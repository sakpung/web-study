Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Partial Public Class ColorCodeLegend
   Inherits Form

   Public Sub New()
      InitializeComponent()
   End Sub

   Friend Sub UpdateLegend(ByVal highlightOptionsDlg As HighlightOptionsDialog)
      lblAnswers.BackColor = highlightOptionsDlg.ClExpected.BackColor
      lblCorrect.BackColor = highlightOptionsDlg.ClCorrect.BackColor
      lblIncorrect.BackColor = highlightOptionsDlg.ClIncorrect.BackColor
      lblModCorrect.BackColor = highlightOptionsDlg.ClModifiedCorrect.BackColor
      lblModIncorrect.BackColor = highlightOptionsDlg.ClModifiedIncorrect.BackColor
      lblReview.BackColor = highlightOptionsDlg.ClReview.BackColor
      Me.Invalidate()
   End Sub

   Private Sub ColorCodeLegend_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      If e.CloseReason = CloseReason.ApplicationExitCall Then
         Return
      End If

      e.Cancel = True
      Visible = False
   End Sub
End Class
