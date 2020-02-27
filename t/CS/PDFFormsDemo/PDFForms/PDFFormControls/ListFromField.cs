// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Pdf;

namespace PDFFormsDemo
{
   public class ListFormField : FormFieldControl, IFormFieldList
   {
      public ListFormField()
      {
         _pdfListBox = new PDFListBox();
         this.SetChildControl(_pdfListBox);
      }

      public override void InitControl(PDFFormField formField)
      {
         base.InitControl(formField);

         ListBox listBox = _pdfListBox.ListBox;

         foreach (string content in formField.Contents)
         {
            _items.Add(content);
         }

         UpdateItemsList(_items, listBox.Items);

         bool ChoiceMultiSelect = (formField.FieldFlags & PDFFormField.FieldFlagsChoiceMultiSelect) == PDFFormField.FieldFlagsChoiceMultiSelect;
         bool ChoiceSort = (formField.FieldFlags & PDFFormField.FieldFlagsChoiceSort) == PDFFormField.FieldFlagsChoiceSort;

         if (ChoiceMultiSelect)
            listBox.SelectionMode = SelectionMode.MultiSimple;
         else
            listBox.SelectionMode = SelectionMode.One;

         if (ChoiceSort)
            this.Sort();

         if (formField.SelectedContents.Count > 0)
         {
            if (listBox.SelectionMode == SelectionMode.MultiSimple)
            {
               foreach (string content in formField.SelectedContents)
               {
                  int index = listBox.Items.IndexOf(content);
                  listBox.SetSelected(index, true);
               }
            }
            else
            {
               listBox.SelectedItem = formField.SelectedContents[0];
            }
         }
      }

      public override void SetToolTip(string toolTip)
      {
         if (FormFieldControl.FormFieldsToolTip != null)
         {
            FormFieldControl.FormFieldsToolTip.SetToolTip(_pdfListBox.ListBox, toolTip);
         }

         base.SetToolTip(toolTip);
      }

      public override void SetContextMenuStrip()
      {
         base.SetContextMenuStrip();

         if (FormFieldControl.FormFieldsContextMenu != null)
         {
            ListBox listBox = _pdfListBox.ListBox;
            listBox.Tag = this;

            listBox.ContextMenuStrip = FormFieldControl.FormFieldsContextMenu;
         }
      }

      public override void UpdateFormField(PDFFormField formField)
      {
         base.UpdateFormField(formField);

         ListBox listBox = _pdfListBox.ListBox;

         formField.Contents.Clear();
         foreach (string item in listBox.Items)
         {
            string itemContent = item;
            formField.Contents.Add(itemContent);
         }

         formField.SelectedContents.Clear();
         foreach (string item in listBox.SelectedItems)
         {
            string selectedItem = item;
            formField.SelectedContents.Add(selectedItem);
         }

         if (listBox.SelectionMode == SelectionMode.MultiSimple)
            formField.FieldFlags |= PDFFormField.FieldFlagsChoiceMultiSelect;

         if (_isSorted)
            formField.FieldFlags |= PDFFormField.FieldFlagsChoiceSort;
      }

      protected override void OnPropertyChange()
      {
         this._pdfListBox.Enabled = !_isReadOnly;

         base.OnPropertyChange();
      }

      public void Sort()
      {
         _items.Sort();

         //Update ListBox items.
         UpdateItemsList(_items, _pdfListBox.ListBox.Items);

         _isSorted = true;
      }

      #region Properties

      #region PDFListBox

      private PDFListBox _pdfListBox;
      public PDFListBox PDFListBox
      {
         get { return this._pdfListBox; }
      }

      #endregion //PDFListBox

      #region Items

      private List<string> _items = new List<string>();
      public List<string> Items
      {
         get
         {
            return _items;
         }
         set
         {
            if (value != null)
            {
               UpdateItemsList(value, _items);
               UpdateItemsList(value, _pdfListBox.ListBox.Items);
               _isSorted = false;
            }
         }
      }

      private void UpdateItemsList(List<string> newItems, IList target)
      {
         target.Clear();

         for (int i = 0; i < newItems.Count; i++)
         {
            target.Add(newItems[i]);
         }
      }

      #endregion //Items

      #region SelectedIndex

      public int SelectedIndex
      {
         get
         {
            ListBox listBox = _pdfListBox.ListBox;
            return listBox.SelectedIndex;
         }
         set
         {
            ListBox listBox = _pdfListBox.ListBox;
            listBox.SelectedIndex = value;
         }
      }

      #endregion //SelectedIndex

      #region SelectedIndices

      public List<int> SelectedIndices
      {
         get
         {
            ListBox listBox = _pdfListBox.ListBox;

            List<int> selectedIndices = new List<int>();
            foreach (int index in listBox.SelectedIndices)
            {
               selectedIndices.Add(index);
            }

            return selectedIndices;
         }
         set
         {
            ListBox listBox = _pdfListBox.ListBox;
            listBox.ClearSelected();

            if (value != null)
            {
               foreach (int index in value)
               {
                  listBox.SetSelected(index, true);
               }
            }
         }
      }

      #endregion //SelectedIndex

      #region IsSorted

      private bool _isSorted = false;
      public bool IsSorted
      {
         get { return _isSorted; }
         set
         {
            _isSorted = value;

            if (_isSorted)
            {
               this.Sort();
            }
         }
      }

      #endregion //IsSorted

      #endregion //Properties
   }

   public class PDFListBox : Panel, IFormFieldControl
   {
      private bool _focus = false;
      private bool _isBorderStyleUpdated = false;

      public PDFListBox()
      {
         _listBox = new ListBox();
         _listBox.BorderStyle = BorderStyle.None;
         _listBox.Dock = DockStyle.Fill;
         _listBox.IntegralHeight = false;
         _listBox.MouseEnter += PDFListBox_MouseEnter;
         _listBox.MouseLeave += PDFListBox_MouseLeave;

         this.Controls.Add(_listBox);
         this.MouseEnter += PDFListBox_MouseEnter;
         this.MouseLeave += PDFListBox_MouseLeave;
         this.Paint += PDFListBox_Paint;
      }

      private void PDFListBox_MouseEnter(object sender, EventArgs e)
      {
         _focus = true;
         this.Invalidate();
      }

      private void PDFListBox_MouseLeave(object sender, EventArgs e)
      {
         _focus = false;
         this.Invalidate();
      }

      private void PDFListBox_Paint(object sender, PaintEventArgs e)
      {
         if (!_isBorderStyleUpdated)
         {
            this.FieldBorderStyle = _fieldBorderStyle;
            _isBorderStyleUpdated = true;
         }

         // Draw ListBox Border.
         FormFieldControl.DrawBorder(e.Graphics, this, this.ClientSize, _focus);
      }

      #region Properties

      #region ForeColor

      public override Color ForeColor
      {
         get
         {
            return _listBox.ForeColor;
         }
         set
         {
            _listBox.ForeColor = value;
         }
      }

      #endregion //ForeColor

      #region BackgroundColor

      protected Color _backgroundColor = SystemColors.Control;
      public Color BackgroundColor
      {
         get
         {
            return _backgroundColor;
         }
         set
         {
            _backgroundColor = value;
            _listBox.BackColor = this._backgroundColor;
         }
      }

      #endregion //BackgroundColor

      #region BorderColor

      protected Color _borderColor = Color.Black;
      public Color BorderColor
      {
         get
         {
            return _borderColor;
         }
         set
         {
            _borderColor = value;
         }
      }

      #endregion //BorderColor

      #region BorderThickness

      private int _borderThickness = 1;
      public int BorderThickness
      {
         get
         {
            return _borderThickness;
         }
         set
         {
            _borderThickness = value;
         }
      }

      #endregion //BorderThickness

      #region FieldBorderStyle

      protected FieldBorderStyle _fieldBorderStyle = FieldBorderStyle.Solid;
      public FieldBorderStyle FieldBorderStyle
      {
         get
         {
            return _fieldBorderStyle;
         }
         set
         {
            _fieldBorderStyle = value;

            switch (_fieldBorderStyle)
            {
               case FieldBorderStyle.Solid:
               case FieldBorderStyle.Dashed:
                  this.Padding = new Padding(_borderThickness);
                  break;
               case FieldBorderStyle.Beveled:
               case FieldBorderStyle.Inset:
                  this.Padding = new Padding(_borderThickness * 2);
                  break;
               case FieldBorderStyle.Underlined:
                  this.Padding = new Padding(0, 0, 0, _borderThickness);
                  break;
            }
         }
      }

      #endregion //FieldBorderStyle

      #region FocusedBorderColor

      protected Color _focusedBorderColor = Color.FromArgb(255, 0, 153, 225);
      public Color FocusedBorderColor
      {
         get
         {
            return _focusedBorderColor;
         }
      }

      #endregion //FocusedBorderColor

      #region IsFieldVisible

      private bool _isFieldVisible = true;
      public bool IsFieldVisible
      {
         get
         {
            return _isFieldVisible;
         }
         set
         {
            _listBox.Visible = value;
            _isFieldVisible = value;
         }
      }

      #endregion //IsFieldVisible

      #region ListBox

      private ListBox _listBox;
      public ListBox ListBox
      {
         get { return _listBox; }
      }

      #endregion //ListBox

      #endregion //Properties
   }
}
