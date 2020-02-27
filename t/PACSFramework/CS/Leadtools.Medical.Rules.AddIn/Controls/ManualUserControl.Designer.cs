namespace Leadtools.Medical.Rules.AddIn.Controls
{
   partial class ManualUserControl
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
         this.buttonDeleteAll = new System.Windows.Forms.Button();
         this.buttonVerifyServer = new System.Windows.Forms.Button();
         this.buttonDeleteAllServers = new System.Windows.Forms.Button();
         this.buttonDeleteServer = new System.Windows.Forms.Button();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.listViewDatasets = new System.Windows.Forms.ListView();
         this._columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this._columnHeader2 = new System.Windows.Forms.ColumnHeader();
         this._columnHeader3 = new System.Windows.Forms.ColumnHeader();
         this._columnHeader4 = new System.Windows.Forms.ColumnHeader();
         this._columnHeader5 = new System.Windows.Forms.ColumnHeader();
         this._columnHeader6 = new System.Windows.Forms.ColumnHeader();
         this.listViewServers = new System.Windows.Forms.ListView();
         this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
         this.buttonRetryAll = new System.Windows.Forms.Button();
         this.buttonRetry = new System.Windows.Forms.Button();
         this.buttonDeleteDataset = new System.Windows.Forms.Button();
         this.splitContainer2 = new System.Windows.Forms.SplitContainer();
         this.listView1 = new System.Windows.Forms.ListView();
         this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
         this.listView2 = new System.Windows.Forms.ListView();
         this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.splitContainer2.Panel1.SuspendLayout();
         this.splitContainer2.Panel2.SuspendLayout();
         this.splitContainer2.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonDeleteAll
         // 
         this.buttonDeleteAll.Location = new System.Drawing.Point(564, 38);
         this.buttonDeleteAll.Name = "buttonDeleteAll";
         this.buttonDeleteAll.Size = new System.Drawing.Size(75, 23);
         this.buttonDeleteAll.TabIndex = 1;
         this.buttonDeleteAll.Text = "Delete All";
         this.buttonDeleteAll.UseVisualStyleBackColor = true;
         // 
         // buttonVerifyServer
         // 
         this.buttonVerifyServer.Location = new System.Drawing.Point(564, 297);
         this.buttonVerifyServer.Name = "buttonVerifyServer";
         this.buttonVerifyServer.Size = new System.Drawing.Size(75, 23);
         this.buttonVerifyServer.TabIndex = 6;
         this.buttonVerifyServer.Text = "Verify";
         this.buttonVerifyServer.UseVisualStyleBackColor = true;
         // 
         // buttonDeleteAllServers
         // 
         this.buttonDeleteAllServers.Location = new System.Drawing.Point(564, 268);
         this.buttonDeleteAllServers.Name = "buttonDeleteAllServers";
         this.buttonDeleteAllServers.Size = new System.Drawing.Size(75, 23);
         this.buttonDeleteAllServers.TabIndex = 5;
         this.buttonDeleteAllServers.Text = "Delete All";
         this.buttonDeleteAllServers.UseVisualStyleBackColor = true;
         // 
         // buttonDeleteServer
         // 
         this.buttonDeleteServer.Location = new System.Drawing.Point(564, 239);
         this.buttonDeleteServer.Name = "buttonDeleteServer";
         this.buttonDeleteServer.Size = new System.Drawing.Size(75, 23);
         this.buttonDeleteServer.TabIndex = 4;
         this.buttonDeleteServer.Text = "Delete";
         this.buttonDeleteServer.UseVisualStyleBackColor = true;
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
         this.splitContainer1.Location = new System.Drawing.Point(3, 3);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.listViewDatasets);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.listViewServers);
         this.splitContainer1.Size = new System.Drawing.Size(555, 419);
         this.splitContainer1.SplitterDistance = 233;
         this.splitContainer1.TabIndex = 6;
         // 
         // listViewDatasets
         // 
         this.listViewDatasets.AllowDrop = true;
         this.listViewDatasets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._columnHeader1,
            this._columnHeader2,
            this._columnHeader3,
            this._columnHeader4,
            this._columnHeader5,
            this._columnHeader6});
         this.listViewDatasets.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewDatasets.FullRowSelect = true;
         this.listViewDatasets.GridLines = true;
         this.listViewDatasets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.listViewDatasets.HideSelection = false;
         this.listViewDatasets.Location = new System.Drawing.Point(0, 0);
         this.listViewDatasets.MultiSelect = false;
         this.listViewDatasets.Name = "listViewDatasets";
         this.listViewDatasets.Size = new System.Drawing.Size(555, 233);
         this.listViewDatasets.TabIndex = 0;
         this.listViewDatasets.UseCompatibleStateImageBehavior = false;
         this.listViewDatasets.View = System.Windows.Forms.View.Details;
         // 
         // _columnHeader1
         // 
         this._columnHeader1.Text = "Patient Name";
         this._columnHeader1.Width = 120;
         // 
         // _columnHeader2
         // 
         this._columnHeader2.Text = "Patient ID";
         this._columnHeader2.Width = 75;
         // 
         // _columnHeader3
         // 
         this._columnHeader3.Text = "Study ID";
         // 
         // _columnHeader4
         // 
         this._columnHeader4.Text = "Modality";
         // 
         // _columnHeader5
         // 
         this._columnHeader5.Text = "Transfer Syntax";
         this._columnHeader5.Width = 90;
         // 
         // _columnHeader6
         // 
         this._columnHeader6.Text = "File Path";
         this._columnHeader6.Width = 255;
         // 
         // listViewServers
         // 
         this.listViewServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
         this.listViewServers.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewServers.FullRowSelect = true;
         this.listViewServers.GridLines = true;
         this.listViewServers.HideSelection = false;
         this.listViewServers.Location = new System.Drawing.Point(0, 0);
         this.listViewServers.MultiSelect = false;
         this.listViewServers.Name = "listViewServers";
         this.listViewServers.Size = new System.Drawing.Size(555, 182);
         this.listViewServers.TabIndex = 0;
         this.listViewServers.UseCompatibleStateImageBehavior = false;
         this.listViewServers.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader6
         // 
         this.columnHeader6.Text = "Last Status";
         this.columnHeader6.Width = 130;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "AETitle";
         this.columnHeader1.Width = 100;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "IP/Hostname";
         this.columnHeader2.Width = 100;
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "Port";
         this.columnHeader3.Width = 45;
         // 
         // columnHeader4
         // 
         this.columnHeader4.Text = "Timeout";
         // 
         // columnHeader5
         // 
         this.columnHeader5.Text = "Secure";
         // 
         // buttonRetryAll
         // 
         this.buttonRetryAll.Location = new System.Drawing.Point(564, 96);
         this.buttonRetryAll.Name = "buttonRetryAll";
         this.buttonRetryAll.Size = new System.Drawing.Size(75, 23);
         this.buttonRetryAll.TabIndex = 3;
         this.buttonRetryAll.Text = "Retry All";
         this.buttonRetryAll.UseVisualStyleBackColor = true;
         // 
         // buttonRetry
         // 
         this.buttonRetry.Location = new System.Drawing.Point(564, 67);
         this.buttonRetry.Name = "buttonRetry";
         this.buttonRetry.Size = new System.Drawing.Size(75, 23);
         this.buttonRetry.TabIndex = 2;
         this.buttonRetry.Text = "Retry";
         this.buttonRetry.UseVisualStyleBackColor = true;
         // 
         // buttonDeleteDataset
         // 
         this.buttonDeleteDataset.Location = new System.Drawing.Point(564, 9);
         this.buttonDeleteDataset.Name = "buttonDeleteDataset";
         this.buttonDeleteDataset.Size = new System.Drawing.Size(75, 23);
         this.buttonDeleteDataset.TabIndex = 0;
         this.buttonDeleteDataset.Text = "Delete";
         this.buttonDeleteDataset.UseVisualStyleBackColor = true;
         // 
         // splitContainer2
         // 
         this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Left;
         this.splitContainer2.Location = new System.Drawing.Point(0, 0);
         this.splitContainer2.Name = "splitContainer2";
         this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer2.Panel1
         // 
         this.splitContainer2.Panel1.Controls.Add(this.listView1);
         // 
         // splitContainer2.Panel2
         // 
         this.splitContainer2.Panel2.Controls.Add(this.listView2);
         this.splitContainer2.Size = new System.Drawing.Size(555, 592);
         this.splitContainer2.SplitterDistance = 329;
         this.splitContainer2.TabIndex = 7;
         // 
         // listView1
         // 
         this.listView1.AllowDrop = true;
         this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
         this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listView1.FullRowSelect = true;
         this.listView1.GridLines = true;
         this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.listView1.HideSelection = false;
         this.listView1.Location = new System.Drawing.Point(0, 0);
         this.listView1.MultiSelect = false;
         this.listView1.Name = "listView1";
         this.listView1.Size = new System.Drawing.Size(555, 329);
         this.listView1.TabIndex = 0;
         this.listView1.UseCompatibleStateImageBehavior = false;
         this.listView1.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader7
         // 
         this.columnHeader7.Text = "Patient Name";
         this.columnHeader7.Width = 120;
         // 
         // columnHeader8
         // 
         this.columnHeader8.Text = "Patient ID";
         this.columnHeader8.Width = 75;
         // 
         // columnHeader9
         // 
         this.columnHeader9.Text = "Study ID";
         // 
         // columnHeader10
         // 
         this.columnHeader10.Text = "Modality";
         // 
         // columnHeader11
         // 
         this.columnHeader11.Text = "Transfer Syntax";
         this.columnHeader11.Width = 90;
         // 
         // columnHeader12
         // 
         this.columnHeader12.Text = "File Path";
         this.columnHeader12.Width = 255;
         // 
         // listView2
         // 
         this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18});
         this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listView2.FullRowSelect = true;
         this.listView2.GridLines = true;
         this.listView2.HideSelection = false;
         this.listView2.Location = new System.Drawing.Point(0, 0);
         this.listView2.MultiSelect = false;
         this.listView2.Name = "listView2";
         this.listView2.Size = new System.Drawing.Size(555, 259);
         this.listView2.TabIndex = 0;
         this.listView2.UseCompatibleStateImageBehavior = false;
         this.listView2.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader13
         // 
         this.columnHeader13.Text = "Last Status";
         this.columnHeader13.Width = 130;
         // 
         // columnHeader14
         // 
         this.columnHeader14.Text = "AETitle";
         this.columnHeader14.Width = 100;
         // 
         // columnHeader15
         // 
         this.columnHeader15.Text = "IP/Hostname";
         this.columnHeader15.Width = 100;
         // 
         // columnHeader16
         // 
         this.columnHeader16.Text = "Port";
         this.columnHeader16.Width = 45;
         // 
         // columnHeader17
         // 
         this.columnHeader17.Text = "Timeout";
         // 
         // columnHeader18
         // 
         this.columnHeader18.Text = "Secure";
         // 
         // FailureOptionsUserControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.splitContainer2);
         this.Name = "FailureOptionsUserControl";
         this.Size = new System.Drawing.Size(736, 592);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         this.splitContainer2.Panel1.ResumeLayout(false);
         this.splitContainer2.Panel2.ResumeLayout(false);
         this.splitContainer2.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button buttonDeleteAll;
      private System.Windows.Forms.Button buttonVerifyServer;
      private System.Windows.Forms.Button buttonDeleteAllServers;
      private System.Windows.Forms.Button buttonDeleteServer;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.ListView listViewDatasets;
      private System.Windows.Forms.ColumnHeader _columnHeader1;
      private System.Windows.Forms.ColumnHeader _columnHeader2;
      private System.Windows.Forms.ColumnHeader _columnHeader3;
      private System.Windows.Forms.ColumnHeader _columnHeader4;
      private System.Windows.Forms.ColumnHeader _columnHeader5;
      private System.Windows.Forms.ColumnHeader _columnHeader6;
      private System.Windows.Forms.ListView listViewServers;
      private System.Windows.Forms.ColumnHeader columnHeader6;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ColumnHeader columnHeader4;
      private System.Windows.Forms.ColumnHeader columnHeader5;
      private System.Windows.Forms.Button buttonRetryAll;
      private System.Windows.Forms.Button buttonRetry;
      private System.Windows.Forms.Button buttonDeleteDataset;
      private System.Windows.Forms.SplitContainer splitContainer2;
      private System.Windows.Forms.ListView listView1;
      private System.Windows.Forms.ColumnHeader columnHeader7;
      private System.Windows.Forms.ColumnHeader columnHeader8;
      private System.Windows.Forms.ColumnHeader columnHeader9;
      private System.Windows.Forms.ColumnHeader columnHeader10;
      private System.Windows.Forms.ColumnHeader columnHeader11;
      private System.Windows.Forms.ColumnHeader columnHeader12;
      private System.Windows.Forms.ListView listView2;
      private System.Windows.Forms.ColumnHeader columnHeader13;
      private System.Windows.Forms.ColumnHeader columnHeader14;
      private System.Windows.Forms.ColumnHeader columnHeader15;
      private System.Windows.Forms.ColumnHeader columnHeader16;
      private System.Windows.Forms.ColumnHeader columnHeader17;
      private System.Windows.Forms.ColumnHeader columnHeader18;

   }
}
