// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Web;
using System.Web.Hosting;

namespace Leadtools.Medical.WebViewer.Common
{
   internal class ServiceUtils
   {
      public static string MapConfigPath(string path)
      {
         if (!string.IsNullOrEmpty(path))
         {
            if (path.ToLower().StartsWith("app_data"))
            {
               path = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, path);
            }
         }
         return path;
      }

      public static int GetFreeIPPort()
      {
         return 1000;
      }

      internal static string GetLocalIPAddressesV4_mgmt()
      {
         try
         {
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
            ManagementObjectCollection queryCollection = query.Get();

            foreach (ManagementObject mo in queryCollection)
            {
               if (queryCollection.Count > 0)
               {
                  string[] addresses = (string[])mo["IPAddress"];

                  foreach (string ip in addresses)
                  {
                     if (!ip.Contains(":") && (ip != "0.0.0.0"))
                        return ip;
                  }
               }
            }
         }
         catch
         {
         }

         return string.Empty;
      }

      internal static string GetLocalIPAddressesV4_dns()
      {
         var localAddresses = Dns.GetHostAddresses(Dns.GetHostName());

         foreach (var localAddress in localAddresses)
         {
            if (localAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
               return localAddress.ToString();
            }
         }

         return string.Empty;
      }

      /// <summary>
      /// returns first local IP address
      /// </summary>
      /// <returns></returns>
      public static string GetLocalIPAddressesV4()
      {
         var ip = GetLocalIPAddressesV4_dns();
         if (string.IsNullOrEmpty(ip))
         {
            ip = GetLocalIPAddressesV4_mgmt();
         }
         return ip;
      }
   }
}
