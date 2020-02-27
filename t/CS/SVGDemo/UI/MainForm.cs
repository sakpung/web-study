// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Drawing;
using Leadtools.Svg;

namespace SvgDemo
{
   public partial class MainForm : Form
   {
      public MainForm()
      {
         InitializeComponent();

         if (!Support.SetLicense())
            return;

         this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

         Messager.Caption = "LEADTOOLS for .NET C# SVG Demo";
         Text = Messager.Caption;

         this.FormClosing += MainForm_FormClosing;
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if(_viewer != null)
            _viewer.DocumentList = null;
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
            Init();

         base.OnLoad(e);
      }

      private Viewer _viewer;
      private string _name;
      private PrintDocument _printDocument;
      private int _currentPrintPageNumber;
      private CodecsLoadSvgOptions _loadSvgOptions;

      private void Init()
      {
         _viewer = new Viewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.Bisque;
         _viewer.BorderStyle = BorderStyle.Fixed3D;
         Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.MouseMove += new MouseEventHandler(_viewer_MouseMove);
         _viewer.UseDpi = true;
         _selectTextToolStripMenuItem.Checked = true;

         _loadSvgOptions = new CodecsLoadSvgOptions();

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

         InitPan();
         UpdateControls();
         string defaultFile =
#if LT_CLICKONCE
            Path.Combine( Application.StartupPath, @"documents\Leadtools.pdf" );
#else
            Path.Combine(DemosGlobal.ImagesFolder, "Leadtools.pdf");
#endif // #if LT_CLICKONCE

         if (File.Exists(defaultFile))
            LoadDocument(defaultFile, true);
      }

      void _viewer_MouseMove(object sender, MouseEventArgs e)
      {
         var document = _viewer.CurrentDocument;
         if (document != null)
         {
            var imagePos = _viewer.ConvertPoint(Viewer.CoordinateType.Control, Viewer.CoordinateType.Image, new LeadPointD(e.X, e.Y));
            _mousePositionLabel.Text = string.Format("Viewer: {0}, {1} - SVG: {2}, {3}", e.X, e.Y, (int)imagePos.X, (int)imagePos.Y);
         }
         else
         {
            _mousePositionLabel.Text = string.Empty;
         }
      }

      LeadPoint _currentPoint = LeadPoint.Empty;
      private void InitPan()
      {
         _viewer.PanBegin += new MouseEventHandler(_viewer_PanBegin);
         _viewer.Panning += new MouseEventHandler(_viewer_Panning);
         _viewer.PanEnd += new EventHandler(_viewer_PanEnd);
      }

      void _viewer_PanEnd(object sender, EventArgs e)
      {
      }

      void _viewer_Panning(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
            return;

         var dx = e.X - _currentPoint.X;
         var dy = e.Y - _currentPoint.Y;

         if (dx != 0 || dy != 0)
         {
            var transform = LeadMatrix.Identity;

            bool zoom = (Control.ModifierKeys & Keys.Control) == Keys.Control;
            bool rotate = (Control.ModifierKeys & Keys.Alt) == Keys.Alt;

            if (zoom)
            {
               if (dy != 0)
               {
                  var factor = 1.0 - ((dy * 4.0) / _viewer.ClientSize.Height);
                  factor = factor < 0 ? -factor : factor;
                  var center = _currentPoint.ToLeadPointD();

                  if (_transformAtCenterToolStripMenuItem.Checked)
                  {
                     center = new LeadPointD(_viewer.ImageSize.Width / 2, _viewer.ImageSize.Height / 2);
                     center = _viewer.ConvertPoint(Viewer.CoordinateType.Image, Viewer.CoordinateType.Control, center);
                  }

                  transform.ScaleAt(factor, factor, center.X, center.Y);
               }
            }
            else if (rotate)
            {
               if (dx != 0)
               {
                  const double rotateAngle = 5.0;
                  var center = _currentPoint.ToLeadPointD();

                  if (_transformAtCenterToolStripMenuItem.Checked)
                  {
                     center = new LeadPointD(_viewer.ImageSize.Width / 2, _viewer.ImageSize.Height / 2);
                     center = _viewer.ConvertPoint(Viewer.CoordinateType.Image, Viewer.CoordinateType.Control, center);
                  }

                  transform.RotateAt(dx > 0 ? rotateAngle : -rotateAngle, center.X, center.Y);
               }
            }
            else
            {
               if (dx != 0 || dy != 0)
                  transform.Translate(dx, dy);
            }

            transform = LeadMatrix.Multiply(_viewer.Transform, transform);
            if (IsScaleInRange(transform))
               _viewer.Transform = transform;
         }

         _currentPoint = new LeadPoint(e.X, e.Y);
      }

      bool IsScaleInRange(LeadMatrix matrix)
      {
         double scaleX = Math.Sqrt(Math.Pow(matrix.M11, 2) + Math.Pow(matrix.M12, 2));
         double scaleY = Math.Sqrt(Math.Pow(matrix.M21, 2) + Math.Pow(matrix.M22, 2));
         return (scaleX < 50 && scaleY < 50);
      }

      void _viewer_PanBegin(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
            _viewer.Identity();
         else
            _currentPoint = new LeadPoint(e.X, e.Y);
      }

      private void PrepareDocument(SvgDocument document)
      {
         if (!document.IsFlat)
            document.Flat(null);

         if (!document.Bounds.IsValid || document.Bounds.IsTrimmed)
            document.CalculateBounds(false);

         document.BeginRenderOptimize();
      }

      private void LoadDocument(string fileName, bool loadDefault)
      {
         try
         {
            using (RasterCodecs codecs = new RasterCodecs())
            {
               // Set load resolution
               codecs.Options.RasterizeDocument.Load.XResolution = 300;
               codecs.Options.RasterizeDocument.Load.YResolution = 300;

               int firstPage = 1;
               int lastPage = 1;
               List<SvgDocument> documents = new List<SvgDocument>();

               if (!loadDefault)
               {
                  // Check if the file can be loaded as svg
                  bool canLoadSvg = codecs.CanLoadSvg(fileName);
                  using (CodecsImageInfo info = codecs.GetInformation(fileName, true))
                  {
                     if (!canLoadSvg)
                     {
                        // Check if the file type is not PDF
                        if (info.Format != RasterImageFormat.PdfLeadMrc    &&
                           info.Format != RasterImageFormat.RasPdf         &&
                           info.Format != RasterImageFormat.RasPdfCmyk     &&
                           info.Format != RasterImageFormat.RasPdfG31Dim   &&
                           info.Format != RasterImageFormat.RasPdfG32Dim   &&
                           info.Format != RasterImageFormat.RasPdfG4       &&
                           info.Format != RasterImageFormat.RasPdfJbig2    &&
                           info.Format != RasterImageFormat.RasPdfJpeg     &&
                           info.Format != RasterImageFormat.RasPdfJpeg411  &&
                           info.Format != RasterImageFormat.RasPdfJpeg422  &&
                           info.Format != RasterImageFormat.RasPdfJpx      &&
                           info.Format != RasterImageFormat.RasPdfLzw      &&
                           info.Format != RasterImageFormat.RasPdfLzwCmyk)
                        {
                           MessageBox.Show("The selected file can't be loaded as an SVG file", "Invalid File Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           return;
                        }
                     }

                     if (info.TotalPages > 1)
                     {
                        using (ImageFileLoaderPagesDialog dlg = new ImageFileLoaderPagesDialog(info.TotalPages, false))
                        {
                           if (dlg.ShowDialog(this) == DialogResult.Cancel)
                              return;

                           firstPage = dlg.FirstPage;
                           lastPage = dlg.LastPage;
                        }
                     }
                  }
               }

               using (WaitCursor wait = new WaitCursor())
               {
                  for (int page = firstPage; page <= lastPage; page++)
                  {
                     SvgDocument svgDoc = codecs.LoadSvg(fileName, page, _loadSvgOptions) as SvgDocument;
                     documents.Add(svgDoc);
                  }

                  SetDocument(fileName, documents, firstPage);
               }

               UpdateControls();
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(this, string.Format("Error {0}{1}{2}", ex.GetType().FullName, Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void SetDocument(string name, List<SvgDocument> documents, int pageNumber)
      {
         _name = name;
         List<SvgDocumentInformation> docsInfo = new List<SvgDocumentInformation>();
         foreach (SvgDocument doc in documents)
         {
            docsInfo.Add(new SvgDocumentInformation(doc));
            PrepareDocument(doc);
         }

         _viewer.DocumentList = docsInfo;
         _viewer.CurrentPageIndex = (pageNumber <= docsInfo.Count) ? pageNumber - 1 : 0;
         _viewer.TotalPages = docsInfo.Count;
         _viewer.Identity();
         _viewer.Invalidate();

         Invalidate();
      }

      private void _useDpiToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _useDpiToolStripMenuItem.Checked = !_useDpiToolStripMenuItem.Checked;
         _viewer.UseDpi = _useDpiToolStripMenuItem.Checked;
      }

      private void _transformAtCenterToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _transformAtCenterToolStripMenuItem.Checked = !_transformAtCenterToolStripMenuItem.Checked;
      }

      private void _getTextToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var document = _viewer.CurrentDocument;
         if (document != null)
         {
            var documentText = DocumentText.FromSvgDocument(document);
            if (documentText != null)
            {
               documentText.BuildWords();
               _viewer.DocumentList[_viewer.CurrentPageIndex].DocumentText = documentText;
               _viewer.DocumentList[_viewer.CurrentPageIndex].ShowText = _selectTextToolStripMenuItem.Checked;
               _viewer.Invalidate();
               UpdateControls();
            }
         }
      }

      private void _saveTextToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var documentText = _viewer.DocumentList[_viewer.CurrentPageIndex].DocumentText;
         if (documentText == null)
            return;

         using (var dlg = new SaveFileDialog())
         {
            dlg.Filter = string.Format("Text files (*.txt)|*.txt");
            dlg.DefaultExt = "txt";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               var txt = documentText.BuildText();
               File.WriteAllText(dlg.FileName, txt, Encoding.UTF8);
               System.Diagnostics.Process.Start(dlg.FileName);
            }
         }
      }

      private void _selectTextToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _selectTextToolStripMenuItem.Checked = !_selectTextToolStripMenuItem.Checked;
         if (_viewer.DocumentList.Count != 0)
         {
            _viewer.DocumentList[_viewer.CurrentPageIndex].ShowText = _selectTextToolStripMenuItem.Checked;
            _viewer.Invalidate();
         }
      }

      private void _exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (var dlg = new OpenFileDialog())
         {
#if LT_CLICKONCE
            dlg.InitialDirectory = Path.Combine( Application.StartupPath, "documents" );
#endif // #if LT_CLICKONCE
            const string documentFormats = "*.afp;*.doc;*.docx;*.pdf;*.ppt;*.pptx;*.ptk;*.rtf;*.xls;*.xlsx;*.epub;*.mob;*.mobi;*.prc";
            const string vectorFormats = "*.cgm;*.cmx;*.dgn;*.drw;*.dwf;*.dwfx;*.dwg;*.dxf;*.e00;*.gbr;*.mif;*.nap;*.pcl;*.shp;*.svg";
            dlg.Filter = string.Format("All Files(*.*)|*.*|Document Files({0})|{0}|Vector Files({1})|{1}", documentFormats, vectorFormats);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               LoadDocument(dlg.FileName, false);
            }
         }
      }

      private void _aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Svg", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _showDocInfoToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DocumentInfo docInfo = new DocumentInfo(_viewer.CurrentDocument, _name, _viewer.CurrentPageIndex, _viewer.TotalPages);
         docInfo.ShowDialog(this);
      }

      private void _printToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_printDocument != null)
         {
            try
            {
               _printDocument.PrinterSettings.MinimumPage = 1;
               _printDocument.PrinterSettings.MaximumPage = _viewer.DocumentList.Count;
               _printDocument.PrinterSettings.FromPage = 1;
               _printDocument.PrinterSettings.ToPage = _viewer.DocumentList.Count;

               _printDocument.Print();
            }
            catch { }
         }
      }

      private void _printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_printDocument != null)
         {
            try
            {
               using (PrintPreviewDialog dlg = new PrintPreviewDialog())
               {
                  _printDocument.PrinterSettings.MinimumPage = 1;
                  _printDocument.PrinterSettings.MaximumPage = _viewer.DocumentList.Count;
                  _printDocument.PrinterSettings.FromPage = 1;
                  _printDocument.PrinterSettings.ToPage = _viewer.DocumentList.Count;

                  dlg.Document = _printDocument;
                  dlg.WindowState = FormWindowState.Maximized;
                  dlg.ShowDialog(this);
               }
            }
            catch { }
         }
      }

      private void _printDocument_BeginPrint(object sender, PrintEventArgs e)
      {
         // Start from first page in the image
         _currentPrintPageNumber = 1;
      }

      private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
      {
         // Get the print document object
         PrintDocument document = sender as PrintDocument;

         SvgDocument svgDoc = _viewer.DocumentList[_currentPrintPageNumber - 1].Document;
         var svgResolution = svgDoc.Bounds.Resolution;
         var svgBounds = svgDoc.Bounds.Bounds;
         // Get page size in pixels
         var pixelSize = LeadSizeD.Create(svgBounds.Width, svgBounds.Height);

         using (Bitmap bitmap = new Bitmap((int)pixelSize.Width, (int)pixelSize.Height, PixelFormat.Format32bppPArgb))
         {
            // Convert to DPI
            var size = LeadSizeD.Create(pixelSize.Width * bitmap.HorizontalResolution / svgResolution.Width, pixelSize.Height * bitmap.VerticalResolution / svgResolution.Height).ToLeadSize();
            // Fit in the margin bounds
            var destRect = LeadRect.Create(e.MarginBounds.X, e.MarginBounds.Y, e.MarginBounds.Width, e.MarginBounds.Height);
            destRect = RasterImage.CalculatePaintModeRectangle(
               size.Width,
               size.Height,
               destRect,
               RasterPaintSizeMode.Fit,
               RasterPaintAlignMode.Center,
               RasterPaintAlignMode.Center);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
               using (var engine = RenderingEngineFactory.Create(g))
               {
                  var options = new SvgRenderOptions();
                  options.Bounds = svgBounds;
                  svgDoc.Render(engine, options);
               }
            }
            e.Graphics.DrawImage(bitmap, destRect.X, destRect.Y, destRect.Width, destRect.Height);
         }

         // Go to the next page
         _currentPrintPageNumber++;

         // Inform the printer whether we have more pages to print
         if (_currentPrintPageNumber <= document.PrinterSettings.ToPage)
            e.HasMorePages = true;
         else
            e.HasMorePages = false;
      }

      private void _printDocument_EndPrint(object sender, PrintEventArgs e)
      {
         // Nothing to do here
      }

      private void _firstPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewer.CurrentPageIndex = 0;
         UpdateControls();
      }

      private void _lastPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewer.CurrentPageIndex = _viewer.DocumentList.Count - 1;
         UpdateControls();
      }

      private void _previousPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         int newCurrentPageIndex = _viewer.CurrentPageIndex - 1;
         if (newCurrentPageIndex >= 0)
            _viewer.CurrentPageIndex = newCurrentPageIndex;

         UpdateControls();
      }

      private void _nextPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         int newCurrentPageIndex = _viewer.CurrentPageIndex + 1;
         if (newCurrentPageIndex < _viewer.DocumentList.Count)
            _viewer.CurrentPageIndex = newCurrentPageIndex;

         UpdateControls();
      }

      private void UpdateControls()
      {
         bool isDocumentLoaded = _viewer.DocumentList.Count != 0;

         _printToolStripMenuItem.Enabled = isDocumentLoaded;
         _printPreviewToolStripMenuItem.Enabled = isDocumentLoaded;

         _getTextToolStripMenuItem.Enabled = isDocumentLoaded;
         _saveTextToolStripMenuItem.Enabled = isDocumentLoaded && _viewer.DocumentList[_viewer.CurrentPageIndex].DocumentText != null;
         _selectTextToolStripMenuItem.Enabled = isDocumentLoaded && _viewer.DocumentList[_viewer.CurrentPageIndex].DocumentText != null;
         _showDocInfoToolStripMenuItem.Enabled = isDocumentLoaded;

         _firstPageToolStripMenuItem.Enabled = isDocumentLoaded && _viewer.CurrentPageIndex > 0;
         _previousPageToolStripMenuItem.Enabled = isDocumentLoaded && _viewer.CurrentPageIndex > 0;
         _nextPageToolStripMenuItem.Enabled = isDocumentLoaded && (_viewer.CurrentPageIndex + 1) != _viewer.DocumentList.Count;
         _lastPageToolStripMenuItem.Enabled = isDocumentLoaded && (_viewer.CurrentPageIndex + 1) != _viewer.DocumentList.Count;
         _gotoPageToolStripMenuItem.Enabled = isDocumentLoaded && _viewer.TotalPages > 1;

         _useDpiToolStripMenuItem.Checked = _viewer.UseDpi;
         _pagePanel.Visible = isDocumentLoaded;
         if (isDocumentLoaded)
            _fileNameLabel.Text = string.Format("{0} [Page {1}:{2}]", _name, _viewer.CurrentPageIndex + 1, _viewer.TotalPages);
      }

      private void MainForm_Resize(object sender, EventArgs e)
      {
         int x = _gbSvgInfo.Size.Width /2;
         _gbSvgInfo.Location = new Point(this.Size.Width / 2 - x - 13, _gbSvgInfo.Location.Y);
      }

      private void _loadSVGOptionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (var dlg = new PropertiesDialog())
         {
            dlg.Properties = new LoadSvgProperties(_loadSvgOptions);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               dlg.Properties.UpdateCodecsLoadSvgOptions(_loadSvgOptions);
         }
      }

      private void _gotoPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (var selPage = new SelectPage())
         {
            selPage.SelectedPageNumber = _viewer.CurrentPageIndex + 1;
            selPage.TotalPage = _viewer.TotalPages;

            if (selPage.ShowDialog(this) == DialogResult.OK)
            {
               _viewer.CurrentPageIndex = selPage.SelectedPageNumber - 1;
               UpdateControls();
            }
         }
      }
   }
}
