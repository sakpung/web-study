using System.Windows.Forms;
using OmrProcessingDemo.Operations;
using System.IO;
using System.Text;
using System;

namespace OmrProcessingDemo
{
   internal class DataExporter : BusyOperation
   {
      private DataGridView dgv;
      private string fileName;

      public DataExporter(string fileName, DataGridView dgvResults)
      {
         this.fileName = fileName;
         this.dgv = dgvResults;
      }

      protected override void Run()
      {
         int ticker = 0;

         string fName = Path.GetFileName(fileName);
         Progress(0, "Saving to " + fName);

         StringBuilder builder = new StringBuilder();

         float steps = 100f / (dgv.Rows.Count * 1f);

         builder.Append(", ");
         for (int i = 0; i < dgv.Columns.Count; i++)
         {
            string text = dgv.Columns[i].HeaderText;
            text = text.Replace('\n', ' ');
            if (text.Contains(","))
            {
               text = "\"" + text + "\"";
            }
            builder.Append(text + ", ");
         }
         builder.AppendLine();

         for (int i = 0; i < dgv.Rows.Count; i++)
         {
            builder.Append(dgv.Rows[i].HeaderCell.Value + ", ");
            for (int j = 0; j < dgv.Rows[i].Cells.Count; j++)
            {
               DataGridViewCell cell = dgv.Rows[i].Cells[j];
               string val = cell.Value != null ? cell.Value.ToString() : " ";

               builder.Append(val + ", ");
            }

            Progress(ticker += (int)steps, "");
            builder.AppendLine();
         }

         File.WriteAllText(fileName, builder.ToString());

         base.Run();
      }

   }
}