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
using System.Xml ;
using System.Xml.Schema ;
using System.Configuration ;
using Leadtools.Dicom.Scp.Command ;
using Leadtools.Medical.Storage.AddIns.Configuration ;
using Leadtools.Demos;
using Leadtools.Medical.Winforms;

#if (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.Winforms.Anonymize;
using Leadtools.Medical.Winforms.DatabaseManager;
#endif

namespace Leadtools.Medical.Storage.AddIns
{
   public partial class AddInsConfiguration : UserControl
   {
      public AddInsConfiguration ( )
      {
         InitializeComponent ( ) ;
      }

      private void AddInsConfiguration_Load(object sender, EventArgs e)
      {
         storageOptionsView1.Dock = DockStyle.Fill;
         queryOptionsView1.Dock = DockStyle.Fill;
         storageClassesTabControl1.Dock = DockStyle.Fill;

#if (LEADTOOLS_V19_OR_LATER)
         databaseManagerOptionsView1.Dock = DockStyle.Fill;
         anonymizeOptionsView1.Dock = DockStyle.Fill;
#endif // #if (LEADTOOLS_V19_OR_LATER)

         MakeInvisible();
      }

      
      public QueryOptionsView QueryOptionsView
      {
         get
         {
            return queryOptionsView1;
         }
      }
      
      public StorageClassesTabControl StorageClassesTabControl
      {
         get
         {
            return storageClassesTabControl1;
         }
      }
      
      public StorageOptionsView StorageOptionsView
      {
         get
         {
            return storageOptionsView1;
         }
      }

#if (LEADTOOLS_V19_OR_LATER)
      public AnonymizeOptionsView AnonymizeOptionsView
      {
         get
         {
            return this.anonymizeOptionsView1;
         }
      }

      public DatabaseManagerOptionsView DatabaseManagerOptionsView
      {
         get
         {
            return this.databaseManagerOptionsView1;
         }
      }
#endif // #if (LEADTOOLS_V19_OR_LATER)

      private void AddInsConfiguration_VisibleChanged(object sender, EventArgs e)
      {
         toolStripButton1_Click(sender, e);
      }

      private void MakeInvisible()
      {
         storageOptionsView1.Visible = false;
         queryOptionsView1.Visible = false;
         storageClassesTabControl1.Visible = false;

#if (LEADTOOLS_V19_OR_LATER)
         databaseManagerOptionsView1.Visible = false;
         anonymizeOptionsView1.Visible = false;
#endif

         toolStripButton1.Checked = false;
         toolStripButton2.Checked = false;
         toolStripButton3.Checked = false;

#if (LEADTOOLS_V19_OR_LATER)
         toolStripButton4.Checked = false;
         toolStripButton5.Checked = false;
#endif // #if (LEADTOOLS_V19_OR_LATER)
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         MakeInvisible();
         storageOptionsView1.Visible = true;
         toolStripButton1.Checked = true;
      }


      private void toolStripButton2_Click(object sender, EventArgs e)
      {
         MakeInvisible();
         queryOptionsView1.Visible = true;
         toolStripButton2.Checked = true;
      }

      private void toolStripButton3_Click(object sender, EventArgs e)
      {
         MakeInvisible();
         storageClassesTabControl1.Visible = true;
         toolStripButton3.Checked = true;
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
         this.toolStripButton3.Visible = _canViewIodClasses;
         this.storageClassesTabControl1.Visible = _canViewIodClasses;
         }
      }

#if (LEADTOOLS_V19_OR_LATER)
      private void toolStripButton4_Click(object sender, EventArgs e)
      {
         MakeInvisible();

         databaseManagerOptionsView1.Visible = true;
         toolStripButton4.Checked = true;
      }

      private void toolStripButton5_Click(object sender, EventArgs e)
      {
         MakeInvisible();

         anonymizeOptionsView1.Visible = true;
         toolStripButton5.Checked = true;
      }
#endif // #if (LEADTOOLS_V19_OR_LATER)
   }
}
