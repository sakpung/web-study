namespace DicomDemo
{
    partial class OptionsDialog
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
           this.panel1 = new System.Windows.Forms.Panel();
           this.OkButton = new System.Windows.Forms.Button();
           this.OptionsCancelButton = new System.Windows.Forms.Button();
           this.DicomTab = new System.Windows.Forms.TabPage();
           this._groupBoxClient = new System.Windows.Forms.GroupBox();
           this._textBoxTimeout = new System.Windows.Forms.TextBox();
           this._textBoxClientAE = new System.Windows.Forms.TextBox();
           this._labelTimeout = new System.Windows.Forms.Label();
           this._labelClientAE = new System.Windows.Forms.Label();
           this._groupBoxServer = new System.Windows.Forms.GroupBox();
           this.VerifyButton = new System.Windows.Forms.Button();
           this._textBoxServerIP = new System.Windows.Forms.TextBox();
           this._textBoxServerPort = new System.Windows.Forms.TextBox();
           this._textBoxServerAE = new System.Windows.Forms.TextBox();
           this._labelServerPort = new System.Windows.Forms.Label();
           this._labelServerIP = new System.Windows.Forms.Label();
           this._labelServerAE = new System.Windows.Forms.Label();
           this.tabControl1 = new System.Windows.Forms.TabControl();
           this.panel1.SuspendLayout();
           this.DicomTab.SuspendLayout();
           this._groupBoxClient.SuspendLayout();
           this._groupBoxServer.SuspendLayout();
           this.tabControl1.SuspendLayout();
           this.SuspendLayout();
           // 
           // panel1
           // 
           this.panel1.Controls.Add(this.OkButton);
           this.panel1.Controls.Add(this.OptionsCancelButton);
           resources.ApplyResources(this.panel1, "panel1");
           this.panel1.Name = "panel1";
           // 
           // OkButton
           // 
           this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
           resources.ApplyResources(this.OkButton, "OkButton");
           this.OkButton.Name = "OkButton";
           this.OkButton.UseVisualStyleBackColor = true;
           // 
           // OptionsCancelButton
           // 
           this.OptionsCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           resources.ApplyResources(this.OptionsCancelButton, "OptionsCancelButton");
           this.OptionsCancelButton.Name = "OptionsCancelButton";
           this.OptionsCancelButton.UseVisualStyleBackColor = true;
           // 
           // DicomTab
           // 
           this.DicomTab.Controls.Add(this._groupBoxClient);
           this.DicomTab.Controls.Add(this._groupBoxServer);
           resources.ApplyResources(this.DicomTab, "DicomTab");
           this.DicomTab.Name = "DicomTab";
           this.DicomTab.UseVisualStyleBackColor = true;
           // 
           // _groupBoxClient
           // 
           this._groupBoxClient.Controls.Add(this._textBoxTimeout);
           this._groupBoxClient.Controls.Add(this._textBoxClientAE);
           this._groupBoxClient.Controls.Add(this._labelTimeout);
           this._groupBoxClient.Controls.Add(this._labelClientAE);
           resources.ApplyResources(this._groupBoxClient, "_groupBoxClient");
           this._groupBoxClient.Name = "_groupBoxClient";
           this._groupBoxClient.TabStop = false;
           // 
           // _textBoxTimeout
           // 
           resources.ApplyResources(this._textBoxTimeout, "_textBoxTimeout");
           this._textBoxTimeout.Name = "_textBoxTimeout";
           // 
           // _textBoxClientAE
           // 
           resources.ApplyResources(this._textBoxClientAE, "_textBoxClientAE");
           this._textBoxClientAE.Name = "_textBoxClientAE";
           // 
           // _labelTimeout
           // 
           resources.ApplyResources(this._labelTimeout, "_labelTimeout");
           this._labelTimeout.Name = "_labelTimeout";
           // 
           // _labelClientAE
           // 
           resources.ApplyResources(this._labelClientAE, "_labelClientAE");
           this._labelClientAE.Name = "_labelClientAE";
           // 
           // _groupBoxServer
           // 
           this._groupBoxServer.Controls.Add(this.VerifyButton);
           this._groupBoxServer.Controls.Add(this._textBoxServerIP);
           this._groupBoxServer.Controls.Add(this._textBoxServerPort);
           this._groupBoxServer.Controls.Add(this._textBoxServerAE);
           this._groupBoxServer.Controls.Add(this._labelServerPort);
           this._groupBoxServer.Controls.Add(this._labelServerIP);
           this._groupBoxServer.Controls.Add(this._labelServerAE);
           resources.ApplyResources(this._groupBoxServer, "_groupBoxServer");
           this._groupBoxServer.Name = "_groupBoxServer";
           this._groupBoxServer.TabStop = false;
           // 
           // VerifyButton
           // 
           resources.ApplyResources(this.VerifyButton, "VerifyButton");
           this.VerifyButton.Name = "VerifyButton";
           this.VerifyButton.UseVisualStyleBackColor = true;
           this.VerifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
           // 
           // _textBoxServerIP
           // 
           resources.ApplyResources(this._textBoxServerIP, "_textBoxServerIP");
           this._textBoxServerIP.Name = "_textBoxServerIP";
           this._textBoxServerIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBoxServerIP_KeyPress);
           // 
           // _textBoxServerPort
           // 
           resources.ApplyResources(this._textBoxServerPort, "_textBoxServerPort");
           this._textBoxServerPort.Name = "_textBoxServerPort";
           this._textBoxServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBoxServerPort_KeyPress);
           // 
           // _textBoxServerAE
           // 
           resources.ApplyResources(this._textBoxServerAE, "_textBoxServerAE");
           this._textBoxServerAE.Name = "_textBoxServerAE";
           // 
           // _labelServerPort
           // 
           resources.ApplyResources(this._labelServerPort, "_labelServerPort");
           this._labelServerPort.Name = "_labelServerPort";
           // 
           // _labelServerIP
           // 
           resources.ApplyResources(this._labelServerIP, "_labelServerIP");
           this._labelServerIP.Name = "_labelServerIP";
           // 
           // _labelServerAE
           // 
           resources.ApplyResources(this._labelServerAE, "_labelServerAE");
           this._labelServerAE.Name = "_labelServerAE";
           // 
           // tabControl1
           // 
           this.tabControl1.Controls.Add(this.DicomTab);
           resources.ApplyResources(this.tabControl1, "tabControl1");
           this.tabControl1.Name = "tabControl1";
           this.tabControl1.SelectedIndex = 0;
           // 
           // OptionsDialog
           // 
           resources.ApplyResources(this, "$this");
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.Controls.Add(this.tabControl1);
           this.Controls.Add(this.panel1);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "OptionsDialog";
           this.Load += new System.EventHandler(this.OptionsDialog_Load);
           this.Shown += new System.EventHandler(this.OptionsDialog_Shown);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsDialog_FormClosing);
           this.panel1.ResumeLayout(false);
           this.DicomTab.ResumeLayout(false);
           this._groupBoxClient.ResumeLayout(false);
           this._groupBoxClient.PerformLayout();
           this._groupBoxServer.ResumeLayout(false);
           this._groupBoxServer.PerformLayout();
           this.tabControl1.ResumeLayout(false);
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button OptionsCancelButton;
        private System.Windows.Forms.TabPage DicomTab;
        private System.Windows.Forms.GroupBox _groupBoxClient;
        public System.Windows.Forms.TextBox _textBoxTimeout;
        public System.Windows.Forms.TextBox _textBoxClientAE;
        private System.Windows.Forms.Label _labelTimeout;
        private System.Windows.Forms.Label _labelClientAE;
        private System.Windows.Forms.GroupBox _groupBoxServer;
        private System.Windows.Forms.Button VerifyButton;
        public System.Windows.Forms.TextBox _textBoxServerIP;
        public System.Windows.Forms.TextBox _textBoxServerPort;
        public System.Windows.Forms.TextBox _textBoxServerAE;
        private System.Windows.Forms.Label _labelServerPort;
        private System.Windows.Forms.Label _labelServerIP;
        private System.Windows.Forms.Label _labelServerAE;
        private System.Windows.Forms.TabControl tabControl1;
    }
}