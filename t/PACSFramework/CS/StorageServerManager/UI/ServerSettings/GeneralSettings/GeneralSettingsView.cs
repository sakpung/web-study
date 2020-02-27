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
using Leadtools.Dicom;
using System.ServiceProcess;
using Leadtools.Dicom.Server.Admin;
using Leadtools.Dicom.AddIn.Common;
using System.Threading;
using Leadtools.Medical.Storage.AddIns.Messages;
using Leadtools.Logging.Medical;
using Leadtools.Logging;

namespace Leadtools.Demos.StorageServer.UI
{
   public partial class GeneralSettingsView : UserControl
   {
      #region Public
         
         #region Methods
               
            public GeneralSettingsView()
            {
               InitializeComponent();

               AddServerToolStripButton.Click    += new EventHandler       ( AddServerToolStripButton_Click ) ;
               DeleteServerToolStripButton.Click += new EventHandler       ( DeleteServerToolStripButton_Click ) ;
               AeTitleTextBox.Validating         += new CancelEventHandler ( AeTitleTextBox_Validating ) ;
               AeTitleTextBox.TextChanged        += new EventHandler       ( AeTitleTextBox_TextChanged );

               IpAddressComboBox.SelectionChangeCommitted += new EventHandler ( OnIpAddressChanged ) ;
               PortNumericUpDown.ValueChanged             += new EventHandler ( OnPortChanged ) ;
               ImplementationClassTextBox.TextChanged     += new EventHandler ( OnImplementationClassUIDChanged ) ;
               ImplementationVersionTextBox.TextChanged   += new EventHandler ( OnImplementationVersionNameChanged ) ;
               StartModeComboBox.SelectionChangeCommitted += new EventHandler ( OnServiceStartModeChanged  ) ;

               IpV4CheckBox.CheckedChanged                  += new EventHandler(OnIpTypeChanged);
               IpV6CheckBox.CheckedChanged                  += new EventHandler(OnIpTypeChanged);
               IpBothCheckBox.CheckedChanged                += new EventHandler(OnIpTypeChanged);

#if LEADTOOLS_V19_OR_LATER
               TestServiceButton.Click                      += new EventHandler(TestServiceButton_Click);
               GarbageCollectServiceButton.Click            += new EventHandler(GarbageCollectServiceButton_Click);
               ForceTerminationsServiceButton.Click         += new EventHandler(ForceTerminationsServiceButton_Click);
#else
               TestServiceButton.Visible = false;
#endif
               
               // IsDirty Handlers
               ServiceDisplayNameTextBox.TextChanged        += new EventHandler(ServiceDisplayNameTextBox_TextChanged);
               ServiceDescriptionTextBox.TextChanged        += new EventHandler(ServiceDescriptionTextBox_TextChanged);
               

            }

            public bool CanIpV6CheckBox
            {
               get
               {
                  return IpV6CheckBox.Enabled;
               }

               set
               {
                  IpV6CheckBox.Enabled = value;
               }
            }
            
            public bool CanIpBothCheckBox
            {
               get
               {
                  return IpBothCheckBox.Enabled;
               }
               
               set
               {
                  IpBothCheckBox.Enabled = value;
               }
            }


            public void SetIpAddressList ( string [] ipadresses ) 
            {
               IpAddressComboBox.DataSource = ipadresses ;
            }
            
            public int SelectedIpAddressIndex 
            {
               get;
               set;
            }
            
            public string SelectedIp
            {
               get;
               set;
            }

            public void SetStartupModeList ( string[] modes ) 
            {
               StartModeComboBox.DataSource = modes ;
            }

            public void AETitelValidationMessage ( string validationMessage )
            {
               AETitleErrorProvider.SetError ( AeTitleTextBox, validationMessage ) ;
            }
            
            public void SetWindowsServiceDescription( string description)
            {
               ServiceDescriptionTextBox.Text = description;
            }
            
            public void SetWindowsServiceDescriptionEnabled(bool enabled)
            {
               ServiceDescriptionTextBox.Enabled = enabled;
            }
         
         #endregion
         
         #region Properties
         
            public string AeTitle
            {
               get
               {
                  return AeTitleTextBox.Text ;
               }

               set
               {
                  AeTitleTextBox.Text = value ;
               }
            }

            public string IpAddress
            {
               get
               {
                  return IpAddressComboBox.SelectedItem as string ;
               }

               set
               {
                  IpAddressComboBox.SelectedItem = value ;
               }
            }

            public int Port
            {
               get
               {
                  return (int) PortNumericUpDown.Value ;
               }

               set
               {
                  PortNumericUpDown.Value  = value ;
               }
            }

            public string ImplementationClassUID
            {
               get
               {
                  return ImplementationClassTextBox.Text ;
               }

               set
               {
                  ImplementationClassTextBox.Text = value ;
               }
            }

            public string ImplementationVersion
            {
               get
               {
                  return ImplementationVersionTextBox.Text ;
               }

               set
               {
                  ImplementationVersionTextBox.Text = value ;
               }
            }

            public string ServiceDisplayName
            {
               get
               {
                  return ServiceDisplayNameTextBox.Text ;
               }

               set
               {
                  ServiceDisplayNameTextBox.Text = value ;
               }
            }

            public string ServiceDecription
            {
               get
               {
                  return ServiceDescriptionTextBox.Text ;
               }

               set
               {
                  ServiceDescriptionTextBox.Text = value ;
               }
            }

            public string ServiceStartupMode
            {
               get
               {
                  return StartModeComboBox.SelectedItem as string ;
               }

               set
               {
                  StartModeComboBox.SelectedItem = value ;
               }
            }

            public bool CanChangeServiceDisplayName
            {
               get
               {
                  return ServiceDisplayNameTextBox.Enabled ;
               }

               set
               {
                  ServiceDisplayNameTextBox.Enabled = value ;
               }
            }

            public bool CanChangeServiceDescription
            {
               get
               {
                  return ServiceDescriptionTextBox.Enabled ;
               }

               set
               {
                  ServiceDescriptionTextBox.Enabled = value ;
               }
            }

            public bool CanAddServer
            {
               get
               {
                  return AddServerToolStripButton.Enabled ;
               }

               set
               {
                  AddServerToolStripButton.Enabled = value ;
               }
            }

            public bool CanDeleteServer
            {
               get
               {
                  return DeleteServerToolStripButton.Enabled ;
               }

               set
               {
                  DeleteServerToolStripButton.Enabled = value ;
               }
            }

            public bool CanShowServerDelete
            {
               get
               {
                  return DeleteServerToolStripButton.Visible;
               }
               set
               {
                  DeleteServerToolStripButton.Visible = value;
               }
            }
            
            public DicomNetIpTypeFlags IpType
            {
               get
               {
                  DicomNetIpTypeFlags flags = DicomNetIpTypeFlags.Ipv4OrIpv6 ;
                  
                  if ( IpBothCheckBox.Checked ) 
                  {
                     return flags ;
                  }
                  else
                  {
                     if ( !IpV4CheckBox.Checked ) 
                     {
                        flags ^= DicomNetIpTypeFlags.Ipv4 ;
                     }
                     
                     if ( !IpV6CheckBox.Checked ) 
                     {
                        flags ^= DicomNetIpTypeFlags.Ipv6 ;
                     }
                     
                     return flags ;
                  }
               }
               
               set
               {
                  if ( value == DicomNetIpTypeFlags.Ipv4 ) 
                  {
                     IpV4CheckBox.Checked = true ;
                  }
                  else if ( value == DicomNetIpTypeFlags.Ipv6 )
                  {
                     IpV6CheckBox.Checked = true ;
                  }
                  else
                  {
                     IpBothCheckBox.Checked = true ;
                  }
               }
            }
            
            public bool CanSelectIpAddress
            {
               get
               {
                  return IpAddressComboBox.Enabled ;
               }
               
               set
               {
                  IpAddressComboBox.Enabled = value ;
               }
            }
            
            
            public bool CanSelectIpType
            {
               get
               {
                  return IpTypePanel.Enabled ;
               }
               
               set
               {
                  IpTypePanel.Enabled = value ;
               }
            }
            
            public bool CanSelectPort
            {
               get
               {
                  return PortNumericUpDown.Enabled;
               }
               
               set
               {
                  PortNumericUpDown.Enabled = value;
               }
            }

            void OnValueChanged(object sender, EventArgs e)
            {
               SetIsDirty(sender, e);
            }

            private bool _isDirty = false;
            
            private void SetIsDirty(object sender, EventArgs e)
            {
               IsDirty = true;
               OnSettingsChanged(sender, e);
            }

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
            
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public event EventHandler AddServer ;
            public event EventHandler DeleteServer ;
            public event EventHandler IpAddressChanged ;
            public event EventHandler PortChanged ;
            public event EventHandler ImplementationClassUIDChanged ;
            public event EventHandler ImplementationVersionNameChanged ;
            public event EventHandler ServiceStartModeChanged ;
            public event EventHandler AETitleChanged ;
            public event EventHandler SettingsChanged ;
            public event EventHandler IpTypeChanged;
            
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
         
            void DeleteServerToolStripButton_Click(object sender, EventArgs e)
            {
               try
               {
                  this.ValidateChildren ( ValidationConstraints.None ) ;
                  
                  if ( null != DeleteServer ) 
                  {
                     DeleteServer ( this, EventArgs.Empty ) ;
                  }
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }

            void AddServerToolStripButton_Click(object sender, EventArgs e)
            {
               try
               {
                  if ( this.ValidateChildren ( ValidationConstraints.None ) )
                  {
                     if ( null != AddServer )
                     {
                        AddServer ( this, e ) ;
                     }
                  }
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }

#if LEADTOOLS_V19_OR_LATER
            void TestService(string dicomServiceMessageGuid, string testType, string successMessage)
            {
               string message = string.Empty;
               string errorMessage;
               string serviceName = string.Empty;
               DicomService dicomService = null;
               Messager.Caption = "DICOM Server";

               if (ServerState.Instance != null && ServerState.Instance.ServerService!= null)
               {
                  dicomService = ServerState.Instance.ServerService;
               }

               if (ServerState.Instance != null && ServerState.Instance.ServerService!= null && !string.IsNullOrEmpty(ServerState.Instance.ServerService.ServiceName))
               {
                  serviceName = ServerState.Instance.ServerService.ServiceName;
               }

               if (dicomService == null)
               {
                  message = string.Format("{0} listening Service must be running to {1}.", serviceName, testType);
                  Messager.ShowWarning(this, message);
                  return;
               }
               DicomServiceTesterResult result = DicomServiceTester.SendDicomServiceMessage(dicomService, dicomServiceMessageGuid, out errorMessage);

               switch(result)
               {
                  case DicomServiceTesterResult.Success:
                     message = string.Format("{0} {1}", serviceName, successMessage);
                     Log(message);
                     break;
                  case DicomServiceTesterResult.ErrorServiceIsNull:
                     message = string.Format("Listening Service has not been created.");
                     break;
                  case DicomServiceTesterResult.ErrorServiceNotRunning:
                     message = string.Format("{0} listening Service must be running to {1}.", serviceName, testType);
                     break;
                  case DicomServiceTesterResult.ErrorServiceCannotAccessDatabase:
                     message = string.Format("{0} listening Service cannot access database. {1}", serviceName, errorMessage);
                     break;
                  case DicomServiceTesterResult.ErrorServiceNotResponding:
                     message = string.Format("Unable to communicate with {0} listening service.", serviceName);
                     break;
               }

               if (result == DicomServiceTesterResult.Success)
               {
                  Messager.ShowInformation(this, message);
               }
               else
               {
                  Messager.ShowWarning(this, message);
               }
            }

            private static void Log(string message)
            {
               LogType leadLogType = LogType.Information;

               Logger.Global.Log(string.Empty,
                                 string.Empty,
                                 string.Empty,
                                 0,
                                 string.Empty,
                                 string.Empty,
                                 0,
                                 DicomCommandType.Undefined,
                                 DateTime.Now,
                                 leadLogType,
                                 MessageDirection.None,
                                 message,
                                 null,
                                 null
                  );
            }

            void GarbageCollectServiceButton_Click(object sender, EventArgs e)
            {
               TestService(MessageNames.GarbageCollectDicomServer, @"reclaim memory", @"listening service memory has been reclaimed.");
            }

            void ForceTerminationsServiceButton_Click(object sender, EventArgs e)
            {
               DialogResult dr = Messager.ShowQuestion(this, @"You are about to force termination of the listening service.  Do you want to continue?",
                                     MessageBoxButtons.YesNo);
               if (dr == DialogResult.Yes)
               {
                  TestService(MessageNames.CrashDicomServer, @"force termination", @"listening service is being terminated.");
               }
               else
               {
                  Messager.ShowInformation(this, @"The listening service is not being terminated.");
               }
            }

            void TestServiceButton_Click(object sender, EventArgs e)
            {
               TestService(StorageAddinMessage.CanAccessDatabase,  @"verify", @"listening service is valid.");
            }
#endif // #if LEADTOOLS_V19_OR_LATER

            void AeTitleTextBox_Validating ( object sender, CancelEventArgs e )
            {
               try
               {
                  AETitleErrorProvider.SetError ( AeTitleTextBox, string.Empty ) ;

                  if ( null != AETitleChanged ) 
                  {
                     AETitleChanged  ( this, e ) ;
                  }

                  e.Cancel = AETitleErrorProvider.GetError ( AeTitleTextBox ) != string.Empty ;
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }


            void AeTitleTextBox_TextChanged(object sender, EventArgs e)
            {
               SetIsDirty(sender, e);
            }


            void OnSettingsChanged ( object sender, EventArgs e ) 
            {
               try
               {
                  if ( null != SettingsChanged ) 
                  {
                     SettingsChanged ( this, e ) ;
                  }
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }
            
            private void OnIpAddressChanged ( object sender, EventArgs e ) 
            {
               if ( null != IpAddressChanged )
               {
                  IpAddressChanged ( this, e ) ;
                  OnSettingsChanged( sender, e);
               }
            }
            
            private void OnPortChanged  ( object sender, EventArgs e )
            {
               if ( PortChanged != null )
               {
                  PortChanged ( this, e ) ;
                  SetIsDirty (sender, e );
               }
            }
            
            private void OnImplementationClassUIDChanged ( object sender, EventArgs e )
            {
               if ( null != ImplementationClassUIDChanged ) 
               {
                  ImplementationClassUIDChanged ( this, e ) ;
                  SetIsDirty( this, e);
               }
            }
            
            private void OnImplementationVersionNameChanged  ( object sender, EventArgs e )
            {
               if ( null != ImplementationVersionNameChanged ) 
               {
                  ImplementationVersionNameChanged ( this, e ) ;
                  SetIsDirty( this, e);
               }
            }
            
            private void OnServiceStartModeChanged  ( object sender, EventArgs e )
            {
               if ( null != ServiceStartModeChanged ) 
               {
                  ServiceStartModeChanged ( this, e ) ;
                  SetIsDirty( this, e);
               }
            }


            private void OnIpTypeChanged(object sender, EventArgs e)
            {
               RadioButton rb = sender as RadioButton;
               if ((null != IpTypeChanged) && (rb.Checked))
               {
                  IpTypeChanged(this, e);
                  SetIsDirty(sender, e);
               }
            }

            private void ServiceDescriptionTextBox_TextChanged(object sender, EventArgs e)
            {
               SetIsDirty(sender, e);
            }

            private void ServiceDisplayNameTextBox_TextChanged(object sender, EventArgs e)
            {
               SetIsDirty(sender, e);
            }
         
         #endregion

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
