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

namespace MedicalViewerDemo
{
   public partial class SetNudgeShrinkActionDialog : Form
   {
      MedicalViewerMultiCell cell = null;
      MedicalViewer viewer;
      MainForm _owner;
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

      public SetNudgeShrinkActionDialog(MainForm owner)
      {
         InitializeComponent();

         cell = MainForm.DefaultCell;
         viewer = owner.Viewer;
         _owner = owner;

         if (cell.IsValidForAction(MedicalViewerActionType.NudgeTool, MedicalViewerMouseButtons.Wheel))
            _cmbNudgeMouseButton.Items.Insert(4, "Wheel");
         if (cell.IsValidForAction(MedicalViewerActionType.ShrinkTool, MedicalViewerMouseButtons.Wheel))
            _cmbShrinkMouseButton.Items.Insert(4, "Wheel");

         if (cell.IsValidForAction(MedicalViewerActionType.NudgeTool, MedicalViewerActionFlags.Selected))
         {
            _cmbNudgeApplyTo.Items.Add("Selected Cells");
            _cmbNudgeApplyTo.Items.Add("All Cells");
         }
         if (cell.IsValidForAction(MedicalViewerActionType.ShrinkTool, MedicalViewerActionFlags.Selected))
         {
            _cmbShrinkApplyTo.Items.Add("Selected Cells");
            _cmbShrinkApplyTo.Items.Add("All Cells");
         }

         if (cell.IsValidForAction(MedicalViewerActionType.NudgeTool, MedicalViewerActionFlags.Selected))
            _cmbNudgeApplyingMethod.Items.Add("On Release");
         if (cell.IsValidForAction(MedicalViewerActionType.ShrinkTool, MedicalViewerActionFlags.Selected))
            _cmbNudgeMouseButton.Items.Add("On Release");

         MedicalViewerActionFlags actionFlags = cell.GetActionFlags(MedicalViewerActionType.NudgeTool);
         if ((actionFlags | MedicalViewerActionFlags.OnRelease) == actionFlags)
            _cmbNudgeApplyingMethod.SelectedIndex = 1;
         else
            _cmbNudgeApplyingMethod.SelectedIndex = 0;

         if ((actionFlags & MedicalViewerActionFlags.Selected) == MedicalViewerActionFlags.Selected)
            _cmbNudgeApplyTo.SelectedIndex = 1;
         else if ((actionFlags & MedicalViewerActionFlags.AllCells) == MedicalViewerActionFlags.AllCells)
            _cmbNudgeApplyTo.SelectedIndex = 2;
         else
            _cmbNudgeApplyTo.SelectedIndex = 0;

         _cmbNudgeMouseButton.SelectedIndex = (int)cell.GetActionButton(MedicalViewerActionType.NudgeTool);


         actionFlags = cell.GetActionFlags(MedicalViewerActionType.ShrinkTool);
         if ((actionFlags | MedicalViewerActionFlags.OnRelease) == actionFlags)
            _cmbShrinkApplyingMethod.SelectedIndex = 1;
         else
            _cmbShrinkApplyingMethod.SelectedIndex = 0;

         if ((actionFlags & MedicalViewerActionFlags.Selected) == MedicalViewerActionFlags.Selected)
            _cmbShrinkApplyTo.SelectedIndex = 1;
         else if ((actionFlags & MedicalViewerActionFlags.AllCells) == MedicalViewerActionFlags.AllCells)
            _cmbShrinkApplyTo.SelectedIndex = 2;
         else
            _cmbShrinkApplyTo.SelectedIndex = 0;

         _cmbShrinkMouseButton.SelectedIndex = (int)cell.GetActionButton(MedicalViewerActionType.ShrinkTool);
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
         _btnApply_Click(sender, e);
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         MedicalViewerActionFlags applyingOperation = (MedicalViewerActionFlags)0;

         switch (_cmbNudgeApplyTo.SelectedIndex)
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

         if (_cmbNudgeApplyTo.SelectedIndex > 0)
         {
            if (_cmbNudgeApplyingMethod.SelectedIndex == 1)
               applyingOperation ^= MedicalViewerActionFlags.OnRelease;
            else
               applyingOperation ^= MedicalViewerActionFlags.RealTime;

         }

         if ((MedicalViewerMouseButtons)_cmbNudgeMouseButton.SelectedIndex == MedicalViewerMouseButtons.Left)
         {
            _owner.CurrentAction = MedicalViewerActionType.NudgeTool;
            _owner.LeftButtonAction = MedicalViewerActionType.NudgeTool;
             _owner.CheckMoveMarkersAction(false);
             _owner.CheckSelectPoints(false);
         }
         if ((MedicalViewerMouseButtons)_cmbNudgeMouseButton.SelectedIndex == MedicalViewerMouseButtons.Right)
         {
            _owner.RightButtonAction = MedicalViewerActionType.NudgeTool;
         }

         cell.SetAction(MedicalViewerActionType.NudgeTool, (MedicalViewerMouseButtons)_cmbNudgeMouseButton.SelectedIndex, applyingOperation);

         foreach (MedicalViewerBaseCell viewerCell in viewer.Cells)
         {
            viewerCell.SetAction(MedicalViewerActionType.NudgeTool, (MedicalViewerMouseButtons)_cmbNudgeMouseButton.SelectedIndex, applyingOperation);
         }




         applyingOperation = (MedicalViewerActionFlags)0;

         switch (_cmbShrinkApplyTo.SelectedIndex)
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

         if (_cmbShrinkApplyTo.SelectedIndex > 0)
         {
            if (_cmbShrinkApplyingMethod.SelectedIndex == 1)
               applyingOperation ^= MedicalViewerActionFlags.OnRelease;
            else
               applyingOperation ^= MedicalViewerActionFlags.RealTime;

         }
         if ((MedicalViewerMouseButtons)_cmbShrinkMouseButton.SelectedIndex == MedicalViewerMouseButtons.Left)
         {
            _owner.CurrentAction = MedicalViewerActionType.ShrinkTool;
            _owner.LeftButtonAction = MedicalViewerActionType.ShrinkTool;
            _owner.CheckMoveMarkersAction(false);
            _owner.CheckSelectPoints(false);
         }
         if ((MedicalViewerMouseButtons)_cmbShrinkMouseButton.SelectedIndex == MedicalViewerMouseButtons.Right)
         {
            _owner.RightButtonAction = MedicalViewerActionType.ShrinkTool;
         }

         cell.SetAction(MedicalViewerActionType.ShrinkTool, (MedicalViewerMouseButtons)_cmbShrinkMouseButton.SelectedIndex, applyingOperation);

         foreach (MedicalViewerBaseCell viewerCell in viewer.Cells)
         {
            viewerCell.SetAction(MedicalViewerActionType.ShrinkTool, (MedicalViewerMouseButtons)_cmbShrinkMouseButton.SelectedIndex, applyingOperation);
         }
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void _cmbApplyTo_SelectedIndexChanged(object sender, EventArgs e)
      {
         ComboBox cmBox = (ComboBox)sender;

         if (cmBox.Name == "_cmbNudgeMouseButton")
         {
            _cmbNudgeApplyingMethod.Enabled = ((_cmbNudgeMouseButton.Text == "Wheel") || (_cmbNudgeApplyTo.SelectedIndex == 0)) ? false : true;
         }
         else if (cmBox.Name == "_cmbShrinkMouseButton")
         {
            _cmbShrinkApplyingMethod.Enabled = ((_cmbShrinkMouseButton.Text == "Wheel") || (_cmbShrinkApplyTo.SelectedIndex == 0)) ? false : true;
         }
      }

      private void _cmbMouseButton_SelectedIndexChanged(object sender, EventArgs e)
      {
         ComboBox cmBox = (ComboBox)sender;

         if (cmBox.Name == "_cmbNudgeMouseButton")
         {
            _cmbNudgeApplyingMethod.Enabled = ((_cmbNudgeMouseButton.Text == "Wheel") || (_cmbNudgeMouseButton.SelectedIndex == 0) || (_cmbNudgeApplyTo.SelectedIndex == 0)) ? false : true;
            _cmbNudgeApplyTo.Enabled = (_cmbNudgeMouseButton.SelectedIndex == 0) ? false : true;

            if (_cmbNudgeMouseButton.Text == _cmbShrinkMouseButton.Text)
            {
               _cmbShrinkMouseButton.SelectedIndex = 0;
            }
         }
         else if (cmBox.Name == "_cmbShrinkMouseButton")
         {
            _cmbShrinkApplyingMethod.Enabled = ((_cmbShrinkMouseButton.Text == "Wheel") || (_cmbShrinkMouseButton.SelectedIndex == 0) || (_cmbShrinkApplyTo.SelectedIndex == 0)) ? false : true;
            _cmbShrinkApplyTo.Enabled = (_cmbShrinkMouseButton.SelectedIndex == 0) ? false : true;

            if (_cmbNudgeMouseButton.Text == _cmbShrinkMouseButton.Text)
            {
               _cmbNudgeMouseButton.SelectedIndex = 0;
            }
         }
      }
   }
}
