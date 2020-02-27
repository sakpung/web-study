' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Management
Imports Leadtools.Dicom
Imports System.Collections.Generic
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Net

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for OptionsDlg.
   ''' </summary>
   Public Class OptionsDlg : Inherits System.Windows.Forms.Form
      Private tabControl1 As System.Windows.Forms.TabControl
      Private button1 As System.Windows.Forms.Button
      Private button2 As System.Windows.Forms.Button
      Private tabPage1 As System.Windows.Forms.TabPage
      Private tabPage2 As System.Windows.Forms.TabPage
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private label5 As System.Windows.Forms.Label
      Private textBoxAETitle As System.Windows.Forms.TextBox
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing
      Private numericUpDownPort As System.Windows.Forms.NumericUpDown

      Public AETitle As String
      Public sIPAddress As String
      Public Port As Integer
      Public Timeout As Integer
      Public ImageDir As String

      Public SaveCSReceived As Boolean
      Public SaveDSReceived As Boolean
      Public SaveDSSent As Boolean
      Public DisableLogging As Boolean
      Public LogDir As String

        Public IsSecure As Boolean = False
#If LEADTOOLS_V17_OR_LATER Then
        Public IpType As DicomNetIpTypeFlags
#End If

      Private label6 As System.Windows.Forms.Label
      Private label7 As System.Windows.Forms.Label
      Private WithEvents buttonDir As System.Windows.Forms.Button
      Private numericUpDownTimeout As System.Windows.Forms.NumericUpDown
      Private numericUpDownMaxClients As System.Windows.Forms.NumericUpDown
      Private folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
      Private textBoxDir As System.Windows.Forms.TextBox
      Friend WithEvents checkBoxUseSecureTLSCommunication As System.Windows.Forms.CheckBox
      Private WithEvents groupBoxIpType As System.Windows.Forms.GroupBox
      Private WithEvents radioButtonIpv4Ipv6 As System.Windows.Forms.RadioButton
      Private WithEvents radioButtonIpv6 As System.Windows.Forms.RadioButton
      Private WithEvents radioButtonIpv4 As System.Windows.Forms.RadioButton
      Private WithEvents comboBoxIPAddress As System.Windows.Forms.ComboBox
      Private WithEvents labelDisableLogging As System.Windows.Forms.Label
      Private WithEvents checkBoxDisableLogging As System.Windows.Forms.CheckBox
      Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents buttonDirLog As System.Windows.Forms.Button
      Private WithEvents textBoxLogDir As System.Windows.Forms.TextBox
      Private WithEvents label8 As System.Windows.Forms.Label
      Private WithEvents checkBoxDSSent As System.Windows.Forms.CheckBox
      Private WithEvents checkBoxDSReceived As System.Windows.Forms.CheckBox
      Private WithEvents checkBoxCSReceived As System.Windows.Forms.CheckBox
      Public MaxClients As Integer

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
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
         Me.tabControl1 = New System.Windows.Forms.TabControl()
         Me.tabPage1 = New System.Windows.Forms.TabPage()
         Me.groupBoxIpType = New System.Windows.Forms.GroupBox()
         Me.radioButtonIpv4Ipv6 = New System.Windows.Forms.RadioButton()
         Me.radioButtonIpv6 = New System.Windows.Forms.RadioButton()
         Me.radioButtonIpv4 = New System.Windows.Forms.RadioButton()
         Me.comboBoxIPAddress = New System.Windows.Forms.ComboBox()
         Me.checkBoxUseSecureTLSCommunication = New System.Windows.Forms.CheckBox()
         Me.numericUpDownMaxClients = New System.Windows.Forms.NumericUpDown()
         Me.numericUpDownTimeout = New System.Windows.Forms.NumericUpDown()
         Me.buttonDir = New System.Windows.Forms.Button()
         Me.textBoxDir = New System.Windows.Forms.TextBox()
         Me.label7 = New System.Windows.Forms.Label()
         Me.label6 = New System.Windows.Forms.Label()
         Me.numericUpDownPort = New System.Windows.Forms.NumericUpDown()
         Me.textBoxAETitle = New System.Windows.Forms.TextBox()
         Me.label5 = New System.Windows.Forms.Label()
         Me.label4 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me.tabPage2 = New System.Windows.Forms.TabPage()
         Me.button1 = New System.Windows.Forms.Button()
         Me.button2 = New System.Windows.Forms.Button()
         Me.folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
         Me.checkBoxCSReceived = New System.Windows.Forms.CheckBox()
         Me.checkBoxDSReceived = New System.Windows.Forms.CheckBox()
         Me.checkBoxDSSent = New System.Windows.Forms.CheckBox()
         Me.label8 = New System.Windows.Forms.Label()
         Me.textBoxLogDir = New System.Windows.Forms.TextBox()
         Me.buttonDirLog = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.labelDisableLogging = New System.Windows.Forms.Label()
         Me.checkBoxDisableLogging = New System.Windows.Forms.CheckBox()
         Me.tabControl1.SuspendLayout()
         Me.tabPage1.SuspendLayout()
         Me.groupBoxIpType.SuspendLayout()
         CType(Me.numericUpDownMaxClients, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.numericUpDownTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.numericUpDownPort, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.tabPage2.SuspendLayout()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         '
         'tabControl1
         '
         Me.tabControl1.Controls.Add(Me.tabPage1)
         Me.tabControl1.Controls.Add(Me.tabPage2)
         Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Top
         Me.tabControl1.Location = New System.Drawing.Point(0, 0)
         Me.tabControl1.Name = "tabControl1"
         Me.tabControl1.SelectedIndex = 0
         Me.tabControl1.Size = New System.Drawing.Size(413, 352)
         Me.tabControl1.TabIndex = 0
         '
         'tabPage1
         '
         Me.tabPage1.Controls.Add(Me.groupBoxIpType)
         Me.tabPage1.Controls.Add(Me.checkBoxUseSecureTLSCommunication)
         Me.tabPage1.Controls.Add(Me.numericUpDownMaxClients)
         Me.tabPage1.Controls.Add(Me.numericUpDownTimeout)
         Me.tabPage1.Controls.Add(Me.buttonDir)
         Me.tabPage1.Controls.Add(Me.textBoxDir)
         Me.tabPage1.Controls.Add(Me.label7)
         Me.tabPage1.Controls.Add(Me.label6)
         Me.tabPage1.Controls.Add(Me.numericUpDownPort)
         Me.tabPage1.Controls.Add(Me.textBoxAETitle)
         Me.tabPage1.Controls.Add(Me.label5)
         Me.tabPage1.Controls.Add(Me.label4)
         Me.tabPage1.Controls.Add(Me.label3)
         Me.tabPage1.Controls.Add(Me.label2)
         Me.tabPage1.Controls.Add(Me.label1)
         Me.tabPage1.Location = New System.Drawing.Point(4, 22)
         Me.tabPage1.Name = "tabPage1"
         Me.tabPage1.Size = New System.Drawing.Size(405, 326)
         Me.tabPage1.TabIndex = 0
         Me.tabPage1.Text = "Server"
         '
         'groupBoxIpType
         '
         Me.groupBoxIpType.Controls.Add(Me.radioButtonIpv4Ipv6)
         Me.groupBoxIpType.Controls.Add(Me.radioButtonIpv6)
         Me.groupBoxIpType.Controls.Add(Me.radioButtonIpv4)
         Me.groupBoxIpType.Controls.Add(Me.comboBoxIPAddress)
         Me.groupBoxIpType.Location = New System.Drawing.Point(128, 48)
         Me.groupBoxIpType.Name = "groupBoxIpType"
         Me.groupBoxIpType.Size = New System.Drawing.Size(232, 104)
         Me.groupBoxIpType.TabIndex = 19
         Me.groupBoxIpType.TabStop = False
         '
         'radioButtonIpv4Ipv6
         '
         Me.radioButtonIpv4Ipv6.AutoSize = True
         Me.radioButtonIpv4Ipv6.Location = New System.Drawing.Point(8, 80)
         Me.radioButtonIpv4Ipv6.Name = "radioButtonIpv4Ipv6"
         Me.radioButtonIpv4Ipv6.Size = New System.Drawing.Size(82, 17)
         Me.radioButtonIpv4Ipv6.TabIndex = 2
         Me.radioButtonIpv4Ipv6.TabStop = True
         Me.radioButtonIpv4Ipv6.Text = "Ipv4 or Ipv6"
         Me.radioButtonIpv4Ipv6.UseVisualStyleBackColor = True
         '
         'radioButtonIpv6
         '
         Me.radioButtonIpv6.AutoSize = True
         Me.radioButtonIpv6.Location = New System.Drawing.Point(8, 64)
         Me.radioButtonIpv6.Name = "radioButtonIpv6"
         Me.radioButtonIpv6.Size = New System.Drawing.Size(47, 17)
         Me.radioButtonIpv6.TabIndex = 1
         Me.radioButtonIpv6.TabStop = True
         Me.radioButtonIpv6.Text = "IPv6"
         Me.radioButtonIpv6.UseVisualStyleBackColor = True
         '
         'radioButtonIpv4
         '
         Me.radioButtonIpv4.AutoSize = True
         Me.radioButtonIpv4.Location = New System.Drawing.Point(8, 48)
         Me.radioButtonIpv4.Name = "radioButtonIpv4"
         Me.radioButtonIpv4.Size = New System.Drawing.Size(47, 17)
         Me.radioButtonIpv4.TabIndex = 0
         Me.radioButtonIpv4.TabStop = True
         Me.radioButtonIpv4.Text = "IPv4"
         Me.radioButtonIpv4.UseVisualStyleBackColor = True
         '
         'comboBoxIPAddress
         '
         Me.comboBoxIPAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.comboBoxIPAddress.Location = New System.Drawing.Point(8, 16)
         Me.comboBoxIPAddress.Name = "comboBoxIPAddress"
         Me.comboBoxIPAddress.Size = New System.Drawing.Size(208, 21)
         Me.comboBoxIPAddress.TabIndex = 6
         '
         'checkBoxUseSecureTLSCommunication
         '
         Me.checkBoxUseSecureTLSCommunication.AutoSize = True
         Me.checkBoxUseSecureTLSCommunication.Location = New System.Drawing.Point(128, 296)
         Me.checkBoxUseSecureTLSCommunication.Name = "checkBoxUseSecureTLSCommunication"
         Me.checkBoxUseSecureTLSCommunication.Size = New System.Drawing.Size(180, 17)
         Me.checkBoxUseSecureTLSCommunication.TabIndex = 17
         Me.checkBoxUseSecureTLSCommunication.Text = "Use Secure TLS Communication"
         Me.checkBoxUseSecureTLSCommunication.UseVisualStyleBackColor = True
         '
         'numericUpDownMaxClients
         '
         Me.numericUpDownMaxClients.Location = New System.Drawing.Point(128, 260)
         Me.numericUpDownMaxClients.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
         Me.numericUpDownMaxClients.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me.numericUpDownMaxClients.Name = "numericUpDownMaxClients"
         Me.numericUpDownMaxClients.Size = New System.Drawing.Size(120, 20)
         Me.numericUpDownMaxClients.TabIndex = 16
         Me.numericUpDownMaxClients.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '
         'numericUpDownTimeout
         '
         Me.numericUpDownTimeout.Location = New System.Drawing.Point(128, 228)
         Me.numericUpDownTimeout.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
         Me.numericUpDownTimeout.Name = "numericUpDownTimeout"
         Me.numericUpDownTimeout.Size = New System.Drawing.Size(120, 20)
         Me.numericUpDownTimeout.TabIndex = 15
         Me.numericUpDownTimeout.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '
         'buttonDir
         '
         Me.buttonDir.Location = New System.Drawing.Point(336, 164)
         Me.buttonDir.Name = "buttonDir"
         Me.buttonDir.Size = New System.Drawing.Size(24, 20)
         Me.buttonDir.TabIndex = 14
         Me.buttonDir.Text = "..."
         '
         'textBoxDir
         '
         Me.textBoxDir.Location = New System.Drawing.Point(128, 164)
         Me.textBoxDir.Name = "textBoxDir"
         Me.textBoxDir.Size = New System.Drawing.Size(184, 20)
         Me.textBoxDir.TabIndex = 13
         '
         'label7
         '
         Me.label7.Location = New System.Drawing.Point(16, 164)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(100, 23)
         Me.label7.TabIndex = 12
         Me.label7.Text = "Image Directory:"
         '
         'label6
         '
         Me.label6.Location = New System.Drawing.Point(248, 232)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(64, 16)
         Me.label6.TabIndex = 11
         Me.label6.Text = "minutes"
         '
         'numericUpDownPort
         '
         Me.numericUpDownPort.Location = New System.Drawing.Point(128, 196)
         Me.numericUpDownPort.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
         Me.numericUpDownPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me.numericUpDownPort.Name = "numericUpDownPort"
         Me.numericUpDownPort.Size = New System.Drawing.Size(120, 20)
         Me.numericUpDownPort.TabIndex = 7
         Me.numericUpDownPort.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '
         'textBoxAETitle
         '
         Me.textBoxAETitle.Location = New System.Drawing.Point(128, 16)
         Me.textBoxAETitle.Name = "textBoxAETitle"
         Me.textBoxAETitle.Size = New System.Drawing.Size(208, 20)
         Me.textBoxAETitle.TabIndex = 5
         '
         'label5
         '
         Me.label5.Location = New System.Drawing.Point(16, 260)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(100, 23)
         Me.label5.TabIndex = 4
         Me.label5.Text = "Max Clients:"
         '
         'label4
         '
         Me.label4.Location = New System.Drawing.Point(16, 228)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(100, 23)
         Me.label4.TabIndex = 3
         Me.label4.Text = "Timeout:"
         '
         'label3
         '
         Me.label3.Location = New System.Drawing.Point(16, 196)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(100, 23)
         Me.label3.TabIndex = 2
         Me.label3.Text = "Port:"
         '
         'label2
         '
         Me.label2.Location = New System.Drawing.Point(16, 48)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(100, 23)
         Me.label2.TabIndex = 1
         Me.label2.Text = "IP Address:"
         '
         'label1
         '
         Me.label1.Location = New System.Drawing.Point(16, 16)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(100, 23)
         Me.label1.TabIndex = 0
         Me.label1.Text = "AE Title:"
         '
         'tabPage2
         '
         Me.tabPage2.Controls.Add(Me.labelDisableLogging)
         Me.tabPage2.Controls.Add(Me.checkBoxDisableLogging)
         Me.tabPage2.Controls.Add(Me.groupBox1)
         Me.tabPage2.Location = New System.Drawing.Point(4, 22)
         Me.tabPage2.Name = "tabPage2"
         Me.tabPage2.Size = New System.Drawing.Size(405, 326)
         Me.tabPage2.TabIndex = 1
         Me.tabPage2.Text = "Log"
         '
         'button1
         '
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.button1.Location = New System.Drawing.Point(136, 360)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(75, 23)
         Me.button1.TabIndex = 1
         Me.button1.Text = "&OK"
         '
         'button2
         '
         Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.button2.Location = New System.Drawing.Point(216, 360)
         Me.button2.Name = "button2"
         Me.button2.Size = New System.Drawing.Size(75, 23)
         Me.button2.TabIndex = 2
         Me.button2.Text = "Cancel"
         '
         'checkBoxCSReceived
         '
         Me.checkBoxCSReceived.Location = New System.Drawing.Point(16, 19)
         Me.checkBoxCSReceived.Name = "checkBoxCSReceived"
         Me.checkBoxCSReceived.Size = New System.Drawing.Size(224, 24)
         Me.checkBoxCSReceived.TabIndex = 17
         Me.checkBoxCSReceived.Text = "Save command sets received by server"
         '
         'checkBoxDSReceived
         '
         Me.checkBoxDSReceived.Location = New System.Drawing.Point(16, 51)
         Me.checkBoxDSReceived.Name = "checkBoxDSReceived"
         Me.checkBoxDSReceived.Size = New System.Drawing.Size(224, 24)
         Me.checkBoxDSReceived.TabIndex = 18
         Me.checkBoxDSReceived.Text = "Save datasets received by server"
         '
         'checkBoxDSSent
         '
         Me.checkBoxDSSent.Location = New System.Drawing.Point(16, 83)
         Me.checkBoxDSSent.Name = "checkBoxDSSent"
         Me.checkBoxDSSent.Size = New System.Drawing.Size(224, 24)
         Me.checkBoxDSSent.TabIndex = 19
         Me.checkBoxDSSent.Text = "Save datasets sent by server"
         '
         'label8
         '
         Me.label8.Location = New System.Drawing.Point(16, 123)
         Me.label8.Name = "label8"
         Me.label8.Size = New System.Drawing.Size(100, 23)
         Me.label8.TabIndex = 20
         Me.label8.Text = "Log directory:"
         '
         'textBoxLogDir
         '
         Me.textBoxLogDir.Location = New System.Drawing.Point(16, 139)
         Me.textBoxLogDir.Name = "textBoxLogDir"
         Me.textBoxLogDir.Size = New System.Drawing.Size(184, 20)
         Me.textBoxLogDir.TabIndex = 21
         '
         'buttonDirLog
         '
         Me.buttonDirLog.Location = New System.Drawing.Point(200, 139)
         Me.buttonDirLog.Name = "buttonDirLog"
         Me.buttonDirLog.Size = New System.Drawing.Size(24, 20)
         Me.buttonDirLog.TabIndex = 22
         Me.buttonDirLog.Text = "..."
         '
         'groupBox1
         '
         Me.groupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
               Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.groupBox1.Controls.Add(Me.buttonDirLog)
         Me.groupBox1.Controls.Add(Me.textBoxLogDir)
         Me.groupBox1.Controls.Add(Me.label8)
         Me.groupBox1.Controls.Add(Me.checkBoxDSSent)
         Me.groupBox1.Controls.Add(Me.checkBoxDSReceived)
         Me.groupBox1.Controls.Add(Me.checkBoxCSReceived)
         Me.groupBox1.Location = New System.Drawing.Point(3, 3)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(394, 174)
         Me.groupBox1.TabIndex = 17
         Me.groupBox1.TabStop = False
         '
         'labelDisableLogging
         '
         Me.labelDisableLogging.AutoSize = True
         Me.labelDisableLogging.ForeColor = System.Drawing.Color.Green
         Me.labelDisableLogging.Location = New System.Drawing.Point(128, 200)
         Me.labelDisableLogging.Name = "labelDisableLogging"
         Me.labelDisableLogging.Size = New System.Drawing.Size(227, 13)
         Me.labelDisableLogging.TabIndex = 20
         Me.labelDisableLogging.Text = "<== Disable logging for Optimized Performance"
         '
         'checkBoxDisableLogging
         '
         Me.checkBoxDisableLogging.AutoSize = True
         Me.checkBoxDisableLogging.Location = New System.Drawing.Point(19, 200)
         Me.checkBoxDisableLogging.Name = "checkBoxDisableLogging"
         Me.checkBoxDisableLogging.Size = New System.Drawing.Size(102, 17)
         Me.checkBoxDisableLogging.TabIndex = 19
         Me.checkBoxDisableLogging.Text = "Disable Logging"
         Me.checkBoxDisableLogging.UseVisualStyleBackColor = True
         '
         'OptionsDlg
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(413, 396)
         Me.Controls.Add(Me.button2)
         Me.Controls.Add(Me.button1)
         Me.Controls.Add(Me.tabControl1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "OptionsDlg"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Server Options"
         Me.tabControl1.ResumeLayout(False)
         Me.tabPage1.ResumeLayout(False)
         Me.tabPage1.PerformLayout()
         Me.groupBoxIpType.ResumeLayout(False)
         Me.groupBoxIpType.PerformLayout()
         CType(Me.numericUpDownMaxClients, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.numericUpDownTimeout, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.numericUpDownPort, System.ComponentModel.ISupportInitialize).EndInit()
         Me.tabPage2.ResumeLayout(False)
         Me.tabPage2.PerformLayout()
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub
#End Region

        Private Sub OptionsDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If LEADTOOLS_V17_OR_LATER Then
            radioButtonIpv4.Checked = (IpType = DicomNetIpTypeFlags.Ipv4)
            radioButtonIpv6.Checked = (IpType = DicomNetIpTypeFlags.Ipv6)
            radioButtonIpv4Ipv6.Checked = (IpType = DicomNetIpTypeFlags.Ipv4OrIpv6)
            radioButtonIpv4Ipv6.Enabled = IsWinVistaOrHigher()
#Else
		 radioButtonIpv4.Checked = True
		 radioButtonIpv6.Checked = False
		 radioButtonIpv4Ipv6.Checked = False

		 radioButtonIpv6.Enabled = False
		 radioButtonIpv4Ipv6.Enabled = False

#End If

            InitIpList()

            textBoxAETitle.Text = AETitle
            textBoxDir.Text = ImageDir
            numericUpDownPort.Value = Port
            numericUpDownTimeout.Value = Timeout
            numericUpDownMaxClients.Value = MaxClients
            checkBoxUseSecureTLSCommunication.Checked = IsSecure

            checkBoxCSReceived.Checked = SaveCSReceived
            checkBoxDSReceived.Checked = SaveDSReceived
            checkBoxDSSent.Checked = SaveDSSent
            textBoxLogDir.Text = LogDir
            checkBoxDisableLogging.Checked = DisableLogging
        End Sub

        Private Sub CheckBoxUseSecureTLSCommunication_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxUseSecureTLSCommunication.CheckedChanged
            If checkBoxUseSecureTLSCommunication.Checked Then
                If Leadtools.DicomDemos.Utils.VerifyOpensslVersion(Me) = False Then
                    checkBoxUseSecureTLSCommunication.Checked = False
                End If
            End If
        End Sub

        Public Function IsWinVistaOrHigher() As Boolean
         Dim OS As OperatingSystem = Environment.OSVersion
         Return (OS.Platform = PlatformID.Win32NT) AndAlso (OS.Version.Major >= 6)
      End Function

      Private Function ExcludeIpv6(ByVal ip As IPAddress) As Boolean
         Dim sIp As String = ip.ToString()
         If sIp.Contains(".") Then
            Return True
         End If

         If sIp.Contains("fe80::1") Then
            Return True
         End If

         Return False
      End Function
#If LEADTOOLS_V17_OR_LATER Then
      Private Sub GetIpListsXp(<System.Runtime.InteropServices.Out()> ByRef ipListIpv4 As ArrayList, <System.Runtime.InteropServices.Out()> ByRef ipListIpv6 As ArrayList)
         ipListIpv4 = New ArrayList()
         ipListIpv6 = New ArrayList()

         ' Obtain a reference to all network interfaces in the machine
         Dim adapters() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
         For Each adapter As NetworkInterface In adapters
            If adapter.OperationalStatus = OperationalStatus.Up Then
               Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
               For Each uniCast As IPAddressInformation In properties.UnicastAddresses
                  Dim ip As IPAddress = uniCast.Address
                  Dim bLoopback As Boolean = IPAddress.IsLoopback(ip)
                  If (Not IPAddress.IsLoopback(ip)) Then
                     If (IpType And DicomNetIpTypeFlags.Ipv4) = DicomNetIpTypeFlags.Ipv4 Then
                        If uniCast.Address.AddressFamily = AddressFamily.InterNetwork Then
                           ipListIpv4.Add(uniCast.Address.ToString())
                        End If
                     End If

                     If (IpType And DicomNetIpTypeFlags.Ipv6) = DicomNetIpTypeFlags.Ipv6 Then
                        If uniCast.Address.AddressFamily = AddressFamily.InterNetworkV6 Then
                           If (Not ExcludeIpv6(ip)) Then
                              ipListIpv6.Add(uniCast.Address.ToString())
                           End If
                        End If
                     End If
                  End If
               Next uniCast
            End If
         Next adapter
      End Sub
#End If

      Private Sub GetIpListsVistaOrHigher(<System.Runtime.InteropServices.Out()> ByRef ipListIpv4 As ArrayList, <System.Runtime.InteropServices.Out()> ByRef ipListIpv6 As ArrayList)
         ipListIpv4 = New ArrayList()
         ipListIpv6 = New ArrayList()

         Dim searcher As New ManagementObjectSearcher("SELECT * From Win32_NetworkAdapterConfiguration WHERE IPEnabled = 1")
         If searcher IsNot Nothing Then
            Dim adapters As ManagementObjectCollection = searcher.Get()

            For Each adapter As ManagementObject In adapters
               Dim ipAddressIpv4 As String = String.Empty
               Dim ipAddressIpv6 As String = String.Empty
               Dim ipArray() As String = CType(adapter("IPAddress"), String())

               If ipArray IsNot Nothing Then
                  If ipArray.Length >= 1 Then
                     ipAddressIpv4 = ipArray(0)
                  End If
                  If ipArray.Length >= 2 Then
                     ipAddressIpv6 = ipArray(1)
                  End If

               End If
#If LEADTOOLS_V17_OR_LATER Then
               If (IpType And DicomNetIpTypeFlags.Ipv4) = DicomNetIpTypeFlags.Ipv4 Then
                  If (Not String.IsNullOrEmpty(ipAddressIpv4)) Then
                     ipListIpv4.Add(ipAddressIpv4)
                  End If
               End If
               If (IpType And DicomNetIpTypeFlags.Ipv6) = DicomNetIpTypeFlags.Ipv6 Then
                  If (Not String.IsNullOrEmpty(ipAddressIpv6)) Then
                     ipListIpv6.Add(ipAddressIpv6)
                  End If
               End If
#Else
			   ipListIpv4.Add(ipAddressIpv4)
#End If
            Next adapter
         End If
      End Sub

      Private Sub InitIpList()
         Dim ipListIpv4 As ArrayList = Nothing
         Dim ipListIpv6 As ArrayList = Nothing
#If LEADTOOLS_V17_OR_LATER Then
         If IsWinVistaOrHigher() Then
            GetIpListsVistaOrHigher(ipListIpv4, ipListIpv6)
         Else
            GetIpListsXp(ipListIpv4, ipListIpv6)
         End If
#Else
        GetIpListsVistaOrHigher(ipListIpv4, ipListIpv6)
#End If


         comboBoxIPAddress.Items.Clear()
         Dim index As Integer = 0
         index = comboBoxIPAddress.Items.Add("All")
         For Each s As String In ipListIpv4
            If s <> "0.0.0.0" Then
               index = comboBoxIPAddress.Items.Add(s)
               If (sIPAddress = s) OrElse (sIPAddress = "*" AndAlso s = "All") OrElse (sIPAddress.Trim().Length = 0) Then
                  comboBoxIPAddress.SelectedIndex = index
               End If
            End If
         Next s
#If (LEADTOOLS_V17_OR_LATER) Then
         For Each s As String In ipListIpv6
            'if (s != "0.0.0.0")
            index = comboBoxIPAddress.Items.Add(s)
            If (sIPAddress = s) OrElse (sIPAddress.Trim().Length = 0) Then
               comboBoxIPAddress.SelectedIndex = index
            End If
         Next s
#End If

         If comboBoxIPAddress.SelectedIndex = -1 Then
            comboBoxIPAddress.SelectedIndex = 0
         End If
         comboBoxIPAddress.Enabled = (comboBoxIPAddress.Items.Count > 1)
      End Sub

      Private Sub UpdateIpType()
#If LEADTOOLS_V17_OR_LATER Then
         If radioButtonIpv4.Checked Then
            IpType = DicomNetIpTypeFlags.Ipv4
         ElseIf radioButtonIpv6.Checked Then
            IpType = DicomNetIpTypeFlags.Ipv6
         Else
            IpType = DicomNetIpTypeFlags.Ipv4OrIpv6
         End If
#End If
      End Sub

      Private Sub OptionsDlg_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
         If DialogResult = DialogResult.OK Then
            AETitle = textBoxAETitle.Text
            Port = Convert.ToInt32(numericUpDownPort.Value)
            Timeout = Convert.ToInt32(numericUpDownTimeout.Value)
            MaxClients = Convert.ToInt32(numericUpDownMaxClients.Value)

            If comboBoxIPAddress.SelectedItem IsNot Nothing Then
               sIPAddress = comboBoxIPAddress.SelectedItem.ToString()
               If sIPAddress = "All" Then
                  sIPAddress = "*"
               End If
            End If
            ImageDir = textBoxDir.Text
            IsSecure = checkBoxUseSecureTLSCommunication.Checked

            SaveCSReceived = checkBoxCSReceived.Checked
            SaveDSReceived = checkBoxDSReceived.Checked
            SaveDSSent = checkBoxDSSent.Checked
            LogDir = textBoxLogDir.Text
            DisableLogging = checkBoxDisableLogging.Checked
            UpdateIpType()
         End If
      End Sub

      Private Sub buttonDir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonDir.Click
         If folderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            textBoxDir.Text = folderBrowserDialog1.SelectedPath
         End If
      End Sub

      Private Sub buttonDirLog_Click(ByVal sender As Object, ByVal e As System.EventArgs)
         If folderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            textBoxLogDir.Text = folderBrowserDialog1.SelectedPath
         End If
      End Sub

   Private Sub radioButtonIp_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles radioButtonIpv4.CheckedChanged, radioButtonIpv4Ipv6.CheckedChanged, radioButtonIpv6.CheckedChanged
		 Dim rb As RadioButton = TryCast(sender, RadioButton)
		 If rb IsNot Nothing Then
			If rb.Checked Then
			   UpdateIpType()
			   InitIpList()
			End If
		 End If
End Sub

      Private Sub checkBoxDisableLogging_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkBoxDisableLogging.CheckedChanged
         UpdateUI()
      End Sub

      Private Sub UpdateUI()
         Dim disableLogging As Boolean = checkBoxDisableLogging.Checked
         groupBox1.Enabled = Not disableLogging
      End Sub

   End Class
End Namespace
