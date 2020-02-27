namespace DicomEditorDemo
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.splitContainer = new System.Windows.Forms.SplitContainer();
         this.propertyGridDataSet = new Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid();
         this.DicomEditableObject = new Leadtools.Dicom.Common.Editing.DicomEditableObject();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.newtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
         this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.addTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
         this.deleteTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
         this.animationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.showTagInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.showUsageImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
         this.addCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.readOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
         this.toolStripContainer1.ContentPanel.SuspendLayout();
         this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
         this.toolStripContainer1.SuspendLayout();
         //((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
         this.splitContainer.Panel1.SuspendLayout();
         this.splitContainer.SuspendLayout();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // openFileDialog
         // 
         this.openFileDialog.Filter = "DICOM Files | *.dcm|All Files|*.*";
         // 
         // toolStripContainer1
         // 
         // 
         // toolStripContainer1.BottomToolStripPanel
         // 
         this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
         // 
         // toolStripContainer1.ContentPanel
         // 
         this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer);
         this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(787, 507);
         this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
         this.toolStripContainer1.Name = "toolStripContainer1";
         this.toolStripContainer1.Size = new System.Drawing.Size(787, 553);
         this.toolStripContainer1.TabIndex = 2;
         this.toolStripContainer1.Text = "toolStripContainer1";
         // 
         // toolStripContainer1.TopToolStripPanel
         // 
         this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
         // 
         // statusStrip1
         // 
         this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
         this.statusStrip1.Location = new System.Drawing.Point(0, 0);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(787, 22);
         this.statusStrip1.TabIndex = 0;
         // 
         // splitContainer
         // 
         this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer.Location = new System.Drawing.Point(0, 0);
         this.splitContainer.Name = "splitContainer";
         // 
         // splitContainer.Panel1
         // 
         this.splitContainer.Panel1.Controls.Add(this.propertyGridDataSet);
         // 
         // splitContainer.Panel2
         // 
         this.splitContainer.Panel2.BackColor = System.Drawing.Color.Black;
         this.splitContainer.Size = new System.Drawing.Size(787, 507);
         this.splitContainer.SplitterDistance = 100;
         this.splitContainer.TabIndex = 3;
         // 
         // propertyGridDataSet
         // 
         this.propertyGridDataSet.AutoDisplayDescription = true;
         this.propertyGridDataSet.DataSet = null;
         this.propertyGridDataSet.DefaultTag = ((long)(-1));
         this.propertyGridDataSet.Dock = System.Windows.Forms.DockStyle.Fill;
         this.propertyGridDataSet.Location = new System.Drawing.Point(0, 0);
         this.propertyGridDataSet.Name = "propertyGridDataSet";
         this.propertyGridDataSet.PropertySort = System.Windows.Forms.PropertySort.NoSort;
         this.propertyGridDataSet.ReadOnly = false;
         this.propertyGridDataSet.SelectedObject = this.DicomEditableObject;
         this.propertyGridDataSet.ShowCommands = true;
         this.propertyGridDataSet.ShowTagInfo = true;
         this.propertyGridDataSet.ShowUsageImages = true;
         this.propertyGridDataSet.Size = new System.Drawing.Size(100, 507);
         this.propertyGridDataSet.TabIndex = 3;
         this.propertyGridDataSet.Type1ConditionalImage = ((System.Drawing.Image)(resources.GetObject("propertyGridDataSet.Type1ConditionalImage")));
         this.propertyGridDataSet.Type1MandatoryImage = ((System.Drawing.Image)(resources.GetObject("propertyGridDataSet.Type1MandatoryImage")));
         this.propertyGridDataSet.Type2ConditionalImage = ((System.Drawing.Image)(resources.GetObject("propertyGridDataSet.Type2ConditionalImage")));
         this.propertyGridDataSet.Type2MandatoryImage = ((System.Drawing.Image)(resources.GetObject("propertyGridDataSet.Type2MandatoryImage")));
         this.propertyGridDataSet.Type3Image = null;
         this.propertyGridDataSet.BeforeAddElement += new System.EventHandler<Leadtools.Dicom.Common.Editing.BeforeAddElementEventArgs>(this.propertyGridDataSet_BeforeAddElement);
         this.propertyGridDataSet.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridDataSet_PropertyValueChanged);
         // 
         // menuStrip1
         // 
         this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.commandsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(787, 24);
         this.menuStrip1.TabIndex = 0;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newtoolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "&File";
         this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
         // 
         // newtoolStripMenuItem
         // 
         this.newtoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newtoolStripMenuItem.Image")));
         this.newtoolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.newtoolStripMenuItem.Name = "newtoolStripMenuItem";
         this.newtoolStripMenuItem.Size = new System.Drawing.Size(146, 22);
         this.newtoolStripMenuItem.Text = "&New";
         this.newtoolStripMenuItem.Click += new System.EventHandler(this.newtoolStripMenuItem_Click);
         // 
         // openToolStripMenuItem
         // 
         this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
         this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.openToolStripMenuItem.Name = "openToolStripMenuItem";
         this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
         this.openToolStripMenuItem.Text = "&Open";
         this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
         // 
         // toolStripSeparator
         // 
         this.toolStripSeparator.Name = "toolStripSeparator";
         this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
         // 
         // saveToolStripMenuItem
         // 
         this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
         this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
         this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
         this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
         this.saveToolStripMenuItem.Text = "&Save";
         this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
         // 
         // saveAsToolStripMenuItem
         // 
         this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
         this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
         this.saveAsToolStripMenuItem.Text = "Save &As";
         this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
         this.exitToolStripMenuItem.Text = "E&xit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // commandsToolStripMenuItem
         // 
         this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTagsToolStripMenuItem,
            this.addItemToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteTagToolStripMenuItem,
            this.toolStripMenuItem4,
            this.animationToolStripMenuItem});
         this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
         this.commandsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
         this.commandsToolStripMenuItem.Text = "&Actions";
         this.commandsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.commandsToolStripMenuItem_DropDownOpening);
         // 
         // addTagsToolStripMenuItem
         // 
         this.addTagsToolStripMenuItem.Name = "addTagsToolStripMenuItem";
         this.addTagsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
         this.addTagsToolStripMenuItem.Text = "&Add Tags";
         this.addTagsToolStripMenuItem.Click += new System.EventHandler(this.addTagsToolStripMenuItem_Click);
         // 
         // addItemToolStripMenuItem
         // 
         this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
         this.addItemToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
         this.addItemToolStripMenuItem.Text = "Add &Item";
         this.addItemToolStripMenuItem.Click += new System.EventHandler(this.addItemToolStripMenuItem_Click);
         // 
         // toolStripMenuItem2
         // 
         this.toolStripMenuItem2.Name = "toolStripMenuItem2";
         this.toolStripMenuItem2.Size = new System.Drawing.Size(136, 6);
         // 
         // deleteTagToolStripMenuItem
         // 
         this.deleteTagToolStripMenuItem.Name = "deleteTagToolStripMenuItem";
         this.deleteTagToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
         this.deleteTagToolStripMenuItem.Text = "&Delete Tag";
         this.deleteTagToolStripMenuItem.Click += new System.EventHandler(this.deleteTagToolStripMenuItem_Click);
         // 
         // toolStripMenuItem4
         // 
         this.toolStripMenuItem4.Name = "toolStripMenuItem4";
         this.toolStripMenuItem4.Size = new System.Drawing.Size(136, 6);
         // 
         // animationToolStripMenuItem
         // 
         this.animationToolStripMenuItem.Name = "animationToolStripMenuItem";
         this.animationToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
         this.animationToolStripMenuItem.Text = "Animation...";
         this.animationToolStripMenuItem.Click += new System.EventHandler(this.animationToolStripMenuItem_Click);
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTagInfoToolStripMenuItem,
            this.showUsageImagesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addCommandsToolStripMenuItem,
            this.readOnlyToolStripMenuItem});
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
         this.optionsToolStripMenuItem.Text = "&Options";
         this.optionsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.optionsToolStripMenuItem_DropDownOpening);
         // 
         // showTagInfoToolStripMenuItem
         // 
         this.showTagInfoToolStripMenuItem.CheckOnClick = true;
         this.showTagInfoToolStripMenuItem.Name = "showTagInfoToolStripMenuItem";
         this.showTagInfoToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
         this.showTagInfoToolStripMenuItem.Text = "&Show Tag Info";
         this.showTagInfoToolStripMenuItem.Click += new System.EventHandler(this.showTagInfoToolStripMenuItem_Click);
         // 
         // showUsageImagesToolStripMenuItem
         // 
         this.showUsageImagesToolStripMenuItem.CheckOnClick = true;
         this.showUsageImagesToolStripMenuItem.Name = "showUsageImagesToolStripMenuItem";
         this.showUsageImagesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
         this.showUsageImagesToolStripMenuItem.Text = "Show &Usage Images";
         this.showUsageImagesToolStripMenuItem.Click += new System.EventHandler(this.showUsageImagesToolStripMenuItem_Click);
         // 
         // toolStripMenuItem1
         // 
         this.toolStripMenuItem1.Name = "toolStripMenuItem1";
         this.toolStripMenuItem1.Size = new System.Drawing.Size(176, 6);
         // 
         // addCommandsToolStripMenuItem
         // 
         this.addCommandsToolStripMenuItem.CheckOnClick = true;
         this.addCommandsToolStripMenuItem.Name = "addCommandsToolStripMenuItem";
         this.addCommandsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
         this.addCommandsToolStripMenuItem.Text = "&Add Commands";
         this.addCommandsToolStripMenuItem.Click += new System.EventHandler(this.addCommandsToolStripMenuItem_Click);
         // 
         // readOnlyToolStripMenuItem
         // 
         this.readOnlyToolStripMenuItem.Name = "readOnlyToolStripMenuItem";
         this.readOnlyToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
         this.readOnlyToolStripMenuItem.Text = "Read Only";
         this.readOnlyToolStripMenuItem.Click += new System.EventHandler(this.readOnlyToolStripMenuItem_Click);
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.helpToolStripMenuItem.Text = "&Help";
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
         this.aboutToolStripMenuItem.Text = "&About";
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(787, 553);
         this.Controls.Add(this.toolStripContainer1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "DICOM Property Editor";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
         this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
         this.toolStripContainer1.ContentPanel.ResumeLayout(false);
         this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
         this.toolStripContainer1.TopToolStripPanel.PerformLayout();
         this.toolStripContainer1.ResumeLayout(false);
         this.toolStripContainer1.PerformLayout();
         this.splitContainer.Panel1.ResumeLayout(false);
         //((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
         this.splitContainer.ResumeLayout(false);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private Leadtools.Dicom.Common.Editing.DicomEditableObject DicomEditableObject;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTagInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showUsageImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addCommandsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem newtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid propertyGridDataSet;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem animationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readOnlyToolStripMenuItem;
    }
}

