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
using Leadtools.Demos;

namespace Leadtools.Medical.Winforms
{
   public partial class EventLogConfigurationView : UserControl
   {
      #region Public
         
         #region Methods
         
            public EventLogConfigurationView()
            {
               InitializeComponent ( ) ;

               EventFilterGroupBox.Enabled          = EnableLoggingCheckBox.Checked ;
               AutoSaveLogGroupBox.Enabled          = EnableAutoSaveLogCheckBox.Checked ;
               
               // LogDSCheckBox_CheckedChanged(this, null);
               
               EnableLoggingCheckBox.CheckedChanged     += new EventHandler ( EnableLoggingCheckBox_CheckedChanged ) ;
               EnableAutoSaveLogCheckBox.CheckedChanged += new EventHandler ( EnableAutoSaveLogCheckBox_CheckedChanged ) ;
               LogDSCheckBox.CheckedChanged             += new EventHandler ( LogDSCheckBox_CheckedChanged ) ;
               BrowseAutoSaveButton.Click               += new EventHandler ( BrowseAutoSaveButton_Click ) ;
               BrowseDataSetDirectoryButton.Click       += new EventHandler ( BrowseDataSetDirectoryButton_Click ) ;
               DicomMessagesCheckbox.CheckedChanged     += new EventHandler (DicomMessagesCheckbox_CheckedChanged);


               // IsDirty
               EnableLoggingCheckBox.CheckedChanged      += new EventHandler(OnSetIsDirty);
               EnableAutoSaveLogCheckBox.CheckedChanged  += new EventHandler(OnSetIsDirty);
               AuoSaveDirectoryTextBox.TextChanged       += new EventHandler(OnSetIsDirty);
               LogDSCheckBox.CheckedChanged              += new EventHandler(OnSetIsDirty);
               BrowseAutoSaveButton.Click                += new EventHandler(OnSetIsDirty);
               DataSetDirectoryTextBox.TextChanged       += new EventHandler(OnSetIsDirty);
               DicomMessagesCheckbox.CheckedChanged      += new EventHandler(OnSetIsDirty);
               EnableThreadingCheckBox.CheckedChanged    += new EventHandler(OnSetIsDirty);
               InformationCheckBox.CheckedChanged        += new EventHandler(OnSetIsDirty);
               WarningsCheckBox.CheckedChanged           += new EventHandler(OnSetIsDirty);
               DebugCheckBox.CheckedChanged              += new EventHandler(OnSetIsDirty);
               ErrorCheckBox.CheckedChanged              += new EventHandler(OnSetIsDirty);
               AuditCheckBox.CheckedChanged              += new EventHandler(OnSetIsDirty);
               AutoSaveDaysNumericUpDown.ValueChanged    += new EventHandler(OnSetIsDirty);
               AutoSaveTimeDateTimePicker.ValueChanged   += new EventHandler(OnSetIsDirty);
               DicomMessagesCheckbox.CheckedChanged      += new EventHandler(OnSetIsDirty);
               DeleteSavedLogCheckBox.CheckedChanged     += new EventHandler(OnSetIsDirty);
            }

         

         #endregion
         
         #region EventHandlers
            public event EventHandler EnableLoggingChanged = null;
            public event EventHandler EnableAutoSaveLogChanged = null;
            public event EventHandler AutoSaveDirectoryChanged = null;
            public event EventHandler LogDicomDatasetChanged = null;
            public event EventHandler LogDicomMessagesChanged = null;
            public event EventHandler DataSetDirectoryChanged = null;
            public event EventHandler EnableThreadingChanged = null;
            public event EventHandler LogInformationChanged = null;
            public event EventHandler LogWarningsChanged = null;
            public event EventHandler LogDebugChanged = null;
            public event EventHandler LogErrorChanged = null;
            public event EventHandler LogAuditChanged = null;
            public event EventHandler AutoSaveDaysChanged = null;
            public event EventHandler AutoSaveTimeChanged = null;
            public event EventHandler DeleteSavedLogChanged = null;
         #endregion
         
         #region Properties
         
            public bool EnableLogging
            {
               get
               {
                  return EnableLoggingCheckBox.Checked ;
               }
               
               set
               {
                  EnableLoggingCheckBox.Checked = value ;
               }
            }
            
            public bool EnableThreading
            {
               get
               {
                  return EnableThreadingCheckBox.Checked ;
               }
               
               set
               {
                  EnableThreadingCheckBox.Checked = value ;
               }
            }
            
            public bool LogInformation 
            {
               get
               {
                  return InformationCheckBox.Checked ;
               }
               
               set
               {
                  InformationCheckBox.Checked = value ;
               }
            }
            
            public bool LogWarnings
            {
               get
               {
                  return WarningsCheckBox.Checked ;
               }
               
               set
               {
                  WarningsCheckBox.Checked = value ;
               }
            }
            
            public bool LogErrors
            {
               get
               {
                  return ErrorCheckBox.Checked ;
               }
               
               set
               {
                  ErrorCheckBox.Checked = value ;
               }
            }
            
            public bool LogDebug
            {
               get
               {
                  return DebugCheckBox.Checked ;
               }
               
               set
               {
                  DebugCheckBox.Checked = value ;
               }
            }
            
            public bool LogAudit
            {
               get
               {
                  return AuditCheckBox.Checked ;
               }
               
               set
               {
                  AuditCheckBox.Checked = value ;
               }
            }

            public bool LogDicom
            {
               get
               {
                  return DicomMessagesCheckbox.Checked;
               }

               set
               {
                  DicomMessagesCheckbox.Checked = value;
               }
            }
            
            public bool LogDicomDataSet
            {
               get
               {
                  return LogDSCheckBox.Checked ;
               }
               
               set
               {
                  LogDSCheckBox.Checked = value ;
               }
            }
            
            public bool EnableAutoSaveLog
            {
               get
               {
                  return EnableAutoSaveLogCheckBox.Checked ;
               }
               
               set
               {
                  EnableAutoSaveLogCheckBox.Checked = value ;
               }
            }
            
            public int AutoSaveDaysPeriod
            {
               get
               {
                  return (int) AutoSaveDaysNumericUpDown.Value ;
               }
               
               set
               {
                  AutoSaveDaysNumericUpDown.Value = value ;
               }
            }
            
            public DateTime AutoSaveTime
            {
               get
               {
                  return AutoSaveTimeDateTimePicker.Value ;
               }
               
               set
               {
                  AutoSaveTimeDateTimePicker.Value = value ;
               }
            }
            
            public string AutoSaveDirectory
            {
               get
               {
                  return AuoSaveDirectoryTextBox.Text ;
               }
               
               set
               {
                  AuoSaveDirectoryTextBox.Text = value ;
               }
            }
            
            public bool DeleteSavedLog
            {
               get
               {
                  return DeleteSavedLogCheckBox.Checked ;
               }
               
               set
               {
                  DeleteSavedLogCheckBox.Checked = value ;
               }
            }
            
            public string DataSetDirectory
            {
               get
               {
                  return DataSetDirectoryTextBox.Text ;
               }
               
               set
               {
                  DataSetDirectoryTextBox.Text = value ;
               }
            }
            
         #endregion

         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events

            void DicomMessagesCheckbox_CheckedChanged(object sender, EventArgs e)
            {
               try
               {
                  LogDSCheckBox.Enabled = DicomMessagesCheckbox.Checked;
                  LogDSCheckBox_CheckedChanged(sender, e);
               }
               catch (Exception ex)
               {
                  Messager.ShowError(this, ex);
               }
            }
         
            void EnableAutoSaveLogCheckBox_CheckedChanged(object sender, EventArgs e)
            {
               try
               {
                  AutoSaveLogGroupBox.Enabled = EnableAutoSaveLogCheckBox.Checked ;
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }

            void EnableLoggingCheckBox_CheckedChanged ( object sender, EventArgs e )
            {
               try
               {
                  EventFilterGroupBox.Enabled = EnableLoggingCheckBox.Checked ;
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }
            
            void LogDSCheckBox_CheckedChanged(object sender, EventArgs e)
            {
               try
               {
                  BrowseDataSetDirectoryButton.Enabled = LogDSCheckBox.Checked && DicomMessagesCheckbox.Checked;
                  DataSetDirectoryTextBox.Enabled = LogDSCheckBox.Checked && DicomMessagesCheckbox.Checked;
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
               
            }
            
            void BrowseAutoSaveButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  using ( FolderBrowserDialog folderDlg = new FolderBrowserDialog ( ) )
                  {
                     folderDlg.SelectedPath = AuoSaveDirectoryTextBox.Text ;
                     
                     if ( folderDlg.ShowDialog ( ) == DialogResult.OK ) 
                     {
                        AuoSaveDirectoryTextBox.Text = folderDlg.SelectedPath ;
                     }
                  }
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
               
            }
            
            void BrowseDataSetDirectoryButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  using ( FolderBrowserDialog folderDlg = new FolderBrowserDialog ( ) )
                  {
                     folderDlg.SelectedPath = DataSetDirectoryTextBox.Text ;
                     
                     if ( folderDlg.ShowDialog ( ) == DialogResult.OK ) 
                     {
                        DataSetDirectoryTextBox.Text = folderDlg.SelectedPath ;
                     }
                  }
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

                  if (sender == EnableLoggingCheckBox)
                  {
                     if (EnableLoggingChanged != null)
                        EnableLoggingChanged(sender, e);
                  }
                  else if (sender == EnableAutoSaveLogCheckBox)
                  {
                     if (EnableAutoSaveLogChanged != null)
                        EnableAutoSaveLogChanged(sender, e);
                  }
                  
                  else if (sender == AuoSaveDirectoryTextBox)
                  {
                     if (AutoSaveDirectoryChanged != null)
                        AutoSaveDirectoryChanged(sender, e);
                  }
                  
                  else if (sender == LogDSCheckBox)
                  {
                     if (LogDicomDatasetChanged != null)
                        LogDicomDatasetChanged(sender, e);
                  }
                  
                  else if (sender == DicomMessagesCheckbox)
                  {
                     if (LogDicomMessagesChanged != null)
                        LogDicomMessagesChanged(sender, e);
                  }
                  
                  else if (sender == this.DataSetDirectoryTextBox)
                  {
                     if (DataSetDirectoryChanged != null)
                        DataSetDirectoryChanged(sender, e);
                  }
                  
                  else if (sender == EnableThreadingCheckBox)
                  {
                     if (EnableThreadingChanged != null)
                        EnableThreadingChanged(sender, e);
                  }
                  
                  else if (sender == InformationCheckBox)
                  {
                     if (LogInformationChanged != null)
                        LogInformationChanged(sender, e);
                  }
                  
                  else if (sender == WarningsCheckBox)
                  {
                     if (LogWarningsChanged != null)
                        LogWarningsChanged(sender, e);
                  }
                  
                  else if (sender == DebugCheckBox)
                  {
                     if (LogDebugChanged != null)
                        LogDebugChanged(sender, e);
                  }
                  
                  else if (sender == ErrorCheckBox)
                  {
                     if (LogErrorChanged != null)
                        LogErrorChanged(sender, e);
                  }
                  
                  else if (sender == AuditCheckBox)
                  {
                     if (LogAuditChanged != null)
                        LogAuditChanged(sender, e);
                  }
                  
                  else if (sender == AutoSaveDaysNumericUpDown)
                  {
                     if (AutoSaveDaysChanged != null)
                        AutoSaveDaysChanged(sender, e);
                  }
                  
                  else if (sender == AutoSaveTimeDateTimePicker)
                  {
                     if (AutoSaveTimeChanged != null)
                        AutoSaveTimeChanged(sender, e);
                  }
                  else if (sender == DeleteSavedLogCheckBox)
                  {
                     if (DeleteSavedLogChanged != null)
                        DeleteSavedLogChanged(sender, e);
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
         
         #endregion

            private void EventLogConfigurationView_VisibleChanged(object sender, EventArgs e)
            {
               DicomMessagesCheckbox_CheckedChanged(sender, e);
            }
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}
