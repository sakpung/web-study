// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.SqlCe;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System;
using Leadtools.Demos;
using System.Windows.Forms;
using Leadtools.DicomDemos;
using System.Collections.Generic;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;

namespace WebViewerConfiguration
{
    /// <summary>
    /// This is a helper class that works on the storage server database 
    /// </summary>
    partial class WebViewerDataAccess
    {
        /// <summary>
        /// check if the database is upgraded
        /// </summary>
        /// <param name="connectionSettings"></param>
        /// <returns></returns>
        public static bool IsUpgraded(ConnectionStringSettings connectionSettings)
        {
            Database db = CreateDatabaseProvider(connectionSettings);

            using (DbConnection connection = db.CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    return (TableExists(command, VersionTableName) && IsCurrentVersion(connectionSettings));
                }
            }
        }

        /// <summary>
        /// Upgrade the Storage server database to include the web viewer tables
        /// </summary>
        /// <param name="connectionSettings"></param>
        public static void UpgradeDatabase(ConnectionStringSettings connectionSettings)
        {
            Database db = CreateDatabaseProvider(connectionSettings);

            using (DbConnection connection = db.CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    DbTransaction transaction = connection.BeginTransaction();
                    command.Transaction = transaction;
                    try
                    {
                        if (!TableExists(command, VersionTableName))
                        {
                            CreateVersionTable(command);
                        }
                        else
                        {
                            UpdateCurrentVersion(command);
                        }

                        if (!TableExists(command, JobsQueueTableName))
                        {
                            CreateJobsTable(command);
                        }

                        if (!TableExists(command, RolesPatientsTableName))
                        {
                            CreateRolesPatientTable(command);
                        }

                        //if ( !TableExists ( command, AnnotationsTableName ) )
                        //{
                        //   CreateAnnotationsTable ( command ) ;
                        //}
#if LEADTOOLS_V19_OR_LATER

                        if (!TableExists(command, MonitorCalibrationTableName))
                        {
                            CreateMonitorCalibrationTable(command);
                        }

                        if (!TableExists(command, RoleOptionsTableName))
                        {
                            CreateRoleOptionsTable(command);
                        }

                        if (!TableExists(command, UserOptionsTableName))
                        {
                            CreateUserOptionsTable(command);
                        }

                        if(!TableExists(command, TemplateTableName))
                        {
                            CreateTemplateTable(command);
                        }

                        if(!TableExists(command, TemplateFramesTableName))
                        {
                            CreateTemplateFrameTable(command);
                        }

                        AddWebViewer19Options(command);
                        AddWebViewer19ClientOptions(command);
                        UpdateTemplateFrameTable(command);
                        UpdateTemplateTable(command);
#endif

#if LEADTOOLS_V20_OR_LATER 
                        UpdateDeprecatedSqlServerTypes(command);
#endif

                  AddWebViewerPermissions(command);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private static bool TableExists(DbCommand command, string tableName)
        {
            command.CommandText = string.Format(SelectTableString, tableName);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string dbName = reader.GetString(0);

                    if (!string.IsNullOrEmpty(dbName))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsCurrentVersion(ConnectionStringSettings connectionSettings)
        {
            Database db = null;

            db = CreateDatabaseProvider(connectionSettings);

            using (DbConnection connection = db.CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {

                    command.CommandText = "SELECT Major from " + VersionTableName + " WHERE Major=" + MajorVersion + " AND Minor = " + MinorVersion;

                    connection.Open();

                    object value = command.ExecuteScalar();

                    return (value != null && value != DBNull.Value && int.Parse(value.ToString()) == MajorVersion);
                }
            }
        }

        private static void CreateVersionTable(DbCommand command)
        {
            command.CommandText = CreateVersionTableString;
            command.ExecuteNonQuery();

            command.CommandText = InsertWebViewerVersionString;
            command.ExecuteNonQuery();
        }

        private static void UpdateCurrentVersion(DbCommand command)
        {
            command.CommandText = DeleteAllVersionsString;
            command.ExecuteNonQuery();

            command.CommandText = InsertWebViewerVersionString;
            command.ExecuteNonQuery();
        }

        private static void AddWebViewerPermissions(DbCommand command)
        {
            command.CommandText = InsertWebViewerPermissionsString;
            command.ExecuteNonQuery();
        }

#if LEADTOOLS_V19_OR_LATER
        private static void AddWebViewer19Options(DbCommand command)
        {
            command.CommandText = InsertWebViewerJsOptionsString;
            command.ExecuteNonQuery();
        }

        private static void AddWebViewer19ClientOptions(DbCommand command)
        {
            DicomDemoSettings settings = DicomDemoSettingsManager.LoadSettings("WebViewerConfiguration_Original.exe");

            if (settings != null && settings.ClientAe != null)
            {
                string sql = InsertWebViewerJsClientAEString.Replace("CLIENTAE", settings.ClientAe.AE);

                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
#endif

        private static void CreateJobsTable(DbCommand command)
        {
            command.CommandText = CreateJobsTableString;
            command.ExecuteNonQuery();
        }

        private static void CreateRolesPatientTable(DbCommand command)
        {
            command.CommandText = CreateRolesPatientTableString;
            command.ExecuteNonQuery();
        }

        private static void CreateAnnotationsTable(DbCommand command)
        {
            command.CommandText = CreateAnnotationsTableString;
            command.ExecuteNonQuery();
        }


#if LEADTOOLS_V19_OR_LATER
        private static void CreateMonitorCalibrationTable(DbCommand command)
        {
            command.CommandText = CreateMonitorCalibrationTableString;
            command.ExecuteNonQuery();
        }

        private static void CreateRoleOptionsTable(DbCommand command)
        {
            command.CommandText = CreateRoleOptionsTableString;
            command.ExecuteNonQuery();
        }

        private static void CreateUserOptionsTable(DbCommand command)
        {
            command.CommandText = CreateUserOptionsTableString;
            command.ExecuteNonQuery();
        }

        private static void CreateTemplateTable(DbCommand command)
        {
            command.CommandText = CreateTemplateTableString;
            command.ExecuteNonQuery();
        }

        private static void CreateTemplateFrameTable(DbCommand command)
        {
            command.CommandText = CreateTemplateFrameTableString;
            command.ExecuteNonQuery();
        }

        private static void UpdateTemplateFrameTable(DbCommand command)
        {
            command.CommandText = UpdateTemplateFramesTableString;
            command.ExecuteNonQuery();
        }

        private static void UpdateTemplateTable(DbCommand command)
        {
            command.CommandText = UpdateTemplateTableString;
            command.ExecuteNonQuery();
        }
#endif

#if LEADTOOLS_V20_OR_LATER
      private static void UpdateDeprecatedSqlServerTypes(DbCommand command)
      {
         command.CommandText = UpdateDeprecatedSqlServerTypesString;
         command.ExecuteNonQuery();
      }
#endif


      private static Database CreateDatabaseProvider(ConnectionStringSettings connection)
        {
            if (connection.ProviderName.ToLower().Contains("sqlce"))
            {
                return new SqlCeDatabase(connection.ConnectionString);
            }
            else
            {
                return new SqlDatabase(connection.ConnectionString);
            }
        }

        private const string SelectTableString = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{0}'";
        private const string CreateJobsTableString = @"
CREATE TABLE [JobsQueue](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](100) NOT NULL,
	[object] [varchar](max) NOT NULL,
	[status] [int] NOT NULL,
	[completedstatus] [int] NOT NULL,
	[timestamp] [datetime] NULL,
	[error] [varchar](max) NULL,
	[userdata] [varchar](max) NULL,
	[retries] [int] NOT NULL,
	[owner] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_jobsQueue] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
";

        private const string CreateRolesPatientTableString = @"
CREATE TABLE [RolesPatients] (
            [RoleID] [varchar] (128) NULL ,
            [PatientID] [nvarchar] (64) NULL ,
            [UserID] [varchar] (128) NULL ,
            [ID] [int] IDENTITY (1, 1) NOT NULL ,
            CONSTRAINT [PK_RolesPatients] PRIMARY KEY  CLUSTERED 
            (
               [ID]
            )  ON [PRIMARY] ,

) ON [PRIMARY]";

        private const string CreateAnnotationsTableString = @"
CREATE TABLE [Annotations] (
	[AnnId] [numeric](18, 0) IDENTITY (1, 1) NOT NULL ,
	[SeriesInstanceUID] [nvarchar] (64) NULL ,
	[FilePath] [nvarchar] (500) NOT NULL ,
	[UserData] [nvarchar](max) NULL ,
	CONSTRAINT [PK_Annotations] PRIMARY KEY  CLUSTERED 
	(
		[AnnId]
	)  ON [PRIMARY] 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]";

        private const string InsertWebViewerPermissionsString = @"INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanDownloadImages','Allow users to Move images from remote PACS.' WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanDownloadImages' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanRetrieve','Allow users to request DICOM DataSet through the web interface.' WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanRetrieve' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanQueryPACS','Allow users to query remote PACS through the web interface.' WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanQueryPACS' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanQuery','Allow users to query local images through the web interface.' WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanQuery' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanManageUsers','Allow users to manage other users through the web interface.' WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanManageUsers' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanManageRoles','Allow users to manage other users through the web interface.' WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanManageRoles' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanViewAnnotations', 'Allow users to load annotations.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanViewAnnotations' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanStore', 'Allow users to save annotations.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanStore' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanStoreAnnotations', 'Allow users to save annotations.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanStoreAnnotations' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanDeleteDownloadInfo', 'Allow users to delete jobs in download queue.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanDeleteDownloadInfo' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanDeleteAnnotations', 'Allow users to save annotations.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanDeleteAnnotations' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanManageRemotePACS', 'Allow users to manage remote PACS servers.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanManageRemotePACS' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanManageAccessRight','Allow users to grant or deny access to patient information through the web interface.' WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanManageAccessRight' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanExport', 'Allow users to export Dicom Files.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanExport' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanModifyBuiltInTemplates', 'Allow users to modify builtin templates.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanModifyBuiltInTemplates' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanViewTemplates', 'Allow users to view templates.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanViewTemplates' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanImportTemplates', 'Allow users to import templates.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanImportTemplates' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanExportTemplates', 'Allow users to export templates.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanExportTemplates' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanEditTemplates', 'Allow users to edit templates.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanEditTemplates' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanDeleteTemplates', 'Allow users to delete templates.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanDeleteTemplates' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanAddTemplates', 'Allow users to add templates.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanAddTemplates' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanSaveHangingProtocol', 'Allow users to create and save hanging protocols.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanSaveHangingProtocol' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanDeleteCache', 'Allow users to delete cached images.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanDeleteCache' )
INSERT INTO [UserPermissionsList] ([Permission],[Description]) SELECT 'MWV.CanSaveStructuredDisplay', 'Allow users to save structured display.'WHERE NOT EXISTS (select [Permission] from [UserPermissionsList] where [Permission]='MWV.CanSaveStructuredDisplay' )";


        private const string CreateMonitorCalibrationTableString = @"
CREATE TABLE [dbo].[MonitorCalibration](
      [Id] [int] IDENTITY(1,1) NOT NULL,
      [CalibrationTime] [datetime] NOT NULL,
      [Username] [nvarchar](50) NOT NULL,
      [Workstation] [nvarchar](24) NOT NULL,
      [Comments] [varchar](max) NULL,
CONSTRAINT [PK_MonitorCalibration] PRIMARY KEY CLUSTERED 
(
      [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
";

        private const string CreateRoleOptionsTableString = @"
CREATE TABLE [dbo].[RoleOptions](
      [RoleName] [nvarchar](50) NOT NULL,
      [Key] [nvarchar](100) NOT NULL,
      [Value] [nvarchar](max) NULL,
CONSTRAINT [PK_RoleOptions] PRIMARY KEY CLUSTERED 
(
      [RoleName] ASC,
      [Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
";


        private const string CreateUserOptionsTableString = @"
CREATE TABLE [dbo].[UserOptions](
      [UserName] [nvarchar](256) NOT NULL,
      [Key] [nvarchar](100) NOT NULL,
      [Value] [nvarchar](max) NULL,
CONSTRAINT [PK_UserOptions] PRIMARY KEY CLUSTERED 
(
      [UserName] ASC,
      [Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
";






        private const string UpdateTemplateTableString = @"
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Template]') AND name = 'AutoMatching'
)
BEGIN
   DECLARE @sqlAutoMatching NVARCHAR(2048) 
   SET @sqlAutoMatching = 'UPDATE [Template] SET [AutoMatching] = NULL;';

   ALTER TABLE Template
   ADD [AutoMatching] [nvarchar](max) NULL  DEFAULT NULL
   EXEC sys.sp_executesql @query = @sqlAutoMatching;
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Template]') AND name = 'Availability'
)
BEGIN
   DECLARE @sqlAvailability NVARCHAR(2048) 
   SET @sqlAvailability = 'UPDATE [Template] SET [Availability] = 1;';

   ALTER TABLE Template
   ADD [Availability] int NOT NULL  DEFAULT 1
   EXEC sys.sp_executesql @query = @sqlAvailability;
END
";


      private const string UpdateDeprecatedSqlServerTypesString = @"
BEGIN
   ALTER TABLE dbo.[JobsQueue] ALTER COLUMN [error] VARCHAR(MAX)
	ALTER TABLE dbo.[JobsQueue] ALTER COLUMN [object] VARCHAR(MAX)
	ALTER TABLE dbo.[JobsQueue] ALTER COLUMN [userdata] VARCHAR(MAX)
   ALTER TABLE dbo.[MonitorCalibration] ALTER COLUMN [Comments] VARCHAR(MAX)
END
";


        private const string UpdateTemplateFramesTableString = @"
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[TemplateFrames]') AND name = 'PresentationSizeMode'
)
BEGIN
   DECLARE @sqlPresentationSizeMode NVARCHAR(2048) 
   SET @sqlPresentationSizeMode= 'UPDATE [TemplateFrames] SET [PresentationSizeMode] = ''ScaleToFit'';';

   ALTER TABLE TemplateFrames
   ADD [PresentationSizeMode] [nvarchar](15) NULL CONSTRAINT [DF_TemplateFrames_PresentationSizeMode]  DEFAULT (N'ScaleToFit')
   EXEC sys.sp_executesql @query = @sqlPresentationSizeMode;
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[TemplateFrames]') AND name = 'Magnification'
)
BEGIN
   DECLARE @sqlMagnification NVARCHAR(2048) 
   SET @sqlMagnification = 'UPDATE [TemplateFrames] SET [Magnification] = ''1'';';

   ALTER TABLE TemplateFrames
   ADD [Magnification] [float] NULL CONSTRAINT [DF_TemplateFrames_Magnification]  DEFAULT ((1.0))
   EXEC sys.sp_executesql @query = @sqlMagnification;
END
";

        private const string CreateTemplateTableString = @"IF NOT EXISTS 
(	SELECT name 
    FROM sys.stats
    WHERE object_id = OBJECT_ID( 'dbo.[AnatomicRegion]')
)
BEGIN
	CREATE TABLE [dbo].[AnatomicRegion](
		[CodeValue] [nvarchar](16) NOT NULL,
		[CodeMeaning] [nvarchar](64) NOT NULL,
		[CodingSchemeDesignator] [nvarchar](16) NOT NULL,
	 CONSTRAINT [PK_AnatomicDescription] PRIMARY KEY CLUSTERED 
	(
		[CodeValue] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

    INSERT [dbo].[AnatomicRegion] ([CodeValue], [CodeMeaning], [CodingSchemeDesignator]) VALUES (N'T-11170', N'Maxilla', N'SNM3')
    INSERT [dbo].[AnatomicRegion] ([CodeValue], [CodeMeaning], [CodingSchemeDesignator]) VALUES (N'T-11180', N'Mandible', N'SNM3')
    INSERT [dbo].[AnatomicRegion] ([CodeValue], [CodeMeaning], [CodingSchemeDesignator]) VALUES (N'T-D1213', N'Jaw Region', N'SNM3')
END

IF NOT EXISTS 
(	SELECT name 
    FROM sys.stats
    WHERE object_id = OBJECT_ID( 'dbo.[AnatomicDescription]')
)
BEGIN
	CREATE TABLE [dbo].[AnatomicDescription](
		[Id] [nvarchar](64) NOT NULL,
		[Name] [nvarchar](255) NOT NULL,
		[AnatomicRegionModiferCodeValue] [nvarchar](16) NULL,
		[AnatomicRegionCodeValue] [nvarchar](16) NULL,
		[Laterality] [nvarchar](10) NULL,
		[Comments] [nvarchar](255) NULL,
	 CONSTRAINT [PK_AnatomicDescription_1] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

    ALTER TABLE [dbo].[AnatomicDescription]  WITH CHECK ADD  CONSTRAINT [FK_AnatomicDescription_AnatomicRegion] FOREIGN KEY([AnatomicRegionCodeValue])
    REFERENCES [dbo].[AnatomicRegion] ([CodeValue])
    ALTER TABLE [dbo].[AnatomicDescription] CHECK CONSTRAINT [FK_AnatomicDescription_AnatomicRegion]

    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'10', N'Canine left upper', N'R-FB35B', N'T-11170', N'Left', NULL)
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'11', N'Premolar left upper (PM2)', N'R-FB359', N'T-11170', N'Left', N'Center of 2nd premolar')
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'12', N'Molar left upper (M2)', N'R-FB354', N'T-11170', N'Left', N'Center on 2nd molar')
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'13', N'Molar left lower (M3)', N'R-FB354', N'T-11180', N'Left', N'Center on 2nd molar')
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'14', N'Premolar left lower (PM3)', N'R-FB359', N'T-11180', N'Left', N'Center on 2nd molar')
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'15', N'Canine left lower', N'R-FB35B', N'T-11180', N'Left', NULL)
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'16', N'Incisors lower jaw', N'R-FB322', N'T-11180', N'Both', NULL)
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'17', N'Canine right lower', N'R-FB35B', N'T-11180', N'Right', NULL)
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'18', N'Premolar right lower (PM4)', N'R-FB359', N'T-11180', N'Right', N'Center on 2nd premolar')
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'19', N'Molar right lower (M4)', N'R-FB354', N'T-11180', N'Right', N'Center on 2nd molar')
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'20', N'BW molar right', N'R-FB354', N'T-D1213', N'Right', N'Center on 2nd molar')
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'21', N'BW premolar right', N'RF-B359', N'T-D1213', N'Right', N'Center on 2nd premolar')
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'22', N'BW premolar left', N'RF-B359', N'T-D1213', N'Left', N'Center on 2nd premolar')
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'23', N'BW molar left', N'R-FB354', N'T-D1213', N'Left', N'Center on 2nd molar')
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'4', N'Molar right upper (M1)', N'R-FB354', N'T-11170', N'Right', N'Center on 2nd molar')
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'5', N'Premolar right upper (PM1)', N'R-FB359', N'T-11170', N'Right', N'Center on 2nd premolar')
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'6', N'Canine right upper', N'R-FB35B', N'T-11170', N'Right', NULL)
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'7', N'Incisors right upper', N'R-FB35C', N'T-11170', N'Right', NULL)
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'8', N'Incisors upper jaw', N'R-FB322', N'T-11170', N'Both', NULL)
    INSERT [dbo].[AnatomicDescription] ([Id], [Name], [AnatomicRegionModiferCodeValue], [AnatomicRegionCodeValue], [Laterality], [Comments]) VALUES (N'9', N'Incisors left upper', N'R-FB35C
    ', N'T-11170', N'Left', NULL)
END

IF NOT EXISTS 
                      (	SELECT name 
                         FROM sys.stats
                         WHERE object_id = OBJECT_ID( 'dbo.[Template]')
                      )
                BEGIN

                    CREATE TABLE [dbo].[Template](
	                    [Id] [nvarchar](64) NOT NULL,
	                    [Name] [nvarchar](255) NOT NULL,
	                    [Comments] [nvarchar](255) NULL,
	                    [BuiltIn] [bit] NOT NULL,
	                    [Modality] [nvarchar](64) NOT NULL,
	                    [Created] [datetime] NULL,
	                    [Hidden] [bit] NULL CONSTRAINT [DF_Template_Hidden]  DEFAULT ((0)),
                       [AutoMatching] [nvarchar](max) NULL,
                       [Availability] [nvarchar](max) NULL,
                     CONSTRAINT [PK_Template] PRIMARY KEY CLUSTERED 
                    (
	                    [Id] ASC
                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                    ) ON [PRIMARY]

                    INSERT [dbo].[Template] ([Id], [Name], [Comments], [BuiltIn], [Modality], [Created], [Hidden], [AutoMatching], [Availability] ) VALUES (N'3590E864-DC73-46E5-BD52-BD7BB4A07833', N'FMX 20 (Anatomic Region)',  NULL, 1, N'DXIntraoralImageStorageProcessing',     NULL,                                           0, NULL, 1)
                    INSERT [dbo].[Template] ([Id], [Name], [Comments], [BuiltIn], [Modality], [Created], [Hidden], [AutoMatching], [Availability] ) VALUES (N'528D2A03-0722-498D-A4B5-22BD67DA8111', N'BW 2 Instance',             NULL, 1, N'DXIntraoralImageStorageProcessing',     NULL,                                           0, NULL, 3)
                    INSERT [dbo].[Template] ([Id], [Name], [Comments], [BuiltIn], [Modality], [Created], [Hidden], [AutoMatching], [Availability] ) VALUES (N'528D2A03-0722-498D-A4B5-22BD67DA8D71', N'BW 2',                      NULL, 1, N'DXIntraoralImageStorageProcessing',     NULL,                                           0, NULL, 1)
                    INSERT [dbo].[Template] ([Id], [Name], [Comments], [BuiltIn], [Modality], [Created], [Hidden], [AutoMatching], [Availability] ) VALUES (N'7663cd8b-1d19-491e-9d82-573391c4d111', N'MG Template Instance',      N'',  0, N'DXMammographyImageStorageProcessing',   CAST(N'2016-02-15 13:22:47.750' AS DateTime),   0, NULL, 1)
                    INSERT [dbo].[Template] ([Id], [Name], [Comments], [BuiltIn], [Modality], [Created], [Hidden], [AutoMatching], [Availability] ) VALUES (N'7663cd8b-1d19-491e-9d82-573391c4d222', N'MG Template Sequence',      N'',  0, N'DXMammographyImageStorageProcessing',   CAST(N'2016-02-15 13:22:47.750' AS DateTime),   0, NULL, 1)
                    INSERT [dbo].[Template] ([Id], [Name], [Comments], [BuiltIn], [Modality], [Created], [Hidden], [AutoMatching], [Availability] ) VALUES (N'7663cd8b-1d19-491e-9d82-573391c4d9a3', N'MG Template Script',        N'',  0, N'DXMammographyImageStorageProcessing',   CAST(N'2016-02-15 13:22:47.750' AS DateTime),   0, NULL, 1)
                    INSERT [dbo].[Template] ([Id], [Name], [Comments], [BuiltIn], [Modality], [Created], [Hidden], [AutoMatching], [Availability] ) VALUES (N'9CD74783-9DE1-4F86-9098-5B66BE64C111', N'FMX 18 Instance',           NULL, 1, N'DXIntraoralImageStorageProcessing',     NULL,                                           0, NULL, 1)
                    INSERT [dbo].[Template] ([Id], [Name], [Comments], [BuiltIn], [Modality], [Created], [Hidden], [AutoMatching], [Availability] ) VALUES (N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', N'FMX 18 (Anatomic Region)',  NULL, 1, N'DXIntraoralImageStorageProcessing',     NULL,                                           0, NULL, 1)
                    INSERT [dbo].[Template] ([Id], [Name], [Comments], [BuiltIn], [Modality], [Created], [Hidden], [AutoMatching], [Availability] ) VALUES (N'd658d475-3f86-4c74-ad2b-8447fad07b84', N'Sequential Template',       N'',  0, N'',                                      CAST(N'2016-02-01 11:57:30.823' AS DateTime),   0, NULL, 3)
                    INSERT [dbo].[Template] ([Id], [Name], [Comments], [BuiltIn], [Modality], [Created], [Hidden], [AutoMatching], [Availability] ) VALUES (N'F239623B-2F7E-4753-AA5E-C212F9F4F333', N'BW4',                       NULL, 1, N'DXIntraoralImageStorageProcessing',     NULL,                                           0, NULL, 1)
                END";                    

        private const string CreateTemplateFrameTableString = @"IF NOT EXISTS 
                      (	SELECT name 
                         FROM sys.stats
                         WHERE object_id = OBJECT_ID( 'dbo.[TemplateFrames]')
                      )
                BEGIN
                    CREATE TABLE [dbo].[TemplateFrames](
	                    [Id] [nvarchar](64) NOT NULL,
	                    [TemplateId] [nvarchar](64) NOT NULL,
	                    [FrameNumber] [int] NULL,
	                    [SequenceNumber] [int] NULL,
	                    [FrameRotation] [nvarchar](25) NULL,
	                    [HorizontalJustification] [nvarchar](25) NULL,
	                    [VerticalJustification] [nvarchar](25) NULL,
	                    [Comments] [nvarchar](256) NULL,
	                    [AnatomicDescriptionId] [nvarchar](64) NULL,
                        [Flip] [bit] NULL,
	                    [Reverse] [bit] NULL,
	                    [Invert] [bit] NULL,
	                    [Left] [float] NULL,
	                    [Top] [float] NULL,
	                    [Right] [float] NULL,
	                    [Bottom] [float] NULL,
                        [Script] [nvarchar](max) NULL
                     CONSTRAINT [PK_TemplateFrames_1] PRIMARY KEY CLUSTERED 
                    (
	                    [Id] ASC
                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                    ) ON [PRIMARY]

                    ALTER TABLE [dbo].[TemplateFrames]  WITH CHECK ADD  CONSTRAINT [FK_TemplateFrames_Template] FOREIGN KEY([TemplateId])
                    REFERENCES [dbo].[Template] ([Id])
                    ON UPDATE CASCADE
                    ON DELETE CASCADE

                    ALTER TABLE [dbo].[TemplateFrames] CHECK CONSTRAINT [FK_TemplateFrames_Template]
                    
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'000C7AA6-D0A4-45D5-983F-B03A1C1E1111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 2, 2, N'None', N'Center', N'Center', NULL, NULL, 0.1928783, 0.9457364, 0.3234421, 0.7325581, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'000C7AA6-D0A4-45D5-983F-B03A1C1E13C3', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 2, 2, N'None', N'Center', N'Center', NULL, NULL, 0.1928783, 0.9457364, 0.3234421, 0.7325581, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-11170''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-51009''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''R'';
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'0C680781-FFC7-4ED2-B0D8-9B38A79D3DCD', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 10, 10, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.04262673, 0.6507462, 0.156682, 0.4507463, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-D1213'';
var arms_codeValue = ''T-5100C'';
var img_laterality = ''R'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'0fcf1518-ebbe-4408-b372-f72bf183fdc3', N'd658d475-3f86-4c74-ad2b-8447fad07b84', 8, 8, N'None', N'Left', N'Top', N'', NULL, 0.25878003696857671, 0.39262472885032529, 0.48059149722735672, 0.11594488695309202, N'true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'1334a463-e5fa-4293-acc3-9cbae16a3111', N'7663cd8b-1d19-491e-9d82-573391c4d111', 4, 4, N'None', N'Left', N'Top', N'', NULL, 0.35736290819470118, 0.525691699604743, 0.6654343807763401, 0.031620553359683723, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'1334a463-e5fa-4293-acc3-9cbae16a3222', N'7663cd8b-1d19-491e-9d82-573391c4d222', 4, 4, N'None', N'Left', N'Top', N'', NULL, 0.35736290819470118, 0.525691699604743, 0.6654343807763401, 0.031620553359683723, N'true;')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'1334a463-e5fa-4293-acc3-9cbae16a3a3c', N'7663cd8b-1d19-491e-9d82-573391c4d9a3', 4, 4, N'None', N'Left', N'Top', N'', NULL, 0.35736290819470118, 0.525691699604743, 0.6654343807763401, 0.031620553359683723, N'var vcs = dicom[''00540220''];
var success = false;
var vcs_codeValue = ''R-10226'';
var img_laterality = ''L'';

if(vcs && vcs.Value && vcs.Value.length > 0){ 
  var seqItem = vcs.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(codeValue == vcs_codeValue){
	var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

	success = laterality == img_laterality;
  }
}')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'156c74c2-3394-432f-8f7d-2e72de26d111', N'7663cd8b-1d19-491e-9d82-573391c4d111', 2, 2, N'None', N'Left', N'Top', N'', NULL, 0.35736290819470118, 0.98023715415019763, 0.6654343807763401, 0.54545454545454541, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'156c74c2-3394-432f-8f7d-2e72de26d222', N'7663cd8b-1d19-491e-9d82-573391c4d222', 2, 2, N'None', N'Left', N'Top', N'', NULL, 0.35736290819470118, 0.98023715415019763, 0.6654343807763401, 0.54545454545454541, N'true;')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'156c74c2-3394-432f-8f7d-2e72de26d528', N'7663cd8b-1d19-491e-9d82-573391c4d9a3', 2, 2, N'None', N'Left', N'Top', N'', NULL, 0.35736290819470118, 0.98023715415019763, 0.6654343807763401, 0.54545454545454541, N'var vcs = dicom[''00540220''];
var success = false;
var vcs_codeValue = ''R-10242'';
var img_laterality = ''L'';

if(vcs && vcs.Value && vcs.Value.length > 0){ 
  var seqItem = vcs.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(codeValue == vcs_codeValue){
	var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

	success = laterality == img_laterality;
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'1A68AC3B-CCB9-4AFC-B869-E4D48009D5D5', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 9, 9, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.8352535, 0.9014925, 0.9493088, 0.7014925, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-5100C'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'20BFE63D-094F-4AEB-9D9B-21C48C57B621', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 17, 17, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.4608295, 0.5402985, 0.5299539, 0.2507463, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11180'';
var arms_codeValue = ''T-51005'';
var img_laterality = ''B'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'24BC8FFE-D2B0-4703-A245-21272EAC5111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 10, 10, N'None', N'Center', N'Center', NULL, NULL, 0.6617211, 0.6666666, 0.7922848, 0.4534883, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'24BC8FFE-D2B0-4703-A245-21272EAC531B', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 10, 10, N'None', N'Center', N'Center', NULL, NULL, 0.6617211, 0.6666666, 0.7922848, 0.4534883, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-D1213''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-51009''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''L'';
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'EA920501-9363-4FD9-B03F-B69CED8BFA3E', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 20, 20, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.8352535, 0.4, 0.9493088, 0.2, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11180'';
var arms_codeValue = ''T-5100C'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'3047DEE5-9AD2-423D-B922-555356AC1F52', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 3, 3, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.3087558, 0.8477612, 0.3778802, 0.5582089, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-51007'';
var img_laterality = ''R'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'3DF47BBF-596F-4CD9-B67E-D1DF0F61F111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 17, 17, N'None', N'Center', N'Center', NULL, NULL, 0.6617211, 0.399224, 0.7922848, 0.1860465, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'3DF47BBF-596F-4CD9-B67E-D1DF0F61FF76', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 17, 17, N'None', N'Center', N'Center', NULL, NULL, 0.6617211, 0.399224, 0.7922848, 0.1860465, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-11180''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-51009''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''L'';
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'3D7EB9C4-8F0D-4C99-B322-88FEF285C4CB', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 8, 8, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.6947005, 0.9014925, 0.8087558, 0.7014925, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-51009'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'3EB14815-6E5A-4A31-9E43-3FCB59337ABC', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 7, 7, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.6129032, 0.8477612, 0.6820276, 0.5582089, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-51007'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'402F05C3-2C00-4A99-BD77-503AFA7629A7', N'F239623B-2F7E-4753-AA5E-C212F9F4F333', 4, 4, N'None', N'Center', N'Center', NULL, NULL, 0.7337807, 0.8248175, 0.9306487, 0.4233577, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-D1213''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-5100C''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''L'';
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'45714ddf-40ac-4540-ba08-251702efa126', N'd658d475-3f86-4c74-ad2b-8447fad07b84', 9, 9, N'None', N'Left', N'Top', N'', NULL, 0.49291435613062229, 0.39262472885032529, 0.73937153419593349, 0.11594488695309202, N'true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'45dd69a8-4d86-4a85-91b7-87f9cf71ec84', N'd658d475-3f86-4c74-ad2b-8447fad07b84', 2, 2, N'None', N'Left', N'Top', N'', NULL, 0.25878003696857671, 0.95661605206073752, 0.48059149722735672, 0.7194619018631091, N'true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'3F0D0842-04F8-4DD7-820A-FC5813DE41A5', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 2, 2, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.1831797, 0.9014925, 0.297235, 0.7014925, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-51009'';
var img_laterality = ''R'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'481856A4-B5BC-4DE0-9A60-31F1A5DE1FE7', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 18, 18, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.5437788, 0.5402985, 0.6129032, 0.2507463, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11180'';
var arms_codeValue = ''T-51007'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'4A29DA47-705F-47B6-BDC2-9B04AD272A75', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 16, 16, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.3778802, 0.5402985, 0.4470046, 0.2507463, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11180'';
var arms_codeValue = ''T-51007'';
var img_laterality = ''R'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'4B6C5069-C5E4-4182-8F9B-E3B79A297572', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 1, 1, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.04262673, 0.9014925, 0.156682, 0.7014925, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-5100C'';
var img_laterality = ''R'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'501c8115-c6fe-4b29-b4ec-9b21f78341b7', N'd658d475-3f86-4c74-ad2b-8447fad07b84', 5, 5, N'None', N'Left', N'Top', N'', NULL, 0.25878003696857671, 0.69631236442516264, 0.48059149722735672, 0.399869676678127, N'true')                    
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'4FFD727C-82B6-4245-BEF7-34C375DF26F6', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 13, 13, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.8352535, 0.6507462, 0.9493088, 0.4507463, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-D1213'';
var arms_codeValue = ''T-5100C'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'54D406E5-31FC-4B64-B646-A41C3945B111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 6, 6, N'None', N'Center', N'Center', NULL, NULL, 0.6617211, 0.9457364, 0.7922848, 0.7325581, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'54D406E5-31FC-4B64-B646-A41C3945BB92', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 6, 6, N'None', N'Center', N'Center', NULL, NULL, 0.6617211, 0.9457364, 0.7922848, 0.7325581, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-51009'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == arms_codeValue){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == img_laterality;
	  }
	}
  }
}

success == true')                    
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'5A53AC34-36B2-47A3-B34C-CB8589470111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 3, 3, N'None', N'Center', N'Center', NULL, NULL, 0.3531157, 0.9457364, 0.4272997, 0.6511628, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'5A53AC34-36B2-47A3-B34C-CB8589470C71', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 3, 3, N'None', N'Center', N'Center', NULL, NULL, 0.3531157, 0.9457364, 0.4272997, 0.6511628, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-51007'';
var img_laterality = ''R'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == arms_codeValue){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == img_laterality;
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'5387A390-74CC-4B49-875E-E2E85916DC10', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 12, 12, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.6947005, 0.6507462, 0.8087558, 0.4507463, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-D1213'';
var arms_codeValue = ''T-51009'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'5e1fb4b3-496d-40ce-b271-a8e44c6cbdca', N'd658d475-3f86-4c74-ad2b-8447fad07b84', 4, 4, N'None', N'Left', N'Top', N'', NULL, 0.01232285890326552, 0.69631236442516264, 0.24645717806531114, 0.399869676678127, N'true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'61B55A5F-940F-4224-A506-DB8E0BF38111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 11, 11, N'None', N'Center', N'Center', NULL, NULL, 0.8204748, 0.6666666, 0.9510386, 0.4534883, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'61B55A5F-940F-4224-A506-DB8E0BF38EC2', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 11, 11, N'None', N'Center', N'Center', NULL, NULL, 0.8204748, 0.6666666, 0.9510386, 0.4534883, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-D1213''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-5100C''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''L'';
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'6366234D-6F03-435A-82E3-F67BCFF42111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 15, 15, N'None', N'Center', N'Center', NULL, NULL, 0.458457, 0.4767442, 0.5326409, 0.1821706, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'6366234D-6F03-435A-82E3-F67BCFF42622', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 15, 15, N'None', N'Center', N'Center', NULL, NULL, 0.458457, 0.4767442, 0.5326409, 0.1821706, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11180'';
var arms_codeValue = ''T-51005'';
var img_laterality = ''B'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == arms_codeValue){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == img_laterality;
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'5DC67429-7663-41EF-A39C-45D2A09AF79F', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 15, 15, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.1831797, 0.4, 0.297235, 0.2, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11180'';
var arms_codeValue = ''T-51009'';
var img_laterality = ''R'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')                    
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'82d13d93-7fd9-4453-868a-2429e6dab936', N'd658d475-3f86-4c74-ad2b-8447fad07b84', 6, 6, N'None', N'Left', N'Top', N'', NULL, 0.49291435613062229, 0.69631236442516264, 0.73937153419593349, 0.399869676678127, N'true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'85384F03-1F58-4895-9C13-741CEDFFF111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 9, 9, N'None', N'Center', N'Center', NULL, NULL, 0.1928783, 0.6666666, 0.3234421, 0.4534883, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'85384F03-1F58-4895-9C13-741CEDFFFAD0', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 9, 9, N'None', N'Center', N'Center', NULL, NULL, 0.1928783, 0.6666666, 0.3234421, 0.4534883, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-D1213''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-51009''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''R'';
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'68AA3597-D5E0-4B6C-80C2-A1925952485D', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 4, 4, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.3847926, 0.8477612, 0.4539171, 0.5582089, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-51006'';
var img_laterality = ''R'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'8e409e2f-f028-4418-96ba-185e10746111', N'7663cd8b-1d19-491e-9d82-573391c4d111', 1, 1, N'None', N'Left', N'Top', N'', NULL, 0.012322858903265557, 0.98023715415019763, 0.30807147258163892, 0.54545454545454541, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'8e409e2f-f028-4418-96ba-185e10746222', N'7663cd8b-1d19-491e-9d82-573391c4d222', 1, 1, N'None', N'Left', N'Top', N'', NULL, 0.012322858903265557, 0.98023715415019763, 0.30807147258163892, 0.54545454545454541, N'true;')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'8e409e2f-f028-4418-96ba-185e10746496', N'7663cd8b-1d19-491e-9d82-573391c4d9a3', 1, 1, N'None', N'Left', N'Top', N'', NULL, 0.012322858903265557, 0.98023715415019763, 0.30807147258163892, 0.54545454545454541, N'var vcs = dicom[''00540220''];
var success = false;
var vcs_codeValue = ''R-10242'';
var img_laterality = ''R'';

if(vcs && vcs.Value && vcs.Value.length > 0){ 
  var seqItem = vcs.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(codeValue == vcs_codeValue){
	var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

	success = laterality == img_laterality;
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'91E19AEE-CB30-46A6-91CC-E831C1B08111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 1, 1, N'None', N'Center', N'Center', NULL, NULL, 0.03412463, 0.9457364, 0.1646884, 0.7325581, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'91E19AEE-CB30-46A6-91CC-E831C1B08E1C', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 1, 1, N'None', N'Center', N'Center', NULL, NULL, 0.03412463, 0.9457364, 0.1646884, 0.7325581, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-11170''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-5100C''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''R'';
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'8706CA65-DB2B-4211-A127-28B236F9EEE7', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 5, 5, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.4608295, 0.8477612, 0.5299539, 0.5582089, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-51005'';
var img_laterality = ''B'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'952ADDED-048C-4C7A-94C4-E440FC5C7111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 13, 13, N'None', N'Center', N'Center', NULL, NULL, 0.1928783, 0.3953488, 0.3234421, 0.1821706, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'952ADDED-048C-4C7A-94C4-E440FC5C7BCA', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 13, 13, N'None', N'Center', N'Center', NULL, NULL, 0.1928783, 0.3953488, 0.3234421, 0.1821706, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-11180''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-51009''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''R'';
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'92735436-B2A3-4440-830C-A91EC1850EB2', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 19, 19, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.6947005, 0.4, 0.8087558, 0.2, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11180'';
var arms_codeValue = ''T-51009'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'9A0E5EF0-DA01-46F1-90B8-4AE6378E0B1C', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 6, 6, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.5368664, 0.8477612, 0.6059908, 0.5582089, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-51006'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'9DF1FEF0-190C-40EA-94F7-34498202A111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 5, 5, N'None', N'Center', N'Center', NULL, NULL, 0.5608308, 0.9457364, 0.6350148, 0.6511628, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'9DF1FEF0-190C-40EA-94F7-34498202A8EF', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 5, 5, N'None', N'Center', N'Center', NULL, NULL, 0.5608308, 0.9457364, 0.6350148, 0.6511628, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-51007'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == arms_codeValue){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == img_laterality;
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'9ECB483A-E59B-4984-9AF2-86D30E9AB111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 4, 4, N'None', N'Center', N'Center', NULL, NULL, 0.458457, 0.9457364, 0.5326409, 0.6511628, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'9ECB483A-E59B-4984-9AF2-86D30E9AB469', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 4, 4, N'None', N'Center', N'Center', NULL, NULL, 0.458457, 0.9457364, 0.5326409, 0.6511628, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-51005'';
var img_laterality = ''B'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == arms_codeValue){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == img_laterality;
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'9F044638-AFDA-4B64-B3CF-DC3A27B89111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 18, 18, N'None', N'Center', N'Center', NULL, NULL, 0.8204748, 0.3953488, 0.9510386, 0.1821706, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'9F044638-AFDA-4B64-B3CF-DC3A27B89B30', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 18, 18, N'None', N'Center', N'Center', NULL, NULL, 0.8204748, 0.3953488, 0.9510386, 0.1821706, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11180'';
var arms_codeValue = ''T-5100C'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == arms_codeValue){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == img_laterality;
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'b00079f7-2f80-4cde-9816-99b7e3d995be', N'd658d475-3f86-4c74-ad2b-8447fad07b84', 3, 3, N'None', N'Left', N'Top', N'', NULL, 0.49291435613062229, 0.95661605206073752, 0.73937153419593349, 0.7194619018631091, N'true')                    
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'B29F2581-EB08-4C36-B034-6D61A73E6111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 12, 12, N'None', N'Center', N'Center', NULL, NULL, 0.03412463, 0.3992248, 0.1646884, 0.1860465, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'B29F2581-EB08-4C36-B034-6D61A73E6CF5', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 12, 12, N'None', N'Center', N'Center', NULL, NULL, 0.03412463, 0.3992248, 0.1646884, 0.1860465, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-11180''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-5100C''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''R'';
	  }
	}
  }
}

success == true')

INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'B6762400-B0F3-4179-A4FC-B564718BB111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 14, 14, N'None', N'Center', N'Center', NULL, NULL, 0.3531157, 0.4767442, 0.4272997, 0.1821706, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'B6762400-B0F3-4179-A4FC-B564718BB59D', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 14, 14, N'None', N'Center', N'Center', NULL, NULL, 0.3531157, 0.4767442, 0.4272997, 0.1821706, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11180'';
var arms_codeValue = ''T-51007'';
var img_laterality = ''R'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == arms_codeValue){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == img_laterality;
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'BDBEF593-64C8-485C-AB3B-4685E177210C', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 7, 7, N'None', N'Center', N'Center', NULL, NULL, 0.8204748, 0.9457364, 0.9510386, 0.7325581, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11170'';
var arms_codeValue = ''T-5100C'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == arms_codeValue){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == img_laterality;
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'BDBEF593-64C8-485C-AB3B-4685E1772111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 7, 7, N'None', N'Center', N'Center', NULL, NULL, 0.8204748, 0.9457364, 0.9510386, 0.7325581, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'CB8B546A-A74B-414F-99E8-75E871984111', N'528D2A03-0722-498D-A4B5-22BD67DA8111', 2, 2, N'None', N'Center', N'Center', NULL, NULL, 0.55, 0.75, 0.94, 0.25, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'CB8B546A-A74B-414F-99E8-75E8719843E6', N'528D2A03-0722-498D-A4B5-22BD67DA8D71', 2, 2, N'None', N'Center', N'Center', NULL, NULL, 0.55, 0.75, 0.94, 0.25, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-D1213''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-51009''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''L'';
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'9B86327E-D4C8-4185-847F-D84A654819B2', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 14, 14, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.04262673, 0.4, 0.156682, 0.2, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11180'';
var arms_codeValue = ''T-5100C'';
var img_laterality = ''R'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'CECA89E6-D097-428A-A695-8BE66FA3218E', N'F239623B-2F7E-4753-AA5E-C212F9F4F333', 2, 2, N'None', N'Center', N'Center', NULL, NULL, 0.2774049, 0.8248175, 0.4742729, 0.4233577, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-D1213''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-51009''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''R'';
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'cefee072-13b4-4f5e-b4e0-973eaa576203', N'd658d475-3f86-4c74-ad2b-8447fad07b84', 7, 7, N'None', N'Left', N'Top', N'', NULL, 0.01232285890326552, 0.39262472885032529, 0.24645717806531114, 0.11594488695309202, N'true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'D0399507-5BB2-4DB1-ADFF-CDDEAE183111', N'528D2A03-0722-498D-A4B5-22BD67DA8111', 1, 1, N'None', N'Center', N'Center', NULL, NULL, 0.06, 0.75, 0.45, 0.25, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'D0399507-5BB2-4DB1-ADFF-CDDEAE183619', N'528D2A03-0722-498D-A4B5-22BD67DA8D71', 1, 1, N'None', N'Center', N'Center', NULL, NULL, 0.06, 0.75, 0.45, 0.25, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-D1213''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-51009''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''R'';
	  }
	}
  }
}

success == true')

INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'D9F77408-CDAC-4F3E-896B-6CC99C998111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 8, 8, N'None', N'Center', N'Center', NULL, NULL, 0.03412463, 0.6666666, 0.1646884, 0.4534883, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'D9F77408-CDAC-4F3E-896B-6CC99C998D63', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 8, 8, N'None', N'Center', N'Center', NULL, NULL, 0.03412463, 0.6666666, 0.1646884, 0.4534883, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-D1213''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-5100C''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''R'';
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'DFC1516E-8535-495B-AD79-F28626C93FA8', N'F239623B-2F7E-4753-AA5E-C212F9F4F333', 1, 1, N'None', N'Center', N'Center', NULL, NULL, 0.049217, 0.824817, 0.246085, 0.4233577, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-D1213''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-5100C''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''R'';
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'e724e019-edbf-44e2-8899-bc6d8c561111', N'7663cd8b-1d19-491e-9d82-573391c4d111', 3, 3, N'None', N'Left', N'Top', N'', NULL, 0.012322858903265557, 0.525691699604743, 0.30807147258163892, 0.031620553359683723, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'e724e019-edbf-44e2-8899-bc6d8c561222', N'7663cd8b-1d19-491e-9d82-573391c4d222', 3, 3, N'None', N'Left', N'Top', N'', NULL, 0.012322858903265557, 0.525691699604743, 0.30807147258163892, 0.031620553359683723, N'true;')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'e724e019-edbf-44e2-8899-bc6d8c561525', N'7663cd8b-1d19-491e-9d82-573391c4d9a3', 3, 3, N'None', N'Left', N'Top', N'', NULL, 0.012322858903265557, 0.525691699604743, 0.30807147258163892, 0.031620553359683723, N'var vcs = dicom[''00540220''];
var success = false;
var vcs_codeValue = ''R-10226'';
var img_laterality = ''R'';

if(vcs && vcs.Value && vcs.Value.length > 0){ 
  var seqItem = vcs.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(codeValue == vcs_codeValue){
	var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

	success = laterality == img_laterality;
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Flip], [Reverse], [Invert], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'CD4F783B-17AB-490B-853C-9E97A00C9DD4', N'3590E864-DC73-46E5-BD52-BD7BB4A07833', 11, 11, N'None', N'Center', N'Center', NULL, NULL, 0, 0, 0, 0.1831797, 0.6507462, 0.297235, 0.4507463, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-D1213'';
var arms_codeValue = ''T-51009'';
var img_laterality = ''R'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 
    
  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
    var arms = seqItem[''00082220''];
    
    if(arms && arms.Value){
      var item = arms.Value[0];
      
      codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
      //alert(codeValue);
      if(codeValue == arms_codeValue){
        var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 
        
        success = laterality == img_laterality;
      }
    }
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'F3E9FB47-7877-4B61-90F2-028869404A27', N'F239623B-2F7E-4753-AA5E-C212F9F4F333', 3, 3, N'None', N'Center', N'Center', NULL, NULL, 0.5055928, 0.8248175, 0.7024608, 0.4233577, N'var ars = dicom[''00082218''];
var success = false;

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ''T-D1213''){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == ''T-51009''){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == ''L'';
	  }
	}
  }
}

success == true')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'FB122EBF-C09A-4226-8FDC-F843F7F34111', N'9CD74783-9DE1-4F86-9098-5B66BE64C111', 16, 16, N'None', N'Center', N'Center', NULL, NULL, 0.5608308, 0.4767442, 0.6350148, 0.1821706, N'')
INSERT [dbo].[TemplateFrames] ([Id], [TemplateId], [FrameNumber], [SequenceNumber], [FrameRotation], [HorizontalJustification], [VerticalJustification], [Comments], [AnatomicDescriptionId], [Left], [Top], [Right], [Bottom], [Script]) VALUES (N'FB122EBF-C09A-4226-8FDC-F843F7F34423', N'9CD74783-9DE1-4F86-9098-5B66BE64CAD2', 16, 16, N'None', N'Center', N'Center', NULL, NULL, 0.5608308, 0.4767442, 0.6350148, 0.1821706, N'var ars = dicom[''00082218''];
var success = false;
var ars_codeValue = ''T-11180'';
var arms_codeValue = ''T-51007'';
var img_laterality = ''L'';

if(ars && ars.Value && ars.Value.length > 0){ 
  var seqItem = ars.Value[0];
  var codeValue = seqItem[''00080100''] && seqItem[''00080100''].Value?seqItem[''00080100''].Value[0]:''''; 

  if(seqItem && seqItem[''00082220''] && codeValue == ars_codeValue){
	var arms = seqItem[''00082220''];

	if(arms && arms.Value){
	  var item = arms.Value[0];

	  codeValue = item[''00080100''] && item[''00080100''].Value?item[''00080100''].Value[0]:'''';       
	  //alert(codeValue);
	  if(codeValue == arms_codeValue){
		var laterality = dicom[''00200062''] && dicom[''00200062''].Value?dicom[''00200062''].Value[0]:''''; 

		success = laterality == img_laterality;
	  }
	}
  }
}

success == true')
                    
                END";


        private const string InsertWebViewerJsOptionsString = @"
DELETE FROM [dbo].[Options] WHERE [Key] = 'AllowOnlyWorklistQuery'
DELETE FROM [dbo].[Options] WHERE [Key] = 'AllowOnlyWorklistQuery'
DELETE FROM [dbo].[Options] WHERE [Key] = 'AutoStartCapture'
DELETE FROM [dbo].[Options] WHERE [Key] = 'BlockWhileLoading'
DELETE FROM [dbo].[Options] WHERE [Key] = 'CaptureInfoTextColor'
DELETE FROM [dbo].[Options] WHERE [Key] = 'CaptureInfoTextRectFillColor'
DELETE FROM [dbo].[Options] WHERE [Key] = 'ConfirmWorklistSelection'
DELETE FROM [dbo].[Options] WHERE [Key] = 'DateFormat'
DELETE FROM [dbo].[Options] WHERE [Key] = 'DefaultSeriesColumnCount'
DELETE FROM [dbo].[Options] WHERE [Key] = 'DefaultSeriesRowCount'
DELETE FROM [dbo].[Options] WHERE [Key] = 'DentalMode'
DELETE FROM [dbo].[Options] WHERE [Key] = 'DerivedSeriesDescriptionText'
DELETE FROM [dbo].[Options] WHERE [Key] = 'disabledName'
DELETE FROM [dbo].[Options] WHERE [Key] = 'DisabledToolbarItems_main'
DELETE FROM [dbo].[Options] WHERE [Key] = 'EmptyCellBackgroundColor'
DELETE FROM [dbo].[Options] WHERE [Key] = 'EnableAuditLog'
DELETE FROM [dbo].[Options] WHERE [Key] = 'EnableIdleTimeout'
DELETE FROM [dbo].[Options] WHERE [Key] = 'EnableModalityWorklistQuery'
DELETE FROM [dbo].[Options] WHERE [Key] = 'EnablePatientIdAutoComplete'
DELETE FROM [dbo].[Options] WHERE [Key] = 'EnablePatientNameAutoComplete'
DELETE FROM [dbo].[Options] WHERE [Key] = 'EnableProtocolNameEdit'
DELETE FROM [dbo].[Options] WHERE [Key] = 'EnableSeriesNumberEdit'
DELETE FROM [dbo].[Options] WHERE [Key] = 'HideOverlays'
DELETE FROM [dbo].[Options] WHERE [Key] = 'IdleTimeout'
DELETE FROM [dbo].[Options] WHERE [Key] = 'IdleWarningDuration'
DELETE FROM [dbo].[Options] WHERE [Key] = 'IssuerOfPatientID'
DELETE FROM [dbo].[Options] WHERE [Key] = 'LogSecuritySettingChanges'
DELETE FROM [dbo].[Options] WHERE [Key] = 'LogSettingChanges'
DELETE FROM [dbo].[Options] WHERE [Key] = 'LogUserActivity'
DELETE FROM [dbo].[Options] WHERE [Key] = 'LogUserSecurity'
DELETE FROM [dbo].[Options] WHERE [Key] = 'OverlaySettings'
DELETE FROM [dbo].[Options] WHERE [Key] = 'PatientIdMask'
DELETE FROM [dbo].[Options] WHERE [Key] = 'SearchOtherPatientIds'
DELETE FROM [dbo].[Options] WHERE [Key] = 'SeriesThumbnailHeight'
DELETE FROM [dbo].[Options] WHERE [Key] = 'SeriesThumbnailWidth'
DELETE FROM [dbo].[Options] WHERE [Key] = 'ShowPacsQuery'
DELETE FROM [dbo].[Options] WHERE [Key] = 'ShowSearchThumbnails'
DELETE FROM [dbo].[Options] WHERE [Key] = 'SinglePatientMode'
DELETE FROM [dbo].[Options] WHERE [Key] = 'SingleSeriesMode'
DELETE FROM [dbo].[Options] WHERE [Key] = 'TimeFormat'
DELETE FROM [dbo].[Options] WHERE [Key] = 'Toolbar_main'
DELETE FROM [dbo].[Options] WHERE [Key] = 'Toolbars'
DELETE FROM [dbo].[Options] WHERE [Key] = 'MaxStudyResults'
DELETE FROM [dbo].[Options] WHERE [Key] = 'MaxSeriesResults'
DELETE FROM [dbo].[Options] WHERE [Key] = 'MaxPatientResults'
DELETE FROM [dbo].[Options] WHERE [Key] = 'TemplateBackgroundColor'
DELETE FROM [dbo].[Options] WHERE [Key] = 'TemplateBorderColor'
DELETE FROM [dbo].[Options] WHERE [Key] = 'TemplateBorderSize'
DELETE FROM [dbo].[Options] WHERE [Key] = 'TemplateBoundsNotification'
DELETE FROM [dbo].[Options] WHERE [Key] = 'TemplateForeColor'
DELETE FROM [dbo].[Options] WHERE [Key] = 'DefaultScript'

INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'BlockWhileLoading', N'true')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'DateFormat', N'MM/dd/yyyy')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'DefaultSeriesColumnCount', N'2')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'DefaultSeriesRowCount', N'2')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'DentalMode', N'false')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'DerivedSeriesDescriptionText', N'(Derived)')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'disabledName', N'[]')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'DisabledToolbarItems_main', N'[]')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'EmptyCellBackgroundColor', N'#0F0F0F')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'EnableAuditLog', N'true')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'EnableIdleTimeout', N'true')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'EnablePatientIdAutoComplete', N'true')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'EnablePatientNameAutoComplete', N'true')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'EnableProtocolNameEdit', N'true')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'EnableSeriesNumberEdit', N'true')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'HideOverlays', N'false')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'IdleTimeout', N'300')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'IdleWarningDuration', N'30')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'LogSecuritySettingChanges', N'false')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'LogSettingChanges', N'true')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'LogUserActivity', N'true')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'LogUserSecurity', N'true')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'OverlaySettings', N'')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'SearchOtherPatientIds', N'false')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'SeriesThumbnailHeight', N'50')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'SeriesThumbnailWidth', N'50')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'ShowPacsQuery', N'true')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'ShowSearchThumbnails', N'true')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'SinglePatientMode', N'false')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'SingleSeriesMode', N'false')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'TimeFormat', N' hh:mm:ss tt')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'MaxStudyResults', N'0')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'MaxSeriesResults', N'0')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'MaxPatientResults', N'0')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'TemplateBackgroundColor', N'000000')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'TemplateBorderColor', N'#FF0000')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'TemplateBorderSize', N'2')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'TemplateBoundsNotification', N'true')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'TemplateForeColor', N'#FFFFFF')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'DefaultScript', N'true;')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'Toolbar_main', N' " + 
MedicalToolbar + 
@"')
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'Toolbars', N'[""main""]')
";



        private const string JobsQueueTableName = "JobsQueue";
        private const string RolesPatientsTableName = "RolesPatients";
        private const string AnnotationsTableName = "Annotations";
        private const string UserPermissionsListTableName = "UserPermissionsList";
        private const string VersionTableName = "WVDbVersion";

#if LEADTOOLS_V19_OR_LATER
        private const string MonitorCalibrationTableName = "MonitorCalibration";
        private const string RoleOptionsTableName = "RoleOptions";
        private const string UserOptionsTableName = "UserOptions";
        private const string TemplateTableName = "Template";
        private const string TemplateFramesTableName = "TemplateFrames";

        private const string InsertWebViewerJsClientAEString = @"DELETE FROM [dbo].[Options] WHERE [Key] = 'RemotePacsConfig'
INSERT [dbo].[Options] ([Key], [Value]) VALUES (N'RemotePacsConfig', N'{""clientAeTitle"":""CLIENTAE"",""remotePacs"":[],""activePacsServer"":""""}')";
#endif

        private const string CreateVersionTableString = @"
CREATE TABLE [" + VersionTableName + @"] (
	[Major] [int] NOT NULL ,
	[Minor] [int] NOT NULL ,
	CONSTRAINT [PK_WV_Major_Minor] PRIMARY KEY  CLUSTERED 
	(
		[Major],
		[Minor]
	)  ON [PRIMARY] 
) ON [PRIMARY]
";

        private const string DeleteAllVersionsString = @"DELETE FROM " + VersionTableName;

        private static string InsertWebViewerVersionString = @"
INSERT INTO [" + VersionTableName + @"] ([Major],[Minor]) VALUES (" + MajorVersion + "," + MinorVersion + ")";

        private const int MajorVersion = 1;
        private const int MinorVersion = 11;


#if LEADTOOLS_V19_OR_LATER
      private static IOptionsDataAccessAgent _optionsAgent;
      private static Configuration _configPacs;

      private static Dictionary<string, string> _dentalOptions;
      private static Dictionary<string, string> _medicalOptions;

      public static Configuration ConfigPacs
      {
          get
          {
              if (_configPacs == null)
              {
                  _configPacs = DicomDemoSettingsManager.GetGlobalPacsConfiguration();
              }
              return _configPacs;
          }
      }

      public static IOptionsDataAccessAgent OptionsAgent
      {
         get
         {
            if (_optionsAgent == null)
            {
               _optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();
            }
            return _optionsAgent;
         }
      }
      #region DentalToolbarRegion
public const string DentalToolbar = @"
{
  ""name"": ""main"",
  ""items"": [
    {
      ""id"": ""WindowLevel"",
      ""action"": ""WindowLevelInteractiveMode"",
      ""caption"":  ""W/L"", ""tooltip"": ""Window Level"",
      ""type"": ""button"",
      ""cssIconClass"": ""WindowLevel"",
      ""items"": []
    },
    {
      ""id"": ""WindowLevelCustom"",
      ""action"": ""WindowLevelCustom"",
      ""caption"":  ""Custom WL"", ""tooltip"": ""Custom Window Level"",
      ""type"": ""button"",
      ""cssIconClass"": ""WindowLevelCustom"",
      ""items"": []
    },
     {
      ""id"": ""Pan"",
      ""action"": ""Pan"",
      ""caption"":  ""Pan"", ""tooltip"": ""Pan"",
      ""type"": ""button"",
      ""cssIconClass"": ""Pan"",
      ""items"": []
    },
    {
      ""id"": ""Zoom"",
      ""action"": ""ZoomToInteractiveMode"",
      ""caption"":  ""Zoom"", ""tooltip"": ""Zoom"",
      ""type"": ""button"",
      ""cssIconClass"": ""Zoom"",
      ""items"": []
    },
    {
      ""id"": ""SpyglassGroup"",
          ""action"": ""OnSpyGlass"",
          ""caption"":  ""SpyGlass"", ""tooltip"": ""Spyglass"",
          ""type"": ""button"",
          ""cssIconClass"": ""Spyglass"",
      ""items"": [
        {
          ""id"": ""SpyGlass"",
          ""action"": ""OnSpyGlass"",
          ""caption"":  ""SpyGlass"", ""tooltip"": ""Spyglass"",
          ""type"": ""button"",
          ""cssIconClass"": ""Spyglass"",
          ""items"": []
        },
        {
          ""id"": ""SpyGlassInvert"",
          ""action"": ""OnSpyGlassInvert"",
          ""caption"":  ""Invert"", ""tooltip"": ""Spyglass Invert"",
          ""type"": ""button"",
          ""cssIconClass"": ""SpyglassInvert"",
          ""items"": []
        },
        {
          ""id"": ""SpyGlassCLAHE"",
          ""action"": ""OnSpyGlassCLAHE"",
          ""caption"":  ""Clahe"", ""tooltip"": ""Spyglass CLAHE"",
          ""type"": ""button"",
          ""cssIconClass"": ""SpyglassCLAHE"",
          ""items"": []
        },
        {
          ""id"": ""SpyGlassEqualization"",
          ""action"": ""OnSpyGlassEqualization"",
          ""caption"":  ""Revealer"", ""tooltip"": ""Revealer"",
          ""type"": ""button"",
          ""cssIconClass"": ""SpyGlassEqualization"",
          ""items"": []
        }
      ]
    },
    {
      ""id"": ""Stack"",
      ""action"": ""InteractiveStack"",
      ""caption"":  ""Stack"", ""tooltip"": ""Stack"",
      ""type"": ""button"",
      ""cssIconClass"": ""Stack"",
      ""items"": []
    },
    {
       ""id"":""ProbeTool"",
       ""action"":""OnProbeTool"",
       ""caption"":  ""Probe"", ""tooltip"":""Probe Tool"",
       ""type"":""button"",
       ""cssIconClass"":""ProbeTool"",
       ""items"":[]
    },
    {
      ""id"": ""FitImage"",
      ""action"": ""FitImage"",
      ""caption"":  ""Fit"", ""tooltip"": ""Fit"",
      ""type"": ""button"",
      ""cssIconClass"": ""FitImage"",
      ""items"": [
        {
          ""id"": ""FitImage"",
          ""action"": ""FitImage"",
          ""caption"":  ""Fit"", ""tooltip"": ""Fit"",
          ""type"": ""button"",
          ""cssIconClass"": ""FitImage"",
          ""items"": []
        },
        {
          ""id"": ""OneToOne"",
          ""action"": ""OneToOne"",
          ""caption"":  ""1-1"", ""tooltip"": ""One To One"",
          ""type"": ""button"",
          ""cssIconClass"": ""OneToOne"",
          ""items"": []
        },
        {
          ""id"": ""TrueSizeDisplay"",
          ""action"": ""TrueSizeDisplay"",
          ""caption"":  ""True Size"", ""tooltip"": ""True Size Display"",
          ""type"": ""button"",
          ""cssIconClass"": ""TrueSizeDisplay"",
          ""items"": []
        },
        {
          ""id"": ""ZoomIn"",
          ""action"": ""ZoomIn"",
          ""caption"":  ""Zoom In"", ""tooltip"": ""Zoom In"",
          ""type"": ""button"",
          ""cssIconClass"": ""ZoomIn"",
          ""items"": []
        },
        {
          ""id"": ""ZoomOut"",
          ""action"": ""ZoomOut"",
          ""caption"":  ""Zoom Out"", ""tooltip"": ""Zoom Out"",
          ""type"": ""button"",
          ""cssIconClass"": ""ZoomOut"",
          ""items"": []
        }
    ]
    },
    {
      ""id"": ""Orientation"",
      ""action"": ""RotateClockwise"",
      ""caption"":  ""Rotate C"", ""tooltip"": ""Rotate Clockwise"",
      ""type"": ""button"",
      ""cssIconClass"": ""RotateClock"",
      ""items"": [
        {
          ""id"": ""RotateClockwise"",
          ""action"": ""RotateClockwise"",
          ""caption"":  ""Rotate C"", ""tooltip"": ""Rotate Clockwise"",
          ""type"": ""button"",
          ""cssIconClass"": ""RotateClock"",
          ""items"": []
        },
        {
          ""id"": ""RotateCounterClock"",
          ""action"": ""RotateCounterclockwise"",
          ""caption"":  ""Rotate CC"", ""tooltip"": ""Rotate Counterclockwise"",
          ""type"": ""button"",
          ""cssIconClass"": ""RotateCounterClock"",
          ""items"": []
        },
        {
          ""id"": ""Flip"",
          ""action"": ""Flip"",
          ""caption"":  ""Flip"", ""tooltip"": ""Flip"",
          ""type"": ""button"",
          ""cssIconClass"": ""Flip"",
          ""items"": []
        },
        {
          ""id"": ""Reverse"",
          ""action"": ""Reverse"",
          ""caption"":  ""Reverse"", ""tooltip"": ""Reverse"",
          ""type"": ""button"",
          ""cssIconClass"": ""Reverse"",
          ""items"": []
        }
      ]
    }, " + 

#if LEADTOOLS_V19_OR_LATER
@" {
      ""id"": ""HorizontalAlignment"",
      ""action"": ""ImageAlignLeft"",
      ""caption"":  ""Left"", ""tooltip"": ""Align Left"",
      ""type"": ""button"",
      ""cssIconClass"": ""AlignLeft"",
      ""items"": [
      {
          ""id"": ""ImageAlignLeft"",
          ""action"": ""ImageAlignLeft"",
          ""caption"":  ""Left"", ""tooltip"": ""Align Left"",
          ""type"": ""button"",
          ""cssIconClass"": ""AlignLeft"",
          ""items"": []
    },
    {
          ""id"": ""ImageAlignRight"",
          ""action"": ""ImageAlignRight"",
          ""caption"":  ""Right"", ""tooltip"": ""Align Right"",
          ""type"": ""button"",
          ""cssIconClass"": ""AlignRight"",
          ""items"": []
        },
        {
          ""id"": ""ImageAlignCenter"",
          ""action"": ""ImageAlignCenter"",
          ""caption"":  ""Center"", ""tooltip"": ""Align Center"",
          ""type"": ""button"",
          ""cssIconClass"": ""AlignCenter"",
          ""items"": []
        }
      ]
    },
    {
      ""id"": ""VerticalAlignment"",
      ""action"": ""ImageAlignTop"",
      ""caption"":  ""Top"", ""tooltip"": ""Align Top"",
      ""type"": ""button"",
      ""cssIconClass"": ""AlignTop"",
      ""items"": [
      {
          ""id"": ""ImageAlignTop"",
          ""action"": ""ImageAlignTop"",
          ""caption"":  ""Top"", ""tooltip"": ""Align Top"",
          ""type"": ""button"",
          ""cssIconClass"": ""AlignTop"",
          ""items"": []
        },
        {
          ""id"": ""ImageAlignBottom"",
          ""action"": ""ImageAlignBottom"",
          ""caption"":  ""Bottom"", ""tooltip"": ""Align Bottom"",
          ""type"": ""button"",
          ""cssIconClass"": ""AlignBottom"",
          ""items"": []
        },
        {
          ""id"": ""ImageAlignMiddle"",
          ""action"": ""ImageAlignMiddle"",
          ""caption"":  ""Middle"", ""tooltip"": ""Align Middle"",
          ""type"": ""button"",
          ""cssIconClass"": ""AlignMiddle"",
          ""items"": []
        }
      ]
    },"
    +
#endif // #if LEADTOOLS_V19_OR_LATER
 @"{
      ""id"": ""Effects"",
      ""action"": ""Invert"",
      ""caption"":  ""Invert"", ""tooltip"": ""Invert"",
      ""type"": ""button"",
      ""cssIconClass"": ""InvertColor"",
      ""items"": [
        {
          ""id"": ""InvertColor"",
          ""action"": ""Invert"",
          ""caption"":  ""Invert"", ""tooltip"": ""Invert"",
          ""type"": ""button"",
          ""cssIconClass"": ""InvertColor"",
          ""items"": []
        },
        {
          ""id"": ""BrightnessContrast"",
          ""action"": ""BrightnessContrast"",
          ""caption"":  ""Lightness"", ""tooltip"": ""Brightness Contrast"",
          ""type"": ""button"",
          ""cssIconClass"": ""BrightnessContrast"",
          ""items"": []
        },
        {
          ""id"": ""HSL"",
          ""action"": ""HSL"",
          ""caption"":  ""HSL"", ""tooltip"": ""HSL"",
          ""type"": ""button"",
          ""cssIconClass"": ""HSL"",
          ""items"": []
        },
        {
          ""id"": ""StretchHistogram"",
          ""action"": ""StretchHistogram"",
          ""caption"":  ""Equalize"", ""tooltip"": ""Stretch Histogram"",
          ""type"": ""button"",
          ""cssIconClass"": ""StretchHistogram"",
          ""items"": []
        }
      ]
    },
    {
      ""id"": ""EdgeEnhancment"",
      ""action"": ""OnEdgeEnhancment"",
      ""caption"":  ""Enhance Edges"", ""tooltip"": ""Edge Enhancment"",
      ""type"": ""button"",
      ""cssIconClass"": ""EdgeEnhancment"",
      ""items"": []
    },
    {
      ""id"": ""Endo"",
      ""action"": ""OnToggleEndo"",
      ""caption"":  ""Endo"", ""tooltip"": ""Toggle Endo"",
      ""type"": ""button"",
      ""cssIconClass"": ""Endo"",
      ""items"": []
    },
    {
      ""id"": ""Perio"",
      ""action"": ""OnTogglePerio"",
      ""caption"":  ""Perio"", ""tooltip"": ""Toggle Perio"",
      ""type"": ""button"",
      ""cssIconClass"": ""Perio"",
      ""items"": []
    },
    {
      ""id"": ""Dentin"",
      ""action"": ""OnToggleDentin"",
      ""caption"":  ""Dentin"", ""tooltip"": ""Toggle Dentin"",
      ""type"": ""button"",
      ""cssIconClass"": ""Dentin"",
      ""items"": []
    },
    {
      ""id"": ""Annotations"",
      ""action"": ""OnAnnotationSelect"",
      ""caption"":  ""Select"", ""tooltip"": ""Select"",
      ""type"": ""button"",
      ""cssIconClass"": ""Select"",
      ""items"": [
        {
          ""id"": ""Select"",
          ""action"": ""OnAnnotationSelect"",
          ""caption"":  ""Select"", ""tooltip"": ""Select"",
          ""type"": ""button"",
          ""cssIconClass"": ""Select"",
          ""items"": []
        },
        {
          ""id"": ""Arrow"",
          ""action"": ""OnAnnotationArrow"",
          ""caption"":  ""Arrow"", ""tooltip"": ""Arrow"",
          ""type"": ""button"",
          ""cssIconClass"": ""Arrow"",
          ""items"": []
        },
        {
          ""id"": ""Point"",
          ""action"": ""OnAnnotationPoint"",
          ""caption"":  ""Point"", ""tooltip"": ""Point"",
          ""type"": ""button"",
          ""cssIconClass"": ""Point"",
          ""items"": []
        },
        {
          ""id"": ""Rectangle"",
          ""action"": ""OnAnnotationRectangle"",
          ""caption"":  ""Rectangle"", ""tooltip"": ""Rectangle"",
          ""type"": ""button"",
          ""cssIconClass"": ""Rectangle"",
          ""items"": []
        },
        {
          ""id"": ""Ellipse"",
          ""action"": ""OnAnnotationEllipse"",
          ""caption"":  ""Ellipse"", ""tooltip"": ""Ellipse"",
          ""type"": ""button"",
          ""cssIconClass"": ""Ellipse"",
          ""items"": []
        },
        {
          ""id"": ""Curve"",
          ""action"": ""OnAnnotationCurve"",
          ""caption"":  ""Curve"", ""tooltip"": ""Curve"",
          ""type"": ""button"",
          ""cssIconClass"": ""Curve"",
          ""items"": []
        },
        {
          ""id"": ""Line"",
          ""action"": ""OnAnnotationLine"",
          ""caption"":  ""Line"", ""tooltip"": ""Line"",
          ""type"": ""button"",
          ""cssIconClass"": ""Line"",
          ""items"": []
        },
        {
          ""id"": ""Freehand"",
          ""action"": ""OnAnnotationFreehand"",
          ""caption"":  ""Free Hand"", ""tooltip"": ""Freehand"",
          ""type"": ""button"",
          ""cssIconClass"": ""Freehand"",
          ""items"": []
        },
        {
          ""id"": ""Polyline"",
          ""action"": ""OnAnnotationPolyline"",
          ""caption"":  ""Poly line"", ""tooltip"": ""Polyline"",
          ""type"": ""button"",
          ""cssIconClass"": ""Polyline"",
          ""items"": []
        },
        {
          ""id"": ""Polygon"",
          ""action"": ""OnAnnotationPolygon"",
          ""caption"":  ""Polygon"", ""tooltip"": ""Polygon"",
          ""type"": ""button"",
          ""cssIconClass"": ""Polygon"",
          ""items"": []
        },
        {
          ""id"": ""Text"",
          ""action"": ""OnAnnotationText"",
          ""caption"":  ""Text"", ""tooltip"": ""Text"",
          ""type"": ""button"",
          ""cssIconClass"": ""Text"",
          ""items"": []
        },
        {
          ""id"": ""Note"",
          ""action"": ""OnAnnotationNote"",
          ""caption"":  ""Note"", ""tooltip"": ""Note"",
          ""type"": ""button"",
          ""cssIconClass"": ""Note"",
          ""items"": []
        },
        {
          ""id"": ""Highlight"",
          ""action"": ""OnAnnotationHighlight"",
          ""caption"":  ""Higlight"", ""tooltip"": ""Highlight"",
          ""type"": ""button"",
          ""cssIconClass"": ""Highlight"",
          ""items"": []
        },
        {
          ""id"": ""TextPointer"",
          ""action"": ""OnAnnotationTextPointer"",
          ""caption"":  ""Text pointer"", ""tooltip"": ""TextPointer"",
          ""type"": ""button"",
          ""cssIconClass"": ""TextPointer"",
          ""items"": []
        }
      ]
    },
    {
      ""id"": ""Measurements"",
      ""action"": ""OnAnnotationRuler"",
      ""caption"":  ""Measurement"", ""tooltip"": ""Ruler"",
      ""type"": ""button"",
      ""cssIconClass"": ""Ruler"",
      ""items"": [
        {
          ""id"": ""Ruler"",
          ""action"": ""OnAnnotationRuler"",
          ""caption"":  ""Ruler"", ""tooltip"": ""Ruler"",
          ""type"": ""button"",
          ""cssIconClass"": ""Ruler"",
          ""items"": []
        },
        {
          ""id"": ""PolyRuler"",
          ""action"": ""OnAnnotationPolyRuler"",
          ""caption"":  ""Poly ruler"", ""tooltip"": ""Poly Ruler"",
          ""type"": ""button"",
          ""cssIconClass"": ""PolyRuler"",
          ""items"": []
        },
        {
          ""id"": ""Protractor"",
          ""action"": ""OnAnnotationProtractor"",
          ""caption"":  ""Protractor"", ""tooltip"": ""Protractor"",
          ""type"": ""button"",
          ""cssIconClass"": ""Protractor"",
          ""items"": []
        },
        {
          ""id"": ""AnnMeasurementSeperator"",
          ""action"": """",
          ""caption"":  ""Sep"", ""tooltip"": """",
          ""type"": ""seperator"",
          ""cssIconClass"": """",
          ""items"": []
        },
        {
          ""id"": ""CalibrateRuler"",
          ""action"": ""OnCalibrateRuler"",
          ""caption"":  ""Calibrate"", ""tooltip"": ""Calibrate Ruler"",
          ""type"": ""button"",
          ""cssIconClass"": ""CalibrateRulerAnn"",
          ""items"": []
        }
      ]
    },
    {
      ""id"": ""AnnotationOptions"",
      ""action"": ""OnAnnotationShowHide"",
      ""caption"":  ""Show/Hide"", ""tooltip"": ""Show/Hide Annotations"",
      ""type"": ""button"",
      ""cssIconClass"": ""ShowHide"",
      ""items"": [
        {
          ""id"": ""AnnotationShowHide"",
          ""action"": ""OnAnnotationShowHide"",
          ""caption"":  ""Show/Hide"", ""tooltip"": ""Show/Hide Annotations"",
          ""type"": ""button"",
          ""cssIconClass"": ""ShowHide"",
          ""items"": []
        },
        {
          ""id"": ""DeleteAnnotations"",
          ""action"": ""OnDeleteAnnotation"",
          ""caption"":  ""Delete"", ""tooltip"": ""Delete Annotations"",
          ""type"": ""button"",
          ""cssIconClass"": ""DeleteAnn"",
          ""items"": []
        },
        {
          ""id"": ""ClearAnnotations"",
          ""action"": ""OnClearAnnotation"",
          ""caption"":  ""Clear"", ""tooltip"": ""Clear Annotations"",
          ""type"": ""button"",
          ""cssIconClass"": ""Clear"",
          ""items"": []
        },
        {
          ""id"": ""ClearAllAnnotations"",
          ""action"": ""OnClearAllAnnotation"",
          ""caption"":  ""Clear all"", ""tooltip"": ""Clear All Annotations"",
          ""type"": ""button"",
          ""cssIconClass"": ""ClearAll"",
          ""items"": []
        },
        {
          ""id"": ""SaveAnnSeperator"",
          ""action"": """",
          ""caption"":  ""Sep"", ""tooltip"": """",
          ""type"": ""seperator"",
          ""cssIconClass"": """",
          ""items"": []
        },
        {
          ""id"": ""SaveAnn"",
          ""action"": ""OnSaveAnnotations"",
          ""caption"":  ""Save"", ""tooltip"": ""Save Annotations"",
          ""type"": ""button"",
          ""cssIconClass"": ""SaveAnn"",
          ""items"": []
        },
        {
          ""id"": ""LoadAnn"",
          ""action"": ""OnLoadAnnotations"",
          ""caption"":  ""Load"", ""tooltip"": ""Load Annotations"",
          ""type"": ""button"",
          ""cssIconClass"": ""LoadAnn"",
          ""items"": []
        }
      ]
    },
    {
        ""id"": ""Reload"",
        ""action"": ""OnReload"",
        ""caption"":  ""Reload"", ""tooltip"": ""Reload"",
        ""type"": ""button"",
        ""cssIconClass"": ""Reload"",
        ""items"": []
    },
    {
      ""id"": ""ToggleTags"",
      ""action"": ""OnToggleTags"",
      ""caption"":  ""Overlays"", ""tooltip"": ""Overlays"",
      ""type"": ""button"",
      ""cssIconClass"": ""ToggleTags"",
      ""items"": []
    },
    {
      ""id"": ""ShowDicom"",
      ""action"": ""ShowDicom"",
      ""caption"":  ""Dicom Info"", ""tooltip"": ""Show Dicom"",
      ""type"": ""button"",
      ""cssIconClass"": ""ShowDicom"",
      ""items"": []
    },
    {
      ""id"": ""FullScreen"",
      ""action"": ""ToggleFullScreen"",
      ""caption"":  ""Full Screen"", ""tooltip"": ""Toggle Full Screen"",
      ""type"": ""button"",
      ""cssIconClass"": ""FullScreen"",
      ""items"": []
    },
    {
      ""id"": ""Rotate3D"",
      ""action"": ""OnRotate3D"",
      ""caption"":  ""Rotate 3D"", ""tooltip"": ""Rotate 3D Object"",
      ""type"": ""button"",
      ""cssIconClass"": ""Rotate3D"",
      ""items"": []
     },
     {
     ""id"": ""VolumeType"",
     ""action"": ""OnVRT"",
     ""caption"":  ""VRT"", ""tooltip"": ""3D Volume Type"",
     ""type"": ""button"",
     ""cssIconClass"": ""VRT"",
     ""items"": [
   {
     ""id"": ""VRT"",
     ""action"": ""OnVRT"",
     ""caption"":  ""VRT"", ""tooltip"": ""VRT"",
     ""type"": ""button"",
     ""cssIconClass"": ""VRT"",
     ""items"": []
   },
   {
     ""id"": ""MIP"",
     ""action"": ""OnMIP"",
     ""caption"":  ""MIP"", ""tooltip"": ""MIP"",
     ""type"": ""button"",
     ""cssIconClass"": ""MIP"",
     ""items"": []
   },
   {
     ""id"": ""MPR"",
     ""action"": ""OnMPRVolume"",
     ""caption"":  ""MPR"", ""tooltip"": ""MPR"",
     ""type"": ""button"",
     ""cssIconClass"": ""MPRVolume"",
     ""items"": []}]
   },
   {
     ""id"": ""DentalPanoramic"",
     ""action"": ""DentalPanoramic"",
     ""caption"":  ""Panoramic"", ""tooltip"": ""DentalPanoramic"",
     ""type"": ""button"",
     ""cssIconClass"": ""DentalPanoramic"",
     ""items"": []
   },
   {
     ""id"": ""Settings3D"",
     ""action"": ""OnSettings3D"",
     ""caption"":  ""Settings"", ""tooltip"": ""3D Settings"",
     ""type"": ""button"",
     ""cssIconClass"": ""Settings3D"",
     ""items"": [
    {
        ""id"": ""Settings3D"",
        ""action"": ""OnSettings3D"",
        ""caption"":  ""Settings"", ""tooltip"": ""3D Settings"",
        ""type"": ""button"",
        ""cssIconClass"": ""Settings3D"",
        ""items"": []
    },
    {
       ""id"":""CrossHair"",
       ""action"":""OnCrossHair"",
       ""caption"":  ""Cross Hair"", ""tooltip"":""Cross hair"",
       ""type"":""button"",
       ""cssIconClass"":""CrossHair"",
       ""items"":[]
    },
    {
     ""id"": ""HeadOrientation"",
     ""action"": ""OnHeadOrientation"",
     ""caption"":  ""Head"", ""tooltip"": ""Head"",
     ""type"": ""button"",
     ""cssIconClass"": ""HeadOrientation"",
     ""items"": []
   },
   {
     ""id"": ""FeetOrientation"",
     ""action"": ""OnFeetOrientation"",
     ""caption"":  ""Feet"", ""tooltip"": ""Feet"",
     ""type"": ""button"",
     ""cssIconClass"": ""FeetOrientation"",
     ""items"": []
   },
   {
     ""id"": ""LeftOrientation"",
     ""action"": ""OnLeftOrientation"",
     ""caption"":  ""Left"", ""tooltip"": ""Left Orientation"",
     ""type"": ""button"",
     ""cssIconClass"": ""LeftOrientation"",
     ""items"": []
   },
   {
     ""id"": ""RightOrientation"",
     ""action"": ""OnRightOrientation"",
     ""caption"":  ""Right"", ""tooltip"": ""Right Orientation"",
     ""type"": ""button"",
     ""cssIconClass"": ""RightOrientation"",
     ""items"": []
   },
   {
     ""id"": ""AnteriorOrientation"",
     ""action"": ""OnAnteriorOrientation"",
     ""caption"":  ""Anterior"", ""tooltip"": ""Anterior"",
     ""type"": ""button"",
     ""cssIconClass"": ""AnteriorOrientation"",
     ""items"": []
   },
   {
     ""id"": ""PosteriorOrientation"",
     ""action"": ""OnPosteriorOrientation"",
     ""caption"":  ""Posterior"", ""tooltip"": ""Posterior"",
     ""type"": ""button"",
     ""cssIconClass"": ""PosteriorOrientation"",
     ""items"": []} ]
   },
    {
      ""id"": ""DeleteCell"",
      ""action"": ""DeleteCell"",
      ""caption"":  ""Delete"", ""tooltip"": ""Delete Cell"",
      ""type"": ""button"",
      ""cssIconClass"": ""DeleteCell"",
      ""items"": []
    },
    {
      ""id"": ""StudyLayout"",
      ""action"": ""OnStudyLayout"",
      ""caption"":  ""Study Layout"", ""tooltip"": ""Change Study Layout"",
      ""type"": ""button"",
      ""cssIconClass"": ""StudyLayout"",
      ""items"": [
                    {
                      ""id"": ""StudyLayout"",
                      ""action"": ""OnStudyLayout"",
                      ""caption"":  ""Study Layout"", ""tooltip"": ""Change Study Layout"",
                      ""type"": ""button"",
                      ""cssIconClass"": ""StudyLayout"",
                      ""items"": []
                    },
                    {
                      ""id"": ""SeriesLayouts"",
                      ""action"": ""OnSeriesLayout"",
                      ""caption"":  ""Series Layout"", ""tooltip"": ""Change Series Layout"",
                      ""type"": ""button"",
                      ""cssIconClass"": ""SeriesLayout"",
                      ""items"": []
                    }
                 ]
    }," +
    @"
    {
        ""id"": ""ToggleCine"",
        ""action"": ""OnToggleCine"",
        ""caption"":  ""Cine"", ""tooltip"": ""Toggle Cine"",
        ""type"": ""button"",
        ""cssIconClass"": ""ToggleCine"",
        ""items"": [
	    {
        ""id"": ""ToggleCine"",
        ""action"": ""OnToggleCine"",
        ""caption"":  ""Play/Stop"", ""tooltip"": ""Toggle Cine"",
        ""type"": ""button"",
        ""cssIconClass"": ""ToggleCine"",
        ""items"": []
	    },
	  	{
        ""id"": ""CinePlayer"",
        ""action"": ""CinePlayer"",
        ""caption"":  ""Cine"", ""tooltip"": ""Cine Player"",
        ""type"": ""button"",
        ""cssIconClass"": ""CinePlayer"",
        ""items"": []
	    }
	    ]
    },
    {
     ""id"": ""PopupCapture"",
     ""action"": ""OnSecondaryCapturePopup"",
     ""caption"":  ""Print To PDF"", ""tooltip"": ""Print To PDF"",
      ""type"": ""button"",
     ""cssIconClass"": ""PopupCapture"",
      ""items"": [
                {
                    ""id"": ""SecondaryCapture"",
                    ""action"": ""OnSecondaryCapture"",
                    ""caption"":  ""Save Derived"", ""tooltip"": ""Save As Derived"",
                    ""type"": ""button"",
                    ""cssIconClass"": ""SecondaryCapture"",
                    ""items"": []
                },
                {
                  ""id"": ""Export"",
                  ""action"": ""OnExport"",
                  ""caption"":  ""Export"", ""tooltip"": ""Export"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""Export"",
                  ""items"": []
                },
                {
                  ""id"": ""PopupCapture"",
                  ""action"": ""OnSecondaryCapturePopup"",
                  ""caption"":  ""Print To PDF"", ""tooltip"": ""Print To PDF"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""PopupCapture"",
                  ""items"": []
                }
                ]
    },

    {
      ""id"": ""WaveformBasicAudio"",
      ""action"": ""OnWaveformBasicAudio"",
      ""caption"":  ""Audio"", ""tooltip"": ""Waveform Basic Audio"",
      ""type"": ""button"",
      ""cssIconClass"": ""WaveformBasicAudio"",
      ""items"": []
    },
    {
      ""id"":""ShutterObject"",
      ""action"":""OnShutterObject"",
      ""caption"":  ""Shutter"", ""tooltip"":""Shutter Object"",
      ""type"":""button"",
      ""cssIconClass"":""ShutterObject"",
      ""items"":[]
   },
    {
      ""id"": ""Cursor3D"",
      ""action"": ""OnCursor3D"",
      ""caption"":  ""3D Cursor"", ""tooltip"": ""3D Cursor"",
      ""type"": ""button"",
      ""cssIconClass"": ""Cursor3D"",
      ""items"": [
                {
                  ""id"": ""Cursor3D"",
                  ""action"": ""OnCursor3D"",
                  ""caption"":  ""3D Cursor"", ""tooltip"": ""3D Cursor"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""Cursor3D"",
                  ""items"": []
                },
                {
                  ""id"": ""ReferenceLine"",
                  ""action"": ""ToggleReferenceLine"",
                  ""caption"":  ""Reference Line"", ""tooltip"": ""Show Reference Line"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""ReferenceLine"",
                  ""items"": []
                },
               {
                  ""id"": ""ShowFirstLast"",
                  ""action"": ""ShowFirstLastReferenceLine"",
                  ""caption"":  ""First/Last"", ""tooltip"": ""Show First And Last Reference Line"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""ShowFirstLast"",
                  ""items"": []
                },
                {  
                   ""id"":""LineProfile"",
                   ""action"":""OnLineProfile"",
                   ""caption"":  ""Line Profile"", ""tooltip"":""Line Profile"",
                   ""type"":""button"",
                   ""cssIconClass"":""LineProfile"",
                   ""items"":[]
                },
                {
                  ""id"": ""SynchronizeSeries"",
                  ""action"": ""SetEnableSeriesSynchronization"",
                  ""caption"":  ""Synch"", ""tooltip"": ""Synchronize Series"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""Synchronization"",
                  ""items"": []
                },
                {
                  ""id"": ""LinkCells"",
                  ""action"": ""LinkCells"",
                  ""caption"":  ""Link Cells"", ""tooltip"": ""Link Cells"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""LinkStudies"",
                  ""items"": []
                },
                {
                  ""id"": ""LinkImages"",
                  ""action"": ""SetLinked"",
                  ""caption"":  ""Link Images"", ""tooltip"": ""Link Images"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""Linked"",
                  ""items"": []
                }
                ]
    }
    ]
}";
      #endregion #DentalToolbarRegion

      #region MedicalToolbarRegion
      public const string MedicalToolbar = @" 
  {
  ""name"": ""main"", 
    ""items"": [ " +
#if LEADTOOLS_V19_OR_LATER
@"   {
      ""id"": ""LayoutCompose"",
      ""action"": ""Compose"",
      ""caption"":  ""Compose Layout"", ""tooltip"": ""Compose Layout"",
      ""type"": ""button"",
      ""cssIconClass"": ""ComposeLayout"",
      ""items"": []
    },
    {
      ""id"": ""MergeCells"",
      ""action"": ""MergeCells"",
      ""caption"":  ""Merge"", ""tooltip"": ""Merge Cells"",
      ""type"": ""button"",
      ""visible"": ""false"", 
      ""disabled"": ""true"",
      ""cssIconClass"": ""MergeCells"",
      ""items"": []
    },
    {
      ""id"": ""HangingProtocol"",
      ""action"": ""HangingProtocol"",
      ""caption"":  ""HP"", ""tooltip"": ""Save Hanging Protocol"",
      ""type"": ""button"",
      ""visible"": ""false"",
      ""cssIconClass"": ""SaveHangingProtocol"",
      ""items"": []
    },
    {
      ""id"": ""SaveStructuredDisplay"",
      ""action"": ""SaveStructuredDisplay"",
      ""caption"":  ""Save SSD"", ""tooltip"": ""Save Study Structured Display"",
      ""type"": ""button"",
      ""visible"": ""false"",
      ""cssIconClass"": ""SaveStructuredDisplay"",
      ""items"": []
    },
    {
      ""id"": ""DeleteStudyStructuredDisplay"",
      ""action"": ""DeleteStudyStructuredDisplay"",
      ""caption"":  ""Delete SSD"", ""tooltip"": ""Delete Study Structured Display"",
      ""type"": ""button"",
      ""visible"": ""false"",
      ""cssIconClass"": ""DeleteStudyLayout"",
      ""items"": []
    }, " +
#endif
 @"
    {
      ""id"": ""WindowLevel"",
      ""action"": ""WindowLevelInteractiveMode"",
      ""caption"":  ""W/L"", ""tooltip"": ""Window Level"",
      ""type"": ""button"",
      ""cssIconClass"": ""WindowLevel"",
      ""items"": []
    },
    {
      ""id"": ""WindowLevelCustom"",
      ""action"": ""WindowLevelCustom"",
      ""caption"":  ""Custom WL"", ""tooltip"": ""Custom Window Level"",
      ""type"": ""button"",
      ""cssIconClass"": ""WindowLevelCustom"",
      ""items"": []
    },
    {
      ""id"": ""Pan"",
      ""action"": ""Pan"", 
      ""caption"":  ""Pan"", ""tooltip"": ""Pan"",
      ""type"": ""button"",
      ""cssIconClass"": ""Pan"",
      ""items"": []
    },
    {
      ""id"": ""Zoom"",
      ""action"": ""ZoomToInteractiveMode"",
      ""caption"":  ""Zoom"", ""tooltip"": ""Zoom"",
      ""type"": ""button"",
      ""cssIconClass"": ""Zoom"",
      ""items"": []
    },
    {
      ""id"": ""SpyglassGroup"",
      ""action"": ""OnSpyGlass"",
      ""caption"":  ""SpyGlass"", ""tooltip"": ""Spyglass"",
      ""type"": ""button"",
      ""cssIconClass"": ""Spyglass"",
      ""items"": [
        {
          ""id"": ""SpyGlass"",
          ""action"": ""OnSpyGlass"",
          ""caption"":  ""SpyGlass"", ""tooltip"": ""Spyglass"",
          ""type"": ""button"",
          ""cssIconClass"": ""Spyglass"",
          ""items"": []
        },        
        {
          ""id"": ""SpyGlassInvert"",
          ""action"": ""OnSpyGlassInvert"",
          ""caption"":  ""Invert"", ""tooltip"": ""Spyglass Invert"",
          ""type"": ""button"",
          ""cssIconClass"": ""SpyglassInvert"",
          ""items"": []
        },
        {
          ""id"": ""SpyGlassCLAHE"",
          ""action"": ""OnSpyGlassCLAHE"",
          ""caption"":  ""Clahe"", ""tooltip"": ""Spyglass CLAHE"",
          ""type"": ""button"",
          ""cssIconClass"": ""SpyglassCLAHE"",
          ""items"": []
        },
        {
          ""id"": ""SpyGlassEqualization"",
          ""action"": ""OnSpyGlassEqualization"",
          ""caption"":  ""Revealer"", ""tooltip"": ""Revealer"",
          ""type"": ""button"",
          ""cssIconClass"": ""SpyGlassEqualization"",
          ""items"": []
        }
      ]
    },
    {
      ""id"": ""Stack"",
      ""action"": ""InteractiveStack"",
      ""caption"":  ""Stack"", ""tooltip"": ""Stack"",
      ""type"": ""button"",
      ""cssIconClass"": ""Stack"",
      ""items"": []
    },
    {
       ""id"":""ProbeTool"",
       ""action"":""OnProbeTool"",
       ""caption"":  ""Probe"", ""tooltip"":""Probe Tool"",
       ""type"":""button"",
       ""cssIconClass"":""ProbeTool"",
       ""items"":[]
    },
    {
      ""id"": ""FitImage"",
      ""action"": ""FitImage"",
      ""caption"":  ""Fit"", ""tooltip"": ""Fit"",
      ""type"": ""button"",
      ""cssIconClass"": ""FitImage"",
      ""items"": [
        {
          ""id"": ""FitImage"",
          ""action"": ""FitImage"",
          ""caption"":  ""Fit"", ""tooltip"": ""Fit"",
          ""type"": ""button"",
          ""cssIconClass"": ""FitImage"",
          ""items"": []
        },
        {
          ""id"": ""OneToOne"",
          ""action"": ""OneToOne"",
          ""caption"":  ""1-1"", ""tooltip"": ""One To One"",
          ""type"": ""button"",
          ""cssIconClass"": ""OneToOne"",
          ""items"": []
        },
        {
          ""id"": ""TrueSizeDisplay"",
          ""action"": ""TrueSizeDisplay"",
          ""caption"":  ""True Size"", ""tooltip"": ""True Size Display"",
          ""type"": ""button"",
          ""cssIconClass"": ""TrueSizeDisplay"",
          ""items"": []
        },
        {
          ""id"": ""ZoomIn"",
          ""action"": ""ZoomIn"",
          ""caption"":  ""Zoom In"", ""tooltip"": ""Zoom In"",
          ""type"": ""button"",
          ""cssIconClass"": ""ZoomIn"",
          ""items"": []
        },
        {
          ""id"": ""ZoomOut"",
          ""action"": ""ZoomOut"",
          ""caption"":  ""Zoom Out"", ""tooltip"": ""Zoom Out"",
          ""type"": ""button"",
          ""cssIconClass"": ""ZoomOut"",
          ""items"": []
        }
    ]
    },
    {
      ""id"": ""Orientation"",
      ""action"": ""RotateClockwise"",
      ""caption"":  ""Rotate C"", ""tooltip"": ""Rotate Clockwise"",
      ""type"": ""button"",
      ""cssIconClass"": ""RotateClock"",
      ""items"": [
        {
          ""id"": ""RotateClockwise"",
          ""action"": ""RotateClockwise"",
          ""caption"":  ""Rotate C"", ""tooltip"": ""Rotate Clockwise"",
          ""type"": ""button"",
          ""cssIconClass"": ""RotateClock"",
          ""items"": []
        },
        {
          ""id"": ""RotateCounterClock"",
          ""action"": ""RotateCounterclockwise"",
          ""caption"":  ""Rotate CC"", ""tooltip"": ""Rotate Counterclockwise"",
          ""type"": ""button"",
          ""cssIconClass"": ""RotateCounterClock"",
          ""items"": []
        },
        {
          ""id"": ""Flip"",
          ""action"": ""Flip"",
          ""caption"":  ""Flip"", ""tooltip"": ""Flip"",
          ""type"": ""button"",
          ""cssIconClass"": ""Flip"",
          ""items"": []
        },
        {
          ""id"": ""Reverse"",
          ""action"": ""Reverse"",
          ""caption"":  ""Reverse"", ""tooltip"": ""Reverse"",
          ""type"": ""button"",
          ""cssIconClass"": ""Reverse"",
          ""items"": []
        }
      ]
    }, " + 

#if LEADTOOLS_V19_OR_LATER
@" {
      ""id"": ""HorizontalAlignment"",
      ""action"": ""ImageAlignLeft"",
      ""caption"":  ""Left"", ""tooltip"": ""Align Left"",
      ""type"": ""button"",
      ""cssIconClass"": ""AlignLeft"",
      ""items"": [
		{
          ""id"": ""ImageAlignLeft"",
          ""action"": ""ImageAlignLeft"",
          ""caption"":  ""Left"", ""tooltip"": ""Align Left"",
          ""type"": ""button"",
          ""cssIconClass"": ""AlignLeft"",
          ""items"": []
        },
        {
          ""id"": ""ImageAlignRight"",
          ""action"": ""ImageAlignRight"",
          ""caption"":  ""Right"", ""tooltip"": ""Align Right"",
          ""type"": ""button"",
          ""cssIconClass"": ""AlignRight"",
          ""items"": []
        },
        {
          ""id"": ""ImageAlignCenter"",
          ""action"": ""ImageAlignCenter"",
          ""caption"":  ""Center"", ""tooltip"": ""Align Center"",
          ""type"": ""button"",
          ""cssIconClass"": ""AlignCenter"",
          ""items"": []
        }
      ]
    },
    {
      ""id"": ""VerticalAlignment"",
      ""action"": ""ImageAlignTop"",
      ""caption"":  ""Top"", ""tooltip"": ""Align Top"",
      ""type"": ""button"",
      ""cssIconClass"": ""AlignTop"",
      ""items"": [
	  {
          ""id"": ""ImageAlignTop"",
          ""action"": ""ImageAlignTop"",
          ""caption"":  ""Top"", ""tooltip"": ""Align Top"",
          ""type"": ""button"",
          ""cssIconClass"": ""AlignTop"",
          ""items"": []
        },
        {
          ""id"": ""ImageAlignBottom"",
          ""action"": ""ImageAlignBottom"",
          ""caption"":  ""Bottom"", ""tooltip"": ""Align Bottom"",
          ""type"": ""button"",
          ""cssIconClass"": ""AlignBottom"",
          ""items"": []
        },
        {
          ""id"": ""ImageAlignMiddle"",
          ""action"": ""ImageAlignMiddle"",
          ""caption"":  ""Middle"", ""tooltip"": ""Align Middle"",
          ""type"": ""button"",
          ""cssIconClass"": ""AlignMiddle"",
          ""items"": []
        }
      ]
    }," +
#endif // #if LEADTOOLS_V19_OR_LATER
 @"{
       ""id"":""SortSeries"",
       ""action"":""OnSort"",
       ""caption"":  ""Sort"", ""tooltip"":""Sort Series"",
       ""type"":""button"",
       ""cssIconClass"":""SortSeries"",
       ""items"":[  
       ]
    },
     {
      ""id"": ""Effects"",
      ""action"": ""Invert"",
      ""caption"":  ""Invert"", ""tooltip"": ""Invert"",
      ""type"": ""button"",
      ""cssIconClass"": ""InvertColor"",
      ""items"": [
        {
          ""id"": ""InvertColor"",
          ""action"": ""Invert"",
          ""caption"":  ""Invert"", ""tooltip"": ""Invert"",
          ""type"": ""button"",
          ""cssIconClass"": ""InvertColor"",
          ""items"": []
        },
        {
          ""id"": ""BrightnessContrast"",
          ""action"": ""BrightnessContrast"",
          ""caption"":  ""Lightness"", ""tooltip"": ""Brightness Contrast"",
          ""type"": ""button"",
          ""cssIconClass"": ""BrightnessContrast"",
          ""items"": []
        },
        {
          ""id"": ""HSL"",
          ""action"": ""HSL"",
          ""caption"":  ""HSL"", ""tooltip"": ""HSL"",
          ""type"": ""button"",
          ""cssIconClass"": ""HSL"",
          ""items"": []
        },
        {
          ""id"": ""StretchHistogram"",
          ""action"": ""StretchHistogram"",
          ""caption"":  ""Equalize"", ""tooltip"": ""Stretch Histogram"",
          ""type"": ""button"",
          ""cssIconClass"": ""StretchHistogram"",
          ""items"": []
        }
      ]
    },
    {
      ""id"": ""EdgeEnhancment"",
      ""action"": ""OnEdgeEnhancment"",
      ""caption"":  ""Enhance Edges"", ""tooltip"": ""Edge Enhancment"",
      ""type"": ""button"",
      ""cssIconClass"": ""EdgeEnhancment"",
      ""items"": []
    },
   {
         ""id"": ""Endo"",
         ""action"": ""OnToggleEndo"",
         ""caption"":  ""Endo"", ""tooltip"": ""Toggle Endo"",
         ""type"": ""button"",
         ""cssIconClass"": ""Endo"",
         ""items"": []
       },
       {
         ""id"": ""Perio"",
         ""action"": ""OnTogglePerio"",
         ""caption"":  ""Perio"", ""tooltip"": ""Toggle Perio"",
         ""type"": ""button"",
         ""cssIconClass"": ""Perio"",
         ""items"": []
       },
       {
         ""id"": ""Dentin"",
         ""action"": ""OnToggleDentin"",
         ""caption"":  ""Dentin"", ""tooltip"": ""Toggle Dentin"",
         ""type"": ""button"",
         ""cssIconClass"": ""Dentin"",
         ""items"": []
       },
    {
      ""id"": ""Annotations"",
      ""action"": ""OnAnnotationSelect"",
      ""caption"":  ""Select"", ""tooltip"": ""Select"",
      ""type"": ""button"",
      ""cssIconClass"": ""Select"",
      ""items"": [
        {
          ""id"": ""Select"",
          ""action"": ""OnAnnotationSelect"",
          ""caption"":  ""Select"", ""tooltip"": ""Select"",
          ""type"": ""button"",
          ""cssIconClass"": ""Select"",
          ""items"": []
        },
        {
          ""id"": ""Arrow"",
          ""action"": ""OnAnnotationArrow"",
          ""caption"":  ""Arrow"", ""tooltip"": ""Arrow"",
          ""type"": ""button"",
          ""cssIconClass"": ""Arrow"",
          ""items"": []
        },
        {
          ""id"": ""Point"",
          ""action"": ""OnAnnotationPoint"",
          ""caption"":  ""Point"", ""tooltip"": ""Point"",
          ""type"": ""button"",
          ""cssIconClass"": ""Point"",
          ""items"": []
        },
        {
          ""id"": ""Rectangle"",
          ""action"": ""OnAnnotationRectangle"",
          ""caption"":  ""Rectangle"", ""tooltip"": ""Rectangle"",
          ""type"": ""button"",
          ""cssIconClass"": ""Rectangle"",
          ""items"": []
        },
        {
          ""id"": ""Ellipse"",
          ""action"": ""OnAnnotationEllipse"",
          ""caption"":  ""Ellipse"", ""tooltip"": ""Ellipse"",
          ""type"": ""button"",
          ""cssIconClass"": ""Ellipse"",
          ""items"": []
        },
        {
          ""id"": ""Curve"",
          ""action"": ""OnAnnotationCurve"",
          ""caption"":  ""Curve"", ""tooltip"": ""Curve"",
          ""type"": ""button"",
          ""cssIconClass"": ""Curve"",
          ""items"": []
        },
        {
          ""id"": ""Line"",
          ""action"": ""OnAnnotationLine"",
          ""caption"":  ""Line"", ""tooltip"": ""Line"",
          ""type"": ""button"",
          ""cssIconClass"": ""Line"",
          ""items"": []
        },
        {
          ""id"": ""Freehand"",
          ""action"": ""OnAnnotationFreehand"",
          ""caption"":  ""Free Hand"", ""tooltip"": ""Freehand"",
          ""type"": ""button"",
          ""cssIconClass"": ""Freehand"",
          ""items"": []
        },
        {
          ""id"": ""Polyline"",
          ""action"": ""OnAnnotationPolyline"",
          ""caption"":  ""Poly line"", ""tooltip"": ""Polyline"",
          ""type"": ""button"",
          ""cssIconClass"": ""Polyline"",
          ""items"": []
        },
        {
          ""id"": ""Polygon"",
          ""action"": ""OnAnnotationPolygon"",
          ""caption"":  ""Polygon"", ""tooltip"": ""Polygon"",
          ""type"": ""button"",
          ""cssIconClass"": ""Polygon"",
          ""items"": []
        },
        {
          ""id"": ""Text"",
          ""action"": ""OnAnnotationText"",
          ""caption"":  ""Text"", ""tooltip"": ""Text"",
          ""type"": ""button"",
          ""cssIconClass"": ""Text"",
          ""items"": []
        },
        {
          ""id"": ""Note"",
          ""action"": ""OnAnnotationNote"",
          ""caption"":  ""Note"", ""tooltip"": ""Note"",
          ""type"": ""button"",
          ""cssIconClass"": ""Note"",
          ""items"": []
        },
        {
          ""id"": ""Highlight"",
          ""action"": ""OnAnnotationHighlight"",
          ""caption"":  ""Higlight"", ""tooltip"": ""Highlight"",
          ""type"": ""button"",
          ""cssIconClass"": ""Highlight"",
          ""items"": []
        },
        {
          ""id"": ""TextPointer"",
          ""action"": ""OnAnnotationTextPointer"",
          ""caption"":  ""Text pointer"", ""tooltip"": ""TextPointer"",
          ""type"": ""button"",
          ""cssIconClass"": ""TextPointer"",
          ""items"": []
        }
      ]
    },
    {
      ""id"": ""Measurements"",
      ""action"": ""OnAnnotationRuler"",
      ""caption"":  ""Measurement"", ""tooltip"": ""Ruler"",
      ""type"": ""button"",
      ""cssIconClass"": ""Ruler"",
      ""items"": [
        {
          ""id"": ""Ruler"",
          ""action"": ""OnAnnotationRuler"",
          ""caption"":  ""Ruler"", ""tooltip"": ""Ruler"",
          ""type"": ""button"",
          ""cssIconClass"": ""Ruler"",
          ""items"": []
        },
        {
          ""id"": ""PolyRuler"",
          ""action"": ""OnAnnotationPolyRuler"",
          ""caption"":  ""Poly ruler"", ""tooltip"": ""Poly Ruler"",
          ""type"": ""button"",
          ""cssIconClass"": ""PolyRuler"",
          ""items"": []
        },
        {
          ""id"": ""Protractor"",
          ""action"": ""OnAnnotationProtractor"",
          ""caption"":  ""Protractor"", ""tooltip"": ""Protractor"",
          ""type"": ""button"",
          ""cssIconClass"": ""Protractor"",
          ""items"": []
        },
        {
          ""id"": ""AnnMeasurementSeperator"",
          ""action"": """",
          ""caption"":  ""Sep"", ""tooltip"": """",
          ""type"": ""seperator"",
          ""cssIconClass"": """",
          ""items"": []
        },
        {
          ""id"": ""CalibrateRuler"",
          ""action"": ""OnCalibrateRuler"",
          ""caption"":  ""Calibrate"", ""tooltip"": ""Calibrate Ruler"",
          ""type"": ""button"",
          ""cssIconClass"": ""CalibrateRulerAnn"",
          ""items"": []
        }
      ]
    },
    {
      ""id"": ""AnnotationOptions"",
      ""action"": ""OnAnnotationShowHide"",
      ""caption"":  ""Show/Hide"", ""tooltip"": ""Show/Hide Annotations"",
      ""type"": ""button"",
      ""cssIconClass"": ""ShowHide"",
      ""items"": [
        {
          ""id"": ""AnnotationShowHide"",
          ""action"": ""OnAnnotationShowHide"",
          ""caption"":  ""Show/Hide"", ""tooltip"": ""Show/Hide Annotations"",
          ""type"": ""button"",
          ""cssIconClass"": ""ShowHide"",
          ""items"": []
        },
        {
          ""id"": ""DeleteAnnotations"",
          ""action"": ""OnDeleteAnnotation"",
          ""caption"":  ""Delete"", ""tooltip"": ""Delete Annotations"",
          ""type"": ""button"",
          ""cssIconClass"": ""DeleteAnn"",
          ""items"": []
        },
        {
          ""id"": ""ClearAnnotations"",
          ""action"": ""OnClearAnnotation"",
          ""caption"":  ""Clear"", ""tooltip"": ""Clear Annotations"",
          ""type"": ""button"",
          ""cssIconClass"": ""Clear"",
          ""items"": []
        },
        {
          ""id"": ""ClearAllAnnotations"",
          ""action"": ""OnClearAllAnnotation"",
          ""caption"":  ""Clear all"", ""tooltip"": ""Clear All Annotations"",
          ""type"": ""button"",
          ""cssIconClass"": ""ClearAll"",
          ""items"": []
        },
        {
          ""id"": ""SaveAnnSeperator"",
          ""action"": """",
          ""caption"":  ""Sep"", ""tooltip"": """",
          ""type"": ""seperator"",
          ""cssIconClass"": """",
          ""items"": []
        },
        {
          ""id"": ""SaveAnn"",
          ""action"": ""OnSaveAnnotations"",
          ""caption"":  ""Save"", ""tooltip"": ""Save Annotations"",
          ""type"": ""button"",
          ""cssIconClass"": ""SaveAnn"",
          ""items"": []
        },
        {
          ""id"": ""LoadAnn"",
          ""action"": ""OnLoadAnnotations"",
          ""caption"":  ""Load"", ""tooltip"": ""Load Annotations"",
          ""type"": ""button"",
          ""cssIconClass"": ""LoadAnn"",
          ""items"": []
        }
      ]
    },
    {
      ""id"": ""Reload"",
      ""action"": ""OnReload"",
      ""caption"":  ""Reload"", ""tooltip"": ""Reload"",
      ""type"": ""button"",
      ""cssIconClass"": ""Reload"",
      ""items"": []
    },
    {
      ""id"": ""ToggleTags"",
      ""action"": ""OnToggleTags"",
      ""caption"":  ""Overlays"", ""tooltip"": ""Overlays"",
      ""type"": ""button"",
      ""cssIconClass"": ""ToggleTags"",
      ""items"": []
    },
    {
      ""id"": ""ShowDicom"",
      ""action"": ""ShowDicom"",
      ""caption"":  ""Dicom Info"", ""tooltip"": ""Show Dicom"",
      ""type"": ""button"",
      ""cssIconClass"": ""ShowDicom"",
      ""items"": []
    },
    {
      ""id"": ""FullScreen"",
      ""action"": ""ToggleFullScreen"",
      ""caption"":  ""Full Screen"", ""tooltip"": ""Toggle Full Screen"",
      ""type"": ""button"",
      ""cssIconClass"": ""FullScreen"",
      ""items"": []
    },
    {
      ""id"": ""Rotate3D"",
      ""action"": ""OnRotate3D"",
      ""caption"":  ""Rotate 3D"", ""tooltip"": ""Rotate 3D Object"",
      ""type"": ""button"",
      ""cssIconClass"": ""Rotate3D"",
      ""items"": []
     },
     {
     ""id"": ""VolumeType"",
     ""action"": ""OnVRT"",
     ""caption"":  ""VRT"", ""tooltip"": ""3D Volume Type"",
     ""type"": ""button"",
     ""cssIconClass"": ""VRT"",
     ""items"": [
   {
     ""id"": ""VRT"",
     ""action"": ""OnVRT"",
     ""caption"":  ""VRT"", ""tooltip"": ""VRT"",
     ""type"": ""button"",
     ""cssIconClass"": ""VRT"",
     ""items"": []
   },
   {
     ""id"": ""MIP"",
     ""action"": ""OnMIP"",
     ""caption"":  ""MIP"", ""tooltip"": ""MIP"",
     ""type"": ""button"",
     ""cssIconClass"": ""MIP"",
     ""items"": []
   },
   {
     ""id"": ""MPR"",
     ""action"": ""OnMPRVolume"",
     ""caption"":  ""MPR"", ""tooltip"": ""MPR"",
     ""type"": ""button"",
     ""cssIconClass"": ""MPRVolume"",
     ""items"": []}]
   },
   {
     ""id"": ""DentalPanoramic"",
     ""action"": ""DentalPanoramic"",
     ""caption"":  ""Panoramic"", ""tooltip"": ""DentalPanoramic"",
     ""type"": ""button"",
     ""cssIconClass"": ""DentalPanoramic"",
     ""items"": []
   },
   {
     ""id"": ""Settings3D"",
     ""action"": ""OnSettings3D"",
     ""caption"":  ""Settings"", ""tooltip"": ""3D Settings"",
     ""type"": ""button"",
     ""cssIconClass"": ""Settings3D"",
     ""items"": [
    {
        ""id"": ""Settings3D"",
        ""action"": ""OnSettings3D"",
        ""caption"":  ""Settings"", ""tooltip"": ""3D Settings"",
        ""type"": ""button"",
        ""cssIconClass"": ""Settings3D"",
        ""items"": []
    },
    {
       ""id"":""CrossHair"",
       ""action"":""OnCrossHair"",
       ""caption"":  ""Cross Hair"", ""tooltip"":""Cross hair"",
       ""type"":""button"",
       ""cssIconClass"":""CrossHair"",
       ""items"":[]
    },
    {
     ""id"": ""HeadOrientation"",
     ""action"": ""OnHeadOrientation"",
     ""caption"":  ""Head"", ""tooltip"": ""Head"",
     ""type"": ""button"",
     ""cssIconClass"": ""HeadOrientation"",
     ""items"": []
   },
   {
     ""id"": ""FeetOrientation"",
     ""action"": ""OnFeetOrientation"",
     ""caption"":  ""Feet"", ""tooltip"": ""Feet"",
     ""type"": ""button"",
     ""cssIconClass"": ""FeetOrientation"",
     ""items"": []
   },
   {
     ""id"": ""LeftOrientation"",
     ""action"": ""OnLeftOrientation"",
     ""caption"":  ""Left"", ""tooltip"": ""Left Orientation"",
     ""type"": ""button"",
     ""cssIconClass"": ""LeftOrientation"",
     ""items"": []
   },
   {
     ""id"": ""RightOrientation"",
     ""action"": ""OnRightOrientation"",
     ""caption"":  ""Right"", ""tooltip"": ""Right Orientation"",
     ""type"": ""button"",
     ""cssIconClass"": ""RightOrientation"",
     ""items"": []
   },
   {
     ""id"": ""AnteriorOrientation"",
     ""action"": ""OnAnteriorOrientation"",
     ""caption"":  ""Anterior"", ""tooltip"": ""Anterior"",
     ""type"": ""button"",
     ""cssIconClass"": ""AnteriorOrientation"",
     ""items"": []
   },
   {
     ""id"": ""PosteriorOrientation"",
     ""action"": ""OnPosteriorOrientation"",
     ""caption"":  ""Posterior"", ""tooltip"": ""Posterior"",
     ""type"": ""button"",
     ""cssIconClass"": ""PosteriorOrientation"",
     ""items"": []} ]
   },

    {
      ""id"": ""DeleteCell"",
      ""action"": ""DeleteCell"",
      ""caption"":  ""Delete"", ""tooltip"": ""Delete Cell"",
      ""type"": ""button"",
      ""cssIconClass"": ""DeleteCell"",
      ""items"": []
    },
    {
      ""id"": ""StudyLayout"",
      ""action"": ""OnStudyLayout"",
      ""caption"":  ""Study Layout"", ""tooltip"": ""Change Study Layout"",
      ""type"": ""button"",
      ""cssIconClass"": ""StudyLayout"",
      ""items"": [
                    {
                      ""id"": ""StudyLayout"",
                      ""action"": ""OnStudyLayout"",
                      ""caption"":  ""Study Layout"", ""tooltip"": ""Change Study Layout"",
                      ""type"": ""button"",
                      ""cssIconClass"": ""StudyLayout"",
                      ""items"": []
                    },
                    {
                      ""id"": ""SeriesLayouts"",
                      ""action"": ""OnSeriesLayout"",
                      ""caption"":  ""Series Layout"", ""tooltip"": ""Change Series Layout"",
                      ""type"": ""button"",
                      ""cssIconClass"": ""SeriesLayout"",
                      ""items"": []
                    }
                 ]
    },
    {
      ""id"": ""ToggleCine"",
      ""action"": ""OnToggleCine"",
      ""caption"":  ""Cine"", ""tooltip"": ""Toggle Cine"",
      ""type"": ""button"",
      ""cssIconClass"": ""ToggleCine"",
      ""items"": [
	  {
        ""id"": ""ToggleCine"",
        ""action"": ""OnToggleCine"",
        ""caption"":  ""Play/Stop"", ""tooltip"": ""Toggle Cine"",
        ""type"": ""button"",
        ""cssIconClass"": ""ToggleCine"",
        ""items"": []
	    },
	  	{
        ""id"": ""CinePlayer"",
        ""action"": ""CinePlayer"",
        ""caption"":  ""Cine"", ""tooltip"": ""Cine Player"",
        ""type"": ""button"",
        ""cssIconClass"": ""CinePlayer"",
        ""items"": []
	    }
	  ]
    },
    {
      ""id"": ""PopupCapture"",
      ""action"": ""OnSecondaryCapturePopup"",
      ""caption"":  ""Print To PDF"", ""tooltip"": ""Print To PDF"",
      ""type"": ""button"",
      ""cssIconClass"": ""PopupCapture"",
      ""items"": [
                {
                    ""id"": ""SecondaryCapture"",
                    ""action"": ""OnSecondaryCapture"",
                    ""caption"":  ""Save Derived"", ""tooltip"": ""Save As Derived"",
                    ""type"": ""button"",
                    ""cssIconClass"": ""SecondaryCapture"",
                    ""items"": []
                },
                {
                  ""id"": ""Export"",
                  ""action"": ""OnExport"",
                  ""caption"":  ""Export"", ""tooltip"": ""Export"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""Export"",
                  ""items"": []
                },
                {
                  ""id"": ""PopupCapture"",
                  ""action"": ""OnSecondaryCapturePopup"",
                  ""caption"":  ""Print To PDF"", ""tooltip"": ""Print To PDF"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""PopupCapture"",
                  ""items"": []
                }
                ]
    },
    {
      ""id"": ""StudyTimeLine"",
      ""action"": ""StudyTimeLine"",
      ""caption"":  ""Time Line"", ""tooltip"": ""Toggle Study Time Line"",
      ""type"": ""button"",
      ""cssIconClass"": ""StudyTimeLine"",
      ""items"": []
    },
    {
      ""id"": ""WaveformBasicAudio"",
      ""action"": ""OnWaveformBasicAudio"",
      ""caption"":  ""Audio"", ""tooltip"": ""Waveform Basic Audio"",
      ""type"": ""button"",
      ""cssIconClass"": ""WaveformBasicAudio"",
      ""items"": []
    },
    {
      ""id"":""ShutterObject"",
      ""action"":""OnShutterObject"",
      ""caption"":  ""Shutter"", ""tooltip"":""Shutter Object"",
      ""type"":""button"",
      ""cssIconClass"":""ShutterObject"",
      ""items"":[]
   },
    {
      ""id"": ""Cursor3D"",
      ""action"": ""OnCursor3D"",
      ""caption"":  ""3D Cursor"", ""tooltip"": ""3D Cursor"",
      ""type"": ""button"",
      ""cssIconClass"": ""Cursor3D"",
      ""items"": [
                {
                  ""id"": ""Cursor3D"",
                  ""action"": ""OnCursor3D"",
                  ""caption"":  ""3D Cursor"", ""tooltip"": ""3D Cursor"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""Cursor3D"",
                  ""items"": []
                },
                {
                  ""id"": ""ReferenceLine"",
                  ""action"": ""ToggleReferenceLine"",
                  ""caption"":  ""Reference Line"", ""tooltip"": ""Show Reference Line"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""ReferenceLine"",
                  ""items"": []
                },
               {
                  ""id"": ""ShowFirstLast"",
                  ""action"": ""ShowFirstLastReferenceLine"",
                  ""caption"":  ""First/Last"", ""tooltip"": ""Show First And Last Reference Line"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""ShowFirstLast"",
                  ""items"": []
                },
                {  
                   ""id"":""LineProfile"",
                   ""action"":""OnLineProfile"",
                   ""caption"":  ""Line Profile"", ""tooltip"":""Line Profile"",
                   ""type"":""button"",
                   ""cssIconClass"":""LineProfile"",
                   ""items"":[]
                },
                {
                  ""id"": ""SynchronizeSeries"",
                  ""action"": ""SetEnableSeriesSynchronization"",
                  ""caption"":  ""Synch"", ""tooltip"": ""Synchronize Series"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""Synchronization"",
                  ""items"": []
                },
                {
                  ""id"": ""LinkCells"",
                  ""action"": ""LinkCells"",
                  ""caption"":  ""Link Cells"", ""tooltip"": ""Link Cells"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""LinkStudies"",
                  ""items"": []
                },
                {
                  ""id"": ""LinkImages"",
                  ""action"": ""SetLinked"",
                  ""caption"":  ""Link Images"", ""tooltip"": ""Link Images"",
                  ""type"": ""button"",
                  ""cssIconClass"": ""Linked"",
                  ""items"": []
                }
            ]
            }
]
}
     ";
      #endregion MedicalToolbarRegion

      public static Dictionary<string, string> DentalOptions
      {
          get
          {
              if (_dentalOptions == null)
              {
                  _dentalOptions = new Dictionary<string, string>();

                  _dentalOptions.Add("DefaultSeriesColumnCount", "1");
                  _dentalOptions.Add("DefaultSeriesRowCount", "1");
                  _dentalOptions.Add("DentalMode", "true");
                  _dentalOptions.Add("ShowPacsQuery", "false");
                  _dentalOptions.Add("SinglePatientMode", "true");
                  _dentalOptions.Add("SingleSeriesMode", "true");
                  _dentalOptions.Add("DisabledToolbarItems_main", "[\"Flip\",\"Reverse\",\"ReferenceLine\",\"ShowFirstLast\",\"StudyLayout\",\"SynchronizeSeries\",\"CinePlayer\",\"WaveformBasicAudio\", \"FullScreen\", \"Create3D\", \"StudyTimeLine\", \"ZoomIn\",\"ZoomOut\",\"DeleteCell\",\"WindowLevelCustom\", \"Cursor3D\", \"TrueSizeDisplay\"]");
                  _dentalOptions.Add("HideOverlays", "true");
                  _dentalOptions.Add("LinkImages", "false");
                  _dentalOptions.Add("Toolbar_main", DentalToolbar);
              }
              return _dentalOptions;
          }
      }

      public static Dictionary<string, string> MedicalOptions
      {
          get
          {
              if (_medicalOptions == null)
              {
                  // Medical Options
                  _medicalOptions = new Dictionary<string, string>();

                  _medicalOptions.Add("DefaultSeriesColumnCount", "2");
                  _medicalOptions.Add("DefaultSeriesRowCount", "2");
                  _medicalOptions.Add("DentalMode", "false");
                  _medicalOptions.Add("ShowPacsQuery", "true");
                  _medicalOptions.Add("SinglePatientMode", "false");
                  _medicalOptions.Add("SingleSeriesMode", "false");
                  _medicalOptions.Add("DisabledToolbarItems_main", "[\"Endo\",\"Perio\",\"Dentin\", \"FullScreen\", \"Create3D\", \"TrueSizeDisplay\"]");
                  _medicalOptions.Add("HideOverlays", "false");
                  _medicalOptions.Add("LinkImages", "true");
                  _medicalOptions.Add("Toolbar_main", MedicalToolbar);
            }
            return _medicalOptions;
         }
      } 

#endif //#if LEADTOOLS_V19_OR_LATER
   }
}
