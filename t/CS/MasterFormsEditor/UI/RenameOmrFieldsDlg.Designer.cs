namespace CSMasterFormsEditor.UI
{
    partial class RenameOmrFieldsDlg
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
            this._rbAlpha = new System.Windows.Forms.RadioButton();
            this._rbNum1 = new System.Windows.Forms.RadioButton();
            this._txtPrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._lblName = new System.Windows.Forms.Label();
            this._numStartsWith = new System.Windows.Forms.NumericUpDown();
            this._rbStartsWith = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numStartsWith)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._numStartsWith);
            this.groupBox1.Controls.Add(this._rbAlpha);
            this.groupBox1.Controls.Add(this._rbNum1);
            this.groupBox1.Controls.Add(this._rbStartsWith);
            this.groupBox1.Location = new System.Drawing.Point(154, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Postfix";
            // 
            // _rbAlpha
            // 
            this._rbAlpha.AutoSize = true;
            this._rbAlpha.Location = new System.Drawing.Point(6, 42);
            this._rbAlpha.Name = "_rbAlpha";
            this._rbAlpha.Size = new System.Drawing.Size(72, 17);
            this._rbAlpha.TabIndex = 5;
            this._rbAlpha.Text = "A B C D...";
            this._rbAlpha.UseVisualStyleBackColor = true;
            this._rbAlpha.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
            // 
            // _rbNum1
            // 
            this._rbNum1.AutoSize = true;
            this._rbNum1.Checked = true;
            this._rbNum1.Location = new System.Drawing.Point(6, 19);
            this._rbNum1.Name = "_rbNum1";
            this._rbNum1.Size = new System.Drawing.Size(67, 17);
            this._rbNum1.TabIndex = 5;
            this._rbNum1.TabStop = true;
            this._rbNum1.Text = "1 2 3 4...";
            this._rbNum1.UseVisualStyleBackColor = true;
            this._rbNum1.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
            // 
            // _txtPrefix
            // 
            this._txtPrefix.Location = new System.Drawing.Point(48, 12);
            this._txtPrefix.Name = "_txtPrefix";
            this._txtPrefix.Size = new System.Drawing.Size(100, 20);
            this._txtPrefix.TabIndex = 1;
            this._txtPrefix.Text = "Q1";
            this._txtPrefix.TextChanged += new System.EventHandler(this._txtPrefix_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Prefix";
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(48, 126);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 3;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(137, 126);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 4;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sample Name";
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(18, 71);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(0, 13);
            this._lblName.TabIndex = 6;
            // 
            // _numStartsWith
            // 
            this._numStartsWith.Location = new System.Drawing.Point(58, 88);
            this._numStartsWith.Name = "_numStartsWith";
            this._numStartsWith.Size = new System.Drawing.Size(50, 20);
            this._numStartsWith.TabIndex = 7;
            this._numStartsWith.ValueChanged += new System.EventHandler(this._numStartsWith_ValueChanged);
            // 
            // _rbStartsWith
            // 
            this._rbStartsWith.AutoSize = true;
            this._rbStartsWith.Location = new System.Drawing.Point(7, 66);
            this._rbStartsWith.Name = "_rbStartsWith";
            this._rbStartsWith.Size = new System.Drawing.Size(74, 17);
            this._rbStartsWith.TabIndex = 8;
            this._rbStartsWith.TabStop = true;
            this._rbStartsWith.Text = "Starts with";
            this._rbStartsWith.UseVisualStyleBackColor = true;
            this._rbStartsWith.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
            // 
            // RenameOmrFieldsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 161);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txtPrefix);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenameOmrFieldsDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rename Omr Fields";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numStartsWith)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton _rbAlpha;
        private System.Windows.Forms.RadioButton _rbNum1;
        private System.Windows.Forms.TextBox _txtPrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.NumericUpDown _numStartsWith;
        private System.Windows.Forms.RadioButton _rbStartsWith;
    }
}