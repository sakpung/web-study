// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Leadtools.Medical.Media.AddIns.Composing;

namespace Leadtools.Medical.Media.AddIns
{
   public class MediaConfigurationController
   {
      #region Public
         
         #region Methods
         
            public MediaConfigurationController 
            ( 
               IMediaConfigurationView view,
               SynchronizationContext syncContext
            )
            {
               View          = view ;
               __SyncContext = syncContext ;
               
               View.Load        += new EventHandler ( View_Load ) ;
               View.SaveChanges += new EventHandler ( View_SaveChanges ) ;
               View.ViewConfigurationChanged += new EventHandler ( View_ViewConfigurationChanged ) ;

               AddInsSession.AddInsConfigurationSaved   += new AddInsSession.AddInsConfigurationHandler ( AddInsSession_AddInsConfigurationSaved ) ;
               AddInsSession.AddInsConfigurationChanged += new AddInsSession.AddInsConfigurationHandler ( AddInsSession_AddInsConfigurationChanged ) ;
            }
            
            public void TearDown ( ) 
            {
               View.Load                     -= new EventHandler ( View_Load ) ;
               View.SaveChanges              -= new EventHandler ( View_SaveChanges ) ;
               View.ViewConfigurationChanged -= new EventHandler ( View_ViewConfigurationChanged ) ;

               AddInsSession.AddInsConfigurationSaved   -= new AddInsSession.AddInsConfigurationHandler ( AddInsSession_AddInsConfigurationSaved ) ;
               AddInsSession.AddInsConfigurationChanged -= new AddInsSession.AddInsConfigurationHandler ( AddInsSession_AddInsConfigurationChanged ) ;
               
               View.TearDown ( ) ;
               
               View = null ;
            }

         #endregion
         
         #region Properties
         
            public IMediaConfigurationView View
            {
               get ;
               private set ;
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
            
         #endregion
         
         #region Properties
         
            private SynchronizationContext __SyncContext
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
            void View_Load ( object sender, EventArgs e )
            {
               View.LoadConfiguration ( AddInsSession.AddInConfiguration, 
                                        new MediaProfiles [] { MediaProfiles.GeneralPurposeCDInterchange, 
                                                               MediaProfiles.GeneralPurposeDVDInterchange } ) ;
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
            
            void View_ViewConfigurationChanged(object sender, EventArgs e)
            {
               AddInsSession.OnAddInsConfigurationChanged  ( ) ;
            }

            void AddInsSession_AddInsConfigurationChanged ( )
            {
               __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) {
                  View.NotifyViewConfigurationChanged ( ) ;
               } ), null ) ;
            }
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}
