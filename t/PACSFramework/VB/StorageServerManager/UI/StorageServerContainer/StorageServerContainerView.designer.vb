Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Leadtools.Demos.StorageServer.UI
   Partial Public Class StorageServerContainerView
      Private Sub InitializeComponent()
         Me.LeftPanel = New DoubleBufferedPanel()
         Me.ContentsPanel = New DoubleBufferedPanel()
         Me.TopPanel = New DoubleBufferedPanel()
         Me.HeaderPanel = New DoubleBufferedPanel()
         Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
         Me.TopPanel.SuspendLayout()
         CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' LeftPanel
         ' 
         Me.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left
         Me.LeftPanel.Location = New System.Drawing.Point(0, 128)
         Me.LeftPanel.Name = "LeftPanel"
         Me.LeftPanel.Size = New System.Drawing.Size(200, 478)
         Me.LeftPanel.TabIndex = 1
         ' 
         ' ContentsPanel
         ' 
         Me.ContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me.ContentsPanel.Location = New System.Drawing.Point(200, 128)
         Me.ContentsPanel.Name = "ContentsPanel"
         Me.ContentsPanel.Size = New System.Drawing.Size(569, 478)
         Me.ContentsPanel.TabIndex = 2
         ' 
         ' TopPanel
         ' 
         Me.TopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
         Me.TopPanel.Controls.Add(Me.HeaderPanel)
         Me.TopPanel.Controls.Add(Me.LogoPictureBox)
         Me.TopPanel.Dock = System.Windows.Forms.DockStyle.Top
         Me.TopPanel.Location = New System.Drawing.Point(0, 0)
         Me.TopPanel.Name = "TopPanel"
         Me.TopPanel.Size = New System.Drawing.Size(769, 128)
         Me.TopPanel.TabIndex = 0
         ' 
         ' HeaderPanel
         ' 
         Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me.HeaderPanel.Location = New System.Drawing.Point(200, 0)
         Me.HeaderPanel.Name = "HeaderPanel"
         Me.HeaderPanel.Size = New System.Drawing.Size(569, 128)
         Me.HeaderPanel.TabIndex = 1
         ' 
         ' LogoPictureBox
         ' 
         Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Left
         Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
         Me.LogoPictureBox.Name = "LogoPictureBox"
         Me.LogoPictureBox.Size = New System.Drawing.Size(200, 128)
         Me.LogoPictureBox.TabIndex = 0
         Me.LogoPictureBox.TabStop = False
         ' 
         ' StorageServerContainerView
         ' 
         Me.BackgroundImage = Global.My.Resources.gradient
         Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
         Me.Controls.Add(Me.ContentsPanel)
         Me.Controls.Add(Me.LeftPanel)
         Me.Controls.Add(Me.TopPanel)
         Me.Name = "StorageServerContainerView"
         Me.Size = New System.Drawing.Size(769, 606)
         Me.TopPanel.ResumeLayout(False)
         CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

      Private TopPanel As DoubleBufferedPanel
      Private LeftPanel As DoubleBufferedPanel
      Private ContentsPanel As DoubleBufferedPanel
      Private HeaderPanel As DoubleBufferedPanel
      Private LogoPictureBox As System.Windows.Forms.PictureBox
   End Class

End Namespace
