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
using System.IO;
using Leadtools.Dicom.Common.Constants;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.Winforms;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.DicomDemos;

namespace Leadtools.Demos.StorageServer.UI
{
   public partial class ServerOptionsView : UserControl
   {
      #region Public

      #region Methods

      public ServerOptionsView()
      {
         InitializeComponent();

         AllowAnonCheckBox.CheckedChanged += new EventHandler(OnSettingsChanged);
         AllowAnonymousCMoveCheckBox.CheckedChanged += new EventHandler(OnSettingsChanged);
         AnonymousClientPortNumericUpDown.ValueChanged += new EventHandler(OnSettingsChanged);
         AllowMultipleCheckBox.CheckedChanged += new EventHandler(OnSettingsChanged);

         UseTlsSecurityCheckBox.CheckedChanged += UseTlsSecurityCheckBox_CheckedChanged;

         MaxClientsNumericUpDown.ValueChanged += new EventHandler(OnSettingsChanged);
         ClientTimeoutNumericUpDown.ValueChanged += new EventHandler(OnSettingsChanged);
         AddinsTimeoutNumericUpDown.ValueChanged += new EventHandler(OnSettingsChanged);
         ReconnectTimeoutNumericUpDown.ValueChanged += new EventHandler(OnSettingsChanged);
         TempFolderTextBox.TextChanged += new EventHandler(OnSettingsChanged);

         rbRelationalQueriesNever.CheckedChanged += new EventHandler(OnSettingsChanged);
         rbRelationalQueriesNegotiate.CheckedChanged += new EventHandler(OnSettingsChanged);
         rbRelationalQueriesAlways.CheckedChanged += new EventHandler(OnSettingsChanged);

         checkBoxEnableDefaultRoleSelection.CheckedChanged += new EventHandler(OnSettingsChanged);
         radioButtonProviderRoleAccept.CheckedChanged += new EventHandler(OnSettingsChanged);
         radioButtonUserRoleAccept.CheckedChanged += new EventHandler(OnSettingsChanged);

         BrowseTempButton.Click += new EventHandler(BrowseTempButton_Click);
      }

      bool ignoreCheckChanged = false;

      private void UseTlsSecurityCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         if (UseTlsSecurityCheckBox.Checked)
         {
            if (Utils.VerifyOpensslVersion(this.ParentForm) == false)
            {
               ignoreCheckChanged = true;
               UseTlsSecurityCheckBox.Checked = false;
               return;
            }
         }

         if (ignoreCheckChanged == false)
         {
            EventBroker.Instance.PublishEvent<ServerSettingsSecureChangedEventArgs>(this, new ServerSettingsSecureChangedEventArgs(UseTlsSecurityCheckBox.Checked));
            OnSettingsChanged(sender, e);
         }
         ignoreCheckChanged = false;
      }

      void BrowseTempButton_Click(object sender, EventArgs e)
      {
         using (FolderBrowserDialog browseFolderDlg = new FolderBrowserDialog())
         {
            browseFolderDlg.SelectedPath = TempFolderTextBox.Text;

            if (browseFolderDlg.ShowDialog(this) == DialogResult.OK)
            {
               TempFolderTextBox.Text = browseFolderDlg.SelectedPath;
            }
         }
      }

      #endregion

      #region Properties

      public bool AllowAnonymousConnections
      {
         get
         {
            return AllowAnonCheckBox.Checked;
         }

         set
         {
            AllowAnonCheckBox.Checked = value;
         }
      }

      public bool AllowAnonymousCMove
      {
         get
         {
            return AllowAnonymousCMoveCheckBox.Checked;
         }

         set
         {
            AllowAnonymousCMoveCheckBox.Checked = value;
         }
      }

      public int AnonymousClientPort
      {
         get
         {
            return (int)AnonymousClientPortNumericUpDown.Value;
         }

         set
         {
            AnonymousClientPortNumericUpDown.Value = value;
         }
      }

      public bool AllowClientMultipleConnections
      {
         get
         {
            return AllowMultipleCheckBox.Checked;
         }

         set
         {
            AllowMultipleCheckBox.Checked = value;
         }
      }

      public bool UseTlsSecurity
      {
         get
         {
            return UseTlsSecurityCheckBox.Checked;
         }
         set
         {
            UseTlsSecurityCheckBox.Checked = value;
         }
      }

      public int MaxClients
      {
         get
         {
            return (int)MaxClientsNumericUpDown.Value;
         }

         set
         {
            MaxClientsNumericUpDown.Value = value;
         }
      }

      public int MaxClientsMaxValue
      {
         get
         {
            return Convert.ToInt32(MaxClientsNumericUpDown.Maximum);
         }
         set
         {
            MaxClientsNumericUpDown.Maximum = value;
         }
      }

      public int ClientIdleTimeout
      {
         get
         {
            return (int)ClientTimeoutNumericUpDown.Value;
         }

         set
         {
            ClientTimeoutNumericUpDown.Value = value;
         }
      }

      public int MessageProcessingTimeout
      {
         get
         {
            return (int)AddinsTimeoutNumericUpDown.Value;
         }

         set
         {
            AddinsTimeoutNumericUpDown.Value = value;
         }
      }

      public int StoreSubOperationsTimeout
      {
         get
         {
            return (int)ReconnectTimeoutNumericUpDown.Value;
         }

         set
         {
            ReconnectTimeoutNumericUpDown.Value = value;
         }
      }

      public string TempDirectory
      {
         get
         {
            return TempFolderTextBox.Text;
         }

         set
         {
            TempFolderTextBox.Text = value;
         }
      }

      public RelationalQuerySupportEnum RelationalQueries
      {
         get
         {
            if (this.rbRelationalQueriesNever.Checked)
            {
               return RelationalQuerySupportEnum.Never;
            }
            else if (rbRelationalQueriesNegotiate.Checked)
            {
               return RelationalQuerySupportEnum.Negotiation;
            }
            return RelationalQuerySupportEnum.Always;
         }

         set
         {
            switch (value)
            {
               case RelationalQuerySupportEnum.Never:
                  rbRelationalQueriesNever.Checked = true;
                  break;
               case RelationalQuerySupportEnum.Negotiation:
                  rbRelationalQueriesNegotiate.Checked = true;
                  break;
               case RelationalQuerySupportEnum.Always:
                  rbRelationalQueriesAlways.Checked = true;
                  break;
            }
         }
      }

      public RoleSelectionFlags RoleSelectionOptions
      {
         get
         {
            RoleSelectionFlags roleSelectionFlags = RoleSelectionFlags.None;
            if (this.checkBoxEnableDefaultRoleSelection.Checked)
            {
               roleSelectionFlags |= RoleSelectionFlags.Enabled;
               if (this.radioButtonUserRoleAccept.Checked)
               {
                  roleSelectionFlags |= RoleSelectionFlags.AcceptUserRoleProposed;
               }

               if (this.radioButtonProviderRoleAccept.Checked)
               {
                  roleSelectionFlags |= RoleSelectionFlags.AcceptProviderRoleProposed;
               }
            }
            else
            {
               roleSelectionFlags |= RoleSelectionFlags.Disabled;
            }
            return roleSelectionFlags;
         }
         set
         {
            checkBoxEnableDefaultRoleSelection.Checked = (Leadtools.DicomDemos.Extensions.IsFlagged(value, RoleSelectionFlags.Enabled));
            radioButtonUserRoleAccept.Checked = Leadtools.DicomDemos.Extensions.IsFlagged(value, RoleSelectionFlags.AcceptUserRoleProposed);
            radioButtonUserRoleTurnDown.Checked = !radioButtonUserRoleAccept.Checked;

            radioButtonProviderRoleAccept.Checked = Leadtools.DicomDemos.Extensions.IsFlagged(value, RoleSelectionFlags.AcceptProviderRoleProposed);
            radioButtonProviderRoleTurnDown.Checked = !radioButtonProviderRoleAccept.Checked;
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

      public event EventHandler SettingsChanged;

      #endregion

      #region Data Members

      #endregion

      #region Data Types Definition

      private void EnableRoleSelectItems(bool enable)
      {
         groupBoxUserRole.Enabled = enable;
         groupBoxProviderRole.Enabled = enable;
      }

      private void EnableRoleSelectItems()
      {
         EnableRoleSelectItems(checkBoxEnableDefaultRoleSelection.Checked);
      }

      private void UpdateUI()
      {
         bool allowAnonymousCMoveEnabled = false;
         bool anonymousClientPortEnabled = false;

#if (LEADTOOLS_V19_OR_LATER)
         allowAnonymousCMoveEnabled = AllowAnonCheckBox.Checked;
         anonymousClientPortEnabled = allowAnonymousCMoveEnabled && AllowAnonymousCMoveCheckBox.Checked;
#endif // #if (LEADTOOLS_V19_OR_LATER)

         AllowAnonymousCMoveCheckBox.Enabled = allowAnonymousCMoveEnabled;
         AnonymousClientPortLabel.Enabled = anonymousClientPortEnabled;
         AnonymousClientPortNumericUpDown.Enabled = anonymousClientPortEnabled;

         EnableRoleSelectItems();
      }

      private void OnSettingsChanged(object sender, EventArgs e)
      {
         UpdateUI();
         try
         {
            if (null != SettingsChanged)
            {
               SettingsChanged(this, e);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      #endregion

      private void TempFolderTextBox_Leave(object sender, EventArgs e)
      {
         if (TempFolderTextBox.Text.Length > 0 && !Directory.Exists(TempFolderTextBox.Text))
         {
            MessageBox.Show(string.Format("Directory does not exist: {0}", TempFolderTextBox.Text), "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            TempFolderTextBox.Focus();
         }
      }

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
