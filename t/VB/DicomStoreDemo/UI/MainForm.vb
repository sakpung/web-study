' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Configuration
Imports System.Net
Imports Microsoft.Win32
Imports System.IO

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Imports Leadtools.DicomDemos.Scu.CStore

#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Demos.Dialogs
#End If

Imports Leadtools.Dicom.Common.Extensions

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for Form1.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private statusBar1 As System.Windows.Forms.StatusBar
      Private panel2 As System.Windows.Forms.Panel
      Private splitter2 As System.Windows.Forms.Splitter
      Private panel3 As System.Windows.Forms.Panel
      Private WithEvents listViewImages As System.Windows.Forms.ListView
      Private columnHeader1 As System.Windows.Forms.ColumnHeader
      Private columnHeader2 As System.Windows.Forms.ColumnHeader
      Private columnHeader3 As System.Windows.Forms.ColumnHeader
      Private columnHeader4 As System.Windows.Forms.ColumnHeader
      Private columnHeader5 As System.Windows.Forms.ColumnHeader
      Private columnHeader6 As System.Windows.Forms.ColumnHeader
      Private components As System.ComponentModel.IContainer
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private mainMenu1 As System.Windows.Forms.MainMenu
      Private WithEvents menuItemAddDicom As System.Windows.Forms.MenuItem
      Private WithEvents menuItemAddDicomDir As System.Windows.Forms.MenuItem
      Private openFileDialog As System.Windows.Forms.OpenFileDialog

      Private menuItem2 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemExit As System.Windows.Forms.MenuItem

      Private cstore As CStore
      Private menuItem3 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemCStore As System.Windows.Forms.MenuItem
      Private server As DicomServer = New DicomServer()
      Private menuItem5 As System.Windows.Forms.MenuItem
      Private WithEvents Options As System.Windows.Forms.MenuItem

      Private AETitle As String = "CLIENT1"
      Private IsSecure As Boolean = False
      Private GroupLengthDataElements As Boolean = False

      Private WithEvents menuItemFile As System.Windows.Forms.MenuItem
      Private WithEvents menuItemClearLog As System.Windows.Forms.MenuItem
      Private Log As System.Windows.Forms.RichTextBox
      Private WithEvents menuItemHelp As System.Windows.Forms.MenuItem
      Private WithEvents menuItemAbout As System.Windows.Forms.MenuItem

      Private progress As ProgressForm = New ProgressForm()

      Public Delegate Sub AddLog(ByVal sentence As String)
      Public Delegate Sub EnableMenu(ByVal enable As Boolean)


      Private Const CONFIGURATION_LICENSE As String = "LEADTOOLS OCX Copyright (c) 1991-2004 LEAD Technologies, Inc."
      Private Const CONFIGURATION_IMPLEMENTATIONCLASS As String = "1.2.840.114257.1123456"
      Private Const CONFIGURATION_IMPLEMENTATIONVERSIONNAME As String = "1"
      Private Const CONFIGURATION_PROTOCOLVERSION As String = "1"

      Private Const _sTab As String = Constants.vbTab
      Private _settingsLocation As String = "SOFTWARE\LEAD Technologies, Inc.\17\VBNet_DicomSTR17"

#If LEADTOOLS_V17_OR_LATER Then
      Private _ipType As DicomNetIpTypeFlags = DicomNetIpTypeFlags.Ipv4
      Private disableLogging As Boolean = False
#End If

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
         Utils.EngineStartup()
         Utils.DicomNetStartup()
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not components Is Nothing Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"
      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me.components = New System.ComponentModel.Container
         Me.statusBar1 = New System.Windows.Forms.StatusBar
         Me.panel2 = New System.Windows.Forms.Panel
         Me.listViewImages = New System.Windows.Forms.ListView
         Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader4 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader5 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader6 = New System.Windows.Forms.ColumnHeader
         Me.splitter2 = New System.Windows.Forms.Splitter
         Me.panel3 = New System.Windows.Forms.Panel
         Me.Log = New System.Windows.Forms.RichTextBox
         Me.mainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
         Me.menuItemFile = New System.Windows.Forms.MenuItem
         Me.Options = New System.Windows.Forms.MenuItem
         Me.menuItemClearLog = New System.Windows.Forms.MenuItem
         Me.menuItem5 = New System.Windows.Forms.MenuItem
         Me.menuItemAddDicom = New System.Windows.Forms.MenuItem
         Me.menuItemAddDicomDir = New System.Windows.Forms.MenuItem
         Me.menuItem3 = New System.Windows.Forms.MenuItem
         Me.menuItemCStore = New System.Windows.Forms.MenuItem
         Me.menuItem2 = New System.Windows.Forms.MenuItem
         Me.menuItemExit = New System.Windows.Forms.MenuItem
         Me.menuItemHelp = New System.Windows.Forms.MenuItem
         Me.menuItemAbout = New System.Windows.Forms.MenuItem
         Me.openFileDialog = New System.Windows.Forms.OpenFileDialog
         Me.panel2.SuspendLayout()
         Me.panel3.SuspendLayout()
         Me.SuspendLayout()
         '
         'statusBar1
         '
         Me.statusBar1.Location = New System.Drawing.Point(0, 391)
         Me.statusBar1.Name = "statusBar1"
         Me.statusBar1.ShowPanels = True
         Me.statusBar1.Size = New System.Drawing.Size(680, 22)
         Me.statusBar1.SizingGrip = False
         Me.statusBar1.TabIndex = 0
         '
         'panel2
         '
         Me.panel2.Controls.Add(Me.listViewImages)
         Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
         Me.panel2.Location = New System.Drawing.Point(0, 0)
         Me.panel2.Name = "panel2"
         Me.panel2.Size = New System.Drawing.Size(680, 240)
         Me.panel2.TabIndex = 3
         '
         'listViewImages
         '
         Me.listViewImages.CheckBoxes = True
         Me.listViewImages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4, Me.columnHeader5, Me.columnHeader6})
         Me.listViewImages.Dock = System.Windows.Forms.DockStyle.Fill
         Me.listViewImages.FullRowSelect = True
         Me.listViewImages.GridLines = True
         Me.listViewImages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me.listViewImages.HideSelection = False
         Me.listViewImages.Location = New System.Drawing.Point(0, 0)
         Me.listViewImages.Name = "listViewImages"
         Me.listViewImages.Size = New System.Drawing.Size(680, 240)
         Me.listViewImages.TabIndex = 0
         Me.listViewImages.UseCompatibleStateImageBehavior = False
         Me.listViewImages.View = System.Windows.Forms.View.Details
         '
         'columnHeader1
         '
         Me.columnHeader1.Text = "Patient Name"
         '
         'columnHeader2
         '
         Me.columnHeader2.Text = "Patient ID"
         '
         'columnHeader3
         '
         Me.columnHeader3.Text = "Study ID"
         '
         'columnHeader4
         '
         Me.columnHeader4.Text = "Modality"
         '
         'columnHeader5
         '
         Me.columnHeader5.Text = "Transfer Syntax"
         '
         'columnHeader6
         '
         Me.columnHeader6.Text = "File Path"
         '
         'splitter2
         '
         Me.splitter2.Dock = System.Windows.Forms.DockStyle.Top
         Me.splitter2.Location = New System.Drawing.Point(0, 240)
         Me.splitter2.Name = "splitter2"
         Me.splitter2.Size = New System.Drawing.Size(680, 3)
         Me.splitter2.TabIndex = 4
         Me.splitter2.TabStop = False
         '
         'panel3
         '
         Me.panel3.Controls.Add(Me.Log)
         Me.panel3.Dock = System.Windows.Forms.DockStyle.Fill
         Me.panel3.Location = New System.Drawing.Point(0, 243)
         Me.panel3.Name = "panel3"
         Me.panel3.Size = New System.Drawing.Size(680, 148)
         Me.panel3.TabIndex = 5
         '
         'Log
         '
         Me.Log.Dock = System.Windows.Forms.DockStyle.Fill
         Me.Log.Location = New System.Drawing.Point(0, 0)
         Me.Log.Name = "Log"
         Me.Log.ReadOnly = True
         Me.Log.Size = New System.Drawing.Size(680, 148)
         Me.Log.TabIndex = 0
         Me.Log.Text = ""
         '
         'mainMenu1
         '
         Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemFile, Me.menuItemHelp})
         '
         'menuItemFile
         '
         Me.menuItemFile.Index = 0
         Me.menuItemFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.Options, Me.menuItemClearLog, Me.menuItem5, Me.menuItemAddDicom, Me.menuItemAddDicomDir, Me.menuItem3, Me.menuItemCStore, Me.menuItem2, Me.menuItemExit})
         Me.menuItemFile.Text = "&File"
         '
         'Options
         '
         Me.Options.Index = 0
         Me.Options.Text = "&Options..."
         '
         'menuItemClearLog
         '
         Me.menuItemClearLog.Index = 1
         Me.menuItemClearLog.Text = "&Clear Log"
         '
         'menuItem5
         '
         Me.menuItem5.Index = 2
         Me.menuItem5.Text = "-"
         '
         'menuItemAddDicom
         '
         Me.menuItemAddDicom.Index = 3
         Me.menuItemAddDicom.Text = "Add Dicom..."
         '
         'menuItemAddDicomDir
         '
         Me.menuItemAddDicomDir.Index = 4
         Me.menuItemAddDicomDir.Text = "Add Dicom Dir..."
         '
         'menuItem3
         '
         Me.menuItem3.Index = 5
         Me.menuItem3.Text = "-"
         '
         'menuItemCStore
         '
         Me.menuItemCStore.Index = 6
         Me.menuItemCStore.Text = "&Store"
         '
         'menuItem2
         '
         Me.menuItem2.Index = 7
         Me.menuItem2.Text = "-"
         '
         'menuItemExit
         '
         Me.menuItemExit.Index = 8
         Me.menuItemExit.Text = "&Exit"
         '
         'menuItemHelp
         '
         Me.menuItemHelp.Index = 1
         Me.menuItemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemAbout})
         Me.menuItemHelp.Text = "&Help"
         '
         'menuItemAbout
         '
         Me.menuItemAbout.Index = 0
         Me.menuItemAbout.Text = "&About"
         '
         'openFileDialog
         '
         Me.openFileDialog.Multiselect = True
         '
         'MainForm
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(680, 413)
         Me.Controls.Add(Me.panel3)
         Me.Controls.Add(Me.splitter2)
         Me.Controls.Add(Me.panel2)
         Me.Controls.Add(Me.statusBar1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Menu = Me.mainMenu1
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "LEADTOOLS Dicom Storage SCU - VB.NET"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         Me.panel2.ResumeLayout(False)
         Me.panel3.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
#End Region

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()>
        Shared Sub Main()
            Application.EnableVisualStyles()
#If LEADTOOLS_V175_OR_LATER Then
            If Not Support.SetLicense() Then
                Return
            End If
#Else
         Support.Unlock(False)
#End If


#If LEADTOOLS_V175_OR_LATER Then
            If (RasterSupport.IsLocked(RasterSupportType.DicomCommunication)) Then
                MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning")
                Return
            End If
#Else
         If (RasterSupport.IsLocked(RasterSupportType.MedicalNet)) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.MedicalNet.ToString()), "Warning")
            Return
         End If
#End If
            Application.Run(New MainForm())
        End Sub

        Private Sub CreateCStoreObject(ByVal secure As Boolean)
         If Not cstore Is Nothing Then
            cstore.Dispose()
         End If
         If secure = True Then
            Dim clientPEM As String = Application.StartupPath & "\client.pem"
            Dim privateKeyPassword As String = "test"
            cstore = New CStore(clientPEM, DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384, DicomTlsCertificateType.Pem, privateKeyPassword)
         Else
            cstore = New CStore()
         End If

         cstore.ImplementationClass = CONFIGURATION_IMPLEMENTATIONCLASS
         cstore.ImplementationVersionName = CONFIGURATION_IMPLEMENTATIONVERSIONNAME
         cstore.ProtocolVersion = CONFIGURATION_PROTOCOLVERSION
         AddHandler cstore.Status, AddressOf cstore_Status
         AddHandler cstore.ProgressFiles, AddressOf cstore_ProgressFiles
      End Sub
      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

#If LTV20_CONFIG Then
         _settingsLocation = "SOFTWARE\LEAD Technologies, Inc.\20\VBNet_DicomSTR20"
#ElseIf LTV19_CONFIG Then
         _settingsLocation = "SOFTWARE\LEAD Technologies, Inc.\19\VBNet_DicomSTR19"
#ElseIf LTV18_CONFIG Then
         _settingsLocation = "SOFTWARE\LEAD Technologies, Inc.\18\VBNet_DicomSTR18"
#ElseIf LTV175_CONFIG Then
         _settingsLocation = "SOFTWARE\LEAD Technologies, Inc.\17.5\VBNet_DicomSTR17.5"
#ElseIf LTV17_CONFIG Then
         _settingsLocation = "SOFTWARE\LEAD Technologies, Inc.\17\VBNet_DicomSTR17"
#ElseIf LTV16_CONFIG Then
         _settingsLocation = "SOFTWARE\LEAD Technologies, Inc.\16\VBNet_DicomSTR16"
#Else
         _settingsLocation = "SOFTWARE\LEAD Technologies, Inc.\15\VBNet_DicomSTR15"
#End If

         LoadSettings()
         cstore = Nothing
         CreateCStoreObject(_useTls)
         If cstore IsNot Nothing Then
            cstore.PresentationContextType = _presentationContextType
            cstore.Compression = _cstoreCompressionType
         End If

         Using dcm As New DicomDataSet()

            If dcm Is Nothing Then
               MessageBox.Show("Can't create dicom object. Quitting app.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
               Application.Exit()
               Return
            End If
         End Using

         Using dcmDir As New DicomDataSet()

            If dcmDir Is Nothing Then
               MessageBox.Show("Can't create dicom object. Quitting app.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
               Application.Exit()
               Return
            End If
         End Using

         panel2.Height = Convert.ToInt32(Me.ClientSize.Height * 0.5)
         UpdateCStoreOptions()

         AddHandler Application.ApplicationExit, AddressOf Application_ApplicationExit
      End Sub

      Private Sub Application_ApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
         cstore.Dispose()
         Utils.EngineShutdown()
         Utils.DicomNetShutdown()
      End Sub

      Private Sub menuItemAddDicom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAddDicom.Click
         openFileDialog.Title = "Add DICOM File"
         openFileDialog.Filter = "DICOM Files (*.dic;*.dcm)|*.dic;*.dcm|All files (*.*)|*.*"
         If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            For Each file As String In openFileDialog.FileNames
               LoadDicomFile(file)
            Next file
         End If
      End Sub

      Private Sub menuItemAddDicomDir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAddDicomDir.Click
         openFileDialog.Title = "Add DICOM Dir"
         openFileDialog.Filter = "All Files|*.*"
         openFileDialog.FileName = "DICOMDIR"
         If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            For Each file As String In openFileDialog.FileNames
               LoadDicomDir(file)
            Next file
         End If
      End Sub

      Private Sub LogText(ByVal s1 As String, ByVal s2 As String)
         If (disableLogging) Then
            Return

         End If
         Log.Text = Log.Text & s1 & s2 & Constants.vbCrLf
      End Sub

      Private Function LoadDicomFile(ByVal filename As String) As Boolean
         'if (_cancel)
         '   return false;

         Using ds As New DicomDataSet()

            Dim item As ListViewItem = Nothing
            Dim element As DicomElement
            Dim strTransferSyntax As String = ""
            Dim succeeded As Boolean = True

            Try
               Me.Cursor = Cursors.WaitCursor
               ds.Load(filename, DicomDataSetLoadFlags.None)
               item = listViewImages.Items.Add(ds.GetValue(Of String)(DicomTag.PatientName, String.Empty))
               item.SubItems.Add(ds.GetValue(Of String)(DicomTag.PatientID, String.Empty))
               item.SubItems.Add(ds.GetValue(Of String)(DicomTag.StudyID, String.Empty))
               item.SubItems.Add(ds.GetValue(Of String)(DicomTag.Modality, String.Empty))

               strTransferSyntax = "Implicit VR - Little Endian"

               element = ds.FindFirstElement(Nothing, DicomTag.TransferSyntaxUID, False)
               If element IsNot Nothing AndAlso ds.GetElementValueCount(element) > 0 Then
                  Dim uidString As String
                  Dim uid As DicomUid

                  uidString = ds.GetValue(Of String)(element, String.Empty)
                  uid = DicomUidTable.Instance.Find(uidString)
                  If uid IsNot Nothing Then
                     strTransferSyntax = uid.Name
                  End If
               End If
            Catch de As DicomException
               LogText("Dicom error: " & de.Code.ToString(), filename)
               succeeded = False
            End Try

            If succeeded Then
               ' Mark item read if we have a basic directory
               If ds.InformationClass = DicomClassType.BasicDirectory Then
                  item.Font = New Font(listViewImages.Font, FontStyle.Bold)
               End If

               item.SubItems.Add(strTransferSyntax)
               item.SubItems.Add(filename)

               item.Checked = True
            End If
            Me.Cursor = Cursors.Default
            Return succeeded
         End Using
      End Function

      Private Sub LoadDicomDir(ByVal filename As String)
         Using ds As New DicomDataSet()
            Dim pathname As String = String.Empty
            Dim refFilename As String = String.Empty
            Dim element As DicomElement = Nothing
            Dim count As Integer = 0
            Dim totalCount As Integer = 0
            Dim nMod As Integer = 10
            Dim sMsg As String = String.Empty


            If (Not filename.ToUpper().Contains("DICOMDIR")) Then
               Return
            End If

            pathname = Path.GetDirectoryName(filename) & "\"
            Try
               Me.Cursor = Cursors.WaitCursor
               ds.Load(filename, DicomDataSetLoadFlags.None)

               ' Get the total count
               element = ds.FindFirstElement(Nothing, DicomTag.ReferencedFileID, False)
               Do While element IsNot Nothing
                  totalCount += 1
                  element = ds.FindNextElement(element, False)
               Loop

               If totalCount > 20 Then
                  nMod = 10
               End If

               ' now get the datasets
               element = ds.FindFirstElement(Nothing, DicomTag.ReferencedFileID, False)
               If element IsNot Nothing AndAlso ds.GetElementValueCount(element) > 0 Then
                  'if (!_cancel)
                  LogText("Loading DICOMDIR", String.Empty)
                  refFilename = ds.GetConvertValue(element)
                  If LoadDicomFile(pathname & refFilename) Then
                     count += 1
                  End If
                  Application.DoEvents()
               End If

               Do While (refFilename.Length > 0)
                  element = ds.FindNextElement(element, False)
                  If element IsNot Nothing AndAlso ds.GetElementValueCount(element) > 0 Then
                     refFilename = ds.GetConvertValue(element)
                     If LoadDicomFile(pathname & refFilename) Then
                        count += 1
                     End If
                     Application.DoEvents()
                  Else
                     refFilename = ""
                  End If
                  If count Mod nMod = 0 Then
                     sMsg = String.Format("Loaded {0} of {1} files...", count.ToString(), totalCount.ToString())
                     LogText(String.Empty, _sTab & sMsg)
                     'StatusText(sMsg);
                  End If
               Loop
            Catch de As DicomException
               LogText("Dicom error: " & de.Code.ToString(), filename)
            End Try
            sMsg = String.Format("Loaded {0} of {1} total files", count.ToString(), totalCount.ToString())
            LogText(String.Empty, _sTab & sMsg)
            ' StatusText(sMsg);
            Me.Cursor = Cursors.Default
         End Using
      End Sub

      Private Sub menuItemExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemExit.Click
         Close()
      End Sub

      Private Sub listViewImages_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listViewImages.SizeChanged
         For Each col As ColumnHeader In listViewImages.Columns
            col.Width = CInt(listViewImages.Width / listViewImages.Columns.Count)
         Next col
      End Sub

      Private Sub menuItemCStore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemCStore.Click
         menuItemFile.Enabled = False
         cstore.Store(server, AETitle)
      End Sub

      Private Sub listViewImages_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles listViewImages.ItemCheck
         Dim filename As String

         filename = listViewImages.Items(e.Index).SubItems(5).Text

         If e.NewValue = CheckState.Checked Then
            '
            ' add file to cstore object
            '
            cstore.Files.Add(filename)
         Else
            '
            ' remove file from cstore object
            '
            cstore.Files.Remove(filename)
         End If
      End Sub

      Private Sub menuItem1_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemFile.Popup
         menuItemCStore.Enabled = (cstore.Files.Count > 0 AndAlso server.AETitle.Length > 0 AndAlso AETitle.Length > 0)
      End Sub

      Public Sub LogText(ByVal logMessage As String)
         If (disableLogging) Then
            Return

         End If
         If InvokeRequired Then
            Invoke(New AddLog(AddressOf LogText), New Object() {logMessage})
         Else
            Log.Text = Log.Text & logMessage & Constants.vbCrLf
         End If

      End Sub

      Public Sub EnableFileMenu(ByVal enable As Boolean)
         If Me.InvokeRequired Then
            Invoke(New EnableMenu(AddressOf EnableFileMenu), New Object() {enable})
         Else
            menuItemFile.Enabled = enable
         End If
      End Sub

      Private Sub cstore_Status(ByVal sender As Object, ByVal e As StatusEventArgs)
         Dim message As String = ""
         Dim done As Boolean = False

         If e.Type = StatusType.Error Then
            message = "DICOM error. The process will be terminated! -- Error code is: " & e.Error.ToString()
         Else
            Select Case e.Type
               Case StatusType.ConnectFailed
                  message = "Connect operation failed."
                  done = True
               Case StatusType.ConnectSucceeded
                  message = "Connected successfully." & Constants.vbLf
                  message &= Constants.vbTab & "Peer Address:" & Constants.vbTab + e.PeerIP.ToString() & Constants.vbLf
                  message &= Constants.vbTab & "Peer Port:" & Constants.vbTab + Constants.vbTab + e.PeerPort.ToString()
               Case StatusType.SendAssociateRequest
                  message = "Sending association request..."
               Case StatusType.ReceiveAssociateAccept
                  message = "Received Associate Accept." & Constants.vbLf
                  message &= Constants.vbTab & "Calling AE:" & Constants.vbTab + e.CallingAE + Constants.vbLf
                  message &= Constants.vbTab & "Called AE:" & Constants.vbTab + e.CalledAE
               Case StatusType.ReceiveAssociateReject
                  message = "Received Associate Reject!"
                  message &= Constants.vbTab & "Result: " & e.Result.ToString()
                  message &= Constants.vbTab & "Reason: " & e.Reason.ToString()
                  message &= Constants.vbTab & "Source: " & e.Source.ToString()
               Case StatusType.AbstractSyntaxNotSupported
                  message = "Abstract Syntax NOT supported!"
               Case StatusType.SendCStoreRequest
                  message = "Sending C-STORE Request..."
               Case StatusType.ReceiveCStoreResponse
                  If e.Error = DicomExceptionCode.Success Then
                     message = "**** Storage completed successfully ****"
                  Else
                     message = "**** Storage failed with status: " & e.Status.ToString()
                  End If
               Case StatusType.ConnectionClosed
                  message = "Network Connection closed!"
                  done = True
               Case StatusType.ProcessTerminated
                  message = "Process has been terminated!"
                  done = True
               Case StatusType.SendReleaseRequest
                  message = "Sending release request..."
               Case StatusType.ReceiveReleaseResponse
                  message = "Receiving release response"
                  done = True
               Case StatusType.Timeout
                  message = "Communication timeout. Process will be terminated."
                  done = True
               Case StatusType.SecureLinkReady
                  Dim net As DicomNet = TryCast(sender, DicomNet)
                  If net IsNot Nothing Then
                     Dim cipher As DicomTlsCipherSuiteType = net.GetTlsCipherSuite()
                     If e.Error = DicomExceptionCode.Success Then
                        message = String.Format(Constants.vbLf + Constants.vbTab & "Secure Link Ready" & Constants.vbLf + Constants.vbTab & "Cipher Suite: {0}", cipher.GetCipherFriendlyName())
                     Else
                        message = Constants.vbLf + Constants.vbTab & "Secure Link Failed" & Constants.vbLf + Constants.vbTab & "Error:" & Constants.vbTab + e.Error.ToString()
                     End If
                  End If
            End Select
         End If
         LogText(message)
         If done Then
            EnableFileMenu(True)

            If cstore.IsConnected() Then
               cstore.Close()
            End If
         End If
      End Sub

      Private Sub cstore_ProgressFiles(ByVal sender As Object, ByVal e As ProgressFilesEventArgs)
         Dim message As String

         message = "File to be stored: " & e.File.FullName
         message &= Constants.vbLf + Constants.vbTab & "Size: " & e.File.Length.ToString()
         LogText(message)
      End Sub

      ' Settings
      Public _mySettings As DicomDemoSettings = Nothing
      Public _demoName As String = Path.GetFileName(Application.ExecutablePath)
      Dim _useTls As Boolean = False
      Dim _cstoreCompressionType As DicomImageCompressionType = DicomImageCompressionType.None
      Dim _presentationContextType As Integer = 0

      Private Sub Options_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Options.Click
         Dim optionDlg As New OptionsDialog()

         optionDlg.DisableLogging.Checked = disableLogging
         optionDlg.ServerAE.Text = server.AETitle
         optionDlg.ServerPort.Text = server.Port.ToString()
         optionDlg.ServerIp.Text = server.Address.ToString()
         optionDlg.IpType = server.IpType
         optionDlg.Compression = cstore.Compression
         optionDlg.PresentationContextType = cstore.PresentationContextType
         optionDlg.Timeout.Text = server.Timeout.ToString()
         optionDlg.ClientAE.Text = AETitle
         optionDlg.UseSecureTLSCommunication.Checked = IsSecure
         optionDlg.GroupLengthDataElements = GroupLengthDataElements
         optionDlg.UseSecureTLSCommunication.Checked = _useTls
         optionDlg.CipherSuites = _mySettings.CipherSuites
         If optionDlg.ShowDialog() = DialogResult.OK Then
            disableLogging = optionDlg.DisableLogging.Checked
            server.AETitle = optionDlg.ServerAE.Text
            server.Port = Convert.ToInt32(optionDlg.ServerPort.Text)
            server.Address = IPAddress.Parse(optionDlg.ServerIp.Text)
            server.IpType = optionDlg.IpType
            cstore.Compression = optionDlg.Compression
            cstore.PresentationContextType = optionDlg.PresentationContextType
            server.Timeout = Convert.ToInt32(optionDlg.Timeout.Text)
            AETitle = optionDlg.ClientAE.Text
            If IsSecure <> optionDlg.UseSecureTLSCommunication.Checked Then
               Cursor = Cursors.WaitCursor

                    Try
                        IsSecure = optionDlg.UseSecureTLSCommunication.Checked
                        CreateCStoreObject(IsSecure)
                        Dim filename As String
                        For Each item As ListViewItem In listViewImages.Items
                            If item.Checked = True Then
                                filename = item.SubItems(5).Text
                                If filename IsNot Nothing Then
                                    cstore.Files.Add(filename)
                                End If
                            End If
                        Next item
                    Catch e1 As Exception

                    Finally
                  Cursor = Cursors.Arrow
               End Try
            End If
            GroupLengthDataElements = optionDlg.GroupLengthDataElements
            _useTls = optionDlg.UseSecureTLSCommunication.Checked
            _mySettings.CipherSuites = optionDlg.CipherSuites
            SaveSettings()
            UpdateCStoreOptions()
         End If
      End Sub

      Private Sub LoadSettings()


         _mySettings = DicomDemoSettingsManager.LoadSettings(_demoName)
         If _mySettings Is Nothing Then
            _mySettings = New DicomDemoSettings()
            _mySettings.FirstRun = False
            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
         End If

         Dim user As RegistryKey = Registry.CurrentUser
         Dim settings As RegistryKey = user.OpenSubKey(_settingsLocation, True)
         If settings Is Nothing Then
            '
            ' We haven't saved any setting yet.  Will use the default
            '  settings.
            Return
         End If

            _useTls = Convert.ToBoolean(settings.GetValue("UseTls", False))
            If _useTls Then
                If Utils.VerifyOpensslVersion(Me) = False Then
                    _useTls = False
                End If
            End If

            server.AETitle = Convert.ToString(settings.GetValue("ServerAE"))
         server.Port = Convert.ToInt32(settings.GetValue("ServerPort", 104))
         Dim sValue As String = Convert.ToString(settings.GetValue("ServerIpType"))
         If String.IsNullOrEmpty(sValue) Then
            server.IpType = DicomNetIpTypeFlags.Ipv4
         Else
            server.IpType = CType(DemosGlobal.StringToEnum(GetType(DicomNetIpTypeFlags), sValue), DicomNetIpTypeFlags)
         End If
         _ipType = server.IpType
         server.Address = IPAddress.Parse(Convert.ToString(settings.GetValue("ServerAddress", "127.0.0.1")))
         server.Timeout = Convert.ToInt32(settings.GetValue("ServerTimeout", 0))

         AETitle = Convert.ToString(settings.GetValue("ClientAE"))
         disableLogging = Convert.ToBoolean(settings.GetValue("DisableLogging"))
         GroupLengthDataElements = Convert.ToBoolean(settings.GetValue("GroupLengthDataElements", False))


         _presentationContextType = Convert.ToInt32(settings.GetValue("PresentationContextType"))
         _cstoreCompressionType = CType(System.Enum.Parse(GetType(DicomImageCompressionType), Convert.ToString(settings.GetValue("Compression"))), DicomImageCompressionType)

         If cstore IsNot Nothing Then
            cstore.PresentationContextType = _presentationContextType
            cstore.Compression = _cstoreCompressionType
         End If

      End Sub

      Private Sub SaveSettings()
         Dim user As RegistryKey = Registry.CurrentUser
         Dim settings As RegistryKey = user.OpenSubKey(_settingsLocation, True)

         If settings Is Nothing Then
            settings = user.CreateSubKey(_settingsLocation)
         End If

         settings.SetValue("UseTls", _useTls)

         settings.SetValue("ServerAE", server.AETitle)
         settings.SetValue("ServerPort", server.Port)
         settings.SetValue("ServerAddress", server.Address.ToString())
         settings.SetValue("ServerIpType", server.IpType)
         settings.SetValue("Compression", cstore.Compression)
         settings.SetValue("ServerTimeout", server.Timeout)
         settings.SetValue("ClientAE", AETitle)
         settings.SetValue("PresentationContextType", cstore.PresentationContextType)

         settings.SetValue("DisableLogging", disableLogging)
#If LEADTOOLS_V19_OR_LATER Then
         settings.SetValue("GroupLengthDataElements", GroupLengthDataElements)
#End If
         settings.Close()

         DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
      End Sub

      Private Sub SetCipherSuites(ByVal scu As DicomNet)
         ' Zero out the CipherSuite list
         scu.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.None)

         ' Add the new CipherSuites in order of priority
         Dim cipherCount As Integer = 0
         For Each cipherSuiteItem As CipherSuiteItem In _mySettings.CipherSuites.ItemList
            If cipherSuiteItem.IsChecked Then
               scu.SetTlsCipherSuiteByIndex(cipherCount, cipherSuiteItem.Cipher)
               cipherCount += 1
            End If
         Next cipherSuiteItem
      End Sub

      Private Sub UpdateCStoreOptions()
#If LEADTOOLS_V19_OR_LATER Then
         cstore.Flags = DicomNetFlags.None
         If GroupLengthDataElements Then
            cstore.Flags = cstore.Flags Or DicomNetFlags.SendDataWithGroupLengthStandardDataElements
         End If

         If cstore.IsSecureTLS Then
            SetCipherSuites(cstore)
         End If
#End If
      End Sub

      Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
         'cstore.Shutdown();
      End Sub

      Private Sub menuItemClearLog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemClearLog.Click
         Log.Clear()
      End Sub

      Private Sub menuItemAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemHelp.Click, menuItemAbout.Click
#If LEADTOOLS_V19_OR_LATER Then
         Using aboutDialog As New AboutDialog("Dicom Storage SCU", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
#Else
         Using aboutDialog As New AboutDialog("Dicom Storage SCU")
	         aboutDialog.ShowDialog(Me)
         End Using
#End If
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
         If Not cstore Is Nothing AndAlso cstore.IsConnected() Then
            cstore.Terminate()
         End If
      End Sub
   End Class
End Namespace
