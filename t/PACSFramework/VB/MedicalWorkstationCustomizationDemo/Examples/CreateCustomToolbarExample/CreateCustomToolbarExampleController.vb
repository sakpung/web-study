' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Medical.Workstation

Namespace Leadtools.Demos.Workstation.Customized
   Class CreateCustomToolbarExampleController : Inherits ExamplesControllerBase
      Protected Overrides Sub RegisterExampleMenu(ByVal exampleItem As DesignToolStripMenuItem)
         Dim toggleToolbarItem As DesignToolStripMenuItem


         toggleToolbarItem = New DesignToolStripMenuItem(CustomMenuItemFeatureProperties.ToggelToolbarItemProperty)

         exampleItem.DropDownItems.Add(toggleToolbarItem)
      End Sub

      Protected Overrides Sub RegisterExampleCommands(ByVal viewerContainer As WorkstationContainer)
         Dim toolStrip3D As Custom3DToolbar
         Dim toggleToolBar As ToggleToolBarCommand


         toolStrip3D = New Custom3DToolbar()
         toggleToolBar = New ToggleToolBarCommand(CustomWorkstationFeatures.ToggleToolBarFeatureId, viewerContainer, toolStrip3D)

         toolStrip3D.Renderer = viewerContainer.State.ActiveWorkstation.ToolBarRenderer

         toolStrip3D.SyncronizeToolbar(viewerContainer.State)

         viewerContainer.FeaturesFactory.RegisterCommand(CustomWorkstationFeatures.ToggleToolBarFeatureId, toggleToolBar)
      End Sub

      Protected Overrides ReadOnly Property ExampleName() As String
         Get
            Return "Create Custom Toolbar"
         End Get
      End Property

      Protected Overrides ReadOnly Property ExampleDescription() As String
         Get
            Return "This example shows you how to create your own Toolbar and include the same features the Workstation Toolbar implement. The example will create a Toolstip control and add some 3D buttons to it then assign the same tool strip item properties (Text, Images, Features) used by the Workstation toolbar. The toolbar will be registered with the workstation components to execute the features behind each button. Also the toolbar will change its buttons state (Enable/Visible) automatically based on the current Workstation behavior."
         End Get
      End Property
   End Class
End Namespace
