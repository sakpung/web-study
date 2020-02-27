' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools

Namespace BasicFeaturesDemo
   ''' <summary>
   ''' Summary description for UnderlayDialog.
   ''' </summary>
   Public Class UnderlayDialog : Inherits System.Windows.Forms.Form
      Private _gbOptions As System.Windows.Forms.GroupBox
      Private _rbTile As System.Windows.Forms.RadioButton
      Private _rbStretch As System.Windows.Forms.RadioButton
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOk As System.Windows.Forms.Button
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
         Me._gbOptions = New System.Windows.Forms.GroupBox()
         Me._rbTile = New System.Windows.Forms.RadioButton()
         Me._rbStretch = New System.Windows.Forms.RadioButton()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._gbOptions.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _gbOptions
         ' 
         Me._gbOptions.Controls.Add(Me._rbTile)
         Me._gbOptions.Controls.Add(Me._rbStretch)
         Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbOptions.Location = New System.Drawing.Point(7, 6)
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.Size = New System.Drawing.Size(136, 88)
         Me._gbOptions.TabIndex = 0
         Me._gbOptions.TabStop = False
         ' 
         ' _rbTile
         ' 
         Me._rbTile.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._rbTile.Location = New System.Drawing.Point(16, 56)
         Me._rbTile.Name = "_rbTile"
         Me._rbTile.TabIndex = 1
         Me._rbTile.Text = "Tile"
         ' 
         ' _rbStretch
         ' 
         Me._rbStretch.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._rbStretch.Location = New System.Drawing.Point(16, 24)
         Me._rbStretch.Name = "_rbStretch"
         Me._rbStretch.TabIndex = 0
         Me._rbStretch.Text = "Stretch"
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(167, 46)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "Cancel"
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(167, 14)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.TabIndex = 1
         Me._btnOk.Text = "OK"
         ' 
         ' UnderlayDialog
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(250, 103)
         Me.Controls.Add(Me._gbOptions)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "UnderlayDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Underlay"
         Me._gbOptions.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Shared _firstTimer As Boolean = True
      Private Shared _initialFlags As RasterImageUnderlayFlags
      Public Flags As RasterImageUnderlayFlags

      Private Sub UnderlayDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs)Handles Me.Load
         If _firstTimer Then
            _firstTimer = False
            _initialFlags = RasterImageUnderlayFlags.Stretch
         End If

         Flags = _initialFlags
         _rbStretch.Checked = (Flags And RasterImageUnderlayFlags.Stretch) = RasterImageUnderlayFlags.Stretch
         _rbTile.Checked = (Flags And RasterImageUnderlayFlags.None) = RasterImageUnderlayFlags.None
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _btnOk.Click
         If _rbStretch.Checked Then
            Flags = RasterImageUnderlayFlags.Stretch
         End If
         If _rbTile.Checked Then
            Flags = RasterImageUnderlayFlags.None
         End If

         _initialFlags = Flags
      End Sub
   End Class
End Namespace
