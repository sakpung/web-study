// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

using Leadtools.Demos;

namespace SharePointDemo
{
   public partial class SharePointConnectDialog : Form
   {
      // Set the server properties to use
      private SharePointServerProperties _serverProperties;
      // Did we cancel this dialog
      private bool _canceled;
      // We are busy
      private bool _isBusy;
      // The list of the documents in the "Shared Document" folder on the server
      private List<string> _documentNames;

      public SharePointConnectDialog(SharePointServerProperties serverProperties)
      {
         InitializeComponent();

         _serverProperties = serverProperties;
      }

      public IList<string> DocumentNames
      {
         get { return _documentNames; }
      }

      private delegate void ConnectToServerDelegate();

      protected override void OnLoad(EventArgs e)
      {
         _isBusy = true;

         BeginInvoke(new ConnectToServerDelegate(ConnectToServer));

         base.OnLoad(e);
      }

      private void ConnectToServer()
      {
         _messageLabel.Text = "Connecting to " + _serverProperties.Url;
         _busyProgressBar.MarqueeAnimationSpeed = 100;
         Application.DoEvents();

         // Connect to SharePoint server
         SharePointLists.Lists listsService = new SharePointLists.Lists();

         try
         {
            // Set the credentials
            if(_serverProperties.UseCredentials)
               listsService.Credentials = new NetworkCredential(_serverProperties.UserName, _serverProperties.Password, _serverProperties.Domain);
            else
               listsService.Credentials = CredentialCache.DefaultCredentials;

            // Set the proxy
            if(_serverProperties.UseProxy)
               listsService.Proxy = new WebProxy(_serverProperties.Host, _serverProperties.Port);
            else
               listsService.Proxy = null;

            // Set the URL
            string url = _serverProperties.Url;
            if(!url.EndsWith("/"))
               url += "/";

            // Use the SharePoint Lists web service
            url += @"_vti_bin/lists.asmx";
            listsService.Url = url;

            // Setup the XML document we need as a parameter to the GetListItems method of the service
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Document><Query/><ViewFields /><QueryOptions /></Document>");
            XmlNode queryNode = doc.SelectSingleNode("//Query");
            XmlNode viewFieldsNode = doc.SelectSingleNode("//ViewFields");
            XmlNode queryOptionsNode = doc.SelectSingleNode("//QueryOptions");

            string documentLibraryName = @"Shared Documents";

            // Now connect to this server asynchronisly
            listsService.GetListItemsCompleted += new SharePointDemo.SharePointLists.GetListItemsCompletedEventHandler(listsService_GetListItemsCompleted);
            listsService.GetListItemsAsync(documentLibraryName, null, queryNode, viewFieldsNode, null, queryOptionsNode);
         }
         catch(Exception ex)
         {
            // Stop the animation and show the error
            _busyProgressBar.MarqueeAnimationSpeed = 0;
            Application.DoEvents();

            Messager.ShowError(this, ex);

            // Cancel
            listsService.Dispose();
            _isBusy = false;
            DialogResult = DialogResult.Cancel;
         }
      }

      private void listsService_GetListItemsCompleted(object sender, SharePointDemo.SharePointLists.GetListItemsCompletedEventArgs e)
      {
         // Get the services
         SharePointLists.Lists listsService = sender as SharePointLists.Lists;

         // Unhook from the event
         listsService.GetListItemsCompleted -= new SharePointDemo.SharePointLists.GetListItemsCompletedEventHandler(listsService_GetListItemsCompleted);

         // Check if we caneled
         if(e.Cancelled || _canceled || e.Error != null)
         {
            if(e.Error != null)
            {
               // Stop the animation and show the error
               _busyProgressBar.MarqueeAnimationSpeed = 0;
               Application.DoEvents();
               Messager.ShowError(this, e.Error);
            }

            // Cancel
            listsService.Dispose();
            _isBusy = false;
            DialogResult = DialogResult.Cancel;
            return;
         }

         // We are done, get the results
         XmlNode listItemsNode = e.Result;

         // Loop through all the items, get the documents
         _documentNames = new List<string>();
         XmlNodeList childNodes = listItemsNode.ChildNodes;
         foreach(XmlNode childNode in childNodes)
         {
            XmlNodeReader reader = new XmlNodeReader(childNode);

            while(reader.Read())
            {
               if(reader["ows_EncodedAbsUrl"] != null && reader["ows_LinkFilename"] != null)
               {
                  string objType = reader["ows_FSObjType"].ToString();

                  // If the objType is of this format: number;#1 then it is a folder
                  // and we should not use it
                  if(!objType.EndsWith(";#1"))
                  {
                     // Get the file name
                     string fileName = reader["ows_LinkFilename"].ToString();
                     _documentNames.Add(fileName);
                  }
               }
            }
         }

         listsService.Dispose();
         DialogResult = DialogResult.OK;
         _isBusy = false;
      }

      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         // If we are busy, cancel but do not close the dialog
         // The ConnectToServer method will eventually exists
         if(_isBusy)
         {
            e.Cancel = true;
            _canceled = true;
         }

         base.OnFormClosing(e);
      }

      private void _cancelButton_Click(object sender, EventArgs e)
      {
         // Cancel and stay in the dialog
         // The ConnectToServer method will eventually exists
         _canceled = true;
         DialogResult = DialogResult.None;
      }
   }
}
