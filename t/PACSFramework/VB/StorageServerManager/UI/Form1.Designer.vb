Namespace Leadtools.Demos.StorageServer
   Partial Friend Class MainForm
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
         Me.components = New System.ComponentModel.Container()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me.MainNotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
         Me.SystemTrayContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me.showToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.SystemTrayContextMenuStrip.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' MainNotifyIcon
         ' 
         Me.MainNotifyIcon.ContextMenuStrip = Me.SystemTrayContextMenuStrip
         Me.MainNotifyIcon.Text = "notifyIcon1"
         Me.MainNotifyIcon.Visible = True
         ' 
         ' SystemTrayContextMenuStrip
         ' 
         Me.SystemTrayContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.showToolStripMenuItem, Me.aboutToolStripMenuItem, Me.toolStripSeparator1, Me.exitToolStripMenuItem})
         Me.SystemTrayContextMenuStrip.Name = "contextMenuStrip1"
         Me.SystemTrayContextMenuStrip.Size = New System.Drawing.Size(108, 76)
         ' 
         ' showToolStripMenuItem
         ' 
         Me.showToolStripMenuItem.Name = "showToolStripMenuItem"
         Me.showToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
         Me.showToolStripMenuItem.Text = "Show"
         ' 
         ' aboutToolStripMenuItem
         ' 
         Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
         Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
         Me.aboutToolStripMenuItem.Text = "About"
         ' 
         ' toolStripSeparator1
         ' 
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(104, 6)
         ' 
         ' exitToolStripMenuItem
         ' 
         Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
         Me.exitToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
         Me.exitToolStripMenuItem.Text = "Exit"
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(1210, 787)
         Me.DoubleBuffered = True
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.Name = "MainForm"
         Me.Text = "LEADTOOLS Storage Server"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         Me.SystemTrayContextMenuStrip.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub

#End Region

      Friend MainNotifyIcon As System.Windows.Forms.NotifyIcon
      Private SystemTrayContextMenuStrip As System.Windows.Forms.ContextMenuStrip
      Private showToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem



   End Class
End Namespace

