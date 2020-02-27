namespace Leadtools.Medical.Worklist.AddIns.Controls
{
   partial class DatabaseEditorDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseEditorDialog));
         this.databaseEditor1 = new Leadtools.Medical.Winforms.WorklistDatabaseEditor();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.worklistAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // databaseEditor1
         // 
         this.databaseEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.databaseEditor1.Location = new System.Drawing.Point(0, 24);
         this.databaseEditor1.MinimumSize = new System.Drawing.Size(805, 645);
         this.databaseEditor1.Name = "databaseEditor1";
         this.databaseEditor1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
         this.databaseEditor1.Size = new System.Drawing.Size(993, 758);
         this.databaseEditor1.TabIndex = 0;
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.worklistAddToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(993, 24);
         this.menuStrip1.TabIndex = 1;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.exitToolStripMenuItem.Text = "&Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // worklistAddToolStripMenuItem
         // 
         this.worklistAddToolStripMenuItem.Name = "worklistAddToolStripMenuItem";
         this.worklistAddToolStripMenuItem.Size = new System.Drawing.Size(161, 20);
         this.worklistAddToolStripMenuItem.Text = "Worklist Add-Ins Options...";
         this.worklistAddToolStripMenuItem.Click += new System.EventHandler(this.worklistAddToolStripMenuItem_Click);
         // 
         // DatabaseEditorDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(993, 782);
         this.Controls.Add(this.databaseEditor1);
         this.Controls.Add(this.menuStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "DatabaseEditorDialog";
         this.Text = "Database Editor";
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Leadtools.Medical.Winforms.WorklistDatabaseEditor databaseEditor1;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem worklistAddToolStripMenuItem;
   }
}