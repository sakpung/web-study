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
Imports Leadtools.Demos
Imports Leadtools.Printer
Imports Leadtools.Codecs
Imports Leadtools
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Diagnostics
Imports Leadtools.Document.Writer
Imports System.Threading
Imports System.Runtime.InteropServices

Namespace ServerPrinterDemo.UI
   Partial Public Class FrmMain : Inherits Form

#Region "Main..."
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main(ByVal args As String())
         Try
            If Not Support.SetLicense() Then
               Return
            End If

            If args.Length > 0 Then
               FrmMain.StartedPrinter = args(0)

            End If

            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New FrmMain())
         Catch ex As Exception
         End Try
      End Sub

      Private Shared ReadOnly Property Is64() As Boolean
         Get
            Return IntPtr.Size = 8
         End Get
      End Property
#End Region

#Region "Fields..."
      Public Shared ReadOnly Property _strTittle() As String
         Get
            If (Is64()) Then
               Return "LEADTOOLS VB Printer Server Demo 64-bit"
            Else
               Return "LEADTOOLS VB Printer Server Demo 32-bit"
            End If
         End Get
      End Property

      Private _printer As Printer
      Private Shared StartedPrinter As String = String.Empty
      Private bSelectedPrinter As Boolean = True
      Private _currentPrinterName As String = String.Empty
      Private _fontPath As String = String.Empty
      Private _codec As RasterCodecs
      Private _jobHolder As JobHolder
      Private _nIndex As Integer
      Private Delegate Sub UpdateListboxDelegate(ByVal nIndex As Integer, ByVal jobHolder As JobHolder)
      Private Delegate Sub EnableButtonDialog(ByVal control As Control, ByVal bEnable As Boolean)
#End Region

      Public Sub New()
         Try
            If InitClass() Then
               InitializeComponent()
            Else
               Close()
               Return
            End If

            Me.Text = _strTittle

            _codec = New RasterCodecs()

            _txtPrinterName.Text = _currentPrinterName

            Dim newGuid As String = Guid.NewGuid().ToString("N")
            _fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), newGuid)
            Directory.CreateDirectory(_fontPath)
         Catch Ex As Exception
            MessageBox.Show(Ex.Message, _strTittle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
         End Try
      End Sub

      Private Function InitClass() As Boolean
         If RasterSupport.IsLocked(RasterSupportType.PrintDriver) AndAlso RasterSupport.IsLocked(RasterSupportType.PrintDriverServer) Then
            Throw New Exception("Printer driver capability is required.")
         End If

         If FrmMain.StartedPrinter = String.Empty Then
            bSelectedPrinter = GetPrinterName(True)
            If (Not bSelectedPrinter) Then
               Return False
            End If

            SetCurrentPrinter()
         Else
            bSelectedPrinter = True
            _currentPrinterName = FrmMain.StartedPrinter
            SetCurrentPrinter()
         End If

         Return bSelectedPrinter
      End Function

      Private Function GetPrinterName(ByVal bShowInstall As Boolean) As Boolean
         Try
            Dim currentPrinterName As String = String.Empty

            If (Not bShowInstall) Then
               currentPrinterName = _currentPrinterName
            End If

            Dim frmGetPrinterName As FrmGetPrinterName = New FrmGetPrinterName(currentPrinterName)
            Dim dialogResult As DialogResult = frmGetPrinterName.ShowDialog()

            If dialogResult = dialogResult.OK Then
               If _currentPrinterName <> frmGetPrinterName.PrinterName AndAlso Not _lstBoxLog Is Nothing Then
                  _lstBoxLog.Items.Clear()
                  _btnOpen.Enabled = False
                  _btnShow.Enabled = False
                  _btnClear.Enabled = False
               End If

               _currentPrinterName = frmGetPrinterName.PrinterName

               Return True
            Else
               Return False
            End If
         Catch
            Return False
         End Try
      End Function

      Private Sub SetCurrentPrinter()
         Try
            If Not _printer Is Nothing Then
               RemoveHandler _printer.EmfEvent, AddressOf _printer_EmfEvent

               RemoveHandler _printer.JobEvent, AddressOf _printer_JobEvent

               _printer.Dispose()
            End If

            _printer = New Printer(_currentPrinterName)

            AddHandler _printer.EmfEvent, AddressOf _printer_EmfEvent

            AddHandler _printer.JobEvent, AddressOf _printer_JobEvent
         Catch Ex As Exception
            MessageBox.Show(Ex.Message, _strTittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End Sub

      Public Sub SetProgressState()
         Try
            If Not _jobHolder._jobData Is Nothing Then
               'Job has client custom data, we will use these data to perform the save
               _jobHolder._message = "( " & _jobHolder._jobData.IPAddress & " ) Job name " & _jobHolder._jobData.PrintJobName & " Job ID " & _jobHolder._jobData.JobID & " Page No: " & _jobHolder._tempFiles.Count.ToString()
            Else
               'Job does not have the additional data, we will save the job using the Job ID
               _jobHolder._message = "( No Extra Information ) JobID " & _jobHolder._jobID & " Page No: " & _jobHolder._tempFiles.Count.ToString()
            End If

            _lstBoxLog.Items(_nIndex) = _jobHolder
         Catch Ex As Exception
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End Sub

      Public Sub _printer_EmfEvent(ByVal sender As Object, ByVal e As EmfEventArgs)
         If _jobHolder Is Nothing Then
            Return
         End If

         Dim tempFile As String = Path.GetTempFileName()
         File.WriteAllBytes(tempFile, e.Stream.ToArray())

         SetProgressState()

         _jobHolder.AddEmf(tempFile)
      End Sub

      Public Sub _printer_JobEvent(ByVal sender As Object, ByVal e As JobEventArgs)
         If e.JobEventState = EventState.JobStart Then
            _btnCancel.Enabled = True
            _btnChange.Enabled = False

            Me.BringToFront()
            Me.Focus()

            Dim jobData As PrintJobData = _printer.RemoteData
            If Not _printer.RemoteData Is Nothing Then
               _jobHolder = New JobHolder(e.JobID, jobData.UserData, _codec, jobData, _fontPath)

               _jobHolder._message = "( " & _jobHolder._jobData.IPAddress & " ) Job name " & jobData.PrintJobName & " Job ID " & jobData.JobID

               _nIndex = _lstBoxLog.Items.Add(_jobHolder)
            Else
               _jobHolder = New JobHolder(e.JobID, _codec, _fontPath)

               _jobHolder._message = "Job Received With No Extra Information ( Job ID  " & e.JobID & " )"
               _nIndex = _lstBoxLog.Items.Add(_jobHolder)

            End If
         ElseIf e.JobEventState = EventState.JobEnd Then
            Dim tmpHolder As JobHolder = Nothing
            Dim i As Integer = 0
            Do While i < _lstBoxLog.Items.Count
               If Not _lstBoxLog.Items(i).GetType() Is GetType(JobHolder) Then
                  Continue Do
               End If

               tmpHolder = CType(_lstBoxLog.Items(i), JobHolder)
               If tmpHolder._jobID = e.JobID Then
                  _jobHolder = tmpHolder
                  Exit Do
               End If
               i += 1
            Loop

            If Not _jobHolder Is Nothing Then
               _btnCancel.Enabled = False
               Me.BringToFront()
               Me.Focus()

               Dim strMessage As String = ""

               'Check if Job has client custom data
               If Not _jobHolder._jobData Is Nothing Then
                  strMessage = "( " & _jobHolder._jobData.IPAddress & " ) Saving " & _jobHolder._format & " file, please wait ... "
               Else
                  strMessage = "( No Extra Information ) Saving " & _jobHolder._format & " file, please wait ... "
               End If

               _jobHolder._message = strMessage
               _lstBoxLog.Items(_nIndex) = _jobHolder

               'Get embedded fonts related to the Job ID
               Dim arrFonts As String() = _printer.GetEmbeddedFonts(_jobHolder._fontPath, e.JobID)
               _jobHolder.SetFonts(arrFonts)

               'Save on a different thread
               Dim pStart As ParameterizedThreadStart = New ParameterizedThreadStart(AddressOf DoSave)
               Dim tSaving As Thread = New Thread(pStart)
               tSaving.Start(New Object() {_jobHolder, _nIndex})
               _jobHolder = Nothing
            End If
         End If
      End Sub

      Private Sub EnableButton(ByVal control As Control, ByVal bEnable As Boolean)
         If control.InvokeRequired Then
            Dim d As EnableButtonDialog = New EnableButtonDialog(AddressOf EnableButton)
            Me.Invoke(d, New Object() {control, bEnable})
         Else
            control.Enabled = bEnable
         End If
      End Sub

      Private Sub UpdateListbox(ByVal nIndex As Integer, ByVal jobHolder As JobHolder)
         If _lstBoxLog.InvokeRequired Then
            Dim d As UpdateListboxDelegate = New UpdateListboxDelegate(AddressOf UpdateListbox)
            Me.Invoke(d, New Object() {nIndex, jobHolder})
         Else
            Me._lstBoxLog.Items(nIndex) = jobHolder
         End If
      End Sub

      Private Sub DoSave(ByVal data As Object)
         Try
            Dim objects As Object() = CType(data, Object())
            Dim jobHolder As JobHolder = CType(objects(0), JobHolder)
            Dim nIndex As Integer = CInt(objects(1))

            jobHolder.Save()

            jobHolder.UninstallFonts()
            jobHolder.DeleteFonts()
            jobHolder.ClearFiles()

            EnableButton(_btnChange, True)
            EnableButton(_btnClear, True)

            'Check if Job has client custom data
            If Not jobHolder._jobData Is Nothing Then
               jobHolder._message = "( " & jobHolder._jobData.IPAddress & " )File saved to: " & jobHolder._fileSaved
            Else
               jobHolder._message = "( No Extra Information )File saved to: " & jobHolder._fileSaved
            End If

            UpdateListbox(nIndex, jobHolder)

         Catch Ex As Exception
            MessageBox.Show(Ex.Message, FrmMain._strTittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try

      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         _printer.CancelPrintedJob(_jobHolder._jobID)
      End Sub

      Private Sub _btnChange_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnChange.Click
         Me.Hide()

         RemoveHandler _printer.EmfEvent, AddressOf _printer_EmfEvent
         RemoveHandler _printer.JobEvent, AddressOf _printer_JobEvent
         _printer.Dispose()
         _printer = Nothing

         GetPrinterName(False)
         SetCurrentPrinter()

         _txtPrinterName.Text = _currentPrinterName
         Me.Show()
      End Sub

      Private Sub _lstBoxLog_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _lstBoxLog.SelectedIndexChanged
         If _lstBoxLog.SelectedItem Is Nothing OrElse Not _lstBoxLog.SelectedItem.GetType() Is GetType(JobHolder) Then
            _btnShow.Enabled = False
            _btnOpen.Enabled = False
            Return
         End If

         Dim jobHolder As JobHolder = CType(_lstBoxLog.SelectedItem, JobHolder)
         If Not jobHolder Is Nothing Then
            _btnShow.Enabled = jobHolder._saved AndAlso Directory.Exists(Path.GetDirectoryName(jobHolder._fileSaved))
            _btnOpen.Enabled = jobHolder._saved AndAlso File.Exists(jobHolder._fileSaved)
            _btnOpen.Tag = jobHolder
            _btnShow.Tag = jobHolder
         End If
      End Sub

      Private Sub _btnOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOpen.Click
         Dim jobHolder As JobHolder = CType(_btnOpen.Tag, JobHolder)

         If Not jobHolder Is Nothing AndAlso jobHolder._saved Then
            If (Not File.Exists(jobHolder._fileSaved)) Then
               MessageBox.Show("File not found.", FrmMain._strTittle, MessageBoxButtons.OK, MessageBoxIcon.Information)
               _btnOpen.Enabled = False
               Return
            End If

            Try
               Process.Start(jobHolder._fileSaved)
            Catch ex As System.Exception
               MessageBox.Show(ex.Message, FrmMain._strTittle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
         End If
      End Sub

      Private Sub _btnShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnShow.Click
         Dim jobHolder As JobHolder = CType(_btnShow.Tag, JobHolder)

         If Not jobHolder Is Nothing AndAlso jobHolder._saved Then
            Process.Start(Path.GetDirectoryName(jobHolder._fileSaved))
         End If
      End Sub

      Private Sub _btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnClear.Click
         _lstBoxLog.Items.Clear()
         _btnShow.Enabled = False
         _btnOpen.Enabled = False
         _btnClear.Enabled = False

      End Sub

      Private Sub FrmMain_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
         Me.Focus()
         Me.BringToFront()
      End Sub

      Private Function CanClose() As Boolean
         Dim bCanClose As Boolean = True
         For Each item As Object In _lstBoxLog.Items
            If Not item.GetType() Is GetType(JobHolder) Then
               Continue For
            End If

            Dim holder As JobHolder = CType(item, JobHolder)
            If holder._saving Then
               bCanClose = False
               Exit For
            End If
         Next item
         Return bCanClose
      End Function

      Private Sub FrmMain_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing


         If (Not CanClose()) Then
            MessageBox.Show("Application cant close while saving, try to close the application later", _strTittle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
         Else

            'Dispose of printer before closing
            RemoveHandler _printer.EmfEvent, AddressOf _printer_EmfEvent

            RemoveHandler _printer.JobEvent, AddressOf _printer_JobEvent

            _printer.Dispose()

            Try
               If (Directory.Exists(_fontPath)) Then
                  Directory.Delete(_fontPath, True)
               End If
            Catch ex As Exception
               ' Do Nothing
            End Try

         End If
      End Sub

      Private Sub _btnReadMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnReadMe.Click
         Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + "\\ServerDemoReadMe.txt")
      End Sub
   End Class

   Friend Class JobHolder
      Public _jobID As Integer
      Public _tempFiles As List(Of String) = New List(Of String)()
      Public _fontNames As List(Of String) = New List(Of String)()

      Public _format As String
      Public _savename As String
      Public _message As String
      Public _fileSaved As String
      Public _saving As Boolean
      Public _fontPath As String

      Public _jobData As PrintJobData
      Private _codec As RasterCodecs
      Public _saved As Boolean

      <DllImport("gdi32")> _
      Public Shared Function AddFontResource(ByVal lpFileName As String) As Integer
      End Function

      <DllImport("gdi32")> _
      Public Shared Function RemoveFontResource(ByVal lpFileName As String) As Integer
      End Function

      Public Sub New(ByVal jobID As Integer, ByVal codec As RasterCodecs, ByVal fontPath As String)
         _jobID = jobID
         _codec = codec
         _saving = False
         _saved = False

         _format = "pdf"
         _savename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Job ID " & jobID
         _fontPath = fontPath
      End Sub

      Public Sub New(ByVal jobID As Integer, ByVal bytes As Byte(), ByVal codec As RasterCodecs, ByVal jobData As PrintJobData, ByVal fontPath As String)
         _jobID = jobID
         _codec = codec
         _jobData = jobData
         _saving = False

         Dim [unicode] As Encoding = Encoding.Unicode

         Dim strBytes As String = [unicode].GetString(bytes)
         Dim nIndex As Integer
         nIndex = strBytes.IndexOf("---")
         _saved = False

         _format = strBytes.Substring(0, nIndex)
         strBytes = strBytes.Substring(nIndex + 3)
         _savename = strBytes
         _fontPath = fontPath
      End Sub


      Public Sub ClearFiles()
         For Each str As String In _tempFiles
            If File.Exists(str) Then
               File.Delete(str)
            End If
         Next str
      End Sub

      Public Sub AddEmf(ByVal file As String)
         _tempFiles.Add(file)
      End Sub

      Public Sub SetFonts(ByVal fonts As String())
         If Not fonts Is Nothing Then
            _fontNames.AddRange(fonts)
         End If
      End Sub

      Public Sub InstallFonts()
         For Each strFont As String In _fontNames
            AddFontResource(_fontPath & "\" & strFont)
         Next strFont
      End Sub

      Public Sub UninstallFonts()
         For Each strFont As String In _fontNames
            RemoveFontResource(_fontPath & "\" & strFont)
         Next strFont
      End Sub

      Public Sub DeleteFonts()
         For Each strFont As String In _fontNames
            Try
               File.Delete(_fontPath & "\" & strFont)
            Catch ex As Exception
               ' Do Nothing
            End Try
         Next strFont
      End Sub

      Public Sub Save()
         Try
            _saving = True
            If _tempFiles.Count = 0 Then
               MessageBox.Show("No pages where printed.", FrmMain._strTittle, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Return
            End If

            Application.DoEvents()
            Dim strName As String = _savename
            Dim documentFormat As DocumentFormat = documentFormat.User
            Dim documentOptions As DocumentOptions = Nothing
            Dim PdfdocumentOptions As PdfDocumentOptions = New PdfDocumentOptions()

            InstallFonts()

            Dim strExt As String = ""

            If _format.ToLower() = "pdf" Then
               documentFormat = documentFormat.Pdf
               documentOptions = New PdfDocumentOptions()
               CType(IIf(TypeOf documentOptions Is PdfDocumentOptions, documentOptions, Nothing), PdfDocumentOptions).DocumentType = PdfDocumentType.Pdf
               CType(IIf(TypeOf documentOptions Is PdfDocumentOptions, documentOptions, Nothing), PdfDocumentOptions).FontEmbedMode = DocumentFontEmbedMode.Auto
               strExt = "pdf"
            End If

            If _format.ToLower() = "doc" Then
               documentFormat = documentFormat.Doc
               documentOptions = New DocDocumentOptions()
               CType(IIf(TypeOf documentOptions Is DocDocumentOptions, documentOptions, Nothing), DocDocumentOptions).TextMode = DocumentTextMode.Framed
               strExt = "doc"
            End If

            If _format.ToLower() = "xps" Then
               documentFormat = documentFormat.Xps
               documentOptions = New XpsDocumentOptions()
               strExt = "xps"
            End If

            If _format.ToLower() = "text" Then
               documentFormat = documentFormat.Text
               documentOptions = New TextDocumentOptions()
               strExt = "txt"
            End If

            If (Not strName.Contains("." & strExt.ToLower())) Then
               strName &= "." & strExt.ToLower()
            End If

            If Not _jobData Is Nothing Then
               strName = Path.GetDirectoryName(strName) & "\(" & _jobData.IPAddress & ") " & Path.GetFileName(strName)
            End If


            _fileSaved = strName

            Dim documentWriter As DocumentWriter = New DocumentWriter()
            documentWriter.SetOptions(documentFormat, documentOptions)
            documentWriter.BeginDocument(strName, documentFormat)

            For Each strFile As String In _tempFiles
#If LEADTOOLS_V175_OR_LATER Then
               Dim documentPage As DocumentWriterEmfPage = New DocumentWriterEmfPage()
#Else
               Dim documentPage As DocumentPage = documentPage.Empty
#End If
               Dim metaFile As Metafile = New Metafile(strFile)

               documentPage.EmfHandle = metaFile.GetHenhmetafile()

               documentWriter.AddPage(documentPage)

               metaFile.Dispose()
               metaFile = New Metafile(documentPage.EmfHandle, True)
               metaFile.Dispose()

            Next strFile
            documentWriter.EndDocument()

            _saved = True
            _saving = False
         Catch Ex As Exception
            _saving = False
            MessageBox.Show(Ex.Message, FrmMain._strTittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End Sub

      Public Overrides Function ToString() As String
         Return _message
      End Function

   End Class
End Namespace
