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

namespace OcrDemo
{
   public partial class SaveRecognizedXmlDialog : Form
   {
      OcrXmlOutputOptions _outputOptions = OcrXmlOutputOptions.None;
      string _fileName = null;

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

      public SaveRecognizedXmlDialog()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            MyMode[] modes =
            {
               new MyMode("Save words", OcrXmlOutputOptions.None),
               new MyMode("Save characters", OcrXmlOutputOptions.Characters),
               new MyMode("Save characters with attributes", OcrXmlOutputOptions.Characters | OcrXmlOutputOptions.CharacterAttributes)
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

      public string FileName
      {
         get { return _fileName; }
      }

      public OcrXmlOutputOptions OutputOptions
      {
         get { return _outputOptions; }
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
         _outputOptions = ((MyMode)_modeComboBox.SelectedItem).Options;
         _fileName = _fileNameTextBox.Text;
      }
   }
}
