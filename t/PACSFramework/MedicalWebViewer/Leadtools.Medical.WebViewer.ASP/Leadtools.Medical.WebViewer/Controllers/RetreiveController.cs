// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using System.Collections.Generic;
using Leadtools.Medical.WebViewer.Core.DataTypes;
using System.IO;
using System.Xml;
using Leadtools.Medical.WebViewer.DataContracts;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Controllers
{
    [RoutePrefix("api/retrieve")]
    public class RetrieveController : ApiController
    {
        private IRetrieveHandler _impl;
        private IRetrieveHandler _wimpl;
        public RetrieveController([Dependency("local")] IRetrieveHandler impl, [Dependency("wado")] IRetrieveHandler wimpl)
        {
            _impl = impl;
            _wimpl = wimpl;
        }

        [Route("ping")]
        [HttpGet]
        public HttpResponseMessage ping()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("Leadtools Medical Services - ObjectRetrieve", Encoding.Unicode);
            return response;
        }

        Exception Error(Exception e)
        {
            var message = string.Format(e.Message + "\r\n" + e.StackTrace);
            var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            throw new HttpResponseException(errorResponse);
        }

        private IRetrieveHandler impl(dynamic model)
        {
            return _impl;
        }

        [Route("GetImage")]
        [HttpGet]
        public HttpResponseMessage GetImage([FromUri]string auth, [FromUri]string instance, [FromUri]int frame, [FromUri]string mime, [FromUri]int? bp, [FromUri]int? qf, [FromUri]int? cx, [FromUri]int? cy, [FromUri]string data = null)
        {
            var result = impl(data).GetImage(auth, instance, frame, mime, bp ?? 0, qf ?? 0, cx ?? 0, cy ?? 0, data);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StreamContent(result ?? Stream.Null);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(mime);
            return response;
        }

        [Route("DownloadImage")]
        [HttpGet]
        public HttpResponseMessage DownloadImage([FromUri]string auth, [FromUri]string instance, [FromUri]int frame, [FromUri]int? bp, [FromUri]int? qf, [FromUri]int? cx, [FromUri]int? cy, [FromUri]string annotationFileName, [FromUri]double? xDpi, [FromUri]double? yDpi, [FromUri]string data = null)
        {
            var result = impl(data).DownloadImage(auth, instance, frame, bp ?? 0, qf ?? 0, cx ?? 0, cy ?? 0, annotationFileName, xDpi ?? 0, yDpi ?? 0, data);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StreamContent(result);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            response.Content.Headers.Add("Content-Disposition", string.Format("attachment; filename={0}.jpg", instance));
            return response;
        }

        [Route("UploadAnnotations")]
        [HttpPost]
        public string UploadAnnotations([FromBody]dynamic model)
        {
            return impl(model).UploadAnnotations((string)model.authenticationCookie, (string)model.data);
        }

        [Route("GetDicom")]
        [HttpPost]
        public HttpResponseMessage GetDicom([FromBody]dynamic model)
        {
            var result = impl(model).GetDicom((string)model.authenticationCookie, model.uid.ToObject<ObjectUID>(), model.options.ToObject<GetDicomOptions>());
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StreamContent(result);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return response;
        }

        [Route("GetPresentationAnnotations")]
        [HttpGet]
        //alternatively we may return an XmlElement
        public string GetPresentationAnnotations([FromUri]string auth, [FromUri]string instance, [FromUri]string data = null)
        {
            return impl(null).GetPresentationAnnotationsString(auth, instance, data);
        }

        [Route("GetAudio")]
        [HttpGet]
        public HttpResponseMessage GetAudio([FromUri]string auth, [FromUri]string instance, [FromUri]int group, [FromUri]string mime)
        {
            var result = impl(null).GetAudio(auth, instance, group, mime);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StreamContent(result);
            if (!string.IsNullOrEmpty(mime))
            {
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(mime);
            }
            else
            {
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("audio/wav");
            }
            return response;
        }

        [Route("GetAudioGroupsCount")]
        [HttpPost]
        public int GetAudioGroupsCount([FromBody]dynamic model)
        {
            return impl(model).GetAudioGroupsCount((string)model.authenticationCookie, (string)model.sopInstanceUID);
        }

        [Route("GetSeriesLayout")]
        [HttpGet]
        public Layout GetSeriesLayout([FromUri]string auth, [FromUri]string seriesInstanceUID, [FromUri]string data = null)
        {
            return impl(data).GetSeriesLayout(auth, seriesInstanceUID, data);
        }

        [Route("GetPatientStructuredDisplay")]
        [HttpGet]
        public List<StudyLayout> GetPatientStructuredDisplay([FromUri]string auth, [FromUri]string patientID, [FromUri]string data = null)
        {
            return impl(data).GetPatientStructuredDisplay(auth, patientID, data);
        }

        [Route("GetStudyLayout")]
        [HttpGet]
        public StudyLayout GetStudyLayout([FromUri]string auth, [FromUri]string studyInstanceUID, [FromUri]string data = null)
        {
            return impl(data).GetStudyLayout(auth, studyInstanceUID, data);
        }

        [Route("GetSeriesThumbnail")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetSeriesThumbnail([FromUri]string auth, [FromUri]string study, [FromUri]string series, [FromUri]int? cx, [FromUri]int? cy)
        {
            var result = await impl(null).GetSeriesThumbnail(auth, study, series, "image/jpeg", 24, 10, cx ?? 0, cy ?? 0);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StreamContent(result);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            return response;
        }

        [Route("GetSeriesStacks")]
        [HttpGet]
        public List<StackItem> GetSeriesStacks([FromUri]string auth, [FromUri]string seriesInstanceUID, [FromUri]string data = null)
        {
            return impl(data).GetSeriesStacks(auth, seriesInstanceUID, data);
        }

        [Route("GetImageTile")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetImageTile([FromUri]string auth, [FromUri]string instance, [FromUri]int frame, [FromUri]int? x = null, [FromUri]int? y = null, [FromUri]int? w = null, [FromUri]int? h = null, [FromUri]int? xr = null, [FromUri]int? yr = null, [FromUri]bool? wldata = true, [FromUri]string data = null)
        {
            var result = await impl(data).GetImageTile(auth, instance, frame, x ?? 0, y ?? 0, w ?? 0, h ?? 0, xr ?? 0, yr ?? 0, wldata ?? true, data);

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StreamContent(result.Item1);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(result.Item2);
            return response;
        }

        [Route("GetDicomJSON")]
        [HttpGet]
        public async Task<string> GetDicomJSON([FromUri]string auth, [FromUri]string study, [FromUri]string series, [FromUri]string instance = null, [FromUri]string data = null)
        {
            return await impl(data).GetDicomJSON(auth, study, series, instance, data);
        }

        [Route("GetHangingProtocol")]
        [HttpGet]
        public WCFHangingProtocol GetHangingProtocol([FromUri]string auth, [FromUri]string instance, [FromUri]string data = null)
        {
            return impl(data).GetHangingProtocol(auth, instance, data);
        }

        [Route("GetHangingProtocolInstances")]
        [HttpPost]
        public List<DisplaySetView> GetHangingProtocolInstances([FromBody]dynamic model)
        {
            return impl(model).GetHangingProtocolInstances((string)model.authenticationCookie, (string)model.hangingProtocolSOP, (string)model.patientID, (string)model.studyInstanceUID, (string)model.studyDateMostRecent, (string)model.userData);
        }

        [Route("ClearCache")]
        [HttpPost]
        public void ClearCache([FromBody]dynamic model)
        {
            impl(null).ClearCache((string)model.authenticationCookie);
        }
    }
}
