' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Pdf

Namespace PDFFormsDemo
   Public Class PDFFormContolsHelper
      Public Shared Function FormFieldsToControls(formFields As IList(Of PDFFormField), docResolution As Integer) As List(Of FormFieldControl)
         Dim formControls As New List(Of FormFieldControl)()

         For Each field As PDFFormField In formFields
            formControls.Add(CreateFieldControl(field, docResolution))
         Next

         Return formControls
      End Function

      Public Shared Sub SetPageControlsToCanvas(page As PDFPageItem, imageViewer As ImageViewer)
         imageViewer.Controls.Clear()

         For Each formFieldControl As FormFieldControl In page.FormControls
            imageViewer.Controls.Add(formFieldControl)
         Next
      End Sub

      Public Shared Sub UpdateFormFieldsFromControls(formFields As IList(Of PDFFormField), controls As IList(Of FormFieldControl))
         For i As Integer = 0 To controls.Count - 1
            controls(i).UpdateFormField(formFields(i))
         Next
      End Sub

      Private Shared Function CreateRadioButton(field As PDFFormField) As FormFieldControl
         Dim formFieldControl As FormFieldControl = New RadioFormField()

         Dim groupPanel As List(Of PDFRadioButton) = Nothing

         If Not PDFRadioButton.RadioButtonGroups.TryGetValue(field.GroupId.ToString(), groupPanel) Then
            PDFRadioButton.RadioButtonGroups(field.GroupId.ToString()) = New List(Of PDFRadioButton)()
         End If

         PDFRadioButton.RadioButtonGroups(field.GroupId.ToString()).Add(CType(formFieldControl, RadioFormField).PDFRadioButton)

         Return formFieldControl

      End Function

      Private Shared Function CreateFieldControl(field As PDFFormField, docResolution As Integer) As FormFieldControl
         Dim formFieldControl As FormFieldControl = Nothing
         Select Case field.FieldType
            Case PDFFormField.FieldTypeCheckBox
               If ((field.FieldFlags And PDFFormField.FieldFlagsButtonRadio) = PDFFormField.FieldFlagsButtonRadio) Or
                 ((field.FieldFlags And PDFFormField.FieldFlagsButtonRadioInUnison) = PDFFormField.FieldFlagsButtonRadioInUnison) Or
                 field.GroupId > 0 Then
                  formFieldControl = CreateRadioButton(field)
               Else
                  formFieldControl = New CheckFormField()
               End If
               Exit Select

            Case PDFFormField.FieldTypeRadioButton
               formFieldControl = CreateRadioButton(field)
               Exit Select

            Case PDFFormField.FieldTypeComboBox
               formFieldControl = New ComboFormField()
               Exit Select

            Case PDFFormField.FieldTypeListBox
               formFieldControl = New ListFormField()
               Exit Select

            Case PDFFormField.FieldTypeTextBox
               formFieldControl = New TextFormField()
               Exit Select
         End Select

         formFieldControl.DocResolution = docResolution
         formFieldControl.InitControl(field)

         Return formFieldControl
      End Function
   End Class
End Namespace
