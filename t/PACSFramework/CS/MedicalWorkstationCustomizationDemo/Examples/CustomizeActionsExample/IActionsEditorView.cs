// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Medical.Workstation.Interfaces.Views;
using System.Drawing;
namespace Leadtools.Demos.Workstation.Customized
{
   interface IActionsEditorView : IWorkstationView
   {
      string ActionDisplayName { get; set; }
      event EventHandler AddSelectedAction;
      bool CanAddAction { get; set; }
      bool CanEditToolstripButtons { get; set; }
      bool CanRemoveAction { get; set; }
      string FeatureId { get; set; }
      event EventHandler RemoveSelectedAction;
      Leadtools.MedicalViewer.MedicalViewerActionType SelectedAction { get; set; }
      event EventHandler SelectedActionChanged;
      event EventHandler SelectedActionMouseButtonChanged;
      Leadtools.MedicalViewer.MedicalViewerMouseButtons SelectedMouseButton { get; set; }
      void SetActionMouseButtons(Leadtools.MedicalViewer.MedicalViewerMouseButtons[] mouseButtons);
      void SetActions(Leadtools.MedicalViewer.MedicalViewerActionType[] actions);
      Image ToolStipItemImage { get; set; }
      Image ToolStipItemAlternativeImage { get; set; }
      event System.ComponentModel.CancelEventHandler ValidateFeatureId;
   
      bool CanChangeDisplayName { get ; set ;}
      bool CanChangeMouseButton { get ; set ;}
      bool CanChangeFeatureId { get ; set ;}
      
      void SetValidationErrorText ( string message ) ;
   }
}
