// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Interfaces;

namespace Leadtools.Medical.Logging.Addins
{
   public class SessionShutdown : NotifyReceiveMessageBase, IProcessBreak
   {
      public void Break ( BreakType type )
      {
         if ( type == BreakType.Shutdown ) 
         {
            if ( ServiceLocator.IsRegistered <CommandAsyncProcessor> ( ) )
            {
               CommandAsyncProcessor  processor = ServiceLocator.Retrieve <CommandAsyncProcessor> ( ) ;
               
               if ( processor != null ) 
               {
                  processor.Stop ( ) ;
                  
                  processor.Dispose ( ) ;
               }
            }
         }
      }
   }
}
