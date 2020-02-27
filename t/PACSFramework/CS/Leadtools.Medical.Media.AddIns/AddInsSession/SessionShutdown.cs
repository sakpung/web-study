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
using Leadtools.Dicom.AddIn.Configuration;

namespace Leadtools.Medical.Media.AddIns
{
   public class SessionShutdown : NotifyReceiveMessageBase, IProcessBreak
   {
      public void Break ( BreakType type )
      {
         if ( type == BreakType.Shutdown ) 
         {
            if ( ServiceLocator.IsRegistered <CommandAsyncProcessor> ( ) )
            {
               foreach ( CommandAsyncProcessor  processor in ServiceLocator.RetrieveAll <CommandAsyncProcessor> ( ) )
               {
                  if ( processor != null ) 
                  {
                     processor.Stop ( ) ;
                     
                     processor.Dispose ( ) ;
                  }
               }
            }
            
            if ( ServiceLocator.IsRegistered <SettingsChangedNotifier> ( ) )
            {
               using ( SettingsChangedNotifier configChangedNotifier = ServiceLocator.Retrieve <SettingsChangedNotifier> ( ) )
               {
                  configChangedNotifier.Enabled = false ;
               }
            }
         }
      }
   }
}
