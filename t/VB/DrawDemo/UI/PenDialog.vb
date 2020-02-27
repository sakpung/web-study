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
''' Summary description for PenDialog.
''' </summary>
Public Class PenDialog : Inherits System.Windows.Forms.Form
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _btnCancel As System.Windows.Forms.Button
   Private _lblWidth As System.Windows.Forms.Label
   Private WithEvents _tbWidth As System.Windows.Forms.TextBox
   Private _lblColor As System.Windows.Forms.Label
   Private _pnlColor As System.Windows.Forms.Panel
   Private WithEvents _btnColor As System.Windows.Forms.Button
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
      Me._lblWidth = New System.Windows.Forms.Label()
      Me._tbWidth = New System.Windows.Forms.TextBox()
      Me._lblColor = New System.Windows.Forms.Label()
      Me._pnlColor = New System.Windows.Forms.Panel()
      Me._btnColor = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(200, 16)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.TabIndex = 5
      Me._btnOk.Text = "OK"
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(200, 48)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.TabIndex = 6
      Me._btnCancel.Text = "Cancel"
      ' 
      ' _lblWidth
      ' 
      Me._lblWidth.Location = New System.Drawing.Point(16, 16)
      Me._lblWidth.Name = "_lblWidth"
      Me._lblWidth.Size = New System.Drawing.Size(48, 23)
      Me._lblWidth.TabIndex = 0
      Me._lblWidth.Text = "&Width:"
      Me._lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _tbWidth
      ' 
      Me._tbWidth.Location = New System.Drawing.Point(72, 16)
      Me._tbWidth.Name = "_tbWidth"
      Me._tbWidth.TabIndex = 2
      Me._tbWidth.Text = ""
      ' 
      ' _lblColor
      ' 
      Me._lblColor.Location = New System.Drawing.Point(16, 48)
      Me._lblColor.Name = "_lblColor"
      Me._lblColor.Size = New System.Drawing.Size(48, 23)
      Me._lblColor.TabIndex = 1
      Me._lblColor.Text = "&Color:"
      Me._lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _pnlColor
      ' 
      Me._pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._pnlColor.Location = New System.Drawing.Point(72, 48)
      Me._pnlColor.Name = "_pnlColor"
      Me._pnlColor.Size = New System.Drawing.Size(40, 23)
      Me._pnlColor.TabIndex = 3
      ' 
      ' _btnColor
      ' 
      Me._btnColor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnColor.Location = New System.Drawing.Point(112, 48)
      Me._btnColor.Name = "_btnColor"
      Me._btnColor.Size = New System.Drawing.Size(32, 23)
      Me._btnColor.TabIndex = 4
      Me._btnColor.Text = "&..."
      ' 
      ' PenDialog
      ' 
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(290, 85)
      Me.Controls.Add(Me._btnColor)
      Me.Controls.Add(Me._pnlColor)
      Me.Controls.Add(Me._lblColor)
      Me.Controls.Add(Me._tbWidth)
      Me.Controls.Add(Me._lblWidth)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PenDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Pen"
      Me.ResumeLayout(False)

   End Sub
#End Region

   Public PenWidth As Integer
   Public PenColor As Color

   ''' <summary>
   ''' Load event, fill in the controls
   ''' </summary>
   Private Sub PenDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs)Handles Me.Load
      _tbWidth.Text = PenWidth.ToString()
      _pnlColor.BackColor = PenColor
   End Sub

   ''' <summary>
   ''' Allow only numbers of control keys for this text box
   ''' </summary>
   Private Sub _tbWidth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)Handles _tbWidth.KeyPress
      If (Not Char.IsNumber(e.KeyChar)) AndAlso (Not Char.IsControl(e.KeyChar)) Then
         e.Handled = True
      End If
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
   ''' Get the pen width and color from the controls back to the public variables
   ''' </summary>
   Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _btnOk.Click
      ' see if we have a valid integer between 0 and 20
      Try
         Dim val As Integer = Integer.Parse(_tbWidth.Text)
         If val <= 0 OrElse val > 20 Then
            Throw New ApplicationException("Width should be between 1 and 20")
         End If

         ' all ok now
         PenWidth = val
         PenColor = _pnlColor.BackColor
      Catch ex As Exception
         Messager.ShowError(Me, ex)

         ' stop the dialog from shutting down
         DialogResult = DialogResult.None
      End Try
   End Sub
End Class
