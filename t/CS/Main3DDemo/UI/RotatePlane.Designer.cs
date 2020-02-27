namespace Main3DDemo
{
    partial class RotatePlane
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
            this.label3 = new System.Windows.Forms.Label();
            this._comboBoxSpace = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._comboBoxAxis = new System.Windows.Forms.ComboBox();
            this._trackBarRotatePlane = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this._textBoxRotatePlane = new Main3DDemo.NumericTextBox();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarRotatePlane)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._comboBoxSpace);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._comboBoxAxis);
            this.groupBox1.Controls.Add(this._trackBarRotatePlane);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this._textBoxRotatePlane);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 117);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "&Space";
            // 
            // _comboBoxSpace
            // 
            this._comboBoxSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxSpace.FormattingEnabled = true;
            this._comboBoxSpace.Items.AddRange(new object[] {
            "Object",
            "View"});
            this._comboBoxSpace.Location = new System.Drawing.Point(199, 73);
            this._comboBoxSpace.Name = "_comboBoxSpace";
            this._comboBoxSpace.Size = new System.Drawing.Size(58, 21);
            this._comboBoxSpace.TabIndex = 38;
            this._comboBoxSpace.SelectedIndexChanged += new System.EventHandler(this._comboBoxSpace_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "&Axis";
            // 
            // _comboBoxAxis
            // 
            this._comboBoxAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxAxis.FormattingEnabled = true;
            this._comboBoxAxis.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this._comboBoxAxis.Location = new System.Drawing.Point(55, 74);
            this._comboBoxAxis.Name = "_comboBoxAxis";
            this._comboBoxAxis.Size = new System.Drawing.Size(58, 21);
            this._comboBoxAxis.TabIndex = 36;
            this._comboBoxAxis.SelectedIndexChanged += new System.EventHandler(this._comboBoxAxis_SelectedIndexChanged);
            // 
            // _trackBarRotatePlane
            // 
            this._trackBarRotatePlane.Location = new System.Drawing.Point(84, 27);
            this._trackBarRotatePlane.Maximum = 360;
            this._trackBarRotatePlane.Name = "_trackBarRotatePlane";
            this._trackBarRotatePlane.Size = new System.Drawing.Size(135, 45);
            this._trackBarRotatePlane.TabIndex = 32;
            this._trackBarRotatePlane.TickFrequency = 0;
            this._trackBarRotatePlane.TickStyle = System.Windows.Forms.TickStyle.None;
            this._trackBarRotatePlane.ValueChanged += new System.EventHandler(this._trackBarRotatePlane_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "&Angle";
            // 
            // _textBoxRotatePlane
            // 
            this._textBoxRotatePlane.Location = new System.Drawing.Point(227, 29);
            this._textBoxRotatePlane.MaximumAllowed = 360;
            this._textBoxRotatePlane.MinimumAllowed = 0;
            this._textBoxRotatePlane.Name = "_textBoxRotatePlane";
            this._textBoxRotatePlane.Size = new System.Drawing.Size(50, 20);
            this._textBoxRotatePlane.TabIndex = 8;
            this._textBoxRotatePlane.Text = "0";
            this._textBoxRotatePlane.Value = 0;
            this._textBoxRotatePlane.TextChanged += new System.EventHandler(this._textBoxRotatePlane_TextChanged);
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(61, 139);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(90, 27);
            this._btnOK.TabIndex = 36;
            this._btnOK.Text = "&OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(157, 139);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(90, 27);
            this._btnCancel.TabIndex = 37;
            this._btnCancel.Text = "&Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // RotatePlane
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(316, 180);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RotatePlane";
            this.Text = "Rotate Plane";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarRotatePlane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label label7;
        private NumericTextBox _textBoxRotatePlane;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _comboBoxAxis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _comboBoxSpace;
        System.Windows.Forms.TrackBar _trackBarRotatePlane;
    }
}