// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Leadtools.Medical.HL7.V2x.Models;
using Leadtools.Medical.HL7.V26.Messages;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Leadtools.Medical.HL7.V2x.Sender;

namespace HL7Messaging
{
   public class MessageModel
   {
      public IHL7MessageItem Message { get; private set; }
      public event EventHandler MessageChanged;

      bool _EnableEvents = true;

      private void Fire(EventHandler ev)
      {
         if (!_EnableEvents)
            return;
         if (ev != null)
            ev(null, null);
      }

      public void FireChanged()
      {
         Fire(MessageChanged);
      }

      public MessageModel()
      {
         Message = null;         
      }

      public string PipeMessage
      {
         get
         {
            try
            {
               if (null == Message)
                  throw new Exception();
               string pipe = SegmentStructureConverter.MessageToPipe(Message);
               return pipe.Replace("\r", Environment.NewLine);
            }
            catch 
            {
               return string.Empty;
            }
         }
      }

      public void LoadPipeMessageFile(string fileName)
      {
         string pipeMessage = File.ReadAllText(fileName);

         //basic verification
         if (string.IsNullOrEmpty(pipeMessage))
         {
            throw new Exception("File has no contents");
         }

         LoadPipeMessage(pipeMessage);
      }

      public void LoadPipeMessage(string pipeMessage)
      {
         Message = ParsePipeMessage(pipeMessage);
         
         Fire(MessageChanged);
      }
      
      public void MessageFromStruct(string name, string version)
      {
         Message = Leadtools.Medical.HL7.V2x.Models.MessageFactory.New(name, version);

         Leadtools.Medical.HL7.V2x.Models.MessageConstructor.CreateSegments(Message);
         Leadtools.Medical.HL7.V2x.Models.MessageConstructor.FillCommonMSH(Message, version);

         Fire(MessageChanged);
      }

      public void ADTA01Message(string PatientId, string PatientName, string PatientMiddleName, string PatientLastName)
      {
         Message = Leadtools.Medical.HL7.V2x.Models.MessageFactory.New("ADT_A01", "V26");

         {
            ADT_A01 msg = (ADT_A01)Message;
            Leadtools.Medical.HL7.V2x.Models.MessageConstructor.CreateSegments(msg);

            msg.MSH.Field_Separator.Value = "|";
            msg.MSH.Encoding_Characters.Value = "^~\\&";
            msg.MSH.Sending_Application.Value = "LTHL7Demo";
            msg.MSH.Sending_Facility.Value = "Leadtools";
            msg.MSH.Receiving_Application.Value = "LTHL7Demo";
            msg.MSH.Receiving_Facility.Value = "Leadtools";
            msg.MSH.Date_Time_of_Message.Value = MessageConstructor.CurTime();
            msg.MSH.Message_Type.MessageCode.Value = "ADT";
            msg.MSH.Message_Type.TriggerEvent.Value = "A01";
            msg.MSH.Message_Control_ID.Value = UniqueId.New;
            msg.MSH.Processing_ID.Value = "1";
            msg.MSH.Version_ID.VersionID.Value = "2.6";

            msg.PID.Patient_ID.IDNumber.Value = PatientId;
            msg.PID.Patient_Name[0].FamilyName.Value = PatientLastName;
            msg.PID.Patient_Name[0].GivenName.Value = PatientName;
            msg.PID.Patient_Name[0].SecondAndFurtherGivenNamesOrInitialsThereof.Value = PatientMiddleName;
         }

         Fire(MessageChanged);
      }

      public void ADTA01MessagePatientUpdate(string PatientId, string Sex, string PatientName, string PatientLastName)
      {
         Message = Leadtools.Medical.HL7.V2x.Models.MessageFactory.New("ADT_A01", "V26");

         {
            ADT_A01 msg = (ADT_A01)Message;
            Leadtools.Medical.HL7.V2x.Models.MessageConstructor.CreateSegments(msg);

            msg.MSH.Field_Separator.Value = "|";
            msg.MSH.Encoding_Characters.Value = "^~\\&";
            msg.MSH.Sending_Application.Value = "LTHL7Demo";
            msg.MSH.Sending_Facility.Value = "Leadtools";
            msg.MSH.Receiving_Application.Value = "LTHL7Demo";
            msg.MSH.Receiving_Facility.Value = "Leadtools";
            msg.MSH.Date_Time_of_Message.Value = MessageConstructor.CurTime();
            msg.MSH.Message_Type.MessageCode.Value = "ADT";
            msg.MSH.Message_Type.TriggerEvent.Value = "A01";
            msg.MSH.Message_Control_ID.Value = UniqueId.New;
            msg.MSH.Processing_ID.Value = "1";
            msg.MSH.Version_ID.VersionID.Value = "2.6";

            msg.PID.Patient_ID.IDNumber.Value = PatientId;
            msg.PID.Patient_Name[0].FamilyName.Value = PatientLastName;
            msg.PID.Patient_Name[0].GivenName.Value = PatientName;
            msg.PID.Administrative_Sex.Value = Sex;
         }

         Fire(MessageChanged);
      }

      private void ConfigMessageForSending(IHL7MessageItem Message, string Sending_Application, string Sending_Facility, string Receiving_Application, string Receiving_Facility)
      {
         HL7MessageItem msh = Message.Getter<HL7MessageItem>(0);
         if (!string.IsNullOrEmpty(Sending_Application))
         {            
            msh.Getter<Field>(2)[0].Value = Sending_Application;
         }
         if (!string.IsNullOrEmpty(Sending_Facility))
            msh.Getter<Field>(3)[0].Value = Sending_Facility;
         if (!string.IsNullOrEmpty(Receiving_Application))
            msh.Getter<Field>(4)[0].Value = Receiving_Application;
         if (!string.IsNullOrEmpty(Receiving_Facility))
            msh.Getter<Field>(5)[0].Value = Receiving_Facility;
      }

      public void SendMessage(ConnectionNode node)
      {
         ConfigMessageForSending(Message, node.ClientAppName, node.ClientFacility, node.RemoteAppName, node.RemoteFacility);

         string pipeMessage = SegmentStructureConverter.MessageToPipe(Message);

         IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(node.RemoteIP), node.RemotePort);

         using (TcpClient _client = new TcpClient())
         {
            _client.SendTimeout = node.Timeout;
            _client.ReceiveTimeout = node.Timeout;

            _client.Connect(EndPoint);

            using (HL7Response rsp = new HL7Response(_client) { WaitForReply = node.WaitForACK, EnvelopPrefix = InternalFormatter.StringToByteArray(node.MLPPrefix), EnvelopSuffix = InternalFormatter.StringToByteArray(node.MLPSuffix) })
            {
               rsp.Send(pipeMessage);

               if (node.WaitForACK)
               {
                  if (rsp.IsFailureCode)
                  {
                     throw new Exception(string.IsNullOrEmpty(rsp.TextMessage) ? "Unspecified error from server" : rsp.TextMessage);
                  }
               }
            }
         }
      }

      IHL7MessageItem ParsePipeMessage(string pipe)
      {
         PipeMessageConverter pmc = new PipeMessageConverter();
         MessageStructure ms = pmc.PipeMessageToMessageStructure(pipe);
         MessageStructureConverter msc = new MessageStructureConverter();

         Exception exParse = null;
         try
         {
            IHL7MessageItem msg = msc.MessageStructureToMessage(ms, new MessageStructureConverter.Options() { Add_NoneStandardSegmentToRoot = true, Ignore_NoneStandardSegment = true, Parse_RepeatableParentGroupFirst = true, Forgive_IncompleteMessage = true }).Message;
            return msg;
         }
         catch(Exception e)
         {
            exParse = e;
         }

         try
         {
            IHL7MessageItem msg = msc.MessageStructureToMessage(ms, new MessageStructureConverter.Options() { Add_NoneStandardSegmentToRoot = true, Ignore_NoneStandardSegment = true, Parse_RepeatableParentGroupFirst = false, Forgive_IncompleteMessage = true }).Message;
            return msg;
         }
         catch
         {
            throw exParse;
         }
      }

      void FillViewInfo(INodeItem nodeItem, NodeItemView tvc)
      {
         if (null == nodeItem)
            return;

         ISchemaItem schema = nodeItem.Schema;
         
         tvc.Name = schema.ItemName;
         tvc.Text = schema.ItemName;
         tvc.Tag = null;
         tvc.Model = this;

         if (schema.IsGroup || schema.IsMessage)
            tvc.Expand = true;
      }

      public NodeItemView BuildViewCtrl_Schema()
      {
         NodeItemView root = new NodeItemView();

         BuildViewCtrl_Schema(Message, root);

         if (root.Nodes.Count == 1)
         {
            return root.Nodes[0];
         }
         else
         {
            return root;
         }
      }

      void BuildViewCtrl_Schema(INodeItem nodeItem, NodeItemView node)
      {
         if (null == nodeItem)
         {
            return;
         }

         ISchemaItem item = nodeItem.Schema;
         NodeItemView subNode = null;

         if (!item.RepetitionContainerNode && (item.StructureDefOnlyNode||item.IsMessage))
         {
            if (null == item)
            {
               return;//dead end
            }

            subNode = new NodeItemView();

            FillViewInfo(nodeItem, subNode);
            BuildViewCtrl_Fields(nodeItem, subNode, false);

            node.Nodes.Add(subNode);
         }
         else
         {
            subNode = node;
         }

         foreach (INodeItem sub in nodeItem.Nodes)
         {
            BuildViewCtrl_Schema(sub, subNode);
         }
      }

      public NodeItemView BuildViewCtrl_All()
      {
         NodeItemView root = new NodeItemView();

         BuildViewCtrl_All(Message, root);

         if (root.Nodes.Count == 1)
         {
            return root.Nodes[0];
         }
         else
         {
            return root;
         }
      }
       
      void BuildViewCtrl_All(INodeItem nodeItem, NodeItemView node)
      {
         if (null == nodeItem)
         {
            return;
         }

         ISchemaItem item = nodeItem.Schema;
         NodeItemView subNode = null;

         bool IsSchemaItem = (!item.RepetitionContainerNode && (item.StructureDefOnlyNode || item.IsMessage)) ;
         bool IsContentItem = ((item.IsGroup && nodeItem.AnySubItemHasRepetition) || item.IsMessage || (!item.RepetitionContainerNode && !item.StructureDefOnlyNode));
         bool ParentContainsContentRep = false;
         
         if (nodeItem.ParentItem != null)
         {
            if (nodeItem.ParentItem.Schema.RepetitionContainerNode)
            {
               ParentContainsContentRep = nodeItem.ParentItem.Nodes.Count > 1;
            }
         }

         if ((IsSchemaItem && !ParentContainsContentRep)||IsContentItem)
         {
            if (null == item)
            {
               return;//dead end
            }

            subNode = new NodeItemView();

            FillViewInfo(nodeItem, subNode);
            BuildViewCtrl_Fields(nodeItem, subNode, false);

            node.Nodes.Add(subNode);
         }
         else
         {
            subNode = node;
         }

         foreach (INodeItem sub in nodeItem.Nodes)
         {
            BuildViewCtrl_All(sub, subNode);
         }
      }

      public NodeItemView BuildViewCtrl_Populated(bool bPopulatedFieldsOnly)
      {
         NodeItemView root = new NodeItemView();

         BuildViewCtrl_Populated(Message, root, bPopulatedFieldsOnly);

         if (root.Nodes.Count == 1)
         {
            return root.Nodes[0];
         }
         else
         {
            return root;
         }
      }

      void BuildViewCtrl_Populated(INodeItem nodeItem, NodeItemView node, bool bPopulatedFieldsOnly)
      {
         if (null == nodeItem)
         {
            return;
         }

         ISchemaItem item = nodeItem.Schema;
         NodeItemView subNode = null;

         if ((item.IsGroup && nodeItem.AnySubItemHasRepetition) || item.IsMessage || (!item.RepetitionContainerNode && !item.StructureDefOnlyNode))
         {
            if (null == item)
            {
               return;//dead end
            }

            subNode = new NodeItemView();

            FillViewInfo(nodeItem, subNode);
            BuildViewCtrl_Fields(nodeItem, subNode, bPopulatedFieldsOnly);

            node.Nodes.Add(subNode);
         }
         else
         {
            subNode = node;
         }

         foreach (INodeItem sub in nodeItem.Nodes)
         {
            BuildViewCtrl_Populated(sub, subNode, bPopulatedFieldsOnly);
         }
      }
      
      void BuildViewCtrl_Fields(INodeItem nodeItem, NodeItemView node, bool bPopulatedFieldsOnly)
      {
         for (int seq = 0; seq < nodeItem.Fields.Count; seq++)
         {
            if (!bPopulatedFieldsOnly)
            {
               if (nodeItem.Fields[seq].Repetitions.Count == 0)
               {
                  NodeItemView subNode = new NodeItemView();
                  subNode.Name = nodeItem.Schema.ItemName + "-" + (seq+1);
                  subNode.Text = nodeItem.Schema.ItemName + "-" + (seq+1);
                  subNode.Text += " (" + nodeItem.Fields[seq].FieldFactory.NameFromType + ")";
                  subNode.Value = "";
                  subNode.Tag = nodeItem.Fields[seq];
                  subNode.Model = this;
                  subNode.DataType = nodeItem.Fields[seq].FieldFactory.NameFromType;
                  subNode.NodeType = "field";
                  subNode.IsPopulated = false;
                                    
                  node.Nodes.Add(subNode);
               }
            }

            for (int rep = 0; rep < nodeItem.Fields[seq].Repetitions.Count; rep++)
            {
               bool subcomphasvalue = false;

               NodeItemView subNode = new NodeItemView();
               subNode.Name = nodeItem.Schema.ItemName + "-" + (seq+1);
               subNode.Text = nodeItem.Schema.ItemName + "-" + (seq+1);
               
               IField f = nodeItem.Fields[seq].Repetitions[rep];
               
               if (!f.IsEmpty)
               {
                  if (!f.HasSubComponents)
                     subNode.NodeType = "field";

                  subNode.IsPopulated = true;

                  if (rep > 0)
                     subNode.Text += "(rep " + rep + ")" + ": " + f.Value;
                  else
                     subNode.Text += ": " + f.Value;
                  subNode.Rep = rep;
                  subNode.Value = f.Value;
                  subNode.Tag = f;
                  subNode.Model = this;
               }

               if (f.HasSubComponents)
               {
                  //add parent's wholesome value
                  {
                     string DeepValue = f.DeepValue;
                     if (!string.IsNullOrEmpty(DeepValue))
                     {
                        subNode.IsPopulated = true;
                        if (rep > 0)
                           subNode.Text += "(rep " + rep + ")" + ": " + DeepValue;
                        else
                           subNode.Text += ": " + DeepValue;
                        subNode.Rep = rep;
                        subNode.Value = DeepValue;
                        subNode.Tag = f;
                        subNode.Model = this;
                     }
                  }

                  for (int subcomp = 0; subcomp < f.Components.Length; subcomp++)
                  {
                     NodeItemView subcompNode = new NodeItemView();
                     subcompNode.Name = nodeItem.Schema.ItemName + "-" + (seq + 1) + "-" + (subcomp + 1).ToString();
                     subcompNode.Text = nodeItem.Schema.ItemName + "-" + (seq + 1) + "-" + (subcomp + 1).ToString();
                     subcompNode.Tag = f.Components[subcomp];
                     subcompNode.Model = this;
                     
                     if (!f.Components[subcomp].IsEmpty)
                     {
                        subcompNode.NodeType = "field";
                        subcompNode.IsPopulated = true;

                        if (rep > 0)
                           subcompNode.Text += "(rep " + rep + ")" + ": " + f.Components[subcomp].Value;
                        else
                           subcompNode.Text += ": " + f.Components[subcomp].Value;
                        subcompNode.Rep = rep;
                        subcompNode.Value = f.Components[subcomp].Value;
                        subcompNode.Tag = f;
                        subcompNode.Model = this;
                        subcomphasvalue = true;
                     }
                     subNode.Nodes.Add(subcompNode);

                     //
                     if (f.Components[subcomp].HasSubComponents)
                     {
                        for (int subcomp1 = 0; subcomp1 < f.Components[subcomp].Components.Length; subcomp1++)
                        {
                           NodeItemView subcompNode1 = new NodeItemView();
                           subcompNode1.Name = nodeItem.Schema.ItemName + "-" + (seq + 1) + "-" + subcomp + "-" + subcomp1;
                           subcompNode1.Text = nodeItem.Schema.ItemName + "-" + (seq + 1) + "-" + subcomp + "-" + subcomp1;
                           subcompNode1.Tag = f.Components[subcomp].Components[subcomp1];
                           subcompNode1.Model = this;

                           if (!f.Components[subcomp].Components[subcomp1].IsEmpty)
                           {
                              subcompNode.NodeType = "field";
                              subcompNode.IsPopulated = true;

                              if (rep > 0)
                                 subcompNode.Text += "(rep " + rep + ")" + ": " + f.Components[subcomp].Components[subcomp1].Value;
                              else
                                 subcompNode.Text += ": " + f.Components[subcomp].Components[subcomp1].Value;
                              subcompNode.Rep = rep;
                              subcompNode.Value = f.Components[subcomp].Components[subcomp1].Value;
                              subcompNode.Tag = f;
                              subcompNode.Model = this;
                              subcomphasvalue = true;
                           }
                           subcompNode.Nodes.Add(subcompNode1);
                        }
                     }
                  }
               }
               
               subNode.Text += " (" + nodeItem.Fields[seq].FieldFactory.NameFromType + ")";
               subNode.DataType = nodeItem.Fields[seq].FieldFactory.NameFromType;
               if (!f.IsEmpty || !bPopulatedFieldsOnly || subcomphasvalue)
               {
                  node.Nodes.Add(subNode);
               }
            }
         }
      }
   }
}
