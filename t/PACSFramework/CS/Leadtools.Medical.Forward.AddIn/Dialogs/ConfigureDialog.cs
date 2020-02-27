// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using Leadtools.Dicom.AddIn.Controls;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Winforms.Forwarder;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;

namespace Leadtools.Medical.Forwarder.AddIn.Dialogs
{
   public partial class ConfigureDialog : Form
   {
      public ForwardManagerConfigurationView View
      {
         get
         {
            return forwardManager;
         }
      }

      public ConfigureDialog()
      {
         InitializeComponent();         
      }

      public ForwardOptions Clone(ForwardOptions options)
      {
         try
         {
            //
            // Don't serialize a null object, simply return the default for that object
            //

            if (Object.ReferenceEquals(options, null))
            {
               return null;
            }

            if (!options.GetType().IsSerializable)
            {
               throw new ArgumentException("The type must be serializable.", "source");
            }
            
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();

            using (stream)
            {
               formatter.Serialize(stream, options);
               stream.Seek(0, SeekOrigin.Begin);

               return (ForwardOptions)formatter.Deserialize(stream);
            }
         }
         finally
         {
            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
         }
      }

      Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
      {
         Assembly ayResult = null;
         string sShortAssemblyName = args.Name.Split(',')[0];
         Assembly[] ayAssemblies = AppDomain.CurrentDomain.GetAssemblies();

         foreach (Assembly ayAssembly in ayAssemblies)
         {
            if (sShortAssemblyName == ayAssembly.FullName.Split(',')[0])
            {
               ayResult = ayAssembly;
               break;
            }
         }
         return ayResult;
      }

      private void ConfigureDialog_Load(object sender, EventArgs e)
      {         
         AddVersionInfo();
         Initialize();                     
      }

      private void AddVersionInfo()
      {
         VersionInfoControl vi = new VersionInfoControl();

         vi.Dock = DockStyle.Fill;
         vi.Assembly = Assembly.GetExecutingAssembly();
         //tabPageDetails.Controls.Add(vi);
      }

      public void Initialize()
      {         
         //checkBoxAutoCopy.Checked = _Options.EnableAutoCopy;         
         //_ConfigView = new AeManagementDataAccessConfigurationView();
         //_AccessAgent = DataAccessFactory.GetInstance(_ConfigView).CreateDataAccessAgent<IAeManagementDataAccessAgent>();
         //LoadAeTitles();
         //checkBoxCustomAE.Checked = _Options.UseCustomAE;
         //textBoxCustomAE.Text = _Options.AutoCopyAE;
         //EnableAutoCopy();
      }      

      //private void LoadAeTitles()
      //{
      //   AeInfo[] aetitles = _AccessAgent.GetAeTitles();

      //   forwardManager.SetAeTitles(aetitles);
      //}

      private void AddToList(AeInfo info)
      {
         //ListViewItem item = new ListViewItem(info.AETitle);

         //item.SubItems.Add(info.Address);
         //item.SubItems.Add(info.Port.ToString());
         //item.Tag = info;
         //listViewAutoCopy.Items.Add(item);         
      }

      private void ConfigureDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (DialogResult == DialogResult.OK)
         {
            //_Options.EnableAutoCopy = checkBoxAutoCopy.Checked;
            //_Options.AutoCopyAE = textBoxCustomAE.Text;
            //_Options.UseCustomAE = checkBoxCustomAE.Checked;
            //_Options.AutoCopyThreads = Convert.ToInt32(numericUpDownThreads.Value);            
         }
      }      

      private void comboBoxSource_SelectionChangeCommitted(object sender, EventArgs e)
      {
         //AeInfo info = comboBoxSource.SelectedItem as AeInfo;

         //listViewAutoCopy.ItemChecked -= listViewAutoUpdate_ItemChecked;
         //listViewAutoCopy.Check(false);
         //try
         //{
         //   listViewAutoCopy.Enabled = checkBoxAutoCopy.Checked;            
         //   if (_SelectedItem != null)
         //   {
         //      listViewAutoCopy.Items.Insert(_SelectedIndex, _SelectedItem);
         //   }

         //   foreach (ListViewItem item in listViewAutoCopy.Items)
         //   {
         //      AeInfo i = item.Tag as AeInfo;

         //      if (i.Address == info.Address && i.AETitle == info.AETitle)
         //      {
         //         _SelectedItem = item;
         //         _SelectedIndex = listViewAutoCopy.Items.IndexOf(item);
         //         break;
         //      }
         //   }

         //   if (_SelectedItem != null)
         //   {
         //      listViewAutoCopy.Items.Remove(_SelectedItem);
         //   }
         //   GetRelatedAes(info);
         //}
         //finally
         //{
         //   listViewAutoCopy.ItemChecked += listViewAutoUpdate_ItemChecked;
         //}
      }            
   }
}
