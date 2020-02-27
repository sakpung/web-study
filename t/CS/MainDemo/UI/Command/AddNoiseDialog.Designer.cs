using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.Demos;
using Leadtools;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Effects;

namespace MainDemo
{
   partial class AddNoiseDialog
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNoiseDialog));
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._lblRange = new System.Windows.Forms.Label();
         this._cbChannel = new System.Windows.Forms.ComboBox();
         this._numRange = new System.Windows.Forms.NumericUpDown();
         this._lblChannel = new System.Windows.Forms.Label();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numRange)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._lblRange);
         this._gbOptions.Controls.Add(this._cbChannel);
         this._gbOptions.Controls.Add(this._numRange);
         this._gbOptions.Controls.Add(this._lblChannel);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _lblRange
         // 
         resources.ApplyResources(this._lblRange, "_lblRange");
         this._lblRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblRange.Name = "_lblRange";
         // 
         // _cbChannel
         // 
         this._cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbChannel.FormattingEnabled = true;
         resources.ApplyResources(this._cbChannel, "_cbChannel");
         this._cbChannel.Name = "_cbChannel";
         // 
         // _numRange
         // 
         resources.ApplyResources(this._numRange, "_numRange");
         this._numRange.Name = "_numRange";
         this._numRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numRange.Leave += new System.EventHandler(this._numRange_Leave);
         // 
         // _lblChannel
         // 
         resources.ApplyResources(this._lblChannel, "_lblChannel");
         this._lblChannel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblChannel.Name = "_lblChannel";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // AddNoiseDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbOptions);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AddNoiseDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.AddNoiseDialog_Load);
         this._gbOptions.ResumeLayout(false);
         this._gbOptions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numRange)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.ComboBox _cbChannel;
      private System.Windows.Forms.NumericUpDown _numRange;
      private System.Windows.Forms.Label _lblChannel;
      private System.Windows.Forms.Label _lblRange;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}