Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Partial Public Class TextInputDialog
   Inherits Form

   Public ReadOnly Property Value As String
      Get
         Return txtValue.Text
      End Get
   End Property

   Private IsValid As Func(Of String, String)

   Public Sub New(Optional ByVal isValid As Func(Of String, String) = Nothing)
      InitializeComponent()
      txtValue.Focus()
      Me.IsValid = isValid
   End Sub

   Public Sub New(ByVal text As String, Optional ByVal isValid As Func(Of String, String) = Nothing)
      Me.New(isValid)
      txtValue.Text = text
      txtValue.SelectAll()
   End Sub

   Private Sub TextInputDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      If DialogResult = DialogResult.OK Then

         If IsValid IsNot Nothing Then
            Dim message As String = IsValid(txtValue.Text)

            If Not String.IsNullOrEmpty(message) Then
               MessageBox.Show(message)
               e.Cancel = True
            End If
         ElseIf String.IsNullOrWhiteSpace(txtValue.Text) Then
            MessageBox.Show("This field cannot be blank.")
            e.Cancel = True
         End If
      End If
   End Sub
End Class
