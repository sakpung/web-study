' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Pdf
Imports System

Namespace PDFFormsDemo
   Public Class TextFormField
      Inherits FormFieldControl
      Public Sub New()
         _pdfTextBox = New PDFTextBox()
         Me.SetChildControl(_pdfTextBox)
      End Sub

      Public Overrides Sub InitControl(formField As PDFFormField)
         MyBase.InitControl(formField)

         Dim textBox As TextBox = _pdfTextBox.TextBox

         For Each content As String In formField.Contents
            textBox.Text += content
         Next

         textBox.Text = textBox.Text.Replace(vbLf, vbCr & vbLf)

         InitTextBoxControl(textBox, formField)

         SetTextJustification(textBox, formField.TextJustification)

         If Me._autoFontResize Then
            AddHandler textBox.TextChanged, AddressOf PDFTextBox_TextChanged
         End If
      End Sub

      Public Overrides Sub SetToolTip(toolTip As String)
         If FormFieldControl.FormFieldsToolTip IsNot Nothing Then
            FormFieldControl.FormFieldsToolTip.SetToolTip(_pdfTextBox.TextBox, toolTip)
         End If

         MyBase.SetToolTip(toolTip)
      End Sub

      Public Overrides Sub SetContextMenuStrip()
         MyBase.SetContextMenuStrip()

         If FormFieldControl.FormFieldsContextMenu IsNot Nothing Then
            Dim textBox As TextBox = _pdfTextBox.TextBox
            textBox.Tag = Me

            textBox.ContextMenuStrip = FormFieldControl.FormFieldsContextMenu
         End If
      End Sub

      Public Overrides Sub UpdateFormField(formField As PDFFormField)
         MyBase.UpdateFormField(formField)

         Dim textBox As TextBox = _pdfTextBox.TextBox

         formField.Contents.Clear()

         formField.Contents.Add(textBox.Text)

         Select Case textBox.TextAlign
            Case HorizontalAlignment.Center
               formField.TextJustification = PDFFormField.TextJustificationCentered
               Exit Select
            Case HorizontalAlignment.Left
               formField.TextJustification = PDFFormField.TextJustificationLeft
               Exit Select
            Case HorizontalAlignment.Right
               formField.TextJustification = PDFFormField.TextJustificationRight
               Exit Select
         End Select

         If textBox.Multiline Then
            formField.FieldFlags = formField.FieldFlags Or PDFFormField.FieldFlagsTextMultiline
         End If
      End Sub

      Protected Overrides Sub DoFontResize()
         Dim textBox As TextBox = _pdfTextBox.TextBox

         Dim fontSize As Single = CalculateFontSize(textBox.Text, textBox.Multiline)

         _pdfTextBox.Font = New Font(_font.FontFamily, fontSize)
      End Sub

      Protected Overrides Sub OnPropertyChange()
         Me._pdfTextBox.TextBox.[ReadOnly] = _isReadOnly

         MyBase.OnPropertyChange()
      End Sub

      Private Sub PDFTextBox_TextChanged(sender As Object, e As EventArgs)
         DoFontResize()
      End Sub

      Private Sub InitTextBoxControl(textBox As TextBox, formField As PDFFormField)
         Dim TextDoNotScroll As Boolean = (formField.FieldFlags And PDFFormField.FieldFlagsTextDoNotScroll) = PDFFormField.FieldFlagsTextDoNotScroll
         Dim TextDoNotSpellcheck As Boolean = (formField.FieldFlags And PDFFormField.FieldFlagsTextDoNotSpellcheck) = PDFFormField.FieldFlagsTextDoNotSpellcheck
         Dim TextMultiline As Boolean = (formField.FieldFlags And PDFFormField.FieldFlagsTextMultiline) = PDFFormField.FieldFlagsTextMultiline

         If TextDoNotScroll Then
            textBox.ScrollBars = ScrollBars.None
         Else
            textBox.ScrollBars = ScrollBars.Both
         End If

         If TextMultiline Then
            textBox.Multiline = True
         Else
            textBox.Multiline = False
         End If
      End Sub

      Private Sub SetTextJustification(textBox As TextBox, textJustification As Integer)
         Select Case textJustification
            Case PDFFormField.TextJustificationLeft
               textBox.TextAlign = HorizontalAlignment.Left
               Exit Select

            Case PDFFormField.TextJustificationCentered
               textBox.TextAlign = HorizontalAlignment.Center
               Exit Select

            Case PDFFormField.TextJustificationRight
               textBox.TextAlign = HorizontalAlignment.Right
               Exit Select
         End Select
      End Sub

#Region "Properties"

#Region "PDFTextBox"

      Private _pdfTextBox As PDFTextBox
      Public ReadOnly Property PDFTextBox() As PDFTextBox
         Get
            Return Me._pdfTextBox
         End Get
      End Property

#End Region

#End Region
   End Class

   Public Class PDFTextBox
      Inherits Panel
      Implements IFormFieldControl
      Private _focus As Boolean = False

      Public Sub New()
         _textBox = New TextBox()
         _textBox.AcceptsReturn = True
         _textBox.AutoSize = False
         _textBox.BorderStyle = System.Windows.Forms.BorderStyle.None
         _textBox.Dock = System.Windows.Forms.DockStyle.Fill
         AddHandler _textBox.MouseEnter, AddressOf PDFTextBox_MouseEnter
         AddHandler _textBox.MouseLeave, AddressOf PDFTextBox_MouseLeave
         AddHandler _textBox.GotFocus, AddressOf _textBox_GotFocus

         Me.Controls.Add(Me._textBox)
         AddHandler Me.MouseEnter, AddressOf PDFTextBox_MouseEnter
         AddHandler Me.MouseLeave, AddressOf PDFTextBox_MouseLeave
         AddHandler Me.Paint, AddressOf PDFTextBox_Paint
      End Sub

      Private Sub _textBox_GotFocus(sender As Object, e As EventArgs)
         Dim imageViewer As ImageViewer = TryCast(Me.Parent.Parent, ImageViewer)
         If imageViewer IsNot Nothing Then
            imageViewer.UpdateTransform()
         End If
      End Sub

      Private Sub PDFTextBox_MouseEnter(sender As Object, e As EventArgs)
         _focus = True
         Me.Invalidate()
      End Sub

      Private Sub PDFTextBox_MouseLeave(sender As Object, e As EventArgs)
         _focus = False
         Me.Invalidate()
      End Sub

      Private Sub PDFTextBox_Paint(sender As Object, e As PaintEventArgs)
         UpdateControl()

         ' Draw TextBox Border.
         FormFieldControl.DrawBorder(e.Graphics, Me, Me.ClientSize, _focus)
      End Sub

      Private Sub UpdateControl()
         Select Case _fieldBorderStyle
            Case FieldBorderStyle.Solid, FieldBorderStyle.Dashed
               Me.Padding = New Padding(_borderThickness)
               Exit Select
            Case FieldBorderStyle.Beveled, FieldBorderStyle.Inset
               Me.Padding = New Padding(_borderThickness * 2)
               Exit Select
            Case FieldBorderStyle.Underlined
               Me.Padding = New Padding(0, 0, 0, _borderThickness)
               Exit Select
         End Select
      End Sub

#Region "Properties"

#Region "ForeColor"

      Public Overrides Property ForeColor() As Color
         Get
            Return _textBox.ForeColor
         End Get
         Set(value As Color)
            _textBox.ForeColor = value
         End Set
      End Property

#End Region

#Region "BackgroundColor"

      Protected _backgroundColor As Color = SystemColors.Control
      Public Property BackgroundColor() As Color Implements IFormFieldControl.BackgroundColor
         Get
            Return _backgroundColor
         End Get
         Set(value As Color)
            _backgroundColor = value
            _textBox.BackColor = Me._backgroundColor
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
            _textBox.Visible = value
            _isFieldVisible = value
         End Set
      End Property

#End Region

#Region "TextBox"

      Private _textBox As TextBox
      Public ReadOnly Property TextBox() As TextBox
         Get
            Return _textBox
         End Get
      End Property

#End Region

#End Region
   End Class
End Namespace
