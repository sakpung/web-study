' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Ocr
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections.Generic
Imports System
Imports Microsoft.VisualBasic

Partial Public Class EnableLanguagesDialog : Inherits Form
   Private _ocrEngine As IOcrEngine
   Public Sub New(ByVal ocrEngine As IOcrEngine, ByVal moveRightImage As Image, ByVal moveLeftImage As Image, ByVal moveTopImage As Image)
      InitializeComponent()

      _ocrEngine = ocrEngine
      Dim languageManager As IOcrLanguageManager = _ocrEngine.LanguageManager

      ' Get the languages supported by this engine and fill the list box
      Dim languages As String() = languageManager.GetSupportedLanguages()
      Dim enabledLanguages As String() = languageManager.GetEnabledLanguages()
      Dim languagesDictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)()

      Dim friendlyNames As String() = New String(languages.Length - 1) {}

      Dim i As Integer = 0
      For Each language As String In languages
         friendlyNames(i) = MyLanguage.GetLanguageFriendlyName(language)
         languagesDictionary.Add(friendlyNames(i), language)
         i += 1
      Next language

      'Array.Sort(friendlyNames, 1, friendlyNames.Length - 1)

      i = 0
      For Each friendlyName As String In friendlyNames
         ' Don't add the enabled languages to the available languages list
         Dim languageEnabled As Boolean = False
         For Each enabledLanguage As String In enabledLanguages
            If languagesDictionary(friendlyName).Equals(enabledLanguage) Then
               languageEnabled = True
               Exit For
            End If
         Next enabledLanguage

         If (Not languageEnabled) Then
            Dim ml As MyLanguage = New MyLanguage(languagesDictionary(friendlyName), friendlyName, i)
            _languagesListBox.Items.Add(ml)
         End If
         i += 1
      Next friendlyName

      ' Fill the 'Enabled Languages' list box
      For Each enabledLanguage As String In enabledLanguages
         i = 0
         For Each entry As KeyValuePair(Of String, String) In languagesDictionary
            If entry.Value.Equals(enabledLanguage) Then
               Exit For
            End If
            i += 1
         Next entry
         Dim friendlyName As String = MyLanguage.GetLanguageFriendlyName(enabledLanguage)
         Dim ml As MyLanguage = New MyLanguage(enabledLanguage, friendlyName, i)
         _enabledLanguagesListBox.Items.Add(ml)
      Next enabledLanguage

      If (Not languageManager.SupportsEnablingMultipleLanguages) OrElse _languagesListBox.Items.Count <= 1 Then
         _languagesListBox.SelectionMode = SelectionMode.One
      End If

      Dim additionalLanguages As String() = languageManager.GetAdditionalLanguages()
      If Not additionalLanguages Is Nothing AndAlso additionalLanguages.Length > 0 Then
         _additionalLabel.Text = "There are more languages supported by this engine that are not installed on this machine." & Constants.vbLf & "Select 'Engine/Components' from the main menu for a complete list"
      End If

      ' Set the buttons images
      If (moveRightImage IsNot Nothing) Then
         _btnMoveRight.Image = moveRightImage
      Else
         _btnMoveRight.Text = "→"
      End If

      If (moveLeftImage IsNot Nothing) Then
         _btnMoveLeft.Image = moveLeftImage
      Else
         _btnMoveLeft.Text = "←"
      End If
      If (moveTopImage IsNot Nothing) Then
         _btnMoveTop.Image = moveTopImage
      Else
         _btnMoveTop.Text = "↑"
      End If
      UpdateUIState()
   End Sub

   Public Sub New(ocrEngine As IOcrEngine)
      Me.New(ocrEngine, Nothing, Nothing, Nothing)
   End Sub

   Private Sub UpdateUIState()
      _mainLanguageLabel.Visible = _ocrEngine.EngineType = OcrEngineType.LEAD
      _btnMoveTop.Visible = _ocrEngine.EngineType = OcrEngineType.LEAD

      _okButton.Enabled = _enabledLanguagesListBox.Items.Count > 0
      _btnMoveRight.Enabled = _languagesListBox.SelectedItems.Count > 0
      _btnMoveLeft.Enabled = _enabledLanguagesListBox.SelectedItems.Count > 0
      _btnMoveTop.Enabled = _enabledLanguagesListBox.SelectedItems.Count = 1
   End Sub

   Private Sub _languagesListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _languagesListBox.SelectedIndexChanged
      UpdateUIState()
   End Sub

   Private Sub _enabledLanguagesListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _enabledLanguagesListBox.SelectedIndexChanged
      UpdateUIState()
   End Sub

   Private Sub _btnMoveRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnMoveRight.Click
      Dim selectedItems As Array = Array.CreateInstance(GetType(Object), _languagesListBox.SelectedItems.Count)
      _languagesListBox.SelectedItems.CopyTo(selectedItems, 0)
      For Each ml As MyLanguage In selectedItems
         Dim index As Integer = _enabledLanguagesListBox.Items.Add(ml)
         _enabledLanguagesListBox.SetSelected(index, True)
         _languagesListBox.Items.Remove(ml)
      Next ml
   End Sub

   Private Sub _btnMoveLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnMoveLeft.Click
      Dim selectedItems As Array = Array.CreateInstance(GetType(Object), _enabledLanguagesListBox.SelectedItems.Count)
      _enabledLanguagesListBox.SelectedItems.CopyTo(selectedItems, 0)
      For Each ml As MyLanguage In selectedItems
         Dim insertionIndex As Integer = 0
         For Each item As MyLanguage In _languagesListBox.Items
            If ml.IndexInSupportedLanguagesList < item.IndexInSupportedLanguagesList Then
               Exit For
            End If

            insertionIndex += 1
         Next item
         _languagesListBox.Items.Insert(insertionIndex, ml)
         _languagesListBox.SetSelected(insertionIndex, True)
         _enabledLanguagesListBox.Items.Remove(ml)
      Next ml
   End Sub

   Private Sub _btnMoveTop_Click(sender As System.Object, e As System.EventArgs) Handles _btnMoveTop.Click
      Dim ml As MyLanguage = CType(_enabledLanguagesListBox.SelectedItem, MyLanguage)
      Dim index As Integer = _enabledLanguagesListBox.Items.IndexOf(ml)
      If index <= 0 Then
         Return
      End If

      _enabledLanguagesListBox.Items.RemoveAt(index)
      _enabledLanguagesListBox.Items.Insert(0, ml)
      _enabledLanguagesListBox.SetSelected(0, True)
   End Sub

   Private Sub _okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _okButton.Click
      ' Enable the languages selected by the user
      Dim languages As List(Of String) = New List(Of String)()
      For Each ml As MyLanguage In _enabledLanguagesListBox.Items
         languages.Add(ml.Language)
      Next ml

      Dim languageManager As IOcrLanguageManager = _ocrEngine.LanguageManager
      If languages.Count > 0 Then
         Try
            languageManager.EnableLanguages(languages.ToArray())
         Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "OCR Languages", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DialogResult = DialogResult.None
         End Try
      End If
   End Sub
End Class
