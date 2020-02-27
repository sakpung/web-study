using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmrProcessingDemo.UI
{
   class ErrorStatisticsPanel : WizardStep
   {
      private System.Windows.Forms.ListView lstResultReport;
      private Workspace.ReviewCounter answerReviewCounts;
      private Workspace.ReviewCounter resultsReviewCounts;
      public ErrorStatisticsPanel(Workspace.ReviewCounter answerReviewCounts, Workspace.ReviewCounter resultsReviewCounts) : base()
      {
         InitializeComponent();

         this.answerReviewCounts = answerReviewCounts;
         this.resultsReviewCounts = resultsReviewCounts;

         PopulateListBox();

         Title = "Report";
      }

      private void PopulateListBox()
      {
         lstResultReport.Columns.Add("Analysis: ");

         if (answerReviewCounts.IsEmpty == false)
         {
            lstResultReport.Columns.Add("Found in Answer Key");
         }
         if (resultsReviewCounts.IsEmpty == false)
         {
            lstResultReport.Columns.Add("Found in Worksheets");
         }

         PopulateValues("Below confidence threshold", answerReviewCounts.BelowThreshold, resultsReviewCounts.BelowThreshold);
         PopulateValues("Not exactly one bubble selected", answerReviewCounts.NotExactlyOneBubble, resultsReviewCounts.NotExactlyOneBubble);

         //if ((answerReviewCounts.IsEmpty && resultsReviewCounts.AgreeWithKey == 0 && resultsReviewCounts.DisagreeWithKey == 0) == false)
         //{
         //   PopulateValues("Same as key (Correct answer)", answerReviewCounts.AgreeWithKey, resultsReviewCounts.AgreeWithKey);
         //   PopulateValues("Different from key (Incorrect answer)", answerReviewCounts.DisagreeWithKey, resultsReviewCounts.DisagreeWithKey);
         //}

         if ((answerReviewCounts.IsEmpty && resultsReviewCounts.AgreeWithKey == 0 && resultsReviewCounts.DisagreeWithKey == 0) == false)
         {
            PopulateValues("Same as key (Correct answer)", "N/A", resultsReviewCounts.AgreeWithKey);
            PopulateValues("Different from key (Incorrect answer)", "N/A", resultsReviewCounts.DisagreeWithKey);
         }

         //PopulateValues("Totals", answerReviewCounts.Total, resultsReviewCounts.Total);
         lstResultReport.Items.Add("");
         PopulateValues("Total Collections", answerReviewCounts.TotalCounts, resultsReviewCounts.TotalCounts);

         lstResultReport.AutoResizeColumns(System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize);
         lstResultReport.AutoResizeColumn(0, System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent);
      }

      private void PopulateValues(string v, int answerCount, int resultCount)
      {
         List<string> items = new List<string>();

         items.Add(v);
         if (answerReviewCounts.IsEmpty == false)
         {
            items.Add(answerCount.ToString());
         }
         if (resultsReviewCounts.IsEmpty == false)
         {
            items.Add(resultCount.ToString());
         }

         System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem(items.ToArray());

         lstResultReport.Items.Add(lvi);
      }

      private void PopulateValues(string v, string answerString, int resultCount)
      {
         List<string> items = new List<string>() { v, answerString, resultCount.ToString() };
         System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem(items.ToArray());
         lstResultReport.Items.Add(lvi);
      }

      private void InitializeComponent()
      {
         this.lstResultReport = new System.Windows.Forms.ListView();
         this.SuspendLayout();
         // 
         // lstResultReport
         // 
         this.lstResultReport.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lstResultReport.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.lstResultReport.Location = new System.Drawing.Point(0, 0);
         this.lstResultReport.MultiSelect = false;
         this.lstResultReport.Name = "lstResultReport";
         this.lstResultReport.Size = new System.Drawing.Size(617, 198);
         this.lstResultReport.TabIndex = 0;
         this.lstResultReport.UseCompatibleStateImageBehavior = false;
         this.lstResultReport.View = System.Windows.Forms.View.Details;
         // 
         // ErrorStatisticsPanel
         // 
         this.Controls.Add(this.lstResultReport);
         this.Name = "ErrorStatisticsPanel";
         this.Size = new System.Drawing.Size(617, 198);
         this.ResumeLayout(false);

      }
   }
}
