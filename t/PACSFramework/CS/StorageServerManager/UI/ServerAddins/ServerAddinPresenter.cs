// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Server.Admin;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Demos.StorageServer.DataTypes;

namespace Leadtools.Demos.StorageServer.UI
{
   class ServerAddinPresenter
   {
      #region Public
         
         #region Methods
         
            public ServerAddinPresenter ( ) 
            {}

            public void RunView ( ServerAddinsView view ) 
            {
               View    = view ;

               SetViewAddins ( ) ;

               ServerState.Instance.ServerServiceChanged += new EventHandler ( Instance_ServerServiceChanged ) ;

               view.AddInClicked += new EventHandler<DataEventArgs<IAddInOptions>> ( view_AddInClicked ) ;
            }
         
         #endregion
         
         #region Properties
         
            public ServerAddinsView View { get; set; }
            
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
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
            static ServerAddinPresenter ( ) 
            {
               _ignoreAddins = new List<string> ( ) ;
               
               _ignoreAddins.Add ( "Auto Copy" ) ;
               _ignoreAddins.Add ( "Forwarder" ) ;
               _ignoreAddins.Add ( "Patient Updater" ) ;
               _ignoreAddins.Add ( "Query/Retrieve, Store Configuration" ) ;
            }
            
            private void SetViewAddins ( )
            {
               if ( ServerState.Instance.ServerService != null )
               {
                  bool found = false ;
                  
                  foreach ( IAddInOptions addin in ServerState.Instance.ServerService.AddInOptions )
                  {
                     if ( _ignoreAddins.Contains ( addin.Text ) )
                     {
                        continue ;
                     }
                     
                     View.SetAddin ( addin ) ;
                     
                     found = true ;
                  }
                  
                  if ( !found ) 
                  {
                     View.DisplayStaticNote ( "No Add-ons found." ) ;
                  }
                  else
                  {
                     View.HideStaticNote ( ) ;
                  }
               }
               else
               {
                  View.ClearAddins ( ) ;
                  
                  View.HideStaticNote ( ) ;
               }
            }
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
         
            void Instance_ServerServiceChanged ( object sender, EventArgs e )
            {
               SetViewAddins ( ) ;
            }
            
            void view_AddInClicked(object sender, DataEventArgs<IAddInOptions> e)
            {
               e.Data.Configure ( View, ServerState.Instance.ServerService.Settings, ServerState.Instance.ServerService.ServiceDirectory ) ;
            }
         
         #endregion
         
         #region Data Members
         
            private static List<string> _ignoreAddins ;
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}
