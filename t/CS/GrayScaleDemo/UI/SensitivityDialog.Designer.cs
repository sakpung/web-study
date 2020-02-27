namespace GrayScaleDemo
{
    partial class SensitivityDialog
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
            this._gbOptions = new System.Windows.Forms.GroupBox();
            this._numValue = new System.Windows.Forms.NumericUpDown();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numValue)).BeginInit();
            this.SuspendLayout();
            // 
            // _gbOptions
            // 
            this._gbOptions.Controls.Add(this._numValue);
            this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._gbOptions.Location = new System.Drawing.Point(4, 4);
            this._gbOptions.Margin = new System.Windows.Forms.Padding(2);
            this._gbOptions.Name = "_gbOptions";
            this._gbOptions.Padding = new System.Windows.Forms.Padding(2);
            this._gbOptions.Size = new System.Drawing.Size(144, 60);
            this._gbOptions.TabIndex = 6;
            this._gbOptions.TabStop = false;
            this._gbOptions.Text = "Sensitivity";
            // 
            // _numValue
            // 
            this._numValue.Location = new System.Drawing.Point(14, 30);
            this._numValue.Margin = new System.Windows.Forms.Padding(2);
            this._numValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numValue.Name = "_numValue";
            this._numValue.Size = new System.Drawing.Size(116, 20);
            this._numValue.TabIndex = 0;
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnCancel.Location = new System.Drawing.Point(152, 41);
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
            this._btnOk.Location = new System.Drawing.Point(152, 11);
            this._btnOk.Margin = new System.Windows.Forms.Padding(2);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(68, 22);
            this._btnOk.TabIndex = 7;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // SensitivityDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 77);
            this.Controls.Add(this._gbOptions);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SensitivityDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sensitivity";
            this.Load += new System.EventHandler(this.SensitivityDialog_Load);
            this._gbOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._numValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbOptions;
        private System.Windows.Forms.NumericUpDown _numValue;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
    }
}