' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports Leadtools.Medical.Workstation.Interfaces.Views

Namespace Leadtools.Demos.Workstation.Customized
   Interface IActionsEditorView : Inherits IWorkstationView
      Property ActionDisplayName() As String
      Event AddSelectedAction As EventHandler
      Property CanAddAction() As Boolean
      Property CanEditToolstripButtons() As Boolean
      Property CanRemoveAction() As Boolean
      Property FeatureId() As String
      Event RemoveSelectedAction As EventHandler
      Property SelectedAction() As MedicalViewer.MedicalViewerActionType
      Event SelectedActionChanged As EventHandler
      Event SelectedActionMouseButtonChanged As EventHandler
      Property SelectedMouseButton() As MedicalViewer.MedicalViewerMouseButtons
      Sub SetActionMouseButtons(ByVal mouseButtons As MedicalViewer.MedicalViewerMouseButtons())
      Sub SetActions(ByVal actions As MedicalViewer.MedicalViewerActionType())
      Property ToolStipItemImage() As Image
      Property ToolStipItemAlternativeImage() As Image
      Event ValidateFeatureId As System.ComponentModel.CancelEventHandler

      Property CanChangeDisplayName() As Boolean
      Property CanChangeMouseButton() As Boolean
      Property CanChangeFeatureId() As Boolean

      Sub SetValidationErrorText(ByVal message As String)
   End Interface
End Namespace
