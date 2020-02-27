// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HL7Messaging
{
   public partial class SendHl7MessageView : Form
   {
      public SendHl7MessageView()
      {
         InitializeComponent();
      }

      private void BuildView()
      {
         List<string> nodes = new List<string>();

         int i = 0;
         foreach (ConnectionNode node in ConnectionNodes.Instance().Nodes)
         {
            if (!string.IsNullOrEmpty(node.Name))
               nodes.Add(node.Name);
            else
               nodes.Add("(Unnamed) - " + (++i));
         }
         comboBox1.Items.Clear();
         comboBox1.Items.AddRange(nodes.ToArray());
         if (comboBox1.Items.Count>0)
            comboBox1.SelectedIndex = 0;
      }

      private void UpdateView()
      {
         button1.Enabled = (comboBox1.Items.Count > 0);
         button4.Enabled = (comboBox1.Items.Count > 0);
         button5.Enabled = (comboBox1.Items.Count > 0);
      }

      private void SendHl7MessageView_Load(object sender, EventArgs e)
      {
         ConnectionNodes.Instance().AddDefaults();
         BuildView();
         if (!string.IsNullOrEmpty(PreferredNode))
         {
            for (int index = 0; index < comboBox1.Items.Count; index++)
            {
               if (comboBox1.Items[index].ToString().ToLower().Contains(PreferredNode.ToLower()))
               {
                  comboBox1.SelectedIndex = index;
                  break;
               }
            }
         }
         UpdateView();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         try
         {
            Cursor.Current = Cursors.WaitCursor;
            var node = ConnectionNodes.Instance().Nodes[SelectedNode];
            Model.SendMessage(node);
            MessageBox.Show("HL7 Message was sent successfully");
         }
         catch (System.Exception ex)
         {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            Cursor.Current = Cursors.Default;
         }
      }

      private void button2_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();      
      }

      private void button3_Click(object sender, EventArgs e)
      {
         NewNode(null);
      }

      private void button4_Click(object sender, EventArgs e)
      {
         ConnectionNodes.Instance().Remove(comboBox1.SelectedIndex);
         BuildView();
         UpdateView();
      }

      private void button5_Click(object sender, EventArgs e)
      {
         if (ConnectionNodes.Instance().Nodes[SelectedNode].IsBuiltIn)
         {
            NewNode(ConnectionNodes.Instance().Nodes[SelectedNode]);
         }
         else
         {
            EditNode();
         }
      }

      private void NewNode(ConnectionNode nodeFrom)
      {
         NodeConfig nc = new NodeConfig();
         
         if (null == nodeFrom)
         {
            ConnectionNodeBuilder.Defaults(nc.Node);
         }
         else
         {
            nc.Node = nodeFrom.Clone();
            nc.Node.IsBuiltIn = false;
            nc.Node.Name = "New Node - " + Guid.NewGuid().ToString().Substring(0, 5);
         }

         if (nc.ShowDialog() == DialogResult.OK)
         {
            ConnectionNodes.Instance().Add(nc.Node);
            BuildView();
            if (comboBox1.Items.Count > 0)
               comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            UpdateView();
         }
      }

      private void EditNode()
      {
         NodeConfig nc = new NodeConfig();
         int selectedNode = SelectedNode;
         nc.Node = ConnectionNodes.Instance().Nodes[selectedNode];
         if (nc.ShowDialog() == DialogResult.OK)
         {
            BuildView();
            if (comboBox1.Items.Count > 0)
               comboBox1.SelectedIndex = selectedNode;
            UpdateView();
         }
      }

      public int SelectedNode 
      {
         get
         {
            if (comboBox1.Items.Count > 0)
               return comboBox1.SelectedIndex;
            else
               return -1;
         }
      }
      public MessageModel Model { get; set; }
      public string PreferredNode { get; set; }
   }
}
