' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Partial Public Class FrmPassword : Inherits Form

#Region "Windows Form Designer generated code"
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPassword))
      Me._lblPassword = New System.Windows.Forms.Label()
      Me._txtBoxPassword = New System.Windows.Forms.TextBox()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' _lblPassword
      ' 
      Me._lblPassword.AutoSize = True
      Me._lblPassword.Location = New System.Drawing.Point(3, 22)
      Me._lblPassword.Name = "_lblPassword"
      Me._lblPassword.Size = New System.Drawing.Size(81, 13)
      Me._lblPassword.TabIndex = 0
      Me._lblPassword.Text = "Enter Password"
      ' 
      ' _txtBoxPassword
      ' 
      Me._txtBoxPassword.Location = New System.Drawing.Point(91, 19)
      Me._txtBoxPassword.Name = "_txtBoxPassword"
      Me._txtBoxPassword.PasswordChar = "*"c
      Me._txtBoxPassword.Size = New System.Drawing.Size(205, 20)
      Me._txtBoxPassword.TabIndex = 1
      Me._txtBoxPassword.UseSystemPasswordChar = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.Location = New System.Drawing.Point(166, 73)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(62, 29)
      Me._btnOk.TabIndex = 7
      Me._btnOk.Text = "Ok"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(234, 73)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(62, 29)
      Me._btnCancel.TabIndex = 8
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' FrmPassword
      ' 
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(308, 105)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._txtBoxPassword)
      Me.Controls.Add(Me._lblPassword)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FrmPassword"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Printer Password"
      '		 Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.FrmPassword_FormClosing);
      '		 Me.Load += New System.EventHandler(Me.FrmPassword_Load);
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
#End Region

   Private _lblPassword As System.Windows.Forms.Label
   Private _txtBoxPassword As System.Windows.Forms.TextBox
   Private _btnOk As System.Windows.Forms.Button
   Private _btnCancel As System.Windows.Forms.Button
#End Region

#Region "Constructor..."
   Public Sub New(ByVal bLock As Boolean)
      InitializeComponent()
      _bLock = bLock
   End Sub
#End Region

#Region "Fields..."
   Private _password As String = String.Empty
   Private _bLock As Boolean = False
#End Region

#Region "Properties..."
   Public ReadOnly Property Password() As String
      Get
         Return _password
      End Get
   End Property
#End Region

#Region "Events..."
   Private Sub FrmPassword_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
      Try
         _password = _txtBoxPassword.Text
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub
#End Region

   Private Sub FrmPassword_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      Try
         Dim formTitle As String = String.Empty

         If _bLock Then
            formTitle = "Lock Printer"
         Else
            formTitle = "Unlock Printer"
         End If
         Me.Text = formTitle
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

End Class
