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
using Leadtools.Medical.Worklist.AddIns.Configuration;

namespace Leadtools.Medical.Worklist.AddIns.Controls
{
   public partial class DatabaseEditorDialog : Form
   {
      public DatabaseEditorDialog()
      {
         InitializeComponent();
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            this.Close ( ) ;
         }
         catch ( Exception )
         {}
      }

      private void worklistAddToolStripMenuItem_Click(object sender, EventArgs e)
      {
         WorklistConfigurationDialog configuration ;
         
         
         configuration = new WorklistConfigurationDialog ( ) ;
         
         if ( null != AddInsSettings ) 
         {
            configuration.AddInsSettings = AddInsSettings ;
         }
         
         configuration.ShowDialog ( ) ; 
      }
      
      WorklistAddInsConfiguration _settings ;

      public WorklistAddInsConfiguration AddInsSettings
      { 
         get
         {
            return _settings ;
         } 
         
         set
         {
            _settings = value ;
         }
      }
   }
}
