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
using System.IO;
using System.Drawing.Drawing2D;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Dicom;
using Leadtools.ImageProcessing.Color;
using Leadtools.Multimedia;
using DicomVideoCaptureDemo.UI;
using System.Reflection;
using LMMPEG2EncoderLib;
using DicomVideoCaptureDemo.Common;
using LTDicWrtLib;
using System.Runtime.InteropServices;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace DicomVideoCaptureDemo
{
   public partial class MainForm : Form
   {
      #region Variables
      public Leadtools.Multimedia.CaptureCtrl CaptureCtrl1 = new Leadtools.Multimedia.CaptureCtrl();
      DicomDataSet m_DS;
      DicomIod m_pDICOMIOD;
      bool m_bDataSetInitialized = false;
      bool _modified;
      bool _bMMCapabilitiesInitialized;
      bool m_bNowPlaying;
      int m_nInstanceNumber;
      DICOMVID_IMAGE_COMPRESSION m_CompressionType;
      int m_nQFactor;
      ILTDicWrt m_DicomWriter;
      object m_pDICOMFilter;
      Timer _timer;
      private string _openInitialPath = string.Empty;
      #endregion

      #region Device Click Menu
      private void VideoDeviceClick(object sender, System.EventArgs e)
      {
         if (_bMMCapabilitiesInitialized)
         {
            //Point to menu item clicked
            ToolStripMenuItem objCurMenuItem = (ToolStripMenuItem)sender;

            try
            {
               CaptureCtrl1.VideoDevices.Selection = (int)objCurMenuItem.Tag - 1;
            }
            catch
            {
               MessageBox.Show("This video capture device is not available. Make sure no other program is using the device or try changing the display resolution", "Error");
            }

            objCurMenuItem = null;
            UpdateMenuStatus();
         }
      }

      private void AudioDeviceClick(object sender, System.EventArgs e)
      {
         if (_bMMCapabilitiesInitialized)
         {
            try
            {
               //Point to menu item clicked
               ToolStripMenuItem objCurMenuItem = (ToolStripMenuItem)sender;
               CaptureCtrl1.AudioDevices.Selection = (int)objCurMenuItem.Tag - 1;
               objCurMenuItem = null;
            }
            catch (System.Exception ex)
            {
               MessageBox.Show("This audio capture device is not available.\n"+
               "Make sure no other program is using the device.\n"+
               "If you have a player running, you can try setting \n"+
               "the player so it plays to the MIDI device");
            }

            UpdateMenuStatus();
         }
      }
      #endregion

      #region CaptureCtrl Events

      private void CaptureCtrl1_Progress(object sender, ProgressEventArgs e)
      {
         //WriteCaptureStatus(false);
      }

      private void CaptureCtrl1_ErrorAbort(object sender, ErrorAbortEventArgs e)
      {
         MessageBox.Show(" Error " + System.Convert.ToString(e.errorcode) + " occurred in your Application.");
         //UpdateMenuStatus();
      }

      private void MenuFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }


      private void CaptureCtrl1_Complete(object sender, System.EventArgs e)
      {
         //MenuFileSelectCaptureFile.Enabled = true;
         //UpdateMenuStatus();
      }

      private void CaptureCtrl1_KeyDownEvent(object sender, KeyDownEventArgs e)
      {
         if ((e.keyCode == 0X1B) & (CaptureCtrl1.FullScreenMode))
         {
            CaptureCtrl1.ToggleFullScreenMode();
            e.keyCode = 0;
         }
      }

      private void _panel_CapturePanel_Resize(object sender, EventArgs e)
      {
         this.CaptureCtrl1.Size = new System.Drawing.Size(_panel_CapturePanel.Size.Width - 10, _panel_CapturePanel.Size.Height - 10);
      }
      #endregion

      #region Menu Events
      private void _mi_captureProperties_Click(object sender, EventArgs e)
      {
         if (_bMMCapabilitiesInitialized == false)
            return;

         CaptureCtrl1.Preview = false;
         CaptureCtrl1.ShowDialog(CaptureDlg.Capture, this);
         CaptureCtrl1.Preview = true;
      }

      private void _mi_compressionSettings_Click(object sender, EventArgs e)
      {
         CaptureCtrl1.Preview = false;
         CompressionSettingsDlg CompressionSettingsDlg=new CompressionSettingsDlg();
         CompressionSettingsDlg.ShowDialog();
         CaptureCtrl1.Preview = true;
      }

      private void _mi_About_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("Dicom Video Capture", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("Dicom Video Capture"))
            aboutDialog.ShowDialog(this);
#endif
      }

      private void _mi_Toolbar_Click(object sender, EventArgs e)
      {
         _toolbar_Main.Enabled = !_mi_Toolbar.Checked;
         _toolbar_Main.Visible = !_mi_Toolbar.Checked;


         UpdateMenuStatus();
      }

      private void _mi_NewFile_Click(object sender, EventArgs e)
      {
         CreateNewDICOMFile newDicomDlg = new CreateNewDICOMFile();

         switch (CheckDirtyFlag())
         {
            case DialogResult.Yes:
               OnFileSaveAs();
               break;
            case DialogResult.No:
               break;
            case DialogResult.Cancel:
               return;
         }

         //Get class (IOD) for the new DICOM file
         if (newDicomDlg.ShowDialog() == DialogResult.OK)
         {
            WaitCursor Wait = new WaitCursor();

            // Prepare a new data set 
            Reset();
            if (!CreateDICOMFileFromTemplate(newDicomDlg.m_nClass))
            {
               m_DS.Initialize(newDicomDlg.m_nClass, newDicomDlg.m_nFlags);
            }

            // Remove any optional elements from 
            // the dataset and set some default values 
            CleanDSAndSetDefaultValues(newDicomDlg.m_nClass,m_DS, false);

            // Is this IOD in our list ?
            if ((m_pDICOMIOD = GetDSIOD(m_DS)) == null)
            {
               MessageBox.Show("Could not create a new DICOM file");
               return;
            }
            //Yes we have a valid dataset
            m_bDataSetInitialized = true;
            // Update the elements tree
            updateTreeView();
            SetModifiedFlag(true);
         }

         UpdateMenuStatus();

      }

      private void _mi_OpenFile_Click(object sender, EventArgs e)
      {
         switch (CheckDirtyFlag())
         {
            case DialogResult.Yes:
               OnFileSaveAs();
               break;
            case DialogResult.No:
               break;
            case DialogResult.Cancel:
               return;
         }

         OpenFileDialog dlg = new OpenFileDialog();
         dlg.Filter = "DCM Files (*.dcm)|*.dcm|DICOM Files (*.dic)|*.dic|All files (*.*)|*.*";
         dlg.InitialDirectory = _openInitialPath;

         if (dlg.ShowDialog() == DialogResult.OK)
         {
            _openInitialPath = Path.GetDirectoryName(dlg.FileName);
            WaitCursor Wait = new WaitCursor();
            Reset();
            // Load Data Set from this file.
            m_DS.Load(dlg.FileName, DicomDataSetLoadFlags.None);

            // Is this IOD in our list ?
            if ((m_pDICOMIOD = GetDSIOD(m_DS)) == null)
            {
               m_DS.Reset();
               MessageBox.Show("This DICOM file does not support multi-frame images"); ;
            }
            else
            {
               ChangeDSToAcceptCompressed();
               m_bDataSetInitialized = true;
            }
            // Update the elements tree
            updateTreeView();
            UpdateMenuStatus();
         }
      }

      private void _mi_SaveFile_Click(object sender, EventArgs e)
      {
         SaveFileDialog dlg = new SaveFileDialog();
         dlg.Filter = "DCM Files (*.dcm)|*.dcm|All files (*.*)|*.*";

         if (dlg.ShowDialog() == DialogResult.OK)
         {
            String strOutputFileName = GetOutputFileName();
            if (strOutputFileName.Length > 0)
            {
               DicomDataSet VideoStreamIntoDataset = new DicomDataSet();
               try
               {
                  VideoStreamIntoDataset.Load(strOutputFileName, DicomDataSetLoadFlags.None);
                  m_DS.Copy(VideoStreamIntoDataset, null, null);
               }
               catch (Exception)
               { 
               }

               m_DS.Save(dlg.FileName, DicomDataSetSaveFlags.GroupLengths | DicomDataSetSaveFlags.MetaHeaderPresent);
            }
            SetModifiedFlag(false);
         }
      }

      private void _mi_CloseFile_Click(object sender, EventArgs e)
      {
         switch (CheckDirtyFlag())
         {
            case DialogResult.Yes:
               OnFileSaveAs();
               break;
            case DialogResult.No:
               break;
            case DialogResult.Cancel:
               return;
         }
         Reset();


         String strOutputFileName = GetOutputFileName();
         if (strOutputFileName.Length > 0)
         {
            File.Delete(strOutputFileName);
         }

         UpdateMenuStatus();
         updateTreeView();
      }

      private void _mi_StartCaptureIntoDicomFile_Click(object sender, EventArgs e)
      {
         if (false == _bMMCapabilitiesInitialized)
            return;

         if (!m_bDataSetInitialized)
         {
            MessageBox.Show("Before you start capturing please either load a DICOM file or create a new one.");
            return;
         }

         CaptureCtrl1.Preview = false;
         if (GetCompression() == DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2)
         {
            MessageBox.Show("Warning: Compressing MPEG2 data requires high computation power. We recommend using a high-end machine capable of handling this type of load." +
                            "\n\nPlease note that the size (width and height) of the video you capture heavily affects the speed of the compression process. For example compressing a (640X480) video is approximately four times slower than compressing a (320X240) video. You can change the size of the video by adjusting the \"Capture Properties\" from the \"Options\" menu.");
         }
         CaptureCtrl1.Preview = true;

         WaitCursor Wait = new WaitCursor();

         String strTemplate = GetTemplateFileName(true);
         String strOutput = GetOutputFileName();

         m_DicomWriter.DICOMTemplateFile = strTemplate;
         CaptureCtrl1.TargetFile = strOutput;

         // Ok start capturing now
         if (GetCompression() == DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2)
         {
            Devices devices;
            int index = -1;
            devices = CaptureCtrl1.AudioDevices;
            index = devices.Selection;
            if (index == -1)
            {
               CaptureCtrl1.StartCapture(CaptureMode.Video);
            }
            else
            {
               CaptureCtrl1.StartCapture(CaptureMode.VideoAndAudio);
            }

         }
         else
         {
            CaptureCtrl1.StartCapture(CaptureMode.Video);
         }

         //Show the user that capturing is in progress
         StartToolbarPlay();
         SetModifiedFlag(true);

         UpdateMenuStatus();
      }

      private void _mi_StopCapture_Click(object sender, EventArgs e)
      {
         WaitCursor Wait = new WaitCursor();

         if (false == _bMMCapabilitiesInitialized)
            return;

         CaptureCtrl1.StopCapture();
         StopToolbarPlay();

         UpdateMenuStatus();
      }

      public void UpdateMenuStatus()
      {
         // Uncheck Menus
         foreach (ToolStripMenuItem menuItem in _mi_VideoDevice.DropDownItems)
         {
            menuItem.Checked = false;
            menuItem.Enabled = !IsCapturing();
         }

         foreach (ToolStripMenuItem menuItem in _mi_AudioDevice.DropDownItems)
         {
            menuItem.Checked = false;
            menuItem.Enabled = !IsCapturing();
         }

         // Check Menus
         ((ToolStripMenuItem)_mi_VideoDevice.DropDownItems[CaptureCtrl1.VideoDevices.Selection + 1]).Checked = true;
         ((ToolStripMenuItem)_mi_AudioDevice.DropDownItems[CaptureCtrl1.AudioDevices.Selection + 1]).Checked = true;

         _mi_Toolbar.Checked = _toolbar_Main.Enabled;


         _mi_CloseFile.Enabled = m_bDataSetInitialized && !IsCapturing();
         _mi_SaveFile.Enabled = _tS_Save.Enabled = m_bDataSetInitialized && !IsCapturing();
         _mi_NewFile.Enabled = _tS_New.Enabled = !IsCapturing();
         _mi_OpenFile.Enabled = _tS_Open.Enabled = !IsCapturing();

         if (_bMMCapabilitiesInitialized)
         {
            CaptureState state;
            state = CaptureCtrl1.State;
            bool f;
            f = CaptureCtrl1.IsModeAvailable(CaptureMode.Video);
            _mi_StartCaptureIntoDicomFile.Enabled = f && (state != CaptureState.Running);
            _mi_StopCapture.Enabled = IsCapturing();
            _mi_compressionSettings.Enabled = m_bDataSetInitialized && !IsCapturing();
            f = CaptureCtrl1.HasDialog(CaptureDlg.Capture);
            _mi_captureProperties.Enabled = f && (state != CaptureState.Running);

         }
         else
         {
            _mi_StartCaptureIntoDicomFile.Enabled = false;
            _mi_StopCapture.Enabled = false;
            _mi_compressionSettings.Enabled = false;
            _mi_captureProperties.Enabled = false;
         }
      }

      #endregion

      #region Toolbar Events

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         _mi_NewFile_Click(null, null);
      }

      private void toolStripButton2_Click(object sender, EventArgs e)
      {
         _mi_OpenFile_Click(null, null);
      }

      private void toolStripButton3_Click(object sender, EventArgs e)
      {
         _mi_SaveFile_Click(null, null);
      }

      private void toolStripButton4_Click(object sender, EventArgs e)
      {
         _mi_About_Click(null, null);
      }

      #endregion      

      #region TreeView Methods
      void updateTreeView()
      {
         _treeView.Nodes.Clear();
         if (m_DS != null)
         {
            if (m_DS.InformationClass == DicomClassType.BasicDirectory)
               return;

            if (_treeView.ImageList == null || _treeView.ImageList.Images.Count == 0)
            {
               _treeView.ImageList = new ImageList();
               _treeView.ImageList.Images.Add(Properties.Resources.STORAGE1);
               _treeView.ImageList.Images.Add(Properties.Resources.STORAGE2);
               _treeView.ImageList.Images.Add(Properties.Resources.STREAM);

            }

            DoFillDICOMElementsTree(m_DS, null, null);
         }
      }

      void DoFillDICOMElementsTree
      (
         DicomDataSet pDS,
         TreeNode hParentTree,
         DicomElement pParentElement
      )
      {
         int i;
         UInt32 j;
         int nCount;
         DicomClassType nClass;
         DicomDataSetFlags nFlags;
         DicomModule pModule;
         DicomElement pElement;
         DicomIod pIOD;
         TreeNode hItem;
         string strName;


         if (pParentElement == null)
         {

            nClass = pDS.InformationClass;
            nFlags = pDS.InformationFlags;
            nCount = pDS.ModuleCount;
            for (i = 0; i < nCount; i++)
            {
               pModule = pDS.FindModuleByIndex(i);
               if (pModule != null)
               {
                  pIOD = DicomIodTable.Instance.FindModule(nClass, pModule.Type);
                  if (pIOD != null)
                  {
                     strName = pIOD.Name;
                  }
                  else
                  {
                     strName = "Unknown";
                  }

                  hParentTree = _treeView.Nodes.Add(strName, strName, 0, 0);
                  /*hParentTree = GetTreeCtrl ().InsertItem( strName, 
                                                   GetImage(IDB_STORAGE_COLLAPSED), 
                                                   GetImage(IDB_STORAGE_COLLAPSED), 
                                                   TVI_ROOT, 
                                                   TVI_LAST);
                  GetTreeCtrl ().SetItemState(hParentTree, TVIS_BOLD, TVIS_BOLD);*/

                  for (j = 0; j < pModule.Elements.Length; j++)
                  {
                     hItem = InsertElement(hParentTree, pModule.Elements[j]);
                     if (pDS.GetChildElement(pModule.Elements[j], true) != null)
                     {
                        DoFillDICOMElementsTree(pDS, hItem, pModule.Elements[j]);
                     }
                  }
               }
            }
         }
         else
         {
            pElement = pDS.GetChildElement(pParentElement, true);
            while (pElement != null)
            {
               hItem = InsertElement(hParentTree, pElement);

               if ((pElement.Length == 0xFFFFFFFF) && (pDS.GetChildElement(pElement, true) != null))
               {
                  if (pDS.GetChildElement(pElement, true) != null)
                  {
                     DoFillDICOMElementsTree(pDS, hItem, pElement);
                  }
               }

               pElement = pDS.GetNextElement(pElement, true, true);
            }
         }
      }

      TreeNode InsertElement(TreeNode hParentTree, DicomElement pElement)
      {
         String strName = null;
         DicomTag pTag = null;
         TreeNode hItem = null;
         String strValue = null;


         pTag = DicomTagTable.Instance.Find(pElement.Tag);

         strName = string.Format("{0:X4}:{1:X4} - {2}",
                        (short)(pElement.Tag >> 16),
                        (short)(pElement.Tag & 0xFFFF),
                        (pTag != null) ? pTag.Name : "Unknown");

         GetElementValue(pElement, ref strValue);
         strName = strName + " : ";
         if (strValue != null && strValue.Length > 0)
         {
            strName = strName + strValue;
         }
         if (pElement.Length == 0xFFFFFFFF)
         {
            hItem = hParentTree.Nodes.Add(strName, strName, 0, 0);
         }
         else
         {
            hItem = hParentTree.Nodes.Add(strName, strName, 2, 2);
         }

         if (hItem != null)
         {
            hItem.Tag = pElement;
         }

         return hItem;
      }


      private void _treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
      {
         TreeNode hItem = e.Node;
         if (hItem != null)
         {
            DicomElement pElement = (DicomElement)hItem.Tag;
            if ((pElement != null) && (pElement.Tag != DicomTag.PixelData))
            {
               String strName;
               DicomTag pTag;
               String strValue = "";
               DicomModifyElementDlg dlg = new DicomModifyElementDlg();

               pTag = DicomTagTable.Instance.Find(pElement.Tag);
               if (null == pTag)
               {
                  return;
               }
               strName = string.Format("{0}", (pTag != null) ? pTag.Name : "Unknown");
               GetElementValue(pElement, ref strValue);
               strName = strName + " : ";

               DicomDataSet pDS = m_DS;
               if (pDS != null)
               {
                  dlg.m_pDicomIOD = DicomIodTable.Instance.Find(m_pDICOMIOD, pElement.Tag, DicomIodType.Element, false);
                  dlg.m_pElement = pElement;
                  dlg.m_strValue = strValue;
                  dlg.m_nCount = pDS.GetElementValueCount(pElement);
                  if ((dlg.m_pDicomIOD != null) && (dlg.ShowDialog() == DialogResult.OK))
                  {
                     dlg.m_strValue.TrimStart();
                     dlg.m_strValue.TrimEnd();
                     pDS.FreeElementValue(dlg.m_pElement);
                     pDS.SetConvertValue(dlg.m_pElement, dlg.m_strValue, dlg.m_nCount);
                     strValue = "";
                     strValue = string.Format("{0:X4}:{1:X4} - {2}",
                                       (UInt16)(pElement.Tag >> 16),
                                       (UInt16)(pElement.Tag & 0xFFFF),
                                       (pTag != null) ? pTag.Name : "Unknown");
                     strValue = strValue + " : " + dlg.m_strValue;
                     hItem.Text = strValue;
                     SetModifiedFlag(true);
                  }
               }
            }
         }
      }
      #endregion

      #region MainForm Events
      private void MainForm_Load(object sender, EventArgs e)
      {
         InitMMCapabilities();
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         switch (CheckDirtyFlag())
         {
            case DialogResult.Yes:
               OnFileSaveAs();
               break;
            case DialogResult.No:
               break;
            case DialogResult.Cancel:
               e.Cancel = true;
               break;
         }
      }
      #endregion

      #region Public Methods
      public void SetQFactor(int nQFactor)
      {
         if (nQFactor < Helper.Q_FACTOR_MIN)
         {
            nQFactor = Helper.Q_FACTOR_MIN;
         }
         if (nQFactor > Helper.Q_FACTOR_MAX)
         {
            nQFactor = Helper.Q_FACTOR_MAX;
         }
         m_nQFactor = nQFactor;
         m_DicomWriter.CompressionQuality = m_nQFactor;
      }

      public int GetQFactor()
      {
         return m_nQFactor;

      }

      public void SetCompression(DICOMVID_IMAGE_COMPRESSION ImageCompression)
      {
         m_CompressionType = ImageCompression;
         DICOM_WRITER_FILTER_TARGET_FORMAT TargetFormat = DICOM_WRITER_FILTER_TARGET_FORMAT.DICOM_WRITER_FILTER_TARGET_FORMAT_CUSTOM;

         if (m_CompressionType == DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2)
         {
            TargetFormat = DICOM_WRITER_FILTER_TARGET_FORMAT.DICOM_WRITER_FILTER_TARGET_FORMAT_MPEG2;
         }
         else
         {
            DICOMCOMPRESSION nDICOMCompression = DICOMCOMPRESSION.COMP_UNCOMPRESSED;
            TargetFormat = DICOM_WRITER_FILTER_TARGET_FORMAT.DICOM_WRITER_FILTER_TARGET_FORMAT_CUSTOM;
            switch (m_CompressionType)
            {
               case DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_NONE:
                  nDICOMCompression = DICOMCOMPRESSION.COMP_UNCOMPRESSED;
                  break;
               case DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_JPEGLOSSLESS:
                  nDICOMCompression = DICOMCOMPRESSION.COMP_LOSSLESSJPEG;
                  break;
               case DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_JPEGLOSSY:
                  nDICOMCompression = DICOMCOMPRESSION.COMP_JPEG422;
                  break;
               case DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_J2KLOSSLESS:
                  nDICOMCompression = DICOMCOMPRESSION.COMP_LOSSLESSJPEG2000;
                  break;
               case DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_J2KLOSSY:
                  nDICOMCompression = DICOMCOMPRESSION.COMP_JPEG2000;
                  break;
               default:
                  return;

            }

            m_DicomWriter.CompressionFormat = (int)nDICOMCompression;
         }

         SetTargetFormat(TargetFormat);
      }

      public DICOMVID_IMAGE_COMPRESSION GetCompression()
      {
         return m_CompressionType;
      }

      public void ShowMPEG2OptionsDlg()
      {
         if (GetCompression() == DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2)
         {
            CaptureCtrl1.ShowDialog(CaptureDlg.VideoCompressor, this);
         }
         else
         {
            CaptureCtrl1.ShowDialog(CaptureDlg.TargetFormat, this);
         }

         CaptureCtrl1.StopCapture();
      }

      public void ShowMPEG2AudioOptionsDlg()
      {
         if (GetCompression() == DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2)
         {
            CaptureCtrl1.ShowDialog(CaptureDlg.AudioCompressor, this);
         }

         CaptureCtrl1.StopCapture();
      }
      #endregion

      public MainForm()
      {
         InitializeComponent();

         // Setup the caption for this demo
         Messager.Caption = "C# Dicom Video Capture Demo";

         DicomEngine.Startup();
         m_DS = new DicomDataSet();
      }

      bool InitMMCapabilities()
      {
         m_DicomWriter = null;
         _bMMCapabilitiesInitialized = false;
         CreateTargetFormats();

         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         ((System.ComponentModel.ISupportInitialize)(this.CaptureCtrl1)).BeginInit();
         this.CaptureCtrl1.AudioDevices.Selection = -1;
         this.CaptureCtrl1.Location = new System.Drawing.Point(5, 5);
         this.CaptureCtrl1.Name = "CaptureCtrl1";
         this.CaptureCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CaptureCtrl1.OcxState")));
         this.CaptureCtrl1.Size = new System.Drawing.Size(_panel_CapturePanel.Size.Width - 10, _panel_CapturePanel.Size.Height - 10);
         this.CaptureCtrl1.TabIndex = 3;
         this.CaptureCtrl1.VideoDevices.Selection = -1;
         this.CaptureCtrl1.KeyDown += new Leadtools.Multimedia.KeyDownEventHandler(this.CaptureCtrl1_KeyDownEvent);
         this.CaptureCtrl1.ErrorAbort += new Leadtools.Multimedia.ErrorAbortEventHandler(this.CaptureCtrl1_ErrorAbort);
         this.CaptureCtrl1.Complete += new System.EventHandler(this.CaptureCtrl1_Complete);
         this.CaptureCtrl1.Progress += new Leadtools.Multimedia.ProgressEventHandler(this.CaptureCtrl1_Progress);
         this.CaptureCtrl1.BackColor = Color.White;
         this._panel_CapturePanel.Controls.Add(this.CaptureCtrl1);
         CaptureCtrl1.EnterEdit();
         CaptureCtrl1.VideoWindowSizeMode = SizeMode.Normal;
         CaptureCtrl1.Preview = true;
         CaptureCtrl1.LeaveEdit();

         IntPtr pUnk = Marshal.GetIUnknownForObject(m_pDICOMFilter);
         Guid guid = typeof(ILTDicWrt).GUID;
         IntPtr pI;
         Marshal.QueryInterface(pUnk, ref guid, out pI);

         m_DicomWriter = Marshal.GetObjectForIUnknown(pI) as ILTDicWrt;
         _bMMCapabilitiesInitialized = true;
         SetCompression(DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_NONE);
         SetQFactor(Helper.Q_FACTOR_MIN);

         BuildDeviceMenu();
         UpdateMenuStatus();
         return true;
      }

      void BuildDeviceMenu()
      {
         int count = 0;
         string name = null;

         count = CaptureCtrl1.VideoDevices.Count;
         // Adding the 'None' menu Item.
         // Set the caption to 'None'.
         ToolStripMenuItem menuItem1 = new ToolStripMenuItem("None");
         menuItem1.Tag = _mi_VideoDevice.DropDownItems.Count;
         _mi_VideoDevice.DropDownItems.Add(menuItem1);
         menuItem1.Click += new System.EventHandler(VideoDeviceClick);

         if (count > 0)
         {
            // Adding the Video Devices to the Video Device menu item.
            foreach (Device dev in CaptureCtrl1.VideoDevices)
            {
               // Get the Device name
               name = dev.FriendlyName;
               // Create the Menu Item.
               ToolStripMenuItem menuItem2 = new ToolStripMenuItem(name);
               menuItem2.Tag = _mi_VideoDevice.DropDownItems.Count;
               _mi_VideoDevice.DropDownItems.Add(menuItem2);
               menuItem2.Click += new System.EventHandler(VideoDeviceClick);
            }
         }

         count = CaptureCtrl1.AudioDevices.Count;
         // Adding the 'None' menu Item.
         // Set the caption to 'None'.
         ToolStripMenuItem menuItem3 = new ToolStripMenuItem("None");
         menuItem3.Tag = _mi_AudioDevice.DropDownItems.Count;
         _mi_AudioDevice.DropDownItems.Add(menuItem3);
         menuItem3.Click += new System.EventHandler(AudioDeviceClick);

         if (count > 0)
         {
            // Adding the Audio Devices to the Audio Device menu item.
            foreach (Device dev in CaptureCtrl1.AudioDevices)
            {
               // Get the Device name
               name = dev.FriendlyName;
               ToolStripMenuItem menuItem2 = new ToolStripMenuItem(name);
               menuItem2.Tag = _mi_AudioDevice.DropDownItems.Count;
               _mi_AudioDevice.DropDownItems.Add(menuItem2);
               menuItem2.Click += new System.EventHandler(AudioDeviceClick);
               // Create the Menu Item.
            }
         }
      }

      #region Methods
      DicomIod GetDSIOD(DicomDataSet pDS)
      {
         if (pDS != null)
         {
            DicomElement pElement;
            pElement = pDS.FindFirstElement(null, DicomTag.SOPClassUID, false);
            if (pElement != null)
            {
               string pszText = null;
               int nClass = -1;

               pszText = pDS.GetConvertValue(pElement);
               if (pszText != null)
               {
                  nClass = GetClassFromUID(pszText);
                  if (nClass != -1)
                  {
                     return GetIODFromMyList(nClass);
                  }

               }
            }
         }
         return null;
      }

      DicomIod GetIODFromMyList(int nClass)
      {
         if (nClass == -1)
            return null;
         return (DicomIodTable.Instance.FindClass((DicomClassType)nClass));
      }

      int GetClassFromUID(string pszUID)
      {
         for (int i = 0; i < CreateNewDICOMFile.m_DICOMUIDIOD.Length; i++)
         {
            if (CreateNewDICOMFile.m_DICOMUIDIOD[i].pszUID == pszUID)
               return (int)CreateNewDICOMFile.m_DICOMUIDIOD[i].nClass;
         }
         return -1;
      }

      void CleanDSAndSetDefaultValues
         (
         DicomClassType uClass,
         DicomDataSet pDicomDataSet,
         bool bInsertMissingElements
         )
      {
         CleanDataSet(uClass, pDicomDataSet);
         // Set some default values 
         SetDSDefaultValues(ref pDicomDataSet, bInsertMissingElements);
      }

      void CreateTargetFormats()
      {
         
         TargetFormats  formats = null;
         TargetFormat   format  = null;

         formats = CaptureCtrl1.TargetFormats;
         format = formats.DICOM;
         
         format.UseFilterCache = true;
         /// get the DICOM filter for private use
         m_pDICOMFilter = format.GetCacheObject(TargetFormatObject.Mux);

         format = formats.MPEG2DICOM;
         format.UseFilterCache = true;
      }

      // Set some default values from a predefined table(m_DefaultElementValues)
      void SetDSDefaultValues(ref DicomDataSet pDicomDataSet, bool bInsertMissingElements)
      {

         int i;
         DicomTag pTag;
         DicomVRType nVR;
         DicomElement pElement;
         DateTime Time;
         string szValue;


         Time = DateTime.Now;
         // Loop through all the elements in the default value table
         for (i = 0; i < Helper.DefaultElementValues.Length; i++)
         {

            pTag = DicomTagTable.Instance.Find(Helper.DefaultElementValues[i].nTag);
            nVR = ((pTag != null) ? pTag.VR : DicomVRType.UN);
            pElement = null;
            pElement = pDicomDataSet.FindFirstElement(null, Helper.DefaultElementValues[i].nTag, false);
            if (pElement == null)
            {
               // If the element is missing and the user of 
               // this functions wants to add it , then add it 
               if (bInsertMissingElements)
               {
                  pElement = pDicomDataSet.InsertElement(null,
                                                            false,
                                                            Helper.DefaultElementValues[i].nTag,
                                                            nVR,
                                                            false,
                                                            -1);
               }
            }
            if (Helper.DefaultElementValues[i].nTag == DicomTag.DateOfSecondaryCapture)
            {
               szValue = string.Format("{0:D2}/{1:D2}/{2:D4}", Time.Month, Time.Day, Time.Year);
               if (pElement != null)
               {
                  pDicomDataSet.FreeElementValue(pElement);
                  pDicomDataSet.SetConvertValue(pElement, szValue, 1);
               }
            }
            else
               if (Helper.DefaultElementValues[i].nTag == DicomTag.TimeOfSecondaryCapture)
               {
                  szValue = string.Format("{0:D2}:{1:D2}:{2:D4}.0", Time.Hour, Time.Minute, Time.Second);
                  if (pElement != null)
                  {
                     pDicomDataSet.FreeElementValue(pElement);
                     pDicomDataSet.SetConvertValue(pElement, szValue, 1);
                  }
               }
               else
               {
                  if ((pElement != null) && CanUpdateElementValue(pDicomDataSet, pElement))
                  {
                     // Set the value for this element
                     pDicomDataSet.FreeElementValue(pElement);
                     pDicomDataSet.SetConvertValue(pElement, Helper.DefaultElementValues[i].pszValue, 1);
                  }
               }
         }
         // Set different UIDs for this dataset 
         SetInstanceUIDs(pDicomDataSet);
         //Set instance numbers
         SetInstanceNumbers(pDicomDataSet, m_nInstanceNumber++);
         // Update study date and time
         SetStudyDateAndTime(pDicomDataSet);
         // Set meta header info
         InsertMetaHeader(pDicomDataSet);
      }

      bool CanUpdateElementValue(DicomDataSet pDicomDataSet, DicomElement pElement)
      {
         if ((pElement != null) && (pDicomDataSet.GetConvertValue(pElement) != null))
         {
            switch (pElement.Tag)
            {
               case DicomTag.MediaStorageSOPClassUID:
               case DicomTag.SOPClassUID:
               case DicomTag.Modality:
                  return false;
            }
         }
         return true;
      }

      void InsertMetaHeader(DicomDataSet pDS)
      {
         DicomElement pElement;

         // Add File Meta Information Version
         pElement = pDS.FindFirstElement(null, DicomTag.FileMetaInformationVersion, false);
         if (pElement == null)
         {
            pElement = pDS.InsertElement(null,
                                          false,
                                          DicomTag.FileMetaInformationVersion,
                                          DicomVRType.OB,
                                          false,
                                          0);
         }
         if (pElement != null)
         {
            byte[] cValue = { 0x00, 0x01 };
            pDS.SetByteValue(pElement, cValue, 2);
         }
         // Implementation Class UID
         pElement = pDS.FindFirstElement(null, DicomTag.ImplementationClassUID, false);
         if (pElement == null)
         {
            pElement = pDS.InsertElement(null, false, DicomTag.ImplementationClassUID, DicomVRType.UI, false, 0);
         }
         if (pElement != null)
         {
            pDS.SetConvertValue(pElement, Helper.LEAD_IMPLEMENTATION_CLASS_UID, 1);
         }

         // Implementation Version Name
         pElement = pDS.FindFirstElement(null, DicomTag.ImplementationVersionName, false);
         if (pElement == null)
         {
            pElement = pDS.InsertElement(null, false, DicomTag.ImplementationVersionName, DicomVRType.SH, false, 0);
         }
         if (pElement != null)
         {
            pDS.SetConvertValue(pElement, Helper.LEAD_IMPLEMENTATION_VERSION_NAME, 1);
         }
      }

      void CleanDataSet(DicomClassType uClass, DicomDataSet pDicomDataSet)
      {
         DeleteEmptyElementsType3(uClass, pDicomDataSet);
         DeleteEmptyModulesOptional(uClass, pDicomDataSet);
      }

      void DeleteEmptyModulesOptional(DicomClassType uClass, DicomDataSet pDicomDataSet)
      {
         int nCountModule = DicomIodTable.Instance.GetModuleCount(uClass);
         DicomIod pIOD;

         for (int i = 0; i < nCountModule; i++)
         {
            pIOD = DicomIodTable.Instance.FindModuleByIndex(uClass, i);
            if ((pIOD != null) && (pIOD.Usage == DicomIodUsageType.OptionalModule))
            {
               DicomModule pModule = pDicomDataSet.FindModule(pIOD.ModuleCode);
               if ((pModule != null) && IsEmptyModule(pModule, pDicomDataSet))
                  pDicomDataSet.DeleteModule(pIOD.ModuleCode);
            }
         }
      }

      bool IsEmptyModule(DicomModule pModule, DicomDataSet pDicomDataSet)
      {
         if (pModule == null)
            return true;

         bool bEmpty = true;
         for (UInt32 i = 0; i < pModule.Elements.Length; i++)
         {
            if (pModule.Elements[i].Length == 0xFFFFFFFFU)
               bEmpty = bEmpty && IsEmptySequence(pModule.Elements[i], pDicomDataSet);

            else if (pModule.Elements[i].Length != 0)
            {
               bEmpty = false;
            }
         }
         return bEmpty;
      }

      // Delete any optional element which has no value
      void DeleteEmptyElementsType3(DicomClassType uClass, DicomDataSet pDicomDataSet)
      {
         DicomElement pElementPrev = null;
         DicomElement pElement;
         DicomIod pIODClass = DicomIodTable.Instance.FindClass(uClass);
         if (pIODClass != null)
         {
            DicomIod pIOD;

            pElement = pDicomDataSet.GetFirstElement(null, false, true);
            pElementPrev = null;
            while (pElement != null)
            {
               pIOD = DicomIodTable.Instance.Find(pIODClass, pElement.Tag, DicomIodType.Element, false);

               if ((pIOD != null) && (pIOD.Usage == DicomIodUsageType.OptionalElement))
               {
                  // nLength==0 means (1) Sequence     or (2)Empty Element 

                  // Case 1: Sequence
                  if (pElement.Length == 0xFFFFFFFFU)
                  {
                     bool bEmptySequence = IsEmptySequence(pElement, pDicomDataSet);
                     if (bEmptySequence)
                     {
                        //if deleting the first element, pElementPrev is NULL
                        //Therefore we must call GetFirstElement
                        pDicomDataSet.DeleteElement(pElement);
                        pElement = pElementPrev;
                        if (pElement == null)
                           pElement = pDicomDataSet.GetFirstElement(null, false, true);
                     }
                  }

                  // Case 2: Empty Element
                  else if (pElement.Length == 0)
                  {
                     //if deleting the first element, pElementPrev is NULL
                     //Therefore we must call GetFirstElement
                     pDicomDataSet.DeleteElement(pElement);
                     pElement = pElementPrev;
                     if (pElement == null)
                        pElement = pDicomDataSet.GetFirstElement(null, false, true);
                  }
               }

               pElementPrev = pElement;
               pElement = pDicomDataSet.GetNextElement(pElement, false, true);
            }
         }

      }

      bool IsEmptySequence(DicomElement pElementSequence, DicomDataSet pDicomDataSet)
      {
         DicomElement pElementItem;
         DicomElement pElement;
         bool bEmpty;


         bEmpty = true;
         pElementItem = pDicomDataSet.GetChildElement(pElementSequence, true);
         while (pElementItem != null)
         {
            pElement = pDicomDataSet.GetChildElement(pElementItem, true);
            while (pElement != null)
            {
               // If a sequence, make a recursive call
               if (pElement.Length == 0xFFFFFFFFU)
                  bEmpty = bEmpty && IsEmptySequence(pElement, pDicomDataSet);

               else if (pElement.Length != 0)
               {
                  bEmpty = false;
               }
               pElement = pDicomDataSet.GetNextElement(pElement, true, true);
            }
            pElementItem = pDicomDataSet.GetNextElement(pElementItem, true, true);
         }
         return bEmpty;
      }

      DialogResult CheckDirtyFlag()
      {
         if (IsModified())
         {
            return MessageBox.Show("Do you want to save the changes you made to this Data Set?", "", MessageBoxButtons.YesNoCancel);
         }

         return DialogResult.No;
      }

      bool IsModified()
      {
         return _modified;
      }

      void Reset()
      {
         m_DS.Reset();
         m_pDICOMIOD = null;
         m_bDataSetInitialized = false;

         SetModifiedFlag(false);
      }

      // Save DICOM file
      void OnFileSaveAs()
      {
         SaveFileDialog dlg = new SaveFileDialog();
         dlg.Filter = "DCM Files (*.dcm)|*.dcm|All files (*.*)|*.*||";

         // Get file name
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            WaitCursor Wait = new WaitCursor();
            //Save dataset into file

            try
            {
               String strOutputFileName = GetOutputFileName();
               if (strOutputFileName.Length > 0)
               {
                  DicomDataSet VideoStreamIntoDataset = new DicomDataSet();

                  VideoStreamIntoDataset.Load(strOutputFileName, DicomDataSetLoadFlags.LoadAndClose);
                  m_DS.Copy(VideoStreamIntoDataset, null, null);
                  m_DS.Save(dlg.FileName, DicomDataSetSaveFlags.GroupLengths | DicomDataSetSaveFlags.MetaHeaderAbsent);
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }

            SetModifiedFlag(false);
         }
      }

      void SetModifiedFlag(bool bSet)
      {
         _modified = bSet;
      }

      bool CreateDICOMFileFromTemplate(DicomClassType uClass)
      {
         byte[] fileData = null;

         switch (uClass)
         {

            case DicomClassType.VideoEndoscopicImageStorage:
               fileData = Properties.Resources.Video_endoscopy;
               break;
            case DicomClassType.VideoMicroscopicImageStorage:
               fileData = Properties.Resources.Video_microscopy;
               break;
            case DicomClassType.VideoPhotographicImageStorage:
               fileData = Properties.Resources.Video_Photography;
               break;
            case DicomClassType.SCMultiFrameTrueColorImageStorage:
               fileData = Properties.Resources.Multi_frame_SC;
               break;
            default:
               return false;
         }

         string szTempPath = Path.GetTempPath();
         string pszFullName = Path.Combine(szTempPath, "TemplatePS.dcm");
         if (pszFullName == null)
         {

            return false;
         }

         Stream fileStream = File.Create(pszFullName);
         if (fileStream == null)
         {

            return false;
         }

         fileStream.Write(fileData, 0, fileData.Length);
         fileStream.Flush();
         fileStream.Close();

         // Loading the DS
         m_DS.Load(pszFullName, DicomDataSetLoadFlags.LoadAndClose);

         File.Delete(pszFullName);
         return true;
      }

      void SetInstanceUIDs(DicomDataSet pDicomDataSet)
      {
         DicomElement pElement;
         string pszInstanceGuid;


         // Set STUDY INSTANCE UID
         pElement = pDicomDataSet.FindFirstElement(null, DicomTag.StudyInstanceUID, false);
         if (pElement == null)
         {
            pElement = pDicomDataSet.InsertElement(null, false, DicomTag.StudyInstanceUID, DicomVRType.UI, false, 0);
         }
         pszInstanceGuid = WinAPI.GenerateDicomUniqueIdentifier();
         pDicomDataSet.SetConvertValue(pElement, pszInstanceGuid, 1);

         // Set SERIES INSTANCE UID
         pElement = pDicomDataSet.FindFirstElement(null, DicomTag.SeriesInstanceUID, false);
         if (pElement == null)
         {
            pElement = pDicomDataSet.InsertElement(null, false, DicomTag.SeriesInstanceUID, DicomVRType.UI, false, 0);
         }
         pDicomDataSet.FreeElementValue(pElement);
         pszInstanceGuid = WinAPI.GenerateDicomUniqueIdentifier();
         pDicomDataSet.SetConvertValue(pElement, pszInstanceGuid, 1);

         // Set SOP INSTANCE UID
         pszInstanceGuid = WinAPI.GenerateDicomUniqueIdentifier();
         pElement = pDicomDataSet.FindFirstElement(null, DicomTag.SOPInstanceUID, false);
         if (pElement == null)
         {
            pElement = pDicomDataSet.InsertElement(null, false, DicomTag.SOPInstanceUID, DicomVRType.UI, false, 0);
         }
         pDicomDataSet.FreeElementValue(pElement);
         pDicomDataSet.SetConvertValue(pElement, pszInstanceGuid, 1);

         // Media Storage SOP Instance UID
         pElement = pDicomDataSet.FindFirstElement(null, DicomTag.MediaStorageSOPInstanceUID, false);
         if (pElement == null)
         {
            pElement = pDicomDataSet.InsertElement(null, false, DicomTag.MediaStorageSOPInstanceUID, DicomVRType.UI, false, 0);
         }
         pDicomDataSet.FreeElementValue(pElement);
         pDicomDataSet.SetConvertValue(pElement, pszInstanceGuid, 1);
      }

      void SetInstanceNumbers(DicomDataSet pDicomDataSet, int nInstanceNumber)
      {
         DicomElement pElement;
         string szValue;

         szValue = nInstanceNumber.ToString();

         // Series number
         pElement = pDicomDataSet.FindFirstElement(null, DicomTag.SeriesNumber, false);
         if (pElement != null)
         {
            pDicomDataSet.FreeElementValue(pElement);
            pDicomDataSet.SetConvertValue(pElement, szValue, 1);
         }

         // Instance number
         pElement = pDicomDataSet.FindFirstElement(null, DicomTag.InstanceNumber, false);
         if (pElement != null)
         {
            pDicomDataSet.FreeElementValue(pElement);
            pDicomDataSet.SetConvertValue(pElement, szValue, 1);
         }
         // Study ID
         pElement = pDicomDataSet.FindFirstElement(null, DicomTag.StudyID, false);
         if (pElement != null)
         {
            pDicomDataSet.FreeElementValue(pElement);
            pDicomDataSet.SetConvertValue(pElement, szValue, 1);
         }

         szValue = "854125" + nInstanceNumber.ToString();
         // Accession number
         pElement = pDicomDataSet.FindFirstElement(null, DicomTag.AccessionNumber, false);
         if (pElement != null)
         {
            pDicomDataSet.FreeElementValue(pElement);
            pDicomDataSet.SetConvertValue(pElement, szValue, 1);
         }
      }

      void SetStudyDateAndTime(DicomDataSet pDicomDataSet)
      {
         DateTime Time;
         string szValue = null;
         DicomElement pElement;

         Time = DateTime.Now;

         // Set study date
         pElement = pDicomDataSet.FindFirstElement(null, DicomTag.StudyDate, false);
         if (pElement != null)
         {
            szValue = string.Format("%02d/%02d/%04d", Time.Month, Time.Day, Time.Year);
            pDicomDataSet.FreeElementValue(pElement);
            pDicomDataSet.SetConvertValue(pElement, szValue, 1);
         }
         // Set content date
         pElement = pDicomDataSet.FindFirstElement(null, DicomTag.ContentDate, false);
         if (pElement != null)
         {
            pDicomDataSet.FreeElementValue(pElement);
            pDicomDataSet.SetConvertValue(pElement, szValue, 1);
         }
         // Set study time
         pElement = pDicomDataSet.FindFirstElement(null, DicomTag.StudyTime, false);
         if (pElement != null)
         {
            szValue = string.Format("%02d:%02d:%04d.0", Time.Hour, Time.Minute, Time.Second);
            pDicomDataSet.FreeElementValue(pElement);
            pDicomDataSet.SetConvertValue(pElement, szValue, 1);
         }
         // Set content time
         pElement = pDicomDataSet.FindFirstElement(null, DicomTag.ContentTime, false);
         if (pElement != null)
         {
            pDicomDataSet.FreeElementValue(pElement);
            pDicomDataSet.SetConvertValue(pElement, szValue, 1);
         }

      }

      //Get value for a certain element
      void GetElementValue(DicomElement pElement, ref String strValue)
      {
         int nCount = 0;
         string pszValue;
         int i;

         DicomDataSet pDS = m_DS;

         if ((null == pElement) || (pDS.ExistsElement(pElement) == false))
            return;
         if (pElement.Tag == DicomTag.PixelData)
         {
            strValue = "";
            return;
         }

         nCount = pDS.GetElementValueCount(pElement);
         pDS.FreeElementValue(pElement);
         if (nCount == 0)
         {
            return;
         }
         strValue = "";

         if (pDS.GetConvertValue(pElement) == null)
         {
            // Is this a date?
            if (pElement.VR == DicomVRType.DA)
            {
               DicomDateValue[] pDate;
               for (i = 0; i < nCount; i++)
               {
                  pDate = pDS.GetDateValue(pElement, i, 1);
                  if (pDate != null)
                  {
                     strValue = string.Format("{0:D}/{1:D}/{2:D}", pDate[0].Day, pDate[0].Month, pDate[0].Year);
                  }
               }
            }
            return;
         }

         //Get the value of this element
         pszValue = pDS.GetConvertValue(pElement);
         string pTemp1;
         for (i = 0, pTemp1 = pszValue; i < nCount; i++)
         {
            if (nCount > 1)
            {
               if (pszValue.Contains("\\"))
               {
                  pszValue = pszValue.Remove(pszValue.IndexOf('\\'));
               }
            }
         }
         strValue = pszValue;
         strValue = pszValue;
      }

      bool IsCapturing()
      {
         if (CaptureCtrl1!=null)
         {
            return ((CaptureCtrl1.State==CaptureState.Running) ? true : false);
         }   
         return false;
      }

      bool CanInsertCompressedImage()
      {
         DicomElement  pElement =null;

         pElement = m_DS.FindFirstElement(null, 
                                          DicomTag.TransferSyntaxUID,
                                          false);
         if(pElement!=null)
         {
            string   pszText = null;
            pszText = m_DS.GetConvertValue(pElement);
            if (pszText == DicomUidType.ImplicitVRLittleEndian ||
                pszText == DicomUidType.ExplicitVRBigEndian)
            {
               return false;
            }
            else
            {
               return true;
            }                                             
                         
         }
         return true;
      }

      bool ChangeDSToAcceptCompressed()
      {
         string          szPath;
         string szFileName;
         DicomElement  pPixelDataElement= null;

         //If the dataset can already accept compressed images then don't do anything
         if(true == CanInsertCompressedImage())
         {
            return true;   
         }   
         // Get a temp file name
         szPath = Path.GetTempPath();
         szFileName = Path.Combine(szPath, Path.GetTempFileName());

         // Delete the pixel data element
         pPixelDataElement = m_DS.FindFirstElement(null, DicomTag.PixelData, false);            
         if(pPixelDataElement!=null)
         {
            m_DS.DeleteElement(pPixelDataElement);
            pPixelDataElement= null;               
         }
         // Save the dataset into a temp file and pass 
         // proper flags to make it Explicit Little Endian
         m_DS.Save(szFileName, 
            DicomDataSetSaveFlags.ExplicitVR | 
            DicomDataSetSaveFlags.LittleEndian|
            DicomDataSetSaveFlags.MetaHeaderPresent|
            DicomDataSetSaveFlags.GroupLengths);
                              
         // Reset the data set and then load the temp file we saved
         m_DS.Reset();
         m_DS.Load(szFileName,DicomDataSetLoadFlags.LoadAndClose);

         // Clean Up!
         File.Delete(szFileName);
         return true;
      }

      String GetOutputFileName()
      {
         string szFileName = Path.GetTempPath();
         if (szFileName == null || szFileName.Length==0)
         {
            MessageBox.Show("Cannot get <TEMP> folder.");
            return "";
         }

         szFileName += "DicomVidOutput.dcm";

         return szFileName;
      }

      bool SetTargetFormat(DICOM_WRITER_FILTER_TARGET_FORMAT TargetFormat)
      {
         CaptureCtrl1.EnterEdit();
         bool bRet = false;
         
         switch(TargetFormat)
         {
            case DICOM_WRITER_FILTER_TARGET_FORMAT.DICOM_WRITER_FILTER_TARGET_FORMAT_CUSTOM:
               CaptureCtrl1.TargetFormat = TargetFormatType.DICOM;
               // clear any compressor (might have been set when we selected MPEG-2 DICOM)
               SelectMPEG2Compressor(false);
               break;
            case DICOM_WRITER_FILTER_TARGET_FORMAT.DICOM_WRITER_FILTER_TARGET_FORMAT_MPEG2:
               CaptureCtrl1.TargetFormat = TargetFormatType.MPEG2DICOM;
               // select a MPEG-2 compressor
               SelectMPEG2Compressor(true);
               break;
            default:
               bRet = false;
               break;
         }
         CaptureCtrl1.LeaveEdit();
         return bRet;
      }


      void SelectMPEG2Compressor(bool bSelect)
      {
         VideoCompressors videoCompressors = null;
         AudioCompressors audioCompressors = null;
         
         videoCompressors = CaptureCtrl1.VideoCompressors;
         if (videoCompressors==null && bSelect)
         {
            MessageBox.Show("Can't find any Video compressors!");
            return;
         }

         audioCompressors = CaptureCtrl1.AudioCompressors;
         if ((audioCompressors==null) && bSelect)
         {
            MessageBox.Show("Can't find any Audio compressors, You won't be able to capture Audio!");
            audioCompressors = null;
         }
         
         if(!bSelect)
         {
            if (videoCompressors != null)
               videoCompressors.Selection = -1;
            if(audioCompressors!=null)
               audioCompressors.Selection = -1;
         }
         else
         {
            int lIndex;      
            // look for the LEAD MPEG-2 Encoder 
            lIndex = videoCompressors.IndexOf(Helper.LEAD_MPEG2_VIDEO_ENCODER);
            if (lIndex==-1)
            {         
               MessageBox.Show("Cannot find the MPEG-2 encoder. You will not be able to capture MPEG-2 DICOM files!");
            }
            else
            {
               videoCompressors.Selection = lIndex;
               // set the compatibility mode to DICOM
               object pUnk;
               // get a pointer to the MPEG-2 object
               pUnk = CaptureCtrl1.GetSubObject(CaptureObject.VideoCompressor);
               ILMMPG2Encoder pMPEG2Encoder;
               pMPEG2Encoder = pUnk as ILMMPG2Encoder;
               pMPEG2Encoder.DefaultMpegMode = eMPEG2DEFAULTMODE.MPEG2MODE_DICOM;
               pMPEG2Encoder.RateControlMethod=eRATECONTROL.MPEG2_CONSTANT_QUALITY;
               pMPEG2Encoder.QuantizerValue = 8;
            }
            
            lIndex = -1;
            if(audioCompressors!=null)
            {
               lIndex = audioCompressors.IndexOf(Helper.LEAD_MPEG_AUDIO_ENCODER);
               if(lIndex == -1)
               {
                  MessageBox.Show("Cannot find the LEAD MPEG Audio Encoder. You will not be able to capture Audio.");
               }
               else
               {
                  audioCompressors.Selection=lIndex;
               }      
            }
         }
      }

      String GetTemplateFileName(bool bCreate)
      {
         string szFileName = Path.GetTempPath();
         if (szFileName==null)
         {
            MessageBox.Show("Cannot get <TEMP> folder.");
            return "";
         }

         szFileName = Path.Combine(szFileName, "Template.dcm");

         String strTemplateFileName = szFileName;

         if(bCreate)
         {
            DicomDataSet Ds=new DicomDataSet();
            Ds.Initialize(DicomClassType.Unknown, DicomDataSetInitializeFlags.None);
            Ds.Save(strTemplateFileName ,DicomDataSetSaveFlags.None);
         }   

         return strTemplateFileName;
      }

      void StartToolbarPlay()
      {
         if (false == m_bNowPlaying) 
         {
            if (_timer == null)
            {
               _timer = new Timer();
               _timer.Tick += new EventHandler(timer_Tick);
               _timer.Interval = 100;

               _tS_ProgressBar.Minimum = 0;
               _tS_ProgressBar.Maximum = 100;
               _tS_ProgressBar.Step = 10;
            }

            _tS_ProgressBar.Value = 0;
            _timer.Start();
            m_bNowPlaying = true;
	      }

         UpdateMenuStatus();
      }

      void StopToolbarPlay()
      {
         if (m_bNowPlaying)
         {
            _timer.Stop();
            _tS_ProgressBar.Value = 0;
		      m_bNowPlaying = false;
	      }

         UpdateMenuStatus();
      }

      void timer_Tick(object sender, EventArgs e)
      {
         if (_tS_ProgressBar.Value < _tS_ProgressBar.Maximum)
            _tS_ProgressBar.PerformStep();
         else
            _tS_ProgressBar.Value = 0;
      }
      #endregion

      private void _mi_Exit_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
