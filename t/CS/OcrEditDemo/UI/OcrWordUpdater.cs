// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
// In LEADTOOLS v17.5, we added IOcrPageCharacters.UpdateWord method
// that performs most of the functionality available in OcrWordUpdater
// So, for this version of LEADTOOLS. If you wish to use the old
// OcrWordUpdater included with this demo, then undefined the symbol
// below

#if LEADTOOLS_V175_OR_LATER
#define USE_TOOLKIT_WORD_UPDATER
#endif // #if LEADTOOLS_V175_OR_LATER

#if !USE_TOOLKIT_WORD_UPDATER

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

using Leadtools;
using Leadtools.Ocr;

namespace OcrEditDemo
{
   static class OcrWordUpdater
   {
      private static Font GetWordFont(OcrCharacter templateCharacter, float dpiY)
      {
         string fontFamilyName;

         if((templateCharacter.FontStyle & OcrCharacterFontStyle.Proportional) == OcrCharacterFontStyle.Proportional)
         {
            if((templateCharacter.FontStyle & OcrCharacterFontStyle.Serif) == OcrCharacterFontStyle.Serif)
               fontFamilyName = "Times New Roman";
            else
               fontFamilyName = "Arial";
         }
         else
         {
            if((templateCharacter.FontStyle & OcrCharacterFontStyle.Serif) == OcrCharacterFontStyle.Serif)
               fontFamilyName = "Courier New";
            else
               fontFamilyName = "Arial";
         }

         FontStyle style = FontStyle.Regular;

         if((templateCharacter.FontStyle & OcrCharacterFontStyle.Bold) == OcrCharacterFontStyle.Bold)
            style |= FontStyle.Bold;
         if((templateCharacter.FontStyle & OcrCharacterFontStyle.Italic) == OcrCharacterFontStyle.Italic)
            style |= FontStyle.Italic;
         if((templateCharacter.FontStyle & OcrCharacterFontStyle.Underline) == OcrCharacterFontStyle.Underline)
            style |= FontStyle.Underline;

         // Calculate the size in points
         float emSize = templateCharacter.FontSize * dpiY / 96.0F;

         Font theFont = new Font(fontFamilyName, emSize, style);

         return theFont;
      }

      private static void DeleteWordCharacters(OcrWord word, IOcrZoneCharacters zoneCharacters)
      {
         // Merge the position flags of the last character we are deleting with the one from the
         // previous word (if any), so if the word we are deleting has EndOfLine or EndOfZone, we
         // save this info in the previous word
         int firstCharacterIndex = word.FirstCharacterIndex;
         int lastCharacterIndex = word.LastCharacterIndex;

         if(firstCharacterIndex > 0)
         {
            OcrCharacterPosition position = zoneCharacters[lastCharacterIndex].Position;
            OcrCharacter tempCharacter = zoneCharacters[firstCharacterIndex - 1];
            tempCharacter.Position |= position;
            zoneCharacters[firstCharacterIndex - 1] = tempCharacter;
         }

         // Remove the characters
         int toRemoveCount = lastCharacterIndex - firstCharacterIndex + 1;
         while(toRemoveCount > 0)
         {
            zoneCharacters.RemoveAt(firstCharacterIndex);
            toRemoveCount--;
         }
      }

      public static void Update(int zoneIndex, int wordIndex, string value, IOcrPage ocrPage, List<List<OcrWord>> zoneWords, IOcrPageCharacters ocrPageCharacters)
      {
         // Find the zone characters we are looking for
         // Find the word we are looking for
         IOcrZoneCharacters zoneCharacters = ocrPageCharacters[zoneIndex];
         OcrWord word = zoneWords[zoneIndex][wordIndex];

         // OcrCharacter.Bounds does not expect the leading and external leading spaces
         // used when drawing normal text

         // First, we need to calculate the size of the original string and then the new
         // value using the same font. This way, we can calculate the offsets used on the
         // left and on top so we can find the new word value

         // We do not support spaces around the word
         if(value != null)
            value = value.Trim();

         // If the value did not change, don't do anything
         if(value == word.Value)
            return;

         // Get the first character to use as a template for creating the font
         OcrCharacter templateCharacter = zoneCharacters[word.FirstCharacterIndex];

         float dpiX = ocrPage.DpiX;
         float dpiY = ocrPage.DpiY;

         // Use a temporary bitmap object to get its Graphics object
         using(Bitmap btmp = new Bitmap(1, 1))
         {
            using(Graphics g = Graphics.FromImage(btmp))
            {
               // Do not use anti-aliasing for better calculations
               g.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

               // Create the font used to draw this word
               using(Font theFont = GetWordFont(templateCharacter, dpiY))
               {
                  // Measure the old string and compare against the word bounds reported from
                  // OCR

                  PointF wordPosition = PointF.Empty;
                  float baselineOffset = 0;

                  SizeF oldWordBounds = SizeF.Empty;
                  if(!string.IsNullOrEmpty(word.Value))
                  {
                     RectangleF ocrWordBounds = Leadtools.Demos.Converters.ConvertRect(word.Bounds.ToRectangle(dpiX, dpiY));
                     oldWordBounds = g.MeasureString(word.Value, theFont, PointF.Empty, StringFormat.GenericDefault);

                     wordPosition = new PointF(ocrWordBounds.X - (oldWordBounds.Width - ocrWordBounds.Width) / 2, ocrWordBounds.Y - (oldWordBounds.Height - ocrWordBounds.Height) / 2);

                     // Calculate the baseline offset of this font
                     float baselineOffsetPoints = theFont.SizeInPoints / theFont.FontFamily.GetEmHeight(theFont.Style) * theFont.FontFamily.GetCellAscent(theFont.Style);
                     baselineOffset = g.DpiY / 72.0F * baselineOffsetPoints;
                  }

                  // Save the insertion point and the position flags for the last character so we can
                  // re-use it (in case, it has an EndOfLine or EndOfZone flags set)
                  int insertionIndex = word.FirstCharacterIndex;
                  OcrCharacterPosition lastCharacterPosition = zoneCharacters[word.LastCharacterIndex].Position;
                  DeleteWordCharacters(word, zoneCharacters);

                  // Rebuild the zone words
                  zoneWords[zoneIndex].Clear();
                  zoneWords[zoneIndex].AddRange(zoneCharacters.GetWords((int)dpiX, (int)dpiY, LogicalUnit.Pixel));

                  if(!string.IsNullOrEmpty(value))
                  {
                     // Now add the characters of the new word
                     SizeF stringSizeLeft = g.MeasureString(value, theFont, PointF.Empty, StringFormat.GenericDefault);
                     float emSize = theFont.Size * g.DpiY / 72.0F;

                     // The string might have space characters in the middle, we don't want to
                     // add them since most of the OCR engines do not support a space character
                     string[] wordParts = value.Split(new char[] { ' ' });
                     int wordCharacterIndex = 0;

                     List<OcrCharacter> characters = new List<OcrCharacter>();

                     foreach(string wordPart in wordParts)
                     {
                        SizeF currentStringSize;
                        // Fix for bug 12953 on FileMaker.
                        if(ocrPage.Document.Engine.EngineType == OcrEngineType.Arabic)
                        {
                           if (stringSizeLeft.Width > oldWordBounds.Width)
                              wordPosition.X -= Math.Abs(stringSizeLeft.Width - oldWordBounds.Width);
                           else if (stringSizeLeft.Width < oldWordBounds.Width)
                              wordPosition.X += Math.Abs(stringSizeLeft.Width - oldWordBounds.Width);
                        }

                        // Process the characters of this part
                        for(int wordPartCharacterIndex = 0; wordPartCharacterIndex < wordPart.Length; wordPartCharacterIndex++)
                        {
                           // We are going to use a GraphicsPath object to draw character on top
                           // Then use the path GetBounds method to get the exact bounding box we need

                           string characterString = wordPart.Substring(wordPartCharacterIndex, 1);

                           using(GraphicsPath path = new GraphicsPath())
                           {
                              path.AddString(characterString, theFont.FontFamily, (int)theFont.Style, emSize, wordPosition, StringFormat.GenericDefault);

                              RectangleF bounds = path.GetBounds();

                              // Build a character and add it
                              OcrCharacter newCharacter = templateCharacter;
                              newCharacter.Code = wordPart[wordPartCharacterIndex];
                              newCharacter.Bounds = new LogicalRectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height, LogicalUnit.Pixel);
                              newCharacter.Base = LogicalLength.FromPixels(wordPosition.Y + baselineOffset - bounds.Y);

                              // We will assume this character is not the last one so we clear all the flags
                              newCharacter.Position = OcrCharacterPosition.None;

                              characters.Add(newCharacter);
                           }

                           // Subtract the part of the string we draw from the overall string size so we know the position of the next character
                           currentStringSize = g.MeasureString(value.Substring(wordCharacterIndex + 1), theFont, PointF.Empty, StringFormat.GenericDefault);
                           wordPosition.X += stringSizeLeft.Width - currentStringSize.Width;
                           stringSizeLeft = currentStringSize;
                           wordCharacterIndex++;
                        }

                        // Add EndOfWord to the character we just inserted
                        if(wordCharacterIndex > 0)
                        {
                           OcrCharacter character = characters[characters.Count - 1];
                           character.Position |= OcrCharacterPosition.EndOfWord;
                           characters[characters.Count - 1] = character;
                        }

                        // Move a space (if any)
                        if(wordCharacterIndex < (value.Length - 1))
                        {
                           currentStringSize = g.MeasureString(value.Substring(wordCharacterIndex + 1), theFont, PointF.Empty, StringFormat.GenericDefault);
                           wordPosition.X += stringSizeLeft.Width - currentStringSize.Width;
                           stringSizeLeft = currentStringSize;
                           wordCharacterIndex++;
                        }

                        // If this is the last character in the over all word, re-add the original position flags
                        // if any (EndOfLine, EndOfZone, etc)
                        if(wordCharacterIndex == value.Length)
                        {
                           OcrCharacter character = characters[characters.Count - 1];
                           character.Position |= lastCharacterPosition;
                           characters[characters.Count - 1] = character;
                        }
                     }

                     // Now add these new characters to the zone
                     int index = insertionIndex;
                     foreach(OcrCharacter character in characters)
                        zoneCharacters.Insert(index++, character);

                     // Rebuild the zone words
                     zoneWords[zoneIndex].Clear();
                     zoneWords[zoneIndex].AddRange(zoneCharacters.GetWords((int)dpiX, (int)dpiY, LogicalUnit.Pixel));
                  }
               }
            }
         }
      }
   }
}

#endif // #if !USE_TOOLKIT_WORD_UPDATER
