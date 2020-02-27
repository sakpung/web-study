using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmrProcessingDemo.UI.ResultsPanel
{
   public partial class ResultSearchDialog : Form
   {
      DataGridView dgv;

      public ResultSearchDialog(DataGridView dgv)
      {
         InitializeComponent();

         this.dgv = dgv;

         txtSearch.Focus();
      }

      private void btnFindNext_Click(object sender, EventArgs e)
      {
         int currentRow = Math.Max(0, dgv.CurrentCell.RowIndex);
         int currentcol = Math.Max(0, dgv.CurrentCell.ColumnIndex);

         int direction = rdbtnForward.Checked ? 1 : -1;

         if (rdbtnSearchbyRows.Checked)
         {
            while (DoRowSearch(currentRow, currentcol, dgv.ColumnCount) == false)
            {
               if ((currentRow == 0 && direction == -1) || (direction == 1 && currentRow == dgv.RowCount - 1))
               {
                  MessageBox.Show("No other matches found.");
                  return;
               }

               currentRow += direction;
               currentcol = direction == 1 ? -1 : dgv.ColumnCount;
            }
         }

         if (rdbtnSearchbyCols.Checked)
         {
            while (DoColumnSearch(currentRow, currentcol, dgv.RowCount) == false)
            {
               if ((currentcol == 0 && direction == -1) || (direction == 1 && currentcol == dgv.ColumnCount - 1))
               {
                  MessageBox.Show("No results found");
                  return;
               }

               string prompt = string.Format("No results found.  Continue searching in {0} {1}?", rdbtnForward.Checked ? "next" : "previous", rdbtnSearchbyRows.Checked ? "row" : "column");

               if (MessageBox.Show(prompt, "Continue?", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                  currentcol += direction;
                  currentRow = direction == 1 ? -1 : dgv.RowCount;
               }
               else
               {
                  break;
               }
            }
         }
      }

      /// <summary>
      /// Search the selected row starting at the selected column for matching text
      /// </summary>
      /// <returns>True if found, false otherwise</returns>
      private bool DoRowSearch(int x, int y, int stop)
      {
         int direction = rdbtnForward.Checked ? 1 : -1;

         y += direction;
         while (y >= 0 && y < stop)
         {
            DataGridViewCell cell = dgv[y, x];

            if (IsMatch(cell.Value))
            {
               dgv.CurrentCell = cell;
               return true;
            }

            y += direction;
         }

         return false;
      }

      private bool IsMatch(object value)
      {
         if (value != null && value is string)
         {
            string toMatch = chkMatchCase.Checked ? txtSearch.Text : txtSearch.Text.ToLowerInvariant();
            string matchValue = chkMatchCase.Checked ? value.ToString() : value.ToString().ToLowerInvariant();

            return toMatch == matchValue;
         }

         return false;
      }

      private bool DoColumnSearch(int x, int y, int stop)
      {
         int direction = rdbtnForward.Checked ? 1 : -1;

         x += direction;
         while (x >= 0 && x < stop)
         {
            DataGridViewCell cell = dgv[y, x];
            if (IsMatch(cell.Value))
            {
               dgv.CurrentCell = cell;
               return true;
            }

            x += direction;
         }

         return false;
      }

      private void rdbtnSearchby_CheckedChanged(object sender, EventArgs e)
      {
         rdbtnForward.Text = rdbtnSearchbyRows.Checked ? "&Forward" : "&Down";
         rdbtnBackward.Text = rdbtnSearchbyRows.Checked ? "&Backward" : "&Up";
      }
   }
}
