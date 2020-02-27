// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.WebViewer.Errors;
using Leadtools.Medical.Winforms.ExternalStore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Leadtools.Medical.WebViewer.Common
{
   internal class ExternalStorage
   {
      public static void Startup()
      {

      }

      static ExternalStorage()
      {

         AdvancedSettings _Settings = null;
         List<Type> _extraTypeList = new List<Type>();
         const string _Name = "ExternalStore";
         ExternalStoreOptions _Options = null;

         if (_Settings == null)
         {
            try
            {
               string storageServerServicePath = ConfigurationManager.AppSettings.Get("storageServerServicePath");
               if (Directory.Exists(storageServerServicePath))
               {
                  storageServerServicePath = ServiceUtils.MapConfigPath(storageServerServicePath);
                  _Settings = AdvancedSettings.Open(storageServerServicePath);
                  _Settings.RefreshSettings();
               }
            }
            catch (System.Configuration.ConfigurationErrorsException)
            {
               // This can occur when connection a v19 HTML Medical Web Viewer to a v18 CSStorageServerManager.exe database
               // The v18 CSStorageServerManager.exe does not have support for external store
            }
            catch (Exception e)
            {
               throw new ServiceException("Possible invalid storageServerServicePath specified. " + e.Message);
            }

            if (_Settings != null)
            {
               _Options = _Settings.GetAddInCustomData<ExternalStoreOptions>(_Name, "ExternalStoreOptions", _extraTypeList.ToArray());
            }
            if (_Options == null)
            {
               _Options = new ExternalStoreOptions();
            }

            _Options.RegisterAllExternalStoreAddins();

            ExternalStoreItem item = _Options.GetCurrentOption();
            if (item != null)
            {
               ICrud crud = item.ExternalStoreAddinConfig.GetCrudInterface();
               DataAccessServiceLocator.Register<ICrud>(crud);
               DataAccessServiceLocator.Register<ICrud>(crud, crud.ExternalStoreGuid);
            }
            else
            {
               DataAccessServiceLocator.Register<ICrud>(new DefaultCrud());
            }


         }
      }
   }
}
