' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
' In LEADTOOLS v17.5, we added IOcrPageCharacters.UpdateWord method
' that performs most of the functionality available in OcrWordUpdater
' So, for this version of LEADTOOLS. If you wish to use the old
' OcrWordUpdater included with this demo, then undefined the symbol
' below

#Const USE_TOOLKIT_WORD_UPDATER = True

#If Not USE_TOOLKIT_WORD_UPDATER Then

Imports System.Drawing
Imports System.Drawing.Text
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Ocr

NotInheritable Class OcrWordUpdater
   Private Shared Function GetWordFont(ByVal templateCharacter As OcrCharacter, ByVal dpiY As Single) As Font
      Dim fontFamilyName As String

      If (templateCharacter.FontStyle And OcrCharacterFontStyle.Proportional) = OcrCharacterFontStyle.Proportional Then
         If (templateCharacter.FontStyle And OcrCharacterFontStyle.Serif) = OcrCharacterFontStyle.Serif Then
            fontFamilyName = "Times New Roman"
         Else
            fontFamilyName = "Arial"
         End If
      Else
         If (templateCharacter.FontStyle And OcrCharacterFontStyle.Serif) = OcrCharacterFontStyle.Serif Then
            fontFamilyName = "Courier New"
         Else
            fontFamilyName = "Arial"
         End If
      End If

      Dim style As FontStyle = FontStyle.Regular

      If (templateCharacter.FontStyle And OcrCharacterFontStyle.Bold) = OcrCharacterFontStyle.Bold Then
         style = style Or FontStyle.Bold
      End If
      If (templateCharacter.FontStyle And OcrCharacterFontStyle.Italic) = OcrCharacterFontStyle.Italic Then
         style = style Or FontStyle.Italic
      End If
      If (templateCharacter.FontStyle And OcrCharacterFontStyle.Underline) = OcrCharacterFontStyle.Underline Then
         style = style Or FontStyle.Underline
      End If
      If (templateCharacter.FontStyle And OcrCharacterFontStyle.Bold) = OcrCharacterFontStyle.Bold Then
         style = style Or FontStyle.Bold
      End If

      ' Calculate the size in points
      Dim emSize As Single = templateCharacter.FontSize * dpiY / 96.0F

      Dim theFont As New Font(fontFamilyName, emSize, style)

      Return theFont
   End Function

   Private Shared Sub DeleteWordCharacters(ByVal word As OcrWord, ByVal zoneCharacters As IOcrZoneCharacters)
      ' Merge the position flags of the last character we are deleting with the one from the
      ' previous word (if any), so if the word we are deleting has EndOfLine or EndOfZone, we
      ' save this info in the previous word
      Dim firstCharacterIndex As Integer = word.FirstCharacterIndex
      Dim lastCharacterIndex As Integer = word.LastCharacterIndex

      If firstCharacterIndex > 0 Then
         Dim position As OcrCharacterPosition = zoneCharacters(lastCharacterIndex).Position
         Dim tempCharacter As OcrCharacter = zoneCharacters(firstCharacterIndex - 1)
         tempCharacter.Position = tempCharacter.Position Or position
         zoneCharacters(firstCharacterIndex - 1) = tempCharacter
      End If

      ' Remove the characters
      Dim toRemoveCount As Integer = lastCharacterIndex - firstCharacterIndex + 1
      While toRemoveCount > 0
         zoneCharacters.RemoveAt(firstCharacterIndex)
         toRemoveCount = toRemoveCount - 1
      End While
   End Sub

   Public Shared Sub Update(ByVal zoneIndex As Integer, ByVal wordIndex As Integer, ByVal value As String, ByVal ocrPage As IOcrPage, ByVal zoneWords As List(Of List(Of OcrWord)), ByVal ocrPageCharacters As IOcrPageCharacters)
      ' Find the zone characters we are looking for
      ' Find the word we are looking for
      Dim zoneCharacters As IOcrZoneCharacters = ocrPageCharacters(zoneIndex)
      Dim word As OcrWord = zoneWords(zoneIndex)(wordIndex)

      ' OcrCharacter.Bounds does not expect the leading and external leading spaces
      ' used when drawing normal text

      ' First, we need to calculate the size of the original string and then the new
      ' value using the same font. This way, we can calculate the offsets used on the
      ' left and on top so we can find the new word value

      ' We do not support spaces around the word
      If Not IsNothing(value) Then
         value = value.Trim()
      End If

      ' If the value did not change, don't do anything
      If value = word.Value Then
         Return
      End If

      ' Get the first character to use as a template for creating the font
      Dim templateCharacter As OcrCharacter = zoneCharacters(word.FirstCharacterIndex)

      Dim dpiX As Single = ocrPage.DpiX
      Dim dpiY As Single = ocrPage.DpiY

      ' Use a temporary bitmap object to get its Graphics object
      Using btmp As New Bitmap(1, 1)
         Dim g As Graphics = Graphics.FromImage(btmp)
         ' Do not use anti-aliasing for better calculations
         g.TextRenderingHint = TextRenderingHint.SingleBitPerPixel

         ' Create the font used to draw this word
         Using theFont As Font = GetWordFont(templateCharacter, dpiY)
            ' Measure the old string and compare against the word bounds reported from
            ' OCR

            Dim wordPosition As PointF = PointF.Empty
            Dim baselineOffset As Single = 0

            Dim oldWordBounds As SizeF = SizeF.Empty
            If Not String.IsNullOrEmpty(word.Value) Then
               Dim r As LeadRect = word.Bounds.ToRectangle(dpiX, dpiY)
               Dim ocrWordBounds As RectangleF = New RectangleF(r.Left, r.Top, r.Width, r.Height)
               oldWordBounds = g.MeasureString(word.Value, theFont, PointF.Empty, StringFormat.GenericDefault)

               wordPosition = New PointF(ocrWordBounds.X - (oldWordBounds.Width - ocrWordBounds.Width) / 2, ocrWordBounds.Y - (oldWordBounds.Height - ocrWordBounds.Height) / 2)

               ' Calculate the baseline offset of this font
               Dim baselineOffsetPoints As Single = theFont.SizeInPoints / theFont.FontFamily.GetEmHeight(theFont.Style) * theFont.FontFamily.GetCellAscent(theFont.Style)
               baselineOffset = g.DpiY / 72.0F * baselineOffsetPoints
            End If

            ' Save the insertion point and the position flags for the last character so we can
            ' re-use it (in case, it has an EndOfLine or EndOfZone flags set)
            Dim insertionIndex As Integer = word.FirstCharacterIndex
            Dim lastCharacterPosition As OcrCharacterPosition = zoneCharacters(word.LastCharacterIndex).Position
            DeleteWordCharacters(word, zoneCharacters)

            ' Rebuild the zone words
            zoneWords(zoneIndex).Clear()
            zoneWords(zoneIndex).AddRange(zoneCharacters.GetWords(CType(dpiX, Integer), CType(dpiY, Integer), LogicalUnit.Pixel))

            If Not String.IsNullOrEmpty(value) Then
               ' Now add the characters of the new word
               Dim stringSizeLeft As SizeF = g.MeasureString(value, theFont, PointF.Empty, StringFormat.GenericDefault)
               Dim emSize As Single = theFont.Size * g.DpiY / 72.0F

               ' The string might have space characters in the middle, we don't want to
               ' add them since most of the OCR engines do not support a space character
               Dim wordParts() As String = value.Split(New Char() {" "c})
               Dim wordCharacterIndex As Integer

               Dim characters As New List(Of OcrCharacter)

               For Each wordPart As String In wordParts
                  Dim currentStringSize As SizeF

                  ' Fix for bug 12953 on FileMaker.
                  If (ocrPage.Document.Engine.EngineType = OcrEngineType.OmniPageArabic) Then
                     If (stringSizeLeft.Width > oldWordBounds.Width) Then
                        wordPosition.X -= Math.Abs(stringSizeLeft.Width - oldWordBounds.Width)
                     ElseIf (stringSizeLeft.Width < oldWordBounds.Width) Then
                        wordPosition.X += Math.Abs(stringSizeLeft.Width - oldWordBounds.Width)
                     End If
                  End If

                  ' Process the characters of this part
                  For wordPartCharacterIndex As Integer = 0 To wordPart.Length - 1
                     ' We are going to use a GraphicsPath object to draw character on top
                     ' Then use the path GetBounds method to get the exact bounding box we need

                     Dim characterString As String = wordPart.Substring(wordPartCharacterIndex, 1)

                     Using path As New GraphicsPath()
                        path.AddString(characterString, theFont.FontFamily, CType(theFont.Style, Integer), emSize, wordPosition, StringFormat.GenericDefault)

                        Dim bounds As RectangleF = path.GetBounds()

                        ' Build a character and add it
                        Dim newCharacter As OcrCharacter = templateCharacter
                        newCharacter.Code = wordPart(wordPartCharacterIndex)
                        newCharacter.Bounds = New LogicalRectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height, LogicalUnit.Pixel)
                        newCharacter.Base = LogicalLength.FromPixels(wordPosition.Y + baselineOffset - bounds.Y)

                        ' We will assume this character is not the last one so we clear all the flags
                        newCharacter.Position = OcrCharacterPosition.None

                        characters.Add(newCharacter)
                     End Using

                     ' Subtract the part of the string we draw from the overall string size so we know the position of the next character
                     currentStringSize = g.MeasureString(value.Substring(wordCharacterIndex + 1), theFont, PointF.Empty, StringFormat.GenericDefault)
                     wordPosition.X = wordPosition.X + stringSizeLeft.Width - currentStringSize.Width
                     stringSizeLeft = currentStringSize
                     wordCharacterIndex = wordCharacterIndex + 1
                  Next

                  ' Add EndOfWord to the character we just inserted
                  If wordCharacterIndex > 0 Then
                     Dim character As OcrCharacter = characters(characters.Count - 1)
                     character.Position = character.Position Or OcrCharacterPosition.EndOfWord
                     characters(characters.Count - 1) = character
                  End If

                  ' Move a space (if any)
                  If wordCharacterIndex < (value.Length - 1) Then
                     currentStringSize = g.MeasureString(value.Substring(wordCharacterIndex + 1), theFont, PointF.Empty, StringFormat.GenericDefault)
                     wordPosition.X = wordPosition.X + stringSizeLeft.Width - currentStringSize.Width
                     stringSizeLeft = currentStringSize
                     wordCharacterIndex = wordCharacterIndex + 1
                  End If

                  ' If this is the last character in the over all word, re-add the original position flags
                  ' if any (EndOfLine, EndOfZone, etc)
                  If wordCharacterIndex = value.Length Then
                     Dim character As OcrCharacter = characters(characters.Count - 1)
                     character.Position = character.Position Or lastCharacterPosition
                     characters(characters.Count - 1) = character
                  End If
               Next

               ' Now add these new characters to the zone
               Dim index As Integer = insertionIndex
               For Each character As OcrCharacter In characters
                  zoneCharacters.Insert(index, character)
                  index = index + 1
               Next

               ' Rebuild the zone words
               zoneWords(zoneIndex).Clear()
               zoneWords(zoneIndex).AddRange(zoneCharacters.GetWords(CType(dpiX, Integer), CType(dpiY, Integer), LogicalUnit.Pixel))
            End If
         End Using
      End Using
   End Sub
End Class

#End If ' #If Not USE_TOOLKIT_WORD_UPDATER
