// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms.EventBrokerArgs
{
   public class FileInformationEventArgs : EventArgs
   {
      public FileInformationEventArgs ( string filePath ) 
      {
         FilePath = filePath ;
      }
   
      public string FilePath { get ; private set ; }
   }
   
   
}
