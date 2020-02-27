// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scp.Media;
using Leadtools.Demos;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions ;
using System.Windows.Forms;
using Leadtools.Medical.Media.AddIns.UI;
using Leadtools.Medical.Media.AddIns.Commands;

namespace Leadtools.Medical.Media.AddIns
{
   class ShellController
   {
      public ShellController ( ) 
      {
      
      }
   
      public void Run ( ) 
      {
         RefereshQueueCommand          refreshMediaCmd ;
         MediaJobStatusController      statusController  ;
         MediaConfigurationController  configController ;
         MediaJobMaintenanceController maintenanceController ;
         MediaAutoCreationController   autoCreationController ;
         
         
         __State         = new MediaObjectsStateService ( new MediaCreationQueue ( ) ) ;
         _mainForm       = new MediaConfigurationDialog ( ) ;
         refreshMediaCmd = new RefereshQueueCommand ( __State ) ;
         
         refreshMediaCmd.Execute ( ) ;
         
         statusController = new MediaJobStatusController ( _mainForm.MediaJobStatusView, 
                                                           __State ,
                                                           System.Windows.Forms.WindowsFormsSynchronizationContext.Current ) ;

         configController = new MediaConfigurationController  ( _mainForm.MediaConfigurationView,
                                                                WindowsFormsSynchronizationContext.Current ) ;
         
         maintenanceController = new MediaJobMaintenanceController ( _mainForm.MediaJobMaintenanceView,
                                                                     WindowsFormsSynchronizationContext.Current ) ;
         
         autoCreationController = new MediaAutoCreationController ( _mainForm.AutoCreationConfigView,
                                                                     WindowsFormsSynchronizationContext.Current ) ;
         
         statusController.BurnActiveMedia += new EventHandler ( statusController_BurnActiveMedia ) ;
         
         try
         {
            _mainForm.Icon = Leadtools.Medical.Media.AddIns.Properties.Resources.BurnConfig ;
            
            _mainForm.ShowDialog ( ) ;
         }
         finally
         {
            statusController.BurnActiveMedia -= new EventHandler ( statusController_BurnActiveMedia ) ;
            
            autoCreationController.TearDown ( ) ;
            
            maintenanceController.TearDown ( ) ;
            
            configController.TearDown ( ) ;
            
            statusController.TearDown ( ) ;
            
            _mainForm.Dispose ( ) ;
            
            __State.Dispose ( ) ;
         }
      }

      void statusController_BurnActiveMedia ( object sender, EventArgs e )
      {
         if ( null != __State.ActiveMediaItem ) 
         {
            BurnMedia burnMediaForm = new BurnMedia ( ) ;
            
            BurnMediaPresenter burnPresenter = new BurnMediaPresenter ( burnMediaForm.BurnMediaControl, 
                                                                       __State,
                                                                       System.Windows.Forms.WindowsFormsSynchronizationContext.Current  ) ;

            burnMediaForm.Tag = burnPresenter ;
            
            burnMediaForm.FormClosing += new FormClosingEventHandler ( burnMediaForm_FormClosing ) ;
            
            burnMediaForm.StartPosition = FormStartPosition.CenterParent ;
            
            if ( DialogResult.OK == burnMediaForm.ShowDialog ( _mainForm ) )
            {
               
            }
         }
      }

      void burnMediaForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         BurnMediaPresenter burnPresenter ;
         
         
         burnPresenter  = ( sender as Form ).Tag as BurnMediaPresenter ;
         
         if ( null != burnPresenter ) 
         {
            if ( burnPresenter.IsProcessing ) 
            {
               Messager.ShowWarning ( sender as Form, 
                                      "A media operation is currently in progress. Wait for the operation to finish or cancel." ) ;
            
               e.Cancel = true ;
            }
            else
            {
               burnPresenter.TearDown ( ) ;
            }
         }
      }
      
      private MediaObjectsStateService __State 
      {
         get ;
         set ;
      }
      
      private MediaConfigurationDialog _mainForm ;
   }
}
