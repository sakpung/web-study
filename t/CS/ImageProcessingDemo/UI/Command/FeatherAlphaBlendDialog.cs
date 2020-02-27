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
using Leadtools.ImageProcessing.Effects;

#if ! LEADTOOLS_V17_OR_LATER
using LeadPoint = System.Drawing.Point;
using LeadSize = System.Drawing.Size;
using LeadRect = System.Drawing.Rectangle;
#endif // #if !LEADTOOLS_V17_OR_LATER

#if LEADTOOLS_V17_OR_LATER
using Leadtools.Drawing;
#endif // #if LEADTOOLS_V17_OR_LATER

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the FeatherAlphaBlendCommand

   public partial class FeatherAlphaBlendDialog : Form
   {
      private FeatherAlphaBlendCommand _FeatherAlphaBlendCommand;
      private int _RectX, _RectY, _RectWidth, _RectHeight;
      private int _XP1, _YP1, _XP2, _YP2;

      public FeatherAlphaBlendDialog(RasterImage TempSrcImage, RasterImage TempMaskImage)
      {
         InitializeComponent();
         _FeatherAlphaBlendCommand = new FeatherAlphaBlendCommand();

         //Set command default values
         _RectX = 0;
         _RectY = 0;
         _RectWidth = (int)(TempMaskImage.Width );
         _RectHeight = (int)(TempMaskImage.Height );

         _numX.Maximum = TempMaskImage.Width;
         _numY.Maximum = TempMaskImage.Height;
         _numWidth.Maximum = TempMaskImage.Width;
         _numHeight.Maximum = TempMaskImage.Height;


         _XP1 = (int)(TempSrcImage.Width / 2);
         _YP1 = (int)(TempSrcImage.Height / 2);

         _numX1.Maximum = TempMaskImage.Width;
         _numY1.Maximum = TempMaskImage.Height;

         _XP2 = 0;
         _YP2 = 0;

         _numX2.Maximum = TempMaskImage.Width;
         _numY2.Maximum = TempMaskImage.Height;

         InitializeUI();
      }

      public FeatherAlphaBlendCommand FeatherAlphaBlendCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _FeatherAlphaBlendCommand;
         }
         set
         {
            _FeatherAlphaBlendCommand = value;
            InitializeUI();
         }
      }


      private void InitializeUI()
      {
         _numX.Value = _RectX;
         _numY.Value = _RectY;
         _numWidth.Value = _RectWidth;
         _numHeight.Value = _RectHeight;

         _numX1.Value = _XP1;
         _numY1.Value = _YP1;

         _numX2.Value = _XP2;
         _numY2.Value = _YP2;
      }

      private void UpdateCommand()
      {
         _RectX = Convert.ToInt32(_numX.Value);
         _RectY = Convert.ToInt32(_numY.Value);
         _RectWidth = Convert.ToInt32(_numWidth.Value);
         _RectHeight = Convert.ToInt32(_numHeight.Value);

         _XP1 = Convert.ToInt32(_numX1.Value);
         _YP1 = Convert.ToInt32(_numY1.Value);

         _XP2 = Convert.ToInt32(_numX2.Value);
         _YP2 = Convert.ToInt32(_numY2.Value);

         _FeatherAlphaBlendCommand.DestinationRectangle = new LeadRect(
          _RectX, _RectY, _RectWidth, _RectHeight);

         _FeatherAlphaBlendCommand.SourcePoint = new LeadPoint(_XP1, _YP1);

         _FeatherAlphaBlendCommand.MaskSourcePoint = new LeadPoint(_XP2, _YP2);
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }
   }
}
