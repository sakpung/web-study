using System.Collections.Generic;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.ServiceContracts;
using System.Linq;
using System.Configuration;
using Leadtools.Medical.WebViewer.Common;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   
   public class OptionsHandler : IOptionsHandler
   {
      IOptionsAddin _optionsAddin = null;

      public OptionsHandler(AddinsFactory factory)
      {
         _optionsAddin = factory.CreateOptionsAddin();

      }

      public void SetExposedWebConfigOptions(Dictionary<string, string> options)
      {
         try
         {
            if (options.ContainsKey("EnableCaching"))
            {
               if(ApplicationSettings.UpdateSettingValue("Caching.Enabled", options["EnableCaching"]))
               {
                  //refresh caching
                  LTCachingCtrl.Refresh();
               }
            }
         }
         catch { }
      }

      public Dictionary<string, string> GetExposedWebConfigOptions()
      {
         try
         {
            bool cacheSettingsEnabled = false;
            bool.TryParse(ConfigurationManager.AppSettings.Get("Caching.Enabled"), out cacheSettingsEnabled);

            return new Dictionary<string, string>() { { "EnableCaching", cacheSettingsEnabled.ToString() } };
         }
         catch
         {
            return null;
         }
      }

      private static Dictionary<string, string> Merge(Dictionary<string, string> to, Dictionary<string, string> from)
      {
         if (null != from)
         {
            from.ToList().ForEach(x => { if(to.ContainsKey(x.Key)) to.Remove(x.Key); to.Add(x.Key, x.Value); });
         }
         
         return to;
      }
      public Dictionary<string, string> GetUserOptions(string authenticationCookie)
      {
         if (!string.IsNullOrEmpty(authenticationCookie))
         {
            string userName;

            userName = AuthHandler.Authorize(authenticationCookie, null);

            return Merge(_optionsAddin.GetUserOptions(userName), GetExposedWebConfigOptions());
         }
         else
         {
            var options = _optionsAddin.GetDefaultOptions();
            options = options.Where(p => p.Key == "EnableOktaSignIn"|| p.Key == "EnableShibbolethSignIn").ToDictionary(p => p.Key, p => p.Value);
            return options;
         }
      }

      public Dictionary<string, string> GetDefaultOptions(string authenticationCookie)
      {
         AuthHandler.Authorize(authenticationCookie, null);
         return _optionsAddin.GetDefaultOptions();
      }

      public void SaveUserOption(string authenticationCookie, string optionName, string optionValue)
      {
         string userName;

         userName = AuthHandler.Authorize(authenticationCookie, null);
         _optionsAddin.SaveUserOption(userName, optionName, optionValue);
      }

      public void DeleteUserOption(string authenticationCookie, string userName)
      {
         AuthHandler.Authorize(authenticationCookie, null);
         _optionsAddin.DeleteUserOption(userName);
      }

      public void SaveUserOption(string authenticationCookie, Dictionary<string, string> options)
      {
         string userName;

         userName = AuthHandler.Authorize(authenticationCookie, null);
         _optionsAddin.SaveUserOption(userName, options);
         SetExposedWebConfigOptions(options);
      }
      public void SaveDefaultOptions(string authenticationCookie, Dictionary<string, string> options)
      {
         string userName;

         userName = AuthHandler.Authorize(authenticationCookie, null);
         _optionsAddin.SaveDefaultOptions(userName, options);
         SetExposedWebConfigOptions(options);
      }

      public string GetRoleOption(string authenticationCookie, string role, string optionName)
      {
         string userName;

         userName = AuthHandler.Authorize(authenticationCookie, null);
         return _optionsAddin.GetRoleOption(role, optionName);
      }

      public void SaveRoleOptions(string authenticationCookie, string role, Dictionary<string, string> options)
      {
         string userName;

         userName = AuthHandler.Authorize(authenticationCookie, null);
         _optionsAddin.SaveRoleOptions(role, options);
      }

      public string GetDefaultOption(string authenticationCookie, string optionName)
      {
         string userName;

         userName = AuthHandler.Authorize(authenticationCookie, null);

         return _optionsAddin.GetDefaultOption(optionName);
      }
   }
}
