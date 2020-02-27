Imports Leadtools.Forms.Processing.Omr
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Leadtools.Forms.Processing.Omr.Fields

Partial Public Class FormSpecificDialog
   Inherits Form

   Public ReadOnly Property FormName As String
      Get
         Return txtValue.Text
      End Get
   End Property

   Private currentForm As ITemplateForm

   Public Sub New(ByVal form As ITemplateForm, Optional ByVal nameEditable As Boolean = False)
      InitializeComponent()
      Me.currentForm = form
      txtValue.Enabled = nameEditable
      txtValue.Text = form.Name
      chkChooseIdentifier.DisplayMember = "Name"
      chkChooseIdentifier.SelectionMode = SelectionMode.One
      Dim fields As List(Of Field) = New List(Of Field)()

      For i As Integer = 0 To form.Pages.Count - 1
         Dim page As Page = form.Pages(i)

         fields.AddRange(page.Fields.Where(Function(f As Field)
                                              Return (TypeOf f Is ImageField) = False AndAlso ((TypeOf f Is OmrField) AndAlso (CType(f, OmrField)).Options.TextFormat = OmrTextFormat.Aggregated)
                                           End Function))
      Next

      For i As Integer = 0 To fields.Count - 1
         Dim isChecked As Boolean = form.IdentifierFieldId IsNot Nothing AndAlso fields(i).PageNumber = form.IdentifierFieldId.PageNumber AndAlso fields(i).Name = form.IdentifierFieldId.FieldName
         chkChooseIdentifier.Items.Add(fields(i), isChecked)
      Next
   End Sub

   Private Sub FormSpecificDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      If DialogResult = DialogResult.OK Then

         If String.IsNullOrWhiteSpace(txtValue.Text) Then
            MessageBox.Show("This field cannot be blank.")
            txtValue.Focus()
            e.Cancel = True
            Return
         End If

         currentForm.Name = txtValue.Text
         Dim selectedItems As CheckedListBox.CheckedIndexCollection = chkChooseIdentifier.CheckedIndices

         If selectedItems.Count > 0 Then
            Dim field As Field = CType(chkChooseIdentifier.Items(selectedItems(0)), Field)
            currentForm.IdentifierFieldId = New FieldId(field.PageNumber, field.Name)
         Else
            currentForm.IdentifierFieldId = New FieldId(-1, "")
         End If
      End If
   End Sub

   Private Sub chkChooseIdentifier_ItemCheck(ByVal sender As Object, ByVal e As ItemCheckEventArgs)
      If e.NewValue <> CheckState.Checked Then
         Return
      End If

      Dim selectedItems As CheckedListBox.CheckedIndexCollection = chkChooseIdentifier.CheckedIndices

      If selectedItems.Count > 0 Then
         chkChooseIdentifier.SetItemChecked(selectedItems(0), False)
      End If
   End Sub

End Class
