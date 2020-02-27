Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Partial Public Class InfoDialog
   Inherits Form

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub InfoDialog_Load(ByVal sender As Object, ByVal e As EventArgs)
      chkShowOnStartup.Checked = Settings.Default.ShowInfoDialog
   End Sub

   Private Sub InfoDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      Settings.Default.ShowInfoDialog = chkShowOnStartup.Checked
   End Sub

   Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs)
      Me.Close()
   End Sub
End Class
