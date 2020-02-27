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

namespace OmrProcessingDemo.UI.ViewerControl
{
   public partial class OmrCollectionDialog : Form
   {
      private OmrCollection f;

      public OmrCollectionDialog(OmrCollection f, bool isGraded)
      {
         InitializeComponent();

         this.f = f;

         txtName.Text = f.Name;
         txtNote.Text = f.Note;

         _numCorrect.Value = (decimal)f.CorrectGrade;
         _numIncorrect.Value = (decimal)f.IncorrectGrade;
         _numNoResponse.Value = (decimal)f.NoResponseGrade;

         grpGradingOptions.Enabled = isGraded;
      }

      private void OmrCollectionDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (DialogResult == DialogResult.OK)
         {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
               MessageBox.Show("The field name cannot be blank.");
               e.Cancel = true;
               return;
            }

            f.Name = txtName.Text;
            f.Note = txtNote.Text;
            f.CorrectGrade = Convert.ToDouble(_numCorrect.Value);
            f.IncorrectGrade = Convert.ToDouble(_numIncorrect.Value);
            f.NoResponseGrade = Convert.ToDouble(_numNoResponse.Value);

         }
      }
   }
}
