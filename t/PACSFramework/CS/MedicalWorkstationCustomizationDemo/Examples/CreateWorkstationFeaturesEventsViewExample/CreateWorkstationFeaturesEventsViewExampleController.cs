// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Workstation;
using Leadtools.Medical.Workstation.UI;
using Leadtools.Medical.Workstation.Commands;
using Leadtools.Medical.Workstation.UI.Factory;

namespace Leadtools.Demos.Workstation.Customized
{
   class CreateWorkstationFeaturesEventsViewExampleController : ExamplesControllerBase
   {
      protected override void RegisterExampleCommands ( WorkstationContainer viewerContainer )
      {
         ModelViewPresenterCommand <WorkstastionFeaturesEventsPresenter, IWorkstastionFeaturesEventsView> cmd ;
         
         
         WorkstationUIFactory.Instance.RegisterWorkstationView <IWorkstastionFeaturesEventsView> ( typeof ( WorkstastionFeaturesEventsView ) ) ;
         
         cmd = new ModelViewPresenterCommand<WorkstastionFeaturesEventsPresenter,IWorkstastionFeaturesEventsView> ( CustomWorkstationFeatures.FeaturesEventsViewFeatureId, viewerContainer ) ;
         
         viewerContainer.FeaturesFactory.RegisterCommand ( cmd ) ;
      }

      protected override void RegisterExampleMenu ( DesignToolStripMenuItem exampleItem )
      {
         DesignToolStripMenuItem toggleToolbarItem ;
         
         
         toggleToolbarItem = new DesignToolStripMenuItem ( CustomMenuItemFeatureProperties.CreateFeaturesEventsViewItemProperty ) ;
         
         exampleItem.DropDownItems.Add ( toggleToolbarItem ) ;
      }

      protected override string ExampleName
      {
         get { return "Features Events View" ;  }
      }

      protected override string ExampleDescription
      {
         get { return @"This example shows you how to use the Workstation Event Broker component to listen to various events in the Workstation. All features executed by the Workstation Framework fires events that can be traced by interested components.

You can also use this as a learning tool to understand the different features implemented by the Workstation Framework and the components that executes them. 

The example also implements the built-in Model/View/Presenter pattern which is used by the Workstation Framework to register and display controls. This is used to display the Features Events Dialog

While the dialog is displayed, load DICOM series and apply some actions on the images or execute some toolbar/menu commands to see the dialog populated with the events." ; 
         }
      }
   }
}
