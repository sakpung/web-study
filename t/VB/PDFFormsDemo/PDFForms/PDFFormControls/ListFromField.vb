' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Pdf
Imports System

Namespace PDFFormsDemo
   Public Class ListFormField
      Inherits FormFieldControl
      Implements IFormFieldList
      Public Sub New()
         _pdfListBox = New PDFListBox()
         Me.SetChildControl(_pdfListBox)
      End Sub

      Public Overrides Sub InitControl(formField As PDFFormField)
         MyBase.InitControl(formField)

         Dim listBox As ListBox = _pdfListBox.ListBox

         For Each content As String In formField.Contents
            _items.Add(content)
         Next

         UpdateItemsList(_items, listBox.Items)

         Dim ChoiceMultiSelect As Boolean = (formField.FieldFlags And PDFFormField.FieldFlagsChoiceMultiSelect) = PDFFormField.FieldFlagsChoiceMultiSelect
         Dim ChoiceSort As Boolean = (formField.FieldFlags And PDFFormField.FieldFlagsChoiceSort) = PDFFormField.FieldFlagsChoiceSort

         If ChoiceMultiSelect Then
            listBox.SelectionMode = SelectionMode.MultiSimple
         Else
            listBox.SelectionMode = SelectionMode.One
         End If

         If ChoiceSort Then
            Me.Sort()
         End If

         If formField.SelectedContents.Count > 0 Then
            If listBox.SelectionMode = SelectionMode.MultiSimple Then
               For Each content As String In formField.SelectedContents
                  Dim index As Integer = listBox.Items.IndexOf(content)
                  listBox.SetSelected(index, True)
               Next
            Else
               listBox.SelectedItem = formField.SelectedContents(0)
            End If
         End If
      End Sub

      Public Overrides Sub SetToolTip(toolTip As String)
         If FormFieldControl.FormFieldsToolTip IsNot Nothing Then
            FormFieldControl.FormFieldsToolTip.SetToolTip(_pdfListBox.ListBox, toolTip)
         End If

         MyBase.SetToolTip(toolTip)
      End Sub

      Public Overrides Sub SetContextMenuStrip()
         MyBase.SetContextMenuStrip()

         If FormFieldControl.FormFieldsContextMenu IsNot Nothing Then
            Dim listBox As ListBox = _pdfListBox.ListBox
            listBox.Tag = Me

            listBox.ContextMenuStrip = FormFieldControl.FormFieldsContextMenu
         End If
      End Sub

      Public Overrides Sub UpdateFormField(formField As PDFFormField)
         MyBase.UpdateFormField(formField)

         Dim listBox As ListBox = _pdfListBox.ListBox

         formField.Contents.Clear()
         For Each item As String In listBox.Items
            Dim itemContent As String = item
            formField.Contents.Add(itemContent)
         Next

         formField.SelectedContents.Clear()
         For Each item As String In listBox.SelectedItems
            Dim selectedItem As String = item
            formField.SelectedContents.Add(selectedItem)
         Next

         If listBox.SelectionMode = SelectionMode.MultiSimple Then
            formField.FieldFlags = formField.FieldFlags Or PDFFormField.FieldFlagsChoiceMultiSelect
         End If

         If _isSorted Then
            formField.FieldFlags = formField.FieldFlags Or PDFFormField.FieldFlagsChoiceSort
         End If
      End Sub

      Protected Overrides Sub OnPropertyChange()
         Me._pdfListBox.Enabled = Not _isReadOnly

         MyBase.OnPropertyChange()
      End Sub

      Public Sub Sort() Implements IFormFieldList.Sort
         _items.Sort()

         'Update ListBox items.
         UpdateItemsList(_items, _pdfListBox.ListBox.Items)

         _isSorted = True
      End Sub

#Region "Properties"

#Region "PDFListBox"

      Private _pdfListBox As PDFListBox
      Public ReadOnly Property PDFListBox() As PDFListBox
         Get
            Return Me._pdfListBox
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
               UpdateItemsList(value, _pdfListBox.ListBox.Items)
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
            Dim listBox As ListBox = _pdfListBox.ListBox
            Return listBox.SelectedIndex
         End Get
         Set(value As Integer)
            Dim listBox As ListBox = _pdfListBox.ListBox
            listBox.SelectedIndex = value
         End Set
      End Property

#End Region

#Region "SelectedIndices"

      Public Property SelectedIndices() As List(Of Integer) Implements IFormFieldList.SelectedIndices
         Get
            Dim listBox As ListBox = _pdfListBox.ListBox

            Dim selectedIndices__1 As New List(Of Integer)()
            For Each index As Integer In listBox.SelectedIndices
               selectedIndices__1.Add(index)
            Next

            Return selectedIndices__1
         End Get
         Set(value As List(Of Integer))
            Dim listBox As ListBox = _pdfListBox.ListBox
            listBox.ClearSelected()

            If value IsNot Nothing Then
               For Each index As Integer In value
                  listBox.SetSelected(index, True)
               Next
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

   Public Class PDFListBox
      Inherits Panel
      Implements IFormFieldControl
      Private _focus As Boolean = False
      Private _isBorderStyleUpdated As Boolean = False

      Public Sub New()
         _listBox = New ListBox()
         _listBox.BorderStyle = BorderStyle.None
         _listBox.Dock = DockStyle.Fill
         _listBox.IntegralHeight = False
         AddHandler _listBox.MouseEnter, AddressOf PDFListBox_MouseEnter
         AddHandler _listBox.MouseLeave, AddressOf PDFListBox_MouseLeave

         Me.Controls.Add(_listBox)
         AddHandler Me.MouseEnter, AddressOf PDFListBox_MouseEnter
         AddHandler Me.MouseLeave, AddressOf PDFListBox_MouseLeave
         AddHandler Me.Paint, AddressOf PDFListBox_Paint
      End Sub

      Private Sub PDFListBox_MouseEnter(sender As Object, e As EventArgs)
         _focus = True
         Me.Invalidate()
      End Sub

      Private Sub PDFListBox_MouseLeave(sender As Object, e As EventArgs)
         _focus = False
         Me.Invalidate()
      End Sub

      Private Sub PDFListBox_Paint(sender As Object, e As PaintEventArgs)
         If Not _isBorderStyleUpdated Then
            Me.FieldBorderStyle = _fieldBorderStyle
            _isBorderStyleUpdated = True
         End If

         ' Draw ListBox Border.
         FormFieldControl.DrawBorder(e.Graphics, Me, Me.ClientSize, _focus)
      End Sub

#Region "Properties"

#Region "ForeColor"

      Public Overrides Property ForeColor() As Color
         Get
            Return _listBox.ForeColor
         End Get
         Set(value As Color)
            _listBox.ForeColor = value
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
            _listBox.BackColor = Me._backgroundColor
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
            _listBox.Visible = value
            _isFieldVisible = value
         End Set
      End Property

#End Region

#Region "ListBox"

      Private _listBox As ListBox
      Public ReadOnly Property ListBox() As ListBox
         Get
            Return _listBox
         End Get
      End Property

#End Region

#End Region
   End Class
End Namespace
