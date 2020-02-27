// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools;
using Leadtools.Svg;

namespace SvgDemo
{
   [Flags]
   public enum DocumentCharacterPositions
   {
      None,
      EndOfWord,
      EndOfLine
   }

   [Serializable]
   public struct DocumentCharacter
   {
      private char _code;
      public char Code
      {
         get { return _code; }
         set { _code = value; }
      }

      private LeadRectD _bounds;
      public LeadRectD Bounds
      {
         get { return _bounds; }
         set { _bounds = value; }
      }

      private DocumentCharacterPositions _positions;
      public DocumentCharacterPositions Positions
      {
         get { return _positions; }
         set { _positions = value; }
      }

      private SvgCharacterDirection _direction;
      public SvgCharacterDirection Direction
      {
         get { return _direction; }
         set { _direction = value; }
      }
   }

   [Serializable]
   public struct DocumentWord
   {
      private string _value;
      public string Value
      {
         get { return _value; }
         set { _value = value; }
      }

      private LeadRectD _bounds;
      public LeadRectD Bounds
      {
         get { return _bounds; }
         set { _bounds = value; }
      }

      private int _firstCharacterIndex;
      public int FirstCharacterIndex
      {
         get { return _firstCharacterIndex; }
         set { _firstCharacterIndex = value; }
      }

      private int _lastCharacterIndex;
      public int LastCharacterIndex
      {
         get { return _lastCharacterIndex; }
         set { _lastCharacterIndex = value; }
      }
   }

   public class DocumentText
   {
      private DocumentText(List<DocumentCharacter> characters)
      {
         _characters = characters;
      }

      public DocumentText()
      {
         _characters = new List<DocumentCharacter>();
      }

      public static DocumentText FromSvgDocument(SvgDocument document)
      {
         // Out list of charcaters
         var characters = new List<DocumentCharacter>();

         // To strip whitespaces
         var hasWhitespaces = false;
         var prevCharacter = new DocumentCharacter();

         // Callback
         SvgSortElementsCallback sortCallback = (callabackDocument, info, userData) =>
         {
            // Is it text?
            var textData = info.TextData;
            if (textData != null)
            {
               // yes, does it have any characters?
               var length = textData.Text.Length;
               for (var i = 0; i < length; i++)
               {
                  // Yes, convert to DocumentCharacter and add them to the list
                  var flags = textData.CharacterFlags[i];
                  var positions = DocumentCharacterPositions.None;
                  if ((flags & SvgTextCharacterFlags.EndOfWord) == SvgTextCharacterFlags.EndOfWord)
                     positions |= DocumentCharacterPositions.EndOfWord;
                  if ((flags & SvgTextCharacterFlags.EndOfLine) == SvgTextCharacterFlags.EndOfLine)
                     positions |= DocumentCharacterPositions.EndOfLine;

                  var character = new DocumentCharacter
                  {
                     Code = textData.Text[i],
                     Bounds = textData.Bounds[i],
                     Positions = positions,
                     Direction = textData.Directions[i]
                  };

                  // If the character duplicated, then remove the old one
                  if (prevCharacter.Bounds == character.Bounds &&
                     prevCharacter.Code == character.Code &&
                     prevCharacter.Direction == character.Direction)
                  {
                     characters.Remove(prevCharacter);
                  }

                  characters.Add(character);

                  if (!hasWhitespaces && Char.IsWhiteSpace(character.Code))
                     hasWhitespaces = true;

                  prevCharacter = character;
               }
            }

            return true;
         };

         // Accept text elements only.
         SvgFilterElementsCallback filterElementsCallback = (svgDocument, nodeHandle, userData) =>
         {
            // Accept text elements only.
            if (nodeHandle.ElementType != SvgElementType.Text)
               return false;

            return true;
         };

         // Setup options and sort
         var options = new SvgSortOptions { ExtractText = SvgExtractText.Character, SortFlags = SvgSortFlags.Default };
         document.SetFilterElementsCallback(filterElementsCallback, null);
         document.SortElements(options, sortCallback, null);
         document.SetFilterElementsCallback(null, null);

         // Characters is set, before using it, strip the whitespaces
         if (hasWhitespaces)
         {
            var temp = new List<DocumentCharacter>();
            var count = characters.Count;
            var positions = DocumentCharacterPositions.None;
            var newIndex = -1;
            for (var index = 0; index < count; index++)
            {
               var character = characters[index];

               // If this character is a whitespace, dont add it, just steal its position and add it to the previous character
               if (Char.IsWhiteSpace(character.Code))
               {
                  positions |= character.Positions;
               }
               else
               {
                  // If have stolen flags from dropping white space characters, add them to the last non-white space character
                  if (positions != DocumentCharacterPositions.None)
                  {
                     if (newIndex != -1)
                     {
                        var tempCharacter = temp[newIndex];
                        tempCharacter.Positions |= positions;
                        temp[newIndex] = tempCharacter;
                     }

                     positions = DocumentCharacterPositions.None;
                  }

                  // Add it
                  temp.Add(character);
                  newIndex++;
               }
            }

            characters = temp;
         }

         var result = new DocumentText(characters);
         return result;
      }

      private List<DocumentCharacter> _characters;

      public IList<DocumentCharacter> Characters
      {
         get { return _characters; }
      }

      private IList<DocumentWord> _words;

      public IList<DocumentWord> Words
      {
         get { return _words; }
      }

      public void BuildWords()
      {
         var characterIndex = 0;
         var characterCount = _characters.Count;

         var words = new List<DocumentWord>();
         var lastReverseWord = false;
         var startReverseIndex = -1;

         // Loop through all the characters
         while(characterIndex < characterCount)
         {
            // Find the total bounding rectangle, begin and end index of the next word
            var wordBounds = LeadRectD.Empty;
            var beginCharacterIndex = characterIndex;
            bool reverseWord = false;

            // Loop till we reach the EndOfWord of EndOfLine
            var more = true;
            var character = new DocumentCharacter();
            while (more && characterIndex < characterCount)
            {
               character = _characters[characterIndex];

               // Add the bounding rectangle of this character
               var characterBounds = character.Bounds;

               if (wordBounds.IsEmpty)
                  wordBounds = characterBounds;
               else
                  wordBounds = LeadRectD.UnionRects(wordBounds, characterBounds);

               more = characterIndex < characterCount &&
                     (character.Positions & DocumentCharacterPositions.EndOfWord) != DocumentCharacterPositions.EndOfWord &&
                     (character.Positions & DocumentCharacterPositions.EndOfLine) != DocumentCharacterPositions.EndOfLine;

               characterIndex++;

               if (character.Direction == SvgCharacterDirection.RightToLeft)
                  reverseWord = true;
            }

            // From the begin and end index, collect the characters into a string
            var sb = new StringBuilder();
            for(var i = beginCharacterIndex; i < characterIndex; i++)
               sb.Append(_characters[i].Code);

            var word = new DocumentWord();
            word.Value = sb.ToString();
            word.Bounds = wordBounds;
            word.FirstCharacterIndex = beginCharacterIndex;
            word.LastCharacterIndex = characterIndex - 1;

            if (reverseWord)
            {
               char[] charArray = word.Value.ToCharArray();
               int startIndex = 0;
               for (int i = 0; i < charArray.Length; i++)
               {
                  int nextIndex = i + 1;
                  if (_characters[i + word.FirstCharacterIndex].Direction == SvgCharacterDirection.RightToLeft &&
                      (nextIndex >= charArray.Length ||
                      _characters[nextIndex + word.FirstCharacterIndex].Direction == SvgCharacterDirection.LeftToRight))
                  {
                     Array.Reverse(charArray, startIndex, nextIndex - startIndex);
                     startIndex = i;
                  }
               }

               word.Value = new string(charArray);
            }


            if (lastReverseWord && reverseWord)
            {
               startReverseIndex = startReverseIndex == -1 ? words.Count - 1: startReverseIndex;
               words.Insert(startReverseIndex, word);
            }
            else
            {
               if (startReverseIndex != -1)
               {
                  ReverseCharacterPositions(words[startReverseIndex].LastCharacterIndex, words[words.Count - 1].LastCharacterIndex);
                  startReverseIndex = -1;
               }
               words.Add(word);
            }

            lastReverseWord = reverseWord && (character.Positions & DocumentCharacterPositions.EndOfLine) != DocumentCharacterPositions.EndOfLine;
         }

         if (startReverseIndex != -1)
            ReverseCharacterPositions(words[startReverseIndex].LastCharacterIndex, words[words.Count - 1].LastCharacterIndex);

         _words = words;
      }

      private void ReverseCharacterPositions(int index1, int index2)
      {
         DocumentCharacterPositions tempPos = _characters[index1].Positions;

         DocumentCharacter tempCharacter = _characters[index1];
         tempCharacter.Positions = _characters[index2].Positions;
         _characters[index1] = tempCharacter;

         tempCharacter = _characters[index2];
         tempCharacter.Positions = tempPos;
         _characters[index2] = tempCharacter;
      }

      public string BuildText()
      {
         if (_words != null && _characters == null)
            BuildWords();

         if (_words == null || _words.Count == 0)
            return string.Empty;

         var sb = new StringBuilder();
         var wordCount = _words.Count;
         var wordIndex = 0;
         while (wordIndex <wordCount)
         {
            var word = _words[wordIndex];
            if (!string.IsNullOrEmpty(word.Value))
               sb.Append(word.Value);

            var positions = DocumentCharacterPositions.None;
            if (word.LastCharacterIndex != -1)
               positions = _characters[word.LastCharacterIndex].Positions;

            var lastWord = (wordIndex == wordCount - 1);

            if ((positions & DocumentCharacterPositions.EndOfLine) == DocumentCharacterPositions.EndOfLine)
            {
               if (!lastWord)
                  sb.AppendLine();
            }
            else if (!lastWord)
            {
               sb.Append(" ");
            }

            wordIndex++;
         }

         return sb.ToString();
      }
   }
}
