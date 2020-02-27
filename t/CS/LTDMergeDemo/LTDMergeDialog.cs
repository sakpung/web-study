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

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using System.IO;
using Leadtools.Document.Writer;
using Leadtools;
using System.Threading;

namespace LTDMergeDemo
{
   public partial class LTDMergeDialog : Form
   {
      private DocumentWriter _docWriter;
      private bool _abort;

      public LTDMergeDialog()
      {
         InitializeComponent();

         // Setup the caption for this demo
         Messager.Caption = "C# LTD Merge Demo";
         _abort = false;
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            BeginInvoke(new MethodInvoker(Startup));
         }

         base.OnLoad(e);
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         if (!DesignMode)
         {
            _documentFormatOptionsControl.SelectedFormatChanged -= new EventHandler<EventArgs>(_documentFormatOptionsControl_SelectedFormatChanged);
            _docWriter.Progress -= new EventHandler<DocumentProgressEventArgs>(DocumentWriterInstance_Progress);

            // Save the last setting
            Properties.Settings settings = new Properties.Settings();

            if (_docWriter != null)
            {
               using (MemoryStream ms = new MemoryStream())
               {
                  _docWriter.SaveOptions(ms);
                  settings.FormatOptionsXml = Encoding.Unicode.GetString(ms.ToArray());
               }
            }

            settings.ViewFinalDocument = _viewDocumentCheckBox.Checked;
            settings.OutputFileName = _outputFileNameTextBox.Text;
            settings.LTDDocumentTypeIndex = _ltdDocumentTypeComboBox.SelectedIndex;
            settings.Save();
         }

         base.OnFormClosed(e);
      }

      private void Startup()
      {
         Properties.Settings settings = new Properties.Settings();

         _docWriter = new DocumentWriter();

         DocDocumentOptions docOptions = _docWriter.GetOptions(DocumentFormat.Doc) as DocDocumentOptions;
         docOptions.TextMode = DocumentTextMode.Framed;

         DocxDocumentOptions docxOptions = _docWriter.GetOptions(DocumentFormat.Docx) as DocxDocumentOptions;
         docxOptions.TextMode = DocumentTextMode.Framed;

         RtfDocumentOptions rtfOptions = _docWriter.GetOptions(DocumentFormat.Rtf) as RtfDocumentOptions;
         rtfOptions.TextMode = DocumentTextMode.Framed;

         AltoXmlDocumentOptions altoXmlOptions = _docWriter.GetOptions(DocumentFormat.AltoXml) as AltoXmlDocumentOptions;
         altoXmlOptions.Formatted = true;

         _documentFormatOptionsControl.SelectedFormatChanged += new EventHandler<EventArgs>(_documentFormatOptionsControl_SelectedFormatChanged);

         _documentFormatOptionsControl.SetDocumentWriter(_docWriter);

         _docWriter.Progress += new EventHandler<DocumentProgressEventArgs>(DocumentWriterInstance_Progress);

         _viewDocumentCheckBox.Checked = settings.ViewFinalDocument;
         _outputFileNameTextBox.Text = settings.OutputFileName;
         _ltdDocumentTypeComboBox.SelectedIndex = settings.LTDDocumentTypeIndex;

         UpdateUIState(false);
      }

      void _documentFormatOptionsControl_SelectedFormatChanged(object sender, EventArgs e)
      {
         // Change the Document Image file extension when the document format is changed.
         DocumentFormat format = _documentFormatOptionsControl.SelectedDocumentFormat;
         string extension = DocumentWriter.GetFormatFileExtension(format);
         _outputFileNameTextBox.Text = Path.ChangeExtension(_outputFileNameTextBox.Text, extension);
         _viewDocumentCheckBox.Enabled = format != DocumentFormat.Ltd;
      }

      private void _exitButton_Click(object sender, EventArgs e)
      {
         _documentFormatOptionsControl.UpdateDocumentWriterOptions();
         Close();
      }

      private void _aboutButton_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("LTD Merge", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void UpdateUIState(bool inProgress)
      {
         if (_mainWizardControl.SelectedTab == _sourceLTDFilesTabPage)
         {
            SourceLTDFilesUpdateUIState();
         }
         else if (_mainWizardControl.SelectedTab == _outputOptionsTabPage)
         {
            OutputOptionsUpdateUIState(inProgress);
         }
      }

      private void SourceLTDFilesUpdateUIState()
      {
         _sourceLTDFilesRemoveButton.Enabled = _sourceLTDFileListView.Items.Count > 0;
         _sourceLTDFilesClearButton.Enabled = _sourceLTDFileListView.Items.Count > 0;

         _moveTopButton.Enabled = _sourceLTDFileListView.SelectedItems.Count > 0;
         _moveUpButton.Enabled = _sourceLTDFileListView.SelectedItems.Count > 0;
         _moveDownButton.Enabled = _sourceLTDFileListView.SelectedItems.Count > 0;
         _moveBottomButton.Enabled = _sourceLTDFileListView.SelectedItems.Count > 0;

         _previousButton.Enabled = false;
         _nextButton.Enabled = _sourceLTDFileListView.Items.Count > 0;
         _nextButton.Text = "&Next";
      }

      private void OutputOptionsUpdateUIState(bool inProgress)
      {
         _previousButton.Enabled = true;
         _nextButton.Enabled = _outputFileNameTextBox.Text.Length > 0;
         if(inProgress)
            _nextButton.Text = "&Abort";
         else
            _nextButton.Text = "&Finish";
      }

      private void _previousButton_Click(object sender, EventArgs e)
      {
         if (_mainWizardControl.SelectedTab == _outputOptionsTabPage)
         {
            OutputOptionsPreviousPage();
         }

         UpdateUIState(false);
      }

      private void _nextButton_Click(object sender, EventArgs e)
      {
         if (_mainWizardControl.SelectedTab == _sourceLTDFilesTabPage)
         {
            SourceLTDFilesNextPage();
            UpdateUIState(false);
         }
         else if (_mainWizardControl.SelectedTab == _outputOptionsTabPage)
         {
            _abort = false;
            if (_nextButton.Text.Equals("&Abort"))
               _abort = true;

            if (!_abort)
            {
               _nextButton.Text = "&Abort";
               Application.DoEvents();

               _documentFormatOptionsControl.UpdateDocumentWriterOptions();
               DocumentFormat format = _documentFormatOptionsControl.SelectedDocumentFormat;
               string outputFileName = _outputFileNameTextBox.Text;
               bool viewFinalDocument = _viewDocumentCheckBox.Checked;
               List<string> sourceLTDFiles = new List<string>();

               LtdDocumentType globalLTDType = (LtdDocumentType)_ltdDocumentTypeComboBox.SelectedIndex;
               int totalPagesCount = 0;
               foreach (ListViewItem item in _sourceLTDFileListView.Items)
               {
                  LtdDocumentInfo ltdFileInfo = DocumentWriter.GetLtdInfo(item.Text);
                  if (ltdFileInfo.Type == globalLTDType)
                  {
                     sourceLTDFiles.Add(item.Text);
                     totalPagesCount += ltdFileInfo.PageCount;
                  }
               }

               _progressBar.Maximum = totalPagesCount + 2 /* The document writer provides progress for two extra operations (BeginDocument and EndDocument) and hence the number 2 */;

               ThreadPool.QueueUserWorkItem((object sender1) =>
               {
                  MergeLTDFiles(format, outputFileName, sourceLTDFiles.ToArray(), viewFinalDocument, globalLTDType);
               });

               UpdateUIState(true);
            }
         }
      }

      private void SourceLTDFilesNextPage()
      {
         // Check if any of the added LTD files in the list matches the globally selected 
         // LTD document type from the combo box, if non, then stay on this page.
         LtdDocumentType globalLTDType = (LtdDocumentType)_ltdDocumentTypeComboBox.SelectedIndex;
         bool validLTDFilesFound = false;
         foreach (ListViewItem item in _sourceLTDFileListView.Items)
         {
            LtdDocumentInfo ltdFileInfo = DocumentWriter.GetLtdInfo(item.Text);
            if (ltdFileInfo.Type == globalLTDType)
            {
               validLTDFilesFound = true;
               break;
            }
         }

         if(validLTDFilesFound)
            _mainWizardControl.SelectedTab = _outputOptionsTabPage;
         else
            Messager.ShowInformation(this, "Non of the source LTD files you added matches the chosen global LTD document type.\nYou can either change the global LTD document type to match the type of your LTD files or add some LTD files that matches the global LTD document type to be able to move to the next page.");
      }

      private void OutputOptionsPreviousPage()
      {
         _documentFormatOptionsControl.UpdateDocumentWriterOptions();

         _mainWizardControl.SelectedTab = _sourceLTDFilesTabPage;
      }

      private void _sourceLTDFilesAddButton_Click(object sender, EventArgs e)
      {
         string[] ltdFiles = ShowLTDOpenFilesDialog();
         if (ltdFiles != null)
         {
            foreach (string ltdFile in ltdFiles)
            {
               if (IsLTDFile(ltdFile))
               {
                  LtdDocumentInfo ltdFileInfo = DocumentWriter.GetLtdInfo(ltdFile);
                  _sourceLTDFileListView.Items.Add(ltdFile).SubItems.Add(ltdFileInfo.Type.ToString());
               }
            }
         }

         // set the focus to the source LTD files list view
         _sourceLTDFileListView.Select();
         if (_sourceLTDFileListView.Items.Count - 1 >= 0)
            _sourceLTDFileListView.EnsureVisible(_sourceLTDFileListView.Items.Count - 1);

         UpdateUIState(false);
      }

      private void _sourceLTDFilesRemoveButton_Click(object sender, EventArgs e)
      {
         SourceLTDFiles_RemoveSelectedItems();
      }

      private void _sourceLTDFilesClearButton_Click(object sender, EventArgs e)
      {
         _sourceLTDFileListView.Items.Clear();
         UpdateUIState(false);
      }

      private void _sourceLTDFileListView_KeyDown(object sender, KeyEventArgs e)
      {
         ListView lv = (ListView)sender;
         if (e.KeyCode == Keys.Delete && lv.SelectedItems.Count > 0)
         {
            // delete currently selected item(s)
            SourceLTDFiles_RemoveSelectedItems();
         }
         else if (e.Control && e.KeyCode == Keys.A)
         {
            // select all items in the list
            foreach (ListViewItem item in _sourceLTDFileListView.Items)
            {
               item.Selected = true;
            }
         }
      }

      private string[] ShowLTDOpenFilesDialog()
      {
         Properties.Settings settings = new Properties.Settings();

         using (OpenFileDialog dlg = new OpenFileDialog())
         {
            dlg.Filter = "LTD Files|*.ltd";
            dlg.Multiselect = true;
            dlg.InitialDirectory = settings.SourceLTDFolder;
            dlg.CheckFileExists = true;
            dlg.Title = "Select LTD file(s)";

            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
               settings.SourceLTDFolder = Path.GetDirectoryName(dlg.FileName);
               settings.Save();

               return dlg.FileNames;
            }
         }

         return null;
      }

      private void SourceLTDFiles_RemoveSelectedItems()
      {
         // set the focus to the source LTD files list view
         _sourceLTDFileListView.Select();

         int itemIndexToSelect = _sourceLTDFileListView.SelectedIndices[0];
         foreach (ListViewItem item in _sourceLTDFileListView.SelectedItems)
         {
            _sourceLTDFileListView.Items.Remove(item);
         }

         // set default selected item after deleting selected ones
         itemIndexToSelect = Math.Min(itemIndexToSelect, Math.Max(0, _sourceLTDFileListView.Items.Count - 1));
         if (_sourceLTDFileListView.Items.Count > 0)
            _sourceLTDFileListView.Items[itemIndexToSelect].Selected = true;

         UpdateUIState(false);
      }

      private void _sourceLTDFileListView_ItemDrag(object sender, ItemDragEventArgs e)
      {
         _sourceLTDFileListView.DoDragDrop(e.Item, DragDropEffects.Move);
      }

      private void _sourceLTDFileListView_DragOver(object sender, DragEventArgs e)
      {
         Point targetPoint = _sourceLTDFileListView.PointToClient(new Point(e.X, e.Y));
         int targetIndex = _sourceLTDFileListView.InsertionMark.NearestIndex(targetPoint);
         if (targetIndex > -1)
         {
            // if the cursor location is near the top of the hit test item then show the insertion mark before the item otherwise show it after the item
            int hitTestItemYCenter = _sourceLTDFileListView.Items[targetIndex].Bounds.Y + (_sourceLTDFileListView.Items[targetIndex].Bounds.Height / 2);
            if (targetPoint.Y < hitTestItemYCenter)
               _sourceLTDFileListView.InsertionMark.AppearsAfterItem = false;
            else
               _sourceLTDFileListView.InsertionMark.AppearsAfterItem = true;
         }

         // Set the location of the insertion mark. If the mouse is over the dragged item, the targetIndex value is -1 and the insertion mark disappears.
         _sourceLTDFileListView.InsertionMark.Index = targetIndex;
      }

      private void _sourceLTDFileListView_DragEnter(object sender, DragEventArgs e)
      {
         // Check if the Dataformat of the data can be accepted (we only accept file drops from Explorer, etc.)
         if (e.Data.GetDataPresent(DataFormats.FileDrop))
         {
            // check if any of the drop files is LTD file then allow this action otherwise don't (this will show the not allowed operation cursor).
            string[] filesList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            bool ok = false;
            foreach (string file in filesList)
            {
               if (IsLTDFile(file))
               {
                  ok = true;
                  break;
               }
            }

            if(ok)
               e.Effect = DragDropEffects.Copy; // Okay
            else
               e.Effect = DragDropEffects.None; // Not Okay
         }
         else
            e.Effect = e.AllowedEffect; // Unknown data, ignore it
      }

      private void _sourceLTDFileListView_DragDrop(object sender, DragEventArgs e)
      {
         if (e.Data.GetDataPresent(DataFormats.FileDrop))
         {
            // remove selection marks from all items in the list in order to select the newly added ones
            _sourceLTDFileListView.SelectedItems.Clear();

            int insertionIndex = (_sourceLTDFileListView.InsertionMark.Index != -1) ? ((_sourceLTDFileListView.InsertionMark.AppearsAfterItem) ? _sourceLTDFileListView.InsertionMark.Index + 1 : _sourceLTDFileListView.InsertionMark.Index) : _sourceLTDFileListView.Items.Count;

            string[] filesList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // Filter the dropped files list and only add the supported files types
            foreach (string file in filesList)
            {
               if (IsLTDFile(file))
               {
                  LtdDocumentInfo ltdFileInfo = DocumentWriter.GetLtdInfo(file);
                  ListViewItem insertedItem = _sourceLTDFileListView.Items.Insert(insertionIndex, file);
                  insertedItem.SubItems.Add(ltdFileInfo.Type.ToString());
                  insertedItem.Selected = true;
                  insertionIndex++;
               }
            }

            _sourceLTDFileListView.Select();
            _sourceLTDFileListView.EnsureVisible(insertionIndex-1);
            UpdateUIState(false);
         }
         else
         {
            if (_sourceLTDFileListView.InsertionMark.Index != -1)
            {
               int insertionIndex = (_sourceLTDFileListView.InsertionMark.Index < _sourceLTDFileListView.SelectedIndices[0]) ? _sourceLTDFileListView.InsertionMark.Index : _sourceLTDFileListView.InsertionMark.Index - _sourceLTDFileListView.SelectedItems.Count + 1;
               SwapItems(insertionIndex);
               _sourceLTDFileListView.InsertionMark.Index = -1;
            }
         }
      }

      private bool IsLTDFile(string fileName)
      {
         char[] trimChars = new char[] { '.' };
         string fileExt = Path.GetExtension(fileName).TrimStart(trimChars);
         return fileExt.ToLower().Equals("ltd");
      }

      private void SwapItems(int insertionIndex)
      {
         if (_sourceLTDFileListView.SelectedItems.Count <= 0)
            return;

         // set the focus to the source LTD files list view
         _sourceLTDFileListView.Select();

         int[] selectedIndices = new int[_sourceLTDFileListView.SelectedItems.Count];
         _sourceLTDFileListView.SelectedIndices.CopyTo(selectedIndices, 0);

         ListViewItem[] selectedItems = new ListViewItem[_sourceLTDFileListView.SelectedItems.Count];
         _sourceLTDFileListView.SelectedItems.CopyTo(selectedItems, 0);

         // Delete the selected items after we took a copy of them in order to insert the new ones at the new index
         for (int i = selectedItems.Length - 1; i >= 0; i--)
         {
            _sourceLTDFileListView.Items.RemoveAt(selectedIndices[i]);
         }

         int newIndex = Math.Max(0, Math.Min(insertionIndex, _sourceLTDFileListView.Items.Count));
         for (int i = 0; i < selectedItems.Length; i++)
         {
            _sourceLTDFileListView.Items.Insert(newIndex, selectedItems[i]);
            _sourceLTDFileListView.Items[newIndex].Selected = true;
            newIndex++;
         }
      }

      private void _moveTopButton_Click(object sender, EventArgs e)
      {
         SwapItems(0);
      }

      private void _moveUpButton_Click(object sender, EventArgs e)
      {
         int insertionIndex = _sourceLTDFileListView.SelectedIndices[0] - 1;
         SwapItems(insertionIndex);
      }

      private void _moveDownButton_Click(object sender, EventArgs e)
      {
         int insertionIndex = _sourceLTDFileListView.SelectedIndices[0] + 1;
         SwapItems(insertionIndex);
      }

      private void _moveBottomButton_Click(object sender, EventArgs e)
      {
         int insertionIndex = _sourceLTDFileListView.Items.Count - 1 - _sourceLTDFileListView.SelectedItems.Count + 1;
         SwapItems(insertionIndex);
      }

      private void _sourceLTDFileListView_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateUIState(false);
      }

      private void _outputFileNameTextBox_TextChanged(object sender, EventArgs e)
      {
         UpdateUIState(false);
      }

      private void _outputFileNameBrowseButton_Click(object sender, EventArgs e)
      {
         Properties.Settings settings = new Properties.Settings();

         // Show the save file dialog
         using (SaveFileDialog dlg = new SaveFileDialog())
         {
            // Get the selected format name and extension
            DocumentFormat format = _documentFormatOptionsControl.SelectedDocumentFormat;

            string extension = DocumentWriter.GetFormatFileExtension(format);

            dlg.Filter = string.Format("{0} (*.{1})|*.{1}|All Files (*.*)|*.*", _documentFormatOptionsControl.SelectedDocumentFormatFriendlyName, extension);
            dlg.InitialDirectory = settings.SaveDialogLastPath;
            dlg.DefaultExt = extension;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _outputFileNameTextBox.Text = dlg.FileName;

               settings.SaveDialogLastPath = Path.GetDirectoryName(dlg.FileName);
               settings.Save();
            }
         }
      }

      private void MergeLTDFiles(DocumentFormat format, string outputFileName, string[] sourceLTDFiles, bool viewFinalDocument, LtdDocumentType globalLTDType)
      {
         // If the output format is LTD then use the same target LTD file path specified by the user, otherwise create a temp file
         string mergedLTDFileName = null;
         if (format != DocumentFormat.Ltd)
         {
            mergedLTDFileName = Guid.NewGuid().ToString().Replace("-", null) + "." + "ltd";
            mergedLTDFileName = Path.Combine(Path.GetTempPath(), mergedLTDFileName);
         }
         else
         {
            mergedLTDFileName = outputFileName;
            if (File.Exists(outputFileName))
               File.Delete(outputFileName);
         }

         bool errorOccurred = false;
         try
         {
            if (sourceLTDFiles.Length > 0)
            {
               foreach (string fileName in sourceLTDFiles)
               {
                  if (_abort)
                     break;

                  _docWriter.AppendLtd(fileName, mergedLTDFileName);
               }

               if (format != DocumentFormat.Ltd)
                  _docWriter.Convert(mergedLTDFileName, outputFileName, format);
            }
            else
            {
               errorOccurred = true;
               OnError("Non of the source LTD files you added matches the chosen global LTD document type from the previous page.");
            }
         }
         catch (Exception ex)
         {
            errorOccurred = true;
            OnError(ex.Message);
         }
         finally
         {
            OnDone(format, mergedLTDFileName, outputFileName, viewFinalDocument, errorOccurred);
         }
      }

      private void OnError(string message)
      {
         this.BeginInvoke(new MethodInvoker(delegate()
         {
            Messager.ShowError(this, message);
         }));

         Application.DoEvents();
      }

      private void OnDone(DocumentFormat format, string tempMergedLTDFileName, string outputFileName, bool viewFinalDocument, bool errorOccurred)
      {
         this.BeginInvoke(new MethodInvoker(delegate()
         {
            _nextButton.Text = "&Finish";
            _progressBar.Value = 0;

            // Delete the temp LTD file
            if (format != DocumentFormat.Ltd && !string.IsNullOrEmpty(tempMergedLTDFileName) && File.Exists(tempMergedLTDFileName))
               File.Delete(tempMergedLTDFileName);

            if (!_abort && !errorOccurred)
            {
               if (viewFinalDocument && format != DocumentFormat.Ltd)
               {
                  // Put some delay before loading the saved file since Windows 7 is a little slow in creating the documents specially the EMF format.
                  System.Threading.Thread.Sleep(1000);
                  System.Diagnostics.Process.Start(outputFileName);
               }
               else
                  Messager.ShowInformation(this, "Operation completed.");
            }
         }));

         Application.DoEvents();
      }

      private delegate void DoUpdateStatusDelegate(int percentage);
      void DocumentWriterInstance_Progress(object sender, DocumentProgressEventArgs e)
      {
         if (_abort)
         {
            e.Cancel = true;
            return;
         }

         if (InvokeRequired && IsHandleCreated)
            BeginInvoke(new DoUpdateStatusDelegate(DoUpdateStatus), new object[] { e.Percentage });
         else
            DoUpdateStatus(e.Percentage);
      }

      private void DoUpdateStatus(int percentage)
      {
         if(percentage == 100)
            _progressBar.PerformStep();
      }
   }
}
