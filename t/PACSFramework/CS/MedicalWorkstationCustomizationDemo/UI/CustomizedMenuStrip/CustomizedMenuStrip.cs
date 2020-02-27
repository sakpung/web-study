// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Medical.Workstation.Interfaces;
using Leadtools.Medical.Workstation.UI;

namespace Leadtools.Demos.Workstation.Customized
{
   class ExamplesMenuStrip : MenuStrip
   {
      #region Public
         
         #region Methods
         
            public ExamplesMenuStrip ( ) 
            {
            }
            
            public void RegisterFeatures ( IWorkstationStripItemFeatureExecuter toolStripExecuter )
            {
               if ( null == toolStripExecuter ) 
               {
                  throw new ArgumentNullException ( ) ;
               }
               
               if ( ToolStripController != null ) 
               {
                  UnregisterFeatures ( ) ;
               }
               
               ToolStripController = toolStripExecuter ;
               
               ToolStripController.RegisterToolStripMenuItemFeatures ( this ) ;
            }
            
            public void UnregisterFeatures ( )
            {
               if ( null == ToolStripController )
               {
                  return ;
               }
               
               ToolStripController.UnregisterToolStripMenuItemFeatures ( this ) ;
            }
         
         #endregion
         
         #region Properties
         
            public IWorkstationStripItemFeatureExecuter ToolStripController
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
            
         #endregion
         
         #region Events
            
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
