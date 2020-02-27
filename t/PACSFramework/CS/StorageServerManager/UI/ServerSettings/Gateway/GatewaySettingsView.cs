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

namespace Leadtools.Demos.StorageServer.UI
{
   public partial class GatewaySettingsView : UserControl
   {
      public GatewaySettingsView()
      {
         InitializeComponent();

         GatewaysItemsGridView.AddText    = "Create Gateway" ;
         GatewaysItemsGridView.ModifyText = "Modify Gateway" ;
         GatewaysItemsGridView.DeleteText = "Remove Gateway" ;
         
         RemoteServersItemsGridView.AddText    = "Add Server" ;
         RemoteServersItemsGridView.ModifyText = "Modify Server" ;
         RemoteServersItemsGridView.DeleteText = "Delete Server" ;

         EnabledChanged += new EventHandler(GatewaySettingsView_EnabledChanged);
         
         NumberOfTimesToUseSecondaryServerNumericUpDown.ValueChanged += new EventHandler ( NumberOfTimesToUseSecondaryServerNumericUpDown_ValueChanged ) ;
      }

      void GatewaySettingsView_EnabledChanged(object sender, EventArgs e)
      {
         GatewaysItemsGridView.CanAdd = Enabled;
      }

      public int NumberOfTimesToUseSecondaryServer
      {
         get
         {
            return (int) NumberOfTimesToUseSecondaryServerNumericUpDown.Value ;;
         }
         set
         {
            NumberOfTimesToUseSecondaryServerNumericUpDown.Value = value ;
         }
      }
      
      public event EventHandler NumberOfTimesToUseSecondaryServerChanged ;
      
      void NumberOfTimesToUseSecondaryServerNumericUpDown_ValueChanged ( object sender, EventArgs e )
      {
         if ( null != NumberOfTimesToUseSecondaryServerChanged ) 
         {
            NumberOfTimesToUseSecondaryServerChanged ( this, e ) ;
         }
      }

      internal void ShowErrorMessage( string errorMessage )
      {
         MessageBox.Show ( errorMessage, "Gateway", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
      }

      internal bool ShowConfirmMessage(string confirmMessage)
      {
         DialogResult dr = MessageBox.Show(confirmMessage, "Gateway", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
         return (dr == DialogResult.Yes);
      }

      internal void ShowMessage(string message)
      {
         MessageBox.Show(message, "Gateway", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
   }
}
