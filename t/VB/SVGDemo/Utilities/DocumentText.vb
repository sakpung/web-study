' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Text

Imports Leadtools
Imports Leadtools.Svg
Imports System

Namespace SvgDemo
   <Flags()> _
   Public Enum DocumentCharacterPositions
      None
      EndOfWord
      EndOfLine
   End Enum

   <Serializable()> _
   Public Structure DocumentCharacter
      Private _code As Char
      Public Property Code() As Char
         Get
            Return _code
         End Get
         Set(value As Char)
            _code = value
         End Set
      End Property

      Private _bounds As LeadRectD
      Public Property Bounds() As LeadRectD
         Get
            Return _bounds
         End Get
         Set(value As LeadRectD)
            _bounds = value
         End Set
      End Property

      Private _positions As DocumentCharacterPositions
      Public Property Positions() As DocumentCharacterPositions
         Get
            Return _positions
         End Get
         Set(value As DocumentCharacterPositions)
            _positions = value
         End Set
      End Property

      Private _direction As SvgCharacterDirection
      Public Property Direction() As SvgCharacterDirection
         Get
            Return _direction
         End Get
         Set(value As SvgCharacterDirection)
            _direction = value
         End Set
      End Property
   End Structure

   <Serializable()> _
   Public Structure DocumentWord
      Private _value As String
      Public Property Value() As String
         Get
            Return _value
         End Get
         Set(value As String)
            _value = value
         End Set
      End Property

      Private _bounds As LeadRectD
      Public Property Bounds() As LeadRectD
         Get
            Return _bounds
         End Get
         Set(value As LeadRectD)
            _bounds = value
         End Set
      End Property

      Private _firstCharacterIndex As Integer
      Public Property FirstCharacterIndex() As Integer
         Get
            Return _firstCharacterIndex
         End Get
         Set(value As Integer)
            _firstCharacterIndex = value
         End Set
      End Property

      Private _lastCharacterIndex As Integer
      Public Property LastCharacterIndex() As Integer
         Get
            Return _lastCharacterIndex
         End Get
         Set(value As Integer)
            _lastCharacterIndex = value
         End Set
      End Property
   End Structure

   Public Class DocumentText
      Private Sub New(characters As List(Of DocumentCharacter))
         _characters = characters
      End Sub

      Public Sub New()
         _characters = New List(Of DocumentCharacter)()
      End Sub

      Public Shared Function FromSvgDocument(document As SvgDocument) As DocumentText
         ' Out list of charcaters
         Dim characters As List(Of DocumentCharacter) = New List(Of DocumentCharacter)()

         ' To strip whitespaces
         Dim hasWhitespaces As Boolean = False
         Dim prevCharacter As DocumentCharacter = New DocumentCharacter()

         ' Callback
         Dim sortCallback As SvgSortElementsCallback = Function(callabackDocument, info, userData)
                                                          ' Is it text?
                                                          Dim textData As SvgTextData = info.TextData
                                                          If textData IsNot Nothing Then
                                                             ' yes, does it have any characters?
                                                             Dim length As Integer = textData.Text.Length
                                                             For i As Integer = 0 To length - 1
                                                                ' Yes, convert to DocumentCharacter and add them to the list
                                                                Dim flags As SvgTextCharacterFlags = textData.CharacterFlags(i)
                                                                Dim positions As DocumentCharacterPositions = DocumentCharacterPositions.None
                                                                If (flags And SvgTextCharacterFlags.EndOfWord) = SvgTextCharacterFlags.EndOfWord Then
                                                                   positions = positions Or DocumentCharacterPositions.EndOfWord
                                                                End If
                                                                If (flags And SvgTextCharacterFlags.EndOfLine) = SvgTextCharacterFlags.EndOfLine Then
                                                                   positions = positions Or DocumentCharacterPositions.EndOfLine
                                                                End If

                                                                Dim character As DocumentCharacter = New DocumentCharacter() With { _
                                                                   .Code = textData.Text(i), _
                                                                   .Bounds = textData.Bounds(i), _
                                                                   .Positions = positions, _
                                                                   .Direction = textData.Directions(i) _
                                                                }

                                                                ' If the character duplicated, then remove the old one
                                                                If prevCharacter.Bounds = character.Bounds AndAlso prevCharacter.Code = character.Code AndAlso prevCharacter.Direction = character.Direction Then
                                                                   characters.Remove(prevCharacter)
                                                                End If

                                                                characters.Add(character)

                                                                If Not hasWhitespaces AndAlso [Char].IsWhiteSpace(character.Code) Then
                                                                   hasWhitespaces = True
                                                                End If

                                                                prevCharacter = character
                                                             Next
                                                          End If

                                                          Return True

                                                       End Function

         ' Accept text elements only.
         Dim filterElementsCallback As SvgFilterElementsCallback = Function(svgDocument, node, userData)
                                                                      ' Accept text elements only.
                                                                      If node.ElementType <> SvgElementType.Text Then
                                                                         Return False
                                                                      End If

                                                                      Return True

                                                                   End Function

         ' Setup options and sort
         Dim options As SvgSortOptions = New SvgSortOptions() With { _
            .ExtractText = SvgExtractText.Character, _
            .SortFlags = SvgSortFlags.[Default] _
         }

         document.SetFilterElementsCallback(filterElementsCallback, Nothing)
         document.SortElements(options, sortCallback, Nothing)
         document.SetFilterElementsCallback(Nothing, Nothing)

         ' Characters is set, before using it, strip the whitespaces
         If hasWhitespaces Then
            Dim temp As List(Of DocumentCharacter) = New List(Of DocumentCharacter)()
            Dim count As Integer = characters.Count
            Dim positions As DocumentCharacterPositions = DocumentCharacterPositions.None
            Dim newIndex As Integer = -1
            For index As Integer = 0 To count - 1
               Dim character As DocumentCharacter = characters(index)

               ' If this character is a whitespace, dont add it, just steal its position and add it to the previous character
               If [Char].IsWhiteSpace(character.Code) Then
                  positions = positions Or character.Positions
               Else
                  ' If have stolen flags from dropping white space characters, add them to the last non-white space character
                  If positions <> DocumentCharacterPositions.None Then
                     If newIndex <> -1 Then
                        Dim tempCharacter As DocumentCharacter = temp(newIndex)
                        tempCharacter.Positions = tempCharacter.Positions Or positions
                        temp(newIndex) = tempCharacter
                     End If

                     positions = DocumentCharacterPositions.None
                  End If

                  ' Add it
                  temp.Add(character)
                  newIndex += 1
               End If
            Next

            characters = temp
         End If

         Dim result As DocumentText = New DocumentText(characters)
         Return result
      End Function

      Private _characters As List(Of DocumentCharacter)

      Public ReadOnly Property Characters() As IList(Of DocumentCharacter)
         Get
            Return _characters
         End Get
      End Property

      Private _words As IList(Of DocumentWord)

      Public ReadOnly Property Words() As IList(Of DocumentWord)
         Get
            Return _words
         End Get
      End Property

      Public Sub BuildWords()
         Dim characterIndex As Integer = 0
         Dim characterCount As Integer = _characters.Count

         Dim words As List(Of DocumentWord) = New List(Of DocumentWord)()
         Dim lastReverseWord As Boolean = False
         Dim startReverseIndex As Integer = -1

         ' Loop through all the characters
         While characterIndex < characterCount
            ' Find the total bounding rectangle, begin and end index of the next word
            Dim wordBounds As LeadRectD = LeadRectD.Empty
            Dim beginCharacterIndex As Integer = characterIndex
            Dim reverseWord As Boolean = False

            ' Loop till we reach the EndOfWord of EndOfLine
            Dim more As Boolean = True
            Dim character As DocumentCharacter = New DocumentCharacter()
            While more AndAlso characterIndex < characterCount
               character = _characters(characterIndex)

               ' Add the bounding rectangle of this character
               Dim characterBounds As LeadRectD = character.Bounds

               If wordBounds.IsEmpty Then
                  wordBounds = characterBounds
               Else
                  wordBounds = LeadRectD.UnionRects(wordBounds, characterBounds)
               End If

               more = characterIndex < characterCount AndAlso (character.Positions And DocumentCharacterPositions.EndOfWord) <> DocumentCharacterPositions.EndOfWord AndAlso (character.Positions And DocumentCharacterPositions.EndOfLine) <> DocumentCharacterPositions.EndOfLine

               characterIndex += 1

               If character.Direction = SvgCharacterDirection.RightToLeft Then
                  reverseWord = True
               End If
            End While

            ' From the begin and end index, collect the characters into a string
            Dim sb As StringBuilder = New StringBuilder()
            For i As Integer = beginCharacterIndex To characterIndex - 1
               sb.Append(_characters(i).Code)
            Next

            Dim word As DocumentWord = New DocumentWord()
            word.Value = sb.ToString()
            word.Bounds = wordBounds
            word.FirstCharacterIndex = beginCharacterIndex
            word.LastCharacterIndex = characterIndex - 1

            If reverseWord Then
               Dim charArray As Char() = word.Value.ToCharArray()
               Dim startIndex As Integer = 0
               For i As Integer = 0 To charArray.Length - 1
                  Dim nextIndex As Integer = i + 1
                  If _characters(i + word.FirstCharacterIndex).Direction = SvgCharacterDirection.RightToLeft AndAlso (nextIndex >= charArray.Length OrElse _characters(nextIndex + word.FirstCharacterIndex).Direction = SvgCharacterDirection.LeftToRight) Then
                     Array.Reverse(charArray, startIndex, nextIndex - startIndex)
                     startIndex = i
                  End If
               Next

               word.Value = New String(charArray)
            End If


            If lastReverseWord AndAlso reverseWord Then
               startReverseIndex = If(startReverseIndex = -1, words.Count - 1, startReverseIndex)
               words.Insert(startReverseIndex, word)
            Else
               If startReverseIndex <> -1 Then
                  ReverseCharacterPositions(words(startReverseIndex).LastCharacterIndex, words(words.Count - 1).LastCharacterIndex)
                  startReverseIndex = -1
               End If
               words.Add(word)
            End If

            lastReverseWord = reverseWord AndAlso (character.Positions And DocumentCharacterPositions.EndOfLine) <> DocumentCharacterPositions.EndOfLine
         End While

         If startReverseIndex <> -1 Then
            ReverseCharacterPositions(words(startReverseIndex).LastCharacterIndex, words(words.Count - 1).LastCharacterIndex)
         End If

         _words = words
      End Sub

      Private Sub ReverseCharacterPositions(index1 As Integer, index2 As Integer)
         Dim tempPos As DocumentCharacterPositions = _characters(index1).Positions

         Dim tempCharacter As DocumentCharacter = _characters(index1)
         tempCharacter.Positions = _characters(index2).Positions
         _characters(index1) = tempCharacter

         tempCharacter = _characters(index2)
         tempCharacter.Positions = tempPos
         _characters(index2) = tempCharacter
      End Sub

      Public Function BuildText() As String
         If _words IsNot Nothing AndAlso _characters Is Nothing Then
            BuildWords()
         End If

         If _words Is Nothing OrElse _words.Count = 0 Then
            Return String.Empty
         End If

         Dim sb As StringBuilder = New StringBuilder()
         Dim wordCount As Integer = _words.Count
         Dim wordIndex As Integer = 0
         While wordIndex < wordCount
            Dim word As DocumentWord = _words(wordIndex)
            If Not String.IsNullOrEmpty(word.Value) Then
               sb.Append(word.Value)
            End If

            Dim positions As Integer = DocumentCharacterPositions.None
            If word.LastCharacterIndex <> -1 Then
               positions = _characters(word.LastCharacterIndex).Positions
            End If

            Dim lastWord As Boolean = (wordIndex = wordCount - 1)

            If (positions And DocumentCharacterPositions.EndOfLine) = DocumentCharacterPositions.EndOfLine Then
               If Not lastWord Then
                  sb.AppendLine()
               End If
            ElseIf Not lastWord Then
               sb.Append(" ")
            End If

            wordIndex += 1
         End While

         Return sb.ToString()
      End Function
   End Class
End Namespace
