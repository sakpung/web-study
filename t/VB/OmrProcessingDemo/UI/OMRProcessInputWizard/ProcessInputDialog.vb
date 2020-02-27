Imports Leadtools
Imports Leadtools.Forms.Processing.Omr.Fields
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

Partial Public Class ProcessInputDialog
   Inherits Form

   Private _steps As WizardStep()
   Private _index As Integer = 0

   Public Sub New(ByVal wizardSteps As WizardStep())
      InitializeComponent()
      _steps = wizardSteps

      For i As Integer = 0 To _steps.Length - 1
         AddHandler _steps(i).CanProceed, AddressOf ProcessInputDialog_CanProceed
         _steps(i).Location = New Point(12, 3)
      Next

      Controls.AddRange(_steps)
      _index = 0
      ChangeWizardStep(0)
      btnPrevious.Enabled = _index > 0
   End Sub

   Public Sub New(ByVal singleStep As WizardStep, ByVal okButtonText As String, Optional ByVal cancelNeeded As Boolean = True)
      InitializeComponent()
      singleStep.Location = New Point(12, 3)
      singleStep.Visible = True
      btnPrevious.Visible = False
      btnNext.Visible = False
      btnOK.Visible = True
      btnOK.Text = okButtonText
      btnCancel.Visible = cancelNeeded
      AddHandler singleStep.CanProceed, AddressOf ProcessInputDialog_CanProceed
      Controls.Add(singleStep)
      Me.Text = singleStep.Title
   End Sub

   Private Sub ProcessInputDialog_CanProceed(ByVal sender As Object, ByVal e As UpdatedEventArgs)
      btnNext.Enabled = e.CanProceed
      btnOK.Enabled = e.CanProceed
   End Sub

   Private Sub ChangeWizardStep(ByVal v As Integer)
      _index += v
      Me.Text = _steps(_index).Title
      btnPrevious.Enabled = _index > 0

      If _index = _steps.Length - 1 Then
         btnNext.Enabled = False
         btnOK.Enabled = True
         btnOK.BringToFront()
         btnNext.SendToBack()
      Else
         btnNext.Enabled = True
         btnOK.Enabled = False
         btnOK.SendToBack()
         btnNext.BringToFront()
      End If

      For i As Integer = 0 To _steps.Length - 1
         _steps(i).Visible = i = _index
      Next
   End Sub

   Private Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs)
      ChangeWizardStep(1)
   End Sub

   Private Sub btnPrevious_Click(ByVal sender As Object, ByVal e As EventArgs)
      ChangeWizardStep(-1)
      btnNext.Enabled = True
   End Sub
End Class
