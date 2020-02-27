namespace Leadtools.Medical.Rules.AddIn.Controls
{
   partial class AssemblyChooserDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblyChooserDialog));
         this.tabControlReferences = new System.Windows.Forms.TabControl();
         this.tabPageReferences = new System.Windows.Forms.TabPage();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
         this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
         this.tabPageNamespaces = new System.Windows.Forms.TabPage();
         this.textBoxNamespaces = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.listViewReferences = new Leadtools.Medical.Rules.AddIn.Controls.DoubleBufferedListView();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
         this.tabControlReferences.SuspendLayout();
         this.tabPageReferences.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.tabPageNamespaces.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControlReferences
         // 
         this.tabControlReferences.Controls.Add(this.tabPageReferences);
         this.tabControlReferences.Controls.Add(this.tabPageNamespaces);
         this.tabControlReferences.Location = new System.Drawing.Point(12, 12);
         this.tabControlReferences.Name = "tabControlReferences";
         this.tabControlReferences.SelectedIndex = 0;
         this.tabControlReferences.Size = new System.Drawing.Size(580, 322);
         this.tabControlReferences.TabIndex = 0;
         // 
         // tabPageReferences
         // 
         this.tabPageReferences.Controls.Add(this.listViewReferences);
         this.tabPageReferences.Controls.Add(this.toolStrip1);
         this.tabPageReferences.Location = new System.Drawing.Point(4, 22);
         this.tabPageReferences.Name = "tabPageReferences";
         this.tabPageReferences.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageReferences.Size = new System.Drawing.Size(572, 296);
         this.tabPageReferences.TabIndex = 0;
         this.tabPageReferences.Text = "References";
         this.tabPageReferences.UseVisualStyleBackColor = true;
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonDelete});
         this.toolStrip1.Location = new System.Drawing.Point(3, 3);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(566, 25);
         this.toolStrip1.TabIndex = 1;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripButtonAdd
         // 
         this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButtonAdd.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.AddAssembly;
         this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonAdd.Name = "toolStripButtonAdd";
         this.toolStripButtonAdd.Size = new System.Drawing.Size(23, 22);
         this.toolStripButtonAdd.Text = "Add assembly";
         this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
         // 
         // toolStripButtonDelete
         // 
         this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButtonDelete.Enabled = false;
         this.toolStripButtonDelete.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.DeleteAssembly;
         this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonDelete.Name = "toolStripButtonDelete";
         this.toolStripButtonDelete.Size = new System.Drawing.Size(23, 22);
         this.toolStripButtonDelete.Text = "Delete assembly";
         this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
         // 
         // tabPageNamespaces
         // 
         this.tabPageNamespaces.Controls.Add(this.textBoxNamespaces);
         this.tabPageNamespaces.Controls.Add(this.label1);
         this.tabPageNamespaces.Location = new System.Drawing.Point(4, 22);
         this.tabPageNamespaces.Name = "tabPageNamespaces";
         this.tabPageNamespaces.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageNamespaces.Size = new System.Drawing.Size(572, 296);
         this.tabPageNamespaces.TabIndex = 1;
         this.tabPageNamespaces.Text = "Namespaces";
         this.tabPageNamespaces.UseVisualStyleBackColor = true;
         // 
         // textBoxNamespaces
         // 
         this.textBoxNamespaces.Location = new System.Drawing.Point(10, 24);
         this.textBoxNamespaces.Multiline = true;
         this.textBoxNamespaces.Name = "textBoxNamespaces";
         this.textBoxNamespaces.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.textBoxNamespaces.Size = new System.Drawing.Size(556, 266);
         this.textBoxNamespaces.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(7, 7);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(209, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Place each namespace on a separate line:";
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(512, 340);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 1;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(431, 340);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 2;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         // 
         // listViewReferences
         // 
         this.listViewReferences.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
         this.listViewReferences.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewReferences.FullRowSelect = true;
         this.listViewReferences.HideSelection = false;
         this.listViewReferences.Location = new System.Drawing.Point(3, 28);
         this.listViewReferences.Name = "listViewReferences";
         this.listViewReferences.Size = new System.Drawing.Size(566, 265);
         this.listViewReferences.Sorting = System.Windows.Forms.SortOrder.Ascending;
         this.listViewReferences.TabIndex = 2;
         this.listViewReferences.UseCompatibleStateImageBehavior = false;
         this.listViewReferences.View = System.Windows.Forms.View.Details;
         this.listViewReferences.SelectedIndexChanged += new System.EventHandler(this.listViewReferences_SelectedIndexChanged);
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Name";
         this.columnHeader1.Width = 176;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Version";
         this.columnHeader2.Width = 84;
         // 
         // AssemblyChooserDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(604, 375);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.tabControlReferences);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AssemblyChooserDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Assembly Chooser";
         this.Load += new System.EventHandler(this.AssemblyChooserDialog_Load);
         this.tabControlReferences.ResumeLayout(false);
         this.tabPageReferences.ResumeLayout(false);
         this.tabPageReferences.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.tabPageNamespaces.ResumeLayout(false);
         this.tabPageNamespaces.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tabControlReferences;
      private System.Windows.Forms.TabPage tabPageReferences;
      private System.Windows.Forms.TabPage tabPageNamespaces;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.TextBox textBoxNamespaces;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
      private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
      private DoubleBufferedListView listViewReferences;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
   }
}