using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Codecs;
using System.IO;
using System.Diagnostics;
using OmrProcessingDemo.Operations;
using OmrProcessingDemo.UI.ViewerControl;
using Leadtools.Forms.Processing.Omr;
using Leadtools.Forms.Processing.Omr.Fields;

using OmrProcessingDemo.UI;
using Leadtools.Forms.Common;
using Leadtools.ImageProcessing;
using System.Runtime.Serialization.Formatters.Binary;
using Leadtools.Controls;
using OmrProcessingDemo.UI.ResultsPanel;
using System.Reflection;
using Leadtools.Demos;

namespace OmrProcessingDemo
{
   public partial class ResultsPanel : UserControl
   {
      private ImageViewer riv;

      private DataGridViewRow _answersRow;

      private const string ROW_STATS_HEADER = "Statistics";
      private int statsRowIndex = -1;

      private DataGridViewColumn gradesCol;

      internal RasterImage templateImage;

      public ITemplateForm CurrentTemplate { get; internal set; }

      private HighlightOptionsDialog highlightOptionsDialog;

      private Workspace workspace;
      public Workspace CurrentWorkspace { get { return workspace; } }
      public EventHandler<CloseRequestArgs> CloseRequested;

      public ResultsPanel()
      {
         InitializeComponent();

         highlightOptionsDialog = new UI.HighlightOptionsDialog();
         highlightOptionsDialog.ColorCodeUpdated += ColorCodeUpdated;

         riv = new ImageViewer();
         riv.Dock = DockStyle.Fill;
         spltResults.Panel2.Controls.Add(riv);

         DataGridViewCell templateCell = new DataGridViewTextBoxCell();
         gradesCol = new DataGridViewColumn(templateCell);
         gradesCol.Name = "Grades";

      }

      private void DgvResults_CellEndEdit(object sender, DataGridViewCellEventArgs e)
      {
      }

      private int FillResults(IRecognitionForm form, bool isAnswer)
      {
         DataGridViewRow row = null;

         if (isAnswer)
         {
            _answersRow = new DataGridViewRow();
            row = _answersRow;
         }
         else
         {
            row = new DataGridViewRow();
         }

         row.HeaderCell.Value = form.Name;

         row.Tag = form;

         int answerRowIdx = 0;

         foreach (Page page in form.Pages)
         {
            for (int i = 0; i < page.Fields.Count; i++)
            {
               Field ff = page.Fields[i];

               DataGridViewCell dgvc = (DataGridViewCell)dgvResults.Columns[i].CellTemplate.Clone();
               dgvc.Tag = ff;

               if (ff is OmrField)
               {
                  OmrField ofr = ff as OmrField;

                  if (ofr.Options.TextFormat == OmrTextFormat.CSV)
                  {
                     for (int j = 0; j < ofr.Fields.Count; j++)
                     {
                        OmrCollection oc = ofr.Fields[j];
                        dgvc = (DataGridViewCell)dgvResults.Columns[j].CellTemplate.Clone();
                        dgvc.Value = oc.Value;
                        dgvc.ValueType = typeof(string);
                        dgvc.Tag = oc;

                        row.Cells.Add(dgvc);
                     }
                  }
                  else
                  {
                     string output = "";

                     OmrFieldResult offr = ofr.Result as OmrFieldResult;

                     if (offr != null)
                     {
                        output = offr.Text;
                     }
                     else
                     {
                        for (int j = 0; j < ofr.Fields.Count; j++)
                        {
                           OmrCollection oc = ofr.Fields[j];
                           output += oc.Value;
                        }
                     }

                     dgvc.Value = output;
                     dgvc.Tag = ofr;

                     answerRowIdx++;

                     row.Cells.Add(dgvc);
                  }

                  continue;
               }
               else if (ff is BarcodeField)
               {
                  BarcodeField bcf = ff as BarcodeField;
                  BarcodeFieldResult bcfr = (BarcodeFieldResult)bcf.Result;

                  if (bcfr == null || bcfr.Status == FieldStatus.Failed || bcfr.BarcodeData.Count < 1)
                  {
                     dgvc.Value = "Failed";
                  }
                  else
                  {
                     Leadtools.Barcode.BarcodeData bcd = bcfr.BarcodeData[0];

                     dgvc.Value = bcd.Value;
                  }
                  answerRowIdx++;
               }
               else if (ff is OcrField)
               {
                  OcrFieldResult ocf = ((OcrField)ff).Result as OcrFieldResult;

                  if (ocf != null)
                  {
                     dgvc.Value = ocf.Text.Replace("\r", "").Replace("\n", "");
                  }
                  else
                  {
                     dgvc.Value = "";
                  }

                  answerRowIdx++;
               }
               else if (ff is ImageField)
               {
                  ImageField imf = (ImageField)ff;
                  ImageFieldResult ifr = (ImageFieldResult)imf.Result;

                  dgvc.Value = "View";
                  answerRowIdx++;
               }

               row.Cells.Add(dgvc);
            }
         }

         dgvResults.Rows.Add(row);

         return row.Index;
      }

      public bool DoOMRProcessing()
      {
         bool isAnswerPresent = CurrentTemplate.Pages.Any(delegate (Page pg)
         {
            return pg.Fields.Any(delegate (Field ff)
            {
               return ff as OmrField != null ? ((OmrField)ff).Options.GradeThisField : false;
            });
         });

         InputPanel ip = new InputPanel(CurrentTemplate.Pages.Count);
         KeyPanel kp = new KeyPanel(isAnswerPresent, CurrentTemplate.Pages.Count);
         ProcessInputDialog pid = new ProcessInputDialog(new WizardStep[] { ip, kp });

         if (pid.ShowDialog() == DialogResult.Cancel)
         {
            return false;
         }

         workspace = new Workspace(ip, kp, CurrentTemplate);
         workspace.Process();

         if (ip.DoSaveWorkspace)
         {
            SaveWorkspace(ip.SelectedFilePath);
         }

         if (workspace.ErrorList.Count > 0)
         {
            string message = "Unable to recognize these files:";
            for (int i = 0; i < workspace.ErrorList.Count; i++)
            {
               message += Environment.NewLine + workspace.ErrorList[i];
            }

            MessageBox.Show(message);
         }


         gradeToolStripMenuItem.Enabled = workspace.AnswersPresent;
         verifyAnswersToolStripMenuItem.Enabled = workspace.AnswersPresent;

         PopulateDefaultDataGridView();

         dgvStats.Rows.Clear();
         dgvStats.Columns.Clear();

         DoGrading();

         return true;
      }

      public void ShowPostProcessingResults()
      {
         if (workspace == null || (workspace.Answers == null && (workspace.Results == null || workspace.Results.Count == 0)))
         {
            return;
         }

         ErrorStatisticsPanel esp = new ErrorStatisticsPanel(workspace.AnswerReviewCounts, workspace.ResultsReviewCounts);
         ProcessInputDialog pid = new ProcessInputDialog(esp, "&Close", false);

         pid.ShowDialog();
         ToggleColorCode();
      }

      private void PopulateDefaultDataGridView()
      {
         if (workspace == null || (workspace.Answers == null && (workspace.Results == null || workspace.Results.Count == 0)))
         {
            return;
         }
         Cursor current = this.ParentForm.Cursor;
         this.ParentForm.Cursor = Cursors.WaitCursor;

         PopulateDataGridView(workspace.Template, workspace.Answers, workspace.Results);
         UpdateGridCellColors();

         saveWorkspaceToolStripMenuItem.Enabled = true;
         saveWorkspaceAsToolStripMenuItem.Enabled = true;
         exportCSVToolStripMenuItem.Enabled = true;
         closeWorkspaceToolStripMenuItem.Enabled = true;

         searchToolStripMenuItem.Enabled = true;
         tssSearch.Enabled = true;
         tssToggleColorLegend.Enabled = true;
         lockToolStripMenuItem.Enabled = true;
         colorsToolStripMenuItem.Enabled = true;

         changeActiveFiltersToolStripMenuItem.Enabled = true;

         swapStatisticsRowsAndColumnsToolStripMenuItem.Enabled = true;

         tssUpdateItems.Enabled = true;

         gradingToolStripMenuItem.Enabled = true;

         this.ParentForm.Cursor = current;
      }

      private void PopulateDataGridView(ITemplateForm otf, IRecognitionForm answers, List<IRecognitionForm> results)
      {
         dgvResults.Rows.Clear();
         dgvResults.Columns.Clear();

         _answersRow = null;

         BuildColumnHeaders(otf);

         statsRowIndex = -1;
         if (answers != null && answers.Pages.Count > 0)
         {
            PopulateAnswers(answers);
         }

         for (int i = 0; i < results.Count; i++)
         {
            IRecognitionForm form = results[i];
            FillResults(form, false);
         }

         SetRowHeaderValues();
      }

      private void PopulateAnswers(IRecognitionForm answers)
      {
         FillResults(answers, true);

         _answersRow.Frozen = true;

         DataGridViewRow statsRow = new DataGridViewRow();
         statsRow.HeaderCell.Value = ROW_STATS_HEADER;

         statsRow.CreateCells(dgvResults);
         statsRow.Frozen = true;

         statsRowIndex = dgvResults.Rows.Add(statsRow);

         dgvResults.Rows.Add(new DataGridViewRow());
      }

      private void BuildColumnHeaders(ITemplateForm otf)
      {
         // build column header structure
         for (int i = 0; i < otf.Pages.Count; i++)
         {
            Page fp = otf.Pages[i];
            // build a column for each field in each page
            for (int j = 0; j < fp.Fields.Count; j++)
            {

               Field ff = fp.Fields[j];

               if (ff is OmrField)
               {
                  OmrField orf = (OmrField)ff;

                  orf = ff as OmrField;

                  OmrFieldResult orfr = orf.Result as OmrFieldResult;

                  // if a collection is CSV, each subfield needs to be its own column
                  if (orf.Options.TextFormat == OmrTextFormat.CSV)
                  {
                     for (int k = 0; k < orf.Fields.Count; k++)
                     {
                        OmrCollection oc = orf.Fields[k];
                        oc.Tag = fp.PageNumber;

                        DataGridViewTextBoxCell dgvcc = new DataGridViewTextBoxCell();

                        DataGridViewColumn dgCol = new DataGridViewColumn(dgvcc);
                        dgCol.Tag = oc;
                        dgCol.Name = orf.Name + " " + oc.Name;
                        dgvResults.Columns.Add(dgCol);
                     }
                  }
                  else // otherwise, the fields can be grouped
                  {
                     DataGridViewTextBoxCell dgvcc = new DataGridViewTextBoxCell();

                     DataGridViewColumn dgCol = new DataGridViewColumn(dgvcc);
                     dgCol.Tag = orf;
                     dgCol.Name = orf.Name;
                     dgvResults.Columns.Add(dgCol);
                  }
               }
               else
               {
                  // custom logic can be done here for other field types
                  // BarcodeField, OcrField, ImageField

                  DataGridViewCell dgvc = new DataGridViewTextBoxCell();

                  DataGridViewColumn dgcol = new DataGridViewColumn(dgvc);
                  dgcol.Tag = ff;
                  dgcol.Name = ff.Name;

                  dgvResults.Columns.Add(dgcol);
               }
            }
         }
      }

      private void DgvResults_CellValueChanged(object sender, DataGridViewCellEventArgs e)
      {
         if (e.RowIndex < 0 || e.ColumnIndex < 0)
         {
            return;
         }

         DataGridViewCell modifiedCell = dgvResults[e.ColumnIndex, e.RowIndex];

         CellValueModified(modifiedCell);
      }

      private void UpdateGridCellColors()
      {
         for (int i = 0; i < dgvResults.Rows.Count; i++)
         {
            DataGridViewRow currentRow = dgvResults.Rows[i];

            // skip empty rows
            if (currentRow.Tag == null)
            {
               continue;
            }

            if (_answersRow != null && _answersRow.Index == currentRow.Index)
            {
               HandleAnswerRow(currentRow);
            }
            else
            {
               HandleStandardRow(currentRow);
            }
         }
      }

      private void HandleAnswerRow(DataGridViewRow currentRow)
      {
         for (int i = 0; i < currentRow.Cells.Count; i++)
         {
            DataGridViewCell cell = currentRow.Cells[i];

            OmrCollection oc = cell.Tag as OmrCollection;
            if (oc == null)
            {
               continue;
            }

            ReviewParameters rp = oc.Tag as ReviewParameters;

            if (rp == null)
            {
               continue;
            }

            bool needsReview = workspace.VerificationParameters.IsAtLeastOneTrueWithoutKey(rp.ErroredParameters);

            cell.Style = needsReview ? highlightOptionsDialog.ClReview : highlightOptionsDialog.ClExpected;
         }
      }

      private void HandleStandardRow(DataGridViewRow currentRow)
      {
         for (int i = 0; i < currentRow.Cells.Count; i++)
         {
            DataGridViewCell cell = currentRow.Cells[i];
            HandleCell(cell);
         }
      }

      private void HandleCell(DataGridViewCell cell)
      {
         bool answersPresent = _answersRow != null;
         string answerVal = _answersRow != null && _answersRow.Cells[cell.ColumnIndex].Value != null ? _answersRow.Cells[cell.ColumnIndex].Value.ToString() : string.Empty;
         bool isCorrect = cell.Value != null ? cell.Value.ToString() == answerVal : false;

         if (cell.Tag is OmrCollection)
         {
            OmrCollection oc = cell.Tag as OmrCollection;
            ReviewParameters rp = oc.Tag as ReviewParameters;
            if (rp == null)
            {
               return;
            }

            if (workspace.VerificationParameters.IsAtLeastOneTrue(rp.ErroredParameters))
            {
               cell.Style = highlightOptionsDialog.ClReview;
            }
            else if (answersPresent && (rp.ReviewRequired == false || rp.ErroredParameters.UseValueChanged))
            {
               cell.Style = isCorrect ? highlightOptionsDialog.ClModifiedCorrect : highlightOptionsDialog.ClModifiedIncorrect;
            }
            else if (answersPresent)
            {
               cell.Style = isCorrect ? highlightOptionsDialog.ClCorrect : highlightOptionsDialog.ClIncorrect;
            }
            else if (rp.ErroredParameters.IsReviewed)
            {
               cell.Style = highlightOptionsDialog.ClModifiedCorrect;
            }
            else
            {
               cell.Style = new DataGridViewCellStyle() { BackColor = Color.White };
            }
         }
         else if (cell.Tag is OcrField && answersPresent)
         {
            //OcrField f = cell.Tag as OcrField;
            //OcrFieldResult ofr = (OcrFieldResult)f.Result;

            //if (ofr != null)
            //{
            //   cell.Style = ofr.Text == answerVal ? highlightOptionsDialog.ClCorrect : highlightOptionsDialog.ClIncorrect;
            //}
         }
         else if (gradesCol != null && cell.ColumnIndex == gradesCol.Index)
         {
         }
      }

      private void CellValueModified(DataGridViewCell modifiedCell)
      {
         if (lockToolStripMenuItem.Checked == false)
         {
            return;
         }

         object ff = modifiedCell.Tag;

         if (ff is OmrCollection)
         {
            OmrCollection sff = ff as OmrCollection;
            string val = modifiedCell.Value != null ? modifiedCell.Value.ToString() : null;

            // if this is true, then it's been modified directly from the grid and not the UI pane, so the value needs validation and assignment
            if (sff.Value != val)
            {
               ReviewParameters param = (ReviewParameters)sff.Tag;
               // if the cell value is valid within the range of allowed selections, keep it and update the owning collection
               if (param.OmrFieldValues.Contains(val))
               {
                  sff.Value = val;
               }
               else
               {
                  // otherwise, revert it to the original collection's value
                  modifiedCell.Value = sff.Value;
               }
            }
         }

         if (_answersRow == null)
         {
            DataGridViewCell cell = modifiedCell;
            OmrCollection oc = cell.Tag as OmrCollection;

            if (oc != null)
            {
               ReviewParameters rp = oc.Tag as ReviewParameters;

               if (rp != null && rp.ReviewRequired == false)
               {
                  cell.Style = highlightOptionsDialog.ClModifiedCorrect;
               }
            }

            return;
         }

         if (modifiedCell.OwningRow == _answersRow)
         {
            for (int i = 0; i < dgvResults.Rows.Count; i++)
            {
               if (i == _answersRow.Index)
               {
                  continue;
               }

               DataGridViewCell cell = dgvResults[modifiedCell.ColumnIndex, i];

               OmrCollection oc = cell.Tag as OmrCollection;
               if (oc != null)
               {
                  ReviewParameters rp = (ReviewParameters)oc.Tag;

                  if (((ReviewParameters)oc.Tag).ReviewRequired == false)
                  {
                     cell.Style = cell.Value.ToString() == modifiedCell.Value.ToString() ? highlightOptionsDialog.ClModifiedCorrect : highlightOptionsDialog.ClModifiedIncorrect;
                  }
                  else
                  {
                     if (workspace.VerificationParameters.IsAtLeastOneTrueWithoutKey(rp.ErroredParameters))
                     {
                        cell.Style = highlightOptionsDialog.ClReview;
                     }
                     else
                     {
                        cell.Style = cell.Value.ToString() == modifiedCell.Value.ToString() ? highlightOptionsDialog.ClCorrect : highlightOptionsDialog.ClIncorrect;
                     }
                  }
               }
            }
         }
         else if (modifiedCell.Tag is OmrCollection)
         {
            if (modifiedCell.Tag is OmrCollection)
            {
               OmrCollection oc = modifiedCell.Tag as OmrCollection;
               ReviewParameters rp = oc.Tag as ReviewParameters;

               if (rp != null)
               {
                  VerificationParameters p = rp.ErroredParameters;
                  p.UseValueChanged = oc.Value != oc.OriginalValue;
                  rp.ErroredParameters = p;

                  if (rp.ReviewRequired == false)
                  {
                     string answerVal = (string)_answersRow.Cells[modifiedCell.ColumnIndex].Value;
                     modifiedCell.Style = (string)modifiedCell.Value == answerVal ? highlightOptionsDialog.ClModifiedCorrect : highlightOptionsDialog.ClModifiedIncorrect;
                  }
               }
            }
         }

         if (modifiedCell.Tag is OmrField)
         {
            OmrField f = modifiedCell.Tag as OmrField;
            if (f.Tag != null && f.Tag is bool)
            {
               if ((bool)f.Tag && modifiedCell.OwningRow.Tag is IRecognitionForm)
               {
                  IRecognitionForm frm = modifiedCell.OwningRow.Tag as IRecognitionForm;

                  int idStart = frm.Name.LastIndexOf('[');
                  int idStop = frm.Name.LastIndexOf(']');

                  if (idStart < idStop)
                  {
                     string name = frm.Name.Remove(idStart);
                     name += "[" + modifiedCell.Value.ToString() + "]";

                     frm.Name = name;
                     modifiedCell.OwningRow.HeaderCell.Value = name;
                  }
               }
            }
         }

         //HandleCell(modifiedCell);
      }

      private void DgvResults_CellLeave(object sender, DataGridViewCellEventArgs e)
      {
         CellValueModified(dgvResults[e.ColumnIndex, e.RowIndex]);
      }

      private void DgvResults_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
      {
         spltResults.Panel2.Controls.Clear();
         if (dgvResults.Rows[e.RowIndex].Tag == null)
         {
            return;
         }

         string guid = ((IRecognitionForm)dgvResults.Rows[e.RowIndex].Tag).Id;

         RasterImage image = workspace.ImageManager.Get(guid);

         ImageViewer iv = new ImageViewer();
         iv.Image = image;
         iv.Dock = DockStyle.Fill;
         iv.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty);

         spltResults.Panel2.Controls.Add(iv);
      }


      private void DgvResults_CellClick(object sender, DataGridViewCellEventArgs e)
      {
         if (lockToolStripMenuItem.Checked == false)
         {
            return;
         }

         if (e.RowIndex < 0 || e.ColumnIndex < 0)
         {
            return;
         }

         DataGridViewCell cell = dgvResults[e.ColumnIndex, e.RowIndex];

         ShowReviewDialog(cell);
      }

      private void ShowReviewDialog(DataGridViewCell cell, bool useWorkspaceParameters = false)
      {

         if (cell == null || cell.OwningRow.Tag == null)
         {
            return;
         }

         object ff = cell.Tag;

         if (ff is OmrCollection || ff is Field)
         {
            lockToolStripMenuItem.Checked = true;
            SingleReviewPanel srp = new SingleReviewPanel(workspace, dgvResults, cell.ColumnIndex, cell.RowIndex, cell.OwningRow == _answersRow, useWorkspaceParameters, _answersRow);
            srp.ShowDialog(this);

            DoGrading();
         }
      }

      private void exportResultsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoExportOperation(dgvResults);
      }

      private void exportStatsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoExportOperation(dgvStats);
      }

      private void DoExportOperation(DataGridView dgv)
      {
         SaveFileDialog sfd = new SaveFileDialog();
         sfd.AddExtension = true;
         sfd.Filter = "CSV Files (*.csv)|*.CSV|HTML Files (*.html)|*.html";
         sfd.FilterIndex = 0;
         sfd.DefaultExt = ".csv";

         if (sfd.ShowDialog() == DialogResult.OK)
         {
            BusyOperation bo;
            if (Path.GetExtension(sfd.FileName) == ".csv")
            {
               bo = new DataExporter(sfd.FileName, dgv);
            }
            else
            {
               bo = new HTMLExporter(sfd.FileName, dgv);
            }

            bo.Start();
         }
      }

      private void changeKeyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         bool isAnswerPresent = CurrentTemplate.Pages.Any(delegate (Page pg)
         {
            return pg.Fields.Any(delegate (Field ff)
            {
               return ff as OmrField != null ? ((OmrField)ff).Options.GradeThisField : false;
            });
         });

         KeyPanel kp = new KeyPanel(isAnswerPresent, CurrentTemplate.Pages.Count);
         ProcessInputDialog pid = new ProcessInputDialog(kp, "Change Key");
         if (pid.ShowDialog(this.ParentForm) == DialogResult.OK)
         {
            workspace.UpdateAnswerKey(kp);

            PopulateDefaultDataGridView();

            DoGrading();
         }
      }

      private void DoGrading()
      {
         GradeOperation grader = workspace.DoGrading();
         grader.Start();

         // populate statistics row
         if (statsRowIndex != -1)
         {
            PopulateStatistics(grader);
         }

         if (workspace.AnswersPresent)
         {
            PopulateGradeColumn(grader);

            if (statsRowIndex != -1)
            {
               dgvResults[gradesCol.Index, statsRowIndex] = new DataGridViewTextBoxCell() { Value = string.Format("{0}%", grader.Statistics.Mean.ToString("F2")) };
            }
         }

         dgvResults.Invalidate();

         // populate lower extended statistics breakdown
         PopulateExtendedStatistics(grader);

         exportStatsToolStripMenuItem.Enabled = true;
      }

      private void PopulateExtendedStatistics(GradeOperation grader)
      {
         Cursor current = this.ParentForm.Cursor;
         this.ParentForm.Cursor = Cursors.WaitCursor;

         string[,] stats = swapStatisticsRowsAndColumnsToolStripMenuItem.Checked ? grader.InvertedStats : grader.StatsArray;

         if (stats == null)
         {
            this.ParentForm.Cursor = current;
            return;
         }

         if (swapStatisticsRowsAndColumnsToolStripMenuItem.Checked)
         {
            dgvStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvStats.ColumnHeadersHeight = 50;
            dgvStats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

            dgvStats.CellPainting -= dgvStats_CellPainting;
         }
         else
         {
            dgvStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvStats.ColumnHeadersHeight = 50;
            dgvStats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;

            dgvStats.CellPainting += dgvStats_CellPainting;
         }

         int length = stats.GetLength(0);
         int width = stats.GetLength(1);
         dgvStats.Rows.Clear();
         dgvStats.Columns.Clear();
         dgvStats.Invalidate();

         for (int i = 0; i < width; i++)
         {
            string val = stats[0, i];
            if (string.IsNullOrEmpty(val) == false)
            {
               DataGridViewTextBoxCell dgvcc = new DataGridViewTextBoxCell();
               DataGridViewColumn dgvc = new DataGridViewColumn(dgvcc);
               dgvc.HeaderText = val;
               dgvStats.Columns.Add(dgvc);
            }
         }

         for (int i = 1; i < length; i++)
         {
            DataGridViewRow row = new DataGridViewRow();
            row.HeaderCell.Value = stats[i, 0];
            for (int j = 1; j < width; j++)
            {
               DataGridViewCell dgvc = new DataGridViewTextBoxCell();
               dgvc.Value = stats[i, j];

               row.Cells.Add(dgvc);
            }

            dgvStats.Rows.Add(row);
         }

         dgvStats.Invalidate();

         this.ParentForm.Cursor = current;
      }

      private void PopulateGradeColumn(GradeOperation grader)
      {
         // insert the grades column
         if ((gradesCol.DataGridView == null || dgvResults.Columns.Contains(gradesCol) == false) && workspace.AnswersPresent)
         {
            gradesCol.Frozen = true;
            dgvResults.Columns.Insert(0, gradesCol);
         }

         // populate the grades column
         for (int i = 0; i < dgvResults.Rows.Count; i++)
         {
            DataGridViewCell cell = new DataGridViewTextBoxCell();

            DataGridViewRow dgvr = dgvResults.Rows[i];

            string currentCell = (string)dgvr.HeaderCell.Value;

            if (currentCell == null)
            {
               continue;
            }

            int startId = currentCell.LastIndexOf("[");
            int stopId = currentCell.LastIndexOf("]");

            if (startId != -1 && stopId != -1)
            {
               currentCell = currentCell.Substring(0, startId);
            }

            IRecognitionForm frm = grader.Results.Find(delegate (IRecognitionForm form) { return form.Name == currentCell; });

            if (string.IsNullOrWhiteSpace(currentCell) == false && frm != null)
            {
               cell.Value = string.Format("{0}%", frm.Grade.ToString("F2"));
               cell.Style = frm.Grade > grader.PassingScore ? highlightOptionsDialog.ClCorrect : highlightOptionsDialog.ClIncorrect;
            }

            dgvr.Cells[gradesCol.Index] = cell;
         }
      }

      private void PopulateStatistics(GradeOperation grader)
      {
         for (int i = 0; i < dgvResults.Columns.Count; i++)
         {
            DataGridViewColumn col = dgvResults.Columns[i];

            DataGridViewCell res = new DataGridViewTextBoxCell();

            if (grader.QuestionAnswers == null)
            {
               continue;
            }

            string prefix = "Page {0} ";
            if (col.Tag is Field)
            {
               Field f = col.Tag as Field;
               prefix = string.Format(prefix, f.PageNumber);
            }
            else if (col.Tag is OmrCollection)
            {
               OmrCollection oc = col.Tag as OmrCollection;
               if (oc.Tag != null)
               {
                  prefix = string.Format(prefix, oc.Tag);
               }
            }

            string key = prefix + col.HeaderCell.Value.ToString();
            if (grader.QuestionAnswers.ContainsKey(key))
            {
               QuestionAnswers qa = grader.QuestionAnswers[key];

               res.Tag = qa;

               if (qa.Answer != null)
               {
                  if (qa.AnswersCount.ContainsKey(qa.Answer))
                  {
                     int correct = qa.AnswersCount[qa.Answer];
                     int total = qa.AnswersCount.Sum(q => q.Value);
                     float value = (float)Math.Round(correct / (total * 1f), 2) * 100;

                     res.Value = string.Format("{0}%", value);
                  }
               }
            }
            dgvResults.Rows[statsRowIndex].Cells[i] = res;
         }
      }

      private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (highlightOptionsDialog.IsDisposed)
         {
            highlightOptionsDialog = new HighlightOptionsDialog();
            highlightOptionsDialog.ColorCodeUpdated += ColorCodeUpdated;
         }

         if (workspace != null)
         {
            highlightOptionsDialog.ManualReviewPanel = new ManualReviewPanel(workspace.VerificationParameters, "Select \"Needs Review\" Highlight Criteria");
            highlightOptionsDialog.ManualReviewPanel.UpdateUI(workspace.AnswersPresent);
         }


         highlightOptionsDialog.ShowDialog(this.ParentForm);
         if (workspace != null)
         {
            workspace.VerificationParameters = highlightOptionsDialog.ManualReviewPanel.VerificationParameters;
         }

         UpdateGridCellColors();
      }

      private void ColorCodeUpdated(object sender, EventArgs e)
      {
         if (workspace != null)
         {
            workspace.VerificationParameters = highlightOptionsDialog.ManualReviewPanel.VerificationParameters;
            UpdateGridCellColors();
         }
      }

      private void saveWorkspaceAsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         string path = "";
         if (MainForm.ChooseWorkspaceFilePath(out path))
         {
            SaveWorkspace(path);
         }
      }

      private void saveWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoSaveWorkspace();
      }

      public bool DoSaveWorkspace()
      {
         if (workspace != null)
         {
            if (string.IsNullOrEmpty(workspace.LocationOnDisk))
            {
               string path = "";
               if (MainForm.ChooseWorkspaceFilePath(out path))
               {
                  SaveWorkspace(path);
               }
               else
               {
                  return false;
               }
            }
            else
            {
               SaveWorkspace(workspace.LocationOnDisk);
            }
         }

         return true;
      }

      private void SaveWorkspace(string path)
      {
         BusyOperation packWorkspace = new SaveWorkspaceOperation(path, workspace);
         packWorkspace.Start();
      }

      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         CloseWorkspace(CloseRequestArgs.ClosingReason.ToLoadExisting);
      }

      public bool OpenWorkspace()
      {
         OpenFileDialog ofd = new OpenFileDialog();
         ofd.Filter = string.Format("Workspace files|*{0}", MainForm.WORKSPACE_EXT);

         ofd.RestoreDirectory = false;
         string path = Path.Combine(DemosGlobal.ImagesFolder, @"\Forms\OMR Processing");
         ofd.InitialDirectory = path;

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            string filename = ofd.FileName;

            LoadWorkspaceOperation lwo = new LoadWorkspaceOperation(filename);
            lwo.Start();

            workspace = lwo.LoadedWorkspace;

            if (workspace != null)
            {
               this.CurrentTemplate = workspace.Template;
               this.templateImage = workspace.TemplateImage;

               PopulateDefaultDataGridView();


               DoGrading();
               return true;
            }
         }

         return false;
      }

      private void verifyAnswersToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ManualReviewPanel mrp = new ManualReviewPanel(VerificationParameters.GetTemplate(VerificationParameters.FilterTemplate.CommonIssues), "Choose what to review manually");
         mrp.UpdateUI(false);

         ProcessInputDialog pid = new ProcessInputDialog(mrp, "Begin Review");
         if (pid.ShowDialog() == DialogResult.OK)
         {
            workspace.VerificationParameters = mrp.VerificationParameters;

            int candidate = 0;
            while (_answersRow.Cells[candidate].Tag == null)
            {
               candidate++;
            }

            ShowReviewDialog(_answersRow.Cells[candidate], true);
         }
      }

      private void tssUpdateItems_Click(object sender, EventArgs e)
      {
         DoGrading();
      }

      private void dgvResults_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
      {
         if (e.RowIndex == -1 && e.ColumnIndex >= 0 && e.Value != null)
         {
            e.PaintBackground(e.ClipBounds, true);
            Rectangle rect = this.dgvResults.GetColumnDisplayRectangle(e.ColumnIndex, true);
            Size titleSize = TextRenderer.MeasureText(e.Value.ToString(), e.CellStyle.Font);
            if (this.dgvResults.ColumnHeadersHeight < titleSize.Width)
            {
               this.dgvResults.ColumnHeadersHeight = titleSize.Width;
            }

            e.Graphics.TranslateTransform(0, titleSize.Width);
            e.Graphics.RotateTransform(-90.0F);

            // This is the key line for bottom alignment - we adjust the PointF based on the 
            // ColumnHeadersHeight minus the current text width. ColumnHeadersHeight is the
            // maximum of all the columns since we paint cells twice - though this fact
            // may not be true in all usages!   
            e.Graphics.DrawString(e.Value.ToString(), this.Font, Brushes.Black, new PointF(rect.Y - (dgvResults.ColumnHeadersHeight - titleSize.Width), rect.X));

            // The old line for comparison
            //e.Graphics.DrawString(e.Value.ToString(), this.Font, Brushes.Black, new PointF(rect.Y, rect.X));


            e.Graphics.RotateTransform(90.0F);
            e.Graphics.TranslateTransform(0, -titleSize.Width);
            e.Handled = true;
         }
      }
      private void dgvStats_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
      {
         if (e.RowIndex == -1 && e.ColumnIndex >= 0 && e.Value != null)
         {
            e.PaintBackground(e.ClipBounds, true);
            Rectangle rect = this.dgvStats.GetColumnDisplayRectangle(e.ColumnIndex, true);
            Size titleSize = TextRenderer.MeasureText(e.Value.ToString(), e.CellStyle.Font);
            if (this.dgvStats.ColumnHeadersHeight < titleSize.Width)
            {
               this.dgvStats.ColumnHeadersHeight = titleSize.Width;
            }

            e.Graphics.TranslateTransform(0, titleSize.Width);
            e.Graphics.RotateTransform(-90.0F);

            // This is the key line for bottom alignment - we adjust the PointF based on the 
            // ColumnHeadersHeight minus the current text width. ColumnHeadersHeight is the
            // maximum of all the columns since we paint cells twice - though this fact
            // may not be true in all usages!   
            e.Graphics.DrawString(e.Value.ToString(), this.Font, Brushes.Black, new PointF(rect.Y - (dgvStats.ColumnHeadersHeight - titleSize.Width), rect.X));

            // The old line for comparison
            //e.Graphics.DrawString(e.Value.ToString(), this.Font, Brushes.Black, new PointF(rect.Y, rect.X));


            e.Graphics.RotateTransform(90.0F);
            e.Graphics.TranslateTransform(0, -titleSize.Width);
            e.Handled = true;
         }
      }

      private void ResultsPanel_Load(object sender, EventArgs e)
      {
         dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
         dgvResults.ColumnHeadersHeight = 50;
         dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;


         dgvResults.CellValueChanged += DgvResults_CellValueChanged;
         dgvResults.CellClick += DgvResults_CellClick;
         dgvResults.CellEndEdit += DgvResults_CellEndEdit;
         dgvResults.CellLeave += DgvResults_CellLeave;
      }

      private void lockToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
      {
         //lockToolStripMenuItem.Text = lockToolStripMenuItem.Checked ? "View Mode" : "Edit Mode";

         lockToolStripMenuItem.Image = !lockToolStripMenuItem.Checked ? Properties.Resources.locked : Properties.Resources.unlocked;

         lockToolStripMenuItem.Invalidate();

         if (lockToolStripMenuItem.Checked)
         {
            ShowReviewDialog(dgvResults.CurrentCell);
         }
      }

      private void searchToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ResultSearchDialog rsd = new ResultSearchDialog(dgvResults);
         rsd.ShowDialog();
      }

      private void processReportToolStripMenuItem_Click(object sender, EventArgs e)
      {
         workspace.ReprocessVerification(workspace.VerificationParameters, workspace.Answers, workspace.Results);

         ErrorStatisticsPanel esp = new ErrorStatisticsPanel(workspace.AnswerReviewCounts, workspace.ResultsReviewCounts);
         ProcessInputDialog pid = new ProcessInputDialog(esp, "&Close", false);

         pid.ShowDialog();
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Leadtools.Demos.Dialogs.AboutDialog ab = new Leadtools.Demos.Dialogs.AboutDialog("OMR Processing", Leadtools.Demos.Dialogs.ProgrammingInterface.CS);
         ab.ShowDialog(this.ParentForm);
      }

      private void changeActiveFiltersToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ManualReviewPanel mrp = new ManualReviewPanel(workspace.VerificationParameters, "Select \"Needs Review\" Highlight Criteria");
         mrp.UpdateUI(workspace.AnswersPresent);

         ProcessInputDialog pid = new ProcessInputDialog(mrp, "Update Criteria");
         if (pid.ShowDialog(this.ParentForm) == DialogResult.OK)
         {
            workspace.VerificationParameters = mrp.VerificationParameters;
            UpdateGridCellColors();
         }
      }

      private void reviewWorksheetsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ManualReviewPanel mrp = new ManualReviewPanel(workspace.VerificationParameters, "Choose what to review manually");
         mrp.UpdateUI(workspace.AnswersPresent);

         ProcessInputDialog pid = new ProcessInputDialog(mrp, "Begin Review");
         if (pid.ShowDialog() == DialogResult.OK)
         {
            workspace.VerificationParameters = mrp.VerificationParameters;

            int rowIndex = 0;
            while (dgvResults.Rows[rowIndex].Tag == null || dgvResults.Rows[rowIndex] == _answersRow)
            {
               rowIndex++;
            }

            int candidate = 0;
            while (dgvResults[candidate, rowIndex].Tag == null)
            {
               candidate++;
            }

            ShowReviewDialog(dgvResults[candidate, rowIndex], true);
         }
      }

      private void showResultPanelToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // panel1 contains dgvResults
         // panel2 contains dgvStats

         bool showres = showResultPanelToolStripMenuItem.Checked;
         spltResults.Panel1Collapsed = !showres;

         showStatisticsPanelToolStripMenuItem.Enabled = showres;
      }

      private void showStatisticsPanelToolStripMenuItem_Click(object sender, EventArgs e)
      {
         bool showres = showStatisticsPanelToolStripMenuItem.Checked;
         spltResults.Panel2Collapsed = !showres;

         showResultPanelToolStripMenuItem.Enabled = showres;
      }

      private void tssToggleColorLegend_Click(object sender, EventArgs e)
      {
         ToggleColorCode();
      }

      private void ToggleColorCode()
      {
         highlightOptionsDialog.ToggleColorCode();
      }

      // clean up anything here prior to changing tabs
      internal void Deactivate()
      {
         highlightOptionsDialog.HideColorCode();
      }

      private void closeWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
      {
         CloseWorkspace(CloseRequestArgs.ClosingReason.RevertToIntro);
      }

      private void CloseWorkspace(CloseRequestArgs.ClosingReason closeReason)
      {
         if (workspace != null)
         {

            bool saveHandled = DoCloseWorkspace();

            if (saveHandled)
            {
               OnCloseRequested(closeReason);
            }
         }
         else
         {

            OnCloseRequested(closeReason);
         }
      }

      public bool DoCloseWorkspace()
      {
         if (workspace == null)
         {
            return true;
         }

         bool saved = false;

         DialogResult dr = MessageBox.Show(this.ParentForm, "Save the currently open workspace?", "Closing", MessageBoxButtons.YesNoCancel);
         if (dr == DialogResult.Yes)
         {
            saved = DoSaveWorkspace();
         }
         else if (dr == DialogResult.No)
         {
            return true;
         }
         else if (dr == DialogResult.Cancel)
         {
            return false;
         }

         return saved;
      }


      private void OnCloseRequested(CloseRequestArgs.ClosingReason closeReason)
      {
         if (CloseRequested != null)
         {
            CloseRequested(this, new CloseRequestArgs(closeReason));
         }
      }

      private void dgv_MouseDown(object sender, MouseEventArgs e)
      {
         DataGridView dgv = sender as DataGridView;
         if (dgv == null)
         {
            return;
         }

         System.Windows.Forms.DataGridView.HitTestInfo hti = dgv.HitTest(e.X, e.Y);
         if (hti.ColumnIndex == -1 && hti.RowIndex >= 0)
         {

            // row header click
            if (dgv.SelectionMode != DataGridViewSelectionMode.RowHeaderSelect)
            {
               dgv.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            }
         }

         else if (hti.RowIndex == -1 && hti.ColumnIndex >= 0)
         {
            // column header click
            if (dgv.SelectionMode != DataGridViewSelectionMode.ColumnHeaderSelect)
            {
               dgv.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            }
         }
      }

      private void swapStatisticsRowsAndColumnsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoGrading();
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         CloseWorkspace(CloseRequestArgs.ClosingReason.ApplicationExiting);
      }

      private void SetRowHeaderValues()
      {
         Field newId = null;
         if (CurrentTemplate.IdentifierFieldId != null && CurrentTemplate.IdentifierFieldId.PageNumber > 0)
         {
            newId = CurrentTemplate.Pages[CurrentTemplate.IdentifierFieldId.PageNumber - 1].Fields.FirstOrDefault(f => f.Name == CurrentTemplate.IdentifierFieldId.FieldName);
         }

         for (int i = 0; i < dgvResults.Rows.Count; i++)
         {
            if (dgvResults.Rows[i].Tag == null)
            {
               continue;
            }

            IRecognitionForm frm = (IRecognitionForm)dgvResults.Rows[i].Tag;

            string suffix = "";
            if (newId != null)
            {
               Field identifier = frm.Pages[newId.PageNumber - 1].Fields.FirstOrDefault(f => f.Name == newId.Name);
               if (identifier is OmrField)
               {
                  OmrField omr = (OmrField)identifier;
                  OmrFieldResult ofr = (OmrFieldResult)omr.Result;

                  suffix = ofr != null ? ofr.Text : "";
               }
               else if (identifier is BarcodeField)
               {
                  BarcodeField bcf = (BarcodeField)identifier;
                  BarcodeFieldResult bcfr = (BarcodeFieldResult)bcf.Result;

                  if (bcfr.BarcodeData.Count > 0)
                  {
                     suffix = bcfr.BarcodeData[0].Value;
                  }
               }
               else if (identifier is OcrField)
               {
                  OcrField ocr = (OcrField)identifier;
                  OcrFieldResult ofr = (OcrFieldResult)ocr.Result;

                  suffix = ofr != null ? ofr.Text : "";
               }

               if (string.IsNullOrEmpty(suffix) == false)
               {
                  suffix = "[" + suffix + "]";
               }
            }

            dgvResults.Rows[i].HeaderCell.Value = frm.Name + suffix;
         }
      }
      private void changeIdentifierToolStripMenuItem_Click(object sender, EventArgs e)
      {
         FormSpecificDialog fsd = new FormSpecificDialog(CurrentTemplate, false);

         if (fsd.ShowDialog(this.ParentForm) == DialogResult.OK)
         {
            SetRowHeaderValues();
         }
      }
   }
}