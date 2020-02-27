namespace ServerPrinterConfigDemo.UI
{
    partial class FrmMain
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
           this._grpNetworkPrinters = new System.Windows.Forms.GroupBox();
           this._btnUninstall = new System.Windows.Forms.Button();
           this._ckSharePrinter = new System.Windows.Forms.CheckBox();
           this._ckNetworkEnabled = new System.Windows.Forms.CheckBox();
           this._btnAddNewPrinter = new System.Windows.Forms.Button();
           this._cmbNetworkPrinters = new System.Windows.Forms.ComboBox();
           this.label1 = new System.Windows.Forms.Label();
           this._grpPrinterSettings = new System.Windows.Forms.GroupBox();
           this._btnSave = new System.Windows.Forms.Button();
           this._grpSaveForamats = new System.Windows.Forms.GroupBox();
           this.label7 = new System.Windows.Forms.Label();
           this._btnBrowseTxt = new System.Windows.Forms.Button();
           this._txtLocationTxt = new System.Windows.Forms.TextBox();
           this.label6 = new System.Windows.Forms.Label();
           this._btnBrowseXps = new System.Windows.Forms.Button();
           this._txtLocationXps = new System.Windows.Forms.TextBox();
           this.label5 = new System.Windows.Forms.Label();
           this._btnBrowseDoc = new System.Windows.Forms.Button();
           this._txtLocationDoc = new System.Windows.Forms.TextBox();
           this.label3 = new System.Windows.Forms.Label();
           this._btnBrowsePdf = new System.Windows.Forms.Button();
           this._txtLocationPDF = new System.Windows.Forms.TextBox();
           this.label4 = new System.Windows.Forms.Label();
           this.label2 = new System.Windows.Forms.Label();
           this._txtPrinterDescription = new System.Windows.Forms.TextBox();
           this._grpNetworkPrinters.SuspendLayout();
           this._grpPrinterSettings.SuspendLayout();
           this._grpSaveForamats.SuspendLayout();
           this.SuspendLayout();
           // 
           // _grpNetworkPrinters
           // 
           this._grpNetworkPrinters.Controls.Add(this._btnUninstall);
           this._grpNetworkPrinters.Controls.Add(this._ckSharePrinter);
           this._grpNetworkPrinters.Controls.Add(this._ckNetworkEnabled);
           this._grpNetworkPrinters.Controls.Add(this._btnAddNewPrinter);
           this._grpNetworkPrinters.Controls.Add(this._cmbNetworkPrinters);
           this._grpNetworkPrinters.Controls.Add(this.label1);
           this._grpNetworkPrinters.Location = new System.Drawing.Point(12, 12);
           this._grpNetworkPrinters.Name = "_grpNetworkPrinters";
           this._grpNetworkPrinters.Size = new System.Drawing.Size(460, 153);
           this._grpNetworkPrinters.TabIndex = 6;
           this._grpNetworkPrinters.TabStop = false;
           this._grpNetworkPrinters.Text = "Network Printers";
           // 
           // _btnUninstall
           // 
           this._btnUninstall.Location = new System.Drawing.Point(356, 57);
           this._btnUninstall.Name = "_btnUninstall";
           this._btnUninstall.Size = new System.Drawing.Size(98, 21);
           this._btnUninstall.TabIndex = 11;
           this._btnUninstall.Text = "Uninstall Printer";
           this._btnUninstall.UseVisualStyleBackColor = true;
           this._btnUninstall.Click += new System.EventHandler(this._btnUninstall_Click);
           // 
           // _ckSharePrinter
           // 
           this._ckSharePrinter.AutoSize = true;
           this._ckSharePrinter.Location = new System.Drawing.Point(6, 129);
           this._ckSharePrinter.Name = "_ckSharePrinter";
           this._ckSharePrinter.Size = new System.Drawing.Size(130, 17);
           this._ckSharePrinter.TabIndex = 10;
           this._ckSharePrinter.Text = "Share Network Printer";
           this._ckSharePrinter.UseVisualStyleBackColor = true;
           this._ckSharePrinter.CheckedChanged += new System.EventHandler(this._ckSharePrinter_CheckedChanged);
           // 
           // _ckNetworkEnabled
           // 
           this._ckNetworkEnabled.AutoSize = true;
           this._ckNetworkEnabled.Location = new System.Drawing.Point(6, 106);
           this._ckNetworkEnabled.Name = "_ckNetworkEnabled";
           this._ckNetworkEnabled.Size = new System.Drawing.Size(140, 17);
           this._ckNetworkEnabled.TabIndex = 9;
           this._ckNetworkEnabled.Text = "Enable Network Printing";
           this._ckNetworkEnabled.UseVisualStyleBackColor = true;
           this._ckNetworkEnabled.CheckedChanged += new System.EventHandler(this._ckNetworkEnabled_CheckedChanged);
           // 
           // _btnAddNewPrinter
           // 
           this._btnAddNewPrinter.Location = new System.Drawing.Point(356, 30);
           this._btnAddNewPrinter.Name = "_btnAddNewPrinter";
           this._btnAddNewPrinter.Size = new System.Drawing.Size(98, 21);
           this._btnAddNewPrinter.TabIndex = 8;
           this._btnAddNewPrinter.Text = "Install Printer";
           this._btnAddNewPrinter.UseVisualStyleBackColor = true;
           this._btnAddNewPrinter.Click += new System.EventHandler(this._btnAddNewPrinter_Click);
           // 
           // _cmbNetworkPrinters
           // 
           this._cmbNetworkPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this._cmbNetworkPrinters.FormattingEnabled = true;
           this._cmbNetworkPrinters.Location = new System.Drawing.Point(80, 31);
           this._cmbNetworkPrinters.Name = "_cmbNetworkPrinters";
           this._cmbNetworkPrinters.Size = new System.Drawing.Size(270, 21);
           this._cmbNetworkPrinters.TabIndex = 7;
           this._cmbNetworkPrinters.SelectedIndexChanged += new System.EventHandler(this._cmbNetworkPrinters_SelectedIndexChanged);
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(6, 34);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(68, 13);
           this.label1.TabIndex = 6;
           this.label1.Text = "Printer Name";
           // 
           // _grpPrinterSettings
           // 
           this._grpPrinterSettings.Controls.Add(this._btnSave);
           this._grpPrinterSettings.Controls.Add(this._grpSaveForamats);
           this._grpPrinterSettings.Controls.Add(this.label2);
           this._grpPrinterSettings.Controls.Add(this._txtPrinterDescription);
           this._grpPrinterSettings.Location = new System.Drawing.Point(12, 175);
           this._grpPrinterSettings.Name = "_grpPrinterSettings";
           this._grpPrinterSettings.Size = new System.Drawing.Size(460, 380);
           this._grpPrinterSettings.TabIndex = 8;
           this._grpPrinterSettings.TabStop = false;
           this._grpPrinterSettings.Text = "Printer Settings";
           // 
           // _btnSave
           // 
           this._btnSave.Location = new System.Drawing.Point(327, 344);
           this._btnSave.Name = "_btnSave";
           this._btnSave.Size = new System.Drawing.Size(127, 23);
           this._btnSave.TabIndex = 21;
           this._btnSave.Text = "Save";
           this._btnSave.UseVisualStyleBackColor = true;
           this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
           // 
           // _grpSaveForamats
           // 
           this._grpSaveForamats.Controls.Add(this.label7);
           this._grpSaveForamats.Controls.Add(this._btnBrowseTxt);
           this._grpSaveForamats.Controls.Add(this._txtLocationTxt);
           this._grpSaveForamats.Controls.Add(this.label6);
           this._grpSaveForamats.Controls.Add(this._btnBrowseXps);
           this._grpSaveForamats.Controls.Add(this._txtLocationXps);
           this._grpSaveForamats.Controls.Add(this.label5);
           this._grpSaveForamats.Controls.Add(this._btnBrowseDoc);
           this._grpSaveForamats.Controls.Add(this._txtLocationDoc);
           this._grpSaveForamats.Controls.Add(this.label3);
           this._grpSaveForamats.Controls.Add(this._btnBrowsePdf);
           this._grpSaveForamats.Controls.Add(this._txtLocationPDF);
           this._grpSaveForamats.Controls.Add(this.label4);
           this._grpSaveForamats.Location = new System.Drawing.Point(9, 134);
           this._grpSaveForamats.Name = "_grpSaveForamats";
           this._grpSaveForamats.Size = new System.Drawing.Size(426, 179);
           this._grpSaveForamats.TabIndex = 15;
           this._grpSaveForamats.TabStop = false;
           this._grpSaveForamats.Text = "Save Formats";
           // 
           // label7
           // 
           this.label7.AutoSize = true;
           this.label7.Location = new System.Drawing.Point(6, 137);
           this.label7.Name = "label7";
           this.label7.Size = new System.Drawing.Size(28, 13);
           this.label7.TabIndex = 31;
           this.label7.Text = "Text";
           // 
           // _btnBrowseTxt
           // 
           this._btnBrowseTxt.Location = new System.Drawing.Point(388, 134);
           this._btnBrowseTxt.Name = "_btnBrowseTxt";
           this._btnBrowseTxt.Size = new System.Drawing.Size(28, 23);
           this._btnBrowseTxt.TabIndex = 30;
           this._btnBrowseTxt.Tag = "3";
           this._btnBrowseTxt.Text = "...";
           this._btnBrowseTxt.UseVisualStyleBackColor = true;
           this._btnBrowseTxt.Click += new System.EventHandler(this._btnBrowse_Click);
           // 
           // _txtLocationTxt
           // 
           this._txtLocationTxt.Location = new System.Drawing.Point(40, 134);
           this._txtLocationTxt.Name = "_txtLocationTxt";
           this._txtLocationTxt.Size = new System.Drawing.Size(342, 20);
           this._txtLocationTxt.TabIndex = 29;
           this._txtLocationTxt.Tag = "3";
           this._txtLocationTxt.TextChanged += new System.EventHandler(this._txtLocation_TextChanged);
           this._txtLocationTxt.Leave += new System.EventHandler(this._txtLocation_Leave);
           // 
           // label6
           // 
           this.label6.AutoSize = true;
           this.label6.Location = new System.Drawing.Point(6, 111);
           this.label6.Name = "label6";
           this.label6.Size = new System.Drawing.Size(25, 13);
           this.label6.TabIndex = 28;
           this.label6.Text = "Xps";
           // 
           // _btnBrowseXps
           // 
           this._btnBrowseXps.Location = new System.Drawing.Point(388, 108);
           this._btnBrowseXps.Name = "_btnBrowseXps";
           this._btnBrowseXps.Size = new System.Drawing.Size(28, 23);
           this._btnBrowseXps.TabIndex = 27;
           this._btnBrowseXps.Tag = "2";
           this._btnBrowseXps.Text = "...";
           this._btnBrowseXps.UseVisualStyleBackColor = true;
           this._btnBrowseXps.Click += new System.EventHandler(this._btnBrowse_Click);
           // 
           // _txtLocationXps
           // 
           this._txtLocationXps.Location = new System.Drawing.Point(40, 108);
           this._txtLocationXps.Name = "_txtLocationXps";
           this._txtLocationXps.Size = new System.Drawing.Size(342, 20);
           this._txtLocationXps.TabIndex = 26;
           this._txtLocationXps.Tag = "2";
           this._txtLocationXps.TextChanged += new System.EventHandler(this._txtLocation_TextChanged);
           this._txtLocationXps.Leave += new System.EventHandler(this._txtLocation_Leave);
           // 
           // label5
           // 
           this.label5.AutoSize = true;
           this.label5.Location = new System.Drawing.Point(6, 85);
           this.label5.Name = "label5";
           this.label5.Size = new System.Drawing.Size(27, 13);
           this.label5.TabIndex = 25;
           this.label5.Text = "Doc";
           // 
           // _btnBrowseDoc
           // 
           this._btnBrowseDoc.Location = new System.Drawing.Point(388, 82);
           this._btnBrowseDoc.Name = "_btnBrowseDoc";
           this._btnBrowseDoc.Size = new System.Drawing.Size(28, 23);
           this._btnBrowseDoc.TabIndex = 24;
           this._btnBrowseDoc.Tag = "1";
           this._btnBrowseDoc.Text = "...";
           this._btnBrowseDoc.UseVisualStyleBackColor = true;
           this._btnBrowseDoc.Click += new System.EventHandler(this._btnBrowse_Click);
           // 
           // _txtLocationDoc
           // 
           this._txtLocationDoc.Location = new System.Drawing.Point(40, 82);
           this._txtLocationDoc.Name = "_txtLocationDoc";
           this._txtLocationDoc.Size = new System.Drawing.Size(342, 20);
           this._txtLocationDoc.TabIndex = 23;
           this._txtLocationDoc.Tag = "1";
           this._txtLocationDoc.TextChanged += new System.EventHandler(this._txtLocation_TextChanged);
           this._txtLocationDoc.Leave += new System.EventHandler(this._txtLocation_Leave);
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(6, 59);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(23, 13);
           this.label3.TabIndex = 22;
           this.label3.Text = "Pdf";
           // 
           // _btnBrowsePdf
           // 
           this._btnBrowsePdf.Location = new System.Drawing.Point(388, 56);
           this._btnBrowsePdf.Name = "_btnBrowsePdf";
           this._btnBrowsePdf.Size = new System.Drawing.Size(28, 23);
           this._btnBrowsePdf.TabIndex = 21;
           this._btnBrowsePdf.Tag = "0";
           this._btnBrowsePdf.Text = "...";
           this._btnBrowsePdf.UseVisualStyleBackColor = true;
           this._btnBrowsePdf.Click += new System.EventHandler(this._btnBrowse_Click);
           // 
           // _txtLocationPDF
           // 
           this._txtLocationPDF.Location = new System.Drawing.Point(40, 56);
           this._txtLocationPDF.Name = "_txtLocationPDF";
           this._txtLocationPDF.Size = new System.Drawing.Size(342, 20);
           this._txtLocationPDF.TabIndex = 18;
           this._txtLocationPDF.Tag = "0";
           this._txtLocationPDF.TextChanged += new System.EventHandler(this._txtLocation_TextChanged);
           this._txtLocationPDF.Leave += new System.EventHandler(this._txtLocation_Leave);
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Location = new System.Drawing.Point(37, 29);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(76, 13);
           this.label4.TabIndex = 17;
           this.label4.Text = "Save Location";
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(6, 29);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(93, 13);
           this.label2.TabIndex = 9;
           this.label2.Text = "Printer Description";
           // 
           // _txtPrinterDescription
           // 
           this._txtPrinterDescription.Location = new System.Drawing.Point(6, 45);
           this._txtPrinterDescription.Multiline = true;
           this._txtPrinterDescription.Name = "_txtPrinterDescription";
           this._txtPrinterDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
           this._txtPrinterDescription.Size = new System.Drawing.Size(429, 74);
           this._txtPrinterDescription.TabIndex = 8;
           this._txtPrinterDescription.TextChanged += new System.EventHandler(this._txtPrinterDescription_TextChanged);
           // 
           // FrmMain
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(482, 565);
           this.Controls.Add(this._grpPrinterSettings);
           this.Controls.Add(this._grpNetworkPrinters);
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MaximizeBox = false;
           this.MaximumSize = new System.Drawing.Size(498, 603);
           this.MinimumSize = new System.Drawing.Size(498, 603);
           this.Name = "FrmMain";
           this.Text = "FrmMain";
           this.Shown += new System.EventHandler(this.FrmMain_Shown);
           this._grpNetworkPrinters.ResumeLayout(false);
           this._grpNetworkPrinters.PerformLayout();
           this._grpPrinterSettings.ResumeLayout(false);
           this._grpPrinterSettings.PerformLayout();
           this._grpSaveForamats.ResumeLayout(false);
           this._grpSaveForamats.PerformLayout();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _grpNetworkPrinters;
        private System.Windows.Forms.Button _btnAddNewPrinter;
        private System.Windows.Forms.ComboBox _cmbNetworkPrinters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox _grpPrinterSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtPrinterDescription;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.GroupBox _grpSaveForamats;
        private System.Windows.Forms.TextBox _txtLocationPDF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox _ckNetworkEnabled;
        private System.Windows.Forms.Button _btnBrowsePdf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button _btnBrowseTxt;
        private System.Windows.Forms.TextBox _txtLocationTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button _btnBrowseXps;
        private System.Windows.Forms.TextBox _txtLocationXps;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button _btnBrowseDoc;
        private System.Windows.Forms.TextBox _txtLocationDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox _ckSharePrinter;
        private System.Windows.Forms.Button _btnUninstall;
    }
}