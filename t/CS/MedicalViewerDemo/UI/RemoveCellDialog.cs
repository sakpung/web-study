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

using Leadtools.Demos;

namespace MedicalViewerDemo
{
   public partial class RemoveCellDialog : Form
   {
      public RemoveCellDialog(MainForm owner)
      {
         InitializeComponent();

         // set the allowed range for the cell index text box.
         cellIndexText.MinimumAllowed = -1;
         cellIndexText.MaximumAllowed = owner.Viewer.Cells.Count - 1;
         cellIndexText.Text = (0).ToString();
      }

      private void removeSpecificRadio_CheckedChanged(object sender, EventArgs e)
      {
         cellIndexLabel.Enabled = removeSpecificRadio.Checked;
         cellIndexText.Enabled = removeSpecificRadio.Checked;
         if (removeSpecificRadio.Checked)
            cellIndexText.Focus();
      }

      private void okButton_Click(object sender, EventArgs e)
      {
         try
         {
            if (removeSpecificRadio.Checked)
               ((MainForm)this.Owner).Viewer.Cells.RemoveAt(Convert.ToInt32(cellIndexText.Text));
            else if (removeSelectedRadio.Checked)
            {
               ((MainForm)this.Owner).RemoveSelectedCells();
            }
            else if (removeAllRadio.Checked)
            {
               ((MainForm)this.Owner).Viewer.Cells.Clear();
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         this.Close();
      }
   }
}
