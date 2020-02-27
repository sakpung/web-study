Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Xml.Serialization

Public Structure TempData
   Public Expected As Tuple(Of Color, Boolean)
   Public Correct As Tuple(Of Color, Boolean)
   Public Incorrect As Tuple(Of Color, Boolean)
   Public ModCorrect As Tuple(Of Color, Boolean)
   Public ModIncorrect As Tuple(Of Color, Boolean)
   Public Review As Tuple(Of Color, Boolean)
End Structure

Partial Public Class HighlightOptionsDialog
   Inherits Form

   Private _clsExpected As DataGridViewCellStyle = New DataGridViewCellStyle()
   Private _clsCorrect As DataGridViewCellStyle = New DataGridViewCellStyle()
   Private _clsIncorrect As DataGridViewCellStyle = New DataGridViewCellStyle()
   Private _clsModifiedCorrect As DataGridViewCellStyle = New DataGridViewCellStyle()
   Private _clsModifiedIncorrect As DataGridViewCellStyle = New DataGridViewCellStyle()
   Private _clsReview As DataGridViewCellStyle = New DataGridViewCellStyle()
   Private _storedData As TempData = New TempData()

   Public ReadOnly Property ClExpected As DataGridViewCellStyle
      Get
         Return _clsExpected
      End Get
   End Property

   Public ReadOnly Property ClCorrect As DataGridViewCellStyle
      Get
         Return _clsCorrect
      End Get
   End Property

   Public ReadOnly Property ClIncorrect As DataGridViewCellStyle
      Get
         Return _clsIncorrect
      End Get
   End Property

   Public ReadOnly Property ClModifiedCorrect As DataGridViewCellStyle
      Get
         Return _clsModifiedCorrect
      End Get
   End Property

   Public ReadOnly Property ClModifiedIncorrect As DataGridViewCellStyle
      Get
         Return _clsModifiedIncorrect
      End Get
   End Property

   Public ReadOnly Property ClReview As DataGridViewCellStyle
      Get
         Return _clsReview
      End Get
   End Property

   Public Property ManualReviewPanel As ManualReviewPanel
   Private colorCode As ColorCodeLegend

   Public Event ColorCodeUpdated As EventHandler

   Public Sub New()
      InitializeComponent()
      chkCorrect.Tag = btnCorrect
      chkCorrectModified.Tag = btnModCorrect
      chkExpected.Tag = btnExpected
      chkIncorrect.Tag = btnIncorrect
      chkIncorrectModified.Tag = btnModIncorrect
      chkReview.Tag = btnReview
      UpdateCell(_clsExpected, Settings.Default.ClsExpected, Settings.Default.ClExpectedEnabled)
      UpdateCell(_clsCorrect, Settings.Default.ClsCorrect, Settings.Default.ClCorrectEnabled)
      UpdateCell(_clsIncorrect, Settings.Default.ClsIncorrect, Settings.Default.ClIncorrectEnabled)
      UpdateCell(_clsModifiedCorrect, Settings.Default.ClsModifiedCorrect, Settings.Default.ClModifiedCorrectEnabled)
      UpdateCell(_clsModifiedIncorrect, Settings.Default.ClsModifiedIncorrect, Settings.Default.ClModifiedIncorrectEnabled)
      UpdateCell(_clsReview, Settings.Default.ClsReview, Settings.Default.ClReviewEnabled)
      colorCode = New ColorCodeLegend()
      colorCode.UpdateLegend(Me)
   End Sub

   Private Sub DataToControls()
      MapControls(Settings.Default.ClsCorrect, Settings.Default.ClCorrectEnabled, chkCorrect, btnCorrect)
      MapControls(Settings.Default.ClsExpected, Settings.Default.ClExpectedEnabled, chkExpected, btnExpected)
      MapControls(Settings.Default.ClsIncorrect, Settings.Default.ClIncorrectEnabled, chkIncorrect, btnIncorrect)
      MapControls(Settings.Default.ClsModifiedCorrect, Settings.Default.ClModifiedCorrectEnabled, chkCorrectModified, btnModCorrect)
      MapControls(Settings.Default.ClsModifiedIncorrect, Settings.Default.ClModifiedIncorrectEnabled, chkIncorrectModified, btnModIncorrect)
      MapControls(Settings.Default.ClsReview, Settings.Default.ClReviewEnabled, chkReview, btnReview)
   End Sub

   Private Sub StoreData()
      _storedData.Correct = New Tuple(Of Color, Boolean)(Settings.Default.ClsCorrect, Settings.Default.ClCorrectEnabled)
      _storedData.Expected = New Tuple(Of Color, Boolean)(Settings.Default.ClsExpected, Settings.Default.ClExpectedEnabled)
      _storedData.Incorrect = New Tuple(Of Color, Boolean)(Settings.Default.ClsIncorrect, Settings.Default.ClIncorrectEnabled)
      _storedData.ModCorrect = New Tuple(Of Color, Boolean)(Settings.Default.ClsModifiedCorrect, Settings.Default.ClModifiedCorrectEnabled)
      _storedData.ModIncorrect = New Tuple(Of Color, Boolean)(Settings.Default.ClsModifiedIncorrect, Settings.Default.ClModifiedIncorrectEnabled)
      _storedData.Review = New Tuple(Of Color, Boolean)(Settings.Default.ClsReview, Settings.Default.ClReviewEnabled)
   End Sub

   Private Sub MapControls(ByVal color As Color, ByVal enabled As Boolean, ByVal box As CheckBox, ByVal button As Button)
      box.Checked = enabled
      button.BackColor = color
   End Sub

   Private Sub ControlsToData()
      Settings.Default.ClsCorrect = btnCorrect.BackColor
      Settings.Default.ClCorrectEnabled = chkCorrect.Checked
      Settings.Default.ClsIncorrect = btnIncorrect.BackColor
      Settings.Default.ClIncorrectEnabled = chkIncorrect.Checked
      Settings.Default.ClsExpected = btnExpected.BackColor
      Settings.Default.ClExpectedEnabled = chkExpected.Checked
      Settings.Default.ClsReview = btnReview.BackColor
      Settings.Default.ClReviewEnabled = chkReview.Checked
      Settings.Default.ClsModifiedCorrect = btnModCorrect.BackColor
      Settings.Default.ClModifiedCorrectEnabled = chkCorrectModified.Checked
      Settings.Default.ClsModifiedIncorrect = btnModIncorrect.BackColor
      Settings.Default.ClModifiedIncorrectEnabled = chkIncorrectModified.Checked
   End Sub

   Private Sub HighlightOptionsDialog_Shown(ByVal sender As Object, ByVal e As EventArgs)
      DataToControls()
      StoreData()
      btnCriteria.Enabled = ManualReviewPanel IsNot Nothing
   End Sub

   Private Sub btnColorChange_Click(ByVal sender As Object, ByVal e As EventArgs)
      Using cd As ColorDialog = New ColorDialog()
         Dim button As Button = TryCast(sender, Button)
         cd.Color = button.BackColor
         cd.FullOpen = False
         cd.SolidColorOnly = True
         cd.AllowFullOpen = False

         If cd.ShowDialog() = DialogResult.OK Then
            button.BackColor = cd.Color
         End If
      End Using
   End Sub

   Private Sub rdbtn_CheckChanged(ByVal sender As Object, ByVal e As EventArgs)
      Dim box As CheckBox = TryCast(sender, CheckBox)
      Dim button As Button = TryCast(box.Tag, Button)
      button.Enabled = box.Checked
      btnCriteria.Enabled = chkReview.Checked
   End Sub

   Private Sub HighlightOptionsDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      If DialogResult = DialogResult.OK Then
         ControlsToData()
      End If

      If DialogResult = DialogResult.Cancel Then
         RevertToInitial()
      End If

      UpdateCell(_clsExpected, Settings.Default.ClsExpected, Settings.Default.ClExpectedEnabled)
      UpdateCell(_clsCorrect, Settings.Default.ClsCorrect, Settings.Default.ClCorrectEnabled)
      UpdateCell(_clsIncorrect, Settings.Default.ClsIncorrect, Settings.Default.ClIncorrectEnabled)
      UpdateCell(_clsModifiedCorrect, Settings.Default.ClsModifiedCorrect, Settings.Default.ClModifiedCorrectEnabled)
      UpdateCell(_clsModifiedIncorrect, Settings.Default.ClsModifiedIncorrect, Settings.Default.ClModifiedIncorrectEnabled)
      UpdateCell(_clsReview, Settings.Default.ClsReview, Settings.Default.ClReviewEnabled)
      Settings.Default.Save()
      colorCode.UpdateLegend(Me)
   End Sub

   Private Sub RevertToInitial()
      Settings.Default.ClsCorrect = _storedData.Correct.Item1
      Settings.Default.ClCorrectEnabled = _storedData.Correct.Item2
      Settings.Default.ClsIncorrect = _storedData.Incorrect.Item1
      Settings.Default.ClIncorrectEnabled = _storedData.Incorrect.Item2
      Settings.Default.ClsExpected = _storedData.Expected.Item1
      Settings.Default.ClExpectedEnabled = _storedData.Expected.Item2
      Settings.Default.ClsReview = _storedData.Review.Item1
      Settings.Default.ClReviewEnabled = _storedData.Review.Item2
      Settings.Default.ClsModifiedCorrect = _storedData.ModCorrect.Item1
      Settings.Default.ClModifiedCorrectEnabled = _storedData.ModCorrect.Item2
      Settings.Default.ClsModifiedIncorrect = _storedData.ModIncorrect.Item1
      Settings.Default.ClModifiedIncorrectEnabled = _storedData.ModIncorrect.Item2
   End Sub

   Private Sub UpdateCell(ByVal clStyle As DataGridViewCellStyle, ByVal color As Color, ByVal enabled As Boolean)
      clStyle.BackColor = If(enabled, color, color.White)
   End Sub

   Private Sub btnCriteria_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim pid As ProcessInputDialog = New ProcessInputDialog(ManualReviewPanel, "Update Criteria")
      Dim vp As VerificationParameters = ManualReviewPanel.VerificationParameters

      If pid.ShowDialog(Me.ParentForm) = DialogResult.OK Then
         OnColorCodeUpdated()
      Else
         ManualReviewPanel.UpdateFilterTemplate(vp)
      End If
   End Sub

   Friend Sub ToggleColorCode()
      If colorCode Is Nothing OrElse colorCode.IsDisposed Then
         colorCode = New ColorCodeLegend()
      End If

      If colorCode.Visible = False Then
         colorCode.Show(Me.ParentForm)
      Else
         HideColorCode()
      End If

      colorCode.BringToFront()
   End Sub

   Friend Sub HideColorCode()
      If colorCode IsNot Nothing AndAlso Not colorCode.IsDisposed AndAlso colorCode.Visible Then
         colorCode.Hide()
      End If
   End Sub

   Private Sub btnApply_Click(ByVal sender As Object, ByVal e As EventArgs)
      ControlsToData()
      UpdateCell(_clsExpected, Settings.Default.ClsExpected, Settings.Default.ClExpectedEnabled)
      UpdateCell(_clsCorrect, Settings.Default.ClsCorrect, Settings.Default.ClCorrectEnabled)
      UpdateCell(_clsIncorrect, Settings.Default.ClsIncorrect, Settings.Default.ClIncorrectEnabled)
      UpdateCell(_clsModifiedCorrect, Settings.Default.ClsModifiedCorrect, Settings.Default.ClModifiedCorrectEnabled)
      UpdateCell(_clsModifiedIncorrect, Settings.Default.ClsModifiedIncorrect, Settings.Default.ClModifiedIncorrectEnabled)
      UpdateCell(_clsReview, Settings.Default.ClsReview, Settings.Default.ClReviewEnabled)
      colorCode.UpdateLegend(Me)
      OnColorCodeUpdated()
   End Sub

   Private Sub OnColorCodeUpdated()
      RaiseEvent ColorCodeUpdated(Me, EventArgs.Empty)
   End Sub
End Class
