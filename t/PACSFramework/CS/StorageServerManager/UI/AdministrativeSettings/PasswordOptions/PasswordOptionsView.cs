// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Demos.StorageServer.DataTypes.Options;

namespace Leadtools.Demos.StorageServer.UI
{
   public partial class PasswordOptionsView : UserControl
   {
      private PasswordOptions _Options;

      public PasswordOptions Options
      {
         get { return _Options; }
         set 
         { 
            _Options = value.Clone() as PasswordOptions;
            ConfigureView();
         }
      }

      public PasswordOptionsView()
      {
         InitializeComponent();
         checkBoxLowercase.Tag = Complexity.Lowercase;
         checkBoxUppercase.Tag = Complexity.Uppercase;
         checkBoxSymbol.Tag = Complexity.Symbol;
         checkBoxNumber.Tag = Complexity.Numbers;
      }

      public void ConfigureView()
      {
         checkBoxLowercase.Checked = (Complexity.Lowercase & Options.Complexity) == Complexity.Lowercase;
         checkBoxUppercase.Checked = (Complexity.Uppercase & Options.Complexity) == Complexity.Uppercase;
         checkBoxSymbol.Checked = (Complexity.Symbol & Options.Complexity) == Complexity.Symbol;
         checkBoxNumber.Checked = (Complexity.Numbers & Options.Complexity) == Complexity.Numbers;

         numericUpDownMinLength.Value = Convert.ToDecimal(Options.MinimumLength);
         numericUpDownExpire.Value = Convert.ToDecimal(Options.DaysToExpire);
         numericUpDownMax.Value = Convert.ToDecimal(Options.MaxPasswordHistory);

         checkBoxIdleTimeout.Checked = Options.EnableIdleTimeout;
         numericUpDownIdleTimeout.Value = Convert.ToDecimal(Options.IdleTimeOut);
      }

      private void ComplexityChanged(object sender, EventArgs e)
      {
         CheckBox checkBox = sender as CheckBox;
         Complexity complexity = (Complexity)checkBox.Tag;

         if (checkBox.Checked)
            Options.Complexity |= complexity;
         else
            Options.Complexity &= ~complexity;
      }

      private void numericUpDownMinLength_ValueChanged(object sender, EventArgs e)
      {
         Options.MinimumLength = Convert.ToInt32(numericUpDownMinLength.Value);
      }

      private void numericUpDownExpire_ValueChanged(object sender, EventArgs e)
      {
         Options.DaysToExpire = Convert.ToInt32(numericUpDownExpire.Value);
      }

      private void numericUpDownMax_ValueChanged(object sender, EventArgs e)
      {
         Options.MaxPasswordHistory = Convert.ToInt32(numericUpDownMax.Value);
      }

      private void checkBoxIdleTimeout_CheckedChanged(object sender, EventArgs e)
      {
         Options.EnableIdleTimeout = checkBoxIdleTimeout.Checked;
         numericUpDownIdleTimeout.Enabled = Options.EnableIdleTimeout;
      }

      private void numericUpDownIdleTimeout_ValueChanged(object sender, EventArgs e)
      {
         Options.IdleTimeOut = Convert.ToInt32(numericUpDownIdleTimeout.Value);
      }
   }
}
