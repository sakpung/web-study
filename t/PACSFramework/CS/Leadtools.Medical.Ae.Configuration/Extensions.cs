// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Leadtools.Medical.Ae.Configuration
{
   public static class Extensions
   {      
      public static IPAddress GetNetworkAddress(this IPAddress address, IPAddress subnetMask)
      {
         byte[] ipAdressBytes = address.GetAddressBytes();
         byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

         if (ipAdressBytes.Length != subnetMaskBytes.Length)
            throw new ArgumentException("Lengths of IP address and subnet mask do not match.");

         byte[] broadcastAddress = new byte[ipAdressBytes.Length];

         for (int i = 0; i < broadcastAddress.Length; i++)
         {
            broadcastAddress[i] = (byte)(ipAdressBytes[i] & (subnetMaskBytes[i]));
         }
         return new IPAddress(broadcastAddress);
      }

      public static bool IsInSameSubnet(this IPAddress address2, IPAddress address, IPAddress subnetMask)
      {
         IPAddress network1 = address.GetNetworkAddress(subnetMask);
         IPAddress network2 = address2.GetNetworkAddress(subnetMask);

         return network1.Equals(network2);
      }
   }
}
