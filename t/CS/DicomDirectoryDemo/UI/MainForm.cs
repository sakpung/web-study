// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

using Leadtools;
using Leadtools.Demos;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using Leadtools.Controls;

namespace DicomDemo
{
   public partial class MainForm : Form
   {
      private string m_strDicomFilesFolder;
      private UserDicomDir m_DicomDir;
      private ImageViewer rasterImageViewer1;

      public static bool cancel = false;

      public MainForm()
      {
         InitializeComponent();

         Utils.EngineStartup();
      }

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         if (RasterSupport.IsLocked(RasterSupportType.Medical))
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Medical.ToString()), "Warning");
            return;
         }

         Application.Run(new MainForm());
      }

      private void SetStatus(string status, bool doEvents)
      {
         txtStatus.Text = status;
         if (doEvents)
         {
            Application.DoEvents();
         }
      }

      private void SetStatus(string status)
      {
         txtStatus.Text = status;
      }

      void UpdateUI(bool enable)
      {
         btnCreate.Enabled = enable;
         btnInsert.Enabled = enable;
         btnLoad.Enabled = enable;

         bool saveFolderSet = !string.IsNullOrEmpty(txtDirectory.Text);
         btnSave.Enabled = enable && saveFolderSet;

         chkRejectInvalidFileIds.Enabled = enable;
         chkInsertIconImageSequence.Enabled = enable;
      }

      /*
       * Creates a new Dicom Directory based on a folder
       */
      private void btnCreate_Click(object sender, EventArgs e)
      {
         MainForm.cancel = false;

         if (!GetFolder())
         {
            MessageBox.Show("Please choose a valid directory");
            return;
         }

         // Reset and clear
         rasterImageViewer1.Visible = false;
         rasterImageViewer1.Image = null;
         trvDicomDir.Nodes.Clear();
         m_DicomDir.Reset("");
         txtElementValue.Text = "";
         txtDirectory.Text = "";
         SetStatus("");
         Invalidate();

         this.Cursor = Cursors.WaitCursor;

         txtDirectory.Text = m_strDicomFilesFolder;

         UpdateUI(false);
         // Create a DICOM Directory for all the files in the folder 
         // m_strDicomFilesFolder and all subfolders
         try
         {
            Debug.WriteLine("Start Creating DicomDir...");
            DoCreateDicomDirectory();
            Debug.WriteLine("End Creating DicomDir...");
         }
         catch (Exception ex)
         {
            SetStatus(string.Format("Status: Failed to create the DICOM Directory!  (Error Message: {0})  Make sure that only valid Dicom DataSet files exist in the directory.", ex.Message));

            if (ex.InnerException != null)
            {
               MessageBox.Show(ex.InnerException.Message);
            }
            this.Cursor = Cursors.Default;
            return;
         }
         UpdateUI(true);

         if (m_DicomDir.GetAddedDicomFilesCount() == 0)
         {
            SetStatus("Status: Search is complete. No DICOM files were added to the DICOM Directory.");

            this.Cursor = Cursors.Default;
         }

         // Populate the tree
         Debug.WriteLine("Start FillTree...");
         try
         {
            FillTreeKeys(null, null);
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error while populating tree:\r\n\r\n" + ex.ToString());
         }
         Debug.WriteLine("End FillTree...");

         SetStatus(string.Format("Status: Search is complete. {0} file(s) were added to the DICOM Directory.",
                                 m_DicomDir.GetAddedDicomFilesCount()));

         this.Cursor = Cursors.Default;
      }

      /*
       * Creates a FolderBrowserDialog for the user to select the directory from which
       * to create the Dicom Directory
       */
      private bool GetFolder()
      {
         FolderBrowserDialog fbd = new FolderBrowserDialog();
         fbd.ShowDialog(this);
         if (Directory.Exists(fbd.SelectedPath))
         {
            m_strDicomFilesFolder = fbd.SelectedPath;
            return true;
         }
         return false;
      }

      /*
       * Creates a Dicom Directory based on the value of m_strDicomFilesFolder
       */
      private void DoCreateDicomDirectory()
      {
         try
         {
            // Reset the DICOM Directory and set the destination folder where
            // the DICOMDIR file will be saved
            m_DicomDir.Reset(m_strDicomFilesFolder);

            // If it is desired to change the values of the Implementation Class
            // UID (0002,0012) and the Implementation Version Name (0002,0013)...
            DicomElement element = m_DicomDir.DataSet.FindFirstElement(null, DemoDicomTags.ImplementationClassUID, false);
            if (element != null)
            {
               m_DicomDir.DataSet.SetStringValue(element, "1.2.840.114257.0.1", DicomCharacterSetType.Default); // Must be a UID
            }
            element = m_DicomDir.DataSet.FindFirstElement(null, DemoDicomTags.ImplementationVersionName, false);
            if (element != null)
            {
               m_DicomDir.DataSet.SetStringValue(element, "LEADTOOLS", DicomCharacterSetType.Default); // Must be a UID
            }

            // Set options
            DicomDirOptions options = m_DicomDir.Options;
            options.IncludeSubfolders = true;
            options.InsertIconImageSequence = chkInsertIconImageSequence.Checked;
            options.RejectInvalidFileId = chkRejectInvalidFileIds.Checked;
            m_DicomDir.Options = options;


            m_DicomDir.SetStatusTextBox(ref txtStatus);

            // Add the DICOM files to the DICOM Directory.
            // This is the function that does it all!
            // You can always give the user feedback about the progress inside 
            // this function by overriding the function DicomDir.OnInsertFile.   
            m_DicomDir.InsertFile(null);
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         // Do some initialization
         m_strDicomFilesFolder = "";
         m_DicomDir = new UserDicomDir();

         // Add a RasterImageViewer in the same location as txtElementValue
         rasterImageViewer1 = new ImageViewer();
         rasterImageViewer1.Visible = false;
         groupBox3.Controls.Add(rasterImageViewer1);
         rasterImageViewer1.Location = txtElementValue.Location;
         rasterImageViewer1.Size = txtElementValue.Size;
         rasterImageViewer1.Zoom( ControlSizeMode.Fit, rasterImageViewer1.ScaleFactor, rasterImageViewer1.DefaultZoomOrigin);
         txtElementValue.SendToBack();
         UpdateUI(true);

         Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
      }

      void Application_ApplicationExit(object sender, EventArgs e)
      {
         Utils.EngineShutdown();
      }

      /*
       * Populates the TreeView with the keys to represent m_DicomDir
       */
      private void FillTreeKeys(DicomElement ParentKeyElement, TreeNode ParentNode)
      {
         DicomElement CurrentKeyElement;
         TreeNode node;
         string name;
         string temp = "";
         int counter = 0;

         if (ParentKeyElement == null)
         {
            CurrentKeyElement = m_DicomDir.DataSet.GetFirstKey(null, true);
         }
         else
         {
            CurrentKeyElement = m_DicomDir.DataSet.GetChildKey(ParentKeyElement);
         }

         // Add the keys to the TreeView
         while (CurrentKeyElement != null)
         {
            // Get key name
            temp = m_DicomDir.DataSet.GetKeyValueString(CurrentKeyElement);

            if ((temp != null) || (temp == ""))
            {
               name = temp;
            }
            else
            {
               name = "UNKNOWN";
            }

            // Add at root or beneath its parent
            if (ParentNode == null)
            {
               node = trvDicomDir.Nodes.Add(name);
            }
            else
            {
               node = ParentNode.Nodes.Add(name);
            }

            node.Tag = CurrentKeyElement;

            // Add the current key's non-key child elements
            DicomElement CurrentKeyChildElement = m_DicomDir.DataSet.GetChildElement(CurrentKeyElement, true);
            while (CurrentKeyChildElement != null)
            {
               FillKeySubTree(CurrentKeyChildElement, node, false);
               CurrentKeyChildElement = m_DicomDir.DataSet.GetNextElement(CurrentKeyChildElement, true, true);
            }

            counter++;
            if ((counter % 100) == 0)
            {

               SetStatus(string.Format("Added {0} Elements to Tree Display", counter));
               Application.DoEvents();
            }

            // Recursively add child keys
            if (m_DicomDir.DataSet.GetChildKey(CurrentKeyElement) != null)
            {
               FillTreeKeys(CurrentKeyElement, node);
            }

            CurrentKeyElement = m_DicomDir.DataSet.GetNextKey(CurrentKeyElement, true);
         }
      }

      /*
       * Populates the TreeView with the elements below each Key to represent m_DicomDir
       */
      private void FillKeySubTree(DicomElement element, TreeNode ParentNode, bool recurse)
      {
         TreeNode node;
         string name;
         string temp = "";
         DicomTag tag;

         // Get the tag's numerical display value (XXXX:XXXX)
         tag = DicomTagTable.Instance.Find(element.Tag);
         temp = string.Format("{0:x4}:{1:x4} - ", Utils.GetGroup((long)element.Tag), Utils.GetElement((long)element.Tag));

         // Get the tag's name
         if (tag == null)
            name = "Item";
         else
            name = tag.Name;

         temp = temp + name;

         // Add the node either on the root or beneath its parent
         if (ParentNode != null)
         {
            node = ParentNode.Nodes.Add(temp);
         }
         else
         {
            node = trvDicomDir.Nodes.Add(temp);
         }

         node.Tag = element;
         node.ImageIndex = 1;
         node.SelectedImageIndex = 1;

         // If the element has children, recursively add them
         DicomElement tempElement = m_DicomDir.DataSet.GetChildElement(element, true);
         if (tempElement != null)
         {
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            FillKeySubTree(tempElement, node, true);
         }

         if (recurse)
         {
            tempElement = m_DicomDir.DataSet.GetNextElement(element, true, true);
            if (tempElement != null)
            {
               FillKeySubTree(tempElement, ParentNode, true);
            }
         }
      }

      /*
       * Displays the value of the element.
       */
      private void trvDicomDir_AfterSelect(object sender, TreeViewEventArgs e)
      {
         string value;

         rasterImageViewer1.Visible = false;
         rasterImageViewer1.Image = null;

         txtElementValue.Text = "";

         if (trvDicomDir.SelectedNode.Tag == null)
            return;

         DicomElement element = (DicomElement)trvDicomDir.SelectedNode.Tag;

         try
         {
            if (element.Tag == DemoDicomTags.PixelData)
            {
               rasterImageViewer1.Image = m_DicomDir.DataSet.GetImage(element, 0, 8, RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut);
               rasterImageViewer1.Visible = true;
               return;
            }

            value = m_DicomDir.DataSet.GetConvertValue(element);
            if (value != null && value.Length > 0)
            {
               value = value.Replace(@"\", "\r\n");
            }
            txtElementValue.Text = value;
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error getting element value:\r\n\r\n" + ex.ToString());
         }
      }

      /*
       * If the element is Referenced File ID, then display the full image in the viewer
       */
      private void trvDicomDir_DoubleClick(object sender, EventArgs e)
      {
         if (trvDicomDir.SelectedNode == null)
            return;

         if (trvDicomDir.SelectedNode.Tag == null)
            return;

         DicomElement element = (DicomElement)trvDicomDir.SelectedNode.Tag;

         if (element.Tag == DemoDicomTags.ReferencedFileID)
            DisplayImage((DicomElement)trvDicomDir.SelectedNode.Tag);
      }

      /*
       * Loads an image based on the Referened File ID element
       * 
       * Preconditions:
       *   1. element != null
       *   2. element.Tag == DemoDicomTags.ReferencedFileID
       */
      private void DisplayImage(DicomElement element)
      {
         if (!m_DicomDir.DataSet.ExistsElement(element))
            return;

         txtElementValue.Text = "";

         // Get file name
         string strFileName = m_strDicomFilesFolder;
         for (int i = 0; i < m_DicomDir.DataSet.GetElementValueCount(element); i++)
            strFileName += "\\" + m_DicomDir.DataSet.GetStringValue(element, i);

         // Load the data set
         DicomDataSet ImageDS = new DicomDataSet();
         try
         {
            ImageDS.Load(strFileName, DicomDataSetLoadFlags.LoadAndClose);
         }
         catch (Exception ex)
         {
            SetStatus(string.Format("Failed to load DataSet.  Error Message: {0}", ex.Message));
            return;
         }

         // Get the image from the Pixel Data element and display it in the viewer
         try
         {
            DicomElement PixelDataElement = ImageDS.FindFirstElement(null, DemoDicomTags.PixelData, false);
            if (PixelDataElement == null)
            {
               SetStatus(string.Format("Dataset does not contain an image."));
               return;
            }

            rasterImageViewer1.Image = ImageDS.GetImage(PixelDataElement,
                0,
                0,
                RasterByteOrder.Rgb,
                DicomGetImageFlags.AutoApplyModalityLut | DicomGetImageFlags.AutoApplyVoiLut | DicomGetImageFlags.AllowRangeExpansion);
            rasterImageViewer1.Visible = true;
         }
         catch (Exception ex)
         {
            SetStatus(string.Format("Failed to load the image from the DataSet.  Error Message: {0}", ex.Message));
            return;
         }
      }

      /*
       * Loads an existing DICOMDIR file
       */
      private void btnLoad_Click(object sender, EventArgs e)
      {
         MainForm.cancel = false;

         OpenFileDialog ofd = new OpenFileDialog();
         ofd.Filter = "DICOMDIR|DICOMDIR|All Files|*.*";
         ofd.FilterIndex = 0;
         if (ofd.ShowDialog() != DialogResult.OK)
            return;

         // Reset and clear
         rasterImageViewer1.Visible = false;
         rasterImageViewer1.Image = null;
         trvDicomDir.Nodes.Clear();
         m_DicomDir.Reset("");
         m_strDicomFilesFolder = "";
         txtElementValue.Text = "";
         txtDirectory.Text = "";
         SetStatus("");
         Invalidate();

         // Get the root directory of this DICOMDIR
         m_strDicomFilesFolder = ofd.FileName.Substring(0, ofd.FileName.LastIndexOf("\\"));
         txtDirectory.Text = m_strDicomFilesFolder;

         if (!File.Exists(ofd.FileName))
         {
            MessageBox.Show("File does not exist.");
            return;
         }

         // Load the file and populate the TreeView
         try
         {
            m_DicomDir.Load(ofd.FileName, DicomDataSetLoadFlags.LoadAndClose);

            if (m_DicomDir.DataSet.InformationClass != DicomClassType.BasicDirectory)
            {
               MessageBox.Show("Please select a valid Dicom Directory file.");
               m_DicomDir = new UserDicomDir();
               return;
            }
            try
            {
               FillTreeKeys(null, null);
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error while populating tree:\r\n\r\n" + ex.ToString());
            }

            SetStatus("DICOMDIR successfully loaded");
         }
         catch (Exception ex)
         {
            SetStatus(string.Format("Status: Failed to add file to the DICOM Directory!  (Error Message: {0})  Make sure that this is a valid Dicom DataSet.", ex.Message));
            return;
         }
      }

      /*
       * Inserts a single dataset into the existing DicomDir
       */
      private void btnInsert_Click(object sender, EventArgs e)
      {
         MainForm.cancel = false;

         if (m_strDicomFilesFolder == "")
         {
            MessageBox.Show("You must create a Dicom Directory first");
            return;
         }

         OpenFileDialog ofd = new OpenFileDialog();
         ofd.Filter = "DICOM Files (*.dic; *.dcm)|*.dic;*.dcm|All Files|*.*";
         ofd.FilterIndex = 0;
         if (ofd.ShowDialog() != DialogResult.OK)
            return;

         if (!File.Exists(ofd.FileName))
         {
            MessageBox.Show("File does not exist.");
            return;
         }

         // If the file doesn't exist in the DICOMDIR's root directory, copy it there
         if (!ofd.FileName.Contains(m_strDicomFilesFolder))
         {
            try
            {
               string strDstFileName = m_strDicomFilesFolder +
                                       ofd.FileName.Substring(ofd.FileName.LastIndexOf("\\"));
               File.Copy(ofd.FileName, strDstFileName);
               ofd.FileName = strDstFileName;
            }
            catch (Exception ex)
            {
               SetStatus(string.Format("Failed to copy the DataSet to the folder \"{0}\".  Error Message: {1}", m_strDicomFilesFolder, ex.Message));
               return;
            }
         }

         // Load the DataSet to be inserted
         DicomDataSet InsertDs = new DicomDataSet();
         try
         {
            InsertDs.Load(ofd.FileName, DicomDataSetLoadFlags.None);
         }
         catch (Exception ex)
         {
            SetStatus(string.Format("Failed to load the DataSet.  Error Message: {0}", ex.Message));
            return;
         }

         // Make sure the file isn't a Directory
         if (InsertDs.InformationClass == DicomClassType.BasicDirectory)
         {
            MessageBox.Show("Please select a valid Dicom DataSet file that is not a Basic Directory.");
            return;
         }

         // Add the file
         try
         {
            m_DicomDir.InsertDataSet(InsertDs, ofd.FileName);
         }
         catch (Exception ex)
         {
            SetStatus(string.Format("Status: Failed to add file to the DICOM Directory!  (Error Message: {0})  Make sure that this is a valid Dicom DataSet.", ex.Message));
            return;
         }

         // Update tree
         trvDicomDir.Nodes.Clear();
         try
         {
            FillTreeKeys(null, null);
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error while populating tree:\r\n\r\n" + ex.ToString());
         }
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         MainForm.cancel = false;

         if (File.Exists(m_strDicomFilesFolder + "\\DICOMDIR"))
         {
            if (MessageBox.Show("A DICOMDIR file already exists, would you like to replace it?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
               SetStatus("Saving of DICOMDIR file was cancelled.");
               return;
            }
         }

         UpdateUI(false);
         try
         {
            SetStatus(@"Saving the DICOMDIR...", true);
            Debug.WriteLine("Start Saving DICOMDIR ...");
            m_DicomDir.Save();
            Debug.WriteLine("End Save DICOMDIR");
            SetStatus(string.Format("A DICOMDIR file was saved to {0}\\DICOMDIR", m_strDicomFilesFolder));
         }
         catch (Exception ex)
         {
            SetStatus(string.Format("Error saving DicomDir: {0}", ex.Message));
         }
         UpdateUI(true);
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         cancel = true;
         UpdateUI(true); 
      }
   }
}
