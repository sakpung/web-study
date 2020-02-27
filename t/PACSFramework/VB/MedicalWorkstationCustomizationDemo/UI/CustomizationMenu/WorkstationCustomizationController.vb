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
Imports Leadtools.Medical.Workstation.UI.Factory
Imports Leadtools.Medical.Workstation.Commands
Imports Leadtools.Medical.Workstation
Imports System.IO
Imports System.Reflection
Imports System.Drawing
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Leadtools.Medical.Workstation.Interfaces.Views
Imports Leadtools.Medical.Workstation.Presenters
Imports Leadtools.Medical.Workstation.Loader
Imports Leadtools.Medical.Workstation.Client.Local
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools.Dicom
Imports Leadtools.Demos.Workstation.Customized


Namespace Leadtools.Demos.Workstation.Customized
   Class WorkstationCustomizationController
      Public Sub New()
         Dim workstation As WorkstationViewer
         Dim examplesMenu As ExamplesMenuStrip


         workstation = WorkstationUIFactory.Instance.GetWorkstsationControl(Of WorkstationViewer)(UIElementKeys.WorkstastionControl)
         examplesMenu = WorkstationUIFactory.Instance.GetWorkstsationControl(Of ExamplesMenuStrip)(UIElementKeys.ExamplesMenuStrip)

         If Nothing Is workstation Then
            Throw New InvalidOperationException("Workstation Viewer is not registered.")
         End If

         If Nothing Is examplesMenu Then
            Throw New InvalidOperationException("Examples menu is not registered.")
         End If


         Dim command As WorkstationCommand = TryCast(workstation.ViewerContainer.FeaturesFactory.GetFeatureCommand(WorkstationFeatures.ShowSeriesBrowserFeatureId), WorkstationCommand)

         If Not Nothing Is command Then
            command.Supported = False
         End If

         Dim loadSeriesExample As LoadSeriesExampleController = New LoadSeriesExampleController()
         loadSeriesExample.Run()

         Dim localizationExample As LocalizationExampleController = New LocalizationExampleController()
         localizationExample.Run()

         Dim createCustomToolbarExample As CreateCustomToolbarExampleController = New CreateCustomToolbarExampleController()
         createCustomToolbarExample.Run()

         Dim createWorkstationFeaturesEventsViewExample As CreateWorkstationFeaturesEventsViewExampleController = New CreateWorkstationFeaturesEventsViewExampleController()
         createWorkstationFeaturesEventsViewExample.Run()

         Dim pluggingViewExample As PluggingViewExampleController = New PluggingViewExampleController()
         pluggingViewExample.Run()

         Dim customizeActionsExample As CustomizeActionsExampleController = New CustomizeActionsExampleController()
         customizeActionsExample.Run()

         examplesMenu.RegisterFeatures(workstation.ViewerContainer.StripItemFeatureExecuter)

      End Sub
   End Class

   Class WorkstationLanguageResources
      Public ToolBarStream As Stream
      Public MessagesStream As Stream
      Public LoaderSteeam As Stream
      Public ActionsNameStream As Stream
   End Class
End Namespace
