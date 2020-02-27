// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace OcrAutoRecognizeDemo
{
   // Language/Friendly name combo
   struct MyLanguage
   {
      public string Language;
      public string FriendlyName;

      public MyLanguage(string l, string f)
      {
         Language = l;
         FriendlyName = f;
      }

      public override string ToString()
      {
         return FriendlyName;
      }

      public static string GetLanguageFriendlyName(string language)
      {
         CultureInfo ci;

         if (language == "sr-Cyrl-CS" || language == "sr-SP-Cyrl")
            ci = new CultureInfo(0x0C1A);
         else if (language == "sr-Latn-CS")
            ci = new CultureInfo(0x081A);
         else if (language == "zh-Hans")
            ci = new CultureInfo(0x0004);
         else if (language == "zh-Hant")
            ci = new CultureInfo(0x7C04);
         else
            ci = new CultureInfo(language);

         return ci.EnglishName;
      }
   }
}
