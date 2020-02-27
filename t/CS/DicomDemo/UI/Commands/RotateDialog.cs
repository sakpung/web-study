// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.Demos;
using Leadtools;
using Leadtools.ImageProcessing;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for RotateDialog.
   /// </summary>
   public class RotateDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Label _lblAngle;
      private System.Windows.Forms.NumericUpDown _numAngle;
      private System.Windows.Forms.Label _lblFillColor;
      private System.Windows.Forms.Panel _pnlFillColor;
      private System.Windows.Forms.Button _btnFillColor;
      private System.Windows.Forms.GroupBox _gbOptionsInterpolation;
      private System.Windows.Forms.CheckBox _cbResize;
      private System.Windows.Forms.RadioButton _rbButtonNormal;
      private System.Windows.Forms.RadioButton _rbButtonResample;
      private System.Windows.Forms.RadioButton _rbButtonBicubic;
      private System.Windows.Forms.Label _lblInterpolation;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public RotateDialog( )
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._lblInterpolation = new System.Windows.Forms.Label();
         this._gbOptionsInterpolation = new System.Windows.Forms.GroupBox();
         this._cbResize = new System.Windows.Forms.CheckBox();
         this._btnFillColor = new System.Windows.Forms.Button();
         this._pnlFillColor = new System.Windows.Forms.Panel();
         this._lblFillColor = new System.Windows.Forms.Label();
         this._numAngle = new System.Windows.Forms.NumericUpDown();
         this._lblAngle = new System.Windows.Forms.Label();
         this._rbButtonBicubic = new System.Windows.Forms.RadioButton();
         this._rbButtonNormal = new System.Windows.Forms.RadioButton();
         this._rbButtonResample = new System.Windows.Forms.RadioButton();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numAngle)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(288, 16);
         this._btnOk.Name = "_btnOk";
         this._btnOk.TabIndex = 12;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(288, 48);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 13;
         this._btnCancel.Text = "Cancel";
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._lblInterpolation);
         this._gbOptions.Controls.Add(this._gbOptionsInterpolation);
         this._gbOptions.Controls.Add(this._cbResize);
         this._gbOptions.Controls.Add(this._btnFillColor);
         this._gbOptions.Controls.Add(this._pnlFillColor);
         this._gbOptions.Controls.Add(this._lblFillColor);
         this._gbOptions.Controls.Add(this._numAngle);
         this._gbOptions.Controls.Add(this._lblAngle);
         this._gbOptions.Controls.Add(this._rbButtonBicubic);
         this._gbOptions.Controls.Add(this._rbButtonNormal);
         this._gbOptions.Controls.Add(this._rbButtonResample);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptions.Location = new System.Drawing.Point(8, 8);
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.Size = new System.Drawing.Size(264, 288);
         this._gbOptions.TabIndex = 0;
         this._gbOptions.TabStop = false;
         // 
         // _lblInterpolation
         // 
         this._lblInterpolation.Location = new System.Drawing.Point(16, 160);
         this._lblInterpolation.Name = "_lblInterpolation";
         this._lblInterpolation.TabIndex = 8;
         this._lblInterpolation.Text = "Interpolation";
         this._lblInterpolation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _gbOptionsInterpolation
         // 
         this._gbOptionsInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptionsInterpolation.Location = new System.Drawing.Point(16, 136);
         this._gbOptionsInterpolation.Name = "_gbOptionsInterpolation";
         this._gbOptionsInterpolation.Size = new System.Drawing.Size(232, 8);
         this._gbOptionsInterpolation.TabIndex = 7;
         this._gbOptionsInterpolation.TabStop = false;
         // 
         // _cbResize
         // 
         this._cbResize.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._cbResize.Location = new System.Drawing.Point(16, 104);
         this._cbResize.Name = "_cbResize";
         this._cbResize.TabIndex = 6;
         this._cbResize.Text = "Resize";
         // 
         // _btnFillColor
         // 
         this._btnFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnFillColor.Location = new System.Drawing.Point(224, 56);
         this._btnFillColor.Name = "_btnFillColor";
         this._btnFillColor.Size = new System.Drawing.Size(24, 23);
         this._btnFillColor.TabIndex = 5;
         this._btnFillColor.Text = "...";
         this._btnFillColor.Click += new System.EventHandler(this._btnFillColor_Click);
         // 
         // _pnlFillColor
         // 
         this._pnlFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._pnlFillColor.Location = new System.Drawing.Point(128, 56);
         this._pnlFillColor.Name = "_pnlFillColor";
         this._pnlFillColor.Size = new System.Drawing.Size(96, 24);
         this._pnlFillColor.TabIndex = 4;
         this._pnlFillColor.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlFillColor_Paint);
         // 
         // _lblFillColor
         // 
         this._lblFillColor.Location = new System.Drawing.Point(16, 56);
         this._lblFillColor.Name = "_lblFillColor";
         this._lblFillColor.TabIndex = 3;
         this._lblFillColor.Text = "Fill Color";
         this._lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _numAngle
         // 
         this._numAngle.Location = new System.Drawing.Point(128, 24);
         this._numAngle.Maximum = new System.Decimal(new int[] {
                                                                  360,
                                                                  0,
                                                                  0,
                                                                  0});
         this._numAngle.Minimum = new System.Decimal(new int[] {
                                                                  360,
                                                                  0,
                                                                  0,
                                                                  -2147483648});
         this._numAngle.Name = "_numAngle";
         this._numAngle.TabIndex = 2;
         this._numAngle.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblAngle
         // 
         this._lblAngle.Location = new System.Drawing.Point(16, 24);
         this._lblAngle.Name = "_lblAngle";
         this._lblAngle.TabIndex = 1;
         this._lblAngle.Text = "Angle";
         this._lblAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _rbButtonBicubic
         // 
         this._rbButtonBicubic.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonBicubic.Location = new System.Drawing.Point(16, 256);
         this._rbButtonBicubic.Name = "_rbButtonBicubic";
         this._rbButtonBicubic.Size = new System.Drawing.Size(128, 24);
         this._rbButtonBicubic.TabIndex = 11;
         this._rbButtonBicubic.Text = "BiCubic";
         // 
         // _rbButtonNormal
         // 
         this._rbButtonNormal.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonNormal.Location = new System.Drawing.Point(16, 192);
         this._rbButtonNormal.Name = "_rbButtonNormal";
         this._rbButtonNormal.Size = new System.Drawing.Size(128, 24);
         this._rbButtonNormal.TabIndex = 9;
         this._rbButtonNormal.Text = "Normal";
         // 
         // _rbButtonResample
         // 
         this._rbButtonResample.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonResample.Location = new System.Drawing.Point(16, 224);
         this._rbButtonResample.Name = "_rbButtonResample";
         this._rbButtonResample.Size = new System.Drawing.Size(128, 24);
         this._rbButtonResample.TabIndex = 10;
         this._rbButtonResample.Text = "Resample (Bilinear)";
         // 
         // RotateDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(368, 303);
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "RotateDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Rotate";
         this.Load += new System.EventHandler(this.RotateDialog_Load);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numAngle)).EndInit();
         this.ResumeLayout(false);

      }
      #endregion

      private static int _initialAngle = 0;
      private static RotateCommandFlags _initialFlags = RotateCommandFlags.None;
      private static RasterColor _initialFillColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White);

      public int Angle;
      public RotateCommandFlags Flags;
      public RasterColor FillColor;

      private void RotateDialog_Load(object sender, System.EventArgs e)
      {
         Angle = _initialAngle / 100;
         Flags = _initialFlags;
         FillColor = _initialFillColor;

         _numAngle.Value = Angle;
         _cbResize.Checked = (Flags & RotateCommandFlags.Resize) == RotateCommandFlags.Resize;

         if((Flags & RotateCommandFlags.Resample) == RotateCommandFlags.Resample)
            _rbButtonResample.Checked = true;
         else if((Flags & RotateCommandFlags.Bicubic) == RotateCommandFlags.Bicubic)
            _rbButtonBicubic.Checked = true;
         else
            _rbButtonNormal.Checked = true;
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _pnlFillColor_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         e.Graphics.FillRectangle(new SolidBrush(Leadtools.Demos.Converters.ToGdiPlusColor(FillColor)), _pnlFillColor.ClientRectangle);
      }

      private void _btnFillColor_Click(object sender, System.EventArgs e)
      {
         if(Tools.ShowColorDialog(this, ref FillColor))
            _pnlFillColor.Refresh();
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Angle = (int)_numAngle.Value * 100;

         Flags = RotateCommandFlags.None;

         if(_cbResize.Checked)
            Flags |= RotateCommandFlags.Resize;

         if(_rbButtonResample.Checked)
            Flags |= RotateCommandFlags.Resample;

         if(_rbButtonBicubic.Checked)
            Flags |= RotateCommandFlags.Bicubic;

         _initialAngle = Angle;
         _initialFlags = Flags;
         _initialFillColor = FillColor;
      }
   }
}
