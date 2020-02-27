' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Threading
Imports Leadtools.Dicom
Imports Leadtools
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Dicom.Scp.Command
Imports Leadtools.Medical.Worklist.DataAccessLayer
Imports Leadtools.Demos

Imports VBCustomizingWorklistDAL.DataTypes

Namespace VBCustomizingWorklistDAL
   Partial Public Class Form1 : Inherits Form
      Private _databaseLayer As DatabaseLayer
      Private _source As WorklistDataSource
      Private _worklistAgent As IWorklistDataAccessAgent
      Private _iodPath As String

      Public ReadOnly Property DatabaseLayer() As DatabaseLayer
         Get
            Return _databaseLayer
         End Get
      End Property

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      '<STAThread()> _
      Shared Sub Main()
         If Not Support.SetLicense() Then
            Return
         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New Form1())
      End Sub

      Public Sub New()
         InitializeComponent()

         DicomEngine.Startup()

         Messager.Caption = Me.Text

         If (Not DatabaseLayer.IsDataAccessSettingsValid()) Then
            MessageBox.Show("Database settings is not valid. Please run the PACS Database Configuration Demo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return
         End If

         _source = New WorklistDataSource()
         _databaseLayer = New DatabaseLayer(_source)
         _iodPath = Application.StartupPath

         _iodPath = Path.Combine(_iodPath, "CustomMWLIOD.xml")

         Using iodStream As Stream = MWLCFindCommand.DefualtMWLIOD
            Using customIODStream As FileStream = New FileStream(_iodPath, FileMode.Create)
               CopyTo(iodStream, customIODStream)
            End Using
         End Using

         _source.DatabaseTags.Add(New DatabaseDicomTags("Visit", "ServiceEpisodeDescription", DicomTag.ServiceEpisodeDescription))
         _source.DatabaseTags.Add(New DatabaseDicomTags("ScheduledProcedureStep", "CommentsOnTheScheduledProcedureStep", DicomTag.CommentsOnTheScheduledProcedureStep))
         _source.DatabaseTags.Add(New DatabaseDicomTags("Patient", "SmokingStatus", DicomTag.SmokingStatus))

         _worklistAgent = _databaseLayer.GetWorklistDataAgent()

         DataAccessServices.RegisterDataAccessService(Of IWorklistDataAccessAgent)(_worklistAgent)

         databaseStatus1.ConnectionString = _databaseLayer.ConnectionString
         databaseStatus1.ProviderName = _databaseLayer.Provider

         dicomTags1.SetSource(_source.DatabaseTags)
         worklistUpdate1.SetSource(_source.DatabaseTags)
         dicomQuery1.SetSource(_source.DatabaseTags, _iodPath)

         If _databaseLayer.IsDatabaseUpdated() Then
            Try
               WorklistIODUpdater.UpdateIOD(_source.DatabaseTags, _iodPath)
            Catch exception As Exception
               Messager.ShowError(Me, "Error Updating the Modality Work-list IOD document." + Environment.NewLine + exception.Message)
            End Try
         End If

         AddHandler UpdateDatabaseButton.Click, AddressOf UpdateDatabaseButton_Click
      End Sub

      Private Sub UpdateDatabaseButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If _databaseLayer.IsDatabaseUpdated() Then
               Messager.ShowInformation(Me, "Database has already been updated.")
            Else
               ' Add the tags to _source, only if they have not already been added
               Try
                  WorklistIODUpdater.UpdateIOD(_source.DatabaseTags, _iodPath)
               Catch exception As Exception
                  Messager.ShowError(Me, "Error Updating the Modality Work-list IOD document." + Environment.NewLine + exception.Message)
               End Try

               _databaseLayer.UpdateDatabase()
               Messager.ShowInformation(Me, "Database updated successfully.")
            End If

         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Shared Sub CopyTo(ByVal src As Stream, ByVal dest As Stream)
         If src Is Nothing Then
            Throw New System.ArgumentNullException("src")
         End If

         If dest Is Nothing Then
            Throw New System.ArgumentNullException("dest")
         End If

         System.Diagnostics.Debug.Assert(src.CanRead, "src.CanRead")
         System.Diagnostics.Debug.Assert(dest.CanWrite, "dest.CanWrite")

         Dim readCount As Integer = 0
         Dim buffer As Byte() = New Byte(8191) {}
         readCount = src.Read(buffer, 0, buffer.Length)
         Do While readCount <> 0
            dest.Write(buffer, 0, readCount)
            readCount = src.Read(buffer, 0, buffer.Length)
         Loop

      End Sub

   End Class
End Namespace
