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

using Leadtools;
using Leadtools.Dicom;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.ImageProcessing;
using Leadtools.MedicalViewer;
using Leadtools.ImageProcessing.Color;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Leadtools.Controls;

namespace MedicalViewerLayoutDemo
{
   public partial class MainForm : Form
   {
      private int _images;
      private int _cellIndex;
      private MedicalViewer _medicalViewer;
      private bool _applyToAll;
      private PrintDocument _printDocument;
      private RasterImage _printImage;
      private string _layoutFile = string.Empty;
      private string _openInitialPath = string.Empty;

      [DllImport("user32.dll")]
      static extern bool LockWindowUpdate(IntPtr hWndLock);

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

      private static MedicalViewerMultiCell _GlobalCell;

      public static MedicalViewerMultiCell GlobalCell
      {
         get
         {
            if (_GlobalCell == null)
            {
               _GlobalCell = new MedicalViewerMultiCell();
               InitalizeCell(_GlobalCell);
            }
            return _GlobalCell;
         }
      }

      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         if (RasterSupport.IsLocked(RasterSupportType.Medical))
         {
            MessageBox.Show("Medical support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
         InitClass();
         Application.Idle += new EventHandler(Application_Idle);
      }

      void Application_Idle(object sender, EventArgs e)
      {
         bool designMode = Viewer.LayoutOptions.UserMode == MedicalViewerUserMode.Design;

         toolStripButtonUserMode.Checked = designMode;
         toolStripButtonSelect.Checked = Viewer.LayoutOptions.DesignTool == MedicalViewerDesignTool.Selection;
         toolStripButtonDraw.Checked = Viewer.LayoutOptions.DesignTool == MedicalViewerDesignTool.Draw;
         toolStripButtonSelect.Enabled = toolStripButtonDraw.Enabled = designMode;
      }

      private void InitClass()
      {
         CounterDialog counter = null;

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
            {
               _printDocument = null;
            }
         }
         catch (Exception)
         {
            _printDocument = null;
         }

         try
         {
            DicomEngine.Startup();

            counter = new CounterDialog(this, new RasterCodecs());
            _applyToAll = false;

            _medicalViewer = new MedicalViewer(false);

            _medicalViewer.Location = new Point(0, 0);
            _medicalViewer.Dock = DockStyle.Fill;
            _medicalViewer.Cells.ItemAdded += new EventHandler<MedicalViewerCollectionEventArgs<MedicalViewerBaseCell>>(Cells_ItemAdded);

            _mainPanel.Controls.Add(_medicalViewer);
         }
         catch (Exception ex)
         {
            if (counter != null)
            {
               if (counter.Visible)
                  counter.Close();
            }
            MessageBox.Show(ex.Message, ex.Source);
         }
      }

      void Cells_ItemAdded(object sender, MedicalViewerCollectionEventArgs<MedicalViewerBaseCell> e)
      {
         MedicalViewerCell cell = e.Item as MedicalViewerCell;

         InitalizeCell(cell);
         CopyPropertiesFromGlobalCell(cell);
         cell.Tag = _medicalViewer.Cells.Count - 1;
         cell.SetTag(0, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, "Image Box " + cell.Tag);
         cell.SetTag(0, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, cell.OverlapPriority.ToString());
      }

      private static void CopyPropertiesFromGlobalCell(MedicalViewerCell cell)
      {
         MedicalViewerActionType actionType;
         MedicalViewerMouseButtons button;
         MedicalViewerActionFlags flags;
         MedicalViewerKeys keys;

         for (actionType = MedicalViewerActionType.WindowLevel; actionType <= MedicalViewerActionType.Alpha; actionType++)
         {
            button = GlobalCell.GetActionButton(actionType);
            flags = GlobalCell.GetActionFlags(actionType);

            if (button != MedicalViewerMouseButtons.None)
            {
               cell.SetAction(actionType, button, flags);
            }

            keys = GlobalCell.GetActionKeys(actionType);
            cell.SetActionKeys(actionType, keys);

         }

         MedicalViewerWindowLevel windowLevelAction = (MedicalViewerWindowLevel)GlobalCell.GetActionProperties(MedicalViewerActionType.WindowLevel);

         MedicalViewerWindowLevel windowLevel = new MedicalViewerWindowLevel();
         windowLevel.ActionCursor = windowLevelAction.ActionCursor;
         windowLevel.CircularMouseMove = windowLevelAction.CircularMouseMove;
         windowLevel.Sensitivity = windowLevelAction.Sensitivity;

         cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevel);


         MedicalViewerAlpha AlphaAction = (MedicalViewerAlpha)GlobalCell.GetActionProperties(MedicalViewerActionType.Alpha);

         MedicalViewerAlpha Alpha = new MedicalViewerAlpha();
         Alpha.ActionCursor = AlphaAction.ActionCursor;
         Alpha.CircularMouseMove = AlphaAction.CircularMouseMove;
         Alpha.Sensitivity = AlphaAction.Sensitivity;

         cell.SetActionProperties(MedicalViewerActionType.Alpha, Alpha);

         MedicalViewerScale ScaleAction = (MedicalViewerScale)GlobalCell.GetActionProperties(MedicalViewerActionType.Scale);

         MedicalViewerScale Scale = new MedicalViewerScale();
         Scale.ActionCursor = ScaleAction.ActionCursor;
         Scale.CircularMouseMove = ScaleAction.CircularMouseMove;
         Scale.Sensitivity = ScaleAction.Sensitivity;

         cell.SetActionProperties(MedicalViewerActionType.Scale, Scale);


         MedicalViewerStack StackAction = (MedicalViewerStack)GlobalCell.GetActionProperties(MedicalViewerActionType.Stack);

         MedicalViewerStack Stack = new MedicalViewerStack();
         Stack.ActionCursor = StackAction.ActionCursor;
         Stack.CircularMouseMove = StackAction.CircularMouseMove;
         Stack.Sensitivity = StackAction.Sensitivity;

         cell.SetActionProperties(MedicalViewerActionType.Stack, Stack);

         MedicalViewerOffset offsetAction = (MedicalViewerOffset)GlobalCell.GetActionProperties(MedicalViewerActionType.Offset);

         MedicalViewerOffset offset = new MedicalViewerOffset();
         offset.ActionCursor = offsetAction.ActionCursor;
         offset.CircularMouseMove = offsetAction.CircularMouseMove;
         offset.Sensitivity = offsetAction.Sensitivity;

         cell.SetActionProperties(MedicalViewerActionType.Offset, offset);

         MedicalViewerMagnifyGlass magnifyAction = (MedicalViewerMagnifyGlass)GlobalCell.GetActionProperties(MedicalViewerActionType.MagnifyGlass);
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

         if (cell.CellBackColor != _GlobalCell.CellBackColor)
            cell.CellBackColor = _GlobalCell.CellBackColor;

         if (cell.TextColor != _GlobalCell.TextColor)
            cell.TextColor = _GlobalCell.TextColor;

         if (cell.TextShadowColor != _GlobalCell.TextShadowColor)
            cell.TextShadowColor = _GlobalCell.TextShadowColor;

         if (cell.ActiveBorderColor != _GlobalCell.ActiveBorderColor)
            cell.ActiveBorderColor = _GlobalCell.ActiveBorderColor;

         if (cell.NonActiveBorderColor != _GlobalCell.NonActiveBorderColor)
            cell.NonActiveBorderColor = _GlobalCell.NonActiveBorderColor;

         if (cell.ActiveSubCellBorderColor != _GlobalCell.ActiveSubCellBorderColor)
            cell.ActiveSubCellBorderColor = _GlobalCell.ActiveSubCellBorderColor;

         if (cell.RulerInColor != _GlobalCell.RulerInColor)
            cell.RulerInColor = _GlobalCell.RulerInColor;

         if (cell.RulerOutColor != _GlobalCell.RulerOutColor)
            cell.RulerOutColor = _GlobalCell.RulerOutColor;

         if (cell.Titlebar.UseCustomColor != _GlobalCell.Titlebar.UseCustomColor)
            cell.Titlebar.UseCustomColor = _GlobalCell.Titlebar.UseCustomColor;

         if (cell.Titlebar.Color != _GlobalCell.Titlebar.Color)
            cell.Titlebar.Color = _GlobalCell.Titlebar.Color;

         if (cell.Titlebar.Visible != _GlobalCell.Titlebar.Visible)
            cell.Titlebar.Visible = _GlobalCell.Titlebar.Visible;

         if (cell.TextQuality != _GlobalCell.TextQuality)
            cell.TextQuality = _GlobalCell.TextQuality;

         if (cell.RulerStyle != _GlobalCell.RulerStyle)
            cell.RulerStyle = _GlobalCell.RulerStyle;

         if (cell.ShowCellScroll != _GlobalCell.ShowCellScroll)
            cell.ShowCellScroll = _GlobalCell.ShowCellScroll;

         if (cell.ShowFreezeText != _GlobalCell.ShowFreezeText)
            cell.ShowFreezeText = _GlobalCell.ShowFreezeText;

         if (cell.PaintingMethod != _GlobalCell.PaintingMethod)
            cell.PaintingMethod = _GlobalCell.PaintingMethod;

         if (cell.MeasurementUnit != _GlobalCell.MeasurementUnit)
            cell.MeasurementUnit = _GlobalCell.MeasurementUnit;

         if (cell.BorderStyle != _GlobalCell.BorderStyle)
            cell.BorderStyle = _GlobalCell.BorderStyle;
      }

      private static void InitalizeCell(MedicalViewerCell cell)
      {
         MedicalViewerKeys medicalKeys = new MedicalViewerKeys();

         cell.AddAction(MedicalViewerActionType.WindowLevel);
         cell.AddAction(MedicalViewerActionType.Scale);
         cell.AddAction(MedicalViewerActionType.Offset);
         cell.AddAction(MedicalViewerActionType.Stack);
         cell.AddAction(MedicalViewerActionType.MagnifyGlass);
         cell.AddAction(MedicalViewerActionType.Alpha);
         cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
         cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active);
         cell.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Middle, MedicalViewerActionFlags.Active);
         cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active);

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
      }

      private void CreateLayout(float[] l, float[] t, float[] r, float[] b)
      {
         _medicalViewer.Cells.Clear();
         try
         {
            LockWindowUpdate(_medicalViewer.Handle);
            for (int i = 0; i < l.Length; i++)
            {
               MedicalViewerMultiCell cell = new MedicalViewerMultiCell(null, false, 1, 1);

               cell.LayoutPosition = new MedicalViewerLayoutPosition(l[i], t[i], r[i], b[i]);

               try
               {
                  cell.FitImageToCell = true;
                  _medicalViewer.Cells.Add(cell);
               }
               catch (Exception e)
               {
                  MessageBox.Show(e.Message);
               }
            }
         }
         finally
         {
            LockWindowUpdate(IntPtr.Zero);
         }
      }

      private void _printDocument_BeginPrint(object sender, PrintEventArgs e)
      {
         // This demo will print one page at a time, so no need to re-start the print page number
      }

      private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
      {
         ColorResolutionCommand colorResolutionCommand = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, 24, RasterByteOrder.Bgr, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.None, null);
         colorResolutionCommand.Run(PrintImage);

         // Get the print document object
         PrintDocument document = sender as PrintDocument;

         // Create an new LEADTOOLS image printer class
         RasterImagePrinter printer = new RasterImagePrinter();

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

         // Inform the printer that we have no more pages to print
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
            if (Viewer.Cells[currentCellIndex].Selected)
               Viewer.Cells.RemoveAt(currentCellIndex);
            else
               ++currentCellIndex;
         }
      }

      private void _miEditRemoveSelectedCells_Click(object sender, EventArgs e)
      {
         RemoveSelectedCells();
      }

      private void _miEditSelectAll_Click(object sender, EventArgs e)
      {
         _medicalViewer.Cells.SelectAll(true);
      }

      private void _miEditDeselectAll_Click(object sender, EventArgs e)
      {
         _medicalViewer.Cells.SelectAll(false);
      }

      private void _miEditInvertSelection_Click(object sender, EventArgs e)
      {
         _medicalViewer.Cells.InvertSelection();
      }

      private DialogResult ShowViewerDialogs(Form Dialog)
      {
         return Dialog.ShowDialog(this);
      }

      // Open "LEAD Open File Dialog" and return the selected image
      private RasterImage LoadImage()
      {
         ImageFileLoader loader = new ImageFileLoader();

         try
         {
            loader.ShowLoadPagesDialog = true;
            loader.OpenDialogInitialPath = _openInitialPath;

            using (RasterCodecs codecs = new RasterCodecs())
            {
            if (loader.Load(this, codecs, false) > 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               CounterDialog counter = new CounterDialog(this, codecs);
               _images = 1;
               counter.Show(this);
               counter.Update();
               return codecs.Load(loader.FileName, 0, CodecsLoadByteOrder.BgrOrGray, loader.FirstPage, loader.LastPage);
            }
         }
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }

         return null;
      }

      private void _fileMenuItem_exit_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _miEditFreezeCell_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new FreezeCellDialog(this));
      }

      private void _miEditToggleFreeze_Click(object sender, EventArgs e)
      {
         foreach (MedicalViewerCell cell in _medicalViewer.Cells)
         {
            if (cell.Selected)
               cell.Frozen = !cell.Frozen;
         }
      }

      private void _miPropertiesViewerProperties_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new ViewerPropertiesDialog(this, GlobalCell));
      }

      private void _miPropertiesCellProperties_Click(object sender, EventArgs e)
      {
         int i = 0;
         MedicalViewerMultiCell cell = null;
         while ((cell == null) && i < this.Viewer.Cells.Count)
         {
            if (this.Viewer.Cells[i].Selected)
               cell = (MedicalViewerMultiCell)this.Viewer.Cells[i];
            else
               ++i;
         }
         ShowViewerDialogs(new CellPropertiesDialog(this, cell));
      }

      private void _miActionWindowLevelSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, _medicalViewer, GlobalCell, MedicalViewerActionType.WindowLevel));
      }

      private void _miActionAlphaSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, _medicalViewer, GlobalCell, MedicalViewerActionType.Alpha));
      }

      private void _miActionScaleSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, _medicalViewer, GlobalCell, MedicalViewerActionType.Scale));
      }

      private void _miMagnifySet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, _medicalViewer, GlobalCell, MedicalViewerActionType.MagnifyGlass));
      }

      private void _miActionStackSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, _medicalViewer, GlobalCell, MedicalViewerActionType.Stack));
      }

      private void _miActionOffsetSet_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new SetActionDialog(this, _medicalViewer, GlobalCell, MedicalViewerActionType.Offset));
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
            if (Viewer.Cells[index].Selected)
               return true;
            else
               index++;
         }
         return false;
      }

      public MedicalViewerCell SearchForFirstSelected()
      {
         foreach (MedicalViewerCell cell in Viewer.Cells)
         {
            if (cell.Selected)
               return cell;
         }
         return null;
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

      private void _miEditAnimation_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new AnimationDialog(SearchForFirstSelected()));
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

      private void _editMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         bool selected = GetSelectedCell() != null;
         bool enabled = Viewer.Cells.Count != 0;

         _miEditAnimation.Enabled = enabled && selected && _medicalViewer.LayoutOptions.UserMode == MedicalViewerUserMode.Run && GetSelectedCell().Image != null && GetSelectedCell().Image.PageCount > 1;
         _miEditFreezeCell.Enabled = enabled && _medicalViewer.LayoutOptions.UserMode == MedicalViewerUserMode.Run;
         _miEditToggleFreeze.Enabled = enabled && selected && _medicalViewer.LayoutOptions.UserMode == MedicalViewerUserMode.Run;
         _miEditSelectAll.Enabled = enabled;
         _miEditDeselectAll.Enabled = enabled && selected;
         _miEditInvertSelection.Enabled = enabled && _medicalViewer.LayoutOptions.UserMode == MedicalViewerUserMode.Run;
         _miEditRemoveCell.Enabled = enabled && _medicalViewer.LayoutOptions.UserMode == MedicalViewerUserMode.Run;
         _miEditRemoveSelectedCells.Enabled = enabled && _medicalViewer.LayoutOptions.UserMode == MedicalViewerUserMode.Run && selected;
      }

      private void _miHelpAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Medical Viewer (Layout)", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _propertiesMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         bool enabled = Viewer.Cells.Count != 0;

         //_miPropertiesViewerProperties.Enabled = _medicalViewer.LayoutOptions.UserMode == MedicalViewerUserMode.Run;
         _miPropertiesCellProperties.Enabled = enabled && _medicalViewer.LayoutOptions.UserMode == MedicalViewerUserMode.Run;
      }

      void _fileMenuItem_DropDownOpening(object sender, System.EventArgs e)
      {
         saveLayoutToolStripMenuItem.Enabled = Viewer.Cells.Count > 0;
         insertImageToolStripMenuItem.Enabled = IsThereASelectedCell() && _medicalViewer.LayoutOptions.UserMode == MedicalViewerUserMode.Run;
         _printCellMenuItem.Enabled = IsThereASelectedCell() && (GetSelectedCell().Image != null);
      }

      private void _miActionAlphaCustomizeAlpha_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new AlphaPropertiesDialog(this, GetSelectedCell()));
      }

      private void _miEditRemoveCell_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new RemoveCellDialog(this));
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         DicomEngine.Shutdown();
      }

      private void _printCellMenuItem_Click(object sender, EventArgs e)
      {
         ShowViewerDialogs(new PrintCellDialog(this, GetSelectedCell()));
      }

      private int _type = 2;
      private void bW4ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _type = 4;
         CreateLayout(new float[] { 0.049217F, 0.2774049F, 0.5055928F, 0.7337807F },
                      new float[] { 0.8248175F, 0.8248175F, 0.8248175F, 0.8248175F },
                      new float[] { 0.246085F, 0.4742729F, 0.7024608F, 0.9306487F },
                      new float[] { 0.4233577F, 0.4233577F, 0.4233577F, 0.4233577F });
      }

      private void fMX18ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _type = 18;
         CreateLayout(new float[] { 0.03412463F, 0.1928783F, 0.3531157F, 0.458457F, 0.5608308F, 0.6617211F, 0.8204748F, 0.03412463F, 0.1928783F, 0.6617211F, 0.8204748F, 0.03412463F, 0.1928783F, 0.3531157F, 0.458457F, 0.5608308F, 0.6617211F, 0.8204748F },
                      new float[] { 0.9457364F, 0.9457364F, 0.9457364F, 0.9457364F, 0.9457364F, 0.9457364F, 0.9457364F, 0.6666666F, 0.6666666F, 0.6666666F, 0.6666666F, 0.3992248F, 0.3953488F, 0.4767442F, 0.4767442F, 0.4767442F, 0.3992248F, 0.3953488F },
                      new float[] { 0.1646884F, 0.3234421F, 0.4272997F, 0.5326409F, 0.6350148F, 0.7922848F, 0.9510386F, 0.1646884F, 0.3234421F, 0.7922848F, 0.9510386F, 0.1646884F, 0.3234421F, 0.4272997F, 0.5326409F, 0.6350148F, 0.7922848F, 0.9510386F },
                      new float[] { 0.7325581F, 0.7325581F, 0.6511628F, 0.6511628F, 0.6511628F, 0.7325581F, 0.7325581F, 0.4534883F, 0.4534883F, 0.4534883F, 0.4534883F, 0.1860465F, 0.1821706F, 0.1821706F, 0.1821706F, 0.1821706F, 0.1860465F, 0.1821706F });
      }

      private void bW2ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _type = 2;
         CreateLayout(new float[] { 0.06F, 0.55F }, new float[] { 0.75F, 0.75F },
                      new float[] { 0.45F, 0.94F }, new float[] { 0.25F, 0.25F });
      }

      private void fMX20ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _type = 20;
         CreateLayout(new float[] { 0.04262673F, 0.1831797F, 0.3087558F, 0.3847926F, 0.4608295F, 0.5368664F, 0.6129032F, 0.6947005F, 0.8352535F, 0.04262673F, 0.1831797F, 0.6947005F, 0.8352535F, 0.04262673F, 0.1831797F, 0.3778802F, 0.4608295F, 0.5437788F, 0.6947005F, 0.8352535F },
                      new float[] { 0.9014925F, 0.9014925F, 0.8477612F, 0.8477612F, 0.8477612F, 0.8477612F, 0.8477612F, 0.9014925F, 0.9014925F, 0.6507462F, 0.6507462F, 0.6507462F, 0.6507462F, 0.4F, 0.4F, 0.5402985F, 0.5402985F, 0.5402985F, 0.4F, 0.4F },
                      new float[] { 0.156682F, 0.297235F, 0.3778802F, 0.4539171F, 0.5299539F, 0.6059908F, 0.6820276F, 0.8087558F, 0.9493088F, 0.156682F, 0.297235F, 0.8087558F, 0.9493088F, 0.156682F, 0.297235F, 0.4470046F, 0.5299539F, 0.6129032F, 0.8087558F, 0.9493088F },
                      new float[] { 0.7014925F, 0.7014925F, 0.5582089F, 0.5582089F, 0.5582089F, 0.5582089F, 0.5582089F, 0.7014925F, 0.7014925F, 0.4507463F, 0.4507463F, 0.4507463F, 0.4507463F, 0.2F, 0.2F, 0.2507463F, 0.2507463F, 0.2507463F, 0.2F, 0.2F });
      }

      private void layoutToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         designToolStripMenuItem.Checked = Viewer.LayoutOptions.UserMode == MedicalViewerUserMode.Design;
         gridToolStripMenuItem.Enabled = Viewer.LayoutOptions.UserMode == MedicalViewerUserMode.Design;
         toolToolStripMenuItem.Enabled = Viewer.LayoutOptions.UserMode == MedicalViewerUserMode.Design;
         allowCellsToOverlappToolStripMenuItem.Checked = Viewer.LayoutOptions.AllowOverlappingCells;
         showLocationToolStripMenuItem.Checked = Viewer.LayoutOptions.ShowPosition;

         bW2ToolStripMenuItem.Checked = false;
         bW4ToolStripMenuItem.Checked = false;
         fMX18ToolStripMenuItem.Checked = false;
         fMX20ToolStripMenuItem.Checked = false;

         switch (_type)
         {
            case 2:
               bW2ToolStripMenuItem.Checked = true;
               break;
            case 4:
               bW4ToolStripMenuItem.Checked = true;
               break;
            case 18:
               fMX18ToolStripMenuItem.Checked = true;
               break;
            case 20:
               fMX20ToolStripMenuItem.Checked = true;
               break;
         }

     }

      private void designToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _medicalViewer.LayoutOptions.UserMode = _medicalViewer.LayoutOptions.UserMode == MedicalViewerUserMode.Run
                                       ? MedicalViewerUserMode.Design
                                       : MedicalViewerUserMode.Run;
         if (_medicalViewer.LayoutOptions.UserMode == MedicalViewerUserMode.Run)
         {
            selectionToolStripMenuItem_Click(this, EventArgs.Empty);
         }
         _medicalViewer.Refresh();
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
          toolStripButtonOverlap.Checked = Viewer.LayoutOptions.AllowOverlappingCells;
          toolStripButtonShowPosition.Checked = Viewer.LayoutOptions.ShowPosition;
          bW2ToolStripMenuItem.Checked = true;
          SetDefaultLayout();
      }

      private void SetDefaultLayout()
      {
          CreateLayout(new float[] { 0.06F, 0.55F }, new float[] { 0.75F, 0.75F },
                       new float[] { 0.45F, 0.94F }, new float[] { 0.25F, 0.25F });

          bW2ToolStripMenuItem.Checked = true;

          using (RasterCodecs codecs = new RasterCodecs())
          {
               foreach (MedicalViewerCell cell in _medicalViewer.Cells)
               {
                  RasterImage image = codecs.Load(DemosGlobal.ImagesFolder + "\\IMAGE2.dcm", 1);
                  if (image != null)
                  {
                     cell.Image = image;
                  }
               }
          }
      }

      private void showToolStripMenuItem_Click(object sender, EventArgs e)
      {
         showToolStripMenuItem.Checked = !showToolStripMenuItem.Checked;
         _medicalViewer.LayoutOptions.ShowGrid = showToolStripMenuItem.Checked;
      }

      private void snapToolStripMenuItem_Click(object sender, EventArgs e)
      {
         snapToolStripMenuItem.Checked = !snapToolStripMenuItem.Checked;
         _medicalViewer.LayoutOptions.SnapToGrid = snapToolStripMenuItem.Checked;
      }

      private void gridToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         showToolStripMenuItem.Checked = _medicalViewer.LayoutOptions.ShowGrid;
         snapToolStripMenuItem.Checked = _medicalViewer.LayoutOptions.SnapToGrid;
         showLinesToolStripMenuItem.Checked = _medicalViewer.LayoutOptions.ShowLines;
      }

      private void sizeToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         switch (_medicalViewer.LayoutOptions.GridSize.Width)
         {
            case 2:
               x6ToolStripMenuItem.Checked = false;
               x8ToolStripMenuItem.Checked = false;
               x10ToolStripMenuItem.Checked = false;
               break;
            case 4:
               x6ToolStripMenuItem.Checked = false;
               x8ToolStripMenuItem.Checked = false;
               x10ToolStripMenuItem.Checked = false;
               break;
            case 6:
               x6ToolStripMenuItem.Checked = true;
               x8ToolStripMenuItem.Checked = false;
               x10ToolStripMenuItem.Checked = false;
               break;
            case 8:
               x6ToolStripMenuItem.Checked = false;
               x8ToolStripMenuItem.Checked = true;
               x10ToolStripMenuItem.Checked = false;
               break;
            case 10:
               x6ToolStripMenuItem.Checked = false;
               x8ToolStripMenuItem.Checked = false;
               x10ToolStripMenuItem.Checked = true;
               break;
         }
      }

      private void SetGridSize(object sender, EventArgs e)
      {
         ToolStripMenuItem item = sender as ToolStripMenuItem;
         int size = Convert.ToInt32(item.Tag);

         _medicalViewer.LayoutOptions.GridSize = new Size(size, size);
      }

      private void saveLayoutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SaveFileDialog sf = new SaveFileDialog();

         sf.Title = "Save Layout";
         sf.Filter = "XML Layout Files | *.xml";
         if (sf.ShowDialog(this) == DialogResult.OK)
         {
            FileInfo f = new FileInfo(sf.FileName);
            FileStream stream = f.Create();

            try
            {
               Viewer.SaveLayout(stream);
            }
            finally
            {
               if (stream != null)
                  stream.Close();
            }
         }
      }

      private void loadLayoutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OpenFileDialog open = new OpenFileDialog();

         open.Title = "Open Layout File";
         open.Filter = "XML Layout Files | *.xml";
         open.Multiselect = false;
         if (open.ShowDialog(this) == DialogResult.OK)
         {
            FileInfo f = new FileInfo(open.FileName);
            FileStream stream = f.Open(FileMode.Open);

            try
            {
               Viewer.Cells.Clear();
               Viewer.LoadLayout(stream);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            finally
            {
               if (stream != null)
                  stream.Close();
            }
         }
      }

      private void toolToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         selectionToolStripMenuItem.Checked = Viewer.LayoutOptions.DesignTool == MedicalViewerDesignTool.Selection;
         drawToolStripMenuItem.Checked = Viewer.LayoutOptions.DesignTool == MedicalViewerDesignTool.Draw;
      }

      private void selectionToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Viewer.LayoutOptions.DesignTool = MedicalViewerDesignTool.Selection;
      }

      private void drawToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Viewer.LayoutOptions.DesignTool = MedicalViewerDesignTool.Draw;
      }

      private void allowCellsToOverlappToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Viewer.LayoutOptions.AllowOverlappingCells = !Viewer.LayoutOptions.AllowOverlappingCells;
         toolStripButtonOverlap.Checked = Viewer.LayoutOptions.AllowOverlappingCells;
      }

      private void toolStripButtonShowPosition_Click(object sender, EventArgs e)
      {
         _medicalViewer.LayoutOptions.ShowPosition = !_medicalViewer.LayoutOptions.ShowPosition;
         toolStripButtonShowPosition.Checked = _medicalViewer.LayoutOptions.ShowPosition;
      }

      private void ChangeOverlapPriority(object sender, EventArgs e)
      {
         MedicalViewerCell selectedCell = GetSelectedCell();
         OverlapDialog dlgOverlap = new OverlapDialog(_medicalViewer.Cells);

         if (dlgOverlap.ShowDialog(this) == DialogResult.OK)
         {
            int i = 1;

            foreach (ListBoxCellItem item in dlgOverlap.Items)
            {
               item.Cell.OverlapPriority = i;
               i++;
            }
         }

         if (selectedCell != null)
            selectedCell.Selected = true;
      }

      public MedicalViewerCell GetSelectedCell()
      {
         foreach (MedicalViewerCell cell in _medicalViewer.Cells)
         {
            if (cell.Selected)
               return cell;
         }
         return null;
      }

      private void insertImageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RasterImage image = LoadImage();

         if (image != null)
         {
            foreach (MedicalViewerCell cell in _medicalViewer.Cells)
            {
               if (cell.Selected)
                  cell.Image = image;
            }
         }
      }

      private void showLinesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _medicalViewer.LayoutOptions.ShowLines = !_medicalViewer.LayoutOptions.ShowLines;
      }


      public static void ApplyToCells(MedicalViewer viewer, ComboBox cmbApplyToCell, NumericTextBox txtCellIndex, ComboBox cmbApplyToSubCell, NumericTextBox txtSubcellIndex, MedicalViewerActionType actionType, MedicalViewerBaseAction actionProperties)
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

         int index;
         MedicalViewerMultiCell cell = null;

         for (index = from; index < to; index++)
         {
            cell = (MedicalViewerMultiCell)(viewer.Cells[index]);
            if (cell.Selected || cmbApplyToCell.Text != "Selected")
               cell.SetActionProperties(actionType, actionProperties, subCellIndex);
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

         cell.SetActionProperties(actionType, baseAction);
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
            _buttonCursor = new System.Windows.Forms.Cursor(openDialog.FileName);
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

