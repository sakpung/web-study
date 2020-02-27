Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Partial Public Class RotatePagesDialog
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public PageCount As Integer
   Public FirstPageNumber As Integer
   Public LastPageNumber As Integer
   Public SelectedPageNumber As Integer

   Public Enum DirectionMode
      Direction90Clockwise
      Direction90CounterClockwise
      Direction180
   End Enum
   Public Direction As DirectionMode = DirectionMode.Direction90Clockwise

   Public Enum EvenOddMode
      All
      OnlyEven
      OnlyOdd
   End Enum

   Public EventOdd As EvenOddMode = EvenOddMode.All

   Public Enum OrientationMode
      All
      PortraitOnly
      LandscapeOnly
   End Enum

   Public Orientation As OrientationMode = OrientationMode.All

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If (Not DesignMode) Then
         _directionComboBox.Items.Add("Clockwise 90 degrees")
         _directionComboBox.Items.Add("Counter-clockwise 90 degrees")
         _directionComboBox.Items.Add("180 degrees")

         _evenOddComboBox.Items.Add("Even and odd Pages")
         _evenOddComboBox.Items.Add("Only even Pages")
         _evenOddComboBox.Items.Add("Only odd Pages")

         _orientationComboBox.Items.Add("Pages of any orientation")
         _orientationComboBox.Items.Add("Portrait pages only")
         _orientationComboBox.Items.Add("Landscape pages only")

         _ofLabel.Text = "of " & Me.PageCount.ToString()

         _fromTextBox.Text = Me.FirstPageNumber.ToString()
         _toTextBox.Text = Me.LastPageNumber.ToString()

         AddHandler _fromTextBox.LostFocus, AddressOf _fromTextBox_LostFocus
         AddHandler _toTextBox.LostFocus, AddressOf _toTextBox_LostFocus

         _allRadioButton.Checked = True
         _directionComboBox.SelectedIndex = CInt(Direction)
         _evenOddComboBox.SelectedIndex = CInt(EventOdd)
         _orientationComboBox.SelectedIndex = CInt(Orientation)

         UpdateUIState()
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _fromTextBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      Dim value As String = _fromTextBox.Text
      Dim tempValue As Integer
      If String.IsNullOrEmpty(value) OrElse (Not Integer.TryParse(value, tempValue)) OrElse tempValue < 1 OrElse tempValue > LastPageNumber Then
         _fromTextBox.Text = FirstPageNumber.ToString()
         Return
      End If

      FirstPageNumber = tempValue
   End Sub

   Private Sub _toTextBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      Dim value As String = _toTextBox.Text
      Dim tempValue As Integer
      If String.IsNullOrEmpty(value) OrElse (Not Integer.TryParse(value, tempValue)) OrElse tempValue < 1 OrElse tempValue > PageCount OrElse tempValue < FirstPageNumber Then
         _toTextBox.Text = LastPageNumber.ToString()
         Return
      End If

      LastPageNumber = tempValue
   End Sub

   Private Sub UpdateUIState()
      _fromTextBox.Enabled = _pagesRadioButton.Checked
      _toTextBox.Enabled = _pagesRadioButton.Checked
   End Sub

   Private Sub _allRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      If _allRadioButton.Checked Then
         FirstPageNumber = 1
         LastPageNumber = PageCount
         _fromTextBox.Text = FirstPageNumber.ToString()
         _toTextBox.Text = LastPageNumber.ToString()
      End If

      UpdateUIState()
   End Sub

   Private Sub _selectedRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      If _selectedRadioButton.Checked Then
         FirstPageNumber = SelectedPageNumber
         LastPageNumber = SelectedPageNumber
         _fromTextBox.Text = FirstPageNumber.ToString()
         _toTextBox.Text = LastPageNumber.ToString()
      End If
      UpdateUIState()
   End Sub

   Private Sub _pagesRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      UpdateUIState()
   End Sub

   Private Sub _okButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      If _allRadioButton.Checked Then
         FirstPageNumber = 1
         LastPageNumber = PageCount
      ElseIf _selectedRadioButton.Checked Then
         FirstPageNumber = SelectedPageNumber
         LastPageNumber = SelectedPageNumber
      End If

      Direction = CType(_directionComboBox.SelectedIndex, DirectionMode)
      EventOdd = CType(_evenOddComboBox.SelectedIndex, EvenOddMode)
      Orientation = CType(_orientationComboBox.SelectedIndex, OrientationMode)
   End Sub
End Class
