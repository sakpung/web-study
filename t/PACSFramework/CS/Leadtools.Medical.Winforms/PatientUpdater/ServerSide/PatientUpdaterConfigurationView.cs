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
using Leadtools.Dicom.Scp.Command.NAction.PatientUpdater;
using Leadtools.Dicom.AddIn.Common;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Reflection;
using Leadtools.Dicom.AddIn.Controls;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer;

namespace Leadtools.Medical.Winforms
{
   public partial class PatientUpdaterConfigurationView : UserControl
   {
      public PatientUpdaterConfigurationView()
      {
         InitializeComponent();
         
         RegisterEvents ( ) ;
      }

      public PatientUpdaterOptions Options
      {
         get { return _Options; }        
      }

      public event EventHandler RequireStationNameChanged = null;
      public event EventHandler RequireOperatorsNameChanged = null;
      public event EventHandler RequireTransactionUidChanged = null;
      public event EventHandler RequireTransactionDateChanged = null;
      public event EventHandler RequireTransactionTimeChanged = null;
      public event EventHandler RequireDescriptionChanged = null;
      public event EventHandler RequireReasonChanged = null;
      public event EventHandler AutoUpdateEnableChanged = null;

      public event EventHandler EnableRetryChanged = null;
      public event EventHandler RetrySecondsChanged = null;
      public event EventHandler RetryExpirationDaysChanged = null;
      public event EventHandler RetryDirectoryChanged = null;
      public event EventHandler UseCustomAeTitleChanged = null;
      public event EventHandler CustomAeTitleChanged = null;
      public event EventHandler AutoUpdateProcessingThreadsChanged = null;

   
      private void RegisterEvents()
      {
         this.Load                                          += new EventHandler ( PatientUpdaterConfigurationView_Load ) ;
         this.checkBoxAutoUpdate.CheckedChanged             += new System.EventHandler(this.checkBoxAutoUpdate_CheckedChanged);
         this.comboBoxSource.SelectionChangeCommitted       += new System.EventHandler(this.comboBoxSource_SelectionChangeCommitted);
         this.listViewAutoUpdate.ItemChecked                += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewAutoUpdate_ItemChecked);
         this.checkBoxCustomAE.CheckedChanged               += new System.EventHandler(this.checkBoxCustomAE_CheckedChanged);
         this.checkBoxRetry.CheckedChanged                  += new System.EventHandler(this.checkBoxRetry_CheckedChanged);
         this.buttonFolder.Click                            += new System.EventHandler(this.buttonFolder_Click);

         this.checkBoxStation.CheckedChanged                += new EventHandler(OnSetIsDirty);
         this.checkBoxOperator.CheckedChanged               += new EventHandler(OnSetIsDirty);
         this.checkBoxTransaction.CheckedChanged            += new EventHandler(OnSetIsDirty);
         this.checkBoxDate.CheckedChanged                   += new EventHandler(OnSetIsDirty);
         this.checkBoxTime.CheckedChanged                   += new EventHandler(OnSetIsDirty);
         this.checkBoxDescription.CheckedChanged            += new EventHandler(OnSetIsDirty);
         this.checkBoxReason.CheckedChanged                 += new EventHandler(OnSetIsDirty);
         
         this.checkBoxRetry.CheckedChanged                  += new EventHandler(OnSetIsDirty);
         this.numericUpDownsSecs.ValueChanged               += new EventHandler(OnSetIsDirty);
         this.numericUpDownDays.ValueChanged                += new EventHandler(OnSetIsDirty);
         this.textBoxDir.TextChanged                        += new EventHandler(OnSetIsDirty);

         this.checkBoxCustomAE.CheckedChanged               += new EventHandler(OnSetIsDirty);
         this.textBoxCustomAE.TextChanged                   += new EventHandler(OnSetIsDirty);
         this.numericUpDownThreads.ValueChanged             += new EventHandler(OnSetIsDirty);

         this.listViewPatientUpdaterMessages.ItemCheck += ListViewPatientUpdaterMessages_ItemCheck;
      }

      private void ListViewPatientUpdaterMessages_ItemCheck(object sender, ItemCheckEventArgs e)
      {
         ListView listView = sender as ListView;
         if (listView != null)
         {
            ListViewItem item = listView.Items[e.Index];
            bool oldChecked = GetAutoUpdateOption(_Options.AutoUpdateOptions, item.Text);
            if (
               ((oldChecked == false) && (e.NewValue == CheckState.Checked)) ||
               ((oldChecked == true) && (e.NewValue == CheckState.Unchecked))
               )
            {
               OnSetIsDirty(sender, e);
            }
         }
      }

      private static void GetAddAutoUpdateOptions(ListView listView, AutoUpdateOptions options)
      {
         listView.Items.Clear();

         Type myType = options.GetType();
         IList<PropertyInfo> myProps = new List<PropertyInfo>(myType.GetProperties());
         foreach (PropertyInfo prop in myProps)
         {
            foreach (Attribute a in prop.GetCustomAttributes(false))
            {
               IntValueAttribute iva = a as IntValueAttribute;
               if (iva != null)
               {
                  ListViewItem item = new ListViewItem(prop.Name);
                  bool ret = (bool)prop.GetValue(options, null);
                  item.Checked = ret;
                  listView.Items.Add(item);
               }
            }
         }
      }

      static bool GetAutoUpdateOption(AutoUpdateOptions options, string name)
      {
         Type myType = options.GetType();
         IList<PropertyInfo> myProps = new List<PropertyInfo>(myType.GetProperties());
         foreach (PropertyInfo prop in myProps)
         {
            foreach (Attribute a in prop.GetCustomAttributes(false))
            {
               IntValueAttribute iva = a as IntValueAttribute;
               if (iva != null)
               {
                  if (prop.Name == name)
                  {
                     bool ret = (bool)prop.GetValue(options, null);
                     return ret;
                  }
               }
            }
         }
         return false;
      }

      static void SetAutoUpdateOption(AutoUpdateOptions options, string name, bool value)
      {
         Type myType = options.GetType();
         IList<PropertyInfo> myProps = new List<PropertyInfo>(myType.GetProperties());
         foreach (PropertyInfo prop in myProps)
         {
            foreach (Attribute a in prop.GetCustomAttributes(false))
            {
               IntValueAttribute iva = a as IntValueAttribute;
               if (iva != null)
               {
                  if (prop.Name == name)
                  {
                     prop.SetValue(options, value, null);
                     return;
                  }
               }
            }
         }
      }

      private void SetAddAutoUpdateOptions(ListView listView, AutoUpdateOptions options)
      {
         foreach(ListViewItem item in listView.Items)
         {
            SetAutoUpdateOption(options, item.Text, item.Checked);
         }
      }
      public void Initialize( PatientUpdaterOptions options, IAeManagementDataAccessAgent accessAgent )
      {
         _Options = options ;
         
         // Request Dataset Validation
         checkBoxStation.Checked = _Options.ValidateStationName;
         checkBoxOperator.Checked = _Options.ValidateOperatorsName;
         checkBoxTransaction.Checked = _Options.ValidateTransactionUID;
         checkBoxDate.Checked = _Options.ValidateDate;
         checkBoxTime.Checked = _Options.ValidateTime;
         checkBoxDescription.Checked = _Options.ValidateDescription;
         checkBoxReason.Checked = _Options.ValidateReason;

         // AutoUpdate
         checkBoxAutoUpdate.Checked = _Options.EnableAutoUpdate;

         // AutoUpdate Retry
         checkBoxRetry.Checked = _Options.EnableRetry;
         numericUpDownDays.Value = Convert.ToDecimal(_Options.RetryDays);
         numericUpDownsSecs.Value = Convert.ToDecimal(_Options.RetrySeconds);
         textBoxDir.Text = _Options.RetryDirectory;

         // AutoUpdate Messages
         GetAddAutoUpdateOptions(listViewPatientUpdaterMessages, _Options.AutoUpdateOptions);

         // AutoUpdate Advanced
         checkBoxCustomAE.Checked = _Options.UseCustomAE;
         textBoxCustomAE.Text = _Options.AutoUpdateAE;
         numericUpDownThreads.Value = Convert.ToDecimal(_Options.AutoUpdateThreads);

         _AccessAgent = accessAgent ;
         EnableAutoUpdate();
      }
      
      public void UpdateSettings ( )
      {

         // Request Dataset Validation
         _Options.ValidateStationName = checkBoxStation.Checked;
         _Options.ValidateOperatorsName = checkBoxOperator.Checked;
         _Options.ValidateTransactionUID = checkBoxTransaction.Checked;
         _Options.ValidateDate = checkBoxDate.Checked;
         _Options.ValidateTime = checkBoxTime.Checked;
         _Options.ValidateDescription = checkBoxDescription.Checked;
         _Options.ValidateReason = checkBoxReason.Checked;

         // AutoUpdate         
         _Options.EnableAutoUpdate = checkBoxAutoUpdate.Checked;

         // AutoUpdate Retry
         _Options.EnableRetry = checkBoxRetry.Checked;
         _Options.RetryDays = Convert.ToInt32(numericUpDownDays.Value);
         _Options.RetrySeconds = Convert.ToInt32(numericUpDownsSecs.Value);
         _Options.RetryDirectory = textBoxDir.Text;

         // AutoUpdate Messages
         SetAddAutoUpdateOptions(listViewPatientUpdaterMessages, _Options.AutoUpdateOptions);

         // AutoUpdate Advanced
         _Options.UseCustomAE = checkBoxCustomAE.Checked;
         _Options.AutoUpdateAE = textBoxCustomAE.Text;
         _Options.AutoUpdateThreads = Convert.ToInt32(numericUpDownThreads.Value);
      }

      private void EnableAutoUpdate()
      {
         comboBoxSource.Enabled = checkBoxAutoUpdate.Checked;
         checkBoxCustomAE.Enabled = checkBoxAutoUpdate.Checked;
         textBoxCustomAE.Enabled = checkBoxCustomAE.Checked && checkBoxAutoUpdate.Checked;
         numericUpDownThreads.Enabled = checkBoxAutoUpdate.Checked;
         checkBoxRetry.Enabled = checkBoxAutoUpdate.Checked;
         numericUpDownDays.Enabled = checkBoxRetry.Checked && checkBoxAutoUpdate.Checked;
         numericUpDownsSecs.Enabled = checkBoxRetry.Checked && checkBoxAutoUpdate.Checked;
         buttonFolder.Enabled = checkBoxRetry.Checked && checkBoxAutoUpdate.Checked;
         if (checkBoxAutoUpdate.Checked)
         {
            LoadAeTitles();
         }
         else
         {
            comboBoxSource.Items.Clear();
            listViewAutoUpdate.Items.Clear();
         }
      }
      
      public bool RequireStationName
      {
         get
         {
            return checkBoxReason.Checked;
         }
      }
      
      public bool RequireOperatersName
      {
         get
         {
            return this.checkBoxOperator.Checked;
         }
      }
      
      public bool RequireTransactionUid
      {
         get
         {
            return this.checkBoxTransaction.Checked;
         }
      }
      
      public bool RequireTransactionDate
      {
         get
         {
            return this.checkBoxDate.Checked;
         }
      }
      
      public bool RequireTransactionTime
      {
         get
         {
            return this.checkBoxTime.Checked;
         }
      }
      
      public bool RequireDescription
      {
         get
         {
            return this.checkBoxDescription.Checked;
         }
      }
      
      public bool RequireReason
      {
         get
         {
            return this.checkBoxReason.Checked;
         }
      }
      
      public bool AutoUpdateEnable
      {
         get
         {
            return this.checkBoxAutoUpdate.Checked;
         }
      }
      
      
       public bool EnableRetry
      {
         get
         {
            return this.checkBoxRetry.Checked;
         }
      }
      
      public int RetrySeconds
      {
         get
         {
            return Convert.ToInt32(numericUpDownsSecs.Value);
         }
      }

      public int RetryExpirationDays
      {
         get
         {
            return Convert.ToInt32(numericUpDownDays.Value);
         }
      }

      public string RetryDirectory
      {
         get
         {
            return textBoxDir.Text;
         }
      }

      public bool UseCustomAeTitle
      {
         get
         {
            return this.checkBoxCustomAE.Checked;
         }
      }

      public string CustomAeTitle
      {
         get
         {
            return textBoxCustomAE.Text;
         }

      }

      public int AutoUpdateProcessingThreads
      {
         get
         {
            return Convert.ToInt32(numericUpDownThreads.Value);
         }
      }
      
      
      private void LoadAeTitles()
      {
         AeInfo[] aetitles = _AccessAgent.GetAeTitles();

         try
         {
            comboBoxSource.Items.Clear ( ) ;
            listViewAutoUpdate.Items.Clear ( ) ;
            _SelectedItem = null;
            _SelectedIndex = -1;
            
            listViewAutoUpdate.ItemChecked -= listViewAutoUpdate_ItemChecked;
            foreach (AeInfo info in aetitles)
            {
               comboBoxSource.Items.Add(info);
               AddToList(info);
            }
         }
         finally
         {
            listViewAutoUpdate.ItemChecked += listViewAutoUpdate_ItemChecked;
         }
      }

      public void AddAeTitle(AeInfo aetitle)
      {
         listViewAutoUpdate.ItemChecked -= listViewAutoUpdate_ItemChecked;
         comboBoxSource.Items.Add(aetitle);
         AddToList(aetitle);
         listViewAutoUpdate.ItemChecked += listViewAutoUpdate_ItemChecked;
      }

      public void RemoveAeTitle(string aetitle)
      {
         int index = -1;

         foreach (AeInfo info in comboBoxSource.Items)
         {
            if (info.AETitle == aetitle)
            {
               index = comboBoxSource.Items.IndexOf(info);
               break;
            }
         }

         if (index != -1)
         {
            listViewAutoUpdate.ItemChecked -= listViewAutoUpdate_ItemChecked;
            comboBoxSource.Items.RemoveAt(index);
            index = -1;
            foreach (ListViewItem item in listViewAutoUpdate.Items)
            {
               AeInfo i = item.Tag as AeInfo;

               if (i.AETitle == aetitle)
               {
                  index = item.Index;
                  break;
               }
            }

            if (index != -1)
            {
               listViewAutoUpdate.Items.RemoveAt(index);
            }
            listViewAutoUpdate.ItemChecked += listViewAutoUpdate_ItemChecked;

            if (_SelectedItem != null)
            {
               if ((_SelectedItem.Tag as AeInfo).AETitle == aetitle)
               {
                  _SelectedItem = null;
                  _SelectedIndex = 0;
               }
            }
         }
      }
      
      private void AddToList(AeInfo info)
      {
         ListViewItem item = new ListViewItem(info.AETitle);

         item.SubItems.Add(info.Address);
         item.SubItems.Add(info.Port.ToString());
         item.Tag = info;
         listViewAutoUpdate.Items.Add(item);         
      }
      
      private void GetRelatedAes(AeInfo info)
      {
         AeInfo[] aes = _AccessAgent.GetRelatedAeTitles(info.AETitle, UPDATE_RELATION);
        
         foreach(AeInfo ae in aes)
         {
            ListViewItem item = listViewAutoUpdate.Items.Cast<ListViewItem>().Where(i => i.Text == ae.AETitle).FirstOrDefault();

            if (item != null)
               item.Checked = true;
         }
      }
      
      private void checkBoxAutoUpdate_CheckedChanged(object sender, EventArgs e)
      {
         if (_AccessAgent == null)
            return;

         EnableAutoUpdate();
         OnSetIsDirty(sender, e);
      }
      
      private void comboBoxSource_SelectionChangeCommitted(object sender, EventArgs e)
      {
         AeInfo info = comboBoxSource.SelectedItem as AeInfo;

         listViewAutoUpdate.ItemChecked -= listViewAutoUpdate_ItemChecked;
         listViewAutoUpdate.Check(false);
         try
         {
            listViewAutoUpdate.Enabled = checkBoxAutoUpdate.Checked;            
            if (_SelectedItem != null)
            {
               listViewAutoUpdate.Items.Insert(_SelectedIndex, _SelectedItem);
            }

            foreach (ListViewItem item in listViewAutoUpdate.Items)
            {
               AeInfo i = item.Tag as AeInfo;

               if (i.Address == info.Address && i.AETitle == info.AETitle)
               {
                  _SelectedItem = item;
                  _SelectedIndex = listViewAutoUpdate.Items.IndexOf(item);
                  break;
               }
            }

            if (_SelectedItem != null)
            {
               listViewAutoUpdate.Items.Remove(_SelectedItem);
            }
            GetRelatedAes(info);
         }
         finally
         {
            listViewAutoUpdate.ItemChecked += listViewAutoUpdate_ItemChecked;
            OnSetIsDirty( sender, e);
         }
      }
      
      private void listViewAutoUpdate_ItemChecked(object sender, ItemCheckedEventArgs e)
      {
         AeInfo info = comboBoxSource.SelectedItem as AeInfo;

         if ( null == info ) 
         {
            return ;
         }
         
         if(e.Item.Checked)
         {
            _AccessAgent.AddReleation(info.AETitle, e.Item.Text, UPDATE_RELATION);
         }
         else
         {
            _AccessAgent.RemoveRelation(info.AETitle, e.Item.Text, UPDATE_RELATION);
         }
         OnSetIsDirty(sender, e);
      }
      
      private void checkBoxCustomAE_CheckedChanged(object sender, EventArgs e)
      {
         textBoxCustomAE.Enabled = checkBoxCustomAE.Checked;
         OnSetIsDirty(sender, e);
      }
      
      private void checkBoxRetry_CheckedChanged(object sender, EventArgs e)
      {
         numericUpDownsSecs.Enabled = checkBoxRetry.Checked;
         numericUpDownDays.Enabled = checkBoxRetry.Checked;
         buttonFolder.Enabled = checkBoxRetry.Checked;
         OnSetIsDirty(sender, e);
      }
      
      private void buttonFolder_Click(object sender, EventArgs e)
      {
         using (FolderBrowserDialog dlgBrowser = new FolderBrowserDialog())
         {
            dlgBrowser.Description = "Select folder to store retry information.";
            if (textBoxDir.Text.Length > 0)
            {
               dlgBrowser.SelectedPath = textBoxDir.Text;
            }

            if (dlgBrowser.ShowDialog(this) == DialogResult.OK)
            {
               textBoxDir.Text = dlgBrowser.SelectedPath;
            }
         }
         OnSetIsDirty(sender, e);
      }

      private void OnSetIsDirty(object sender, EventArgs e)
      {
         try
         {
            IsDirty = true;
            OnSettingsChanged(sender, e);

            if (sender == checkBoxStation)
            {
               if (RequireStationNameChanged != null)
                  RequireStationNameChanged(sender, e);
            }
            else if (sender == checkBoxOperator)
            {
               if (RequireOperatorsNameChanged != null)
                  RequireOperatorsNameChanged(sender, e);
            }
            else if (sender == checkBoxTransaction)
            {
               if (RequireTransactionUidChanged != null)
                  RequireTransactionUidChanged(sender, e);
            }
            else if (sender == checkBoxDate)
            {
               if (RequireTransactionDateChanged != null)
                  RequireTransactionDateChanged(sender, e);
            }
            else if (sender == checkBoxTime)
            {
               if (RequireTransactionTimeChanged != null)
                  RequireTransactionTimeChanged(sender, e);
            }
            else if (sender == checkBoxDescription)
            {
               if (RequireDescriptionChanged != null)
                  RequireDescriptionChanged(sender, e);
            }
            else if (sender == checkBoxReason)
            {
               if (RequireReasonChanged != null)
                  RequireReasonChanged(sender, e);
            }
            else if (sender == checkBoxAutoUpdate)
            {
               if (AutoUpdateEnableChanged != null)
                  AutoUpdateEnableChanged(sender, e);
            }

            else if (sender == checkBoxRetry)
            {
               if (EnableRetryChanged != null)
                  EnableRetryChanged(sender, e);
            }
            else if (sender == numericUpDownsSecs)
            {
               if (RetrySecondsChanged != null)
                  RetrySecondsChanged(sender, e);
            }
            else if (sender == numericUpDownDays)
            {
               if (RetryExpirationDaysChanged != null)
                  RetryExpirationDaysChanged(sender, e);
            }
            else if (sender == textBoxDir)
            {
               if (RetryDirectoryChanged != null)
                  RetryDirectoryChanged(sender, e);
            }
            else if (sender == checkBoxCustomAE)
            {
               if (UseCustomAeTitleChanged != null)
                  UseCustomAeTitleChanged(sender, e);
            }
            else if (sender == textBoxCustomAE)
            {
               if (CustomAeTitleChanged != null)
                  CustomAeTitleChanged(sender, e);
            }
            else if (sender == numericUpDownThreads)
            {
               if (AutoUpdateProcessingThreadsChanged != null)
                  AutoUpdateProcessingThreadsChanged(sender, e);
            }
            
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }
            
      private void PatientUpdaterConfigurationView_Load ( object sender, EventArgs e )
      {
         //
         // Resize the columns evenly
         //
         foreach(ColumnHeader column in listViewAutoUpdate.Columns)
         {
            column.Width = listViewAutoUpdate.ClientRectangle.Width / 3;
         }
      }   
   
      private PatientUpdaterOptions                   _Options;
      private IAeManagementDataAccessAgent            _AccessAgent;
      private ListViewItem                            _SelectedItem = null;
      private int                                     _SelectedIndex = -1;
      
      private const int UPDATE_RELATION = 923;

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

   public static class ListViewExt
   {
      public static void Check(this ListView listview, bool check)
      {
         if(listview == null)
            return;

         foreach(ListViewItem item in listview.Items)
         {
            item.Checked = check;
         }
      }
   }
}
