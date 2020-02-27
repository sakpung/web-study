namespace GrayScaleDemo
{
    partial class ShearDialog
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
           this._gb = new System.Windows.Forms.GroupBox();
           this._lblDirection = new System.Windows.Forms.Label();
           this._numAngle = new System.Windows.Forms.NumericUpDown();
           this._lblAngle = new System.Windows.Forms.Label();
           this._rbHorizontal = new System.Windows.Forms.RadioButton();
           this._rbVertical = new System.Windows.Forms.RadioButton();
           this._pnlColor = new System.Windows.Forms.Panel();
           this._pnlRevColor = new System.Windows.Forms.Panel();
           this._lblFillClr = new System.Windows.Forms.Label();
           this._btnDlgColor = new System.Windows.Forms.Button();
           this._pnlLevel = new System.Windows.Forms.Panel();
           this._numFillColorLevel = new System.Windows.Forms.NumericUpDown();
           this._lblFillColor = new System.Windows.Forms.Label();
           this._btnCancel = new System.Windows.Forms.Button();
           this._btnOk = new System.Windows.Forms.Button();
           this._gb.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._numAngle)).BeginInit();
           this._pnlColor.SuspendLayout();
           this._pnlLevel.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._numFillColorLevel)).BeginInit();
           this.SuspendLayout();
           // 
           // _gb
           // 
           this._gb.Controls.Add(this._lblDirection);
           this._gb.Controls.Add(this._numAngle);
           this._gb.Controls.Add(this._lblAngle);
           this._gb.Controls.Add(this._rbHorizontal);
           this._gb.Controls.Add(this._rbVertical);
           this._gb.Controls.Add(this._pnlColor);
           this._gb.Controls.Add(this._pnlLevel);
           this._gb.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._gb.Location = new System.Drawing.Point(11, 11);
           this._gb.Margin = new System.Windows.Forms.Padding(2);
           this._gb.Name = "_gb";
           this._gb.Padding = new System.Windows.Forms.Padding(2);
           this._gb.Size = new System.Drawing.Size(257, 188);
           this._gb.TabIndex = 3;
           this._gb.TabStop = false;
           // 
           // _lblDirection
           // 
           this._lblDirection.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblDirection.Location = new System.Drawing.Point(14, 98);
           this._lblDirection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblDirection.Name = "_lblDirection";
           this._lblDirection.Size = new System.Drawing.Size(90, 22);
           this._lblDirection.TabIndex = 6;
           this._lblDirection.Text = "Direction";
           this._lblDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _numAngle
           // 
           this._numAngle.Location = new System.Drawing.Point(116, 23);
           this._numAngle.Margin = new System.Windows.Forms.Padding(2);
           this._numAngle.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
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
           // _rbHorizontal
           // 
           this._rbHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._rbHorizontal.Location = new System.Drawing.Point(14, 128);
           this._rbHorizontal.Margin = new System.Windows.Forms.Padding(2);
           this._rbHorizontal.Name = "_rbHorizontal";
           this._rbHorizontal.Size = new System.Drawing.Size(116, 23);
           this._rbHorizontal.TabIndex = 7;
           this._rbHorizontal.Text = "Horizontal";
           // 
           // _rbVertical
           // 
           this._rbVertical.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._rbVertical.Location = new System.Drawing.Point(14, 158);
           this._rbVertical.Margin = new System.Windows.Forms.Padding(2);
           this._rbVertical.Name = "_rbVertical";
           this._rbVertical.Size = new System.Drawing.Size(116, 23);
           this._rbVertical.TabIndex = 8;
           this._rbVertical.Text = "Vertical";
           // 
           // _pnlColor
           // 
           this._pnlColor.Controls.Add(this._pnlRevColor);
           this._pnlColor.Controls.Add(this._lblFillClr);
           this._pnlColor.Controls.Add(this._btnDlgColor);
           this._pnlColor.Location = new System.Drawing.Point(5, 48);
           this._pnlColor.Name = "_pnlColor";
           this._pnlColor.Size = new System.Drawing.Size(241, 43);
           this._pnlColor.TabIndex = 11;
           // 
           // _pnlRevColor
           // 
           this._pnlRevColor.Location = new System.Drawing.Point(151, 12);
           this._pnlRevColor.Name = "_pnlRevColor";
           this._pnlRevColor.Size = new System.Drawing.Size(59, 24);
           this._pnlRevColor.TabIndex = 4;
           // 
           // _lblFillClr
           // 
           this._lblFillClr.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblFillClr.Location = new System.Drawing.Point(9, 14);
           this._lblFillClr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblFillClr.Name = "_lblFillClr";
           this._lblFillClr.Size = new System.Drawing.Size(90, 21);
           this._lblFillClr.TabIndex = 2;
           this._lblFillClr.Text = "Fill Color ";
           this._lblFillClr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _btnDlgColor
           // 
           this._btnDlgColor.Location = new System.Drawing.Point(102, 12);
           this._btnDlgColor.Name = "_btnDlgColor";
           this._btnDlgColor.Size = new System.Drawing.Size(35, 24);
           this._btnDlgColor.TabIndex = 3;
           this._btnDlgColor.Text = "...";
           this._btnDlgColor.UseVisualStyleBackColor = true;
           this._btnDlgColor.Click += new System.EventHandler(this._btnDlgColor_Click);
           // 
           // _pnlLevel
           // 
           this._pnlLevel.Controls.Add(this._numFillColorLevel);
           this._pnlLevel.Controls.Add(this._lblFillColor);
           this._pnlLevel.Location = new System.Drawing.Point(11, 47);
           this._pnlLevel.Name = "_pnlLevel";
           this._pnlLevel.Size = new System.Drawing.Size(232, 47);
           this._pnlLevel.TabIndex = 10;
           // 
           // _numFillColorLevel
           // 
           this._numFillColorLevel.Location = new System.Drawing.Point(105, 15);
           this._numFillColorLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
           this._numFillColorLevel.Name = "_numFillColorLevel";
           this._numFillColorLevel.Size = new System.Drawing.Size(108, 20);
           this._numFillColorLevel.TabIndex = 9;
           // 
           // _lblFillColor
           // 
           this._lblFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._lblFillColor.Location = new System.Drawing.Point(0, 13);
           this._lblFillColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
           this._lblFillColor.Name = "_lblFillColor";
           this._lblFillColor.Size = new System.Drawing.Size(90, 21);
           this._lblFillColor.TabIndex = 2;
           this._lblFillColor.Text = "Fill Color Level";
           this._lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // _btnCancel
           // 
           this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._btnCancel.Location = new System.Drawing.Point(272, 52);
           this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(68, 22);
           this._btnCancel.TabIndex = 5;
           this._btnCancel.Text = "Cancel";
           // 
           // _btnOk
           // 
           this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
           this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this._btnOk.Location = new System.Drawing.Point(272, 22);
           this._btnOk.Margin = new System.Windows.Forms.Padding(2);
           this._btnOk.Name = "_btnOk";
           this._btnOk.Size = new System.Drawing.Size(68, 22);
           this._btnOk.TabIndex = 4;
           this._btnOk.Text = "OK";
           this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
           // 
           // ShearDialog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(351, 213);
           this.Controls.Add(this._gb);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this._btnOk);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "ShearDialog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Shear";
           this.Load += new System.EventHandler(this.ShearDialog_Load);
           this._gb.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this._numAngle)).EndInit();
           this._pnlColor.ResumeLayout(false);
           this._pnlLevel.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this._numFillColorLevel)).EndInit();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gb;
        private System.Windows.Forms.Label _lblDirection;
        private System.Windows.Forms.Label _lblFillColor;
        private System.Windows.Forms.NumericUpDown _numAngle;
        private System.Windows.Forms.Label _lblAngle;
        private System.Windows.Forms.RadioButton _rbHorizontal;
        private System.Windows.Forms.RadioButton _rbVertical;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.NumericUpDown _numFillColorLevel;
        private System.Windows.Forms.Panel _pnlLevel;
        private System.Windows.Forms.Panel _pnlColor;
        private System.Windows.Forms.Button _btnDlgColor;
        private System.Windows.Forms.Label _lblFillClr;
        private System.Windows.Forms.Panel _pnlRevColor;
    }
}