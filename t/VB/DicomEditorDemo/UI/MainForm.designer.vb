Imports Microsoft.VisualBasic
Imports System
Namespace DicomEditorDemo
	Partial Public Class MainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
		   Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
		   Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
		   Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
		   Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
		   Me.splitContainer = New System.Windows.Forms.SplitContainer()
		   Me.propertyGridDataSet = New Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid()
		   Me.DicomEditableObject = New Leadtools.Dicom.Common.Editing.DicomEditableObject()
		   Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
		   Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.newtoolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
		   Me.saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.saveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		   Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.commandsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.addTagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.addItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
		   Me.deleteTagToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
		   Me.animationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.showTagInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.showUsageImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
		   Me.addCommandsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.readOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		   Me.toolStripContainer1.BottomToolStripPanel.SuspendLayout()
		   Me.toolStripContainer1.ContentPanel.SuspendLayout()
		   Me.toolStripContainer1.TopToolStripPanel.SuspendLayout()
		   Me.toolStripContainer1.SuspendLayout()
		   Me.splitContainer.Panel1.SuspendLayout()
		   Me.splitContainer.SuspendLayout()
		   Me.menuStrip1.SuspendLayout()
		   Me.SuspendLayout()
		   ' 
		   ' openFileDialog
		   ' 
		   Me.openFileDialog.Filter = "DICOM Files | *.dcm|All Files|*.*"
		   ' 
		   ' toolStripContainer1
		   ' 
		   ' 
		   ' toolStripContainer1.BottomToolStripPanel
		   ' 
		   Me.toolStripContainer1.BottomToolStripPanel.Controls.Add(Me.statusStrip1)
		   ' 
		   ' toolStripContainer1.ContentPanel
		   ' 
		   Me.toolStripContainer1.ContentPanel.Controls.Add(Me.splitContainer)
		   Me.toolStripContainer1.ContentPanel.Size = New System.Drawing.Size(787, 507)
		   Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		   Me.toolStripContainer1.Location = New System.Drawing.Point(0, 0)
		   Me.toolStripContainer1.Name = "toolStripContainer1"
		   Me.toolStripContainer1.Size = New System.Drawing.Size(787, 553)
		   Me.toolStripContainer1.TabIndex = 2
		   Me.toolStripContainer1.Text = "toolStripContainer1"
		   ' 
		   ' toolStripContainer1.TopToolStripPanel
		   ' 
		   Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.menuStrip1)
		   ' 
		   ' statusStrip1
		   ' 
		   Me.statusStrip1.Dock = System.Windows.Forms.DockStyle.None
		   Me.statusStrip1.Location = New System.Drawing.Point(0, 0)
		   Me.statusStrip1.Name = "statusStrip1"
		   Me.statusStrip1.Size = New System.Drawing.Size(787, 22)
		   Me.statusStrip1.TabIndex = 0
		   ' 
		   ' splitContainer
		   ' 
		   Me.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
		   Me.splitContainer.Location = New System.Drawing.Point(0, 0)
		   Me.splitContainer.Name = "splitContainer"
		   ' 
		   ' splitContainer.Panel1
		   ' 
		   Me.splitContainer.Panel1.Controls.Add(Me.propertyGridDataSet)
		   Me.splitContainer.Size = New System.Drawing.Size(787, 507)
		   Me.splitContainer.SplitterDistance = 100
		   Me.splitContainer.TabIndex = 3
		   ' 
		   ' propertyGridDataSet
		   ' 
		   Me.propertyGridDataSet.AutoDisplayDescription = True
		   Me.propertyGridDataSet.DataSet = Nothing
		   Me.propertyGridDataSet.DefaultTag = (CLng(Fix(-1)))
		   Me.propertyGridDataSet.Dock = System.Windows.Forms.DockStyle.Fill
		   Me.propertyGridDataSet.Location = New System.Drawing.Point(0, 0)
		   Me.propertyGridDataSet.Name = "propertyGridDataSet"
		   Me.propertyGridDataSet.PropertySort = System.Windows.Forms.PropertySort.NoSort
		   Me.propertyGridDataSet.ReadOnly = False
		   Me.propertyGridDataSet.SelectedObject = Me.DicomEditableObject
		   Me.propertyGridDataSet.ShowCommands = True
		   Me.propertyGridDataSet.ShowTagInfo = True
		   Me.propertyGridDataSet.ShowUsageImages = True
		   Me.propertyGridDataSet.Size = New System.Drawing.Size(100, 507)
		   Me.propertyGridDataSet.TabIndex = 3
		   Me.propertyGridDataSet.Type1ConditionalImage = (CType(resources.GetObject("propertyGridDataSet.Type1ConditionalImage"), System.Drawing.Image))
		   Me.propertyGridDataSet.Type1MandatoryImage = (CType(resources.GetObject("propertyGridDataSet.Type1MandatoryImage"), System.Drawing.Image))
		   Me.propertyGridDataSet.Type2ConditionalImage = (CType(resources.GetObject("propertyGridDataSet.Type2ConditionalImage"), System.Drawing.Image))
		   Me.propertyGridDataSet.Type2MandatoryImage = (CType(resources.GetObject("propertyGridDataSet.Type2MandatoryImage"), System.Drawing.Image))
		   Me.propertyGridDataSet.Type3Image = Nothing
'		   Me.propertyGridDataSet.PropertyValueChanged += New System.Windows.Forms.PropertyValueChangedEventHandler(Me.propertyGridDataSet_PropertyValueChanged);
'		   Me.propertyGridDataSet.BeforeAddElement += New System.EventHandler(Of Leadtools.Dicom.Common.Editing.BeforeAddElementEventArgs)(Me.propertyGridDataSet_BeforeAddElement);
		   ' 
		   ' menuStrip1
		   ' 
		   Me.menuStrip1.Dock = System.Windows.Forms.DockStyle.None
		   Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.fileToolStripMenuItem, Me.commandsToolStripMenuItem, Me.optionsToolStripMenuItem, Me.helpToolStripMenuItem})
		   Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
		   Me.menuStrip1.Name = "menuStrip1"
		   Me.menuStrip1.Size = New System.Drawing.Size(787, 24)
		   Me.menuStrip1.TabIndex = 0
		   Me.menuStrip1.Text = "menuStrip1"
		   ' 
		   ' fileToolStripMenuItem
		   ' 
		   Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.newtoolStripMenuItem, Me.openToolStripMenuItem, Me.toolStripSeparator, Me.saveToolStripMenuItem, Me.saveAsToolStripMenuItem, Me.toolStripSeparator1, Me.exitToolStripMenuItem})
		   Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
		   Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
		   Me.fileToolStripMenuItem.Text = "&File"
'		   Me.fileToolStripMenuItem.DropDownOpening += New System.EventHandler(Me.fileToolStripMenuItem_DropDownOpening);
		   ' 
		   ' newtoolStripMenuItem
		   ' 
		   Me.newtoolStripMenuItem.Image = (CType(resources.GetObject("newtoolStripMenuItem.Image"), System.Drawing.Image))
		   Me.newtoolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		   Me.newtoolStripMenuItem.Name = "newtoolStripMenuItem"
		   Me.newtoolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		   Me.newtoolStripMenuItem.Text = "&New"
'		   Me.newtoolStripMenuItem.Click += New System.EventHandler(Me.newtoolStripMenuItem_Click);
		   ' 
		   ' openToolStripMenuItem
		   ' 
		   Me.openToolStripMenuItem.Image = (CType(resources.GetObject("openToolStripMenuItem.Image"), System.Drawing.Image))
		   Me.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		   Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
		   Me.openToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys))
		   Me.openToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		   Me.openToolStripMenuItem.Text = "&Open"
'		   Me.openToolStripMenuItem.Click += New System.EventHandler(Me.openToolStripMenuItem_Click);
		   ' 
		   ' toolStripSeparator
		   ' 
		   Me.toolStripSeparator.Name = "toolStripSeparator"
		   Me.toolStripSeparator.Size = New System.Drawing.Size(143, 6)
		   ' 
		   ' saveToolStripMenuItem
		   ' 
		   Me.saveToolStripMenuItem.Image = (CType(resources.GetObject("saveToolStripMenuItem.Image"), System.Drawing.Image))
		   Me.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		   Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
		   Me.saveToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys))
		   Me.saveToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		   Me.saveToolStripMenuItem.Text = "&Save"
'		   Me.saveToolStripMenuItem.Click += New System.EventHandler(Me.saveToolStripMenuItem_Click);
		   ' 
		   ' saveAsToolStripMenuItem
		   ' 
		   Me.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem"
		   Me.saveAsToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		   Me.saveAsToolStripMenuItem.Text = "Save &As"
'		   Me.saveAsToolStripMenuItem.Click += New System.EventHandler(Me.saveAsToolStripMenuItem_Click);
		   ' 
		   ' toolStripSeparator1
		   ' 
		   Me.toolStripSeparator1.Name = "toolStripSeparator1"
		   Me.toolStripSeparator1.Size = New System.Drawing.Size(143, 6)
		   ' 
		   ' exitToolStripMenuItem
		   ' 
		   Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
		   Me.exitToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		   Me.exitToolStripMenuItem.Text = "E&xit"
'		   Me.exitToolStripMenuItem.Click += New System.EventHandler(Me.exitToolStripMenuItem_Click);
		   ' 
		   ' commandsToolStripMenuItem
		   ' 
		   Me.commandsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.addTagsToolStripMenuItem, Me.addItemToolStripMenuItem, Me.toolStripMenuItem2, Me.deleteTagToolStripMenuItem, Me.toolStripMenuItem4, Me.animationToolStripMenuItem})
		   Me.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem"
		   Me.commandsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
		   Me.commandsToolStripMenuItem.Text = "&Actions"
'		   Me.commandsToolStripMenuItem.DropDownOpening += New System.EventHandler(Me.commandsToolStripMenuItem_DropDownOpening);
		   ' 
		   ' addTagsToolStripMenuItem
		   ' 
		   Me.addTagsToolStripMenuItem.Name = "addTagsToolStripMenuItem"
		   Me.addTagsToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
		   Me.addTagsToolStripMenuItem.Text = "&Add Tags"
'		   Me.addTagsToolStripMenuItem.Click += New System.EventHandler(Me.addTagsToolStripMenuItem_Click);
		   ' 
		   ' addItemToolStripMenuItem
		   ' 
		   Me.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem"
		   Me.addItemToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
		   Me.addItemToolStripMenuItem.Text = "Add &Item"
'		   Me.addItemToolStripMenuItem.Click += New System.EventHandler(Me.addItemToolStripMenuItem_Click);
		   ' 
		   ' toolStripMenuItem2
		   ' 
		   Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
		   Me.toolStripMenuItem2.Size = New System.Drawing.Size(136, 6)
		   ' 
		   ' deleteTagToolStripMenuItem
		   ' 
		   Me.deleteTagToolStripMenuItem.Name = "deleteTagToolStripMenuItem"
		   Me.deleteTagToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
		   Me.deleteTagToolStripMenuItem.Text = "&Delete Tag"
'		   Me.deleteTagToolStripMenuItem.Click += New System.EventHandler(Me.deleteTagToolStripMenuItem_Click);
		   ' 
		   ' toolStripMenuItem4
		   ' 
		   Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
		   Me.toolStripMenuItem4.Size = New System.Drawing.Size(136, 6)
		   ' 
		   ' animationToolStripMenuItem
		   ' 
		   Me.animationToolStripMenuItem.Name = "animationToolStripMenuItem"
		   Me.animationToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
		   Me.animationToolStripMenuItem.Text = "Animation..."
'		   Me.animationToolStripMenuItem.Click += New System.EventHandler(Me.animationToolStripMenuItem_Click);
		   ' 
		   ' optionsToolStripMenuItem
		   ' 
		   Me.optionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.showTagInfoToolStripMenuItem, Me.showUsageImagesToolStripMenuItem, Me.toolStripMenuItem1, Me.addCommandsToolStripMenuItem, Me.readOnlyToolStripMenuItem})
		   Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
		   Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
		   Me.optionsToolStripMenuItem.Text = "&Options"
'		   Me.optionsToolStripMenuItem.DropDownOpening += New System.EventHandler(Me.optionsToolStripMenuItem_DropDownOpening);
		   ' 
		   ' showTagInfoToolStripMenuItem
		   ' 
		   Me.showTagInfoToolStripMenuItem.CheckOnClick = True
		   Me.showTagInfoToolStripMenuItem.Name = "showTagInfoToolStripMenuItem"
		   Me.showTagInfoToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
		   Me.showTagInfoToolStripMenuItem.Text = "&Show Tag Info"
'		   Me.showTagInfoToolStripMenuItem.Click += New System.EventHandler(Me.showTagInfoToolStripMenuItem_Click);
		   ' 
		   ' showUsageImagesToolStripMenuItem
		   ' 
		   Me.showUsageImagesToolStripMenuItem.CheckOnClick = True
		   Me.showUsageImagesToolStripMenuItem.Name = "showUsageImagesToolStripMenuItem"
		   Me.showUsageImagesToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
		   Me.showUsageImagesToolStripMenuItem.Text = "Show &Usage Images"
'		   Me.showUsageImagesToolStripMenuItem.Click += New System.EventHandler(Me.showUsageImagesToolStripMenuItem_Click);
		   ' 
		   ' toolStripMenuItem1
		   ' 
		   Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
		   Me.toolStripMenuItem1.Size = New System.Drawing.Size(176, 6)
		   ' 
		   ' addCommandsToolStripMenuItem
		   ' 
		   Me.addCommandsToolStripMenuItem.CheckOnClick = True
		   Me.addCommandsToolStripMenuItem.Name = "addCommandsToolStripMenuItem"
		   Me.addCommandsToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
		   Me.addCommandsToolStripMenuItem.Text = "&Add Commands"
'		   Me.addCommandsToolStripMenuItem.Click += New System.EventHandler(Me.addCommandsToolStripMenuItem_Click);
		   ' 
		   ' readOnlyToolStripMenuItem
		   ' 
		   Me.readOnlyToolStripMenuItem.Name = "readOnlyToolStripMenuItem"
		   Me.readOnlyToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
		   Me.readOnlyToolStripMenuItem.Text = "Read Only"
'		   Me.readOnlyToolStripMenuItem.Click += New System.EventHandler(Me.readOnlyToolStripMenuItem_Click);
		   ' 
		   ' helpToolStripMenuItem
		   ' 
		   Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.aboutToolStripMenuItem})
		   Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
		   Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
		   Me.helpToolStripMenuItem.Text = "&Help"
		   ' 
		   ' aboutToolStripMenuItem
		   ' 
		   Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
		   Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
		   Me.aboutToolStripMenuItem.Text = "&About"
'		   Me.aboutToolStripMenuItem.Click += New System.EventHandler(Me.aboutToolStripMenuItem_Click);
		   ' 
		   ' MainForm
		   ' 
		   Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		   Me.ClientSize = New System.Drawing.Size(787, 553)
		   Me.Controls.Add(Me.toolStripContainer1)
		   Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		   Me.MainMenuStrip = Me.menuStrip1
		   Me.Name = "MainForm"
		   Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		   Me.Text = "DICOM Property Editor"
		   Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
'		   Me.Load += New System.EventHandler(Me.MainForm_Load);
		   Me.toolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
		   Me.toolStripContainer1.BottomToolStripPanel.PerformLayout()
		   Me.toolStripContainer1.ContentPanel.ResumeLayout(False)
		   Me.toolStripContainer1.TopToolStripPanel.ResumeLayout(False)
		   Me.toolStripContainer1.TopToolStripPanel.PerformLayout()
		   Me.toolStripContainer1.ResumeLayout(False)
		   Me.toolStripContainer1.PerformLayout()
		   Me.splitContainer.Panel1.ResumeLayout(False)
		   Me.splitContainer.ResumeLayout(False)
		   Me.menuStrip1.ResumeLayout(False)
		   Me.menuStrip1.PerformLayout()
		   Me.ResumeLayout(False)

		End Sub

		#End Region

		Private openFileDialog As System.Windows.Forms.OpenFileDialog
		Private toolStripContainer1 As System.Windows.Forms.ToolStripContainer
		Private DicomEditableObject As Leadtools.Dicom.Common.Editing.DicomEditableObject
		Private menuStrip1 As System.Windows.Forms.MenuStrip
		Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator As System.Windows.Forms.ToolStripSeparator
		Private WithEvents saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents saveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents showTagInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents showUsageImagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents addCommandsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private statusStrip1 As System.Windows.Forms.StatusStrip
		Private WithEvents newtoolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents commandsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents addTagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents addItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents deleteTagToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private splitContainer As System.Windows.Forms.SplitContainer
		Private WithEvents propertyGridDataSet As Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid
		Private toolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents animationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents readOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	End Class
End Namespace

