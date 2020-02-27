// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   public interface IOptionsAddin
   {
      Dictionary<string, string> GetUserOptions(string userName);
      Dictionary<string, string> GetDefaultOptions();
      void SetUserOptions(string userName, Dictionary<string, string> options);
      void SaveUserOption(string userName, string optionName, string optionValue);
      void SaveUserOption(string userName, Dictionary<string, string> options);
      void DeleteUserOption(string userName);
      void SaveDefaultOptions(string authUser, Dictionary<string, string> options);

      string GetRoleOption(string role, string optionName);
      void SaveRoleOptions(string role, Dictionary<string, string> options);
      string GetDefaultOption(string optionName);
   }
}