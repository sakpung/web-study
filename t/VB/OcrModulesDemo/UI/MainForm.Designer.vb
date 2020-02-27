Imports Microsoft.VisualBasic
Imports System

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
      If disposing Then
         CleanUp()
      End If

      If disposing AndAlso (Not components Is Nothing) Then
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
      Me._lblDocumentFormat = New System.Windows.Forms.Label()
      Me._splitContainer = New System.Windows.Forms.SplitContainer()
      Me.groupBox2 = New System.Windows.Forms.GroupBox()
      Me._btnClearZones = New System.Windows.Forms.Button()
      Me._btnRecognize = New System.Windows.Forms.Button()
      Me._btnBrowseImageFile = New System.Windows.Forms.Button()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me._omrOptionsButton = New System.Windows.Forms.Button()
      Me._cbViewFinalDocument = New System.Windows.Forms.CheckBox()
      Me._cmbOcrModules = New System.Windows.Forms.ComboBox()
      Me._lblOcrModules = New System.Windows.Forms.Label()
      Me._statusBar = New System.Windows.Forms.StatusStrip()
      Me._lblImageFileName = New System.Windows.Forms.ToolStripStatusLabel()
      Me._documentFormatSelector = New DocumentFormatSelector()
      'CType(Me._splitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._splitContainer.Panel1.SuspendLayout()
      Me._splitContainer.SuspendLayout()
      Me.groupBox2.SuspendLayout()
      Me.groupBox1.SuspendLayout()
      Me._statusBar.SuspendLayout()
      Me.SuspendLayout()
      '
      '_lblDocumentFormat
      '
      Me._lblDocumentFormat.AutoSize = True
      Me._lblDocumentFormat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lblDocumentFormat.Location = New System.Drawing.Point(6, 100)
      Me._lblDocumentFormat.Name = "_lblDocumentFormat"
      Me._lblDocumentFormat.Size = New System.Drawing.Size(92, 13)
      Me._lblDocumentFormat.TabIndex = 3
      Me._lblDocumentFormat.Text = "Document &Format"
      '
      '_splitContainer
      '
      Me._splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
      Me._splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
      Me._splitContainer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._splitContainer.IsSplitterFixed = True
      Me._splitContainer.Location = New System.Drawing.Point(0, 0)
      Me._splitContainer.Name = "_splitContainer"
      '
      '_splitContainer.Panel1
      '
      Me._splitContainer.Panel1.AutoScroll = True
      Me._splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control
      Me._splitContainer.Panel1.Controls.Add(Me.groupBox2)
      Me._splitContainer.Panel1.Controls.Add(Me.groupBox1)
      Me._splitContainer.Panel1MinSize = 0
      Me._splitContainer.Panel2MinSize = 0
      Me._splitContainer.Size = New System.Drawing.Size(801, 524)
      Me._splitContainer.SplitterDistance = 280
      Me._splitContainer.TabIndex = 0
      '
      'groupBox2
      '
      Me.groupBox2.Controls.Add(Me._btnClearZones)
      Me.groupBox2.Controls.Add(Me._btnRecognize)
      Me.groupBox2.Controls.Add(Me._btnBrowseImageFile)
      Me.groupBox2.Location = New System.Drawing.Point(10, 194)
      Me.groupBox2.Name = "groupBox2"
      Me.groupBox2.Size = New System.Drawing.Size(263, 183)
      Me.groupBox2.TabIndex = 1
      Me.groupBox2.TabStop = False
      Me.groupBox2.Text = "Action"
      '
      '_btnClearZones
      '
      Me._btnClearZones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._btnClearZones.Location = New System.Drawing.Point(6, 122)
      Me._btnClearZones.Name = "_btnClearZones"
      Me._btnClearZones.Size = New System.Drawing.Size(251, 45)
      Me._btnClearZones.TabIndex = 2
      Me._btnClearZones.Text = "&Clear Zones"
      Me._btnClearZones.UseVisualStyleBackColor = True
      '
      '_btnRecognize
      '
      Me._btnRecognize.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._btnRecognize.Location = New System.Drawing.Point(6, 71)
      Me._btnRecognize.Name = "_btnRecognize"
      Me._btnRecognize.Size = New System.Drawing.Size(251, 45)
      Me._btnRecognize.TabIndex = 1
      Me._btnRecognize.Text = "&Recognize and Save Results"
      Me._btnRecognize.UseVisualStyleBackColor = True
      '
      '_btnBrowseImageFile
      '
      Me._btnBrowseImageFile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._btnBrowseImageFile.Location = New System.Drawing.Point(6, 20)
      Me._btnBrowseImageFile.Name = "_btnBrowseImageFile"
      Me._btnBrowseImageFile.Size = New System.Drawing.Size(251, 45)
      Me._btnBrowseImageFile.TabIndex = 0
      Me._btnBrowseImageFile.Text = "&Open..."
      Me._btnBrowseImageFile.UseVisualStyleBackColor = True
      '
      'groupBox1
      '
      Me.groupBox1.Controls.Add(Me._omrOptionsButton)
      Me.groupBox1.Controls.Add(Me._documentFormatSelector)
      Me.groupBox1.Controls.Add(Me._cbViewFinalDocument)
      Me.groupBox1.Controls.Add(Me._cmbOcrModules)
      Me.groupBox1.Controls.Add(Me._lblOcrModules)
      Me.groupBox1.Controls.Add(Me._lblDocumentFormat)
      Me.groupBox1.Location = New System.Drawing.Point(10, 11)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(263, 177)
      Me.groupBox1.TabIndex = 0
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Options"
      '
      '_omrOptionsButton
      '
      Me._omrOptionsButton.Location = New System.Drawing.Point(6, 64)
      Me._omrOptionsButton.Name = "_omrOptionsButton"
      Me._omrOptionsButton.Size = New System.Drawing.Size(251, 23)
      Me._omrOptionsButton.TabIndex = 2
      Me._omrOptionsButton.Text = "Change OMR Options..."
      Me._omrOptionsButton.UseVisualStyleBackColor = True
      '
      '_cbViewFinalDocument
      '
      Me._cbViewFinalDocument.AutoSize = True
      Me._cbViewFinalDocument.Location = New System.Drawing.Point(6, 145)
      Me._cbViewFinalDocument.Name = "_cbViewFinalDocument"
      Me._cbViewFinalDocument.Size = New System.Drawing.Size(124, 17)
      Me._cbViewFinalDocument.TabIndex = 5
      Me._cbViewFinalDocument.Text = "&View Final Document"
      Me._cbViewFinalDocument.UseVisualStyleBackColor = True
      '
      '_cmbOcrModules
      '
      Me._cmbOcrModules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbOcrModules.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cmbOcrModules.FormattingEnabled = True
      Me._cmbOcrModules.Location = New System.Drawing.Point(6, 37)
      Me._cmbOcrModules.Name = "_cmbOcrModules"
      Me._cmbOcrModules.Size = New System.Drawing.Size(251, 21)
      Me._cmbOcrModules.TabIndex = 1
      '
      '_lblOcrModules
      '
      Me._lblOcrModules.AutoSize = True
      Me._lblOcrModules.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lblOcrModules.Location = New System.Drawing.Point(3, 21)
      Me._lblOcrModules.Name = "_lblOcrModules"
      Me._lblOcrModules.Size = New System.Drawing.Size(152, 13)
      Me._lblOcrModules.TabIndex = 0
      Me._lblOcrModules.Text = "OCR &Modules And Fill Methods"
      '
      '_statusBar
      '
      Me._statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._lblImageFileName})
      Me._statusBar.Location = New System.Drawing.Point(0, 524)
      Me._statusBar.Name = "_statusBar"
      Me._statusBar.Size = New System.Drawing.Size(801, 22)
      Me._statusBar.TabIndex = 1
      Me._statusBar.Text = "statusStrip1"
      '
      '_lblImageFileName
      '
      Me._lblImageFileName.AutoSize = False
      Me._lblImageFileName.BackColor = System.Drawing.SystemColors.Control
      Me._lblImageFileName.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
      Me._lblImageFileName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me._lblImageFileName.ForeColor = System.Drawing.Color.Blue
      Me._lblImageFileName.Margin = New System.Windows.Forms.Padding(1, 3, 1, 2)
      Me._lblImageFileName.Name = "_lblImageFileName"
      Me._lblImageFileName.Size = New System.Drawing.Size(220, 17)
      Me._lblImageFileName.Text = "Ready"
      Me._lblImageFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_documentFormatSelector
      '
      Me._documentFormatSelector.FormatHasOptions = False
      Me._documentFormatSelector.Location = New System.Drawing.Point(6, 116)
      Me._documentFormatSelector.Name = "_documentFormatSelector"
      Me._documentFormatSelector.Size = New System.Drawing.Size(251, 23)
      Me._documentFormatSelector.TabIndex = 4
      Me._documentFormatSelector.TotalPages = 0
      '
      'MainForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(801, 546)
      Me.Controls.Add(Me._splitContainer)
      Me.Controls.Add(Me._statusBar)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "MainForm"
      Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "OCR Modules Demo"
      Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
      Me._splitContainer.Panel1.ResumeLayout(False)
      'CType(Me._splitContainer, System.ComponentModel.ISupportInitialize).EndInit()
      Me._splitContainer.ResumeLayout(False)
      Me.groupBox2.ResumeLayout(False)
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      Me._statusBar.ResumeLayout(False)
      Me._statusBar.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _lblDocumentFormat As System.Windows.Forms.Label
   Private _splitContainer As System.Windows.Forms.SplitContainer
   Private WithEvents _cmbOcrModules As System.Windows.Forms.ComboBox
   Private _lblOcrModules As System.Windows.Forms.Label
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private groupBox2 As System.Windows.Forms.GroupBox
   Private WithEvents _btnRecognize As System.Windows.Forms.Button
   Private WithEvents _btnBrowseImageFile As System.Windows.Forms.Button
   Private _cbViewFinalDocument As System.Windows.Forms.CheckBox
   Private _statusBar As System.Windows.Forms.StatusStrip
   Private _lblImageFileName As System.Windows.Forms.ToolStripStatusLabel
   Private WithEvents _btnClearZones As System.Windows.Forms.Button
   Friend WithEvents _documentFormatSelector As DocumentFormatSelector
   Private WithEvents _omrOptionsButton As System.Windows.Forms.Button







End Class

