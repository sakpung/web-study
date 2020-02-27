namespace Main3DDemo
{
    partial class SeriesTreatmentDialog
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
           this.groupBox1 = new System.Windows.Forms.GroupBox();
           this.radioCrop = new System.Windows.Forms.RadioButton();
           this.radioResize = new System.Windows.Forms.RadioButton();
           this.label2 = new System.Windows.Forms.Label();
           this.label1 = new System.Windows.Forms.Label();
           this._lblFramesInfo = new System.Windows.Forms.Label();
           this._btnOK = new System.Windows.Forms.Button();
           this._btnCancel = new System.Windows.Forms.Button();
           this.groupResize = new System.Windows.Forms.GroupBox();
           this.label6 = new System.Windows.Forms.Label();
           this.label5 = new System.Windows.Forms.Label();
           this.label3 = new System.Windows.Forms.Label();
           this.groupBox2 = new System.Windows.Forms.GroupBox();
           this.label10 = new System.Windows.Forms.Label();
           this.label11 = new System.Windows.Forms.Label();
           this.label7 = new System.Windows.Forms.Label();
           this.label8 = new System.Windows.Forms.Label();
           this._txtCropHeightTo = new Main3DDemo.NumericTextBox();
           this._txtCropWidthTo = new Main3DDemo.NumericTextBox();
           this._txtCropHeightFrom = new Main3DDemo.NumericTextBox();
           this._txtCropWidthFrom = new Main3DDemo.NumericTextBox();
           this._txtHeight = new Main3DDemo.NumericTextBox();
           this._txtWidth = new Main3DDemo.NumericTextBox();
           this.groupBox1.SuspendLayout();
           this.groupResize.SuspendLayout();
           this.groupBox2.SuspendLayout();
           this.SuspendLayout();
           // 
           // groupBox1
           // 
           this.groupBox1.Controls.Add(this.radioCrop);
           this.groupBox1.Controls.Add(this.radioResize);
           this.groupBox1.Controls.Add(this.label2);
           this.groupBox1.Controls.Add(this.label1);
           this.groupBox1.Controls.Add(this._lblFramesInfo);
           this.groupBox1.Location = new System.Drawing.Point(12, 12);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Size = new System.Drawing.Size(365, 191);
           this.groupBox1.TabIndex = 0;
           this.groupBox1.TabStop = false;
           this.groupBox1.Text = "&Resolving the problem";
           // 
           // radioCrop
           // 
           this.radioCrop.AutoSize = true;
           this.radioCrop.Checked = true;
           this.radioCrop.Location = new System.Drawing.Point(12, 163);
           this.radioCrop.Name = "radioCrop";
           this.radioCrop.Size = new System.Drawing.Size(110, 17);
           this.radioCrop.TabIndex = 44;
           this.radioCrop.TabStop = true;
           this.radioCrop.Text = "&Crop each frames";
           this.radioCrop.UseVisualStyleBackColor = true;
           this.radioCrop.CheckedChanged += new System.EventHandler(this.radioCrop_CheckedChanged);
           // 
           // radioResize
           // 
           this.radioResize.AutoSize = true;
           this.radioResize.Location = new System.Drawing.Point(12, 136);
           this.radioResize.Name = "radioResize";
           this.radioResize.Size = new System.Drawing.Size(115, 17);
           this.radioResize.TabIndex = 43;
           this.radioResize.Text = "&Resize each Frame";
           this.radioResize.UseVisualStyleBackColor = true;
           this.radioResize.CheckedChanged += new System.EventHandler(this.radioResize_CheckedChanged);
           // 
           // label2
           // 
           this.label2.Location = new System.Drawing.Point(9, 110);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(253, 23);
           this.label2.TabIndex = 42;
           this.label2.Text = "What would you like to do?";
           // 
           // label1
           // 
           this.label1.Location = new System.Drawing.Point(9, 67);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(274, 32);
           this.label1.TabIndex = 41;
           this.label1.Text = "You can solve this by scaling down the series frames by either resizing or croppi" +
               "ng";
           // 
           // _lblFramesInfo
           // 
           this._lblFramesInfo.Location = new System.Drawing.Point(9, 22);
           this._lblFramesInfo.Name = "_lblFramesInfo";
           this._lblFramesInfo.Size = new System.Drawing.Size(333, 45);
           this._lblFramesInfo.TabIndex = 38;
           this._lblFramesInfo.Text = "The series you are trying to load consist of frames with dimensions larger than w" +
               "hat the current graphics  card could handle ";
           // 
           // _btnOK
           // 
           this._btnOK.Location = new System.Drawing.Point(97, 409);
           this._btnOK.Name = "_btnOK";
           this._btnOK.Size = new System.Drawing.Size(90, 27);
           this._btnOK.TabIndex = 34;
           this._btnOK.Text = "&OK";
           this._btnOK.UseVisualStyleBackColor = true;
           this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
           // 
           // _btnCancel
           // 
           this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this._btnCancel.Location = new System.Drawing.Point(193, 409);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(90, 27);
           this._btnCancel.TabIndex = 35;
           this._btnCancel.Text = "&Cancel";
           this._btnCancel.UseVisualStyleBackColor = true;
           // 
           // groupResize
           // 
           this.groupResize.Controls.Add(this._txtHeight);
           this.groupResize.Controls.Add(this._txtWidth);
           this.groupResize.Controls.Add(this.label6);
           this.groupResize.Controls.Add(this.label5);
           this.groupResize.Controls.Add(this.label3);
           this.groupResize.Location = new System.Drawing.Point(12, 205);
           this.groupResize.Name = "groupResize";
           this.groupResize.Size = new System.Drawing.Size(365, 98);
           this.groupResize.TabIndex = 46;
           this.groupResize.TabStop = false;
           this.groupResize.Tag = "";
           this.groupResize.Text = "Resize &Parameters";
           // 
           // label6
           // 
           this.label6.Location = new System.Drawing.Point(13, 58);
           this.label6.Name = "label6";
           this.label6.Size = new System.Drawing.Size(89, 18);
           this.label6.TabIndex = 46;
           this.label6.Text = "Resize &height to";
           // 
           // label5
           // 
           this.label5.Location = new System.Drawing.Point(13, 31);
           this.label5.Name = "label5";
           this.label5.Size = new System.Drawing.Size(81, 18);
           this.label5.TabIndex = 45;
           this.label5.Text = "Resize &width to";
           // 
           // label3
           // 
           this.label3.Location = new System.Drawing.Point(13, 26);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(89, 23);
           this.label3.TabIndex = 45;
           this.label3.Text = "&";
           // 
           // groupBox2
           // 
           this.groupBox2.Controls.Add(this._txtCropHeightTo);
           this.groupBox2.Controls.Add(this._txtCropWidthTo);
           this.groupBox2.Controls.Add(this.label10);
           this.groupBox2.Controls.Add(this.label11);
           this.groupBox2.Controls.Add(this._txtCropHeightFrom);
           this.groupBox2.Controls.Add(this._txtCropWidthFrom);
           this.groupBox2.Controls.Add(this.label7);
           this.groupBox2.Controls.Add(this.label8);
           this.groupBox2.Location = new System.Drawing.Point(12, 305);
           this.groupBox2.Name = "groupBox2";
           this.groupBox2.Size = new System.Drawing.Size(365, 98);
           this.groupBox2.TabIndex = 49;
           this.groupBox2.TabStop = false;
           this.groupBox2.Tag = "";
           this.groupBox2.Text = "Crop &Parameters";
           // 
           // label10
           // 
           this.label10.Location = new System.Drawing.Point(202, 31);
           this.label10.Name = "label10";
           this.label10.Size = new System.Drawing.Size(24, 18);
           this.label10.TabIndex = 50;
           this.label10.Text = "&To";
           // 
           // label11
           // 
           this.label11.Location = new System.Drawing.Point(202, 61);
           this.label11.Name = "label11";
           this.label11.Size = new System.Drawing.Size(24, 18);
           this.label11.TabIndex = 49;
           this.label11.Text = "T&o";
           // 
           // label7
           // 
           this.label7.Location = new System.Drawing.Point(12, 61);
           this.label7.Name = "label7";
           this.label7.Size = new System.Drawing.Size(125, 18);
           this.label7.TabIndex = 46;
           this.label7.Text = "Crop Image &height from";
           // 
           // label8
           // 
           this.label8.Location = new System.Drawing.Point(12, 34);
           this.label8.Name = "label8";
           this.label8.Size = new System.Drawing.Size(118, 18);
           this.label8.TabIndex = 45;
           this.label8.Text = "Crop Image &width from";
           // 
           // _txtCropHeightTo
           // 
           this._txtCropHeightTo.Location = new System.Drawing.Point(232, 60);
           this._txtCropHeightTo.MaximumAllowed = 1000;
           this._txtCropHeightTo.MinimumAllowed = -1000;
           this._txtCropHeightTo.Name = "_txtCropHeightTo";
           this._txtCropHeightTo.Size = new System.Drawing.Size(49, 20);
           this._txtCropHeightTo.TabIndex = 52;
           this._txtCropHeightTo.Text = "0";
           this._txtCropHeightTo.Value = 0;
           this._txtCropHeightTo.TextChanged += new System.EventHandler(this._txtCropHeightTo_TextChanged);
           // 
           // _txtCropWidthTo
           // 
           this._txtCropWidthTo.Location = new System.Drawing.Point(232, 28);
           this._txtCropWidthTo.MaximumAllowed = 1000;
           this._txtCropWidthTo.MinimumAllowed = -1000;
           this._txtCropWidthTo.Name = "_txtCropWidthTo";
           this._txtCropWidthTo.Size = new System.Drawing.Size(48, 20);
           this._txtCropWidthTo.TabIndex = 51;
           this._txtCropWidthTo.Text = "0";
           this._txtCropWidthTo.Value = 0;
           this._txtCropWidthTo.TextChanged += new System.EventHandler(this._txtCropWidthTo_TextChanged);
           // 
           // _txtCropHeightFrom
           // 
           this._txtCropHeightFrom.Location = new System.Drawing.Point(137, 61);
           this._txtCropHeightFrom.MaximumAllowed = 1000;
           this._txtCropHeightFrom.MinimumAllowed = -1000;
           this._txtCropHeightFrom.Name = "_txtCropHeightFrom";
           this._txtCropHeightFrom.Size = new System.Drawing.Size(49, 20);
           this._txtCropHeightFrom.TabIndex = 48;
           this._txtCropHeightFrom.Text = "0";
           this._txtCropHeightFrom.Value = 0;
           this._txtCropHeightFrom.TextChanged += new System.EventHandler(this._txtCropHeightFrom_TextChanged);
           // 
           // _txtCropWidthFrom
           // 
           this._txtCropWidthFrom.Location = new System.Drawing.Point(137, 29);
           this._txtCropWidthFrom.MaximumAllowed = 1000;
           this._txtCropWidthFrom.MinimumAllowed = -1000;
           this._txtCropWidthFrom.Name = "_txtCropWidthFrom";
           this._txtCropWidthFrom.Size = new System.Drawing.Size(48, 20);
           this._txtCropWidthFrom.TabIndex = 47;
           this._txtCropWidthFrom.Text = "0";
           this._txtCropWidthFrom.Value = 0;
           this._txtCropWidthFrom.TextChanged += new System.EventHandler(this._txtCropWidthFrom_TextChanged);
           // 
           // _txtHeight
           // 
           this._txtHeight.Location = new System.Drawing.Point(108, 58);
           this._txtHeight.MaximumAllowed = 1000;
           this._txtHeight.MinimumAllowed = -1000;
           this._txtHeight.Name = "_txtHeight";
           this._txtHeight.Size = new System.Drawing.Size(49, 20);
           this._txtHeight.TabIndex = 48;
           this._txtHeight.Text = "0";
           this._txtHeight.Value = 0;
           this._txtHeight.TextChanged += new System.EventHandler(this._txtHeight_TextChanged);
           // 
           // _txtWidth
           // 
           this._txtWidth.Location = new System.Drawing.Point(108, 26);
           this._txtWidth.MaximumAllowed = 1000;
           this._txtWidth.MinimumAllowed = -1000;
           this._txtWidth.Name = "_txtWidth";
           this._txtWidth.Size = new System.Drawing.Size(48, 20);
           this._txtWidth.TabIndex = 47;
           this._txtWidth.Text = "0";
           this._txtWidth.Value = 0;
           this._txtWidth.TextChanged += new System.EventHandler(this._txtWidth_TextChanged);
           // 
           // SeriesTreatmentDialog
           // 
           this.AcceptButton = this._btnOK;
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.CancelButton = this._btnCancel;
           this.ClientSize = new System.Drawing.Size(388, 441);
           this.Controls.Add(this.groupBox2);
           this.Controls.Add(this.groupResize);
           this.Controls.Add(this._btnOK);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this.groupBox1);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "SeriesTreatmentDialog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Series frame is too large";
           this.groupBox1.ResumeLayout(false);
           this.groupBox1.PerformLayout();
           this.groupResize.ResumeLayout(false);
           this.groupResize.PerformLayout();
           this.groupBox2.ResumeLayout(false);
           this.groupBox2.PerformLayout();
           this.ResumeLayout(false);

        }

        #endregion

       private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnOK;
       private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label _lblFramesInfo;
       private System.Windows.Forms.Label label2;
       private System.Windows.Forms.Label label1;
       private System.Windows.Forms.RadioButton radioCrop;
       private System.Windows.Forms.RadioButton radioResize;
       private System.Windows.Forms.GroupBox groupResize;
       private System.Windows.Forms.Label label3;
       private NumericTextBox _txtHeight;
       private NumericTextBox _txtWidth;
       private System.Windows.Forms.Label label6;
       private System.Windows.Forms.Label label5;
       private System.Windows.Forms.GroupBox groupBox2;
       private NumericTextBox _txtCropHeightTo;
       private NumericTextBox _txtCropWidthTo;
       private System.Windows.Forms.Label label10;
       private System.Windows.Forms.Label label11;
       private NumericTextBox _txtCropHeightFrom;
       private NumericTextBox _txtCropWidthFrom;
       private System.Windows.Forms.Label label7;
       private System.Windows.Forms.Label label8;
    }
}