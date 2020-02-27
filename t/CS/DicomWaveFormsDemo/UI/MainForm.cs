// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing.Color;
using Leadtools.Controls;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private MainMenu mainMenu1;
      private MenuItem menuItemHelp;
      private MenuItem menuItemAbout;
      private MenuItem menuItemOpen;
      private MenuItem menuItemFile;
      private MenuItem menuItemView;
      private MenuItem menuItem8;
      private MenuItem menuItemExit;
      private MenuItem menuItemWaveformInfo;
      private MenuItem menuItemAudio;
      private MenuItem menuItemCreateAudio;
      private MenuItem menuItemPlayAudio;
      private IContainer components;
      private ImageList imageList1;
      private TreeView treeViewElements;
      private SplitContainer splitContainer1;

      private DicomDataSet ds;
      private DicomWaveformGroup m_CurrentWaveformGroup;
      private bool m_bLoadedWaveform;
      private int m_nPageWidth = Screen.PrimaryScreen.Bounds.Width;
      private int m_nPageHeight = Screen.PrimaryScreen.Bounds.Height;
      private int m_nFrameWidth = 100;
      private int m_nNumHorzPoints = 50;
      private int m_nNumVerPoints = 50;
      private int m_nCellWidth;
      private int m_nCellHeight;
      private OpenFileDialog openFileDialog1;
      private int m_nRibbonWidth = 0;
      private string _openInitialPath = string.Empty;

      public MainForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         Utils.EngineStartup();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
         this.menuItemFile = new System.Windows.Forms.MenuItem();
         this.menuItemOpen = new System.Windows.Forms.MenuItem();
         this.menuItem8 = new System.Windows.Forms.MenuItem();
         this.menuItemExit = new System.Windows.Forms.MenuItem();
         this.menuItemView = new System.Windows.Forms.MenuItem();
         this.menuItemWaveformInfo = new System.Windows.Forms.MenuItem();
         this.menuItemAudio = new System.Windows.Forms.MenuItem();
         this.menuItemCreateAudio = new System.Windows.Forms.MenuItem();
         this.menuItemPlayAudio = new System.Windows.Forms.MenuItem();
         this.menuItemHelp = new System.Windows.Forms.MenuItem();
         this.menuItemAbout = new System.Windows.Forms.MenuItem();
         this.treeViewElements = new System.Windows.Forms.TreeView();
         this.imageList1 = new System.Windows.Forms.ImageList(this.components);
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.SuspendLayout();
         // 
         // mainMenu1
         // 
         this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemView,
            this.menuItemAudio,
            this.menuItemHelp});
         // 
         // menuItemFile
         // 
         this.menuItemFile.Index = 0;
         this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOpen,
            this.menuItem8,
            this.menuItemExit});
         this.menuItemFile.Text = "&File";
         // 
         // menuItemOpen
         // 
         this.menuItemOpen.Index = 0;
         this.menuItemOpen.Text = "&Open...";
         this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
         // 
         // menuItem8
         // 
         this.menuItem8.Index = 1;
         this.menuItem8.Text = "-";
         // 
         // menuItemExit
         // 
         this.menuItemExit.Index = 2;
         this.menuItemExit.Text = "&Exit";
         this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
         // 
         // menuItemView
         // 
         this.menuItemView.Index = 1;
         this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemWaveformInfo});
         this.menuItemView.Text = "&View";
         // 
         // menuItemWaveformInfo
         // 
         this.menuItemWaveformInfo.Index = 0;
         this.menuItemWaveformInfo.Text = "&Waveform Info";
         this.menuItemWaveformInfo.Click += new System.EventHandler(this.menuItemWaveformInfo_Click);
         // 
         // menuItemAudio
         // 
         this.menuItemAudio.Index = 2;
         this.menuItemAudio.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCreateAudio,
            this.menuItemPlayAudio});
         this.menuItemAudio.Text = "Audio";
         // 
         // menuItemCreateAudio
         // 
         this.menuItemCreateAudio.Index = 0;
         this.menuItemCreateAudio.Text = "&Create Basic Voice Audio File";
         this.menuItemCreateAudio.Click += new System.EventHandler(this.menuItemCreateAudio_Click);
         // 
         // menuItemPlayAudio
         // 
         this.menuItemPlayAudio.Index = 1;
         this.menuItemPlayAudio.Text = "&Play Basic Voice Audio File";
         this.menuItemPlayAudio.Click += new System.EventHandler(this.menuItemPlayAudio_Click);
         // 
         // menuItemHelp
         // 
         this.menuItemHelp.Index = 3;
         this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAbout});
         this.menuItemHelp.Text = "&Help";
         // 
         // menuItemAbout
         // 
         this.menuItemAbout.Index = 0;
         this.menuItemAbout.Text = "&About";
         this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
         // 
         // treeViewElements
         // 
         this.treeViewElements.Dock = System.Windows.Forms.DockStyle.Fill;
         this.treeViewElements.FullRowSelect = true;
         this.treeViewElements.HideSelection = false;
         this.treeViewElements.ImageIndex = 0;
         this.treeViewElements.ImageList = this.imageList1;
         this.treeViewElements.Location = new System.Drawing.Point(0, 0);
         this.treeViewElements.Name = "treeViewElements";
         this.treeViewElements.SelectedImageIndex = 0;
         this.treeViewElements.Size = new System.Drawing.Size(158, 569);
         this.treeViewElements.TabIndex = 0;
         // 
         // imageList1
         // 
         this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
         this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList1.Images.SetKeyName(0, "");
         this.imageList1.Images.SetKeyName(1, "");
         this.imageList1.Images.SetKeyName(2, "");
         this.imageList1.Images.SetKeyName(3, "");
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.treeViewElements);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
         this.splitContainer1.Size = new System.Drawing.Size(825, 569);
         this.splitContainer1.SplitterDistance = 158;
         this.splitContainer1.TabIndex = 1;
         // 
         // openFileDialog1
         // 
         this.openFileDialog1.Filter = "DICOM Files (*.dic;*.dcm)|*.dic;*.dcm|All files (*.*)|*.*";
         this.openFileDialog1.Multiselect = true;
         this.openFileDialog1.Title = "Open Dicom File";
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(825, 569);
         this.Controls.Add(this.splitContainer1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this.mainMenu1;
         this.Name = "MainForm";
         this.Text = "DICOM Waveforms Demo";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

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

      private void menuItemAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("DICOM Waveforms", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void menuItemExit_Click(object sender, System.EventArgs e)
      {
         Application.Exit();
      }

      private void MainForm_Load(object sender, System.EventArgs e)
      {
         try
         {
            // Initialize the right panel where drawing will take place
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.Panel2.AutoScrollMinSize = new Size(m_nPageWidth, m_nPageHeight);

            // Calculate the cell width and height which we'll use later in the drawing code
            m_nCellWidth = (int)((double)m_nPageWidth / (double)m_nNumHorzPoints);
            m_nCellHeight = (int)((double)m_nPageHeight / (double)m_nNumVerPoints);

            m_bLoadedWaveform = false;
            menuItemWaveformInfo.Enabled = m_bLoadedWaveform;

            ds = new DicomDataSet();
            if (ds == null)
            {
               MessageBox.Show("Can't create dicom object. Quitting app.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               Application.Exit();
               return;
            }

            BringToFront();

            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      void Application_ApplicationExit(object sender, EventArgs e)
      {
         Utils.EngineShutdown();
      }

      private void menuItemOpen_Click(object sender, System.EventArgs e)
      {
         try
         {
            openFileDialog1.InitialDirectory = _openInitialPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               _openInitialPath = Path.GetDirectoryName(openFileDialog1.FileName);
               menuItemClose_Click(null, new EventArgs());
               OpenDataset(openFileDialog1.FileName);
               Invalidate(true);
               menuItemWaveformInfo.Enabled = m_bLoadedWaveform;
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      /*
       * Loads a dataset, checks to make sure it has waveforms, and then builds the tree
       */
      private void OpenDataset(string file)
      {
         Cursor = Cursors.WaitCursor;

         try
         {
            m_bLoadedWaveform = false;

            ds.Load(file, DicomDataSetLoadFlags.LoadAndClose);


            // Do we have any waveform groups at all
            if (ds.WaveformGroupCount == 0)
            {
               MessageBox.Show("The DICOM file you are trying to load doesn't include any waveforms.");
               m_bLoadedWaveform = false;
               return;
            }
            else
            {
               m_bLoadedWaveform = true;
            }

            // There is at least one waveform group in this DS, the first waveform group will be loaded
            if (m_CurrentWaveformGroup != null)
               m_CurrentWaveformGroup.Reset();
            m_CurrentWaveformGroup = ds.GetWaveformGroup(0);

            // Update the Tree View
            UpdateTree();
         }
         catch (Exception exception)
         {
            MessageBox.Show(exception.ToString());
         }
         finally
         {
            Cursor = Cursors.Arrow;
         }

         if (treeViewElements.Nodes.Count > 0)
         {
            treeViewElements.SelectedNode = treeViewElements.Nodes[0];
         }
      }

      /*
       * Finds the first module and then continues to fill the tree
       */
      private void FillTreeModules()
      {
         try
         {
            for (int x = 0; x < ds.ModuleCount; x++)
            {
               TreeNode node;
               DicomModule module;
               DicomIod iod;

               module = ds.FindModuleByIndex(x);
               iod = DicomIodTable.Instance.FindModule(ds.InformationClass, module.Type);

               node = treeViewElements.Nodes.Add(iod.Name);
               node.Tag = module;
               foreach (DicomElement element in module.Elements)
               {
                  FillModuleSubTree(element, node, false);
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      /*
       * Recursively fills the tree with elements and modules
       */
      void FillModuleSubTree(DicomElement element, TreeNode ParentNode, bool recurse)
      {
         try
         {
            TreeNode node;
            string name, value;
            string temp = "";
            DicomElement tempElement;

            DicomTag tag;

            // Build the string representing the tree node
            // Get the tag

            {
               tag = DicomTagTable.Instance.Find(element.Tag);
               temp = string.Format("{0:x4}:{1:x4} - ", Utils.GetGroup((long)element.Tag), Utils.GetElement((long)element.Tag));
            }

            // Get the tag name
            if (tag == null)
               name = "Item";
            else
               name = tag.Name;

            // Get the tag value
            value = "";
            value = ds.GetConvertValue(element);

            temp = temp + name + " : " + value;

            if (ParentNode != null)
               node = ParentNode.Nodes.Add(temp);
            else
               node = treeViewElements.Nodes.Add(temp);

            node.Tag = element;

            if (ds.IsVolatileElement(element))
               node.ForeColor = Color.Red;

            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;

            // Recursively fille the tree if there are children
            tempElement = ds.GetChildElement(element, true);
            if (tempElement != null)
            {
               node.ImageIndex = 0;
               node.SelectedImageIndex = 0;
               FillModuleSubTree(tempElement, node, true);
            }

            // Recursively fill the tree for the next element
            if (recurse)
            {
               tempElement = ds.GetNextElement(element, true, true);

               if (tempElement != null)
                  FillModuleSubTree(tempElement, ParentNode, true);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      private void menuItemClose_Click(object sender, System.EventArgs e)
      {
         try
         {
            treeViewElements.BeginUpdate();
            treeViewElements.Nodes.Clear();
            treeViewElements.EndUpdate();

            ds.Reset();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      /*
       * Clears the tree and starts the recursive building process
       */
      private void UpdateTree()
      {
         try
         {
            treeViewElements.BeginUpdate();
            treeViewElements.Nodes.Clear();

            FillTreeModules();
            treeViewElements.EndUpdate();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      /*
       * Paints the graph and the waveforms (if they exist) on the right panel
       */
      private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
      {
         try
         {
            // update the transform in case the panel has been scrolled
            e.Graphics.TranslateTransform(splitContainer1.Panel2.AutoScrollPosition.X,
                                     splitContainer1.Panel2.AutoScrollPosition.Y);

            // Draw grid
            e.Graphics.FillRectangle(Brushes.Black, Screen.PrimaryScreen.Bounds);

            // Horizontal lines
            int y;
            for (int i = 0; i < m_nNumHorzPoints; i++)
            {
               y = (i * m_nCellHeight) + m_nCellHeight;
               e.Graphics.DrawLine(new Pen(Color.FromArgb(50, 50, 50)), new Point(0, y), new Point(m_nPageWidth, y));
            }

            // Vertical Lines
            int x;
            for (int i = 0; i < m_nNumVerPoints; i++)
            {
               x = (i * m_nCellWidth) + m_nRibbonWidth;
               e.Graphics.DrawLine(new Pen(Color.FromArgb(50, 50, 50)), new Point(x, 0), new Point(x, m_nPageHeight));
            }

            // Draw the waveform if one is loaded
            if (m_bLoadedWaveform)
               DrawWaveform(e.Graphics);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      /*
       * Draws the waveform(s) on the Graphics object
       */
      private void DrawWaveform(Graphics g)
      {
         if (m_CurrentWaveformGroup == null)
            return;
         try
         {
            // Get number of channels
            int nChannelsCount = m_CurrentWaveformGroup.ChannelCount;
            if (nChannelsCount == 0)
            {
               return;
            }

            // How many samples do we have in a channel
            int nSamplesPerChannel = m_CurrentWaveformGroup.GetNumberOfSamplesPerChannel();
            if (nSamplesPerChannel == 0)
            {
               return;
            }

            int[] nAllData;
            int nSampleIndex, nChannelIndex;
            int iMaxVal, iMinVal;
            double dExtent = 0;
            double dVertStep = 0;
            RectangleF DrawTextRect;

            int nViewRectHeight = m_nPageHeight - m_nFrameWidth;
            int nViewRectWidth = m_nPageWidth;

            DicomCodeSequenceItem ChannelSource;

            iMaxVal = -32768;
            iMinVal = 32767;

            // Find the minimum and maximum value for all the channels
            for (nChannelIndex = 0; nChannelIndex < nChannelsCount; nChannelIndex++)
            {
               nAllData = m_CurrentWaveformGroup.GetChannel(nChannelIndex).GetChannelSamples();

               for (nSampleIndex = 0; nSampleIndex < nSamplesPerChannel; nSampleIndex++)
               {
                  if (nAllData[nSampleIndex] > iMaxVal)
                  {
                     iMaxVal = nAllData[nSampleIndex];
                  }
                  else if (nAllData[nSampleIndex] < iMinVal)
                  {
                     iMinVal = nAllData[nSampleIndex];
                  }
               }

               dVertStep = nViewRectHeight / nChannelsCount;
               dExtent = ((iMaxVal - iMinVal) * 1.2) / dVertStep;
            }

            int nIndex = 0;
            string strText;
            DicomWaveformAnnotation ann;
            long lStartPoint;

            // Loop through the channels one by one
            for (nChannelIndex = 0; nChannelIndex < nChannelsCount; nChannelIndex++)
            {
               strText = "";
               nIndex = nChannelsCount - nChannelIndex - 1;

               //Get the data for this channel
               nAllData = m_CurrentWaveformGroup.GetChannel(nIndex).GetChannelSamples();
               lStartPoint = ((nViewRectHeight + (int)((double)((nChannelIndex) * -1 * (int)dVertStep) - (nAllData[0] - iMinVal) / dExtent))) + m_nFrameWidth / 2;


               // Get the channel source
               ChannelSource = m_CurrentWaveformGroup.GetChannel(nIndex).GetChannelSource();

               DrawTextRect = new RectangleF(5, lStartPoint, m_nFrameWidth - 5, (float)dVertStep);

               if ((ChannelSource != null) && (ChannelSource.CodeMeaning != null))
               {
                  // Display the channel source
                  strText = ChannelSource.CodeMeaning;
                  if (m_CurrentWaveformGroup.GetChannel(nIndex).GetAnnotationCount() > 0)
                  {
                     // Display the channel annotation
                     ann = m_CurrentWaveformGroup.GetChannel(nIndex).GetAnnotation(0);
                     if (ann != null)
                     {
                        if ((ann.UnformattedTextValue != null) && (ann.UnformattedTextValue != ""))
                        {
                           strText += " (";
                           strText += ann.UnformattedTextValue;
                           strText += ")";
                        }
                        else
                        {
                           if ((ann.CodedName != null) && ((ann.CodedName.CodeMeaning != null) && ann.CodedName.CodeMeaning != ""))
                           {
                              strText += " (";
                              strText += ann.CodedName.CodeMeaning;
                              strText += ")";
                           }
                        }
                     }
                  }

                  g.DrawString(strText, new Font(FontFamily.GenericSansSerif, 10), Brushes.Red, DrawTextRect);
               }

               int nDiff;
               double dRatio;
               int nOffset;

               // Draw the points/lines for this channel
               Point ptPreviousPoint, ptCurrentPoint;
               ptPreviousPoint = new Point(m_nFrameWidth, (int)lStartPoint);
               for (nSampleIndex = 1; nSampleIndex < nSamplesPerChannel; nSampleIndex++)
               {
                  nDiff = nAllData[nSampleIndex] - iMinVal;
                  dRatio = (double)nDiff / dExtent;
                  nOffset = m_nFrameWidth / 2;

                  ptCurrentPoint = new Point(
                      (nSampleIndex * nViewRectWidth / nSamplesPerChannel) + m_nFrameWidth,
                      ((nViewRectHeight + (int)(((double)(nChannelIndex) * -1 * dVertStep) - dRatio))) + nOffset);

                  g.DrawLine(new Pen(Color.FromArgb(0, 255, 0)), ptPreviousPoint, ptCurrentPoint);

                  ptPreviousPoint = ptCurrentPoint;
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      /*
       * Displays a dialog which reports the information about the 
       *   waveform group and different channels
       */
      private void menuItemWaveformInfo_Click(object sender, EventArgs e)
      {
         WaveformAttributesDialog AttributesDlg = new WaveformAttributesDialog(ref m_CurrentWaveformGroup);
         AttributesDlg.ShowDialog(this);
      }

      /*
       * Displays a dialog for creating a Basic Voice Audio dicom file
       */
      private void menuItemCreateAudio_Click(object sender, EventArgs e)
      {
         BasicVoiceDialog BasicVoiceDlg = new BasicVoiceDialog();
         BasicVoiceDlg.ShowDialog(this);
      }

      /*
       * Displays a dialog for playing a basic voice audio Dicom file.
       */
      private void menuItemPlayAudio_Click(object sender, EventArgs e)
      {
         PlayBasicVoiceDialog PlayDlg = new PlayBasicVoiceDialog();
         PlayDlg.ShowDialog(this);
      }
   }
}
