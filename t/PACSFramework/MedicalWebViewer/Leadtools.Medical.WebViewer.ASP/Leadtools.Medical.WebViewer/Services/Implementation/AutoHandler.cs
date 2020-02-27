using System;
using System.Linq;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.Errors;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   public class AutoHandler : IAutoHandler, IDisposable
   {
      private IMessagesBus _bus = null;
      private Lazy<IOptionsHandler> _options;

      public AutoHandler(AddinsFactory factory, Lazy<IMessagesBus> bus, Lazy<IOptionsHandler> options)
      {
         _bus = bus.Value;
         _options = options;
      }

      private bool _disposed = false;
      ~AutoHandler()
      {
         if (!this._disposed)
         {
            this._disposed = true;
            Dispose();
         }
      }

      public void Dispose()
      {
         if (!this._disposed)
         {
            this._disposed = true;

            //DicomEngine.Shutdown();

            GC.SuppressFinalize(this);
         }
      }

      public string Automate(string authenticationCookie)
      {
         return authenticationCookie;//currently we use same auth cookie for auto token
      }

      public bool IsAutomated(string token)
      {
         return true;
      }
      
      private void VerifyIsAutomated(string token)
      {
         if(!IsAutomated(token))
         {
            throw new Exception("Invalid automation token specified.");
         }
      }

      //some commands require an environment setup (i.e toolbars, dental mode...etc)
      private void SetupCommandEnvironment(string token, string param)
      {
         var env = JsonConvert.DeserializeObject< Dictionary<string, string> > (param);
         var dict = new Dictionary<string, string>();
         if (env.ContainsKey("dentalMode"))
         {
            dict.Add("DentalMode", env["dentalMode"]);
         }
         if (env.ContainsKey("toolbars"))
         {
            if (env["toolbars"] == "mini")
            {
               dict.Add("Toolbar_embedded", Auto_Toolbars.Toolbar_embedded_mini);
               dict.Add("Toolbars", @"[""embedded""]");
            }
            else if (env["toolbars"] == "embedded")
            {
               dict.Add("Toolbar_embedded", Auto_Toolbars.Toolbar_embedded);
               dict.Add("Toolbars", @"[""embedded""]");
            }
         }
         if (dict.Keys.Count > 0)
         {
            _options.Value.SaveUserOption(token, dict);
         }
      }
      
      public async Task<string> QueueCommand(string token, string to, string name, string param)
      {
         VerifyIsAutomated(token);

         SetupCommandEnvironment(token, param);

         var id = Guid.NewGuid().ToString();
         var cmd = new Tuple<string, string, string>(id, name, param);

         await _bus.SendSingle(token, cmd);

         await SetCommandStatus(id, CmdTaskStatus.Queued, "");

         return id;
      }

      private async Task SetCommandStatus(string id, string status, string message)
      {
         await _bus.SetStatus(id, new Tuple<string, string>(status, message));
      }

      public async Task<Tuple<string, string>> GetCommandStatus(string token, string cmdId)
      {
         VerifyIsAutomated(token);

         var status = await _bus.GetStatus<Tuple<string, string>>(cmdId);
         
         if(status != null)
         {
            return status;
         }

         return new Tuple<string, string>(CmdTaskStatus.Unknown, "");
      }

      //id, cmd, param
      public async Task<List<Tuple<string, string, string>>> GetAndRemoveCommands(string token, string to)
      {
         VerifyIsAutomated(token);

         var obj = await _bus.GetMany<Tuple<string,string,string>>(token);

         if (null==obj)
         {
            obj = new List<Tuple<string, string, string>> ();
         }

         return obj;
      }

      public async Task ReportCommandStatus(string token, string cmdId, string status, string message)
      {
         VerifyIsAutomated(token);

         await SetCommandStatus(cmdId, status, message);
      }

      public void Logout(string token, string reason)
      {
         VerifyIsAutomated(token);

         throw new NotImplementedException();
      }

      static string DecryptStringFromBytes_Aes(string cipherText, byte[] Key, byte[] IV)
      {
         string result = null;
         using (var aesAlg = Aes.Create())
         {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
               using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
               {
                  using (var srDecrypt = new StreamReader(csDecrypt))
                  {
                     result = srDecrypt.ReadToEnd();
                  }
               }
            }
         }
         return result;
      }

      public JObject DecodeRequest(string token, string protocol)
      {
         var shared_key = ConfigurationManager.AppSettings.Get("UrlInterface.Key").ToString();
         var shared_key_salt = new byte[8] { 100, 19, 41, 255, 18, 30, 12, 86 };

         var json = "";
         switch (protocol)
         {
            case "plain":
               json = Uri.UnescapeDataString(token);
               break;
            case "base64":
               json = Encoding.ASCII.GetString(Convert.FromBase64String(token));
               break;
            case "aes128":            
               {
                  var keySize = 128;
                  var blockSize = 128;
                  using (var derived_key = new Rfc2898DeriveBytes(shared_key, shared_key_salt))
                  {
                     var aesKey = derived_key.GetBytes(keySize / 8);
                     var aesIV = derived_key.GetBytes(blockSize / 8);
                     json = DecryptStringFromBytes_Aes(token, aesKey, aesIV);
                  }
               }
               break;
            case "aes256":
               {
                  var keySize = 256;
                  var blockSize = 128;
                  using (var derived_key = new Rfc2898DeriveBytes(shared_key, shared_key_salt))
                  {
                     var aesKey = derived_key.GetBytes(keySize / 8);
                     var aesIV = derived_key.GetBytes(blockSize / 8);
                     json = DecryptStringFromBytes_Aes(token, aesKey, aesIV);
                  }
               }
               break;
            case "ltidp":
               {
                  var keySize = 128;
                  var blockSize = 128;
                  using (var derived_key = new Rfc2898DeriveBytes(shared_key, shared_key_salt))
                  {
                     var aesKey = derived_key.GetBytes(keySize / 8);
                     var aesIV = derived_key.GetBytes(blockSize / 8);
                     json = DecryptStringFromBytes_Aes(token, aesKey, aesIV);
                  }
               }
               break;
            default:
               throw new Exception("Not supported!");
         }

         if (!string.IsNullOrEmpty(json))
            return JsonConvert.DeserializeObject<JObject>(json);
         else
            return null;
      }
      public bool IsProtocolAllowed(string protocol)
      {
         if (!StrongProtocolOnly())
            return true;

         return protocol == "aes256" || protocol == "aes128" || protocol == "ltidp";
      }

      private static long GetUnixTimeSeconds()
      {
         long num = DateTime.UtcNow.Ticks / 10000000L;
         return num - 62135596800L;
      }

      public bool HasReqExpired(JObject req)
      {
         var created = long.Parse(req.GetValue("created").ToString());
         TimeSpan valid_timespan;
         if (!TimeSpan.TryParse(ConfigurationManager.AppSettings.Get("UrlInterface.Timeout"), out valid_timespan))
         {
            valid_timespan = TimeSpan.FromMinutes(1);
         }

         //0 means never expires
         if (0 == valid_timespan.TotalSeconds)
            return false;

         var now = GetUnixTimeSeconds();
         if ((created > now) || (now - created > valid_timespan.TotalSeconds))
         {
            return true;
         }
         return false;
      }

      public bool StrongProtocolOnly()
      {
         var strongProtocol = ConfigurationManager.AppSettings.Get("UrlInterface.StrongProtocol");
         var strong = true;
         if(bool.TryParse(strongProtocol, out strong))
            return strong;
         else
            return true;
      }
   }

   internal static class Auto_Toolbars
   {
      public static string Toolbar_embedded = @"{""name"": ""embedded"",
  ""items"": [
    {
      ""id"": ""Pan"",
      ""action"": ""Pan"",
      ""caption"": ""Pan"",
      ""tooltip"": ""Pan"",
      ""type"": ""button"",
      ""cssIconClass"": ""Pan"",
      ""items"": []
    },
    {
      ""id"": ""Zoom"",
      ""action"": ""ZoomToInteractiveMode"",
      ""caption"": ""Zoom"",
      ""tooltip"": ""Zoom"",
      ""type"": ""button"",
      ""cssIconClass"": ""Zoom"",
      ""items"": []
    },
    {
      ""id"": ""Magnify"",
      ""action"": ""InteractiveMagnifyGlass"",
      ""caption"": ""Magnify"",
      ""tooltip"": ""Magnify"",
      ""type"": ""button"",
      ""cssIconClass"": ""Magnify"",
      ""items"": []
    },
    {
      ""id"": ""Stack"",
      ""action"": ""InteractiveStack"",
      ""caption"": ""Stack"",
      ""tooltip"": ""Stack"",
      ""type"": ""button"",
      ""cssIconClass"": ""Stack"",
      ""items"": []
    },
    {
      ""id"": ""WindowLevel"",
      ""action"": ""WindowLevelInteractiveMode"",
      ""caption"": ""Window Level"",
      ""tooltip"": ""Window Level"",
      ""type"": ""button"",
      ""cssIconClass"": ""WindowLevel"",
      ""items"": []
    },
    {
      ""id"": ""FitImage"",
      ""action"": ""FitImage"",
      ""caption"": ""Fit"",
      ""tooltip"": ""Fit"",
      ""type"": ""button"",
      ""cssIconClass"": ""FitImage"",
      ""items"": []
    },
    {
      ""id"": ""OneToOne"",
      ""action"": ""OneToOne"",
      ""caption"": ""1 To 1"",
      ""tooltip"": ""One To One"",
      ""type"": ""button"",
      ""cssIconClass"": ""OneToOne"",
      ""items"": []
    },
    {
      ""id"": ""ZoomIn"",
      ""action"": ""ZoomIn"",
      ""caption"": ""Zoom In"",
      ""tooltip"": ""Zoom In"",
      ""type"": ""button"",
      ""cssIconClass"": ""ZoomIn"",
      ""items"": []
    },
    {
      ""id"": ""ZoomOut"",
      ""action"": ""ZoomOut"",
      ""caption"": ""Zoom Out"",
      ""tooltip"": ""Zoom Out"",
      ""type"": ""button"",
      ""cssIconClass"": ""ZoomOut"",
      ""items"": []
    },
    {
      ""id"": ""Orientation"",
      ""action"": ""RotateClockwise"",
      ""caption"": ""Rotate C"",
      ""tooltip"": ""Rotate Clockwise"",
      ""type"": ""button"",
      ""cssIconClass"": ""RotateClock"",
      ""items"": [
        {
          ""id"": ""RotateClockwise"",
          ""action"": ""RotateClockwise"",
          ""caption"": ""Rotate C"",
          ""tooltip"": ""Rotate Clockwise"",
          ""type"": ""button"",
          ""cssIconClass"": ""RotateClock"",
          ""items"": []
        },
        {
          ""id"": ""RotateCounterClock"",
          ""action"": ""RotateCounterclockwise"",
          ""caption"": ""Rotate CC"",
          ""tooltip"": ""Rotate Counterclockwise"",
          ""type"": ""button"",
          ""cssIconClass"": ""RotateCounterClock"",
          ""items"": []
        },
        {
          ""id"": ""Flip"",
          ""action"": ""Flip"",
          ""caption"": ""Flip"",
          ""tooltip"": ""Flip"",
          ""type"": ""button"",
          ""cssIconClass"": ""Flip"",
          ""items"": []
        },
        {
          ""id"": ""Reverse"",
          ""action"": ""Reverse"",
          ""caption"": ""Reverse"",
          ""tooltip"": ""Reverse"",
          ""type"": ""button"",
          ""cssIconClass"": ""Reverse"",
          ""items"": []
        }
      ]
    },
    {
      ""id"": ""Endo"",
      ""action"": ""OnToggleEndo"",
      ""caption"": ""Endo"",
      ""tooltip"": ""Toggle Endo"",
      ""type"": ""button"",
      ""cssIconClass"": ""Endo"",
      ""items"": []
    },
    {
      ""id"": ""Perio"",
      ""action"": ""OnTogglePerio"",
      ""caption"": ""Perio"",
      ""tooltip"": ""Toggle Perio"",
      ""type"": ""button"",
      ""cssIconClass"": ""Perio"",
      ""items"": []
    },
    {
      ""id"": ""Dentin"",
      ""action"": ""OnToggleDentin"",
      ""caption"": ""Dentin"",
      ""tooltip"": ""Toggle Dentin"",
      ""type"": ""button"",
      ""cssIconClass"": ""Dentin"",
      ""items"": []
    }
  ]
}";

      public static string Toolbar_embedded_mini = @"{""name"": ""embedded"",
  ""items"": [
    {
      ""id"": ""FitImage"",
      ""action"": ""FitImage"",
      ""caption"": ""Fit"",
      ""tooltip"": ""Fit"",
      ""type"": ""button"",
      ""cssIconClass"": ""FitImage"",
      ""items"": []
    },
    {
      ""id"": ""OneToOne"",
      ""action"": ""OneToOne"",
      ""caption"": ""1 To 1"",
      ""tooltip"": ""One To One"",
      ""type"": ""button"",
      ""cssIconClass"": ""OneToOne"",
      ""items"": []
    },
    {
      ""id"": ""ZoomIn"",
      ""action"": ""ZoomIn"",
      ""caption"": ""Zoom In"",
      ""tooltip"": ""Zoom In"",
      ""type"": ""button"",
      ""cssIconClass"": ""ZoomIn"",
      ""items"": []
    },
    {
      ""id"": ""ZoomOut"",
      ""action"": ""ZoomOut"",
      ""caption"": ""Zoom Out"",
      ""tooltip"": ""Zoom Out"",
      ""type"": ""button"",
      ""cssIconClass"": ""ZoomOut"",
      ""items"": []
    },
    {
      ""id"": ""Orientation"",
      ""action"": ""RotateClockwise"",
      ""caption"": ""Rotate C"",
      ""tooltip"": ""Rotate Clockwise"",
      ""type"": ""button"",
      ""cssIconClass"": ""RotateClock"",
      ""items"": [
        {
          ""id"": ""RotateClockwise"",
          ""action"": ""RotateClockwise"",
          ""caption"": ""Rotate C"",
          ""tooltip"": ""Rotate Clockwise"",
          ""type"": ""button"",
          ""cssIconClass"": ""RotateClock"",
          ""items"": []
        },
        {
          ""id"": ""RotateCounterClock"",
          ""action"": ""RotateCounterclockwise"",
          ""caption"": ""Rotate CC"",
          ""tooltip"": ""Rotate Counterclockwise"",
          ""type"": ""button"",
          ""cssIconClass"": ""RotateCounterClock"",
          ""items"": []
        },
        {
          ""id"": ""Flip"",
          ""action"": ""Flip"",
          ""caption"": ""Flip"",
          ""tooltip"": ""Flip"",
          ""type"": ""button"",
          ""cssIconClass"": ""Flip"",
          ""items"": []
        },
        {
          ""id"": ""Reverse"",
          ""action"": ""Reverse"",
          ""caption"": ""Reverse"",
          ""tooltip"": ""Reverse"",
          ""type"": ""button"",
          ""cssIconClass"": ""Reverse"",
          ""items"": []
        }
      ]
    },
    {
      ""id"": ""Endo"",
      ""action"": ""OnToggleEndo"",
      ""caption"": ""Endo"",
      ""tooltip"": ""Toggle Endo"",
      ""type"": ""button"",
      ""cssIconClass"": ""Endo"",
      ""items"": []
    },
    {
      ""id"": ""Perio"",
      ""action"": ""OnTogglePerio"",
      ""caption"": ""Perio"",
      ""tooltip"": ""Toggle Perio"",
      ""type"": ""button"",
      ""cssIconClass"": ""Perio"",
      ""items"": []
    },
    {
      ""id"": ""Dentin"",
      ""action"": ""OnToggleDentin"",
      ""caption"": ""Dentin"",
      ""tooltip"": ""Toggle Dentin"",
      ""type"": ""button"",
      ""cssIconClass"": ""Dentin"",
      ""items"": []
    }
  ]
}";

   }
}