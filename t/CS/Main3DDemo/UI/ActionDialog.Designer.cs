namespace Main3DDemo
{
    partial class ActionDialog
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
           this._cmbModifier = new System.Windows.Forms.ComboBox();
           this._cmbButton = new System.Windows.Forms.ComboBox();
           this._textBoxSensitivity = new Main3DDemo.NumericTextBox();
           this.label10 = new System.Windows.Forms.Label();
           this._btnOK = new System.Windows.Forms.Button();
           this._btnCancel = new System.Windows.Forms.Button();
           this.groupBox1.SuspendLayout();
           this.SuspendLayout();
           // 
           // groupBox1
           // 
           this.groupBox1.Controls.Add(this.label6);
           this.groupBox1.Controls.Add(this.label4);
           this.groupBox1.Controls.Add(this._cmbModifier);
           this.groupBox1.Controls.Add(this._cmbButton);
           this.groupBox1.Controls.Add(this._textBoxSensitivity);
           this.groupBox1.Controls.Add(this.label10);
           this.groupBox1.Location = new System.Drawing.Point(12, 12);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Size = new System.Drawing.Size(208, 173);
           this.groupBox1.TabIndex = 0;
           this.groupBox1.TabStop = false;
           this.groupBox1.Text = "Mous&e";
           // 
           // label6
           // 
           this.label6.AutoSize = true;
           this.label6.Location = new System.Drawing.Point(25, 80);
           this.label6.Name = "label6";
           this.label6.Size = new System.Drawing.Size(45, 13);
           this.label6.TabIndex = 40;
           this.label6.Text = "Mod&ifier";
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Location = new System.Drawing.Point(11, 33);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(73, 13);
           this.label4.TabIndex = 38;
           this.label4.Text = "&Mouse Button";
           // 
           // _cmbModifier
           // 
           this._cmbModifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this._cmbModifier.FormattingEnabled = true;
           this._cmbModifier.Items.AddRange(new object[] {
            "None",
            "Alt",
            "Shift"});
           this._cmbModifier.Location = new System.Drawing.Point(97, 77);
           this._cmbModifier.Name = "_cmbModifier";
           this._cmbModifier.Size = new System.Drawing.Size(87, 21);
           this._cmbModifier.TabIndex = 35;
           // 
           // _cmbButton
           // 
           this._cmbButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this._cmbButton.FormattingEnabled = true;
           this._cmbButton.Items.AddRange(new object[] {
            "None",
            "Left",
            "Right",
            "Middle",
            "Wheel",
            "XButton1",
            "XButton2"});
           this._cmbButton.Location = new System.Drawing.Point(97, 30);
           this._cmbButton.Name = "_cmbButton";
           this._cmbButton.Size = new System.Drawing.Size(87, 21);
           this._cmbButton.TabIndex = 31;
           // 
           // _textBoxSensitivity
           // 
           this._textBoxSensitivity.Location = new System.Drawing.Point(97, 122);
           this._textBoxSensitivity.MaximumAllowed = 1000;
           this._textBoxSensitivity.MinimumAllowed = 1;
           this._textBoxSensitivity.Name = "_textBoxSensitivity";
           this._textBoxSensitivity.Size = new System.Drawing.Size(50, 20);
           this._textBoxSensitivity.TabIndex = 6;
           this._textBoxSensitivity.Text = "100";
           this._textBoxSensitivity.Value = 100;
           // 
           // label10
           // 
           this.label10.AutoSize = true;
           this.label10.Location = new System.Drawing.Point(21, 125);
           this.label10.Name = "label10";
           this.label10.Size = new System.Drawing.Size(56, 13);
           this.label10.TabIndex = 29;
           this.label10.Text = "&Sensitivity";
           // 
           // _btnOK
           // 
           this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
           this._btnOK.Location = new System.Drawing.Point(19, 194);
           this._btnOK.Name = "_btnOK";
           this._btnOK.Size = new System.Drawing.Size(90, 27);
           this._btnOK.TabIndex = 34;
           this._btnOK.Text = "&OK";
           this._btnOK.UseVisualStyleBackColor = true;
           this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
           // 
           // _btnCancel
           // 
           this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this._btnCancel.Location = new System.Drawing.Point(115, 194);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(90, 27);
           this._btnCancel.TabIndex = 35;
           this._btnCancel.Text = "&Cancel";
           this._btnCancel.UseVisualStyleBackColor = true;
           this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
           // 
           // ActionDialog
           // 
           this.AcceptButton = this._btnOK;
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.CancelButton = this._btnCancel;
           this.ClientSize = new System.Drawing.Size(240, 233);
           this.Controls.Add(this._btnOK);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this.groupBox1);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "ActionDialog";
           this.Text = "Actions Dialog";
           this.groupBox1.ResumeLayout(false);
           this.groupBox1.PerformLayout();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox _cmbModifier;
        private System.Windows.Forms.ComboBox _cmbButton;
        private NumericTextBox _textBoxSensitivity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}