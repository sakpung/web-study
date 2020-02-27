// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Linq;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Attributes;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom.Scp;
using Leadtools.Dicom.Scp.Command;
using Leadtools.Dicom.Scp.Command.NAction.PatientUpdater;
using Leadtools.DicomDemos;
using Leadtools.Logging;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.PatientUpdater.AddIn.Queue;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.Winforms.DataAccessLayer.Configuration;
using Leadtools.Medical.Winforms.DatabaseManager;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;

namespace Leadtools.Medical.PatientUpdater.AddIn
{
   [DicomAddIn("Patient Updater Addin", "1.0.0.0", Description = "Implements NAction support for patient update", Author = "LEAD Technologies, Inc.")]
   public class PatientUpdaterAddIn : IProcessNAction, IExtendedPresentationContextProvider
   {
      private ClientSession _ClientSession = null;
      private INActionClientSessionProxy _SessionProxy;
      private DicomCommandStatusType _Status = DicomCommandStatusType.Failure;
      private const string UpdatePermission = "Update";      

      private static string _TemporaryDirectory = null;

      public static string TemporaryDirectory
      {
         get { return PatientUpdaterAddIn._TemporaryDirectory; }         
      }

      #region IProcessNAction Members
      
      public DicomCommandStatusType OnNAction(DicomClient Client, byte PresentationId, int MessageID, string AffectedClass, string Instance, int Action, DicomDataSet Request, DicomDataSet Response)
      {
         ClientSession clientSession = null;
         INActionClientSessionProxy sessionProxy = null;
         DicomCommand patientUpdateCommand = null;
         CompositeInstanceDataSet.InstanceRow[] instanceRows = null;

         if (_TemporaryDirectory == null)
         {
            _TemporaryDirectory = Client.Server.TemporaryDirectory;
         }
                  
         if (Instance != PatientUpdaterConstants.UID.PatientUpdateInstance)
         {
            return DicomCommandStatusType.InvalidObjectInstance;
         }

         if (clientSession != null)
         {
            clientSession.NActionResponse -= clientSession_NActionResponse;
            clientSession = null;
         }

         clientSession = new ClientSession(Client);
         clientSession.NActionResponse += new EventHandler<NActionResponseEventArgs>(clientSession_NActionResponse);
         sessionProxy = new NActionClientSessionProxy(clientSession, PresentationId, MessageID, AffectedClass, Instance, Action, Response);
         patientUpdateCommand = DicomCommandFactory.GetInstance().CreateNActionCommand(sessionProxy, Request);

         _ClientSession = clientSession;
         _SessionProxy = sessionProxy;

         
         //
         // If we are deleting we need to get the instance rows
         //  
         List<string> studyInstanceUids;       
         instanceRows = GetInstanceRows(Action, Request, out studyInstanceUids);

         ConfigureCommand(patientUpdateCommand as PatientUpdaterCommand);
         _ClientSession.ProcessNActionRequest(PresentationId, MessageID, AffectedClass, Instance, Action, patientUpdateCommand).WaitOne();
         
         if (_Status == DicomCommandStatusType.Success)
         {
            //
            // We need to delete the dicom files according to the user options
            //
            if (Action == PatientUpdaterConstants.Action.DeletePatient || Action == PatientUpdaterConstants.Action.DeleteSeries)
            {
               if (instanceRows != null)
               {
                  DicomFileDeleter deleter = new DicomFileDeleter();

                  try
                  {
                     StorageAddInsConfiguration storageSettings = Module.StorageConfigManager.GetStorageAddInsSettings();

                     deleter.DicomFileDeleted += new EventHandler<Leadtools.Medical.Winforms.EventBrokerArgs.DicomFileDeletedEventArgs>(deleter_DicomFileDeleted);
                     deleter.DicomFileDeleteFailed += new EventHandler<Leadtools.Medical.Winforms.EventBrokerArgs.DicomFileDeletedEventArgs>(deleter_DicomFileDeleteFailed);
                     if (storageSettings != null)
                     {
                        deleter.DeleteFilesOnDatabaseDelete = storageSettings.StoreAddIn.DeleteFiles;
                        deleter.BackupFilesOnDatabaseDelete = storageSettings.StoreAddIn.BackupFilesOnDelete;
                        deleter.BackupFilesOnDeleteFolder = storageSettings.StoreAddIn.DeleteBackupLocation;
                     }
                     deleter.Delete(null, instanceRows);
                  }
                  catch (Exception e)
                  {
                     Logger.Global.Error(Module.Source, "[Patient Updater] " + e.Message);
                  }
                  finally
                  {
                     deleter.DicomFileDeleted -= deleter_DicomFileDeleted;
                     deleter.DicomFileDeleteFailed -= deleter_DicomFileDeleteFailed;
                  }
               }
            }

            //
            // If auto update is enabled we need to forward this message to associated ae title
            //
            if (Module.Options != null && Module.Options.EnableAutoUpdate && Module.UpdateQueue != null)
            {
               AutoUpdateItem item = new AutoUpdateItem(Client.AETitle) { Action = Action, ClientAE = Client.Server.AETitle };

               if (Action == PatientUpdaterConstants.Action.MergePatient && (instanceRows != null))
               {
                  MergePatient mergePatientData = Request.Get<MergePatient>(null);
                  foreach(string studyInstanceUid in studyInstanceUids)
                  {
                     mergePatientData.ReferencedStudySequence.Add( new StudyInstanceReference(studyInstanceUid));
                  }
                  mergePatientData.PatientToMerge.Clear();
                  Request.Set(mergePatientData);
               }
               else if (studyInstanceUids.Count > 0)
               {
                  DeletePatient deletePatientData = Request.Get<DeletePatient>(null);
                  foreach(string studyInstanceUid in studyInstanceUids)
                  {
                     deletePatientData.ReferencedStudySequence.Add( new StudyInstanceReference(studyInstanceUid));
                  }
                  Request.Set(deletePatientData);
               }


               // Request.InsertElementAndSetValue(DicomTag.ReferencedStudySequence)
               item.Dicom = Request;

               if (ShouldAutoUpdate(item.Action))
               {
                  Module.UpdateQueue.AddItem(item);
               }

            }
            
         }
         return _Status;
      }

      bool ShouldAutoUpdate(int action)
      {
         Type myType = Module.Options.AutoUpdateOptions.GetType();
         IList<PropertyInfo> myProps = new List<PropertyInfo>(myType.GetProperties());
         foreach (PropertyInfo prop in myProps)
         {
            foreach (Attribute a in prop.GetCustomAttributes(false))
            {
               IntValueAttribute iva = a as IntValueAttribute;
               if (iva != null)
               {
                  if (iva.Value == action)
                  {
                     bool ret = (bool)prop.GetValue(Module.Options.AutoUpdateOptions);
                     return ret;
                  }
               }
            }
         }
         return false;
      }

      void deleter_DicomFileDeleteFailed(object sender, Leadtools.Medical.Winforms.EventBrokerArgs.DicomFileDeletedEventArgs e)
      {
         Logger.Global.SystemMessage(LogType.Error, string.Format("[Patient Updater] Failed to delete file: {0} ", e.FilePath), Module.ServerAE);
      }

      void deleter_DicomFileDeleted(object sender, Leadtools.Medical.Winforms.EventBrokerArgs.DicomFileDeletedEventArgs e)
      {
         Logger.Global.SystemMessage(LogType.Audit, string.Format("[Patient Updater] File Deleted: {0} ", e.FilePath), Module.ServerAE);
      }

      private static CompositeInstanceDataSet.InstanceRow[] GetInstanceRows(int action, DicomDataSet request, out List<string> studyInstanceUids)
      {
         CompositeInstanceDataSet.InstanceRow[] rows = null;
         CompositeInstanceDataSet ds = null;
         MatchingParameterCollection mpc = new MatchingParameterCollection();
         MatchingParameterList mpl = new MatchingParameterList();
         studyInstanceUids = new List<string>();

         if (request == null)
            return null;

         if (Module.StorageAgent == null)
            return null;

         switch (action)
         {
            case PatientUpdaterConstants.Action.MergePatient:
               MergePatient mergePatient = request.Get<MergePatient>();
               if (mergePatient.PatientToMerge != null && mergePatient.PatientToMerge.Count > 0)
               {
                  mpl.Add(new Patient() { PatientID = mergePatient.PatientToMerge[0].PatientId });
                  mpc.Add(mpl);
               }
               break;
            case PatientUpdaterConstants.Action.DeletePatient:
               DeletePatient delPatient = request.Get<DeletePatient>();

               mpl.Add(new Patient() { PatientID = delPatient.PatientId });
               foreach(StudyInstanceReference studyInstanceReference in delPatient.ReferencedStudySequence)
               {
                  mpl.Add(new Study() { StudyInstanceUID = studyInstanceReference.StudyInstanceUID});
               }
               mpc.Add(mpl);
               break;
            case PatientUpdaterConstants.Action.DeleteSeries:
               DeleteSeries delSeries = request.Get<DeleteSeries>();

               mpl.Add(new Series() { SeriesInstanceUID = delSeries.SeriesInstanceUID });
               mpc.Add(mpl);
               break;

            case PatientUpdaterConstants.Action.ChangePatient:
               ChangePatient changePatient = request.Get<ChangePatient>();
               mpl.Add(new Patient() { PatientID = changePatient.OriginalPatientId });
               mpc.Add(mpl);
               break;

            default:
               return null;
         }

         ds = Module.StorageAgent.QueryCompositeInstances(mpc).ToCompositeInstanceDataSet();

         CompositeInstanceDataSet.StudyRow[] studyRows = ds.Study.Rows.OfType<CompositeInstanceDataSet.StudyRow>().ToArray();
         foreach (CompositeInstanceDataSet.StudyRow studyRow in studyRows)
         {
            studyInstanceUids.Add(studyRow.StudyInstanceUID);
         }

         rows = ds.Instance.Rows.OfType<CompositeInstanceDataSet.InstanceRow>().ToArray();

         return rows;
      }

      private void ConfigureCommand(PatientUpdaterCommand command)
      {                 
         StorageAddInsConfiguration config = Module.StorageConfigManager.GetStorageAddInsSettings();
         
         if (config!=null)
         {            
            command.StoreConfiguration.DataSetStorageLocation = config.StoreAddIn.StorageLocation;            
            command.StoreConfiguration.DicomFileExtension = config.StoreAddIn.StoreFileExtension;                   
            command.StoreConfiguration.DirectoryStructure.CreatePatientFolder = config.StoreAddIn.DirectoryStructure.CreatePatientFolder;
            command.StoreConfiguration.DirectoryStructure.CreateSeriesFolder = config.StoreAddIn.DirectoryStructure.CreateSeriesFolder;
            command.StoreConfiguration.DirectoryStructure.CreateStudyFolder = config.StoreAddIn.DirectoryStructure.CreateStudyFolder;
            command.StoreConfiguration.DirectoryStructure.UsePatientName = config.StoreAddIn.DirectoryStructure.UsePatientName;
         }
         command.Options = Module.Options;
      }

      void clientSession_NActionResponse(object sender, NActionResponseEventArgs e)
      {
         e.Handled = true;
         _Status = e.Status;
      }

      #endregion

      #region IProcessBreak Members

      public void Break(BreakType type)
      {
         if (_ClientSession != null)
         {
            if (type == BreakType.Cancel)
            {
               _ClientSession.ProcessCCancelRequest(_SessionProxy.MessageID);
            }
         }

         if (type == BreakType.Shutdown && Module.UpdateQueue!=null)
         {
            Module.UpdateQueue.Dispose();
         }

         if (type == BreakType.Shutdown && Module.RetryProcessor != null)
         {
            Module.RetryProcessor.Stop();
         }
      }

      #endregion      

      #region IExtendedPresentationContextProvider Members


      private DicomClient _Client;

      public DicomClient Client
      {         
         set
         {
            _Client = value;
         }
      }

      public ExtendedNegotiation GetExtended(string abstractSyntax)
      {
         return ExtendedNegotiation.None;
      }

      public bool IsAbstractSyntaxSupported(string abstractSyntax)
      {
         if (abstractSyntax == PatientUpdaterConstants.UID.PatientUpdateClass)
         {
            return CheckPermissions();
         }

         return false;
      }

      public bool IsTransferSyntaxSupported(string abstractSyntax, string transferSyntax)
      {
         if (abstractSyntax == PatientUpdaterConstants.UID.PatientUpdateClass)
         {
            return CheckPermissions();
         }
         return false;
      }

      #endregion

      private bool CheckPermissions()
      {
         try
         {
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(Module.ServiceDirectory);
            IPermissionManagementDataAccessAgent agent = DataAccessFactory.GetInstance(new AePermissionManagementDataAccessConfigurationView(configuration, null, Module.ServiceName)).CreateDataAccessAgent<IPermissionManagementDataAccessAgent>();
            string[] permissions = agent.GetUserPermissions(_Client.AETitle);

            return permissions.Contains(UpdatePermission);
         }
         catch (Exception e)
         {
            Logger.Global.Exception("Patient Updater", e);
         }
         return false;
      }
   }
}
