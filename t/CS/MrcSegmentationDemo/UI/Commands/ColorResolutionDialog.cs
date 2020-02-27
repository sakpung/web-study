// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools;
using Leadtools.ImageProcessing;

namespace MrcSegmentationDemo
{
   /// <summary>
   /// Summary description for ColorResolutionDialog.
   /// </summary>
   public class ColorResolutionDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.GroupBox _grbOptions;
      private System.Windows.Forms.ComboBox _cbDither;
      private System.Windows.Forms.Label _lblDither;
      private System.Windows.Forms.ComboBox _cbBitsPerPixel;
      private System.Windows.Forms.Label _lblBitsPerPixel;
      private System.Windows.Forms.ComboBox _cbOrder;
      private System.Windows.Forms.Label _lblOrder;
      private System.Windows.Forms.ComboBox _cbPalette;
      private System.Windows.Forms.Label _lblPalette;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public ColorResolutionDialog()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._grbOptions = new System.Windows.Forms.GroupBox();
         this._cbOrder = new System.Windows.Forms.ComboBox();
         this._lblOrder = new System.Windows.Forms.Label();
         this._cbDither = new System.Windows.Forms.ComboBox();
         this._lblDither = new System.Windows.Forms.Label();
         this._cbPalette = new System.Windows.Forms.ComboBox();
         this._lblPalette = new System.Windows.Forms.Label();
         this._cbBitsPerPixel = new System.Windows.Forms.ComboBox();
         this._lblBitsPerPixel = new System.Windows.Forms.Label();
         this._grbOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(344, 16);
         this._btnOk.Name = "_btnOk";
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "&OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(344, 48);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "&Cancel";
         // 
         // _grbOptions
         // 
         this._grbOptions.Controls.Add(this._cbOrder);
         this._grbOptions.Controls.Add(this._lblOrder);
         this._grbOptions.Controls.Add(this._cbDither);
         this._grbOptions.Controls.Add(this._lblDither);
         this._grbOptions.Controls.Add(this._cbPalette);
         this._grbOptions.Controls.Add(this._lblPalette);
         this._grbOptions.Controls.Add(this._cbBitsPerPixel);
         this._grbOptions.Controls.Add(this._lblBitsPerPixel);
         this._grbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._grbOptions.Location = new System.Drawing.Point(8, 8);
         this._grbOptions.Name = "_grbOptions";
         this._grbOptions.Size = new System.Drawing.Size(320, 160);
         this._grbOptions.TabIndex = 0;
         this._grbOptions.TabStop = false;
         // 
         // _cbOrder
         // 
         this._cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbOrder.Location = new System.Drawing.Point(120, 56);
         this._cbOrder.Name = "_cbOrder";
         this._cbOrder.Size = new System.Drawing.Size(184, 21);
         this._cbOrder.TabIndex = 3;
         // 
         // _lblOrder
         // 
         this._lblOrder.Location = new System.Drawing.Point(16, 56);
         this._lblOrder.Name = "_lblOrder";
         this._lblOrder.Size = new System.Drawing.Size(96, 24);
         this._lblOrder.TabIndex = 2;
         this._lblOrder.Text = "&Order:";
         this._lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _cbDither
         // 
         this._cbDither.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbDither.Location = new System.Drawing.Point(120, 120);
         this._cbDither.Name = "_cbDither";
         this._cbDither.Size = new System.Drawing.Size(184, 21);
         this._cbDither.TabIndex = 8;
         // 
         // _lblDither
         // 
         this._lblDither.Location = new System.Drawing.Point(16, 120);
         this._lblDither.Name = "_lblDither";
         this._lblDither.Size = new System.Drawing.Size(96, 24);
         this._lblDither.TabIndex = 7;
         this._lblDither.Text = "&Dither:";
         this._lblDither.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _cbPalette
         // 
         this._cbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbPalette.ItemHeight = 13;
         this._cbPalette.Location = new System.Drawing.Point(120, 88);
         this._cbPalette.Name = "_cbPalette";
         this._cbPalette.Size = new System.Drawing.Size(184, 21);
         this._cbPalette.TabIndex = 5;
         // 
         // _lblPalette
         // 
         this._lblPalette.Location = new System.Drawing.Point(16, 88);
         this._lblPalette.Name = "_lblPalette";
         this._lblPalette.Size = new System.Drawing.Size(96, 24);
         this._lblPalette.TabIndex = 4;
         this._lblPalette.Text = "&Palette:";
         this._lblPalette.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _cbBitsPerPixel
         // 
         this._cbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbBitsPerPixel.Location = new System.Drawing.Point(120, 24);
         this._cbBitsPerPixel.Name = "_cbBitsPerPixel";
         this._cbBitsPerPixel.Size = new System.Drawing.Size(184, 21);
         this._cbBitsPerPixel.TabIndex = 1;
         this._cbBitsPerPixel.SelectedIndexChanged += new System.EventHandler(this._cbBitsPerPixel_SelectedIndexChanged);
         // 
         // _lblBitsPerPixel
         // 
         this._lblBitsPerPixel.Location = new System.Drawing.Point(16, 24);
         this._lblBitsPerPixel.Name = "_lblBitsPerPixel";
         this._lblBitsPerPixel.Size = new System.Drawing.Size(96, 24);
         this._lblBitsPerPixel.TabIndex = 0;
         this._lblBitsPerPixel.Text = "&Bits Per Pixel:";
         this._lblBitsPerPixel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // ColorResolutionDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(426, 176);
         this.Controls.Add(this._grbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ColorResolutionDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Color Resolution";
         this.Load += new System.EventHandler(this.ColorResolutionDialog_Load);
         this._grbOptions.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      private static int _initialBitsPerPixel = 24;
      private static RasterByteOrder _initialOrder = RasterByteOrder.Bgr;
      private static ColorResolutionCommandPaletteFlags _initialPaletteFlags = ColorResolutionCommandPaletteFlags.Optimized;
      private static RasterDitheringMethod _initialDitheringMethod = RasterDitheringMethod.None;

      public int BitsPerPixel = -1;
      public RasterByteOrder Order;
      public ColorResolutionCommandPaletteFlags PaletteFlags;
      public RasterDitheringMethod DitheringMethod;

      private enum MyPaletteType
      {
         Fixed = ColorResolutionCommandPaletteFlags.Fixed,
         Optimized = ColorResolutionCommandPaletteFlags.Optimized,
         Identity = ColorResolutionCommandPaletteFlags.Identity,
         Netscape = ColorResolutionCommandPaletteFlags.Netscape
      }

      private void ColorResolutionDialog_Load(object sender, System.EventArgs e)
      {
         if(BitsPerPixel == -1)
            BitsPerPixel = _initialBitsPerPixel;

         PaletteFlags = _initialPaletteFlags;
         DitheringMethod = _initialDitheringMethod;

         int[] bitsPerPixel = { 1, 2, 3, 4, 5, 6, 7, 8, 12, 16, 24, 32, 48, 64 };
         foreach(int i in bitsPerPixel)
         {
            _cbBitsPerPixel.Items.Add(i);
            if(BitsPerPixel == i)
               _cbBitsPerPixel.SelectedItem = i;
         }

         Array a = Enum.GetValues(typeof(MyPaletteType));
         foreach(MyPaletteType i in a)
         {
            _cbPalette.Items.Add(i);
            if((int)PaletteFlags == (int)i)
               _cbPalette.SelectedItem = i;
         }

         if(_cbPalette.SelectedItem == null)
            _cbPalette.SelectedIndex = 0;

         Tools.FillComboBoxWithEnum(_cbDither, typeof(RasterDitheringMethod), DitheringMethod);

         UpdateMyControls();
      }

      private void UpdateMyControls()
      {
         int bitsPerPixel = (int)_cbBitsPerPixel.SelectedItem;
         _cbPalette.Enabled = bitsPerPixel <= 8;
         _cbDither.Enabled = bitsPerPixel <= 8;

         if(bitsPerPixel <= 8)
         {
            _cbOrder.Items.Clear();
            _cbOrder.Items.Add(Constants.GetNameFromValue(typeof(RasterByteOrder), RasterByteOrder.Rgb));
            _cbOrder.SelectedIndex = 0;
            _cbOrder.Enabled = false;

            if(_cbPalette.Enabled)
            {
               MyPaletteType selectedPalette;
               if(_cbPalette.SelectedItem != null)
                  selectedPalette = (MyPaletteType)_cbPalette.SelectedItem;
               else
                  selectedPalette = MyPaletteType.Fixed;

               _cbPalette.Items.Clear();

               Array a = Enum.GetValues(typeof(MyPaletteType));
               foreach(MyPaletteType i in a)
               {
                  if(bitsPerPixel == 8 || i != MyPaletteType.Netscape)
                  {
                     _cbPalette.Items.Add(i);
                     if(i == selectedPalette)
                        _cbPalette.SelectedItem = i;
                  }
               }

               if(_cbPalette.SelectedItem == null)
                  _cbPalette.SelectedIndex = 0;
            }
         }
         else if(bitsPerPixel == 12)
         {
            _cbOrder.Items.Clear();
            _cbOrder.Items.Add(Constants.GetNameFromValue(typeof(RasterByteOrder), RasterByteOrder.Gray));
            _cbOrder.SelectedIndex = 0;
            _cbOrder.Enabled = false;
         }
         else if(bitsPerPixel == 16)
         {
            _cbOrder.Items.Clear();
            Tools.FillComboBoxWithEnum(_cbOrder, typeof(RasterByteOrder), Order, new object[] { RasterByteOrder.Romm });
            if(_cbOrder.SelectedItem == null)
               _cbOrder.SelectedItem = RasterByteOrder.Bgr;
            _cbOrder.Enabled = true;
         }
         else
         {
            _cbOrder.Items.Clear();
            Tools.FillComboBoxWithEnum(_cbOrder, typeof(RasterByteOrder), Order, new object[] { RasterByteOrder.Gray, RasterByteOrder.Romm });
            if(_cbOrder.SelectedItem == null)
               _cbOrder.SelectedItem = RasterByteOrder.Bgr;
            _cbOrder.Enabled = true;

         }
      }

      private void _cbBitsPerPixel_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         UpdateMyControls();
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         BitsPerPixel = (int)_cbBitsPerPixel.SelectedItem;
         Order = (RasterByteOrder)Constants.GetValueFromName(
            typeof(RasterByteOrder),
            (string)_cbOrder.SelectedItem,
            _initialOrder);
         PaletteFlags = ColorResolutionCommandPaletteFlags.None;
         MyPaletteType myPalette = (MyPaletteType)_cbPalette.SelectedItem;
         switch(myPalette)
         {
            case MyPaletteType.Fixed:     PaletteFlags |= ColorResolutionCommandPaletteFlags.Fixed; break;
            case MyPaletteType.Optimized: PaletteFlags |= ColorResolutionCommandPaletteFlags.Optimized; break;
            case MyPaletteType.Identity:  PaletteFlags |= ColorResolutionCommandPaletteFlags.Identity; break;
            case MyPaletteType.Netscape:  PaletteFlags |= ColorResolutionCommandPaletteFlags.Netscape; break;
         }

         DitheringMethod = (RasterDitheringMethod)Constants.GetValueFromName(
            typeof(RasterDitheringMethod),
            (string)_cbDither.SelectedItem,
            _initialDitheringMethod);

         _initialBitsPerPixel = BitsPerPixel;
         _initialOrder = Order;
         _initialPaletteFlags = PaletteFlags;
         _initialDitheringMethod = DitheringMethod;
      }
   }
}
