// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Leadtools.Medical.Media.AddIns.UI
{
   class MediaAutoCreationController
   {
      public MediaAutoCreationController 
      ( 
         IAutoCreationConfigView view,
         SynchronizationContext syncContext 
      ) 
      {
         View = view ;
         __SyncContext = syncContext ;
         
         View.Load                     += new EventHandler ( View_Load ) ;
         View.SaveConfiguration        += new EventHandler ( View_SaveConfiguration ) ;
         View.ViewConfigurationChanged += new EventHandler ( View_ViewConfigurationChanged ) ;
         
         AddInsSession.AddInsConfigurationSaved += new AddInsSession.AddInsConfigurationHandler ( AddInsSession_AddInsConfigurationSaved ) ;
         AddInsSession.AddInsConfigurationChanged += new AddInsSession.AddInsConfigurationHandler ( AddInsSession_AddInsConfigurationChanged ) ;
      }
      
      public void TearDown ( ) 
      {
         View.Load                     -= new EventHandler ( View_Load ) ;
         View.SaveConfiguration        -= new EventHandler ( View_SaveConfiguration ) ;
         View.ViewConfigurationChanged -= new EventHandler ( View_ViewConfigurationChanged ) ;
         
         AddInsSession.AddInsConfigurationSaved   -= new AddInsSession.AddInsConfigurationHandler ( AddInsSession_AddInsConfigurationSaved ) ;
         AddInsSession.AddInsConfigurationChanged -= new AddInsSession.AddInsConfigurationHandler ( AddInsSession_AddInsConfigurationChanged ) ;
         
         View = null ;
      }

      void AddInsSession_AddInsConfigurationChanged()
      {
         __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) {
            View.NotifyViewConfigurationChanged ( ) ;
         } ), null ) ;
      }

      void View_Load ( object sender, EventArgs e )
      {
         View.LoadConfiguration ( AddInsSession.MediaAutoCreationConfiguration ) ;
      }
      
      void View_SaveConfiguration(object sender, EventArgs e)
      {
         AddInsSession.SaveAddInConfiguration ( ) ;
      }
      
      void View_ViewConfigurationChanged ( object sender, EventArgs e )
      {
         AddInsSession.OnAddInsConfigurationChanged  ( ) ;
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
      
      public IAutoCreationConfigView View 
      {
         get ;
         private set ;
      }
   }
}
