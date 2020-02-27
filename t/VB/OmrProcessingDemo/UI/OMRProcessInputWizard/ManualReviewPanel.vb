Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Leadtools.Forms.Processing.Omr
Imports Leadtools.Forms.Processing.Omr.Fields

Partial Public Class ManualReviewPanel
   Inherits WizardStep

   Private _filterTemplate As VerificationParameters.FilterTemplate = VerificationParameters.FilterTemplate.CommonIssues

   Public ReadOnly Property VerificationParameters As VerificationParameters
      Get
         Return ControlsToData()
      End Get
   End Property

   Public ReadOnly Property IsReviewParamPresent As Boolean
      Get
         Return chkThreshold.Checked OrElse chkExactlyOne.Checked OrElse chkAgree.Checked OrElse chkDisagree.Checked
      End Get
   End Property

   Public Sub New(ByVal param As VerificationParameters, ByVal title As String)
      Me.New(title)
      UpdateFilterTemplate(param)
   End Sub

   Public Sub UpdateFilterTemplate(ByVal param As VerificationParameters)
      _filterTemplate = param.Template

      Select Case _filterTemplate
         Case VerificationParameters.FilterTemplate.CommonIssues
            rdbtnCommonIssues.Checked = True
         Case VerificationParameters.FilterTemplate.ChangeAndModified
            rdbtnChangedOrModified.Checked = True
         Case VerificationParameters.FilterTemplate.CorrectOnly
            rdbtnCorrect.Checked = True
         Case VerificationParameters.FilterTemplate.IncorrectOnly
            rdbtnIncorrectOnly.Checked = True
         Case VerificationParameters.FilterTemplate.Custom
            rdbtnCustomize.Checked = True
         Case Else
      End Select

      UpdateFromTemplate(If(_filterTemplate = VerificationParameters.FilterTemplate.Custom, param, VerificationParameters.GetTemplate(_filterTemplate)))
      nudThreshold.Value = param.Threshold
   End Sub

   Public Sub UpdateFromTemplate(ByVal param As VerificationParameters)
      chkThreshold.Checked = param.UseThreshold
      chkAgree.Checked = param.UseAgreeWithKey
      chkDisagree.Checked = param.UseDisagreeWithKey
      chkExactlyOne.Checked = param.UseExactlyOneBubble
      chkAlreadyReviewed.Checked = param.IsReviewed
      chkModified.Checked = param.UseValueChanged
      nudThreshold.Value = param.Threshold
      OnCanProceed()
   End Sub

   Public Sub New(Optional ByVal title As String = "")
      InitializeComponent()
      Me.Title = title
      grpValidation.Text = title
   End Sub

   Private Function ControlsToData() As VerificationParameters
      Return New VerificationParameters(chkThreshold.Checked, chkAgree.Checked, chkDisagree.Checked, chkExactlyOne.Checked, CInt(nudThreshold.Value), chkAlreadyReviewed.Checked, chkModified.Checked) With {
          .Template = _filterTemplate
      }
   End Function

   Private Sub chkThreshold_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      nudThreshold.Enabled = chkThreshold.Checked
      OnCanProceed()
   End Sub

   Friend Sub UpdateUI(ByVal isKeyPresent As Boolean)
      chkDisagree.Enabled = isKeyPresent
      chkAgree.Enabled = isKeyPresent
      rdbtnCorrect.Enabled = isKeyPresent
      rdbtnIncorrectOnly.Enabled = isKeyPresent
      ToggleEnables(_filterTemplate = VerificationParameters.FilterTemplate.Custom)
   End Sub

   Protected Overrides Sub OnCanProceed()
      If rdbtnCustomize.Checked Then
         OnCanProceed(chkAgree.Checked OrElse chkDisagree.Checked OrElse chkExactlyOne.Checked OrElse chkModified.Checked OrElse chkThreshold.Checked OrElse chkAlreadyReviewed.Checked)
      Else
         OnCanProceed(True)
      End If
   End Sub

   Private Sub UnCheckAll()
      chkAgree.Checked = False
      chkDisagree.Checked = False
      chkExactlyOne.Checked = False
      chkThreshold.Checked = False
      chkAlreadyReviewed.Checked = False
      chkModified.Checked = False
   End Sub

   Private Sub ToggleEnables(ByVal v As Boolean)
      chkAgree.Enabled = v AndAlso rdbtnCorrect.Enabled
      chkDisagree.Enabled = v AndAlso rdbtnIncorrectOnly.Enabled
      chkAlreadyReviewed.Enabled = v
      chkExactlyOne.Enabled = v
      chkModified.Enabled = v
      chkThreshold.Enabled = v
   End Sub

   Private Sub rdbtnCommonIssues_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      _filterTemplate = VerificationParameters.FilterTemplate.CommonIssues
      ToggleEnables(False)
      UpdateFromTemplate(VerificationParameters.GetTemplate(_filterTemplate))
   End Sub

   Private Sub rdbtnChangedOrModified_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      _filterTemplate = VerificationParameters.FilterTemplate.ChangeAndModified
      ToggleEnables(False)
      UpdateFromTemplate(VerificationParameters.GetTemplate(_filterTemplate))
   End Sub

   Private Sub rdbtnCorrect_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      _filterTemplate = VerificationParameters.FilterTemplate.CorrectOnly
      ToggleEnables(False)
      UpdateFromTemplate(VerificationParameters.GetTemplate(_filterTemplate))
   End Sub

   Private Sub rdbtnIncorrectOnly_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      _filterTemplate = VerificationParameters.FilterTemplate.IncorrectOnly
      ToggleEnables(False)
      UpdateFromTemplate(VerificationParameters.GetTemplate(_filterTemplate))
   End Sub

   Private Sub rdbtnCustomize_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      _filterTemplate = VerificationParameters.FilterTemplate.Custom
      ToggleEnables(True)
      UpdateFromTemplate(VerificationParameters.GetTemplate(_filterTemplate))
   End Sub

   Private Sub chkFilter_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      OnCanProceed()
   End Sub
End Class

<Serializable()>
Public Structure VerificationParameters
   Public Enum FilterTemplate
      CommonIssues
      ChangeAndModified
      CorrectOnly
      IncorrectOnly
      Custom
   End Enum

   Public Const DEFAULT_OMR_THRESHOLD As Integer = 73
   Public Template As FilterTemplate
   Public Property UseThreshold As Boolean
   Public Property UseAgreeWithKey As Boolean
   Public Property UseDisagreeWithKey As Boolean
   Public Property UseExactlyOneBubble As Boolean
   Public Property IsReviewed As Boolean
   Public Property Threshold As Integer
   Public Property UseValueChanged As Boolean

   Public Sub New(ByVal useThreshold As Boolean, ByVal useAgree As Boolean, ByVal useDisagree As Boolean, ByVal useExactly As Boolean, ByVal threshold As Integer, ByVal isReviewed As Boolean, ByVal useValueChanged As Boolean)
      Me.UseThreshold = useThreshold
      Me.UseAgreeWithKey = useAgree
      Me.UseDisagreeWithKey = useDisagree
      Me.UseExactlyOneBubble = useExactly
      Me.Threshold = threshold
      Me.UseValueChanged = useValueChanged
      Me.IsReviewed = isReviewed
      Template = FilterTemplate.CommonIssues
   End Sub

   Public Function IsAtLeastOneTrue(ByVal incoming As VerificationParameters) As Boolean
      Return (UseThreshold AndAlso Threshold > incoming.Threshold) OrElse (UseAgreeWithKey AndAlso incoming.UseAgreeWithKey) OrElse (UseDisagreeWithKey AndAlso incoming.UseDisagreeWithKey) OrElse (UseExactlyOneBubble AndAlso incoming.UseExactlyOneBubble OrElse IsReviewed AndAlso incoming.IsReviewed OrElse UseValueChanged AndAlso incoming.UseValueChanged)
   End Function

   Public Function IsAtLeastOneTrueWithoutKey(ByVal incoming As VerificationParameters) As Boolean
      Return (UseThreshold AndAlso Threshold > incoming.Threshold) OrElse (UseExactlyOneBubble AndAlso incoming.UseExactlyOneBubble OrElse IsReviewed AndAlso incoming.IsReviewed OrElse UseValueChanged AndAlso incoming.UseValueChanged)
   End Function

   Public Shared ReadOnly Property AllParameters As VerificationParameters
      Get
         Return New VerificationParameters(True, True, True, True, DEFAULT_OMR_THRESHOLD, False, False)
      End Get
   End Property

   Public Shared Function GetTemplate(ByVal template As FilterTemplate) As VerificationParameters
      Dim vp As VerificationParameters = New VerificationParameters()

      Select Case template
         Case FilterTemplate.CommonIssues
            vp = New VerificationParameters(True, False, False, True, DEFAULT_OMR_THRESHOLD, False, False)
         Case FilterTemplate.ChangeAndModified
            vp = New VerificationParameters(False, False, False, False, DEFAULT_OMR_THRESHOLD, True, True)
         Case FilterTemplate.CorrectOnly
            vp = New VerificationParameters(False, True, False, False, DEFAULT_OMR_THRESHOLD, False, False)
         Case FilterTemplate.IncorrectOnly
            vp = New VerificationParameters(False, False, True, False, DEFAULT_OMR_THRESHOLD, False, False)
         Case FilterTemplate.Custom
            vp = New VerificationParameters(False, False, False, False, DEFAULT_OMR_THRESHOLD, False, False)
      End Select

      vp.Template = template
      Return vp
   End Function
End Structure
