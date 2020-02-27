// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scp.Media;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.Medical.Media.AddIns.MediaBurningProcessor
{
   class MediaItemFailureEventArgs : MediaItemEventArgs
   {
      public MediaItemFailureEventArgs ( MediaCreationManagement mediaObject, ExecutionStatusInfo errorInfo )
      : base ( mediaObject )
      {
         ErrorInfo = errorInfo ;
      }
      
      public ExecutionStatusInfo ErrorInfo
      {
         get ;
         private set ;
      }
   }
}
