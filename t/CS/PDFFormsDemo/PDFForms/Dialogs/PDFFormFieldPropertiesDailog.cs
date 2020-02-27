// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.Pdf;

namespace PDFFormsDemo
{
   public partial class PDFFormFieldPropertiesDailog : Form
   {
      FormFieldControl _formFieldControl;
      public PDFFormFieldPropertiesDailog(FormFieldControl control)
      {
         InitializeComponent();

         foreach (FontFamily font in System.Drawing.FontFamily.Families)
         {
            _appearanceFontFamilyComboBox.Items.Add(font.Name);
         }

         if (control != null)
         {
            _formFieldControl = control;

            InitPropertiesControls();
         }

         this.FormClosing += PDFFormFieldPropertiesDailog_FormClosing;

         UpdateControls();
      }

      private void PDFFormFieldPropertiesDailog_FormClosing(object sender, FormClosingEventArgs e)
      {
         this.UpdateFormFieldControl();
      }

      private void InitPropertiesControls()
      {
         this.Text = GetFormFieldControlTypeName();

         #region General

         _generalNameTextBox.Text = _formFieldControl.FieldName;

         if (!string.IsNullOrEmpty(_formFieldControl.AlternateName))
            _generalTooltipTextBox.Text = _formFieldControl.AlternateName;

         // Set form field view and print property
         if (_formFieldControl.IsFieldVisible && _formFieldControl.IsFieldPrintable)
            _generalFormFieldComboBox.SelectedIndex = 0;
         else if (!_formFieldControl.IsFieldVisible && !_formFieldControl.IsFieldPrintable)
            _generalFormFieldComboBox.SelectedIndex = 1;
         else if (_formFieldControl.IsFieldVisible && !_formFieldControl.IsFieldPrintable)
            _generalFormFieldComboBox.SelectedIndex = 2;
         else if (!_formFieldControl.IsFieldVisible && _formFieldControl.IsFieldPrintable)
            _generalFormFieldComboBox.SelectedIndex = 3;

         _generalReadOnlyCheckBox.Checked = _formFieldControl.IsReadOnly;
         _lockedCheckBox.Checked = _formFieldControl.IsFieldLocked;

         #endregion

         #region Appearance

         if (_formFieldControl.BorderColor != null)
            _appearanceBorderColorColorPicker.Color = _formFieldControl.BorderColor;

         if (_formFieldControl.BackgroundColor != null)
         {
            _appearanceFillColorColorPicker.Color = _formFieldControl.BackgroundColor;
            _formFieldControl.FillMode = PDFFormField.FillModeFilled;
         }

         switch (_formFieldControl.BorderThickness)
         {
            case 1:
               _appearanceBorderThicknessComboBox.SelectedIndex = 0;
               break;
            case 2:
               _appearanceBorderThicknessComboBox.SelectedIndex = 1;
               break;
            case 3:
               _appearanceBorderThicknessComboBox.SelectedIndex = 2;
               break;
         }

         _appearanceBorderStyleComboBox.SelectedIndex = (int)_formFieldControl.FieldBorderStyle;

         if (_formFieldControl is CheckFormField || _formFieldControl is RadioFormField)
            _appearanceTextGroupBox.Enabled = false;

         _appearanceFontFamilyComboBox.SelectedItem = _formFieldControl.Font.FontFamily.Name;

         if (_formFieldControl.AutoFontResize)
         {
            _appearanceFontSizeComboBox.SelectedIndex = 0;
         }
         else
         {
            switch ((int)_formFieldControl.Font.Size)
            {
               case 6:
                  _appearanceFontSizeComboBox.SelectedIndex = 1;
                  break;
               case 8:
                  _appearanceFontSizeComboBox.SelectedIndex = 2;
                  break;
               case 9:
                  _appearanceFontSizeComboBox.SelectedIndex = 3;
                  break;
               case 10:
                  _appearanceFontSizeComboBox.SelectedIndex = 4;
                  break;
               case 12:
                  _appearanceFontSizeComboBox.SelectedIndex = 5;
                  break;
               case 14:
                  _appearanceFontSizeComboBox.SelectedIndex = 6;
                  break;
               case 18:
                  _appearanceFontSizeComboBox.SelectedIndex = 7;
                  break;
            }
         }

         if (_formFieldControl.ForeColor != null)
            _appearanceTextColorColorPicker.Color = _formFieldControl.ForeColor;

         #endregion //Appearance

         #region Options

         if (_formFieldControl is IFormFieldList)
         {
            _optionsItemsPanel.Visible = true;

            List<string> items = new List<string>();
            for (int i = 0; i < (_formFieldControl as IFormFieldList).Items.Count; i++)
            {
               items.Add((_formFieldControl as IFormFieldList).Items[i]);
            }

            _optionsItemsListBox.DataSource = items;
            _optionsSortItemsCheckBox.Checked = (_formFieldControl as IFormFieldList).IsSorted;

            _optionsItemsListBox.ClearSelected();
            foreach (int index in (_formFieldControl as IFormFieldList).SelectedIndices)
            {
               _optionsItemsListBox.SetSelected(index, true);
            }

            if (_formFieldControl is ListFormField)
            {
               _optionsMultipleSelectionCheckBox.Visible = true;
               _optionsMultipleSelectionLabel.Visible = true;

               ListBox listBox = (_formFieldControl as ListFormField).PDFListBox.ListBox;
               if (listBox.SelectionMode == SelectionMode.MultiSimple)
               {
                  _optionsMultipleSelectionCheckBox.Checked = true;
               }
            }
         }
         else if (_formFieldControl is TextFormField)
         {
            TextBox textBox = (_formFieldControl as TextFormField).PDFTextBox.TextBox;

            _optionsTextBoxPanel.Visible = true;

            switch (textBox.TextAlign)
            {
               case HorizontalAlignment.Left:
                  _optionsAlignmentComboBox.SelectedIndex = 0; //Left
                  break;

               case HorizontalAlignment.Center:
                  _optionsAlignmentComboBox.SelectedIndex = 1; //Center
                  break;

               case HorizontalAlignment.Right:
                  _optionsAlignmentComboBox.SelectedIndex = 2; //Right
                  break;
            }

            _optionsMultiLineCheckBox.Checked = textBox.Multiline;
         }
         else
         {
            _propertiesTabControl.Controls.Remove(_optionsTabPage);
         }

         #endregion //Options
      }

      private void UpdateFormFieldControl()
      {
         #region General

         _formFieldControl.FieldName = _generalNameTextBox.Text;

         _formFieldControl.SetToolTip(_generalTooltipTextBox.Text);

         switch (_generalFormFieldComboBox.SelectedIndex)
         {
            case 0://Visible
               _formFieldControl.IsFieldVisible = true;
               _formFieldControl.IsFieldPrintable = true;
               break;

            case 1://Hidden
               _formFieldControl.IsFieldVisible = false;
               _formFieldControl.IsFieldPrintable = false;
               break;

            case 2://Visible but doesn't print
               _formFieldControl.IsFieldVisible = true;
               _formFieldControl.IsFieldPrintable = false;
               break;

            case 3://Hidden but printable
               _formFieldControl.IsFieldVisible = false;
               _formFieldControl.IsFieldPrintable = true;
               break;
         }

         _formFieldControl.IsReadOnly = _generalReadOnlyCheckBox.Checked;

         _formFieldControl.IsFieldLocked = _lockedCheckBox.Checked;

         #endregion //General

         #region Appearance

         _formFieldControl.BorderColor = _appearanceBorderColorColorPicker.Color;

         _formFieldControl.BackgroundColor = _appearanceFillColorColorPicker.Color;

         switch (_appearanceBorderThicknessComboBox.SelectedIndex)
         {
            case 0:
               _formFieldControl.BorderThickness = 1;
               break;
            case 1:
               _formFieldControl.BorderThickness = 2;
               break;
            case 2:
               _formFieldControl.BorderThickness = 3;
               break;
         }

         _formFieldControl.FieldBorderStyle = (FieldBorderStyle)_appearanceBorderStyleComboBox.SelectedIndex;

         string familyName = _appearanceFontFamilyComboBox.SelectedItem.ToString();
         int fontSize = FormFieldControl.MaxFontSize;

         _formFieldControl.AutoFontResize = false;
         switch (_appearanceFontSizeComboBox.SelectedIndex)
         {
            case 0:
               _formFieldControl.AutoFontResize = true;
               break;
            case 1:
               fontSize = 6;
               break;
            case 2:
               fontSize = 8;
               break;
            case 3:
               fontSize = 9;
               break;
            case 4:
               fontSize = 10;
               break;
            case 5:
               fontSize = 12;
               break;
            case 6:
               fontSize = 14;
               break;
            case 7:
               fontSize = 18;
               break;
         }

         _formFieldControl.Font = new Font(familyName, fontSize);

         _formFieldControl.ForeColor = _appearanceTextColorColorPicker.Color;

         #endregion //Appearance

         #region Options

         if (_propertiesTabControl.Controls.Contains(_optionsTabPage))
         {
            if (_formFieldControl is IFormFieldList)
            {
               IFormFieldList formFieldList = (_formFieldControl as IFormFieldList);
               formFieldList.Items = _optionsItemsListBox.DataSource as List<string>;
               formFieldList.IsSorted = _optionsSortItemsCheckBox.Checked;

               if (_formFieldControl is ListFormField)
               {
                  ListBox listBox = (_formFieldControl as ListFormField).PDFListBox.ListBox;

                  if (_optionsMultipleSelectionCheckBox.Checked)
                     listBox.SelectionMode = SelectionMode.MultiSimple;
                  else
                     listBox.SelectionMode = SelectionMode.One;
               }

               //Set selected sndices for IFormFieldList.
               List<int> selectedIndices = new List<int>();
               foreach (int index in _optionsItemsListBox.SelectedIndices)
               {
                  selectedIndices.Add(index);
               }
               formFieldList.SelectedIndices = selectedIndices;
            }
            else if (_formFieldControl is TextFormField)
            {
               TextBox textBox = (_formFieldControl as TextFormField).PDFTextBox.TextBox;

               switch (_optionsAlignmentComboBox.SelectedIndex)
               {
                  case 0: //Left
                     textBox.TextAlign = HorizontalAlignment.Left;
                     break;

                  case 1: //Center
                     textBox.TextAlign = HorizontalAlignment.Center;
                     break;

                  case 2: //Right
                     textBox.TextAlign = HorizontalAlignment.Right;
                     break;
               }

               textBox.Multiline = _optionsMultiLineCheckBox.Checked;
               textBox.WordWrap = _optionsMultiLineCheckBox.Checked;
            }
         }

         #endregion //Options
      }

      private string GetFormFieldControlTypeName()
      {
         string name = "";

         if (_formFieldControl is CheckFormField)
            name = "Check Box Form Field Properties";
         else if (_formFieldControl is RadioFormField)
            name = "Radio Button Form Field Properties";
         else if (_formFieldControl is ComboFormField)
            name = "Combo Box Form Field Properties";
         else if (_formFieldControl is ListFormField)
            name = "List Box Form Field Properties";
         else if (_formFieldControl is TextFormField)
            name = "Text Box Form Field Properties";

         return name;
      }

      #region Options Items Panel Events

      private void _optionsAddItemTextBox_TextChanged(object sender, EventArgs e)
      {
         UpdateControls();
      }

      private void _optionsAddItemButton_Click(object sender, EventArgs e)
      {
         List<string> itemsList = _optionsItemsListBox.DataSource as List<string>;
         itemsList.Add(_optionsAddItemTextBox.Text);

         UpdateOptionsItemsListBox(itemsList);

         _optionsItemsListBox.SelectedItem = _optionsItemsListBox.Items.Count - 1;

         _optionsAddItemTextBox.Text = "";

         UpdateControls();
      }

      private void _optionsDeleteButton_Click(object sender, EventArgs e)
      {
         List<string> itemsList = _optionsItemsListBox.DataSource as List<string>;
         itemsList.Remove(_optionsItemsListBox.SelectedItem.ToString());

         UpdateOptionsItemsListBox(itemsList);

         UpdateControls();
      }

      private void _optionsUpButton_Click(object sender, EventArgs e)
      {
         int index = _optionsItemsListBox.SelectedIndex;

         string content = _optionsItemsListBox.SelectedItem.ToString();

         List<string> itemsList = _optionsItemsListBox.DataSource as List<string>;
         itemsList.Insert(index - 1, content);
         itemsList.RemoveAt(index + 1);

         UpdateOptionsItemsListBox(itemsList);

         _optionsItemsListBox.SelectedIndex = index - 1;

         _optionsSortItemsCheckBox.Checked = false;

         UpdateControls();
      }

      private void _optionsDownButton_Click(object sender, EventArgs e)
      {
         int index = _optionsItemsListBox.SelectedIndex;

         string content = _optionsItemsListBox.SelectedItem.ToString();

         List<string> itemsList = _optionsItemsListBox.DataSource as List<string>;
         itemsList.Insert(index + 2, content);
         itemsList.RemoveAt(index);

         UpdateOptionsItemsListBox(itemsList);

         _optionsItemsListBox.SelectedIndex = index + 1;

         _optionsSortItemsCheckBox.Checked = false;

         UpdateControls();
      }

      private void UpdateOptionsItemsListBox(List<string> itemsList)
      {
         _optionsItemsListBox.DataSource = null;
         _optionsItemsListBox.DataSource = itemsList;
      }

      private void _optionItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateControls();
      }

      private void _optionsSortItemsCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         if (_optionsSortItemsCheckBox.Checked)
         {
            List<string> itemsList = _optionsItemsListBox.DataSource as List<string>;
            itemsList.Sort();

            UpdateOptionsItemsListBox(itemsList);
         }
      }

      #endregion //Options Items Panel Events

      private void UpdateControls()
      {
         _generalTabPage.Enabled = !_lockedCheckBox.Checked;
         _appearanceTabPage.Enabled = !_lockedCheckBox.Checked;
         _optionsTabPage.Enabled = !_lockedCheckBox.Checked;

         if (string.IsNullOrEmpty(_optionsAddItemTextBox.Text))
            _optionsAddItemButton.Enabled = false;
         else
            _optionsAddItemButton.Enabled = true;

         bool firstItem = _optionsItemsListBox.SelectedIndex == 0;
         bool lastItem = _optionsItemsListBox.SelectedIndex == (_optionsItemsListBox.Items.Count - 1);

         if (firstItem || _optionsItemsListBox.SelectedItem == null)
            _optionsUpButton.Enabled = false;
         else
            _optionsUpButton.Enabled = true;

         if (lastItem || _optionsItemsListBox.SelectedItem == null)
            _optionsDownButton.Enabled = false;
         else
            _optionsDownButton.Enabled = true;

         if (_optionsItemsListBox.SelectedItem == null)
            _optionsDeleteButton.Enabled = false;
         else
            _optionsDeleteButton.Enabled = true;
      }

      private void _lockedCheckBox_Click(object sender, EventArgs e)
      {
         UpdateControls();
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
