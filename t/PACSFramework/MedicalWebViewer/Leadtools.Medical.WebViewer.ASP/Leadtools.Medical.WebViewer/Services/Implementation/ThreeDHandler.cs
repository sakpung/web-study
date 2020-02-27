// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.Common;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Services.Interfaces;

using System;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Configuration;


namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   public class ThreeDHandler : IThreeDHandler
   {
      private Lazy<IQueryAddin> _queryAddin;
      private Lazy<IObjectRetrieveAddin> _ret;

      static int MaxConcurrentUsers = 20;
      static SemaphoreSlim _create3dSemaphore = null;

      static ThreeDHandler()
      {
         if (!int.TryParse(ConfigurationManager.AppSettings.Get("Medical3D.MaxConcurrentUsers"), out MaxConcurrentUsers))
         {
            MaxConcurrentUsers = 20;
         }
         MaxConcurrentUsers = Math.Min(100, Math.Max(1, MaxConcurrentUsers));
         _create3dSemaphore = new SemaphoreSlim(MaxConcurrentUsers, MaxConcurrentUsers);
      }

      public ThreeDHandler(AddinsFactory factory)
      {
         _queryAddin = new Lazy<IQueryAddin>(() => { return factory.CreateQueryAddin(); });
         _ret = new Lazy<IObjectRetrieveAddin>(() => { return factory.CreateRetrieveAddin(); });
      }

      public string CheckProgress(string authenticationCookie, string id)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         _queryAddin.Value.LockTimeOut(id);

         try
         {
            return _queryAddin.Value.CheckProgress(id/*stackInstanceUID*/);
         }
         finally
         {
            _queryAddin.Value.UnlockTimeOut(id);
         }
      }
            
      public string Create3DObject(string authenticationCookie, QueryOptions options, string id, int renderingType, ExtraOptions extraOptions)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         int MaxQueryResults = 0;
         if (extraOptions != null && extraOptions.UserData != null)
         {
            MaxQueryResults = Convert.ToInt32(extraOptions.UserData);
         }

         bool lightQuery = extraOptions != null && extraOptions.UserData2 != null ? (extraOptions.UserData2 == "lightQuery") : false;
         bool noSort = extraOptions != null && extraOptions.UserData3 != null ? (extraOptions.UserData3 == "NoSort") : false;
         string stackInstanceUID = !lightQuery && extraOptions != null && extraOptions.UserData2 != null ? extraOptions.UserData2 : string.Empty;

         _queryAddin.Value.Initialize3DObject(id);//embedded lock timeout
         
         try
         {
            var t = new Task(() =>
            {
               _create3dSemaphore.Wait();

               if (!_queryAddin.Value.ItemExists(id))
               {                  
                  return;
               }

               try
               {
                  _queryAddin.Value.Start3DObject(userName, options, LTCachingCtrl.CacheSettings.Enabled, Path.Combine(LTCachingCtrl.CacheSettings.Storage, "Cache3D"), id, stackInstanceUID, renderingType);
               }
               finally
               {
                  _queryAddin.Value.UnlockTimeOut(id);
                  _create3dSemaphore.Release();
               }
            });
            t.Start();
         }
         finally
         {            
         }
         //we don't want to run on the iis tasks pool, because it will block other threads from running
            
         return "Success";
      }

      public bool End3DObject(string authenticationCookie, string id)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);
         
         try
         {
            _queryAddin.Value.LockTimeOut(id);

            _queryAddin.Value.End3DObject(id);
         }
         finally
         {
            _queryAddin.Value.UnlockTimeOut(id);
            
         }
         return true;  
      }
        public Stream GetPanoramicImage(string authenticationCookie, string id, int resizeFactor, string polygonInfo, string polygonData)
        {
            //lock object for not to time out
            _queryAddin.Value.LockTimeOut(id);

            try
            {
                return _queryAddin.Value.GetPanoramicImage(id, resizeFactor, polygonInfo, polygonData);
            }
            finally
            {
                _queryAddin.Value.UnlockTimeOut(id);
            }
        }

        public Stream Get3DImage(string authenticationCookie, string id, int x, int y, int width, int height, int resizeFactor, string effect, int action, float sensitivity, float resizeRatio)
        {
            //lock object for not to time out
            _queryAddin.Value.LockTimeOut(id);
         
         try
         {
            return _queryAddin.Value.Get3DImage(id, x, y, width, height, resizeFactor, effect, action, sensitivity, resizeRatio);
         }
         finally
         {
            _queryAddin.Value.UnlockTimeOut(id);
         }
      }

      public string Get3DSettings(string authenticationCookie, string id, string options)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         _queryAddin.Value.LockTimeOut(id);

         try
         {
            return _queryAddin.Value.Get3DSettings(id, options);
         }
         finally
         {
            _queryAddin.Value.UnlockTimeOut(id);
         }
      }

      public bool KeepAlive(string authenticationCookie, string id)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         _queryAddin.Value.KeepAlive(id/*stackInstanceUID*/);

         return true;
      }

      public bool Update3DSettings(string authenticationCookie, string id, string options)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         _queryAddin.Value.LockTimeOut(id);

         try
         {
            _queryAddin.Value.Update3DSettings(id, options);
         }
         finally
         {
            _queryAddin.Value.UnlockTimeOut(id);
         }

         return true;
      }

      public Stream GetMPRImage(string authenticationCookie, string id, int mprType, int index)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanRetrieve);

         _queryAddin.Value.LockTimeOut(id);

         try
         {
            return _ret.Value.GetMPRImage(id, mprType, index);
         }
         finally
         {
            _queryAddin.Value.UnlockTimeOut(id);
         }
      }
   }
}
