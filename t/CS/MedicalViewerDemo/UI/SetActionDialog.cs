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
   public partial class SetActionDialog : Form
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

      private MedicalViewerActionType _actionType;
      private bool _annotationAction = false;

      public SetActionDialog(MainForm owner, MedicalViewerActionType actionType, bool annotationAction)
      {
         Initialize(owner, actionType);
         _annotationAction = annotationAction;
      }

      public SetActionDialog(MainForm owner, MedicalViewerActionType actionType)
      {
         Initialize(owner, actionType);
      }

      public void Initialize(MainForm owner, MedicalViewerActionType actionType)
      {
         InitializeComponent();

         cell = MainForm.DefaultCell;
         viewer = owner.Viewer;
         _owner = owner;


         _owner.CobbAngleStarted = false;


         _actionType = actionType;
         this.Text = "Set " + GetSeparatedText(actionType.ToString()) + " Action";

         if (cell.IsValidForAction(actionType, MedicalViewerMouseButtons.Wheel))
            _cmbMouseButton.Items.Insert(4, "Wheel");

         if (cell.IsValidForAction(actionType, MedicalViewerActionFlags.Selected))
         {
            _cmbApplyTo.Items.Add("Selected Cells");
            _cmbApplyTo.Items.Add("All Cells");
         }

         if (cell.IsValidForAction(actionType, MedicalViewerActionFlags.Selected))
            _cmbApplyingMethod.Items.Add("On Release");

         MedicalViewerActionFlags actionFlags = cell.GetActionFlags(actionType);


         if ((actionFlags | MedicalViewerActionFlags.OnRelease) == actionFlags)
            _cmbApplyingMethod.SelectedIndex = 1;
         else
            _cmbApplyingMethod.SelectedIndex = 0;

         if ((actionFlags & MedicalViewerActionFlags.Selected) == MedicalViewerActionFlags.Selected)
            _cmbApplyTo.SelectedIndex = 1;
         else if ((actionFlags & MedicalViewerActionFlags.AllCells) == MedicalViewerActionFlags.AllCells)
            _cmbApplyTo.SelectedIndex = 2;
         else
            _cmbApplyTo.SelectedIndex = 0;

         _cmbMouseButton.SelectedIndex = (int)cell.GetActionButton(actionType);
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

         if ((MedicalViewerMouseButtons)_cmbMouseButton.SelectedIndex == MedicalViewerMouseButtons.Left)
         {
             _owner.CurrentAction = _actionType;
             _owner.LeftButtonAction = _actionType;
             _owner.CheckMoveMarkersAction(false);
             _owner.CheckSelectPoints(false);
         }
         if ((MedicalViewerMouseButtons)_cmbMouseButton.SelectedIndex == MedicalViewerMouseButtons.Right)
         {
             _owner.RightButtonAction = _actionType;
         }

         cell.SetAction(_actionType, (MedicalViewerMouseButtons)_cmbMouseButton.SelectedIndex, applyingOperation);

         foreach (MedicalViewerBaseCell viewerCell in viewer.Cells)
         {
            viewerCell.SetAction(_actionType, (MedicalViewerMouseButtons)_cmbMouseButton.SelectedIndex, applyingOperation);
         }


         if ((MedicalViewerMouseButtons)_cmbMouseButton.SelectedIndex == MedicalViewerMouseButtons.Left)
         {
            if (_annotationAction)
               PushAnnotationIcon(_actionType);
            else
               UnpushAllAnnotationIcons();
         }
      }


      private void PushAnnotationIcon(MedicalViewerActionType actionType)
      {
         UnpushAllAnnotationIcons();

         MedicalViewerActionType buttonAction;

         foreach (ToolBarButton button in _owner.ManagerHelper.ToolBar.Buttons)
         {
            buttonAction = _owner.GetAnnotationActionId((int)button.Tag);
            if (buttonAction == actionType)
            {
               button.Pushed = true;
               _owner.CurrentToolBarButton = button;
               return;
            }
         }
      }


      private void UnpushAllAnnotationIcons()
      {
         foreach (ToolBarButton button in _owner.ManagerHelper.ToolBar.Buttons)
         {
            button.Pushed = false;
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
