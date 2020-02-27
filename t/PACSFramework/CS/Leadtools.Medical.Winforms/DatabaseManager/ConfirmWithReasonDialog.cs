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

namespace Leadtools.Medical.Winforms
{
   public partial class ConfirmWithReasonDialog : Form
   {
      public ConfirmWithReasonDialog ( )
      {
         InitializeComponent();

         ReasonTextBox.TextChanged += new EventHandler ( ReasonTextBox_TextChanged ) ;
      }
      
      void EnableAcceptButton()
      {
         bool bEnabled = ReasonTextBox.Text.Trim ( ).Length > 0;
         if (ConfirmCheckBox.Visible)
            bEnabled = bEnabled && ConfirmCheckBox.Checked;
         AcceptButton.Enabled = bEnabled;
      }

      void ReasonTextBox_TextChanged ( object sender, EventArgs e )
      {
         EnableAcceptButton();
      }
      
      public string Message
      {
         get
         {
            return TextLabel.Text ;
         }
         
         set
         {
            TextLabel.Text = value ;
         }
      }
      
      public string Reason
      {
         get
         {
            return ReasonTextBox.Text ;
         }
         
         set
         {
            ReasonTextBox.Text = value ;
         }
      }
      
      public Image ConfirmIcon
      {
         get
         {
            return IconPictureBox.Image ;
         }
         
         set
         {
            IconPictureBox.Image = value ;
         }
      }
      
      public bool ConfirmCheckBoxVisible
      {
         get
         {
            return ConfirmCheckBox.Visible ;
         }
         
         set
         {
            ConfirmCheckBox.Visible = value ;
         }
      }

      private void ConfirmCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         EnableAcceptButton();
      }

      public void SetDefaultWarningIcon()
      {
         ConfirmIcon = Properties.Resources.Warning_128;
      }
   }
}
