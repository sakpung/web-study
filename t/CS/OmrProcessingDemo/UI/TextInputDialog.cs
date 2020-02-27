using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmrProcessingDemo
{
   public partial class TextInputDialog : Form
   {
      public string Value { get { return txtValue.Text; } }
      private Func<string, string> IsValid;

      public TextInputDialog(Func<string, string> isValid = null)
      {
         InitializeComponent();
         txtValue.Focus();

         this.IsValid = isValid;
      }

      public TextInputDialog(string text, Func<string, string> isValid = null) : this(isValid)
      {
         txtValue.Text = text;
         txtValue.SelectAll();
      }

      private void TextInputDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (DialogResult == DialogResult.OK)
         {
            if (IsValid != null)
            {
               string message = IsValid(txtValue.Text);

               if (!string.IsNullOrEmpty(message))
               {
                  MessageBox.Show(message);
                  e.Cancel = true;
               }
            }

            else if (string.IsNullOrWhiteSpace(txtValue.Text))
            {
               MessageBox.Show("This field cannot be blank.");
               e.Cancel = true;
            }
         }
      }
   }
}
