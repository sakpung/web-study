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
using CSCustomizingWorklistDAL.DataTypes;
using Leadtools.Dicom ;

namespace CSCustomizingWorklistDAL.UI
{
   public partial class DicomTags : UserControl
   {
      public DicomTags()
      {
         InitializeComponent ( ) ;
      }
      
      public void SetSource ( List<DatabaseDicomTags> DatabaseTags )
      {
         ColumnTagsListView.Items.Clear ( ) ;
         
         foreach ( DatabaseDicomTags dbDicomTag in DatabaseTags ) 
         {
            ListViewItem dbTagItem = new ListViewItem ( dbDicomTag.TableName ) ;
            
            
            dbTagItem.SubItems.Add ( dbDicomTag.ColumnName ) ;
            dbTagItem.SubItems.Add ( DicomTagTable.Instance.Find ( dbDicomTag.DicomTag ).Name ) ;
            
            ColumnTagsListView.Items.Add ( dbTagItem ) ;
         }
      }
   }
}
