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
using Leadtools.Document.Writer;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace OcrMultiThreadingDemo
{
   public partial class MainForm : Form
   {
      private bool _isBusy;
      private DocumentWriter _docWriter;

      public MainForm()
      {
         InitializeComponent();

         Messager.Caption = "C# OCR Multi Threading Demo";
         Text = Messager.Caption;

         _gatherInformationControl.Visible = true;
         _conversionControl.Visible = false;
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
         DemoOptions options = DemoOptions.LoadDefault();

         // Show the engine selection dialog
         using(OcrEngineSelectDialog dlg = new OcrEngineSelectDialog(Messager.Caption, options.OcrEngineType.ToString(), false))
         {
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _docWriter = new DocumentWriter();
               _gatherInformationControl.Init(dlg.SelectedOcrEngineType, _docWriter, options, 1);

               // Add the selected engine name to the demo caption
               Text = Text + " [" + dlg.SelectedOcrEngineType.ToString() + " Engine]";
            }
            else
            {
               // Close the demo
               Close();
            }
         }
      }

      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         // Dont allow existing when the demo is busy
         e.Cancel = _isBusy;

         base.OnFormClosing(e);
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         _gatherInformationControl.SaveSettings();

         base.OnFormClosed(e);
      }

      private void _miFileExit_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _miHelpAbout_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("OCR Multi Threading", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("OCR Multi Threading"))
            aboutDialog.ShowDialog(this);
#endif
      }

      private void _gatherInformationControl_StartConversion(object sender, StartConversionEventArgs e)
      {
         _gatherInformationControl.Visible = false;
         _conversionControl.Visible = true;

         _isBusy = true;
         _msMain.Enabled = false;

         _conversionControl.Convert(_docWriter, e.EngineType, e.SourceFiles, e.DestinationDirectory, e.Format, e.LoopContinuously);
      }

      private void _conversionControl_ConversionFinished(object sender, EventArgs e)
      {
         this.BeginInvoke(new MethodInvoker(delegate()
         {
            _isBusy = false;
            _msMain.Enabled = true;
         }));
      }

      private void _conversionControl_ConvertMoreFiles(object sender, EventArgs e)
      {
         _gatherInformationControl.Visible = true;
         _conversionControl.Visible = false;
      }
  }
}
