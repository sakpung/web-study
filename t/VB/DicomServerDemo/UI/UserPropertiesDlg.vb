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

Imports Leadtools.Demos.Database

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for UserProperties.
   ''' </summary>
   Public Class UserPropertiesDlg : Inherits System.Windows.Forms.Form
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private textBoxAETitle As System.Windows.Forms.TextBox
      Private textBoxIPAddress As System.Windows.Forms.TextBox
      Private numericUpDownPort As System.Windows.Forms.NumericUpDown
      Private label4 As System.Windows.Forms.Label
      Private numericUpDownTimeout As System.Windows.Forms.NumericUpDown
      Private buttonOK As System.Windows.Forms.Button
      Private buttonCancel As System.Windows.Forms.Button
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Private _Edit As Boolean = False
      Private label5 As System.Windows.Forms.Label
      Private _User As UserInfo

      Public Property Edit() As Boolean
         Get
            Return _Edit
         End Get
         Set(ByVal value As Boolean)
            If Value Then
               Text = "Modify User"
            Else
               Text = "Add User"
            End If
            _Edit = Value
         End Set
      End Property

      Public Property User() As UserInfo
         Get
            Return _User
         End Get
         Set(ByVal value As UserInfo)
            _User = Value
         End Set
      End Property

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
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.textBoxAETitle = New System.Windows.Forms.TextBox()
         Me.textBoxIPAddress = New System.Windows.Forms.TextBox()
         Me.numericUpDownPort = New System.Windows.Forms.NumericUpDown()
         Me.label4 = New System.Windows.Forms.Label()
         Me.numericUpDownTimeout = New System.Windows.Forms.NumericUpDown()
         Me.buttonOK = New System.Windows.Forms.Button()
         Me.buttonCancel = New System.Windows.Forms.Button()
         Me.label5 = New System.Windows.Forms.Label()
         CType(Me.numericUpDownPort, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.numericUpDownTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.Location = New System.Drawing.Point(8, 8)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(64, 23)
         Me.label1.TabIndex = 0
         Me.label1.Text = "AE Title:"
         ' 
         ' label2
         ' 
         Me.label2.Location = New System.Drawing.Point(8, 40)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(64, 23)
         Me.label2.TabIndex = 1
         Me.label2.Text = "IP Address:"
         ' 
         ' label3
         ' 
         Me.label3.Location = New System.Drawing.Point(8, 72)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(64, 23)
         Me.label3.TabIndex = 2
         Me.label3.Text = "Port No:"
         ' 
         ' textBoxAETitle
         ' 
         Me.textBoxAETitle.Location = New System.Drawing.Point(80, 8)
         Me.textBoxAETitle.Name = "textBoxAETitle"
         Me.textBoxAETitle.Size = New System.Drawing.Size(232, 20)
         Me.textBoxAETitle.TabIndex = 3
         Me.textBoxAETitle.Text = ""
         ' 
         ' textBoxIPAddress
         ' 
         Me.textBoxIPAddress.Location = New System.Drawing.Point(80, 40)
         Me.textBoxIPAddress.Name = "textBoxIPAddress"
         Me.textBoxIPAddress.Size = New System.Drawing.Size(232, 20)
         Me.textBoxIPAddress.TabIndex = 4
         Me.textBoxIPAddress.Text = ""
         ' 
         ' numericUpDownPort
         ' 
         Me.numericUpDownPort.Location = New System.Drawing.Point(80, 72)
         Me.numericUpDownPort.Maximum = New System.Decimal(New Integer() {10000, 0, 0, 0})
         Me.numericUpDownPort.Minimum = New System.Decimal(New Integer() {1, 0, 0, 0})
         Me.numericUpDownPort.Name = "numericUpDownPort"
         Me.numericUpDownPort.Size = New System.Drawing.Size(56, 20)
         Me.numericUpDownPort.TabIndex = 5
         Me.numericUpDownPort.Value = New System.Decimal(New Integer() {1, 0, 0, 0})
         ' 
         ' label4
         ' 
         Me.label4.Location = New System.Drawing.Point(8, 104)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(64, 23)
         Me.label4.TabIndex = 6
         Me.label4.Text = "Timeout:"
         ' 
         ' numericUpDownTimeout
         ' 
         Me.numericUpDownTimeout.Location = New System.Drawing.Point(80, 104)
         Me.numericUpDownTimeout.Maximum = New System.Decimal(New Integer() {5, 0, 0, 0})
         Me.numericUpDownTimeout.Name = "numericUpDownTimeout"
         Me.numericUpDownTimeout.Size = New System.Drawing.Size(56, 20)
         Me.numericUpDownTimeout.TabIndex = 7
         Me.numericUpDownTimeout.Value = New System.Decimal(New Integer() {1, 0, 0, 0})
         ' 
         ' buttonOK
         ' 
         Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.buttonOK.Location = New System.Drawing.Point(160, 136)
         Me.buttonOK.Name = "buttonOK"
         Me.buttonOK.TabIndex = 8
         Me.buttonOK.Text = "OK"
         ' 
         ' buttonCancel
         ' 
         Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.buttonCancel.Location = New System.Drawing.Point(240, 136)
         Me.buttonCancel.Name = "buttonCancel"
         Me.buttonCancel.TabIndex = 9
         Me.buttonCancel.Text = "Cancel"
         ' 
         ' label5
         ' 
         Me.label5.Location = New System.Drawing.Point(144, 104)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(100, 16)
         Me.label5.TabIndex = 10
         Me.label5.Text = "minutes"
         ' 
         ' UserPropertiesDlg
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(322, 167)
         Me.Controls.Add(Me.label5)
         Me.Controls.Add(Me.buttonCancel)
         Me.Controls.Add(Me.buttonOK)
         Me.Controls.Add(Me.numericUpDownTimeout)
         Me.Controls.Add(Me.label4)
         Me.Controls.Add(Me.numericUpDownPort)
         Me.Controls.Add(Me.textBoxIPAddress)
         Me.Controls.Add(Me.textBoxAETitle)
         Me.Controls.Add(Me.label3)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.label1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "UserPropertiesDlg"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "UserProperties"
         '            Me.Load += New System.EventHandler(Me.UserPropertiesDlg_Load);
         '            Me.Closed += New System.EventHandler(Me.UserPropertiesDlg_Closed);
         CType(Me.numericUpDownPort, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.numericUpDownTimeout, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Sub UserPropertiesDlg_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
         If (Not Edit) Then
            _User = New UserInfo()
         End If

         _User.AETitle = textBoxAETitle.Text
         _User.IPAddress = textBoxIPAddress.Text
         _User.Port = Convert.ToInt32(numericUpDownPort.Value)
         _User.Timeout = Convert.ToInt32(numericUpDownTimeout.Value)
      End Sub

      Private Sub UserPropertiesDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If Edit Then
            textBoxAETitle.Text = _User.AETitle
            textBoxIPAddress.Text = _User.IPAddress
            numericUpDownPort.Value = Convert.ToDecimal(_User.Port)
            numericUpDownTimeout.Value = Convert.ToDecimal(_User.Timeout)
         Else
            numericUpDownPort.Value = 1000
            numericUpDownTimeout.Value = 1
         End If
      End Sub
   End Class
End Namespace
