namespace PDFDocumentDemo.Annotations
{
   partial class AnnotationsControl
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnnotationsControl));
         this._annotationsLabel = new System.Windows.Forms.Label();
         this._commentsListBox = new System.Windows.Forms.ListBox();
         this._automationListControl = new Leadtools.Annotations.WinForms.AutomationObjectsListControl();
         this._contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._contentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._toolbarPanel = new System.Windows.Forms.Panel();
         this._commentsListLabel = new System.Windows.Forms.Label();
         this._contextMenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _annotationsLabel
         // 
         resources.ApplyResources(this._annotationsLabel, "_annotationsLabel");
         this._annotationsLabel.Name = "_annotationsLabel";
         //
         //_automationListControl
         //
         this._automationListControl.ContextMenuStrip = this._contextMenuStrip;
         this._automationListControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this._automationListControl.Name = "_automationListControl";
         // 
         // _contextMenuStrip
         // 
         this._contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._propertiesToolStripMenuItem,
            this._contentToolStripMenuItem,
            this._deleteToolStripMenuItem});
         this._contextMenuStrip.Name = "_contextMenuStrip";
         resources.ApplyResources(this._contextMenuStrip, "_contextMenuStrip");
         // 
         // _propertiesToolStripMenuItem
         // 
         this._propertiesToolStripMenuItem.Name = "_propertiesToolStripMenuItem";
         resources.ApplyResources(this._propertiesToolStripMenuItem, "_propertiesToolStripMenuItem");
         this._propertiesToolStripMenuItem.Click += new System.EventHandler(this._propertiesToolStripMenuItem_Click);
         // 
         // _contentToolStripMenuItem
         // 
         this._contentToolStripMenuItem.Name = "_contentToolStripMenuItem";
         resources.ApplyResources(this._contentToolStripMenuItem, "_contentToolStripMenuItem");
         this._contentToolStripMenuItem.Click += new System.EventHandler(this._contentToolStripMenuItem_Click);
         // 
         // _deleteToolStripMenuItem
         // 
         this._deleteToolStripMenuItem.Name = "_deleteToolStripMenuItem";
         resources.ApplyResources(this._deleteToolStripMenuItem, "_deleteToolStripMenuItem");
         this._deleteToolStripMenuItem.Click += new System.EventHandler(this._deleteToolStripMenuItem_Click);
         // 
         // _toolbarPanel
         // 
         resources.ApplyResources(this._toolbarPanel, "_toolbarPanel");
         this._toolbarPanel.Name = "_toolbarPanel";
         // 
         // _commentsListLabel
         // 
         resources.ApplyResources(this._commentsListLabel, "_commentsListLabel");
         this._commentsListLabel.Name = "_commentsListLabel";
         // 
         // AnnotationsControl
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         //this.Controls.Add(this._commentsListBox);
         this.Controls.Add(this._automationListControl);
         this.Controls.Add(this._commentsListLabel);
         this.Controls.Add(this._toolbarPanel);
         this.Controls.Add(this._annotationsLabel);
         this.Name = "AnnotationsControl";
         this._contextMenuStrip.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _annotationsLabel;
      private Leadtools.Annotations.WinForms.AutomationObjectsListControl _automationListControl;
      private System.Windows.Forms.ListBox _commentsListBox;
      private System.Windows.Forms.Panel _toolbarPanel;
      private System.Windows.Forms.Label _commentsListLabel;
      private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem _propertiesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _deleteToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _contentToolStripMenuItem;
   }
}
