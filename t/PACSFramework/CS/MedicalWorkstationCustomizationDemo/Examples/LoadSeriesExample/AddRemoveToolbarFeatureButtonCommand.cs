// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Workstation.Commands;
using Leadtools.Medical.Workstation;
using System.Windows.Forms;
using Leadtools.Medical.Workstation.UI;

namespace Leadtools.Demos.Workstation.Customized
{
   class AddRemoveToolbarFeatureItemCommand : WorkstationCommand
   {
      public AddRemoveToolbarFeatureItemCommand ( string featureId, WorkstationContainer container, ToolStripItem item )
      : base ( featureId, container )
      {
         Item = item ;
      }

      protected override bool DoCanExecute()
      {
         return ( Item is IToolStripItemItemProperties ) ;
      }

      protected override void DoExecute()
      {
         if ( Item.Owner == null )
         {
            Container.State.ActiveWorkstation.ViewerToolbar.Items.Insert ( 0, Item ) ;
         
            Container.StripItemFeatureExecuter.SetItemFeature ( Item, ( ( IToolStripItemItemProperties ) Item ).ItemProperties.FeatureId ) ;
         }
         else
         {
            Container.State.ActiveWorkstation.ViewerToolbar.Items.Remove ( Item ) ;
         
            Container.StripItemFeatureExecuter.RemoveItemFeature ( Item ) ;
         }
      }
      
      public ToolStripItem Item
      {
         get;
         private set ;
      }
   }
}
