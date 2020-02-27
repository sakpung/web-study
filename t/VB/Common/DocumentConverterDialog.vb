' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Document
Imports Leadtools.Ocr
Imports Leadtools.Demos.Dialogs
Imports System
Imports System.IO
Imports Leadtools.Document.Writer

Partial Public Class DocumentConverterDialog
   Inherits Form
   Public Sub New()
      InitializeComponent()

      _optionsControl.RedactionOptions = New ConvertRedactionOptions()
   End Sub

   ' Preferences, input and output options from this dialog
   Private _preferences As DocumentConverterPreferences
   <Browsable(False)> _
   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public Property Preferences() As DocumentConverterPreferences
      Get
         Return _preferences
      End Get
      Set(value As DocumentConverterPreferences)
         _preferences = value
      End Set
   End Property

   ' Document to convert, if null, will as for an input file
   Private _inputDocument As LEADDocument
   <Browsable(False)>
   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
   Public Property InputDocument() As LEADDocument
      Get
         Return _inputDocument
      End Get
      Set(value As LEADDocument)
         _inputDocument = value
      End Set
   End Property


   <Browsable(False)>
   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
   Public Property RedactionOptions As ConvertRedactionOptions
      Get
         Return TryCast(_optionsControl.RedactionOptions, ConvertRedactionOptions)
      End Get
      Set(ByVal value As ConvertRedactionOptions)
         _optionsControl.RedactionOptions = value
      End Set
   End Property

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         If Me.Preferences Is Nothing Then
            Throw New InvalidOperationException("Set Preferences before calling this method")
         End If

         If Me.Preferences.RasterCodecsInstance Is Nothing Then
            Throw New InvalidOperationException("Set RasterCodecsInstance before calling this method")
         End If

         If Me.Preferences.DocumentWriterInstance Is Nothing Then
            Throw New InvalidOperationException("Set DocumentWriterInstance before calling this method")
         End If

         If _preferences.OcrEngineInstance Is Nothing OrElse Not _preferences.OcrEngineInstance.IsStarted Then
            _tabControl.TabPages.Remove(_ocrSettingsTabPage)
            _tabControl.TabPages.Remove(_ocrLanguagesTabPage)
         Else
            _ocrEngineLabel.Text = _ocrEngineLabel.Text.Replace("###", _preferences.OcrEngineInstance.EngineType.ToString())
         End If

         ' Set the preferences
         AddHandler _documentControl.UIStateChanged, AddressOf Me.UpdateUIState
         AddHandler _optionsControl.UIStateChanged, AddressOf Me.UpdateUIState

         _documentControl.Populate(_inputDocument, _preferences)
         _optionsControl.Populate(_inputDocument, _preferences)

         Try
            ' this can fail if the OCR Engine is missing
            If _preferences.OcrEngineInstance IsNot Nothing Then
               _ocrEngineSettingsControl.SetEngine(_preferences.OcrEngineInstance)
               InitOCRLanguages(_preferences.OcrEngineInstance)
            End If
         Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message)
         End Try

         UpdateUIState()
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub UpdateUIState()
      Dim ocrEngine As IOcrEngine = _preferences.OcrEngineInstance
      If Not ocrEngine Is Nothing Then
         Dim engineType As OcrEngineType = ocrEngine.EngineType
         _languagesHintLabel.Visible = (engineType = OcrEngineType.LEAD)
         _languagesMoveTopButton.Visible = (engineType = OcrEngineType.LEAD)

         _languagesMoveRightButton.Enabled = _languagesListBox.SelectedItems.Count > 0
         _languagesMoveLeftButton.Enabled = _enabledLanguagesListBox.SelectedItems.Count > 0
         _languagesMoveTopButton.Enabled = (_enabledLanguagesListBox.SelectedItems.Count = 1)
      End If

      Dim okState As Boolean = _documentControl.CanApplyToPreferences AndAlso _optionsControl.CanApplyToPreferences
      If okState AndAlso (Not ocrEngine Is Nothing) AndAlso ocrEngine.IsStarted Then
         ' Must have selected at least one enabled OCR language
         okState = _enabledLanguagesListBox.Items.Count > 0
      End If

      _okButton.Enabled = okState
   End Sub

   ' Language/Friendly name combo
   Private Structure MyLanguage
      Public Sub New(language As String, friendlyName As String, supportedIndex As Integer)
         Me.Language = language
         Me.FriendlyName = friendlyName
         Me.SupportedIndex = supportedIndex
      End Sub

      Public Language As String
      Public FriendlyName As String
      Public SupportedIndex As Integer

      Public Overrides Function ToString() As String
         Return Me.FriendlyName
      End Function

      Public Shared Function GetLanguageFriendlyName(language As String) As String
         Dim ci As CultureInfo

         If language = "sr-Cyrl-CS" OrElse language = "sr-SP-Cyrl" Then
            ci = New CultureInfo(&HC1A)
         ElseIf language = "sr-Latn-CS" Then
            ci = New CultureInfo(&H81A)
         ElseIf language = "zh-Hans" Then
            ci = New CultureInfo(&H4)
         ElseIf language = "zh-Hant" Then
            ci = New CultureInfo(&H7C04)
         Else
            ci = New CultureInfo(language)
         End If

         Return ci.EnglishName
      End Function
   End Structure

   Private Sub InitOCRLanguages(ocrEngine As IOcrEngine)
      Dim languageManager As IOcrLanguageManager = ocrEngine.LanguageManager

      ' Get the languages supported by this engine and fill the list box
      Dim languages() As String = languageManager.GetSupportedLanguages()
      Dim enabledLanguages() As String = languageManager.GetEnabledLanguages()
      Dim languagesDictionary As New Dictionary(Of String, String)

      Dim friendlyNames(languages.Length - 1) As String

      Dim index As Integer = 0
      For Each language As String In languages
         friendlyNames(index) = MyLanguage.GetLanguageFriendlyName(language)
         languagesDictionary.Add(friendlyNames(index), language)
         index = index + 1
      Next

      index = 0
      For Each friendlyName As String In friendlyNames
         ' Don't add the enabled languages to the available languages list
         Dim languageEnabled As Boolean = False
         For Each enabledLanguage As String In enabledLanguages
            If languagesDictionary(friendlyName).Equals(enabledLanguage) Then
               languageEnabled = True
               Exit For
            End If
         Next

         If Not languageEnabled Then
            Dim ml As New MyLanguage(languagesDictionary(friendlyName), friendlyName, index)
            _languagesListBox.Items.Add(ml)
         End If
         index = index + 1
      Next

      ' Fill the 'Enabled Languages' list box
      For Each enabledLanguage As String In enabledLanguages
         index = 0
         For Each entry As KeyValuePair(Of String, String) In languagesDictionary
            If entry.Value.Equals(enabledLanguage) Then
               Exit For
            End If
            index = index + 1
         Next

         Dim friendlyName As String = MyLanguage.GetLanguageFriendlyName(enabledLanguage)
         Dim ml As New MyLanguage(enabledLanguage, friendlyName, index)
         _enabledLanguagesListBox.Items.Add(ml)
      Next

      If Not languageManager.SupportsEnablingMultipleLanguages OrElse _languagesListBox.Items.Count <= 1 Then
         _languagesListBox.SelectionMode = SelectionMode.One
      End If

      Dim additionalLanguages() As String = languageManager.GetAdditionalLanguages()
      If (Not additionalLanguages Is Nothing) AndAlso additionalLanguages.Length > 0 Then
         _languagesAdditionalLabel.Text = "There are more languages supported by this engine that are not installed on this machine.\r\nVisit our website at http://www.leadtools.com for more information."
      End If
   End Sub


   Private Sub _languagesListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _languagesListBox.SelectedIndexChanged
      UpdateUIState()

   End Sub

   Private Sub _enabledLanguagesListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _enabledLanguagesListBox.SelectedIndexChanged
      UpdateUIState()
   End Sub

   Private Sub _languagesMoveRightButton_Click(sender As Object, e As EventArgs) Handles _languagesMoveRightButton.Click
      Dim selectedItems As New List(Of MyLanguage)
      For Each i As MyLanguage In _languagesListBox.SelectedItems
         selectedItems.Add(i)
      Next

      For Each ml As MyLanguage In selectedItems
         Dim index As Integer = _enabledLanguagesListBox.Items.Add(ml)
         _enabledLanguagesListBox.SetSelected(index, True)
         _languagesListBox.Items.Remove(ml)
      Next
   End Sub

   Private Sub _languagesMoveLeftButton_Click(sender As Object, e As EventArgs) Handles _languagesMoveLeftButton.Click
      Dim selectedItems As New List(Of MyLanguage)
      For Each i As MyLanguage In _enabledLanguagesListBox.SelectedItems
         selectedItems.Add(i)
      Next

      For Each ml As MyLanguage In selectedItems
         Dim insertionIndex As Integer = 0
         For Each item As MyLanguage In _languagesListBox.Items
            If (ml.SupportedIndex < item.SupportedIndex) Then
               Exit For
            End If

            insertionIndex = insertionIndex + 1
         Next

         _languagesListBox.Items.Insert(insertionIndex, ml)
         _languagesListBox.SetSelected(insertionIndex, True)
         _enabledLanguagesListBox.Items.Remove(ml)
      Next
   End Sub

   Private Sub _languagesMoveTopButton_Click(sender As Object, e As EventArgs) Handles _languagesMoveTopButton.Click
      Dim ml As MyLanguage = DirectCast(_enabledLanguagesListBox.SelectedItem, MyLanguage)
      Dim index As Integer = _enabledLanguagesListBox.Items.IndexOf(ml)
      If (index <= 0) Then
         Return
      End If

      _enabledLanguagesListBox.Items.RemoveAt(index)
      _enabledLanguagesListBox.Items.Insert(0, ml)
      _enabledLanguagesListBox.SetSelected(0, True)

   End Sub

   Private Function GetOCRLanguages(ocrEngine As IOcrEngine) As Boolean
      ' Enable the languages selected by the user
      Dim languages As New List(Of String)
      For Each ml As MyLanguage In _enabledLanguagesListBox.Items
         languages.Add(ml.Language)
      Next

      If languages.Count > 0 Then
         Try
            ocrEngine.LanguageManager.EnableLanguages(languages.ToArray())
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            Return False
         End Try
      End If

      Return True
   End Function

   Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
      If _documentControl.CanApplyToPreferences AndAlso _optionsControl.CanApplyToPreferences Then
         _documentControl.ApplyToPreferences()
         _optionsControl.ApplyToPreferences()

         If _inputDocument IsNot Nothing Then
            Dim redactionOptions As DocumentRedactionOptions = New DocumentRedactionOptions()
            redactionOptions.ViewOptions = _inputDocument.Annotations.RedactionOptions.ViewOptions
            redactionOptions.ConvertOptions = Me.RedactionOptions
            _inputDocument.Annotations.RedactionOptions = redactionOptions
         End If

         Dim deleteExistingFile As Boolean = File.Exists(_preferences.OutputDocumentFileName)
         If deleteExistingFile AndAlso _preferences.DocumentFormat = DocumentFormat.Ltd Then
            ' This is an LTD file that already exists, so ask the user what to do here, delete or append to it
            Dim message As String = String.Format("Delete the existing output file '{0}' first?{1}The file already exists. Select 'Yes' to delete it and create a new one or 'No' to append this result to it.", _preferences.OutputDocumentFileName, Environment.NewLine)
            Select Case Messager.ShowQuestion(Nothing, message, MessageBoxButtons.YesNo)
               Case DialogResult.Yes
                  deleteExistingFile = True
                  Exit Select

               Case DialogResult.No
                  deleteExistingFile = False
                  Exit Select
            End Select
         End If

         ' Delete the output file first
         If deleteExistingFile Then
            Try
               File.Delete(_preferences.OutputDocumentFileName)
            Catch ex As Exception
               Messager.ShowError(Me, ex)
               DialogResult = DialogResult.None
               Return
            End Try
         End If

         ' Get the languages
         If _preferences.OcrEngineInstance IsNot Nothing Then
            If Not GetOCRLanguages(_preferences.OcrEngineInstance) Then
               DialogResult = DialogResult.None
            End If
         End If
      End If
   End Sub

   Private Sub _aboutButton_Click(sender As Object, e As EventArgs) Handles _aboutButton.Click
      Using aboutDialog As New AboutDialog(DocumentConverterPreferences.DemoName, ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub
End Class
