namespace DocumentCleanupDemo
{
   partial class RotateDialog
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
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numAngle)).BeginInit();
         this.SuspendLayout();
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
         this._gbOptions.Location = new System.Drawing.Point(11, 14);
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.Size = new System.Drawing.Size(316, 333);
         this._gbOptions.TabIndex = 0;
         this._gbOptions.TabStop = false;
         // 
         // _lblInterpolation
         // 
         this._lblInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblInterpolation.Location = new System.Drawing.Point(19, 185);
         this._lblInterpolation.Name = "_lblInterpolation";
         this._lblInterpolation.Size = new System.Drawing.Size(120, 26);
         this._lblInterpolation.TabIndex = 7;
         this._lblInterpolation.Text = "Interpolation";
         this._lblInterpolation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _gbOptionsInterpolation
         // 
         this._gbOptionsInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptionsInterpolation.Location = new System.Drawing.Point(19, 157);
         this._gbOptionsInterpolation.Name = "_gbOptionsInterpolation";
         this._gbOptionsInterpolation.Size = new System.Drawing.Size(279, 9);
         this._gbOptionsInterpolation.TabIndex = 6;
         this._gbOptionsInterpolation.TabStop = false;
         // 
         // _cbResize
         // 
         this._cbResize.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._cbResize.Location = new System.Drawing.Point(19, 120);
         this._cbResize.Name = "_cbResize";
         this._cbResize.Size = new System.Drawing.Size(125, 28);
         this._cbResize.TabIndex = 5;
         this._cbResize.Text = "Resize";
         // 
         // _btnFillColor
         // 
         this._btnFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnFillColor.Location = new System.Drawing.Point(269, 65);
         this._btnFillColor.Name = "_btnFillColor";
         this._btnFillColor.Size = new System.Drawing.Size(29, 26);
         this._btnFillColor.TabIndex = 4;
         this._btnFillColor.Text = "...";
         this._btnFillColor.Click += new System.EventHandler(this._btnFillColor_Click);
         // 
         // _pnlFillColor
         // 
         this._pnlFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._pnlFillColor.Location = new System.Drawing.Point(154, 65);
         this._pnlFillColor.Name = "_pnlFillColor";
         this._pnlFillColor.Size = new System.Drawing.Size(115, 27);
         this._pnlFillColor.TabIndex = 3;
         this._pnlFillColor.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlFillColor_Paint);
         // 
         // _lblFillColor
         // 
         this._lblFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblFillColor.Location = new System.Drawing.Point(19, 65);
         this._lblFillColor.Name = "_lblFillColor";
         this._lblFillColor.Size = new System.Drawing.Size(120, 26);
         this._lblFillColor.TabIndex = 2;
         this._lblFillColor.Text = "Fill Color";
         this._lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _numAngle
         // 
         this._numAngle.Location = new System.Drawing.Point(154, 28);
         this._numAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
         this._numAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
         this._numAngle.Name = "_numAngle";
         this._numAngle.Size = new System.Drawing.Size(144, 22);
         this._numAngle.TabIndex = 1;
         this._numAngle.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblAngle
         // 
         this._lblAngle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblAngle.Location = new System.Drawing.Point(19, 28);
         this._lblAngle.Name = "_lblAngle";
         this._lblAngle.Size = new System.Drawing.Size(120, 26);
         this._lblAngle.TabIndex = 0;
         this._lblAngle.Text = "Angle";
         this._lblAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _rbButtonBicubic
         // 
         this._rbButtonBicubic.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonBicubic.Location = new System.Drawing.Point(19, 295);
         this._rbButtonBicubic.Name = "_rbButtonBicubic";
         this._rbButtonBicubic.Size = new System.Drawing.Size(154, 28);
         this._rbButtonBicubic.TabIndex = 10;
         this._rbButtonBicubic.Text = "BiCubic";
         // 
         // _rbButtonNormal
         // 
         this._rbButtonNormal.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonNormal.Location = new System.Drawing.Point(19, 222);
         this._rbButtonNormal.Name = "_rbButtonNormal";
         this._rbButtonNormal.Size = new System.Drawing.Size(154, 27);
         this._rbButtonNormal.TabIndex = 8;
         this._rbButtonNormal.Text = "Normal";
         // 
         // _rbButtonResample
         // 
         this._rbButtonResample.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonResample.Location = new System.Drawing.Point(19, 258);
         this._rbButtonResample.Name = "_rbButtonResample";
         this._rbButtonResample.Size = new System.Drawing.Size(154, 28);
         this._rbButtonResample.TabIndex = 9;
         this._rbButtonResample.Text = "Resample (Bilinear)";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(347, 60);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(90, 27);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(347, 23);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(90, 27);
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // RotateDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(449, 362);
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

      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Label _lblInterpolation;
      private System.Windows.Forms.GroupBox _gbOptionsInterpolation;
      private System.Windows.Forms.CheckBox _cbResize;
      private System.Windows.Forms.Button _btnFillColor;
      private System.Windows.Forms.Panel _pnlFillColor;
      private System.Windows.Forms.Label _lblFillColor;
      private System.Windows.Forms.NumericUpDown _numAngle;
      private System.Windows.Forms.Label _lblAngle;
      private System.Windows.Forms.RadioButton _rbButtonBicubic;
      private System.Windows.Forms.RadioButton _rbButtonNormal;
      private System.Windows.Forms.RadioButton _rbButtonResample;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;

   }
}