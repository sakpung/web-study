// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace AnnotationsDemo
{
   /// <summary>
   /// Summary description for ZoomDialog.
   /// </summary>
   public class ZoomDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Label _lblZoom;
      private System.Windows.Forms.TextBox _tbPercentage;
      private System.Windows.Forms.TrackBar _tbZoom;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public ZoomDialog( )
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
         this._lblZoom = new System.Windows.Forms.Label();
         this._tbPercentage = new System.Windows.Forms.TextBox();
         this._tbZoom = new System.Windows.Forms.TrackBar();
         ((System.ComponentModel.ISupportInitialize)(this._tbZoom)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(304, 16);
         this._btnOk.Name = "_btnOk";
         this._btnOk.TabIndex = 3;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(304, 48);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 4;
         this._btnCancel.Text = "Cancel";
         // 
         // _lblZoom
         // 
         this._lblZoom.Location = new System.Drawing.Point(16, 15);
         this._lblZoom.Name = "_lblZoom";
         this._lblZoom.Size = new System.Drawing.Size(72, 23);
         this._lblZoom.TabIndex = 0;
         this._lblZoom.Text = "&Percentage:";
         this._lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _tbPercentage
         // 
         this._tbPercentage.Location = new System.Drawing.Point(96, 16);
         this._tbPercentage.Name = "_tbPercentage";
         this._tbPercentage.TabIndex = 1;
         this._tbPercentage.Text = "";
         this._tbPercentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbPercentage_KeyPress);
         this._tbPercentage.TextChanged += new System.EventHandler(this._tbPercentage_TextChanged);
         // 
         // _tbZoom
         // 
         this._tbZoom.Location = new System.Drawing.Point(16, 48);
         this._tbZoom.Maximum = 30000;
         this._tbZoom.Minimum = 5;
         this._tbZoom.Name = "_tbZoom";
         this._tbZoom.Size = new System.Drawing.Size(264, 42);
         this._tbZoom.TabIndex = 2;
         this._tbZoom.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbZoom.Value = 5;
         this._tbZoom.Scroll += new System.EventHandler(this._tbZoom_Scroll);
         // 
         // ZoomDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(394, 101);
         this.Controls.Add(this._tbZoom);
         this.Controls.Add(this._tbPercentage);
         this.Controls.Add(this._lblZoom);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ZoomDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Zoom";
         this.Load += new System.EventHandler(this.ZoomDialog_Load);
         ((System.ComponentModel.ISupportInitialize)(this._tbZoom)).EndInit();
         this.ResumeLayout(false);

      }
      #endregion

      public int Value;
      public int MinimumValue;
      public int MaximumValue;

      private void ZoomDialog_Load(object sender, System.EventArgs e)
      {
         _tbZoom.Minimum = MinimumValue;
         _tbZoom.Maximum = MaximumValue;
         _tbPercentage.Text = Value.ToString();
      }

      private void _tbPercentage_TextChanged(object sender, System.EventArgs e)
      {
         try
         {
            int val = int.Parse(_tbPercentage.Text);
            if(val >= _tbZoom.Minimum && val <= _tbZoom.Maximum)
               _tbZoom.Value = val;
         }
         catch
         {
         }
      }

      private void _tbPercentage_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
         if(!e.Handled)
         {
            if(!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
               e.Handled = true;
         }
      }

      private void _tbZoom_Scroll(object sender, System.EventArgs e)
      {
         _tbPercentage.Text = _tbZoom.Value.ToString();
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Value = _tbZoom.Value;
      }
   }
}
