' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core

Namespace DocumentCleanupDemo
   Partial Public Class LineRemoveDialog : Inherits Form

      '' The LineRemoveCommand Class is part of our LEAD Document Imaging functions. This class will remove horizontal and vertical lines in a 1-bit black and white image.
      '' This dialog will update the following members of this class:
      '' LineRemoveCommand.GapLength, this member will be used to set the maximum length of a break or a hole in a line.   
      '' LineRemoveCommand.MaximumLineWidth, this member will be used to set the maximum average width of a line that is considered for removal.   
      '' LineRemoveCommand.MaximumWallPercent, this member will be used to set the maximum number of wall slices (expressed as a percent of the total length of the line) that are allowed.   
      '' LineRemoveCommand.MinimumLineLength, this member will be used to set the minimum length of a line considered for removal.   
      '' LineRemoveCommand.Type Flag that indicates which lines to remove. (horizontal or vertical lines)   
      '' LineRemoveCommand.Variance, this member will be used to set the amount of width change that is tolerated between adjacent line slices.   
      '' LineRemoveCommand.Wall, this member will be used to set the height of a wall. Walls are slices of a line that are too wide to be considered part of the line.   

      Private _LineRemoveCommand As LineRemoveCommand = Nothing
      Private _MinimumLineLength As Double = 0.0
      Private _MaximumLineWidth As Double = 0.0
      Private _WallHeight As Double = 0.0
      Private _Variance As Double = 0.0
      Private _GapLength As Double = 0.0
      Public XResolution As Integer = 150
      Public YResolution As Integer = 150

      Public Sub New()
         InitializeComponent()
         _LineRemoveCommand = New LineRemoveCommand()
         InitializeUI()
      End Sub

      Public Sub New(ByVal lineRmvCommand As LineRemoveCommand, ByVal XResolution As Integer, ByVal YResolution As Integer)
         InitializeComponent()
         _LineRemoveCommand = lineRmvCommand
         Me.XResolution = XResolution
         Me.YResolution = YResolution
         InitializeUI()
      End Sub

      Public Property LineRemoveCommand() As LineRemoveCommand
         Get
            UpdateCommand()
            Return _LineRemoveCommand
         End Get
         Set(ByVal value As LineRemoveCommand)
            _LineRemoveCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = Windows.Forms.DialogResult.Cancel
      End Sub
      Private Sub InitializeUI()
         '' Initialize the LineRemoveCommand Dialog with default values
         If (_LineRemoveCommand.Flags And LineRemoveCommandFlags.UseDpi) = LineRemoveCommandFlags.UseDpi Then
            '' If true, the measure for all properties of the LineRemoveCommand is thousandths of an inch
            _Variance = CDbl(_LineRemoveCommand.Variance) / 1000
            _GapLength = CDbl(_LineRemoveCommand.GapLength) / 1000
            _MaximumLineWidth = CDbl(_LineRemoveCommand.MaximumLineWidth) / 1000
            _MinimumLineLength = CDbl(_LineRemoveCommand.MinimumLineLength) / 1000
            _WallHeight = CDbl(_LineRemoveCommand.Wall) / 1000

            _tbVariance.Text = _Variance.ToString()
            _tbGapLength.Text = _GapLength.ToString()
            _tbMaximumLineWidth.Text = _MaximumLineWidth.ToString()
            _tbMinimumLineLength.Text = _MinimumLineLength.ToString()
            _tbWallHeight.Text = _WallHeight.ToString()
            _tbMaximumWallPercent.Text = _LineRemoveCommand.MaximumWallPercent.ToString()


            _cbUseDPI.Checked = True

            _lbl5.Text = "inches"
            _lbl6.Text = "inches"
            _lbl7.Text = "inches"
            _lbl8.Text = "inches"
            _lbl9.Text = "inches"
         Else
            _tbVariance.Text = _LineRemoveCommand.Variance.ToString()
            _tbGapLength.Text = _LineRemoveCommand.GapLength.ToString()
            _tbMaximumLineWidth.Text = _LineRemoveCommand.MaximumLineWidth.ToString()
            _tbMinimumLineLength.Text = _LineRemoveCommand.MinimumLineLength.ToString()
            _tbMaximumWallPercent.Text = _LineRemoveCommand.MaximumWallPercent.ToString()
            _tbWallHeight.Text = _LineRemoveCommand.Wall.ToString()

            '' Converts the used unit to inches
            ConvertToInches()
            _cbUseDPI_CheckedChanged(Me, Nothing)
         End If

         AddHandler _cbUseDPI.CheckedChanged, AddressOf _cbUseDPI_CheckedChanged

         If (_LineRemoveCommand.Type And LineRemoveCommandType.Horizontal) = LineRemoveCommandType.Horizontal Then
            _rbHorizontalLines.Checked = True
         Else
            _rbVerticalLines.Checked = True
         End If

         If (_LineRemoveCommand.Flags And LineRemoveCommandFlags.UseGap) = LineRemoveCommandFlags.UseGap Then
            _cbMaximumGap.Checked = True
         End If

         If (_LineRemoveCommand.Flags And LineRemoveCommandFlags.UseVariance) = LineRemoveCommandFlags.UseVariance Then
            _cbLineVariance.Checked = True
         End If

         If (_LineRemoveCommand.Flags And LineRemoveCommandFlags.RemoveEntire) = LineRemoveCommandFlags.RemoveEntire Then
            _cbRemoveEntireLine.Checked = True
         End If

         _tbDPI.Text = "dpi: " & Me.XResolution.ToString() & ", " & Me.YResolution.ToString()
      End Sub
      Private Sub UpdateCommand()
         '' Determine how the LineRemoveCommand will work by setting the values to its members and flags
         _LineRemoveCommand.Flags = LineRemoveCommandFlags.None
         _LineRemoveCommand.Flags = CType(IIf(_cbUseDPI.Checked, LineRemoveCommandFlags.UseDpi, LineRemoveCommandFlags.None), LineRemoveCommandFlags) _
         Or CType(IIf(_cbMaximumGap.Checked, LineRemoveCommandFlags.UseGap, LineRemoveCommandFlags.None), LineRemoveCommandFlags) _
         Or CType(IIf(_cbRemoveEntireLine.Checked, LineRemoveCommandFlags.RemoveEntire, LineRemoveCommandFlags.None), LineRemoveCommandFlags) _
         Or CType(IIf(_cbLineVariance.Checked, LineRemoveCommandFlags.UseVariance, LineRemoveCommandFlags.None), LineRemoveCommandFlags)

         If _LineRemoveCommand.Flags = LineRemoveCommandFlags.None Then
            _LineRemoveCommand.Flags = (New LineRemoveCommand()).Flags
         End If

         If _cbUseDPI.Checked Then
            _LineRemoveCommand.GapLength = Convert.ToInt32(_GapLength * 1000)
            _LineRemoveCommand.MaximumLineWidth = Convert.ToInt32(_MaximumLineWidth * 1000)
            _LineRemoveCommand.MinimumLineLength = Convert.ToInt32(_MinimumLineLength * 1000)
            _LineRemoveCommand.Variance = Convert.ToInt32(_Variance * 1000)
            _LineRemoveCommand.Wall = Convert.ToInt32(_WallHeight * 1000)
         Else
            If _tbGapLength.Text <> "" Then
               _LineRemoveCommand.GapLength = Convert.ToInt32(_tbGapLength.Text)
            End If
            If _tbMaximumLineWidth.Text <> "" Then
               _LineRemoveCommand.MaximumLineWidth = Convert.ToInt32(_tbMaximumLineWidth.Text)
            End If
            If _tbMinimumLineLength.Text <> "" Then
               _LineRemoveCommand.MinimumLineLength = Convert.ToInt32(_tbMinimumLineLength.Text)
            End If
            If _tbVariance.Text <> "" Then
               _LineRemoveCommand.Variance = Convert.ToInt32(_tbVariance.Text)
            End If
            If _tbWallHeight.Text <> "" Then
               _LineRemoveCommand.Wall = Convert.ToInt32(_tbWallHeight.Text)
            End If
         End If

         If _tbMaximumWallPercent.Text <> "" Then
            Dim nWallPercent As Integer = Convert.ToInt32(_tbMaximumWallPercent.Text)
            If nWallPercent < 0 Then
               nWallPercent = 0
            End If
            If nWallPercent > 100 Then
               nWallPercent = 100
            End If
            _LineRemoveCommand.MaximumWallPercent = nWallPercent
         End If

         If _rbHorizontalLines.Checked Then
            _LineRemoveCommand.Type = LineRemoveCommandType.Horizontal
         Else
            _LineRemoveCommand.Type = LineRemoveCommandType.Vertical
         End If
      End Sub

      Private Sub _cbUseDPI_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
         If _cbUseDPI.Checked Then
            '' Converts the used unit to inches
            ConvertToInches()
            _lbl5.Text = "inches"
            _lbl6.Text = "inches"
            _lbl7.Text = "inches"
            _lbl8.Text = "inches"
            _lbl9.Text = "inches"
         Else
            '' Converts the used unit to pixels
            ConvertToPixels()
            _lbl5.Text = "pixels"
            _lbl6.Text = "pixels"
            _lbl7.Text = "pixels"
            _lbl8.Text = "pixels"
            _lbl9.Text = "pixels"
         End If
      End Sub

      Private Sub _cbLineVariance_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbLineVariance.CheckedChanged
         _tbVariance.Enabled = _cbLineVariance.Checked
      End Sub

      Private Sub _cbMaximumGap_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbMaximumGap.CheckedChanged
         _tbGapLength.Enabled = _cbMaximumGap.Checked
      End Sub
      Private Sub ConvertToInches()
         If _tbVariance.Text <> "" Then
            _Variance = Convert.ToDouble(_tbVariance.Text) / Me.XResolution
         End If
         If _tbGapLength.Text <> "" Then
            _GapLength = Convert.ToDouble(_tbGapLength.Text) / Me.XResolution
         End If
         If _tbMinimumLineLength.Text <> "" Then
            _MinimumLineLength = Convert.ToDouble(_tbMinimumLineLength.Text) / Me.XResolution
         End If
         If _tbMaximumLineWidth.Text <> "" Then
            _MaximumLineWidth = Convert.ToDouble(_tbMaximumLineWidth.Text) / Me.XResolution
         End If
         If _tbWallHeight.Text <> "" Then
            _WallHeight = Convert.ToDouble(_tbWallHeight.Text) / Me.XResolution
         End If

         _tbVariance.Text = _Variance.ToString()
         _tbGapLength.Text = _GapLength.ToString()
         _tbMaximumLineWidth.Text = _MaximumLineWidth.ToString()
         _tbMinimumLineLength.Text = _MinimumLineLength.ToString()
         _tbWallHeight.Text = _WallHeight.ToString()
      End Sub
      Private Sub ConvertToPixels()
         _tbVariance.Text = Convert.ToInt32((Me.XResolution * _Variance)).ToString()
         _tbGapLength.Text = Convert.ToInt32((Me.XResolution * _GapLength)).ToString()
         _tbMinimumLineLength.Text = Convert.ToInt32((Me.XResolution * _MinimumLineLength)).ToString()
         _tbMaximumLineWidth.Text = Convert.ToInt32((Me.XResolution * _MaximumLineWidth)).ToString()
         _tbWallHeight.Text = Convert.ToInt32((Me.XResolution * _WallHeight)).ToString()
      End Sub

      Private Sub _tbMinimumLineLength_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMinimumLineLength.TextChanged
         _tbMinimumLineLength.Text = MainForm.IsValidNumber(_tbMinimumLineLength.Text, 0, 10000)

      End Sub

      Private Sub _tbMaximumLineWidth_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMaximumLineWidth.TextChanged
         _tbMaximumLineWidth.Text = MainForm.IsValidNumber(_tbMaximumLineWidth.Text, 0, 10000)

      End Sub

      Private Sub _tbWallHeight_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbWallHeight.TextChanged
         _tbWallHeight.Text = MainForm.IsValidNumber(_tbWallHeight.Text, 0, 10000)

      End Sub

      Private Sub _tbMaximumWallPercent_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMaximumWallPercent.TextChanged
         _tbMaximumWallPercent.Text = MainForm.IsValidNumber(_tbMaximumWallPercent.Text, 0, 100)

      End Sub

      Private Sub _tbVariance_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbVariance.TextChanged
         _tbVariance.Text = MainForm.IsValidNumber(_tbVariance.Text, 0, 10000)
      End Sub

      Private Sub _tbGapLength_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbGapLength.TextChanged
         _tbGapLength.Text = MainForm.IsValidNumber(_tbGapLength.Text, 0, 10000)
      End Sub
   End Class
End Namespace
