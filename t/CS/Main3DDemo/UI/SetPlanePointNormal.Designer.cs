namespace Main3DDemo
{
    partial class SetPlanePointNormal
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
            this._btnOK = new System.Windows.Forms.Button();
            this._btnReset = new System.Windows.Forms.Button();
            this._textBoxPointY = new Main3DDemo.FNumericTextBox();
            this._textBoxPointZ = new Main3DDemo.FNumericTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._textBoxPointX = new Main3DDemo.FNumericTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._textBoxNormalZ = new Main3DDemo.FNumericTextBox();
            this._textBoxNormalY = new Main3DDemo.FNumericTextBox();
            this._textBoxNormalX = new Main3DDemo.FNumericTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(127, 155);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(90, 27);
            this._btnCancel.TabIndex = 18;
            this._btnCancel.Text = "&Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(31, 155);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(90, 27);
            this._btnOK.TabIndex = 17;
            this._btnOK.Text = "&OK";
            this._btnOK.UseVisualStyleBackColor = true;
            // 
            // _btnReset
            // 
            this._btnReset.Location = new System.Drawing.Point(223, 155);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(90, 27);
            this._btnReset.TabIndex = 19;
            this._btnReset.Text = "&Reset";
            this._btnReset.UseVisualStyleBackColor = true;
            this._btnReset.Click += new System.EventHandler(this._btnReset_Click);
            // 
            // _textBoxPointY
            // 
            this._textBoxPointY.Location = new System.Drawing.Point(139, 24);
            this._textBoxPointY.MaximumAllowed = 1F;
            this._textBoxPointY.MinimumAllowed = -1F;
            this._textBoxPointY.Name = "_textBoxPointY";
            this._textBoxPointY.Size = new System.Drawing.Size(50, 20);
            this._textBoxPointY.TabIndex = 7;
            this._textBoxPointY.Text = "0";
            this._textBoxPointY.Value = 0F;
            this._textBoxPointY.TextChanged += new System.EventHandler(this._textBoxPointY_TextChanged);
            // 
            // _textBoxPointZ
            // 
            this._textBoxPointZ.Location = new System.Drawing.Point(236, 24);
            this._textBoxPointZ.MaximumAllowed = 1F;
            this._textBoxPointZ.MinimumAllowed = -1F;
            this._textBoxPointZ.Name = "_textBoxPointZ";
            this._textBoxPointZ.Size = new System.Drawing.Size(50, 20);
            this._textBoxPointZ.TabIndex = 8;
            this._textBoxPointZ.Text = "0";
            this._textBoxPointZ.Value = 0F;
            this._textBoxPointZ.TextChanged += new System.EventHandler(this._textBoxPointZ_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this._textBoxPointZ);
            this.groupBox1.Controls.Add(this._textBoxPointY);
            this.groupBox1.Controls.Add(this._textBoxPointX);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 59);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Point";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "&Z";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "&Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "&X";
            // 
            // _textBoxPointX
            // 
            this._textBoxPointX.Location = new System.Drawing.Point(45, 24);
            this._textBoxPointX.MaximumAllowed = 1F;
            this._textBoxPointX.MinimumAllowed = -1F;
            this._textBoxPointX.Name = "_textBoxPointX";
            this._textBoxPointX.Size = new System.Drawing.Size(50, 20);
            this._textBoxPointX.TabIndex = 6;
            this._textBoxPointX.Text = "0";
            this._textBoxPointX.Value = 0F;
            this._textBoxPointX.TextChanged += new System.EventHandler(this._textBoxPointX_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this._textBoxNormalZ);
            this.groupBox2.Controls.Add(this._textBoxNormalY);
            this.groupBox2.Controls.Add(this._textBoxNormalX);
            this.groupBox2.Location = new System.Drawing.Point(11, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 72);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "&Normal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "&Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "&Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "&X";
            // 
            // _textBoxNormalZ
            // 
            this._textBoxNormalZ.Location = new System.Drawing.Point(236, 30);
            this._textBoxNormalZ.MaximumAllowed = 1F;
            this._textBoxNormalZ.MinimumAllowed = -1F;
            this._textBoxNormalZ.Name = "_textBoxNormalZ";
            this._textBoxNormalZ.Size = new System.Drawing.Size(50, 20);
            this._textBoxNormalZ.TabIndex = 22;
            this._textBoxNormalZ.Text = "0";
            this._textBoxNormalZ.Value = 0F;
            this._textBoxNormalZ.TextChanged += new System.EventHandler(this._textBoxNormalZ_TextChanged);
            // 
            // _textBoxNormalY
            // 
            this._textBoxNormalY.Location = new System.Drawing.Point(139, 30);
            this._textBoxNormalY.MaximumAllowed = 1F;
            this._textBoxNormalY.MinimumAllowed = -1F;
            this._textBoxNormalY.Name = "_textBoxNormalY";
            this._textBoxNormalY.Size = new System.Drawing.Size(50, 20);
            this._textBoxNormalY.TabIndex = 21;
            this._textBoxNormalY.Text = "0";
            this._textBoxNormalY.Value = 0F;
            this._textBoxNormalY.TextChanged += new System.EventHandler(this._textBoxNormalY_TextChanged);
            // 
            // _textBoxNormalX
            // 
            this._textBoxNormalX.Location = new System.Drawing.Point(45, 30);
            this._textBoxNormalX.MaximumAllowed = 1F;
            this._textBoxNormalX.MinimumAllowed = -1F;
            this._textBoxNormalX.Name = "_textBoxNormalX";
            this._textBoxNormalX.Size = new System.Drawing.Size(50, 20);
            this._textBoxNormalX.TabIndex = 20;
            this._textBoxNormalX.Text = "0";
            this._textBoxNormalX.Value = 0F;
            this._textBoxNormalX.TextChanged += new System.EventHandler(this._textBoxNormalX_TextChanged);
            // 
            // SetPlanePointNormal
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(343, 197);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetPlanePointNormal";
            this.Text = "Set Plane Point & Normal";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private FNumericTextBox _textBoxPointY;
        private FNumericTextBox _textBoxPointZ;
        private FNumericTextBox _textBoxPointX;
        private FNumericTextBox _textBoxNormalZ;
        private FNumericTextBox _textBoxNormalY;
        private FNumericTextBox _textBoxNormalX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
    }
}