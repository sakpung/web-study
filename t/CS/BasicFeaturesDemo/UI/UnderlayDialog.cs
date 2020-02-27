// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools;

namespace BasicFeaturesDemo
{
   /// <summary>
   /// Summary description for UnderlayDialog.
   /// </summary>
   public class UnderlayDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.RadioButton _rbTile;
      private System.Windows.Forms.RadioButton _rbStretch;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public UnderlayDialog( )
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
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._rbTile = new System.Windows.Forms.RadioButton();
         this._rbStretch = new System.Windows.Forms.RadioButton();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._rbTile);
         this._gbOptions.Controls.Add(this._rbStretch);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptions.Location = new System.Drawing.Point(7, 6);
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.Size = new System.Drawing.Size(136, 88);
         this._gbOptions.TabIndex = 0;
         this._gbOptions.TabStop = false;
         // 
         // _rbTile
         // 
         this._rbTile.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbTile.Location = new System.Drawing.Point(16, 56);
         this._rbTile.Name = "_rbTile";
         this._rbTile.TabIndex = 1;
         this._rbTile.Text = "Tile";
         // 
         // _rbStretch
         // 
         this._rbStretch.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbStretch.Location = new System.Drawing.Point(16, 24);
         this._rbStretch.Name = "_rbStretch";
         this._rbStretch.TabIndex = 0;
         this._rbStretch.Text = "Stretch";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(167, 46);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(167, 14);
         this._btnOk.Name = "_btnOk";
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // UnderlayDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(250, 103);
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "UnderlayDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Underlay";
         this.Load += new System.EventHandler(this.UnderlayDialog_Load);
         this._gbOptions.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      private static bool _firstTimer = true;
      private static RasterImageUnderlayFlags _initialFlags;
      public RasterImageUnderlayFlags Flags;

      private void UnderlayDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            _initialFlags = RasterImageUnderlayFlags.Stretch;
         }

         Flags = _initialFlags;
         _rbStretch.Checked = (Flags & RasterImageUnderlayFlags.Stretch) == RasterImageUnderlayFlags.Stretch;
         _rbTile.Checked = (Flags & RasterImageUnderlayFlags.None) == RasterImageUnderlayFlags.None;
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         if(_rbStretch.Checked)
            Flags = RasterImageUnderlayFlags.Stretch;
         if(_rbTile.Checked)
            Flags = RasterImageUnderlayFlags.None;

         _initialFlags = Flags;
      }
   }
}
