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

Partial Public Class OcrFieldDialog
   Inherits Form

   Private tff As OcrField

   Public Sub New(ByVal ff As OcrField)
      InitializeComponent()
      tff = ff
      txtName.Focus()
      txtName.SelectAll()
   End Sub

   Private Sub rdBtnTextType_CheckChanged(ByVal sender As Object, ByVal e As EventArgs)
   End Sub

   Private Sub chkEnableOCR_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
   End Sub

   Private Sub OcrFieldDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      If DialogResult = DialogResult.OK Then

         If String.IsNullOrEmpty(txtName.Text) Then
            MessageBox.Show("Name cannot be empty")
            e.Cancel = True
            Return
         End If

         tff.Name = txtName.Text
      End If
   End Sub
End Class
