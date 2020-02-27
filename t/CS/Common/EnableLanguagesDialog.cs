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

namespace Leadtools.Demos
{
   public partial class EnableLanguagesDialog : Form
   {
      private IOcrEngine _ocrEngine;

      public EnableLanguagesDialog(IOcrEngine ocrEngine, Image moveRightImage, Image moveLeftImage, Image moveTopImage)
      {
         InitializeComponent();

         _ocrEngine = ocrEngine;
         IOcrLanguageManager languageManager = _ocrEngine.LanguageManager;

         // Get the languages supported by this engine and fill the list box
         string[] languages = languageManager.GetSupportedLanguages();
         string[] enabledLanguages = languageManager.GetEnabledLanguages();
         Dictionary<string, string> languagesDictionary = new Dictionary<string, string>();

         string[] friendlyNames = new string[languages.Length];

         int i = 0;
         foreach(string language in languages)
         {
            friendlyNames[i] = MyLanguage.GetLanguageFriendlyName(language);
            languagesDictionary.Add(friendlyNames[i], language);
            i++;
         }

         //Array.Sort(friendlyNames, 1, friendlyNames.Length - 1);

         i = 0;
         foreach(string friendlyName in friendlyNames)
         {
            // Don't add the enabled languages to the available languages list
            bool languageEnabled = false;
            foreach (string enabledLanguage in enabledLanguages)
            {
               if (languagesDictionary[friendlyName].Equals(enabledLanguage))
               {
                  languageEnabled = true;
                  break;
               }
            }

            if (!languageEnabled)
            {
               MyLanguage ml = new MyLanguage(languagesDictionary[friendlyName], friendlyName, i);
               _languagesListBox.Items.Add(ml);
            }
            i++;
         }

         // Fill the 'Enabled Languages' list box
         foreach (string enabledLanguage in enabledLanguages)
         {
            i = 0;
            foreach(KeyValuePair<string, string> entry in languagesDictionary)
            {
               if (entry.Value.Equals(enabledLanguage))
                  break;
               i++;
            }
            string friendlyName = MyLanguage.GetLanguageFriendlyName(enabledLanguage);
            MyLanguage ml = new MyLanguage(enabledLanguage, friendlyName, i);
            _enabledLanguagesListBox.Items.Add(ml);
         }

         if(!languageManager.SupportsEnablingMultipleLanguages || _languagesListBox.Items.Count <= 1)
            _languagesListBox.SelectionMode = SelectionMode.One;

         string[] additionalLanguages = languageManager.GetAdditionalLanguages();
         if(additionalLanguages != null && additionalLanguages.Length > 0)
         {
            _additionalLabel.Text = DemosGlobalization.GetResxString(GetType(), "Resx_SupportedLanguages") + "\n" + DemosGlobalization.GetResxString(GetType(), "Resx_EngineComponents");
         }

         // Set the buttons images
         if (moveRightImage != null)
            _btnMoveRight.Image = moveRightImage;
         else
            _btnMoveRight.Text = "→";
         if (moveLeftImage != null)
            _btnMoveLeft.Image = moveLeftImage;
         else
            _btnMoveLeft.Text = "←";
         if (moveTopImage != null)
            _btnMoveTop.Image = moveTopImage;
         else
            _btnMoveTop.Text = "↑";

         UpdateUIState();
      }

      public EnableLanguagesDialog(IOcrEngine ocrEngine) : this(ocrEngine, null, null, null)
      {
      }


      private void UpdateUIState()
      {
         _mainLanguageLabel.Visible = _ocrEngine.EngineType == OcrEngineType.LEAD;
         _btnMoveTop.Visible = _ocrEngine.EngineType == OcrEngineType.LEAD;
         _okButton.Enabled = _enabledLanguagesListBox.Items.Count > 0;
         _btnMoveRight.Enabled = _languagesListBox.SelectedItems.Count > 0;
         _btnMoveLeft.Enabled = _enabledLanguagesListBox.SelectedItems.Count > 0;
         _btnMoveTop.Enabled = _enabledLanguagesListBox.SelectedItems.Count == 1;
      }

      private void _languagesListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _enabledLanguagesListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _btnMoveRight_Click(object sender, EventArgs e)
      {
         Array selectedItems = Array.CreateInstance(typeof(object), _languagesListBox.SelectedItems.Count);
         _languagesListBox.SelectedItems.CopyTo(selectedItems, 0);
         foreach (MyLanguage ml in selectedItems)
         {
            int index = _enabledLanguagesListBox.Items.Add(ml);
            _enabledLanguagesListBox.SetSelected(index, true);
            _languagesListBox.Items.Remove(ml);
         }
      }

      private void _btnMoveLeft_Click(object sender, EventArgs e)
      {
         Array selectedItems = Array.CreateInstance(typeof(object), _enabledLanguagesListBox.SelectedItems.Count);
         _enabledLanguagesListBox.SelectedItems.CopyTo(selectedItems, 0);
         foreach (MyLanguage ml in selectedItems)
         {
            int insertionIndex = 0;
            foreach (MyLanguage item in _languagesListBox.Items)
            {
               if (ml.IndexInSupportedLanguagesList < item.IndexInSupportedLanguagesList)
                  break;

               insertionIndex++;
            }
            _languagesListBox.Items.Insert(insertionIndex, ml);
            _languagesListBox.SetSelected(insertionIndex, true);
            _enabledLanguagesListBox.Items.Remove(ml);
         }
      }

      private void _btnMoveTop_Click(object sender, EventArgs e)
      {
         MyLanguage ml = (MyLanguage)_enabledLanguagesListBox.SelectedItem;
         int index = _enabledLanguagesListBox.Items.IndexOf(ml);
         if (index <= 0)
            return;

         _enabledLanguagesListBox.Items.RemoveAt(index);
         _enabledLanguagesListBox.Items.Insert(0, ml);
         _enabledLanguagesListBox.SetSelected(0, true);
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         // Enable the languages selected by the user
         List<string> languages = new List<string>();
         foreach (MyLanguage ml in _enabledLanguagesListBox.Items)
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
               MessageBox.Show(this, ex.Message, DemosGlobalization.GetResxString(GetType(), "Resx_OCRLanguages"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               DialogResult = DialogResult.None;
            }
         }
      }
   }
}
