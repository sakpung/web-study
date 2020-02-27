namespace Leadtools.Dicom.Server.Manager.Dialogs
{
    partial class EditAeTitleDialog
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAeTitleDialog));
           this.AETitle = new System.Windows.Forms.TextBox();
           this.labelAeTitle = new System.Windows.Forms.Label();
           this.radioButtonHost = new System.Windows.Forms.RadioButton();
           this.radioButtonIp = new System.Windows.Forms.RadioButton();
           this.Hostname = new System.Windows.Forms.TextBox();
           this.textboxIPAddress = new System.Windows.Forms.TextBox();
           this.labelPort = new System.Windows.Forms.Label();
           this.Port = new System.Windows.Forms.NumericUpDown();
           this.SecurePort = new System.Windows.Forms.NumericUpDown();
           this.labelSecurePort = new System.Windows.Forms.Label();
           this.buttonOk = new System.Windows.Forms.Button();
           this.buttonCancel = new System.Windows.Forms.Button();
           ((System.ComponentModel.ISupportInitialize)(this.Port)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.SecurePort)).BeginInit();
           this.SuspendLayout();
           // 
           // AETitle
           // 
           this.AETitle.Location = new System.Drawing.Point(96, 12);
           this.AETitle.Name = "AETitle";
           this.AETitle.Size = new System.Drawing.Size(191, 20);
           this.AETitle.TabIndex = 2;
           this.AETitle.TextChanged += new System.EventHandler(this.AETitle_TextChanged);
           // 
           // labelAeTitle
           // 
           this.labelAeTitle.AutoSize = true;
           this.labelAeTitle.Location = new System.Drawing.Point(43, 16);
           this.labelAeTitle.Name = "labelAeTitle";
           this.labelAeTitle.Size = new System.Drawing.Size(47, 13);
           this.labelAeTitle.TabIndex = 1;
           this.labelAeTitle.Text = "AE Title:";
           // 
           // radioButtonHost
           // 
           this.radioButtonHost.AutoSize = true;
           this.radioButtonHost.Location = new System.Drawing.Point(12, 40);
           this.radioButtonHost.Name = "radioButtonHost";
           this.radioButtonHost.Size = new System.Drawing.Size(81, 17);
           this.radioButtonHost.TabIndex = 3;
           this.radioButtonHost.TabStop = true;
           this.radioButtonHost.Text = "Host Name:";
           this.radioButtonHost.UseVisualStyleBackColor = true;
           this.radioButtonHost.CheckedChanged += new System.EventHandler(this.radioButtonHost_CheckedChanged);
           // 
           // radioButtonIp
           // 
           this.radioButtonIp.AutoSize = true;
           this.radioButtonIp.Location = new System.Drawing.Point(12, 66);
           this.radioButtonIp.Name = "radioButtonIp";
           this.radioButtonIp.Size = new System.Drawing.Size(79, 17);
           this.radioButtonIp.TabIndex = 4;
           this.radioButtonIp.TabStop = true;
           this.radioButtonIp.Text = "IP Address:";
           this.radioButtonIp.UseVisualStyleBackColor = true;
           this.radioButtonIp.CheckedChanged += new System.EventHandler(this.radioButtonIp_CheckedChanged);
           // 
           // Hostname
           // 
           this.Hostname.Location = new System.Drawing.Point(96, 38);
           this.Hostname.Name = "Hostname";
           this.Hostname.Size = new System.Drawing.Size(191, 20);
           this.Hostname.TabIndex = 5;
           this.Hostname.TextChanged += new System.EventHandler(this.Hostname_TextChanged);
           // 
           // IPAddress
           // 
           this.textboxIPAddress.Location = new System.Drawing.Point(96, 64);
           this.textboxIPAddress.MaxLength = 39;
           this.textboxIPAddress.Name = "IPAddress";
           this.textboxIPAddress.Size = new System.Drawing.Size(191, 20);
           this.textboxIPAddress.TabIndex = 6;
           this.textboxIPAddress.TextChanged += new System.EventHandler(this.IPAddress_TextChanged);
           this.textboxIPAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPAddress_KeyPress);
           // 
           // labelPort
           // 
           this.labelPort.AutoSize = true;
           this.labelPort.Location = new System.Drawing.Point(61, 94);
           this.labelPort.Name = "labelPort";
           this.labelPort.Size = new System.Drawing.Size(29, 13);
           this.labelPort.TabIndex = 7;
           this.labelPort.Text = "Port:";
           // 
           // Port
           // 
           this.Port.Location = new System.Drawing.Point(96, 90);
           this.Port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
           this.Port.Name = "Port";
           this.Port.Size = new System.Drawing.Size(54, 20);
           this.Port.TabIndex = 8;
           // 
           // SecurePort
           // 
           this.SecurePort.Location = new System.Drawing.Point(233, 90);
           this.SecurePort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
           this.SecurePort.Name = "SecurePort";
           this.SecurePort.Size = new System.Drawing.Size(54, 20);
           this.SecurePort.TabIndex = 10;
           // 
           // labelSecurePort
           // 
           this.labelSecurePort.AutoSize = true;
           this.labelSecurePort.Location = new System.Drawing.Point(161, 94);
           this.labelSecurePort.Name = "labelSecurePort";
           this.labelSecurePort.Size = new System.Drawing.Size(66, 13);
           this.labelSecurePort.TabIndex = 9;
           this.labelSecurePort.Text = "Secure Port:";
           // 
           // buttonOk
           // 
           this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.buttonOk.Location = new System.Drawing.Point(131, 137);
           this.buttonOk.Name = "buttonOk";
           this.buttonOk.Size = new System.Drawing.Size(75, 23);
           this.buttonOk.TabIndex = 11;
           this.buttonOk.Text = "OK";
           this.buttonOk.UseVisualStyleBackColor = true;
           // 
           // buttonCancel
           // 
           this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.buttonCancel.Location = new System.Drawing.Point(212, 137);
           this.buttonCancel.Name = "buttonCancel";
           this.buttonCancel.Size = new System.Drawing.Size(75, 23);
           this.buttonCancel.TabIndex = 12;
           this.buttonCancel.Text = "Cancel";
           this.buttonCancel.UseVisualStyleBackColor = true;
           // 
           // EditAeTitleDialog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.CancelButton = this.buttonCancel;
           this.ClientSize = new System.Drawing.Size(304, 172);
           this.Controls.Add(this.buttonCancel);
           this.Controls.Add(this.buttonOk);
           this.Controls.Add(this.SecurePort);
           this.Controls.Add(this.labelSecurePort);
           this.Controls.Add(this.Port);
           this.Controls.Add(this.labelPort);
           this.Controls.Add(this.textboxIPAddress);
           this.Controls.Add(this.Hostname);
           this.Controls.Add(this.radioButtonIp);
           this.Controls.Add(this.radioButtonHost);
           this.Controls.Add(this.AETitle);
           this.Controls.Add(this.labelAeTitle);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "EditAeTitleDialog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "EditAeTitleDialog";
           this.Load += new System.EventHandler(this.EditAeTitleDialog_Load);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditAeTitleDialog_FormClosing);
           ((System.ComponentModel.ISupportInitialize)(this.Port)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.SecurePort)).EndInit();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AETitle;
        private System.Windows.Forms.Label labelAeTitle;
        private System.Windows.Forms.RadioButton radioButtonHost;
        private System.Windows.Forms.RadioButton radioButtonIp;
       private System.Windows.Forms.TextBox Hostname;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.NumericUpDown Port;
        private System.Windows.Forms.NumericUpDown SecurePort;
        private System.Windows.Forms.Label labelSecurePort;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
       private System.Windows.Forms.TextBox textboxIPAddress;
    }
}