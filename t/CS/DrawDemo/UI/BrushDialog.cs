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

namespace DrawDemo
{
   /// <summary>
   /// Summary description for BrushDialog.
   /// </summary>
   public class BrushDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.CheckBox _cbUse;
      private System.Windows.Forms.Button _btnColor;
      private System.Windows.Forms.Panel _pnlColor;
      private System.Windows.Forms.Label _lblColor;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public BrushDialog( )
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
         this._cbUse = new System.Windows.Forms.CheckBox();
         this._btnColor = new System.Windows.Forms.Button();
         this._pnlColor = new System.Windows.Forms.Panel();
         this._lblColor = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(200, 16);
         this._btnOk.Name = "_btnOk";
         this._btnOk.TabIndex = 4;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(200, 48);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 5;
         this._btnCancel.Text = "Cancel";
         // 
         // _cbUse
         // 
         this._cbUse.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._cbUse.Location = new System.Drawing.Point(24, 16);
         this._cbUse.Name = "_cbUse";
         this._cbUse.Size = new System.Drawing.Size(64, 24);
         this._cbUse.TabIndex = 0;
         this._cbUse.Text = "&Use";
         this._cbUse.CheckedChanged += new System.EventHandler(this._cbUse_CheckedChanged);
         // 
         // _btnColor
         // 
         this._btnColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnColor.Location = new System.Drawing.Point(120, 48);
         this._btnColor.Name = "_btnColor";
         this._btnColor.Size = new System.Drawing.Size(32, 23);
         this._btnColor.TabIndex = 3;
         this._btnColor.Text = "&...";
         this._btnColor.Click += new System.EventHandler(this._btnColor_Click);
         // 
         // _pnlColor
         // 
         this._pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._pnlColor.Location = new System.Drawing.Point(80, 48);
         this._pnlColor.Name = "_pnlColor";
         this._pnlColor.Size = new System.Drawing.Size(40, 23);
         this._pnlColor.TabIndex = 2;
         // 
         // _lblColor
         // 
         this._lblColor.Location = new System.Drawing.Point(24, 48);
         this._lblColor.Name = "_lblColor";
         this._lblColor.Size = new System.Drawing.Size(48, 23);
         this._lblColor.TabIndex = 1;
         this._lblColor.Text = "&Color:";
         this._lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // BrushDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(290, 85);
         this.Controls.Add(this._btnColor);
         this.Controls.Add(this._pnlColor);
         this.Controls.Add(this._lblColor);
         this.Controls.Add(this._cbUse);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "BrushDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Brush";
         this.Load += new System.EventHandler(this.BrushDialog_Load);
         this.ResumeLayout(false);

      }
      #endregion

      public bool BrushUse;
      public Color BrushColor;

      /// <summary>
      /// Load event, fill in the controls
      /// </summary>
      private void BrushDialog_Load(object sender, System.EventArgs e)
      {
         _cbUse.Checked = BrushUse;
         _pnlColor.BackColor = BrushColor;
         UpdateMyControls();
      }

      /// <summary>
      /// enable/diable the color controls based on the check box status
      /// </summary>
      private void UpdateMyControls( )
      {
         _lblColor.Enabled = _btnColor.Enabled = _pnlColor.Enabled = _cbUse.Checked;
      }

      /// <summary>
      /// Show the color dialog, update the panel back color
      /// </summary>
      private void _btnColor_Click(object sender, System.EventArgs e)
      {
         ColorDialog dlg = new ColorDialog();
         dlg.Color = _pnlColor.BackColor;
         if(dlg.ShowDialog(this) == DialogResult.OK)
            _pnlColor.BackColor = dlg.Color;
      }

      /// <summary>
      /// Dont forget to update the controls
      /// </summary>
      private void _cbUse_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateMyControls();
      }

      /// <summary>
      /// Get the brush usage and color from the controls back to the public variables
      /// </summary>
      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         // Notice, we dont need any try catch like we did in the pen dialog
         BrushUse = _cbUse.Checked;
         BrushColor = _pnlColor.BackColor;
      }
   }
}
