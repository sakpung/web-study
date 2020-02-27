// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Leadtools.Medical.HL7.V2x.MLP;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace HL7Messaging
{
   [Serializable]
   public class ConnectionNode
   {
      public bool IsBuiltIn { get; set; }
      public string Name { get; set; }

      public string RemoteIP { get; set; }
      public int RemotePort { get; set; }
      public string RemoteAppName { get; set; }
      public string RemoteFacility { get; set; }

      public string ClientAppName { get; set; }
      public string ClientFacility { get; set; }

      public int Timeout { get; set; }
      public string MessagingVersion { get; set; }
      public string MLPPrefix { get; set; }
      public string MLPSuffix { get; set; }
      public bool WaitForACK { get; set; }

      public ConnectionNode Clone()
      {
         return new ConnectionNode()
         {
            IsBuiltIn = IsBuiltIn,
            Name = Name,
            RemoteIP = RemoteIP,
            RemotePort = RemotePort,
            RemoteAppName = RemoteAppName,
            RemoteFacility = RemoteFacility,
            ClientAppName = ClientAppName,
            ClientFacility = ClientFacility,
            Timeout = Timeout,
            MessagingVersion = MessagingVersion,
            MLPPrefix = MLPPrefix,
            MLPSuffix = MLPSuffix,
            WaitForACK = WaitForACK
         };
      }
   }

   class InternalFormatter
   {
      public static byte[] StringToByteArray(string hex)
      {
         if (hex.Length % 2 == 1)
            hex = '0' + hex;
         hex = hex.ToUpper();
         byte[] arr = new byte[hex.Length >> 1];

         for (int i = 0; i < (hex.Length >> 1); ++i)
         {
            arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
         }

         return arr;
      }

      public static int GetHexVal(char hex)
      {
         int val = (int)hex;
         //For uppercase A-F letters:
         return val - (val < 58 ? 48 : 55);
         //For lowercase a-f letters:
         //return val - (val < 58 ? 48 : 87);
      }

      public static string ToHexString(byte[] bb)
      {
         string hex = "";
         foreach (var b in bb)
            hex += b.ToString("X2");
         return hex;
      }
   }

   public class ConnectionNodeBuilder
   {
      static public ConnectionNode Defaults(ConnectionNode node)
      {
         node.Name = "";
         node.RemoteIP = "127.0.0.1";
         node.RemotePort = 6790;
         node.MLPPrefix = InternalFormatter.ToHexString(MLPEnvelope.Envelop_Header);
         node.MLPSuffix = InternalFormatter.ToHexString(MLPEnvelope.Envelop_Trailer);
         node.Timeout = 0;
         node.WaitForACK = true;
         node.ClientFacility = "LEAD Tech";
         node.ClientAppName = "LEADTOOLS HL7 Sender";
         return node;
      }

      static public ConnectionNode MWL(ConnectionNode node)
      {
         node.IsBuiltIn = true;
         node.Name = "[Demo] Storage Server's MWL Plug-in";
         node.RemoteIP = "127.0.0.1";
         node.RemotePort = 6788;
         node.MLPPrefix = InternalFormatter.ToHexString(MLPEnvelope.Envelop_Header);
         node.MLPSuffix = InternalFormatter.ToHexString(MLPEnvelope.Envelop_Trailer);
         node.Timeout = 0;
         node.WaitForACK = true;
         return node;
      }

      static public ConnectionNode PatientUpdate(ConnectionNode node)
      {
         node.IsBuiltIn = true;
         node.Name = "[Demo] Storage Server's Patient Update Plug-in";
         node.RemoteIP = "127.0.0.1";
         node.RemotePort = 6787;
         node.MLPPrefix = InternalFormatter.ToHexString(MLPEnvelope.Envelop_Header);
         node.MLPSuffix = InternalFormatter.ToHexString(MLPEnvelope.Envelop_Trailer);
         node.Timeout = 0;
         node.WaitForACK = true;
#if FOR_WIN64
         node.ClientAppName = "L20_CLIENT64";
#else
         node.ClientAppName = "L20_CLIENT32";
#endif
         return node;
      }
   }

   [Serializable]
   public class ConnectionNodes
   {
      static ConnectionNodes _instance = null;
      public static ConnectionNodes Instance()
      {
         if (_instance == null)
         {
            _instance = new ConnectionNodes();
         }
         return _instance;
      }

      public List<ConnectionNode> Nodes { get; set; }

      public ConnectionNodes()
      {
         Nodes = new List<ConnectionNode>();
         Reset();
      }
      
      public void AddDefaults()
      {
         Add(ConnectionNodeBuilder.PatientUpdate(new ConnectionNode()));
         Add(ConnectionNodeBuilder.MWL(new ConnectionNode()));
      }

      public int Find(string name)
      {
         if (string.IsNullOrEmpty(name))
            return -1;

         for (int index = 0; index < Nodes.Count; index++)
         {
            if (0 == string.Compare(Nodes[index].Name, name))
            {
               return index;
            }
         }

         return -1;
      }

      public void Add(ConnectionNode node)
      {
         int index = Find(node.Name);
         if (index >= 0)
         {
            Nodes.Insert(index, node.Clone());
            Nodes.RemoveAt(index + 1);
         }
         else
         {
            Nodes.Add(node.Clone());
         }
      }

      public void Remove(int index)
      {
         if (index >= 0 && index< Nodes.Count)
         {
            Nodes.RemoveAt(index);
         }         
      }

      public void Reset()
      {
         Nodes.Clear();
         AddDefaults();
      }

      public void Load(string fileName)
      {
         if (!File.Exists(fileName))
            return;
         using (var file = new StreamReader(fileName))
         {
            XmlSerializer ser = new XmlSerializer(typeof(ConnectionNodes));
            ConnectionNodes cns = (ConnectionNodes)ser.Deserialize(file);
            Reset();
            foreach (ConnectionNode cn in cns.Nodes)
            {
               Add(cn);
            }
         }
      }

      public void Save(string fileName)
      {
         using (var file = new StreamWriter(fileName))
         {
            XmlSerializer ser = new XmlSerializer(typeof(ConnectionNodes));
            ser.Serialize(file, this);            
         }
      }
   }
}

