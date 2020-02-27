using Leadtools.Medical.Winforms ;

namespace Leadtools.Medical.Storage.AddIns.Controls
{
   partial class StorageDatabaseManagerDialog
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
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.addDICOMFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.addDICOMDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.databaseManager1 = new Leadtools.Medical.Winforms.StorageDatabaseManager();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(934, 24);
         this.menuStrip1.TabIndex = 1;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDICOMFileToolStripMenuItem,
            this.addDICOMDirectoryToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "&File";
         this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
         // 
         // addDICOMFileToolStripMenuItem
         // 
         this.addDICOMFileToolStripMenuItem.Name = "addDICOMFileToolStripMenuItem";
         this.addDICOMFileToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
         this.addDICOMFileToolStripMenuItem.Text = "&Add DICOM File...";
         this.addDICOMFileToolStripMenuItem.Click += new System.EventHandler(this.addDICOMFileToolStripMenuItem_Click);
         // 
         // addDICOMDirectoryToolStripMenuItem
         // 
         this.addDICOMDirectoryToolStripMenuItem.Name = "addDICOMDirectoryToolStripMenuItem";
         this.addDICOMDirectoryToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
         this.addDICOMDirectoryToolStripMenuItem.Text = "&Add DICOM Directory...";
         this.addDICOMDirectoryToolStripMenuItem.Click += new System.EventHandler(this.addDICOMDirectoryToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
         this.exitToolStripMenuItem.Text = "&Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
         this.optionsToolStripMenuItem.Text = "Options...";
         this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
         // 
         // databaseManager1
         // 
         this.databaseManager1.AETitle = null;
         this.databaseManager1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.databaseManager1.Font = new System.Drawing.Font("Arial", 8F);
         this.databaseManager1.ForeColor = System.Drawing.SystemColors.ControlText;
         this.databaseManager1.Location = new System.Drawing.Point(0, 24);
         this.databaseManager1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.databaseManager1.MinimumSize = new System.Drawing.Size(754, 523);
         this.databaseManager1.Name = "databaseManager1";
         this.databaseManager1.Size = new System.Drawing.Size(934, 540);
         this.databaseManager1.TabIndex = 0;
         // 
         // StorageDatabaseManagerDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
         this.ClientSize = new System.Drawing.Size(934, 564);
         this.Controls.Add(this.databaseManager1);
         this.Controls.Add(this.menuStrip1);
         this.ForeColor = System.Drawing.Color.White;
         this.MainMenuStrip = this.menuStrip1;
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(793, 567);
         this.Name = "StorageDatabaseManagerDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.Text = "Database Manager";
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private StorageDatabaseManager databaseManager1;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem addDICOMFileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem addDICOMDirectoryToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
   }
}