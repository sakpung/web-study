// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Leadtools.Medical.WebViewer.Addins;
using Leadtools.Medical.WebViewer.Common;
using Leadtools.Medical.WebViewer.Core.DataTypes;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Services.Interfaces;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   /// <summary>
   /// Retrieves objects from local PACS
   /// </summary>
   
   public class RetrieveHandler : IRetrieveHandler
   {
      private Lazy<IObjectRetrieveAddin> _ret;
      private Lazy<IQueryAddin> _query;
      private Lazy<IStoreAddin> _store;
      private Lazy<Dicom.Imaging.DiskDataCacheStorage> _storage;
      public RetrieveHandler(AddinsFactory factory)
      {
         _ret = new Lazy<IObjectRetrieveAddin>(()=>{ return factory.CreateRetrieveAddin(); });
         _query = new Lazy<IQueryAddin>(()=>{ return factory.CreateQueryAddin(); });
         _store = new Lazy<IStoreAddin>(()=>{ return factory.CreateStoreAddin(); });
         _storage = new Lazy<Dicom.Imaging.DiskDataCacheStorage>(()=>{ return factory.CreateCacheDiskStorage(); });
      }
      
      public Stream GetImage(string authenticationCookie, string sopInstanceUID, int frame, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height, string userData)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         if (frame <= 0)
         {
            frame = 1;
         }

         if (string.IsNullOrEmpty(mimeType))
         {
            mimeType = SupportedMimeTypes.JPG;
         }

         if (mimeType.ToLower() == SupportedMimeTypes.JPG.ToLower())
         {
            if (qualityFactor < 2)
            {
               qualityFactor = 2;
            }
         }

         return _ret.Value.GetImage(sopInstanceUID, frame, mimeType, bitsPerPixel, qualityFactor, width, height, userData);
      }

      public Stream DownloadImage(string authenticationCookie, string sopInstanceUID, int frame, int bitsPerPixel, int qualityFactor, int width, int height, string annotationFileName, double xDpi, double yDpi, string userData)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         if (frame <= 0)
         {
            frame = 1;
         }

         if (qualityFactor < 2)
         {
            qualityFactor = 2;
         }

         // string dir = HostingEnvironment.ApplicationPhysicalPath;
         string dir = Path.GetTempPath();
         if (null == dir)
            dir = string.Empty;
         string outDir = Path.Combine(dir, "Temp");
         string filePath = null;
         string annotationData = null;

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

         if (width == 0 && height == 0)
         {
            var captureSize = ConfigurationManager.AppSettings.Get("MaxCaptureSize");
            if (!string.IsNullOrEmpty(captureSize))
            {
               int.TryParse(captureSize, out width);
               int.TryParse(captureSize, out height);
            }
         }

         Stream stream = _ret.Value.DownloadImage(sopInstanceUID, frame, SupportedMimeTypes.JPG, bitsPerPixel, qualityFactor, width, height, annotationData, xDpi, yDpi, userData);

         return stream;
      }

      private string LoadAnnotationData(string annotationFileName)
      {
         // string dir = HostingEnvironment.ApplicationPhysicalPath;
         string dir = Path.GetTempPath();
         if (null == dir)
            dir = string.Empty;
         string outDir = Path.Combine(dir, "Temp");
         string filePath = null;
         string annotationData = null;

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

      public string UploadAnnotations(string authenticationCookie, string data)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         if (data == null)
            return null;

         // Check if the temp folder exists
         // string dir = HostingEnvironment.ApplicationPhysicalPath;
         string dir = Path.GetTempPath();
         if (null == dir)
            dir = string.Empty;
         string outDir = Path.Combine(dir, "Temp");
         if (!Directory.Exists(outDir))
            Directory.CreateDirectory(outDir);

         // Check if we have old files in the directory, delete them
         DateTime now = DateTime.Now;
         string[] files = Directory.GetFiles(outDir, "*.xml");
         foreach (string file in files)
         {
            DateTime fileTime = File.GetCreationTime(file);
            if (fileTime > now.AddHours(24))
            {
               // Delete it
               try
               {
                  File.Delete(file);
               }
               catch { }
            }
         }

         // Create the new file
         string fileName = Guid.NewGuid().ToString().Replace("-", "") + ".xml";
         string filePath = Path.Combine(outDir, fileName);
         File.WriteAllText(filePath, data);
        
         return fileName;
      }

      public Stream GetDicom(string authenticationCookie, ObjectUID uid, GetDicomOptions options)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         return _ret.Value.GetDicom(uid, options);
      }

      class DataInfo
      {
         public Stream Stream { get; set; }
         public string StatusDescription { get; set; }
         public HttpStatusCode StatusCode { get; set; }
      }

      public Task<Tuple<Stream, string>> GetImageTile(string authenticationCookie, string sopInstanceUID, int frame, int x, int y, int width, int height, int xResolution, int yResolution, Boolean wldata, string userData)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);
                  
         return Task.Factory.StartNew<Tuple<Stream, string>>(() =>
         {
            LeadRect tile = LeadRect.Create(x, y, width, height);
            string mime;
            var stream = _ret.Value.GetImageTile(sopInstanceUID, frame, tile, xResolution, yResolution, wldata, userData, out mime);

            return new Tuple<Stream, string>(stream, mime);
         });
      }

      public Task<string> GetDicomJSON(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string sopInstanceUID, string userData)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         var uid = new ObjectUID();
         uid.StudyInstanceUID = studyInstanceUID;
         uid.SeriesInstanceUID = seriesInstanceUID;

         if (string.IsNullOrEmpty(sopInstanceUID))
         {
            var options = new QueryOptions();
            options.StudiesOptions = new StudiesQueryOptions();
            options.StudiesOptions.StudyInstanceUID = studyInstanceUID;
            options.SeriesOptions = new SeriesQueryOptions();
            options.SeriesOptions.SeriesInstanceUID = seriesInstanceUID;
            var objectsFound = _query.Value.FindInstances(authenticationCookie, options, 1, true);
            if (objectsFound.Length > 0)
            {
               var objects = objectsFound.Where(o => o != null).ToArray();
               if (objects.Length > 0)
               {
                  sopInstanceUID = objects[0].SOPInstanceUID;
               }
            }
         }

         uid.SOPInstanceUID = sopInstanceUID;

         return Task.Factory.StartNew<string>(() => _ret.Value.GetDicomJSON(uid));
      }

      private static MemoryStream Decompress(Stream outStream)
      {
         MemoryStream unComp = new MemoryStream();
         outStream.Position = 0;
         byte[] buffer = new byte[1024 * 1000];
         int bytesRead;

         using (GZipStream decompressed = new GZipStream(outStream, CompressionMode.Decompress))
         {
            while ((bytesRead = decompressed.Read(buffer, 0, buffer.Length)) > 0)
            {
               unComp.Write(buffer, 0, bytesRead);
            }
         }
         unComp.Position = 0;
         return unComp;
      }

      private static MemoryStream CompressGZip(Stream outStream)
      {
         byte[] buffer = new byte[1024 * 1000];
         int bytesRead;
         string tempFile = Path.GetTempFileName();

         try
         {
            using (FileStream compressed = new FileStream(tempFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
               using (GZipStream compressedStream = new GZipStream(compressed, CompressionMode.Compress))
               {
                  while ((bytesRead = outStream.Read(buffer, 0, buffer.Length)) > 0)
                  {
                     compressedStream.Write(buffer, 0, bytesRead);
                  }

                  compressedStream.Flush();
               }
            }

            return new MemoryStream(File.ReadAllBytes(tempFile));
         }
         finally
         {
            File.Delete(tempFile);
         }
      }

      private static MemoryStream CompressDeflate(Stream outStream)
      {
         byte[] buffer = new byte[1024 * 1000];
         int bytesRead;
         string tempFile = Path.GetTempFileName();

         try
         {
            using (FileStream compressed = new FileStream(tempFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
               using (DeflateStream compressedStream = new DeflateStream(compressed, CompressionMode.Compress))
               {
                  while ((bytesRead = outStream.Read(buffer, 0, buffer.Length)) > 0)
                  {
                     compressedStream.Write(buffer, 0, bytesRead);
                  }

                  compressedStream.Flush();
               }
            }

            return new MemoryStream(File.ReadAllBytes(tempFile));
         }
         finally
         {
            File.Delete(tempFile);
         }
      }

      private Stream GetPresentationAnnotationsStream(string authenticationCookie, string sopInstanceUID, string userData)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         Stream annStream = _ret.Value.GetPresentationAnnotations(sopInstanceUID, userData);

         return annStream;
      }
      public string GetPresentationAnnotationsString(string authenticationCookie, string sopInstanceUID, string userData)
      {
         var annStream = GetPresentationAnnotationsStream(authenticationCookie, sopInstanceUID, userData);

         if (null == annStream)
         {
            return null;
         }

         using (var reader = new StreamReader(annStream))
         {
            return reader.ReadToEnd();
         }
      }

      public XmlElement GetPresentationAnnotations(string authenticationCookie, string sopInstanceUID, string userData)
      {
         var annStream = GetPresentationAnnotationsStream(authenticationCookie, sopInstanceUID, userData);

         if (null == annStream)
         {
            return null;
         }

         annStream.Position = 0;
         XmlDocument document = new XmlDocument();
         document.Load(annStream);
         return document.DocumentElement;
      }

      public Layout GetSeriesLayout(string authenticationCookie, string seriesInstanceUID, string userData)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         return _ret.Value.GetSeriesLayout(userName, seriesInstanceUID, _store, userData);
      }
        public List<StudyLayout> GetPatientStructuredDisplay(string authenticationCookie, string patientID, string userData)
        {
            var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            return _ret.Value.GetPatientStructuredDisplay(userName, patientID, userData);
        }

        public StudyLayout GetStudyLayout(string authenticationCookie, string studyInstanceUID, string userData)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         return _ret.Value.GetStudyLayout(userName, studyInstanceUID, userData);
      }

      public Task<Stream> GetSeriesThumbnail(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         if (string.IsNullOrEmpty(mimeType))
         {
            mimeType = SupportedMimeTypes.JPG;

            if (qualityFactor < 2)
            {
               qualityFactor = 2;
            }
         }

         return Task.Factory.StartNew<Stream>(() => _ret.Value.GetSeriesThumbnail(userName, seriesInstanceUID, mimeType, bitsPerPixel, qualityFactor, width, height));
      }

      private void CopyData(Stream output, Stream input)
      {
         byte[] imageData = new byte[(int)input.Length];

         input.Position = 0;

         input.Read(imageData, 0, imageData.Length);


         int iteration = imageData.Length / 1000;
         int index = 0;


         while ((index + iteration) < input.Length)
         {
            output.Write(imageData, index, iteration);
            index += iteration;
         }

         output.Write(imageData, index, imageData.Length - index);
         output.Flush();
      }

      public Stream GetAudio(string authenticationCookie, string sopInstanceUID, int groupIndex, string mimeType)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);
         return _ret.Value.GetAudio(sopInstanceUID, groupIndex, mimeType);
      }

      public int GetAudioGroupsCount(string authenticationCookie, string sopInstanceUID)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         try
         {
            return _ret.Value.GetAudioGroupsCount(sopInstanceUID);
         }
         catch
         {
            return 0;
         }
      }


      public List<StackItem> GetSeriesStacks(string authenticationCookie, string seriesInstanceUID, string userData)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         return _ret.Value.GetSeriesStacks(seriesInstanceUID);
      }


      public WCFHangingProtocol GetHangingProtocol(string authenticationCookie, string sopInstanceUID, string userData)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         return _ret.Value.GetHangingProtocol(userName, sopInstanceUID, userData);
      }

      public List<DisplaySetView> GetHangingProtocolInstances(string authenticationCookie, string hangingProtocolSOP, string patientID, string studyInstanceUID, string studyDateMostRecent, string userData)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         return _ret.Value.GetHangingProtocolInstances(userName, hangingProtocolSOP, patientID, studyInstanceUID, studyDateMostRecent, userData);
      }
      public void ClearCache(string authenticationCookie)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDeleteCache);
         try
         {
            TimeStampProvider.RefreshTimeStamp();

            if (null != _storage)
            {
               _storage.Value.RunCleanup(null);
            }
         }
         catch { }
      }      
   }
}
