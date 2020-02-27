' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Pdf
Imports System

Namespace PDFFormsDemo
   Public Class RadioFormField
      Inherits FormFieldControl
      Public Sub New()
         _pdfRadioButton = New PDFRadioButton()
         Me.SetChildControl(_pdfRadioButton)
      End Sub

      Protected Overrides Sub OnSizeChanged(e As EventArgs)
         MyBase.OnSizeChanged(e)

         Dim circularPath As New GraphicsPath()
         circularPath.AddEllipse(Me.DisplayRectangle)

         Me.Region = New Region(circularPath)
      End Sub

      Public Overrides Sub InitControl(formField As PDFFormField)
         MyBase.InitControl(formField)

         Dim radioButton As PDFRadioButton = _pdfRadioButton

         radioButton.GroupName = formField.GroupId.ToString()

         radioButton.Checked = If(formField.State = PDFFormField.StateSelected, True, False)
      End Sub

      Public Overrides Sub SetToolTip(toolTip As String)
         If FormFieldControl.FormFieldsToolTip IsNot Nothing Then
            FormFieldControl.FormFieldsToolTip.SetToolTip(_pdfRadioButton, toolTip)
         End If

         MyBase.SetToolTip(toolTip)
      End Sub

      Public Overrides Sub SetContextMenuStrip()
         MyBase.SetContextMenuStrip()

         If FormFieldControl.FormFieldsContextMenu IsNot Nothing Then
            Dim radioButton As PDFRadioButton = _pdfRadioButton
            radioButton.Tag = Me

            radioButton.ContextMenuStrip = FormFieldControl.FormFieldsContextMenu
         End If
      End Sub

      Public Overrides Sub UpdateFormField(formField As PDFFormField)
         MyBase.UpdateFormField(formField)

         Dim radioButton As PDFRadioButton = _pdfRadioButton

         If radioButton.Checked = True Then
            formField.State = PDFFormField.StateSelected
         Else
            formField.State = PDFFormField.StateNotSelected
         End If
      End Sub

      Protected Overrides Sub OnPropertyChange()
         Me._pdfRadioButton.Enabled = Not _isReadOnly

         MyBase.OnPropertyChange()
      End Sub

#Region "Properties"

      Public Overrides Property FiedlBounds() As LeadRect
         Get
            Return _fiedlBounds
         End Get
         Set(value As LeadRect)
            Dim controlRadius As Integer = If(value.Height >= value.Width, value.Width, value.Height)

            Me.Left = value.Left + CInt((value.Width - controlRadius) / 2)
            Me.Top = value.Top + CInt((value.Height - controlRadius) / 2)
            Me.Width = controlRadius
            Me.Height = controlRadius

            _fiedlBounds = New LeadRect(Me.Left, Me.Top, Me.Width, Me.Height)
         End Set
      End Property

#Region "PDFRadioButton"

      Private _pdfRadioButton As PDFRadioButton
      Public ReadOnly Property PDFRadioButton() As PDFRadioButton
         Get
            Return Me._pdfRadioButton
         End Get
      End Property

#End Region

#End Region
   End Class

   Public Class PDFRadioButton
      Inherits RadioButton
      Implements IFormFieldControl
      Private _focus As Boolean = False

      Public Sub New()
         Me.CheckAlign = ContentAlignment.MiddleCenter

         Me._backgroundColor = Me.BackColor

         AddHandler Me.MouseEnter, AddressOf PDFRadioButton_MouseEnter
         AddHandler Me.MouseLeave, AddressOf PDFRadioButton_MouseLeave
         AddHandler Me.CheckedChanged, AddressOf PDFRadioButton_CheckedChanged
      End Sub

      Private Sub PDFRadioButton_CheckedChanged(sender As Object, e As EventArgs)
         If Me.Checked Then
            For Each radioButton As PDFRadioButton In PDFRadioButton.RadioButtonGroups(_groupName)
               If radioButton IsNot Me Then
                  radioButton.Checked = False
               End If
            Next
         End If
      End Sub

      Private Sub PDFRadioButton_MouseEnter(sender As Object, e As EventArgs)
         _focus = True
      End Sub

      Private Sub PDFRadioButton_MouseLeave(sender As Object, e As EventArgs)
         _focus = False
      End Sub

      Protected Overrides Sub OnPaint(e As PaintEventArgs)
         Dim controlHeight As Integer = Me.ClientSize.Height
         Dim borderHeight As Integer = controlHeight - (_borderThickness * 2)

         Dim borderOffset As New Point(CInt((Me.ClientSize.Width - borderHeight) / 2), CInt((Me.ClientSize.Height - borderHeight) / 2))
         Dim borderRect As New Rectangle(borderOffset.X, borderOffset.Y, borderHeight, borderHeight)

         e.Graphics.Clear(Me.BackColor)

         e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

         ' Draw Radion Button Background.
         e.Graphics.FillEllipse(New SolidBrush(_backgroundColor), borderRect)

         ' Draw Radion Button Border.
         DrawControlBorder(e.Graphics, borderRect)

         ' Draw Check Mark.
         If Me.Checked Then
            Dim checkMarkHeight As Integer = CInt(borderHeight / 2)
            Dim checkMarkOffset As New Point(borderOffset.X + CInt(checkMarkHeight / 2), borderOffset.Y + CInt(checkMarkHeight / 2))
            Dim checkMarkRect As New Rectangle(checkMarkOffset.X, checkMarkOffset.Y, checkMarkHeight, checkMarkHeight)

            e.Graphics.FillEllipse(New SolidBrush(Color.Black), checkMarkRect)
         End If
      End Sub

      Private Sub DrawControlBorder(graphics As Graphics, borderRect As Rectangle)
         Using borderPen As New Pen((If(_focus, _focusedBorderColor, _borderColor)), _borderThickness)
            Dim insetBeveledRect As Rectangle = borderRect
            insetBeveledRect.Inflate(-Me._borderThickness, -Me._borderThickness)

            insetBeveledRect.Width = If(insetBeveledRect.Width = 0, 1, insetBeveledRect.Width)
            insetBeveledRect.Height = If(insetBeveledRect.Height = 0, 1, insetBeveledRect.Height)

            Select Case _fieldBorderStyle
               Case FieldBorderStyle.Solid
                  Exit Select
               Case FieldBorderStyle.Dashed
                  Dim dashValues As Single() = {1, 1}
                  borderPen.DashPattern = dashValues
                  Exit Select
               Case FieldBorderStyle.Beveled
                  Dim beveledColor As Color = Color.FromArgb(_backgroundColor.A, CInt(_backgroundColor.R * 0.9), CInt(_backgroundColor.G * 0.9), CInt(_backgroundColor.B * 0.9))
                  graphics.DrawArc(New Pen(New SolidBrush(beveledColor), _borderThickness), insetBeveledRect, 315, 180)
                  graphics.DrawArc(New Pen(New SolidBrush(Color.White), _borderThickness), insetBeveledRect, 135, 180)
                  Exit Select
               Case FieldBorderStyle.Inset
                  graphics.DrawArc(New Pen(New SolidBrush(Color.LightGray), _borderThickness), insetBeveledRect, 315, 180)
                  graphics.DrawArc(New Pen(New SolidBrush(Color.Gray), _borderThickness), insetBeveledRect, 135, 180)
                  Exit Select
               Case FieldBorderStyle.Underlined
                  Exit Select
            End Select

            graphics.DrawEllipse(borderPen, borderRect)
         End Using
      End Sub

#Region "Properties"

#Region "BackgroundColor"

      Protected _backgroundColor As Color = SystemColors.Control
      Public Property BackgroundColor() As Color Implements IFormFieldControl.BackgroundColor
         Get
            Return _backgroundColor
         End Get
         Set(value As Color)
            _backgroundColor = value
         End Set
      End Property

#End Region

#Region "BorderColor"

      Protected _borderColor As Color = Color.Black
      Public Property BorderColor() As Color Implements IFormFieldControl.BorderColor
         Get
            Return _borderColor
         End Get
         Set(value As Color)
            _borderColor = value
         End Set
      End Property

#End Region

#Region "BorderThickness"

      Private _borderThickness As Integer = 1
      Public Property BorderThickness() As Integer Implements IFormFieldControl.BorderThickness
         Get
            Return _borderThickness
         End Get
         Set(value As Integer)
            _borderThickness = value
         End Set
      End Property

#End Region

#Region "FieldBorderStyle"

      Protected _fieldBorderStyle As FieldBorderStyle = FieldBorderStyle.Solid
      Public Property FieldBorderStyle() As FieldBorderStyle Implements IFormFieldControl.FieldBorderStyle
         Get
            Return _fieldBorderStyle
         End Get
         Set(value As FieldBorderStyle)
            _fieldBorderStyle = value
         End Set
      End Property

#End Region

#Region "FocusedBorderColor"

      Protected _focusedBorderColor As Color = Color.FromArgb(255, 0, 153, 225)
      Public ReadOnly Property FocusedBorderColor() As Color Implements IFormFieldControl.FocusedBorderColor
         Get
            Return _focusedBorderColor
         End Get
      End Property

#End Region

#Region "IsFieldVisible"

      Private _isFieldVisible As Boolean = True
      Public Property IsFieldVisible() As Boolean Implements IFormFieldControl.IsFieldVisible
         Get
            Return _isFieldVisible
         End Get
         Set(value As Boolean)
            Me.Visible = value
            _isFieldVisible = value
         End Set
      End Property

#End Region

#Region "GroupName"

      Public _groupName As String
      Public Property GroupName() As String
         Get
            Return _groupName
         End Get
         Set(value As String)
            _groupName = value
         End Set
      End Property

#End Region

#End Region

      Public Shared RadioButtonGroups As New Dictionary(Of String, List(Of PDFRadioButton))()
   End Class
End Namespace
