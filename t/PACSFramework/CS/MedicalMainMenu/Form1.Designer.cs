namespace MedicalMainMenu
{
   partial class Form1
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this.groupBoxDicomServers = new System.Windows.Forms.GroupBox();
         this.dataGridViewDicomServers = new System.Windows.Forms.DataGridView();
         this.ColumnDemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnDescription = new System.Windows.Forms.DataGridViewLinkColumn();
         this.groupBoxDicomClients = new System.Windows.Forms.GroupBox();
         this.dataGridViewDicomClients = new System.Windows.Forms.DataGridView();
         this.ColumnDemoClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnLinkClient = new System.Windows.Forms.DataGridViewLinkColumn();
         this.groupBoxDicomViewers = new System.Windows.Forms.GroupBox();
         this.dataGridViewDicomViewers = new System.Windows.Forms.DataGridView();
         this.ColumnDemoViewer = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnLinkViewer = new System.Windows.Forms.DataGridViewLinkColumn();
         this.groupBoxConfiguration = new System.Windows.Forms.GroupBox();
         this.dataGridViewConfiguration = new System.Windows.Forms.DataGridView();
         this.ColumnDemoConfiguration = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnLinkConfiguration = new System.Windows.Forms.DataGridViewLinkColumn();
         this.richTextBoxCaption = new System.Windows.Forms.RichTextBox();
         this.groupBoxTroubleShooting = new System.Windows.Forms.GroupBox();
         this.dataGridViewTroubleshooting = new System.Windows.Forms.DataGridView();
         this.ColumnProblem = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnLinkTroubleshooting = new System.Windows.Forms.DataGridViewLinkColumn();
         this.groupBoxDicomServers.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDicomServers)).BeginInit();
         this.groupBoxDicomClients.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDicomClients)).BeginInit();
         this.groupBoxDicomViewers.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDicomViewers)).BeginInit();
         this.groupBoxConfiguration.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConfiguration)).BeginInit();
         this.groupBoxTroubleShooting.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTroubleshooting)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBoxDicomServers
         // 
         this.groupBoxDicomServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxDicomServers.Controls.Add(this.dataGridViewDicomServers);
         this.groupBoxDicomServers.Location = new System.Drawing.Point(7, 163);
         this.groupBoxDicomServers.Name = "groupBoxDicomServers";
         this.groupBoxDicomServers.Size = new System.Drawing.Size(502, 82);
         this.groupBoxDicomServers.TabIndex = 2;
         this.groupBoxDicomServers.TabStop = false;
         this.groupBoxDicomServers.Text = "DICOM Server Demos";
         // 
         // dataGridViewDicomServers
         // 
         this.dataGridViewDicomServers.AllowUserToAddRows = false;
         this.dataGridViewDicomServers.AllowUserToDeleteRows = false;
         this.dataGridViewDicomServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridViewDicomServers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDemo,
            this.ColumnDescription});
         this.dataGridViewDicomServers.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridViewDicomServers.Location = new System.Drawing.Point(3, 16);
         this.dataGridViewDicomServers.Name = "dataGridViewDicomServers";
         this.dataGridViewDicomServers.ReadOnly = true;
         this.dataGridViewDicomServers.Size = new System.Drawing.Size(496, 63);
         this.dataGridViewDicomServers.TabIndex = 0;
         // 
         // ColumnDemo
         // 
         this.ColumnDemo.HeaderText = "Demo";
         this.ColumnDemo.Name = "ColumnDemo";
         this.ColumnDemo.ReadOnly = true;
         // 
         // ColumnDescription
         // 
         this.ColumnDescription.HeaderText = "Link";
         this.ColumnDescription.Name = "ColumnDescription";
         this.ColumnDescription.ReadOnly = true;
         // 
         // groupBoxDicomClients
         // 
         this.groupBoxDicomClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxDicomClients.Controls.Add(this.dataGridViewDicomClients);
         this.groupBoxDicomClients.Location = new System.Drawing.Point(7, 264);
         this.groupBoxDicomClients.Name = "groupBoxDicomClients";
         this.groupBoxDicomClients.Size = new System.Drawing.Size(502, 123);
         this.groupBoxDicomClients.TabIndex = 3;
         this.groupBoxDicomClients.TabStop = false;
         this.groupBoxDicomClients.Text = "DICOM Client Demos";
         // 
         // dataGridViewDicomClients
         // 
         this.dataGridViewDicomClients.AllowUserToAddRows = false;
         this.dataGridViewDicomClients.AllowUserToDeleteRows = false;
         this.dataGridViewDicomClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridViewDicomClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDemoClient,
            this.ColumnLinkClient});
         this.dataGridViewDicomClients.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridViewDicomClients.Location = new System.Drawing.Point(3, 16);
         this.dataGridViewDicomClients.Name = "dataGridViewDicomClients";
         this.dataGridViewDicomClients.ReadOnly = true;
         this.dataGridViewDicomClients.Size = new System.Drawing.Size(496, 104);
         this.dataGridViewDicomClients.TabIndex = 0;
         // 
         // ColumnDemoClient
         // 
         this.ColumnDemoClient.HeaderText = "Demo";
         this.ColumnDemoClient.Name = "ColumnDemoClient";
         this.ColumnDemoClient.ReadOnly = true;
         // 
         // ColumnLinkClient
         // 
         this.ColumnLinkClient.HeaderText = "Link";
         this.ColumnLinkClient.Name = "ColumnLinkClient";
         this.ColumnLinkClient.ReadOnly = true;
         // 
         // groupBoxDicomViewers
         // 
         this.groupBoxDicomViewers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxDicomViewers.Controls.Add(this.dataGridViewDicomViewers);
         this.groupBoxDicomViewers.Location = new System.Drawing.Point(7, 406);
         this.groupBoxDicomViewers.Name = "groupBoxDicomViewers";
         this.groupBoxDicomViewers.Size = new System.Drawing.Size(502, 83);
         this.groupBoxDicomViewers.TabIndex = 4;
         this.groupBoxDicomViewers.TabStop = false;
         this.groupBoxDicomViewers.Text = "DICOM Viewer Demos";
         // 
         // dataGridViewDicomViewers
         // 
         this.dataGridViewDicomViewers.AllowUserToAddRows = false;
         this.dataGridViewDicomViewers.AllowUserToDeleteRows = false;
         this.dataGridViewDicomViewers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridViewDicomViewers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDemoViewer,
            this.ColumnLinkViewer});
         this.dataGridViewDicomViewers.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridViewDicomViewers.Location = new System.Drawing.Point(3, 16);
         this.dataGridViewDicomViewers.Name = "dataGridViewDicomViewers";
         this.dataGridViewDicomViewers.ReadOnly = true;
         this.dataGridViewDicomViewers.Size = new System.Drawing.Size(496, 64);
         this.dataGridViewDicomViewers.TabIndex = 0;
         // 
         // ColumnDemoViewer
         // 
         this.ColumnDemoViewer.HeaderText = "Demo";
         this.ColumnDemoViewer.Name = "ColumnDemoViewer";
         this.ColumnDemoViewer.ReadOnly = true;
         // 
         // ColumnLinkViewer
         // 
         this.ColumnLinkViewer.HeaderText = "Link";
         this.ColumnLinkViewer.Name = "ColumnLinkViewer";
         this.ColumnLinkViewer.ReadOnly = true;
         // 
         // groupBoxConfiguration
         // 
         this.groupBoxConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxConfiguration.Controls.Add(this.dataGridViewConfiguration);
         this.groupBoxConfiguration.Location = new System.Drawing.Point(7, 60);
         this.groupBoxConfiguration.Name = "groupBoxConfiguration";
         this.groupBoxConfiguration.Size = new System.Drawing.Size(502, 84);
         this.groupBoxConfiguration.TabIndex = 5;
         this.groupBoxConfiguration.TabStop = false;
         this.groupBoxConfiguration.Text = "Configuration Demos (These run automatically when needed)";
         // 
         // dataGridViewConfiguration
         // 
         this.dataGridViewConfiguration.AllowUserToAddRows = false;
         this.dataGridViewConfiguration.AllowUserToDeleteRows = false;
         this.dataGridViewConfiguration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridViewConfiguration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDemoConfiguration,
            this.ColumnLinkConfiguration});
         this.dataGridViewConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridViewConfiguration.Location = new System.Drawing.Point(3, 16);
         this.dataGridViewConfiguration.Name = "dataGridViewConfiguration";
         this.dataGridViewConfiguration.ReadOnly = true;
         this.dataGridViewConfiguration.Size = new System.Drawing.Size(496, 65);
         this.dataGridViewConfiguration.TabIndex = 0;
         // 
         // ColumnDemoConfiguration
         // 
         this.ColumnDemoConfiguration.HeaderText = "Demo";
         this.ColumnDemoConfiguration.Name = "ColumnDemoConfiguration";
         this.ColumnDemoConfiguration.ReadOnly = true;
         // 
         // ColumnLinkConfiguration
         // 
         this.ColumnLinkConfiguration.HeaderText = "Link";
         this.ColumnLinkConfiguration.Name = "ColumnLinkConfiguration";
         this.ColumnLinkConfiguration.ReadOnly = true;
         // 
         // richTextBoxCaption
         // 
         this.richTextBoxCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.richTextBoxCaption.BackColor = System.Drawing.SystemColors.Control;
         this.richTextBoxCaption.Location = new System.Drawing.Point(7, -1);
         this.richTextBoxCaption.Name = "richTextBoxCaption";
         this.richTextBoxCaption.Size = new System.Drawing.Size(502, 55);
         this.richTextBoxCaption.TabIndex = 6;
         this.richTextBoxCaption.Text = "";
         // 
         // groupBoxTroubleShooting
         // 
         this.groupBoxTroubleShooting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxTroubleShooting.Controls.Add(this.dataGridViewTroubleshooting);
         this.groupBoxTroubleShooting.Location = new System.Drawing.Point(7, 502);
         this.groupBoxTroubleShooting.Name = "groupBoxTroubleShooting";
         this.groupBoxTroubleShooting.Size = new System.Drawing.Size(502, 83);
         this.groupBoxTroubleShooting.TabIndex = 7;
         this.groupBoxTroubleShooting.TabStop = false;
         this.groupBoxTroubleShooting.Text = "Troubleshooting";
         // 
         // dataGridViewTroubleshooting
         // 
         this.dataGridViewTroubleshooting.AllowUserToAddRows = false;
         this.dataGridViewTroubleshooting.AllowUserToDeleteRows = false;
         this.dataGridViewTroubleshooting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridViewTroubleshooting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnProblem,
            this.ColumnLinkTroubleshooting});
         this.dataGridViewTroubleshooting.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridViewTroubleshooting.Location = new System.Drawing.Point(3, 16);
         this.dataGridViewTroubleshooting.Name = "dataGridViewTroubleshooting";
         this.dataGridViewTroubleshooting.ReadOnly = true;
         this.dataGridViewTroubleshooting.Size = new System.Drawing.Size(496, 64);
         this.dataGridViewTroubleshooting.TabIndex = 0;
         // 
         // ColumnProblem
         // 
         this.ColumnProblem.HeaderText = "Problem";
         this.ColumnProblem.Name = "ColumnProblem";
         this.ColumnProblem.ReadOnly = true;
         // 
         // ColumnLinkTroubleshooting
         // 
         this.ColumnLinkTroubleshooting.HeaderText = "Link";
         this.ColumnLinkTroubleshooting.Name = "ColumnLinkTroubleshooting";
         this.ColumnLinkTroubleshooting.ReadOnly = true;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(516, 594);
         this.Controls.Add(this.groupBoxTroubleShooting);
         this.Controls.Add(this.richTextBoxCaption);
         this.Controls.Add(this.groupBoxConfiguration);
         this.Controls.Add(this.groupBoxDicomViewers);
         this.Controls.Add(this.groupBoxDicomClients);
         this.Controls.Add(this.groupBoxDicomServers);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "Form1";
         this.Text = "LEADTOOLS Medical Menu Demo";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.groupBoxDicomServers.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDicomServers)).EndInit();
         this.groupBoxDicomClients.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDicomClients)).EndInit();
         this.groupBoxDicomViewers.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDicomViewers)).EndInit();
         this.groupBoxConfiguration.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConfiguration)).EndInit();
         this.groupBoxTroubleShooting.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTroubleshooting)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion
      private System.Windows.Forms.GroupBox groupBoxDicomServers;
      private System.Windows.Forms.DataGridView dataGridViewDicomServers;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDemo;
      private System.Windows.Forms.DataGridViewLinkColumn ColumnDescription;
      private System.Windows.Forms.GroupBox groupBoxDicomClients;
      private System.Windows.Forms.DataGridView dataGridViewDicomClients;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDemoClient;
      private System.Windows.Forms.DataGridViewLinkColumn ColumnLinkClient;
      private System.Windows.Forms.GroupBox groupBoxDicomViewers;
      private System.Windows.Forms.DataGridView dataGridViewDicomViewers;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDemoViewer;
      private System.Windows.Forms.DataGridViewLinkColumn ColumnLinkViewer;
      private System.Windows.Forms.GroupBox groupBoxConfiguration;
      private System.Windows.Forms.DataGridView dataGridViewConfiguration;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDemoConfiguration;
      private System.Windows.Forms.DataGridViewLinkColumn ColumnLinkConfiguration;
      private System.Windows.Forms.RichTextBox richTextBoxCaption;
      private System.Windows.Forms.GroupBox groupBoxTroubleShooting;
      private System.Windows.Forms.DataGridView dataGridViewTroubleshooting;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProblem;
      private System.Windows.Forms.DataGridViewLinkColumn ColumnLinkTroubleshooting;
   }
}

