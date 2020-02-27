using Leadtools.Forms.Processing.Omr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmrProcessingDemo.Operations
{
   class StatisticsExporter : BusyOperation
   {
      private string filename;

      private string[,] statsArray;

      public StatisticsExporter(string filename, string[,] statsArray)
      {
         this.filename = filename;
         this.statsArray = statsArray;
      }

      protected override void Run()
      {
         string fName = Path.GetFileName(filename);
         Progress(0, "Saving to " + fName);

         int length = statsArray.GetLength(0);
         int width = statsArray.GetLength(1);

         StringBuilder builder = new StringBuilder();

         for (int i = 0; i < length; i++)
         {
            for (int j = 0; j < width; j++)
            {
               builder.Append(statsArray[i, j] + ", ");
            }
            builder.AppendLine();
         }

         File.WriteAllText(filename, builder.ToString());

         base.Run();
      }
   }
}
