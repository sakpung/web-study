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
using Leadtools.SpecialEffects;

namespace SpecialEffectsDemo
{
   public partial class EffectsDialog : Form
   {
      public EffectsDialog(EffectOptions options)
      {
         _effectOptions = options;

         InitializeComponent();
      }

      private EffectOptions _effectOptions;

      private void EffectsDialog_Load(object sender, EventArgs e)
      {
         ArrayList items = new ArrayList();

         items.Add(new ComboBoxItem("No Effect", (int)SpecialEffectsType.None));
         items.Add(new ComboBoxItem("Linear Wipes: Left To Right", (int)SpecialEffectsType.WipeLToR));
         items.Add(new ComboBoxItem("Rectangle Wipes: In", (int)SpecialEffectsType.WipeRectangleIn));
         items.Add(new ComboBoxItem("Circular Wipes: Center CW from Left", (int)SpecialEffectsType.WipeCircleCCWFromL));
         items.Add(new ComboBoxItem("Pushes: Right to Left", (int)SpecialEffectsType.PushRToL));
         items.Add(new ComboBoxItem("Slides: Right to Left", (int)SpecialEffectsType.SlideRToL));
         items.Add(new ComboBoxItem("Rolls: Left to Right", (int)SpecialEffectsType.RollLToR));
         items.Add(new ComboBoxItem("Rotates: Left to Right", (int)SpecialEffectsType.RotateTToB));
         items.Add(new ComboBoxItem("Zooms: to Center", (int)SpecialEffectsType.ZoomToC));
         items.Add(new ComboBoxItem("Drips: Top to Bottom", (int)SpecialEffectsType.DripTToB));
         items.Add(new ComboBoxItem("Blinds: Top to Bottom", (int)SpecialEffectsType.BlindTToB));
         items.Add(new ComboBoxItem("Random Effects: Bars Right to Left", (int)SpecialEffectsType.RandomBarsRToL));
         items.Add(new ComboBoxItem("CheckerBorads: Top to Bottom then Top to Bottom", (int)SpecialEffectsType.CheckboardTToBThenTToB));
         items.Add(new ComboBoxItem("Blocks: Top to Bottom", (int)SpecialEffectsType.BlocksTToB));
         items.Add(new ComboBoxItem("Circular Effects: Center In", (int)SpecialEffectsType.CircleCIn));
         items.Add(new ComboBoxItem("Elliptical Effects: Center In", (int)SpecialEffectsType.EllipseCIn));

         _cmbEffectStyle.DataSource = items;
         _cmbEffectStyle.DisplayMember = "Display";
         _cmbEffectStyle.ValueMember = "Value";

         for(int i = 0; i < _cmbEffectStyle.Items.Count; i++)
         {
            ComboBoxItem item = (ComboBoxItem)_cmbEffectStyle.Items[i];
            if(_effectOptions.Type == (SpecialEffectsType)item.Value)
            {
               _cmbEffectStyle.SelectedIndex = i;
            }
         }

         _numDelay.Minimum = 0;
         _numDelay.Maximum = 999;
         _numDelay.Value = _effectOptions.Delay;

         _numGrain.Minimum = 1;
         _numGrain.Maximum = 256;
         _numGrain.Value = _effectOptions.Grain;

         _numPasses.Minimum = 1;
         _numPasses.Maximum = 64;
         _numPasses.Value = _effectOptions.Passes;

         _numWand.Minimum = 0;
         _numWand.Maximum = 256;
         _numWand.Value = _effectOptions.Wand;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         ComboBoxItem item = (ComboBoxItem)_cmbEffectStyle.SelectedItem;

         _effectOptions.Type = (SpecialEffectsType)item.Value;
         _effectOptions.Delay = (int)_numDelay.Value;
         _effectOptions.Grain = (int)_numGrain.Value;
         _effectOptions.Passes = (int)_numPasses.Value;
         _effectOptions.Wand = (int)_numWand.Value;
      }

      public EffectOptions EffectOptions
      {
         get
         {
            return _effectOptions;
         }
      }
   }
}
