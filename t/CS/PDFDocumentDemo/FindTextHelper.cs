// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace PDFDocumentDemo
{
   class FindTextHelper
   {
      // This is a helper for "Find" operations
      struct FindWordItem
      {
         public int BeginTextIndex; // Begin index into _currentPageText
         public int EndTextIndex;   // Begin index into _currentPageText
         public int WordIndex;      // Index into the DocumentWord array
      }

      private FindWordItem[] _findWordItems;

      private string _currentPageText;  // Current page text
      private string _findText;  // Last text we used for "find"
      private int _lastFindWordIndex; // Index of the last word we found. Used in find next/find previous

      public FindTextHelper()
      {
      }

      public void Reset()
      {
         // Reset the find text stuff
         _findWordItems = null;
         _lastFindWordIndex = -1;
         _findText = string.Empty;
      }

      private int _gotoPageNumber;
      public int GotoPageNumber
      {
         get { return _gotoPageNumber; }
      }

      private MyWord[] _selectedWords;
      public MyWord[] GetSelectedWords()
      {
         return _selectedWords;
      }

      public bool FindText(Dictionary<int, MyWord[]> documentText, int currentPageNumber, int pageCount, string text, bool next)
      {
         if (string.Compare(text, _findText, StringComparison.OrdinalIgnoreCase) != 0)
         {
            // New word
            _findText = text;
         }

         int startIndex = _lastFindWordIndex;
         int pageNumberToCheck = currentPageNumber;
         int stopCount = 0;
         int index = -1;
         while (stopCount != 2 && index == -1)
         {
            // Get the page word items
            if (_findWordItems == null)
            {
               // Rebuild it
               BuildWordItems(documentText, pageNumberToCheck);

               if (startIndex == -1 && !next)
               {
                  startIndex = _currentPageText.Length - 1;
               }
            }

            // Try to find the text in the page
            if (next)
            {
               index = _currentPageText.IndexOf(_findText, Math.Min(startIndex + 1, _currentPageText.Length), StringComparison.OrdinalIgnoreCase);
            }
            else
            {
               index = _currentPageText.LastIndexOf(_findText, Math.Max(0, startIndex - 1), StringComparison.OrdinalIgnoreCase);
            }

            if (index == -1)
            {
               _findWordItems = null;
               startIndex = -1;

               // Could not be found or reached the end of the page, try next (or previous) page
               if (next)
               {
                  pageNumberToCheck++;
                  if (pageNumberToCheck > pageCount)
                  {
                     pageNumberToCheck = 1;
                  }
               }
               else
               {
                  pageNumberToCheck--;
                  if (pageNumberToCheck < 1)
                  {
                     pageNumberToCheck = pageCount;
                  }
               }

               if (pageNumberToCheck == currentPageNumber)
               {
                  // We looped back to original page, the count goes to 2 so we
                  // do the same page upper or lower part in case we started in the middle
                  stopCount++;
               }
            }
         }

         if (index != -1)
         {
            MyWord[] words = null;
            if (documentText[pageNumberToCheck] != null)
            {
               words = documentText[pageNumberToCheck];
            }

            // Found it, get the correspoding page word
            _lastFindWordIndex = index;
            int lastIndex = index + _findText.Length - 1;

            // We found it, get the corresponding word(s)
            List<MyWord> selectedWords = new List<MyWord>();
            bool inside = false;
            foreach (FindWordItem item in _findWordItems)
            {
               if (!inside && index >= item.BeginTextIndex && index <= item.EndTextIndex)
               {
                  // First word in sentence
                  inside = true;
               }

               if (inside)
               {
                  selectedWords.Add(words[item.WordIndex]);
               }

               // Check if we reached end of sentence
               if (inside && item.EndTextIndex >= lastIndex)
               {
                  // part of sentence
                  break;
               }
            }

            _gotoPageNumber = pageNumberToCheck;
            _selectedWords = selectedWords.ToArray();
            return true;
         }
         else
         {
            return false;
         }
      }

      private void BuildWordItems(Dictionary<int, MyWord[]> documentText, int pageNumber)
      {
         List<FindWordItem> findWordItems = new List<FindWordItem>();

         MyWord[] words = null;
         if (documentText[pageNumber] != null)
         {
            words = documentText[pageNumber];
         }

         if (words != null)
         {
            int beginIndex = 0;

            StringBuilder sb = new StringBuilder();

            for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
            {
               MyWord word = words[wordIndex];
               sb.Append(word.Value);

               // Add it as a FindWordItem
               FindWordItem item = new FindWordItem();
               item.BeginTextIndex = beginIndex;
               item.EndTextIndex = beginIndex + word.Value.Length - 1;
               item.WordIndex = wordIndex;
               findWordItems.Add(item);

               sb.Append(" ");

               beginIndex = item.EndTextIndex + 2;
            }

            _currentPageText = sb.ToString();
         }
         else
         {
            _currentPageText = string.Empty;
         }

         _findWordItems = findWordItems.ToArray();
      }
   }
}
