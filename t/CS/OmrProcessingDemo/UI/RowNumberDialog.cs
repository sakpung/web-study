using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools.Forms.Processing.Omr.Fields;

namespace OmrProcessingDemo.UI
{
   public partial class RowNumberDialog : Form
   {

      public string Template { get { return txtValue.Text; } }
      public int StartingValue { get { return (int)nudStart.Value; } }

      public RowNumberDialog(OmrField omrField)
      {
         InitializeComponent();

         txtValue.Text = GetFriendlyFieldTemplate(omrField.Options.FieldOrientation);

         txtValue.Focus();
         txtValue.SelectAll();
      }

      public static string GetFriendlyFieldTemplate(OmrFieldOrientation orientation)
      {
         switch (orientation)
         {
            case OmrFieldOrientation.RowWise:
               return "Row %";
            case OmrFieldOrientation.ColumnWise:
               return "Column %";
            case OmrFieldOrientation.FreeFlow:
               return "Area %";
            default:
               return "";
         }
      }

      private void txtValue_Enter(object sender, EventArgs e)
      {
         TextBox tb = (TextBox)sender;

         ToolTip tt = new ToolTip();
         tt.Show("Use '%' as placeholder for number", this, tb.Left, tb.Top, 5000);
      }

      private void RowNumberDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (string.IsNullOrWhiteSpace(txtValue.Text))
         {
            MessageBox.Show("This field cannot be blank.");
            txtValue.Focus();

            e.Cancel = true;
         }
         else if (txtValue.Text.IndexOf('%') < 0)
         {
            MessageBox.Show("The '%' placeholder must be present.");
            txtValue.Focus();
            e.Cancel = true;
         }
      }
   }
}
