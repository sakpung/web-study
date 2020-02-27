using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OmrProcessingDemo.UI.ResultsPanel
{
   public partial class ColorCodeLegend : Form
   {
      public ColorCodeLegend()
      {
         InitializeComponent();
      }

      internal void UpdateLegend(HighlightOptionsDialog highlightOptionsDialog)
      {
         lblAnswers.BackColor = highlightOptionsDialog.ClExpected.BackColor;
         lblCorrect.BackColor = highlightOptionsDialog.ClCorrect.BackColor;
         lblIncorrect.BackColor = highlightOptionsDialog.ClIncorrect.BackColor;
         lblModCorrect.BackColor = highlightOptionsDialog.ClModifiedCorrect.BackColor;
         lblModIncorrect.BackColor = highlightOptionsDialog.ClModifiedIncorrect.BackColor;
         lblReview.BackColor = highlightOptionsDialog.ClReview.BackColor;

         this.Invalidate();
      }

      private void ColorCodeLegend_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (e.CloseReason == CloseReason.ApplicationExitCall)
         {
            return;
         }

         e.Cancel = true;
         Visible = false;
      }
   }
}
