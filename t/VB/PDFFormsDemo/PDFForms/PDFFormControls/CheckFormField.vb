' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Pdf
Imports System

Namespace PDFFormsDemo
   Public Class CheckFormField
      Inherits FormFieldControl
      Public Sub New()
         _pdfCheckBox = New PDFCheckBox()
         Me.SetChildControl(_pdfCheckBox)
      End Sub

      Public Overrides Sub InitControl(formField As PDFFormField)
         MyBase.InitControl(formField)

         _pdfCheckBox.Checked = If(formField.State = PDFFormField.StateSelected, True, False)
      End Sub

      Public Overrides Sub SetToolTip(toolTip As String)
         If FormFieldControl.FormFieldsToolTip IsNot Nothing Then
            FormFieldControl.FormFieldsToolTip.SetToolTip(_pdfCheckBox, toolTip)
         End If

         MyBase.SetToolTip(toolTip)
      End Sub

      Public Overrides Sub SetContextMenuStrip()
         MyBase.SetContextMenuStrip()

         If FormFieldControl.FormFieldsContextMenu IsNot Nothing Then
            _pdfCheckBox.Tag = Me

            _pdfCheckBox.ContextMenuStrip = FormFieldControl.FormFieldsContextMenu
         End If
      End Sub

      Public Overrides Sub UpdateFormField(formField As PDFFormField)
         MyBase.UpdateFormField(formField)

         If _pdfCheckBox.Checked = True Then
            formField.State = PDFFormField.StateSelected
         Else
            formField.State = PDFFormField.StateNotSelected
         End If
      End Sub

      Protected Overrides Sub OnPropertyChange()
         Me._pdfCheckBox.Enabled = Not _isReadOnly

         MyBase.OnPropertyChange()
      End Sub

#Region "Properties"

#Region "PDFComboBox"

      Private _pdfCheckBox As PDFCheckBox
      Public ReadOnly Property PDFCheckBox() As PDFCheckBox
         Get
            Return Me._pdfCheckBox
         End Get
      End Property

#End Region

#End Region
   End Class

   Public Class PDFCheckBox
      Inherits CheckBox
      Implements IFormFieldControl
      Private _focus As Boolean = False

      Public Sub New()
         Me.CheckAlign = ContentAlignment.MiddleCenter

         Me._backgroundColor = Me.BackColor

         AddHandler Me.MouseEnter, AddressOf PDFCheckBox_MouseEnter
         AddHandler Me.MouseLeave, AddressOf PDFCheckBox_MouseLeave
      End Sub

      Private Sub PDFCheckBox_MouseEnter(sender As Object, e As EventArgs)
         _focus = True
         Me.Invalidate()
      End Sub

      Private Sub PDFCheckBox_MouseLeave(sender As Object, e As EventArgs)
         _focus = False
         Me.Invalidate()
      End Sub

      Protected Overrides Sub OnPaint(e As PaintEventArgs)
         e.Graphics.Clear(Me.BackColor)

         Dim innerRect As New Rectangle((_borderThickness), (_borderThickness), Me.ClientSize.Width - (_borderThickness * 2), Me.ClientSize.Height - (_borderThickness * 2))
         Dim backgroundRect As New Rectangle((_borderThickness), (_borderThickness), Me.ClientSize.Width - (_borderThickness * 2), Me.ClientSize.Height - (_borderThickness * 2))

         Select Case _fieldBorderStyle
            Case FieldBorderStyle.Beveled
               backgroundRect.Inflate(-Me._borderThickness, -Me._borderThickness)
               Exit Select
            Case FieldBorderStyle.Inset
               backgroundRect.Inflate(-Me._borderThickness, -Me._borderThickness)
               Exit Select
            Case FieldBorderStyle.Underlined
               backgroundRect = New Rectangle(0, 0, Me.ClientSize.Width, Me.ClientSize.Height - _borderThickness)
               Exit Select
         End Select

         backgroundRect.Width = If(backgroundRect.Width = 0, 1, backgroundRect.Width)
         backgroundRect.Height = If(backgroundRect.Height = 0, 1, backgroundRect.Height)

         ' Draw CheckBox Border.
         FormFieldControl.DrawBorder(e.Graphics, Me, Me.ClientSize, _focus)

         ' Draw Check Box Background.
         e.Graphics.FillRectangle(New SolidBrush(_backgroundColor), backgroundRect)

         ' Draw Check Mark.
         If Me.Checked Then
            Dim checkMarkHeight As Integer = If(innerRect.Height >= innerRect.Width, innerRect.Width, innerRect.Height)
            Dim checkMarkOffset As New Point(innerRect.X + CInt((innerRect.Width - checkMarkHeight) / 2), innerRect.Y + CInt((innerRect.Height - checkMarkHeight) / 2))
            Dim checkMarkRect As New Rectangle(checkMarkOffset.X, checkMarkOffset.Y, checkMarkHeight, checkMarkHeight)

            Dim font As New Font("Verdana", checkMarkRect.Height, FontStyle.Bold)

            font = FitTextToControlHeight(font, checkMarkRect.Height)

            TextRenderer.DrawText(e.Graphics, "✓", font, New Point(checkMarkRect.X, checkMarkRect.Y), Color.Black)
         End If
      End Sub

      Private Function FitTextToControlHeight(font As Font, controlHeight As Integer) As Font
         While controlHeight < TextRenderer.MeasureText("✓", New Font(font.FontFamily, font.Size, font.Style)).Height
            font = New Font(font.FontFamily, font.Size - 0.5F, font.Style)
         End While

         Return font
      End Function

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

#End Region
   End Class
End Namespace
