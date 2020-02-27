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

namespace Leadtools.Medical.Winforms.ClientManager
{
   public partial class ClientConfigurationOptionsView : UserControl
   {

      private ClientConfigurationOptions _Options;

      public ClientConfigurationOptions Options
      {
         get { return _Options; }
         set
         {
            if (value == null)
            {
               _Options = null;
            }
            else
            {
               _Options = value.Clone() as ClientConfigurationOptions;
            }
            ConfigureView();
         }
      }


      public ClientConfigurationOptionsView()
      {
         InitializeComponent();
         
         // set defaults
         numericUpDownPageSize.Minimum = 2;
         numericUpDownPageSize.Maximum = 5000;
         numericUpDownPageSize.Increment = 10;

         // numericUpDownPageSize.TextChanged += new EventHandler(numericUpDownPageSize_ValueChanged);
         numericUpDownPageSize.ValueChanged += new EventHandler(numericUpDownPageSize_ValueChanged);
         rbPaginationNever.CheckedChanged += new EventHandler(rbPaginationNever_CheckedChanged);
         rbPaginationWhenNecessary.CheckedChanged += new EventHandler(rbPaginationWhenNecessary_CheckedChanged);
         rbPaginationAlways.CheckedChanged += new EventHandler(rbPaginationAlways_CheckedChanged);
         rbLastAccessDateShowDateTime.CheckedChanged += rbLastAccessDateShowDateTime_CheckedChanged;
         rbLastAccessDateShowDateOnly.CheckedChanged += rbLastAccessDateShowDateOnly_CheckedChanged;

         // IsDirty Handlers
         numericUpDownPageSize.ValueChanged += new EventHandler(OnSetIsDirty);
         rbPaginationNever.CheckedChanged += new EventHandler(OnSetIsDirty);
         rbPaginationWhenNecessary.CheckedChanged += new EventHandler(OnSetIsDirty);
         rbPaginationAlways.CheckedChanged += new EventHandler(OnSetIsDirty);

         rbLastAccessDateShowDateTime.CheckedChanged += new EventHandler(OnSetIsDirty);
         rbLastAccessDateShowDateOnly.CheckedChanged += new EventHandler(OnSetIsDirty);
      }

      void numericUpDownPageSize_ValueChanged(object sender, EventArgs e)
      {
         Options.PageSize = Convert.ToInt32(numericUpDownPageSize.Value);
      }      
      
      void rbPaginationNever_CheckedChanged(object sender, EventArgs e)
      {
         if (Options != null)
         {
            if (rbPaginationNever.Checked)
            {
               Options.PaginationDisplay = PaginationDisplayOptions.ShowNever;
            }
         }
      }

      void rbPaginationWhenNecessary_CheckedChanged(object sender, EventArgs e)
      {
         if (Options != null)
         {
            if (rbPaginationWhenNecessary.Checked)
            {
               Options.PaginationDisplay = PaginationDisplayOptions.ShowWhenNecessary;
            }
         }
      }

      void rbPaginationAlways_CheckedChanged(object sender, EventArgs e)
      {
         if (Options != null)
         {
            if (rbPaginationAlways.Checked)
            {
               Options.PaginationDisplay = PaginationDisplayOptions.ShowAlways;
            }
         }
      }

      // ***

      private void rbLastAccessDateShowDateOnly_CheckedChanged(object sender, EventArgs e)
      {
         if (Options != null)
         {
            if (rbLastAccessDateShowDateOnly.Checked)
            {
               Options.LastAccessDateDisplay = LastAccessDateDisplayOptions.ShowDateOnly;
            }
         }
      }

      private void rbLastAccessDateShowDateTime_CheckedChanged(object sender, EventArgs e)
      {
         if (Options != null)
         {
            if (rbLastAccessDateShowDateTime.Checked)
            {
               Options.LastAccessDateDisplay = LastAccessDateDisplayOptions.ShowDateTime;
            }
         }
      }

      public event EventHandler PageSizeChanged = null;
      public event EventHandler PaginationDisplayOptionChanged = null;
      public event EventHandler LastViewDisplayOptionChanged = null;

      public void ConfigureView()
      {
         if (Options != null)
         {
            numericUpDownPageSize.Value = Convert.ToDecimal(Options.PageSize);
            rbPaginationNever.Checked = (PaginationDisplayOptions.ShowNever == Options.PaginationDisplay);
            rbPaginationWhenNecessary.Checked = (PaginationDisplayOptions.ShowWhenNecessary == Options.PaginationDisplay);
            rbPaginationAlways.Checked = (PaginationDisplayOptions.ShowAlways == Options.PaginationDisplay);

            // LastAccessDate
            rbLastAccessDateShowDateOnly.Checked = (LastAccessDateDisplayOptions.ShowDateOnly == Options.LastAccessDateDisplay);
            rbLastAccessDateShowDateTime.Checked = (LastAccessDateDisplayOptions.ShowDateTime == Options.LastAccessDateDisplay);
         }
      }


      private void OnSetIsDirty(object sender, EventArgs e)
      {
         try
         {
            IsDirty = true;
            OnSettingsChanged(sender, e);
            
            if (sender == numericUpDownPageSize && PageSizeChanged != null)
            {
               PageSizeChanged(sender, e);
            }
            else if (sender == rbPaginationNever)
            {
               if (rbPaginationNever.Checked && PaginationDisplayOptionChanged != null)
               {
                  PaginationDisplayOptionChanged(sender, e);
               }
            }
            else if (sender == rbPaginationWhenNecessary)
            {
               if (rbPaginationWhenNecessary.Checked && PaginationDisplayOptionChanged != null)
               {
                  PaginationDisplayOptionChanged(sender, e);
               }
            }
            else if (sender == rbPaginationAlways)
            {
               if (rbPaginationAlways.Checked && PaginationDisplayOptionChanged != null)
               {
                  PaginationDisplayOptionChanged(sender, e);
               }
            }

            if (sender == rbLastAccessDateShowDateOnly)
            {
               if (rbLastAccessDateShowDateOnly.Checked && LastViewDisplayOptionChanged != null)
               {
                  LastViewDisplayOptionChanged(sender, e);
               }
            }
            else if (sender == rbLastAccessDateShowDateTime)
            {
               if (rbLastAccessDateShowDateTime.Checked && LastViewDisplayOptionChanged != null)
               {
                  LastViewDisplayOptionChanged(sender, e);
               }
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
