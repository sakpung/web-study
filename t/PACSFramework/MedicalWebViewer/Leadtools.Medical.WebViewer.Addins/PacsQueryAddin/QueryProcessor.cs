// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom.AddIn.Common;
using System.Net;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu.Queries;
using Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.Medical.WebViewer.Addins
{
   /// <summary>
   /// Perform the actual query to the DICOM server. (High level query object!)
   /// The class uses the QueryRetrieveScu to perform the query, most levels are generic excpet for the Patient level query 
   /// </summary>
   /// <typeparam name="T"></typeparam>
   class QueryProcessor <T> where T : class
   {
      public AeInfo ScuInfo { get ; set ; }
      public AeInfo ScpInfo { get; set; }

      public QueryProcessor ( AeInfo scpInfo, AeInfo scuInfo ) 
      {
         ScuInfo = scuInfo ;
         ScpInfo = scpInfo ;
      }

      public PatientData[] DoFindPatient ( PatientsQueryOptions query )  
      {
         using (QueryRetrieveScu find = CreateQueryRetrieveClient())
         {
            __CurrentFind = find;

            RegisterEvents(find);

            try
            {
               DicomScp scp = new DicomScp ( ) ; 

               scp.AETitle = ScpInfo.AETitle ;
               scp.Port    = ScpInfo.Port ;
               scp.PeerAddress = IPAddress.Parse ( ScpInfo.Address ) ;

               Patients = new List<PatientData>();

               find.EnableDebugLog = false ;
               
               PatientRootQueryPatient patientRootQuery = new PatientRootQueryPatient ( ) ;

               if ( query != null ) 
               {
                  if ( !string.IsNullOrEmpty ( query.BirthDate ) )
                  {
#if LEADTOOLS_V19_OR_LATER
                     DateRange dr = new DateRange();
                     DateTime dt = DateTime.Parse ( query.BirthDate );
                     dr.StartDate = dt;
                     dr.EndDate = dt;
                     patientRootQuery.PatientQuery.PatientBirthDate = dr;//DateTime.Parse ( query.BirthDate ) ;
#else
                     patientRootQuery.PatientQuery.PatientBirthDate = DateTime.Parse ( query.BirthDate ) ;
#endif
                  }

                  patientRootQuery.PatientQuery.PatientId   = query.PatientID ;
                  patientRootQuery.PatientQuery.PatientName = query.PatientName ;
                  patientRootQuery.PatientQuery.PatientSex  = query.Sex ;
                  patientRootQuery.PatientQuery.PatientComments = query.Comments;
                  // patientRootQuery.PatientQuery.EthnicGroup = query.EthnicGroup;
               }

               find.Find <PatientRootQueryPatient, PatientQuery> ( scp, patientRootQuery, PatientMatchDelegate ) ;

               return Patients.ToArray ( ) ;
            }
            catch (Exception exception)
            {
               System.Diagnostics.Debug.Assert(false, exception.Message);

               throw;
            }
            finally
            {
               __CurrentFind = null;

               UnregisterEvents(find);
            }
         }
      }
      
      public T[] DoFind ( DicomDataSet query )  
      {
         using (QueryRetrieveScu find = CreateQueryRetrieveClient())
         {
            __CurrentFind = find;

            RegisterEvents(find);

            try
            {
               DicomScp scp = new DicomScp ( ) ;

               scp.AETitle = ScpInfo.AETitle ;
               scp.Port    = ScpInfo.Port ;
               scp.PeerAddress = IPAddress.Parse ( ScpInfo.Address ) ;

               Matches = new List<T>();

               find.EnableDebugLog = false ;
               
               find.Find (scp, query);

               return Matches.ToArray ( ) ;
            }
            catch (Exception exception)
            {
               System.Diagnostics.Debug.Assert(false, exception.Message);

               throw;
            }
            finally
            {
               __CurrentFind = null;

               UnregisterEvents(find);
            }
         }
      }

      private QueryRetrieveScu CreateQueryRetrieveClient()
      {
         QueryRetrieveScu find;


         find = new QueryRetrieveScu();
         find.ImplementationClass       = Constants.ConfigurationImplementationClass ;
         find.ProtocolVersion           = Constants.ConfigurationProtocolversion ;
         find.ImplementationVersionName = Constants.ConfigurationImplementationVersionName ;
         find.AETitle                   = ScuInfo.AETitle ;
         find.HostPort                  = ScuInfo.Port ;
         find.HostAddress               = IPAddress.Parse ( ScuInfo.Address ) ;

         return find;
      }

      private void RegisterEvents(QueryRetrieveScu find)
      {
         try
         {
            find.AfterAssociateRequest += new AfterAssociateRequestDelegate ( find_AfterAssociateRequest ) ;
            find.AfterCFind            += new AfterCFindDelegate ( find_AfterCFind ) ;
            find.AfterConnect          += new AfterConnectDelegate ( find_AfterConnect ) ;
            find.MatchStudy            += new MatchStudyDelegate ( find_MatchStudy ) ;
            find.MatchSeries           += new MatchSeriesDelegate ( find_MatchSeries ) ;
            find.MatchInstance         += new MatchInstanceDelegate ( find_MatchInstance ) ;
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);

            throw;
         }
      }

      private void UnregisterEvents(QueryRetrieveScu find)
      {
         try
         {
            find.AfterAssociateRequest -= new AfterAssociateRequestDelegate ( find_AfterAssociateRequest ) ;
            find.AfterCFind            -= new AfterCFindDelegate ( find_AfterCFind ) ;
            find.AfterConnect          -= new AfterConnectDelegate ( find_AfterConnect ) ;
            find.MatchStudy            -= new MatchStudyDelegate ( find_MatchStudy ) ;
            find.MatchSeries           -= new MatchSeriesDelegate ( find_MatchSeries ) ;
            find.MatchInstance         -= new MatchInstanceDelegate ( find_MatchInstance ) ;
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);

            throw;
         }
      }

      private void find_AfterConnect(object sender, AfterConnectEventArgs e)
      {
         if (e.Error != DicomExceptionCode.Success)
         {
            throw new Leadtools.Dicom.Scu.Common.ClientConnectionException(Constants.Exception.ConnectionFailed,
                                                  e.Error);
         }
      }

      private void find_AfterCFind(object sender, AfterCFindEventArgs e)
      {
          if (e.Status != DicomCommandStatusType.Success && e.Status != DicomCommandStatusType.Pending && e.Status != DicomCommandStatusType.PendingWarning)
         {
            throw new Leadtools.Dicom.Scu.Common.ClientCommunicationException(Constants.Exception.CFindFailed,
                                                     e.Status);
         }
      }

      private void find_AfterAssociateRequest(object sender, AfterAssociateRequestEventArgs e)
      {
         try
         {
            if (e.Rejected)
            {
               throw new Leadtools.Dicom.Scu.Common.ClientAssociationException(Constants.Exception.AssociationFailed,
                                                                                 e.Reason);
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);

            throw;
         }
      }

      private void PatientMatchDelegate ( PatientQuery patientResult, DicomDataSet ds )
      {
         PatientData patient = new PatientData ( )  ;
#if LEADTOOLS_V19_OR_LATER
         patient.BirthDate = ( patientResult.PatientBirthDate == null ) ? string.Empty : patientResult.PatientBirthDate.StartDate.Value.ToString ( ) ;
#else
         patient.BirthDate = ( patientResult.PatientBirthDate == null ) ? string.Empty : patientResult.PatientBirthDate.Value.ToString ( ) ;
#endif
         patient.Comments  = patientResult.PatientComments ;
         patient.ID        = patientResult.PatientId ;
         patient.Name      = ( string.IsNullOrEmpty ( patientResult.PatientName ) ) ? string.Empty : patientResult.PatientName ;
         patient.Sex       = patientResult.PatientSex ;

         patient.NumberOfRelatedInstances = ds.GetValue <string> ( DicomTag.NumberOfPatientRelatedInstances, string.Empty ) ;
         patient.NumberOfRelatedSeries    = ds.GetValue <string> ( DicomTag.NumberOfPatientRelatedSeries, string.Empty ) ;
         patient.NumberOfRelatedStudies   = ds.GetValue <string> ( DicomTag.NumberOfPatientRelatedStudies, string.Empty ) ;
      }

      private void find_MatchStudy(object sender, MatchEventArgs<Study> e)
      {
         StudyData study = new StudyData ( ) ;

         study.Patient = new PatientData ( ) ;

         study.AccessionNumber = e.Info.AccessionNumber ;
         study.AdmittingDiagnosesDescription = e.Info.AdmitDiagDescrp ;
         study.Age = ( e.Info.Age == null ) ? null : e.Info.Age.Value.Number.ToString ( )+ e.Info.Age.Value.Reference.ToString ( );//TODO: this needs to be replaced with the DICOM encoding
         study.Date = ( e.Info.Date == null ) ? null : e.Info.Date.Value.ToString ( ) ;
         study.Description = e.Info.Description ;
         study.Id = e.Info.Id ;
         study.InstanceUID = e.Info.InstanceUID ;
         study.ModalitiesInStudy = ( null != e.Info.ModalitiesInStudy ) ? e.Info.ModalitiesInStudy.ToArray ( ) : null ;
         study.NumberOfRelatedInstances = e.Info.NumberOfRelatedInstances ;
         study.NumberOfRelatedSeries = e.Info.NumberofRelatedSeries ;
         study.ReferringPhysiciansName = e.Info.ReferringPhysiciansName.FullDicomEncoded ;
         study.Size = ( e.Info.Size == null ) ? null : e.Info.Size.ToString ( ) ;
         study.Weight = ( e.Info.Weight == null ) ? null : e.Info.Weight.ToString ( ) ;
         study.Patient.ID = e.Info.Patient.Id ;
         study.Patient.Name = e.Info.Patient.Name.FullDicomEncoded ;
         study.Patient.BirthDate = ( e.Info.Patient.BirthDate == null ) ? null : e.Info.Patient.BirthDate.ToString ( ) ;
         study.AdditionalPatientHistory = e.Dataset.GetValue <string> ( DicomTag.AdditionalPatientHistory, string.Empty ) ;

//study.NameOfDoctorsReading 
         Matches.Add ( study as T) ;

      }

      private void find_MatchSeries
      (
         object sender,
         MatchEventArgs<Leadtools.Dicom.Scu.Series> e
      )
      {
         SeriesData series = new SeriesData ( ) ;

         series.Patient = new PatientData();         
         series.Date                     = ( e.Info.Date == null ) ? null : e.Info.Date.Value.ToString ( ) ;
         series.Description              = e.Info.Description ;
         series.InstanceUID              = e.Info.InstanceUID ;
         series.Modality                 = e.Info.Modality ;
         series.Number                   = ( e.Info.Number == null ) ? string.Empty : e.Info.Number.ToString ( )  ;
         series.NumberOfRelatedInstances = e.Info.NumberOfRelatedInstances.ToString ( ) ;
         //series.PatientID                = e.Dataset.GetValue <string> ( DicomTag.PatientID, string.Empty ) ;
         series.Patient.ID                = e.Dataset.GetValue <string> ( DicomTag.PatientID, string.Empty ) ;
         series.StudyInstanceUID         = e.Dataset.GetValue <string> ( DicomTag.StudyInstanceUID, string.Empty ) ;

         Matches.Add ( series as T ) ;
      }

      void find_MatchInstance
      (
         object sender,
         MatchEventArgs<CompositeObjectInstance> e
      )
      {
         try
         {
            InstanceData instance = new InstanceData ( ) ;

            instance.InstanceNumber    = e.Info.InstanceNumber.ToString ( ) ;
            instance.PatientID         = e.Dataset.GetValue <string> ( DicomTag.PatientID, string.Empty ) ;
            instance.SeriesInstanceUID = e.Info.SeriesInstanceUID ;
            instance.SOPClassUID       = e.Info.SOPClassUID ;
            instance.SOPInstanceUID    = e.Info.SOPInstanceUID ;
            instance.StationName       = e.Dataset.GetValue <string> ( DicomTag.StationName, string.Empty ) ;
            instance.StudyInstanceUID  = e.Dataset.GetValue <string> ( DicomTag.StudyInstanceUID, string.Empty ) ;
            instance.TransferSyntax    = e.Dataset.GetValue <string> ( DicomTag.TransferSyntaxUID, string.Empty ) ;

            Matches.Add ( instance as T ) ;
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);

            throw;
         }
      }

      private List<PatientData>  Patients  { get; set; } 
      private List<T> Matches { get; set; } 

      private QueryRetrieveScu __CurrentFind { get ; set ;}

      private class Constants
      {
         public const string ConfigurationImplementationClass = "1.2.840.114257.1123456";
         public const string ConfigurationImplementationVersionName = "1";
         public const string ConfigurationProtocolversion = "1";

         public class Exception
         {
            public const string MoveFailed = "C-Move operation failed.";
            public const string ConnectionFailed = "Failed to connect to server.";
            public const string AssociationFailed = "Failed to establish an association with the server.";
            public const string CFindFailed = "C-Find Request failed";
         }
      }
   }
}
