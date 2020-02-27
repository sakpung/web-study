namespace JpipServerDemo
{
   partial class ImagesEnumerationServiceDlg
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
         this.lblDescription = new System.Windows.Forms.Label();
         this.lblServiceIP = new System.Windows.Forms.Label();
         this.lblPort = new System.Windows.Forms.Label();
         this.txtIpAddress = new System.Windows.Forms.TextBox();
         this.mtxtPort = new System.Windows.Forms.MaskedTextBox();
         this.grpExten = new System.Windows.Forms.GroupBox();
         this.chkJ2kExt = new System.Windows.Forms.CheckBox();
         this.chkJp2Ext = new System.Windows.Forms.CheckBox();
         this.chkJpxExt = new System.Windows.Forms.CheckBox();
         this.txtExtensions = new System.Windows.Forms.TextBox();
         this.btnStart = new System.Windows.Forms.Button();
         this.btnStop = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.btnOK = new System.Windows.Forms.Button();
         this.grpExten.SuspendLayout();
         this.SuspendLayout();
         // 
         // lblDescription
         // 
         this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.lblDescription.Location = new System.Drawing.Point(3, 9);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(507, 48);
         this.lblDescription.TabIndex = 0;
         this.lblDescription.Text = "The images enumeration service will help LEADTOOLS JPIP Client demo to enumerate " +
             "the images on the server.";
         // 
         // lblServiceIP
         // 
         this.lblServiceIP.AutoSize = true;
         this.lblServiceIP.Location = new System.Drawing.Point(3, 60);
         this.lblServiceIP.Name = "lblServiceIP";
         this.lblServiceIP.Size = new System.Drawing.Size(125, 17);
         this.lblServiceIP.TabIndex = 1;
         this.lblServiceIP.Text = "Service IP Address:";
         this.lblServiceIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblPort
         // 
         this.lblPort.AutoSize = true;
         this.lblPort.Location = new System.Drawing.Point(3, 90);
         this.lblPort.Name = "lblPort";
         this.lblPort.Size = new System.Drawing.Size(39, 17);
         this.lblPort.TabIndex = 3;
         this.lblPort.Text = "Port:";
         this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // txtIpAddress
         // 
         this.txtIpAddress.Enabled = false;
         this.txtIpAddress.Location = new System.Drawing.Point(134, 60);
         this.txtIpAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.txtIpAddress.Name = "txtIpAddress";
         this.txtIpAddress.Size = new System.Drawing.Size(133, 24);
         this.txtIpAddress.TabIndex = 2;
         // 
         // mtxtPort
         // 
         this.mtxtPort.HidePromptOnLeave = true;
         this.mtxtPort.Location = new System.Drawing.Point(134, 100);
         this.mtxtPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtPort.Mask = "00000";
         this.mtxtPort.Name = "mtxtPort";
         this.mtxtPort.Size = new System.Drawing.Size(133, 24);
         this.mtxtPort.TabIndex = 4;
         // 
         // grpExten
         // 
         this.grpExten.Controls.Add(this.chkJ2kExt);
         this.grpExten.Controls.Add(this.chkJp2Ext);
         this.grpExten.Controls.Add(this.chkJpxExt);
         this.grpExten.Controls.Add(this.txtExtensions);
         this.grpExten.Location = new System.Drawing.Point(6, 130);
         this.grpExten.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.grpExten.Name = "grpExten";
         this.grpExten.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.grpExten.Size = new System.Drawing.Size(506, 95);
         this.grpExten.TabIndex = 5;
         this.grpExten.TabStop = false;
         this.grpExten.Text = "Select or add the files extension which you want to be identified as valid images" +
             "";
         // 
         // chkJ2kExt
         // 
         this.chkJ2kExt.AutoSize = true;
         this.chkJ2kExt.Location = new System.Drawing.Point(7, 34);
         this.chkJ2kExt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.chkJ2kExt.Name = "chkJ2kExt";
         this.chkJ2kExt.Size = new System.Drawing.Size(51, 21);
         this.chkJ2kExt.TabIndex = 0;
         this.chkJ2kExt.Tag = "*.j2k";
         this.chkJ2kExt.Text = "J2k";
         this.chkJ2kExt.UseVisualStyleBackColor = true;
         this.chkJ2kExt.CheckedChanged += new System.EventHandler(this.chkJ2kExt_CheckedChanged);
         // 
         // chkJp2Ext
         // 
         this.chkJp2Ext.AutoSize = true;
         this.chkJp2Ext.Location = new System.Drawing.Point(70, 34);
         this.chkJp2Ext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.chkJp2Ext.Name = "chkJp2Ext";
         this.chkJp2Ext.Size = new System.Drawing.Size(52, 21);
         this.chkJp2Ext.TabIndex = 1;
         this.chkJp2Ext.Tag = "*.jp2";
         this.chkJp2Ext.Text = "Jp2";
         this.chkJp2Ext.UseVisualStyleBackColor = true;
         this.chkJp2Ext.CheckedChanged += new System.EventHandler(this.chkJ2kExt_CheckedChanged);
         // 
         // chkJpxExt
         // 
         this.chkJpxExt.AutoSize = true;
         this.chkJpxExt.Location = new System.Drawing.Point(128, 34);
         this.chkJpxExt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.chkJpxExt.Name = "chkJpxExt";
         this.chkJpxExt.Size = new System.Drawing.Size(52, 21);
         this.chkJpxExt.TabIndex = 2;
         this.chkJpxExt.Tag = "*.jpx";
         this.chkJpxExt.Text = "Jpx";
         this.chkJpxExt.UseVisualStyleBackColor = true;
         this.chkJpxExt.CheckedChanged += new System.EventHandler(this.chkJ2kExt_CheckedChanged);
         // 
         // txtExtensions
         // 
         this.txtExtensions.Location = new System.Drawing.Point(5, 62);
         this.txtExtensions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.txtExtensions.Name = "txtExtensions";
         this.txtExtensions.Size = new System.Drawing.Size(495, 24);
         this.txtExtensions.TabIndex = 3;
         this.txtExtensions.TextChanged += new System.EventHandler(this.txtExtensions_TextChanged);
         // 
         // btnStart
         // 
         this.btnStart.Location = new System.Drawing.Point(6, 231);
         this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnStart.Name = "btnStart";
         this.btnStart.Size = new System.Drawing.Size(75, 44);
         this.btnStart.TabIndex = 6;
         this.btnStart.Text = "&Start";
         this.btnStart.UseVisualStyleBackColor = true;
         this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
         // 
         // btnStop
         // 
         this.btnStop.Location = new System.Drawing.Point(87, 231);
         this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnStop.Name = "btnStop";
         this.btnStop.Size = new System.Drawing.Size(75, 44);
         this.btnStop.TabIndex = 7;
         this.btnStop.Text = "S&top";
         this.btnStop.UseVisualStyleBackColor = true;
         this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Location = new System.Drawing.Point(-192, 289);
         this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox1.Size = new System.Drawing.Size(727, 2);
         this.groupBox1.TabIndex = 8;
         this.groupBox1.TabStop = false;
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(430, 298);
         this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 31);
         this.btnOK.TabIndex = 8;
         this.btnOK.Text = "Close";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // ImagesEnumerationServiceDlg
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnOK;
         this.ClientSize = new System.Drawing.Size(519, 335);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.btnStop);
         this.Controls.Add(this.btnStart);
         this.Controls.Add(this.grpExten);
         this.Controls.Add(this.mtxtPort);
         this.Controls.Add(this.txtIpAddress);
         this.Controls.Add(this.lblPort);
         this.Controls.Add(this.lblServiceIP);
         this.Controls.Add(this.lblDescription);
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.MinimizeBox = false;
         this.Name = "ImagesEnumerationServiceDlg";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Images Enumeration Service";
         this.grpExten.ResumeLayout(false);
         this.grpExten.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblDescription;
      private System.Windows.Forms.Label lblServiceIP;
      private System.Windows.Forms.Label lblPort;
      private System.Windows.Forms.TextBox txtIpAddress;
      private System.Windows.Forms.MaskedTextBox mtxtPort;
      private System.Windows.Forms.GroupBox grpExten;
      private System.Windows.Forms.CheckBox chkJ2kExt;
      private System.Windows.Forms.CheckBox chkJp2Ext;
      private System.Windows.Forms.CheckBox chkJpxExt;
      private System.Windows.Forms.TextBox txtExtensions;
      private System.Windows.Forms.Button btnStart;
      private System.Windows.Forms.Button btnStop;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button btnOK;
   }
}