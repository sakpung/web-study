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
using Leadtools.Dicom.Scp.Media;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Demos;

namespace Leadtools.Medical.Media.AddIns.UI
{
   public partial class MediaConfigurationDialog : Form
   {
      public MediaConfigurationDialog ( )
      {
         InitializeComponent ( ) ;

         Init ( ) ;

         RegisterEvents ( ) ;
      }

      private void Init ( )
      {
         ItemStatusButton.Tag         = MediaJobStatusView ;
         MediaConfigurationButton.Tag = MediaConfigurationView ;
         MediaMaintenanceButton.Tag   = MediaJobMaintenanceView ;
         MediaAutoCreationButton.Tag  = AutoCreationConfigView ;
         
         ToolBarItemButton_Click ( ItemStatusButton, EventArgs.Empty ) ;
      }

      private void RegisterEvents()
      {
         ItemStatusButton.Click           += new EventHandler ( ToolBarItemButton_Click ) ;
         MediaConfigurationButton.Click   += new EventHandler ( ToolBarItemButton_Click ) ;
         MediaMaintenanceButton.Click     += new EventHandler ( ToolBarItemButton_Click ) ;
         MediaAutoCreationButton.Click    += new EventHandler ( ToolBarItemButton_Click ) ;
      }

      void ToolBarItemButton_Click(object sender, EventArgs e)
      {
         try
         {
            foreach ( Control view in panel2.Controls ) 
            {
               view.Visible = false ;
            }
            
            ( ( sender as Button ).Tag as Control ).Visible = true ;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }
   }
}
