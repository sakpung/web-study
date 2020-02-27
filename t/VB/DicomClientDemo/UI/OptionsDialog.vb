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

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for OptionsDialog.
   ''' </summary>
   Public Class OptionsDialog : Inherits System.Windows.Forms.Form
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Public ServerAE As System.Windows.Forms.TextBox
      Public WithEvents ServerPort As System.Windows.Forms.TextBox
      Public WithEvents ServerIp As System.Windows.Forms.TextBox
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private label5 As System.Windows.Forms.Label
      Private label6 As System.Windows.Forms.Label
      Public WithEvents Timeout As System.Windows.Forms.TextBox
      Public ClientAE As System.Windows.Forms.TextBox
      Public WithEvents ClientPort As System.Windows.Forms.TextBox
      Private label4 As System.Windows.Forms.Label
      Private WithEvents buttonOK As System.Windows.Forms.Button
      Private buttonCancel As System.Windows.Forms.Button
      Private WithEvents _groupMiscellaneous As System.Windows.Forms.GroupBox
      Private WithEvents _checkBoxGroupLengthDataElements As System.Windows.Forms.CheckBox
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

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
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.ServerIp = New System.Windows.Forms.TextBox()
         Me.ServerPort = New System.Windows.Forms.TextBox()
         Me.ServerAE = New System.Windows.Forms.TextBox()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.ClientPort = New System.Windows.Forms.TextBox()
         Me.label4 = New System.Windows.Forms.Label()
         Me.Timeout = New System.Windows.Forms.TextBox()
         Me.ClientAE = New System.Windows.Forms.TextBox()
         Me.label5 = New System.Windows.Forms.Label()
         Me.label6 = New System.Windows.Forms.Label()
         Me.buttonOK = New System.Windows.Forms.Button()
         Me.buttonCancel = New System.Windows.Forms.Button()
         Me._groupMiscellaneous = New System.Windows.Forms.GroupBox()
         Me._checkBoxGroupLengthDataElements = New System.Windows.Forms.CheckBox()
         Me.groupBox1.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me._groupMiscellaneous.SuspendLayout()
         Me.SuspendLayout()
         '
         'groupBox1
         '
         Me.groupBox1.Controls.Add(Me.ServerIp)
         Me.groupBox1.Controls.Add(Me.ServerPort)
         Me.groupBox1.Controls.Add(Me.ServerAE)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(8, 8)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(344, 120)
         Me.groupBox1.TabIndex = 0
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Server (SCP AE) Information"
         '
         'ServerIp
         '
         Me.ServerIp.Location = New System.Drawing.Point(128, 56)
         Me.ServerIp.Name = "ServerIp"
         Me.ServerIp.Size = New System.Drawing.Size(208, 20)
         Me.ServerIp.TabIndex = 3
         '
         'ServerPort
         '
         Me.ServerPort.Location = New System.Drawing.Point(128, 88)
         Me.ServerPort.Name = "ServerPort"
         Me.ServerPort.Size = New System.Drawing.Size(208, 20)
         Me.ServerPort.TabIndex = 5
         '
         'ServerAE
         '
         Me.ServerAE.Location = New System.Drawing.Point(128, 24)
         Me.ServerAE.Name = "ServerAE"
         Me.ServerAE.Size = New System.Drawing.Size(208, 20)
         Me.ServerAE.TabIndex = 1
         '
         'label3
         '
         Me.label3.Location = New System.Drawing.Point(16, 88)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(100, 23)
         Me.label3.TabIndex = 4
         Me.label3.Text = "Server Port No.:"
         '
         'label2
         '
         Me.label2.Location = New System.Drawing.Point(16, 56)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(100, 23)
         Me.label2.TabIndex = 2
         Me.label2.Text = "Server IP Address:"
         '
         'label1
         '
         Me.label1.Location = New System.Drawing.Point(16, 24)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(100, 23)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Server AE Name:"
         '
         'groupBox2
         '
         Me.groupBox2.Controls.Add(Me.ClientPort)
         Me.groupBox2.Controls.Add(Me.label4)
         Me.groupBox2.Controls.Add(Me.Timeout)
         Me.groupBox2.Controls.Add(Me.ClientAE)
         Me.groupBox2.Controls.Add(Me.label5)
         Me.groupBox2.Controls.Add(Me.label6)
         Me.groupBox2.Location = New System.Drawing.Point(8, 136)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(344, 120)
         Me.groupBox2.TabIndex = 1
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "Client Information"
         '
         'ClientPort
         '
         Me.ClientPort.Location = New System.Drawing.Point(128, 88)
         Me.ClientPort.Name = "ClientPort"
         Me.ClientPort.Size = New System.Drawing.Size(208, 20)
         Me.ClientPort.TabIndex = 5
         '
         'label4
         '
         Me.label4.Location = New System.Drawing.Point(16, 88)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(100, 23)
         Me.label4.TabIndex = 4
         Me.label4.Text = "Client Port No.:"
         '
         'Timeout
         '
         Me.Timeout.Location = New System.Drawing.Point(128, 56)
         Me.Timeout.Name = "Timeout"
         Me.Timeout.Size = New System.Drawing.Size(208, 20)
         Me.Timeout.TabIndex = 3
         '
         'ClientAE
         '
         Me.ClientAE.Location = New System.Drawing.Point(128, 24)
         Me.ClientAE.Name = "ClientAE"
         Me.ClientAE.Size = New System.Drawing.Size(208, 20)
         Me.ClientAE.TabIndex = 1
         '
         'label5
         '
         Me.label5.Location = New System.Drawing.Point(16, 56)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(100, 23)
         Me.label5.TabIndex = 2
         Me.label5.Text = "Timeout (sec):"
         '
         'label6
         '
         Me.label6.Location = New System.Drawing.Point(16, 24)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(100, 23)
         Me.label6.TabIndex = 0
         Me.label6.Text = "Client AE Name:"
         '
         'buttonOK
         '
         Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.buttonOK.Location = New System.Drawing.Point(192, 329)
         Me.buttonOK.Name = "buttonOK"
         Me.buttonOK.Size = New System.Drawing.Size(75, 23)
         Me.buttonOK.TabIndex = 3
         Me.buttonOK.Text = "&OK"
         '
         'buttonCancel
         '
         Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.buttonCancel.Location = New System.Drawing.Point(277, 329)
         Me.buttonCancel.Name = "buttonCancel"
         Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
         Me.buttonCancel.TabIndex = 4
         Me.buttonCancel.Text = "&Cancel"
         '
         '_groupMiscellaneous
         '
         Me._groupMiscellaneous.Controls.Add(Me._checkBoxGroupLengthDataElements)
         Me._groupMiscellaneous.Location = New System.Drawing.Point(8, 262)
         Me._groupMiscellaneous.Name = "_groupMiscellaneous"
         Me._groupMiscellaneous.Size = New System.Drawing.Size(344, 53)
         Me._groupMiscellaneous.TabIndex = 2
         Me._groupMiscellaneous.TabStop = False
         Me._groupMiscellaneous.Text = "Miscellaneous"
         '
         '_checkBoxGroupLengthDataElements
         '
         Me._checkBoxGroupLengthDataElements.AutoSize = True
         Me._checkBoxGroupLengthDataElements.Location = New System.Drawing.Point(15, 20)
         Me._checkBoxGroupLengthDataElements.Name = "_checkBoxGroupLengthDataElements"
         Me._checkBoxGroupLengthDataElements.Size = New System.Drawing.Size(201, 17)
         Me._checkBoxGroupLengthDataElements.TabIndex = 0
         Me._checkBoxGroupLengthDataElements.Text = "Include Group Length Data Elements"
         Me._checkBoxGroupLengthDataElements.UseVisualStyleBackColor = True
         '
         'OptionsDialog
         '
         Me.AcceptButton = Me.buttonOK
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me.buttonCancel
         Me.ClientSize = New System.Drawing.Size(360, 358)
         Me.Controls.Add(Me._groupMiscellaneous)
         Me.Controls.Add(Me.buttonCancel)
         Me.Controls.Add(Me.buttonOK)
         Me.Controls.Add(Me.groupBox2)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Name = "OptionsDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "Options"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me._groupMiscellaneous.ResumeLayout(False)
         Me._groupMiscellaneous.PerformLayout()
         Me.ResumeLayout(False)

      End Sub
#End Region


      Private Sub ServerIp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ServerIp.KeyPress
         If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "."c) Then
            e.Handled = True
         End If
      End Sub


      Private Sub Port_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ServerPort.KeyPress, ClientPort.KeyPress, Timeout.KeyPress
         If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
            e.Handled = True
         End If
      End Sub


      Private Sub ParseError(ByVal tb As TextBox, ByVal fieldName As String, ByVal ex As Exception)
         Dim message As String = String.Format("Please enter a valid value for '{0}'{1}Error: {2}", fieldName, Environment.NewLine, ex.Message)
         MessageBox.Show(Me, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         tb.Focus()
         DialogResult = Windows.Forms.DialogResult.None
      End Sub

      Private Function CheckFormat(ByVal tb As TextBox, ByVal fieldName As String, ByVal ipAddress As Boolean) As Boolean
         Try
            If ipAddress Then
               System.Net.IPAddress.Parse(tb.Text)
            Else
               Convert.ToInt32(tb.Text)
            End If

            Return True
         Catch ex As FormatException
            ParseError(tb, fieldName, ex)
            Return False
         Catch ex As OverflowException
            ParseError(tb, fieldName, ex)
            Return False
         End Try
      End Function

      Public Property GroupLengthDataElements() As Boolean
         Get
            Return _checkBoxGroupLengthDataElements.Checked
         End Get
         Set(ByVal value As Boolean)
            _checkBoxGroupLengthDataElements.Checked = value
         End Set
      End Property

      Private Sub buttonOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonOK.Click
         If (Not CheckFormat(ServerPort, "Server Port No.", False)) Then
            Return
         End If
         If (Not CheckFormat(Timeout, "Timeout", False)) Then
            Return
         End If
         If (Not CheckFormat(ServerIp, "Server IP Address", True)) Then
            Return
         End If
         If (Not CheckFormat(ClientPort, "Client Port No.", True)) Then
            Return
         End If
      End Sub

      Private Sub OptionsDialog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
#If (Not LEADTOOLS_V19_OR_LATER) Then
   Me._groupMiscellaneous.Visible = False
#End If
      End Sub
   End Class
End Namespace
