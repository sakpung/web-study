
Partial Public Class MainForm
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
         CleanUp(disposing)
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
      Me._tbAnnotationsPage = New System.Windows.Forms.TabPage()
      Me._tvLayers = New CheckBoxTreeView()
      Me._mainMenu = New System.Windows.Forms.MenuStrip()
      Me._miFile = New System.Windows.Forms.ToolStripMenuItem()
      Me._miFileLoad = New System.Windows.Forms.ToolStripMenuItem()
      Me._miFileSave = New System.Windows.Forms.ToolStripMenuItem()
      Me._miHelp = New System.Windows.Forms.ToolStripMenuItem()
      Me._miHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
      Me._mainMenu.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _tbAnnotationsPage
      ' 
      Me._tbAnnotationsPage.Location = New System.Drawing.Point(0, 0)
      Me._tbAnnotationsPage.Name = "_tbAnnotationsPage"
      Me._tbAnnotationsPage.Size = New System.Drawing.Size(200, 100)
      Me._tbAnnotationsPage.TabIndex = 0
      ' 
      ' _tvLayers
      ' 
      Me._tvLayers.Dock = System.Windows.Forms.DockStyle.Left
      Me._tvLayers.Location = New System.Drawing.Point(0, 24)
      Me._tvLayers.Name = "_tvLayers"
      Me._tvLayers.Size = New System.Drawing.Size(181, 497)
      Me._tvLayers.TabIndex = 1
      ' 
      ' _mainMenu
      ' 
      Me._mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFile, Me._miHelp})
      Me._mainMenu.Location = New System.Drawing.Point(0, 0)
      Me._mainMenu.Name = "_mainMenu"
      Me._mainMenu.Size = New System.Drawing.Size(850, 24)
      Me._mainMenu.TabIndex = 2
      Me._mainMenu.Text = "_mainMenu"
      ' 
      ' _miFile
      ' 
      Me._miFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFileLoad, Me._miFileSave})
      Me._miFile.Name = "_miFile"
      Me._miFile.Size = New System.Drawing.Size(37, 20)
      Me._miFile.Text = "&File"
      ' 
      ' _miFileLoad
      ' 
      Me._miFileLoad.Name = "_miFileLoad"
      Me._miFileLoad.Size = New System.Drawing.Size(168, 22)
      Me._miFileLoad.Text = "Load Annotations"
      ' 
      ' _miFileSave
      ' 
      Me._miFileSave.Name = "_miFileSave"
      Me._miFileSave.Size = New System.Drawing.Size(168, 22)
      Me._miFileSave.Text = "Save Annotations"
      ' 
      ' _miHelp
      ' 
      Me._miHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miHelpAbout})
      Me._miHelp.Name = "_miHelp"
      Me._miHelp.Size = New System.Drawing.Size(44, 20)
      Me._miHelp.Text = "&Help"
      ' 
      ' _miHelpAbout
      ' 
      Me._miHelpAbout.Name = "_miHelpAbout"
      Me._miHelpAbout.Size = New System.Drawing.Size(107, 22)
      Me._miHelpAbout.Text = "&About"
      ' 
      ' MainForm
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(850, 521)
      Me.Controls.Add(Me._tvLayers)
      Me.Controls.Add(Me._mainMenu)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Form1"
      Me._mainMenu.ResumeLayout(False)
      Me._mainMenu.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _tbAnnotationsPage As System.Windows.Forms.TabPage
   Private WithEvents _tvLayers As System.Windows.Forms.TreeView
   Private _mainMenu As System.Windows.Forms.MenuStrip
   Private _miFile As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFileLoad As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFileSave As System.Windows.Forms.ToolStripMenuItem
   Private _miHelp As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miHelpAbout As System.Windows.Forms.ToolStripMenuItem
End Class
