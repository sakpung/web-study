' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Demos.Dialogs
#End If

Namespace Ocr2SharePointDemo
   Public Delegate Sub SetOperationTextDelegate(ByVal text As String)

   Partial Public Class MainForm : Inherits Form
      Private _demoOptions As DemoOptions = DemoOptions.Default
      Private _isRunningOperation As Boolean
      Private _sharePointLists As SharePoint.SPListInfo()

      Public Sub New()
         InitializeComponent()
      End Sub

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         If (Not DesignMode) Then
            Messager.Caption = "OCR 2 SharePoint 2010 VB.NET Demo"
            Text = Messager.Caption

            Me.Text = Messager.Caption

            _demoOptions = DemoOptions.Load()

            _sharePointServerSettingsControl.SetOwner(Me)
            _selectImageDocumentFileControl.SetOwner(Me, _demoOptions.ImageDocumentFileName)
            _sharePointBrowserControl.SetOwner(Me)
            _recognizeAndUploadControl.SetOwner(Me)

            _sharePointServerSettingsControl.SetServerSettings(_demoOptions.SharePointServerSettings)

            UpdateUIState()
         End If

         MyBase.OnLoad(e)
      End Sub

      Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
         e.Cancel = _isRunningOperation

         MyBase.OnFormClosing(e)
      End Sub

      Protected Overrides Sub OnFormClosed(ByVal e As FormClosedEventArgs)
         _demoOptions.Save()

         MyBase.OnFormClosed(e)
      End Sub

      Public Sub UpdateUIState()
         If _isRunningOperation Then
            _mainWizardControl.Enabled = False
            _operationPanel.Visible = True

            _aboutButton.Enabled = False
            _exitButton.Enabled = False
            _previousButton.Enabled = False
            _nextButton.Enabled = False
         Else
            _mainWizardControl.Enabled = True
            _operationPanel.Visible = False
            _aboutButton.Enabled = True
            _exitButton.Enabled = True

            If _mainWizardControl.SelectedTab Is _serverPropertiesTabPage Then
               ServerPropertiesUpdateUIState()
            ElseIf _mainWizardControl.SelectedTab Is _sharePointBrowserTabPage Then
               SharePointBrowserUpadateUIState()
            ElseIf _mainWizardControl.SelectedTab Is _selectImageDocumentFileTabPage Then
               SelectImageDocumentFileUpdateUIState()
            ElseIf _mainWizardControl.SelectedTab Is _recognizeAndUploadTabPage Then
               RecognizeAndUploadUpdateUIState()
            End If
         End If
      End Sub

      Public Sub BeginOperation(ByVal method As MethodInvoker)
         _isRunningOperation = True
         _operationLabel.Text = String.Empty
         UpdateUIState()

         method.BeginInvoke(Nothing, Nothing)
      End Sub

      Public Sub SetOperationText(ByVal text As String)
         _operationLabel.Text = text
      End Sub

      Public Sub EndOperation(ByVal err As Exception)
         BeginInvoke(New EndOperationDelegate(AddressOf DoEndOperation), New Object() {err})
      End Sub

      Private Delegate Sub EndOperationDelegate(ByVal err As Exception)
      Private Sub DoEndOperation(ByVal err As Exception)
         _isRunningOperation = False
         UpdateUIState()

         If err Is Nothing Then
            If _mainWizardControl.SelectedTab Is _serverPropertiesTabPage Then
               _demoOptions.SharePointServerSettings = _sharePointServerSettingsControl.ServerSettings
               _sharePointLists = _sharePointServerSettingsControl.SharePointLists
               _sharePointBrowserControl.SetSharePointSettings(_demoOptions.SharePointServerSettings, _sharePointLists)
               _nextButton.PerformClick()
            End If
         Else
            Messager.ShowError(Me, err)
         End If
      End Sub

      Private Sub ServerPropertiesUpdateUIState()
         _previousButton.Enabled = False
         _nextButton.Enabled = Not _sharePointServerSettingsControl.SharePointLists Is Nothing
         _nextButton.Text = "&Next"
      End Sub

      Private Sub SelectImageDocumentFileUpdateUIState()
         _previousButton.Enabled = True
         _nextButton.Enabled = Not String.IsNullOrEmpty(_selectImageDocumentFileControl.ImageDocumentFileName)
         _nextButton.Text = "&Next"
      End Sub

      Private Sub SharePointBrowserUpadateUIState()
         _previousButton.Enabled = True
         _nextButton.Enabled = Not String.IsNullOrEmpty(_sharePointBrowserControl.GetCurrentFolderPath(False))
         _nextButton.Text = "&Next"
      End Sub

      Private Sub RecognizeAndUploadUpdateUIState()
         _previousButton.Enabled = True
         _nextButton.Enabled = True
         _nextButton.Text = "&Next"
      End Sub

      Private Sub _aboutButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _aboutButton.Click
#If LEADTOOLS_V19_OR_LATER Then
         Using aboutDialog As New AboutDialog("OCR 2 SharePoint 2010", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
#Else
         Using aboutDialog As New AboutDialog("OCR 2 SharePoint 2010")
	         aboutDialog.ShowDialog(Me)
         End Using
#End If
      End Sub

      Private Sub _exitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _exitButton.Click
         Close()
      End Sub

      Private Sub _nextButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _nextButton.Click
         If _mainWizardControl.SelectedTab Is _serverPropertiesTabPage Then
            _mainWizardControl.SelectedTab = _sharePointBrowserTabPage
            _sharePointBrowserControl.RefreshCurrentFolder()
            UpdateUIState()
         ElseIf _mainWizardControl.SelectedTab Is _sharePointBrowserTabPage Then
            _mainWizardControl.SelectedTab = _selectImageDocumentFileTabPage
            UpdateUIState()
         ElseIf _mainWizardControl.SelectedTab Is _selectImageDocumentFileTabPage Then
            _demoOptions.ImageDocumentFileName = _selectImageDocumentFileControl.ImageDocumentFileName
            Dim format As MyDocumentFormat = _selectImageDocumentFileControl.GetSelectedDocumentFormat()
            _demoOptions.DocumentFormatIndex = CInt(format)

            ' Create the URL for the output document
            Dim outputDocumentPathAndFileName As String = BuildOutputDocumentPathAndFileName()

            _recognizeAndUploadControl.SetProperties(_demoOptions.SharePointServerSettings, _demoOptions.ImageDocumentFileName, outputDocumentPathAndFileName, CType(_demoOptions.DocumentFormatIndex, MyDocumentFormat))

            _mainWizardControl.SelectedTab = _recognizeAndUploadTabPage
            UpdateUIState()

            Application.DoEvents()
            _recognizeAndUploadControl.Run()
         ElseIf _mainWizardControl.SelectedTab Is _recognizeAndUploadTabPage Then
            _mainWizardControl.SelectedTab = _sharePointBrowserTabPage
            _sharePointBrowserControl.RefreshCurrentFolder()
            _sharePointBrowserControl.SelectItem(_recognizeAndUploadControl.LastUplodedDocumentUri)
            UpdateUIState()
         End If
      End Sub

      Private Sub _previousButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _previousButton.Click
         If _mainWizardControl.SelectedTab Is _sharePointBrowserTabPage Then
            _mainWizardControl.SelectedTab = _serverPropertiesTabPage
            UpdateUIState()
         ElseIf _mainWizardControl.SelectedTab Is _selectImageDocumentFileTabPage Then
            _mainWizardControl.SelectedTab = _sharePointBrowserTabPage
            _sharePointBrowserControl.RefreshCurrentFolder()
            UpdateUIState()
         ElseIf _mainWizardControl.SelectedTab Is _recognizeAndUploadTabPage Then
            _mainWizardControl.SelectedTab = _selectImageDocumentFileTabPage
            UpdateUIState()
         End If
      End Sub

      Private Function BuildOutputDocumentPathAndFileName() As String
         ' Get the server folder URI
         Dim folderPath As String = _sharePointBrowserControl.GetCurrentFolderPath(False)

         Dim format As MyDocumentFormat = CType(_demoOptions.DocumentFormatIndex, MyDocumentFormat)
         Dim extension As String = MyDocumentFormatItem.GetExtension(format)
         Dim name As String = System.IO.Path.GetFileNameWithoutExtension(_demoOptions.ImageDocumentFileName)

         Dim outputDocumentPathAndFileName As String = System.IO.Path.Combine(folderPath, name)
         outputDocumentPathAndFileName = System.IO.Path.ChangeExtension(outputDocumentPathAndFileName, extension)
         Return outputDocumentPathAndFileName
      End Function
   End Class
End Namespace
