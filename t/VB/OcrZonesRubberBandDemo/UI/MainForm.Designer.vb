Imports Microsoft.VisualBasic
Imports System
Namespace OcrZonesRubberBandDemo
   Public Partial Class MainForm
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

	  #Region "Windows Form Designer generated code"

	  ''' <summary>
	  ''' Required method for Designer support - do not modify
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
         Me.components = New System.ComponentModel.Container
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._splitContainer = New System.Windows.Forms.SplitContainer
         Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
         Me._toolbar = New System.Windows.Forms.ToolStrip
         Me._tsMainZoomComboBox = New System.Windows.Forms.ToolStripComboBox
         Me._viewer = New Leadtools.Controls.ImageViewer()
         Me._recognitionResults = New System.Windows.Forms.RichTextBox
         Me._mmMain = New System.Windows.Forms.MainMenu(Me.components)
         Me._miFile = New System.Windows.Forms.MenuItem
         Me._miFileOpen = New System.Windows.Forms.MenuItem
         Me._miFileSetLoadRes = New System.Windows.Forms.MenuItem
         Me._miFileSep1 = New System.Windows.Forms.MenuItem
         Me._miFileExit = New System.Windows.Forms.MenuItem
         Me._miHelp = New System.Windows.Forms.MenuItem
         Me._miHelpAbout = New System.Windows.Forms.MenuItem
         Me._splitContainer.Panel1.SuspendLayout()
         Me._splitContainer.Panel2.SuspendLayout()
         Me._splitContainer.SuspendLayout()
         Me.tableLayoutPanel1.SuspendLayout()
         Me._toolbar.SuspendLayout()
         Me.SuspendLayout()
         '
         '_splitContainer
         '
         Me._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer.Location = New System.Drawing.Point(0, 0)
         Me._splitContainer.Name = "_splitContainer"
         Me._splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
         '
         '_splitContainer.Panel1
         '
         Me._splitContainer.Panel1.Controls.Add(Me.tableLayoutPanel1)
         '
         '_splitContainer.Panel2
         '
         Me._splitContainer.Panel2.Controls.Add(Me._recognitionResults)
         Me._splitContainer.Size = New System.Drawing.Size(715, 250)
         Me._splitContainer.SplitterDistance = 176
         Me._splitContainer.TabIndex = 0
         '
         'tableLayoutPanel1
         '
         Me.tableLayoutPanel1.ColumnCount = 1
         Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
         Me.tableLayoutPanel1.Controls.Add(Me._toolbar, 0, 0)
         Me.tableLayoutPanel1.Controls.Add(Me._viewer, 0, 1)
         Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
         Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
         Me.tableLayoutPanel1.RowCount = 2
         Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
         Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
         Me.tableLayoutPanel1.Size = New System.Drawing.Size(715, 176)
         Me.tableLayoutPanel1.TabIndex = 4
         '
         '_toolbar
         '
         Me._toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._tsMainZoomComboBox})
         Me._toolbar.Location = New System.Drawing.Point(0, 0)
         Me._toolbar.Name = "_toolbar"
         Me._toolbar.Size = New System.Drawing.Size(715, 25)
         Me._toolbar.TabIndex = 3
         Me._toolbar.Text = "toolStrip1"
         '
         '_tsMainZoomComboBox
         '
         Me._tsMainZoomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._tsMainZoomComboBox.Name = "_tsMainZoomComboBox"
         Me._tsMainZoomComboBox.Size = New System.Drawing.Size(121, 25)
         '
         '_viewer
         '
         me._viewer.AutoDisposeImages = true
         Me._viewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._viewer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._viewer.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Near
         Me._viewer.Image = Nothing
         Me._viewer.Location = New System.Drawing.Point(3, 28)
         Me._viewer.Name = "_viewer"
         Me._viewer.Size = New System.Drawing.Size(709, 145)
         Me._viewer.TabIndex = 0
         Me._viewer.Text = "imageViewer"
         Me._viewer.UseDpi = False
         Me._viewer.ViewVerticalAlignment = Leadtools.Controls.ControlAlignment.Near
         '
         '_recognitionResults
         '
         Me._recognitionResults.BackColor = System.Drawing.Color.White
         Me._recognitionResults.Dock = System.Windows.Forms.DockStyle.Fill
         Me._recognitionResults.Location = New System.Drawing.Point(0, 0)
         Me._recognitionResults.Name = "_recognitionResults"
         Me._recognitionResults.ReadOnly = True
         Me._recognitionResults.Size = New System.Drawing.Size(715, 70)
         Me._recognitionResults.TabIndex = 0
         Me._recognitionResults.Text = ""
         '
         '_mmMain
         '
         Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miHelp})
         '
         '_miFile
         '
         Me._miFile.Index = 0
         Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileSetLoadRes, Me._miFileSep1, Me._miFileExit})
         Me._miFile.Text = "&File"
         '
         '_miFileOpen
         '
         Me._miFileOpen.Index = 0
         Me._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
         Me._miFileOpen.Text = "&Open"
         '
         '_miFileSetLoadRes
         '
         Me._miFileSetLoadRes.Index = 1
         Me._miFileSetLoadRes.Text = "Set Load &Resolution°"
         '
         '_miFileSep1
         '
         Me._miFileSep1.Index = 2
         Me._miFileSep1.Text = "-"
         '
         '_miFileExit
         '
         Me._miFileExit.Index = 3
         Me._miFileExit.Text = "E&xit"
         '
         '_miHelp
         '
         Me._miHelp.Index = 1
         Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
         Me._miHelp.Text = "&Help"
         '
         '_miHelpAbout
         '
         Me._miHelpAbout.Index = 0
         Me._miHelpAbout.Text = "&About"
         '
         'MainForm
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(715, 250)
         Me.Controls.Add(Me._splitContainer)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Menu = Me._mmMain
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "LEADTOOLS OCR Zones Rubberband Demo"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         Me._splitContainer.Panel1.ResumeLayout(False)
         Me._splitContainer.Panel2.ResumeLayout(False)
         Me._splitContainer.ResumeLayout(False)
         Me.tableLayoutPanel1.ResumeLayout(False)
         Me.tableLayoutPanel1.PerformLayout()
         Me._toolbar.ResumeLayout(False)
         Me._toolbar.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

	  #End Region

	  Private _splitContainer As System.Windows.Forms.SplitContainer
      Private WithEvents _viewer As Leadtools.Controls.ImageViewer
	  Private _recognitionResults As System.Windows.Forms.RichTextBox
	  Private _mmMain As System.Windows.Forms.MainMenu
	  Private _miFile As System.Windows.Forms.MenuItem
	  Private WithEvents _miFileOpen As System.Windows.Forms.MenuItem
	  Private WithEvents _miFileSetLoadRes As System.Windows.Forms.MenuItem
	  Private WithEvents _miFileExit As System.Windows.Forms.MenuItem
	  Private _miHelp As System.Windows.Forms.MenuItem
	  Private WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
	  Private _toolbar As System.Windows.Forms.ToolStrip
	  Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	  Private WithEvents _tsMainZoomComboBox As System.Windows.Forms.ToolStripComboBox
	  Private _miFileSep1 As System.Windows.Forms.MenuItem
   End Class
End Namespace

