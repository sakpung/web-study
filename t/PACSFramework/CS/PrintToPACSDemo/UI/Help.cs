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

namespace PrintToPACSDemo
{
   public partial class HelpDialog : Form
   {
      public HelpDialog()
      {
         _serverAE = string.Empty;
         InitializeComponent();
      }

      public HelpDialog(string serverAE, bool showHelpCheckBox, bool bFirstTime)
      {
         _serverAE = serverAE;
         _showHelpCheckBox = showHelpCheckBox;
         _firstrun = bFirstTime;
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

      private bool _firstrun = false;

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
         if (_firstrun)
            this.Height = 650;
         else
            this.Height = 600;

         _pictureBox.Image = System.Drawing.SystemIcons.Information.ToBitmap();

         _richTextBoxHelp.Clear();
         _richTextBoxHelp.SelectionColor = Color.Black;
         BoldText("This demo shows how to use the Leadtools.DICOM components with the Leadtools.printer component .\n\n\n");

         ColorText("(Optional but Recommended) ", Color.Blue);
         _richTextBoxHelp.SelectedText = "Run the ";
         BoldText("PACS Config Demo");
         string sMsg = string.Format(" to automatically configure this demo and other client demos to communicate with a DICOM server.\n\n");
         _richTextBoxHelp.SelectedText = sMsg;

         ColorText("(Optional) ", Color.Blue);
         _richTextBoxHelp.SelectedText = "Click the ";
         BoldText("\"Options\"->\"Settings\"");
         sMsg = string.Format(" Menu Item to configure this demo to communicate with the DICOM servers.\n If this is the first time you run this demo PrintToPACS printer will be installed.\n\n");
         _richTextBoxHelp.SelectedText = sMsg;

         ColorText("(Required) ", Color.Red);
         sMsg = "Insert images to the demo, Use any of the following options:\n";
         sMsg += "   1. Print any document to the ";
         _richTextBoxHelp.SelectedText = sMsg;
         BoldText("PrintToPACS Printer.\n");
         sMsg = "   2. Open any support image from the hard disk.\n";
         _richTextBoxHelp.SelectedText = sMsg;
         sMsg = "   3. Scan images from Wia and Twain supported devices.\n";
         _richTextBoxHelp.SelectedText = sMsg;
         sMsg = "   4. Capture any part of the screen.\n\n";
         _richTextBoxHelp.SelectedText = sMsg;

         ColorText("(Required) ", Color.Red);
         sMsg = string.Format("Start CSLeadtools.DICOM.Server.Manager.exe, select the {0} service, and click the ", _serverAE);
         _richTextBoxHelp.SelectedText = sMsg;
         BoldText("Start Server");
         _richTextBoxHelp.SelectedText = " button (blue triangle) to start the DICOM service.\n\n";

         ColorText("(Optional) ", Color.Blue);
         _richTextBoxHelp.SelectedText = "Populate DICOM Information, Use one of the following options:\n";
         _richTextBoxHelp.SelectedText = "   1. Opening an existing ";
         BoldText("DICOM dataset.\n");
         _richTextBoxHelp.SelectedText = "   2. Query DICOM patients and studies from ";
         BoldText(" SCP server.\n");
         _richTextBoxHelp.SelectedText = "   3. Query DICOM ";
         BoldText(" Work Lists");
         _richTextBoxHelp.SelectedText = ".\n\n";

         ColorText("(Optional) ", Color.Blue);
         _richTextBoxHelp.SelectedText = "Click the ";
         BoldText("\"File\"->\"Save DICOM File\"");
         _richTextBoxHelp.SelectedText = " Menu Item to save the generated DICOM on the hard disk.\n\n";

         ColorText("(Optional) ", Color.Blue);
         _richTextBoxHelp.SelectedText = "Click the ";
         BoldText("\"File\"->\"Remote PACS\"");
         _richTextBoxHelp.SelectedText = " Menu Item to send the generated DICOM to the storage SCP.\n\n";

         if (_firstrun)
         {
            ColorText("(IMPORTANT) ", Color.Red);
            _richTextBoxHelp.SelectedText = "This is the ";
            BoldText("first time");
            _richTextBoxHelp.SelectedText = " you run the demo\nthe demo is loaded with a default image and default DICOM data\njust press on ";
            BoldText("Push To PACS");
            _richTextBoxHelp.SelectedText = " button to send the DICOM file to the PACS Storage.";
         }

         _checkBoxNoShowAgain.Visible = _showHelpCheckBox;
         buttonOK.Select();
      }

      private void HelpDialog_FormClosed(object sender, FormClosedEventArgs e)
      {
         CheckBoxNoShowAgainResult = _checkBoxNoShowAgain.Checked;
      }

   }
}
