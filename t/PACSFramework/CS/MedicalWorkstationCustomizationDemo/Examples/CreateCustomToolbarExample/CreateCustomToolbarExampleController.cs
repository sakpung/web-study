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

namespace Leadtools.Demos.Workstation.Customized
{
   class CreateCustomToolbarExampleController : ExamplesControllerBase
   {
      protected override void RegisterExampleMenu ( DesignToolStripMenuItem exampleItem )
      {
         DesignToolStripMenuItem toggleToolbarItem ;
         
         
         toggleToolbarItem = new DesignToolStripMenuItem ( CustomMenuItemFeatureProperties.ToggelToolbarItemProperty ) ;
         
         exampleItem.DropDownItems.Add ( toggleToolbarItem ) ;
      }

      protected override void RegisterExampleCommands ( WorkstationContainer viewerContainer )
      {
         Custom3DToolbar      toolStrip3D ;
         ToggleToolBarCommand toggleToolBar ;
         
         
         toolStrip3D   = new Custom3DToolbar ( ) ;
         toggleToolBar = new ToggleToolBarCommand ( CustomWorkstationFeatures.ToggleToolBarFeatureId, 
                                                    viewerContainer, 
                                                    toolStrip3D ) ;

         toolStrip3D.Renderer = viewerContainer.State.ActiveWorkstation.ToolBarRenderer ;
         
         toolStrip3D.SyncronizeToolbar ( viewerContainer.State ) ;
         
         viewerContainer.FeaturesFactory.RegisterCommand ( CustomWorkstationFeatures.ToggleToolBarFeatureId, toggleToolBar ) ;
      }

      protected override string ExampleName
      {
         get { return "Create Custom Toolbar" ; }
      }

      protected override string ExampleDescription
      {
         get 
         { 
            return @"This example shows you how to create your own Toolbar and include the same features the Workstation Toolbar implement.

The example will create a Toolstip control and add some 3D buttons to it then assign the same tool strip item properties (Text, Images, Features) used by the Workstation toolbar.

The toolbar will be registered with the workstation components to execute the features behind each button.

Also the toolbar will change its buttons state (Enable/Visible) automatically based on the current Workstation behavior." ;
         }
      }
   }
}
