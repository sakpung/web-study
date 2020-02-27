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

using Leadtools.MedicalViewer;

namespace Main3DDemo
{
   public partial class SetActionDialog : Form
   {
      MedicalViewer _viewer;

      private string GetSeparatedText(string sourceString)
      {
         string result = sourceString.ToString();
         int    index = 1;

         while (index < result.Length)
         {
            if (Char.IsUpper(result[index]) || result[index] == '3')
            {
               result = result.Insert(index, " ");
               if (result[index + 1] == '3')
                  ++index;
               ++index;
            }

            ++index;
         }
         return result;
      }

      private MedicalViewerActionType _actionType;

      public SetActionDialog(MedicalViewer viewer, MedicalViewerActionType actionType)
      {
         _viewer = viewer;
         InitializeComponent();

         _actionType = actionType;
         this.Text = "Set " + GetSeparatedText(actionType.ToString()) + " Action";

         if (_viewer.IsValidForAction(actionType, MedicalViewerMouseButtons.Wheel))
         {
            if (actionType != MedicalViewerActionType.WindowLevel && actionType != MedicalViewerActionType.Alpha)
            _cmbMouseButton.Items.Insert(4, "Wheel");
         }

         if (_viewer.IsValidForAction(actionType, MedicalViewerActionFlags.Selected))
         {
            _cmbApplyTo.Items.Add("Selected Cells");
            _cmbApplyTo.Items.Add("All Cells");
         }

         if (_viewer.IsValidForAction(actionType, MedicalViewerActionFlags.Selected))
            _cmbApplyingMethod.Items.Add("On Release");

         MedicalViewerActionFlags actionFlags = _viewer.GetActionFlags(actionType);

         if ((actionFlags | MedicalViewerActionFlags.OnRelease) == actionFlags)
            _cmbApplyingMethod.SelectedIndex = 1;
         else
            _cmbApplyingMethod.SelectedIndex = 0;

         if ((actionFlags | MedicalViewerActionFlags.Selected) == actionFlags)
            _cmbApplyTo.SelectedIndex = 1;
         else if ((actionFlags | MedicalViewerActionFlags.AllCells) == actionFlags)
            _cmbApplyTo.SelectedIndex = 2;
         else
            _cmbApplyTo.SelectedIndex = 0;

         _cmbMouseButton.SelectedIndex = (int)_viewer.GetActionButton(actionType);
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
         _btnApply_Click(sender, e);
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         MedicalViewerActionFlags applyingOperation = (MedicalViewerActionFlags)_cmbApplyTo.SelectedIndex;
         if ((_cmbApplyingMethod.SelectedIndex == 1) && (_cmbApplyTo.SelectedIndex != 0))
            applyingOperation ^= MedicalViewerActionFlags.OnRelease;

         _viewer.SetAction(_actionType, (MedicalViewerMouseButtons)_cmbMouseButton.SelectedIndex, applyingOperation);
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void _cmbApplyTo_SelectedIndexChanged(object sender, EventArgs e)
      {
         _cmbApplyingMethod.Enabled = ((_cmbMouseButton.Text == "Wheel") || (_cmbApplyTo.SelectedIndex == 0)) ? false : true;
      }

      private void _cmbMouseButton_SelectedIndexChanged(object sender, EventArgs e)
      {
         _cmbApplyingMethod.Enabled = ((_cmbMouseButton.Text == "Wheel") || (_cmbMouseButton.SelectedIndex == 0) || (_cmbApplyTo.SelectedIndex == 0)) ? false : true;
         _cmbApplyTo.Enabled = (_cmbMouseButton.SelectedIndex == 0) ? false : true;
      }
   }
}
