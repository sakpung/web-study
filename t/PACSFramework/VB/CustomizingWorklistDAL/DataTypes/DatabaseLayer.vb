' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Configuration
Imports Leadtools.Medical.Worklist.DataAccessLayer
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports Microsoft.Practices.EnterpriseLibrary.Data.SqlCe
Imports Leadtools.Medical.DataAccessLayer.Configuration
Imports Leadtools.Medical.Worklist.DataAccessLayer.Configuration
Imports Leadtools.DicomDemos
Imports Leadtools.Demos.StorageServer.DataTypes

Namespace VBCustomizingWorklistDAL.DataTypes
   Public Class DatabaseLayer
      Private _database As DatabaseUtility
      Private _source As WorklistDataSource
      Private _agent As IWorklistDataAccessAgent

      Public Sub New(ByVal source As WorklistDataSource)
         If IsDataAccessSettingsValid() Then
            _source = source

            Dim configuration As System.Configuration.Configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration()

            Dim view As New WorklistDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameDemoServer, Nothing)

            ConnectionString = view.GetConnectionStringSettings().ConnectionString
            Provider = view.GetConnectionStringSettings().ProviderName

            If Provider = DataAccessMapping.DefaultSqlProviderName Then
               _database = New SqlServerDatabaseUtility(ConnectionString)
               _agent = New WorklistSqlDbDataAccessAgent(ConnectionString)
            ElseIf Provider = DataAccessMapping.DefaultSqlCe3_5ProviderName Then
               _database = New SqlCeDatabaseUtility(ConnectionString)
               _agent = New WorklistSqlCeDataAccessAgent(ConnectionString)
            Else
               Throw New NotImplementedException()
            End If
         End If
      End Sub

      Public Sub UpdateDatabase()
         For Each dbColumnTag As DatabaseDicomTags In _source.DatabaseTags
            If (Not _database.IsColumnExists(dbColumnTag.TableName, dbColumnTag.ColumnName)) Then
               _database.AddStringColumn(dbColumnTag.TableName, dbColumnTag.ColumnName)
            End If
         Next dbColumnTag
      End Sub

      Public Function IsDatabaseUpdated() As Boolean
         For Each dbColumnTag As DatabaseDicomTags In _source.DatabaseTags
            If (Not _database.IsColumnExists(dbColumnTag.TableName, dbColumnTag.ColumnName)) Then
               Return False
            End If
         Next dbColumnTag

         Return True
      End Function

      Public Shared Function IsDataAccessSettingsValid() As Boolean
         Dim configuration As System.Configuration.Configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration()

         Dim view As New WorklistDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameDemoServer, Nothing)

         ConfigurationManager.RefreshSection(view.DataAccessSettingsSectionName)

         Return GlobalPacsUpdater.IsDataAccessSettingsValid(configuration, view.DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameDemoServer)
      End Function


      Public ConnectionString As String
      Public Provider As String

      Public Function GetWorklistDataAgent() As IWorklistDataAccessAgent
         Return _agent
      End Function
   End Class

   Class SqlServerDatabaseUtility : Inherits DatabaseUtility
      Public Sub New(ByVal connectionString As String)
         MyBase.New(connectionString)

      End Sub

      Public Overrides Sub AddStringColumn(ByVal tableName As String, ByVal columnName As String)
         Using connection As DbConnection = DataProvider.CreateConnection()
            connection.Open()

            Using command As DbCommand = connection.CreateCommand()
               command.CommandText = String.Format("alter table [{0}] add [{1}] nvarchar(400)", tableName, columnName)
               command.ExecuteNonQuery()
            End Using
         End Using
      End Sub

      Public Overrides Function IsColumnExists(ByVal tableName As String, ByVal columnName As String) As Boolean

         Using connection As DbConnection = DataProvider.CreateConnection()
            connection.Open()

            Using command As DbCommand = connection.CreateCommand()
               command.CommandText = String.Format("select column_name from INFORMATION_SCHEMA.columns where table_name = '{0}' and column_name = '{1}'", tableName, columnName)

               Dim result As Object = command.ExecuteScalar()

               Return Not Nothing Is result AndAlso result.ToString() = columnName
            End Using
         End Using
      End Function

      Protected ReadOnly Property DataProvider() As Database
         Get
            If Nothing Is _dataProvider Then
               _dataProvider = CreateDatabaseProvider()
            End If

            Return _dataProvider
         End Get
      End Property

      Protected Overridable Function CreateDatabaseProvider() As Database
         Return New SqlDatabase(ConnectionString)
      End Function

      Private _dataProvider As Database
   End Class
   Class SqlCeDatabaseUtility : Inherits SqlServerDatabaseUtility
      Public Sub New(ByVal connectionString As String)
         MyBase.New(connectionString)
      End Sub

      Protected Overrides Function CreateDatabaseProvider() As Database
         Return New SqlCeDatabase(ConnectionString)
      End Function
   End Class

   MustInherit Class DatabaseUtility
      Public Sub New(ByVal connectionString As String)
         Me.ConnectionString = connectionString
      End Sub

      Public MustOverride Sub AddStringColumn(ByVal tableName As String, ByVal columnName As String)

      Public MustOverride Function IsColumnExists(ByVal tableName As String, ByVal columnName As String) As Boolean

      Public ConnectionString As String

   End Class
End Namespace

