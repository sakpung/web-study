namespace Main3DDemo.UI
{
    partial class FrameIndex
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
            System.Windows.Forms.TrackBar _trackBarPlaneIndex;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this._txtPlaneIndex = new Main3DDemo.NumericTextBox();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            _trackBarPlaneIndex = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(_trackBarPlaneIndex)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _trackBarPlaneIndex
            // 
            _trackBarPlaneIndex.Location = new System.Drawing.Point(83, 27);
            _trackBarPlaneIndex.Maximum = 1000;
            _trackBarPlaneIndex.Minimum = -1000;
            _trackBarPlaneIndex.Name = "_trackBarPlaneIndex";
            _trackBarPlaneIndex.Size = new System.Drawing.Size(135, 45);
            _trackBarPlaneIndex.TabIndex = 32;
            _trackBarPlaneIndex.TickFrequency = 0;
            _trackBarPlaneIndex.TickStyle = System.Windows.Forms.TickStyle.None;
            _trackBarPlaneIndex.Value = -1000;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(_trackBarPlaneIndex);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this._txtPlaneIndex);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 74);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "&Plane Index";
            // 
            // _txtPlaneIndex
            // 
            this._txtPlaneIndex.Location = new System.Drawing.Point(224, 29);
            this._txtPlaneIndex.MaximumAllowed = 1;
            this._txtPlaneIndex.MinimumAllowed = -1;
            this._txtPlaneIndex.Name = "_txtPlaneIndex";
            this._txtPlaneIndex.Size = new System.Drawing.Size(50, 20);
            this._txtPlaneIndex.TabIndex = 8;
            this._txtPlaneIndex.Text = "0";
            this._txtPlaneIndex.Value = 0;
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(55, 97);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(90, 27);
            this._btnOK.TabIndex = 36;
            this._btnOK.Text = "&OK";
            this._btnOK.UseVisualStyleBackColor = true;
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(151, 97);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(90, 27);
            this._btnCancel.TabIndex = 37;
            this._btnCancel.Text = "&Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrameIndex
            // 
            this.AcceptButton = this._btnOK;
            this.CancelButton = this._btnCancel;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 146);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrameIndex";
            this.Text = "Frame Index";
            ((System.ComponentModel.ISupportInitialize)(_trackBarPlaneIndex)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label label7;
        private NumericTextBox _txtPlaneIndex;
    }
}