// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.Dicom;
using System.IO;
using Leadtools.Codecs;
using System.Drawing;
using Leadtools.ImageProcessing;
using Leadtools.Dicom.Common.Anonymization;
using Leadtools.Annotations.Engine;
using System.Web.Script.Serialization;

namespace Leadtools.Medical.WebViewer.Addins
{
   public static class ExportExtensions
   {
      private static RasterCodecs _Codecs;
      private static Anonymizer _Anonymizer;
       private static Dictionary<string, string> _TagCache = new Dictionary<string, string>();      


      static ExportExtensions()
      {
         _Codecs = new RasterCodecs();          
          _Anonymizer = new Anonymizer();
          _Anonymizer.ApplicationDescription = "HTML5 Medical Viewer";
          _Anonymizer.BeforeTagAnonymization += new EventHandler<BeforeTagAnonymizationEventArgs>(_Anonymizer_BeforeTagAnonymization);
      }      

      public static MemoryStream ToStream(this RasterImage image, RasterImageFormat format, int compression)
      {
         MemoryStream fileStream = new MemoryStream();

         _Codecs.Options.Jpeg.Save.QualityFactor = compression;
         _Codecs.Save(image, fileStream, format, 0);
         return fileStream;
      }
 

      public static RasterImage ResizeImage(this RasterImage currentImage, RectangleF destinationRect)
      {
         RasterImage resizedImage;
         ResizeCommand cmd = new ResizeCommand();

         cmd.Flags = RasterSizeFlags.Bicubic;
         cmd.DestinationImage = currentImage.GetResizedImageToAspectRatio((int)destinationRect.Width, (int)destinationRect.Height);

         cmd.Run(currentImage);

         resizedImage = cmd.DestinationImage;

         return resizedImage;
      }

      private static void _Anonymizer_BeforeTagAnonymization(object sender, BeforeTagAnonymizationEventArgs e)
      {
          if (e.Element != null && (e.Element.Tag == DicomTag.PatientID || e.Element.Tag == DicomTag.PatientBirthDate ||
              e.Element.Tag == DicomTag.PatientName || e.Element.Tag == DicomTag.PatientSex || e.Element.Tag == DicomTag.StudyID ||
              e.Element.Tag == DicomTag.StudyInstanceUID || e.Element.Tag == DicomTag.SeriesInstanceUID))
          {
              string itemToFind = string.Empty;

              if (e.Element.Tag == DicomTag.StudyInstanceUID || e.Element.Tag == DicomTag.SeriesInstanceUID || e.Element.Tag == DicomTag.StudyID)
              {
                  itemToFind = e.CurrentValue;
              }
              else
              {
                  itemToFind = e.Element.Tag.ToString();
              }

              if (_TagCache.ContainsKey(itemToFind))
                  e.NewValue = _TagCache[itemToFind];
              else
              {
                  _TagCache[itemToFind] = e.NewValue;
              }
          }
      }

       public static void ResetAnonymization()
       {
           _TagCache.Clear();   
       }
    
       public static void Anonymize(this DicomDataSet dataset)
       {           
           _Anonymizer.Anonymize(dataset);
       }
      
   }
   
}
