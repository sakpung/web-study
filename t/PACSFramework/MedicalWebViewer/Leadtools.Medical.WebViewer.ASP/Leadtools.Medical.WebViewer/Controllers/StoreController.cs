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
using Leadtools.Medical.WebViewer.Core.DataTypes;
using Newtonsoft.Json.Linq;

namespace Leadtools.Medical.WebViewer.Controllers
{
   [RoutePrefix("api/store")]
   public class StoreController : ApiController
   {
      private IStoreHandler _impl;
      public StoreController(IStoreHandler impl)
      {
         _impl = impl;
      }

      [Route("ping")]
      [HttpGet]
      public HttpResponseMessage ping()
      {
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
         response.Content = new StringContent("Leadtools Medical Services - Store", Encoding.Unicode);
         return response;
      }

      Exception Error(Exception e)
      {
         var message = string.Format(e.Message + "\r\n" + e.StackTrace);
         var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
         throw new HttpResponseException(errorResponse);
      }

      [Route("StoreSecondaryCapture")]
      [HttpPost]
      public SeriesData StoreSecondaryCapture([FromBody]dynamic model)
      {
         return _impl.StoreSecondaryCapture((string)model.authenticationCookie, (string)model.EncodedCapture, (string)model.OriginalSOPInstance, (string)model.SeriesNumber, (string)model.SeriesDescription, (string)model.ProtocolName);
      }

      [Route("StoreAnnotations")]
      [HttpPost]
      public PresentationStateData StoreAnnotations([FromBody]dynamic model)
      {
         return _impl.StoreAnnotations((string)model.authenticationCookie, (string)model.seriesInstanceUID, (string)model.annotationData, (string)model.description, (string)model.userData);
      }

      [Route("UploadDicomImage")]
      [HttpPost]
      public string UploadDicomImage([FromBody]dynamic model)
      {
         return _impl.UploadDicomImage((string)model.authenticationCookie, (string)model.dicomData, (string)model.status, (string)model.fileName);
      }

      [Route("DeletePresentationState")]
      [HttpPost]
      public void DeletePresentationState([FromBody]dynamic model)
      {
         _impl.DeletePresentationState((string)model.authenticationCookie, (string)model.sopInstanceUID, (string)model.userData);
      }

      [Route("StoreImage")]
      [HttpPost]
      public StoreStatus_Json StoreImage([FromBody]dynamic model)
      {
         return _impl.StoreImage((string)model.authenticationCookie, (int)model.formatCode, (string)model.imageData, (string)model.userData);
      }


      [Route("StoreStudyLayout")]
      [HttpPost]
      public void StoreStudyLayout([FromBody]dynamic model)
      {
         _impl.StoreStudyLayout((string)model.authenticationCookie, (string)model.studyInstanceUID, model.studyLayout.ToObject<StudyLayout>(), (string)model.userData);
      }

      [Route("DeleteStudyLayout")]
      [HttpPost]
      public void DeleteStudyLayout([FromBody]dynamic model)
      {
         _impl.DeleteStudyLayout((string)model.authenticationCookie, (string)model.studyInstanceUID, (string)model.userData);
      }

      [Route("StoreHangingProtocol")]
      [HttpPost]
      public void StoreHangingProtocol([FromBody]dynamic model)
      {
         _impl.StoreHangingProtocol((string)model.authenticationCookie, model.hangingProtocol.ToObject<WCFHangingProtocol>(), (string)model.userData);
      }

   }
}
