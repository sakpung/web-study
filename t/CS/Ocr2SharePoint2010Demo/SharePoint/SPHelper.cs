// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using Microsoft.SharePoint.Client;

namespace Ocr2SharePointDemo.SharePoint
{
   public enum SPTemplateType
   {
      All = 0,                // Get all SharePoint lists of all the types listed below
      DocumentLibrary = 101,  // Get SharePoint lists with DocumentLibrary base template
      PictureLibrary = 109,   // Get SharePoint lists with PictureLibrary base template
      AssetLibrary = 851,     // Get SharePoint lists with AssetLibrary base template
   }

   public class SPListInfo
   {
      public Guid Id;
      public string Title;
      public SPTemplateType BaseTemplate;
      public DateTime Created;
      public string Description;
      public string ServerRelativeUrl;
      public Uri AbsoluteUri;

      public SPListInfo()
      {
      }

      public SPListInfo(Uri siteUri, List list)
      {
         Id = list.Id;
         Title = list.Title;
         ServerRelativeUrl = list.RootFolder.ServerRelativeUrl;
         AbsoluteUri = SPHelper.CombineUrl(siteUri, ServerRelativeUrl);
         BaseTemplate = (SPTemplateType)list.BaseTemplate;
         Created = list.Created;
         Description = list.Description;
      }

      public override string ToString()
      {
         return Title;
      }
   }

   public enum SPItemType
   {
      File,
      Folder,
      Other
   }

   public class SPItemInfo
   {
      public int Id;
      public Guid ParentListId;
      public SPItemInfo ParentItem;
      public SPItemType ItemType;
      public DateTime Created;
      public string DisplayName;
      public string Name;
      public string Title;
      public string ServerRelativeUrl;
      public Uri AbsoluteUri;
      public string Author;
      public string FileExtension;

      public SPItemInfo()
      {
      }

      public SPItemInfo(Uri siteUri, ListItem item, SPListInfo parentList, SPItemInfo parentItem)
      {
         Id = item.Id;
         ParentListId = parentList.Id;
         ParentItem = parentItem;
         ItemType = item.FileSystemObjectType == FileSystemObjectType.File ? SPItemType.File : SPItemType.Folder;
         if (!DateTime.TryParse(item.FieldValuesAsText["Created"], out Created))
         {
            Created = DateTime.Now;
         }
         DisplayName = item.DisplayName;
         Name = item.FieldValuesAsText["FileLeafRef"];
         Title = item.FieldValuesAsText["Title"];
         ServerRelativeUrl = item.FieldValuesAsText["FileRef"];
         AbsoluteUri = SPHelper.CombineUrl(siteUri, ServerRelativeUrl);
         Author = item.FieldValuesAsText["Author"];
         FileExtension = item.FieldValuesAsText["File_x0020_Type"];
      }

      public override string ToString()
      {
         return DisplayName;
      }
   }

   public class SPHelper
   {
      private SharePointServerSettings _serverSettings;

      private SPHelper()
      {
      }

      public SPHelper(SharePointServerSettings serverSettings)
      {
         _serverSettings = serverSettings;
      }

      private ClientContext CreateContext()
      {
         ClientContext clientContext = new ClientContext(new Uri(_serverSettings.Uri));
         if (_serverSettings.UserName != null)
         {
            clientContext.Credentials = new NetworkCredential(_serverSettings.UserName, _serverSettings.Password, _serverSettings.Domain);
         }

         if (_serverSettings.ProxyUri != null)
         {
            System.Net.WebProxy proxy = new System.Net.WebProxy(_serverSettings.ProxyUri, _serverSettings.ProxyPort);
            if (proxy.Credentials == null && clientContext.Credentials != null)
            {
               proxy.Credentials = clientContext.Credentials;
            }
            else
            {
               proxy.Credentials = CredentialCache.DefaultCredentials;
            }

            WebRequest.DefaultWebProxy = proxy;
         }
         else
            WebRequest.DefaultWebProxy = WebRequest.GetSystemWebProxy(); // Get default system proxy settings

         return clientContext;
      }

      public SPListInfo[] GetLists()
      {
         List<SPListInfo> ret = new List<SPListInfo>();

         using (ClientContext clientContext = CreateContext())
         {
            clientContext.Load(clientContext.Web.Lists);
            clientContext.Load(clientContext.Web.Lists, lists => lists.Include(l => l.RootFolder.ServerRelativeUrl, l => l.OnQuickLaunch));
            clientContext.ExecuteQuery();

            SPTemplateType baseTemplateType = SPTemplateType.All;
            Uri siteUri = new Uri(_serverSettings.Uri);

            if (clientContext.Web.Lists.Count > 0)
            {
               foreach (List list in clientContext.Web.Lists)
               {
                  if (EnsureValidListTemplate(list, baseTemplateType))
                  {
                     SPListInfo spListInfo = new SPListInfo(siteUri, list);
                     ret.Add(spListInfo);
                  }
               }
            }
         }

         return ret.ToArray();
      }

      private bool EnsureValidListTemplate(List list, SPTemplateType baseTemplateType)
      {
         BaseType listBaseType = (BaseType)list.BaseType;
         if (list.Hidden || listBaseType != BaseType.DocumentLibrary)
         {
            return false;
         }

         SPTemplateType listBaseTemplate = (SPTemplateType)list.BaseTemplate;

         if (baseTemplateType == SPTemplateType.All)
         {
            return listBaseTemplate == SPTemplateType.DocumentLibrary ||
                   listBaseTemplate == SPTemplateType.PictureLibrary ||
                   listBaseTemplate == SPTemplateType.AssetLibrary;
         }
         else
         {
            return listBaseTemplate == baseTemplateType;
         }
      }

      internal static Uri CombineUrl(Uri uri, string name)
      {
         if (name != null)
         {
            UriBuilder urib = new UriBuilder(uri);
            urib.Path = System.IO.Path.Combine(urib.Path, name);
            uri = urib.Uri;
         }

         return uri;
      }

      public SPItemInfo[] GetChildren(SPListInfo parentList, SPItemInfo parentItemInfo)
      {
         CamlQuery query = new CamlQuery();
         query.ViewXml = "<View/>";

         if(parentItemInfo != null)
            query.FolderServerRelativeUrl = parentItemInfo.ServerRelativeUrl;

         List<SPItemInfo> ret = new List<SPItemInfo>();
         Uri siteUri = new Uri(_serverSettings.Uri);

         using (ClientContext clientContext = CreateContext())
         {
            clientContext.Load(clientContext.Web.Lists);
            clientContext.Load(clientContext.Web.Lists, lists => lists.Include(l => l.RootFolder.ServerRelativeUrl, l => l.OnQuickLaunch));
            clientContext.ExecuteQuery();

            List list = clientContext.Web.Lists.GetById(parentList.Id);
            ListItemCollection listItems = list.GetItems(query);
            if (listItems != null)
            {
               clientContext.Load(listItems);
               clientContext.Load(listItems, items => items.Include(
                  item => item.Id,
                  item => item.FileSystemObjectType,
                  item => item.DisplayName,
                  item => item.FieldValuesAsText));
               clientContext.ExecuteQuery();

               foreach (ListItem item in listItems)
               {
                  if(item.FileSystemObjectType == FileSystemObjectType.File || item.FileSystemObjectType == FileSystemObjectType.Folder)
                  {
                     SPItemInfo spItemInfo = new SPItemInfo(siteUri, item, parentList, parentItemInfo);
                     ret.Add(spItemInfo);
                  }
               }
            }
         }

         return ret.ToArray();
      }
   }
}
