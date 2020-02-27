// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn.Common;

#if DNXCORE50
using Leadtools.Core;
#endif

namespace Leadtools.Medical.AeManagement.DataAccessLayer
{

   public class ClientInformation
   {
      public ClientInformation()
      {
         Client = new AeInfoExtended();
         Permissions = new List<string>();
      }

      public ClientInformation(ClientInformation ci)
      {
         this.Client = new AeInfoExtended(ci.Client);
         this.Permissions = new List<string>(ci.Permissions);
      }

      public ClientInformation(AeInfoExtended client, string[] permissions)
      {
         if (client == null)
            Client = new AeInfoExtended();
         else
         Client = client;

         if (permissions == null)
            Permissions = new List<string>();
         else
         Permissions = new List<string>(permissions);
      }

      public void CopyTo(ClientInformation ci)
      {
         ci.Permissions = new List<string>(this.Permissions);
         ci.Client = new AeInfoExtended(this.Client);
      }

      public bool Equals(ClientInformation ci)
      {
         if (!ci.Client.Equals(Client))
            return false;

         if (!Permissions.SequenceEqual(ci.Permissions))
            return false;

         return true;
      }

      public AeInfoExtended Client { get; private set; }
      public List<string> Permissions { get; private set; }
   }

   [Serializable]
   public class AeInfoExtended : AeInfo
   {
      public AeInfoExtended()
      {
         ClientPortUsage = ClientPortUsageType.Unsecure;
#if LEADTOOLS_V20_OR_LATER
         LastAccessDate = DateTime.Now;
#endif
      }
      
      public AeInfoExtended(string aeTitle, string address, int port)
      {
         AETitle = aeTitle;
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
         FriendlyName = string.Empty;
#endif
         Address = address;
         Port = port;
         SecurePort = 0;
         Mask = string.Empty;
         VerifyAddress = false;
         VerifyMask = false;
         // UseSecurePort = false;
         ClientPortUsage = ClientPortUsageType.Unsecure;
#if LEADTOOLS_V20_OR_LATER
         LastAccessDate = DateTime.Now;
#endif
      }

      public AeInfoExtended(AeInfoExtended info)
      {
         AETitle = info.AETitle;
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
         FriendlyName = info.FriendlyName;
#endif
         Address = info.Address;
         Port = info.Port;
         SecurePort = info.SecurePort;
         Mask = info.Mask;
         VerifyAddress = info.VerifyAddress;
         VerifyMask = info.VerifyMask;

         // deprecated -- not used
         // UseSecurePort = info.UseSecurePort;

         ClientPortUsage = info.ClientPortUsage;
#if LEADTOOLS_V20_OR_LATER
         LastAccessDate = info.LastAccessDate;
#endif
      }

      void CopyTo(AeInfoExtended info)
      {
         info.AETitle = AETitle;
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
         info.FriendlyName = FriendlyName;
#endif
         info.Address = Address;
         info.Port = Port;
         info.SecurePort = SecurePort;
         info.Mask = Mask;
         info.VerifyAddress = VerifyAddress;
         info.VerifyMask = VerifyMask;

         // deprecated -- not used
         // info.UseSecurePort = UseSecurePort;
         info.ClientPortUsage = ClientPortUsage;
#if LEADTOOLS_V20_OR_LATER
         info.LastAccessDate = LastAccessDate;
#endif
      }

      public bool Equals(AeInfoExtended aeInfoExtended)
      {
         if (!base.Equals(aeInfoExtended))
            return false;

         if (aeInfoExtended.Mask != Mask)
            return false;

         // deprecated -- not used
         //if (aeInfoExtended.UseSecurePort != UseSecurePort)
         //   return false;

         if (aeInfoExtended.VerifyAddress != VerifyAddress)
            return false;

         if (aeInfoExtended.VerifyMask != VerifyMask)
            return false;

         if (aeInfoExtended.ClientPortUsage != ClientPortUsage)
            return false;

         return true;
      }


      public bool VerifyAddress { get; set; }
      public string Mask { get; set; }
      public bool VerifyMask { get; set; }

      // deprecated -- not used
      // public bool UseSecurePort { get; set; }

      public override string ToString()
      {
         return AETitle;
      }
   }


   [Serializable]
   public class ClientInformationList
   {
      public ClientInformationList()
      {
         _clientDictionary = new Dictionary<string, ClientInformation>(StringComparer.CurrentCultureIgnoreCase);
      }

      public ClientInformationList(ClientInformationList list)
      {
         this._clientDictionary = new Dictionary<string, ClientInformation>(list._clientDictionary, StringComparer.CurrentCultureIgnoreCase);
      }

      public void CopyTo(ClientInformationList list)
      {
         list.ClientDictionary = new Dictionary<string, ClientInformation>(this.ClientDictionary, StringComparer.CurrentCultureIgnoreCase);
      }


      [XmlIgnore]
      private Dictionary<string, ClientInformation> _clientDictionary = new Dictionary<string, ClientInformation>(StringComparer.CurrentCultureIgnoreCase);

      [XmlIgnore]
      public Dictionary<string, ClientInformation> ClientDictionary
      {
         get { return _clientDictionary; }
         set { _clientDictionary = value; }
      }

      [XmlElement("Client")]
      public ClientInformation[] Items
      {
         get
         {
            ClientInformation[] items = new ClientInformation[_clientDictionary.Count];
            _clientDictionary.Values.CopyTo(items, 0);
            return items;
         }
         set
         {
            if (value == null) return;
            ClientInformation[] items = value;
            _clientDictionary.Clear();
            foreach (ClientInformation item in items)
               _clientDictionary.Add(item.Client.AETitle, item);
         }
      }

      //public void AddItems(AeInfoExtended[] aeInfoExtendedArray)
      //{
      //   ClientInformation ci;
      //   foreach (AeInfoExtended aeInfoExtended in aeInfoExtendedArray)
      //   {
      //      string aeTitle = aeInfoExtended.AETitle.Trim();
      //      if (!ClientDictionary.TryGetValue(aeTitle, out ci))
      //      {
      //         ci = new ClientInformation(aeInfoExtended, null);
      //         ClientDictionary.Add(ci.Client.AETitle, ci);

      //         // add permissions here
      //      }
      //   }
      //}

      //private ClientInformation[] clients = 
      //{ 
      //   new ClientInformation("Client1", "192.168.0.1", false, "255.255.255.0", false, 101, 2762,  true, false, false, false, false, false),
      //   new ClientInformation("Client2", "192.168.0.2", true, "255.255.255.0", true, 102, 2762,  false, true, false, false, false, false),
      //   new ClientInformation("Client3", "192.168.0.3", false, "255.255.255.0", false, 103, 2762,  false, false, true, false, false, false),
      //   new ClientInformation("Client4", "192.168.0.4", false, "255.255.255.0", false, 104, 2762,  false, false, false, true, false, false),
      //   new ClientInformation("Client5", "192.168.0.5", false, "255.255.255.0", false, 105, 2762,  false, false, false, false, true, false),
      //   new ClientInformation("Client6", "192.168.0.6", false, "255.255.255.0", false, 106, 2762,  false, false, false, false, false, true),
      //};

      //public void Default()
      //{
      //   _clientDictionary.Clear();
      //   foreach (ClientInformation ci in clients)
      //   {
      //      _clientDictionary.Add(ci.Client.AETitle, ci);
      //   }
      //}

      //public void Save(string outFile)
      //{
      //   try
      //   {
      //      // Serialization
      //      XmlSerializer s = new XmlSerializer(typeof(ClientInformationList));
      //      TextWriter w = new StreamWriter(outFile);
      //      s.Serialize(w, this);
      //      w.Close();
      //   }
      //   catch (Exception)
      //   {
      //      MessageBox.Show("Unable to save file:\r\n" + outFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //   }
      //}

      //public void Load(string inFile)
      //{
      //   if (File.Exists(inFile))
      //   {
      //      try
      //      {
      //         // Serialization
      //         XmlSerializer s = new XmlSerializer(typeof(ClientInformationList));
      //         TextReader r = new StreamReader(inFile);

      //         ClientInformationList clientList = (ClientInformationList)s.Deserialize(r);
      //         Items = clientList.Items;
      //         _clientDictionary.Clear();
      //         foreach (ClientInformation ci in clientList.Items)
      //            _clientDictionary.Add(ci.Client.AETitle, ci);

      //         //this.Items = (PresentationContextEntry[])s.Deserialize(r);
      //         r.Close();
      //      }
      //      catch (Exception)
      //      {
      //         MessageBox.Show("Unable to load file:\r\n" + inFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //      }

      //   }
      //   else
      //   {
      //      Default();
      //   }
      //}
   }

}
