// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;
using DicomAnonymizer.UI.Controls;
using DicomAnonymizer.Common;
using DicomAnonymizer.Properties;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;
using Leadtools.Dicom.Common.Anonymization;
using System.Collections.ObjectModel;
using Leadtools.Dicom.Common.Editing.Controls;
using Leadtools.Dicom.Common.Editing;
using Leadtools.Dicom.Common.Compare;
using System.Diagnostics;
using DicomAnonymizer.UI;
using Leadtools.Dicom.Common.Diff;

namespace DicomAnonymizer
{
   public partial class MainForm : Form
   {
      private Dictionary<long, int> _TagItems;
      private Anonymizer _Anonymizer;
      private string _FileName = string.Empty;
      private bool _Modified;
      private string _OldValue;
      private DicomDataSet _ActiveDataSet;

      private const int TAG_COLUMN = 0;
      private const int DESCRIPTION_COLUMN = 1;
      private const int TAGS_VALUE_COLUMN = 2;

      public MainForm()
      {
         try
         {
            InitializeComponent();
         }
         catch (Exception ex)
         { 
            MessageBox.Show(ex.Message, "Exception initializing visual components", MessageBoxButtons.OK);
         }
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         if (DesignMode)
            return;

         try
         {
            _TagItems = new Dictionary<long, int>();
            Messager.Caption = "C# DICOM Anonymizer Demo";
            Text = Messager.Caption + " - Untitled";
            _Anonymizer = new Anonymizer(true);
            _Anonymizer.ApplicationDescription = Messager.Caption;
            _Anonymizer.Progress += new EventHandler<ProgressEventArgs>(_Anonymizer_Progress);
            RegisterEvents();
            SizeColumns();
            InitializeMacroCombo();
            LoadMacros(_Anonymizer.TagMacros);
            _Modified = false;
            new RowNumberDataGridViewDecorator(treeGridViewTags);
            new SelectionDecorator(treeGridViewDifference);
            //new DifferenceDecorator(treeGridViewDifference);
            toolStripProgressBar.Size = new Size(Width / 4, toolStripProgressBar.Size.Height);
         }
         catch { }
         Application.Idle += new EventHandler(Application_Idle);
         _ActiveDataSet = new DicomDataSet();
         LoadDefault();
      }

      void _Anonymizer_Progress(object sender, ProgressEventArgs e)
      {
         toolStripProgressBar.Value = e.Progress;
         Application.DoEvents();
      }

      void Application_Idle(object sender, EventArgs e)
      {
         toolStripButtonSave.Enabled = _Modified;
         toolStripButtonAnonymize.Enabled = treeGridViewTags.Nodes.Count > 0;
         toolStripButtonSaveDataset.Enabled = treeGridViewDifference.Nodes.Count > 0;
         if (toolStripButtonSaveDataset.Enabled)
         {
            AnonymizedInfo info = treeGridViewDifference.Tag as AnonymizedInfo;

            toolStripButtonView.Enabled = info != null && info.ImageCount > 0;
         }
         else
            toolStripButtonView.Enabled = false;
         toolStripButtonDeleteTag.Enabled = treeGridViewTags.SelectedCells.Count > 0;
         toolStripButtonRefresh.Enabled = treeGridViewDifference.Tag != null;
      }

      private void UpdateTitle()
      {
         Text = Messager.Caption + " - " + (_FileName.Length == 0 ? "Untitled" : _FileName);
      }

      private void SizeColumns()
      {
         int width = (treeGridViewTags.CreateGraphics().MeasureDisplayStringWidth("(9999,9999)", treeGridViewTags.Font) + Resources.Tag_16x16.Width) * 2;

         treeGridViewTags.Columns[TAG_COLUMN].Width = width;
         treeGridViewTags.Columns[DESCRIPTION_COLUMN].Width = 250;
      }

      private void RegisterEvents()
      {
         treeGridViewTags.CellBeginEdit += new DataGridViewCellCancelEventHandler(treeGridViewTags_CellBeginEdit);
         treeGridViewTags.CellFormatting += treeGridViewTags_CellFormatting;
         treeGridViewTags.CellEndEdit += treeGridViewTags_CellEndEdit;
         treeGridViewTags.EditingControlShowing += treeGridViewTags_EditingControlShowing;
         treeGridViewTags.CellValidating += treeGridViewTags_CellValidating;
         treeGridViewTags.DataError += new DataGridViewDataErrorEventHandler(treeGridViewTags_DataError);

         treeGridViewDifference.CellClick += treeGridViewDifference_CellClick;
         treeGridViewDifference.RowStateChanged += treeGridViewDifference_RowStateChanged;
      }

      void treeGridViewTags_DataError(object sender, DataGridViewDataErrorEventArgs e)
      {        
      }

      void treeGridViewTags_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
      {
         if (e.ColumnIndex == TAGS_VALUE_COLUMN)
         {
            object efv = e.FormattedValue;
            DataGridViewComboBoxCell cell = treeGridViewTags.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)treeGridViewTags.Columns[TAGS_VALUE_COLUMN];

            if (!column.Items.Contains(efv))
               column.Items.Add(efv);
            cell.Value = efv;
         }
      }

      void treeGridViewDifference_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
      {
         if (e.Row.Selected == true)
         {
            Difference diff = e.Row.Tag as Difference;

            if (diff != null)
            {
               TreeGridNode node = (from n in treeGridViewTags.Nodes.OfType<DicomTagNode>()
                                    where n.DicomTag.Code == diff.Tag
                                    select n).FirstOrDefault();

               if (node != null && node.IsSited)
               {
                  TreeGridNode selectedNode = (from n in treeGridViewTags.Nodes
                                               where n.Selected == true
                                               select n).FirstOrDefault();

                  if (selectedNode != null)
                     selectedNode.Selected = false;

                  node.Selected = true;
                  treeGridViewTags.FirstDisplayedScrollingRowIndex = node.RowIndex;
               }
            }
         }
      }

      void treeGridViewDifference_CellClick(object sender, DataGridViewCellEventArgs e)
      {
         if (e.ColumnIndex == 5 && e.RowIndex!=-1)
         {
            DataGridViewDisableButtonCell cell = treeGridViewDifference.Rows[e.RowIndex].Cells[5] as DataGridViewDisableButtonCell;

            if (cell.Enabled)
            {
               ToolStripDropDown popup = new ToolStripDropDown();
               Difference diff = treeGridViewDifference.Rows[e.RowIndex].Tag as Difference;
               Point location = new Point(treeGridViewDifference.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Left, treeGridViewDifference.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Bottom);

               popup.Margin = Padding.Empty;
               popup.Padding = Padding.Empty;
               ToolStripControlHost host = new ToolStripControlHost(new WebBrowser() { DocumentText = diff.HtmlDiff, Width = cell.ContentBounds.Width * 2 });
               host.Margin = Padding.Empty;
               host.Padding = Padding.Empty;
               host.AutoSize = false;
               host.Size = host.Control.Size;
               popup.Size = host.Size;
               popup.DropShadowEnabled = true;
               popup.Items.Add(host);
               popup.Show(treeGridViewDifference.PointToScreen(location));
            }
         }
      }

      void treeGridViewTags_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
      {
         if (e.ColumnIndex == TAGS_VALUE_COLUMN)
         {
            e.CellStyle.ForeColor = Color.Blue;
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
         }
      }

      void treeGridViewTags_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
      {
         if (e.RowIndex <= treeGridViewTags.Rows.Count)
         {
            TagMacro macro = treeGridViewTags.Nodes[e.RowIndex].Tag as TagMacro;

            e.Cancel = e.ColumnIndex != TAGS_VALUE_COLUMN;
         }
      }

      void treeGridViewTags_CellEndEdit(object sender, DataGridViewCellEventArgs e)
      {
         TagMacro macro = treeGridViewTags.Nodes[e.RowIndex].Tag as TagMacro;
         DataGridViewComboBoxCell cell = treeGridViewTags.Nodes[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;

         macro.Macro = cell.Value != null ? cell.Value.ToString() : string.Empty;
         if (_OldValue.ToString() != macro.Macro)
         {
            _Modified = true;
         }
      }

      void treeGridViewTags_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
      {
         DataGridViewComboBoxEditingControl column = e.Control as DataGridViewComboBoxEditingControl;

         column.DropDownStyle = ComboBoxStyle.DropDown;
         _OldValue = column.Text;
      }

      private DicomTagNode AddAnonymizationTag(long tag, string name, string macro)
      {
         DicomTagNode node = null;
         DicomTag dicomTag = DicomTagTable.Instance.Find(tag);

         node = new DicomTagNode();
         treeGridViewTags.Nodes.Add(node);
         node.SetValues(string.Format("({0:X4},{1:X4})", tag.GetGroup(), tag.GetElement()), name, macro);
         node.DicomTag = dicomTag;
         node.Image = Resources.Tag_16x16;

         if (dicomTag != null && dicomTag.VR == DicomVRType.SQ)
            node.Image = Resources.Tags_16x16;
         _Anonymizer[tag] = macro;
         node.Tag = _Anonymizer.FindTag(tag);
         return node;
      }

      private void InitializeMacroCombo()
      {
         DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)treeGridViewTags.Columns[TAGS_VALUE_COLUMN];

         column.Items.Clear();
         column.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
         foreach (string key in _Anonymizer.MacroProcessor.Macros.Keys)
         {
            column.Items.Add(string.Format("${{{0}}}", key));
         }
      }

      private void LoadMacros(ObservableCollection<TagMacro> macros)
      {
         treeGridViewTags.Nodes.Clear();
         foreach (TagMacro macro in macros)
         {
            DicomTag dicomTag = DicomTagTable.Instance.Find(macro.Tag);
            string name = dicomTag != null ? dicomTag.Name : string.Empty;
            DicomTagNode node = new DicomTagNode();

            treeGridViewTags.Nodes.Add(node);
            node.SetValues(string.Format("({0:X4},{1:X4})", macro.Tag.GetGroup(), macro.Tag.GetElement()), name, macro.Macro);
            node.DicomTag = dicomTag;
            node.Tag = macro;
            AddToList(macro.Macro);

            if (dicomTag != null)
            {
               if (dicomTag.VR == DicomVRType.SQ)
                  node.Image = Resources.Tags_16x16;
               else
                  node.Image = Resources.Tag_16x16;
            }
         }
      }

      private void AddToList(string macro)
      {
         DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)treeGridViewTags.Columns[TAGS_VALUE_COLUMN];

         if (!column.Items.Contains(macro))
         {
            column.Items.Add(macro);
         }
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("DICOM Anonymizer", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void ToggleProgress(bool enable)
      {
         toolStripStatusLabel.Visible = enable;
         toolStripProgressBar.Visible = enable;
      }

      private void anonymizefileToolStripMenuItem_Click(object sender, EventArgs e)
      {
         anonymizeopenFileDialog.Multiselect = false;
         anonymizeopenFileDialog.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*";
         if (anonymizeopenFileDialog.ShowDialog(this) == DialogResult.OK)
         {
            DicomDataSet dsAnonymized = new DicomDataSet();

            _ActiveDataSet.Reset();
            try
            {               
               _ActiveDataSet.Load(anonymizeopenFileDialog.FileName, DicomDataSetLoadFlags.None);
               dsAnonymized = Anonymize();

               AnonymizedInfo info = new AnonymizedInfo() { AnonymizedDataset = dsAnonymized };

               //
               // Store the image count as a tag of the first node.  This is so we don't have to query the dataset during the Idle event.
               //
               if (treeGridViewTags.Nodes.Count > 0)
               {
                  DicomElement element = dsAnonymized.FindFirstElement(null, DicomTag.PixelData, true);

                  if (element != null)
                     info.ImageCount = dsAnonymized.GetImageCount(element);
               }
               treeGridViewDifference.Tag = info;
            }
            catch (Exception exception)
            {
               Messager.ShowError(this, exception);
            }
            finally
            {
               ToggleProgress(false);
            }
         }
      }

      class AnonymizedInfo
      {
         public DicomDataSet AnonymizedDataset { get; set; }
         public int ImageCount { get; set; }
      }

      public void ShowDifference(DicomDataSet original, DicomDataSet anonymized)
      {
         List<Difference> difference;

         treeGridViewDifference.Nodes.Clear();
         difference = original.Compare(anonymized);
         foreach (Difference diff in difference)
         {
            TreeGridNode node = null;

            if (diff.Parent == null)
            {
               node = treeGridViewDifference.Nodes.Add(string.Format("({0:X4},{1:X4})", diff.Tag.GetGroup(), diff.Tag.GetElement()), diff.Name, diff.VR);
               node.Tag = diff;
               SetValue(node, diff);
            }
            else
            {
               TreeGridNode tagNode = FindParentNode(treeGridViewDifference.Nodes, n => (n.Tag as Difference).Path == diff.Parent.Path);

               node = tagNode.Nodes.Add(string.Format("({0:X4},{1:X4})", diff.Tag.GetGroup(), diff.Tag.GetElement()), diff.Name, diff.VR);
               node.Tag = diff;
               SetValue(node, diff);
            }

            if (_Anonymizer.FindTag(diff.Tag) != null)
               node.Image = Resources.ShowTag_16x16p;
         }
      }

      private void SetValue(TreeGridNode node, Difference diff)
      {
         if (diff.VR != DicomVRType.SQ)
         {
            node.Cells[3].Value = diff.FirstValue;
            node.Cells[4].Value = diff.SecondValue;
         }

         //
         // If the tag is located in both files we need to find the difference
         //
         if (diff.Location == TagLocation.Both && diff.IsChanged())
         {
            if (diff.VR != DicomVRType.SQ)
            {
               DataGridViewDisableButtonCell cell = node.Cells[5] as DataGridViewDisableButtonCell;

               cell.Value = "Show Diff";
            }
         }
         else
         {
            DataGridViewDisableButtonCell cell = node.Cells[5] as DataGridViewDisableButtonCell;

            cell.Value = string.Empty;
            if (diff.Location == TagLocation.First)
            {
               cell.Style.ForeColor = Color.Red;
               cell.Value = "Deleted";
            }
            cell.Enabled = false;
         }
      }

      private TreeGridNode FindParentNode(TreeGridNodeCollection nodes, Predicate<TreeGridNode> predicate)
      {
         foreach (TreeGridNode node in nodes)
         {
            if (predicate(node))
            {
               return node;
            }
            else
            {
               TreeGridNode nodeChild = FindParentNode(node.Nodes, predicate);

               if (nodeChild != null)
                  return nodeChild;
            }
         }
         return null;
      }


      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private List<long> GetTags()
      {
         List<long> tags = new List<long>();

         foreach (DicomTagNode node in treeGridViewTags.Nodes)
         {
            tags.Add(node.DicomTag.Code);
         }
         return tags;
      }

      private void insertToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (InsertElementDlg dlgInsert = new InsertElementDlg(GetTags()))
         {
            if (dlgInsert.ShowDialog(this) == DialogResult.OK)
            {
               DicomTagNode node = null;

               foreach (long tag in dlgInsert.Tags)
               {
                  DicomTag dicomTag = DicomTagTable.Instance.Find(tag);
                  DicomTagNode tagNode = null;

                  tagNode = AddAnonymizationTag(tag, dicomTag != null ? dicomTag.Name : string.Empty, GetDefaultMacro(dicomTag));
                  if (node == null)
                     node = tagNode;
               }
               _Modified = dlgInsert.Tags.Count > 0;
               if (node != null)
               {
                  treeGridViewTags.ClearSelection();
                  treeGridViewTags.SelectRow(node.Index);
                  treeGridViewTags.FirstDisplayedScrollingRowIndex = node.Index;
               }
            }
         }
      }

      private string GetDefaultMacro(DicomTag tag)
      {
         string macro = string.Empty;

         if (tag == null || tag.VR == DicomVRType.UN)
            return "${empty}";

         switch (tag.VR)
         {
            case DicomVRType.UI:
               macro = "${uid}";
               break;
            case DicomVRType.DA:
            case DicomVRType.DT:
               macro = "${random_date}";
               break;
            case DicomVRType.TM:
               macro = "${random_time}";
               break;
            case DicomVRType.PN:
               macro = "${name}";
               break;
            case DicomVRType.CS:
            case DicomVRType.LO:
            case DicomVRType.LT:
            case DicomVRType.UT:
               macro = "${random_string}";
               break;
            case DicomVRType.SH:
               macro = "${random_string(16)}";
               break;
            default:
               macro = "${empty}";
               break;
         }

         AddToList(macro);
         return macro;
      }

      private void tagToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         deleteToolStripMenuItem.Enabled = treeGridViewTags.SelectedRows.Count > 0;
      }

      private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
      {
         List<DicomTagNode> nodes = (from n in treeGridViewTags.Rows.Cast<DataGridViewRow>()
                                     where n.Selected == true
                                     select n as DicomTagNode).ToList();

         foreach (DicomTagNode node in nodes)
         {
            treeGridViewTags.Nodes.Remove(node);
            _Anonymizer.DeleteMacro(node.DicomTag.Code);
         }
         _Modified = nodes.Count > 0;
      }

      private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         saveToolStripMenuItem.Enabled = _Modified;
         saveAsToolStripMenuItem.Enabled = _FileName.Length > 0;         
         toolStripButtonAnonymize.Enabled = treeGridViewTags.Nodes.Count > 0;
      }

      private void saveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if (string.IsNullOrEmpty(_FileName))
            {
               using (SaveFileDialog dlgSave = new SaveFileDialog())
               {
                  dlgSave.Title = "Save Anonymization Script";
                  dlgSave.Filter = "Dicom Anonymization Script (*.das)|*.das";
                  dlgSave.AddExtension = true;

                  if (dlgSave.ShowDialog(this) == DialogResult.OK)
                  {
                     _Anonymizer.Save(dlgSave.FileName);
                     _FileName = dlgSave.FileName;
                     UpdateTitle();
                     _Modified = false;
                  }
               }
            }
            else
            {
               _Anonymizer.Save(_FileName);
               _Modified = false;
            }
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception);
         }
      }

      private bool PromptForSave()
      {
         if (!_Modified)
         {
            return true;
         }

         // ask the user to save.
         DialogResult result = MessageBox.Show(this, "Current anonymization script has changed. Would you like to save?", "Save current script", MessageBoxButtons.YesNoCancel);

         if (result == DialogResult.Cancel)
         {
            return false;
         }

         if (result == DialogResult.Yes)
         {
            // Does the current file have a name?
            if (string.IsNullOrEmpty(_FileName))
            {
               using (SaveFileDialog dlgSave = new SaveFileDialog())
               {
                  dlgSave.Title = "Save Anonymization Script";
                  dlgSave.Filter = "Dicom Anonymization Script (*.das)|*.das";
                  dlgSave.AddExtension = true;

                  if (dlgSave.ShowDialog(this) == DialogResult.OK)
                  {
                     _Anonymizer.Save(dlgSave.FileName);
                     _FileName = dlgSave.FileName;
                     UpdateTitle();
                  }
                  else
                  {
                     return false;
                  }
               }
            }
            else
            {
               _Anonymizer.Save(_FileName);
               UpdateTitle();
            }
            _Modified = false;
         }
         return true;
      }

      private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            using (SaveFileDialog dlgSave = new SaveFileDialog())
            {
               dlgSave.Title = "Save Anonymization Script";
               dlgSave.Filter = "Dicom Anonymization Script (*.das)|*.das";
               dlgSave.AddExtension = true;
               if (dlgSave.ShowDialog(this) == DialogResult.OK)
               {
                  _Anonymizer.Save(dlgSave.FileName);
                  _FileName = dlgSave.FileName;
                  UpdateTitle();
                  _Modified = false;
               }
            }
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception);
         }
      }

      private void newToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (PromptForSave())
         {
            treeGridViewTags.Freeze();            
            treeGridViewTags.Nodes.Clear();
            treeGridViewTags.Unfreeze();
            _Modified = false;
            _Anonymizer.TagMacros.Clear();
            _FileName = string.Empty;
            UpdateTitle();
         }
      }

      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (PromptForSave())
         {
            using (OpenFileDialog dlgOpen = new OpenFileDialog())
            {
               dlgOpen.Title = "Open Anonymization Script";
               dlgOpen.Filter = "Dicom Anonymization Script (*.das)|*.das";
               dlgOpen.Multiselect = false;
               dlgOpen.AddExtension = true;
               if (dlgOpen.ShowDialog(this) == DialogResult.OK)
               {
                  _Anonymizer = Anonymizer.Load(dlgOpen.FileName);
                  _FileName = dlgOpen.FileName;
                  UpdateTitle();
                  _Modified = false;
                  LoadMacros(_Anonymizer.TagMacros);
               }
            }
         }
      }

      private void toolStripButtonView_Click(object sender, EventArgs e)
      {
         AnonymizedInfo info = treeGridViewDifference.Tag as AnonymizedInfo;

         if (info != null)
         {
            try
            {              
               using (ViewImageDialog dlgView = new ViewImageDialog(info.AnonymizedDataset))
               {
                  dlgView.Text = "View Image";
                  dlgView.ShowDialog(this);
               }
            }
            catch (Exception exception)
            {
               Messager.ShowError(this, exception);
            }
         }
      }

      private void toolStripButtonSaveDataset_Click(object sender, EventArgs e)
      {
         AnonymizedInfo info = treeGridViewDifference.Tag as AnonymizedInfo;

         if (info != null)
         {
            try
            {
               using (SaveFileDialog dlgSave = new SaveFileDialog())
               {
                  dlgSave.Title = "Save Anonymized Dataset";
                  dlgSave.Filter = "Dicom Files (*.dic) | *.dic | All Files (*.*) | *.*";
                  dlgSave.AddExtension = true;
                  if (dlgSave.ShowDialog(this) == DialogResult.OK)
                     info.AnonymizedDataset.Save(dlgSave.FileName, DicomDataSetSaveFlags.None);
               }
            }
            catch (Exception exception)
            {
               Messager.ShowError(this, exception);
            }
         }

      }

      private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (PromptForSave())
         {
            treeGridViewTags.Freeze();
            treeGridViewTags.Nodes.Clear();
            treeGridViewTags.Unfreeze();
            _Modified = false;
            _Anonymizer.TagMacros.Clear();
            _FileName = string.Empty;
            UpdateTitle();
            foreach (var item in BasicProfile.TagMacros)
            {
               _Anonymizer.TagMacros.Add(item);
            }
            LoadMacros(_Anonymizer.TagMacros);
         }
      }

      private void LoadDefault()
      {
         try
         {
            DicomDataSet dsAnonymized;
            
            _ActiveDataSet.Load(DemosGlobal.ImagesFolder + @"\Image2.dcm", DicomDataSetLoadFlags.None);
            dsAnonymized = Anonymize();

            AnonymizedInfo info = new AnonymizedInfo() { AnonymizedDataset = dsAnonymized };

            //
            // Store the image count as a tag of the first node.  This is so we don't have to query the dataset during the Idle event.
            //
            if (treeGridViewTags.Nodes.Count > 0)
            {
               DicomElement element = dsAnonymized.FindFirstElement(null, DicomTag.PixelData, true);

               if (element != null)
                  info.ImageCount = dsAnonymized.GetImageCount(element);
            }
            treeGridViewDifference.Tag = info;
         }
         catch (Exception e)
         {
            Messager.Show(this, e, MessageBoxIcon.Error);
         }
      }

      private DicomDataSet Anonymize()
      {
         DicomDataSet dsAnonymized = new DicomDataSet();

         try
         {
            DicomElement pixelData = null;

            pixelData = _ActiveDataSet.FindFirstElement(null, DicomTag.PixelData, true);
            _Anonymizer.BlackoutRects.Clear();
            if (toolStripButtonRedact.Checked && pixelData != null && _ActiveDataSet.GetImageCount(pixelData) > 0)
            {
               using (SelectBlackoutRectsDialog dlgRects = new SelectBlackoutRectsDialog(_ActiveDataSet))
               {
                  if (dlgRects.ShowDialog(this) == DialogResult.OK && dlgRects.BlackoutRects.Count > 0)
                  {
                     _Anonymizer.BlackoutRects.AddRange(dlgRects.BlackoutRects);
                  }
               }
            }

            if (_ActiveDataSet.InformationClass != DicomClassType.BasicDirectory)
            {
               dsAnonymized.Copy(_ActiveDataSet, null, null);
               ToggleProgress(true);
               _Anonymizer.Anonymize(dsAnonymized);
               ShowDifference(_ActiveDataSet, dsAnonymized);
            }
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception);
         }
         finally
         {
            ToggleProgress(false);
         }
         return dsAnonymized;
      }

      private void toolStripButtonRefresh_Click(object sender, EventArgs e)
      {
         DicomDataSet dsAnonymized = Anonymize();
         AnonymizedInfo info = new AnonymizedInfo() { AnonymizedDataset = dsAnonymized };

         //
         // Store the image count as a tag of the first node.  This is so we don't have to query the dataset during the Idle event.
         //
         if (treeGridViewTags.Nodes.Count > 0)
         {
            DicomElement element = dsAnonymized.FindFirstElement(null, DicomTag.PixelData, true);

            if (element != null)
               info.ImageCount = dsAnonymized.GetImageCount(element);
         }
         treeGridViewDifference.Tag = info;
      }
   }
}
