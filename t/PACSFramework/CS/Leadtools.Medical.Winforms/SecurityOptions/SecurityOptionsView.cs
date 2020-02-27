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
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.Winforms.SecurityOptions
{
   public partial class SecurityOptionsView : UserControl
   {
      public SecurityOptionsView()
      {
         InitializeComponent();

         // OnSettingsChanged Handlers -- used to enable 'Apply' button
         _textBoxCA.TextChanged += OnSettingsChanged;
         _textBoxCertificate.TextChanged += OnSettingsChanged;
         _textBoxPrivateKey.TextChanged += OnSettingsChanged;
         _textBoxKeyPassword.TextChanged += OnSettingsChanged;
         
         _checkBoxShowPassword.CheckedChanged += OnSettingsChanged;

         _comboBoxCertificateType.SelectedIndexChanged += OnSettingsChanged;
         _numericUpDownMaxDepth.ValueChanged += OnSettingsChanged;

         _checkBoxVerifyPeer.CheckedChanged += OnSettingsChanged;
         _checkBoxFailIfNoPeer.CheckedChanged += OnSettingsChanged;
         _checkBoxVerifyClientOnce.CheckedChanged += OnSettingsChanged;

         _checkBoxTlsOld.CheckedChanged += OnSettingsChanged;

         _listViewCipherSuites.ItemChecked += _listViewCipherSuites_ItemChecked;

      }

      private void _listViewCipherSuites_ItemChecked(object sender, ItemCheckedEventArgs e)
      {
         if (this._listViewCipherSuites.FocusedItem != null)
         {
            OnSettingsChanged(sender, e);
         }
      }

      DicomSecurityOptions _options = null;

      public DicomSecurityOptions Options
      {
         get
         {
            return _options;
         }
      }

      public string CertificateAuthority
      {
         get
         {
            return _textBoxCA.Text;
         }
         set
         {
            _textBoxCA.Text = value;
         }
      }

      public string Certificate
      {
         get
         {
            return _textBoxCertificate.Text;
         }
         set
         {
            _textBoxCertificate.Text = value;
         }
      }

      public string PrivateKey
      {
         get
         {
            return _textBoxPrivateKey.Text;
         }
         set
         {
            _textBoxPrivateKey.Text = value;
         }
      }

      public string PrivateKeyPassword
      {
         get
         {
            return _textBoxKeyPassword.Text;
         }
         set
         {
            _textBoxKeyPassword.Text = value;
         }
      }

      public bool ShowPrivateKeyPassword
      {
         get
         {
            return _checkBoxShowPassword.Checked;
         }
         set
         {
            _checkBoxShowPassword.Checked = value;
         }
      }

      public DicomTlsCertificateType CertificateType
      {
         get
         {
            DicomTlsCertificateType certificateType = DicomTlsCertificateType.Pem;
            CertificateTypeItem item = _comboBoxCertificateType.SelectedItem as CertificateTypeItem;
            if (item != null)
            {
               certificateType = item.CertificateType;
            }
            return certificateType;
         }

         set
         {
            if (_comboBoxCertificateType.Items.Count > 0)
            {
               if (value == DicomTlsCertificateType.Pem)
                  _comboBoxCertificateType.SelectedIndex = 0;
               else
                  _comboBoxCertificateType.SelectedIndex = 1;
            }
         }
      }

      public int MaximumVerificationDepth
      {
         get
         {
            return Convert.ToInt32(_numericUpDownMaxDepth.Value);
         }
         set
         {
            _numericUpDownMaxDepth.Value = value;
         }
      }

      DicomOpenSslVerificationFlags CheckboxesToVerificationFlags()
      {
         DicomOpenSslVerificationFlags flags = DicomOpenSslVerificationFlags.None;
         if (_checkBoxVerifyPeer.Checked)
            flags |= DicomOpenSslVerificationFlags.Peer;
         if (_checkBoxFailIfNoPeer.Checked)
            flags |= DicomOpenSslVerificationFlags.FailIfNoPeerCertificate;
         if (_checkBoxVerifyClientOnce.Checked)
            flags |= DicomOpenSslVerificationFlags.ClientOnce;
         return flags;
      }

      void VerificationFlagsToCheckboxes(DicomOpenSslVerificationFlags flags)
      {
         _checkBoxVerifyPeer.Checked = flags.IsFlagged(DicomOpenSslVerificationFlags.Peer);
         _checkBoxFailIfNoPeer.Checked = flags.IsFlagged(DicomOpenSslVerificationFlags.FailIfNoPeerCertificate);
         _checkBoxVerifyClientOnce.Checked = flags.IsFlagged(DicomOpenSslVerificationFlags.ClientOnce);
      }

      public DicomOpenSslVerificationFlags VerificationFlags
      {
         get
         {
            return CheckboxesToVerificationFlags();
         }
         set
         {
            VerificationFlagsToCheckboxes(value);
         }
      }

      public CipherSuiteItems CipherSuites
      {
         get
         {
            CipherSuiteItems cipherSuites = new CipherSuiteItems();
            _listViewCipherSuites.ListViewToCipherSuites(cipherSuites, _initializing);
            return cipherSuites;
         }
         set
         {
            _listViewCipherSuites.InitializeCipherListView(value, imageListCiphers);
         }
      }

      private event EventHandler _settingsChanged = null;
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
         if (_initializing)
            return;

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

      private bool _initializing = true;

      public void Initialize(DicomSecurityOptions o)
      {
         _initializing = true;

         // Initialize CertificateType dropdown
         _comboBoxCertificateType.DropDownStyle = ComboBoxStyle.DropDownList;
         _comboBoxCertificateType.Items.Add(new CertificateTypeItem(DicomTlsCertificateType.Pem,  "PEM   -- Base64 encoded DER certificate"));
         _comboBoxCertificateType.Items.Add(new CertificateTypeItem(DicomTlsCertificateType.Asn1, "ASN.1 -- Absract Syntax Notation One Certificate"));

         // Add Handlers
         _buttonCA.Click += _buttonCA_Click;
         _buttonCertificate.Click += _buttonCertificate_Click;
         _buttonPrivateKey.Click += _buttonPrivateKey_Click;
         _checkBoxShowPassword.CheckedChanged += _checkBoxShowPassword_CheckedChanged;
         _buttonMoveUp.Click += _buttonMoveUp_Click;
         _buttonMoveDown.Click += _buttonMoveDown_Click;
         _checkBoxTlsOld.CheckedChanged += _checkBoxTlsOld_CheckedChanged;

         // Initialize UI
         CertificateAuthority = o.CertificationAuthoritiesFileName;
         Certificate = o.CertificateFileName;
         PrivateKey = o.KeyFileName;
         PrivateKeyPassword = o.Password;
         CertificateType = o.CertificateType;
         MaximumVerificationDepth = o.MaximumVerificationDepth;
         VerificationFlags = o.VerificationFlags;
         _textBoxKeyPassword.UseSystemPasswordChar = true;
         ShowPrivateKeyPassword = o.ShowPassword;
         _numericUpDownMaxDepth.Minimum = 1;
         _numericUpDownMaxDepth.Maximum = 9;

         // Cipher suites
         _listViewCipherSuites.InitializeCipherListView(o.CipherSuites, imageListCiphers);
         _checkBoxTlsOld.Checked = o.CipherSuites.ContainsOldCipherSuites();

         _options = o;

         _initializing = false;
      }

      private void _checkBoxTlsOld_CheckedChanged(object sender, EventArgs e)
      {
         if (!_initializing)
         {
            CipherSuiteItems temp = new CipherSuiteItems();
            _listViewCipherSuites.ListViewToCipherSuites(temp, _initializing);
            if (_checkBoxTlsOld.Checked)
            {
               temp.AddOldCipherSuites();
            }
            else
            {
               temp.RemoveOldCipherSuites();
            }
            _listViewCipherSuites.UpdateCipherSuitesListView(temp);
            _listViewCipherSuites.Focus();
         }
      }

      private void _buttonMoveDown_Click(object sender, EventArgs e)
      {
         _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Down);
         OnSettingsChanged(sender, e);
      }

      private void _buttonMoveUp_Click(object sender, EventArgs e)
      {
         _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Up);
         OnSettingsChanged(sender, e);
      }

      private void _checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
      {
         CheckBox cb = sender as CheckBox;
         if (cb != null)
         {
            _textBoxKeyPassword.UseSystemPasswordChar = !cb.Checked;
         }
      }

      private void _buttonPrivateKey_Click(object sender, EventArgs e)
      {
         OpenFileDialog openDialog = new OpenFileDialog();
         openDialog.Title = "Select Private Key File";
         openDialog.FileName = _textBoxPrivateKey.Text;
         openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*";
         DialogResult result = openDialog.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            _textBoxPrivateKey.Text = openDialog.FileName;
         }
      }

      private void _buttonCertificate_Click(object sender, EventArgs e)
      {
         OpenFileDialog openDialog = new OpenFileDialog();
         openDialog.Title = "Select Client Certificate";
         openDialog.FileName = _textBoxCertificate.Text;
         openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*";
         DialogResult result = openDialog.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            _textBoxCertificate.Text = openDialog.FileName;
         }
      }

      private void _buttonCA_Click(object sender, EventArgs e)
      {
         OpenFileDialog openDialog = new OpenFileDialog();
         openDialog.Title = "Select Certificate Authority";
         openDialog.FileName = _textBoxCA.Text;
         openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*";
         DialogResult result = openDialog.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            _textBoxCA.Text = openDialog.FileName;
         }
      }

      public DicomSecurityOptions UpdateSettings()
      {
         if (_options == null)
            return null;

         _options.CertificationAuthoritiesFileName = CertificateAuthority;
         _options.CertificateFileName        = Certificate;         
         _options.KeyFileName                = PrivateKey;
         _options.Password                   = PrivateKeyPassword;
         _options.CertificateType            = CertificateType;
         _options.MaximumVerificationDepth   = MaximumVerificationDepth;
         _options.VerificationFlags          = VerificationFlags;

         _options.ShowPassword = ShowPrivateKeyPassword;
         _options.CipherSuites = CipherSuites;

         return _options;
      }
   }

   public class CertificateTypeItem
   {
      string _friendlyName;
      DicomTlsCertificateType _certificateType;

      public CertificateTypeItem(DicomTlsCertificateType certificateType, string friendlyName)
      {
         _friendlyName = friendlyName;
         _certificateType = certificateType;
      }

      public string FriendlyName
      {
         get
         {
            return _friendlyName;
         }
      }

      public DicomTlsCertificateType CertificateType
      {
         get
         {
            return _certificateType;
         }
      }

      public override string ToString()
      {
         return _friendlyName;
      }
   }
}
