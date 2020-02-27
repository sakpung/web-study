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

Partial Public Class OmrCollectionDialog
   Inherits Form

   Private f As OmrCollection

   Public Sub New(ByVal f As OmrCollection, ByVal isGraded As Boolean)
      InitializeComponent()
      Me.f = f
      txtName.Text = f.Name
      txtNote.Text = f.Note
      _numCorrect.Value = CDec(f.CorrectGrade)
      _numIncorrect.Value = CDec(f.IncorrectGrade)
      _numNoResponse.Value = CDec(f.NoResponseGrade)
      grpGradingOptions.Enabled = isGraded
   End Sub

   Private Sub OmrCollectionDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      If DialogResult = DialogResult.OK Then

         If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("The field name cannot be blank.")
            e.Cancel = True
            Return
         End If

         f.Name = txtName.Text
         f.Note = txtNote.Text
         f.CorrectGrade = Convert.ToDouble(_numCorrect.Value)
         f.IncorrectGrade = Convert.ToDouble(_numIncorrect.Value)
         f.NoResponseGrade = Convert.ToDouble(_numNoResponse.Value)
      End If
   End Sub
End Class
