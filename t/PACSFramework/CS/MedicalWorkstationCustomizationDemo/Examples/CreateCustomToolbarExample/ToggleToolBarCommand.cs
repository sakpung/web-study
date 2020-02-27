// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Workstation.Commands;
using System.Windows.Forms;
using Leadtools.Medical.Workstation;

namespace Leadtools.Demos.Workstation.Customized
{
   class ToggleToolBarCommand : WorkstationCommand
   {
      public ToggleToolBarCommand
      ( 
         string featureId, 
         WorkstationContainer container,
         Custom3DToolbar toolbar3D
      ) 
      : base ( featureId, container ) 
      {
         CustomToolStrip = toolbar3D ;
      }

      protected override void DoExecute ( )
      {
         if ( CustomToolStrip.Parent == null ) 
         {
            Container.State.ActiveWorkstation.Controls.Add ( CustomToolStrip ) ;
            
            CustomToolStrip.RegisterFeatures ( Container.StripItemFeatureExecuter ) ;
         }
         else
         {
            CustomToolStrip.Parent.Controls.Remove ( CustomToolStrip ) ;
            
            CustomToolStrip.UnregisterFeatures ( ) ;
         }
      }

      protected override bool DoCanExecute()
      {
         return null != CustomToolStrip ;
      }
      
      public Custom3DToolbar CustomToolStrip
      {
         get ;
         private set ;
      }
   }
}
