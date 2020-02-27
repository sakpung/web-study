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
using Leadtools.Medical.Winforms.Forwarder.Scheduling;

namespace Leadtools.Medical.Winforms.Forwarder.Controls
{
   public partial class SchedulerControl : UserControl
   {
      public IntervalType RepeatInterval
      {
         get
         {
            if (comboBoxInterval.SelectedItem == null)
               return IntervalType.Days;

            return (IntervalType)comboBoxInterval.SelectedItem;
         }
         set
         {
            comboBoxInterval.SelectedItem = value;
         }
      }

      public decimal RepeatEvery
      {
         get
         {
            return numericUpDownInterval.Value;
         }

         set
         {
            numericUpDownInterval.Value = value;
         }
      }

      public SchedulerControl()
      {
         // Form parent;

         InitializeComponent();

         comboBoxInterval.Items.Add(IntervalType.Seconds);
         comboBoxInterval.Items.Add(IntervalType.Minutes);
         comboBoxInterval.Items.Add(IntervalType.Hours);
         comboBoxInterval.Items.Add(IntervalType.Days);
         
         // IsDirty handlers
         dateTimePickerStartDate.ValueChanged += new EventHandler(OnSettingsChanged);
         dateTimePickerStartTime.ValueChanged += new EventHandler(OnSettingsChanged);
         dateTimePickerEndDate.ValueChanged += new EventHandler(OnSettingsChanged);
         dateTimePickerEndTime.ValueChanged += new EventHandler(OnSettingsChanged);
         numericUpDownInterval.ValueChanged += new EventHandler(OnSettingsChanged);
         comboBoxInterval.SelectedIndexChanged += new EventHandler(OnSettingsChanged);         
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

      public void SetSchedule(Job job)
      {
         dateTimePickerStartDate.Value = job.StartTime.DateTime;
         dateTimePickerStartTime.Value = job.StartTime.DateTime;
         if (job.ExpirationTime != null)
         {
            dateTimePickerEndDate.Checked = true;
            dateTimePickerEndDate.Value = job.ExpirationTime.Value.DateTime;

            dateTimePickerEndTime.Checked = true;
            dateTimePickerEndTime.Value = job.ExpirationTime.Value.DateTime;
         }
      }

      public Job GetSchedule()
      {
         Job job = new Job();

         job.StartTime = GetStart();
         job.ExpirationTime = GetEnd();
         job.Interval = GetInterval();
         job.IntervalType = RepeatInterval;

         if (job.Interval == null)
         {
            job.Loops = 1;
         }
         return job;
      }

      public DateTime GetStart()
      {
         DateTime dt;
         DateTime sd = dateTimePickerStartDate.Value;
         DateTime st = dateTimePickerStartTime.Value;

         dt = new DateTime(sd.Year, sd.Month, sd.Day, st.Hour, st.Minute, st.Second, st.Millisecond);

         return dt;
      }

      public DateTime? GetEnd()
      {
         if (dateTimePickerEndDate.Checked)
         {
            DateTime dt;
            DateTime ed = dateTimePickerEndDate.Value;
            DateTime et = dateTimePickerEndTime.Value;

            dt = new DateTime(ed.Year, ed.Month, ed.Day, et.Hour, et.Minute, et.Second, et.Millisecond);

            return dt;
         }
         return null;
      }

      private TimeSpan? GetInterval()
      {
         IntervalType interval = (IntervalType)comboBoxInterval.SelectedItem;

         if (numericUpDownInterval.Value == 0)
            return null;

         switch (interval)
         {
            case IntervalType.Seconds:
               return TimeSpan.FromSeconds(Convert.ToDouble(numericUpDownInterval.Value));
            case IntervalType.Minutes:
               return TimeSpan.FromMinutes(Convert.ToDouble(numericUpDownInterval.Value));
            case IntervalType.Hours:
               return TimeSpan.FromHours(Convert.ToDouble(numericUpDownInterval.Value));
            default:
               return TimeSpan.FromDays(Convert.ToDouble(numericUpDownInterval.Value));
         }
      }

      private void comboBoxName_SelectionChangeCommitted(object sender, EventArgs e)
      {

      }

      private void SetRange(string type)
      {
      }

      private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
      {
         dateTimePickerEndTime.Enabled = dateTimePickerEndDate.Checked;
         if (dateTimePickerEndDate.Checked)
         {
            if (dateTimePickerEndTime.Value < SystemTime.Now())
            { 
               DateTime end = SystemTime.Now().LocalDateTime.AddHours(8);

               dateTimePickerEndTime.Value = end;
               dateTimePickerEndDate.Value = end;
            }
         }
      }

      private void dateTimePickerEndDate_Validating(object sender, CancelEventArgs e)
      {
         DateTime? end = GetEnd();

         if (end != null)
         {
            if (end.Value.Date < SystemTime.Now().LocalDateTime.Date)
            {
               string msg = "End date cannot earlier than the current date.";

               errorProvider.SetError(dateTimePickerEndDate, msg);
               e.Cancel = true;
            }
            else
            {
               if (end.Value.Date < GetStart().Date)
               {
                  string msg = "End date must be greater then start date.";

                  errorProvider.SetError(dateTimePickerEndDate, msg);
                  e.Cancel = true;
               }
            }            
         }

         if (!e.Cancel)
         {
            errorProvider.SetError(dateTimePickerEndDate, string.Empty);
         }
      }

      private void dateTimePickerEndTime_Validating(object sender, CancelEventArgs e)
      {
         DateTime? end = GetEnd();

         if (end != null)
         {
            if (end.Value < SystemTime.Now().LocalDateTime)
            {
               string msg = "End time cannot be earlier than the current time.";

               errorProvider.SetError(dateTimePickerEndTime, msg);
               e.Cancel = true;
            }
            else
            {
               if (end.Value < GetStart())
               {
                  string msg = "End time must be greater then start time.";

                  errorProvider.SetError(dateTimePickerEndTime, msg);
                  e.Cancel = true;
               }
            }
         }

         if (!e.Cancel)
         {
            errorProvider.SetError(dateTimePickerEndTime, string.Empty);
         }
      }
   }
}
