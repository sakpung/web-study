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
   Partial Public Class DotRemoveDialog : Inherits Form

      '' The DotRemoveCommand Class is part of our LEAD Document Imaging functions. This class will find and removes dots and specks of various sizes.
      '' This dialog will update the following members of this class:
      '' DotRemoveCommand.MaximumDotHeight to set the maximum height of a dot to be removed.   
      '' DotRemoveCommand.MaximumDotWidth to set the maximum width of a dot to be removed.   
      '' DotRemoveCommand.MinimumDotHeight to set the minimum height of a dot to be removed.   
      '' DotRemoveCommand.MinimumDotWidth to set the minimum width of a dot to be removed.  

      Private _DotRemoveCommand As DotRemoveCommand = Nothing
      Public XResolution As Integer = 150
      Public YResolution As Integer = 150
      Private _MaximumDotHeight As Double = 0.0
      Private _MaximumDotWidth As Double = 0.0
      Private _MinimumDotHeight As Double = 0.0
      Private _MinimumDotWidth As Double = 0.0

      Public Sub New()
         InitializeComponent()
         _DotRemoveCommand = New DotRemoveCommand()
         InitializeUI()
      End Sub

      Public Sub New(ByVal DotRemoveCommand As DotRemoveCommand, ByVal XResolution As Integer, ByVal YResolution As Integer)
         InitializeComponent()
         _DotRemoveCommand = DotRemoveCommand
         Me.XResolution = XResolution
         Me.YResolution = YResolution
         InitializeUI()
      End Sub
      Public Property DotRemoveCommand() As DotRemoveCommand
         Get
            UpdateCommand()
            Return _DotRemoveCommand
         End Get
         Set(ByVal value As DotRemoveCommand)
            _DotRemoveCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         Dim OK As Boolean = True
         UpdateCommand()

         If (_tbMinimumDotWidth.Text <> "") AndAlso (_tbMaximumDotWidth.Text <> "") Then

            If (Convert.ToInt32(_tbMinimumDotWidth.Text)) > (Convert.ToInt32(_tbMaximumDotWidth.Text)) Then
               MessageBox.Show("Minimum width must be less than maximum width")
               OK = False
            End If
         End If
         If (_tbMinimumDotHeight.Text <> "") AndAlso (_tbMaximumDotHeight.Text <> "") Then
            If (Convert.ToInt32(_tbMinimumDotHeight.Text)) > (Convert.ToInt32(_tbMaximumDotHeight.Text)) Then
               MessageBox.Show("Minimum Height must be less than maximum Height")
               OK = False
            End If
         End If

         If OK Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
         End If
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = Windows.Forms.DialogResult.Cancel
      End Sub
      Private Sub InitializeUI()
         '' Initialize the DotRemove Dialog with default values
         If (_DotRemoveCommand.Flags And DotRemoveCommandFlags.UseDpi) = DotRemoveCommandFlags.UseDpi Then
            _MaximumDotHeight = CDbl(_DotRemoveCommand.MaximumDotHeight) / 1000
            _MaximumDotWidth = CDbl(_DotRemoveCommand.MaximumDotWidth) / 1000
            _MinimumDotHeight = CDbl(_DotRemoveCommand.MinimumDotHeight) / 1000
            _MinimumDotWidth = CDbl(_DotRemoveCommand.MinimumDotWidth) / 1000

            _tbMinimumDotHeight.Text = _MinimumDotHeight.ToString()
            _tbMinimumDotWidth.Text = _MinimumDotWidth.ToString()
            _tbMaximumDotHeight.Text = _MaximumDotHeight.ToString()
            _tbMaximumDotWidth.Text = _MaximumDotWidth.ToString()

            _cbUseDPI.Checked = True
            _lbl5.Text = "inches"
            _lbl6.Text = "inches"
            _lbl7.Text = "inches"
            _lbl8.Text = "inches"
         Else
            _tbMinimumDotHeight.Text = _DotRemoveCommand.MinimumDotHeight.ToString()
            _tbMinimumDotWidth.Text = _DotRemoveCommand.MinimumDotWidth.ToString()
            _tbMaximumDotHeight.Text = _DotRemoveCommand.MaximumDotHeight.ToString()
            _tbMaximumDotWidth.Text = _DotRemoveCommand.MaximumDotWidth.ToString()

            '' Converts the used unit to inches
            ConvertToInches()
            _cbUseDPI_CheckedChanged(Me, Nothing)
         End If

         If (_DotRemoveCommand.Flags And DotRemoveCommandFlags.UseDiagonals) = DotRemoveCommandFlags.UseDiagonals Then
            _cbUseDiagonals.Checked = True
         End If
         If (_DotRemoveCommand.Flags And DotRemoveCommandFlags.UseSize) = DotRemoveCommandFlags.UseSize Then
            _cbUseDotDimensions.Checked = True
         End If
         AddHandler _cbUseDPI.CheckedChanged, AddressOf _cbUseDPI_CheckedChanged

         _tbDPI.Text = "dpi: " & Me.XResolution.ToString() & ", " & Me.YResolution.ToString()
         _cbUseDotDimensions_CheckedChanged(Me, Nothing)
      End Sub
      Private Sub UpdateCommand()
         _DotRemoveCommand.Flags = DotRemoveCommandFlags.None
         _DotRemoveCommand.Flags = CType(IIf(_cbUseDPI.Checked, DotRemoveCommandFlags.UseDpi, DotRemoveCommandFlags.None), DotRemoveCommandFlags) _
         Or CType(IIf(_cbUseDiagonals.Checked, DotRemoveCommandFlags.UseDiagonals, DotRemoveCommandFlags.None), DotRemoveCommandFlags) _
         Or CType(IIf(_cbUseDotDimensions.Checked, DotRemoveCommandFlags.UseSize, DotRemoveCommandFlags.None), DotRemoveCommandFlags)

         If _DotRemoveCommand.Flags = DotRemoveCommandFlags.None Then
            _DotRemoveCommand.Flags = (New DotRemoveCommand()).Flags
         End If

         '' Updates the dimensions of the Dot
         If _cbUseDotDimensions.Checked Then
            If _cbUseDPI.Checked Then
               _DotRemoveCommand.MaximumDotHeight = Convert.ToInt32(_MaximumDotHeight * 1000)
               _DotRemoveCommand.MaximumDotWidth = Convert.ToInt32(_MaximumDotWidth * 1000)
               _DotRemoveCommand.MinimumDotHeight = Convert.ToInt32(_MinimumDotHeight * 1000)
               _DotRemoveCommand.MinimumDotWidth = Convert.ToInt32(_MinimumDotWidth * 1000)
            Else
               If _tbMaximumDotHeight.Text <> "" Then
                  _DotRemoveCommand.MaximumDotHeight = Convert.ToInt32(_tbMaximumDotHeight.Text)
               End If
               If _tbMaximumDotWidth.Text <> "" Then
                  _DotRemoveCommand.MaximumDotWidth = Convert.ToInt32(_tbMaximumDotWidth.Text)
               End If
               If _tbMinimumDotHeight.Text <> "" Then
                  _DotRemoveCommand.MinimumDotHeight = Convert.ToInt32(_tbMinimumDotHeight.Text)
               End If
               If _tbMinimumDotWidth.Text <> "" Then
                  _DotRemoveCommand.MinimumDotWidth = Convert.ToInt32(_tbMinimumDotWidth.Text)
               End If
            End If
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
         Else
            '' Converts the used unit to pixels
            ConvertToPixels()
            _lbl5.Text = "pixels"
            _lbl6.Text = "pixels"
            _lbl7.Text = "pixels"
            _lbl8.Text = "pixels"
         End If
      End Sub
      Private Sub ConvertToInches()
         If _tbMaximumDotHeight.Text <> "" Then
            _MaximumDotHeight = Convert.ToDouble(_tbMaximumDotHeight.Text) / Me.XResolution
         End If
         If _tbMaximumDotWidth.Text <> "" Then
            _MaximumDotWidth = Convert.ToDouble(_tbMaximumDotWidth.Text) / Me.XResolution
         End If
         If _tbMinimumDotHeight.Text <> "" Then
            _MinimumDotHeight = Convert.ToDouble(_tbMinimumDotHeight.Text) / Me.XResolution
         End If
         If _tbMinimumDotWidth.Text <> "" Then
            _MinimumDotWidth = Convert.ToDouble(_tbMinimumDotWidth.Text) / Me.XResolution
         End If

         _tbMinimumDotHeight.Text = _MinimumDotHeight.ToString()
         _tbMinimumDotWidth.Text = _MinimumDotWidth.ToString()
         _tbMaximumDotHeight.Text = _MaximumDotHeight.ToString()
         _tbMaximumDotWidth.Text = _MaximumDotWidth.ToString()
      End Sub
      Private Sub ConvertToPixels()
         _tbMinimumDotHeight.Text = Convert.ToInt32((Me.XResolution * _MinimumDotHeight)).ToString()
         _tbMinimumDotWidth.Text = Convert.ToInt32((Me.XResolution * _MinimumDotWidth)).ToString()
         _tbMaximumDotHeight.Text = Convert.ToInt32((Me.XResolution * _MaximumDotHeight)).ToString()
         _tbMaximumDotWidth.Text = Convert.ToInt32((Me.XResolution * _MaximumDotWidth)).ToString()
      End Sub

      Private Sub _cbUseDotDimensions_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbUseDotDimensions.CheckedChanged
         _gbDotDimensions.Enabled = _cbUseDotDimensions.Checked
      End Sub

      Private Sub _tbMinimumDotWidth_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMinimumDotWidth.TextChanged
         _tbMinimumDotWidth.Text = MainForm.IsValidNumber(_tbMinimumDotWidth.Text, 1, 10000)
      End Sub

      Private Sub _tbMinimumDotHeight_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMinimumDotHeight.TextChanged
         _tbMinimumDotHeight.Text = MainForm.IsValidNumber(_tbMinimumDotHeight.Text, 1, 10000)
      End Sub

      Private Sub _tbMaximumDotWidth_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMaximumDotWidth.TextChanged
         _tbMaximumDotWidth.Text = MainForm.IsValidNumber(_tbMaximumDotWidth.Text, 1, 10000)

      End Sub

      Private Sub _tbMaximumDotHeight_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMaximumDotHeight.TextChanged
         _tbMaximumDotHeight.Text = MainForm.IsValidNumber(_tbMaximumDotHeight.Text, 1, 10000)

      End Sub
   End Class
End Namespace
