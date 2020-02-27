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

namespace MagnifyGlassDemo
{
   /// <summary>
   /// Summary description for ValueDialog.
   /// </summary>
   public class ValueDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
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
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._numericValue = new System.Windows.Forms.NumericUpDown();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numericValue)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(192, 48);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(192, 16);
         this._btnOk.Name = "_btnOk";
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
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
         this._numericValue.TabIndex = 0;
         this._numericValue.Leave += new System.EventHandler(this._numericValue_Leave);
         // 
         // ValueDialog
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(274, 80);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbOptions);
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
         Width,
         Height,
         Border,
         ScaleFactor,
      }

      private struct TypeProp
      {
         public TypeConstants Type;
         public string CaptionName;
         public string ValueName;
         public int Min;
         public int Max;

         public TypeProp(TypeConstants type, string captionName, string valueName, int min, int max)
         {
            Type = type;
            CaptionName = captionName;
            ValueName = valueName;
            Min = min;
            Max = max;
         }
      }

      private static TypeProp[] _typeProp = new TypeProp[]
      {
         new TypeProp(TypeConstants.Width,      "MagnifyGlass Width",  "Width",        100, 500),
         new TypeProp(TypeConstants.Height,     "MagnifyGlass Height", "Height",       100, 500),
         new TypeProp(TypeConstants.Border,     "MagnifyGlass Border", "Border Width", 1, 11),
         new TypeProp(TypeConstants.ScaleFactor, "Magnifying Scale Factor",   "Scale Factor",  1, 10)
      };

      private TypeConstants _type;

      public int Value;

      private void ValueDialog_Load(object sender, System.EventArgs e)
      {
         TypeProp prop = _typeProp[(int)_type];
         Text = prop.CaptionName;
         _gbOptions.Text = string.Format("{0} ({1}..{2})", prop.ValueName, prop.Min, prop.Max);
         _numericValue.Minimum = prop.Min;
         _numericValue.Maximum = prop.Max;

         DialogUtilities.SetNumericValue(_numericValue, Value);
      }

      private void _numericValue_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         int index = (int)_type;
         Value = (int)_numericValue.Value;
      }
   }
}
