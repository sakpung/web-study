// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Workstation.Presenters;
using System.Windows.Forms;
using System.Threading;

namespace Leadtools.Demos.Workstation.Customized
{
   class WorkstastionFeaturesEventsPresenter : WorkstationPresenterBase <IWorkstastionFeaturesEventsView>
   {
      public WorkstastionFeaturesEventsPresenter ( ) 
      {
         __SyncContext = WindowsFormsSynchronizationContext.Current ;
      }
      
      protected override void DoInitialize 
      ( 
         Leadtools.Medical.Workstation.WorkstationContainer container, 
         IWorkstastionFeaturesEventsView view 
      )
      {
         container.EventBroker.FeatureExecuted += new EventHandler<Leadtools.Medical.Workstation.DataEventArgs<string>>(EventBroker_FeatureExecuted);
         
         view.CanStart = false ;
         view.CanStop  = true ;

         view.StartListeningToeEvents += new EventHandler(view_StartListeningToeEvents);
         view.StopListeningToeEvents += new EventHandler(view_StopListeningToeEvents);
         
         view.ActivateView ( container.State.ActiveWorkstation ) ;
      }

      protected override void OnViewDeactivated ( object sender, EventArgs e )
      {
         StopListening ( null ) ;
         
         base.OnViewDeactivated ( sender, e ) ;
      }
      
      private void StopListening ( object state )
      {
         try
         {
            if ( View.CanStop )
            {
               ViewerContainer.EventBroker.FeatureExecuted -= new EventHandler<Leadtools.Medical.Workstation.DataEventArgs<string>>(EventBroker_FeatureExecuted);
               
               View.CanStop  = false ;
               View.CanStart = true ;
            }
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( ViewerContainer.State.ActiveWorkstation, exception ) ;
         }
      }
      
      private void StartListening ( object state )
      {
         try
         {
            if ( View.CanStart ) 
            {
               ViewerContainer.EventBroker.FeatureExecuted += new EventHandler<Leadtools.Medical.Workstation.DataEventArgs<string>>(EventBroker_FeatureExecuted);
            
               View.CanStart = false ;
               View.CanStop  = true ;
            }
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( ViewerContainer.State.ActiveWorkstation, exception ) ;
         }
      }

      void view_StopListeningToeEvents ( object sender, EventArgs e )
      {
         try
         {
            __SyncContext.Send ( new SendOrPostCallback ( StopListening ), null ) ;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( ViewerContainer.State.ActiveWorkstation, exception ) ;
         }
      }
      
      void view_StartListeningToeEvents ( object sender, EventArgs e )
      {
         try
         {
            __SyncContext.Send ( new SendOrPostCallback ( StartListening ), null ) ;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( ViewerContainer.State.ActiveWorkstation, exception ) ;
         }
      }

      void EventBroker_FeatureExecuted ( object sender, Leadtools.Medical.Workstation.DataEventArgs<string> e )
      {
         try
         {
            __SyncContext.Send ( delegate ( object state ) { View.AddFeatureEvent ( e.Data, sender ) ; }, null ) ;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( ViewerContainer.State.ActiveWorkstation, exception ) ;
         }
      }
      
      private SynchronizationContext __SyncContext
      {
         get ;
         set ;
      }
   }
}

