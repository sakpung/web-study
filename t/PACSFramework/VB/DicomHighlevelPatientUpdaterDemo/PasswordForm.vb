' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for PasswordForm.
   ''' </summary>
   Public Class PasswordForm : Inherits System.Windows.Forms.Form
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private button2 As System.Windows.Forms.Button
      Private WithEvents textBoxPassword As System.Windows.Forms.TextBox
      Private WithEvents textBoxVerify As System.Windows.Forms.TextBox
      Private buttonOk As System.Windows.Forms.Button
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public ReadOnly Property NewPassword() As String
         Get
            Return textBoxPassword.Text
         End Get
      End Property

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         ''
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PasswordForm))
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.textBoxPassword = New System.Windows.Forms.TextBox()
         Me.textBoxVerify = New System.Windows.Forms.TextBox()
         Me.buttonOk = New System.Windows.Forms.Button()
         Me.button2 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.Location = New System.Drawing.Point(16, 24)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(88, 16)
         Me.label1.TabIndex = 0
         Me.label1.Text = "New Password:"
         ' 
         ' label2
         ' 
         Me.label2.Location = New System.Drawing.Point(16, 60)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(96, 16)
         Me.label2.TabIndex = 1
         Me.label2.Text = "Verify Password:"
         ' 
         ' textBoxPassword
         ' 
         Me.textBoxPassword.Location = New System.Drawing.Point(120, 24)
         Me.textBoxPassword.Name = "textBoxPassword"
         Me.textBoxPassword.PasswordChar = "*"c
         Me.textBoxPassword.Size = New System.Drawing.Size(208, 20)
         Me.textBoxPassword.TabIndex = 2
         '		 Me.textBoxPassword.TextChanged += New System.EventHandler(Me.CheckPassword);
         ' 
         ' textBoxVerify
         ' 
         Me.textBoxVerify.Location = New System.Drawing.Point(120, 56)
         Me.textBoxVerify.Name = "textBoxVerify"
         Me.textBoxVerify.PasswordChar = "*"c
         Me.textBoxVerify.Size = New System.Drawing.Size(208, 20)
         Me.textBoxVerify.TabIndex = 3
         '		 Me.textBoxVerify.TextChanged += New System.EventHandler(Me.CheckPassword);
         ' 
         ' buttonOk
         ' 
         Me.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.buttonOk.Enabled = False
         Me.buttonOk.Location = New System.Drawing.Point(96, 96)
         Me.buttonOk.Name = "buttonOk"
         Me.buttonOk.Size = New System.Drawing.Size(75, 23)
         Me.buttonOk.TabIndex = 4
         Me.buttonOk.Text = "OK"
         ' 
         ' button2
         ' 
         Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.button2.Location = New System.Drawing.Point(184, 96)
         Me.button2.Name = "button2"
         Me.button2.Size = New System.Drawing.Size(75, 23)
         Me.button2.TabIndex = 5
         Me.button2.Text = "Cancel"
         ' 
         ' PasswordForm
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(352, 127)
         Me.Controls.Add(Me.button2)
         Me.Controls.Add(Me.buttonOk)
         Me.Controls.Add(Me.textBoxVerify)
         Me.Controls.Add(Me.textBoxPassword)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.label1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "PasswordForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "Enter new application password"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
#End Region

      Private Sub CheckPassword(ByVal sender As Object, ByVal e As System.EventArgs) Handles textBoxPassword.TextChanged, textBoxVerify.TextChanged
         buttonOk.Enabled = (textBoxPassword.Text <> "" AndAlso textBoxVerify.Text <> "") AndAlso (textBoxPassword.Text = textBoxVerify.Text)
      End Sub
   End Class
End Namespace
