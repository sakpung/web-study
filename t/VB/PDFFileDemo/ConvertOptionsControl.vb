' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Pdf
Imports Leadtools

Namespace PDFFileDemo
   Partial Public Class ConvertOptionsControl : Inherits UserControl
      Private _showSecurityOptions As Boolean
      Private _showOptimizationOptions As Boolean
      Private _showInitialViewOptions As Boolean
      Private _securityTabPage As TabPage
      Private _optimizationTabPage As TabPage
      Private _initialViewTabPage As TabPage

      Public Sub New()
         InitializeComponent()

         For Each level As PDFCompatibilityLevel In System.Enum.GetValues(GetType(PDFCompatibilityLevel))
            _compatibilityLevelComboBox.Items.Add(level)
         Next level

         _securityTabPage = _securityTab
         _optimizationTabPage = _optimizationTab
         _initialViewTabPage = _initialViewTab
      End Sub

      Public Sub SetDocument(ByVal document As PDFFile, ByVal showCompatibilityLevel As Boolean, ByVal showSecurityOptions As Boolean, ByVal showOptimizationOptions As Boolean, ByVal showInitialViewOptions As Boolean, ByVal firstPageNumber As Integer, ByVal lastPageNumber As Integer)
         _showSecurityOptions = showSecurityOptions
         _showOptimizationOptions = showOptimizationOptions
         _showInitialViewOptions = showInitialViewOptions

         _compatibilityLevelComboBox.Visible = showCompatibilityLevel
         _compatibilityLevelLabel.Visible = showCompatibilityLevel
         _compatibilityLevelComboBox.SelectedItem = document.CompatibilityLevel

         If Not document.DocumentProperties Is Nothing Then
            _documentPropertiesControl.SetDocumentProperties(document.DocumentProperties, False)
         Else
            Dim documentProps As PDFDocumentProperties = New PDFDocumentProperties()
            documentProps.Created = DateTime.Now
            documentProps.Modified = DateTime.Now

            _documentPropertiesControl.SetDocumentProperties(documentProps, False)
         End If

         If showSecurityOptions Then
            _updateSecurityOptionsCheckBox.Checked = Not document.SecurityOptions Is Nothing

            If Not document.SecurityOptions Is Nothing Then
               _securityOptionsControl.SetSecurityOptions(document.SecurityOptions)
            Else
               Dim securityOptions As PDFSecurityOptions = New PDFSecurityOptions()
               securityOptions.PrintEnabled = True
               securityOptions.HighQualityPrintEnabled = True
               securityOptions.CopyEnabled = True
               securityOptions.EditEnabled = True
               securityOptions.AnnotationsEnabled = True
               securityOptions.AssemblyEnabled = True
               securityOptions.EncryptionMode = PDFEncryptionMode.RC40Bit
               _securityOptionsControl.SetSecurityOptions(securityOptions)
            End If
            _securityOptionsControl.SetCompatibilityLevel(document.CompatibilityLevel)
         End If

         If showOptimizationOptions Then
            _updateOptimizationOptionsCheckBox.Checked = Not document.OptimizerOptions Is Nothing

            If Not document.OptimizerOptions Is Nothing Then
               _optimizerOptionsControl.SetOptimizerOptions(document.OptimizerOptions)
            Else
               Dim optimizerOptions As PDFOptimizerOptions = New PDFOptimizerOptions()
               optimizerOptions.AutoOptimizerMode = PDFAutoOptimizerMode.Customized
               optimizerOptions.ColorImageDownsamplingMode = PDFDownsamplingMode.Average
               optimizerOptions.ColorImageDownsampleFactor = 1.5
               optimizerOptions.ColorImageDPI = 150
               optimizerOptions.ColorImageCompression = RasterImageFormat.Jpeg

               optimizerOptions.GrayImageDownsamplingMode = PDFDownsamplingMode.Average
               optimizerOptions.GrayImageDownsampleFactor = 1.5
               optimizerOptions.GrayImageDPI = 150
               optimizerOptions.GrayImageCompression = RasterImageFormat.RawFlate

               optimizerOptions.MonoImageDownsamplingMode = PDFDownsamplingMode.Average
               optimizerOptions.MonoImageDownsampleFactor = 1.5
               optimizerOptions.MonoImageDPI = 150
               optimizerOptions.MonoImageCompression = RasterImageFormat.FaxG4

               _optimizerOptionsControl.SetOptimizerOptions(optimizerOptions)
            End If
         End If

         If showInitialViewOptions Then
            _updateInitialViewOptionsCheckBox.Checked = Not document.InitialViewOptions Is Nothing

            Dim totalPages As Integer = If((lastPageNumber = -1), document.Pages.Count - firstPageNumber + 1, lastPageNumber - firstPageNumber + 1)
            If Not document.InitialViewOptions Is Nothing Then
               _initialViewOptionsControl.SetInitialViewOptions(document.InitialViewOptions, totalPages)
            Else
               Dim initialViewOptions As PDFInitialViewOptions = New PDFInitialViewOptions()
               initialViewOptions.AutoPrint = False
               initialViewOptions.CenterWindow = False
               initialViewOptions.DisplayDocTitle = False
               initialViewOptions.FitWindow = False
               initialViewOptions.HideMenubar = False
               initialViewOptions.HideToolbar = False
               initialViewOptions.HideWindowUI = False
               initialViewOptions.PageFitType = PDFPageFitType.Default
               initialViewOptions.PageLayoutType = PDFPageLayoutType.OneColumnDisplay
               initialViewOptions.PageModeType = PDFPageModeType.PageOnly
               initialViewOptions.PageNumber = 1
               initialViewOptions.Position = New PDFPoint(0, 0)
               initialViewOptions.ZoomPercent = 0

               _initialViewOptionsControl.SetInitialViewOptions(initialViewOptions, totalPages)
            End If
         End If

         UpdateUIState(showSecurityOptions, showOptimizationOptions, showInitialViewOptions)
      End Sub

      Public Sub UpdateDocument(ByVal document As PDFFile)
         If _compatibilityLevelComboBox.Visible Then
            document.CompatibilityLevel = CType(_compatibilityLevelComboBox.SelectedItem, PDFCompatibilityLevel)
         End If

         If _updateDocumentPropertiesCheckBox.Checked Then
            document.DocumentProperties = New PDFDocumentProperties()
            _documentPropertiesControl.UpdateDocumentProperties(document.DocumentProperties)
         Else
            document.DocumentProperties = Nothing
         End If

         If _showSecurityOptions Then
            If _updateSecurityOptionsCheckBox.Checked Then
               document.SecurityOptions = New PDFSecurityOptions()
               _securityOptionsControl.UpdateSecurityOptions(document.SecurityOptions)
               _securityOptionsControl.SetCompatibilityLevel(document.CompatibilityLevel)
            Else
               document.SecurityOptions = Nothing
            End If
         End If

         If _showOptimizationOptions Then
            If _updateOptimizationOptionsCheckBox.Checked Then
               document.OptimizerOptions = New PDFOptimizerOptions()
               document.OptimizerOptions.AutoOptimizerMode = PDFAutoOptimizerMode.Customized
               document.OptimizerOptions.ColorImageDownsamplingMode = PDFDownsamplingMode.Average
               document.OptimizerOptions.ColorImageDownsampleFactor = 1.5
               document.OptimizerOptions.ColorImageDPI = 150
               document.OptimizerOptions.ColorImageCompression = RasterImageFormat.Jpeg

               document.OptimizerOptions.GrayImageDownsamplingMode = PDFDownsamplingMode.Average
               document.OptimizerOptions.GrayImageDownsampleFactor = 1.5
               document.OptimizerOptions.GrayImageDPI = 150
               document.OptimizerOptions.GrayImageCompression = RasterImageFormat.RawFlate

               document.OptimizerOptions.MonoImageDownsamplingMode = PDFDownsamplingMode.Average
               document.OptimizerOptions.MonoImageDownsampleFactor = 1.5
               document.OptimizerOptions.MonoImageDPI = 150
               document.OptimizerOptions.MonoImageCompression = RasterImageFormat.FaxG4
               _optimizerOptionsControl.UpdateOptimizerOptions(document.OptimizerOptions)
            Else
               document.OptimizerOptions = Nothing
            End If
         End If

         If _showInitialViewOptions Then
            If _updateInitialViewOptionsCheckBox.Checked Then
               document.InitialViewOptions = New PDFInitialViewOptions()
               _initialViewOptionsControl.UpdateInitialViewOptions(document.InitialViewOptions)
            Else
               document.InitialViewOptions = Nothing
            End If
         End If
      End Sub

      Private Sub UpdateUIState(ByVal showSecurityOptions As Boolean, ByVal showOptimizationOptions As Boolean, ByVal showInitialViewOptions As Boolean)
         _documentPropertiesControl.Enabled = _updateDocumentPropertiesCheckBox.Checked
         _securityOptionsControl.Enabled = _updateSecurityOptionsCheckBox.Checked
         _optimizerOptionsControl.Enabled = _updateOptimizationOptionsCheckBox.Checked
         _initialViewOptionsControl.Enabled = _updateInitialViewOptionsCheckBox.Checked
         ' Show/Hide unwanted tab pages
         Dim securityTabPage As TabPage = _tabControl.TabPages("_securityTab")
         If (Not showSecurityOptions) Then
            _updateSecurityOptionsCheckBox.Checked = False
            If Not securityTabPage Is Nothing Then
               _tabControl.TabPages.Remove(securityTabPage)
            End If
         Else
            If securityTabPage Is Nothing Then ' Tab page does not exist
               _tabControl.TabPages.Insert(1, _securityTabPage)
            End If
         End If

         Dim optimizationTabPage As TabPage = _tabControl.TabPages("_optimizationTab")
         If (Not showOptimizationOptions) Then
            If Not optimizationTabPage Is Nothing Then
               _tabControl.TabPages.Remove(optimizationTabPage)
            End If
         Else
            If optimizationTabPage Is Nothing Then ' Tab page does not exist
               If (_tabControl.TabPages.Count >= 2) Then
                  _tabControl.TabPages.Insert(2, _optimizationTabPage)
               Else
                  _tabControl.TabPages.Insert(_tabControl.TabPages.Count, _optimizationTabPage)
               End If
            End If
         End If

         Dim initialViewTabPage As TabPage = _tabControl.TabPages("_initialViewTab")
         If (Not showInitialViewOptions) Then
            If Not initialViewTabPage Is Nothing Then
               _tabControl.TabPages.Remove(initialViewTabPage)
            End If
         Else
            If initialViewTabPage Is Nothing Then ' Tab page does not exist
               If (_tabControl.TabPages.Count >= 3) Then
                  _tabControl.TabPages.Insert(3, _initialViewTabPage)
               Else
                  _tabControl.TabPages.Insert(_tabControl.TabPages.Count, _initialViewTabPage)
               End If
            End If
         End If
      End Sub

      Private Sub UpdateOptionsUIState()
         If PDFCompatibilityLevel.PDFA = CType(_compatibilityLevelComboBox.SelectedItem, PDFCompatibilityLevel) Then
            UpdateUIState(False, _showOptimizationOptions, _showInitialViewOptions)
         Else
            UpdateUIState(_showSecurityOptions, _showOptimizationOptions, _showInitialViewOptions)
         End If
      End Sub

      Private Sub _compatibilityLevelComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _compatibilityLevelComboBox.SelectedIndexChanged
         UpdateOptionsUIState()
      End Sub

      Private Sub _updateDocumentPropertiesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _updateDocumentPropertiesCheckBox.CheckedChanged
         UpdateUIState(_showSecurityOptions, _showOptimizationOptions, _showInitialViewOptions)
      End Sub

      Private Sub _updateSecurityOptionsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _updateSecurityOptionsCheckBox.CheckedChanged
         UpdateUIState(_showSecurityOptions, _showOptimizationOptions, _showInitialViewOptions)
      End Sub

      Private Sub _updateOptimizationOptionsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _updateOptimizationOptionsCheckBox.CheckedChanged
         UpdateUIState(_showSecurityOptions, _showOptimizationOptions, _showInitialViewOptions)
      End Sub

      Private Sub _updateInitialViewOptionsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _updateInitialViewOptionsCheckBox.CheckedChanged
         UpdateUIState(_showSecurityOptions, _showOptimizationOptions, _showInitialViewOptions)
      End Sub
   End Class
End Namespace
