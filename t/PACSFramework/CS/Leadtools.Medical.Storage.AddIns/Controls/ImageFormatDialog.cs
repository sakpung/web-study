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
using Leadtools ;
using Leadtools.Medical.Storage.AddIns.Configuration;

namespace Leadtools.Medical.Storage.AddIns
{
   public partial class ImageFormatDialog : Form
   {
      public ImageFormatDialog()
      {
         InitializeComponent();
         
         LosslessRadioButton.Checked = true ;
         ImageQFactorNumeric.Enabled = false ;

         LosslessRadioButton.CheckedChanged += new EventHandler ( LosslessRadioButton_CheckedChanged ) ;
         ImageFormatComboBox.SelectedValueChanged += ImageFormatComboBox_SelectedValueChanged;
      }

      void ImageFormatComboBox_SelectedValueChanged(object sender, EventArgs e)
      {
          if(ImageFormatComboBox.SelectedValue.ToString() == "TifJ2k")
          {
              ImageWidthNumeric.Value = 0;
              ImageHeightNumeric.Value = 0;
              DisableControls(this, ImageFormatComboBox);
          }
          else
          {
              if(!ImageQFactorNumeric.Enabled)
                  EnableControls(this);
          }
      }

      private void DisableControls(Control con, Control except)
      {
          foreach (Control c in con.Controls)
          {
              c.Enabled = c == except || (c is Button);
          }          
      }

      private void EnableControls(Control con)
      {
          foreach (Control c in con.Controls)
          {
              c.Enabled = true;
          } 
      }

      public SaveImageFormatElement DataSource
      {
         get 
         {
            return _dataSource ;
         }
         
         set 
         {
            if ( value != _dataSource )
            {
               _dataSource = value ;
               
               if ( value != null ) 
               {
                  ImageWidthNumeric.Value   = _dataSource.Width ;
                  ImageHeightNumeric.Value  = _dataSource.Height ;
                  
                  if ( _dataSource.QFactor == 0 ) 
                  {
                     LosslessRadioButton.Checked = true ;
                  }
                  else
                  {
                     LossyRadioButton.Checked = true ;
                     
                     ImageQFactorNumeric.Value = _dataSource.QFactor ;
                  }
                  
                  ImageFormatComboBox.DataSource = AllowedFormats ;
                  
                  ImageFormatComboBox.SelectedItem = _dataSource.Format ;
               }
               else
               {
                  ImageWidthNumeric.Value   = 64 ;
                  ImageHeightNumeric.Value  = 64 ;
                  
                  LosslessRadioButton.Checked = true ;
                  
                  ImageFormatComboBox.DataSource = null ;
               }
            }
         }
      }
      
      public string[] AllowedFormats
      {
         get ;
         set ;
      }

      void LosslessRadioButton_CheckedChanged(object sender, EventArgs e)
      {
         ImageQFactorNumeric.Enabled = LossyRadioButton.Checked ;
      }

      private void ImageFormatDialog_Validating(object sender, CancelEventArgs e)
      {
         string errorMessage ;
         Control validatingControl ;
         
         errorMessage      = "Value can't be empty." ;
         validatingControl = sender as Control ;
         
         if ( validatingControl.Text.Length == 0 )
         {
            errorProvider1.SetError ( validatingControl, errorMessage ) ;
            
            e.Cancel = true ;
         }
         else
         {
            errorProvider1.SetError ( validatingControl, "" ) ;
            
            e.Cancel = false ;
         }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         if ( !ValidateChildren ( ValidationConstraints.Enabled ) )
         {
            DialogResult = DialogResult.None ;
            
            return ;
         }
         
         if ( _dataSource != null ) 
         {
            _dataSource.Width  = (int) ImageWidthNumeric.Value ;
            _dataSource.Height = (int) ImageHeightNumeric.Value ;
            
            if ( LosslessRadioButton.Checked ) 
            {
               _dataSource.QFactor = 0 ;
            }
            else
            {
               _dataSource.QFactor = (int) ImageQFactorNumeric.Value ;
            }
            
            _dataSource.Format = ( ImageFormatComboBox.SelectedItem ).ToString ( ) ;
         }
      }
      
      private SaveImageFormatElement _dataSource ;
   }
}
