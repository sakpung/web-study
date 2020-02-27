namespace Main3DDemo
{
    partial class SlabDialog
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
            this._chkBoxenableSlab = new System.Windows.Forms.CheckBox();
            this._textBoxZ2 = new Main3DDemo.NumericTextBox();
            this._textBoxY2 = new Main3DDemo.NumericTextBox();
            this._textBoxX2 = new Main3DDemo.NumericTextBox();
            this._textBoxZ1 = new Main3DDemo.NumericTextBox();
            this._textBoxY1 = new Main3DDemo.NumericTextBox();
            this._textBoxX1 = new Main3DDemo.NumericTextBox();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            _trackBarY2 = new System.Windows.Forms.TrackBar();
            _trackBarZ2 = new System.Windows.Forms.TrackBar();
            _trackBarX2 = new System.Windows.Forms.TrackBar();
            _trackBarY1 = new System.Windows.Forms.TrackBar();
            _trackBarZ1 = new System.Windows.Forms.TrackBar();
            _trackBarX1 = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(_trackBarY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarZ2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarZ1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarX1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._chkBoxenableSlab);
            this.groupBox1.Controls.Add(this._textBoxZ2);
            this.groupBox1.Controls.Add(this._textBoxY2);
            this.groupBox1.Controls.Add(this._textBoxX2);
            this.groupBox1.Controls.Add(this._textBoxZ1);
            this.groupBox1.Controls.Add(this._textBoxY1);
            this.groupBox1.Controls.Add(this._textBoxX1);
            this.groupBox1.Controls.Add(_trackBarY2);
            this.groupBox1.Controls.Add(_trackBarZ2);
            this.groupBox1.Controls.Add(_trackBarX2);
            this.groupBox1.Controls.Add(_trackBarY1);
            this.groupBox1.Controls.Add(_trackBarZ1);
            this.groupBox1.Controls.Add(_trackBarX1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 190);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Parameters";
            // 
            // _chkBoxenableSlab
            // 
            this._chkBoxenableSlab.AutoSize = true;
            this._chkBoxenableSlab.Location = new System.Drawing.Point(16, 160);
            this._chkBoxenableSlab.Name = "_chkBoxenableSlab";
            this._chkBoxenableSlab.Size = new System.Drawing.Size(64, 17);
            this._chkBoxenableSlab.TabIndex = 12;
            this._chkBoxenableSlab.Text = "&Enabled";
            this._chkBoxenableSlab.UseVisualStyleBackColor = true;
            this._chkBoxenableSlab.CheckedChanged += new System.EventHandler(this._chkBoxenableSlab_CheckedChanged);
            // 
            // _textBoxZ2
            // 
            this._textBoxZ2.Location = new System.Drawing.Point(410, 118);
            this._textBoxZ2.MaximumAllowed = 1000;
            this._textBoxZ2.MinimumAllowed = -1000;
            this._textBoxZ2.Name = "_textBoxZ2";
            this._textBoxZ2.Size = new System.Drawing.Size(50, 20);
            this._textBoxZ2.TabIndex = 11;
            this._textBoxZ2.Text = "1000";
            this._textBoxZ2.Value = 1000;
            this._textBoxZ2.TextChanged += new System.EventHandler(this._textBoxZ2_TextChanged);
            // 
            // _textBoxY2
            // 
            this._textBoxY2.Location = new System.Drawing.Point(410, 69);
            this._textBoxY2.MaximumAllowed = 1000;
            this._textBoxY2.MinimumAllowed = -1000;
            this._textBoxY2.Name = "_textBoxY2";
            this._textBoxY2.Size = new System.Drawing.Size(50, 20);
            this._textBoxY2.TabIndex = 10;
            this._textBoxY2.Text = "1000";
            this._textBoxY2.Value = 1000;
            this._textBoxY2.TextChanged += new System.EventHandler(this._textBoxY2_TextChanged);
            // 
            // _textBoxX2
            // 
            this._textBoxX2.Location = new System.Drawing.Point(410, 20);
            this._textBoxX2.MaximumAllowed = 1000;
            this._textBoxX2.MinimumAllowed = -1000;
            this._textBoxX2.Name = "_textBoxX2";
            this._textBoxX2.Size = new System.Drawing.Size(50, 20);
            this._textBoxX2.TabIndex = 9;
            this._textBoxX2.Text = "1000";
            this._textBoxX2.Value = 1000;
            this._textBoxX2.TextChanged += new System.EventHandler(this._textBoxX2_TextChanged);
            // 
            // _textBoxZ1
            // 
            this._textBoxZ1.Location = new System.Drawing.Point(171, 120);
            this._textBoxZ1.MaximumAllowed = 1000;
            this._textBoxZ1.MinimumAllowed = -1000;
            this._textBoxZ1.Name = "_textBoxZ1";
            this._textBoxZ1.Size = new System.Drawing.Size(50, 20);
            this._textBoxZ1.TabIndex = 8;
            this._textBoxZ1.Text = "-1000";
            this._textBoxZ1.Value = -1000;
            this._textBoxZ1.TextChanged += new System.EventHandler(this._textBoxZ1_TextChanged);
            // 
            // _textBoxY1
            // 
            this._textBoxY1.Location = new System.Drawing.Point(171, 71);
            this._textBoxY1.MaximumAllowed = 1000;
            this._textBoxY1.MinimumAllowed = -1000;
            this._textBoxY1.Name = "_textBoxY1";
            this._textBoxY1.Size = new System.Drawing.Size(50, 20);
            this._textBoxY1.TabIndex = 7;
            this._textBoxY1.Text = "-1000";
            this._textBoxY1.Value = -1000;
            this._textBoxY1.TextChanged += new System.EventHandler(this._textBoxY1_TextChanged);
            // 
            // _textBoxX1
            // 
            this._textBoxX1.Location = new System.Drawing.Point(171, 20);
            this._textBoxX1.MaximumAllowed = 1000;
            this._textBoxX1.MinimumAllowed = -1000;
            this._textBoxX1.Name = "_textBoxX1";
            this._textBoxX1.Size = new System.Drawing.Size(50, 20);
            this._textBoxX1.TabIndex = 6;
            this._textBoxX1.Text = "-1000";
            this._textBoxX1.Value = -1000;
            this._textBoxX1.TextChanged += new System.EventHandler(this._textBoxX1_TextChanged);
            // 
            // _trackBarY2
            // 
            _trackBarY2.Location = new System.Drawing.Point(272, 69);
            _trackBarY2.Maximum = 1000;
            _trackBarY2.Minimum = -1000;
            _trackBarY2.Name = "_trackBarY2";
            _trackBarY2.Size = new System.Drawing.Size(135, 45);
            _trackBarY2.TabIndex = 5;
            _trackBarY2.TickFrequency = 0;
            _trackBarY2.TickStyle = System.Windows.Forms.TickStyle.None;
            _trackBarY2.Value = 1000;
            _trackBarY2.ValueChanged += new System.EventHandler(this._trackBarY2_ValueChanged);
            // 
            // _trackBarZ2
            // 
            _trackBarZ2.Location = new System.Drawing.Point(272, 118);
            _trackBarZ2.Maximum = 1000;
            _trackBarZ2.Minimum = -1000;
            _trackBarZ2.Name = "_trackBarZ2";
            _trackBarZ2.Size = new System.Drawing.Size(135, 45);
            _trackBarZ2.TabIndex = 4;
            _trackBarZ2.TickFrequency = 0;
            _trackBarZ2.TickStyle = System.Windows.Forms.TickStyle.None;
            _trackBarZ2.Value = 1000;
            _trackBarZ2.ValueChanged += new System.EventHandler(this._trackBarZ2_ValueChanged);
            // 
            // _trackBarX2
            // 
            _trackBarX2.Location = new System.Drawing.Point(272, 20);
            _trackBarX2.Maximum = 1000;
            _trackBarX2.Minimum = -1000;
            _trackBarX2.Name = "_trackBarX2";
            _trackBarX2.Size = new System.Drawing.Size(135, 45);
            _trackBarX2.TabIndex = 3;
            _trackBarX2.TickFrequency = 0;
            _trackBarX2.TickStyle = System.Windows.Forms.TickStyle.None;
            _trackBarX2.Value = 1000;
            _trackBarX2.ValueChanged += new System.EventHandler(this._trackBarX2_ValueChanged);
            // 
            // _trackBarY1
            // 
            _trackBarY1.Location = new System.Drawing.Point(32, 71);
            _trackBarY1.Maximum = 1000;
            _trackBarY1.Minimum = -1000;
            _trackBarY1.Name = "_trackBarY1";
            _trackBarY1.Size = new System.Drawing.Size(135, 45);
            _trackBarY1.TabIndex = 2;
            _trackBarY1.TickFrequency = 0;
            _trackBarY1.TickStyle = System.Windows.Forms.TickStyle.None;
            _trackBarY1.Value = -1000;
            _trackBarY1.ValueChanged += new System.EventHandler(this._trackBarY1_ValueChanged);
            // 
            // _trackBarZ1
            // 
            _trackBarZ1.Location = new System.Drawing.Point(32, 120);
            _trackBarZ1.Maximum = 1000;
            _trackBarZ1.Minimum = -1000;
            _trackBarZ1.Name = "_trackBarZ1";
            _trackBarZ1.Size = new System.Drawing.Size(135, 45);
            _trackBarZ1.TabIndex = 1;
            _trackBarZ1.TickFrequency = 0;
            _trackBarZ1.TickStyle = System.Windows.Forms.TickStyle.None;
            _trackBarZ1.Value = -1000;
            _trackBarZ1.ValueChanged += new System.EventHandler(this._trackBarZ1_ValueChanged);
            // 
            // _trackBarX1
            // 
            _trackBarX1.Location = new System.Drawing.Point(32, 22);
            _trackBarX1.Maximum = 1000;
            _trackBarX1.Minimum = -1000;
            _trackBarX1.Name = "_trackBarX1";
            _trackBarX1.Size = new System.Drawing.Size(135, 45);
            _trackBarX1.TabIndex = 0;
            _trackBarX1.TickFrequency = 0;
            _trackBarX1.TickStyle = System.Windows.Forms.TickStyle.None;
            _trackBarX1.Value = -1000;
            _trackBarX1.ValueChanged += new System.EventHandler(this._trackBarX1_ValueChanged);
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(102, 215);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(90, 33);
            this._btnOK.TabIndex = 13;
            this._btnOK.Text = "&OK";
            this._btnOK.UseVisualStyleBackColor = true;
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(198, 215);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(90, 33);
            this._btnCancel.TabIndex = 14;
            this._btnCancel.Text = "&Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnReset
            // 
            this._btnReset.Location = new System.Drawing.Point(294, 215);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(90, 33);
            this._btnReset.TabIndex = 15;
            this._btnReset.Text = "&Reset";
            this._btnReset.UseVisualStyleBackColor = true;
            this._btnReset.Click += new System.EventHandler(this._btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "&X1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "&X2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "&Y2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "&Y1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "&Z2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "&Z1";
            // 
            // SlabDialog
            // 
            this.AcceptButton = this._btnOK;
            this.CancelButton = this._btnCancel;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 254);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "SlabDialog";
            this.Text = "Slab Dialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(_trackBarY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarZ2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarZ1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(_trackBarX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        System.Windows.Forms.TrackBar _trackBarY2;
        System.Windows.Forms.TrackBar _trackBarZ2;
        System.Windows.Forms.TrackBar _trackBarX2;
        System.Windows.Forms.TrackBar _trackBarY1;
        System.Windows.Forms.TrackBar _trackBarZ1;
        System.Windows.Forms.TrackBar _trackBarX1;
        private NumericTextBox _textBoxX1;
        private NumericTextBox _textBoxY1;
        private NumericTextBox _textBoxZ1;
        private NumericTextBox _textBoxZ2;
        private NumericTextBox _textBoxY2;
        private NumericTextBox _textBoxX2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnReset;
        private System.Windows.Forms.CheckBox _chkBoxenableSlab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;

    }
}