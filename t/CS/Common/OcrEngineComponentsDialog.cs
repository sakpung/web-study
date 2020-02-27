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
using System.Diagnostics;
using System.Globalization;

using Leadtools.Ocr;

namespace Leadtools.Demos
{
   public partial class OcrEngineComponentsDialog : Form
   {
      public OcrEngineComponentsDialog(IOcrEngine ocrEngine)
      {
         InitializeComponent();

         // Find all the supported and additional languages
         string[] languages = ocrEngine.LanguageManager.GetSupportedLanguages();
         foreach(string language in languages)
         {
            string name = GetLanguageFriendlyName(language);
            _lbInstalledLanguages.Items.Add(name);
         }

         languages = ocrEngine.LanguageManager.GetAdditionalLanguages();
         if(languages.Length > 0)
         {
            _lbAdditionalLanguages.Visible = true;
            _lblNoAdditionalLanguages.Visible = false;

            foreach(string language in languages)
            {
               string name = GetLanguageFriendlyName(language);
               _lbAdditionalLanguages.Items.Add(name);
            }
         }
         else
         {
            _lbAdditionalLanguages.Visible = false;
            _lblNoAdditionalLanguages.Visible = true;
         }

         IOcrSpellCheckManager spellCheckManager = ocrEngine.SpellCheckManager;
         if(spellCheckManager != null)
         {
            string[] spellLanguages = spellCheckManager.GetSupportedSpellLanguages();
            foreach(string spellLanguage in spellLanguages)
            {
               string name = GetLanguageFriendlyName(spellLanguage);
               _lbInstalledDictionaries.Items.Add(name);
            }

            spellLanguages = spellCheckManager.GetAdditionalSpellLanguages();
            foreach(string spellLanguage in spellLanguages)
            {
               string name = GetLanguageFriendlyName(spellLanguage);
               _lbAdditionalDictionaries.Items.Add(name);
            }
         }
         else
         {
            _tabMain.TabPages.Remove(_tpDictionaries);
         }

         if(ocrEngine.EngineType == OcrEngineType.LEAD)
         {
            if(spellCheckManager != null && spellCheckManager.SpellCheckEngine == OcrSpellCheckEngine.Hunspell)
            {
               _leadEngineDictionariesNoteLabel.Text = "Select OCR/Spell CheckEngine for the Hunspell spell check engine additional dictionaries support.";
            }
            else
            {
                _leadEngineDictionariesNoteLabel.Text = DemosGlobalization.GetResxString(GetType(), "Resx_DictionariesSupport");
            }
         }
         else
         {
            _leadEngineDictionariesNoteLabel.Visible = false;
         }

         string[] installedEngineFormats = ocrEngine.DocumentManager.GetSupportedEngineFormats();
         string[] additionalEngineFormats = ocrEngine.DocumentManager.GetAdditionalEngineFormats();

         if(installedEngineFormats.Length > 0 || additionalEngineFormats.Length > 0)
         {
            foreach(string format in installedEngineFormats)
               _lbInstalledEngineFormats.Items.Add(format);

            foreach(string format in additionalEngineFormats)
               _lbAdditionalEngineFormats.Items.Add(format);
         }
         else
         {
            _tabMain.TabPages.Remove(_tpEngineFormats);
         }
      }

      private static string GetLanguageFriendlyName(string language)
      {
         CultureInfo ci;

         try
         {
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
         }
         catch
         {
            return language;
         }

         return ci.EnglishName;
      }

      private void _lbDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         Process.Start(_lbDownload.Text);
      }
   }
}
