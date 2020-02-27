' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Ocr

Partial Public Class DetectPageLanguagesDialog : Inherits Form
   Private _ocrEngine As IOcrEngine
   Private _ocrPage As IOcrPage

   Public Sub New(ByVal ocrEngine As IOcrEngine, ByVal ocrPage As IOcrPage)
      InitializeComponent()

      _ocrEngine = ocrEngine
      _ocrPage = ocrPage
   End Sub

   Private Sub DetectPageLanguagesDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      Dim supportedLanguages As String() = _ocrEngine.LanguageManager.GetSupportedLanguages()
      If supportedLanguages Is Nothing OrElse supportedLanguages.Length <= 0 Then
         Return
      End If

      Dim languagesDictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)()
      Dim friendlyNames As String() = New String(supportedLanguages.Length - 1) {}

      Dim i As Integer = 0
      For Each language As String In supportedLanguages
         friendlyNames(i) = MyLanguage.GetLanguageFriendlyName(language)
         languagesDictionary.Add(friendlyNames(i), language)
         i += 1
      Next language

      Array.Sort(friendlyNames, 1, friendlyNames.Length - 1)
      For Each friendlyName As String In friendlyNames
         Dim ml As MyLanguage = New MyLanguage(languagesDictionary(friendlyName), friendlyName, -1)
         _lbSuggestedLanguages.Items.Add(ml)
      Next friendlyName

      UpdateUIState()
   End Sub

   Private Sub _btnDetectLanguages_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnDetectLanguages.Click
      _lbPageLanguages.Items.Clear()
      Dim suggestedLanguages As String() = New String(_lbSuggestedLanguages.SelectedItems.Count - 1) {}
      Dim index As Integer = 0
      For Each language As MyLanguage In _lbSuggestedLanguages.SelectedItems
         suggestedLanguages(index) = language.Language
         index += 1
      Next language

      Dim pageLanguages As String() = _ocrPage.DetectLanguages(suggestedLanguages)
      If Not pageLanguages Is Nothing AndAlso pageLanguages.Length > 0 Then
         For Each lang As String In pageLanguages
            Dim friendlyName As String = MyLanguage.GetLanguageFriendlyName(lang)
            _lbPageLanguages.Items.Add(friendlyName)
         Next lang
      End If
   End Sub

   Private Sub UpdateUIState()
      _btnDetectLanguages.Enabled = _lbSuggestedLanguages.SelectedItems.Count > 0
   End Sub

   Private Sub _lbSuggestedLanguages_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _lbSuggestedLanguages.SelectedIndexChanged
      UpdateUIState()
   End Sub
End Class
