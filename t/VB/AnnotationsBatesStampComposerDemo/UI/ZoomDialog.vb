' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing.Imaging

''' <summary>
''' Summary description for ZoomDialog.
''' </summary>
Public Class ZoomDialog
   Inherits System.Windows.Forms.Form
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _btnCancel As System.Windows.Forms.Button
   Private _lblZoom As System.Windows.Forms.Label
   Private WithEvents _tbPercentage As System.Windows.Forms.TextBox
   Private WithEvents _tbZoom As System.Windows.Forms.TrackBar
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.Container = Nothing

   Public Sub New()
      '
      ' Required for Windows Form Designer support
      '

      '
      ' TODO: Add any constructor code after InitializeComponent call
      '
      InitializeComponent()
   End Sub

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing Then
         If components IsNot Nothing Then
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
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._lblZoom = New System.Windows.Forms.Label()
      Me._tbPercentage = New System.Windows.Forms.TextBox()
      Me._tbZoom = New System.Windows.Forms.TrackBar()
      CType(Me._tbZoom, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(304, 16)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.TabIndex = 3
      Me._btnOk.Text = "OK"
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(304, 48)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.TabIndex = 4
      Me._btnCancel.Text = "Cancel"
      ' 
      ' _lblZoom
      ' 
      Me._lblZoom.Location = New System.Drawing.Point(16, 15)
      Me._lblZoom.Name = "_lblZoom"
      Me._lblZoom.Size = New System.Drawing.Size(72, 23)
      Me._lblZoom.TabIndex = 0
      Me._lblZoom.Text = "&Percentage:"
      Me._lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _tbPercentage
      ' 
      Me._tbPercentage.Location = New System.Drawing.Point(96, 16)
      Me._tbPercentage.Name = "_tbPercentage"
      Me._tbPercentage.TabIndex = 1
      Me._tbPercentage.Text = ""
      ' 
      ' _tbZoom
      ' 
      Me._tbZoom.Location = New System.Drawing.Point(16, 48)
      Me._tbZoom.Maximum = 30000
      Me._tbZoom.Minimum = 5
      Me._tbZoom.Name = "_tbZoom"
      Me._tbZoom.Size = New System.Drawing.Size(264, 42)
      Me._tbZoom.TabIndex = 2
      Me._tbZoom.TickStyle = System.Windows.Forms.TickStyle.None
      Me._tbZoom.Value = 5
      ' 
      ' ZoomDialog
      ' 
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(394, 101)
      Me.Controls.Add(Me._tbZoom)
      Me.Controls.Add(Me._tbPercentage)
      Me.Controls.Add(Me._lblZoom)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ZoomDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Zoom"
      CType(Me._tbZoom, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
#End Region

   Public Value As Integer
   Public MinimumValue As Integer
   Public MaximumValue As Integer

   Private Sub ZoomDialog_Load(sender As Object, e As System.EventArgs)Handles Me.Load
      _tbZoom.Minimum = MinimumValue
      _tbZoom.Maximum = MaximumValue
      _tbPercentage.Text = Value.ToString()
   End Sub

   Private Sub _tbPercentage_TextChanged(sender As Object, e As System.EventArgs)Handles _tbPercentage.TextChanged
      Try
         Dim val As Integer = Integer.Parse(_tbPercentage.Text)
         If val >= _tbZoom.Minimum AndAlso val <= _tbZoom.Maximum Then
            _tbZoom.Value = val
         End If
      Catch
      End Try
   End Sub

   Private Sub _tbPercentage_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)Handles _tbPercentage.KeyPress
      If Not e.Handled Then
         If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
         End If
      End If
   End Sub

   Private Sub _tbZoom_Scroll(sender As Object, e As System.EventArgs)Handles _tbZoom.Scroll
      _tbPercentage.Text = _tbZoom.Value.ToString()
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As System.EventArgs)Handles _btnOk.Click
      Value = _tbZoom.Value
   End Sub
End Class
