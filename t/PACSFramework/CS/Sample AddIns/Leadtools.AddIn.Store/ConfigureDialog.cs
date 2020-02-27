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
using System.IO;
using System.Windows.Forms;

using Leadtools.Dicom;

namespace Leadtools.AddIn.Store
{
   public partial class ConfigureDialog : Form
   {
      public bool _cancel = false;

      public ConfigureDialog()
      {
         InitializeComponent();
      }

      void ArrangeButtons()
      {
         int nSpaceBetweenButtons = 6;
         int nTotalButtonWidth =
            _buttonImport.Width +
            _buttonImportDicomDir.Width +
            _buttonRemove.Width +
            _buttonRemoveAll.Width +
            _buttonRefresh.Width +
            _buttonCancel.Width + 
            _buttonOk.Width +      6 * nSpaceBetweenButtons;

         _buttonImport.Left = (_splitContainer1.Panel2.ClientSize.Width - nTotalButtonWidth) / 2;
         _buttonImport.Top = (_splitContainer1.Panel2.ClientSize.Height - _buttonImport.Height) / 3;

         _buttonImportDicomDir.Left = _buttonImport.Right + nSpaceBetweenButtons;
         _buttonImportDicomDir.Top = _buttonImport.Top;

         _buttonRemove.Left = _buttonImportDicomDir.Right + nSpaceBetweenButtons;
         _buttonRemove.Top = _buttonImport.Top;

         _buttonRemoveAll.Left = _buttonRemove.Right + nSpaceBetweenButtons;
         _buttonRemoveAll.Top = _buttonImport.Top;

         _buttonRefresh.Left = _buttonRemoveAll.Right + nSpaceBetweenButtons;
         _buttonRefresh.Top = _buttonImport.Top;

         _buttonCancel.Left = _buttonRefresh.Right + nSpaceBetweenButtons;
         _buttonCancel.Top = _buttonImport.Top;

         _buttonOk.Left = _buttonCancel.Right + nSpaceBetweenButtons;
         _buttonOk.Top = _buttonImport.Top;

         this._labelStatus.Left = _buttonImport.Left;
         this._labelStatus.Top = _buttonImport.Bottom + nSpaceBetweenButtons;
      }

      private void EnableCancel(bool bEnable)
      {
         int nCount = _listViewDatabase.Items.Count;
         int nCheckedCount = GetCheckedCount();

         _buttonImport.Enabled = !bEnable;
         _buttonImportDicomDir.Enabled = !bEnable;
         _buttonRemove.Enabled = !bEnable && (nCheckedCount > 0);
         _buttonRemoveAll.Enabled = !bEnable && (nCount > 0);
         _buttonRefresh.Enabled = !bEnable;
         _listViewDatabase.Enabled = !bEnable;
         _buttonCancel.Enabled = bEnable;
         _buttonOk.Enabled = !bEnable;

         if (bEnable == false)
         {
            if (_cancel)
            {
               MessageBox.Show(this, "Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
               _cancel = false;
            }
         }
         else
         {
            LogText(string.Empty);
         }
      }

      private void LogText(string sLogText)
      {
         _labelStatus.Text = sLogText;
         Application.DoEvents();
      }


      private void RemoveItem(string sSOPInstanceUid)
      {
         DB.DeleteDicomRecord(Module.ServerInfo.ConnectionString, sSOPInstanceUid);
      }

      private int RemoveSelectedItems()
      {
         int count = 0;
         int totalCount = 0;
         int nMod = 1;
         string sMsg = string.Empty;
         EnableCancel(true);

         try
         {
            // Get total count
            foreach (ListViewItem item in _listViewDatabase.CheckedItems)
               totalCount++;

            if (totalCount >= 20)
               nMod = 10;

            foreach (ListViewItem item in _listViewDatabase.CheckedItems)
            {
               if (!_cancel)
               {
                  string sSopInstanceUid = item.Tag.ToString();
                  RemoveItem(sSopInstanceUid);
                  count++;

                  if (count % nMod == 0)
                  {
                     sMsg = string.Format("Removed {0} of {1} files...", count.ToString(), totalCount.ToString());
                     LogText(sMsg);
                  }
                  Application.DoEvents();
               }
            }
         }
         catch (Exception e)
         {
             LogText("Dicom error: " + e.Message);
         }
         sMsg = string.Format("Removed {0} of {1} files", count.ToString(), totalCount.ToString());
         LogText(sMsg);

         EnableCancel(false);

         return count;
      }

      private int RemoveAllItems()
      {
         int nCount = _listViewDatabase.Items.Count;
         DB.DeleteAllDicomRecords(Module.ServerInfo.ConnectionString);
         return nCount;
      }

      private bool IsDicomDir(string file, DicomDataSet ds)
      {
         string name = Path.GetFileNameWithoutExtension(file);

         return (name == "DICOMDIR" && ds.InformationClass == DicomClassType.BasicDirectory);
      }

      private bool LoadDicomFile(string file)
      {
         bool ret = true;
         try
         {
            using (DicomDataSet ds = new DicomDataSet())
            {
               ds.Load(file, DicomDataSetLoadFlags.None);
               DicomCommandStatusType status = DB.Insert(DateTime.Now, Module.ServerInfo, "TEST_AE", ds);
               if (status != DicomCommandStatusType.Success)
                  ret = false;
            }
         }
         catch (Exception e)
         {
             MessageBox.Show(this, e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             ret = false;
         }
         return ret;
      }

      private void _buttonImport_Click(object sender, EventArgs e)
      {
         OpenFileDialog of = new OpenFileDialog();
         //DicomDataSet ds = new DicomDataSet();
         of.Multiselect = true;
         of.Title = "Add DICOM File";
         of.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*";
         int count = 0;
         int totalCount = 0;
         int nMod = 1;
         string sMsg = string.Empty;
         if (of.ShowDialog() == DialogResult.OK)
         {
            EnableCancel(true);
            totalCount = of.FileNames.Length;
            if (totalCount >= 20)
               nMod = 10;
            foreach (string file in of.FileNames)
            {
               try
               {
                  if (!_cancel)
                  {
                     if (LoadDicomFile(file))
                     {
                        count++;
                        if (count % nMod == 0)
                        {
                           sMsg = string.Format("Loaded {0} of {1} files...", count.ToString(), totalCount.ToString());
                           LogText(sMsg);
                        }
                     }
                     else
                     {
                        sMsg = string.Format("Failed to load {0}", file);
                        LogText(sMsg);
                     }
                  }
               }
               catch (Exception ex)
               {
                  MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               Application.DoEvents();
            }
            RefreshList();
         }
         sMsg = string.Format("Loaded {0} of {1} files", count.ToString(), totalCount.ToString());
         LogText(sMsg);
         EnableCancel(false);
      }

      private void LoadDicomDir(string filename)
      {
         if (_cancel)
            return;

         string pathname = string.Empty;
         string refFilename = string.Empty;
         DicomElement element = null;
         int count = 0;
         int totalCount = 0;
         int nMod = 1;
         string sMsg = string.Empty;


         if (!filename.ToUpper().Contains("DICOMDIR"))
            return;

         pathname = Path.GetDirectoryName(filename) + "\\";
         using (DicomDataSet ds = new DicomDataSet())
         {
            try
            {
               this.Cursor = Cursors.WaitCursor;
               LogText("Loading DICOMDIR...");
               ds.Load(filename, DicomDataSetLoadFlags.None);

               // Get the total count
               LogText("Getting total count...");
               element = ds.FindFirstElement(null, DicomTag.ReferencedFileID, false);
               while (element != null)
               {
                  totalCount++;
                  element = ds.FindNextElement(element, false);
               }

               if (totalCount >= 20)
                  nMod = 10;

               // now get the datasets
               element = ds.FindFirstElement(null, DicomTag.ReferencedFileID, false);
               if (element != null && ds.GetElementValueCount(element) > 0)
               {
                  if (!_cancel)
                  {
                     refFilename = ds.GetConvertValue(element);
                     if (LoadDicomFile(pathname + refFilename))
                        count++;
                     Application.DoEvents();
                  }
               }

               while ((refFilename.Length > 0) && (!_cancel))
               {
                  element = ds.FindNextElement(element, false);
                  if (element != null && ds.GetElementValueCount(element) > 0)
                  {
                     refFilename = ds.GetConvertValue(element);
                     if (LoadDicomFile(pathname + refFilename))
                        count++;
                     Application.DoEvents();
                  }
                  else
                     refFilename = "";
                  if (count % nMod == 0)
                  {
                     sMsg = string.Format("Loaded {0} of {1} files...", count.ToString(), totalCount.ToString());
                     LogText(sMsg);
                  }
               }
            }
            catch (DicomException de)
            {
               LogText("Dicom error: " + de.Code.ToString() + ": " + filename);
            }
         }
         sMsg = string.Format("Loaded {0} of {1} total files", count.ToString(), totalCount.ToString());
         LogText(sMsg);
         RefreshList(); 
         this.Cursor = Cursors.Default;
      }


      private void _buttonImportDicomDir_Click(object sender, EventArgs e)
      {
         OpenFileDialog of = new OpenFileDialog();
         of.Multiselect = false;
         of.Title = "Add DICOM Dir";
         of.Filter = "All Files|*.*";
         of.FileName = "DICOMDIR";
         if (of.ShowDialog() == DialogResult.OK)
         {
            EnableCancel(true);
            foreach (string file in of.FileNames)
            {
               LoadDicomDir(file);
            }
            EnableCancel(false);
         }
         SizeColumns();
      }

      private int GetCheckedCount()
      {
         int nCount = 0;
         foreach (ListViewItem item in _listViewDatabase.CheckedItems)
         {
            nCount++;
         }
         return nCount;
      }

      private void _buttonRemove_Click(object sender, EventArgs e)
      {
         string sMsg;
         int nCount = GetCheckedCount();
         if (nCount > 0)
         {
            sMsg = string.Format("You are about to permananetly delete {0} item(s).  Do you want to continue?", nCount);
            DialogResult dr = MessageBox.Show(this, sMsg, "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
               nCount = RemoveSelectedItems();
               if (nCount > 0)
               {
                  RefreshList();
                  sMsg = string.Format("Removed {0} items", nCount);
                  LogText(sMsg);
                  EnableCancel(false);
               }
            }
            else
            {
               LogText("Remove Cancelled");
            }
         }
      }

      private void _buttonRemoveAll_Click(object sender, EventArgs e)
      {
         DialogResult dr = MessageBox.Show(this, "You are about to permananetly delete ALL items.  Do you want to continue?", "Remove All", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
         if (dr == DialogResult.Yes)
         {
            int nCount = RemoveAllItems();
            if (nCount > 0)
            {
               RefreshList();
               string sMsg = string.Format("Removed {0} items", nCount);
               LogText(sMsg);
               EnableCancel(false);
            }
         }
         else
         {
            LogText("RemoveAll Cancelled");
         }
      }

      private void SizeColumns()
      {
         if (_listViewDatabase.Items.Count > 0)
         {
            // Size to content
            foreach (ColumnHeader header in _listViewDatabase.Columns)
            {
               if (header.Text.Contains("Modality"))
                  header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               else if (header.Text.Contains("Study ID"))
                  header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               else if (header.Text.Contains("Instance #"))
                  header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               else if (header.Text.Contains("Series #"))
                  header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               else
                  header.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
         }
         else
         {
            // size to header
            foreach (ColumnHeader header in _listViewDatabase.Columns)
               header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
         }
      }

      private void RefreshList()
      {
         try
         {
            DB.ListAllImages(Module.ServerInfo.ConnectionString, _listViewDatabase);
            SizeColumns();
            _listViewDatabase.Refresh();
         }
         catch (Exception e)
         {
             LogText("Dicom error: " + e.Message);
         }
      }

      private void _listViewDatabase_ItemChecked(object sender, ItemCheckedEventArgs e)
      {
         EnableCancel(false);
      }

      private void _splitContainer1_Panel2_Resize(object sender, EventArgs e)
      {
         ArrangeButtons();
      }


      private void _buttonRefresh_Click(object sender, EventArgs e)
      {
         RefreshList();
      }

      private void _buttonCancel_Click(object sender, EventArgs e)
      {
         _cancel = true;
      }

      private void DatabaseManagerControl_Load(object sender, EventArgs e)
      {
         RefreshList();
         ArrangeButtons();
         EnableCancel(false);
      }

      private void _buttonOk_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void copyFilePathToolStripMenuItem_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in _listViewDatabase.Items)
         {
            if (item.Selected)
            {
               Clipboard.SetText(item.SubItems[_columnHeaderReferencedFile.Index].Text);
            }
         }
      }

      private void _contextMenuStripDatabase_Opening(object sender, CancelEventArgs e)
      {
         _contextMenuStripDatabase.Enabled = (_listViewDatabase.SelectedItems.Count > 0);
      }
   }
}
