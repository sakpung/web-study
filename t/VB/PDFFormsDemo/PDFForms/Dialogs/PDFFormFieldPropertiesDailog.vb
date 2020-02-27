' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System
Imports Leadtools.Pdf

Namespace PDFFormsDemo
   Partial Public Class PDFFormFieldPropertiesDailog
      Inherits Form
      Private _formFieldControl As FormFieldControl
      Public Sub New(control As FormFieldControl)
         InitializeComponent()

         For Each font As FontFamily In System.Drawing.FontFamily.Families
            _appearanceFontFamilyComboBox.Items.Add(font.Name)
         Next

         If control IsNot Nothing Then
            _formFieldControl = control

            InitPropertiesControls()
         End If

         AddHandler Me.FormClosing, AddressOf PDFFormFieldPropertiesDailog_FormClosing

         UpdateControls()
      End Sub

      Private Sub PDFFormFieldPropertiesDailog_FormClosing(sender As Object, e As FormClosingEventArgs)
         Me.UpdateFormFieldControl()
      End Sub

      Private Sub InitPropertiesControls()
         Me.Text = GetFormFieldControlTypeName()

         '#Region "General"

         _generalNameTextBox.Text = _formFieldControl.FieldName

         If Not String.IsNullOrEmpty(_formFieldControl.AlternateName) Then
            _generalTooltipTextBox.Text = _formFieldControl.AlternateName
         End If

         ' Set form field view and print property
         If _formFieldControl.IsFieldVisible AndAlso _formFieldControl.IsFieldPrintable Then
            _generalFormFieldComboBox.SelectedIndex = 0
         ElseIf Not _formFieldControl.IsFieldVisible AndAlso Not _formFieldControl.IsFieldPrintable Then
            _generalFormFieldComboBox.SelectedIndex = 1
         ElseIf _formFieldControl.IsFieldVisible AndAlso Not _formFieldControl.IsFieldPrintable Then
            _generalFormFieldComboBox.SelectedIndex = 2
         ElseIf Not _formFieldControl.IsFieldVisible AndAlso _formFieldControl.IsFieldPrintable Then
            _generalFormFieldComboBox.SelectedIndex = 3
         End If

         _generalReadOnlyCheckBox.Checked = _formFieldControl.IsReadOnly
         _lockedCheckBox.Checked = _formFieldControl.IsFieldLocked

         '#End Region

         '#Region "Appearance"

         If _formFieldControl.BorderColor <> Nothing Then
            _appearanceBorderColorColorPicker.Color = _formFieldControl.BorderColor
         End If

         If _formFieldControl.BackgroundColor <> Nothing Then
            _appearanceFillColorColorPicker.Color = _formFieldControl.BackgroundColor
         End If

         Select Case _formFieldControl.BorderThickness
            Case 1
               _appearanceBorderThicknessComboBox.SelectedIndex = 0
               Exit Select
            Case 2
               _appearanceBorderThicknessComboBox.SelectedIndex = 1
               Exit Select
            Case 3
               _appearanceBorderThicknessComboBox.SelectedIndex = 2
               Exit Select
         End Select

         _appearanceBorderStyleComboBox.SelectedIndex = CInt(_formFieldControl.FieldBorderStyle)

         If TypeOf _formFieldControl Is CheckFormField OrElse TypeOf _formFieldControl Is RadioFormField Then
            _appearanceTextGroupBox.Enabled = False
         End If

         _appearanceFontFamilyComboBox.SelectedItem = _formFieldControl.Font.FontFamily.Name

         If _formFieldControl.AutoFontResize Then
            _appearanceFontSizeComboBox.SelectedIndex = 0
         Else
            Select Case CInt(_formFieldControl.Font.Size)
               Case 6
                  _appearanceFontSizeComboBox.SelectedIndex = 1
                  Exit Select
               Case 8
                  _appearanceFontSizeComboBox.SelectedIndex = 2
                  Exit Select
               Case 9
                  _appearanceFontSizeComboBox.SelectedIndex = 3
                  Exit Select
               Case 10
                  _appearanceFontSizeComboBox.SelectedIndex = 4
                  Exit Select
               Case 12
                  _appearanceFontSizeComboBox.SelectedIndex = 5
                  Exit Select
               Case 14
                  _appearanceFontSizeComboBox.SelectedIndex = 6
                  Exit Select
               Case 18
                  _appearanceFontSizeComboBox.SelectedIndex = 7
                  Exit Select
            End Select
         End If

         If _formFieldControl.ForeColor <> Nothing Then
            _appearanceTextColorColorPicker.Color = _formFieldControl.ForeColor
         End If

         '#End Region

         '#Region "Options"

         If TypeOf _formFieldControl Is IFormFieldList Then
            _optionsItemsPanel.Visible = True

            Dim items As New List(Of String)()
            For i As Integer = 0 To CType(_formFieldControl, IFormFieldList).Items.Count - 1
               items.Add(CType(_formFieldControl, IFormFieldList).Items(i))
            Next

            _optionsItemsListBox.DataSource = items
            _optionsSortItemsCheckBox.Checked = CType(_formFieldControl, IFormFieldList).IsSorted

            _optionsItemsListBox.ClearSelected()
            For Each index As Integer In CType(_formFieldControl, IFormFieldList).SelectedIndices
               _optionsItemsListBox.SetSelected(index, True)
            Next

            If TypeOf _formFieldControl Is ListFormField Then
               _optionsMultipleSelectionCheckBox.Visible = True
               _optionsMultipleSelectionLabel.Visible = True

               Dim listBox As ListBox = CType(_formFieldControl, ListFormField).PDFListBox.ListBox
               If listBox.SelectionMode = SelectionMode.MultiSimple Then
                  _optionsMultipleSelectionCheckBox.Checked = True
               End If
            End If
         ElseIf TypeOf _formFieldControl Is TextFormField Then
            Dim textBox As TextBox = CType(_formFieldControl, TextFormField).PDFTextBox.TextBox

            _optionsTextBoxPanel.Visible = True

            Select Case textBox.TextAlign
               Case HorizontalAlignment.Left
                  _optionsAlignmentComboBox.SelectedIndex = 0
                  'Left
                  Exit Select

               Case HorizontalAlignment.Center
                  _optionsAlignmentComboBox.SelectedIndex = 1
                  'Center
                  Exit Select

               Case HorizontalAlignment.Right
                  _optionsAlignmentComboBox.SelectedIndex = 2
                  'Right
                  Exit Select
            End Select

            _optionsMultiLineCheckBox.Checked = textBox.Multiline
         Else
            _propertiesTabControl.Controls.Remove(_optionsTabPage)
         End If

         '#End Region
      End Sub

      Private Sub UpdateFormFieldControl()
         '#Region "General"

         _formFieldControl.FieldName = _generalNameTextBox.Text

         _formFieldControl.SetToolTip(_generalTooltipTextBox.Text)

         Select Case _generalFormFieldComboBox.SelectedIndex
            Case 0
               'Visible
               _formFieldControl.IsFieldVisible = True
               _formFieldControl.IsFieldPrintable = True
               Exit Select

            Case 1
               'Hidden
               _formFieldControl.IsFieldVisible = False
               _formFieldControl.IsFieldPrintable = False
               Exit Select

            Case 2
               'Visible but doesn't print
               _formFieldControl.IsFieldVisible = True
               _formFieldControl.IsFieldPrintable = False
               Exit Select

            Case 3
               'Hidden but printable
               _formFieldControl.IsFieldVisible = False
               _formFieldControl.IsFieldPrintable = True
               Exit Select
         End Select

         _formFieldControl.IsReadOnly = _generalReadOnlyCheckBox.Checked

         _formFieldControl.IsFieldLocked = _lockedCheckBox.Checked

         '#End Region

         '#Region "Appearance"

         _formFieldControl.BorderColor = _appearanceBorderColorColorPicker.Color

         If _formFieldControl.BackgroundColor <> Nothing Then
            _formFieldControl.BackgroundColor = _appearanceFillColorColorPicker.Color
            _formFieldControl.FillMode = PDFFormField.FillModeFilled
         End If

         Select Case _appearanceBorderThicknessComboBox.SelectedIndex
            Case 0
               _formFieldControl.BorderThickness = 1
               Exit Select
            Case 1
               _formFieldControl.BorderThickness = 2
               Exit Select
            Case 2
               _formFieldControl.BorderThickness = 3
               Exit Select
         End Select

         _formFieldControl.FieldBorderStyle = CType(_appearanceBorderStyleComboBox.SelectedIndex, FieldBorderStyle)

         Dim familyName As String = _appearanceFontFamilyComboBox.SelectedItem.ToString()
         Dim fontSize As Integer = FormFieldControl.MaxFontSize

         _formFieldControl.AutoFontResize = False
         Select Case _appearanceFontSizeComboBox.SelectedIndex
            Case 0
               _formFieldControl.AutoFontResize = True
               Exit Select
            Case 1
               fontSize = 6
               Exit Select
            Case 2
               fontSize = 8
               Exit Select
            Case 3
               fontSize = 9
               Exit Select
            Case 4
               fontSize = 10
               Exit Select
            Case 5
               fontSize = 12
               Exit Select
            Case 6
               fontSize = 14
               Exit Select
            Case 7
               fontSize = 18
               Exit Select
         End Select

         _formFieldControl.Font = New Font(familyName, fontSize)

         _formFieldControl.ForeColor = _appearanceTextColorColorPicker.Color

         '#End Region

         '#Region "Options"

         If _propertiesTabControl.Controls.Contains(_optionsTabPage) Then
            If TypeOf _formFieldControl Is IFormFieldList Then
               Dim formFieldList As IFormFieldList = CType(_formFieldControl, IFormFieldList)
               formFieldList.Items = CType(_optionsItemsListBox.DataSource, List(Of String))
               formFieldList.IsSorted = _optionsSortItemsCheckBox.Checked

               If TypeOf _formFieldControl Is ListFormField Then
                  Dim listBox As ListBox = CType(_formFieldControl, ListFormField).PDFListBox.ListBox

                  If _optionsMultipleSelectionCheckBox.Checked Then
                     listBox.SelectionMode = SelectionMode.MultiSimple
                  Else
                     listBox.SelectionMode = SelectionMode.One
                  End If
               End If

               'Set selected sndices for IFormFieldList.
               Dim selectedIndices As New List(Of Integer)()
               For Each index As Integer In _optionsItemsListBox.SelectedIndices
                  selectedIndices.Add(index)
               Next
               formFieldList.SelectedIndices = selectedIndices
            ElseIf TypeOf _formFieldControl Is TextFormField Then
               Dim textBox As TextBox = CType(_formFieldControl, TextFormField).PDFTextBox.TextBox

               Select Case _optionsAlignmentComboBox.SelectedIndex
                  Case 0
                     'Left
                     textBox.TextAlign = HorizontalAlignment.Left
                     Exit Select

                  Case 1
                     'Center
                     textBox.TextAlign = HorizontalAlignment.Center
                     Exit Select

                  Case 2
                     'Right
                     textBox.TextAlign = HorizontalAlignment.Right
                     Exit Select
               End Select

               textBox.Multiline = _optionsMultiLineCheckBox.Checked
               textBox.WordWrap = _optionsMultiLineCheckBox.Checked
            End If
         End If

         '#End Region
      End Sub

      Private Function GetFormFieldControlTypeName() As String
         Dim name As String = ""

         If TypeOf _formFieldControl Is CheckFormField Then
            name = "Check Box Form Field Properties"
         ElseIf TypeOf _formFieldControl Is RadioFormField Then
            name = "Radio Button Form Field Properties"
         ElseIf TypeOf _formFieldControl Is ComboFormField Then
            name = "Combo Box Form Field Properties"
         ElseIf TypeOf _formFieldControl Is ListFormField Then
            name = "List Box Form Field Properties"
         ElseIf TypeOf _formFieldControl Is TextFormField Then
            name = "Text Box Form Field Properties"
         End If

         Return name
      End Function

#Region "Options Items Panel Events"

      Private Sub _optionsAddItemTextBox_TextChanged(sender As Object, e As EventArgs) Handles _optionsAddItemTextBox.TextChanged
         UpdateControls()
      End Sub

      Private Sub _optionsAddItemButton_Click(sender As Object, e As EventArgs) Handles _optionsAddItemButton.Click
         Dim itemsList As List(Of String) = CType(_optionsItemsListBox.DataSource, List(Of String))
         itemsList.Add(_optionsAddItemTextBox.Text)

         UpdateOptionsItemsListBox(itemsList)

         _optionsItemsListBox.SelectedItem = _optionsItemsListBox.Items.Count - 1

         _optionsAddItemTextBox.Text = ""

         UpdateControls()
      End Sub

      Private Sub _optionsDeleteButton_Click(sender As Object, e As EventArgs) Handles _optionsDeleteButton.Click
         Dim itemsList As List(Of String) = CType(_optionsItemsListBox.DataSource, List(Of String))
         itemsList.Remove(_optionsItemsListBox.SelectedItem.ToString())

         UpdateOptionsItemsListBox(itemsList)

         UpdateControls()
      End Sub

      Private Sub _optionsUpButton_Click(sender As Object, e As EventArgs) Handles _optionsUpButton.Click
         Dim index As Integer = _optionsItemsListBox.SelectedIndex

         Dim content As String = _optionsItemsListBox.SelectedItem.ToString()

         Dim itemsList As List(Of String) = CType(_optionsItemsListBox.DataSource, List(Of String))
         itemsList.Insert(index - 1, content)
         itemsList.RemoveAt(index + 1)

         UpdateOptionsItemsListBox(itemsList)

         _optionsItemsListBox.SelectedIndex = index - 1

         _optionsSortItemsCheckBox.Checked = False

         UpdateControls()
      End Sub

      Private Sub _optionsDownButton_Click(sender As Object, e As EventArgs) Handles _optionsDownButton.Click
         Dim index As Integer = _optionsItemsListBox.SelectedIndex

         Dim content As String = _optionsItemsListBox.SelectedItem.ToString()

         Dim itemsList As List(Of String) = CType(_optionsItemsListBox.DataSource, List(Of String))
         itemsList.Insert(index + 2, content)
         itemsList.RemoveAt(index)

         UpdateOptionsItemsListBox(itemsList)

         _optionsItemsListBox.SelectedIndex = index + 1

         _optionsSortItemsCheckBox.Checked = False

         UpdateControls()
      End Sub

      Private Sub UpdateOptionsItemsListBox(itemsList As List(Of String))
         _optionsItemsListBox.DataSource = Nothing
         _optionsItemsListBox.DataSource = itemsList
      End Sub

      Private Sub _optionItemsListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _optionsItemsListBox.SelectedIndexChanged
         UpdateControls()
      End Sub

      Private Sub _optionsSortItemsCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _optionsSortItemsCheckBox.CheckedChanged
         If _optionsSortItemsCheckBox.Checked Then
            Dim itemsList As List(Of String) = CType(_optionsItemsListBox.DataSource, List(Of String))
            itemsList.Sort()

            UpdateOptionsItemsListBox(itemsList)
         End If
      End Sub

#End Region

      Private Sub UpdateControls()
         _generalTabPage.Enabled = Not _lockedCheckBox.Checked
         _appearanceTabPage.Enabled = Not _lockedCheckBox.Checked
         _optionsTabPage.Enabled = Not _lockedCheckBox.Checked

         If String.IsNullOrEmpty(_optionsAddItemTextBox.Text) Then
            _optionsAddItemButton.Enabled = False
         Else
            _optionsAddItemButton.Enabled = True
         End If

         Dim firstItem As Boolean = _optionsItemsListBox.SelectedIndex = 0
         Dim lastItem As Boolean = _optionsItemsListBox.SelectedIndex = (_optionsItemsListBox.Items.Count - 1)

         If firstItem OrElse _optionsItemsListBox.SelectedItem Is Nothing Then
            _optionsUpButton.Enabled = False
         Else
            _optionsUpButton.Enabled = True
         End If

         If lastItem OrElse _optionsItemsListBox.SelectedItem Is Nothing Then
            _optionsDownButton.Enabled = False
         Else
            _optionsDownButton.Enabled = True
         End If

         If _optionsItemsListBox.SelectedItem Is Nothing Then
            _optionsDeleteButton.Enabled = False
         Else
            _optionsDeleteButton.Enabled = True
         End If
      End Sub

      Private Sub _lockedCheckBox_Click(sender As Object, e As EventArgs) Handles _lockedCheckBox.Click
         UpdateControls()
      End Sub

      Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
         Me.Close()
      End Sub
   End Class
End Namespace
