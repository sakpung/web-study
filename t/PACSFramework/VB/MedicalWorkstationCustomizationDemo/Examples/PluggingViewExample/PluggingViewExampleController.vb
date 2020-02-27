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

Namespace Leadtools.Demos.Workstation.Customized
   Class PluggingViewExampleController : Inherits ExamplesControllerBase

      Protected Overrides Sub RegisterExampleCommands(ByVal viewerContainer As WorkstationContainer)
         Dim customWlControlCommand As PlugWorkstationViewCommand(Of IWindowLevelView, CustomWindowLevelControl)
         Dim originalWlDlgCommand As PlugWorkstationViewCommand(Of IWindowLevelView, WindowLevelDialog)

         customWlControlCommand = New PlugWorkstationViewCommand(Of IWindowLevelView, CustomWindowLevelControl)(CustomWorkstationFeatures.PlugCustomWindowLevelControlFeatureId, viewerContainer)
         originalWlDlgCommand = New PlugWorkstationViewCommand(Of IWindowLevelView, WindowLevelDialog)(CustomWorkstationFeatures.PlugOrigWindowLevelControlFeatureId, viewerContainer)

         viewerContainer.FeaturesFactory.RegisterCommand(customWlControlCommand)
         viewerContainer.FeaturesFactory.RegisterCommand(originalWlDlgCommand)

         AddHandler viewerContainer.EventBroker.FeatureExecuted, AddressOf EventBroker_FeatureExecuted
      End Sub

      Private Sub EventBroker_FeatureExecuted(ByVal sender As Object, ByVal e As DataEventArgs(Of String))
         If e.Data = CustomWorkstationFeatures.PlugCustomWindowLevelControlFeatureId Then
            _plugCustomWl.Checked = True
            _plugOriginWl.Checked = False
         ElseIf e.Data = CustomWorkstationFeatures.PlugOrigWindowLevelControlFeatureId Then
            _plugCustomWl.Checked = False
            _plugOriginWl.Checked = True
         End If
      End Sub

      Private _plugCustomWl As DesignToolStripMenuItem
      Private _plugOriginWl As DesignToolStripMenuItem

      Protected Overrides Sub RegisterExampleMenu(ByVal exampleItem As DesignToolStripMenuItem)


         _plugCustomWl = New DesignToolStripMenuItem(CustomMenuItemFeatureProperties.PlugCustomWindowLevelControlProperty)
         _plugOriginWl = New DesignToolStripMenuItem(CustomMenuItemFeatureProperties.PlugOrigWindowLevelControlProperty)

         exampleItem.DropDownItems.Add(_plugCustomWl)
         exampleItem.DropDownItems.Add(_plugOriginWl)

         _plugCustomWl.Checked = False
         _plugOriginWl.Checked = True

      End Sub

      Protected Overrides ReadOnly Property ExampleName() As String
         Get
            Return "Plug View Example"
         End Get
      End Property

      Protected Overrides ReadOnly Property ExampleDescription() As String
         Get
            Return "This example will show you how to replace a View (dialog/control) used by the Workstation with a totally new view. The new view will provide the same functionality as the original view without the need to write the code for that. In this example, a new Control will be used to replace the default Window Level Dialog. The new control will be displayed on the Workstation as a child control instead of the default behavior of showing a dialog. To display the dialog, load a series and click on the \'Custom\' menu item under the Window Level button on the toolbar."
         End Get
      End Property
   End Class
End Namespace
