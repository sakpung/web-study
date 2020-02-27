// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Security;

namespace Leadtools.Medical.WebViewer.Wado
{
   public class WadoClientConfig
   {
      public static WadoClientConfig From(RemoteQueryServiceConfig config)
      {
         if (config.ServiceClass != "WadoServiceConfig")
         {
            throw new ArgumentException();
         }
         return config.ClientInfo as WadoClientConfig;
      }

      public string ClientIdentifier { get; set; }
      public string ClientSecret  { get; set; }
      public SecureString SecureClientSecret  { get; set; }
   }

   public class WadoServiceConfig
   {
      public static WadoServiceConfig From(RemoteQueryServiceConfig config)
      {
         if (config.ServiceClass != "WadoServiceConfig")
         {
            throw new ArgumentException();
         }
         return config.ServerInfo as WadoServiceConfig;
      }
      public string Url { get; set; }
      public string QidoRsService { get; set; }
      public string WadoRsService { get; set; }

      public string QidoRsServiceUrl
      {
         get
         {
            return UrlBuilder.Combine(Url, QidoRsService);
         }
      }

      public string WadoRsServiceUrl
      {
         get
         {
            return UrlBuilder.Combine(Url, WadoRsService);
         }
      }
   }
}
