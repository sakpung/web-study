// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace Leadtools.Demos.StorageServer.DataTypes
{
   public class MachineIDs
   {
      static MachineIDs _ins = new MachineIDs();

      public static MachineIDs Instance
      {
         get
         {
            return _ins;
         }
      }

      private List<string> _sMACAddress = null;
      private List<string> _sHDSerial = null;
      private string _sCPUId = null;

      public List<string> MACAddress
      {
         get
         {
            if (null == _sMACAddress)
               _sMACAddress = GetMACAddress();
            return _sMACAddress;
         }
      }

      public List<string> HDSerial
      {
         get
         {
            if (null == _sHDSerial)
               _sHDSerial = GetHDSerial(true);
            return _sHDSerial;
         }
      }

      public string CPUId
      {
         get
         {
            if (null == _sCPUId)
               _sCPUId = GetCPUId();
            return _sCPUId;
         }
      }

      private List<string> GetHDSerial(bool fFirstHDOnly)
      {
         List<string> HDSerialsList = new List<string>();
         MachineIDs m = MachineIDs.Instance;
         ManagementScope myScope =
         new ManagementScope("root\\CIMV2");
         SelectQuery q = new SelectQuery("Win32_LogicalDisk");
         ManagementObjectSearcher s = new ManagementObjectSearcher(myScope, q);

         foreach (ManagementObject disk in s.Get())
         {
            try
            {
               ManagementObject dsk = new ManagementObject(disk.ToString());
               dsk.Get();
               string volumeSerial = dsk["VolumeSerialNumber"].ToString();
               HDSerialsList.Add(volumeSerial);

               if (fFirstHDOnly)
               {
                  break;
               }
            }
            catch
            {
            }
         }
         return HDSerialsList;
      }

      /// <summary>
      /// this function is expensive
      /// </summary>
      /// <returns></returns>
      private string GetCPUId()
      {
         string cpuInfo = string.Empty;
         ManagementClass mc = new ManagementClass("win32_processor");
         ManagementObjectCollection moc = mc.GetInstances();

         foreach (ManagementObject mo in moc)
         {
            if (cpuInfo == "")
            {
               //Get only the first CPU's ID
               cpuInfo = mo.Properties["processorID"].Value.ToString();
               break;
            }
         }
         return cpuInfo;
      }

      private List<string> GetMACAddress()
      {
         List<string> MACAddressList = new List<string>();
         ManagementObjectSearcher searcher = new ManagementObjectSearcher("select MACAddress from Win32_NetworkAdapter");

         try
         {
            foreach (ManagementObject share in searcher.Get())
            {
               foreach (PropertyData PD in share.Properties)
               {
                  if (PD.Value != null && PD.Value.ToString() != "")
                  {
                     switch (PD.Value.GetType().ToString())
                     {
                        case "System.String[]":
                           string[] str = (string[])PD.Value;

                           string str2 = "";
                           foreach (string st in str)
                              str2 += st + " ";

                           MACAddressList.Add(str2);

                           break;
                        case "System.UInt16[]":
                           ushort[] shortData = (ushort[])PD.Value;


                           string tstr2 = "";
                           foreach (ushort st in shortData)
                              tstr2 += st.ToString() + " ";

                           MACAddressList.Add(tstr2);

                           break;

                        default:
                           MACAddressList.Add(PD.Value.ToString());
                           break;
                     }
                  }
               }
            }
         }
         catch
         {
         }

         return MACAddressList;
      }

      public MachineIDs()
      {
      }
   }
}
