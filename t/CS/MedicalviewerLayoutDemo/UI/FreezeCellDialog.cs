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

namespace MedicalViewerLayoutDemo
{
   public partial class FreezeCellDialog : Form
   {
      public FreezeCellDialog(MainForm owner)
      {
         InitializeComponent();

         this.CancelButton = cancelButton;
         this.AcceptButton = okButton;

         // set the allowed range for the cell index text box.
         freezeCombo.SelectedIndex = 0;
         cellIndexText.MinimumAllowed = -1;
         cellIndexText.MaximumAllowed = owner.Viewer.Cells.Count - 1;
         cellIndexText.Text = (0).ToString();
      }

      private void okButton_Click(object sender, EventArgs e)
      {
         applyButton_Click(sender, e);
         this.Close();
      }

      private void applyToSingleRadio_CheckedChanged(object sender, EventArgs e)
      {
         cellIndexText.Enabled = applyToSingleRadio.Checked;
         cellIndexLabel.Enabled = applyToSingleRadio.Checked;
         if (applyToSingleRadio.Checked)
            cellIndexText.Focus();
      }

      private void applyButton_Click(object sender, EventArgs e)
      {
         try
         {
            if (applyToSingleRadio.Checked)
               ((MainForm)this.Owner).Viewer.Cells[Convert.ToInt32(cellIndexText.Text)].Frozen = (freezeCombo.SelectedIndex == 0);
            else if (applyToSelectedRadio.Checked)
            {
                if (freezeCombo.SelectedIndex == 0)
                    ((MainForm)this.Owner).Viewer.Cells.FreezeSelected(freezeCombo.SelectedIndex == 0);
                else
                    ((MainForm)this.Owner).Viewer.Cells.FreezeAll(false);
            }
            else if (applyToAllRadio.Checked)
            {
                if (freezeCombo.SelectedIndex == 0)
                    ((MainForm)this.Owner).Viewer.Cells.FreezeAll(freezeCombo.SelectedIndex == 0);
                else
                    ((MainForm)this.Owner).Viewer.Cells.FreezeAll(false);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }
   }
}
