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

using Leadtools;
using Leadtools.Codecs;
using Leadtools.SpecialEffects;
using Leadtools.Demos;

#if ! LEADTOOLS_V17_OR_LATER
using LeadPoint = System.Drawing.Point;
using LeadSize = System.Drawing.Size;
using LeadRect = System.Drawing.Rectangle;
#endif // #if !LEADTOOLS_V17_OR_LATER

#if LEADTOOLS_V17_OR_LATER
using Leadtools.Drawing;
#endif // #if LEADTOOLS_V17_OR_LATER

namespace SpecialEffectsDemo
{
   public partial class MainForm : Form
   {
      public MainForm( )
      {
         InitializeComponent();
      }

      private RasterCodecs _codecs;

      private string[] _fileNameArray = { "Sample1.cmp", "Sample2.cmp", "Sample3.cmp", "Sample4.cmp", "Sample5.cmp" };
      private string ImagePath = DemosGlobal.ImagesFolder + @"\";

      // Special Effects processor object.
      private SpecialEffectsProcessor _processor;

      // Special Effects private members
      private EffectOptions _effectOptions;
      private TransitionOptions _transitionOptions;
      private ShapeOptions _shapeOptions;
      private TextOptions _textOptions;

      // Some Special Effects const options values.
      private const int Speed = 0;
      private const int Cycles = 0;
      private const int Steps = 255;
      private const bool Transparency = false;
      private Color WandColor = Color.Red;

      // Index of the current active image.
      private int _index;
      private RasterImage _image;
      /// <summary>
      /// Initializes the application
      /// </summary>
      private void MainForm_Load(object sender, EventArgs e)
      {
         try
         {
            // setup our caption
            Messager.Caption = "LEADTOOLS for .NET C# Special Effects Demo";
            Text = Messager.Caption;

            // intitialize the codecs object
            _codecs = new RasterCodecs();

            // Initialize the private memebers

            _effectOptions = new EffectOptions(
               SpecialEffectsType.ZoomToC,
               10,
               10,
               1,
               0);

            _transitionOptions = new TransitionOptions(
               SpecialEffectsTransitionStyle.ConeFromB,
               Color.Red,
               Color.Blue,
               new EffectOptions(SpecialEffectsType.WipeLToR, 10, 10, 1, 0));

            _shapeOptions = new ShapeOptions(
               SpecialEffectsShape.CrossSMALL,
               SpecialEffectsFillStyle.Solid,
               Color.Red,
               Color.Blue);

            _textOptions = new TextOptions(
               "LEADTOOLS",
               SpecialEffectsTextStyle.InsetLight,
               Color.Red,
               Color.Blue);

            _processor = new SpecialEffectsProcessor();

            _index = 0;
            PaintSpecialEffects();
         }
         catch(Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      /// <summary>
      /// Shutdown the RasterCodecs before we go.
      /// </summary>
      private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
      {
      }

      private void _btnEffect_Click(object sender, EventArgs e)
      {
         EffectsDialog dlg = new EffectsDialog(_effectOptions);
         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            _effectOptions = dlg.EffectOptions;
            Invalidate();
         }
      }

      private void _btnTransition_Click(object sender, EventArgs e)
      {
         TransitionDialog dlg = new TransitionDialog(_transitionOptions);
         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            _transitionOptions = dlg.TransitionOptions;

            _ckShowTransition.Checked = true;

            Invalidate();
         }
      }

      private void _btnShape_Click(object sender, EventArgs e)
      {
         ShapeDialog dlg = new ShapeDialog(_shapeOptions);
         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            _shapeOptions = dlg.ShapeOptions;
            _ckShowShape.Checked = true;
            Invalidate();
         }
      }

      private void _btnText_Click(object sender, EventArgs e)
      {
         TextDialog dlg = new TextDialog(_textOptions);

         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            _textOptions = dlg.TextOptions;
            _ckShowText.Checked = true;
            Invalidate();
         }
      }

      private void _btnShow_Click(object sender, EventArgs e)
      {
         PaintSpecialEffects();
      }

      private void PaintSpecialEffects( )
      {
         if(_image != null)
            _image.Dispose();

         _image = _codecs.Load(ImagePath + _fileNameArray[_index]);

         _index = (_index + 1) % _fileNameArray.Length;

         Graphics g = _pnlViewer.CreateGraphics();

         Rectangle rc = _pnlViewer.ClientRectangle;

         rc = _processor.DrawFrame(
            g,
            rc,
            SpecialEffectsFrameStyleFlags.AdjustRectangle | SpecialEffectsFrameStyleFlags.OuterRaised,
            2,
            Color.Silver,
            2,
            Color.DarkGray,
            Color.White,
            2,
            Color.DarkGray,
            Color.White);

         if(_ckShowTransition.Checked)
         {
            for(int i = 0; i < _transitionOptions.EffectOptions.Passes; i++)
            {
               _processor.PaintTransition(
                  g,
                  _transitionOptions.Style,
                  _transitionOptions.BackColor,
                  _transitionOptions.ForeColor,
                  Steps,
                  rc,
                   _transitionOptions.EffectOptions.Type,
                   _transitionOptions.EffectOptions.Grain,
                   _transitionOptions.EffectOptions.Delay,
                   Speed,
                   Cycles,
                   i + 1,
                   _transitionOptions.EffectOptions.Passes,
                   Transparency,
                   Color.Empty,
                   _transitionOptions.EffectOptions.Wand,
                   WandColor,
                   RasterPaintProperties.SourceCopy,
                   null);
            }
         }

         for(int i = 0; i < _effectOptions.Passes; i++)
         {
            RasterPaintProperties paintProp = new RasterPaintProperties();
            paintProp.RasterOperation = RasterPaintProperties.SourceCopy;

            _processor.PaintImage(g,
                                  _image,
                                  Rectangle.Empty,
                                  Rectangle.Empty,
                                  rc,
                                  rc,
                                  _effectOptions.Type,
                                  _effectOptions.Grain,
                                  _effectOptions.Delay,
                                  0,
                                  0,
                                  i + 1,
                                  _effectOptions.Passes,
                                  false,
                                  Color.Empty,
                                  _effectOptions.Wand,
                                  WandColor,
                                  paintProp,
                                  null);
         }

         if(_ckShowShape.Checked)
         {
            _processor.Draw3dShape(
               g,
               _shapeOptions.ShapeStyle,
               rc,
               _shapeOptions.BackColor,
               null,
               rc,
               SpecialEffectsBackStyle.Translucent,
               _shapeOptions.ForeColor,
               _shapeOptions.FillStyle,
               Color.Red,
               SpecialEffectsBorderStyle.Solid,
               2,
               Color.Green,
               Color.Yellow,
               SpecialEffectsInnerStyle.Raised,
               2,
               Color.Turquoise,
               Color.Snow,
               SpecialEffectsOuterStyle.Inset,
               2,
               5,
               5,
               Color.Black,
               null);
         }

         if(_ckShowText.Checked)
         {
            FontFamily ff = new FontFamily("Arial");

            Font f = new Font(ff, 48);

            _processor.Draw3dText(
               g,
               _textOptions.Text,
               rc,
               _textOptions.Style,
               SpecialEffectsTextAlignmentFlags.HorizontalCenter | SpecialEffectsTextAlignmentFlags.VerticalCenter,
               5,
               5,
               _textOptions.TextColor,
               _textOptions.BorderColor,
               Color.White,
               f,
               null);
         }

         g.Dispose();
      }

      private void _pnlViewer_Paint(object sender, PaintEventArgs e)
      {
         if(_image != null)
         {
            PaintSpecialEffects();
         }
      }
   }
}
