' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Medical3D
Imports Leadtools.MedicalViewer
Imports Main3DDemo.Leadtools.Demos

Namespace Main3DDemo
   Partial Public Class ThresholdDialog : Inherits Form
      Private oldFromValue As Single
      Private oldToValue As Single
      Private oldEnabled As Boolean

      Private removeIntervalType As Medical3DRemoveIntervalType
      Private _container As Medical3DContainer
      Private type As Medical3DVolumeType
      Private minimum As Integer
      Private maximum As Integer
      Private dontApply As Boolean
      Private _control3D As Medical3DControl

      Private Sub EnableControls(ByVal enable As Boolean)
         _trackBarLower.Enabled = enable
         _trackBarUpper.Enabled = enable
         _textBoxLower.Enabled = enable
         _textBoxUpper.Enabled = enable
         _removeInnerRangeChkBox.Enabled = enable
      End Sub

      Public Sub New(ByVal control3D As Medical3DControl, ByVal Medical3DContainer As Medical3DContainer, ByVal Medical3DVolumeType As Medical3DVolumeType)
         InitializeComponent()

         _container = Medical3DContainer
         type = Medical3DVolumeType

         _control3D = control3D

         oldFromValue = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).LowerThreshold
         oldToValue = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).UpperThreshold
         removeIntervalType = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).RemoveInterval
         oldEnabled = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).EnableThresholding
         _chkBoxenableThreshold.Checked = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).EnableThresholding
         _removeInnerRangeChkBox.Checked = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).RemoveInterval = Medical3DRemoveIntervalType.InnerRange

         minimum = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).MinimumValue
         maximum = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).MaximumValue

         dontApply = True
         _trackBarLower.Maximum = maximum
         _textBoxLower.MinimumAllowed = 0
         _textBoxLower.MaximumAllowed = maximum
         _textBoxLower.Value = CInt(oldFromValue)

         _trackBarUpper.Maximum = maximum
         _textBoxUpper.MinimumAllowed = 0
         _textBoxUpper.MaximumAllowed = maximum
         dontApply = False
         _textBoxUpper.Value = CInt(oldToValue)

         EnableControls(_chkBoxenableThreshold.Checked)
         _control3D.Invalidate()
      End Sub

      Private Sub _btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnReset.Click
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).LowerThreshold = minimum
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).UpperThreshold = maximum
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).EnableThresholding = False
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).RemoveInterval = Medical3DRemoveIntervalType.OuterRange

         _textBoxLower.Value = CInt(minimum)
         _textBoxUpper.Value = CInt(maximum)
         _removeInnerRangeChkBox.Checked = False
         _chkBoxenableThreshold.Checked = False
         EnableControls(False)
         _control3D.Invalidate()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).LowerThreshold = oldFromValue
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).UpperThreshold = oldToValue
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).EnableThresholding = oldEnabled
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).RemoveInterval = removeIntervalType
         _control3D.Invalidate()
      End Sub

      Private Sub SetLowerThreshold(ByVal value As Integer)
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).LowerThreshold = value
         _control3D.Invalidate()
      End Sub

      Private Sub SetUpperThreshold(ByVal value As Integer)
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).UpperThreshold = value
         _control3D.Invalidate()
      End Sub


      Private Sub SetThreshold()
         If dontApply Then
            Return
         End If


         If _textBoxLower.Value > _textBoxUpper.Value Then
            SetLowerThreshold(_trackBarUpper.Value)
            SetUpperThreshold(_trackBarLower.Value)
            _toLbl.Text = DemosGlobalization.GetResxString(Me.GetType(), "Resx_From")
            _fromLbl.Text = DemosGlobalization.GetResxString(Me.GetType(), "Resx_To")

         Else
            SetLowerThreshold(_trackBarLower.Value)
            SetUpperThreshold(_trackBarUpper.Value)
            _toLbl.Text = DemosGlobalization.GetResxString(Me.GetType(), "Resx_To")

            _fromLbl.Text = DemosGlobalization.GetResxString(Me.GetType(), "Resx_From")

         End If

      End Sub

      Private Sub _trackBarLower_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _trackBarLower.ValueChanged
         If (_textBoxLower.Value) <> _trackBarLower.Value Then
            _textBoxLower.Value = _trackBarLower.Value
         End If

         SetThreshold()
         _control3D.Invalidate()
      End Sub

      Private Sub _trackBarUpper_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _trackBarUpper.ValueChanged
         If (_textBoxUpper.Value) <> _trackBarUpper.Value Then
            _textBoxUpper.Value = _trackBarUpper.Value
         End If

         SetThreshold()
         _control3D.Invalidate()
      End Sub

      Private Sub _textBoxLower_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _textBoxLower.TextChanged
         _trackBarLower.Value = _textBoxLower.Value
         _control3D.Invalidate()
      End Sub

      Private Sub _textBoxUpper_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _textBoxUpper.TextChanged
         _trackBarUpper.Value = _textBoxUpper.Value
         _control3D.Invalidate()
      End Sub

      Private Sub _chkBoxenableThreshold_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkBoxenableThreshold.CheckedChanged
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).EnableThresholding = _chkBoxenableThreshold.Checked
         EnableControls(_chkBoxenableThreshold.Checked)
         _control3D.Invalidate()
      End Sub

      Private Sub _removeInnerRangeChkBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _removeInnerRangeChkBox.CheckedChanged
         Dim intervalType As Medical3DRemoveIntervalType
         If _removeInnerRangeChkBox.Checked Then
            intervalType = Medical3DRemoveIntervalType.InnerRange
         Else
            intervalType = Medical3DRemoveIntervalType.OuterRange
         End If
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).RemoveInterval = intervalType
         _control3D.Invalidate()
      End Sub
   End Class
End Namespace
