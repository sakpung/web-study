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
using Leadtools.Medical.Storage.AddIns.Configuration;
using System.Xml.Schema;
using Leadtools.Dicom.Scp.Command;
using System.Xml;
using Leadtools.Demos;

namespace Leadtools.Medical.Storage.AddIns
{
   public partial class QueryOptionsView : UserControl
   {
      public QueryOptionsView()
      {
         InitializeComponent();
         
         this.btnBrowseMWLIODPath.Click += new System.EventHandler(this.btnBrowseQueryIODPath_Click);
         QueryIODPathTextBox.Validating += new CancelEventHandler(QueryIODPathTextBox_Validating);
         QueryIODPathTextBox.TextChanged += new EventHandler(QueryIODPathTextBox_TextChanged);
         
         textBoxStatus.MaxLength = 4;
         textBoxStatus.CharacterCasing = CharacterCasing.Upper;
         comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
         comboBoxStatus.MaxDropDownItems = 32;

         textBoxStatus.TextChanged += new EventHandler(textBoxStatus_TextChanged);
         textBoxStatus.LostFocus += new EventHandler(textBoxStatus_LostFocus);

         comboBoxStatus.SelectedIndexChanged += new EventHandler(comboBoxStatus_SelectedIndexChanged);
         

         AddIsDirtyHandlers();
         UpdateUI();
      }
      
      public static int UpperLimitCountCFindRsp = 999;

      void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_comboBoxStatusEnable)
         {
            ServiceStatusItem item = comboBoxStatus.SelectedItem as ServiceStatusItem;
            if (Convert.ToInt32(item.Value) == -1)
            {
               textBoxStatus.Text = "0000";
            }
            else
            {
               textBoxStatus.Text = item.ToHexValue();
            }
         }
      }
      
      public void InitializeServiceStatusItems()
      {
         comboBoxStatus.Items.Clear();
         foreach (ServiceStatusItem item in ServiceStatusItems)
         {
            comboBoxStatus.Items.Add(item);
         }
         comboBoxStatus.SelectedIndex = 0;
         
         // Find the user defined item in the list (-1)
         ServiceStatusItem i = ServiceStatusItems.Find(item => Convert.ToInt32(item.Value) == -1);
         if (i != null)
         {
            _sUserDefined = i.Name;
         }

      }

      private bool _comboBoxStatusEnable = true;

      public bool ComboBoxStatusEnable
      {
         get { return _comboBoxStatusEnable; }
         set { _comboBoxStatusEnable = value; }
      }
      
      private string _sUserDefined = string.Empty;


      private List<ServiceStatusItem> _items = new List<ServiceStatusItem>();

      public List<ServiceStatusItem> ServiceStatusItems
      {
         get { return _items; }
         set { _items = value; }
      }

      void textBoxStatus_LostFocus(object sender, EventArgs e)
      {
        string s = textBoxStatus.Text.Trim();
         textBoxStatus.Text = s.PadLeft(4, '0');
      }
      
      bool IsHex(char c)
      {
         bool isHexChar = ('0' <= c) && (c <= '9') ||
                            ('a' <= c) && (c <= 'f') ||
                            ('A' <= c) && (c <= 'F');
         return isHexChar;
      }

      void textBoxStatus_TextChanged(object sender, EventArgs e)
      {
         string sTemp = "";
         foreach (char c in textBoxStatus.Text)
         {

            if (IsHex(c) )
            {
               sTemp += c;
            }
         }

         textBoxStatus.Text = sTemp;

         if (!string.IsNullOrEmpty(sTemp.Trim()))
         {
            _comboBoxStatusEnable = false;
            int nValue = Convert.ToInt32(sTemp, 16);

            ServiceStatusItem i = ServiceStatusItems.Find(item => Convert.ToInt32(item.Value) == nValue);

            if (i != null)
            {
               comboBoxStatus.Text = i.Name;
            }
            else
            {
               comboBoxStatus.Text = _sUserDefined;
            }
            _comboBoxStatusEnable = true;
         }
      }
   
      private StorageAddInsConfiguration _settings ;
      private bool _isDirty = false;
      private bool _dirtyHandlersAdded = false;

      // Event Handlers
      public event EventHandler AllowZeroItemsChanged          = null;
      public event EventHandler AllowMultipleItemsChanged      = null;
      public event EventHandler AllowPrivateItemsChanged       = null;
      public event EventHandler AllowExtraItemsChanged         = null;
      public event EventHandler PatientRelatedStudiesChanged   = null;
      public event EventHandler PatientRelatedSeriesChanged    = null;
      public event EventHandler PatientRelatedInstancesChanged = null;
      public event EventHandler StudyRelatedSeriesChanged      = null;
      public event EventHandler StudyRelatedInstancesChanged   = null;
      public event EventHandler SeriesRelatedInstancesChanged  = null;
      public event EventHandler IodXmlPathChanged              = null;
      
      public event EventHandler LimitCFindRspChanged           = null;
      public event EventHandler MaximumCountCFindRspChanged    = null;
      
      public event EventHandler ServiceStatusChanged           = null;
            
      private void AddIsDirtyHandlers()
      {
         if (_dirtyHandlersAdded == false)
         {
            _dirtyHandlersAdded = true;

            chkServerRequestDatasetValidationZero.CheckedChanged              += new EventHandler(OnSetIsDirty);
            chkServerRequestDatasetValidationMultiple.CheckedChanged          += new EventHandler(OnSetIsDirty);
            chkServerRequestDatasetValidationPrivateElements.CheckedChanged   += new EventHandler(OnSetIsDirty);
            chkServerRequestDatasetValidationExtraElements.CheckedChanged     += new EventHandler(OnSetIsDirty);
            IncludePatientStudiesCheckBox.CheckedChanged                      += new EventHandler(OnSetIsDirty);
            IncludePatientSeriesCheckBox.CheckedChanged                       += new EventHandler(OnSetIsDirty);
            IncludePatientInstancesCheckBox.CheckedChanged                    += new EventHandler(OnSetIsDirty);
            IncludeStudySeriesCheckBox.CheckedChanged                         += new EventHandler(OnSetIsDirty);
            IncludeStudyInstancesCheckBox.CheckedChanged                      += new EventHandler(OnSetIsDirty);
            IncludeSeriesInstancesCheckBox.CheckedChanged                     += new EventHandler(OnSetIsDirty);
            QueryIODPathTextBox.TextChanged                                   += new EventHandler(OnSetIsDirty);
            
            chkLimitCFindResponses.CheckedChanged                             += new EventHandler(OnSetIsDirty);
            numericUpDownMaximumCountCFindRsp.ValueChanged                    += new EventHandler(OnSetIsDirty);
            numericUpDownMaximumCountCFindRsp.TextChanged                     += new EventHandler(OnSetIsDirty);
            textBoxStatus.TextChanged                                         += new EventHandler(OnSetIsDirty);
            
            chkLimitCFindResponses.CheckedChanged                             += new EventHandler(UpdateUI_Changed);
         }
      }


      
      public StorageAddInsConfiguration AddInsSettings
      {
         get
         {
            return _settings ;
         }
         
         set
         {
            if ( value != _settings ) 
            {
               _settings  = value ;
               
               if ( null != _settings ) 
               {
                  BindUI ( ) ;
               }
            }
         }
      }
      
      public bool AllowZeroItems
      {
         get
         {
            return chkServerRequestDatasetValidationZero.Checked;
         }
         
         set
         {
            chkServerRequestDatasetValidationZero.Checked = value;
         }
      }

      public bool AllowMultipleItems
      {
         get
         {
            return chkServerRequestDatasetValidationMultiple.Checked;
         }

         set
         {
            chkServerRequestDatasetValidationMultiple.Checked = value;
         }
      }

      public bool AllowPrivateItems
      {
         get
         {
            return chkServerRequestDatasetValidationPrivateElements.Checked;
         }

         set
         {
            chkServerRequestDatasetValidationPrivateElements.Checked = value;
         }
      }

      public bool AllowExtraItems
      {
         get
         {
            return chkServerRequestDatasetValidationExtraElements.Checked;
         }

         set
         {
            chkServerRequestDatasetValidationExtraElements.Checked = value;
         }
      }

      public bool PatientRelatedStudies
      {
         get
         {
            return IncludePatientStudiesCheckBox.Checked;
         }

         set
         {
            IncludePatientStudiesCheckBox.Checked = value;
         }
      }

      public bool PatientRelatedSeries
      {
         get
         {
            return IncludePatientSeriesCheckBox.Checked;
         }

         set
         {
            IncludePatientSeriesCheckBox.Checked = value;
         }
      }

      public bool PatientRelatedInstances
      {
         get
         {
            return IncludePatientInstancesCheckBox.Checked;
         }

         set
         {
            IncludePatientInstancesCheckBox.Checked = value;
         }
      }

      public bool StudyRelatedSeries
      {
         get
         {
            return IncludeStudySeriesCheckBox.Checked;
         }

         set
         {
            IncludeStudySeriesCheckBox.Checked = value;
         }
      }

      public bool StudyRelatedInstances
      {
         get
         {
            return IncludeStudyInstancesCheckBox.Checked;
         }

         set
         {
            IncludeStudyInstancesCheckBox.Checked = value;
         }
      }

      public bool SeriesRelatedInstances
      {
         get
         {
            return IncludeSeriesInstancesCheckBox.Checked;
         }

         set
         {
            IncludeSeriesInstancesCheckBox.Checked = value;
         }
      }
      
      public bool LimitCFindRsp
      {
         get
         {
            return chkLimitCFindResponses.Checked;
         }
         set
         {
            chkLimitCFindResponses.Checked = value;
         }
      }
      
      public int MaximumCountCFindRsp
      {
         get
         {
            return Convert.ToInt32(numericUpDownMaximumCountCFindRsp.Value);
         }
         set
         {
            if (value == 0)
               numericUpDownMaximumCountCFindRsp.Value = UpperLimitCountCFindRsp;
            else if (value > UpperLimitCountCFindRsp)
               numericUpDownMaximumCountCFindRsp.Value = UpperLimitCountCFindRsp;
            else
               numericUpDownMaximumCountCFindRsp.Value = Convert.ToDecimal(value);
         }
      }
      
      public int ServiceStatus
     {
         get
         {
            return Convert.ToInt32(textBoxStatus.Text, 16);
         }
         set
         {
            textBoxStatus.Text = ServiceStatusItem.ToHexValue(value);
         }
      }

      public string IodXmlPath
      {
         get
         {
            return QueryIODPathTextBox.Text;
         }

         set
         {
            QueryIODPathTextBox.Text = value;
         }
      }
      

      private void BindUI ( )
      {
         if ( !string.IsNullOrEmpty ( AddInsSettings.QueryAddIn.QueryIODPath ) )
         {
            XmlSchema schema ;
            Exception result ;
            
            schema   =  QueryCFindCommand.IODSchema ;
            
            result = ValidateIOD ( schema, AddInsSettings.QueryAddIn.QueryIODPath ) ;
            
            if ( null != result ) 
            {
               MessageBox.Show ( "Invalid Query IOD file.\n" + result.Message ) ;
            }
            else
            {
               QueryIODPathTextBox.Text = AddInsSettings.QueryAddIn.QueryIODPath ;
            }
         }
      }


      public Exception ValidateIOD ( XmlSchema schema, string iodPath )
      {
         Exception error ;
         XmlDocument iodDocument ;
         
         
         try
         {
            iodDocument = new XmlDocument ( ) ;
            
            iodDocument.Load ( iodPath ) ;
            
            iodDocument.Schemas.Add ( schema ) ;
            
            _validationException = null ;
            
            iodDocument.Validate ( iodSchemaValidationEventHandler ) ;
            
            error = _validationException ;
            
            _validationException = null ;
            
            return error ;
         }
         catch ( Exception exception ) 
         {
            return exception ;
         }
      }
      
      private void iodSchemaValidationEventHandler ( object sender, ValidationEventArgs e )
      {
         _validationException = e.Exception ;
      }
      
      private Exception _validationException ;

      private void btnBrowseQueryIODPath_Click(object sender, EventArgs e)
      {
         try
         {
            if ( iodOpenFileDialog.ShowDialog ( ) == DialogResult.OK )
            {
               SetQueryIODPath(iodOpenFileDialog.FileName);
            }
         }
         catch ( Exception ex )
         {
            Messager.ShowError ( this, ex ) ;
         }
      }

      private void SetQueryIODPath(string fileName)
      {
         if ( string.IsNullOrEmpty ( fileName ) )
         {
            QueryIODPathTextBox.Text = "";

            AddInsSettings.QueryAddIn.QueryIODPath = "";
         }
         else
         {
            Exception validationResult;

            validationResult = ValidateIOD(QueryCFindCommand.IODSchema, fileName);

            if (null != validationResult)
            {
               Messager.ShowError(this, "Invalid Query IOD file.\n" + validationResult.Message);
            }
            else
            {
               QueryIODPathTextBox.Text = fileName;

               AddInsSettings.QueryAddIn.QueryIODPath = fileName;
            }
         }
      }
      
      void QueryIODPathTextBox_Validating(object sender, CancelEventArgs e)
      {
         try
         {
            e.Cancel = false ;
            
            if ( !string.IsNullOrEmpty ( QueryIODPathTextBox.Text ) )
            {
               Exception validationResult = ValidateIOD ( QueryCFindCommand.IODSchema, QueryIODPathTextBox.Text ) ;
               
               if ( null != validationResult )
               {
                  Messager.ShowError(this, "Invalid Query IOD file.\n" + validationResult.Message);
                  
                  e.Cancel = true ;
               }
            }
         }
         catch ( Exception ex )
         {
            Messager.ShowError ( this, ex ) ;
         }
      }
      
      void QueryIODPathTextBox_TextChanged(object sender, EventArgs e)
      {
         try
         {
            //SetQueryIODPath ( QueryIODPathTextBox.Text ) ;
         }
         catch ( Exception ex )
         {
            Messager.ShowError ( this, ex ) ;
         }
      }

      private void OnSetIsDirty(object sender, EventArgs e)
      {
         try
         {
            IsDirty = true;
            OnSettingsChanged(sender, e);

            if (sender == chkServerRequestDatasetValidationZero)
            {
               if (AllowZeroItemsChanged != null)
                  AllowZeroItemsChanged(sender, e);
            }
            else if (sender == chkServerRequestDatasetValidationMultiple)
            {
               if (AllowMultipleItemsChanged != null)
                  AllowMultipleItemsChanged(sender, e);
            }
            if (sender == chkServerRequestDatasetValidationPrivateElements)
            {
               if (AllowPrivateItemsChanged != null)
                  AllowPrivateItemsChanged(sender, e);
            }
            else if (sender == chkServerRequestDatasetValidationExtraElements)
            {
               if (AllowExtraItemsChanged != null)
                  AllowExtraItemsChanged(sender, e);
            }
            else if (sender == IncludePatientStudiesCheckBox)
            {
               if (PatientRelatedStudiesChanged != null)
                  PatientRelatedStudiesChanged(sender, e);
            }
            else if (sender == IncludePatientSeriesCheckBox)
            {
               if (PatientRelatedSeriesChanged != null)
                  PatientRelatedSeriesChanged(sender, e);
            }
            else if (sender == IncludePatientInstancesCheckBox)
            {
               if (PatientRelatedInstancesChanged != null)
                  PatientRelatedInstancesChanged(sender, e);
            }
            else if (sender == IncludeStudySeriesCheckBox)
            {
               if (StudyRelatedSeriesChanged != null)
                  StudyRelatedSeriesChanged(sender, e);
            }
            else if (sender == IncludeStudyInstancesCheckBox)
            {
               if (StudyRelatedInstancesChanged != null)
                  StudyRelatedInstancesChanged(sender, e);
            }
            else if (sender == IncludeSeriesInstancesCheckBox)
            {
               if (SeriesRelatedInstancesChanged != null)
                  SeriesRelatedInstancesChanged(sender, e);
            }
            else if (sender == QueryIODPathTextBox)
            {
               if (IodXmlPathChanged != null)
                  IodXmlPathChanged(sender, e);
            }
            else if (sender == chkLimitCFindResponses)
            {
               if (LimitCFindRspChanged != null)
                  LimitCFindRspChanged(sender, e);
            }
            
            else if (sender == numericUpDownMaximumCountCFindRsp)
            {
               if (MaximumCountCFindRspChanged != null)
                  MaximumCountCFindRspChanged(sender, e);
            }
            else if (sender == textBoxStatus )
            {
               if (ServiceStatusChanged != null)
                  ServiceStatusChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      public bool IsDirty
      {
         get
         {
            return _isDirty;
         }
         internal /*private */ set
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


      private void UpdateUI()
      {
         numericUpDownMaximumCountCFindRsp.Enabled = chkLimitCFindResponses.Checked;
         comboBoxStatus.Enabled = chkLimitCFindResponses.Checked;
         textBoxStatus.Enabled = chkLimitCFindResponses.Checked;
      }
      
      private void UpdateUI_Changed(object sender, EventArgs e)
      {
         try
         {
            UpdateUI();
         }
         catch(Exception)
         {
         }
      }
      
   }
}
