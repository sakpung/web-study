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

using Leadtools.Demos;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Ocr;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace OcrSettingsDemo
{
   public partial class MainForm : Form
   {
      private IOcrEngine _ocrEngine;
      private OcrEngineType _ocrEngineType;

      public MainForm()
      {
         InitializeComponent();

         Messager.Caption = "C# OCR Settings Demo";
         Text = Messager.Caption;
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            BeginInvoke(new MethodInvoker(Startup));
         }

         base.OnLoad(e);
      }

      private void Startup()
      {
         Properties.Settings settings = new Properties.Settings();

         string engineType = settings.OcrEngineType;

         // Show the engine selection dialog
         using(OcrEngineSelectDialog dlg = new OcrEngineSelectDialog(Messager.Caption, engineType, true))
         {
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _ocrEngine = dlg.OcrEngine;
               _ocrEngineType = dlg.SelectedOcrEngineType;

               _ocrEngineSettings.SetEngine(_ocrEngine);

               // Add the selected engine name to the demo caption
               Text = Text + " [" + _ocrEngineType.ToString() + " Engine]";
            }
            else
            {
               // Close the demo
               Close();
            }
         }
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         // Save the last setting
         Properties.Settings settings = new Properties.Settings();
         settings.OcrEngineType = _ocrEngineType.ToString();
         settings.Save();

         // Dispose the engine (this will call Shutdown as well)
         if(_ocrEngine != null)
            _ocrEngine.Dispose();

         base.OnFormClosed(e);
      }

      private void _miFileExit_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _miHelpAbout_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("OCR Settings", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("OCR Settings"))
            aboutDialog.ShowDialog(this);
#endif
      }
   }
}
