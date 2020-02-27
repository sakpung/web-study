using Leadtools;
using Leadtools.Controls;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DicomDemo.UI
{
   public partial class LoadOptionsDlg : Form
   {
      public LoadOptionsDlg()
      {
         InitializeComponent();
      }

      public ImageViewer Viewer
      {
         get;
         set;
      }

      public DicomDataSet ds
      {
         get;
         set;
      }

      private static bool _firstLoad = true;

      private static DicomGetImageFlags _defaultImageFlags = DicomGetImageFlags.None;

      private DicomGetImageFlags _getImageFlags = DicomGetImageFlags.None;

      private bool _initializing = true;

      public DicomGetImageFlags GetImageFlags
      {
         get
         {
            return _getImageFlags;
         }
         set
         {
            _getImageFlags = value;
         }
      }

      private void UpdateImageViewer()
      {
         _getImageFlags = CheckBoxesToGetImageFlags();

         DicomElement element = ds.FindFirstElement(null, DicomTag.PixelData, true);
         int bitmapCount = ds.GetImageCount(element);
         if (bitmapCount > 0)
         {
            try
            {
               RasterImage _image = ds.GetImage(element, 0, 0, RasterByteOrder.Gray, _getImageFlags);
               Viewer.Image = _image;
            }
            catch (Exception)
            {
               Viewer.Image = null;
            }
         }
      }

      private void GetImageFlagsToCheckBoxes()
      {
         this.checkBoxAutoApplyModalityLut.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.AutoApplyModalityLut);
         this.checkBoxAutoApplyVoiLut.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.AutoApplyVoiLut);
         this.checkBoxAutoScaleModalityLut.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.AutoScaleModalityLut);
         this.checkBoxAutoScaleVoiLut.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.AutoScaleVoiLut);
         this.checkBoxAutoDetectInvalidRleCompression.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.AutoDetectInvalidRleCompression);
         this.checkBoxKeepColorPalette.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.KeepColorPalette);
         this.checkBoxLoadCorrupted.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.LoadCorrupted);
         this.checkBoxRleSwapSegments.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.RleSwapSegments);
         this.checkBoxAutoLoadOverlays.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.AutoLoadOverlays);
      }

      private DicomGetImageFlags CheckBoxesToGetImageFlags()
      {
         DicomGetImageFlags flags = DicomGetImageFlags.None;

         if (checkBoxAutoApplyModalityLut.Checked)
            flags |= DicomGetImageFlags.AutoApplyModalityLut;

         if (checkBoxAutoApplyVoiLut.Checked)
            flags |= DicomGetImageFlags.AutoApplyVoiLut;

         if (checkBoxAutoScaleModalityLut.Checked)
            flags |= DicomGetImageFlags.AutoScaleModalityLut;

         if (checkBoxAutoScaleVoiLut.Checked)
            flags |= DicomGetImageFlags.AutoScaleVoiLut;

         if (checkBoxAutoDetectInvalidRleCompression.Checked)
            flags |= DicomGetImageFlags.AutoDetectInvalidRleCompression;

         if (checkBoxKeepColorPalette.Checked)
            flags |= DicomGetImageFlags.KeepColorPalette;

         if (checkBoxLoadCorrupted.Checked)
            flags |= DicomGetImageFlags.LoadCorrupted;

         if (checkBoxRleSwapSegments.Checked)
            flags |= DicomGetImageFlags.RleSwapSegments;

         if (checkBoxAutoLoadOverlays.Checked)
            flags |= DicomGetImageFlags.AutoLoadOverlays;

         return flags;
      }

      private void LoadOptionsDlg_Load(object sender, EventArgs e)
      {
         _initializing = true;
         if (_firstLoad)
         {
            _defaultImageFlags = _getImageFlags;
            _firstLoad = false;
         }
         GetImageFlagsToCheckBoxes();

         _initializing = false;
      }

      private void buttonOK_Click(object sender, EventArgs e)
      {
         _getImageFlags = CheckBoxesToGetImageFlags();
      }

      private void buttonRestoreDefaults_Click(object sender, EventArgs e)
      {
         _getImageFlags = _defaultImageFlags;
         _initializing = true;
         GetImageFlagsToCheckBoxes();
         _initializing = false;
         UpdateImageViewer();
      }

      private void checkBoxAutoApplyModalityLut_CheckedChanged(object sender, EventArgs e)
      {
         if (_initializing)
            return;

         if (checkBoxAutoApplyModalityLut.Checked == false)
         {
            checkBoxAutoScaleModalityLut.Checked = false;
            checkBoxAutoScaleVoiLut.Checked = false;
         }
         UpdateImageViewer();
      }

      private void checkBoxAutoApplyVoiLut_CheckedChanged(object sender, EventArgs e)
      {
         if (_initializing)
            return;

         if (checkBoxAutoApplyVoiLut.Checked == false)
         {
            checkBoxAutoScaleVoiLut.Checked = false;
         }
         UpdateImageViewer();
      }

      private void checkBoxAutoScaleModalityLut_CheckedChanged(object sender, EventArgs e)
      {
         if (_initializing)
            return;

         if (checkBoxAutoScaleModalityLut.Checked)
         {
            checkBoxAutoApplyModalityLut.Checked = true;
         }
         UpdateImageViewer();
      }

      private void checkBoxAutoScaleVoiLut_CheckedChanged(object sender, EventArgs e)
      {
         if (_initializing)
            return;

         if (checkBoxAutoScaleVoiLut.Checked)
         {
            checkBoxAutoApplyModalityLut.Checked = true;
            checkBoxAutoApplyVoiLut.Checked = true;
            checkBoxAutoScaleModalityLut.Checked = true;
            // CheckedAutoScaleVoiLut.Checked = true;
         }
         UpdateImageViewer();
      }

      private void checkBoxAutoDetectInvalidRleCompression_CheckedChanged(object sender, EventArgs e)
      {
         if (_initializing)
            return;

         if (checkBoxAutoDetectInvalidRleCompression.Checked)
            checkBoxRleSwapSegments.Checked = false;

         UpdateImageViewer();
      }

      private void checkBoxRleSwapSegments_CheckedChanged(object sender, EventArgs e)
      {
         if (_initializing)
            return;

         if (checkBoxRleSwapSegments.Checked)
            checkBoxAutoDetectInvalidRleCompression.Checked = false;

         UpdateImageViewer();
      }

      private void checkBoxKeepColorPalette_CheckedChanged(object sender, EventArgs e)
      {
         if (_initializing)
            return;

         UpdateImageViewer();
      }

      private void checkBoxLoadCorrupted_CheckedChanged(object sender, EventArgs e)
      {
         if (_initializing)
            return;

         UpdateImageViewer();
      }


      private void checkBoxAutoLoadOverlays_CheckedChanged(object sender, EventArgs e)
      {
         if (_initializing)
            return;

         UpdateImageViewer();
      }
   }

   public static class MyExtensions
   {
      public static bool IsFlagged(this DicomGetImageFlags flags, DicomGetImageFlags flag)
      {
         return ((flags & flag) == (flag));
      }

      public static bool IsFlagged(this uint flags, uint flag)
      {
         return ((flags & flag) == (flag));
      }
   }
}
