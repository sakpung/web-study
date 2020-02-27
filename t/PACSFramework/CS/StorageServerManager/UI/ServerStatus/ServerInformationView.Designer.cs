namespace Leadtools.Demos.StorageServer.UI
{
   partial class ServerInformationView
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerInformationView));
         this.ServiceDisplayNameLabel = new System.Windows.Forms.Label();
         this.toolTip = new System.Windows.Forms.ToolTip(this.components);
         this.ServerStatusPictureBox = new System.Windows.Forms.PictureBox();
         this.buttonExit = new System.Windows.Forms.Button();
         this.buttonStop = new System.Windows.Forms.Button();
         this.buttonAbout = new System.Windows.Forms.Button();
         this.buttonSettings = new System.Windows.Forms.Button();
         this.buttonStart = new System.Windows.Forms.Button();
         this.panel1 = new Leadtools.Demos.StorageServer.UI.DoubleBufferedPanel();
         this.pictureBoxSecure = new System.Windows.Forms.PictureBox();
         this.labelStatus = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.PortLabel = new System.Windows.Forms.Label();
         this.IpAddressLabel = new System.Windows.Forms.Label();
         this.AETitleLabel = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.ServerStatusPictureBox)).BeginInit();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecure)).BeginInit();
         this.SuspendLayout();
         // 
         // ServiceDisplayNameLabel
         // 
         this.ServiceDisplayNameLabel.AutoSize = true;
         this.ServiceDisplayNameLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.ServiceDisplayNameLabel.Location = new System.Drawing.Point(121, 29);
         this.ServiceDisplayNameLabel.Name = "ServiceDisplayNameLabel";
         this.ServiceDisplayNameLabel.Size = new System.Drawing.Size(150, 22);
         this.ServiceDisplayNameLabel.TabIndex = 11;
         this.ServiceDisplayNameLabel.Text = "Storage Server";
         // 
         // ServerStatusPictureBox
         // 
         this.ServerStatusPictureBox.Image = global::Leadtools.Demos.StorageServer.Properties.Resources._1313685426_Symbol_Error;
         this.ServerStatusPictureBox.Location = new System.Drawing.Point(12, 29);
         this.ServerStatusPictureBox.Name = "ServerStatusPictureBox";
         this.ServerStatusPictureBox.Size = new System.Drawing.Size(100, 76);
         this.ServerStatusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.ServerStatusPictureBox.TabIndex = 7;
         this.ServerStatusPictureBox.TabStop = false;
         this.toolTip.SetToolTip(this.ServerStatusPictureBox, "Server is stopped");
         // 
         // buttonExit
         // 
         this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
         this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
         this.buttonExit.FlatAppearance.BorderSize = 0;
         this.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(218)))), ((int)(((byte)(232)))));
         this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.buttonExit.Location = new System.Drawing.Point(568, 91);
         this.buttonExit.Name = "buttonExit";
         this.buttonExit.Size = new System.Drawing.Size(64, 36);
         this.buttonExit.TabIndex = 2;
         this.toolTip.SetToolTip(this.buttonExit, "Exit Application");
         this.buttonExit.UseVisualStyleBackColor = true;
         this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
         // 
         // buttonStop
         // 
         this.buttonStop.BackColor = System.Drawing.Color.Transparent;
         this.buttonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.buttonStop.Cursor = System.Windows.Forms.Cursors.Hand;
         this.buttonStop.Enabled = false;
         this.buttonStop.FlatAppearance.BorderSize = 0;
         this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.buttonStop.Image = global::Leadtools.Demos.StorageServer.Properties.Resources.ServiceStop;
         this.buttonStop.Location = new System.Drawing.Point(61, 104);
         this.buttonStop.Name = "buttonStop";
         this.buttonStop.Size = new System.Drawing.Size(25, 25);
         this.buttonStop.TabIndex = 14;
         this.buttonStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip.SetToolTip(this.buttonStop, "Stop Storage Service");
         this.buttonStop.UseVisualStyleBackColor = false;
         this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
         // 
         // buttonAbout
         // 
         this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonAbout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAbout.BackgroundImage")));
         this.buttonAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.buttonAbout.Cursor = System.Windows.Forms.Cursors.Hand;
         this.buttonAbout.FlatAppearance.BorderSize = 0;
         this.buttonAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(218)))), ((int)(((byte)(232)))));
         this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.buttonAbout.Location = new System.Drawing.Point(568, 49);
         this.buttonAbout.Name = "buttonAbout";
         this.buttonAbout.Size = new System.Drawing.Size(64, 36);
         this.buttonAbout.TabIndex = 1;
         this.toolTip.SetToolTip(this.buttonAbout, "About");
         this.buttonAbout.UseVisualStyleBackColor = true;
         this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
         // 
         // buttonSettings
         // 
         this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.buttonSettings.Cursor = System.Windows.Forms.Cursors.Hand;
         this.buttonSettings.FlatAppearance.BorderSize = 0;
         this.buttonSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(218)))), ((int)(((byte)(232)))));
         this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
         this.buttonSettings.Location = new System.Drawing.Point(568, 7);
         this.buttonSettings.Name = "buttonSettings";
         this.buttonSettings.Size = new System.Drawing.Size(64, 36);
         this.buttonSettings.TabIndex = 0;
         this.toolTip.SetToolTip(this.buttonSettings, "Settings");
         this.buttonSettings.UseVisualStyleBackColor = true;
         this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
         // 
         // buttonStart
         // 
         this.buttonStart.BackColor = System.Drawing.Color.Transparent;
         this.buttonStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
         this.buttonStart.FlatAppearance.BorderSize = 0;
         this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.buttonStart.Image = ((System.Drawing.Image)(resources.GetObject("buttonStart.Image")));
         this.buttonStart.Location = new System.Drawing.Point(31, 104);
         this.buttonStart.Name = "buttonStart";
         this.buttonStart.Size = new System.Drawing.Size(25, 25);
         this.buttonStart.TabIndex = 13;
         this.buttonStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.toolTip.SetToolTip(this.buttonStart, "Start Storage Service");
         this.buttonStart.UseVisualStyleBackColor = false;
         this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
         // 
         // panel1
         // 
         this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panel1.Controls.Add(this.pictureBoxSecure);
         this.panel1.Controls.Add(this.labelStatus);
         this.panel1.Controls.Add(this.label5);
         this.panel1.Controls.Add(this.PortLabel);
         this.panel1.Controls.Add(this.IpAddressLabel);
         this.panel1.Controls.Add(this.AETitleLabel);
         this.panel1.Controls.Add(this.label2);
         this.panel1.Controls.Add(this.label1);
         this.panel1.Controls.Add(this.label3);
         this.panel1.Location = new System.Drawing.Point(118, 54);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(318, 77);
         this.panel1.TabIndex = 10;
         // 
         // pictureBoxSecure
         // 
         this.pictureBoxSecure.Image = global::Leadtools.Demos.StorageServer.Properties.Resources._lock;
         this.pictureBoxSecure.Location = new System.Drawing.Point(110, 2);
         this.pictureBoxSecure.Name = "pictureBoxSecure";
         this.pictureBoxSecure.Size = new System.Drawing.Size(16, 16);
         this.pictureBoxSecure.TabIndex = 15;
         this.pictureBoxSecure.TabStop = false;
         // 
         // labelStatus
         // 
         this.labelStatus.AutoSize = true;
         this.labelStatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelStatus.ForeColor = System.Drawing.Color.Red;
         this.labelStatus.Location = new System.Drawing.Point(125, 59);
         this.labelStatus.Name = "labelStatus";
         this.labelStatus.Size = new System.Drawing.Size(25, 14);
         this.labelStatus.TabIndex = 14;
         this.labelStatus.Text = "805";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(4, 59);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(41, 14);
         this.label5.TabIndex = 13;
         this.label5.Text = "Status:";
         // 
         // PortLabel
         // 
         this.PortLabel.AutoSize = true;
         this.PortLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.PortLabel.Location = new System.Drawing.Point(125, 41);
         this.PortLabel.Name = "PortLabel";
         this.PortLabel.Size = new System.Drawing.Size(25, 14);
         this.PortLabel.TabIndex = 12;
         this.PortLabel.Text = "805";
         // 
         // IpAddressLabel
         // 
         this.IpAddressLabel.AutoSize = true;
         this.IpAddressLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.IpAddressLabel.Location = new System.Drawing.Point(125, 23);
         this.IpAddressLabel.Name = "IpAddressLabel";
         this.IpAddressLabel.Size = new System.Drawing.Size(76, 14);
         this.IpAddressLabel.TabIndex = 11;
         this.IpAddressLabel.Text = "192.168.0.151";
         // 
         // AETitleLabel
         // 
         this.AETitleLabel.AutoSize = true;
         this.AETitleLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.AETitleLabel.Location = new System.Drawing.Point(125, 5);
         this.AETitleLabel.Name = "AETitleLabel";
         this.AETitleLabel.Size = new System.Drawing.Size(67, 14);
         this.AETitleLabel.TabIndex = 10;
         this.AETitleLabel.Text = "MI_SERVER";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(4, 23);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(107, 14);
         this.label2.TabIndex = 8;
         this.label2.Text = "Host/Address Name:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(4, 5);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(46, 14);
         this.label1.TabIndex = 7;
         this.label1.Text = "AE Title:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(4, 41);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(29, 14);
         this.label3.TabIndex = 9;
         this.label3.Text = "Port:";
         // 
         // ServerInformationView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.ServerStatusPictureBox);
         this.Controls.Add(this.buttonExit);
         this.Controls.Add(this.buttonStop);
         this.Controls.Add(this.buttonAbout);
         this.Controls.Add(this.buttonSettings);
         this.Controls.Add(this.ServiceDisplayNameLabel);
         this.Controls.Add(this.buttonStart);
         this.Controls.Add(this.panel1);
         this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.MinimumSize = new System.Drawing.Size(360, 134);
         this.Name = "ServerInformationView";
         this.Size = new System.Drawing.Size(635, 134);
         ((System.ComponentModel.ISupportInitialize)(this.ServerStatusPictureBox)).EndInit();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecure)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox ServerStatusPictureBox;
      private DoubleBufferedPanel panel1;
      private System.Windows.Forms.Label PortLabel;
      private System.Windows.Forms.Label IpAddressLabel;
      private System.Windows.Forms.Label AETitleLabel;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label ServiceDisplayNameLabel;
      private System.Windows.Forms.Button buttonExit;
      private System.Windows.Forms.Button buttonAbout;
      private System.Windows.Forms.Button buttonSettings;
      private System.Windows.Forms.ToolTip toolTip;
      private System.Windows.Forms.Button buttonStart;
      private System.Windows.Forms.Button buttonStop;
      private System.Windows.Forms.Label labelStatus;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.PictureBox pictureBoxSecure;
   }
}
