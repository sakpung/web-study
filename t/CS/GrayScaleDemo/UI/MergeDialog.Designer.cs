namespace GrayScaleDemo
{
    partial class MergeDialog
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
         this._cLbImages = new System.Windows.Forms.CheckedListBox();
         this._rbSCT = new System.Windows.Forms.RadioButton();
         this._rbYCRCB = new System.Windows.Forms.RadioButton();
         this._rbLAB = new System.Windows.Forms.RadioButton();
         this._rbXYZ = new System.Windows.Forms.RadioButton();
         this._rbYUV = new System.Windows.Forms.RadioButton();
         this._rbCMY = new System.Windows.Forms.RadioButton();
         this._rbHLS = new System.Windows.Forms.RadioButton();
         this._rbHSV = new System.Windows.Forms.RadioButton();
         this._rbCMYK = new System.Windows.Forms.RadioButton();
         this._rbRGB = new System.Windows.Forms.RadioButton();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gbMergeType = new System.Windows.Forms.GroupBox();
         this._gbMergeType.SuspendLayout();
         this.SuspendLayout();
         // 
         // _cLbImages
         // 
         this._cLbImages.FormattingEnabled = true;
         this._cLbImages.Location = new System.Drawing.Point(153, 16);
         this._cLbImages.Name = "_cLbImages";
         this._cLbImages.Size = new System.Drawing.Size(754, 244);
         this._cLbImages.TabIndex = 0;
         // 
         // _rbSCT
         // 
         this._rbSCT.AutoSize = true;
         this._rbSCT.Location = new System.Drawing.Point(22, 226);
         this._rbSCT.Name = "_rbSCT";
         this._rbSCT.Size = new System.Drawing.Size(46, 17);
         this._rbSCT.TabIndex = 9;
         this._rbSCT.TabStop = true;
         this._rbSCT.Text = "SCT";
         this._rbSCT.UseVisualStyleBackColor = true;
         this._rbSCT.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
         // 
         // _rbYCRCB
         // 
         this._rbYCRCB.AutoSize = true;
         this._rbYCRCB.Location = new System.Drawing.Point(21, 203);
         this._rbYCRCB.Name = "_rbYCRCB";
         this._rbYCRCB.Size = new System.Drawing.Size(61, 17);
         this._rbYCRCB.TabIndex = 8;
         this._rbYCRCB.TabStop = true;
         this._rbYCRCB.Text = "YCRCB";
         this._rbYCRCB.UseVisualStyleBackColor = true;
         this._rbYCRCB.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
         // 
         // _rbLAB
         // 
         this._rbLAB.AutoSize = true;
         this._rbLAB.Location = new System.Drawing.Point(21, 180);
         this._rbLAB.Name = "_rbLAB";
         this._rbLAB.Size = new System.Drawing.Size(48, 17);
         this._rbLAB.TabIndex = 7;
         this._rbLAB.TabStop = true;
         this._rbLAB.Text = "LAB ";
         this._rbLAB.UseVisualStyleBackColor = true;
         this._rbLAB.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
         // 
         // _rbXYZ
         // 
         this._rbXYZ.AutoSize = true;
         this._rbXYZ.Location = new System.Drawing.Point(21, 157);
         this._rbXYZ.Name = "_rbXYZ";
         this._rbXYZ.Size = new System.Drawing.Size(46, 17);
         this._rbXYZ.TabIndex = 6;
         this._rbXYZ.TabStop = true;
         this._rbXYZ.Text = "XYZ";
         this._rbXYZ.UseVisualStyleBackColor = true;
         this._rbXYZ.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
         // 
         // _rbYUV
         // 
         this._rbYUV.AutoSize = true;
         this._rbYUV.Location = new System.Drawing.Point(21, 134);
         this._rbYUV.Name = "_rbYUV";
         this._rbYUV.Size = new System.Drawing.Size(47, 17);
         this._rbYUV.TabIndex = 5;
         this._rbYUV.TabStop = true;
         this._rbYUV.Text = "YUV";
         this._rbYUV.UseVisualStyleBackColor = true;
         this._rbYUV.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
         // 
         // _rbCMY
         // 
         this._rbCMY.AutoSize = true;
         this._rbCMY.Location = new System.Drawing.Point(21, 111);
         this._rbCMY.Name = "_rbCMY";
         this._rbCMY.Size = new System.Drawing.Size(48, 17);
         this._rbCMY.TabIndex = 4;
         this._rbCMY.TabStop = true;
         this._rbCMY.Text = "CMY";
         this._rbCMY.UseVisualStyleBackColor = true;
         this._rbCMY.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
         // 
         // _rbHLS
         // 
         this._rbHLS.AutoSize = true;
         this._rbHLS.Location = new System.Drawing.Point(21, 88);
         this._rbHLS.Name = "_rbHLS";
         this._rbHLS.Size = new System.Drawing.Size(46, 17);
         this._rbHLS.TabIndex = 3;
         this._rbHLS.TabStop = true;
         this._rbHLS.Text = "HLS";
         this._rbHLS.UseVisualStyleBackColor = true;
         this._rbHLS.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
         // 
         // _rbHSV
         // 
         this._rbHSV.AutoSize = true;
         this._rbHSV.Location = new System.Drawing.Point(21, 65);
         this._rbHSV.Name = "_rbHSV";
         this._rbHSV.Size = new System.Drawing.Size(47, 17);
         this._rbHSV.TabIndex = 2;
         this._rbHSV.TabStop = true;
         this._rbHSV.Text = "HSV";
         this._rbHSV.UseVisualStyleBackColor = true;
         this._rbHSV.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
         // 
         // _rbCMYK
         // 
         this._rbCMYK.AutoSize = true;
         this._rbCMYK.Location = new System.Drawing.Point(21, 42);
         this._rbCMYK.Name = "_rbCMYK";
         this._rbCMYK.Size = new System.Drawing.Size(55, 17);
         this._rbCMYK.TabIndex = 1;
         this._rbCMYK.TabStop = true;
         this._rbCMYK.Text = "CMYK";
         this._rbCMYK.UseVisualStyleBackColor = true;
         this._rbCMYK.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
         // 
         // _rbRGB
         // 
         this._rbRGB.AutoSize = true;
         this._rbRGB.Location = new System.Drawing.Point(21, 19);
         this._rbRGB.Name = "_rbRGB";
         this._rbRGB.Size = new System.Drawing.Size(48, 17);
         this._rbRGB.TabIndex = 0;
         this._rbRGB.TabStop = true;
         this._rbRGB.Text = "RGB";
         this._rbRGB.UseVisualStyleBackColor = true;
         this._rbRGB.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(790, 267);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(56, 27);
         this._btnOk.TabIndex = 2;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.Location = new System.Drawing.Point(852, 267);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(55, 26);
         this._btnCancel.TabIndex = 3;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _gbMergeType
         // 
         this._gbMergeType.Controls.Add(this._rbRGB);
         this._gbMergeType.Controls.Add(this._rbSCT);
         this._gbMergeType.Controls.Add(this._rbHSV);
         this._gbMergeType.Controls.Add(this._rbHLS);
         this._gbMergeType.Controls.Add(this._rbYCRCB);
         this._gbMergeType.Controls.Add(this._rbCMYK);
         this._gbMergeType.Controls.Add(this._rbCMY);
         this._gbMergeType.Controls.Add(this._rbLAB);
         this._gbMergeType.Controls.Add(this._rbYUV);
         this._gbMergeType.Controls.Add(this._rbXYZ);
         this._gbMergeType.Location = new System.Drawing.Point(14, 10);
         this._gbMergeType.Name = "_gbMergeType";
         this._gbMergeType.Size = new System.Drawing.Size(123, 250);
         this._gbMergeType.TabIndex = 10;
         this._gbMergeType.TabStop = false;
         this._gbMergeType.Text = "Merge Type :";
         // 
         // MergeDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(919, 302);
         this.Controls.Add(this._gbMergeType);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._cLbImages);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MergeDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Merge";
         this.Load += new System.EventHandler(this.MergeDialog_Load);
         this._gbMergeType.ResumeLayout(false);
         this._gbMergeType.PerformLayout();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox _cLbImages;
        private System.Windows.Forms.RadioButton _rbCMY;
        private System.Windows.Forms.RadioButton _rbHLS;
        private System.Windows.Forms.RadioButton _rbHSV;
        private System.Windows.Forms.RadioButton _rbCMYK;
        private System.Windows.Forms.RadioButton _rbRGB;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.RadioButton _rbSCT;
        private System.Windows.Forms.RadioButton _rbYCRCB;
        private System.Windows.Forms.RadioButton _rbLAB;
        private System.Windows.Forms.RadioButton _rbXYZ;
        private System.Windows.Forms.RadioButton _rbYUV;
        private System.Windows.Forms.GroupBox _gbMergeType;
    }
}