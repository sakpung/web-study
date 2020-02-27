using Leadtools.DicomDemos;
namespace DicomDemo
{
    partial class Page1
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
            if (disposing)
            {
               if (components != null)
                  components.Dispose();

               if ( null != _cecho )
               {
                  _cecho.CloseForced(false);
                  if (_cecho.workThread != null)
                     _cecho.workThread.Abort();

                  _cecho.Status -= new StatusEventHandler(cecho_Status);
                  _cecho.Dispose();
                  _cecho = null ;
               }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.grpMWLServer = new System.Windows.Forms.GroupBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtServerAE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.txtClientAE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.grpMWLServer.SuspendLayout();
            this.grpClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(568, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configure Modality Work List Server.  Supply the requested information, click the" +
                " \"Verify\" button, and then click \"Next\".";
            // 
            // grpMWLServer
            // 
            this.grpMWLServer.Controls.Add(this.txtServerPort);
            this.grpMWLServer.Controls.Add(this.txtServerIP);
            this.grpMWLServer.Controls.Add(this.txtServerAE);
            this.grpMWLServer.Controls.Add(this.label2);
            this.grpMWLServer.Controls.Add(this.label3);
            this.grpMWLServer.Controls.Add(this.label4);
            this.grpMWLServer.Location = new System.Drawing.Point(19, 48);
            this.grpMWLServer.Name = "grpMWLServer";
            this.grpMWLServer.Size = new System.Drawing.Size(583, 100);
            this.grpMWLServer.TabIndex = 0;
            this.grpMWLServer.TabStop = false;
            this.grpMWLServer.Text = "Modality Work List Server";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(121, 68);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(227, 20);
            this.txtServerPort.TabIndex = 10;
            this.txtServerPort.TextChanged += new System.EventHandler(this.txtServerPort_TextChanged);
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(121, 44);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(227, 20);
            this.txtServerIP.TabIndex = 9;
            this.txtServerIP.TextChanged += new System.EventHandler(this.txtServerIP_TextChanged);
            // 
            // txtServerAE
            // 
            this.txtServerAE.Location = new System.Drawing.Point(121, 20);
            this.txtServerAE.Name = "txtServerAE";
            this.txtServerAE.Size = new System.Drawing.Size(428, 20);
            this.txtServerAE.TabIndex = 8;
            this.txtServerAE.TextChanged += new System.EventHandler(this.txtServerAE_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "AE Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "IP Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Port Number";
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(this.txtClientAE);
            this.grpClient.Controls.Add(this.label5);
            this.grpClient.Location = new System.Drawing.Point(19, 164);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new System.Drawing.Size(583, 50);
            this.grpClient.TabIndex = 1;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client";
            // 
            // txtClientAE
            // 
            this.txtClientAE.Location = new System.Drawing.Point(121, 20);
            this.txtClientAE.Name = "txtClientAE";
            this.txtClientAE.Size = new System.Drawing.Size(227, 20);
            this.txtClientAE.TabIndex = 11;
            this.txtClientAE.TextChanged += new System.EventHandler(this.txtClientAE_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "AE Title";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(19, 248);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(583, 185);
            this.txtLog.TabIndex = 1;
            this.txtLog.TabStop = false;
            this.txtLog.WordWrap = false;
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(19, 220);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 2;
            this.btnVerify.Text = "Verify...";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // Page1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.grpClient);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.grpMWLServer);
            this.Controls.Add(this.label1);
            this.Name = "Page1";
            this.Size = new System.Drawing.Size(618, 452);
            this.Load += new System.EventHandler(this.Page1_Load);
            this.grpMWLServer.ResumeLayout(false);
            this.grpMWLServer.PerformLayout();
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpMWLServer;
        private System.Windows.Forms.GroupBox grpClient;
        public System.Windows.Forms.TextBox txtServerPort;
        public System.Windows.Forms.TextBox txtServerIP;
        public System.Windows.Forms.TextBox txtServerAE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtClientAE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnVerify;
    }
}
