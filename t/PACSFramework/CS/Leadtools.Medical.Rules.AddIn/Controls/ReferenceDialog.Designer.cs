namespace Leadtools.Medical.Rules.AddIn.Controls
{
   partial class ReferenceDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReferenceDialog));
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPageDotNet = new System.Windows.Forms.TabPage();
         this.tabPageBrowse = new System.Windows.Forms.TabPage();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
         this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.listViewAssembly = new Leadtools.Medical.Rules.AddIn.Controls.DoubleBufferedListView();
         this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.listViewFiles = new Leadtools.Medical.Rules.AddIn.Controls.DoubleBufferedListView();
         this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.tabControl1.SuspendLayout();
         this.tabPageDotNet.SuspendLayout();
         this.tabPageBrowse.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControl1
         // 
         this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControl1.Controls.Add(this.tabPageDotNet);
         this.tabControl1.Controls.Add(this.tabPageBrowse);
         this.tabControl1.Location = new System.Drawing.Point(13, 13);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(624, 415);
         this.tabControl1.TabIndex = 0;
         // 
         // tabPageDotNet
         // 
         this.tabPageDotNet.Controls.Add(this.listViewAssembly);
         this.tabPageDotNet.Location = new System.Drawing.Point(4, 22);
         this.tabPageDotNet.Name = "tabPageDotNet";
         this.tabPageDotNet.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageDotNet.Size = new System.Drawing.Size(616, 389);
         this.tabPageDotNet.TabIndex = 0;
         this.tabPageDotNet.Text = ".NET";
         this.tabPageDotNet.UseVisualStyleBackColor = true;
         // 
         // tabPageBrowse
         // 
         this.tabPageBrowse.Controls.Add(this.listViewFiles);
         this.tabPageBrowse.Controls.Add(this.toolStrip1);
         this.tabPageBrowse.Location = new System.Drawing.Point(4, 22);
         this.tabPageBrowse.Name = "tabPageBrowse";
         this.tabPageBrowse.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageBrowse.Size = new System.Drawing.Size(616, 389);
         this.tabPageBrowse.TabIndex = 1;
         this.tabPageBrowse.Text = "Browse";
         this.tabPageBrowse.UseVisualStyleBackColor = true;
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonDelete});
         this.toolStrip1.Location = new System.Drawing.Point(3, 3);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(610, 25);
         this.toolStrip1.TabIndex = 2;
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
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(562, 435);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 1;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
         // 
         // buttonOK
         // 
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(481, 434);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 2;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // openFileDialog
         // 
         this.openFileDialog.AddExtension = false;
         this.openFileDialog.Filter = "Assemblies |*.dll|All Files|*.*";
         this.openFileDialog.Multiselect = true;
         this.openFileDialog.Title = "Add Assembly";
         // 
         // listViewAssembly
         // 
         this.listViewAssembly.CheckBoxes = true;
         this.listViewAssembly.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
         this.listViewAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewAssembly.FullRowSelect = true;
         this.listViewAssembly.HideSelection = false;
         this.listViewAssembly.Location = new System.Drawing.Point(3, 3);
         this.listViewAssembly.Name = "listViewAssembly";
         this.listViewAssembly.Size = new System.Drawing.Size(610, 383);
         this.listViewAssembly.Sorting = System.Windows.Forms.SortOrder.Ascending;
         this.listViewAssembly.TabIndex = 0;
         this.listViewAssembly.UseCompatibleStateImageBehavior = false;
         this.listViewAssembly.View = System.Windows.Forms.View.Details;
         this.listViewAssembly.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewAssembly_ItemCheck);
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Component Name";
         this.columnHeader1.Width = 176;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Version";
         this.columnHeader2.Width = 84;
         // 
         // listViewFiles
         // 
         this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
         this.listViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewFiles.FullRowSelect = true;
         this.listViewFiles.HideSelection = false;
         this.listViewFiles.Location = new System.Drawing.Point(3, 28);
         this.listViewFiles.MultiSelect = false;
         this.listViewFiles.Name = "listViewFiles";
         this.listViewFiles.Size = new System.Drawing.Size(610, 358);
         this.listViewFiles.TabIndex = 1;
         this.listViewFiles.UseCompatibleStateImageBehavior = false;
         this.listViewFiles.View = System.Windows.Forms.View.Details;
         this.listViewFiles.SelectedIndexChanged += new System.EventHandler(this.listViewFiles_SelectedIndexChanged);
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "File Name";
         this.columnHeader3.Width = 176;
         // 
         // columnHeader4
         // 
         this.columnHeader4.Text = "Version";
         this.columnHeader4.Width = 84;
         // 
         // ReferenceDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(649, 470);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.tabControl1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ReferenceDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Add Reference";
         this.Load += new System.EventHandler(this.ReferenceDialog_Load);
         this.Shown += new System.EventHandler(this.ReferenceDialog_Shown);
         this.tabControl1.ResumeLayout(false);
         this.tabPageDotNet.ResumeLayout(false);
         this.tabPageBrowse.ResumeLayout(false);
         this.tabPageBrowse.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage tabPageDotNet;
      private DoubleBufferedListView listViewAssembly;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.TabPage tabPageBrowse;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private DoubleBufferedListView listViewFiles;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ColumnHeader columnHeader4;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
      private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
      private System.Windows.Forms.OpenFileDialog openFileDialog;
   }
}