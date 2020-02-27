Imports Microsoft.VisualBasic
Imports System
Namespace Ocr2SharePointDemo
   Public Partial Class SharePointBrowserControl
	  ''' <summary> 
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.IContainer = Nothing

	  ''' <summary> 
	  ''' Clean up any resources being used.
	  ''' </summary>
	  ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		 If disposing AndAlso (Not components Is Nothing) Then
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
		 Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SharePointBrowserControl))
		 Me._descriptionLabel = New System.Windows.Forms.Label()
		 Me._instructionLabel = New System.Windows.Forms.Label()
		 Me._documentLibrariesGroupBox = New System.Windows.Forms.GroupBox()
		 Me._documentLibrariesListBox = New System.Windows.Forms.ListBox()
		 Me._listsContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
		 Me._listsCopyAbsoluteURLToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._documentsGroupBox = New System.Windows.Forms.GroupBox()
		 Me._downloadButton = New System.Windows.Forms.Button()
		 Me._selectedFileTextBox = New System.Windows.Forms.TextBox()
		 Me._selectedFileLabel = New System.Windows.Forms.Label()
		 Me._selectedFolderTextBox = New System.Windows.Forms.TextBox()
		 Me._itemsContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
		 Me._itemsCopyAbsoluteURLToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._itemsDownloadToDiskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._selectedFolderLabel = New System.Windows.Forms.Label()
		 Me._errorLabel = New System.Windows.Forms.Label()
		 Me._refreshButton = New System.Windows.Forms.Button()
		 Me._sharePointItemsListView = New Ocr2SharePointDemo.SharePointItemsListView()
		 Me._documentLibrariesGroupBox.SuspendLayout()
		 Me._listsContextMenuStrip.SuspendLayout()
		 Me._documentsGroupBox.SuspendLayout()
		 Me._itemsContextMenuStrip.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _descriptionLabel
		 ' 
		 Me._descriptionLabel.AutoSize = True
		 Me._descriptionLabel.Location = New System.Drawing.Point(4, 4)
		 Me._descriptionLabel.Name = "_descriptionLabel"
		 Me._descriptionLabel.Size = New System.Drawing.Size(309, 13)
		 Me._descriptionLabel.TabIndex = 0
		 Me._descriptionLabel.Text = "The SharePoint server contains the following document libraries."
		 ' 
		 ' _instructionLabel
		 ' 
		 Me._instructionLabel.Location = New System.Drawing.Point(4, 27)
		 Me._instructionLabel.Name = "_instructionLabel"
		 Me._instructionLabel.Size = New System.Drawing.Size(714, 38)
		 Me._instructionLabel.TabIndex = 1
		 Me._instructionLabel.Text = resources.GetString("_instructionLabel.Text")
		 ' 
		 ' _documentLibrariesGroupBox
		 ' 
		 Me._documentLibrariesGroupBox.Controls.Add(Me._documentLibrariesListBox)
		 Me._documentLibrariesGroupBox.Location = New System.Drawing.Point(7, 68)
		 Me._documentLibrariesGroupBox.Name = "_documentLibrariesGroupBox"
		 Me._documentLibrariesGroupBox.Size = New System.Drawing.Size(200, 235)
		 Me._documentLibrariesGroupBox.TabIndex = 2
		 Me._documentLibrariesGroupBox.TabStop = False
		 Me._documentLibrariesGroupBox.Text = "Document Libraries"
		 ' 
		 ' _documentLibrariesListBox
		 ' 
		 Me._documentLibrariesListBox.ContextMenuStrip = Me._listsContextMenuStrip
		 Me._documentLibrariesListBox.FormattingEnabled = True
		 Me._documentLibrariesListBox.Location = New System.Drawing.Point(7, 20)
		 Me._documentLibrariesListBox.Name = "_documentLibrariesListBox"
		 Me._documentLibrariesListBox.ScrollAlwaysVisible = True
		 Me._documentLibrariesListBox.Size = New System.Drawing.Size(187, 199)
		 Me._documentLibrariesListBox.TabIndex = 0
'		 Me._documentLibrariesListBox.SelectedIndexChanged += New System.EventHandler(Me._documentLibrariesListBox_SelectedIndexChanged);
		 ' 
		 ' _listsContextMenuStrip
		 ' 
		 Me._listsContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me._listsCopyAbsoluteURLToClipboardToolStripMenuItem})
		 Me._listsContextMenuStrip.Name = "_listsContextMenuStrip"
		 Me._listsContextMenuStrip.Size = New System.Drawing.Size(262, 26)
'		 Me._listsContextMenuStrip.Opening += New System.ComponentModel.CancelEventHandler(Me._listsContextMenuStrip_Opening);
		 ' 
		 ' _listsCopyAbsoluteURLToClipboardToolStripMenuItem
		 ' 
		 Me._listsCopyAbsoluteURLToClipboardToolStripMenuItem.Name = "_listsCopyAbsoluteURLToClipboardToolStripMenuItem"
		 Me._listsCopyAbsoluteURLToClipboardToolStripMenuItem.Size = New System.Drawing.Size(261, 22)
		 Me._listsCopyAbsoluteURLToClipboardToolStripMenuItem.Text = "&Copy absolute URL to the clipboard"
'		 Me._listsCopyAbsoluteURLToClipboardToolStripMenuItem.Click += New System.EventHandler(Me._listsCopyAbsoluteURLToClipboardToolStripMenuItem_Click);
		 ' 
		 ' _documentsGroupBox
		 ' 
		 Me._documentsGroupBox.Controls.Add(Me._downloadButton)
		 Me._documentsGroupBox.Controls.Add(Me._selectedFileTextBox)
		 Me._documentsGroupBox.Controls.Add(Me._selectedFileLabel)
		 Me._documentsGroupBox.Controls.Add(Me._selectedFolderTextBox)
		 Me._documentsGroupBox.Controls.Add(Me._sharePointItemsListView)
		 Me._documentsGroupBox.Controls.Add(Me._selectedFolderLabel)
		 Me._documentsGroupBox.Location = New System.Drawing.Point(213, 68)
		 Me._documentsGroupBox.Name = "_documentsGroupBox"
		 Me._documentsGroupBox.Size = New System.Drawing.Size(511, 235)
		 Me._documentsGroupBox.TabIndex = 3
		 Me._documentsGroupBox.TabStop = False
		 Me._documentsGroupBox.Text = "Existing Folders and Document"
		 ' 
		 ' _downloadButton
		 ' 
         Me._downloadButton.Image = Global.Ocr2SharePointDemo.Resources.Download
		 Me._downloadButton.Location = New System.Drawing.Point(482, 41)
		 Me._downloadButton.Name = "_downloadButton"
		 Me._downloadButton.Size = New System.Drawing.Size(23, 23)
		 Me._downloadButton.TabIndex = 5
		 Me._downloadButton.UseVisualStyleBackColor = True
'		 Me._downloadButton.Click += New System.EventHandler(Me._downloadButton_Click);
		 ' 
		 ' _selectedFileTextBox
		 ' 
		 Me._selectedFileTextBox.Location = New System.Drawing.Point(94, 43)
		 Me._selectedFileTextBox.Name = "_selectedFileTextBox"
		 Me._selectedFileTextBox.ReadOnly = True
		 Me._selectedFileTextBox.Size = New System.Drawing.Size(382, 20)
		 Me._selectedFileTextBox.TabIndex = 4
		 Me._selectedFileTextBox.TabStop = False
		 ' 
		 ' _selectedFileLabel
		 ' 
		 Me._selectedFileLabel.AutoSize = True
		 Me._selectedFileLabel.Location = New System.Drawing.Point(7, 46)
		 Me._selectedFileLabel.Name = "_selectedFileLabel"
		 Me._selectedFileLabel.Size = New System.Drawing.Size(68, 13)
		 Me._selectedFileLabel.TabIndex = 3
		 Me._selectedFileLabel.Text = "Selected file:"
		 ' 
		 ' _selectedFolderTextBox
		 ' 
		 Me._selectedFolderTextBox.Location = New System.Drawing.Point(94, 20)
		 Me._selectedFolderTextBox.Name = "_selectedFolderTextBox"
		 Me._selectedFolderTextBox.ReadOnly = True
		 Me._selectedFolderTextBox.Size = New System.Drawing.Size(411, 20)
		 Me._selectedFolderTextBox.TabIndex = 1
		 Me._selectedFolderTextBox.TabStop = False
		 ' 
		 ' _itemsContextMenuStrip
		 ' 
		 Me._itemsContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me._itemsCopyAbsoluteURLToClipboardToolStripMenuItem, Me._itemsDownloadToDiskToolStripMenuItem})
		 Me._itemsContextMenuStrip.Name = "_itemsContextMenuStrip"
		 Me._itemsContextMenuStrip.Size = New System.Drawing.Size(262, 48)
'		 Me._itemsContextMenuStrip.Opening += New System.ComponentModel.CancelEventHandler(Me._itemsContextMenuStrip_Opening);
		 ' 
		 ' _itemsCopyAbsoluteURLToClipboardToolStripMenuItem
		 ' 
		 Me._itemsCopyAbsoluteURLToClipboardToolStripMenuItem.Name = "_itemsCopyAbsoluteURLToClipboardToolStripMenuItem"
		 Me._itemsCopyAbsoluteURLToClipboardToolStripMenuItem.Size = New System.Drawing.Size(261, 22)
		 Me._itemsCopyAbsoluteURLToClipboardToolStripMenuItem.Text = "&Copy absolute URL to the clipboard"
'		 Me._itemsCopyAbsoluteURLToClipboardToolStripMenuItem.Click += New System.EventHandler(Me._itemsCopyAbsoluteURLToClipboardToolStripMenuItem_Click);
		 ' 
		 ' _itemsDownloadToDiskToolStripMenuItem
		 ' 
         Me._itemsDownloadToDiskToolStripMenuItem.Image = Global.Ocr2SharePointDemo.Resources.Download
		 Me._itemsDownloadToDiskToolStripMenuItem.Name = "_itemsDownloadToDiskToolStripMenuItem"
		 Me._itemsDownloadToDiskToolStripMenuItem.Size = New System.Drawing.Size(261, 22)
		 Me._itemsDownloadToDiskToolStripMenuItem.Text = "&Download to disk and view"
'		 Me._itemsDownloadToDiskToolStripMenuItem.Click += New System.EventHandler(Me._itemsDownloadToDiskToolStripMenuItem_Click);
		 ' 
		 ' _selectedFolderLabel
		 ' 
		 Me._selectedFolderLabel.AutoSize = True
		 Me._selectedFolderLabel.Location = New System.Drawing.Point(7, 23)
		 Me._selectedFolderLabel.Name = "_selectedFolderLabel"
		 Me._selectedFolderLabel.Size = New System.Drawing.Size(81, 13)
		 Me._selectedFolderLabel.TabIndex = 0
		 Me._selectedFolderLabel.Text = "Selected folder:"
		 ' 
		 ' _errorLabel
		 ' 
		 Me._errorLabel.ForeColor = System.Drawing.Color.Red
		 Me._errorLabel.Location = New System.Drawing.Point(210, 310)
		 Me._errorLabel.Name = "_errorLabel"
		 Me._errorLabel.Size = New System.Drawing.Size(433, 13)
		 Me._errorLabel.TabIndex = 5
		 Me._errorLabel.Text = "_errorLabel"
		 ' 
		 ' _refreshButton
		 ' 
		 Me._refreshButton.Location = New System.Drawing.Point(649, 304)
		 Me._refreshButton.Name = "_refreshButton"
		 Me._refreshButton.Size = New System.Drawing.Size(75, 23)
		 Me._refreshButton.TabIndex = 6
		 Me._refreshButton.Text = "Refresh"
		 Me._refreshButton.UseVisualStyleBackColor = True
'		 Me._refreshButton.Click += New System.EventHandler(Me._refreshButton_Click);
		 ' 
		 ' _sharePointItemsListView
		 ' 
		 Me._sharePointItemsListView.ContextMenuStrip = Me._itemsContextMenuStrip
		 Me._sharePointItemsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
		 Me._sharePointItemsListView.Location = New System.Drawing.Point(7, 67)
		 Me._sharePointItemsListView.Name = "_sharePointItemsListView"
		 Me._sharePointItemsListView.Size = New System.Drawing.Size(498, 152)
		 Me._sharePointItemsListView.TabIndex = 2
		 Me._sharePointItemsListView.UseCompatibleStateImageBehavior = False
		 Me._sharePointItemsListView.View = System.Windows.Forms.View.Details
'		 Me._sharePointItemsListView.ItemActivate += New System.EventHandler(Me._sharePointItemsListView_ItemActivate);
'		 Me._sharePointItemsListView.SelectedIndexChanged += New System.EventHandler(Me._sharePointItemsListView_SelectedIndexChanged);
		 ' 
		 ' SharePointBrowserControl
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.Controls.Add(Me._refreshButton)
		 Me.Controls.Add(Me._errorLabel)
		 Me.Controls.Add(Me._documentsGroupBox)
		 Me.Controls.Add(Me._documentLibrariesGroupBox)
		 Me.Controls.Add(Me._instructionLabel)
		 Me.Controls.Add(Me._descriptionLabel)
		 Me.Name = "SharePointBrowserControl"
		 Me.Size = New System.Drawing.Size(740, 330)
		 Me._documentLibrariesGroupBox.ResumeLayout(False)
		 Me._listsContextMenuStrip.ResumeLayout(False)
		 Me._documentsGroupBox.ResumeLayout(False)
		 Me._documentsGroupBox.PerformLayout()
		 Me._itemsContextMenuStrip.ResumeLayout(False)
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _descriptionLabel As System.Windows.Forms.Label
	  Private _instructionLabel As System.Windows.Forms.Label
	  Private _documentLibrariesGroupBox As System.Windows.Forms.GroupBox
	  Private WithEvents _documentLibrariesListBox As System.Windows.Forms.ListBox
	  Private _documentsGroupBox As System.Windows.Forms.GroupBox
	  Private _selectedFolderLabel As System.Windows.Forms.Label
	  Private WithEvents _sharePointItemsListView As SharePointItemsListView
	  Private _errorLabel As System.Windows.Forms.Label
	  Private _selectedFolderTextBox As System.Windows.Forms.TextBox
	  Private WithEvents _listsContextMenuStrip As System.Windows.Forms.ContextMenuStrip
	  Private WithEvents _listsCopyAbsoluteURLToClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _itemsContextMenuStrip As System.Windows.Forms.ContextMenuStrip
	  Private WithEvents _itemsCopyAbsoluteURLToClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _refreshButton As System.Windows.Forms.Button
	  Private _selectedFileTextBox As System.Windows.Forms.TextBox
	  Private _selectedFileLabel As System.Windows.Forms.Label
	  Private WithEvents _downloadButton As System.Windows.Forms.Button
	  Private WithEvents _itemsDownloadToDiskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   End Class
End Namespace
