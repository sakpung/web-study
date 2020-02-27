' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Ocr
Imports System

Namespace OcrDemo
   Partial Public Class DetectPageLanguagesDialog
      Inherits Form
      Private _ocrEngine As IOcrEngine
      Private _ocrPage As IOcrPage

      Public Sub New(ocrEngine As IOcrEngine, ocrPage As IOcrPage)
         InitializeComponent()

         _ocrEngine = ocrEngine
         _ocrPage = ocrPage
      End Sub

      Private Sub DetectPageLanguagesDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
         Dim supportedLanguages As String() = _ocrEngine.LanguageManager.GetSupportedLanguages()
         If supportedLanguages Is Nothing OrElse supportedLanguages.Length <= 0 Then
            Return
         End If

         Dim languagesDictionary As New Dictionary(Of String, String)()
         Dim friendlyNames As String() = New String(supportedLanguages.Length - 1) {}

         Dim i As Integer = 0
         For Each language As String In supportedLanguages
            friendlyNames(i) = MyLanguage.GetLanguageFriendlyName(language)
            languagesDictionary.Add(friendlyNames(i), language)
            i += 1
         Next

         Array.Sort(friendlyNames, 1, friendlyNames.Length - 1)
         For Each friendlyName As String In friendlyNames
            Dim ml As New MyLanguage(languagesDictionary(friendlyName), friendlyName, -1)
            _lbSuggestedLanguages.Items.Add(ml)
         Next

         UpdateUIState()
      End Sub

      Private Sub _btnDetectLanguages_Click(sender As Object, e As EventArgs) Handles _btnDetectLanguages.Click
         Using wait As New WaitCursor()
            _lbPageLanguages.Items.Clear()
            Dim suggestedLanguages As String() = New String(_lbSuggestedLanguages.SelectedItems.Count - 1) {}
            Dim index As Integer = 0
            For Each language As MyLanguage In _lbSuggestedLanguages.SelectedItems
               suggestedLanguages(index) = language.Language
               index += 1
            Next

            Dim pageLanguages As String() = _ocrPage.DetectLanguages(suggestedLanguages)
            If pageLanguages IsNot Nothing AndAlso pageLanguages.Length > 0 Then
               For Each lang As String In pageLanguages
                  Dim friendlyName As String = MyLanguage.GetLanguageFriendlyName(lang)
                  _lbPageLanguages.Items.Add(friendlyName)
               Next
            End If
         End Using
      End Sub

      Private Sub UpdateUIState()
         _btnDetectLanguages.Enabled = _lbSuggestedLanguages.SelectedItems.Count > 0
      End Sub

      Private Sub _lbSuggestedLanguages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _lbSuggestedLanguages.SelectedIndexChanged
         UpdateUIState()
      End Sub
   End Class
End Namespace
