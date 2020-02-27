// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

using Leadtools.Dicom.Scu;
using Leadtools.Dicom.Scu.Common;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Dicom;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using System.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer.Interface;

namespace Leadtools.Medical.WebViewer.Jobs
{
   [Serializable]
   public class MoveObjectsJob : DICOMJob
   {
      protected MoveObjectsJob()
         : base()
      {
         QueryResult = null;
         DSQueryResult = null;
         DataSet = new Dicom.DicomDataSet();
         Owner = string.Empty;
         PatientRightsDataAccess = null;
         DataAccessAgent = null;
      }

      public MoveObjectsJob(DICOMJobSettings js)
         : base(js)
      {
         QueryResult = null;
         DSQueryResult = null;
         DataSet = new Dicom.DicomDataSet();
         Owner = string.Empty;
         PatientRightsDataAccess = null;
         DataAccessAgent = null;
      }
      public override void Dispose(bool bUnmanaged)
      {
         base.Dispose();

         if (null != QueryResult)
         {
            QueryResult.Dispose();
         }

         if (null != DSQueryResult)
         {
            DSQueryResult.Dispose();
         }
      }
      [XmlIgnore]
      public RasterImage QueryResult
      {
         get;
         private set;
      }
      [XmlIgnore]
      public Leadtools.Dicom.DicomDataSet DSQueryResult
      {
         get;
         private set;
      }

      void ReceiveImage(Leadtools.Dicom.Scu.ImageInstance instance)
      {
         if (null != instance.Images)
         {
            QueryResult = instance.Images;
         }
      }

      void ReceiveDS(Leadtools.Dicom.DicomDataSet Dataset)
      {
         if (null != Dataset)
         {
            DSQueryResult = Dataset;
         }
      }

      void _find_AfterCMove(object sender, AfterCMoveEventArgs e)
      {
         if ((e.Status != DicomCommandStatusType.Success) &&
             (e.Status != DicomCommandStatusType.Pending) &&
             (e.Status != DicomCommandStatusType.Warning))
         {
            #region LOG
            {
               string message = @"MoveObjectsJob Failure: " + e.Status.ToString();
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, message, null, null);
            }
            #endregion	

            throw new Exception("Move operation failed: " + e.Status.ToString());
         }
      }

      void _find_Moved(object sender, Leadtools.Dicom.Scu.Common.MovedEventArgs e)
      {
         if (e.Instance.InstanceType == InstanceLevel.Image)
         {
            ReceiveImage(e.Instance as Leadtools.Dicom.Scu.ImageInstance);
            ReceiveDS(e.Dataset);
         }
      }

      void _find_PrivateKeyPassword(object sender, Leadtools.Dicom.Scu.Common.PrivateKeyPasswordEventArgs e)
      {
         //e.PrivateKeyPassword = ClientPrivateKeyPassword;
      }

      QueryRetrieveScu CreateQRObject()
      {
         QueryRetrieveScu _QRScu = null;

         _QRScu = new QueryRetrieveScu();

         _QRScu.MaxLength = 46726;
         _QRScu.ImplementationClass = ConfigurationImplementationClass;
         _QRScu.ProtocolVersion = ConfigurationProtocolversion;
         _QRScu.ImplementationVersionName = ConfigurationImplementationVersionName;
         _QRScu.AETitle = ClientAE;
         _QRScu.HostPort = ClientPort;

         _QRScu.Moved += new Leadtools.Dicom.Scu.Common.MovedDelegate(_find_Moved);
         _QRScu.AfterCMove += new Leadtools.Dicom.Scu.Common.AfterCMoveDelegate(_find_AfterCMove);

         _QRScu.PrivateKeyPassword += new PrivateKeyPasswordDelegate(_find_PrivateKeyPassword);
         if (UseTls)
         {
            _QRScu.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.DheRsaWith3DesEdeCbcSha);
            _QRScu.SetTlsClientCertificate(
               ClientCertificate,
               DicomTlsCertificateType.Pem,
               ClientPrivateKey.Length > 0 ? ClientPrivateKey : null);
         }
         _QRScu.DebugLogFilename = string.Empty;
         _QRScu.EnableDebugLog = false;

         return _QRScu;
      }

      [XmlIgnore]
      public IPatientRightsDataAccessAgent PatientRightsDataAccess { get; set; }
      public string Owner { get; set; }
      [XmlIgnore]
      public Dicom.DicomDataSet DataSet { get; set; }
      public string DataSetStr
      {
         get
         {
            using (MemoryStream ms = new MemoryStream())
            {
               DataSet.Save(ms, DicomDataSetSaveFlags.None);
               byte[] data = ms.ToArray();
               string sEncoded = Convert.ToBase64String(data);
               return sEncoded;
            }
         }
         set
         {
            byte[] data = Convert.FromBase64String(value);
            using (MemoryStream ms = new MemoryStream(data))
            {
               DataSet.Load(ms, DicomDataSetLoadFlags.None);
            }
         }
      }

      QueryRetrieveScu _QRScu = null;

      override protected void TryAbort()
      {
         if (null != _QRScu)
         {
            if (_QRScu.IsAssociated())
            {
               _QRScu.AbortRequest(DicomAbortSourceType.User, DicomAbortReasonType.Unexpected);
            }
         }
      }

      override public void StartJob()
      {
         try
         {
            #region LOG
            {
               string message = @"MoveObjectsJob StartJob";
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, message, null, null);
            }
            #endregion	

            if (IsAbortTriggered())
            {
               JobAborted();
               return;
            }

            JobPending();

            #region LOG
            {
               string message = @"MoveObjectsJob StartJob - Pending";
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, message, null, null);
            }
            #endregion	

            using (_QRScu = CreateQRObject())
            {
               JobRunning();
               _QRScu.Move(CreateServerObject(), MoveToClientAE, DataSet);
               #region LOG
               {
                  string message = @"MoveObjectsJob Completed";
                  Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                   LogType.Information, MessageDirection.None, message, null, null);
               }
               #endregion	

               PostJobRoutine();
               JobSucceeded();
            }
         }
         catch (System.Exception ex)
         {
            JobFailed("Error connecting to remote server {" + ServerAE + "}: " + ex.Message);
         }
         finally
         {
            _QRScu = null;
         }
      }
      [XmlIgnore]
      public IStorageDataAccessAgent DataAccessAgent { get; set; }

      string GetPatientIdFromStorage()
      {
         try
         {
            if (null == DataAccessAgent)
            {
               return "";
            }

            MatchingParameterCollection matchingParamCollection;
            MatchingParameterList matchingParamList;

            matchingParamCollection = new MatchingParameterCollection();
            matchingParamList = new MatchingParameterList();
            matchingParamCollection.Add(matchingParamList);

            {
               ReverseDicomDatasetAdapter dataSetReader = new ReverseDicomDatasetAdapter()
               {
                  query = DataSet
               };

               string PatientID = dataSetReader.PatientID;
               string StudyInstanceUID = dataSetReader.StudyInstanceUID;
               string SeriesInstanceUID = dataSetReader.SeriesInstanceUID;
               string SOPInstanceUID = dataSetReader.SOPInstanceUID;

               if (!string.IsNullOrEmpty(SOPInstanceUID))
               {
                  Instance imageInstance = new Instance(SOPInstanceUID);

                  matchingParamList.Add(imageInstance);

               }
               if (!string.IsNullOrEmpty(SeriesInstanceUID))
               {
                  Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters.Series seriesEntity = new Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters.Series(SeriesInstanceUID);

                  matchingParamList.Add(seriesEntity);
               }
               if (!string.IsNullOrEmpty(StudyInstanceUID))
               {
                  Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters.Study studyEntity = new Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters.Study(StudyInstanceUID);

                  matchingParamList.Add(studyEntity);
               }
               if (!string.IsNullOrEmpty(PatientID))
               {
                  Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters.Patient patientEntity = new Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters.Patient(PatientID);

                  matchingParamList.Add(patientEntity);
               }
            }

            DataSet result = DataAccessAgent.QueryPatients(matchingParamCollection);
            if (null != result)
            {
               if (result.Tables[DataTableHelper.PatientTableName].Rows.Count > 0)
               {
                  // return result.Patient[0].PatientID;
                    IPatientInfo patientInfo = RegisteredDataRows.PatientInfo;
                    DataRow patientRow = result.Tables[DataTableHelper.PatientTableName].Rows[0];
                    string sPatientId = patientInfo.GetElementValue(patientRow, DicomTag.PatientID);

                  return (string)result.Tables[DataTableHelper.PatientTableName].Rows[0]["PatientId"];
               }
            }

            return "";
         }
         catch (System.Exception )
         {
            System.Diagnostics.Debug.Assert(false);
            return "";
         }
      }

      string GetPatientId()
      {
         try
         {
            string PatientId = DataSet.GetValue<string>(DicomTag.PatientID, null);
            if (!String.IsNullOrEmpty(PatientId))
            {
               return PatientId;
            }

            return GetPatientIdFromStorage();
         }
         catch
         {
            return null;
         }
      }

      void PostJobRoutine()
      {
         try
         {
            if (String.IsNullOrEmpty(Owner) || (null == PatientRightsDataAccess))
            {
               return;
            }

            string PatientId = GetPatientId();

            #region LOG
            {
               string message = @"MoveObjectsJob PostJobRoutine - Started";
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, message, null, null);
            }
            #endregion	
            PatientRightsDataAccess.GrantUserAccess(PatientId, Owner);
            #region LOG
            {
               string message = @"MoveObjectsJob PostJobRoutine - Completed";
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, message, null, null);
            }
            #endregion	

         }
         catch
         {
            System.Diagnostics.Debug.Assert(false);

            //ignored
         }
      }
   }
}
