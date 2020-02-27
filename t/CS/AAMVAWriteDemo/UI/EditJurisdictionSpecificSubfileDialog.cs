using Leadtools.Barcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AAMVAWriteDemo
{
   public partial class EditJurisdictionSpecificSubfileDialog : Form
   {

      private readonly char ASCII_A = 'A';
      private readonly char ASCII_Z = 'Z';

      private char _currentChar;

      private EditSubfileDialog.EditMode _mode;
      private int _subfileIndex;
      private MainForm _parent;
      private AAMVAJurisdiction _jurisdiction;
      private MainForm.SubfileSkeleton _subfileSkeleton;

      public EditJurisdictionSpecificSubfileDialog(MainForm parent, AAMVAJurisdiction jurisdiction, MainForm.SubfileSkeleton subfileSkeleton, int subfileIndex, EditSubfileDialog.EditMode mode)
      {
         InitializeComponent();
         this.Text = "Edit Subfile - Jurisdiction Specific";
         _currentChar = ASCII_A;
         _parent = parent;
         _jurisdiction = jurisdiction;
         _subfileSkeleton = subfileSkeleton;
         _subfileIndex = subfileIndex;
         _closeAction = EditSubfileDialog.CloseAction.Cancel;
         _mode = mode;
         _btnSubmit.Enabled = false;
         if (subfileSkeleton.DataElements.Keys.Count > 0)
         {
            RepopulateDataElements();
         }
      }

      private void RepopulateDataElements()
      {
         ICollection<string> keys = _subfileSkeleton.DataElements.Keys;
         string[] keyArray = keys.ToArray<string>();
         Array.Sort(keyArray);
         foreach(string elementID in keyArray)
         {
            InternalAddDataElement(elementID, _subfileSkeleton.DataElements[elementID].Value);
         }
      }

      private void _btnAddDataElement_Click(object sender, EventArgs e)
      {
         InternalAddDataElement(null, null);
      }

      private void InternalAddDataElement(string optionalElementID, string optionalValue)
      {
         if (_currentChar <= ASCII_Z)
         {
            DataElementRowControl row = new DataElementRowControl();
            row.Jurisdiction = _jurisdiction;
            row.ElementID = optionalElementID != null ? optionalElementID : "Z" + _jurisdiction.ToString()[0] + _currentChar.ToString();
            if (optionalValue != null)
               row.TextBox.Text = optionalValue;
            row.Dock = DockStyle.Top;
            row.SubfileType = AAMVASubfileType.JurisdictionSpecific;
            row.ActionButton.Click += ActionButton_Click;
            _panelDataElements.Controls.Add(row);
            _panelDataElements.Controls.SetChildIndex(row, 0);

            _currentChar++;
            if (_currentChar > ASCII_Z)
            {
               _btnAddDataElement.Enabled = false;
            }

            _panelDataElements.ScrollControlIntoView(row);
            _btnSubmit.Enabled = true;
         }
      }

      private void ActionButton_Click(object sender, EventArgs e)
      {
         Button btn = (Button)sender;
         DataElementRowControl deletedRow = (DataElementRowControl)btn.Parent;
         char deletedChar = deletedRow.ElementID[2];

         foreach(Control ctrl in _panelDataElements.Controls)
         {
            if(ctrl is DataElementRowControl)
            {
               DataElementRowControl row = (DataElementRowControl)ctrl;
               char rowChar = row.ElementID[2];

               if(rowChar > deletedChar)
               {
                  row.ElementID = "Z" + _jurisdiction.ToString()[0] + ((char)(rowChar - 1));
               }
            }
         }

         _panelDataElements.Controls.Remove(deletedRow);
         _btnAddDataElement.Enabled = true;
         _currentChar--;
         if(_currentChar == ASCII_A)
            _btnSubmit.Enabled = false;
      }

      private void _btnSubmit_Click(object sender, EventArgs e)
      {
         IDictionary<string, AAMVADataElement> dataElements = new Dictionary<string, AAMVADataElement>();
         //Get values
         foreach (Control ctrl in _panelDataElements.Controls)
         {
            if (ctrl is DataElementRowControl)
            {
               DataElementRowControl row = (DataElementRowControl)ctrl;
               if (row.CheckBox.Checked)
               {
                  AAMVADataElement dataElement = new AAMVADataElement();
                  dataElement.ElementID = row.ElementID;
                  dataElement.Value = row.TextBox.Text;
                  dataElements.Add(dataElement.ElementID, dataElement);
               }
            }
         }
         
         _parent.SubmitEditSubfile(_subfileIndex, dataElements);
         _closeAction = EditSubfileDialog.CloseAction.Submit;
         Close();
      }

      private EditSubfileDialog.CloseAction _closeAction;
      private void _btnCancel_Click(object sender, EventArgs e)
      {
         _closeAction = EditSubfileDialog.CloseAction.Cancel;
         Close();
      }

      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         switch (_closeAction)
         {
            case EditSubfileDialog.CloseAction.Cancel:
               _parent.CancelEditSubfile(_subfileIndex, _mode);
               break;
         }

         base.OnFormClosing(e);
      }
   }
}
