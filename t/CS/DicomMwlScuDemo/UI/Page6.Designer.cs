using Leadtools.DicomDemos;
namespace DicomDemo
{
    partial class Page6
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

              cstore.CloseForced(true);
              if (cstore.workThread != null)
                 cstore.workThread.Abort();
              cstore.Status -= new StatusEventHandler(cstore_Status);
              cstore.Dispose();

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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.txtClientAE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStore = new System.Windows.Forms.Button();
            this.grpMWLServer = new System.Windows.Forms.GroupBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtServerAE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radServer = new System.Windows.Forms.RadioButton();
            this.radLocal = new System.Windows.Forms.RadioButton();
            this.grpClient.SuspendLayout();
            this.grpMWLServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(591, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a radio button to choose whether to store the resulting data set to a stor" +
                "age server or locally.  Then click the \"Store\"  ";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(19, 313);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(583, 120);
            this.txtLog.TabIndex = 16;
            this.txtLog.TabStop = false;
            this.txtLog.WordWrap = false;
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(this.txtClientAE);
            this.grpClient.Controls.Add(this.label5);
            this.grpClient.Location = new System.Drawing.Point(19, 229);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new System.Drawing.Size(583, 50);
            this.grpClient.TabIndex = 3;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client";
            // 
            // txtClientAE
            // 
            this.txtClientAE.Location = new System.Drawing.Point(121, 20);
            this.txtClientAE.Name = "txtClientAE";
            this.txtClientAE.Size = new System.Drawing.Size(227, 20);
            this.txtClientAE.TabIndex = 11;
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
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(19, 285);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(75, 23);
            this.btnStore.TabIndex = 4;
            this.btnStore.Text = "Store...";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // grpMWLServer
            // 
            this.grpMWLServer.Controls.Add(this.txtServerPort);
            this.grpMWLServer.Controls.Add(this.txtServerIP);
            this.grpMWLServer.Controls.Add(this.txtServerAE);
            this.grpMWLServer.Controls.Add(this.label2);
            this.grpMWLServer.Controls.Add(this.label3);
            this.grpMWLServer.Controls.Add(this.label4);
            this.grpMWLServer.Location = new System.Drawing.Point(19, 113);
            this.grpMWLServer.Name = "grpMWLServer";
            this.grpMWLServer.Size = new System.Drawing.Size(583, 100);
            this.grpMWLServer.TabIndex = 2;
            this.grpMWLServer.TabStop = false;
            this.grpMWLServer.Text = "Modality Work List Server";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(121, 68);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(227, 20);
            this.txtServerPort.TabIndex = 10;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(121, 44);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(227, 20);
            this.txtServerIP.TabIndex = 9;
            // 
            // txtServerAE
            // 
            this.txtServerAE.Location = new System.Drawing.Point(121, 20);
            this.txtServerAE.Name = "txtServerAE";
            this.txtServerAE.Size = new System.Drawing.Size(428, 20);
            this.txtServerAE.TabIndex = 8;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "button, and click \"Next\".";
            // 
            // radServer
            // 
            this.radServer.AutoSize = true;
            this.radServer.Location = new System.Drawing.Point(19, 65);
            this.radServer.Name = "radServer";
            this.radServer.Size = new System.Drawing.Size(136, 17);
            this.radServer.TabIndex = 0;
            this.radServer.TabStop = true;
            this.radServer.Text = "Send to Storage Server";
            this.radServer.UseVisualStyleBackColor = true;
            this.radServer.CheckedChanged += new System.EventHandler(this.radServer_CheckedChanged);
            // 
            // radLocal
            // 
            this.radLocal.AutoSize = true;
            this.radLocal.Location = new System.Drawing.Point(19, 81);
            this.radLocal.Name = "radLocal";
            this.radLocal.Size = new System.Drawing.Size(86, 17);
            this.radLocal.TabIndex = 1;
            this.radLocal.TabStop = true;
            this.radLocal.Text = "Store Locally";
            this.radLocal.UseVisualStyleBackColor = true;
            this.radLocal.CheckedChanged += new System.EventHandler(this.radLocal_CheckedChanged);
            // 
            // Page6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLocal);
            this.Controls.Add(this.radServer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.grpClient);
            this.Controls.Add(this.btnStore);
            this.Controls.Add(this.grpMWLServer);
            this.Controls.Add(this.label1);
            this.Name = "Page6";
            this.Size = new System.Drawing.Size(618, 452);
            this.Load += new System.EventHandler(this.Page6_Load);
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            this.grpMWLServer.ResumeLayout(false);
            this.grpMWLServer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox grpClient;
        public System.Windows.Forms.TextBox txtClientAE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.GroupBox grpMWLServer;
        public System.Windows.Forms.TextBox txtServerPort;
        public System.Windows.Forms.TextBox txtServerIP;
        public System.Windows.Forms.TextBox txtServerAE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radServer;
        private System.Windows.Forms.RadioButton radLocal;
    }
}
