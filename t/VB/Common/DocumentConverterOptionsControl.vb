' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Document
Imports Leadtools.Document.Converter

Partial Public Class DocumentConverterOptionsControl
   Inherits UserControl

   Public Sub New()
      InitializeComponent()
   End Sub

   Private _preferences As DocumentConverterPreferences

   Public Sub Populate(ByVal inputDocument As LEADDocument, ByVal preferences As DocumentConverterPreferences)
      _preferences = preferences

      If _preferences.OcrEngineInstance Is Nothing Then
         _enableSvgConversionCheckBox.Checked = True
         _enableSvgConversionCheckBox.Enabled = False
      Else
         _enableSvgConversionCheckBox.Checked = _preferences.EnableSvgConversion
      End If

      _svgImagesRecognitionModeComboBox.Items.Clear()

      For Each i As DocumentConverterSvgImagesRecognitionMode In [Enum].GetValues(GetType(DocumentConverterSvgImagesRecognitionMode))
         _svgImagesRecognitionModeComboBox.Items.Add(i)
      Next

      _svgImagesRecognitionModeComboBox.SelectedItem = If((_preferences.OcrEngineInstance IsNot Nothing AndAlso _preferences.OcrEngineInstance.IsStarted), _preferences.SvgImagesRecognitionMode, DocumentConverterSvgImagesRecognitionMode.Disabled)
      _svgImagesRecognitionModeLabel.Enabled = _preferences.OcrEngineInstance IsNot Nothing AndAlso _preferences.OcrEngineInstance.IsStarted
      _svgImagesRecognitionModeComboBox.Enabled = _preferences.OcrEngineInstance IsNot Nothing AndAlso _preferences.OcrEngineInstance.IsStarted
      _emptyPageModeComboBox.Items.Clear()

      For Each i As DocumentConverterEmptyPageMode In [Enum].GetValues(GetType(DocumentConverterEmptyPageMode))
         _emptyPageModeComboBox.Items.Add(i)
      Next

      _emptyPageModeComboBox.SelectedItem = _preferences.EmptyPageMode
      _useThreadsCheckBox.Checked = _preferences.UseThreads
      _deskewCheckBox.Checked = _preferences.PreprocessingDeskew
      _invertCheckBox.Checked = _preferences.PreprocessingInvert
      _orientCheckBox.Checked = _preferences.PreprocessingOrient
      _continueOnRecoverableErrorsCheckBox.Checked = (_preferences.ErrorMode = DocumentConverterJobErrorMode.[Continue])
      _enableTraceCheckBox.Checked = _preferences.EnableTrace
      _jobNameTextBox.Text = _preferences.JobName

      If _preferences.OpenOutputDocumentAllowed Then
         _openOutputDocumentCheckBox.Checked = _preferences.OpenOutputDocument
      Else
         _openOutputDocumentCheckBox.Checked = False
         _openOutputDocumentCheckBox.Enabled = False
         _openOutputDocumentCheckBox.Visible = False
      End If

      If inputDocument IsNot Nothing Then
         _redactionOptionsControl.Options = inputDocument.Annotations.RedactionOptions.ConvertOptions.Clone()
      End If

      UpdateHelp()
   End Sub

   Public Sub ApplyToPreferences()
      _preferences.EnableSvgConversion = _enableSvgConversionCheckBox.Checked
      If _preferences.OcrEngineInstance IsNot Nothing AndAlso _preferences.OcrEngineInstance.IsStarted Then _preferences.SvgImagesRecognitionMode = CType(_svgImagesRecognitionModeComboBox.SelectedItem, DocumentConverterSvgImagesRecognitionMode)
      _preferences.EmptyPageMode = CType(_emptyPageModeComboBox.SelectedItem, DocumentConverterEmptyPageMode)
      _preferences.UseThreads = _useThreadsCheckBox.Checked
      _preferences.PreprocessingDeskew = _deskewCheckBox.Checked
      _preferences.PreprocessingInvert = _invertCheckBox.Checked
      _preferences.PreprocessingOrient = _orientCheckBox.Checked
      _preferences.ErrorMode = If(_continueOnRecoverableErrorsCheckBox.Checked, DocumentConverterJobErrorMode.[Continue], DocumentConverterJobErrorMode.Abort)
      _preferences.EnableTrace = _enableTraceCheckBox.Checked
      _preferences.JobName = _jobNameTextBox.Text
      _preferences.OpenOutputDocument = _openOutputDocumentCheckBox.Checked
      UpdateUIState()
   End Sub

   Public ReadOnly Property CanApplyToPreferences As Boolean
      Get
         Return True
      End Get
   End Property

   Public Property RedactionOptions As AnnotationsRedactionOptions
      Get
         Return Me._redactionOptionsControl.Options
      End Get
      Set(ByVal value As AnnotationsRedactionOptions)
         If value IsNot Nothing Then Me._redactionOptionsControl.Options = value
      End Set
   End Property

   Private Shared ReadOnly _svgImagesRecognitionModeHelp As String() = {"Use OCR on raster only pages found in the document.", "Do not use OCR at all.", "Use OCR on the image elements found in a page."}

   Private Sub UpdateHelp()
      Dim svgImagesRecognitionMode As DocumentConverterSvgImagesRecognitionMode = CType(_svgImagesRecognitionModeComboBox.SelectedItem, DocumentConverterSvgImagesRecognitionMode)
      _svgImagesRecognitionModeHelpLabel.Text = _svgImagesRecognitionModeHelp(CInt(svgImagesRecognitionMode))
   End Sub

   Public Event UIStateChanged As EventHandler

   Private Sub UpdateUIState()
      RaiseEvent UIStateChanged(Me, EventArgs.Empty)
   End Sub

   Private Sub _svgImagesRecognitionModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
      UpdateHelp()
   End Sub

   Private Sub _defaultButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      _svgImagesRecognitionModeComboBox.SelectedIndex = 0
      _emptyPageModeComboBox.SelectedIndex = 0
      _enableSvgConversionCheckBox.Checked = True
      _useThreadsCheckBox.Checked = True
      _deskewCheckBox.Checked = False
      _invertCheckBox.Checked = False
      _orientCheckBox.Checked = False
      _continueOnRecoverableErrorsCheckBox.Checked = True
      _openOutputDocumentCheckBox.Checked = _preferences.OpenOutputDocumentAllowed
      _redactionOptionsControl.Options = New AnnotationsRedactionOptions()
   End Sub
End Class
