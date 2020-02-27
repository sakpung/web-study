' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Medical.Workstation.UI.Factory
Imports Leadtools.Medical.Workstation


Namespace Leadtools.Demos.Workstation.Customized
   MustInherit Class ExamplesControllerBase
      Public Sub New()
         _exampleCount += 1
      End Sub

      Public Sub Run()
         Dim viewer As WorkstationViewer
         Dim examplesMenu As ExamplesMenuStrip
         Dim exampleItem As DesignToolStripMenuItem
         Dim examplesDesctiptionControl As Control

         viewer = WorkstationUIFactory.Instance.GetWorkstsationControl(Of WorkstationViewer)(UIElementKeys.WorkstastionControl)
         examplesMenu = WorkstationUIFactory.Instance.GetWorkstsationControl(Of ExamplesMenuStrip)(UIElementKeys.ExamplesMenuStrip)

         examplesDesctiptionControl = WorkstationUIFactory.Instance.GetWorkstsationControl(Of Control)(UIElementKeys.ExamplesDescription)

         If Nothing Is viewer Then
            Throw New InvalidOperationException("Workstation Viewer is not registered.")
         End If

         If Nothing Is examplesMenu Then
            Throw New InvalidOperationException("Examples menu is not registered.")
         End If

         exampleItem = New DesignToolStripMenuItem(String.Format("Example {0}: {1}", _exampleCount, ExampleName))

         If Not Nothing Is examplesDesctiptionControl Then
            AddHandler exampleItem.MouseEnter, AddressOf exampleItem_MouseEnter
            AddHandler exampleItem.MouseLeave, AddressOf exampleItem_MouseLeave

            __DescriptionControl = examplesDesctiptionControl

            __DescriptionControl.ForeColor = Color.YellowGreen
            __DescriptionControl.Font = New Font(__DescriptionControl.Font, FontStyle.Bold)
         End If

         RegisterExampleCommands(viewer.ViewerContainer)
         RegisterExampleMenu(exampleItem)

         examplesMenu.Items.Add(exampleItem)
      End Sub

      Private Sub exampleItem_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
         __DescriptionControl.Text = String.Empty
      End Sub

      Private Sub exampleItem_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
         Try
            __DescriptionControl.Text = ExampleDescription
         Catch ex As Exception
            System.Diagnostics.Debug.Assert(False, ex.Message)
         End Try
      End Sub

      Protected MustOverride Sub RegisterExampleCommands(ByVal viewerContainer As WorkstationContainer)
      Protected MustOverride Sub RegisterExampleMenu(ByVal exampleItem As DesignToolStripMenuItem)

      Protected MustOverride ReadOnly Property ExampleName() As String

      Protected MustOverride ReadOnly Property ExampleDescription() As String

      Private __DescriptionControl As Control
      Private Shared _exampleCount As Integer = 0

   End Class
End Namespace
