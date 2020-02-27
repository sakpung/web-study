using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace Leadtools.Medical.WebViewer.IdP.Controllers
{
   public class AccountController : Controller
   {
      static string EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
      {
         byte[] encrypted;
         using (var aesAlg = Aes.Create())
         {
            aesAlg.Key = Key;
            aesAlg.IV = IV;
            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (var msEncrypt = new MemoryStream())
            {
               using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
               {
                  using (var swEncrypt = new StreamWriter(csEncrypt))
                  {
                     swEncrypt.Write(plainText);
                  }
                  encrypted = msEncrypt.ToArray();
               }
            }
         }
         return Convert.ToBase64String(encrypted);
      }
      private string Encode(string token)
      {
         var shared_key = "{A90A4F9C-DE86-4D50-889A-A8D329DB6922}";
         var shared_key_salt = new byte[8] { 100, 19, 41, 255, 18, 30, 12, 86 };

         var keySize = 128;
         var blockSize = 128;
         using (var derived_key = new Rfc2898DeriveBytes(shared_key, shared_key_salt))
         {
            var aesKey = derived_key.GetBytes(keySize / 8);
            var aesIV = derived_key.GetBytes(blockSize / 8);
            return EncryptStringToBytes_Aes(token, aesKey, aesIV);
         }
      }

      public static long GetUnixTimeSeconds()
      {
         long num = DateTime.UtcNow.Ticks / 10000000L;
         return num - 62135596800L;
      }
      public ActionResult LoginOkta()
      {
         if (!HttpContext.User.Identity.IsAuthenticated)
         {
            HttpContext.GetOwinContext().Authentication.Challenge(OpenIdConnectAuthenticationDefaults.AuthenticationType);
            return new HttpUnauthorizedResult();
         }

         //preferred_username
         var claim = HttpContext.GetOwinContext().Authentication.User.Claims.First(x => x.Type == "preferred_username");

         //consider using id_token

         if (null != claim)
         {
            var json = $"{{\"{claim.Type}\": \"{claim.Value}\", \"created\":{GetUnixTimeSeconds()}}}";
            string clientUri = ConfigurationManager.AppSettings["client:MedicalViewer"];
            return Redirect(clientUri + $"#/login/implicit/ltidp/{Encode(json)}");
         }
         else
         {
            return RedirectToAction("Index", "Home");
         }
      }

      public ActionResult LoginShibboleth()
      {
         if (!HttpContext.User.Identity.IsAuthenticated)
         {
            HttpContext.GetOwinContext().Authentication.Challenge(OpenIdConnectAuthenticationDefaults.AuthenticationType);
            return new HttpUnauthorizedResult();
         }

         //preferred_username
         var claim = HttpContext.GetOwinContext().Authentication.User.Claims.First(x => x.Type == "preferred_username");

         //consider using id_token

         if (null != claim)
         {
            var json = $"{{\"{claim.Type}\": \"{claim.Value}\", \"created\":{GetUnixTimeSeconds()}}}";
            string clientUri = ConfigurationManager.AppSettings["client:MedicalViewer"];
            return Redirect(clientUri + $"#/login/implicit/ltidp/{Encode(json)}");
         }
         else
         {
            return RedirectToAction("Index", "Home");
         }
      }

      [HttpPost]
      public ActionResult Logout()
      {
         if (HttpContext.User.Identity.IsAuthenticated)
         {
            HttpContext.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType, OpenIdConnectAuthenticationDefaults.AuthenticationType);
         }

         return RedirectToAction("Index", "Home");
      }

      public ActionResult PostLogout()
      {
         return RedirectToAction("Index", "Home");
      }

      [Authorize]
      public ActionResult Claims()
      {
         return View(HttpContext.GetOwinContext().Authentication.User.Claims);
      }
   }
}