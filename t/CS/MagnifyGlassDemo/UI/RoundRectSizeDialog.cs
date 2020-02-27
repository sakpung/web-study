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

namespace MagnifyGlassDemo
{
   /// <summary>
   /// Summary description for RoundRectSizeDialog.
   /// </summary>
   public class RoundRectSizeDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Label _lblWidth;
      private System.Windows.Forms.Label _lblHeight;
      private System.Windows.Forms.NumericUpDown _numHeight;
      private System.Windows.Forms.NumericUpDown _numWidth;
      private System.Windows.Forms.GroupBox _gbOptions;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public RoundRectSizeDialog(int width, int height, int maxWidth, int maxHeight)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         _roundRectEllipseSize = new Size(width, height);
         _maxWidth = maxWidth;
         _maxHeight = maxHeight;
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
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
      private void InitializeComponent()
      {
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._lblHeight = new System.Windows.Forms.Label();
         this._lblWidth = new System.Windows.Forms.Label();
         this._numHeight = new System.Windows.Forms.NumericUpDown();
         this._numWidth = new System.Windows.Forms.NumericUpDown();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(132, 97);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(52, 97);
         this._btnOk.Name = "_btnOk";
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._lblHeight);
         this._gbOptions.Controls.Add(this._lblWidth);
         this._gbOptions.Controls.Add(this._numHeight);
         this._gbOptions.Controls.Add(this._numWidth);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptions.Location = new System.Drawing.Point(8, 8);
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.Size = new System.Drawing.Size(243, 80);
         this._gbOptions.TabIndex = 0;
         this._gbOptions.TabStop = false;
         this._gbOptions.Text = "Size";
         // 
         // _lblHeight
         // 
         this._lblHeight.Location = new System.Drawing.Point(127, 16);
         this._lblHeight.Name = "_lblHeight";
         this._lblHeight.TabIndex = 2;
         this._lblHeight.Text = "Height";
         // 
         // _lblWidth
         // 
         this._lblWidth.Location = new System.Drawing.Point(8, 16);
         this._lblWidth.Name = "_lblWidth";
         this._lblWidth.TabIndex = 0;
         this._lblWidth.Text = "Width";
         // 
         // _numHeight
         // 
         this._numHeight.Location = new System.Drawing.Point(127, 47);
         this._numHeight.Name = "_numHeight";
         this._numHeight.Size = new System.Drawing.Size(104, 20);
         this._numHeight.TabIndex = 3;
         this._numHeight.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numWidth
         // 
         this._numWidth.Location = new System.Drawing.Point(8, 47);
         this._numWidth.Name = "_numWidth";
         this._numWidth.Size = new System.Drawing.Size(104, 20);
         this._numWidth.TabIndex = 1;
         this._numWidth.Leave += new System.EventHandler(this._num_Leave);
         // 
         // RoundRectSizeDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(258, 128);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbOptions);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "RoundRectSizeDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Round Rectangle Ellipse Size";
         this.Load += new System.EventHandler(this.RoundRectSizeDialog_Load);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
         this.ResumeLayout(false);

      }
      #endregion

      private int _maxWidth;
      private int _maxHeight;
      private Size _roundRectEllipseSize;

      private void RoundRectSizeDialog_Load(object sender, System.EventArgs e)
      {
         _lblWidth.Text = string.Format("Width (1..{0})", _maxWidth);
         _lblHeight.Text = string.Format("Height (1..{0})", _maxHeight);
         _numWidth.Minimum = 1;
         _numWidth.Maximum = _maxWidth;
         _numHeight.Minimum = 1;
         _numHeight.Maximum = _maxHeight;

         DialogUtilities.SetNumericValue(_numWidth, _roundRectEllipseSize.Width);
         DialogUtilities.SetNumericValue(_numHeight, _roundRectEllipseSize.Height);
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         _roundRectEllipseSize = new Size((int)_numWidth.Value, (int)_numHeight.Value);
      }

      public Size RoundRectEllipseSize
      {
         get { return _roundRectEllipseSize; }
      }
   }
}
