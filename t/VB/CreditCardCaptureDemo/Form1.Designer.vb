
Partial Class Form1
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

#Region "Windows Form Designer generated code"

   ''' <summary>
   ''' Required method for Designer support - do not modify
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
      Me._components = New System.ComponentModel.Container()
      Me._statusStrip = New System.Windows.Forms.StatusStrip()
      Me._toolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
      Me._statusStrip.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _statusStrip
      ' 
      Me._statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._toolStripStatusLabel})
      Me._statusStrip.Location = New System.Drawing.Point(0, 435)
      Me._statusStrip.Name = "_statusStrip"
      Me._statusStrip.Size = New System.Drawing.Size(657, 22)
      Me._statusStrip.TabIndex = 0
      Me._statusStrip.Text = "statusStrip1"
      Me._statusStrip.SizingGrip = False
      ' 
      ' _toolStripStatusLabel
      ' 
      Me._toolStripStatusLabel.Name = "_toolStripStatusLabel"
      Me._toolStripStatusLabel.Size = New System.Drawing.Size(0, 17)
      ' 
      ' _mainMenu
      ' 
      Me._mainMenu = New System.Windows.Forms.MainMenu(Me._components)
      Me._fileMenu = New System.Windows.Forms.MenuItem("File")
      Me._fileExit = New System.Windows.Forms.MenuItem("&Exit")
      Me._fileMenu.MenuItems.Add(Me._fileExit)
      Me._optionsMenu = New System.Windows.Forms.MenuItem("&Options")
      Me._optionsMenuVideoDevice = New System.Windows.Forms.MenuItem("Video &Devices")
      Me._optionsMenu.MenuItems.Add(Me._optionsMenuVideoDevice)
      Me._optionsMenu.MenuItems.Add("-")
      Me._captureOptions = New System.Windows.Forms.MenuItem("&Capture Options")
      Me._captureOptions.Enabled = False
      Me._optionsMenu.MenuItems.Add(Me._captureOptions)
      Me._miHelp = New System.Windows.Forms.MenuItem()
      Me._miHelp.Text = "Help"
      Me._miHelpAbout = New System.Windows.Forms.MenuItem()
      Me._miHelpAbout.Text = "About..."
      Me._miHelp.MenuItems.Add(Me._miHelpAbout)
      Me._optionsMenuVideoDeviceNone = New System.Windows.Forms.MenuItem("None")
      Me._optionsMenuVideoDeviceNone.Checked = True
      Me._optionsMenuVideoDevice.MenuItems.Add(Me._optionsMenuVideoDeviceNone)
      Me._mainMenu.MenuItems.Add(Me._fileMenu)
      Me._mainMenu.MenuItems.Add(Me._optionsMenu)
      Me._mainMenu.MenuItems.Add(Me._miHelp)
      ' 
      ' Form1
      ' 
      Me.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint Or System.Windows.Forms.ControlStyles.UserPaint Or System.Windows.Forms.ControlStyles.ResizeRedraw Or System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, True)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MinimizeBox = False
      Me.MaximizeBox = False
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(657, 457)
      Me.Controls.Add(Me._statusStrip)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Menu = Me._mainMenu
      Me.Name = "MainForm"
      Me.Text = "VB Credit Card Capture Demo"
      Me._statusStrip.ResumeLayout(False)
      Me._statusStrip.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

#End Region

   Private _statusStrip As System.Windows.Forms.StatusStrip
   Private _toolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
   Private _components As System.ComponentModel.Container
   Private _mainMenu As System.Windows.Forms.MainMenu
   Private _fileMenu As System.Windows.Forms.MenuItem
   Private WithEvents _fileExit As System.Windows.Forms.MenuItem
   Private _optionsMenu As System.Windows.Forms.MenuItem
   Private _optionsMenuVideoDevice As System.Windows.Forms.MenuItem
   Private WithEvents _optionsMenuVideoDeviceNone As System.Windows.Forms.MenuItem
   Private _miHelp As System.Windows.Forms.MenuItem
   Private WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
   Private WithEvents _captureOptions As System.Windows.Forms.MenuItem
End Class