// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Winforms.ClientManager;
using Leadtools.Dicom.Server.Admin;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.AddIn;
using System.Windows.Forms;
using System.Diagnostics;
using System.ServiceProcess;

namespace Leadtools.Demos.StorageServer.UI.RealtimeView
{
   public class RealTimeViewPresenter
   {
      private RealTimeViewerControl _View;

      public void RunView(RealTimeViewerControl view)
      {
         _View = view;
         _View.VisibleChanged += new EventHandler(_View_VisibleChanged);
         _View.DisconnectClient += new EventHandler<DisconnectClientEventArgs>(_View_DisconnectClient);
         ServerState.Instance.ServerServiceChanged += new EventHandler(Instance_ServerServiceChanged);
         HookEvents();
      }

      void _View_DisconnectClient(object sender, DisconnectClientEventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            ServerState.Instance.ServerService.SendMessage(MessageNames.DisconnectClient, e.ClientInfo);
         }
      }

      void _View_VisibleChanged(object sender, EventArgs e)
      {
          if (!_View.Visible)
              _View.PauseScheduler();
          else
              _View.ResumeScheduler();
      }

      void Instance_ServerServiceChanged(object sender, EventArgs e)
      {
         HookEvents();
      }

      private void HookEvents()
      {
         if (ServerState.Instance.ServerService != null)
         {
             ServerState.Instance.ServerService.Message += ServerService_Message;
             ServerState.Instance.ServerService.StatusChange += ServerService_StatusChange;
             if(ServerState.Instance.ServerService.Status == ServiceControllerStatus.Running)
             {
                 ServerState.Instance.ServerService.SendMessage(MessageNames.GetConnectedClients);
             }
             _View.Refresh();
         }
      }

      void ServerService_StatusChange(object sender, EventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            if (ServerState.Instance.ServerService.Status != ServiceControllerStatus.Running)
            {
               AsyncHelper.SynchronizedInvoke(Application.OpenForms[0], () => _View.Clear());
            }
         }
      }

      void ServerService_Message(object sender, MessageEventArgs e)
      {
         switch (e.Message.Message)
         {
            case MessageNames.ClientConnected:
                 AsyncHelper.SynchronizedInvoke(Application.OpenForms[0], () =>
                 {
                     _View.ClientConnected(e.Message.Data[1] as ClientInfo);
                     if (!_View.Visible)
                         _View.PauseScheduler();
                 });
               break;
            case MessageNames.ClientAssociated:
               AsyncHelper.SynchronizedInvoke(Application.OpenForms[0], () => {
                   _View.ClientAssociated(e.Message.Data[1] as ClientInfo);
                   _View.SetClientAction(e.Message.Data[0] as string, "ASSOCIATED",string.Empty);
               });
               break;
            case MessageNames.ClientAction:
               AsyncHelper.SynchronizedInvoke(Application.OpenForms[0], () => _View.SetClientAction(e.Message.Data[0] as string, e.Message.Data[1] as string,(e.Message.Data[3] as string)));
               break;
            case MessageNames.ClientDisconnected:
               AsyncHelper.SynchronizedInvoke(Application.OpenForms[0], () => _View.ClientDisconnected(e.Message.Data[1] as ClientInfo));
               break; 
             case MessageNames.GetConnectedClients:
               AsyncHelper.SynchronizedInvoke(Application.OpenForms[0], () => _View.AddConnectedClients(e.Message.Data[0] as List<ClientInfo>));
               break;

         }
      }
   }
}
