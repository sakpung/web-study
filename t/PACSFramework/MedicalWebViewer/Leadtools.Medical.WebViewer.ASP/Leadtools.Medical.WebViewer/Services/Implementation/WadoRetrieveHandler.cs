// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.Addins;
using System.Configuration;
using System.Net;
using System.IO.Compression;
using Leadtools.Medical.WebViewer.Core.DataTypes;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Common;
using Leadtools.Medical.WebViewer.Wado;
using System.Threading.Tasks;
using Leadtools.Medical.WebViewerModels;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   /// <summary>
   /// Retrieves objects from wado server
   /// </summary>

   public class WadoRetrieveHandler : IRetrieveHandler
   {
      private Lazy<IRemoteRetrieveAddin> _retrieve;
      private Lazy<IRemoteQueryAddin> _query;
      private Lazy<IStoreAddin> _store;

      public WadoRetrieveHandler(AddinsFactory factory)
      {
         _retrieve = new Lazy<IRemoteRetrieveAddin>(() => factory.CreateWadoRetrieveAddin());
         _query = new Lazy<IRemoteQueryAddin>(() => factory.CreateWadoQueryAddin());
         _store = new Lazy<IStoreAddin>(() => factory.CreateStoreAddin());
      }
      
      public Stream GetImage(string authenticationCookie, string sopInstanceUID, int frame, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height, string userData)
      {
         return null;
      }

      public Stream DownloadImage(string authenticationCookie, string sopInstanceUID, int frame, int bitsPerPixel, int qualityFactor, int width, int height, string annotationFileName, double xDpi, double yDpi, string userData)
      {
         return null;
      }

      private string LoadAnnotationData(string annotationFileName)
      {
         return null;
      }

      public string UploadAnnotations(string authenticationCookie, string data)
      {
         return "";
      }


      /// <summary>
      /// Gets the raw DICOM object for an object
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="uid">UIDs. Only SOPInstanceUID is used</param>
      /// <param name="options">Query options</param>
      /// <returns>The DICOM as stream</returns>
      /// <remarks>
      /// <para>RoleName:CanRetrieve</para>
      /// </remarks>
      public Stream GetDicom(string authenticationCookie, ObjectUID uid, GetDicomOptions options)
      {
         return null;
      }

      class DataInfo
      {
         public Stream Stream { get; set; }
         public string StatusDescription { get; set; }
         public HttpStatusCode StatusCode { get; set; }
      }

      public Task<Tuple<Stream, string>> GetImageTile(string authenticationCookie, string sopInstanceUID, int frame, int x, int y, int width, int height, int xResolution, int yResolution, Boolean wldata, string userData)
      {
         return null;
      }

      public Task<string> GetDicomJSON(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string sopInstanceUID, string userData)
      {
         return null;
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

      public XmlElement GetPresentationAnnotations(string authenticationCookie, string sopInstanceUID, string userData)
      {
         return null;
      }

      public Layout GetSeriesLayout(string authenticationCookie, string seriesInstanceUID, string userData)
      {
         return null;
      }

      public List<StudyLayout> GetPatientStructuredDisplay(string authenticationCookie, string patientID, string userData)
        {
            return null;
        }


      public StudyLayout GetStudyLayout(string authenticationCookie, string studyInstanceUID, string userData)
      {
         return null;
      }
      
      public async Task<Stream> GetSeriesThumbnail(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height)
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

         var retrieve_query = new QueryOptions();
         retrieve_query.StudiesOptions = new StudiesQueryOptions();
         retrieve_query.StudiesOptions.StudyInstanceUID = studyInstanceUID;

         retrieve_query.SeriesOptions = new SeriesQueryOptions();
         retrieve_query.SeriesOptions.SeriesInstanceUID = seriesInstanceUID;

         var config = RemoteConnectionFactory.Config(new WadoConnection() { dicomWebRoot = @"http://localhost/WadoService/api/", rs = "wado-rs" });
         return await _retrieve.Value.RetrieveDatasetRendered(config, retrieve_query, new System.Drawing.Size(width, height));
         //can be supported: mimeType, bitsPerPixel, qualityFactor
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
         return null;
      }

      public int GetAudioGroupsCount(string authenticationCookie, string sopInstanceUID)
      {
         return 0;
      }

      public List<StackItem> GetSeriesStacks(string authenticationCookie, string seriesInstanceUID, string userData)
      {
         return null;
      }
      
      public WCFHangingProtocol GetHangingProtocol(string authenticationCookie, string sopInstanceUID, string userData)
      {
         return null;
      }

      public List<DisplaySetView> GetHangingProtocolInstances(string authenticationCookie, string hangingProtocolSOP, string patientID, string studyInstanceUID, string studyDateMostRecent, string userData)
      {
         return null;
      }
      public void ClearCache(string authenticationCookie)
      {
      }

      public string GetPresentationAnnotationsString(string authenticationCookie, string sopInstanceUID, string userData)
      {
         return null;
      }
   }
}
