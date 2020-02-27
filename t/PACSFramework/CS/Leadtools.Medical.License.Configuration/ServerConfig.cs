// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn;
using Leadtools.Medical.DataAccessLayer;
using System.Diagnostics;
using Leadtools.Logging;

namespace Leadtools.Medical.License.Configuration
{
   public class ServerConfig : IServerConfig
   {
      private ServerLicense _ServerLicense;

      #region IServerConfig Members

      public void Configure(DicomServer server)
      {
         _ServerLicense = new ServerLicense(server);
         if (_ServerLicense != null)
         {
            _ServerLicense.Initialize();
            ServiceLocator.Register<ILicense>(_ServerLicense);
         }
      }

      #endregion
   }
}
