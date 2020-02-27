namespace CSMasterFormsEditor.UI
{
    partial class SingleSelectionFieldDlg
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
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._tbName = new System.Windows.Forms.TextBox();
            this._gbFields = new System.Windows.Forms.GroupBox();
            this._gbName = new System.Windows.Forms.GroupBox();
            this._gbName.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(22, 355);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(102, 27);
            this._btnOK.TabIndex = 10;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(130, 355);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(105, 27);
            this._btnCancel.TabIndex = 11;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _tbName
            // 
            this._tbName.Location = new System.Drawing.Point(10, 19);
            this._tbName.Multiline = true;
            this._tbName.Name = "_tbName";
            this._tbName.Size = new System.Drawing.Size(314, 54);
            this._tbName.TabIndex = 0;
            // 
            // _gbFields
            // 
            this._gbFields.AutoSize = true;
            this._gbFields.Location = new System.Drawing.Point(12, 97);
            this._gbFields.Name = "_gbFields";
            this._gbFields.Size = new System.Drawing.Size(330, 252);
            this._gbFields.TabIndex = 8;
            this._gbFields.TabStop = false;
            this._gbFields.Text = "Fields Values";
            // 
            // _gbName
            // 
            this._gbName.Controls.Add(this._tbName);
            this._gbName.Location = new System.Drawing.Point(12, 12);
            this._gbName.Name = "_gbName";
            this._gbName.Size = new System.Drawing.Size(330, 79);
            this._gbName.TabIndex = 9;
            this._gbName.TabStop = false;
            this._gbName.Text = "Field Name";
            // 
            // SingleSelectionFieldDlg
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(361, 394);
            this.Controls.Add(this._gbName);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._gbFields);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SingleSelectionFieldDlg";
            this.Text = "Single Selection";
            this.Load += new System.EventHandler(this.SingleSelectionDlg_Load);
            this._gbName.ResumeLayout(false);
            this._gbName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.TextBox _tbName;
        private System.Windows.Forms.GroupBox _gbFields;
        private System.Windows.Forms.GroupBox _gbName;
    }
}