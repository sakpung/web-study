// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Media.AddIns.Composing;

namespace Leadtools.Medical.Media.AddIns
{
   public interface IMediaConfigurationView
   {
      void LoadConfiguration ( MediaAddInConfiguration configuration, 
                               MediaProfiles[] profiles  ) ;
      
      void OnChangesSaved ( ) ;
      void NotifyViewConfigurationChanged ( ) ;
      void TearDown ( ) ;

      event EventHandler Load ;
      event EventHandler SaveChanges ;
      event EventHandler ViewConfigurationChanged ;
   }
}
