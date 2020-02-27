// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.DataContracts;
using System.ServiceModel.Activation;
using Leadtools.Medical.WebViewer.Addins;
using System.Web.Services;
using System.Configuration;
using Leadtools.Medical.WebViewer.Wcf.Helper;
using System.ServiceModel.Web;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;
using System.Threading.Tasks;
using System.Threading;

namespace Leadtools.Medical.WebViewer.Wcf
{
   /// <summary>
   /// the service query the local database for DICOM information, it mostly delegate all functionality to the IQueryAddin after checking if the user is authenticated and authorized.
   /// </summary>
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   [WebService(Namespace = "http://leadtools.com/" )]
   public class ThreeDService : IThreeDService
   {
      IQueryAddin _queryAddin ;

      static int MaxConcurrentUsers = 20;
      static Semaphore _create3dSemaphore = new Semaphore(MaxConcurrentUsers, MaxConcurrentUsers);
      static ThreeDService()
      {
         if (!int.TryParse(ConfigurationManager.AppSettings.Get("Medical3D.MaxConcurrentUsers"), out MaxConcurrentUsers))
         {
            MaxConcurrentUsers = 20;
         }
         MaxConcurrentUsers = Math.Min(100, Math.Max(1, MaxConcurrentUsers));
      }

      public ThreeDService( ) 
      {
         _queryAddin = AddinsFactory.CreateQueryAddin();
      }

      public Stream Get3DImage(string authenticationCookie, string id, int x, int y, int width, int height, int resizeFactor, string effect, int action, float sensitivity, float resizeRatio)
      {
         _queryAddin.LockTimeOut(id);
         try
         {
            if (null != WebOperationContext.Current)
            {
               WebOperationContext.Current.OutgoingResponse.ContentType = SupportedMimeTypes.JPG;
               WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Disposition", string.Format("attachment; filename={0}.jpg", id.ToString()));
            }

            Stream stream = _queryAddin.Get3DImage(id, x, y, width, height, resizeFactor, effect, action, sensitivity, resizeRatio);

            if ((null != WebOperationContext.Current) && (null != stream))
            {
               WebOperationContext.Current.OutgoingResponse.ContentLength = stream.Length;
            }

            return stream;
         }
         finally
         {
            _queryAddin.UnlockTimeOut(id);
         }
      }

      public void End3DObject(string authenticationCookie, string stackInstanceUID)
      {
         string userName;

         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         _queryAddin.LockTimeOut(stackInstanceUID);
         try
         {
            _queryAddin.End3DObject(stackInstanceUID);
         }
         finally
         {
            _queryAddin.UnlockTimeOut(stackInstanceUID);
         }         
      }


      public string CheckProgress(string authenticationCookie, string stackInstanceUID)
      {
         string userName;

         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         _queryAddin.LockTimeOut(stackInstanceUID);
         try
         {
            return _queryAddin.CheckProgress(stackInstanceUID); 
         }
         finally
         {
            _queryAddin.UnlockTimeOut(stackInstanceUID);
         }         
      }

      public void KeepAlive(string authenticationCookie, string stackInstanceUID)
      {
         string userName;

         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         _queryAddin.KeepAlive(stackInstanceUID);
      }


      public string Create3DObject(string authenticationCookie, QueryOptions options, string id, int renderingType, ExtraOptions extraOptions)
      {
         string userName;


         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         int MaxQueryResults = 0;
         if (extraOptions != null && extraOptions.UserData != null)
         {
            MaxQueryResults = Convert.ToInt32(extraOptions.UserData);
         }

         bool lightQuery = extraOptions != null && extraOptions.UserData2 != null ? (extraOptions.UserData2 == "lightQuery") : false;
         bool noSort = extraOptions != null && extraOptions.UserData3 != null ? (extraOptions.UserData3 == "NoSort") : false;
         string stackInstanceUID = !lightQuery && extraOptions != null && extraOptions.UserData2 != null ? extraOptions.UserData2 : string.Empty;

         _queryAddin.Initialize3DObject(id);//embedded lock timeout

         var Enabled = LTCachingCtrl.CacheSettings.Enabled;
         var Storage = Path.Combine(LTCachingCtrl.CacheSettings.Storage, "Cache3D");
         
         Task.Factory.StartNew<string>(() =>
         {
            if (!_create3dSemaphore.WaitOne())
               return "Error waiting";
            _queryAddin.LockTimeOut(id);
            try
            {
               return _queryAddin.Start3DObject(userName, options, Enabled, Storage, id, stackInstanceUID, renderingType); ;
            }
            catch (Exception )
            {
               throw;
            }
            finally
            {
               _queryAddin.UnlockTimeOut(id);
               _create3dSemaphore.Release();
            }
         }, TaskCreationOptions.LongRunning
         ).ContinueWith((t) => { if (t.IsFaulted) System.Diagnostics.Debug.WriteLine("lt: thread: " + t.Exception.Message); });

         _queryAddin.UnlockTimeOut(id);

         return "Success";
      }


      public string Get3DSettings(string authenticationCookie, string id, string options)
      {
         string userName;

         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         _queryAddin.LockTimeOut(id);
         try
         {
            return _queryAddin.Get3DSettings(id, options);
         }
         finally
         {
            _queryAddin.UnlockTimeOut(id);
         }
      }


      public void Update3DSettings(string authenticationCookie, string id, string options)
      {
         string userName;

         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         _queryAddin.LockTimeOut(id);
         try
         {
            _queryAddin.Update3DSettings(id, options);
         }
         finally
         {
            _queryAddin.UnlockTimeOut(id);
         }
      }

      public Stream GetMPRImage(string authenticationCookie, string id, int mprType, int index)
      {
         ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         _queryAddin.LockTimeOut(id);
         try
         {
            var stream = AddinsFactory.CreateObjectRetrieveAddin().GetMPRImage(id, mprType, index);
            WebOperationContext.Current.OutgoingResponse.ContentType = SupportedMimeTypes.PNG;
            return stream;
         }
         finally
         {
            _queryAddin.UnlockTimeOut(id);
         }
      }
    }
}
