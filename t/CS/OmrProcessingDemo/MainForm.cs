using System;
using System.Windows.Forms;
using Leadtools;
using System.IO;
using OmrProcessingDemo.ViewerControl;
using Leadtools.Codecs;
using Leadtools.Ocr;
using Leadtools.Forms.Processing.Omr;
using OmrProcessingDemo.UI;
using Leadtools.Demos;
using System.Linq;

namespace OmrProcessingDemo
{
   public partial class MainForm : Form
   {
      private const string templatePath = "Template";

      public const string WORKSPACE_EXT = ".ltw";
      public const string TEMPLATE_EXT = ".ltt";

      ViewerControl.ViewerControl vc;
      ResultsPanel resultsPanel;

      private const int TBI_TEMPLATE = 0;
      private const int TBI_PROCESS = 1;
      private const int TBI_WORKSPACE = 2;

      public static bool PerspectiveDeskewActive = false;
      public static bool UnWarpActive = false;
      private static OmrEngine _omrEngine;
      public static bool AutoEstimateMissingOmr = true;

      enum TemplateState
      {
         NotPresent,
         PresentButNoFieldsDefined,
         Present
      }

      public MainForm()
      {
         InitializeComponent();

         vc = new ViewerControl.ViewerControl();
         vc.Dock = DockStyle.Fill;

         vc.CloseRequested += ViewerControlCloseRequested;

         resultsPanel = new ResultsPanel();
         resultsPanel.Dock = DockStyle.Fill;

         resultsPanel.CloseRequested += ResultsPanelCloseRequested;
      }

      private void ViewerControlCloseRequested(object sender, CloseRequestArgs e)
      {
         vc.Deactivate();
         vc.Dispose();

         vc = new ViewerControl.ViewerControl();
         vc.Dock = DockStyle.Fill;

         vc.CloseRequested += ViewerControlCloseRequested;

         tbcMain.TabPages[TBI_TEMPLATE].Controls.Add(vc);
         vc.BringToFront();
         tbcMain.SelectedIndex = TBI_TEMPLATE;

         switch (e.ClosingState)
         {
            case CloseRequestArgs.ClosingReason.RevertToIntro:
               ShowIntroDialog();
               break;
            case CloseRequestArgs.ClosingReason.ExplicitNew:
               vc.CreateNewTemplate();
               break;
            case CloseRequestArgs.ClosingReason.ToLoadExisting:
               vc.ShowLoadTemplate();
               break;
            case CloseRequestArgs.ClosingReason.ApplicationExiting:
               tbcMain.SelectedIndex = TBI_WORKSPACE;
               if (resultsPanel.DoCloseWorkspace())
               {
                  Application.Exit();
               }
               break;
            default:
               break;
         }
      }

      private void ResultsPanelCloseRequested(object sender, CloseRequestArgs e)
      {
         resultsPanel.Deactivate();
         resultsPanel.Dispose();

         resultsPanel = new ResultsPanel();
         resultsPanel.Dock = DockStyle.Fill;

         resultsPanel.CloseRequested += ResultsPanelCloseRequested;

         tbcMain.TabPages[TBI_WORKSPACE].Controls.Add(resultsPanel);
         resultsPanel.BringToFront();
         tbcMain.SelectedIndex = TBI_WORKSPACE;

         switch (e.ClosingState)
         {
            case CloseRequestArgs.ClosingReason.RevertToIntro:
               ShowIntroDialog();
               break;
            case CloseRequestArgs.ClosingReason.ToLoadExisting:
               resultsPanel.OpenWorkspace();
               break;
            case CloseRequestArgs.ClosingReason.ApplicationExiting:
               tbcMain.SelectedIndex = TBI_TEMPLATE;
               if (vc.DoCloseTemplate())
               {
                  Application.Exit();
               }
               break;
            default:
               break;
         }
      }


      private void Form1_Load(object sender, EventArgs e)
      {
         tbcMain.TabPages[TBI_TEMPLATE].Controls.Add(vc);
         vc.BringToFront();

         tbcMain.TabPages[TBI_WORKSPACE].Controls.Add(resultsPanel);
         resultsPanel.BringToFront();

         tbcMain.SelectedIndexChanged += TbcMain_SelectedIndexChanged;
      }

      private void MainForm_Shown(object sender, EventArgs e)
      {
         if (OmrProcessingDemo.Properties.Settings.Default.ShowInfoDialog)
         {
            InfoDialog info = new InfoDialog();
            info.ShowDialog(this);
         }

         ShowIntroDialog();
      }

      private void ShowIntroDialog()
      {
         IntroDialog id = new IntroDialog(vc.IsAutosavePresent());
         id.ShowDialog(this);

         switch (id.Start)
         {
            case IntroDialog.StartupType.NewTemplate:
               vc.CreateNewTemplate();
               tbcMain.SelectedIndex = TBI_TEMPLATE;
               break;
            case IntroDialog.StartupType.LoadTemplate:
               vc.ShowLoadTemplate();
               tbcMain.SelectedIndex = TBI_TEMPLATE;
               break;
            case IntroDialog.StartupType.LoadBackupTemplate:
               vc.LoadAutosave();
               tbcMain.SelectedIndex = TBI_TEMPLATE;
               break;
            case IntroDialog.StartupType.LoadWorkspace:
               if (UnpackWorkspace())
               {
                  tbcMain.SelectedIndex = TBI_WORKSPACE;
               }
               break;
            default:
               break;
         }
      }

      private bool UnpackWorkspace()
      {
         if (resultsPanel.OpenWorkspace())
         {
            vc.AssignTemplate(resultsPanel.CurrentWorkspace.Template);
            return true;
         }
         return false;
      }

      private void TbcMain_SelectedIndexChanged(object sender, EventArgs e)
      {
         switch (tbcMain.SelectedIndex)
         {
            case TBI_TEMPLATE:
               resultsPanel.Deactivate();
               break;
            case TBI_WORKSPACE:
               vc.Deactivate();
               break;
            case TBI_PROCESS:
               vc.Deactivate();
               resultsPanel.Deactivate();
               break;
            default:
               break;
         }

         if (tbcMain.SelectedIndex == TBI_PROCESS)
         {

            TemplateState ts = DoTransferTemplate();

            switch (ts)
            {
               case TemplateState.NotPresent:
                  MessageBox.Show("A template must first be loaded or constructed.");
                  tbcMain.SelectedIndex = TBI_TEMPLATE;
                  break;
               case TemplateState.PresentButNoFieldsDefined:
                  MessageBox.Show("No fields have been created in the template.");
                  tbcMain.SelectedIndex = TBI_TEMPLATE;
                  break;
               case TemplateState.Present:
                  if (resultsPanel.DoOMRProcessing())
                  {
                     tbcMain.SelectedIndex = TBI_WORKSPACE;

                     resultsPanel.ShowPostProcessingResults();
                  }
                  else if (resultsPanel.CurrentWorkspace != null)
                  {
                     tbcMain.SelectedIndex = TBI_WORKSPACE;
                  }
                  else
                  {
                     tbcMain.SelectedIndex = TBI_TEMPLATE;
                  }
                  break;
               default:
                  break;
            }
         }
      }


      private TemplateState DoTransferTemplate()
      {
         resultsPanel.templateImage = vc.RasterImage;
         resultsPanel.CurrentTemplate = vc.TemplateForm;

         if (resultsPanel.templateImage == null || resultsPanel.CurrentAutoScaleDimensions == null)
         {
            return TemplateState.NotPresent;
         }

         bool fieldsPresent = resultsPanel.CurrentTemplate.Pages.Any(delegate (Page pg)
         {
            return pg.Fields.Count > 0;
         });

         return fieldsPresent ? TemplateState.Present : TemplateState.PresentButNoFieldsDefined;
      }

      public static IOcrEngine GetOcrEngine()
      {
         RasterCodecs codecs = GetRasterCodecs();

         IOcrEngine formsOCREngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, false);
         formsOCREngine.Startup(codecs, null, null, null);

         return formsOCREngine;
      }

      public static RasterCodecs GetRasterCodecs()
      {
         RasterCodecs codecs = new RasterCodecs();
         codecs.Options.Load.Resolution = 300;
         codecs.Options.Load.XResolution = 300;
         codecs.Options.Load.YResolution = 300;
         codecs.Options.RasterizeDocument.Load.Resolution = 300;
         codecs.Options.RasterizeDocument.Load.XResolution = 300;
         codecs.Options.RasterizeDocument.Load.YResolution = 300;


         return codecs;
      }

      public static OmrEngine GetOmrEngine()
      {
         if (_omrEngine == null)
         {
            _omrEngine = new OmrEngine();

            Leadtools.Barcode.BarcodeEngine bce = new Leadtools.Barcode.BarcodeEngine();

            _omrEngine.EnginesObject.BarcodeEngine = bce;
            _omrEngine.EnginesObject.OcrEngine = GetOcrEngine();
         }

         return _omrEngine;
      }

      internal static bool LoadRasterImage(out RasterImage image, out string filename, bool allPages, string initialDir = "")
      {
         image = null;
         filename = "";

         OpenFileDialog ofd = new OpenFileDialog();
         ofd.Filter = "Image Files (*.bmp; *.jpg; *.tif; *.png, *.pdf) | *.BMP; *.JPG; *.TIF; *.PNG; *.PDF";

         ofd.InitialDirectory = initialDir != null ? initialDir : Path.Combine(DemosGlobal.ImagesFolder, @"\Forms\OMR Processing");

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            filename = ofd.FileName;
            image = LoadImage(filename, allPages);
         }

         return image != null;
      }

      internal static RasterImage LoadImage(string fileName, bool allPages)
      {
         RasterImage image = null;

         try
         {
            using (RasterCodecs codecs = GetRasterCodecs())
            {
               codecs.Options.Load.AllPages = allPages;
               image = codecs.Load(fileName);
               image.ChangeViewPerspective(RasterViewPerspective.TopLeft);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
            return null;
         }

         return image;
      }

      internal static bool ChooseTemplate(out string input)
      {
         OpenFileDialog fbd = new OpenFileDialog();
         fbd.Title = "Choose Template File";
         fbd.Filter = string.Format("Template files|*{0}", TEMPLATE_EXT);

         string path = Path.Combine(DemosGlobal.ImagesFolder, @"\Forms\OMR Processing");
         fbd.InitialDirectory = path;

         DialogResult dr = fbd.ShowDialog();
         input = fbd.FileName;

         return dr == DialogResult.OK;
      }

      internal static bool ChooseWorkspaceFilePath(out string input)
      {
         SaveFileDialog sfd = new SaveFileDialog();
         input = null;
         sfd.Filter = string.Format("Workspace files|*{0}", WORKSPACE_EXT);
         sfd.OverwritePrompt = true;
         sfd.RestoreDirectory = true;

         string path = Path.Combine(DemosGlobal.ImagesFolder, @"\Forms\OMR Processing");
         sfd.InitialDirectory = path;

         if (sfd.ShowDialog() == DialogResult.OK)
         {
            input = sfd.FileName;

            return true;
         }

         return false;
      }

      internal static bool GetFromTwain(out string savedPath)
      {
         savedPath = null;

         UI.TwainDialog td = new UI.TwainDialog();

         if (td.ShowDialog() == DialogResult.OK)
         {
            savedPath = td.SavedLocation;
         }

         return savedPath != null;
      }
      
      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         Properties.Settings.Default.Save();
         vc.Cleanup();
      }

   }
}