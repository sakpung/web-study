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
   public interface IMediaJobMaintenanceView
   {
      void LoadMaintenanceConfiguration ( MediaMaintenanceState config ) ;
      void OnChangesSaved ( ) ;
      void NotifyViewConfigurationChanged ( ) ;
      
      event EventHandler Load ;
      event EventHandler SaveChanges ; 
      event EventHandler ViewConfigurationChanged ;
      
      
      
   }
}
