namespace Leadtools.Medical.Winforms.ClientManager
{
   partial class RealTimeViewerControl
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
            this.listViewClients = new System.Windows.Forms.ListView();
            this.columnIpAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAeTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnConnectTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLastAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTotalConnectTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripClients = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonViewAssociation = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDisconnectClient = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripClients.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewClients
            // 
            this.listViewClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIpAddress,
            this.columnAeTitle,
            this.columnConnectTime,
            this.columnLastAction,
            this.columnTotalConnectTime});
            this.listViewClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewClients.FullRowSelect = true;
            this.listViewClients.GridLines = true;
            this.listViewClients.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewClients.HideSelection = false;
            this.listViewClients.Location = new System.Drawing.Point(0, 39);
            this.listViewClients.MultiSelect = false;
            this.listViewClients.Name = "listViewClients";
            this.listViewClients.Size = new System.Drawing.Size(547, 320);
            this.listViewClients.TabIndex = 2;
            this.listViewClients.UseCompatibleStateImageBehavior = false;
            this.listViewClients.View = System.Windows.Forms.View.Details;
            // 
            // columnIpAddress
            // 
            this.columnIpAddress.Tag = "1";
            this.columnIpAddress.Text = "IP Address";
            this.columnIpAddress.Width = 95;
            // 
            // columnAeTitle
            // 
            this.columnAeTitle.Tag = "1";
            this.columnAeTitle.Text = "AETitle";
            this.columnAeTitle.Width = 100;
            // 
            // columnConnectTime
            // 
            this.columnConnectTime.Tag = "1";
            this.columnConnectTime.Text = "Connect Time";
            this.columnConnectTime.Width = 100;
            // 
            // columnLastAction
            // 
            this.columnLastAction.Tag = "1";
            this.columnLastAction.Text = "Last Action";
            this.columnLastAction.Width = 150;
            // 
            // columnTotalConnectTime
            // 
            this.columnTotalConnectTime.Tag = "2";
            this.columnTotalConnectTime.Text = "Total Time Connected";
            this.columnTotalConnectTime.Width = 150;
            // 
            // toolStripClients
            // 
            this.toolStripClients.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripClients.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripClients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonViewAssociation,
            this.toolStripButtonDisconnectClient});
            this.toolStripClients.Location = new System.Drawing.Point(0, 0);
            this.toolStripClients.Name = "toolStripClients";
            this.toolStripClients.Size = new System.Drawing.Size(547, 39);
            this.toolStripClients.Stretch = true;
            this.toolStripClients.TabIndex = 4;
            // 
            // toolStripButtonViewAssociation
            // 
            this.toolStripButtonViewAssociation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonViewAssociation.Enabled = false;
            this.toolStripButtonViewAssociation.Image = global::Leadtools.Medical.Winforms.Properties.Resources.ClientAssociation_Image;
            this.toolStripButtonViewAssociation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonViewAssociation.Name = "toolStripButtonViewAssociation";
            this.toolStripButtonViewAssociation.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonViewAssociation.Text = "View Assocation";
            this.toolStripButtonViewAssociation.Click += new System.EventHandler(this.toolStripButtonViewAssociation_Click);
            // 
            // toolStripButtonDisconnectClient
            // 
            this.toolStripButtonDisconnectClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDisconnectClient.Enabled = false;
            this.toolStripButtonDisconnectClient.Image = global::Leadtools.Medical.Winforms.Properties.Resources.ClientDisconnect_Image;
            this.toolStripButtonDisconnectClient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDisconnectClient.Name = "toolStripButtonDisconnectClient";
            this.toolStripButtonDisconnectClient.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonDisconnectClient.Text = "Disconnect Client";
            this.toolStripButtonDisconnectClient.Click += new System.EventHandler(this.toolStripButtonDisconnectClient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actions:";
            // 
            // RealTimeViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewClients);
            this.Controls.Add(this.toolStripClients);
            this.Name = "RealTimeViewerControl";
            this.Size = new System.Drawing.Size(547, 359);
            this.toolStripClients.ResumeLayout(false);
            this.toolStripClients.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListView listViewClients;
      private System.Windows.Forms.ColumnHeader columnIpAddress;
      private System.Windows.Forms.ColumnHeader columnAeTitle;
      private System.Windows.Forms.ColumnHeader columnConnectTime;
      private System.Windows.Forms.ColumnHeader columnLastAction;
      private System.Windows.Forms.ColumnHeader columnTotalConnectTime;
      private System.Windows.Forms.ToolStrip toolStripClients;
      private System.Windows.Forms.ToolStripButton toolStripButtonViewAssociation;
      private System.Windows.Forms.ToolStripButton toolStripButtonDisconnectClient;
      private System.Windows.Forms.Label label1;      
   }
}
