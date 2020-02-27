// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Demos.StorageServer.DataTypes
{
   public class DisplayFeatureEventArgs : EventArgs
   {
      public DisplayFeatureEventArgs ( FeatureNames feature ) 
      {
         Feature = feature ;
      }

      public FeatureNames Feature
      {
         get ;
         private set ;
      }
   }
}
