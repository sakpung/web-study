namespace GrayScaleDemo
{
    partial class AdaptiveContrastDialog
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
            this._cmbAdaptiveType = new System.Windows.Forms.ComboBox();
            this._lblColorSpace = new System.Windows.Forms.Label();
            this._lblEnd = new System.Windows.Forms.Label();
            this._lblStart = new System.Windows.Forms.Label();
            this._numDimension = new System.Windows.Forms.NumericUpDown();
            this._numAmount = new System.Windows.Forms.NumericUpDown();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numDimension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // _gbOptions
            // 
            this._gbOptions.Controls.Add(this._cmbAdaptiveType);
            this._gbOptions.Controls.Add(this._lblColorSpace);
            this._gbOptions.Controls.Add(this._lblEnd);
            this._gbOptions.Controls.Add(this._lblStart);
            this._gbOptions.Controls.Add(this._numDimension);
            this._gbOptions.Controls.Add(this._numAmount);
            this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._gbOptions.Location = new System.Drawing.Point(4, -3);
            this._gbOptions.Margin = new System.Windows.Forms.Padding(2);
            this._gbOptions.Name = "_gbOptions";
            this._gbOptions.Padding = new System.Windows.Forms.Padding(2);
            this._gbOptions.Size = new System.Drawing.Size(252, 121);
            this._gbOptions.TabIndex = 9;
            this._gbOptions.TabStop = false;
            // 
            // _cmbAdaptiveType
            // 
            this._cmbAdaptiveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbAdaptiveType.FormattingEnabled = true;
            this._cmbAdaptiveType.Items.AddRange(new object[] {
            "Exponential",
            "Linear"});
            this._cmbAdaptiveType.Location = new System.Drawing.Point(94, 87);
            this._cmbAdaptiveType.Margin = new System.Windows.Forms.Padding(2);
            this._cmbAdaptiveType.Name = "_cmbAdaptiveType";
            this._cmbAdaptiveType.Size = new System.Drawing.Size(152, 21);
            this._cmbAdaptiveType.TabIndex = 5;
            // 
            // _lblColorSpace
            // 
            this._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblColorSpace.Location = new System.Drawing.Point(9, 81);
            this._lblColorSpace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lblColorSpace.Name = "_lblColorSpace";
            this._lblColorSpace.Size = new System.Drawing.Size(81, 38);
            this._lblColorSpace.TabIndex = 4;
            this._lblColorSpace.Text = "Adaptive Contrast Type";
            this._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblEnd
            // 
            this._lblEnd.AutoSize = true;
            this._lblEnd.Location = new System.Drawing.Point(9, 52);
            this._lblEnd.Name = "_lblEnd";
            this._lblEnd.Size = new System.Drawing.Size(56, 13);
            this._lblEnd.TabIndex = 3;
            this._lblEnd.Text = "Dimension";
            // 
            // _lblStart
            // 
            this._lblStart.AutoSize = true;
            this._lblStart.Location = new System.Drawing.Point(9, 19);
            this._lblStart.Name = "_lblStart";
            this._lblStart.Size = new System.Drawing.Size(43, 13);
            this._lblStart.TabIndex = 2;
            this._lblStart.Text = "Amount";
            // 
            // _numDimension
            // 
            this._numDimension.Location = new System.Drawing.Point(94, 50);
            this._numDimension.Margin = new System.Windows.Forms.Padding(2);
            this._numDimension.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._numDimension.Name = "_numDimension";
            this._numDimension.Size = new System.Drawing.Size(116, 20);
            this._numDimension.TabIndex = 1;
            this._numDimension.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // _numAmount
            // 
            this._numAmount.Location = new System.Drawing.Point(94, 14);
            this._numAmount.Margin = new System.Windows.Forms.Padding(2);
            this._numAmount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this._numAmount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._numAmount.Name = "_numAmount";
            this._numAmount.Size = new System.Drawing.Size(116, 20);
            this._numAmount.TabIndex = 0;
            this._numAmount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnCancel.Location = new System.Drawing.Point(260, 56);
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
            this._btnOk.Location = new System.Drawing.Point(260, 26);
            this._btnOk.Margin = new System.Windows.Forms.Padding(2);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(68, 22);
            this._btnOk.TabIndex = 10;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // AdaptiveContrastDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 125);
            this.Controls.Add(this._gbOptions);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdaptiveContrastDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adaptive Contrast";
            this.Load += new System.EventHandler(this.AdaptiveContrastDialog_Load);
            this._gbOptions.ResumeLayout(false);
            this._gbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numDimension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbOptions;
        private System.Windows.Forms.Label _lblEnd;
        private System.Windows.Forms.Label _lblStart;
        private System.Windows.Forms.NumericUpDown _numDimension;
        private System.Windows.Forms.NumericUpDown _numAmount;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.ComboBox _cmbAdaptiveType;
        private System.Windows.Forms.Label _lblColorSpace;
    }
}