using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Leadtools;
using Leadtools.Barcode;
using Leadtools.Codecs;
using Leadtools.Ocr;
using Cloud_Services_Api.Configuration;
using Cloud_Services_Api.Helper;
namespace Cloud_Services_Api.Controllers
{
   /// <summary>
   /// Abstract controller that all other controllers in the API will inherit from.  This controller will contain common methods that are used across all API controllers. 
   /// </summary>
    public abstract class BaseController : ApiController
    {
      //Allow the OCR engine to persist between Controller Actions.
      //Creating a new OCR engine instance with each request will significantly slow down the speed that requests are processed. 
      static internal IOcrEngine ocrEngine = InitEngine();

      /// <summary>
      /// Method to create and initialize the LEAD OCR engine. 
      /// </summary>
      static internal IOcrEngine InitEngine()
      {
         DemoConfiguration.UnlockSupport();

         IOcrEngine engine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, false);
         if (string.IsNullOrWhiteSpace(DemoConfiguration.OCREnginePath))
            engine.Startup(null, null, null, null);
         else
            engine.Startup(null, null, null, DemoConfiguration.OCREnginePath);

         return engine;
      }

      /// <summary>
      /// Method to authenticate any request made to the service.  For the purposes of this demo, no authentication information is checked.  There is generic code for conforming to the HTTP Basic Authentication standard.
      /// </summary>
      internal void AuthenticateRequest()
      {
         /*
           var authHeader = this.Request.Headers.Authorization;
           if (authHeader == null)
              throw new UnauthorizedAccessException();
           if(authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeader.Parameter != null)
           {
              var encoding = Encoding.GetEncoding("iso-8859-1");
              var credentials = encoding.GetString(Convert.FromBase64String(authHeader.Parameter));
              int separator = credentials.IndexOf(':');

              var username = credentials.Substring(0, separator);
              var password = credentials.Substring(separator + 1);

              // Check Authentication information here
           }
           else
              throw new UnauthorizedAccessException();
         */
      }

      /// <summary>
      /// Method to verify the common parameters that are sent with every request to the service.  This method also double checks to make sure that the LEADTOOLS license is set appropriately.
      /// </summary>
      internal bool VerifyCommonParameters(LeadWebRequest request)
      {
         try
         {
            if (request == null)
               throw new Exception();

            //Passing a last page value of -1 indicates that we want to process every page in the file.
            if ((request.FirstPage > request.LastPage && request.LastPage != -1) || request.FirstPage < 1)
               throw new Exception();

            if (!DemoConfiguration.UnlockSupport())
               throw new RasterException("Your license file is missing, invalid or expired. LEADTOOLS will not function. Please contact LEAD Sales for information on obtaining a valid license");

            return true;
         }
         catch(RasterException)
         {
            throw;
         }
         catch
         {
            return false;
         }
      }

      /// <summary>
      /// Method to parse an exception, and return an appropriate HTTP response and message. 
      /// </summary>
      internal HttpResponseMessage GenerateExceptionMessage(Exception e)
      {
         InvalidRequest ReturnRequest = new InvalidRequest();
         if (e is MalformedRequestException)
         {
            ReturnRequest.Status = HttpStatusCode.BadRequest;
            ReturnRequest.ErrorMessage = "Malformed Request";
         }
         //For RasterExceptions (which are thrown by the LEADTOOLS SDK), we return the exception message in the response for debugging purposes. In a production environment, these exception messages should NOT be bubbled up to user.
         else if(e is RasterException) 
         {
            ReturnRequest.Status = HttpStatusCode.InternalServerError;
            ReturnRequest.ErrorMessage = e.Message;
         }
         else
         {
            ReturnRequest.Status = HttpStatusCode.InternalServerError;
            ReturnRequest.ErrorMessage = e.Message;
         }

         return new HttpResponseMessage()
         {
            StatusCode = ReturnRequest.Status,
            Content = new StringContent(ReturnRequest.ErrorMessage)
         };
         }

      /// <summary>
      /// Method to extract file data sent by a request.  This method will prioritize a file passed via the fileUrl request parameter over a file passed as multi-part content. 
      /// </summary>
      internal async Task<Stream> GetImageStream(string ImageUrl)
      {
         var uri = (ImageUrl != null) ? new Uri(ImageUrl) : null;
         Stream stream = null;

         if (uri == null) //File passed as multi-part content in the request
         {
            if (!Request.Content.IsMimeMultipartContent())
               throw new MalformedRequestException();

            var provider = await Request.Content.ReadAsMultipartAsync(new MultipartMemoryStreamProvider());
            HttpContent content = (provider.Contents.Count > 0) ? content = provider.Contents[0] : null;

            if (content == null)
               throw new MalformedRequestException();

            stream = content.ReadAsStreamAsync().Result;
         }
         else if (IsUrlImage(uri, DemoConfiguration.MaxUrlMbs))
         {
            byte[] imageData = DownloadData(uri);
            stream = new MemoryStream(imageData);
         }
         else
            throw new MalformedRequestException();

         return stream;
      }

      /// <summary>
      /// Method to determine whether or not a URL is valid. 
      /// </summary>
      internal bool IsUrlImage(Uri url, int maxMbAllowed)
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
               if (mb > maxMbAllowed)
                  return false;

               //For further sanitation of URL requests, the Mime-type of the file can be checked by accessing the response.ContentType parameter. 
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

      /// <summary>
      /// Method to ensure that a files that is sent to the service is valid
      /// </summary>
      internal void ValidateFile(Stream s, ref int lastPage)
      {         
         try
         {
            using (var codecs = new RasterCodecs())
            using (var info = codecs.GetInformation(s, true))
            {
               //Now that we have the actual file information, we can verify the properties of the file itself.  We will sanitize the lastPage parameter of the request to make sure that it pointing to a valid location within the file. 
               if (lastPage == -1 || lastPage > info.TotalPages)
                  lastPage = info.TotalPages;

               //Check to determine whether or not a file is raster-based, or if it is a document/vector file.  If it is a document/vector file, we can check and see if it is a format that is supposed by calling codecs.LoadSvg
               if (info.Document.IsDocumentFile || info.Vector.IsVectorFile)
               {
                  var options = new CodecsLoadSvgOptions { MaximumElements = DemoConfiguration.MaxSvgElements };
                  using (var svg = codecs.LoadSvg(s, 1, options))
                     if (svg == null)
                        throw new RejectedFileException();
               }

            }
         }
         //If the file format is not supported by the LEADTOOLS SDK, or if it isn't possible to pull info from the file (such as the case with txt files), the RasterCodecs.GetInformation call will fail.  This will cause the SDK to throw a RasterException -- which we can catch, and then reject the file.
         catch (RasterException)
         {
            throw new RejectedFileException();
         }
         catch(Exception)
         {
            throw;
         }         
      }

      /// <summary>
      /// Download stream from a URI
      /// </summary>
      internal static byte[] DownloadData(Uri url)
      {
         using (var wc = new WebClient())
            return wc.DownloadData(url);
      }

      /// <summary>
      /// Write a stream to disk
      /// </summary>
      internal static void SaveToDisk(Stream s, string name)
      {
         var ms = new MemoryStream();
         s.CopyTo(ms);
         File.WriteAllBytes(name, ms.ToArray());
         ms.Dispose();
      }

      internal static List<BarcodeSymbology> ExtractBarcodeSymbologies(string symbologyList)
      {
         try
         {
            var returnList = new List<BarcodeSymbology>();

            var splitSymbologies = symbologyList.Split(',');
            foreach (var symbologyToParse in splitSymbologies)
            {
               if (!Enum.TryParse(symbologyToParse, true, out BarcodeSymbology parsedSymbology))
                  throw new Exception();

               returnList.Add(parsedSymbology);
            }

            return returnList.Distinct().ToList(); //Remove any duplicate entries from the list
         }
         catch
         {
            //Instead of throwing an error -- we will return an empty list.  We can check API side to see if the user actually passed a valid string of BarcodeSymbologies, and handle returning an error there. 
            return new List<BarcodeSymbology>();
         }
      }
   }
}
