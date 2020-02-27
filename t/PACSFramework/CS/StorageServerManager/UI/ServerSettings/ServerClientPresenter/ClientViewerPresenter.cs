// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Demos.StorageServer;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.Winforms.ClientManager;

namespace Leadtools.Medical.Winforms
{
   public class ClientViewerPresenter
   {
      public int? MaxClients
      {
         get
         {
            if (_view != null)
               return _view.MaxClients;
            return null;
         }
         set
         {
            if(_view!=null)
            {
               _view.MaxClients = value;
            }
         }
      }
      public ClientViewerPresenter ( )
      {}

      private ClientViewerControl _view;

      public ClientViewerControl View
      {
         get { return _view; }
         set { _view = value; }
      }
      
      public void RunView ( ClientViewerControl view ) 
      {
         // 
         view.ServerSecure = false;
         if (ServerState.Instance.ServerService != null && ServerState.Instance.ServerService.Settings != null)
         {
            view.ServerSecure = ServerState.Instance.ServerService.Settings.Secure;
         }

         EventBroker.Instance.Subscribe<ApplyServerSettingsEventArgs>(OnUpdateServerSettings);
         EventBroker.Instance.Subscribe<CancelServerSettingsEventArgs>(OnCancelServerSettings);
         EventBroker.Instance.Subscribe<ServerSettingsSecureChangedEventArgs>(OnServerSettingsSecureChanged);

         // store the view
         _view = view;         
         _view.SettingsChanged += new EventHandler(View_SettingsChanged);
         _view_LoadClients(_view, EventArgs.Empty);
         _view.LoadClients +=new EventHandler<EventArgs>(_view_LoadClients);

#if LEADTOOLS_V20_OR_LATER
         IOptionsDataAccessAgent optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();
         if (optionsAgent != null)
         {
            ClientConfigurationOptions clientConfigurationOptions = optionsAgent.Get<ClientConfigurationOptions>(ClientConfigurationOptionsKeyName, new ClientConfigurationOptions());
            if (clientConfigurationOptions != null)
            {
               _view.Options = clientConfigurationOptions;
            }
         }
#endif // #if LEADTOOLS_V20_OR_LATER
      }

      public const string ClientConfigurationOptionsKeyName = "ClientConfigurationOptions";

      void _view_LoadClients(object sender, EventArgs e)
      {
         IAeManagementDataAccessAgent2 agent = DataAccessServices.GetDataAccessService<IAeManagementDataAccessAgent>() as IAeManagementDataAccessAgent2;
         if (agent == null)
         {
            return;
         }

#if LEADTOOLS_V20_OR_LATER
         IOptionsDataAccessAgent optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>() as IOptionsDataAccessAgent;
         if (optionsAgent == null)
         {
            return;
         }

         AeInfoExtended searchParams = new AeInfoExtended();
#endif // #if LEADTOOLS_V20_OR_LATER
      
         AeInfoExtended[] aeInfoExtendedArray = agent.GetAeTitles();

         IPermissionManagementDataAccessAgent permissionsAgent = DataAccessServices.GetDataAccessService<IPermissionManagementDataAccessAgent>();

         // Get the list of all possible permissions
         _view.Permissions = permissionsAgent.GetPermissions();

         // The LEADTOOLS skinned version defaults to all permissions on
         if (Shell.storageServerName.Contains("LEAD"))
            _view.NewClientPermissions = _view.Permissions; // All permissions on by default;
         else
            _view.NewClientPermissions = new Permission[0]; // All permissions off by default;

         _view.ClientInformationList = new ClientInformationList();

         // view.ClientInformationList.AddItems(aeInfoExtendedArray);
         foreach (AeInfoExtended info in aeInfoExtendedArray)
         {
            string[] permissionsArray = permissionsAgent.GetUserPermissions(info.AETitle);
            ClientInformation ci = new ClientInformation(info, permissionsArray);
            _view.ClientInformationList.ClientDictionary.Add(info.AETitle, ci);
         }

         // Make a backup of the settings
         ServerState.Instance.ClientList = new ClientInformationList(_view.ClientInformationList);
      }

      public event EventHandler SettingsChanged;

      private void View_SettingsChanged(object sender, EventArgs e)
      {
         try
         {
            if (SettingsChanged != null)
            {
               SettingsChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }


      public bool IsDirty
      {
         get
         {
            return _view.IsDirty;
         }
      }

      void OnUpdateServerSettings(object sender, EventArgs e)
      {
         if (_view != null)
         {
            IAeManagementDataAccessAgent agent = DataAccessServices.GetDataAccessService<IAeManagementDataAccessAgent>();
            IPermissionManagementDataAccessAgent permissionsAgent = DataAccessServices.GetDataAccessService<IPermissionManagementDataAccessAgent>();

#if LEADTOOLS_V20_OR_LATER
            IOptionsDataAccessAgent optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();

            if (optionsAgent != null)
            {
               ClientConfigurationOptions clientConfigurationOptions = optionsAgent.Get<ClientConfigurationOptions>(ClientConfigurationOptionsKeyName, new ClientConfigurationOptions());
               if (clientConfigurationOptions != null)
               {
                  View.Options =clientConfigurationOptions;
               }
            }
#endif // #if LEADTOOLS_V20_OR_LATER

            AeInfoExtended[] aeInfoExtendedArray = agent.GetAeTitles();
            List<string> aeTitlesInDB = new List<string>();

            foreach (AeInfoExtended ae in aeInfoExtendedArray)
            {
               ClientInformation info = (from i in ServerState.Instance.ClientList.Items
                                         where i.Client.AETitle == ae.AETitle
                                         select i).FirstOrDefault();

               //
               // Only add items that existed when the database was first queried. If an ae title was added outside of this dialog
               //  it will be ignored.
               //
               if(info!=null)
                  aeTitlesInDB.Add(ae.AETitle.ToUpper());
            }

            // Updates and adds
            foreach (ClientInformation ci in _view.ClientInformationList.Items)
            {
               string aeTitle =ci.Client.AETitle; 
               if (aeTitlesInDB.Contains(aeTitle, StringComparer.InvariantCultureIgnoreCase))
               {
                  // update
                  ClientInformation ciPrevious = null;
                  ServerState.Instance.ClientList.ClientDictionary.TryGetValue(aeTitle, out ciPrevious);
                  
                  if (!ciPrevious.Equals(ci))
                     agent.Update(aeTitle, ci.Client);
                  aeTitlesInDB.Remove(aeTitle.ToUpper());
                  try
                  {
                     EventBroker.Instance.PublishEvent<ClientUpdatedEventArgs>(this, new ClientUpdatedEventArgs(aeTitle, ci.Client));
                  }
                  catch { }
               }
               else
               {
                  // insert
                  agent.Add(ci.Client);
                  try
                  {
                     EventBroker.Instance.PublishEvent<ClientAddedEventArgs>(this, new ClientAddedEventArgs(ci.Client));
                  }
                  catch { }
               }
               permissionsAgent.DeleteUserPermission(null, aeTitle);
               foreach (string permissionName in ci.Permissions)
               {
                  permissionsAgent.AddUserPermission(permissionName, aeTitle);
               }
            }

            // Finally, remove the deleted AE titles from the database
            foreach (string aeTitle in aeTitlesInDB)
            {
               agent.Remove(aeTitle);
               try
               {
                  EventBroker.Instance.PublishEvent<ClientRemovedEventArgs>(this, new ClientRemovedEventArgs(aeTitle));
               }
               catch { }
            }

            ServerState.Instance.ClientList = new ClientInformationList(_view.ClientInformationList);

         }
      }

      void OnCancelServerSettings(object sender, EventArgs e)
      {
         if (_view != null)
            _view.ClientInformationList = ServerState.Instance.ClientList;
      }

      void OnServerSettingsSecureChanged(object sender, ServerSettingsSecureChangedEventArgs e)
      {
         _view.ServerSecure = e.SecureServer;
      }
   }
}
