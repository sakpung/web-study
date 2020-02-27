
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
   public partial class OcrFieldDialog : Form
   {
      private OcrField tff;
      //private TextFieldType selectedTFT;
      public OcrFieldDialog(OcrField ff)
      {
         InitializeComponent();

         tff = ff;

         //rdbtnCharacter.Tag = TextFieldType.Character;
         //rdbtnData.Tag = TextFieldType.Data;
         //rdbtnNumerical.Tag = TextFieldType.Numerical;

         //chkEnableOCR.Checked = tff.EnableOcr;

         //txtName.Text = tff.Name;
         //selectedTFT = tff.Type;

         //switch (tff.Type)
         //{
         //   case TextFieldType.Character:
         //      rdbtnCharacter.Checked = true;
         //      break;
         //   case TextFieldType.Numerical:
         //      rdbtnNumerical.Checked = true;
         //      break;
         //   case TextFieldType.Data:
         //      rdbtnData.Checked = true;
         //      break;
         //   default:
         //      break;
         //}

         txtName.Focus();
         txtName.SelectAll();
      }

      private void rdBtnTextType_CheckChanged(object sender, EventArgs e)
      {
         //selectedTFT = (TextFieldType)((RadioButton)sender).Tag;
      }

      private void chkEnableOCR_CheckedChanged(object sender, EventArgs e)
      {
         //tff.EnableOcr = ((CheckBox)sender).Checked;
      }

      private void OcrFieldDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (DialogResult == DialogResult.OK)
         {
            if (string.IsNullOrEmpty(txtName.Text))
            {
               MessageBox.Show("Name cannot be empty");
               e.Cancel = true;

               return;
            }

            tff.Name = txtName.Text;
            //tff.EnableOcr = chkEnableOCR.Checked;
            //tff.Type = selectedTFT;
         }
      }
   }
}
