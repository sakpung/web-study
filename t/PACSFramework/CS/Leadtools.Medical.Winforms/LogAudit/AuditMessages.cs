// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms
{
   public abstract class AuditMessages
   {
      public static readonly Entry UserLogIn                        = new Entry ( 0, "User Log in: {0}" ) ;
      public static readonly Entry UserLogOff                       = new Entry ( 1, "User Log Off: {0}" ) ;
      
      // Dicom Server Settings
      public static readonly Entry ServerServiceCreated             = new Entry ( 2, "Service Created: Name={0}, AE Title={1}, IP Address={2}, Port={3}" ) ;
      public static readonly Entry ServerServiceDeleted             = new Entry ( 3, "Service Deleted: Name={0}" ) ;
      public static readonly Entry AeTitleChanged                   = new Entry ( 4, "Server AE Title Changed: {0}" ) ;
      public static readonly Entry IpAddressChanged                 = new Entry ( 5, "Server IP Address Changed: {0}" ) ;
      public static readonly Entry PortChanged                      = new Entry ( 6, "Server Port Changed: {0}" ) ;
      public static readonly Entry ImplementationClassUIDChanged    = new Entry ( 7, "Server Implementation Class UID Changed: {0}" ) ;
      public static readonly Entry ImplementationVersionNameChanged = new Entry ( 8, "Server Implementation Version Name Changed: {0}" ) ;
      public static readonly Entry ServiceStartModeChanged          = new Entry ( 9, "Service Start Mode Changed: {0}" ) ;
      
      // 
      public static readonly Entry DicomFileDeleted                 = new Entry ( 10, "DICOM File Deleted: {0}" ) ;
      public static readonly Entry ImageFileDeleted                 = new Entry ( 11, "Image File Deleted: {0}" ) ;
      public static readonly Entry DicomFileImported                = new Entry ( 12, "DICOM File Imported: {0}" ) ;
      
      // Administration: Users
      public static readonly Entry NewUserAdded                     = new Entry ( 13, "New User Added: {0}" ) ;
      public static readonly Entry UserRemoved                      = new Entry ( 14, "User Removed: {0}" ) ;
      public static readonly Entry UserPasswordChanged              = new Entry ( 15, "User Password Changed: {0}" ) ;
      public static readonly Entry PermissionAdded                  = new Entry ( 16, "User Permission Granted. User: {0}, Permission: {1}" ) ;
      public static readonly Entry PermissionRemoved                = new Entry ( 17, "User Permission Removed. User: {0}, Permission: {1}" ) ;
      
      
      public static readonly Entry DeletingDicomFile                = new Entry ( 18, "User {0} requested to delete DICOM files, Reason: {1}" ) ;
      public static readonly Entry EmptyDatabase                    = new Entry ( 19, "User {0} requested to delete all DICOM files, Reason: {1}");

      public static readonly Entry AddClient                        = new Entry ( 20, "Client Added: {0}, IP {1}, Mask {2}, Port {3}, Secure Port {4}, Privileges: {5}");
      public static readonly Entry UpdateClient                     = new Entry ( 21, "Client Updated: {0}, IP {1}, Mask {2}, Port {3}, Secure Port {4}, Privileges: {5}");
      public static readonly Entry DeleteClient                     = new Entry ( 22, "Client Deleted: {0}");

      // Storage Settings: Store Settings: Files tab
      public static readonly Entry StorageLocationChanged           = new Entry ( 23, "Store Settings - Storage Folder Changed: {0}");
      public static readonly Entry FileExtensionChanged             = new Entry ( 24, "Store Settings - Store File Extension Changed: {0}");
      public static readonly Entry OverwriteLocationChanged         = new Entry ( 25, "Store Settings - 'Create File Backup Before Overwrite' Folder Changed: {0}");
      public static readonly Entry CreateBackupChanged              = new Entry ( 26, "Store Settings - 'Create File Backup Before Overwrite' Changed: {0}");
      public static readonly Entry BackupLocationChanged            = new Entry ( 27, "Store Settings - 'Backup DICOM Dataset on Delete' Folder Changed: {0}");
      public static readonly Entry CStoreLocationChanged            = new Entry ( 28, "Store Settings - 'Save C-CStore Failures Folder' Changed: {0}");
      public static readonly Entry DeleteFilesChanged               = new Entry ( 29, "Store Settings - 'Delete DICOM files when Deleting Database' Changed: {0}");
      public static readonly Entry BackupFilesOnDeleteChanged       = new Entry ( 30, "Store Settings - 'Automatically Backup DICOM Dataset on Delete' Changed: {0}");
      public static readonly Entry SaveCStoreFailuresChanged        = new Entry ( 31, "Store Settings - 'Save C-STORE and Import Failures' Changed: {0}");

      // Storage Settings: Store Settings: Directory Structure Tab
      public static readonly Entry CreatePatientFolderChanged       = new Entry ( 32, "Store Settings - 'Create Patient Folder' Changed: {0}");
      public static readonly Entry UsePatientIdChanged              = new Entry ( 33, "Store Settings - 'Use Patient ID' Changed: {0}");
      public static readonly Entry SplitPatientIdChanged            = new Entry ( 34, "Store Settings - 'Split Patient ID into Multiple Folders' Changed: {0}");
      public static readonly Entry CreateStudyFolderChanged         = new Entry ( 35, "Store Settings - 'Create Study Folder' Changed: {0}");
      public static readonly Entry CreateSeriesFolderChanged        = new Entry ( 36, "Store Settings - 'Create Series Folder' Changed: {0}");

      // Storage Settings: Store Settings: Images Tab
      public static readonly Entry CreateThumbChanged                = new Entry ( 37, "Store Settings - 'Create Thumbnail Image' Changed: {0}");
      public static readonly Entry ThumbWidthChanged                 = new Entry ( 38, "Store Settings - 'Thumbnail Width' Changed: {0}");
      public static readonly Entry ThumbHeightChanged                = new Entry ( 39, "Store Settings - 'Thumbnail Height' Changed: {0}");
      public static readonly Entry ThumbQFactorChanged               = new Entry ( 40, "Store Settings - 'Thumbnail Quality Factor' Changed: {0}");
      public static readonly Entry ThumbFormatChanged                = new Entry ( 41, "Store Settings - 'Thumbnail Format' Changed: {0}");
      public static readonly Entry GenerateImageItemAdded            = new Entry ( 42, "Store Settings - 'Generate Images' Item Added: Width: {0}, Height: {1}, QualityFactor: {2}, Format: {3}");
      public static readonly Entry GenerateImageItemChanged          = new Entry ( 43, "Store Settings - 'Generate Images' Item Edit: Width: {0}, Height: {1}, QualityFactor: {2}, Format: {3}");
      public static readonly Entry GenerateImageItemDeleted          = new Entry ( 44, "Store Settings - 'Generate Images' Item Deleted: Width: {0}, Height: {1}, QualityFactor: {2}, Format: {3}");
                                                                                  
      // Storage Settings: Store Settings: Options Tab                            
      public static readonly Entry AutoTruncateDataChanged           = new Entry ( 45, "Store Settings - 'Auto Truncate Data' Changed: {0}");
      public static readonly Entry UpdateExistingInstanceChanged     = new Entry ( 46, "Store Settings - 'Update Existing Instance' Changed: {0}");
      public static readonly Entry UpdateExistingSeriesChanged       = new Entry ( 47, "Store Settings - 'Update Existing Series' Changed: {0}");
      public static readonly Entry UpdateExistingStudyChanged        = new Entry ( 48, "Store Settings - 'Update Existing Study' Changed: {0}");
      public static readonly Entry UpdateExistingPatientChanged      = new Entry ( 49, "Store Settings - 'Update Existing Patient' Changed: {0}");
      public static readonly Entry PreventStoringDuplicatesChanged   = new Entry ( 50, "Store Settings - 'Prevent Storing Duplicate SOP Instance' Changed: {0}");
                                                                                  
      // Storage Settings: Query Settings                                         
      public static readonly Entry AllowZeroItemsChanged             = new Entry ( 51, "Query Settings - 'Allow Zero Items' Changed: {0}");
      public static readonly Entry AllowMultipleItemsChanged         = new Entry ( 52, "Query Settings - 'Allow Multiple Items' Changed: {0}");
      public static readonly Entry AllowPrivateItemsChanged          = new Entry ( 53, "Query Settings - 'Allow Private Elements' Changed: {0}");
      public static readonly Entry AllowExtraItemsChanged            = new Entry ( 54, "Query Settings - 'Allow Extra Elements' Changed: {0}");
      public static readonly Entry PatientRelatedStudiesChanged      = new Entry ( 55, "Query Settings - 'Include Number of Patient Related Studies' Changed: {0}");
      public static readonly Entry PatientRelatedSeriesChanged       = new Entry ( 56, "Query Settings - 'Include Number of Patient Related Series' Changed: {0}");
      public static readonly Entry PatientRelatedInstancesChanged    = new Entry ( 57, "Query Settings - 'Include Number of Patient Related Instances' Changed: {0}");
      public static readonly Entry StudyRelatedSeriesChanged         = new Entry ( 58, "Query Settings - 'Include Number of Study Related Series' Changed: {0}");
      public static readonly Entry StudyRelatedInstancesChanged      = new Entry ( 59, "Query Settings - 'Include Number of Study Related Instances' Changed: {0}");
      public static readonly Entry SeriesRelatedInstancesChanged     = new Entry ( 60, "Query Settings - 'Include Number of Series Related Instances' Changed: {0}");
      public static readonly Entry IodXmlPathChanged                 = new Entry ( 61, "Query Settings - 'IOD XML Path' Changed: {0}");
                                                                                  
      // Storage Settings: IOD Classes                                            
      public static readonly Entry StorageIodCreated                 = new Entry ( 62, "IOD Classes - Storage IOD Created: UID: {0}, Description: {1}");
      public static readonly Entry StorageIodModified                = new Entry ( 63, "IOD Classes - Storage IOD Modified: UID: {0}, Description: {1}");
      public static readonly Entry StorageIodDeleted                 = new Entry ( 64, "IOD Classes - Storage IOD Deleted: UID: {0}, Description: {1}");
      public static readonly Entry StorageIodSupportChanged          = new Entry ( 65, "IOD Classes - Storage IOD Support Changed: UID: {0}, Description: {1}, Supported: {2}");
      public static readonly Entry TransferSyntaxCreated             = new Entry ( 66, "IOD Classes - Transfer Syntax Created: UID: {0}, Description: {1}");
      public static readonly Entry TransferSyntaxModified            = new Entry ( 67, "IOD Classes - Transfer Syntax Modified: UID: {0}, Description: {1}");
      public static readonly Entry TransferSyntaxDeleted             = new Entry ( 68, "IOD Classes - Transfer Syntax Deleted: UID: {0}, Description: {1}");
      public static readonly Entry TransferSyntaxSupportChanged      = new Entry ( 69, "IOD Classes - Transfer Syntax Support Changed: UID: {0}, Description: {1}, Supported: {2}");
                                                                                  
      // Administration: Password Options                                         
      public static readonly Entry ComplexityLowerCaseChanged        = new Entry ( 70, "Login Options - Complexity 'Lowercase' Changed: {0}");
      public static readonly Entry ComplexityUpperCaseChanged        = new Entry ( 71, "Login Options - Complexity 'Uppercase' Changed: {0}");
      public static readonly Entry ComplexitySymbolChanged           = new Entry ( 72, "Login Options - Complexity 'Symbol' Changed: {0}");
      public static readonly Entry ComplexityNumberChanged           = new Entry ( 73, "Login Options - Complexity 'Number' Changed: {0}");
      public static readonly Entry MinimumLengthChanged              = new Entry ( 74, "Login Options - 'Minimum Length' Changed: {0}");
      public static readonly Entry DaysToExpirationChanged           = new Entry ( 75, "Login Options - 'Days To Expiration' Changed: {0}");
      public static readonly Entry MaximumRememberedChanged          = new Entry ( 76, "Login Options - 'Max Remembered' Changed: {0}");
      public static readonly Entry IdleTimeoutEnableChanged          = new Entry ( 77, "Login Options - Idle Timeout 'Enable' Changed: {0}");
      public static readonly Entry IdleTimeoutChanged                = new Entry ( 78, "Login Options - Idle Timeout 'Timeout (secs)' Changed: {0}");                                                                                  
      // Patient Updater                                                          
      public static readonly Entry RequireStationNameChanged         = new Entry ( 79, "Patient Updater - 'Require Station Name' Changed: {0}");
      public static readonly Entry RequireOperatorsNameChanged       = new Entry ( 80, "Patient Updater - 'Require Operator's Name' Changed: {0}");
      public static readonly Entry RequireTransactionUidChanged      = new Entry ( 81, "Patient Updater - 'Require Transaction UID' Changed: {0}");
      public static readonly Entry RequireTransactionDateChanged     = new Entry ( 82, "Patient Updater - 'Require Transaction Date' Changed: {0}");
      public static readonly Entry RequireTransactionTimeChanged     = new Entry ( 83, "Patient Updater - 'Require Transaction Time' Changed: {0}");
      public static readonly Entry RequireDescriptionChanged         = new Entry ( 84, "Patient Updater - 'Require Description' Changed: {0}");
      public static readonly Entry RequireReasonChanged              = new Entry ( 85, "Patient Updater - 'Require Reason' Changed: {0}");
      public static readonly Entry AutoUpdateEnableChanged           = new Entry ( 86, "Patient Updater - 'Auto Update Enable' Changed: {0}");
      public static readonly Entry EnableRetryChanged                = new Entry ( 87, "Patient Updater - 'Enable Retry' Changed: {0}");
      public static readonly Entry RetrySecondsChanged               = new Entry ( 88, "Patient Updater - 'Retry (secs)' Changed: {0}");
      public static readonly Entry RetryExpirationDaysChanged        = new Entry ( 89, "Patient Updater - 'Expiration (days)' Changed: {0}");
      public static readonly Entry RetryDirectoryChanged             = new Entry ( 90, "Patient Updater - 'Retry Directory' Changed: {0}");
      public static readonly Entry UseCustomAeTitleChanged           = new Entry ( 91, "Patient Updater - 'Use Custom AE Title' Changed: {0}");
      public static readonly Entry CustomAeTitleChanged              = new Entry ( 92, "Patient Updater - 'Custom AE' Changed: {0}");
      public static readonly Entry AutoUpdateProcessingThreadsChanged= new Entry ( 93, "Patient Updater - 'Auto Update PRocessing Threads Number' Changed: {0}");
                                                                                  
      // Logging Configuration                                                    
      public static readonly Entry EnableLoggingChanged              = new Entry (  94, "Logging Configuration - 'Enable Logging' Changed: {0}");
      public static readonly Entry EnableAutoSaveLogChanged          = new Entry (  95, "Logging Configuration - 'Enable Auto Save Log' Changed: {0}");
      public static readonly Entry AutoSaveDirectoryChanged          = new Entry (  96, "Logging Configuration - 'Auto Save Directory' Changed: {0}");
      public static readonly Entry LogDicomDatasetChanged            = new Entry (  97, "Logging Configuration - 'Log DICOM Dataset' Changed: {0}");
      public static readonly Entry LogDicomChanged                   = new Entry (  98, "Logging Configuration - 'Log DICOM Messages' Changed: {0}");
      public static readonly Entry DataSetDirectoryChanged           = new Entry (  99, "Logging Configuration - 'DICOM Dataset Directory' Changed: {0}");
      public static readonly Entry EnableThreadingChanged            = new Entry ( 100, "Logging Configuration - 'Enable Threading' Changed: {0}");
      public static readonly Entry LogInformationChanged             = new Entry ( 101, "Logging Configuration - Filter Type 'Information' Changed: {0}");
      public static readonly Entry LogWarningsChanged                = new Entry ( 102, "Logging Configuration - Filter Type 'Warnings' Changed: {0}");
      public static readonly Entry LogDebugChanged                   = new Entry ( 103, "Logging Configuration - Filter Type 'Debug' Changed: {0}");
      public static readonly Entry LogErrorChanged                   = new Entry ( 104, "Logging Configuration - Filter Type 'Error' Changed: {0}");
      public static readonly Entry LogAuditChanged                   = new Entry ( 105, "Logging Configuration - Filter Type 'Audit' Changed: {0}");
      public static readonly Entry AutoSaveDaysPeriodChanged         = new Entry ( 106, "Logging Configuration - Auto Save Days Changed: {0}");
      public static readonly Entry AutoSaveTimeChanged               = new Entry ( 107, "Logging Configuration - Auto Save Time Changed: {0}");
      public static readonly Entry DeleteSavedLogChanged             = new Entry ( 108, "Logging Configuration - 'Delete Saved Log' Changed: {0}");
      
      // Database Manager Options
      public static readonly Entry DatabaseManagerPageSizeChanged    = new Entry ( 109, "Database Manager Options - 'Image Level Page Size' Changed: {0}");
      public static readonly Entry DatabaseManagerPaginationDisplayOptionChanged = new Entry (110, "Database Manager Options - 'Pagination Display Option' Changed: {0}");
      
      public static readonly Entry LimitCFindRspChanged              = new Entry ( 111, "Query Settings - 'Limit Number of CFind-Rsp Per Request' Changed: {0}");
      public static readonly Entry MaximumCountCFindRspChanged       = new Entry ( 112, "Query Settings - 'Maximum Number of CFind-Rsp Per Request' Changed: {0}");
      public static readonly Entry ServiceStatusChanged              = new Entry ( 113, "Query Settings - 'Service Status for Final CFind-Rsp' Changed: {0}");


      public static readonly Entry DicomFileImportedFailure         = new Entry ( 114, "DICOM File Import Failure: Failed to load '{0}', Status: {1}, Description: {2}" ) ;


      // Forwarder
      public static readonly Entry CleanForwardedDatasets          = new Entry ( 115, "User {0} requested to clean (delete) {1} forwarded DICOM files, Reason: {2}" ) ;

      // Other
      public static readonly Entry UseMessageQueueChanged               = new Entry(116, "Store Settings - 'Use Message Queue' Changed: {0}");
      public static readonly Entry HangingProtocolLocationChanged       = new Entry ( 117, "Store Settings - Hanging Protocol Folder Changed: {0}");
      public static readonly Entry LoginTypeChanged                     = new Entry ( 118, "Login Options - Login Type Changed: {0}");
      public static readonly Entry MultiDicomImportStarting             = new Entry ( 119, "Import Starting: Files to import: {0}" ) ;
      public static readonly Entry MultiDicomImportEndingSuccess        = new Entry ( 120, "Import {0}: {2} of {1} files successfully imported" ) ;
      public static readonly Entry MultiDicomImportEndingPartialSuccess = new Entry ( 121, "Import {0}: {2} of {1} files successfully imported, {3} failures" ) ;


       // Storage Settings: Store Settings: Metadata Tab
      public static readonly Entry JsonStoreJsonChanged                 = new Entry ( 130, "Store Settings - 'Store JSON' Changed: {0}");
      public static readonly Entry JsonTrimWhiteSpace                   = new Entry ( 131, "Store Settings - 'Trim White Space (JSON)' Changed: {0}");
      public static readonly Entry JsonWriteKeyword                     = new Entry ( 132, "Store Settings - 'Write Keyword (JSON)' Changed: {0}");
      public static readonly Entry JsonMinify                           = new Entry ( 133, "Store Settings - 'Minify (JSON)' Changed: {0}");
      public static readonly Entry JsonIgnoreBinaryData                 = new Entry ( 134, "Store Settings - 'Ignore Binary Data (JSON)' Changed: {0}");
      public static readonly Entry JsonDeleteMetadata                   = new Entry ( 135, "Store Settings - 'Delete Metadata (JSON)' Clicked: {0}");
      public static readonly Entry JsonRegenerateMetadata               = new Entry ( 136, "Store Settings - 'Regenerate Metadata (JSON)' Clicked: {0}");

      public static readonly Entry XmlStoreXmlChanged                   = new Entry ( 137, "Store Settings - 'Store XML' Changed: {0}");
      public static readonly Entry XmlTrimWhiteSpace                    = new Entry ( 138, "Store Settings - 'Trim White Space (XML)' Changed: {0}");
      public static readonly Entry XmlWriteFullEndStatement             = new Entry ( 139, "Store Settings - 'Write Full End Statement (XML)' Changed: {0}");
      public static readonly Entry XmlIgnoreBinaryData                  = new Entry ( 140, "Store Settings - 'Ignore Binary Data (XML)' Changed: {0}");
      public static readonly Entry XmlDeleteMetadata                    = new Entry ( 141, "Store Settings - 'Delete Metadata (XML)' Clicked: {0}");
      public static readonly Entry XmlRegenerateMetadata                = new Entry ( 142, "Store Settings - 'Regenerate Metadata (XML)' Clicked: {0}");

      // Client Configuration Options
      public static readonly Entry ClientConfigurationPageSizeChanged   = new Entry ( 143, "Client Configuration Options - 'Page Size' Changed: {0}");
      public static readonly Entry ClientConfigurationPaginationDisplayOptionChanged = new Entry (144, "Client Configuration Manager Options - 'Pagination Display Option' Changed: {0}");

      public static readonly Entry ClientConfigurationLastAccessDateDisplayOptionChanged = new Entry(145, "Client Configuration Manager Options - 'Last Access Date' Option Changed: {0}");

      // Generate Metadata
      public static readonly Entry GenerateMetadataStarting              = new Entry(150, "Generate {0} Metadata Starting: {1} instances to generate");
      public static readonly Entry GenerateMetadataEnding                = new Entry(151, "Generate {0} Metadata Finished: {1} of {2} instances sucessfully generated");
      public static readonly Entry GenerateMetadataStopped               = new Entry(152, "Generate {0} Metadata Stopped: {1} of {2} instances sucessfully generated");
      public static readonly Entry DeleteMetadata                        = new Entry(153, "Delete {0} {1} Metadata Instances Finished, Reason: '{2}'");

































   }

   public struct Entry
   {
      public Entry ( int key, string message ) 
      {
         _key     = key ;
         _message = message ;
      }
      
      public int    Key     { get { return _key ; } } 
      public string Message { get { return _message ; } }
      
      private int    _key     ;
      private string _message ;
   }
}
