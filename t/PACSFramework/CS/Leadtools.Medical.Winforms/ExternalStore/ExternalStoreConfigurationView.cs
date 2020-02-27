// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.DicomDemos;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.Medical.Winforms.Forwarder;
using Leadtools.Medical.ExternalStore.DataAccessLayer.Configuration;
using Leadtools.Medical.Winforms.Forwarder.Scheduling;
using Leadtools.Medical.Winforms.Forwarder.Controls;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.AddIn;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Leadtools.Dicom.AddIn.Attributes;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Demos;

namespace Leadtools.Medical.Winforms.ExternalStore
{
   public partial class ExternalStoreConfigurationView : UserControl
   {
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
      private IExternalStoreDataAccessAgent _externalStoreAgent;
      private System.Threading.Timer _infoTimer;
      private const int REFRESH_INTERVAL = 1000;

      private ExternalStoreAddinConfigAbstract[] _configurations;

      public ExternalStoreAddinConfigAbstract[] ExternalStoreAddins
      {
         get
         {
            return _configurations;
         }

         set
         {
            _configurations = value;
         }
      }

      private ExternalStoreOptions _Options;
      public ExternalStoreOptions Options
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
            tabControlExternalStore.Enabled = base.Enabled;
         }
      }

      public event EventHandler<ExternalStoreMessageEventArgs> ExternalStore;

      protected void OnExternalStore(string destination)
      {
         if (ExternalStore != null)
         {
            ExternalStoreMessageEventArgs e = new ExternalStoreMessageEventArgs(ExternalStoreMessage.ExternalStore, destination);

            ExternalStore(this, e);
         }
      }
      
      public event EventHandler<EventArgs> CancelExternalStore;
      protected void OnCancelExternalStore()
      {
         if (CancelExternalStore != null)
         {
            CancelExternalStore(this, new EventArgs());
         }
      }


      public event EventHandler<CleanMessageEventArgs> Clean;

      protected void OnClean(string destination, int expirationDays)
      {
         if (Clean != null)
         {
            CleanMessageEventArgs e = new CleanMessageEventArgs(ExternalStoreMessage.Clean, destination, expirationDays);

            Clean(this, e);
         }
      }

      public event EventHandler<RestoreMessageEventArgs> Restore;

      protected void OnRestore(string destination, DateTime start, DateTime? end)
      {
         if (Restore != null)
         {
            RestoreMessageEventArgs e = new RestoreMessageEventArgs(ExternalStoreMessage.Restore, destination, start, end );

            Restore(this, e);
         }
      }

      public event EventHandler<EventArgs> CancelRestore;

      protected void OnCancelRestore()
      {
         if (CancelRestore != null)
         {
            CancelRestore(this, new EventArgs());
         }
      }

      public event EventHandler<ResetEventArgs> Reset;

      protected void OnReset(DateTime start, DateTime? end)
      {
         if (Reset != null)
         {
            ResetEventArgs e = new ResetEventArgs(ExternalStoreMessage.Reset,start,end);

            Reset(this, e);
         }
      }

      public ExternalStoreConfigurationView()
      {
         InitializeComponent();

         // IsDirty Handlers

         // Configuration Tab
         comboBoxStoreTo.SelectedIndexChanged += new EventHandler(OnSettingsChanged);
         comboBoxStoreTo.SelectedIndexChanged += new EventHandler(comboBoxStoreTo_SelectedIndexChanged);

         // Schedule Tab
         checkBoxExternalStoreEnable.CheckedChanged         += new EventHandler(OnSettingsChanged);
         checkBoxExternalStoreEnable.CheckedChanged         += new EventHandler(checkBoxExternalStoreEnable_CheckedChanged);
         schedulerControlExternalStore.SettingsChanged      += new EventHandler(OnSettingsChanged);

         checkBoxCleanEnable.CheckedChanged           += new EventHandler(OnSettingsChanged);
         checkBoxCleanEnable.CheckedChanged           += new EventHandler(checkBoxCleanEnable_CheckedChanged);
         schedulerControlClean.SettingsChanged        += new EventHandler(OnSettingsChanged);

         numericUpDownHoldAmount.ValueChanged         +=new EventHandler(OnSettingsChanged);
         comboBoxHoldInterval.SelectedIndexChanged    += new EventHandler(OnSettingsChanged);
         checkBoxVerify.CheckedChanged                += new EventHandler(OnSettingsChanged);
         
         // Tools Tab
         comboBoxReset.SelectedIndexChanged           += new EventHandler(OnSettingsChanged);
         comboBoxReset.SelectedIndexChanged           += new EventHandler(comboBoxReset_SelectionChangeCommitted);
         dateTimePickerResetStart.ValueChanged        += new EventHandler(OnSettingsChanged);
         dateTimePickerResetEnd.ValueChanged          += new EventHandler(OnSettingsChanged);

         comboBoxRestore.SelectedIndexChanged           += new EventHandler(OnSettingsChanged);
         comboBoxRestore.SelectedIndexChanged           += new EventHandler(comboBoxRestore_SelectionChangeCommitted);
         dateTimePickerRestoreStart.ValueChanged        += new EventHandler(OnSettingsChanged);
         dateTimePickerRestoreEnd.ValueChanged          += new EventHandler(OnSettingsChanged);

         groupBoxTools.Enabled = false;
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

      public void Initialize(ExternalStoreOptions options, string serviceDirectory)
      {
         _Options = options;
         if (_Options == null)
            return;

         // Initialize UI
         comboBoxHoldInterval.Items.Clear();
         comboBoxHoldInterval.Items.Add(HoldInterval.Days);
         comboBoxHoldInterval.Items.Add(HoldInterval.Months);
         comboBoxHoldInterval.Items.Add(HoldInterval.Years);
         comboBoxHoldInterval.SelectedItem = HoldInterval.Days;

         comboBoxReset.Text = "Today";
         comboBoxReset_SelectionChangeCommitted(comboBoxReset, EventArgs.Empty);
         dateTimePickerResetStart_ValueChanged(dateTimePickerResetEnd, EventArgs.Empty);
         dateTimePickerResetEnd_ValueChanged(dateTimePickerResetEnd, EventArgs.Empty);

         comboBoxRestore.Text = "Today";
         comboBoxRestore_SelectionChangeCommitted(comboBoxRestore, EventArgs.Empty);
         dateTimePickerRestoreStart_ValueChanged(dateTimePickerRestoreEnd, EventArgs.Empty);
         dateTimePickerRestoreEnd_ValueChanged(dateTimePickerRestoreEnd, EventArgs.Empty);

         checkBoxExternalStoreEnable.Checked = false;
         checkBoxCleanEnable.Checked = false;
         numericUpDownHoldAmount.Value = 0;
         checkBoxVerify.Checked = false;

         comboBoxStoreTo.Items.Clear();
         comboBoxStoreTo.Items.Add("None");

         List<ExternalStoreItem> itemList = new List<ExternalStoreItem>();

         if (ExternalStoreAddins != null)
         {
            foreach (ExternalStoreAddinConfigAbstract config in ExternalStoreAddins)
            {
               comboBoxStoreTo.Items.Add(config);
               itemList.Add(new ExternalStoreItem(config));
            }
         }

         _Options.SynchronizeOptionsList(itemList.ToArray());

         // Register all the ICrud interfaces for all addins
         _Options.RegisterAllExternalStoreAddins();

         ExternalStoreItem selectedItem = _Options.GetCurrentOption();

         RegisterCrud(selectedItem);

         labelStartDate.Text = string.Empty;
         labelEndDate.Text = string.Empty;
         labelRestoreStartDate.Text = string.Empty;
         labelRestoreEndDate.Text = string.Empty;

         //dateTimePickerResetStart.ValueChanged += dateTimePickerResetStart_ValueChanged;
         //dateTimePickerResetEnd.ValueChanged += dateTimePickerResetEnd_ValueChanged;
         //dateTimePickerRestoreStart.ValueChanged += dateTimePickerRestoreStart_ValueChanged;
         //dateTimePickerRestoreEnd.ValueChanged += dateTimePickerRestoreEnd_ValueChanged;

         UpdateDateLabels();

         UpdateUI(selectedItem);

         // Initialize Data Access Layer
         InitializeDataAccess();
      }

      static void RegisterCrud(ExternalStoreItem item)
      {
         if (item == null)
         {
            DataAccessServiceLocator.Register<ICrud>(new DefaultCrud());
         }
         else
         {
            ICrud crud = item.ExternalStoreAddinConfig.GetCrudInterface();
            if (crud != null)
            {
               crud.Initialize();
            }
            DataAccessServiceLocator.Register<ICrud>(crud);
            if (crud != null)
            {
               DataAccessServiceLocator.Register<ICrud>(crud, crud.ExternalStoreGuid);
            }
         }
      }

      void UpdateUI(ExternalStoreItem selectedItem)
      {
         if (selectedItem != null)
         {
            labelError.Visible = false;
            tabControlExternalStore.Enabled = true;
            comboBoxStoreTo.Text = selectedItem.ExternalStoreAddinConfig.FriendlyName;
         }
         else
         {
            comboBoxStoreTo.Text = @"None";
            labelError.Visible = (comboBoxStoreTo.Items.Count == 1);
            tabControlExternalStore.Enabled = false;
         }
         buttonVerify.Visible = !labelError.Visible && (selectedItem != null);
      }

      static MyObjectProperty GetObjectProperties(object myObject, PropertyInfo prop)
      {
         MyObjectProperty ret = new MyObjectProperty {PropertyName = prop.Name};

         object propValue = prop.GetValue(myObject, null);

         object[] attributes = prop.GetCustomAttributes(false);
         foreach (Attribute a in attributes)
         {
            if (a is DisplayNameAttribute)
            {
               DisplayNameAttribute displayNameAttribute = a as DisplayNameAttribute;
               ret.DisplayName = displayNameAttribute.DisplayName;
            }
            else if (a is DefaultValueAttribute)
            {
               DefaultValueAttribute defaultValueAttribute = a as DefaultValueAttribute;
               ret.DefaultValue = defaultValueAttribute.Value;
            }
            else if (a is RangeAttribute)
            {
               RangeAttribute rangeAttribute = a as RangeAttribute;
               ret.Minimum = rangeAttribute.Minimum;
               ret.Maximum = rangeAttribute.Maximum;
            }
            else if (a is ControlAttribute)
            {
               ControlAttribute controlAttribute = a as ControlAttribute;
               ret.ControlWidth = controlAttribute.Width;
               ret.ControlHeight = controlAttribute.Height;
               ret.Password = controlAttribute.Password;
            }
         }
         return ret;
      }

      static int GetIntValue(object value)
      {
         int tempValue = 0;
         if (value != null)
            tempValue = (int)value;

         return tempValue;
      }

      static string GetStringValue(object value)
      {
         string tempValue = string.Empty;
         if (value != null)
            tempValue = value as string;
         return tempValue;
      }

      static bool GetBoolValue(object value)
      {
         bool tempValue = false;
         if (value != null)
            tempValue = Convert.ToBoolean(value);
         return tempValue;
      }

      static Enum GetEnumValue(object value)
      {
         Enum tempValue = null;
         if (value != null)
            tempValue = value as Enum;
         return tempValue;
      }

      void InitializeFlowLayout(ExternalStoreItem item)
      {
         FlowLayoutPanel flowLayoutPanel = tabPageExternalStoreConfiguration.Controls["groupBoxConfiguration"].Controls["flowLayoutPanel"] as FlowLayoutPanel;
         if (flowLayoutPanel != null)
         {
            flowLayoutPanel.Controls.Clear();

            if (item == null)
            {
               return;
            }

            object configurationObject = item.ExternalStoreAddinConfig.ConfigurationObject;

            Type myType = configurationObject.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
               MyObjectProperty objectProperty = GetObjectProperties(configurationObject, prop);
               Type fieldType = prop.PropertyType;

               if (!string.IsNullOrEmpty(objectProperty.DisplayName))
               {
                  if (fieldType != typeof(bool))
                  {
                     // skip 'bool' because these are mapped to checkbox which doesn't need a label-- it has a description
                     Label label = new Label();
                     label.TextAlign = ContentAlignment.BottomLeft;
                     label.Text = objectProperty.DisplayName;
                     flowLayoutPanel.Controls.Add(label);
                  }
               }


               System.Windows.Forms.Control control = null;
               object value = GetObjectProperty(objectProperty.PropertyName, configurationObject);
               if (fieldType == typeof(string))
               {
                  TextBox textBox = new TextBox();
                  control = textBox;
                  textBox.Name = objectProperty.PropertyName;

                  // Set the default
                  textBox.Text = GetStringValue(value);
                  textBox.UseSystemPasswordChar = objectProperty.Password;
                  textBox.TextChanged += new EventHandler(OnSettingsChanged);
               }
               else if (fieldType == typeof(int))
               {
                  NumericUpDown numericUpDown = new NumericUpDown();
                  control = numericUpDown;
                  numericUpDown.Name = objectProperty.PropertyName;

                  if (objectProperty.Minimum != null)
                  {
                     numericUpDown.Minimum = GetIntValue(objectProperty.Minimum);
                  }

                  if (objectProperty.Maximum != null)
                  {
                     numericUpDown.Maximum = GetIntValue(objectProperty.Maximum);
                  }

                  // Set the default
                  numericUpDown.Value = GetIntValue(value);

                  numericUpDown.ValueChanged += new EventHandler(OnSettingsChanged);
               }

               else if (fieldType == typeof(bool))
               {
                  CheckBox checkBox = new CheckBox();
                  control = checkBox;
                  checkBox.Name = objectProperty.PropertyName;
                  checkBox.Text = objectProperty.DisplayName;

                  // Set the default
                  checkBox.Checked = GetBoolValue(value);

                  checkBox.CheckedChanged += new EventHandler(OnSettingsChanged);
               }

               else if (fieldType.IsEnum)
               {
                  ComboBox comboBox = new ComboBox();
                  comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                  control = comboBox;
                  comboBox.Name = objectProperty.PropertyName;

                  Array values = Enum.GetValues(fieldType);
                  foreach (Enum val in values)
                  {
                     FlowComboBoxItem ci = new FlowComboBoxItem();
                     ci.FriendlyName = val.Description();
                     ci.EnumValue = val;
                     comboBox.Items.Add(ci);
                  }

                  // Set the default
                  Enum myEnum = GetEnumValue(value);
                  comboBox.Text = myEnum.Description();

                  comboBox.SelectedIndexChanged += new EventHandler(OnSettingsChanged);
               }

               if (control != null)
               {
                  if (objectProperty.ControlWidth != -1)
                     control.Width = objectProperty.ControlWidth;

                  if (objectProperty.ControlHeight != -1)
                     control.Height = objectProperty.ControlHeight;

                  flowLayoutPanel.Controls.Add(control);
               }
            }
         }
      }

      private static void SetObjectProperty(string propertyName, object value, ref object objName)
      {
         PropertyInfo propertyInfo = objName.GetType().GetProperty(propertyName);
         // make sure object has the property we are after
         if (propertyInfo != null)
         {
            bool isEnum = typeof(Enum).IsAssignableFrom(propertyInfo.PropertyType);
            if (isEnum)//its derived from Enum
            {
               //more business logic here, ie: is this the property your want to set and know how to set?
               //now to the important part
               string enumStringName = string.Empty;
               if (value != null)
               {
                  enumStringName = value as string;
               }
               propertyInfo.SetValue(objName, System.Enum.Parse(propertyInfo.PropertyType, enumStringName), null);
            }
            else
            {
               propertyInfo.SetValue(objName, value, null);
            }
         }
      }

      private static object GetObjectProperty(string propertyName, object objName)
      {
         object value = null;
         PropertyInfo propertyInfo = objName.GetType().GetProperty(propertyName);
         if (propertyInfo != null)
         {
            value = propertyInfo.GetValue(objName, null);
         }
         return value;
      }

      void UpdateFlowLayoutFromConfiguration(object configurationObject)
      {
         FlowLayoutPanel flowLayoutPanel = tabPageExternalStoreConfiguration.Controls["groupBoxConfiguration"].Controls["flowLayoutPanel"] as FlowLayoutPanel;
         if (flowLayoutPanel != null)
         {
            Type myType = configurationObject.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
               MyObjectProperty objectProperty = GetObjectProperties(configurationObject, prop);
               Type fieldType = prop.PropertyType;
               object value = GetObjectProperty(objectProperty.PropertyName, configurationObject);
               if (fieldType == typeof(string))
               {
                  TextBox textBox = flowLayoutPanel.Controls[objectProperty.PropertyName] as TextBox;
                  textBox.Text = GetStringValue(value);
               }
               else if (fieldType == typeof(int))
               {
                  NumericUpDown numericUpDown = flowLayoutPanel.Controls[objectProperty.PropertyName] as NumericUpDown;
                  numericUpDown.Name = objectProperty.PropertyName;
                  numericUpDown.Value = GetIntValue(value);
               }
               else if (fieldType == typeof(bool))
               {
                  CheckBox checkBox = flowLayoutPanel.Controls[objectProperty.PropertyName] as CheckBox;
                  checkBox.Name = objectProperty.PropertyName;
                  checkBox.Checked = GetBoolValue(value);
               }
               else if (fieldType.IsEnum)
               {
                  ComboBox comboBox = flowLayoutPanel.Controls[objectProperty.PropertyName] as ComboBox;
                  comboBox.Name = objectProperty.PropertyName;
                  Enum myEnum = GetEnumValue(value);
                  comboBox.Text = myEnum.Description();
               }
            }
         }
      }

      void UpdateConfigurationObjectFromFlowLayout(object configurationObject)
      {
         FlowLayoutPanel flowLayoutPanel = tabPageExternalStoreConfiguration.Controls["groupBoxConfiguration"].Controls["flowLayoutPanel"] as FlowLayoutPanel;
         if (flowLayoutPanel != null)
         {
            Type myType = configurationObject.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
               MyObjectProperty objectProperty = GetObjectProperties(configurationObject, prop);
               Type fieldType = prop.PropertyType;
               if (fieldType == typeof(string))
               {
                  TextBox textBox = flowLayoutPanel.Controls[objectProperty.PropertyName] as TextBox;
                  SetObjectProperty(objectProperty.PropertyName, textBox.Text, ref configurationObject);
               }
               else if (fieldType == typeof(int))
               {
                  NumericUpDown numericUpDown = flowLayoutPanel.Controls[objectProperty.PropertyName] as NumericUpDown;
                  numericUpDown.Name = objectProperty.PropertyName;
                  SetObjectProperty(objectProperty.PropertyName, (int)numericUpDown.Value, ref configurationObject);
               }
               else if (fieldType == typeof(bool))
               {
                  CheckBox checkBox = flowLayoutPanel.Controls[objectProperty.PropertyName] as CheckBox;
                  checkBox.Name = objectProperty.PropertyName;
                  SetObjectProperty(objectProperty.PropertyName, checkBox.Checked, ref configurationObject);
               }
               else if (fieldType.IsEnum)
               {
                  ComboBox comboBox = flowLayoutPanel.Controls[objectProperty.PropertyName] as ComboBox;
                  comboBox.Name = objectProperty.PropertyName;
                  FlowComboBoxItem ci = comboBox.SelectedItem as FlowComboBoxItem;
                  if (ci != null)
                  {
                     SetObjectProperty(objectProperty.PropertyName, ci.EnumValue.ToString(), ref configurationObject);
                  }
               }
            }
         }
      }

      public ExternalStoreAddinConfigAbstract GetSelectedExternalStoreAddin()
      {
         ExternalStoreAddinConfigAbstract c = comboBoxStoreTo.SelectedItem as ExternalStoreAddinConfigAbstract;
         return c;
      }

      void comboBoxStoreTo_SelectedIndexChanged(object sender, EventArgs e)
      {
         ExternalStoreAddinConfigAbstract c = comboBoxStoreTo.SelectedItem as ExternalStoreAddinConfigAbstract;

         _Options.SetCurrentOption(c);
         ExternalStoreItem item = _Options.GetCurrentOption();

         InitializeFlowLayout(item);
         IntializeScheduleTab(item);

         UpdateUI(item);
      }

      void IntializeScheduleTab(ExternalStoreItem item)
      {
         if (item != null)
         {
            InitializeSchedule(item.ExternalStoreJob, schedulerControlExternalStore);
            InitializeSchedule(item.CleanJob, schedulerControlClean);
            InitializeInterval(item);

            checkBoxExternalStoreEnable.Enabled = item.ExternalStoreAddinConfig.EnableAutoExternalStore;
            if (item.ExternalStoreJob != null && item.ExternalStoreJob.ExpirationTime < DateTime.Now)
            {
               checkBoxExternalStoreEnable.Checked = false;
            }
            else
            {
               checkBoxExternalStoreEnable.Checked = item.ExternalStoreAddinConfig.EnableAutoExternalStore && item.ExternalStoreJob != null;
            }

            checkBoxCleanEnable.Enabled = item.ExternalStoreAddinConfig.EnableAutoClear;
            if (item.CleanJob != null && item.CleanJob.ExpirationTime < DateTime.Now)
            {
               checkBoxCleanEnable.Checked = false;
            }
            else
            {
               checkBoxCleanEnable.Checked = item.ExternalStoreAddinConfig.EnableAutoClear && (item.CleanJob != null);
            }

            // Verify checkbox
            checkBoxVerify.Enabled = item.ExternalStoreAddinConfig.EnableVerifyRetrieveAfterExternalStore;

            // Hold
            labelHoldTime.Enabled = item.ExternalStoreAddinConfig.EnableAutoClear;
            numericUpDownHoldAmount.Enabled = item.ExternalStoreAddinConfig.EnableAutoClear;
            comboBoxHoldInterval.Enabled = item.ExternalStoreAddinConfig.EnableAutoClear;

            comboBoxHoldInterval.SelectedItem = item.HoldInterval;
            if (item.ImageHold != null)
               numericUpDownHoldAmount.Value = Convert.ToDecimal(item.ImageHold);

            checkBoxVerify.Checked = item.Verify;
         }

         EnableExternalStore(checkBoxExternalStoreEnable.Checked);
         EnableClean(checkBoxCleanEnable.Checked);
      }


      private static void InitializeSchedule(Job job, SchedulerControl scheduler)
      {
         if (job != null)
         {                      
            scheduler.SetSchedule(job);
         }
      }

      private void InitializeInterval(ExternalStoreItem item)
      {
         if (item != null)
         {
            ForwardManagerConfigurationView.SetJobInterval(item.ExternalStoreJob, schedulerControlExternalStore);
            ForwardManagerConfigurationView.SetJobInterval(item.CleanJob, schedulerControlClean);
         }
      }

      private void InitializeDataAccess()
      {
         if (!DataAccessServices.IsDataAccessServiceRegistered<IExternalStoreDataAccessAgent>())
         {
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();
            _externalStoreAgent = DataAccessFactory.GetInstance(new ExternalStoreDataAccessConfigurationView(configuration, PacsProduct.ProductName, PacsProduct.ServiceName)).CreateDataAccessAgent<IExternalStoreDataAccessAgent>();
            DataAccessServices.RegisterDataAccessService<IExternalStoreDataAccessAgent>(_externalStoreAgent);
         }
         else
            _externalStoreAgent = DataAccessServices.GetDataAccessService<IExternalStoreDataAccessAgent>();

         if (_externalStoreAgent != null)
         {
            if (_infoTimer == null)
            {
               _infoTimer = new System.Threading.Timer(new System.Threading.TimerCallback(UpdateCount));
               VisibleChanged += new EventHandler(ExternalStoreConfigurationView_VisibleChanged);
               if (Visible)
                  _infoTimer.Change(REFRESH_INTERVAL, REFRESH_INTERVAL);
            }
         }
      }

        void ExternalStoreConfigurationView_VisibleChanged(object sender, EventArgs e)
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

      public static string GetCountString(long count, string datasetType, string process)
      {
         string info = string.Format("{0} {1} dataset(s) to {2}", count, datasetType, process);
         return info;
      }

      private void UpdateCount(object data)
      {
         _infoTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
         if (!Visible)
            return;

         try
         {
            long externalStoreCount = 0;
            long cleanCount = 0;
            //long restoreCount = 0;

            try
            {
               externalStoreCount = _externalStoreAgent.GetExternalStoreCount();
            }
            catch { }

            try
            {
               int daysToExpire = (int)numericUpDownDaysToExpire.Value;
               cleanCount = _externalStoreAgent.GetClearCount(daysToExpire);
            }
            catch { }

            //try
            //{
            //   restoreCount = _externalStoreAgent.GetRestoreCount();
            //}
            //catch { }

            AsyncHelper.SynchronizedInvoke(this, () =>
               {
                  labelExternalStoreInfo.Text = GetCountString(externalStoreCount, "local", "Send to 'External Store'");
                  labelClearInfo.Text = GetCountString(cleanCount, "local", "'Clear'");
                  //labelRestoreInfo.Text = GetCountString(restoreCount, "externally stored", "restore");

                  buttonExternalStore.Enabled = externalStoreCount > 0 && EnableTools;
                  buttonCancelExternalStore.Enabled = buttonExternalStore.Enabled;

                  buttonCleanLocal.Enabled = cleanCount > 0 && EnableTools;
                  // buttonRestoreLocalStore.Enabled = restoreCount > 0 && EnableTools;

                  GetRestoreCountUpdateLabel();
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

      public void EnableExternalStore(bool enable)
      {
         EnableGroup(groupBoxExternalStore, checkBoxExternalStoreEnable.Checked);         
      }

      public void EnableClean(bool enable)
      {
         EnableGroup(groupBoxClean, checkBoxCleanEnable.Checked);
      }

      private void checkBoxExternalStoreEnable_CheckedChanged(object sender, EventArgs e)
      {
         EnableExternalStore(checkBoxExternalStoreEnable.Checked);
      }

      private void checkBoxCleanEnable_CheckedChanged(object sender, EventArgs e)
      {
         EnableClean(checkBoxCleanEnable.Checked);
      }


      public ExternalStoreOptions UpdateSettings()
      {
         if (_Options == null)
            return null;

         ExternalStoreAddinConfigAbstract c = comboBoxStoreTo.SelectedItem as ExternalStoreAddinConfigAbstract;
         _Options.SetCurrentOption(c);

         // Register all the ICrud interfaces for all addins
         _Options.RegisterAllExternalStoreAddins();

         ExternalStoreItem item = _Options.GetCurrentOption();

         RegisterCrud(item);


         if (item != null)
         {
            if (checkBoxExternalStoreEnable.Checked)
               item.ExternalStoreJob = schedulerControlExternalStore.GetSchedule();
            else
               item.ExternalStoreJob = null;

            if (checkBoxCleanEnable.Checked)
               item.CleanJob = schedulerControlClean.GetSchedule();
            else
               item.CleanJob = null;

            item.HoldInterval = (HoldInterval)comboBoxHoldInterval.SelectedItem;

            //if (numericUpDownHoldAmount.Value != 0)
            //{
            //   item.ImageHold = Convert.ToInt32(numericUpDownHoldAmount.Value);
            //}
            //else
            //{
            //   item.ImageHold = null;
            //}
             item.ImageHold = Convert.ToInt32(numericUpDownHoldAmount.Value);

            item.Verify = checkBoxVerify.Checked;

            item.ExternalStoreAddinConfig = (ExternalStoreAddinConfigAbstract)comboBoxStoreTo.SelectedItem;

            if (item.ExternalStoreAddinConfig != null)
            {
               UpdateConfigurationObjectFromFlowLayout(item.ExternalStoreAddinConfig.ConfigurationObject);
            }
         }
         return _Options;
      }

       private void comboBoxReset_SelectionChangeCommitted(object sender, EventArgs e)
      {
         DateTime now = DateTime.Now;

         switch (comboBoxReset.Text)
         {               
            case "Today":
               SetResetDate(DateTime.Today, null);
               break;
            case "Yesterday":
               SetResetDate(now.AddDays(-1), null);
               break;  
            case "This Week":
               SetResetDate(now.StartOfWeek(), now.EndOfWeek());
               break;
            case "Last Week":
               SetResetDate(now.StartOfLastWeek(), now.EndOfLastWeek());
               break;
            default:
               if (dateTimePickerResetStart.Value > dateTimePickerResetEnd.Value)
                  SetResetDate(dateTimePickerResetStart.Value, dateTimePickerResetStart.Value.AddDays(1));
               dateTimePickerResetEnd.Checked = comboBoxReset.Text == @"Date Range";               
               break;
               
         }

         GetResetCount();
      }

       private void comboBoxRestore_SelectionChangeCommitted(object sender, EventArgs e)
       {
          DateTime now = DateTime.Now;

          switch (comboBoxRestore.Text)
          {
             case "Today":
                SetRestoreDate(DateTime.Today, null);
                break;
             case "Yesterday":
                SetRestoreDate(now.AddDays(-1), null);
                break;
             case "This Week":
                SetRestoreDate(now.StartOfWeek(), now.EndOfWeek());
                break;
             case "Last Week":
                SetRestoreDate(now.StartOfLastWeek(), now.EndOfLastWeek());
                break;
             default:
                if (dateTimePickerRestoreStart.Value > dateTimePickerRestoreEnd.Value)
                   SetRestoreDate(dateTimePickerRestoreStart.Value, dateTimePickerRestoreStart.Value.AddDays(1));
                dateTimePickerRestoreEnd.Checked = comboBoxRestore.Text == @"Date Range";
                break;

          }

          GetRestoreCountUpdateLabel();
       }

      private void SetResetDate(DateTime start, DateTime? end)
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
         UpdateResetDateLabels();
      }

      private void SetRestoreDate(DateTime start, DateTime? end)
      {
         dateTimePickerRestoreStart.ValueChanged -= dateTimePickerRestoreStart_ValueChanged;
         if (end.HasValue)
         {
            dateTimePickerRestoreEnd.ValueChanged -= dateTimePickerRestoreEnd_ValueChanged;            
            if (end.Value < start)
               end = start.AddDays(1);
            dateTimePickerRestoreEnd.Value = end.Value;
            dateTimePickerRestoreEnd.Checked = true;            
            dateTimePickerRestoreEnd.ValueChanged += dateTimePickerRestoreEnd_ValueChanged;
         }
         else
         {
            dateTimePickerRestoreEnd.Checked = false;
         }

         dateTimePickerRestoreStart.Value = start;
         dateTimePickerRestoreStart.ValueChanged += dateTimePickerRestoreStart_ValueChanged;

         UpdateRestoreDateLabels();
      }



      private void buttonExternalStore_Click(object sender, EventArgs e)
      {
         try
         {
            long count = _externalStoreAgent.GetExternalStoreCount();

            if (_infoTimer != null)
            {
               _infoTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            }
            string message = string.Format("This will attempt to copy {0} {1} to the '{2} External Store'.\r\n\r\nDo you want to continue?",
                                           count, 
                                           count == 1 ? "dataset" : "datasets", 
                                           comboBoxStoreTo.Text /*_Options.ForwardTo*/ );

            if (MessageBox.Show(message, @"External Store", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
               ExternalStoreAddinConfigAbstract c = comboBoxStoreTo.SelectedItem as ExternalStoreAddinConfigAbstract;
               if (c != null)
               {
                  OnExternalStore(c.Guid);
                  buttonExternalStore.Enabled = false;
                  buttonCancelExternalStore.Enabled = false;
               }
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
         int daysToExpire = (int)numericUpDownDaysToExpire.Value;
         long count = _externalStoreAgent.GetClearCount(daysToExpire);
         string message = string.Format("{0} dataset(s) will be removed from the 'Local Store'.  These datasets already exist on the 'External Store'.\n\nDo you want to continue?", count);

         if (MessageBox.Show(message, @"Clear Locally Stored dataset(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
         {
            ExternalStoreAddinConfigAbstract c = comboBoxStoreTo.SelectedItem as ExternalStoreAddinConfigAbstract;
            if (c != null)
            {
               OnClean(c.Guid, daysToExpire);
            }
         }
      }

      private void buttonRestoreLocalStore_Click(object sender, EventArgs e)
      {
         string message;
         long count = GetRestoreCount();
         const string sRestoringPrompt = "'Restoring' copies from the 'External Store' to the 'Local Store'.\n\nDo you want to continue?";

         
         if (dateTimePickerRestoreEnd.Checked)
         {
            message = string.Format("This will restore {0} dataset(s) that were stored\n\tfrom:\t{1} \n\tto:\t{2}.\n\n{3}", 
               count,
               dateTimePickerRestoreStart.Value.ToLongDateString(), 
               dateTimePickerRestoreEnd.Value.ToLongDateString(),
               sRestoringPrompt
             );
         }
         else
         {
            message = string.Format("This will restore {0} dataset(s) that were stored on {1}.\n\n{2}", 
            count,
            dateTimePickerRestoreStart.Value.ToLongDateString(),
            sRestoringPrompt
            );
         }


         if (MessageBox.Show(message, @"Copy from 'External Store' to the 'Local Store'?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
         {
            ExternalStoreAddinConfigAbstract c = comboBoxStoreTo.SelectedItem as ExternalStoreAddinConfigAbstract;
            if (c != null)
            {
               OnRestore(c.Guid, dateTimePickerRestoreStart.Value, dateTimePickerRestoreEnd.Checked ? dateTimePickerRestoreEnd.Value : (DateTime?)null);
            }
         }
      }

      private void buttonCancelExternalStore_Click(object sender, EventArgs e)
      {
         const string message = "This will cancel any pending 'Send to External Store'.\n\nDo you want to continue?";

         if (MessageBox.Show(message, @"Cancel Pending 'Send to External Store'", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
         {
            OnCancelExternalStore();
         }
      }

      private void buttonCancelRestore_Click(object sender, EventArgs e)
      {
         const string message = "This will cancel any pending 'Restores' from the 'External Store' to the 'Local Store'.\n\nDo you want to continue?";

         if (MessageBox.Show(message, @"Cancel Pending 'Restores'", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
         {
            OnCancelRestore();
         }
      }

      private void buttonReset_Click(object sender, EventArgs e)
      {
         string message;

         if (dateTimePickerResetEnd.Checked)
         {
            message = string.Format("This will reset the 'External Store Date' on all images that were stored\n\tfrom:\t{0} \n\tto:\t{1}.\n\nDo you want to continue?",
                                    dateTimePickerResetStart.Value.ToLongDateString(), dateTimePickerResetEnd.Value.ToLongDateString());
         }
         else
            message = string.Format("This will reset the 'External Store Date' on all images that were stored on {0}.\n\nDo you want to continue?",
                                    dateTimePickerResetStart.Value.ToLongDateString());

         if (MessageBox.Show(message, @"Reset External Store Date", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
         {
            OnReset(dateTimePickerResetStart.Value, dateTimePickerResetEnd.Checked ? dateTimePickerResetEnd.Value : (DateTime?)null);
         }
      }

      private static void UpdateDateLabel(Label startDate, Label endDate, DateTimePicker pickerStart, DateTimePicker pickerEnd)
      {
         startDate.Text = pickerStart.Value.DayOfWeek.ToString();
         endDate.Text = pickerEnd.Value.DayOfWeek.ToString();
         endDate.Enabled = pickerEnd.Checked;
      }

      private void UpdateResetDateLabels()
      {
         UpdateDateLabel(labelStartDate, labelEndDate, dateTimePickerResetStart, dateTimePickerResetEnd);
      }

      private void UpdateRestoreDateLabels()
      {
         UpdateDateLabel(labelRestoreStartDate, labelRestoreEndDate, dateTimePickerRestoreStart, dateTimePickerRestoreEnd);
      }

      private void UpdateDateLabels()
      {
         UpdateResetDateLabels();
         UpdateRestoreDateLabels();
      }

      private static void UpdateDateComboBox(Label startDate, Label endDate, DateTimePicker pickerStart, DateTimePicker pickerEnd, ComboBox comboBox)
      {
         UpdateDateLabel( startDate,  endDate,  pickerStart,  pickerEnd);

         if (!pickerEnd.Checked)
         {
            comboBox.Text = @"Date";
         }
         else
         {
            comboBox.Text = @"Date Range";
         }
      }

      private void dateTimePickerResetStart_ValueChanged(object sender, EventArgs e)
      {
         UpdateDateComboBox(labelStartDate, labelEndDate, dateTimePickerResetStart, dateTimePickerResetEnd, comboBoxReset);
         GetResetCount();
      }

      private void dateTimePickerRestoreStart_ValueChanged(object sender, EventArgs e)
      {
         UpdateDateComboBox(labelRestoreStartDate, labelRestoreEndDate, dateTimePickerRestoreStart, dateTimePickerRestoreEnd, comboBoxRestore);
         GetRestoreCount();
      }

      private void dateTimePickerResetEnd_ValueChanged(object sender, EventArgs e)
      {
         UpdateDateComboBox(labelStartDate, labelEndDate, dateTimePickerResetStart, dateTimePickerResetEnd, comboBoxReset);
         GetResetCount();
      }

      private void dateTimePickerRestoreEnd_ValueChanged(object sender, EventArgs e)
      {
         UpdateDateComboBox(labelRestoreStartDate, labelRestoreEndDate, dateTimePickerRestoreStart, dateTimePickerRestoreEnd, comboBoxRestore);
         GetRestoreCount();
      }

      private void GetResetCount()
      {
         if (dateTimePickerResetEnd.Checked)
         {
            if (dateTimePickerResetEnd.Value < dateTimePickerResetStart.Value)
               return;
         }

         if (_externalStoreAgent != null)
         {
            DateRange range = new DateRange() { StartDate = dateTimePickerResetStart.Value };
            long count = 0;

            if (dateTimePickerResetEnd.Checked)
               range.EndDate = dateTimePickerResetEnd.Value;

            try
            {
               count = _externalStoreAgent.GetResetCount(range);
            }
            catch { }

            buttonReset.Enabled = count > 0 && EnableTools;
            labelResetInfo.Text = string.Format("{0} dataset(s) to 'Reset'", count);
         }
      }

      private long GetRestoreCount()
      {
         long count = 0;
         if (dateTimePickerRestoreEnd.Checked)
         {
            if (dateTimePickerRestoreEnd.Value < dateTimePickerRestoreStart.Value)
               return 0;
         }

         if (_externalStoreAgent != null)
         {
            DateRange range = new DateRange() { StartDate = dateTimePickerRestoreStart.Value };

            if (dateTimePickerRestoreEnd.Checked)
               range.EndDate = dateTimePickerRestoreEnd.Value;

            try
            {
               count = _externalStoreAgent.GetRestoreCount(range);
            }
            catch { }
         }
         return count;
      }

      private long GetRestoreCountUpdateLabel()
      {
         long count = GetRestoreCount();

         buttonRestoreLocalStore.Enabled = count > 0 && EnableTools;
         buttonCancelRestore.Enabled = buttonRestoreLocalStore.Enabled;
         labelRestoreInfo.Text = string.Format("{0} dataset(s) to 'Restore'", count);
         return count;
      }

      private void buttonVerify_Click(object sender, EventArgs e)
      {
         ExternalStoreItem item = _Options.GetCurrentOption();
         if (item != null)
         {
            UpdateConfigurationObjectFromFlowLayout(item.ExternalStoreAddinConfig.ConfigurationObject);

            string errorString;
            bool verify = item.ExternalStoreAddinConfig.VerifyConfiguration(out errorString);

            string msg = string.Format("'{0}' settings are {1}. ", item.ExternalStoreAddinConfig.FriendlyName, verify ? "valid" : "invalid");
            Messager.Caption = "Verify External Store Settings";
            if (verify)
            {
               Messager.ShowInformation(this, msg);
            }
            else
            {
               msg = msg + "\n" + errorString;
               Messager.ShowWarning(this, msg);
            }
         }

      }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
   }


   public class FlowComboBoxItem
   {
      Enum _enumValue;
      public Enum EnumValue
      {
         get { return _enumValue; }
         set { _enumValue = value; }
      }

      string _friendlyName;
      public string FriendlyName
      {
         get { return _friendlyName; }
         set { _friendlyName = value; }
      }

      public override string ToString()
      {
         return _friendlyName;
      }

   }


   public class MyObjectProperty
   {
      public MyObjectProperty()
      {
         DisplayName = string.Empty;
         PropertyName = string.Empty;
         Minimum = null;
         Maximum = null;
         DefaultValue = null;
         ControlWidth = -1;
         ControlHeight = -1;
         Password = false;
      }

      public string DisplayName;
      public string PropertyName;
      public object DefaultValue;
      public object Minimum;
      public object Maximum;
      public int ControlWidth;
      public int ControlHeight;
      public bool Password;
   }
}
