namespace JpipClientDemo
{
   partial class ConnectionDialog
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
           this.btnCancel = new System.Windows.Forms.Button();
           this.btnOK = new System.Windows.Forms.Button();
           this.label2 = new System.Windows.Forms.Label();
           this.textCacheDirectoryName = new System.Windows.Forms.TextBox();
           this.label5 = new System.Windows.Forms.Label();
           this.label4 = new System.Windows.Forms.Label();
           this.label3 = new System.Windows.Forms.Label();
           this.groupBox1 = new System.Windows.Forms.GroupBox();
           this.textPortNumber = new System.Windows.Forms.MaskedTextBox();
           this.textPacketSize = new System.Windows.Forms.MaskedTextBox();
           this.lblConnection = new System.Windows.Forms.Label();
           this.cmbConnectionType = new System.Windows.Forms.ComboBox();
           this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
           this.OpenFolderDialogButton = new System.Windows.Forms.Button();
           this.label7 = new System.Windows.Forms.Label();
           this.textRequestTimeout = new System.Windows.Forms.MaskedTextBox();
           this.btnDefault = new System.Windows.Forms.Button();
           this.cmbIpAddress = new System.Windows.Forms.ComboBox();
           this.txtEnumerationServicePort = new System.Windows.Forms.MaskedTextBox();
           this.label1 = new System.Windows.Forms.Label();
           this.chkRequestTimeout = new System.Windows.Forms.CheckBox();
           this.lblNote = new System.Windows.Forms.Label();
           this.SuspendLayout();
           // 
           // btnCancel
           // 
           this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.btnCancel.Location = new System.Drawing.Point(340, 323);
           this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
           this.btnCancel.Name = "btnCancel";
           this.btnCancel.Size = new System.Drawing.Size(87, 28);
           this.btnCancel.TabIndex = 17;
           this.btnCancel.Text = "Cancel";
           // 
           // btnOK
           // 
           this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.btnOK.Location = new System.Drawing.Point(245, 323);
           this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
           this.btnOK.Name = "btnOK";
           this.btnOK.Size = new System.Drawing.Size(87, 28);
           this.btnOK.TabIndex = 16;
           this.btnOK.Text = "OK";
           this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(5, 17);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(151, 17);
           this.label2.TabIndex = 0;
           this.label2.Text = "Cache Directory Name:";
           // 
           // textCacheDirectoryName
           // 
           this.textCacheDirectoryName.Location = new System.Drawing.Point(171, 17);
           this.textCacheDirectoryName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
           this.textCacheDirectoryName.Name = "textCacheDirectoryName";
           this.textCacheDirectoryName.Size = new System.Drawing.Size(223, 24);
           this.textCacheDirectoryName.TabIndex = 1;
           // 
           // label5
           // 
           this.label5.AutoSize = true;
           this.label5.Location = new System.Drawing.Point(5, 177);
           this.label5.Name = "label5";
           this.label5.Size = new System.Drawing.Size(122, 17);
           this.label5.TabIndex = 11;
           this.label5.Text = "Packet Size / byte:";
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Location = new System.Drawing.Point(5, 82);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(92, 17);
           this.label4.TabIndex = 5;
           this.label4.Text = "Port Number:";
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(5, 50);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(77, 17);
           this.label3.TabIndex = 3;
           this.label3.Text = "IP Address:";
           // 
           // groupBox1
           // 
           this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.groupBox1.Location = new System.Drawing.Point(-27, 290);
           this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
           this.groupBox1.Size = new System.Drawing.Size(468, 2);
           this.groupBox1.TabIndex = 17;
           this.groupBox1.TabStop = false;
           // 
           // textPortNumber
           // 
           this.textPortNumber.HidePromptOnLeave = true;
           this.textPortNumber.Location = new System.Drawing.Point(171, 82);
           this.textPortNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
           this.textPortNumber.Mask = "00000";
           this.textPortNumber.Name = "textPortNumber";
           this.textPortNumber.Size = new System.Drawing.Size(100, 24);
           this.textPortNumber.TabIndex = 6;
           // 
           // textPacketSize
           // 
           this.textPacketSize.Location = new System.Drawing.Point(171, 177);
           this.textPacketSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
           this.textPacketSize.Mask = "00000";
           this.textPacketSize.Name = "textPacketSize";
           this.textPacketSize.Size = new System.Drawing.Size(100, 24);
           this.textPacketSize.TabIndex = 12;
           this.textPacketSize.ValidatingType = typeof(int);
           // 
           // lblConnection
           // 
           this.lblConnection.AutoSize = true;
           this.lblConnection.Location = new System.Drawing.Point(5, 149);
           this.lblConnection.Name = "lblConnection";
           this.lblConnection.Size = new System.Drawing.Size(83, 17);
           this.lblConnection.TabIndex = 9;
           this.lblConnection.Text = "Connection:";
           // 
           // cmbConnectionType
           // 
           this.cmbConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.cmbConnectionType.FormattingEnabled = true;
           this.cmbConnectionType.Location = new System.Drawing.Point(171, 149);
           this.cmbConnectionType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
           this.cmbConnectionType.Name = "cmbConnectionType";
           this.cmbConnectionType.Size = new System.Drawing.Size(121, 24);
           this.cmbConnectionType.TabIndex = 10;
           // 
           // OpenFolderDialogButton
           // 
           this.OpenFolderDialogButton.Location = new System.Drawing.Point(396, 16);
           this.OpenFolderDialogButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
           this.OpenFolderDialogButton.Name = "OpenFolderDialogButton";
           this.OpenFolderDialogButton.Size = new System.Drawing.Size(28, 26);
           this.OpenFolderDialogButton.TabIndex = 2;
           this.OpenFolderDialogButton.Text = "...";
           this.OpenFolderDialogButton.UseVisualStyleBackColor = true;
           this.OpenFolderDialogButton.Click += new System.EventHandler(this.OpenFolderDialogButton_Click);
           // 
           // label7
           // 
           this.label7.AutoSize = true;
           this.label7.Location = new System.Drawing.Point(5, 207);
           this.label7.Name = "label7";
           this.label7.Size = new System.Drawing.Size(150, 17);
           this.label7.TabIndex = 13;
           this.label7.Text = "Request Timeout / sec:";
           // 
           // textRequestTimeout
           // 
           this.textRequestTimeout.Location = new System.Drawing.Point(171, 207);
           this.textRequestTimeout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
           this.textRequestTimeout.Mask = "0000000";
           this.textRequestTimeout.Name = "textRequestTimeout";
           this.textRequestTimeout.Size = new System.Drawing.Size(100, 24);
           this.textRequestTimeout.TabIndex = 14;
           this.textRequestTimeout.ValidatingType = typeof(int);
           // 
           // btnDefault
           // 
           this.btnDefault.Location = new System.Drawing.Point(336, 251);
           this.btnDefault.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
           this.btnDefault.Name = "btnDefault";
           this.btnDefault.Size = new System.Drawing.Size(87, 28);
           this.btnDefault.TabIndex = 15;
           this.btnDefault.Text = "&Default";
           this.btnDefault.UseVisualStyleBackColor = true;
           this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
           // 
           // cmbIpAddress
           // 
           this.cmbIpAddress.FormattingEnabled = true;
           this.cmbIpAddress.Location = new System.Drawing.Point(171, 48);
           this.cmbIpAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
           this.cmbIpAddress.Name = "cmbIpAddress";
           this.cmbIpAddress.Size = new System.Drawing.Size(259, 24);
           this.cmbIpAddress.TabIndex = 4;
           // 
           // txtEnumerationServicePort
           // 
           this.txtEnumerationServicePort.HidePromptOnLeave = true;
           this.txtEnumerationServicePort.Location = new System.Drawing.Point(171, 117);
           this.txtEnumerationServicePort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
           this.txtEnumerationServicePort.Mask = "00000";
           this.txtEnumerationServicePort.Name = "txtEnumerationServicePort";
           this.txtEnumerationServicePort.Size = new System.Drawing.Size(100, 24);
           this.txtEnumerationServicePort.TabIndex = 8;
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(5, 117);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(169, 17);
           this.label1.TabIndex = 7;
           this.label1.Text = "Enumeration Service Port:";
           // 
           // chkRequestTimeout
           // 
           this.chkRequestTimeout.AutoSize = true;
           this.chkRequestTimeout.Location = new System.Drawing.Point(277, 209);
           this.chkRequestTimeout.Name = "chkRequestTimeout";
           this.chkRequestTimeout.Size = new System.Drawing.Size(85, 21);
           this.chkRequestTimeout.TabIndex = 18;
           this.chkRequestTimeout.Text = "&Unlimited";
           this.chkRequestTimeout.UseVisualStyleBackColor = true;
           this.chkRequestTimeout.CheckedChanged += new System.EventHandler(this.chkRequestTimeout_CheckedChanged);
           // 
           // lblNote
           // 
           this.lblNote.AutoSize = true;
           this.lblNote.ForeColor = System.Drawing.Color.Blue;
           this.lblNote.Location = new System.Drawing.Point(5, 298);
           this.lblNote.Name = "lblNote";
           this.lblNote.Size = new System.Drawing.Size(384, 17);
           this.lblNote.TabIndex = 20;
           this.lblNote.Text = "*Make sure the server is running before making a connection.";
           // 
           // ConnectionDialog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(433, 357);
           this.Controls.Add(this.lblNote);
           this.Controls.Add(this.chkRequestTimeout);
           this.Controls.Add(this.txtEnumerationServicePort);
           this.Controls.Add(this.label1);
           this.Controls.Add(this.cmbIpAddress);
           this.Controls.Add(this.btnDefault);
           this.Controls.Add(this.textRequestTimeout);
           this.Controls.Add(this.label7);
           this.Controls.Add(this.OpenFolderDialogButton);
           this.Controls.Add(this.cmbConnectionType);
           this.Controls.Add(this.lblConnection);
           this.Controls.Add(this.textPacketSize);
           this.Controls.Add(this.textPortNumber);
           this.Controls.Add(this.groupBox1);
           this.Controls.Add(this.textCacheDirectoryName);
           this.Controls.Add(this.label4);
           this.Controls.Add(this.label3);
           this.Controls.Add(this.label5);
           this.Controls.Add(this.label2);
           this.Controls.Add(this.btnOK);
           this.Controls.Add(this.btnCancel);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "ConnectionDialog";
           this.ShowInTaskbar = false;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Connection";
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
       private System.Windows.Forms.Button btnOK;
       private System.Windows.Forms.Label label2;
       private System.Windows.Forms.TextBox textCacheDirectoryName;
      private System.Windows.Forms.Label label5;
       private System.Windows.Forms.Label label4;
       private System.Windows.Forms.Label label3;
       private System.Windows.Forms.GroupBox groupBox1;
       private System.Windows.Forms.MaskedTextBox textPortNumber;
       private System.Windows.Forms.MaskedTextBox textPacketSize;
       private System.Windows.Forms.Label lblConnection;
       private System.Windows.Forms.ComboBox cmbConnectionType;
       private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
       private System.Windows.Forms.Button OpenFolderDialogButton;
       private System.Windows.Forms.Label label7;
       private System.Windows.Forms.MaskedTextBox textRequestTimeout;
      private System.Windows.Forms.Button btnDefault;
      private System.Windows.Forms.ComboBox cmbIpAddress;
      private System.Windows.Forms.MaskedTextBox txtEnumerationServicePort;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.CheckBox chkRequestTimeout;
      internal System.Windows.Forms.Label lblNote;
    }
}