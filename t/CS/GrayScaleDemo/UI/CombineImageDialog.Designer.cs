namespace GrayScaleDemo
{
    partial class CombineImageDialog
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
         this._gbDigitalSubtract = new System.Windows.Forms.GroupBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label6 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this._numHeight = new System.Windows.Forms.NumericUpDown();
         this._numWidth = new System.Windows.Forms.NumericUpDown();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this._numDestY = new System.Windows.Forms.NumericUpDown();
         this._numDestX = new System.Windows.Forms.NumericUpDown();
         this._gbMaskStratPoint = new System.Windows.Forms.GroupBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._numMaskY = new System.Windows.Forms.NumericUpDown();
         this._numMaskX = new System.Windows.Forms.NumericUpDown();
         this._cmbCombiningOperation = new System.Windows.Forms.ComboBox();
         this._lblCombiningOperation = new System.Windows.Forms.Label();
         this._cmbMaskImage = new System.Windows.Forms.ComboBox();
         this._lblMaskImage = new System.Windows.Forms.Label();
         this._gbDigitalSubtract.SuspendLayout();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
         this.groupBox2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numDestY)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numDestX)).BeginInit();
         this._gbMaskStratPoint.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numMaskY)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMaskX)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(554, 297);
         this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(68, 22);
         this._btnCancel.TabIndex = 14;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(482, 297);
         this._btnOk.Margin = new System.Windows.Forms.Padding(2);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(68, 22);
         this._btnOk.TabIndex = 13;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _gbDigitalSubtract
         // 
         this._gbDigitalSubtract.Controls.Add(this.groupBox1);
         this._gbDigitalSubtract.Controls.Add(this.groupBox2);
         this._gbDigitalSubtract.Controls.Add(this._gbMaskStratPoint);
         this._gbDigitalSubtract.Controls.Add(this._cmbCombiningOperation);
         this._gbDigitalSubtract.Controls.Add(this._lblCombiningOperation);
         this._gbDigitalSubtract.Controls.Add(this._cmbMaskImage);
         this._gbDigitalSubtract.Controls.Add(this._lblMaskImage);
         this._gbDigitalSubtract.Location = new System.Drawing.Point(5, 3);
         this._gbDigitalSubtract.Name = "_gbDigitalSubtract";
         this._gbDigitalSubtract.Size = new System.Drawing.Size(617, 289);
         this._gbDigitalSubtract.TabIndex = 12;
         this._gbDigitalSubtract.TabStop = false;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this._numHeight);
         this.groupBox1.Controls.Add(this._numWidth);
         this.groupBox1.Location = new System.Drawing.Point(22, 226);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(261, 52);
         this.groupBox1.TabIndex = 9;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Destination Rectangle :";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(132, 26);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(44, 13);
         this.label6.TabIndex = 7;
         this.label6.Text = "Height :";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(9, 26);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(41, 13);
         this.label5.TabIndex = 6;
         this.label5.Text = "Width :";
         // 
         // _numHeight
         // 
         this._numHeight.Location = new System.Drawing.Point(179, 24);
         this._numHeight.Name = "_numHeight";
         this._numHeight.Size = new System.Drawing.Size(72, 20);
         this._numHeight.TabIndex = 5;
         // 
         // _numWidth
         // 
         this._numWidth.Location = new System.Drawing.Point(50, 24);
         this._numWidth.Name = "_numWidth";
         this._numWidth.Size = new System.Drawing.Size(72, 20);
         this._numWidth.TabIndex = 4;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.label4);
         this.groupBox2.Controls.Add(this.label2);
         this.groupBox2.Controls.Add(this._numDestY);
         this.groupBox2.Controls.Add(this._numDestX);
         this.groupBox2.Location = new System.Drawing.Point(22, 163);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(261, 52);
         this.groupBox2.TabIndex = 8;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Destination Image Start Point :";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(146, 26);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(20, 13);
         this.label4.TabIndex = 5;
         this.label4.Text = "Y :";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(15, 26);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(20, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "X :";
         // 
         // _numDestY
         // 
         this._numDestY.Location = new System.Drawing.Point(174, 24);
         this._numDestY.Name = "_numDestY";
         this._numDestY.Size = new System.Drawing.Size(72, 20);
         this._numDestY.TabIndex = 3;
         this._numDestY.ValueChanged += new System.EventHandler(this._num_ValueChanged);
         // 
         // _numDestX
         // 
         this._numDestX.Location = new System.Drawing.Point(43, 24);
         this._numDestX.Name = "_numDestX";
         this._numDestX.Size = new System.Drawing.Size(72, 20);
         this._numDestX.TabIndex = 2;
         this._numDestX.ValueChanged += new System.EventHandler(this._num_ValueChanged);
         // 
         // _gbMaskStratPoint
         // 
         this._gbMaskStratPoint.Controls.Add(this.label3);
         this._gbMaskStratPoint.Controls.Add(this.label1);
         this._gbMaskStratPoint.Controls.Add(this._numMaskY);
         this._gbMaskStratPoint.Controls.Add(this._numMaskX);
         this._gbMaskStratPoint.Location = new System.Drawing.Point(22, 96);
         this._gbMaskStratPoint.Name = "_gbMaskStratPoint";
         this._gbMaskStratPoint.Size = new System.Drawing.Size(261, 52);
         this._gbMaskStratPoint.TabIndex = 7;
         this._gbMaskStratPoint.TabStop = false;
         this._gbMaskStratPoint.Text = "Mask Image Start Point :";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(146, 26);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(20, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Y :";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(15, 26);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(20, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "X :";
         // 
         // _numMaskY
         // 
         this._numMaskY.Location = new System.Drawing.Point(174, 24);
         this._numMaskY.Name = "_numMaskY";
         this._numMaskY.Size = new System.Drawing.Size(72, 20);
         this._numMaskY.TabIndex = 1;
         this._numMaskY.ValueChanged += new System.EventHandler(this._num_ValueChanged);
         // 
         // _numMaskX
         // 
         this._numMaskX.Location = new System.Drawing.Point(43, 24);
         this._numMaskX.Name = "_numMaskX";
         this._numMaskX.Size = new System.Drawing.Size(72, 20);
         this._numMaskX.TabIndex = 0;
         this._numMaskX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numMaskX.ValueChanged += new System.EventHandler(this._num_ValueChanged);
         // 
         // _cmbCombiningOperation
         // 
         this._cmbCombiningOperation.FormattingEnabled = true;
         this._cmbCombiningOperation.Items.AddRange(new object[] {
            "Or ",
            "Xor ",
            "Add",
            "SubtractSource",
            "SubtractDestination",
            "Multiply",
            "DivideSource ",
            "DivideDestination ",
            "Average ",
            "Minimum ",
            "Maximum"});
         this._cmbCombiningOperation.Location = new System.Drawing.Point(159, 69);
         this._cmbCombiningOperation.Name = "_cmbCombiningOperation";
         this._cmbCombiningOperation.Size = new System.Drawing.Size(125, 21);
         this._cmbCombiningOperation.TabIndex = 6;
         // 
         // _lblCombiningOperation
         // 
         this._lblCombiningOperation.AutoSize = true;
         this._lblCombiningOperation.Location = new System.Drawing.Point(19, 69);
         this._lblCombiningOperation.Name = "_lblCombiningOperation";
         this._lblCombiningOperation.Size = new System.Drawing.Size(111, 13);
         this._lblCombiningOperation.TabIndex = 5;
         this._lblCombiningOperation.Text = "Combining Operation :";
         // 
         // _cmbMaskImage
         // 
         this._cmbMaskImage.FormattingEnabled = true;
         this._cmbMaskImage.Location = new System.Drawing.Point(22, 38);
         this._cmbMaskImage.Name = "_cmbMaskImage";
         this._cmbMaskImage.Size = new System.Drawing.Size(589, 21);
         this._cmbMaskImage.TabIndex = 4;
         this._cmbMaskImage.SelectedIndexChanged += new System.EventHandler(this._cmbMaskImage_SelectedIndexChanged);
         // 
         // _lblMaskImage
         // 
         this._lblMaskImage.AutoSize = true;
         this._lblMaskImage.Location = new System.Drawing.Point(19, 22);
         this._lblMaskImage.Name = "_lblMaskImage";
         this._lblMaskImage.Size = new System.Drawing.Size(71, 13);
         this._lblMaskImage.TabIndex = 3;
         this._lblMaskImage.Text = "Mask Image :";
         // 
         // CombineImageDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(634, 326);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbDigitalSubtract);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CombineImageDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Combine Image";
         this.Load += new System.EventHandler(this.CombineImageDialog_Load);
         this._gbDigitalSubtract.ResumeLayout(false);
         this._gbDigitalSubtract.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numDestY)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numDestX)).EndInit();
         this._gbMaskStratPoint.ResumeLayout(false);
         this._gbMaskStratPoint.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numMaskY)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMaskX)).EndInit();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.GroupBox _gbDigitalSubtract;
        private System.Windows.Forms.ComboBox _cmbMaskImage;
        private System.Windows.Forms.Label _lblMaskImage;
        private System.Windows.Forms.ComboBox _cmbCombiningOperation;
        private System.Windows.Forms.Label _lblCombiningOperation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox _gbMaskStratPoint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown _numHeight;
        private System.Windows.Forms.NumericUpDown _numWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _numDestY;
        private System.Windows.Forms.NumericUpDown _numDestX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _numMaskY;
        private System.Windows.Forms.NumericUpDown _numMaskX;

    }
}