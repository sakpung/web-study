// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using Leadtools.Dicom.AddIn.Common;

namespace Leadtools.DataAccessLayers
{
   public interface IClientOptionsDataAccessAgent
   {
      Dictionary<string, string> GetDefaultOptions();
      Dictionary<string, string> GetClientOptions(string userName);
      void SetClientOptions(string userName, Dictionary<string, string> options);
   }
}
