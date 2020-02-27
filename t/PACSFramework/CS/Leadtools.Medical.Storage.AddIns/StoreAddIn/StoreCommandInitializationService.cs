// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom ;
using Leadtools.Dicom.AddIn.Configuration ;
using Leadtools.Dicom.Scp.Command ;
using Leadtools.Dicom.Scp.Command.Configuration ;
using Leadtools.Medical.Storage.AddIns.Configuration ;
using Leadtools.Logging ;
using Leadtools.Logging.Medical;
using System.IO;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.Storage.AddIns
{
   public class StoreCommandInitializationService : IInitializationService
   {
      public StoreCommandInitializationService ( ) 
      {}
      
      public StoreCommandInitializationService ( StorageModuleConfigurationManager configManager ) 
      {
         _configManager = configManager ;
      }
      
      #region IInitializationService Members

      public void ConfigureCommand ( DicomCommand command )
      {
         try
         {
            if ( null == _configManager  )
            {
               if ( ServiceLocator.IsRegistered<StorageModuleConfigurationManager> ( ) )
               {
                  _configManager = ServiceLocator.Retrieve<StorageModuleConfigurationManager> ( ) ;
               }
               else
               {
                  throw new InvalidOperationException ( "No " + typeof (StorageModuleConfigurationManager).Name + " registered." ) ;
               }
            }
            
            
            if ( command is CStoreCommand )
            {
               ConfigureCStoreCommand ( command, _configManager.GetStorageAddInsSettings ( ).StoreAddIn ) ;
            }
            
            if ( command is InstanceCStoreCommand )
            {
               ConfigureInstanceCStoreCommand ( command, _configManager.GetStorageAddInsSettings ( ).StoreAddIn ) ;
            }
         }
         catch ( Exception exception ) 
         {
            LogEvent ( "Failed to configure CStore Command, default configuration will be applied.^\n" + exception.Message, command.RequestDataSet ) ;
         }
      }

      public static void ConfigureCStoreCommand 
      ( 
         DicomCommand command, 
         StoreAddInConfigurationElement storeConfig 
      )
      {
         CStoreCommand storeCommand ;
         
         
         storeCommand = command as CStoreCommand ;
         
         if ( null != storeCommand ) 
         {
            storeCommand.Configuration.DataSetStorageLocation = storeConfig.StorageLocation ;
#if (LEADTOOLS_V19_OR_LATER)
            storeCommand.Configuration.HangingProtocolLocation = storeConfig.HangingProtocolLocation ;
#endif
            storeCommand.Configuration.OverwriteBackupLocation = storeConfig.OverwriteBackupLocation;
            storeCommand.Configuration.DicomFileExtension     = storeConfig.StoreFileExtension ;
            
            storeCommand.Configuration.DirectoryStructure.CreatePatientFolder = storeConfig.DirectoryStructure.CreatePatientFolder ;
            storeCommand.Configuration.DirectoryStructure.CreateSeriesFolder  = storeConfig.DirectoryStructure.CreateSeriesFolder ;
            storeCommand.Configuration.DirectoryStructure.CreateStudyFolder   = storeConfig.DirectoryStructure.CreateStudyFolder ;
            storeCommand.Configuration.DirectoryStructure.UsePatientName      = storeConfig.DirectoryStructure.UsePatientName ;
            storeCommand.Configuration.DirectoryStructure.SplitPatientId      = storeConfig.DirectoryStructure.SplitPatientId;
            
            foreach ( SaveImageFormatElement imageFormatElement in storeConfig.ImagesFormat )
            {
               SaveImageFormat imageFormat = GetImageFormat ( imageFormatElement ) ;
               
               storeCommand.Configuration.OtherImageFormat.Add ( imageFormat ) ;
            }
            
            storeCommand.Configuration.SaveThumbnail = storeConfig.CreateThumbnailImage ;
            
            if ( storeCommand.Configuration.SaveThumbnail )
            {
               storeCommand.Configuration.ThumbnailFormat = GetImageFormat ( storeConfig.ThumbnailFormat ) ;
            }

#if (LEADTOOLS_V20_OR_LATER)
            storeCommand.Configuration.SaveMetadataOptions.StoreJson = storeConfig.JsonStore;
            storeCommand.Configuration.SaveMetadataOptions.SaveJsonFlags = 
               (storeConfig.JsonTrimWhiteSpace     ? DicomDataSetSaveJsonFlags.TrimWhiteSpace   : DicomDataSetSaveJsonFlags.None) |
               (storeConfig.JsonWriteKeyword       ? DicomDataSetSaveJsonFlags.WriteKeyword     : DicomDataSetSaveJsonFlags.None) |
               (storeConfig.JsonMinify             ? DicomDataSetSaveJsonFlags.Minify           : DicomDataSetSaveJsonFlags.None) |
               (storeConfig.JsonIgnoreBinaryData   ? DicomDataSetSaveJsonFlags.IgnoreBinaryData : DicomDataSetSaveJsonFlags.None);
   
            storeCommand.Configuration.SaveMetadataOptions.StoreXml = storeConfig.XmlStore;
            storeCommand.Configuration.SaveMetadataOptions.SaveXmlFlags = 
               (storeConfig.XmlTrimWhiteSpace      ? DicomDataSetSaveXmlFlags.TrimWhiteSpace       : DicomDataSetSaveXmlFlags.None) |
               (storeConfig.XmlTrimWhiteSpace      ? DicomDataSetSaveXmlFlags.WriteFullEndElement  : DicomDataSetSaveXmlFlags.None) |
               (storeConfig.XmlTrimWhiteSpace      ? DicomDataSetSaveXmlFlags.IgnoreBinaryData     : DicomDataSetSaveXmlFlags.IgnoreBinaryData);
            storeCommand.Configuration.SaveMetadataOptions.StoreXml = storeConfig.XmlStore;
#endif // #if (LEADTOOLS_V20_OR_LATER)
         }
      }
      
      public static void ConfigureInstanceCStoreCommand 
      ( 
         DicomCommand command, 
         StoreAddInConfigurationElement storeConfig 
      )
      {
         InstanceCStoreCommand instanceStoreCommand ;
         
         
         instanceStoreCommand = command as InstanceCStoreCommand ;
         
         if ( null != instanceStoreCommand )
         {
            instanceStoreCommand.InstanceConfiguration.CreateBackupForDuplicateSop = storeConfig.CreateBackupBeforeOverwrite ;
            instanceStoreCommand.InstanceConfiguration.UpdateInstanceData          = storeConfig.DatabaseOptions.UpdateExistentInstance ;
            instanceStoreCommand.InstanceConfiguration.UpdatePatientData           = storeConfig.DatabaseOptions.UpdateExistentPatient ;
            instanceStoreCommand.InstanceConfiguration.UpdateSeriesData            = storeConfig.DatabaseOptions.UpdateExistentSeries ;
            instanceStoreCommand.InstanceConfiguration.UpdateStudyData             = storeConfig.DatabaseOptions.UpdateExistentStudy ;
            
            instanceStoreCommand.InstanceConfiguration.ValidateDuplicateSopInstanceUID = storeConfig.PreventStoringDuplicateInstance ;
         }
      }

      private static SaveImageFormat GetImageFormat
      (
         SaveImageFormatElement imageFormatElement
      )
      {
         SaveImageFormat imageFormat ;
         
         
         imageFormat = new SaveImageFormat ( ) ;         
         imageFormat.Format = ( RasterImageFormat ) Enum.Parse ( typeof ( RasterImageFormat ), imageFormatElement.Format, true ) ;
         imageFormat.Height = imageFormatElement.Height ;
         imageFormat.Width  = imageFormatElement.Width ;
         imageFormat.QualityFactor = imageFormatElement.QFactor ;
         
         return imageFormat;
      }

      #endregion
      
      private StorageModuleConfigurationManager _configManager ;
      
      
      public static void LogEvent ( string message, DicomDataSet dataset )
      {
         try
         {
            Logger.Global.Log ( AddInsSession.ServerAE, 
                                AddInsSession.ServerAddress, 
                                AddInsSession.ServerPort, 
                                string.Empty, 
                                string.Empty, 
                                -1, 
                                DicomCommandType.CStore,
                                DateTime.Now, 
                                LogType.Error, 
                                MessageDirection.Input,
                                message,
                                dataset,
                                null ) ;
         }
         catch ( Exception ) 
         {}
      }
   }
}
