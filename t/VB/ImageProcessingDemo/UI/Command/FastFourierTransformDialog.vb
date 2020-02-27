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
   'will be used for the FastFourierTransformCommand

   Partial Public Class FastFourierTransformDialog : Inherits Form
      Private _FastFourierTransformCommand As FastFourierTransformCommand
      Private _FrequencyFilterCommand As FrequencyFilterCommand

      Public Sub New()
         InitializeComponent()
         _FastFourierTransformCommand = New FastFourierTransformCommand()
         _FrequencyFilterCommand = New FrequencyFilterCommand()

         'Set command default values
         InitializeUI()
      End Sub

      Public Property FastFourierTransformCommand() As FastFourierTransformCommand
         Get
            'Update command values
            UpdateCommand()
            Return _FastFourierTransformCommand
         End Get
         Set(ByVal value As FastFourierTransformCommand)
            _FastFourierTransformCommand = value
            InitializeUI()
         End Set
      End Property

      Public Property FrequencyFilterCommand() As FrequencyFilterCommand
         Get
            UpdateCommand()
            Return _FrequencyFilterCommand
         End Get
         Set(ByVal value As FrequencyFilterCommand)
            _FrequencyFilterCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _rbInsideX.Checked = True
         _rbInsideY.Checked = True
         _rbGray.Checked = True
         _rbBoth.Checked = True
         _rbScale.Checked = True

         If (_FrequencyFilterCommand.Flags And FrequencyFilterCommandFlags.InsideX) = FrequencyFilterCommandFlags.InsideX Then
            _rbInsideX.Checked = True
         End If

         If (_FrequencyFilterCommand.Flags And FrequencyFilterCommandFlags.OutsideX) = FrequencyFilterCommandFlags.OutsideX Then
            _rbOutsideX.Checked = True
         End If

         If (_FrequencyFilterCommand.Flags And FrequencyFilterCommandFlags.InsideY) = FrequencyFilterCommandFlags.InsideY Then
            _rbInsideY.Checked = True
         End If

         If (_FrequencyFilterCommand.Flags And FrequencyFilterCommandFlags.OutsideY) = FrequencyFilterCommandFlags.OutsideY Then
            _rbOutsideY.Checked = True
         End If

         If (_FastFourierTransformCommand.Flags And FastFourierTransformCommandFlags.Blue) = FastFourierTransformCommandFlags.Blue Then
            _rbBlue.Checked = True
         End If

         If (_FastFourierTransformCommand.Flags And FastFourierTransformCommandFlags.Green) = FastFourierTransformCommandFlags.Green Then
            _rbGreen.Checked = True
         End If

         If (_FastFourierTransformCommand.Flags And FastFourierTransformCommandFlags.Gray) = FastFourierTransformCommandFlags.Gray Then
            _rbGray.Checked = True
         End If

         If (_FastFourierTransformCommand.Flags And FastFourierTransformCommandFlags.Red) = FastFourierTransformCommandFlags.Red Then
            _rbRed.Checked = True
         End If


         If (_FastFourierTransformCommand.Flags And FastFourierTransformCommandFlags.Magnitude) = FastFourierTransformCommandFlags.Magnitude Then
            _rbMagnitude.Checked = True
         End If
         If (_FastFourierTransformCommand.Flags And FastFourierTransformCommandFlags.Phase) = FastFourierTransformCommandFlags.Phase Then
            _rbPhase.Checked = True
         End If
         If (_FastFourierTransformCommand.Flags And FastFourierTransformCommandFlags.Both) = FastFourierTransformCommandFlags.Both Then
            _rbBoth.Checked = True
         End If


         If (_FastFourierTransformCommand.Flags And FastFourierTransformCommandFlags.Clip) = FastFourierTransformCommandFlags.Clip Then
            _rbClip.Checked = True
         End If
         If (_FastFourierTransformCommand.Flags And FastFourierTransformCommandFlags.Scale) = FastFourierTransformCommandFlags.Scale Then
            _rbScale.Checked = True
         End If
      End Sub

      Private Sub UpdateCommand()
         _FastFourierTransformCommand.Flags = CType(0, FastFourierTransformCommandFlags)
         _FrequencyFilterCommand.Flags = CType(0, FrequencyFilterCommandFlags)

         If _rbInsideX.Checked Then
            _FrequencyFilterCommand.Flags = _FrequencyFilterCommand.Flags Or FrequencyFilterCommandFlags.InsideX
         End If
         If _rbOutsideX.Checked Then
            _FrequencyFilterCommand.Flags = _FrequencyFilterCommand.Flags Or FrequencyFilterCommandFlags.OutsideX
         End If
         If _rbInsideY.Checked Then
            _FrequencyFilterCommand.Flags = _FrequencyFilterCommand.Flags Or FrequencyFilterCommandFlags.InsideY
         End If
         If _rbOutsideY.Checked Then
            _FrequencyFilterCommand.Flags = _FrequencyFilterCommand.Flags Or FrequencyFilterCommandFlags.OutsideY
         End If
         If _rbNoneX.Checked Then
            _FrequencyFilterCommand.Flags = _FrequencyFilterCommand.Flags Or FrequencyFilterCommandFlags.None
         End If
         If _rbNoneY.Checked Then
            _FrequencyFilterCommand.Flags = _FrequencyFilterCommand.Flags Or FrequencyFilterCommandFlags.None
         End If

         If _rbBlue.Checked Then
            _FastFourierTransformCommand.Flags = _FastFourierTransformCommand.Flags Or FastFourierTransformCommandFlags.Blue
         End If

         If _rbGreen.Checked Then
            _FastFourierTransformCommand.Flags = _FastFourierTransformCommand.Flags Or FastFourierTransformCommandFlags.Green
         End If

         If _rbGray.Checked Then
            _FastFourierTransformCommand.Flags = _FastFourierTransformCommand.Flags Or FastFourierTransformCommandFlags.Gray
         End If

         If _rbRed.Checked Then
            _FastFourierTransformCommand.Flags = _FastFourierTransformCommand.Flags Or FastFourierTransformCommandFlags.Red
         End If

         If _rbMagnitude.Checked Then
            _FastFourierTransformCommand.Flags = _FastFourierTransformCommand.Flags Or FastFourierTransformCommandFlags.Magnitude
         End If

         If _rbPhase.Checked Then
            _FastFourierTransformCommand.Flags = _FastFourierTransformCommand.Flags Or FastFourierTransformCommandFlags.Phase
         End If

         If _rbBoth.Checked Then
            _FastFourierTransformCommand.Flags = _FastFourierTransformCommand.Flags Or FastFourierTransformCommandFlags.Both
         End If

         If _rbClip.Checked Then
            _FastFourierTransformCommand.Flags = _FastFourierTransformCommand.Flags Or FastFourierTransformCommandFlags.Clip
         End If

         If _rbScale.Checked Then
            _FastFourierTransformCommand.Flags = _FastFourierTransformCommand.Flags Or FastFourierTransformCommandFlags.Scale
         End If

         _FastFourierTransformCommand.Flags = _FastFourierTransformCommand.Flags Or FastFourierTransformCommandFlags.FastFourierTransform

      End Sub

      Private Sub _btnOk_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub
   End Class
End Namespace
