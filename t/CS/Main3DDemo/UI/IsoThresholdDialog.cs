// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

using Leadtools.Medical3D;
using Leadtools.MedicalViewer;

namespace Main3DDemo
{
    public partial class IsoThresholdDialog : Form
   {
      private MedicalViewer _viewer;
      private Medical3DContainer _container;
      private int _oldThresholdValue;
      private Medical3DControl _control3D;
      private int minimum;
      private int maximum;

      public IsoThresholdDialog()
      {
         InitializeComponent();
      }

      public IsoThresholdDialog(Medical3DControl control3D, MedicalViewer control, Medical3DContainer container)
      {
         InitializeComponent();

         _viewer = control;
         _control3D = control3D;

         _container = container;
         _oldThresholdValue = container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].SSD.Threshold;

         minimum = container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].MinimumValue;
         maximum = container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].MaximumValue;

         _textBoxThreshold.MinimumAllowed = minimum;
         _textBoxThreshold.MaximumAllowed = maximum;

         _trackThreshold.Maximum = maximum - minimum;

         _trackThreshold.Value = Math.Min(maximum - minimum, Math.Max(minimum, _oldThresholdValue));
         _control3D.Invalidate();
         _control3D.Update();
      }

      private void _btnReset_Click(object sender, EventArgs e)
      {
         _container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].SSD.Threshold = _oldThresholdValue;
         _trackThreshold.Value = Math.Min(maximum - minimum, Math.Max(minimum, _oldThresholdValue));
         _control3D.Invalidate();
         _control3D.Update();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         _container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].SSD.Threshold = _oldThresholdValue;
         _control3D.Invalidate();
         _control3D.Update();
      }

      private void _trackBarOpacity_Scroll(object sender, EventArgs e)
      {
         if (_trackThreshold.Value != (_textBoxThreshold.Value - minimum))
            _textBoxThreshold.Value = (_trackThreshold.Value + minimum);
         _control3D.Invalidate();
         _control3D.Update();
      }

      private void _textBoxOpacity_TextChanged(object sender, EventArgs e)
      {
         if (_textBoxThreshold.Value > minimum)
         {
            if (_trackThreshold.Value != (_textBoxThreshold.Value - minimum))
               _trackThreshold.Value = _textBoxThreshold.Value - minimum;
            _control3D.Invalidate();
            _control3D.Update();
         }
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         if (_container.Objects[0].SSD.Threshold != _textBoxThreshold.Value)
            _container.Objects[0].SSD.Threshold = _textBoxThreshold.Value;
         _control3D.Invalidate();
         _control3D.Update();
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         _btnOK_Click(sender, e);
      }

      private void groupBox1_Enter(object sender, EventArgs e)
      {

      }
   }
}
