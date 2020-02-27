namespace Leadtools.WebScanning.Host
{
   partial class WebScanningForm
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebScanningForm));
         this._startupChkBox = new System.Windows.Forms.CheckBox();
         this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
         this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.trayContextMenu.SuspendLayout();
         this.SuspendLayout();
         // 
         // _startupChkBox
         // 
         this._startupChkBox.AutoSize = true;
         this._startupChkBox.Checked = true;
         this._startupChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
         this._startupChkBox.Location = new System.Drawing.Point(12, 58);
         this._startupChkBox.Name = "_startupChkBox";
         this._startupChkBox.Size = new System.Drawing.Size(229, 17);
         this._startupChkBox.TabIndex = 0;
         this._startupChkBox.Text = "Run Scanning Service at Windows Startup";
         this._startupChkBox.UseVisualStyleBackColor = true;
         this._startupChkBox.CheckedChanged += new System.EventHandler(this.StartupChkBox_CheckedChanged);
         // 
         // trayIcon
         // 
         this.trayIcon.ContextMenuStrip = this.trayContextMenu;
         this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
         this.trayIcon.Text = "Web Scanning Service";
         this.trayIcon.Visible = true;
         this.trayIcon.DoubleClick += new System.EventHandler(this.TrayIcon_DoubleClick);
         // 
         // trayContextMenu
         // 
         this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
         this.trayContextMenu.Name = "trayContextMenu";
         this.trayContextMenu.Size = new System.Drawing.Size(104, 48);
         // 
         // openToolStripMenuItem
         // 
         this.openToolStripMenuItem.Name = "openToolStripMenuItem";
         this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
         this.openToolStripMenuItem.Text = "Open";
         this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
         this.exitToolStripMenuItem.Text = "Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
         // 
         // WebScanningForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(344, 133);
         this.Controls.Add(this._startupChkBox);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "WebScanningForm";
         this.Text = "Leadtools Web Scanning Service";
         this.Load += new System.EventHandler(this.WebScanningForm_Load);
         this.Resize += new System.EventHandler(this.WebScanningForm_Resize);
         this.trayContextMenu.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.CheckBox _startupChkBox;
      private System.Windows.Forms.NotifyIcon trayIcon;
      private System.Windows.Forms.ContextMenuStrip trayContextMenu;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
   }
}

