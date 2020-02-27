' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.Workstation.Commands
Imports Leadtools.Medical.Workstation
Imports Leadtools.Medical.Workstation.UI

Namespace Leadtools.Demos.Workstation.Customized
   Class AddRemoveToolbarFeatureItemCommand
      Inherits WorkstationCommand
      Public Sub New(ByVal featureId As String, ByVal container As WorkstationContainer, ByVal item__1 As ToolStripItem)
         MyBase.New(featureId, container)
         Item = item__1
      End Sub

      Protected Overrides Function DoCanExecute() As Boolean
         Return (TypeOf Item Is IToolStripItemItemProperties)
      End Function

      Protected Overrides Sub DoExecute()
         If Item.Owner Is Nothing Then
            Container.State.ActiveWorkstation.ViewerToolbar.Items.Insert(0, Item)

            Container.StripItemFeatureExecuter.SetItemFeature(Item, CType(Item, IToolStripItemItemProperties).ItemProperties.FeatureId)
         Else
            Container.State.ActiveWorkstation.ViewerToolbar.Items.Remove(Item)

            Container.StripItemFeatureExecuter.RemoveItemFeature(Item)
         End If
      End Sub

      Public Item As ToolStripItem
   End Class
End Namespace
