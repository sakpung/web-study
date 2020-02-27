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
using Leadtools.Demos;

namespace MainDemo
{
   public partial class PaletteDialog : Form
   {
      public RasterColor[] Palette;

      private const int _gridWidth = 24;
      private const int _gridHeight = 24;
      private const int _minWidth = 200;
      private const int _minHeight = 200;

      public PaletteDialog( )
      {
         InitializeComponent();
      }

      private void PaletteDialog_Load(object sender, System.EventArgs e)
      {
         _lblPaletteInfo.Text = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_Count") + " {0}", Palette.Length);

         int xGrids = 16;
         int yGrids = Math.Max(1, Palette.Length / 16);

         SuspendLayout();

         _pnlPalette.Size = new Size(
            xGrids * _gridWidth + SystemInformation.Border3DSize.Width * 2,
            yGrids * _gridHeight + SystemInformation.Border3DSize.Height * 2);

         int d = _lblPaletteInfo.Top;
         ClientSize = new Size(
            Math.Max(d * 2 + _pnlPalette.Width, _minWidth),
            Math.Max(d * 5 + _pnlPalette.Height + _lblPaletteInfo.Height * 2 + _btnClose.Height, _minHeight));
         _lblPaletteInfo.Bounds = new Rectangle(d, d, ClientSize.Width - d * 2, _lblPaletteInfo.Height);
         _lblCurrentColor.Bounds = new Rectangle(d, _lblPaletteInfo.Bottom + d, _lblPaletteInfo.Width, _lblCurrentColor.Height);
         _pnlPalette.Location = new Point((ClientSize.Width - _pnlPalette.Width) / 2, _lblCurrentColor.Bottom + d);
         _btnClose.Location = new Point((ClientSize.Width - _btnClose.Width) / 2, _pnlPalette.Bottom + d);

         ResumeLayout();
      }

      private void _pnlPalette_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         Graphics g = e.Graphics;

         for(int i = 0; i < Palette.Length; i++)
         {
            Rectangle rc = GetColorRectangle(i);

            g.DrawRectangle(Pens.Black, rc);
            rc.Inflate(-1, -1);

            Color color = Converters.ToGdiPlusColor(Palette[i]);
            using(Brush brush = new SolidBrush(color))
               g.FillRectangle(brush, rc);
         }
      }

      private Rectangle GetColorRectangle(int index)
      {
         int xGrids = Palette.Length % 16;
         if(xGrids == 0)
            xGrids = 16;
         int yGrids = Math.Max(1, Palette.Length / 16);

         int x = index % xGrids;
         int y = index / 16;

         return new Rectangle(
            (_pnlPalette.ClientSize.Width - xGrids * _gridWidth) / 2 + x * _gridWidth,
            (_pnlPalette.ClientSize.Height - yGrids * _gridHeight) / 2 + y * _gridHeight,
            _gridWidth,
            _gridHeight);
      }

      private void _pnlPalette_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         for(int i = 0; i < Palette.Length; i++)
         {
            if(GetColorRectangle(i).Contains(e.X, e.Y))
            {
               RasterColor color = Palette[i];
               _lblCurrentColor.BackColor = Converters.ToGdiPlusColor(color);
               Color foreColor = Color.FromArgb(
                  (byte)((color.R + 128) % 256),
                  (byte)((color.G + 128) % 256),
                  (byte)((color.B + 128) % 256));
               _lblCurrentColor.ForeColor = foreColor;
               _lblCurrentColor.Text = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_Index") + " = {0} : {1}", i, color.ToString());
               return;
            }
         }

         if(_lblCurrentColor.BackColor != SystemColors.Control)
            _lblCurrentColor.BackColor = SystemColors.Control;
         if(_lblCurrentColor.ForeColor != SystemColors.ControlText)
            _lblCurrentColor.BackColor = SystemColors.ControlText;
         if(_lblCurrentColor.Text != string.Empty)
            _lblCurrentColor.Text = string.Empty;
      }
   }
}
