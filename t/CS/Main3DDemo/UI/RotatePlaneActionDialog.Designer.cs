namespace Main3DDemo
{
    partial class RotatePlaneActionDialog
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
           this.label1 = new System.Windows.Forms.Label();
           this.label2 = new System.Windows.Forms.Label();
           this._comboBoxOrientation = new System.Windows.Forms.ComboBox();
           this._comboBoxAxis = new System.Windows.Forms.ComboBox();
           this._btnOK = new System.Windows.Forms.Button();
           this._btnCancel = new System.Windows.Forms.Button();
           this.groupBox1.SuspendLayout();
           this.SuspendLayout();
           // 
           // groupBox1
           // 
           this.groupBox1.Controls.Add(this.label1);
           this.groupBox1.Controls.Add(this.label2);
           this.groupBox1.Controls.Add(this._comboBoxOrientation);
           this.groupBox1.Controls.Add(this._comboBoxAxis);
           this.groupBox1.Location = new System.Drawing.Point(12, 12);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Size = new System.Drawing.Size(209, 122);
           this.groupBox1.TabIndex = 0;
           this.groupBox1.TabStop = false;
           this.groupBox1.Text = "Mous&e";
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(12, 78);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(61, 13);
           this.label1.TabIndex = 44;
           this.label1.Text = "&Orientation";
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(29, 31);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(27, 13);
           this.label2.TabIndex = 43;
           this.label2.Text = "&Axis";
           // 
           // _comboBoxOrientation
           // 
           this._comboBoxOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this._comboBoxOrientation.FormattingEnabled = true;
           this._comboBoxOrientation.Items.AddRange(new object[] {
            "Object",
            "View"});
           this._comboBoxOrientation.Location = new System.Drawing.Point(92, 75);
           this._comboBoxOrientation.Name = "_comboBoxOrientation";
           this._comboBoxOrientation.Size = new System.Drawing.Size(87, 21);
           this._comboBoxOrientation.TabIndex = 42;
           // 
           // _comboBoxAxis
           // 
           this._comboBoxAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this._comboBoxAxis.FormattingEnabled = true;
           this._comboBoxAxis.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
           this._comboBoxAxis.Location = new System.Drawing.Point(92, 28);
           this._comboBoxAxis.Name = "_comboBoxAxis";
           this._comboBoxAxis.Size = new System.Drawing.Size(87, 21);
           this._comboBoxAxis.TabIndex = 41;
           // 
           // _btnOK
           // 
           this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
           this._btnOK.Location = new System.Drawing.Point(22, 140);
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
           this._btnCancel.Location = new System.Drawing.Point(118, 140);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(90, 27);
           this._btnCancel.TabIndex = 35;
           this._btnCancel.Text = "&Cancel";
           this._btnCancel.UseVisualStyleBackColor = true;
           // 
           // RotatePlaneActionDialog
           // 
           this.AcceptButton = this._btnOK;
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.CancelButton = this._btnCancel;
           this.ClientSize = new System.Drawing.Size(238, 182);
           this.Controls.Add(this._btnOK);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this.groupBox1);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "RotatePlaneActionDialog";
           this.Text = "Customize Rotate Plane Dialog";
           this.groupBox1.ResumeLayout(false);
           this.groupBox1.PerformLayout();
           this.ResumeLayout(false);

        }

        #endregion

       private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnOK;
       private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _comboBoxOrientation;
       private System.Windows.Forms.ComboBox _comboBoxAxis;
    }
}