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
using Leadtools.Medical.DataAccessLayer;
using System.Configuration;

namespace CSCustomizingWorklistDAL.UI
{
   public partial class DatabaseStatus : UserControl
   {
      public DatabaseStatus()
      {
         InitializeComponent();
      }
      
      public string ConnectionString
      {
         get
         {
            return ConnectionStringTextBox.Text ;
         }
         
         set
         {
            ConnectionStringTextBox.Text = value ;
         }
      }
      
      public string ProviderName
      {
         get
         {
            return ProviderTextBox.Text ;
         }
         
         set
         {
            ProviderTextBox.Text = value ;
         }
      }
   }
}
