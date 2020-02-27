// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu.Common;
using System.Linq;

namespace DicomDemo.UI
{
   public partial class StorageClassesDialog : Form
   {
      public StorageClassesDialog()
      {
         InitializeComponent();
      }

      private List<PresentationContext> _presentationContextList = new List<PresentationContext>();

      public List<PresentationContext> PresentationContextList
      {
         get
         {
            _presentationContextList.Clear();
            foreach (ListViewItem item in _listViewClasses.Items)
            {
               if (item.Checked)
               {
                  PresentationContext pc = MySeries.CreatePresentationContext(item.Text);
                  _presentationContextList.Add(pc);
               }
            }
            return _presentationContextList;
         }
         set
         {
            _presentationContextList = value;
         }
      }

      private void LoadClasses()
      {
         DicomUid uid = DicomUidTable.Instance.GetFirst();
         while (uid != null)
         {
            if (uid.Type == DicomUIDCategory.Class && uid.Code.StartsWith("1.2.840.10008.5.1.4.1.1"))
            {
               ListViewItem item = _listViewClasses.Items.Add(uid.Code);
               item.SubItems.Add(uid.Name);

               DicomUid uidToMatch = uid;
               bool inPresentationContextList = _presentationContextList.Any(p => p.AbstractSyntax == uidToMatch.Code);
               if (inPresentationContextList)
               {
                  item.Checked = true;
               }
            }
            uid = DicomUidTable.Instance.GetNext(uid);
         }
         _listViewClasses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
      }

      public void CheckAllItems(ListView lvw, bool check)
      {
         // lvw.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = check);
          foreach (ListViewItem item in lvw.Items)
          {
              item.Checked = check;
          }
      }

      private void StorageClassesDialog_Load(object sender, EventArgs e)
      {
         labelInstructions.Text = @"Select the SOP Classes of any image that will be retrieved by the C-GET.  These will be added to the DICOM association used by the C-GET DIMSE.";
         LoadClasses();
      }

      private void buttonSelectAll_Click(object sender, EventArgs e)
      {
         CheckAllItems(_listViewClasses, true);
      }

      private void buttonUnselectAll_Click(object sender, EventArgs e)
      {
         CheckAllItems(_listViewClasses, false);
      }
   }
}
