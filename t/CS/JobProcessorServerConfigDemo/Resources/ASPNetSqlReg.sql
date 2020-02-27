USE [master]
GO
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'@DatabaseName@')
BEGIN
CREATE DATABASE [@DatabaseName@]
END

GO
EXEC dbo.sp_dbcmptlevel @dbname=N'@DatabaseName@', @new_cmptlevel=100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [@DatabaseName@].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [@DatabaseName@] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [@DatabaseName@] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [@DatabaseName@] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [@DatabaseName@] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [@DatabaseName@] SET ARITHABORT OFF 
GO
ALTER DATABASE [@DatabaseName@] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [@DatabaseName@] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [@DatabaseName@] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [@DatabaseName@] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [@DatabaseName@] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [@DatabaseName@] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [@DatabaseName@] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [@DatabaseName@] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [@DatabaseName@] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [@DatabaseName@] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [@DatabaseName@] SET  DISABLE_BROKER 
GO
ALTER DATABASE [@DatabaseName@] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [@DatabaseName@] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [@DatabaseName@] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [@DatabaseName@] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [@DatabaseName@] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [@DatabaseName@] SET  READ_WRITE 
GO
ALTER DATABASE [@DatabaseName@] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [@DatabaseName@] SET  MULTI_USER 
GO
ALTER DATABASE [@DatabaseName@] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [@DatabaseName@] SET DB_CHAINING OFF 
USE [@DatabaseName@]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobsTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[JobsTable](
	[cGuid] [uniqueidentifier] NOT NULL,
	[cStatus] [nvarchar](50) NULL,
	[cWorker] [nvarchar](50) NULL,
	[cAttempts] [int] NULL,
	[cPercentage] [int] NULL,
	[cAddedTime] [datetime] NULL,
	[cLastStartedTime] [datetime] NULL,
	[cLastUpdatedTime] [datetime] NULL,
	[cCompletedTime] [datetime] NULL,
	[cFailedTime] [datetime] NULL,
	[cFailedErrorID] [int] NULL,
	[cFailedMessage] [nvarchar](max) NULL,
	[cMustAbort] [bit] NULL,
	[cAbortReason] [nvarchar](max) NULL,
	[cUserToken] [nvarchar](max) NULL,
	[cJobMetadata] [nvarchar](max) NULL,
	[cWorkerMetadata] [nvarchar](max) NULL,
	[cJobType] [nvarchar](100) NULL,
 CONSTRAINT [PK_JobsTable] PRIMARY KEY CLUSTERED 
(
	[cGuid] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[JobsTable]') AND name = N'IX_JobsTable')
CREATE NONCLUSTERED INDEX [IX_JobsTable] ON [dbo].[JobsTable] 
(
	[cStatus] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[JobsTable]') AND name = N'IX_JobsTable_1')
CREATE NONCLUSTERED INDEX [IX_JobsTable_1] ON [dbo].[JobsTable] 
(
	[cAddedTime] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[JobsTable]') AND name = N'IX_JobsTable_2')
CREATE NONCLUSTERED INDEX [IX_JobsTable_2] ON [dbo].[JobsTable] 
(
	[cJobType] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateFailedStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateFailedStatus]
   (
   @guid uniqueidentifier,
   @time dateTime,
   @status nvarchar(50) OUTPUT,
   @failedInfo nvarchar(MAX),
   @failedErrorId int,
   @jobMetadata nvarchar(MAX)= NULL
   )
AS

BEGIN TRY
   BEGIN TRANSACTION

	  UPDATE JobsTable
	  SET cFailedTime=@time, cStatus=@status,cFailedErrorID=@failedErrorId, cFailedMessage=@failedInfo, cAttempts = cAttempts+1, cMustAbort = 0, cLastUpdatedTime= GetUTCDate(), cJobMetadata=ISNULL(@jobMetadata, cJobMetadata), cPercentage=0
	  WHERE cGuid = @guid 

	SELECT @status = cStatus FROM JobsTable WHERE @guid = cGuid

   COMMIT TRAN
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
      ROLLBACK TRAN --RollBack in case of Error

   DECLARE @ErrorMessage NVARCHAR(4000);
   DECLARE @ErrorSeverity INT;
   DECLARE @ErrorState INT;

   SELECT @ErrorMessage = ERROR_MESSAGE(),
		  @ErrorSeverity = ERROR_SEVERITY(),
		  @ErrorState = ERROR_STATE();

   RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH

RETURN



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetNewJob]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetNewJob]
   (
   @machineName nvarchar(50),
   @jobType nvarchar(max),
   @attempts int,
   @status nvarchar(50) OUTPUT
   )
AS

BEGIN TRY
   BEGIN TRANSACTION

      DECLARE @guid uniqueidentifier

      SELECT TOP 1 @guid = cGuid  , @status=cStatus FROM JobsTable WITH (HOLDLOCK XLOCK ROWLOCK) WHERE cStatus IN (''New'', ''Failed'') AND cAttempts < @attempts AND cMustAbort=0 AND cJobType = @jobType ORDER BY cAddedTime ASC
      UPDATE JobsTable Set cStatus = ''Queried'', cAttempts = cAttempts+1, cWorker=@machineName Where cGuid = @guid

      SELECT * FROM JobsTable WHERE cGuid = @guid

   COMMIT TRAN
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
      ROLLBACK TRAN --RollBack in case of Error

   DECLARE @ErrorMessage NVARCHAR(4000);
   DECLARE @ErrorSeverity INT;
   DECLARE @ErrorState INT;

   SELECT @ErrorMessage = ERROR_MESSAGE(),
		  @ErrorSeverity = ERROR_SEVERITY(),
		  @ErrorState = ERROR_STATE();

   RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH

RETURN






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdatePercentage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdatePercentage]
   (
   @guid uniqueidentifier,
   @percentage int,
   @workerMetadata nvarchar(MAX)
   )
AS

BEGIN TRY
   BEGIN TRANSACTION

      UPDATE JobsTable
      SET cPercentage=@percentage, cWorkerMetadata=@workerMetadata, cLastUpdatedTime= GetUTCDate()
      WHERE @guid = cGuid 

      SELECT @percentage = cPercentage FROM JobsTable WHERE @guid = cGuid

   COMMIT TRAN
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
      ROLLBACK TRAN --RollBack in case of Error

   DECLARE @ErrorMessage NVARCHAR(4000);
   DECLARE @ErrorSeverity INT;
   DECLARE @ErrorState INT;

   SELECT @ErrorMessage = ERROR_MESSAGE(),
		  @ErrorSeverity = ERROR_SEVERITY(),
		  @ErrorState = ERROR_STATE();

   RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH

RETURN








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResetJob]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ResetJob]
   (
   @guid uniqueidentifier,
   @jobType nvarchar(MAX)=NULL,
   @jobMetaData nvarchar(MAX)=NULL
   )
AS

BEGIN TRY
   BEGIN TRANSACTION
	  /* SET NOCOUNT ON */
      UPDATE JobsTable
		 SET  cStatus=''New'', cJobMetadata=ISNULL(@jobMetadata, cJobMetadata), cMustAbort=''0'', cjobType=ISNULL(@jobType, cjobType),
		 cWorker=NULL, cAttempts=0, cPercentage=0, cLastStartedTime=NULL, cCompletedTime=NULL, 
		 cFailedTime=NULL, cLastUpdatedTime=NULL, cFailedErrorID=0, cFailedMessage=NULL, cAbortReason=NULL, cWorkerMetadata=NULL

        WHERE cGuid=@guid

   COMMIT TRAN
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
      ROLLBACK TRAN --RollBack in case of Error

   DECLARE @ErrorMessage NVARCHAR(4000);
   DECLARE @ErrorSeverity INT;
   DECLARE @ErrorState INT;

   SELECT @ErrorMessage = ERROR_MESSAGE(),
		  @ErrorSeverity = ERROR_SEVERITY(),
		  @ErrorState = ERROR_STATE();

   RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH

RETURN








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteJob]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DeleteJob]
   (
   @guid uniqueidentifier
   )
AS

BEGIN TRY
   BEGIN TRANSACTION

      DELETE FROM JobsTable WHERE cGuid = @guid

   COMMIT TRAN
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
      ROLLBACK TRAN --RollBack in case of Error

   DECLARE @ErrorMessage NVARCHAR(4000);
   DECLARE @ErrorSeverity INT;
   DECLARE @ErrorState INT;

   SELECT @ErrorMessage = ERROR_MESSAGE(),
		  @ErrorSeverity = ERROR_SEVERITY(),
		  @ErrorState = ERROR_STATE();

   RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH

RETURN




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetClientJobs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetClientJobs]
   (
   @userToken nvarchar(MAX)
   )
AS

BEGIN TRY
   BEGIN TRANSACTION

      /* SET NOCOUNT ON */
      SELECT cGuid FROM JobsTable WHERE cUserToken = @userToken

   COMMIT TRAN
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
      ROLLBACK TRAN --RollBack in case of Error

   DECLARE @ErrorMessage NVARCHAR(4000);
   DECLARE @ErrorSeverity INT;
   DECLARE @ErrorState INT;

   SELECT @ErrorMessage = ERROR_MESSAGE(),
		  @ErrorSeverity = ERROR_SEVERITY(),
		  @ErrorState = ERROR_STATE();

   RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH

RETURN





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateCompletedStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateCompletedStatus]
   (
   @guid uniqueidentifier,
   @time dateTime,
   @status nvarchar(50) OUTPUT,
   @jobMetadata nvarchar(MAX)=NULL
   )
AS

BEGIN TRY
   BEGIN TRANSACTION
		UPDATE JobsTable
		SET cCompletedTime=@time, cStatus=@status, cLastUpdatedTime=GetUTCDate(), cJobMetadata=ISNULL(@jobMetadata, cJobMetadata)
		WHERE @guid = cGuid 

	SELECT @status = cStatus FROM JobsTable WHERE @guid = cGuid


   COMMIT TRAN
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
	  ROLLBACK TRAN --RollBack in case of Error

   DECLARE @ErrorMessage NVARCHAR(4000);
   DECLARE @ErrorSeverity INT;
   DECLARE @ErrorState INT;

   SELECT @ErrorMessage = ERROR_MESSAGE(),
		  @ErrorSeverity = ERROR_SEVERITY(),
		  @ErrorState = ERROR_STATE();

   RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH

RETURN















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateStartedStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateStartedStatus]
   (
   @guid uniqueidentifier,
   @time dateTime,
   @status nvarchar(50) OUTPUT
   )
AS

BEGIN TRY
   BEGIN TRANSACTION

      /* SET NOCOUNT ON */
      UPDATE JobsTable
      SET cLastStartedTime=@time, cStatus=@status, cMustAbort=0, cLastUpdatedTime=GETUTCDATE()
      WHERE @guid = cGuid 

      SELECT @status = cStatus FROM JobsTable WHERE @guid = cGuid

   COMMIT TRAN
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
      ROLLBACK TRAN --RollBack in case of Error

   DECLARE @ErrorMessage NVARCHAR(4000);
   DECLARE @ErrorSeverity INT;
   DECLARE @ErrorState INT;

   SELECT @ErrorMessage = ERROR_MESSAGE(),
		  @ErrorSeverity = ERROR_SEVERITY(),
		  @ErrorState = ERROR_STATE();

   RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH

RETURN








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetJobStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetJobStatus]
   (
   @guid uniqueidentifier,
   @status nvarchar(50) OUTPUT
   )
AS

BEGIN TRY
   BEGIN TRANSACTION

      /* SET NOCOUNT ON */
      SELECT @status = cStatus FROM JobsTable WHERE cGuid = @guid

   COMMIT TRAN
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
      ROLLBACK TRAN --RollBack in case of Error

   DECLARE @ErrorMessage NVARCHAR(4000);
   DECLARE @ErrorSeverity INT;
   DECLARE @ErrorState INT;

   SELECT @ErrorMessage = ERROR_MESSAGE(),
		  @ErrorSeverity = ERROR_SEVERITY(),
		  @ErrorState = ERROR_STATE();

   RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH

RETURN





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AbortJob]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AbortJob]
   (
   @guid uniqueidentifier,
   @reason nvarchar(MAX)
   )
AS

BEGIN TRY
   BEGIN TRANSACTION

	  UPDATE JobsTable
	  SET cMustAbort=1, cAbortReason=@reason
	  WHERE @guid = cGuid 

   COMMIT TRAN
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
	  ROLLBACK TRAN --RollBack in case of Error

   DECLARE @ErrorMessage NVARCHAR(4000);
   DECLARE @ErrorSeverity INT;
   DECLARE @ErrorState INT;

   SELECT @ErrorMessage = ERROR_MESSAGE(),
		  @ErrorSeverity = ERROR_SEVERITY(),
		  @ErrorState = ERROR_STATE();

   RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);

END CATCH

RETURN







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddJob]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AddJob]
   (
   @guid uniqueidentifier,
   @status nvarchar(50),
   @attempts int,
   @addedTime datetime,
   @userToken nvarchar(MAX),
   @jobMetadata nvarchar(MAX),
   @jobType nvarchar(MAX)
   )
AS

BEGIN TRY
   BEGIN TRANSACTION

      /* SET NOCOUNT ON */
      INSERT INTO JobsTable (cGuid, cStatus, cAttempts, cAddedTime,cUserToken, cJobMetadata, cPercentage, cMustAbort, cJobType) VALUES (@guid, @status, @attempts, @addedTime,@userToken, @jobMetadata, 0, 0, @jobType)

   COMMIT TRAN
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
      ROLLBACK TRAN --RollBack in case of Error

   DECLARE @ErrorMessage NVARCHAR(4000);
   DECLARE @ErrorSeverity INT;
   DECLARE @ErrorState INT;

   SELECT @ErrorMessage = ERROR_MESSAGE(),
		  @ErrorSeverity = ERROR_SEVERITY(),
		  @ErrorState = ERROR_STATE();

   RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH

RETURN







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetJobInformation]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetJobInformation]
   (
   @guid uniqueidentifier
   )
AS

BEGIN TRY
   BEGIN TRANSACTION

      SELECT * FROM JobsTable WHERE @guid = cGuid

   COMMIT TRAN
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
      ROLLBACK TRAN --RollBack in case of Error

   DECLARE @ErrorMessage NVARCHAR(4000);
   DECLARE @ErrorSeverity INT;
   DECLARE @ErrorState INT;

   SELECT @ErrorMessage = ERROR_MESSAGE(),
		  @ErrorSeverity = ERROR_SEVERITY(),
		  @ErrorState = ERROR_STATE();

   RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH

RETURN




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsMustAbort]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[IsMustAbort]
   (
   @guid uniqueidentifier,
   @aborted bit OUTPUT
   )
AS

BEGIN TRY
   BEGIN TRANSACTION

      /* SET NOCOUNT ON */
      SELECT @aborted=cMustAbort FROM JobsTable WHERE cGuid=@guid


   COMMIT TRAN
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
      ROLLBACK TRAN --RollBack in case of Error

   DECLARE @ErrorMessage NVARCHAR(4000);
   DECLARE @ErrorSeverity INT;
   DECLARE @ErrorState INT;

   SELECT @ErrorMessage = ERROR_MESSAGE(),
		  @ErrorSeverity = ERROR_SEVERITY(),
		  @ErrorState = ERROR_STATE();

   RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH

RETURN





' 
END
