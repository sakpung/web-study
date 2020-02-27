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
   public partial class AnimationDialog : Form
   {     
      MedicalViewerCell _cell;

      public AnimationDialog(MedicalViewerCell cell)
      {
         InitializeComponent();        
         _cell = cell;

         this.Size = new Size(this.Size.Width, 213);
         _grpExtendedParameters.Visible = false;
         _txtFrom.Value = _cell.Animation.StartFrame + 1;
         bool toEnd = _cell.Animation.FrameCount == -1;
         _txtTo.Value = (_cell.Animation.FrameCount == -1) ? _cell.Image.PageCount : _cell.Animation.FrameCount + 1;
         _chkToEnd.Checked = toEnd;
         _tbSpeed.Value = (301 - _cell.Animation.Interval);
         _chkShowAnnotation.Checked = (_cell.Animation.Flags & MedicalViewerAnimationFlags.ShowAnnotations) == MedicalViewerAnimationFlags.ShowAnnotations;
         _chkShowRegion.Checked = (_cell.Animation.Flags & MedicalViewerAnimationFlags.ShowRegions) == MedicalViewerAnimationFlags.ShowRegions;
         _cmbInterpolation.SelectedIndex = (int)(_cell.Animation.Flags & (MedicalViewerAnimationFlags.PaintNormal | MedicalViewerAnimationFlags.PaintResample | MedicalViewerAnimationFlags.PaintBicubic));
         _radLoop.Checked = (_cell.Animation.Flags & (MedicalViewerAnimationFlags.Sequence | MedicalViewerAnimationFlags.Loop)) == MedicalViewerAnimationFlags.Sequence;
         _radShuffle.Checked = !_radLoop.Checked;
         _chkAnimateAllSubCells.Checked = _cell.Animation.AnimateAllSubCells;

         if (_cell.Animation.Animated)
         {
             if ((int)(_cell.Animation.Flags & MedicalViewerAnimationFlags.PlayBackward) != 0)
                 _chkBackward.Checked = true;
             else
                 _chkForward.Checked = true;
         }
         else
             _chkStop.Checked = true;



         switch (_cell.Animation.Frames)
         {
             case -1:
             case 0:
             case 1:
                 _cmbFrames.SelectedIndex = _cell.Animation.Frames + 1;
                 break;
             default:
                 _cmbFrames.SelectedIndex = 3;
                 _txtFrames.Value = _cell.Animation.Frames;
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
         if (!_chkBackward.Checked)
         {
            _chkStop.Checked = false;
            _chkForward.Checked = false;
            _chkBackward.Checked = true;

            _cell.Animation.Flags &= ~(MedicalViewerAnimationFlags.PlayForward | MedicalViewerAnimationFlags.PlayBackward);
            _cell.Animation.Flags |= MedicalViewerAnimationFlags.PlayBackward;
            _cell.Animation.Animated = _chkBackward.Checked;
         }
      }

      void _chkForward_Click(object sender, System.EventArgs e)
      {
         if (!_chkForward.Checked)
         {
            _chkStop.Checked = false;
            _chkBackward.Checked = false;
            _chkForward.Checked = true;

            _cell.Animation.Flags &= ~(MedicalViewerAnimationFlags.PlayForward | MedicalViewerAnimationFlags.PlayBackward);
            _cell.Animation.Flags |= MedicalViewerAnimationFlags.PlayForward;
            _cell.Animation.Animated = _chkForward.Checked;
         }
      }

      void _chkStop_Click(object sender, System.EventArgs e)
      {
         if (_chkForward.Checked | _chkBackward.Checked)
         {
            _chkForward.Checked = false;
            _chkBackward.Checked = false;

            _cell.Animation.Animated = false;
         }
      }

      private void _radShuffle_CheckedChanged(object sender, EventArgs e)
      {
         _cell.Animation.Flags &= ~(MedicalViewerAnimationFlags.Loop | MedicalViewerAnimationFlags.Sequence);
         _cell.Animation.Flags |= (_radShuffle.Checked ? MedicalViewerAnimationFlags.Loop : MedicalViewerAnimationFlags.Sequence);
      }

      private void _cmbInterpolation_SelectedIndexChanged(object sender, EventArgs e)
      {
         _cell.Animation.Flags &= ~(MedicalViewerAnimationFlags.PaintBicubic | MedicalViewerAnimationFlags.PaintNormal | MedicalViewerAnimationFlags.PaintResample);

         switch (_cmbInterpolation.SelectedIndex)
         {
             case 0:
                 _cell.Animation.Flags |= MedicalViewerAnimationFlags.PaintNormal;
                 break;
             case 1:
                 _cell.Animation.Flags |= MedicalViewerAnimationFlags.PaintResample;
                 break;
             case 2:
                 _cell.Animation.Flags |= MedicalViewerAnimationFlags.PaintBicubic;
                 break;
         }
      }

      private void _chkAnimateAllSubCells_CheckedChanged(object sender, EventArgs e)
      {
         _cell.Animation.AnimateAllSubCells = _chkAnimateAllSubCells.Checked;
      }

      private void _chkShowRegion_CheckedChanged(object sender, EventArgs e)
      {
         _cell.Animation.Flags &= ~(MedicalViewerAnimationFlags.ShowRegions);
         if (_chkShowRegion.Checked)
             _cell.Animation.Flags |= MedicalViewerAnimationFlags.ShowRegions;
      }

      private void _chkShowAnnotation_CheckedChanged(object sender, EventArgs e)
      {
         _cell.Animation.Flags &= ~(MedicalViewerAnimationFlags.ShowAnnotations);
         if (_chkShowAnnotation.Checked)
             _cell.Animation.Flags |= MedicalViewerAnimationFlags.ShowAnnotations;
      }

      private void _cmbFrames_SelectedIndexChanged(object sender, EventArgs e)
      {
          switch (_cmbFrames.SelectedIndex)
          {
              case 0:
                  _cell.Animation.Frames = -1;
                  _txtFrames.Enabled = false;
                  break;
              case 1:
                  _cell.Animation.Frames = 0;
                  _txtFrames.Enabled = false;
                  break;
              case 2:
                  _cell.Animation.Frames = 1;
                  _txtFrames.Enabled = false;
                  break;
              case 3:
                  _cell.Animation.Frames = _txtFrames.Value;
                  _txtFrames.Enabled = true;
                  break;
          }
      }

      private void _txtFrames_TextChanged(object sender, EventArgs e)
      {
          if (_txtFrames.Value == 1)
              _cell.Animation.Frames = -1;
          else
              _cell.Animation.Frames = _txtFrames.Value;
      }

      private void _txtFrom_TextChanged(object sender, EventArgs e)
      {
         _cell.Animation.StartFrame = _txtFrom.Value - 1;
      }

      private void _txtTo_TextChanged(object sender, EventArgs e)
      {
         _cell.Animation.FrameCount = _txtTo.Value - 1;
      }

      private void _chkToEnd_CheckedChanged(object sender, EventArgs e)
      {
         _txtTo.Enabled = !_chkToEnd.Checked;
         _cell.Animation.FrameCount = _chkToEnd.Checked ? -1 : _txtTo.Value;
      }

      private void _tbSpeed_Scroll(object sender, EventArgs e)
      {
         _cell.Animation.Interval = (301 - _tbSpeed.Value);
      }

      private void _btnHidden_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
