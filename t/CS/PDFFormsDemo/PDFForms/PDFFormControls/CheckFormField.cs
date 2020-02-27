// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Pdf;

namespace PDFFormsDemo
{
   public class CheckFormField : FormFieldControl
   {
      public CheckFormField()
      {
         _pdfCheckBox = new PDFCheckBox();
         this.SetChildControl(_pdfCheckBox);
      }

      public override void InitControl(PDFFormField formField)
      {
         base.InitControl(formField);

         _pdfCheckBox.Checked = formField.State == PDFFormField.StateSelected ? true : false;
      }

      public override void SetToolTip(string toolTip)
      {
         if (FormFieldControl.FormFieldsToolTip != null)
         {
            FormFieldControl.FormFieldsToolTip.SetToolTip(_pdfCheckBox, toolTip);
         }

         base.SetToolTip(toolTip);
      }

      public override void SetContextMenuStrip()
      {
         base.SetContextMenuStrip();

         if (FormFieldControl.FormFieldsContextMenu != null)
         {
            _pdfCheckBox.Tag = this;

            _pdfCheckBox.ContextMenuStrip = FormFieldControl.FormFieldsContextMenu;
         }
      }

      public override void UpdateFormField(PDFFormField formField)
      {
         base.UpdateFormField(formField);

         if (_pdfCheckBox.Checked == true)
            formField.State = PDFFormField.StateSelected;
         else
            formField.State = PDFFormField.StateNotSelected;
      }

      protected override void OnPropertyChange()
      {
         this._pdfCheckBox.Enabled = !_isReadOnly;

         base.OnPropertyChange();
      }

      #region Properties

      #region PDFComboBox

      private PDFCheckBox _pdfCheckBox;
      public PDFCheckBox PDFCheckBox
      {
         get { return this._pdfCheckBox; }
      }

      #endregion //PDFCheckBox

      #endregion //Properties
   }

   public class PDFCheckBox : CheckBox, IFormFieldControl
   {
      private bool _focus = false;

      public PDFCheckBox()
      {
         this.CheckAlign = ContentAlignment.MiddleCenter;

         this._backgroundColor = this.BackColor;

         this.MouseEnter += PDFCheckBox_MouseEnter;
         this.MouseLeave += PDFCheckBox_MouseLeave;
      }

      private void PDFCheckBox_MouseEnter(object sender, EventArgs e)
      {
         _focus = true;
         this.Invalidate();
      }

      private void PDFCheckBox_MouseLeave(object sender, EventArgs e)
      {
         _focus = false;
         this.Invalidate();
      }

      protected override void OnPaint(PaintEventArgs e)
      {
         e.Graphics.Clear(this.BackColor);

         Rectangle innerRect = new Rectangle((_borderThickness), (_borderThickness), this.ClientSize.Width - (_borderThickness * 2), this.ClientSize.Height - (_borderThickness * 2));
         Rectangle backgroundRect = new Rectangle((_borderThickness), (_borderThickness), this.ClientSize.Width - (_borderThickness * 2), this.ClientSize.Height - (_borderThickness * 2));

         switch (_fieldBorderStyle)
         {
            case FieldBorderStyle.Beveled:
               backgroundRect.Inflate(-this._borderThickness, -this._borderThickness);
               break;
            case FieldBorderStyle.Inset:
               backgroundRect.Inflate(-this._borderThickness, -this._borderThickness);
               break;
            case FieldBorderStyle.Underlined:
               backgroundRect = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height - _borderThickness);
               break;
         }

         backgroundRect.Width = backgroundRect.Width == 0 ? 1 : backgroundRect.Width;
         backgroundRect.Height = backgroundRect.Height == 0 ? 1 : backgroundRect.Height;

         // Draw CheckBox Border.
         FormFieldControl.DrawBorder(e.Graphics, this, this.ClientSize, _focus);

         // Draw Check Box Background.
         e.Graphics.FillRectangle(new SolidBrush(_backgroundColor), backgroundRect);

         // Draw Check Mark.
         if (this.Checked)
         {
            int checkMarkHeight = innerRect.Height >= innerRect.Width ? innerRect.Width : innerRect.Height;
            Point checkMarkOffset = new Point(innerRect.X + ((innerRect.Width - checkMarkHeight) / 2), innerRect.Y + ((innerRect.Height - checkMarkHeight) / 2));
            Rectangle checkMarkRect = new Rectangle(checkMarkOffset.X, checkMarkOffset.Y, checkMarkHeight, checkMarkHeight);

            Font font = new Font("Verdana", checkMarkRect.Height, FontStyle.Bold);

            font = FitTextToControlHeight(font, checkMarkRect.Height);

            TextRenderer.DrawText(e.Graphics, "✓", font, new Point(checkMarkRect.X, checkMarkRect.Y), Color.Black);
         }
      }

      private Font FitTextToControlHeight(Font font, int controlHeight)
      {
         while (controlHeight < TextRenderer.MeasureText("✓", new Font(font.FontFamily, font.Size, font.Style)).Height)
         {
            font = new Font(font.FontFamily, font.Size - 0.5f, font.Style);
         }

         return font;
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

      #endregion //Properties
   }
}
