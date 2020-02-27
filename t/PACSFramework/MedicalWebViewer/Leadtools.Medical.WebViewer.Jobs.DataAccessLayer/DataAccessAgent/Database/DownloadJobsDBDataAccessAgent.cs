// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Leadtools.Medical.WebViewer.Jobs.DataAccessLayer
{
   public class DownloadJobsDbDataAccessAgent : DownloadJobsDataAccessAgent
   {
      public DownloadJobsDbDataAccessAgent(string connectionString)
         : base(connectionString)
      {

      }

      protected override Database CreateDatabaseProvider()
      {
         return new SqlDatabase(DBConnectionString);
      }
   }
}
