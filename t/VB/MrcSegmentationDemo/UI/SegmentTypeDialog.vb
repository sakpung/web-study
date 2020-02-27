' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Mrc

Namespace MrcSegmentationDemo
   ''' <summary>
   ''' Summary description for MrcSegmentType.
   ''' </summary>
   Public Class SegmentTypeDialog : Inherits System.Windows.Forms.Form
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

         _cbSegmentType.Items.Add("Text 1-Bit(B & W)")
         _cbSegmentType.Items.Add("Text 1-Bit(Colored)")
         _cbSegmentType.Items.Add("Text 2-Bit(Colored)")
         _cbSegmentType.Items.Add("Grayscale 2-Bit")
         _cbSegmentType.Items.Add("Grayscale 8-Bit")
         _cbSegmentType.Items.Add("Picture 24-Bit")
         _cbSegmentType.Items.Add("Back Ground segment")
         _cbSegmentType.Items.Add("One Color segment")
         _cbSegmentType.Items.Add("Text segment 2-Bit(B & W)")
         _cbSegmentType.SelectedIndex = 0
      End Sub

      Private WithEvents _cbSegmentType As System.Windows.Forms.ComboBox
      Private _Cancel As System.Windows.Forms.Button
      Private _btnOk As System.Windows.Forms.Button
      Private _groupBox1 As System.Windows.Forms.GroupBox

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
         Me._cbSegmentType = New System.Windows.Forms.ComboBox()
         Me._Cancel = New System.Windows.Forms.Button()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._groupBox1 = New System.Windows.Forms.GroupBox()
         Me.SuspendLayout()
         ' 
         ' _cbSegmentType
         ' 
         Me._cbSegmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbSegmentType.Location = New System.Drawing.Point(15, 20)
         Me._cbSegmentType.Name = "_cbSegmentType"
         Me._cbSegmentType.Size = New System.Drawing.Size(152, 21)
         Me._cbSegmentType.TabIndex = 1
         ' 
         ' _Cancel
         ' 
         Me._Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._Cancel.Location = New System.Drawing.Point(184, 40)
         Me._Cancel.Name = "_Cancel"
         Me._Cancel.TabIndex = 3
         Me._Cancel.Text = "&Cancel"
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(184, 6)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.TabIndex = 2
         Me._btnOk.Text = "&Ok"
         ' 
         ' _groupBox1
         ' 
         Me._groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._groupBox1.Location = New System.Drawing.Point(7, 4)
         Me._groupBox1.Name = "_groupBox1"
         Me._groupBox1.Size = New System.Drawing.Size(169, 47)
         Me._groupBox1.TabIndex = 0
         Me._groupBox1.TabStop = False
         Me._groupBox1.Text = "&Segment Type"
         ' 
         ' SegmentTypeDialog
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._Cancel
         Me.ClientSize = New System.Drawing.Size(266, 72)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me._Cancel)
         Me.Controls.Add(Me._cbSegmentType)
         Me.Controls.Add(Me._groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "SegmentTypeDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Segment Type"
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private _segmentType As MrcSegmentType

      Public Property SegmentType() As MrcSegmentType
         Get
            Return _segmentType
         End Get
         Set(value As MrcSegmentType)
            _segmentType = Value
            Select Case _segmentType
               Case MrcSegmentType.Text1BitBw
                  _cbSegmentType.SelectedIndex = 0
               Case MrcSegmentType.Text1BitColor
                  _cbSegmentType.SelectedIndex = 1
               Case MrcSegmentType.Text2BitColor
                  _cbSegmentType.SelectedIndex = 2
               Case MrcSegmentType.Grayscale2Bit
                  _cbSegmentType.SelectedIndex = 3
               Case MrcSegmentType.Grayscale8Bit
                  _cbSegmentType.SelectedIndex = 4
               Case MrcSegmentType.Picture
                  _cbSegmentType.SelectedIndex = 5
               Case MrcSegmentType.Background
                  _cbSegmentType.SelectedIndex = 6
               Case MrcSegmentType.OneColor
                  _cbSegmentType.SelectedIndex = 7
               Case MrcSegmentType.Text2BitBw
                  _cbSegmentType.SelectedIndex = 8
            End Select
         End Set
      End Property

      Private Sub _cbSegmentType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbSegmentType.SelectedIndexChanged
         Select Case _cbSegmentType.SelectedIndex
            Case 0
               _segmentType = MrcSegmentType.Text1BitBw
            Case 1
               _segmentType = MrcSegmentType.Text1BitColor
            Case 2
               _segmentType = MrcSegmentType.Text2BitColor
            Case 3
               _segmentType = MrcSegmentType.Grayscale2Bit
            Case 4
               _segmentType = MrcSegmentType.Grayscale8Bit
            Case 5
               _segmentType = MrcSegmentType.Picture
            Case 6
               _segmentType = MrcSegmentType.Background
            Case 7
               _segmentType = MrcSegmentType.OneColor
            Case 8
               _segmentType = MrcSegmentType.Text2BitBw
         End Select
      End Sub
   End Class
End Namespace
