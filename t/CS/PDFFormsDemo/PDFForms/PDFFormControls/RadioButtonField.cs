// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Pdf;

namespace PDFFormsDemo
{
   public class RadioFormField : FormFieldControl
   {
      public RadioFormField()
      {
         _pdfRadioButton = new PDFRadioButton();
         this.SetChildControl(_pdfRadioButton);
      }

      protected override void OnSizeChanged(EventArgs e)
      {
         base.OnSizeChanged(e);

         GraphicsPath circularPath = new GraphicsPath();
         circularPath.AddEllipse(this.DisplayRectangle);

         this.Region = new Region(circularPath);
      }

      public override void InitControl(PDFFormField formField)
      {
         base.InitControl(formField);

         PDFRadioButton radioButton = _pdfRadioButton;

         radioButton.GroupName = formField.GroupId.ToString();

         radioButton.Checked = formField.State == PDFFormField.StateSelected ? true : false;
      }

      public override void SetToolTip(string toolTip)
      {
         if (FormFieldControl.FormFieldsToolTip != null)
         {
            FormFieldControl.FormFieldsToolTip.SetToolTip(_pdfRadioButton, toolTip);
         }

         base.SetToolTip(toolTip);
      }

      public override void SetContextMenuStrip()
      {
         base.SetContextMenuStrip();

         if (FormFieldControl.FormFieldsContextMenu != null)
         {
            PDFRadioButton radioButton = _pdfRadioButton;
            radioButton.Tag = this;

            radioButton.ContextMenuStrip = FormFieldControl.FormFieldsContextMenu;
         }
      }

      public override void UpdateFormField(PDFFormField formField)
      {
         base.UpdateFormField(formField);

         PDFRadioButton radioButton = _pdfRadioButton;

         if (radioButton.Checked == true)
            formField.State = PDFFormField.StateSelected;
         else
            formField.State = PDFFormField.StateNotSelected;
      }

      protected override void OnPropertyChange()
      {
         this._pdfRadioButton.Enabled = !_isReadOnly;

         base.OnPropertyChange();
      }

      #region Properties

      public override LeadRect FiedlBounds
      {
         get
         {
            return _fiedlBounds;
         }
         set
         {
            int controlRadius = value.Height >= value.Width ? value.Width : value.Height;

            this.Left = value.Left + ((value.Width - controlRadius) / 2);
            this.Top = value.Top + +((value.Height - controlRadius) / 2);
            this.Width = controlRadius;
            this.Height = controlRadius;

            _fiedlBounds = new LeadRect(this.Left, this.Top, this.Width, this.Height);
         }
      }

      #region PDFRadioButton

      private PDFRadioButton _pdfRadioButton;
      public PDFRadioButton PDFRadioButton
      {
         get { return this._pdfRadioButton; }
      }

      #endregion //PDFRadioButton

      #endregion //Properties
   }

   public class PDFRadioButton : RadioButton, IFormFieldControl
   {
      private bool _focus = false;

      public PDFRadioButton()
      {
         this.CheckAlign = ContentAlignment.MiddleCenter;

         this._backgroundColor = this.BackColor;

         this.MouseEnter += PDFRadioButton_MouseEnter;
         this.MouseLeave += PDFRadioButton_MouseLeave;
         this.CheckedChanged += PDFRadioButton_CheckedChanged;
      }

      private void PDFRadioButton_CheckedChanged(object sender, EventArgs e)
      {
         if (this.Checked)
         {
            foreach (PDFRadioButton radioButton in PDFRadioButton.RadioButtonGroups[_groupName])
            {
               if (radioButton != this)
               {
                  radioButton.Checked = false;
               }
            }
         }
      }

      private void PDFRadioButton_MouseEnter(object sender, EventArgs e)
      {
         _focus = true;
      }

      private void PDFRadioButton_MouseLeave(object sender, EventArgs e)
      {
         _focus = false;
      }

      protected override void OnPaint(PaintEventArgs e)
      {
         int controlHeight = this.ClientSize.Height;
         int borderHeight = controlHeight - (_borderThickness * 2);

         Point borderOffset = new Point(((this.ClientSize.Width - borderHeight) / 2), ((this.ClientSize.Height - borderHeight) / 2));
         Rectangle borderRect = new Rectangle(borderOffset.X, borderOffset.Y, borderHeight, borderHeight);

         e.Graphics.Clear(this.BackColor);

         e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

         // Draw Radion Button Background.
         e.Graphics.FillEllipse(new SolidBrush(_backgroundColor), borderRect);

         // Draw Radion Button Border.
         DrawControlBorder(e.Graphics, borderRect);

         // Draw Check Mark.
         if (this.Checked)
         {
            int checkMarkHeight = borderHeight / 2;
            Point checkMarkOffset = new Point(borderOffset.X + (checkMarkHeight / 2), borderOffset.Y + (checkMarkHeight / 2));
            Rectangle checkMarkRect = new Rectangle(checkMarkOffset.X, checkMarkOffset.Y, checkMarkHeight, checkMarkHeight);

            e.Graphics.FillEllipse(new SolidBrush(Color.Black), checkMarkRect);
         }
      }

      private void DrawControlBorder(Graphics graphics, Rectangle borderRect)
      {
         using (Pen borderPen = new Pen((_focus ? _focusedBorderColor : _borderColor), _borderThickness))
         {
            Rectangle insetBeveledRect = borderRect;
            insetBeveledRect.Inflate(-this._borderThickness, -this._borderThickness);

            insetBeveledRect.Width = insetBeveledRect.Width == 0 ? 1 : insetBeveledRect.Width;
            insetBeveledRect.Height = insetBeveledRect.Height == 0 ? 1 : insetBeveledRect.Height;

            switch (_fieldBorderStyle)
            {
               case FieldBorderStyle.Solid:
                  break;
               case FieldBorderStyle.Dashed:
                  float[] dashValues = { 1, 1 };
                  borderPen.DashPattern = dashValues;
                  break;
               case FieldBorderStyle.Beveled:
                  Color beveledColor = Color.FromArgb(_backgroundColor.A, (int)(_backgroundColor.R * 0.9), (int)(_backgroundColor.G * 0.9), (int)(_backgroundColor.B * 0.9));
                  graphics.DrawArc(new Pen(new SolidBrush(beveledColor), _borderThickness), insetBeveledRect, 315, 180);
                  graphics.DrawArc(new Pen(new SolidBrush(Color.White), _borderThickness), insetBeveledRect, 135, 180);
                  break;
               case FieldBorderStyle.Inset:
                  graphics.DrawArc(new Pen(new SolidBrush(Color.LightGray), _borderThickness), insetBeveledRect, 315, 180);
                  graphics.DrawArc(new Pen(new SolidBrush(Color.Gray), _borderThickness), insetBeveledRect, 135, 180);
                  break;
               case FieldBorderStyle.Underlined:
                  break;
            }

            graphics.DrawEllipse(borderPen, borderRect);
         }
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

      #region GroupName

      public string _groupName;
      public string GroupName
      {
         get
         {
            return _groupName;
         }
         set
         {
            _groupName = value;
         }
      }

      #endregion //GroupName

      #endregion //Properties

      public static Dictionary<string, List<PDFRadioButton>> RadioButtonGroups = new Dictionary<string, List<PDFRadioButton>>();
   }
}
