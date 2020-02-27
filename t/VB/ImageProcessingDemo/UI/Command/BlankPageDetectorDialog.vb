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
Imports Leadtools.ImageProcessing.Core

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the AverageCommand

   Partial Public Class BlankPageDetectorDialog : Inherits Form

      Enum Units
         Pixels
         Inches
         Centimeters
      End Enum

      Private _BlankPageDetectorCommand As BlankPageDetectorCommand
      Private RasImage As RasterImage
      Private _Left, _Top, _Right, _Bottom As Integer
      Private _unit As Units

      Public Sub New()
         InitializeComponent()
         _BlankPageDetectorCommand = New BlankPageDetectorCommand()
         _Left = 1
         _Top = 1
         _Right = 1
         _Bottom = 1

         _BlankPageDetectorCommand.Flags = BlankPageDetectorCommandFlags.UseAdvanced Or BlankPageDetectorCommandFlags.UsePixels
         _unit = Units.Pixels

         'Set command default values
         InitializeUI()
      End Sub

      Public Sub New(ByVal TempImage As RasterImage)
         InitializeComponent()
         _BlankPageDetectorCommand = New BlankPageDetectorCommand()
         _Left = 1
         _Top = 1
         _Right = 1
         _Bottom = 1
         RasImage = TempImage

         _BlankPageDetectorCommand.Flags = BlankPageDetectorCommandFlags.UseAdvanced Or BlankPageDetectorCommandFlags.UsePixels
         _unit = Units.Pixels

         InitializeUI()
      End Sub
      Public Property BlankPageDetectorcommand() As BlankPageDetectorCommand
         Get
            'Update command values
            UpdateCommand()
            Return _BlankPageDetectorCommand
         End Get
         Set(ByVal value As BlankPageDetectorCommand)
            _BlankPageDetectorCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _Left = 1
         _Top = 1
         _Right = 1
         _Bottom = 1

         _tbLeft.Text = _Left.ToString()
         _tbTop.Text = _Top.ToString()
         _tbRight.Text = _Right.ToString()
         _tbBottom.Text = _Bottom.ToString()

         _chkDetectNoisyPage.Checked = ((_BlankPageDetectorCommand.Flags And BlankPageDetectorCommandFlags.DetectNoisyPage) = BlankPageDetectorCommandFlags.DetectNoisyPage)
         _chkIgnorBleedThrough.Checked = ((_BlankPageDetectorCommand.Flags And BlankPageDetectorCommandFlags.UseBleedThrough) = BlankPageDetectorCommandFlags.UseBleedThrough)
         _chkDetectLinedPage.Checked = ((_BlankPageDetectorCommand.Flags And BlankPageDetectorCommandFlags.DetectLinedPage) = BlankPageDetectorCommandFlags.DetectLinedPage)
         _chkUseActiveArea.Checked = ((_BlankPageDetectorCommand.Flags And BlankPageDetectorCommandFlags.UseActiveArea) = BlankPageDetectorCommandFlags.UseActiveArea)
         _chkUseDefaultMargin.Checked = Not ((_BlankPageDetectorCommand.Flags And BlankPageDetectorCommandFlags.UseUserMargins) = BlankPageDetectorCommandFlags.UseUserMargins)
         _rdUseCentimeters.Checked = ((_BlankPageDetectorCommand.Flags And BlankPageDetectorCommandFlags.UseCentimeters) = BlankPageDetectorCommandFlags.UseCentimeters)
         _rdUsePixels.Checked = ((_BlankPageDetectorCommand.Flags And BlankPageDetectorCommandFlags.UsePixels) = BlankPageDetectorCommandFlags.UsePixels)
         _rdUseInches.Checked = ((_BlankPageDetectorCommand.Flags And BlankPageDetectorCommandFlags.UseInches) = BlankPageDetectorCommandFlags.UseInches)
         _chkUseAdvanced.Checked = ((_BlankPageDetectorCommand.Flags And BlankPageDetectorCommandFlags.UseAdvanced) = BlankPageDetectorCommandFlags.UseAdvanced)
         _chkDetectTextOnly.Checked = ((_BlankPageDetectorCommand.Flags And BlankPageDetectorCommandFlags.DetectTextOnly) = BlankPageDetectorCommandFlags.DetectTextOnly)
         _chkDetectTextOnly.Enabled = _chkUseAdvanced.Checked

         If _rdUsePixels.Checked Then _unit = Units.Pixels
         If _rdUseInches.Checked Then _unit = Units.Inches
         If _rdUseCentimeters.Checked Then _unit = Units.Centimeters
      End Sub

      Private Sub UpdateCommand()
         _BlankPageDetectorCommand.Flags = CType(0, BlankPageDetectorCommandFlags)

         If (_chkUseAdvanced.Checked) Then
            _BlankPageDetectorCommand.Flags = _BlankPageDetectorCommand.Flags Or BlankPageDetectorCommandFlags.UseAdvanced
         End If

         If (_rdUseCentimeters.Checked) Then
            _BlankPageDetectorCommand.Flags = _BlankPageDetectorCommand.Flags Or BlankPageDetectorCommandFlags.UseCentimeters
         End If

         If (_rdUseInches.Checked) Then
            _BlankPageDetectorCommand.Flags = _BlankPageDetectorCommand.Flags Or BlankPageDetectorCommandFlags.UseInches
         End If
         If (_rdUsePixels.Checked) Then
            _BlankPageDetectorCommand.Flags = _BlankPageDetectorCommand.Flags Or BlankPageDetectorCommandFlags.UsePixels
         End If
         If (_chkDetectNoisyPage.Checked) Then
            _BlankPageDetectorCommand.Flags = _BlankPageDetectorCommand.Flags Or BlankPageDetectorCommandFlags.DetectNoisyPage
         End If
         If (_chkIgnorBleedThrough.Checked) Then
            _BlankPageDetectorCommand.Flags = _BlankPageDetectorCommand.Flags Or BlankPageDetectorCommandFlags.UseBleedThrough
         End If
         If (_chkDetectLinedPage.Checked) Then
            _BlankPageDetectorCommand.Flags = _BlankPageDetectorCommand.Flags Or BlankPageDetectorCommandFlags.DetectLinedPage
         End If

         If (_chkUseActiveArea.Checked) Then
            _BlankPageDetectorCommand.Flags = _BlankPageDetectorCommand.Flags Or BlankPageDetectorCommandFlags.UseActiveArea
         End If

         If (_chkDetectTextOnly.Checked And _chkUseAdvanced.Checked) Then
            _BlankPageDetectorCommand.Flags = _BlankPageDetectorCommand.Flags Or BlankPageDetectorCommandFlags.DetectTextOnly
         End If

         If (Not _chkUseDefaultMargin.Checked) Then
            _BlankPageDetectorCommand.Flags = _BlankPageDetectorCommand.Flags Or BlankPageDetectorCommandFlags.UseUserMargins

            _Left = Convert.ToInt32(_tbLeft.Text)
            _Top = Convert.ToInt32(_tbTop.Text)
            _Right = Convert.ToInt32(_tbRight.Text)
            _Bottom = Convert.ToInt32(_tbBottom.Text)

            _BlankPageDetectorCommand.LeftMargin = _Left
            _BlankPageDetectorCommand.TopMargin = _Top
            _BlankPageDetectorCommand.RightMargin = _Right
            _BlankPageDetectorCommand.BottomMargin = _Bottom
         End If
      End Sub

      Private Sub _tbLeft_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbLeft.TextChanged
         _tbLeft.Text = MainForm.IsValidNumber(_tbLeft.Text, 0, Integer.MaxValue)
      End Sub

      Private Sub _tbTop_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbTop.TextChanged
         _tbTop.Text = MainForm.IsValidNumber(_tbTop.Text, 0, Integer.MaxValue)
      End Sub

      Private Sub _tbRight_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbRight.TextChanged
         _tbRight.Text = MainForm.IsValidNumber(_tbRight.Text, 0, Integer.MaxValue)
      End Sub

      Private Sub _tbBottom_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbBottom.TextChanged
         _tbBottom.Text = MainForm.IsValidNumber(_tbBottom.Text, 0, Integer.MaxValue)
      End Sub

      Private Sub _btnok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnok.Click
         UpdateCommand()

         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         InitializeUI()
         Me.DialogResult = DialogResult.Cancel
      End Sub

      Private Sub _chkUseDefaultMargin_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles _chkUseDefaultMargin.CheckedChanged
         _gbUserMargins.Enabled = Not _chkUseDefaultMargin.Checked
      End Sub

      Private Sub _chkUseAdvanced_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles _chkUseAdvanced.CheckedChanged
         _chkDetectTextOnly.Enabled = _chkUseAdvanced.Checked
      End Sub

      Private Sub UnitCheckedChanged(sender As System.Object, e As System.EventArgs) Handles _rdUsePixels.CheckedChanged, _rdUseCentimeters.CheckedChanged, _rdUseInches.CheckedChanged
         If _rdUsePixels.Checked Then
            _unit = Units.Pixels
         ElseIf _rdUseInches.Checked Then
            _unit = Units.Inches
         Else
            _unit = Units.Centimeters
         End If

         If _unit = Units.Pixels Then
            _lblUnitLeft.Text = "Pixels"
            _lblUnitTop.Text = "Pixels"
            _lblUnitRight.Text = "Pixels"
            _lblUnitBottom.Text = "Pixels"

            _lblUnits.Text = ""
         Else
            Dim unitName As String = "Inch"
            If _unit = Units.Centimeters Then unitName = "cm"

            _lblUnitLeft.Text = String.Format("1/1000 {0}", unitName)
            _lblUnitTop.Text = String.Format("1/1000 {0}", unitName)
            _lblUnitRight.Text = String.Format("1/1000 {0}", unitName)
            _lblUnitBottom.Text = String.Format("1/1000 {0}", unitName)

            _lblUnits.Text = String.Format("Units of 1/1000 {0} means 1000 is an {0}", unitName.ToLower())
         End If
      End Sub
   End Class
End Namespace
