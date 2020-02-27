// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration ;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.Storage.AddIns.Configuration
{
   public class StoreAddInConfigurationElement : ConfigurationElement
   {
      private const string StorageLocationProperty                 = "storageLocation" ;
      private const string HangingProtocolLocationProperty         = "hangingProtocolLocation" ;

      private const string StoreFileExtensionProperty              = "storeFileExt" ;
      private const string PreventStoringDuplicateInstanceProperty = "preventStoringDuplicateInstance" ;
      private const string CreateBackupBeforeOverwriteProperty     = "createBackupBeforeOverwrite" ;
      private const string OverwriteBackupLocationProperty         = "overwriteBackupLocation";
      
      private const string DeleteFilesProperty                     = "deleteFiles";
      private const string BackupFilesOnDeleteProperty             = "backupFilesOnDelete";
      private const string DeleteBackupLocationProperty            = "deleteBackupLocation";
      
      private const string CreateThumbnailImageProperty            = "createThumbnailImage" ;
      
      private const string DirectoryStructureProperty = "directoryStructure" ;
      private const string DatabaseOptionsProperty    = "databaseOptions" ;
      private const string ThumbnailFormatProperty    = "thumbnailFormat" ;
      private const string ImagesFormatProperty       = "ImagesFormat" ;
      
      private const string DeleteAnnotationsOnImageDeleteProperty = "DeleteAnnotationsOnImageDelete" ;
      public const string SaveCStoreFailuresProperty = "saveCStoreFailures" ;
      public const string CStoreFailuresPathProperty = "cStoreFailuresPath" ;
      
      public const string AutoTruncateDataProperty = "autoTruncateData" ;
      public const string UseMessageQueueProperty  = "useMessageQueue";
      
      public const string AutoCreateFolderLocationsProperty = "autoCreateFolderLocations";

#if (LEADTOOLS_V20_OR_LATER)
      // Metadata tab -- Json
      public const string JsonStoreProperty              = "jsonStore";
      public const string JsonTrimWhiteSpaceProperty     = "jsonTrimWhiteSpace";
      public const string JsonWriteKeywordProperty       = "jsonWriteKeyword";
      public const string JsonMinifyProperty             = "jsonMinify";
      public const string JsonIgnoreBinaryDataProperty   = "jsonIgnoreBinaryData";

      // Metadata tab -- Xml
      public const string XmlStoreProperty               = "xmlStore";
      public const string XmlTrimWhiteSpaceProperty      = "xmlTrimWhiteSpace";
      public const string XmlFullEndStatementProperty    = "xmlFullEndStatement";
      public const string XmlIgnoreBinaryDataProperty    = "xmlIgnoreBinaryData";
#endif // #if (LEADTOOLS_V20_OR_LATER)
      
      [ConfigurationProperty( StorageLocationProperty, IsRequired=false, DefaultValue="")]
      public string StorageLocation
      {
         get
         {
            return base [ StorageLocationProperty ] as string ;
         }
         
         set
         {
            base [ StorageLocationProperty ] = value ;
         }
      }
#if (LEADTOOLS_V19_OR_LATER)
      [ConfigurationProperty( HangingProtocolLocationProperty, IsRequired=false, DefaultValue="")]
      public string HangingProtocolLocation
      {
         get
         {
            return base [ HangingProtocolLocationProperty ] as string ;
         }
         
         set
         {
            base [ HangingProtocolLocationProperty ] = value ;
         }
      }
  #endif    
      
      [ConfigurationProperty( StoreFileExtensionProperty, IsRequired=false, DefaultValue="")]
      public string StoreFileExtension
      {
         get
         {
            return base [ StoreFileExtensionProperty ] as string ;
         }
         
         set
         {
            base [ StoreFileExtensionProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( PreventStoringDuplicateInstanceProperty, IsRequired=false, DefaultValue=true)]
      public bool PreventStoringDuplicateInstance
      {
         get
         {
            return bool.Parse ( base [ PreventStoringDuplicateInstanceProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ PreventStoringDuplicateInstanceProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( CreateBackupBeforeOverwriteProperty, IsRequired=false, DefaultValue=true)]
      public bool CreateBackupBeforeOverwrite
      {
         get
         {
            return bool.Parse ( base [ CreateBackupBeforeOverwriteProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ CreateBackupBeforeOverwriteProperty ] = value ;
         }
      }

      [ConfigurationProperty(OverwriteBackupLocationProperty, IsRequired = false, DefaultValue = "")]
      public string OverwriteBackupLocation
      {
         get
         {
            return base[OverwriteBackupLocationProperty] as string;
         }
         
         set
         {
            base[OverwriteBackupLocationProperty] = value;
         }
      }
      
      [ConfigurationProperty( DeleteFilesProperty, IsRequired=false, DefaultValue=true)]
      public bool DeleteFiles
      {
         get
         {
            return bool.Parse ( base [ DeleteFilesProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ DeleteFilesProperty ] = value ;
         }
      }

      [ConfigurationProperty(BackupFilesOnDeleteProperty, IsRequired = false, DefaultValue = false)]
      public bool BackupFilesOnDelete
      {
         get
         {
            return bool.Parse(base[BackupFilesOnDeleteProperty].ToString());
         }
         
         set
         {
            base[BackupFilesOnDeleteProperty] = value;
         }
      }

      [ConfigurationProperty(DeleteBackupLocationProperty, IsRequired = false, DefaultValue = "")]
      public string DeleteBackupLocation
      {
         get
         {
            return base[DeleteBackupLocationProperty] as string;
         }
         
         set
         {
            base[DeleteBackupLocationProperty] = value;
         }
      }
      
      [ConfigurationProperty( CreateThumbnailImageProperty, IsRequired=false, DefaultValue=false)]
      public bool CreateThumbnailImage
      {
         get
         {
            return bool.Parse ( base [ CreateThumbnailImageProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ CreateThumbnailImageProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( DirectoryStructureProperty, IsRequired=false)]
      public DirectoryStructureElement DirectoryStructure
      {
         get
         {
            return base [ DirectoryStructureProperty ]as DirectoryStructureElement ;
         }
         
         set
         {
            base [ DirectoryStructureProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( DatabaseOptionsProperty, IsRequired=false )]
      public DatabaseOptionsElement DatabaseOptions
      {
         get
         {
            return base [ DatabaseOptionsProperty ] as DatabaseOptionsElement ;
         }
         
         set
         {
            base [ DatabaseOptionsProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( ThumbnailFormatProperty, IsRequired=false )]
      public SaveImageFormatElement ThumbnailFormat
      {
         get
         {
            return base [ ThumbnailFormatProperty ] as SaveImageFormatElement ;
         }
         
         set
         {
            base [ ThumbnailFormatProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( ImagesFormatProperty, IsRequired=false)]
      public SaveImageFormatCollection ImagesFormat
      {
         get
         {
            return base [ ImagesFormatProperty ] as SaveImageFormatCollection ;
         }
         
         set
         {
            base [ ImagesFormatProperty ] = value  ;
         }
      }
      
      [ConfigurationProperty( DeleteAnnotationsOnImageDeleteProperty, IsRequired=false, DefaultValue=false)]
      public bool DeleteAnnotationsOnImageDelete
      {
         get
         {
            return bool.Parse ( base [ DeleteAnnotationsOnImageDeleteProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ DeleteAnnotationsOnImageDeleteProperty ] = value  ;
         }         
      }
      
      [ConfigurationProperty( SaveCStoreFailuresProperty, IsRequired=false, DefaultValue=false )]
      public bool SaveCStoreFailures
      {
         get
         {
            return bool.Parse ( base [ SaveCStoreFailuresProperty ].ToString ( ) )  ;
         }
         
         set
         {
            base [ SaveCStoreFailuresProperty ] = value ;
         }
      }      
      
      [ConfigurationProperty( CStoreFailuresPathProperty, IsRequired=false, DefaultValue="" )]
      public string CStoreFailuresPath
      {
         get
         {
            return base [ CStoreFailuresPathProperty ].ToString ( ) ;
         }
         
         set
         {
            base [ CStoreFailuresPathProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( AutoTruncateDataProperty, IsRequired=false, DefaultValue=false )]
      public bool AutoTruncateData
      {
         get
         {
            return bool.Parse ( base [ AutoTruncateDataProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ AutoTruncateDataProperty ] = value ;
         }
      }

      [ConfigurationProperty( UseMessageQueueProperty, IsRequired=false, DefaultValue=true )]
      public bool UseMessageQueue
      {
         get
         {
            return bool.Parse ( base [ UseMessageQueueProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ UseMessageQueueProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( AutoCreateFolderLocationsProperty, IsRequired=false, DefaultValue=true )]
      public bool AutoCreateFolderLocations
      {
         get
         {
            return bool.Parse ( base [ AutoCreateFolderLocationsProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ AutoCreateFolderLocationsProperty ] = value ;
         }
      }

#if (LEADTOOLS_V20_OR_LATER)
      // Metadata tab -- Json
      [ConfigurationProperty(JsonStoreProperty, IsRequired = false, DefaultValue = false)]
      public bool JsonStore
      {
         get
         {
            return bool.Parse ( base [ JsonStoreProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ JsonStoreProperty ] = value ;
         }
      }

      [ConfigurationProperty(JsonTrimWhiteSpaceProperty, IsRequired = false, DefaultValue = false)]
      public bool JsonTrimWhiteSpace
      {
         get
         {
            return bool.Parse(base[JsonTrimWhiteSpaceProperty].ToString());
         }

         set
         {
            base[JsonTrimWhiteSpaceProperty] = value;
         }
      }

            [ConfigurationProperty(JsonWriteKeywordProperty, IsRequired = false, DefaultValue = false)]
      public bool JsonWriteKeyword
      {
         get
         {
            return bool.Parse(base[JsonWriteKeywordProperty].ToString());
         }

         set
         {
            base[JsonWriteKeywordProperty] = value;
         }
      }

      [ConfigurationProperty(JsonMinifyProperty, IsRequired = false, DefaultValue = false)]
      public bool JsonMinify
      {
         get
         {
            return bool.Parse(base[JsonMinifyProperty].ToString());
         }

         set
         {
            base[JsonMinifyProperty] = value;
         }
      }

      [ConfigurationProperty(JsonIgnoreBinaryDataProperty, IsRequired = false, DefaultValue = false)]
      public bool JsonIgnoreBinaryData
      {
         get
         {
            return bool.Parse(base[JsonIgnoreBinaryDataProperty].ToString());
         }

         set
         {
            base[JsonIgnoreBinaryDataProperty] = value;
         }
      }

      // Metadata tab -- Xml

      [ConfigurationProperty(XmlStoreProperty, IsRequired = false, DefaultValue = false)]
      public bool XmlStore
      {
         get
         {
            return bool.Parse(base[XmlStoreProperty].ToString());
         }

         set
         {
            base[XmlStoreProperty] = value;
         }
      }

      [ConfigurationProperty(XmlTrimWhiteSpaceProperty, IsRequired = false, DefaultValue = false)]
     public bool XmlTrimWhiteSpace
      {
         get
         {
            return bool.Parse(base[XmlTrimWhiteSpaceProperty].ToString());
         }

         set
         {
            base[XmlTrimWhiteSpaceProperty] = value;
         }
      }

      [ConfigurationProperty(XmlFullEndStatementProperty, IsRequired = false, DefaultValue = false)]
      public bool XmlFullEndStatement
      {
         get
         {
            return bool.Parse(base[XmlFullEndStatementProperty].ToString());
         }

         set
         {
            base[XmlFullEndStatementProperty] = value;
         }
      }

     [ConfigurationProperty(XmlIgnoreBinaryDataProperty, IsRequired = false, DefaultValue = false)]
     public bool XmlIgnoreBinaryData
      {
         get
         {
            return bool.Parse(base[XmlIgnoreBinaryDataProperty].ToString());
         }

         set
         {
            base[XmlIgnoreBinaryDataProperty] = value;
         }
      }

      public MetadataOptions GetMetadataOptions()
      {
         MetadataOptions options = new MetadataOptions();

         // Copy Json Metdata Options
         options.SaveJsonFlags = 
                        (JsonTrimWhiteSpace     ? DicomDataSetSaveJsonFlags.TrimWhiteSpace   : DicomDataSetSaveJsonFlags.None) |
                        (JsonWriteKeyword       ? DicomDataSetSaveJsonFlags.WriteKeyword     : DicomDataSetSaveJsonFlags.None) |
                        (JsonMinify             ? DicomDataSetSaveJsonFlags.Minify           : DicomDataSetSaveJsonFlags.None) |
                        (JsonIgnoreBinaryData   ? DicomDataSetSaveJsonFlags.IgnoreBinaryData : DicomDataSetSaveJsonFlags.None);

         options.StoreJson = JsonStore;

         // Copy XML MetadataOptions
         options.SaveXmlFlags =
                        (XmlTrimWhiteSpace      ? DicomDataSetSaveXmlFlags.TrimWhiteSpace       : DicomDataSetSaveXmlFlags.None) |
                        (XmlFullEndStatement    ? DicomDataSetSaveXmlFlags.WriteFullEndElement  : DicomDataSetSaveXmlFlags.None) |
                        (XmlIgnoreBinaryData    ? DicomDataSetSaveXmlFlags.IgnoreBinaryData     : DicomDataSetSaveXmlFlags.None);

         options.StoreXml = XmlStore;

         return options;
      }
#endif // #if (LEADTOOLS_V20_OR_LATER)
   }
}
