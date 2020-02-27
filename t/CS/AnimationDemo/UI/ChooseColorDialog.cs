// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools;

namespace AnimationDemo
{
   public partial class ChooseColorDialog : Form
   {
      RasterImage _image;
      Size _itemSize = new Size(24, 12);
      int _horzspace = 5;
      int _vertSpace = 5;
      Point _startLocation = new Point(10, 15);
      Color _selectedColor;
      bool _enableChangeColor = true;

      public ChooseColorDialog(RasterImage image, bool enableChangeColor)
      {
         InitializeComponent();
         _image = image;
         _enableChangeColor = enableChangeColor;
      }

      private void ColorDialog_Load(object sender, EventArgs e)
      {
         RasterColor [] colors = _image.GetPalette();
         int colorsCount = colors.Length;

         int vertSpace = 10;
         int horzSpace = 20;

         _gpBitmapColors.Height = (colorsCount > 16 ? colorsCount/ 16 : 1) * (_itemSize.Height + _vertSpace)+ _startLocation.Y + _vertSpace;
         _gpBitmapColors.Width = (_itemSize.Width + _horzspace) * 16;

         //Adjust Current Color group box.
         _gpCurrentColor.Top = _gpBitmapColors.Bottom + vertSpace;

         // Adjust OK & Cancel buttons;
         _btnOK.Top = _gpCurrentColor.Top;
         _btnOK.Left = _gpBitmapColors.Right - _btnOK.Width + _startLocation.X + _horzspace;

         _btnCancel.Top = _btnOK.Bottom + vertSpace;
         _btnCancel.Left = _btnOK.Left;

         _gpCurrentColor.Width = _btnOK.Left - vertSpace - _gpCurrentColor.Left;

         for (int i = 0; i < colorsCount; ++i)
         {
            Point pt = Point.Empty;

            pt.X= i * (_itemSize.Width + _horzspace) % _gpBitmapColors.Width;
            pt.Y = ((i * (_itemSize.Width + _horzspace)) / _gpBitmapColors.Width) * (_itemSize.Height + _vertSpace);

            pt.X += _startLocation.X;
            pt.Y += _startLocation.Y;

            Panel panel = CreateLabel(pt, Leadtools.Demos.Converters.ToGdiPlusColor(colors[i]));
            panel.Tag = i;
            this._gpBitmapColors.Controls.Add(panel);
         }

         _gpBitmapColors.Width += _startLocation.X + _horzspace;
         _gpRGB.Left = _gpCurrentColor.Right - _gpRGB.Width - horzSpace;

         //Adjust Color Dialog form.
         this.Size = new Size( _gpBitmapColors.Right + horzSpace, _gpCurrentColor.Bottom + vertSpace +20);
      }

      Panel CreateLabel(Point location, Color color)
      {
         Panel label = new Panel();
         label.Size = _itemSize;
         label.BackColor = color;
         label.Location = location;
         label.Text = "";
         label.BorderStyle = BorderStyle.FixedSingle;
         label.Click += new EventHandler(label_Click);
         label.DoubleClick += new EventHandler(label_DoubleClick);

         return label;
      }

      void label_DoubleClick(object sender, EventArgs e)
      {
         RasterColor color = new RasterColor();
         if (Tools.ShowColorDialog(this, ref color) == true)
         {
            Panel panel = sender as Panel;
            if (panel != null)
            {
               panel.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(color);
               panel1.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(color);
            }
         }
      }

      void label_Click(object sender, EventArgs e)
      {
         panel1.BackColor = (sender as Panel).BackColor;
         _txtRed.Text = panel1.BackColor.R.ToString();
         _txtGreen.Text = panel1.BackColor.G.ToString();
         _txtBlue.Text = panel1.BackColor.B.ToString();
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         SelectedColor = panel1.BackColor;
         if (_enableChangeColor)
         {
            RasterColor[] colors = new RasterColor[this._gpBitmapColors.Controls.Count];
            for(int i =0; i < this._gpBitmapColors.Controls.Count; ++i)
            {
               colors[i] = Leadtools.Demos.Converters.FromGdiPlusColor(this._gpBitmapColors.Controls[i].BackColor);
            }

            _image.SetPalette(colors, 0, this._gpBitmapColors.Controls.Count);
         }
      }

      public Color SelectedColor
      {
         get
         {
            return _selectedColor;
         }
         set
         {
            _selectedColor = panel1.BackColor;
         }
      }
   }
}
