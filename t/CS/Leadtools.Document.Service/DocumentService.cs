// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Models;
using Leadtools.Document.Service.Models.Annotations;
using Leadtools.Document.Service.Models.Compare;
using Leadtools.Document.Service.Models.Document;
using Leadtools.Document.Service.Models.Factory;
using Leadtools.Document.Service.Models.Page;
using Leadtools.Document.Service.Models.PreCache;
using Leadtools.Document.Service.Models.StatusJobConverter;
using Leadtools.Document.Service.Models.Structure;
using Leadtools.Document.Service.Models.Test;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Leadtools.Document.Service
{
   public class Result<TResponse>
   {
      public ServiceError Error;
      public TResponse Response;
   }

   public class DocumentService : IDisposable
   {
      public DocumentService()
      {
         _test = new TestController(this);
         _factory = new FactoryController(this);
         _document = new DocumentController(this);
         _page = new PageController(this);
         _structure = new StructureController(this);
         _statusJobConverter = new StatusJobConverterController(this);
         _annotations = new AnnotationsController(this);
         _cache = new CacheController(this);
         _compare = new CompareController(this);
      }

      protected virtual void Dispose(bool disposing)
      {
      }

      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      ~DocumentService()
      {
         Dispose(false);
      }

      private static readonly HttpClient _client = new HttpClient();
      public static HttpClient Client
      {
         get { return _client; }
      }

      internal void EnsureClient()
      {
         if (ServiceAddress == null)
            throw new InvalidOperationException("Must set DocumentService.ServiceAddress before calling this method");
      }

      private Uri _serviceAddress;// = "http://localhost:20000/";
      public Uri ServiceAddress
      {
         get { return _serviceAddress; }
         set { _serviceAddress = value; }
      }

      public bool EnsureSuccessStatusCode { get; set; } = true;

      public async Task<Result<TResponse>> PostAsync<TRequest, TResponse>(string api, TRequest request)
      {
         EnsureClient();

         var fullApiPath = this.ServiceAddress.ToString() + api;

         StringContent requestContent = null;

         if (request != null)
         {
            string jsonRequest = JsonConvert.SerializeObject(request);
            requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
         }

         HttpResponseMessage responseMessage = await _client.PostAsync(fullApiPath, requestContent);

         string responseJson = await responseMessage.Content.ReadAsStringAsync();

         if (EnsureSuccessStatusCode)
         {
            responseMessage.EnsureSuccessStatusCode();
         }
         else if (!responseMessage.IsSuccessStatusCode)
         {
            var error = JsonConvert.DeserializeObject<ServiceError>(responseJson);
            return new Result<TResponse>
            {
               Error = error
            };
         }

         var response = JsonConvert.DeserializeObject<TResponse>(responseJson);
         return new Result<TResponse>
         {
            Response = response
         };
      }

      public async Task<Result<TResponse>> PostAsync<TRequest, TResponse>(string api, HttpContent content)
      {
         EnsureClient();

         var fullApiPath = this.ServiceAddress.ToString() + api;

         HttpResponseMessage responseMessage = await _client.PostAsync(fullApiPath, content);

         string responseJson = await responseMessage.Content.ReadAsStringAsync();

         if (EnsureSuccessStatusCode)
         {
            responseMessage.EnsureSuccessStatusCode();
         }
         else if (!responseMessage.IsSuccessStatusCode)
         {
            var error = JsonConvert.DeserializeObject<ServiceError>(responseJson);
            return new Result<TResponse>
            {
               Error = error
            };
         }

         var response = JsonConvert.DeserializeObject<TResponse>(responseJson);
         return new Result<TResponse>
         {
            Response = response
         };
      }

      public async Task<Result<TResponse>> GetAsync<TRequest, TResponse>(string api, NameValueCollection query)
      {
         EnsureClient();

         var builder = new UriBuilder(this.ServiceAddress.ToString() + api);
         builder.Query = query.ToString();
         string fullApiPath = builder.ToString();

         HttpResponseMessage responseMessage = await _client.GetAsync(fullApiPath);

         string responseJson = await responseMessage.Content.ReadAsStringAsync();
         if (EnsureSuccessStatusCode)
         {
            responseMessage.EnsureSuccessStatusCode();
         }
         else if (!responseMessage.IsSuccessStatusCode)
         {
            var error = JsonConvert.DeserializeObject<ServiceError>(responseJson);
            return new Result<TResponse>
            {
               Error = error
            };
         }

         var response = JsonConvert.DeserializeObject<TResponse>(responseJson);
         return new Result<TResponse>
         {
            Response = response
         };
      }

      public async Task<Result<HttpResponseMessage>> GetAsyncMessage(string api, NameValueCollection query)
      {
         EnsureClient();

         var builder = new UriBuilder(this.ServiceAddress.ToString() + api);
         builder.Query = query.ToString();
         string fullApiPath = builder.ToString();

         HttpResponseMessage response = await _client.GetAsync(fullApiPath);

         if (EnsureSuccessStatusCode)
         {
            response.EnsureSuccessStatusCode();
         }
         else if (!response.IsSuccessStatusCode)
         {
            string responseJson = await response.Content.ReadAsStringAsync();
            var error = JsonConvert.DeserializeObject<ServiceError>(responseJson);
            return new Result<HttpResponseMessage>
            {
               Error = error
            };
         }

         return new Result<HttpResponseMessage>
         {
            Response = response
         };
      }

      private static string BuildQuery(string url, IEnumerable<KeyValuePair<string, string>> queryParams)
      {
         if (queryParams == null)
            return url;

         var result = new StringBuilder();
         result.Append(url);
         string pre = "?";
         foreach (var queryParam in queryParams)
         {
            if (!string.IsNullOrEmpty(queryParam.Value))
            {
               result.Append(pre);
               result.Append(queryParam.Key);
               result.Append("=");
               result.Append(queryParam.Value);
               pre = "&";
            }
         }

         return result.ToString();
      }

      public class TestController
      {
         private TestController() { }
         private DocumentService _owner;
         internal TestController(DocumentService owner)
         {
            _owner = owner;
         }

         public async Task<Result<PingResponse>> Ping(Request request)
         {
            const string api = "api/Test/Ping";
            var response = await _owner.PostAsync<Request, PingResponse>(api, request);
            return response;
         }

         public async Task<Result<PingResponse>> PingGet(Request request)
         {
            const string api = "api/Test/Ping";

            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            if (request.UserData != null)
               query["userData"] = request.UserData;

            var response = await _owner.GetAsync<Request, PingResponse>(api, query);
            return response;
         }

         public async Task<Result<HeartbeatResponse>> Heartbeat(Request request)
         {
            const string api = "api/Test/Heartbeat";
            var response = await _owner.PostAsync<Request, HeartbeatResponse>(api, request);
            return response;
         }

         public async Task<Result<HeartbeatResponse>> HeartbeatGet(Request request)
         {
            const string api = "api/Test/Heartbeat";

            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            if (request.UserData != null)
               query["userData"] = request.UserData;

            var response = await _owner.GetAsync<Request, HeartbeatResponse>(api, query);
            return response;
         }
      }

      private TestController _test;
      public TestController Test
      {
         get { return _test; }
      }

      public class FactoryController
      {
         private FactoryController() { }
         private DocumentService _owner;

         internal FactoryController(DocumentService owner)
         {
            _owner = owner;
         }

         public async Task<Result<LoadFromUriResponse>> LoadFromUri(LoadFromUriRequest request)
         {
            const string api = "api/Factory/LoadFromUri";
            var response = await _owner.PostAsync<LoadFromUriRequest, LoadFromUriResponse>(api, request);
            return response;
         }

         public async Task<Result<LoadFromCacheResponse>> LoadFromCache(LoadFromCacheRequest request)
         {
            const string api = "api/Factory/LoadFromCache";
            var response = await _owner.PostAsync<LoadFromCacheRequest, LoadFromCacheResponse>(api, request);
            return response;
         }

         public async Task<Result<CheckCacheInfoResponse>> CheckCacheInfo(CheckCacheInfoRequest request)
         {
            const string api = "api/Factory/CheckCacheInfo";
            var response = await _owner.PostAsync<CheckCacheInfoRequest, CheckCacheInfoResponse>(api, request);
            return response;
         }

         public async Task<Result<Response>> Delete(DeleteRequest request)
         {
            const string api = "api/Factory/Delete";
            var response = await _owner.PostAsync<DeleteRequest, Response>(api, request);
            return response;
         }

         public async Task<Result<BeginUploadResponse>> BeginUpload(BeginUploadRequest request)
         {
            const string api = "api/Factory/BeginUpload";
            var response = await _owner.PostAsync<BeginUploadRequest, BeginUploadResponse>(api, request);
            return response;
         }

         public async Task<Result<Response>> UploadDocument(UploadDocumentRequest request)
         {
            const string api = "api/Factory/UploadDocument";
            var response = await _owner.PostAsync<UploadDocumentRequest, Response>(api, request);
            return response;
         }

         public async Task<Result<Response>> UploadDocumentBlob(UploadDocumentBlobRequest request, byte[] data)
         {
            string api = "api/Factory/UploadDocumentBlob";
            string url = BuildQuery(api, new Dictionary<string, string>()
            {
               { "uri", request.Uri != null ? request.Uri.ToString() : null },
               { "userData", request.UserData }
            });
            var multipartDataContent = new MultipartFormDataContent();
            multipartDataContent.Add(new ByteArrayContent(data), "file", "file");
            var response = await _owner.PostAsync<UploadDocumentBlobRequest, Response>(url, multipartDataContent);
            return response;
         }

         public async Task<Result<Response>> EndUpload(EndUploadRequest request)
         {
            const string api = "api/Factory/EndUpload";
            var response = await _owner.PostAsync<EndUploadRequest, Response>(api, request);
            return response;
         }

         public async Task<Result<Response>> AbortUploadDocument(AbortUploadDocumentRequest request)
         {
            const string api = "api/Factory/AbortUploadDocument";
            var response = await _owner.PostAsync<AbortUploadDocumentRequest, Response>(api, request);
            return response;
         }

         public async Task<Result<SaveToCacheResponse>> SaveToCache(SaveToCacheRequest request)
         {
            const string api = "api/Factory/SaveToCache";
            var response = await _owner.PostAsync<SaveToCacheRequest, SaveToCacheResponse>(api, request);
            return response;
         }

         public async Task<Result<CloneDocumentResponse>> CloneDocument(CloneDocumentRequest request)
         {
            const string api = "api/Factory/CloneDocument";
            var response = await _owner.PostAsync<CloneDocumentRequest, CloneDocumentResponse>(api, request);
            return response;
         }

         public async Task<Result<HttpResponseMessage>> DownloadAnnotations(DownloadAnnotationsRequest request)
         {
            const string api = "api/Factory/DownloadAnnotations";

            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            if (request.DocumentId != null)
               query["documentId"] = request.DocumentId;
            if (request.Uri != null)
               query["uri"] = request.Uri.ToString();

            Result<HttpResponseMessage> result = await _owner.GetAsyncMessage(api, query);
            return result;
         }

         public async Task<Result<HttpResponseMessage>> DownloadDocument(DownloadDocumentRequest request)
         {
            const string api = "api/Factory/DownloadDocument";

            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            if (request.DocumentId != null)
               query["documentId"] = request.DocumentId;
            if (request.Uri != null)
               query["uri"] = request.Uri.ToString();
            query["includeAnnotations"] = request.IncludeAnnotations.ToString();
            if (!string.IsNullOrEmpty(request.ContentDisposition))
               query["contentDisposition"] = request.ContentDisposition;

            Result<HttpResponseMessage> result = await _owner.GetAsyncMessage(api, query);
            return result;
         }

         public async Task<Result<ReportPreCacheResponse>> ReportPreCache(ReportPreCacheRequest request)
         {
            const string api = "api/Factory/ReportPreCache";

            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            query["clear"] = request.Clear.ToString();
            query["clean"] = request.Clean.ToString();
            if (request.Passcode != null)
               query["passcode"] = request.Passcode;

            Result<ReportPreCacheResponse> result = await _owner.GetAsync<Request, ReportPreCacheResponse>(api, query);
            return result;
         }

         public async Task<Result<PreCacheDocumentResponse>> PreCacheDocument(PreCacheDocumentRequest request)
         {
            const string api = "api/Factory/PreCacheDocument";
            var response = await _owner.PostAsync<PreCacheDocumentRequest, PreCacheDocumentResponse>(api, request);
            return response;
         }
      }

      private FactoryController _factory;
      public FactoryController Factory
      {
         get { return _factory; }
      }

      public class DocumentController
      {
         private DocumentController() { }
         private DocumentService _owner;
         public DocumentController(DocumentService owner)
         {
            _owner = owner;
         }

         public async Task<Result<DecryptResponse>> Decrypt(DecryptRequest request)
         {
            const string api = "api/Document/Decrypt";
            var result = await _owner.PostAsync<DecryptRequest, DecryptResponse>(api, request);
            return result;
         }
         public async Task<Result<GetHistoryResponse>> GetHistory(GetHistoryRequest request)
         {
            const string api = "api/Document/GetHistory";
            var result = await _owner.PostAsync<GetHistoryRequest, GetHistoryResponse>(api, request);
            return result;
         }
      }

      private DocumentController _document;
      public DocumentController Document
      {
         get { return _document; }
      }

      public class PageController
      {
         private PageController() { }
         private DocumentService _owner;
         internal PageController(DocumentService owner)
         {
            _owner = owner;
         }

         public async Task<Result<Models.Page.GetAnnotationsResponse>> GetAnnotations(Models.Page.GetAnnotationsRequest request)
         {
            const string api = "api/Page/GetAnnotations";
            var result = await _owner.PostAsync<Models.Page.GetAnnotationsRequest, Models.Page.GetAnnotationsResponse>(api, request);
            return result;
         }

         public async Task<Result<Response>> SetAnnotations(Models.Page.SetAnnotationsRequest request)
         {
            const string api = "api/Page/SetAnnotations";
            var result = await _owner.PostAsync<Models.Page.SetAnnotationsRequest, Response>(api, request);
            return result;
         }
      }

      private PageController _page;
      public PageController Page
      {
         get { return _page; }
      }

      public class StructureController
      {
         private StructureController() { }
         private DocumentService _owner;
         internal StructureController(DocumentService owner)
         {
            _owner = owner;
         }


         public async Task<Result<ParseStructureResponse>> ParseStructure(ParseStructureRequest request)
         {
            const string api = "api/Structure/ParseStructure";
            var result = await _owner.PostAsync<ParseStructureRequest, ParseStructureResponse>(api, request);
            return result;
         }
      }

      private StructureController _structure;
      public StructureController Structure
      {
         get { return _structure; }
      }

      public class StatusJobConverterController
      {
         private StatusJobConverterController() { }
         private DocumentService _owner;
         internal StatusJobConverterController(DocumentService owner)
         {
            _owner = owner;
         }

         public async Task<Result<RunConvertJobResponse>> Run(RunConvertJobRequest request)
         {
            const string api = "api/StatusJobConverter/Run";
            var result = await _owner.PostAsync<RunConvertJobRequest, RunConvertJobResponse>(api, request);
            return result;
         }

         public async Task<Result<QueryConvertJobStatusResponse>> Query(QueryConvertJobStatusRequest request)
         {
            const string api = "api/StatusJobConverter/Query";
            var result = await _owner.PostAsync<QueryConvertJobStatusRequest, QueryConvertJobStatusResponse>(api, request);
            return result;
         }

         public async Task<Result<Response>> Delete(DeleteConvertJobStatusRequest request)
         {
            const string api = "api/StatusJobConverter/Delete";
            var result = await _owner.PostAsync<DeleteConvertJobStatusRequest, Response>(api, request);
            return result;
         }

         public async Task<Result<Response>> Abort(AbortConvertJobRequest request)
         {
            const string api = "api/StatusJobConverter/Abort";
            var result = await _owner.PostAsync<AbortConvertJobRequest, Response>(api, request);
            return result;
         }
      }

      private StatusJobConverterController _statusJobConverter;
      public StatusJobConverterController StatusJobConverter
      {
         get { return _statusJobConverter; }
      }

      public class AnnotationsController
      {
         private AnnotationsController() { }
         private DocumentService _owner;
         internal AnnotationsController(DocumentService owner)
         {
            _owner = owner;
         }

         public async Task<Result<SetAnnotationsResponse>> SetAnnotations(Models.Annotations.SetAnnotationsRequest request)
         {
            const string api = "api/Annotations/SetAnnotations";
            var result = await _owner.PostAsync<Models.Annotations.SetAnnotationsRequest, SetAnnotationsResponse>(api, request);
            return result;
         }

         public async Task<Result<Models.Annotations.GetAnnotationsResponse>> GetAnnotations(Models.Annotations.GetAnnotationsRequest request)
         {
            const string api = "api/Annotations/GetAnnotations";
            var result = await _owner.PostAsync<Models.Annotations.GetAnnotationsRequest, Models.Annotations.GetAnnotationsResponse>(api, request);
            return result;
         }


         public async Task<Result<SetAnnotationsLEADResponse>> SetAnnotationsLEAD(SetAnnotationsLEADRequest request)
         {
            const string api = "api/Annotations/SetAnnotationsLEAD";
            var result = await _owner.PostAsync<SetAnnotationsLEADRequest, SetAnnotationsLEADResponse>(api, request);
            return result;
         }

         public async Task<Result<GetAnnotationsLEADResponse>> GetAnnotationsLEAD(GetAnnotationsLEADRequest request)
         {
            const string api = "api/Annotations/GetAnnotationsLEAD";
            var result = await _owner.PostAsync<GetAnnotationsLEADRequest, GetAnnotationsLEADResponse>(api, request);
            return result;
         }

         public async Task<Result<SetAnnotationsIBMResponse>> SetAnnotationsIBM(SetAnnotationsIBMRequest request)
         {
            const string api = "api/Annotations/SetAnnotationsIBM";
            var result = await _owner.PostAsync<SetAnnotationsIBMRequest, SetAnnotationsIBMResponse>(api, request);
            return result;

         }

         public async Task<Result<GetAnnotationsIBMResponse>> GetAnnotationsIBM(GetAnnotationsIBMRequest request)
         {
            const string api = "api/Annotations/GetAnnotationsIBM";
            var result = await _owner.PostAsync<GetAnnotationsIBMRequest, GetAnnotationsIBMResponse>(api, request);
            return result;
         }
      }

      private AnnotationsController _annotations;
      public AnnotationsController Annotations
      {
         get { return _annotations; }
      }

      public class CacheController
      {
         private CacheController() { }
         private DocumentService _owner;
         internal CacheController(DocumentService owner)
         {
            _owner = owner;
         }

         public async Task<Result<HttpResponseMessage>> GetDocumentData(string documentId)
         {
            const string api = "api/Cache/GetDocumentData";

            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            if (documentId != null)
               query["documentId"] = documentId;

            Result<HttpResponseMessage> result = await _owner.GetAsyncMessage(api, query);
            return result;
         }

         public async Task<Result<HttpResponseMessage>> Item(string region, string key)
         {
            const string api = "api/Cache/Item";

            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            if (region != null)
               query["region"] = region;
            if (key != null)
               query["key"] = key;

            Result<HttpResponseMessage> result = await _owner.GetAsyncMessage(api, query);
            return result;
         }
      }

      private CacheController _cache;
      public CacheController Cache
      {
         get { return _cache; }
      }

      public class CompareController
      {
         private CompareController() { }
         private DocumentService _owner;

         internal CompareController(DocumentService owner)
         {
            _owner = owner;
         }

         public async Task<Result<RunCompareJobResponse>> Run(RunCompareJobRequest request)
         {
            const string api = "api/Compare/Run";
            var result = await _owner.PostAsync<RunCompareJobRequest, RunCompareJobResponse>(api, request);
            return result;
         }

         public async Task<Result<QueryCompareJobResponse>> Query(QueryCompareJobRequest request)
         {
            const string api = "api/Compare/Query";
            var result = await _owner.PostAsync<QueryCompareJobRequest, QueryCompareJobResponse>(api, request);
            return result;
         }

         public async Task<Result<HttpResponseMessage>> Delete(DeleteCompareJobRequest request)
         {
            const string api = "api/Compare/Delete";
            var result = await _owner.PostAsync<DeleteCompareJobRequest, HttpResponseMessage>(api, request);
            return result;
         }

         public async Task<Result<HttpResponseMessage>> Abort(AbortCompareJobRequest request)
         {
            const string api = "api/Compare/Abort";
            var result = await _owner.PostAsync<AbortCompareJobRequest, HttpResponseMessage>(api, request);
            return result;
         }
      }

      internal CompareController _compare;
      public CompareController Compare{ get { return this._compare; } }
   }
}
