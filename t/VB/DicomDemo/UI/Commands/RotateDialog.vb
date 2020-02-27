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

Imports Leadtools
Imports Leadtools.ImageProcessing

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for RotateDialog.
   ''' </summary>
   Public Class RotateDialog : Inherits System.Windows.Forms.Form
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private _gbOptions As System.Windows.Forms.GroupBox
      Private _lblAngle As System.Windows.Forms.Label
      Private WithEvents _numAngle As System.Windows.Forms.NumericUpDown
      Private _lblFillColor As System.Windows.Forms.Label
      Private WithEvents _pnlFillColor As System.Windows.Forms.Panel
      Private WithEvents _btnFillColor As System.Windows.Forms.Button
      Private _gbOptionsInterpolation As System.Windows.Forms.GroupBox
      Private _cbResize As System.Windows.Forms.CheckBox
      Private _rbButtonNormal As System.Windows.Forms.RadioButton
      Private _rbButtonResample As System.Windows.Forms.RadioButton
      Private _rbButtonBicubic As System.Windows.Forms.RadioButton
      Private _lblInterpolation As System.Windows.Forms.Label
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
         Me._gbOptions = New System.Windows.Forms.GroupBox()
         Me._lblInterpolation = New System.Windows.Forms.Label()
         Me._gbOptionsInterpolation = New System.Windows.Forms.GroupBox()
         Me._cbResize = New System.Windows.Forms.CheckBox()
         Me._btnFillColor = New System.Windows.Forms.Button()
         Me._pnlFillColor = New System.Windows.Forms.Panel()
         Me._lblFillColor = New System.Windows.Forms.Label()
         Me._numAngle = New System.Windows.Forms.NumericUpDown()
         Me._lblAngle = New System.Windows.Forms.Label()
         Me._rbButtonBicubic = New System.Windows.Forms.RadioButton()
         Me._rbButtonNormal = New System.Windows.Forms.RadioButton()
         Me._rbButtonResample = New System.Windows.Forms.RadioButton()
         Me._gbOptions.SuspendLayout()
         CType(Me._numAngle, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(288, 16)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.TabIndex = 12
         Me._btnOk.Text = "OK"
         '         Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(288, 48)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.TabIndex = 13
         Me._btnCancel.Text = "Cancel"
         ' 
         ' _gbOptions
         ' 
         Me._gbOptions.Controls.Add(Me._lblInterpolation)
         Me._gbOptions.Controls.Add(Me._gbOptionsInterpolation)
         Me._gbOptions.Controls.Add(Me._cbResize)
         Me._gbOptions.Controls.Add(Me._btnFillColor)
         Me._gbOptions.Controls.Add(Me._pnlFillColor)
         Me._gbOptions.Controls.Add(Me._lblFillColor)
         Me._gbOptions.Controls.Add(Me._numAngle)
         Me._gbOptions.Controls.Add(Me._lblAngle)
         Me._gbOptions.Controls.Add(Me._rbButtonBicubic)
         Me._gbOptions.Controls.Add(Me._rbButtonNormal)
         Me._gbOptions.Controls.Add(Me._rbButtonResample)
         Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbOptions.Location = New System.Drawing.Point(8, 8)
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.Size = New System.Drawing.Size(264, 288)
         Me._gbOptions.TabIndex = 0
         Me._gbOptions.TabStop = False
         ' 
         ' _lblInterpolation
         ' 
         Me._lblInterpolation.Location = New System.Drawing.Point(16, 160)
         Me._lblInterpolation.Name = "_lblInterpolation"
         Me._lblInterpolation.TabIndex = 8
         Me._lblInterpolation.Text = "Interpolation"
         Me._lblInterpolation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _gbOptionsInterpolation
         ' 
         Me._gbOptionsInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbOptionsInterpolation.Location = New System.Drawing.Point(16, 136)
         Me._gbOptionsInterpolation.Name = "_gbOptionsInterpolation"
         Me._gbOptionsInterpolation.Size = New System.Drawing.Size(232, 8)
         Me._gbOptionsInterpolation.TabIndex = 7
         Me._gbOptionsInterpolation.TabStop = False
         ' 
         ' _cbResize
         ' 
         Me._cbResize.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._cbResize.Location = New System.Drawing.Point(16, 104)
         Me._cbResize.Name = "_cbResize"
         Me._cbResize.TabIndex = 6
         Me._cbResize.Text = "Resize"
         ' 
         ' _btnFillColor
         ' 
         Me._btnFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnFillColor.Location = New System.Drawing.Point(224, 56)
         Me._btnFillColor.Name = "_btnFillColor"
         Me._btnFillColor.Size = New System.Drawing.Size(24, 23)
         Me._btnFillColor.TabIndex = 5
         Me._btnFillColor.Text = "..."
         '         Me._btnFillColor.Click += New System.EventHandler(Me._btnFillColor_Click);
         ' 
         ' _pnlFillColor
         ' 
         Me._pnlFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._pnlFillColor.Location = New System.Drawing.Point(128, 56)
         Me._pnlFillColor.Name = "_pnlFillColor"
         Me._pnlFillColor.Size = New System.Drawing.Size(96, 24)
         Me._pnlFillColor.TabIndex = 4
         '         Me._pnlFillColor.Paint += New System.Windows.Forms.PaintEventHandler(Me._pnlFillColor_Paint);
         ' 
         ' _lblFillColor
         ' 
         Me._lblFillColor.Location = New System.Drawing.Point(16, 56)
         Me._lblFillColor.Name = "_lblFillColor"
         Me._lblFillColor.TabIndex = 3
         Me._lblFillColor.Text = "Fill Color"
         Me._lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _numAngle
         ' 
         Me._numAngle.Location = New System.Drawing.Point(128, 24)
         Me._numAngle.Maximum = New System.Decimal(New Integer() {360, 0, 0, 0})
         Me._numAngle.Minimum = New System.Decimal(New Integer() {360, 0, 0, -2147483648})
         Me._numAngle.Name = "_numAngle"
         Me._numAngle.TabIndex = 2
         '         Me._numAngle.Leave += New System.EventHandler(Me._num_Leave);
         ' 
         ' _lblAngle
         ' 
         Me._lblAngle.Location = New System.Drawing.Point(16, 24)
         Me._lblAngle.Name = "_lblAngle"
         Me._lblAngle.TabIndex = 1
         Me._lblAngle.Text = "Angle"
         Me._lblAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _rbButtonBicubic
         ' 
         Me._rbButtonBicubic.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._rbButtonBicubic.Location = New System.Drawing.Point(16, 256)
         Me._rbButtonBicubic.Name = "_rbButtonBicubic"
         Me._rbButtonBicubic.Size = New System.Drawing.Size(128, 24)
         Me._rbButtonBicubic.TabIndex = 11
         Me._rbButtonBicubic.Text = "BiCubic"
         ' 
         ' _rbButtonNormal
         ' 
         Me._rbButtonNormal.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._rbButtonNormal.Location = New System.Drawing.Point(16, 192)
         Me._rbButtonNormal.Name = "_rbButtonNormal"
         Me._rbButtonNormal.Size = New System.Drawing.Size(128, 24)
         Me._rbButtonNormal.TabIndex = 9
         Me._rbButtonNormal.Text = "Normal"
         ' 
         ' _rbButtonResample
         ' 
         Me._rbButtonResample.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._rbButtonResample.Location = New System.Drawing.Point(16, 224)
         Me._rbButtonResample.Name = "_rbButtonResample"
         Me._rbButtonResample.Size = New System.Drawing.Size(128, 24)
         Me._rbButtonResample.TabIndex = 10
         Me._rbButtonResample.Text = "Resample (Bilinear)"
         ' 
         ' RotateDialog
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(368, 303)
         Me.Controls.Add(Me._gbOptions)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "RotateDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Rotate"
         '         Me.Load += New System.EventHandler(Me.RotateDialog_Load);
         Me._gbOptions.ResumeLayout(False)
         CType(Me._numAngle, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Shared _initialAngle As Integer = 0
      Private Shared _initialFlags As RotateCommandFlags = RotateCommandFlags.None
      Private Shared _initialFillColor As RasterColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White)

      Public Angle As Integer
      Public Flags As RotateCommandFlags
      Public FillColor As RasterColor

      Private Sub RotateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Angle = CInt(_initialAngle / 100)
         Flags = _initialFlags
         FillColor = _initialFillColor

         _numAngle.Value = Angle
         _cbResize.Checked = (Flags And RotateCommandFlags.Resize) = RotateCommandFlags.Resize

         If (Flags And RotateCommandFlags.Resample) = RotateCommandFlags.Resample Then
            _rbButtonResample.Checked = True
         ElseIf (Flags And RotateCommandFlags.Bicubic) = RotateCommandFlags.Bicubic Then
            _rbButtonBicubic.Checked = True
         Else
            _rbButtonNormal.Checked = True
         End If
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numAngle.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _pnlFillColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _pnlFillColor.Paint
         e.Graphics.FillRectangle(New SolidBrush(Leadtools.Demos.Converters.ToGdiPlusColor(FillColor)), _pnlFillColor.ClientRectangle)
      End Sub

      Private Sub _btnFillColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnFillColor.Click
         If Tools.ShowColorDialog(Me, FillColor) Then
            _pnlFillColor.Refresh()
         End If
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Angle = CInt(_numAngle.Value) * 100

         Flags = RotateCommandFlags.None

         If _cbResize.Checked Then
            Flags = Flags Or RotateCommandFlags.Resize
         End If

         If _rbButtonResample.Checked Then
            Flags = Flags Or RotateCommandFlags.Resample
         End If

         If _rbButtonBicubic.Checked Then
            Flags = Flags Or RotateCommandFlags.Bicubic
         End If

         _initialAngle = Angle
         _initialFlags = Flags
         _initialFillColor = FillColor
      End Sub
   End Class
End Namespace
