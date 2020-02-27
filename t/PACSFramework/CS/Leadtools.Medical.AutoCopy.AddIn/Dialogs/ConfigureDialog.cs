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
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.AeManagement.DataAccessLayer;

namespace Leadtools.Medical.AutoCopy.AddIn.Dialogs
{
   public partial class ConfigureDialog : Form
   {
      public ConfigureDialog()
      {
         InitializeComponent();
      }


      private void ConfigureDialog_Load(object sender, EventArgs e)
      {
         AddVersionInfo();
      }

      private void AddVersionInfo()
      {
         VersionInfoControl vi = new VersionInfoControl();

         vi.Dock = DockStyle.Fill;
         vi.Assembly = Assembly.GetExecutingAssembly();
         tabPageDetails.Controls.Add(vi);
      }
   }
}
