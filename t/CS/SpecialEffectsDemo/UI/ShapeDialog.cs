// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools.SpecialEffects;

namespace SpecialEffectsDemo
{
   public partial class ShapeDialog : Form
   {
      public ShapeDialog(ShapeOptions options)
      {
         _options = options;

         InitializeComponent();
      }

      private ShapeOptions _options;

      private void ShapeDialog_Load(object sender, EventArgs e)
      {
         ArrayList s = new ArrayList();

         s.Add(new ComboBoxItem("Squares: Normal", (int)SpecialEffectsShape.Square));
         s.Add(new ComboBoxItem("Rectangles: Normal", (int)SpecialEffectsShape.Rectangle));
         s.Add(new ComboBoxItem("Parallelograms: Left", (int)SpecialEffectsShape.ParallelogramL));
         s.Add(new ComboBoxItem("Trapezoids: Left", (int)SpecialEffectsShape.TrapezoidL));
         s.Add(new ComboBoxItem("Triangles: Equilateral Left", (int)SpecialEffectsShape.TriangleEquilateralL));
         s.Add(new ComboBoxItem("Other: Octagon", (int)SpecialEffectsShape.Octagon));
         s.Add(new ComboBoxItem("Circles: Normal", (int)SpecialEffectsShape.Circle));
         s.Add(new ComboBoxItem("Ellipses: Normal", (int)SpecialEffectsShape.Ellipse));
         s.Add(new ComboBoxItem("Stars: 8-Point", (int)SpecialEffectsShape.Star8));
         s.Add(new ComboBoxItem("Crosses: Small", (int)SpecialEffectsShape.CrossSMALL));
         s.Add(new ComboBoxItem("Arrows: Left", (int)SpecialEffectsShape.ArrowL));

         _cmbShapeStyle.Items.Clear();
         _cmbShapeStyle.DataSource = s;
         _cmbShapeStyle.DisplayMember = "Display";
         _cmbShapeStyle.ValueMember = "Value";

         for(int i = 0; i < _cmbShapeStyle.Items.Count; i++)
         {
            ComboBoxItem item = (ComboBoxItem)_cmbShapeStyle.Items[i];
            if(_options.ShapeStyle == (SpecialEffectsShape)item.Value)
            {
               _cmbShapeStyle.SelectedIndex = i;
            }
         }

         ArrayList ss = new ArrayList();

         ss.Add(new ComboBoxItem("Solid", (int)SpecialEffectsFillStyle.Solid));
         ss.Add(new ComboBoxItem("Transparent", (int)SpecialEffectsFillStyle.Transparent));
         ss.Add(new ComboBoxItem("Horizontal", (int)SpecialEffectsFillStyle.Horizontal));
         ss.Add(new ComboBoxItem("Vertical", (int)SpecialEffectsFillStyle.Vertical));
         ss.Add(new ComboBoxItem("Forward Diagonal", (int)SpecialEffectsFillStyle.ForwardDiagonal));
         ss.Add(new ComboBoxItem("Backward Diagonal", (int)SpecialEffectsFillStyle.BackwardDiagonal));
         ss.Add(new ComboBoxItem("Cross", (int)SpecialEffectsFillStyle.Cross));
         ss.Add(new ComboBoxItem("Diagonal Cross", (int)SpecialEffectsFillStyle.DiagonalCross));

         _cmbFillStyle.Items.Clear();
         _cmbFillStyle.DataSource = ss;
         _cmbFillStyle.DisplayMember = "Display";
         _cmbFillStyle.ValueMember = "Value";

         for(int i = 0; i < _cmbFillStyle.Items.Count; i++)
         {
            ComboBoxItem item = (ComboBoxItem)_cmbFillStyle.Items[i];
            if(_options.FillStyle == (SpecialEffectsFillStyle)item.Value)
            {
               _cmbFillStyle.SelectedIndex = i;
            }
         }

         _btnForeColor.BackColor = _options.ForeColor;
         _btnBackColor.BackColor = _options.BackColor;

      }

      private void _btnForeColor_Click(object sender, EventArgs e)
      {
         ColorDialog dlg = new ColorDialog();
         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            _btnForeColor.BackColor = dlg.Color;
         }
      }

      private void _btnBackColor_Click(object sender, EventArgs e)
      {
         ColorDialog dlg = new ColorDialog();
         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            _btnBackColor.BackColor = dlg.Color;
         }
      }


      public ShapeOptions ShapeOptions
      {
         get
         {
            return _options;
         }
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         ComboBoxItem ss = (ComboBoxItem)_cmbShapeStyle.SelectedItem;
         _options.ShapeStyle = (SpecialEffectsShape)ss.Value;

         ComboBoxItem fs = (ComboBoxItem)_cmbFillStyle.SelectedItem;
         _options.FillStyle = (SpecialEffectsFillStyle)fs.Value;

         _options.ForeColor = _btnForeColor.BackColor;
         _options.BackColor = _btnBackColor.BackColor;
      }
   }
}
