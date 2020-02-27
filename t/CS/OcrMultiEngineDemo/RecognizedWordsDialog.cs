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
using Leadtools.Demos;
using Leadtools.Ocr;

namespace OcrMultiEngineDemo
{
   public partial class RecognizedWordsDialog : Form
   {
      private IOcrDocument _ocrDocument;

      public RecognizedWordsDialog(IOcrDocument ocrDocument)
      {
         InitializeComponent();

         _ocrDocument = ocrDocument;

         for(int i = 0; i < _ocrDocument.Pages.Count; i++)
         {
            _pagesListBox.Items.Add(DemosGlobalization.GetResxString(GetType(), "Resx_Page") + (i + 1).ToString());
         }

         if(_pagesListBox.Items.Count > 0)
            _pagesListBox.SelectedIndex = 0;

         // change some of the words listbox in case of Arabic OCR for better words display.
         if (_ocrDocument.Engine.EngineType == OcrEngineType.OmniPageArabic)
         {
            _wordsListBox.RightToLeft = RightToLeft.Yes;
            _wordsListBox.Font = new System.Drawing.Font("Times New Roman", 10);
         }
      }

      private void _pagesListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Get the recognized words of the selected page

         _wordsListBox.Items.Clear();

         IOcrPage ocrPage = _ocrDocument.Pages[_pagesListBox.SelectedIndex];
         if(ocrPage.IsRecognized)
         {
            IOcrPageCharacters pageCharacters = ocrPage.GetRecognizedCharacters();
            if (pageCharacters == null)
               return;

            foreach(IOcrZoneCharacters zoneCharacters in pageCharacters)
            {
               ICollection<OcrWord> words = zoneCharacters.GetWords();

               foreach(OcrWord word in words)
                  _wordsListBox.Items.Add(word.Value);
            }
         }
      }
   }
}
