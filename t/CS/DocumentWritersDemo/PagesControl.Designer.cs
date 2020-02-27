namespace DocumentWritersDemo
{
   partial class PagesControl
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
         if(disposing && (components != null))
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
         this._movePageUpToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._titleDummy = new System.Windows.Forms.Label();
         this._tabPages = new System.Windows.Forms.TabPage();
         this._rasterImageList = new Leadtools.Controls.ImageViewer(new Leadtools.Controls.ImageViewerVerticalViewLayout() { Columns = 1 });
         this._toolStrip = new System.Windows.Forms.ToolStrip();
         this._newPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._deleteCurrentPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._movePageDownToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._tabBookmarks = new System.Windows.Forms.TabPage();
         this._treeBookmarks = new System.Windows.Forms.TreeView();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this._toolStripDropDownInsertBookmark = new System.Windows.Forms.ToolStripDropDownButton();
         this._insertBookmarkAfterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._insertBookmarkBeforeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._insertChildBookmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._deleteToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
         this._deleteSelectedBookmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._clearAllBookmarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._bookmarkPropertiesToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._tabControl = new System.Windows.Forms.TabControl();
         this._contextMenuBookmarks = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._insertBookmarkAfterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._insertBookmarkBeforeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._insertChildBookmarkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._bookmarkPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItemSeparator = new System.Windows.Forms.ToolStripSeparator();
         this._deleteBookmarkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._tabPages.SuspendLayout();
         this._toolStrip.SuspendLayout();
         this._tabBookmarks.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this._tabControl.SuspendLayout();
         this._contextMenuBookmarks.SuspendLayout();
         this.SuspendLayout();
         // 
         // _movePageUpToolStripButton
         // 
         this._movePageUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._movePageUpToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.MovePageUp;
         this._movePageUpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._movePageUpToolStripButton.Name = "_movePageUpToolStripButton";
         this._movePageUpToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._movePageUpToolStripButton.ToolTipText = "Move current page up in the document";
         this._movePageUpToolStripButton.Click += new System.EventHandler(this._movePageUpToolStripButton_Click);
         // 
         // _titleDummy
         // 
         this._titleDummy.Dock = System.Windows.Forms.DockStyle.Top;
         this._titleDummy.Location = new System.Drawing.Point(0, 0);
         this._titleDummy.Name = "_titleDummy";
         this._titleDummy.Size = new System.Drawing.Size(197, 9);
         this._titleDummy.TabIndex = 11;
         this._titleDummy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _tabPages
         // 
         this._tabPages.Controls.Add(this._rasterImageList);
         this._tabPages.Controls.Add(this._toolStrip);
         this._tabPages.Font = new System.Drawing.Font("Tahoma", 8F);
         this._tabPages.Location = new System.Drawing.Point(29, 4);
         this._tabPages.Name = "_tabPages";
         this._tabPages.Size = new System.Drawing.Size(164, 347);
         this._tabPages.TabIndex = 0;
         this._tabPages.Text = "Pages";
         this._tabPages.UseVisualStyleBackColor = true;
         // 
         // _rasterImageList
         // 

         this._rasterImageList.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._rasterImageList.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this._rasterImageList.Dock = System.Windows.Forms.DockStyle.Fill;
         this._rasterImageList.ItemSize = new Leadtools.LeadSize(180, 200);          
         this._rasterImageList.Location = new System.Drawing.Point(0, 25);
         this._rasterImageList.ItemSpacing = new Leadtools.LeadSize(20, 20);
         this._rasterImageList.ItemBorderThickness = 2;         
         this._rasterImageList.SelectedItemBorderColor = System.Drawing.Color.Blue;          
         this._rasterImageList.ItemSizeMode = Leadtools.Controls.ControlSizeMode.Fit;
         this._rasterImageList.Name = "_rasterImageList";
         this._rasterImageList.Size = new System.Drawing.Size(164, 322);
         this._rasterImageList.TabIndex = 11;         
         this._rasterImageList.InteractiveModes.Add(new Leadtools.Controls.ImageViewerSelectItemsInteractiveMode() { SelectionMode = Leadtools.Controls.ImageViewerSelectionMode.Single });
         this._rasterImageList.SelectedItemsChanged += new System.EventHandler(_rasterImageList_SelectedItemsChanged);         
         this._rasterImageList.PostRender += new System.EventHandler<Leadtools.Controls.ImageViewerRenderEventArgs>(_rasterImageList_PostRender);
         // 
         // _toolStrip
         // 
         this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newPageToolStripButton,
            this._deleteCurrentPageToolStripButton,
            this._movePageUpToolStripButton,
            this._movePageDownToolStripButton});
         this._toolStrip.Location = new System.Drawing.Point(0, 0);
         this._toolStrip.Name = "_toolStrip";
         this._toolStrip.Size = new System.Drawing.Size(164, 25);
         this._toolStrip.TabIndex = 3;
         // 
         // _newPageToolStripButton
         // 
         this._newPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._newPageToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.NewPage;
         this._newPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._newPageToolStripButton.Name = "_newPageToolStripButton";
         this._newPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._newPageToolStripButton.ToolTipText = "Add a new empty page the document";
         this._newPageToolStripButton.Click += new System.EventHandler(this._newPageToolStripButton_Click);
         // 
         // _deleteCurrentPageToolStripButton
         // 
         this._deleteCurrentPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._deleteCurrentPageToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.DeletePage;
         this._deleteCurrentPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._deleteCurrentPageToolStripButton.Name = "_deleteCurrentPageToolStripButton";
         this._deleteCurrentPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._deleteCurrentPageToolStripButton.ToolTipText = "Delete current page";
         this._deleteCurrentPageToolStripButton.Click += new System.EventHandler(this._deleteCurrentPageToolStripButton_Click);
         // 
         // _movePageDownToolStripButton
         // 
         this._movePageDownToolStripButton.BackColor = System.Drawing.Color.Transparent;
         this._movePageDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._movePageDownToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.MovePageDown;
         this._movePageDownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._movePageDownToolStripButton.Name = "_movePageDownToolStripButton";
         this._movePageDownToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._movePageDownToolStripButton.ToolTipText = "Move current page down in the document";
         this._movePageDownToolStripButton.Click += new System.EventHandler(this._movePageDownToolStripButton_Click);
         // 
         // _tabBookmarks
         // 
         this._tabBookmarks.Controls.Add(this._treeBookmarks);
         this._tabBookmarks.Controls.Add(this.toolStrip1);
         this._tabBookmarks.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._tabBookmarks.Location = new System.Drawing.Point(29, 4);
         this._tabBookmarks.Name = "_tabBookmarks";
         this._tabBookmarks.Size = new System.Drawing.Size(164, 347);
         this._tabBookmarks.TabIndex = 0;
         this._tabBookmarks.Text = "Bookmarks";
         this._tabBookmarks.UseVisualStyleBackColor = true;
         // 
         // _treeBookmarks
         // 
         this._treeBookmarks.BackColor = System.Drawing.SystemColors.Window;
         this._treeBookmarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this._treeBookmarks.Cursor = System.Windows.Forms.Cursors.Hand;
         this._treeBookmarks.Dock = System.Windows.Forms.DockStyle.Fill;
         this._treeBookmarks.FullRowSelect = true;
         this._treeBookmarks.HideSelection = false;
         this._treeBookmarks.HotTracking = true;
         this._treeBookmarks.Location = new System.Drawing.Point(0, 25);
         this._treeBookmarks.Name = "_treeBookmarks";
         this._treeBookmarks.Size = new System.Drawing.Size(164, 322);
         this._treeBookmarks.TabIndex = 11;
         this._treeBookmarks.MouseDown += new System.Windows.Forms.MouseEventHandler(this._treeBookmarks_MouseDown);
         this._treeBookmarks.Click += new System.EventHandler(this._treeBookmarks_Click);
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripDropDownInsertBookmark,
            this._deleteToolStripDropDownButton,
            this._bookmarkPropertiesToolStripButton});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(164, 25);
         this.toolStrip1.TabIndex = 10;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // _toolStripDropDownInsertBookmark
         // 
         this._toolStripDropDownInsertBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._toolStripDropDownInsertBookmark.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._insertBookmarkAfterToolStripMenuItem,
            this._insertBookmarkBeforeToolStripMenuItem,
            this._insertChildBookmarkToolStripMenuItem});
         this._toolStripDropDownInsertBookmark.Image = global::DocumentWritersDemo.Properties.Resources.AddBookmark;
         this._toolStripDropDownInsertBookmark.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._toolStripDropDownInsertBookmark.Name = "_toolStripDropDownInsertBookmark";
         this._toolStripDropDownInsertBookmark.Size = new System.Drawing.Size(29, 22);
         this._toolStripDropDownInsertBookmark.ToolTipText = "Insert new bookmark";
         // 
         // _insertBookmarkAfterToolStripMenuItem
         // 
         this._insertBookmarkAfterToolStripMenuItem.Name = "_insertBookmarkAfterToolStripMenuItem";
         this._insertBookmarkAfterToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
         this._insertBookmarkAfterToolStripMenuItem.Text = "Insert After...";
         this._insertBookmarkAfterToolStripMenuItem.ToolTipText = "Insert new bookmark after the selected one";
         this._insertBookmarkAfterToolStripMenuItem.Click += new System.EventHandler(this._insertBookmarkAfterToolStripMenuItem_Click);
         // 
         // _insertBookmarkBeforeToolStripMenuItem
         // 
         this._insertBookmarkBeforeToolStripMenuItem.Name = "_insertBookmarkBeforeToolStripMenuItem";
         this._insertBookmarkBeforeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
         this._insertBookmarkBeforeToolStripMenuItem.Text = "Insert Before...";
         this._insertBookmarkBeforeToolStripMenuItem.ToolTipText = "Insert new bookmark before the selected one";
         this._insertBookmarkBeforeToolStripMenuItem.Click += new System.EventHandler(this._insertBookmarkBeforeToolStripMenuItem_Click);
         // 
         // _insertChildBookmarkToolStripMenuItem
         // 
         this._insertChildBookmarkToolStripMenuItem.Name = "_insertChildBookmarkToolStripMenuItem";
         this._insertChildBookmarkToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
         this._insertChildBookmarkToolStripMenuItem.Text = "Insert Child...";
         this._insertChildBookmarkToolStripMenuItem.ToolTipText = "Insert child bookmark for the selected one";
         this._insertChildBookmarkToolStripMenuItem.Click += new System.EventHandler(this._insertChildBookmarkToolStripMenuItem_Click);
         // 
         // _deleteToolStripDropDownButton
         // 
         this._deleteToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._deleteToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._deleteSelectedBookmarkToolStripMenuItem,
            this._clearAllBookmarksToolStripMenuItem});
         this._deleteToolStripDropDownButton.Image = global::DocumentWritersDemo.Properties.Resources.Delete;
         this._deleteToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._deleteToolStripDropDownButton.Name = "_deleteToolStripDropDownButton";
         this._deleteToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
         this._deleteToolStripDropDownButton.Text = "Delete bookmark";
         // 
         // _deleteSelectedBookmarkToolStripMenuItem
         // 
         this._deleteSelectedBookmarkToolStripMenuItem.Name = "_deleteSelectedBookmarkToolStripMenuItem";
         this._deleteSelectedBookmarkToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
         this._deleteSelectedBookmarkToolStripMenuItem.Text = "Delete selected bookmark";
         this._deleteSelectedBookmarkToolStripMenuItem.Click += new System.EventHandler(this._deleteSelectedBookmarkToolStripMenuItem_Click);
         // 
         // _clearAllBookmarksToolStripMenuItem
         // 
         this._clearAllBookmarksToolStripMenuItem.Name = "_clearAllBookmarksToolStripMenuItem";
         this._clearAllBookmarksToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
         this._clearAllBookmarksToolStripMenuItem.Text = "Clear all bookmarks";
         this._clearAllBookmarksToolStripMenuItem.Click += new System.EventHandler(this._clearAllBookmarksToolStripMenuItem_Click);
         // 
         // _bookmarkPropertiesToolStripButton
         // 
         this._bookmarkPropertiesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._bookmarkPropertiesToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.ObjectProperties;
         this._bookmarkPropertiesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._bookmarkPropertiesToolStripButton.Name = "_bookmarkPropertiesToolStripButton";
         this._bookmarkPropertiesToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._bookmarkPropertiesToolStripButton.ToolTipText = "Show selected object(s) properties";
         this._bookmarkPropertiesToolStripButton.Click += new System.EventHandler(this._bookmarkPropertiesToolStripButton_Click);
         // 
         // _tabControl
         // 
         this._tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
         this._tabControl.Controls.Add(this._tabPages);
         this._tabControl.Controls.Add(this._tabBookmarks);
         this._tabControl.Cursor = System.Windows.Forms.Cursors.Default;
         this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this._tabControl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._tabControl.ItemSize = new System.Drawing.Size(106, 25);
         this._tabControl.Location = new System.Drawing.Point(0, 9);
         this._tabControl.Multiline = true;
         this._tabControl.Name = "_tabControl";
         this._tabControl.SelectedIndex = 0;
         this._tabControl.Size = new System.Drawing.Size(197, 355);
         this._tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
         this._tabControl.TabIndex = 12;
         // 
         // _contextMenuBookmarks
         // 
         this._contextMenuBookmarks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._insertBookmarkAfterMenuItem,
            this._insertBookmarkBeforeMenuItem,
            this._insertChildBookmarkMenuItem,
            this._bookmarkPropertiesMenuItem,
            this.toolStripMenuItemSeparator,
            this._deleteBookmarkMenuItem});
         this._contextMenuBookmarks.Name = "contextMenuBookmarks";
         this._contextMenuBookmarks.Size = new System.Drawing.Size(150, 120);
         // 
         // _insertBookmarkAfterMenuItem
         // 
         this._insertBookmarkAfterMenuItem.Name = "_insertBookmarkAfterMenuItem";
         this._insertBookmarkAfterMenuItem.Size = new System.Drawing.Size(149, 22);
         this._insertBookmarkAfterMenuItem.Text = "Insert After...";
         this._insertBookmarkAfterMenuItem.Click += new System.EventHandler(this._insertBookmarkAfterToolStripMenuItem_Click);
         // 
         // _insertBookmarkBeforeMenuItem
         // 
         this._insertBookmarkBeforeMenuItem.Name = "_insertBookmarkBeforeMenuItem";
         this._insertBookmarkBeforeMenuItem.Size = new System.Drawing.Size(149, 22);
         this._insertBookmarkBeforeMenuItem.Text = "Insert Before...";
         this._insertBookmarkBeforeMenuItem.Click += new System.EventHandler(this._insertBookmarkBeforeToolStripMenuItem_Click);
         // 
         // _insertChildBookmarkMenuItem
         // 
         this._insertChildBookmarkMenuItem.Name = "_insertChildBookmarkMenuItem";
         this._insertChildBookmarkMenuItem.Size = new System.Drawing.Size(149, 22);
         this._insertChildBookmarkMenuItem.Text = "Insert Child...";
         this._insertChildBookmarkMenuItem.Click += new System.EventHandler(this._insertChildBookmarkToolStripMenuItem_Click);
         // 
         // _bookmarkPropertiesMenuItem
         // 
         this._bookmarkPropertiesMenuItem.Name = "_bookmarkPropertiesMenuItem";
         this._bookmarkPropertiesMenuItem.Size = new System.Drawing.Size(149, 22);
         this._bookmarkPropertiesMenuItem.Text = "Properties...";
         this._bookmarkPropertiesMenuItem.Click += new System.EventHandler(this._bookmarkPropertiesToolStripButton_Click);
         // 
         // toolStripMenuItemSeparator
         // 
         this.toolStripMenuItemSeparator.Name = "toolStripMenuItemSeparator";
         this.toolStripMenuItemSeparator.Size = new System.Drawing.Size(146, 6);
         // 
         // _deleteBookmarkMenuItem
         // 
         this._deleteBookmarkMenuItem.Name = "_deleteBookmarkMenuItem";
         this._deleteBookmarkMenuItem.Size = new System.Drawing.Size(149, 22);
         this._deleteBookmarkMenuItem.Text = "Delete";
         this._deleteBookmarkMenuItem.Click += new System.EventHandler(this._deleteSelectedBookmarkToolStripMenuItem_Click);
         // 
         // PagesControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._tabControl);
         this.Controls.Add(this._titleDummy);
         this.Name = "PagesControl";
         this.Size = new System.Drawing.Size(197, 364);
         this._tabPages.ResumeLayout(false);
         this._tabPages.PerformLayout();
         this._toolStrip.ResumeLayout(false);
         this._toolStrip.PerformLayout();
         this._tabBookmarks.ResumeLayout(false);
         this._tabBookmarks.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this._tabControl.ResumeLayout(false);
         this._contextMenuBookmarks.ResumeLayout(false);
         this.ResumeLayout(false);

      }     

      
      #endregion

      private System.Windows.Forms.ToolStripButton _movePageUpToolStripButton;
      private System.Windows.Forms.Label _titleDummy;
      private System.Windows.Forms.TabPage _tabPages;
      private Leadtools.Controls.ImageViewer _rasterImageList;
      private System.Windows.Forms.ToolStrip _toolStrip;
      private System.Windows.Forms.ToolStripButton _newPageToolStripButton;
      private System.Windows.Forms.ToolStripButton _deleteCurrentPageToolStripButton;
      private System.Windows.Forms.ToolStripButton _movePageDownToolStripButton;
      private System.Windows.Forms.TabPage _tabBookmarks;
      private System.Windows.Forms.TabControl _tabControl;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripDropDownButton _toolStripDropDownInsertBookmark;
      private System.Windows.Forms.ToolStripMenuItem _insertBookmarkAfterToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _insertBookmarkBeforeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _insertChildBookmarkToolStripMenuItem;
      private System.Windows.Forms.ToolStripDropDownButton _deleteToolStripDropDownButton;
      private System.Windows.Forms.ToolStripMenuItem _deleteSelectedBookmarkToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _clearAllBookmarksToolStripMenuItem;
      private System.Windows.Forms.ToolStripButton _bookmarkPropertiesToolStripButton;
      private System.Windows.Forms.ContextMenuStrip _contextMenuBookmarks;
      private System.Windows.Forms.ToolStripMenuItem _insertChildBookmarkMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _insertBookmarkAfterMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _insertBookmarkBeforeMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItemSeparator;
      private System.Windows.Forms.ToolStripMenuItem _deleteBookmarkMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _bookmarkPropertiesMenuItem;
      private System.Windows.Forms.TreeView _treeBookmarks;

   }
}
