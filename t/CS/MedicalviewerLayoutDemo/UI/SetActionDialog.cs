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

namespace MedicalViewerLayoutDemo
{
   public partial class SetActionDialog : Form
   {
      private string GetSeparatedText(string sourceString)
      {
         string result = sourceString.ToString();
         int    index = 1;

         while (index < result.Length)
         {
            if (Char.IsUpper(result[index]))
            {
               result = result.Insert(index, " ");
               ++index;
            }
            
            ++index;
         }
         return result;
      }

      private MedicalViewerActionType _actionType;
      private MedicalViewerCell _SelectedCell;
      private MedicalViewer _viewer;

      public SetActionDialog(MainForm owner, MedicalViewer viewer, MedicalViewerCell selectedCell, MedicalViewerActionType actionType)
      {
         InitializeComponent();
         _viewer = viewer;
         _actionType = actionType;
         _SelectedCell = selectedCell;
         this.Text = "Set " + GetSeparatedText(actionType.ToString()) + " Action";

         if (selectedCell.IsValidForAction(actionType, MedicalViewerMouseButtons.Wheel))
             _cmbMouseButton.Items.Insert(4, "Wheel");

         if (selectedCell.IsValidForAction(actionType, MedicalViewerActionFlags.Selected))
         {
             _cmbApplyTo.Items.Add("Selected Cells");
             _cmbApplyTo.Items.Add("All Cells");
         }

         if (selectedCell.IsValidForAction(actionType, MedicalViewerActionFlags.Selected))
             _cmbApplyingMethod.Items.Add("On Release");

         MedicalViewerActionFlags actionFlags = selectedCell.GetActionFlags(actionType);

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

         _cmbMouseButton.SelectedIndex = (int)selectedCell.GetActionButton(actionType);
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
         _btnApply_Click(sender, e);
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         MedicalViewerActionFlags applyingOperation = (MedicalViewerActionFlags)0;

         switch (_cmbApplyTo.SelectedIndex)
         {
            case 0:
               applyingOperation = MedicalViewerActionFlags.Active;
               break;
            case 1:
               applyingOperation = MedicalViewerActionFlags.Selected;
               break;
            case 2:
               applyingOperation = MedicalViewerActionFlags.AllCells;
               break;
         }

         if (_cmbApplyTo.SelectedIndex > 0)
         {
            if (_cmbApplyingMethod.SelectedIndex == 1)
               applyingOperation ^= MedicalViewerActionFlags.OnRelease;
            else
               applyingOperation ^= MedicalViewerActionFlags.RealTime;

         }

         foreach (MedicalViewerBaseCell viewerCell in _viewer.Cells)
         {
            viewerCell.SetAction(_actionType, (MedicalViewerMouseButtons)_cmbMouseButton.SelectedIndex, applyingOperation);
         }
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
