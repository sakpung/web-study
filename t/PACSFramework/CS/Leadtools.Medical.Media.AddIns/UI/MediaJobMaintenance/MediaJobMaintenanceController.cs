// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Leadtools.Medical.Media.AddIns
{
   public class MediaJobMaintenanceController
   {
      public MediaJobMaintenanceController 
      ( 
         IMediaJobMaintenanceView view,
         SynchronizationContext syncContext 
      ) 
      {
         View          = view ;
         __SyncContext = syncContext ;

         View.Load        += new EventHandler ( View_Load ) ;
         View.SaveChanges += new EventHandler ( View_SaveChanges ) ;
         
         View.ViewConfigurationChanged += new EventHandler ( View_ViewConfigurationChanged ) ;
         
         AddInsSession.AddInsConfigurationSaved += new AddInsSession.AddInsConfigurationHandler   ( AddInsSession_AddInsConfigurationSaved ) ;
         AddInsSession.AddInsConfigurationChanged += new AddInsSession.AddInsConfigurationHandler ( AddInsSession_AddInsConfigurationChanged ) ;
      }
      
      public void TearDown ( ) 
      {
         View.Load        -= new EventHandler ( View_Load ) ;
         View.SaveChanges -= new EventHandler ( View_SaveChanges ) ;
         
         View.ViewConfigurationChanged -= new EventHandler ( View_ViewConfigurationChanged ) ;
         
         AddInsSession.AddInsConfigurationSaved   -= new AddInsSession.AddInsConfigurationHandler   ( AddInsSession_AddInsConfigurationSaved ) ;
         AddInsSession.AddInsConfigurationChanged -= new AddInsSession.AddInsConfigurationHandler ( AddInsSession_AddInsConfigurationChanged ) ;
         
         View = null ;
      }

      void AddInsSession_AddInsConfigurationChanged ( )
      {
         __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) {
            View.NotifyViewConfigurationChanged ( ) ;
         } ), null ) ;
         
         View.NotifyViewConfigurationChanged ( ) ;
      }

      void View_ViewConfigurationChanged ( object sender, EventArgs e )
      {
         AddInsSession.OnAddInsConfigurationChanged ( ) ;
      }

      void View_Load ( object sender, EventArgs e )
      {
         View.LoadMaintenanceConfiguration ( AddInsSession.MaintenanceConfiguration ) ;
      }
      
      void View_SaveChanges ( object sender, EventArgs e )
      {
         AddInsSession.SaveAddInConfiguration ( ) ;
      }
      
      void AddInsSession_AddInsConfigurationSaved ( )
      {
         __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) {
            View.OnChangesSaved ( ) ;
         } ), null ) ;
      }
      
      private SynchronizationContext __SyncContext
      {
         get ;
         set ;
      }
      
      public IMediaJobMaintenanceView View
      {
         get ;
         private set ;
      }
   }
}
