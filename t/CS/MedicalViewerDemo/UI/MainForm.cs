// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Threading;
using System.Collections.Generic;

using Leadtools;
using Leadtools.WinForms;
using Leadtools.Dicom;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.ImageProcessing;
using Leadtools.MedicalViewer;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing.Effects;
using Leadtools.WinForms.CommonDialogs.File;
using Leadtools.Annotations.Automation;
using Leadtools.Controls;
using Leadtools.Annotations.Engine;

using Leadtools.Annotations.WinForms;


namespace MedicalViewerDemo
{
   public delegate void MyFunctionDelegate(MedicalViewerMultiCell cell, int subCellIndex);

   public partial class MainForm : Form
   {

      public AutomationManagerHelper ManagerHelper
      {
         get
         {
            return _managerHelper;
         }
      }

      public class StentData
      {
         public StentData(MedicalViewerMultiCell stentCell, MedicalViewerMultiCell avgImageCell, MedicalViewerMultiCell enhImageCell)
         {
            _stentCell = stentCell;
            _avgImageCell = avgImageCell;
            _enhImageCell = enhImageCell;
         }

         private MedicalViewerMultiCell _stentCell;
         private MedicalViewerMultiCell _avgImageCell;
         private MedicalViewerMultiCell _enhImageCell;
         private int _enhImageCellWLWidth;
         private int _enhImageCellWLCenter;

         public MedicalViewerMultiCell StentCell
         {
            get
            {
               return _stentCell;
            }
         }
         public MedicalViewerMultiCell AvgImageCell
         {
            get
            {
               return _avgImageCell;
            }
            set
            {
               _avgImageCell = value;
            }
         }

         public MedicalViewerMultiCell EnhImageCell
         {
            get
            {
               return _enhImageCell;
            }
            set
            {
               _enhImageCell = value;
            }
         }

         public int EnhImageCellWLWidth
         {
            get
            {
               return _enhImageCellWLWidth;
            }
            set
            {
               _enhImageCellWLWidth = value;
            }
         }

         public int EnhImageCellWLCenter
         {
            get
            {
               return _enhImageCellWLCenter;
            }
            set
            {
               _enhImageCellWLCenter = value;
            }
         }
      }

      private MedicalViewerMultiCell _stentCell;
      private MedicalViewerMultiCell _avgImageCell;
      private MedicalViewerMultiCell _enhImageCell;
      private StentEnhancementCommand _stentCommand;
      private StentEnhancementDialog _stentDialog;
      private List<StentData> _stentDataList;
      private LeadRect _stentRegion;
      private int markerIndex;
      private int _keyStentFrame;
      private bool _dialogDisplaced;
      private bool[] _frameEnabled;
      private string _openInitialPath = string.Empty;

      public StentEnhancementCommand StentCommand
      {
         get
         {
            return _stentCommand;
         }
      }

      public bool[] FrameEnabled
      {
         get
         {
            return _frameEnabled;
         }
      }


      private static List<RasterImage[]> _orignalImagesList;
      public List<RasterImage[]> OrignalImagesList
      {
         get
         {
            return _orignalImagesList;
         }
      }



      private List<LeadPoint> _templateList;
      private List<LeadPoint> _referenceList;

      private MedicalViewerMultiCell _referenceCell;
      private MedicalViewerMultiCell _templateCell;
      private bool _refPointAdded;
      private int _alignPointIdx;

      private ImageAlignmentDialog _alignmentDlg;
      private MedicalViewerMultiCell _registeredImageCell;

      public List<LeadPoint> TemplateList
      {
         get
         {
            return _templateList;
         }
         set
         {
            _templateList = value;
         }
      }

      public List<LeadPoint> ReferenceList
      {
         get
         {
            return _referenceList;
         }
         set
         {
            _referenceList = value;
         }
      }



      public bool StentEnhancementActive;
      public bool UnselectFrameActive;
      public bool ModifyStentActive;

      public ModifyStent _modifyStentDlg;

      private int _images;
      private int _cellIndex;
      private MedicalViewer _medicalViewer;
      private bool _applyToAll;
      private PrintDocument _printDocument;
      private RasterImage _printImage;

      private MedicalViewerActionType _currentAction;

      private static MedicalViewerActionType _leftButtonAction;
      private static MedicalViewerActionType _rightButtonAction;

      public MedicalViewerActionType LeftButtonAction
      {
         get
         {
            return _leftButtonAction;
         }
         set
         {
            _leftButtonAction = value;
         }
      }

      public MedicalViewerActionType RightButtonAction
      {
         get
         {
            return _rightButtonAction;
         }
         set
         {
            _rightButtonAction = value;
         }
      }

      public MedicalViewerActionType CurrentAction
      {

         get
         {
            return _currentAction;
         }

         set
         {
            _currentAction = value;
         }
      }

      public PrintDocument PrintDocument
      {
         get
         {
            return _printDocument;
         }
      }


      public RasterImage PrintImage
      {
         get
         {
            return _printImage;
         }
         set
         {
            _printImage = value;
         }
      }

      public static MedicalViewerMultiCell _defaultCell;

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

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.EnableVisualStyles();
         Application.DoEvents();
         Application.Run(new MainForm());
      }



      public MainForm()
      {
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         InitClass();
         _medicalViewer.DeleteCell += new EventHandler<MedicalViewerDeleteEventArgs>(_medicalViewer_DeleteCell);
         _stentMenuItem.Enabled = true;
         _stentMenuItem.Visible = true;
         _filtersMenuItem.Enabled = true;
         _filtersMenuItem.Visible = true;


      }

      void Cells_ItemAdded(object sender, MedicalViewerCollectionEventArgs<MedicalViewerBaseCell> e)
      {

         if (((MedicalViewerCell)e.Item).Image != null)
         {
            int imageCount = ((MedicalViewerCell)e.Item).Image.PageCount;
            _orignalImagesList.Add(new RasterImage[imageCount]);
         }
         else
         {
            _orignalImagesList.Add(null);
         }

      }

#if LEADTOOLS_V19_OR_LATER
      private AnnAutomationManager _automationManager;
      private AutomationManagerHelper _managerHelper;
      private void InitAutomation(MedicalViewerCell cell)
      {
         if (_managerHelper == null)
         {
            _automationManager = ((MedicalViewerMultiCell)_medicalViewer.Cells[0]).AutomationManager; //new AnnAutomationManager();

            _automationManager.RedactionRealizePassword = string.Empty;
            _managerHelper = new AutomationManagerHelper(_automationManager);



            IAnnObjectRenderer annNoteObjectRenderer = _automationManager.RenderingEngine.Renderers[AnnObject.NoteObjectId];


            _managerHelper.IgnoredObjectsList.Add(AnnObject.TextUnderlineObjectId);
            _managerHelper.IgnoredObjectsList.Add(AnnObject.TextStrikeoutObjectId);
            _managerHelper.IgnoredObjectsList.Add(AnnObject.TextHiliteObjectId);
            _managerHelper.IgnoredObjectsList.Add(AnnObject.TextRedactionObjectId);
            _managerHelper.IgnoredObjectsList.Add(AnnObject.StickyNoteObjectId);

            _managerHelper.CreateToolBar();
            Controls.Add(_managerHelper.ToolBar);

            _managerHelper.ToolBar.Dock = DockStyle.Right;
            _managerHelper.ToolBar.BringToFront();
            _managerHelper.ToolBar.AutoSize = true;
            _managerHelper.ToolBar.Appearance = ToolBarAppearance.Flat;
            _managerHelper.ToolBar.ButtonClick += new ToolBarButtonClickEventHandler(ToolBar_ButtonClick);
            _managerHelper.ToolBar.ButtonDropDown += new ToolBarButtonClickEventHandler(ToolBar_ButtonClick);

            UnpushAllAnnotationIcons();

            MainForm_Resize(this, EventArgs.Empty);
         }
         else
         {

            AnnAutomationManager automationManager = cell.AutomationManager;
            AutomationManagerHelper helpers = new AutomationManagerHelper(automationManager);
         }
      }


      ToolBarButton _currentToolbarButton = null;



      private void UnpushAllAnnotationIcons()
      {
         foreach (ToolBarButton button in _managerHelper.ToolBar.Buttons)
         {
            button.Pushed = false;
         }
      }


      public MedicalViewerActionType GetAnnotationActionId(int annotationObjectId)
      {
         switch (annotationObjectId)
         {
            case AnnObject.SelectObjectId:
               return MedicalViewerActionType.None;
            case AnnObject.RulerObjectId:
               return MedicalViewerActionType.AnnotationRuler;
            case AnnObject.ProtractorObjectId:
               return MedicalViewerActionType.AnnotationAngle;
            case AnnObject.TextObjectId:
               return MedicalViewerActionType.AnnotationText;
            case AnnObject.PointerObjectId:
               return MedicalViewerActionType.AnnotationArrow;
            case AnnObject.RectangleObjectId:
               return MedicalViewerActionType.AnnotationRectangle;
            case AnnObject.EllipseObjectId:
               return MedicalViewerActionType.AnnotationEllipse;
            case AnnObject.HiliteObjectId:
               return MedicalViewerActionType.AnnotationHilite;
            case AnnObject.LineObjectId:
               return MedicalViewerActionType.AnnotationLine;
            case AnnObject.PolylineObjectId:
               return MedicalViewerActionType.AnnotationPolyline;
            case AnnObject.PolygonObjectId:
               return MedicalViewerActionType.AnnotationPolygon;
            case AnnObject.CurveObjectId:
               return MedicalViewerActionType.AnnotationCurve;
            case AnnObject.ClosedCurveObjectId:
               return MedicalViewerActionType.AnnotationClosedCurve;
            case AnnObject.TextPointerObjectId:
               return MedicalViewerActionType.AnnotationTextPointer;
            case AnnObject.FreehandObjectId:
               return MedicalViewerActionType.AnnotationFreeHand;
            case AnnObject.TextRollupObjectId:
               return MedicalViewerActionType.AnnotationTextRollup;
            case AnnObject.NoteObjectId:
               return MedicalViewerActionType.AnnotationNote;
            case AnnObject.RubberStampObjectId:
               return MedicalViewerActionType.AnnotationRubberStamp;
            case AnnObject.StampObjectId:
               return MedicalViewerActionType.AnnotationStamp;
            case AnnObject.HotspotObjectId:
               return MedicalViewerActionType.AnnotationHotSpot;
            case AnnObject.FreehandHotspotObjectId:
               return MedicalViewerActionType.AnnotationFreeHandHotSpot;
            case AnnObject.ButtonObjectId:
               return MedicalViewerActionType.AnnotationButton;
            case AnnObject.PointObjectId:
               return MedicalViewerActionType.AnnotationPoint;
            case AnnObject.PolyRulerObjectId:
               return MedicalViewerActionType.AnnotationPolyRuler;
            case AnnObject.CrossProductObjectId:
               return MedicalViewerActionType.AnnotationCrossProduct;
            case AnnObject.RedactionObjectId:
               return MedicalViewerActionType.AnnotationRedaction;
            case AnnObject.EncryptObjectId:
               return MedicalViewerActionType.AnnotationEncrypt;
            case AnnObject.AudioObjectId:
               return MedicalViewerActionType.AnnotationAudio;
            case AnnObject.MediaObjectId:
               return MedicalViewerActionType.AnnotationMedia;
            default:
               return MedicalViewerActionType.None;
         }
      }
      void ToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
      {
         _currentToolbarButton = e.Button;
         MedicalViewerActionType annotationType = GetAnnotationActionId((int)e.Button.Tag);

         SetAction(annotationType, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
      }
#endif //LEADTOOLS_V19_OR_LATER

      private void InitClass()
      {
         _alignmentMenuItem.Visible = false;
#if LEADTOOLS_V19_OR_LATER
         _alignmentMenuItem.Visible = true;
#endif
         _stentDataList = new List<StentData>();


         _orignalImagesList = new List<RasterImage[]>();

         try
         {

            if (PrinterSettings.InstalledPrinters != null && PrinterSettings.InstalledPrinters.Count > 0)
            {
               _printDocument = new PrintDocument();
               _printDocument.BeginPrint += new PrintEventHandler(_printDocument_BeginPrint);
               _printDocument.PrintPage += new PrintPageEventHandler(_printDocument_PrintPage);
               _printDocument.EndPrint += new PrintEventHandler(_printDocument_EndPrint);
            }
            else
               _printDocument = null;
         }
         catch (Exception)
         {
            _printDocument = null;
         }

         try
         {
            DicomEngine.Startup();

            using (RasterCodecs codecs = new RasterCodecs())
            {
               RasterImage _image;
               _applyToAll = false;

               _medicalViewer = new MedicalViewer(1, 2);
               _medicalViewer.Location = new Point(0, 0);
               _medicalViewer.Size = new Size(this.ClientRectangle.Right, this.ClientRectangle.Bottom);
               _medicalViewer.Cells.ItemAdded += new EventHandler<MedicalViewerCollectionEventArgs<MedicalViewerBaseCell>>(Cells_ItemAdded);

               _mainPanel.Controls.Add(_medicalViewer);

               DefaultImagesDialog defaultDialog = new DefaultImagesDialog();


               if (defaultDialog.ShowDialog() == DialogResult.Yes)
               {
                  string imagesFolder;
#if LT_CLICKONCE
               imagesFolder = Application.StartupPath; 
#else
                  imagesFolder = DemosGlobal.ImagesFolder;
#endif // LT_CLICKONCE

                  string fileName = Path.Combine(imagesFolder, "xa.dcm");
                  if (File.Exists(fileName))
                  {
                     SeriesInformation seriesInformation = LoadSeries(fileName);
                     _image = seriesInformation.Image;

                     if (_image != null)
                     {
                        MedicalViewerMultiCell cell = new MedicalViewerMultiCell(_image, false, 1, 1);
                        _medicalViewer.Cells.Add(cell);

                        cell.Image = _image;
                        cell.ApplyActionOnMove = true;

                        cell.SetScaleMode(MedicalViewerScaleMode.Fit);

                        SetCellTags(cell, seriesInformation);

                        InitializeCell(cell);
                        InitAutomation(cell);
                        InitializeAutomationManager(cell);
                        InitializeEvents(cell);

                     }
                  }

                  fileName = Path.Combine(imagesFolder, "mr.dcm");

                  if (File.Exists(fileName))
                  {
                     SeriesInformation seriesInformation = LoadSeries(fileName);
                     _image = seriesInformation.Image;

                     if (_image != null)
                     {
                        MedicalViewerMultiCell cell = new MedicalViewerMultiCell(_image, true, 1, 1);
                        _medicalViewer.Cells.Add(cell);

                        cell.Image = _image;
                        cell.FitImageToCell = true;

                        SetCellTags(cell, seriesInformation);

                        cell.Rows = 2;
                        cell.Columns = 2;
                        cell.ApplyActionOnMove = true;
                        InitializeCell(cell);
                        InitAutomation(cell);
                        InitializeAutomationManager(cell);
                        InitializeEvents(cell);
                     }
                  }

               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.Source);
         }
      }

      void _medicalViewer_DeleteCell(object sender, MedicalViewerDeleteEventArgs e)
      {
         int i = 0;
         for (i = e.CellIndexes.Length - 1; i >= 0; i--)
         {

            MedicalViewerMultiCell cell = (MedicalViewerMultiCell)_medicalViewer.Cells[e.CellIndexes[i]];

            if (cell.Equals(_enhImageCell))
               _enhImageCell = null;
            else if (cell.Equals(_avgImageCell))
               _avgImageCell = null;

            if (_orignalImagesList[e.CellIndexes[i]] != null)
            {
               foreach (RasterImage image in _orignalImagesList[e.CellIndexes[i]])
               {
                  if (image != null)
                     image.Dispose();
               }
            }
            _orignalImagesList.RemoveAt(e.CellIndexes[i]);

         }
      }

      private void InitializeEvents(MedicalViewerMultiCell cell)
      {
#if LEADTOOLS_V19_OR_LATER
         cell.Automation.Draw += new EventHandler<AnnDrawDesignerEventArgs>(Automation_Draw);
         cell.KeepDrawingAnnotation = true;
#endif
         cell.SpyGlassStarted += new EventHandler<MedicalViewerSpyGlassStartedEventArgs>(cell_SpyGlassStarted);
         cell.AnnotationCreated += new EventHandler<MedicalViewerAnnotationCreatedEventArgs>(cell_AnnotationCreated);
         cell.DeleteAnnotation += new EventHandler<MedicalViewerDeleteEventArgs>(cell_DeleteAnnotation);
         AddProbeToolEvents(cell);

      }

      void cell_DeleteAnnotation(object sender, MedicalViewerDeleteEventArgs e)
      {
         ((MedicalViewerMultiCell)sender).RefreshAnnotation();
      }

      private void InitializeAutomationManager(MedicalViewerMultiCell cell)
      {
         AnnAutomation automation = cell.Automation;
         automation.OnShowContextMenu += new EventHandler<AnnAutomationEventArgs>(automation_OnShowContextMenu);
      }

      private static void InitializeCell(MedicalViewerCell cell)
      {
         cell.InteractiveInterpolation = true;

         Array enums = Enum.GetValues(typeof(MedicalViewerActionType));

         foreach (MedicalViewerActionType action in enums)
         {
            if (action != MedicalViewerActionType.None)
            {
               if (cell.CanExecuteAction(action))
                  cell.AddAction(action);
            }
         }

         cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
         cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active);
         cell.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Middle, MedicalViewerActionFlags.Active);
         cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active);
         _leftButtonAction = MedicalViewerActionType.WindowLevel;
         _rightButtonAction = MedicalViewerActionType.Offset;

         MedicalViewerKeys medicalKeys = new MedicalViewerKeys();
         medicalKeys.MouseDown = Keys.Down;
         medicalKeys.MouseUp = Keys.Up;
         medicalKeys.MouseLeft = Keys.Left;
         medicalKeys.MouseRight = Keys.Right;
         cell.SetActionKeys(MedicalViewerActionType.Offset, medicalKeys);
         medicalKeys.Modifiers = MedicalViewerModifiers.Ctrl;
         cell.SetActionKeys(MedicalViewerActionType.WindowLevel, medicalKeys);
         medicalKeys.Modifiers = MedicalViewerModifiers.None;
         medicalKeys.MouseDown = Keys.PageDown;
         medicalKeys.MouseUp = Keys.PageUp;
         cell.SetActionKeys(MedicalViewerActionType.Stack, medicalKeys);
         medicalKeys.MouseDown = Keys.Add;
         medicalKeys.MouseUp = Keys.Subtract;
         cell.SetActionKeys(MedicalViewerActionType.Scale, medicalKeys);

         MedicalViewerWindowLevel windowLevel = (MedicalViewerWindowLevel)(cell.GetActionProperties(MedicalViewerActionType.WindowLevel));
         windowLevel.RelativeSensitivity = true;
         cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevel);
         cell.AlwaysInterpolate = true;
         cell.CellBackColor = Color.Black;

      }


      private void cell_SpyGlassStarted(object sender, MedicalViewerSpyGlassStartedEventArgs e)
      {
         MedicalViewer medicalViewer = this.Viewer;

         RasterImage image = e.Image;

         if (image.UseLookupTable)
         {
            RasterColor16[] colors = image.GetLookupTable16();
            int length = colors.Length;
            int counter;

            for (counter = 0; counter < length; counter++)
            {
               colors[counter].R ^= 0xffff;
               colors[counter].G ^= 0xffff;
               colors[counter].B ^= 0xffff;
            }

            image.SetLookupTable16(colors);
         }
         else
         {
            RasterColor[] colors = image.GetPalette();
            if (colors == null)
            {
               if (image.HasRegion)
                  image.MakeRegionEmpty();
               InvertCommand invert = new InvertCommand();
               invert.Run(image);
            }
            else
            {
               int length = colors.Length;
               int counter;

               for (counter = 0; counter < length; counter++)
               {
                  colors[counter].R ^= 0xff;
                  colors[counter].G ^= 0xff;
                  colors[counter].B ^= 0xff;
               }

               image.SetPalette(colors, 0, length);
            }
         }
      }

      private void _printDocument_BeginPrint(object sender, PrintEventArgs e)
      {
         // This demo only prints one page at a time, so there is no need to re-start the print page number
      }

      private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
      {
         ColorResolutionCommand colorResolutionCommand = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, 24, RasterByteOrder.Bgr, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.None, null);
         colorResolutionCommand.Run(PrintImage);

         // Get the print document object
         PrintDocument document = sender as PrintDocument;

         // Create an new LEADTOOLS image printer class
         Leadtools.Controls.RasterImagePrinter printer = new Leadtools.Controls.RasterImagePrinter();

         // Set the document object so page calculations can be performed
         printer.PrintDocument = document;

         // We want to fit and center the image into the maximum print area
         printer.SizeMode = RasterPaintSizeMode.FitAlways;
         printer.HorizontalAlignMode = RasterPaintAlignMode.Center;
         printer.VerticalAlignMode = RasterPaintAlignMode.Center;

         // Account for FAX images that may have different horizontal and vertical resolution
         printer.UseDpi = true;

         // Print the whole image
         printer.ImageRectangle = Rectangle.Empty;

         // Use maximum page dimension ignoring the margins, this will be equivalant of printing
         // using Windows Photo Gallery
         printer.PageRectangle = RectangleF.Empty;
         printer.UseMargins = false;

         // Print the current page
         printer.Print(PrintImage, PrintImage.Page, e);

         // Inform the printer we have no more pages to print
         e.HasMorePages = false;
      }

      private void _printDocument_EndPrint(object sender, PrintEventArgs e)
      {
         // Nothing to do here
      }

      public bool ApplyToAll
      {
         get { return _applyToAll; }
         set { _applyToAll = value; }
      }

      public int CellIndex
      {
         get
         {
            return _cellIndex;
         }
         set
         {
            _cellIndex = value;
         }
      }

      public int Images
      {
         get
         {
            return _images;
         }

         set
         {
            _images = value;
         }
      }

      public MedicalViewer Viewer
      {
         get
         {
            return _medicalViewer;
         }
      }

      public void RemoveSelectedCells()
      {
         int currentCellIndex = 0;
         while (currentCellIndex < Viewer.Cells.Count)
         {
            MedicalViewerMultiCell cell = (MedicalViewerMultiCell)Viewer.Cells[currentCellIndex];
            if (cell.Selected)
            {
               Viewer.Cells.RemoveAt(currentCellIndex);
               cell.Dispose();
            }
            else
               ++currentCellIndex;
         }
      }

      private void MainForm_Resize(object sender, EventArgs e)
      {
         int toolbar = 0;

         if (_managerHelper != null)
         {
            if (_managerHelper.ToolBar != null)
            {
               toolbar = _managerHelper.ToolBar.Width;
            }
         }

         if (_medicalViewer != null)
            _medicalViewer.Size = new Size(_mainPanel.ClientRectangle.Right - toolbar, _mainPanel.ClientRectangle.Bottom);
      }

      private void _miEditRemoveSelectedCells_Click(object sender, EventArgs e)
      {
         RemoveSelectedCells();
      }

      private void _miEditSelectAll_Click(object sender, EventArgs e)
      {
         if (_medicalViewer != null)
            _medicalViewer.Cells.SelectAll(true);
      }

      private void _miEditDeselectAll_Click(object sender, EventArgs e)
      {
         if (_medicalViewer != null)
            _medicalViewer.Cells.SelectAll(false);
      }

      private void _miEditInvertSelection_Click(object sender, EventArgs e)
      {
         if (_medicalViewer != null)
            _medicalViewer.Cells.InvertSelection();
      }


      private void ShowModlessDialog(bool show)
      {

         if (_stentDialog != null)
            _stentDialog.Visible = show;

         if (_modifyStentDlg != null)
            _modifyStentDlg.Visible = show;

         if (_alignmentDlg != null)
            _alignmentDlg.Visible = show;

      }

      private DialogResult ShowViewerDialogs(Form Dialog)
      {
         DialogResult dialogResult;

         ShowModlessDialog(false);

         dialogResult = Dialog.ShowDialog(this);

         ShowModlessDialog(true);

         return dialogResult;
      }

      public int GetCellIndex(MedicalViewerCell cell)
      {
         return _medicalViewer.Cells.IndexOf(cell);
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


      // Open "LEAD Open File Dialog" and return the selected image
      private SeriesInformation LoadSeries(string imagePath)
      {
         ImageFileLoader loader = null;
         int firstPage = 1;
         int lastPage = -1;

         try
         {
            if (string.IsNullOrEmpty(imagePath))
            {
               loader = new ImageFileLoader();
               loader.ShowLoadPagesDialog = true;

               using (RasterCodecs codecs = new RasterCodecs())
               {
                  if (loader.Load(this, codecs, false) > 0)
                  {
                     imagePath = loader.FileName;
                     firstPage = loader.FirstPage;
                     lastPage = loader.LastPage;
                  }
               }
            }


            return LoadDICOM(imagePath, firstPage, lastPage);
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }

         return null;
      }

      private RasterImage GetImage(DicomDataSet dicomDataSet, string imagePath, int firstPage, int lastPage)
      {
         _images = 1;
         CounterDialog counter = new CounterDialog(this, null);
         counter.Show(this);
         counter.Update();

         try
         {
            int iconsCount = 0;

            dicomDataSet.Load(imagePath, DicomDataSetLoadFlags.None);

            if (lastPage == -1)
               lastPage = dicomDataSet.GetImageCount(null);

            if (dicomDataSet.GetImageCount(null) == 0)
            {
               if (counter.Visible)
                  counter.Close();
               return GetRasterImage(imagePath, firstPage, lastPage);
            }

            DicomElement imageSeqElement = dicomDataSet.FindFirstElement(null, DicomTag.IconImageSequence, true);

            if (imageSeqElement != null)
            {
               DicomElement item = dicomDataSet.GetChildElement(imageSeqElement, true);

               DicomElement itemChild = dicomDataSet.GetChildElement(item, true);

               DicomElement pixelDataElement = dicomDataSet.FindFirstElement(itemChild, DicomTag.PixelData, true);

               iconsCount = dicomDataSet.GetImageCount(pixelDataElement);
            }

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

            RasterImage image = dicomDataSet.GetImage(null, firstPage - 1 + iconsCount, 0, RasterByteOrder.Gray, getImageFlags);

            counter.UpdateCounterPercent(firstPage, lastPage - firstPage + 1, firstPage, true);
            Application.DoEvents();

            for (int i = firstPage + iconsCount; i <= lastPage + iconsCount - 1; i++)
            {
               image.AddPage(dicomDataSet.GetImage(null, i, 0, RasterByteOrder.Gray, getImageFlags));
               counter.UpdateCounterPercent(i + iconsCount + 1, lastPage - firstPage + 1, firstPage, true);
               Application.DoEvents();
            }

            return image;

         }
         catch (Exception)
         {
            if (counter.Visible)
               counter.Close();

            return GetRasterImage(imagePath, firstPage, lastPage);
         }
      }

      private RasterImage GetRasterImage(string imagePath, int firstPage, int lastPage)
      {
         using (RasterCodecs codecs = new RasterCodecs())
         {
            RasterImage image = null;
            _images = 1;
            CounterDialog counter = new CounterDialog(this, codecs);
            counter.Show(this);
            counter.Update();

            try
            {
               image = codecs.Load(imagePath, 0, CodecsLoadByteOrder.BgrOrGrayOrRomm, firstPage, lastPage);
            }
            catch (Exception)
            {
               if (counter.Visible)
                  counter.Close();
            }

            return image;
         }
      }
      // Load the DICOM file
      private SeriesInformation LoadDICOM(string imagePath, int firstPage, int lastPage)
      {
         try
         {
            SeriesInformation seriesInformation = new SeriesInformation();

            using(DicomDataSet dicomDataSet = new DicomDataSet())
            {
               seriesInformation.Image = GetImage(dicomDataSet, imagePath, firstPage, lastPage);
               if (seriesInformation.Image == null)
               {
                  dicomDataSet.Dispose();
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
               seriesInformation.StudyDescription = GetDicomTag(dicomDataSet, DicomTag.StudyDescription);
               seriesInformation.SeriesDescription = GetDicomTag(dicomDataSet, DicomTag.SeriesDescription);
               seriesInformation.SeriesNumber = GetDicomTag(dicomDataSet, DicomTag.SeriesNumber);
               seriesInformation.ImageComments = GetDicomTag(dicomDataSet, DicomTag.ImageComments);
               seriesInformation.PhotometricInterpretation = GetDicomTag(dicomDataSet, DicomTag.PhotometricInterpretation);
            }
            return seriesInformation;
         }
         catch (System.Exception ex)
         {
            Messager.Show(this, ex, MessageBoxIcon.Exclamation);
         }

         return null;
      }


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

      private void _fileMenuItem_insertCell_Click(object sender, EventArgs e)
      {
         try
         {
            if (ShowViewerDialogs(new InsertCellDialog(this)) == DialogResult.OK)
            {
               MedicalViewer medicalViewer = this.Viewer;
               SeriesInformation seriesInformation = LoadSeries(null);

               if (seriesInformation == null)
                  return;

               RasterImage image = seriesInformation.Image;

               // Insert new cell if the user has selected an image.
               if (image != null)
               {
                  MedicalViewerMultiCell cell = new MedicalViewerMultiCell(image, false, 1, 1);

                  if (!string.IsNullOrEmpty(seriesInformation.PhotometricInterpretation))
                     cell.PhotometricInterpretation = seriesInformation.PhotometricInterpretation;

                  int index;
                  if (CellIndex != -1)
                  {
                     index = CellIndex;
                     medicalViewer.Cells.Insert(index, cell);
                  }
                  else
                  {
                     index = medicalViewer.Cells.Count;
                     medicalViewer.Cells.Add(cell);
                  }
                  cell.Image = image;
                  cell.SetScaleMode(MedicalViewerScaleMode.Fit);

                  SetCellTags(cell, seriesInformation);

                  InitializeCell(cell);
                  InitAutomation(cell);
                  InitializeAutomationManager(cell);

                  InitializeEvents(cell);
                  CopyPropertiesFromGlobalCell(cell);

                  ApplyToCell(cell);
                  MainForm_Resize(this, EventArgs.Empty);
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void SetCellTags(MedicalViewerCell cell, SeriesInformation seriesInformation)
      {
         cell.SetTag(0, MedicalViewerTagAlignment.TopCenter, MedicalViewerTagType.TopOrientation);


         cell.SetTag(0, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Frame);

         cell.SetTag(1, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData,
            String.Format("Acc#: {0}", (!String.IsNullOrEmpty(seriesInformation.AccessionNumber) ? seriesInformation.AccessionNumber : "AccessionNumber")));

         cell.SetTag(2, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData,
            String.Format("Study Date: {0}", (!String.IsNullOrEmpty(seriesInformation.StudyDate) ? seriesInformation.StudyDate : "StudyDate")));

         cell.SetTag(3, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData,
            String.Format("Study: {0}", (!String.IsNullOrEmpty(seriesInformation.StudyDescription) ? seriesInformation.StudyDescription : "StudyDescription")));

         cell.SetTag(4, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData,
            String.Format("Series: {0}", (!String.IsNullOrEmpty(seriesInformation.SeriesDescription) ? seriesInformation.SeriesDescription : "SeriesDescription")));

         cell.SetTag(5, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData,
           String.Format("Se#: {0}", (!String.IsNullOrEmpty(seriesInformation.SeriesNumber) ? seriesInformation.SeriesNumber : "SeriesNumber")));


         cell.SetTag(0, MedicalViewerTagAlignment.LeftCenter, MedicalViewerTagType.LeftOrientation);
         cell.SetTag(0, MedicalViewerTagAlignment.RightCenter, MedicalViewerTagType.RightOrientation);

         if (seriesInformation.Image.GrayscaleMode != RasterGrayscaleMode.None)
            cell.SetTag(1, MedicalViewerTagAlignment.LeftCenter, MedicalViewerTagType.WindowLevelData);


         cell.SetTag(0, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData,
            String.Format("Name: {0}", (!String.IsNullOrEmpty(seriesInformation.PatientName) ? seriesInformation.PatientName : "PatientName")));

         cell.SetTag(1, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData,
            String.Format("PID: {0}", (!String.IsNullOrEmpty(seriesInformation.PatientID) ? seriesInformation.PatientID : "PatientID")));

         cell.SetTag(2, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData,
            String.Format("Sex: {0}", (!String.IsNullOrEmpty(seriesInformation.PatientSex) ? seriesInformation.PatientSex : "PatientSex")));

         cell.SetTag(3, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData,
            String.Format("DOB: {0}", (!String.IsNullOrEmpty(seriesInformation.PatientBirthDate) ? seriesInformation.PatientBirthDate : "PatientBirthDate")));

         cell.SetTag(0, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.RulerUnit);
         cell.SetTag(1, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.Scale);

         cell.SetTag(0, MedicalViewerTagAlignment.BottomCenter, MedicalViewerTagType.BottomOrientation);
      }

      private void _fileMenuItem_exit_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void _miEditFreezeCell_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new FreezeCellDialog(this));
      }

      private void _miEditToggleFreeze_Click(object sender, EventArgs e)
      {
         if (_medicalViewer != null)
         {
            foreach (MedicalViewerCell cell in _medicalViewer.Cells)
            {
               if (cell.Selected)
                  cell.Frozen = !cell.Frozen;
            }
         }
      }

      private void _miPropertiesViewerProperties_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new ViewerPropertiesDialog(this));
      }

      private void _miPropertiesCellProperties_Click(object sender, EventArgs e)
      {
         bool selected = false;
         int i = 0;
         while (!selected && i < this.Viewer.Cells.Count)
         {
            if (((MedicalViewerMultiCell)this.Viewer.Cells[i]).Selected)
               selected = true;
            else
               ++i;
         }
         ShowViewerDialogs(new CellPropertiesDialog(this, i));
      }

      private void _miActionWindowLevelSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.WindowLevel));
      }

      private void _miActionAlphaSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.Alpha));
      }

      private void _miActionScaleSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.Scale));
      }

      private void _miMagnifySet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.MagnifyGlass));
      }

      private void _miActionStackSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.Stack));
      }

      private void _miActionOffsetSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.Offset));
      }

      private void setToolStripMenuItem6_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.RectangleRegion));
      }

      private void _miRegionEllipseSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.EllipseRegion));
      }

      private void _miRegionSquareSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.SquareRegion));
      }

      private void _miRegionCircleSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.CircleRegion));
      }

      private void _miRegionPolygonSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.PolygonRegion));
      }

      private void _miRegionFreeHandSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.FreeHandRegion));
      }

      private void _miRegionMagicWandSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.MagicWandRegion));
      }

      private void _miRegionColorRangeSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.ColorRangeRegion));
      }

      private void _miAnnotationRectangleSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.AnnotationRectangle, true));
      }

      private void _miAnnotationEllipseSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.AnnotationEllipse, true));
      }

      private void _miAnnotationArrowSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.AnnotationArrow, true));
      }

      private void _miAnnotationTextSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.AnnotationText, true));
      }

      private void _miAnnotationAngleSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.AnnotationAngle, true));
      }

      private void _miAnnotationHiliteSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.AnnotationHilite, true));
      }

      private void _miActionWindowLevelCustomize_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new WindowLevelPropertiesDialog(this, GetSelectedCell()));
      }

      // This method add a key list to the specifid combo box
      public void AddKeysToCombo(ComboBox keyComboBox, Keys currentKey)
      {
         #region Added keys
         Keys[] keys =
         {
            Keys.None,
            Keys.Space,
            Keys.PageUp,
            Keys.PageDown,
            Keys.End,
            Keys.Home,
            Keys.Left,
            Keys.Up,
            Keys.Right,
            Keys.Down,
            Keys.PrintScreen,
            Keys.Insert,
            Keys.Delete,
            Keys.D0,
            Keys.D1,
            Keys.D2,
            Keys.D3,
            Keys.D4,
            Keys.D5,
            Keys.D6,
            Keys.D7,
            Keys.D8,
            Keys.D9,
            Keys.A,
            Keys.B,
            Keys.C,
            Keys.D,
            Keys.E,
            Keys.F,
            Keys.G,
            Keys.H,
            Keys.I,
            Keys.J,
            Keys.K,
            Keys.L,
            Keys.M,
            Keys.N,
            Keys.O,
            Keys.P,
            Keys.Q,
            Keys.R,
            Keys.S,
            Keys.T,
            Keys.U,
            Keys.V,
            Keys.W,
            Keys.X,
            Keys.Y,
            Keys.Z,
            Keys.NumPad0,
            Keys.NumPad1,
            Keys.NumPad2,
            Keys.NumPad3,
            Keys.NumPad4,
            Keys.NumPad5,
            Keys.NumPad6,
            Keys.NumPad7,
            Keys.NumPad8,
            Keys.NumPad9,
            Keys.Multiply,
            Keys.Add,
            Keys.Subtract,
            Keys.Decimal,
            Keys.F1,
            Keys.F2,
            Keys.F3,
            Keys.F4,
            Keys.F5,
            Keys.F6,
            Keys.F7,
            Keys.F8,
            Keys.F9,
            Keys.F10,
            Keys.F11,
            Keys.F12
         };

         foreach (Keys key in keys)
            keyComboBox.Items.Add(key);

         keyComboBox.SelectedIndex = keyComboBox.Items.IndexOf(currentKey);
         #endregion
      }

      public void AddModifiersToCombo(ComboBox keyComboBox, MedicalViewerModifiers currentKey)
      {
         #region Added modifiers
         MedicalViewerModifiers[] modifiers =
         {
            MedicalViewerModifiers.None,
            MedicalViewerModifiers.Ctrl,
            MedicalViewerModifiers.Alt
         };

         foreach (MedicalViewerModifiers modifier in modifiers)
            keyComboBox.Items.Add(modifier);

         keyComboBox.SelectedIndex = keyComboBox.Items.IndexOf(currentKey);
         #endregion
      }

      public int GetIndex(ComboBox combo, NumericTextBox text)
      {
         if (combo.Text == "None")
            return -3;
         else if (combo.Text == "Selected")
            return -2;
         else if (combo.Text == "All")
            return -1;
         else
            return text.Value;
      }

      public bool IsThereASelectedCell()
      {
         int index = 0;
         while (index < Viewer.Cells.Count)
         {
            if (((MedicalViewerMultiCell)Viewer.Cells[index]).Selected)
               return true;
            else
               index++;
         }
         return false;
      }

      private MedicalViewerCell GetSelectedCell()
      {
         if (_medicalViewer != null)
         {
            foreach (MedicalViewerCell cell in _medicalViewer.Cells)
            {
               if (cell.Selected)
                  return cell;
            }
         }
         return null;
      }

      public int SearchForFirstSelected()
      {
         int index = 0;
         bool found = false;

         while (!found && index < Viewer.Cells.Count)
         {
            if (((MedicalViewerMultiCell)Viewer.Cells[index]).Selected)
               found = true;
            else
               index++;
         }
         return found ? index : ((Viewer.Cells.Count != 0) ? 0 : -1);
      }

      private void _miActionScaleCustomizeScale_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new ScalePropertiesDialog(this, GetSelectedCell()));
      }

      private void _miActionMagnifyCustomizeMagnify_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new MagnifyGlassProperties(this, GetSelectedCell()));
      }

      private void _miActionStackCustomizeStack_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new StackPropertiesDialog(this, GetSelectedCell()));
      }

      private void _miActionOffsetCustomizeOffset_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new OffsetPropertiesDialog(this, GetSelectedCell()));
      }

      private void _miAnnotationTextCustomizeText_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new TextAnnotationDialog(this));
      }

      private void _miAnnotationRectangleCustomizeRectangle_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new RectangleAnnotationDialog(this));
      }

      private void _miAnnotationEllipseCustomizeEllipse_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new EllipseAnnotationDialog(this));
      }

      private void _miActionArrowCustomizeArrow_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new ArrowAnnotationDialog(this));
      }

      private void _miAnnotationAngleCustomizeAngle_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new AngleAnnotationDialog(this));
      }

      private void _miAnnotationHiliteCustomizeHilite_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new HiliteAnnotationDialog(this));
      }

      private void _miStatisticsStatistics_Click(object sender, EventArgs e)
      {

         ShowViewerDialogs(new StatisticsDialog(this));
      }

      private void _miAnnotationRulerSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.AnnotationRuler));
      }

      private void _miAnnotationRulerCustomize_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new RulerAnnotationDialog(this));
      }

      private void _miEditAnimation_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new AnimationDialog(this, SearchForFirstSelected()));
      }

      public static void ShowColorDialog(Label label)
      {
         ColorDialog colorDlg = new ColorDialog();

         colorDlg.Color = label.BackColor;
         if (colorDlg.ShowDialog() == DialogResult.OK)
         {
            label.BackColor = colorDlg.Color;
         }
      }

      private void ApplyFilter(RasterCommand command)
      {
         // This will apply the command to all selected cells.
         foreach (MedicalViewerCell cell in Viewer.Cells)
         {
            if (cell.Selected)
            {
               // Check whether to apply the command to all the image pages or only of the active page
               if (_miEffectOptionsApplyToAllSubCells.Checked)
               {
                  // Apply the command to all the image pages
                  int index;
                  for (index = 1; index <= cell.Image.PageCount; index++)
                  {
                     cell.Image.Page = index;
                     command.Run(cell.Image);
                     if (command is FlipCommand)
                     {
                        FlipCommand flip = (FlipCommand)command;
                        if (flip.Horizontal)
                           ((MedicalViewerMultiCell)cell).ReverseAnnotationContainer(index - 1);
                        else
                           ((MedicalViewerMultiCell)cell).FlipAnnotationContainer(index - 1);
                     }
                  }
               }
               else
               {
                  // Apply the command to only the active page.
                  MedicalViewerStack stack = (MedicalViewerStack)cell.GetActionProperties(MedicalViewerActionType.Stack, Viewer.Cells.IndexOf(cell));
                  cell.Image.Page = stack.ScrollValue + stack.ActiveSubCell + 1;
                  command.Run(cell.Image);
                  if (command is FlipCommand)
                  {
                     FlipCommand flip = (FlipCommand)command;
                     if (flip.Horizontal)
                        cell.ReverseAnnotationContainer();
                     else
                        cell.FlipAnnotationContainer();
                  }

               }
#if LEADTOOLS_V19_OR_LATER
               if (command is FlipCommand)
               {
                  if (_templateCell != null && _templateCell == cell && _templateList != null)
                  {
                     int idx;
                     for (idx = 0; idx < _templateList.Count; idx++)
                     {
                        int Y = (!((FlipCommand)command).Horizontal) ? _templateCell.Image.Height - _templateList[idx].Y : _templateList[idx].Y;
                        int X = (((FlipCommand)command).Horizontal) ? _templateCell.Image.Width - _templateList[idx].X : _templateList[idx].X;
                        _templateList.RemoveAt(idx);
                        _templateList.Insert(idx, new LeadPoint(X, Y));
                     }
                  }
                  else if (_referenceCell != null && _referenceCell == cell && _referenceList != null)
                  {
                     int idx;
                     for (idx = 0; idx < _referenceList.Count; idx++)
                     {
                        int Y = (!((FlipCommand)command).Horizontal) ? _referenceCell.Image.Height - _referenceList[idx].Y : _referenceList[idx].Y;
                        int X = (((FlipCommand)command).Horizontal) ? _referenceCell.Image.Width - _referenceList[idx].X : _referenceList[idx].X;
                        _referenceList.RemoveAt(idx);
                        _referenceList.Insert(idx, new LeadPoint(X, Y));
                     }
                  }
               }
#endif
               // Redraw the cell to adopt the new changes.
               cell.Invalidate();
               cell.Automation.Invalidate(LeadRectD.Empty);
            }
         }
      }

      private void _editMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         bool selected = IsThereASelectedCell();
         bool enabled = Viewer.Cells.Count != 0;
         _miEditCalibrateRuler.Enabled = enabled;
         _miEditConvertAnnotationToRegion.Enabled = enabled;
         _miEditAnimation.Enabled = enabled;
         _miEditFreezeCell.Enabled = enabled;
         _miEditToggleFreeze.Enabled = enabled && selected;
         _miEditSelectAll.Enabled = enabled;
         _miEditDeselectAll.Enabled = enabled && selected;
         _miEditInvertSelection.Enabled = enabled;
         _miEditRepositionCell.Enabled = (Viewer.Cells.Count > 1);
         _miEditRemoveCell.Enabled = enabled;
         _miEditRemoveSelectedCells.Enabled = enabled;

         if (enabled)
         {
            int index = 0;
            bool rulerFound = false;
            bool selectedAnnotationFound = false;
            MedicalViewerAnnotationAttributes annotationAttributes;

            MedicalViewerMultiCell cell;
            // search if there is at least one selected ruler, or one selected closed shape annotation object (Rectangle, Ellipse or Hilite).
            for (index = 0; index < Viewer.Cells.Count; ++index)
            {
               cell = ((MedicalViewerMultiCell)Viewer.Cells[index]);
               // Get the selected annotation object of the cell.
               annotationAttributes = cell.GetSelectedAnnotationAttributes(-2);

               // Check the type of the selected annotation object.
               if (annotationAttributes.Type != MedicalViewerActionType.None)
               {
                  switch (annotationAttributes.Type)
                  {
                     case MedicalViewerActionType.AnnotationRectangle:
                     case MedicalViewerActionType.AnnotationEllipse:
                     case MedicalViewerActionType.AnnotationHilite:
                        {
                           AnnRectangleObject AnnRectObj = cell.Automation.CurrentEditObject as AnnRectangleObject;
                           if (Math.Abs(AnnRectObj.Angle) < 0.1)
                              selectedAnnotationFound = true;
                        }
                        break;
                     case MedicalViewerActionType.AnnotationRuler:
                        rulerFound = true;
                        break;
                  }
               }
               // If both (ruler) & closed shape annotation object are found, then there is no need for more searching.
               if (selectedAnnotationFound && rulerFound)
                  break;
            }

            _miEditCalibrateRuler.Enabled = rulerFound;
            _miEditConvertAnnotationToRegion.Enabled = selectedAnnotationFound;
         }
      }

      private void _miEffectOptionsApplyToAllSubCells_Click(object sender, EventArgs e)
      {
         _miEffectOptionsApplyToAllSubCells.Checked = !_miEffectOptionsApplyToAllSubCells.Checked;
      }

      private void _miEffectInvert_Click(object sender, EventArgs e)
      {

         int cellIndex;
         MedicalViewerMultiCell cell = null;
         for (cellIndex = 0; cellIndex < Viewer.Cells.Count; cellIndex++)
         {
            cell = ((MedicalViewerMultiCell)Viewer.Cells[cellIndex]);
            if (cell.Selected)
            {
               // Check whether to apply the Invert to all the image pages or only on the active page
               if (_miEffectOptionsApplyToAllSubCells.Checked)
               {
                  // Apply the command to all the image pages
                  ((MedicalViewerMultiCell)Viewer.Cells[cellIndex]).InvertImage();
               }
               else
               {
                  // Apply the command to only the active page.
                  MedicalViewerStack stack = (MedicalViewerStack)cell.GetActionProperties(MedicalViewerActionType.Stack, cellIndex);
                  ((MedicalViewerMultiCell)Viewer.Cells[cellIndex]).InvertImage(stack.ScrollValue + stack.ActiveSubCell);
               }
            }
         }
      }

      private void _miEffectReverse_Click(object sender, EventArgs e)
      {
         ApplyFilter(new FlipCommand(true));
      }

      private void _miEffectFlip_Click(object sender, EventArgs e)
      {
         ApplyFilter(new FlipCommand(false));
      }

      private void _miHelpAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Medical Viewer", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _propertiesMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         bool enabled = Viewer.Cells.Count != 0;
         _miPropertiesCellProperties.Enabled = enabled;
      }

      void _fileMenuItem_DropDownOpening(object sender, System.EventArgs e)
      {
         bool enabled = (Viewer.Cells.Count != 0) && IsThereASelectedCell();
         saveToolStripMenuItem.Enabled = _printCellMenuItem.Enabled = enabled;
      }

      void loadAnnotationsToolStripMenuItem_DropDownOpening(object sender, System.EventArgs e)
      {
         bool enabled = (Viewer.Cells.Count != 0) && IsThereASelectedCell();
         selectedCellsToolStripMenuItem1.Enabled = enabled;
         allCellToolStripMenuItem.Enabled = (Viewer.Cells.Count != 0);
      }

      void saveAnnotationsToolStripMenuItem_DropDownOpening(object sender, System.EventArgs e)
      {
         bool enabled = (Viewer.Cells.Count != 0) && IsThereASelectedCell();
         selectedCellsToolStripMenuItem.Enabled = enabled;
         allCellsToolStripMenuItem.Enabled = (Viewer.Cells.Count != 0);
      }

      void saveRegionsToolStripMenuItem_DropDownOpening(object sender, System.EventArgs e)
      {
         bool enabled = (Viewer.Cells.Count != 0) && IsThereASelectedCell();
         selectedCellsToolStripMenuItem2.Enabled = enabled;
         allCellsToolStripMenuItem1.Enabled = (Viewer.Cells.Count != 0);
      }

      void loadRegionsToolStripMenuItem_DropDownOpening(object sender, System.EventArgs e)
      {
         bool enabled = (Viewer.Cells.Count != 0) && IsThereASelectedCell();
         selectedCellsToolStripMenuItem3.Enabled = enabled;
         allCellsToolStripMenuItem2.Enabled = (Viewer.Cells.Count != 0);
      }



      private void __transformMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)GetSelectedCell();
         bool enabled = (Viewer.Cells.Count != 0) && IsThereASelectedCell() && !cell.Frozen;

         _miEffectInvert.Enabled = enabled;
         if (_stentDialog != null)
            enabled = enabled && !_stentDialog.Visible;
         _miEffectFlip.Enabled = enabled;
         _miEffectReverse.Enabled = enabled;
         _miRotate.Enabled = enabled;
      }

      private void _miActionAlphaCustomizeAlpha_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new AlphaPropertiesDialog(this, GetSelectedCell()));
      }

      private void _miEditRemoveCell_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new RemoveCellDialog(this));
      }

      private void _miEditCalibrateRuler_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new CalibrateRulerDialog(this));
      }

      private void _miEditConvertAnnotationToRegion_Click(object sender, EventArgs e)
      {
         foreach (MedicalViewerCell cell in Viewer.Cells)
         {
            if (cell.Selected)
               cell.ConvertAnnotationToRegion(RasterRegionCombineMode.Or, true);
         }
      }

      private void _miEditRepositionCell_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new RepositionCellDialog(this));
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         DicomEngine.Shutdown();
      }

      private void _printCellMenuItem_Click(object sender, EventArgs e)
      {

         ShowViewerDialogs(new PrintCellDialog(this));

      }

      private void setToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetNudgeShrinkActionDialog(this));
      }

      private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
      {

         ShowViewerDialogs(new NudgeShrinkToolDialog(this));

      }

      private void selectedCellsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // saving annotations
         string fileName = ShowSaveDialog(false);
         if (fileName == null || fileName == "")
            return;

         Viewer.SaveAnnotations(fileName, true);
      }

      private string ShowSaveDialog(bool forRegion)
      {
         SaveFileDialog saveDialog = new SaveFileDialog();
         saveDialog.AddExtension = true;
         if (forRegion)
         {
            saveDialog.Filter = "Region Files (*.rgn)|*.rgn";
         }
         else
         {
            saveDialog.Filter = "Annotation Files (*.xml)|*.xml";
         }
         DialogResult result = saveDialog.ShowDialog();
         if (result == DialogResult.OK)
            return saveDialog.FileName;
         else
            return null;
      }

      private string ShowLoadDialog(bool forRegion)
      {
         OpenFileDialog openDialog = new OpenFileDialog();
         if (forRegion)
         {
            openDialog.Filter = "Region Files (*.rgn)|*.rgn";
         }
         else
         {
            openDialog.Filter = "Annotation Files (*.xml)|*.xml";
         }

         DialogResult result = openDialog.ShowDialog();
         if (result == DialogResult.OK)
            return openDialog.FileName;
         else
            return null;
      }

      private void allCellsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         string fileName = ShowSaveDialog(false);
         if (fileName == null || fileName == "")
            return;
         Viewer.SaveAnnotations(fileName, true);
      }

      private void selectedCellsToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         string fileName = ShowLoadDialog(false);
         int count = 1;

         if (fileName != null)
         {
            foreach (MedicalViewerMultiCell cell in Viewer.Cells)
            {
               if (cell.Selected)
               {
                  cell.LoadAnnotations(fileName, -1, count);
                  count += cell.Image.PageCount;
               }
            }
         }
      }

      private void allCellToolStripMenuItem_Click(object sender, EventArgs e)
      {
         string fileName = ShowLoadDialog(false);
         int count = 1;

         if (fileName != null)
         {
            foreach (MedicalViewerMultiCell cell in Viewer.Cells)
            {
               cell.LoadAnnotations(fileName, -1, count);
               count += cell.Image.PageCount;
            }
         }
      }

      private void selectedCellsToolStripMenuItem2_Click(object sender, EventArgs e)
      {
         string fileName = ShowSaveDialog(true);
         int index = 0;

         if (fileName != null)
         {
            foreach (MedicalViewerMultiCell cell in Viewer.Cells)
            {
               if (cell.Selected)
               {
                  if (index == 0)
                     cell.SaveRegion(fileName, -1, 1, MedicalViewerFileOperation.Create);
                  else
                     cell.SaveRegion(fileName, -1, 1, MedicalViewerFileOperation.Append);
                  index++;
               }
            }
         }
      }

      private void allCellsToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         string fileName = ShowSaveDialog(true);
         int index = 0;

         if (fileName != null)
         {
            foreach (MedicalViewerMultiCell cell in Viewer.Cells)
            {
               if (index == 0)
                  cell.SaveRegion(fileName, -1, 1, MedicalViewerFileOperation.Create);
               else
                  cell.SaveRegion(fileName, -1, 1, MedicalViewerFileOperation.Append);
               index++;
            }
         }
      }

      private void selectedCellsToolStripMenuItem3_Click(object sender, EventArgs e)
      {
         string fileName = ShowLoadDialog(true);
         int count = 1;

         if (fileName != null)
         {
            foreach (MedicalViewerMultiCell cell in Viewer.Cells)
            {
               if (cell.Selected)
               {
                  cell.LoadRegion(fileName, -1, count);
                  count += cell.Image.PageCount;
               }
            }
         }
      }

      private void allCellsToolStripMenuItem2_Click(object sender, EventArgs e)
      {
         string fileName = ShowLoadDialog(true);
         int count = 1;

         if (fileName != null)
         {
            foreach (MedicalViewerMultiCell cell in Viewer.Cells)
            {
               cell.LoadRegion(fileName, -1, count);
               count += cell.Image.PageCount;
            }
         }
      }

      public void ApplyToCell(MedicalViewerCell cell)
      {
         int index;
         MedicalViewerIcon icon;
         MedicalViewerIcon cellIcon;
         MedicalViewerCell defaultCell = DefaultCell;


         for (index = 0; index < cell.Titlebar.Icons.Length; index++)
         {
            icon = cell.Titlebar.Icons[index];
            cellIcon = defaultCell.Titlebar.Icons[index];

            if (icon.Visible != cellIcon.Visible)
               icon.Visible = cellIcon.Visible;

            if (icon.Color != cellIcon.Color)
               icon.Color = cellIcon.Color;

            if (icon.ColorPressed != cellIcon.ColorPressed)
               icon.ColorPressed = cellIcon.ColorPressed;

            if (icon.ColorHover != cellIcon.ColorHover)
               icon.ColorHover = cellIcon.ColorHover;

            if (icon.ReadOnly != cellIcon.ReadOnly)
               icon.ReadOnly = cellIcon.ReadOnly;
         }

         if (cell.CellBackColor != defaultCell.CellBackColor)
            cell.CellBackColor = defaultCell.CellBackColor;

         if (cell.TextColor != defaultCell.TextColor)
            cell.TextColor = defaultCell.TextColor;

         if (cell.TextShadowColor != defaultCell.TextShadowColor)
            cell.TextShadowColor = defaultCell.TextShadowColor;

         if (cell.ActiveBorderColor != defaultCell.ActiveBorderColor)
            cell.ActiveBorderColor = defaultCell.ActiveBorderColor;

         if (cell.NonActiveBorderColor != defaultCell.NonActiveBorderColor)
            cell.NonActiveBorderColor = defaultCell.NonActiveBorderColor;

         if (cell.ActiveSubCellBorderColor != defaultCell.ActiveSubCellBorderColor)
            cell.ActiveSubCellBorderColor = defaultCell.ActiveSubCellBorderColor;

         if (cell.RulerInColor != defaultCell.RulerInColor)
            cell.RulerInColor = defaultCell.RulerInColor;

         if (cell.RulerOutColor != defaultCell.RulerOutColor)
            cell.RulerOutColor = defaultCell.RulerOutColor;

         if (cell.Titlebar.UseCustomColor != defaultCell.Titlebar.UseCustomColor)
            cell.Titlebar.UseCustomColor = defaultCell.Titlebar.UseCustomColor;

         if (cell.Titlebar.Color != defaultCell.Titlebar.Color)
            cell.Titlebar.Color = defaultCell.Titlebar.Color;

         if (cell.Titlebar.Visible != defaultCell.Titlebar.Visible)
            cell.Titlebar.Visible = defaultCell.Titlebar.Visible;

         if (cell.TextQuality != defaultCell.TextQuality)
            cell.TextQuality = defaultCell.TextQuality;

         if (cell.RulerStyle != defaultCell.RulerStyle)
            cell.RulerStyle = defaultCell.RulerStyle;

         if (cell.ShowCellScroll != defaultCell.ShowCellScroll)
            cell.ShowCellScroll = defaultCell.ShowCellScroll;

         if (cell.ShowFreezeText != defaultCell.ShowFreezeText)
            cell.ShowFreezeText = defaultCell.ShowFreezeText;

         if (cell.PaintingMethod != defaultCell.PaintingMethod)
            cell.PaintingMethod = defaultCell.PaintingMethod;

         if (cell.MeasurementUnit != defaultCell.MeasurementUnit)
            cell.MeasurementUnit = defaultCell.MeasurementUnit;

         if (cell.BorderStyle != defaultCell.BorderStyle)
            cell.BorderStyle = defaultCell.BorderStyle;


         if (!defaultCell.Cursor.Equals(defaultCell.Cursor))
         {
            cell.Cursor = defaultCell.Cursor;
         }

         if (cell.AnnotationSelectCursor != null)
            if (!defaultCell.AnnotationSelectCursor.Equals(cell.AnnotationSelectCursor))
            {
               cell.AnnotationSelectCursor = defaultCell.AnnotationSelectCursor;
            }

         if (!defaultCell.RegionDefaultCursor.Equals(cell.RegionDefaultCursor))
         {
            cell.RegionDefaultCursor = defaultCell.RegionDefaultCursor;
         }

         if (cell.AnnotationDefaultCursor != null)
            if (!defaultCell.AnnotationDefaultCursor.Equals(cell.AnnotationDefaultCursor))
            {
               cell.AnnotationDefaultCursor = defaultCell.AnnotationDefaultCursor;
            }

         if (cell.AnnotationMoveCursor != null)
            if (!defaultCell.AnnotationMoveCursor.Equals(cell.AnnotationMoveCursor))
            {
               cell.AnnotationMoveCursor = defaultCell.AnnotationMoveCursor;
            }
      }

      public static MedicalViewerMultiCell DefaultCell
      {
         get
         {
            if (_defaultCell == null)
            {
               _defaultCell = new MedicalViewerMultiCell(null, false, 1, 1);
               InitializeCell(_defaultCell);
            }

            return _defaultCell;
         }
      }

      private static void CopyPropertiesFromGlobalCell(MedicalViewerCell cell)
      {
         MedicalViewerActionType actionType;
         MedicalViewerMouseButtons button;
         MedicalViewerActionFlags flags;
         MedicalViewerKeys keys;
         MedicalViewerActionType myEnum = MedicalViewerActionType.SpatialLocator;

         myEnum = MedicalViewerActionType.SpyGlass;


         for (actionType = MedicalViewerActionType.WindowLevel; actionType <= myEnum; actionType++)
         {
            if (!cell.CanExecuteAction(actionType))
               continue;
            button = DefaultCell.GetActionButton(actionType);
            flags = DefaultCell.GetActionFlags(actionType);

            if (button != MedicalViewerMouseButtons.None)
            {
               cell.SetAction(actionType, button, flags);
            }

            keys = DefaultCell.GetActionKeys(actionType);
            cell.SetActionKeys(actionType, keys);

            if (actionType > MedicalViewerActionType.Alpha)
            {
               MedicalViewerBaseAction baseAction = DefaultCell.GetActionProperties(actionType);
               cell.SetActionProperties(actionType, baseAction);
            }
         }

         MedicalViewerWindowLevel windowLevelAction = (MedicalViewerWindowLevel)DefaultCell.GetActionProperties(MedicalViewerActionType.WindowLevel);

         MedicalViewerWindowLevel windowLevel = new MedicalViewerWindowLevel();
         windowLevel.ActionCursor = windowLevelAction.ActionCursor;
         windowLevel.CircularMouseMove = windowLevelAction.CircularMouseMove;
         windowLevel.Sensitivity = windowLevelAction.Sensitivity;

         cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevel);


         MedicalViewerAlpha AlphaAction = (MedicalViewerAlpha)DefaultCell.GetActionProperties(MedicalViewerActionType.Alpha);

         MedicalViewerAlpha Alpha = new MedicalViewerAlpha();
         Alpha.ActionCursor = AlphaAction.ActionCursor;
         Alpha.CircularMouseMove = AlphaAction.CircularMouseMove;
         Alpha.Sensitivity = AlphaAction.Sensitivity;

         cell.SetActionProperties(MedicalViewerActionType.Alpha, Alpha);

         MedicalViewerScale ScaleAction = (MedicalViewerScale)DefaultCell.GetActionProperties(MedicalViewerActionType.Scale);

         MedicalViewerScale Scale = new MedicalViewerScale();
         Scale.ActionCursor = ScaleAction.ActionCursor;
         Scale.CircularMouseMove = ScaleAction.CircularMouseMove;
         Scale.Sensitivity = ScaleAction.Sensitivity;

         cell.SetActionProperties(MedicalViewerActionType.Scale, Scale);


         MedicalViewerStack StackAction = (MedicalViewerStack)DefaultCell.GetActionProperties(MedicalViewerActionType.Stack);

         MedicalViewerStack Stack = new MedicalViewerStack();
         Stack.ActionCursor = StackAction.ActionCursor;
         Stack.CircularMouseMove = StackAction.CircularMouseMove;
         Stack.Sensitivity = StackAction.Sensitivity;

         cell.SetActionProperties(MedicalViewerActionType.Stack, Stack);

         MedicalViewerOffset offsetAction = (MedicalViewerOffset)DefaultCell.GetActionProperties(MedicalViewerActionType.Offset);

         MedicalViewerOffset offset = new MedicalViewerOffset();
         offset.ActionCursor = offsetAction.ActionCursor;
         offset.CircularMouseMove = offsetAction.CircularMouseMove;
         offset.Sensitivity = offsetAction.Sensitivity;

         cell.SetActionProperties(MedicalViewerActionType.Offset, offset);

         MedicalViewerMagnifyGlass magnifyAction = (MedicalViewerMagnifyGlass)DefaultCell.GetActionProperties(MedicalViewerActionType.MagnifyGlass);
         cell.SetActionProperties(MedicalViewerActionType.MagnifyGlass, magnifyAction);

         int index = 0;
         MedicalViewerIcon icon;
         MedicalViewerIcon virtualCellIcon;

         for (index = 0; index < cell.Titlebar.Icons.Length; index++)
         {
            icon = cell.Titlebar.Icons[index];
            virtualCellIcon = cell.Titlebar.Icons[index];

            if (icon.Visible != virtualCellIcon.Visible)
               icon.Visible = virtualCellIcon.Visible;

            if (icon.Color != virtualCellIcon.Color)
               icon.Color = virtualCellIcon.Color;

            if (icon.ColorPressed != virtualCellIcon.ColorPressed)
               icon.ColorPressed = virtualCellIcon.ColorPressed;

            if (icon.ColorHover != virtualCellIcon.ColorHover)
               icon.ColorHover = virtualCellIcon.ColorHover;

            if (icon.ReadOnly != virtualCellIcon.ReadOnly)
               icon.ReadOnly = virtualCellIcon.ReadOnly;
         }
         if (cell.CellBackColor != DefaultCell.CellBackColor)
            cell.CellBackColor = DefaultCell.CellBackColor;

         if (cell.TextColor != DefaultCell.TextColor)
            cell.TextColor = DefaultCell.TextColor;

         if (cell.TextShadowColor != DefaultCell.TextShadowColor)
            cell.TextShadowColor = DefaultCell.TextShadowColor;

         if (cell.ActiveBorderColor != DefaultCell.ActiveBorderColor)
            cell.ActiveBorderColor = DefaultCell.ActiveBorderColor;

         if (cell.NonActiveBorderColor != DefaultCell.NonActiveBorderColor)
            cell.NonActiveBorderColor = DefaultCell.NonActiveBorderColor;

         if (cell.ActiveSubCellBorderColor != DefaultCell.ActiveSubCellBorderColor)
            cell.ActiveSubCellBorderColor = DefaultCell.ActiveSubCellBorderColor;

         if (cell.RulerInColor != DefaultCell.RulerInColor)
            cell.RulerInColor = DefaultCell.RulerInColor;

         if (cell.RulerOutColor != DefaultCell.RulerOutColor)
            cell.RulerOutColor = DefaultCell.RulerOutColor;

         if (cell.Titlebar.UseCustomColor != DefaultCell.Titlebar.UseCustomColor)
            cell.Titlebar.UseCustomColor = DefaultCell.Titlebar.UseCustomColor;

         if (cell.Titlebar.Color != DefaultCell.Titlebar.Color)
            cell.Titlebar.Color = DefaultCell.Titlebar.Color;

         if (cell.Titlebar.Visible != DefaultCell.Titlebar.Visible)
            cell.Titlebar.Visible = DefaultCell.Titlebar.Visible;

         if (cell.TextQuality != DefaultCell.TextQuality)
            cell.TextQuality = DefaultCell.TextQuality;

         if (cell.RulerStyle != DefaultCell.RulerStyle)
            cell.RulerStyle = DefaultCell.RulerStyle;

         if (cell.ShowCellScroll != DefaultCell.ShowCellScroll)
            cell.ShowCellScroll = DefaultCell.ShowCellScroll;

         if (cell.ShowFreezeText != DefaultCell.ShowFreezeText)
            cell.ShowFreezeText = DefaultCell.ShowFreezeText;

         if (cell.PaintingMethod != DefaultCell.PaintingMethod)
            cell.PaintingMethod = DefaultCell.PaintingMethod;

         if (cell.MeasurementUnit != DefaultCell.MeasurementUnit)
            cell.MeasurementUnit = DefaultCell.MeasurementUnit;

         if (cell.BorderStyle != DefaultCell.BorderStyle)
            cell.BorderStyle = DefaultCell.BorderStyle;
      }

      public static void ApplyToCells(MedicalViewer viewer, ComboBox cmbApplyToCell, NumericTextBox txtCellIndex, ComboBox cmbApplyToSubCell, NumericTextBox txtSubcellIndex, MedicalViewerActionType actionType, MedicalViewerBaseAction actionProperties)
      {
         ApplyToCells(viewer, cmbApplyToCell, txtCellIndex, cmbApplyToSubCell, txtSubcellIndex, actionType, actionProperties, null);
      }


      public static void ApplyToCells(MedicalViewer viewer, ComboBox cmbApplyToCell, NumericTextBox txtCellIndex, ComboBox cmbApplyToSubCell, NumericTextBox txtSubcellIndex, MedicalViewerActionType actionType, MedicalViewerBaseAction actionProperties, MyFunctionDelegate myFunction)
      {
         if (cmbApplyToCell == null)
            return;

         if (cmbApplyToCell.Text == "None")
            return;

         int from = 0;
         int to = viewer.Cells.Count;

         switch (cmbApplyToCell.Text)
         {
            case "Custom":
               if (txtCellIndex.Value >= viewer.Cells.Count)
                  return;
               from = txtCellIndex.Value;
               to = txtCellIndex.Value + 1;
               break;
         }

         int subCellIndex = 0;

         if (txtSubcellIndex != null)
         {
            subCellIndex = txtSubcellIndex.Value;
            switch (cmbApplyToSubCell.Text)
            {
               case "All":
                  subCellIndex = -1;
                  break;
               case "Selected":
                  subCellIndex = -2;
                  break;
            }
         }
         else
         {
            subCellIndex = -1;
         }

         int index;
         MedicalViewerMultiCell cell = null;

         for (index = from; index < to; index++)
         {
            cell = (MedicalViewerMultiCell)(viewer.Cells[index]);
            if (cell.Selected || cmbApplyToCell.Text != "Selected")
            {
               cell.SetActionProperties(actionType, actionProperties, subCellIndex);
               if (myFunction != null)
                  myFunction(cell, subCellIndex);
            }
         }
      }

      public static void CopyKeysFromGlobalCell(MedicalViewerMultiCell sourceCell, MedicalViewerMultiCell cell, MedicalViewerActionType actionType)
      {
         MedicalViewerKeys keys = sourceCell.GetActionKeys(actionType);
         cell.SetActionKeys(actionType, keys);
      }

      public static void CopyActionPropertiesFromGlobalCell(MedicalViewerMultiCell sourceCell, MedicalViewerMultiCell cell, MedicalViewerActionType actionType)
      {
         MedicalViewerCommonActions baseAction = (MedicalViewerCommonActions)cell.GetActionProperties(actionType);
         MedicalViewerCommonActions virtualBaseAction = (MedicalViewerCommonActions)sourceCell.GetActionProperties(actionType);

         if (baseAction is MedicalViewerCommonActions)
         {
            MedicalViewerCommonActions commonAction = (MedicalViewerCommonActions)baseAction;
            MedicalViewerCommonActions virtualCommonAction = (MedicalViewerCommonActions)virtualBaseAction;
            commonAction.ActionCursor = virtualCommonAction.ActionCursor;
            commonAction.CircularMouseMove = virtualCommonAction.CircularMouseMove;
            commonAction.Sensitivity = virtualCommonAction.Sensitivity;
         }

         cell.SetActionProperties(actionType, baseAction, cell.ActiveSubCell);
      }
      private void _actionsMenuItem_DropDownOpening(object sender, EventArgs e)
      {
      }

      private void _miSpyGlassSet_Click(object sender, EventArgs e)
      {

         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.SpyGlass));

      }

      private void _miActionsProbeToolSet_Click(object sender, EventArgs e)
      {

         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.ProbeTool));

      }

      private void _miActionZoomToRectangleSet_Click(object sender, EventArgs e)
      {

         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.ZoomToRectangle));

      }

      private void _miActionClickZoomInSet_Click(object sender, EventArgs e)
      {

         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.ClickZoomIn));

      }

      private void _miActionClickZoomOutSet_Click(object sender, EventArgs e)
      {

         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.ClickZoomOut));

      }

      private void _miActionCobbAngleSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, MedicalViewerActionType.AnnotationLine));
         CobbAngleStarted = true;
      }

      public bool CobbAngleStarted;

      private AnnPolylineObject FindAnotherLineObjectToAttach(MedicalViewerSubCell subCell, AnnPolylineObject lineObject)
      {
         AnnContainer container = subCell.AnnotationContainer;
         int count = subCell.CobbAngles.Count;
         int lastObject = container.Children.Count - 1;
         AnnPolylineObject[] list = new AnnPolylineObject[(count * 2) + 1];
         int index;
         int counter = 0;

         for (index = 0; index < count; index++)
         {
            list[counter++] = subCell.CobbAngles[index].Line1;
            list[counter++] = subCell.CobbAngles[index].Line2;
         }

         AnnObject annObject;
         for (index = lastObject; index >= 0; index--)
         {
            annObject = container.Children[index];
            if (annObject is AnnPolylineObject)
            {
               if (annObject.Equals(lineObject))
                  continue;
               if (Array.IndexOf(list, annObject) == -1)
                  return (AnnPolylineObject)annObject;
            }
         }

         return null;
      }

      void Automation_Draw(object sender, AnnDrawDesignerEventArgs e)
      {
         if (CobbAngleStarted)
         {
            if (e.OperationStatus == AnnDesignerOperationStatus.End)
            {
               if ((e.Object) is AnnPolylineObject)
               {
                  int cellIndex = GetFirstSelectedMultiCellIndex();

                  if (cellIndex == -1)
                     return;

                  MedicalViewerMultiCell cell = (MedicalViewerMultiCell)(_medicalViewer.Cells[cellIndex]);

                  AnnContainer container = cell.SubCells[cell.ActiveSubCell].AnnotationContainer;

                  AnnObject annObject = (e.Object);
                  if (annObject is AnnPolylineObject)
                  {
                     AnnPolylineObject lineObject = (AnnPolylineObject)annObject;

                     AnnPolylineObject secondLine = FindAnotherLineObjectToAttach(cell.SubCells[cell.ActiveSubCell], (AnnPolylineObject)annObject);
                     if ((secondLine != null) && (secondLine.Tag != null))
                     {
                        cell.SubCells[cell.ActiveSubCell].CobbAngles.Add(new MedicalViewerCobbAngle((AnnPolylineObject)annObject, secondLine));
                     }
                     else
                     {
                        lineObject.Tag = true;
                        cell.SetAction(MedicalViewerActionType.AnnotationLine, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
                     }

                  }
               }
            }
         }



         UnpushAllAnnotationIcons();
         if (_currentToolbarButton != null)
            _currentToolbarButton.Pushed = true;
      }


      public ToolBarButton CurrentToolBarButton
      {
         get
         {
            return _currentToolbarButton;
         }

         set
         {
            _currentToolbarButton = value;
         }
      }


      void cell_AnnotationCreated(object sender, MedicalViewerAnnotationCreatedEventArgs e)
      {
         if (e.AnnotationType == MedicalViewerActionType.AnnotationLine)
         {
            /*MedicalViewerMultiCell cell = (MedicalViewerMultiCell)(sender);
            AnnContainer container = cell.SubCells[e.SubCellIndex].AnnotationContainer;
            AnnObject annObject = e.Object;
            if (annObject is AnnLineObject)
            {
                AnnLineObject secondLine = FindAnotherLineObjectToAttach(cell.SubCells[cell.ActiveSubCell], (AnnLineObject)annObject);
                if (secondLine != null)
                {
                    cell.SubCells[cell.ActiveSubCell].CobbAngles.Add(new MedicalViewerCobbAngle((AnnLineObject)annObject, secondLine));
                }
            }*/
         }
      }

      private void imageInfoToolStripMenuItem_Click(object sender, EventArgs e)
      {
         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)GetSelectedCell();
         if (cell != null)
         {
            if (cell.Image != null)
            {
               MessageBox.Show(String.Format("Low Bit = {0} \n High Bit {1}\n Signed {2} \nMinimumValue {3} \n MaximumValue {4}", cell.Image.LowBit, cell.Image.HighBit, cell.Image.Signed, cell.Image.MinValue, cell.Image.MaxValue));
            }
         }
      }

      private void checkMarkerClicked(LeadPoint firstMarker, LeadPoint secondMarker, MedicalViewerCellMouseEventArgs e)
      {

         int highlightArea = 5;
         Rectangle rect = _stentCell.GetDisplayedImageRectangle();
         LeadRect rcRegion = _stentCommand.Region;
         RasterImage image = _stentCell.Image;

         float scaleX = rect.Width * 1.0f / image.Width;
         float scaleY = rect.Height * 1.0f / image.Height;


         LeadPoint firstOutput = new LeadPoint((int)((firstMarker.X + rcRegion.Left) * scaleX + rect.Left + 0.5),
                                               (int)((firstMarker.Y + rcRegion.Top) * scaleY + rect.Top + 0.5));

         LeadPoint secondOutput = new LeadPoint((int)((secondMarker.X + rcRegion.Left) * scaleX + rect.Left + 0.5),
                                                (int)((secondMarker.Y + rcRegion.Top) * scaleY + rect.Top + 0.5));

         Rectangle firstRect = new Rectangle(firstOutput.X - highlightArea, firstOutput.Y - highlightArea, highlightArea * 2, highlightArea * 2);
         Rectangle secondRect = new Rectangle(secondOutput.X - highlightArea, secondOutput.Y - highlightArea, highlightArea * 2, highlightArea * 2);

         Point mousePoint = new Point(e.X, e.Y);

         if (firstRect.Contains(mousePoint))
         {
            markerIndex = 0;
         }
         else if (secondRect.Contains(mousePoint))
         {
            markerIndex = 1;
         }

      }

      void cell_CellMouseDown(object sender, MedicalViewerCellMouseEventArgs e)
      {

         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)(sender);

         if (_currentAction == (MedicalViewerActionType)101)
         {
            if (_stentDialog != null)
            {
               if (_stentCommand != null)
               {
                  if ((cell) == _stentCell)
                  {
                     if (e.Button == MouseButtons.Left)
                     {
                        markerIndex = -1;
                        if (_stentCommand.StentMarkers == null)
                        {
                           if (e.SubCellIndex == _keyStentFrame)
                           {
                              checkMarkerClicked(_stentCommand.FirstMarker, _stentCommand.SecondMarker, e);
                           }
                        }
                        else
                        {
                           checkMarkerClicked(_stentCommand.StentMarkers[e.SubCellIndex].FirstMarker, _stentCommand.StentMarkers[e.SubCellIndex].SecondMarker, e);
                        }
                     }
                  }
               }
            }
         }


         if (cell.Image != null)
         {
            _probeToolImage = cell.Image;
            _probeToolImage.Page = e.SubCellIndex + 1;
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
                  image.Access();
                  Data = image.GetPixelData(y, x);
                  image.Release();
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
                     image.Access();
                     bit16ComponentData = image.GetPixelData(y, x);
                     image.Release();
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

      public int GetFirstSelectedMultiCellIndex()
      {
         int counter = 0;
         foreach (Control control in _medicalViewer.Cells)
         {
            if (control is MedicalViewerMultiCell)
            {
               MedicalViewerMultiCell cell = (MedicalViewerMultiCell)control;

               if (cell.Selected)
                  return counter;

               counter++;
            }
         }
         return -1;
      }

      void cell_CellMouseUp(object sender, MedicalViewerCellMouseEventArgs e)
      {

         if (markerIndex != -1)
         {
            markerIndex = -1;
            if (_stentDialog != null)
            {
               if (((MedicalViewerCell)sender) == _stentCell)
               {
                  if (_stentCommand != null)
                  {
                     if (_stentCommand.StentMarkers != null)
                     {
                        _stentCommand.UpdateStentImage(_stentCell.Image);
                        ApplyEnhancements(_stentCommand.EnhancedImage);
                     }
                  }
               }
            }
         }


      }

      private LeadPoint moveMarker(MedicalViewerCellMouseEventArgs e)
      {

         LeadRect rcRegion = _stentCommand.Region;
         int X = e.X;
         int Y = e.Y;

         Rectangle cellRect = _stentCell.GetDisplayedImageRectangle();
         RasterImage image = _stentCell.Image;

         float scaleX = cellRect.Width * 1.0f / image.Width;
         float scaleY = cellRect.Height * 1.0f / image.Height;

         X = (int)((X - cellRect.Left) / scaleX + 0.5);
         Y = (int)((Y - cellRect.Top) / scaleY + 0.5);
         X = X - rcRegion.Left;
         Y = Y - rcRegion.Top;

         return new LeadPoint(X, Y);

      }

      void cell_CellMouseMove(object sender, MedicalViewerCellMouseEventArgs e)
      {

         if (markerIndex != -1)
         {
            if (_stentDialog != null)
            {
               if (((MedicalViewerCell)sender) == _stentCell)
               {
                  if (_stentCommand != null)
                  {
                     LeadPoint currentPoint = moveMarker(e);
                     LeadRect region = _stentCommand.Region;
                     if (_stentCommand.Region.Contains(currentPoint.X + region.Left, currentPoint.Y + region.Top))
                     {
                        if (_stentCommand.StentMarkers == null)
                        {
                           if (e.SubCellIndex == _keyStentFrame)
                           {
                              if (markerIndex == 0)
                              {
                                 _stentCommand.FirstMarker = currentPoint;
                              }
                              else
                              {
                                 _stentCommand.SecondMarker = currentPoint;
                              }
                           }
                        }
                        else
                        {
                           if (markerIndex == 0)
                           {
                              _stentCommand.StentMarkers[e.SubCellIndex].FirstMarker = currentPoint;
                           }
                           else
                           {
                              _stentCommand.StentMarkers[e.SubCellIndex].SecondMarker = currentPoint;
                           }
                        }
                        _stentCell.Invalidate();
                     }
                  }
               }
            }
         }

      }

      private Rectangle CreateRectFromPoint(LeadPoint point, int size)
      {
         return new Rectangle(point.X - size, point.Y - size, size * 2, size * 2);
      }

      void cell_PostPaint(object sender, MedicalViewerPaintInformationEventArgs e)
      {

         if (_stentCommand == null || _stentCell != (MedicalViewerCell)sender)
            return;

         if (_frameEnabled != null)
            if (!_frameEnabled[e.SubCellIndex])
               return;
          
         StentEnhancementMarkers marker;
         if (_stentCommand.StentMarkers == null)
         {
            if (e.SubCellIndex != _keyStentFrame)
               return;
            marker = new StentEnhancementMarkers(_stentCommand.FirstMarker.X, _stentCommand.FirstMarker.Y, _stentCommand.SecondMarker.X, _stentCommand.SecondMarker.Y);
         }
         else
            marker = _stentCommand.StentMarkers[e.SubCellIndex];

         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)_medicalViewer.Cells[e.CellIndex];
         RasterImage image = cell.Image;
         LeadRect rcRegion = _stentCommand.Region;

         Rectangle rect = cell.GetDisplayedImageRectangle();


         float scaleX = rect.Width * 1.0f / image.Width;
         float scaleY = rect.Height * 1.0f / image.Height;

         marker.FirstMarker = cell.Image.PointToImage(cell.Image.ViewPerspective, marker.FirstMarker);
         marker.SecondMarker = cell.Image.PointToImage(cell.Image.ViewPerspective, marker.SecondMarker);
         LeadPoint firstOutput = new LeadPoint((int)((marker.FirstMarker.X + rcRegion.Left) * scaleX + rect.Left + 0.5),
                                               (int)((marker.FirstMarker.Y + rcRegion.Top) * scaleY + rect.Top + 0.5));

         LeadPoint secondOutput = new LeadPoint((int)((marker.SecondMarker.X + rcRegion.Left) * scaleX + rect.Left + 0.5),
                                                (int)((marker.SecondMarker.Y + rcRegion.Top) * scaleY + rect.Top + 0.5));

         Rectangle rect2 = cell.GetDisplayedClippedImageRectangle();

         if (!rect2.IsEmpty)
         {
            e.Graphics.DrawEllipse(Pens.Red, CreateRectFromPoint(firstOutput, 5));
            e.Graphics.DrawEllipse(Pens.Blue, CreateRectFromPoint(secondOutput, 5));
         }

      }

      private void CreateStentCells()
      {

         MedicalViewer medicalViewer = this.Viewer;

         _avgImageCell = _enhImageCell = null;
         foreach (StentData data in _stentDataList)
         {
            if (data.StentCell == _stentCell)
            {
               if (data.AvgImageCell != null)
               {
                  if (!data.AvgImageCell.IsDisposed)
                     _avgImageCell = data.AvgImageCell;
                  else
                     _avgImageCell = null;
               }

               if (data.EnhImageCell != null)
               {
                  if (!data.EnhImageCell.IsDisposed)
                     _enhImageCell = data.EnhImageCell;
                  else
                     _enhImageCell = null;
               }

            }
         }


         if (_avgImageCell == null)
         {
            _avgImageCell = new MedicalViewerMultiCell();

            _avgImageCell.FitImageToCell = true;
            _avgImageCell.SetTag(0, MedicalViewerTagAlignment.TopCenter, MedicalViewerTagType.UserData, "Average Stent Image");
            _avgImageCell.SetTag(1, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Scale);
            _avgImageCell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData);

            medicalViewer.Cells.Add(_avgImageCell);
            _avgImageCell.Disposed += new EventHandler(_avgImageCell_Disposed);

            InitializeCell(_avgImageCell);
            InitAutomation(_avgImageCell);
            InitializeAutomationManager(_avgImageCell);
            _avgImageCell.Resized += new EventHandler<EventArgs>(_avgImageCell_Resized);
            InitializeEvents(_avgImageCell);
         }


         if (_enhImageCell == null)
         {
            _enhImageCell = new MedicalViewerMultiCell();

            _enhImageCell.FitImageToCell = true;
            _enhImageCell.SetTag(0, MedicalViewerTagAlignment.TopCenter, MedicalViewerTagType.UserData, "Default Stent Image Enhancement");
            _enhImageCell.SetTag(1, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Scale);
            _enhImageCell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData);

            medicalViewer.Cells.Add(_enhImageCell);
            _enhImageCell.Disposed += new EventHandler(_enhImageCell_Disposed);

            InitializeCell(_enhImageCell);
            InitAutomation(_enhImageCell);
            InitializeAutomationManager(_enhImageCell);
            _enhImageCell.Resized += new EventHandler<EventArgs>(_avgImageCell_Resized);

            InitializeEvents(_enhImageCell);
         }


         bool addToList = true;
         foreach (StentData data in _stentDataList)
         {
            if (data.StentCell == _stentCell)
            {
               addToList = false;
               data.AvgImageCell = _avgImageCell;
               data.EnhImageCell = _enhImageCell;
               break;
            }
         }

         if (addToList)
            _stentDataList.Add(new StentData(_stentCell, _avgImageCell, _enhImageCell));

         return;

      }

      void _avgImageCell_Resized(object sender, EventArgs e)
      {
         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)sender;

         if (cell.Image == null)
             return;

         RasterImage image = cell.Image;
         LeadRect RegionBounds = image.GetRegionBounds(null);

         cell.ZoomToRectangle(ZoomToRectangleHelper(RegionBounds, cell));
      }

      void _enhImageCell_Disposed(object sender, EventArgs e)
      {

         MedicalViewerMultiCell enhImageCell = (MedicalViewerMultiCell)sender;
         if (_stentDialog != null && _enhImageCell.Equals(enhImageCell))
         {
            _dialogDisplaced = false;
         }

         foreach (StentData data in _stentDataList)
         {
            if (data.EnhImageCell == enhImageCell)
            {
               data.EnhImageCell = null;
               break;
            }
         }

         enhImageCell.Disposed -= new EventHandler(_enhImageCell_Disposed);
         enhImageCell = null;

      }

      void _avgImageCell_Disposed(object sender, EventArgs e)
      {

         MedicalViewerMultiCell avgImageCell = (MedicalViewerMultiCell)sender;
         if (_stentDialog != null && _avgImageCell.Equals(avgImageCell))
         {
            _stentDialog.ResetAvgEnabled(false);
            _dialogDisplaced = false;
         }

         foreach (StentData data in _stentDataList)
         {
            if (data.AvgImageCell == avgImageCell)
            {
               data.AvgImageCell = null;
               break;
            }
         }
         avgImageCell.Disposed -= new EventHandler(_avgImageCell_Disposed);
         avgImageCell = null;

      }

      private Rectangle ZoomToRectangleHelper(LeadRect stentRegion, MedicalViewerMultiCell cell)
      {
         int Top = stentRegion.Top;
         int Left = stentRegion.Left;
         int Right = stentRegion.Right;
         int Bottom = stentRegion.Bottom;

         Rectangle rect = cell.GetDisplayedImageRectangle();
         RasterImage image = cell.Image;
         float scaleX = rect.Width * 1.0f / image.Width;
         float scaleY = rect.Height * 1.0f / image.Height;

         Top = (int)(Top * scaleY + 0.5 + rect.Top);
         Left = (int)(Left * scaleX + 0.5 + rect.Left);
         Right = (int)(Right * scaleX + 0.5 + rect.Left);
         Bottom = (int)(Bottom * scaleY + 0.5 + rect.Top);

         return new Rectangle(Left, Top, Right - Left, Bottom - Top);
      }

      public void ApplyEnhancements(RasterImage img)
      {

         CreateStentCells();
         _avgImageCell.Image = img.Clone();
         _enhImageCell.Image = img.Clone();
         RasterImage image = _enhImageCell.Image;

         if (image.BitsPerPixel != 8)
         {
            UnsharpMaskCommand unsharpCommand = new UnsharpMaskCommand(200, 100, 0, UnsharpMaskCommandColorType.Yuv);
            unsharpCommand.Run(image);
         }

         MultiscaleEnhancementCommand multiscaleCommand = new MultiscaleEnhancementCommand(900, 3, 170, 5, 140, MultiscaleEnhancementCommandType.Gaussian, MultiscaleEnhancementCommandFlags.EdgeEnhancement | MultiscaleEnhancementCommandFlags.LatitudeReduction);
         multiscaleCommand.Run(image);

         if (image.BitsPerPixel == 16 || image.BitsPerPixel == 8)
         {
            float Alpha = 0.65f;
            int Tilesize = 8;
            float Tilehistcliplimit = 0.01f;
            int Binnumber = 128;
            CLAHECommandFlags flags = CLAHECommandFlags.ApplyRayliehDistribution;
            CLAHECommand hhh = new CLAHECommand(Alpha, Tilesize, Tilehistcliplimit, Binnumber, flags);
            hhh.Run(image);

            if (image.BitsPerPixel == 16)
            {
               GetLinearVoiLookupTableCommand command = new GetLinearVoiLookupTableCommand(GetLinearVoiLookupTableCommandFlags.None);
               command.Run(image);
               _enhImageCell.SetWindowLevel((int)command.Width, (int)command.Center);
            }
         }

         _avgImageCell.ZoomToRectangle(ZoomToRectangleHelper(_stentRegion, _avgImageCell));
         _enhImageCell.ZoomToRectangle(ZoomToRectangleHelper(_stentRegion, _enhImageCell));

         _avgImageCell.Invalidate();
         _enhImageCell.Invalidate();

         foreach (StentData data in _stentDataList)
         {
            if (data.EnhImageCell == _enhImageCell)
            {
               data.EnhImageCellWLCenter = _enhImageCell.GetWindowLevelCenter();
               data.EnhImageCellWLWidth = _enhImageCell.GetWindowLevelWidth();
               break;
            }
         }


      }

      public void ApplyStent()
      {

         _regionMenuItem.Enabled = false;
         if (_stentCell == null || _stentCommand == null)
            return;
         if (_stentCell.Image == null)
            return;

         _stentCell.Image.Page = _stentCell.ActiveSubCell + 1;

         if (_stentCell.Image != null)
            if (!_stentCell.Image.HasRegion)
               return;

         if (_medicalViewer.Rows != 2)
         {
            _medicalViewer.Rows = 2;
            _medicalViewer.Columns = 2;
         }

         if (!_dialogDisplaced)
         {
            _stentDialog.ResetBtnEnabled(false);

            _stentDialog.Left += _stentDialog.Width / 2;
            _stentDialog.Top += _stentDialog.Height / 2;
            _dialogDisplaced = true;

            RasterImage image = _stentCell.Image;
            if (_stentCell.Image.ViewPerspective != RasterViewPerspective.TopLeft)
               _stentCell.SetImagePerspective(RasterViewPerspective.TopLeft);


            int WindowWidth = _stentCell.GetWindowLevelWidth();
            int WindowCenter = _stentCell.GetWindowLevelCenter();

            _stentCell.SetWindowLevel(WindowWidth, WindowCenter);

            try
            {
               _stentCommand.Run(image);
            }
            catch (System.Exception ex)
            {
               Messager.ShowError(this, ex);
            }

            _frameEnabled = _stentCommand.FrameEnabled;

            _stentDialog.UpdateProgress(0);

            ApplyEnhancements(_stentCommand.EnhancedImage);
            _stentDialog.ResetAvgEnabled(true);
         }

      }

      public void ResetRegion()
      {

         RasterImage image = _stentCell.Image;
         LeadRect RegionBounds = image.GetRegionBounds(null);

         _keyStentFrame = _stentCell.ActiveSubCell;
         _stentCell.SetAction(MedicalViewerActionType.RectangleRegion, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
         CheckMoveMarkersAction(false);
         _stentCommand = null;
         _stentCell.RemoveRegion();
         _stentCell.Invalidate();

      }

      public void FinishStentEnhancement()
      {

         if (_stentCell != null)
         {
            _stentCell.SetAction(_leftButtonAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
            _stentCell.SetAction(_rightButtonAction, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active);
            CheckMoveMarkersAction(false);
            _stentDialog = null;
            _dialogDisplaced = false;

            if (_stentCell.Image != null)
               _stentCell.RemoveRegion();

            if (_modifyStentDlg != null)
               _modifyStentDlg.Close();
            _modifyStentDlg = null;

            _stentCell.RegionCreated -= new EventHandler<MedicalViewerRegionCreatedEventArgs>(cell_RegionCreated);
            _stentCell.PostPaint -= new EventHandler<MedicalViewerPaintInformationEventArgs>(cell_PostPaint);

            _stentCell.CellMouseDown -= new EventHandler<MedicalViewerCellMouseEventArgs>(cell_CellMouseDown);
            _stentCell.CellMouseMove -= new EventHandler<MedicalViewerCellMouseEventArgs>(cell_CellMouseMove);
            _stentCell.CellMouseUp -= new EventHandler<MedicalViewerCellMouseEventArgs>(cell_CellMouseUp);

            _stentCommand = null;
            /*_avgImageCell = null;
            _enhImageCell = null;*/
            _frameEnabled = null;
            _stentCell.Invalidate();

            _stentCell = null;
         }

      }

      void _stentCell_Disposed(object sender, EventArgs e)
      {

         if (_stentCell == null) return;
         _stentCell = null;
         _stentDialog.Close();
         if (_modifyStentDlg != null)
            _modifyStentDlg.Close();
         _modifyStentDlg = null;
         _stentCommand = null;
         _stentDialog = null;
         _enhImageCell = null;
         _avgImageCell = null;
         CheckMoveMarkersAction(false);


      }

      void cell_RegionCreated(object sender, MedicalViewerRegionCreatedEventArgs e)
      {

         if (_stentDialog == null)
            return;

         RasterImage image = _stentCell.Image;
         LeadRect RegionBounds = image.GetRegionBounds(null);
         RegionBounds = image.RectangleFromImage(RasterViewPerspective.TopLeft, RegionBounds);

         _stentRegion = RegionBounds;

         int regionWidth = RegionBounds.Width;
         int regionHeight = RegionBounds.Height;

         _keyStentFrame = e.SubCellIndex;

         MedicalViewerActionType userAction = (MedicalViewerActionType)101;
         _stentCell.AddAction(userAction);
         _stentCell.SetAction(userAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
         _currentAction = (MedicalViewerActionType)101;
         CheckMoveMarkersAction(true);

         _stentCommand = new StentEnhancementCommand(RegionBounds, _keyStentFrame);

         _stentCommand.DetectMarkers(image, e.SubCellIndex, RegionBounds);

         _stentCommand.Progress += new EventHandler<RasterCommandProgressEventArgs>(_stentCommand_Progress);

         _stentDialog.ResetBtnEnabled(true);

         _stentCell.Invalidate();

      }

      void _stentCommand_Progress(object sender, RasterCommandProgressEventArgs e)
      {

         _stentDialog.UpdateProgress(e.Percent);
         Application.DoEvents();

      }

      private void stentEnhancementToolStripMenuItem_Click(object sender, EventArgs e)
      {

         if (_stentDialog != null)
            return;

         _stentDialog = new StentEnhancementDialog(this);
         _stentDialog.Show(this);
         _stentDialog.FormClosing += new FormClosingEventHandler(_stentDialog_FormClosing);

         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)GetSelectedCell();
         cell.SetImagePerspective(RasterViewPerspective.TopLeft);
         cell.SetAction(MedicalViewerActionType.RectangleRegion, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
         cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active);

         cell.RegionCreated += new EventHandler<MedicalViewerRegionCreatedEventArgs>(cell_RegionCreated);
         cell.PostPaint += new EventHandler<MedicalViewerPaintInformationEventArgs>(cell_PostPaint);

         cell.CellMouseDown += new EventHandler<MedicalViewerCellMouseEventArgs>(cell_CellMouseDown);
         cell.CellMouseMove += new EventHandler<MedicalViewerCellMouseEventArgs>(cell_CellMouseMove);
         cell.CellMouseUp += new EventHandler<MedicalViewerCellMouseEventArgs>(cell_CellMouseUp);
         cell.Disposed += new EventHandler(_stentCell_Disposed);

         _stentCell = cell;

         _dialogDisplaced = false;

      }

      public void _stentDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         _regionMenuItem.Enabled = true;
      }

      private void unselectFramesToolStripMenuItem_Click(object sender, EventArgs e)
      {

         if (_stentCell == null) return;
         if (_frameEnabled == null) return;
         if (_modifyStentDlg != null) return;

         _modifyStentDlg = new ModifyStent(_stentCell, _stentCommand, this);
         _modifyStentDlg.Show(this);

      }

      public void ResetAverage()
      {

         if (_avgImageCell != null)
         {
            if (_stentCommand.EnhancedImage != null)
            {
               _avgImageCell.Image = _stentCommand.EnhancedImage.Clone();
               _avgImageCell.ZoomToRectangle(ZoomToRectangleHelper(_stentRegion, _avgImageCell));
               _avgImageCell.Invalidate();
            }
         }

      }

      private void multiscaleEnhancementToolStripMenuItem_Click(object sender, EventArgs e)
      {

         MedicalViewerCell cell = GetSelectedCell();
         if (cell != null)
            ShowViewerDialogs(new MultiscaleEnhancementDialog(this, cell));

      }

      private void adaptiveContrastToolStripMenuItem_Click(object sender, EventArgs e)
      {

         MedicalViewerCell cell = GetSelectedCell();
         if (cell != null)
            ShowViewerDialogs(new AdaptiveContrastDialog(this));

      }

      private void unsharpMaskToolStripMenuItem_Click(object sender, EventArgs e)
      {

         MedicalViewerCell cell = GetSelectedCell();
         if (cell != null)
            ShowViewerDialogs(new UnsharpMaskDialog(this));

      }

      private void histogramEqualizeToolStripMenuItem_Click(object sender, EventArgs e)
      {

         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)GetSelectedCell();
         if (cell != null)
            ShowViewerDialogs(new HistogramEqualizeDialog(cell, this));

      }

      public delegate void ApplyFilterCallBack();
      public void FilterOk_Click(RasterImage originalBitmap, bool firstTime, ApplyFilterCallBack ApplyFilter)
      {

         MedicalViewerCell cell = GetSelectedCell();
         int cellIndex = GetCellIndex(cell);

         if (_orignalImagesList[cellIndex] == null)
            _orignalImagesList[cellIndex] = new RasterImage[cell.Image.PageCount];

         RasterImage[] imageArray = _orignalImagesList[cellIndex];

         if (firstTime)
         {
            if (imageArray[cell.ActiveSubCell] == null)
            {
               int orignalPage = cell.Image.Page;
               cell.Image.Page = cell.ActiveSubCell + 1;
               imageArray[cell.ActiveSubCell] = cell.Image.Clone();
               cell.Image.Page = orignalPage;
            }
            ApplyFilter();
         }
         else
         {
            if (imageArray[cell.ActiveSubCell] == null)
            {
               imageArray[cell.ActiveSubCell] = new RasterImage(originalBitmap);
            }
         }

      }

      public void FilterApply_Click(ref bool firstTime, ref RasterImage originalBitmap, ApplyFilterCallBack ApplyFilter)
      {
         MedicalViewerCell cell = GetSelectedCell();

         if (firstTime)
         {
            int orignalPage = cell.Image.Page;
            cell.Image.Page = cell.ActiveSubCell + 1;
            originalBitmap = cell.Image.Clone();
            cell.Image.Page = orignalPage;

            firstTime = false;
         }
         else
         {
            int orignalPage = cell.Image.Page;
            cell.Image.Page = cell.ActiveSubCell + 1;
            CopyBitmapData(cell.Image, originalBitmap);
            cell.Image.Page = orignalPage;
         }

         ApplyFilter();
      }

      public void FilterCancel_Click(bool firstTime, RasterImage originalBitmap, bool invalidate)
      {
         if (!firstTime)
         {
            MedicalViewerCell cell = GetSelectedCell();

            int orignalPage = cell.Image.Page;
            cell.Image.Page = cell.ActiveSubCell + 1;
            CopyBitmapData(cell.Image, originalBitmap);
            cell.Image.Page = orignalPage;

            if (invalidate)
               cell.Invalidate();

            originalBitmap.Dispose();
         }
      }

      public void FilterRunCommand(RasterCommand command, bool invalidate, bool useRegion)
      {
         MedicalViewerCell cell = GetSelectedCell();
         bool regionSet = false;

         int orignalPage = cell.Image.Page;
         cell.Image.Page = cell.ActiveSubCell + 1;
         try
         {
             if (useRegion)
             {
                 if (!cell.Image.HasRegion)
                 {
                     regionSet = true;
                     cell.Image.AddRectangleToRegion(null, LeadRect.Create(0, 0, cell.Image.Width, cell.Image.Height), RasterRegionCombineMode.Set);
                 }
             }

            command.Run(cell.Image);

            if (regionSet)
                cell.Image.MakeRegionEmpty();
         }
         catch (System.Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         cell.Image.Page = orignalPage;

         if (invalidate)
            cell.Invalidate();
      }

      private void stentToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {

         bool enableEffects = (Viewer.Cells.Count != 0) && IsThereASelectedCell();
         _stentEnhancementMenuItem.Enabled = enableEffects;
         _unselectFramesMenuItem.Enabled = enableEffects;
         _moveMarkersAction.Enabled = enableEffects;

      }

      private void filtersToolStripMenuItem1_DropDownOpening(object sender, EventArgs e)
      {

         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)GetSelectedCell();
         bool enableEffects = (Viewer.Cells.Count != 0) && IsThereASelectedCell() && !cell.Frozen;

         _miEffectInvert.Enabled =
         multiscaleEnhancementToolStripMenuItem.Enabled =
         adaptiveContrastToolStripMenuItem.Enabled =
         unsharpMaskToolStripMenuItem.Enabled =
         histogramEqualizeToolStripMenuItem.Enabled =
         saveToolStripMenuItem.Enabled = enableEffects;

         _miEffectCLAHE.Enabled = (enableEffects && (GetSelectedCell().Image.BitsPerPixel == 16 || GetSelectedCell().Image.BitsPerPixel == 8));

         if (cell != null && _orignalImagesList[GetCellIndex(cell)] != null && _orignalImagesList[GetCellIndex(cell)][cell.ActiveSubCell] != null)
            resetToolStripMenuItem.Enabled = true;
         else
            resetToolStripMenuItem.Enabled = false;


      }

      private void _moveMarkersAction_Click(object sender, EventArgs e)
      {

         if (_stentCell != null && _stentCommand != null)
         {
            if (_moveMarkersAction.Checked == false)
            {
               _stentCell.SetAction((MedicalViewerActionType)101, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
               _currentAction = (MedicalViewerActionType)101;
               _stentCell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active);
               CheckMoveMarkersAction(true);
            }
            else
            {
               _stentCell.SetAction(_leftButtonAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
               _currentAction = _leftButtonAction;
               CheckMoveMarkersAction(false);
            }
         }

      }

      public void CheckMoveMarkersAction(bool check)
      {
         _moveMarkersAction.Checked = check;
      }

      private LeadPoint moveMarker(MedicalViewerCellMouseEventArgs e, MedicalViewerMultiCell cell)
      {

         int X = e.X;
         int Y = e.Y;

         Rectangle cellRect = cell.GetDisplayedImageRectangle();
         RasterImage image = cell.Image;

         float scaleX = cellRect.Width * 1.0f / image.Width;
         float scaleY = cellRect.Height * 1.0f / image.Height;

         X = (int)((X - cellRect.Left) * 1.0f / scaleX + 0.5);
         Y = (int)((Y - cellRect.Top) * 1.0f / scaleY + 0.5);

         return new LeadPoint(X, Y);

      }

      private void imageAlignmentToolStripMenuItem_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         if (_medicalViewer.Cells.Count < 2)
            return;
         if (_alignmentDlg != null)
            return;


         _referenceCell = null;
         _templateCell = null;
         foreach (MedicalViewerMultiCell cell in _medicalViewer.Cells)
         {
            if (cell.Selected)
            {
               if (_referenceCell == null)
               {
                  _referenceCell = cell;
               }
               else
               {
                  _templateCell = cell;
                  break;
               }
            }
         }

         if (_templateCell == null || _referenceCell == null)
            return;

         if (_referenceCell.Image.BitsPerPixel != _templateCell.Image.BitsPerPixel)
         {
            Messager.ShowError(this, "The two images should be of the same bit depth (Bits Per Pixel)");
            _templateCell = null;
            _referenceCell = null;
            return;
         }

         _referenceCell.PostPaint += new EventHandler<MedicalViewerPaintInformationEventArgs>(alignmentCell_PostPaint);
         _templateCell.PostPaint += new EventHandler<MedicalViewerPaintInformationEventArgs>(alignmentCell_PostPaint);

         MedicalViewerActionType SelectPointsAction = (MedicalViewerActionType)102;
         _referenceCell.AddAction(SelectPointsAction);
         _templateCell.AddAction(SelectPointsAction);
         _referenceCell.SetAction(SelectPointsAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
         _templateCell.SetAction(SelectPointsAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
         CheckSelectPoints(true);
         _currentAction = SelectPointsAction;

         _refPointAdded = false;

         _referenceList = new List<LeadPoint>();
         _templateList = new List<LeadPoint>();

         _alignPointIdx = -1;

         _referenceCell.CellMouseDown += new EventHandler<MedicalViewerCellMouseEventArgs>(alignmentCell_CellMouseDown);
         _templateCell.CellMouseDown += new EventHandler<MedicalViewerCellMouseEventArgs>(alignmentCell_CellMouseDown);

         _referenceCell.CellMouseMove += new EventHandler<MedicalViewerCellMouseEventArgs>(alignmentCell_CellMouseMove);
         _referenceCell.CellMouseUp += new EventHandler<MedicalViewerCellMouseEventArgs>(alignmentCell_CellMouseUp);

         _templateCell.CellMouseMove += new EventHandler<MedicalViewerCellMouseEventArgs>(alignmentCell_CellMouseMove);
         _templateCell.CellMouseUp += new EventHandler<MedicalViewerCellMouseEventArgs>(alignmentCell_CellMouseUp);

         _referenceCell.Disposed += new EventHandler(_referenceCell_Disposed);
         _templateCell.Disposed += new EventHandler(_templateCell_Disposed);

         _alignmentDlg = new ImageAlignmentDialog(this);
         _alignmentDlg.Show(this);
#endif
      }

      void _referenceCell_Disposed(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         _referenceCell = null;
         if (_alignmentDlg != null)
         {
            _alignmentDlg.Close();
         }
#endif
      }

      void _templateCell_Disposed(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         _templateCell = null;
         if (_alignmentDlg != null)
         {
            _alignmentDlg.Close();
         }
#endif
      }

      void _registeredImageCell_Disposed(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         _registeredImageCell = null;
#endif
      }

      void alignmentCell_CellMouseDown(object sender, MedicalViewerCellMouseEventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)sender;
         List<LeadPoint> list = null;
         if (cell == _referenceCell)
         {
            list = _referenceList;
         }
         else if (cell == _templateCell)
         {
            list = _templateList;
         }

         if (_currentAction == (MedicalViewerActionType)102)
         {
            if (e.Button == MouseButtons.Left)
            {
               if (cell.GetDisplayedImageRectangle().Contains(e.X, e.Y))
               {
                  LeadPoint currentPoint = moveMarker(e, cell);
                  int idx = 0;
                  _alignPointIdx = -1;
                  foreach (LeadPoint point in list)
                  {
                     Rectangle rect = CreateRectFromPoint(point, 5);
                     if (rect.Contains(currentPoint.X, currentPoint.Y))
                     {
                        _alignPointIdx = idx;
                        break;
                     }
                     idx++;
                  }
                  if (_refPointAdded && cell == _templateCell)
                  {
                     if (_alignPointIdx == -1)
                     {
                        list.Add(currentPoint);
                        cell.Invalidate();
                        _refPointAdded = false;
                        _alignmentDlg.EnableApplyButton(true);
                     }
                  }
                  else if (!_refPointAdded && cell == _referenceCell)
                  {
                     if (_alignPointIdx == -1)
                     {
                        list.Add(currentPoint);
                        cell.Invalidate();
                        _refPointAdded = true;
                     }
                  }
               }
            }
         }
#endif
      }

      void alignmentCell_CellMouseUp(object sender, MedicalViewerCellMouseEventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         if (_currentAction == (MedicalViewerActionType)102)
            if (e.Button == MouseButtons.Left)
            {
               _alignPointIdx = -1;
               MedicalViewerMultiCell cell = (MedicalViewerMultiCell)sender;
               cell.Invalidate();
            }
#endif
      }

      void alignmentCell_CellMouseMove(object sender, MedicalViewerCellMouseEventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         if (_currentAction == (MedicalViewerActionType)102)
         {
            MedicalViewerMultiCell cell = (MedicalViewerMultiCell)sender;
            List<LeadPoint> list = null;
            if (cell == _referenceCell)
            {
               list = _referenceList;
            }
            else if (cell == _templateCell)
            {
               list = _templateList;
            }

            if (cell.GetDisplayedImageRectangle().Contains(e.X, e.Y))
            {
               if (cell != null)
               {
                  if (_alignPointIdx != -1)
                  {
                     list.RemoveAt(_alignPointIdx);
                     list.Insert(_alignPointIdx, moveMarker(e, cell));
                     _referenceCell.Invalidate();
                     _templateCell.Invalidate();
                     _alignmentDlg.EnableApplyButton(true);
                  }
               }
            }
         }
#endif
      }

      void alignmentCell_PostPaint(object sender, MedicalViewerPaintInformationEventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)sender;
         List<LeadPoint> list = null;
         if (cell == _referenceCell)
         {
            list = _referenceList;
         }
         else if (cell == _templateCell)
         {
            list = _templateList;
         }

         if (list != null)
         {
            if (list.Count > 0)
            {
               if (e.SubCellIndex == 0)
               {
                  Rectangle displayRect = cell.GetDisplayedClippedImageRectangle();
                  int index = 0;
                  foreach (LeadPoint point in list)
                  {
                     RasterImage image = cell.Image;
                     Rectangle rect = cell.GetDisplayedImageRectangle();

                     float scaleX = rect.Width * 1.0f / image.Width;
                     float scaleY = rect.Height * 1.0f / image.Height;

                     LeadPoint outPoint = new LeadPoint((int)((point.X) * scaleX + rect.Left + 0.5),
                                                           (int)((point.Y) * scaleY + rect.Top + 0.5));

                     if (!displayRect.IsEmpty)
                     {
                        Brush brush = Brushes.Red;
                        if (index == _alignPointIdx)
                           brush = Brushes.Yellow;
                        e.Graphics.FillEllipse(brush, CreateRectFromPoint(outPoint, 3));
                     }
                     index++;
                  }
               }
            }
         }
#endif
      }

      public void ApplyAlignment()
      {
#if LEADTOOLS_V19_OR_LATER
         if (_referenceCell == null ||
             _templateCell == null ||
             _referenceList == null ||
             _templateList == null)
            return;

         if (_referenceList.Count < 1)
            return;

         if (_refPointAdded)
            return;

         _alignmentDlg.EnableApplyButton(false);
         _alignmentDlg.OldOptions = _alignmentDlg.Options;

         AlignImagesCommand command = new AlignImagesCommand();

         command.RegistrationMethod = _alignmentDlg.Options;

         command.ReferenceImagePoints = _referenceList.ToArray();
         command.TemplateImagePoints = _templateList.ToArray();

         command.TemplateImage = _templateCell.Image.Clone();

         try
         {
            command.Run(_referenceCell.Image.Clone());
         }
         catch (System.Exception ex)
         {
            Messager.ShowError(this, ex);
            return;
         }

         if (_registeredImageCell == null)
         {
            _medicalViewer.Rows = 2;
            _medicalViewer.Columns = 2;

            MedicalViewerMultiCell newCell = new MedicalViewerMultiCell();

            _medicalViewer.Cells.Add(newCell);

            InitializeCell(newCell);
            InitAutomation(newCell);
            InitializeAutomationManager(newCell);

            newCell.SetTag(0, MedicalViewerTagAlignment.TopCenter, MedicalViewerTagType.UserData, "Registered Image");
            newCell.SetTag(1, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Scale);
            newCell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData);
            _registeredImageCell = newCell;

            _registeredImageCell.Disposed += new EventHandler(_registeredImageCell_Disposed);
            _registeredImageCell.Image = command.RegisteredImage.Clone();
            _registeredImageCell.FitImageToCell = false;
            _registeredImageCell.SetScaleMode(MedicalViewerScaleMode.Fit);

            _registeredImageCell.Invalidate();

         }
         else
         {
            if (command.RegisteredImage != null)
            {
               if (_registeredImageCell.Image != null)
                  _registeredImageCell.Image.Dispose();

               _registeredImageCell.Image = command.RegisteredImage.Clone();
               _registeredImageCell.SetScaleMode(MedicalViewerScaleMode.Fit);

               command.RegisteredImage.Dispose();
            }
         }
#endif
      }

      public void FinishAlignment()
      {
#if LEADTOOLS_V19_OR_LATER

         if (_referenceCell != null)
         {
            _referenceCell.PostPaint -= new EventHandler<MedicalViewerPaintInformationEventArgs>(alignmentCell_PostPaint);
            _referenceCell.CellMouseDown -= new EventHandler<MedicalViewerCellMouseEventArgs>(alignmentCell_CellMouseDown);
            _referenceCell.CellMouseMove -= new EventHandler<MedicalViewerCellMouseEventArgs>(alignmentCell_CellMouseMove);
            _referenceCell.CellMouseUp -= new EventHandler<MedicalViewerCellMouseEventArgs>(alignmentCell_CellMouseUp);
            _referenceCell.Disposed -= new EventHandler(_referenceCell_Disposed);

            _referenceCell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
            _referenceCell.Invalidate();
         }
         if (_templateCell != null)
         {
            _templateCell.PostPaint -= new EventHandler<MedicalViewerPaintInformationEventArgs>(alignmentCell_PostPaint);
            _templateCell.CellMouseDown -= new EventHandler<MedicalViewerCellMouseEventArgs>(alignmentCell_CellMouseDown);
            _templateCell.CellMouseMove -= new EventHandler<MedicalViewerCellMouseEventArgs>(alignmentCell_CellMouseMove);
            _templateCell.CellMouseUp -= new EventHandler<MedicalViewerCellMouseEventArgs>(alignmentCell_CellMouseUp);
            _templateCell.Disposed -= new EventHandler(_templateCell_Disposed);

            _templateCell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
            _templateCell.Invalidate();
         }
         if (_registeredImageCell != null)
         {
            _registeredImageCell.Disposed -= new EventHandler(_registeredImageCell_Disposed);
         }
         CheckSelectPoints(false);
         _alignmentDlg = null;
         _templateCell = null;
         _referenceCell = null;
         _templateList = null;
         _referenceCell = null;

         _registeredImageCell = null;
#endif
      }

      public void ResetAlignment()
      {
#if LEADTOOLS_V19_OR_LATER
         _refPointAdded = false;
         _templateList = new List<LeadPoint>();
         _referenceList = new List<LeadPoint>();
         _templateCell.Invalidate();
         _referenceCell.Invalidate();
#endif
      }

      private void dISToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         imageAlignmentToolStripMenuItem.Enabled = (IsThereASelectedCell() & _medicalViewer.Cells.Count >= 2);
      }

      private void _selectPointsActionMenuItem_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         if (_referenceCell == null ||
              _templateCell == null ||
              _referenceList == null ||
              _templateList == null)
         {
            return;
         }
         if (_selectPointsActionMenuItem.Checked == false)
         {
            _referenceCell.SetAction((MedicalViewerActionType)102, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
            _templateCell.SetAction((MedicalViewerActionType)102, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
            _currentAction = (MedicalViewerActionType)102;
            CheckSelectPoints(true);
         }
         else
         {
            _referenceCell.SetAction(_leftButtonAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
            _templateCell.SetAction(_leftButtonAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
            _currentAction = _leftButtonAction;
            CheckSelectPoints(false);
         }
#endif
      }

      public void CheckSelectPoints(bool value)
      {
         _selectPointsActionMenuItem.Checked = value;
      }

      private void cLAHEToolStripMenuItem_Click(object sender, EventArgs e)
      {

         MedicalViewerCell cell = GetSelectedCell();
         if (cell != null)
            ShowViewerDialogs(new CLAHEDialog(this, cell));

      }

      private void saveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)GetSelectedCell();
         RasterCodecs RC = new RasterCodecs();

         ImageFileSaver _saver = new ImageFileSaver();



         try
         {
            if (cell.Image.HasRegion)
               cell.Image.MakeRegionEmpty();

            DemosGlobal.SetDefaultComments(cell.Image, RC);
            _saver.FormatIndex = RasterDialogFileTypesIndex.Tiff;
            _saver.BitsPerPixel = 16;
            _saver.Save(this, RC, cell.Image);
         }
         catch (Exception ex)
         {
            Messager.ShowFileSaveError(this, _saver.FileName, ex);
         }

      }

      private void CopyBitmapData(RasterImage destImage, RasterImage srcImage)
      {
         srcImage.Access();
         destImage.Access();

         byte[] buffer = new byte[srcImage.BytesPerLine];

         for (int y = 0; y < srcImage.Height; y++)
         {
            srcImage.GetRow(y, buffer, 0, buffer.Length);
            destImage.SetRow(y, buffer, 0, buffer.Length);
         }

         srcImage.Release();
         destImage.Release();
      }


      //#if LEADTOOLS_V18_OR_LATER
      //        private RasterImage _originalAvgCellImage = null;
      //        private RasterImage _originalCellImage = null;
      //#endif

      private void resetToolStripMenuItem_Click(object sender, EventArgs e)
      {

         if (MessageBox.Show("Are you sure you want to reset the Image", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
         {
            MedicalViewerMultiCell cell = (MedicalViewerMultiCell)GetSelectedCell();

            int orignalPage = cell.Image.Page;
            cell.Image.Page = cell.ActiveSubCell + 1;
            RasterImage orignalImage = _orignalImagesList[GetCellIndex(cell)][cell.ActiveSubCell];
            CopyBitmapData(cell.Image, orignalImage);

            cell.Image.Page = orignalPage;

            bool isEnhImageCell = false;
            StentData enhImageCellData = null;
            foreach (StentData data in _stentDataList)
            {
               if (data.EnhImageCell == cell)
               {
                  isEnhImageCell = true;
                  enhImageCellData = data;
                  break;
               }
            }

            if (isEnhImageCell && enhImageCellData != null)
            {
               _enhImageCell.SetWindowLevel(enhImageCellData.EnhImageCellWLWidth, enhImageCellData.EnhImageCellWLCenter);

               if (_enhImageCell.IsImageInverted(cell.ActiveSubCell))
               {
                  _enhImageCell.InvertImage(cell.ActiveSubCell);
               }

            }
            else
            {
               MedicalViewerWindowLevelValues windowLevelValues = cell.GetDefaultWindowLevelValues(cell.ActiveSubCell);

               cell.SetWindowLevel(windowLevelValues.Width, windowLevelValues.Center);

               if (cell.IsImageInverted(cell.ActiveSubCell))
               {
                  cell.InvertImage(cell.ActiveSubCell);
               }
            }

            orignalImage.Dispose();
            _orignalImagesList[GetCellIndex(cell)][cell.ActiveSubCell] = null;

            cell.Invalidate();
         }
      }

      public void SetAction(MedicalViewerActionType actionType, MedicalViewerMouseButtons mouseButton, MedicalViewerActionFlags applyingOperation)
      {
         if (mouseButton == MedicalViewerMouseButtons.Left)
         {
            CurrentAction = actionType;
            LeftButtonAction = actionType;
            CheckMoveMarkersAction(false);
            CheckSelectPoints(false);
         }
         if (mouseButton == MedicalViewerMouseButtons.Right)
         {
            RightButtonAction = actionType;
         }

         //cell.SetAction(actionType, mouseButton, applyingOperation);

         foreach (MedicalViewerBaseCell viewerCell in _medicalViewer.Cells)
         {
            viewerCell.SetAction(actionType, mouseButton, applyingOperation);
         }
      }

      void automation_OnShowContextMenu(object sender, AnnAutomationEventArgs e)
      {
         MedicalViewerBaseCell _viewer = ((MedicalViewerBaseCell)_medicalViewer.Cells[0]);
         Point point = _viewer.PointToClient(Cursor.Position);
         if (e != null && e.Object != null)
         {
            _viewer.AutomationInvalidate(LeadRectD.Empty);
            AnnAutomationObject annAutomationObject = e.Object as AnnAutomationObject;
            if (annAutomationObject != null)
            {
               ObjectContextMenu menu = annAutomationObject.ContextMenu as ObjectContextMenu;
               if (menu != null)
               {
                  menu.Automation = sender as AnnAutomation;
                  menu.Show(_viewer, point);
               }
            }
         }
         else
         {
            ManagerContextMenu defaultMenu = new ManagerContextMenu();
            defaultMenu.Automation = sender as AnnAutomation;
            defaultMenu.Show(_viewer, point);
         }
      }



      private void Rotate(int angle)
      {

         foreach (MedicalViewerCell cell in Viewer.Cells)
         {
            if (cell.Selected)
            {
               // Check whether to apply the command to all the image pages or only of the active page
               if (_miEffectOptionsApplyToAllSubCells.Checked)
               {
                  // Apply the command to all the image pages
                  int index;
                  for (index = 1; index <= cell.Image.PageCount; index++)
                  {
                     cell.Image.Page = index;
                     cell.Image.RotateViewPerspective(angle);

                  }
               }
               else
               {
                  // Apply the command to only the active page.
                  MedicalViewerStack stack = (MedicalViewerStack)cell.GetActionProperties(MedicalViewerActionType.Stack, Viewer.Cells.IndexOf(cell));
                  cell.Image.Page = stack.ScrollValue + stack.ActiveSubCell + 1;
                  cell.Image.RotateViewPerspective(angle);
               }
               // Redraw the cell to adopt the new changes.
               cell.UpdateView();
               cell.Invalidate();
            }
         }
      }

      private void _miRotate90_Click(object sender, EventArgs e)
      {
         Rotate(90);
      }

      private void _miRotate180_Click(object sender, EventArgs e)
      {
         Rotate(180);
      }

      private void _miRotateMinus90_Click(object sender, EventArgs e)
      {
         Rotate(-90);
      }

      private void _miRotateMinus180_Click(object sender, EventArgs e)
      {
         Rotate(-180);
      }

      private void _miEditAnnotation_Click(object sender, EventArgs e)
      {
         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)GetSelectedCell();
         ShowViewerDialogs(new AnnotationPropertiesDialog(cell));
      }

      private void _annotationMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)GetSelectedCell();
         if (cell == null)
         {
            _miEditAnnotation.Enabled = false;
            return;
         }

         AnnObject currentObject = cell.Automation.CurrentEditObject;
         if (currentObject is AnnPointObject)
         {
            _miEditAnnotation.Enabled = false;
         }
         else
         {
            if (currentObject != null)
            {
               _miEditAnnotation.Enabled = (currentObject.SupportsStroke || currentObject.SupportsFont || currentObject.SupportsFill);
            }
            else
               _miEditAnnotation.Enabled = false;
         }
      }
   }


   // A class that is derived from System.Windows.Forms.Label control
   public partial class ColorBox : System.Windows.Forms.Label
   {
      private Color _color;


      public ColorBox()
      {
         _color = Color.Transparent;
      }

      public Color BoxColor
      {
         set
         {
            _color = Color.FromArgb(255, value);
            if (this.Enabled)
               BackColor = _color;
         }
         get
         {
            return Color.FromArgb(0, _color.R, _color.G, _color.B);
         }
      }

      protected override void OnBackColorChanged(EventArgs e)
      {
         base.OnBackColorChanged(e);
         if (BackColor != Color.Transparent)
            _color = BackColor;
      }

      protected override void OnEnabledChanged(EventArgs e)
      {
         base.OnEnabledChanged(e);
         if (this.Enabled)
            BackColor = _color;
         else
            BackColor = Color.Transparent;
      }

      protected override void OnDoubleClick(EventArgs e)
      {
         MainForm.ShowColorDialog(this);
         _color = BackColor;
         base.OnDoubleClick(e);
      }
   }


   // A class that is derieved from TextBox control, that allows only
   // 1) The numeric values.
   // 2) The values that fall within the given range.
   public partial class FNumericTextBox : System.Windows.Forms.TextBox
   {
      private double _maximumAllowed;
      private double _minimumAllowed;
      private string _oldText;

      public FNumericTextBox()
      {
         _maximumAllowed = 1000.0;
         _minimumAllowed = -1000.0;
         _oldText = "";
      }

      [Description("The minimum allowed value to be entered"),
      Category("Allowed Values")]
      public double MinimumAllowed
      {
         set
         {
            _minimumAllowed = value;
         }
         get
         {
            return _minimumAllowed;
         }
      }

      [Description("The maximum allowed value to be entered"),
      Category("Allowed Values")]
      public double MaximumAllowed
      {
         set
         {
            _maximumAllowed = value;
         }
         get
         {
            return _maximumAllowed;
         }
      }

      [Description("The numeric value of the Text box"),
      Category("Current Value")]
      public double Value
      {
         set
         {
            this.Text = value.ToString();
         }
         get
         {
            if (this.Text.Trim() == "")
               return _minimumAllowed;
            else
               return Convert.ToDouble(this.Text);
         }
      }

      // Is the entered number within the specified valid range
      private bool IsAllowed(string text)
      {
         bool isAllowed = true;

         try
         {
            double newNumber = Convert.ToDouble(text);
            if ((newNumber > _maximumAllowed) || (newNumber < _minimumAllowed))
               isAllowed = false;
         }
         catch
         {
            // This happen if the entered value is not a numeric.
            isAllowed = false;
         }

         return isAllowed;
      }

      protected override void OnTextChanged(EventArgs e)
      {
         if (!IsAllowed(this.Text))
         {
            // If this condition doesn't exist, the user will be bugged. (trust me).
            if (_minimumAllowed <= 0)
               this.Text = _oldText;
         }
         else
            _oldText = this.Text;

         base.OnTextChanged(e);
      }

      protected override void OnKeyDown(KeyEventArgs e)
      {
         // Increase or decrease the current value by 1 if the user presses the UP or DOWN
         // and test if the new value is allowed
         if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
         {
            double value = Convert.ToDouble(this.Text);

            value = (e.KeyCode == Keys.Up) ? value + 0.1 : value - 0.1;

            if (IsAllowed(value.ToString()))
               this.Text = value.ToString();
         }

         base.OnKeyDown(e);
      }

      protected override void OnLostFocus(EventArgs e)
      {
         double value = (this.Text.Trim() == "") ? _minimumAllowed : Convert.ToDouble(this.Text);
         if (value < _minimumAllowed)
            this.Text = _minimumAllowed.ToString();

         base.OnLostFocus(e);
      }

      protected override void OnKeyPress(KeyPressEventArgs e)
      {
         // if Enter, Escape, Ctrl or Alt key is pressed, then there is no need to check
         // since the user is not entering a new character...
         if (((Control.ModifierKeys & Keys.Control) == 0) &&
             ((Control.ModifierKeys & Keys.Alt) == 0) &&
              (e.KeyChar != Convert.ToChar(Keys.Enter)) &&
              (e.KeyChar != Convert.ToChar(Keys.Escape)) &&
              (e.KeyChar != Convert.ToChar(Keys.Back)))
         {
            #region Check if the entered character is valid for Numeric format
            // Validate the entered character
            if (!Char.IsNumber(e.KeyChar))
            {

               #region Check If the user has entered Minus character
               // Here we check if the user wants to enter the "-" character.
               if (!((this.Text.IndexOf('-') == -1) && // there is no Minus character
                     (this.SelectionStart == 0) && // the cursor at the begining
                     (_minimumAllowed < 0) && // the minimum allowed accept negative values
                     (e.KeyChar == '-')))  // the character entered was a Minus character
               {
                  if (!((e.KeyChar == '.') &&
                     (this.Text.IndexOf('.') == -1)))
                     e.KeyChar = Char.MinValue;
               }
               #endregion
            }
            #endregion

            if (_minimumAllowed <= 0)
               #region Checkinng if the value falles within the given range
               if (e.KeyChar != Char.MinValue)
               {
                  // Create the string that will be displayed, and check whether it's valid or not.

                  // Remove the selected character(s).
                  string newString = this.Text.Remove(this.SelectionStart, this.SelectionLength);
                  // Insert the new character.
                  newString = newString.Insert(this.SelectionStart, e.KeyChar.ToString());
                  if (!IsAllowed(newString))
                     // the new string is not valid, cancel the whole operation.
                     e.KeyChar = Char.MinValue;
               }
               #endregion
         }
         base.OnKeyPress(e);
      }
   }


   public partial class CursorButton : System.Windows.Forms.Button
   {
      private Cursor _buttonCursor;

      public CursorButton()
      {
         _buttonCursor = null;
      }

      [Description("The Cursor"),
      Category("Cursor")]
      public Cursor ButtonCursor
      {
         set
         {
            _buttonCursor = value;
         }
         get
         {
            return _buttonCursor;
         }
      }

      protected override void OnClick(EventArgs e)
      {
         base.OnClick(e);
         OpenFileDialog openDialog = new OpenFileDialog();
         openDialog.Filter = @"Cursor files (*.cur) | *.cur";
         openDialog.RestoreDirectory = true;

         if (openDialog.ShowDialog() == DialogResult.OK)
         {
            try
            {
               _buttonCursor = new System.Windows.Forms.Cursor(openDialog.FileName);
            }
            catch (System.Exception ex)
            {
               Messager.ShowError(this, ex);
            }

         }
      }

      protected override void OnPaint(PaintEventArgs pevent)
      {
         base.OnPaint(pevent);
         if (_buttonCursor != null)
         {
            int averageWidth = (pevent.ClipRectangle.Width - _buttonCursor.Size.Width) / 2;
            int averageHeight = (pevent.ClipRectangle.Height - _buttonCursor.Size.Height) / 2;

            _buttonCursor.Draw(pevent.Graphics, new Rectangle(averageWidth, averageHeight, _buttonCursor.Size.Width, _buttonCursor.Size.Height));
         }
      }
   }

   // A class that is derieved from TextBox control, that allows only
   // 1) The numeric values.
   // 2) The values that fall within the given range.
   public partial class NumericTextBox : System.Windows.Forms.TextBox
   {
      private int _maximumAllowed;
      private int _minimumAllowed;
      private string _oldText;

      public NumericTextBox()
      {
         _maximumAllowed = 1000;
         _minimumAllowed = -1000;
         _oldText = "";
      }

      [Description("The minimum allowed value to be entered"),
      Category("Allowed Values")]
      public int MinimumAllowed
      {
         set
         {
            _minimumAllowed = value;
         }
         get
         {
            return _minimumAllowed;
         }
      }

      [Description("The maximum allowed value to be entered"),
      Category("Allowed Values")]
      public int MaximumAllowed
      {
         set
         {
            _maximumAllowed = value;
         }
         get
         {
            return _maximumAllowed;
         }
      }

      [Description("The maximum allowed value to be entered"),
      Category("Current Value")]
      public int Value
      {
         set
         {
            this.Text = value.ToString();
         }
         get
         {
            if (this.Text.Trim() == "")
               return _minimumAllowed;
            else
               return Convert.ToInt32(this.Text);
         }
      }

      // Is the entered number within the specified valid range
      private bool IsAllowed(string text)
      {
         bool isAllowed = true;

         try
         {
            int newNumber = Convert.ToInt32(text);
            if ((newNumber > _maximumAllowed) || (newNumber < _minimumAllowed))
               isAllowed = false;
         }
         catch
         {
            // This happen if the entered value is not a numeric.
            isAllowed = false;
         }

         return isAllowed;
      }

      protected override void OnTextChanged(EventArgs e)
      {
         if (!IsAllowed(this.Text))
         {
            if (_minimumAllowed <= 1)
               this.Text = _oldText;
         }
         else
            _oldText = this.Text;

         base.OnTextChanged(e);
      }

      protected override void OnKeyDown(KeyEventArgs e)
      {
         // Increase or decrease the current value by 1 if the user presses the UP or DOWN
         // and test if the new value is allowed
         if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
         {
            int value = Convert.ToInt32(this.Text);

            value = (e.KeyCode == Keys.Up) ? value + 1 : value - 1;

            if (IsAllowed(value.ToString()))
               this.Text = value.ToString();
         }

         base.OnKeyDown(e);
      }

      protected override void OnLostFocus(EventArgs e)
      {
         int value = Convert.ToInt32(this.Text);
         if (value < _minimumAllowed)
            this.Text = _minimumAllowed.ToString();

         base.OnLostFocus(e);
      }

      protected override void OnKeyPress(KeyPressEventArgs e)
      {
         // if Enter, Escape, Ctrl or Alt key is pressed, then there is no need to check
         // since the user is not entering a new character...
         if (((Control.ModifierKeys & Keys.Control) == 0) &&
             ((Control.ModifierKeys & Keys.Alt) == 0) &&
              (e.KeyChar != Convert.ToChar(Keys.Enter)) &&
              (e.KeyChar != Convert.ToChar(Keys.Escape)))
         {
            #region Check if the entered character is valid for Numeric format
            // Validate the entered character
            if (!Char.IsNumber(e.KeyChar))
            {

               #region Check If the user has entered Minus character
               // Here we check if the user wants to enter the "-" character.
               if (!((this.Text.IndexOf('-') == -1) && // there is no Minus character
                     (this.SelectionStart == 0) && // the cursor at the begining
                     (_minimumAllowed < 0) && // the minimum allowed accept negative values
                     (e.KeyChar == '-')))  // the character entered was a Minus character
                  e.KeyChar = Char.MinValue;
               #endregion
            }
            #endregion

            if (_minimumAllowed <= 1)
               #region Checkinng if the value falles within the given range
               if (e.KeyChar != Char.MinValue)
               {
                  // Create the string that will be displayed, and check whether it's valid or not.

                  // Remove the selected character(s).
                  string newString = this.Text.Remove(this.SelectionStart, this.SelectionLength);
                  // Insert the new character.
                  newString = newString.Insert(this.SelectionStart, e.KeyChar.ToString());
                  if (!IsAllowed(newString))
                     // the new string is not valid, cancel the whole operation.
                     e.KeyChar = Char.MinValue;
               }
               #endregion
         }
         base.OnKeyPress(e);
      }
   }
}
