// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scp.Command.Configuration;
using Leadtools.Dicom.Scp.Command;

namespace Leadtools.Medical.Media.AddIns
{
   class MediaNCreateCommandInitializationService : IInitializationService
   {
      #region IInitializationService Members

      public void ConfigureCommand ( DicomCommand command )
      {
         if ( command is MediaNCreateCommand )
         {
            MediaNCreateCommand mediaCreateCommand ;
            
            
            mediaCreateCommand = ( MediaNCreateCommand ) command ;
            
            mediaCreateCommand.DefaultMediaProfile = AddInsSession.AddInConfiguration.DefaultProfile ;
         }
      }

      #endregion
   }
}
