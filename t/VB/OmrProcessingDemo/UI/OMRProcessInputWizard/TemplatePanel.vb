Imports Leadtools.Codecs
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.Forms.Processing.Omr
Imports System.IO
Imports Leadtools.Controls

Partial Public Class TemplatePanel
   Inherits WizardStep

   Private _iv As ImageViewer
   Private _templateImage As RasterImage
   Private _fileImage As RasterImage
   Private _templateEditorEngine As ITemplateForm
   Private _loadedEditorEngine As ITemplateForm

   Public ReadOnly Property LoadedEditor As ITemplateForm
      Get
         Return If(rdbtnTemplate.Checked, _templateEditorEngine, _loadedEditorEngine)
      End Get
   End Property

   Public ReadOnly Property LoadedImage As RasterImage
      Get
         Return _iv.Image
      End Get
   End Property

   Public Sub New()
      InitializeComponent()
      _iv = New ImageViewer()
      _iv.Dock = DockStyle.Fill
      _iv.AutoDisposeImages = False
      AddHandler _iv.ItemChanged, AddressOf Riv_ItemChanged
      pnlThumbnail.Controls.Add(_iv)
   End Sub

   Public Sub New(ByVal defaultImage As RasterImage, ByVal currentEngine As ITemplateForm)
      _templateImage = defaultImage
      _templateEditorEngine = currentEngine

      If defaultImage IsNot Nothing Then
         rdbtnTemplate.Checked = True
      Else
         rdBtnFile.Checked = True
         rdbtnTemplate.Enabled = False
      End If
   End Sub

   Private Sub rdBtnToggled(ByVal sender As Object, ByVal e As EventArgs)
      Try

         If rdBtnFile.Checked Then
            _iv.Image = _fileImage
         End If

         If rdbtnTemplate.Checked Then
            _iv.Image = _templateImage
         End If

      Catch __unusedException1__ As Exception
         _iv.Image = Nothing
      End Try

      txtFilePath.Enabled = rdBtnFile.Checked
      btnBrowse.Enabled = rdBtnFile.Checked
      OnCanProceed()
   End Sub

   Private Sub btnTemplateBrowse_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim input As String = ""

      If MainForm.ChooseTemplate(input) Then
         LoadTemplate(input)
         _fileImage = _loadedEditorEngine.Pages(0).Image
         _iv.Image = _fileImage
         txtFilePath.Text = input
         OnCanProceed()
      End If
   End Sub

   Protected Overrides Sub OnCanProceed()
      OnCanProceed(LoadedEditor IsNot Nothing AndAlso _iv.Image IsNot Nothing)
   End Sub

   Private Sub LoadTemplate(ByVal selectedPath As String)
      _loadedEditorEngine = MainForm.GetOmrEngine().CreateTemplateForm()
      _loadedEditorEngine.Load(New FileStream(selectedPath, FileMode.Open, FileAccess.Read))
   End Sub

   Private Sub Riv_ItemChanged(ByVal sender As Object, ByVal e As ImageViewerItemChangedEventArgs)
      If e.Reason = ImageViewerItemChangedReason.Image Then
         _iv.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty)
      End If
   End Sub
End Class
