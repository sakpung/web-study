using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Leadtools;
using Leadtools.Barcode;
using Leadtools.Ocr;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Serverless_Cloud_Services_API
{
   public static class CommonMethods
   {
      private static HttpClient client = new HttpClient();
      private static IOcrEngine ocrEngine;

      public static IOcrEngine GetOcrEngine()
      {
         if(ocrEngine == null)
            ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, false);

         if (!ocrEngine.IsStarted)
         {
            if (string.IsNullOrWhiteSpace(DemoConfiguration.OCREnginePath))
               ocrEngine.Startup(null, null, null, null);
            else
               ocrEngine.Startup(null, null, null, DemoConfiguration.OCREnginePath);            
         }

         return ocrEngine;
      }

      public static List<BarcodeSymbology> ExtractBarcodeSymbologies(HttpRequestMessage req)
      {
         var nameValuePairs = req.GetQueryNameValuePairs();
         var symbologyString = nameValuePairs.FirstOrDefault(q => string.Compare(q.Key, "symbologies", true) == 0).Value;
         var symbologyList = new List<BarcodeSymbology>();
         if (string.IsNullOrEmpty(symbologyString))//If no symbology string is passed, default to all symbologies. 
         {
            symbologyList = Enum.GetValues(typeof(BarcodeSymbology)).OfType<BarcodeSymbology>().ToList();
            symbologyList.Remove(BarcodeSymbology.Unknown);
         }
         else
         {
            var splitSymbologies = symbologyString.Split(',');
            foreach (var symbologyToParse in splitSymbologies)
            {
               if (!Enum.TryParse(symbologyToParse, true, out BarcodeSymbology parsedSymbology))
               {
                  symbologyList.Clear();
                  break;
               }
               symbologyList.Add(parsedSymbology);
            }
            symbologyList = symbologyList.Distinct().ToList();         
         }

         return symbologyList;
      }
      public static AuthReturn ParseAuthenticationHeader(HttpRequestMessage req)
      {
         if (req == null)
            return new AuthReturn(ApiError.Unauthorized);

         var authHeader = req.Headers.Authorization;
         if (authHeader == null)
            return new AuthReturn(ApiError.Unauthorized);

         //Since the Authorization header is defined as user:pw, the minimum parameter length we will accept for the authorization header parameter is 3. 
         if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeader.Parameter != null && authHeader.Parameter.Length >= 3)
         {
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var credentials = encoding.GetString(System.Convert.FromBase64String(authHeader.Parameter));
            int separator = credentials.IndexOf(':');

            var appId = credentials.Substring(0, separator);
            var password = credentials.Substring(separator + 1);


            return (!string.IsNullOrWhiteSpace(appId) && !string.IsNullOrWhiteSpace(password)) ?
               new AuthReturn() { Successful = true, AppId = appId, Password = password } :
               new AuthReturn(ApiError.Unauthorized);
         }

         return new AuthReturn(ApiError.Unauthorized);
      }

      public static HttpResponseMessage GenerateErrorMessage(ApiError errorType, HttpRequestMessage req)
      {
         try
         {
            if (req == null)
               throw new ArgumentNullException();

            switch (errorType)
            {
               case ApiError.Unauthorized:
                  return req.CreateResponse(HttpStatusCode.Unauthorized, "Invalid Authentication Information");
               case ApiError.InvalidRequest:
                  return req.CreateResponse(HttpStatusCode.BadRequest, "Malformed Request");
               case ApiError.LicenseNotSet:
                  return req.CreateResponse(HttpStatusCode.PaymentRequired, "Your LEADTOOLS License file has not been set correctly");
               default:
                  return req.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred while processing your request");
            }
         }
         catch
         {
            return new HttpResponseMessage() { StatusCode = HttpStatusCode.InternalServerError, Content = new StringContent("An error occurred while processing your request") };
         }
      }

      public static ParseWebRequestReturn ParseLeadWebRequestParameters(HttpRequestMessage request)
      {
         var nameValuePairs = request.GetQueryNameValuePairs();

         //first we will parse the required parameters
         var firstPageString = nameValuePairs.FirstOrDefault(q => string.Compare(q.Key, "firstPage", true) == 0).Value;

         var lastPageString = nameValuePairs.FirstOrDefault(q => string.Compare(q.Key, "lastPage", true) == 0).Value;

         var fileUrlString = nameValuePairs.FirstOrDefault(q => string.Compare(q.Key, "fileUrl", true) == 0).Value;

         if (!Int32.TryParse(firstPageString, out int firstPage) || !Int32.TryParse(lastPageString, out int lastPage))
            return new ParseWebRequestReturn() { Successful = false };

         var leadRequest = new LeadWebRequest()
         {
            FirstPage = firstPage,
            LastPage = lastPage,
            fileUrl = fileUrlString
         };

         return new ParseWebRequestReturn() { Successful = true, LeadWebRequest = leadRequest };
      }

      public static async Task<ImageDataReturn> GetImageStreamAsync(string imageUrl, HttpRequestMessage request, int maxUrlMbs)
      {
         Stream stream = null;

         if (imageUrl == null) //File passed in the request
         {
            if (request == null)
               return new ImageDataReturn(ApiError.InvalidRequest);

            if (!request.Content.IsMimeMultipartContent())
               return new ImageDataReturn(ApiError.InvalidRequest);

            var provider = await request.Content.ReadAsMultipartAsync(new MultipartMemoryStreamProvider());
            HttpContent content = (provider.Contents.Count > 0) ? content = provider.Contents[0] : null;

            if (content == null)
               return new ImageDataReturn(ApiError.InvalidRequest);

            stream = content.ReadAsStreamAsync().Result;
         }
         else //Check the URL parameter
         {
            if (!Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
               return new ImageDataReturn(ApiError.InvalidRequest);

            if (!Uri.TryCreate(imageUrl, UriKind.Absolute, out Uri uri))
               return new ImageDataReturn(ApiError.InvalidRequest);

            if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
               return new ImageDataReturn(ApiError.InvalidRequest);

            if (!IsUrlImage(uri, maxUrlMbs))
               return new ImageDataReturn(ApiError.FileRejected);

            byte[] imageData = await DownloadData(uri);
            if (imageData == null)
               return new ImageDataReturn(ApiError.InvalidRequest);

            stream = new MemoryStream(imageData);
         }

         return new ImageDataReturn() { Successful = true, Stream = stream };
      }

      
      public async static Task<byte[]> DownloadData(Uri url)
      {
         if (client == null)
            client = new HttpClient();

         var data = await client.GetByteArrayAsync(url);
         return data;
      }

      public static bool IsUrlImage(Uri url, int maxUserMbs)
      {
         try
         {

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Timeout = 10000;
            request.Method = "HEAD";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
               var bytes = response.ContentLength;
               var mb = (bytes / 1024) / 1024;
               if (mb > maxUserMbs)
                  return false;
               //For the purposes of this demo, we will accept all content types.  To filter out Mimetypes, you can check the response.ContentType property. 
               if (response.StatusCode == HttpStatusCode.OK)
                  return true;
               else
                  return false;
            }
         }
         catch
         {
            return false;
         }
      }

      public static void SaveToDisk(Stream s, string name)
      {
         var ms = new MemoryStream();
         s.CopyTo(ms);
         File.WriteAllBytes(name, ms.ToArray());
         ms.Dispose();
      }

      public static Uri UploadFileToBlobStorage(Stream stream, string fileName)
      {
         try
         {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(DemoConfiguration.BlobStorageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(DemoConfiguration.BlobContainerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            if (stream.Length > 0)
            {
               stream.Position = 0;
               blockBlob.UploadFromStream(stream);
            }

            return blockBlob.Uri;
         }
         catch (Exception)
         {
            throw;
         }
      }
   }
}
