namespace DocumentCleanupDemo
{
   partial class ResizeDialog
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
         this._gbOptionsFlags = new System.Windows.Forms.GroupBox();
         this._numWidth = new System.Windows.Forms.NumericUpDown();
         this._lblWidth = new System.Windows.Forms.Label();
         this._rbButtonResample = new System.Windows.Forms.RadioButton();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._lblInterpolation = new System.Windows.Forms.Label();
         this._rbButtonFavorBlackOrBicubic = new System.Windows.Forms.RadioButton();
         this._rbButtonBicubic = new System.Windows.Forms.RadioButton();
         this._rbButtonFavorBlackOrResample = new System.Windows.Forms.RadioButton();
         this._numHeight = new System.Windows.Forms.NumericUpDown();
         this._lblHeight = new System.Windows.Forms.Label();
         this._rbButtonNormal = new System.Windows.Forms.RadioButton();
         this._rbButtonFavorBlack = new System.Windows.Forms.RadioButton();
         this._btnOk = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbOptionsFlags
         // 
         this._gbOptionsFlags.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptionsFlags.Location = new System.Drawing.Point(19, 83);
         this._gbOptionsFlags.Name = "_gbOptionsFlags";
         this._gbOptionsFlags.Size = new System.Drawing.Size(279, 9);
         this._gbOptionsFlags.TabIndex = 4;
         this._gbOptionsFlags.TabStop = false;
         // 
         // _numWidth
         // 
         this._numWidth.Location = new System.Drawing.Point(154, 18);
         this._numWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numWidth.Name = "_numWidth";
         this._numWidth.Size = new System.Drawing.Size(144, 22);
         this._numWidth.TabIndex = 1;
         this._numWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // _lblWidth
         // 
         this._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblWidth.Location = new System.Drawing.Point(19, 18);
         this._lblWidth.Name = "_lblWidth";
         this._lblWidth.Size = new System.Drawing.Size(120, 27);
         this._lblWidth.TabIndex = 0;
         this._lblWidth.Text = "New Width";
         this._lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _rbButtonResample
         // 
         this._rbButtonResample.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonResample.Location = new System.Drawing.Point(19, 212);
         this._rbButtonResample.Name = "_rbButtonResample";
         this._rbButtonResample.Size = new System.Drawing.Size(154, 28);
         this._rbButtonResample.TabIndex = 8;
         this._rbButtonResample.Text = "Resample";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(348, 58);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(90, 27);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._lblInterpolation);
         this._gbOptions.Controls.Add(this._rbButtonFavorBlackOrBicubic);
         this._gbOptions.Controls.Add(this._rbButtonBicubic);
         this._gbOptions.Controls.Add(this._rbButtonFavorBlackOrResample);
         this._gbOptions.Controls.Add(this._numHeight);
         this._gbOptions.Controls.Add(this._lblHeight);
         this._gbOptions.Controls.Add(this._gbOptionsFlags);
         this._gbOptions.Controls.Add(this._numWidth);
         this._gbOptions.Controls.Add(this._lblWidth);
         this._gbOptions.Controls.Add(this._rbButtonResample);
         this._gbOptions.Controls.Add(this._rbButtonNormal);
         this._gbOptions.Controls.Add(this._rbButtonFavorBlack);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptions.Location = new System.Drawing.Point(12, 12);
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.Size = new System.Drawing.Size(316, 360);
         this._gbOptions.TabIndex = 0;
         this._gbOptions.TabStop = false;
         // 
         // _lblInterpolation
         // 
         this._lblInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblInterpolation.Location = new System.Drawing.Point(19, 102);
         this._lblInterpolation.Name = "_lblInterpolation";
         this._lblInterpolation.Size = new System.Drawing.Size(120, 26);
         this._lblInterpolation.TabIndex = 5;
         this._lblInterpolation.Text = "Interpolation";
         this._lblInterpolation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _rbButtonFavorBlackOrBicubic
         // 
         this._rbButtonFavorBlackOrBicubic.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonFavorBlackOrBicubic.Location = new System.Drawing.Point(19, 323);
         this._rbButtonFavorBlackOrBicubic.Name = "_rbButtonFavorBlackOrBicubic";
         this._rbButtonFavorBlackOrBicubic.Size = new System.Drawing.Size(202, 28);
         this._rbButtonFavorBlackOrBicubic.TabIndex = 11;
         this._rbButtonFavorBlackOrBicubic.Text = "Favor Black Or Bicubic";
         // 
         // _rbButtonBicubic
         // 
         this._rbButtonBicubic.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonBicubic.Location = new System.Drawing.Point(19, 286);
         this._rbButtonBicubic.Name = "_rbButtonBicubic";
         this._rbButtonBicubic.Size = new System.Drawing.Size(154, 28);
         this._rbButtonBicubic.TabIndex = 10;
         this._rbButtonBicubic.Text = "Bicubic";
         // 
         // _rbButtonFavorBlackOrResample
         // 
         this._rbButtonFavorBlackOrResample.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonFavorBlackOrResample.Location = new System.Drawing.Point(19, 249);
         this._rbButtonFavorBlackOrResample.Name = "_rbButtonFavorBlackOrResample";
         this._rbButtonFavorBlackOrResample.Size = new System.Drawing.Size(202, 28);
         this._rbButtonFavorBlackOrResample.TabIndex = 9;
         this._rbButtonFavorBlackOrResample.Text = "Favor Black Or Resample";
         // 
         // _numHeight
         // 
         this._numHeight.Location = new System.Drawing.Point(154, 55);
         this._numHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numHeight.Name = "_numHeight";
         this._numHeight.Size = new System.Drawing.Size(144, 22);
         this._numHeight.TabIndex = 3;
         this._numHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // _lblHeight
         // 
         this._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblHeight.Location = new System.Drawing.Point(19, 55);
         this._lblHeight.Name = "_lblHeight";
         this._lblHeight.Size = new System.Drawing.Size(120, 27);
         this._lblHeight.TabIndex = 2;
         this._lblHeight.Text = "New Height";
         this._lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _rbButtonNormal
         // 
         this._rbButtonNormal.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonNormal.Location = new System.Drawing.Point(19, 138);
         this._rbButtonNormal.Name = "_rbButtonNormal";
         this._rbButtonNormal.Size = new System.Drawing.Size(154, 28);
         this._rbButtonNormal.TabIndex = 6;
         this._rbButtonNormal.Text = "Normal";
         // 
         // _rbButtonFavorBlack
         // 
         this._rbButtonFavorBlack.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonFavorBlack.Location = new System.Drawing.Point(19, 175);
         this._rbButtonFavorBlack.Name = "_rbButtonFavorBlack";
         this._rbButtonFavorBlack.Size = new System.Drawing.Size(154, 28);
         this._rbButtonFavorBlack.TabIndex = 7;
         this._rbButtonFavorBlack.Text = "Favor Black";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(348, 21);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(90, 27);
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.Click +=new System.EventHandler(_btnOk_Click);
         // 
         // ResizeDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(449, 387);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ResizeDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Resize";
         this.Load += new System.EventHandler(ResizeDialog_Load); 
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptionsFlags;
      private System.Windows.Forms.NumericUpDown _numWidth;
      private System.Windows.Forms.Label _lblWidth;
      private System.Windows.Forms.RadioButton _rbButtonResample;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Label _lblInterpolation;
      private System.Windows.Forms.RadioButton _rbButtonFavorBlackOrBicubic;
      private System.Windows.Forms.RadioButton _rbButtonBicubic;
      private System.Windows.Forms.RadioButton _rbButtonFavorBlackOrResample;
      private System.Windows.Forms.NumericUpDown _numHeight;
      private System.Windows.Forms.Label _lblHeight;
      private System.Windows.Forms.RadioButton _rbButtonNormal;
      private System.Windows.Forms.RadioButton _rbButtonFavorBlack;
      private System.Windows.Forms.Button _btnOk;
   }
}