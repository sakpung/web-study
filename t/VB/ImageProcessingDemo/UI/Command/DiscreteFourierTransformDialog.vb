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
   'will be used for the DiscreteFourierTransformCommand

   Partial Public Class DiscreteFourierTransformDialog : Inherits Form
      Private _DiscreteFourierTransformCommand As DiscreteFourierTransformCommand
      Private _FourierTransformDisplayCommand As FourierTransformDisplayCommand
      Private _X, _Y, _Width, _Height As Integer

      Public Sub New(ByVal TempImage As RasterImage)
         InitializeComponent()
         _DiscreteFourierTransformCommand = New DiscreteFourierTransformCommand()
         _FourierTransformDisplayCommand = New FourierTransformDisplayCommand()
         _X = 0
         _Y = 0
         _Width = TempImage.Width
         _Height = TempImage.Height

         'Set command default values
         InitializeUI()
      End Sub

      Public Property DiscreteFourierTransformCommand() As DiscreteFourierTransformCommand
         Get
            'Update command values
            UpdateCommand()
            Return _DiscreteFourierTransformCommand
         End Get
         Set(ByVal value As DiscreteFourierTransformCommand)
            _DiscreteFourierTransformCommand = value
            InitializeUI()
         End Set
      End Property

      Public Property FourierTransformDisplayCommand() As FourierTransformDisplayCommand
         Get
            UpdateCommand()
            Return _FourierTransformDisplayCommand
         End Get
         Set(ByVal value As FourierTransformDisplayCommand)
            _FourierTransformDisplayCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _numX.Maximum = _Width
         _numX.Value = _X
         _numY.Maximum = _Height
         _numY.Value = _Y
         _numWidth.Maximum = _Width - 1
         _numWidth.Value = _Width - 1
         _numHeight.Maximum = _Height - 1
         _numHeight.Value = _Height - 1

         _rbDiscreteFourierTransform.Checked = True
         _rbClip.Checked = True
         _rbRed.Checked = True
         _rbAll.Checked = True
         _rbMagnitude.Checked = True
         _rbInsideX.Checked = True
         _rbInsideY.Checked = True
         _rbDMagnitude.Checked = True
         _rbNormal.Checked = True
      End Sub
      Private Sub UpdateCommand()
         _DiscreteFourierTransformCommand.Flags = CType(0, DiscreteFourierTransformCommandFlags)
         _FourierTransformDisplayCommand.Flags = CType(0, FourierTransformDisplayCommandFlags)

         If _rbDiscreteFourierTransform.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.DiscreteFourierTransform
         End If
         If _rbInverseDiscreteFourierTransform.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.InverseDiscreteFourierTransform
         End If
         If _rbClip.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.Clip
         End If
         If _rbScale.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.Scale
         End If
         If _rbRed.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.Red
         End If
         If _rbGreen.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.Green
         End If
         If _rbBlue.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.Blue
         End If
         If _rbGray.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.Gray
         End If
         If _rbAll.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.All
         End If
         If _rbRange.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.Range
         End If
         If _rbMagnitude.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.Magnitude
         End If
         If _rbPhase.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.Phase
         End If
         If _rbBoth.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.Both
         End If
         If _rbInsideX.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.InsideX
         End If
         If _rbOutsideX.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.OutsideX
         End If
         If _rbInsideY.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.InsideY
         End If
         If _rbOutsideY.Checked Then
            _DiscreteFourierTransformCommand.Flags = _DiscreteFourierTransformCommand.Flags Or DiscreteFourierTransformCommandFlags.OutsideY
         End If

         _X = Convert.ToInt32(_numX.Value)
         _Y = Convert.ToInt32(_numY.Value)
         _Width = Convert.ToInt32(_numWidth.Value)
         _Height = Convert.ToInt32(_numHeight.Value)

         _DiscreteFourierTransformCommand.Range = New LeadRect(_X, _Y, _Width, _Height)

         If _rbDMagnitude.Checked Then
            _FourierTransformDisplayCommand.Flags = _FourierTransformDisplayCommand.Flags Or FourierTransformDisplayCommandFlags.Magnitude
         End If
         If _rbDPhase.Checked Then
            _FourierTransformDisplayCommand.Flags = _FourierTransformDisplayCommand.Flags Or FourierTransformDisplayCommandFlags.Phase
         End If
         If _rbNormal.Checked Then
            _FourierTransformDisplayCommand.Flags = _FourierTransformDisplayCommand.Flags Or FourierTransformDisplayCommandFlags.Normal
         End If
         If _rbLogarithm.Checked Then
            _FourierTransformDisplayCommand.Flags = _FourierTransformDisplayCommand.Flags Or FourierTransformDisplayCommandFlags.Log
         End If
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub

      Private Sub _numX_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numX.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numY_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numY.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numWidth_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numWidth.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numHeight_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numHeight.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub
   End Class
End Namespace
