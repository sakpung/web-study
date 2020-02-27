// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Leadtools.SpecialEffects;

namespace SpecialEffectsDemo
{
   internal class ComboBoxItem
   {
      private string _display;
      private int _value;

      public ComboBoxItem(string display, int value)
      {
         _display = display;
         _value = value;
      }

      public string Display
      {
         get
         {
            return _display;
         }
      }

      public int Value
      {
         get
         {
            return _value;
         }
      }
   }

   public struct EffectOptions
   {
      public SpecialEffectsType Type;
      public int Delay;
      public int Grain;
      public int Passes;
      public int Wand;

      public EffectOptions(
         SpecialEffectsType type,
         int delay,
         int grain,
         int passes,
         int wand)
      {
         Type = type;
         Delay = delay;
         Grain = grain;
         Passes = passes;
         Wand = wand;
      }
   }

   public struct TransitionOptions
   {
      public SpecialEffectsTransitionStyle Style;
      public Color ForeColor;
      public Color BackColor;
      public EffectOptions EffectOptions;

      public TransitionOptions(
         SpecialEffectsTransitionStyle style,
         Color foreColor,
         Color backColor,
         EffectOptions effectOptions)
      {
         Style = style;
         ForeColor = foreColor;
         BackColor = backColor;
         EffectOptions = effectOptions;
      }
   }

   public struct ShapeOptions
   {
      public SpecialEffectsShape ShapeStyle;
      public SpecialEffectsFillStyle FillStyle;
      public Color ForeColor;
      public Color BackColor;

      public ShapeOptions(
         SpecialEffectsShape shapeStyle,
         SpecialEffectsFillStyle fillStyle,
         Color foreColor,
         Color backColor)
      {
         ShapeStyle = shapeStyle;
         FillStyle = fillStyle;
         ForeColor = foreColor;
         BackColor = backColor;
      }
   }

   public struct TextOptions
   {
      public string Text;
      public SpecialEffectsTextStyle Style;
      public Color TextColor;
      public Color BorderColor;

      public TextOptions(
         string text,
         SpecialEffectsTextStyle style,
         Color textColor,
         Color borderColor)
      {
         Text = text;
         Style = style;
         TextColor = textColor;
         BorderColor = borderColor;
      }
   }
}
