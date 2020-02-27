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

namespace Leadtools.Dicom.Server.Manager.Dialogs
{
   public partial class HelpDialog : Form
   {
      public HelpDialog()
      {
         InitializeComponent();
         _showHelpCheckBox = false;
      }

      private bool _showHelpCheckBox;     

      public bool ShowHelpCheckBox
      {
          get
          {
              return _showHelpCheckBox;
          }
          set
          {
              _showHelpCheckBox = value;
          }
      }

      public bool CheckBoxNoShowAgainResult
      {
          get { return _checkBoxNoShowAgain.Checked; }
         set { _checkBoxNoShowAgain.Checked = value; }
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

      private void HelpDialog_Load(object sender, EventArgs e)
      {
         _pictureBox.Image = System.Drawing.SystemIcons.Information.ToBitmap();

         _richTextBoxHelp.Clear();
         _richTextBoxHelp.SelectionColor = Color.Black;
         BoldText("This utility allows management of multiple LEADTOOLS PACS Framework Servers from one location.\n");
         ColorText("It can add, remove, start, stop & pause any of the server services. It also allows client configuration to any server and exposes the configuration settings for all add-ins for all servers from one user interface.\n\n\n", Color.Black);

         ColorText("(Optional but Recommended) ", Color.Blue);
         _richTextBoxHelp.SelectedText = "Run the ";
         BoldText("PACS Config Demo");
         string sMsg = string.Format(" to automatically create and configure a DICOM Server service, to configure the high-level DICOM client demos to communicate with this service, and to configure the logging viewer.\n\n");
         _richTextBoxHelp.SelectedText = sMsg;

         ColorText("(Optional but Recommended) ", Color.Blue); ;
         _richTextBoxHelp.SelectedText = "View the ";
         BoldText("PACS Framework");
         _richTextBoxHelp.SelectedText = " topic in the LEAD Help file. This gives a detailed explanation of the features of this demo.\n\n";

         _richTextBoxHelp.SelectedText = "Run the  ";
         BoldText("CSDicomHighlevelStoreDemo");
         _richTextBoxHelp.SelectedText = " demo to store DICOM images to the DICOM server.\n\n";

         _richTextBoxHelp.SelectedText = "Run the  ";
         BoldText("CSDicomHighlevelClientDemo");
         _richTextBoxHelp.SelectedText = " demo to retrieve the stored images from the DICOM server.\n\n";

         _richTextBoxHelp.SelectionBullet = false;

         _checkBoxNoShowAgain.Visible = _showHelpCheckBox;
         buttonOK.Select();
      }
   }
}
