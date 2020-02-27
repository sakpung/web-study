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
using Leadtools.Medical.Workstation.UI;
using Leadtools.Medical.Workstation.Loader;

namespace Leadtools.Demos.Workstation.Customized
{
   class ChangeWorkstationLanguageCommand : WorkstationCommand
   {
      public ChangeWorkstationLanguageCommand 
      ( 
         string featureId, 
         WorkstationContainer container,
         WorkstationLanguageResources language
      ) 
      : base ( featureId, container ) 
      {
         Language = language ;
      }

      protected override void DoExecute ( )
      {
         Language.MessagesStream.Position = 0 ;
         Language.ToolBarStream.Position = 0 ;
         Language.LoaderSteeam.Position = 0 ;
         Language.ActionsNameStream.Position = 0 ;
         
         WorkstationMessages.LoadMessages ( Language.MessagesStream ) ;
         ToolStripMenuProperties.LoadStrings ( Language.ToolBarStream ) ;
         LoaderStatusMessage.Load ( Language.LoaderSteeam ) ;
         Container.State.SetMouseButtonActionDisplayNameStream ( Language.ActionsNameStream ) ;
      }

      protected override bool DoCanExecute()
      {
         return null != Language ;
      }
      
      public WorkstationLanguageResources Language
      {
         get ;
         private set ;
      }
   }
}
