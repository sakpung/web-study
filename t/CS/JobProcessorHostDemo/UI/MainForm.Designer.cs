namespace JobProcessorHostDemo
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
         if ( disposing && (components != null) )
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
         this._btnStartup = new System.Windows.Forms.Button();
         this._btnShutDown = new System.Windows.Forms.Button();
         this._lstReport = new System.Windows.Forms.ListBox();
         this._btnClose = new System.Windows.Forms.Button();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this._txtAlias = new System.Windows.Forms.TextBox();
         this._txtAddress = new System.Windows.Forms.TextBox();
         this._lblAlias = new System.Windows.Forms.Label();
         this._txtPort = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this._lblAddress = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._lstvwDatabases = new System.Windows.Forms.ListView();
         this.clmhdrKey = new System.Windows.Forms.ColumnHeader();
         this.clmhdrValue = new System.Windows.Forms.ColumnHeader();
         this.buttonDatabaseConfigure = new System.Windows.Forms.Button();
         this.groupBox2.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnStartup
         // 
         this._btnStartup.Location = new System.Drawing.Point(12, 308);
         this._btnStartup.Name = "_btnStartup";
         this._btnStartup.Size = new System.Drawing.Size(75, 23);
         this._btnStartup.TabIndex = 0;
         this._btnStartup.Text = "&Startup";
         this._btnStartup.UseVisualStyleBackColor = true;
         this._btnStartup.Click += new System.EventHandler(this._btnStartup_Click);
         // 
         // _btnShutDown
         // 
         this._btnShutDown.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnShutDown.Enabled = false;
         this._btnShutDown.Location = new System.Drawing.Point(115, 308);
         this._btnShutDown.Name = "_btnShutDown";
         this._btnShutDown.Size = new System.Drawing.Size(75, 23);
         this._btnShutDown.TabIndex = 1;
         this._btnShutDown.Text = "&Shutdown";
         this._btnShutDown.UseVisualStyleBackColor = true;
         this._btnShutDown.Click += new System.EventHandler(this._btnShutDown_Click);
         // 
         // _lstReport
         // 
         this._lstReport.FormattingEnabled = true;
         this._lstReport.HorizontalScrollbar = true;
         this._lstReport.Location = new System.Drawing.Point(12, 119);
         this._lstReport.Name = "_lstReport";
         this._lstReport.Size = new System.Drawing.Size(280, 173);
         this._lstReport.TabIndex = 2;
         // 
         // _btnClose
         // 
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnClose.Location = new System.Drawing.Point(213, 308);
         this._btnClose.Name = "_btnClose";
         this._btnClose.Size = new System.Drawing.Size(75, 23);
         this._btnClose.TabIndex = 7;
         this._btnClose.Text = "&Close";
         this._btnClose.UseVisualStyleBackColor = true;
         this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this._txtAlias);
         this.groupBox2.Controls.Add(this._txtAddress);
         this.groupBox2.Controls.Add(this._lblAlias);
         this.groupBox2.Controls.Add(this._txtPort);
         this.groupBox2.Controls.Add(this.label1);
         this.groupBox2.Controls.Add(this._lblAddress);
         this.groupBox2.Location = new System.Drawing.Point(12, 12);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(280, 101);
         this.groupBox2.TabIndex = 8;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Settings:";
         // 
         // _txtAlias
         // 
         this._txtAlias.Location = new System.Drawing.Point(103, 19);
         this._txtAlias.Name = "_txtAlias";
         this._txtAlias.Size = new System.Drawing.Size(168, 20);
         this._txtAlias.TabIndex = 11;
         this._txtAlias.Text = "LEADTOOLSJobProcessorServices";
         // 
         // _txtAddress
         // 
         this._txtAddress.Location = new System.Drawing.Point(103, 47);
         this._txtAddress.Name = "_txtAddress";
         this._txtAddress.Size = new System.Drawing.Size(168, 20);
         this._txtAddress.TabIndex = 12;
         // 
         // _lblAlias
         // 
         this._lblAlias.AutoSize = true;
         this._lblAlias.Location = new System.Drawing.Point(9, 22);
         this._lblAlias.Name = "_lblAlias";
         this._lblAlias.Size = new System.Drawing.Size(83, 13);
         this._lblAlias.TabIndex = 10;
         this._lblAlias.Text = "Alias (Optional) :";
         // 
         // _txtPort
         // 
         this._txtPort.Location = new System.Drawing.Point(103, 75);
         this._txtPort.MaxLength = 4;
         this._txtPort.Name = "_txtPort";
         this._txtPort.Size = new System.Drawing.Size(59, 20);
         this._txtPort.TabIndex = 13;
         this._txtPort.Text = "8181";
         this._txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtPort_KeyPress);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(11, 78);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(29, 13);
         this.label1.TabIndex = 9;
         this.label1.Text = "Port:";
         // 
         // _lblAddress
         // 
         this._lblAddress.AutoSize = true;
         this._lblAddress.Location = new System.Drawing.Point(11, 50);
         this._lblAddress.Name = "_lblAddress";
         this._lblAddress.Size = new System.Drawing.Size(64, 13);
         this._lblAddress.TabIndex = 8;
         this._lblAddress.Text = "IP Address :";
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)));
         this.groupBox1.Controls.Add(this._lstvwDatabases);
         this.groupBox1.Controls.Add(this.buttonDatabaseConfigure);
         this.groupBox1.Location = new System.Drawing.Point(1, 339);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(291, 127);
         this.groupBox1.TabIndex = 10;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Database Configuration";
         // 
         // _lstvwDatabases
         // 
         this._lstvwDatabases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmhdrKey,
            this.clmhdrValue});
         this._lstvwDatabases.Dock = System.Windows.Forms.DockStyle.Top;
         this._lstvwDatabases.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
         this._lstvwDatabases.Location = new System.Drawing.Point(3, 16);
         this._lstvwDatabases.MultiSelect = false;
         this._lstvwDatabases.Name = "_lstvwDatabases";
         this._lstvwDatabases.Size = new System.Drawing.Size(285, 79);
         this._lstvwDatabases.TabIndex = 9;
         this._lstvwDatabases.UseCompatibleStateImageBehavior = false;
         this._lstvwDatabases.View = System.Windows.Forms.View.Details;
         // 
         // clmhdrKey
         // 
         this.clmhdrKey.Text = "";
         this.clmhdrKey.Width = 100;
         // 
         // clmhdrValue
         // 
         this.clmhdrValue.Text = "";
         this.clmhdrValue.Width = 200;
         // 
         // buttonDatabaseConfigure
         // 
         this.buttonDatabaseConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonDatabaseConfigure.Location = new System.Drawing.Point(210, 104);
         this.buttonDatabaseConfigure.Name = "buttonDatabaseConfigure";
         this.buttonDatabaseConfigure.Size = new System.Drawing.Size(75, 23);
         this.buttonDatabaseConfigure.TabIndex = 8;
         this.buttonDatabaseConfigure.Text = "Configure...";
         this.buttonDatabaseConfigure.UseVisualStyleBackColor = true;
         this.buttonDatabaseConfigure.Click += new System.EventHandler(this.buttonDatabaseConfigure_Click);
         // 
         // MainForm
         // 
         this.AcceptButton = this._btnStartup;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(304, 468);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this._btnClose);
         this.Controls.Add(this._lstReport);
         this.Controls.Add(this._btnShutDown);
         this.Controls.Add(this._btnStartup);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "LEADTOOLS JobProcessor Self Host";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnStartup;
      private System.Windows.Forms.Button _btnShutDown;
      private System.Windows.Forms.ListBox _lstReport;
      private System.Windows.Forms.Button _btnClose;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TextBox _txtAlias;
      private System.Windows.Forms.TextBox _txtAddress;
      private System.Windows.Forms.Label _lblAlias;
      private System.Windows.Forms.TextBox _txtPort;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label _lblAddress;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ListView _lstvwDatabases;
      private System.Windows.Forms.ColumnHeader clmhdrKey;
      private System.Windows.Forms.ColumnHeader clmhdrValue;
      private System.Windows.Forms.Button buttonDatabaseConfigure;
   }
}

