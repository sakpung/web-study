// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Leadtools.Demos.StorageServer.Properties;

namespace Leadtools.Demos.StorageServer
{
   public partial class SplashForm : Form
   {
      private static Thread _splashThread;
      private static SplashForm _splashForm;

      public static Image SplashBitmap { get; set; }

      public Image Bitmap
      {
         get
         {
            return pictureBoxBitmap.Image;
         }
         set
         {
            pictureBoxBitmap.Image = value;
         }
      }

      public SplashForm()
      {
         InitializeComponent();
      }

      public static void ShowSplash()
      {
         if (_splashThread == null)
         {
            // show the form in a new thread
            _splashThread = new Thread(new ThreadStart(DoShowSplash));
            _splashThread.IsBackground = true;
            _splashThread.Start();
         }
      }      

      private static void DoShowSplash()
      {
         if (_splashForm == null)
            _splashForm = new SplashForm();

         _splashForm.Bitmap = SplashBitmap;
         _splashForm.Icon = Program.GetAppIcon();
         _splashForm.Text = "Loading...";
         // create a new message pump on this thread (started from ShowSplash)
         Application.Run(_splashForm);
      }

      public static void CloseSplash()
      {
         // need to call on the thread that launched this splash
         if (_splashForm.InvokeRequired)
            _splashForm.Invoke(new MethodInvoker(CloseSplash));

         else
            Application.ExitThread();
      }

      private void SplashForm_Shown(object sender, EventArgs e)
      {
         progressBar.MarqueeAnimationSpeed = 100;
      }
   }
}
