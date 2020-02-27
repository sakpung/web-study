// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Media.AddIns
{
   public class MediaServicesState
   {
      public bool AutoCreationServiceEnabled
      {
         get 
         {
            return _autoCreationServiceEnabled ;
         }
         
         set 
         {
            if ( value != _autoCreationServiceEnabled ) 
            {
               _autoCreationServiceEnabled = value ;
               
               if ( AutoCreationServiceStateChanged != null ) 
               {
                  AutoCreationServiceStateChanged ( this, EventArgs.Empty ) ;
               }
            }
         }
      }
      
      public bool MediaMaintenanceServiceEnabled
      {
         get 
         {
            return _mediaMaintenanceServiceEnabled ;
         }
         
         set 
         {
            if ( value != _mediaMaintenanceServiceEnabled ) 
            {
               _mediaMaintenanceServiceEnabled = value ;
               
               if ( null != MediaMaintenanceServiceStateChanged ) 
               {
                  MediaMaintenanceServiceStateChanged ( this, EventArgs.Empty ) ;
               }
            }
         }
      }
      
      public event EventHandler AutoCreationServiceStateChanged ;
      public event EventHandler MediaMaintenanceServiceStateChanged ;
      
      private bool _autoCreationServiceEnabled ;
      private bool _mediaMaintenanceServiceEnabled ;
   }
}
