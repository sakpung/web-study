' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Medical.Workstation.Interfaces
Imports Leadtools.Medical.Workstation
Imports Leadtools.Medical3D

Namespace Leadtools.Demos.Workstation.Customized
   Class Custom3DToolbar : Inherits ToolStrip
      Public Sub New()
         MyBase.New()
         Items.Add(New DesignToolStripButton(ToolStripMenuProperties.Instance.Create3DVolumeToolStripButton))
         Items.Add(New DesignToolStripButton(ToolStripMenuProperties.Instance.SingleCutPlaneToolStripMenuItem))
         Items.Add(New DesignToolStripButton(ToolStripMenuProperties.Instance.DoubleCutPlaneToolStripMenuItem))
         Items.Add(New DesignToolStripButton(ToolStripMenuProperties.Instance.Rotate3DToolStripButton))

         Object3DTypeToolStripSplitButton = New CustomToolStripSplitButton(ToolStripMenuProperties.Instance.Object3DTypeToolStripSplitButton)
         MPRToolStripMenuItem = New CustomToolStripMenuItem(ToolStripMenuProperties.Instance.MPRToolStripMenuItem)
         MIPToolStripMenuItem = New CustomToolStripMenuItem(ToolStripMenuProperties.Instance.MIPToolStripMenuItem)
         MinMIPToolStripMenuItem = New CustomToolStripMenuItem(ToolStripMenuProperties.Instance.MinMIPToolStripMenuItem)
         SSDToolStripMenuItem = New CustomToolStripMenuItem(ToolStripMenuProperties.Instance.SSDToolStripMenuItem)
         VRTToolStripMenuItem = New CustomToolStripMenuItem(ToolStripMenuProperties.Instance.VRTToolStripMenuItem)

         Object3DTypeToolStripSplitButton.DropDownItems.AddRange(New ToolStripItem() {MPRToolStripMenuItem, MIPToolStripMenuItem, MinMIPToolStripMenuItem, SSDToolStripMenuItem, VRTToolStripMenuItem})

         Items.Add(Object3DTypeToolStripSplitButton)
      End Sub

      Public Sub SyncronizeToolbar(ByVal state As WorkstationState)
         __State = state

         SetCurrentVolumeType(state)

         AddHandler __State.SelectedVolumeTypeChanged, AddressOf __State_SelectedVolumeTypeChanged
         AddHandler __State.ActiveCellChanged, AddressOf __State_ActiveCellChanged
      End Sub

      Public Sub RegisterFeatures(ByVal toolStripExecuter As IWorkstationStripItemFeatureExecuter)
         If Nothing Is toolStripExecuter Then
            Throw New ArgumentNullException()
         End If

         If Not ToolStripController Is Nothing Then
            UnregisterFeatures()
         End If

         ToolStripController = toolStripExecuter

         ToolStripController.RegisterToolStripMenuItemFeatures(Me)

         ToolStripController.UpdateMenuItemsState()
         ToolStripController.UpdateTopLevelItemsState(Me)
      End Sub

      Public Sub UnregisterFeatures()
         If Nothing Is ToolStripController Then
            Return
         End If

         ToolStripController.UnregisterToolStripMenuItemFeatures(Me)
      End Sub

      Public ToolStripController As IWorkstationStripItemFeatureExecuter
      Private Sub __State_SelectedVolumeTypeChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try
            SetCurrentVolumeType(__State)
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub __State_ActiveCellChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If ToolStripController IsNot Nothing Then
               ToolStripController.UpdateTopLevelItemsState(Me)
            End If
         Catch ex As Exception
            System.Diagnostics.Debug.Assert(False, ex.Message)
         End Try
      End Sub


      Private Sub SetCurrentVolumeType(ByVal state As WorkstationState)
         Select Case state.SelectedVolumeType
            Case Medical3D.Medical3DVolumeType.MINIP
               If True Then
                  Object3DTypeToolStripSplitButton.SetCurrentItem(MinMIPToolStripMenuItem)
               End If
               Exit Select

            Case Medical3D.Medical3DVolumeType.MIP
               If True Then
                  Object3DTypeToolStripSplitButton.SetCurrentItem(MIPToolStripMenuItem)
               End If
               Exit Select

            Case Medical3D.Medical3DVolumeType.MPR
               If True Then
                  Object3DTypeToolStripSplitButton.SetCurrentItem(MPRToolStripMenuItem)
               End If
               Exit Select

            Case Medical3D.Medical3DVolumeType.SSD
               If True Then
                  Object3DTypeToolStripSplitButton.SetCurrentItem(SSDToolStripMenuItem)
               End If
               Exit Select

            Case Medical3D.Medical3DVolumeType.VRT
               If True Then
                  Object3DTypeToolStripSplitButton.SetCurrentItem(VRTToolStripMenuItem)
               End If
               Exit Select
         End Select
      End Sub


      Private __State As WorkstationState

      Private Object3DTypeToolStripSplitButton As CustomToolStripSplitButton
      Private MPRToolStripMenuItem As CustomToolStripMenuItem
      Private MIPToolStripMenuItem As CustomToolStripMenuItem
      Private MinMIPToolStripMenuItem As CustomToolStripMenuItem
      Private SSDToolStripMenuItem As CustomToolStripMenuItem
      Private VRTToolStripMenuItem As CustomToolStripMenuItem
   End Class
End Namespace
