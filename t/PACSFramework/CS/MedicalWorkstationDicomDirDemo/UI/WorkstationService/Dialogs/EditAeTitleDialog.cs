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
using System.Text.RegularExpressions;
using Leadtools.Dicom.AddIn.Common;


namespace Leadtools.Demos.Workstation
{
    public partial class EditAeTitleDialog : Form
    {
        private AeInfo _AeInfo = null;

        public AeInfo AeInfo
        {
            get
            {
                return _AeInfo;
            }
            
            set
            {
               _AeInfo = value ;
            }
        }

        public EditAeTitleDialog ( )
        {
            InitializeComponent();
            
            Icon = WorkstationUtils.GetApplicationIcon ( ) ;
            
            AETitleTextBox.Validating += new CancelEventHandler(AETitle_Validating);
        }

        void AETitle_Validating(object sender, CancelEventArgs e)
        {
            if ( AETitleTextBox.Text .Length == 0 ) 
            {
               AeErrorProvider.SetError ( AETitleTextBox, "AE Title can't be empty." ) ;
               
               e.Cancel = true ;
            }
            else if ( AETitleTextBox.Text .Length > 16 ) 
            {
               AeErrorProvider.SetError ( AETitleTextBox, "AE Title must be less than 16 characters." ) ;
               
               e.Cancel = true ;
            }
            else 
            {
               AeErrorProvider.SetError ( AETitleTextBox, string.Empty ) ;
            }
        }

      private void EditAeTitleDialog_Load ( object sender, EventArgs e )
      {
         if (_AeInfo == null)
         {
            Text = "Add AE Title" ;
         }
         else
         {             
            Text = "Edit AE Title";
            AETitleTextBox.Text  = _AeInfo.AETitle;
            HostNameTextBox.Text = _AeInfo.Address;
            
            PortNumericUpDown.Value = Convert.ToDecimal(_AeInfo.Port);
            SecurePortNumericUpDown.Value = Convert.ToDecimal(_AeInfo.SecurePort);
         }
            
         AETitle_TextChanged(null, EventArgs.Empty);
      }


        private void EditAeTitleDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (_AeInfo == null)
                {
                    _AeInfo = new AeInfo();
                }

                _AeInfo.AETitle = AETitleTextBox.Text;
                _AeInfo.Address = HostNameTextBox.Text;                    
                _AeInfo.Port    = Convert.ToInt32(PortNumericUpDown.Value);
                _AeInfo.SecurePort = Convert.ToInt32(SecurePortNumericUpDown.Value);                
            }
        }


        private void AETitle_TextChanged(object sender, EventArgs e)
        {
            OkButton.Enabled = AETitleTextBox.Text != string.Empty;
        }
    }
}
