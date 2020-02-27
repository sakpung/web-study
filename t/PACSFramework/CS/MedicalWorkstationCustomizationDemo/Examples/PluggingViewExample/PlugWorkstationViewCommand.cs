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
using Leadtools.Medical.Workstation.Interfaces.Views;
using Leadtools.Medical.Workstation.UI.Factory;

namespace Leadtools.Demos.Workstation.Customized
{
   class PlugWorkstationViewCommand <V,T>: WorkstationCommand where V : IWorkstationView
   {
      public PlugWorkstationViewCommand ( string featureId, WorkstationContainer container ) 
      : base ( featureId, container )
      {
         
      }
      
      protected override bool DoCanExecute()
      {
         return true ;
      }

      protected override void DoExecute()
      {
         WorkstationUIFactory.Instance.RegisterWorkstationView <V> ( typeof ( T) ) ;
      }
   }
}
