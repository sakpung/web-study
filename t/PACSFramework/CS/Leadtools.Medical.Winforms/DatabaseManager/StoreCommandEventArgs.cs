// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scp.Command;

namespace Leadtools.Medical.Winforms
{
   public class StoreCommandEventArgs : EventArgs
   {
      public StoreCommandEventArgs ( InstanceCStoreCommand command )
      {
         Command = command ;
      }
      
      public InstanceCStoreCommand Command
      {
         get
         {
            return _command ;
         }
         
         private set
         {
            _command = value ;
         }
      }
      
      private InstanceCStoreCommand _command ;
   }
}
