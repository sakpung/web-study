namespace GrayScaleDemo
{
    partial class IntensityDetectDailog
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
           this._lblMsg = new System.Windows.Forms.Label();
           this._gbOptions = new System.Windows.Forms.GroupBox();
           this._pnlLevel = new System.Windows.Forms.Panel();
           this._numOutColorLevel = new System.Windows.Forms.NumericUpDown();
           this._numInColorLevel = new System.Windows.Forms.NumericUpDown();
           this._lblOutColor = new System.Windows.Forms.Label();
           this._lblInColor = new System.Windows.Forms.Label();
           this._pnlColor = new System.Windows.Forms.Panel();
           this._lblOutClr = new System.Windows.Forms.Label();
           this._pnlOutRevColor = new System.Windows.Forms.Panel();
           this._pnlInRevColor = new System.Windows.Forms.Panel();
           this._btnOutColor = new System.Windows.Forms.Button();
           this._btnInColor = new System.Windows.Forms.Button();
           this._lblInClr = new System.Windows.Forms.Label();
           this._cbChannel = new System.Windows.Forms.ComboBox();
           this._numHigh = new System.Windows.Forms.NumericUpDown();
           this._numLow = new System.Windows.Forms.NumericUpDown();
           this._lblChannel = new System.Windows.Forms.Label();
           this._lblHigh = new System.Windows.Forms.Label();
           this._lblLow = new System.Windows.Forms.Label();
           this._btnCancel = new System.Windows.Forms.Button();
           this._btnOk = new System.Windows.Forms.Button();
           this._gbOptions.SuspendLayout();
           this._pnlLevel.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._numOutColorLevel)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._numInColorLevel)).BeginInit();
           this._pnlColor.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._numHigh)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._numLow)).BeginInit();
           this.SuspendLayout();
           // 
           // _lblMsg
           // 
           this._lblMsg.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblMsg.Location = new System.Drawing.Point(11, 214);
           this._lblMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblMsg.Name = "_lblMsg";
           this._lblMsg.Size = new System.Drawing.Size(208, 22);
           this._lblMsg.TabIndex = 5;
           this._lblMsg.Text = "Low must be less than High.";
           // 
           // _gbOptions
           // 
           this._gbOptions.Controls.Add(this._pnlColor);
           this._gbOptions.Controls.Add(this._cbChannel);
           this._gbOptions.Controls.Add(this._numHigh);
           this._gbOptions.Controls.Add(this._numLow);
           this._gbOptions.Controls.Add(this._lblChannel);
           this._gbOptions.Controls.Add(this._lblHigh);
           this._gbOptions.Controls.Add(this._lblLow);
           this._gbOptions.Controls.Add(this._pnlLevel);
           this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._gbOptions.Location = new System.Drawing.Point(11, 11);
           this._gbOptions.Margin = new System.Windows.Forms.Padding(2);
           this._gbOptions.Name = "_gbOptions";
           this._gbOptions.Padding = new System.Windows.Forms.Padding(2);
           this._gbOptions.Size = new System.Drawing.Size(273, 188);
           this._gbOptions.TabIndex = 4;
           this._gbOptions.TabStop = false;
           // 
           // _pnlLevel
           // 
           this._pnlLevel.Controls.Add(this._numOutColorLevel);
           this._pnlLevel.Controls.Add(this._numInColorLevel);
           this._pnlLevel.Controls.Add(this._lblOutColor);
           this._pnlLevel.Controls.Add(this._lblInColor);
           this._pnlLevel.Location = new System.Drawing.Point(5, 77);
           this._pnlLevel.Name = "_pnlLevel";
           this._pnlLevel.Size = new System.Drawing.Size(252, 69);
           this._pnlLevel.TabIndex = 14;
           // 
           // _numOutColorLevel
           // 
           this._numOutColorLevel.Location = new System.Drawing.Point(116, 40);
           this._numOutColorLevel.Margin = new System.Windows.Forms.Padding(2);
           this._numOutColorLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
           this._numOutColorLevel.Name = "_numOutColorLevel";
           this._numOutColorLevel.Size = new System.Drawing.Size(115, 20);
           this._numOutColorLevel.TabIndex = 13;
           // 
           // _numInColorLevel
           // 
           this._numInColorLevel.Location = new System.Drawing.Point(116, 11);
           this._numInColorLevel.Margin = new System.Windows.Forms.Padding(2);
           this._numInColorLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
           this._numInColorLevel.Name = "_numInColorLevel";
           this._numInColorLevel.Size = new System.Drawing.Size(115, 20);
           this._numInColorLevel.TabIndex = 12;
           // 
           // _lblOutColor
           // 
           this._lblOutColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblOutColor.Location = new System.Drawing.Point(9, 38);
           this._lblOutColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblOutColor.Name = "_lblOutColor";
           this._lblOutColor.Size = new System.Drawing.Size(75, 21);
           this._lblOutColor.TabIndex = 7;
           this._lblOutColor.Text = "Out Color Level";
           this._lblOutColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _lblInColor
           // 
           this._lblInColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblInColor.Location = new System.Drawing.Point(9, 9);
           this._lblInColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblInColor.Name = "_lblInColor";
           this._lblInColor.Size = new System.Drawing.Size(75, 21);
           this._lblInColor.TabIndex = 4;
           this._lblInColor.Text = "In Color Level";
           this._lblInColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _pnlColor
           // 
           this._pnlColor.Controls.Add(this._lblOutClr);
           this._pnlColor.Controls.Add(this._pnlOutRevColor);
           this._pnlColor.Controls.Add(this._pnlInRevColor);
           this._pnlColor.Controls.Add(this._btnOutColor);
           this._pnlColor.Controls.Add(this._btnInColor);
           this._pnlColor.Controls.Add(this._lblInClr);
           this._pnlColor.Location = new System.Drawing.Point(5, 77);
           this._pnlColor.Name = "_pnlColor";
           this._pnlColor.Size = new System.Drawing.Size(252, 68);
           this._pnlColor.TabIndex = 15;
           // 
           // _lblOutClr
           // 
           this._lblOutClr.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblOutClr.Location = new System.Drawing.Point(9, 38);
           this._lblOutClr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblOutClr.Name = "_lblOutClr";
           this._lblOutClr.Size = new System.Drawing.Size(75, 21);
           this._lblOutClr.TabIndex = 7;
           this._lblOutClr.Text = "Out Color ";
           this._lblOutClr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _pnlOutRevColor
           // 
           this._pnlOutRevColor.Location = new System.Drawing.Point(157, 35);
           this._pnlOutRevColor.Name = "_pnlOutRevColor";
           this._pnlOutRevColor.Size = new System.Drawing.Size(72, 21);
           this._pnlOutRevColor.TabIndex = 11;
           // 
           // _pnlInRevColor
           // 
           this._pnlInRevColor.Location = new System.Drawing.Point(157, 7);
           this._pnlInRevColor.Name = "_pnlInRevColor";
           this._pnlInRevColor.Size = new System.Drawing.Size(72, 21);
           this._pnlInRevColor.TabIndex = 10;
           // 
           // _btnOutColor
           // 
           this._btnOutColor.Location = new System.Drawing.Point(116, 34);
           this._btnOutColor.Name = "_btnOutColor";
           this._btnOutColor.Size = new System.Drawing.Size(29, 24);
           this._btnOutColor.TabIndex = 9;
           this._btnOutColor.Text = "...";
           this._btnOutColor.UseVisualStyleBackColor = true;
           this._btnOutColor.Click += new System.EventHandler(this._btnColor_Click);
           // 
           // _btnInColor
           // 
           this._btnInColor.Location = new System.Drawing.Point(116, 2);
           this._btnInColor.Name = "_btnInColor";
           this._btnInColor.Size = new System.Drawing.Size(29, 26);
           this._btnInColor.TabIndex = 8;
           this._btnInColor.Text = "...";
           this._btnInColor.UseVisualStyleBackColor = true;
           this._btnInColor.Click += new System.EventHandler(this._btnColor_Click);
           // 
           // _lblInClr
           // 
           this._lblInClr.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblInClr.Location = new System.Drawing.Point(9, 9);
           this._lblInClr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblInClr.Name = "_lblInClr";
           this._lblInClr.Size = new System.Drawing.Size(75, 21);
           this._lblInClr.TabIndex = 4;
           this._lblInClr.Text = "In Color";
           this._lblInClr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _cbChannel
           // 
           this._cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this._cbChannel.FormattingEnabled = true;
           this._cbChannel.Location = new System.Drawing.Point(121, 151);
           this._cbChannel.Margin = new System.Windows.Forms.Padding(2);
           this._cbChannel.Name = "_cbChannel";
           this._cbChannel.Size = new System.Drawing.Size(116, 21);
           this._cbChannel.TabIndex = 11;
           // 
           // _numHigh
           // 
           this._numHigh.Location = new System.Drawing.Point(121, 55);
           this._numHigh.Margin = new System.Windows.Forms.Padding(2);
           this._numHigh.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
           this._numHigh.Name = "_numHigh";
           this._numHigh.Size = new System.Drawing.Size(115, 20);
           this._numHigh.TabIndex = 3;
           // 
           // _numLow
           // 
           this._numLow.Location = new System.Drawing.Point(121, 25);
           this._numLow.Margin = new System.Windows.Forms.Padding(2);
           this._numLow.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
           this._numLow.Name = "_numLow";
           this._numLow.Size = new System.Drawing.Size(115, 20);
           this._numLow.TabIndex = 1;
           // 
           // _lblChannel
           // 
           this._lblChannel.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblChannel.Location = new System.Drawing.Point(14, 150);
           this._lblChannel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblChannel.Name = "_lblChannel";
           this._lblChannel.Size = new System.Drawing.Size(56, 21);
           this._lblChannel.TabIndex = 10;
           this._lblChannel.Text = "Blue Factor";
           this._lblChannel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _lblHigh
           // 
           this._lblHigh.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblHigh.Location = new System.Drawing.Point(14, 53);
           this._lblHigh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblHigh.Name = "_lblHigh";
           this._lblHigh.Size = new System.Drawing.Size(56, 21);
           this._lblHigh.TabIndex = 2;
           this._lblHigh.Text = "High";
           this._lblHigh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _lblLow
           // 
           this._lblLow.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblLow.Location = new System.Drawing.Point(14, 23);
           this._lblLow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblLow.Name = "_lblLow";
           this._lblLow.Size = new System.Drawing.Size(56, 21);
           this._lblLow.TabIndex = 0;
           this._lblLow.Text = "Low";
           this._lblLow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _btnCancel
           // 
           this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._btnCancel.Location = new System.Drawing.Point(288, 52);
           this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(68, 22);
           this._btnCancel.TabIndex = 7;
           this._btnCancel.Text = "Cancel";
           this._btnCancel.UseVisualStyleBackColor = true;
           // 
           // _btnOk
           // 
           this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
           this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._btnOk.Location = new System.Drawing.Point(288, 22);
           this._btnOk.Margin = new System.Windows.Forms.Padding(2);
           this._btnOk.Name = "_btnOk";
           this._btnOk.Size = new System.Drawing.Size(68, 22);
           this._btnOk.TabIndex = 6;
           this._btnOk.Text = "OK";
           this._btnOk.UseVisualStyleBackColor = true;
           this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
           // 
           // IntensityDetectDailog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(372, 243);
           this.Controls.Add(this._lblMsg);
           this.Controls.Add(this._gbOptions);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this._btnOk);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.KeyPreview = true;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "IntensityDetectDailog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Intensity Detect";
           this.Load += new System.EventHandler(this.IntensityDetectDailog_Load);
           this._gbOptions.ResumeLayout(false);
           this._pnlLevel.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this._numOutColorLevel)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._numInColorLevel)).EndInit();
           this._pnlColor.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this._numHigh)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._numLow)).EndInit();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _lblMsg;
        private System.Windows.Forms.GroupBox _gbOptions;
        private System.Windows.Forms.ComboBox _cbChannel;
        private System.Windows.Forms.NumericUpDown _numHigh;
        private System.Windows.Forms.NumericUpDown _numLow;
        private System.Windows.Forms.Label _lblChannel;
        private System.Windows.Forms.Label _lblOutColor;
        private System.Windows.Forms.Label _lblInColor;
        private System.Windows.Forms.Label _lblHigh;
        private System.Windows.Forms.Label _lblLow;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.NumericUpDown _numOutColorLevel;
        private System.Windows.Forms.NumericUpDown _numInColorLevel;
        private System.Windows.Forms.Panel _pnlLevel;
        private System.Windows.Forms.Panel _pnlColor;
        private System.Windows.Forms.Button _btnOutColor;
        private System.Windows.Forms.Button _btnInColor;
        private System.Windows.Forms.Label _lblOutClr;
        private System.Windows.Forms.Label _lblInClr;
        private System.Windows.Forms.Panel _pnlOutRevColor;
        private System.Windows.Forms.Panel _pnlInRevColor;
    }
}