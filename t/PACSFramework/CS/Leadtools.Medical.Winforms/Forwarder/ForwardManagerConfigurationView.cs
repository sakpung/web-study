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
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.Winforms.Forwarder.Controls;
using Leadtools.Medical.Winforms.Forwarder.Scheduling;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Forward.DataAccessLayer;
using Leadtools.Medical.Forward.DataAccessLayer.Configuration;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.DicomDemos;
using System.Reflection;
using Leadtools.Medical.Winforms.Properties;
using Leadtools.Medical.Winforms.EventBrokerArgs;

namespace Leadtools.Medical.Winforms.Forwarder
{
   public partial class ForwardManagerConfigurationView : UserControl
   {
      private IForwardDataAccessAgent _forwardAgent;
      private System.Threading.Timer _infoTimer;
      private const int REFRESH_INTERVAL = 1000;

      private ForwardOptions _Options;

      public ForwardOptions Options
      {
         get { return _Options; }        
      }
    
      public bool EnableTools
      {
         get
         {
            return groupBoxTools.Enabled;
         }
         set
         {
            if (value != groupBoxTools.Enabled)
            {
               groupBoxTools.Enabled = value;               
            }
            panelWarning.Visible = !value;
         }
      }

      public bool Enable
      {
         get
         {
            return base.Enabled;
         }
         set
         {
            base.Enabled = value;
            tabControlForward.Enabled = base.Enabled;
         }
      }

      public event EventHandler<ForwardMessageEventArgs> Forward;

      protected void OnForward(string destination)
      {
         if (Forward != null)
         {
            ForwardMessageEventArgs e = new ForwardMessageEventArgs(ForwarderMessage.Forward, destination);

            Forward(this, e);
         }
      }

      public event EventHandler<SendMessageEventArgs> Clean;

      protected void OnClean()
      {
         if (Clean != null)
         {
            SendMessageEventArgs e = new SendMessageEventArgs(ForwarderMessage.Clean);

            Clean(this, e);
         }
      }

      public event EventHandler<ResetEventArgs> Reset;

      protected void OnReset(DateTime start, DateTime? end)
      {
         if (Reset != null)
         {
            ResetEventArgs e = new ResetEventArgs(ForwarderMessage.Reset,start,end);

            Reset(this, e);
         }
      }

      public ForwardManagerConfigurationView()
      {
         InitializeComponent();
         
         // IsDirty Handlers
         checkBoxForwardEnable.CheckedChanged         += new EventHandler(OnSettingsChanged);
         schedulerControlForward.SettingsChanged      += new EventHandler(OnSettingsChanged);
         comboBoxForwardTo.SelectedIndexChanged       += new EventHandler(OnSettingsChanged);
         checkBoxCleanEnable.CheckedChanged           += new EventHandler(OnSettingsChanged);
         schedulerControlClean.SettingsChanged        += new EventHandler(OnSettingsChanged);
         numericUpDownHoldAmount.ValueChanged         +=new EventHandler(OnSettingsChanged);
         comboBoxHoldInterval.SelectedIndexChanged    += new EventHandler(OnSettingsChanged);
         checkBoxCustomAE.CheckedChanged              += new EventHandler(OnSettingsChanged);
         textBoxCustomAE.TextChanged                  += new EventHandler(OnSettingsChanged);
         checkBoxVerify.CheckedChanged                += new EventHandler(OnSettingsChanged);
         comboBoxToolForwardTo.SelectedIndexChanged   += new EventHandler(OnSettingsChanged);
         comboBoxReset.SelectedIndexChanged           += new EventHandler(OnSettingsChanged);
         dateTimePickerResetStart.ValueChanged        += new EventHandler(OnSettingsChanged);
         dateTimePickerResetEnd.ValueChanged          += new EventHandler(OnSettingsChanged);
      }

      private event EventHandler _settingsChanged;
      public event EventHandler SettingsChanged
      {
         add
         {
            _settingsChanged += value;
         }
         remove
         {
            _settingsChanged -= value;
         }
      }



      private void OnSettingsChanged(object sender, EventArgs e)
      {
         try
         {
            if (_settingsChanged != null)
            {
               _settingsChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      public void Initialize(ForwardOptions options)
      {
         _Options = options;
         if (_Options == null)
            return;         

         InitializeSchedule(_Options.Forward, schedulerControlForward);
         InitializeSchedule(_Options.Clean, schedulerControlClean);
         InitializeInterval();

         if (options.Forward != null && options.Forward.ExpirationTime < DateTime.Now)
         {
            checkBoxForwardEnable.Checked = false;
         }
         else
         {
            checkBoxForwardEnable.Checked = options.Forward != null;
         }

         if (options.Clean != null && options.Clean.ExpirationTime < DateTime.Now)
         {
            checkBoxCleanEnable.Checked = false;
         }
         else
         {
            checkBoxCleanEnable.Checked = options.Clean != null;
         }
         
         EnableForward(checkBoxForwardEnable.Checked);
         EnableClean(checkBoxCleanEnable.Checked);

         comboBoxHoldInterval.Items.Clear();
         comboBoxHoldInterval.Items.Add(HoldInterval.Days);
         comboBoxHoldInterval.Items.Add(HoldInterval.Months);
         comboBoxHoldInterval.Items.Add(HoldInterval.Years);
         comboBoxHoldInterval.SelectedItem = _Options.HoldInterval;
         checkBoxVerify.Checked = _Options.Verify;
         if (_Options.ImageHold != null)
            numericUpDownHoldAmount.Value = Convert.ToDecimal(_Options.ImageHold);

         checkBoxCustomAE.Checked = _Options.UseCustomAE;
         textBoxCustomAE.Text = _Options.CustomAE;
         checkBoxCustomAE_CheckedChanged(checkBoxCustomAE, EventArgs.Empty);
         comboBoxReset.Text = "Today";
         comboBoxReset_SelectionChangeCommitted(comboBoxReset, EventArgs.Empty);
         dateTimePickerResetEnd_ValueChanged(dateTimePickerResetEnd, EventArgs.Empty);

         InitializeDataAccess();
      }

      private void InitializeSchedule(Job job, SchedulerControl scheduler)
      {
         if (job != null)
         {                      
            scheduler.SetSchedule(job);
         }
      }

      private void InitializeInterval()
      {         
         SetJobInterval(_Options.Forward, schedulerControlForward);
         SetJobInterval(_Options.Clean, schedulerControlClean);         
      }

      private void InitializeDataAccess()
      {
         if (!DataAccessServices.IsDataAccessServiceRegistered<IForwardDataAccessAgent>())
         {
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();
            _forwardAgent = DataAccessFactory.GetInstance(new ForwardDataAccessConfigurationView(configuration, PacsProduct.ProductName, PacsProduct.ServiceName) ).CreateDataAccessAgent<IForwardDataAccessAgent>();
            DataAccessServices.RegisterDataAccessService<IForwardDataAccessAgent>(_forwardAgent);
         }
         else
            _forwardAgent = DataAccessServices.GetDataAccessService<IForwardDataAccessAgent>();

         if (_forwardAgent != null)
         {
            _infoTimer = new System.Threading.Timer(new System.Threading.TimerCallback(UpdateCount));
            VisibleChanged += new EventHandler(ForwardManagerConfigurationView_VisibleChanged);
            if(Visible)
               _infoTimer.Change(REFRESH_INTERVAL, REFRESH_INTERVAL);
         }
      }

      void ForwardManagerConfigurationView_VisibleChanged(object sender, EventArgs e)
      {
         if (Visible && _infoTimer!=null)
         {
            _infoTimer.Change(0, REFRESH_INTERVAL);
         }
         else if(!Visible && _infoTimer!=null)
         {
            _infoTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
         }
      }

      private void UpdateCount(object data)
      {
         _infoTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
         if (!Visible)
            return;

         try
         {
            long forwardCount = 0;
            long cleanCount = 0;

            try
            {
               forwardCount = _forwardAgent.GetForwardCount();
            }
            catch { }

            try
            {
               cleanCount = _forwardAgent.GetCleanCount();
            }
            catch { }

            AsyncHelper.SynchronizedInvoke(this, () =>
               {
                  labelForwardInfo.Text = GetCountString(forwardCount, "forward");
                  labelCleanInfo.Text = GetCountString(cleanCount, "clean");
                  buttonForward.Enabled = forwardCount > 0 && EnableTools;
                  buttonClean.Enabled = cleanCount > 0 && EnableTools;
                  GetResetCount();
               });
         }
         catch { }
         finally
         {           
            if (Visible)
            {
               _infoTimer.Change(REFRESH_INTERVAL, REFRESH_INTERVAL);
            }
         }
      }

      public static string GetCountString(long count, string process)
      {
         string info;

         if (count == 1)
            info = "1 dataset to ";
         else
            info = string.Format("{0} datasets to ", count);
         info += process;
         return info;
      }

      public static void SetJobInterval(Job job, SchedulerControl scheduler)
      {
         if (job!=null && job.Interval != null)
         {
            TimeSpan interval = job.Interval.Value;

            if (job.IntervalType== IntervalType.Seconds)
            {
               scheduler.RepeatEvery = Convert.ToDecimal(interval.TotalSeconds);
               scheduler.RepeatInterval = IntervalType.Seconds;
            }
            else if (job.IntervalType == IntervalType.Minutes)
            {
               scheduler.RepeatEvery = Convert.ToDecimal(interval.TotalMinutes);
               scheduler.RepeatInterval = IntervalType.Minutes;
            }
            else if (job.IntervalType == IntervalType.Hours)
            {
               scheduler.RepeatEvery = Convert.ToDecimal(interval.TotalHours);
               scheduler.RepeatInterval = IntervalType.Hours;
            }
            else if (job.IntervalType == IntervalType.Days)
            {
               scheduler.RepeatEvery = Convert.ToDecimal(interval.TotalDays);
               scheduler.RepeatInterval = IntervalType.Days;
            }
         }
         else
         {
            scheduler.RepeatEvery = 0;
            scheduler.RepeatInterval = IntervalType.Days;
         }
      }

      public static void EnableGroup(GroupBox group, bool enable)
      {
         foreach (System.Windows.Forms.Control control in group.Controls)
         {
            if (!(control is CheckBox))
            {
               control.Enabled = enable;
            }
         }         
      }

      public void EnableForward(bool enable)
      {
         EnableGroup(groupBoxForward, checkBoxForwardEnable.Checked);         
      }

      public void EnableClean(bool enable)
      {
         EnableGroup(groupBoxClean, checkBoxCleanEnable.Checked);
      }

      public void SetAeTitles(AeInfo[] aetitles)
      {
         comboBoxForwardTo.Items.Clear();
         comboBoxToolForwardTo.Items.Clear();
         foreach (AeInfo aetitle in aetitles)
         {
            comboBoxForwardTo.Items.Add(aetitle.AETitle);
            comboBoxToolForwardTo.Items.Add(aetitle.AETitle);
         }

         if(_Options!=null)
            comboBoxForwardTo.SelectedItem = _Options.ForwardTo;
         comboBoxToolForwardTo.SelectedIndex = comboBoxForwardTo.SelectedIndex;
      }

      public void AddAeTitle(AeInfo aetitle)
      {
         comboBoxForwardTo.Items.Add(aetitle.AETitle);
         comboBoxToolForwardTo.Items.Add(aetitle.AETitle);
      }

      public void RemoveClient(string aetitle)
      {
         int index = -1;

         index = comboBoxForwardTo.Items.IndexOf(aetitle);
         if (index != -1)
         {
            comboBoxForwardTo.Items.RemoveAt(index);
            comboBoxToolForwardTo.Items.RemoveAt(index);
         }
      }

      public void UpdateClient(string oldAe, AeInfo aetitle)
      {
         if (oldAe != aetitle.AETitle)
         {
            int index = comboBoxForwardTo.Items.IndexOf(oldAe);

            if (index != -1)
            {
               comboBoxForwardTo.Items[index] = aetitle.AETitle;
               comboBoxToolForwardTo.Items[index] = aetitle.AETitle;
            }
         }
      }

      private void checkBoxForwardEnable_CheckedChanged(object sender, EventArgs e)
      {
         EnableForward(checkBoxForwardEnable.Checked);
      }

      private void checkBoxCleanEnable_CheckedChanged(object sender, EventArgs e)
      {
         EnableClean(checkBoxCleanEnable.Checked);
      }

      public void UpdateSettings()
      {
         if (_Options == null)
            return;

         if (checkBoxForwardEnable.Checked)
            _Options.Forward = schedulerControlForward.GetSchedule();
         else
            _Options.Forward = null;

         if (checkBoxCleanEnable.Checked)
            _Options.Clean = schedulerControlClean.GetSchedule();
         else
            _Options.Clean = null;

         try
         {
            _Options.ForwardTo = comboBoxForwardTo.Text;
         }
         catch 
         {
            _Options.ForwardTo = string.Empty;
         }

         _Options.HoldInterval = (HoldInterval)comboBoxHoldInterval.SelectedItem;
         _Options.Verify = checkBoxVerify.Checked;

         if (numericUpDownHoldAmount.Value != 0)
         {
            _Options.ImageHold = Convert.ToInt32(numericUpDownHoldAmount.Value);
         }
         else
            _Options.ImageHold = null;

         _Options.UseCustomAE = checkBoxCustomAE.Checked;
         _Options.CustomAE = textBoxCustomAE.Text;
      }

      private void checkBoxCustomAE_CheckedChanged(object sender, EventArgs e)
      {
         textBoxCustomAE.Enabled = checkBoxCustomAE.Checked;
      }

      private void comboBoxReset_SelectionChangeCommitted(object sender, EventArgs e)
      {
         DateTime now = DateTime.Now;

         switch (comboBoxReset.Text)
         {               
            case "Today":
               SetDate(DateTime.Today, null);
               break;
            case "Yesterday":
               SetDate(now.AddDays(-1), null);
               break;  
            case "This Week":
               SetDate(now.StartOfWeek(), now.EndOfWeek());
               break;
            case "Last Week":
               SetDate(now.StartOfLastWeek(), now.EndOfLastWeek());
               break;
            default:
               if (dateTimePickerResetStart.Value > dateTimePickerResetEnd.Value)
                  SetDate(dateTimePickerResetStart.Value, dateTimePickerResetStart.Value.AddDays(1));
               dateTimePickerResetEnd.Checked = comboBoxReset.Text == "Date Range";               
               break;
               
         }

         GetResetCount();
      }

      private void SetDate(DateTime start, DateTime? end)
      {
         dateTimePickerResetStart.ValueChanged -= dateTimePickerResetStart_ValueChanged;
         if (end.HasValue)
         {
            dateTimePickerResetEnd.ValueChanged -= dateTimePickerResetEnd_ValueChanged;            
            if (end.Value < start)
               end = start.AddDays(1);
            dateTimePickerResetEnd.Value = end.Value;
            dateTimePickerResetEnd.Checked = true;            
            dateTimePickerResetEnd.ValueChanged += dateTimePickerResetEnd_ValueChanged;
         }
         else
         {
            dateTimePickerResetEnd.Checked = false;
         }

         dateTimePickerResetStart.Value = start;
         dateTimePickerResetStart.ValueChanged += dateTimePickerResetStart_ValueChanged;
      }

      private void dateTimePickerResetEnd_ValueChanged(object sender, EventArgs e)
      {
         if (!dateTimePickerResetEnd.Checked)
         {
            comboBoxReset.Text = "Date";
         }
         else
         {
            comboBoxReset.Text = "Date Range";            
         }
         labelEndDate.Text = dateTimePickerResetEnd.Value.DayOfWeek.ToString();
         labelEndDate.Enabled = dateTimePickerResetEnd.Checked;
         GetResetCount();
      }

      private void buttonForward_Click(object sender, EventArgs e)
      {
         try
         {
            string message;
            long count = _forwardAgent.GetForwardCount();

            if (_infoTimer != null)
            {
               _infoTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            }
            message = string.Format("This will attempt to forward {0} {1} to the server {2}.\r\n\r\nDo you want to continue?",
                                    count, count == 1 ? "dataset" : "datasets", comboBoxToolForwardTo.Text /*_Options.ForwardTo*/ );

            if (MessageBox.Show(message, "Forward", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
               OnForward(comboBoxToolForwardTo.Text);
               buttonForward.Enabled = false;
            }
         }
         finally
         {
            if (_infoTimer != null)
            {
               _infoTimer.Change(REFRESH_INTERVAL, REFRESH_INTERVAL);
            }
         }
      }

      private void buttonClean_Click(object sender, EventArgs e)
      {
         long count = _forwardAgent.GetCleanCount();
         string message = string.Format("You are about to clean (remove) {0} forwarded {1} from the database.\n\nDo you want to continue?\n\nType the reason for removing the forwarded {1}.",count,
                                          count==1?"dataset":"datasets");

            using (ConfirmWithReasonDialog confirmDlg = new ConfirmWithReasonDialog())
            {
               confirmDlg.Text = "Confirm Clean Forwarded Datasets";

               confirmDlg.Message = message;

               confirmDlg.ConfirmIcon = Resources.Warning_128;
               
               confirmDlg.ConfirmCheckBoxVisible = true;

               if (confirmDlg.ShowDialog(this) != DialogResult.OK)
               {
                  return;
               }

               EventBroker.Instance.PublishEvent<CleanForwardedDatasetsEventArgs>(this, new CleanForwardedDatasetsEventArgs(confirmDlg.Reason, count));

               OnClean();
            }
      }

      private void buttonReset_Click(object sender, EventArgs e)
      {
         string message;

         if (dateTimePickerResetEnd.Checked)
         {
            message = string.Format("This will reset the 'Forward Date' on all images that were forwarded\n\tfrom:\t{0} \n\tto:\t{1}.\n\nDo you want to continue?",
                                    dateTimePickerResetStart.Value.ToLongDateString(), dateTimePickerResetEnd.Value.ToLongDateString());
         }
         else
            message = string.Format("This will reset the 'Forward Date' on all images that were forwarded on {0}.\n\nDo you want to continue?",
                                    dateTimePickerResetStart.Value.ToLongDateString());

         if (MessageBox.Show(message, "Reset Forward Date", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
         {
            OnReset(dateTimePickerResetStart.Value, dateTimePickerResetEnd.Checked ? dateTimePickerResetEnd.Value : (DateTime?)null);
         }
      }

      private void dateTimePickerResetStart_ValueChanged(object sender, EventArgs e)
      {
         labelStartDay.Text = dateTimePickerResetStart.Value.DayOfWeek.ToString();
         if (!dateTimePickerResetEnd.Checked)
         {
            comboBoxReset.Text = "Date";
         }
         else
         {
            comboBoxReset.Text = "Date Range";
         }
         GetResetCount();
      }

      private void GetResetCount()
      {
         if (dateTimePickerResetEnd.Checked)
         {
            if (dateTimePickerResetEnd.Value < dateTimePickerResetStart.Value)
               return;
         }

         if (_forwardAgent != null)
         {            
            DateRange range = new DateRange() { StartDate = dateTimePickerResetStart.Value };
            long count = 0;

            if (dateTimePickerResetEnd.Checked)
               range.EndDate = dateTimePickerResetEnd.Value;

            try
            {
               count = _forwardAgent.GetResetCount(range);
            }
            catch { }

            buttonReset.Enabled = count > 0 && EnableTools;
            if (count == 1)
               labelResetInfo.Text = "1 dataset will be reset ";
            else
               labelResetInfo.Text = string.Format("{0} datasets will be reset", count);
         }
      }

#if LEADTOOLS_V18_OR_LATER
      public event EventHandler<EventArgs> CancelForward;
      protected void OnCancelForward()
      {
         if (CancelForward != null)
         {
            CancelForward(this, new EventArgs());
         }
      }

      public event EventHandler<EventArgs> CancelClean;
      protected void OnCancelClean()
      {
         if (CancelClean != null)
         {
            CancelClean(this, new EventArgs());
         }
      }

      private void buttonCancelForward_Click(object sender, EventArgs e)
      {
         const string message = "This will cancel any pending 'Forward'.\n\nDo you want to continue?";

         if (MessageBox.Show(message, @"Cancel Pending 'Forward'", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
         {
            OnCancelForward();
         }
      }

      private void buttonCancelClean_Click(object sender, EventArgs e)
      {
         const string message = "This will cancel any pending 'Clean'.\n\nDo you want to continue?";

         if (MessageBox.Show(message, @"Cancel Pending 'Clean'", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
         {
            OnCancelClean();
         }
      }
#endif // #if LEADTOOLS_V18_OR_LATER
   }
}
