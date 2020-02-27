Namespace DicomDemo
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
         Me.components = New System.ComponentModel.Container()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._splitContainer = New System.Windows.Forms.SplitContainer()
         Me._listViewImages = New System.Windows.Forms.ListView()
         Me._columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._contextMenuStripImages = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me._toolStripMenuItemRemoveSelected = New System.Windows.Forms.ToolStripMenuItem()
         Me._toolStripMenuItemRemoveAll = New System.Windows.Forms.ToolStripMenuItem()
         Me._label1 = New System.Windows.Forms.Label()
         Me._splitContainer1 = New System.Windows.Forms.SplitContainer()
         Me._buttonStorageCommit = New System.Windows.Forms.Button()
         Me._buttonCancel = New System.Windows.Forms.Button()
         Me._groupBoxServer = New System.Windows.Forms.GroupBox()
         Me._labelServerPort = New System.Windows.Forms.Label()
         Me._labelServerIp = New System.Windows.Forms.Label()
         Me._labelServerAeTitle = New System.Windows.Forms.Label()
         Me._textBoxServerPort = New System.Windows.Forms.TextBox()
         Me._textBoxServerIp = New System.Windows.Forms.TextBox()
         Me._comboBoxService = New System.Windows.Forms.ComboBox()
         Me._buttonOptions = New System.Windows.Forms.Button()
         Me._buttonStore = New System.Windows.Forms.Button()
         Me._richTextBoxLog = New System.Windows.Forms.RichTextBox()
         Me._contextMenuStripLog = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me.clearLogToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
         Me._labelStatus = New System.Windows.Forms.Label()
         Me._label2 = New System.Windows.Forms.Label()
         Me._fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.addDICOMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.addDICOMDIRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me.removeSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.removeAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
         Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.clearLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me.storeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.cancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.showHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuStrip = New System.Windows.Forms.MenuStrip()
         Me._openFileDialog = New System.Windows.Forms.OpenFileDialog()
         CType(Me._splitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._splitContainer.Panel1.SuspendLayout()
         Me._splitContainer.Panel2.SuspendLayout()
         Me._splitContainer.SuspendLayout()
         Me._contextMenuStripImages.SuspendLayout()
         CType(Me._splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._splitContainer1.Panel1.SuspendLayout()
         Me._splitContainer1.Panel2.SuspendLayout()
         Me._splitContainer1.SuspendLayout()
         Me._groupBoxServer.SuspendLayout()
         Me._contextMenuStripLog.SuspendLayout()
         Me._menuStrip.SuspendLayout()
         Me.SuspendLayout()
         '
         '_splitContainer
         '
         Me._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer.Location = New System.Drawing.Point(0, 24)
         Me._splitContainer.Name = "_splitContainer"
         Me._splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
         '
         '_splitContainer.Panel1
         '
         Me._splitContainer.Panel1.Controls.Add(Me._listViewImages)
         Me._splitContainer.Panel1.Controls.Add(Me._label1)
         '
         '_splitContainer.Panel2
         '
         Me._splitContainer.Panel2.Controls.Add(Me._splitContainer1)
         Me._splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
         Me._splitContainer.Size = New System.Drawing.Size(747, 512)
         Me._splitContainer.SplitterDistance = 292
         Me._splitContainer.TabIndex = 0
         '
         '_listViewImages
         '
         Me._listViewImages.AllowDrop = True
         Me._listViewImages.CheckBoxes = True
         Me._listViewImages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._columnHeader1, Me._columnHeader2, Me._columnHeader3, Me._columnHeader4, Me._columnHeader5, Me._columnHeader6})
         Me._listViewImages.ContextMenuStrip = Me._contextMenuStripImages
         Me._listViewImages.Dock = System.Windows.Forms.DockStyle.Fill
         Me._listViewImages.FullRowSelect = True
         Me._listViewImages.GridLines = True
         Me._listViewImages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me._listViewImages.HideSelection = False
         Me._listViewImages.Location = New System.Drawing.Point(0, 23)
         Me._listViewImages.Name = "_listViewImages"
         Me._listViewImages.Size = New System.Drawing.Size(747, 269)
         Me._listViewImages.TabIndex = 1
         Me._listViewImages.UseCompatibleStateImageBehavior = False
         Me._listViewImages.View = System.Windows.Forms.View.Details
         '
         '_columnHeader1
         '
         Me._columnHeader1.Text = "Patient Name"
         '
         '_columnHeader2
         '
         Me._columnHeader2.Text = "Patient ID"
         '
         '_columnHeader3
         '
         Me._columnHeader3.Text = "Study ID"
         '
         '_columnHeader4
         '
         Me._columnHeader4.Text = "Modality"
         '
         '_columnHeader5
         '
         Me._columnHeader5.Text = "Transfer Syntax"
         '
         '_columnHeader6
         '
         Me._columnHeader6.Text = "File Path"
         '
         '_contextMenuStripImages
         '
         Me._contextMenuStripImages.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._toolStripMenuItemRemoveSelected, Me._toolStripMenuItemRemoveAll})
         Me._contextMenuStripImages.Name = "_contextMenuStripImages"
         Me._contextMenuStripImages.Size = New System.Drawing.Size(165, 48)
         '
         '_toolStripMenuItemRemoveSelected
         '
         Me._toolStripMenuItemRemoveSelected.Name = "_toolStripMenuItemRemoveSelected"
         Me._toolStripMenuItemRemoveSelected.Size = New System.Drawing.Size(164, 22)
         Me._toolStripMenuItemRemoveSelected.Text = "Remove &Selected"
         '
         '_toolStripMenuItemRemoveAll
         '
         Me._toolStripMenuItemRemoveAll.Name = "_toolStripMenuItemRemoveAll"
         Me._toolStripMenuItemRemoveAll.Size = New System.Drawing.Size(164, 22)
         Me._toolStripMenuItemRemoveAll.Text = "Remove &All"
         '
         '_label1
         '
         Me._label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._label1.Dock = System.Windows.Forms.DockStyle.Top
         Me._label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._label1.Location = New System.Drawing.Point(0, 0)
         Me._label1.Name = "_label1"
         Me._label1.Size = New System.Drawing.Size(747, 23)
         Me._label1.TabIndex = 0
         Me._label1.Text = "Images: (File->Add Dicom) or (Drag and Drop) -- Right-click to delete"
         '
         '_splitContainer1
         '
         Me._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer1.Location = New System.Drawing.Point(0, 0)
         Me._splitContainer1.Name = "_splitContainer1"
         '
         '_splitContainer1.Panel1
         '
         Me._splitContainer1.Panel1.Controls.Add(Me._buttonStorageCommit)
         Me._splitContainer1.Panel1.Controls.Add(Me._buttonCancel)
         Me._splitContainer1.Panel1.Controls.Add(Me._groupBoxServer)
         Me._splitContainer1.Panel1.Controls.Add(Me._buttonOptions)
         Me._splitContainer1.Panel1.Controls.Add(Me._buttonStore)
         '
         '_splitContainer1.Panel2
         '
         Me._splitContainer1.Panel2.Controls.Add(Me._richTextBoxLog)
         Me._splitContainer1.Panel2.Controls.Add(Me._labelStatus)
         Me._splitContainer1.Panel2.Controls.Add(Me._label2)
         Me._splitContainer1.Size = New System.Drawing.Size(747, 216)
         Me._splitContainer1.SplitterDistance = 247
         Me._splitContainer1.TabIndex = 2
         '
         '_buttonStorageCommit
         '
         Me._buttonStorageCommit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
         Me._buttonStorageCommit.Location = New System.Drawing.Point(3, 186)
         Me._buttonStorageCommit.Name = "_buttonStorageCommit"
         Me._buttonStorageCommit.Size = New System.Drawing.Size(106, 23)
         Me._buttonStorageCommit.TabIndex = 15
         Me._buttonStorageCommit.Text = "Storage Commit"
         Me._buttonStorageCommit.UseVisualStyleBackColor = True
         '
         '_buttonCancel
         '
         Me._buttonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
         Me._buttonCancel.Location = New System.Drawing.Point(167, 157)
         Me._buttonCancel.Name = "_buttonCancel"
         Me._buttonCancel.Size = New System.Drawing.Size(75, 23)
         Me._buttonCancel.TabIndex = 14
         Me._buttonCancel.Text = "&Cancel"
         Me._buttonCancel.UseVisualStyleBackColor = True
         '
         '_groupBoxServer
         '
         Me._groupBoxServer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
               Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._groupBoxServer.Controls.Add(Me._labelServerPort)
         Me._groupBoxServer.Controls.Add(Me._labelServerIp)
         Me._groupBoxServer.Controls.Add(Me._labelServerAeTitle)
         Me._groupBoxServer.Controls.Add(Me._textBoxServerPort)
         Me._groupBoxServer.Controls.Add(Me._textBoxServerIp)
         Me._groupBoxServer.Controls.Add(Me._comboBoxService)
         Me._groupBoxServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._groupBoxServer.Location = New System.Drawing.Point(0, 0)
         Me._groupBoxServer.Name = "_groupBoxServer"
         Me._groupBoxServer.Size = New System.Drawing.Size(248, 122)
         Me._groupBoxServer.TabIndex = 11
         Me._groupBoxServer.TabStop = False
         Me._groupBoxServer.Text = "Server"
         '
         '_labelServerPort
         '
         Me._labelServerPort.AutoSize = True
         Me._labelServerPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._labelServerPort.Location = New System.Drawing.Point(8, 67)
         Me._labelServerPort.Name = "_labelServerPort"
         Me._labelServerPort.Size = New System.Drawing.Size(29, 13)
         Me._labelServerPort.TabIndex = 14
         Me._labelServerPort.Text = "Port:"
         Me._labelServerPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_labelServerIp
         '
         Me._labelServerIp.AutoSize = True
         Me._labelServerIp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._labelServerIp.Location = New System.Drawing.Point(8, 44)
         Me._labelServerIp.Name = "_labelServerIp"
         Me._labelServerIp.Size = New System.Drawing.Size(20, 13)
         Me._labelServerIp.TabIndex = 13
         Me._labelServerIp.Text = "IP:"
         Me._labelServerIp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_labelServerAeTitle
         '
         Me._labelServerAeTitle.AutoSize = True
         Me._labelServerAeTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._labelServerAeTitle.Location = New System.Drawing.Point(8, 20)
         Me._labelServerAeTitle.Name = "_labelServerAeTitle"
         Me._labelServerAeTitle.Size = New System.Drawing.Size(24, 13)
         Me._labelServerAeTitle.TabIndex = 12
         Me._labelServerAeTitle.Text = "AE:"
         Me._labelServerAeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_textBoxServerPort
         '
         Me._textBoxServerPort.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._textBoxServerPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._textBoxServerPort.Location = New System.Drawing.Point(48, 63)
         Me._textBoxServerPort.Name = "_textBoxServerPort"
         Me._textBoxServerPort.ReadOnly = True
         Me._textBoxServerPort.Size = New System.Drawing.Size(195, 20)
         Me._textBoxServerPort.TabIndex = 11
         '
         '_textBoxServerIp
         '
         Me._textBoxServerIp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._textBoxServerIp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._textBoxServerIp.Location = New System.Drawing.Point(48, 40)
         Me._textBoxServerIp.Name = "_textBoxServerIp"
         Me._textBoxServerIp.ReadOnly = True
         Me._textBoxServerIp.Size = New System.Drawing.Size(195, 20)
         Me._textBoxServerIp.TabIndex = 10
         '
         '_comboBoxService
         '
         Me._comboBoxService.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._comboBoxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._comboBoxService.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._comboBoxService.FormattingEnabled = True
         Me._comboBoxService.Location = New System.Drawing.Point(48, 16)
         Me._comboBoxService.Name = "_comboBoxService"
         Me._comboBoxService.Size = New System.Drawing.Size(195, 21)
         Me._comboBoxService.TabIndex = 9
         '
         '_buttonOptions
         '
         Me._buttonOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
         Me._buttonOptions.Location = New System.Drawing.Point(3, 128)
         Me._buttonOptions.Name = "_buttonOptions"
         Me._buttonOptions.Size = New System.Drawing.Size(106, 23)
         Me._buttonOptions.TabIndex = 12
         Me._buttonOptions.Text = "&Options..."
         Me._buttonOptions.UseVisualStyleBackColor = True
         '
         '_buttonStore
         '
         Me._buttonStore.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
         Me._buttonStore.Location = New System.Drawing.Point(3, 157)
         Me._buttonStore.Name = "_buttonStore"
         Me._buttonStore.Size = New System.Drawing.Size(106, 23)
         Me._buttonStore.TabIndex = 13
         Me._buttonStore.Text = "&Store"
         Me._buttonStore.UseVisualStyleBackColor = True
         '
         '_richTextBoxLog
         '
         Me._richTextBoxLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
               Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._richTextBoxLog.BackColor = System.Drawing.SystemColors.Control
         Me._richTextBoxLog.ContextMenuStrip = Me._contextMenuStripLog
         Me._richTextBoxLog.Location = New System.Drawing.Point(0, 24)
         Me._richTextBoxLog.Name = "_richTextBoxLog"
         Me._richTextBoxLog.ReadOnly = True
         Me._richTextBoxLog.Size = New System.Drawing.Size(504, 194)
         Me._richTextBoxLog.TabIndex = 7
         Me._richTextBoxLog.Text = ""
         Me._richTextBoxLog.WordWrap = False
         '
         '_contextMenuStripLog
         '
         Me._contextMenuStripLog.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.clearLogToolStripMenuItem1})
         Me._contextMenuStripLog.Name = "_contextMenuStripLog"
         Me._contextMenuStripLog.Size = New System.Drawing.Size(125, 26)
         '
         'clearLogToolStripMenuItem1
         '
         Me.clearLogToolStripMenuItem1.Name = "clearLogToolStripMenuItem1"
         Me.clearLogToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
         Me.clearLogToolStripMenuItem1.Text = "&Clear Log"
         '
         '_labelStatus
         '
         Me._labelStatus.AutoSize = True
         Me._labelStatus.ForeColor = System.Drawing.Color.Blue
         Me._labelStatus.Location = New System.Drawing.Point(224, 8)
         Me._labelStatus.Name = "_labelStatus"
         Me._labelStatus.Size = New System.Drawing.Size(35, 13)
         Me._labelStatus.TabIndex = 6
         Me._labelStatus.Text = "status"
         '
         '_label2
         '
         Me._label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._label2.Location = New System.Drawing.Point(0, 0)
         Me._label2.Name = "_label2"
         Me._label2.Size = New System.Drawing.Size(500, 23)
         Me._label2.TabIndex = 4
         Me._label2.Text = "Log: (Right-click to clear)"
         '
         '_fileToolStripMenuItem
         '
         Me._fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.addDICOMToolStripMenuItem, Me.addDICOMDIRToolStripMenuItem, Me.toolStripSeparator1, Me.removeSelectedToolStripMenuItem, Me.removeAllToolStripMenuItem, Me.toolStripSeparator4, Me.optionsToolStripMenuItem, Me.clearLogToolStripMenuItem, Me.toolStripSeparator2, Me.storeToolStripMenuItem, Me.cancelToolStripMenuItem, Me.toolStripSeparator3, Me.exitToolStripMenuItem})
         Me._fileToolStripMenuItem.Name = "_fileToolStripMenuItem"
         Me._fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
         Me._fileToolStripMenuItem.Text = "&File"
         '
         'addDICOMToolStripMenuItem
         '
         Me.addDICOMToolStripMenuItem.Name = "addDICOMToolStripMenuItem"
         Me.addDICOMToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
         Me.addDICOMToolStripMenuItem.Text = "Add &DICOM..."
         '
         'addDICOMDIRToolStripMenuItem
         '
         Me.addDICOMDIRToolStripMenuItem.Name = "addDICOMDIRToolStripMenuItem"
         Me.addDICOMDIRToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
         Me.addDICOMDIRToolStripMenuItem.Text = "Add DICOMDI&R..."
         '
         'toolStripSeparator1
         '
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(162, 6)
         '
         'removeSelectedToolStripMenuItem
         '
         Me.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem"
         Me.removeSelectedToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
         Me.removeSelectedToolStripMenuItem.Text = "Remove &Selected"
         '
         'removeAllToolStripMenuItem
         '
         Me.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem"
         Me.removeAllToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
         Me.removeAllToolStripMenuItem.Text = "Remove &All"
         '
         'toolStripSeparator4
         '
         Me.toolStripSeparator4.Name = "toolStripSeparator4"
         Me.toolStripSeparator4.Size = New System.Drawing.Size(162, 6)
         '
         'optionsToolStripMenuItem
         '
         Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
         Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
         Me.optionsToolStripMenuItem.Text = "&Options..."
         '
         'clearLogToolStripMenuItem
         '
         Me.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem"
         Me.clearLogToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
         Me.clearLogToolStripMenuItem.Text = "&Clear Log"
         '
         'toolStripSeparator2
         '
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         Me.toolStripSeparator2.Size = New System.Drawing.Size(162, 6)
         '
         'storeToolStripMenuItem
         '
         Me.storeToolStripMenuItem.Name = "storeToolStripMenuItem"
         Me.storeToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
         Me.storeToolStripMenuItem.Text = "&Store"
         '
         'cancelToolStripMenuItem
         '
         Me.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem"
         Me.cancelToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
         Me.cancelToolStripMenuItem.Text = "&Cancel"
         '
         'toolStripSeparator3
         '
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         Me.toolStripSeparator3.Size = New System.Drawing.Size(162, 6)
         '
         'exitToolStripMenuItem
         '
         Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
         Me.exitToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
         Me.exitToolStripMenuItem.Text = "&Exit"
         '
         '_helpToolStripMenuItem
         '
         Me._helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.showHelpToolStripMenuItem, Me.aboutToolStripMenuItem})
         Me._helpToolStripMenuItem.Name = "_helpToolStripMenuItem"
         Me._helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me._helpToolStripMenuItem.Text = "&Help"
         '
         'showHelpToolStripMenuItem
         '
         Me.showHelpToolStripMenuItem.Name = "showHelpToolStripMenuItem"
         Me.showHelpToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
         Me.showHelpToolStripMenuItem.Text = "&Show Help..."
         '
         'aboutToolStripMenuItem
         '
         Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
         Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
         Me.aboutToolStripMenuItem.Text = "&About..."
         '
         '_menuStrip
         '
         Me._menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileToolStripMenuItem, Me._helpToolStripMenuItem})
         Me._menuStrip.Location = New System.Drawing.Point(0, 0)
         Me._menuStrip.Name = "_menuStrip"
         Me._menuStrip.Size = New System.Drawing.Size(747, 24)
         Me._menuStrip.TabIndex = 1
         Me._menuStrip.Text = "_menuStrip"
         '
         '_openFileDialog
         '
         Me._openFileDialog.FileName = "_openFileDialog"
         '
         'MainForm
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(747, 536)
         Me.Controls.Add(Me._splitContainer)
         Me.Controls.Add(Me._menuStrip)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Name = "MainForm"
         Me.Text = "LEADTOOLS High Level DICOM Store Demo - VB.Net"
         Me._splitContainer.Panel1.ResumeLayout(False)
         Me._splitContainer.Panel2.ResumeLayout(False)
         CType(Me._splitContainer, System.ComponentModel.ISupportInitialize).EndInit()
         Me._splitContainer.ResumeLayout(False)
         Me._contextMenuStripImages.ResumeLayout(False)
         Me._splitContainer1.Panel1.ResumeLayout(False)
         Me._splitContainer1.Panel2.ResumeLayout(False)
         Me._splitContainer1.Panel2.PerformLayout()
         CType(Me._splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
         Me._splitContainer1.ResumeLayout(False)
         Me._groupBoxServer.ResumeLayout(False)
         Me._groupBoxServer.PerformLayout()
         Me._contextMenuStripLog.ResumeLayout(False)
         Me._menuStrip.ResumeLayout(False)
         Me._menuStrip.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

        Private _splitContainer As System.Windows.Forms.SplitContainer
        Private WithEvents _listViewImages As System.Windows.Forms.ListView
        Private _label1 As System.Windows.Forms.Label
        Private _contextMenuStripLog As System.Windows.Forms.ContextMenuStrip
        Private _columnHeader1 As System.Windows.Forms.ColumnHeader
        Private _columnHeader2 As System.Windows.Forms.ColumnHeader
        Private _columnHeader3 As System.Windows.Forms.ColumnHeader
        Private _columnHeader4 As System.Windows.Forms.ColumnHeader
        Private _columnHeader5 As System.Windows.Forms.ColumnHeader
        Private _columnHeader6 As System.Windows.Forms.ColumnHeader
        Private _fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private _helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private _menuStrip As System.Windows.Forms.MenuStrip
        Private WithEvents optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents clearLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Private WithEvents addDICOMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents addDICOMDIRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Private WithEvents storeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Private exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private _openFileDialog As System.Windows.Forms.OpenFileDialog
        Private WithEvents clearLogToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents removeSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents removeAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Private _contextMenuStripImages As System.Windows.Forms.ContextMenuStrip
        Private WithEvents _toolStripMenuItemRemoveSelected As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents _toolStripMenuItemRemoveAll As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents _splitContainer1 As System.Windows.Forms.SplitContainer
        Private WithEvents cancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents showHelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents _buttonCancel As System.Windows.Forms.Button
        Private WithEvents _buttonStore As System.Windows.Forms.Button
        Private WithEvents _buttonOptions As System.Windows.Forms.Button
        Private WithEvents _groupBoxServer As System.Windows.Forms.GroupBox
        Private WithEvents _labelServerPort As System.Windows.Forms.Label
        Private WithEvents _labelServerIp As System.Windows.Forms.Label
        Private WithEvents _labelServerAeTitle As System.Windows.Forms.Label
        Private WithEvents _textBoxServerPort As System.Windows.Forms.TextBox
        Private WithEvents _textBoxServerIp As System.Windows.Forms.TextBox
        Private WithEvents _comboBoxService As System.Windows.Forms.ComboBox
        Private WithEvents _richTextBoxLog As System.Windows.Forms.RichTextBox
        Private WithEvents _labelStatus As System.Windows.Forms.Label
      Private WithEvents _label2 As System.Windows.Forms.Label
      Private WithEvents _buttonStorageCommit As System.Windows.Forms.Button
    End Class
End Namespace