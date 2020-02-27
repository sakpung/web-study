Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Reflection
Imports System.IO

Partial Public Class TwainDocumentCleanupMessage
   Inherits Form

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Function ShouldShow() As Boolean
      Try
         If TryCast(Settings.[Default]("ShowAgain"), String) = "False" Then Return False
      Catch
         Return True
      End Try
      Return True
   End Function

   Private Sub Information_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
      _chkShowAgain.Checked = Not ShouldShow()
   End Sub

   Private Sub checkBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkShowAgain.CheckedChanged
      If _chkShowAgain.Checked = True Then
         Settings.[Default]("ShowAgain") = "False"
      Else
         Settings.[Default]("ShowAgain") = "True"
      End If

      Settings.[Default].Save()
   End Sub
End Class
