// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Linq;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Configuration;
using System.Threading;
using System.ServiceModel.Description;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Globalization;
using System.ServiceModel.Channels;

namespace Leadtools.Demos
{
   public class CustomChannelFactory<T> : ChannelFactory<T>
   {
      private string _ConfigurationFileName;
      private static ReaderWriterLock _ReaderWriterLock = new ReaderWriterLock();
      private static Dictionary<string, ServiceModelSectionGroup> _Groups = new Dictionary<string, ServiceModelSectionGroup>();

      public CustomChannelFactory(string endpointConfigurationName, string configurationFileName)
         : base(typeof(T))
      {
         _ConfigurationFileName = configurationFileName;
         InitializeEndpoint(endpointConfigurationName, null);
      }

      protected override void ApplyConfiguration(string endpointConfigurationName)
      {
         if (string.IsNullOrEmpty(_ConfigurationFileName))
         {
            return;
         }

         ServiceModelSectionGroup serviceModeGroup = GetGroup(_ConfigurationFileName);

         LoadChannelBehaviors(Endpoint, endpointConfigurationName, serviceModeGroup);
      }

      private static ServiceModelSectionGroup GetGroup(string configurationFileName)
      {
         ServiceModelSectionGroup group;

         // Get a read lock while we access the cache collection
         _ReaderWriterLock.AcquireReaderLock(-1);
         try
         {
            // Check to see if we already have a group for the given configuration
            if (_Groups.TryGetValue(configurationFileName, out group))
            {
               // We found group so return it and we are done
               return group;
            }
         }
         finally
         {
            // always release the lock safely
            _ReaderWriterLock.ReleaseReaderLock();
         }

         // if we get here, we couldn't get a group so we need to create one
         // this will involve modifying the collection so we need a write lock
         _ReaderWriterLock.AcquireWriterLock(-1);
         try
         {
            // check an open group wasn't created on another thread while we were
            // acquiring the writer lock
            if (_Groups.TryGetValue(configurationFileName, out group))
            {
               // we found a group so return it and we are done
               return group;
            }

            ExeConfigurationFileMap executionFileMap = new ExeConfigurationFileMap
            {
               ExeConfigFilename = configurationFileName
            };

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(executionFileMap, ConfigurationUserLevel.None);
            group = ServiceModelSectionGroup.GetSectionGroup(config);

            // store it in the cache
            _Groups.Add(configurationFileName, group);

            return group;
         }
         finally
         {
            // always release the writer lock!
            _ReaderWriterLock.ReleaseWriterLock();
         }
      }

      public ServiceEndpoint LoadChannelBehaviors(ServiceEndpoint serviceEndpoint, string configurationName, ServiceModelSectionGroup serviceModeGroup)
      {
         bool isWildcard = string.Equals(configurationName, "*", StringComparison.Ordinal);
         ChannelEndpointElement provider = LookupChannel(serviceModeGroup, configurationName, serviceEndpoint.Contract.ConfigurationName, isWildcard);

         if (provider == null)
         {
            return null;
         }

         if (serviceEndpoint.Binding == null)
         {
            serviceEndpoint.Binding = LookupBinding(serviceModeGroup, provider.Binding, provider.BindingConfiguration);
         }

         if (serviceEndpoint.Address == null)
         {
            serviceEndpoint.Address = new EndpointAddress(provider.Address, LookupIdentity(provider.Identity), provider.Headers.Headers);
         }

         if (serviceEndpoint.Behaviors.Count == 0 && !String.IsNullOrEmpty(provider.BehaviorConfiguration))
         {
            LoadBehaviors(serviceModeGroup, provider.BehaviorConfiguration, serviceEndpoint);
         }

         serviceEndpoint.Name = provider.Contract;

         return serviceEndpoint;
      }

      private ChannelEndpointElement LookupChannel(ServiceModelSectionGroup serviceModeGroup, string configurationName, string contractName, bool wildcard)
      {
         foreach (ChannelEndpointElement endpoint in serviceModeGroup.Client.Endpoints)
         {
            if (endpoint.Contract == contractName && (endpoint.Name == configurationName || wildcard))
            {
               return endpoint;
            }
         }

         return null;
      }

      private Binding LookupBinding(ServiceModelSectionGroup group, string bindingName, string configurationName)
      {
         BindingCollectionElement bindingElementCollection = group.Bindings[bindingName];
         if (bindingElementCollection.ConfiguredBindings.Count == 0)
         {
            return null;
         }

         IBindingConfigurationElement bindingConfigurationElement = bindingElementCollection.ConfiguredBindings.First(item => item.Name == configurationName);

         Binding binding = GetBinding(bindingConfigurationElement);
         if (bindingConfigurationElement != null)
         {
            bindingConfigurationElement.ApplyConfiguration(binding);
         }

         return binding;
      }

      private EndpointIdentity LookupIdentity(IdentityElement element)
      {
         EndpointIdentity identity = null;
         PropertyInformationCollection properties = element.ElementInformation.Properties;

         if (properties["userPrincipalName"].ValueOrigin != PropertyValueOrigin.Default)
         {
            return EndpointIdentity.CreateUpnIdentity(element.UserPrincipalName.Value);
         }

         if (properties["servicePrincipalName"].ValueOrigin != PropertyValueOrigin.Default)
         {
            return EndpointIdentity.CreateSpnIdentity(element.ServicePrincipalName.Value);
         }

         if (properties["dns"].ValueOrigin != PropertyValueOrigin.Default)
         {
            return EndpointIdentity.CreateDnsIdentity(element.Dns.Value);
         }

         if (properties["rsa"].ValueOrigin != PropertyValueOrigin.Default)
         {
            return EndpointIdentity.CreateRsaIdentity(element.Rsa.Value);
         }

         if (properties["certificate"].ValueOrigin != PropertyValueOrigin.Default)
         {
            X509Certificate2Collection supportingCertificates = new X509Certificate2Collection();
            supportingCertificates.Import(Convert.FromBase64String(element.Certificate.EncodedValue));
            if (supportingCertificates.Count == 0)
            {
               throw new InvalidOperationException("UnableToLoadCertificateIdentity");
            }

            X509Certificate2 primaryCertificate = supportingCertificates[0];
            supportingCertificates.RemoveAt(0);
            return EndpointIdentity.CreateX509CertificateIdentity(primaryCertificate, supportingCertificates);
         }

         return identity;
      }

      private static void LoadBehaviors(ServiceModelSectionGroup group, string behaviorConfiguration, ServiceEndpoint serviceEndpoint)
      {
         EndpointBehaviorElement behaviorElement = group.Behaviors.EndpointBehaviors[behaviorConfiguration];

         for (int i = 0; i < behaviorElement.Count; i++)
         {
            BehaviorExtensionElement behaviorExtension = behaviorElement[i];
            object extension = behaviorExtension.GetType().InvokeMember(
             "CreateBehavior",
             BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance,
             null,
             behaviorExtension,
             null,
             CultureInfo.InvariantCulture);
            if (extension != null)
            {
               serviceEndpoint.Behaviors.Add((IEndpointBehavior)extension);
            }
         }
      }

      private Binding GetBinding(IBindingConfigurationElement configurationElement)
      {
         if (configurationElement is NetTcpBindingElement)
         {
            return new NetTcpBinding();
         }

         if (configurationElement is NetMsmqBindingElement)
         {
            return new NetMsmqBinding();
         }

         if (configurationElement is BasicHttpBindingElement)
         {
            return new BasicHttpBinding();
         }

         if (configurationElement is NetNamedPipeBindingElement)
         {
            return new NetNamedPipeBinding();
         }

         if (configurationElement is NetPeerTcpBindingElement)
         {
            return new NetPeerTcpBinding();
         }

         if (configurationElement is WSDualHttpBindingElement)
         {
            return new WSDualHttpBinding();
         }

         if (configurationElement is WSHttpBindingElement)
         {
            return new WSHttpBinding();
         }

         if (configurationElement is WSFederationHttpBindingElement)
         {
            return new WSFederationHttpBinding();
         }

         if (configurationElement is CustomBindingElement)
         {
            return new CustomBinding();
         }

         return null;
      }
   }
}
