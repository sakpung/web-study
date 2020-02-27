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

using Leadtools.Dicom;
using Leadtools.Demos;

namespace DicomDemo
{
   public partial class ModifyTablesDlg : Form
   {
      public ModifyTablesDlg()
      {
         InitializeComponent();
      }

      private void ModifyTablesDlg_Load(object sender, EventArgs e)
      {
         textBoxUidFile.Text = System.IO.Path.Combine(DemosGlobal.ImagesFolder, "dicTableUid.xml");
         textBoxTagFile.Text = System.IO.Path.Combine(DemosGlobal.ImagesFolder, "dicTableElement.xml");
         textBoxIodFile.Text = System.IO.Path.Combine(DemosGlobal.ImagesFolder, "dicTableIodModule.xml");
         textBoxContextGroupFile.Text = System.IO.Path.Combine(DemosGlobal.ImagesFolder, "dicTableContextGroup.xml");
      }

      void MyBrowse(TextBox tb)
      {
         OpenFileDialog dlg = new OpenFileDialog();
         dlg.DefaultExt = "xml";
         dlg.FileName = tb.Text;
         dlg.Title = "Browse to Table File";
         dlg.InitialDirectory = DemosGlobal.ImagesFolder;
         dlg.Filter = "XML Files: (*.xml)|*.xml||";
         if (DialogResult.OK == dlg.ShowDialog())
         {
            tb.Text = dlg.FileName;
         }
      }

      bool Prompt(string table)
      {
         string msg = string.Format("This will remove all the items from the {0} table.\n\n\tClick 'OK' to continue\n\tClick 'Cancel' to cancel", table);
         return (MessageBox.Show(msg, "Remove All Table Items", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK);
      }

      void PromptResult(string table, bool removed)
      {
         string result = "Cancelled";
         if (removed)
         {
            result = string.Format("All items have been removed from the {0} table.", table);
         }
         MessageBox.Show(result, "Remove All Table Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
}

      private void Messager(string file, string tableName, string result)
      {
         bool successfullyLoaded = string.IsNullOrEmpty(result);
         string msg = string.Format(
            "{0} the {1} table from file\n'{2}'",
            successfullyLoaded ? "Successfully loaded" : "Failed to load",
            tableName,
            file
            );
         MessageBoxIcon icon;
         if (successfullyLoaded)
            icon = MessageBoxIcon.Information;
         else
            icon = MessageBoxIcon.Exclamation;
         MessageBox.Show(msg, "Table Load", MessageBoxButtons.OK, icon);
      }

      // Load From File
      private void buttonLoadUidTable_Click(object sender, EventArgs e)
      {
         Cursor = Cursors.WaitCursor;
         string result = string.Empty;
         string tableName = "UID";
         string file = textBoxUidFile.Text;

         try
         {
            Leadtools.Dicom.DicomUidTable.Instance.LoadXml(file);
         }
         catch (Exception ex)
         {
            result = ex.Message;
         }
         finally
         {
            Cursor = Cursors.Arrow;
         }
         Messager(file, tableName, result);
      }

      private void buttonLoadTagTable_Click(object sender, EventArgs e)
      {
         Cursor = Cursors.WaitCursor;

         string result = string.Empty;
         string tableName = "Element Tag";
         string file = textBoxTagFile.Text;

         try
         {
            Leadtools.Dicom.DicomTagTable.Instance.LoadXml(file);
         }
         catch (Exception ex)
         {
            result = ex.Message;
         }
         finally
         {
            Cursor = Cursors.Arrow;
         }
         Messager(file, tableName, result);
      }

      private void buttonLoadIodTable_Click(object sender, EventArgs e)
      {
         Cursor = Cursors.WaitCursor;

         string result = string.Empty;
         string tableName = "IOD";
         string file = textBoxIodFile.Text;

         try
         {
            Leadtools.Dicom.DicomIodTable.Instance.LoadXml(file);
         }
         catch (Exception ex)
         {
            result = ex.Message;
         }
         finally
         {
            Cursor = Cursors.Arrow;
         }
         Messager(file, tableName, result);
      }

      private void buttonLoadContextGroupTable_Click(object sender, EventArgs e)
      {
         Cursor = Cursors.WaitCursor;
         string result = string.Empty;
         string tableName = "Context Group";
         string file = textBoxContextGroupFile.Text;

         try
         {
            Leadtools.Dicom.DicomContextGroupTable.Instance.LoadXml(file);
         }
         catch (Exception ex)
         {
            result = ex.Message;
         }
         finally
         {
            Cursor = Cursors.Arrow;
         }
         Messager(file, tableName, result);
      }


      // Reset table
      private void buttonResetUidTable_Click(object sender, EventArgs e)
      {
         string table = "UID";
         bool result = Prompt(table);
         if (result)
            DicomUidTable.Instance.Reset();
         PromptResult(table, result);
      }

      private void buttonResetTagTable_Click(object sender, EventArgs e)
      {
         string table = "Element Tag";
         bool result = Prompt(table);
         if (result)
            DicomTagTable.Instance.Reset();
         PromptResult(table, result);
      }

      private void buttonResetIodTable_Click(object sender, EventArgs e)
      {
         string table = "IOD";
         bool result = Prompt(table);
         if (result)
            DicomIodTable.Instance.Reset();
         PromptResult(table, result);
      }

      private void buttonResetContextGroupTable_Click(object sender, EventArgs e)
      {
         string table = "Context Group";
         bool result = Prompt(table);
         if (result)
            DicomContextGroupTable.Instance.Reset();
         PromptResult(table, result);
      }

      // Show Table
      private void buttonShowUidTable_Click(object sender, EventArgs e)
      {
         Cursor = Cursors.WaitCursor;
         Tools.ShowUidTable();
         Cursor = Cursors.Arrow;
      }

      private void buttonTagTable_Click(object sender, EventArgs e)
      {
         Cursor = Cursors.WaitCursor;
         Tools.ShowTagTable();
         Cursor = Cursors.Arrow;
      }

      private void buttonShowIodTable_Click(object sender, EventArgs e)
      {
         Cursor = Cursors.WaitCursor;
         Tools.ShowIodTable();
         Cursor = Cursors.Arrow;
      }

      private void buttonShowContextGroupTable_Click(object sender, EventArgs e)
      {
         Cursor = Cursors.WaitCursor;
         Tools.ShowContextGroupTable();
         Cursor = Cursors.Arrow;
      }

      // Browse
      private void buttonUidFile_Click(object sender, EventArgs e)
      {
         MyBrowse(textBoxUidFile);
      }

      private void buttonTagFile_Click(object sender, EventArgs e)
      {
         MyBrowse(textBoxTagFile);
      }

      private void buttonIodFile_Click(object sender, EventArgs e)
      {
         MyBrowse(textBoxIodFile);
      }

      private void buttonContextGroupFile_Click(object sender, EventArgs e)
      {
         MyBrowse(textBoxContextGroupFile);
      }


      // This goes last
      private void buttonClose_Click(object sender, EventArgs e)
      {
         Close();
      }


   }
}
