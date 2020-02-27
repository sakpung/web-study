' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Forms.Processing
Imports System

Partial Public Class SingleSelectionFieldDlg
   Inherits Form
   Private _mainForm As MainForm
   Private _singleSelection As SingleSelectionField
   Private _currentTextBox As TextBox
   Private _firstTb As Boolean
   Private _oldName As String
   Private _nameChanged As Boolean

   Public Sub New(mainForm As MainForm, singleSelection As SingleSelectionField)
      Me.HorizontalScroll.Enabled = False
      Me.HorizontalScroll.Visible = False

      _mainForm = mainForm
      _singleSelection = singleSelection
      Me.AutoScrollPosition = New Point(0, 0)
      _oldName = singleSelection.Name
      _nameChanged = False

      InitializeComponent()
   End Sub

   Private Sub SingleSelectionDlg_Load(sender As Object, e As EventArgs) Handles Me.Load
      _tbName.Text = _singleSelection.Name
      _firstTb = True
      Me.SuspendLayout()
      For i As Integer = 0 To _singleSelection.Fields.Count - 1
         CreateNewField(_singleSelection.Fields(i).OmrField.Name)
         _currentTextBox.Text = _singleSelection.Fields(i).FieldValue
      Next
      Me.ResumeLayout()

      If _gbFields.Bottom >= _btnOK.Top Then
         _btnOK.Location = New Point(_btnOK.Location.X, _gbFields.Bottom + 20)
         _btnCancel.Location = New Point(_btnCancel.Location.X, _gbFields.Bottom + 20)
      End If
   End Sub

   Private Sub CreateNewField(fieldName As String)
      Dim newFieldTop As Integer = -1
      Dim tabIndex As Integer = -1

      If _firstTb Then
         newFieldTop = 20
         tabIndex = 1
         _firstTb = False
      End If

      If _currentTextBox IsNot Nothing Then
         newFieldTop = _currentTextBox.Location.Y + _currentTextBox.Size.Height + 5
         tabIndex = _currentTextBox.TabIndex + 1
      End If

      _currentTextBox = New TextBox()
      _currentTextBox.Location = New System.Drawing.Point(110, newFieldTop)
      _currentTextBox.Name = "tb" + fieldName.Replace(" ", "")
      _currentTextBox.Size = New System.Drawing.Size(211, 20)
      _currentTextBox.TabIndex = tabIndex

      Dim lbl As New Label()
      lbl.AutoSize = True
      lbl.Location = New System.Drawing.Point(19, newFieldTop)
      lbl.Name = "lbl" + fieldName.Replace(" ", "")
      lbl.Size = New System.Drawing.Size(60, 13)
      lbl.Text = fieldName

      _gbFields.Controls.Add(_currentTextBox)
      _gbFields.Controls.Add(lbl)
   End Sub

   Private Sub UpdateFields()
      If _tbName.Text <> _singleSelection.Name Then
         _singleSelection.Name = _tbName.Text
         _nameChanged = True
      End If

      For Each control As Control In _gbFields.Controls
         If TypeOf control Is TextBox Then
            Dim tb As TextBox = TryCast(control, TextBox)
            For i As Integer = 0 To _singleSelection.Fields.Count - 1
               If control.Name.Equals("tb" + _singleSelection.Fields(i).OmrField.Name.Replace(" ", "")) Then
                  Dim field As SingleField = _singleSelection.Fields(i)
                  field.FieldValue = tb.Text
                  _singleSelection.Fields(i) = field
                  Exit For
               End If
            Next
         End If
      Next
   End Sub

   Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
      UpdateFields()
      If _nameChanged Then
         _mainForm.UpdateSingleSelection(_oldName, _singleSelection)
      End If
      Me.Close()
   End Sub
End Class
