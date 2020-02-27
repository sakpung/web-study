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
   public partial class SaveRecognizedXmlDialog : Form
   {
      private IOcrDocument _ocrDocument;

      private struct MyMode
      {
         public string Name;
         public OcrXmlOutputOptions Options;

         public MyMode(string n, OcrXmlOutputOptions o)
         {
            Name = n;
            Options = o;
         }

         public override string ToString()
         {
            return Name;
         }
      }

      public SaveRecognizedXmlDialog(IOcrDocument ocrDocument)
      {
         InitializeComponent();

         _ocrDocument = ocrDocument;
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            MyMode[] modes =
            {
               new MyMode(DemosGlobalization.GetResxString(GetType(), "Resx_SaveWords"), OcrXmlOutputOptions.None),
               new MyMode(DemosGlobalization.GetResxString(GetType(), "Resx_SaveCharacters"), OcrXmlOutputOptions.Characters),
               new MyMode(DemosGlobalization.GetResxString(GetType(), "Resx_SaveCharactersWithAttributes"), OcrXmlOutputOptions.Characters | OcrXmlOutputOptions.CharacterAttributes)
            };

            foreach(MyMode mode in modes)
            {
               _modeComboBox.Items.Add(mode);
            }

            _modeComboBox.SelectedIndex = 0;

            UpdateMyControls();
         }

         base.OnLoad(e);
      }

      private void UpdateMyControls()
      {
         _okButton.Enabled = !string.IsNullOrEmpty(_fileNameTextBox.Text.Trim());
      }

      private void _fileNameTextBox_TextChanged(object sender, EventArgs e)
      {
         UpdateMyControls();
      }

      private void _fileNameButton_Click(object sender, EventArgs e)
      {
         using(SaveFileDialog dlg = new SaveFileDialog())
         {
            dlg.Filter = "XML Files|*.xml|All Files|*.*";
            dlg.DefaultExt = "xml";
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _fileNameTextBox.Text = dlg.FileName;
            }
         }
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         try
         {
            using(WaitCursor wait = new WaitCursor())
            {
               OcrXmlOutputOptions options = ((MyMode)_modeComboBox.SelectedItem).Options;
               _ocrDocument.SaveXml(_fileNameTextBox.Text, options);

               System.Threading.Thread.Sleep(1000);
               System.Diagnostics.Process.Start(_fileNameTextBox.Text);
            }
         }
         catch(Exception ex)
         {
             MessageBox.Show(this, ex.Message, DemosGlobalization.GetResxString(GetType(), "Resx_Error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            DialogResult = DialogResult.None;
         }
      }
   }
}
