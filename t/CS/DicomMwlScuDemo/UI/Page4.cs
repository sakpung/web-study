// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Controls;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using Leadtools.WinForms.CommonDialogs.File;

namespace DicomDemo
{
   public partial class Page4 : UserControl
   {
      private Globals _globals;
      private ImageViewerRubberBandInteractiveMode _rubberBandInteractiveMode;
      private ImageViewerMagnifyGlassInteractiveMode _rasterMagnifyGlass2;

      public ImageViewerRubberBandInteractiveMode RubberBandInteractiveMode
      {
         get
         {
            return _rubberBandInteractiveMode;

         }
         set
         {
            _rubberBandInteractiveMode = value;

         }
      }

      public ImageViewerMagnifyGlassInteractiveMode RasterMagnifyGlass2
      {
         get
         {
            return _rasterMagnifyGlass2;

         }
         set
         {
            _rasterMagnifyGlass2 = value;

         }
      }

      public Page4(ref Globals pGlobals)
      {
         InitializeComponent();

         _globals = pGlobals;

         RubberBandInteractiveMode = new ImageViewerRubberBandInteractiveMode();
         RasterMagnifyGlass2 = new ImageViewerMagnifyGlassInteractiveMode();

         RubberBandInteractiveMode.Shape = Leadtools.Controls.ImageViewerRubberBandShape.Rectangle;
         RubberBandInteractiveMode.AutoItemMode = Leadtools.Controls.ImageViewerAutoItemMode.AutoSet;
         RubberBandInteractiveMode.WorkOnBounds = true;
         RubberBandInteractiveMode.IsEnabled = true;
         this.rasterImageViewer.InteractiveModes.Add(RubberBandInteractiveMode);

         RasterMagnifyGlass2.Crosshair = Leadtools.Controls.ImageViewerSpyGlassCrosshair.Fine;
         RasterMagnifyGlass2.ScaleFactor = 2;
         RasterMagnifyGlass2.WorkOnBounds = true;
         RasterMagnifyGlass2.Shape = Leadtools.Controls.ImageViewerSpyGlassShape.Rectangle;
         RasterMagnifyGlass2.Size = new Leadtools.LeadSize(150, 150);
         RasterMagnifyGlass2.IsEnabled = true;
         this.rasterImageViewer.InteractiveModes.Add(RasterMagnifyGlass2);
         this.rasterImageViewer.InteractiveModes.EnableById(RasterMagnifyGlass2.Id);
      }

      /*
       * After an element tree node is selected, update the text boxes with the element data
       */
      void m_TreeResult_AfterSelect(object sender, TreeViewEventArgs e)
      {
         try
         {
            // Get the root parent node
            MyTreeNode MWLNode = _globals.m_TreeResult.GetSelectedRootNode();

            txtSelectedWorklist.Text = MWLNode.Text;
            txtModality.Text = Utils.GetStringValue(MWLNode.m_DS, DemoDicomTags.Modality, false);

            if (((MyTreeNode)e.Node).m_Element != null)
            {
               txtElementValue.Text = ((MyTreeNode)e.Node).m_DS.GetConvertValue(((MyTreeNode)e.Node).m_Element);
            }
            else
            {
               txtElementValue.Text = "";
            }

            // Disable the next button if the user doesn't have an image and an item selected
            ((MainForm)Parent.Parent).btnNext.Enabled = ((rasterImageViewer.Image != null) && (_globals.m_TreeResult.SelectedNode != null));
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }


      }

      /*
       * When this page is made active, add the global MWL tree view and add or remove the AfterSelect
       *   event
       */
      private void Page4_VisibleChanged(object sender, EventArgs e)
      {
         try
         {
            if (Visible)
            {
               // Disable the next button if the user doesn't have an image and an item selected
               ((MainForm)Parent.Parent).btnNext.Enabled = ((rasterImageViewer.Image != null) && (_globals.m_TreeResult.SelectedNode != null));


               // Display the global results tree view
               panelTreeView.Controls.Add(_globals.m_TreeResult);

               // Add needed events from the tree
               _globals.m_TreeResult.AfterSelect += new TreeViewEventHandler(m_TreeResult_AfterSelect);
            }
            else
            {
               // Remove events from the tree since we're not using this page anymore
               _globals.m_TreeResult.AfterSelect -= m_TreeResult_AfterSelect;
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      /*
       * Loads an image into the viewer
       */
      private void btnSelectImage_Click(object sender, EventArgs e)
      {
         try
         {
            using (RasterCodecs codecs = new RasterCodecs())
            {
               ImageFileLoader loader = new ImageFileLoader();

               loader.ShowLoadPagesDialog = true;

               if (loader.Load(this, codecs, true) > 0)
               {
                  rasterImageViewer.Image = loader.Image.Clone();
                  ((MainForm)Parent.Parent).btnNext.Enabled = true;
               }

               // Disable the next button if the user doesn't have an image and an item selected
               ((MainForm)Parent.Parent).btnNext.Enabled = ((rasterImageViewer.Image != null) && (_globals.m_TreeResult.SelectedNode != null));
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      /*
       * Creates a new dataset based off of the MWL dataset
       */
      public CreateDatasetReturn CreateDataset()
      {
         CreateDatasetReturn nRet = CreateDatasetReturn.GeneralError;

         try
         {

            // Check for a selected node
            if (_globals.m_TreeResult.SelectedNode == null)
               return CreateDatasetReturn.NoItemSelected;

            // Make sure that the modality is supported            
            nRet = CreateDatasetReturn.ModalityNotFound;
            string strModality = Utils.GetStringValue(((MyTreeNode)_globals.m_TreeResult.SelectedNode).m_DS, DemoDicomTags.Modality, false);
            DicomClassType nClass = DicomClassType.SCImageStorage; // use SCImageStorage if we cannot find the modality

            for (int i = 0; i < _globals.m_ModalityTable.Length; i++)
            {
               if (strModality == _globals.m_ModalityTable[i].m_strValue)
               {
                  // Modality was found, change return type to Success
                  nClass = _globals.m_ModalityTable[i].m_DicomClassType;
                  nRet = CreateDatasetReturn.Success;
                  break;
               }
            }

            // Initialize dataset
            MyDicomDataSet ds = new MyDicomDataSet();

            ds.Initialize(nClass, DicomDataSetInitializeFlags.ImplicitVR | DicomDataSetInitializeFlags.LittleEndian | DicomDataSetInitializeFlags.AddMandatoryElementsOnly | DicomDataSetInitializeFlags.AddMandatoryModulesOnly);



            ds.MapMWLtoDS(((MyTreeNode)_globals.m_TreeResult.SelectedNode).m_DS);
            ds.SetTagSpecificCharacterSet();
            ds.SetTagInstanceNumber(1);

            // Set Pixel Data
            DicomElement PixelDataElement = ds.FindFirstElement(null, DemoDicomTags.PixelData, true);
            if (PixelDataElement != null)
            {
               ds.DeleteElement(PixelDataElement);
               PixelDataElement = ds.InsertElement(null, false, DemoDicomTags.PixelData, DicomVRType.OB, false, 0);
            }

            // use RGB as default Photometric Interpretation
            DicomImagePhotometricInterpretationType nPhotometric = DicomImagePhotometricInterpretationType.Rgb;
            if (rasterImageViewer.Image != null)
            {
               if (rasterImageViewer.Image.Order == Leadtools.RasterByteOrder.Gray)
                  nPhotometric = DicomImagePhotometricInterpretationType.Monochrome2;
               else if (Convert.ToInt32(rasterImageViewer.Image.Order) <= 8)
                  nPhotometric = DicomImagePhotometricInterpretationType.PaletteColor;
               else
                  nPhotometric = DicomImagePhotometricInterpretationType.Rgb;

               ds.InsertImage(PixelDataElement, rasterImageViewer.Image, 0, DicomImageCompressionType.None,
                   nPhotometric, 0, 0, DicomSetImageFlags.AutoSetVoiLut);
            }

            ds.DeleteEmptyElementsType3(nClass);
            ds.DeleteEmptyModulesOptional(nClass);

            if (nPhotometric != DicomImagePhotometricInterpretationType.PaletteColor)
            {

               if (ds.IsEmptyModule(DicomModuleType.PaletteColorLookupTable))
               {
                  ds.DeleteModule(DicomModuleType.PaletteColorLookupTable);
               }

            }

            // Generate new series instance UID and SOP Instance UID
            ds.InsertUID(DemoDicomTags.SeriesInstanceUID);
            ds.InsertUID(DemoDicomTags.SOPInstanceUID);

            // If the MWL already had a study instance UID, we use that
            // If not, generate a new UID
            ds.GenerateStudyInstanceUID();

            _globals.m_nClass = nClass;
            _globals.m_DS = ds;
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }

         return nRet;
      }

      /*
       * Enumeration type for the return value of CreateDataset()
       */
      public enum CreateDatasetReturn : int
      {
         Success,
         GeneralError,
         NoItemSelected,
         ModalityNotFound
      }
   }
}
