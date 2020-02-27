Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Partial Public Class IntroDialog
   Inherits Form

   Public Enum StartupType
      None
      NewTemplate
      LoadTemplate
      LoadWorkspace
      LoadBackupTemplate
   End Enum

   Public Property Start As StartupType

   Public Sub New(ByVal recoverVisible As Boolean)
      InitializeComponent()
      Start = StartupType.None
      rdbtnLoadAutosave.Visible = recoverVisible
      lblDescAutoRecover.Visible = recoverVisible
   End Sub

   Private Sub rdbtnCreateNewTemplate_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      Start = StartupType.NewTemplate
   End Sub

   Private Sub rdbtnLoadTemplate_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      Start = StartupType.LoadTemplate
   End Sub

   Private Sub rdbtnLoadWorkspace_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      Start = StartupType.LoadWorkspace
   End Sub

   Private Sub rdbtnLoadAutosave_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      Start = StartupType.LoadBackupTemplate
   End Sub

   Private Sub IntroDialog_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
      If Me.DialogResult = DialogResult.Cancel Then
         Start = StartupType.None
      End If
   End Sub
End Class
