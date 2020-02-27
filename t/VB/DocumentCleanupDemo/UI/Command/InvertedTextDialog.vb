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
   Partial Public Class InvertedTextDialog : Inherits Form

      '' The InvertedTextCommand Class is part of our LEAD Document Imaging functions. This class will find and modify areas of inverted text in a 1-bit black and white image
      '' This dialog will update the following members of this class:
      '' Members that controls the Opacity
      '' InvertedTextCommand.MaximumBlackPercent, this member will be used to set the maximum percent of total pixels in an inverted text area that must be black.   
      '' InvertedTextCommand.MinimumBlackPercent, this member will be used to set the minimum percent of total pixels in an inverted text area that must be black.
      '' Members that controls the inverted text dimensions   
      '' InvertedTextCommand.MinimumInvertHeight, this member will be used to set the minimum height of an area that is considered to be inverted text.   
      '' InvertedTextCommand.MinimumInvertWidth, this member will be used to set the minimum width of an area that is considered to be inverted text. 

      Private _InvertedTextCommand As InvertedTextCommand = Nothing
      Public XResolution As Integer = 150
      Public YResolution As Integer = 150
      Private _MinimumInvertWidth As Double = 0.0
      Private _MinimumInvertHeight As Double = 0.0

      Public Sub New()
         InitializeComponent()
         _InvertedTextCommand = New InvertedTextCommand()
         InitializeUI()
      End Sub
      Public Sub New(ByVal InvertedTextCommand As InvertedTextCommand, ByVal XResolution As Integer, ByVal YResolution As Integer)
         InitializeComponent()
         _InvertedTextCommand = InvertedTextCommand
         Me.XResolution = XResolution
         Me.YResolution = YResolution
         InitializeUI()
      End Sub
      Public Property InvertedTextCommand() As InvertedTextCommand
         Get
            UpdateCommand()
            Return _InvertedTextCommand
         End Get
         Set(ByVal value As InvertedTextCommand)
            _InvertedTextCommand = value
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
         '' Initialize the InvertedTextCommand Dialog with default values
         If (_InvertedTextCommand.Flags And InvertedTextCommandFlags.UseDpi) = InvertedTextCommandFlags.UseDpi Then
            '' If true, the measure for all properties of the InvertedTextCommand is thousandths of an inch
            _MinimumInvertWidth = CDbl(_InvertedTextCommand.MinimumInvertWidth) / 1000
            _MinimumInvertHeight = CDbl(_InvertedTextCommand.MinimumInvertHeight) / 1000

            _tbMinimumInvertWidth.Text = _MinimumInvertWidth.ToString()
            _tbMinimumInvertHeight.Text = _MinimumInvertHeight.ToString()

            _cbUseDPI.Checked = True

            _lbl3.Text = "inches"
            _lbl4.Text = "inches"
         Else
            _tbMinimumInvertWidth.Text = _InvertedTextCommand.MinimumInvertWidth.ToString()
            _tbMinimumInvertHeight.Text = _InvertedTextCommand.MinimumInvertHeight.ToString()

            '' Converts the used unit to inches
            ConvertToInches()
            _cbUseDPI_CheckedChanged(Me, Nothing)
         End If
         AddHandler _cbUseDPI.CheckedChanged, AddressOf _cbUseDPI_CheckedChanged
         _tbDPI.Text = "dpi: " & Me.XResolution.ToString() & ", " & Me.YResolution.ToString()

         _tbMinimumBlackPercent.Text = _InvertedTextCommand.MinimumBlackPercent.ToString()
         _tbMaximumBlackPercent.Text = _InvertedTextCommand.MaximumBlackPercent.ToString()
      End Sub
      Private Sub UpdateCommand()
         '' Determine how the InvertedTextCommand will work by setting the values to its members and flags
         _InvertedTextCommand.Flags = InvertedTextCommandFlags.None
         _InvertedTextCommand.Flags = CType(IIf(_cbUseDPI.Checked, InvertedTextCommandFlags.UseDpi, InvertedTextCommandFlags.None), InvertedTextCommandFlags)

         If _cbUseDPI.Checked Then
            _InvertedTextCommand.MinimumInvertWidth = Convert.ToInt32(_MinimumInvertWidth * 1000)
            _InvertedTextCommand.MinimumInvertHeight = Convert.ToInt32(_MinimumInvertHeight * 1000)
         Else
            If _tbMinimumInvertWidth.Text <> "" Then
               _InvertedTextCommand.MinimumInvertWidth = Convert.ToInt32(_tbMinimumInvertWidth.Text)
            End If
            If _tbMinimumInvertHeight.Text <> "" Then
               _InvertedTextCommand.MinimumInvertHeight = Convert.ToInt32(_tbMinimumInvertHeight.Text)
            End If
         End If
         If _tbMaximumBlackPercent.Text <> "" Then
            Dim nPercent As Integer = Convert.ToInt32(_tbMaximumBlackPercent.Text)
            If nPercent > 100 Then
               nPercent = 100
            End If
            If nPercent < 0 Then
               nPercent = 0
            End If
            _InvertedTextCommand.MaximumBlackPercent = nPercent
         End If
         If _tbMinimumBlackPercent.Text <> "" Then
            Dim nPercent As Integer = Convert.ToInt32(_tbMinimumBlackPercent.Text)
            If nPercent > 100 Then
               nPercent = 100
            End If
            If nPercent < 0 Then
               nPercent = 0
            End If
            _InvertedTextCommand.MinimumBlackPercent = nPercent
         End If
      End Sub
      Private Sub _cbUseDPI_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
         If _cbUseDPI.Checked Then
            '' Converts the used unit to inches
            ConvertToInches()
            _lbl3.Text = "inches"
            _lbl4.Text = "inches"
         Else
            '' Converts the used unit to pixels
            ConvertToPixels()
            _lbl3.Text = "pixels"
            _lbl4.Text = "pixels"
         End If
      End Sub
      Private Sub ConvertToInches()
         If _tbMinimumInvertWidth.Text <> "" Then
            _MinimumInvertWidth = Convert.ToDouble(_tbMinimumInvertWidth.Text) / Me.XResolution
         End If
         If _tbMinimumInvertHeight.Text <> "" Then
            _MinimumInvertHeight = Convert.ToDouble(_tbMinimumInvertHeight.Text) / Me.XResolution
         End If

         _tbMinimumInvertWidth.Text = _MinimumInvertWidth.ToString()
         _tbMinimumInvertHeight.Text = _MinimumInvertHeight.ToString()
      End Sub
      Private Sub ConvertToPixels()
         _tbMinimumInvertWidth.Text = Convert.ToInt32((Me.XResolution * _MinimumInvertWidth)).ToString()
         _tbMinimumInvertHeight.Text = Convert.ToInt32((Me.XResolution * _MinimumInvertHeight)).ToString()
      End Sub

      Private Sub _tbMinimumInvertWidth_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMinimumInvertWidth.TextChanged
         _tbMinimumInvertWidth.Text = MainForm.IsValidNumber(_tbMinimumInvertWidth.Text, 0, 10000)
      End Sub

      Private Sub _tbMinimumInvertHeight_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMinimumInvertHeight.TextChanged
         _tbMinimumInvertHeight.Text = MainForm.IsValidNumber(_tbMinimumInvertHeight.Text, 0, 10000)

      End Sub

      Private Sub _tbMinimumBlackPercent_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMinimumBlackPercent.TextChanged
         _tbMinimumBlackPercent.Text = MainForm.IsValidNumber(_tbMinimumBlackPercent.Text, 0, 100)

      End Sub

      Private Sub _tbMaximumBlackPercent_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMaximumBlackPercent.TextChanged
         _tbMaximumBlackPercent.Text = MainForm.IsValidNumber(_tbMaximumBlackPercent.Text, 0, 100)
      End Sub

   End Class
End Namespace
