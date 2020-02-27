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
using Leadtools.Medical.Winforms ;
using Leadtools.Medical.Storage.AddIns.Configuration ;


namespace Leadtools.Medical.Storage.AddIns.Controls
{
   public partial class AddInsConfigurationDialog : Form
   {
      public AddInsConfigurationDialog()
      {
         InitializeComponent();
      }
      
      private void DatabaseMangagerToolStripButton_Click(object sender, EventArgs e)
      {
         StorageDatabaseManagerDialog dbManager ;
         
         
         dbManager = new StorageDatabaseManagerDialog ( ) ;
                  
         dbManager.ShowDialog ( ) ;
      }

      private bool _canViewIodClasses = true;

      public bool CanViewIodClasses
      {
         get 
         { 
            return _canViewIodClasses; 
         }
         set 
         { 
            _canViewIodClasses = value; 
            this.AddInsConfiguration.CanViewIodClasses = _canViewIodClasses;
         }
      }
      

   }
}
