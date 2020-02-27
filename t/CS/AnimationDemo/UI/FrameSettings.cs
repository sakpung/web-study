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
using Leadtools;

#if ! LEADTOOLS_V17_OR_LATER
using LeadPoint = System.Drawing.Point;
using LeadSize = System.Drawing.Size;
using LeadRect = System.Drawing.Rectangle;
#endif // #if !LEADTOOLS_V17_OR_LATER

namespace AnimationDemo
{
   public partial class FrameSettings : Form
   {
      RasterImage _image;
      public RasterImage Image
      {
         set { _image = value; }
         get { return _image; }
      }

      Point offset = Point.Empty;

      public FrameSettings()
      {
         InitializeComponent();
      }

      public FrameSettings(RasterImage image)
      {
         InitializeComponent();

         _image = image;
         _tbDelay.Text = image.AnimationDelay.ToString();
         _chkWaitForUserInput.Checked = image.AnimationWaitUserInput;
         _tbTop.Text = image.AnimationOffset.Y.ToString();
         _tbLeft.Text = image.AnimationOffset.X.ToString();

         _cmbDisposalMethod.Items.Clear();
         _cmbDisposalMethod.Items.Add("None");
         _cmbDisposalMethod.Items.Add("Leave");
         _cmbDisposalMethod.Items.Add("Restore Background");
         _cmbDisposalMethod.Items.Add("Restore Previous");

         switch (image.AnimationDisposalMethod)
         {
            case RasterImageAnimationDisposalMethod.Leave:
               {
                  _cmbDisposalMethod.SelectedIndex = 1;
                  break;
               }

            case RasterImageAnimationDisposalMethod.RestoreBackground:
               {
                  _cmbDisposalMethod.SelectedIndex = 2;
                  break;
               }

            case RasterImageAnimationDisposalMethod.RestorePrevious:
               {
                  _cmbDisposalMethod.SelectedIndex = 3;
                  break;
               }

            default:
               {
                  _cmbDisposalMethod.SelectedIndex = 0;
                  break;
               }
         }
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         if (_chkApplyToAll.Checked)
         {
            for (int i = 0; i < _image.PageCount; ++i)
            {
               _image.Page = i + 1;

               _image.AnimationDelay = Convert.ToInt32(_tbDelay.Text);
               _image.AnimationWaitUserInput = _chkWaitForUserInput.Checked;
               _image.AnimationOffset = new LeadPoint(Convert.ToInt32(_tbLeft.Text), Convert.ToInt32(_tbTop.Text));

               _image.Transparent = true;
               _image.TransparentColor = Leadtools.Demos.Converters.FromGdiPlusColor(_pnlColor.BackColor);

               string value = _cmbDisposalMethod.SelectedItem.ToString();

               int index = value.IndexOf(" ");
               if(index >= 0)
                  value = value.Remove(index, 1);
               _image.AnimationDisposalMethod = (RasterImageAnimationDisposalMethod)Enum.Parse(typeof(RasterImageAnimationDisposalMethod), value);
            }
         }
         else
         {
            _image.AnimationDelay = Convert.ToInt32(_tbDelay.Text);
            _image.AnimationWaitUserInput = _chkWaitForUserInput.Checked;
            _image.AnimationOffset = new LeadPoint(Convert.ToInt32(_tbLeft.Text), Convert.ToInt32(_tbTop.Text));

            _image.Transparent = _chkTransparentColor.Checked;
            _image.TransparentColor = Leadtools.Demos.Converters.FromGdiPlusColor(_pnlColor.BackColor);
         }

         _image.Page = 1;
      }

      private void _btnChooseColor_Click(object sender, EventArgs e)
      {
         if (_image.BitsPerPixel <= 8)
         {
            ChooseColorDialog colorDialog = new AnimationDemo.ChooseColorDialog(_image, false);

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
               _pnlColor.BackColor = colorDialog.SelectedColor;
            }
         }
         else
         {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
               _pnlColor.BackColor = colorDialog.Color;
            }
         }
      }

      private void _tbDelay_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!e.Handled)
         {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
               e.Handled = true;
         }
      }

      private void _tbLeft_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!e.Handled)
         {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
               e.Handled = true;
         }
      }

      private void _tbTop_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!e.Handled)
         {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
               e.Handled = true;
         }
      }
   }
}
