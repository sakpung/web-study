// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Dicom.Scp.Media;

namespace Leadtools.Medical.Media.AddIns.MediaBurningProcessor
{
   interface IMediaBurningProcessor : IDisposable
   {
      void ProcessMedia ( MediaCreationManagement mediaObject, MediaAutoCreationConfiguration configuration ) ;
      
      event EventHandler <MediaItemEventArgs>        MediaBurningCompleted ;
      event EventHandler <MediaItemFailureEventArgs> MediaBurningFailed ;
   }
}
