// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Xml;

namespace HL7Messaging
{   
   [Serializable()]
   public class NodeItemView : IEnumerable
   {
      public NodeItemView()
      {
         Nodes = new List<NodeItemView>();
         Expand = false;
         Tag = null;
         Model = null;
      }

      public IEnumerator GetEnumerator()
      {
         return Nodes.GetEnumerator();
      }

      public List<NodeItemView> Nodes { get; set; }

      public string Name { get; set; }
      public string DataType { get; set; }
      public string NodeType { get; set; }
      public bool IsPopulated { get; set; }
      public string Value { get; set; }
      public int Rep { get; set; }

      public string Text { get; set; }
      public object Tag { get; set; }
      public object Model { get; set; }
      public bool Expand { get; set; }

      private XmlElement ThisToXML(XmlDocument doc)
      {
         if (string.IsNullOrEmpty(Name))
         {
            return null;
         }

         XmlElement XMLNode = doc.CreateElement(Name);

         if (!string.IsNullOrEmpty(Value))
         {
            XMLNode.InnerText = Value;
         }         

         for (int index = 0; index < Nodes.Count; index++)
         {
            XMLNode.AppendChild(Nodes[index].ThisToXML(doc));
         }

         return XMLNode;
      }

      public XmlDocument ToXML()
      {
         XmlDocument doc = new XmlDocument();

         XmlElement XMLNode = ThisToXML(doc);

         if (null != XMLNode)
         {
            doc.AppendChild(XMLNode);
         }

         return doc;
      }
   }
}
