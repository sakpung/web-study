// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Leadtools;
using Leadtools.WinForms;
using Leadtools.Dicom;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.ImageProcessing;
using Leadtools.Medical3D;
using Leadtools.MedicalViewer;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using Leadtools.Demos.Dialogs;

namespace Main3DDemo
{
    public partial class MainForm : Form
    {
#if FOR_NUGET
      private const string NUGET_LIC_WARNING = "When using a LEADTOOLS 30-day, limited license file, LEADTOOLS will randomly watermark your images and documents." +
         " This may cause unexpected results in this demo. " +
         "To obtain a fully functional license with no watermarking, contact LEADTOOLS Technical Support or visit: https://www.leadtools.com/downloads/evaluation-form";
#endif // FOR_NUGET

        SeriesBrowser seriesBrowserDialog;
        MedicalViewer _viewer;
        CounterDialog counter;
        private bool _planeCutLineClicked;
        private Point _mousePoint;
        private int _polygonIndex;
        private MedicalViewerMPRPolygon _polygon;
        private MedicalViewerMPRPolygonHitTest _clickType;
        private bool _showFirstAndLastReferenceLines;
        private bool _polygonHandleClicked = false;

        private CellData _cellData;
        private bool _MPRMode;
        private bool _showReferenceBoundaries;
        private bool _showReferenceLine;
        private bool _showMPRCrossHair;
        private bool _coloredMPRCrossHair;
        private ContextMenuStrip _rightClickContextMenu;
        private ContextMenuStrip _rightClickGeneratorContextMenu;
        private int _generatorCellIndex;
        private Point _currentMousePoint;
        private ToolStripMenuItem _currentSelectedMenuItem;
        private MedicalViewerActionType _actionType;
        int _counter;
        private bool _showScrollBar;
        private bool _alwaysInterpolate;



        public bool AlwaysInterpolate
        {
            get
            {
                return _alwaysInterpolate;
            }

            set
            {
                _alwaysInterpolate = value;
            }
        }


        public enum MPRType
        {
            Axial,
            Sagittal,
            Coronal
        }

        [STAThread]
        static void Main(string[] args)
        {
            if (!Support.SetLicense())
                return;

            if (RasterSupport.IsLocked(RasterSupportType.Medical))
            {
                MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Medical.ToString()), "Warning");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.DoEvents();

            {
#if FOR_NUGET
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (Convert.ToBoolean(config.AppSettings.Settings["ShowNuGetWarningDialog"]?.Value))
            {
               MessageBox.Show(NUGET_LIC_WARNING, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               if(null!=config.AppSettings.Settings["ShowNuGetWarningDialog"])
                  config.AppSettings.Settings["ShowNuGetWarningDialog"].Value = "false";
               config.Save(ConfigurationSaveMode.Modified);
            }
#endif // FOR_NUGET
                Application.Run(new MainForm());

            }
        }

        public bool SoftwareRendering { get; private set; }
        public Medical3DVolumeRenderingType RenderingType { get; private set; }
        public bool HardwareCompatible { get; private set; }

        public MainForm()
        {
           RenderingType = (Medical3DVolumeRenderingType)Convert.ToInt32(GetConfigData("RenderingType"));
           Medical3DEngine.SoftwareRendering = false;
           HardwareCompatible = Medical3DEngine.HardwareCompatible;
           SoftwareRendering = (IsConfigValueTrue("SoftwareOnlyRenderingMode"));

           InitializeComponent();
           InitClass();
        }

        private void InitializeMPRCell(MedicalViewerMPRCell cell, MPRType type)
        {
            AddBasicActionsFor2DCell(cell);

            cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active);

            cell.ShowSlabBoundaries = _menuShowSlab.Checked;
            cell.SnapRulers = true;
            AddProbeToolEvents(cell);
            cell.SetTag(0, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, type.ToString());

            cell.SetTag(0, MedicalViewerTagAlignment.LeftCenter, MedicalViewerTagType.LeftOrientation);
            cell.SetTag(0, MedicalViewerTagAlignment.RightCenter, MedicalViewerTagType.RightOrientation);
            cell.SetTag(0, MedicalViewerTagAlignment.TopCenter, MedicalViewerTagType.TopOrientation);
            cell.SetTag(0, MedicalViewerTagAlignment.BottomCenter, MedicalViewerTagType.BottomOrientation);

            cell.SetTag(0, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.RulerUnit);

            cell.Tag = new CellData(ViewerCellType.MPRCell);

            MedicalViewerWindowLevel windowLevel = (MedicalViewerWindowLevel)cell.GetActionProperties(MedicalViewerActionType.WindowLevel);

            windowLevel.RelativeSensitivity = true;

            cell.AlwaysInterpolate = AlwaysInterpolate;

            cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevel);

            SetAction(cell, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel);
        }

        void SetCurrent2DAction(MedicalViewerCell cell)
        {
            switch (_actionType)
            {
                case MedicalViewerActionType.Alpha:
                case MedicalViewerActionType.MagnifyGlass:
                case MedicalViewerActionType.Offset:
                case MedicalViewerActionType.WindowLevel:
                case MedicalViewerActionType.Scale:
                case MedicalViewerActionType.ProbeTool:
                case MedicalViewerActionType.PanoramicPolygon:
                    cell.SetAction(_actionType, MedicalViewerMouseButtons.Left, getApplyingOperation(_actionType));
                    break;
                default:
                    cell.SetAction(MedicalViewerActionType.None, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
                    break;
            }
        }

        void SetCurrent3DAction(Medical3DControl cell)
        {
            bool canExcute = cell.CanExecuteAction(_actionType);

            // Cannot apply window level on the volume while in SSD.
            if (cell.ObjectsContainer.VolumeType == Medical3DVolumeType.SSD)
            {
                if (_actionType == MedicalViewerActionType.WindowLevel)
                    canExcute = false;
            }

            if (canExcute)
            {
                cell.SetAction(_actionType, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
            }
            else
            {
                cell.SetAction(MedicalViewerActionType.Rotate3DObject, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
            }
        }

        private void Initialize3DCell(Medical3DControl cell)
        {
            cell.AddAction(MedicalViewerActionType.Rotate3DObject);
            cell.AddAction(MedicalViewerActionType.Offset);
            cell.AddAction(MedicalViewerActionType.Scale3DObject);
            cell.AddAction(MedicalViewerActionType.Rotate3DCamera);
            cell.AddAction(MedicalViewerActionType.Translate3DCamera);
            cell.AddAction(MedicalViewerActionType.Scale);
            cell.AddAction(MedicalViewerActionType.TranslatePlane);
            cell.AddAction(MedicalViewerActionType.RotatePlane);
            cell.AddAction(MedicalViewerActionType.WindowLevel);

            SetCurrent3DAction(cell);
            cell.ObjectsContainer.CreateObject += new EventHandler<RasterCommandProgressEventArgs>(ObjectsContainer_CreateObject);
            _menuInvert.Checked = false;
        }

        private void StartProgress(CounterDialog counterDialog)
        {
            counterDialog.Show();
        }

        private void EndProgress(CounterDialog counterDialog)
        {
            if (counterDialog != null)
            {
                counterDialog.Close();
                counterDialog.Dispose();
                counterDialog = null;
            }
        }

        private void ObjectsContainer_CreateObject(object sender, RasterCommandProgressEventArgs e)
        {
            Medical3DControl control = ((Medical3DControl)((Medical3DContainer)sender).OwnerControl);
            CounterDialog counterDialog = null;//

            if (control.Tag is CounterDialog)
                counterDialog = (CounterDialog)(control.Tag);

            if ((e.Percent % 5) == 0)
                Application.DoEvents();
            if (counterDialog == null)
                return;
            counterDialog.Percent = e.Percent;
            counterDialog.Update();
        }

        private void InitializeCell(MedicalViewerMultiCell cell, SeriesInformation seriesInformation)
        {
            cell.ShowCellScroll = _showScrollBar;
            cell.PaintingMethod = MedicalViewerPaintingMethod.Bicubic;
            cell.CellMouseClick += new EventHandler<MedicalViewerCellMouseEventArgs>(_viewer_CellMouseClick);
            cell.CellMouseDown += new EventHandler<MedicalViewerCellMouseEventArgs>(_viewer_CellMouseDown);
            cell.PlaneCutLineClicked += new EventHandler<MedicalViewerPlaneCutLineEventArgs>(_viewer_PlaneCutLineClicked);
            cell.Data3DRequested += new EventHandler<MedicalViewerData3DRequestedEventArgs>(cell_Data3DRequested);
            cell.DerivativeGenerated += new EventHandler<MedicalViewerDerivativeGeneratedEventArgs>(cell_DerivativeGenerated);
            cell.Data3DFrameRequested += new EventHandler<MedicalViewer3DFrameRequestedEventArgs>(cell_Data3DFrameRequested);
            cell.MPRPolygonCreated += new EventHandler<MedicalViewerMPRPolygonEventsArgs>(cell_CurvedMPRPolygonCreated);
            cell.PanoramicDataRequested += new EventHandler<MedicalViewerPanoramicDataRequestedEventArgs>(cell_CurvedMPRDataRequested);
            cell.MPRPolygonClicked += new EventHandler<MedicalViewerMPRPolygonClickedEventsArgs>(cell_CurvedMPRPolygonClicked);
            AddProbeToolEvents(cell);
            cell.AutoDisposeInternalData = true;
            cell.FitImageToCell = false;
            cell.SetScaleMode(MedicalViewerScaleMode.Fit);
            cell.SnapRulers = true;

            AddBasicActionsFor2DCell(cell);

            cell.AddAction(MedicalViewerActionType.PanoramicPolygon);

            cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, getApplyingOperation(MedicalViewerActionType.Offset));
            cell.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Middle, getApplyingOperation(MedicalViewerActionType.Scale));
            cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, getApplyingOperation(MedicalViewerActionType.Stack));
            cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, getApplyingOperation(MedicalViewerActionType.WindowLevel));

            CellData data = (CellData)cell.Tag;

            data.CurrentCheckedItem = _menuActionWindowLevel;
            data.CurrentCheckedRightClickItem = _rightClickWindowLevel;
            data.CurrentActionType = MedicalViewerActionType.WindowLevel;

            cell.SetActionKeys(MedicalViewerActionType.Stack, new MedicalViewerKeys(Keys.PageUp, Keys.PageDown, Keys.None, Keys.None, MedicalViewerModifiers.None));

            cell.SetActionKeys(MedicalViewerActionType.WindowLevel, new MedicalViewerKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right, MedicalViewerModifiers.Ctrl));

            cell.Selected = true;

            cell.AlwaysInterpolate = AlwaysInterpolate;

            SetCurrent2DAction(cell);

            if (seriesInformation != null && !string.IsNullOrEmpty(seriesInformation.PhotometricInterpretation))
            {
                cell.PhotometricInterpretation = seriesInformation.PhotometricInterpretation;
            }
        }

        void SetAllItemsEnabled(ContextMenuStrip menu, bool enabled)
        {
            foreach (ToolStripItem item in menu.Items)
            {
                item.Enabled = enabled;
            }
        }

        void SetAllItemsVisible(ContextMenuStrip menu, bool visible)
        {
            foreach (ToolStripItem item in menu.Items)
            {
                item.Visible = visible;
            }
        }

        void cell_CellMouseDown(object sender, MedicalViewerCellMouseEventArgs e)
        {
            MedicalViewerCell cell = (MedicalViewerCell)(sender);

            if (cell.VirtualImage == null)
            {
                _probeToolImage = cell.Image;
            }
            else
            {
                if (cell.VirtualImage[e.SubCellIndex].ImageExist)
                {
                    _probeToolImage = cell.VirtualImage[e.SubCellIndex].Image;
                }
            }
        }
        private void AddProbeToolEvents(MedicalViewerCell cell)
        {
            cell.ProbeToolTextChanged += new EventHandler<MedicalViewerProbeToolTextChangedEventArgs>(cell_ProbeToolTextChanged);
            cell.CellMouseDown += new EventHandler<MedicalViewerCellMouseEventArgs>(cell_CellMouseDown);
        }

        void cell_ProbeToolTextChanged(object sender, MedicalViewerProbeToolTextChangedEventArgs e)
        {
            int bitmapX = (int)(e.X);
            int bitmapY = (int)(e.Y);
            string output;

            string value = GetRealPixelValue(_probeToolImage, bitmapX, bitmapY);

            if (value != "")
                output = String.Format("X = {0}, Y = {1} \nValue = {2} \nFrame {3}", (int)e.X, (int)e.Y, value, e.SubCellIndex + 1);
            else
                output = String.Format("X = N/A, Y = N/A \nValue = N/A \nFrame N/A");

            e.Text = output;
        }

        RasterImage _probeToolImage;

        string GetRealPixelValue(RasterImage image, int x, int y)
        {
            LeadPoint bitmapPoint = image.PointToImage(RasterViewPerspective.TopLeft, new LeadPoint(x, y));

            x = bitmapPoint.X;
            y = bitmapPoint.Y;

            if (x >= 0 && y >= 0)
                if ((image.Width >= x) && (image.Height >= y))
                {
                    byte[] Data;
                    Int16 Value;
                    UInt16 uValue;

                    // just work with extended gray scale here
                    if (image.GrayscaleMode != RasterGrayscaleMode.None && image.BitsPerPixel > 8)
                    {
                        Data = image.GetPixelData(y, x);
                        if (image.Signed)
                        {
                            Int16 highBit;
                            if (image.HighBit == 0)
                            {
                                highBit = (Int16)(image.BitsPerPixel - 1);
                            }
                            else
                                highBit = (Int16)image.HighBit;

                            Value = BitConverter.ToInt16(Data, 0);
                            // account for when all allocated bits are not used for image data encoding
                            if ((image.HighBit < (image.BitsPerPixel - 1)) | (image.LowBit > 0))
                            {
                                // actual image low bit is not 0
                                if (image.LowBit != 0)
                                {
                                    Value = (Int16)(Value >> image.LowBit);
                                    highBit = (Int16)(image.HighBit - image.LowBit);
                                }

                                // see if the value is negative 
                                Int16 signLimit;
                                signLimit = (Int16)(Math.Pow(2, highBit + 1) / 2);
                                if (Value >= signLimit)
                                {
                                    Value = (Int16)(Value - (Math.Pow(2, highBit + 1)));
                                }
                            }

                            return Value.ToString();
                        }
                        else
                        {
                            uValue = BitConverter.ToUInt16(Data, 0);
                            // when low bit is not zero
                            if (image.LowBit > 0)
                            {
                                uValue = (UInt16)(uValue >> image.LowBit);
                            }
                            return uValue.ToString();
                        }
                    }
                    else
                    {
                        int R;
                        int G;
                        int B;

                        if (image.BitsPerPixel > 32)
                        {
                            byte[] bit16ComponentData;
                            bit16ComponentData = image.GetPixelData(y, x);
                            R = BitConverter.ToUInt16(bit16ComponentData, 0);
                            G = BitConverter.ToUInt16(bit16ComponentData, 2);
                            B = BitConverter.ToUInt16(bit16ComponentData, 4);
                            return String.Format("{0}, {1}, {2}", R, G, B);
                        }


                        RasterColor PixelColor = image.GetPixelColor(y, x);
                        return String.Format("{0}, {1}, {2}", PixelColor.R, PixelColor.G, PixelColor.B);
                    }

                }
            return "";
        }

        void cell_CurvedMPRPolygonClicked(object sender, MedicalViewerMPRPolygonClickedEventsArgs e)
        {
            MedicalViewerMultiCell cell = (MedicalViewerMultiCell)sender;

            if (e.Button == MouseButtons.Right)
            {

                _mousePoint.X = e.X + cell.Location.X;
                _mousePoint.Y = e.Y + cell.Location.Y;
                _polygonIndex = e.Index;
                _polygon = e.Polygon;
                _clickType = e.Type;
                _polygonHandleClicked = true;

                SetAllItemsVisible(_panoramicRightClickMenu, true);
                SetAllItemsEnabled(_panoramicRightClickMenu, true);
                switch (e.Type)
                {
                    case MedicalViewerMPRPolygonHitTest.Body:
                        {
                            _panoramicRightClickDeletePoint.Visible = false;
                            MedicalViewerParaxialCutCell paraxialCell = GetParaxialCell();
                            // if there is already one paraxial cell on that line, don't allow adding another.
                            if (paraxialCell != null)
                            {
                                _panoramicRightClickCreateParaxialCell.Enabled = false;
                            }
                            else // if there is no paraxial, then disable all the paraxial properties.
                            {
                                _panoramicRightClickActiveParaxialColor.Enabled = false;
                                _panoramicRightClickParaxialLineColor.Enabled = false;
                                _panoramicRightClickParaxialProperties.Enabled = false;
                                _panoramicRightClickDeleteParaxialCell.Enabled = false;
                            }
                        }
                        break;

                    case MedicalViewerMPRPolygonHitTest.Handle:
                        _panoramicRightClickSeperator1.Visible = false;
                        _panoramicRightClickSeperator2.Visible = false;
                        _panoramicRightClickInsertPoint.Visible = false;
                        _panoramicRightClickDeleteParaxialCell.Visible = false;
                        _panoramicRightClickCreateParaxialCell.Visible = false;
                        _panoramicRightClickActiveParaxialColor.Visible = false;
                        _panoramicRightClickParaxialLineColor.Visible = false;
                        _panoramicRightClickParaxialProperties.Visible = false;

                        if (_polygon.Points.Count <= 2)
                            _panoramicRightClickDeletePoint.Enabled = false;

                        break;
                }

                _panoramicRightClickMenu.Show(_viewer, _mousePoint);
            }
        }


        void AddParaxialCell(MedicalViewerMultiCell cellSource, MedicalViewerMPRPolygon polygon, int index)
        {
            MedicalViewerParaxialCutCell paraxialCutCell = new MedicalViewerParaxialCutCell(polygon, index);

            paraxialCutCell.Tag = new CellData(ViewerCellType.Derivate);
            paraxialCutCell.EfficientMemoryEnabled = true;
            paraxialCutCell.Rows = 2;
            paraxialCutCell.Columns = 2;
            paraxialCutCell.ApplyActionOnMove = true;
            paraxialCutCell.ShowCellScroll = false;
            CopyTags(paraxialCutCell, cellSource, true);

            InitializeCell(paraxialCutCell, null);

            _viewer.Cells.Add(paraxialCutCell);
        }

        void cell_CurvedMPRPolygonCreated(object sender, MedicalViewerMPRPolygonEventsArgs e)
        {
            MedicalViewerMultiCell cellSource = (MedicalViewerMultiCell)sender;
            MedicalViewerPanoramicCell cell = new MedicalViewerPanoramicCell(e.Polygon);

            cell.Tag = new CellData(ViewerCellType.Derivate);

            AddProbeToolEvents(cell);
            CopyTags(cell, cellSource, true);

            AddBasicActionsFor2DCell(cell);

            cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.AllCells | MedicalViewerActionFlags.RealTime);
            cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.AllCells | MedicalViewerActionFlags.RealTime);
            cell.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Middle, MedicalViewerActionFlags.AllCells | MedicalViewerActionFlags.RealTime);
            _viewer.Cells.Add(cell);

            // AddParaxialCell(cellSource, e.Polygon, 0);

            e.Polygon.EnableDragThickness = true;


            _menuActionWindowLevel_Click(e, e);

        }

#if !LEADTOOLS_V20_OR_LATER
        private const DicomGetImageFlags _dicomGetImageFlags =
                    DicomGetImageFlags.AutoApplyModalityLut |
                    DicomGetImageFlags.AutoApplyVoiLut |
                    DicomGetImageFlags.AutoScaleModalityLut |
                    DicomGetImageFlags.AutoScaleVoiLut |
                    DicomGetImageFlags.AutoDectectInvalidRleCompression;
#else
        private const DicomGetImageFlags _dicomGetImageFlags =
                    DicomGetImageFlags.AutoDetectInvalidRleCompression;
#endif // #if !LEADTOOLS_V20_OR_LATER

        void cell_CurvedMPRDataRequested(object sender, MedicalViewerPanoramicDataRequestedEventArgs e)
        {
            MedicalViewerMultiCell cell = (MedicalViewerMultiCell)sender;
            CellData data = (CellData)cell.Tag;
            RasterCodecs _codecs = new RasterCodecs();

            DicomDataSet ds = new DicomDataSet();
            if (data.CellType == ViewerCellType.SingleFileSeries)
            {
                ds.Load(data.FileNames[0], DicomDataSetLoadFlags.None);
                e.Frame = ds.GetImage(null, e.FrameIndex, 0, RasterByteOrder.Gray, _dicomGetImageFlags);
            }
            else
            {
                ds.Load(data.FileNames[e.FrameIndex], DicomDataSetLoadFlags.None);
                e.Frame = ds.GetImage(null, data.FrameIndex - 1, 0, RasterByteOrder.Gray, _dicomGetImageFlags);
            }

            ds.DeleteImage(null, 0, 1);
            ds.Dispose();
        }

        void cell_Data3DFrameRequested(object sender, MedicalViewer3DFrameRequestedEventArgs e)
        {
            MedicalViewerMultiCell cell = (MedicalViewerMultiCell)sender;
            CellData data = (CellData)cell.Tag;

            using (RasterCodecs codecs = new RasterCodecs())
            {
                if (data.CellType == ViewerCellType.SingleFileSeries)
                {
                    DicomDataSet ds = new DicomDataSet();
                    ds.Load(data.FileNames[0], DicomDataSetLoadFlags.None);
                    e.Image = ds.GetImage(null, e.ImageIndex, 0, RasterByteOrder.Gray, _dicomGetImageFlags);
                    ds.Dispose();
                }
                else
                {
                    DicomDataSet ds = new DicomDataSet();
                    ds.Load(data.FileNames[e.ImageIndex], DicomDataSetLoadFlags.None);
                    e.Image = ds.GetImage(null, data.FrameIndex - 1, 0, RasterByteOrder.Gray, _dicomGetImageFlags);
                    ds.Dispose();
                }
            }
        }

        void AddBasicActionsFor2DCell(MedicalViewerBaseCell cell)
        {
            cell.AddAction(MedicalViewerActionType.Scale);
            cell.AddAction(MedicalViewerActionType.Offset);
            cell.AddAction(MedicalViewerActionType.Stack);
            cell.AddAction(MedicalViewerActionType.MagnifyGlass);
            cell.AddAction(MedicalViewerActionType.WindowLevel);
            if (cell.CanExecuteAction(MedicalViewerActionType.Alpha))
                cell.AddAction(MedicalViewerActionType.Alpha);
            cell.AddAction(MedicalViewerActionType.ProbeTool);
        }

        void cell_DerivativeGenerated(object sender, MedicalViewerDerivativeGeneratedEventArgs e)
        {
            e.DerivativeCell.SetTag(0, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, "MIP Slab");
            e.DerivativeCell.Tag = new CellData(ViewerCellType.Derivate);
            e.DerivativeCell.ReferenceLine.Enabled = _showReferenceLine;
            e.DerivativeCell.ShowCellBoundaries = _showReferenceBoundaries;
            e.DerivativeCell.ReferenceLine.ShowFirstAndLast = _showFirstAndLastReferenceLines;

            AddBasicActionsFor2DCell(e.DerivativeCell);

            e.DerivativeCell.ShowCellScroll = _menuShowScrollBar.Checked;
            e.DerivativeCell.SetScaleMode(MedicalViewerScaleMode.Fit);
            e.DerivativeCell.CellMouseClick += new EventHandler<MedicalViewerCellMouseEventArgs>(_viewer_CellMouseClick);
            e.DerivativeCell.CellMouseDown += new EventHandler<MedicalViewerCellMouseEventArgs>(_viewer_CellMouseDown);
            SetCurrent2DAction(e.DerivativeCell);
            SetCurrentCheckedCellOption((MedicalViewerMultiCell)sender, e.DerivativeCell);
            e.DerivativeCell.SetTag(0, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.MPRType);
            e.DerivativeCell.SnapRulers = true;


            CellData data = (CellData)((MedicalViewerMultiCell)sender).Tag;

            SetAction(e.DerivativeCell, data.CurrentActionType, data.CurrentCheckedItem, data.CurrentCheckedRightClickItem);
        }

        void cell_Data3DRequested(object sender, MedicalViewerData3DRequestedEventArgs e)
        {
            e.Succeed = Medical3DEngine.Provide3DInformation(e);
        }

        void PrepareRightClickMenu(out ContextMenuStrip menuDest, ToolStripMenuItem menuSource)
        {
            menuDest = new ContextMenuStrip();
            ToolStripMenuItem[] contextArray = new ToolStripMenuItem[menuSource.DropDownItems.Count];
            menuSource.DropDownItems.CopyTo(contextArray, 0);
            menuDest.Items.AddRange(contextArray);
        }

        private bool IsConfigValueTrue(string setting)
        {
            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (null != config.AppSettings.Settings[setting])
                {
                    return Convert.ToBoolean(config.AppSettings.Settings[setting].Value);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;//most likely the config file was not found
            }
        }
        private void SetConfigValue(string setting, bool value)
        {
           SetConfigData(setting, value.ToString());
        }

        private void SetConfigData(string setting, string input)
        {
           System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

           if (null != config.AppSettings.Settings[setting])
              config.AppSettings.Settings[setting].Value = input;
           config.Save(ConfigurationSaveMode.Modified);
        }

        private string GetConfigData(string setting)
        {
           System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

           if (null != config.AppSettings.Settings[setting])
           {
              return config.AppSettings.Settings[setting].Value;
           }

           return "2";
        }



        private void ShowDownloadSamplesDialog()
        {
            if (IsConfigValueTrue("ShowDownloadSamplesDialog"))
            {
                ImagesDownloadDialog dialog = new ImagesDownloadDialog("Download Sample Images");
                dialog.TopMost = true;
                dialog.ShowDialog();
            }
        }

        private static object GetDicomValue(DicomDataSet ds, long tag, bool integer)
        {


            DicomElement element = ds.FindFirstElement(null, tag, false);
            if (element != null)
            {

                //string valu1e = ds.GetValue<string>(element, "0");

                string value = ds.GetConvertValue(element);
                if (!String.IsNullOrEmpty(value))
                {
                    double numericValue = double.Parse(value);

                    if (integer)
                    {
                        int integerValue = (int)numericValue;
                        return integerValue;
                    }
                    else
                        return numericValue;
                }

            }

            return null;
        }

        private void InitClass()
        {
            try
            {
                ShowDownloadSamplesDialog();
                DicomEngine.Startup();

                _viewer = new MedicalViewer(2, 2);
                _viewer.ShowSelectedReferenceLine = true;

                _viewer.AllowMultipleSelection = false;
                _viewer.DeleteCell += new EventHandler<MedicalViewerDeleteEventArgs>(MedicalViewer_DeleteCell);
                _viewer.SelectedCellsChanged += new EventHandler<MedicalViewerSelectedCellsChangedEventArgs>(_viewer_SelectedCellsChanged);

                _generatorCellIndex = -1;

                _displayPanel.Controls.Add(_viewer);

                _rightClickContextMenu = new ContextMenuStrip();
                ToolStripMenuItem[] contextArray = new ToolStripMenuItem[_cellRightClickMenu.DropDownItems.Count];
                _cellRightClickMenu.DropDownItems.CopyTo(contextArray, 0);
                _rightClickContextMenu.Items.AddRange(contextArray);

                _rightClickGeneratorContextMenu = new ContextMenuStrip();
                contextArray = new ToolStripMenuItem[_deleteGeneratorDropMenu.DropDownItems.Count];
                _deleteGeneratorDropMenu.DropDownItems.CopyTo(contextArray, 0);
                _rightClickGeneratorContextMenu.Items.AddRange(contextArray);

                _currentSelectedMenuItem = _menu2DCell;
                _currentSelectedMenuItem.Checked = true;

                _MPRMode = false;
                _actionType = MedicalViewerActionType.WindowLevel;
                _menuActionWindowLevel.Checked = true;
                _rightClickWindowLevel.Checked = true;
                oldMeshColor = Color.FromArgb((int)(255 * 0.8), 128, (int)(255 * 0.8));
                AlwaysInterpolate = true;
                Show();


                // open the DICOMDIR dialog
                _menuItemFileLoadDICOMDIR_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        void SetCurrentCheckedCellOption(MedicalViewerMultiCell multiCell, MedicalViewerCell cell)
        {
            if (multiCell.GetActionButton(MedicalViewerActionType.Alpha) == MedicalViewerMouseButtons.Left)
                SetAction(cell, MedicalViewerActionType.Alpha, _menuActionAlpha, _rightClickAlpha);
            else if (multiCell.GetActionButton(MedicalViewerActionType.Scale) == MedicalViewerMouseButtons.Left)
                SetAction(cell, MedicalViewerActionType.Scale, _menuActionScale, _rightClickScale);
            else if (multiCell.GetActionButton(MedicalViewerActionType.MagnifyGlass) == MedicalViewerMouseButtons.Left)
                SetAction(cell, MedicalViewerActionType.MagnifyGlass, _menuActionMagnify, _rightClickMagnify);
            else if (multiCell.GetActionButton(MedicalViewerActionType.Offset) == MedicalViewerMouseButtons.Left)
                SetAction(cell, MedicalViewerActionType.Offset, _menuActionPan, _rightClickPan);
        }


        ToolStripMenuItem GetCurrentCheckedCellOption(int cellIndex)
        {
            Control control = _viewer.Cells[cellIndex];

            if (control is Medical3DControl)
            {
                Medical3DControl control3D = (Medical3DControl)_viewer.Cells[cellIndex];

                _menuInvert.Checked = control3D.ObjectsContainer.Inverted;
                switch (control3D.ObjectsContainer.VolumeType)
                {
                    case Medical3DVolumeType.SSD:
                        return _menuVolumeSSD;
                    case Medical3DVolumeType.VRT:
                        return _menuVolumeVRT;
                    case Medical3DVolumeType.MPR:
                        return _menuVolumeMPR;
                    case Medical3DVolumeType.MIP:
                        return _menuVolumeMIP;
                    case Medical3DVolumeType.MINIP:
                        return _menuVolumeMinIP;
                }
            }

            if (control is MedicalViewerMultiCell)
            {
                MedicalViewerMultiCell cell = (MedicalViewerMultiCell)_viewer.Cells[cellIndex];
                if (cell.ReferenceLine.DoubleCutLines.Count > 0)
                {
                    return _menuDoubleCutPlane2DCell;
                }
                else if (cell.ReferenceLine.CutLines.Count > 0)
                {
                    return _menuCutPlane2DCell;
                }
                else
                    return _menu2DCell;
            }
            return _menu2DCell;
        }

        void UncheckAllActionMenu()
        {
            UncheckThePerviousMenuItem(_menuActionWindowLevel);
            UncheckThePerviousMenuItem(_rightClickWindowLevel);
        }

        void _viewer_SelectedCellsChanged(object sender, MedicalViewerSelectedCellsChangedEventArgs e)
        {
            MedicalViewerBaseCell cell = GetFirstSelectedControl();
            if (cell != null)
            {
                if ((cell is MedicalViewerMultiCell) || (cell is MedicalViewerCell))
                {
                    MedicalViewerCell multiCell = (MedicalViewerCell)cell;
                    _showReferenceLine = multiCell.ReferenceLine.Enabled;
                    _menuShowReferenceLine.Checked = _showReferenceLine;
                    _showReferenceBoundaries = multiCell.ShowCellBoundaries;
                    _showFirstAndLastReferenceLines = multiCell.ReferenceLine.ShowFirstAndLast;
                    _menuShowReferenceBoundaries.Checked = _showReferenceBoundaries;
                    _menuShowScrollBar.Checked = multiCell.ShowCellScroll;
                    _menuInvert.Checked = false;
                }
                else if (cell is Medical3DControl)
                {
                    Medical3DControl cell3D = (Medical3DControl)cell;
                    _menuInvert.Checked = cell3D.ObjectsContainer.Inverted;
                }

                _currentSelectedMenuItem.Checked = false;
                _currentSelectedMenuItem = GetCurrentCheckedCellOption(e.SelectedCellsIndexes[0]);
                _currentSelectedMenuItem.Checked = true;
            }
        }

        void _viewer_PlaneCutLineClicked(object sender, MedicalViewerPlaneCutLineEventArgs e)
        {
            if (e.Button == MedicalViewerMouseButtons.Right)
            {
                _generatorCellIndex = e.CellIndex;
                _planeCutLineClicked = true;
                _mousePoint.X = e.X + _viewer.Cells[e.CellIndex].Location.X;
                _mousePoint.Y = e.Y + _viewer.Cells[e.CellIndex].Location.Y;
                _rightClickGeneratorContextMenu.Show(_viewer, _mousePoint);
            }
        }

        void _viewer_CellMouseDown(object sender, MedicalViewerCellMouseEventArgs e)
        {
            _currentMousePoint.X = e.X;
            _currentMousePoint.Y = e.Y;
        }

        void _viewer_CellMouseClick(object sender, MedicalViewerCellMouseEventArgs e)
        {
            if (_polygonHandleClicked)
                return;
            // if the plane cutline event is fired, don't show the right click menu.
            if (_planeCutLineClicked)
            {
                _planeCutLineClicked = false;
                return;
            }

            if (!((_currentMousePoint.X == e.X) && (_currentMousePoint.Y == e.Y)))
                return;


            if (e.Button == MouseButtons.Right)
            {
                _mousePoint.X = e.X + _viewer.Cells[e.CellIndex].Location.X;
                _mousePoint.Y = e.Y + _viewer.Cells[e.CellIndex].Location.Y;
                _generatorCellIndex = e.CellIndex;

                _rightClickContextMenu.Show(_viewer, _mousePoint);
                EnableRightClickMenuItems(sender);
            }
        }


        // Detect whehter the cell has an image.
        private bool Is2DCell(Control cell)
        {
            return ((cell is MedicalViewerCell) || (cell is MedicalViewerMultiCell));
        }

        MedicalViewerCell SearchForTheGeneratorCellAndReturnTheOtherCell(MedicalViewerCell cell)
        {
            int index;
            for (index = 0; index < _viewer.Cells.Count; index++)
            {
                if (_viewer.Cells[index] is MedicalViewerMultiCell)
                {
                    MedicalViewerMultiCell multiCell = (MedicalViewerMultiCell)_viewer.Cells[index];

                    int cutPlaneIndex;
                    for (cutPlaneIndex = 0; cutPlaneIndex < multiCell.ReferenceLine.DoubleCutLines.Count; cutPlaneIndex++)
                    {
                        if (multiCell.ReferenceLine.DoubleCutLines[cutPlaneIndex].FirstDerivativeCell == cell)
                        {
                            multiCell.Selected = true;
                            return multiCell.ReferenceLine.DoubleCutLines[cutPlaneIndex].SecondDerivativeCell;
                        }

                        if (multiCell.ReferenceLine.DoubleCutLines[cutPlaneIndex].SecondDerivativeCell == cell)
                        {
                            multiCell.Selected = true;
                            return multiCell.ReferenceLine.DoubleCutLines[cutPlaneIndex].FirstDerivativeCell;
                        }
                    }
                }
            }
            return null;
        }

        void DeleteAllDerivativeCells(MedicalViewerMultiCell cell)
        {
            DeleteAllMPRPolygonFromCell(cell);

            int index;
            List<MedicalViewerCell> list = new List<MedicalViewerCell>();

            for (index = 0; index < cell.ReferenceLine.CutLines.Count; index++)
            {
                list.Add(cell.ReferenceLine.CutLines[index].DerivativeCell);
            }

            for (index = 0; index < cell.ReferenceLine.DoubleCutLines.Count; index++)
            {
                list.Add(cell.ReferenceLine.DoubleCutLines[index].FirstDerivativeCell);
                list.Add(cell.ReferenceLine.DoubleCutLines[index].SecondDerivativeCell);
            }

            // Delete the cell itself.
            cell.Dispose();

            // Delete all the derivative cells.
            for (index = 0; index < list.Count; index++)
                list[index].Dispose();
        }

        void MedicalViewer_DeleteCell(object sender, MedicalViewerDeleteEventArgs e)
        {
            // don't delete the cell on the MPR mode.
            if (_MPRMode)
                e.Delete = false;
            else
            {
                for (int i = 0; i < e.CellIndexes.Length; i++)
                {
                    if (_viewer.Cells[e.CellIndexes[i]] is Medical3DControl)
                    {
                        Medical3DControl control3D = (Medical3DControl)(_viewer.Cells[e.CellIndexes[i]]);

                        if (((CellData)control3D.Tag).Cell != null)
                        {
                            MedicalViewerBaseCell baseCell = (MedicalViewerBaseCell)((CellData)control3D.Tag).Cell;
                            baseCell.Dispose();
                        }
                    }
                    else
                    {
                        e.Delete = false;
                        if (_viewer.Cells[e.CellIndexes[0]] is MedicalViewerPanoramicCell)
                        {
                            MedicalViewerPanoramicCell panoramicCell = (MedicalViewerPanoramicCell)_viewer.Cells[e.CellIndexes[0]];
                            if (panoramicCell.Polygon != null)
                            {
                                if (panoramicCell.Polygon.Parent != null)
                                    DeleteAllMPRPolygonFromCell((MedicalViewerMultiCell)panoramicCell.Polygon.Parent);
                            }
                            else
                                e.Delete = true;
                        }
                        else
                        {
                            if (_viewer.Cells[e.CellIndexes[0]] is MedicalViewerMultiCell)
                                DeleteAllDerivativeCells((MedicalViewerMultiCell)_viewer.Cells[e.CellIndexes[0]]);
                            else if (_viewer.Cells[e.CellIndexes[0]] is MedicalViewerCell)
                            {
                                MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[e.CellIndexes[0]];
                                MedicalViewerCell theOtherCell = SearchForTheGeneratorCellAndReturnTheOtherCell((MedicalViewerCell)_viewer.Cells[e.CellIndexes[0]]);

                                _currentSelectedMenuItem.Checked = false;
                                _currentSelectedMenuItem = _menu2DCell;
                                _currentSelectedMenuItem.Checked = true;

                                if (theOtherCell != null)
                                    theOtherCell.Dispose();
                                cell.Dispose();
                            }
                        }
                    }
                }
            }
        }

        private void _menuItemFileLoadDICOMDIR_Click(object sender, EventArgs e)
        {
            // if there is an already instance of the series browser, then don't create the a new one. and just use the already created one
            // You will notice that all the data (series and study) are still stored.
            if (seriesBrowserDialog == null)
            {
                seriesBrowserDialog = new SeriesBrowser();
                seriesBrowserDialog.LoadAs3D = true;
                // this will be fired every time the browser loads a new frame.
                seriesBrowserDialog.FrameLoaded += new FrameLoadedEventHandler(seriesBrowserDialog_FrameLoaded);
            }
            seriesBrowserDialog.ShowDialog();
        }

        void seriesBrowserDialog_FrameLoaded(object sender, FrameLoadedEventArgs e)
        {
            try
            {
                if (e.State == FrameLoadedState.StartLoading)
                {
                    _cellData = new CellData();
                    _cellData.FileNames = new string[e.PageCount];
                    _cellData.InstanceNumbers = new int[e.PageCount];
                    _cellData.ImagePositions = new Point3D[e.PageCount];
                    _counter = 0;
                }

                if (e.State == FrameLoadedState.FrameLoaded)
                {
                    _cellData.InstanceNumbers[_counter] = e.InstanceNumber;
                    _cellData.FileNames[_counter] = e.ImagePath;
                    _cellData.ImagePositions[_counter] = e.ImagePosition;
                    _counter++;
                }

                if (e.State == FrameLoadedState.EndLoading)
                {
                    List<Point3D> a = new List<Point3D>(); ;
                    a.Add(e.ImagePosition);

                    List<float[]> b = new List<float[]>(); ;
                    b.Add(e.ImageOrientation);


                    LoadImagesToMedicalViewer(e.SeriesInformation, e.ImageOrientation, seriesBrowserDialog.LoadAs3D);
                }
            }
            catch (Exception)
            {
                e.Cancel = true;
            }
        }

        private bool LoadImagesToMedicalViewer(SeriesInformation seriesInformation, float[] imageOrientation, bool loadAs3D)
        {
            seriesBrowserDialog.DisableLoading = true;

            CellData data = _cellData;

            MedicalViewerMultiCell cell = new MedicalViewerMultiCell(null, false, 1, 1);
            cell.Tag = data;

            cell.FitImageToCell = false;
            InitializeCell(cell, seriesInformation);

            AddCellToViewer(cell);

            cell.Focus();

            _currentSelectedMenuItem.Checked = false;
            _currentSelectedMenuItem = _menu2DCell;
            _currentSelectedMenuItem.Checked = true;

            SetCellTags(cell, seriesInformation);
            cell.FitImageToCell = false;
            cell.ReferenceLine.Enabled = _showReferenceLine;
            cell.ShowCellBoundaries = _showReferenceBoundaries;
            cell.ReferenceLine.ShowFirstAndLast = _showFirstAndLastReferenceLines;

            cell.PixelSpacing = new Point2D((float)seriesInformation.VoxelSpacing.X, (float)seriesInformation.VoxelSpacing.Y);

            cell.FrameOfReferenceUID = seriesInformation.FrameOfReferenceUID;
            if (imageOrientation != null)
            {
                if (imageOrientation.Length != 0)
                    cell.ImageOrientation = imageOrientation;
            }
            else
            {
                _cellData.CellType = ViewerCellType.Other;
            }
           ((CellData)cell.Tag).FrameIndex = (seriesInformation.DicomFrameNumber + 1);


            EnableCellLowMemoryUsage(cell);
            SetFrameInformation(cell);
            cell.SetScaleMode(MedicalViewerScaleMode.Fit);

            if (_cellData.CellType == ViewerCellType.Cell2D && cell.VirtualImage.Count >= 3)
            {
                if (loadAs3D)
                {
                    Medical3DControl control3D = ConvertTo3D(cell);
                    if (_MPRMode)
                    {
                        control3D.AxialFrame = (MedicalViewerMPRCell)_viewer.Cells[1];
                        control3D.SagittalFrame = (MedicalViewerMPRCell)_viewer.Cells[2];
                        control3D.CoronalFrame = (MedicalViewerMPRCell)_viewer.Cells[3];
                    }
                }
            }
            else
            {
                if (_MPRMode)
                {
                    _menu2DCell_Click(null, null);
                }
            }

            seriesBrowserDialog.DisableLoading = false;

            return true;
        }

        void SetFrameInformation(MedicalViewerMultiCell cell)
        {
            int index;
            CellData data = (CellData)cell.Tag;
            int count = data.FileNames.Length;

            for (index = 0; index < count; index++)
            {
                cell.SetTag(index, 5, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, "Im: " + data.InstanceNumbers[index].ToString() + " / " + count.ToString());
                cell.SetImagePosition(index, data.ImagePositions[index], index == (count - 1));
            }
        }

        private void EnableCellLowMemoryUsage(MedicalViewerMultiCell cell)
        {
            CellData cellData = ((CellData)cell.Tag);
            int count = cellData.FileNames.Length;
            int index;
            CellData data = (CellData)cell.Tag;
            MedicalViewerImageInformation[] imagesInformation = new MedicalViewerImageInformation[count];
            using (RasterCodecs codecs = new RasterCodecs())
            {
                CounterDialog counter = new CounterDialog(count, 1, this);
                counter.LoadingObject = true;
                counter.LoadingText = "Preparing Series Data";
                counter.Show();
                counter.Update();

                for (index = 0; index < count; index++)
                {
                    using (CodecsImageInfo codecsInformation = codecs.GetInformation(cellData.FileNames[index], true, cellData.FrameIndex))
                    {
                        counter.Percent = (index * 100 / (Math.Max(count - 1, 1)));
                        if ((index % 5) == 0)
                            Application.DoEvents();
                        imagesInformation[index] = new MedicalViewerImageInformation(codecsInformation.XResolution, codecsInformation.YResolution, codecsInformation.Width, codecsInformation.Height);
                    }
                }

                counter.Close();
                counter.Dispose();

                cell.FramesRequested += new EventHandler<MedicalViewerRequestedFramesInformationEventArgs>(cell_FramesRequested);
                cell.EnableLowMemoryUsage(2, cellData.FileNames.Length, imagesInformation);
            }
        }

        RasterImage LoadRequestedFrameFileName(MedicalViewerRequestedFramesInformationEventArgs e, RasterCodecs codecs, CellData data, int index)
        {
            DicomDataSet ds = new DicomDataSet();
            RasterImage image = null;
            if (data.CellType != ViewerCellType.SingleFileSeries)
            {
                ds.Load(data.FileNames[index], DicomDataSetLoadFlags.None);
                image = ds.GetImage(null, data.FrameIndex - 1, 0, RasterByteOrder.Gray, _dicomGetImageFlags);

            }
            else
            {
                int outputIndex = index;
                if (data.Indexing != null)
                    outputIndex = data.Indexing[index];
                image = GetImage(ds, data.FileNames[0], outputIndex);
            }

            ds.Dispose();
            return image;
        }

        void cell_FramesRequested(object sender, MedicalViewerRequestedFramesInformationEventArgs e)
        {
            MedicalViewerMultiCell cell = (MedicalViewerMultiCell)sender;
            CellData data = (CellData)cell.Tag;

            MedicalViewer viewer = (MedicalViewer)cell.Parent;
            if (data == null)
                return;

            using (RasterCodecs codecs = new RasterCodecs())
            {
                int i;

                if (e.RequestedFramesIndexes.Length > 0)
                {
                    using (RasterImage image = LoadRequestedFrameFileName(e, codecs, data, e.RequestedFramesIndexes[0]))
                    {
                        for (i = 1; i < e.RequestedFramesIndexes.Length; i++)
                        {
                            image.AddPage(LoadRequestedFrameFileName(e, codecs, data, e.RequestedFramesIndexes[i]));
                        }


                        cell.SetRequestedImage(image, e.RequestedFramesIndexes, MedicalViewerSetImageOptions.Insert);
                    }
                }
            }
        }

        private void FillCellTag(MedicalViewerMultiCell cell)
        {
        }


        private void SetCellTags(MedicalViewerMultiCell cell, SeriesInformation seriesInformation)
        {
            cell.SetTag(0, MedicalViewerTagAlignment.LeftCenter, MedicalViewerTagType.LeftOrientation);
            cell.SetTag(0, MedicalViewerTagAlignment.RightCenter, MedicalViewerTagType.RightOrientation);
            cell.SetTag(0, MedicalViewerTagAlignment.TopCenter, MedicalViewerTagType.TopOrientation);
            cell.SetTag(0, MedicalViewerTagAlignment.BottomCenter, MedicalViewerTagType.BottomOrientation);

            cell.SetTag(2, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, seriesInformation.InstitutionName);
            cell.SetTag(3, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, seriesInformation.PatientName);
            cell.SetTag(4, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, seriesInformation.PatientAge);
            cell.SetTag(5, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, seriesInformation.PatientBirthDate);
            cell.SetTag(6, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, seriesInformation.PatientSex);
            cell.SetTag(7, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, seriesInformation.PatientID);

            cell.SetTag(9, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, seriesInformation.AccessionNumber);
            cell.SetTag(8, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, seriesInformation.StudyDate);
            cell.SetTag(7, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, seriesInformation.AcquisitionTime);
            cell.SetTag(6, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, seriesInformation.SeriesTime);
            cell.SetTag(5, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.FieldOfView);

            cell.SetTag(2, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, seriesInformation.AccessionNumber);
            cell.SetTag(3, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, seriesInformation.StudyDate);
            cell.SetTag(4, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, seriesInformation.AcquisitionTime);
            cell.SetTag(7, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Frame);
            if (seriesInformation.EchoNumber != -1)
                cell.SetTag(8, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, "Echo: " + seriesInformation.EchoNumber.ToString());


            cell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData);

            cell.SetTag(4, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.Alpha);

            cell.SetTag(6, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Scale);
        }

        private void _menuVolumeMPR_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();

            if (control3D == null)
            {
                MedicalViewerMultiCell cell = GetFirstSelectedMultiCell();
                if (cell == null)
                    return;

                control3D = ConvertTo3D(cell);

                if (control3D == null)
                    return;
            }

            control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.MPR;

            CheckMenu(_menuVolumeMPR);

        }

        private void CheckMenu(ToolStripMenuItem selectedMenuItem)
        {
            _currentSelectedMenuItem.Checked = false;
            selectedMenuItem.Checked = true;
            _currentSelectedMenuItem = selectedMenuItem;
        }



        private void _menuVolumeVRT_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();

            if (control3D == null)
            {
                MedicalViewerMultiCell cell = GetFirstSelectedMultiCell();
                if (cell == null)
                    return;

                control3D = ConvertTo3D(cell);

                if (control3D == null)
                    return;
            }

            control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.VRT;


            CellData data = (CellData)control3D.Tag;
            if (data.ColorMapIndex != -1)
            {
                Medical3DObject object3d = control3D.ObjectsContainer.Objects[0];
                object3d.ColorMap = _cellData.ColorMap;
                object3d.Palette = _cellData.Palette;
            }



            CheckMenu(_menuVolumeVRT);
        }

        private void _menuVolumeMIP_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();

            if (control3D == null)
            {
                MedicalViewerMultiCell cell = GetFirstSelectedMultiCell();
                if (cell == null)
                    return;

                control3D = ConvertTo3D(cell);

                if (control3D == null)
                    return;
            }

            control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.MIP;

            CheckMenu(_menuVolumeMIP);
        }

        MedicalViewerMultiCell GetFirstSelectedMultiCell()
        {
            foreach (Control control in _viewer.Cells)
            {
                if (control is MedicalViewerMultiCell)
                {
                    MedicalViewerMultiCell cell = (MedicalViewerMultiCell)control;

                    if (cell.Selected)
                        return (MedicalViewerMultiCell)control;
                }
            }
            return null;
        }


        MedicalViewerCell GetFirstSelectedCell()
        {
            foreach (Control control in _viewer.Cells)
            {
                if (control is MedicalViewerCell)
                {
                    MedicalViewerCell cell = (MedicalViewerCell)control;

                    if (cell.Selected)
                        return (MedicalViewerCell)control;
                }
            }
            return null;
        }


        Medical3DControl GetFirstSelected3DControl()
        {
            foreach (Control control in _viewer.Cells)
            {
                if (control is Medical3DControl)
                {
                    Medical3DControl ctrl3D = (Medical3DControl)control;

                    if (ctrl3D.Selected)
                        return (Medical3DControl)control;
                }
            }
            return null;
        }

        private void _menuInvert_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();
            if (control3D == null)
                return;

            control3D.ObjectsContainer.Inverted = !control3D.ObjectsContainer.Inverted;
            _menuInvert.Checked = !_menuInvert.Checked;
        }

        private void _menuProperties_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();

            if (control3D == null)
                return;


            (new ContainerProperties(control3D, _viewer, control3D.ObjectsContainer)).ShowDialog();
        }

        private void _mainPanel_SizeChanged(object sender, EventArgs e)
        {
            if (_viewer != null)
            {
                if (_displayPanel != null)
                {
                    _displayPanel.Left = 0;
                    _displayPanel.Top = 0;
                    _displayPanel.Width = _mainPanel.Width;
                    _displayPanel.Height = _mainPanel.Height;
                }

                _viewer.SetBounds(_displayPanel.Left, _displayPanel.Top, _displayPanel.Width, _displayPanel.Height);
            }
        }

        private void EnableCellLowMemoryUsage(MedicalViewerMultiCell cell, string fileName, CodecsImageInfo info)
        {
            int index;
            int count = info.TotalPages;
            CellData cellData = ((CellData)cell.Tag);

            MedicalViewerImageInformation[] imagesInformation = new MedicalViewerImageInformation[count];

            using (RasterCodecs codecs = new RasterCodecs())
            {
                using (CodecsImageInfo codecsInformation = codecs.GetInformation(fileName, true, cellData.FrameIndex))
                {

                    for (index = 0; index < count; index++)
                    {
                        imagesInformation[index] = new MedicalViewerImageInformation(codecsInformation.XResolution, codecsInformation.YResolution, codecsInformation.Width, codecsInformation.Height);
                    }

                    cell.FramesRequested += new EventHandler<MedicalViewerRequestedFramesInformationEventArgs>(cell_FramesRequested);
                    cell.EnableLowMemoryUsage(2, count, imagesInformation);
                }
            }
        }

        string _openInitialPath = string.Empty;
        private void GetFileName(out string fileName)
        {
            RasterCodecs codecs = new RasterCodecs();
            ImageFileLoader loader = new ImageFileLoader();
            fileName = "";
            loader.OpenDialogInitialPath = _openInitialPath;

            try
            {
                loader.ShowLoadPagesDialog = false;
                if (loader.Load(this, codecs, false) != 0)
                {
                    _openInitialPath = Path.GetDirectoryName(loader.FileName);
                    fileName = "";
                    if (loader.LastPage != 0)
                    {
                        counter = new CounterDialog(loader.LastPage == -1 ? -1 : loader.LastPage - loader.FirstPage + 1, 0, this);
                        counter.FirstPage = loader.FirstPage;

                        fileName = loader.FileName;

                        if (fileName.IndexOf("DICOMDIR") != -1)
                        {
                            MessageBox.Show("You cannot load the DICOMDIR from here, use Load DICOMDIR instead", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            fileName = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messager.ShowFileOpenError(this, loader.FileName, ex);
            }
        }

        void AddNewDicomDirectoryTab(bool dicomDirectroyAvailable)
        {
            return;
        }


        // This method returns the specified DICOM tag in a string format.
        string GetDicomTag(DicomDataSet ds, long tag)
        {
            DicomElement patientElement = ds.FindFirstElement(null,
                                                 tag,
                                                 true);

            if (patientElement != null)
                return ds.GetConvertValue(patientElement);

            return null;
        }


        private RasterImage GetImage(DicomDataSet dicomDataSet, string imagePath, int index)
        {
            try
            {
                dicomDataSet.Load(imagePath, DicomDataSetLoadFlags.None);
                return dicomDataSet.GetImage(null, SeriesBrowser.GetDicomFrameNumber(dicomDataSet), 0, RasterByteOrder.Gray, _dicomGetImageFlags);

            }
            catch (Exception)
            {
                RasterCodecs _codecs = new RasterCodecs();
                if (index < 0)
                    index = 0;

                return _codecs.Load(imagePath, 0, CodecsLoadByteOrder.BgrOrGrayOrRomm, index + 1, index + 1);
            }
        }

        // Load the DICOM file
        private SeriesInformation LoadDICOM(DicomDataSet dicomDataSet, string imagePath)
        {
            try
            {
                SeriesInformation seriesInformation = new SeriesInformation();

                seriesInformation.Image = GetImage(dicomDataSet, imagePath, SeriesBrowser.GetDicomFrameNumber(dicomDataSet));
                if (seriesInformation.Image == null)
                {
                    return null;
                }

                double[] orientation;
                double[] doubleArray;

                DicomElement patientElement = dicomDataSet.FindFirstElement(null,
                                                                 DicomTag.PixelSpacing,
                                                                 true);

                if (patientElement != null)
                {
                    doubleArray = dicomDataSet.GetDoubleValue(patientElement, 0, 1);
                    seriesInformation.VoxelSpacing = new Point3D((float)doubleArray[0], (float)doubleArray[0], 0);
                }

                patientElement = dicomDataSet.FindFirstElement(null,
                                                     DicomTag.ImageOrientationPatient,
                                                     true);

                if (patientElement != null)
                {
                    orientation = dicomDataSet.GetDoubleValue(patientElement, 0, 6);
                    seriesInformation.ImageOrientation = orientation;
                }

                patientElement = dicomDataSet.FindFirstElement(null,
                                                     DicomTag.ImagePositionPatient,
                                                     true);

                if (patientElement != null)
                {
                    doubleArray = dicomDataSet.GetDoubleValue(patientElement, 0, 3);
                    seriesInformation.ImagePosition = Point3D.FromDoubleArray(doubleArray);
                }

                patientElement = dicomDataSet.FindFirstElement(null,
                                                     DicomTag.FrameOfReferenceUID,
                                                     true);

                if (patientElement != null)
                {
                    string str = dicomDataSet.GetConvertValue(patientElement);
                    seriesInformation.FrameOfReferenceUID = str;
                }

                seriesInformation.InstitutionName = GetDicomTag(dicomDataSet, DicomTag.InstitutionName);
                seriesInformation.PatientName = GetDicomTag(dicomDataSet, DicomTag.PatientName);
                seriesInformation.PatientAge = GetDicomTag(dicomDataSet, DicomTag.PatientAge);
                seriesInformation.PatientBirthDate = GetDicomTag(dicomDataSet, DicomTag.PatientBirthDate);
                seriesInformation.PatientSex = GetDicomTag(dicomDataSet, DicomTag.PatientSex);
                seriesInformation.PatientID = GetDicomTag(dicomDataSet, DicomTag.PatientID);
                seriesInformation.AccessionNumber = GetDicomTag(dicomDataSet, DicomTag.AccessionNumber);
                seriesInformation.StudyDate = GetDicomTag(dicomDataSet, DicomTag.StudyDate);
                seriesInformation.AcquisitionTime = GetDicomTag(dicomDataSet, DicomTag.AcquisitionTime);
                seriesInformation.SeriesTime = GetDicomTag(dicomDataSet, DicomTag.SeriesTime);
                seriesInformation.StationName = GetDicomTag(dicomDataSet, DicomTag.StationName);
                seriesInformation.StudyID = GetDicomTag(dicomDataSet, DicomTag.StudyID);
                seriesInformation.SeriesDescription = GetDicomTag(dicomDataSet, DicomTag.SeriesDescription);
                seriesInformation.ImageComments = GetDicomTag(dicomDataSet, DicomTag.ImageComments);
                seriesInformation.PhotometricInterpretation = GetDicomTag(dicomDataSet, DicomTag.PhotometricInterpretation);

                return seriesInformation;
            }
            catch (System.Exception ex)
            {
                Messager.Show(this, ex, MessageBoxIcon.Exclamation);
            }

            return null;
        }

        private float[] SetDICOMInformation(DicomDataSet dicomDataSet, MedicalViewerMultiCell cell)
        {
            int index = 0;
            float[] orientation = null;

            CellData cellData = (CellData)cell.Tag;

            cell.SuspendCalculation();

            DicomElement sharedElement = dicomDataSet.FindFirstElement(null,
                                                 DicomTag.SharedFunctionalGroupsSequence,
                                                 true);

            if (sharedElement != null)
            {
                DicomElement sharedItemElement = dicomDataSet.FindFirstElement(sharedElement,
                                                     DicomTag.Item,
                                                     false);

                if (sharedItemElement != null)
                {
                    DicomElement pixelElement = dicomDataSet.FindFirstElement(sharedItemElement,
                                                         DicomTag.PixelMeasuresSequence,
                                                         false);

                    if (pixelElement != null)
                    {
                        sharedItemElement = dicomDataSet.FindFirstElement(pixelElement,
                                                             DicomTag.Item,
                                                             false);

                        if (sharedItemElement != null)
                        {
                            DicomElement pixelSpacing = dicomDataSet.FindFirstElement(sharedItemElement,
                                                              DicomTag.PixelSpacing,
                                                              false);

                            if (pixelSpacing != null)
                            {
                                double[] doubleArray = dicomDataSet.GetDoubleValue(pixelSpacing, 0, 2);
                                cell.PixelSpacing = new Point2D(doubleArray[0], doubleArray[1]);
                            }
                        }

                    }

                }

            }

            DicomElement perFrameElement = dicomDataSet.FindFirstElement(null, DicomTag.PerFrameFunctionalGroupsSequence, true);
            DicomElement firstItem;
            DicomElement itemElement;

            if (perFrameElement != null)
            {
                perFrameElement = dicomDataSet.GetChildElement(perFrameElement, true);

                firstItem = dicomDataSet.FindFirstElement(perFrameElement, DicomTag.Item, true);

                itemElement = dicomDataSet.GetChildElement(firstItem, true);

                itemElement = dicomDataSet.FindFirstElement(itemElement, DicomTag.PlaneOrientationSequence, true);

                itemElement = dicomDataSet.GetChildElement(itemElement, true);

                itemElement = dicomDataSet.FindFirstElement(itemElement, DicomTag.Item, true);

                itemElement = dicomDataSet.GetChildElement(itemElement, true);

                itemElement = dicomDataSet.FindFirstElement(itemElement, DicomTag.ImageOrientationPatient, true);

                double[] doubleArray = dicomDataSet.GetDoubleValue(itemElement, 0, 6);


                orientation = new float[] { (float)doubleArray[0], (float)doubleArray[1], (float)doubleArray[2], (float)doubleArray[3], (float)doubleArray[4], (float)doubleArray[5] };
            }
            DicomElement patientElement = dicomDataSet.FindFirstElement(null, DicomTag.PerFrameFunctionalGroupsSequence, true);

            patientElement = dicomDataSet.GetChildElement(patientElement, true);

            firstItem = dicomDataSet.FindFirstElement(patientElement, DicomTag.Item, true);


            while (firstItem != null)
            {
                itemElement = dicomDataSet.GetChildElement(firstItem, true);

                itemElement = dicomDataSet.FindFirstElement(itemElement, DicomTag.PlanePositionSequence, true);

                itemElement = dicomDataSet.GetChildElement(itemElement, true);

                itemElement = dicomDataSet.FindFirstElement(itemElement, DicomTag.Item, true);

                itemElement = dicomDataSet.GetChildElement(itemElement, true);

                itemElement = dicomDataSet.FindFirstElement(itemElement, DicomTag.ImagePositionPatient, true);

                if (itemElement != null)
                {
                    double[] doubleArray = dicomDataSet.GetDoubleValue(itemElement, 0, 3);

                    cellData.ImagePositions[index] = Point3D.FromDoubleArray(doubleArray);

                    cell.SetImagePosition(index, cellData.ImagePositions[index], false);

                    index++;
                }



                firstItem = dicomDataSet.GetNextElement(firstItem, true, true);



            }
            cell.ResumeCalculation();

            return orientation;
        }


        private void _menuItemFileLoadDICOM_Click(object sender, EventArgs e)
        {
            string imagePath;
            RasterCodecs codecs = new RasterCodecs();
            GetFileName(out imagePath);

            // Insert new cell if the user has selected an image.
            if (imagePath != "")
            {
                DicomDataSet dicomDataSet = new DicomDataSet();
                dicomDataSet.Load(imagePath, DicomDataSetLoadFlags.None);

                SeriesInformation seriesInformation = LoadDICOM(dicomDataSet, imagePath);
                if (seriesInformation == null)
                    return;
                RasterImage image = seriesInformation.Image;

                if (image == null)
                {
                    return;
                }

                MedicalViewerMultiCell cell = new MedicalViewerMultiCell(null, true, 1, 1);

                CellData cellData = new CellData(ViewerCellType.SingleFileSeries);
                cellData.FileNames = new string[1];
                cellData.FileNames[0] = imagePath;
                cell.Tag = cellData;

                Cursor oldCursor = Cursor;
                Cursor = Cursors.WaitCursor;
                CodecsImageInfo info = codecs.GetInformation(imagePath, true);


                cellData.ImagePositions = new Point3D[info.TotalPages];

                EnableCellLowMemoryUsage(cell, imagePath, info);


                float[] orientation = SetDICOMInformation(dicomDataSet, cell);

                float[] floatArray = new float[] { (float)seriesInformation.ImageOrientation[0], (float)seriesInformation.ImageOrientation[1], (float)seriesInformation.ImageOrientation[2], (float)seriesInformation.ImageOrientation[3], (float)seriesInformation.ImageOrientation[4], (float)seriesInformation.ImageOrientation[5] };


                if (orientation != null)
                    cell.ImageOrientation = orientation;
                else
                    cell.ImageOrientation = floatArray;


                List<MedicalViewerImageData> list = new List<MedicalViewerImageData>();
                MedicalViewerImageData data;
                for (int index = 0; index < info.TotalPages; index++)
                {
                    data = new MedicalViewerImageData();
                    data.ImagePosition = cellData.ImagePositions[index];
                    data.ImageOrientationArray = cell.ImageOrientation;
                    data.Data = index;
                    list.Add(data);
                }

                MedicalViewerSeriesManager _seriesManager;
                _seriesManager = new MedicalViewerSeriesManager();
                _seriesManager.Sort(list);


                if (_seriesManager.Stacks.Count != 1)
                {
                    cellData.Can3D = false;
                }
                else
                {

                    int[] indexing = new int[info.TotalPages];
                    for (int index = 0; index < info.TotalPages; index++)
                    {
                        indexing[index] = (int)_seriesManager.Stacks[0].Items[index].Data;
                    }

                    cellData.Indexing = indexing;
                }




                Cursor = oldCursor;

                AddCellToViewer(cell);
                InitializeCell(cell, seriesInformation);
                SetCellTags(cell, seriesInformation);
                cell.FitImageToCell = false;
                cell.SnapRulers = true;
                cell.ReferenceLine.Enabled = _showReferenceLine;
                cell.ShowCellBoundaries = _showReferenceBoundaries;
                cell.ReferenceLine.ShowFirstAndLast = _showFirstAndLastReferenceLines;
                cell.SetScaleMode(MedicalViewerScaleMode.Fit);
                image.Dispose();

                if ((info.TotalPages >= 3) && cellData.Can3D)
                    ConvertTo3D(cell);
            }
        }

        private void _menuFile_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _menuEdit_DropDownOpening(object sender, EventArgs e)
        {
            bool enable = true;
            bool ssdEnabled = false;
            bool vrtEnabled = false;

            Medical3DControl control3D = GetFirstSelected3DControl();
            MedicalViewerMultiCell multiCell = GetFirstSelectedMultiCell();

            if (control3D == null)
                enable = false;

            if (control3D != null)
            {
                ssdEnabled = (control3D.ObjectsContainer.VolumeType == Medical3DVolumeType.SSD);
                vrtEnabled = (control3D.ObjectsContainer.VolumeType == Medical3DVolumeType.VRT);


                if (((CellData)control3D.Tag).CellType == ViewerCellType.Mesh3D)
                {
                    enable = false;
                }
            }



            _menuRemoveDensity.Enabled = enable && !ssdEnabled;

            _menuSSDMeshColor.Enabled =
            _menuSSDIsoThreshold.Enabled = ssdEnabled;

            _menuItemEditReset.Enabled =
            _menuDeleteAll.Enabled = _viewer.Cells.Count != 0;


            _editColorMap.Enabled = vrtEnabled;
        }

        private void CopyTags(MedicalViewerBaseCell destinationCell, MedicalViewerBaseCell cell, bool addWindowLevelTag)
        {
            CopyTags(destinationCell, cell, addWindowLevelTag, true);
        }


        private void CopyTags(MedicalViewerBaseCell destinationCell, MedicalViewerBaseCell cell, bool addWindowLevelTag, bool addScaleTag)
        {
            MedicalViewerTagInformation information;
            information = cell.GetTag(0, MedicalViewerTagAlignment.LeftCenter);
            if (information != null) destinationCell.SetTag(0, MedicalViewerTagAlignment.LeftCenter, information.Type);
            information = cell.GetTag(0, MedicalViewerTagAlignment.RightCenter);
            if (information != null) destinationCell.SetTag(0, MedicalViewerTagAlignment.RightCenter, information.Type);
            information = cell.GetTag(0, MedicalViewerTagAlignment.TopCenter);
            if (information != null) destinationCell.SetTag(0, MedicalViewerTagAlignment.TopCenter, information.Type);
            information = cell.GetTag(0, MedicalViewerTagAlignment.BottomCenter);
            if (information != null) destinationCell.SetTag(0, MedicalViewerTagAlignment.BottomCenter, information.Type);

            information = cell.GetTag(2, MedicalViewerTagAlignment.TopRight);
            if (information != null) destinationCell.SetTag(2, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text);
            information = cell.GetTag(3, MedicalViewerTagAlignment.TopRight);
            if (information != null) destinationCell.SetTag(3, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text);
            information = cell.GetTag(4, MedicalViewerTagAlignment.TopRight);
            if (information != null) destinationCell.SetTag(4, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text);
            information = cell.GetTag(5, MedicalViewerTagAlignment.TopRight);
            if (information != null) destinationCell.SetTag(5, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text);
            information = cell.GetTag(6, MedicalViewerTagAlignment.TopRight);
            if (information != null) destinationCell.SetTag(6, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text);
            information = cell.GetTag(7, MedicalViewerTagAlignment.TopRight);
            if (information != null) destinationCell.SetTag(7, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text);

            information = cell.GetTag(9, MedicalViewerTagAlignment.BottomRight);
            if (information != null) destinationCell.SetTag(9, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text);
            information = cell.GetTag(8, MedicalViewerTagAlignment.BottomRight);
            if (information != null) destinationCell.SetTag(8, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text);
            information = cell.GetTag(7, MedicalViewerTagAlignment.BottomRight);
            if (information != null) destinationCell.SetTag(7, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text);
            information = cell.GetTag(6, MedicalViewerTagAlignment.BottomRight);
            if (information != null) destinationCell.SetTag(6, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text);
            information = cell.GetTag(5, MedicalViewerTagAlignment.BottomRight);
            if (information != null) destinationCell.SetTag(5, MedicalViewerTagAlignment.BottomRight, information.Type);


            information = cell.GetTag(2, MedicalViewerTagAlignment.TopLeft);
            if (information != null) destinationCell.SetTag(2, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, information.Text);
            information = cell.GetTag(3, MedicalViewerTagAlignment.TopLeft);
            if (information != null) destinationCell.SetTag(3, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, information.Text);
            information = cell.GetTag(4, MedicalViewerTagAlignment.TopLeft);
            if (information != null) destinationCell.SetTag(4, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, information.Text);

            if (addWindowLevelTag)
            {
                information = cell.GetTag(2, MedicalViewerTagAlignment.BottomLeft);
                if (information != null) destinationCell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, information.Type);
            }

            if (addScaleTag)
            {
                information = cell.GetTag(6, MedicalViewerTagAlignment.TopLeft);
                if (information != null) destinationCell.SetTag(6, MedicalViewerTagAlignment.TopLeft, information.Type);

                information = cell.GetTag(7, MedicalViewerTagAlignment.TopLeft);
                if (information != null) destinationCell.SetTag(7, MedicalViewerTagAlignment.TopLeft, information.Type);
            }
        }


        // Convert the 2D Cell to 3D
        private Medical3DControl ConvertTo3D(MedicalViewerMultiCell cell)
        {
            Medical3DControl control3D = null;
            CounterDialog counterDialog = null;
            RasterImage image = null;
            try
            {
                if (_menuActionPanoramicPolygon.Checked)
                    _menuActionWindowLevel_Click(null, null);

                _mainMenu.Enabled = false;
                using (RasterCodecs codecs = new RasterCodecs())
                {
                    int index;

                    CellData data = (CellData)cell.Tag;

                    DeleteAllGeneratorsFromCell(cell);
                    DeleteAllMPRPolygonFromCell(cell);
                    cell.DisposeCutPlanesData();

                    counterDialog = new CounterDialog(this);


                    int width = cell.VirtualImage[0].Image.Width;
                    int height = cell.VirtualImage[0].Image.Height;
                    int depth = (data.CellType == ViewerCellType.SingleFileSeries) ? cell.VirtualImage.Count : data.FileNames.Length;


                    bool doSoftwareRendering = SoftwareRendering;
                    if (!Medical3DEngine.CanUse3DTexturing(width, height, depth))
                    {
                        doSoftwareRendering = true;
                    }

                    if (!Medical3DEngine.HardwareCompatible)
                    {
                        doSoftwareRendering = true;
                    }


                    // TODO : if the hardware is weak to the point it doesn't have enough VRAM, then switch to software.


                    control3D = new Medical3DControl(doSoftwareRendering);
                    control3D.ObjectsContainer.RenderingType = RenderingType;

                    control3D.Tag = counterDialog;

                    control3D.ObjectsContainer.Objects.Add(new Medical3DObject());

                    Initialize3DCell(control3D);

                    int count;

                    StartProgress(counterDialog);

                    bool created = true;

                    if (data.CellType == ViewerCellType.SingleFileSeries)
                    {
                        count = cell.VirtualImage.Count;
                        created = control3D.ObjectsContainer.Objects[0].MemoryEfficientInit(count);
                        if (!created)
                        {
                            // Remove the object
                            control3D.ObjectsContainer.Objects.RemoveAt(0);
                            control3D.Dispose();
                            MessageBox.Show("Not Enough memory to allocate the 3D object");
                            EndProgress(counterDialog);
                            return null;
                        }

                        try
                        {
                            DicomDataSet ds = new DicomDataSet();
                            ds.Load(data.FileNames[0], DicomDataSetLoadFlags.None);
                            for (index = 0; index < count; index++)
                            {

                                image = ds.GetImage(null, index, 0, RasterByteOrder.Gray, _dicomGetImageFlags);

                                control3D.ObjectsContainer.Objects[0].MemoryEfficientSetFrame(image, index, data.ImagePositions[index], true);
                                image.Dispose();
                                image = null;
                            }
                        }
                        catch (Exception)
                        {
                            // in case the image is not a dicom image, then load it using codecs.Load, which might be slower, but it works.
                            for (index = 0; index < count; index++)
                            {
                                image = codecs.Load(data.FileNames[0], 0, CodecsLoadByteOrder.BgrOrGray, index + 1, index + 1);
                                control3D.ObjectsContainer.Objects[0].MemoryEfficientSetFrame(image, index, data.ImagePositions[index], true);
                                image.Dispose();
                                image = null;
                            }

                        }
                    }
                    else
                    {
                        count = data.FileNames.Length;
                        created = control3D.ObjectsContainer.Objects[0].MemoryEfficientInit(count);
                        if (!created)
                        {
                            // Remove the object
                            control3D.ObjectsContainer.Objects.RemoveAt(0);
                            control3D.Dispose();
                            MessageBox.Show("Not Enough memory to allocate the 3D object");
                            EndProgress(counterDialog);
                            return null;
                        }

                        DicomDataSet ds = new DicomDataSet();
                        for (index = 0; index < count; index++)
                        {
                            ds.Load(data.FileNames[index], DicomDataSetLoadFlags.None);

                            image = ds.GetImage(null, data.FrameIndex - 1, 0, RasterByteOrder.Gray, _dicomGetImageFlags);
                            ds.DeleteImage(null, 0, 1);

                            int windowWidth = 0;
                            int windowCenter = 0;
                            float rescaleSlope = 1;
                            float rescaleIntercept = 0;


                            Int32.TryParse(GetDicomTag(ds, DicomTag.WindowWidth), out windowWidth);
                            Int32.TryParse(GetDicomTag(ds, DicomTag.WindowCenter), out windowCenter);
                            float.TryParse(GetDicomTag(ds, DicomTag.RescaleSlope), out rescaleSlope);
                            float.TryParse(GetDicomTag(ds, DicomTag.RescaleIntercept), out rescaleIntercept);


                            control3D.ObjectsContainer.Objects[0].MemoryEfficientSetFrame(image, index, data.ImagePositions[index], false, rescaleSlope, rescaleIntercept, windowWidth, windowCenter);
                            image.Dispose();
                            image = null;
                        }
                        ds.Dispose();
                    }

                    control3D.ObjectsContainer.Objects[0].MemoryEfficientEnd(cell.ImageOrientation, cell.PixelSpacing);

                    EndProgress(counterDialog);
                    control3D.Tag = data;

                    index = _viewer.Cells.IndexOf(cell);

                    _viewer.SuspendLayout();

                    if (index != -1)
                    {
                        _viewer.Cells.RemoveAt(index);
                    }
                    CopyTags(control3D, cell, true, false);

                    data.Cell = cell;
                    control3D.Tag = data;
                    _viewer.Cells.Insert(index, control3D);
                    _viewer.ResumeLayout();
                    control3D.Selected = true;

                    _mainMenu.Enabled = true;
                }

                return control3D;
            }
            catch (System.Exception ex)
            {
                if (image != null)
                    image.Dispose();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _mainMenu.Enabled = true;
                EndProgress(counterDialog);
                if (control3D != null)
                    control3D.Dispose();
                return null;
            }
        }


        private void cToolStripMenuItem_Click()
        {
            MedicalViewerMultiCell multiCell;
            MedicalViewerAnnotationAttributes annAttributes;
            MedicalViewerBaseAction AnnotationAction;


            multiCell = _viewer.Cells[0] as MedicalViewerMultiCell;

            annAttributes = multiCell.GetSelectedAnnotationAttributes(multiCell.ActiveSubCell);

            if (null != annAttributes)
            {

                MedicalViewerAnnotationText CurrentAction;


                CurrentAction = (MedicalViewerAnnotationText)multiCell.GetActionProperties(MedicalViewerActionType.AnnotationText,
                                                                                                 multiCell.ActiveSubCell);

                CurrentAction.AnnotationColor = Color.Red;

                CurrentAction.Flags = MedicalViewerAnnotationFlags.Selected;

                AnnotationAction = CurrentAction;

                multiCell.SetActionProperties(annAttributes.Type,
                                                AnnotationAction,
                                                multiCell.ActiveSubCell);
            }
        }


        private void LoadImages()
        {
            string[] files = Directory.GetFiles(DemosGlobal.ImagesFolder, "*.dcm");
            using (RasterCodecs codecs = new RasterCodecs())
            {

                for (int i = 0; i < _viewer.Cells.Count; i++)
                {
                    if (i >= files.Length)
                        break;

                    try
                    {
                        ((MedicalViewerCell)_viewer.Cells[i]).Image = codecs.Load(files[i]);
                    }
                    catch { }
                }
            }
        }

        private void _menuAbout_Click(object sender, EventArgs e)
        {
            using (AboutDialog aboutDialog = new AboutDialog("Main 3D Demo", ProgrammingInterface.CS))
                aboutDialog.ShowDialog(this);
        }

        MedicalViewerMultiCell ConvertBackTo2DCell()
        {
            Medical3DControl control3D = GetFirstSelected3DControl();
            CellData data = (CellData)control3D.Tag;
            MedicalViewerMultiCell cell = data.Cell;
            int index;

            DeleteAllGeneratorsFromCell(cell);

            index = _viewer.Cells.IndexOf(control3D);
            if (index != -1)
            {
                _viewer.Cells.RemoveAt(index);
                _viewer.Cells.Insert(index, cell);
                cell.Selected = true;
                cell.Focus();
            }

            control3D.Dispose();
            return cell;
        }

        void _viewer_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePoint.X = e.X;
            _mousePoint.Y = e.Y;
        }


        private void DeletePolygon(MedicalViewerMPRPolygon polygon)
        {
            if (polygon.PanoramicRepresentation != null)
            {
                _viewer.Cells.Remove(polygon.PanoramicRepresentation);
                polygon.PanoramicRepresentation.Dispose();
            }

            int index = 0;
            MedicalViewerParaxialCutCell cell = null;
            for (; index < polygon.ParaxialCuts.Count;)
            {
                cell = polygon.ParaxialCuts[0];
                polygon.ParaxialCuts.Remove(cell);
                cell.Dispose();
                cell = null;
            }

            MedicalViewerMultiCell parentCell = (MedicalViewerMultiCell)polygon.Parent;
            parentCell.Polygons.Remove(polygon);
        }

        private void DeleteAllMPRPolygonFromCell(MedicalViewerMultiCell cell)
        {
            int index;
            for (index = 0; index < cell.Polygons.Count;)
            {
                DeletePolygon(cell.Polygons[index]);
            }
        }

        private void DeleteAllGeneratorsFromCell(MedicalViewerMultiCell cell)
        {
            if (cell.ReferenceLine.CutLines.Count != 0)
            {
                MedicalViewerCell derivativeCell = cell.ReferenceLine.CutLines[0].DerivativeCell;
                cell.ReferenceLine.CutLines.RemoveAt(0);
                derivativeCell.Dispose();
            }

            if (cell.ReferenceLine.DoubleCutLines.Count != 0)
            {
                MedicalViewerCell firstDerivativeCell = cell.ReferenceLine.DoubleCutLines[0].FirstDerivativeCell;
                MedicalViewerCell secondDerivativeCell = cell.ReferenceLine.DoubleCutLines[0].SecondDerivativeCell;
                cell.ReferenceLine.DoubleCutLines.RemoveAt(0);
                firstDerivativeCell.Dispose();
                secondDerivativeCell.Dispose();
            }
        }

        private void SelectCell(int index)
        {
            if (index >= _viewer.Cells.Count)
                _viewer.Cells[index].Selected = true;
        }

        private void _menuItemShowOptionsDeleteGenerator_Click(object sender, EventArgs e)
        {
            if (_viewer.Cells[_generatorCellIndex] is MedicalViewerMultiCell)

                DeleteAllGeneratorsFromCell((MedicalViewerMultiCell)(_viewer.Cells[_generatorCellIndex]));
            _currentSelectedMenuItem.Checked = false;
            _currentSelectedMenuItem = GetCurrentCheckedCellOption(_generatorCellIndex);
            _currentSelectedMenuItem.Checked = true;
            _planeCutLineClicked = false;

            SelectCell(_generatorCellIndex);
        }

        private void _menuSSDMeshColor_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();
            if (control3D == null)
                return;

            ColorDialog dialog = new ColorDialog();
            dialog.Color = control3D.ObjectsContainer.Objects[0].SSD.MeshColor;

            if (dialog.ShowDialog() == DialogResult.OK)
                control3D.ObjectsContainer.Objects[0].SSD.MeshColor = dialog.Color;
        }


        private void ActivateMenu(ToolStripMenuItem currentSelectedMenuItem, object sender, EventArgs e)
        {
            if (currentSelectedMenuItem == _menuVolumeVRT)
            {
                _menuVolumeVRT_Click(sender, e);
            }
            else if (currentSelectedMenuItem == _menuVolumeMIP)
            {
                _menuVolumeMIP_Click(sender, e);
            }
            else if (currentSelectedMenuItem == _menuVolumeMinIP)
            {
                _menuVolumeMinIP_Click(sender, e);
            }
            else if (currentSelectedMenuItem == _menu2DCell)
            {
                _menu2DCell_Click(sender, e);
            }
            else if (currentSelectedMenuItem == _menuCutPlane2DCell)
            {
                _menuCutPlane2DCell_Click(sender, e);
            }
            else if (currentSelectedMenuItem == _menuDoubleCutPlane2DCell)
            {
                _menuDoubleCutPlane2DCell_Click(sender, e);
            }
        }

        private void _menuVolumeSSD_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();

            if (!Medical3DEngine.CanCreateMesh)
            {
                MessageBox.Show("You cannot create any more meshes, only one mesh can be loaded at a time");
                return;
            }


            Cursor oldCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            try
            {
                if (control3D == null)
                {
                    MedicalViewerMultiCell cell = GetFirstSelectedMultiCell();
                    if (cell == null)
                        return;

                    control3D = ConvertTo3D(cell);

                    if (control3D == null)
                    {
                        ActivateMenu(_menu2DCell, sender, e);
                        return;
                    }
                }

                if (_MPRMode)
                {
                    _showMPRWindows_Click(sender, e);
                }

                control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.SSD;

                if (_menuActionWindowLevel.Checked || _menuActionAlpha.Checked)
                    _menuActionRotate_Click(sender, e);

                if (oldIsoThreshold == 0)
                    oldIsoThreshold = control3D.ObjectsContainer.Objects[0].SSD.Threshold;

                CheckMenu(_menuVolumeSSD);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // revert back to the old selected menu item
                ActivateMenu(_menu2DCell, sender, e);
            }
            finally
            {
                Cursor = oldCursor;

            }
        }

        private void _menuLayoutOptions_Click(object sender, EventArgs e)
        {
            (new LayoutOptions(_viewer, this)).ShowDialog(this);
        }

        private string ShowSaveDialog(string filter)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.AddExtension = true;
            saveDialog.Filter = filter;
            DialogResult result = saveDialog.ShowDialog();
            if (result == DialogResult.OK)
                return saveDialog.FileName;
            else
                return null;
        }

        private string ShowLoadDialog(string filter)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = filter;

            DialogResult result = openDialog.ShowDialog();
            if (result == DialogResult.OK)
                return openDialog.FileName;
            else
                return null;
        }

        private void _loadMeshMenu_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = null;

            if (!Medical3DEngine.CanCreateMesh)
            {
                MessageBox.Show("You cannot create any more meshes, only one mesh can be loaded at a time");
                return;
            }

            try
            {
                string fileName = ShowLoadDialog("Mesh Files (*.x)|*.x");
                if (fileName != null)
                {
                    control3D = new Medical3DControl(SoftwareRendering);
                    if (control3D.ObjectsContainer.Objects.Count > 0)
                        control3D.ObjectsContainer.Objects.RemoveAt(0);

                    control3D.ObjectsContainer.Objects.Add(new Medical3DObject());
                    control3D.Tag = new CellData(ViewerCellType.Mesh3D);
                    Initialize3DCell(control3D);
                    AddCellToViewer(control3D);
                    control3D.ObjectsContainer.Objects[0].SSD.LoadMesh(fileName);
                    control3D.Invalidate();
                    control3D.Update();
                }
            }
            catch (Exception exception)
            {
                if (control3D != null)
                {
                    if (control3D.ObjectsContainer.Objects.Count > 0)
                        control3D.ObjectsContainer.Objects.RemoveAt(0);
                }
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _saveMeshMenu_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();
            if (control3D == null)
                return;
            if (control3D.ObjectsContainer.VolumeType != Medical3DVolumeType.SSD)
                return;

            string fileName = ShowSaveDialog("Mesh Files (*.x)|*.x");

            if (fileName != null)
            {
                control3D.ObjectsContainer.Objects[0].SSD.SaveMesh(fileName);
            }
        }

        private void _menuSSDIsoThreshold_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();
            if (control3D == null)
                return;

            (new IsoThresholdDialog(control3D, _viewer, control3D.ObjectsContainer)).ShowDialog(this);
        }

        private void _saveObjectStatusMenu_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();
            if (control3D == null)
                return;

            string fileName = ShowSaveDialog("Object Information (*.nfo)|*.nfo");

            if (fileName != null)
            {
                control3D.ObjectsContainer.Objects[0].SaveState(fileName);
            }
        }

        private void _loadObjectStatusMenu_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();
            if (control3D == null)
                return;

            string fileName = ShowLoadDialog("Object Information (*.nfo)|*.nfo");
            if (fileName != null)
            {
                control3D.ObjectsContainer.Objects[0].LoadState(fileName);

                if (_MPRMode)
                    _menuShowSlab.Checked = control3D.ObjectsContainer.Objects[0].Slab.Enabled;

                control3D.Invalidate();
            }
        }

        private string CreateInfoFile(string fileName)
        {
            string infoFileName = fileName;

            int index = infoFileName.LastIndexOf('\\');
            index++;

            String name = infoFileName.Substring(index);

            infoFileName = infoFileName.Remove(index);

            infoFileName = infoFileName + "Information" + name;

            return infoFileName;
        }

        private void UncheckThePerviousMenuItem(ToolStripMenuItem sender)
        {
            if (sender == null)
                return;

            foreach (ToolStripMenuItem item in sender.Owner.Items)
            {
                if (item.Checked)
                    item.Checked = false;
            }
        }

        private MedicalViewerActionFlags getApplyingOperation(MedicalViewerActionType actionType)
        {
            return (actionType == MedicalViewerActionType.MagnifyGlass) ? MedicalViewerActionFlags.Active : (false ? MedicalViewerActionFlags.AllCells | MedicalViewerActionFlags.RealTime : MedicalViewerActionFlags.Active);
        }

        private void SetAction(Control control, MedicalViewerActionType actionType, ToolStripMenuItem sender, ToolStripMenuItem rightClickMenuItem)
        {
            MedicalViewerBaseCell cell = (MedicalViewerBaseCell)control;
            UncheckThePerviousMenuItem(sender);
            UncheckThePerviousMenuItem(rightClickMenuItem);

            CellData data = (CellData)cell.Tag;

            data.CurrentCheckedItem = sender;
            data.CurrentCheckedRightClickItem = rightClickMenuItem;
            data.CurrentActionType = actionType;

            if (actionType == MedicalViewerActionType.Rotate3DObject)
                actionType = MedicalViewerActionType.WindowLevel;

            MedicalViewerActionFlags applyingOperation = getApplyingOperation(actionType);

            cell.SetAction(actionType, MedicalViewerMouseButtons.Left, applyingOperation);

            if (actionType == MedicalViewerActionType.WindowLevel)
                cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, getApplyingOperation(MedicalViewerActionType.Offset));
            else
                cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Right, getApplyingOperation(MedicalViewerActionType.WindowLevel));
        }

        private void Set3DAction(Control control, MedicalViewerActionType actionType, ToolStripMenuItem sender, ToolStripMenuItem rightClickMenuItem)
        {
            MedicalViewerBaseCell cell = (MedicalViewerBaseCell)control;
            UncheckThePerviousMenuItem(sender);
            UncheckThePerviousMenuItem(rightClickMenuItem);
            //sender.Checked = true;
            //rightClickMenuItem.Checked = true;

            CellData data = (CellData)cell.Tag;

            data.CurrentCheckedItem = sender;
            data.CurrentCheckedRightClickItem = rightClickMenuItem;
            data.CurrentActionType = actionType;


            cell.SetAction(actionType, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);

            if (actionType == MedicalViewerActionType.WindowLevel)
                cell.SetAction(MedicalViewerActionType.Rotate3DObject, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active);
            else
            {
                MedicalViewerActionType rightClickActionType = MedicalViewerActionType.WindowLevel;

                if (((Medical3DControl)control).ObjectsContainer.VolumeType == Medical3DVolumeType.SSD)
                    rightClickActionType = actionType == MedicalViewerActionType.Offset ? MedicalViewerActionType.Scale : MedicalViewerActionType.Offset;

                cell.SetAction(rightClickActionType, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.AllCells | MedicalViewerActionFlags.RealTime);
            }
        }



        private void _menuActionWindowLevel_Click(object sender, EventArgs e)
        {
            _actionType = MedicalViewerActionType.WindowLevel;
            foreach (Control control in _viewer.Cells)
            {
                if (Is2DCell(control))
                {
                    SetAction(control, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel);
                }

                if (control is Medical3DControl)
                {
                    Set3DAction(control, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel);
                }
            }
        }

        private void _menuActionAlpha_Click(object sender, EventArgs e)
        {
            _actionType = MedicalViewerActionType.Alpha;
            foreach (Control control in _viewer.Cells)
            {
                if (Is2DCell(control))
                {
                    SetAction(control, MedicalViewerActionType.Alpha, _menuActionAlpha, _rightClickAlpha);
                }
            }
        }

        private void _menuActionScale_Click(object sender, EventArgs e)
        {
            _actionType = MedicalViewerActionType.Scale;
            foreach (Control control in _viewer.Cells)
            {
                if (Is2DCell(control))
                {
                    SetAction(control, MedicalViewerActionType.Scale, _menuActionScale, _rightClickScale);
                }

                if (control is Medical3DControl)
                {
                    Set3DAction(control, MedicalViewerActionType.Scale, _menuActionScale, _rightClickScale);
                }
            }



        }

        private void _menuActionMagnify_Click(object sender, EventArgs e)
        {
            _actionType = MedicalViewerActionType.MagnifyGlass;
            foreach (Control control in _viewer.Cells)
            {
                if (Is2DCell(control))
                {
                    SetAction(control, MedicalViewerActionType.MagnifyGlass, _menuActionMagnify, _rightClickMagnify);
                }
            }
        }

        private void _menuActionPan_Click(object sender, EventArgs e)
        {
            _actionType = MedicalViewerActionType.Offset;
            foreach (Control control in _viewer.Cells)
            {
                if (Is2DCell(control))
                {
                    SetAction(control, MedicalViewerActionType.Offset, _menuActionPan, _rightClickPan);
                }
                if (control is Medical3DControl)
                {
                    Set3DAction(control, MedicalViewerActionType.Offset, _menuActionPan, _rightClickPan);
                }
            }
        }

        private void _menuActionRotate_Click(object sender, EventArgs e)
        {
            _actionType = MedicalViewerActionType.Rotate3DObject;
            foreach (Control control in _viewer.Cells)
            {
                if (control is Medical3DControl)
                {
                    Set3DAction(control, MedicalViewerActionType.Rotate3DObject, _menuActionRotate, _rightClickRotate);
                }

                if (Is2DCell(control))
                {
                    SetAction(control, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel);
                }
            }
        }

        private void _menuItemAddSingleCutPlane_Click(object sender, EventArgs e)
        {
            foreach (Control control in _viewer.Cells)
            {
                if ((control is MedicalViewerMultiCell))
                {
                    MedicalViewerMultiCell cell = (MedicalViewerMultiCell)control;

                    if (cell.Selected && !cell.Derivative)
                    {
                        DeleteAllGeneratorsFromCell(cell);
                        MedicalViewerPlaneCutLine cutplane = new MedicalViewerPlaneCutLine();
                        cell.ReferenceLine.CutLines.Add(cutplane);
                    }
                }
            }
        }

        private void _menuItemAddDoubleCutPlane_Click(object sender, EventArgs e)
        {
            foreach (Control control in _viewer.Cells)
            {
                if ((control is MedicalViewerMultiCell))
                {
                    MedicalViewerMultiCell cell = (MedicalViewerMultiCell)control;
                    if (cell.Selected && !cell.Derivative)
                    {
                        DeleteAllGeneratorsFromCell(cell);

                        MedicalViewerCell derivativeCell = null;
                        MedicalViewerCell derivativeCell1 = null;

                        try
                        {
                            derivativeCell = new MedicalViewerCell();
                            _viewer.Cells.Add(derivativeCell);
                            derivativeCell1 = new MedicalViewerCell();
                            _viewer.Cells.Add(derivativeCell1);
                            MedicalViewerDoublePlaneCutLine doubleCutplane = new MedicalViewerDoublePlaneCutLine(derivativeCell, derivativeCell1);
                            cell.ReferenceLine.DoubleCutLines.Add(doubleCutplane);
                        }
                        catch (System.Exception ex)
                        {
                            if (derivativeCell != null)
                                derivativeCell.Dispose();
                            if (derivativeCell1 != null)
                                derivativeCell1.Dispose();
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
        }

        int oldIsoThreshold;
        Color oldMeshColor = Color.White;


        private void ResetColorMapData(Medical3DControl control3D)
        {
            Medical3DObject object3D = (Medical3DObject)control3D.ObjectsContainer.Objects[0];
            object3D.Palette = null;
            object3D.ColorMap = null;

            CellData cellData = (CellData)control3D.Tag;
            cellData.ColorMapIndex = -1;

            ColorMapItem colorMapHistogram;

            Array Values = Enum.GetValues(typeof(MedicalViewerPaletteType));

            if (cellData.ColorMapList != null)
            {
                if (cellData.ColorMapList.Count > Values.Length)
                {
                    cellData.ColorMapList.RemoveAt(Values.Length);
                }


                int length = cellData.ColorMapList.Count;
                for (int i = 0; i < length; i++)
                {
                    colorMapHistogram = cellData.ColorMapList[i];

                    if (colorMapHistogram.Points != null)
                        colorMapHistogram.Points.Clear();
                    colorMapHistogram.PaletteType = MedicalViewerPaletteType.None;
                }
            }

            control3D.Invalidate();
        }

        private void _menuItemEditReset_Click(object sender, EventArgs e)
        {
            int i;

            MedicalViewerOffset offset;
            Medical3DControl control3D;
            for (i = 0; i < _viewer.Cells.Count; i++)
            {
                // check if this is a 3D cell.
                if (_viewer.Cells[i] is Medical3DControl)
                {
                    control3D = (Medical3DControl)_viewer.Cells[i];
                    control3D.ObjectsContainer.ResetRotation();
                    control3D.ObjectsContainer.ResetPosition();
                    control3D.ObjectsContainer.Camera.Zoom = 27.69f;

                    if (control3D.ObjectsContainer.Objects.Count != 0)
                    {
                        control3D.ObjectsContainer.Objects[0].Scale = 100;
                        control3D.ObjectsContainer.Objects[0].LowerThreshold = control3D.ObjectsContainer.Objects[0].MinimumValue;
                        control3D.ObjectsContainer.Objects[0].UpperThreshold = control3D.ObjectsContainer.Objects[0].MaximumValue;
                        control3D.ObjectsContainer.Objects[0].RemoveInterval = Medical3DRemoveIntervalType.OuterRange;
                        control3D.ObjectsContainer.Objects[0].EnableThresholding = false;
                        control3D.ResetWindowLevelValues();

                        if (control3D.ObjectsContainer.VolumeType == Medical3DVolumeType.SSD)
                        {
                            control3D.ObjectsContainer.Objects[0].SSD.MeshColor = oldMeshColor;
                            control3D.ObjectsContainer.Objects[0].LowerThreshold = control3D.ObjectsContainer.Objects[0].MinimumValue;
                            control3D.ObjectsContainer.Objects[0].UpperThreshold = control3D.ObjectsContainer.Objects[0].MaximumValue;
                        }
                    }
                    control3D.ResetOrientationCubePosition();

                    ResetColorMapData(control3D);

                }
                else if (_viewer.Cells[i] is MedicalViewerCell)
                {
                    MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[i];
                    offset = (MedicalViewerOffset)cell.GetActionProperties(MedicalViewerActionType.Offset, i);
                    offset.X = 0;
                    offset.Y = 0;

                    MedicalViewerAlpha alpha = (MedicalViewerAlpha)cell.GetActionProperties(MedicalViewerActionType.Alpha, i);
                    alpha.Alpha = 0;
                    cell.SetActionProperties(MedicalViewerActionType.Alpha, alpha);

                    cell.SetActionProperties(MedicalViewerActionType.Offset, offset);
                    cell.SetScaleMode(MedicalViewerScaleMode.Fit);
                    cell.ResetWindowLevelValues();
                }
            }


        }

        private void _rightClickCellReferenceColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            MedicalViewerCell cell = (MedicalViewerCell)_viewer.Cells[_generatorCellIndex];
            colorDlg.Color = cell.ReferenceLine.Color;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                cell.ReferenceLine.Color = colorDlg.Color;
            }
            _planeCutLineClicked = false;
        }

        private void _menuItemShowOptionsSetGeneratorColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                MedicalViewerMultiCell cell = (MedicalViewerMultiCell)_viewer.Cells[_generatorCellIndex];

                // since there will be one generator, either a single or double, then I'll check the type of generator
                // by checking the count of each collection.
                if (cell.ReferenceLine.CutLines.Count != 0)
                    cell.ReferenceLine.CutLines[0].Color = colorDlg.Color;

                if (cell.ReferenceLine.DoubleCutLines.Count != 0)
                {
                    cell.ReferenceLine.DoubleCutLines[0].FirstLineColor = colorDlg.Color;
                    cell.ReferenceLine.DoubleCutLines[0].SecondLineColor = colorDlg.Color;
                }
            }
            _planeCutLineClicked = false;
        }

        private void _menuRemoveDensity_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();
            if (control3D == null)
                return;

            new ThresholdDialog(control3D, control3D.ObjectsContainer, Medical3DVolumeType.VRT).ShowDialog();
        }

        private void _menuItemEditSSD_DropDownOpening(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();
            if (control3D == null)
                return;

            bool enable = (control3D.ObjectsContainer.VolumeType == Medical3DVolumeType.SSD);

            CellData cellData = (CellData)control3D.Tag;

            _menuSSDMeshColor.Enabled = enable;

            switch (cellData.CellType)
            {
                case ViewerCellType.Mesh3D:
                    enable = false;
                    break;
            }

            _menuSSDIsoThreshold.Enabled = enable;
        }

        private void _menuFile_DropDownOpening(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();

            bool SSDLoaded = false;
            bool control3DExist = false;

            if (control3D != null)
            {
                control3DExist = true;
                if (control3D.ObjectsContainer.VolumeType == Medical3DVolumeType.SSD)
                    SSDLoaded = true;
            }

            _saveMeshMenu.Enabled = SSDLoaded;
            _saveObjectStatusMenu.Enabled = control3DExist;
            _loadObjectStatusMenu.Enabled = control3DExist;
            _menuSaveRawData.Enabled = control3DExist;

            _menuItemHardwareCheck.Enabled = !SoftwareRendering;


            _loadMeshMenu.Enabled = !_MPRMode;
            _menuLoadObject.Enabled = !_MPRMode;
            _menuItemFileLoadDICOM.Enabled = !_MPRMode;
            _menuItemFileLoadDICOMDIR.Enabled = !_MPRMode;

            if (IsLoadedSSDMesh(control3D) || SSDLoaded)
                _menuSaveRawData.Enabled = false;

            _menuUnload.Enabled = ((GetFirstSelectedControl() != null));

            _saveMPR.Enabled = _MPRMode;
            _save3DImage.Enabled = control3DExist && (control3D.ObjectsContainer.VolumeType == Medical3DVolumeType.VRT);
        }

        private void _menuItemHardwareCheck_Click(object sender, EventArgs e)
        {
            if (!HardwareCompatible)
            {
                MessageBox.Show("Hardware does not meet the required specifications required to render 3D in hardware mode.", "Compatibility Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CheckUtilityDialog check = new CheckUtilityDialog(this);
            check.ShowDialog();
        }

        private void _menuCellType_DropDownOpening(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();
            MedicalViewerMultiCell cell = GetFirstSelectedMultiCell();

            bool control3DExist = (control3D == null);
            bool Allow3D = true;
            bool Allow2D = true;

            if ((cell == null) && (control3D == null))
            {
                Allow3D = false;
                Allow2D = false;
            }
            else if (cell == null)
            {
                CellData cellData = (CellData)control3D.Tag;

                switch (cellData.CellType)
                {
                    case ViewerCellType.Mesh3D:
                        Allow2D = false;
                        Allow3D = false;
                        break;
                    case ViewerCellType.LoadedObject:
                        Allow3D = true;
                        Allow2D = false;
                        break;
                }
            }
            else if (control3D == null)
            {
                CellData cellData = (CellData)cell.Tag;
                switch (cellData.CellType)
                {
                    case ViewerCellType.Other:
                    case ViewerCellType.Derivate:
                        {
                            Allow2D = false;
                            Allow3D = false;
                        }
                        break;

                    case ViewerCellType.SingleFileSeries:
                    case ViewerCellType.Cell2D:
                        if (cell.VirtualImage.Count < 3 || !cellData.Can3D)
                        {
                            Allow3D = false;
                            Allow2D = false;
                        }
                        break;
                }
            }

            _menu2DCell.Enabled =
            _menuCutPlane2DCell.Enabled =
            _menuDoubleCutPlane2DCell.Enabled = Allow2D;


            _menuVolumeMinIP.Enabled =
            _menuVolumeMIP.Enabled =
            _menuVolumeVRT.Enabled =
            _menuVolumeMPR.Enabled =
            _menuVolumeSSD.Enabled = Allow3D;
        }

        Medical3DControl _mprControlWindow;
        int _mprControlIndex;
        MedicalViewer _oldViewer;
        void ConverttoMPRWindow(bool mprMode)
        {
            if (mprMode)
            {
                _mprControlWindow = GetFirstSelected3DControl();

                _mprControlIndex = _viewer.Cells.IndexOf(_mprControlWindow);

                _viewer.Cells.Remove(_mprControlWindow);

                _displayPanel.Controls.Remove(_viewer);

                _oldViewer = _viewer;
                _viewer = new MedicalViewer(2, 2);

                _viewer.UseExtraSplitters = false;
                _viewer.DeleteCell += new EventHandler<MedicalViewerDeleteEventArgs>(MedicalViewer_DeleteCell);
                _viewer.Cells.Add(_mprControlWindow);

                _showMPRCrossHair = true;
                _coloredMPRCrossHair = true;

                _menuShowSlab.Checked = false;
                _menuShowCrossHair.Checked = true;
                _menuColoredCrossHair.Checked = true;

                MedicalViewerMPRCell mprAxial = new MedicalViewerMPRCell();
                MedicalViewerMPRCell mprSagittal = new MedicalViewerMPRCell();
                MedicalViewerMPRCell mprCoronal = new MedicalViewerMPRCell();

                InitializeMPRCell(mprAxial, MPRType.Axial);
                InitializeMPRCell(mprSagittal, MPRType.Sagittal);
                InitializeMPRCell(mprCoronal, MPRType.Coronal);

                mprAxial.ShowMPRCrossHair = true;
                mprSagittal.ShowMPRCrossHair = true;
                mprCoronal.ShowMPRCrossHair = true;

                mprAxial.DistinguishMPRByColor = true;
                mprSagittal.DistinguishMPRByColor = true;
                mprCoronal.DistinguishMPRByColor = true;

                _mprControlWindow.AxialFrame = mprAxial;
                _mprControlWindow.SagittalFrame = mprSagittal;
                _mprControlWindow.CoronalFrame = mprCoronal;

                CopyTags(mprAxial, _mprControlWindow, true);
                CopyTags(mprSagittal, _mprControlWindow, true);
                CopyTags(mprCoronal, _mprControlWindow, true);

                _viewer.Cells.AddRange(new MedicalViewerBaseCell[] { mprAxial, mprSagittal, mprCoronal });

                mprAxial.SetScaleMode(MedicalViewerScaleMode.Fit);
                mprSagittal.SetScaleMode(MedicalViewerScaleMode.Fit);
                mprCoronal.SetScaleMode(MedicalViewerScaleMode.Fit);

                _mprControlWindow.ApplyWindowLevelOnMPRSlices = true;

                mprAxial.ShowCellScroll = _showScrollBar;
                mprSagittal.ShowCellScroll = _showScrollBar;
                mprCoronal.ShowCellScroll = _showScrollBar;


                _displayPanel.Controls.Add(_viewer);
            }
            else
            {
                Medical3DControl control3D = (Medical3DControl)(_viewer.Cells[0]);

                if (control3D.ObjectsContainer.Objects[0].Slab.Enabled)
                {
                    control3D.ObjectsContainer.Objects[0].Slab.Enabled = false;
                }

                _viewer.Cells.RemoveAt(0);
                _displayPanel.Controls.Remove(_viewer);
                MedicalViewerBaseCell cell1 = _viewer.Cells[0];
                MedicalViewerBaseCell cell2 = _viewer.Cells[1];
                MedicalViewerBaseCell cell3 = _viewer.Cells[2];
                _viewer.Cells.RemoveAt(0);
                _viewer.Cells.RemoveAt(0);
                _viewer.Cells.RemoveAt(0);

                _viewer.Dispose();

                _viewer = _oldViewer;
                _mprControlWindow.AxialFrame = null;
                _mprControlWindow.SagittalFrame = null;
                _mprControlWindow.CoronalFrame = null;

                _displayPanel.Controls.Add(_viewer);
                _viewer.Cells.Insert(_mprControlIndex, _mprControlWindow);

                cell1.Dispose();
                cell2.Dispose();
                cell3.Dispose();
                _mprControlWindow.Selected = true;

            }
            _viewer.SetBounds(_displayPanel.Left, _displayPanel.Top, _displayPanel.Width, _displayPanel.Height);
            _viewer.Focus();
        }

        private void _showMPRWindows_Click(object sender, EventArgs e)
        {
            MedicalViewerBaseCell cell = GetFirstSelectedControl();

            if (cell == null)
                return;

            if ((!(cell is Medical3DControl)) && !_MPRMode)
            {
                Medical3DControl control3D = ConvertTo3D((MedicalViewerMultiCell)cell);
                if (control3D == null)
                    return;
                control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.MPR;
                CheckMenu(_menuVolumeMPR);
            }

            _MPRMode = !_MPRMode;
            _showMPRWindows.Checked = _MPRMode;
            _menuReferenceLine.Enabled = !_MPRMode;
            _menuMPRLayout.Enabled = _MPRMode;

            ConverttoMPRWindow(_MPRMode);

            if (_menuActionPanoramicPolygon.Checked)
                _menuActionWindowLevel_Click(sender, e);

            _viewer.Update();
            Update();
        }

        private void _menu2DCell_Click(object sender, EventArgs e)
        {
            if (_MPRMode)
                _showMPRWindows_Click(sender, e);

            CheckMenu(_menu2DCell);
            GetClean2DCell();
        }

        MedicalViewerMultiCell GetClean2DCell()
        {
            Medical3DControl control3D;
            MedicalViewerMultiCell cell;

            control3D = GetFirstSelected3DControl();
            cell = GetFirstSelectedMultiCell();

            if (control3D == null && cell == null)
                return null;

            if (control3D != null)
            {
                cell = ConvertBackTo2DCell();
            }
            else
            {
                DeleteAllGeneratorsFromCell(cell);
                DeleteAllMPRPolygonFromCell(cell);
            }

            return cell;
        }

        private void _menuCutPlane2DCell_Click(object sender, EventArgs e)
        {
            MedicalViewerCell derivativeCell = new MedicalViewerCell();

            try
            {
                if (_MPRMode)
                    _showMPRWindows_Click(sender, e);

                if (_menuActionPanoramicPolygon.Checked)
                    _menuActionWindowLevel_Click(sender, e);

                if (_menuCutPlane2DCell.Checked)
                    return;

                MedicalViewerMultiCell cell = GetClean2DCell();

                if (cell != null)
                {
                    _viewer.Cells.Add(derivativeCell);
                    cell.ReferenceLine.CutLines.Add(new MedicalViewerPlaneCutLine(derivativeCell));
                    CheckMenu(_menuCutPlane2DCell);

                }
            }
            catch (Exception exception)
            {
                derivativeCell.Dispose();
                ActivateMenu(_menu2DCell, sender, e);
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _menuDoubleCutPlane2DCell_Click(object sender, EventArgs e)
        {
            MedicalViewerCell derivativeCell = new MedicalViewerCell();
            MedicalViewerCell derivativeCell1 = new MedicalViewerCell();

            try
            {
                if (_MPRMode)
                    _showMPRWindows_Click(sender, e);

                if (_menuActionPanoramicPolygon.Checked)
                    _menuActionWindowLevel_Click(sender, e);

                if (_menuDoubleCutPlane2DCell.Checked)
                    return;

                MedicalViewerMultiCell cell = GetClean2DCell();

                if (cell != null)
                {
                    _viewer.Cells.Add(derivativeCell);
                    _viewer.Cells.Add(derivativeCell1);
                    cell.ReferenceLine.DoubleCutLines.Add(new MedicalViewerDoublePlaneCutLine(derivativeCell, derivativeCell1));
                    CheckMenu(_menuDoubleCutPlane2DCell);
                }
            }
            catch (Exception exception)
            {
                derivativeCell.Dispose();
                derivativeCell1.Dispose();
                ActivateMenu(_menu2DCell, sender, e);
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _menuShowReferenceLine_Click(object sender, EventArgs e)
        {
            MedicalViewerCell cell;
            _showReferenceLine = !_showReferenceLine;
            _menuShowReferenceLine.Checked = _showReferenceLine;

            foreach (Control control in _viewer.Cells)
            {
                if ((control is MedicalViewerCell) ||
                    (control is MedicalViewerMultiCell))
                {
                    cell = (MedicalViewerCell)control;
                    cell.ReferenceLine.Enabled = _showReferenceLine;
                }
            }
        }

        private void _menuShowReferenceBoundaries_Click(object sender, EventArgs e)
        {
            MedicalViewerCell cell;
            _showReferenceBoundaries = !_showReferenceBoundaries;
            _menuShowReferenceBoundaries.Checked = _showReferenceBoundaries;

            foreach (Control control in _viewer.Cells)
            {
                if ((control is MedicalViewerMultiCell) || (control is MedicalViewerCell))
                {
                    cell = (MedicalViewerCell)control;
                    cell.ShowCellBoundaries = _showReferenceBoundaries;
                }
            }
        }

        private void _menuShowCrossHair_Click(object sender, EventArgs e)
        {
            _showMPRCrossHair = !_showMPRCrossHair;
            _menuShowCrossHair.Checked = _showMPRCrossHair;
            MedicalViewerMPRCell mprCell;
            foreach (Control cell in _viewer.Cells)
            {
                if (cell is MedicalViewerMPRCell)
                {
                    mprCell = (MedicalViewerMPRCell)cell;
                    mprCell.ShowMPRCrossHair = _showMPRCrossHair;
                }
            }
        }

        private void _menuColoredCrossHair_Click(object sender, EventArgs e)
        {
            _coloredMPRCrossHair = !_coloredMPRCrossHair;
            _menuColoredCrossHair.Checked = _coloredMPRCrossHair;
            MedicalViewerMPRCell mprCell;
            foreach (Control cell in _viewer.Cells)
            {
                if (cell is MedicalViewerMPRCell)
                {
                    mprCell = (MedicalViewerMPRCell)cell;
                    mprCell.DistinguishMPRByColor = _coloredMPRCrossHair;
                }
            }
        }

        private void _menuShowSlab_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D;

            if (_viewer.Cells[0] is Medical3DControl)
            {
                control3D = (Medical3DControl)_viewer.Cells[0];
            }
            else
                return;

            _menuShowSlab.Checked = !_menuShowSlab.Checked;
            control3D.ObjectsContainer.Objects[0].Slab.Enabled = _menuShowSlab.Checked;
            MedicalViewerMPRCell mprCell;
            foreach (Control cell in _viewer.Cells)
            {
                if (cell is MedicalViewerMPRCell)
                {
                    mprCell = (MedicalViewerMPRCell)cell;
                    mprCell.ShowSlabBoundaries = _menuShowSlab.Checked;
                }
            }
        }

        void AddCellToViewer(MedicalViewerBaseCell control)
        {
            if (_MPRMode)
            {
                // if the MPR is active the program will delete the first 3D cell and replace it with a new one.
                if (_viewer.Cells.Count == 4)
                    _viewer.Cells[0].Dispose();

                if (_viewer != null)
                    _viewer.Cells.Insert(0, control);
            }
            else
            {
                if (_viewer != null)
                    _viewer.Cells.Add(control);
            }
        }

        private void _menuLoadObject_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = null;

            try
            {
                string fileName = ShowLoadDialog("RAW data (*.raw)|*.raw");

                if (fileName != null)
                {
                    control3D = new Medical3DControl(SoftwareRendering);

                    if (control3D.ObjectsContainer.Objects.Count == 0)
                    {
                        control3D.ObjectsContainer.Objects.Add(new Medical3DObject());
                    }

                    Initialize3DCell(control3D);
                    AddCellToViewer(control3D);
                    control3D.ObjectsContainer.Objects[0].LoadObjectFromFile(fileName);
                    control3D.Tag = new CellData(ViewerCellType.LoadedObject);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (control3D != null)
                    control3D.Dispose();
                return;
            }
        }

        private void _menuSaveRawData_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();
            if (control3D == null)
                return;

            string fileName = ShowSaveDialog("RAW data (*.raw)|*.raw");

            if (fileName != null)
            {
                control3D.ObjectsContainer.Objects[0].SaveObjectToFile(fileName);
                control3D.Invalidate();
                control3D.Update();
            }
        }

        private bool IsLoadedSSDMesh(Control control3D)
        {
            if (control3D == null)
                return false;

            CellData cellData = (CellData)(control3D.Tag);
            if (cellData.CellType == ViewerCellType.Mesh3D)
            {
                return true;
            }
            return false;
        }

        private void _menuView_DropDownOpening(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();
            MedicalViewerBaseCell cell = (MedicalViewerBaseCell)GetFirstSelectedControl();

            bool control3DExist = false;

            if (control3D != null)
                control3DExist = true;

            _menuProperties.Enabled =
            _menuInvert.Enabled = control3DExist;

            bool enableMPR = true;
            if (control3D == null)
            {

                if (cell != null)
                {
                    CellData cellData = (CellData)cell.Tag;
                    switch (cellData.CellType)
                    {
                        case ViewerCellType.MPRCell:
                            break;

                        case ViewerCellType.Other:
                        case ViewerCellType.Derivate:
                            enableMPR = false;
                            break;
                        case ViewerCellType.SingleFileSeries:
                        case ViewerCellType.Cell2D:
                            {
                                if (((MedicalViewerMultiCell)cell).VirtualImage.Count < 3)
                                {
                                    enableMPR = false;
                                }
                            }
                            break;
                    }
                }
                else
                    enableMPR = false;
            }
            _showMPRWindows.Enabled = enableMPR || _MPRMode;

            if (IsLoadedSSDMesh(control3D) || IsSSDMode(control3D))
                _showMPRWindows.Enabled = false;
        }

        private void _menuReferenceLine_DropDownOpening(object sender, EventArgs e)
        {
            _menuShowReferenceLine.Enabled =
            _menuShowReferenceBoundaries.Enabled = !_MPRMode;

            _menuShowAllReferenceLines.Enabled =
            _menuShowFirstAndLastReferenceLines.Enabled = _menuShowReferenceLine.Checked;
        }

        MedicalViewerBaseCell GetFirstSelectedControl()
        {
            foreach (Control control in _viewer.Cells)
            {
                MedicalViewerBaseCell cell = (MedicalViewerBaseCell)control;

                if (cell.Selected)
                    return (MedicalViewerBaseCell)control;
            }
            return null;
        }

        MedicalViewerCell GetFirstDerivativeCell()
        {
            foreach (Control control in _viewer.Cells)
            {
                if ((control is MedicalViewerCell) && (!(control is MedicalViewerMultiCell)))
                {
                    MedicalViewerCell cell = (MedicalViewerCell)control;

                    if (cell.Selected)
                        return (MedicalViewerCell)control;
                }
            }
            return null;
        }

        private bool IsSSDMode(Medical3DControl control3D)
        {
            if (control3D == null)
                return false;

            if (control3D.ObjectsContainer.VolumeType == Medical3DVolumeType.SSD)
            {
                return true;
            }
            return false;
        }

        private void _actionsMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            bool allow2D = false;
            bool allow3D = false;
            bool allowmulti2D = false;
            bool allowPanoramic = true;
            MedicalViewerMultiCell multicell = null;

            Medical3DControl control3D = GetFirstSelected3DControl();
            CellData cellData = null;

            if (control3D != null)
            {
                allow3D = true;
                cellData = (CellData)control3D.Tag;
            }
            else
            {
                MedicalViewerCell cell = GetFirstDerivativeCell();
                multicell = GetFirstSelectedMultiCell();

                if (multicell != null)
                {
                    allowmulti2D = true;

                    cellData = (CellData)multicell.Tag;
                    switch (cellData.CellType)
                    {
                        case ViewerCellType.SingleFileSeries:
                        case ViewerCellType.Cell2D:
                            if (multicell.VirtualImage.Count < 3)
                            {
                                allowPanoramic = false;
                            }
                            break;
                    }


                }

                if (cell != null)
                {
                    cellData = (CellData)cell.Tag;
                    allow2D = true;
                }
            }

            _menuActionMagnify.Enabled = allowmulti2D || allow2D;
            _menuActionAlpha.Enabled = allowmulti2D;
            _menuActionPanoramicPolygon.Enabled = allowmulti2D && !(multicell is MedicalViewerParaxialCutCell) && allowPanoramic;
            _menuActionProbeTool.Enabled = allowmulti2D || allow2D;
            _menuActionWindowLevel.Enabled = (allowmulti2D || allow3D || allow2D);
            _menuActionPan.Enabled = allowmulti2D || allow3D || allow2D;
            _menuActionScale.Enabled = allowmulti2D || allow3D || allow2D;
            _menuActionRotate.Enabled = allow3D;

            if (IsLoadedSSDMesh(control3D) || IsSSDMode(control3D))
            {
                _menuActionWindowLevel.Enabled = false;
                _menuActionAlpha.Enabled = false;
            }

            UncheckAllActionMenu();

            if (cellData != null)
            {
                if (cellData.CurrentCheckedItem != null)
                    cellData.CurrentCheckedItem.Checked = true;

                if (cellData.CurrentCheckedRightClickItem != null)
                    cellData.CurrentCheckedRightClickItem.Checked = true;
            }

        }

        private void _menuShowScrollBar_Click(object sender, EventArgs e)
        {
            _showScrollBar = !_showScrollBar;

            foreach (Control control in _viewer.Cells)
            {
                if (control is MedicalViewerCell)
                {
                    MedicalViewerCell cell = (MedicalViewerCell)control;
                    cell.ShowCellScroll = !cell.ShowCellScroll;
                }
            }

            _menuShowScrollBar.Checked = _showScrollBar;
        }

        private void _menuUnload_Click(object sender, EventArgs e)
        {
            MedicalViewerBaseCell cell = (MedicalViewerBaseCell)GetFirstSelectedControl();

            // if you unload the MPR, then go back to the normal view before delete the set.
            if (_MPRMode)
            {
                cell = _viewer.Cells[0];
                _showMPRWindows_Click(sender, e);
            }
            DeleteCell(cell);
        }

        void DeleteCell(MedicalViewerBaseCell cell)
        {
            if (cell != null)
            {
                _viewer.Cells.Remove(cell);

                if (cell is Medical3DControl)
                {
                    Medical3DControl control3D = (Medical3DControl)(cell);

                    if (((CellData)control3D.Tag).Cell != null)
                    {
                        MedicalViewerBaseCell baseCell = (MedicalViewerBaseCell)((CellData)control3D.Tag).Cell;
                        baseCell.Dispose();
                    }
                }
                else if (cell is MedicalViewerMultiCell)
                {
                    MedicalViewerMultiCell multiCell = (MedicalViewerMultiCell)cell;
                    DeleteAllGeneratorsFromCell(multiCell);
                }
                else if (cell is MedicalViewerCell)
                {
                    MedicalViewerCell theOtherCell = SearchForTheGeneratorCellAndReturnTheOtherCell((MedicalViewerCell)cell);

                    if (theOtherCell != null)
                        theOtherCell.Dispose();
                }
                cell.Dispose();
            }
        }

        private void _menuDeleteAll_Click(object sender, EventArgs e)
        {
            MedicalViewerBaseCell cell = null;
            if (_MPRMode)
            {
                _menuUnload_Click(sender, e);
            }

            while (_viewer.Cells.Count != 0)
            {
                cell = _viewer.Cells[0];
                DeleteCell(cell);
            }
        }

        private void EnableRightClickMenuItems(object sender)
        {
            bool allow2D = false;
            bool allow3D = false;
            bool allowmulti2D = false;

            Medical3DControl control3D = GetFirstSelected3DControl();

            if (control3D != null)
            {
                allow3D = true;
            }
            else
            {
                MedicalViewerCell cell = GetFirstDerivativeCell();
                MedicalViewerMultiCell multicell = GetFirstSelectedMultiCell();
                if (multicell != null)
                {
                    allowmulti2D = true;
                }

                if (cell != null)
                {
                    allow2D = true;
                }
            }

            _rightClickMagnify.Enabled = !allow3D;
            _rightClickAlpha.Enabled = allowmulti2D;
            _rightClickWindowLevel.Enabled = (allowmulti2D || allow3D || allow2D);
            _rightClickPan.Enabled = allowmulti2D || allow3D || allow2D;
            _rightClickScale.Enabled = allowmulti2D || allow3D || allow2D;
            _rightClickRotate.Enabled = allow3D;

            if (IsLoadedSSDMesh(control3D) || IsSSDMode(control3D))
            {
                _rightClickWindowLevel.Enabled = false;
            }

            _rightClickCellReferenceColor.Enabled = (!(sender is Medical3DControl));

        }

        private void _menuVolumeMinIP_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();

            if (control3D == null)
            {
                MedicalViewerMultiCell cell = GetFirstSelectedMultiCell();
                if (cell == null)
                    return;

                control3D = ConvertTo3D(cell);

                if (control3D == null)
                    return;
            }

            control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.MINIP;

            CheckMenu(_menuVolumeMinIP);
        }



        private void _menuActionPanoramicPolygon_Click(object sender, EventArgs e)
        {
            UncheckAllActionMenu();

            _menuActionPanoramicPolygon.Checked = true;

            // make sure to convert to 2D cell
            _menu2DCell_Click(sender, e);
            bool allowed = true;
            if (_menuActionPanoramicPolygon.Checked)
            {
                foreach (MedicalViewerBaseCell baseCell in _viewer.Cells)
                {
                    allowed = !(baseCell is Medical3DControl);
                    if (allowed)
                    {
                        if (baseCell is MedicalViewerPanoramicCell)
                        {
                            allowed = false;
                        }
                        else if (baseCell is MedicalViewerCell)
                        {
                            if (((MedicalViewerCell)baseCell).Derivative)
                                allowed = false;
                        }
                    }

                    if (!allowed)
                    {
                        if (Is2DCell(baseCell))
                        {
                            SetAction(baseCell, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel);
                        }

                        if (baseCell is Medical3DControl)
                        {
                            Set3DAction(baseCell, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel);
                        }
                    }
                    else
                    {
                        SetAction(baseCell, MedicalViewerActionType.PanoramicPolygon, _menuActionPanoramicPolygon, null);
                    }
                }
            }
            else
            {
                foreach (MedicalViewerBaseCell baseCell in _viewer.Cells)
                {
                    baseCell.AddAction(MedicalViewerActionType.WindowLevel);
                    baseCell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.AllCells | MedicalViewerActionFlags.RealTime);
                }
            }
        }

        private void _panoramicRightClickCreateParaxialCell_Click(object sender, EventArgs e)
        {
            MedicalViewerMultiCell cell = GetFirstSelectedMultiCell();
            if (cell == null)
                return;

            AddParaxialCell(cell, _polygon, _polygonIndex);
        }

        private void _panoramicRightClickInsertPoint_Click(object sender, EventArgs e)
        {
            MedicalViewerMultiCell cell = GetFirstSelectedMultiCell();
            if (cell == null)
                return;

            _mousePoint.Offset(-cell.Location.X, -cell.Location.Y);

            Point pt = cell.PointToImage(_mousePoint);

            _polygon.Points.Insert(_polygonIndex + 1, pt);
            _polygon.Recalculate();
            _polygon.Parent.Invalidate();
            _polygonHandleClicked = false;
        }

        private void DeleteParaxialCell(int polygonLineIndex)
        {
            if (polygonLineIndex == _polygon.Points.Count - 1)
                polygonLineIndex--;

            int counter = 0;
            for (counter = 0; counter < _polygon.ParaxialCuts.Count; counter++)
            {
                if (_polygon.ParaxialCuts[counter].PolygonLineIndex == polygonLineIndex)
                {
                    DeleteCell(_polygon.ParaxialCuts[counter]);
                    return;
                }

            }
        }

        private void _panoramicRightClickDeletePoint_Click(object sender, EventArgs e)
        {
            DeleteParaxialCell(_polygonIndex);
            _polygon.Points.RemoveAt(_polygonIndex);
            _polygon.Recalculate();
            _polygon.Parent.Invalidate();
            _polygonHandleClicked = false;
        }

        private void _panoramicRightClickParaxialLineColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();

            MedicalViewerParaxialCutCell cell = GetParaxialCell();
            dialog.Color = cell.LinesColor;
            if (dialog.ShowDialog() == DialogResult.OK)
                cell.LinesColor = dialog.Color;
        }

        private void _panoramicRightClickActiveParaxialColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();

            MedicalViewerParaxialCutCell cell = GetParaxialCell();

            dialog.Color = cell.ActiveLineColor;
            if (dialog.ShowDialog() == DialogResult.OK)
                cell.ActiveLineColor = dialog.Color;
        }

        private void _panoramicRightClickPolygonColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = _polygon.Color;
            if (dialog.ShowDialog() == DialogResult.OK)
                _polygon.Color = dialog.Color;
        }

        MedicalViewerParaxialCutCell GetParaxialCell()
        {
            int polygonLineIndex = (_polygonIndex == _polygon.Points.Count - 1) ? _polygonIndex - 1 : _polygonIndex;

            int index;
            for (index = 0; index < _polygon.ParaxialCuts.Count; index++)
            {
                if (_polygon.ParaxialCuts[index].PolygonLineIndex == polygonLineIndex)
                    return _polygon.ParaxialCuts[index];

            }

            return null;
        }


        private void _panoramicRightClickParaxialProperties_Click(object sender, EventArgs e)
        {
            MedicalViewerParaxialCutCell cell = GetParaxialCell();
            if (cell == null)
                return;

            ParaxialDialog dialog = new ParaxialDialog(cell);
            dialog.ShowDialog();
        }

        private void _panoramicRightClickDeletePolygon_Click(object sender, EventArgs e)
        {
            MedicalViewerMultiCell cell = GetFirstSelectedMultiCell();
            if (cell == null)
                return;

            DeleteAllMPRPolygonFromCell(cell);
        }

        private void _panoramicRightClickDeleteParaxialCell_Click(object sender, EventArgs e)
        {
            MedicalViewerParaxialCutCell cell = GetParaxialCell();
            if (cell == null)
                return;

            cell.Dispose();
        }

        private void _menuShowAllReferenceLines_Click(object sender, EventArgs e)
        {
            _viewer.ShowSelectedReferenceLine = !_viewer.ShowSelectedReferenceLine;
            _menuShowAllReferenceLines.Checked = !_viewer.ShowSelectedReferenceLine;
        }

        private void _menuShowFirstAndLastReferenceLines_Click(object sender, EventArgs e)
        {
            MedicalViewerCell cell;
            _showFirstAndLastReferenceLines = !_showFirstAndLastReferenceLines;
            _menuShowFirstAndLastReferenceLines.Checked = _showFirstAndLastReferenceLines;

            foreach (Control control in _viewer.Cells)
            {
                if ((control is MedicalViewerMultiCell) || (control is MedicalViewerCell))
                {
                    cell = (MedicalViewerCell)control;
                    cell.ReferenceLine.ShowFirstAndLast = _showFirstAndLastReferenceLines;
                }
            }
        }

        private void _menuActionProbeTool_Click(object sender, EventArgs e)
        {

            _actionType = MedicalViewerActionType.ProbeTool;
            foreach (Control control in _viewer.Cells)
            {
                if (Is2DCell(control))
                {
                    SetAction(control, MedicalViewerActionType.ProbeTool, _menuActionProbeTool, _rightClickProbeTool);
                }

                if (control is Medical3DControl)
                {
                    Set3DAction(control, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel);
                }
            }
        }

        private void _menuEditFusion_Click(object sender, EventArgs e)
        {
            try
            {
                MedicalViewerMultiCell cell = GetFirstSelectedMultiCell();

                string imagePath;
                GetFileName(out imagePath);

                // Insert new cell if the user has selected an image.
                if (imagePath != "")
                {
                    DicomDataSet dicomDataSet = new DicomDataSet();
                    dicomDataSet.Load(imagePath, DicomDataSetLoadFlags.None);

                    SeriesInformation seriesInformation = LoadDICOM(dicomDataSet, imagePath);

                    dicomDataSet.Dispose();

                    if (seriesInformation.Image == null)
                        throw new Exception("Error Loading File");

                    MedicalViewerFusion fusion = new MedicalViewerFusion();

                    RasterCodecs _codecs = new RasterCodecs();

                    fusion.FusedImage = seriesInformation.Image;
                    fusion.FusionScale = 0.5f;
                    fusion.ColorPalette = MedicalViewerPaletteType.Fire;

                    cell.SubCells[cell.ActiveSubCell].Fusion.Add(fusion);
                }
            }
            catch (Exception ex)
            {
                Messager.Show(this, ex, MessageBoxIcon.Exclamation);
            }
        }

        private void dHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Medical3DControl control3D = GetFirstSelected3DControl();
            if (control3D == null)
            {
                MessageBox.Show("There is no 3D object selected");
                return;

            }


            Medical3DObject myObject = control3D.ObjectsContainer.Objects[0];

            Histogram3DDialog dialog = new Histogram3DDialog(control3D, myObject, this);
            dialog.ShowDialog();

            CellData data = (CellData)control3D.Tag;

        }

        class MPRCell
        {
            public MPRCell(MedicalViewerMPRCell cell, string name, Medical3DMPRInfo mPRInfo)
            {
                Cell = cell;
                Name = name;
                MPRInfo = mPRInfo;
            }
            public MedicalViewerMPRCell Cell;
            public string Name;
            public Medical3DMPRInfo MPRInfo;
        }



        private void UpdateDicomDataSetInformation(DicomDataSet dicomDataSet, MedicalViewerMPRCell mprCell, Medical3DMPRInfo info)
        {
            DicomElement dicomElement = dicomDataSet.FindFirstElement(null, DicomTag.ImageOrientationPatient, true);

            if (dicomElement != null)
            {
                string myString = "";
                for (int index = 0; index < 6; index++)
                {
                    myString += info.Orientation[index].ToString() + "\\";
                }
                myString.Remove(myString.Length - 1);

                dicomDataSet.SetConvertValue(dicomElement, myString, 6);
            }


            dicomElement = dicomDataSet.FindFirstElement(null, DicomTag.ImagePositionPatient, true);

            if (dicomElement != null)
            {
                string myString = "";
                for (int index = 0; index < 3; index++)
                {
                    myString += info.Position[index].ToString() + "\\";
                }
                myString.Remove(myString.Length - 1);

                dicomDataSet.SetConvertValue(dicomElement, myString, 3);
            }


            dicomElement = dicomDataSet.FindFirstElement(null, DicomTag.WindowWidth, true);

            if (dicomElement != null)
            {
                dicomDataSet.SetConvertValue(dicomElement, info.Width.ToString(), 1);
            }


            dicomElement = dicomDataSet.FindFirstElement(null, DicomTag.WindowCenter, true);

            if (dicomElement != null)
            {
                dicomDataSet.SetConvertValue(dicomElement, info.Center.ToString(), 1);
            }


            dicomElement = dicomDataSet.FindFirstElement(null, DicomTag.PixelSpacing, true);

            if (dicomElement != null)
            {
                dicomDataSet.SetConvertValue(dicomElement, String.Format("{0}\\{1}", info.CentiPerPixelX, info.CentiPerPixelY), 2);
            }
        }

        private void _saveMPR_Click(object sender, EventArgs e)
        {

            string fileName = ShowSaveDialog("DICOM Files (*.dcm)|*.dcm");

            if (fileName != null)
            {
                string fileNameWithNoExtenstion = fileName;
                int dotIndex = fileNameWithNoExtenstion.LastIndexOf(".");
                fileNameWithNoExtenstion = fileNameWithNoExtenstion.Remove(dotIndex);


                Medical3DControl control3D = (Medical3DControl)_viewer.Cells[0];
                if (control3D == null)
                {
                    throw new Exception("No 3d control is found");
                }

                CellData data = (CellData)control3D.Tag;
                MedicalViewerMultiCell cell = data.Cell;


                CellData cellData = (CellData)cell.Tag;


                DicomDataSet dicomDataSet = new DicomDataSet();
                dicomDataSet.Load(cellData.FileNames[0], DicomDataSetLoadFlags.None);

                int imageCount = dicomDataSet.GetImageCount(null);

                MPRCell[] mprCells = new MPRCell[3];
                mprCells[0] = new MPRCell(control3D.AxialFrame, "Axial", control3D.ObjectsContainer.Objects[0].GetMPRInformation(Medical3DMPRPlaneType.Axial, control3D.AxialFrame.ActiveSubCell));
                mprCells[1] = new MPRCell(control3D.SagittalFrame, "Sagittal", control3D.ObjectsContainer.Objects[0].GetMPRInformation(Medical3DMPRPlaneType.Sagittal, control3D.SagittalFrame.ActiveSubCell));
                mprCells[2] = new MPRCell(control3D.CoronalFrame, "Coronal", control3D.ObjectsContainer.Objects[0].GetMPRInformation(Medical3DMPRPlaneType.Coronal, control3D.CoronalFrame.ActiveSubCell));

                int index = 0;
                for (; index < 3; index++)
                {
                    MedicalViewerMPRCell currentMPRCell = mprCells[index].Cell;
                    RasterImage image = mprCells[index].MPRInfo.Image;

                    UpdateDicomDataSetInformation(dicomDataSet, currentMPRCell, mprCells[index].MPRInfo);

                    dicomDataSet.DeleteImage(null, 0, imageCount);

                    dicomDataSet.SetImage(null, image, DicomImageCompressionType.None, DicomImagePhotometricInterpretationType.Monochrome2, image.BitsPerPixel, 2, DicomSetImageFlags.None);

                    dicomDataSet.Save(String.Format("{0}_{1}.dcm", fileNameWithNoExtenstion, mprCells[index].Name), DicomDataSetSaveFlags.None);
                }

                dicomDataSet.Dispose();
            }

        }

        private void _save3DImage_Click(object sender, EventArgs e)
        {
            string fileName = ShowSaveDialog("DICOM Files (*.dcm)|*.dcm");

            if (fileName != null)
            {
                Medical3DControl control3D = GetFirstSelected3DControl();
                RasterImage image = control3D.ObjectsContainer.Objects[0].GetRendered3DObject();

                RasterCodecs codecs = new RasterCodecs();
                codecs.Save(image, fileName, RasterImageFormat.Tif, 64);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + (SoftwareRendering ? " - Software Rendering" : " - Hardware Rendering");
            var settingSoftwareOnly = IsConfigValueTrue("SoftwareOnlyRenderingMode");
            hardwareIfAvailbleToolStripMenuItem.Checked = !settingSoftwareOnly;
            softwareOnlyToolStripMenuItem.Checked = settingSoftwareOnly;
        }

        private void hardwareIfAvailbleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsConfigValueTrue("SoftwareOnlyRenderingMode"))
            {
                if (HardwareCompatible)
                {
                    MessageBox.Show("Please restart the application to apply this setting.", "Restart Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            SetConfigValue("SoftwareOnlyRenderingMode", false);


            hardwareIfAvailbleToolStripMenuItem.Checked = true;
            softwareOnlyToolStripMenuItem.Checked = false;

            if (!HardwareCompatible)
            {
                MessageBox.Show("Hardware does not meet the required specifications required to render 3D in hardware mode.", "Compatibility Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckUtilityDialog check = new CheckUtilityDialog(this);
                check.ShowDialog();
            }
        }

        private void softwareOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsConfigValueTrue("SoftwareOnlyRenderingMode"))
            {
                MessageBox.Show("Please restart the application to apply this setting.", "Restart Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            SetConfigValue("SoftwareOnlyRenderingMode", true);

            hardwareIfAvailbleToolStripMenuItem.Checked = false;
            softwareOnlyToolStripMenuItem.Checked = true;
        }

        private void renderingTypeToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
           foreach (ToolStripMenuItem item in renderingTypeToolStripMenuItem.DropDownItems)
           {
              item.Checked = false;
           }

           switch (RenderingType)
           {
              case Medical3DVolumeRenderingType.Auto:
                 _texturingAuto.Checked = true;
                 break;

              case Medical3DVolumeRenderingType.Type3D:
                 _texturing3D.Checked = true;
                 break;

              case Medical3DVolumeRenderingType.Type2D:
                 _texturing2D.Checked = true;
                 break;
           }
        }

        private void _texturing3D_Click(object sender, EventArgs e)
        {
           RenderingType = Medical3DVolumeRenderingType.Type3D;
           SetConfigData("RenderingType", ((int)RenderingType).ToString());

        }

        private void _texturing2D_Click(object sender, EventArgs e)
        {
           RenderingType = Medical3DVolumeRenderingType.Type2D;
           SetConfigData("RenderingType", ((int)RenderingType).ToString());
        }

        private void _texturingAuto_Click(object sender, EventArgs e)
        {
           RenderingType = Medical3DVolumeRenderingType.Auto;
           SetConfigData("RenderingType", ((int)RenderingType).ToString());
        }
    }

    // Determine the type of the cell.
    public enum ViewerCellType
    {
        Derivate,
        SingleFileSeries,
        MPRCell,
        Cell2D,
        Mesh3D,
        LoadedObject,
        Other
    }

    /// <summary>
    /// This class contains the information that will be saved in cell "Tag"
    /// </summary>
    public class CellData
    {
        private bool _can3D = true;

        public bool Can3D
        {
            get { return _can3D; }
            set { _can3D = value; }
        }

        private int _colorMapIndex;
        private ViewerCellType _cellType;
        private List<ColorMapItem> _colorMapPoint;
        private string[] _fileNames;
        private Point3D[] _imagePositions;
        private int[] _frameInstanceNumber;
        private int _multiPageCount;
        private MedicalViewerMultiCell _cell;
        private int _frameIndex;
        private CounterDialog _counterDialog;

        public CellData(ViewerCellType cellType)
        {
            _cellType = cellType;
            Initialize();
        }

        private void Initialize()
        {
            _colorMapIndex = -1;
        }

        public CellData()
        {
            _cellType = ViewerCellType.Cell2D;
            Initialize();
        }

        public CounterDialog Counter
        {
            get
            {
                return _counterDialog;
            }
            set
            {
                _counterDialog = value;
            }
        }

        private int[] _indexing;

        public int[] Indexing
        {
            get
            {
                return _indexing;
            }

            set
            {
                _indexing = value;
            }
        }

        public Point3D[] ImagePositions
        {
            get
            {
                return _imagePositions;
            }
            set
            {
                _imagePositions = value;
            }
        }



        public int FrameIndex
        {
            get
            {
                return _frameIndex;
            }
            set
            {
                _frameIndex = value;
            }
        }




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


        public ViewerCellType CellType
        {
            get
            {
                return _cellType;
            }
            set
            {
                _cellType = value;
            }
        }

        public int ColorMapIndex
        {
            get
            {
                return _colorMapIndex;
            }

            set
            {
                _colorMapIndex = value;
            }
        }

        public List<ColorMapItem> ColorMapList
        {
            get
            {
                return _colorMapPoint;
            }

            set
            {
                _colorMapPoint = value;
            }
        }


        public int MultiPageCount
        {
            get
            {
                return _multiPageCount;
            }
            set
            {
                _multiPageCount = value;
            }
        }

        public int[] InstanceNumbers
        {
            get
            {
                return _frameInstanceNumber;
            }
            set
            {
                _frameInstanceNumber = value;
            }
        }

        public string[] FileNames
        {
            get
            {
                return _fileNames;
            }
            set
            {
                _fileNames = value;
            }
        }

        public Medical3DColorMapping ColorMap = null;
        public byte[] Palette = null;


        public ToolStripMenuItem CurrentCheckedItem;
        public ToolStripMenuItem CurrentCheckedRightClickItem;
        public MedicalViewerActionType CurrentActionType;
    }
}
