// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools;
using Leadtools.Pdf;

namespace PDFDocumentDemo
{
   public class MyWord
   {
      private LeadRect _bounds;
      public LeadRect Bounds
      {
         get { return _bounds; }
         set { _bounds = value; }
      }

      private string _value;
      public string Value
      {
         get { return _value; }
         set { _value = value; }
      }

      private bool _isEndOfLine;
      public bool IsEndOfLine
      {
         get { return _isEndOfLine; }
         set { _isEndOfLine = value; }
      }

      public static Dictionary<int, MyWord[]> BuildWord(PDFDocument document)
      {
         Dictionary<int, MyWord[]> pageWords = new Dictionary<int, MyWord[]>();
         for (int pageNumber = 1; pageNumber <= document.Pages.Count; pageNumber++)
         {
            List<MyWord> words = new List<MyWord>();

            PDFDocumentPage page = document.Pages[pageNumber - 1];
            IList<PDFObject> objects = page.Objects;
            if (objects != null && objects.Count > 0)
            {
               int objectIndex = 0;
               int objectCount = objects.Count;

               // Loop through all the objects
               while (objectIndex < objectCount)
               {
                  // Find the total bounding rectangle, begin and end index of the next word
                  LeadRect wordBounds = LeadRect.Empty;
                  int firstObjectIndex = objectIndex;

                  // Loop till we reach EndOfWord or reach the end of the objects
                  bool more = true;
                  while (more)
                  {
                     PDFObject obj = objects[objectIndex];

                     // Must be text and not a white character
                     if (obj.ObjectType == PDFObjectType.Text && !Char.IsWhiteSpace(obj.Code))
                     {
                        // Add the bounding rectangle of this object
                        PDFRect temp = page.ConvertRect(PDFCoordinateType.Pdf, PDFCoordinateType.Pixel, obj.Bounds);
                        LeadRect objectBounds = LeadRect.FromLTRB((int)temp.Left, (int)temp.Top, (int)temp.Right, (int)temp.Bottom);

                        if (wordBounds.IsEmpty)
                        {
                           wordBounds = objectBounds;
                        }
                        else
                        {
                           wordBounds = LeadRect.Union(wordBounds, objectBounds);
                        }
                     }
                     else
                     {
                        firstObjectIndex = objectIndex + 1;
                     }

                     objectIndex++;
                     more = (objectIndex < objectCount) && !obj.TextProperties.IsEndOfWord && !obj.TextProperties.IsEndOfLine;
                  }

                  if (firstObjectIndex == objectIndex)
                  {
                     continue;
                  }

                  // From the begin and end index, collect the characters into a string
                  StringBuilder sb = new StringBuilder();
                  for (int i = firstObjectIndex; i < objectIndex; i++)
                  {
                     if (objects[i].ObjectType == PDFObjectType.Text)
                     {
                        sb.Append(objects[i].Code);
                     }
                  }

                  // Add this word to the list

                  PDFObject lastObject = objects[objectIndex - 1];

                  MyWord word = new MyWord();
                  word.Value = sb.ToString();
                  word.Bounds = wordBounds;
                  word.IsEndOfLine = lastObject.TextProperties.IsEndOfLine;

                  words.Add(word);
               }
            }

            // Add "IsEndOfLine" to the last word in the page, just in case it does not have it
            if (words.Count > 0)
            {
               MyWord word = words[words.Count - 1];
               word.IsEndOfLine = true;
               words[words.Count - 1] = word;
            }

            pageWords.Add(pageNumber, words.ToArray());
         }

         return pageWords;
      }
   }
}
