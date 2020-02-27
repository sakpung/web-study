// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{

   public interface IAuditHandler
   {
      void Log(string authenticationCookie, string user, string workstation, DateTime date, string details, string userData);
   }
}
