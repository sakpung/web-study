// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Workstation.UI;
using Leadtools.Medical.Workstation.UI.Factory;
using Leadtools.Medical.Workstation;
using System.Drawing;

namespace Leadtools.Demos.Workstation.Customized
{
   class LoadSeriesExampleController : ExamplesControllerBase 
   {
      public LoadSeriesExampleController ( ) 
      {
         
      }
      
      protected override void RegisterExampleMenu ( DesignToolStripMenuItem exampleItem ) 
      {
         DesignToolStripMenuItem loadSeriesItem ;
         DesignToolStripMenuItem toggleLoadSeriesItem ;
         
         
         loadSeriesItem       = new DesignToolStripMenuItem ( CustomMenuItemFeatureProperties.LoadDicomDirItemProperty ) ;
         toggleLoadSeriesItem = new DesignToolStripMenuItem ( "Add/Remove Item to Toolbar" ) ;
         
         loadSeriesItem.ItemProperties.DefaultImage = new Bitmap ( Leadtools.Demos.Workstation.Customized.Properties.Resources.folder_open.ToBitmap ( ), new Size ( 16, 16 ) ) ;
         toggleLoadSeriesItem.ItemProperties.FeatureId = CustomWorkstationFeatures.ToggleLoadSeriesItem ;
         
         exampleItem.DropDownItems.Add ( loadSeriesItem ) ;
         exampleItem.DropDownItems.Add ( toggleLoadSeriesItem ) ;
      }
      
      protected override void RegisterExampleCommands ( WorkstationContainer viewerContainer )
      {
         LoadSeriesFromDicomDirCommand loadDicomDirCmd ;
         AddRemoveToolbarFeatureItemCommand toggleLoadSeriesItemCmd ;
         DesignToolStripMenuItem  loadDicomSeriesItem ;
         
         loadDicomDirCmd = new LoadSeriesFromDicomDirCommand ( CustomWorkstationFeatures.LoadDicomDirSeriesFeatureId, 
                                                               viewerContainer ) ;

         loadDicomSeriesItem = new DesignToolStripMenuItem ( CustomMenuItemFeatureProperties.LoadDicomDirItemProperty ) ;
         
         
         loadDicomSeriesItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image ;
         loadDicomSeriesItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         //loadDicomSeriesItem.Size = new System.Drawing.Size(23, 60);
         
         
         toggleLoadSeriesItemCmd = new AddRemoveToolbarFeatureItemCommand ( CustomWorkstationFeatures.ToggleLoadSeriesItem, viewerContainer, loadDicomSeriesItem ) ;
         
         viewerContainer.FeaturesFactory.RegisterCommand ( loadDicomDirCmd ) ;
         viewerContainer.FeaturesFactory.RegisterCommand ( toggleLoadSeriesItemCmd ) ;

         viewerContainer.EventBroker.SeriesLoadingCompleted += new EventHandler<LoadSeriesEventArgs> ( EventBroker_SeriesLoadingCompleted ) ;
      }

      void EventBroker_SeriesLoadingCompleted(object sender, LoadSeriesEventArgs e)
      {
         if ( null != e.LoadedSeries && null != e.LoadedSeries.Viewer )
         {
            e.LoadedSeries.Viewer.EnsureSelectedCellVisible ( ) ;
         }
      }

      protected override string ExampleName
      {
         get { return "Load DICOMDIR" ; }
      }

      protected override string ExampleDescription
      {
         get 
         {  
            return @"This example will show you how to implement a simple feature and register it with the Workstation Framework. 

The feature will load a DICOM DIR into the Workstation Viewer.

The example will also show you how registering this feature will allow you to easily add it into the Workstation Viewer Toolbar.
" ;
         }
      }
   }
}
