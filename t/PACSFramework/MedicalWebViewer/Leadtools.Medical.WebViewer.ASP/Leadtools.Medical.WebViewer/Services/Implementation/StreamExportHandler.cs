// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;
using System.Web.Hosting;
using Leadtools.Medical.WebViewer.Core.DataTypes.Common;
using System.Xml;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.ServiceContracts;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   public class StreamExportHandler : IStreamExportHandler
   {
      IExportAddin _exportAddin;
      
      public StreamExportHandler (AddinsFactory factory)
      {
         _exportAddin = factory.CreateExportAddin();
      }

      #region IExportHandler Members

      public Task<Stream> ExportAllSeries(string authenticationCookie, string patientID, ExportOptions options)
      {
         return Task.Factory.StartNew<Stream>(() =>
         {
            var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
            var zip = _exportAddin.ExportAllSeries(userName, patientID, options);
            return zip;
         });
      }

      public Task<Stream> ExportSeries(string authenticationCookie, string[] seriesInstanceUIDs, ExportOptions options)
      {
         return Task.Factory.StartNew<Stream>(() =>
         {
            var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
            var zip = _exportAddin.ExportSeries(userName, seriesInstanceUIDs, options);
            return zip;
         });
      }

      public Task<Stream> ExportInstances(string authenticationCookie, string[] instanceUIDs, ExportOptions options)
      {
         return Task.Factory.StartNew<Stream>(() =>
         {
            var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
            var zip = _exportAddin.ExportInstances(userName, instanceUIDs, options);
            return zip;
         });
      }

      public Task<Stream> ExportLayout(string authenticationCookie, string seriesInstanceUID, Layout layout, bool burnAnnotations, CompressionType compression, int width)
      {
         return Task.Factory.StartNew<Stream>(() =>
         {
            var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
            var image = _exportAddin.ExportLayout(userName, seriesInstanceUID, layout, burnAnnotations, compression, width);
            return image;
         });
      }

      public Task<Stream> PrintAllSeries(string authenticationCookie, string patientID, PrintOptions options)
      {
         return Task.Factory.StartNew<Stream>(() =>
         {
            try
            {
               string annotationData = string.Empty;
               if (options.BurnAnnotations)
                  annotationData = LoadAnnotations(options.AnnotationsFileName);

               var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
               var pdf = _exportAddin.PrintAllSeries(userName, patientID, options, annotationData);
               return pdf;
            }
            catch
            {
               return null;
            }
         });
      }

      public Task<Stream> PrintSeries(string authenticationCookie, string[] seriesInstanceUIDs, PrintOptions options)
      {
         return Task.Factory.StartNew<Stream>(() =>
         {
            try
            {
               string annotationData = string.Empty;

               if (options.BurnAnnotations)
                  annotationData = LoadAnnotations(options.AnnotationsFileName);

               var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
               var pdf = _exportAddin.PrintSeries(userName, seriesInstanceUIDs, options, annotationData);
               return pdf;
            }
            catch
            {
               return null;
            }
         });
      }

      public Task<Stream> PrintInstances(string authenticationCookie, string[] instanceUIDs, PrintOptions options)
      {
         return Task.Factory.StartNew<Stream>(() =>
         {
            try
            {
               string annotationData = string.Empty;

               if (options.BurnAnnotations)
                  annotationData = LoadAnnotations(options.AnnotationsFileName);

               var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
               var pdf = _exportAddin.PrintInstances(userName, instanceUIDs, options, annotationData);
               return pdf;
            }
            catch
            {
               return null;
            }
         });
      }

      public Task<Stream> PrintLayout(string authenticationCookie, string seriesInstanceUID, Layout layout, PrintOptions options)
      {
         return Task.Factory.StartNew<Stream>(() =>
         {
            try
            {
               string annotationData = string.Empty;

               if (options.BurnAnnotations)
                  annotationData = LoadAnnotations(options.AnnotationsFileName);

               var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
               var pdf = _exportAddin.PrintLayout(userName, seriesInstanceUID, layout, options, annotationData);
               return pdf;
            }
            catch
            {
               return null;
            }
         });
      }

      private string LoadAnnotations(string annotationFileName)
      {
         string dir = Path.GetTempPath();
         string filePath = null;
         string annotationData = null;
         string outDir;

         if (null == dir)
            dir = string.Empty;
         outDir = Path.Combine(dir, "Temp");

         if (!String.IsNullOrEmpty(annotationFileName))
         {
            filePath = Path.Combine(outDir, annotationFileName);
         }

         if (filePath != null && File.Exists(filePath))
         {
            XmlDocument doc = new XmlDocument();

            doc.Load(filePath);
            annotationData = doc.InnerXml;

            File.Delete(filePath);
         }
         return annotationData;
      }
      
      #endregion      
   }
}
