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

using Leadtools.Medical3D;
using Leadtools.MedicalViewer;
using Leadtools.Demos;

namespace Main3DDemo
{
    public partial class ThresholdDialog : Form
    {
       private float oldFromValue;
       private float oldToValue;
       private bool oldEnabled;

       private Medical3DRemoveIntervalType removeIntervalType;
       private Medical3DContainer container;
       private Medical3DVolumeType type;
       private int minimum;
       private int maximum;
       private bool dontApply;
       Medical3DControl _control3D;

        void EnableControls(bool enable)
        {
            _trackBarLower.Enabled = enable;
            _trackBarUpper.Enabled = enable;
            _textBoxLower.Enabled = enable;
            _textBoxUpper.Enabled = enable;
            _removeInnerRangeChkBox.Enabled = enable;
        }

       public ThresholdDialog(Medical3DControl control3D, Medical3DContainer Medical3DContainer, Medical3DVolumeType Medical3DVolumeType)
        {
          InitializeComponent();

          container = Medical3DContainer;
          type = Medical3DVolumeType;

          _control3D = control3D;

            oldFromValue = container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].LowerThreshold;
            oldToValue = container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].UpperThreshold;
            removeIntervalType = container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].RemoveInterval;
            oldEnabled = container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].EnableThresholding;
            _chkBoxenableThreshold.Checked = container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].EnableThresholding;
            _removeInnerRangeChkBox.Checked = container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].RemoveInterval == Medical3DRemoveIntervalType.InnerRange;

            minimum = container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].MinimumValue;
            maximum = container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].MaximumValue;

            dontApply = true;
            _trackBarLower.Maximum = maximum;
            _textBoxLower.MinimumAllowed = 0;
            _textBoxLower.MaximumAllowed = maximum;
            _textBoxLower.Value = (int)oldFromValue;

            _trackBarUpper.Maximum = maximum;
            _textBoxUpper.MinimumAllowed = 0;
            _textBoxUpper.MaximumAllowed = maximum;
            dontApply = false;
            _textBoxUpper.Value = (int)oldToValue;

            EnableControls(_chkBoxenableThreshold.Checked);
            _control3D.Invalidate();
        }

        private void _btnReset_Click(object sender, EventArgs e)
        {
            container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].LowerThreshold = minimum;
           container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].UpperThreshold = maximum;
           container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].EnableThresholding = false;
           container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].RemoveInterval = Medical3DRemoveIntervalType.OuterRange;

            _textBoxLower.Value = (int)minimum;
            _textBoxUpper.Value = (int)maximum;
            _removeInnerRangeChkBox.Checked = false;
            _chkBoxenableThreshold.Checked = false;
            EnableControls(false);
            _control3D.Invalidate();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
           container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].LowerThreshold = oldFromValue;
           container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].UpperThreshold = oldToValue;
           container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].EnableThresholding = oldEnabled;
           container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].RemoveInterval = removeIntervalType;
           _control3D.Invalidate();
        }

       void SetLowerThreshold(int value)
       {
           container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].LowerThreshold = value;
           _control3D.Invalidate();
       }

       void SetUpperThreshold(int value)
       {
           container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].UpperThreshold = value;
           _control3D.Invalidate();
       }


         void SetThreshold()
         {
            if (dontApply)
               return;


            if (_textBoxLower.Value > _textBoxUpper.Value)
            {
               SetLowerThreshold(_trackBarUpper.Value);
               SetUpperThreshold(_trackBarLower.Value);
               _toLbl.Text = DemosGlobalization.GetResxString(GetType(), "Resx_From");
               _fromLbl.Text = DemosGlobalization.GetResxString(GetType(), "Resx_To");;
            }
            else
            {
               SetLowerThreshold(_trackBarLower.Value);
               SetUpperThreshold(_trackBarUpper.Value);
               _toLbl.Text = DemosGlobalization.GetResxString(GetType(), "Resx_To"); ;
               _fromLbl.Text = DemosGlobalization.GetResxString(GetType(), "Resx_From"); ;
            }

         }

        private void _trackBarLower_ValueChanged(object sender, EventArgs e)
        {
           if ((_textBoxLower.Value) != _trackBarLower.Value)
              _textBoxLower.Value = _trackBarLower.Value;

           SetThreshold();
           _control3D.Invalidate();
        }

        private void _trackBarUpper_ValueChanged(object sender, EventArgs e)
        {
           if ((_textBoxUpper.Value) != _trackBarUpper.Value)
              _textBoxUpper.Value = _trackBarUpper.Value;

           SetThreshold();
           _control3D.Invalidate();
        }

        private void _textBoxLower_TextChanged(object sender, EventArgs e)
        {
           _trackBarLower.Value = _textBoxLower.Value;
           _control3D.Invalidate();
        }

        private void _textBoxUpper_TextChanged(object sender, EventArgs e)
        {
           _trackBarUpper.Value = _textBoxUpper.Value;
           _control3D.Invalidate();
        }

        private void _chkBoxenableThreshold_CheckedChanged(object sender, EventArgs e)
        {
           container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].EnableThresholding = _chkBoxenableThreshold.Checked;
            EnableControls(_chkBoxenableThreshold.Checked);
            _control3D.Invalidate();
        }

        private void _removeInnerRangeChkBox_CheckedChanged(object sender, EventArgs e)
        {
           Medical3DRemoveIntervalType intervalType = _removeInnerRangeChkBox.Checked ? Medical3DRemoveIntervalType.InnerRange : Medical3DRemoveIntervalType.OuterRange;
           container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].RemoveInterval = intervalType;
           _control3D.Invalidate();
        }
    }
}
