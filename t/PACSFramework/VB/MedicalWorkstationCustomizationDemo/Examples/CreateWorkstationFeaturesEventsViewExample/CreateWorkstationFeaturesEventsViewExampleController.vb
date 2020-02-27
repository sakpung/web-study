' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Workstation
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Medical.Workstation.Commands
Imports Leadtools.Medical.Workstation.UI.Factory

Namespace Leadtools.Demos.Workstation.Customized
   Class CreateWorkstationFeaturesEventsViewExampleController : Inherits ExamplesControllerBase
      Protected Overrides Sub RegisterExampleCommands(ByVal viewerContainer As WorkstationContainer)
         Dim cmd As ModelViewPresenterCommand(Of WorkstastionFeaturesEventsPresenter, IWorkstastionFeaturesEventsView)


         WorkstationUIFactory.Instance.RegisterWorkstationView(Of IWorkstastionFeaturesEventsView)(GetType(WorkstastionFeaturesEventsView))

         cmd = New ModelViewPresenterCommand(Of WorkstastionFeaturesEventsPresenter, IWorkstastionFeaturesEventsView)(CustomWorkstationFeatures.FeaturesEventsViewFeatureId, viewerContainer)

         viewerContainer.FeaturesFactory.RegisterCommand(cmd)
      End Sub

      Protected Overrides Sub RegisterExampleMenu(ByVal exampleItem As DesignToolStripMenuItem)
         Dim toggleToolbarItem As DesignToolStripMenuItem


         toggleToolbarItem = New DesignToolStripMenuItem(CustomMenuItemFeatureProperties.CreateFeaturesEventsViewItemProperty)

         exampleItem.DropDownItems.Add(toggleToolbarItem)
      End Sub

      Protected Overrides ReadOnly Property ExampleName() As String
         Get
            Return "Features Events View"
         End Get
      End Property

      Protected Overrides ReadOnly Property ExampleDescription() As String
         Get
            Return "This example shows you how to use the Workstation Event Broker component to listen to various events in the Workstation. All features executed by the Workstation Framework fires events that can be traced by interested components. You can also use this as a learning tool to understand the different features implemented by the Workstation Framework and the components that executes them. The example also implements the built-in Model/View/Presenter pattern which is used by the Workstation Framework to register and display controls. This is used to display the Features Events Dialog While the dialog is displayed, load DICOM series and apply some actions on the images or execute some toolbar/menu commands to see the dialog populated with the events."
         End Get
      End Property
   End Class
End Namespace
