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

Namespace PrintToPACSDemo
   Partial Public Class InputDialog : Inherits Form
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

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
   Me.button1 = New System.Windows.Forms.Button()
   Me._lblCaption = New System.Windows.Forms.Label()
   Me._txtValue = New System.Windows.Forms.TextBox()
   Me.button2 = New System.Windows.Forms.Button()
   Me.SuspendLayout()
   ' 
   ' button1
   ' 
   Me.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
   Me.button1.Location = New System.Drawing.Point(162, 118)
   Me.button1.Name = "button1"
   Me.button1.Size = New System.Drawing.Size(75, 23)
   Me.button1.TabIndex = 2
   Me.button1.Text = "Cancel"
   Me.button1.UseVisualStyleBackColor = True
   ' 
   ' _lblCaption
   ' 
   Me._lblCaption.AutoSize = True
   Me._lblCaption.Location = New System.Drawing.Point(12, 18)
   Me._lblCaption.Name = "_lblCaption"
   Me._lblCaption.Size = New System.Drawing.Size(35, 13)
   Me._lblCaption.TabIndex = 0
   Me._lblCaption.Text = "label1"
   ' 
   ' _txtValue
   ' 
   Me._txtValue.Location = New System.Drawing.Point(81, 60)
   Me._txtValue.Name = "_txtValue"
   Me._txtValue.Size = New System.Drawing.Size(225, 20)
   Me._txtValue.TabIndex = 0
'		 Me._txtValue.KeyDown += New System.Windows.Forms.KeyEventHandler(Me._txtValue_KeyDown);
   ' 
   ' button2
   ' 
   Me.button2.DialogResult = System.Windows.Forms.DialogResult.OK
   Me.button2.Location = New System.Drawing.Point(81, 118)
   Me.button2.Name = "button2"
   Me.button2.Size = New System.Drawing.Size(75, 23)
   Me.button2.TabIndex = 1
   Me.button2.Text = "OK"
   Me.button2.UseVisualStyleBackColor = True
   ' 
   ' InputDialog
   ' 
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.ClientSize = New System.Drawing.Size(322, 153)
   Me.Controls.Add(Me.button2)
   Me.Controls.Add(Me._txtValue)
   Me.Controls.Add(Me._lblCaption)
   Me.Controls.Add(Me.button1)
   Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
   Me.MaximizeBox = False
   Me.Name = "InputDialog"
   Me.ResumeLayout(False)
   Me.PerformLayout()

   End Sub

#End Region

   Private button1 As System.Windows.Forms.Button
   Private _lblCaption As System.Windows.Forms.Label
   Private WithEvents _txtValue As System.Windows.Forms.TextBox
   Private button2 As System.Windows.Forms.Button

   Public ReadOnly Property Value() As String
   Get
   Return _txtValue.Text
   End Get
   End Property

   Public Sub New(ByVal DialogTittle As String, ByVal DialogPromt As String, ByVal DialogDefaultValue As String)
   InitializeComponent()
   Me.StartPosition = FormStartPosition.CenterScreen
   Me.Text = DialogTittle
   _lblCaption.Text = DialogPromt
   _txtValue.Text = DialogDefaultValue
   _txtValue.Focus()
   _txtValue.SelectAll()
   End Sub

   Private Sub _txtValue_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles _txtValue.KeyDown
   If e.KeyCode = Keys.Enter Then
   DialogResult = DialogResult.OK
   End If
   If e.KeyCode = Keys.Escape Then
   DialogResult = DialogResult.Cancel
   End If
   End Sub

   End Class
End Namespace
