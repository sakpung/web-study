namespace Main3DDemo
{
    partial class RotateDialog
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
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._textBoxZ = new Main3DDemo.NumericTextBox();
            this._textBoxY = new Main3DDemo.NumericTextBox();
            this._textBoxX = new Main3DDemo.NumericTextBox();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            _trackBarY = new System.Windows.Forms.TrackBar();
            _trackBarZ = new System.Windows.Forms.TrackBar();
            _trackBarX = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(_trackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarX)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._textBoxZ);
            this.groupBox1.Controls.Add(this._textBoxY);
            this.groupBox1.Controls.Add(this._textBoxX);
            this.groupBox1.Controls.Add(_trackBarY);
            this.groupBox1.Controls.Add(_trackBarZ);
            this.groupBox1.Controls.Add(_trackBarX);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 171);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Rotation Parameters";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "&Z";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "&Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "&X";
            // 
            // _textBoxZ
            // 
            this._textBoxZ.Location = new System.Drawing.Point(173, 125);
            this._textBoxZ.MaximumAllowed = 180;
            this._textBoxZ.MinimumAllowed = -180;
            this._textBoxZ.Name = "_textBoxZ";
            this._textBoxZ.Size = new System.Drawing.Size(50, 20);
            this._textBoxZ.TabIndex = 34;
            this._textBoxZ.Text = "0";
            this._textBoxZ.Value = 0;
            this._textBoxZ.TextChanged += new System.EventHandler(this._textBoxZ_TextChanged);
            // 
            // _textBoxY
            // 
            this._textBoxY.Location = new System.Drawing.Point(173, 76);
            this._textBoxY.MaximumAllowed = 180;
            this._textBoxY.MinimumAllowed = -180;
            this._textBoxY.Name = "_textBoxY";
            this._textBoxY.Size = new System.Drawing.Size(50, 20);
            this._textBoxY.TabIndex = 33;
            this._textBoxY.Text = "0";
            this._textBoxY.Value = 0;
            this._textBoxY.TextChanged += new System.EventHandler(this._textBoxY_TextChanged);
            // 
            // _textBoxX
            // 
            this._textBoxX.Location = new System.Drawing.Point(173, 25);
            this._textBoxX.MaximumAllowed = 180;
            this._textBoxX.MinimumAllowed = -180;
            this._textBoxX.Name = "_textBoxX";
            this._textBoxX.Size = new System.Drawing.Size(50, 20);
            this._textBoxX.TabIndex = 32;
            this._textBoxX.Text = "0";
            this._textBoxX.Value = 0;
            this._textBoxX.TextChanged += new System.EventHandler(this._textBoxX_TextChanged);
            // 
            // _trackBarY
            // 
            _trackBarY.Location = new System.Drawing.Point(34, 76);
            _trackBarY.Maximum = 180;
            _trackBarY.Minimum = -180;
            _trackBarY.Name = "_trackBarY";
            _trackBarY.Size = new System.Drawing.Size(135, 45);
            _trackBarY.TabIndex = 31;
            _trackBarY.TickFrequency = 0;
            _trackBarY.TickStyle = System.Windows.Forms.TickStyle.None;
            _trackBarY.ValueChanged += new System.EventHandler(this._trackBarY_ValueChanged);
            // 
            // _trackBarZ
            // 
            _trackBarZ.Location = new System.Drawing.Point(34, 125);
            _trackBarZ.Maximum = 180;
            _trackBarZ.Minimum = -180;
            _trackBarZ.Name = "_trackBarZ";
            _trackBarZ.Size = new System.Drawing.Size(135, 45);
            _trackBarZ.TabIndex = 30;
            _trackBarZ.TickFrequency = 0;
            _trackBarZ.TickStyle = System.Windows.Forms.TickStyle.None;
            _trackBarZ.ValueChanged += new System.EventHandler(this._trackBarZ_ValueChanged);
            // 
            // _trackBarX
            // 
            _trackBarX.Location = new System.Drawing.Point(34, 27);
            _trackBarX.Maximum = 180;
            _trackBarX.Minimum = -180;
            _trackBarX.Name = "_trackBarX";
            _trackBarX.Size = new System.Drawing.Size(135, 45);
            _trackBarX.TabIndex = 29;
            _trackBarX.TickFrequency = 0;
            _trackBarX.TickStyle = System.Windows.Forms.TickStyle.None;
            _trackBarX.ValueChanged += new System.EventHandler(this._trackBarX_ValueChanged);
            // 
            // _btnReset
            // 
            this._btnReset.Location = new System.Drawing.Point(172, 189);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(66, 33);
            this._btnReset.TabIndex = 32;
            this._btnReset.Text = "&Reset";
            this._btnReset.UseVisualStyleBackColor = true;
            this._btnReset.Click += new System.EventHandler(this._btnReset_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(98, 189);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(66, 33);
            this._btnCancel.TabIndex = 31;
            this._btnCancel.Text = "&Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(24, 189);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(66, 33);
            this._btnOK.TabIndex = 30;
            this._btnOK.Text = "&OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // RotateDialog
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(262, 234);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RotateDialog";
            this.Text = "Rotate Dialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(_trackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar _trackBarY;
        private System.Windows.Forms.TrackBar _trackBarZ;
        private System.Windows.Forms.TrackBar _trackBarX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private NumericTextBox _textBoxZ;
        private NumericTextBox _textBoxY;
        private NumericTextBox _textBoxX;
        private System.Windows.Forms.Button _btnReset;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;

    }
}