Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Twain
Imports Leadtools.WinForms.CommonDialogs.File
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Partial Public Class TwainDialog
   Inherits Form

   Private _twnSession As TwainSession
   Private _format As RasterImageFormat = RasterImageFormat.Unknown

   Public ReadOnly Property SavedLocation As String
      Get
         Return txtSaveLocation.Text
      End Get
   End Property

   Public Sub New()
      InitializeComponent()
      btnScan.Enabled = False
      _twnSession = New TwainSession()
   End Sub

   Private Sub TwainDialog_Load(ByVal sender As Object, ByVal e As EventArgs)
      Try
         _twnSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
      Catch __unusedException1__ As Exception
         MessageBox.Show("An error occurred initializing TWAIN.")
         Me.Close()
      End Try
   End Sub

   Private Sub TwainDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      _twnSession.Shutdown()
   End Sub

   Private Sub btnScan_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim current As Cursor = Me.Cursor
      Me.Cursor = Cursors.WaitCursor
      Dim image As RasterImage = _twnSession.AcquireToImage(TwainUserInterfaceFlags.Show Or TwainUserInterfaceFlags.Modal)

      Using codecs As RasterCodecs = MainForm.GetRasterCodecs()
         codecs.Save(image, txtSaveLocation.Text, _format, 0)
      End Using

      image.Dispose()
      Me.Cursor = current
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub btnSelectSource_Click(ByVal sender As Object, ByVal e As EventArgs)
      If _twnSession.SelectSource(String.Empty) = DialogResult.OK Then
         txtSelectedSource.Text = _twnSession.SelectedSourceName()
      End If

      UpdateScanEnabled()
   End Sub

   Private Sub UpdateScanEnabled()
      btnScan.Enabled = String.IsNullOrWhiteSpace(txtSaveLocation.Text) = False AndAlso String.IsNullOrWhiteSpace(txtSelectedSource.Text) = False AndAlso _format <> RasterImageFormat.Unknown
   End Sub

   Private Sub btnChooseSaveLocation_Click(ByVal sender As Object, ByVal e As EventArgs)
      Using codecs As RasterCodecs = MainForm.GetRasterCodecs()
         Dim rsd As RasterSaveDialog = New RasterSaveDialog(codecs)
         rsd.FileFormatsList = New RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.[Default])
         rsd.ShowFormatSubType = False
         rsd.ShowBitsPerPixel = False
         rsd.Title = "Save scan..."

         If rsd.ShowDialog(Me) = DialogResult.OK Then
            txtSaveLocation.Text = rsd.FileName
            _format = rsd.Format
         End If

         UpdateScanEnabled()
      End Using
   End Sub
End Class
