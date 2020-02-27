// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.Dicom;
using Leadtools.Codecs;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Leadtools.Medical.Storage.AddIns.StoreAddIn
{
   public static class MedicalViewerPageInfoCache
   {

      static void fillOutputWithDicomDataSet(MedicalViewerPageInfo output, DicomDataSet ds)
      {
         DicomElement elemImagePatientOrientation = ds.FindFirstElement(null, DicomTag.PatientOrientation, true);
         DicomElement elemImagePositionPatient = ds.FindFirstElement(null, DicomTag.ImagePositionPatient, true);
         DicomElement elemImageOrientationPatient = ds.FindFirstElement(null, DicomTag.ImageOrientationPatient, true);
         DicomElement elemImagerPixelSpacing = ds.FindFirstElement(null, DicomTag.ImagerPixelSpacing, true);
         DicomElement elemPixelSpacing = ds.FindFirstElement(null, DicomTag.PixelSpacing, true);
         DicomElement elemPhotometricInterpretation = ds.FindFirstElement(null, DicomTag.PhotometricInterpretation, true);


         if (null != elemPhotometricInterpretation)
         {
            string photometricInterpretation = ds.GetStringValue(elemPhotometricInterpretation, 0);
            output.SupportWindowLevel = photometricInterpretation == "MONOCHROME2" || photometricInterpretation == "MONOCHROME1";
         }

         if (null != elemImagePatientOrientation)
         {
            int count = ds.GetElementValueCount(elemImagePatientOrientation);
            if (count > 0)
            {
               output.PatientOrientation = new string[count];
               for (int index = 0; index < count; index++)
               {
                  output.PatientOrientation[index] = ds.GetStringValue(elemImagePatientOrientation, index);
               }
            }
         }
         if (null != elemImagePositionPatient)
         {
            output.ImagePositionPatientArray = ds.GetDoubleValue(elemImagePositionPatient, 0, 3);
            if (output.ImagePositionPatientArray.Length == 0)
               output.ImagePositionPatientArray = null;
         }
         if (null != elemImageOrientationPatient)
         {
            output.ImageOrientationPatientArray = ds.GetDoubleValue(elemImageOrientationPatient, 0, 6);
            if (output.ImageOrientationPatientArray.Length == 0)
               output.ImageOrientationPatientArray = null;
         }
         if (null != elemPixelSpacing)
         {
            output.PixelSpacingPatientArray = ds.GetDoubleValue(elemPixelSpacing, 0, 2);
            if (output.PixelSpacingPatientArray.Length == 0)
               output.PixelSpacingPatientArray = null;
         }
         else if (null != elemImagerPixelSpacing)
         {
            output.PixelSpacingPatientArray = ds.GetDoubleValue(elemImagerPixelSpacing, 0, 2);
            if (output.PixelSpacingPatientArray.Length == 0)
               output.PixelSpacingPatientArray = null;
         }
      }

      static void FindChildElements(DicomDataSet ds, DicomElement element, long tag, List<DicomElement> elemLst)
      {
         if (null != element)
         {
            DicomElement child = ds.GetChildElement(element, true);
            if (child != null)
            {
               if (child.Tag == tag)
               {
                  elemLst.Add(child);
               }

               FindChildElements(ds, child, tag, elemLst);
               child = ds.GetNextElement(child, true, true);

               while (child != null)
               {
                  FindChildElements(ds, child, tag, elemLst);
                  child = ds.GetNextElement(child, true, true);
               }
            }
         }
      }

      static void Normalize(MedicalViewerPageInfo presentation)
      {
         if (null != presentation.ImagePositionPatientArray)
         {
            if (presentation.ImagePositionPatientArray.Length == 0)
            {
               presentation.ImagePositionPatientArray = null;
            }
         }
         if (null != presentation.ImageOrientationPatientArray)
         {
            if (presentation.ImageOrientationPatientArray.Length == 0)
            {
               presentation.ImageOrientationPatientArray = null;
            }
         }
         if (null != presentation.PixelSpacingPatientArray)
         {
            if (presentation.PixelSpacingPatientArray.Length == 0)
            {
               presentation.PixelSpacingPatientArray = null;
            }
         }
      }

      static List<MedicalViewerPageInfo> GetPagesInfoFromMaster(DicomDataSet ds, MedicalViewerPageInfo ppiMaster)
      {
         try
         {
            List<MedicalViewerPageInfo> ppiLst = new List<MedicalViewerPageInfo>();

            DicomElement elemPerFrameFunctionalGroupsSequence = ds.FindFirstElement(null, DicomTag.PerFrameFunctionalGroupsSequence, true);
            List<DicomElement> elemImagePositionPatient = new List<DicomElement>();
            FindChildElements(ds, elemPerFrameFunctionalGroupsSequence, DicomTag.ImagePositionPatient, elemImagePositionPatient);
            foreach (DicomElement de in elemImagePositionPatient)
            {
               MedicalViewerPageInfo ppi = new MedicalViewerPageInfo
               {
                  ImageOrientationPatientArray = ppiMaster.ImageOrientationPatientArray,
                  ImagePositionPatientArray = ds.GetDoubleValue(de, 0, 3),
                  PixelSpacingPatientArray = ppiMaster.PixelSpacingPatientArray
               };
               Normalize(ppi);
               ppiLst.Add(ppi);
            }

            return ppiLst;
         }
         catch
         {
            return new List<MedicalViewerPageInfo>();
         }
      }

      static string ExtractPDFData(DicomDataSet ds)
      {
         string pdfFullPath = string.Empty;
         string sopInstanceUID = string.Empty;
         DicomElement sopInstanceUIDElement = ds.FindFirstElement(null, DicomTag.SOPInstanceUID, true);

         if (sopInstanceUIDElement == null)
            return pdfFullPath;

         sopInstanceUID = ds.GetStringValue(sopInstanceUIDElement, 0);
         if (string.IsNullOrEmpty(sopInstanceUID))
            return pdfFullPath;

         string tempFolder = Path.GetTempPath();
         string pdfFileName = String.Format("{0}.pdf", sopInstanceUID);
         pdfFullPath = Path.Combine(tempFolder, pdfFileName);

         long lCount;
         DicomElement ele = null;

         if (pdfFullPath == "")
            return string.Empty;

         // check if the pdf has already been extracted
         if (File.Exists(pdfFullPath))
            return pdfFullPath;

         ele = ds.FindFirstElement(null, DicomTag.EncapsulatedDocument, true);
         if (ele != null)
         {
            lCount = ele.Length;
            if (lCount == 0)
               return string.Empty;

            byte[] buf;

            // Get the bytes
            buf = ds.GetBinaryValue(ele, (int)lCount);

            // Dump PDF to file
            using (FileStream fileStream = new FileStream(pdfFullPath, FileMode.Create))
            {
               fileStream.Write(buf, 0, buf.Length);
               fileStream.Close();
               //_pdfCreatedFiles.Add(path);
            }

            return pdfFullPath;
         }

         return string.Empty;
      }

      static MedicalViewerPageInfo[] GetPagesPresentationInfo(DicomDataSet ds, MedicalViewerPageInfo ppiMaster, int DefTotalPages)
      {
         int nFrames = DefTotalPages;
         DicomElement elemNumberOfFrames = ds.FindFirstElement(null, DicomTag.NumberOfFrames, true);

         string path = ExtractPDFData(ds);
         if (!string.IsNullOrEmpty(path))
         {
            using (RasterCodecs codecs = new RasterCodecs())
            {
               using (CodecsImageInfo info = codecs.GetInformation(path, true))
               {
                  nFrames = info.TotalPages;
               }
            }
         }
         else
            if (null != elemNumberOfFrames)
            {
               int[] nFramesList = ds.GetIntValue(elemNumberOfFrames, 0, 1);
               nFrames = Math.Max(nFrames, nFramesList[0]);
            }

         List<MedicalViewerPageInfo> PagePresentationInfoLstFromDS = GetPagesInfoFromMaster(ds, ppiMaster);
         List<MedicalViewerPageInfo> PagePresentationInfoLst = new List<MedicalViewerPageInfo>();

         for (int nIndex = 0; nIndex < nFrames; nIndex++)
         {
            if (nIndex < PagePresentationInfoLstFromDS.Count)
            {
               PagePresentationInfoLst.Add(PagePresentationInfoLstFromDS[nIndex]);
            }
            else
            {
               PagePresentationInfoLst.Add(null);
            }
         }

         return PagePresentationInfoLst.ToArray();
      }

      static string GetImageURI(string sopInstanceUID)
      {
         return string.Format("&instance={0}", sopInstanceUID);
      }

      static void SaveMeta(string referencedFile, object obj)
      {
         if (null == obj || string.IsNullOrEmpty(referencedFile))
         {
            System.Diagnostics.Debug.Assert(false);
            return;
         }

         try
         {
            if (File.Exists(referencedFile))
            {
               File.SetAttributes(referencedFile, FileAttributes.Normal);
               File.Delete(referencedFile);
            }
            else
            {
               Directory.CreateDirectory(Path.GetDirectoryName(referencedFile));
            }

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());

            using (Stream stream = new FileStream(referencedFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
               serializer.WriteObject(stream, obj);
            }
         }
         catch
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      //public static object GetPageDicomData(DicomDataSet ds)
      //{
      //   MedicalViewerPageInfo output = null;
      //   output = new MedicalViewerPageInfo();

      //   fillOutputWithDicomDataSet(output, ds);
      //   output.Pages = GetPagesPresentationInfo(ds, output, 1);

      //   return output;
      //}



      public static void GetPage(string pdiInstancePath, string pyramidFileName, string sopInstanceUid, object pageInfo)
      {
         MedicalViewerPageInfo output = pageInfo as MedicalViewerPageInfo;
         if (output == null)
            return;

         if (!string.IsNullOrEmpty(pyramidFileName))
         {
            //var cat = PyramidImage.GetCatalouge(pyramidFileName, null);
            //if (cat != null)
            //{
            //   output.TileSize = cat.TileSize;
            //   output.ImageUri = GetImageURI(sopInstanceUid);
            //   {
            //      var res = new List<LeadSize>();
            //      foreach (var r in cat.Resolutions)
            //         res.Add(r);
            //      output.Resolutions = res.ToArray();
            //   }
           
            //}
         }

         SaveMeta(pdiInstancePath, output);
      }

   }
}
