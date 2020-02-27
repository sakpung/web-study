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
using Leadtools;
using Leadtools.ImageProcessing;

namespace MainDemo
{
   public partial class CommandProgressDialog : Form
   {
      public RasterImage Image;
      public RasterCommand Command;

      public bool Cancel;
      private IAsyncResult _ar;

      private delegate void StartupDelegate( );

      public CommandProgressDialog( )
      {
         InitializeComponent();
      }

      private void CommandProgressDialog_Load(object sender, System.EventArgs e)
      {
         Text = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_Processing") + " {0}", Command.ToString());
         Cancel = false;
         _ar = BeginInvoke(new StartupDelegate(Startup));
      }

      private void Startup( )
      {
         EventHandler<RasterCommandProgressEventArgs> commandProgress = new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
         Command.Progress += commandProgress;

         try
         {
            EndInvoke(_ar);
            Command.Run(Image);

            DialogResult = Cancel ? DialogResult.Cancel : DialogResult.OK;
            Close();
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            DialogResult = DialogResult.Cancel;
            Close();
         }
         finally
         {
            Command.Progress -= commandProgress;
         }
      }

      private void Command_Progress(object sender, RasterCommandProgressEventArgs e)
      {
         _progressBarCommand.Value = e.Percent;

         if(Cancel)
            e.Cancel = true;

         Application.DoEvents();
      }

      private void _btnCancel_Click(object sender, System.EventArgs e)
      {
         Cancel = true;
      }
   }
}
