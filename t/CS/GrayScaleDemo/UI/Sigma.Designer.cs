namespace GrayScaleDemo
{
    partial class SigmaDialog
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
            this._gbSigma = new System.Windows.Forms.GroupBox();
            this._numThreshold = new System.Windows.Forms.NumericUpDown();
            this._numSigma = new System.Windows.Forms.NumericUpDown();
            this._numDimension = new System.Windows.Forms.NumericUpDown();
            this._cbOutline = new System.Windows.Forms.CheckBox();
            this._lblThreshold = new System.Windows.Forms.Label();
            this._lblSigma = new System.Windows.Forms.Label();
            this._lblDimension = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._gbSigma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDimension)).BeginInit();
            this.SuspendLayout();
            // 
            // _gbSigma
            // 
            this._gbSigma.Controls.Add(this._numThreshold);
            this._gbSigma.Controls.Add(this._numSigma);
            this._gbSigma.Controls.Add(this._numDimension);
            this._gbSigma.Controls.Add(this._cbOutline);
            this._gbSigma.Controls.Add(this._lblThreshold);
            this._gbSigma.Controls.Add(this._lblSigma);
            this._gbSigma.Controls.Add(this._lblDimension);
            this._gbSigma.Location = new System.Drawing.Point(7, 4);
            this._gbSigma.Name = "_gbSigma";
            this._gbSigma.Size = new System.Drawing.Size(243, 126);
            this._gbSigma.TabIndex = 0;
            this._gbSigma.TabStop = false;
            // 
            // _numThreshold
            // 
            this._numThreshold.DecimalPlaces = 2;
            this._numThreshold.Location = new System.Drawing.Point(108, 73);
            this._numThreshold.Name = "_numThreshold";
            this._numThreshold.Size = new System.Drawing.Size(120, 20);
            this._numThreshold.TabIndex = 6;
            // 
            // _numSigma
            // 
            this._numSigma.Location = new System.Drawing.Point(108, 48);
            this._numSigma.Name = "_numSigma";
            this._numSigma.Size = new System.Drawing.Size(120, 20);
            this._numSigma.TabIndex = 5;
            // 
            // _numDimension
            // 
            this._numDimension.Location = new System.Drawing.Point(108, 23);
            this._numDimension.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._numDimension.Name = "_numDimension";
            this._numDimension.Size = new System.Drawing.Size(120, 20);
            this._numDimension.TabIndex = 4;
            this._numDimension.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // _cbOutline
            // 
            this._cbOutline.AutoSize = true;
            this._cbOutline.Location = new System.Drawing.Point(20, 100);
            this._cbOutline.Name = "_cbOutline";
            this._cbOutline.Size = new System.Drawing.Size(59, 17);
            this._cbOutline.TabIndex = 3;
            this._cbOutline.Text = "Outline";
            this._cbOutline.UseVisualStyleBackColor = true;
            // 
            // _lblThreshold
            // 
            this._lblThreshold.AutoSize = true;
            this._lblThreshold.Location = new System.Drawing.Point(19, 75);
            this._lblThreshold.Name = "_lblThreshold";
            this._lblThreshold.Size = new System.Drawing.Size(60, 13);
            this._lblThreshold.TabIndex = 2;
            this._lblThreshold.Text = "Threshold :";
            // 
            // _lblSigma
            // 
            this._lblSigma.AutoSize = true;
            this._lblSigma.Location = new System.Drawing.Point(19, 50);
            this._lblSigma.Name = "_lblSigma";
            this._lblSigma.Size = new System.Drawing.Size(42, 13);
            this._lblSigma.TabIndex = 1;
            this._lblSigma.Text = "Sigma :";
            // 
            // _lblDimension
            // 
            this._lblDimension.AutoSize = true;
            this._lblDimension.Location = new System.Drawing.Point(19, 25);
            this._lblDimension.Name = "_lblDimension";
            this._lblDimension.Size = new System.Drawing.Size(62, 13);
            this._lblDimension.TabIndex = 0;
            this._lblDimension.Text = "Dimension :";
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnCancel.Location = new System.Drawing.Point(136, 135);
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
            this._btnOk.Location = new System.Drawing.Point(52, 135);
            this._btnOk.Margin = new System.Windows.Forms.Padding(2);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(68, 22);
            this._btnOk.TabIndex = 10;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // SigmaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 174);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._gbSigma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SigmaDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sigma";
            this.Load += new System.EventHandler(this.Sigma_Load);
            this._gbSigma.ResumeLayout(false);
            this._gbSigma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDimension)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbSigma;
        private System.Windows.Forms.CheckBox _cbOutline;
        private System.Windows.Forms.Label _lblThreshold;
        private System.Windows.Forms.Label _lblSigma;
        private System.Windows.Forms.Label _lblDimension;
        private System.Windows.Forms.NumericUpDown _numThreshold;
        private System.Windows.Forms.NumericUpDown _numSigma;
        private System.Windows.Forms.NumericUpDown _numDimension;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
    }
}