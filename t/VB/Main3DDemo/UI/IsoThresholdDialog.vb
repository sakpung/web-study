' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools.Medical3D
Imports Leadtools.MedicalViewer

Namespace Main3DDemo
   Partial Public Class IsoThresholdDialog : Inherits Form
      Private _viewer As MedicalViewer
      Private _container As Medical3DContainer
      Private _oldThresholdValue As Integer
      Private _control3D As Medical3DControl
      Private minimum As Integer
      Private maximum As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub New(ByVal control3D As Medical3DControl, ByVal control As MedicalViewer, ByVal container As Medical3DContainer)
         InitializeComponent()

         _viewer = control
         _control3D = control3D

         _container = container
         _oldThresholdValue = container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).SSD.Threshold

         minimum = container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).MinimumValue
         maximum = container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).MaximumValue

         _textBoxThreshold.MinimumAllowed = minimum
         _textBoxThreshold.MaximumAllowed = maximum

         _trackThreshold.Maximum = maximum - minimum

         _trackThreshold.Value = Math.Min(maximum - minimum, Math.Max(minimum, _oldThresholdValue))
         _control3D.Invalidate()
         _control3D.Update()
      End Sub

      Private Sub _btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnReset.Click
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).SSD.Threshold = _oldThresholdValue
         _trackThreshold.Value = Math.Min(maximum - minimum, Math.Max(minimum, _oldThresholdValue))
         _control3D.Invalidate()
         _control3D.Update()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).SSD.Threshold = _oldThresholdValue
         _control3D.Invalidate()
         _control3D.Update()
      End Sub

      Private Sub _trackBarOpacity_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _trackThreshold.ValueChanged
         If _trackThreshold.Value <> (_textBoxThreshold.Value - minimum) Then
            _textBoxThreshold.Value = (_trackThreshold.Value + minimum)
         End If
         _control3D.Invalidate()
         _control3D.Update()
      End Sub

      Private Sub _textBoxOpacity_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _textBoxThreshold.TextChanged
         If _textBoxThreshold.Value > minimum Then
            If _trackThreshold.Value <> (_textBoxThreshold.Value - minimum) Then
               _trackThreshold.Value = _textBoxThreshold.Value - minimum
            End If
            _control3D.Invalidate()
            _control3D.Update()
         End If
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         If _container.Objects(0).SSD.Threshold <> _textBoxThreshold.Value Then
            _container.Objects(0).SSD.Threshold = _textBoxThreshold.Value
         End If
         _control3D.Invalidate()
         _control3D.Update()
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _btnOK_Click(sender, e)
      End Sub

      Private Sub groupBox1_Enter(ByVal sender As Object, ByVal e As EventArgs)

      End Sub
   End Class
End Namespace
