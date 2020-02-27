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

using Leadtools;
using Leadtools.Demos;
using Leadtools.Controls;
using Leadtools.Forms.Recognition;
using Leadtools.Forms.Processing;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.WinForms;
using Leadtools.Drawing;


namespace FormsDemo
{
   public partial class RecognitionResult : Form
   {
      private List<FilledForm> _filledForms;
      private AnnAutomationManager annAutomationManager = null;
      private AutomationManagerHelper _annotationsHelper = null;
      private AnnAutomation automation = null;
      private ImageViewerPanZoomInteractiveMode _panInteractiveMode;
      private ImageViewerZoomToInteractiveMode _zoomToInteractiveMode;

      public RecognitionResult(List<FilledForm> filledForms)
      {
         InitializeComponent();
         _filledForms = filledForms;
         _cmbSelectedForm.Items.Clear();

         for (int i = 0; i < _filledForms.Count; i++)
            _cmbSelectedForm.Items.Add(_filledForms[i].Name);

         _panInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         _zoomToInteractiveMode = new ImageViewerZoomToInteractiveMode();

         _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left;

         _panInteractiveMode.IdleCursor = Cursors.Hand;
         _panInteractiveMode.IdleCursor = Cursors.Hand;
         _zoomToInteractiveMode.IdleCursor = Cursors.Cross;
         _zoomToInteractiveMode.IdleCursor = Cursors.Cross;

         _filledFormViewer.InteractiveModes.BeginUpdate();
         _fieldViewer.InteractiveModes.BeginUpdate();
         _filledFormViewer.InteractiveModes.Add(_panInteractiveMode);
         _filledFormViewer.InteractiveModes.Add(_zoomToInteractiveMode);
         _fieldViewer.InteractiveModes.Add(_panInteractiveMode);
         _fieldViewer.InteractiveModes.Add(_zoomToInteractiveMode);
         _filledFormViewer.InteractiveModes.EndUpdate();
         _fieldViewer.InteractiveModes.EndUpdate();
         _fieldResults.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      }

      ~RecognitionResult()
      {
         if (automation != null)
            automation = null;

         if (annAutomationManager != null)
            annAutomationManager = null;
      }

      private void SetupAnnotations()
      {
         // create and setup the automation manager
         annAutomationManager = new AnnAutomationManager();
         _annotationsHelper = new AutomationManagerHelper(annAutomationManager);
         annAutomationManager.CreateDefaultObjects();
         //Run mode to prevent editing of annotations
         annAutomationManager.UserMode = AnnUserMode.Run;

         //Create dummy image to init automation
         RasterImage img = new RasterImage(RasterMemoryFlags.Conventional, 1, 1, 1, RasterByteOrder.Bgr, RasterViewPerspective.TopLeft, null, IntPtr.Zero, 0);
         img.XResolution = 150;
         img.YResolution = 150;
         _filledFormViewer.Image = img;

         automation = new AnnAutomation(annAutomationManager, _filledFormViewer);
         automation.Active = true;
         _filledFormViewer.Image = null;
      }

      private void UpdateControls()
      {
         if (_fieldResults.SelectedRows.Count != 1)
         {
            _fieldViewer.Image = null;
            _fieldViewerToobar.Enabled = false;
         }
      }

      private void _cmbSelectedForm_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            _cmbSelectedPage.Items.Clear();

            for (int i = 0; i < _filledForms[_cmbSelectedForm.SelectedIndex].Image.PageCount; i++)
               _cmbSelectedPage.Items.Add((i + 1).ToString());

            _txtMasterForm.Text = _filledForms[_cmbSelectedForm.SelectedIndex].Master.Properties.Name;
            _txtFormConficence.Text = _filledForms[_cmbSelectedForm.SelectedIndex].Result.Confidence.ToString() + "%";

            _cmbSelectedPage.SelectedIndex = 0;
            UpdateControls();
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private string GetDataString(byte[] data)
      {
         string result = string.Empty;

         for (int i = 0; i < data.Length; i++)
         {
            result = result + System.Convert.ToChar(data[i]).ToString();
         }

         return result;
      }

      private void _cmbSelectedPage_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (_filledFormViewer.Image != null)
               _filledFormViewer.Image.Dispose();

            //If the user chose to only recognize the first page, there will only be a recognition confidence value for the first page
            if (_filledForms[_cmbSelectedForm.SelectedIndex].Result.PageResults.Count < _cmbSelectedPage.Items.Count)
            {
               _txtPageConfidence.Enabled = false;
               _txtPageConfidence.Text = "";
            }
            else
            {
               _txtPageConfidence.Enabled = true;
               _txtPageConfidence.Text = _filledForms[_cmbSelectedForm.SelectedIndex].Result.PageResults[_cmbSelectedPage.SelectedIndex].Confidence.ToString() + "%";
            }


            _filledForms[_cmbSelectedForm.SelectedIndex].Image.Page = _cmbSelectedPage.SelectedIndex + 1;
            _filledFormViewer.Image = _filledForms[_cmbSelectedForm.SelectedIndex].Image.Clone();

            _fieldResults.Rows.Clear();

            if (_filledForms[_cmbSelectedForm.SelectedIndex].ProcessingPages != null && _filledForms[_cmbSelectedForm.SelectedIndex].ProcessingPages.Count > _cmbSelectedPage.SelectedIndex)
            {
               foreach (FormField field in _filledForms[_cmbSelectedForm.SelectedIndex].ProcessingPages[_cmbSelectedPage.SelectedIndex])
               {
                  string[] row = new string[5];
                  row[0] = field.Name;

                  LeadRect alignedBounds = LeadRect.Empty;

                  if (field is TableFormField)
                  {
                     TableFormField tableField = field as TableFormField;
                     int pageIndex = Math.Max(tableField.ExpectedPages.IndexOf(_cmbSelectedPage.SelectedIndex), _cmbSelectedPage.SelectedIndex);
                     if (tableField.PagesBounds.ContainsKey(pageIndex))
                        alignedBounds = tableField.PagesBounds[pageIndex];
                     else
                        alignedBounds = LeadRect.Empty;
                  }
                  else if (field is UnStructuredTextFormField)
                  {
                     alignedBounds = field.Bounds;
                  }
                  else if (field is OmrFormField)
                  {
                      alignedBounds = _filledForms[_cmbSelectedForm.SelectedIndex].Alignment[field.MasterPageNumber - 1].AlignOmrRectangle(field.Bounds);
                  }
                  else
                      alignedBounds = _filledForms[_cmbSelectedForm.SelectedIndex].Alignment[field.MasterPageNumber - 1].AlignRectangle(field.Bounds);


                  row[4] = alignedBounds.ToString();

                  bool bAdded = true;

                  if (field.Result != null)
                  {
                     if (field is TextFormField)
                     {
                        row[1] = "Text";
                        row[2] = ((field as TextFormField).Result as TextFormFieldResult).Text;
                        row[3] = ((field as TextFormField).Result as TextFormFieldResult).AverageConfidence.ToString();
                     }
                     else if (field is UnStructuredTextFormField)
                     {
                        row[1] = "Unstructured Text";
                        row[2] = ((field as UnStructuredTextFormField).Result as TextFormFieldResult).Text;
                        row[3] = ((field as UnStructuredTextFormField).Result as TextFormFieldResult).AverageConfidence.ToString();
                     }
                     else if (field is OmrFormField)
                     {
                        row[1] = "Omr";
                        row[2] = ((field as OmrFormField).Result as OmrFormFieldResult).Text;
                        row[3] = ((field as OmrFormField).Result as OmrFormFieldResult).AverageConfidence.ToString();
                     }
                     else if (field is BarcodeFormField)
                     {
                        row[1] = "Barcode";
                        for (int i = 0; i < ((field as BarcodeFormField).Result as BarcodeFormFieldResult).BarcodeData.Count; i++)
                           row[2] = GetDataString(((field as BarcodeFormField).Result as BarcodeFormFieldResult).BarcodeData[i].GetData());

                        row[3] = "N/A";
                     }
                     else if (field is ImageFormField)
                     {
                        row[1] = "Image";
                        row[2] = "N/A";
                        row[3] = "N/A";
                     }
                     else if (field is TableFormField)
                     {
                        row[1] = "Table";
                        row[2] = "Double click here to view the results...";
                        row[3] = "N/A";
                     }
                     else if (field is SingleSelectionField)
                     {
                         row[1] = "SingleSelection";
                         row[2] = ((field as SingleSelectionField).Result as OmrFormFieldResult).Text;
                         row[3] = ((field as SingleSelectionField).Result as OmrFormFieldResult).AverageConfidence.ToString();
                     }
                     else if (field is BubbleWordField)
                     {
                         row[1] = "BubbleWord";
                         row[2] = ((field as BubbleWordField).Result as OmrFormFieldResult).Text;
                         row[3] = ((field as BubbleWordField).Result as OmrFormFieldResult).AverageConfidence.ToString();
                     }
#if LEADTOOLS_V20_OR_LATER
                     else if (field is OmrAnswerAreaField)
                     {
                        row[1] = "OmrAnswerAreaField";
                        row[2] = ((field as OmrAnswerAreaField).Result as OmrFormFieldResult).Text;
                        row[3] = ((field as OmrAnswerAreaField).Result as OmrFormFieldResult).AverageConfidence.ToString();
                     }
                     else if (field is OmrDateField)
                     {
                        row[1] = "OmrDateField";
                        row[2] = ((field as OmrDateField).Result as OmrFormFieldResult).Text;
                        row[3] = ((field as OmrDateField).Result as OmrFormFieldResult).AverageConfidence.ToString();
                     }
#endif //#if LEADTOOLS_V20_OR_LATER
                  }

                  if (bAdded)
                     _fieldResults.Rows.Add(row);

                  if (field is TableFormField)
                  {
                      _fieldResults.Rows[_fieldResults.Rows.Count - 1].Cells[2].Style.ForeColor = Color.Blue;
                  }
               }

               if (_fieldResults.Rows.Count > 0)
                  _fieldResults.Rows[0].Selected = true;
            }
            UpdateControls();
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void AddHighlight(Rectangle highlightBounds)
      {
         AnnHiliteObject annotationField = new AnnHiliteObject();
         annotationField.HiliteColor = "Yellow";
         automation.Container.Children.Add(annotationField);
         //Now we can calculate the object bounds correctly
         RectangleF rc = RectangleF.FromLTRB(highlightBounds.Left, highlightBounds.Top, highlightBounds.Right, highlightBounds.Bottom);
         LeadRectD rect = BoundsToAnnotations(annotationField, rc);
         annotationField.Rect = rect;
      }
             
      private LeadRectD BoundsToAnnotations(AnnObject annObject, RectangleF rect)
      {
         // Convert a rectangle from logical (top-left) to annotation object coordinates
         LeadRectD rc =  LeadRectD.Create(rect.Left + System.Convert.ToDouble(rect.Width < 0) * rect.Width, rect.Top + System.Convert.ToDouble(rect.Height < 0) * rect.Height, Math.Abs(rect.Width), Math.Abs(rect.Height));
         rc = _filledFormViewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rc);
         rc = automation.Container.Mapper.RectToContainerCoordinates(rc);
         return rc;
      }

      private void _fieldResults_SelectionChanged(object sender, EventArgs e)
      {
         try
         {
            //clear annotations
            automation.SelectObjects(null);
            automation.Container.Children.Clear();

            if (_fieldResults.Rows.Count > 0 && _fieldResults.SelectedRows.Count > 0)
            {
               if (_fieldViewer.Image != null)
                  _fieldViewer.Image.Dispose();

               int formIndex = _cmbSelectedForm.SelectedIndex;
               int pageIndex = _cmbSelectedPage.SelectedIndex;
               int fieldIndex = _fieldResults.SelectedRows[0].Index;
                              
               _filledForms[_cmbSelectedForm.SelectedIndex].Image.Page = _cmbSelectedPage.SelectedIndex + 1;
               LeadRect tempRect = LeadRect.Empty;
               FormField field = _filledForms[formIndex].ProcessingPages[pageIndex][fieldIndex];
                              
               if (field is TableFormField)
               {
                  TableFormField tableField = field as TableFormField;
                  int expectedPageIndex = -1;
                  if (tableField.ExpectedPages.Contains(pageIndex))
                     expectedPageIndex = tableField.ExpectedPages.IndexOf(pageIndex);

                  expectedPageIndex = Math.Max(expectedPageIndex, pageIndex);

                  if (tableField.PagesBounds.ContainsKey(expectedPageIndex))
                     tempRect = tableField.PagesBounds[expectedPageIndex];
                  else
                     tempRect = LeadRect.Empty;

               }
               else if (field is UnStructuredTextFormField)
               {
                  tempRect = field.Bounds;
               }
               else if (field is OmrFormField)
               {
                   tempRect = _filledForms[_cmbSelectedForm.SelectedIndex].Alignment[field.MasterPageNumber - 1].AlignOmrRectangle(field.Bounds);
               }
               else
                  tempRect = _filledForms[_cmbSelectedForm.SelectedIndex].Alignment[field.MasterPageNumber - 1 >= 0 ? field.MasterPageNumber - 1 : 0].AlignRectangle(field.Bounds);

               Rectangle alignedRect = Leadtools.Demos.Converters.ConvertRect(_filledForms[formIndex].Image.RectangleToImage(RasterViewPerspective.TopLeft, tempRect));
               if (!alignedRect.IsEmpty)
                  _fieldViewer.Image = _filledForms[formIndex].Image.Clone(Leadtools.Demos.Converters.ConvertRect(alignedRect));
               else
                  _fieldViewer.Image = null;
               AddHighlight(alignedRect);

               LeadMatrix LeadImageMatrix = _filledFormViewer.ImageTransform;
               //Ensure field is visible
               Transformer transformer = new Transformer(new System.Drawing.Drawing2D.Matrix((float)LeadImageMatrix.M11,
                                                                                             (float)LeadImageMatrix.M12,
                                                                                             (float)LeadImageMatrix.M21,
                                                                                             (float)LeadImageMatrix.M22,
                                                                                             (float)LeadImageMatrix.OffsetX,
                                                                                             (float)LeadImageMatrix.OffsetY));

               PointF location = transformer.PointToPhysical(alignedRect.Location);
               _filledFormViewer.CenterAtPoint(LeadPoint.Create((int)location.X, (int)location.Y));

               UpdateControls();
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void DisableInteactiveMode(bool viewer)
      {
         if (viewer)
            foreach (ImageViewerInteractiveMode mode in _filledFormViewer.InteractiveModes)
               mode.IsEnabled = false;
         else
            foreach (ImageViewerInteractiveMode mode in _fieldViewer.InteractiveModes)
               mode.IsEnabled = false;
      }

      private void RecognitionResult_Load(object sender, EventArgs e)
      {
         SetupAnnotations();
         RasterPaintProperties properties = RasterPaintProperties.Default;
         properties.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic | RasterPaintDisplayModeFlags.ScaleToGray;
         properties.PaintEngine = RasterPaintEngine.Gdi;
         properties.UsePaintPalette = true;
         _fieldViewer.PaintProperties = properties;
         _fieldViewer.UseDpi = false;
         DisableInteactiveMode(false);
         _fieldViewer.InteractiveModes.EnableById(_panInteractiveMode.Id);

         _filledFormViewer.PaintProperties = properties;
         _filledFormViewer.UseDpi = false;
         DisableInteactiveMode(true);
         _filledFormViewer.InteractiveModes.EnableById(_panInteractiveMode.Id);

         _cmbSelectedForm.SelectedIndex = 0;
         UpdateControls();
      }

      private void _btnFormPan_Click(object sender, EventArgs e)
      {
         DisableInteactiveMode(true);
         _filledFormViewer.InteractiveModes.EnableById(_panInteractiveMode.Id);
         _btnFormZoomRect.Checked = !_btnFormPan.Checked;
      }

      private void _btnFieldPan_Click(object sender, EventArgs e)
      {
         DisableInteactiveMode(false);
         _fieldViewer.InteractiveModes.EnableById(_panInteractiveMode.Id);
         _btnFieldZoomRect.Checked = !_btnFieldPan.Checked;
      }

      private void _btnFormZoomRect_Click(object sender, EventArgs e)
      {
         DisableInteactiveMode(true);
         _filledFormViewer.InteractiveModes.EnableById(_zoomToInteractiveMode.Id);
         _btnFormPan.Checked = !_btnFormZoomRect.Checked;
      }

      private void _btnFieldZoomRect_Click(object sender, EventArgs e)
      {
         DisableInteactiveMode(false);
         _fieldViewer.InteractiveModes.EnableById(_zoomToInteractiveMode.Id);
         _btnFieldPan.Checked = !_btnFieldZoomRect.Checked;
      }

      private void _btnFormZoomNormal_Click(object sender, EventArgs e)
      {
         try
         {
            _filledFormViewer.Zoom(ControlSizeMode.ActualSize, 1, _filledFormViewer.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnFieldZoomNormal_Click(object sender, EventArgs e)
      {
         try
         {
            _fieldViewer.Zoom(ControlSizeMode.ActualSize, 1, _filledFormViewer.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnFormZoomIn_Click(object sender, EventArgs e)
      {
         try
         {
            double oldScaleFactor = _filledFormViewer.ScaleFactor;
            _filledFormViewer.Zoom(ControlSizeMode.None, oldScaleFactor + 0.1f, _filledFormViewer.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnFieldZoomIn_Click(object sender, EventArgs e)
      {
         try
         {
            double oldScaleFactor = _fieldViewer.ScaleFactor;
            _fieldViewer.Zoom(ControlSizeMode.None, oldScaleFactor + 0.1f, _fieldViewer.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnFormZoomOut_Click(object sender, EventArgs e)
      {
         try
         {
            if (_filledFormViewer.ScaleFactor > 0.1f)
            {
               double oldScaleFactor = _filledFormViewer.ScaleFactor;
               _filledFormViewer.Zoom(ControlSizeMode.None, oldScaleFactor - 0.1f, _filledFormViewer.DefaultZoomOrigin);
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnFieldZoomOut_Click(object sender, EventArgs e)
      {
         try
         {
            if (_fieldViewer.ScaleFactor > 0.1f)
            {
               double oldScaleFactor = _fieldViewer.ScaleFactor;
               _fieldViewer.Zoom(ControlSizeMode.None, oldScaleFactor - 0.1f, _fieldViewer.DefaultZoomOrigin);
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnFormFit_Click(object sender, EventArgs e)
      {
         try
         {
            _filledFormViewer.Zoom(ControlSizeMode.FitAlways, 1, _filledFormViewer.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnFieldFit_Click(object sender, EventArgs e)
      {
         try
         {
            _fieldViewer.Zoom(ControlSizeMode.FitAlways, 1, _fieldViewer.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnFormFitWidth_Click(object sender, EventArgs e)
      {
         try
         {
            _filledFormViewer.Zoom(ControlSizeMode.FitWidth, 1, _filledFormViewer.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnFieldFitWidth_Click(object sender, EventArgs e)
      {
         try
         {
            _fieldViewer.Zoom(ControlSizeMode.FitWidth, 1, _fieldViewer.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _fieldResults_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         try
         {
            if (_fieldResults.Rows.Count > 0 && _fieldResults.SelectedRows.Count == 1)
            {
               int formIndex = _cmbSelectedForm.SelectedIndex;
               int pageIndex = _cmbSelectedPage.SelectedIndex;
               int fieldIndex = _fieldResults.SelectedRows[0].Index;

               if (_filledForms[formIndex].ProcessingPages[pageIndex][fieldIndex] is TextFormField 
                  || _filledForms[formIndex].ProcessingPages[pageIndex][fieldIndex] is OmrFormField 
                  || _filledForms[formIndex].ProcessingPages[pageIndex][fieldIndex] is UnStructuredTextFormField 
#if LEADTOOLS_V20_OR_LATER
                  || _filledForms[formIndex].ProcessingPages[pageIndex][fieldIndex] is OmrAnswerAreaField)
#else
)
#endif //#if LEADTOOLS_V20_OR_LATER
               {
                  DetailedCharacterResults detailedResultsdialog = new DetailedCharacterResults(_filledForms[formIndex].ProcessingPages[pageIndex][fieldIndex]);
                  detailedResultsdialog.ShowDialog(this);
               }
               else if (_filledForms[formIndex].ProcessingPages[pageIndex][fieldIndex] is TableFormField)
               {
                  TableFormField tableField = _filledForms[formIndex].ProcessingPages[pageIndex][fieldIndex] as TableFormField;
                  if (tableField.Result.Status == FormFieldStatus.Success)
                  {
                     DetailedTableResults detailedResultsdialog = new DetailedTableResults(_filledForms[formIndex].ProcessingPages[pageIndex][fieldIndex] as TableFormField);
                     detailedResultsdialog.ShowDialog(this);
                  }
                  else
                  {
                     MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_FailedRecognize"));
                  }
               }
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }
   }
}
