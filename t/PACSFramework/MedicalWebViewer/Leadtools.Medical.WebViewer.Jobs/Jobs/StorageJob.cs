// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;

using System.Text;
using Leadtools;
using System.Net;
using System.Runtime.Serialization;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.WebViewer.PatientAccessRights;

namespace Leadtools.Medical.WebViewer.Jobs
{
   [Serializable]
   public class StorageJob : Job
   {
      protected StorageJob()
      {
         DataAccessAgent = null;
         AuthorizedDataAccessAgent = null;
      }
      public IAuthorizedStorageDataAccessAgent AuthorizedDataAccessAgent { get; set; }
      public IStorageDataAccessAgent DataAccessAgent { get; set; }

      public override void Dispose(bool bUnmanaged)
      {
         base.Dispose();
      }

   }
}
