' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms


''' <summary>
''' Summary description for BrushDialog.
''' </summary>
Public Class BrushDialog : Inherits System.Windows.Forms.Form
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _cbUse As System.Windows.Forms.CheckBox
   Private WithEvents _btnColor As System.Windows.Forms.Button
   Private _pnlColor As System.Windows.Forms.Panel
   Private _lblColor As System.Windows.Forms.Label
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
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._cbUse = New System.Windows.Forms.CheckBox()
      Me._btnColor = New System.Windows.Forms.Button()
      Me._pnlColor = New System.Windows.Forms.Panel()
      Me._lblColor = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(200, 16)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.TabIndex = 4
      Me._btnOk.Text = "OK"
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(200, 48)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.TabIndex = 5
      Me._btnCancel.Text = "Cancel"
      ' 
      ' _cbUse
      ' 
      Me._cbUse.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._cbUse.Location = New System.Drawing.Point(24, 16)
      Me._cbUse.Name = "_cbUse"
      Me._cbUse.Size = New System.Drawing.Size(64, 24)
      Me._cbUse.TabIndex = 0
      Me._cbUse.Text = "&Use"
      ' 
      ' _btnColor
      ' 
      Me._btnColor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnColor.Location = New System.Drawing.Point(120, 48)
      Me._btnColor.Name = "_btnColor"
      Me._btnColor.Size = New System.Drawing.Size(32, 23)
      Me._btnColor.TabIndex = 3
      Me._btnColor.Text = "&..."
      ' 
      ' _pnlColor
      ' 
      Me._pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._pnlColor.Location = New System.Drawing.Point(80, 48)
      Me._pnlColor.Name = "_pnlColor"
      Me._pnlColor.Size = New System.Drawing.Size(40, 23)
      Me._pnlColor.TabIndex = 2
      ' 
      ' _lblColor
      ' 
      Me._lblColor.Location = New System.Drawing.Point(24, 48)
      Me._lblColor.Name = "_lblColor"
      Me._lblColor.Size = New System.Drawing.Size(48, 23)
      Me._lblColor.TabIndex = 1
      Me._lblColor.Text = "&Color:"
      Me._lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' BrushDialog
      ' 
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(290, 85)
      Me.Controls.Add(Me._btnColor)
      Me.Controls.Add(Me._pnlColor)
      Me.Controls.Add(Me._lblColor)
      Me.Controls.Add(Me._cbUse)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "BrushDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Brush"
      Me.ResumeLayout(False)

   End Sub
#End Region

   Public BrushUse As Boolean
   Public BrushColor As Color

   ''' <summary>
   ''' Load event, fill in the controls
   ''' </summary>
   Private Sub BrushDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs)Handles Me.Load
      _cbUse.Checked = BrushUse
      _pnlColor.BackColor = BrushColor
      UpdateMyControls()
   End Sub

   ''' <summary>
   ''' enable/diable the color controls based on the check box status
   ''' </summary>
   Private Sub UpdateMyControls()
      _lblColor.Enabled = _btnColor.Enabled = _pnlColor.Enabled = _cbUse.Checked
   End Sub

   ''' <summary>
   ''' Show the color dialog, update the panel back color
   ''' </summary>
   Private Sub _btnColor_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _btnColor.Click
      Dim dlg As ColorDialog = New ColorDialog()
      dlg.Color = _pnlColor.BackColor
      If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
         _pnlColor.BackColor = dlg.Color
      End If
   End Sub

   ''' <summary>
   ''' Dont forget to update the controls
   ''' </summary>
   Private Sub _cbUse_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)Handles _cbUse.CheckedChanged
      UpdateMyControls()
   End Sub

   ''' <summary>
   ''' Get the brush usage and color from the controls back to the public variables
   ''' </summary>
   Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _btnOk.Click
      ' Notice, we dont need any try catch like we did in the pen dialog
      BrushUse = _cbUse.Checked
      BrushColor = _pnlColor.BackColor
   End Sub
End Class
