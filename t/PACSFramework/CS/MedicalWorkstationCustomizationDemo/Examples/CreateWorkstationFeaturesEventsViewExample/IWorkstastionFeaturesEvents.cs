// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Workstation.Interfaces.Views;

namespace Leadtools.Demos.Workstation.Customized
{
   interface IWorkstastionFeaturesEventsView : IWorkstationView
   {
      void AddFeatureEvent ( string featureId, object publisher ) ;
      
      event EventHandler StartListeningToeEvents ;
      event EventHandler StopListeningToeEvents ;
      
      bool CanStop
      {
         get ;
         set ;
      }
      
      bool CanStart
      {
         get ;
         set ;
      }
   }
}
