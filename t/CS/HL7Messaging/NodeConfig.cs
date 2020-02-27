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
using System.Text.RegularExpressions;
using System.Net;
using Leadtools.Medical.HL7.V2x.Models;

namespace HL7Messaging
{
   public partial class NodeConfig : Form
   {
      public ConnectionNode Node { get; set; }

      public NodeConfig()
      {
         Node = new ConnectionNode();
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      void OnError(Exception ex)
      {
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      static bool VerifyIP(string str)
      {
         if (string.IsNullOrEmpty(str))
            return false;
         var hst = Dns.GetHostEntry(str);
         if (hst.AddressList.Length == 0)
            return false;
         IPAddress ip = hst.AddressList[0];
         
         return true;
      }

      static bool VerifyPort(string str)
      {
         int port;
         if (int.TryParse(str, out port))
         {
            return (port >= 0 && port <= 65535);
         }
         return false;
      }

      static bool VerifyHex(string hex)
      {
         Int32 HexNumber;
         return Int32.TryParse(hex, System.Globalization.NumberStyles.HexNumber, null, out HexNumber);
      }

      private void InitialVerify()
      {
         if (!VerifyIP(textBox1.Text))
            throw new Exception("Invalid Remote IP specified");
         if (!VerifyPort(textBox5.Text))
            throw new Exception("Invalid Remote Port specified");
         if (!VerifyHex(textBox4.Text))
            throw new Exception("Invalid MLP prefix specified, use only hex values");
         if (!VerifyHex(textBox9.Text))
            throw new Exception("Invalid MLP suffix specified, use only hex values");
         if(string.IsNullOrEmpty(textBox8.Text))
            throw new Exception("Invalid Timeout specified");
      }

      private void button2_Click(object sender, EventArgs e)
      {
         try
         {
            InitialVerify();

            Node.Name = textBox10.Text;
            Node.RemoteIP = textBox1.Text;
            Node.RemotePort = int.Parse(textBox5.Text);
            Node.RemoteAppName = textBox2.Text;
            Node.RemoteFacility = textBox3.Text;
            Node.ClientAppName = textBox7.Text;
            Node.ClientFacility = textBox6.Text;
            Node.Timeout = int.Parse(textBox8.Text);
            Node.MessagingVersion = comboBox1.SelectedItem.ToString();
            Node.MLPPrefix = textBox4.Text;
            Node.MLPSuffix = textBox9.Text;
            Node.WaitForACK = checkBox1.Checked;
            
            this.DialogResult = DialogResult.OK;
            this.Close();
         }
         catch (System.Exception ex)
         {
            OnError(ex);
         }         
      }

      private void BuildView()
      {
         comboBox1.Items.Clear();
         comboBox1.Items.AddRange(HL7Package.EnumV2xVersions());
         comboBox1.SelectedIndex = comboBox1.Items.Count - 1;   
      }

      private void UpdateView()
      {
         if (null == Node)
            return;

         textBox10.Text = Node.Name;
         textBox1.Text = Node.RemoteIP;
         textBox5.Text = Node.RemotePort.ToString();
         textBox2.Text = Node.RemoteAppName ;
         textBox3.Text = Node.RemoteFacility ;
         textBox7.Text = Node.ClientAppName;
         textBox6.Text = Node.ClientFacility;
         textBox8.Text = Node.Timeout.ToString() ;
         if (!string.IsNullOrEmpty(Node.MessagingVersion))
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(Node.MessagingVersion);
         textBox4.Text = Node.MLPPrefix;
         textBox9.Text = Node.MLPSuffix;
         checkBox1.Checked = Node.WaitForACK;
      }

      private void NodeConfig_Load(object sender, EventArgs e)
      {
         BuildView();
         UpdateView();
      }
      
      private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
      {
         
      }

      private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
         {
            e.Handled = true;
         }
      }
   }
}
