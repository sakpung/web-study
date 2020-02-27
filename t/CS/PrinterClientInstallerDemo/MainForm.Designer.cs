namespace PrinterClientInstaller
{
    partial class MainForm
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
           this._grpPrinterInformation = new System.Windows.Forms.GroupBox();
           this._btnRefresh = new System.Windows.Forms.Button();
           this._txtServerName = new System.Windows.Forms.TextBox();
           this._cmbPrinters = new System.Windows.Forms.ComboBox();
           this.label3 = new System.Windows.Forms.Label();
           this._btnBrowse = new System.Windows.Forms.Button();
           this._txtPrinterDll = new System.Windows.Forms.TextBox();
           this.label2 = new System.Windows.Forms.Label();
           this.label1 = new System.Windows.Forms.Label();
           this._btnInstall = new System.Windows.Forms.Button();
           this._grpPrinterInformation.SuspendLayout();
           this.SuspendLayout();
           // 
           // _grpPrinterInformation
           // 
           this._grpPrinterInformation.Controls.Add(this._btnRefresh);
           this._grpPrinterInformation.Controls.Add(this._txtServerName);
           this._grpPrinterInformation.Controls.Add(this._cmbPrinters);
           this._grpPrinterInformation.Controls.Add(this.label3);
           this._grpPrinterInformation.Controls.Add(this._btnBrowse);
           this._grpPrinterInformation.Controls.Add(this._txtPrinterDll);
           this._grpPrinterInformation.Controls.Add(this.label2);
           this._grpPrinterInformation.Controls.Add(this.label1);
           this._grpPrinterInformation.Location = new System.Drawing.Point(12, 12);
           this._grpPrinterInformation.Name = "_grpPrinterInformation";
           this._grpPrinterInformation.Size = new System.Drawing.Size(538, 120);
           this._grpPrinterInformation.TabIndex = 0;
           this._grpPrinterInformation.TabStop = false;
           this._grpPrinterInformation.Text = "Network Printer";
           // 
           // _btnRefresh
           // 
           this._btnRefresh.Enabled = false;
           this._btnRefresh.Location = new System.Drawing.Point(466, 52);
           this._btnRefresh.Name = "_btnRefresh";
           this._btnRefresh.Size = new System.Drawing.Size(58, 23);
           this._btnRefresh.TabIndex = 1;
           this._btnRefresh.Text = "Refresh";
           this._btnRefresh.UseVisualStyleBackColor = true;
           this._btnRefresh.Click += new System.EventHandler(this._btnRefresh_Click);
           // 
           // _txtServerName
           // 
           this._txtServerName.Location = new System.Drawing.Point(105, 24);
           this._txtServerName.Name = "_txtServerName";
           this._txtServerName.Size = new System.Drawing.Size(419, 20);
           this._txtServerName.TabIndex = 0;
           this._txtServerName.TextChanged += new System.EventHandler(this._txtServerName_TextChanged);
           // 
           // _cmbPrinters
           // 
           this._cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this._cmbPrinters.Enabled = false;
           this._cmbPrinters.FormattingEnabled = true;
           this._cmbPrinters.Location = new System.Drawing.Point(105, 54);
           this._cmbPrinters.Name = "_cmbPrinters";
           this._cmbPrinters.Size = new System.Drawing.Size(355, 21);
           this._cmbPrinters.TabIndex = 2;
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(6, 57);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(68, 13);
           this.label3.TabIndex = 23;
           this.label3.Text = "Printer Name";
           // 
           // _btnBrowse
           // 
           this._btnBrowse.Location = new System.Drawing.Point(497, 81);
           this._btnBrowse.Name = "_btnBrowse";
           this._btnBrowse.Size = new System.Drawing.Size(27, 23);
           this._btnBrowse.TabIndex = 3;
           this._btnBrowse.Text = "...";
           this._btnBrowse.UseVisualStyleBackColor = true;
           this._btnBrowse.Click += new System.EventHandler(this._btnBrowse_Click);
           // 
           // _txtPrinterDll
           // 
           this._txtPrinterDll.Location = new System.Drawing.Point(105, 81);
           this._txtPrinterDll.Name = "_txtPrinterDll";
           this._txtPrinterDll.Size = new System.Drawing.Size(386, 20);
           this._txtPrinterDll.TabIndex = 3;
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(6, 86);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(83, 13);
           this.label2.TabIndex = 18;
           this.label2.Text = "Printer Demo Dll";
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(6, 27);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(71, 13);
           this.label1.TabIndex = 6;
           this.label1.Text = "Printer Server";
           // 
           // _btnInstall
           // 
           this._btnInstall.Location = new System.Drawing.Point(423, 156);
           this._btnInstall.Name = "_btnInstall";
           this._btnInstall.Size = new System.Drawing.Size(127, 23);
           this._btnInstall.TabIndex = 2;
           this._btnInstall.Text = "Install";
           this._btnInstall.UseVisualStyleBackColor = true;
           this._btnInstall.Click += new System.EventHandler(this._btnInstall_Click);
           // 
           // MainForm
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(562, 200);
           this.Controls.Add(this._btnInstall);
           this.Controls.Add(this._grpPrinterInformation);
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MaximizeBox = false;
           this.MaximumSize = new System.Drawing.Size(578, 238);
           this.MinimumSize = new System.Drawing.Size(578, 238);
           this.Name = "MainForm";
           this.Text = "Client Printer Installation";
           this.Load += new System.EventHandler(this.MainForm_Load);
           this.Shown += new System.EventHandler(this.MainForm_Shown);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
           this._grpPrinterInformation.ResumeLayout(false);
           this._grpPrinterInformation.PerformLayout();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _grpPrinterInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnInstall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btnBrowse;
        private System.Windows.Forms.TextBox _txtPrinterDll;
        private System.Windows.Forms.ComboBox _cmbPrinters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _btnRefresh;
        private System.Windows.Forms.TextBox _txtServerName;
    }
}