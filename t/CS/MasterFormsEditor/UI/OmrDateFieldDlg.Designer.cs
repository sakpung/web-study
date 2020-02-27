namespace CSMasterFormsEditor.UI
{
    partial class OmrDateFieldDlg
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
         this._gbName = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this._tbName = new System.Windows.Forms.TextBox();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._gbFields = new System.Windows.Forms.GroupBox();
         this._btnEdit = new System.Windows.Forms.Button();
         this._lbSelection = new System.Windows.Forms.ListBox();
         this._gbName.SuspendLayout();
         this._gbFields.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbName
         // 
         this._gbName.Controls.Add(this.label1);
         this._gbName.Controls.Add(this._tbName);
         this._gbName.Location = new System.Drawing.Point(12, 12);
         this._gbName.Name = "_gbName";
         this._gbName.Size = new System.Drawing.Size(330, 57);
         this._gbName.TabIndex = 13;
         this._gbName.TabStop = false;
         this._gbName.Text = "Field Properties";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(22, 22);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(60, 13);
         this.label1.TabIndex = 16;
         this.label1.Text = "Field Name";
         // 
         // _tbName
         // 
         this._tbName.Location = new System.Drawing.Point(118, 19);
         this._tbName.Name = "_tbName";
         this._tbName.Size = new System.Drawing.Size(203, 20);
         this._tbName.TabIndex = 16;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(130, 304);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(105, 27);
         this._btnCancel.TabIndex = 15;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(22, 304);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(102, 27);
         this._btnOK.TabIndex = 14;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _gbFields
         // 
         this._gbFields.AutoSize = true;
         this._gbFields.Controls.Add(this._btnEdit);
         this._gbFields.Controls.Add(this._lbSelection);
         this._gbFields.Location = new System.Drawing.Point(12, 75);
         this._gbFields.Name = "_gbFields";
         this._gbFields.Size = new System.Drawing.Size(330, 223);
         this._gbFields.TabIndex = 12;
         this._gbFields.TabStop = false;
         this._gbFields.Text = "Fields Values";
         // 
         // _btnEdit
         // 
         this._btnEdit.Location = new System.Drawing.Point(246, 39);
         this._btnEdit.Name = "_btnEdit";
         this._btnEdit.Size = new System.Drawing.Size(75, 23);
         this._btnEdit.TabIndex = 16;
         this._btnEdit.Text = "Edit";
         this._btnEdit.UseVisualStyleBackColor = true;
         this._btnEdit.Click += new System.EventHandler(this._btnEdit_Click);
         // 
         // _lbSelection
         // 
         this._lbSelection.FormattingEnabled = true;
         this._lbSelection.Location = new System.Drawing.Point(10, 28);
         this._lbSelection.Name = "_lbSelection";
         this._lbSelection.Size = new System.Drawing.Size(213, 173);
         this._lbSelection.TabIndex = 0;
         // 
         // OmrDateFieldDlg
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoScroll = true;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(364, 341);
         this.Controls.Add(this._gbName);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._gbFields);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "OmrDateFieldDlg";
         this.Text = "Omr Date Field";
         this._gbName.ResumeLayout(false);
         this._gbName.PerformLayout();
         this._gbFields.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbName;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.GroupBox _gbFields;
        private System.Windows.Forms.TextBox _tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnEdit;
        private System.Windows.Forms.ListBox _lbSelection;
    }
}