// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Management;
using Leadtools.Dicom;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;

using Leadtools.Demos;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for OptionsDlg.
   /// </summary>
   public class OptionsDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.TabPage tabPage1;
      private System.Windows.Forms.TabPage tabPage2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox textBoxAETitle;
      private System.Windows.Forms.ComboBox comboBoxIPAddress;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;
      private System.Windows.Forms.NumericUpDown numericUpDownPort;

      public string AETitle;
      public string sIPAddress;
      public int Port;
      public int Timeout;
      public string ImageDir;
      public bool IsSecure = false;
#if LEADTOOLS_V17_OR_LATER
      public DicomNetIpTypeFlags IpType;
#endif

      public bool SaveCSReceived;
      public bool SaveDSReceived;
      public bool SaveDSSent;
      public bool DisableLogging;
      public string LogDir;

      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Button buttonDir;
      private System.Windows.Forms.NumericUpDown numericUpDownTimeout;
      private System.Windows.Forms.NumericUpDown numericUpDownMaxClients;
      private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
      private System.Windows.Forms.TextBox textBoxDir;
      private CheckBox checkBoxUseSecureTLSCommunication;
      private GroupBox groupBoxIpType;
      private RadioButton radioButtonIpv4Ipv6;
      private RadioButton radioButtonIpv6;
      private RadioButton radioButtonIpv4;
      private SaveFileDialog saveFileDialog1;
      private GroupBox groupBox1;
      private Label labelDisableLogging;
      private CheckBox checkBoxDisableLogging;
      private Button buttonDirLog;
      private TextBox textBoxLogDir;
      private Label label8;
      private CheckBox checkBoxDSSent;
      private CheckBox checkBoxDSReceived;
      private CheckBox checkBoxCSReceived;
      public int MaxClients;

      public OptionsDlg( )
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
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPage1 = new System.Windows.Forms.TabPage();
         this.groupBoxIpType = new System.Windows.Forms.GroupBox();
         this.radioButtonIpv4Ipv6 = new System.Windows.Forms.RadioButton();
         this.radioButtonIpv6 = new System.Windows.Forms.RadioButton();
         this.radioButtonIpv4 = new System.Windows.Forms.RadioButton();
         this.comboBoxIPAddress = new System.Windows.Forms.ComboBox();
         this.checkBoxUseSecureTLSCommunication = new System.Windows.Forms.CheckBox();
         this.numericUpDownMaxClients = new System.Windows.Forms.NumericUpDown();
         this.numericUpDownTimeout = new System.Windows.Forms.NumericUpDown();
         this.buttonDir = new System.Windows.Forms.Button();
         this.textBoxDir = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
         this.textBoxAETitle = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.tabPage2 = new System.Windows.Forms.TabPage();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
         this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
         this.checkBoxDisableLogging = new System.Windows.Forms.CheckBox();
         this.labelDisableLogging = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.buttonDirLog = new System.Windows.Forms.Button();
         this.textBoxLogDir = new System.Windows.Forms.TextBox();
         this.label8 = new System.Windows.Forms.Label();
         this.checkBoxDSSent = new System.Windows.Forms.CheckBox();
         this.checkBoxDSReceived = new System.Windows.Forms.CheckBox();
         this.checkBoxCSReceived = new System.Windows.Forms.CheckBox();
         this.tabControl1.SuspendLayout();
         this.tabPage1.SuspendLayout();
         this.groupBoxIpType.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxClients)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
         this.tabPage2.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControl1
         // 
         this.tabControl1.Controls.Add(this.tabPage1);
         this.tabControl1.Controls.Add(this.tabPage2);
         this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tabControl1.Location = new System.Drawing.Point(0, 0);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(413, 352);
         this.tabControl1.TabIndex = 0;
         // 
         // tabPage1
         // 
         this.tabPage1.Controls.Add(this.groupBoxIpType);
         this.tabPage1.Controls.Add(this.checkBoxUseSecureTLSCommunication);
         this.tabPage1.Controls.Add(this.numericUpDownMaxClients);
         this.tabPage1.Controls.Add(this.numericUpDownTimeout);
         this.tabPage1.Controls.Add(this.buttonDir);
         this.tabPage1.Controls.Add(this.textBoxDir);
         this.tabPage1.Controls.Add(this.label7);
         this.tabPage1.Controls.Add(this.label6);
         this.tabPage1.Controls.Add(this.numericUpDownPort);
         this.tabPage1.Controls.Add(this.textBoxAETitle);
         this.tabPage1.Controls.Add(this.label5);
         this.tabPage1.Controls.Add(this.label4);
         this.tabPage1.Controls.Add(this.label3);
         this.tabPage1.Controls.Add(this.label2);
         this.tabPage1.Controls.Add(this.label1);
         this.tabPage1.Location = new System.Drawing.Point(4, 22);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Size = new System.Drawing.Size(405, 326);
         this.tabPage1.TabIndex = 0;
         this.tabPage1.Text = "Server";
         // 
         // groupBoxIpType
         // 
         this.groupBoxIpType.Controls.Add(this.radioButtonIpv4Ipv6);
         this.groupBoxIpType.Controls.Add(this.radioButtonIpv6);
         this.groupBoxIpType.Controls.Add(this.radioButtonIpv4);
         this.groupBoxIpType.Controls.Add(this.comboBoxIPAddress);
         this.groupBoxIpType.Location = new System.Drawing.Point(128, 48);
         this.groupBoxIpType.Name = "groupBoxIpType";
         this.groupBoxIpType.Size = new System.Drawing.Size(232, 104);
         this.groupBoxIpType.TabIndex = 18;
         this.groupBoxIpType.TabStop = false;
         // 
         // radioButtonIpv4Ipv6
         // 
         this.radioButtonIpv4Ipv6.AutoSize = true;
         this.radioButtonIpv4Ipv6.Location = new System.Drawing.Point(8, 80);
         this.radioButtonIpv4Ipv6.Name = "radioButtonIpv4Ipv6";
         this.radioButtonIpv4Ipv6.Size = new System.Drawing.Size(82, 17);
         this.radioButtonIpv4Ipv6.TabIndex = 2;
         this.radioButtonIpv4Ipv6.TabStop = true;
         this.radioButtonIpv4Ipv6.Text = "Ipv4 or Ipv6";
         this.radioButtonIpv4Ipv6.UseVisualStyleBackColor = true;
         this.radioButtonIpv4Ipv6.CheckedChanged += new System.EventHandler(this.radioButtonIp_CheckedChanged);
         // 
         // radioButtonIpv6
         // 
         this.radioButtonIpv6.AutoSize = true;
         this.radioButtonIpv6.Location = new System.Drawing.Point(8, 64);
         this.radioButtonIpv6.Name = "radioButtonIpv6";
         this.radioButtonIpv6.Size = new System.Drawing.Size(47, 17);
         this.radioButtonIpv6.TabIndex = 1;
         this.radioButtonIpv6.TabStop = true;
         this.radioButtonIpv6.Text = "IPv6";
         this.radioButtonIpv6.UseVisualStyleBackColor = true;
         this.radioButtonIpv6.CheckedChanged += new System.EventHandler(this.radioButtonIp_CheckedChanged);
         // 
         // radioButtonIpv4
         // 
         this.radioButtonIpv4.AutoSize = true;
         this.radioButtonIpv4.Location = new System.Drawing.Point(8, 48);
         this.radioButtonIpv4.Name = "radioButtonIpv4";
         this.radioButtonIpv4.Size = new System.Drawing.Size(47, 17);
         this.radioButtonIpv4.TabIndex = 0;
         this.radioButtonIpv4.TabStop = true;
         this.radioButtonIpv4.Text = "IPv4";
         this.radioButtonIpv4.UseVisualStyleBackColor = true;
         this.radioButtonIpv4.CheckedChanged += new System.EventHandler(this.radioButtonIp_CheckedChanged);
         // 
         // comboBoxIPAddress
         // 
         this.comboBoxIPAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxIPAddress.Location = new System.Drawing.Point(8, 16);
         this.comboBoxIPAddress.Name = "comboBoxIPAddress";
         this.comboBoxIPAddress.Size = new System.Drawing.Size(208, 21);
         this.comboBoxIPAddress.TabIndex = 6;
         // 
         // checkBoxUseSecureTLSCommunication
         // 
         this.checkBoxUseSecureTLSCommunication.AutoSize = true;
         this.checkBoxUseSecureTLSCommunication.Location = new System.Drawing.Point(128, 296);
         this.checkBoxUseSecureTLSCommunication.Name = "checkBoxUseSecureTLSCommunication";
         this.checkBoxUseSecureTLSCommunication.Size = new System.Drawing.Size(180, 17);
         this.checkBoxUseSecureTLSCommunication.TabIndex = 17;
         this.checkBoxUseSecureTLSCommunication.Text = "Use Secure TLS Communication";
         this.checkBoxUseSecureTLSCommunication.UseVisualStyleBackColor = true;
         // 
         // numericUpDownMaxClients
         // 
         this.numericUpDownMaxClients.Location = new System.Drawing.Point(128, 260);
         this.numericUpDownMaxClients.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownMaxClients.Name = "numericUpDownMaxClients";
         this.numericUpDownMaxClients.Size = new System.Drawing.Size(120, 20);
         this.numericUpDownMaxClients.TabIndex = 16;
         this.numericUpDownMaxClients.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // numericUpDownTimeout
         // 
         this.numericUpDownTimeout.Location = new System.Drawing.Point(128, 228);
         this.numericUpDownTimeout.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
         this.numericUpDownTimeout.Name = "numericUpDownTimeout";
         this.numericUpDownTimeout.Size = new System.Drawing.Size(120, 20);
         this.numericUpDownTimeout.TabIndex = 15;
         this.numericUpDownTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // buttonDir
         // 
         this.buttonDir.Location = new System.Drawing.Point(336, 164);
         this.buttonDir.Name = "buttonDir";
         this.buttonDir.Size = new System.Drawing.Size(24, 20);
         this.buttonDir.TabIndex = 14;
         this.buttonDir.Text = "...";
         this.buttonDir.Click += new System.EventHandler(this.buttonDir_Click);
         // 
         // textBoxDir
         // 
         this.textBoxDir.Location = new System.Drawing.Point(128, 164);
         this.textBoxDir.Name = "textBoxDir";
         this.textBoxDir.Size = new System.Drawing.Size(200, 20);
         this.textBoxDir.TabIndex = 13;
         // 
         // label7
         // 
         this.label7.Location = new System.Drawing.Point(16, 164);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(100, 23);
         this.label7.TabIndex = 12;
         this.label7.Text = "Image Directory:";
         // 
         // label6
         // 
         this.label6.Location = new System.Drawing.Point(248, 232);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(64, 16);
         this.label6.TabIndex = 11;
         this.label6.Text = "minutes";
         // 
         // numericUpDownPort
         // 
         this.numericUpDownPort.Location = new System.Drawing.Point(128, 196);
         this.numericUpDownPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this.numericUpDownPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownPort.Name = "numericUpDownPort";
         this.numericUpDownPort.Size = new System.Drawing.Size(120, 20);
         this.numericUpDownPort.TabIndex = 7;
         this.numericUpDownPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // textBoxAETitle
         // 
         this.textBoxAETitle.Location = new System.Drawing.Point(128, 16);
         this.textBoxAETitle.Name = "textBoxAETitle";
         this.textBoxAETitle.Size = new System.Drawing.Size(232, 20);
         this.textBoxAETitle.TabIndex = 5;
         // 
         // label5
         // 
         this.label5.Location = new System.Drawing.Point(16, 260);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(100, 23);
         this.label5.TabIndex = 4;
         this.label5.Text = "Max Clients:";
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(16, 228);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(100, 23);
         this.label4.TabIndex = 3;
         this.label4.Text = "Timeout:";
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(16, 196);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(100, 23);
         this.label3.TabIndex = 2;
         this.label3.Text = "Port:";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(16, 48);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(100, 23);
         this.label2.TabIndex = 1;
         this.label2.Text = "IP Address:";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(100, 23);
         this.label1.TabIndex = 0;
         this.label1.Text = "AE Title:";
         // 
         // tabPage2
         // 
         this.tabPage2.Controls.Add(this.groupBox1);
         this.tabPage2.Controls.Add(this.labelDisableLogging);
         this.tabPage2.Controls.Add(this.checkBoxDisableLogging);
         this.tabPage2.Location = new System.Drawing.Point(4, 22);
         this.tabPage2.Name = "tabPage2";
         this.tabPage2.Size = new System.Drawing.Size(405, 326);
         this.tabPage2.TabIndex = 1;
         this.tabPage2.Text = "Log";
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button1.Location = new System.Drawing.Point(136, 360);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 1;
         this.button1.Text = "&OK";
         // 
         // button2
         // 
         this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button2.Location = new System.Drawing.Point(216, 360);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 2;
         this.button2.Text = "Cancel";
         // 
         // checkBoxDisableLogging
         // 
         this.checkBoxDisableLogging.AutoSize = true;
         this.checkBoxDisableLogging.Location = new System.Drawing.Point(20, 194);
         this.checkBoxDisableLogging.Name = "checkBoxDisableLogging";
         this.checkBoxDisableLogging.Size = new System.Drawing.Size(102, 17);
         this.checkBoxDisableLogging.TabIndex = 17;
         this.checkBoxDisableLogging.Text = "Disable Logging";
         this.checkBoxDisableLogging.UseVisualStyleBackColor = true;
         this.checkBoxDisableLogging.CheckedChanged += new System.EventHandler(this.checkBoxDisableLogging_CheckedChanged);
         // 
         // labelDisableLogging
         // 
         this.labelDisableLogging.AutoSize = true;
         this.labelDisableLogging.ForeColor = System.Drawing.Color.Green;
         this.labelDisableLogging.Location = new System.Drawing.Point(129, 194);
         this.labelDisableLogging.Name = "labelDisableLogging";
         this.labelDisableLogging.Size = new System.Drawing.Size(227, 13);
         this.labelDisableLogging.TabIndex = 18;
         this.labelDisableLogging.Text = "<== Disable logging for Optimized Performance";
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.buttonDirLog);
         this.groupBox1.Controls.Add(this.textBoxLogDir);
         this.groupBox1.Controls.Add(this.label8);
         this.groupBox1.Controls.Add(this.checkBoxDSSent);
         this.groupBox1.Controls.Add(this.checkBoxDSReceived);
         this.groupBox1.Controls.Add(this.checkBoxCSReceived);
         this.groupBox1.Location = new System.Drawing.Point(9, 15);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(380, 165);
         this.groupBox1.TabIndex = 19;
         this.groupBox1.TabStop = false;
         // 
         // buttonDirLog
         // 
         this.buttonDirLog.Location = new System.Drawing.Point(195, 131);
         this.buttonDirLog.Name = "buttonDirLog";
         this.buttonDirLog.Size = new System.Drawing.Size(24, 20);
         this.buttonDirLog.TabIndex = 28;
         this.buttonDirLog.Text = "...";
         // 
         // textBoxLogDir
         // 
         this.textBoxLogDir.Location = new System.Drawing.Point(11, 131);
         this.textBoxLogDir.Name = "textBoxLogDir";
         this.textBoxLogDir.Size = new System.Drawing.Size(184, 20);
         this.textBoxLogDir.TabIndex = 27;
         // 
         // label8
         // 
         this.label8.Location = new System.Drawing.Point(11, 115);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(100, 23);
         this.label8.TabIndex = 26;
         this.label8.Text = "Log directory:";
         // 
         // checkBoxDSSent
         // 
         this.checkBoxDSSent.Location = new System.Drawing.Point(11, 78);
         this.checkBoxDSSent.Name = "checkBoxDSSent";
         this.checkBoxDSSent.Size = new System.Drawing.Size(224, 24);
         this.checkBoxDSSent.TabIndex = 25;
         this.checkBoxDSSent.Text = "Save datasets sent by server";
         // 
         // checkBoxDSReceived
         // 
         this.checkBoxDSReceived.Location = new System.Drawing.Point(11, 46);
         this.checkBoxDSReceived.Name = "checkBoxDSReceived";
         this.checkBoxDSReceived.Size = new System.Drawing.Size(224, 24);
         this.checkBoxDSReceived.TabIndex = 24;
         this.checkBoxDSReceived.Text = "Save datasets received by server";
         // 
         // checkBoxCSReceived
         // 
         this.checkBoxCSReceived.Location = new System.Drawing.Point(11, 14);
         this.checkBoxCSReceived.Name = "checkBoxCSReceived";
         this.checkBoxCSReceived.Size = new System.Drawing.Size(224, 24);
         this.checkBoxCSReceived.TabIndex = 23;
         this.checkBoxCSReceived.Text = "Save command sets received by server";
         // 
         // OptionsDlg
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(413, 396);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.tabControl1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "OptionsDlg";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Server Options";
         this.Closed += new System.EventHandler(this.OptionsDlg_Closed);
         this.Load += new System.EventHandler(this.OptionsDlg_Load);
         this.tabControl1.ResumeLayout(false);
         this.tabPage1.ResumeLayout(false);
         this.tabPage1.PerformLayout();
         this.groupBoxIpType.ResumeLayout(false);
         this.groupBoxIpType.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxClients)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
         this.tabPage2.ResumeLayout(false);
         this.tabPage2.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }
      #endregion

      private void OptionsDlg_Load(object sender, System.EventArgs e)
      {
#if LEADTOOLS_V17_OR_LATER
         radioButtonIpv4.Checked = (IpType == DicomNetIpTypeFlags.Ipv4);
         radioButtonIpv6.Checked = (IpType == DicomNetIpTypeFlags.Ipv6);
         radioButtonIpv4Ipv6.Checked = (IpType == DicomNetIpTypeFlags.Ipv4OrIpv6);
         radioButtonIpv4Ipv6.Enabled = DemosGlobal.IsOnVistaOrLater;
#else
         radioButtonIpv4.Checked = true;
         radioButtonIpv6.Checked = false;
         radioButtonIpv4Ipv6.Checked = false;

         radioButtonIpv6.Enabled = false;
         radioButtonIpv4Ipv6.Enabled = false;

#endif
         InitIpList();

         textBoxAETitle.Text = AETitle;
         textBoxDir.Text = ImageDir;
         numericUpDownPort.Value = Port;
         numericUpDownTimeout.Value = Timeout;
         numericUpDownMaxClients.Value = MaxClients;
         checkBoxUseSecureTLSCommunication.Checked = IsSecure;

         checkBoxCSReceived.Checked = SaveCSReceived;
         checkBoxDSReceived.Checked = SaveDSReceived;
         checkBoxDSSent.Checked = SaveDSSent;
         textBoxLogDir.Text = LogDir;
         checkBoxDisableLogging.Checked = DisableLogging;

         checkBoxUseSecureTLSCommunication.CheckedChanged += CheckBoxUseSecureTLSCommunication_CheckedChanged;   
      }

      private void CheckBoxUseSecureTLSCommunication_CheckedChanged(object sender, EventArgs e)
      {
         if (checkBoxUseSecureTLSCommunication.Checked)
         {
            if (Leadtools.DicomDemos.Utils.VerifyOpensslVersion(this) == false)
            {
               checkBoxUseSecureTLSCommunication.Checked = false;
            }
         }
      }

      private bool ExcludeIpv6(IPAddress ip)
      {
         string sIp = ip.ToString();
         if (sIp.Contains("."))
            return true;

         if (sIp.Contains("fe80::1"))
            return true;

         return false;
      }


#if LEADTOOLS_V17_OR_LATER
      private void GetIpListsXp(out ArrayList ipListIpv4, out ArrayList ipListIpv6)
      {
         ipListIpv4 = new ArrayList();
         ipListIpv6 = new ArrayList();

         // Obtain a reference to all network interfaces in the machine
         NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
         foreach (NetworkInterface adapter in adapters)
         {
            if (adapter.OperationalStatus == OperationalStatus.Up)
            {
               IPInterfaceProperties properties = adapter.GetIPProperties();
               foreach (IPAddressInformation uniCast in properties.UnicastAddresses)
               {
                  IPAddress ip = uniCast.Address;
                  bool bLoopback = IPAddress.IsLoopback(ip);
                  if (!IPAddress.IsLoopback(ip))
                  {
                     if ((IpType & DicomNetIpTypeFlags.Ipv4) == DicomNetIpTypeFlags.Ipv4)
                     {
                        if (uniCast.Address.AddressFamily == AddressFamily.InterNetwork)
                           ipListIpv4.Add(uniCast.Address.ToString());
                     }

                     if ((IpType & DicomNetIpTypeFlags.Ipv6) == DicomNetIpTypeFlags.Ipv6)
                     {
                        if (uniCast.Address.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                           if (!ExcludeIpv6(ip))
                              ipListIpv6.Add(uniCast.Address.ToString());
                        }
                     }
                  }
               }
            }
         }
      }
#endif

      private void GetIpListsVistaOrHigher(out ArrayList ipListIpv4, out ArrayList ipListIpv6)
      {
         ipListIpv4 = new ArrayList();
         ipListIpv6 = new ArrayList();

         ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * From Win32_NetworkAdapterConfiguration WHERE IPEnabled = 1");
         if (searcher != null)
         {
            ManagementObjectCollection adapters = searcher.Get();

            foreach (ManagementObject adapter in adapters)
            {
               string ipAddressIpv4 = string.Empty;
               string ipAddressIpv6 = string.Empty;
               string[] ipArray = (string[])adapter["IPAddress"];

               if (ipArray != null)
               {
                  if (ipArray.Length >= 1)
                     ipAddressIpv4 = ipArray[0];
                  if (ipArray.Length >= 2)
                     ipAddressIpv6 = ipArray[1];

               }
#if LEADTOOLS_V17_OR_LATER
               if ((IpType & DicomNetIpTypeFlags.Ipv4) == DicomNetIpTypeFlags.Ipv4)
               {
                  if (!string.IsNullOrEmpty(ipAddressIpv4))
                     ipListIpv4.Add(ipAddressIpv4);
               }
               if ((IpType & DicomNetIpTypeFlags.Ipv6) == DicomNetIpTypeFlags.Ipv6)
               {
                  if (!string.IsNullOrEmpty(ipAddressIpv6))
                     ipListIpv6.Add(ipAddressIpv6);
               }
#else
               ipListIpv4.Add(ipAddressIpv4);
#endif
            }
         }
      }

      private void InitIpList()
      {
         ArrayList ipListIpv4 = null;
         ArrayList ipListIpv6 = null;

#if LEADTOOLS_V17_OR_LATER
         if (DemosGlobal.IsOnVistaOrLater)
            GetIpListsVistaOrHigher(out ipListIpv4, out ipListIpv6);
         else
            GetIpListsXp(out ipListIpv4, out ipListIpv6);
#else
         GetIpListsVistaOrHigher(out ipListIpv4, out ipListIpv6);
#endif


         comboBoxIPAddress.Items.Clear();
         int index = 0;
         index = comboBoxIPAddress.Items.Add("All");
         foreach (string s in ipListIpv4)
         {
            if (s != "0.0.0.0")
            {
               index = comboBoxIPAddress.Items.Add(s);
               if (
                  (sIPAddress == s) ||
                  (sIPAddress == "*" && s == "All") ||
                  (sIPAddress.Trim().Length == 0)
                  )
               {
                  comboBoxIPAddress.SelectedIndex = index;
               }
            }
         }
#if (LEADTOOLS_V17_OR_LATER)
         foreach (string s in ipListIpv6)
         {
            //if (s != "0.0.0.0")
            {
               index = comboBoxIPAddress.Items.Add(s);
               if ((sIPAddress == s) || (sIPAddress.Trim().Length == 0))
               {
                  comboBoxIPAddress.SelectedIndex = index;
               }
            }
         }
#endif

         if (comboBoxIPAddress.SelectedIndex == -1)
            comboBoxIPAddress.SelectedIndex = 0;
         comboBoxIPAddress.Enabled = (comboBoxIPAddress.Items.Count > 1);
      }

      private void UpdateIpType()
      {
#if LEADTOOLS_V17_OR_LATER
         if (radioButtonIpv4.Checked)
            IpType = DicomNetIpTypeFlags.Ipv4;
         else if (radioButtonIpv6.Checked)
            IpType = DicomNetIpTypeFlags.Ipv6;
         else
            IpType = DicomNetIpTypeFlags.Ipv4OrIpv6;
#endif
      }

      private void OptionsDlg_Closed(object sender, System.EventArgs e)
      {
         if(DialogResult == DialogResult.OK)
         {
            AETitle = textBoxAETitle.Text;
            Port = Convert.ToInt32(numericUpDownPort.Value);
            Timeout = Convert.ToInt32(numericUpDownTimeout.Value);
            MaxClients = Convert.ToInt32(numericUpDownMaxClients.Value);

            if (comboBoxIPAddress.SelectedItem != null)
            {
               sIPAddress = comboBoxIPAddress.SelectedItem.ToString();
               if (sIPAddress == "All")
                  sIPAddress = "*";
            }
            ImageDir = textBoxDir.Text;
            IsSecure = checkBoxUseSecureTLSCommunication.Checked;

            SaveCSReceived = checkBoxCSReceived.Checked;
            SaveDSReceived = checkBoxDSReceived.Checked;
            SaveDSSent = checkBoxDSSent.Checked;
            LogDir = textBoxLogDir.Text;
            DisableLogging = checkBoxDisableLogging.Checked;

            UpdateIpType();
         }
      }

      private void buttonDir_Click(object sender, System.EventArgs e)
      {
         if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
         {
            textBoxDir.Text = folderBrowserDialog1.SelectedPath;
         }
      }

      private void buttonDirLog_Click(object sender, System.EventArgs e)
      {
         if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
         {
            textBoxLogDir.Text = folderBrowserDialog1.SelectedPath;
         }
      }

      private void radioButtonIp_CheckedChanged(object sender, EventArgs e)
      {
         RadioButton rb = sender as RadioButton;
         if (rb != null)
         {
            if (rb.Checked)
            {
               UpdateIpType();
               InitIpList();
            }
         }
      }

      private void checkBoxDisableLogging_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUI();
      }

      private void UpdateUI()
      {
         bool disableLogging = checkBoxDisableLogging.Checked;
         groupBox1.Enabled = !disableLogging;
      }

   }
}
