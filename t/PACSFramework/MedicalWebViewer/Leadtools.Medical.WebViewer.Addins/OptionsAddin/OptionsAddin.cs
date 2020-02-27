// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.DataAccessLayers;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.Logging.DataAccessLayer;

namespace Leadtools.Medical.WebViewer.Addins
{
   public class OptionsAddin : IOptionsAddin
   {
       IOptionsDataAccessAgent DataAccess { get; set; }
       ILoggingDataAccessAgent LoggingDataAccess { get; set; }

       public OptionsAddin(IOptionsDataAccessAgent dataAccess, ILoggingDataAccessAgent loggingAccess)
      {
         DataAccess = dataAccess;
           LoggingDataAccess = loggingAccess;
      }

      #region IClientOptionsAddin Members

      public Dictionary<string, string> GetUserOptions(string userName)
      {
         return DataAccess.GetUserOptions(userName);
      }

      public Dictionary<string, string> GetDefaultOptions()
      {
          return DataAccess.GetDefaultOptions();
      }
      public string GetDefaultOption(string optionName)
      {
         return DataAccess.Get<string>(optionName,string.Empty);
      }
      public void SetUserOptions(string userName, Dictionary<string, string> options)
      {
         DataAccess.SetUserOptions(userName, options);
      }

      public void SaveUserOption(string userName, string optionName, string optionValue)
      {
          var option = new Dictionary<string, string>();

          option[optionName] = optionValue;
          DataAccess.SetUserOptions(userName, option);
      }
      public void DeleteUserOption(string userName)
      {
         DataAccess.DeleteUserOptions(userName);
      }
      public void SaveUserOption(string userName, Dictionary<string, string> options)
      {
         DataAccess.SetUserOptions(userName, options);
      }

      public void SaveDefaultOptions(string authUser, Dictionary<string, string> options)
      {          
          DataAccess.SaveDefaultOptions(options);
          LoggingDataAccess.OptionsChanged(DataAccess, authUser, options);
      }

      public string GetRoleOption(string role, string optionName)
       {
          return DataAccess.GetRoleOption(role, optionName);
       }

       public void SaveRoleOptions(string role, Dictionary<string, string> options)
       {
           DataAccess.SaveRoleOptions(role, options);
       }

       #endregion
   }

    public static class OptionsLogger
    {
        public static void OptionsChanged(this ILoggingDataAccessAgent logger, IOptionsDataAccessAgent DataAccess, string authUser, Dictionary<string, string> options)
        {
            string details = "Options Changed: \n\n" + string.Join("\n", options.Select(x => x.Key + ": " + x.Value).ToArray());

            AuthenticationLogger.OptionsAgent = DataAccess;
            AuthenticationLogger.LogSettingChanges(logger, authUser, details);
        }
    }
}
