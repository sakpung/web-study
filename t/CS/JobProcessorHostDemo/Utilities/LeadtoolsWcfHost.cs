// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;
using System.Net;

using Leadtools.Demos;

using Leadtools.Services.JobProcessor.ServiceImplementations;
using Leadtools.Services.JobProcessor.ServiceContracts;

namespace JobProcessorHostDemo
{
   public class LeadtoolsWcfHost
   {
      public List<ServiceHost> _serviceHosts = null;
      LeadtoolsServices _services = new LeadtoolsServices();
      System.ServiceModel.Channels.Binding _binding;
      string _baseAddress = "";
      string _port;
      string _alias;

      public delegate void OpenedEventHandler(string serviceName, string address);
      public delegate void OpeningEventHandler(string serviceName, string address);
      public delegate void ClosingEventHandler(string serviceName, string address);
      public delegate void ClosedEventHandler(string serviceName, string address);

      public event OpenedEventHandler Opened;
      public event OpeningEventHandler Opening;
      public event ClosingEventHandler Closing;
      public event ClosedEventHandler Closed;

      public LeadtoolsWcfHost()
      {
         _services.Add(new LeadtoolsService(typeof(WorkerService), typeof(IWorkerService)));
         _services.Add(new LeadtoolsService(typeof(JobService), typeof(IJobService)));

         BasicHttpBinding binding = new BasicHttpBinding();
         binding.TransferMode = TransferMode.Buffered;
         binding.ReaderQuotas.MaxArrayLength = 2147483647;
         binding.MaxReceivedMessageSize = 2147483647;
         binding.MaxBufferSize = 2147483647;

         _binding = binding;
      }

      public void Start(bool silent)
      {
         if ( _serviceHosts != null )
         {
            foreach ( ServiceHost host2 in _serviceHosts )
            {
               host2.Opened -= new EventHandler(host_Opened);
               host2.Opening -= new EventHandler(host_Opening);
               host2.Closing -= new EventHandler(host_Closing);
               host2.Closed -= new EventHandler(host_Closed);

               host2.Close();
            }

            _serviceHosts.Clear();
            _serviceHosts = null;
         }

         if ( _baseAddress.Length > 0 )
         {
            string alias;

            if(_alias.Length > 0)
            {
               alias = "/" + _alias;
            }
            else
            {
               alias = "";
            }

            _serviceHosts = new List<ServiceHost>();

            foreach ( LeadtoolsService service in _services )
            {
               string address = "http://" + _baseAddress + ":" + _port +  alias + "/" +  service.ServiceType.Name + ".svc";

               ServiceHost host = new ServiceHost(service.ServiceType, new Uri(address));
               host.AddServiceEndpoint(service.ServiceContractType, _binding, new Uri(address));
               ServiceMetadataBehavior metadataBehavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
               if ( metadataBehavior == null )
               {
                  metadataBehavior = new ServiceMetadataBehavior();
                  metadataBehavior.HttpGetEnabled = true;
                  host.Description.Behaviors.Add(metadataBehavior);
               }

               host.Opened += new EventHandler(host_Opened);
               host.Opening += new EventHandler(host_Opening);
               host.Closing += new EventHandler(host_Closing);
               host.Closed += new EventHandler(host_Closed);

               try
               {
                  host.Open();
                  _serviceHosts.Add(host);
               }
               catch(Exception ex)
               {
                  if (!silent)
                     MessageBox.Show(ex.Message, "JobProcessor Host Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  break;
               }
            }

            if(!silent)
               MessageBox.Show("The LEADTOOLS JobProcessor Services are now hosted on this system.", "Services Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
      }

      public string Address
      {
         get
         {
            return _baseAddress;
         }
         set
         {
            _baseAddress = value;
         }
      }

      public string Port
      {
         get
         {
            return _port;
         }
         set
         {
            _port = value;
         }
      }

      public string Alias
      {
         get
         {
            return _alias;
         }
         set
         {
            _alias = value;
         }
      }

      public void Shutdown()
      {
         
         if ( _serviceHosts != null )
         {
            foreach ( ServiceHost host in _serviceHosts )
            {
               host.Close();
               host.Opened -= new EventHandler(host_Opened);
               host.Opening -= new EventHandler(host_Opening);
               host.Closing -= new EventHandler(host_Closing);
               host.Closed -= new EventHandler(host_Closed);
            }

            _serviceHosts.Clear();
            _serviceHosts = null;
         }
      }


      void host_Closed(object sender, EventArgs e)
      {
         if ( Closed != null )
            Closed((sender as ServiceHost).Description.Name, (sender as ServiceHost).BaseAddresses[0].ToString());
      }

      void host_Opening(object sender, EventArgs e)
      {
         if ( Opening != null )
            Opening((sender as ServiceHost).Description.Name, (sender as ServiceHost).BaseAddresses[0].ToString());

      }

      void host_Closing(object sender, EventArgs e)
      {
         if ( Closing != null )
            Closing((sender as ServiceHost).Description.Name, (sender as ServiceHost).BaseAddresses[0].ToString());
      }

      void host_Opened(object sender, EventArgs e)
      {
         if ( Opened != null )
            Opened((sender as ServiceHost).Description.Name, (sender as ServiceHost).BaseAddresses[0].ToString());
      }
   }

   class LeadtoolsService
   {
      Type _serviceType;
      Type _serviceContractType;

      public LeadtoolsService(Type serviceType, Type serviceContractType)
      {
         _serviceType = serviceType;
         _serviceContractType = serviceContractType;
      }

      public Type ServiceContractType
      {
         get { return _serviceContractType; }
         set { _serviceContractType = value; }
      }

      public Type ServiceType
      {
         get { return _serviceType; }
         set { _serviceType = value; }
      }
   }

   class LeadtoolsServices : List<LeadtoolsService>
   {
   }
}
