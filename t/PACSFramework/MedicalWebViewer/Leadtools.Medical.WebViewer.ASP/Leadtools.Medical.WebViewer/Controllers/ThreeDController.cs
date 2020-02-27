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
using Leadtools.Medical.WebViewerModels;
using Leadtools.Medical.WebViewer.DataContracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Leadtools.Medical.WebViewer.Common;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Net.Http.Headers;
using System.Web;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Leadtools.Medical.WebViewer.Controllers
{
    [RoutePrefix("api/threed")]
    public class ThreeDController : ApiController
    {
        private IThreeDHandler _threedimpl;

        public ThreeDController(IThreeDHandler threedmpl)
        {
            _threedimpl = threedmpl;
        }

        [Route("ping")]
        [HttpGet]
        public HttpResponseMessage ping()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("Leadtools Medical Services - 3D Service", Encoding.Unicode);
            return response;
        }

        Exception Error(Exception e)
        {
            var message = string.Format(e.Message + "\r\n" + e.StackTrace);
            var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            throw new HttpResponseException(errorResponse);
        }

        [Route("GetPanoramicImage")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetPanoramicImage([FromUri]string auth, [FromUri]string id, [FromUri]int resizeFactor, [FromUri]string polygonInfo, [FromUri]string polygonData)
        {
            try
            {
                var result = await Task.Factory.StartNew(() => _threedimpl.GetPanoramicImage(auth, id, resizeFactor, polygonInfo, polygonData));
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StreamContent(result);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                return response;
            }
            catch (Exception ex)
            {
                throw Error(ex);
            }

        }



        [Route("Get3DImage")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get3DImage([FromUri]string auth, [FromUri]string id, [FromUri]int x, [FromUri]int y, [FromUri]int width, [FromUri]int height, [FromUri]int resizeFactor, [FromUri]string effect, [FromUri]int action, [FromUri]float sensitivity, [FromUri]float resizeRatio)
        {
            try
            {
                var result = await Task.Factory.StartNew(() => _threedimpl.Get3DImage(auth, id, x, y, width, height, resizeFactor, effect, action, sensitivity, resizeRatio));
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StreamContent(result);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                return response;
            }
            catch (Exception ex)
            {
                throw Error(ex);
            }

        }

        [Route("End3DObject")]
        [HttpPost]
        public async Task<bool> End3DObject([FromBody]dynamic model)
        {
            try
            {
                return await Task.Factory.StartNew(() => _threedimpl.End3DObject(model.authenticationCookie.ToString(), model.id.ToString()));
            }
            catch (Exception ex)
            {
                throw Error(ex);
            }
        }

        [Route("Create3DObject")]
        [HttpPost]
        public async Task<string> Create3DObject([FromBody]dynamic model)
        {
            try
            {
                return await Task.Factory.StartNew(() => _threedimpl.Create3DObject(model.authenticationCookie.ToString(), ParseTools.ToObject<QueryOptions>(model.options), model.id.ToString(), int.Parse(model.renderingType.ToString()), ParseTools.ToObject<ExtraOptions>(model.extraOptions)));
            }
            catch (Exception ex)
            {
                throw Error(ex);
            }
        }

        [Route("Update3DSettings")]
        [HttpPost]
        public async Task<bool> Update3DSettings([FromBody]dynamic model)
        {
            try
            {
                return await Task.Factory.StartNew(() => _threedimpl.Update3DSettings(model.authenticationCookie.ToString(), model.id.ToString(), model.options.ToString()));
            }
            catch (Exception ex)
            {
                throw Error(ex);
            }
        }

        [Route("Get3DSettings")]
        [HttpPost]
        public async Task<string> Get3DSettings([FromBody]dynamic model)
        {
            try
            {
                return await Task.Factory.StartNew(() => _threedimpl.Get3DSettings(model.authenticationCookie.ToString(), model.id.ToString(), model.options.ToString()));
            }
            catch (Exception ex)
            {
                throw Error(ex);
            }
        }

        [Route("CheckProgress")]
        [HttpPost]
        public async Task<string> CheckProgress([FromBody]dynamic model)
        {
            try
            {
                return await Task.Factory.StartNew(() => _threedimpl.CheckProgress(model.authenticationCookie.ToString(), model.id.ToString()));
            }
            catch (Exception ex)
            {
                throw Error(ex);
            }
        }

        [Route("KeepAlive")]
        [HttpPost]
        public async Task<bool> KeepAlive([FromBody]dynamic model)
        {
            try
            {
                return await Task.Factory.StartNew(() => _threedimpl.KeepAlive(model.authenticationCookie.ToString(), model.id.ToString()));
            }
            catch (Exception ex)
            {
                throw Error(ex);
            }
        }

        [Route("GetMPRImage")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetMPRImage([FromUri]string auth, [FromUri]string id, [FromUri]int mprType, [FromUri]int index)
        {
            try
            {
                var result = await Task.Factory.StartNew(() => _threedimpl.GetMPRImage(auth, id, mprType, index));
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StreamContent(result);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return response;
            }
            catch (Exception ex)
            {
                throw Error(ex);
            }
        }
    }
}
