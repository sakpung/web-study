' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Ocr

Public Class EnableLanguagesDialog
   Private _ocrEngine As IOcrEngine

   Public Sub New(ByVal ocrEngine As IOcrEngine)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      _ocrEngine = ocrEngine
      Dim languageManager As IOcrLanguageManager = _ocrEngine.LanguageManager

      ' Get the languages supported by this engine and fill the list box
      Dim languages As String() = languageManager.GetSupportedLanguages()
      Dim languagesDictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)()

      Dim friendlyNames As String() = New String(languages.Length - 1) {}

      Dim i As Integer = 0
      For Each language As String In languages
         friendlyNames(i) = MyLanguage.GetLanguageFriendlyName(language)
         languagesDictionary.Add(friendlyNames(i), language)
         i += 1
      Next language

      Array.Sort(friendlyNames, 1, friendlyNames.Length - 1)

      For Each friendlyName As String In friendlyNames
         Dim ml As MyLanguage = New MyLanguage(languagesDictionary(friendlyName), friendlyName)
         _languagesListBox.Items.Add(ml)
      Next friendlyName

      ' Check in the list box the current enabled languages
      Dim enabledLanguages() As String = languageManager.GetEnabledLanguages()
      For i = 0 To _languagesListBox.Items.Count - 1
         Dim ml As MyLanguage = CType(_languagesListBox.Items(i), MyLanguage)
         For Each language As String In enabledLanguages
            If (ml.Language = language) Then
               _languagesListBox.SelectedItems.Add(ml)
               Exit For
            End If
         Next
      Next

      If (Not languageManager.SupportsEnablingMultipleLanguages) OrElse (_languagesListBox.Items.Count <= 1) Then
         _languagesListBox.SelectionMode = SelectionMode.One
      End If
   End Sub

   Private Sub _languagesListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _languagesListBox.SelectedIndexChanged
      ' We must have at least one language selected
      _okButton.Enabled = (_languagesListBox.SelectedItems.Count > 0)
   End Sub

   Private Sub _okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _okButton.Click
      ' Enable the languages selected by the user
      Dim languages As New List(Of String)

      For Each ml As MyLanguage In _languagesListBox.SelectedItems
         languages.Add(ml.Language)
      Next

      Dim languageManager As IOcrLanguageManager = _ocrEngine.LanguageManager

      If (languages.Count > 0) Then
         Try
            languageManager.EnableLanguages(languages.ToArray())
         Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "OCR Languages", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DialogResult = DialogResult.None
         End Try
      End If
   End Sub
End Class
