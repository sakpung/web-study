// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing;
using Leadtools.Dicom.Common.DataTypes.PresentationState;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Annotations.Engine;
using Leadtools.Dicom.Annotations;
using Leadtools.Medical.Storage.DataAccessLayer;
using System.Web.Script.Serialization;
using System.IO;
using Leadtools.Dicom.Common.Extensions;
using System.Data;
using Leadtools.Medical.Storage.DataAccessLayer.Interface;

namespace Leadtools.Medical.WebViewer.Addins
{
    /// <summary>
    /// 
    /// </summary>
    class DSTemplate
    {
        static byte[] TemplateDS_SecondaryCapture = new byte[]{
  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
, 0x44, 0x49, 0x43, 0x4D, 0x02, 0x00, 0x00, 0x00, 0x55, 0x4C, 0x04, 0x00, 0x6E, 0x00, 0x00, 0x00
, 0x02, 0x00, 0x01, 0x00, 0x4F, 0x42, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x01, 0x02, 0x00
, 0x02, 0x00, 0x55, 0x49, 0x1A, 0x00, 0x31, 0x2E, 0x32, 0x2E, 0x38, 0x34, 0x30, 0x2E, 0x31, 0x30
, 0x30, 0x30, 0x38, 0x2E, 0x35, 0x2E, 0x31, 0x2E, 0x34, 0x2E, 0x31, 0x2E, 0x31, 0x2E, 0x37, 0x00
, 0x02, 0x00, 0x10, 0x00, 0x55, 0x49, 0x14, 0x00, 0x31, 0x2E, 0x32, 0x2E, 0x38, 0x34, 0x30, 0x2E
, 0x31, 0x30, 0x30, 0x30, 0x38, 0x2E, 0x31, 0x2E, 0x32, 0x2E, 0x31, 0x00, 0x02, 0x00, 0x12, 0x00
, 0x55, 0x49, 0x1A, 0x00, 0x31, 0x2E, 0x32, 0x2E, 0x38, 0x34, 0x30, 0x2E, 0x31, 0x31, 0x34, 0x32
, 0x35, 0x37, 0x2E, 0x31, 0x2E, 0x32, 0x2E, 0x31, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x08, 0x00
, 0x08, 0x00, 0x43, 0x53, 0x10, 0x00, 0x44, 0x45, 0x52, 0x49, 0x56, 0x45, 0x44, 0x5C, 0x50, 0x52
, 0x49, 0x4D, 0x41, 0x52, 0x59, 0x20, 0x08, 0x00, 0x16, 0x00, 0x55, 0x49, 0x1A, 0x00, 0x31, 0x2E
, 0x32, 0x2E, 0x38, 0x34, 0x30, 0x2E, 0x31, 0x30, 0x30, 0x30, 0x38, 0x2E, 0x35, 0x2E, 0x31, 0x2E
, 0x34, 0x2E, 0x31, 0x2E, 0x31, 0x2E, 0x37, 0x00, 0x08, 0x00, 0x18, 0x00, 0x55, 0x49, 0x00, 0x00
, 0x08, 0x00, 0x20, 0x00, 0x44, 0x41, 0x00, 0x00, 0x08, 0x00, 0x21, 0x00, 0x44, 0x41, 0x00, 0x00
, 0x08, 0x00, 0x23, 0x00, 0x44, 0x41, 0x00, 0x00, 0x08, 0x00, 0x30, 0x00, 0x54, 0x4D, 0x00, 0x00
, 0x08, 0x00, 0x31, 0x00, 0x54, 0x4D, 0x00, 0x00, 0x08, 0x00, 0x33, 0x00, 0x54, 0x4D, 0x00, 0x00
, 0x08, 0x00, 0x50, 0x00, 0x53, 0x48, 0x00, 0x00, 0x08, 0x00, 0x60, 0x00, 0x43, 0x53, 0x02, 0x00
, 0x4F, 0x54, 0x08, 0x00, 0x64, 0x00, 0x43, 0x53, 0x04, 0x00, 0x57, 0x53, 0x44, 0x20, 0x08, 0x00
, 0x70, 0x00, 0x4C, 0x4F, 0x12, 0x00, 0x4C, 0x45, 0x41, 0x44, 0x20, 0x54, 0x65, 0x63, 0x68, 0x6E
, 0x6F, 0x6C, 0x6F, 0x67, 0x69, 0x65, 0x73, 0x20, 0x08, 0x00, 0x90, 0x00, 0x50, 0x4E, 0x00, 0x00
, 0x08, 0x00, 0x30, 0x10, 0x4C, 0x4F, 0x00, 0x00, 0x08, 0x00, 0x3E, 0x10, 0x4C, 0x4F, 0x00, 0x00
, 0x08, 0x00, 0x70, 0x10, 0x50, 0x4E, 0x00, 0x00, 0x10, 0x00, 0x10, 0x00, 0x50, 0x4E, 0x00, 0x00
, 0x10, 0x00, 0x20, 0x00, 0x4C, 0x4F, 0x00, 0x00, 0x10, 0x00, 0x30, 0x00, 0x44, 0x41, 0x00, 0x00
, 0x10, 0x00, 0x40, 0x00, 0x43, 0x53, 0x00, 0x00, 0x18, 0x00, 0x12, 0x10, 0x44, 0x41, 0x00, 0x00
, 0x18, 0x00, 0x14, 0x10, 0x54, 0x4D, 0x00, 0x00, 0x18, 0x00, 0x30, 0x10, 0x4C, 0x4F, 0x00, 0x00
, 0x20, 0x00, 0x0D, 0x00, 0x55, 0x49, 0x00, 0x00, 0x20, 0x00, 0x0E, 0x00, 0x55, 0x49, 0x00, 0x00
, 0x20, 0x00, 0x10, 0x00, 0x53, 0x48, 0x00, 0x00, 0x20, 0x00, 0x11, 0x00, 0x49, 0x53, 0x00, 0x00
, 0x20, 0x00, 0x13, 0x00, 0x49, 0x53, 0x00, 0x00, 0x20, 0x00, 0x20, 0x00, 0x43, 0x53, 0x00, 0x00
, 0x20, 0x00, 0x60, 0x00, 0x43, 0x53, 0x00, 0x00, 0x28, 0x00, 0x02, 0x00, 0x55, 0x53, 0x00, 0x00
, 0x28, 0x00, 0x04, 0x00, 0x43, 0x53, 0x00, 0x00, 0x28, 0x00, 0x06, 0x00, 0x55, 0x53, 0x00, 0x00
, 0x28, 0x00, 0x10, 0x00, 0x55, 0x53, 0x00, 0x00, 0x28, 0x00, 0x11, 0x00, 0x55, 0x53, 0x00, 0x00
, 0x28, 0x00, 0x30, 0x00, 0x44, 0x53, 0x00, 0x00, 0x28, 0x00, 0x34, 0x00, 0x49, 0x53, 0x00, 0x00
, 0x28, 0x00, 0x00, 0x01, 0x55, 0x53, 0x00, 0x00, 0x28, 0x00, 0x01, 0x01, 0x55, 0x53, 0x00, 0x00
, 0x28, 0x00, 0x02, 0x01, 0x55, 0x53, 0x00, 0x00, 0x28, 0x00, 0x03, 0x01, 0x55, 0x53, 0x02, 0x00
, 0x00, 0x00, 0x28, 0x00, 0x01, 0x03, 0x43, 0x53, 0x04, 0x00, 0x59, 0x45, 0x53, 0x20, 0x28, 0x00
, 0x10, 0x21, 0x43, 0x53, 0x02, 0x00, 0x30, 0x31};

        static public DicomDataSet CreateDS_SecondaryCapture()
        {
            DicomDataSet ds = new DicomDataSet();
            using (MemoryStream stream = new MemoryStream(TemplateDS_SecondaryCapture))
            {
                ds.Load(stream, DicomDataSetLoadFlags.None);
                return ds;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class SeriesGenerator
    {
        public static string GenerateDicomUniqueIdentifier()
        {
            string strGUID = "";

            try
            {
                DateTime SystemTime = DateTime.Now;
                Random rand = new Random((int)SystemTime.Ticks);
                strGUID = string.Format("1.2.840.114257.1.1{0}{1}{2}", SystemTime.Ticks, rand.Next(), rand.Next());
                // max length for this field is 64 so cut it off if too long
                if (strGUID.Length > 64)
                    strGUID = strGUID.Substring(0, 64);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strGUID;
        }

        void CopyExistingElementsValues(DicomDataSet dsTarget, DicomDataSet dsSrc)
        {
            for (int nIndex = 0; nIndex < dsTarget.ModuleCount; nIndex++)
            {
                DicomModule dm = dsTarget.FindModuleByIndex(nIndex);

                foreach (DicomElement elementTarget in dm.Elements)
                {
                    if (elementTarget.Length == 0)
                    {
                        DicomElement elementSrc = dsSrc.FindFirstElement(null, elementTarget.Tag, false);
                        if (null != elementSrc)
                        {
                            dsTarget.SetValue(elementTarget, dsSrc.GetValue<object>(elementSrc, null));
                        }
                    }
                }
            }
        }

        DicomDataSet Duplicate(DicomDataSet original, RasterImage derivedImage)
        {
            DicomDataSet derivedDataSet = DSTemplate.CreateDS_SecondaryCapture();

            CopyExistingElementsValues(derivedDataSet, original);

            derivedDataSet.SetImage(null,
               derivedImage,
               DicomImageCompressionType.JpegLossy,
               DicomImagePhotometricInterpretationType.Rgb,
               24,
               10,
               DicomSetImageFlags.None);

            SetWindowLevel(derivedImage, derivedDataSet);

            return derivedDataSet;
        }

        int GetInstanceNumber(DicomDataSet ds)
        {
            try
            {
                DicomElement dicomElement = null;

                dicomElement = ds.FindFirstElement(null, DicomTag.InstanceNumber, false);

                if (dicomElement != null)
                {
                    int[] Values = ds.GetIntValue(dicomElement, 0, 1);
                    return Values[0];
                }

                return 0;
            }
            catch
            {
                return 0;
            }
        }

        //in safari, when canvas is captured, that has transparency, it fills transparent areas with 255 not black
        //we force transparent areas to be black instead
        static void PreProcessBitmap(RasterImage derivedImage)
        {
            using (RasterImage alpha = derivedImage.CreateAlphaImage())
            {
                alpha.AddColorRgbRangeToRegion(new RasterColor(0, 0, 0), new RasterColor(3, 3, 3), RasterRegionCombineMode.Set);
                derivedImage.SetRegion(null, alpha.GetRegion(null), RasterRegionCombineMode.Set);
                FillCommand fill = new FillCommand(new RasterColor(0, 0, 0));
                fill.Run(derivedImage);
            }
        }

        public DicomDataSet GenerateDerivedInstance
        (
           DicomDataSet original,
           RasterImage derivedImage,
           string seriesDescription,
           string seriesNumber,
           string protocolName,
           string userName
        )
        {
            string sopInstanceUID = GenerateDicomUniqueIdentifier();
            string seriesInstancUID = GenerateDicomUniqueIdentifier();

            PreProcessBitmap(derivedImage);

            DicomDataSet derivedDataSet = Duplicate(original, derivedImage);

            if (!string.IsNullOrEmpty(seriesDescription))
            {
                derivedDataSet.InsertElementAndSetValue(DicomTag.SeriesDescription, seriesDescription);
            }

            if (!string.IsNullOrEmpty(seriesInstancUID))
            {
                derivedDataSet.InsertElementAndSetValue(DicomTag.SeriesInstanceUID, seriesInstancUID);
            }

            if (string.IsNullOrEmpty(sopInstanceUID))
            {
                throw new InvalidOperationException("SOP Instance UID can't be empty.");
            }

            if (!string.IsNullOrEmpty(seriesNumber))
            {
                derivedDataSet.InsertElementAndSetValue(DicomTag.SeriesNumber, seriesNumber);
            }

            if (!string.IsNullOrEmpty(protocolName))
            {
                derivedDataSet.InsertElementAndSetValue(DicomTag.ProtocolName, protocolName);
            }

            derivedDataSet.InsertElementAndSetValue(DicomTag.SeriesDate, original.GetValue<string>(DicomTag.SeriesDate, string.Empty));
            derivedDataSet.InsertElementAndSetValue(DicomTag.SeriesTime, original.GetValue<string>(DicomTag.SeriesTime, string.Empty));

            derivedDataSet.InsertElementAndSetValue(DicomTag.InstanceCreationDate, DateTime.Now);
            derivedDataSet.InsertElementAndSetValue(DicomTag.InstanceCreationTime, DateTime.Now);
            derivedDataSet.InsertElementAndSetValue(DicomTag.ContentDate, DateTime.Now);
            derivedDataSet.InsertElementAndSetValue(DicomTag.ContentTime, DateTime.Now);
            derivedDataSet.InsertElementAndSetValue(DicomTag.DateOfSecondaryCapture, DateTime.Now);
            derivedDataSet.InsertElementAndSetValue(DicomTag.TimeOfSecondaryCapture, DateTime.Now);

            derivedDataSet.InsertElementAndSetValue(DicomTag.SOPInstanceUID, sopInstanceUID);
            derivedDataSet.InsertElementAndSetValue(DicomTag.MediaStorageSOPInstanceUID, sopInstanceUID);

            derivedDataSet.InsertElementAndSetValue(DicomTag.OperatorName, userName);
            derivedDataSet.InsertElementAndSetValue(DicomTag.ConversionType, "WSD");
            derivedDataSet.InsertElementAndSetValue(DicomTag.Modality, "OT");
            derivedDataSet.InsertElementAndSetValue(DicomTag.InstanceNumber, GetInstanceNumber(derivedDataSet) + 1);
            derivedDataSet.InsertElementAndSetValue(DicomTag.ImageType, "DERIVED\\SECONDARY");

            return derivedDataSet;
        }

        public static DicomDataSet GeneratePresentationStateForAnnotations
        (
           string userName,
           string seriesInstanceUID,
           string annotationData,
           string description,
           string userData,
           DataSet seriesDs
        )
        {
            AnnCodecs codec = new AnnCodecs();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(annotationData)))
            {
                ms.Position = 0;
                AnnCodecsInfo codecInfo = codec.GetInfo(ms);
                ms.Position = 0;
                JavaScriptSerializer jsSerialzer = new JavaScriptSerializer();
                DicomAnnotationsUtilities dicomAnnotationsUtilities = new DicomAnnotationsUtilities();

                if (null == seriesDs || seriesDs.Tables[DataTableHelper.PatientTableName].Rows.Count == 0 || seriesDs.Tables[DataTableHelper.StudyTableName].Rows.Count == 0)
                {
                    throw new Exception("Series not found");
                }

                DicomDataSet ds = new DicomDataSet();

                {
                    DataRow patient = seriesDs.Tables[DataTableHelper.PatientTableName].Rows[0];
                    DataRow study = seriesDs.Tables[DataTableHelper.StudyTableName].Rows[0];

                    IPatientInfo patientInfo = RegisteredDataRows.PatientInfo;
                    PersonNameComponent pn = patientInfo.Name(patient);
                    string sFamilyName = pn.FamilyName;
                    string sGivenName = pn.GivenName;
                    string sMiddleName = pn.MiddleName;
                    string sNamePrefix = pn.NamePrefix;
                    string sNameSuffix = pn.NameSuffix;
                    string sPatientId = patientInfo.GetElementValue(patient, DicomTag.PatientID);

                    //Patient Module C.7.1.1
                    ds.InsertElementAndSetValue(DicomTag.PatientName, string.Format("{0}^{1}^{2}^{3}^{4}",
                       string.IsNullOrEmpty(sFamilyName) ? "" : sFamilyName,
                       string.IsNullOrEmpty(sGivenName) ? "" : sGivenName,
                       string.IsNullOrEmpty(sMiddleName) ? "" : sMiddleName,
                       string.IsNullOrEmpty(sNamePrefix) ? "" : sNamePrefix,
                       string.IsNullOrEmpty(sNameSuffix) ? "" : sNameSuffix));

                    ds.InsertElementAndSetValue(DicomTag.PatientID, sPatientId);
                    ds.InsertElementAndSetValue(DicomTag.PatientBirthDate, "");
                    ds.InsertElementAndSetValue(DicomTag.PatientSex, "");

                    IStudyInfo studyInfo = RegisteredDataRows.StudyInfo;
                    string sStudyInstanceUid = studyInfo.GetElementValue(study, DicomTag.StudyInstanceUID);
                    string sAccessionNumber = studyInfo.GetElementValue(study, DicomTag.AccessionNumber);
                    string sStudyId = studyInfo.GetElementValue(study, DicomTag.StudyID);

                    //Study Module C.7.2.1
                    ds.InsertElementAndSetValue(DicomTag.StudyInstanceUID, sStudyInstanceUid);
                    ds.InsertElementAndSetValue(DicomTag.StudyDate, "");
                    ds.InsertElementAndSetValue(DicomTag.StudyTime, "");
                    ds.InsertElementAndSetValue(DicomTag.ReferringPhysicianName, "");
                    ds.InsertElementAndSetValue(DicomTag.StudyID, string.IsNullOrEmpty(sStudyId) ? "" : sStudyId);
                    ds.InsertElementAndSetValue(DicomTag.AccessionNumber, string.IsNullOrEmpty(sAccessionNumber) ? "" : sAccessionNumber);

                    //Series Module C.7.3.1
                    ds.InsertElementAndSetValue(DicomTag.SeriesInstanceUID, SeriesGenerator.GenerateDicomUniqueIdentifier());
                    ds.InsertElementAndSetValue(DicomTag.Modality, "PR");
                    ds.InsertElementAndSetValue(DicomTag.SeriesNumber, 1);
                    ds.InsertElementAndSetValue(DicomTag.SeriesDate, DicomDateValue.Now);
                    ds.InsertElementAndSetValue(DicomTag.SeriesTime, DicomTimeValue.Now);
                    ds.InsertElementAndSetValue(DicomTag.SeriesDescription, "Annotations presentation state");

                    //General Equipment Module C.7.5.1
                    ds.InsertElementAndSetValue(DicomTag.Manufacturer, "LEADTOOLS IMAGING");
                    ds.InsertElementAndSetValue(DicomTag.InstitutionName, "LEADTOOLS, INC.");
                    ds.InsertElementAndSetValue(DicomTag.StationName, "HTML5 Viewer");

                    //Presentation State Identification Module C.11.10
                    ds.InsertElementAndSetValue(DicomTag.PresentationCreationDate, DicomDateValue.Now);
                    ds.InsertElementAndSetValue(DicomTag.PresentationCreationTime, DicomTimeValue.Now);
                    //Content Identification Macro Table 10-12
                    ds.InsertElementAndSetValue(DicomTag.InstanceNumber, 1);
                    ds.InsertElementAndSetValue(DicomTag.ContentLabel, "ANNOTATIONS");
                    ds.InsertElementAndSetValue(DicomTag.ContentDescription, description);
                    ds.InsertElementAndSetValue(DicomTag.ContentCreatorName, userName);

                    //Presentation State RelationShip Module C11.11
                    PresentationStateRelationShip referncedSeriesSeq = new PresentationStateRelationShip();
                    referncedSeriesSeq.ReferencedSeriesSequence = new List<ReferencedSeries>();
                    ReferencedSeries referencedSeries = new ReferencedSeries();
                    referencedSeries.SeriesInstanceUID = seriesInstanceUID;
                    referencedSeries.ReferencedImageSequence = new List<SopInstanceReference>();
                    referncedSeriesSeq.ReferencedSeriesSequence.Add(referencedSeries);


                    Dictionary<LeadSize, List<ImageSopInstanceReference>> displayedAreaInstance = new Dictionary<LeadSize, List<ImageSopInstanceReference>>();
                    for (int index = 0; index < codecInfo.Pages.Length; index++)
                    {
                        AnnContainer container = codec.Load(ms, codecInfo.Pages[index]);
                        ms.Position = 0;

                        if (null == container.UserData)
                        {
                            continue;
                        }

                        AnnUserData refInstance = (AnnUserData)jsSerialzer.Deserialize<AnnUserData>(container.UserData.ToString());

                        if (null != refInstance && null != refInstance.ReferencedImageSequence)
                        {
                            referncedSeriesSeq.ReferencedSeriesSequence[0].ReferencedImageSequence.Add(refInstance.ReferencedImageSequence);

                            // The Medical Viewer defaults dpi to 150
                            // In this case, there is enough information to compute the dpi, which should be 150

                            //double dpiX = 0;
                            //double dpiY = 0;   
                            //container.CalculateDpi(out dpiX, out dpiY);

                            //if (dpiX == 0 || dpiY == 0)
                            //{
                            //   dpiX = 150.0;
                            //   dpiY = 150.0;
                            //}
                            double xDpi = 150;
                            double yDpi = 150;

                            dicomAnnotationsUtilities.ImageDpiX = xDpi;
                            dicomAnnotationsUtilities.ImageDpiY = yDpi;


                            DicomElement graphicSequenceItem = dicomAnnotationsUtilities.FromAnnContainerToDataSet(ds, container);

                            DicomElement layerElement = ds.FindFirstElement(graphicSequenceItem, DicomTag.GraphicLayer, false);

                            if (null == layerElement)
                            {
                                ds.InsertElementAndSetValue(graphicSequenceItem, true, DicomTag.GraphicLayer, "LAYER1");
                            }
                            else
                            {
                                ds.SetStringValue(layerElement, "LAYER1", DicomCharacterSetType.Default);
                            }

                            GraphicAnnotationsModule annModule = new GraphicAnnotationsModule();

                            annModule.ReferencedImageSequence = new List<ImageSopInstanceReference>();
                            annModule.ReferencedImageSequence.Add(refInstance.ReferencedImageSequence);

                            ds.Set(graphicSequenceItem, annModule);
                        }

                        if (!refInstance.ImageSize.IsEmpty)
                        {
                            if (!displayedAreaInstance.ContainsKey(refInstance.ImageSize))
                            {
                                displayedAreaInstance[refInstance.ImageSize] = new List<ImageSopInstanceReference>();
                            }

                            displayedAreaInstance[refInstance.ImageSize].Add(refInstance.ReferencedImageSequence);
                        }
                    }

                    ds.Set(referncedSeriesSeq);

                    //Displayed Area Module
                    //
                    //
                    DisplayedAreaModule displayedAreaModule = new DisplayedAreaModule();


                    displayedAreaModule.DisplayedAreaSelection = new List<DisplayedAreaSelection>();

                    foreach (KeyValuePair<LeadSize, List<ImageSopInstanceReference>> areaInstance in displayedAreaInstance)
                    {
                        DisplayedAreaSelection displayedArea = new DisplayedAreaSelection();
                        displayedAreaModule.DisplayedAreaSelection.Add(displayedArea);
                        displayedArea.DisplayedAreaTopLeftHandCorner = new List<long>();
                        displayedArea.DisplayedAreaBottomRightHandCorner = new List<long>();
                        displayedArea.DisplayedAreaTopLeftHandCorner.Add(1);
                        displayedArea.DisplayedAreaTopLeftHandCorner.Add(1);
                        displayedArea.DisplayedAreaBottomRightHandCorner.Add(areaInstance.Key.Width);
                        displayedArea.DisplayedAreaBottomRightHandCorner.Add(areaInstance.Key.Height);
                        displayedArea.PresentationSizeMode = PresentationSizeMode.ScaleToFit;
                        displayedArea.PresentationPixelAspectRatio = new List<int>();
                        displayedArea.PresentationPixelAspectRatio.Add(1);
                        displayedArea.PresentationPixelAspectRatio.Add(1);

                        if (displayedAreaInstance.Count > 1)
                        {
                            displayedArea.ReferencedImageSequence = areaInstance.Value;
                        }
                    }

                    ds.Set(displayedAreaModule);

                    //Graphic Layer Module
                    GraphicLayerModule graphicLayerModule = new GraphicLayerModule();
                    graphicLayerModule.GraphicLayerSequence = new List<GraphicLayer>();
                    GraphicLayer layer = new GraphicLayer();
                    layer.GraphicLayerName = "LAYER1";
                    layer.GraphicLayerOrder = 1;
                    graphicLayerModule.GraphicLayerSequence.Add(layer);

                    ds.Set(graphicLayerModule);

                    //Softcopy Presentation LUT Module
                    SoftCopyPresentationLutModule presentationLut = new SoftCopyPresentationLutModule();
                    presentationLut.PresentationLutShape = PresentationLutShape.Identity;

                    ds.Set(presentationLut);

                    //SOP Common Module
                    ds.InsertElementAndSetValue(DicomTag.SOPClassUID, DicomUidType.GrayscaleSoftcopyPresentationStateStorage);
                    ds.InsertElementAndSetValue(DicomTag.SOPInstanceUID, SeriesGenerator.GenerateDicomUniqueIdentifier());
                    ds.InsertElementAndSetValue(DicomTag.InstanceCreationDate, DicomDateValue.Now);
                    ds.InsertElementAndSetValue(DicomTag.InstanceCreationTime, DicomDateValue.Now);
                    ds.InsertElementAndSetValue(DicomTag.InstanceNumber, 1);
                }
                return ds;
            }
        }

        public static DicomDataSet GeneratePresentationState(string seriesInstanceUID, string annotationData, string description, DicomDataSet seriesDs, int windowCenter, int windowWidth, out string sopInstanceUID)
        {
            AnnCodecs codec = new AnnCodecs();

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(annotationData)))
            {
                ms.Position = 0;
                AnnCodecsInfo codecInfo = codec.GetInfo(ms);
                ms.Position = 0;
                JavaScriptSerializer jsSerialzer = new JavaScriptSerializer();
                DicomAnnotationsUtilities dicomAnnotationsUtilities = new DicomAnnotationsUtilities();
                DicomDataSet ds = new DicomDataSet();


                sopInstanceUID = SeriesGenerator.GenerateDicomUniqueIdentifier();
                //Patient Module C.7.1.1
                ds.InsertElementAndSetValue(DicomTag.PatientName, seriesDs.GetValue<string>(DicomTag.PatientName, string.Empty));

                ds.InsertElementAndSetValue(DicomTag.PatientID, seriesDs.GetValue<string>(DicomTag.PatientID, string.Empty));
                ds.InsertElementAndSetValue(DicomTag.PatientBirthDate, "");
                ds.InsertElementAndSetValue(DicomTag.PatientSex, "");

                //Study Module C.7.2.1
                ds.InsertElementAndSetValue(DicomTag.StudyInstanceUID, seriesDs.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty));
                ds.InsertElementAndSetValue(DicomTag.StudyDate, "");
                ds.InsertElementAndSetValue(DicomTag.StudyTime, "");
                ds.InsertElementAndSetValue(DicomTag.ReferringPhysicianName, "");
                ds.InsertElementAndSetValue(DicomTag.StudyID, seriesDs.GetValue<string>(DicomTag.StudyID, string.Empty));
                ds.InsertElementAndSetValue(DicomTag.AccessionNumber, seriesDs.GetValue<string>(DicomTag.AccessionNumber, string.Empty));

                //Series Module C.7.3.1
                ds.InsertElementAndSetValue(DicomTag.SeriesInstanceUID, SeriesGenerator.GenerateDicomUniqueIdentifier());
                ds.InsertElementAndSetValue(DicomTag.Modality, "PR");
                ds.InsertElementAndSetValue(DicomTag.SeriesNumber, 1);
                ds.InsertElementAndSetValue(DicomTag.SeriesDate, DicomDateValue.Now);
                ds.InsertElementAndSetValue(DicomTag.SeriesTime, DicomTimeValue.Now);
                ds.InsertElementAndSetValue(DicomTag.SeriesDescription, "Study layout presentation state");

                //General Equipment Module C.7.5.1
                ds.InsertElementAndSetValue(DicomTag.Manufacturer, "LEADTOOLS IMAGING");
                ds.InsertElementAndSetValue(DicomTag.InstitutionName, "LEADTOOLS, INC.");
                ds.InsertElementAndSetValue(DicomTag.StationName, "HTML5 Viewer");

                //Presentation State Identification Module C.11.10
                ds.InsertElementAndSetValue(DicomTag.PresentationCreationDate, DicomDateValue.Now);
                ds.InsertElementAndSetValue(DicomTag.PresentationCreationTime, DicomTimeValue.Now);
                //Content Identification Macro Table 10-12
                ds.InsertElementAndSetValue(DicomTag.InstanceNumber, 1);
                ds.InsertElementAndSetValue(DicomTag.ContentLabel, "STUDY LAYOUT PRESENTATION");
                ds.InsertElementAndSetValue(DicomTag.ContentDescription, description);
                //ds.InsertElementAndSetValue(DicomTag.ContentCreatorName, userName);

                //Presentation State RelationShip Module C11.11
                PresentationStateRelationShip referncedSeriesSeq = new PresentationStateRelationShip();
                referncedSeriesSeq.ReferencedSeriesSequence = new List<ReferencedSeries>();
                ReferencedSeries referencedSeries = new ReferencedSeries();
                referencedSeries.SeriesInstanceUID = seriesInstanceUID;
                referencedSeries.ReferencedImageSequence = new List<SopInstanceReference>();
                referncedSeriesSeq.ReferencedSeriesSequence.Add(referencedSeries);


                Dictionary<LeadSize, List<ImageSopInstanceReference>> displayedAreaInstance = new Dictionary<LeadSize, List<ImageSopInstanceReference>>();
                for (int index = 0; index < codecInfo.Pages.Length; index++)
                {
                    AnnContainer container = codec.Load(ms, codecInfo.Pages[index]);
                    ms.Position = 0;

                    if (null == container.UserData)
                    {
                        continue;
                    }

                    AnnUserData refInstance = (AnnUserData)jsSerialzer.Deserialize<AnnUserData>(container.UserData.ToString());

                    if (null != refInstance && null != refInstance.ReferencedImageSequence)
                    {
                        referncedSeriesSeq.ReferencedSeriesSequence[0].ReferencedImageSequence.Add(refInstance.ReferencedImageSequence);

                        // The Medical Viewer defaults dpi to 150
                        // In this case, there is enough information to compute the dpi, which should be 150

                        //double dpiX = 0;
                        //double dpiY = 0;   
                        //container.CalculateDpi(out dpiX, out dpiY);

                        //if (dpiX == 0 || dpiY == 0)
                        //{
                        //   dpiX = 150.0;
                        //   dpiY = 150.0;
                        //}
                        double xDpi = 150;
                        double yDpi = 150;

                        dicomAnnotationsUtilities.ImageDpiX = xDpi;
                        dicomAnnotationsUtilities.ImageDpiY = yDpi;


                        DicomElement graphicSequenceItem = dicomAnnotationsUtilities.FromAnnContainerToDataSet(ds, container);

                        DicomElement layerElement = ds.FindFirstElement(graphicSequenceItem, DicomTag.GraphicLayer, false);

                        if (null == layerElement)
                        {
                            ds.InsertElementAndSetValue(graphicSequenceItem, true, DicomTag.GraphicLayer, "LAYER1");
                        }
                        else
                        {
                            ds.SetStringValue(layerElement, "LAYER1", DicomCharacterSetType.Default);
                        }

                        GraphicAnnotationsModule annModule = new GraphicAnnotationsModule();

                        annModule.ReferencedImageSequence = new List<ImageSopInstanceReference>();
                        annModule.ReferencedImageSequence.Add(refInstance.ReferencedImageSequence);

                        ds.Set(graphicSequenceItem, annModule);
                    }

                    if (!refInstance.ImageSize.IsEmpty)
                    {
                        if (!displayedAreaInstance.ContainsKey(refInstance.ImageSize))
                        {
                            displayedAreaInstance[refInstance.ImageSize] = new List<ImageSopInstanceReference>();
                        }

                        displayedAreaInstance[refInstance.ImageSize].Add(refInstance.ReferencedImageSequence);
                    }
                }

                ds.Set(referncedSeriesSeq);

                //Displayed Area Module
                //
                //
                DisplayedAreaModule displayedAreaModule = new DisplayedAreaModule();


                displayedAreaModule.DisplayedAreaSelection = new List<DisplayedAreaSelection>();

                foreach (KeyValuePair<LeadSize, List<ImageSopInstanceReference>> areaInstance in displayedAreaInstance)
                {
                    DisplayedAreaSelection displayedArea = new DisplayedAreaSelection();
                    displayedAreaModule.DisplayedAreaSelection.Add(displayedArea);
                    displayedArea.DisplayedAreaTopLeftHandCorner = new List<long>();
                    displayedArea.DisplayedAreaBottomRightHandCorner = new List<long>();
                    displayedArea.DisplayedAreaTopLeftHandCorner.Add(1);
                    displayedArea.DisplayedAreaTopLeftHandCorner.Add(1);
                    displayedArea.DisplayedAreaBottomRightHandCorner.Add(areaInstance.Key.Width);
                    displayedArea.DisplayedAreaBottomRightHandCorner.Add(areaInstance.Key.Height);
                    displayedArea.PresentationSizeMode = PresentationSizeMode.ScaleToFit;
                    displayedArea.PresentationPixelAspectRatio = new List<int>();
                    displayedArea.PresentationPixelAspectRatio.Add(1);
                    displayedArea.PresentationPixelAspectRatio.Add(1);

                    if (displayedAreaInstance.Count > 1)
                    {
                        displayedArea.ReferencedImageSequence = areaInstance.Value;
                    }
                }

                ds.Set(displayedAreaModule);

                //Graphic Layer Module
                GraphicLayerModule graphicLayerModule = new GraphicLayerModule();                
                GraphicLayer layer = new GraphicLayer();

                graphicLayerModule.GraphicLayerSequence = new List<GraphicLayer>();
                layer.GraphicLayerName = "LAYER1";
                layer.GraphicLayerOrder = 1;
                graphicLayerModule.GraphicLayerSequence.Add(layer);

                ds.Set(graphicLayerModule);

                //Softcopy Presentation LUT Module
                SoftCopyPresentationLutModule presentationLut = new SoftCopyPresentationLutModule();
                presentationLut.PresentationLutShape = PresentationLutShape.Identity;
                if (windowCenter != -1 || windowWidth != -1)
                {
                    SoftCopyVoiLutModule module = new SoftCopyVoiLutModule();

                    module.WindowCenter = new List<double>();
                    module.WindowCenter.Add(windowCenter);
                    module.WindowWidth = new List<double>();
                    module.WindowWidth.Add(windowWidth);
                    ds.Set(module);
                }

                ds.Set(presentationLut);

                //SOP Common Module
                ds.InsertElementAndSetValue(DicomTag.SOPClassUID, DicomUidType.GrayscaleSoftcopyPresentationStateStorage);
                ds.InsertElementAndSetValue(DicomTag.SOPInstanceUID, sopInstanceUID);
                ds.InsertElementAndSetValue(DicomTag.InstanceCreationDate, DicomDateValue.Now);
                ds.InsertElementAndSetValue(DicomTag.InstanceCreationTime, DicomDateValue.Now);
                ds.InsertElementAndSetValue(DicomTag.InstanceNumber, 1);

                return ds;
            }
        }

        private static void SetWindowLevel(RasterImage derivedImage, DicomDataSet derivedDataSet)
        {
            if (derivedImage.GetLookupTable() != null)
            {
                GetLinearVoiLookupTableCommand cmd = new GetLinearVoiLookupTableCommand();
                cmd.Run(derivedImage);

                derivedDataSet.InsertElementAndSetValue(DicomTag.WindowCenter, cmd.Center);
                derivedDataSet.InsertElementAndSetValue(DicomTag.WindowWidth, cmd.Width);
            }
            else
            {
                derivedDataSet.InsertElementAndSetValue(DicomTag.WindowCenter, 127);
                derivedDataSet.InsertElementAndSetValue(DicomTag.WindowWidth, 255);
            }
        }
    }
}
