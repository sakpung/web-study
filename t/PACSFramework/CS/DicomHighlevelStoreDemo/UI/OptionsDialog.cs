// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Leadtools.DicomDemos;
using Leadtools.Dicom;

namespace DicomDemo
{
   public partial class OptionsDialog : Form
   {
      private Leadtools.Dicom.Scu.Common.Compression _compression;
      private string _clientAE;
      private int _clientPort;

      public List<DicomAE> ServerList
      {
         get
         {
            List<DicomAE> items = new List<DicomAE>(dataGridViewServers.Rows.Count);
            for (int i = 0; i < dataGridViewServers.Rows.Count; i++)
            {
               DicomAE server = new DicomAE();
               server.AE = dataGridViewServers.Rows[i].Cells["ColumnAE"].Value.ToString().Trim();
               server.IPAddress = dataGridViewServers.Rows[i].Cells["ColumnIP"].Value.ToString().Trim();
               server.Timeout = Convert.ToInt32(dataGridViewServers.Rows[i].Cells["ColumnTimeout"].Value);
               server.Port = Convert.ToInt32(dataGridViewServers.Rows[i].Cells["ColumnPort"].Value);
               server.UseTls = Convert.ToBoolean(dataGridViewServers.Rows[i].Cells["ColumnTls"].Value);

               items.Add(server);
            }
            return items;
         }

         set
         {
            foreach (DicomAE s in value)
            {
               int n = dataGridViewServers.Rows.Add();
               dataGridViewServers.Rows[n].Cells["ColumnAE"].Value = s.AE.Trim();
               dataGridViewServers.Rows[n].Cells["ColumnIP"].Value = s.IPAddress.Trim();
               dataGridViewServers.Rows[n].Cells["ColumnTimeout"].Value = s.Timeout.ToString().Trim();
               dataGridViewServers.Rows[n].Cells["ColumnPort"].Value = s.Port.ToString().Trim();
               dataGridViewServers.Rows[n].Cells["ColumnTls"].Value = s.UseTls.ToString().Trim();
            }
         }
      }

      private string _clientCertificate;
      private string _privateKey;
      private string _privateKeyPassword;
      private bool _logLowLevel;
      private bool _groupLengthDataElements;
      private bool _storageCommitResultsOnSameAssociation;

      public string PrivateKeyPassword
      {
         get { return _privateKeyPassword; }
         set { _privateKeyPassword = value; }
      }

      public string PrivateKey
      {
         get { return _privateKey; }
         set { _privateKey = value; }
      }

      public string ClientCertificate
      {
         get { return _clientCertificate; }
         set { _clientCertificate = value; }
      }

      public bool LogLowLevel
      {
         get { return _logLowLevel; }
         set { _logLowLevel = value; }
      }

      public bool GroupLengthDataElements
      {
         get { return _groupLengthDataElements; }
         set { _groupLengthDataElements = value;}
      }

      public bool StorageCommitResultsOnSameAssociation
      {
         get { return _storageCommitResultsOnSameAssociation; }
         set { _storageCommitResultsOnSameAssociation = value; }
      }

      public bool DisableLogging
      {
         get
         {
            return _checkBoxDisableLogging.Checked;
         }
         set
         {
            _checkBoxDisableLogging.Checked = value;
         }
      } 

      public OptionsDialog()
      {
         InitializeComponent();
      }

      public string ClientAE
      {
         get { return _clientAE; }
         set { _clientAE = value; }
      }

      public int ClientPort
      {
         get { return _clientPort; }
         set { _clientPort = value; }
      }
      

      public Leadtools.Dicom.Scu.Common.Compression Compression
      {
         get { return _compression; }
         set { _compression = value; }
      }

      // Return true if any of the servers are using tls
      // Return false if all of the servers do not use tls
      private bool IsAnyServerUseTls()
      {
         for (int i = 0; i < dataGridViewServers.Rows.Count; i++)
         {
            if (Convert.ToBoolean(dataGridViewServers.Rows[i].Cells["ColumnTls"].Value))
               return true;
         }
         return false;
      }

      private void EnableDialogItems()
      {
         bool enable = IsAnyServerUseTls();
         _labelCertificate.Enabled = enable;
         _buttonClientCertificate.Enabled = enable;
         _textBoxClientCertificate.Enabled = enable;

         _labelPrivateKey.Enabled = enable;
         _buttonClientCertificate.Enabled = enable;
         _textBoxClientCertificate.Enabled = enable;

         _labelPrivateKey.Enabled = enable;
         _buttonPrivateKey.Enabled = enable;
         _textBoxPrivateKey.Enabled = enable;

         _labelPrivateKeyPassword.Enabled = enable;
         _textBoxKeyPassword.Enabled = enable;
         _labelHint.Enabled = enable;

         // Cipher Suites
         _buttonMoveUp.Enabled = enable;
         _buttonMoveDown.Enabled = enable;
         _listViewCipherSuites.Enabled = enable;
         _checkBoxTlsOld.Enabled = enable;
      }

      private bool _initializing = true;

      private void OptionsDialog_Load(object sender, EventArgs e)
      {
         _initializing = true;
         _textBoxClientAE.Text = ClientAE;
         _textBoxClientPort.Text = ClientPort.ToString();
         _textBoxClientCertificate.Text = ClientCertificate;
         _textBoxPrivateKey.Text = PrivateKey;
         _textBoxKeyPassword.Text = PrivateKeyPassword;
         _checkBoxLogLowLevel.Checked = LogLowLevel;
         _checkBoxGroupLengthDataElements.Checked = GroupLengthDataElements;
         _radioButtonWaitForResults.Checked = StorageCommitResultsOnSameAssociation;
         _radioButtonNoWaitForResults.Checked = !StorageCommitResultsOnSameAssociation;
         switch (_compression)
         {
            case Leadtools.Dicom.Scu.Common.Compression.Native:
               _radioButtonCompressionNative.Checked = true;
               break;
            case Leadtools.Dicom.Scu.Common.Compression.Lossy:
               _radioButtonCompressionLossy.Checked = true;
               break;
            case Leadtools.Dicom.Scu.Common.Compression.Lossless:
               _radioButtonCompressionLossless.Checked = true;
               break;
         }
#if !LEADTOOLS_V19_OR_LATER
         _groupBoxStorageCommit.Visible = false;
         this._groupMiscellaneous.Visible = false;
#endif

         _listViewCipherSuites.InitializeCipherListView(CipherSuites, imageListCiphers);
         _checkBoxTlsOld.Checked = CipherSuites.ContainsOldCipherSuites();

         _initializing = false;
         EnableDialogItems();
      }


      private bool CheckInteger(TextBox tb, Label lb)
      {
         try
         {
            Convert.ToInt32(tb.Text);
            return true;
         }
         catch (Exception )
         {
            if (tb.Text.Trim() == string.Empty)
               MessageBox.Show("Invalid " + lb.Text, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            tb.SelectAll();
            tb.Focus();
            DialogResult = DialogResult.None;
            return false;
         }
      }

      private bool CheckFileExists(TextBox tb, bool showMessageBox)
      {
         bool ret = true;
         string sMsg = string.Empty;
         string sFile = tb.Text.Trim();
         if (sFile.Length == 0)
         {
            sMsg = @"File can not be empty if 'Use Secure TLS Communication' is checked.";
            ret = false;
         }
         else if (!File.Exists(sFile))
         {
            sMsg = @"File does not exist: " + sFile;
            ret = false;
         }
         if ((ret == false) && showMessageBox)
         {
            MessageBox.Show(sMsg, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            tb.SelectAll();
            tb.Focus();
            DialogResult = DialogResult.None;
         }
         return ret;
      }

      private void _buttonOK_Click(object sender, EventArgs e)
      {
         if (IsAnyServerUseTls())
         {
            if (!CheckFileExists(_textBoxClientCertificate, true))
               return;
            if (!CheckFileExists(_textBoxPrivateKey, true))
               return;
         }

         if (!CheckInteger(_textBoxClientPort, _labelClientPort))
            return;

         _listViewCipherSuites.ListViewToCipherSuites(CipherSuites, _initializing);

         ClientAE = _textBoxClientAE.Text;
         ClientPort = Convert.ToInt32(_textBoxClientPort.Text);

         ClientCertificate = _textBoxClientCertificate.Text;
         PrivateKey = _textBoxPrivateKey.Text;
         PrivateKeyPassword = _textBoxKeyPassword.Text;
         LogLowLevel = _checkBoxLogLowLevel.Checked;
         GroupLengthDataElements = _checkBoxGroupLengthDataElements.Checked;
         StorageCommitResultsOnSameAssociation = _radioButtonWaitForResults.Checked;

         if (this._radioButtonCompressionNative.Checked)
            _compression = Leadtools.Dicom.Scu.Common.Compression.Native;
         else if (this._radioButtonCompressionLossy.Checked)
            _compression = Leadtools.Dicom.Scu.Common.Compression.Lossy;
         else if (this._radioButtonCompressionLossless.Checked)
            _compression = Leadtools.Dicom.Scu.Common.Compression.Lossless;

         DialogResult = DialogResult.OK;
      }

      private void _buttonClientCertificate_Click(object sender, EventArgs e)
      {
         OpenFileDialog openDialog = new OpenFileDialog();
         openDialog.Title = @"Select Client Certificate";
         openDialog.FileName = _textBoxClientCertificate.Text;
         openDialog.Filter = @"PEM files (*.pem)|*.pem|All files (*.*)|*.*";
         DialogResult result = openDialog.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            _textBoxClientCertificate.Text = openDialog.FileName;
         }
      }

      private void _buttonPrivateKey_Click(object sender, EventArgs e)
      {
         OpenFileDialog openDialog = new OpenFileDialog();
         openDialog.Title = @"Select Private Key File";
         openDialog.FileName = _textBoxClientCertificate.Text;
         openDialog.Filter = @"PEM files (*.pem)|*.pem|All files (*.*)|*.*";
         DialogResult result = openDialog.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            _textBoxPrivateKey.Text = openDialog.FileName;
         }
      }

      private void buttonAddServer_Click(object sender, EventArgs e)
      {
         try
         {
            int rowIndex = dataGridViewServers.Rows.Add();
            DataGridViewRow row = dataGridViewServers.Rows[rowIndex];
            row.ReadOnly = false;
            row.Selected = true;
            dataGridViewServers.CurrentCell = row.Cells[0];
            dataGridViewServers.ShowEditingIcon = true;
            dataGridViewServers.BeginEdit(false);
         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.Assert(false, ex.Message);
         }
      }

      private void buttonDeleteServer_Click(object sender, EventArgs e)
      {
         try
         {
            foreach (DataGridViewRow row in dataGridViewServers.SelectedRows)
            {
               dataGridViewServers.Rows.Remove(row);
            }
         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.Assert(false, ex.Message);
         }

      }

      private void dataGridViewServers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
      {
         DataGridView d = sender as DataGridView;
         if (d != null)
         {
            DataGridViewCheckBoxCell cb = d.CurrentCell as DataGridViewCheckBoxCell;
            if (cb != null)
            {
               if (cb.Value is bool)
               {
                  bool bValue = (bool)cb.Value;
                  if (bValue)
                  {
                     if (Utils.VerifyOpensslVersion(this) == false)
                     {
                        cb.Value = false;
                        dataGridViewServers.RefreshEdit();
                     }
                  }
               }
               d.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
               EnableDialogItems();
            }
         }
      }

      private void dataGridViewServers_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
      {
         try
         {
            DataGridViewRow validatingRow = dataGridViewServers.Rows[e.RowIndex];
            if ((null == validatingRow.Cells[ColumnAE.Name].EditedFormattedValue) ||
                       (string.IsNullOrEmpty(validatingRow.Cells[ColumnAE.Name].EditedFormattedValue.ToString())))
            {
               validatingRow.ErrorText = ColumnAE.HeaderText + " cannot be empty";
               e.Cancel = true;
               return;
            }

            if ((null != validatingRow.Cells[ColumnAE.Name].EditedFormattedValue &&
                 validatingRow.Cells[ColumnAE.Name].EditedFormattedValue.ToString().Length > 16))
            {
               validatingRow.ErrorText = ColumnAE.HeaderText + @" must be less than 16 characters";
               e.Cancel = true;
               return;
            }

            if ((null == validatingRow.Cells[ColumnIP.Name].EditedFormattedValue) ||
                 (string.IsNullOrEmpty(validatingRow.Cells[ColumnIP.Name].EditedFormattedValue.ToString())))
            {
               validatingRow.ErrorText = ColumnIP.HeaderText + @" cannot be empty.";
               e.Cancel = true;
               return;
            }

            try
            {
               string ip = validatingRow.Cells[ColumnIP.Name].EditedFormattedValue.ToString();
               Utils.ResolveIPAddress(ip);
            }
            catch (Exception exception)
            {
               validatingRow.ErrorText = exception.Message;
               e.Cancel = true;
               return;
            }

            int number;
            if ((null == validatingRow.Cells[ColumnPort.Name].EditedFormattedValue) ||
                 (string.IsNullOrEmpty(validatingRow.Cells[ColumnPort.Name].EditedFormattedValue.ToString())) ||
                 (!int.TryParse(validatingRow.Cells[ColumnPort.Name].EditedFormattedValue.ToString(), out number)))
            {
               validatingRow.ErrorText = string.Format(@"Invalid {0}.", ColumnPort.HeaderText);
               e.Cancel = true;
               return;
            }

            if ((null == validatingRow.Cells[ColumnTimeout.Name].EditedFormattedValue) ||
                 (string.IsNullOrEmpty(validatingRow.Cells[ColumnTimeout.Name].EditedFormattedValue.ToString())) ||
                 (!int.TryParse(validatingRow.Cells[ColumnTimeout.Name].EditedFormattedValue.ToString(), out number)))
            {
               validatingRow.ErrorText = string.Format(@"Invalid {0}.", ColumnTimeout.HeaderText);
               e.Cancel = true;
               return;
            }

            validatingRow.ErrorText = "";

         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.Assert(false, ex.Message);
            throw;
         }
      }

      private void disableLogging_CheckedChanged(object sender, EventArgs e)
      {
         _checkBoxLogLowLevel.Enabled = !DisableLogging;         
      }

      private void _buttonMoveUp_Click(object sender, EventArgs e)
      {
         _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Up);
      }

      private void _buttonMoveDown_Click(object sender, EventArgs e)
      {
         _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Down);
      }

      public CipherSuiteItems CipherSuites = new CipherSuiteItems();

      private void _checkBoxTlsOld_CheckedChanged(object sender, EventArgs e)
      {
         {
            _listViewCipherSuites.ListViewToCipherSuites(CipherSuites, _initializing);
            if (_checkBoxTlsOld.Checked)
            {
               CipherSuites.AddOldCipherSuites();
            }
            else
            {
               CipherSuites.RemoveOldCipherSuites();
            }
            _listViewCipherSuites.UpdateCipherSuitesListView(CipherSuites);
            _listViewCipherSuites.Focus();
         }
      }
   }
}
