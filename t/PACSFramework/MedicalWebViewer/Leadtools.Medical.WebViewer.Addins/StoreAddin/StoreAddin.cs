// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Linq;
using System.Collections.Generic;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom;
using System.IO;
using Leadtools.Dicom.Scp.Command;
using Leadtools.Dicom.Scp;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Dicom.Common.Extensions;
using System.ComponentModel;
using Leadtools.Medical.Winforms.Common;
using System.Data;
using Leadtools.Medical.DataAccessLayer.Catalog;
using Leadtools.Medical.Logging.DataAccessLayer;
using Leadtools.Dicom.Scp.Command.NAction.PatientUpdater;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using Leadtools.Medical.WebViewer.Addins.Common;
using Leadtools.Dicom.Common.DataTypes.StructuredDisplay;
using Leadtools.Medical.Storage.DataAccessLayer.Interface;
using System.Configuration;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Dicom.AddIn;
using Leadtools.Codecs;
using Leadtools.Annotations.Engine;
using System.Text;
using System.Web.Script.Serialization;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;
using Leadtools.Medical.WebViewer.Core.DataTypes;
using System.Reflection;
using Leadtools.Dicom.Imaging;

#if TUTORIAL_CUSTOM_DATABASE
using My.Medical.Storage.DataAccessLayer.Entities;
#endif

namespace Leadtools.Medical.WebViewer.Addins
{
    public class StoreAddin : IStoreAddin
    {
        IStorageDataAccessAgent3 _storageAgent = null;
        IQueryAddin _queryAddin = null;
        IObjectRetrieveAddin _objectRetrieveAddin = null;
        ILoggingDataAccessAgent _loggingAgent = null;

        string _AETitle;
        string _StorageServerServicePath;
        string _ImplementationClassUID;
        public static string ImplementationClassUID = "1.2.840.114257.1123456";

        private IAuthorizedStorageDataAccessAgent _authorizedStorageAgent = null;
        private IPermissionManagementDataAccessAgent2 _permissionsDataAccess;

        public StoreAddin(IStorageDataAccessAgent3 storageAgent, ILoggingDataAccessAgent loggingAgent, IQueryAddin queryAddin, IObjectRetrieveAddin objectRetrieveAddin, string ServerAETitle, string StorageServerServicePath, IPermissionManagementDataAccessAgent2 permissionsDataAccess, IAuthorizedStorageDataAccessAgent authorizedStorageAgent)
        {
            _storageAgent = storageAgent;
            _loggingAgent = loggingAgent;
            _queryAddin = queryAddin;
            _objectRetrieveAddin = objectRetrieveAddin;
            _AETitle = ServerAETitle;
            _StorageServerServicePath = StorageServerServicePath;
            _ImplementationClassUID = ImplementationClassUID;
            _permissionsDataAccess = permissionsDataAccess;
            _authorizedStorageAgent = authorizedStorageAgent;
        }

        #region IStoreAddin Members

        public void StoreItem(System.IO.Stream stream, StoreItemInfo itemInfo)
        {
            if (itemInfo.MimeType != SupportedMimeTypes.DICOM)
            {
                throw new Exception("Mime type not supported");
            }

            using (DicomDataSet ds = new DicomDataSet())
            {
                ds.Load(stream, DicomDataSetLoadFlags.None);
                //_storageAgent.StoreDicom(ds, string.Empty, string.Empty, new ReferencedImages[] { }, false, false, false, false);
                DoStore(ds);
            }
        }

        StoreAddInConfigurationElement _StorageStoreConfig = null;
        bool _StorageStoreConfigLoaded = false;

        void LoadStorageStoreConfig()
        {
            try
            {
                if (_StorageStoreConfigLoaded)
                {
                    return;
                }

                _StorageStoreConfigLoaded = true;

                if (!string.IsNullOrEmpty(_StorageServerServicePath))
                {
                    using (StorageModuleConfigurationManager configurationManager = new StorageModuleConfigurationManager(false))
                    {
                        configurationManager.Load(_StorageServerServicePath);
                        _StorageStoreConfig = configurationManager.GetStorageAddInsSettings().StoreAddIn;
                    }
                }
            }
            catch
            {
            }
        }

        public static void ConfigureCStoreCommand
        (
           DicomCommand command,
           StoreAddInConfigurationElement storeConfig
        )
        {
            CStoreCommand storeCommand;

            if (null == storeConfig)
            {
                return;
            }

            storeCommand = command as CStoreCommand;

            if (null != storeCommand)
            {
                storeCommand.Configuration.DataSetStorageLocation = storeConfig.StorageLocation;
                storeCommand.Configuration.HangingProtocolLocation = storeConfig.HangingProtocolLocation;
                storeCommand.Configuration.OverwriteBackupLocation = storeConfig.OverwriteBackupLocation;
                storeCommand.Configuration.DicomFileExtension = storeConfig.StoreFileExtension;

                storeCommand.Configuration.DirectoryStructure.CreatePatientFolder = storeConfig.DirectoryStructure.CreatePatientFolder;
                storeCommand.Configuration.DirectoryStructure.CreateSeriesFolder = storeConfig.DirectoryStructure.CreateSeriesFolder;
                storeCommand.Configuration.DirectoryStructure.CreateStudyFolder = storeConfig.DirectoryStructure.CreateStudyFolder;
                storeCommand.Configuration.DirectoryStructure.UsePatientName = storeConfig.DirectoryStructure.UsePatientName;
                storeCommand.Configuration.DirectoryStructure.SplitPatientId = storeConfig.DirectoryStructure.SplitPatientId;

                foreach (SaveImageFormatElement imageFormatElement in storeConfig.ImagesFormat)
                {
                    SaveImageFormat imageFormat = GetImageFormat(imageFormatElement);

                    storeCommand.Configuration.OtherImageFormat.Add(imageFormat);
                }

                storeCommand.Configuration.SaveThumbnail = storeConfig.CreateThumbnailImage;

                if (storeCommand.Configuration.SaveThumbnail)
                {
                    storeCommand.Configuration.ThumbnailFormat = GetImageFormat(storeConfig.ThumbnailFormat);
                }
            }
        }

        void ConfigureInstanceCStoreCommand(DicomCommand command)
        {
            InstanceCStoreCommand instanceStoreCommand;

            instanceStoreCommand = command as InstanceCStoreCommand;

            if (null != instanceStoreCommand && null != _StorageStoreConfig)
            {
                instanceStoreCommand.InstanceConfiguration.CreateBackupForDuplicateSop = _StorageStoreConfig.CreateBackupBeforeOverwrite;
                instanceStoreCommand.InstanceConfiguration.UpdateInstanceData = _StorageStoreConfig.DatabaseOptions.UpdateExistentInstance;
                instanceStoreCommand.InstanceConfiguration.UpdatePatientData = _StorageStoreConfig.DatabaseOptions.UpdateExistentPatient;
                instanceStoreCommand.InstanceConfiguration.UpdateSeriesData = _StorageStoreConfig.DatabaseOptions.UpdateExistentSeries;
                instanceStoreCommand.InstanceConfiguration.UpdateStudyData = _StorageStoreConfig.DatabaseOptions.UpdateExistentStudy;

                instanceStoreCommand.InstanceConfiguration.ValidateDuplicateSopInstanceUID = _StorageStoreConfig.PreventStoringDuplicateInstance;
            }
        }

        private static SaveImageFormat GetImageFormat
        (
           SaveImageFormatElement imageFormatElement
        )
        {
            SaveImageFormat imageFormat;


            imageFormat = new SaveImageFormat();

            imageFormat.Format = (RasterImageFormat)Enum.Parse(typeof(RasterImageFormat), imageFormatElement.Format, true);
            imageFormat.Height = imageFormatElement.Height;
            imageFormat.Width = imageFormatElement.Width;
            imageFormat.QualityFactor = imageFormatElement.QFactor;

            return imageFormat;
        }

        private void SendMessageQueue(DicomDataSet ds, string command, string sopInstanceUid, string path)
        {
           //StorageAddInsConfiguration settings = _configurationManager.GetStorageAddInsSettings();

           //if (settings.StoreAddIn.UseMessageQueue)
           {
              var messageQueueSuccess = CStoreAddIn.SendMessageQueueImplementation(ds, command, sopInstanceUid, path);

              if (!messageQueueSuccess)
              {
                 try
                 {
                    //const string message = "'Use Message Queue' has been disabled.  To enable, go to: Storage Settings->Options and check 'Use Message Queue'.";
                    //Logger.Global.Log(string.Empty,
                    //                    string.Empty,
                    //                    0,
                    //                    string.Empty,
                    //                    string.Empty,
                    //                    0,
                    //                    DicomCommandType.Undefined,
                    //                    DateTime.Now,
                    //                    LogType.Information,
                    //                    MessageDirection.None,
                    //                    message, null, null);

                    //settings.StoreAddIn.UseMessageQueue = false;
                    //_configurationManager.SetStorageAddinsSettings(settings);
                    //_configurationManager.Save();
                 }
                 catch (Exception)
                 {
                 }
              }
           }
        }

        public void DoStore(DicomDataSet ds)
        {
            StoreClientSessionProxy proxy = new StoreClientSessionProxy();
            InstanceCStoreCommand cmd = new InstanceCStoreCommand(proxy, ds, _storageAgent);
            InstanceCStoreCommand.SendMessageQueue = SendMessageQueue;

            LoadStorageStoreConfig();

            ConfigureCStoreCommand(cmd, _StorageStoreConfig);
            ConfigureInstanceCStoreCommand(cmd);

            proxy.AffectedSOPInstance = ds.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
            proxy.AbstractClass = ds.GetValue<string>(DicomTag.SOPClassUID, string.Empty);
            proxy.ServerName = _AETitle;

            ds.InsertElementAndSetValue(DicomTag.MediaStorageSOPInstanceUID, proxy.AffectedSOPInstance);
            ds.InsertElementAndSetValue(DicomTag.ImplementationClassUID, _ImplementationClassUID);

            cmd.Execute();

            if (proxy.LastStatus != DicomCommandStatusType.Success)
            {
                throw new Exception("Storing dataset failure: " + proxy.LastStatusDescriptionMessage);
            }
        }

        public string UploadFile(string userName, string dicomData, string status, string fileName)
        {
            if (status.Trim().ToLower() == "start")
            {
                fileName = Path.GetTempFileName();

                byte[] buff = Convert.FromBase64CharArray(dicomData.ToCharArray(), 0, dicomData.Length);
                // Dump PDF to file
                using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                {
                    fileStream.Write(buff, 0, buff.Length);
                    fileStream.Flush();
                    fileStream.Close();
                }

                return fileName;
            }
            else if (status.Trim().ToLower() == "append")
            {
                byte[] buff = Convert.FromBase64CharArray(dicomData.ToCharArray(), 0, dicomData.Length);
                // Dump PDF to file
                using (FileStream fileStream = new FileStream(fileName, FileMode.Append))
                {
                    fileStream.Write(buff, 0, buff.Length);
                    fileStream.Flush();
                    fileStream.Close();
                }

                return fileName;
            }
            else if (status.Trim().ToLower() == "done")
            {
                using (DicomDataSet ds = new DicomDataSet())
                {
                    // already been called
                    ds.Load(fileName, DicomDataSetLoadFlags.None);

                    DoStore(ds);

                    DicomElement patientElement = ds.FindFirstElement(null, DicomTag.PatientName, true);
                    string patientName = "Unknown";
                    if (patientElement != null)
                    {
                        patientName = ds.GetStringValue(patientElement, 0);
                    }

                    DicomElement sopInstanceUIDElement = ds.FindFirstElement(null, DicomTag.PatientName, true);
                    string sopInstanceUID = "";
                    if (sopInstanceUIDElement != null)
                    {
                        sopInstanceUID = ds.GetStringValue(sopInstanceUIDElement, 0);
                    }

                    _loggingAgent.UploadFile(userName, patientName, sopInstanceUID);

                    // delete the temporary file.
                    try
                    {
                       File.Delete(fileName);
                    }
                    catch
                    {
                    	//ignored
                    }                    
                }
                return "success";
            }

            return "";
        }


        public SeriesData StoreSecondaryCapture(string UserName, string EncodedCapture, string OriginalSOPInstance, string SeriesNumber, string SeriesDescription, string ProtocolName)
        {
            //get SOP instance info
            QueryOptions qoptions = new QueryOptions();
            string newSOPInstanceUID = string.Empty;
            SeriesData data = new SeriesData();

            qoptions.InstancesOptions = new InstancesQueryOptions();
            qoptions.InstancesOptions.SOPInstanceUID = OriginalSOPInstance;

            //InstanceData[] instances = _queryAddin.FindInstances(UserName, qoptions, null);

            //if (null == instances)
            //{
            //    throw new Exception("Original instance not found");
            //}
            //if (instances.Length == 0)
            //{
            //    throw new Exception("Original instance not found");
            //}

            //get object
            ObjectUID ouid = new ObjectUID();
            ouid.SOPInstanceUID = OriginalSOPInstance;

            GetDicomOptions options = new GetDicomOptions();
            options.StripImage = false;
            options.TransferSyntax = string.Empty;
            options.QualityFactor = -1;

            Stream stream = _objectRetrieveAddin.GetDicom(ouid, options);

            using (DicomDataSet dsOriginal = new DicomDataSet())
            {
                dsOriginal.Load(stream, DicomDataSetLoadFlags.None);

                //remove header
                string ImageBase64 = EncodedCapture.Substring(EncodedCapture.IndexOf(',') + 1);

                //decode to PNG image
                byte[] PNGImageBuf = Convert.FromBase64String(ImageBase64);

                using (MemoryStream ms = new MemoryStream(PNGImageBuf))
                {

                    using (Leadtools.Codecs.RasterCodecs rc = new Leadtools.Codecs.RasterCodecs())
                    {
                        RasterImage derivedImage = rc.Load(ms);

                        SeriesGenerator sg = new SeriesGenerator();
                        DicomDataSet dsDerived = sg.GenerateDerivedInstance(dsOriginal, derivedImage, SeriesDescription, SeriesNumber, ProtocolName, UserName);

                        newSOPInstanceUID = dsDerived.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);

                        data.Date = dsDerived.GetValue<string>(DicomTag.SeriesDate, string.Empty);
                        data.Description = dsDerived.GetValue<string>(DicomTag.SeriesDescription, string.Empty);
                        data.InstanceUID = dsDerived.GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);
                        data.Modality = dsDerived.GetValue<string>(DicomTag.Modality, string.Empty);
                        data.Number = dsDerived.GetValue<string>(DicomTag.SeriesNumber, string.Empty);
                        data.NumberOfRelatedInstances = "1";
                        data.StudyInstanceUID = dsDerived.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty);

                        data.Patient = new PatientData();
                        data.Patient.BirthDate = dsDerived.GetValue<string>(DicomTag.PatientBirthDate, string.Empty);
                        data.Patient.Comments = dsDerived.GetValue<string>(DicomTag.PatientComments, string.Empty);
                        data.Patient.ID = dsDerived.GetValue<string>(DicomTag.PatientID, string.Empty);
                        data.Patient.Name = dsDerived.GetValue<string>(DicomTag.PatientName, string.Empty);
                        data.Patient.Sex = dsDerived.GetValue<string>(DicomTag.PatientSex, string.Empty);

                        DoStore(dsDerived);
                    }
                }
            }

            _loggingAgent.CreateDerived(UserName, OriginalSOPInstance, newSOPInstanceUID);
            return data;
        }

        public void UpdatePatient(DicomDataSet ds)
        {
            INActionClientSessionProxy session = new NActionClientSessionProxy();
            ChangePatientCommand command = new ChangePatientCommand(session, ds);

            // 35102 -- UpdatePatient needs the DataAccess
            command.DataAccess = _storageAgent;
            command.Execute();
        }

        public bool DeletePatient(string patientId)
        {

            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();

#if TUTORIAL_CUSTOM_DATABASE
         // This version of FindPresentationInstance is part of the "Changing the LEAD HTML5 Medical Viewer to use a different database schema" tutorial
         // For more details, see the "Changing the LEAD HTML5 Medical Viewer to use a different database schema" tutorial.
            
         MyPatient patientEntity = new MyPatient(patientId);
#else
            Patient patientEntity = new Patient(patientId);
#endif
            matchingList.Add(patientEntity);
            matchingCollection.Add(matchingList);
            int count = _storageAgent.DeletePatient(matchingCollection);
            return (count > 0);
        }

        #endregion


        #region Annotations PresentationState

        public PresentationStateData StoreAnnotations(string userName, string seriesInstanceUID, string annotationData, string description, string userData)
        {
            DataSet seriesDs = FindSeries(seriesInstanceUID);
            DicomDataSet ds = SeriesGenerator.GeneratePresentationStateForAnnotations(userName, seriesInstanceUID, annotationData, description, userData, seriesDs);

            DoStore(ds);

            PresentationStateData presentationData = new PresentationStateData();

            presentationData.ContentCreatorName = ds.GetValue<string>(DicomTag.ContentCreatorName, string.Empty);
            presentationData.ContentDescription = ds.GetValue<string>(DicomTag.ContentDescription, string.Empty);
            presentationData.ContentLabel = ds.GetValue<string>(DicomTag.ContentLabel, string.Empty);
            presentationData.CreationDate = ds.GetValue<string>(DicomTag.PresentationCreationDate, string.Empty);
            presentationData.InstanceNumber = ds.GetValue<string>(DicomTag.InstanceNumber, string.Empty);
            presentationData.PatientID = ds.GetValue<string>(DicomTag.PatientID, string.Empty);
            presentationData.SeriesInstanceUID = ds.GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);
            presentationData.StudyInstanceUID = ds.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty);
            presentationData.SOPClassUID = ds.GetValue<string>(DicomTag.SOPClassUID, string.Empty);
            presentationData.SOPInstanceUID = ds.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
            presentationData.StationName = ds.GetValue<string>(DicomTag.StationName, string.Empty);
            presentationData.TransferSyntax = ds.GetValue<string>(DicomTag.TransferSyntaxUID, string.Empty);

            return presentationData;

        }


        public void StoreStudyLayout(string userName, string studyInstanceUID, StudyLayout studyLayout, string userData)
        {
            DataSet studyDataset = FindStudy(studyInstanceUID);
            DicomDataSet dcmStructuredDisplay;

            DeleteStudyLayout(studyInstanceUID, userData);
            dcmStructuredDisplay = BuildStructuredDisplay(userName, studyInstanceUID, studyDataset, studyLayout);
            if (dcmStructuredDisplay != null)
            {
                DoStore(dcmStructuredDisplay);
            }
        }

        public void DeleteStudyLayout(string studyInstanceUID, string userData)
        {
           // Study study = new Study() { StudyInstanceUID = studyInstanceUID };
           ICatalogEntity studyEntity = RegisteredEntities.GetStudyEntity(studyInstanceUID);

           // Series series = new Series() { Modality = "PR", SeriesDescription = "FOR STUDY LAYOUT" };
           Dictionary<long, object> seriesValues = new Dictionary<long, object>();
           seriesValues.Add(DicomTag.Modality, "PR");
           seriesValues.Add(DicomTag.SeriesDescription, "FOR STUDY LAYOUT");
           ICatalogEntity seriesEntity = RegisteredEntities.GetSeriesEntity(seriesValues);

           // Instance instance = new Instance() { SOPClassUID = DicomUidType.BasicStructuredDisplayStorage };
           Dictionary<long, object> instanceValues = new Dictionary<long, object>();
           instanceValues.Add(DicomTag.SOPClassUID, DicomUidType.BasicStructuredDisplayStorage);
           ICatalogEntity instanceEntity = RegisteredEntities.GetInstanceEntity(instanceValues);

           MatchingParameterCollection mpc = new MatchingParameterCollection();
           MatchingParameterList mpl = new MatchingParameterList();

           mpl.Add(studyEntity);
           mpl.Add(seriesEntity);
           mpl.Add(instanceEntity);
           mpc.Add(mpl);
           DataSet results = _storageAgent.QueryCompositeInstances(mpc);

           //
           // If there is already a layout we are going to delete it.
           //
           if (results.Tables[DataTableHelper.StudyTableName].Rows.Count != 0)
           {
              for (int i = 0; i < results.Tables[DataTableHelper.SeriesTableName].Rows.Count; i++)
              {
                 DataRow row = results.Tables[DataTableHelper.SeriesTableName].Rows[i];
                 string seriesInstanceUID = RegisteredDataRows.SeriesInfo.GetElementValue(row, DicomTag.SeriesInstanceUID);

                 ICatalogEntity seriesEntity2 = RegisteredEntities.GetSeriesEntity(seriesInstanceUID);

                 MatchingParameterCollection prMpc = new MatchingParameterCollection();
                 MatchingParameterList prMp = new MatchingParameterList();

                 prMp.Add(seriesEntity2);
                 prMpc.Add(prMp);
                 _storageAgent.DeleteSeries(prMpc);
              }
           }
        }

        public void SetDisplaySetsSequence(HangingProtocolEx protocol, WCFHangingProtocol hangingProtocol)
        {
           int imageBoxNumber = 1;

           for (int i = 0; i < hangingProtocol.DisplaySets.Count; i++)
           {
              DisplaySetEx displaySet = new DisplaySetEx();
              WCFDisplaySet wcfDisplaySet = hangingProtocol.DisplaySets[i];

              // Display Set Number (Mandatory)
              displaySet.DisplaySetNumber = wcfDisplaySet.DisplaySetNumber;

              // Display Set Label (Optional)
              displaySet.DisplaySetLabel = wcfDisplaySet.DisplaySetLabel;

              // Display Set Presentation Group (Mandatory)
              displaySet.DisplaySetPresentationGroup = wcfDisplaySet.DisplaySetPresentationGroup;

              // Image Set Number (Mandatory)
              displaySet.ImageSetNumber = wcfDisplaySet.ImageSetNumber;

              // Image Boxes Sequence (Mandatory)
              for (int j = 0; j < wcfDisplaySet.Boxes.Count; j++)
              {
                 DataContracts.ImageBox box = wcfDisplaySet.Boxes[j];
                 HPWCFImageBox dsBox = new HPWCFImageBox();

                 box.CopyAllTo<HPWCFImageBox>(dsBox);
                 if (displaySet.ImageBoxesSequence == null)
                    displaySet.ImageBoxesSequence = new List<HPWCFImageBox>();
                 dsBox.DisplayEnvironmentSpatialPosition = box.Position.ToCoordinate().ToList();
                 if (box.RowPosition != -1 && box.ColumnPosition != -1)
                 {
                    dsBox.Position = new List<double>();

                    dsBox.ImageDisplayFormat = string.Format(@"STANDARD\{0},{1}", box.ColumnPosition, box.RowPosition);
                    dsBox.Position.Add(box.NumberOfRows);
                    dsBox.Position.Add(box.NumberOfColumns);
                 }
                 dsBox.ImageBoxNumber = imageBoxNumber++;
                 dsBox.ImageBoxLayoutType = box.ImageBoxLayoutType;
                 displaySet.ImageBoxesSequence.Add(dsBox);
              }

              // Filter Operations Sequence (Mandatory)
              displaySet.FilterOperationsSequence = wcfDisplaySet.FilterOperationsSequence;
              displaySet.CorrectSelectorAttributes();

              // Sorting Operations Sequence (Mandatory)
              displaySet.SortingOperationsSequence = wcfDisplaySet.SortingOperationsSequence;

              // Blending Operation Type (Optional)
              // xxx

              // Reformatting Operation Type (Optional)
              displaySet.ReformattingOperationType = wcfDisplaySet.ReformattingOperationType;

              // Reformatting Thickness (Conditional)
              displaySet.ReformattingThickness = wcfDisplaySet.ReformattingThickness;

              // Reformatting Interval (Conditional)
              displaySet.ReformattingInterval = wcfDisplaySet.ReformattingInterval;

              // Reformatting Operation Initial View Direction (Conditional)
              displaySet.ReformattingOperationInitialViewDirection = wcfDisplaySet.ReformattingOperationInitialViewDirection;

              // 3D Rendering Type (Conditional)
              // xxx

              // Display Set Patient Orientation (Optional)
              displaySet.DisplaySetPatientOrientation = wcfDisplaySet.DisplaySetPatientOrientation;

              // Display Set Horizontal Justification (Optional)
              displaySet.DisplaySetHorizontalJustification = wcfDisplaySet.DisplaySetHorizontalJustification;

              // Display Set Vertical Justification (Optional)
              displaySet.DisplaySetVerticalJustification = wcfDisplaySet.DisplaySetVerticalJustification;

              // VOI Type (Optional)
              displaySet.VoiType = wcfDisplaySet.VoiType;

              // Pseudo-Color Type (Optional)
              // xxx

              // Pseudo-Color Palette Instance Reference Sequence (Conditional)
              // xxx

              // Show Grayscale Inverted (Optional)
              displaySet.ShowGrayscaleInverted = wcfDisplaySet.ShowGrayscaleInverted;

              // Show Image True Size Flag (Optional)
              displaySet.ShowImageTrueSizeFlag = wcfDisplaySet.ShowImageTrueSizeFlag;

              // Show Graphic Annotation Flag (Optional)
              displaySet.ShowGraphicAnnotationFlag = wcfDisplaySet.ShowGraphicAnnotationFlag;

              // Show Patient Demographics Flag (Optional)
              displaySet.ShowPatientDemographicsFlag = wcfDisplaySet.ShowPatientDemographicsFlag;

              // Show Acquisition Techniques Flag (Optional)
              // xxx

              // Display Set Presentation Group Description (Optional)
              // xxx

              foreach (FilterOperation filterOperation in displaySet.FilterOperationsSequence)
              {
                 if (filterOperation.SelectorAttribute.HasValue)
                 {
                    DicomTag tag = DicomTagTable.Instance.Find(filterOperation.SelectorAttribute.Value);

                    if (tag != null)
                    {
                       filterOperation.SelectorAttributeVR = tag.VR.ToString();
                       if (!string.IsNullOrEmpty(filterOperation.SelectorValue))
                       {
                          if (tag.VR != DicomVRType.SQ)
                          {
                             SetVrValue(filterOperation, tag.VR);
                          }
                          else
                          {
                             filterOperation.SelectorAttributeVR = "SQ";
                             // filterOperation.SelectorSequencePointer.Clear();

                             // For this implementation, there will always be a FilterByOperator
                             if (filterOperation.FilterByOperator == null)
                             {
                                filterOperation.FilterByOperator = FilterByOperator.MemberOf;
                             }

                             // SelectorValueNumber is required for our implementation
                             // From the DICOM specification: Required if Selector Attribute (0072,0026) and Filter-by Operator (0072,0406) are present
                             if (filterOperation.SelectorValueNumber == null)
                             {
                                filterOperation.SelectorValueNumber = 0;
                             }
                          }
                       }
                    }
                 }
                 else
                 {
                    if (!string.IsNullOrEmpty(filterOperation.SelectorValue))
                    {
                       if (filterOperation.FilterByCategory == "IMAGE_PLANE")
                       {
                          filterOperation.SelectorAttributeVR = "CS";
                          filterOperation.SelectorAttribute = null;
                          filterOperation.SelectorCSValue = filterOperation.SelectorValue;
                       }
                    }
                 }
              }

              if (protocol.DisplaySetsSequence == null)
                 protocol.DisplaySetsSequence = new List<DisplaySetEx>();
              protocol.DisplaySetsSequence.Add(displaySet);
           }
        }

        public void StoreHangingProtocol(string userName, WCFHangingProtocol hangingProtocol, string userData)
        {
           HangingProtocolEx protocol = new HangingProtocolEx();

           // Hanging Protocol Name (Mandatory)
           protocol.HangingProtocolName = hangingProtocol.HangingProtocolName;

           // Hanging Protocol Description (Mandatory)
           protocol.HangingProtocolDescription = hangingProtocol.HangingProtocolDescription;

           // Hanging Protocol Level (Mandatory)
           protocol.HangingProtocolLevel = hangingProtocol.HangingProtocolLevel;

           // Hanging Protocol Creator (Mandatory)
           protocol.HangingProtocolCreator = hangingProtocol.HangingProtocolCreator;

           // Hanging Protocol Creation DateTime (Mandatory)
           protocol.HangingProtocolCreationDateTime = hangingProtocol.HangingProtocolCreationDateTime;

           // Hanging Protocol Definition Sequence (Mandatory)
           protocol.HangingProtocolDefinitionSequence = hangingProtocol.HangingProtocolDefinitionSequence;
           protocol.NormalizeHangingProtocolDefinitionSequence();

           // Hanging Protocol User Identification Code Sequence (Mandatory)
           protocol.HangingProtocolUserIdentificationCodeSequence = hangingProtocol.HangingProtocolUserIdentificationCodeSequence;

           // Hanging Protocol User Group Name (Optional)
           if (hangingProtocol.HangingProtocolLevel.HasValue && hangingProtocol.HangingProtocolLevel.Value == HangingProtocolLevel.UserGroup)
           {
              protocol.HangingProtocolUserGroupName = hangingProtocol.HangingProtocolUserGroupName;
           }

           // Source Hanging Protocol Sequence (Optional)
           // xxx

           // Number of Priors Referenced (Mandatory)
           protocol.NumberOfPriorsReferenced = hangingProtocol.NumberOfPriorsReferenced;

           // Image Sets Sequence (Mandatory)
           protocol.ImageSetsSequence = hangingProtocol.ImageSetsSequence;

           // Number of Screens (Mandatory)
           protocol.NumberOfScreens = hangingProtocol.NumberOfScreens;

           // Nominal Screen Definition Sequence (Mandatory)
           protocol.NominalScreenDefinitionSequence = hangingProtocol.NominalScreenDefinitionSequence;

           // Display Sets Sequence (Mandatory)
           SetDisplaySetsSequence(protocol, hangingProtocol);

           // Partial Data Display Handling (Mandatory)
           protocol.PartialDataDisplayHandling = hangingProtocol.PartialDataDisplayHandling;

           // Synchronized Scrolling Sequence (Optional)
           protocol.SynchronizedScrollingSequence = hangingProtocol.SynchronizedScrollingSequence;

           // Navigation Indicator Sequence (Optional)
           protocol.NavigationIndicatorSequence = hangingProtocol.NavigationIndicatorSequence;

           using (DicomDataSet dicom = new DicomDataSet())
           {
              dicom.Initialize(DicomClassType.HangingProtocolStorage, DicomDataSetInitializeFlags.AddMandatoryElementsOnly);

              dicom.RemoveTag(DicomTag.ImageSetsSequence);
              dicom.RemoveTag(DicomTag.DisplaySetsSequence);
              dicom.RemoveTag(DicomTag.NominalScreenDefinitionSequence);
              dicom.RemoveTag(DicomTag.HangingProtocolDefinitionSequence);

              //protocol.NominalScreenDefinitionSequence = new List<NominalScreenDefinition>();
              //protocol.NominalScreenDefinitionSequence.Add(new NominalScreenDefinition()
              //{
              //   NumberOfHorizontalPixels = 1024,
              //   NumberOfVerticalPixels = 768,
              //   DisplayEnvironmentSpatialPosition = new List<float> { 0, 1, 1, 0 },
              //   ScreenMinimumColorBitDepth = 8
              //});

              for (int i = 0; i < protocol.ImageSetsSequence.Count; i++)
              {
                 ImageSet set = protocol.ImageSetsSequence[i];

                 for (int j = 0; j < set.ImageSetSelectorSequence.Count; j++)
                 {
                    ImageSetSelector selector = set.ImageSetSelectorSequence[j];
                    DicomTag tag = DicomTagTable.Instance.Find(selector.SelectorAttribute);

                    if (tag != null)
                    {
                       if (tag.VR != DicomVRType.SQ)
                       {
                          selector.SelectorAttributeVR = tag.VR.ToString();
                          if (!string.IsNullOrEmpty(selector.SelectorValue))
                          {
                             SetVrValue(selector, tag.VR);
                          }
                       }
                       else
                       {
                          selector.SelectorAttributeVR = "SQ";
                          selector.SelectorSequencePointer = null;
                       }
                    }
                 }
              }

              // 
              if (protocol.HangingProtocolUserIdentificationCodeSequence == null || protocol.HangingProtocolUserIdentificationCodeSequence.Count == 0)
              {
                 dicom.RemoveTag(DicomTag.HangingProtocolUserIdentificationCodeSequence);
                 dicom.InsertElementAndSetValue(DicomTag.HangingProtocolUserIdentificationCodeSequence, "");
              }

              dicom.InsertElementAndSetValue(DicomTag.SOPInstanceUID, SeriesGenerator.GenerateDicomUniqueIdentifier());
              protocol.ImageDisplayFormat = string.Format(@"STANDARD\{0},{1}", hangingProtocol.Columns, hangingProtocol.Rows);

              dicom.Set(protocol);

              DoStore(dicom);
           }
        }

        private static object GetPropertyValue(object item, string propertyName)
        {
           //returns value of property Name
           return item.GetType().GetProperty(propertyName).GetValue(item, null);
        } 

        public void SetVrValue(object item, DicomVRType vr /*, bool multipleValues*/)
        {
           PropertyInfo property = item.GetType().GetProperty("Selector" + vr.ToString() + "Value");
           PropertyInfo valueProperty = item.GetType().GetProperty("SelectorValue");


           if (property != null && valueProperty != null)
           {
              object value = valueProperty.GetValue(item, null);

              object objectValueNumber = GetPropertyValue(item, "SelectorValueNumber");
              int selectorValueNumber = Convert.ToInt32(objectValueNumber);

              Type t = property.PropertyType;
              bool isStringType = t.IsAssignableFrom(typeof (string));

              if (isStringType)
              {
                 // do nothing
              }
              else
              {
                 string inputString = value as string;
                 if (inputString != null)
                 {
                    char[] splitChars = new char[] { '\\' };
                    string[] values = inputString.Split(splitChars);

                    value = values;

                    //if (selectorValueNumber > values.Length)
                    //{
                    //   selectorValueNumber = 1;
                    //}
                    //value = values[selectorValueNumber - 1];
                 }
              }

              property.SetValue(item, AddInsUtils.ConvertToPropertyType(property, value), null);
           }
        }       


        public void DeletePresentationState(string sopInstanceUID, string userData)
        {
            if (string.IsNullOrEmpty(sopInstanceUID))
            {
                throw new Exception("Invalid SOP Instance UID");
            }

            MatchingParameterCollection matchingCollection;
            DataSet instanceDs = FindPresentationInstance(sopInstanceUID, out matchingCollection);

            if (null == instanceDs || instanceDs.Tables[DataTableHelper.InstanceTableName].Rows.Count == 0)
            {
                throw new Exception("No presentation state found matching requested instance");
            }

            _storageAgent.DeleteInstance(matchingCollection);

            DicomInstanceDeleteCommand delCmd = new DicomInstanceDeleteCommand(_storageAgent);

            delCmd.DeleteInstances(new DataRow[] { instanceDs.Tables[DataTableHelper.InstanceTableName].Rows[0] });

        }


        public static CStoreCommandConfiguration GetStoreCommandConfiguration(StoreAddInConfigurationElement settings)
        {
            CStoreCommandConfiguration c = new CStoreCommandConfiguration();

            // Set the default store location

            c.DataSetStorageLocation = settings.StorageLocation;
            c.DicomFileExtension = settings.StoreFileExtension;

            // Set the default Overwrite location
            c.OverwriteBackupLocation = settings.OverwriteBackupLocation;

            // Set the default Backup location

            // Set the default CStoreFailures location
            //string storeFailuresLocation = Path.Combine(storeLocation, "StoreFailures");
            //settings.StoreAddIn.CStoreFailuresPath = Path.Combine(storeFailuresLocation, serviceName);

            c.DirectoryStructure.CreatePatientFolder = settings.DirectoryStructure.CreatePatientFolder;
            c.DirectoryStructure.CreateSeriesFolder = settings.DirectoryStructure.CreateSeriesFolder;
            c.DirectoryStructure.CreateStudyFolder = settings.DirectoryStructure.CreateStudyFolder;
            c.DirectoryStructure.UsePatientName = settings.DirectoryStructure.UsePatientName;
            c.DirectoryStructure.SplitPatientId = settings.DirectoryStructure.SplitPatientId;
            c.SaveThumbnail = settings.CreateThumbnailImage;

            return c;
        }

        private static string GetFileNameWithFormatExt(string dicomImagePath, RasterImageFormat extFormat, bool isThumb)
        {
            string newImagePath;
            string ext;
            string qualifier;

            ext = GetExtension(extFormat, out qualifier);
            newImagePath = Path.Combine(Path.GetDirectoryName(dicomImagePath), Path.GetFileNameWithoutExtension(dicomImagePath));
            newImagePath += "." + ext;
            return newImagePath;
        }

        private static string GetExtension(RasterImageFormat rasterImageFormat, out string extensionQualifier)
        {
            string ext = rasterImageFormat.ToString().ToLower();

            extensionQualifier = null;
            if (ext.Contains("tifj2k"))
            {
                extensionQualifier = ext.Replace("tifj2k", string.Empty);

                return "tif";
            }

            return ext;
        }

        private static void AddDataToImage(RasterImage rasterImage, DicomAutoScaleData data)
        {
            RasterTagMetadata autoScaleData = new RasterTagMetadata();
            autoScaleData.Id = 0x8001;
            autoScaleData.DataType = RasterTagMetadataDataType.Double;
            Double[] doubleArray = new Double[2];
            doubleArray[0] = data.AutoScaleIntercept;
            doubleArray[1] = data.AutoScaleSlope;
            autoScaleData.FromDouble(doubleArray);
            rasterImage.Tags.Add(autoScaleData);
        }

        private static void GenerateImage(RasterImage rasterImage, Leadtools.Codecs.RasterCodecs codec, string newimagePath, RasterImageFormat format,
                                   int pageIndex, List<ReferencedImages> images, Action<RasterImage> beforeSave, DicomAutoScaleData data)
        {
            try
            {
                if (null != rasterImage)
                {
                    int frameCount;

                    frameCount = rasterImage.PageCount;

                    if (rasterImage.Signed || rasterImage.GrayscaleMode == RasterGrayscaleMode.OrderedInverse)
                    {
                        for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                        {
                            rasterImage.Page = frameIndex + 1;
                        }
                    }

                    if (IsFormatSupportMultiPage(format) && (-1 == pageIndex))
                    {
                        LeadSizeD size = LeadSizeD.Create(rasterImage.Width, rasterImage.Height);

                        if (File.Exists(newimagePath))
                        {
                            try
                            {
                                //try to delete the old file, it not successful then we will still try to save to it.
                                File.Delete(newimagePath);
                            }
                            catch (Exception)
                            { }
                        }

                        if (beforeSave != null)
                            beforeSave(rasterImage);


                        AddDataToImage(rasterImage, data);
                        codec.Options.Save.Tags = true;
                        //PyramidImage.Save(rasterImage, newimagePath, codec);
                        images.Add(new ReferencedImages(0, 0, 2, -1, newimagePath, format, false));
                    }
                    else if (pageIndex == -1)
                    {
                        string ext;
                        string frameName;

                        ext = Path.GetExtension(newimagePath);
                        frameName = Path.Combine(Path.GetDirectoryName(newimagePath), Path.GetFileNameWithoutExtension(newimagePath));

                        for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                        {
                            string newFramePath;

                            rasterImage.Page = frameIndex + 1;
                            newFramePath = frameName + "(" + frameIndex.ToString() + ")";
                            newFramePath += ext;

                            if (beforeSave != null)
                                beforeSave(rasterImage);
                            AddDataToImage(rasterImage, data);
                            codec.Options.Save.Tags = true;
                            //PyramidImage.Save(rasterImage, newFramePath, codec);
                            images.Add(new ReferencedImages(0, 0, 2, frameIndex, newFramePath, format, false));
                        }
                    }
                    else
                    {
                        rasterImage.Page = pageIndex + 1;

                        if (beforeSave != null)
                            beforeSave(rasterImage);
                        AddDataToImage(rasterImage, data);
                        codec.Options.Save.Tags = true;
                        //PyramidImage.Save(rasterImage, newimagePath, codec);
                        images.Add(new ReferencedImages(0, 0, 2, pageIndex, newimagePath, format, false));
                    }

                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        private static bool IsFormatSupportMultiPage(RasterImageFormat format)
        {
            switch (format)
            {
                case RasterImageFormat.DicomColor:
                case RasterImageFormat.DicomGray:
                case RasterImageFormat.DicomJ2kColor:
                case RasterImageFormat.DicomJ2kGray:
                case RasterImageFormat.DicomJpegColor:
                case RasterImageFormat.DicomJpegGray:
                case RasterImageFormat.DicomRleColor:
                case RasterImageFormat.DicomRleGray:
                case RasterImageFormat.Tif:
                case RasterImageFormat.TifJpeg:
                case RasterImageFormat.Jp2:
                case RasterImageFormat.Jpx:
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }
        private DataSet FindPresentationInstance(string sopInstanceUID, out MatchingParameterCollection matchingCollection)
        {
            matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();

#if TUTORIAL_CUSTOM_DATABASE
            // This version of FindPresentationInstance is part of the "Changing the LEAD HTML5 Medical Viewer to use a different database schema" tutorial
            // While the tutorial database schema does not store presentation state information, it does store presentation state instances.
            // For the tutorial, this method fills the properties of custom classes MySeries and MyInstance with the presentation state modality of "PR",
            // and adds these classes to a 'matchingList' so that the stored presentation state instances can be deleted from the custom database
            // For more details, see the "Changing the LEAD HTML5 Medical Viewer to use a different database schema" tutorial.
            
            MySeries seriesEntity = new MySeries();
            MyInstance instanceEntity = new MyInstance ( sopInstanceUID ) ;
            seriesEntity.SeriesModality = "PR" ;
#else
            Series seriesEntity = new Series();
            Instance instanceEntity = new Instance(sopInstanceUID);
            seriesEntity.Modality = "PR";
#endif
            matchingList.Add(instanceEntity);
            matchingList.Add(seriesEntity);
            matchingCollection.Add(matchingList);

            return _storageAgent.QueryCompositeInstances(matchingCollection);
        }

        private DataSet FindSeries(string seriesInstanceUID)
        {
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();

            ICatalogEntity seriesEntity = RegisteredEntities.GetSeriesEntity(seriesInstanceUID);

            matchingList.Add(seriesEntity);
            matchingCollection.Add(matchingList);

            return _storageAgent.QuerySeries(matchingCollection);
        }

        private DataSet FindStudy(string studyInstanceUID)
        {
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();

            ICatalogEntity studyEntity = RegisteredEntities.GetStudyEntity(studyInstanceUID);

            matchingList.Add(studyEntity);
            matchingCollection.Add(matchingList);

            return _storageAgent.QueryStudies(matchingCollection);
        }

        private DicomDataSet BuildStructuredDisplay(string seriesInstanceUID, string templateId, DataSet seriesDataset, Leadtools.Medical.WebViewer.DataContracts.ImageBox[] boxes)
        {
            IInstanceInfo instanceInfo = RegisteredDataRows.InstanceInfo;
            ISeriesInfo seriesInfo = RegisteredDataRows.SeriesInfo;
            IStudyInfo studyInfo = RegisteredDataRows.StudyInfo;
            IPatientInfo patientInfo = RegisteredDataRows.PatientInfo;
            StructuredDisplayImageBoxModule ib = new StructuredDisplayImageBoxModule();
            CustomStructuredDisplayModule sd = null;
            DicomDataSet sdDataset;
            DataRow studyRow = seriesInfo.GetStudyRow(seriesDataset.Tables[DataTableHelper.SeriesTableName].Rows[0]);
            DataRow patientRow = studyInfo.GetPatientRow(studyRow);

            sd = GetStructuredDisplayModule(seriesInstanceUID, studyInfo, studyRow, patientInfo, patientRow, out sdDataset);
            foreach (Leadtools.Medical.WebViewer.DataContracts.ImageBox box in boxes)
            {
                SDImageBox imageBox = new SDImageBox() { ImageBoxLayoutType = ImageBoxLayoutType.Single };

                if (box.referencedSOPInstanceUID.Count > 0)
                {
                    DataRow instanceRow = AddInsUtils.GetDicomInstanceRow(_storageAgent, box.referencedSOPInstanceUID[0]);

                    if (instanceRow != null)
                    {
                        string sopClassUID = instanceRow["SOPClassUID"].ToString();
                        string sopInstanceUID = instanceRow["SOPInstanceUID"].ToString();
                        StructuredDisplayReferencedImage reference = imageBox.AddReferencedImage(sopClassUID, sopInstanceUID);

                        sd.AddReferencedImage(sopClassUID, sopInstanceUID);
                        imageBox.ReferencedImageSequence.Add(reference);
                    }
                }
                imageBox.DisplayEnvironmentSpatialPosition = box.Position.ToCoordinate().ToList();
                ib.StructuredDisplayImageBoxSequence.Add(imageBox);
            }

            if (!string.IsNullOrEmpty(templateId))
                sdDataset.InsertElementAndSetValue(DicomTag.TemplateIdentifier, templateId);

            sdDataset.Set(sd);
            sdDataset.Set(ib);
            sdDataset.RemoveTag(DicomTag.PresentationCreationDate);
            sdDataset.RemoveTag(DicomTag.PresentationCreationTime);

           sdDataset.InsertElementAndSetValue(null, true, DicomTag.SOPClassUID,
                                              DicomUidType.BasicStructuredDisplayStorage);

            return sdDataset;
        }

        private DicomDataSet BuildStructuredDisplay(string userName, string studyInstanceUID, DataSet studyDataset, StudyLayout studyLayout)
        {
            IInstanceInfo instanceInfo = RegisteredDataRows.InstanceInfo;
            ISeriesInfo seriesInfo = RegisteredDataRows.SeriesInfo;
            IStudyInfo studyInfo = RegisteredDataRows.StudyInfo;
            IPatientInfo patientInfo = RegisteredDataRows.PatientInfo;

            StructuredDisplayImageBoxModule ib = new StructuredDisplayImageBoxModule();
            CustomStructuredDisplayModule sd = null;
            DicomDataSet sdDataset;
            DataRow studyRow = studyDataset.Tables[DataTableHelper.StudyTableName].Rows[0];
            DataRow patientRow = studyInfo.GetPatientRow(studyRow);
            AnnCodecs codec = new AnnCodecs();
            Dictionary<string, List<string>> annotations = new Dictionary<string, List<string>>();
            Dictionary<string, string> annSops = new Dictionary<string, string>();
            PresentationStateData data;

            sd = GetStructuredDisplayModule(studyInfo, studyRow, patientInfo, patientRow, out sdDataset);
            foreach (SeriesInfo item in studyLayout.Series)
            {
                ExtendedReferenceSeries rs = null;

                if (item.SeriesInstanceUID != string.Empty)
                {
                    rs = new ExtendedReferenceSeries() { ImageBoxNumber = item.ImageBoxNumber };
                    rs.SeriesInstanceUID = item.SeriesInstanceUID;
                    rs.ReferencedImageSequence = new List<SopInstanceReference>();
                    sd.ReferencedSeriesSequence.Add(rs);
                }

                data = LoadSeriesAnnotations(codec, item.SeriesInstanceUID, item.AnnotationData, annotations, userName);
                if (data != null)
                    annSops[item.SeriesInstanceUID] = data.SOPInstanceUID;
            }            

            foreach (OtherStudies item in studyLayout.OtherStudies)
            {
                OtherStudyReference osr = new OtherStudyReference();

                osr.StudyInstanceUID = item.StudyInstanceUID;
                osr.ReferencedSeriesSequence = new List<ExtendedReferenceSeries>();
                foreach (SeriesInfo series in item.Series)
                {
                    ExtendedReferenceSeries rs = null;

                    rs = new ExtendedReferenceSeries() { ImageBoxNumber = series.ImageBoxNumber };
                    rs.SeriesInstanceUID = series.SeriesInstanceUID;
                    rs.ReferencedInstanceSequence = new List<SopInstanceReference>();
                    osr.ReferencedSeriesSequence.Add(rs);
                    data = LoadSeriesAnnotations(codec, series.SeriesInstanceUID, series.AnnotationData, annotations, userName);
                    if (data != null)
                        annSops[series.SeriesInstanceUID] = data.SOPInstanceUID;
                }

                sd.StudyContainingOtherReferences.Add(osr);                
            }

            foreach (Leadtools.Medical.WebViewer.DataContracts.ImageBox box in studyLayout.Boxes)
            {
                ExtendedSDImageBox imageBox = new ExtendedSDImageBox();
                                                                          
                if (box.referencedSOPInstanceUID.Count > 0)
                {
                    ExtendedReferenceSeries rs = (from s in sd.ReferencedSeriesSequence
                                                  where s.ImageBoxNumber == box.ImageBoxNumber
                                                  select s).FirstOrDefault();
                    DataRow instanceRow = AddInsUtils.GetDicomInstanceRow(_storageAgent, box.referencedSOPInstanceUID[0]);

                    if(rs == null)
                    {
                        rs = (from s in sd.StudyContainingOtherReferences
                              from r in s.ReferencedSeriesSequence
                              where r.ImageBoxNumber == box.ImageBoxNumber
                              select r).FirstOrDefault();
                    }

                    if (instanceRow != null)
                    {
                       string sopClassUID = instanceInfo.GetElementValue(instanceRow, DicomTag.SOPClassUID);
                       string sopInstanceUID = instanceInfo.GetElementValue(instanceRow, DicomTag.SOPInstanceUID);
                        StructuredDisplayReferencedImage reference = imageBox.AddReferencedImage(sopClassUID, sopInstanceUID);

                        if (rs != null)
                        {
                            if (rs.ReferencedImageSequence != null)
                                rs.ReferencedImageSequence.Add(new SopInstanceReference() { ReferencedSopClassUid = sopClassUID, ReferencedSopInstanceUid = sopInstanceUID });
                            else
                                rs.ReferencedInstanceSequence.Add(new SopInstanceReference() { ReferencedSopClassUid = sopClassUID, ReferencedSopInstanceUid = sopInstanceUID });
                        }

                        imageBox.ReferencedImageSequence.Add(reference);

                        if (rs != null && annotations.ContainsKey(rs.SeriesInstanceUID))
                        {
                            string sopInstance = (from sop in annotations[rs.SeriesInstanceUID]
                                                  where sop == sopInstanceUID
                                                  select sop).FirstOrDefault();
                            
                            if(!string.IsNullOrEmpty(sopInstance))
                            {
                                imageBox.ReferencedPresentationStateSequence = new List<SopInstanceReference>();
                                imageBox.ReferencedPresentationStateSequence.Add(new SopInstanceReference() { ReferencedSopClassUid = sopClassUID, ReferencedSopInstanceUid = annSops[rs.SeriesInstanceUID] });
                            } 
                        }
                    }
                }
                imageBox.DisplayEnvironmentSpatialPosition = box.Position.ToCoordinate().ToList();
                imageBox.ImageBoxNumber = box.ImageBoxNumber;
                imageBox.ImageBoxLayoutType = box.ImageBoxLayoutType;

                if(box.FirstFrame!=null)               
                {
                    ImageSopInstanceReference imgSopRef = new ImageSopInstanceReference() { ReferencedFrameNumber = new List<int>() };

                    imageBox.ReferencedFirstFrameSequence = new List<ImageSopInstanceReference>();                    
                    imgSopRef.ReferencedFrameNumber.Add(box.FirstFrame.FrameNumber);
                    imgSopRef.ReferencedSopInstanceUid = box.FirstFrame.SOPInstanceUID;
                    imgSopRef.ReferencedSopClassUid = box.FirstFrame.SOPClassUID;
                    imageBox.ReferencedFirstFrameSequence.Add(imgSopRef);
                }

                if (box.RowPosition != -1 && box.ColumnPosition != -1)
                {
                    imageBox.ImageDisplayFormat = string.Format(@"STANDARD\{0},{1}", box.ColumnPosition, box.RowPosition);
                    imageBox.Rows = box.NumberOfRows;
                    imageBox.Columns = box.NumberOfColumns;
                }

                imageBox.DisplaySetHorizontalJustification = box.HorizontalJustification;
                imageBox.DisplaySetVerticalJustification = box.VerticalJustification;
                
                if (box.ImageBoxTileHorizontalDimension.HasValue)
                {
                   imageBox.ImageBoxTileHorizontalDimension = box.ImageBoxTileHorizontalDimension.Value;
                }

                if (box.ImageBoxTileVerticalDimension.HasValue)
                {
                   imageBox.ImageBoxTileVerticalDimension = box.ImageBoxTileVerticalDimension.Value;
                }

                //if (box.WindowCenter!=-1 || box.WindowWidth!=-1)
                //{
                //    DicomDataSet ps = SeriesGenerator.GeneratePresentationState(sdDataset.GetValue<string>())
                //}

                ib.StructuredDisplayImageBoxSequence.Add(imageBox);
            }


            sdDataset.InsertElementAndSetValue(DicomTag.SeriesDescription, "FOR STUDY LAYOUT");
            if (studyLayout.Rows != -1 && studyLayout.Columns != -1)
            {
                string layoutData = string.Format(@"STANDARD\{0},{1}", studyLayout.Columns, studyLayout.Rows);

                sdDataset.InsertElementAndSetValue(DicomTag.ImageDisplayFormat, layoutData);
            }

            sdDataset.Set(sd);
            sdDataset.Set(ib);            

            sdDataset.RemoveTag(DicomTag.PresentationCreationDate);
            sdDataset.RemoveTag(DicomTag.PresentationCreationTime);            

            return sdDataset;
        }

        private PresentationStateData LoadSeriesAnnotations(AnnCodecs codec, string seriesInstanceUID, string annotationData, Dictionary<string,List<string>> annotations, string userName)
        {
            if (!string.IsNullOrEmpty(annotationData))
            {                
                annotations[seriesInstanceUID] = new List<string>();
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(annotationData)))
                {
                    AnnCodecsInfo codecInfo;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    ms.Position = 0;
                    codecInfo = codec.GetInfo(ms);
                    ms.Position = 0;

                    for (int index = 0; index < codecInfo.Pages.Length; index++)
                    {
                        AnnContainer container = codec.Load(ms, codecInfo.Pages[index]);
                        AnnUserData refInstance = (AnnUserData)serializer.Deserialize<AnnUserData>(container.UserData.ToString());

                        ms.Position = 0;
                        if(refInstance!=null && refInstance.ReferencedImageSequence!=null)
                        {
                            annotations[seriesInstanceUID].Add(refInstance.ReferencedImageSequence.ReferencedSopInstanceUid);
                        }
                    }
                }
                return StoreAnnotations(userName, seriesInstanceUID, annotationData, "", string.Empty);
            }
            return null;
        }

        private CustomStructuredDisplayModule GetStructuredDisplayModule(string seriesInstanceUID, IStudyInfo studyInfo, DataRow studyRow, IPatientInfo patientInfo, DataRow patientRow, out DicomDataSet sdDisplay)
        {
            CustomStructuredDisplayModule sd = new CustomStructuredDisplayModule(seriesInstanceUID);

            return BuildModule(string.Empty, sd, studyInfo, studyRow, patientInfo, patientRow, out sdDisplay);
        }

        private CustomStructuredDisplayModule GetStructuredDisplayModule(IStudyInfo studyInfo, DataRow studyRow, IPatientInfo patientInfo, DataRow patientRow, out DicomDataSet sdDisplay)
        {
            CustomStructuredDisplayModule sd = new CustomStructuredDisplayModule();

            return BuildModule(string.Empty, sd, studyInfo, studyRow, patientInfo, patientRow, out sdDisplay);
        }

        private static CustomStructuredDisplayModule BuildModule(string userName, CustomStructuredDisplayModule sd, IStudyInfo studyInfo, DataRow studyRow, IPatientInfo patientInfo, DataRow patientRow, out DicomDataSet sdDisplay)
        {
            DicomElement element = null;

            sd.NumberOfScreens = 1;
            sd.ContentIdentification = new ContentIdentification();
            sd.ContentIdentification.ContentCreatorName = ConfigurationManager.AppSettings["SDContentCreator"];
            sd.ContentIdentification.ContentDescription = ConfigurationManager.AppSettings["SDContentDescription"];
            sd.ContentIdentification.ContentLabel = "STRUCTURED DISPLAY";
            sd.NominalScreenDefinitionSequence = new List<NominalScreenDefinition>();
            sd.NominalScreenDefinitionSequence.Add(new NominalScreenDefinition()
            {
                NumberOfHorizontalPixels = 1024,
                NumberOfVerticalPixels = 768,
                DisplayEnvironmentSpatialPosition = new List<float>() { 0, 1, 1, 0 },
                ScreenMinimumColorBitDepth = 8
            });

            sdDisplay = new DicomDataSet();
            sdDisplay.Initialize(DicomClassType.BasicStructuredDisplayStorage, DicomDataSetInitializeFlags.AddMandatoryElementsOnly | DicomDataSetInitializeFlags.AddMandatoryModulesOnly);
            sdDisplay.InsertElementAndSetValue(DicomTag.Manufacturer, ConfigurationManager.AppSettings["SDManufacturer"]);
            sdDisplay.InsertElementAndSetValue(DicomTag.StudyInstanceUID, studyInfo.GetElementValue(studyRow, DicomTag.StudyInstanceUID));

            string studyDateString = studyInfo.GetElementValue(studyRow, DicomTag.StudyDate);
            DateTime? studyDate = null;
            if (!string.IsNullOrEmpty(studyDateString))
            {
               studyDate = DateTime.Parse(studyDateString);
            }

            sdDisplay.InsertElementAndSetValue(DicomTag.StudyDate, studyDate);
            sdDisplay.InsertElementAndSetValue(DicomTag.StudyTime, studyDate);

            sdDisplay.InsertElementAndSetValue(DicomTag.SeriesDate, DateTime.Now);
            sdDisplay.InsertElementAndSetValue(DicomTag.SeriesTime, DateTime.Now);
            sdDisplay.InsertElementAndSetValue(DicomTag.StudyID, studyInfo.GetElementValue(studyRow, DicomTag.StudyID));
            sdDisplay.InsertElementAndSetValue(DicomTag.SeriesInstanceUID, SeriesGenerator.GenerateDicomUniqueIdentifier());
            sdDisplay.InsertElementAndSetValue(DicomTag.SOPInstanceUID, SeriesGenerator.GenerateDicomUniqueIdentifier());
            sdDisplay.InsertElementAndSetValue(DicomTag.Modality, "PR");
            sdDisplay.InsertElementAndSetValue(DicomTag.PatientName, patientInfo.Name(patientRow));
            sdDisplay.InsertElementAndSetValue(DicomTag.PatientID, patientInfo.GetElementValue(patientRow, DicomTag.PatientID));

            string patientBirthDateString = patientInfo.GetElementValue(patientRow, DicomTag.PatientBirthDate);
            DateTime? patientBirthDate = null;
            if (!string.IsNullOrEmpty(patientBirthDateString))
            {
               patientBirthDate = DateTime.Parse(patientBirthDateString);
            }

            sdDisplay.InsertElementAndSetValue(DicomTag.PatientBirthDate, patientBirthDate);

            sdDisplay.InsertElementAndSetValue(DicomTag.PatientSex, patientInfo.GetElementValue(patientRow, DicomTag.PatientSex));
            sdDisplay.InsertElementAndSetValue(DicomTag.StationName, "HTML5 Viewer");
            sdDisplay.InsertElementAndSetValue(DicomTag.InstitutionName, ConfigurationManager.AppSettings["InstitutionName"]);
            sdDisplay.InsertElementAndSetValue(DicomTag.ContentCreatorName, userName);

            sdDisplay.InsertElementAndSetValue(DicomTag.InstanceNumber, 1);

            element = sdDisplay.FindFirstElement(null, DicomTag.StructuredDisplayImageBoxSequence, false);
            if (element != null)
            {
                sdDisplay.DeleteElement(element);
            }

            return sd;
        }

        #endregion
    }

    public class NActionClientSessionProxy : INActionClientSessionProxy
    {
        public NActionClientSessionProxy()
        {
            ActionTypeID = PatientUpdaterConstants.Action.ChangePatient;
        }

        #region INActionClientSessionProxy Members

        public int ActionTypeID
        {
            get;
            set;
        }

        public string RequestedSopInstanceUID
        {
            get;
            set;
        }

        public DicomDataSet ResponseDataSet
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        public void SendNActionResponse(DicomCommandStatusType status, DicomDataSet responseDataset, string descriptionMessage)
        {
            return;
        }

        #endregion

        #region IDicomCommandClientSessionProxy Members

        public string AbstractClass
        {
            get { return string.Empty; }
        }

        public int MessageID
        {
            get { return 0; }
        }

        public byte PresentationID
        {
            get { return 0; }
        }

        #endregion

        #region IClientSessionProxy Members

        public string ClientName
        {
            get { return string.Empty; }
        }

        public bool IsAssociated
        {
            get { return false; }
        }

        public bool IsConnected
        {
            get { return false; }
        }

        public void LogEvent(LogType eventType, MessageDirection messageDirection, string description, DicomCommandType command, DicomDataSet dataset, SerializableDictionary<string, object> customInformation)
        {
            return;
        }

        public string ServerName
        {
            get { return string.Empty; }
        }

        #endregion
    }

    public class StoreClientSessionProxy : ICStoreClientSessionProxy
    {
        private string affectedSopInstance;
        private string abstractClass;
        private string _serverName;

        public DicomCommandStatusType LastStatus;
        public string LastStatusDescriptionMessage;

        #region ICStoreClientSessionProxy Members

        public string AffectedSOPInstance
        {
            get
            {
                return affectedSopInstance;
            }
            set
            {
                affectedSopInstance = value;
            }
        }

        public void SendCStoreResponse(DicomCommandStatusType status, string descriptionMessage)
        {
            LastStatus = status;
            LastStatusDescriptionMessage = descriptionMessage;
        }

        #endregion

        #region IDICOMCommandClientSessionProxy Members

        public string AbstractClass
        {
            get { return abstractClass; }
            set
            {
                abstractClass = value;
            }
        }

        public int MessageID
        {
            get { return 0; }
        }

        public byte PresentationID
        {
            get { return 0; }
        }

        #endregion

        #region IClientSessionProxy Members

        public string ClientName
        {
            get { return System.Threading.Thread.CurrentPrincipal.Identity.Name; }
        }

        public bool IsAssociated
        {
            get { return true; }
        }

        public bool IsConnected
        {
            get { return true; }
        }

        public void LogEvent
        (
           LogType enumType,
           MessageDirection enumMessageDirection,
           string strDescription,
           DicomCommandType command,
           DicomDataSet DatasetRootElement,
           SerializableDictionary<string, object> customInfo
        )
        {

        }

        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; }
        }

        #endregion
    }


    public class AnnUserData
    {
        public ImageSopInstanceReference ReferencedImageSequence;
        public LeadSize ImageSize;
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class GraphicAnnotationsModule
    {
        [Element(DicomTag.ReferencedImageSequence)]
        public List<ImageSopInstanceReference> ReferencedImageSequence { get; set; }
    }

    //public class ReferencedImageInstance
    //{
    //   public string SopInstanceUID ;
    //   public int [] FrameNumbers ;
    //   public int [] SegmentNumber ;
    //}
}
