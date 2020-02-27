namespace ManagedPrinterClientDemo
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
           this._grpNetworkPrinters = new System.Windows.Forms.GroupBox();
           this._txtPrinterName = new System.Windows.Forms.TextBox();
           this.label1 = new System.Windows.Forms.Label();
           this._grpPrinterSettings = new System.Windows.Forms.GroupBox();
           this._grpSaveForamats = new System.Windows.Forms.GroupBox();
           this._txtSavePath = new System.Windows.Forms.TextBox();
           this.label3 = new System.Windows.Forms.Label();
           this._txtSaveName = new System.Windows.Forms.TextBox();
           this.label4 = new System.Windows.Forms.Label();
           this._cmbFileFormats = new System.Windows.Forms.ComboBox();
           this._lblFileFormat = new System.Windows.Forms.Label();
           this.label2 = new System.Windows.Forms.Label();
           this._txtPrinterDescription = new System.Windows.Forms.TextBox();
           this._btnOk = new System.Windows.Forms.Button();
           this._btnCancel = new System.Windows.Forms.Button();
           this._grpNetworkPrinters.SuspendLayout();
           this._grpPrinterSettings.SuspendLayout();
           this._grpSaveForamats.SuspendLayout();
           this.SuspendLayout();
           // 
           // _grpNetworkPrinters
           // 
           this._grpNetworkPrinters.Controls.Add(this._txtPrinterName);
           this._grpNetworkPrinters.Controls.Add(this.label1);
           this._grpNetworkPrinters.Location = new System.Drawing.Point(12, 12);
           this._grpNetworkPrinters.Name = "_grpNetworkPrinters";
           this._grpNetworkPrinters.Size = new System.Drawing.Size(460, 61);
           this._grpNetworkPrinters.TabIndex = 7;
           this._grpNetworkPrinters.TabStop = false;
           this._grpNetworkPrinters.Text = "Network Printer";
           // 
           // _txtPrinterName
           // 
           this._txtPrinterName.BackColor = System.Drawing.Color.White;
           this._txtPrinterName.Enabled = false;
           this._txtPrinterName.Location = new System.Drawing.Point(83, 24);
           this._txtPrinterName.Name = "_txtPrinterName";
           this._txtPrinterName.ReadOnly = true;
           this._txtPrinterName.Size = new System.Drawing.Size(371, 20);
           this._txtPrinterName.TabIndex = 19;
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(6, 27);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(68, 13);
           this.label1.TabIndex = 6;
           this.label1.Text = "Printer Name";
           // 
           // _grpPrinterSettings
           // 
           this._grpPrinterSettings.Controls.Add(this._grpSaveForamats);
           this._grpPrinterSettings.Controls.Add(this.label2);
           this._grpPrinterSettings.Controls.Add(this._txtPrinterDescription);
           this._grpPrinterSettings.Location = new System.Drawing.Point(12, 79);
           this._grpPrinterSettings.Name = "_grpPrinterSettings";
           this._grpPrinterSettings.Size = new System.Drawing.Size(460, 285);
           this._grpPrinterSettings.TabIndex = 9;
           this._grpPrinterSettings.TabStop = false;
           this._grpPrinterSettings.Text = "Printer Settings";
           // 
           // _grpSaveForamats
           // 
           this._grpSaveForamats.Controls.Add(this._txtSavePath);
           this._grpSaveForamats.Controls.Add(this.label3);
           this._grpSaveForamats.Controls.Add(this._txtSaveName);
           this._grpSaveForamats.Controls.Add(this.label4);
           this._grpSaveForamats.Controls.Add(this._cmbFileFormats);
           this._grpSaveForamats.Controls.Add(this._lblFileFormat);
           this._grpSaveForamats.Location = new System.Drawing.Point(9, 131);
           this._grpSaveForamats.Name = "_grpSaveForamats";
           this._grpSaveForamats.Size = new System.Drawing.Size(445, 133);
           this._grpSaveForamats.TabIndex = 0;
           this._grpSaveForamats.TabStop = false;
           this._grpSaveForamats.Text = "Save Formats";
           // 
           // _txtSavePath
           // 
           this._txtSavePath.BackColor = System.Drawing.Color.White;
           this._txtSavePath.Enabled = false;
           this._txtSavePath.Location = new System.Drawing.Point(110, 43);
           this._txtSavePath.Name = "_txtSavePath";
           this._txtSavePath.Size = new System.Drawing.Size(316, 20);
           this._txtSavePath.TabIndex = 20;
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(107, 27);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(57, 13);
           this.label3.TabIndex = 19;
           this.label3.Text = "Save Path";
           // 
           // _txtSaveName
           // 
           this._txtSaveName.Location = new System.Drawing.Point(9, 92);
           this._txtSaveName.Name = "_txtSaveName";
           this._txtSaveName.Size = new System.Drawing.Size(417, 20);
           this._txtSaveName.TabIndex = 0;
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Location = new System.Drawing.Point(6, 76);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(54, 13);
           this.label4.TabIndex = 17;
           this.label4.Text = "File Name";
           // 
           // _cmbFileFormats
           // 
           this._cmbFileFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this._cmbFileFormats.FormattingEnabled = true;
           this._cmbFileFormats.Location = new System.Drawing.Point(6, 43);
           this._cmbFileFormats.Name = "_cmbFileFormats";
           this._cmbFileFormats.Size = new System.Drawing.Size(84, 21);
           this._cmbFileFormats.TabIndex = 16;
           this._cmbFileFormats.SelectedIndexChanged += new System.EventHandler(this._cmbFileFormats_SelectedIndexChanged);
           // 
           // _lblFileFormat
           // 
           this._lblFileFormat.AutoSize = true;
           this._lblFileFormat.Location = new System.Drawing.Point(6, 27);
           this._lblFileFormat.Name = "_lblFileFormat";
           this._lblFileFormat.Size = new System.Drawing.Size(58, 13);
           this._lblFileFormat.TabIndex = 15;
           this._lblFileFormat.Text = "File Foramt";
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
           this._txtPrinterDescription.BackColor = System.Drawing.Color.White;
           this._txtPrinterDescription.Location = new System.Drawing.Point(9, 51);
           this._txtPrinterDescription.Multiline = true;
           this._txtPrinterDescription.Name = "_txtPrinterDescription";
           this._txtPrinterDescription.ReadOnly = true;
           this._txtPrinterDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
           this._txtPrinterDescription.Size = new System.Drawing.Size(445, 74);
           this._txtPrinterDescription.TabIndex = 8;
           // 
           // _btnOk
           // 
           this._btnOk.Location = new System.Drawing.Point(12, 370);
           this._btnOk.Name = "_btnOk";
           this._btnOk.Size = new System.Drawing.Size(127, 23);
           this._btnOk.TabIndex = 21;
           this._btnOk.Text = "Ok";
           this._btnOk.UseVisualStyleBackColor = true;
           this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
           // 
           // _btnCancel
           // 
           this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this._btnCancel.Location = new System.Drawing.Point(345, 370);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(127, 23);
           this._btnCancel.TabIndex = 20;
           this._btnCancel.Text = "Cancel";
           this._btnCancel.UseVisualStyleBackColor = true;
           // 
           // MainForm
           // 
           this.AcceptButton = this._btnOk;
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.CancelButton = this._btnCancel;
           this.ClientSize = new System.Drawing.Size(491, 407);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this._btnOk);
           this.Controls.Add(this._grpPrinterSettings);
           this.Controls.Add(this._grpNetworkPrinters);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MaximizeBox = false;
           this.Name = "MainForm";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           this.Text = "MainForm";
           this.Load += new System.EventHandler(this.MainForm_Load);
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
        private System.Windows.Forms.TextBox _txtPrinterName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox _grpPrinterSettings;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.GroupBox _grpSaveForamats;
        private System.Windows.Forms.TextBox _txtSaveName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _cmbFileFormats;
        private System.Windows.Forms.Label _lblFileFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtPrinterDescription;
        private System.Windows.Forms.TextBox _txtSavePath;
        private System.Windows.Forms.Label label3;
    }
}