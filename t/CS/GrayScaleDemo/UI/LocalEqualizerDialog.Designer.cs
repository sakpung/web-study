namespace GrayScaleDemo
{
    partial class LocalEqualizerDialog
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
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._gbOptions = new System.Windows.Forms.GroupBox();
            this._numSmooth = new System.Windows.Forms.NumericUpDown();
            this._numHeightExt = new System.Windows.Forms.NumericUpDown();
            this._numWidthExt = new System.Windows.Forms.NumericUpDown();
            this._numHeight = new System.Windows.Forms.NumericUpDown();
            this._numWidth = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._cbEqualizeType = new System.Windows.Forms.ComboBox();
            this._lblColorSpace = new System.Windows.Forms.Label();
            this._gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numSmooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numHeightExt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numWidthExt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnCancel.Location = new System.Drawing.Point(307, 68);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(68, 22);
            this._btnCancel.TabIndex = 8;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnOk.Location = new System.Drawing.Point(307, 38);
            this._btnOk.Margin = new System.Windows.Forms.Padding(2);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(68, 22);
            this._btnOk.TabIndex = 7;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _gbOptions
            // 
            this._gbOptions.Controls.Add(this._numSmooth);
            this._gbOptions.Controls.Add(this._numHeightExt);
            this._gbOptions.Controls.Add(this._numWidthExt);
            this._gbOptions.Controls.Add(this._numHeight);
            this._gbOptions.Controls.Add(this._numWidth);
            this._gbOptions.Controls.Add(this.label5);
            this._gbOptions.Controls.Add(this.label4);
            this._gbOptions.Controls.Add(this.label3);
            this._gbOptions.Controls.Add(this.label2);
            this._gbOptions.Controls.Add(this.label1);
            this._gbOptions.Controls.Add(this._cbEqualizeType);
            this._gbOptions.Controls.Add(this._lblColorSpace);
            this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._gbOptions.Location = new System.Drawing.Point(5, -1);
            this._gbOptions.Margin = new System.Windows.Forms.Padding(2);
            this._gbOptions.Name = "_gbOptions";
            this._gbOptions.Padding = new System.Windows.Forms.Padding(2);
            this._gbOptions.Size = new System.Drawing.Size(298, 190);
            this._gbOptions.TabIndex = 6;
            this._gbOptions.TabStop = false;
            // 
            // _numSmooth
            // 
            this._numSmooth.Location = new System.Drawing.Point(131, 128);
            this._numSmooth.Margin = new System.Windows.Forms.Padding(2);
            this._numSmooth.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this._numSmooth.Name = "_numSmooth";
            this._numSmooth.Size = new System.Drawing.Size(116, 20);
            this._numSmooth.TabIndex = 11;
            // 
            // _numHeightExt
            // 
            this._numHeightExt.Location = new System.Drawing.Point(131, 97);
            this._numHeightExt.Margin = new System.Windows.Forms.Padding(2);
            this._numHeightExt.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numHeightExt.Name = "_numHeightExt";
            this._numHeightExt.Size = new System.Drawing.Size(116, 20);
            this._numHeightExt.TabIndex = 10;
            // 
            // _numWidthExt
            // 
            this._numWidthExt.Location = new System.Drawing.Point(131, 71);
            this._numWidthExt.Margin = new System.Windows.Forms.Padding(2);
            this._numWidthExt.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numWidthExt.Name = "_numWidthExt";
            this._numWidthExt.Size = new System.Drawing.Size(116, 20);
            this._numWidthExt.TabIndex = 9;
            // 
            // _numHeight
            // 
            this._numHeight.Location = new System.Drawing.Point(131, 43);
            this._numHeight.Margin = new System.Windows.Forms.Padding(2);
            this._numHeight.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numHeight.Name = "_numHeight";
            this._numHeight.Size = new System.Drawing.Size(116, 20);
            this._numHeight.TabIndex = 8;
            // 
            // _numWidth
            // 
            this._numWidth.Location = new System.Drawing.Point(131, 15);
            this._numWidth.Margin = new System.Windows.Forms.Padding(2);
            this._numWidth.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numWidth.Name = "_numWidth";
            this._numWidth.Size = new System.Drawing.Size(116, 20);
            this._numWidth.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(11, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Smooth ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(11, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "HeightExtension ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(11, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "WidthExtension";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(11, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cbEqualizeType
            // 
            this._cbEqualizeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbEqualizeType.FormattingEnabled = true;
            this._cbEqualizeType.Location = new System.Drawing.Point(131, 161);
            this._cbEqualizeType.Margin = new System.Windows.Forms.Padding(2);
            this._cbEqualizeType.Name = "_cbEqualizeType";
            this._cbEqualizeType.Size = new System.Drawing.Size(152, 21);
            this._cbEqualizeType.TabIndex = 1;
            // 
            // _lblColorSpace
            // 
            this._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblColorSpace.Location = new System.Drawing.Point(11, 161);
            this._lblColorSpace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lblColorSpace.Name = "_lblColorSpace";
            this._lblColorSpace.Size = new System.Drawing.Size(81, 21);
            this._lblColorSpace.TabIndex = 0;
            this._lblColorSpace.Text = "Equalize Type";
            this._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LocalEqualizerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 198);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._gbOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocalEqualizerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Equalizer";
            this.Load += new System.EventHandler(this.LocalEqualizerDialog_Load);
            this._gbOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._numSmooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numHeightExt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numWidthExt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.GroupBox _gbOptions;
        private System.Windows.Forms.ComboBox _cbEqualizeType;
        private System.Windows.Forms.Label _lblColorSpace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _numSmooth;
        private System.Windows.Forms.NumericUpDown _numHeightExt;
        private System.Windows.Forms.NumericUpDown _numWidthExt;
        private System.Windows.Forms.NumericUpDown _numHeight;
        private System.Windows.Forms.NumericUpDown _numWidth;
    }
}