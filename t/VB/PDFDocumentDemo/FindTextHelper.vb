' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace PDFDocumentDemo
   Friend Class FindTextHelper
      ' This is a helper for "Find" operations
      Private Structure FindWordItem
         Public BeginTextIndex As Integer ' Begin index into _currentPageText
         Public EndTextIndex As Integer ' Begin index into _currentPageText
         Public WordIndex As Integer ' Index into the DocumentWord array
      End Structure

      Private _findWordItems As FindWordItem()

      Private _currentPageText As String ' Current page text
      Private _findText As String ' Last text we used for "find"
      Private _lastFindWordIndex As Integer ' Index of the last word we found. Used in find next/find previous

      Public Sub New()
      End Sub

      Public Sub Reset()
         ' Reset the find text stuff
         _findWordItems = Nothing
         _lastFindWordIndex = -1
         _findText = String.Empty
      End Sub

      Private _gotoPageNumber As Integer
      Public ReadOnly Property GotoPageNumber() As Integer
         Get
            Return _gotoPageNumber
         End Get
      End Property

      Private _selectedWords As MyWord()
      Public Function GetSelectedWords() As MyWord()
         Return _selectedWords
      End Function

      Public Function FindText(documentText As Dictionary(Of Integer, MyWord()), currentPageNumber As Integer, pageCount As Integer, text As String, [next] As Boolean) As Boolean
         If String.Compare(text, _findText, StringComparison.OrdinalIgnoreCase) <> 0 Then
            ' New word
            _findText = text
         End If

         Dim startIndex As Integer = _lastFindWordIndex
         Dim pageNumberToCheck As Integer = currentPageNumber
         Dim stopCount As Integer = 0
         Dim index As Integer = -1
         While stopCount <> 2 AndAlso index = -1
            ' Get the page word items
            If _findWordItems Is Nothing Then
               ' Rebuild it
               BuildWordItems(documentText, pageNumberToCheck)

               If startIndex = -1 AndAlso Not [next] Then
                  startIndex = _currentPageText.Length - 1
               End If
            End If

            ' Try to find the text in the page
            If [next] Then
               index = _currentPageText.IndexOf(_findText, Math.Min(startIndex + 1, _currentPageText.Length), StringComparison.OrdinalIgnoreCase)
            Else
               index = _currentPageText.LastIndexOf(_findText, Math.Max(0, startIndex - 1), StringComparison.OrdinalIgnoreCase)
            End If

            If index = -1 Then
               _findWordItems = Nothing
               startIndex = -1

               ' Could not be found or reached the end of the page, try next (or previous) page
               If [next] Then
                  pageNumberToCheck += 1
                  If pageNumberToCheck > pageCount Then
                     pageNumberToCheck = 1
                  End If
               Else
                  pageNumberToCheck -= 1
                  If pageNumberToCheck < 1 Then
                     pageNumberToCheck = pageCount
                  End If
               End If

               If pageNumberToCheck = currentPageNumber Then
                  ' We looped back to original page, the count goes to 2 so we
                  ' do the same page upper or lower part in case we started in the middle
                  stopCount += 1
               End If
            End If
         End While

         If index <> -1 Then
            Dim words As MyWord() = Nothing
            If documentText(pageNumberToCheck) IsNot Nothing Then
               words = documentText(pageNumberToCheck)
            End If

            ' Found it, get the correspoding page word
            _lastFindWordIndex = index
            Dim lastIndex As Integer = index + _findText.Length - 1

            ' We found it, get the corresponding word(s)
            Dim selectedWords As New List(Of MyWord)()
            Dim inside As Boolean = False
            For Each item As FindWordItem In _findWordItems
               If Not inside AndAlso index >= item.BeginTextIndex AndAlso index <= item.EndTextIndex Then
                  ' First word in sentence
                  inside = True
               End If

               If inside Then
                  selectedWords.Add(words(item.WordIndex))
               End If

               ' Check if we reached end of sentence
               If inside AndAlso item.EndTextIndex >= lastIndex Then
                  ' part of sentence
                  Exit For
               End If
            Next

            _gotoPageNumber = pageNumberToCheck
            _selectedWords = selectedWords.ToArray()
            Return True
         Else
            Return False
         End If
      End Function

	  Private Sub BuildWordItems(documentText As Dictionary(Of Integer, MyWord()), pageNumber As Integer)
         Dim findWordItems As New List(Of FindWordItem)()

         Dim words As MyWord() = Nothing
         If documentText(pageNumber) IsNot Nothing Then
            words = documentText(pageNumber)
         End If

         If words IsNot Nothing Then
            Dim beginIndex As Integer = 0

            Dim sb As New StringBuilder()

            For wordIndex As Integer = 0 To words.Length - 1
               Dim word As MyWord = words(wordIndex)
               sb.Append(word.Value)

               ' Add it as a FindWordItem
               Dim item As New FindWordItem()
               item.BeginTextIndex = beginIndex
               item.EndTextIndex = beginIndex + word.Value.Length - 1
               item.WordIndex = wordIndex
               findWordItems.Add(item)

               sb.Append(" ")

               beginIndex = item.EndTextIndex + 2
            Next

            _currentPageText = sb.ToString()
         Else
            _currentPageText = String.Empty
         End If

         _findWordItems = findWordItems.ToArray()
      End Sub
   End Class
End Namespace
