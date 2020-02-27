// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.Demos;
using Leadtools.ImageProcessing;
//using Leadtools.ImageProcessing.Color;
//using Leadtools.ImageProcessing.Effects;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for ValueDialog.
   /// </summary>
   public class ValueDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.NumericUpDown _numericValue;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public ValueDialog(TypeConstants type)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         _type = type;
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._numericValue = new System.Windows.Forms.NumericUpDown();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numericValue)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(192, 16);
         this._btnOk.Name = "_btnOk";
         this._btnOk.TabIndex = 2;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(192, 48);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 3;
         this._btnCancel.Text = "Cancel";
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._numericValue);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptions.Location = new System.Drawing.Point(8, 8);
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.Size = new System.Drawing.Size(160, 64);
         this._gbOptions.TabIndex = 0;
         this._gbOptions.TabStop = false;
         this._gbOptions.Text = "Value";
         // 
         // _numericValue
         // 
         this._numericValue.Location = new System.Drawing.Point(16, 32);
         this._numericValue.Name = "_numericValue";
         this._numericValue.Size = new System.Drawing.Size(128, 20);
         this._numericValue.TabIndex = 1;
         this._numericValue.Leave += new System.EventHandler(this._num_Leave);
         // 
         // ValueDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(274, 79);
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ValueDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "ValueDialog";
         this.Load += new System.EventHandler(this.ValueDialog_Load);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numericValue)).EndInit();
         this.ResumeLayout(false);

      }
      #endregion

      public enum TypeConstants
      {
         ScaleFactor,
         PaintIntensity,
         PaintContrast,
         PaintGamma,
         AutoCrop,
         Average,
         Gaussian,
         Median,
         Mosaic,
         Oilify,
         Posterize,
         Sharpen,
         Min,
         Max,
         Contrast,
         GammaCorrect,
         HistoContrast,
         Hue,
         Intensity,
         Saturation,
         Solarize,
      }

      private struct TypeProp
      {
         public TypeConstants Type;
         public string CaptionName;
         public string ValueName;
         public int InitialValue;
         public bool ReadInitialValue;
         public int Min;
         public int Max;
         public int MultiplyBy;

         public TypeProp(TypeConstants type, string captionName, string valueName, int initialValue, bool readInitialValue, int min, int max, int multiplyBy)
         {
            Type = type;
            CaptionName = captionName;
            ValueName = valueName;
            InitialValue = initialValue;
            ReadInitialValue = readInitialValue;
            Min = min;
            Max = max;
            MultiplyBy = multiplyBy;
         }
      }

      private static TypeProp[] _typeProp = new TypeProp[]
      {
         new TypeProp(TypeConstants.ScaleFactor,      "Scale Factor (%)",        "Scale Factor",      0, true,       1,   1000,   1),
         new TypeProp(TypeConstants.PaintIntensity,   "Paint Intensity",         "Paint Intensity",   0, true,    -100,    100,  10),
         new TypeProp(TypeConstants.PaintContrast,    "Paint Contrast",          "Paint Contrast",    0, true,    -100,    100,  10),
         new TypeProp(TypeConstants.PaintGamma,       "Paint Gamma",             "Paint Gamma",       0, true,      10,    500,   1),
         new TypeProp(TypeConstants.AutoCrop,         "Auto Crop (Trim)",        "Threshold",         0, true,       0,    244,   1),
         new TypeProp(TypeConstants.Average,          "Average",                 "Dimension",         3, false,      3,    255,   1),
         new TypeProp(TypeConstants.Gaussian,         "Gaussian",                "Radius",            0, false,      1,   1000,   1),
         new TypeProp(TypeConstants.Median,           "Median",                  "Dimension",         2, false,      2,     64,   1),
         new TypeProp(TypeConstants.Mosaic,           "Mosaic",                  "Dimension",         2, false,      2,     64,   1),
         new TypeProp(TypeConstants.Oilify,           "Oilify",                  "Dimension",         2, false,      2,    255,   1),
         new TypeProp(TypeConstants.Posterize,        "Posterize",               "Levels",            2, false,      2,     64,   1),
         new TypeProp(TypeConstants.Sharpen,          "Sharpen",                 "Sharpness",         0, false,   -100,    100,  10),
         new TypeProp(TypeConstants.Min,              "Min Filter",              "Sample Size",       1, false,      1,     32,   1),
         new TypeProp(TypeConstants.Max,              "Max Filter",              "Sample Size",       1, false,      1,     32,   1),
         new TypeProp(TypeConstants.Contrast,         "Contrast",                "Contrast",          0, false,   -100,    100,  10),
         new TypeProp(TypeConstants.GammaCorrect,     "Gamma Correct",           "Gamma",            10, false,     10,    500,   1),
         new TypeProp(TypeConstants.HistoContrast,    "Histo Contrast",          "Contrast",          0, false,   -100,    100,  10),
         new TypeProp(TypeConstants.Hue,              "Hue",                     "Angle",             0, false,   -360,    360,   1),
         new TypeProp(TypeConstants.Intensity,        "Intensity (Brightness)",  "Brightness",        0, false,   -100,    100,  10),
         new TypeProp(TypeConstants.Saturation,       "Saturation",              "Change",            0, false,   -100,    100,  10),
         new TypeProp(TypeConstants.Solarize,         "Solarize",                "Threshold",         0, false,      0,    255,   1)
      };

      public int Value;

      private TypeConstants _type;

      private void ValueDialog_Load(object sender, System.EventArgs e)
      {
         TypeProp prop = _typeProp[(int)_type];
         Text = prop.CaptionName;
         _gbOptions.Text = prop.ValueName;
         _numericValue.Minimum = prop.Min;
         _numericValue.Maximum = prop.Max;
         if(prop.ReadInitialValue)
            prop.InitialValue = Value;
         else
            Value = prop.InitialValue;

         DialogUtilities.SetNumericValue(_numericValue, Value / prop.MultiplyBy);
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         int index = (int)_type;
         Value = (int)_numericValue.Value * _typeProp[index].MultiplyBy;
         _typeProp[index].InitialValue = Value;
      }
   }
}
