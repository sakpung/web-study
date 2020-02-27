// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;
using Leadtools.Medical.WebViewer.ServiceContracts;
using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.Wcf.Helper;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Net;
using System.Web.Services;
using System.Web.Hosting;
using Leadtools.Medical.WebViewer.Core.DataTypes.Common;
using System.Diagnostics;
using System.Xml;

namespace Leadtools.Medical.WebViewer.Wcf
{
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   [WebService(Namespace = "http://leadtools.com/")]
   public class ExportService : IExportService
   {
      IExportAddin _exportAddin;

      private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
      private static readonly Random _Random = new Random();

      public ExportService()
      {
         try
         {
            _exportAddin = AddinsFactory.CreateExportAddin();
         }
         catch (Exception ex)
         {
            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
            WebOperationContext.Current.OutgoingResponse.StatusDescription = ex.Message;
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";

            throw;
         }
      }

      #region IExportService Members

      public string ExportAllSeries(string authenticationCookie, string patientID, ExportOptions options)
      {
         Stream zip;

         var userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
         zip = _exportAddin.ExportAllSeries(userName, patientID, options);
         return SaveZip(patientID, zip);
      }

      public string ExportSeries(string authenticationCookie, string[] seriesInstanceUIDs, ExportOptions options)
      {
         Stream zip;

         var userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
         zip = _exportAddin.ExportSeries(userName, seriesInstanceUIDs, options);

         return SaveZip("Series", zip);
      }

      public string ExportInstances(string authenticationCookie, string[] instanceUIDs, ExportOptions options)
      {
         Stream zip;

         var userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);

         zip = _exportAddin.ExportInstances(userName, instanceUIDs, options);
         return SaveZip("Instances", zip);
      }

      public string ExportLayout(string authenticationCookie, string seriesInstanceUID, Layout layout, bool burnAnnotations, CompressionType compression, int width)
      {
         Stream image = null;

         var userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
         image = _exportAddin.ExportLayout(userName, seriesInstanceUID, layout, burnAnnotations, compression, width);
         return SaveStream(image);
      }

      public string PrintAllSeries(string authenticationCookie, string patientID, PrintOptions options)
      {
         try
         {
            Stream pdf;
            string annotationData = string.Empty;

            if (options.BurnAnnotations)
               annotationData = LoadAnnotations(options.AnnotationsFileName);
            
            var userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
            pdf = _exportAddin.PrintAllSeries(userName, patientID, options, annotationData);
            string url = SavePdf(patientID, pdf);
            pdf.Dispose();
            return url;
         }
         catch
         {
            return string.Empty;
         }
      }

      public string PrintSeries(string authenticationCookie, string[] seriesInstanceUIDs, PrintOptions options)
      {
         try
         {
            Stream pdf;
            string annotationData = string.Empty;

            if (options.BurnAnnotations)
               annotationData = LoadAnnotations(options.AnnotationsFileName);

            var userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
            pdf = _exportAddin.PrintSeries(userName, seriesInstanceUIDs, options, annotationData);
            string url = SavePdf("Series", pdf);
            pdf.Dispose();
            return url;
         }
         catch
         {
            return string.Empty;
         }
      }

      public string PrintInstances(string authenticationCookie, string[] instanceUIDs, PrintOptions options)
      {
         try
         {
            Stream pdf;
            string annotationData = string.Empty;

            if (options.BurnAnnotations)
               annotationData = LoadAnnotations(options.AnnotationsFileName);


            var userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
            pdf = _exportAddin.PrintInstances(userName, instanceUIDs, options, annotationData);
            string url = SavePdf("Instances", pdf);
            pdf.Dispose();
            return url;
         }
         catch
         {
            return string.Empty;
         }
      }

      public string PrintLayout(string authenticationCookie, string seriesInstanceUID, Layout layout, PrintOptions options)
      {
         try
         {
            Stream pdf = null;
            string annotationData = string.Empty;

            if (options.BurnAnnotations)
               annotationData = LoadAnnotations(options.AnnotationsFileName);


            var userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
            pdf = _exportAddin.PrintLayout(userName, seriesInstanceUID, layout, options, annotationData);
            string url = SavePdf("Layout", pdf);
            pdf.Dispose();
            return url;
         }
         catch
         {
            return string.Empty;
         }
      }

      private string LoadAnnotations(string annotationFileName)
      {
         // string dir = HostingEnvironment.ApplicationPhysicalPath;
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

      public string GetInstanceLocalPathName(string authenticationCookie, string instanceUID)
      {
         var userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanExport);
         string pathName = _exportAddin.GetInstanceLocalPathName(userName, instanceUID);
         return pathName;
      }

      #endregion

      private void CheckPath(string path)
      {
         if (!Directory.Exists(path))
         {
            Directory.CreateDirectory(path);
         }
      }

      private string SavePdf(string patientID, Stream stream)
      {
         string path = HostingEnvironment.MapPath("~/Files") + "/";
         string fileName = patientID + "_" + CoreUtils.RandomString(5) + ".pdf";
         string filePath = Path.Combine(path, fileName);

         CheckPath(path);
         using (Stream file = File.OpenWrite(filePath))
         {
            CoreUtils.CopyStream(stream, file);
         }

         return MapURL(fileName);
      }

      private string SaveZip(string patientID, Stream stream)
      {
         string path = HostingEnvironment.MapPath("~/Files") + "/";
         string fileName = patientID + "_" + CoreUtils.RandomString(5) + ".zip";
         string filePath = Path.Combine(path, fileName);

         CheckPath(path);
         using (Stream file = File.OpenWrite(filePath))
         {
            CoreUtils.CopyStream(stream, file);
         }

         return MapURL(fileName);
      }

      private string SaveStream(Stream stream)
      {
         string path = HostingEnvironment.MapPath("~/Files") + "/";
         string fileName = CoreUtils.RandomString(5) + ".jpg";
         string filePath = Path.Combine(path, fileName);

         using (Stream file = File.OpenWrite(filePath))
         {
            CoreUtils.CopyStream(stream, file);
         }

         return MapURL(fileName);
      }

      private string MapURL(string Path)
      {
         string url = "/Files/" + Path;

         return url;
      }
   }
}
