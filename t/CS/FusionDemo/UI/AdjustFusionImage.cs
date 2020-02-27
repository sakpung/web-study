// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

using Leadtools.MedicalViewer;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Designers;
using Leadtools;
using Leadtools.Annotations.WinForms;

namespace FusionDemo
{
   public partial class AdjustFusionImage : Form
   {
      MedicalViewer _viewer;
      MainForm _form;
      List<FusionData>[] _cellFusionNames;
      MedicalViewerMultiCell _cell;
      AnnEditDesigner _currentAnnDesigner;
      bool _update;

      public MedicalViewerMultiCell Cell
      {
         get
         {
            return _cell;
         }
         set
         {
            _cell = value;
         }
      }

      public AdjustFusionImage()
      {
         InitializeComponent();
      }

      public AdjustFusionImage(MedicalViewer viewer, MainForm form)
      {
         _viewer = viewer;
         _form = form;

         this.Shown += AdjustFusionImage_Shown;
         this.FormClosed += AdjustFusionImage_FormClosed;

         InitializeComponent();
         InitializeAdjustFusionImageForm();
      }

      void AdjustFusionImage_FormClosed(object sender, FormClosedEventArgs e)
      {
         _cell.Paint -= new PaintEventHandler(_cell_Paint);
         _cell.DesignerCreated -= new EventHandler<MedicalViewerDesignerCreatedEventArgs>(_cell_DesignerCreated);
         _cell.ActiveSubCellChanged -= new EventHandler<MedicalViewerActiveSubCellChangedEventArgs>(_cell_ActiveSubCellChanged);
         _cell.DeleteAnnotation -= new EventHandler<MedicalViewerDeleteEventArgs>(_cell_DeleteAnnotation);
         _cell.Automation.Edit -= new EventHandler<AnnEditDesignerEventArgs>(Automation_Edit);
         _cell.Automation.SetCursor -= new EventHandler<AnnCursorEventArgs>(Automation_SetCursor);
         _cell.Automation.RestoreCursor -= Automation_RestoreCursor;
         this.Shown -= AdjustFusionImage_Shown;
      }

      void AdjustFusionImage_Shown(object sender, EventArgs e)
      {
         UpdateFusionComboBox();
      }

      void InitializeAdjustFusionImageForm()
      {
         _currentAnnDesigner = null;

         int cellIndex = _form.GetFirstSelectedMultiCellIndex();
         if (cellIndex == -1)
            return;

         _cell = (MedicalViewerMultiCell)_viewer.Cells[cellIndex];
         if (_cell == null)
            return;

         _cell.Automation.Edit += new EventHandler<AnnEditDesignerEventArgs>(Automation_Edit);
         _cell.Automation.SetCursor += new EventHandler<AnnCursorEventArgs>(Automation_SetCursor);
         _cell.Automation.RestoreCursor += Automation_RestoreCursor;

         _cellFusionNames = _form.FusionListNames[cellIndex];
         UpdateFusionUI(0);
         UpdateFusionComboBox();
         MedicalViewerSubCell subCell = _cell.SubCells[_cell.ActiveSubCell];

         this.FormClosing += new FormClosingEventHandler(AdjustFusionImage_FormClosing);

         _cell.Paint += new PaintEventHandler(_cell_Paint);
         _cell.DesignerCreated += new EventHandler<MedicalViewerDesignerCreatedEventArgs>(_cell_DesignerCreated);
         _cell.ActiveSubCellChanged += new EventHandler<MedicalViewerActiveSubCellChangedEventArgs>(_cell_ActiveSubCellChanged);
         _cell.DeleteAnnotation += new EventHandler<MedicalViewerDeleteEventArgs>(_cell_DeleteAnnotation);

      }
      private void Automation_RestoreCursor(object sender, EventArgs e)
      {
         if (_viewer.Cursor != Cursors.Default)
            _viewer.Cursor = Cursors.Default;
      }
      private void Automation_SetCursor(object sender, AnnCursorEventArgs e)
      {
         Cursor newCursor = null;
         if (e.IsRotateCenter)
            newCursor = AutomationManagerHelper.AutomationCursors[CursorType.RotateCenterControlPoint];
         else if (e.IsRotateGripper)
         {
            newCursor = AutomationManagerHelper.AutomationCursors[CursorType.RotateGripperControlPoint];
         }
         else if (e.ThumbIndex < 0)
         {
            newCursor = AutomationManagerHelper.AutomationCursors[CursorType.SelectedObject];
         }
         else
         {
            newCursor = AutomationManagerHelper.AutomationCursors[CursorType.ControlPoint];
         }
         if (_viewer.Cursor != newCursor)
            _viewer.Cursor = newCursor;
      }

      void Automation_Edit(object sender, AnnEditDesignerEventArgs e)
      {
         AdjustFusionImage_Edit(sender, (AnnRectangleObject)e.Object);
      }

      void _cell_ActiveSubCellChanged(object sender, MedicalViewerActiveSubCellChangedEventArgs e)
      {
         if (_cell.SubCells[_cell.ActiveSubCell].Fusion.Count < 1)
         {
            EnableControls(false);
         }
         else
         {
            EnableControls(true);
            TerminateAdjustFusionImageForm();
            InitializeAdjustFusionImageForm();
         }
      }

      void _cell_DeleteAnnotation(object sender, MedicalViewerDeleteEventArgs e)
      {
         DialogResult msgBoxResult = MessageBox.Show("Are you sure want to delete this fusion image?", "Delete Fusion Image", MessageBoxButtons.YesNo);

         if (msgBoxResult == DialogResult.Yes)
         {
            _cell.SubCells[_cell.ActiveSubCell].Fusion.RemoveAt(_cmbFusedIndex.SelectedIndex);
            _form.FusionListNames[_form.GetFirstSelectedMultiCellIndex()][_cell.ActiveSubCell].RemoveAt(_cmbFusedIndex.SelectedIndex);
            _cmbFusedIndex.Items.RemoveAt(_cmbFusedIndex.SelectedIndex);
            if (_cmbFusedIndex.Items.Count < 1)
               this.Close();
            else
               _cmbFusedIndex.SelectedIndex = 0;
         }
         else
            e.Delete = false;

         _form.CheckFusionTranslucencyAction(_viewer.Cells.IndexOf(_cell));
      }

      private void _cell_DesignerCreated(object sender, MedicalViewerDesignerCreatedEventArgs e)
      {
         _currentAnnDesigner = (AnnEditDesigner)e.Designer;
         e.Object.RotateGripper = new LeadLengthD(e.Object.RotateGripper.Value / 2);
      }

      private AnnContainer GetContainer(MedicalViewerMultiCell cell, AnnObject annotationObject)
      {
         int index = 0;
         int length = cell.SubCells.Count;

         AnnContainer container;
         for (index = 0; index < length; index++)
         {
            container = cell.SubCells[index].AnnotationContainer;

            if (container.Children.IndexOf(annotationObject) != -1)
               return container;
         }
         return null;
      }

      private void AdjustFusionImage_Edit(object sender, AnnRectangleObject fusionEditRect)
      {
         int subCellIndex = _cell.ActiveSubCell;
         int index = _cmbFusedIndex.SelectedIndex;

         MedicalViewerFusion fusion = _cell.SubCells[subCellIndex].Fusion[index];

         AnnContainer _Container = GetContainer(_cell, fusionEditRect);
         fusion.Rotation = (float) fusionEditRect.Angle;

         LeadPointD[] pt = new LeadPointD[1];


         LeadRectD rect = _Container.Mapper.RectFromContainerCoordinates(fusionEditRect.Rect, AnnFixedStateOperations.None);

         Rectangle displayRect = _cell.GetDisplayedImageRectangle();

         rect.Offset(-displayRect.Left, -displayRect.Top);


         pt[0].X = (float)(rect.X + rect.Width / 2);
         pt[0].Y = (float)(rect.Y + rect.Height / 2);

         LeadPointD point = LeadPointD.Create(pt[0].X, pt[0].Y);


         _cell.AutomationContainer.Mapper.Transform.TransformPoints(pt);

         float normalizedXPosition = (float)(((float)point.X - (float)displayRect.Width / 2) / fusion.FusedImage.Width * 100 / _cell.GetScale(subCellIndex));
         float normalizedYPosition = (float)(((float)point.Y - (float)displayRect.Height / 2) / fusion.FusedImage.Height * 100 / _cell.GetScale(subCellIndex));

         float scaleX = (float)((rect.Width / fusion.FusedImage.Width)   * 100 / _cell.GetScale(subCellIndex));
         float scaleY = (float)((rect.Height / fusion.FusedImage.Height) * 100 / _cell.GetScale(subCellIndex));

         if (scaleX == 0)
            scaleX = 0.1F;

         if (scaleY == 0)
            scaleY = 0.1F;

         RectangleF rectangle = new RectangleF(normalizedXPosition, normalizedYPosition, Math.Abs(scaleX), Math.Abs(scaleY));

         fusion.DisplayRectangle = rectangle;

         UpdateFusionUI(index);

         CellData cellData = (CellData)_cell.Tag;
         if (cellData.SyncCellFusion)
            UpdateCellFusions(fusion, subCellIndex, index);

         _cell.Invalidate();
      }

      private void AdjustFusionImage_FormClosing(object sender, FormClosingEventArgs e)
      {
         TerminateAdjustFusionImageForm();
      }

      void TerminateAdjustFusionImageForm()
      {
         HideAllFusionEditRectangles();
         if (_currentAnnDesigner != null)
         {
            _currentAnnDesigner.End();
         }

         this.FormClosing -= new FormClosingEventHandler(AdjustFusionImage_FormClosing);

         if (_cell != null && !_cell.IsDisposed)
         {
            MedicalViewerSubCell subCell = _cell.SubCells[_cell.ActiveSubCell];

            _cell.Paint -= new PaintEventHandler(_cell_Paint);
            _cell.DesignerCreated -= new EventHandler<MedicalViewerDesignerCreatedEventArgs>(_cell_DesignerCreated);
            _cell.DeleteAnnotation -= new EventHandler<MedicalViewerDeleteEventArgs>(_cell_DeleteAnnotation);
            _cell.ActiveSubCellChanged -= new EventHandler<MedicalViewerActiveSubCellChangedEventArgs>(_cell_ActiveSubCellChanged);
         }

         if (_palettePreview.Image != null)
         {
            _palettePreview.Image.Dispose();
            _palettePreview.Image = null;
         }

         if (_orgImagePalettePreview.Image != null)
         {
            _orgImagePalettePreview.Image.Dispose();
            _orgImagePalettePreview.Image = null;
         }
      }

      void _cell_Paint(object sender, PaintEventArgs e)
      {
         e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      }

      private void UpdateFusionComboBox()
      {
         _cmbFusedIndex.Items.Clear();

         int subCellIndex = _cell.ActiveSubCell;

         int index = 0;
         int length = _cellFusionNames[subCellIndex] == null ? 0 : _cellFusionNames[subCellIndex].Count;

         for (index = 0; index < length; index++)
         {
            _cmbFusedIndex.Items.Add(_cellFusionNames[subCellIndex][index].Name);
         }

         EnableControls(length != 0);

         if (length != 0)
         {
            _cmbFusedIndex.SelectedIndex = 0;
         }
      }

      private void EnableControls(bool enabled)
      {
         _txtRotate.Enabled =
         _txtWLWidth.Enabled =
         _txtWLCenter.Enabled =
         _txtOffsetX.Enabled =
         _txtOffsetY.Enabled =
         _cmbPalette.Enabled =
         _cmbFusedIndex.Enabled =
         _chkFit.Enabled = enabled;
         _txtScaleX.Enabled = (!_chkFit.Checked) && enabled;
         _txtScaleY.Enabled = (!_chkFit.Checked) && enabled;
      }

      private void UpdateFusion()
      {
         if (!_update)
            return;

         int subCellIndex = _cell.ActiveSubCell;
         int index = _cmbFusedIndex.SelectedIndex;

         MedicalViewerSubCell subCell = _cell.SubCells[subCellIndex];
         MedicalViewerFusion fusion = subCell.Fusion[index];

         UpdatePalettePreview(_cmbPalette, _palettePreview);

         if (_txtWLWidth.Text == "")
            fusion.Width = 1;
         else
            fusion.Width = Convert.ToInt32(_txtWLWidth.Text);

         if (_txtWLCenter.Text == "")
            fusion.Center = 0;
         else
            fusion.Center = Convert.ToInt32(_txtWLCenter.Text);

         fusion.ColorPalette = (MedicalViewerPaletteType)_cmbPalette.SelectedIndex;

         if (_txtOffsetX.Text == "")
            fusion.DisplayRectangle = new RectangleF(0, fusion.DisplayRectangle.Y, fusion.DisplayRectangle.Width, fusion.DisplayRectangle.Height);
         else
         {
            try
            {
               float offsetX = float.Parse(_txtOffsetX.Text) / fusion.FusedImage.Width;
               fusion.DisplayRectangle = new RectangleF(offsetX, fusion.DisplayRectangle.Y, fusion.DisplayRectangle.Width, fusion.DisplayRectangle.Height);
            }
            catch { }
         }

         if (_txtOffsetY.Text == "")
            fusion.DisplayRectangle = new RectangleF(fusion.DisplayRectangle.X, 0, fusion.DisplayRectangle.Width, fusion.DisplayRectangle.Height);
         else
         {
            try
            {
               float offsetY = float.Parse(_txtOffsetY.Text) / fusion.FusedImage.Height;
               fusion.DisplayRectangle = new RectangleF(fusion.DisplayRectangle.X, offsetY, fusion.DisplayRectangle.Width, fusion.DisplayRectangle.Height);
            }
            catch { }
         }


         RasterImage image = _cell.VirtualImage[subCellIndex].Image;

         float fitScaleX = image.Width * 1.0f / fusion.FusedImage.Width;
         float fitScaleY = image.Height * 1.0f / fusion.FusedImage.Height;

         float xScale = 0.001f;
         if (_txtScaleX.Text != "")
            xScale = Math.Max(xScale, float.Parse(_txtScaleX.Text));

         float yScale = 0.001f;
         if (_txtScaleY.Text != "")
            yScale = Math.Max(yScale, float.Parse(_txtScaleY.Text));

         if (_txtScaleX.Text == "")
            fusion.DisplayRectangle = new RectangleF(fusion.DisplayRectangle.X, fusion.DisplayRectangle.Y, 1, fusion.DisplayRectangle.Height);
         else
            fusion.DisplayRectangle = new RectangleF(fusion.DisplayRectangle.X, fusion.DisplayRectangle.Y, _chkFit.Checked ? fitScaleX : xScale / 100.0f, fusion.DisplayRectangle.Height);

         if (_txtScaleY.Text == "")
            fusion.DisplayRectangle = new RectangleF(fusion.DisplayRectangle.X, fusion.DisplayRectangle.Y, fusion.DisplayRectangle.Width, 1);
         else
            fusion.DisplayRectangle = new RectangleF(fusion.DisplayRectangle.X, fusion.DisplayRectangle.Y, fusion.DisplayRectangle.Width, _chkFit.Checked ? fitScaleY : yScale / 100.0f);

         if (_txtRotate.Text == "")
            fusion.Rotation = 0;
         else
         {
            try
            {
               fusion.Rotation = float.Parse(_txtRotate.Text);
            }
            catch { }
         }


         UpdateFusionEditRectangle(index);

         CellData cellData = (CellData)_cell.Tag;
         if (cellData.SyncCellFusion)
            UpdateCellFusions(fusion, subCellIndex, index);
      }

      private void SuspendUpdate()
      {
         _update = false;
      }

      private void ResumeUpdate()
      {
         _update = true;
      }

      void UpdateCellFusions(MedicalViewerFusion refFusion, int subCellIndex, int index)
      {
         for (int i = 0; i < _cell.SubCells.Count; i++ )
         {
            if (i == subCellIndex)
               continue;

            if(_cell.SubCells[i].Fusion.Count <= index)
               continue;

            MedicalViewerFusion fusion = _cell.SubCells[i].Fusion[index];
            fusion.Center = refFusion.Center;
            fusion.ColorPalette = refFusion.ColorPalette;
            fusion.DisplayRectangle = new RectangleF(refFusion.DisplayRectangle.X, refFusion.DisplayRectangle.Y, refFusion.DisplayRectangle.Width, refFusion.DisplayRectangle.Height);
            fusion.Fit = refFusion.Fit;
            fusion.FusionScale = refFusion.FusionScale;
            fusion.OffsetX = refFusion.OffsetX;
            fusion.OffsetY = refFusion.OffsetY;
            fusion.Rotation = refFusion.Rotation;
            fusion.Scale = refFusion.Scale;
            fusion.Width = refFusion.Width;
         }
      }


      private void UpdateFusionUI(int index)
      {
         SuspendUpdate();
         int subCellIndex = _cell.ActiveSubCell;

         _cmbOrgImagePalette.SelectedIndex = (int)_cell.SubCells[subCellIndex].PaletteType;

         if (index >= 0 && _cell.SubCells[subCellIndex].Fusion.Count > index)
         {
            MedicalViewerSubCell subCell = _cell.SubCells[subCellIndex];
            MedicalViewerFusion fusion = subCell.Fusion[index];

            _cmbPalette.SelectedIndex = (int)fusion.ColorPalette;
            _txtWLWidth.Text = fusion.Width.ToString();
            _txtWLCenter.Text = fusion.Center.ToString();

            UpdatePalettePreview(_cmbPalette, _palettePreview);

            _txtOffsetX.Text = (fusion.DisplayRectangle.X * fusion.FusedImage.Width).ToString("#0.000");
            _txtOffsetY.Text = (fusion.DisplayRectangle.Y * fusion.FusedImage.Height).ToString("#0.000");

            _chkFit.Checked = (Math.Abs(fusion.DisplayRectangle.Width - 1) < 0.0001 && Math.Abs(fusion.DisplayRectangle.Height - 1) < 0.0001);

            _txtScaleX.Text = (fusion.DisplayRectangle.Width * 100).ToString("#0.000");
            _txtScaleX.Enabled = !_chkFit.Checked;
            _txtScaleY.Text = (fusion.DisplayRectangle.Height * 100).ToString("#0.000");
            _txtScaleY.Enabled = !_chkFit.Checked;

            _txtRotate.Text = fusion.Rotation.ToString("#0.000");

            _txtRotate.Refresh();

            _txtOffsetX.Refresh();
            _txtOffsetY.Refresh();

            _txtScaleX.Refresh();
            _txtScaleY.Refresh();
            _chkFit.Refresh();
         }

         ResumeUpdate();
      }

      private void FillImage(Image img, Color[] colors)
      {
         float xstep = (float)img.Width / (float)colors.Length;

         List<SolidBrush> brushes = new List<SolidBrush>();
         foreach (Color color in colors)
            brushes.Add(new SolidBrush(color));

         using (Graphics g = Graphics.FromImage(img))
         {
            for (int x = 0; x < colors.Length; x++)
               g.FillRectangle(brushes[x], new RectangleF(x * xstep, 0, xstep, img.Height));
         }
      }

      private void UpdatePalettePreview(ComboBox cmbPalette, PictureBox palettePreview)
      {
         byte[] palette = MedicalViewerCell.GetPalette((MedicalViewerPaletteType)cmbPalette.SelectedIndex);
         if (palette != null)
         {
            Color[] colorArray = new Color[palette.Length / 3];
            for (int i = 0; i < palette.Length; i += 3)
            {
               colorArray[i / 3] = Color.FromArgb(palette[i], palette[i + 1], palette[i + 2]);
            }
            if (palettePreview.Image != null)
            {
               palettePreview.Image.Dispose();
               palettePreview.Image = null;
            }
            Image paletteImage = new Bitmap(palettePreview.Width, palettePreview.Height);
            FillImage(paletteImage, colorArray);

            palettePreview.Image = paletteImage;
         }
         else
         {
            palettePreview.Image = null;
         }
      }

      private void AddAnnotationRectangle(MedicalViewerSubCell subCell)
      {
         AnnRectangleObject rect = new AnnRectangleObject();
         rect.IsVisible = false;
         rect.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), LeadLengthD.Create(5));
         subCell.AnnotationContainer.Children.Add(rect);
      }

      private void ShowFusionEditRectangle(int index)
      {
         int subCellIndex = _cell.ActiveSubCell;

         MedicalViewerSubCell subCell = _cell.SubCells[subCellIndex];

         for (int i = 0; i < subCell.AnnotationContainer.Children.Count; i++)
         {
            subCell.AnnotationContainer.Children[i].IsVisible = false;
         }

         AddAnnotationRectangle(subCell);

         UpdateFusionEditRectangle(index);

         subCell.AnnotationContainer.Children[index].IsVisible = true;
         _cell.RefreshAnnotation();
      }

      private void UpdateFusionEditRectangle(int index)
      {
         int subCellIndex = _cell.ActiveSubCell;

         MedicalViewerSubCell subCell = _cell.SubCells[subCellIndex];
         MedicalViewerFusion fusion = _cell.SubCells[subCellIndex].Fusion[index];
         AnnRectangleObject fusionEditRect = ((AnnRectangleObject)subCell.AnnotationContainer.Children[index]);
         double scaleRatio = _cell.GetScale(subCellIndex) / 100;

         Point location = _cell.GetDisplayedImageRectangle().Location;

         AnnContainer container = subCell.AnnotationContainer;
         double scale = _cell.GetScale(subCellIndex);

         LeadSizeD fusionEditRectSize = new LeadSizeD();
         fusionEditRectSize.Width = fusion.FusedImage.Width * fusion.DisplayRectangle.Width * scale / 100;
         fusionEditRectSize.Height = fusion.FusedImage.Height * fusion.DisplayRectangle.Height * scale / 100;

         fusionEditRectSize =  container.Mapper.SizeToContainerCoordinates(fusionEditRectSize);

         LeadPointD fusionEditRectPos = new LeadPointD();
         fusionEditRectPos.X = (subCell.AnnotationContainer.Size.Width - fusionEditRectSize.Width) / 2;
         fusionEditRectPos.Y = (subCell.AnnotationContainer.Size.Height - fusionEditRectSize.Height) / 2;

         //container.Bounds
         fusionEditRect.Rect = new LeadRectD(fusionEditRectPos, fusionEditRectSize);

         AnnContainer _Container = GetContainer(_cell, fusionEditRect);

         fusionEditRect.Rotate(fusion.Rotation, new LeadPointD(_Container.Size.Width / 2, _Container.Size.Height / 2));
         LeadPointD point = LeadPointD.Create(fusion.DisplayRectangle.X * fusion.FusedImage.Width * scaleRatio + location.X, fusion.DisplayRectangle.Y * fusion.FusedImage.Height * scaleRatio + location.Y);
         point = _Container.Mapper.PointToContainerCoordinates(point);
         fusionEditRect.Translate(point.X, point.Y);

         fusionEditRect.RotateCenter = new LeadPointD(fusionEditRect.Rect.Left + (fusionEditRect.Rect.Width / 2), fusionEditRect.Rect.Top + (fusionEditRect.Rect.Height / 2));

         _cell.RefreshAnnotation();
         _cell.Automation.Invalidate(LeadRectD.Empty);
         _cell.Invalidate();
      }

      private void HideAllFusionEditRectangles()
      {
         if (_cell.IsDisposed)
            return;

         _cell.Automation.DeleteSelectedObjects();
         foreach (MedicalViewerSubCell subCell in _cell.SubCells)
         {
            subCell.AnnotationContainer.Children.Clear();
         }

         _cell.RefreshAnnotation();
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         if (_currentAnnDesigner != null)
            _currentAnnDesigner.End();

         Close();
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         _btnOK_Click(sender, e);
      }

      private void _txtOffsetY_TextChanged(object sender, EventArgs e)
      {
         UpdateFusion();
      }

      private void _txtOffsetX_TextChanged(object sender, EventArgs e)
      {
         UpdateFusion();
      }

      private void _txtScale_TextChanged(object sender, EventArgs e)
      {
         UpdateFusion();
      }

      private void _txtWLWidth_TextChanged(object sender, EventArgs e)
      {
         UpdateFusion();
      }

      private void _txtWLCenter_TextChanged(object sender, EventArgs e)
      {
         UpdateFusion();
      }

      private void _txtRotate_TextChanged(object sender, EventArgs e)
      {
         UpdateFusion();
      }

      private void _chkFit_CheckedChanged(object sender, EventArgs e)
      {
         _txtScaleX.Enabled = !_chkFit.Checked;
         _txtScaleY.Enabled = !_chkFit.Checked;
         UpdateFusion();
      }

      private void _cmbFusedIndex_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateFusionUI(_cmbFusedIndex.SelectedIndex);

         ShowFusionEditRectangle(_cmbFusedIndex.SelectedIndex);

         if (_currentAnnDesigner != null)
            _currentAnnDesigner.End();
      }

      private void _cmbPalette_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateFusion();
      }

      private void _cmbOrgImagePalette_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdatePalettePreview(_cmbOrgImagePalette, _orgImagePalettePreview);

         _cell.SubCells[_cell.ActiveSubCell].PaletteType = (MedicalViewerPaletteType)_cmbOrgImagePalette.SelectedIndex;
      }

      private void _btnReset_Click(object sender, EventArgs e)
      {
         int subCellIndex = _cell.ActiveSubCell;
         int index = _cmbFusedIndex.SelectedIndex;

         _cmbOrgImagePalette.SelectedIndex = 0;

         UpdatePalettePreview(_cmbOrgImagePalette, _orgImagePalettePreview);

         if (index >= 0 && _cell.SubCells[subCellIndex].Fusion.Count > index)
         {
            MedicalViewerSubCell subCell = _cell.SubCells[subCellIndex];
            MedicalViewerFusion fusion = subCell.Fusion[index];

            MedicalViewerFusion tmpFusion = new MedicalViewerFusion();
            tmpFusion.FusedImage = fusion.FusedImage;

            SuspendUpdate();
            _txtWLWidth.Text = tmpFusion.Width.ToString();
            _txtWLCenter.Text = tmpFusion.Center.ToString();

            _txtScaleX.Text = "100.000";
            _txtScaleY.Text = "100.000";

            _txtOffsetX.Text = "0.000";
            _txtOffsetY.Text = "0.000";

            _txtRotate.Text = "0.000";

            _chkFit.Checked = true;

            _cmbPalette.SelectedIndex = 0;

            ResumeUpdate();

            UpdateFusion();

            _txtRotate.Refresh();

            _txtOffsetX.Refresh();
            _txtOffsetY.Refresh();

            _txtScaleX.Refresh();
            _txtScaleY.Refresh();

            _chkFit.Refresh();

            _cmbPalette.Refresh();
            resetOffset();
         }
      }

      private void resetOffset()
      {
         using (MedicalViewerOffset offset = (MedicalViewerOffset)_cell.GetActionProperties(MedicalViewerActionType.Offset))
         {
            offset.X = 0;
            offset.Y = 0;
            _cell.SetActionProperties(MedicalViewerActionType.Offset, offset);
         }
      }
   }
}
