' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Microsoft.VisualBasic
Imports Leadtools
Imports Leadtools.MediaWriter
Imports System.Threading

Namespace MediaWriterDemo
   Partial Public Class MainForm : Inherits Form
      Public Sub New()
         InitializeComponent()
      End Sub

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
       Shared Sub Main()
#If LEADTOOLS_V175_OR_LATER Then
         If Not Support.SetLicense() Then
            Return
         End If
#Else
         Support.Unlock(False)
#End If
         

         If RasterSupport.IsLocked(RasterSupportType.MediaWriter) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.MediaWriter.ToString()), "Warning")
            Return
         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainForm())
      End Sub

      Private gLMediaWriter As MediaWriter
      Private gBurnerDrive As MediaWriterDrive

      Private Function CheckInputPath(ByVal sInputPath As String) As Boolean
         Dim attr As FileAttributes
         Try
            attr = File.GetAttributes(sInputPath)
         Catch
            MessageBox.Show("The specified file or folder does not exist. Please select valid file or folder.", "Warning", MessageBoxButtons.OK)
            Return False
         End Try
         If (attr And FileAttributes.Directory) = FileAttributes.Directory Then
            Try
               If Directory.GetFiles(sInputPath, "*", SearchOption.AllDirectories).Length < 1 Then
                  MessageBox.Show("The specified folder does not contain any files or folders. Please select another folder.", "Warning", MessageBoxButtons.OK)
                  Return False
               End If
            Catch ex As Exception
               MessageBox.Show("An error was encountered while checking the specified folder. Please check your folder and try again.  Error details:" & Constants.vbLf + Constants.vbLf + ex.Message, "Warning", MessageBoxButtons.OK)
               Return False
            End Try
         End If
         Return True
      End Function

      Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         gLMediaWriter = New MediaWriter()

         progressBar1.Minimum = 0
         progressBar1.Maximum = 10000

         BuildDriveList()
         BuildWriteSpeedList()
         gBurnerDrive = gLMediaWriter.CurrentDrive

         _txtVolumeName.Text = "LEAD-IMAGES"
         _txtInputPath.Text = "C:\InputFiles"
         _chkAutoEject.Checked = gBurnerDrive.AutoEject
         _chkReserveCDTrackOnWriting.Checked = gBurnerDrive.ReserveCDTrackOnWriting

         EnableCtrls()
      End Sub

      Private Sub _btnBrosweISOFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnBrowseISOFile.Click
         Try
            Dim ofd As OpenFileDialog = New OpenFileDialog()

            ofd.Title = "Choose ISO File"
            ofd.Filter = "ISO Files (*.iso)|*.iso|" & "All Files (*.*)|*.*"

            If ofd.ShowDialog() = DialogResult.OK Then
               _txtInputPath.Text = ofd.FileName
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
         EnableCtrls()
      End Sub

      Private Sub _btnBrowseDVDFolder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnBrowseDVDFolder.Click
         Try
            Dim fbd As FolderBrowserDialog = New FolderBrowserDialog()

            If fbd.ShowDialog() = DialogResult.OK Then
               _txtInputPath.Text = fbd.SelectedPath
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
         EnableCtrls()
      End Sub

      Private Sub _btnBrowseISOOutputFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnBrowseISOOutputFile.Click
         Try
            Dim sfd As SaveFileDialog = New SaveFileDialog()

            sfd.Title = "Choose ISO File"
            sfd.Filter = "ISO Files (*.iso)|*.iso|" & "All Files (*.*)|*.*"

            If sfd.ShowDialog() = DialogResult.OK Then
               _cmbDrive.SelectedIndex = 0
               _txtISOOutput.Text = sfd.FileName
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
         EnableCtrls()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
         Try
            If gBurnerDrive.State <> MediaWriterState.StateIdle Then
               If MessageBox.Show("A disc operation is currently in progress. Are you sure you would like to cancel?", "Warning", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                  Return
               End If

               gBurnerDrive.Cancel()
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
         EnableCtrls()
      End Sub

      Private Sub _btnEject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnEject.Click
         _lblProgress.Text = ""
         progressBar1.Value = 0

         Try
            gBurnerDrive.EjectDisc()
         Catch ex As Exception
            MessageBox.Show(ex.Message & " occurred while ejecting. Operation canceled.")
         End Try
         EnableCtrls()
      End Sub

      Private Sub _btnErase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnErase.Click
         _lblProgress.Text = ""
         progressBar1.Value = 0

         Try
            gBurnerDrive.EraseDisc()
            EnableCtrls()
            Do While gBurnerDrive.State = MediaWriterState.StateErasing
               Application.DoEvents()
            Loop
         Catch ex As Exception
            MessageBox.Show(ex.Message & " occurred while starting erase. Operation canceled.")
         End Try
         EnableCtrls()
      End Sub

      Private Sub _btnTest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnTest.Click
         Dim testDisc As MediaWriterDisc = gBurnerDrive.CreateDisc()

         _lblProgress.Text = ""
         progressBar1.Value = 0

         Try
            If (Not CheckInputPath(_txtInputPath.Text)) Then
               Return
            End If

            testDisc.SourcePathName = _txtInputPath.Text
            testDisc.OutputPathName = _txtISOOutput.Text
            testDisc.VolumeName = _txtVolumeName.Text
         Catch ex As Exception
            MessageBox.Show(ex.Message & " occurred while setting the source. Operation canceled.")
            EnableCtrls()
            Return
         End Try

         Try
            gBurnerDrive.TestBurnDisc(testDisc)
            EnableCtrls()
            Do While gBurnerDrive.State = MediaWriterState.StateTestWriting
               Application.DoEvents()
            Loop

         Catch ex As Exception
            MessageBox.Show(ex.Message & " occurred while starting write. Operation canceled.")
         End Try
         EnableCtrls()
      End Sub

      Private Sub _btnWrite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnWrite.Click
         Dim burnDisc As MediaWriterDisc = gBurnerDrive.CreateDisc()
         progressBar1.Value = 0

         Try
            If (Not CheckInputPath(_txtInputPath.Text)) Then
               Return
            End If
            burnDisc.SourcePathName = _txtInputPath.Text
            burnDisc.VolumeName = _txtVolumeName.Text
         Catch ex As Exception
            MessageBox.Show(ex.Message & " occurred while setting the source. Operation canceled.")
            EnableCtrls()
            Return
         End Try

         Try
            If String.Empty <> _txtISOOutput.Text Then
               burnDisc.OutputPathName = _txtISOOutput.Text
               gBurnerDrive.CreateISO(burnDisc)
            Else
               gBurnerDrive.BurnDisc(burnDisc)
            End If
            EnableCtrls()
            Do While gBurnerDrive.State = MediaWriterState.StateWriting
               Application.DoEvents()
            Loop

         Catch ex As Exception
            MessageBox.Show(ex.Message & " occurred while starting write. Operation canceled.")
         End Try
         EnableCtrls()
      End Sub

      Private Sub _chkAutoEject_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _chkAutoEject.CheckedChanged
         Try
            gBurnerDrive.AutoEject = _chkAutoEject.Checked
         Catch ex As Exception
            _chkAutoEject.Checked = gBurnerDrive.AutoEject
            MessageBox.Show(ex.Message & " occurred while setting auto eject. Operation canceled.")
         End Try
      End Sub

      Public Sub UpdateProgress(ByVal sender As Object, ByVal evtargs As EventArgs)
         Dim mevtargs As MediaWriterProgressEventArgs = CType(IIf(TypeOf evtargs Is MediaWriterProgressEventArgs, evtargs, Nothing), MediaWriterProgressEventArgs)
         If Not Nothing Is mevtargs Then
            progressBar1.Value = mevtargs.Complete
            _lblProgress.Text = mevtargs.Description
         End If
      End Sub

      Private Sub gBurnerDrive_OnProgress(ByVal sender As Object, ByVal e As MediaWriterProgressEventArgs)
         If Me.InvokeRequired Then
            Me.Invoke(New EventHandler(AddressOf UpdateProgress), New Object() {sender, e})
         Else
            UpdateProgress(sender, e)
         End If
      End Sub

      Private Sub UpdateDeviceEvent(ByVal sender As Object, ByVal evtargs As EventArgs)
         Dim mevtargs As MediaWriterDevNotifyEventArgs = CType(IIf(TypeOf evtargs Is MediaWriterDevNotifyEventArgs, evtargs, Nothing), MediaWriterDevNotifyEventArgs)
         If Not Nothing Is mevtargs Then
            If mevtargs.State = MediaWriterDeviceState.StateLoaded Then
               ' new disc was inserted in current drive
            Else
               If mevtargs.State = MediaWriterDeviceState.StateEmpty Then
                  ' disc was ejected from current drive
               Else
                  If mevtargs.State = MediaWriterDeviceState.StateUnknown Then
                     ' disc was ejected from current drive
                     BuildWriteSpeedList()
                  End If
               End If
            End If
            EnableCtrls()
         End If
      End Sub

      Private Sub gBurnerDrive_OnDeviceEvent(ByVal sender As Object, ByVal e As MediaWriterDevNotifyEventArgs)
         If Me.InvokeRequired Then
            Me.Invoke(New EventHandler(AddressOf UpdateDeviceEvent), New Object() {sender, e})
         Else
            UpdateDeviceEvent(sender, e)
         End If
      End Sub

      Private Sub _cmbDrive_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbDrive.SelectedIndexChanged
         Dim lCurrent As Integer = gLMediaWriter.CurrentDriveNumber
         If Not gBurnerDrive Is Nothing AndAlso gBurnerDrive.State <> MediaWriterState.StateIdle Then
            Return
         End If

         Try
            gLMediaWriter.CurrentDriveNumber = _cmbDrive.SelectedIndex - 1
            If Not gBurnerDrive Is Nothing Then
               RemoveHandler gBurnerDrive.OnProgress, AddressOf gBurnerDrive_OnProgress
               RemoveHandler gBurnerDrive.OnDeviceEvent, AddressOf gBurnerDrive_OnDeviceEvent
            End If

            gBurnerDrive = gLMediaWriter.CurrentDrive
            AddHandler gBurnerDrive.OnProgress, AddressOf gBurnerDrive_OnProgress
            AddHandler gBurnerDrive.OnDeviceEvent, AddressOf gBurnerDrive_OnDeviceEvent

            BuildWriteSpeedList()

            If _cmbDrive.SelectedIndex > 0 Then
               _txtISOOutput.Text = String.Empty
            End If

            _lblProgress.Text = ""
            progressBar1.Value = 0
         Catch ex As Exception
            _cmbDrive.SelectedIndex = lCurrent + 1
            BuildWriteSpeedList()
            MessageBox.Show(ex.Message & " occurred while selecting drive. Operation canceled.")
         End Try
         EnableCtrls()
      End Sub

      Private Sub _btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnLoad.Click
         _lblProgress.Text = ""
         progressBar1.Value = 0

         Try
            gBurnerDrive.LoadDisc()
            'Sleep to allow control to update with drive's status (open or closed)
            Thread.Sleep(2000)
         Catch ex As Exception
            MessageBox.Show(ex.Message & " occurred while loading. Operation canceled.")
         End Try
         EnableCtrls()
      End Sub

      Private Sub BuildDriveList()
         Try
            _cmbDrive.Items.Clear()
            For Each drive As MediaWriterDrive In gLMediaWriter.Drives
               _cmbDrive.Items.Add(drive.Name)
            Next drive
            _cmbDrive.SelectedIndex = gLMediaWriter.CurrentDriveNumber + 1
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub

      Private Sub BuildWriteSpeedList()
         Try
            _cmbSpeed.Items.Clear()

            If _cmbDrive.SelectedIndex <> 0 AndAlso Not gBurnerDrive Is Nothing AndAlso Not gBurnerDrive.Speeds Is Nothing Then
               For Each speed As MediaWriterSpeed In gBurnerDrive.Speeds
                  _cmbSpeed.Items.Add(speed.Name)
               Next speed

               If _cmbSpeed.Items.Count > 0 AndAlso gBurnerDrive.CurrentSpeedIndex < _cmbSpeed.Items.Count Then
                  _cmbSpeed.SelectedIndex = gBurnerDrive.CurrentSpeedIndex
               End If
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub

      Private Sub EnableCtrls()
         Dim bEraseable As Boolean
         Dim bWriteable As Boolean
         Dim bTestwriteable As Boolean
         Dim bEjectable As Boolean
         Dim bLoadable As Boolean
         Dim bIdle As Boolean
         Dim lDrive As Integer

         bIdle = (gBurnerDrive.State = MediaWriterState.StateIdle)
         bEraseable = gBurnerDrive.Eraseable
         bWriteable = gBurnerDrive.Writeable
         bTestwriteable = gBurnerDrive.TestWriteable
         bEjectable = gBurnerDrive.Ejectable
         bLoadable = gBurnerDrive.Loadable

         lDrive = gBurnerDrive.DriveNumber

         'if we have not specified a drive but have enabled an output iso file then enable write
         If lDrive < 0 AndAlso bIdle _
            AndAlso (Not String.IsNullOrEmpty(_txtISOOutput.Text)) Then
            Dim sPath As String = _txtISOOutput.Text
            sPath = Path.GetDirectoryName(sPath)
            If (Directory.Exists(sPath)) Then
               bWriteable = True
               bTestwriteable = True
            End If
         End If

         If bIdle AndAlso bWriteable Then
            _btnWrite.Enabled = True
         Else
            _btnWrite.Enabled = False
         End If
         If bIdle AndAlso bEraseable Then
            _btnErase.Enabled = True
         Else
            _btnErase.Enabled = False
         End If

         If bIdle Then
            _cmbDrive.Enabled = True
         Else
            _cmbDrive.Enabled = False
         End If

         If bIdle Then
            _txtVolumeName.Enabled = True
         Else
            _txtVolumeName.Enabled = False
         End If

         If bIdle AndAlso bEjectable Then
            _btnEject.Enabled = True
         Else
            _btnEject.Enabled = False
         End If
         If bIdle AndAlso bLoadable Then
            _btnLoad.Enabled = True
         Else
            _btnLoad.Enabled = False
         End If
         If bIdle Then
            _chkAutoEject.Enabled = True
         Else
            _chkAutoEject.Enabled = False
         End If
         If bIdle Then
            _btnBrowseDVDFolder.Enabled = True
         Else
            _btnBrowseDVDFolder.Enabled = False
         End If
         If bIdle Then
            _txtISOOutput.Enabled = True
         Else
            _txtISOOutput.Enabled = False
         End If
         If bIdle Then
            _btnBrowseISOOutputFile.Enabled = True
         Else
            _btnBrowseISOOutputFile.Enabled = False
         End If
         If bIdle Then
            _txtInputPath.Enabled = True
         Else
            _txtInputPath.Enabled = False
         End If
         If bIdle Then
            _btnBrowseISOFile.Enabled = True
         Else
            _btnBrowseISOFile.Enabled = False
         End If
         If bIdle AndAlso bTestwriteable Then
            _btnTest.Enabled = True
         Else
            _btnTest.Enabled = False
         End If
         If bIdle Then
            _cmbSpeed.Enabled = True
         Else
            _cmbSpeed.Enabled = False
         End If

         Dim bcd As Boolean = False
         If gBurnerDrive.CurrentDiscType IsNot Nothing Then
            bcd = gBurnerDrive.CurrentDiscType.Type = MediaWriterDiscTypeCode.DiscTypeCDR OrElse gBurnerDrive.CurrentDiscType.Type = MediaWriterDiscTypeCode.DiscTypeCDROM OrElse gBurnerDrive.CurrentDiscType.Type = MediaWriterDiscTypeCode.DiscTypeCDRW
         End If
         If bIdle And bcd Then
            _chkReserveCDTrackOnWriting.Enabled = True
         Else
            _chkReserveCDTrackOnWriting.Enabled = False
         End If

         Try
            If bIdle Then
               Dim lCapacity As Double
               Dim lbytes As Double
               Dim sText As String
               lCapacity = gBurnerDrive.DiscCapacity
               lbytes = lCapacity * 2048
               If lbytes >= &H40000000 Then
                  sText = Convert.ToString(lbytes / &H40000000)
                  If sText.Length > 5 Then
                     sText = Strings.Left(sText, 5) & " GB"
                  Else
                     If sText <> String.Empty Then
                        sText = sText & " GB"
                     End If
                  End If
               ElseIf lbytes >= &H100000 Then
                  sText = Convert.ToString(lbytes / &H100000)
                  If sText.Length > 4 Then
                     sText = Strings.Left(sText, 4) & " MB"
                  Else
                     If sText <> String.Empty Then
                        sText = sText & " MB"
                     End If
                  End If
               Else
                  sText = Convert.ToString(lbytes / &H400)
                  If sText.Length > 3 Then
                     sText = Strings.Left(sText, 3) & " KB"
                  Else
                     If sText <> String.Empty Then
                        sText = sText & " KB"
                     End If
                  End If
               End If
               _lblDiskCapacity.Text = sText
            End If
         Catch
            _lblDiskCapacity.Text = ""
         End Try

         If Not Nothing Is gBurnerDrive.CurrentDiscType Then
            _lblDiscType.Text = gBurnerDrive.CurrentDiscType.Name
         Else
            _lblDiscType.Text = String.Empty
         End If

      End Sub

      Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
         Try
            If gBurnerDrive.State <> MediaWriterState.StateIdle Then
               If MessageBox.Show("A disc operation is currently in progress. Are you sure you would like to exit?", "Warning", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                  e.Cancel = True
                  gBurnerDrive.Cancel()
                  Return
               End If
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub

      Private Sub _cmbSpeed_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbSpeed.SelectedIndexChanged
         If Not gBurnerDrive Is Nothing Then
            gBurnerDrive.CurrentSpeedIndex = _cmbSpeed.SelectedIndex
         End If
      End Sub

      Private Sub _txtISOOutput_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _txtISOOutput.TextChanged
         EnableCtrls()
      End Sub

      Private Sub _chkReserveCDTrackOnWriting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _chkReserveCDTrackOnWriting.CheckedChanged
         Try
            gBurnerDrive.ReserveCDTrackOnWriting = _chkReserveCDTrackOnWriting.Checked
         Catch ex As Exception
            _chkReserveCDTrackOnWriting.Checked = gBurnerDrive.ReserveCDTrackOnWriting
            MessageBox.Show(ex.Message & " occurred while setting reserve track on writing. Operation canceled.")
         End Try
      End Sub
   End Class
End Namespace
