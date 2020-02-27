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

namespace Leadtools.Medical.SearchOtherPatientId.Addin.Dialogs
{
   public partial class ConfigureDialog : Form
   {
      public ConfigureDialog()
      {
         InitializeComponent();
      }

      public bool UseOtherPatientId
      {
         get
         {
            return checkBoxUseOtherPatientId.Checked;
         }
         set
         {
            checkBoxUseOtherPatientId.Checked = value;
         }
      }
   }
}
