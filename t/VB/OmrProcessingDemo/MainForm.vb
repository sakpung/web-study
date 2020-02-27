Imports System
Imports System.Windows.Forms
Imports Leadtools
Imports System.IO
Imports Leadtools.Codecs
Imports Leadtools.Ocr
Imports Leadtools.Forms.Processing.Omr
Imports Leadtools.Demos
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Drawing

Partial Public Class MainForm
   Inherits Form

   Private Const templatePath As String = "Template"
   Public Const WORKSPACE_EXT As String = ".ltw"
   Public Const TEMPLATE_EXT As String = ".ltt"
   Private vc As ViewerControl
   Private _resultsPanel As ResultsPanel
   Private Const TBI_TEMPLATE As Integer = 0
   Private Const TBI_PROCESS As Integer = 1
   Private Const TBI_WORKSPACE As Integer = 2
   Public Shared PerspectiveDeskewActive As Boolean = False
   Public Shared UnWarpActive As Boolean = False
   Private Shared _omrEngine As OmrEngine
   Public Shared AutoEstimateMissingOmr As Boolean = True

   Enum TemplateState
      NotPresent
      PresentButNoFieldsDefined
      Present
   End Enum

   Public Sub New()
      InitializeComponent()
      vc = New ViewerControl()
      vc.Dock = DockStyle.Fill
      AddHandler vc.CloseRequested, AddressOf ViewerControlCloseRequested
      _resultsPanel = New ResultsPanel()
      _resultsPanel.Dock = DockStyle.Fill
      AddHandler _resultsPanel.CloseRequested, AddressOf ResultsPanelCloseRequested
   End Sub

   Private Sub ViewerControlCloseRequested(ByVal sender As Object, ByVal e As CloseRequestArgs)
      vc.Deactivate()
      vc.Dispose()
      vc = New ViewerControl()
      vc.Dock = DockStyle.Fill
      AddHandler vc.CloseRequested, AddressOf ViewerControlCloseRequested
      tbcMain.TabPages(TBI_TEMPLATE).Controls.Add(vc)
      vc.BringToFront()
      tbcMain.SelectedIndex = TBI_TEMPLATE

      Select Case e.ClosingState
         Case CloseRequestArgs.ClosingReason.RevertToIntro
            ShowIntroDialog()
         Case CloseRequestArgs.ClosingReason.ExplicitNew
            vc.CreateNewTemplate()
         Case CloseRequestArgs.ClosingReason.ToLoadExisting
            vc.ShowLoadTemplate()
         Case CloseRequestArgs.ClosingReason.ApplicationExiting
            tbcMain.SelectedIndex = TBI_WORKSPACE

            If _resultsPanel.DoCloseWorkspace() Then
               Application.[Exit]()
            End If

         Case Else
      End Select
   End Sub

   Private Sub ResultsPanelCloseRequested(ByVal sender As Object, ByVal e As CloseRequestArgs)
      _resultsPanel.Deactivate()
      _resultsPanel.Dispose()
      _resultsPanel = New ResultsPanel()
      _resultsPanel.Dock = DockStyle.Fill
      AddHandler _resultsPanel.CloseRequested, AddressOf ResultsPanelCloseRequested
      tbcMain.TabPages(TBI_WORKSPACE).Controls.Add(_resultsPanel)
      _resultsPanel.BringToFront()
      tbcMain.SelectedIndex = TBI_WORKSPACE

      Select Case e.ClosingState
         Case CloseRequestArgs.ClosingReason.RevertToIntro
            ShowIntroDialog()
         Case CloseRequestArgs.ClosingReason.ToLoadExisting
            _resultsPanel.OpenWorkspace()
         Case CloseRequestArgs.ClosingReason.ApplicationExiting
            tbcMain.SelectedIndex = TBI_TEMPLATE

            If vc.DoCloseTemplate() Then
               Application.[Exit]()
            End If

         Case Else
      End Select
   End Sub

   Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
      tbcMain.TabPages(TBI_TEMPLATE).Controls.Add(vc)
      vc.BringToFront()
      tbcMain.TabPages(TBI_WORKSPACE).Controls.Add(_resultsPanel)
      _resultsPanel.BringToFront()
      AddHandler tbcMain.SelectedIndexChanged, AddressOf TbcMain_SelectedIndexChanged
   End Sub

   Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As EventArgs)
      If Settings.Default.ShowInfoDialog Then
         Dim info As InfoDialog = New InfoDialog()
         info.ShowDialog(Me)
      End If

      ShowIntroDialog()
   End Sub

   Private Sub ShowIntroDialog()
      Dim id As IntroDialog = New IntroDialog(vc.IsAutosavePresent())
      id.ShowDialog(Me)

      Select Case id.Start
         Case IntroDialog.StartupType.NewTemplate
            vc.CreateNewTemplate()
            tbcMain.SelectedIndex = TBI_TEMPLATE
         Case IntroDialog.StartupType.LoadTemplate
            vc.ShowLoadTemplate()
            tbcMain.SelectedIndex = TBI_TEMPLATE
         Case IntroDialog.StartupType.LoadBackupTemplate
            vc.LoadAutosave()
            tbcMain.SelectedIndex = TBI_TEMPLATE
         Case IntroDialog.StartupType.LoadWorkspace

            If UnpackWorkspace() Then
               tbcMain.SelectedIndex = TBI_WORKSPACE
            End If

         Case Else
      End Select
   End Sub

   Private Function UnpackWorkspace() As Boolean
      If _resultsPanel.OpenWorkspace() Then
         vc.AssignTemplate(_resultsPanel.CurrentWorkspace.Template)
         Return True
      End If

      Return False
   End Function

   Private Sub TbcMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
      Select Case tbcMain.SelectedIndex
         Case TBI_TEMPLATE
            _resultsPanel.Deactivate()
         Case TBI_WORKSPACE
            vc.Deactivate()
         Case TBI_PROCESS
            vc.Deactivate()
            _resultsPanel.Deactivate()
         Case Else
      End Select

      If tbcMain.SelectedIndex = TBI_PROCESS Then
         Dim ts As TemplateState = DoTransferTemplate()

         Select Case ts
            Case TemplateState.NotPresent
               MessageBox.Show("A template must first be loaded or constructed.")
               tbcMain.SelectedIndex = TBI_TEMPLATE
            Case TemplateState.PresentButNoFieldsDefined
               MessageBox.Show("No fields have been created in the template.")
               tbcMain.SelectedIndex = TBI_TEMPLATE
            Case TemplateState.Present

               If _resultsPanel.DoOMRProcessing() Then
                  tbcMain.SelectedIndex = TBI_WORKSPACE
                  _resultsPanel.ShowPostProcessingResults()
               ElseIf _resultsPanel.CurrentWorkspace IsNot Nothing Then
                  tbcMain.SelectedIndex = TBI_WORKSPACE
               Else
                  tbcMain.SelectedIndex = TBI_TEMPLATE
               End If

            Case Else
         End Select
      End If
   End Sub

   Private Function DoTransferTemplate() As TemplateState
      _resultsPanel.TemplateImage = vc.RasterImage
      _resultsPanel.CurrentTemplate = vc.TemplateForm

      If _resultsPanel.TemplateImage Is Nothing OrElse _resultsPanel.CurrentAutoScaleDimensions = SizeF.Empty Then
         Return TemplateState.NotPresent
      End If

      Dim fieldsPresent As Boolean = _resultsPanel.CurrentTemplate.Pages.Any(Function(pg As Page) pg.Fields.Count > 0)
      Return If(fieldsPresent, TemplateState.Present, TemplateState.PresentButNoFieldsDefined)
   End Function

   Public Shared Function GetOcrEngine() As IOcrEngine
      Dim codecs As RasterCodecs = GetRasterCodecs()
      Dim formsOCREngine As IOcrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, False)
      formsOCREngine.Startup(codecs, Nothing, Nothing, Nothing)
      Return formsOCREngine
   End Function

   Public Shared Function GetRasterCodecs() As RasterCodecs
      Dim codecs As RasterCodecs = New RasterCodecs()
      codecs.Options.Load.Resolution = 300
      codecs.Options.Load.XResolution = 300
      codecs.Options.Load.YResolution = 300
      codecs.Options.RasterizeDocument.Load.Resolution = 300
      codecs.Options.RasterizeDocument.Load.XResolution = 300
      codecs.Options.RasterizeDocument.Load.YResolution = 300
      Return codecs
   End Function

   Public Shared Function GetOmrEngine() As OmrEngine
      If _omrEngine Is Nothing Then
         _omrEngine = New OmrEngine()
         Dim bce As Barcode.BarcodeEngine = New Barcode.BarcodeEngine()
         _omrEngine.EnginesObject.BarcodeEngine = bce
         _omrEngine.EnginesObject.OcrEngine = GetOcrEngine()
      End If

      Return _omrEngine
   End Function

   Friend Shared Function LoadRasterImage(<Out()> ByRef image As RasterImage, <Out()> ByRef filename As String, ByVal allPages As Boolean, Optional ByVal initialDir As String = "") As Boolean
      image = Nothing
      filename = ""
      Dim ofd As OpenFileDialog = New OpenFileDialog()
      ofd.Filter = "Image Files (*.bmp; *.jpg; *.tif; *.png, *.pdf) | *.BMP; *.JPG; *.TIF; *.PNG; *.PDF"
      ofd.InitialDirectory = If(initialDir IsNot Nothing, initialDir, Path.Combine(DemosGlobal.ImagesFolder, "\Forms\OMR Processing"))

      If ofd.ShowDialog() = DialogResult.OK Then
         filename = ofd.FileName
         image = LoadImage(filename, allPages)
      End If

      Return image IsNot Nothing
   End Function

   Friend Shared Function LoadImage(ByVal fileName As String, ByVal allPages As Boolean) As RasterImage
      Dim image As RasterImage = Nothing

      Try

         Using codecs As RasterCodecs = GetRasterCodecs()
            codecs.Options.Load.AllPages = allPages
            image = codecs.Load(fileName)
            image.ChangeViewPerspective(RasterViewPerspective.TopLeft)
         End Using

      Catch ex As Exception
         MessageBox.Show(ex.Message)
         Return Nothing
      End Try

      Return image
   End Function

   Friend Shared Function ChooseTemplate(<Out()> ByRef input As String) As Boolean
      Dim fbd As OpenFileDialog = New OpenFileDialog()
      fbd.Title = "Choose Template File"
      fbd.Filter = String.Format("Template files|*{0}", TEMPLATE_EXT)
      Dim defaultPath As String = Path.Combine(DemosGlobal.ImagesFolder, "\Forms\OMR Processing")
      fbd.InitialDirectory = defaultPath

      Dim dr As DialogResult = fbd.ShowDialog()
      input = fbd.FileName
      Return dr = DialogResult.OK
   End Function

   Friend Shared Function ChooseWorkspaceFilePath(<Out()> ByRef input As String) As Boolean
      Dim sfd As SaveFileDialog = New SaveFileDialog()
      input = Nothing
      sfd.Filter = String.Format("Workspace files|*{0}", WORKSPACE_EXT)
      sfd.OverwritePrompt = True
      sfd.RestoreDirectory = True

      Dim defaultPath As String = Path.Combine(DemosGlobal.ImagesFolder, "\Forms\OMR Processing")
      sfd.InitialDirectory = defaultPath

      If sfd.ShowDialog() = DialogResult.OK Then
         input = sfd.FileName
         Return True
      End If

      Return False
   End Function

   Friend Shared Function GetFromTwain(<Out()> ByRef savedPath As String) As Boolean
      savedPath = Nothing
      Dim td As TwainDialog = New TwainDialog()

      If td.ShowDialog() = DialogResult.OK Then
         savedPath = td.SavedLocation
      End If

      Return savedPath IsNot Nothing
   End Function

   Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      Settings.Default.Save()
      vc.Cleanup()
   End Sub
End Class
