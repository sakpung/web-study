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
using Leadtools.Medical.HL7.V2x.Models;

namespace HL7Messaging
{
   public partial class CreateMessageView : Form
   {
      public string SelectedMessage { get; set; }
      public string SelectedVersion { get; set; }

      public CreateMessageView()
      {
         InitializeComponent();
      }

      string GetSelectedVersion()
      {
         return comboBox1.SelectedItem.ToString();
      }

      void BuildVersion()
      {
         comboBox1.Items.Clear();
         comboBox1.Items.AddRange(HL7Package.EnumV2xVersions());
         comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
      }

      void BuildView()
      {
         treeView1.SuspendLayout();
         treeView1.Nodes.Clear();

         var all = HL7Package.EnumMessages(GetSelectedVersion());
         foreach (var msg in all)
         {
            TreeNode node = new TreeNode();

            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            node.Name = msg.Substring(msg.LastIndexOf('.') + 1);
            node.Text = msg.Substring(msg.LastIndexOf('.')+1);
            node.Tag = "message";

            treeView1.Nodes.Add(node);
         }         
      }

      private void CreateMessageView_Load(object sender, EventArgs e)
      {
         BuildVersion();
         BuildView();
      }

      private void ReadMessage()
      {
         if (treeView1.SelectedNode == null)
         {
            throw new Exception("Please select a message first");
         }

         SelectedMessage = treeView1.SelectedNode.Name;
         SelectedVersion = comboBox1.SelectedItem.ToString();

         if (string.IsNullOrEmpty(SelectedMessage))
         {
            throw new Exception("Invalid message selected");
         }
      }

      private void button2_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.None;
         try
         {            
            ReadMessage();
            this.DialogResult = DialogResult.OK;
            this.Close();
         }
         catch (System.Exception ex)
         {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void button1_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
      {
         BuildView();
      }
   }
}
