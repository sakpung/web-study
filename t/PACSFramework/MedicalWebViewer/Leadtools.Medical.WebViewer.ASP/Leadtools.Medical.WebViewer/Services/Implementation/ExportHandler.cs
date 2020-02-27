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
using System.Linq;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   public class ExportHandler : IExportHandler
   {
      IExportAddin _exportAddin;
      IHashingProvider _hasing;
      
      public ExportHandler(AddinsFactory factory, IHashingProvider hasing)
      {
         _exportAddin = factory.CreateExportAddin();
         _hasing = hasing;
      }

      #region IExportHandler Members

      public Task<string> ExportAllSeries(string authenticationCookie, string patientID, ExportOptions options)
      {
         return Task.Factory.StartNew(() =>
         {
            var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
            var zip = _exportAddin.ExportAllSeries(userName, patientID, options);
            return Save(authenticationCookie, patientID+"_", ".zip", zip);
         });
      }

      public Task<string> ExportSeries(string authenticationCookie, string[] seriesInstanceUIDs, ExportOptions options)
      {
         return Task.Factory.StartNew(() =>
         {
            var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
            var zip = _exportAddin.ExportSeries(userName, seriesInstanceUIDs, options);
            return Save(authenticationCookie, "Series_", ".zip", zip);
         });
      }

      public Task<string> ExportInstances(string authenticationCookie, string[] instanceUIDs, ExportOptions options)
      {
         return Task.Factory.StartNew(() =>
         {
            var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
            var zip = _exportAddin.ExportInstances(userName, instanceUIDs, options);
            return Save(authenticationCookie, "Instances_", ".zip", zip);
         });
      }

      public Task<string> ExportLayout(string authenticationCookie, string seriesInstanceUID, Layout layout, bool burnAnnotations, CompressionType compression, int width)
      {
         return Task.Factory.StartNew(() =>
         {
            var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
            var image = _exportAddin.ExportLayout(userName, seriesInstanceUID, layout, burnAnnotations, compression, width);
            return Save(authenticationCookie, "Layout_", ".jpg", image);
         });
      }

      public Task<string> PrintAllSeries(string authenticationCookie, string patientID, PrintOptions options)
      {
         return Task.Factory.StartNew(() =>
         {
            try
            {
               string annotationData = string.Empty;
               if (options.BurnAnnotations)
                  annotationData = LoadAnnotations(options.AnnotationsFileName);

               var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
               var pdf = _exportAddin.PrintAllSeries(userName, patientID, options, annotationData);
               string url = Save(authenticationCookie, patientID+"_", ".pdf", pdf);
               pdf.Dispose();
               return url;
            }
            catch
            {
               return string.Empty;
            }
         });
      }

      public Task<string>  PrintSeries(string authenticationCookie, string[] seriesInstanceUIDs, PrintOptions options)
      {
         return Task.Factory.StartNew(() =>
         {
            try
            {
               string annotationData = string.Empty;
               if (options.BurnAnnotations)
                  annotationData = LoadAnnotations(options.AnnotationsFileName);

               var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
               var pdf = _exportAddin.PrintSeries(userName, seriesInstanceUIDs, options, annotationData);
               string url = Save(authenticationCookie, "Series_", ".pdf", pdf);
               pdf.Dispose();
               return url;
            }
            catch
            {
               return string.Empty;
            }
         });
      }

      public Task<string>  PrintInstances(string authenticationCookie, string[] instanceUIDs, PrintOptions options)
      {
         return Task.Factory.StartNew(() =>
         {
            try
            {
               string annotationData = string.Empty;
               if (options.BurnAnnotations)
                  annotationData = LoadAnnotations(options.AnnotationsFileName);

               var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
               var pdf = _exportAddin.PrintInstances(userName, instanceUIDs, options, annotationData);
               string url = Save(authenticationCookie, "Instances_", ".pdf", pdf);
               pdf.Dispose();
               return url;
            }
            catch
            {
               return string.Empty;
            }
         });
      }

      public Task<string>  PrintLayout(string authenticationCookie, string seriesInstanceUID, Layout layout, PrintOptions options)
      {
         return Task.Factory.StartNew(() =>
         {
            try
            {
               string annotationData = string.Empty;
               if (options.BurnAnnotations)
                  annotationData = LoadAnnotations(options.AnnotationsFileName);

               var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
               var pdf = _exportAddin.PrintLayout(userName, seriesInstanceUID, layout, options, annotationData);
               string url = Save(authenticationCookie, "Layout_", ".pdf", pdf);
               pdf.Dispose();
               return url;
            }
            catch
            {
               return string.Empty;
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

      public Task<string>  GetInstanceLocalPathName(string authenticationCookie, string instanceUID)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
         string pathName = _exportAddin.GetInstanceLocalPathName(userName, instanceUID);
         return Task.FromResult<string>(pathName);
      }

      #endregion

      private void CheckPath(string path)
      {
         if (!Directory.Exists(path))
         {
            Directory.CreateDirectory(path);
         }
      }

      static string PathSafe(string path)
      {
          return Path.GetInvalidFileNameChars().Aggregate(path, (current, c) => current.Replace(c.ToString(), string.Empty));
      }

      public string MapPath(string authenticationCookie, string url)
      {
         string path = Path.Combine(HostingEnvironment.MapPath("~/Files"), PathSafe(authenticationCookie));
         string physicalFileName = _hasing.GetHashString(url + authenticationCookie);
         string filePath = Path.Combine(path, physicalFileName);
         return filePath ;
      }

      private string Save(string authenticationCookie, string hint, string ext, Stream stream)
      {
         string logicalFileName = hint + CoreUtils.RandomString(5) + ext;
         string path = Path.Combine(HostingEnvironment.MapPath("~/Files"), PathSafe(authenticationCookie));
         string physicalFileName = _hasing.GetHashString(logicalFileName + authenticationCookie);
         string filePath = Path.Combine(path, physicalFileName);

         CheckPath(path);

         using (Stream file = File.OpenWrite(filePath))
         {
            CoreUtils.CopyStream(stream, file);
         }

         return logicalFileName;
      }      
   }
}
