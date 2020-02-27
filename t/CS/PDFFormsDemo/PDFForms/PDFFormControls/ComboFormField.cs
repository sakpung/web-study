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
   public class ComboFormField : FormFieldControl, IFormFieldList
   {
      public ComboFormField()
      {
         _pdfComboBox = new PDFComboBox();
         _pdfComboBox.SelectedIndexChanged += PDFComboBox_SelectedIndexChanged;
         this.SetChildControl(_pdfComboBox);
      }

      protected override void OnSizeChanged(EventArgs e)
      {
         if (_pdfComboBox != null)
         {
            _pdfComboBox.SetHeight(this.Height);
         }

         base.OnSizeChanged(e);
      }

      public override void InitControl(PDFFormField formField)
      {
         base.InitControl(formField);

         _items.Clear();
         foreach (string content in formField.Contents)
            _items.Add(content);

         UpdateItemsList(_items, _pdfComboBox.Items);

         bool ChoiceSort = (formField.FieldFlags & PDFFormField.FieldFlagsChoiceSort) == PDFFormField.FieldFlagsChoiceSort;

         if (ChoiceSort)
            this.Sort();

         // Set PDFComboBox selected item, using PDFFormField.ContentValues and Items List.
         string selectedContent = (this.PDFFormField.SelectedContents.Count <= 0 ? "" : this.PDFFormField.SelectedContents[0]);

         SetContentText(this.PDFFormField.ContentValues, selectedContent);

         _pdfComboBox.SetHeight(this.Height);
      }

      public override void SetToolTip(string toolTip)
      {
         if (FormFieldControl.FormFieldsToolTip != null)
         {
            FormFieldControl.FormFieldsToolTip.SetToolTip(_pdfComboBox, toolTip);
         }

         base.SetToolTip(toolTip);
      }

      public override void SetContextMenuStrip()
      {
         base.SetContextMenuStrip();

         if (FormFieldControl.FormFieldsContextMenu != null)
         {
            _pdfComboBox.Tag = this;

            _pdfComboBox.ContextMenuStrip = FormFieldControl.FormFieldsContextMenu;
         }
      }

      public override void UpdateFormField(PDFFormField formField)
      {
         base.UpdateFormField(formField);

         formField.Contents.Clear();
         foreach (string item in _items)
         {
            string itemContent = item;
            formField.Contents.Add(itemContent);
         }

         formField.SelectedContents.Clear();
         if (_pdfComboBox.SelectedItem != null)
         {
            string selectedItem = _pdfComboBox.SelectedItem != null ? _pdfComboBox.SelectedItem.ToString() : "";
            formField.SelectedContents.Add(selectedItem);
         }

         if (_isSorted)
            formField.FieldFlags |= PDFFormField.FieldFlagsChoiceSort;
      }

      protected override void DoFontResize()
      {
         base.DoFontResize();

         _pdfComboBox.SetHeight(this.Height);
      }

      protected override void OnPropertyChange()
      {
         this._pdfComboBox.Enabled = !_isReadOnly;

         base.OnPropertyChange();
      }

      public void Sort()
      {
         _items.Sort();

         //Update ComboBox items.
         UpdateItemsList(_items, _pdfComboBox.Items);

         _isSorted = true;
      }

      private void PDFComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         _pdfComboBox.ContentText = "";
         _pdfComboBox.Invalidate();
      }

      private void SetContentText(IList<string> contentValues, string selectedContent)
      {
         bool inItems = _items.IndexOf(selectedContent) != -1;
         bool inValues = contentValues.IndexOf(selectedContent) != -1;

         if (inItems)
         {
            _pdfComboBox.SelectedIndex = _items.IndexOf(selectedContent);
            _pdfComboBox.ContentText = "";
         }
         else if (inValues)
         {
            _pdfComboBox.SelectedIndex = contentValues.IndexOf(selectedContent);
            _pdfComboBox.ContentText = "";
         }
         else
         {
            _pdfComboBox.SelectedIndex = -1;
            _pdfComboBox.ContentText = selectedContent;
         }
      }

      #region Properties

      #region PDFComboBox

      private PDFComboBox _pdfComboBox;
      public PDFComboBox PDFComboBox
      {
         get { return this._pdfComboBox; }
      }

      #endregion //PDFComboBox

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
               UpdateItemsList(value, _pdfComboBox.Items);
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
            return _pdfComboBox.SelectedIndex;
         }
         set
         {
            _pdfComboBox.SelectedIndex = value;
         }
      }

      #endregion //SelectedIndex

      #region SelectedIndices

      public List<int> SelectedIndices
      {
         get
         {
            List<int> selectedIndices = new List<int>();
            if (_pdfComboBox.SelectedIndex != -1)
            {
               selectedIndices.Add(_pdfComboBox.SelectedIndex);
            }

            return selectedIndices;
         }
         set
         {
            if (value != null && value.Count > 0)
            {
               _pdfComboBox.SelectedIndex = value[0];
            }
         }
      }

      #endregion //SelectedIndices

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

   public class PDFComboBox : ComboBox, IFormFieldControl
   {
      private bool _focus = false;

      public PDFComboBox()
      {
         this.SetStyle(ControlStyles.UserPaint, true);

         this.DrawMode = DrawMode.OwnerDrawVariable;
         this.DropDownStyle = ComboBoxStyle.DropDownList;

         this.DrawItem += CustomComboBox_DrawItem;

         this.MouseEnter += PDFComboBox_MouseEnter;
         this.MouseLeave += PDFComboBox_MouseLeave;
      }

      private void PDFComboBox_MouseEnter(object sender, EventArgs e)
      {
         _focus = true;
      }

      private void PDFComboBox_MouseLeave(object sender, EventArgs e)
      {
         _focus = false;
      }

      protected override void OnPaint(PaintEventArgs e)
      {
         e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

         // Draw ComboBox Border.
         FormFieldControl.DrawBorder(e.Graphics, this, this.Parent.Size, _focus);

         Rectangle innerRect = GetInnerRect();

         using (e.Graphics.Clip = new Region(innerRect))
         {
            // Draw Background Rectangle
            using (SolidBrush brush = new SolidBrush(this.BackgroundColor))
            {
               e.Graphics.FillRectangle(brush, innerRect);
            }

            // Draw Selected Item String
            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {
               string selectetItem = this.SelectedItem == null ? "" : this.SelectedItem.ToString();

               string text = string.IsNullOrEmpty(ContentText) ? selectetItem : this.ContentText;

               SizeF textSize = e.Graphics.MeasureString(text, this.Font);

               float centerY = innerRect.Y + (innerRect.Height - textSize.Height) / 2;

               e.Graphics.DrawString(text, this.Font, brush, innerRect.X, centerY);
            }

            // Draw Combo Button
            Rectangle comboButtonRect = new Rectangle(innerRect.X + innerRect.Width - 15, innerRect.Y, 15, innerRect.Height);

            ControlPaint.DrawComboButton(e.Graphics, comboButtonRect, ButtonState.Normal);
         }
      }

      private void CustomComboBox_DrawItem(object sender, DrawItemEventArgs e)
      {
         // Draw the background of the item.
         e.DrawBackground();

         if (e.Index != -1)
         {
            // Draw each string in the array.
            e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds);
         }

         // Draw the focus rectangle if the mouse hovers over an item.
         e.DrawFocusRectangle();
      }

      private Rectangle GetInnerRect()
      {
         Rectangle rect = new Rectangle(new Point(0, 0), this.Parent.Size);

         switch (_fieldBorderStyle)
         {
            case FieldBorderStyle.Solid:
            case FieldBorderStyle.Dashed:
               rect.Inflate(-this._borderThickness, -this._borderThickness);
               break;
            case FieldBorderStyle.Beveled:
            case FieldBorderStyle.Inset:
               rect.Inflate(-this._borderThickness * 2, -this._borderThickness * 2);
               break;
            case FieldBorderStyle.Underlined:
               rect.Height -= this._borderThickness;
               break;
         }

         return rect;
      }

      [System.Runtime.InteropServices.DllImport("user32.dll")]
      private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
      private const Int32 CB_SETITEMHEIGHT = 0x153;

      public void SetHeight(Int32 desiredHeight)
      {
         SendMessage(this.Handle, CB_SETITEMHEIGHT, -1, desiredHeight);
      }

      #region Properties

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
            this.Visible = value;
            _isFieldVisible = value;
         }
      }

      #endregion //IsFieldVisible

      #region ContentText

      [System.ComponentModel.DefaultValue("")]
      public string ContentText
      {
         get;
         set;
      }

      #endregion //ContentText

      #endregion //Properties
   }
}
