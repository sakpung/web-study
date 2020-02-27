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
using System.Xml;

namespace JobProcessorAdministratorDemo
{
   public partial class CustomQueryDlg : Form
   {
      public CustomQueryDlg()
      {
         InitializeComponent();
      }

      private string _customQuery = String.Empty;
      public string CustomQuery
      {
         get { return _customQuery; }
         set { _customQuery = value; }
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         if (String.IsNullOrEmpty(_cmbCustomQuery.Text))
            MessageBox.Show("You must enter a query");
         else
         {
            try
            {
               //save new query so it can be loaded next time
               if (_cmbCustomQuery.Items.IndexOf(_cmbCustomQuery.Text) == -1)
               {
                  Properties.Settings.Default.CustomQueryHistory.Insert(0, _cmbCustomQuery.Text);
                  Properties.Settings.Default.Save();
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }

            _customQuery = _cmbCustomQuery.Text;
            this.DialogResult = DialogResult.OK;
         }
      }

      private void CustomQuery_Load(object sender, EventArgs e)
      {
         try
         {
            //Initialize string collection if it is null
            if (Properties.Settings.Default.CustomQueryHistory == null)
            {
               Properties.Settings.Default.CustomQueryHistory = new System.Collections.Specialized.StringCollection();
               Properties.Settings.Default.Save();
            }

            //load query history           
            foreach (string query in Properties.Settings.Default.CustomQueryHistory)
               _cmbCustomQuery.Items.Add(query);

            if (_cmbCustomQuery.Items.Count > 0)
               _cmbCustomQuery.SelectedIndex = 0;
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void _btnClearHistory_Click(object sender, EventArgs e)
      {
         try
         {
            _cmbCustomQuery.Items.Clear();
            Properties.Settings.Default.CustomQueryHistory.Clear();
            Properties.Settings.Default.Save();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }
   }
}
