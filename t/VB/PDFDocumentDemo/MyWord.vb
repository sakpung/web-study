' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Text

Imports Leadtools
Imports Leadtools.Pdf

Namespace PDFDocumentDemo
   Public Class MyWord
      Private _bounds As LeadRect
      Public Property Bounds() As LeadRect
         Get
            Return _bounds
         End Get
         Set(value As LeadRect)
            _bounds = value
         End Set
      End Property

      Private _value As String
      Public Property Value() As String
         Get
            Return _value
         End Get
         Set(value As String)
            _value = value
         End Set
      End Property

      Private _isEndOfLine As Boolean
      Public Property IsEndOfLine() As Boolean
         Get
            Return _isEndOfLine
         End Get
         Set(value As Boolean)
            _isEndOfLine = value
         End Set
      End Property

      Public Shared Function BuildWord(document As PDFDocument) As Dictionary(Of Integer, MyWord())
         Dim pageWords As New Dictionary(Of Integer, MyWord())()
         For pageNumber As Integer = 1 To document.Pages.Count
            Dim words As New List(Of MyWord)()

            Dim page As PDFDocumentPage = document.Pages(pageNumber - 1)
            Dim objects As IList(Of PDFObject) = page.Objects
            If objects IsNot Nothing AndAlso objects.Count > 0 Then
               Dim objectIndex As Integer = 0
               Dim objectCount As Integer = objects.Count

               ' Loop through all the objects
               While objectIndex < objectCount
                  ' Find the total bounding rectangle, begin and end index of the next word
                  Dim wordBounds As LeadRect = LeadRect.Empty
                  Dim firstObjectIndex As Integer = objectIndex

                  ' Loop till we reach EndOfWord or reach the end of the objects
                  Dim more As Boolean = True
                  While more
                     Dim obj As PDFObject = objects(objectIndex)

                     ' Must be text and not a white character
                     If obj.ObjectType = PDFObjectType.Text AndAlso Not Char.IsWhiteSpace(obj.Code) Then
                        ' Add the bounding rectangle of this object
                        Dim temp As PDFRect = page.ConvertRect(PDFCoordinateType.Pdf, PDFCoordinateType.Pixel, obj.Bounds)
                        Dim objectBounds As LeadRect = LeadRect.FromLTRB(CInt(temp.Left), CInt(temp.Top), CInt(temp.Right), CInt(temp.Bottom))

                        If wordBounds.IsEmpty Then
                           wordBounds = objectBounds
                        Else
                           wordBounds = LeadRect.Union(wordBounds, objectBounds)
                        End If
                     Else
                        firstObjectIndex = objectIndex + 1
                     End If

                     objectIndex += 1
                     more = (objectIndex < objectCount) AndAlso Not obj.TextProperties.IsEndOfWord AndAlso Not obj.TextProperties.IsEndOfLine
                  End While

                  If firstObjectIndex = objectIndex Then
                     Continue While
                  End If

                  ' From the begin and end index, collect the characters into a string
                  Dim sb As New StringBuilder()
                  For i As Integer = firstObjectIndex To objectIndex - 1
                     If objects(i).ObjectType = PDFObjectType.Text Then
                        sb.Append(objects(i).Code)
                     End If
                  Next

                  ' Add this word to the list

                  Dim lastObject As PDFObject = objects(objectIndex - 1)

                  Dim word As New MyWord()
                  word.Value = sb.ToString()
                  word.Bounds = wordBounds
                  word.IsEndOfLine = lastObject.TextProperties.IsEndOfLine

                  words.Add(word)
               End While
            End If

            ' Add "IsEndOfLine" to the last word in the page, just in case it does not have it
            If words.Count > 0 Then
               Dim word As MyWord = words(words.Count - 1)
               word.IsEndOfLine = True
               words(words.Count - 1) = word
            End If

            pageWords.Add(pageNumber, words.ToArray())
         Next

         Return pageWords
      End Function
   End Class
End Namespace
