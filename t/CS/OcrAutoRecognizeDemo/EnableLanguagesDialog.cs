// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Leadtools.Ocr;

namespace OcrAutoRecognizeDemo
{
   public partial class EnableLanguagesDialog : Form
   {
      private IOcrEngine _ocrEngine;

      public EnableLanguagesDialog(IOcrEngine ocrEngine)
      {
         InitializeComponent();

         _ocrEngine = ocrEngine;
         IOcrLanguageManager languageManager = _ocrEngine.LanguageManager;

         // Get the languages supported by this engine and fill the list box
         string[] languages = languageManager.GetSupportedLanguages();
         Dictionary<string, string> languagesDictionary = new Dictionary<string, string>();

         string[] friendlyNames = new string[languages.Length];

         int i = 0;
         foreach(string language in languages)
         {
            friendlyNames[i] = MyLanguage.GetLanguageFriendlyName(language);
            languagesDictionary.Add(friendlyNames[i], language);
            i++;
         }

         Array.Sort(friendlyNames, 1, friendlyNames.Length - 1);

         foreach(string friendlyName in friendlyNames)
         {
            MyLanguage ml = new MyLanguage(languagesDictionary[friendlyName], friendlyName);
            _languagesListBox.Items.Add(ml);
         }

         // Check in the list box the current enabled languages
         string[] enabledLanguages = languageManager.GetEnabledLanguages();
         for(i = 0; i < _languagesListBox.Items.Count; i++)
         {
            MyLanguage ml = (MyLanguage)_languagesListBox.Items[i];
            foreach(string language in enabledLanguages)
            {
               if(ml.Language == language)
               {
                  _languagesListBox.SelectedItems.Add(ml);
                  break;
               }
            }
         }

         if(!languageManager.SupportsEnablingMultipleLanguages || _languagesListBox.Items.Count <= 1)
            _languagesListBox.SelectionMode = SelectionMode.One;
      }

      private void _languagesListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         // We must have at least one language selected
         _okButton.Enabled = _languagesListBox.SelectedItems.Count > 0;
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         // Enable the languages selected by the user
         List<string> languages = new List<string>();

         foreach(MyLanguage ml in _languagesListBox.SelectedItems)
            languages.Add(ml.Language);

         IOcrLanguageManager languageManager = _ocrEngine.LanguageManager;

         if(languages.Count > 0)
         {
            try
            {
               languageManager.EnableLanguages(languages.ToArray());
            }
            catch(Exception ex)
            {
               MessageBox.Show(this, ex.Message, "OCR Languages", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               DialogResult = DialogResult.None;
            }
         }
      }
   }
}
