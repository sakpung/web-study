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

using Leadtools.Dicom.Common.Editing;
using Leadtools.Dicom;
using Leadtools.Demos;
using Leadtools.Codecs;
using Leadtools.MedicalViewer;
using Leadtools;
using System.Threading;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace DicomEditorDemo
{
   public partial class MainForm : Form
   {
      private DicomDataSet _DataSet;
      private string _Filename = string.Empty;
      private MedicalViewer _MedicalViewer;
      private string _openInitialPath = string.Empty;

      public MedicalViewerCell Cell
      {
         get
         {
            MedicalViewerCell cell;
            if (_MedicalViewer.Cells.Count < 1)
            {
               _MedicalViewer.Cells.Add(createNewCell());
            }
            cell = _MedicalViewer.Cells[0] as MedicalViewerCell;
            
            return cell;
         }
      }

      public MainForm()
      {
         InitializeComponent();
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         if (DesignMode)
            return;
         Messager.Caption = "C# DICOM Editor Demo";
         Text = Messager.Caption;

         _DataSet = new DicomDataSet();
         if (_DataSet == null)
         {
            MessageBox.Show("Can't create dicom object. Quitting app.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
            return;
         }

         splitContainer.SplitterDistance = ClientRectangle.Width / 3;
         InitializeMedicalViewer();
         LoadDefaultImage();
      }

      private void LoadDefaultImage()
      {
         try
         {
#if LT_CLICKONCE
            _DataSet.Load("image2.dcm", DicomDataSetLoadFlags.LoadAndClose);
            LoadImage(null);
            _Filename = "image2.dcm";
#else
            _DataSet.Load(DemosGlobal.ImagesFolder + @"\image2.dcm", DicomDataSetLoadFlags.LoadAndClose);
            LoadImage(null);
            _Filename = DemosGlobal.ImagesFolder + @"\image2.dcm";
#endif // LT_CLICKONCE

            propertyGridDataSet.DataSet = _DataSet;
            Text = Messager.Caption + " : " + _Filename;

         }
         catch { }
      }

      private void InitializeMedicalViewer()
      {
         MedicalViewerCell cell = createNewCell();

         _MedicalViewer = new MedicalViewer(1, 1);
         _MedicalViewer.Dock = DockStyle.Fill;
         _MedicalViewer.SplitterStyle = MedicalViewerSplitterStyle.None;
         _MedicalViewer.Cells.Add(cell);
         splitContainer.Panel2.Controls.Add(_MedicalViewer);
      }

      private MedicalViewerCell createNewCell()
      {
         MedicalViewerCell cell = new MedicalViewerCell();

         cell.AddAction(MedicalViewerActionType.Stack);
         cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active);

         return cell;
      }

      private void optionsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         showTagInfoToolStripMenuItem.Checked = propertyGridDataSet.ShowTagInfo;
         showUsageImagesToolStripMenuItem.Checked = propertyGridDataSet.ShowUsageImages;
         addCommandsToolStripMenuItem.Checked = propertyGridDataSet.ShowCommands;
         readOnlyToolStripMenuItem.Checked = propertyGridDataSet.ReadOnly;
      }

      private void showTagInfoToolStripMenuItem_Click(object sender, EventArgs e)
      {
         propertyGridDataSet.ShowTagInfo = showTagInfoToolStripMenuItem.Checked;
      }

      private void showUsageImagesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         propertyGridDataSet.ShowUsageImages = showUsageImagesToolStripMenuItem.Checked;
      }

      private void addCommandsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         propertyGridDataSet.ShowCommands = addCommandsToolStripMenuItem.Checked;
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (WaitCursor wait = new WaitCursor())
         {
            openFileDialog.InitialDirectory = DemosGlobal.ImagesFolder;
            openFileDialog.InitialDirectory = _openInitialPath;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
               try
               {
                  _openInitialPath = Path.GetDirectoryName(openFileDialog.FileName);
                  _DataSet.Load(openFileDialog.FileName, DicomDataSetLoadFlags.LoadAndClose);
                  LoadImage(null);
                  _Filename = openFileDialog.FileName;
                  propertyGridDataSet.DataSet = _DataSet;
                  propertyGridDataSet.Refresh();
                  Text = Messager.Caption + " : " + openFileDialog.FileName;
               }
               catch (Exception ex)
               {
                  Messager.ShowError(this, ex.Message);
               }
            }
         }
      }

      private void LoadImage(RasterImage image)
      {
         int count = 0;

         Clear();
         if (image == null)
         {
            count = _DataSet.GetImageCount(null);
            if (count > 0)
            {
#if !LEADTOOLS_V20_OR_LATER
               DicomGetImageFlags getImageFlags =
                     DicomGetImageFlags.AutoApplyModalityLut |
                     DicomGetImageFlags.AutoApplyVoiLut |
                     DicomGetImageFlags.AutoScaleModalityLut |
                     DicomGetImageFlags.AutoScaleVoiLut |
                     DicomGetImageFlags.AutoDectectInvalidRleCompression;
#else
              DicomGetImageFlags getImageFlags =
                    DicomGetImageFlags.AutoApplyModalityLut |
                    DicomGetImageFlags.AutoApplyVoiLut |
                    DicomGetImageFlags.AutoScaleModalityLut |
                    DicomGetImageFlags.AutoScaleVoiLut |
                    DicomGetImageFlags.AutoDetectInvalidRleCompression;
#endif // #if !LEADTOOLS_V20_OR_LATER

               image = _DataSet.GetImages(null, 0, count, 0, RasterByteOrder.Rgb | RasterByteOrder.Gray,
                                          getImageFlags);
            }

            animationToolStripMenuItem.Enabled = count > 1;
         }

         if (image != null)
         {
            MedicalViewerCell cell = _MedicalViewer.Cells[0] as MedicalViewerCell;

            cell.Image = image;
            cell.FitImageToCell = true;
            if (image.GrayscaleMode != RasterGrayscaleMode.None)
            {
               cell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData);
               cell.SetTag(0, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.Frame);
            }

            animationToolStripMenuItem.Enabled = image.PageCount > 1;
         }
      }

      private void commandsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         bool hasDataSet = propertyGridDataSet.DataSet != null;

         addTagsToolStripMenuItem.Enabled = (hasDataSet && propertyGridDataSet.CanAddTag) && !propertyGridDataSet.ReadOnly;
         addItemToolStripMenuItem.Enabled = (hasDataSet && propertyGridDataSet.CanAddSequenceItem) && !propertyGridDataSet.ReadOnly;
         deleteTagToolStripMenuItem.Enabled = hasDataSet && !propertyGridDataSet.ReadOnly;
         animationToolStripMenuItem.Enabled = hasDataSet && Cell.Image != null && Cell.Image.PageCount > 1;
      }

      private void newtoolStripMenuItem_Click(object sender, EventArgs e)
      {
         NewDatasetDlg dlgNew = new NewDatasetDlg(_DataSet);

         if (dlgNew.ShowDialog(this) == DialogResult.OK)
         {
            Clear();
            using (WaitCursor wait = new WaitCursor())
            {
               _DataSet.Initialize(dlgNew.Class, dlgNew.Flags);
               propertyGridDataSet.DataSet = _DataSet;
               Text = Messager.Caption;
               _Filename = string.Empty;
            }
         }
      }

      private void addTagsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         List<long> tags = propertyGridDataSet.ShowTagSelectionDialog();

         if (tags.Count > 0)
            propertyGridDataSet.AddTags(tags);
      }

      private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         saveAsToolStripMenuItem.Enabled = _DataSet.GetFirstElement(null, false, true) != null;
         saveToolStripMenuItem.Enabled = _DataSet.GetFirstElement(null, false, true) != null && !string.IsNullOrEmpty(_Filename);
      }

      private void saveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         string oldFile = _Filename;

         if (string.IsNullOrEmpty(_Filename))
         {
            SaveFileDialog sf = new SaveFileDialog();

            sf.Filter = "DCM File(*.dcm)|*.dcm|All files (*.*)|*.*";
            sf.AddExtension = true;
            sf.Title = "Save Dicom File";

            if (sf.ShowDialog(this) == DialogResult.OK)
               _Filename = sf.FileName;
         }

         try
         {
            _DataSet.Save(_Filename, DicomDataSetSaveFlags.None);
            Text = Messager.Caption + " : " + _Filename;
         }
         catch (DicomException de)
         {
            string err = string.Format("Error saving dicom dataset!\r\n\r\n{0}", de.Code.ToString());

            _Filename = oldFile;
            MessageBox.Show(err, "Error");
            return;
         }
      }

      private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(_Filename))
         {
            saveToolStripMenuItem_Click(saveToolStripMenuItem, e);
         }
         else
         {
            SaveFileDialog sf = new SaveFileDialog();

            sf.Filter = "DCM File(*.dcm)|*.dcm|All files (*.*)|*.*";
            sf.AddExtension = true;
            sf.Title = "Save Dicom File As";
            sf.FileName = _Filename;

            if (sf.ShowDialog(this) == DialogResult.OK)
            {
               try
               {
                  _DataSet.Save(sf.FileName, DicomDataSetSaveFlags.None);
                  _Filename = sf.FileName;
                  Text = Messager.Caption + " : " + _Filename;
               }
               catch (DicomException de)
               {
                  string err = string.Format("Error saving dicom dataset!\r\n\r\n{0}", de.Code.ToString());

                  MessageBox.Show(err, "Error");
                  return;
               }
            }
         }
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("DICOM Editor", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("DICOM Editor"))
            aboutDialog.ShowDialog(this);
#endif
      }

      private void propertyGridDataSet_BeforeAddElement(object sender, BeforeAddElementEventArgs e)
      {
         if (CellHasImage())
         {
            if (e.Element.DicomElement.Tag == DicomTag.PatientID && e.Element.Value != null)
            {
               SetUserTag(0, MedicalViewerTagAlignment.TopLeft, "PID: " + e.Element.Value);
            }

            if (e.Element.DicomElement.Tag == DicomTag.PatientName && e.Element.Value != null)
            {
               SetUserTag(1, MedicalViewerTagAlignment.TopLeft, e.Element.Value);
            }
         }

         if (_DataSet != null)
         {
            if (_DataSet.IsVolatileElement(e.Element.DicomElement))
            {
               e.Element.Attributes.Add(new ReadOnlyAttribute(true));
            }
         }
      }

      void propertyGridDataSet_PropertyInfo(object sender, PropertyInfoEventArgs e)
      {
         e.PropertyImageInfo.Add(new PropertyImageInfo());
      }

      private void propertyGridDataSet_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
      {
         DicomEditablePropertyDescriptor pd = e.ChangedItem.PropertyDescriptor as DicomEditablePropertyDescriptor;

         if (pd != null)
         {
            if (pd.Element.Tag == DicomTag.PixelData)
            {
               RasterImage image = pd.GetValue(null) as RasterImage;

               if (image != null)
               {
                  LoadImage(image);
               }
            }

            if (pd.Element.Tag == DicomTag.PatientName)
            {
               if (pd.Element.Tag == DicomTag.PatientName && pd.GetValue(null) != null)
               {
                  SetUserTag(1, MedicalViewerTagAlignment.TopLeft, pd.GetValue(null));
               }
            }
         }
      }

      private void SetUserTag(int row, MedicalViewerTagAlignment align, object value)
      {
         Cell.SetTag(row, align, MedicalViewerTagType.UserData, value != null ? value.ToString() : (string)value);
      }

      private bool CellHasImage()
      {
         return Cell.Image != null;
      }

      private void Clear()
      {
         Cell.Image = null;
         SetUserTag(2, MedicalViewerTagAlignment.BottomLeft, string.Empty);
         SetUserTag(0, MedicalViewerTagAlignment.TopRight, string.Empty);
         SetUserTag(0, MedicalViewerTagAlignment.TopLeft, string.Empty);
         SetUserTag(1, MedicalViewerTagAlignment.TopLeft, string.Empty);
      }

      private void animationToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnimationDialog dlgAnimation = new AnimationDialog(_MedicalViewer);

         dlgAnimation.ShowDialog(this);
      }

      private void readOnlyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         propertyGridDataSet.ReadOnly = !propertyGridDataSet.ReadOnly;
      }

      private void deleteTagToolStripMenuItem_Click(object sender, EventArgs e)
      {
         propertyGridDataSet.DeleteTag();
      }

      private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
      {
         propertyGridDataSet.AddSequenceItem();
      }
   }
}
