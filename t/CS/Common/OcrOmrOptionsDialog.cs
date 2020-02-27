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

namespace Leadtools.Demos
{
   public partial class OcrOmrOptionsDialog : Form
   {
      private IOcrOmrOptions _omrOptions;

      public OcrOmrOptionsDialog(IOcrEngine ocrEngine)
      {
         InitializeComponent();

         // Get the OMR options object
         _omrOptions = ocrEngine.ZoneManager.OmrOptions;

         Array a = Enum.GetValues(typeof(OcrOmrFrameDetectionMethod));
         foreach(OcrOmrFrameDetectionMethod i in a)
            _frameDetectionMethodComboBox.Items.Add(i);

         _frameDetectionMethodComboBox.SelectedItem = _omrOptions.FrameDetectionMethod;

         a = Enum.GetValues(typeof(OcrOmrSensitivity));
         foreach(OcrOmrSensitivity i in a)
            _sensitivityComboBox.Items.Add(i);

         _sensitivityComboBox.SelectedItem = _omrOptions.Sensitivity;

         char unfilledCharacter = _omrOptions.GetStateRecognitionCharacter(OcrOmrZoneState.Unfilled);
         _unfilledStateCharacterTextBox.Text = new string(unfilledCharacter, 1);

         char filledCharacter = _omrOptions.GetStateRecognitionCharacter(OcrOmrZoneState.Filled);
         _filledStateCharacterTextBox.Text = new string(filledCharacter, 1);
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         OcrOmrFrameDetectionMethod frameDetectionMethod = (OcrOmrFrameDetectionMethod)_frameDetectionMethodComboBox.SelectedItem;
         OcrOmrSensitivity sensitivity = (OcrOmrSensitivity)_sensitivityComboBox.SelectedItem;

         char unfilledCharacter;
         if(!string.IsNullOrEmpty(_unfilledStateCharacterTextBox.Text))
            unfilledCharacter = _unfilledStateCharacterTextBox.Text[0];
         else
            unfilledCharacter = ' ';

         char filledCharacter;
         if(!string.IsNullOrEmpty(_filledStateCharacterTextBox.Text))
            filledCharacter = _filledStateCharacterTextBox.Text[0];
         else
            filledCharacter = ' ';

         _omrOptions.FrameDetectionMethod = frameDetectionMethod;
         _omrOptions.Sensitivity = sensitivity;
         _omrOptions.SetStateRecognitionCharacter(OcrOmrZoneState.Unfilled, unfilledCharacter);
         _omrOptions.SetStateRecognitionCharacter(OcrOmrZoneState.Filled, filledCharacter);
      }


   }
}
