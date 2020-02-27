' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Medical.Workstation.UI.Factory
Imports Leadtools.Medical.Workstation

Namespace Leadtools.Demos.Workstation.Customized
   Class LoadSeriesExampleController : Inherits ExamplesControllerBase
      Public Sub New()

      End Sub

      Protected Overrides Sub RegisterExampleMenu(ByVal exampleItem As DesignToolStripMenuItem)
         Dim loadSeriesItem As DesignToolStripMenuItem
         Dim toggleLoadSeriesItem As DesignToolStripMenuItem


         loadSeriesItem = New DesignToolStripMenuItem(CustomMenuItemFeatureProperties.LoadDicomDirItemProperty)
         toggleLoadSeriesItem = New DesignToolStripMenuItem("Add/Remove Item to Toolbar")

         loadSeriesItem.ItemProperties.DefaultImage = New Bitmap(Resources.folder_open.ToBitmap(), New Size(16, 16))
         toggleLoadSeriesItem.ItemProperties.FeatureId = CustomWorkstationFeatures.ToggleLoadSeriesItem

         exampleItem.DropDownItems.Add(loadSeriesItem)
         exampleItem.DropDownItems.Add(toggleLoadSeriesItem)
      End Sub

      Protected Overrides Sub RegisterExampleCommands(ByVal viewerContainer As WorkstationContainer)
         Dim loadDicomDirCmd As LoadSeriesFromDicomDirCommand
         Dim toggleLoadSeriesItemCmd As AddRemoveToolbarFeatureItemCommand
         Dim loadDicomSeriesItem As DesignToolStripMenuItem

         loadDicomDirCmd = New LoadSeriesFromDicomDirCommand(CustomWorkstationFeatures.LoadDicomDirSeriesFeatureId, viewerContainer)

         loadDicomSeriesItem = New DesignToolStripMenuItem(CustomMenuItemFeatureProperties.LoadDicomDirItemProperty)


         loadDicomSeriesItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         loadDicomSeriesItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
         'loadDicomSeriesItem.Size = new System.Drawing.Size(23, 60);


         toggleLoadSeriesItemCmd = New AddRemoveToolbarFeatureItemCommand(CustomWorkstationFeatures.ToggleLoadSeriesItem, viewerContainer, loadDicomSeriesItem)

         viewerContainer.FeaturesFactory.RegisterCommand(loadDicomDirCmd)
         viewerContainer.FeaturesFactory.RegisterCommand(toggleLoadSeriesItemCmd)

         AddHandler viewerContainer.EventBroker.SeriesLoadingCompleted, AddressOf EventBroker_SeriesLoadingCompleted
      End Sub

      Private Sub EventBroker_SeriesLoadingCompleted(ByVal sender As Object, ByVal e As LoadSeriesEventArgs)
         If Not Nothing Is e.LoadedSeries AndAlso Not Nothing Is e.LoadedSeries.Viewer Then
            e.LoadedSeries.Viewer.EnsureSelectedCellVisible()
         End If
      End Sub

      Protected Overrides ReadOnly Property ExampleName() As String
         Get
            Return "Load DICOMDIR"
         End Get
      End Property

      Protected Overrides ReadOnly Property ExampleDescription() As String
         Get
            Return "This example will show you how to implement a simple feature and register it with the Workstation Framework. The feature will load a DICOM DIR into the Workstation Viewer. The example will also show you how registering this feature will allow you to easily add it into the Workstation Viewer Toolbar."
         End Get
      End Property
   End Class
End Namespace
