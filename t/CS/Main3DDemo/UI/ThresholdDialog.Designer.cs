namespace Main3DDemo
{
    partial class ThresholdDialog
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
           this._btnReset = new System.Windows.Forms.Button();
           this._btnCancel = new System.Windows.Forms.Button();
           this._btnOK = new System.Windows.Forms.Button();
           this.groupBox1 = new System.Windows.Forms.GroupBox();
           this._removeInnerRangeChkBox = new System.Windows.Forms.CheckBox();
           this._toLbl = new System.Windows.Forms.Label();
           this._fromLbl = new System.Windows.Forms.Label();
           this._chkBoxenableThreshold = new System.Windows.Forms.CheckBox();
           this._textBoxUpper = new Main3DDemo.NumericTextBox();
           this._textBoxLower = new Main3DDemo.NumericTextBox();
           _trackBarUpper = new System.Windows.Forms.TrackBar();
           _trackBarLower = new System.Windows.Forms.TrackBar();
           this.groupBox1.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(_trackBarUpper)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(_trackBarLower)).BeginInit();
           this.SuspendLayout();
           // 
           // _btnReset
           // 
           this._btnReset.Location = new System.Drawing.Point(168, 165);
           this._btnReset.Name = "_btnReset";
           this._btnReset.Size = new System.Drawing.Size(61, 33);
           this._btnReset.TabIndex = 19;
           this._btnReset.Text = "&Reset";
           this._btnReset.UseVisualStyleBackColor = true;
           this._btnReset.Click += new System.EventHandler(this._btnReset_Click);
           // 
           // _btnCancel
           // 
           this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this._btnCancel.Location = new System.Drawing.Point(98, 165);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(64, 33);
           this._btnCancel.TabIndex = 18;
           this._btnCancel.Text = "&Cancel";
           this._btnCancel.UseVisualStyleBackColor = true;
           this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
           // 
           // _btnOK
           // 
           this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
           this._btnOK.Location = new System.Drawing.Point(28, 165);
           this._btnOK.Name = "_btnOK";
           this._btnOK.Size = new System.Drawing.Size(64, 33);
           this._btnOK.TabIndex = 17;
           this._btnOK.Text = "&OK";
           this._btnOK.UseVisualStyleBackColor = true;
           // 
           // groupBox1
           // 
           this.groupBox1.Controls.Add(this._removeInnerRangeChkBox);
           this.groupBox1.Controls.Add(this._toLbl);
           this.groupBox1.Controls.Add(this._fromLbl);
           this.groupBox1.Controls.Add(this._chkBoxenableThreshold);
           this.groupBox1.Controls.Add(this._textBoxUpper);
           this.groupBox1.Controls.Add(this._textBoxLower);
           this.groupBox1.Controls.Add(_trackBarUpper);
           this.groupBox1.Controls.Add(_trackBarLower);
           this.groupBox1.Location = new System.Drawing.Point(12, 12);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Size = new System.Drawing.Size(237, 141);
           this.groupBox1.TabIndex = 16;
           this.groupBox1.TabStop = false;
           this.groupBox1.Text = "&Parameters";
           // 
           // _removeInnerRangeChkBox
           // 
           this._removeInnerRangeChkBox.AutoSize = true;
           this._removeInnerRangeChkBox.Location = new System.Drawing.Point(103, 107);
           this._removeInnerRangeChkBox.Name = "_removeInnerRangeChkBox";
           this._removeInnerRangeChkBox.Size = new System.Drawing.Size(128, 17);
           this._removeInnerRangeChkBox.TabIndex = 15;
           this._removeInnerRangeChkBox.Text = "&Remove Inner Range";
           this._removeInnerRangeChkBox.UseVisualStyleBackColor = true;
           this._removeInnerRangeChkBox.CheckedChanged += new System.EventHandler(this._removeInnerRangeChkBox_CheckedChanged);
           // 
           // _toLbl
           // 
           this._toLbl.AutoSize = true;
           this._toLbl.Location = new System.Drawing.Point(10, 65);
           this._toLbl.Name = "_toLbl";
           this._toLbl.Size = new System.Drawing.Size(20, 13);
           this._toLbl.TabIndex = 14;
           this._toLbl.Text = "&To";
           // 
           // _fromLbl
           // 
           this._fromLbl.AutoSize = true;
           this._fromLbl.Location = new System.Drawing.Point(6, 25);
           this._fromLbl.Name = "_fromLbl";
           this._fromLbl.Size = new System.Drawing.Size(30, 13);
           this._fromLbl.TabIndex = 13;
           this._fromLbl.Text = "From";
           // 
           // _chkBoxenableThreshold
           // 
           this._chkBoxenableThreshold.AutoSize = true;
           this._chkBoxenableThreshold.Location = new System.Drawing.Point(9, 107);
           this._chkBoxenableThreshold.Name = "_chkBoxenableThreshold";
           this._chkBoxenableThreshold.Size = new System.Drawing.Size(65, 17);
           this._chkBoxenableThreshold.TabIndex = 12;
           this._chkBoxenableThreshold.Text = "&Enabled";
           this._chkBoxenableThreshold.UseVisualStyleBackColor = true;
           this._chkBoxenableThreshold.CheckedChanged += new System.EventHandler(this._chkBoxenableThreshold_CheckedChanged);
           // 
           // _textBoxUpper
           // 
           this._textBoxUpper.Location = new System.Drawing.Point(170, 58);
           this._textBoxUpper.MaximumAllowed = 100000;
           this._textBoxUpper.MinimumAllowed = 0;
           this._textBoxUpper.Name = "_textBoxUpper";
           this._textBoxUpper.Size = new System.Drawing.Size(50, 20);
           this._textBoxUpper.TabIndex = 9;
           this._textBoxUpper.Text = "100000";
           this._textBoxUpper.Value = 100000;
           this._textBoxUpper.TextChanged += new System.EventHandler(this._textBoxUpper_TextChanged);
           // 
           // _textBoxLower
           // 
           this._textBoxLower.Location = new System.Drawing.Point(171, 18);
           this._textBoxLower.MaximumAllowed = 100000;
           this._textBoxLower.MinimumAllowed = 0;
           this._textBoxLower.Name = "_textBoxLower";
           this._textBoxLower.Size = new System.Drawing.Size(50, 20);
           this._textBoxLower.TabIndex = 6;
           this._textBoxLower.Text = "0";
           this._textBoxLower.Value = 0;
           this._textBoxLower.TextChanged += new System.EventHandler(this._textBoxLower_TextChanged);
           // 
           // _trackBarUpper
           // 
           _trackBarUpper.Location = new System.Drawing.Point(34, 60);
           _trackBarUpper.Maximum = 100000;
           _trackBarUpper.Name = "_trackBarUpper";
           _trackBarUpper.Size = new System.Drawing.Size(133, 45);
           _trackBarUpper.TabIndex = 3;
           _trackBarUpper.TickFrequency = 0;
           _trackBarUpper.TickStyle = System.Windows.Forms.TickStyle.None;
           _trackBarUpper.Value = 255;
           _trackBarUpper.ValueChanged += new System.EventHandler(this._trackBarUpper_ValueChanged);
           // 
           // _trackBarLower
           // 
           _trackBarLower.Location = new System.Drawing.Point(34, 20);
           _trackBarLower.Maximum = 100000;
           _trackBarLower.Name = "_trackBarLower";
           _trackBarLower.Size = new System.Drawing.Size(133, 45);
           _trackBarLower.TabIndex = 0;
           _trackBarLower.TickFrequency = 0;
           _trackBarLower.TickStyle = System.Windows.Forms.TickStyle.None;
           _trackBarLower.ValueChanged += new System.EventHandler(this._trackBarLower_ValueChanged);
           // 
           // ThresholdDialog
           // 
           this.AcceptButton = this._btnOK;
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.CancelButton = this._btnCancel;
           this.ClientSize = new System.Drawing.Size(258, 208);
           this.Controls.Add(this._btnReset);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this._btnOK);
           this.Controls.Add(this.groupBox1);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "ThresholdDialog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Remove Density Dialog";
           this.groupBox1.ResumeLayout(false);
           this.groupBox1.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(_trackBarUpper)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(_trackBarLower)).EndInit();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnReset;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox _chkBoxenableThreshold;
        private NumericTextBox _textBoxUpper;
        private NumericTextBox _textBoxLower;
        private System.Windows.Forms.CheckBox _removeInnerRangeChkBox;
        private System.Windows.Forms.Label _toLbl;
        private System.Windows.Forms.Label _fromLbl;
        private System.Windows.Forms.TrackBar _trackBarUpper;
        private System.Windows.Forms.TrackBar _trackBarLower;
    }
}