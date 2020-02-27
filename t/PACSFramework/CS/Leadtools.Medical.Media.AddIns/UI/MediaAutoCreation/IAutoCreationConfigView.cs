// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Media.AddIns.UI
{
   public interface IAutoCreationConfigView
   {
      void LoadConfiguration ( MediaAutoCreationConfiguration configuration ) ;
      void OnChangesSaved ( ) ;
      void NotifyViewConfigurationChanged ( ) ;
      
      event EventHandler Load ;
      event EventHandler SaveConfiguration ;
      event EventHandler ViewConfigurationChanged ;
   }
}
