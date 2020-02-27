using System.Collections.Generic;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{
   public interface IOptionsHandler
   {
      Dictionary<string, string> GetUserOptions(string authenticationCookie);
      Dictionary<string, string> GetDefaultOptions(string authenticationCookie);
      void SaveUserOption(string authenticationCookie, string optionName, string optionValue);
      void SaveUserOption(string authenticationCookie, Dictionary<string, string> options);
      void DeleteUserOption(string authenticationCookie, string userName);
      void SaveDefaultOptions(string authenticationCookie, Dictionary<string, string> options);
      string GetRoleOption(string authenticationCookie, string role, string optionName);
      void SaveRoleOptions(string authenticationCookie, string role, Dictionary<string, string> options);
      string GetDefaultOption(string authenticationCookie, string optionName);
   }
}
