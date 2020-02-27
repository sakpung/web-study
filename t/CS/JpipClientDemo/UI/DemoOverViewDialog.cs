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
using System.Configuration ;

namespace JpipClientDemo
{
   public partial class DemoOverViewDialog : Form
   {
      public DemoOverViewDialog()
      {
         InitializeComponent();
      }

      private void DemoOverViewDialog_FormClosing 
      ( 
         object sender, 
         FormClosingEventArgs e 
      )
      {
         try
         {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if ( null == config ) 
            {
               return ;
            }
            
            AddConfigurationValue ( config,"ShowOverView", 
                                    chkShowDlg.Checked.ToString ( ).ToLower ( ) );
                                    
            config.Save ( ConfigurationSaveMode.Modified ) ;
            
            ConfigurationManager.RefreshSection ( "appSettings" ) ;
         }
         catch ( Exception exception )
         {
            MessageBox.Show ( exception.Message, 
                              this.Text, 
                              MessageBoxButtons.OK, 
                              MessageBoxIcon.Warning ) ;
         }
      }
         
      private void AddConfigurationValue
      ( 
         System.Configuration.Configuration config, 
         string key, 
         string value  
      )
      {
         if (null == config.AppSettings.Settings[key])
         {
            config.AppSettings.Settings.Add(key, value);
         }
         else
         {
            config.AppSettings.Settings[key].Value = value;
         }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         this.Close ( ) ;
      }
   }
}
