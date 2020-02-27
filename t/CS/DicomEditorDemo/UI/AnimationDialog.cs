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

namespace DicomEditorDemo
{
   public partial class AnimationDialog : Form
   {
      MedicalViewer _viewer;

      public AnimationDialog(MedicalViewer viewer)
      {
         InitializeComponent();
         _viewer = viewer;        
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];

         this.Size = new Size(this.Size.Width, 213);
         _grpExtendedParameters.Visible = false;
         _txtFrom.Value = (cell.Animation.StartFrame + 1);
         bool toEnd = cell.Animation.FrameCount == -1;
         _txtTo.Value = (cell.Animation.FrameCount == -1) ? cell.Image.PageCount : cell.Animation.FrameCount + 1;
         _chkToEnd.Checked = toEnd;
         _tbSpeed.Value = (301 - cell.Animation.Interval);
         _chkShowAnnotation.Checked = (cell.Animation.Flags & MedicalViewerAnimationFlags.ShowAnnotations) == MedicalViewerAnimationFlags.ShowAnnotations;
         _chkShowRegion.Checked = (cell.Animation.Flags & MedicalViewerAnimationFlags.ShowRegions) == MedicalViewerAnimationFlags.ShowRegions;
         _cmbInterpolation.SelectedIndex = (int)(cell.Animation.Flags & (MedicalViewerAnimationFlags.PaintNormal | MedicalViewerAnimationFlags.PaintResample | MedicalViewerAnimationFlags.PaintBicubic));
         _radLoop.Checked = (cell.Animation.Flags & (MedicalViewerAnimationFlags.Sequence | MedicalViewerAnimationFlags.Loop)) == MedicalViewerAnimationFlags.Sequence;
         _radShuffle.Checked = !_radLoop.Checked;
         _chkAnimateAllSubCells.Checked = cell.Animation.AnimateAllSubCells;
         if ((cell.Animation.Flags & MedicalViewerAnimationFlags.PlayOnSelection) == MedicalViewerAnimationFlags.PlayOnSelection)
            cell.Animation.Flags ^= MedicalViewerAnimationFlags.PlayOnSelection;



         if (cell.Animation.Animated)
         {
            if ((int)(cell.Animation.Flags & MedicalViewerAnimationFlags.PlayBackward) != 0)
               _chkBackward.Checked = true;
            else
               _chkForward.Checked = true;
         }
         else
            _chkStop.Checked = true;



         switch (cell.Animation.Frames)
         {
            case -1:
            case 0:
            case 1:
               _cmbFrames.SelectedIndex = cell.Animation.Frames + 1;
               break;
            default:
               _cmbFrames.SelectedIndex = 3;
               _txtFrames.Value = cell.Animation.Frames;
               break;
         }
      }

      private void _btnAdvance_Click(object sender, EventArgs e)
      {
         if (_btnAdvance.Text == "Ad&vance >>")
         {
            _btnAdvance.Text = "&Basic <<";
            this.Size = new Size(this.Size.Width, 438);
            _grpExtendedParameters.Visible = true;
         }
         else if (_btnAdvance.Text == "&Basic <<")
         {
            _btnAdvance.Text = "Ad&vance >>";
            this.Size = new Size(this.Size.Width, 213);
            _grpExtendedParameters.Visible = false;
         }
      }

      private void _chkBackward_Click(object sender, System.EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         if (!_chkBackward.Checked)
         {
            _chkStop.Checked = false;
            _chkForward.Checked = false;
            _chkBackward.Checked = true;

            cell.Animation.Flags &= ~(MedicalViewerAnimationFlags.PlayForward | MedicalViewerAnimationFlags.PlayBackward);
            cell.Animation.Flags |= MedicalViewerAnimationFlags.PlayBackward;
            cell.Animation.Animated = _chkBackward.Checked;
         }
      }

      void _chkForward_Click(object sender, System.EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         if (!_chkForward.Checked)
         {
            _chkStop.Checked = false;
            _chkBackward.Checked = false;
            _chkForward.Checked = true;

            cell.Animation.Flags &= ~(MedicalViewerAnimationFlags.PlayForward | MedicalViewerAnimationFlags.PlayBackward);
            cell.Animation.Flags |= MedicalViewerAnimationFlags.PlayForward;
            cell.Animation.Animated = _chkForward.Checked;
         }
      }

      void _chkStop_Click(object sender, System.EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         if (_chkForward.Checked | _chkBackward.Checked)
         {
            _chkForward.Checked = false;
            _chkBackward.Checked = false;

            cell.Animation.Animated = false;
         }
      }

      private void _radShuffle_CheckedChanged(object sender, EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         cell.Animation.Flags &= ~(MedicalViewerAnimationFlags.Loop | MedicalViewerAnimationFlags.Sequence);
         cell.Animation.Flags |= (_radShuffle.Checked ? MedicalViewerAnimationFlags.Loop : MedicalViewerAnimationFlags.Sequence);
      }

      private void _cmbInterpolation_SelectedIndexChanged(object sender, EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         cell.Animation.Flags &= ~(MedicalViewerAnimationFlags.PaintBicubic | MedicalViewerAnimationFlags.PaintNormal | MedicalViewerAnimationFlags.PaintResample);

         switch (_cmbInterpolation.SelectedIndex)
         {
            case 0:
               cell.Animation.Flags |= MedicalViewerAnimationFlags.PaintNormal;
               break;
            case 1:
               cell.Animation.Flags |= MedicalViewerAnimationFlags.PaintResample;
               break;
            case 2:
               cell.Animation.Flags |= MedicalViewerAnimationFlags.PaintBicubic;
               break;
         }
      }

      private void _chkAnimateAllSubCells_CheckedChanged(object sender, EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         cell.Animation.AnimateAllSubCells = _chkAnimateAllSubCells.Checked;
      }

      private void _chkShowRegion_CheckedChanged(object sender, EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         cell.Animation.Flags &= ~(MedicalViewerAnimationFlags.ShowRegions);
         if (_chkShowRegion.Checked)
            cell.Animation.Flags |= MedicalViewerAnimationFlags.ShowRegions;
      }

      private void _chkShowAnnotation_CheckedChanged(object sender, EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         cell.Animation.Flags &= ~(MedicalViewerAnimationFlags.ShowAnnotations);
         if (_chkShowAnnotation.Checked)
            cell.Animation.Flags |= MedicalViewerAnimationFlags.ShowAnnotations;
      }

      private void _cmbFrames_SelectedIndexChanged(object sender, EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         switch (_cmbFrames.SelectedIndex)
         {
            case 0:
               cell.Animation.Frames = -1;
               _txtFrames.Enabled = false;
               break;
            case 1:
               cell.Animation.Frames = 0;
               _txtFrames.Enabled = false;
               break;
            case 2:
               cell.Animation.Frames = 1;
               _txtFrames.Enabled = false;
               break;
            case 3:
               cell.Animation.Frames = _txtFrames.Value;
               _txtFrames.Enabled = true;
               break;
         }
      }

      private void _txtFrames_TextChanged(object sender, EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         if (_txtFrames.Value == 1)
            cell.Animation.Frames = -1;
         else
            cell.Animation.Frames = _txtFrames.Value;
      }

      private void _txtFrom_TextChanged(object sender, EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         cell.Animation.StartFrame = _txtFrom.Value - 1;
      }

      private void _txtTo_TextChanged(object sender, EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         cell.Animation.FrameCount = _txtTo.Value - 1;
      }

      private void _chkToEnd_CheckedChanged(object sender, EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         _txtTo.Enabled = !_chkToEnd.Checked;
         cell.Animation.FrameCount = _chkToEnd.Checked ? -1 : _txtTo.Value;
      }

      private void _tbSpeed_Scroll(object sender, EventArgs e)
      {
         MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[0];
         cell.Animation.Interval = (301 - _tbSpeed.Value);
      }

      private void _btnHidden_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }

   public partial class NumericTextBox : System.Windows.Forms.TextBox
   {
       private int _maximumAllowed;
       private int _minimumAllowed;
       private string _oldText;

       public NumericTextBox()
       {
           _maximumAllowed = 1000;
           _minimumAllowed = -1000;
           _oldText = "";
       }

       [Description("The minimum allowed value to be entered"),
       Category("Allowed Values")]
       public int MinimumAllowed
       {
           set
           {
               _minimumAllowed = value;
           }
           get
           {
               return _minimumAllowed;
           }
       }

       [Description("The maximum allowed value to be entered"),
       Category("Allowed Values")]
       public int MaximumAllowed
       {
           set
           {
               _maximumAllowed = value;
           }
           get
           {
               return _maximumAllowed;
           }
       }

       [Description("The maximum allowed value to be entered"),
       Category("Current Value")]
       public int Value
       {
           set
           {
               this.Text = value.ToString();
           }
           get
           {
               if (this.Text.Trim() == "")
                   return _minimumAllowed;
               else
                   return Convert.ToInt32(this.Text);
           }
       }

       // Is the entered number within the specified valid range
       private bool IsAllowed(string text)
       {
           bool isAllowed = true;

           try
           {
               int newNumber = Convert.ToInt32(text);
               if ((newNumber > _maximumAllowed) || (newNumber < _minimumAllowed))
                   isAllowed = false;
           }
           catch
           {
               // This happen if the entered value is not a numeric.
               isAllowed = false;
           }

           return isAllowed;
       }

       protected override void OnTextChanged(EventArgs e)
       {
           if (!IsAllowed(this.Text))
           {
               if (_minimumAllowed <= 1)
                   this.Text = _oldText;
           }
           else
               _oldText = this.Text;

           base.OnTextChanged(e);
       }

       protected override void OnKeyDown(KeyEventArgs e)
       {
           // Increase or decrease the current value by 1 if the user presses the UP or DOWN
           // and test if the new value is allowed
           if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
           {
               int value = Convert.ToInt32(this.Text);

               value = (e.KeyCode == Keys.Up) ? value + 1 : value - 1;

               if (IsAllowed(value.ToString()))
                   this.Text = value.ToString();
           }

           base.OnKeyDown(e);
       }

       protected override void OnLostFocus(EventArgs e)
       {
           int value = Convert.ToInt32(this.Text);
           if (value < _minimumAllowed)
               this.Text = _minimumAllowed.ToString();

           base.OnLostFocus(e);
       }

       protected override void OnKeyPress(KeyPressEventArgs e)
       {
           // if Enter, Escape, Ctrl or Alt key is pressed, then there is no need to check
           // since the user is not entering a new character...
           if (((Control.ModifierKeys & Keys.Control) == 0) &&
               ((Control.ModifierKeys & Keys.Alt) == 0) &&
                (e.KeyChar != Convert.ToChar(Keys.Enter)) &&
                (e.KeyChar != Convert.ToChar(Keys.Escape)))
           {
               #region Check if the entered character is valid for Numeric format
               // Validate the entered character
               if (!Char.IsNumber(e.KeyChar))
               {

                   #region Check If the user has entered Minus character
                   // Here we check if the user wants to enter the "-" character.
                   if (!((this.Text.IndexOf('-') == -1) && // there is no Minus character
                         (this.SelectionStart == 0) && // the cursor at the begining
                         (_minimumAllowed < 0) && // the minimum allowed accept negative values
                         (e.KeyChar == '-')))  // the character entered was a Minus character
                       e.KeyChar = Char.MinValue;
                   #endregion
               }
               #endregion

               if (_minimumAllowed <= 1)
                   #region Checkinng if the value falles within the given range
                   if (e.KeyChar != Char.MinValue)
                   {
                       // Create the string that will be displayed, and check whether it's valid or not.

                       // Remove the selected character(s).
                       string newString = this.Text.Remove(this.SelectionStart, this.SelectionLength);
                       // Insert the new character.
                       newString = newString.Insert(this.SelectionStart, e.KeyChar.ToString());
                       if (!IsAllowed(newString))
                           // the new string is not valid, cancel the whole operation.
                           e.KeyChar = Char.MinValue;
                   }
                   #endregion
           }
           base.OnKeyPress(e);
       }
   }
}
