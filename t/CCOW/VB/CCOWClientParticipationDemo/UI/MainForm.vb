' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Demos
Imports CCOWClientParticipationDemo.UI
Imports CCOWClientParticipationDemo.CCOW
Imports System.Diagnostics
Imports Leadtools.Ccow
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports System.Collections.Specialized
Imports System.Threading
#If LEADTOOLS_V19_OR_LATER Then
Imports System.Linq
Imports Leadtools.Ccow.Server
#End If '#If LEADTOOLS_V19_OR_LATER

Namespace CCOWClientParticipationDemo
   ''' <summary>
   ''' Summary description for MainForm.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private components As IContainer
      Private statusStrip1 As StatusStrip
      Private toolStripStatusLabelLink As ToolStripStatusLabel
      Private menuStrip1 As MenuStrip
      Private WithEvents fileToolStripMenuItem As ToolStripMenuItem
      Private WithEvents exitToolStripMenuItem As ToolStripMenuItem
      Private WithEvents contextToolStripMenuItem As ToolStripMenuItem
      Private toolTip As ToolTip
      Private WithEvents suspendToolStripMenuItem As ToolStripMenuItem
      Private WithEvents logoutToolStripMenuItem As ToolStripMenuItem
      Private toolStripMenuItem2 As ToolStripSeparator
      Private _Context As ClientContext = Nothing
      Private toolStripStatusLabelUser As ToolStripStatusLabel
      Private WithEvents listViewPatients As ListView
      Private columnHeader1 As ColumnHeader
      Private columnHeader2 As ColumnHeader
      Private columnHeader3 As ColumnHeader
      Private columnHeader4 As ColumnHeader
      Private _LoggedIn As Boolean = False
      Private _NewPatientId As String = String.Empty
      Private _NewUser As String = String.Empty
      Private WithEvents logOffAllToolStripMenuItem As ToolStripMenuItem
      Private _UpdateContext As Boolean = True
      Private WithEvents logOnToolStripMenuItem As ToolStripMenuItem
      Private toolStripMenuItem3 As ToolStripSeparator
      Private _LogOff As Boolean = False
      Private Shared _ActiveScenario As ActiveScenario
      Private Shared _CCOWApplication As CCOWApplication
      Private _AppOnlyLogin As Boolean = False
      Private _CurrentUser As String = String.Empty
      Private failedToVerify As Boolean

      '
      ' Determines if the application is started as a user link participant.  If this is true the application
      ' syncs with user and patient link.  If false it is only a patient linked application.
      '
      Public Shared UserLink As Boolean = False
      Private splitContainer1 As SplitContainer
      Private WithEvents resumeToolStripMenuItem As ToolStripMenuItem
      Private textBoxHelp As TextBox
      Private label1 As Label
      Public Shared Dashboard As Boolean = False
      Private panelInfo As Panel
      Private pictureBoxStatus As PictureBox
      Private labelApplicationName As Label
      Private listViewContext As ListView
      Private label2 As Label
      Private columnHeader5 As ColumnHeader
      Private columnHeader6 As ColumnHeader
      Private label3 As Label
      Private splitter1 As Splitter
      Private panel1 As Panel
      Private splitContainer2 As SplitContainer
      Private richTextBoxLog As RichTextBox
      Private label4 As Label
      Private checkBoxShowPing As CheckBox
      Private panel2 As Panel
      Private Shared _HiliteColor As Nullable(Of Color) = Nothing

      <DllImport("user32.dll")> _
      Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
      End Function

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then

            If Not components Is Nothing Then
               components.Dispose()
            End If
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
         Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
         Me.toolStripStatusLabelLink = New System.Windows.Forms.ToolStripStatusLabel()
         Me.toolStripStatusLabelUser = New System.Windows.Forms.ToolStripStatusLabel()
         Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
         Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.logOnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
         Me.logoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.logOffAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
         Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.contextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.suspendToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.resumeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolTip = New System.Windows.Forms.ToolTip(Me.components)
         Me.listViewPatients = New System.Windows.Forms.ListView()
         Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader3 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader4 = New System.Windows.Forms.ColumnHeader()
         Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
         Me.label3 = New System.Windows.Forms.Label()
         Me.textBoxHelp = New System.Windows.Forms.TextBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.listViewContext = New System.Windows.Forms.ListView()
         Me.columnHeader5 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader6 = New System.Windows.Forms.ColumnHeader()
         Me.label2 = New System.Windows.Forms.Label()
         Me.panelInfo = New System.Windows.Forms.Panel()
         Me.labelApplicationName = New System.Windows.Forms.Label()
         Me.pictureBoxStatus = New System.Windows.Forms.PictureBox()
         Me.splitter1 = New System.Windows.Forms.Splitter()
         Me.panel1 = New System.Windows.Forms.Panel()
         Me.splitContainer2 = New System.Windows.Forms.SplitContainer()
         Me.richTextBoxLog = New System.Windows.Forms.RichTextBox()
         Me.panel2 = New System.Windows.Forms.Panel()
         Me.label4 = New System.Windows.Forms.Label()
         Me.checkBoxShowPing = New System.Windows.Forms.CheckBox()
         Me.statusStrip1.SuspendLayout()
         Me.menuStrip1.SuspendLayout()
         Me.splitContainer1.Panel1.SuspendLayout()
         Me.splitContainer1.Panel2.SuspendLayout()
         Me.splitContainer1.SuspendLayout()
         Me.panelInfo.SuspendLayout()
         CType(Me.pictureBoxStatus, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.panel1.SuspendLayout()
         Me.splitContainer2.Panel1.SuspendLayout()
         Me.splitContainer2.Panel2.SuspendLayout()
         Me.splitContainer2.SuspendLayout()
         Me.panel2.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' statusStrip1
         ' 
         Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabelLink, Me.toolStripStatusLabelUser})
         Me.statusStrip1.Location = New System.Drawing.Point(0, 583)
         Me.statusStrip1.Name = "statusStrip1"
         Me.statusStrip1.ShowItemToolTips = True
         Me.statusStrip1.Size = New System.Drawing.Size(921, 22)
         Me.statusStrip1.TabIndex = 1
         Me.statusStrip1.Text = "statusStrip1"
         ' 
         ' toolStripStatusLabelLink
         ' 
         Me.toolStripStatusLabelLink.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
         Me.toolStripStatusLabelLink.Name = "toolStripStatusLabelLink"
         Me.toolStripStatusLabelLink.Size = New System.Drawing.Size(902, 17)
         Me.toolStripStatusLabelLink.Spring = True
         Me.toolStripStatusLabelLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' toolStripStatusLabelUser
         ' 
         Me.toolStripStatusLabelUser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
         Me.toolStripStatusLabelUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
         Me.toolStripStatusLabelUser.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
         Me.toolStripStatusLabelUser.Image = My.Resources.user
         Me.toolStripStatusLabelUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
         Me.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser"
         Me.toolStripStatusLabelUser.Size = New System.Drawing.Size(4, 17)
         ' 
         ' menuStrip1
         ' 
         Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.contextToolStripMenuItem})
         Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
         Me.menuStrip1.Name = "menuStrip1"
         Me.menuStrip1.Size = New System.Drawing.Size(921, 24)
         Me.menuStrip1.TabIndex = 2
         Me.menuStrip1.Text = "menuStrip1"
         ' 
         ' fileToolStripMenuItem
         ' 
         Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.logOnToolStripMenuItem, Me.toolStripMenuItem3, Me.logoutToolStripMenuItem, Me.logOffAllToolStripMenuItem, Me.toolStripMenuItem2, Me.exitToolStripMenuItem})
         Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
         Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
         Me.fileToolStripMenuItem.Text = "&File"
         '			Me.fileToolStripMenuItem.MouseHover += New System.EventHandler(Me.MenuItem_MouseHover);
         ' 
         ' logOnToolStripMenuItem
         ' 
         Me.logOnToolStripMenuItem.Name = "logOnToolStripMenuItem"
         Me.logOnToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
         Me.logOnToolStripMenuItem.Text = "Log-On"
         '			Me.logOnToolStripMenuItem.MouseHover += New System.EventHandler(Me.MenuItem_MouseHover);
         '			Me.logOnToolStripMenuItem.Click += New System.EventHandler(Me.logOnToolStripMenuItem_Click);
         ' 
         ' toolStripMenuItem3
         ' 
         Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
         Me.toolStripMenuItem3.Size = New System.Drawing.Size(130, 6)
         ' 
         ' logoutToolStripMenuItem
         ' 
         Me.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem"
         Me.logoutToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
         Me.logoutToolStripMenuItem.Text = "&Log-Off"
         '			Me.logoutToolStripMenuItem.MouseHover += New System.EventHandler(Me.MenuItem_MouseHover);
         '			Me.logoutToolStripMenuItem.Click += New System.EventHandler(Me.logoutToolStripMenuItem_Click);
         ' 
         ' logOffAllToolStripMenuItem
         ' 
         Me.logOffAllToolStripMenuItem.Name = "logOffAllToolStripMenuItem"
         Me.logOffAllToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
         Me.logOffAllToolStripMenuItem.Text = "&Log-Off All"
         '			Me.logOffAllToolStripMenuItem.MouseHover += New System.EventHandler(Me.MenuItem_MouseHover);
         '			Me.logOffAllToolStripMenuItem.Click += New System.EventHandler(Me.logOffAllToolStripMenuItem_Click);
         ' 
         ' toolStripMenuItem2
         ' 
         Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
         Me.toolStripMenuItem2.Size = New System.Drawing.Size(130, 6)
         ' 
         ' exitToolStripMenuItem
         ' 
         Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
         Me.exitToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
         Me.exitToolStripMenuItem.Text = "&Exit"
         '			Me.exitToolStripMenuItem.MouseHover += New System.EventHandler(Me.MenuItem_MouseHover);
         '			Me.exitToolStripMenuItem.Click += New System.EventHandler(Me.exitToolStripMenuItem_Click);
         ' 
         ' contextToolStripMenuItem
         ' 
         Me.contextToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.suspendToolStripMenuItem, Me.resumeToolStripMenuItem})
         Me.contextToolStripMenuItem.Name = "contextToolStripMenuItem"
         Me.contextToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
         Me.contextToolStripMenuItem.Text = "&Context"
         '			Me.contextToolStripMenuItem.MouseHover += New System.EventHandler(Me.MenuItem_MouseHover);
         ' 
         ' suspendToolStripMenuItem
         ' 
         Me.suspendToolStripMenuItem.Name = "suspendToolStripMenuItem"
         Me.suspendToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
         Me.suspendToolStripMenuItem.Text = "&Suspend"
         '			Me.suspendToolStripMenuItem.MouseHover += New System.EventHandler(Me.MenuItem_MouseHover);
         '			Me.suspendToolStripMenuItem.Click += New System.EventHandler(Me.suspendToolStripMenuItem_Click);
         ' 
         ' resumeToolStripMenuItem
         ' 
         Me.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem"
         Me.resumeToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
         Me.resumeToolStripMenuItem.Text = "&Resume"
         '			Me.resumeToolStripMenuItem.MouseHover += New System.EventHandler(Me.MenuItem_MouseHover);
         '			Me.resumeToolStripMenuItem.Click += New System.EventHandler(Me.resumeToolStripMenuItem_Click);
         ' 
         ' toolTip
         ' 
         Me.toolTip.IsBalloon = True
         Me.toolTip.ShowAlways = True
         Me.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
         ' 
         ' listViewPatients
         ' 
         Me.listViewPatients.BackColor = System.Drawing.SystemColors.Window
         Me.listViewPatients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4})
         Me.listViewPatients.Dock = System.Windows.Forms.DockStyle.Fill
         Me.listViewPatients.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.listViewPatients.FullRowSelect = True
         Me.listViewPatients.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me.listViewPatients.HideSelection = False
         Me.listViewPatients.Location = New System.Drawing.Point(0, 13)
         Me.listViewPatients.MultiSelect = False
         Me.listViewPatients.Name = "listViewPatients"
         Me.listViewPatients.Size = New System.Drawing.Size(709, 198)
         Me.listViewPatients.TabIndex = 3
         Me.listViewPatients.UseCompatibleStateImageBehavior = False
         Me.listViewPatients.View = System.Windows.Forms.View.Details
         '			Me.listViewPatients.Resize += New System.EventHandler(Me.listViewPatients_Resize);
         '			Me.listViewPatients.SelectedIndexChanged += New System.EventHandler(Me.listViewPatients_SelectedIndexChanged);
         ' 
         ' columnHeader1
         ' 
         Me.columnHeader1.Text = "Id"
         ' 
         ' columnHeader2
         ' 
         Me.columnHeader2.Text = "Name"
         ' 
         ' columnHeader3
         ' 
         Me.columnHeader3.Text = "BirthDate"
         Me.columnHeader3.Width = 100
         ' 
         ' columnHeader4
         ' 
         Me.columnHeader4.Text = "Sex"
         ' 
         ' splitContainer1
         ' 
         Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top
         Me.splitContainer1.Location = New System.Drawing.Point(0, 80)
         Me.splitContainer1.Name = "splitContainer1"
         ' 
         ' splitContainer1.Panel1
         ' 
         Me.splitContainer1.Panel1.Controls.Add(Me.listViewPatients)
         Me.splitContainer1.Panel1.Controls.Add(Me.label3)
         ' 
         ' splitContainer1.Panel2
         ' 
         Me.splitContainer1.Panel2.Controls.Add(Me.textBoxHelp)
         Me.splitContainer1.Panel2.Controls.Add(Me.label1)
         Me.splitContainer1.Size = New System.Drawing.Size(921, 211)
         Me.splitContainer1.SplitterDistance = 709
         Me.splitContainer1.TabIndex = 4
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Dock = System.Windows.Forms.DockStyle.Top
         Me.label3.Location = New System.Drawing.Point(0, 0)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(356, 13)
         Me.label3.TabIndex = 4
         Me.label3.Text = "Patients (Click on a patient to synchronize with other context applications):"
         ' 
         ' textBoxHelp
         ' 
         Me.textBoxHelp.Dock = System.Windows.Forms.DockStyle.Fill
         Me.textBoxHelp.Location = New System.Drawing.Point(0, 13)
         Me.textBoxHelp.Multiline = True
         Me.textBoxHelp.Name = "textBoxHelp"
         Me.textBoxHelp.ReadOnly = True
         Me.textBoxHelp.Size = New System.Drawing.Size(208, 198)
         Me.textBoxHelp.TabIndex = 2
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Dock = System.Windows.Forms.DockStyle.Top
         Me.label1.Location = New System.Drawing.Point(0, 0)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(32, 13)
         Me.label1.TabIndex = 1
         Me.label1.Text = "Help:"
         ' 
         ' listViewContext
         ' 
         Me.listViewContext.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader5, Me.columnHeader6})
         Me.listViewContext.Dock = System.Windows.Forms.DockStyle.Fill
         Me.listViewContext.Location = New System.Drawing.Point(0, 13)
         Me.listViewContext.Name = "listViewContext"
         Me.listViewContext.Size = New System.Drawing.Size(921, 131)
         Me.listViewContext.TabIndex = 1
         Me.listViewContext.UseCompatibleStateImageBehavior = False
         Me.listViewContext.View = System.Windows.Forms.View.Details
         ' 
         ' columnHeader5
         ' 
         Me.columnHeader5.Text = "Name"
         ' 
         ' columnHeader6
         ' 
         Me.columnHeader6.Text = "Value"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Dock = System.Windows.Forms.DockStyle.Top
         Me.label2.Location = New System.Drawing.Point(0, 0)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(83, 13)
         Me.label2.TabIndex = 0
         Me.label2.Text = "Current Context:"
         ' 
         ' panelInfo
         ' 
         Me.panelInfo.Controls.Add(Me.labelApplicationName)
         Me.panelInfo.Controls.Add(Me.pictureBoxStatus)
         Me.panelInfo.Dock = System.Windows.Forms.DockStyle.Top
         Me.panelInfo.Location = New System.Drawing.Point(0, 24)
         Me.panelInfo.Name = "panelInfo"
         Me.panelInfo.Size = New System.Drawing.Size(921, 56)
         Me.panelInfo.TabIndex = 5
         ' 
         ' labelApplicationName
         ' 
         Me.labelApplicationName.AutoSize = True
         Me.labelApplicationName.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.labelApplicationName.ForeColor = System.Drawing.Color.White
         Me.labelApplicationName.Location = New System.Drawing.Point(4, 10)
         Me.labelApplicationName.Name = "labelApplicationName"
         Me.labelApplicationName.Size = New System.Drawing.Size(101, 36)
         Me.labelApplicationName.TabIndex = 1
         Me.labelApplicationName.Text = "label2"
         ' 
         ' pictureBoxStatus
         ' 
         Me.pictureBoxStatus.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.pictureBoxStatus.Image = My.Resources.Broken
         Me.pictureBoxStatus.Location = New System.Drawing.Point(861, 4)
         Me.pictureBoxStatus.Name = "pictureBoxStatus"
         Me.pictureBoxStatus.Size = New System.Drawing.Size(48, 48)
         Me.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
         Me.pictureBoxStatus.TabIndex = 0
         Me.pictureBoxStatus.TabStop = False
         ' 
         ' splitter1
         ' 
         Me.splitter1.Dock = System.Windows.Forms.DockStyle.Top
         Me.splitter1.Location = New System.Drawing.Point(0, 291)
         Me.splitter1.Name = "splitter1"
         Me.splitter1.Size = New System.Drawing.Size(921, 3)
         Me.splitter1.TabIndex = 6
         Me.splitter1.TabStop = False
         ' 
         ' panel1
         ' 
         Me.panel1.Controls.Add(Me.splitContainer2)
         Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.panel1.Location = New System.Drawing.Point(0, 294)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(921, 289)
         Me.panel1.TabIndex = 7
         ' 
         ' splitContainer2
         ' 
         Me.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
         Me.splitContainer2.Location = New System.Drawing.Point(0, 0)
         Me.splitContainer2.Name = "splitContainer2"
         Me.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
         ' 
         ' splitContainer2.Panel1
         ' 
         Me.splitContainer2.Panel1.Controls.Add(Me.listViewContext)
         Me.splitContainer2.Panel1.Controls.Add(Me.label2)
         ' 
         ' splitContainer2.Panel2
         ' 
         Me.splitContainer2.Panel2.Controls.Add(Me.richTextBoxLog)
         Me.splitContainer2.Panel2.Controls.Add(Me.panel2)
         Me.splitContainer2.Size = New System.Drawing.Size(921, 289)
         Me.splitContainer2.SplitterDistance = 144
         Me.splitContainer2.TabIndex = 2
         ' 
         ' richTextBoxLog
         ' 
         Me.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill
         Me.richTextBoxLog.Location = New System.Drawing.Point(0, 18)
         Me.richTextBoxLog.Name = "richTextBoxLog"
         Me.richTextBoxLog.Size = New System.Drawing.Size(921, 123)
         Me.richTextBoxLog.TabIndex = 1
         Me.richTextBoxLog.Text = ""
         ' 
         ' panel2
         ' 
         Me.panel2.Controls.Add(Me.label4)
         Me.panel2.Controls.Add(Me.checkBoxShowPing)
         Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
         Me.panel2.Location = New System.Drawing.Point(0, 0)
         Me.panel2.Name = "panel2"
         Me.panel2.Size = New System.Drawing.Size(921, 18)
         Me.panel2.TabIndex = 3
         ' 
         ' label4
         ' 
         Me.label4.Dock = System.Windows.Forms.DockStyle.Left
         Me.label4.Location = New System.Drawing.Point(0, 0)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(34, 18)
         Me.label4.TabIndex = 0
         Me.label4.Text = "Log:"
         ' 
         ' checkBoxShowPing
         ' 
         Me.checkBoxShowPing.AutoSize = True
         Me.checkBoxShowPing.Location = New System.Drawing.Point(40, -1)
         Me.checkBoxShowPing.Name = "checkBoxShowPing"
         Me.checkBoxShowPing.Size = New System.Drawing.Size(98, 17)
         Me.checkBoxShowPing.TabIndex = 2
         Me.checkBoxShowPing.Text = "Show Ping Log"
         Me.checkBoxShowPing.UseVisualStyleBackColor = True
         ' 
         ' MainForm
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(921, 605)
         Me.Controls.Add(Me.panel1)
         Me.Controls.Add(Me.splitter1)
         Me.Controls.Add(Me.splitContainer1)
         Me.Controls.Add(Me.statusStrip1)
         Me.Controls.Add(Me.panelInfo)
         Me.Controls.Add(Me.menuStrip1)
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MainMenuStrip = Me.menuStrip1
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "XXX SDI Demo"
         'Me.Load += New System.EventHandler(AddressOf Me.MainForm_Load);
         '			Me.Shown += New System.EventHandler(Me.MainForm_Shown);
         '			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.MainForm_FormClosing);
         Me.statusStrip1.ResumeLayout(False)
         Me.statusStrip1.PerformLayout()
         Me.menuStrip1.ResumeLayout(False)
         Me.menuStrip1.PerformLayout()
         Me.splitContainer1.Panel1.ResumeLayout(False)
         Me.splitContainer1.Panel1.PerformLayout()
         Me.splitContainer1.Panel2.ResumeLayout(False)
         Me.splitContainer1.Panel2.PerformLayout()
         Me.splitContainer1.ResumeLayout(False)
         Me.panelInfo.ResumeLayout(False)
         Me.panelInfo.PerformLayout()
         CType(Me.pictureBoxStatus, System.ComponentModel.ISupportInitialize).EndInit()
         Me.panel1.ResumeLayout(False)
         Me.splitContainer2.Panel1.ResumeLayout(False)
         Me.splitContainer2.Panel1.PerformLayout()
         Me.splitContainer2.Panel2.ResumeLayout(False)
         Me.splitContainer2.ResumeLayout(False)
         Me.panel2.ResumeLayout(False)
         Me.panel2.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
#End Region

      Public Const WM_USER As Integer = &H400
      Public Const WM_GETID As Integer = WM_USER + 1

      <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
      Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInt32, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
      End Function

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Public Shared Sub Main(ByVal args As String())

         If Not Support.SetLicense() Then
            Return
         End If


         If RasterSupport.IsLocked(RasterSupportType.Ccow) Then
            MessageBox.Show("CCOW Support is locked!  Application will exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
         End If

         '
         ' See if multiple intances are running
         '
         Dim processes As Process() = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)

         If Not processes Is Nothing AndAlso processes.Length > 3 Then
            Dim message As String = "Only three instances of this application are allowed to run." & vbCrLf & "Application will exit."

            Messager.ShowInformation(Nothing, message)
            Application.Exit()
            Return
         Else
            _ActiveScenario = ActiveScenario.Load()

            ReadCommandLine(args)
            If (Not Dashboard) Then
               If Not processes Is Nothing Then
                  Dim current As Process = Process.GetCurrentProcess()
                  Dim indexes As List(Of Integer) = New List(Of Integer)()

                  For Each p As Process In processes
                     If p.Id = current.Id Then
                        Continue For
                     End If

                     Dim i As IntPtr = SendMessage(p.MainWindowHandle, WM_GETID, IntPtr.Zero, IntPtr.Zero)

                     indexes.Add(i.ToInt32())
                  Next p

                  For i As Integer = 0 To 2
                     If indexes.Contains(i) Then
                        Continue For
                     End If

                     MainForm.ApplicationIndex = i
                     Exit For
                  Next i
               End If

               Select Case ApplicationIndex
                  Case 0
                     _HiliteColor = Color.Red
                  Case 1
                     _HiliteColor = Color.Green
                  Case Else
                     _HiliteColor = Color.Blue
               End Select
            End If

            If Not _ActiveScenario Is Nothing AndAlso Not _ActiveScenario.Scenario Is Nothing AndAlso _ActiveScenario.Scenario.Applications.Count > ApplicationIndex Then
               _CCOWApplication = _ActiveScenario.Scenario.Applications(ApplicationIndex)
               MainForm.ApplicationName = _CCOWApplication.Name
               MainForm.Suffix = _CCOWApplication.Suffix
            End If
         End If
         AddHandler Application.ThreadException, AddressOf Application_ThreadException
         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainForm())
      End Sub

      Private Shared Sub Application_ThreadException(ByVal sender As Object, ByVal e As ThreadExceptionEventArgs)
      End Sub

      Private Shared Sub ReadCommandLine(ByVal args As String())
         Dim sQuestion As String = "/?"
         Dim sHelp As String = "/help"
         Dim sLink As String = "/link="
         Dim sDashboard As String = "/dashboard" ' Passed if application launched from the dashboard.
         Dim sColor As String = "/color="
         Dim sIndex As String = "/index="

         For Each s As String In args
            Dim sVal As String = String.Empty

            If (String.Compare(sHelp, s, True) = 0) OrElse (String.Compare(sQuestion, s, True) = 0) Then
               'MessageBox.Show(sHelpInstructions, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
               Return
            ElseIf String.Compare(sDashboard, s, True) = 0 Then
               Dashboard = True
            ElseIf s.StartsWith(sLink, True, Nothing) Then
               sVal = s.Substring(sLink.Length)
               If sVal.ToLower() = "user" Then
                  UserLink = True
               End If
            ElseIf s.StartsWith(sColor, True, Nothing) Then
               sVal = s.Substring(sColor.Length)
               Try
                  _HiliteColor = ColorTranslator.FromHtml(sVal)
               Catch
               End Try
            ElseIf s.StartsWith(sIndex, True, Nothing) Then
               sVal = s.Substring(sIndex.Length)
               Try
                  ApplicationIndex = Convert.ToInt32(sVal)
               Catch
               End Try
            End If
         Next s
      End Sub

      Private Shared _ApplicationName As String = "LEADTOOLS CCOW Desktop"

      Public Shared Property ApplicationName() As String
         Get
            Return _ApplicationName
         End Get
         Set(ByVal value As String)
            _ApplicationName = value
         End Set
      End Property

      Private Shared _Suffix As String = String.Empty

      Public Shared Property Suffix() As String
         Get
            Return _Suffix
         End Get
         Set(ByVal value As String)
            _Suffix = value
         End Set
      End Property

      Private Shared _ApplicationIndex As Integer = 0

      Public Shared Property ApplicationIndex() As Integer
         Get
            Return _ApplicationIndex
         End Get
         Set(ByVal value As Integer)
            _ApplicationIndex = value
         End Set
      End Property

      Protected Overrides Sub WndProc(ByRef m As Message)
         MyBase.WndProc(m)

         If m.Msg = WM_GETID Then
            m.Result = CType(ApplicationIndex, IntPtr)
         End If
      End Sub

      ''' <summary>
      ''' Initialize the Application.
      ''' </summary>
      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Messager.Caption = "VB.NET CCOW Context Participant"
         Text = Messager.Caption
         SetCCowIcon(ContextState.Broken)

         If Not _HiliteColor Is Nothing Then
            panelInfo.BackColor = _HiliteColor.Value
            toolStripStatusLabelUser.ForeColor = _HiliteColor.Value
         End If

         Dim width As Integer = Convert.ToInt32(listViewPatients.ClientRectangle.Width / listViewPatients.Columns.Count)

         For Each column As ColumnHeader In listViewPatients.Columns
            column.Width = width
         Next column

         width = Convert.ToInt32(listViewContext.ClientRectangle.Width / listViewContext.Columns.Count)
         For Each column As ColumnHeader In listViewContext.Columns
            column.Width = width
         Next column

         labelApplicationName.Text = MainForm.ApplicationName
      End Sub

      Private Sub SetCCowIcon(ByVal state As ContextState)
         Select Case state
            Case ContextState.Broken
               pictureBoxStatus.Image = My.Resources.Broken
            Case ContextState.Changing
               pictureBoxStatus.Image = My.Resources.Changing
            Case ContextState.Linked
               pictureBoxStatus.Image = My.Resources.Linked
         End Select
      End Sub

      ''' <summary>
      ''' Shutdown
      ''' </summary>
      Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
         Close()
      End Sub

      ''' <summary>
      ''' show the about dialog
      ''' </summary>
      Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs)
         CType(New AboutDialog("CCOW Desktop"), AboutDialog).ShowDialog(Me)
      End Sub

      Private Sub EnableAndVisibleMenu(ByVal menu As MenuItem, ByVal value As Boolean)
         menu.Enabled = value
         menu.Visible = value
      End Sub


      Private Sub SecureBind()
         _Context.SecureBind(failedToVerify)
      End Sub
      Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
         Dim dialogInfo As InfoDialog = New InfoDialog(Me)
         Dim old As Exception = Nothing

         dialogInfo.Title = "Joining Common Context"
         dialogInfo.Description = "Attempting to join common context"
         Try
            _Context = New ClientContext(ApplicationName, Me)
            AddHandler _Context.Terminated, AddressOf Context_Terminated
            AddHandler _Context.ChangesAccepted, AddressOf Context_ChangesAccepted
            AddHandler _Context.ChangesCanceled, AddressOf Context_ChangesCanceled
            AddHandler _Context.ChangesPending, AddressOf Context_ChangesPending
            AddHandler _Context.LeftContext, AddressOf Context_LeftContext
            AddHandler _Context.JoinedContext, AddressOf Context_JoinedContext
            AddHandler _Context.Pinged, AddressOf Context_Pinged

            If dialogInfo.ShowDialog(New MethodInvoker(AddressOf JoinContext)) = System.Windows.Forms.DialogResult.OK Then
               SetCCowIcon(ContextState.Linked)
               ShowContext()

               Try
                  dialogInfo.Title = "Secure Binding"
                  dialogInfo.Description = "Securely binding to context manager"
                  dialogInfo.ShowDialog(New MethodInvoker(AddressOf SecureBind))
                  If Not dialogInfo.Exception Is Nothing Then
                     Throw dialogInfo.Exception
                  End If

               Catch exception As Exception
                  old = exception
                  Messager.ShowError(Me, exception)
               End Try

               If MainForm.Dashboard Then
                  DoDashboard(True, failedToVerify)
               Else
                  DoApplicationLogin()
                  If _LoggedIn Then
                     _AppOnlyLogin = True
                     _Context.SetFilter("Patient")
                     SetLinkDisplay(My.Resources.PatientLink)
                     ShowContext()
                  End If
               End If
            Else
               If Not dialogInfo.Exception Is Nothing Then
                  Throw dialogInfo.Exception
               End If
            End If

            If _Context.Joined Then
               InitializePatients()
               If _Context.LastCoupon <> 0 Then
                  CheckPatient(_Context.LastCoupon, False)
                  SelectNewPatient()
               End If
            End If
         Catch ex As Exception
            If Not old Is Nothing AndAlso old.Message <> ex.Message Then
               Dim message As String = ex.Message
               Dim [exit] As Boolean = False

               If ex.Message.ToLower().Contains("not allowed to participate") Then
                  message &= vbCrLf & vbCrLf & "Please configure the CCOW server to allow this application (" & ApplicationName & ") "
                  message &= "to join the common context."
               End If

               If ex.Message.Contains("already joined") Then
                  message &= vbCrLf & vbCrLf & "Application will exit."
                  [exit] = True
               End If
               If ex.Message.Contains("A signature could not be authenticated") Then
                  MainForm.UserLink = False
                  Try
                     If Not _Context Is Nothing Then
                        _Context.SetFilter("Patient")
                     End If
                  Catch exc As Exception
                     Messager.ShowError(Me, exc.Message)
                  End Try
               End If

               If (Not IsDisposed) Then
                  '
                  ' Load patients if we have joined the context
                  '
                  If _Context.Joined Then
                     If listViewPatients.Items.Count = 0 Then
                        InitializePatients()
                     End If
                  End If
                  Messager.ShowError(Me, message)
               End If

               If [exit] Then
                  Close()
               End If
            Else
               If _Context.Joined Then
                  If listViewPatients.Items.Count = 0 Then
                     InitializePatients()
                  End If
               End If
            End If
         End Try
         contextToolStripMenuItem.Enabled = Not _Context Is Nothing
         If MainForm.UserLink Then
            SetLinkDisplay(My.Resources.UserPatientLink)
         Else
            SetLinkDisplay(My.Resources.PatientLink)
         End If
      End Sub

      Private Sub DoDashboard(ByVal showInfo As Boolean, ByVal failedToVerify As Boolean)
         If MainForm.UserLink Then
            If (Not _Context.IsUserContextSet()) Then
               Dim authApp As Process() = Process.GetProcessesByName("VBCCOWAuthenticationDemo")

               If authApp.Length = 1 Then
                  Dim result As DialogResult

                  result = Messager.Show(Me, "The user context is not currently set.  If another application has " _
                                         & "logged in with a user unknown to this application, close this application and launch " _
                                         & "without enabling SSO.  Select 'No', if you want to log in with the VBCCOWAuthentication demo." _
                                         & vbCrLf & vbCrLf _
                                         & "Would you like to close this application?", MessageBoxIcon.Stop, MessageBoxButtons.YesNo)
                  If result = DialogResult.No Then
                     SetForegroundWindow(authApp(0).MainWindowHandle)
                  Else
                     Close()
                     Environment.Exit(0)
                  End If
               Else
                  If Messager.Show(Me, "This application cannot continue.  The application was launched from the CCOW " _
                                   & " Dashboard and requires that a user be set in the context.  If another application " _
                                   & "has logged in with a user unknown to this application, select 'No' to close this application. Then, relaunch " _
                                   & "from the dashboard without enabling SSO." _
                                   & vbCrLf & vbCrLf _
                                   & "Would you like to launch the VBCCOWAuthenticationDemo?", MessageBoxIcon.Asterisk, MessageBoxButtons.YesNo) = DialogResult.Yes Then
                     CCOWUtils.LauchAuthApplication(Nothing)
                  End If
                  Close()
                  Environment.Exit(0)
               End If
            Else
               '
               ' The user context is set, therefore we need to check to see if we can logon this specific user
               '
               Dim user As String = _Context.GetCurrentUser()

               If (Not String.IsNullOrEmpty(user)) Then
                  LogInApplication(user)
                  SetLinkDisplay(My.Resources.UserPatientLink)
               End If
            End If
         Else
            If showInfo Then
               If Not failedToVerify Then
                  Messager.Show(Me, "This application was launched from the dashboard with user linking disabled. " & _
                                "You will be required to log into the application.  The login  " & _
                                "dialog will appear when this message box is closed.  Once logged in, the application " & _
                                "will only be patient-linked.", MessageBoxIcon.Information, MessageBoxButtons.OK)
               Else
                  Messager.Show(Me, "This application failed to securely bind with the context manager. " _
                                & "You will be required to log into the application.  The login " _
                                & "dialog will appear when this message box is closed.  Once logged in, the application " _
                                & "will only be patient-linked.", MessageBoxIcon.Information, MessageBoxButtons.OK)
               End If
            End If
            DoApplicationLogin()
            If _LoggedIn Then
               '
               ' Only be notified of patient context changes
               '
               _AppOnlyLogin = True
               _Context.SetFilter("Patient")
               SetLinkDisplay(My.Resources.PatientLink)
            End If
         End If
      End Sub

      Private Sub DoApplicationLogin()
         Dim dlgLogin As LoginDialog = New LoginDialog(_CCOWApplication)

         dlgLogin.Text = "Log On: " & MainForm.ApplicationName
         If dlgLogin.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            SetUserInfo(dlgLogin.Username)
            _LoggedIn = True
         Else
            Close()
            Return
         End If
      End Sub

      Private loggingIn As Boolean = False

      Private Sub LogInApplication(ByVal user As String)
         If loggingIn Then
            Return
         End If

         Try
            loggingIn = True
            Dim authData As String = _Context.GetAuthenticationData(user)

            '
            ' If we do not have any authentication data then we need to display a dialog and
            ' let the user log into this application. Once successfully logged in the user auth
            ' data (password) will be added to the authentication repository.
            '
            If String.IsNullOrEmpty(authData) Then
               Dim dlgLogin As LoginDialog = New LoginDialog(_CCOWApplication)

               dlgLogin.Text = "Log On: " & MainForm.ApplicationName
               dlgLogin.Username = user
               dlgLogin.EnableUser = False
               dlgLogin.FirstLogin = True
               If dlgLogin.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                  _Context.SetAuthenticationData(user, dlgLogin.Password)
                  _LoggedIn = True
                  SetUserInfo(user)
               Else
                  Close()
                  Return
               End If
            Else
               SetUserInfo(user)
               _LoggedIn = True
            End If
         Finally
            loggingIn = False
         End Try
      End Sub

      ''' <summary>
      ''' Initializes the patients.  This demo uses a list of predefined patients.  In a production scenario, the
      ''' patient information should be read from a database of some other on site repository.  This examples serves
      ''' as a sample of how to do things, not a representation of best practices.
      ''' </summary>
      Private Sub InitializePatients()
         If Not _CCOWApplication Is Nothing Then
            For Each patient As Patient In _CCOWApplication.Patients
               AddPatient(patient)
            Next patient
         End If
      End Sub

      Private Sub AddPatient(ByVal patient As Patient)
         Dim item As ListViewItem = New ListViewItem(patient.Id)

         item.SubItems.Add(patient.Name)
         If patient.BirthDate.HasValue Then
            item.SubItems.Add(patient.BirthDate.Value.ToShortDateString())
         Else
            item.SubItems.Add(String.Empty)
         End If
         item.SubItems.Add(patient.Sex)
         item.Tag = patient
         listViewPatients.Items.Add(item)
      End Sub

      Private Sub SetUserInfo(ByVal user As String)
         _CurrentUser = user
         toolStripStatusLabelUser.Text = user
         If String.IsNullOrEmpty(user) Then
            _LoggedIn = False
            toolStripStatusLabelUser.DisplayStyle = ToolStripItemDisplayStyle.Text
         Else
            toolStripStatusLabelUser.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
         End If
      End Sub

      Private Sub Context_ChangesCanceled(ByVal sender As Object, ByVal e As ContextEventArgs)
         Log("=> Context Changes Canceled")
         _NewPatientId = String.Empty
         _NewUser = String.Empty
      End Sub

      Private Sub Context_ChangesAccepted(ByVal sender As Object, ByVal e As ContextEventArgs)
         Log("=> Context Changes Accepted")
         If _LogOff Then
            Invoke(New MethodInvoker(AddressOf LogOffUser))
         ElseIf (Not String.IsNullOrEmpty(_NewUser)) AndAlso MainForm.UserLink Then
            Invoke(New Action(Of String)(AddressOf LogInApplication), _NewUser)
         End If

         If (Not loggingIn) Then
            Invoke(New MethodInvoker(AddressOf SelectNewPatient))
            Invoke(New MethodInvoker(AddressOf ShowContext))
         End If
      End Sub

      Private Sub Context_Terminated(ByVal sender As Object, ByVal e As EventArgs)
         Log("=> Context Terminated")
      End Sub

      Private Sub Context_ChangesPending(ByVal sender As Object, ByVal e As ContextEventArgs)
         Log("=> Context Changes Pending")
         If _Context.IsSetting("user", "logon", e.ContextCoupon) Then
            CheckUser(e)
         End If
         CheckPatient(e.ContextCoupon, True)
         e.Decision = "accept"
      End Sub

      Private Sub Context_Pinged(ByVal sender As Object, ByVal e As EventArgs)
         If checkBoxShowPing.Checked Then
            Log("=> Received Ping")
         End If
      End Sub

      Private Sub Context_JoinedContext(ByVal sender As Object, ByVal e As EventArgs)
         Log("=> Successfully Joined Context")
         Log("     Participant Coupon: " & _Context.ParticipantCoupon.ToString())
      End Sub

      Private Sub CheckUser(ByVal e As ContextEventArgs)
         Dim item As ContextItem = New ContextItem("User.Id.logon." & MainForm.Suffix)
         Dim temp As String = _Context.GetItemValue(item, False, e.ContextCoupon)

         _NewUser = String.Empty

         '
         ' Check to see if we are removing the user
         '
         If temp.Length = 0 AndAlso _LoggedIn Then
            _LogOff = True
         Else
            '
            ' A new user has been logged in
            '
            If _CurrentUser.ToLower() <> temp.ToLower() Then
               _NewUser = temp
            End If
         End If
      End Sub

      Private Sub CheckPatient(ByVal ContextCoupon As Integer, ByVal onlyChanges As Boolean)
         Dim item As ContextItem = New ContextItem("Patient.Id.MRN." & MainForm.Suffix)
         Dim temp As String = _Context.GetItemValue(item, onlyChanges, ContextCoupon)

         _NewPatientId = String.Empty
         For Each p As Patient In _CCOWApplication.Patients
            If p.Id.ToLower() = temp.ToLower() Then
               _NewPatientId = temp
               Exit For
            End If
         Next p
      End Sub

      Private Sub Context_LeftContext(ByVal sender As Object, ByVal e As EventArgs)
         SetCCowIcon(ContextState.Broken)
      End Sub

      Private Sub LogOffUser()
         If _LogOff Then
            SetUserInfo(String.Empty)
            _LogOff = False

#If LEADTOOLS_V19_OR_LATER Then
            If CheckPatientDependencies() Then
               Me._Context.Leave()
            End If
#End If
         End If
      End Sub

      Private Sub SelectNewPatient()
         _UpdateContext = False
         Try
            If _NewPatientId = String.Empty Then
               listViewPatients.SelectedItems.Clear()
            Else
               For Each item As ListViewItem In listViewPatients.Items
                  Dim patient As Patient = TryCast(item.Tag, Patient)

                  If patient.Id.ToLower() = _NewPatientId.ToLower() Then
                     item.Selected = True
                     Exit For
                  End If
               Next item
            End If
         Finally
            _UpdateContext = True
         End Try
      End Sub

      Public Sub ShowContext()
         Dim context As NameValueCollection = _Context.GetCurrentContext()

         Monitor.Enter(Me)
         Try
            listViewContext.Items.Clear()
            For Each name As String In context
               Dim item As ListViewItem = listViewContext.Items.Add(name)

               item.SubItems.Add(context(name))
            Next name
         Finally
            Monitor.Exit(Me)
         End Try
      End Sub
      Private Sub LeaveContext()
         _Context.Leave()
      End Sub
      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
         If Not _Context Is Nothing Then
            RemoveHandler _Context.Terminated, AddressOf Context_Terminated
            RemoveHandler _Context.ChangesAccepted, AddressOf Context_ChangesAccepted
            RemoveHandler _Context.ChangesCanceled, AddressOf Context_ChangesCanceled
            RemoveHandler _Context.LeftContext, AddressOf Context_LeftContext
            RemoveHandler _Context.Pinged, AddressOf Context_Pinged
            RemoveHandler _Context.JoinedContext, AddressOf Context_JoinedContext

            If _Context.Joined Then
               Dim dlgInfo As InfoDialog = New InfoDialog(Me)

               dlgInfo.Title = "Leaving Common Context"
               dlgInfo.Description = "Attempting to leave common context"
               Try
                  dlgInfo.ShowDialog(New MethodInvoker(AddressOf LeaveContext))
               Catch ex As Exception
                  Messager.ShowError(Me, ex)
                  e.Cancel = True
               End Try
            End If
         End If
      End Sub

      Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
         Close()
      End Sub

      Private Sub suspendToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles suspendToolStripMenuItem.Click
         Try
            If (Not _Context.Suspended) Then
               _Context.Suspend()
               If _Context.Suspended Then
                  SetCCowIcon(ContextState.Broken)
                  listViewPatients.Enabled = False
               End If
            Else
               Messager.ShowInformation(Me, "This application has already suspended it's participation.  Please resume before trying to suspend.")
            End If
         Catch exception As Exception
            If TypeOf exception Is COMException Then
               '
               ' Check to see if the Context Manager server has terminated.
               '
               If exception.Message.Contains("The RPC server is unavailable") Then
                  Messager.Show(Me, "The Context Management Server was terminated.  The application can no longer access the context and will restart to attempt to rejoin the context.", MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                  Close()
                  CCOWUtils.Restart()
               Else
                  Messager.ShowError(Nothing, exception)
               End If
            Else
               Messager.ShowError(Nothing, exception)
            End If
         End Try
      End Sub

      Private Sub resumeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles resumeToolStripMenuItem.Click
         If _Context.Suspended Then
            _Context.Resume(True)
            If (Not _Context.Suspended) Then
               SetCCowIcon(ContextState.Linked)
               listViewPatients.Enabled = True
               ShowContext()
               CheckPatient(_Context.LastCoupon, False)
               SelectNewPatient()
               If MainForm.UserLink Then
                  Dim user As String = _Context.GetCurrentUser()

                  SetUserInfo(user)
               End If
            End If
         Else
            Messager.ShowInformation(Me, "This application's participation is not suspended. Please, suspend this application before trying to resume.")
         End If
      End Sub

      Private Sub listViewPatients_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles listViewPatients.Resize
         Dim width As Integer = Convert.ToInt32(listViewPatients.ClientRectangle.Width / listViewPatients.Columns.Count)

         For Each column As ColumnHeader In listViewPatients.Columns
            column.Width = width
         Next column
      End Sub

      Private Sub listViewPatients_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listViewPatients.SelectedIndexChanged
         Try
            If listViewPatients.SelectedItems.Count > 0 AndAlso _UpdateContext AndAlso _Context.Joined Then
               Dim patient As Patient = TryCast(listViewPatients.SelectedItems(0).Tag, Patient)
               Dim patientSubject As Subject = New Subject("Patient")
               Dim item As ContextItem = New ContextItem("Patient.Id.MRN." & MainForm.Suffix)

               item.Value = patient.Id
               patientSubject.Items.Add(item)
               _Context.Set(patientSubject)
               ShowContext()
            Else
               If (Not _Context.Joined) Then
                  Log(Color.Red, "Not a member of the context")
                  Log("    Patient context not switched")
               End If
            End If
         Catch exception As Exception
            If TypeOf exception Is COMException Then
               '
               ' Check to see if the Context Manager server has terminated.
               '
               If exception.Message.Contains("The RPC server is unavailable") Then
                  Messager.Show(Me, "The Context Management Server was terminated.  The application can no longer access the context and will restart to attempt to rejoin the context.", MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                  Close()
                  CCOWUtils.Restart()
               Else
                  Messager.ShowError(Nothing, exception)
               End If
            Else
               Messager.ShowError(Nothing, exception)
            End If
         End Try
      End Sub

      Private Sub logoutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles logoutToolStripMenuItem.Click
         Try
            _Context.Leave()
            SetUserInfo(String.Empty)
            listViewContext.Items.Clear()
            _LoggedIn = False
            SetLinkDisplay(String.Empty)
         Catch exception As Exception
            If TypeOf exception Is COMException Then
               '
               ' Check to see if the Context Manager server has terminated.
               '
               If exception.Message.Contains("The RPC server is unavailable") Then
                  Messager.Show(Me, "The Context Management Server was terminated.  The application can no longer access the context and will restart to attempt to rejoin the context.", MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                  Close()
                  CCOWUtils.Restart()
               Else
                  Messager.ShowError(Nothing, exception)
               End If
            Else
               Messager.ShowError(Nothing, exception)
            End If
         End Try
      End Sub

      Private Sub logOffAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles logOffAllToolStripMenuItem.Click
         If (Not _Context.Joined) Then
            Messager.ShowInformation(Me, "This application is currently not joined to the context.  The 'Log-Off All' option " _
                                     & "is not available. If you would like to enable the 'Log-Off All' option, close and restart this " _
                                     & "application from the CCOW dashboard with the SSO option enabled.")
            Return
         End If

         Try
            If (Not _AppOnlyLogin) Then
               Dim userSubject As Subject = New Subject("User")
               Dim item As ContextItem = New ContextItem("User.Id.logon." & MainForm.Suffix, String.Empty)

               userSubject.Items.Add(item)
               _Context.Set(userSubject)
               SetUserInfo(String.Empty)
               _LoggedIn = False
               ShowContext()

#If LEADTOOLS_V19_OR_LATER Then
               If CheckPatientDependencies() Then
                  Me._Context.Leave()
               End If
#End If
            Else
               Messager.ShowInformation(Me, "This application is currently not joined to the context.  The 'Log-Off All' option " _
                                            & "is not available. If you would like to enable the 'Log-Off All' option, close and restart this " _
                                            & "application from the CCOW dashboard with the SSO option enabled.")
            End If
         Catch exception As Exception
            If TypeOf exception Is COMException Then
               '
               ' Check to see if the Context Manager server has terminated.
               '
               If exception.Message.Contains("The RPC server is unavailable") Then
                  Messager.Show(Me, "The Context Management Server was terminated.  The application can no longer access the context and will restart to attempt to rejoin the context.", MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                  Close()
                  CCOWUtils.Restart()
               Else
                  Messager.ShowError(Nothing, exception)
               End If
            Else
               Messager.ShowError(Nothing, exception)
            End If
         End Try
      End Sub



#If LEADTOOLS_V19_OR_LATER Then
      Private Shared Function CheckPatientDependencies() As Boolean
         Monitor.Enter(CcowServer.LockObject)
         Try
            Using db As Leadtools.Ccow.Server.Data.Database = Leadtools.Ccow.Server.Utils.GetDatabase()
               Dim patientSubject As Leadtools.Ccow.Server.Data.CCOWSubject = db.CCOWSubject.FirstOrDefault(Function(a) a.Subject.ToLower() = "patient")
               For Each dp As Leadtools.Ccow.Server.Data.CCOWSubjectDependency In patientSubject.DependentSubjects
                  If dp.CCOWSubject.Subject.ToLower() = "user" Then
                     Return True
                  End If
               Next
            End Using
         Finally
            Monitor.[Exit](CcowServer.LockObject)
         End Try

         Return False
      End Function
#End If

      Private Sub JoinContext()
         _Context.Join(_ApplicationName, True)
      End Sub
      Private Sub logOnToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles logOnToolStripMenuItem.Click
         Dim old As Exception = Nothing

         If (Not _LoggedIn) Then
            Dim dialogInfo As InfoDialog = New InfoDialog(Me)

            dialogInfo.Title = "Joining Common Context"
            dialogInfo.Description = "Attempting to join the common context"
            Try
               If (Not _Context.Joined) Then
                  If dialogInfo.ShowDialog(New MethodInvoker(AddressOf JoinContext)) = System.Windows.Forms.DialogResult.OK Then
                     SetCCowIcon(ContextState.Linked)
                  End If

                  If Not dialogInfo.Exception Is Nothing Then
                     Throw dialogInfo.Exception
                  End If

                  Try
                     dialogInfo.Title = "Secure Binding"
                     dialogInfo.Description = "Securely binding to the context manager"
                     dialogInfo.ShowDialog(New MethodInvoker(AddressOf SecureBind))
                     If Not dialogInfo.Exception Is Nothing Then
                        Throw dialogInfo.Exception
                     End If

                  Catch exception As Exception
                     old = exception
                     Messager.ShowError(Me, exception)
                  End Try
               End If

               If MainForm.Dashboard Then
                  DoDashboard(False, failedToVerify)
               Else
                  DoApplicationLogin()
               End If
               ShowContext()
               If listViewPatients.Items.Count = 0 Then
                  InitializePatients()
               End If

               If _Context.LastCoupon <> 0 Then
                  CheckPatient(_Context.LastCoupon, False)
                  SelectNewPatient()
               End If
            Catch exception As Exception
               If TypeOf exception Is COMException Then
                  '
                  ' Check to see if the Context Manager server has terminated.
                  '
                  If exception.Message.Contains("The RPC server is unavailable") Then
                     Messager.Show(Me, "The Context Management Server was terminated.  The application can no longer access the context and will restart to attempt to rejoin the context.", MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                     Close()
                     CCOWUtils.Restart()
                  Else
                     If Not old Is Nothing AndAlso old.Message <> exception.Message Then
                        Messager.ShowError(Nothing, exception)
                     End If
                     If _Context.Joined Then
                        Try
                           ShowContext()
                        Catch ex As Exception
                           Messager.ShowError(Nothing, ex.Message)
                        End Try
                     End If
                  End If
               Else
                  Messager.ShowError(Nothing, exception)
               End If
            End Try
         Else
            Messager.ShowInformation(Me, "A user is currently logged into the application. This menu option will become available once the current user logs out.")
         End If
      End Sub

      Private Sub MenuItem_MouseHover(ByVal sender As Object, ByVal e As EventArgs) Handles fileToolStripMenuItem.MouseHover, logOnToolStripMenuItem.MouseHover, logoutToolStripMenuItem.MouseHover, logOffAllToolStripMenuItem.MouseHover, exitToolStripMenuItem.MouseHover, contextToolStripMenuItem.MouseHover, suspendToolStripMenuItem.MouseHover, resumeToolStripMenuItem.MouseHover
         Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
         Dim name As String = item.Text.Replace("&", String.Empty).ToLower()

         '
         ' No hover when menu disabled
         '
         Select Case name
            Case "file"
               textBoxHelp.Text = My.Resources.File
            Case "context"
               textBoxHelp.Text = My.Resources.Context
            Case "join"
               textBoxHelp.Text = My.Resources.Join
            Case "log-off all"
               textBoxHelp.Text = My.Resources.LogOffAll
            Case "log-on"
               textBoxHelp.Text = My.Resources.LogOn
            Case "log-off"
               textBoxHelp.Text = My.Resources.LogOff
            Case "exit"
               textBoxHelp.Text = My.Resources.ExitApp
            Case "suspend"
               textBoxHelp.Text = My.Resources.Suspend
            Case "resume"
               textBoxHelp.Text = My.Resources.ResumeApp
            Case Else
               textBoxHelp.Text = String.Empty
         End Select
      End Sub

      Private Sub SetLinkDisplay(ByVal linkInfo As String)
         toolStripStatusLabelLink.Text = linkInfo
      End Sub

#Region "Logging Functions"

      Private Delegate Sub LogDelegate(ByVal color As Color, ByVal format As String, <[ParamArray]()> ByVal args As Object())

      Public Sub Log(ByVal format As String, ByVal ParamArray args As Object())
         Log(Color.Empty, format, args)
      End Sub

      Public Sub Log(ByVal color As Color, ByVal format As String, ByVal ParamArray args As Object())
         If InvokeRequired Then
            BeginInvoke(New LogDelegate(AddressOf Log), color, format, args)
         Else
            Dim message As String = String.Format(format, args) & vbCrLf
            Dim start As Integer = richTextBoxLog.TextLength

            If Not color.Equals(color.Empty) Then
               richTextBoxLog.SelectionColor = color
            End If
            richTextBoxLog.AppendText(message)
            If Not color.Equals(color.Empty) Then
               Dim [end] As Integer = 0

               [end] = richTextBoxLog.TextLength
               richTextBoxLog.Select(start, [end] - start)
               richTextBoxLog.SelectionColor = color
               richTextBoxLog.SelectionLength = 0
            End If
            richTextBoxLog.SelectionStart = richTextBoxLog.TextLength
            richTextBoxLog.ScrollToCaret()
         End If
      End Sub

#End Region
   End Class
End Namespace
