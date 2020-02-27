' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.BatesStamp
Imports Leadtools.Annotations.Automation

Namespace PDFDocumentDemo.Annotations
   Partial Public Class AnnotationsControl : Inherits UserControl
      Private _documentAnnotations As DocumentAnnotations
      Public Property DocumentAnnotations() As DocumentAnnotations
         Get
            Return _documentAnnotations
         End Get
         Set(value As DocumentAnnotations)
            _documentAnnotations = Value
         End Set
      End Property

      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub CreateToolBar()

         ' Create the toolbar
         _documentAnnotations.AutomationManagerHelper.CreateToolBar()

         ' Set its properties
         Dim toolBar As ToolBar = _documentAnnotations.AutomationManagerHelper.ToolBar
         toolBar.Dock = DockStyle.Top
         toolBar.BringToFront()
         toolBar.Appearance = ToolBarAppearance.Flat
         toolBar.BringToFront()
         Me._toolbarPanel.Controls.Add(toolBar)

         Populate()
      End Sub

      Public Property Automation() As AnnAutomation
         Get
            Return _automationListControl.Automation
         End Get
         Set(value As AnnAutomation)
            If Not _automationListControl.Automation Is Nothing Then
               _automationListControl.Automation.Detach()
               _automationListControl.Automation = Nothing
            End If
            _automationListControl.Automation = Value
         End Set
      End Property

      Public Sub Populate()
         _automationListControl.Populate()
      End Sub

      'Public Sub UpdateSelectedObject()
      '   Dim automation_Renamed As AnnAutomation = Automation
      '   _automationListControl.SelectedItem = automation_Renamed.CurrentEditObject
      'End Sub

      Private Sub _propertiesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _propertiesToolStripMenuItem.Click
         _documentAnnotations.Automation.ShowObjectProperties()
      End Sub

      Private Sub _contentToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _contentToolStripMenuItem.Click
         _documentAnnotations.ShowObjectContent(_documentAnnotations.Automation.CurrentEditObject)
      End Sub

      Private Sub _deleteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _deleteToolStripMenuItem.Click
         _documentAnnotations.DeleteSelectedObject()
      End Sub
   End Class
End Namespace
