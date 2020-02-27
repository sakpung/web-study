' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Ocr

Public Class RecognizedWordsDialog
   Private _ocrDocument As IOcrDocument

   Public Sub New(ByVal ocrDocument As IOcrDocument)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      _ocrDocument = ocrDocument

      For i As Integer = 0 To _ocrDocument.Pages.Count - 1
         _pagesListBox.Items.Add("Page " + (i + 1).ToString())
      Next

      If (_pagesListBox.Items.Count > 0) Then
         _pagesListBox.SelectedIndex = 0
      End If

      ' change some of the words listbox in case of Arabic OCR for better words display.
      If _ocrDocument.Engine.EngineType = OcrEngineType.OmniPageArabic Then
         _wordsListBox.RightToLeft = RightToLeft.Yes
         _wordsListBox.Font = New System.Drawing.Font("Times New Roman", 10)
      End If
   End Sub

   Private Sub _pagesListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _pagesListBox.SelectedIndexChanged
      ' Get the recognized words of the selected page

      _wordsListBox.Items.Clear()

      Dim ocrPage As IOcrPage = _ocrDocument.Pages(_pagesListBox.SelectedIndex)
      If (ocrPage.IsRecognized) Then
         Dim pageCharacters As IOcrPageCharacters = ocrPage.GetRecognizedCharacters()
         If (IsNothing(pageCharacters)) Then
            Exit Sub
         End If

         For Each zoneCharacters As IOcrZoneCharacters In pageCharacters
            Dim words As ICollection(Of OcrWord) = zoneCharacters.GetWords()

            For Each word As OcrWord In words
               _wordsListBox.Items.Add(word.Value)
            Next
         Next
      End If
   End Sub
End Class
