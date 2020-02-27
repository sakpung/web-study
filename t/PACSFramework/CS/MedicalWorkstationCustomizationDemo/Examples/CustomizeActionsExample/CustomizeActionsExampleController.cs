// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Workstation.UI;
using Leadtools.Medical.Workstation;
using Leadtools.Medical.Workstation.UI.Factory;
using Leadtools.Medical.Workstation.Interfaces.Views;
using Leadtools.Medical.Workstation.Commands;

namespace Leadtools.Demos.Workstation.Customized
{
   class CustomizeActionsExampleController : ExamplesControllerBase
   {

      protected override void RegisterExampleCommands ( WorkstationContainer viewerContainer)
      {
         WorkstationUIFactory.Instance.RegisterWorkstationView <IActionsEditorView> ( typeof ( ActionsEditorDialog ) ) ;
         
         ModelViewPresenterCommand <ActionsEditorViewPresenter, IActionsEditorView> cmd ;
         
         cmd = new ModelViewPresenterCommand<ActionsEditorViewPresenter, IActionsEditorView> ( CustomWorkstationFeatures.ShowCustomizeActionsViewFeatureId, viewerContainer ) ;
         
         viewerContainer.FeaturesFactory.RegisterCommand ( cmd ) ;
      }

      protected override void RegisterExampleMenu ( DesignToolStripMenuItem exampleItem)
      {
         DesignToolStripMenuItem showCustomizeActions ;
         
         
         showCustomizeActions = new DesignToolStripMenuItem ( CustomMenuItemFeatureProperties.ShowCustomizeActionViewProperty ) ;
         
         exampleItem.DropDownItems.Add ( showCustomizeActions ) ;
      }

      protected override string ExampleName
      {
         get { return "Customize Viewer Actions"; }
      }

      protected override string ExampleDescription
      {
         get { return @"This example will show you how to customize the Workstation Toolbar/Context Menu by adding new Medical Viewer Actions into it. 

You can easily add new features/buttons into Workstation toolbar/context menu and it will be executed when you click on it. The buttons will also maintain their state as Enabled/Disabled automatically based on whether the feature can be executed or not.

For example, you can add a new Free Hand Annotation and it will be added under the Annotation button in the toolbar and the Context menu, or you can add a new Alpha action and it will be added as a top level button in the toolbar.

The example also implements the built-in Model/View/Presenter pattern which is used by the Workstation Framework to register and display controls. This is used to display the Features Events Dialog "; 
            }
      }
   }
}
