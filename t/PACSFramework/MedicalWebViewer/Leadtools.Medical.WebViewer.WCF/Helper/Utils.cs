// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
//#define FOR_DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.ServiceContracts;
using System.Net;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using System.Configuration;
using Leadtools.Medical.DataAccessLayer.Configuration;
using System.Web;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Interface;
using Leadtools.Medical.Storage.DataAccessLayer;
using System.Management;
using System.Web.Hosting;

#if TUTORIAL_CUSTOM_DATABASE
using My.Medical.Storage.DataAccessLayer;
using My.Medical.Storage.DataAccessLayer.Entities;
#endif

namespace Leadtools.Medical.WebViewer.Wcf.Helper
{
   /// <summary>
   /// Utilities class
   /// </summary>
   class ServiceUtils
   {
      internal static string GetLocalIPAddressesV4_mgmt()
      {
         try
         {
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
            ManagementObjectCollection queryCollection = query.Get();

            foreach (ManagementObject mo in queryCollection)
            {
               if (queryCollection.Count > 0)
               {
                  string[] addresses = (string[])mo["IPAddress"];

                  foreach (string ip in addresses)
                  {
                     if (!ip.Contains(":") && (ip != "0.0.0.0"))
                        return ip;
                  }
               }
            }
         }
         catch
         {
         }

         return string.Empty;
      }

      internal static string GetLocalIPAddressesV4_dns()
      {
         var localAddresses = Dns.GetHostAddresses(Dns.GetHostName());

         foreach (var localAddress in localAddresses)
         {
            if (localAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
               return localAddress.ToString();
            }
         }

         return string.Empty;
      }

      /// <summary>
      /// returns first local IP address
      /// </summary>
      /// <returns></returns>
      public static string GetLocalIPAddressesV4()
      {
         var ip = GetLocalIPAddressesV4_dns();
         if (string.IsNullOrEmpty(ip))
         {
            ip = GetLocalIPAddressesV4_mgmt();
         }
         return ip;
      }

      /// <summary>
      /// returns an available IP port, currently hard-coded
      /// </summary>
      /// <returns></returns>
      public static int GetFreeIPPort()
      {
         return 1000;
      }

      public static int ToInt(string str, int alt)
      {
         if (!string.IsNullOrEmpty(str))
         {
            int n = -1;

            if (int.TryParse(str, out n))
            {
               return n;
            }
         }
         return alt;
      }

      /// <summary>
      /// Checks the authentication cookie and extract/returns the user name. If user is not authenticated it throws the appropriate exception
      /// </summary>
      /// <param name="authenticationService"></param>
      /// <param name="authenticationCookie"></param>
      /// <param name="userName"></param>
      /// <param name="extraOptions"></param>
      internal static void Authenticate ( IAuthenticationAddin authenticationService, string authenticationCookie, out string userName, ExtraOptions extraOptions)
      {
         AuthenticationInfo info = null ;

         try
         {
            info = authenticationService.GetAuthenticationInfo ( authenticationCookie, null ) ;
         }
         catch ( Exception ex ) 
         {
            throw new ServiceAuthenticationException ( ex.Message ) ;
         }

         userName = "" ;

         if ( null != info ) 
         {
            userName = info.UserName ;

            if ( authenticationService.IsTimedOut ( info, null ) )
            {
               throw new ServiceAuthenticationException ( "Timed-out" ) ;
            }
         }
         else
         {
            throw new ServiceAuthenticationException ( "Not Authenticated" ) ;
         }

      }


      /// <summary>
      /// Checks if the user has permission to perform an operation and throws exception if not.
      /// </summary>
      /// <param name="authenticationService"></param>
      /// <param name="userName"></param>
      /// <param name="permission"></param>
      /// <param name="extraOptions"></param>
      internal static void Authorize(IAuthenticationAddin authenticationService, string userName, Permission permission, ExtraOptions extraOptions)
      {
         if (!authenticationService.HasPermission(userName, permission.Name, null))
         {
            throw new ServiceAuthorizationException ( "Not enough permissions." ) ;
         }
      }

      internal static string Authenticate(string authenticationCookie)
      {
         AuthenticationInfo ai = null;
         var srv = AddinsFactory.CreateSessionAuthenticationAddin();

         try
         {
            ai = srv.GetAuthenticationInfo(authenticationCookie);
         }
         catch (Exception ex)
         {
            throw new ServiceAuthenticationException(ex.Message);
         }

         if (srv.IsTimedOut(ai))
         {
            throw new ServiceAuthenticationException("Timed-out");
         }

         return ai.UserName;
      }
      internal static string Authorize(string authenticationCookie, Permission permission)
      {
         AuthenticationInfo ai = null;
         var srv = AddinsFactory.CreateSessionAuthenticationAddin();

         try
         {            
            ai = srv.GetAuthenticationInfo(authenticationCookie);
         }
         catch ( Exception ex ) 
         {
            throw new ServiceAuthenticationException ( ex.Message ) ;
         }

         if(srv.IsTimedOut (ai))
         {
            throw new ServiceAuthenticationException ( "Timed-out" ) ;
         }

         if(!srv.HasPermission(ai, permission))         
         {
            throw new ServiceAuthenticationException ( "Not Authenticated" ) ;
         }

         //passed
         return ai.UserName;
      }
       public static string MapConfigPath(string path)
      {
         if (!string.IsNullOrEmpty(path))
         {
            if (path.ToLower().StartsWith("app_data"))
            {
               path = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, path);
            }
         }
         return path;
      }
               
      /// <summary>
      /// Gets the configuration object for the toolkit PACS config file that defines the DALs. 
      /// </summary>
      /// <returns></returns>
      public static Configuration GetGlobalPacsConfig ( ) 
      {
         string globalPacsFile = ConfigurationManager.AppSettings["globalConfigPath"] ;
         globalPacsFile = MapConfigPath(globalPacsFile);

         ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
         configFile.ExeConfigFilename = globalPacsFile;
         configFile.MachineConfigFilename = globalPacsFile;

         return ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
      }

      public static string ProductNameStorageServer
      {
         get
         {
            return "StorageServer";
         }
      }

      public static string ProductNameMedicalViewer
      {
         get
         {
            return "MedicalViewer";
         }
      }
      
      /// <summary>
      /// Not used for now but can be enabled to debug the service.
      /// </summary>
      /// <param name="message"></param>
      public static void Log ( string message ) 
      {
         //string dir = HttpContext.Current.Server.MapPath("."); 
         
         //string globalPacsFile = Path.Combine ( dir, "log.txt" );

         //FileStream fs = new FileStream ( globalPacsFile, FileMode.Append, FileAccess.Write ) ;

         //try
         //{
         //   byte [] buffer = Encoding.ASCII.GetBytes ( "\n\r" + message ) ;
         //   fs.Write ( buffer, 0, buffer.Length ) ;
         //}
         //finally
         //{
         //   fs.Close ( ) ;
         //}
      }

      public static void RegisterInterfaces()
      {
#if TUTORIAL_CUSTOM_DATABASE
         // The 'RegisterInterfaces' method is implemented as part of the "Changing the LEAD HTML5 Medical Viewer to use a different database schema" tutorial.
         // For the tutorial, 'RegisterInterfaces' is used to register custom classes that you define to interact with a custom database.
         // For the shipping version, the 'RegisterInterfaces' does nothing
         // 
         // Since the WCF services are stateless (below), this method is called before using any of the services.
         // The AddinsFactory class is used to generate the addins required by each of the services.
         // So the AddinsFactory constructor calls 'RegisterInterfaces' if it has not already been called.
         //
         // WCF Services:
         // * AuthenticationService
         // * ObjectRetrieveService
         // * PacsQueryService
         // * PACSRetrieveService
         // * StoreService
         // 
         // The MyPatientInfo, MyStudyInfo, MySeriesInfo, and MyInstanceInfo classes are used for extracting DICOM data from a System.Data.DataRow.
         // The MyStorageSqlDbDataAccessAgent and MyStorageDataAccessConfigurationView classes are used for accessing your custom database
         // The MyPatient, MyStudy, MySeries, and MyInstance classes are used to generate the WHERE statement of the database query
         // For more details, see the "Changing the LEAD HTML5 Medical Viewer to use a different database schema" tutorial.

         if (!DataAccessServiceLocator.IsRegistered<IPatientInfo>())
         {
            DataAccessServiceLocator.Register<IPatientInfo>(new MyPatientInfo());
         }

         if (!DataAccessServiceLocator.IsRegistered<IStudyInfo>())
         {
            DataAccessServiceLocator.Register<IStudyInfo>(new MyStudyInfo());
         }

         if (!DataAccessServiceLocator.IsRegistered<ISeriesInfo>())
         {
            DataAccessServiceLocator.Register<ISeriesInfo>(new MySeriesInfo());
         }

         if (!DataAccessServiceLocator.IsRegistered<IInstanceInfo>())
         {
            DataAccessServiceLocator.Register<IInstanceInfo>(new MyInstanceInfo());
         }

         if (!DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent3>())
         {
            System.Configuration.Configuration configuration = ServiceUtils.GetGlobalPacsConfig();
            IStorageDataAccessAgent3 storageDataAccess = DataAccessFactory.GetInstance(new MyStorageDataAccessConfigurationView(configuration, ServiceUtils.ProductNameStorageServer, null)).CreateDataAccessAgent<IStorageDataAccessAgent3>();
            DataAccessServices.RegisterDataAccessService<IStorageDataAccessAgent3>(storageDataAccess);
         }

         RegisteredEntities.AddItem(RegisteredEntities.PatientEntityName, typeof(MyPatient));
         RegisteredEntities.AddItem(RegisteredEntities.StudyEntityName, typeof(MyStudy));
         RegisteredEntities.AddItem(RegisteredEntities.SeriesEntityName, typeof(MySeries));
         RegisteredEntities.AddItem(RegisteredEntities.InstanceEntityName, typeof(MyInstance));
#endif
      }
   }


   public class ServiceException : Exception
   {
      public ServiceException ( string message, HttpStatusCode errorCode ) : 
      base ( message ) 
      {
         Status = errorCode ;
      }

      public HttpStatusCode Status 
      { 
         get ;
         private set ; 
      } 
   }

   public class ServiceAuthenticationException : ServiceException
   {
      public ServiceAuthenticationException ( string message  ) : 
      base ( message, HttpStatusCode.Unauthorized ) 
      {
         
      }
   }

   public class ServiceAuthorizationException : ServiceException
   {
      public ServiceAuthorizationException ( string message  ) : 
      base ( message, HttpStatusCode.Forbidden ) 
      {
         
      }
   }
}
