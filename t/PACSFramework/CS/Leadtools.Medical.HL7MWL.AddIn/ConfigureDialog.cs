// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   public partial class ConfigureDialog : Form
   {
      public ConfigureDialog()
      {
         InitializeComponent();
      }

      private void ConfigureDialog_Load(object sender, EventArgs e)
      {
         textBox1.Text = HL7ServerMWL.HL7Options.HL7IPAddress;
         textBox2.Text = HL7ServerMWL.HL7Options.HL7Port.ToString();
         checkBox1.Checked = HL7ServerMWL.HL7Options.Autostart;
         checkBox2.Checked = HL7ServerMWL.HL7Options.HandleDuplicates;
      }

      private void button2_Click(object sender, EventArgs e)
      {
         var Autostart = checkBox1.Checked;
         var Graceful = checkBox2.Checked;
         var HL7IPAddress = textBox1.Text;
         var HL7Port = 0;
         int port = 0;
         if (int.TryParse(textBox2.Text, out port))
         {
            HL7Port = port;
         }

         if (HL7ServerMWL.HL7Options.Autostart != Autostart ||
            HL7ServerMWL.HL7Options.HandleDuplicates != Graceful||
         HL7ServerMWL.HL7Options.HL7IPAddress != HL7IPAddress ||
         HL7ServerMWL.HL7Options.HL7Port != HL7Port)
         {
            HL7ServerMWL.HL7Options.Autostart = Autostart;
            HL7ServerMWL.HL7Options.HandleDuplicates = Graceful;
            HL7ServerMWL.HL7Options.HL7IPAddress = HL7IPAddress;
            HL7ServerMWL.HL7Options.HL7Port = HL7Port;

            MessageBox.Show("Please restart the hosting server in order for the changes to be applied");
         }

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }
   }
}
