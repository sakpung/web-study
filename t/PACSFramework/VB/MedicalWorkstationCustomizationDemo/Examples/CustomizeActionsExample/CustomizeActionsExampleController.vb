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
Imports Leadtools.Medical.Workstation.UI.Factory
Imports Leadtools.Medical.Workstation.Interfaces.Views
Imports Leadtools.Medical.Workstation.Commands

Namespace Leadtools.Demos.Workstation.Customized
   Class CustomizeActionsExampleController : Inherits ExamplesControllerBase

      Protected Overrides Sub RegisterExampleCommands(ByVal viewerContainer As WorkstationContainer)
         WorkstationUIFactory.Instance.RegisterWorkstationView(Of IActionsEditorView)(GetType(ActionsEditorDialog))

         Dim cmd As ModelViewPresenterCommand(Of ActionsEditorViewPresenter, IActionsEditorView)

         cmd = New ModelViewPresenterCommand(Of ActionsEditorViewPresenter, IActionsEditorView)(CustomWorkstationFeatures.ShowCustomizeActionsViewFeatureId, viewerContainer)

         viewerContainer.FeaturesFactory.RegisterCommand(cmd)
      End Sub

      Protected Overrides Sub RegisterExampleMenu(ByVal exampleItem As DesignToolStripMenuItem)
         Dim showCustomizeActions As DesignToolStripMenuItem


         showCustomizeActions = New DesignToolStripMenuItem(CustomMenuItemFeatureProperties.ShowCustomizeActionViewProperty)

         exampleItem.DropDownItems.Add(showCustomizeActions)
      End Sub

      Protected Overrides ReadOnly Property ExampleName() As String
         Get
            Return "Customize Viewer Actions"
         End Get
      End Property

      Protected Overrides ReadOnly Property ExampleDescription() As String
         Get
            Return "This example will show you how to customize the Workstation Toolbar/Context Menu by adding new Medical Viewer Actions into it. You can easily add new features/buttons into Workstation toolbar/context menu and it will be executed when you click on it. The buttons will also maintain their state as Enabled/Disabled automatically based on whether the feature can be executed or not. For example, you can add a new Free Hand Annotation and it will be added under the Annotation button in the toolbar and the Context menu, or you can add a new Alpha action and it will be added as a top level button in the toolbar. The example also implements the built-in Model/View/Presenter pattern which is used by the Workstation Framework to register and display controls. This is used to display the Features Events Dialog "
         End Get
      End Property
   End Class
End Namespace
