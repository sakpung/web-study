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
   public partial class AddSubfileDialog : Form
   {
      private AAMVAJurisdiction _jurisdiction;
      private MainForm _parent;
      public AddSubfileDialog(MainForm parent, AAMVAJurisdiction jurisdiction)
      {
         InitializeComponent();
         _jurisdiction = jurisdiction;
         _parent = parent;
         InitControls();
      }

      private void InitControls()
      {
         MainForm.JurisdictionDatum[] jurisdictionDummyList = { new MainForm.JurisdictionDatum(MainForm.JurisdictionToFriendlyString(_jurisdiction, true), _jurisdiction) };
         _comboBoxJurisdiction.DataSource = jurisdictionDummyList;
         _comboBoxJurisdiction.DisplayMember = "Name";
         _comboBoxJurisdiction.ValueMember = "Value";

         MainForm.SubfileTypeDatum[] subfileTypeList =
         {
            new MainForm.SubfileTypeDatum("Driver's License", AAMVASubfileType.DL),
            new MainForm.SubfileTypeDatum("ID", AAMVASubfileType.ID),
            new MainForm.SubfileTypeDatum("Jurisdiction-Specific", AAMVASubfileType.JurisdictionSpecific)
         };
         _comboBoxSubfileType.DataSource = subfileTypeList;
         _comboBoxSubfileType.DisplayMember = "Name";
         _comboBoxSubfileType.ValueMember = "Value";
         _comboBoxSubfileType.SelectedValueChanged += _comboBoxSubfileType_SelectedValueChanged;

         _textBoxCode.Text = "DL";
         _textBoxCode.ReadOnly = true;
         _textBoxCode.BackColor = SystemColors.Control;
         _textBoxCode.Leave += _textBoxCode_Leave;
         _textBoxCode.KeyPress += _textBoxCode_KeyPress;

         _checkBoxAuto.Visible = false;
         _checkBoxAuto.CheckedChanged += _checkBoxAuto_CheckedChanged;
         _checkBoxAuto.Checked = true;
      }

      private void _checkBoxAuto_CheckedChanged(object sender, EventArgs e)
      {
         _textBoxCode.ReadOnly = _checkBoxAuto.Checked;
         _textBoxCode.BackColor = _checkBoxAuto.Checked ? SystemColors.Control : Color.White;
      }

      private void _comboBoxSubfileType_SelectedValueChanged(object sender, EventArgs e)
      {
         AAMVASubfileType subfileType = (AAMVASubfileType)_comboBoxSubfileType.SelectedValue;

         switch(subfileType)
         {
            case AAMVASubfileType.DL:
               _textBoxCode.Text = "DL";
               _textBoxCode.ReadOnly = true;
               _textBoxCode.BackColor = SystemColors.Control;
               _checkBoxAuto.Visible = false;
               break;
            case AAMVASubfileType.ID:
               _textBoxCode.Text = "ID";
               _textBoxCode.ReadOnly = true;
               _textBoxCode.BackColor = SystemColors.Control;
               _checkBoxAuto.Visible = false;
               break;
            case AAMVASubfileType.JurisdictionSpecific:
               string abbr = AAMVAID.LookupStateAbbreviation(_jurisdiction);
               if(abbr != null)
               {
                  _textBoxCode.Text = "Z" + abbr[0];
               }
               else
               {
                  _textBoxCode.Text = "ZX";
               }
               
               _checkBoxAuto.Visible = true;
               _textBoxCode.ReadOnly = _checkBoxAuto.Checked;
               _textBoxCode.BackColor = _checkBoxAuto.Checked ? SystemColors.Control : Color.White;
               break;
         }
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
      }


      private void _textBoxCode_Leave(object sender, EventArgs e)
      {
         if (_textBoxCode.Text.Length < 2 || (_textBoxCode.Text.Length > 1 && _textBoxCode.Text[0] != 'Z'))
         {
            string abbr = AAMVAID.LookupStateAbbreviation(_jurisdiction);
            if (abbr != null)
            {
               _textBoxCode.Text = "Z" + abbr[0];
            }
            else
            {
               _textBoxCode.Text = "ZX";
            }
         }
      }

      private void _textBoxCode_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (_textBoxCode.Text.Length == 2 && !char.IsControl(e.KeyChar) && _textBoxCode.SelectedText.Length == 0)
         {
            e.Handled = true;
            System.Media.SystemSounds.Beep.Play();
            return;
         }


         if (!(char.IsLetter(e.KeyChar) && char.IsUpper(e.KeyChar) || char.IsControl(e.KeyChar)))
         {
            e.Handled = true;
            System.Media.SystemSounds.Beep.Play();
            return;
         }

      }

      private void _btnAddAddSubDlg_Click(object sender, EventArgs e)
      {
         AAMVASubfileType subfileType = (AAMVASubfileType)_comboBoxSubfileType.SelectedValue;
         if (subfileType != AAMVASubfileType.JurisdictionSpecific ||
            subfileType == AAMVASubfileType.JurisdictionSpecific && _textBoxCode.Text.Length == 2 && _textBoxCode.Text[0] == 'Z')
         {
            bool hasIDDL = false;
            bool hasJurisSpec = false;
            foreach(MainForm.SubfileSkeleton existingSubfile in _parent.SubfileSkeletons)
            {
               if (existingSubfile.SubfileType == AAMVASubfileType.DL || existingSubfile.SubfileType == AAMVASubfileType.ID)
                  hasIDDL = true;

               if (existingSubfile.SubfileType == AAMVASubfileType.JurisdictionSpecific)
                  hasJurisSpec = true;
            }

            if((subfileType == AAMVASubfileType.DL || subfileType == AAMVASubfileType.ID) && hasIDDL)
            {
               MessageBox.Show("AAMVA ID can only have 1 ID/DL subfile. You must delete the existing ID/DL subfile to continue with this operation.");
               System.Media.SystemSounds.Beep.Play();
               return;
            }

            if (subfileType == AAMVASubfileType.JurisdictionSpecific && hasJurisSpec)
            {
               MessageBox.Show("AAMVA ID can only have 1 jurisdiction-specific subfile. You must delete the existing jurisdiction-specific subfile to continue with this operation.");
               System.Media.SystemSounds.Beep.Play();
               return;
            }

            RaiseSubfileAddedEvent();
            Hide();
            Close();
         }
         else
         {
            MessageBox.Show("Invalid Subfile Type Code!");
            System.Media.SystemSounds.Beep.Play();
         }
      }

      public class SubfileAddedEventArgs
      {  
         public SubfileAddedEventArgs(AAMVASubfileType subfileType, string subfileTypeCode)
         {
            this.SubfileType = subfileType;
            this.SubfileTypeCode = subfileTypeCode;
         }

         public AAMVASubfileType SubfileType { get; set; }
         public string SubfileTypeCode { get; set; }
      }

      public event SubfileAddedEventHandler SubfileAdded;

      public delegate void SubfileAddedEventHandler(object sender, SubfileAddedEventArgs e);

      protected virtual void RaiseSubfileAddedEvent()
      {
         if (SubfileAdded != null)
         {
            AAMVASubfileType subfileType = (AAMVASubfileType)_comboBoxSubfileType.SelectedValue;
            SubfileAdded(this, new SubfileAddedEventArgs(subfileType, _textBoxCode.Text));
         }
      }
   }
}
