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
   public partial class PatientUpdateView : Form
   {
      public string ID { get; set; }
      public string Sex { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }

      public PatientUpdateView()
      {
         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         comboBox1.SelectedIndex = 0;
      }


      private void ShowRequiredFields()
      {
         MessageBox.Show(this, "Please supply the patient's id and all the other fields", "Missing Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      private void button1_Click(object sender, EventArgs e)
      {
         ID = textBox1.Text;
         Sex = comboBox1.SelectedItem.ToString();
         FirstName = textBox5.Text;
         LastName = textBox3.Text;

         if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(Sex) || string.IsNullOrEmpty(LastName))
         {
            ShowRequiredFields();
            return;
         }

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void button2_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }
   }
}
