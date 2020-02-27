// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
namespace Leadtools.Medical.Winforms.SecurityOptions
{
   partial class SecurityOptionsView
   {
      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityOptionsView));
         this._groupBoxSecurity = new System.Windows.Forms.GroupBox();
         this.groupBoxVerification = new System.Windows.Forms.GroupBox();
         this._checkBoxVerifyClientOnce = new System.Windows.Forms.CheckBox();
         this._checkBoxFailIfNoPeer = new System.Windows.Forms.CheckBox();
         this._checkBoxVerifyPeer = new System.Windows.Forms.CheckBox();
         this._numericUpDownMaxDepth = new System.Windows.Forms.NumericUpDown();
         this.labelVerificationOptions = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBoxCertificates = new System.Windows.Forms.GroupBox();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.checkBox3 = new System.Windows.Forms.CheckBox();
         this.checkBox4 = new System.Windows.Forms.CheckBox();
         this.checkBox5 = new System.Windows.Forms.CheckBox();
         this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this._checkBoxShowPassword = new System.Windows.Forms.CheckBox();
         this._comboBoxCertificateType = new System.Windows.Forms.ComboBox();
         this.labelCertificateType = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.button1 = new System.Windows.Forms.Button();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.button2 = new System.Windows.Forms.Button();
         this.listView1 = new System.Windows.Forms.ListView();
         this._labelCA = new System.Windows.Forms.Label();
         this._buttonCA = new System.Windows.Forms.Button();
         this._textBoxCA = new System.Windows.Forms.TextBox();
         this._labelCertificate = new System.Windows.Forms.Label();
         this._buttonCertificate = new System.Windows.Forms.Button();
         this._textBoxCertificate = new System.Windows.Forms.TextBox();
         this._textBoxKeyPassword = new System.Windows.Forms.TextBox();
         this._labelPrivateKeyPassword = new System.Windows.Forms.Label();
         this._labelPrivateKey = new System.Windows.Forms.Label();
         this._textBoxPrivateKey = new System.Windows.Forms.TextBox();
         this._buttonPrivateKey = new System.Windows.Forms.Button();
         this.groupBoxCipherSuites = new System.Windows.Forms.GroupBox();
         this._buttonMoveDown = new System.Windows.Forms.Button();
         this._checkBoxTlsOld = new System.Windows.Forms.CheckBox();
         this._buttonMoveUp = new System.Windows.Forms.Button();
         this._listViewCipherSuites = new System.Windows.Forms.ListView();
         this.imageListCiphers = new System.Windows.Forms.ImageList(this.components);
         this._groupBoxSecurity.SuspendLayout();
         this.groupBoxVerification.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numericUpDownMaxDepth)).BeginInit();
         this.groupBoxCertificates.SuspendLayout();
         this.groupBox3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.groupBoxCipherSuites.SuspendLayout();
         this.SuspendLayout();
         // 
         // _groupBoxSecurity
         // 
         this._groupBoxSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._groupBoxSecurity.Controls.Add(this.groupBoxVerification);
         this._groupBoxSecurity.Controls.Add(this.groupBoxCertificates);
         this._groupBoxSecurity.Controls.Add(this.groupBoxCipherSuites);
         this._groupBoxSecurity.Location = new System.Drawing.Point(3, 3);
         this._groupBoxSecurity.Name = "_groupBoxSecurity";
         this._groupBoxSecurity.Size = new System.Drawing.Size(629, 459);
         this._groupBoxSecurity.TabIndex = 0;
         this._groupBoxSecurity.TabStop = false;
         this._groupBoxSecurity.Text = "DICOM Security Options";
         // 
         // groupBoxVerification
         // 
         this.groupBoxVerification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxVerification.Controls.Add(this._checkBoxVerifyClientOnce);
         this.groupBoxVerification.Controls.Add(this._checkBoxFailIfNoPeer);
         this.groupBoxVerification.Controls.Add(this._checkBoxVerifyPeer);
         this.groupBoxVerification.Controls.Add(this._numericUpDownMaxDepth);
         this.groupBoxVerification.Controls.Add(this.labelVerificationOptions);
         this.groupBoxVerification.Controls.Add(this.label1);
         this.groupBoxVerification.Location = new System.Drawing.Point(7, 164);
         this.groupBoxVerification.Name = "groupBoxVerification";
         this.groupBoxVerification.Size = new System.Drawing.Size(616, 98);
         this.groupBoxVerification.TabIndex = 1;
         this.groupBoxVerification.TabStop = false;
         this.groupBoxVerification.Text = "Verification";
         // 
         // _checkBoxVerifyClientOnce
         // 
         this._checkBoxVerifyClientOnce.AutoSize = true;
         this._checkBoxVerifyClientOnce.Location = new System.Drawing.Point(112, 79);
         this._checkBoxVerifyClientOnce.Name = "_checkBoxVerifyClientOnce";
         this._checkBoxVerifyClientOnce.Size = new System.Drawing.Size(110, 17);
         this._checkBoxVerifyClientOnce.TabIndex = 5;
         this._checkBoxVerifyClientOnce.Text = "Verify Client Once";
         this._checkBoxVerifyClientOnce.UseVisualStyleBackColor = true;
         // 
         // _checkBoxFailIfNoPeer
         // 
         this._checkBoxFailIfNoPeer.AutoSize = true;
         this._checkBoxFailIfNoPeer.Location = new System.Drawing.Point(112, 62);
         this._checkBoxFailIfNoPeer.Name = "_checkBoxFailIfNoPeer";
         this._checkBoxFailIfNoPeer.Size = new System.Drawing.Size(166, 17);
         this._checkBoxFailIfNoPeer.TabIndex = 4;
         this._checkBoxFailIfNoPeer.Text = "Fail if Peer Certificate not sent";
         this._checkBoxFailIfNoPeer.UseVisualStyleBackColor = true;
         // 
         // _checkBoxVerifyPeer
         // 
         this._checkBoxVerifyPeer.AutoSize = true;
         this._checkBoxVerifyPeer.Location = new System.Drawing.Point(112, 45);
         this._checkBoxVerifyPeer.Name = "_checkBoxVerifyPeer";
         this._checkBoxVerifyPeer.Size = new System.Drawing.Size(177, 17);
         this._checkBoxVerifyPeer.TabIndex = 3;
         this._checkBoxVerifyPeer.Text = "Verify Peer Cerificate only if sent";
         this._checkBoxVerifyPeer.UseVisualStyleBackColor = true;
         // 
         // _numericUpDownMaxDepth
         // 
         this._numericUpDownMaxDepth.Location = new System.Drawing.Point(112, 15);
         this._numericUpDownMaxDepth.Name = "_numericUpDownMaxDepth";
         this._numericUpDownMaxDepth.Size = new System.Drawing.Size(146, 20);
         this._numericUpDownMaxDepth.TabIndex = 1;
         // 
         // labelVerificationOptions
         // 
         this.labelVerificationOptions.AutoSize = true;
         this.labelVerificationOptions.Location = new System.Drawing.Point(47, 45);
         this.labelVerificationOptions.Name = "labelVerificationOptions";
         this.labelVerificationOptions.Size = new System.Drawing.Size(46, 13);
         this.labelVerificationOptions.TabIndex = 2;
         this.labelVerificationOptions.Text = "Options:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(31, 19);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(62, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Max Depth:";
         // 
         // groupBoxCertificates
         // 
         this.groupBoxCertificates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxCertificates.Controls.Add(this.groupBox3);
         this.groupBoxCertificates.Controls.Add(this._checkBoxShowPassword);
         this.groupBoxCertificates.Controls.Add(this._comboBoxCertificateType);
         this.groupBoxCertificates.Controls.Add(this.labelCertificateType);
         this.groupBoxCertificates.Controls.Add(this.groupBox1);
         this.groupBoxCertificates.Controls.Add(this._labelCA);
         this.groupBoxCertificates.Controls.Add(this._buttonCA);
         this.groupBoxCertificates.Controls.Add(this._textBoxCA);
         this.groupBoxCertificates.Controls.Add(this._labelCertificate);
         this.groupBoxCertificates.Controls.Add(this._buttonCertificate);
         this.groupBoxCertificates.Controls.Add(this._textBoxCertificate);
         this.groupBoxCertificates.Controls.Add(this._textBoxKeyPassword);
         this.groupBoxCertificates.Controls.Add(this._labelPrivateKeyPassword);
         this.groupBoxCertificates.Controls.Add(this._labelPrivateKey);
         this.groupBoxCertificates.Controls.Add(this._textBoxPrivateKey);
         this.groupBoxCertificates.Controls.Add(this._buttonPrivateKey);
         this.groupBoxCertificates.Location = new System.Drawing.Point(8, 16);
         this.groupBoxCertificates.Name = "groupBoxCertificates";
         this.groupBoxCertificates.Size = new System.Drawing.Size(615, 140);
         this.groupBoxCertificates.TabIndex = 0;
         this.groupBoxCertificates.TabStop = false;
         this.groupBoxCertificates.Text = "Certificates";
         // 
         // groupBox3
         // 
         this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox3.Controls.Add(this.checkBox3);
         this.groupBox3.Controls.Add(this.checkBox4);
         this.groupBox3.Controls.Add(this.checkBox5);
         this.groupBox3.Controls.Add(this.numericUpDown2);
         this.groupBox3.Controls.Add(this.label7);
         this.groupBox3.Controls.Add(this.label8);
         this.groupBox3.Location = new System.Drawing.Point(-1, 148);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(616, 98);
         this.groupBox3.TabIndex = 1;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Verification";
         // 
         // checkBox3
         // 
         this.checkBox3.AutoSize = true;
         this.checkBox3.Location = new System.Drawing.Point(112, 79);
         this.checkBox3.Name = "checkBox3";
         this.checkBox3.Size = new System.Drawing.Size(110, 17);
         this.checkBox3.TabIndex = 5;
         this.checkBox3.Text = "Verify Client Once";
         this.checkBox3.UseVisualStyleBackColor = true;
         // 
         // checkBox4
         // 
         this.checkBox4.AutoSize = true;
         this.checkBox4.Location = new System.Drawing.Point(112, 62);
         this.checkBox4.Name = "checkBox4";
         this.checkBox4.Size = new System.Drawing.Size(166, 17);
         this.checkBox4.TabIndex = 4;
         this.checkBox4.Text = "Fail if Peer Certificate not sent";
         this.checkBox4.UseVisualStyleBackColor = true;
         // 
         // checkBox5
         // 
         this.checkBox5.AutoSize = true;
         this.checkBox5.Location = new System.Drawing.Point(112, 45);
         this.checkBox5.Name = "checkBox5";
         this.checkBox5.Size = new System.Drawing.Size(177, 17);
         this.checkBox5.TabIndex = 3;
         this.checkBox5.Text = "Verify Peer Cerificate only if sent";
         this.checkBox5.UseVisualStyleBackColor = true;
         // 
         // numericUpDown2
         // 
         this.numericUpDown2.Location = new System.Drawing.Point(112, 15);
         this.numericUpDown2.Name = "numericUpDown2";
         this.numericUpDown2.Size = new System.Drawing.Size(146, 20);
         this.numericUpDown2.TabIndex = 1;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(47, 45);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(46, 13);
         this.label7.TabIndex = 2;
         this.label7.Text = "Options:";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(31, 19);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(62, 13);
         this.label8.TabIndex = 0;
         this.label8.Text = "Max Depth:";
         // 
         // _checkBoxShowPassword
         // 
         this._checkBoxShowPassword.AutoSize = true;
         this._checkBoxShowPassword.Location = new System.Drawing.Point(288, 95);
         this._checkBoxShowPassword.Name = "_checkBoxShowPassword";
         this._checkBoxShowPassword.Size = new System.Drawing.Size(102, 17);
         this._checkBoxShowPassword.TabIndex = 14;
         this._checkBoxShowPassword.Text = "Show Password";
         this._checkBoxShowPassword.UseVisualStyleBackColor = true;
         // 
         // _comboBoxCertificateType
         // 
         this._comboBoxCertificateType.FormattingEnabled = true;
         this._comboBoxCertificateType.Location = new System.Drawing.Point(112, 115);
         this._comboBoxCertificateType.Name = "_comboBoxCertificateType";
         this._comboBoxCertificateType.Size = new System.Drawing.Size(270, 21);
         this._comboBoxCertificateType.TabIndex = 13;
         // 
         // labelCertificateType
         // 
         this.labelCertificateType.AutoSize = true;
         this.labelCertificateType.Location = new System.Drawing.Point(9, 119);
         this.labelCertificateType.Name = "labelCertificateType";
         this.labelCertificateType.Size = new System.Drawing.Size(84, 13);
         this.labelCertificateType.TabIndex = 12;
         this.labelCertificateType.Text = "Certificate Type:";
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.button1);
         this.groupBox1.Controls.Add(this.checkBox1);
         this.groupBox1.Controls.Add(this.button2);
         this.groupBox1.Controls.Add(this.listView1);
         this.groupBox1.Location = new System.Drawing.Point(0, 252);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(615, 185);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Cipher Suites";
         // 
         // button1
         // 
         this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
         this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.button1.Location = new System.Drawing.Point(16, 120);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(85, 38);
         this.button1.TabIndex = 1;
         this.button1.Text = "Low Priority";
         this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
         this.button1.UseVisualStyleBackColor = true;
         // 
         // checkBox1
         // 
         this.checkBox1.AutoSize = true;
         this.checkBox1.Location = new System.Drawing.Point(110, 164);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(235, 17);
         this.checkBox1.TabIndex = 3;
         this.checkBox1.Text = "Include TLS 1.0 Cipher Suites (Less Secure)";
         this.checkBox1.UseVisualStyleBackColor = true;
         // 
         // button2
         // 
         this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
         this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.button2.Location = new System.Drawing.Point(16, 16);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(85, 38);
         this.button2.TabIndex = 0;
         this.button2.Text = "High Priority";
         this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.button2.UseVisualStyleBackColor = true;
         // 
         // listView1
         // 
         this.listView1.Location = new System.Drawing.Point(112, 16);
         this.listView1.Name = "listView1";
         this.listView1.Size = new System.Drawing.Size(497, 142);
         this.listView1.TabIndex = 2;
         this.listView1.UseCompatibleStateImageBehavior = false;
         // 
         // _labelCA
         // 
         this._labelCA.AutoSize = true;
         this._labelCA.Location = new System.Drawing.Point(7, 23);
         this._labelCA.Name = "_labelCA";
         this._labelCA.Size = new System.Drawing.Size(73, 13);
         this._labelCA.TabIndex = 0;
         this._labelCA.Text = "Cert Authority:";
         // 
         // _buttonCA
         // 
         this._buttonCA.Image = ((System.Drawing.Image)(resources.GetObject("_buttonCA.Image")));
         this._buttonCA.Location = new System.Drawing.Point(82, 19);
         this._buttonCA.Name = "_buttonCA";
         this._buttonCA.Size = new System.Drawing.Size(23, 20);
         this._buttonCA.TabIndex = 1;
         this._buttonCA.UseVisualStyleBackColor = true;
         // 
         // _textBoxCA
         // 
         this._textBoxCA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._textBoxCA.Location = new System.Drawing.Point(112, 19);
         this._textBoxCA.Name = "_textBoxCA";
         this._textBoxCA.Size = new System.Drawing.Size(497, 20);
         this._textBoxCA.TabIndex = 2;
         // 
         // _labelCertificate
         // 
         this._labelCertificate.AutoSize = true;
         this._labelCertificate.Location = new System.Drawing.Point(23, 47);
         this._labelCertificate.Name = "_labelCertificate";
         this._labelCertificate.Size = new System.Drawing.Size(57, 13);
         this._labelCertificate.TabIndex = 3;
         this._labelCertificate.Text = "Certificate:";
         // 
         // _buttonCertificate
         // 
         this._buttonCertificate.Image = ((System.Drawing.Image)(resources.GetObject("_buttonCertificate.Image")));
         this._buttonCertificate.Location = new System.Drawing.Point(82, 43);
         this._buttonCertificate.Name = "_buttonCertificate";
         this._buttonCertificate.Size = new System.Drawing.Size(23, 20);
         this._buttonCertificate.TabIndex = 4;
         this._buttonCertificate.UseVisualStyleBackColor = true;
         // 
         // _textBoxCertificate
         // 
         this._textBoxCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._textBoxCertificate.Location = new System.Drawing.Point(112, 43);
         this._textBoxCertificate.Name = "_textBoxCertificate";
         this._textBoxCertificate.Size = new System.Drawing.Size(497, 20);
         this._textBoxCertificate.TabIndex = 5;
         // 
         // _textBoxKeyPassword
         // 
         this._textBoxKeyPassword.Location = new System.Drawing.Point(112, 91);
         this._textBoxKeyPassword.Name = "_textBoxKeyPassword";
         this._textBoxKeyPassword.Size = new System.Drawing.Size(146, 20);
         this._textBoxKeyPassword.TabIndex = 10;
         // 
         // _labelPrivateKeyPassword
         // 
         this._labelPrivateKeyPassword.AutoSize = true;
         this._labelPrivateKeyPassword.Location = new System.Drawing.Point(16, 95);
         this._labelPrivateKeyPassword.Name = "_labelPrivateKeyPassword";
         this._labelPrivateKeyPassword.Size = new System.Drawing.Size(77, 13);
         this._labelPrivateKeyPassword.TabIndex = 9;
         this._labelPrivateKeyPassword.Text = "Key Password:";
         // 
         // _labelPrivateKey
         // 
         this._labelPrivateKey.AutoSize = true;
         this._labelPrivateKey.Location = new System.Drawing.Point(16, 71);
         this._labelPrivateKey.Name = "_labelPrivateKey";
         this._labelPrivateKey.Size = new System.Drawing.Size(64, 13);
         this._labelPrivateKey.TabIndex = 6;
         this._labelPrivateKey.Text = "Private Key:";
         // 
         // _textBoxPrivateKey
         // 
         this._textBoxPrivateKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._textBoxPrivateKey.Location = new System.Drawing.Point(112, 67);
         this._textBoxPrivateKey.Name = "_textBoxPrivateKey";
         this._textBoxPrivateKey.Size = new System.Drawing.Size(497, 20);
         this._textBoxPrivateKey.TabIndex = 8;
         // 
         // _buttonPrivateKey
         // 
         this._buttonPrivateKey.Image = ((System.Drawing.Image)(resources.GetObject("_buttonPrivateKey.Image")));
         this._buttonPrivateKey.Location = new System.Drawing.Point(82, 67);
         this._buttonPrivateKey.Name = "_buttonPrivateKey";
         this._buttonPrivateKey.Size = new System.Drawing.Size(23, 20);
         this._buttonPrivateKey.TabIndex = 7;
         this._buttonPrivateKey.UseVisualStyleBackColor = true;
         // 
         // groupBoxCipherSuites
         // 
         this.groupBoxCipherSuites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxCipherSuites.Controls.Add(this._buttonMoveDown);
         this.groupBoxCipherSuites.Controls.Add(this._checkBoxTlsOld);
         this.groupBoxCipherSuites.Controls.Add(this._buttonMoveUp);
         this.groupBoxCipherSuites.Controls.Add(this._listViewCipherSuites);
         this.groupBoxCipherSuites.Location = new System.Drawing.Point(8, 268);
         this.groupBoxCipherSuites.Name = "groupBoxCipherSuites";
         this.groupBoxCipherSuites.Size = new System.Drawing.Size(615, 185);
         this.groupBoxCipherSuites.TabIndex = 2;
         this.groupBoxCipherSuites.TabStop = false;
         this.groupBoxCipherSuites.Text = "Cipher Suites";
         // 
         // _buttonMoveDown
         // 
         this._buttonMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
         // 
         // _checkBoxTlsOld
         // 
         this._checkBoxTlsOld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this._checkBoxTlsOld.AutoSize = true;
         this._checkBoxTlsOld.Location = new System.Drawing.Point(112, 164);
         this._checkBoxTlsOld.Name = "_checkBoxTlsOld";
         this._checkBoxTlsOld.Size = new System.Drawing.Size(235, 17);
         this._checkBoxTlsOld.TabIndex = 3;
         this._checkBoxTlsOld.Text = "Include TLS 1.0 Cipher Suites (Less Secure)";
         this._checkBoxTlsOld.UseVisualStyleBackColor = true;
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
         // 
         // _listViewCipherSuites
         // 
         this._listViewCipherSuites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._listViewCipherSuites.Location = new System.Drawing.Point(112, 16);
         this._listViewCipherSuites.Name = "_listViewCipherSuites";
         this._listViewCipherSuites.Size = new System.Drawing.Size(497, 142);
         this._listViewCipherSuites.TabIndex = 2;
         this._listViewCipherSuites.UseCompatibleStateImageBehavior = false;
         // 
         // imageListCiphers
         // 
         this.imageListCiphers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCiphers.ImageStream")));
         this.imageListCiphers.TransparentColor = System.Drawing.Color.Transparent;
         this.imageListCiphers.Images.SetKeyName(0, "yellowBullet.png");
         this.imageListCiphers.Images.SetKeyName(1, "yellowBullet.png");
         this.imageListCiphers.Images.SetKeyName(2, "greenBullet.png");
         // 
         // SecurityOptionsView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._groupBoxSecurity);
         this.Name = "SecurityOptionsView";
         this.Size = new System.Drawing.Size(635, 465);
         this._groupBoxSecurity.ResumeLayout(false);
         this.groupBoxVerification.ResumeLayout(false);
         this.groupBoxVerification.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numericUpDownMaxDepth)).EndInit();
         this.groupBoxCertificates.ResumeLayout(false);
         this.groupBoxCertificates.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBoxCipherSuites.ResumeLayout(false);
         this.groupBoxCipherSuites.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _groupBoxSecurity;
      private System.Windows.Forms.GroupBox groupBoxVerification;
      private System.Windows.Forms.CheckBox _checkBoxVerifyClientOnce;
      private System.Windows.Forms.CheckBox _checkBoxFailIfNoPeer;
      private System.Windows.Forms.CheckBox _checkBoxVerifyPeer;
      private System.Windows.Forms.NumericUpDown _numericUpDownMaxDepth;
      private System.Windows.Forms.Label labelVerificationOptions;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.GroupBox groupBoxCertificates;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.CheckBox checkBox3;
      private System.Windows.Forms.CheckBox checkBox4;
      private System.Windows.Forms.CheckBox checkBox5;
      private System.Windows.Forms.NumericUpDown numericUpDown2;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.CheckBox _checkBoxShowPassword;
      private System.Windows.Forms.ComboBox _comboBoxCertificateType;
      private System.Windows.Forms.Label labelCertificateType;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.CheckBox checkBox1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.ListView listView1;
      private System.Windows.Forms.Label _labelCA;
      private System.Windows.Forms.Button _buttonCA;
      private System.Windows.Forms.TextBox _textBoxCA;
      private System.Windows.Forms.Label _labelCertificate;
      private System.Windows.Forms.Button _buttonCertificate;
      private System.Windows.Forms.TextBox _textBoxCertificate;
      private System.Windows.Forms.TextBox _textBoxKeyPassword;
      private System.Windows.Forms.Label _labelPrivateKeyPassword;
      private System.Windows.Forms.Label _labelPrivateKey;
      private System.Windows.Forms.TextBox _textBoxPrivateKey;
      private System.Windows.Forms.Button _buttonPrivateKey;
      private System.Windows.Forms.GroupBox groupBoxCipherSuites;
      private System.Windows.Forms.Button _buttonMoveDown;
      private System.Windows.Forms.CheckBox _checkBoxTlsOld;
      private System.Windows.Forms.Button _buttonMoveUp;
      private System.Windows.Forms.ListView _listViewCipherSuites;
      private System.Windows.Forms.ImageList imageListCiphers;
   }
}
