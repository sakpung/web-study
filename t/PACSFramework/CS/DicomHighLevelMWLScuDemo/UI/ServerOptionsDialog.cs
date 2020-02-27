// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for OptionsDialog.
   /// </summary>
   public class ServerOptionsDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.GroupBox _groupBoxServer;
      private System.Windows.Forms.Label _labelServerAE;
      private System.Windows.Forms.Label _labelServerIP;
      private System.Windows.Forms.Label _labelServerPort;
      public System.Windows.Forms.TextBox _textBoxServerAE;
      public System.Windows.Forms.TextBox _textBoxServerPort;
      public System.Windows.Forms.TextBox _textBoxServerIP;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Button buttonCancel;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;


      private string _serverAE;
      private string _serverIP;
      private int _serverPort;
      private string _clientAE;
      private int _clientPort;

      public int ClientPort
      {
         get { return _clientPort; }
         set { _clientPort = value; }
      }
      private int _timeout;
      private bool _useTls;
      private string _clientCertificate;
      private string _privateKey;
      private string _privateKeyPassword;
      public TextBox _textBoxTimeout;
      private Label _labelTimeout;
      private bool _logLowLevel;


      public ServerOptionsDialog()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerOptionsDialog));
          this._groupBoxServer = new System.Windows.Forms.GroupBox();
          this._textBoxServerIP = new System.Windows.Forms.TextBox();
          this._textBoxServerPort = new System.Windows.Forms.TextBox();
          this._textBoxServerAE = new System.Windows.Forms.TextBox();
          this._labelServerPort = new System.Windows.Forms.Label();
          this._labelServerIP = new System.Windows.Forms.Label();
          this._labelServerAE = new System.Windows.Forms.Label();
          this.buttonOK = new System.Windows.Forms.Button();
          this.buttonCancel = new System.Windows.Forms.Button();
          this._textBoxTimeout = new System.Windows.Forms.TextBox();
          this._labelTimeout = new System.Windows.Forms.Label();
          this._groupBoxServer.SuspendLayout();
          this.SuspendLayout();
          // 
          // _groupBoxServer
          // 
          this._groupBoxServer.Controls.Add(this._textBoxTimeout);
          this._groupBoxServer.Controls.Add(this._labelTimeout);
          this._groupBoxServer.Controls.Add(this._textBoxServerIP);
          this._groupBoxServer.Controls.Add(this._textBoxServerPort);
          this._groupBoxServer.Controls.Add(this._textBoxServerAE);
          this._groupBoxServer.Controls.Add(this._labelServerPort);
          this._groupBoxServer.Controls.Add(this._labelServerIP);
          this._groupBoxServer.Controls.Add(this._labelServerAE);
          this._groupBoxServer.Location = new System.Drawing.Point(8, 8);
          this._groupBoxServer.Name = "_groupBoxServer";
          this._groupBoxServer.Size = new System.Drawing.Size(418, 138);
          this._groupBoxServer.TabIndex = 0;
          this._groupBoxServer.TabStop = false;
          this._groupBoxServer.Text = "Server (SCP AE) Information";
          // 
          // _textBoxServerIP
          // 
          this._textBoxServerIP.Location = new System.Drawing.Point(111, 48);
          this._textBoxServerIP.MaxLength = 15;
          this._textBoxServerIP.Name = "_textBoxServerIP";
          this._textBoxServerIP.Size = new System.Drawing.Size(301, 20);
          this._textBoxServerIP.TabIndex = 3;
          this._textBoxServerIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ServerIp_KeyPress);
          // 
          // _textBoxServerPort
          // 
          this._textBoxServerPort.Location = new System.Drawing.Point(111, 76);
          this._textBoxServerPort.Name = "_textBoxServerPort";
          this._textBoxServerPort.Size = new System.Drawing.Size(301, 20);
          this._textBoxServerPort.TabIndex = 5;
          this._textBoxServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Port_KeyPress);
          // 
          // _textBoxServerAE
          // 
          this._textBoxServerAE.Location = new System.Drawing.Point(111, 20);
          this._textBoxServerAE.Name = "_textBoxServerAE";
          this._textBoxServerAE.Size = new System.Drawing.Size(301, 20);
          this._textBoxServerAE.TabIndex = 1;
          // 
          // _labelServerPort
          // 
          this._labelServerPort.AutoSize = true;
          this._labelServerPort.Location = new System.Drawing.Point(16, 80);
          this._labelServerPort.Name = "_labelServerPort";
          this._labelServerPort.Size = new System.Drawing.Size(83, 13);
          this._labelServerPort.TabIndex = 4;
          this._labelServerPort.Text = "Server Port No.:";
          // 
          // _labelServerIP
          // 
          this._labelServerIP.AutoSize = true;
          this._labelServerIP.Location = new System.Drawing.Point(16, 52);
          this._labelServerIP.Name = "_labelServerIP";
          this._labelServerIP.Size = new System.Drawing.Size(95, 13);
          this._labelServerIP.TabIndex = 2;
          this._labelServerIP.Text = "Server IP Address:";
          // 
          // _labelServerAE
          // 
          this._labelServerAE.AutoSize = true;
          this._labelServerAE.Location = new System.Drawing.Point(16, 24);
          this._labelServerAE.Name = "_labelServerAE";
          this._labelServerAE.Size = new System.Drawing.Size(89, 13);
          this._labelServerAE.TabIndex = 0;
          this._labelServerAE.Text = "Server AE Name:";
          // 
          // buttonOK
          // 
          this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
          this.buttonOK.Location = new System.Drawing.Point(139, 166);
          this.buttonOK.Name = "buttonOK";
          this.buttonOK.Size = new System.Drawing.Size(75, 23);
          this.buttonOK.TabIndex = 2;
          this.buttonOK.Text = "&OK";
          this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
          // 
          // buttonCancel
          // 
          this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.buttonCancel.Location = new System.Drawing.Point(224, 166);
          this.buttonCancel.Name = "buttonCancel";
          this.buttonCancel.Size = new System.Drawing.Size(75, 23);
          this.buttonCancel.TabIndex = 3;
          this.buttonCancel.Text = "&Cancel";
          // 
          // _textBoxTimeout
          // 
          this._textBoxTimeout.Location = new System.Drawing.Point(111, 102);
          this._textBoxTimeout.Name = "_textBoxTimeout";
          this._textBoxTimeout.Size = new System.Drawing.Size(301, 20);
          this._textBoxTimeout.TabIndex = 7;
          // 
          // _labelTimeout
          // 
          this._labelTimeout.AutoSize = true;
          this._labelTimeout.Location = new System.Drawing.Point(16, 106);
          this._labelTimeout.Name = "_labelTimeout";
          this._labelTimeout.Size = new System.Drawing.Size(74, 13);
          this._labelTimeout.TabIndex = 6;
          this._labelTimeout.Text = "Timeout (sec):";
          // 
          // ServerOptionsDialog
          // 
          this.AcceptButton = this.buttonOK;
          this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
          this.CancelButton = this.buttonCancel;
          this.ClientSize = new System.Drawing.Size(438, 204);
          this.Controls.Add(this.buttonCancel);
          this.Controls.Add(this.buttonOK);
          this.Controls.Add(this._groupBoxServer);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.Name = "ServerOptionsDialog";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Options";
          this.Load += new System.EventHandler(this.OptionsDialog_Load);
          this._groupBoxServer.ResumeLayout(false);
          this._groupBoxServer.PerformLayout();
          this.ResumeLayout(false);

      }
      #endregion

      public bool LogLowLevel
      {
         get { return _logLowLevel; }
         set { _logLowLevel = value; }
      }

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

      public bool UseTls
      {
         get { return _useTls; }
         set { _useTls = value; }
      }

      public string ServerAE
      {
         get { return _serverAE; }
         set { _serverAE = value; }
      }

      public string ServerIP
      {
         get { return _serverIP; }
         set { _serverIP = value; }
      }

      public int ServerPort
      {
         get { return _serverPort; }
         set { _serverPort = value; }
      }

      public string ClientAE
      {
         get { return _clientAE; }
         set { _clientAE = value; }
      }

      public int Timeout
      {
         get { return _timeout; }
         set { _timeout = value; }
      }


      private void ServerIp_KeyPress
      (
         object sender,
         System.Windows.Forms.KeyPressEventArgs e
      )
      {
         bool bValid = Char.IsNumber(e.KeyChar) || (e.KeyChar == '.') || Char.IsControl(e.KeyChar);
         e.Handled = !bValid;
      }


      private void Port_KeyPress
      (
         object sender,
         System.Windows.Forms.KeyPressEventArgs e
      )
      {
         if(!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
         {
            e.Handled = true;
         }
      }

      private bool CheckInteger(TextBox tb, Label lb)
      {
         try
         {
            Convert.ToInt32(tb.Text);
            return true;
         }
         catch (Exception)
         {
            if (tb.Text.Trim() == string.Empty)
               MessageBox.Show("Invalid " + lb.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            tb.SelectAll();
            tb.Focus();
            DialogResult = DialogResult.None;
            return false;
         }
      }

      private bool CheckIP(TextBox tb, Label lb)
      {
         try
         {
            System.Net.IPAddress.Parse(tb.Text);
            return true;
         }
         catch (Exception)
         {
            if (tb.Text.Trim() == string.Empty)
               MessageBox.Show("Invalid " + lb.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            sMsg = "File can not be empty if 'Use Secure TLS Communication' is checked.";
            ret = false;
         }
         else if (!File.Exists(sFile))
         {
            sMsg = "File does not exist: " + sFile;
            ret = false;
         }
         if ((ret == false) && showMessageBox)
         {
            MessageBox.Show(sMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            tb.SelectAll();
            tb.Focus();
            DialogResult = DialogResult.None;
         }
         return ret;
      }

      private void buttonOK_Click(object sender, System.EventArgs e)
      {
         if (!CheckIP(_textBoxServerIP, _labelServerIP))
            return;
         if (!CheckInteger(_textBoxServerPort, _labelServerPort))
            return;         
         if (!CheckInteger(_textBoxTimeout, _labelTimeout))
            return;         

         ServerAE = _textBoxServerAE.Text;
         ServerIP = _textBoxServerIP.Text;
         ServerPort = Convert.ToInt32(_textBoxServerPort.Text);         
         Timeout = Convert.ToInt32(_textBoxTimeout.Text);         
      }      

      private void OptionsDialog_Load(object sender, EventArgs e)
      {
         _textBoxServerAE.Text = ServerAE;
         _textBoxServerIP.Text = ServerIP;
         _textBoxServerPort.Text = ServerPort.ToString();        
         _textBoxTimeout.Text = Timeout.ToString();         
      }     
   }
}
