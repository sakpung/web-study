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
using Leadtools.Dicom;

namespace Leadtools.Demos.StorageServer.UI
{
   public partial class AeInfoDetails : Form
   {
      public AeInfoDetails()
      {
         InitializeComponent();

         ConfirmChangesButton.Click += new EventHandler(ConfirmChangesButton_Click);
      }

      void ConfirmChangesButton_Click ( object sender, EventArgs e )
      {
         DialogResult = DialogResult.OK ;
         
         if ( AETitleTextBox.Text.Length == 0 || AETitleTextBox.Text.Length > 16 )
         {
            errorProvider1.SetError ( AETitleTextBox, "AE Title must be 16 characters." ) ;
            
            DialogResult = DialogResult.None ;
         }
         else
         {
            errorProvider1.SetError ( AETitleTextBox, string.Empty ) ;
         }
         
         if ( IpAddressComboBox.Text.Length == 0 )
         {
            errorProvider1.SetError ( IpAddressComboBox, "Enter an IP Address." ) ;
            
            DialogResult = DialogResult.None ;
         }
         else
         {
            errorProvider1.SetError ( IpAddressComboBox, string.Empty ) ;
         }
         
         if ( PortNumericUpDown.Value == 0 )
         {
            errorProvider1.SetError ( PortNumericUpDown, "Enter a port." ) ;
            
            DialogResult = DialogResult.None ;
         }
         else
         {
            errorProvider1.SetError ( PortNumericUpDown, string.Empty ) ;
         }
      }

      public void SetIpAddressList ( string [] ipadresses ) 
      {
         IpAddressComboBox.DataSource = ipadresses ;
      }
      
      public string DialogTitle
      {
         get
         {
            return this.Text ;
         }
         
         set
         {
            this.Text = value ;
         }
      }
      
      public string AETitle
      {
         get
         {
            return AETitleTextBox.Text ;
         }
         
         set
         {
            AETitleTextBox.Text = value ;
         }
      }
      
      public string Address
      {
         get
         {
            return IpAddressComboBox.Text ;
         }

         set
         {
            IpAddressComboBox.Text = value ;
         }
      }
      
      public int Port
      {
         get
         {
            return (int) PortNumericUpDown.Value ;
         }
         
         set
         {
            PortNumericUpDown.Value = value ;
         }
      }
      
      public bool Secure
      {
         get
         {
            return SecureCheckBox.Checked ;
         }
         
         set
         {
            SecureCheckBox.Checked = value ;
         }
      }
      
      public string ConfirmText 
      {
         get
         {
            return ConfirmChangesButton.Text ;
         }
         
         set
         {
            ConfirmChangesButton.Text = value ;
         }
      }
      
      public bool CanEnterIp
      {
         get
         {
            return ( IpAddressComboBox.DropDownStyle != ComboBoxStyle.DropDownList ) ;
         }
         
         set
         {
            IpAddressComboBox.DropDownStyle = ( value ) ? ComboBoxStyle.Simple : ComboBoxStyle.DropDownList ;
         }
      }

   }
}
