namespace GrayScaleDemo
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
           this._pnlColor = new System.Windows.Forms.Panel();
           this._pnlRevColor = new System.Windows.Forms.Panel();
           this._btnDlgColor = new System.Windows.Forms.Button();
           this.label1 = new System.Windows.Forms.Label();
           this._pnlLevel = new System.Windows.Forms.Panel();
           this._numFillColorLevel = new System.Windows.Forms.NumericUpDown();
           this._lblFillColor = new System.Windows.Forms.Label();
           this._lblInterpolation = new System.Windows.Forms.Label();
           this._gbOptionsInterpolation = new System.Windows.Forms.GroupBox();
           this._cbResize = new System.Windows.Forms.CheckBox();
           this._numAngle = new System.Windows.Forms.NumericUpDown();
           this._lblAngle = new System.Windows.Forms.Label();
           this._rbButtonBicubic = new System.Windows.Forms.RadioButton();
           this._rbButtonNormal = new System.Windows.Forms.RadioButton();
           this._rbButtonResample = new System.Windows.Forms.RadioButton();
           this._btnCancel = new System.Windows.Forms.Button();
           this._btnOk = new System.Windows.Forms.Button();
           this._gbOptions.SuspendLayout();
           this._pnlColor.SuspendLayout();
           this._pnlLevel.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._numFillColorLevel)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._numAngle)).BeginInit();
           this.SuspendLayout();
           // 
           // _gbOptions
           // 
           this._gbOptions.Controls.Add(this._pnlLevel);
           this._gbOptions.Controls.Add(this._lblInterpolation);
           this._gbOptions.Controls.Add(this._gbOptionsInterpolation);
           this._gbOptions.Controls.Add(this._cbResize);
           this._gbOptions.Controls.Add(this._numAngle);
           this._gbOptions.Controls.Add(this._lblAngle);
           this._gbOptions.Controls.Add(this._rbButtonBicubic);
           this._gbOptions.Controls.Add(this._rbButtonNormal);
           this._gbOptions.Controls.Add(this._rbButtonResample);
           this._gbOptions.Controls.Add(this._pnlColor);
           this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._gbOptions.Location = new System.Drawing.Point(7, 7);
           this._gbOptions.Margin = new System.Windows.Forms.Padding(2);
           this._gbOptions.Name = "_gbOptions";
           this._gbOptions.Padding = new System.Windows.Forms.Padding(2);
           this._gbOptions.Size = new System.Drawing.Size(252, 271);
           this._gbOptions.TabIndex = 3;
           this._gbOptions.TabStop = false;
           // 
           // _pnlColor
           // 
           this._pnlColor.Controls.Add(this._pnlRevColor);
           this._pnlColor.Controls.Add(this._btnDlgColor);
           this._pnlColor.Controls.Add(this.label1);
           this._pnlColor.Location = new System.Drawing.Point(5, 49);
           this._pnlColor.Name = "_pnlColor";
           this._pnlColor.Size = new System.Drawing.Size(231, 44);
           this._pnlColor.TabIndex = 13;
           // 
           // _pnlRevColor
           // 
           this._pnlRevColor.Location = new System.Drawing.Point(156, 10);
           this._pnlRevColor.Name = "_pnlRevColor";
           this._pnlRevColor.Size = new System.Drawing.Size(63, 26);
           this._pnlRevColor.TabIndex = 4;
           // 
           // _btnDlgColor
           // 
           this._btnDlgColor.Location = new System.Drawing.Point(111, 10);
           this._btnDlgColor.Name = "_btnDlgColor";
           this._btnDlgColor.Size = new System.Drawing.Size(33, 26);
           this._btnDlgColor.TabIndex = 3;
           this._btnDlgColor.Text = "...";
           this._btnDlgColor.UseVisualStyleBackColor = true;
           this._btnDlgColor.Click += new System.EventHandler(this._btnDlgColor_Click);
           // 
           // label1
           // 
           this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this.label1.Location = new System.Drawing.Point(10, 12);
           this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(90, 21);
           this.label1.TabIndex = 2;
           this.label1.Text = "Fill Color ";
           this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _pnlLevel
           // 
           this._pnlLevel.Controls.Add(this._numFillColorLevel);
           this._pnlLevel.Controls.Add(this._lblFillColor);
           this._pnlLevel.Location = new System.Drawing.Point(5, 47);
           this._pnlLevel.Name = "_pnlLevel";
           this._pnlLevel.Size = new System.Drawing.Size(231, 44);
           this._pnlLevel.TabIndex = 12;
           // 
           // _numFillColorLevel
           // 
           this._numFillColorLevel.Location = new System.Drawing.Point(111, 12);
           this._numFillColorLevel.Margin = new System.Windows.Forms.Padding(2);
           this._numFillColorLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
           this._numFillColorLevel.Name = "_numFillColorLevel";
           this._numFillColorLevel.Size = new System.Drawing.Size(108, 20);
           this._numFillColorLevel.TabIndex = 11;
           // 
           // _lblFillColor
           // 
           this._lblFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblFillColor.Location = new System.Drawing.Point(6, 11);
           this._lblFillColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblFillColor.Name = "_lblFillColor";
           this._lblFillColor.Size = new System.Drawing.Size(90, 21);
           this._lblFillColor.TabIndex = 2;
           this._lblFillColor.Text = "Fill Color Level";
           this._lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _lblInterpolation
           // 
           this._lblInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblInterpolation.Location = new System.Drawing.Point(14, 150);
           this._lblInterpolation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblInterpolation.Name = "_lblInterpolation";
           this._lblInterpolation.Size = new System.Drawing.Size(90, 21);
           this._lblInterpolation.TabIndex = 7;
           this._lblInterpolation.Text = "Interpolation";
           this._lblInterpolation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _gbOptionsInterpolation
           // 
           this._gbOptionsInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._gbOptionsInterpolation.Location = new System.Drawing.Point(14, 128);
           this._gbOptionsInterpolation.Margin = new System.Windows.Forms.Padding(2);
           this._gbOptionsInterpolation.Name = "_gbOptionsInterpolation";
           this._gbOptionsInterpolation.Padding = new System.Windows.Forms.Padding(2);
           this._gbOptionsInterpolation.Size = new System.Drawing.Size(222, 7);
           this._gbOptionsInterpolation.TabIndex = 6;
           this._gbOptionsInterpolation.TabStop = false;
           // 
           // _cbResize
           // 
           this._cbResize.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._cbResize.Location = new System.Drawing.Point(14, 98);
           this._cbResize.Margin = new System.Windows.Forms.Padding(2);
           this._cbResize.Name = "_cbResize";
           this._cbResize.Size = new System.Drawing.Size(94, 23);
           this._cbResize.TabIndex = 5;
           this._cbResize.Text = "Resize";
           // 
           // _numAngle
           // 
           this._numAngle.Location = new System.Drawing.Point(116, 23);
           this._numAngle.Margin = new System.Windows.Forms.Padding(2);
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
           this._numAngle.Size = new System.Drawing.Size(108, 20);
           this._numAngle.TabIndex = 1;
           // 
           // _lblAngle
           // 
           this._lblAngle.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblAngle.Location = new System.Drawing.Point(14, 23);
           this._lblAngle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblAngle.Name = "_lblAngle";
           this._lblAngle.Size = new System.Drawing.Size(90, 21);
           this._lblAngle.TabIndex = 0;
           this._lblAngle.Text = "Angle";
           this._lblAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _rbButtonBicubic
           // 
           this._rbButtonBicubic.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._rbButtonBicubic.Location = new System.Drawing.Point(14, 240);
           this._rbButtonBicubic.Margin = new System.Windows.Forms.Padding(2);
           this._rbButtonBicubic.Name = "_rbButtonBicubic";
           this._rbButtonBicubic.Size = new System.Drawing.Size(116, 23);
           this._rbButtonBicubic.TabIndex = 10;
           this._rbButtonBicubic.Text = "BiCubic";
           // 
           // _rbButtonNormal
           // 
           this._rbButtonNormal.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._rbButtonNormal.Location = new System.Drawing.Point(14, 180);
           this._rbButtonNormal.Margin = new System.Windows.Forms.Padding(2);
           this._rbButtonNormal.Name = "_rbButtonNormal";
           this._rbButtonNormal.Size = new System.Drawing.Size(116, 22);
           this._rbButtonNormal.TabIndex = 8;
           this._rbButtonNormal.Text = "Normal";
           // 
           // _rbButtonResample
           // 
           this._rbButtonResample.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._rbButtonResample.Location = new System.Drawing.Point(14, 210);
           this._rbButtonResample.Margin = new System.Windows.Forms.Padding(2);
           this._rbButtonResample.Name = "_rbButtonResample";
           this._rbButtonResample.Size = new System.Drawing.Size(116, 23);
           this._rbButtonResample.TabIndex = 9;
           this._rbButtonResample.Text = "Resample (Bilinear)";
           // 
           // _btnCancel
           // 
           this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._btnCancel.Location = new System.Drawing.Point(281, 41);
           this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(68, 22);
           this._btnCancel.TabIndex = 5;
           this._btnCancel.Text = "Cancel";
           this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
           // 
           // _btnOk
           // 
           this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
           this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._btnOk.Location = new System.Drawing.Point(281, 11);
           this._btnOk.Margin = new System.Windows.Forms.Padding(2);
           this._btnOk.Name = "_btnOk";
           this._btnOk.Size = new System.Drawing.Size(68, 22);
           this._btnOk.TabIndex = 4;
           this._btnOk.Text = "OK";
           this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
           // 
           // RotateDialog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(359, 291);
           this.Controls.Add(this._gbOptions);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this._btnOk);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "RotateDialog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "RotateDialog";
           this.Load += new System.EventHandler(this.RotateDialog_Load);
           this._gbOptions.ResumeLayout(false);
           this._pnlColor.ResumeLayout(false);
           this._pnlLevel.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this._numFillColorLevel)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._numAngle)).EndInit();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbOptions;
        private System.Windows.Forms.Label _lblInterpolation;
        private System.Windows.Forms.GroupBox _gbOptionsInterpolation;
        private System.Windows.Forms.CheckBox _cbResize;
        private System.Windows.Forms.NumericUpDown _numAngle;
        private System.Windows.Forms.Label _lblAngle;
        private System.Windows.Forms.RadioButton _rbButtonBicubic;
        private System.Windows.Forms.RadioButton _rbButtonNormal;
        private System.Windows.Forms.RadioButton _rbButtonResample;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.NumericUpDown _numFillColorLevel;
        private System.Windows.Forms.Label _lblFillColor;
        private System.Windows.Forms.Panel _pnlColor;
        private System.Windows.Forms.Button _btnDlgColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel _pnlLevel;
        private System.Windows.Forms.Panel _pnlRevColor;
    }
}