namespace Leadtools.Demos.StorageServer
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.MainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
         this.SystemTrayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.SystemTrayContextMenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // MainNotifyIcon
         // 
         this.MainNotifyIcon.ContextMenuStrip = this.SystemTrayContextMenuStrip;
         this.MainNotifyIcon.Text = "notifyIcon1";
         // 
         // SystemTrayContextMenuStrip
         // 
         this.SystemTrayContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
         this.SystemTrayContextMenuStrip.Name = "contextMenuStrip1";
         this.SystemTrayContextMenuStrip.Size = new System.Drawing.Size(108, 76);
         // 
         // showToolStripMenuItem
         // 
         this.showToolStripMenuItem.Name = "showToolStripMenuItem";
         this.showToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
         this.showToolStripMenuItem.Text = "Show";
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
         this.aboutToolStripMenuItem.Text = "About";
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
         this.exitToolStripMenuItem.Text = "Exit";
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1210, 787);
         this.DoubleBuffered = true;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "MainForm";
         this.Text = "LEADTOOLS Storage Server";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Shown += new System.EventHandler(this.MainForm_Shown);
         this.SystemTrayContextMenuStrip.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      internal System.Windows.Forms.NotifyIcon MainNotifyIcon;
      private System.Windows.Forms.ContextMenuStrip SystemTrayContextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;



   }
}

