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
   public class DeletingDicomFilesEventArgs : ConfirmActionEventArgs
   {
      public DeletingDicomFilesEventArgs ( string reason ) 
      : base ( reason ) 
      {
         
      }
   }
   
   public class EmptyDatabaseEventArgs : ConfirmActionEventArgs
   {
      public EmptyDatabaseEventArgs ( string reason ) 
      : base ( reason ) 
      {
         
      }
   }

   public class CleanForwardedDatasetsEventArgs : ConfirmActionEventArgs
   {
      public CleanForwardedDatasetsEventArgs ( string reason, long cleanCount ) 
      : base ( reason ) 
      {
         CleanCount = cleanCount;
      }

      public long CleanCount { get ; private set ; }
   }
}
