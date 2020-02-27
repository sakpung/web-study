' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.Workstation.Commands
Imports Leadtools.Medical.Workstation

Namespace Leadtools.Demos.Workstation.Customized
   Class ToggleToolBarCommand : Inherits WorkstationCommand
      Public Sub New(ByVal featureId As String, ByVal container As WorkstationContainer, ByVal toolbar3D As Custom3DToolbar)
         MyBase.New(featureId, container)
         CustomToolStrip = toolbar3D
      End Sub

      Protected Overrides Sub DoExecute()
         If CustomToolStrip.Parent Is Nothing Then
            Container.State.ActiveWorkstation.Controls.Add(CustomToolStrip)

            CustomToolStrip.RegisterFeatures(Container.StripItemFeatureExecuter)
         Else
            CustomToolStrip.Parent.Controls.Remove(CustomToolStrip)

            CustomToolStrip.UnregisterFeatures()
         End If
      End Sub

      Protected Overrides Function DoCanExecute() As Boolean
         Return Not Nothing Is CustomToolStrip
      End Function

      Public CustomToolStrip As Custom3DToolbar
   End Class
End Namespace
