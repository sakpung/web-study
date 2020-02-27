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
   /// Summary description for PenDialog.
   /// </summary>
   public class PenDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Label _lblWidth;
      private System.Windows.Forms.TextBox _tbWidth;
      private System.Windows.Forms.Label _lblColor;
      private System.Windows.Forms.Panel _pnlColor;
      private System.Windows.Forms.Button _btnColor;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public PenDialog( )
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
         this._lblWidth = new System.Windows.Forms.Label();
         this._tbWidth = new System.Windows.Forms.TextBox();
         this._lblColor = new System.Windows.Forms.Label();
         this._pnlColor = new System.Windows.Forms.Panel();
         this._btnColor = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(200, 16);
         this._btnOk.Name = "_btnOk";
         this._btnOk.TabIndex = 5;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(200, 48);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 6;
         this._btnCancel.Text = "Cancel";
         // 
         // _lblWidth
         // 
         this._lblWidth.Location = new System.Drawing.Point(16, 16);
         this._lblWidth.Name = "_lblWidth";
         this._lblWidth.Size = new System.Drawing.Size(48, 23);
         this._lblWidth.TabIndex = 0;
         this._lblWidth.Text = "&Width:";
         this._lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _tbWidth
         // 
         this._tbWidth.Location = new System.Drawing.Point(72, 16);
         this._tbWidth.Name = "_tbWidth";
         this._tbWidth.TabIndex = 2;
         this._tbWidth.Text = "";
         this._tbWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbWidth_KeyPress);
         // 
         // _lblColor
         // 
         this._lblColor.Location = new System.Drawing.Point(16, 48);
         this._lblColor.Name = "_lblColor";
         this._lblColor.Size = new System.Drawing.Size(48, 23);
         this._lblColor.TabIndex = 1;
         this._lblColor.Text = "&Color:";
         this._lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _pnlColor
         // 
         this._pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._pnlColor.Location = new System.Drawing.Point(72, 48);
         this._pnlColor.Name = "_pnlColor";
         this._pnlColor.Size = new System.Drawing.Size(40, 23);
         this._pnlColor.TabIndex = 3;
         // 
         // _btnColor
         // 
         this._btnColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnColor.Location = new System.Drawing.Point(112, 48);
         this._btnColor.Name = "_btnColor";
         this._btnColor.Size = new System.Drawing.Size(32, 23);
         this._btnColor.TabIndex = 4;
         this._btnColor.Text = "&...";
         this._btnColor.Click += new System.EventHandler(this._btnColor_Click);
         // 
         // PenDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(290, 85);
         this.Controls.Add(this._btnColor);
         this.Controls.Add(this._pnlColor);
         this.Controls.Add(this._lblColor);
         this.Controls.Add(this._tbWidth);
         this.Controls.Add(this._lblWidth);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PenDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Pen";
         this.Load += new System.EventHandler(this.PenDialog_Load);
         this.ResumeLayout(false);

      }
      #endregion

      public int PenWidth;
      public Color PenColor;

      /// <summary>
      /// Load event, fill in the controls
      /// </summary>
      private void PenDialog_Load(object sender, System.EventArgs e)
      {
         _tbWidth.Text = PenWidth.ToString();
         _pnlColor.BackColor = PenColor;
      }

      /// <summary>
      /// Allow only numbers of control keys for this text box
      /// </summary>
      private void _tbWidth_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
         if(!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            e.Handled = true;
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
      /// Get the pen width and color from the controls back to the public variables
      /// </summary>
      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         // see if we have a valid integer between 0 and 20
         try
         {
            int val = int.Parse(_tbWidth.Text);
            if(val <= 0 || val > 20)
               throw new ApplicationException("Width should be between 1 and 20");

            // all ok now
            PenWidth = val;
            PenColor = _pnlColor.BackColor;
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);

            // stop the dialog from shutting down
            DialogResult = DialogResult.None;
         }
      }
   }
}
