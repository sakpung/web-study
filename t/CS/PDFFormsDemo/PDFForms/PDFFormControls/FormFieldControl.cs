// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Pdf;

namespace PDFFormsDemo
{
   public abstract class FormFieldControl : Control
   {
      public static ContextMenuStrip FormFieldsContextMenu = null;
      public static ToolTip FormFieldsToolTip = null;
      public static int MaxFontSize = 18;

      public FormFieldControl()
      {
         this.SizeChanged += FormFieldControl_SizeChanged;
         this.Invalidated += FormFieldControl_Invalidated;
      }

      private void FormFieldControl_SizeChanged(object sender, EventArgs e)
      {
         DoFontResize();

         this.Invalidate();
      }

      private void FormFieldControl_Invalidated(object sender, InvalidateEventArgs e)
      {
         if (_childControl != null)
         {
            _childControl.Refresh();
            _childControl.Invalidate();
         }
      }

      protected void SetChildControl(Control childControl)
      {
         _childControl = childControl;
         _childControl.Dock = DockStyle.Fill;

         this.Controls.Add(_childControl);
      }

      public virtual void InitControl(PDFFormField formField)
      {
         this.PDFFormField = formField;

         // Set common form field controls properties
         this._fieldName = formField.Name;
         this._alternateName = formField.AlternateName;
         this._optionalName = formField.OptionalName;
         this._mappingName = formField.MappingName;
         this._fillMode = formField.FillMode;

         // Set Form Field Control Bounds.
         PDFFormControlsPropertiesHelper.SetControlBounds(this, formField.Bounds, DocResolution);

         // Set Form Field Control Font size, family name, and color.
         PDFFormControlsPropertiesHelper.SetControlFont(this, formField.FontName, formField.FontSize, formField.TextColor);

         // Set Form Field Control Border width, color, and style.
         PDFFormControlsPropertiesHelper.SetControlBorder(this, formField.BorderColor, formField.BorderWidth, formField.BorderStyle);

         // Set Form Field Control Background brush.
         PDFFormControlsPropertiesHelper.SetControlBackground(this, formField.FillColor, formField.FillMode);

         // Set Form Field Control Visibility flag.
         PDFFormControlsPropertiesHelper.SetControlFlagsProperties(this, formField.ViewFlags, formField.FieldFlags);

         // Set Form Field Control Rotate Angle.
         this.RotateAngle = formField.Rotation;

         // Set Form Field Control Tooltip.
         this.SetToolTip(formField.AlternateName);

         // Set Form Field Control Tooltip.
         this.SetContextMenuStrip();
      }

      public virtual void SetToolTip(string toolTip)
      {
         this._alternateName = toolTip;
      }

      public virtual void SetContextMenuStrip()
      {
         if (FormFieldControl.FormFieldsContextMenu != null)
         {
            this.ContextMenuStrip = FormFieldControl.FormFieldsContextMenu;
            this.Tag = this;
         }
      }

      protected float CalculateFontSize(string text, bool multiLine)
      {
         float fontSize = _font.Size;

         if (!_autoFontResize)
         {
            if (this.Height != 0 && this.FiedlBounds.Height != 0)
            {
               fontSize = fontSize * ((float)this.Height / (float)this.FiedlBounds.Height);
            }
         }
         else
         {
            Size stringSize = TextRenderer.MeasureText(text, _font);
            float wRatio = (float)this.Width / (float)stringSize.Width;
            float hRatio = (float)this.Height / (float)stringSize.Height;

            float ratio = multiLine ? hRatio : Math.Min(hRatio, wRatio);

            if (ratio != 0 && !float.IsInfinity(ratio) && !float.IsNaN(ratio))
            {
               fontSize = fontSize * ratio;

               if (fontSize > 24)
                  fontSize = 24;
            }
         }

         return fontSize;
      }

      public virtual void UpdateFormField(PDFFormField formField)
      {
         // Set Names Properties
         formField.Name = _fieldName;
         formField.AlternateName = _alternateName;

         // Set View Flags Property
         formField.ViewFlags = 0;
         if (!_isFieldVisible && !_isFieldPrintable)
         {
            formField.ViewFlags |= PDFFormField.ViewFlagsHidden;
         }
         else
         {
            if (_isFieldPrintable)
               formField.ViewFlags |= PDFFormField.ViewFlagsPrint;

            if (!_isFieldVisible)
               formField.ViewFlags |= PDFFormField.ViewFlagsNoView;
         }

         if (_isFieldLocked)
            formField.ViewFlags |= PDFFormField.ViewFlagsLocked;

         if (!_isFieldRotatable)
            formField.ViewFlags |= PDFFormField.ViewFlagsNoRotate;

         // Set Rotation Properties
         formField.Rotation = _rotateAngle;

         // Set Border Properties
         Color borderColor = _borderColor;
         formField.BorderColor = new RasterColor(borderColor.A, borderColor.R, borderColor.G, borderColor.B);
         formField.BorderWidth = _borderThickness;
         formField.BorderStyle = (int)_fieldBorderStyle;

         // Set background Property
         Color fillColor = BackgroundColor;
         formField.FillColor = new RasterColor(fillColor.A, fillColor.R, fillColor.G, fillColor.B);
         formField.FillMode = _fillMode;

         // Set font Properties
         Color textColor = this.ForeColor;
         formField.TextColor = new RasterColor(textColor.A, textColor.R, textColor.G, textColor.B);
         formField.FontSize = (int)this.Font.Size;
         formField.FontName = this.Font.FontFamily.Name;

         // Set ReadOnly Property
         formField.FieldFlags = 0;
         if (this.IsReadOnly)
            formField.FieldFlags |= PDFFormField.FieldFlagsReadOnly;

         this.PDFFormField = formField;
      }

      protected virtual void DoFontResize()
      {
         float fontSize = CalculateFontSize("Mg", false);

         if (this.Font.Size != fontSize)
         {
            _childControl.Font = new Font(_font.FontFamily, fontSize);
         }
      }

      protected virtual void OnPropertyChange()
      {
         if (_childControl != null)
         {
            _childControl.ForeColor = this.ForeColor;
            _childControl.BackColor = this.BackColor;

            (_childControl as IFormFieldControl).BackgroundColor = this.BackgroundColor;
            (_childControl as IFormFieldControl).BorderColor = this.BorderColor;
            (_childControl as IFormFieldControl).BorderThickness = this.BorderThickness;
            (_childControl as IFormFieldControl).FieldBorderStyle = this.FieldBorderStyle;
            (_childControl as IFormFieldControl).IsFieldVisible = this.IsFieldVisible;

            DoFontResize();
         }

         this.Invalidate();
      }

      #region Properties

      #region ChildControl

      protected Control _childControl;
      public Control ChildControl
      {
         get { return _childControl; }
      }

      #endregion //ChildControl

      #region FieldName

      private string _fieldName = "";
      public string FieldName
      {
         get { return _fieldName; }
         set { _fieldName = value; }
      }

      #endregion //FieldName

      #region AlternateName

      private string _alternateName = "";
      public string AlternateName
      {
         get { return _alternateName; }
      }

      #endregion //AlternateName

      #region OptionalName

      private string _optionalName = "";
      public string OptionalName
      {
         get { return _optionalName; }
      }

      #endregion //OptionalName

      #region MappingName

      private string _mappingName = "";
      public string MappingName
      {
         get { return _mappingName; }
      }

      #endregion //MappingName

      #region FiedlBounds

      protected LeadRect _fiedlBounds = LeadRect.Empty;
      public virtual LeadRect FiedlBounds
      {
         get
         {
            return _fiedlBounds;
         }
         set
         {
            if (_fiedlBounds != value)
            {
               _fiedlBounds = value;

               this.Left = value.Left;
               this.Top = value.Top;
               this.Width = value.Width;
               this.Height = value.Height;

               OnPropertyChange();
            }
         }
      }

      #endregion //FiedlBounds

      #region DocResolution

      public int DocResolution { get; set; }

      #endregion //DocResolution

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
            if (_isFieldVisible != value)
            {
               _isFieldVisible = value;
               OnPropertyChange();
            }
         }
      }

      #endregion //IsFieldVisible

      #region IsFieldPrintable

      private bool _isFieldPrintable = true;
      public bool IsFieldPrintable
      {
         get
         {
            return _isFieldPrintable;
         }
         set
         {
            _isFieldPrintable = value;
         }
      }

      #endregion //IsFieldPrintable

      #region IsFieldLocked

      private bool _isFieldLocked = true;
      public bool IsFieldLocked
      {
         get
         {
            return _isFieldLocked;
         }
         set
         {
            _isFieldLocked = value;
         }
      }

      #endregion //IsFieldLocked

      #region IsReadOnly

      protected bool _isReadOnly = true;
      public bool IsReadOnly
      {
         get
         {
            return _isReadOnly;
         }
         set
         {
            _isReadOnly = value;
            OnPropertyChange();
         }
      }

      #endregion //IsReadOnly

      #region IsFieldRotatable

      private bool _isFieldRotatable = true;
      public bool IsFieldRotatable
      {
         get
         {
            return _isFieldRotatable;
         }
         set
         {
            _isFieldRotatable = value;
         }
      }

      #endregion //IsFieldRotatable

      #region RotateAngle

      private int _rotateAngle = 0;
      public int RotateAngle
      {
         get
         {
            return _rotateAngle;
         }
         set
         {
            if (_rotateAngle != value)
            {
               _rotateAngle = value;
               OnPropertyChange();
            }
         }
      }

      #endregion //RotateAngle

      #region Font

      protected Font _font = new Font("Arial", FormFieldControl.MaxFontSize);
      public override Font Font
      {
         get
         {
            return _font;
         }
         set
         {
            if (_font != value)
            {
               _font = value;
               OnPropertyChange();
            }
         }
      }

      #endregion //Font

      #region AutoFontResize

      protected bool _autoFontResize = false;
      public bool AutoFontResize
      {
         get
         {
            return _autoFontResize;
         }
         set
         {
            if (_autoFontResize != value)
            {
               _autoFontResize = value;
               OnPropertyChange();
            }
         }
      }

      #endregion //AutoFontResize

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
            if (_backgroundColor != value)
            {
               _backgroundColor = value;
               OnPropertyChange();
            }
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
            if (_borderColor != value)
            {
               _borderColor = value;
               OnPropertyChange();
            }
         }
      }

      #endregion //BorderColor

      #region BorderThickness

      protected int _borderThickness = 1;
      public int BorderThickness
      {
         get
         {
            return _borderThickness;
         }
         set
         {
            if (_borderThickness != value)
            {
               _borderThickness = value;
               OnPropertyChange();
            }
         }
      }

      #endregion //BorderThickness

      #region FieldBorderStyle

      protected FieldBorderStyle _fieldBorderStyle = FieldBorderStyle.Solid;
      public FieldBorderStyle FieldBorderStyle
      {
         get { return _fieldBorderStyle; }
         set
         {
            if (_fieldBorderStyle != value)
            {
               _fieldBorderStyle = value;
               OnPropertyChange();
            }
         }
      }

      #endregion //FieldBorderStyle

      #region PDFFormField

      [System.ComponentModel.DefaultValue(null)]
      public PDFFormField PDFFormField
      {
         get;
         set;
      }

      #endregion //PDFFormField

      #region ForeColor

      public override Color ForeColor
      {
         get
         {
            return base.ForeColor;
         }
         set
         {
            base.ForeColor = value;
            OnPropertyChange();
         }
      }

      #endregion //ForeColor

      #region FillMode

      private int _fillMode;
      public int FillMode
      {
         get { return _fillMode; }
         set { _fillMode = value; }
      }

      #endregion //FillMode

      #endregion //Properties

      public static void DrawBorder(Graphics graphics, IFormFieldControl formFieldChild, Size clientSize, bool focus)
      {
         if (formFieldChild == null || !formFieldChild.IsFieldVisible)
            return;

         Rectangle borderRect = new Rectangle(0, 0, clientSize.Width, clientSize.Height);

         Rectangle innerRect = new Rectangle(
            formFieldChild.BorderThickness,
            formFieldChild.BorderThickness,
            clientSize.Width - (formFieldChild.BorderThickness * 2),
            clientSize.Height - (formFieldChild.BorderThickness * 2)
            );

         ButtonBorderStyle mainBoderStyle = ButtonBorderStyle.Solid;

         ButtonBorderStyle innerBoderTopLeftStyle = ButtonBorderStyle.Solid;
         ButtonBorderStyle innerBoderBottomRightStyle = ButtonBorderStyle.Solid;

         Color innerBoderTopLeftColor = Color.DarkGray;
         Color innerBoderBottomRightColor = Color.LightGray;

         switch (formFieldChild.FieldBorderStyle)
         {
            case FieldBorderStyle.Solid:
               mainBoderStyle = ButtonBorderStyle.Solid;
               innerBoderTopLeftStyle = ButtonBorderStyle.None;
               innerBoderBottomRightStyle = ButtonBorderStyle.None;
               break;
            case FieldBorderStyle.Dashed:
               mainBoderStyle = ButtonBorderStyle.Dotted;
               innerBoderTopLeftStyle = ButtonBorderStyle.None;
               innerBoderBottomRightStyle = ButtonBorderStyle.None;
               break;
            case FieldBorderStyle.Beveled:
               mainBoderStyle = ButtonBorderStyle.Solid;
               innerBoderTopLeftStyle = ButtonBorderStyle.Solid;
               innerBoderBottomRightStyle = ButtonBorderStyle.Solid;

               innerBoderTopLeftColor = Color.White;
               innerBoderBottomRightColor = Color.FromArgb(
                  formFieldChild.BackgroundColor.A,
                  (int)(formFieldChild.BackgroundColor.R * 0.9),
                  (int)(formFieldChild.BackgroundColor.G * 0.9),
                  (int)(formFieldChild.BackgroundColor.B * 0.9)
                  );
               break;
            case FieldBorderStyle.Inset:
               mainBoderStyle = ButtonBorderStyle.Solid;
               innerBoderTopLeftStyle = ButtonBorderStyle.Solid;
               innerBoderBottomRightStyle = ButtonBorderStyle.Inset;
               break;
            case FieldBorderStyle.Underlined:
               mainBoderStyle = ButtonBorderStyle.Solid;
               innerBoderTopLeftStyle = ButtonBorderStyle.None;
               innerBoderBottomRightStyle = ButtonBorderStyle.None;
               break;
         }

         ControlPaint.DrawBorder(graphics, borderRect,
            focus ? formFieldChild.FocusedBorderColor : formFieldChild.BorderColor, formFieldChild.BorderThickness, mainBoderStyle,                               //Left
            focus ? formFieldChild.FocusedBorderColor : formFieldChild.BorderColor, formFieldChild.BorderThickness, mainBoderStyle,                               //Top
            focus ? formFieldChild.FocusedBorderColor : formFieldChild.BorderColor, formFieldChild.BorderThickness, mainBoderStyle,                               //Right
            focus ? formFieldChild.FocusedBorderColor : formFieldChild.BorderColor, formFieldChild.BorderThickness, mainBoderStyle                                //Bottom
            );

         ControlPaint.DrawBorder(graphics, innerRect,
            innerBoderTopLeftColor, formFieldChild.BorderThickness, innerBoderTopLeftStyle,                                                                       //Left
            innerBoderTopLeftColor, formFieldChild.BorderThickness, innerBoderTopLeftStyle,                                                                       //Top
            innerBoderBottomRightColor, formFieldChild.BorderThickness, innerBoderBottomRightStyle,                                                               //Right
            innerBoderBottomRightColor, formFieldChild.BorderThickness, innerBoderBottomRightStyle                                                                //Bottom
            );
      }
   }

   public enum FieldBorderStyle
   {
      Solid,
      Dashed,
      Beveled,
      Inset,
      Underlined,
   }

   public interface IFormFieldControl
   {
      Color BackgroundColor { get; set; }
      Color BorderColor { get; set; }
      int BorderThickness { get; set; }
      Color FocusedBorderColor { get; }
      FieldBorderStyle FieldBorderStyle { get; set; }
      bool IsFieldVisible { get; set; }
   }

   public interface IFormFieldList
   {
      List<string> Items { get; set; }
      int SelectedIndex { get; set; }
      List<int> SelectedIndices { get; set; }
      bool IsSorted { get; set; }
      void Sort();
   }
}
