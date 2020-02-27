// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.DataContracts;
using System.ServiceModel.Activation;
using Leadtools.Medical.WebViewer.Addins;
using Leadtools.Dicom;
using System.Configuration;
using Leadtools.Medical.WebViewer.Wcf.Helper;

namespace Leadtools.Medical.WebViewer.Wcf
{
   /// <summary>
   /// query remote PACS for DICOM information (Patient, Study, series and instance level).
   /// Mostly delegates all functionality to the PACS Query Addin after authentication and authorization
   /// </summary>
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class PacsQueryService : IPACSQueryService
   {
      public PacsQueryService ( ) 
      {
      }

      #region IPACSQueryService

      public PACSConnection[] GetConnectionInfo()
      {
         return new PACSConnection[] { AddinsFactory.ClientConnection, AddinsFactory.StorageServerConnection };
      }

      public PatientData[] FindPatients(string authenticationCookie, DataContracts.PACSConnection server, DataContracts.ClientConnection client, DataContracts.QueryOptions options,  DataContracts.ExtraOptions extraOptions)
      {
         ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQueryPACS);

         return AddinsFactory.CreatePacsQueryAddin ( ).FindPatients ( server, client, options ) ;
      }

      public StudyData[] FindStudies(string authenticationCookie, DataContracts.PACSConnection server, DataContracts.ClientConnection client, DataContracts.QueryOptions options,  DataContracts.ExtraOptions extraOptions)
      {
         ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQueryPACS);

         return AddinsFactory.CreatePacsQueryAddin ( ).FindStudies ( server, client, options ) ;
      }

      public SeriesData[] FindSeries(string authenticationCookie, DataContracts.PACSConnection server, DataContracts.ClientConnection client, DataContracts.QueryOptions options,  DataContracts.ExtraOptions extraOptions)
      {
         ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQueryPACS);

         return AddinsFactory.CreatePacsQueryAddin ( ).FindSeries ( server, client, options ) ;
      }

      public InstanceData[] FindInstances(string authenticationCookie, DataContracts.PACSConnection server, DataContracts.ClientConnection client, DataContracts.QueryOptions options,  DataContracts.ExtraOptions extraOptions)
      {
         ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanQueryPACS);

         return AddinsFactory.CreatePacsQueryAddin ( ).FindInstances ( server, client, options ) ;
      }

      public string VerifyConnection(string authenticationCookie, PACSConnection server, ClientConnection client, ExtraOptions extraOptions)
      {
          ServiceUtils.Authenticate(authenticationCookie);          

          return AddinsFactory.CreatePacsQueryAddin().VerifyConnection(server, client);
      }

      private static int CompareFunc(InstanceData x, InstanceData y)
      {
         if (x.InstanceNumber == null)
         {
            if (y.InstanceNumber == null)
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
            if (y.InstanceNumber == null)
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

      public DICOMQueryResult ElectStudyTimeLineInstances(string authenticationCookie, PACSConnection server, ClientConnection client, QueryOptions options, ExtraOptions extraOptions)
      {
         DICOMQueryResult result = new DICOMQueryResult();

         StudyData[] StudiesDataArray = FindStudies(authenticationCookie, server, client, options, extraOptions);
         result.Studies = StudiesDataArray;

         SeriesData[] SeriesDataArray = FindSeries(authenticationCookie, server, client, options, extraOptions);

         result.Series = SeriesDataArray;

         List<InstanceData> AvailableInstancesList = new List<InstanceData>();

         if (null == options.SeriesOptions)
            options.SeriesOptions = new SeriesQueryOptions();

         foreach (SeriesData series in SeriesDataArray)
         {
            options.SeriesOptions.SeriesInstanceUID = series.InstanceUID;
            InstanceData[] objectsFound = FindInstances(authenticationCookie, server, client, options, extraOptions);
            if (objectsFound.Length > 0)
            {
               Array.Sort<InstanceData>(objectsFound, CompareFunc);

               if (string.IsNullOrEmpty(objectsFound[0].SeriesInstanceUID))
                  objectsFound[0].SeriesInstanceUID = series.InstanceUID;

               AvailableInstancesList.Add(objectsFound[0]);
            }
         }

         result.Instances = AvailableInstancesList.ToArray();

         return result;
      }      

      #endregion
   }
}
