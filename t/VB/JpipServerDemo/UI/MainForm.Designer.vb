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
         If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
         End If

         If _server.IsRunning Then
            _server.Stop()
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
      Me.lstvwEventLog = New System.Windows.Forms.ListView
      Me.ServerName = New System.Windows.Forms.ColumnHeader
      Me.ServerIPAddress = New System.Windows.Forms.ColumnHeader
      Me.ServerPort = New System.Windows.Forms.ColumnHeader
      Me.ClientIPAddress = New System.Windows.Forms.ColumnHeader
      Me.ClientPort = New System.Windows.Forms.ColumnHeader
      Me.EventType = New System.Windows.Forms.ColumnHeader
      Me.ChannelID = New System.Windows.Forms.ColumnHeader
      Me.DateTime = New System.Windows.Forms.ColumnHeader
      Me.Description = New System.Windows.Forms.ColumnHeader
      Me.mnuMain = New System.Windows.Forms.MenuStrip
      Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.clearLogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.displayLogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ClearCacheToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.InteractiveRequeststoolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.InteractiveResponsestoolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
      Me.ConfiguraitonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.FileEnumerationServiceToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
      Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.howToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuMain.SuspendLayout()
      Me.SuspendLayout()
      '
      'lstvwEventLog
      '
      Me.lstvwEventLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ServerName, Me.ServerIPAddress, Me.ServerPort, Me.ClientIPAddress, Me.ClientPort, Me.EventType, Me.ChannelID, Me.DateTime, Me.Description})
      Me.lstvwEventLog.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lstvwEventLog.FullRowSelect = True
      Me.lstvwEventLog.HideSelection = False
      Me.lstvwEventLog.Location = New System.Drawing.Point(0, 24)
      Me.lstvwEventLog.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.lstvwEventLog.MultiSelect = False
      Me.lstvwEventLog.Name = "lstvwEventLog"
      Me.lstvwEventLog.Size = New System.Drawing.Size(639, 485)
      Me.lstvwEventLog.Sorting = System.Windows.Forms.SortOrder.Ascending
      Me.lstvwEventLog.TabIndex = 2
      Me.lstvwEventLog.UseCompatibleStateImageBehavior = False
      Me.lstvwEventLog.View = System.Windows.Forms.View.Details
      '
      'ServerName
      '
      Me.ServerName.Text = "Server Name"
      Me.ServerName.Width = 115
      '
      'ServerIPAddress
      '
      Me.ServerIPAddress.Text = "Server IP Address"
      Me.ServerIPAddress.Width = 67
      '
      'ServerPort
      '
      Me.ServerPort.Text = "Server Port"
      Me.ServerPort.Width = 72
      '
      'ClientIPAddress
      '
      Me.ClientIPAddress.Text = "Client IP Address"
      Me.ClientIPAddress.Width = 93
      '
      'ClientPort
      '
      Me.ClientPort.Text = "Client Port"
      Me.ClientPort.Width = 64
      '
      'EventType
      '
      Me.EventType.Text = "Event Type"
      '
      'ChannelID
      '
      Me.ChannelID.Text = "Channel ID"
      '
      'DateTime
      '
      Me.DateTime.Text = "Date/Time"
      '
      'Description
      '
      Me.Description.Text = "Description"
      Me.Description.Width = 224
      '
      'mnuMain
      '
      Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem, Me.StopToolStripMenuItem, Me.viewToolStripMenuItem, Me.toolsToolStripMenuItem, Me.ConfiguraitonToolStripMenuItem, Me.FileEnumerationServiceToolStripMenuItem1, Me.helpToolStripMenuItem, Me.ExitToolStripMenuItem1})
      Me.mnuMain.Location = New System.Drawing.Point(0, 0)
      Me.mnuMain.Name = "mnuMain"
      Me.mnuMain.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
      Me.mnuMain.Size = New System.Drawing.Size(639, 24)
      Me.mnuMain.TabIndex = 5
      Me.mnuMain.Text = "menuStrip1"
      '
      'StartToolStripMenuItem
      '
      Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
      Me.StartToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
      Me.StartToolStripMenuItem.Text = "&Start"
      '
      'StopToolStripMenuItem
      '
      Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
      Me.StopToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
      Me.StopToolStripMenuItem.Text = "Sto&p"
      '
      'viewToolStripMenuItem
      '
      Me.viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.clearLogsToolStripMenuItem, Me.toolStripSeparator2, Me.displayLogsToolStripMenuItem})
      Me.viewToolStripMenuItem.Name = "viewToolStripMenuItem"
      Me.viewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me.viewToolStripMenuItem.Text = "&View"
      '
      'clearLogsToolStripMenuItem
      '
      Me.clearLogsToolStripMenuItem.Name = "clearLogsToolStripMenuItem"
      Me.clearLogsToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
      Me.clearLogsToolStripMenuItem.Text = "&Clear Logs"
      '
      'toolStripSeparator2
      '
      Me.toolStripSeparator2.Name = "toolStripSeparator2"
      Me.toolStripSeparator2.Size = New System.Drawing.Size(137, 6)
      '
      'displayLogsToolStripMenuItem
      '
      Me.displayLogsToolStripMenuItem.Checked = True
      Me.displayLogsToolStripMenuItem.CheckOnClick = True
      Me.displayLogsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
      Me.displayLogsToolStripMenuItem.Name = "displayLogsToolStripMenuItem"
      Me.displayLogsToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
      Me.displayLogsToolStripMenuItem.Text = "&Display Logs"
      '
      'toolsToolStripMenuItem
      '
      Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearCacheToolStripMenuItem, Me.InteractiveRequeststoolStripMenuItem, Me.InteractiveResponsestoolStripMenuItem3})
      Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
      Me.toolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
      Me.toolsToolStripMenuItem.Text = "&Tools"
      '
      'ClearCacheToolStripMenuItem
      '
      Me.ClearCacheToolStripMenuItem.Name = "ClearCacheToolStripMenuItem"
      Me.ClearCacheToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
      Me.ClearCacheToolStripMenuItem.Text = "C&lear Server Cache"
      '
      'InteractiveRequeststoolStripMenuItem
      '
      Me.InteractiveRequeststoolStripMenuItem.Name = "InteractiveRequeststoolStripMenuItem"
      Me.InteractiveRequeststoolStripMenuItem.Size = New System.Drawing.Size(248, 22)
      Me.InteractiveRequeststoolStripMenuItem.Text = "Interactive Requests Handling..."
      '
      'InteractiveResponsestoolStripMenuItem3
      '
      Me.InteractiveResponsestoolStripMenuItem3.Name = "InteractiveResponsestoolStripMenuItem3"
      Me.InteractiveResponsestoolStripMenuItem3.Size = New System.Drawing.Size(248, 22)
      Me.InteractiveResponsestoolStripMenuItem3.Text = "Interactive Responses Handling..."
      '
      'ConfiguraitonToolStripMenuItem
      '
      Me.ConfiguraitonToolStripMenuItem.Name = "ConfiguraitonToolStripMenuItem"
      Me.ConfiguraitonToolStripMenuItem.Size = New System.Drawing.Size(102, 20)
      Me.ConfiguraitonToolStripMenuItem.Text = "&Configuration..."
      '
      'FileEnumerationServiceToolStripMenuItem1
      '
      Me.FileEnumerationServiceToolStripMenuItem1.Name = "FileEnumerationServiceToolStripMenuItem1"
      Me.FileEnumerationServiceToolStripMenuItem1.Size = New System.Drawing.Size(177, 20)
      Me.FileEnumerationServiceToolStripMenuItem1.Text = "&Images Enumeration Service..."
      '
      'helpToolStripMenuItem
      '
      Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem, Me.howToToolStripMenuItem})
      Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
      Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me.helpToolStripMenuItem.Text = "&Help"
      '
      'aboutToolStripMenuItem
      '
      Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
      Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
      Me.aboutToolStripMenuItem.Text = "&About"
      '
      'howToToolStripMenuItem
      '
      Me.howToToolStripMenuItem.Name = "howToToolStripMenuItem"
      Me.howToToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
      Me.howToToolStripMenuItem.Text = "How To"
      '
      'ExitToolStripMenuItem1
      '
      Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
      Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
      Me.ExitToolStripMenuItem1.Text = "&Exit"
      '
      'MainForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(643, 513)
      Me.Controls.Add(Me.lstvwEventLog)
      Me.Controls.Add(Me.mnuMain)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MainMenuStrip = Me.mnuMain
      Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.Name = "MainForm"
      Me.Padding = New System.Windows.Forms.Padding(0, 0, 4, 4)
      Me.Text = "JPIP Server Demo"
      Me.mnuMain.ResumeLayout(False)
      Me.mnuMain.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

      Private lstvwEventLog As System.Windows.Forms.ListView
      Private ServerName As System.Windows.Forms.ColumnHeader
      Private ServerIPAddress As System.Windows.Forms.ColumnHeader
      Private ServerPort As System.Windows.Forms.ColumnHeader
      Private ClientIPAddress As System.Windows.Forms.ColumnHeader
      Private ClientPort As System.Windows.Forms.ColumnHeader
      Private EventType As System.Windows.Forms.ColumnHeader
      Private Description As System.Windows.Forms.ColumnHeader
      Private ChannelID As System.Windows.Forms.ColumnHeader
      Private DateTime As System.Windows.Forms.ColumnHeader
      Private mnuMain As System.Windows.Forms.MenuStrip
      Private viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents clearLogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents displayLogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents ClearCacheToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents InteractiveRequeststoolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents InteractiveResponsestoolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents howToToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents StartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents StopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ConfiguraitonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents FileEnumerationServiceToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
   End Class


