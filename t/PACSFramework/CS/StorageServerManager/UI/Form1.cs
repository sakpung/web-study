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
using System.Drawing.Drawing2D;
using System.Collections;
using Leadtools.Medical.Winforms;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Medical.Winforms.Monitor;
using System.Threading;

namespace Leadtools.Demos.StorageServer
{
   public partial class MainForm : Form
   {
      private AboutDialog _About = null;

      public MainForm()
      {
         InitializeComponent  ( ) ;
         
         _userWindowState = FormWindowState.Normal ;
         
         //ShowInTaskbar    = false ;
         WindowState      = _userWindowState ;
         _lastWindowState = WindowState ;
         
         MainNotifyIcon.Icon = this.Icon ;
         MainNotifyIcon.Text = this.Text ;
         
         MainNotifyIcon.DoubleClick   += new EventHandler ( MainNotifyIcon_DoubleClick ) ;
         showToolStripMenuItem.Click  += new EventHandler ( MainNotifyIcon_DoubleClick ) ;
         aboutToolStripMenuItem.Click += new EventHandler ( aboutToolStripMenuItem_Click ) ;
         exitToolStripMenuItem.Click  += new EventHandler ( exitToolStripMenuItem_Click ) ;
         
         
         WindowStateChanged += new EventHandler ( MainForm_WindowStateChanged ) ;
         
         //this.BackColor = Color.Fuchsia ;
         //TransparencyKey = SystemColors.Control ;
      }

      void MainForm_WindowStateChanged ( object sender, EventArgs e )
      {
         try
         {
            if (_lastWindowState == FormWindowState.Minimized && !_localStateChange)
            {
               // MainNotifyIcon_DoubleClick(sender, e);
               MinimizeToRestore();
               return;
            }
            if ( !_localStateChange  ) 
            {
               if ( WindowState != FormWindowState.Minimized ) 
               {
                  _userWindowState = WindowState ;
               }
               else
               {
                  _minimizedTicks = DateTime.Now.Ticks;
                  EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this,new BackgroundProcessEventAgs(true));                  
               }
            }
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      void MainNotifyIcon_DoubleClick ( object sender, EventArgs e )
      {
         try
         {
            ShowFromTaskBar ( ) ;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
      {
         if((keyData & Keys.Alt)!=0 && (keyData & Keys.KeyCode) == Keys.X)
         {
            Application.Exit();
            // Environment.Exit(0);
         }
         else if ((keyData & Keys.Alt) != 0 && (keyData & Keys.KeyCode) == Keys.S)
         {
            EventBroker.Instance.PublishEvent<DisplayFeatureEventArgs>(this, new DisplayFeatureEventArgs(FeatureNames.DisplaySettingsFeature));
         }
         return base.ProcessCmdKey(ref msg, keyData);
      }

      public override object InitializeLifetimeService()
      {
         return null;
      }
      
      void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Exit ( ) ;
      }

      public void Exit()
      {
         MainNotifyIcon.Visible = false;
         Application.Exit();
         // Environment.Exit(0);
      }

      void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_About != null && !_About.IsDisposed && _About.Visible)
         {
            _About.Focus();
         }
         else
         {
            if ((_About != null && !_About.Visible) || _About == null)
            {
               _About = new AboutDialog("Storage Server Manager");
               _About.ShowDialog(this);
            }
         }
      }

      internal void ShowFromTaskBar()
      {
         _localStateChange = true ;
         ExitMinimizedStateEventArgs args = null;
         if (WindowState == FormWindowState.Minimized)
         {
            long minimizedTickCount = DateTime.Now.Ticks - _minimizedTicks;
            long minimizedSeconds = minimizedTickCount / TimeSpan.TicksPerSecond;
            args = new ExitMinimizedStateEventArgs(minimizedSeconds);
         }

         try
         {
            this.Visible = true ;

            ShowInTaskbar = true;
            if ( _userWindowState != FormWindowState.Minimized ) 
            {
               WindowState  = _userWindowState ;
            }
            else
            {
               WindowState = FormWindowState.Maximized ;               
            }
            
            this.Activate ( ) ;
            EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(false));           
            
         }
         finally
         {
            _localStateChange = false ;
             if (args != null)
             {
                EventBroker.Instance.PublishEvent<ExitMinimizedStateEventArgs>(this, args);
             }
         }
      }
      
      private void DelayExitMinimized()
      {
         long minimizedTickCount = DateTime.Now.Ticks - _minimizedTicks;
         long minimizedSeconds = minimizedTickCount / TimeSpan.TicksPerSecond;

         ExitMinimizedStateEventArgs args = new ExitMinimizedStateEventArgs(minimizedSeconds);

         // This must be done in a thread -- otherwise, the login box is displayed for the Storage Server Manager UI
         Thread thread = new Thread(() =>
         {
            Thread.Sleep(500);
            EventBroker.Instance.PublishEvent<ExitMinimizedStateEventArgs>(this, args);
         });
         thread.IsBackground = true;
         thread.Start();
      }
      
      internal void MinimizeToRestore()
      {
         EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(false));
         DelayExitMinimized();
      }
      
      protected override void OnFormClosing ( FormClosingEventArgs e )
      {
         if ( e.CloseReason == CloseReason.UserClosing ) 
         {
            e.Cancel = true ;            
            WindowState = FormWindowState.Minimized ;
            Hide();
         }
         else
         {
            MainNotifyIcon.Dispose ( ) ;
            
            base.OnFormClosing(e);
         }
      }

      protected override void OnSizeChanged(EventArgs e)
      {
         base.OnSizeChanged(e);
         
         if ( WindowState != _lastWindowState ) 
         {
            if ( null != WindowStateChanged ) 
            {
               WindowStateChanged ( this, e ) ;
            }
         }
         _lastWindowState = WindowState;
      }

    //The ControlPaint Class has methods to Lighten and Darken Colors, but they return a Solid Color.
    //The Following 2 methods return a modified color with original Alpha.
    private Color DarkenColor(Color colorIn, int percent)
    {
      //This method returns Black if you Darken by 100%
      
      if (percent < 0 || percent > 100)
        throw new ArgumentOutOfRangeException("percent");
      
      int a, r, g, b;
      
      a = colorIn.A;
      r = colorIn.R - (int)((colorIn.R / 100f) * percent);
      g = colorIn.G - (int)((colorIn.G / 100f) * percent);
      b = colorIn.B - (int)((colorIn.B / 100f) * percent);
      
      return Color.FromArgb(a, r, g, b);
    }

      private Color LightenColor(Color colorIn, int percent)
      {
      //This method returns White if you lighten by 100%
      
      if (percent < 0 || percent > 100)
         throw new ArgumentOutOfRangeException("percent");
      
      int a, r, g, b;
      
      a = colorIn.A;
      r = colorIn.R + (int)(((255f - colorIn.R) / 100f) * percent);
      g = colorIn.G + (int)(((255f - colorIn.G) / 100f) * percent);
      b = colorIn.B + (int)(((255f - colorIn.B) / 100f) * percent);
      
      return Color.FromArgb(a, r, g, b);
      }
      
      event EventHandler WindowStateChanged ;
      FormWindowState _userWindowState ;
      FormWindowState _lastWindowState ;
      bool _localStateChange = false ;
      long _minimizedTicks = 0;

      private void MainForm_Shown(object sender, EventArgs e)
      {
// #if !DEBUG
         SplashForm.CloseSplash();
// #endif
         MainNotifyIcon.Visible = true;
      }
   }
}
