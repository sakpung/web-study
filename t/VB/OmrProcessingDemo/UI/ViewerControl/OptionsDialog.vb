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

Partial Public Class OptionsDialog
   Inherits Form

   Private _autoEstimateMissingOmr As Boolean

   Public Sub New(ByVal autoEstimateMissingOmr As Boolean)
      InitializeComponent()
      chkAutoEstimate.Checked = autoEstimateMissingOmr
      chkAutosave.Checked = Settings.Default.AutoSaveEnabled
      nudAutosave.Value = Settings.Default.AutoSaveDelay
   End Sub

   Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs)
      _autoEstimateMissingOmr = chkAutoEstimate.Checked
      Settings.Default.AutoSaveDelay = CInt(nudAutosave.Value)
      Settings.Default.AutoSaveEnabled = chkAutosave.Checked
      Me.Close()
   End Sub

   Private Sub chkAutosave_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      nudAutosave.Enabled = chkAutosave.Checked
   End Sub

   Public ReadOnly Property AutoEstimateMissingOmr As Boolean
      Get
         Return _autoEstimateMissingOmr
      End Get
   End Property
End Class
