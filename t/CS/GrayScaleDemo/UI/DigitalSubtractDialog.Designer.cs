namespace GrayScaleDemo
{
    partial class DigitalSubtractDialog
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
         this._gbDigitalSubtract = new System.Windows.Forms.GroupBox();
         this._cmbMaskImage = new System.Windows.Forms.ComboBox();
         this._lblMaskImage = new System.Windows.Forms.Label();
         this._cbOptimizeRange = new System.Windows.Forms.CheckBox();
         this._cbContrastEnhancement = new System.Windows.Forms.CheckBox();
         this._lblFlags = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbDigitalSubtract.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbDigitalSubtract
         // 
         this._gbDigitalSubtract.Controls.Add(this._cmbMaskImage);
         this._gbDigitalSubtract.Controls.Add(this._lblMaskImage);
         this._gbDigitalSubtract.Controls.Add(this._cbOptimizeRange);
         this._gbDigitalSubtract.Controls.Add(this._cbContrastEnhancement);
         this._gbDigitalSubtract.Controls.Add(this._lblFlags);
         this._gbDigitalSubtract.Location = new System.Drawing.Point(6, 9);
         this._gbDigitalSubtract.Name = "_gbDigitalSubtract";
         this._gbDigitalSubtract.Size = new System.Drawing.Size(860, 98);
         this._gbDigitalSubtract.TabIndex = 0;
         this._gbDigitalSubtract.TabStop = false;
         // 
         // _cmbMaskImage
         // 
         this._cmbMaskImage.FormattingEnabled = true;
         this._cmbMaskImage.Location = new System.Drawing.Point(83, 19);
         this._cmbMaskImage.Name = "_cmbMaskImage";
         this._cmbMaskImage.Size = new System.Drawing.Size(771, 21);
         this._cmbMaskImage.TabIndex = 4;
         // 
         // _lblMaskImage
         // 
         this._lblMaskImage.AutoSize = true;
         this._lblMaskImage.Location = new System.Drawing.Point(6, 22);
         this._lblMaskImage.Name = "_lblMaskImage";
         this._lblMaskImage.Size = new System.Drawing.Size(71, 13);
         this._lblMaskImage.TabIndex = 3;
         this._lblMaskImage.Text = "Mask Image :";
         // 
         // _cbOptimizeRange
         // 
         this._cbOptimizeRange.AutoSize = true;
         this._cbOptimizeRange.Location = new System.Drawing.Point(83, 75);
         this._cbOptimizeRange.Name = "_cbOptimizeRange";
         this._cbOptimizeRange.Size = new System.Drawing.Size(101, 17);
         this._cbOptimizeRange.TabIndex = 2;
         this._cbOptimizeRange.Text = "Optimize Range";
         this._cbOptimizeRange.UseVisualStyleBackColor = true;
         // 
         // _cbContrastEnhancement
         // 
         this._cbContrastEnhancement.AutoSize = true;
         this._cbContrastEnhancement.Location = new System.Drawing.Point(83, 52);
         this._cbContrastEnhancement.Name = "_cbContrastEnhancement";
         this._cbContrastEnhancement.Size = new System.Drawing.Size(134, 17);
         this._cbContrastEnhancement.TabIndex = 1;
         this._cbContrastEnhancement.Text = "Contrast Enhancement";
         this._cbContrastEnhancement.UseVisualStyleBackColor = true;
         // 
         // _lblFlags
         // 
         this._lblFlags.AutoSize = true;
         this._lblFlags.Location = new System.Drawing.Point(6, 56);
         this._lblFlags.Name = "_lblFlags";
         this._lblFlags.Size = new System.Drawing.Size(38, 13);
         this._lblFlags.TabIndex = 0;
         this._lblFlags.Text = "Flags :";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(798, 118);
         this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(68, 22);
         this._btnCancel.TabIndex = 11;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(726, 118);
         this._btnOk.Margin = new System.Windows.Forms.Padding(2);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(68, 22);
         this._btnOk.TabIndex = 10;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // DigitalSubtractDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(878, 149);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbDigitalSubtract);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "DigitalSubtractDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Digital Subtract";
         this.Load += new System.EventHandler(this.DigitalSubtractDialog_Load);
         this._gbDigitalSubtract.ResumeLayout(false);
         this._gbDigitalSubtract.PerformLayout();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbDigitalSubtract;
        private System.Windows.Forms.ComboBox _cmbMaskImage;
        private System.Windows.Forms.Label _lblMaskImage;
        private System.Windows.Forms.CheckBox _cbOptimizeRange;
        private System.Windows.Forms.CheckBox _cbContrastEnhancement;
        private System.Windows.Forms.Label _lblFlags;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
    }
}