// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Media.AddIns.Commands
{
   abstract class MediaCommand : ICommand
   {
      public MediaCommand ( MediaObjectsStateService mediaService )
      {
         MediaService = mediaService ;
      }
      
      public MediaObjectsStateService MediaService
      {
         get ;
         private set ;
      }
      
      public abstract void Execute ( ) ;
   }
}
