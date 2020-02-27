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
using Leadtools.Medical.UserManagementDataAccessLayer;

namespace Leadtools.Medical.Winforms
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

      private List<User> _cardReaderUsers;
      public List<User>  CardReaderUsers
      {
         get
         {
            return _cardReaderUsers;
         }
         set
         {
            _cardReaderUsers = value;
            UpdateUI();
         }
      }

      public event EventHandler ComplexityLowerCaseChanged = null;
      public event EventHandler ComplexityUpperCaseChanged = null;
      public event EventHandler ComplexitySymbolChanged = null;
      public event EventHandler ComplexityNumberChanged = null;
      public event EventHandler MinimumLengthChanged = null;
      public event EventHandler DaysToExpirationChanged = null;
      public event EventHandler MaximumRememberedChanged = null;
      public event EventHandler IdleTimeoutEnableChanged = null;
      public event EventHandler IdleTimeoutChanged = null;
      public event EventHandler LoginTypeChanged = null;

      public PasswordOptionsView()
      {
         InitializeComponent();
         checkBoxLowercase.Tag = Complexity.Lowercase;
         checkBoxUppercase.Tag = Complexity.Uppercase;
         checkBoxSymbol.Tag = Complexity.Symbol;
         checkBoxNumber.Tag = Complexity.Numbers;

         this.checkBoxNumber.CheckedChanged           += new System.EventHandler(this.ComplexityChanged);
         this.checkBoxSymbol.CheckedChanged           += new System.EventHandler(this.ComplexityChanged);
         this.checkBoxUppercase.CheckedChanged        += new System.EventHandler(this.ComplexityChanged);
         this.checkBoxLowercase.CheckedChanged        += new System.EventHandler(this.ComplexityChanged);
         this.numericUpDownMinLength.ValueChanged     += new System.EventHandler(this.numericUpDownMinLength_ValueChanged);
         this.numericUpDownExpire.ValueChanged        += new System.EventHandler(this.numericUpDownExpire_ValueChanged);
         this.numericUpDownMax.ValueChanged           += new System.EventHandler(this.numericUpDownMax_ValueChanged);
         this.numericUpDownIdleTimeout.ValueChanged   += new System.EventHandler(this.numericUpDownIdleTimeout_ValueChanged);
         this.checkBoxIdleTimeout.CheckedChanged      += new System.EventHandler(this.checkBoxIdleTimeout_CheckedChanged);
         this.radioButtonNamePassword.CheckedChanged  += new System.EventHandler(this.radioLoginTypeChanged);
         this.radioButtonSmartCardPin.CheckedChanged  += new System.EventHandler(this.radioLoginTypeChanged);
         this.radioButtonBoth.CheckedChanged          += new System.EventHandler(this.radioLoginTypeChanged);

         // IsDirty Handlers
         checkBoxLowercase.CheckedChanged             += new EventHandler(OnSetIsDirty);
         checkBoxUppercase.CheckedChanged             += new EventHandler(OnSetIsDirty);
         checkBoxSymbol.CheckedChanged                += new EventHandler(OnSetIsDirty);
         checkBoxNumber.CheckedChanged                += new EventHandler(OnSetIsDirty);
         numericUpDownMinLength.ValueChanged          += new EventHandler(OnSetIsDirty);
         numericUpDownExpire.ValueChanged             += new EventHandler(OnSetIsDirty);
         numericUpDownMax.ValueChanged                += new EventHandler(OnSetIsDirty);
         checkBoxIdleTimeout.CheckedChanged           += new EventHandler(OnSetIsDirty);
         numericUpDownIdleTimeout.ValueChanged        += new EventHandler(OnSetIsDirty);

         labelSmartCardWarning.Visible = false;
      }

      public void InitializeLoginType(PasswordOptions options)
      {
         switch(options.LoginType)
         {
            case LoginType.UsernamePassword:
               this.radioButtonNamePassword.Checked = true;
               break;

            case LoginType.SmartcardPin:
               this.radioButtonSmartCardPin.Checked = true;
               break;

            case LoginType.Both:
               this.radioButtonBoth.Checked = true;
               break;
         }
      }

      private void UpdateUI()
      {
         User adminUser = null;

         if (_cardReaderUsers != null)
         {
            adminUser = _cardReaderUsers.Find(x => x.IsAdmin);
         }
         bool adminCardReaderUserExists = (adminUser != null);
         radioButtonSmartCardPin.Enabled = adminCardReaderUserExists;
         labelSmartCardWarning.Visible = !adminCardReaderUserExists;
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
         checkBoxIdleTimeout_CheckedChanged(this, null);
         numericUpDownIdleTimeout.Value = Convert.ToDecimal(Math.Max(Math.Min(Options.IdleTimeOut,1200),30));

         InitializeLoginType(Options);

         UpdateUI();
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

      
      private void radioLoginTypeChanged(object sender, EventArgs e)
      {
         RadioButton rb = sender as RadioButton;
         if (rb != null)
         {
            if (rb.Checked)
            {
               if (sender == radioButtonNamePassword)
                  Options.LoginType = LoginType.UsernamePassword;

               else if (sender == radioButtonSmartCardPin)
                  Options.LoginType = LoginType.SmartcardPin;

               else if (sender == radioButtonBoth)
                  Options.LoginType = LoginType.Both;

               OnSetIsDirty(sender, e);
            }
         }
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

      private void OnSetIsDirty(object sender, EventArgs e)
      {
         try
         {
            IsDirty = true;
            OnSettingsChanged(sender, e);
            if (sender == checkBoxLowercase)
            {
               if (ComplexityLowerCaseChanged != null)
                  ComplexityLowerCaseChanged(sender, e);
            }
            else if (sender == checkBoxUppercase)
            {
               if (ComplexityUpperCaseChanged != null)
                  ComplexityUpperCaseChanged(sender, e);
            }
            else if (sender == checkBoxSymbol)
            {
               if (ComplexitySymbolChanged != null)
                  ComplexitySymbolChanged(sender, e);
            }
            else if (sender == checkBoxNumber)
            {
               if (ComplexityNumberChanged != null)
                  ComplexityNumberChanged(sender, e);
            }
            else if (sender == numericUpDownMinLength)
            {
               if (MinimumLengthChanged != null)
                  MinimumLengthChanged(sender, e);
            }
            else if (sender == numericUpDownExpire)
            {
               if (DaysToExpirationChanged != null)
                  DaysToExpirationChanged(sender, e);
            }
            else if (sender == numericUpDownMax)
            {
               if (MaximumRememberedChanged != null)
                  MaximumRememberedChanged(sender, e);
            }
            else if (sender == checkBoxIdleTimeout)
            {
               if (IdleTimeoutEnableChanged != null)
                  IdleTimeoutEnableChanged(sender, e);
            }
            else if (sender == numericUpDownIdleTimeout)
            {
               if (IdleTimeoutChanged != null)
                  IdleTimeoutChanged(sender, e);
            }
            else if (sender == radioButtonNamePassword)
            {
               if (LoginTypeChanged != null)
                  LoginTypeChanged(sender, e);
            }
            else if (sender == radioButtonSmartCardPin)
            {
               if (LoginTypeChanged != null)
                  LoginTypeChanged(sender, e);
            }
            else if (sender == radioButtonBoth)
            {
               if (LoginTypeChanged != null)
                  LoginTypeChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      private bool _isDirty = false;

      public bool IsDirty
      {
         get
         {
            return _isDirty;
         }
         private set
         {
            _isDirty = value;
         }
      }

      public event EventHandler SettingsChanged;

      private void OnSettingsChanged(object sender, EventArgs e)
      {
         try
         {
            if (SettingsChanged != null)
            {
               SettingsChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }
   }
}
