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

namespace Leadtools.Medical.WebViewer.Wcf
{
   /// <summary>
   /// the service query the local database for DICOM information, it mostly delegate all functionality to the IQueryAddin after checking if the user is authenticated and authorized.
   /// </summary>
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   [WebService(Namespace = "http://leadtools.com/" )]
   public class ObjectQueryService : IObjectQueryService
   {
      IQueryAddin _queryAddin ;

      public ObjectQueryService ( ) 
      {
         _queryAddin = AddinsFactory.CreateQueryAddin();
      }
      
      
      #region IQueryService

      public PatientData[] FindPatients(string authenticationCookie, DataContracts.QueryOptions options,  DataContracts.ExtraOptions extraOptions)
      {
         string userName ;

         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         int MaxQueryResults =0;
         if (extraOptions != null && extraOptions.UserData != null)
         {
            MaxQueryResults = Convert.ToInt32(extraOptions.UserData);
         }
         return _queryAddin.FindPatients(userName, options, MaxQueryResults);
      }

      public StudyData[] FindStudies(string authenticationCookie, DataContracts.QueryOptions options,  DataContracts.ExtraOptions extraOptions)
      {
         string userName ;
         
         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         int MaxQueryResults = 0;
         if (extraOptions != null && extraOptions.UserData != null)
         {
            MaxQueryResults = Convert.ToInt32(extraOptions.UserData);
         }

         var readModalitiesInStudy = false;
           if (extraOptions != null)
              if (extraOptions.UserData2 != null)
                 if (extraOptions.UserData2.ToLower() == "readmodalitiesinstudy") { readModalitiesInStudy = true; }

           return _queryAddin.FindStudies(userName, options, MaxQueryResults, readModalitiesInStudy);
      }

      public SeriesData[] FindSeries(string authenticationCookie, DataContracts.QueryOptions options,  DataContracts.ExtraOptions extraOptions)
      {
         string userName ;
         
         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         int MaxQueryResults = 0;
         if (extraOptions != null && extraOptions.UserData != null)
         {
            MaxQueryResults = Convert.ToInt32(extraOptions.UserData);
         }

          bool lightQuery = extraOptions != null && extraOptions.UserData2 != null ? (extraOptions.UserData2 == "lightQuery") : false;

          return _queryAddin.FindSeries(userName, options, MaxQueryResults, lightQuery);
      }

      public InstanceData[] FindInstances(string authenticationCookie, DataContracts.QueryOptions options,  DataContracts.ExtraOptions extraOptions)
      {
         string userName ;


         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         int MaxQueryResults = 0;
         if (extraOptions != null && extraOptions.UserData != null)
         {
            MaxQueryResults = Convert.ToInt32(extraOptions.UserData);
         }

         bool lightQuery = extraOptions != null && extraOptions.UserData2 != null ? (extraOptions.UserData2 == "lightQuery") : false;
         bool noSort = extraOptions != null && extraOptions.UserData3 != null ? (extraOptions.UserData3 == "NoSort") : false;
         string stackInstanceUID = !lightQuery && extraOptions != null && extraOptions.UserData2 != null ? extraOptions.UserData2 : string.Empty;

         return _queryAddin.FindInstances(userName, options, MaxQueryResults, lightQuery, noSort, stackInstanceUID);
      }

      public PresentationStateData[] FindPresentationState (string authenticationCookie, string referencedSeries,  string userData) 
      {
         string userName ;


         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         WebOperationContext.Current.OutgoingResponse.Headers.Add ( "Cache-Control", "must-revalidate, max-age=0" ) ;
         
         return _queryAddin.FindPresentationState ( userName, referencedSeries, userData) ;
      }

      public bool HasPresentationState(string authenticationCookie, string seriesInstanceUID, string sopInstanceUID, string userData)
      {
         string userName;


         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         return _queryAddin.HasPresentationState(userName, seriesInstanceUID, sopInstanceUID, userData);
      }     

      private static int CompareFunc(InstanceData x, InstanceData y)
      {
         if (x.InstanceNumber == null)
         {
            if (y==null || y.InstanceNumber == null)
            {
               return 0;
            }
            else
            {
               return -1;
            }
         }
         else
         {
            if (y==null || y.InstanceNumber == null)
            {
               return 1;
            }
            else
            {
               int retval = x.InstanceNumber.Length.CompareTo(y.InstanceNumber.Length);

               if (retval != 0)
               {
                  return retval;
               }
               else
               {
                  return x.InstanceNumber.CompareTo(y.InstanceNumber);
               }
            }
         }
      }
      
      public DICOMQueryResult ElectStudyTimeLineInstances(string authenticationCookie, QueryOptions options, ExtraOptions _extraOptions)
      {
         string userName ;
         
         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         return _queryAddin.ElectStudyTimeLineInstances(userName, options, authenticationCookie);
      }
    
      public WordResult[] AutoComplete(string authenticationCookie, string key, string term, string userData)
      {
         string userName;


         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         return _queryAddin.AutoComplete(userName, key, term, userData);
      }

        #endregion

#if (LEADTOOLS_V19_OR_LATER)
        public HangingProtocolQueryResult[] FindHangingProtocols(string authenticationCookie, string studyInstanceUID, string userData)
        {
            string userName;


            userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

            return _queryAddin.FindHangingProtocols(userName, studyInstanceUID, userData);
        }
#endif
    }
}
