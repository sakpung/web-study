' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports Leadtools
Imports System.Windows.Forms
Imports Leadtools.Forms.Processing
Imports Leadtools.Ocr

Partial Public Class ColumnOptions : Inherits Form
   Private _ocrField As OcrFormField
   Private _column As TableColumn
   Private stopUpdate As Boolean = False
   Public Property Column() As TableColumn
      Get
         Return _column
      End Get
      Set(value As TableColumn)
         _column = value
         _ocrField = value.OcrField
         stopUpdate = True
         If Not value Is Nothing Then
            _nudLeft.Value = CInt(_ocrField.Bounds.Left)
            _nudTop.Value = CInt(_ocrField.Bounds.Top)
            _nudWidth.Value = CInt(_ocrField.Bounds.Width)
            _nudHeight.Value = CInt(_ocrField.Bounds.Height)

            _txt_ColumnOptionsFieldName.Text = _ocrField.Name

            _cbIsKeyColumn.Checked = Me.Column.IsKeyColumn

            If TypeOf _ocrField Is TextFormField Then
               _gb_OcrColumnOption.Enabled = True
               _gb_OmrColumnOptions.Enabled = False

               Dim textField As TextFormField = CType(IIf(TypeOf _ocrField Is TextFormField, _ocrField, Nothing), TextFormField)

               _chkEnableIcr.Checked = textField.EnableIcr
               _chkEnableOcr.Checked = textField.EnableOcr
               _rbTextTypeChar.Checked = (textField.Type = TextFieldType.Character)
               _rbtextTypeNum.Checked = (textField.Type = TextFieldType.Numerical)

            ElseIf TypeOf _ocrField Is OmrFormField Then
               _gb_OcrColumnOption.Enabled = False
               _gb_OmrColumnOptions.Enabled = True

               Dim omrField As OmrFormField = CType(IIf(TypeOf _ocrField Is OmrFormField, _ocrField, Nothing), OmrFormField)

               _rbOMRWithFrame.Checked = omrField.FrameMethod = OcrOmrFrameDetectionMethod.WithFrame
               _rbOMRWithoutFrame.Checked = omrField.FrameMethod = OcrOmrFrameDetectionMethod.WithoutFrame
               _rbOMRAutoFrame.Checked = omrField.FrameMethod = OcrOmrFrameDetectionMethod.Auto
               _rbOMRSensitivityLowest.Checked = omrField.Sensitivity = OcrOmrSensitivity.Lowest
               _rbOMRSensitivityLow.Checked = omrField.Sensitivity = OcrOmrSensitivity.Low
               _rbOMRSensitivityHigh.Checked = omrField.Sensitivity = OcrOmrSensitivity.High
               _rbOMRSensitivityHighest.Checked = omrField.Sensitivity = OcrOmrSensitivity.Highest
            End If
         Else
            _nudLeft.Value = 0
            _nudTop.Value = 0
            _nudWidth.Value = 0
            _nudHeight.Value = 0
            _txt_ColumnOptionsFieldName.Text = ""
         End If
         stopUpdate = False
      End Set
   End Property

   Public Sub New(enableIcr As Boolean)
      InitializeComponent()

      If Not enableIcr Then
         _chkEnableIcr.Enabled = False
      End If
   End Sub

   Private Sub UpdateField()
      'One or more of the fields properties changed so we need to update the field data
      'which is stored in the annotation objects UserData
      Dim currentField As FormField = _ocrField
      Dim fieldType As String
      If (TypeOf currentField Is TextFormField) Then
         fieldType = "Text"
      Else
         fieldType = "Omr"
      End If

      Select Case fieldType
         Case "Text"
            If Not (TypeOf currentField Is TextFormField) Then
               currentField = New TextFormField()
            End If

            'set text field options
            CType(IIf(TypeOf currentField Is TextFormField, currentField, Nothing), TextFormField).EnableIcr = _chkEnableIcr.Checked
            CType(IIf(TypeOf currentField Is TextFormField, currentField, Nothing), TextFormField).EnableOcr = _chkEnableOcr.Checked
            If _rbTextTypeChar.Checked Then
               CType(IIf(TypeOf currentField Is TextFormField, currentField, Nothing), TextFormField).Type = TextFieldType.Character
            Else
               CType(IIf(TypeOf currentField Is TextFormField, currentField, Nothing), TextFormField).Type = TextFieldType.Numerical
            End If

         Case "Omr"
            If Not (TypeOf currentField Is OmrFormField) Then
               currentField = New OmrFormField()
            End If

            'set omr field options
            If _rbOMRWithFrame.Checked Then
               CType(IIf(TypeOf currentField Is OmrFormField, currentField, Nothing), OmrFormField).FrameMethod = OcrOmrFrameDetectionMethod.WithFrame
            ElseIf _rbOMRWithoutFrame.Checked Then
               CType(IIf(TypeOf currentField Is OmrFormField, currentField, Nothing), OmrFormField).FrameMethod = OcrOmrFrameDetectionMethod.WithoutFrame
            ElseIf _rbOMRAutoFrame.Checked Then
               CType(IIf(TypeOf currentField Is OmrFormField, currentField, Nothing), OmrFormField).FrameMethod = OcrOmrFrameDetectionMethod.Auto
            End If

            If _rbOMRSensitivityLowest.Checked Then
               CType(IIf(TypeOf currentField Is OmrFormField, currentField, Nothing), OmrFormField).Sensitivity = OcrOmrSensitivity.Lowest
            ElseIf _rbOMRSensitivityLow.Checked Then
               CType(IIf(TypeOf currentField Is OmrFormField, currentField, Nothing), OmrFormField).Sensitivity = OcrOmrSensitivity.Low
            ElseIf _rbOMRSensitivityHigh.Checked Then
               CType(IIf(TypeOf currentField Is OmrFormField, currentField, Nothing), OmrFormField).Sensitivity = OcrOmrSensitivity.High
            ElseIf _rbOMRSensitivityHighest.Checked Then
               CType(IIf(TypeOf currentField Is OmrFormField, currentField, Nothing), OmrFormField).Sensitivity = OcrOmrSensitivity.Highest
            End If
      End Select

      currentField.Bounds = New LeadRect(Convert.ToInt32(_nudLeft.Value), Convert.ToInt32(_nudTop.Value), Convert.ToInt32(_nudWidth.Value), Convert.ToInt32(_nudHeight.Value))
      currentField.Name = _txt_ColumnOptionsFieldName.Text
      _chkDropoutWords.Checked = (currentField.Dropout And DropoutFlag.WordsDropout) = DropoutFlag.WordsDropout
      _chkDropoutCells.Checked = (currentField.Dropout And DropoutFlag.CellsDropout) = DropoutFlag.CellsDropout
   End Sub

   Private Sub OptionsChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txt_ColumnOptionsFieldName.TextChanged, _rbtextTypeNum.CheckedChanged, _rbTextTypeChar.CheckedChanged, _rbOMRWithoutFrame.CheckedChanged, _rbOMRWithFrame.CheckedChanged, _rbOMRSensitivityLowest.CheckedChanged, _rbOMRSensitivityLow.CheckedChanged, _rbOMRSensitivityHighest.CheckedChanged, _rbOMRSensitivityHigh.CheckedChanged, _rbOMRAutoFrame.CheckedChanged, _nudWidth.ValueChanged, _nudTop.ValueChanged, _nudLeft.ValueChanged, _nudHeight.ValueChanged, _chkEnableOcr.CheckedChanged, _chkEnableIcr.CheckedChanged
      If (Not stopUpdate) Then
         UpdateField()
      End If
   End Sub

   Private Sub _cbIsKeyColumn_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbIsKeyColumn.CheckedChanged
      Me.Column.IsKeyColumn = _cbIsKeyColumn.Checked
   End Sub

   Private Sub _chkDropoutWords_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      Dim currentField As FormField = _ocrField
      If Me._chkDropoutWords.Checked = True Then
         currentField.Dropout = currentField.Dropout Or DropoutFlag.WordsDropout
      Else
         currentField.Dropout = currentField.Dropout And Not DropoutFlag.WordsDropout
      End If
   End Sub

   Private Sub _chkDropoutCells_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      Dim currentField As FormField = _ocrField
      If Me._chkDropoutCells.Checked = True Then
         currentField.Dropout = currentField.Dropout Or DropoutFlag.CellsDropout
      Else
         currentField.Dropout = currentField.Dropout And Not DropoutFlag.CellsDropout
      End If
   End Sub

   Private Sub _btnOK_Click(sender As System.Object, e As System.EventArgs) Handles _btnOK.Click
      Me.Close()
   End Sub
End Class
