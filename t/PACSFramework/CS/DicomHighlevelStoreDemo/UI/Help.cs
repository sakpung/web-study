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

namespace DicomDemo
{
   public partial class HelpDialog : Form
   {
      public HelpDialog()
      {
         _serverAE = string.Empty;
         InitializeComponent();
      }

      public HelpDialog(string serverAE, bool showHelpCheckBox)
      {
         _serverAE = serverAE;
         _showHelpCheckBox = showHelpCheckBox;

         InitializeComponent();
      }

      private bool _showHelpCheckBox;
      private bool _checkBoxNoShowAgainResult;

      public bool CheckBoxNoShowAgainResult
      {
         get { return _checkBoxNoShowAgainResult; }
         set { _checkBoxNoShowAgainResult = value; }
      }
      private string _serverAE = string.Empty;

      private void ColorText(string text, Color color)
      {
         _richTextBoxHelp.SelectionColor = color;
         _richTextBoxHelp.SelectedText = text;
         _richTextBoxHelp.SelectionColor = Color.Black;
      }

      private void BoldText(string text)
      {
         Font font = _richTextBoxHelp.SelectionFont;
         Font fontBold = new Font(font.Name, font.Size, FontStyle.Bold);
         _richTextBoxHelp.SelectionFont = fontBold;
         _richTextBoxHelp.SelectedText = text;
         _richTextBoxHelp.SelectionFont = font;
      }

      private void _HelpDialog_Load(object sender, EventArgs e)
      {
         _pictureBox.Image = System.Drawing.SystemIcons.Information.ToBitmap();

         _richTextBoxHelp.Clear();
         _richTextBoxHelp.SelectionColor = Color.Black;
         BoldText("This demo shows how to use the high level Leadtools.Dicom.Scu component to store DICOM data sets to a DICOM server.\n\n\n");

         ColorText("(Optional but Recommended) ", Color.Blue); ;
         _richTextBoxHelp.SelectedText = "Run the ";
         BoldText("PACS Config Demo");
         string sMsg = string.Format(" to automatically configure this demo and other client demos to communicate with a DICOM server.\n\n");
         _richTextBoxHelp.SelectedText = sMsg;

         ColorText("(Optional) ", Color.Blue); ;
         _richTextBoxHelp.SelectedText = "Click the ";
         BoldText("Options");
         sMsg = string.Format(" button to configure this demo to communicate with a DICOM server.  Note that the demo is pre-configured to communicate with the already running DICOM Server service ({0}).\n\n", _serverAE);
         _richTextBoxHelp.SelectedText = sMsg;

         ColorText("(Required) ", Color.Red); ;
         sMsg = string.Format("Start CSLeadtools.Dicom.Server.Manager.exe, select the {0} service, and click the ", _serverAE);
         _richTextBoxHelp.SelectedText = sMsg;
         BoldText("Start Server");
         _richTextBoxHelp.SelectedText = " button (blue triangle) to start the DICOM service.\n\n";

         ColorText("(Optional) ", Color.Blue);
         _richTextBoxHelp.SelectedText = "Add any images that you want to store to the ";
         BoldText("Images");
         _richTextBoxHelp.SelectedText = " list view, and make sure the corresponding check box is selected.\n\n";

         _richTextBoxHelp.SelectedText = "Click the ";
         BoldText("Store");
         _richTextBoxHelp.SelectedText = " button to store the checked data sets.\n\n";

         _richTextBoxHelp.SelectedText = "Run the  ";
         BoldText("CSDicomHighlevelClientDemo");
         _richTextBoxHelp.SelectedText = " demo to retrieve the stored images.\n\n";

         _richTextBoxHelp.SelectionBullet = false;

         _checkBoxNoShowAgain.Visible = _showHelpCheckBox;
         buttonOK.Select();
      }

      private void HelpDialog_FormClosed(object sender, FormClosedEventArgs e)
      {
         CheckBoxNoShowAgainResult = _checkBoxNoShowAgain.Checked;
      }

   }
}
