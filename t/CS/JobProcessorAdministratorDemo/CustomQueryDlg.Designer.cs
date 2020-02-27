namespace JobProcessorAdministratorDemo
{
    partial class CustomQueryDlg
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomQueryDlg));
           this._lblCustomQuery = new System.Windows.Forms.Label();
           this._btnOK = new System.Windows.Forms.Button();
           this._btnCancel = new System.Windows.Forms.Button();
           this._cmbCustomQuery = new System.Windows.Forms.ComboBox();
           this._btnClearHistory = new System.Windows.Forms.Button();
           this.SuspendLayout();
           // 
           // _lblCustomQuery
           // 
           this._lblCustomQuery.AutoSize = true;
           this._lblCustomQuery.Location = new System.Drawing.Point(9, 15);
           this._lblCustomQuery.Name = "_lblCustomQuery";
           this._lblCustomQuery.Size = new System.Drawing.Size(73, 13);
           this._lblCustomQuery.TabIndex = 1;
           this._lblCustomQuery.Text = "Custom Query";
           // 
           // _btnOK
           // 
           this._btnOK.Location = new System.Drawing.Point(12, 90);
           this._btnOK.Name = "_btnOK";
           this._btnOK.Size = new System.Drawing.Size(103, 24);
           this._btnOK.TabIndex = 2;
           this._btnOK.Text = "OK";
           this._btnOK.UseVisualStyleBackColor = true;
           this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
           // 
           // _btnCancel
           // 
           this._btnCancel.Location = new System.Drawing.Point(121, 90);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(103, 24);
           this._btnCancel.TabIndex = 3;
           this._btnCancel.Text = "Cancel";
           this._btnCancel.UseVisualStyleBackColor = true;
           this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
           // 
           // _cmbCustomQuery
           // 
           this._cmbCustomQuery.FormattingEnabled = true;
           this._cmbCustomQuery.Location = new System.Drawing.Point(12, 47);
           this._cmbCustomQuery.Name = "_cmbCustomQuery";
           this._cmbCustomQuery.Size = new System.Drawing.Size(574, 21);
           this._cmbCustomQuery.TabIndex = 4;
           // 
           // _btnClearHistory
           // 
           this._btnClearHistory.Location = new System.Drawing.Point(230, 90);
           this._btnClearHistory.Name = "_btnClearHistory";
           this._btnClearHistory.Size = new System.Drawing.Size(103, 24);
           this._btnClearHistory.TabIndex = 5;
           this._btnClearHistory.Text = "Clear History";
           this._btnClearHistory.UseVisualStyleBackColor = true;
           this._btnClearHistory.Click += new System.EventHandler(this._btnClearHistory_Click);
           // 
           // CustomQueryDlg
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(598, 129);
           this.Controls.Add(this._btnClearHistory);
           this.Controls.Add(this._cmbCustomQuery);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this._btnOK);
           this.Controls.Add(this._lblCustomQuery);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MaximizeBox = false;
           this.Name = "CustomQueryDlg";
           this.Text = "Custom Query";
           this.Load += new System.EventHandler(this.CustomQuery_Load);
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblCustomQuery;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.ComboBox _cmbCustomQuery;
        private System.Windows.Forms.Button _btnClearHistory;
    }
}