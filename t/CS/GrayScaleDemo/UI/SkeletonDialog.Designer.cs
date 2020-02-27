namespace GrayScaleDemo
{
    partial class SkeletonDialog
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
            this._numThreshold = new System.Windows.Forms.NumericUpDown();
            this._lblThreshold = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._numThreshold);
            this.groupBox1.Controls.Add(this._lblThreshold);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // _numThreshold
            // 
            this._numThreshold.Location = new System.Drawing.Point(86, 19);
            this._numThreshold.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._numThreshold.Name = "_numThreshold";
            this._numThreshold.Size = new System.Drawing.Size(120, 20);
            this._numThreshold.TabIndex = 1;
            // 
            // _lblThreshold
            // 
            this._lblThreshold.AutoSize = true;
            this._lblThreshold.Location = new System.Drawing.Point(16, 21);
            this._lblThreshold.Name = "_lblThreshold";
            this._lblThreshold.Size = new System.Drawing.Size(60, 13);
            this._lblThreshold.TabIndex = 0;
            this._lblThreshold.Text = "Threshold :";
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnCancel.Location = new System.Drawing.Point(132, 64);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(68, 22);
            this._btnCancel.TabIndex = 17;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnOk.Location = new System.Drawing.Point(47, 64);
            this._btnOk.Margin = new System.Windows.Forms.Padding(2);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(68, 22);
            this._btnOk.TabIndex = 16;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // SkeletonDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 104);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SkeletonDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Skeleton";
            this.Load += new System.EventHandler(this.SkeletonDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown _numThreshold;
        private System.Windows.Forms.Label _lblThreshold;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
    }
}