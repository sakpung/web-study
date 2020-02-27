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
using Leadtools.Forms.Recognition;
using System.IO;
using Leadtools.Demos;

namespace FormsDemo
{
   public partial class MasterFormProperties : Form
   {
      public MasterFormProperties(FormRecognitionProperties masterFormProps, string workingDir)
      {
         InitializeComponent();

         this.Text = "\"" + masterFormProps.Name + "\"" + DemosGlobalization.GetResxString(GetType(), "Resx_Properties");

         _txtName.Text = masterFormProps.Name;
         _txtCreated.Text = masterFormProps.CreationTime.ToLongDateString();
         _txtModified.Text = masterFormProps.LastModificationTime.ToLongDateString();
         _txtAccessed.Text = masterFormProps.LastAccessTime.ToLongDateString();
         string fName = Path.Combine(workingDir, masterFormProps.Name + ".bin");
         _txtFormAttributes.Text = fName;
         fName = Path.Combine(workingDir, masterFormProps.Name + ".xml");
         _txtFields.Text = File.Exists(fName) ? fName : "NA";
         fName = Path.Combine(workingDir, masterFormProps.Name + ".tif");
         _txtImage.Text = File.Exists(fName) ? fName : "NA";
      }
   }
}
