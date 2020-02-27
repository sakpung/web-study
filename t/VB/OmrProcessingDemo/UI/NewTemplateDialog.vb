Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Forms.Processing.Omr
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Partial Public Class NewTemplateDialog
   Inherits Form

   Private _iv As ImageViewer
   Private _loadedImage As RasterImage
   Private _twainImage As RasterImage

   Public ReadOnly Property LoadedImage As RasterImage
      Get
         Return _iv.Image
      End Get
   End Property

   Public ReadOnly Property TemplateName As String
      Get
         Return txtTemplateName.Text
      End Get
   End Property

   Public ReadOnly Property FileName As String
      Get
         Return txtFilePath.Text
      End Get
   End Property

   Public Sub New()
      InitializeComponent()
      _iv = New ImageViewer()
      _iv.Dock = DockStyle.Fill
      _iv.AutoDisposeImages = False
      AddHandler _iv.ItemChanged, AddressOf Riv_ItemChanged
      pnlThumbnail.Controls.Add(_iv)
      rdBtnFile.Checked = True
      txtTemplateName.Text = "New Template"
      txtTemplateName.Focus()
      txtTemplateName.SelectAll()
   End Sub

   Public Sub New(ByVal currentPageCount As Integer)
      Me.New()
      Me.Text = "Add new page"
      Me.lblDescription.Text = "Page Name:"
      txtTemplateName.Text = String.Format("Page {0}", currentPageCount + 1)
      txtTemplateName.Focus()
      txtTemplateName.SelectAll()
      txtTemplateName.Visible = False
      lblDescription.Text = "Choose a single page or multipage file to append new pages to this template."
   End Sub

   Public Sub New(ByVal v As String)
      Me.New()
      txtFilePath.Text = v
   End Sub

   Private Sub rdBtnToggled(ByVal sender As Object, ByVal e As EventArgs)
      grpLoad.Enabled = rdBtnFile.Checked
      grpTwain.Enabled = rdbtnTwain.Checked
      rdBtnFile.Checked = Not rdbtnTwain.Checked

      If rdbtnTwain.Checked Then
         _iv.Image = _twainImage
      ElseIf rdBtnFile.Checked Then
         _iv.Image = _loadedImage
      End If
   End Sub

   Private Sub btnBrowse_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim filenameVal As String = String.Empty
      Dim loaded As Boolean = MainForm.LoadRasterImage(_loadedImage, filenameVal, True)

      If loaded Then
         txtFilePath.Text = filenameVal
         _iv.Image = _loadedImage
         lblPageIndex.Visible = True
         AdvanceToPage(0)
      End If
   End Sub

   Private Sub AdvanceToPage(ByVal dir As Integer)
      _iv.Image.Page += dir
      lblPageIndex.Text = String.Format("Page {0} of {1}", _iv.Image.Page, _iv.Image.PageCount)
      btnNextPage.Enabled = _iv.Image.Page < _iv.Image.PageCount
      btnPreviousPage.Enabled = _iv.Image.Page > 1
   End Sub

   Private Sub Riv_ItemChanged(ByVal sender As Object, ByVal e As ImageViewerItemChangedEventArgs)
      If e.Reason = ImageViewerItemChangedReason.Image Then
         _iv.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty)
      End If

      CheckToProceed()
   End Sub

   Private Sub CheckToProceed()
      BtnOK.Enabled = String.IsNullOrWhiteSpace(txtTemplateName.Text) = False AndAlso _iv.Image IsNot Nothing
   End Sub

   Private Sub GetNewImageDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      If rdbtnTwain.Checked Then
         txtFilePath.Text = ""
      End If
   End Sub

   Private Sub btnScan_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim path As String = Nothing

      If MainForm.GetFromTwain(path) Then
         _twainImage = MainForm.LoadImage(path, False)

         If _twainImage IsNot Nothing Then
            _iv.Image = _twainImage
            txtScanPath.Text = path
         End If
      End If
   End Sub

   Private Sub txtTemplateName_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
      CheckToProceed()
   End Sub

   Private Sub btnNextPage_Click(ByVal sender As Object, ByVal e As EventArgs)
      AdvanceToPage(1)
   End Sub

   Private Sub btnPreviousPage_Click(ByVal sender As Object, ByVal e As EventArgs)
      AdvanceToPage(-1)
   End Sub
End Class
