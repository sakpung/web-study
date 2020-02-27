namespace Leadtools.Medical.Winforms.Anonymize
{
   partial class AnonymizeOptionsView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnonymizeOptionsView));
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.groupBoxAnonymizeScripts = new System.Windows.Forms.GroupBox();
         this.toolStripAnonymizeScripts = new System.Windows.Forms.ToolStrip();
         this.toolStripButtonAddEmpty = new System.Windows.Forms.ToolStripButton();
         this.toolStripButtonAddDefault = new System.Windows.Forms.ToolStripButton();
         this.toolStripButtonClone = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButtonActivate = new System.Windows.Forms.ToolStripButton();
         this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
         this.listViewAnonymizeScripts = new System.Windows.Forms.ListView();
         this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         this.groupBoxScriptDefinition = new System.Windows.Forms.GroupBox();
         this.toolStripScriptDefinition = new System.Windows.Forms.ToolStrip();
         this.toolStripButtonInsertTag = new System.Windows.Forms.ToolStripButton();
         this.toolStripButtonDeleteTag = new System.Windows.Forms.ToolStripButton();
         this.treeGridViewTags = new System.Windows.Forms.DataGridView();
         this.columnTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.columnValue = new System.Windows.Forms.DataGridViewComboBoxColumn();
         this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.activateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.groupBoxAnonymizeScripts.SuspendLayout();
         this.toolStripAnonymizeScripts.SuspendLayout();
         this.groupBoxScriptDefinition.SuspendLayout();
         this.toolStripScriptDefinition.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.treeGridViewTags)).BeginInit();
         this.contextMenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.groupBoxAnonymizeScripts);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.groupBoxScriptDefinition);
         this.splitContainer1.Size = new System.Drawing.Size(584, 677);
         this.splitContainer1.SplitterDistance = 300;
         this.splitContainer1.TabIndex = 5;
         // 
         // groupBoxAnonymizeScripts
         // 
         this.groupBoxAnonymizeScripts.Controls.Add(this.toolStripAnonymizeScripts);
         this.groupBoxAnonymizeScripts.Controls.Add(this.listViewAnonymizeScripts);
         this.groupBoxAnonymizeScripts.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBoxAnonymizeScripts.Location = new System.Drawing.Point(0, 0);
         this.groupBoxAnonymizeScripts.Name = "groupBoxAnonymizeScripts";
         this.groupBoxAnonymizeScripts.Size = new System.Drawing.Size(584, 300);
         this.groupBoxAnonymizeScripts.TabIndex = 5;
         this.groupBoxAnonymizeScripts.TabStop = false;
         this.groupBoxAnonymizeScripts.Text = "AnonymizeScripts";
         // 
         // toolStripAnonymizeScripts
         // 
         this.toolStripAnonymizeScripts.ImageScalingSize = new System.Drawing.Size(24, 24);
         this.toolStripAnonymizeScripts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddEmpty,
            this.toolStripButtonAddDefault,
            this.toolStripButtonClone,
            this.toolStripSeparator1,
            this.toolStripButtonDelete,
            this.toolStripSeparator2,
            this.toolStripButtonActivate,
            this.toolStripButtonSave});
         this.toolStripAnonymizeScripts.Location = new System.Drawing.Point(3, 16);
         this.toolStripAnonymizeScripts.Name = "toolStripAnonymizeScripts";
         this.toolStripAnonymizeScripts.Size = new System.Drawing.Size(578, 31);
         this.toolStripAnonymizeScripts.TabIndex = 1;
         this.toolStripAnonymizeScripts.Text = "toolStripScripts";
         // 
         // toolStripButtonAddEmpty
         // 
         this.toolStripButtonAddEmpty.Image = global::Leadtools.Medical.Winforms.Properties.Resources.NewEmpty;
         this.toolStripButtonAddEmpty.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonAddEmpty.Name = "toolStripButtonAddEmpty";
         this.toolStripButtonAddEmpty.Size = new System.Drawing.Size(96, 28);
         this.toolStripButtonAddEmpty.Text = "New Empty";
         // 
         // toolStripButtonAddDefault
         // 
         this.toolStripButtonAddDefault.Image = global::Leadtools.Medical.Winforms.Properties.Resources.NewDefault;
         this.toolStripButtonAddDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonAddDefault.Name = "toolStripButtonAddDefault";
         this.toolStripButtonAddDefault.Size = new System.Drawing.Size(100, 28);
         this.toolStripButtonAddDefault.Text = "New Default";
         // 
         // toolStripButtonClone
         // 
         this.toolStripButtonClone.Image = global::Leadtools.Medical.Winforms.Properties.Resources.copy;
         this.toolStripButtonClone.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonClone.Name = "toolStripButtonClone";
         this.toolStripButtonClone.Size = new System.Drawing.Size(63, 28);
         this.toolStripButtonClone.Text = "Copy";
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
         // 
         // toolStripButtonDelete
         // 
         this.toolStripButtonDelete.Image = global::Leadtools.Medical.Winforms.Properties.Resources.RemoveLarge;
         this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonDelete.Name = "toolStripButtonDelete";
         this.toolStripButtonDelete.Size = new System.Drawing.Size(68, 28);
         this.toolStripButtonDelete.Text = "Delete";
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
         // 
         // toolStripButtonActivate
         // 
         this.toolStripButtonActivate.Image = global::Leadtools.Medical.Winforms.Properties.Resources.Tick;
         this.toolStripButtonActivate.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonActivate.Name = "toolStripButtonActivate";
         this.toolStripButtonActivate.Size = new System.Drawing.Size(78, 28);
         this.toolStripButtonActivate.Text = "Activate";
         // 
         // toolStripButtonSave
         // 
         this.toolStripButtonSave.Image = global::Leadtools.Medical.Winforms.Properties.Resources.Save_Floppy;
         this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonSave.Name = "toolStripButtonSave";
         this.toolStripButtonSave.Size = new System.Drawing.Size(59, 28);
         this.toolStripButtonSave.Text = "Save";
         // 
         // listViewAnonymizeScripts
         // 
         this.listViewAnonymizeScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewAnonymizeScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName});
         this.listViewAnonymizeScripts.FullRowSelect = true;
         this.listViewAnonymizeScripts.HideSelection = false;
         this.listViewAnonymizeScripts.LabelEdit = true;
         this.listViewAnonymizeScripts.Location = new System.Drawing.Point(3, 58);
         this.listViewAnonymizeScripts.MultiSelect = false;
         this.listViewAnonymizeScripts.Name = "listViewAnonymizeScripts";
         this.listViewAnonymizeScripts.Size = new System.Drawing.Size(578, 236);
         this.listViewAnonymizeScripts.SmallImageList = this.imageList;
         this.listViewAnonymizeScripts.TabIndex = 0;
         this.listViewAnonymizeScripts.UseCompatibleStateImageBehavior = false;
         this.listViewAnonymizeScripts.View = System.Windows.Forms.View.Details;
         // 
         // columnHeaderName
         // 
         this.columnHeaderName.Text = "Name";
         this.columnHeaderName.Width = 100;
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "check.png");
         // 
         // groupBoxScriptDefinition
         // 
         this.groupBoxScriptDefinition.Controls.Add(this.toolStripScriptDefinition);
         this.groupBoxScriptDefinition.Controls.Add(this.treeGridViewTags);
         this.groupBoxScriptDefinition.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBoxScriptDefinition.Location = new System.Drawing.Point(0, 0);
         this.groupBoxScriptDefinition.Name = "groupBoxScriptDefinition";
         this.groupBoxScriptDefinition.Size = new System.Drawing.Size(584, 373);
         this.groupBoxScriptDefinition.TabIndex = 4;
         this.groupBoxScriptDefinition.TabStop = false;
         this.groupBoxScriptDefinition.Text = "Script Definition";
         // 
         // toolStripScriptDefinition
         // 
         this.toolStripScriptDefinition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonInsertTag,
            this.toolStripButtonDeleteTag});
         this.toolStripScriptDefinition.Location = new System.Drawing.Point(3, 16);
         this.toolStripScriptDefinition.Name = "toolStripScriptDefinition";
         this.toolStripScriptDefinition.Size = new System.Drawing.Size(578, 25);
         this.toolStripScriptDefinition.TabIndex = 3;
         this.toolStripScriptDefinition.Text = "toolStrip1";
         // 
         // toolStripButtonInsertTag
         // 
         this.toolStripButtonInsertTag.Image = global::Leadtools.Medical.Winforms.Properties.Resources.Plus;
         this.toolStripButtonInsertTag.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonInsertTag.Name = "toolStripButtonInsertTag";
         this.toolStripButtonInsertTag.Size = new System.Drawing.Size(79, 22);
         this.toolStripButtonInsertTag.Text = "Insert Tag";
         // 
         // toolStripButtonDeleteTag
         // 
         this.toolStripButtonDeleteTag.Image = global::Leadtools.Medical.Winforms.Properties.Resources.Minus;
         this.toolStripButtonDeleteTag.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonDeleteTag.Name = "toolStripButtonDeleteTag";
         this.toolStripButtonDeleteTag.Size = new System.Drawing.Size(83, 22);
         this.toolStripButtonDeleteTag.Text = "Delete Tag";
         // 
         // treeGridViewTags
         // 
         this.treeGridViewTags.AllowDrop = true;
         this.treeGridViewTags.AllowUserToAddRows = false;
         this.treeGridViewTags.AllowUserToDeleteRows = false;
         this.treeGridViewTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.treeGridViewTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnTag,
            this.columnName,
            this.columnValue});
         this.treeGridViewTags.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
         this.treeGridViewTags.Location = new System.Drawing.Point(3, 55);
         this.treeGridViewTags.Name = "treeGridViewTags";
         this.treeGridViewTags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.treeGridViewTags.Size = new System.Drawing.Size(575, 312);
         this.treeGridViewTags.TabIndex = 1;
         // 
         // columnTag
         // 
         this.columnTag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.columnTag.HeaderText = "Tag";
         this.columnTag.Name = "columnTag";
         this.columnTag.ReadOnly = true;
         this.columnTag.Width = 51;
         // 
         // columnName
         // 
         this.columnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
         this.columnName.HeaderText = "Name";
         this.columnName.Name = "columnName";
         this.columnName.ReadOnly = true;
         this.columnName.Width = 60;
         // 
         // columnValue
         // 
         this.columnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
         dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent;
         dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
         dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
         dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Transparent;
         this.columnValue.DefaultCellStyle = dataGridViewCellStyle2;
         this.columnValue.HeaderText = "Value";
         this.columnValue.MaxDropDownItems = 20;
         this.columnValue.Name = "columnValue";
         // 
         // contextMenuStrip
         // 
         this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.toolStripSeparator3,
            this.cloneToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.activateToolStripMenuItem});
         this.contextMenuStrip.Name = "contextMenuStrip";
         this.contextMenuStrip.Size = new System.Drawing.Size(118, 98);
         // 
         // renameToolStripMenuItem
         // 
         this.renameToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
         this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
         this.renameToolStripMenuItem.Text = "Rename";
         this.renameToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemRename_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(114, 6);
         // 
         // cloneToolStripMenuItem
         // 
         this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
         this.cloneToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
         this.cloneToolStripMenuItem.Text = "Clone";
         this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
         // 
         // deleteToolStripMenuItem
         // 
         this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
         this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
         this.deleteToolStripMenuItem.Text = "Delete";
         this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
         // 
         // activateToolStripMenuItem
         // 
         this.activateToolStripMenuItem.Name = "activateToolStripMenuItem";
         this.activateToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
         this.activateToolStripMenuItem.Text = "Activate";
         this.activateToolStripMenuItem.Click += new System.EventHandler(this.activateToolStripMenuItem_Click);
         // 
         // AnonymizeOptionsView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.splitContainer1);
         this.Name = "AnonymizeOptionsView";
         this.Size = new System.Drawing.Size(584, 677);
         this.Load += new System.EventHandler(this.AnonymizeEditorControl_Load);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         this.groupBoxAnonymizeScripts.ResumeLayout(false);
         this.groupBoxAnonymizeScripts.PerformLayout();
         this.toolStripAnonymizeScripts.ResumeLayout(false);
         this.toolStripAnonymizeScripts.PerformLayout();
         this.groupBoxScriptDefinition.ResumeLayout(false);
         this.groupBoxScriptDefinition.PerformLayout();
         this.toolStripScriptDefinition.ResumeLayout(false);
         this.toolStripScriptDefinition.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.treeGridViewTags)).EndInit();
         this.contextMenuStrip.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.GroupBox groupBoxAnonymizeScripts;
      private System.Windows.Forms.ToolStrip toolStripAnonymizeScripts;
      private System.Windows.Forms.ToolStripButton toolStripButtonAddEmpty;
      private System.Windows.Forms.ToolStripButton toolStripButtonAddDefault;
      private System.Windows.Forms.ToolStripButton toolStripButtonClone;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton toolStripButtonActivate;
      private System.Windows.Forms.ListView listViewAnonymizeScripts;
      private System.Windows.Forms.ColumnHeader columnHeaderName;
      private System.Windows.Forms.GroupBox groupBoxScriptDefinition;
      private System.Windows.Forms.ToolStrip toolStripScriptDefinition;
      private System.Windows.Forms.ToolStripButton toolStripButtonInsertTag;
      private System.Windows.Forms.ToolStripButton toolStripButtonDeleteTag;
      private System.Windows.Forms.DataGridView treeGridViewTags;
      private System.Windows.Forms.ToolStripButton toolStripButtonSave;
      private System.Windows.Forms.DataGridViewTextBoxColumn columnTag;
      private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
      private System.Windows.Forms.DataGridViewComboBoxColumn columnValue;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem activateToolStripMenuItem;
      private System.Windows.Forms.ImageList imageList;

   }
}
