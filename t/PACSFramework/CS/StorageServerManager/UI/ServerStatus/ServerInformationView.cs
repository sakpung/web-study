// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Medical.Winforms;
using Leadtools.Demos.StorageServer.DataTypes;

namespace Leadtools.Demos.StorageServer.UI
{
   public partial class ServerInformationView : UserControl
   {
      public ServerInformationView()
      {
         InitializeComponent();

         SetStyle ( ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint| 
                    ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor,
                    true);                                     
      }      

      public string ServerDisplayName
      {
         get { return ServiceDisplayNameLabel.Text ; }

         set { ServiceDisplayNameLabel.Text = value ; }
      }

      public string ServerAE
      {
         get { return AETitleLabel.Text ; } 
         set { AETitleLabel.Text = value ; } 
      }

      public string IpAddress
      {
         get { return IpAddressLabel.Text ; }
         set { IpAddressLabel.Text = value ; } 
      }

      public string Port
      {
         get { return PortLabel.Text ; }
         set { PortLabel.Text = value ; }
      }

      private bool _isSecure = false;

      public bool IsSecure
      {
         get
         {
            return _isSecure;
         }
         set
         {
            _isSecure = value;
            pictureBoxSecure.Visible = _isSecure;
         }
      }

      public bool IsServerRunning
      {  
         get { return _isServerRunning ; } 
         
         set
         {
            if ( value != _isServerRunning ) 
            {
               _isServerRunning = value ;
               
               ServerStatusPictureBox.Image = GetStatusImage ( ) ;
               buttonStart.Enabled = !_isServerRunning;
               buttonStop.Enabled = _isServerRunning;
            }
         }
      }

      public string Status
      {
         set
         {
            if (value == "Running")
               labelStatus.ForeColor = Color.Green;
            else
               labelStatus.ForeColor = Color.Red;

            labelStatus.Text = value;
         }
      }

      public bool CanStart
      {
         get
         {
            return buttonStart.Enabled;
         }
         set
         {
            buttonStart.Enabled = value;
         }
      }

      public bool CanChangeSettings
      {
         get
         {
            return buttonSettings.Enabled;
         }
         set
         {
            buttonSettings.Enabled = value;
         }
      }

      public event EventHandler StartService ;
      public event EventHandler StopService ;      

      private Image GetStatusImage()
      {
         if ( IsServerRunning ) 
         {
            toolTip.SetToolTip(ServerStatusPictureBox, "Server is running");
            return global::Leadtools.Demos.StorageServer.Properties.Resources._1313684564_Symbol_Check ;
         }
         else
         {
            toolTip.SetToolTip(ServerStatusPictureBox, "Server is stopped");
            return global::Leadtools.Demos.StorageServer.Properties.Resources._1313685426_Symbol_Error ;
         }
      }


      private bool _isServerRunning ;


      public bool CanStartStopServer 
      { 
         get
         {
            return  buttonStop.Enabled ;
         }

         set
         {
            buttonStop.Enabled = value;
            //buttonStart.Enabled = !value && !_isServerRunning;
         }
      }

      private void buttonSettings_Click(object sender, EventArgs e)
      {
         EventBroker.Instance.PublishEvent<DisplayFeatureEventArgs>(this, new DisplayFeatureEventArgs(FeatureNames.DisplaySettingsFeature));
      }

      private void buttonAbout_Click(object sender, EventArgs e)
      {
         ShowAbout();
      }

      private void buttonExit_Click(object sender, EventArgs e)
      {
         Application.Exit();
         // Environment.Exit(0);
      }

      private void buttonStart_Click(object sender, EventArgs e)
      {
         try
         {
            if (!IsServerRunning && (null != StartService))
            {
               buttonStart.Enabled = false;
               StartService(this, EventArgs.Empty);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }
      
      public void StopRunningService()
      {
         try
         {
            if (IsServerRunning && (null != StopService))
            {
               buttonStop.Enabled = false;
               StopService(this, EventArgs.Empty);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      } 

      private void buttonStop_Click(object sender, EventArgs e)
      {
         StopRunningService();
      }     
   }   
}
