' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Pdf

Namespace PDFFormsDemo
   Public Class ComboFormField
      Inherits FormFieldControl
      Implements IFormFieldList
      Public Sub New()
         _pdfComboBox = New PDFComboBox()
         AddHandler _pdfComboBox.SelectedIndexChanged, AddressOf PDFComboBox_SelectedIndexChanged
         Me.SetChildControl(_pdfComboBox)
      End Sub

      Protected Overrides Sub OnSizeChanged(e As EventArgs)
         If _pdfComboBox IsNot Nothing Then
            _pdfComboBox.SetHeight(Me.Height)
         End If

         MyBase.OnSizeChanged(e)
      End Sub

      Public Overrides Sub InitControl(formField As PDFFormField)
         MyBase.InitControl(formField)

         _items.Clear()
         For Each content As String In formField.Contents
            _items.Add(content)
         Next

         UpdateItemsList(_items, _pdfComboBox.Items)

         Dim ChoiceSort As Boolean = (formField.FieldFlags And PDFFormField.FieldFlagsChoiceSort) = PDFFormField.FieldFlagsChoiceSort

         If ChoiceSort Then
            Me.Sort()
         End If

         ' Set PDFComboBox selected item, using PDFFormField.ContentValues and Items List.
         Dim selectedContent As String = (If(Me.PDFFormField.SelectedContents.Count <= 0, "", Me.PDFFormField.SelectedContents(0)))

         SetContentText(Me.PDFFormField.ContentValues, selectedContent)

         _pdfComboBox.SetHeight(Me.Height)
      End Sub

      Public Overrides Sub SetToolTip(toolTip As String)
         If FormFieldControl.FormFieldsToolTip IsNot Nothing Then
            FormFieldControl.FormFieldsToolTip.SetToolTip(_pdfComboBox, toolTip)
         End If

         MyBase.SetToolTip(toolTip)
      End Sub

      Public Overrides Sub SetContextMenuStrip()
         MyBase.SetContextMenuStrip()

         If FormFieldControl.FormFieldsContextMenu IsNot Nothing Then
            _pdfComboBox.Tag = Me

            _pdfComboBox.ContextMenuStrip = FormFieldControl.FormFieldsContextMenu
         End If
      End Sub

      Public Overrides Sub UpdateFormField(formField As PDFFormField)
         MyBase.UpdateFormField(formField)

         formField.Contents.Clear()
         For Each item As String In _items
            Dim itemContent As String = item
            formField.Contents.Add(itemContent)
         Next

         formField.SelectedContents.Clear()
         If _pdfComboBox.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = If(_pdfComboBox.SelectedItem IsNot Nothing, _pdfComboBox.SelectedItem.ToString(), "")
            formField.SelectedContents.Add(selectedItem)
         End If

         If _isSorted Then
            formField.FieldFlags = formField.FieldFlags Or PDFFormField.FieldFlagsChoiceSort
         End If
      End Sub

      Protected Overrides Sub DoFontResize()
         MyBase.DoFontResize()

         _pdfComboBox.SetHeight(Me.Height)
      End Sub

      Protected Overrides Sub OnPropertyChange()
         Me._pdfComboBox.Enabled = Not _isReadOnly

         MyBase.OnPropertyChange()
      End Sub

      Public Sub Sort() Implements IFormFieldList.Sort
         _items.Sort()

         'Update ComboBox items.
         UpdateItemsList(_items, _pdfComboBox.Items)

         _isSorted = True
      End Sub

      Private Sub PDFComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
         _pdfComboBox.ContentText = ""
         _pdfComboBox.Invalidate()
      End Sub

      Private Sub SetContentText(contentValues As IList(Of String), selectedContent As String)
         Dim inItems As Boolean = _items.IndexOf(selectedContent) <> -1
         Dim inValues As Boolean = contentValues.IndexOf(selectedContent) <> -1

         If inItems Then
            _pdfComboBox.SelectedIndex = _items.IndexOf(selectedContent)
            _pdfComboBox.ContentText = ""
         ElseIf inValues Then
            _pdfComboBox.SelectedIndex = contentValues.IndexOf(selectedContent)
            _pdfComboBox.ContentText = ""
         Else
            _pdfComboBox.SelectedIndex = -1
            _pdfComboBox.ContentText = selectedContent
         End If
      End Sub

#Region "Properties"

#Region "PDFComboBox"

      Private _pdfComboBox As PDFComboBox
      Public ReadOnly Property PDFComboBox() As PDFComboBox
         Get
            Return Me._pdfComboBox
         End Get
      End Property

#End Region

#Region "Items"

      Private _items As New List(Of String)()
      Public Property Items() As List(Of String) Implements IFormFieldList.Items
         Get
            Return _items
         End Get
         Set(value As List(Of String))
            If value IsNot Nothing Then
               UpdateItemsList(value, _items)
               UpdateItemsList(value, _pdfComboBox.Items)
               _isSorted = False
            End If
         End Set
      End Property

      Private Sub UpdateItemsList(newItems As List(Of String), target As IList)
         target.Clear()

         For i As Integer = 0 To newItems.Count - 1
            target.Add(newItems(i))
         Next
      End Sub

#End Region

#Region "SelectedIndex"

      Public Property SelectedIndex() As Integer Implements IFormFieldList.SelectedIndex
         Get
            Return _pdfComboBox.SelectedIndex
         End Get
         Set(value As Integer)
            _pdfComboBox.SelectedIndex = value
         End Set
      End Property

#End Region

#Region "SelectedIndices"

      Public Property SelectedIndices() As List(Of Integer) Implements IFormFieldList.SelectedIndices
         Get
            Dim selectedIndices__1 As New List(Of Integer)()
            If _pdfComboBox.SelectedIndex <> -1 Then
               selectedIndices__1.Add(_pdfComboBox.SelectedIndex)
            End If

            Return selectedIndices__1
         End Get
         Set(value As List(Of Integer))
            If value IsNot Nothing AndAlso value.Count > 0 Then
               _pdfComboBox.SelectedIndex = value(0)
            End If
         End Set
      End Property

#End Region

#Region "IsSorted"

      Private _isSorted As Boolean = False
      Public Property IsSorted() As Boolean Implements IFormFieldList.IsSorted
         Get
            Return _isSorted
         End Get
         Set(value As Boolean)
            _isSorted = value

            If _isSorted Then
               Me.Sort()
            End If
         End Set
      End Property

#End Region

#End Region
   End Class

   Public Class PDFComboBox
      Inherits ComboBox
      Implements IFormFieldControl
      Private _focus As Boolean = False

      Public Sub New()
         Me.SetStyle(ControlStyles.UserPaint, True)

         Me.DrawMode = DrawMode.OwnerDrawVariable
         Me.DropDownStyle = ComboBoxStyle.DropDownList

         AddHandler Me.DrawItem, AddressOf CustomComboBox_DrawItem

         AddHandler Me.MouseEnter, AddressOf PDFComboBox_MouseEnter
         AddHandler Me.MouseLeave, AddressOf PDFComboBox_MouseLeave
      End Sub

      Private Sub PDFComboBox_MouseEnter(sender As Object, e As EventArgs)
         _focus = True
      End Sub

      Private Sub PDFComboBox_MouseLeave(sender As Object, e As EventArgs)
         _focus = False
      End Sub

      Protected Overrides Sub OnPaint(e As PaintEventArgs)
         e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

         ' Draw ComboBox Border.
         FormFieldControl.DrawBorder(e.Graphics, Me, Me.Parent.Size, _focus)

         Dim innerRect As Rectangle = GetInnerRect()

         e.Graphics.Clip = New Region(innerRect)
         ' Draw Background Rectangle
         Using brush As New SolidBrush(Me.BackgroundColor)
            e.Graphics.FillRectangle(brush, innerRect)
         End Using

         ' Draw Selected Item String
         Using brush As New SolidBrush(Me.ForeColor)
            Dim selectetItem As String = If(Me.SelectedItem Is Nothing, "", Me.SelectedItem.ToString())

            Dim text As String = If(String.IsNullOrEmpty(ContentText), selectetItem, Me.ContentText)

            Dim textSize As SizeF = e.Graphics.MeasureString(text, Me.Font)

            Dim centerY As Single = innerRect.Y + (innerRect.Height - textSize.Height) / 2

            e.Graphics.DrawString(text, Me.Font, brush, innerRect.X, centerY)
         End Using

         ' Draw Combo Button
         Dim comboButtonRect As New Rectangle(innerRect.X + innerRect.Width - 15, innerRect.Y, 15, innerRect.Height)

         ControlPaint.DrawComboButton(e.Graphics, comboButtonRect, ButtonState.Normal)

         e.Graphics.Clip.Dispose()

      End Sub

      Private Sub CustomComboBox_DrawItem(sender As Object, e As DrawItemEventArgs)
         ' Draw the background of the item.
         e.DrawBackground()

         If e.Index <> -1 Then
            ' Draw each string in the array.
            e.Graphics.DrawString(Me.Items(e.Index).ToString(), e.Font, Brushes.Black, e.Bounds)
         End If

         ' Draw the focus rectangle if the mouse hovers over an item.
         e.DrawFocusRectangle()
      End Sub

      Private Function GetInnerRect() As Rectangle
         Dim rect As New Rectangle(New Point(0, 0), Me.Parent.Size)

         Select Case _fieldBorderStyle
            Case FieldBorderStyle.Solid, FieldBorderStyle.Dashed
               rect.Inflate(-Me._borderThickness, -Me._borderThickness)
               Exit Select
            Case FieldBorderStyle.Beveled, FieldBorderStyle.Inset
               rect.Inflate(-Me._borderThickness * 2, -Me._borderThickness * 2)
               Exit Select
            Case FieldBorderStyle.Underlined
               rect.Height -= Me._borderThickness
               Exit Select
         End Select

         Return rect
      End Function

      <System.Runtime.InteropServices.DllImport("user32.dll")> _
      Private Shared Function SendMessage(hWnd As IntPtr, Msg As UInt32, wParam As Int32, lParam As Int32) As IntPtr
      End Function
      Private Const CB_SETITEMHEIGHT As Int32 = &H153

      Public Sub SetHeight(desiredHeight As Int32)
         SendMessage(Me.Handle, CB_SETITEMHEIGHT, -1, desiredHeight)
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

#Region "ContentText"

      <System.ComponentModel.DefaultValue("")> _
      Public Property ContentText() As String
         Get
            Return m_ContentText
         End Get
         Set(value As String)
            m_ContentText = Value
         End Set
      End Property
      Private m_ContentText As String

#End Region

#End Region
   End Class
End Namespace
