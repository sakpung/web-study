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
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

using Leadtools.Medical.WebViewer.Addins;
using Leadtools.Medical.WebViewer.Core.DataTypes;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Wcf.Helper;

namespace Leadtools.Medical.WebViewer.Wcf
{
   /// <summary>
   /// Retrieves objects from local PACS
   /// </summary>
   /// <remarks>
   /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
   /// can perform the operation
   /// </remarks>
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ObjectRetrieveService : IObjectRetrieveService
    {
        public ObjectRetrieveService()
        {
        }

        /// <summary>
        /// Gets a single image
        /// </summary>
        /// <param name="authenticationCookie"></param>
        /// <param name="sopInstanceUID"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        public Stream GetImage(string authenticationCookie, string sopInstanceUID, int frame, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height, string userData)
        {
            ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

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

            WebOperationContext.Current.OutgoingResponse.ContentType = mimeType;

            return AddinsFactory.CreateObjectRetrieveAddin().GetImage(sopInstanceUID, frame, mimeType, bitsPerPixel, qualityFactor, width, height, userData);
        }

        public Stream DownloadImage(string authenticationCookie, string sopInstanceUID, int frame, int bitsPerPixel, int qualityFactor, int width, int height, string annotationFileName, double xDpi, double yDpi, string userData)
        {
           ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

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

            if (null != WebOperationContext.Current)
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = SupportedMimeTypes.JPG;
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Disposition", string.Format("attachment; filename={0}.jpg", sopInstanceUID.ToString()));
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

            Stream stream = AddinsFactory.CreateObjectRetrieveAddin().DownloadImage(sopInstanceUID, frame, SupportedMimeTypes.JPG, bitsPerPixel, qualityFactor, width, height, annotationData, xDpi, yDpi, userData);

            if (null != WebOperationContext.Current)
            {
                WebOperationContext.Current.OutgoingResponse.ContentLength = stream.Length;
            }

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

        public string UploadAnnotations(string authenticationCookie, XmlElement data)
        {
           ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

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

            // Save the data
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;
            settings.Encoding = Encoding.UTF8;

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                writer.WriteStartDocument();
                data.WriteTo(writer);
                writer.WriteEndDocument();
            }

            return fileName;
        }


        /// <summary>
        /// Gets the raw DICOM object for an object
        /// </summary>
        /// <param name="authenticationCookie">Cookie</param>
        /// <param name="uid">UIDs. Only SOPInstanceUID is used</param>
        /// <param name="options">Query options</param>
        /// <param name="extraOptions">Extra options</param>
        /// <returns>The DICOM as stream</returns>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        public Stream GetDicom(string authenticationCookie, ObjectUID uid, GetDicomOptions options, ExtraOptions extraOptions)
        {
           ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            return AddinsFactory.CreateObjectRetrieveAddin().GetDicom(uid, options);
        }

        class DataInfo
        {
            public Stream Stream { get; set; }
            public string StatusDescription { get; set; }
            public HttpStatusCode StatusCode { get; set; }
        }

        private DataInfo GetImageData(string studyInstanceUID, string seriesInstanceUID, string sopInstanceUID, int frame, string userData)
        {
            //must get the encoding accepted by the browser before encoding it. if browser doesn't support some encoding then do not encode
            string acceptEncoding = "Accept-Encoding";
            string encoding = WebOperationContext.Current.IncomingRequest.Headers[acceptEncoding];
            bool deflate = (encoding != null) && (encoding.Contains("deflate"));
            bool gzip = (encoding != null) && (encoding.Contains("gzip"));
            DataInfo dataInfo = new DataInfo();
            Stream result = null;

            dataInfo.StatusCode = HttpStatusCode.OK;
            dataInfo.StatusDescription = "";

            if (string.IsNullOrEmpty(sopInstanceUID))
            {
                dataInfo.StatusCode = System.Net.HttpStatusCode.BadRequest;
                dataInfo.StatusDescription = "Invalid SOPInstanceUID";
            }

            if (frame <= 0)
            {
                frame = 1;
            }

            if (dataInfo.StatusCode == HttpStatusCode.OK)
            {
                ObjectUID uid = new ObjectUID();

                uid.StudyInstanceUID = studyInstanceUID;
                uid.SeriesInstanceUID = seriesInstanceUID;
                uid.SOPInstanceUID = sopInstanceUID;

                //returns the raw image data as binary (no compression, no base 64)
                byte[] data = AddinsFactory.CreateObjectRetrieveAddin().GetBinaryDicomImageData(uid, frame);

                if (null != data)
                {
                    result = new MemoryStream(data);
                }

                if (null != result && result.Length > 0)
                {
                    Stream outStream;

                    //check if can do deflate compression first
                    if (deflate)
                    {
                        outStream = CompressDeflate(result);

                        WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Encoding", "deflate");
                    }
                    //then check the gzip compression
                    else if (gzip)
                    {
                        outStream = CompressGZip(result);

                        WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Encoding", "gzip");
                    }
                    //if neither is supported then don't compress
                    else
                    {
                        outStream = result;
                    }

                    //add the right content type so the browser won't try to mess with the data
                    WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain; charset=x-user-defined";

                    dataInfo.Stream = outStream;
                    return dataInfo;
                }
                else
                {
                    dataInfo.StatusCode = System.Net.HttpStatusCode.NotFound;
                    dataInfo.StatusDescription = "No data was found";

                    result = null;
                }
            }
            dataInfo.Stream = result;
            return dataInfo;
        }
      
        /// <summary>
        /// this is the main function in the class. It returns the DICOM image data wrapped inside a PNG image
        /// </summary>
        /// <param name="authenticationCookie"></param>
        /// <param name="studyInstanceUID"></param>
        /// <param name="seriesInstanceUID"></param>
        /// <param name="sopInstanceUID"></param>
        /// <param name="frame"></param>
        /// <param name="userData"></param>
        /// <returns></returns>
        public Stream GetDicomImageDataAsPNG(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string sopInstanceUID, int frame, string userData)
        {
           ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            //must get the encoding accepted by the browser before encoding it. if browser doesn't support some encoding then do not encode
            string acceptEncoding = "Accept-Encoding";
            string encoding = WebOperationContext.Current.IncomingRequest.Headers[acceptEncoding];


            HttpStatusCode statusCode = HttpStatusCode.OK;
            string statusDescription = "";
            Stream outStream = null;
            Exception error = null;
            try
            {
                if (string.IsNullOrEmpty(sopInstanceUID))
                {
                    statusCode = System.Net.HttpStatusCode.BadRequest;
                    statusDescription = "Invalid SOPInstanceUID";
                }

                if (frame <= 0)
                {
                    frame = 1;
                }

                if (statusCode == HttpStatusCode.OK)
                {
                    ObjectUID uid = new ObjectUID();
                    uid.StudyInstanceUID = studyInstanceUID;
                    uid.SeriesInstanceUID = seriesInstanceUID;
                    uid.SOPInstanceUID = sopInstanceUID;

                    //returns the raw image data as PNG
                    byte[] data = AddinsFactory.CreateObjectRetrieveAddin().GetBinaryDicomImageDataAsPNG(uid, frame);

                    if (null != data)
                    {
                        outStream = new MemoryStream(data);
                    }

                    if (null != outStream && outStream.Length > 0)
                    {
                        //add the right content type so the browser won't try to mess with the data
                        WebOperationContext.Current.OutgoingResponse.ContentType = "image/png";
                    }
                    else
                    {
                        statusCode = System.Net.HttpStatusCode.NotFound;
                        statusDescription = "No data was found";

                        outStream = null;
                    }
                }

                return outStream;
            }
            catch (Exception ex)
            {
                statusCode = System.Net.HttpStatusCode.InternalServerError;
                statusDescription = ex.Message;
                error = ex;
                return null;
            }
            finally
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = statusCode;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = statusDescription;

                if (error != null || statusCode != HttpStatusCode.OK)
                {
                    WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";


                    if (error == null)
                    {
                        throw new ApplicationException(statusDescription);
                    }
                    else
                    {
                        throw error;
                    }
                }
            }
        }

        public Stream GetImageTile(string authenticationCookie, string sopInstanceUID, int frame, int x, int y, int width, int height, int xResolution, int yResolution, Boolean wldata, string userData)
        {
           ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            LeadRect tile = LeadRect.Create(x, y, width, height);

           
            string mime;
            var stream = AddinsFactory.CreateObjectRetrieveAddin().GetImageTile(sopInstanceUID, frame, tile, xResolution, yResolution, wldata, userData, out mime);
            WebOperationContext.Current.OutgoingResponse.ContentType = mime;
            return stream;
        }

        public string GetDicomJSON(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string sopInstanceUID, string userData)
        {
           var user = ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

           ExtraOptions extraOptions = new ExtraOptions();
            ObjectUID uid = new ObjectUID();
            extraOptions.UserData = userData;
            uid.StudyInstanceUID = studyInstanceUID;
            uid.SeriesInstanceUID = seriesInstanceUID;

            if (string.IsNullOrEmpty(sopInstanceUID))
            {
               var options = new QueryOptions();
               options.StudiesOptions = new StudiesQueryOptions();
               options.StudiesOptions.StudyInstanceUID = studyInstanceUID;
               options.SeriesOptions = new SeriesQueryOptions();
               options.SeriesOptions.SeriesInstanceUID = seriesInstanceUID;
               var objectsFound = AddinsFactory.CreateQueryAddin().FindInstances(user, options, 1, true);
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

            return AddinsFactory.CreateObjectRetrieveAddin().GetDicomJSON(uid);
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

        /// <summary>
        /// Gets the raw DICOM object as XML
        /// </summary>
        /// <param name="authenticationCookie">Cookie</param>
        /// <param name="uid">UIDs. Only SOPInstanceUID is used</param>
        /// <param name="options">Query options</param>
        /// <param name="extraOptions">Extra options</param>
        /// <returns>The DICOM as XML</returns>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        public XmlElement GetDicomXml(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string sopInstanceUID, string userData)
        {
           ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            ObjectUID uid = new ObjectUID();
            
            uid.StudyInstanceUID = studyInstanceUID;
            uid.SeriesInstanceUID = seriesInstanceUID;
            uid.SOPInstanceUID = sopInstanceUID;

            return AddinsFactory.CreateObjectRetrieveAddin().GetDicomXml(uid);
        }
      
        public XmlElement GetPresentationAnnotations(string authenticationCookie, string sopInstanceUID, string userData)
        {
           ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            Stream annStream = AddinsFactory.CreateObjectRetrieveAddin().GetPresentationAnnotations(sopInstanceUID, userData);

            if (null == annStream)
            {
                return null;
            }
            else
            {
                annStream.Position = 0;
                XmlDocument document = new XmlDocument();
                document.Load(annStream);
                return document.DocumentElement;
            }
        }

        public Layout GetSeriesLayout(string authenticationCookie, string seriesInstanceUID, string userData)
        {
           var userName = ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         return AddinsFactory.CreateObjectRetrieveAddin().GetSeriesLayout(userName, seriesInstanceUID, new Lazy<IStoreAddin>(() => AddinsFactory.CreateStoreAddin()), userData);
        }

        public StudyLayout GetStudyLayout(string authenticationCookie, string studyInstanceUID, string userData)
        {
           var userName = ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            return AddinsFactory.CreateObjectRetrieveAddin().GetStudyLayout(userName, studyInstanceUID, userData);
        }


        public Stream GetSeriesThumbnail(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, int width, int height)
        {
           var userName = ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            WebOperationContext.Current.OutgoingResponse.ContentType = SupportedMimeTypes.JPG;
         
            return AddinsFactory.CreateObjectRetrieveAddin().GetSeriesThumbnail(userName, seriesInstanceUID, SupportedMimeTypes.JPG, 24, 10, width, height);
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
           ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            if (string.IsNullOrEmpty(mimeType))
            {
                mimeType = SupportedMimeTypes.WAVE;
            }

            WebOperationContext.Current.OutgoingResponse.ContentType = mimeType;

            return AddinsFactory.CreateObjectRetrieveAddin().GetAudio(sopInstanceUID, groupIndex, mimeType);
        }

        public int GetAudioGroupsCount(string authenticationCookie, string sopInstanceUID)
        {
           ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            try
            {
                return AddinsFactory.CreateObjectRetrieveAddin().GetAudioGroupsCount(sopInstanceUID);
            }
            catch
            {
                return 0;
            }
        }

        public int[] GetMinMaxValues(string authenticationCookie, string sopInstanceUID, int frameNumber, string userData)
        {
           ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            return AddinsFactory.CreateObjectRetrieveAddin().GetMinMaxValues(sopInstanceUID, frameNumber);
        }

        public List<StackItem> GetSeriesStacks(string authenticationCookie, string seriesInstanceUID, string userData)
        {
           ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            return AddinsFactory.CreateObjectRetrieveAddin().GetSeriesStacks(seriesInstanceUID);
        }


        public WCFHangingProtocol GetHangingProtocol(string authenticationCookie, string sopInstanceUID, string userData)
        {
           var userName = ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            return AddinsFactory.CreateObjectRetrieveAddin().GetHangingProtocol(userName, sopInstanceUID, userData);
        }

        public List<DisplaySetView> GetHangingProtocolInstances(string authenticationCookie, string hangingProtocolSOP, string patientID, string studyInstanceUID, string studyDateMostRecent, string userData)
        {
           var userName = ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanRetrieve);

            return AddinsFactory.CreateObjectRetrieveAddin().GetHangingProtocolInstances(userName, hangingProtocolSOP, patientID, studyInstanceUID, studyDateMostRecent, userData);
        }

        public void ClearCache(string authenticationCookie)
        {
            try
            {
               ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanDeleteCache);
               AddinsFactory.RefreshTimeStamp();
               var storage = AddinsFactory.CacheDiskStorage;
               if (null != storage)
               {
                  storage.RunCleanup(null);
               }
            }
            catch { }
        }

    }
}
