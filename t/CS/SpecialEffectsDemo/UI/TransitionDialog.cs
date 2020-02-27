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
   public partial class TransitionDialog : Form
   {
      public TransitionDialog(TransitionOptions transitionOptions)
      {
         _transitionOptions = transitionOptions;

         InitializeComponent();
      }

      private TransitionOptions _transitionOptions;
      private SpecialEffectsType _effectType;
      private void TransitionDialog_Load(object sender, EventArgs e)
      {
         ArrayList items = new ArrayList();

         items.Add(new ComboBoxItem("Solid", (int)SpecialEffectsTransitionStyle.Solid));
         items.Add(new ComboBoxItem("Horizontal Lines", (int)SpecialEffectsTransitionStyle.HorzLine));
         items.Add(new ComboBoxItem("Vertical Lines", (int)SpecialEffectsTransitionStyle.VertLine));
         items.Add(new ComboBoxItem("Forward Diagonal Lines", (int)SpecialEffectsTransitionStyle.UpwardDiagnoal));
         items.Add(new ComboBoxItem("Backward Diagonal Lines", (int)SpecialEffectsTransitionStyle.DownwardDiagnoal));
         items.Add(new ComboBoxItem("Cross Lines", (int)SpecialEffectsTransitionStyle.Cross));
         items.Add(new ComboBoxItem("Diagonal Cross Lines", (int)SpecialEffectsTransitionStyle.DiagCross));
         items.Add(new ComboBoxItem("Gradient Conical from Bottom", (int)SpecialEffectsTransitionStyle.ConeFromB));

         _cmbTransitionStyle.DataSource = items;
         _cmbTransitionStyle.DisplayMember = "Display";
         _cmbTransitionStyle.ValueMember = "Value";

         for(int i = 0; i < _cmbTransitionStyle.Items.Count; i++)
         {
            ComboBoxItem item = (ComboBoxItem)_cmbTransitionStyle.Items[i];
            if(_transitionOptions.Style == (SpecialEffectsTransitionStyle)item.Value)
            {
               _cmbTransitionStyle.SelectedIndex = i;
            }
         }

         _btnForeColor.BackColor = _transitionOptions.ForeColor;
         _btnBackColor.BackColor = _transitionOptions.BackColor;

         _effectType = _transitionOptions.EffectOptions.Type;
         _numDelay.Value = _transitionOptions.EffectOptions.Delay;
         _numGrain.Value = _transitionOptions.EffectOptions.Grain;
         _numPasses.Value = _transitionOptions.EffectOptions.Passes;
         _numWand.Value = _transitionOptions.EffectOptions.Wand;
      }

      private void _btnEffect_Click(object sender, EventArgs e)
      {
         ComboBoxItem item = (ComboBoxItem)_cmbTransitionStyle.SelectedItem;

         EffectsDialog dlg = new EffectsDialog(new EffectOptions(
            _effectType,
            (int)_numDelay.Value,
            (int)_numGrain.Value,
            (int)_numPasses.Value,
            (int)_numWand.Value));

         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            _effectType = dlg.EffectOptions.Type;
            _numDelay.Value = dlg.EffectOptions.Delay;
            _numGrain.Value = dlg.EffectOptions.Grain;
            _numPasses.Value = dlg.EffectOptions.Passes;
            _numWand.Value = dlg.EffectOptions.Wand;
         }
      }

      public TransitionOptions TransitionOptions
      {
         get
         {
            return _transitionOptions;
         }
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

      private void _btnOK_Click(object sender, EventArgs e)
      {
         ComboBoxItem item = (ComboBoxItem)_cmbTransitionStyle.SelectedItem;
         _transitionOptions.Style = (SpecialEffectsTransitionStyle)item.Value;
         _transitionOptions.ForeColor = _btnForeColor.BackColor;
         _transitionOptions.BackColor = _btnBackColor.BackColor;
         _transitionOptions.EffectOptions = new EffectOptions(
            _effectType,
            (int)_numDelay.Value,
            (int)_numGrain.Value,
            (int)_numPasses.Value,
            (int)_numWand.Value);
      }
   }
}
