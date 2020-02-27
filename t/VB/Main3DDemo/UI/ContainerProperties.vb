' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools.Medical3D
Imports Leadtools.MedicalViewer
Imports Main3DDemo.Leadtools.Demos

Namespace Main3DDemo
   Partial Public Class ContainerProperties : Inherits Form
      Private _container As Medical3DContainer
      Private _control3D As Medical3DControl
      Private _mprCell As MedicalViewerMPRCell
      Private _cell As MedicalViewerMultiCell
      Private _viewer As MedicalViewer

      Private Sub FillDialogWithDefaultValues()
         _comboBoxProjectionMethod.SelectedIndex = 0

         _lblBoundaryBoxColor.BoxColor = Color.Red
         _lblBackgroundColor.BoxColor = Color.Black
         _lblFrameBoundaryColor.BoxColor = Color.Blue
         _lblIntersectionLineColor.BoxColor = Color.White
         _txtCameraNear.Value = 1
         _txtCameraFar.Value = 6

         _chkBoundaryBox.Checked = True
         _chkIntersectionLine.Checked = False
         _chkFrameBoundary.Checked = True
         _chkRemoveBackground.Checked = False

         
         _btnBoundaryBoxColor.Enabled = _lblBoundaryBoxColor.Enabled = True

         
         _lblFrameBoundaryColor.Enabled = _btnFrameBoundaryColor.Enabled = True

         
         _lblIntersectionLineColor.Enabled = _btnIntersectionLineColor.Enabled = False
      End Sub


      Private Sub FillDialogWithOldValues()
         _lblFrameBoundaryColor.BoxColor = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).MPR.FrameBoundariesColor
         _lblIntersectionLineColor.BoxColor = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).MPR.IntersectionLineColor


         _chkIntersectionLine.Checked = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).MPR.EnableIntersectionLines
         _chkFrameBoundary.Checked = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).MPR.EnableFrameBoundaries
         _chkRemoveBackground.Checked = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).MPR.RemoveBackground
         
         _btnBoundaryBoxColor.Enabled = _lblBoundaryBoxColor.Enabled = _chkBoundaryBox.Checked

         
         _lblFrameBoundaryColor.Enabled = _btnFrameBoundaryColor.Enabled = _chkFrameBoundary.Checked

         
         _lblIntersectionLineColor.Enabled = _btnIntersectionLineColor.Enabled = _chkIntersectionLine.Checked


         If (_container.Camera.ProjectionMethod = Medical3DProjectionMethod.Perspective) Then
            _comboBoxProjectionMethod.SelectedIndex = 0
         Else
            _comboBoxProjectionMethod.SelectedIndex = 1
         End If
         _lblBoundaryBoxColor.BoxColor = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).BoundaryBoxColor
         _lblBackgroundColor.BoxColor = _container.BackgroundColor
         _txtCameraNear.Value = CInt(_container.Camera.Near)
         _txtCameraFar.Value = CInt(_container.Camera.Far)
         _chkBoundaryBox.Checked = _container.Objects(_control3D.ObjectsContainer.CurrentObjectIndex).EnableBoundaryBox

         If _container.VolumeType = Medical3DVolumeType.SSD Then
            _lblFrameBoundaryColor.Enabled = False
            _lblIntersectionLineColor.Enabled = False

            _chkIntersectionLine.Enabled = False
            _chkFrameBoundary.Enabled = False
            _chkRemoveBackground.Enabled = False

            
            _lblFrameBoundaryColor.Enabled = _btnFrameBoundaryColor.Enabled = False

           
            _lblIntersectionLineColor.Enabled = _btnIntersectionLineColor.Enabled = False

         End If
      End Sub

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Function FindFirstMPRCell(ByVal viewer As MedicalViewer) As MedicalViewerMPRCell
         For Each control As Control In viewer.Cells
            If TypeOf control Is MedicalViewerMPRCell Then
               Return CType(control, MedicalViewerMPRCell)
            End If
         Next control

         Return Nothing
      End Function

      Private Function FindFirstMultiCell(ByVal viewer As MedicalViewer) As MedicalViewerMultiCell
         For Each control As Control In viewer.Cells
            If TypeOf control Is MedicalViewerMultiCell Then
               Return CType(control, MedicalViewerMultiCell)
            End If
         Next control

         Return Nothing
      End Function

      Public Sub New(ByVal control3D As Medical3DControl, ByVal viewer As MedicalViewer, ByVal container As Medical3DContainer)
         _container = container
         _control3D = control3D
         _viewer = viewer

         _mprCell = FindFirstMPRCell(viewer)
         _cell = FindFirstMultiCell(viewer)


         InitializeComponent()
         FillDialogWithOldValues()
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Dim index As Integer

         index = 0
         Do While index < _control3D.ObjectsContainer.Objects.Count
            _container.Objects(index).EnableBoundaryBox = _chkBoundaryBox.Checked
            _container.BackgroundColor = _lblBackgroundColor.BoxColor
            If _comboBoxProjectionMethod.SelectedIndex = 0 Then
               _container.Camera.ProjectionMethod = Medical3DProjectionMethod.Perspective
            Else
               _container.Camera.ProjectionMethod = Medical3DProjectionMethod.Orthogonal
            End If
            _container.Objects(index).BoundaryBoxColor = _lblBoundaryBoxColor.BoxColor

            If _txtCameraNear.Value > _txtCameraFar.Value Then
               MessageBox.Show(DemosGlobalization.GetResxString(Me.GetType(), "Resx_NearValue"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_FarValues"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return
            Else
               If _txtCameraNear.Value > _container.Camera.Far Then
                  _container.Camera.Far = Math.Max(1, _txtCameraFar.Value)
                  _container.Camera.Near = Math.Max(1, _txtCameraNear.Value)
               Else
                  _container.Camera.Near = Math.Max(1, _txtCameraNear.Value)
                  _container.Camera.Far = Math.Max(1, _txtCameraFar.Value)
               End If
            End If

            If _container.VolumeType <> Medical3DVolumeType.SSD Then
               _container.Objects(index).MPR.EnableFrameBoundaries = _chkFrameBoundary.Checked
               _container.Objects(index).MPR.EnableIntersectionLines = _chkIntersectionLine.Checked
               _container.Objects(index).MPR.FrameBoundariesColor = _lblFrameBoundaryColor.BoxColor
               _container.Objects(index).MPR.IntersectionLineColor = _lblIntersectionLineColor.BoxColor
               _container.Objects(index).MPR.RemoveBackground = _chkRemoveBackground.Checked
            End If
            index += 1
         Loop

         _control3D.Invalidate()
         _control3D.Update()
      End Sub

      Private Sub _btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnReset.Click
         FillDialogWithDefaultValues()
      End Sub

      Private Sub _btnBoundaryBoxColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBoundaryBoxColor.Click
         ShowColorDialog(_lblBoundaryBoxColor)
      End Sub

      Private Sub _btnBackgroundColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBackgroundColor.Click
         ShowColorDialog(_lblBackgroundColor)
      End Sub

      Private Sub _btnFrameBoundaryColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnFrameBoundaryColor.Click
         ShowColorDialog(_lblFrameBoundaryColor)
      End Sub

      Private Sub _btnIntersectionLineColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnIntersectionLineColor.Click
         ShowColorDialog(_lblIntersectionLineColor)
      End Sub

      Private Sub _chkBoundaryBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkBoundaryBox.CheckedChanged
         _lblBoundaryBoxColor.Enabled = _chkBoundaryBox.Checked
         _btnBoundaryBoxColor.Enabled = _chkBoundaryBox.Checked
      End Sub

      Private Sub _chkFrameBoundary_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkFrameBoundary.CheckedChanged
         _lblFrameBoundaryColor.Enabled = _chkFrameBoundary.Checked
         _btnFrameBoundaryColor.Enabled = _chkFrameBoundary.Checked
      End Sub

      Private Sub _chkIntersectionLine_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkIntersectionLine.CheckedChanged
         _lblIntersectionLineColor.Enabled = _chkIntersectionLine.Checked
         _btnIntersectionLineColor.Enabled = _chkIntersectionLine.Checked

      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _btnOK_Click(sender, e)
      End Sub

      Public Shared Sub ShowColorDialog(ByVal label As Label)
         Dim colorDlg As ColorDialog = New ColorDialog()

         colorDlg.Color = label.BackColor
         If colorDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            label.BackColor = colorDlg.Color
         End If
      End Sub



   End Class
End Namespace






