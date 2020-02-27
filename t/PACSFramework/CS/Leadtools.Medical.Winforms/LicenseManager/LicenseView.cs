// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Interfaces;
using System.Management;
using System.Security.Cryptography;

namespace Leadtools.Medical.Winforms.LicenseManager
{
   public partial class LicenseView : UserControl
   {
      private ILicense _License;

      public event EventHandler<OpenLicenseEventArgs> OpenLicense;
      public event EventHandler<EventArgs> RemoveLicense;

      protected void OnOpenLicense(string filename)
      {
         if (OpenLicense != null)
         {
            OpenLicenseEventArgs e = new OpenLicenseEventArgs(filename);

            OpenLicense(this, e);            
         }         
      }
      
      protected void OnRemoveLicense()
      {
         if (RemoveLicense != null)
         {
            RemoveLicense(this, new EventArgs());
         }
      }

      public LicenseView()
      {
         InitializeComponent();
      }

      private void buttonOpenLicense_Click(object sender, EventArgs e)
      {
         if (openFileDialog.ShowDialog(this) == DialogResult.OK)
         {
            OnOpenLicense(openFileDialog.FileName);            
         }
      }
      
      private void buttonRemoveLicense_Click(object sender, EventArgs e)
      {
         if (DialogResult.Yes == MessageBox.Show(this, "Are you sure you want to quit using the current license file?", "License File", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
         {
            OnRemoveLicense();
         }
      }

      public void SetLicense(string licenseFile, ILicense license)
      {
         _License = license;
         if (_License != null)
            Update(licenseFile);
         else
            Clear();
      }

      public void SetHardwareCodes(string[] codes)
      {
         int count = 1;

         listViewCodes.Items.Clear();
         foreach (string code in codes)
         {
            string hardware = string.Format("HWID{0}", count);            
            ListViewItem item = listViewCodes.Items.Add(hardware);

            item.SubItems.Add(code);
            count++;
         }
      }

      public void Update(string licenseFile)
      {
         textBoxFileName.Text = licenseFile;
         this.buttonRemoveLicense.Enabled = !string.IsNullOrEmpty(licenseFile);
         textBoxMan.Text = _License.Manufacturer;
         textBoxCustomer.Text = _License.Customer;
         textBoxProduct.Text = _License.Product;
         this.listFeatures.Items.Clear();
         foreach (IFeature current in _License.Features)
         {
            ListViewItem listViewItem = new ListViewItem(current.Id, 0);

            listViewItem.SubItems.Add(current.Description);
            listViewItem.SubItems.Add(current.Type.ToString());
            listViewItem.SubItems.Add(current.Expiration.HasValue?current.Expiration.Value.ToShortDateString():String.Empty);
            listViewItem.SubItems.Add(current.Counter.ToString());
            listViewItem.SubItems.Add(current.AdditionalInfo);
            this.listFeatures.Items.Add(listViewItem);
         }
      }

      public void Clear()
      {
         textBoxFileName.Text = string.Empty;
         textBoxMan.Text = string.Empty;
         textBoxCustomer.Text = string.Empty;
         textBoxProduct.Text = string.Empty;        
         listFeatures.Items.Clear();         
      }

      private void buttonCopy_Click(object sender, EventArgs e)
      {
         CopyToClipboard();
      }
     
      private void listViewCodes_DoubleClick(object sender, EventArgs e)
      {
         CopyToClipboard();
      }

      private void CopyToClipboard()
      {
         if (listViewCodes.SelectedItems.Count == 1)
         {
            StringBuilder buffer = new StringBuilder();
            ListViewItem item = listViewCodes.SelectedItems[0];

            buffer.Append(item.Text);
            buffer.Append(":");
            buffer.Append(item.SubItems[1].Text);
            Clipboard.SetText(buffer.ToString());
            MessageBox.Show(this,buffer.ToString(), "Hardware code copied to clipboard", MessageBoxButtons.OK);
         }
      }
   }
}
