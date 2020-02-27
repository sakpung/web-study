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

#if LEADTOOLS_V17_OR_LATER
using Leadtools.Drawing;
#endif // #if LEADTOOLS_V17_OR_LATER

namespace Leadtools.Demos
{
   public partial class PaintPropertiesDialog : Form
   {
      private enum CategorizedDithering
      {
         None,
         ErrorDiffusion,
         Ordered
      }

      private enum CategorizedBitonalScaling
      {
         None,
         FavorBlack,
         ScaleToGray
      }

      private enum CategorizedPaintScaling
      {
         None,
         Resample,
         Bicubic
      }

      private enum CategorizedPalette
      {
         Auto,
         Fixed,
         Netscape
      }

      private struct CategorizedPaintProperties
      {
         public RasterPaintEngine PaintEngine;
         public int RasterOperation;
         public CategorizedDithering Dithering;
         public CategorizedBitonalScaling BitonalScaling;
         public CategorizedPaintScaling PaintScaling;
         public CategorizedPalette Palette;
         public bool UsePaintPalette;
         public bool IndexedPaint;
         public bool FastPaint;
         public bool HalftonePrint;

         public CategorizedPaintProperties(RasterPaintProperties props)
         {
            PaintEngine = props.PaintEngine;
            RasterOperation = props.RasterOperation;

            if((props.PaintDisplayMode & RasterPaintDisplayModeFlags.DitheredPaint) == RasterPaintDisplayModeFlags.DitheredPaint)
            {
               if((props.PaintDisplayMode & RasterPaintDisplayModeFlags.OrderedDither) == RasterPaintDisplayModeFlags.OrderedDither)
                  Dithering = CategorizedDithering.Ordered;
               else
                  Dithering = CategorizedDithering.ErrorDiffusion;
            }
            else
               Dithering = CategorizedDithering.None;

            if((props.PaintDisplayMode & RasterPaintDisplayModeFlags.FavorBlack) == RasterPaintDisplayModeFlags.FavorBlack)
               BitonalScaling = CategorizedBitonalScaling.FavorBlack;
            else if((props.PaintDisplayMode & RasterPaintDisplayModeFlags.ScaleToGray) == RasterPaintDisplayModeFlags.ScaleToGray)
               BitonalScaling = CategorizedBitonalScaling.ScaleToGray;
            else
               BitonalScaling = CategorizedBitonalScaling.None;

            if((props.PaintDisplayMode & RasterPaintDisplayModeFlags.Resample) == RasterPaintDisplayModeFlags.Resample)
               PaintScaling = CategorizedPaintScaling.Resample;
            else if((props.PaintDisplayMode & RasterPaintDisplayModeFlags.Bicubic) == RasterPaintDisplayModeFlags.Bicubic)
               PaintScaling = CategorizedPaintScaling.Bicubic;
            else
               PaintScaling = CategorizedPaintScaling.None;

            if((props.PaintDisplayMode & RasterPaintDisplayModeFlags.FixedPalette) == RasterPaintDisplayModeFlags.FixedPalette)
            {
               if((props.PaintDisplayMode & RasterPaintDisplayModeFlags.NetscapePalette) == RasterPaintDisplayModeFlags.NetscapePalette)
                  Palette = CategorizedPalette.Netscape;
               else
                  Palette = CategorizedPalette.Fixed;
            }
            else
               Palette = CategorizedPalette.Auto;

            UsePaintPalette = props.UsePaintPalette;
            IndexedPaint = (props.PaintDisplayMode & RasterPaintDisplayModeFlags.IndexedPaint) == RasterPaintDisplayModeFlags.IndexedPaint;
            FastPaint = (props.PaintDisplayMode & RasterPaintDisplayModeFlags.FastPaint) == RasterPaintDisplayModeFlags.FastPaint;
            HalftonePrint = (props.PaintDisplayMode & RasterPaintDisplayModeFlags.HalftonePrint) == RasterPaintDisplayModeFlags.HalftonePrint;
         }

         public RasterPaintProperties ToPaintProperties( )
         {
            RasterPaintProperties props = RasterPaintProperties.Default;
            props.PaintDisplayMode = RasterPaintDisplayModeFlags.None;

            props.PaintEngine = PaintEngine;
            props.RasterOperation = RasterOperation;

            if(Dithering == CategorizedDithering.Ordered)
               props.PaintDisplayMode |= (RasterPaintDisplayModeFlags.OrderedDither | RasterPaintDisplayModeFlags.DitheredPaint);
            else if(Dithering == CategorizedDithering.ErrorDiffusion)
               props.PaintDisplayMode |= RasterPaintDisplayModeFlags.OrderedDither;

            if(BitonalScaling == CategorizedBitonalScaling.ScaleToGray)
               props.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray;
            else if(BitonalScaling == CategorizedBitonalScaling.FavorBlack)
               props.PaintDisplayMode |= RasterPaintDisplayModeFlags.FavorBlack;

            if(PaintScaling == CategorizedPaintScaling.Bicubic)
               props.PaintDisplayMode |= RasterPaintDisplayModeFlags.Bicubic;
            else if(PaintScaling == CategorizedPaintScaling.Resample)
               props.PaintDisplayMode |= RasterPaintDisplayModeFlags.Resample;

            if(Palette == CategorizedPalette.Netscape)
               props.PaintDisplayMode |= (RasterPaintDisplayModeFlags.FixedPalette | RasterPaintDisplayModeFlags.NetscapePalette);
            else if(Palette == CategorizedPalette.Fixed)
               props.PaintDisplayMode |= RasterPaintDisplayModeFlags.FixedPalette;

            props.UsePaintPalette = UsePaintPalette;

            if(IndexedPaint)
               props.PaintDisplayMode |= RasterPaintDisplayModeFlags.IndexedPaint;

            if(FastPaint)
               props.PaintDisplayMode |= RasterPaintDisplayModeFlags.FastPaint;

            if(HalftonePrint)
               props.PaintDisplayMode |= RasterPaintDisplayModeFlags.HalftonePrint;

            return props;
         }
      }

      private RasterPaintProperties _paintProperties;

      public RasterPaintProperties PaintProperties
      {
         get
         {
            return _paintProperties;
         }
         set
         {
            _paintProperties = value;
         }
      }

      public event EventHandler Apply;

      private CategorizedPaintProperties _categorizedProps;

      private struct ComboBoxItem
      {
         public int Value;
         public string Name;

         public ComboBoxItem(int val, string n)
         {
            Value = val;
            Name = n;
         }

         public override string ToString( )
         {
            return Name;
         }
      }

      private static readonly ComboBoxItem[] _engines =
      {
         new ComboBoxItem((int)RasterPaintEngine.Gdi, "Win32 GDI"),
         new ComboBoxItem((int)RasterPaintEngine.GdiPlus, "GDI+"),
      };

      private ComboBoxItem[] _operations ;

      private ComboBoxItem[] _ditherings;

      private ComboBoxItem[] _palettes;
      private ComboBoxItem[] _bitonalScalings;
      private ComboBoxItem[] _paintScalings;


      public PaintPropertiesDialog( )
      {
         InitializeComponent();

         _paintScalings = new ComboBoxItem[]
          {
             new ComboBoxItem((int)CategorizedPaintScaling.None, DemosGlobalization.GetResxString(GetType(), "Resx_None")),
             new ComboBoxItem((int)CategorizedPaintScaling.Resample, DemosGlobalization.GetResxString(GetType(), "Resx_Resample")),
             new ComboBoxItem((int)CategorizedPaintScaling.Bicubic, DemosGlobalization.GetResxString(GetType(), "Resx_BiCubic")),
          };
         _bitonalScalings = new ComboBoxItem[]
          {
             new ComboBoxItem((int)CategorizedBitonalScaling.None, DemosGlobalization.GetResxString(GetType(), "Resx_None")),
             new ComboBoxItem((int)CategorizedBitonalScaling.FavorBlack, DemosGlobalization.GetResxString(GetType(), "Resx_FavorBlack")),
             new ComboBoxItem((int)CategorizedBitonalScaling.ScaleToGray, DemosGlobalization.GetResxString(GetType(), "Resx_ScaleToGray")),
          };
         _palettes = new ComboBoxItem[]
          {
             new ComboBoxItem((int)CategorizedPalette.Auto, DemosGlobalization.GetResxString(GetType(), "Resx_Auto")),
             new ComboBoxItem((int)CategorizedPalette.Fixed, "LEADTOOLS"),
             new ComboBoxItem((int)CategorizedPalette.Netscape, DemosGlobalization.GetResxString(GetType(), "Resx_Netscape")),
          };
         _ditherings = new ComboBoxItem[]
          {
             new ComboBoxItem((int)CategorizedDithering.None, DemosGlobalization.GetResxString(GetType(), "Resx_None")),
             new ComboBoxItem((int)CategorizedDithering.ErrorDiffusion, DemosGlobalization.GetResxString(GetType(), "Resx_ErrorDiffusion")),
             new ComboBoxItem((int)CategorizedDithering.Ordered, DemosGlobalization.GetResxString(GetType(), "Resx_Ordered")),
          };
         _operations = new ComboBoxItem[]
          {
             new ComboBoxItem(RasterPaintProperties.SourceCopy, DemosGlobalization.GetResxString(GetType(), "Resx_SourceCopy")),
             new ComboBoxItem(RasterPaintProperties.SourcePaint, DemosGlobalization.GetResxString(GetType(), "Resx_SourcePaint")),
             new ComboBoxItem(RasterPaintProperties.SourceAnd,DemosGlobalization.GetResxString(GetType(), "Resx_SourceAnd") ),
             new ComboBoxItem(RasterPaintProperties.SourceInvert, DemosGlobalization.GetResxString(GetType(), "Resx_SourceInvert")),
             new ComboBoxItem(RasterPaintProperties.SourceErase, DemosGlobalization.GetResxString(GetType(), "Resx_SourceErase")),
             new ComboBoxItem(RasterPaintProperties.NotSourceCopy, DemosGlobalization.GetResxString(GetType(), "Resx_NotSourceCopy")),
             new ComboBoxItem(RasterPaintProperties.NotSourceErase, DemosGlobalization.GetResxString(GetType(), "Resx_NotSourceErase")),
             new ComboBoxItem(RasterPaintProperties.MergeCopy, DemosGlobalization.GetResxString(GetType(), "Resx_MergeCopy")),
             new ComboBoxItem(RasterPaintProperties.MergePaint, DemosGlobalization.GetResxString(GetType(), "Resx_MergePaint")),
             new ComboBoxItem(RasterPaintProperties.PatternCopy, DemosGlobalization.GetResxString(GetType(), "Resx_PatternCopy")),
             new ComboBoxItem(RasterPaintProperties.PatternPaint, DemosGlobalization.GetResxString(GetType(), "Resx_PatternPaint")),
             new ComboBoxItem(RasterPaintProperties.PatternInvert, DemosGlobalization.GetResxString(GetType(), "Resx_PatternInvert")),
             new ComboBoxItem(RasterPaintProperties.DestinationInvert, DemosGlobalization.GetResxString(GetType(), "Resx_DestinationInvert")),
             new ComboBoxItem(RasterPaintProperties.Blackness, DemosGlobalization.GetResxString(GetType(), "Resx_Blackness")),
             new ComboBoxItem(RasterPaintProperties.Whiteness, DemosGlobalization.GetResxString(GetType(), "Resx_Whiteness"))
          };
      }

      private void PaintPropertiesDialog_Load(object sender, System.EventArgs e)
      {
         _categorizedProps = new CategorizedPaintProperties(PaintProperties);

         foreach(ComboBoxItem i in _engines)
         {
            _cbEngine.Items.Add(i);
            if((RasterPaintEngine)i.Value == _categorizedProps.PaintEngine)
               _cbEngine.SelectedItem = i;
         }

         foreach(ComboBoxItem i in _operations)
         {
            _cbOperation.Items.Add(i);
            if(i.Value == _categorizedProps.RasterOperation)
               _cbOperation.SelectedItem = i;
         }

         foreach(ComboBoxItem i in _ditherings)
         {
            _cbDithering.Items.Add(i);
            if((CategorizedDithering)i.Value == _categorizedProps.Dithering)
               _cbDithering.SelectedItem = i;
         }

         foreach(ComboBoxItem i in _palettes)
         {
            _cbPalette.Items.Add(i);
            if((CategorizedPalette)i.Value == _categorizedProps.Palette)
               _cbPalette.SelectedItem = i;
         }

         foreach(ComboBoxItem i in _bitonalScalings)
         {
            _cbBitonalScaling.Items.Add(i);
            if((CategorizedBitonalScaling)i.Value == _categorizedProps.BitonalScaling)
               _cbBitonalScaling.SelectedItem = i;
         }

         foreach(ComboBoxItem i in _paintScalings)
         {
            _cbPaintScaling.Items.Add(i);
            if((CategorizedPaintScaling)i.Value == _categorizedProps.PaintScaling)
               _cbPaintScaling.SelectedItem = i;
         }

         _cbIndexedPaint.Checked = _categorizedProps.IndexedPaint;
         _cbFastPaint.Checked = _categorizedProps.FastPaint;
         _cbHalftonePrint.Checked = _categorizedProps.HalftonePrint;

         CheckApply();
      }

      private void CheckApply( )
      {
         bool canApply = false;

         CategorizedPaintProperties props = GetProps();

         if(!canApply && props.PaintEngine != _categorizedProps.PaintEngine)
            canApply = true;

         if(!canApply && props.RasterOperation != _categorizedProps.RasterOperation)
            canApply = true;

         if(!canApply && props.Dithering != _categorizedProps.Dithering)
            canApply = true;

         if(!canApply && props.Palette != _categorizedProps.Palette)
            canApply = true;

         if(!canApply && props.BitonalScaling != _categorizedProps.BitonalScaling)
            canApply = true;

         if(!canApply && props.PaintScaling != _categorizedProps.PaintScaling)
            canApply = true;

         if(!canApply && props.UsePaintPalette != _categorizedProps.UsePaintPalette)
            canApply = true;

         if(!canApply && props.IndexedPaint != _categorizedProps.IndexedPaint)
            canApply = true;

         if(!canApply && props.FastPaint != _categorizedProps.FastPaint)
            canApply = true;

         if(!canApply && props.HalftonePrint != _categorizedProps.HalftonePrint)
            canApply = true;

         _btnApply.Enabled = canApply;

         _lblOperation.Enabled = props.PaintEngine != RasterPaintEngine.GdiPlus;
         _cbOperation.Enabled = props.PaintEngine != RasterPaintEngine.GdiPlus;
      }

      private CategorizedPaintProperties GetProps( )
      {
         CategorizedPaintProperties props = new CategorizedPaintProperties();

         if(_cbEngine.SelectedItem != null)
         {
            ComboBoxItem item = (ComboBoxItem)_cbEngine.SelectedItem;
            props.PaintEngine = (RasterPaintEngine)item.Value;
         }

         if(_cbOperation.SelectedItem != null)
         {
            ComboBoxItem item = (ComboBoxItem)_cbOperation.SelectedItem;
            props.RasterOperation = item.Value;
         }

         if(_cbDithering.SelectedItem != null)
         {
            ComboBoxItem item = (ComboBoxItem)_cbDithering.SelectedItem;
            props.Dithering = (CategorizedDithering)item.Value;
         }

         if(_cbPalette.SelectedItem != null)
         {
            ComboBoxItem item = (ComboBoxItem)_cbPalette.SelectedItem;
            props.Palette = (CategorizedPalette)item.Value;
         }

         if(_cbBitonalScaling.SelectedItem != null)
         {
            ComboBoxItem item = (ComboBoxItem)_cbBitonalScaling.SelectedItem;
            props.BitonalScaling = (CategorizedBitonalScaling)item.Value;
         }

         if(_cbPaintScaling.SelectedItem != null)
         {
            ComboBoxItem item = (ComboBoxItem)_cbPaintScaling.SelectedItem;
            props.PaintScaling = (CategorizedPaintScaling)item.Value;
         }

         props.UsePaintPalette = true;
         props.IndexedPaint = _cbIndexedPaint.Checked;
         props.FastPaint = _cbFastPaint.Checked;
         props.HalftonePrint = _cbHalftonePrint.Checked;

         return props;
      }

      private void ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         CheckApply();
      }

      private void CheckBox_CheckedChanged(object sender, System.EventArgs e)
      {
         CheckApply();
      }

      private void _btnApply_Click(object sender, System.EventArgs e)
      {
         ApplyProps();
         CheckApply();
      }

      private void ApplyProps( )
      {
         if(_btnApply.Enabled)
         {
            _categorizedProps = GetProps();
            _paintProperties = _categorizedProps.ToPaintProperties();

            if(Apply != null)
               Apply(this, EventArgs.Empty);
         }
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         ApplyProps();
      }
   }
}
