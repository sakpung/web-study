namespace CSMasterFormsEditor.UI
{
    partial class OmrDetectionDialog
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
            this._btnOk = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._rbHighest = new System.Windows.Forms.RadioButton();
            this._rbHigh = new System.Windows.Forms.RadioButton();
            this._rbLow = new System.Windows.Forms.RadioButton();
            this._rbLowest = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnOk
            // 
            this._btnOk.Location = new System.Drawing.Point(12, 158);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(93, 29);
            this._btnOk.TabIndex = 0;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(123, 158);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(86, 28);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._rbHighest);
            this.groupBox1.Controls.Add(this._rbHigh);
            this.groupBox1.Controls.Add(this._rbLow);
            this.groupBox1.Controls.Add(this._rbLowest);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 126);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensitivity";
            // 
            // _rbHighest
            // 
            this._rbHighest.AutoSize = true;
            this._rbHighest.Location = new System.Drawing.Point(16, 94);
            this._rbHighest.Name = "_rbHighest";
            this._rbHighest.Size = new System.Drawing.Size(61, 17);
            this._rbHighest.TabIndex = 13;
            this._rbHighest.Text = "Highest";
            this._rbHighest.UseVisualStyleBackColor = true;
            this._rbHighest.CheckedChanged += new System.EventHandler(this._omrSensitivtyChecked);
            // 
            // _rbHigh
            // 
            this._rbHigh.AutoSize = true;
            this._rbHigh.Checked = true;
            this._rbHigh.Location = new System.Drawing.Point(16, 71);
            this._rbHigh.Name = "_rbHigh";
            this._rbHigh.Size = new System.Drawing.Size(47, 17);
            this._rbHigh.TabIndex = 12;
            this._rbHigh.TabStop = true;
            this._rbHigh.Text = "High";
            this._rbHigh.UseVisualStyleBackColor = true;
            this._rbHigh.CheckedChanged += new System.EventHandler(this._omrSensitivtyChecked);
            // 
            // _rbLow
            // 
            this._rbLow.AutoSize = true;
            this._rbLow.Location = new System.Drawing.Point(16, 48);
            this._rbLow.Name = "_rbLow";
            this._rbLow.Size = new System.Drawing.Size(45, 17);
            this._rbLow.TabIndex = 11;
            this._rbLow.Text = "Low";
            this._rbLow.UseVisualStyleBackColor = true;
            this._rbLow.CheckedChanged += new System.EventHandler(this._omrSensitivtyChecked);
            // 
            // _rbLowest
            // 
            this._rbLowest.AutoSize = true;
            this._rbLowest.Location = new System.Drawing.Point(16, 25);
            this._rbLowest.Name = "_rbLowest";
            this._rbLowest.Size = new System.Drawing.Size(59, 17);
            this._rbLowest.TabIndex = 10;
            this._rbLowest.Text = "Lowest";
            this._rbLowest.UseVisualStyleBackColor = true;
            this._rbLowest.CheckedChanged += new System.EventHandler(this._omrSensitivtyChecked);
            // 
            // OmrDetectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 200);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OmrDetectionDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OmrDetectionDialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton _rbHighest;
        private System.Windows.Forms.RadioButton _rbHigh;
        private System.Windows.Forms.RadioButton _rbLow;
        private System.Windows.Forms.RadioButton _rbLowest;
    }
}