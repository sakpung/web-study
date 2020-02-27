using Leadtools.Forms.Processing.Omr.Fields;
using Leadtools.Forms.Processing.Omr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmrProcessingDemo.UI.ViewerControl
{
   public partial class FormSpecificDialog : Form
   {
      public string FormName { get { return txtValue.Text; } }

      private ITemplateForm currentForm;

      public FormSpecificDialog(ITemplateForm form, bool nameEditable = false)
      {
         InitializeComponent();

         this.currentForm = form;

         txtValue.Enabled = nameEditable;
         txtValue.Text = form.Name;

         chkChooseIdentifier.DisplayMember = "Name";
         chkChooseIdentifier.SelectionMode = SelectionMode.One;

         List<Field> fields = new List<Field>();
         for (int i = 0; i < form.Pages.Count; i++)
         {
            Page page = form.Pages[i];
            fields.AddRange(page.Fields.Where<Field>(f =>
               // include anything that's not an image field
               (f is ImageField) == false

               // but exclude CSV OmrFields
               && ((f is OmrField) && ((OmrField)f).Options.TextFormat == OmrTextFormat.Aggregated)
               )
            );
         }

         for (int i = 0; i < fields.Count; i++)
         {
            bool isChecked = form.IdentifierFieldId != null && fields[i].PageNumber == form.IdentifierFieldId.PageNumber && fields[i].Name == form.IdentifierFieldId.FieldName;
            chkChooseIdentifier.Items.Add(fields[i], isChecked);
         }
      }

      private void FormSpecificDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (DialogResult == DialogResult.OK)
         {
            if (string.IsNullOrWhiteSpace(txtValue.Text))
            {
               MessageBox.Show("This field cannot be blank.");
               txtValue.Focus();
               e.Cancel = true;

               return;
            }

            currentForm.Name = txtValue.Text;

            CheckedListBox.CheckedIndexCollection selectedItems = chkChooseIdentifier.CheckedIndices;

            if (selectedItems.Count > 0)
            {
               Field field = (Field)chkChooseIdentifier.Items[selectedItems[0]];
               currentForm.IdentifierFieldId = new FieldId(field.PageNumber, field.Name);
            }
            else
            {
               currentForm.IdentifierFieldId = new FieldId(-1, "");
            }
         }
      }

      // if a user checks more than one item, uncheck the previous one
      private void chkChooseIdentifier_ItemCheck(object sender, ItemCheckEventArgs e)
      {
         if (e.NewValue != CheckState.Checked)
         {
            return;
         }

         CheckedListBox.CheckedIndexCollection selectedItems = chkChooseIdentifier.CheckedIndices;

         if (selectedItems.Count > 0)
         {
            chkChooseIdentifier.SetItemChecked(selectedItems[0], false);
         }
      }
   }
}
