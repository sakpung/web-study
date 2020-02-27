using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OmrProcessingDemo.UI.ResultsPanel
{
   public class DataGridViewDoubleBuffered : DataGridView
   {
      public DataGridViewDoubleBuffered() : base()
      {
         DoubleBuffered = true;
      }

      protected override void OnScroll(ScrollEventArgs e)
      {
         this.Invalidate();
         base.OnScroll(e);
      }
   }
}
