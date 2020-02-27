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
using Leadtools.Ocr;
using Leadtools.Demos;

namespace OcrDemo
{
   public partial class DetectPageLanguagesDialog : Form
   {
      private IOcrEngine _ocrEngine;
      private IOcrPage _ocrPage;

      public DetectPageLanguagesDialog(IOcrEngine ocrEngine, IOcrPage ocrPage)
      {
         InitializeComponent();

         _ocrEngine = ocrEngine;
         _ocrPage = ocrPage;
      }

      private void DetectPageLanguagesDialog_Load(object sender, EventArgs e)
      {
         string[] supportedLanguages = _ocrEngine.LanguageManager.GetSupportedLanguages();
         if (supportedLanguages == null || supportedLanguages.Length <= 0)
            return;

         Dictionary<string, string> languagesDictionary = new Dictionary<string, string>();
         string[] friendlyNames = new string[supportedLanguages.Length];

         int i = 0;
         foreach (string language in supportedLanguages)
         {
            friendlyNames[i] = MyLanguage.GetLanguageFriendlyName(language);
            languagesDictionary.Add(friendlyNames[i], language);
            i++;
         }

         Array.Sort(friendlyNames, 1, friendlyNames.Length - 1);
         foreach (string friendlyName in friendlyNames)
         {
            MyLanguage ml = new MyLanguage(languagesDictionary[friendlyName], friendlyName, -1);
            _lbSuggestedLanguages.Items.Add(ml);
         }

         UpdateUIState();
      }

      private void _btnDetectLanguages_Click(object sender, EventArgs e)
      {
         using (WaitCursor wait = new WaitCursor())
         {
            _lbPageLanguages.Items.Clear();
            string[] suggestedLanguages = new string[_lbSuggestedLanguages.SelectedItems.Count];
            int index = 0;
            foreach (MyLanguage language in _lbSuggestedLanguages.SelectedItems)
            {
               suggestedLanguages[index] = language.Language;
               index++;
            }

            string[] pageLanguages = _ocrPage.DetectLanguages(suggestedLanguages);
            if (pageLanguages != null && pageLanguages.Length > 0)
            {
               foreach (string lang in pageLanguages)
               {
                  string friendlyName = MyLanguage.GetLanguageFriendlyName(lang);
                  _lbPageLanguages.Items.Add(friendlyName);
               }
            }
         }
      }

      void UpdateUIState()
      {
         _btnDetectLanguages.Enabled = _lbSuggestedLanguages.SelectedItems.Count > 0;
      }

      private void _lbSuggestedLanguages_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }
   }
}
