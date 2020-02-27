Imports Leadtools
Imports Leadtools.Controls

Namespace DocumentWritersDemo
   Partial Class PagesControl
      ''' <summary> 
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary> 
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
         If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Component Designer generated code"

      ''' <summary> 
      ''' Required method for Designer support - do not modify 
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me.components = New System.ComponentModel.Container()
         Me._movePageUpToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._titleDummy = New System.Windows.Forms.Label()
         Me._tabPages = New System.Windows.Forms.TabPage()
         Dim _imageViewerVerticalViewLayout As ImageViewerVerticalViewLayout = New ImageViewerVerticalViewLayout()
         _imageViewerVerticalViewLayout.Columns = 1
         Me._rasterImageList = New ImageViewer(_imageViewerVerticalViewLayout)
         Me._toolStrip = New System.Windows.Forms.ToolStrip()
         Me._newPageToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._deleteCurrentPageToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._movePageDownToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._tabBookmarks = New System.Windows.Forms.TabPage()
         Me._treeBookmarks = New System.Windows.Forms.TreeView()
         Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
         Me._toolStripDropDownInsertBookmark = New System.Windows.Forms.ToolStripDropDownButton()
         Me._insertBookmarkAfterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._insertBookmarkBeforeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._insertChildBookmarkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._deleteToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
         Me._deleteSelectedBookmarkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._clearAllBookmarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._bookmarkPropertiesToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._tabControl = New System.Windows.Forms.TabControl()
         Me._contextMenuBookmarks = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me._insertBookmarkAfterMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._insertBookmarkBeforeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._insertChildBookmarkMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._bookmarkPropertiesMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripMenuItemSeparator = New System.Windows.Forms.ToolStripSeparator()
         Me._deleteBookmarkMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._tabPages.SuspendLayout()
         Me._toolStrip.SuspendLayout()
         Me._tabBookmarks.SuspendLayout()
         Me.toolStrip1.SuspendLayout()
         Me._tabControl.SuspendLayout()
         Me._contextMenuBookmarks.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _movePageUpToolStripButton
         ' 
         Me._movePageUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._movePageUpToolStripButton.Image = Global.DocumentWritersDemo.Resources.MovePageUp
         Me._movePageUpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._movePageUpToolStripButton.Name = "_movePageUpToolStripButton"
         Me._movePageUpToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._movePageUpToolStripButton.ToolTipText = "Move current page up in the document"
         ' 
         ' _titleDummy
         ' 
         Me._titleDummy.Dock = System.Windows.Forms.DockStyle.Top
         Me._titleDummy.Location = New System.Drawing.Point(0, 0)
         Me._titleDummy.Name = "_titleDummy"
         Me._titleDummy.Size = New System.Drawing.Size(197, 9)
         Me._titleDummy.TabIndex = 11
         Me._titleDummy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _tabPages
         ' 
         Me._tabPages.Controls.Add(Me._rasterImageList)
         Me._tabPages.Controls.Add(Me._toolStrip)
         Me._tabPages.Font = New System.Drawing.Font("Tahoma", 8.0F)
         Me._tabPages.Location = New System.Drawing.Point(29, 4)
         Me._tabPages.Name = "_tabPages"
         Me._tabPages.Size = New System.Drawing.Size(164, 347)
         Me._tabPages.TabIndex = 0
         Me._tabPages.Text = "Pages"
         Me._tabPages.UseVisualStyleBackColor = True
         ' 
         ' _rasterImageList
         ' 

         Me._rasterImageList.BackColor = System.Drawing.SystemColors.AppWorkspace
         Me._rasterImageList.BorderStyle = System.Windows.Forms.BorderStyle.None
         Me._rasterImageList.Dock = System.Windows.Forms.DockStyle.Fill
         Me._rasterImageList.ItemSize = New LeadSize(180, 200)
         Me._rasterImageList.Location = New System.Drawing.Point(0, 25)
         Me._rasterImageList.ItemSpacing = New LeadSize(20, 20)
         Me._rasterImageList.ItemBorderThickness = 2
         Me._rasterImageList.SelectedItemBorderColor = System.Drawing.Color.Blue
         Me._rasterImageList.ItemSizeMode = ControlSizeMode.Fit
         Me._rasterImageList.Name = "_rasterImageList"
         Me._rasterImageList.Size = New System.Drawing.Size(164, 322)
         Me._rasterImageList.TabIndex = 11
         Dim _imageViewerSelectItemsInteractiveMode As New ImageViewerSelectItemsInteractiveMode()
         _imageViewerSelectItemsInteractiveMode.SelectionMode = ImageViewerSelectionMode.Single
         Me._rasterImageList.InteractiveModes.Add(_imageViewerSelectItemsInteractiveMode)
         ' 
         ' _toolStrip
         ' 
         Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._newPageToolStripButton, Me._deleteCurrentPageToolStripButton, Me._movePageUpToolStripButton, Me._movePageDownToolStripButton})
         Me._toolStrip.Location = New System.Drawing.Point(0, 0)
         Me._toolStrip.Name = "_toolStrip"
         Me._toolStrip.Size = New System.Drawing.Size(164, 25)
         Me._toolStrip.TabIndex = 3
         ' 
         ' _newPageToolStripButton
         ' 
         Me._newPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._newPageToolStripButton.Image = Global.DocumentWritersDemo.Resources.NewPage
         Me._newPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._newPageToolStripButton.Name = "_newPageToolStripButton"
         Me._newPageToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._newPageToolStripButton.ToolTipText = "Add a new empty page the document"
         ' 
         ' _deleteCurrentPageToolStripButton
         ' 
         Me._deleteCurrentPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._deleteCurrentPageToolStripButton.Image = Global.DocumentWritersDemo.Resources.DeletePage
         Me._deleteCurrentPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._deleteCurrentPageToolStripButton.Name = "_deleteCurrentPageToolStripButton"
         Me._deleteCurrentPageToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._deleteCurrentPageToolStripButton.ToolTipText = "Delete current page"
         ' 
         ' _movePageDownToolStripButton
         ' 
         Me._movePageDownToolStripButton.BackColor = System.Drawing.Color.Transparent
         Me._movePageDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._movePageDownToolStripButton.Image = Global.DocumentWritersDemo.Resources.MovePageDown
         Me._movePageDownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._movePageDownToolStripButton.Name = "_movePageDownToolStripButton"
         Me._movePageDownToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._movePageDownToolStripButton.ToolTipText = "Move current page down in the document"
         ' 
         ' _tabBookmarks
         ' 
         Me._tabBookmarks.Controls.Add(Me._treeBookmarks)
         Me._tabBookmarks.Controls.Add(Me.toolStrip1)
         Me._tabBookmarks.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me._tabBookmarks.Location = New System.Drawing.Point(29, 4)
         Me._tabBookmarks.Name = "_tabBookmarks"
         Me._tabBookmarks.Size = New System.Drawing.Size(164, 347)
         Me._tabBookmarks.TabIndex = 0
         Me._tabBookmarks.Text = "Bookmarks"
         Me._tabBookmarks.UseVisualStyleBackColor = True
         ' 
         ' _treeBookmarks
         ' 
         Me._treeBookmarks.BackColor = System.Drawing.SystemColors.Window
         Me._treeBookmarks.BorderStyle = System.Windows.Forms.BorderStyle.None
         Me._treeBookmarks.Cursor = System.Windows.Forms.Cursors.Hand
         Me._treeBookmarks.Dock = System.Windows.Forms.DockStyle.Fill
         Me._treeBookmarks.FullRowSelect = True
         Me._treeBookmarks.HideSelection = False
         Me._treeBookmarks.HotTracking = True
         Me._treeBookmarks.Location = New System.Drawing.Point(0, 25)
         Me._treeBookmarks.Name = "_treeBookmarks"
         Me._treeBookmarks.Size = New System.Drawing.Size(164, 322)
         Me._treeBookmarks.TabIndex = 11
         ' 
         ' toolStrip1
         ' 
         Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._toolStripDropDownInsertBookmark, Me._deleteToolStripDropDownButton, Me._bookmarkPropertiesToolStripButton})
         Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
         Me.toolStrip1.Name = "toolStrip1"
         Me.toolStrip1.Size = New System.Drawing.Size(164, 25)
         Me.toolStrip1.TabIndex = 10
         Me.toolStrip1.Text = "toolStrip1"
         ' 
         ' _toolStripDropDownInsertBookmark
         ' 
         Me._toolStripDropDownInsertBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._toolStripDropDownInsertBookmark.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._insertBookmarkAfterToolStripMenuItem, Me._insertBookmarkBeforeToolStripMenuItem, Me._insertChildBookmarkToolStripMenuItem})
         Me._toolStripDropDownInsertBookmark.Image = Global.DocumentWritersDemo.Resources.AddBookmark
         Me._toolStripDropDownInsertBookmark.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._toolStripDropDownInsertBookmark.Name = "_toolStripDropDownInsertBookmark"
         Me._toolStripDropDownInsertBookmark.Size = New System.Drawing.Size(29, 22)
         Me._toolStripDropDownInsertBookmark.ToolTipText = "Insert new bookmark"
         ' 
         ' _insertBookmarkAfterToolStripMenuItem
         ' 
         Me._insertBookmarkAfterToolStripMenuItem.Name = "_insertBookmarkAfterToolStripMenuItem"
         Me._insertBookmarkAfterToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
         Me._insertBookmarkAfterToolStripMenuItem.Text = "Insert After..."
         Me._insertBookmarkAfterToolStripMenuItem.ToolTipText = "Insert new bookmark after the selected one"
         ' 
         ' _insertBookmarkBeforeToolStripMenuItem
         ' 
         Me._insertBookmarkBeforeToolStripMenuItem.Name = "_insertBookmarkBeforeToolStripMenuItem"
         Me._insertBookmarkBeforeToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
         Me._insertBookmarkBeforeToolStripMenuItem.Text = "Insert Before..."
         Me._insertBookmarkBeforeToolStripMenuItem.ToolTipText = "Insert new bookmark before the selected one"
         ' 
         ' _insertChildBookmarkToolStripMenuItem
         ' 
         Me._insertChildBookmarkToolStripMenuItem.Name = "_insertChildBookmarkToolStripMenuItem"
         Me._insertChildBookmarkToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
         Me._insertChildBookmarkToolStripMenuItem.Text = "Insert Child..."
         Me._insertChildBookmarkToolStripMenuItem.ToolTipText = "Insert child bookmark for the selected one"
         ' 
         ' _deleteToolStripDropDownButton
         ' 
         Me._deleteToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._deleteToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._deleteSelectedBookmarkToolStripMenuItem, Me._clearAllBookmarksToolStripMenuItem})
         Me._deleteToolStripDropDownButton.Image = Global.DocumentWritersDemo.Resources.Delete
         Me._deleteToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._deleteToolStripDropDownButton.Name = "_deleteToolStripDropDownButton"
         Me._deleteToolStripDropDownButton.Size = New System.Drawing.Size(29, 22)
         Me._deleteToolStripDropDownButton.Text = "Delete bookmark"
         ' 
         ' _deleteSelectedBookmarkToolStripMenuItem
         ' 
         Me._deleteSelectedBookmarkToolStripMenuItem.Name = "_deleteSelectedBookmarkToolStripMenuItem"
         Me._deleteSelectedBookmarkToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
         Me._deleteSelectedBookmarkToolStripMenuItem.Text = "Delete selected bookmark"
         ' 
         ' _clearAllBookmarksToolStripMenuItem
         ' 
         Me._clearAllBookmarksToolStripMenuItem.Name = "_clearAllBookmarksToolStripMenuItem"
         Me._clearAllBookmarksToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
         Me._clearAllBookmarksToolStripMenuItem.Text = "Clear all bookmarks"
         ' 
         ' _bookmarkPropertiesToolStripButton
         ' 
         Me._bookmarkPropertiesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._bookmarkPropertiesToolStripButton.Image = Global.DocumentWritersDemo.Resources.ObjectProperties
         Me._bookmarkPropertiesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._bookmarkPropertiesToolStripButton.Name = "_bookmarkPropertiesToolStripButton"
         Me._bookmarkPropertiesToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._bookmarkPropertiesToolStripButton.ToolTipText = "Show selected object(s) properties"
         ' 
         ' _tabControl
         ' 
         Me._tabControl.Alignment = System.Windows.Forms.TabAlignment.Left
         Me._tabControl.Controls.Add(Me._tabPages)
         Me._tabControl.Controls.Add(Me._tabBookmarks)
         Me._tabControl.Cursor = System.Windows.Forms.Cursors.Default
         Me._tabControl.Dock = System.Windows.Forms.DockStyle.Fill
         Me._tabControl.Font = New System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me._tabControl.ItemSize = New System.Drawing.Size(106, 25)
         Me._tabControl.Location = New System.Drawing.Point(0, 9)
         Me._tabControl.Multiline = True
         Me._tabControl.Name = "_tabControl"
         Me._tabControl.SelectedIndex = 0
         Me._tabControl.Size = New System.Drawing.Size(197, 355)
         Me._tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
         Me._tabControl.TabIndex = 12
         ' 
         ' _contextMenuBookmarks
         ' 
         Me._contextMenuBookmarks.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._insertBookmarkAfterMenuItem, Me._insertBookmarkBeforeMenuItem, Me._insertChildBookmarkMenuItem, Me._bookmarkPropertiesMenuItem, Me.toolStripMenuItemSeparator, Me._deleteBookmarkMenuItem})
         Me._contextMenuBookmarks.Name = "contextMenuBookmarks"
         Me._contextMenuBookmarks.Size = New System.Drawing.Size(150, 120)
         ' 
         ' _insertBookmarkAfterMenuItem
         ' 
         Me._insertBookmarkAfterMenuItem.Name = "_insertBookmarkAfterMenuItem"
         Me._insertBookmarkAfterMenuItem.Size = New System.Drawing.Size(149, 22)
         Me._insertBookmarkAfterMenuItem.Text = "Insert After..."
         ' 
         ' _insertBookmarkBeforeMenuItem
         ' 
         Me._insertBookmarkBeforeMenuItem.Name = "_insertBookmarkBeforeMenuItem"
         Me._insertBookmarkBeforeMenuItem.Size = New System.Drawing.Size(149, 22)
         Me._insertBookmarkBeforeMenuItem.Text = "Insert Before..."
         ' 
         ' _insertChildBookmarkMenuItem
         ' 
         Me._insertChildBookmarkMenuItem.Name = "_insertChildBookmarkMenuItem"
         Me._insertChildBookmarkMenuItem.Size = New System.Drawing.Size(149, 22)
         Me._insertChildBookmarkMenuItem.Text = "Insert Child..."
         ' 
         ' _bookmarkPropertiesMenuItem
         ' 
         Me._bookmarkPropertiesMenuItem.Name = "_bookmarkPropertiesMenuItem"
         Me._bookmarkPropertiesMenuItem.Size = New System.Drawing.Size(149, 22)
         Me._bookmarkPropertiesMenuItem.Text = "Properties..."
         ' 
         ' toolStripMenuItemSeparator
         ' 
         Me.toolStripMenuItemSeparator.Name = "toolStripMenuItemSeparator"
         Me.toolStripMenuItemSeparator.Size = New System.Drawing.Size(146, 6)
         ' 
         ' _deleteBookmarkMenuItem
         ' 
         Me._deleteBookmarkMenuItem.Name = "_deleteBookmarkMenuItem"
         Me._deleteBookmarkMenuItem.Size = New System.Drawing.Size(149, 22)
         Me._deleteBookmarkMenuItem.Text = "Delete"
         ' 
         ' PagesControl
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._tabControl)
         Me.Controls.Add(Me._titleDummy)
         Me.Name = "PagesControl"
         Me.Size = New System.Drawing.Size(197, 364)
         Me._tabPages.ResumeLayout(False)
         Me._tabPages.PerformLayout()
         Me._toolStrip.ResumeLayout(False)
         Me._toolStrip.PerformLayout()
         Me._tabBookmarks.ResumeLayout(False)
         Me._tabBookmarks.PerformLayout()
         Me.toolStrip1.ResumeLayout(False)
         Me.toolStrip1.PerformLayout()
         Me._tabControl.ResumeLayout(False)
         Me._contextMenuBookmarks.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub


#End Region

      Private WithEvents _movePageUpToolStripButton As System.Windows.Forms.ToolStripButton
      Private _titleDummy As System.Windows.Forms.Label
      Private _tabPages As System.Windows.Forms.TabPage
      Private WithEvents _rasterImageList As ImageViewer
      Private _toolStrip As System.Windows.Forms.ToolStrip
      Private WithEvents _newPageToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _deleteCurrentPageToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _movePageDownToolStripButton As System.Windows.Forms.ToolStripButton
      Private _tabBookmarks As System.Windows.Forms.TabPage
      Private _tabControl As System.Windows.Forms.TabControl
      Private toolStrip1 As System.Windows.Forms.ToolStrip
      Private _toolStripDropDownInsertBookmark As System.Windows.Forms.ToolStripDropDownButton
      Private WithEvents _insertBookmarkAfterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _insertBookmarkBeforeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _insertChildBookmarkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _deleteToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
      Private WithEvents _deleteSelectedBookmarkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _clearAllBookmarksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _bookmarkPropertiesToolStripButton As System.Windows.Forms.ToolStripButton
      Private _contextMenuBookmarks As System.Windows.Forms.ContextMenuStrip
      Private WithEvents _insertChildBookmarkMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _insertBookmarkAfterMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _insertBookmarkBeforeMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripMenuItemSeparator As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _deleteBookmarkMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _bookmarkPropertiesMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _treeBookmarks As System.Windows.Forms.TreeView

   End Class
End Namespace
