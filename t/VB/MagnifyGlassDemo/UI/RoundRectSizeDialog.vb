' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms


Namespace MagnifyGlassDemo
   ''' <summary>
   ''' Summary description for RoundRectSizeDialog.
   ''' </summary>
   Public Class RoundRectSizeDialog : Inherits System.Windows.Forms.Form
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _lblWidth As System.Windows.Forms.Label
      Private _lblHeight As System.Windows.Forms.Label
      Private WithEvents _numHeight As System.Windows.Forms.NumericUpDown
      Private WithEvents _numWidth As System.Windows.Forms.NumericUpDown
      Private _gbOptions As System.Windows.Forms.GroupBox
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public Sub New(ByVal width As Integer, ByVal height As Integer, ByVal maxWidth As Integer, ByVal maxHeight As Integer)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         _roundRectEllipseSize = New Size(width, height)
         _maxWidth = maxWidth
         _maxHeight = maxHeight
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
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._gbOptions = New System.Windows.Forms.GroupBox()
         Me._lblHeight = New System.Windows.Forms.Label()
         Me._lblWidth = New System.Windows.Forms.Label()
         Me._numHeight = New System.Windows.Forms.NumericUpDown()
         Me._numWidth = New System.Windows.Forms.NumericUpDown()
         Me._gbOptions.SuspendLayout()
         CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(132, 97)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "Cancel"
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(52, 97)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.TabIndex = 1
         Me._btnOk.Text = "OK"
         ' 
         ' _gbOptions
         ' 
         Me._gbOptions.Controls.Add(Me._lblHeight)
         Me._gbOptions.Controls.Add(Me._lblWidth)
         Me._gbOptions.Controls.Add(Me._numHeight)
         Me._gbOptions.Controls.Add(Me._numWidth)
         Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbOptions.Location = New System.Drawing.Point(8, 8)
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.Size = New System.Drawing.Size(243, 80)
         Me._gbOptions.TabIndex = 0
         Me._gbOptions.TabStop = False
         Me._gbOptions.Text = "Size"
         ' 
         ' _lblHeight
         ' 
         Me._lblHeight.Location = New System.Drawing.Point(127, 16)
         Me._lblHeight.Name = "_lblHeight"
         Me._lblHeight.TabIndex = 2
         Me._lblHeight.Text = "Height"
         ' 
         ' _lblWidth
         ' 
         Me._lblWidth.Location = New System.Drawing.Point(8, 16)
         Me._lblWidth.Name = "_lblWidth"
         Me._lblWidth.TabIndex = 0
         Me._lblWidth.Text = "Width"
         ' 
         ' _numHeight
         ' 
         Me._numHeight.Location = New System.Drawing.Point(127, 47)
         Me._numHeight.Name = "_numHeight"
         Me._numHeight.Size = New System.Drawing.Size(104, 20)
         Me._numHeight.TabIndex = 3
         ' 
         ' _numWidth
         ' 
         Me._numWidth.Location = New System.Drawing.Point(8, 47)
         Me._numWidth.Name = "_numWidth"
         Me._numWidth.Size = New System.Drawing.Size(104, 20)
         Me._numWidth.TabIndex = 1
         ' 
         ' RoundRectSizeDialog
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(258, 128)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me._gbOptions)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "RoundRectSizeDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Round Rectangle Ellipse Size"
         Me._gbOptions.ResumeLayout(False)
         CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private _maxWidth As Integer
      Private _maxHeight As Integer
      Private _roundRectEllipseSize As Size

      Private Sub RoundRectSizeDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         _lblWidth.Text = String.Format("Width (1..{0})", _maxWidth)
         _lblHeight.Text = String.Format("Height (1..{0})", _maxHeight)
         _numWidth.Minimum = 1
         _numWidth.Maximum = _maxWidth
         _numHeight.Minimum = 1
         _numHeight.Maximum = _maxHeight

         DialogUtilities.SetNumericValue(_numWidth, _roundRectEllipseSize.Width)
         DialogUtilities.SetNumericValue(_numHeight, _roundRectEllipseSize.Height)
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numHeight.Leave, _numWidth.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         _roundRectEllipseSize = New Size(CInt(_numWidth.Value), CInt(_numHeight.Value))
      End Sub

      Public ReadOnly Property RoundRectEllipseSize() As Size
         Get
            Return _roundRectEllipseSize
         End Get
      End Property
   End Class
End Namespace
