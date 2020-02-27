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
using System.IO;
using System.Diagnostics;

using Leadtools.Ocr;

namespace OcrDemo
{
   public partial class SpellCheckEngineDialog : Form
   {
      private IOcrEngine _ocrEngine;

      public SpellCheckEngineDialog(IOcrEngine ocrEngine)
      {
         InitializeComponent();

         _ocrEngine = ocrEngine;
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            IOcrSpellCheckManager ocrSpellCheckManager = _ocrEngine.SpellCheckManager;

            OcrSpellCheckEngine[] engines = ocrSpellCheckManager.GetSupportedSpellCheckEngines();
            foreach(OcrSpellCheckEngine engine in engines)
            {
#if LT_CLICKONCE
               if (engine != OcrSpellCheckEngine.Hunspell)
#endif
               _engineComboBox.Items.Add(engine);
            }

            _engineComboBox.SelectedItem = ocrSpellCheckManager.SpellCheckEngine;

            _helpButton.Visible = (_ocrEngine.EngineType == OcrEngineType.LEAD);
         }

         base.OnLoad(e);
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         IOcrSpellCheckManager ocrSpellCheckManager = _ocrEngine.SpellCheckManager;

         try
         {
            OcrSpellCheckEngine spellCheckEngine = (OcrSpellCheckEngine)_engineComboBox.SelectedItem;
            ocrSpellCheckManager.SpellCheckEngine = spellCheckEngine;
         }
         catch(Exception ex)
         {
            string msg = string.Format("{0}{1}Spell check engine will be set to 'None' now.", ex.Message, Environment.NewLine);
            MessageBox.Show(this, msg, "OCR Spell Check Engine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ocrSpellCheckManager.SpellCheckEngine = OcrSpellCheckEngine.None;
            _engineComboBox.SelectedItem = ocrSpellCheckManager.SpellCheckEngine;
            DialogResult = DialogResult.None;
         }
      }

      private void _helpButton_Click(object sender, EventArgs e)
      {
         try
         {
            string helpFile = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"OCRSpellCheckEngines.html");
            Process.Start(helpFile);
         }
         catch(Exception ex)
         {
            MessageBox.Show(this, ex.Message, "Help", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }
   }
}
