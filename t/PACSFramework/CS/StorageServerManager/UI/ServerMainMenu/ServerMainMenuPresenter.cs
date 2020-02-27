// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Medical.Winforms;

namespace Leadtools.Demos.StorageServer.UI
{
   public class ServerMainMenuPresenter
   {
      #region Public
         
         #region Methods
         
            public ServerMainMenuPresenter ( ) 
            {}

            public void RunView ( ServerMainMenu view ) 
            {
               view.ExitApplication += new EventHandler ( view_ExitApplication ) ;
               view.ShowSettings    += new EventHandler ( view_ShowSettings ) ;
               view.ShowAbout       += new EventHandler ( view_ShowAbout ) ;
            }
         
         #endregion
         
         #region Properties
            
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
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
         
            void view_ShowSettings ( object sender, EventArgs e )
            {
               EventBroker.Instance.PublishEvent <DisplayFeatureEventArgs> ( this, new DisplayFeatureEventArgs ( FeatureNames.DisplaySettingsFeature ) ) ;
            }

            void view_ShowAbout(object sender, EventArgs e)
            {
               MessageBox.Show ( "About" ) ;
            }

            void view_ExitApplication ( object sender, EventArgs e )
            {
               Application.Exit ( ) ;
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
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}
