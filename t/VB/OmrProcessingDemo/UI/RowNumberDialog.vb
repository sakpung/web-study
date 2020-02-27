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

Partial Public Class RowNumberDialog
   Inherits Form

   Public ReadOnly Property Template As String
      Get
         Return txtValue.Text
      End Get
   End Property

   Public ReadOnly Property StartingValue As Integer
      Get
         Return CInt(nudStart.Value)
      End Get
   End Property

   Public Sub New(ByVal omrField As OmrField)
      InitializeComponent()
      txtValue.Text = GetFriendlyFieldTemplate(omrField.Options.FieldOrientation)
      txtValue.Focus()
      txtValue.SelectAll()
   End Sub

   Public Shared Function GetFriendlyFieldTemplate(ByVal orientation As OmrFieldOrientation) As String
      Select Case orientation
         Case OmrFieldOrientation.RowWise
            Return "Row %"
         Case OmrFieldOrientation.ColumnWise
            Return "Column %"
         Case OmrFieldOrientation.FreeFlow
            Return "Area %"
         Case Else
            Return ""
      End Select
   End Function

   Private Sub txtValue_Enter(ByVal sender As Object, ByVal e As EventArgs)
      Dim tb As TextBox = CType(sender, TextBox)
      Dim tt As ToolTip = New ToolTip()
      tt.Show("Use '%' as placeholder for number", Me, tb.Left, tb.Top, 5000)
   End Sub

   Private Sub RowNumberDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      If String.IsNullOrWhiteSpace(txtValue.Text) Then
         MessageBox.Show("This field cannot be blank.")
         txtValue.Focus()
         e.Cancel = True
      ElseIf txtValue.Text.IndexOf("%"c) < 0 Then
         MessageBox.Show("The '%' placeholder must be present.")
         txtValue.Focus()
         e.Cancel = True
      End If
   End Sub
End Class
