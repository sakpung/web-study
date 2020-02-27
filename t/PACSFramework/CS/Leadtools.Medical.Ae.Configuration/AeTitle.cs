// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.AddIn;
using System.Diagnostics;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using System.Net;
using Leadtools.Logging;

namespace Leadtools.Medical.Ae.Configuration
{   
   public class AeTitle : IAETitle
   {
      private IAeManagementDataAccessAgent _Agent;

      public AeTitle(IAeManagementDataAccessAgent agent)
      {
         _Agent = agent;
      }

      #region IAETitle Members

      public void Add(AeInfo aeInfo)
      {
         if (aeInfo is AeInfoExtended)
         {
            _Agent.Add(aeInfo as AeInfoExtended);
         }
         else
         {
            AeInfoExtended extended = new AeInfoExtended();

            extended.Address = aeInfo.Address;
            extended.AETitle = aeInfo.AETitle;
            extended.Port = aeInfo.Port;
            // extended.UseSecurePort = aeInfo.SecurePort != 0;
            extended.SecurePort = aeInfo.SecurePort;
            extended.ClientPortUsage = aeInfo.ClientPortUsage;
#if LEADTOOLS_V20_OR_LATER
            extended.LastAccessDate = aeInfo.LastAccessDate;
#endif
            _Agent.Add(extended);
         }
      }

      public AeInfo GetAeInfo(string AETitle)
      {
         AeInfo info = _Agent.GetAeTitle(AETitle);

         return info;
      }

      public List<AeInfo> GetAll()
      {         
         return _Agent.GetAeTitles().Cast<AeInfo>().ToList();
      }

      public void Remove(string AETitle)
      {
         _Agent.Remove(AETitle);
      }

      public void Update(string AETitle, AeInfo newInfo)
      {
         if (newInfo is AeInfoExtended)
         {
            _Agent.Update(AETitle, newInfo as AeInfoExtended);
         }
         else
         {
            AeInfoExtended extended = new AeInfoExtended();

            extended.Address = newInfo.Address;
            extended.AETitle = newInfo.AETitle;
            extended.Port = newInfo.Port;
            // extended.UseSecurePort = newInfo.SecurePort != 0;
            extended.ClientPortUsage = newInfo.ClientPortUsage;
            extended.SecurePort = newInfo.SecurePort;
#if LEADTOOLS_V20_OR_LATER
            extended.LastAccessDate = newInfo.LastAccessDate;
#endif
            _Agent.Update(AETitle, extended);
         }
      }

      public bool Validate(DicomClient client)
      {
         try
         {
            AeInfoExtended info = _Agent.GetAeTitle(client.AETitle);

            if (info != null)
            {
#if LEADTOOLS_V20_OR_LATER
               // Update dbo.AeInfo.LastAccessDate to Date.Now
               info.LastAccessDate = DateTime.Now;
               _Agent.Update(client.AETitle, info);
#endif

               if (!info.VerifyAddress)
                  return true;
               if (!info.VerifyMask)
               {
                  return ValidateIp(client, info);
               }
               else
               {
                  return ValidateSubnet(client, info);
               }
            }
         }
         catch (Exception e)
         {
            Logger.Global.Exception("AE Configuration", e);
         }

         return false;
      }

      #endregion

      private bool ValidateIp(DicomClient client, AeInfoExtended info)
      {
         IPAddress address = IPAddress.None;

         if (IPAddress.TryParse(info.Address, out address))
         {
            IPAddress peer = IPAddress.Parse(client.PeerAddress);

            // For an IPv6 address, if it is link local (starting with fe80::), then the digits after the % are the 'scope id'
            // Example:  13 is the 'scope id' for this address:    
            //    fe80::4881:55fb:faf2:d96%13
            // Clear the ScopeID for ivp6 before doing the compare
            if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
               address.ScopeId = 0;
            }
            
            if (peer.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
               peer.ScopeId = 0;
            }

            return address.Equals(peer);
         }
         else
         {
            IPAddress hostAddress;

            return ValidateHostname(client, info, out hostAddress);
         }         
      }

      private bool ValidateSubnet(DicomClient client, AeInfoExtended info)
      {
         IPAddress address = IPAddress.None;

         if (IPAddress.TryParse(info.Address, out address))
         {
            IPAddress peer = IPAddress.Parse(client.PeerAddress);
            IPAddress mask = IPAddress.Parse(info.Mask);

            return address.IsInSameSubnet(peer, mask);
         }
         else
         {
            IPAddress hostAddress;

            if(ValidateHostname(client,info,out hostAddress))
            {
               IPAddress peer = IPAddress.Parse(client.PeerAddress);
               IPAddress mask = IPAddress.Parse(info.Mask);

               return hostAddress.IsInSameSubnet(peer,mask);
            }
         }
         return false;
      }

      private bool ValidateHostname(DicomClient client, AeInfoExtended info, out IPAddress hostAddress)
      {
         IPAddress[] addresses = Dns.GetHostAddresses(info.Address);
         IPAddress peer = IPAddress.Parse(client.PeerAddress);

         hostAddress = IPAddress.None;
         foreach (IPAddress address in addresses)
         {
            if (peer.Equals(address))
            {
               hostAddress = address;
               return true;
            }
         }
         return false;
      }
   }
}
