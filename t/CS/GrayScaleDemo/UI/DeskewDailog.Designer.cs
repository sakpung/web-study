namespace GrayScaleDemo
{
    partial class DeskewDailog
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
           this._rbNoFill = new System.Windows.Forms.RadioButton();
           this._rbFill = new System.Windows.Forms.RadioButton();
           this._pnlLevel = new System.Windows.Forms.Panel();
           this._numFillColorLevel = new System.Windows.Forms.NumericUpDown();
           this._lblFillColor = new System.Windows.Forms.Label();
           this._pnlColor = new System.Windows.Forms.Panel();
           this._pnlRevColor = new System.Windows.Forms.Panel();
           this._btnRevColor = new System.Windows.Forms.Button();
           this._lblColor = new System.Windows.Forms.Label();
           this._btnCancel = new System.Windows.Forms.Button();
           this._btnOk = new System.Windows.Forms.Button();
           this._gbOptions.SuspendLayout();
           this._pnlLevel.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._numFillColorLevel)).BeginInit();
           this._pnlColor.SuspendLayout();
           this.SuspendLayout();
           // 
           // _gbOptions
           // 
           this._gbOptions.Controls.Add(this._pnlLevel);
           this._gbOptions.Controls.Add(this._pnlColor);
           this._gbOptions.Controls.Add(this._rbNoFill);
           this._gbOptions.Controls.Add(this._rbFill);
           this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._gbOptions.Location = new System.Drawing.Point(11, 7);
           this._gbOptions.Margin = new System.Windows.Forms.Padding(2);
           this._gbOptions.Name = "_gbOptions";
           this._gbOptions.Padding = new System.Windows.Forms.Padding(2);
           this._gbOptions.Size = new System.Drawing.Size(246, 120);
           this._gbOptions.TabIndex = 3;
           this._gbOptions.TabStop = false;
           // 
           // _rbNoFill
           // 
           this._rbNoFill.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._rbNoFill.Location = new System.Drawing.Point(14, 83);
           this._rbNoFill.Margin = new System.Windows.Forms.Padding(2);
           this._rbNoFill.Name = "_rbNoFill";
           this._rbNoFill.Size = new System.Drawing.Size(153, 22);
           this._rbNoFill.TabIndex = 4;
           this._rbNoFill.TabStop = true;
           this._rbNoFill.Text = "Do not fill exposed area";
           this._rbNoFill.UseVisualStyleBackColor = true;
           // 
           // _rbFill
           // 
           this._rbFill.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._rbFill.Location = new System.Drawing.Point(14, 23);
           this._rbFill.Margin = new System.Windows.Forms.Padding(2);
           this._rbFill.Name = "_rbFill";
           this._rbFill.Size = new System.Drawing.Size(129, 22);
           this._rbFill.TabIndex = 0;
           this._rbFill.TabStop = true;
           this._rbFill.Text = "Fill Exposed Area";
           this._rbFill.UseVisualStyleBackColor = true;
           // 
           // _pnlLevel
           // 
           this._pnlLevel.Controls.Add(this._numFillColorLevel);
           this._pnlLevel.Controls.Add(this._lblFillColor);
           this._pnlLevel.Location = new System.Drawing.Point(25, 45);
           this._pnlLevel.Name = "_pnlLevel";
           this._pnlLevel.Size = new System.Drawing.Size(217, 38);
           this._pnlLevel.TabIndex = 6;
           this._pnlLevel.Visible = false;
           // 
           // _numFillColorLevel
           // 
           this._numFillColorLevel.Location = new System.Drawing.Point(93, 8);
           this._numFillColorLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
           this._numFillColorLevel.Name = "_numFillColorLevel";
           this._numFillColorLevel.Size = new System.Drawing.Size(98, 20);
           this._numFillColorLevel.TabIndex = 5;
           // 
           // _lblFillColor
           // 
           this._lblFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblFillColor.Location = new System.Drawing.Point(12, 8);
           this._lblFillColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblFillColor.Name = "_lblFillColor";
           this._lblFillColor.Size = new System.Drawing.Size(76, 21);
           this._lblFillColor.TabIndex = 1;
           this._lblFillColor.Text = "Fill Color Level";
           this._lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _pnlColor
           // 
           this._pnlColor.Controls.Add(this._pnlRevColor);
           this._pnlColor.Controls.Add(this._btnRevColor);
           this._pnlColor.Controls.Add(this._lblColor);
           this._pnlColor.Location = new System.Drawing.Point(27, 45);
           this._pnlColor.Name = "_pnlColor";
           this._pnlColor.Size = new System.Drawing.Size(207, 38);
           this._pnlColor.TabIndex = 7;
           // 
           // _pnlRevColor
           // 
           this._pnlRevColor.Location = new System.Drawing.Point(135, 7);
           this._pnlRevColor.Name = "_pnlRevColor";
           this._pnlRevColor.Size = new System.Drawing.Size(55, 25);
           this._pnlRevColor.TabIndex = 3;
           // 
           // _btnRevColor
           // 
           this._btnRevColor.Location = new System.Drawing.Point(86, 7);
           this._btnRevColor.Name = "_btnRevColor";
           this._btnRevColor.Size = new System.Drawing.Size(39, 26);
           this._btnRevColor.TabIndex = 2;
           this._btnRevColor.Text = "...";
           this._btnRevColor.UseVisualStyleBackColor = true;
           this._btnRevColor.Click += new System.EventHandler(this._btnRevColor_Click);
           // 
           // _lblColor
           // 
           this._lblColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblColor.Location = new System.Drawing.Point(12, 8);
           this._lblColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblColor.Name = "_lblColor";
           this._lblColor.Size = new System.Drawing.Size(76, 21);
           this._lblColor.TabIndex = 1;
           this._lblColor.Text = "Fill Color :";
           this._lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _btnCancel
           // 
           this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._btnCancel.Location = new System.Drawing.Point(268, 41);
           this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(68, 22);
           this._btnCancel.TabIndex = 5;
           this._btnCancel.Text = "Cancel";
           this._btnCancel.UseVisualStyleBackColor = true;
           // 
           // _btnOk
           // 
           this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
           this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._btnOk.Location = new System.Drawing.Point(268, 11);
           this._btnOk.Margin = new System.Windows.Forms.Padding(2);
           this._btnOk.Name = "_btnOk";
           this._btnOk.Size = new System.Drawing.Size(68, 22);
           this._btnOk.TabIndex = 4;
           this._btnOk.Text = "OK";
           this._btnOk.UseVisualStyleBackColor = true;
           this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
           // 
           // DeskewDailog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(344, 138);
           this.Controls.Add(this._gbOptions);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this._btnOk);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "DeskewDailog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Deskew";
           this.Load += new System.EventHandler(this.DeskewDailog_Load);
           this._gbOptions.ResumeLayout(false);
           this._pnlLevel.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this._numFillColorLevel)).EndInit();
           this._pnlColor.ResumeLayout(false);
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbOptions;
        private System.Windows.Forms.RadioButton _rbNoFill;
        private System.Windows.Forms.RadioButton _rbFill;
        private System.Windows.Forms.Label _lblFillColor;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Panel _pnlLevel;
        private System.Windows.Forms.Panel _pnlColor;
        private System.Windows.Forms.Label _lblColor;
        private System.Windows.Forms.Panel _pnlRevColor;
        private System.Windows.Forms.Button _btnRevColor;
        private System.Windows.Forms.NumericUpDown _numFillColorLevel;
    }
}