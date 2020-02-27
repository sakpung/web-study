// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Medical.Workstation.UI;
using Leadtools.Medical.Workstation.Interfaces;
using Leadtools.Medical.Workstation;
using Leadtools.Medical3D ;

namespace Leadtools.Demos.Workstation.Customized
{
   class Custom3DToolbar : ToolStrip
   {
      public Custom3DToolbar ( ) 
      {
         Items.Add ( new DesignToolStripButton ( ToolStripMenuProperties.Instance.Create3DVolumeToolStripButton ) ) ;
         Items.Add ( new DesignToolStripButton ( ToolStripMenuProperties.Instance.SingleCutPlaneToolStripMenuItem ) ) ;
         Items.Add ( new DesignToolStripButton ( ToolStripMenuProperties.Instance.DoubleCutPlaneToolStripMenuItem ) ) ;
         Items.Add ( new DesignToolStripButton ( ToolStripMenuProperties.Instance.Rotate3DToolStripButton ) ) ;
         
         Object3DTypeToolStripSplitButton = new CustomToolStripSplitButton ( ToolStripMenuProperties.Instance.Object3DTypeToolStripSplitButton ) ;
         MPRToolStripMenuItem             = new CustomToolStripMenuItem ( ToolStripMenuProperties.Instance.MPRToolStripMenuItem ) ;
         MIPToolStripMenuItem             = new CustomToolStripMenuItem ( ToolStripMenuProperties.Instance.MIPToolStripMenuItem ) ;
         MinMIPToolStripMenuItem          = new CustomToolStripMenuItem ( ToolStripMenuProperties.Instance.MinMIPToolStripMenuItem ) ;
         SSDToolStripMenuItem             = new CustomToolStripMenuItem ( ToolStripMenuProperties.Instance.SSDToolStripMenuItem ) ;
         VRTToolStripMenuItem             = new CustomToolStripMenuItem ( ToolStripMenuProperties.Instance.VRTToolStripMenuItem ) ;
         
         Object3DTypeToolStripSplitButton.DropDownItems.AddRange ( new ToolStripItem[] { MPRToolStripMenuItem,
                                                                                         MIPToolStripMenuItem,
                                                                                         MinMIPToolStripMenuItem,
                                                                                         SSDToolStripMenuItem,
                                                                                         VRTToolStripMenuItem } ) ;
      
         Items.Add ( Object3DTypeToolStripSplitButton ) ;
      }
      
      public void SyncronizeToolbar ( WorkstationState state ) 
      {
         __State = state ;
         
         SetCurrentVolumeType ( state ) ;
         
         __State.SelectedVolumeTypeChanged += new EventHandler ( __State_SelectedVolumeTypeChanged ) ;
         __State.ActiveCellChanged         += new EventHandler ( __State_ActiveCellChanged ) ;
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
         
         ToolStripController.UpdateMenuItemsState ( ) ;
         ToolStripController.UpdateTopLevelItemsState ( this ) ;
      }
      
      public void UnregisterFeatures ( )
      {
         if ( null == ToolStripController )
         {
            return ;
         }
         
         ToolStripController.UnregisterToolStripMenuItemFeatures ( this ) ;
      }
      
      public IWorkstationStripItemFeatureExecuter ToolStripController
      {
         get ;
         private set ;
      }
      
      void __State_SelectedVolumeTypeChanged ( object sender, EventArgs e )
      {
         try
         {
            SetCurrentVolumeType ( __State ) ;
         }
         catch ( Exception ex ) 
         {
            Messager.ShowError ( this, ex ) ;
         }
      }
      
      void __State_ActiveCellChanged ( object sender, EventArgs e )
      {
         try
         {
            if ( null != ToolStripController )
            {
               ToolStripController.UpdateTopLevelItemsState ( this ) ;
            }
         }
         catch ( Exception ex ) 
         {
            System.Diagnostics.Debug.Assert ( false, ex.Message ) ;
         }
      }
      
      private void SetCurrentVolumeType ( WorkstationState state )
      {
         switch ( state.SelectedVolumeType )
         {
            case Leadtools.Medical3D.Medical3DVolumeType.MINIP:
            {
               Object3DTypeToolStripSplitButton.SetCurrentItem ( MinMIPToolStripMenuItem ) ;
            }
            break ;
            
            case Leadtools.Medical3D.Medical3DVolumeType.MIP:
            {
               Object3DTypeToolStripSplitButton.SetCurrentItem ( MIPToolStripMenuItem ) ;
            }
            break ;
            
            case Leadtools.Medical3D.Medical3DVolumeType.MPR:
            {
               Object3DTypeToolStripSplitButton.SetCurrentItem ( MPRToolStripMenuItem ) ;
            }
            break ;
            
            case Leadtools.Medical3D.Medical3DVolumeType.SSD:
            {
               Object3DTypeToolStripSplitButton.SetCurrentItem ( SSDToolStripMenuItem ) ;
            }
            break ;
            
            case Leadtools.Medical3D.Medical3DVolumeType.VRT:
            {
               Object3DTypeToolStripSplitButton.SetCurrentItem ( VRTToolStripMenuItem ) ;
            }
            break ;
         }
      }
      
      private WorkstationState __State
      {
         get ;
         set ;
      }
      
      private CustomToolStripSplitButton Object3DTypeToolStripSplitButton;
      private CustomToolStripMenuItem MPRToolStripMenuItem;
      private CustomToolStripMenuItem MIPToolStripMenuItem;
      private CustomToolStripMenuItem MinMIPToolStripMenuItem;
      private CustomToolStripMenuItem SSDToolStripMenuItem;
      private CustomToolStripMenuItem VRTToolStripMenuItem;
   }
}
