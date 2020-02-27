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
using Leadtools.Demos;
using Leadtools.Dicom;
using CSDicomDirLinqDemo.Utils;
using System.IO;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using System.Reflection;
using System.Collections;
using System.Text.RegularExpressions;
using Leadtools.MedicalViewer;
using Leadtools;
using CSDicomDirLinqDemo.Properties;
using Leadtools.Dicom.Common.Editing.Controls;
using System.Net;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace CSDicomDirLinqDemo.UI
{
   public partial class MainForm : Form
   {
      private DicomDataSet _Dataset = new DicomDataSet();
      private DicomDataSet _DataView = null;
      private MedicalViewer _MedicalViewer;
      private string _Directory = string.Empty;
      private string _DemoName = Path.GetFileName(Application.ExecutablePath);
      private HttpServer _HttpServer = new HttpServer();
      public static string Port = "33333";
      private string _openInitialPath = string.Empty;

      public MedicalViewerCell Cell
      {
         get
         {
            return _MedicalViewer.Cells[0] as MedicalViewerCell;
         }
      }

      private List<LinqQuery> _Queries;

      public List<LinqQuery> Queries
      {
         get { return _Queries; }
         set { _Queries = value; }
      }

      private static bool _ViewThumbnails = true;

      public static bool ViewThumbnails
      {
         get { return MainForm._ViewThumbnails; }
         set { MainForm._ViewThumbnails = value; }
      }

      public MainForm()
      {
         InitializeComponent();
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         Messager.Caption = "LINQ Basic Directory";
         Text = "C# " + Messager.Caption + " Demo";

         try
         {
            _Queries = SettingsManager.Load<List<LinqQuery>>(_DemoName);
            if (_Queries == null)
            {
               LoadDefaultQueries();
            }
            LoadQueries();
            _HttpServer.Start("http://localhost:" + Port + "/");
            toolStripButtonThumbnails.Checked = _ViewThumbnails;
         }
         catch (HttpListenerException he)
         {
            toolStripButtonThumbnails.Enabled = false;
            Messager.ShowInformation(this, "Can't start the internal http server [" + he.Message + "].  This could be a problem " +
                                     "with the port.  Thumbnail images will not be available.");
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            Close();
            return;
         }
         webBrowserResults.Navigate("about:blank");
         richTextBoxLinqInfo.Rtf = Resources.LinqInfo;
         InitializeMedicalViewer();
         Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
         Application.Idle += new EventHandler(Application_Idle);
      }

      private void Application_ApplicationExit(object sender, EventArgs e)
      {
         try
         {
            if (_HttpServer != null)
               _HttpServer.Stop();
            SettingsManager.Save<List<LinqQuery>>(_DemoName, _Queries);
         }
         catch
         {
         }
      }

      private void InitializeMedicalViewer()
      {
         MedicalViewerCell cell = new MedicalViewerCell();

         cell.AddAction(MedicalViewerActionType.Stack);
         cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active);

         _MedicalViewer = new MedicalViewer(1, 1);
         _MedicalViewer.Dock = DockStyle.Fill;
         _MedicalViewer.SplitterStyle = MedicalViewerSplitterStyle.None;
         _MedicalViewer.Cells.Add(cell);
         tabPageViewer.Controls.Add(_MedicalViewer);
      }

      void Application_Idle(object sender, EventArgs e)
      {
         richTextBoxScript.Enabled = _Dataset.InformationClass == DicomClassType.BasicDirectory;
         toolStripButtonExecute.Enabled = richTextBoxScript.Text.Length > 0 && _Dataset.InformationClass == DicomClassType.BasicDirectory;
      }

      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         openFileDialog.InitialDirectory = _openInitialPath;
         if (openFileDialog.ShowDialog(this) == DialogResult.OK)
         {
            _openInitialPath = Path.GetDirectoryName(openFileDialog.FileName);
            using (WaitCursor wc = new WaitCursor())
            {
               LoadDirectory(openFileDialog.FileName);
            }
         }
      }

      private void LoadDirectory(string filename)
      {
         try
         {
            webBrowserResults.Document.OpenNew(true);
            if (Cell.Image != null)
               Cell.Image = null;
            _Dataset.Load(filename, DicomDataSetLoadFlags.None);
            if (_Dataset.InformationClass != DicomClassType.BasicDirectory)
            {
               Messager.ShowError(this, string.Format("{0} is not a DICOMDIR", filename));
            }
            else
            {
               try
               {
                  treeViewDicomDir.BeginUpdate();
                  treeViewDicomDir.Nodes.Clear();
                  treeViewDicomDir.LoadDirectory(_Dataset);
                  _Directory = new FileInfo(filename).DirectoryName + @"\";
               }
               finally
               {
                  treeViewDicomDir.EndUpdate();
               }
            }
         }
         catch (Exception e)
         {
            Messager.ShowError(this, e);
         }
      }

      private void LoadDefaultQueries()
      {
         Queries = new List<LinqQuery>();

         Queries.Add(new LinqQuery() { Name = "Patient Query", Description = "Query All Patients", Query = Resources.PatientQuery });
         Queries.Add(new LinqQuery() { Name = "Study Query", Description = "Query All Studies", Query = Resources.StudyQuery });
         Queries.Add(new LinqQuery() { Name = "Image Query", Description = "Query All Images", Query = Resources.ImageQuery });
      }

      private void LoadQueries()
      {
         foreach (LinqQuery query in Queries)
         {
            LinkLabel label = new LinkLabel() { AutoSize = true, Margin = new Padding() { Left = 5, Bottom = 10 } };

            label.Text = query.Name;
            label.Tag = query;
            label.LinkClicked += new LinkLabelLinkClickedEventHandler(SelectQuery);
            toolTip.SetToolTip(label, query.Query);
            queryPanel.Controls.Add(label);
         }
      }

      void SelectQuery(object sender, LinkLabelLinkClickedEventArgs e)
      {
         LinqQuery query = (sender as LinkLabel).Tag as LinqQuery;

         tabControl.SelectedTab = tabPageQuery;
         richTextBoxScript.Text = query.Query;
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void treeViewDicomDir_AfterSelect(object sender, TreeViewEventArgs e)
      {
         DicomElement element;
         string value;

         txtElementValue.Text = "";

         if (treeViewDicomDir.SelectedNode.Tag == null)
            return;

         element = (DicomElement)treeViewDicomDir.SelectedNode.Tag;

         try
         {
            if (element.Tag == DicomTag.PixelData)
            {
               return;
            }

            value = _Dataset.GetConvertValue(element);
            if (value != null && value.Length > 0)
            {
               value = value.Replace(@"\", "\r\n");
            }
            txtElementValue.Text = value;
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, "Error getting element value:\r\n\r\n" + ex.ToString());
         }
      }

      private void toolStripButtonExecute_Click(object sender, EventArgs e)
      {
         try
         {
            string html = string.Empty;
            bool hasErrors = false;
            int count;

            webBrowserResults.Document.OpenNew(true);
            if (Cell.Image != null)
               Cell.Image = null;
            ShowProgress(true);
            tabPageResults.Text = "Results";
            using (WaitCursor wc = new WaitCursor())
            {
               html = LinqCompiler.Execute(_Dataset, richTextBoxScript.Text, _Directory, out hasErrors, out count);
            }

            if (!hasErrors)
            {
               if (count > 0)
               {
                  webBrowserResults.Document.Write(html);
                  tabControl.SelectedTab = tabPageResults;
                  tabPageResults.Text = "Results [" + count.ToString() + "]";
               }
               else
                  Messager.ShowInformation(this, "No Results Found");
            }
            else if (tabControl.SelectedTab != tabPageQuery)
            {
               tabControl.SelectedTab = tabPageQuery;
            }
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception);
         }
         finally
         {
            ShowProgress(false);
         }
      }

      private void ShowProgress(bool show)
      {
         toolStripProgressBar.Visible = show;
         toolStripProgressBar.MarqueeAnimationSpeed = show ? 100 : 0;
      }

      private void webBrowserResults_Navigating(object sender, WebBrowserNavigatingEventArgs e)
      {
         string[] data = e.Url.LocalPath.Split('=');

         if (data.Length > 0 && data[0] != "referencedfileid")
         {
            long tag = GetTag(data[0]);

            if (tag != -1)
            {
               FindNode(treeViewDicomDir.Nodes, tag, data[1]);
               e.Cancel = true;
            }
         }
         else
         {
            string filename = data[1];

            if (!data[1].Contains(@":\"))
               filename = _Directory + filename;

            LoadDataset(filename);
            e.Cancel = true;
         }
      }

      private long GetTag(string name)
      {
         switch (name)
         {
            case "patientid":
               return DicomTag.PatientID;
            case "studyinstanceuid":
               return DicomTag.StudyInstanceUID;
            case "seriesinstanceuid":
               return DicomTag.SeriesInstanceUID;
            case "sopinstanceuid":
               return DicomTag.SOPInstanceUID;
            case "referencedsopinstanceuidinfile":
               return DicomTag.ReferencedSOPInstanceUIDInFile;
         }
         return -1;
      }

      private void FindNode(TreeNodeCollection nodes, long tag, string value)
      {
         foreach (TreeNode node in nodes)
         {
            DicomElement element = node.Tag as DicomElement;

            if (element != null && element.Tag == tag)
            {
               if (_Dataset.GetConvertValue(element) == value)
               {
                  node.Expand();
                  treeViewDicomDir.SelectedNode = node;
                  treeViewDicomDir.Select();
                  return;
               }
            }

            FindNode(node.Nodes, tag, value);
         }
      }

      private void LoadDataset(string filename)
      {
         if (_DataView != null)
         {
            _DataView.Dispose();
         }

         _DataView = new DicomDataSet();
         try
         {
            RasterImage image = null;
            int count = 0;

            _DataView.Load(filename, DicomDataSetLoadFlags.None);
            count = _DataView.GetImageCount(null);
            image = _DataView.GetImages(null, 0, count, 0, RasterByteOrder.Rgb | RasterByteOrder.Gray,
                                       DicomGetImageFlags.AutoApplyVoiLut | DicomGetImageFlags.AutoApplyModalityLut);
            if (image != null)
            {
               Cell.Image = image;
               Cell.FitImageToCell = true;
               if (image.GrayscaleMode != RasterGrayscaleMode.None)
               {
                  Cell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData);
                  Cell.SetTag(0, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.Frame);
               }
            }
            tabControl.SelectedTab = tabPageViewer;
         }
         catch (Exception e)
         {
            Messager.ShowError(this, e);
         }
      }

      private void toolStripButtonThumbnails_CheckedChanged(object sender, EventArgs e)
      {
         _ViewThumbnails = toolStripButtonThumbnails.Checked;
      }

      private void treeViewDicomDir_DragEnter(object sender, DragEventArgs e)
      {
         if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
         {
            e.Effect = DragDropEffects.Copy;
         }
      }

      private void treeViewDicomDir_DragDrop(object sender, DragEventArgs e)
      {
         string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

         if (files.Length >= 1)
         {
            LoadDirectory(files[0]);
         }
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog(Messager.Caption, ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog(Messager.Caption))
            aboutDialog.ShowDialog(this);
#endif
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (!RasterSupport.KernelExpired)
         {
            webBrowserResults.Navigate("about:blank");
            _HttpServer.Stop();
         }
      }

      private void DownloadSampleDicomDir()
      {
         System.Diagnostics.Process.Start("ftp://ftp.leadtools.com/pub/3d/Head MRI Study with scout/Head MRI Study with scout.zip");
      }

      private void linkLabelDownloadDicomDir_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
      {
         DownloadSampleDicomDir();
      }

      private void downloadSampleDICOMDIRToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DownloadSampleDicomDir();
      }
   }
}
