Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Codecs

Partial Public Class KeyPanel
   Inherits WizardStep

   Private iv As ImageViewer
   Private fileImage As RasterImage
   Private twainImage As RasterImage

   Public ReadOnly Property IsKeySelected As Boolean
      Get
         Return chkUseKey.Checked
      End Get
   End Property

   Public ReadOnly Property AnswerImage As RasterImage
      Get
         Return iv.Image
      End Get
   End Property

   Public ReadOnly Property AnswerImagePath As String
      Get
         Return If(rdBtnFile.Checked, txtFilePath.Text, txtScanPath.Text)
      End Get
   End Property

   Public ReadOnly Property PassingGrade As Integer
      Get
         Return CInt(nudPassingGrade.Value)
      End Get
   End Property

   Private requiredPageCount As Integer

   Public Sub New(ByVal isAnswerPresent As Boolean, ByVal requiredPages As Integer)
      InitializeComponent()
      iv = New ImageViewer()
      iv.Dock = DockStyle.Fill
      iv.AutoDisposeImages = False
      AddHandler iv.ItemChanged, AddressOf Riv_ItemChanged
      pnlThumbnail.Controls.Add(iv)
      rdBtnFile.Checked = True
      Me.requiredPageCount = requiredPages
      Me.Title = "Choose an Answer Key"
   End Sub

   Private Sub Riv_ItemChanged(ByVal sender As Object, ByVal e As ImageViewerItemChangedEventArgs)
      If e.Reason = ImageViewerItemChangedReason.Image Then
         iv.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty)
      End If

      OnCanProceed()
   End Sub

   Protected Overrides Sub OnCanProceed()
      OnCanProceed(chkUseKey.Checked = False OrElse (chkUseKey.Checked AndAlso iv.Image IsNot Nothing))
   End Sub

   Private Sub rdBtnToggled(ByVal sender As Object, ByVal e As EventArgs)
      Try

         If rdBtnFile.Checked Then
            iv.Image = fileImage
         End If

         If rdbtnTwain.Checked Then
            iv.Image = twainImage
         End If

      Catch __unusedException1__ As Exception
         iv.Image = Nothing
      End Try

      txtFilePath.Enabled = rdBtnFile.Checked
      btnBrowse.Enabled = rdBtnFile.Checked
      btnScan.Enabled = rdbtnTwain.Checked
      txtScanPath.Enabled = rdbtnTwain.Checked
   End Sub

   Private Sub btnImageFileBrowse_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim image As RasterImage = Nothing
      Dim path As String = String.Empty
      Dim loaded As Boolean = MainForm.LoadRasterImage(image, path, True)

      If loaded Then

         If image.PageCount <> requiredPageCount Then
            MessageBox.Show(String.Format("This file contains {0} pages, but the template requires {1}.", image.PageCount, requiredPageCount))
            Return
         End If

         txtFilePath.Text = path
         fileImage = image
         iv.Image = image
      End If
   End Sub

   Private Sub chkUseKey_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      OnCanProceed()
      rdBtnFile.Enabled = chkUseKey.Checked
      txtFilePath.Enabled = rdBtnFile.Checked AndAlso chkUseKey.Checked
      btnBrowse.Enabled = rdBtnFile.Checked AndAlso chkUseKey.Checked
      rdbtnTwain.Enabled = chkUseKey.Checked
      btnScan.Enabled = rdbtnTwain.Checked AndAlso chkUseKey.Checked
      nudPassingGrade.Enabled = chkUseKey.Checked
      lblPassingGrade.Enabled = chkUseKey.Checked
   End Sub

   Private Sub btnScan_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim path As String = Nothing

      If MainForm.GetFromTwain(path) Then
         twainImage = MainForm.LoadImage(path, False)

         If twainImage IsNot Nothing Then
            iv.Image = twainImage
            txtScanPath.Text = path
         End If
      End If
   End Sub
End Class
