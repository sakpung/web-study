// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn ;
using Leadtools.Dicom.Server.Admin ;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.DicomDemos;
using Leadtools.Medical.Worklist.DataAccessLayer ;
using Leadtools.Medical.Worklist.DataAccessLayer.Configuration;
using Leadtools.Dicom.AddIn.Interfaces;
using System.Diagnostics;
using Leadtools.Logging;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn.Common;

namespace Leadtools.Medical.Worklist.AddIns
{
   public partial class AddInsSession : ModuleInit
   {
      public override void Load ( string serviceDirectory, string displayName )
      {
         List <string>        unlockedSerivces ;
         DicomService         service ;         
                  
         InitializeLicense();         
         base.Load ( serviceDirectory, displayName ) ;
         
         unlockedSerivces = new List<string> ( ) ;
         ServiceDirectory = serviceDirectory ;
         DisplayName      = displayName ;
         
         RegisterDataAccessAgents ( displayName ) ;
         
         unlockedSerivces.Add ( displayName ) ;
         
         using ( ServiceAdministrator serviceAdmin = new ServiceAdministrator ( serviceDirectory ) )
         {
            //Add the key
#if LEADTOOLS_V175_OR_LATER
            serviceAdmin.Initialize(unlockedSerivces);
#else
            serviceAdmin.Unlock ( string.Empty, unlockedSerivces ) ;
#endif
            
            if ( serviceAdmin.Services.ContainsKey ( displayName ) )
            {
               service = serviceAdmin.Services [ displayName ] ;
               
               ServerAE      = service.Settings.AETitle ;
               ServerAddress = service.Settings.IpAddress ;
               ServerPort    = service.Settings.Port ;
            }
         }

         if (!AddInsSession.IsLicenseValid())
         {
            DicomServer server = ServiceLocator.Retrieve<DicomServer>();

            Logger.Global.SystemMessage(LogType.Information, "Worklist license not valid.  Worklist search cannot be performed", server.AETitle);            
         }         
      }

      void license_LicenseChanged(object sender, EventArgs e)
      {
         if (!AddInsSession.IsLicenseValid())
         {
            DicomServer server = ServiceLocator.Retrieve<DicomServer>();

            Logger.Global.SystemMessage(LogType.Information, "Worklist license is valid.", server.AETitle);
         }
      }
      
      public static IWorklistDataAccessAgent DataAccess
      {
         get
         {
            return _dataAccess ;
         }
         
         set
         {
            _dataAccess = value ;
         }
      }
      
      
      static void RegisterDataAccessAgents ( string serviceName)
      {
         System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(ServiceDirectory);
         if ( !DataAccessServices.IsDataAccessServiceRegistered <IWorklistDataAccessAgent> ( ) )
         {
            IWorklistDataAccessAgent worklistDataAccess = DataAccessFactory.GetInstance ( new WorklistDataAccessConfigurationView (configuration, null, serviceName) ).CreateDataAccessAgent <IWorklistDataAccessAgent> ( ) ;
            
            DataAccessServices.RegisterDataAccessService <IWorklistDataAccessAgent> ( worklistDataAccess ) ;
            
            DataAccess = worklistDataAccess ;
         }
         else
         {
            DataAccess = DataAccessServices.GetDataAccessService<IWorklistDataAccessAgent>();
         }
      }
      
      public static string ServiceDirectory
      {
         get
         {
            return _serviceDirectory ;
         }
         
         set
         {
            _serviceDirectory = value ;
         }
      }
      
      public static string DisplayName
      {
         get
         {
            return _displayName ;
         }
         
         set
         {
            _displayName = value ;
         }
      }
      
      public static string ServerAE 
      {
         get
         {
            return _serverAE ;
         }
         
         set
         {
            _serverAE = value ;
         }
      }
      
      public static string ServerAddress
      {
         get
         {
            return _serverAddress ; 
         }
         
         set
         {
            _serverAddress = value ;
         }
      }
      
      public static int ServerPort 
      {
         get
         {
            return _serverPort ;
         }
         
         set
         {
            _serverPort = value ;
         }
      }
      
      private static string _serviceDirectory ;
      private static string _displayName ;
      private static string _serverAE ;
      private static string _serverAddress ;
      private static int _serverPort ;
      private static IWorklistDataAccessAgent _dataAccess;
   }

#if LEADTOOLS_V19_OR_LATER
    public class GetInstanceFileName : IProcessServiceMessage
    {
       private const string CanAccessDatabaseMessageId = "7E953C86-243E-475A-8A0C-0AB1A160AD3A";

       #region IProcessServiceMessage Members

       public bool CanProcess(string MessageId)
        {
           return (MessageId == CanAccessDatabaseMessageId);
        }

       public Dicom.AddIn.Common.ServiceMessage Process(Dicom.AddIn.Common.ServiceMessage Message)
       {
          ServiceMessage message = new ServiceMessage();

          if (Message.Message == CanAccessDatabaseMessageId)
          {
             message.Message = message.Message;

             string errorString = string.Empty;
             bool result = CanAccessDatabase(out errorString);
             message.Success = result;
             if (result == false)
             {
                message.Data.Add(errorString);
             }
          }
          return message;
       }

        private static bool CanAccessDatabase(out string errorString)
        {
           bool result = true;
           errorString = string.Empty;

           IWorklistDataAccessAgent agent = null;
           if (DataAccessServices.IsDataAccessServiceRegistered<IWorklistDataAccessAgent>())
           {
              agent = DataAccessServices.GetDataAccessService<IWorklistDataAccessAgent>();
           }
           if (agent == null)
           {
              errorString = "Error: Cannot create IWorklistDataAccessAgent";
              return false;
           }

           try
           {
              agent.GetPatientIDs();
           }
           catch (Exception ex)
           {
              errorString = ex.Message;
              result = false;
           }
           return result;
        }

       #endregion
    } 
#endif // #if LEADTOOLS_V19_OR_LATER
}
