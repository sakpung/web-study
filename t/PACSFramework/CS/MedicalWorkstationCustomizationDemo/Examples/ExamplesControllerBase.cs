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
using System.Windows.Forms;
using System.Drawing;

namespace Leadtools.Demos.Workstation.Customized
{
   abstract class ExamplesControllerBase
   {
      public ExamplesControllerBase ( ) 
      {
         _exampleCount++ ;
      }
      
      public void Run ( ) 
      {
         WorkstationViewer       viewer ;
         ExamplesMenuStrip     examplesMenu ;
         DesignToolStripMenuItem exampleItem ;
         Control                 examplesDesctiptionControl ;
         
         viewer       = WorkstationUIFactory.Instance.GetWorkstsationControl <WorkstationViewer>   ( UIElementKeys.WorkstastionControl ) ;
         examplesMenu = WorkstationUIFactory.Instance.GetWorkstsationControl <ExamplesMenuStrip> ( UIElementKeys.ExamplesMenuStrip ) ;
         
         examplesDesctiptionControl = WorkstationUIFactory.Instance.GetWorkstsationControl <Control> ( UIElementKeys.ExamplesDescription ) ;
         
         if ( null == viewer ) 
         {
            throw new InvalidOperationException ( "Workstation Viewer is not registered." ) ;
         }
         
         if ( null == examplesMenu ) 
         {
            throw new InvalidOperationException ( "Examples menu is not registered." ) ;
         }
         
         exampleItem = new DesignToolStripMenuItem ( string.Format ( "Example {0}: {1}", _exampleCount, ExampleName ) ) ;

         if ( null != examplesDesctiptionControl ) 
         {
            exampleItem.MouseEnter += new EventHandler(exampleItem_MouseEnter);
            exampleItem.MouseLeave += new EventHandler(exampleItem_MouseLeave);
            
            __DescriptionControl = examplesDesctiptionControl ;
            
            __DescriptionControl.ForeColor = Color.YellowGreen ;
            __DescriptionControl.Font = new Font ( __DescriptionControl.Font, FontStyle.Bold ) ;
         }
         
         RegisterExampleCommands ( viewer.ViewerContainer ) ;
         RegisterExampleMenu     ( exampleItem ) ;
         
         examplesMenu.Items.Add ( exampleItem ) ;
      }

      void exampleItem_MouseLeave ( object sender, EventArgs e )
      {
         __DescriptionControl.Text = string.Empty ;
      }

      void exampleItem_MouseEnter(object sender, EventArgs e)
      {
         try
         {
            __DescriptionControl.Text = ExampleDescription ;
         }
         catch ( Exception ex )
         {
            System.Diagnostics.Debug.Assert ( false, ex.Message ) ;
         }
      }
      
      protected abstract void RegisterExampleCommands ( WorkstationContainer viewerContainer ) ;
      protected abstract void RegisterExampleMenu  ( DesignToolStripMenuItem exampleItem ) ;
      
      protected abstract string ExampleName
      {
         get ;
      }
      
      protected abstract string ExampleDescription
      {
         get ;
      }
      
      private Control __DescriptionControl
      {
         get ;
         set ;
      }
      
      private static int _exampleCount = 0 ;
   }
}
