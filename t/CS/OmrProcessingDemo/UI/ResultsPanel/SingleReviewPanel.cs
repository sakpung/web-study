using Leadtools;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.WinForms;
using Leadtools.Controls;
using Leadtools.Forms.Processing.Omr.Fields;
using Leadtools.Forms.Processing.Omr;
using Leadtools.ImageProcessing;
using OmrProcessingDemo.UI.ViewerControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmrProcessingDemo.UI.ResultsPanel
{
   public partial class SingleReviewPanel : Form
   {
      AutomationImageViewer masterSheetViewer;
      private AnnAutomationManager annAutomationManager = null;
      private AutomationManagerHelper _annotationsHelper = null;
      private AnnAutomation automation = null;

      private RasterImage masterSheet;
      private Workspace workspace;
      private DataGridView dgv;
      private int columnIndex;
      private int rowIndex;
      private ImageViewer answerViewer;
      private AnnHiliteObject annotationField;

      private SingleFieldPanel sfp;
      private TextResultPanel trp;
      private DataGridViewRow answerRow;
      private const string LBL_FILENAME = "Filename: ";
      private const string LBL_IDENTIFIER = "Identifier: ";
      private const string LBL_ANSWERKEY_PRESENT = "Answer Key";
      private const string LBL_ANSWERKEY_MISSING = "No Answer Key Present";

      private const int INFLATE = 5;
      private int currentPage = 1;
      private int maxPages = 1;

      bool isAnswerKeySelected;

      public SingleReviewPanel(Workspace workspace, DataGridView dgv)
      {
         InitializeComponent();

         answerViewer = new ImageViewer();
         answerViewer.Dock = DockStyle.Fill;
         answerViewer.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty);
         pnlAnswerCrop.Controls.Add(answerViewer);

         masterSheetViewer = new AutomationImageViewer();
         masterSheetViewer.Dock = DockStyle.Fill;
         masterSheetViewer.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty);
         pnlFullSheet.Controls.Add(masterSheetViewer);

         this.workspace = workspace;
         this.dgv = dgv;

         sfp = new SingleFieldPanel();
         trp = new TextResultPanel();

         trp.TextUpdated += CellValueUpdated;

         sfp.Visible = false;
         trp.Visible = false;

         spltInfo.Panel2.Controls.Add(sfp);
         spltInfo.Panel2.Controls.Add(trp);

         lblAnswerKey.Visible = false;

         if (workspace.AnswersPresent == false)
         {
            lblAnswerKey.Visible = true;
            lblAnswerKey.Text = LBL_ANSWERKEY_MISSING;
         }

      }

      public SingleReviewPanel(Workspace workspace, DataGridView dgv, int columnIndex, int rowIndex, bool isAnswers, bool useWorkspaceParameters, DataGridViewRow answerRow) : this(workspace, dgv)
      {
         this.columnIndex = columnIndex;
         this.rowIndex = rowIndex;

         isAnswerKeySelected = isAnswers;

         if (isAnswerKeySelected)
         {
            SetupAnswerKey();
         }
         else
         {
            PopulateFileDropdown();
         }

         PopulateZoneDropdown();


         this.answerRow = answerRow;

         rdbtnAllFields.Checked = !useWorkspaceParameters;
         rdbtnSpecific.Checked = useWorkspaceParameters;
         btnChooseFilters.Enabled = rdbtnSpecific.Checked;

         btnNextWorksheet.Visible = !isAnswerKeySelected;
         btnPreviousWorksheet.Visible = !isAnswerKeySelected;
         cbFiles.Visible = !isAnswerKeySelected;

         btnNextWorksheet.Enabled = (rowIndex < dgv.Rows.Count - 1) && (dgv.Rows[rowIndex + 1].Tag != null);
         btnPreviousWorksheet.Enabled = (rowIndex > 0) && (dgv.Rows[rowIndex - 1].Tag != null);

         maxPages = masterSheet != null ? masterSheet.PageCount : 0;

         btnNextPage.Visible = masterSheet != null && masterSheet.PageCount > 1;
         btnPreviousPage.Visible = masterSheet != null && masterSheet.PageCount > 1;
         lblCurrentPage.Visible = masterSheet != null && masterSheet.PageCount > 1;

         if (useWorkspaceParameters)
         {
            AdvanceToNextZone(1);
         }
         else
         {
            DoZoneSetup();
         }
      }
      private void CellValueUpdated(object sender, EventArgs e)
      {
         //lblIdentifier.Text = LBL_IDENTIFIER + trp.Cell.Value.ToString();
      }

      private void PopulateZoneDropdown()
      {

         for (int i = 0; i < dgv.Columns.Count; i++)
         {
            DataGridViewColumn dgvc = dgv.Columns[i];

            if (dgvc.Tag != null)
            {
               cbZones.Items.Add(dgvc);
            }
         }

         cbZones.DisplayMember = "HeaderText";
         cbZones.SelectedItem = dgv.Columns[columnIndex];
      }


      private void PopulateFileDropdown()
      {
         int startingRowIndex = rowIndex;

         // first, back up to the first row containing a worksheet
         while (startingRowIndex >= 0 && dgv.Rows[startingRowIndex].Tag != null)
         {
            startingRowIndex--;
         }
         startingRowIndex++;

         IRecognitionForm startingForm = dgv.Rows[rowIndex].Tag as IRecognitionForm;

         cbFiles.DisplayMember = "Name";
         // iterate over each worksheet and add to dropdown
         while (dgv.Rows[startingRowIndex].Tag != null)
         {
            IRecognitionForm form = (IRecognitionForm)dgv.Rows[startingRowIndex].Tag;
            cbFiles.Items.Add(form);

            startingRowIndex++;
         }

         cbFiles.SelectedItem = startingForm;
      }

      private void SetupAnswerKey()
      {
         if (rowIndex >= dgv.Rows.Count || dgv.Rows[rowIndex].Tag == null)
         {
            return;
         }

         IRecognitionForm form = (IRecognitionForm)dgv.Rows[rowIndex].Tag;
         string guid = form.Id;

         string fileName = workspace.AnswerKeyPath;
         lblFilename.Text = LBL_FILENAME + Path.GetFileName(fileName);

         if (File.Exists(fileName))
         {
            masterSheet = workspace.ImageManager.Get(guid);
            SetupAnnotations(masterSheet);
         }
         else
         {
            Label lbl = new Label();
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Text = string.Format("The image file for the answer key \n\"{0}\"\n was not found.", fileName);
            spltMain.Panel2.Controls.Add(lbl);

            lbl.AutoSize = false;
            lbl.Dock = DockStyle.Fill;

            lbl.BringToFront();
         }

         Workspace.ReviewCounter rc = Workspace.GetManualReviewCollection(form, workspace.VerificationParameters, workspace.Answers);
      }

      private void DoWorksheetSetup(IRecognitionForm form)
      {
         if (rowIndex >= dgv.Rows.Count || dgv.Rows[rowIndex].Tag == null)
         {
            return;
         }


         string guid = form.Id;
         string fileName = workspace.GetImageFilePath(guid);

         Workspace.ReviewCounter rc = Workspace.GetManualReviewCollection(form, workspace.VerificationParameters, workspace.Answers);

         masterSheet = workspace.ImageManager.Get(guid);

         SetupAnnotations(masterSheet);
      }

      private void DoZoneSetup()
      {
         DoZoneSetup(false);
      }

      private void DoZoneSetup(bool stayOnPage)
      {
         bool isZoneSetup = false;

         if (dgv.Columns.Count == 1 && columnIndex == 0)
         {
            DataGridViewCell cell = dgv[0, rowIndex];
            lblNoFieldSelected.Visible = false;
            isZoneSetup = DoZoneSetup(cell, stayOnPage);
         }
         else if (columnIndex >= 0 && columnIndex < dgv.ColumnCount)
         {
            DataGridViewCell cell = dgv[columnIndex, rowIndex];
            lblNoFieldSelected.Visible = false;
            isZoneSetup = DoZoneSetup(cell, stayOnPage);
         }

         if (isZoneSetup == false || (columnIndex < 0 || columnIndex >= dgv.ColumnCount))
         {
            UpdateNavigationEnables();

            sfp.Visible = false;
            trp.Visible = false;

            answerViewer.Image = null;
            annotationField.IsVisible = false;
            lblNoFieldSelected.Visible = true;
         }
      }

      private bool DoZoneSetup(DataGridViewCell cell, bool stayOnPage)
      {
         bool zoneIsOnCurrentPage = DoPageSetup(cell, stayOnPage);

         UpdateNavigationEnables();

         if (!zoneIsOnCurrentPage)
         {
            return false;
         }

         object ff = cell.Tag;

         if (annotationField != null)
         {
            annotationField.IsVisible = true;
         }

         dgv.CurrentCell = cell;

         string header = cell.OwningColumn.HeaderText;
         this.Text = "Review: " + header;

         LeadRect bounds = LeadRect.Empty;
         LeadRect answerBounds = LeadRect.Empty;
         string color = "Green";
         if (ff is OmrCollection)
         {
            OmrCollection sff = (OmrCollection)ff;

            RasterImage target = GetCroppedImage(masterSheet, sff.Bounds);

            sfp.Visible = true;
            trp.Visible = false;
            sfp.Populate(sff, target, cell);
            bounds = sff.Bounds;
            color = "Green";

            ReviewParameters rp = sff.Tag as ReviewParameters;
            VerificationParameters p = rp.ErroredParameters;
            p.IsReviewed = true;
            p.UseValueChanged = sff.Value != sff.OriginalValue;
            rp.ErroredParameters = p;
         }
         else if (ff is OmrField)
         {
            OmrField omr = (OmrField)ff;
            OmrFieldResult ofr = (OmrFieldResult)omr.Result;

            RasterImage target = GetCroppedImage(masterSheet, omr.Bounds);

            sfp.Visible = false;
            trp.Visible = true;

            trp.Populate(target, cell, ofr.Text);
            bounds = omr.Bounds;
            color = "Green";
         }
         else if (ff is BarcodeField)
         {
            BarcodeField bcf = (BarcodeField)ff;
            BarcodeFieldResult bcfr = (BarcodeFieldResult)bcf.Result;

            RasterImage target = GetCroppedImage(masterSheet, bcf.Bounds);

            sfp.Visible = false;
            trp.Visible = true;

            string value = "";

            if (bcfr != null && bcfr.BarcodeData != null && bcfr.BarcodeData.Count > 0)
            {
               value = bcfr.BarcodeData[0].Value;
            }

            trp.Populate(target, cell, value);
            bounds = bcf.Bounds;
            color = "Blue";
         }
         else if (ff is OcrField)
         {
            OcrField ocf = (OcrField)ff;
            OcrFieldResult ofr = (OcrFieldResult)ocf.Result;
            RasterImage target = GetCroppedImage(masterSheet, ocf.Bounds);

            sfp.Visible = false;
            trp.Visible = true;

            string text = ofr != null ? ofr.Text : "";
            int confidence = ofr != null ? ofr.Confidence : -1;

            trp.Populate(target, cell, text, confidence);
            bounds = ocf.Bounds;
            color = "Red";
         }
         else if (ff is ImageField)
         {
            ImageField imf = (ImageField)ff;
            ImageFieldResult imfr = (ImageFieldResult)imf.Result;

            sfp.Visible = false;
            trp.Visible = true;

            if (imfr == null)
            {
               RasterImage target = GetCroppedImage(masterSheet, imf.Bounds);
               trp.Populate(target, cell, imf.Name);
            }
            else
            {
               trp.Populate(imfr.Image, cell, imf.Name);
            }

            bounds = imf.Bounds;
            color = "Yellow";
         }

         DoAnswerFieldSetup(cell);
         AddHighlight(bounds, color);

         return true;
      }
      
      private void DoAnswerFieldSetup(DataGridViewCell cell)
      {
         if (answerRow != null)
         {
            LeadRect bounds = LeadRect.Empty;

            if (cell.Tag is OmrCollection)
            {
               bounds = ((OmrCollection)answerRow.Cells[cell.ColumnIndex].Tag).Bounds;
            }
            else if (cell.Tag is Field)
            {
               bounds = ((Field)answerRow.Cells[cell.ColumnIndex].Tag).Bounds;
            }

            using (RasterImage page = workspace.ImageManager.GetPage(Workspace.IMGMGR_ANSWERS, currentPage))
            {
               if (page != null)
               {
                  RasterImage answerCrop = GetCroppedImage(page, bounds);
                  answerViewer.Image = answerCrop;
                  answerViewer.Zoom(ControlSizeMode.FitAlways, 1, LeadPoint.Empty);
               }
               else
               {
                  lblAnswerKey.Visible = true;
                  lblAnswerKey.Text = LBL_ANSWERKEY_MISSING;
               }
            }

         }
         else
         {
            answerViewer.Image = null;
         }
      }

      private bool DoPageSetup(DataGridViewCell cell, bool stayOnPage)
      {
         object ff = cell.Tag;

         int newPage = 0;
         if (ff is OmrCollection)
         {
            OmrCollection oc = ff as OmrCollection;
            ReviewParameters rp = (ReviewParameters)oc.Tag;
            newPage = rp.PageNumber;
         }
         else if (ff is Field)
         {
            Field f = ff as Field;
            newPage = f.PageNumber;
         }
         else if (ff == null)
         {
            return false;
         }

         if (masterSheet != null && !stayOnPage)
         {
            AdvanceToNextPage(newPage - currentPage);
         }

         return newPage == currentPage;
      }

      private void AdvanceToNextPage(int v)
      {
         int newPage = currentPage + v;

         if (newPage > 0 &&  newPage <= maxPages)
         {
            currentPage = newPage;
            masterSheet.Page = newPage;
         }

         lblCurrentPage.Text = string.Format("Page {0} of {1}", currentPage, maxPages);
      }

      private void PopulateAnswerArea(LeadRect bounds, string color)
      {
      }

      private string ExtractIdentifier(string identifier)
      {
         int idStart = identifier.LastIndexOf('[');
         int idStop = identifier.LastIndexOf(']');

         if (idStart < idStop)
         {
            idStart += 1;
            idStop = Math.Min(idStop, identifier.Length);
            identifier = identifier.Substring(idStart, idStop - idStart);
         }

         return identifier;
      }

      private void SetupAnnotations(RasterImage image)
      {
         // create and setup the automation manager
         annAutomationManager = new AnnAutomationManager();
         _annotationsHelper = new AutomationManagerHelper(annAutomationManager);
         annAutomationManager.CreateDefaultObjects();
         //Run mode to prevent editing of annotations
         annAutomationManager.UserMode = AnnUserMode.Render;

         masterSheetViewer.Image = image;

         automation = new AnnAutomation(annAutomationManager, masterSheetViewer);
         automation.Active = true;

         automation.Container.Children.Clear();

         annotationField = new AnnHiliteObject();
         annotationField.HiliteColor = "Green";
         automation.Container.Children.Add(annotationField);
      }
      private void AddHighlight(LeadRect highlightBounds, string color)
      {
         if (masterSheet == null)
         {
            return;
         }

         masterSheetViewer.BeginUpdate();

         //Now we can calculate the object bounds correctly
         LeadRectD rect = BoundsToAnnotations(highlightBounds);

         rect.Inflate(INFLATE, INFLATE);

         annotationField.HiliteColor = color;
         annotationField.Rect = rect;

         masterSheetViewer.EndUpdate();
      }

      private LeadRectD BoundsToAnnotations(LeadRect rect)
      {
         // Convert a rectangle from logical (top-left) to annotation object coordinates
         //LeadRectD rc = LeadRectD.Create(rect.Left + System.Convert.ToDouble(rect.Width < 0) * rect.Width, rect.Top + System.Convert.ToDouble(rect.Height < 0) * rect.Height, Math.Abs(rect.Width), Math.Abs(rect.Height));
         LeadRectD rc = rect.ToLeadRectD();
         rc = masterSheetViewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rc);
         rc = automation.Container.Mapper.RectToContainerCoordinates(rc);
         return rc;
      }

      private static RasterImage GetCroppedImage(RasterImage input, LeadRect boundaries)
      {
         boundaries.Inflate(INFLATE, INFLATE);

         RasterImage target = null;
         try
         {
            target = input.Clone();

            CropCommand cc = new CropCommand();
            cc.Rectangle = boundaries;
            cc.Run(target);
         }
         catch (Exception)
         {
            return null;
         }
         return target;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void btnPreviousWorksheet_Click(object sender, EventArgs e)
      {
         cbFiles.SelectedIndex--;
         //AdvanceToNextWorkSheet(-1, columnIndex);
      }

      private void btnNextWorksheet_Click(object sender, EventArgs e)
      {
         if (cbFiles.SelectedIndex + 1 == cbFiles.Items.Count)
         {
            return;
         }
         cbFiles.SelectedIndex++;
         //AdvanceToNextWorkSheet(1, columnIndex);
      }

      private bool AdvanceToNextWorkSheet(int v, int newColumnIndex)
      {
         int tempRowIndex = rowIndex;

         tempRowIndex += v;
         while (tempRowIndex >= 0 && tempRowIndex < dgv.Rows.Count)
         {
            if (dgv.Rows[tempRowIndex].Tag != null)
            {
               rowIndex = tempRowIndex;

               columnIndex = newColumnIndex;

               cbFiles.SelectedIndex += v;
               //DoWorksheetSetup(dgv.Rows[tempRowIndex].Tag as IRecognitionForm);
               //DoZoneSetup();

               return true;
            }
            else
               break;

            //tempRowIndex += v;
         }

         //string message = string.Format("This is the {0} worksheet.", v == -1 ? "first" : "last");
         return false;
      }

      private void btnNextZone_Click(object sender, EventArgs e)
      {
         AdvanceToNextZone(1);
      }

      private void btnPreviousZone_Click(object sender, EventArgs e)
      {
         AdvanceToNextZone(-1);
      }

      private void AdvanceToNextZone(int dir)
      {
         int tempColumnIndex = columnIndex;
         tempColumnIndex += dir;

         int min = dgv.Columns[0].Tag == null ? 1 : 0;
         int max = dgv.Columns.Count;// + (dgv.Columns[0].Tag == null ? 0 : 1);

         bool found = true;
         while (found)
         {
            while (tempColumnIndex >= min && tempColumnIndex < max)
            {

               DataGridViewCell cell = dgv[tempColumnIndex, rowIndex];
               if (rdbtnAllFields.Checked && ((cell.Tag is Field && !chkSkipNonOMR.Checked) || (cell.Tag is Field == false)))
               {
                  columnIndex = tempColumnIndex;
                  cbZones.SelectedItem = dgv.Columns[columnIndex];
                  return;
               }

               if (cell.Tag is OmrCollection)
               {
                  OmrCollection oc = (OmrCollection)cell.Tag;
                  ReviewParameters rp = (ReviewParameters)oc.Tag;

                  VerificationParameters errorParams = rp.ErroredParameters;

                  if (workspace.VerificationParameters.IsAtLeastOneTrue(errorParams))
                  {
                     columnIndex = tempColumnIndex;
                     cbZones.SelectedItem = dgv.Columns[columnIndex];
                     return;
                  }
               }
               else if (cell.Tag != null && chkSkipNonOMR.Checked == false)
               {
                  columnIndex = tempColumnIndex;
                  cbZones.SelectedItem = dgv.Columns[columnIndex];
                  return;
               }

               tempColumnIndex += dir;
            }

            tempColumnIndex = dir == 1 ? min : max - 1;
            found = AdvanceToNextWorkSheet(dir, tempColumnIndex);
         }

         MessageBox.Show("No other matches found for the specified criteria.");
      }

      private void UpdateNavigationEnables()
      {

         btnPreviousPage.Enabled = masterSheet != null &&  masterSheet.Page > 1;
         btnNextPage.Enabled = masterSheet != null && masterSheet.Page < masterSheet.PageCount;

         btnNextWorksheet.Enabled = (rowIndex < dgv.Rows.Count - 1) && (dgv.Rows[rowIndex + 1].Tag != null);
         btnPreviousWorksheet.Enabled = (rowIndex > 0) && (dgv.Rows[rowIndex - 1].Tag != null);

         //btnNextZone.Enabled = columnIndex < dgv.Columns.Count;// && btnNextWorksheet.Enabled;
         //btnPreviousZone.Enabled = columnIndex > 0;// && btnPreviousWorksheet.Enabled;
      }

      private void rdbtnAllFields_CheckedChanged(object sender, EventArgs e)
      {
         btnChooseFilters.Enabled = rdbtnSpecific.Checked;
      }

      private void btnChooseFilters_Click(object sender, EventArgs e)
      {
         ManualReviewPanel mrp = new ManualReviewPanel(workspace.VerificationParameters, "Choose what to review manually");
         if (isAnswerKeySelected)
         {
            mrp.UpdateUI(false);
         }
         else
         {
            mrp.UpdateUI(workspace.AnswersPresent);
         }

         ProcessInputDialog pid = new ProcessInputDialog(mrp, "Update Criteria");

         if (pid.ShowDialog() == DialogResult.OK)
         {
            workspace.VerificationParameters = mrp.VerificationParameters;
         }
      }

      private void btnPreviousPage_Click(object sender, EventArgs e)
      {
         AdvanceToNextPage(-1);

         if (dgv.ColumnCount == 1)
         {
            columnIndex = 0;
         }
         else
         {
            if (columnIndex >= dgv.ColumnCount)
            {
               columnIndex = dgv.ColumnCount - 1;
            }

            while (columnIndex >= 0 && columnIndex < dgv.ColumnCount)
            {
               DataGridViewCell cell = dgv[columnIndex, rowIndex];
               if (cell.Tag is OmrCollection)
               {
                  if (((ReviewParameters)((OmrCollection)cell.Tag).Tag).PageNumber == currentPage)
                  {
                     break;
                  }
               }
               else if (cell.Tag is Field)
               {
                  if (((Field)cell.Tag).PageNumber == currentPage)
                  {
                     break;
                  }
               }
               columnIndex--;
            }
         }
         DoZoneSetup(true);
      }

      private void btnNextPage_Click(object sender, EventArgs e)
      {
         AdvanceToNextPage(1);

         columnIndex = columnIndex == -1 ? 0 : columnIndex;

         if (dgv.ColumnCount == 1)
         {
            columnIndex = 0;
         }
         else
         {
            while (columnIndex < dgv.ColumnCount)
            {
               DataGridViewCell cell = dgv[columnIndex, rowIndex];
               if (cell.Tag is OmrCollection)
               {
                  if (((ReviewParameters)((OmrCollection)cell.Tag).Tag).PageNumber == currentPage)
                  {
                     break;
                  }
               }
               else if (cell.Tag is Field)
               {
                  if (((Field)cell.Tag).PageNumber == currentPage)
                  {
                     break;
                  }
               }
               columnIndex++;
            }
         }
         DoZoneSetup(true);
      }

      private void cbFiles_SelectedIndexChanged(object sender, EventArgs e)
      {
         IRecognitionForm selectedForm = (IRecognitionForm)cbFiles.SelectedItem;

         if (selectedForm == null)
         {
            return;
         }

         for (int i = 0; i < dgv.Rows.Count; i++)
         {
            if (dgv.Rows[i].HeaderCell.Value != null && dgv.Rows[i].HeaderCell.Value.ToString() == selectedForm.Name)
            {
               rowIndex = i;
               break;
            }
         }

         DoWorksheetSetup(selectedForm);
         DoZoneSetup();
         UpdateNavigationEnables();
      }

      private void cbZones_SelectedIndexChanged(object sender, EventArgs e)
      {
         DataGridViewColumn dgvc = (DataGridViewColumn)cbZones.SelectedItem;

         if (dgvc != null)
         {
            columnIndex = dgvc.Index;

            DoZoneSetup();
         }
      }
   }
}
