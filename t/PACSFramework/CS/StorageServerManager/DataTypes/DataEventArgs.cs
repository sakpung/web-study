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
   public class DataEventArgs <T> : EventArgs
   {
      public DataEventArgs ( T data ) 
      {
         Data = data ;
      }

      public T Data
      {
         get ;
         private set ;
      }
   }
}
