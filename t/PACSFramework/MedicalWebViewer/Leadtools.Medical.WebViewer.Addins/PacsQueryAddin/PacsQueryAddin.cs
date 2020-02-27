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
using Leadtools.Dicom.Scu;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu.Common;
using System.Net;

namespace Leadtools.Medical.WebViewer.Addins
{
   /// <summary>
   /// Connect to remote PACS to do a query
   /// </summary>
   public class PACSQueryAddin : IPACSQueryAddin
   {
      public PACSConnection LocalClient { get; set; } 

      public PACSQueryAddin ( PACSConnection localClient )
      {
         LocalClient = localClient ;
      }

      /// <summary>
      /// query a DICOM server for instance/image data (Image Level query)
      /// </summary>
      /// <param name="server">remote server info</param>
      /// <param name="client">query client info</param>
      /// <param name="options">query options</param>
      /// <param name="extraOptions">custom data</param>
      /// <returns>returns the found instances </returns>
      public InstanceData[] FindInstances
      (
         PACSConnection server, 
         ClientConnection client, 
         QueryOptions options
      )
      {
         AeInfo scpInfo ;
         AeInfo scuInfo ;

         scpInfo = GetScp ( server ) ;
         scuInfo = GetScu ( client ) ;

         QueryProcessor <InstanceData> query = new QueryProcessor<InstanceData> ( scpInfo, scuInfo ) ;

         return query.DoFind ( GetInstanceQuery ( options ) ) ;
      }

      /// <summary>
      /// query a DICOM server for patient data (Patient Level query)
      /// </summary>
      /// <param name="server">remote server info</param>
      /// <param name="client">query client info</param>
      /// <param name="options">query options</param>
      /// <param name="extraOptions">custom data</param>
      /// <returns>returns the found patients</returns>
      public PatientData[] FindPatients
      (
         PACSConnection server, 
         ClientConnection client, 
         QueryOptions options
      )
      {
         AeInfo scpInfo ;
         AeInfo scuInfo ;

         scpInfo = GetScp ( server ) ;
         scuInfo = GetScu ( client ) ;

         QueryProcessor <PatientData> query = new QueryProcessor<PatientData> ( scpInfo, scuInfo ) ;

         return query.DoFind ( GetPatientQuery ( options ) ) ;
      }

      /// <summary>
      /// query a DICOM server for series data (Series Level query)
      /// </summary>
      /// <param name="server">remote server info</param>
      /// <param name="client">query client info</param>
      /// <param name="options">query options</param>
      /// <param name="extraOptions">custom data</param>
      /// <returns>returns the found Series</returns>
      public SeriesData[] FindSeries
      (
         PACSConnection server, 
         ClientConnection client, 
         QueryOptions options
      )
      {
         AeInfo scpInfo ;
         AeInfo scuInfo ;

         scpInfo = GetScp ( server ) ;
         scuInfo = GetScu ( client ) ;

         QueryProcessor <SeriesData> query = new QueryProcessor<SeriesData> ( scpInfo, scuInfo ) ;

         return query.DoFind ( GetSeriesQuery ( options ) ) ;
      }

      /// <summary>
      /// query a DICOM server for study data (Study Level query)
      /// </summary>
      /// <param name="server">remote server info</param>
      /// <param name="client">query client info</param>
      /// <param name="options">query options</param>
      /// <param name="extraOptions">custom data</param>
      /// <returns>returns the found study </returns>
      public StudyData[] FindStudies
      (  
         PACSConnection server, 
         ClientConnection client, 
         QueryOptions options
      )
      {
         AeInfo scpInfo ;
         AeInfo scuInfo ;

         scpInfo = GetScp ( server ) ;
         scuInfo = GetScu ( client ) ;

         QueryProcessor <StudyData> query = new QueryProcessor<StudyData> ( scpInfo, scuInfo ) ;

         return query.DoFind ( GetStudyQuery ( options ) ) ;
      }
            
       public string VerifyConnection(PACSConnection server, ClientConnection client)
       {
           AeInfo scpInfo =  GetScp(server);
           using (StoreScu scu = new StoreScu())
           {
              DicomScp scp = new DicomScp(IPAddress.Parse(scpInfo.Address), scpInfo.AETitle, scpInfo.Port);

              scu.AETitle = client.AETitle;
              try
              {
                 if (scu.Verify(scp))
                 {
                    return string.Empty;
                 }
              }
              catch (Exception exception)
              {
                 return exception.Message;
              }
           }
           return string.Empty;
       }

      private AeInfo GetScu ( ClientConnection client )
      {
         AeInfo scuInfo;
         
         
         scuInfo = new AeInfo ( ) ;

         scuInfo.AETitle = ( client == null || string.IsNullOrEmpty ( client.AETitle ) ) ? LocalClient.AETitle : client.AETitle ;
         scuInfo.Address = LocalClient.IPAddress ;
         scuInfo.Port    = LocalClient.Port ;

         return scuInfo;
      }

      private static AeInfo GetScp ( PACSConnection server )
      {
         AeInfo scpInfo ;

         scpInfo = new AeInfo ( ) ;

         scpInfo.AETitle = server.AETitle ;
         scpInfo.Address = server.IPAddress ;
         scpInfo.Port    = server.Port ;

         return scpInfo ;
      }

      /// <summary>
      /// Convert query options into DICOM patient query DataSeet
      /// </summary>
      /// <param name="options">query options</param>
      /// <returns>DICOM DataSet that contains the DICOM query options</returns>
      private Dicom.DicomDataSet GetPatientQuery ( QueryOptions options )
      {
         DicomDataSet query = new DicomDataSet ( ) ;
         FindQuery findQuery = new FindQuery ( ) ;
         
         query.Initialize ( DicomClassType.StudyRootQueryStudy, DicomDataSetInitializeFlags.ImplicitVR | DicomDataSetInitializeFlags.LittleEndian | DicomDataSetInitializeFlags.AddMandatoryElementsOnly | DicomDataSetInitializeFlags.AddMandatoryModulesOnly);

         InsertPatientInfo ( options, query ) ;
         
         query.InsertElementAndSetValue ( DicomTag.QueryRetrieveLevel, "PATIENT" ) ;

         return query ;
      }
      
      /// <summary>
      /// Convert query options into DICOM study query DataSeet
      /// </summary>
      /// <param name="options">query options</param>
      /// <returns>DICOM DataSet that contains the DICOM query options</returns>
      private Dicom.DicomDataSet GetStudyQuery ( QueryOptions options )
      {
         DicomDataSet query = new DicomDataSet ( ) ;
         FindQuery findQuery = new FindQuery ( ) ;
         
         query.Initialize ( DicomClassType.StudyRootQueryStudy, DicomDataSetInitializeFlags.ImplicitVR | DicomDataSetInitializeFlags.LittleEndian | DicomDataSetInitializeFlags.AddMandatoryElementsOnly | DicomDataSetInitializeFlags.AddMandatoryModulesOnly);

         InsertPatientInfo ( options, query ) ;
         InsertStudyInfo ( options, query ) ;
         
         query.InsertElementAndSetValue ( DicomTag.QueryRetrieveLevel, "STUDY" ) ;
         return query ;
      }

      /// <summary>
      /// Convert query options into DICOM series query DataSeet
      /// </summary>
      /// <param name="options">query options</param>
      /// <returns>DICOM DataSet that contains the DICOM query options</returns>
      private Dicom.DicomDataSet GetSeriesQuery ( QueryOptions options )
      {
         DicomDataSet query = new DicomDataSet ( ) ;
         FindQuery    findQuery = new FindQuery ( ) ;

         query.Initialize(DicomClassType.StudyRootQuerySeries, DicomDataSetInitializeFlags.ImplicitVR | DicomDataSetInitializeFlags.LittleEndian | DicomDataSetInitializeFlags.AddMandatoryElementsOnly | DicomDataSetInitializeFlags.AddMandatoryModulesOnly);

         InsertPatientInfo ( options, query ) ;
         InsertStudyInfo ( options, query ) ;
         InsertSeriesInfo(options, query);
         
         query.InsertElementAndSetValue ( DicomTag.QueryRetrieveLevel, "SERIES" ) ;
         return query ;
      }

      /// <summary>
      /// Convert query options into DICOM instnace query DataSeet
      /// </summary>
      /// <param name="options">query options</param>
      /// <returns>DICOM DataSet that contains the DICOM query options</returns>
      private Dicom.DicomDataSet GetInstanceQuery ( QueryOptions options )
      {
         DicomDataSet query = new DicomDataSet ( ) ;
         FindQuery    findQuery = new FindQuery ( ) ;
         
         query.Initialize ( DicomClassType.StudyRootQueryImage, DicomDataSetInitializeFlags.ImplicitVR | DicomDataSetInitializeFlags.LittleEndian | DicomDataSetInitializeFlags.AddMandatoryElementsOnly | DicomDataSetInitializeFlags.AddMandatoryModulesOnly);

         InsertPatientInfo  ( options, query ) ;
         InsertStudyInfo    ( options, query ) ;
         InsertSeriesInfo   ( options, query ) ;
         InsertInstanceInfo ( options, query ) ;
         
         query.InsertElementAndSetValue ( DicomTag.QueryRetrieveLevel, "IMAGE" ) ;

         return query ;
      }

      private static void InsertPatientInfo(QueryOptions options, DicomDataSet query)
      {
         if ( options.PatientsOptions != null ) 
         {
            if ( !string.IsNullOrEmpty ( options.PatientsOptions.BirthDate ) )
            {
               query.InsertElementAndSetValue ( DicomTag.PatientBirthDate, options.PatientsOptions.BirthDate ) ;
            }
            else
            {
               query.InsertElementAndSetValue ( DicomTag.PatientBirthDate, string.Empty ) ;
            }

            if ( !string.IsNullOrEmpty ( options.PatientsOptions.PatientID ) )
            {
               query.InsertElementAndSetValue(DicomTag.PatientID, options.PatientsOptions.PatientID ) ;
            }
            else
            {
               query.InsertElementAndSetValue(DicomTag.PatientID, string.Empty ) ;
            }

            if ( !string.IsNullOrEmpty ( options.PatientsOptions.PatientName ) ) 
            {
               query.InsertElementAndSetValue ( DicomTag.PatientName, options.PatientsOptions.PatientName ) ;
            }
            else
            {
               query.InsertElementAndSetValue(DicomTag.PatientName, string.Empty ) ;
            }

            if ( !string.IsNullOrEmpty ( options.PatientsOptions.Sex ) ) 
            {
               query.InsertElementAndSetValue ( DicomTag.PatientSex, options.PatientsOptions.Sex ) ;
            }
            else
            {
               query.InsertElementAndSetValue(DicomTag.PatientSex, string.Empty ) ;
            }
         }
         else
         {
            query.InsertElementAndSetValue ( DicomTag.PatientBirthDate, string.Empty ) ;
            query.InsertElementAndSetValue ( DicomTag.PatientID, string.Empty ) ;
            query.InsertElementAndSetValue ( DicomTag.PatientName, string.Empty ) ;
            query.InsertElementAndSetValue ( DicomTag.PatientSex, string.Empty ) ; 
         }
      }

      private void InsertStudyInfo ( QueryOptions options, DicomDataSet query )
      {
         if ( null != options.StudiesOptions ) 
         {
            if ( !string.IsNullOrEmpty ( options.StudiesOptions.AccessionNumber ) )
            {
               query.InsertElementAndSetValue ( DicomTag.AccessionNumber, options.StudiesOptions.AccessionNumber ) ;
            }


            if ( ( null != options.StudiesOptions.ModalitiesInStudy ) && 
                 ( options.StudiesOptions.ModalitiesInStudy.Length > 0 ) ) 
            {
               query.InsertElementAndSetValue ( DicomTag.ModalitiesInStudy, options.StudiesOptions.ModalitiesInStudy ) ;
            }

            if (!string.IsNullOrEmpty(options.StudiesOptions.ReferDoctorName))
            {
                query.InsertElementAndSetValue(DicomTag.ReferringPhysicianName, options.StudiesOptions.ReferDoctorName);
            } 

            if ( !string.IsNullOrEmpty ( options.StudiesOptions.StudyID ) )
            {
               query.InsertElementAndSetValue ( DicomTag.StudyID, options.StudiesOptions.StudyID ) ;
            }

            if ( !string.IsNullOrEmpty ( options.StudiesOptions.StudyInstanceUID ) )
            {
               query.InsertElementAndSetValue ( DicomTag.StudyInstanceUID, options.StudiesOptions.StudyInstanceUID ) ;
            }

            if ( !string.IsNullOrEmpty ( options.StudiesOptions.StudyDateStart ) ||
                 !string.IsNullOrEmpty ( options.StudiesOptions.StudyDateEnd ) )
            {
               //TODO: Date need to be formatted into DICOM. Convert string to datetime then ToString ( "yyyyMMdd" )
               query.InsertElementAndSetValue ( DicomTag.StudyDate, string.Format ( "{0}-{1}", 
                                                                    ( options.StudiesOptions.StudyDateStart == null ) ? "" : options.StudiesOptions.StudyDateStart,
                                                                    ( options.StudiesOptions.StudyDateEnd == null ) ? "" : options.StudiesOptions.StudyDateEnd )  ) ;
            }

            if ( !string.IsNullOrEmpty ( options.StudiesOptions.StudyTimeStart ) ||
                 !string.IsNullOrEmpty ( options.StudiesOptions.StudyTimeEnd ) )
            {
               //TODO: Time need to be formatted into DICOM. Convert string to datetime then ToString ( "HHmmss" )
               query.InsertElementAndSetValue ( DicomTag.StudyTime, string.Format ( "{0}-{1}", 
                                                                    ( options.StudiesOptions.StudyTimeStart == null ) ? "" : options.StudiesOptions.StudyTimeStart,
                                                                    ( options.StudiesOptions.StudyTimeEnd == null ) ? "" : options.StudiesOptions.StudyTimeEnd )  ) ;
            }
         }
         else
         {
            
         }
      }

      private void InsertSeriesInfo ( QueryOptions options, DicomDataSet query )
      {
         if ( null != options.SeriesOptions ) 
         {
            if ( !string.IsNullOrEmpty ( options.SeriesOptions.Modality ) )
            {
               query.InsertElementAndSetValue ( DicomTag.Modality, options.SeriesOptions.Modality) ;
            }

            if ( !string.IsNullOrEmpty ( options.SeriesOptions.SeriesInstanceUID ) )
            {
               query.InsertElementAndSetValue ( DicomTag.SeriesInstanceUID, options.SeriesOptions.SeriesInstanceUID ) ;
            }

            if ( !string.IsNullOrEmpty ( options.SeriesOptions.SeriesNumber ) )
            {
               query.InsertElementAndSetValue ( DicomTag.SeriesNumber, options.SeriesOptions.SeriesNumber ) ;
            }
         }
      }

      private void InsertInstanceInfo ( QueryOptions options, DicomDataSet query )
      {
         if ( null != options.InstancesOptions ) 
         {
            if ( !string.IsNullOrEmpty ( options.InstancesOptions.InstanceNumber ) )
            {
               query.InsertElementAndSetValue ( DicomTag.InstanceNumber, options.InstancesOptions.InstanceNumber ) ;
            }

            if ( !string.IsNullOrEmpty ( options.InstancesOptions.SOPInstanceUID ) )
            {
               query.InsertElementAndSetValue ( DicomTag.SOPInstanceUID, options.InstancesOptions.SOPInstanceUID ) ;
            }
         }
      }
   }
}
