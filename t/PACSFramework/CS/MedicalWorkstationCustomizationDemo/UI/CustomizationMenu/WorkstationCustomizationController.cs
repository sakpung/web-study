// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Medical.Workstation.UI;
using Leadtools.Medical.Workstation.UI.Factory;
using Leadtools.Medical.Workstation.Commands;
using Leadtools.Medical.Workstation;
using System.IO;
using System.Reflection;
using Leadtools.Medical.Workstation.Interfaces.Views;
using Leadtools.Medical.Workstation.Presenters;
using Leadtools.Medical.Workstation.Loader;
using Leadtools.Medical.Workstation.Client.Local;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Dicom;
using Leadtools.Demos.Workstation.Customized;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Drawing;

namespace Leadtools.Demos.Workstation.Customized
{
   class WorkstationCustomizationController
   {
      public WorkstationCustomizationController ( ) 
      {
         WorkstationViewer   workstation ;
         ExamplesMenuStrip examplesMenu ;
         
         
         workstation  = WorkstationUIFactory.Instance.GetWorkstsationControl <WorkstationViewer> ( UIElementKeys.WorkstastionControl ) ;
         examplesMenu = WorkstationUIFactory.Instance.GetWorkstsationControl <ExamplesMenuStrip> ( UIElementKeys.ExamplesMenuStrip ) ;
      
         if ( null == workstation ) 
         {
            throw new InvalidOperationException ( "Workstation Viewer is not registered." ) ;
         }
         
         if ( null == examplesMenu ) 
         {
            throw new InvalidOperationException ( "Examples menu is not registered." ) ;
         }
         
         
         WorkstationCommand command = workstation.ViewerContainer.FeaturesFactory.GetFeatureCommand ( WorkstationFeatures.ShowSeriesBrowserFeatureId ) as WorkstationCommand ;
         
         if ( null != command ) 
         {
            command.Supported = false ;
         }
         
         new LoadSeriesExampleController ( ).Run ( ) ;
         new LocalizationExampleController ( ).Run ( ) ;
         new CreateCustomToolbarExampleController ( ).Run ( ) ;
         new CreateWorkstationFeaturesEventsViewExampleController ( ).Run ( ) ;
         new PluggingViewExampleController ( ).Run ( ) ;
         new CustomizeActionsExampleController ( ) .Run ( ) ;
         examplesMenu.RegisterFeatures ( workstation.ViewerContainer.StripItemFeatureExecuter ) ;
         
      }
   }
   
   class WorkstationLanguageResources
   {
      public Stream ToolBarStream
      {
         get ;
         set ;
      }
      
      public Stream MessagesStream
      {
         get ;
         set ;
      }
      
      public Stream LoaderSteeam
      {
         get ;
         set ;
      }
      
      public Stream ActionsNameStream
      {
         get ;
         set ;
      }
   }
   
}
