using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OmrProcessingDemo.Operations
{
   class HTMLExporter : BusyOperation
   {
      private DataGridView dgv;
      private string fileName;

      public HTMLExporter(string filename, DataGridView dgv)
      {
         this.fileName = filename;
         this.dgv = dgv;
      }

      protected override void Run()
      {
         int ticker = 0;

         string fName = Path.GetFileName(fileName);
         Progress(0, "Saving to " + fName);

         StringBuilder builder = new StringBuilder();
         float steps = 100f / (dgv.Rows.Count * 1f);

         // build HTML document header
         builder.AppendLine("<!DOCTYPE html>");
         builder.AppendLine("<html>");
         builder.AppendLine("<head>");
         builder.AppendLine("<style>");
         builder.AppendLine("table {");
         builder.AppendLine("border-collapse: collapse;");
         builder.AppendLine("width: 100 %;");
         builder.AppendLine("}");

         builder.AppendLine("th, td {");
         builder.AppendLine("text-align: left;");
         builder.AppendLine("padding: 8px;");
         builder.AppendLine("}");

         builder.AppendLine("tr:nth-child(even) {background-color: #f2f2f2;}");
         builder.AppendLine("</style>");
         builder.AppendLine("</head>");
         builder.AppendLine("<body>");
         builder.AppendLine("<table>");

         // build table headers
         builder.AppendLine("<tr>");
         builder.AppendLine("<td></td>");
         for (int i = 0; i < dgv.ColumnCount; i++)
         {
            string text = dgv.Columns[i].HeaderText;
            builder.AppendFormat("<th>{0}</th>", text);
            builder.AppendLine();
         }
         builder.AppendLine("</tr>");

         for (int i = 0; i < dgv.Rows.Count; i++)
         {
            builder.AppendLine("<tr>");

            string header = dgv.Rows[i].HeaderCell.Value != null ? dgv.Rows[i].HeaderCell.Value.ToString() : "";
            builder.AppendFormat("<td>{0}</td>", header);
            builder.AppendLine();

            for (int j = 0; j < dgv.Rows[i].Cells.Count; j++)
            {
               DataGridViewCell cell = dgv.Rows[i].Cells[j];
               string val = cell.Value != null ? cell.Value.ToString() : " ";

               builder.AppendFormat("<td>{0}</td>", val);
               builder.AppendLine();
            }
            Progress(ticker += (int)steps, "");
            builder.AppendLine("</tr>");
         }

         // build HTML document footer
         builder.AppendLine("</table>");
         builder.AppendLine("</body></html>");

         File.WriteAllText(fileName, builder.ToString());

         base.Run();
      }
   }
}
