namespace FusionDemo
{
    partial class LayoutOptions
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
            this._btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this._txtColumns = new NumericTextBox();
            this._txtRows = new NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._interpolateAlwaysImage = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(94, 124);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(72, 26);
            this._btnCancel.TabIndex = 17;
            this._btnCancel.Text = "&Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(12, 124);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(72, 26);
            this._btnOK.TabIndex = 16;
            this._btnOK.Text = "&OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // _btnApply
            // 
            this._btnApply.Location = new System.Drawing.Point(178, 124);
            this._btnApply.Name = "_btnApply";
            this._btnApply.Size = new System.Drawing.Size(72, 26);
            this._btnApply.TabIndex = 19;
            this._btnApply.Text = "&Apply";
            this._btnApply.UseVisualStyleBackColor = true;
            this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._interpolateAlwaysImage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._txtColumns);
            this.groupBox1.Controls.Add(this._txtRows);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 106);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Layout";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "X";
            // 
            // _txtColumns
            // 
            this._txtColumns.Location = new System.Drawing.Point(175, 37);
            this._txtColumns.MaximumAllowed = 8;
            this._txtColumns.MinimumAllowed = 1;
            this._txtColumns.Name = "_txtColumns";
            this._txtColumns.Size = new System.Drawing.Size(51, 20);
            this._txtColumns.TabIndex = 4;
            this._txtColumns.Text = "1";
            this._txtColumns.Value = 1;
            // 
            // _txtRows
            // 
            this._txtRows.Location = new System.Drawing.Point(98, 37);
            this._txtRows.MaximumAllowed = 8;
            this._txtRows.MinimumAllowed = 1;
            this._txtRows.Name = "_txtRows";
            this._txtRows.Size = new System.Drawing.Size(51, 20);
            this._txtRows.TabIndex = 3;
            this._txtRows.Text = "1";
            this._txtRows.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Viewer Layout";
            // 
            // _interpolateAlwaysImage
            // 
            this._interpolateAlwaysImage.AutoSize = true;
            this._interpolateAlwaysImage.Location = new System.Drawing.Point(15, 74);
            this._interpolateAlwaysImage.Name = "_interpolateAlwaysImage";
            this._interpolateAlwaysImage.Size = new System.Drawing.Size(161, 17);
            this._interpolateAlwaysImage.TabIndex = 6;
            this._interpolateAlwaysImage.Text = "Always Interpolate the image";
            this._interpolateAlwaysImage.UseVisualStyleBackColor = true;
            // 
            // LayoutOptions
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(264, 160);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._btnApply);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayoutOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Medical 3D Properties";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnApply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private NumericTextBox _txtColumns;
        private NumericTextBox _txtRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox _interpolateAlwaysImage;
    }
}