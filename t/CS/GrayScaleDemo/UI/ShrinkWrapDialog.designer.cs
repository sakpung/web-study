namespace GrayScaleDemo
{
    partial class ShrinkWrapDialog
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
            this._gbParameters = new System.Windows.Forms.GroupBox();
            this._cbType = new System.Windows.Forms.ComboBox();
            this._numThreshold = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._btnApply = new System.Windows.Forms.Button();
            this._cbCombine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._gbParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(168, 141);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 0;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _gbParameters
            // 
            this._gbParameters.Controls.Add(this._cbCombine);
            this._gbParameters.Controls.Add(this.label3);
            this._gbParameters.Controls.Add(this._cbType);
            this._gbParameters.Controls.Add(this._numThreshold);
            this._gbParameters.Controls.Add(this.label1);
            this._gbParameters.Controls.Add(this.label2);
            this._gbParameters.Location = new System.Drawing.Point(12, 8);
            this._gbParameters.Name = "_gbParameters";
            this._gbParameters.Size = new System.Drawing.Size(246, 127);
            this._gbParameters.TabIndex = 1;
            this._gbParameters.TabStop = false;
            this._gbParameters.Text = "Parameters";
            // 
            // _cbType
            // 
            this._cbType.FormattingEnabled = true;
            this._cbType.Items.AddRange(new object[] {
            "Circle",
            "Rectangle"});
            this._cbType.Location = new System.Drawing.Point(110, 53);
            this._cbType.Name = "_cbType";
            this._cbType.Size = new System.Drawing.Size(121, 21);
            this._cbType.TabIndex = 5;
            // 
            // _numThreshold
            // 
            this._numThreshold.Location = new System.Drawing.Point(111, 20);
            this._numThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numThreshold.Name = "_numThreshold";
            this._numThreshold.Size = new System.Drawing.Size(120, 20);
            this._numThreshold.TabIndex = 4;
            this._numThreshold.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Threshold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type";
            // 
            // _btnApply
            // 
            this._btnApply.Location = new System.Drawing.Point(22, 141);
            this._btnApply.Name = "_btnApply";
            this._btnApply.Size = new System.Drawing.Size(75, 23);
            this._btnApply.TabIndex = 2;
            this._btnApply.Text = "Apply";
            this._btnApply.UseVisualStyleBackColor = true;
            this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
            // 
            // _cbCombine
            // 
            this._cbCombine.FormattingEnabled = true;
            this._cbCombine.Items.AddRange(new object[] {
            "AND",
            "SET",
            "AND NOT BITMAP",
            "AND NOT RGN",
            "OR",
            "XOR",
            "SETNOT"});
            this._cbCombine.Location = new System.Drawing.Point(110, 90);
            this._cbCombine.Name = "_cbCombine";
            this._cbCombine.Size = new System.Drawing.Size(121, 21);
            this._cbCombine.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Combine";
            // 
            // ShrinkWrapDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 176);
            this.Controls.Add(this._btnApply);
            this.Controls.Add(this._gbParameters);
            this.Controls.Add(this._btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShrinkWrapDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shrink Wrap Tool";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShrinkWrapDialog_FormClosing);
            this._gbParameters.ResumeLayout(false);
            this._gbParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.GroupBox _gbParameters;
        private System.Windows.Forms.ComboBox _cbType;
        private System.Windows.Forms.NumericUpDown _numThreshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btnApply;
        private System.Windows.Forms.ComboBox _cbCombine;
        private System.Windows.Forms.Label label3;
    }
}