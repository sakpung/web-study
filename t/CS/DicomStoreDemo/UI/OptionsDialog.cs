// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Dicom;
using Leadtools.DicomDemos;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for OptionsDialog.
   /// </summary>
   public class OptionsDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      public System.Windows.Forms.TextBox ServerAE;
      public System.Windows.Forms.TextBox ServerPort;
      public System.Windows.Forms.TextBox ServerIp;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      public System.Windows.Forms.TextBox Timeout;
      public System.Windows.Forms.TextBox ClientAE;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.RadioButton CompressionNone;
      private System.Windows.Forms.RadioButton CompressionJ2kLossy;
      private System.Windows.Forms.RadioButton CompressionJ2KLossless;
      private System.Windows.Forms.RadioButton CompressionJPEGLossy;
      private System.Windows.Forms.RadioButton CompressionJPEGLossless;
      private IContainer components;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Button buttonCancel;
      private GroupBox groupBox4;
      private RadioButton _rbPresentationMultiple;
      private RadioButton _rbPresentationOne;

      private DicomImageCompressionType _Compression;
      private GroupBox groupBox5;
      private RadioButton radioButtonIpv4Ipv6;
      private RadioButton radioButtonIpv6;
      private RadioButton radioButtonIpv4;
      private int _presentationContextType;
      private GroupBox groupBox6;
      private CheckBox disableLogging;
      private CheckBox _checkBoxGroupLengthDataElements;
      private ImageList imageListCiphers;
      internal GroupBox GroupBoxSecurity;
      public CheckBox UseSecureTLSCommunication;
      private GroupBox groupBoxCipherSuites;
      private Button _buttonMoveDown;
      private CheckBox _checkBoxTlsOld;
      private Button _buttonMoveUp;
      private ListView _listViewCipherSuites;

#if LEADTOOLS_V17_OR_LATER
      public DicomNetIpTypeFlags IpType;
#endif

      public int PresentationContextType
      {
         get 
         { 
            return _presentationContextType; 
         }
         set 
         {
            _presentationContextType = value;
            CheckPresentationContextType();
         }
      }

      public DicomImageCompressionType Compression
      {
         get
         {
            return _Compression;
         }
         set
         {
            _Compression = value;
            CheckCompressionOption();
         }
      }

      public bool DisableLogging
      {
         get
         {
            return disableLogging.Checked;
         }
         set
         {
            disableLogging.Checked = value;
         }
      }

      public bool GroupLengthDataElements
      {
         get { return _checkBoxGroupLengthDataElements.Checked; }
         set { _checkBoxGroupLengthDataElements.Checked = value;}
      }

      public OptionsDialog( )
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.groupBox5 = new System.Windows.Forms.GroupBox();
         this.radioButtonIpv4Ipv6 = new System.Windows.Forms.RadioButton();
         this.radioButtonIpv6 = new System.Windows.Forms.RadioButton();
         this.radioButtonIpv4 = new System.Windows.Forms.RadioButton();
         this.ServerIp = new System.Windows.Forms.TextBox();
         this.ServerPort = new System.Windows.Forms.TextBox();
         this.ServerAE = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.Timeout = new System.Windows.Forms.TextBox();
         this.ClientAE = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.CompressionJPEGLossless = new System.Windows.Forms.RadioButton();
         this.CompressionJPEGLossy = new System.Windows.Forms.RadioButton();
         this.CompressionJ2KLossless = new System.Windows.Forms.RadioButton();
         this.CompressionJ2kLossy = new System.Windows.Forms.RadioButton();
         this.CompressionNone = new System.Windows.Forms.RadioButton();
         this.buttonOK = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.groupBox4 = new System.Windows.Forms.GroupBox();
         this._rbPresentationMultiple = new System.Windows.Forms.RadioButton();
         this._rbPresentationOne = new System.Windows.Forms.RadioButton();
         this.groupBox6 = new System.Windows.Forms.GroupBox();
         this._checkBoxGroupLengthDataElements = new System.Windows.Forms.CheckBox();
         this.disableLogging = new System.Windows.Forms.CheckBox();
         this.imageListCiphers = new System.Windows.Forms.ImageList(this.components);
         this.GroupBoxSecurity = new System.Windows.Forms.GroupBox();
         this.UseSecureTLSCommunication = new System.Windows.Forms.CheckBox();
         this.groupBoxCipherSuites = new System.Windows.Forms.GroupBox();
         this._buttonMoveDown = new System.Windows.Forms.Button();
         this._checkBoxTlsOld = new System.Windows.Forms.CheckBox();
         this._buttonMoveUp = new System.Windows.Forms.Button();
         this._listViewCipherSuites = new System.Windows.Forms.ListView();
         this.groupBox1.SuspendLayout();
         this.groupBox5.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.groupBox4.SuspendLayout();
         this.groupBox6.SuspendLayout();
         this.GroupBoxSecurity.SuspendLayout();
         this.groupBoxCipherSuites.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.groupBox5);
         this.groupBox1.Controls.Add(this.ServerPort);
         this.groupBox1.Controls.Add(this.ServerAE);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(8, 8);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(344, 178);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Server (SCP AE) Information";
         // 
         // groupBox5
         // 
         this.groupBox5.Controls.Add(this.radioButtonIpv4Ipv6);
         this.groupBox5.Controls.Add(this.radioButtonIpv6);
         this.groupBox5.Controls.Add(this.radioButtonIpv4);
         this.groupBox5.Controls.Add(this.ServerIp);
         this.groupBox5.Location = new System.Drawing.Point(128, 41);
         this.groupBox5.Name = "groupBox5";
         this.groupBox5.Size = new System.Drawing.Size(208, 104);
         this.groupBox5.TabIndex = 3;
         this.groupBox5.TabStop = false;
         // 
         // radioButtonIpv4Ipv6
         // 
         this.radioButtonIpv4Ipv6.AutoSize = true;
         this.radioButtonIpv4Ipv6.Location = new System.Drawing.Point(16, 80);
         this.radioButtonIpv4Ipv6.Name = "radioButtonIpv4Ipv6";
         this.radioButtonIpv4Ipv6.Size = new System.Drawing.Size(84, 17);
         this.radioButtonIpv4Ipv6.TabIndex = 3;
         this.radioButtonIpv4Ipv6.TabStop = true;
         this.radioButtonIpv4Ipv6.Text = "IPv4 or IPv6";
         this.radioButtonIpv4Ipv6.UseVisualStyleBackColor = true;
         this.radioButtonIpv4Ipv6.CheckedChanged += new System.EventHandler(this.radioButtonIp_CheckedChanged);
         // 
         // radioButtonIpv6
         // 
         this.radioButtonIpv6.AutoSize = true;
         this.radioButtonIpv6.Location = new System.Drawing.Point(16, 60);
         this.radioButtonIpv6.Name = "radioButtonIpv6";
         this.radioButtonIpv6.Size = new System.Drawing.Size(46, 17);
         this.radioButtonIpv6.TabIndex = 2;
         this.radioButtonIpv6.TabStop = true;
         this.radioButtonIpv6.Text = "Ipv6";
         this.radioButtonIpv6.UseVisualStyleBackColor = true;
         this.radioButtonIpv6.CheckedChanged += new System.EventHandler(this.radioButtonIp_CheckedChanged);
         // 
         // radioButtonIpv4
         // 
         this.radioButtonIpv4.AutoSize = true;
         this.radioButtonIpv4.Location = new System.Drawing.Point(16, 40);
         this.radioButtonIpv4.Name = "radioButtonIpv4";
         this.radioButtonIpv4.Size = new System.Drawing.Size(46, 17);
         this.radioButtonIpv4.TabIndex = 1;
         this.radioButtonIpv4.TabStop = true;
         this.radioButtonIpv4.Text = "Ipv4";
         this.radioButtonIpv4.UseVisualStyleBackColor = true;
         this.radioButtonIpv4.CheckedChanged += new System.EventHandler(this.radioButtonIp_CheckedChanged);
         // 
         // ServerIp
         // 
         this.ServerIp.Location = new System.Drawing.Point(8, 16);
         this.ServerIp.Name = "ServerIp";
         this.ServerIp.Size = new System.Drawing.Size(192, 20);
         this.ServerIp.TabIndex = 0;
         // 
         // ServerPort
         // 
         this.ServerPort.Location = new System.Drawing.Point(128, 153);
         this.ServerPort.Name = "ServerPort";
         this.ServerPort.Size = new System.Drawing.Size(208, 20);
         this.ServerPort.TabIndex = 5;
         // 
         // ServerAE
         // 
         this.ServerAE.Location = new System.Drawing.Point(128, 18);
         this.ServerAE.Name = "ServerAE";
         this.ServerAE.Size = new System.Drawing.Size(208, 20);
         this.ServerAE.TabIndex = 1;
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(16, 153);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(100, 23);
         this.label3.TabIndex = 4;
         this.label3.Text = "Server Port No.:";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(16, 41);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(100, 23);
         this.label2.TabIndex = 2;
         this.label2.Text = "Server IP Address:";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 18);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(100, 23);
         this.label1.TabIndex = 0;
         this.label1.Text = "Server AE Name:";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.Timeout);
         this.groupBox2.Controls.Add(this.ClientAE);
         this.groupBox2.Controls.Add(this.label5);
         this.groupBox2.Controls.Add(this.label6);
         this.groupBox2.Location = new System.Drawing.Point(362, 8);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(344, 113);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Client Information";
         // 
         // Timeout
         // 
         this.Timeout.Location = new System.Drawing.Point(128, 47);
         this.Timeout.Name = "Timeout";
         this.Timeout.Size = new System.Drawing.Size(208, 20);
         this.Timeout.TabIndex = 3;
         // 
         // ClientAE
         // 
         this.ClientAE.Location = new System.Drawing.Point(128, 18);
         this.ClientAE.Name = "ClientAE";
         this.ClientAE.Size = new System.Drawing.Size(208, 20);
         this.ClientAE.TabIndex = 1;
         // 
         // label5
         // 
         this.label5.Location = new System.Drawing.Point(16, 47);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(100, 23);
         this.label5.TabIndex = 2;
         this.label5.Text = "Timeout (sec):";
         // 
         // label6
         // 
         this.label6.Location = new System.Drawing.Point(16, 18);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(100, 23);
         this.label6.TabIndex = 0;
         this.label6.Text = "Client AE Name:";
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.CompressionJPEGLossless);
         this.groupBox3.Controls.Add(this.CompressionJPEGLossy);
         this.groupBox3.Controls.Add(this.CompressionJ2KLossless);
         this.groupBox3.Controls.Add(this.CompressionJ2kLossy);
         this.groupBox3.Controls.Add(this.CompressionNone);
         this.groupBox3.Location = new System.Drawing.Point(362, 438);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(344, 99);
         this.groupBox3.TabIndex = 5;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Compression Options";
         // 
         // CompressionJPEGLossless
         // 
         this.CompressionJPEGLossless.Location = new System.Drawing.Point(216, 68);
         this.CompressionJPEGLossless.Name = "CompressionJPEGLossless";
         this.CompressionJPEGLossless.Size = new System.Drawing.Size(104, 24);
         this.CompressionJPEGLossless.TabIndex = 4;
         this.CompressionJPEGLossless.Text = "JPE&G Lossless";
         // 
         // CompressionJPEGLossy
         // 
         this.CompressionJPEGLossy.Location = new System.Drawing.Point(216, 44);
         this.CompressionJPEGLossy.Name = "CompressionJPEGLossy";
         this.CompressionJPEGLossy.Size = new System.Drawing.Size(104, 24);
         this.CompressionJPEGLossy.TabIndex = 3;
         this.CompressionJPEGLossy.Text = "JP&EG Lossy";
         // 
         // CompressionJ2KLossless
         // 
         this.CompressionJ2KLossless.Location = new System.Drawing.Point(16, 68);
         this.CompressionJ2KLossless.Name = "CompressionJ2KLossless";
         this.CompressionJ2KLossless.Size = new System.Drawing.Size(104, 24);
         this.CompressionJ2KLossless.TabIndex = 2;
         this.CompressionJ2KLossless.Text = "J2&K Lossless";
         // 
         // CompressionJ2kLossy
         // 
         this.CompressionJ2kLossy.Location = new System.Drawing.Point(16, 44);
         this.CompressionJ2kLossy.Name = "CompressionJ2kLossy";
         this.CompressionJ2kLossy.Size = new System.Drawing.Size(104, 24);
         this.CompressionJ2kLossy.TabIndex = 1;
         this.CompressionJ2kLossy.Text = "&J2K Lossy";
         // 
         // CompressionNone
         // 
         this.CompressionNone.Checked = true;
         this.CompressionNone.Location = new System.Drawing.Point(16, 20);
         this.CompressionNone.Name = "CompressionNone";
         this.CompressionNone.Size = new System.Drawing.Size(187, 24);
         this.CompressionNone.TabIndex = 0;
         this.CompressionNone.TabStop = true;
         this.CompressionNone.Text = "Don\'t Recompress (if possible)";
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(552, 600);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 6;
         this.buttonOK.Text = "&OK";
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(633, 600);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 7;
         this.buttonCancel.Text = "&Cancel";
         // 
         // groupBox4
         // 
         this.groupBox4.Controls.Add(this._rbPresentationMultiple);
         this.groupBox4.Controls.Add(this._rbPresentationOne);
         this.groupBox4.Location = new System.Drawing.Point(8, 438);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Size = new System.Drawing.Size(344, 82);
         this.groupBox4.TabIndex = 3;
         this.groupBox4.TabStop = false;
         this.groupBox4.Text = "Association Options";
         // 
         // _rbPresentationMultiple
         // 
         this._rbPresentationMultiple.AutoSize = true;
         this._rbPresentationMultiple.Location = new System.Drawing.Point(16, 44);
         this._rbPresentationMultiple.Name = "_rbPresentationMultiple";
         this._rbPresentationMultiple.Size = new System.Drawing.Size(305, 17);
         this._rbPresentationMultiple.TabIndex = 1;
         this._rbPresentationMultiple.TabStop = true;
         this._rbPresentationMultiple.Text = "&Multiple presentation contexts (one for each transfer syntax)";
         this._rbPresentationMultiple.UseVisualStyleBackColor = true;
         // 
         // _rbPresentationOne
         // 
         this._rbPresentationOne.AutoSize = true;
         this._rbPresentationOne.Location = new System.Drawing.Point(16, 20);
         this._rbPresentationOne.Name = "_rbPresentationOne";
         this._rbPresentationOne.Size = new System.Drawing.Size(273, 17);
         this._rbPresentationOne.TabIndex = 0;
         this._rbPresentationOne.TabStop = true;
         this._rbPresentationOne.Text = "&One presentation context (holds all transfer syntaxes)";
         this._rbPresentationOne.UseVisualStyleBackColor = true;
         // 
         // groupBox6
         // 
         this.groupBox6.Controls.Add(this._checkBoxGroupLengthDataElements);
         this.groupBox6.Controls.Add(this.disableLogging);
         this.groupBox6.Location = new System.Drawing.Point(8, 526);
         this.groupBox6.Name = "groupBox6";
         this.groupBox6.Size = new System.Drawing.Size(344, 68);
         this.groupBox6.TabIndex = 4;
         this.groupBox6.TabStop = false;
         this.groupBox6.Text = "Miscellaneous";
         // 
         // _checkBoxGroupLengthDataElements
         // 
         this._checkBoxGroupLengthDataElements.AutoSize = true;
         this._checkBoxGroupLengthDataElements.Location = new System.Drawing.Point(19, 42);
         this._checkBoxGroupLengthDataElements.Name = "_checkBoxGroupLengthDataElements";
         this._checkBoxGroupLengthDataElements.Size = new System.Drawing.Size(201, 17);
         this._checkBoxGroupLengthDataElements.TabIndex = 1;
         this._checkBoxGroupLengthDataElements.Text = "Include Group Length Data Elements";
         this._checkBoxGroupLengthDataElements.UseVisualStyleBackColor = true;
         // 
         // disableLogging
         // 
         this.disableLogging.AutoSize = true;
         this.disableLogging.Location = new System.Drawing.Point(19, 19);
         this.disableLogging.Name = "disableLogging";
         this.disableLogging.Size = new System.Drawing.Size(102, 17);
         this.disableLogging.TabIndex = 0;
         this.disableLogging.Text = "Disable Logging";
         this.disableLogging.UseVisualStyleBackColor = true;
         // 
         // imageListCiphers
         // 
         this.imageListCiphers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCiphers.ImageStream")));
         this.imageListCiphers.TransparentColor = System.Drawing.Color.Transparent;
         this.imageListCiphers.Images.SetKeyName(0, "yellowBullet.png");
         this.imageListCiphers.Images.SetKeyName(1, "yellowBullet.png");
         this.imageListCiphers.Images.SetKeyName(2, "greenBullet.png");
         // 
         // GroupBoxSecurity
         // 
         this.GroupBoxSecurity.Controls.Add(this.UseSecureTLSCommunication);
         this.GroupBoxSecurity.Controls.Add(this.groupBoxCipherSuites);
         this.GroupBoxSecurity.Location = new System.Drawing.Point(8, 192);
         this.GroupBoxSecurity.Name = "GroupBoxSecurity";
         this.GroupBoxSecurity.Size = new System.Drawing.Size(698, 240);
         this.GroupBoxSecurity.TabIndex = 2;
         this.GroupBoxSecurity.TabStop = false;
         this.GroupBoxSecurity.Text = "Security";
         // 
         // UseSecureTLSCommunication
         // 
         this.UseSecureTLSCommunication.AutoSize = true;
         this.UseSecureTLSCommunication.Location = new System.Drawing.Point(11, 17);
         this.UseSecureTLSCommunication.Name = "UseSecureTLSCommunication";
         this.UseSecureTLSCommunication.Size = new System.Drawing.Size(180, 17);
         this.UseSecureTLSCommunication.TabIndex = 8;
         this.UseSecureTLSCommunication.Text = "Use Secure TLS Communication";
         this.UseSecureTLSCommunication.UseVisualStyleBackColor = true;
         this.UseSecureTLSCommunication.CheckedChanged += new System.EventHandler(this.UseSecureTLSCommunication_CheckedChanged);
         // 
         // groupBoxCipherSuites
         // 
         this.groupBoxCipherSuites.Controls.Add(this._buttonMoveDown);
         this.groupBoxCipherSuites.Controls.Add(this._checkBoxTlsOld);
         this.groupBoxCipherSuites.Controls.Add(this._buttonMoveUp);
         this.groupBoxCipherSuites.Controls.Add(this._listViewCipherSuites);
         this.groupBoxCipherSuites.Location = new System.Drawing.Point(35, 39);
         this.groupBoxCipherSuites.Name = "groupBoxCipherSuites";
         this.groupBoxCipherSuites.Size = new System.Drawing.Size(544, 190);
         this.groupBoxCipherSuites.TabIndex = 2;
         this.groupBoxCipherSuites.TabStop = false;
         this.groupBoxCipherSuites.Text = "Cipher Suites";
         // 
         // _buttonMoveDown
         // 
         this._buttonMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this._buttonMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("_buttonMoveDown.Image")));
         this._buttonMoveDown.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
         this._buttonMoveDown.Location = new System.Drawing.Point(16, 120);
         this._buttonMoveDown.Name = "_buttonMoveDown";
         this._buttonMoveDown.Size = new System.Drawing.Size(85, 38);
         this._buttonMoveDown.TabIndex = 1;
         this._buttonMoveDown.Text = "Low Priority";
         this._buttonMoveDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
         this._buttonMoveDown.UseVisualStyleBackColor = true;
         this._buttonMoveDown.Click += new System.EventHandler(this._buttonMoveDown_Click);
         // 
         // _checkBoxTlsOld
         // 
         this._checkBoxTlsOld.AutoSize = true;
         this._checkBoxTlsOld.Location = new System.Drawing.Point(110, 164);
         this._checkBoxTlsOld.Name = "_checkBoxTlsOld";
         this._checkBoxTlsOld.Size = new System.Drawing.Size(235, 17);
         this._checkBoxTlsOld.TabIndex = 2;
         this._checkBoxTlsOld.Text = "Include TLS 1.0 Cipher Suites (Less Secure)";
         this._checkBoxTlsOld.UseVisualStyleBackColor = true;
         this._checkBoxTlsOld.CheckedChanged += new System.EventHandler(this._checkBoxTlsOld_CheckedChanged);
         // 
         // _buttonMoveUp
         // 
         this._buttonMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this._buttonMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("_buttonMoveUp.Image")));
         this._buttonMoveUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this._buttonMoveUp.Location = new System.Drawing.Point(16, 16);
         this._buttonMoveUp.Name = "_buttonMoveUp";
         this._buttonMoveUp.Size = new System.Drawing.Size(85, 38);
         this._buttonMoveUp.TabIndex = 0;
         this._buttonMoveUp.Text = "High Priority";
         this._buttonMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this._buttonMoveUp.UseVisualStyleBackColor = true;
         this._buttonMoveUp.Click += new System.EventHandler(this._buttonMoveUp_Click);
         // 
         // _listViewCipherSuites
         // 
         this._listViewCipherSuites.Location = new System.Drawing.Point(110, 16);
         this._listViewCipherSuites.Name = "_listViewCipherSuites";
         this._listViewCipherSuites.Size = new System.Drawing.Size(418, 142);
         this._listViewCipherSuites.TabIndex = 3;
         this._listViewCipherSuites.UseCompatibleStateImageBehavior = false;
         // 
         // OptionsDialog
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(713, 632);
         this.Controls.Add(this.GroupBoxSecurity);
         this.Controls.Add(this.groupBox6);
         this.Controls.Add(this.groupBox4);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "OptionsDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Options";
         this.Load += new System.EventHandler(this.OptionsDialog_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox5.ResumeLayout(false);
         this.groupBox5.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox4.ResumeLayout(false);
         this.groupBox4.PerformLayout();
         this.groupBox6.ResumeLayout(false);
         this.groupBox6.PerformLayout();
         this.GroupBoxSecurity.ResumeLayout(false);
         this.GroupBoxSecurity.PerformLayout();
         this.groupBoxCipherSuites.ResumeLayout(false);
         this.groupBoxCipherSuites.PerformLayout();
         this.ResumeLayout(false);

      }
      #endregion

      private void CheckCompressionOption()
      {
         switch (_Compression)
         {
            case DicomImageCompressionType.None:
               CompressionNone.Checked = true;
               break;
            case DicomImageCompressionType.J2kLossy:
               CompressionJ2kLossy.Checked = true;
               break;
            case DicomImageCompressionType.J2kLossless:
               CompressionJ2KLossless.Checked = true;
               break;
            case DicomImageCompressionType.JpegLossy:
               CompressionJPEGLossy.Checked = true;
               break;
            case DicomImageCompressionType.JpegLossless:
               CompressionJPEGLossless.Checked = true;
               break;
         }
      }

      private void CheckPresentationContextType()
      {
         switch (PresentationContextType)
         {
            case 0:
               _rbPresentationOne.Checked = true;
               break;
            case 1:
               _rbPresentationMultiple.Checked = true;
               break;
         }
      }

      private void ParseError(TextBox tb, string fieldName, Exception ex)
      {
         string message = string.Format("Please enter a valid value for '{0}'{1}Error: {2}", fieldName, Environment.NewLine, ex.Message);
         MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         tb.Focus();
         DialogResult = DialogResult.None;
      }

      private bool CheckFormat(TextBox tb, string fieldName, bool ipAddress)
      {
         try
         {
            if(ipAddress)
               System.Net.IPAddress.Parse(tb.Text);
            else
               Convert.ToInt32(tb.Text);

            return true;
         }
         catch(FormatException ex)
         {
            ParseError(tb, fieldName, ex);
            return false;
         }
         catch(OverflowException ex)
         {
            ParseError(tb, fieldName, ex);
            return false;
         }
      }

      private void buttonOK_Click(object sender, System.EventArgs e)
      {
         if(!CheckFormat(ServerPort, "Server Port No.", false))
            return;
         if(!CheckFormat(Timeout, "Timeout", false))
            return;
         if(!CheckFormat(ServerIp, "Server IP Address", true))
            return;

         _listViewCipherSuites.ListViewToCipherSuites(CipherSuites, _initializing);

         _Compression = DicomImageCompressionType.None;
         if (CompressionNone.Checked)
            _Compression = DicomImageCompressionType.None;
         else if (CompressionJ2kLossy.Checked)
            _Compression = DicomImageCompressionType.J2kLossy;
         else if (CompressionJ2KLossless.Checked)
            _Compression = DicomImageCompressionType.J2kLossless;
         else if (CompressionJPEGLossy.Checked)
            _Compression = DicomImageCompressionType.JpegLossy;
         else if (CompressionJPEGLossless.Checked)
            _Compression = DicomImageCompressionType.JpegLossless;

         _presentationContextType = this._rbPresentationOne.Checked ? 0 : 1;
      }

      private void UpdateIpType()
      {
         if (radioButtonIpv4.Checked)
            IpType = DicomNetIpTypeFlags.Ipv4;
         else if (radioButtonIpv6.Checked)
            IpType = DicomNetIpTypeFlags.Ipv6;
         else
            IpType = DicomNetIpTypeFlags.Ipv4OrIpv6;
      }

      private void radioButtonIp_CheckedChanged(object sender, EventArgs e)
      {
         RadioButton rb = sender as RadioButton;
         if (rb != null)
         {
            if (rb.Checked)
            {
               UpdateIpType();
            }
         }
      }

      public void EnableDialogItems()
      {
         bool enable = UseSecureTLSCommunication.Checked;

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

         radioButtonIpv4.Checked = (IpType == DicomNetIpTypeFlags.Ipv4);
         radioButtonIpv6.Checked = (IpType == DicomNetIpTypeFlags.Ipv6);
         radioButtonIpv4Ipv6.Checked = (IpType == DicomNetIpTypeFlags.Ipv4OrIpv6);

         _listViewCipherSuites.InitializeCipherListView(CipherSuites, imageListCiphers);
         _checkBoxTlsOld.Checked = CipherSuites.ContainsOldCipherSuites();

         _initializing = false;
         EnableDialogItems();
      }

      private void _buttonMoveUp_Click(object sender, EventArgs e)
      {
          _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Up);
      }

      private void _buttonMoveDown_Click(object sender, EventArgs e)
      {
         _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Down);
      }

      private void _checkBoxTlsOld_CheckedChanged(object sender, EventArgs e)
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

      public CipherSuiteItems CipherSuites = new CipherSuiteItems();

      private void UseSecureTLSCommunication_CheckedChanged(object sender, EventArgs e)
      {
         if (UseSecureTLSCommunication.Checked)
         {
            if (Utils.VerifyOpensslVersion(this) == false)
            {
               UseSecureTLSCommunication.Checked = false;
               return;
            }
         }
         EnableDialogItems();
      }
   }
}
