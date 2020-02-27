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

namespace Leadtools.Demos.Workstation.Customized
{
   class PluggingViewExampleController : ExamplesControllerBase
   {

      protected override void RegisterExampleCommands ( WorkstationContainer viewerContainer)
      {
         PlugWorkstationViewCommand<IWindowLevelView, CustomWindowLevelControl> customWlControlCommand ;
         PlugWorkstationViewCommand<IWindowLevelView, WindowLevelDialog> originalWlDlgCommand ;
         
         customWlControlCommand = new PlugWorkstationViewCommand<IWindowLevelView,CustomWindowLevelControl> ( CustomWorkstationFeatures.PlugCustomWindowLevelControlFeatureId, viewerContainer ) ;
         originalWlDlgCommand   = new PlugWorkstationViewCommand<IWindowLevelView,WindowLevelDialog>        ( CustomWorkstationFeatures.PlugOrigWindowLevelControlFeatureId, viewerContainer ) ;
         
         viewerContainer.FeaturesFactory.RegisterCommand ( customWlControlCommand ) ;
         viewerContainer.FeaturesFactory.RegisterCommand ( originalWlDlgCommand ) ;

         viewerContainer.EventBroker.FeatureExecuted += new EventHandler<DataEventArgs<string>>(EventBroker_FeatureExecuted);
      }

      void EventBroker_FeatureExecuted(object sender, DataEventArgs<string> e)
      {
         if (e.Data == CustomWorkstationFeatures.PlugCustomWindowLevelControlFeatureId)
         {
            _plugCustomWl.Checked = true;
            _plugOriginWl.Checked = false;
         }
         else if (e.Data == CustomWorkstationFeatures.PlugOrigWindowLevelControlFeatureId)
         {
            _plugCustomWl.Checked = false;
            _plugOriginWl.Checked = true;
         }
      }

      DesignToolStripMenuItem _plugCustomWl;
      DesignToolStripMenuItem _plugOriginWl;

      protected override void RegisterExampleMenu ( DesignToolStripMenuItem exampleItem)
      {
         
         
         _plugCustomWl = new DesignToolStripMenuItem ( CustomMenuItemFeatureProperties.PlugCustomWindowLevelControlProperty ) ;
         _plugOriginWl = new DesignToolStripMenuItem ( CustomMenuItemFeatureProperties.PlugOrigWindowLevelControlProperty ) ;
         
         exampleItem.DropDownItems.Add ( _plugCustomWl ) ;
         exampleItem.DropDownItems.Add ( _plugOriginWl ) ;

         _plugCustomWl.Checked = false;
         _plugOriginWl.Checked = true;

      }

      protected override string ExampleName
      {
         get { return "Plug View Example"; }
      }

      protected override string ExampleDescription
      {
         get { return @"This example will show you how to replace a View (dialog/control) used by the Workstation with a totally new view. 

The new view will provide the same functionality as the original view without the need to write the code for that.

In this example, a new Control will be used to replace the default Window Level Dialog. The new control will be displayed on the Workstation as a child control instead of the default behavior of showing a dialog.

To display the dialog, load a series and click on the “Custom” menu item under the Window Level button on the toolbar.
"; }
      }
   }
}
