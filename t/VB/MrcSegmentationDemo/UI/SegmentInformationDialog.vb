' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms


Namespace MrcSegmentationDemo
   ''' <summary>
   ''' Summary description for SegmentInformation.
   ''' </summary>
   Public Class SegmentInformationDialog : Inherits System.Windows.Forms.Form
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public Sub New(ByVal segmentType As String, ByVal ImageWidth As Integer, ByVal ImageHeight As Integer)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         _txtSegmentType.Text = segmentType
         _imageWidth = ImageWidth
         _imageHeight = ImageHeight
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
         Me._lblLeft = New System.Windows.Forms.Label()
         Me._txtLeft = New System.Windows.Forms.TextBox()
         Me._txtTop = New System.Windows.Forms.TextBox()
         Me._lblTop = New System.Windows.Forms.Label()
         Me._txtRight = New System.Windows.Forms.TextBox()
         Me._lblRight = New System.Windows.Forms.Label()
         Me._txtBottom = New System.Windows.Forms.TextBox()
         Me._lblBottom = New System.Windows.Forms.Label()
         Me._txtSegmentType = New System.Windows.Forms.TextBox()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' _lblLeft
         ' 
         Me._lblLeft.Location = New System.Drawing.Point(14, 24)
         Me._lblLeft.Name = "_lblLeft"
         Me._lblLeft.Size = New System.Drawing.Size(26, 16)
         Me._lblLeft.TabIndex = 1
         Me._lblLeft.Text = "&Left"
         ' 
         ' _txtLeft
         ' 
         Me._txtLeft.Location = New System.Drawing.Point(48, 21)
         Me._txtLeft.Name = "_txtLeft"
         Me._txtLeft.Size = New System.Drawing.Size(42, 20)
         Me._txtLeft.TabIndex = 2
         Me._txtLeft.Text = ""
         ' 
         ' _txtTop
         ' 
         Me._txtTop.Location = New System.Drawing.Point(150, 21)
         Me._txtTop.Name = "_txtTop"
         Me._txtTop.Size = New System.Drawing.Size(42, 20)
         Me._txtTop.TabIndex = 4
         Me._txtTop.Text = ""
         ' 
         ' _lblTop
         ' 
         Me._lblTop.Location = New System.Drawing.Point(108, 24)
         Me._lblTop.Name = "_lblTop"
         Me._lblTop.Size = New System.Drawing.Size(37, 16)
         Me._lblTop.TabIndex = 3
         Me._lblTop.Text = "&Top"
         ' 
         ' _txtRight
         ' 
         Me._txtRight.Location = New System.Drawing.Point(48, 51)
         Me._txtRight.Name = "_txtRight"
         Me._txtRight.Size = New System.Drawing.Size(42, 20)
         Me._txtRight.TabIndex = 6
         Me._txtRight.Text = ""
         ' 
         ' _lblRight
         ' 
         Me._lblRight.Location = New System.Drawing.Point(15, 53)
         Me._lblRight.Name = "_lblRight"
         Me._lblRight.Size = New System.Drawing.Size(32, 16)
         Me._lblRight.TabIndex = 5
         Me._lblRight.Text = "&Right"
         ' 
         ' _txtBottom
         ' 
         Me._txtBottom.Location = New System.Drawing.Point(150, 50)
         Me._txtBottom.Name = "_txtBottom"
         Me._txtBottom.Size = New System.Drawing.Size(42, 20)
         Me._txtBottom.TabIndex = 8
         Me._txtBottom.Text = ""
         ' 
         ' _lblBottom
         ' 
         Me._lblBottom.Location = New System.Drawing.Point(108, 54)
         Me._lblBottom.Name = "_lblBottom"
         Me._lblBottom.Size = New System.Drawing.Size(45, 16)
         Me._lblBottom.TabIndex = 7
         Me._lblBottom.Text = "&Bottom"
         ' 
         ' _txtSegmentType
         ' 
         Me._txtSegmentType.Location = New System.Drawing.Point(18, 103)
         Me._txtSegmentType.Name = "_txtSegmentType"
         Me._txtSegmentType.ReadOnly = True
         Me._txtSegmentType.TabIndex = 12
         Me._txtSegmentType.Text = ""
         Me._txtSegmentType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.groupBox2.Location = New System.Drawing.Point(11, 0)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(197, 80)
         Me.groupBox2.TabIndex = 0
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "Segment Rectangle"
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.groupBox1.Location = New System.Drawing.Point(11, 82)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(117, 54)
         Me.groupBox1.TabIndex = 11
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Segment Type"
         ' 
         ' _btnOk
         ' 
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(133, 88)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.TabIndex = 9
         Me._btnOk.Text = "&Ok"
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(133, 114)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.TabIndex = 10
         Me._btnCancel.Text = "&Cancel"
         ' 
         ' SegmentInformationDialog
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(218, 143)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me._txtSegmentType)
         Me.Controls.Add(Me._txtBottom)
         Me.Controls.Add(Me._txtRight)
         Me.Controls.Add(Me._txtTop)
         Me.Controls.Add(Me._txtLeft)
         Me.Controls.Add(Me._lblBottom)
         Me.Controls.Add(Me._lblRight)
         Me.Controls.Add(Me._lblTop)
         Me.Controls.Add(Me._lblLeft)
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me.groupBox2)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "SegmentInformationDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Segment Information"
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private _lblLeft As System.Windows.Forms.Label
      Private WithEvents _txtLeft As System.Windows.Forms.TextBox
      Private WithEvents _txtTop As System.Windows.Forms.TextBox
      Private _lblTop As System.Windows.Forms.Label
      Private WithEvents _txtRight As System.Windows.Forms.TextBox
      Private _lblRight As System.Windows.Forms.Label
      Private WithEvents _txtBottom As System.Windows.Forms.TextBox
      Private _lblBottom As System.Windows.Forms.Label
      Private _txtSegmentType As System.Windows.Forms.TextBox
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button

      Private _left As Integer
      Private _right As Integer
      Private _top As Integer
      Private _bottom As Integer
      Private _imageWidth As Integer
      Private _imageHeight As Integer

      Public Property NewLeft() As Integer
         Get
            Return _left
         End Get
         Set(value As Integer)
            _left = Value
            _txtLeft.Text = _left.ToString()
         End Set
      End Property
      Public Property NewRight() As Integer
         Get
            Return _right
         End Get
         Set(value As Integer)
            _right = Value
            _txtRight.Text = _right.ToString()
         End Set
      End Property
      Public Property NewTop() As Integer
         Get
            Return _top
         End Get
         Set(value As Integer)
            _top = Value
            _txtTop.Text = _top.ToString()
         End Set
      End Property
      Public Property NewBottom() As Integer
         Get
            Return _bottom
         End Get
         Set(value As Integer)
            _bottom = Value
            _txtBottom.Text = _bottom.ToString()
         End Set
      End Property

      Private Sub _txtLeft_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLeft.TextChanged
         If _txtLeft.Text.Length = 0 Then
            _txtLeft.Text = "0"
         End If

         If (Convert.ToInt32(_txtLeft.Text)) > _imageWidth Then
            _txtLeft.Text = Convert.ToString(_imageWidth)
         End If

         _left = Int32.Parse(_txtLeft.Text)
      End Sub

      Private Sub _txtRight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtRight.TextChanged
         If _txtRight.Text.Length = 0 Then
            _txtRight.Text = "0"
         End If

         If (Convert.ToInt32(_txtRight.Text)) > _imageWidth Then
            _txtRight.Text = Convert.ToString(_imageWidth)
         End If

         _right = Int32.Parse(_txtRight.Text)
      End Sub

      Private Sub _txtTop_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtTop.TextChanged
         If _txtTop.Text.Length = 0 Then
            _txtTop.Text = "0"
         End If

         If (Convert.ToInt32(_txtTop.Text)) > _imageHeight Then
            _txtTop.Text = Convert.ToString(_imageHeight)
         End If

         _top = Int32.Parse(_txtTop.Text)
      End Sub

      Private Sub _txtBottom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtBottom.TextChanged
         If _txtBottom.Text.Length = 0 Then
            _txtBottom.Text = "0"
         End If

         If (Convert.ToInt32(_txtBottom.Text)) > _imageHeight Then
            _txtBottom.Text = Convert.ToString(_imageHeight)
         End If

         _bottom = Int32.Parse(_txtBottom.Text)
      End Sub

      Private Sub _txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _txtLeft.KeyPress, _txtTop.KeyPress, _txtRight.KeyPress, _txtBottom.KeyPress
         If (Not Char.IsNumber(e.KeyChar)) AndAlso (Not Char.IsControl(e.KeyChar)) Then
            e.Handled = True
         End If
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         If _left < 0 Then
            Messager.ShowError(Me, "Invalid y-coordinate of the rectangle's upper-left corner")
         ElseIf _top < 0 Then
            Messager.ShowError(Me, "Invalid y-coordinate of the rectangle's upper-left corner")
         ElseIf _right > _imageWidth Then
            Messager.ShowError(Me, "Invalid x-coordinate of the rectangle's lower-right corner")
         ElseIf _bottom > _imageHeight Then
            Messager.ShowError(Me, "Invalid y-coordinate of the rectangle's lower-right corner.")
         ElseIf (_right - _left) < 15 Then
            Messager.ShowError(Me, "Invalid rectangle width.")
         ElseIf (_bottom - _top) < 15 Then
            Messager.ShowError(Me, "Invalid rectangle height.")
         Else
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
         End If
      End Sub
   End Class


   ''' <summary>
   ''' Summary description for PdfDPIOptions.
   ''' </summary>
   Public Class PdfDPIOptions : Inherits System.Windows.Forms.Form
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private WithEvents _txtXResolution As System.Windows.Forms.TextBox
      Private _lblYResolution As System.Windows.Forms.Label
      Private _lblXResolution As System.Windows.Forms.Label
      Private WithEvents _txtYResolution As System.Windows.Forms.TextBox
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public Sub New(ByVal mainForm As MainForm, ByVal initXResolution As Integer, ByVal initYResolution As Integer)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         _mainForm = mainForm
         _xResolution = initXResolution
         _yResolution = initYResolution
         InitClass()
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
         Me._txtYResolution = New System.Windows.Forms.TextBox()
         Me._txtXResolution = New System.Windows.Forms.TextBox()
         Me._lblYResolution = New System.Windows.Forms.Label()
         Me._lblXResolution = New System.Windows.Forms.Label()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.groupBox2.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(136, 72)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.TabIndex = 6
         Me._btnCancel.Text = "&Cancel"
         ' 
         ' _btnOk
         ' 
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(40, 72)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.TabIndex = 5
         Me._btnOk.Text = "&Ok"
         ' 
         ' _txtYResolution
         ' 
         Me._txtYResolution.Location = New System.Drawing.Point(200, 32)
         Me._txtYResolution.Name = "_txtYResolution"
         Me._txtYResolution.Size = New System.Drawing.Size(42, 20)
         Me._txtYResolution.TabIndex = 4
         Me._txtYResolution.Text = ""
         ' 
         ' _txtXResolution
         ' 
         Me._txtXResolution.Location = New System.Drawing.Point(80, 32)
         Me._txtXResolution.Name = "_txtXResolution"
         Me._txtXResolution.Size = New System.Drawing.Size(42, 20)
         Me._txtXResolution.TabIndex = 2
         Me._txtXResolution.Text = ""
         ' 
         ' _lblYResolution
         ' 
         Me._lblYResolution.Location = New System.Drawing.Point(136, 32)
         Me._lblYResolution.Name = "_lblYResolution"
         Me._lblYResolution.Size = New System.Drawing.Size(72, 16)
         Me._lblYResolution.TabIndex = 3
         Me._lblYResolution.Text = "&YResolution"
         ' 
         ' _lblXResolution
         ' 
         Me._lblXResolution.Location = New System.Drawing.Point(16, 32)
         Me._lblXResolution.Name = "_lblXResolution"
         Me._lblXResolution.Size = New System.Drawing.Size(72, 16)
         Me._lblXResolution.TabIndex = 1
         Me._lblXResolution.Text = "&XResolution"
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.groupBox2.Location = New System.Drawing.Point(8, 8)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(248, 56)
         Me.groupBox2.TabIndex = 7
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "PDF Resolution"
         ' 
         ' PdfDPIOptions
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(264, 101)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me._txtXResolution)
         Me.Controls.Add(Me._txtYResolution)
         Me.Controls.Add(Me._lblYResolution)
         Me.Controls.Add(Me._lblXResolution)
         Me.Controls.Add(Me.groupBox2)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "PdfDPIOptions"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "PdfDPIOptions"
         Me.groupBox2.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private _mainForm As MainForm
      Private _xResolution As Integer
      Private _yResolution As Integer

      Public ReadOnly Property XResolution() As Integer
         Get
            Return _xResolution
         End Get
      End Property

      Public ReadOnly Property YResolution() As Integer
         Get
            Return _yResolution
         End Get
      End Property

      Private Sub InitClass()
         _txtXResolution.Text = _xResolution.ToString()
         _txtYResolution.Text = _yResolution.ToString()
      End Sub

      Private Sub _txtXResolution_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtXResolution.TextChanged
         If _txtXResolution.Text.Length = 0 Then
            _txtXResolution.Text = "10"
         End If

         _xResolution = Int32.Parse(_txtXResolution.Text)
      End Sub

      Private Sub _txtYResolution_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtYResolution.TextChanged
         If _txtYResolution.Text.Length = 0 Then
            _txtYResolution.Text = "10"
         End If

         _yResolution = Int32.Parse(_txtYResolution.Text)
      End Sub

      Private Sub _txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _txtYResolution.KeyPress, _txtXResolution.KeyPress
         If (Not Char.IsNumber(e.KeyChar)) AndAlso (Not Char.IsControl(e.KeyChar)) Then
            e.Handled = True
         End If
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         If _xResolution < 10 OrElse _xResolution > 1000 Then
            Messager.ShowError(Me, "Invalid x-resolution. The x-resolution value should be between 10 and 1000")
         ElseIf _yResolution < 10 OrElse _yResolution > 1000 Then
            Messager.ShowError(Me, "Invalid y-resolution. The y-resolution value should be between 10 and 1000")
         Else
            _xResolution = Int32.Parse(_txtXResolution.Text)
            _yResolution = Int32.Parse(_txtYResolution.Text)

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
         End If
      End Sub
   End Class
End Namespace
