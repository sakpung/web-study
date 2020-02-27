// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Leadtools.Medical.WebViewer.ServiceContracts;
using System.Xml;
using System.ServiceModel.Activation;
using System.Web.Services;
using Leadtools.Medical.WebViewer.Wcf.Helper;

namespace Leadtools.Medical.WebViewer.Wcf
{    
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [WebService(Namespace = "http://leadtools.com/")]
    public class OptionsService : IOptionsService
    {
        IOptionsAddin _optionsAddin = null;
        
        public OptionsService()
        {
           _optionsAddin = AddinsFactory.CreateOptionsAddin();
        }

      public Dictionary<string, string> GetUserOptions(string authenticationCookie)
      {
         if (string.IsNullOrEmpty(authenticationCookie))
         {
            return new Dictionary<string, string>();
         }
         string userName;

         userName = ServiceUtils.Authorize(authenticationCookie, null);

         return _optionsAddin.GetUserOptions(userName);
      }

      public Dictionary<string, string> GetDefaultOptions(string authenticationCookie)
        {
           ServiceUtils.Authorize(authenticationCookie, null);
            return _optionsAddin.GetDefaultOptions();
        }

        public void SaveUserOption(string authenticationCookie, string optionName, string optionValue)
        {
            string userName;
            
            userName = ServiceUtils.Authorize(authenticationCookie, null);
            _optionsAddin.SaveUserOption(userName, optionName, optionValue);            
        }

        public void SaveDefaultOptions(string authenticationCookie, Dictionary<string, string> options)
        {
            string userName;

            userName = ServiceUtils.Authorize(authenticationCookie, null);
            _optionsAddin.SaveDefaultOptions(userName, options);
        }

        public string GetRoleOption(string authenticationCookie, string role, string optionName)
        {
            string userName;

            userName = ServiceUtils.Authorize(authenticationCookie, null);
            return _optionsAddin.GetRoleOption(role, optionName);
        }

        public void SaveRoleOptions(string authenticationCookie, string role, Dictionary<string, string> options)
        {
            string userName;

            userName = ServiceUtils.Authorize(authenticationCookie, null);
            _optionsAddin.SaveRoleOptions(role, options);
        }
    }
}
