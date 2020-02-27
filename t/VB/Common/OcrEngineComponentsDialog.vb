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
Imports System.Diagnostics
Imports System.Globalization

Imports Leadtools.Ocr

Partial Public Class OcrEngineComponentsDialog : Inherits Form
   Public Sub New(ByVal ocrEngine As IOcrEngine)
      InitializeComponent()

      ' Find all the supported and additional languages
      Dim languages As String() = ocrEngine.LanguageManager.GetSupportedLanguages()
      For Each language As String In languages
         Dim name As String = GetLanguageFriendlyName(language)
         _lbInstalledLanguages.Items.Add(name)
      Next language

      languages = ocrEngine.LanguageManager.GetAdditionalLanguages()
      If languages.Length > 0 Then
         _lbAdditionalLanguages.Visible = True
         _lblNoAdditionalLanguages.Visible = False

         For Each language As String In languages
            Dim name As String = GetLanguageFriendlyName(language)
            _lbAdditionalLanguages.Items.Add(name)
         Next language
      Else
         _lbAdditionalLanguages.Visible = False
         _lblNoAdditionalLanguages.Visible = True
      End If

      Dim spellCheckManager As IOcrSpellCheckManager = ocrEngine.SpellCheckManager
      If Not IsNothing(spellCheckManager) Then
         Dim spellLanguages() As String = spellCheckManager.GetSupportedSpellLanguages()
         For Each spellLanguage As String In spellLanguages
            Dim name As String = GetLanguageFriendlyName(spellLanguage)
            _lbInstalledDictionaries.Items.Add(name)
         Next

         spellLanguages = spellCheckManager.GetAdditionalSpellLanguages()
         For Each spellLanguage As String In spellLanguages
            Dim name As String = GetLanguageFriendlyName(spellLanguage)
            _lbAdditionalDictionaries.Items.Add(name)
         Next
      Else
         _tabMain.TabPages.Remove(_tpDictionaries)
      End If

      If ocrEngine.EngineType = OcrEngineType.LEAD Then
         If Not IsNothing(spellCheckManager) AndAlso spellCheckManager.SpellCheckEngine = OcrSpellCheckEngine.Hunspell Then
            _advantageEngineDictionariesNoteLabel.Text = "Select OCR/Spell CheckEngine for the Hunspell spell check engine additional dictionaries support."
         Else
            _advantageEngineDictionariesNoteLabel.Text = "Dictionaries support varies by the current spell engine. Select 'OCR/Spell check engine' from the main menu for more details."
         End If
      Else
         _advantageEngineDictionariesNoteLabel.Visible = False
      End If

      Dim installedEngineFormats() As String = ocrEngine.DocumentManager.GetSupportedEngineFormats()

      Dim additionalEngineFormats() As String = ocrEngine.DocumentManager.GetAdditionalEngineFormats()

      If installedEngineFormats.Length > 0 OrElse additionalEngineFormats.Length > 0 Then
         For Each format As String In installedEngineFormats
            _lbInstalledEngineFormats.Items.Add(format)
         Next

         For Each format As String In additionalEngineFormats
            _lbAdditionalEngineFormats.Items.Add(format)
         Next
      Else
         _tabMain.TabPages.Remove(_tpEngineFormats)
      End If

   End Sub

   Private Shared Function GetLanguageFriendlyName(ByVal language As String) As String
      Dim ci As CultureInfo

      Try
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
      Catch
         Return language
      End Try

      Return ci.EnglishName

   End Function

   Private Sub _lbDownload_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles _lbDownload.LinkClicked
      Process.Start(_lbDownload.Text)
   End Sub
End Class
