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
using Leadtools.Medical.Worklist.AddIns.Configuration ;

namespace Leadtools.Medical.Worklist.AddIns.Controls
{
   public partial class WorklistConfigurationDialog : Form
   {
      public WorklistConfigurationDialog()
      {
         InitializeComponent();
      }

      public WorklistAddInsConfiguration AddInsSettings 
      {
         get
         {
            return addInConfiguration1.AddInsSettings ;
         }
         
         set
         {
            addInConfiguration1.AddInsSettings = value ;
         }
      }
      
      private void toolStripButton2_Click(object sender, EventArgs e)
      {
         DatabaseEditorDialog dbEditor ;
         
         
         dbEditor = new DatabaseEditorDialog ( ) ;
         
         dbEditor.ShowDialog ( ) ;
      }
   }
}
