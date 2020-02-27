namespace DicomDemo
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSCPProperties = new System.Windows.Forms.TabPage();
            this.grpClients = new System.Windows.Forms.GroupBox();
            this.lblSeparator1 = new System.Windows.Forms.Label();
            this.lstClients = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtCallingAE = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpSCP = new System.Windows.Forms.GroupBox();
            this.txtConcurrentConnections = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtCalledAE = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabWorklistItems = new System.Windows.Forms.TabPage();
            this.lstDatabase = new System.Windows.Forms.ListView();
            this.btnEditRecord = new System.Windows.Forms.Button();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabSCPProperties.SuspendLayout();
            this.grpClients.SuspendLayout();
            this.grpSCP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabWorklistItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSCPProperties);
            this.tabControl1.Controls.Add(this.tabWorklistItems);
            this.tabControl1.Controls.Add(this.tabLog);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(632, 493);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSCPProperties
            // 
            this.tabSCPProperties.Controls.Add(this.grpClients);
            this.tabSCPProperties.Controls.Add(this.grpSCP);
            this.tabSCPProperties.Controls.Add(this.btnStop);
            this.tabSCPProperties.Controls.Add(this.btnStart);
            this.tabSCPProperties.Controls.Add(this.label1);
            this.tabSCPProperties.Controls.Add(this.pictureBox1);
            this.tabSCPProperties.Location = new System.Drawing.Point(4, 22);
            this.tabSCPProperties.Name = "tabSCPProperties";
            this.tabSCPProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabSCPProperties.Size = new System.Drawing.Size(624, 467);
            this.tabSCPProperties.TabIndex = 0;
            this.tabSCPProperties.Text = "SCP Properties";
            this.tabSCPProperties.UseVisualStyleBackColor = true;
            // 
            // grpClients
            // 
            this.grpClients.Controls.Add(this.lblSeparator1);
            this.grpClients.Controls.Add(this.lstClients);
            this.grpClients.Controls.Add(this.btnDeleteClient);
            this.grpClients.Controls.Add(this.btnAddClient);
            this.grpClients.Controls.Add(this.txtIP);
            this.grpClients.Controls.Add(this.txtCallingAE);
            this.grpClients.Controls.Add(this.label7);
            this.grpClients.Controls.Add(this.label6);
            this.grpClients.Controls.Add(this.label5);
            this.grpClients.Location = new System.Drawing.Point(51, 156);
            this.grpClients.Name = "grpClients";
            this.grpClients.Size = new System.Drawing.Size(567, 276);
            this.grpClients.TabIndex = 5;
            this.grpClients.TabStop = false;
            this.grpClients.Text = "Clients";
            // 
            // lblSeparator1
            // 
            this.lblSeparator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparator1.Location = new System.Drawing.Point(9, 97);
            this.lblSeparator1.Name = "lblSeparator1";
            this.lblSeparator1.Size = new System.Drawing.Size(464, 2);
            this.lblSeparator1.TabIndex = 8;
            // 
            // lstClients
            // 
            this.lstClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstClients.FullRowSelect = true;
            this.lstClients.GridLines = true;
            this.lstClients.Location = new System.Drawing.Point(6, 115);
            this.lstClients.MultiSelect = false;
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(464, 155);
            this.lstClients.TabIndex = 7;
            this.lstClients.UseCompatibleStateImageBehavior = false;
            this.lstClients.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Calling AE Title";
            this.columnHeader1.Width = 230;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "IP Address";
            this.columnHeader2.Width = 230;
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.Location = new System.Drawing.Point(476, 247);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteClient.TabIndex = 6;
            this.btnDeleteClient.Text = "Delete Client";
            this.btnDeleteClient.UseVisualStyleBackColor = true;
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDeleteClient_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(379, 71);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(94, 23);
            this.btnAddClient.TabIndex = 5;
            this.btnAddClient.Text = "Add to List >>";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(103, 45);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(370, 20);
            this.txtIP.TabIndex = 4;
            // 
            // txtCallingAE
            // 
            this.txtCallingAE.Location = new System.Drawing.Point(103, 21);
            this.txtCallingAE.Name = "txtCallingAE";
            this.txtCallingAE.Size = new System.Drawing.Size(370, 20);
            this.txtCallingAE.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(327, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Note: If you leave this list empty, any client can connect to the SCP.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "IP Address:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Calling AE Title:";
            // 
            // grpSCP
            // 
            this.grpSCP.Controls.Add(this.txtConcurrentConnections);
            this.grpSCP.Controls.Add(this.txtPort);
            this.grpSCP.Controls.Add(this.txtCalledAE);
            this.grpSCP.Controls.Add(this.label4);
            this.grpSCP.Controls.Add(this.label3);
            this.grpSCP.Controls.Add(this.label2);
            this.grpSCP.Location = new System.Drawing.Point(51, 48);
            this.grpSCP.Name = "grpSCP";
            this.grpSCP.Size = new System.Drawing.Size(567, 102);
            this.grpSCP.TabIndex = 4;
            this.grpSCP.TabStop = false;
            this.grpSCP.Text = "Service Class Provider (SCP)";
            // 
            // txtConcurrentConnections
            // 
            this.txtConcurrentConnections.Location = new System.Drawing.Point(172, 69);
            this.txtConcurrentConnections.Name = "txtConcurrentConnections";
            this.txtConcurrentConnections.Size = new System.Drawing.Size(389, 20);
            this.txtConcurrentConnections.TabIndex = 5;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(172, 45);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(389, 20);
            this.txtPort.TabIndex = 4;
            // 
            // txtCalledAE
            // 
            this.txtCalledAE.Location = new System.Drawing.Point(172, 21);
            this.txtCalledAE.Name = "txtCalledAE";
            this.txtCalledAE.Size = new System.Drawing.Size(389, 20);
            this.txtCalledAE.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Max. Concurrent Connections:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Port Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Called AE Title:";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(543, 438);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(462, 438);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(519, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "In order to run this worklist SCP, fill the required properties below then click " +
                "the start button to start the server.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabWorklistItems
            // 
            this.tabWorklistItems.Controls.Add(this.lstDatabase);
            this.tabWorklistItems.Controls.Add(this.btnEditRecord);
            this.tabWorklistItems.Controls.Add(this.btnDeleteRecord);
            this.tabWorklistItems.Controls.Add(this.btnAddRecord);
            this.tabWorklistItems.Controls.Add(this.label12);
            this.tabWorklistItems.Controls.Add(this.label11);
            this.tabWorklistItems.Controls.Add(this.label9);
            this.tabWorklistItems.Controls.Add(this.label8);
            this.tabWorklistItems.Controls.Add(this.pictureBox2);
            this.tabWorklistItems.Location = new System.Drawing.Point(4, 22);
            this.tabWorklistItems.Name = "tabWorklistItems";
            this.tabWorklistItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabWorklistItems.Size = new System.Drawing.Size(624, 467);
            this.tabWorklistItems.TabIndex = 1;
            this.tabWorklistItems.Text = "Worklist Items";
            this.tabWorklistItems.UseVisualStyleBackColor = true;
            // 
            // lstDatabase
            // 
            this.lstDatabase.FullRowSelect = true;
            this.lstDatabase.GridLines = true;
            this.lstDatabase.HideSelection = false;
            this.lstDatabase.Location = new System.Drawing.Point(6, 124);
            this.lstDatabase.MultiSelect = false;
            this.lstDatabase.Name = "lstDatabase";
            this.lstDatabase.Size = new System.Drawing.Size(522, 337);
            this.lstDatabase.TabIndex = 9;
            this.lstDatabase.UseCompatibleStateImageBehavior = false;
            this.lstDatabase.View = System.Windows.Forms.View.Details;
            // 
            // btnEditRecord
            // 
            this.btnEditRecord.Location = new System.Drawing.Point(543, 153);
            this.btnEditRecord.Name = "btnEditRecord";
            this.btnEditRecord.Size = new System.Drawing.Size(75, 23);
            this.btnEditRecord.TabIndex = 8;
            this.btnEditRecord.Text = "Edit";
            this.btnEditRecord.UseVisualStyleBackColor = true;
            this.btnEditRecord.Click += new System.EventHandler(this.btnEditRecord_Click);
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.Location = new System.Drawing.Point(543, 182);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRecord.TabIndex = 7;
            this.btnDeleteRecord.Text = "Delete";
            this.btnDeleteRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(543, 124);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(75, 23);
            this.btnAddRecord.TabIndex = 6;
            this.btnAddRecord.Text = "Add";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(48, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(380, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "- To modify the Value of an Attribute, enter the new value and then press Enter.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(552, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "- To delete a Worklist Item, select the whole record by clicking the correspondin" +
                "g left bar cell and then press Delete.";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(48, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(570, 26);
            this.label9.TabIndex = 2;
            this.label9.Text = "- To add a new Worklist Item, set the cursor on the last record denoted by \'*\' an" +
                "d then add the values you want.               The data will be saved once the fo" +
                "cus goes out of this record.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(480, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "In the list below, you can add and delete Worklist Items, as well as update the V" +
                "alue of any Attribute:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.txtLog);
            this.tabLog.Controls.Add(this.btnClearAll);
            this.tabLog.Location = new System.Drawing.Point(4, 22);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(624, 467);
            this.tabLog.TabIndex = 2;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(6, 6);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(612, 426);
            this.txtLog.TabIndex = 1;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(543, 438);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 0;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(565, 511);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 546);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Modality Worklist Provider";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSCPProperties.ResumeLayout(false);
            this.tabSCPProperties.PerformLayout();
            this.grpClients.ResumeLayout(false);
            this.grpClients.PerformLayout();
            this.grpSCP.ResumeLayout(false);
            this.grpSCP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabWorklistItems.ResumeLayout(false);
            this.tabWorklistItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabLog.ResumeLayout(false);
            this.tabLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSCPProperties;
        private System.Windows.Forms.TabPage tabWorklistItems;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.GroupBox grpClients;
        private System.Windows.Forms.GroupBox grpSCP;
        private System.Windows.Forms.TextBox txtConcurrentConnections;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtCalledAE;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSeparator1;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtCallingAE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnEditRecord;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.ListView lstClients;
        public System.Windows.Forms.ListView lstDatabase;

    }
}