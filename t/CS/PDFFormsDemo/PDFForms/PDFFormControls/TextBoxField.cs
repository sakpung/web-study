// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Controls;
using Leadtools.Pdf;

namespace PDFFormsDemo
{
   public class TextFormField : FormFieldControl
   {
      public TextFormField()
      {
         _pdfTextBox = new PDFTextBox();
         this.SetChildControl(_pdfTextBox);
      }

      public override void InitControl(PDFFormField formField)
      {
         base.InitControl(formField);

         TextBox textBox = _pdfTextBox.TextBox;

         foreach (string content in formField.Contents)
         {
            textBox.Text += content;
         }

         textBox.Text = textBox.Text.Replace("\n", "\r\n");

         InitTextBoxControl(textBox, formField);

         SetTextJustification(textBox, formField.TextJustification);

         if (this._autoFontResize)
         {
            textBox.TextChanged += PDFTextBox_TextChanged;
         }
      }

      public override void SetToolTip(string toolTip)
      {
         if (FormFieldControl.FormFieldsToolTip != null)
         {
            FormFieldControl.FormFieldsToolTip.SetToolTip(_pdfTextBox.TextBox, toolTip);
         }

         base.SetToolTip(toolTip);
      }

      public override void SetContextMenuStrip()
      {
         base.SetContextMenuStrip();

         if (FormFieldControl.FormFieldsContextMenu != null)
         {
            TextBox textBox = _pdfTextBox.TextBox;
            textBox.Tag = this;

            textBox.ContextMenuStrip = FormFieldControl.FormFieldsContextMenu;
         }
      }

      public override void UpdateFormField(PDFFormField formField)
      {
         base.UpdateFormField(formField);

         TextBox textBox = _pdfTextBox.TextBox;

         formField.Contents.Clear();

         formField.Contents.Add(textBox.Text);

         switch (textBox.TextAlign)
         {
            case HorizontalAlignment.Center:
               formField.TextJustification = PDFFormField.TextJustificationCentered;
               break;
            case HorizontalAlignment.Left:
               formField.TextJustification = PDFFormField.TextJustificationLeft;
               break;
            case HorizontalAlignment.Right:
               formField.TextJustification = PDFFormField.TextJustificationRight;
               break;
         }

         if (textBox.Multiline)
            formField.FieldFlags |= PDFFormField.FieldFlagsTextMultiline;
      }

      protected override void DoFontResize()
      {
         TextBox textBox = _pdfTextBox.TextBox;

         float fontSize = CalculateFontSize(textBox.Text, textBox.Multiline);

         _pdfTextBox.Font = new Font(_font.FontFamily, fontSize);
      }

      protected override void OnPropertyChange()
      {
         this._pdfTextBox.TextBox.ReadOnly = _isReadOnly;

         base.OnPropertyChange();
      }

      private void PDFTextBox_TextChanged(object sender, EventArgs e)
      {
         DoFontResize();
      }

      private void InitTextBoxControl(TextBox textBox, PDFFormField formField)
      {
         bool TextDoNotScroll = (formField.FieldFlags & PDFFormField.FieldFlagsTextDoNotScroll) == PDFFormField.FieldFlagsTextDoNotScroll;
         bool TextDoNotSpellcheck = (formField.FieldFlags & PDFFormField.FieldFlagsTextDoNotSpellcheck) == PDFFormField.FieldFlagsTextDoNotSpellcheck;
         bool TextMultiline = (formField.FieldFlags & PDFFormField.FieldFlagsTextMultiline) == PDFFormField.FieldFlagsTextMultiline;

         if (TextDoNotScroll)
            textBox.ScrollBars = ScrollBars.None;
         else
            textBox.ScrollBars = ScrollBars.Both;

         if (TextMultiline)
            textBox.Multiline = true;
         else
            textBox.Multiline = false;
      }

      private void SetTextJustification(TextBox textBox, int textJustification)
      {
         switch (textJustification)
         {
            case PDFFormField.TextJustificationLeft:
               textBox.TextAlign = HorizontalAlignment.Left;
               break;

            case PDFFormField.TextJustificationCentered:
               textBox.TextAlign = HorizontalAlignment.Center;
               break;

            case PDFFormField.TextJustificationRight:
               textBox.TextAlign = HorizontalAlignment.Right;
               break;
         }
      }

      #region Properties

      #region PDFTextBox

      private PDFTextBox _pdfTextBox;
      public PDFTextBox PDFTextBox
      {
         get { return this._pdfTextBox; }
      }

      #endregion //PDFTextBox

      #endregion //Properties
   }

   public class PDFTextBox : Panel, IFormFieldControl
   {
      private bool _focus = false;

      public PDFTextBox()
      {
         _textBox = new TextBox();
         _textBox.AcceptsReturn = true;
         _textBox.AutoSize = false;
         _textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
         _textBox.Dock = System.Windows.Forms.DockStyle.Fill;
         _textBox.MouseEnter += PDFTextBox_MouseEnter;
         _textBox.MouseLeave += PDFTextBox_MouseLeave;
         _textBox.GotFocus += _textBox_GotFocus;

         this.Controls.Add(this._textBox);
         this.MouseEnter += PDFTextBox_MouseEnter;
         this.MouseLeave += PDFTextBox_MouseLeave;
         this.Paint += PDFTextBox_Paint;
      }

      private void _textBox_GotFocus(object sender, EventArgs e)
      {
         ImageViewer imageViewer = (this.Parent.Parent as ImageViewer);
         if (imageViewer != null)
         {
            imageViewer.UpdateTransform();
         }
      }

      private void PDFTextBox_MouseEnter(object sender, EventArgs e)
      {
         _focus = true;
         this.Invalidate();
      }

      private void PDFTextBox_MouseLeave(object sender, EventArgs e)
      {
         _focus = false;
         this.Invalidate();
      }

      private void PDFTextBox_Paint(object sender, PaintEventArgs e)
      {
         UpdateControl();

         // Draw TextBox Border.
         FormFieldControl.DrawBorder(e.Graphics, this, this.ClientSize, _focus);
      }

      private void UpdateControl()
      {
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

      #region Properties

      #region ForeColor

      public override Color ForeColor
      {
         get
         {
            return _textBox.ForeColor;
         }
         set
         {
            _textBox.ForeColor = value;
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
            _textBox.BackColor = this._backgroundColor;
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
            _textBox.Visible = value;
            _isFieldVisible = value;
         }
      }

      #endregion //IsFieldVisible

      #region TextBox

      private TextBox _textBox;
      public TextBox TextBox
      {
         get { return _textBox; }
      }

      #endregion //TextBox

      #endregion //Properties
   }
}
