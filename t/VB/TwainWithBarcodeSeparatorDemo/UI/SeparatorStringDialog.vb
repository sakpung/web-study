' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace TwainWithBarcodeSeparatorDemo
   Partial Public Class SeperatorStringDialog : Inherits Form
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      Public Sub New()
         InitializeComponent()

         _seperatorString = "seperator"
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
         Me._lblSeperatorString = New System.Windows.Forms.Label()
         Me._txtSeperatorString = New System.Windows.Forms.TextBox()
         Me._btnOK = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' _lblSeperatorString
         ' 
         Me._lblSeperatorString.AutoSize = True
         Me._lblSeperatorString.Location = New System.Drawing.Point(10, 22)
         Me._lblSeperatorString.Name = "_lblSeperatorString"
         Me._lblSeperatorString.Size = New System.Drawing.Size(83, 13)
         Me._lblSeperatorString.TabIndex = 0
         Me._lblSeperatorString.Text = "Seperator String"
         ' 
         ' _txtSeperatorString
         ' 
         Me._txtSeperatorString.Location = New System.Drawing.Point(99, 19)
         Me._txtSeperatorString.Name = "_txtSeperatorString"
         Me._txtSeperatorString.Size = New System.Drawing.Size(189, 20)
         Me._txtSeperatorString.TabIndex = 1
         '		 Me._txtSeperatorString.TextChanged += New System.EventHandler(Me._txtSeperatorString_TextChanged);
         ' 
         ' _btnOK
         ' 
         Me._btnOK.Location = New System.Drawing.Point(213, 52)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(75, 23)
         Me._btnOK.TabIndex = 1
         Me._btnOK.Text = "OK"
         Me._btnOK.UseVisualStyleBackColor = True
         '		 Me._btnOK.Click += New System.EventHandler(Me._btnOK_Click);
         ' 
         ' SeperatorStringDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(303, 82)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me._txtSeperatorString)
         Me.Controls.Add(Me._lblSeperatorString)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
         Me.Name = "SeperatorStringDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Set Seperator String"
         '		 Me.Load += New System.EventHandler(Me.SeperatorStringDialog_Load);
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _lblSeperatorString As System.Windows.Forms.Label
      Private WithEvents _txtSeperatorString As System.Windows.Forms.TextBox
      Private WithEvents _btnOK As System.Windows.Forms.Button

      Private _seperatorString As String

      Public Property SeperatorString() As String
         Get
            Return _seperatorString
         End Get
         Set(ByVal value As String)
            _seperatorString = Value
         End Set
      End Property

      Private Sub SeperatorStringDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Me._txtSeperatorString.Text = _seperatorString
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         _seperatorString = Me._txtSeperatorString.Text
         Me.DialogResult = DialogResult.OK
      End Sub

      Private Sub _txtSeperatorString_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtSeperatorString.TextChanged
         Me._btnOK.Enabled = Me._txtSeperatorString.Text.Length > 0
      End Sub
   End Class
End Namespace
