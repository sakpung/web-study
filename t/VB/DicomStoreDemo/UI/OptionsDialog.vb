' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for OptionsDialog.
   ''' </summary>
   Public Class OptionsDialog : Inherits System.Windows.Forms.Form
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Public ServerAE As System.Windows.Forms.TextBox
      Public ServerPort As System.Windows.Forms.TextBox
      Public ServerIp As System.Windows.Forms.TextBox
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private label5 As System.Windows.Forms.Label
      Private label6 As System.Windows.Forms.Label
      Public Timeout As System.Windows.Forms.TextBox
      Public ClientAE As System.Windows.Forms.TextBox
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private WithEvents CompressionNone As System.Windows.Forms.RadioButton
      Private WithEvents CompressionJ2kLossy As System.Windows.Forms.RadioButton
      Private WithEvents CompressionJ2KLossless As System.Windows.Forms.RadioButton
      Private WithEvents CompressionJPEGLossy As System.Windows.Forms.RadioButton
      Private WithEvents CompressionJPEGLossless As System.Windows.Forms.RadioButton
      Private components As IContainer
      Private WithEvents buttonOK As System.Windows.Forms.Button
      Private buttonCancel As System.Windows.Forms.Button
      Friend WithEvents groupBox4 As System.Windows.Forms.GroupBox
      Friend WithEvents _rbPresentationMultiple As System.Windows.Forms.RadioButton
      Friend WithEvents _rbPresentationOne As System.Windows.Forms.RadioButton

      Private _Compression As DicomImageCompressionType
      Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
      Friend WithEvents radioButtonIpv4Ipv6 As System.Windows.Forms.RadioButton
      Friend WithEvents radioButtonIpv6 As System.Windows.Forms.RadioButton
      Friend WithEvents radioButtonIpv4 As System.Windows.Forms.RadioButton

      Private _presentationContextType As Integer
      Friend WithEvents GroupBox6 As GroupBox
      Friend WithEvents DisableLogging As CheckBox
      Private WithEvents _checkBoxGroupLengthDataElements As System.Windows.Forms.CheckBox
      Private WithEvents groupBoxCipherSuites As GroupBox
      Private WithEvents _buttonMoveDown As Button
      Private WithEvents _checkBoxTlsOld As CheckBox
      Private WithEvents _buttonMoveUp As Button
      Private WithEvents _listViewCipherSuites As ListView
      Friend WithEvents ImageListCiphers As ImageList
      Public WithEvents UseSecureTLSCommunication As CheckBox
      Friend WithEvents GroupBoxSecurity As GroupBox

#If LEADTOOLS_V17_OR_LATER Then
      Public IpType As DicomNetIpTypeFlags
#End If

      Public Property PresentationContextType() As Integer
         Get
            Return _presentationContextType
         End Get
         Set(ByVal value As Integer)
            _presentationContextType = value
            CheckPresentationContextType()
         End Set
      End Property

      Public Property Compression() As DicomImageCompressionType
         Get
            Return _Compression
         End Get
         Set(ByVal value As DicomImageCompressionType)
            _Compression = value
            CheckCompressionOption()
         End Set
      End Property

      Public Property GroupLengthDataElements() As Boolean
         Get
            Return _checkBoxGroupLengthDataElements.Checked
         End Get
         Set(ByVal value As Boolean)
            _checkBoxGroupLengthDataElements.Checked = value
         End Set
      End Property

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not components Is Nothing Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"
      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me.components = New System.ComponentModel.Container()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsDialog))
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.GroupBox5 = New System.Windows.Forms.GroupBox()
         Me.radioButtonIpv4Ipv6 = New System.Windows.Forms.RadioButton()
         Me.radioButtonIpv6 = New System.Windows.Forms.RadioButton()
         Me.radioButtonIpv4 = New System.Windows.Forms.RadioButton()
         Me.ServerIp = New System.Windows.Forms.TextBox()
         Me.ServerPort = New System.Windows.Forms.TextBox()
         Me.ServerAE = New System.Windows.Forms.TextBox()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.Timeout = New System.Windows.Forms.TextBox()
         Me.ClientAE = New System.Windows.Forms.TextBox()
         Me.label5 = New System.Windows.Forms.Label()
         Me.label6 = New System.Windows.Forms.Label()
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         Me.CompressionJPEGLossless = New System.Windows.Forms.RadioButton()
         Me.CompressionJPEGLossy = New System.Windows.Forms.RadioButton()
         Me.CompressionJ2KLossless = New System.Windows.Forms.RadioButton()
         Me.CompressionJ2kLossy = New System.Windows.Forms.RadioButton()
         Me.CompressionNone = New System.Windows.Forms.RadioButton()
         Me.buttonOK = New System.Windows.Forms.Button()
         Me.buttonCancel = New System.Windows.Forms.Button()
         Me.groupBox4 = New System.Windows.Forms.GroupBox()
         Me._rbPresentationMultiple = New System.Windows.Forms.RadioButton()
         Me._rbPresentationOne = New System.Windows.Forms.RadioButton()
         Me.GroupBox6 = New System.Windows.Forms.GroupBox()
         Me._checkBoxGroupLengthDataElements = New System.Windows.Forms.CheckBox()
         Me.DisableLogging = New System.Windows.Forms.CheckBox()
         Me.groupBoxCipherSuites = New System.Windows.Forms.GroupBox()
         Me._buttonMoveDown = New System.Windows.Forms.Button()
         Me._checkBoxTlsOld = New System.Windows.Forms.CheckBox()
         Me._buttonMoveUp = New System.Windows.Forms.Button()
         Me._listViewCipherSuites = New System.Windows.Forms.ListView()
         Me.ImageListCiphers = New System.Windows.Forms.ImageList(Me.components)
         Me.UseSecureTLSCommunication = New System.Windows.Forms.CheckBox()
         Me.GroupBoxSecurity = New System.Windows.Forms.GroupBox()
         Me.groupBox1.SuspendLayout()
         Me.GroupBox5.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me.groupBox3.SuspendLayout()
         Me.groupBox4.SuspendLayout()
         Me.GroupBox6.SuspendLayout()
         Me.groupBoxCipherSuites.SuspendLayout()
         Me.GroupBoxSecurity.SuspendLayout()
         Me.SuspendLayout()
         '
         'groupBox1
         '
         Me.groupBox1.Controls.Add(Me.GroupBox5)
         Me.groupBox1.Controls.Add(Me.ServerPort)
         Me.groupBox1.Controls.Add(Me.ServerAE)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(8, 8)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(344, 178)
         Me.groupBox1.TabIndex = 0
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Server (SCP AE) Information"
         '
         'GroupBox5
         '
         Me.GroupBox5.Controls.Add(Me.radioButtonIpv4Ipv6)
         Me.GroupBox5.Controls.Add(Me.radioButtonIpv6)
         Me.GroupBox5.Controls.Add(Me.radioButtonIpv4)
         Me.GroupBox5.Controls.Add(Me.ServerIp)
         Me.GroupBox5.Location = New System.Drawing.Point(128, 41)
         Me.GroupBox5.Name = "GroupBox5"
         Me.GroupBox5.Size = New System.Drawing.Size(208, 104)
         Me.GroupBox5.TabIndex = 3
         Me.GroupBox5.TabStop = False
         '
         'radioButtonIpv4Ipv6
         '
         Me.radioButtonIpv4Ipv6.AutoSize = True
         Me.radioButtonIpv4Ipv6.Location = New System.Drawing.Point(16, 80)
         Me.radioButtonIpv4Ipv6.Name = "radioButtonIpv4Ipv6"
         Me.radioButtonIpv4Ipv6.Size = New System.Drawing.Size(84, 17)
         Me.radioButtonIpv4Ipv6.TabIndex = 3
         Me.radioButtonIpv4Ipv6.TabStop = True
         Me.radioButtonIpv4Ipv6.Text = "IPv4 or IPv6"
         Me.radioButtonIpv4Ipv6.UseVisualStyleBackColor = True
         '
         'radioButtonIpv6
         '
         Me.radioButtonIpv6.AutoSize = True
         Me.radioButtonIpv6.Location = New System.Drawing.Point(16, 60)
         Me.radioButtonIpv6.Name = "radioButtonIpv6"
         Me.radioButtonIpv6.Size = New System.Drawing.Size(47, 17)
         Me.radioButtonIpv6.TabIndex = 2
         Me.radioButtonIpv6.TabStop = True
         Me.radioButtonIpv6.Text = "IPv6"
         Me.radioButtonIpv6.UseVisualStyleBackColor = True
         '
         'radioButtonIpv4
         '
         Me.radioButtonIpv4.AutoSize = True
         Me.radioButtonIpv4.Location = New System.Drawing.Point(16, 40)
         Me.radioButtonIpv4.Name = "radioButtonIpv4"
         Me.radioButtonIpv4.Size = New System.Drawing.Size(47, 17)
         Me.radioButtonIpv4.TabIndex = 1
         Me.radioButtonIpv4.TabStop = True
         Me.radioButtonIpv4.Text = "IPv4"
         Me.radioButtonIpv4.UseVisualStyleBackColor = True
         '
         'ServerIp
         '
         Me.ServerIp.Location = New System.Drawing.Point(8, 16)
         Me.ServerIp.Name = "ServerIp"
         Me.ServerIp.Size = New System.Drawing.Size(192, 20)
         Me.ServerIp.TabIndex = 0
         '
         'ServerPort
         '
         Me.ServerPort.Location = New System.Drawing.Point(128, 153)
         Me.ServerPort.Name = "ServerPort"
         Me.ServerPort.Size = New System.Drawing.Size(208, 20)
         Me.ServerPort.TabIndex = 5
         '
         'ServerAE
         '
         Me.ServerAE.Location = New System.Drawing.Point(128, 18)
         Me.ServerAE.Name = "ServerAE"
         Me.ServerAE.Size = New System.Drawing.Size(208, 20)
         Me.ServerAE.TabIndex = 1
         '
         'label3
         '
         Me.label3.Location = New System.Drawing.Point(16, 153)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(100, 23)
         Me.label3.TabIndex = 4
         Me.label3.Text = "Server Port No.:"
         '
         'label2
         '
         Me.label2.Location = New System.Drawing.Point(16, 41)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(100, 23)
         Me.label2.TabIndex = 2
         Me.label2.Text = "Server IP Address:"
         '
         'label1
         '
         Me.label1.Location = New System.Drawing.Point(16, 18)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(100, 23)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Server AE Name:"
         '
         'groupBox2
         '
         Me.groupBox2.Controls.Add(Me.Timeout)
         Me.groupBox2.Controls.Add(Me.ClientAE)
         Me.groupBox2.Controls.Add(Me.label5)
         Me.groupBox2.Controls.Add(Me.label6)
         Me.groupBox2.Location = New System.Drawing.Point(362, 8)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(344, 113)
         Me.groupBox2.TabIndex = 1
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "Client Information"
         '
         'Timeout
         '
         Me.Timeout.Location = New System.Drawing.Point(128, 47)
         Me.Timeout.Name = "Timeout"
         Me.Timeout.Size = New System.Drawing.Size(208, 20)
         Me.Timeout.TabIndex = 3
         '
         'ClientAE
         '
         Me.ClientAE.Location = New System.Drawing.Point(128, 18)
         Me.ClientAE.Name = "ClientAE"
         Me.ClientAE.Size = New System.Drawing.Size(208, 20)
         Me.ClientAE.TabIndex = 1
         '
         'label5
         '
         Me.label5.Location = New System.Drawing.Point(16, 47)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(100, 23)
         Me.label5.TabIndex = 2
         Me.label5.Text = "Timeout (sec):"
         '
         'label6
         '
         Me.label6.Location = New System.Drawing.Point(16, 18)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(100, 23)
         Me.label6.TabIndex = 0
         Me.label6.Text = "Client AE Name:"
         '
         'groupBox3
         '
         Me.groupBox3.Controls.Add(Me.CompressionJPEGLossless)
         Me.groupBox3.Controls.Add(Me.CompressionJPEGLossy)
         Me.groupBox3.Controls.Add(Me.CompressionJ2KLossless)
         Me.groupBox3.Controls.Add(Me.CompressionJ2kLossy)
         Me.groupBox3.Controls.Add(Me.CompressionNone)
         Me.groupBox3.Location = New System.Drawing.Point(362, 438)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(344, 99)
         Me.groupBox3.TabIndex = 5
         Me.groupBox3.TabStop = False
         Me.groupBox3.Text = "Compression Options"
         '
         'CompressionJPEGLossless
         '
         Me.CompressionJPEGLossless.Location = New System.Drawing.Point(216, 68)
         Me.CompressionJPEGLossless.Name = "CompressionJPEGLossless"
         Me.CompressionJPEGLossless.Size = New System.Drawing.Size(120, 24)
         Me.CompressionJPEGLossless.TabIndex = 4
         Me.CompressionJPEGLossless.Text = "JPE&G Lossless"
         '
         'CompressionJPEGLossy
         '
         Me.CompressionJPEGLossy.Location = New System.Drawing.Point(216, 44)
         Me.CompressionJPEGLossy.Name = "CompressionJPEGLossy"
         Me.CompressionJPEGLossy.Size = New System.Drawing.Size(104, 24)
         Me.CompressionJPEGLossy.TabIndex = 3
         Me.CompressionJPEGLossy.Text = "JP&EG Lossy"
         '
         'CompressionJ2KLossless
         '
         Me.CompressionJ2KLossless.Location = New System.Drawing.Point(16, 68)
         Me.CompressionJ2KLossless.Name = "CompressionJ2KLossless"
         Me.CompressionJ2KLossless.Size = New System.Drawing.Size(104, 24)
         Me.CompressionJ2KLossless.TabIndex = 2
         Me.CompressionJ2KLossless.Text = "J2&K Lossless"
         '
         'CompressionJ2kLossy
         '
         Me.CompressionJ2kLossy.Location = New System.Drawing.Point(16, 44)
         Me.CompressionJ2kLossy.Name = "CompressionJ2kLossy"
         Me.CompressionJ2kLossy.Size = New System.Drawing.Size(104, 24)
         Me.CompressionJ2kLossy.TabIndex = 1
         Me.CompressionJ2kLossy.Text = "&J2K Lossy"
         '
         'CompressionNone
         '
         Me.CompressionNone.Checked = True
         Me.CompressionNone.Location = New System.Drawing.Point(16, 20)
         Me.CompressionNone.Name = "CompressionNone"
         Me.CompressionNone.Size = New System.Drawing.Size(187, 24)
         Me.CompressionNone.TabIndex = 0
         Me.CompressionNone.TabStop = True
         Me.CompressionNone.Text = "Don't Recompress (if possible)"
         '
         'buttonOK
         '
         Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.buttonOK.Location = New System.Drawing.Point(552, 600)
         Me.buttonOK.Name = "buttonOK"
         Me.buttonOK.Size = New System.Drawing.Size(75, 23)
         Me.buttonOK.TabIndex = 6
         Me.buttonOK.Text = "&OK"
         '
         'buttonCancel
         '
         Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.buttonCancel.Location = New System.Drawing.Point(633, 600)
         Me.buttonCancel.Name = "buttonCancel"
         Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
         Me.buttonCancel.TabIndex = 7
         Me.buttonCancel.Text = "&Cancel"
         '
         'groupBox4
         '
         Me.groupBox4.Controls.Add(Me._rbPresentationMultiple)
         Me.groupBox4.Controls.Add(Me._rbPresentationOne)
         Me.groupBox4.Location = New System.Drawing.Point(8, 438)
         Me.groupBox4.Name = "groupBox4"
         Me.groupBox4.Size = New System.Drawing.Size(344, 82)
         Me.groupBox4.TabIndex = 3
         Me.groupBox4.TabStop = False
         Me.groupBox4.Text = "Association Options"
         '
         '_rbPresentationMultiple
         '
         Me._rbPresentationMultiple.AutoSize = True
         Me._rbPresentationMultiple.Location = New System.Drawing.Point(16, 44)
         Me._rbPresentationMultiple.Name = "_rbPresentationMultiple"
         Me._rbPresentationMultiple.Size = New System.Drawing.Size(305, 17)
         Me._rbPresentationMultiple.TabIndex = 1
         Me._rbPresentationMultiple.TabStop = True
         Me._rbPresentationMultiple.Text = "&Multiple presentation contexts (one for each transfer syntax)"
         Me._rbPresentationMultiple.UseVisualStyleBackColor = True
         '
         '_rbPresentationOne
         '
         Me._rbPresentationOne.AutoSize = True
         Me._rbPresentationOne.Location = New System.Drawing.Point(16, 20)
         Me._rbPresentationOne.Name = "_rbPresentationOne"
         Me._rbPresentationOne.Size = New System.Drawing.Size(273, 17)
         Me._rbPresentationOne.TabIndex = 0
         Me._rbPresentationOne.TabStop = True
         Me._rbPresentationOne.Text = "&One presentation context (holds all transfer syntaxes)"
         Me._rbPresentationOne.UseVisualStyleBackColor = True
         '
         'GroupBox6
         '
         Me.GroupBox6.Controls.Add(Me._checkBoxGroupLengthDataElements)
         Me.GroupBox6.Controls.Add(Me.DisableLogging)
         Me.GroupBox6.Location = New System.Drawing.Point(8, 526)
         Me.GroupBox6.Name = "GroupBox6"
         Me.GroupBox6.Size = New System.Drawing.Size(344, 73)
         Me.GroupBox6.TabIndex = 4
         Me.GroupBox6.TabStop = False
         Me.GroupBox6.Text = "Miscellaneous"
         '
         '_checkBoxGroupLengthDataElements
         '
         Me._checkBoxGroupLengthDataElements.AutoSize = True
         Me._checkBoxGroupLengthDataElements.Location = New System.Drawing.Point(7, 43)
         Me._checkBoxGroupLengthDataElements.Name = "_checkBoxGroupLengthDataElements"
         Me._checkBoxGroupLengthDataElements.Size = New System.Drawing.Size(201, 17)
         Me._checkBoxGroupLengthDataElements.TabIndex = 1
         Me._checkBoxGroupLengthDataElements.Text = "Include Group Length Data Elements"
         Me._checkBoxGroupLengthDataElements.UseVisualStyleBackColor = True
         '
         'DisableLogging
         '
         Me.DisableLogging.AutoSize = True
         Me.DisableLogging.Location = New System.Drawing.Point(7, 20)
         Me.DisableLogging.Name = "DisableLogging"
         Me.DisableLogging.Size = New System.Drawing.Size(102, 17)
         Me.DisableLogging.TabIndex = 0
         Me.DisableLogging.Text = "Disable Logging"
         Me.DisableLogging.UseVisualStyleBackColor = True
         '
         'groupBoxCipherSuites
         '
         Me.groupBoxCipherSuites.Controls.Add(Me._buttonMoveDown)
         Me.groupBoxCipherSuites.Controls.Add(Me._checkBoxTlsOld)
         Me.groupBoxCipherSuites.Controls.Add(Me._buttonMoveUp)
         Me.groupBoxCipherSuites.Controls.Add(Me._listViewCipherSuites)
         Me.groupBoxCipherSuites.Location = New System.Drawing.Point(35, 39)
         Me.groupBoxCipherSuites.Name = "groupBoxCipherSuites"
         Me.groupBoxCipherSuites.Size = New System.Drawing.Size(544, 190)
         Me.groupBoxCipherSuites.TabIndex = 2
         Me.groupBoxCipherSuites.TabStop = False
         Me.groupBoxCipherSuites.Text = "Cipher Suites"
         '
         '_buttonMoveDown
         '
         Me._buttonMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
         Me._buttonMoveDown.Image = CType(resources.GetObject("_buttonMoveDown.Image"), System.Drawing.Image)
         Me._buttonMoveDown.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
         Me._buttonMoveDown.Location = New System.Drawing.Point(16, 120)
         Me._buttonMoveDown.Name = "_buttonMoveDown"
         Me._buttonMoveDown.Size = New System.Drawing.Size(85, 38)
         Me._buttonMoveDown.TabIndex = 1
         Me._buttonMoveDown.Text = "Low Priority"
         Me._buttonMoveDown.TextAlign = System.Drawing.ContentAlignment.TopCenter
         Me._buttonMoveDown.UseVisualStyleBackColor = True
         '
         '_checkBoxTlsOld
         '
         Me._checkBoxTlsOld.AutoSize = True
         Me._checkBoxTlsOld.Location = New System.Drawing.Point(110, 164)
         Me._checkBoxTlsOld.Name = "_checkBoxTlsOld"
         Me._checkBoxTlsOld.Size = New System.Drawing.Size(235, 17)
         Me._checkBoxTlsOld.TabIndex = 2
         Me._checkBoxTlsOld.Text = "Include TLS 1.0 Cipher Suites (Less Secure)"
         Me._checkBoxTlsOld.UseVisualStyleBackColor = True
         '
         '_buttonMoveUp
         '
         Me._buttonMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
         Me._buttonMoveUp.Image = CType(resources.GetObject("_buttonMoveUp.Image"), System.Drawing.Image)
         Me._buttonMoveUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
         Me._buttonMoveUp.Location = New System.Drawing.Point(16, 16)
         Me._buttonMoveUp.Name = "_buttonMoveUp"
         Me._buttonMoveUp.Size = New System.Drawing.Size(85, 38)
         Me._buttonMoveUp.TabIndex = 0
         Me._buttonMoveUp.Text = "High Priority"
         Me._buttonMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
         Me._buttonMoveUp.UseVisualStyleBackColor = True
         '
         '_listViewCipherSuites
         '
         Me._listViewCipherSuites.Location = New System.Drawing.Point(110, 16)
         Me._listViewCipherSuites.Name = "_listViewCipherSuites"
         Me._listViewCipherSuites.Size = New System.Drawing.Size(418, 142)
         Me._listViewCipherSuites.TabIndex = 3
         Me._listViewCipherSuites.UseCompatibleStateImageBehavior = False
         '
         'ImageListCiphers
         '
         Me.ImageListCiphers.ImageStream = CType(resources.GetObject("ImageListCiphers.ImageStream"), System.Windows.Forms.ImageListStreamer)
         Me.ImageListCiphers.TransparentColor = System.Drawing.Color.Transparent
         Me.ImageListCiphers.Images.SetKeyName(0, "yellowBullet.png")
         Me.ImageListCiphers.Images.SetKeyName(1, "yellowBullet.png")
         Me.ImageListCiphers.Images.SetKeyName(2, "greenBullet.png")
         '
         'UseSecureTLSCommunication
         '
         Me.UseSecureTLSCommunication.AutoSize = True
         Me.UseSecureTLSCommunication.Location = New System.Drawing.Point(11, 17)
         Me.UseSecureTLSCommunication.Name = "UseSecureTLSCommunication"
         Me.UseSecureTLSCommunication.Size = New System.Drawing.Size(180, 17)
         Me.UseSecureTLSCommunication.TabIndex = 8
         Me.UseSecureTLSCommunication.Text = "Use Secure TLS Communication"
         Me.UseSecureTLSCommunication.UseVisualStyleBackColor = True
         '
         'GroupBoxSecurity
         '
         Me.GroupBoxSecurity.Controls.Add(Me.UseSecureTLSCommunication)
         Me.GroupBoxSecurity.Controls.Add(Me.groupBoxCipherSuites)
         Me.GroupBoxSecurity.Location = New System.Drawing.Point(8, 192)
         Me.GroupBoxSecurity.Name = "GroupBoxSecurity"
         Me.GroupBoxSecurity.Size = New System.Drawing.Size(698, 240)
         Me.GroupBoxSecurity.TabIndex = 2
         Me.GroupBoxSecurity.TabStop = False
         Me.GroupBoxSecurity.Text = "Security"
         '
         'OptionsDialog
         '
         Me.AcceptButton = Me.buttonOK
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me.buttonCancel
         Me.ClientSize = New System.Drawing.Size(713, 632)
         Me.Controls.Add(Me.GroupBoxSecurity)
         Me.Controls.Add(Me.GroupBox6)
         Me.Controls.Add(Me.groupBox4)
         Me.Controls.Add(Me.buttonCancel)
         Me.Controls.Add(Me.buttonOK)
         Me.Controls.Add(Me.groupBox3)
         Me.Controls.Add(Me.groupBox2)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Name = "OptionsDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "Options"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.GroupBox5.ResumeLayout(False)
         Me.GroupBox5.PerformLayout()
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.groupBox3.ResumeLayout(False)
         Me.groupBox4.ResumeLayout(False)
         Me.groupBox4.PerformLayout()
         Me.GroupBox6.ResumeLayout(False)
         Me.GroupBox6.PerformLayout()
         Me.groupBoxCipherSuites.ResumeLayout(False)
         Me.groupBoxCipherSuites.PerformLayout()
         Me.GroupBoxSecurity.ResumeLayout(False)
         Me.GroupBoxSecurity.PerformLayout()
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Sub CheckCompressionOption()
         Select Case _Compression
            Case DicomImageCompressionType.None
               CompressionNone.Checked = True
            Case DicomImageCompressionType.J2kLossy
               CompressionJ2kLossy.Checked = True
            Case DicomImageCompressionType.J2kLossless
               CompressionJ2KLossless.Checked = True
            Case DicomImageCompressionType.JpegLossy
               CompressionJPEGLossy.Checked = True
            Case DicomImageCompressionType.JpegLossless
               CompressionJPEGLossless.Checked = True
         End Select
      End Sub

      Private Sub ParseError(ByVal tb As TextBox, ByVal fieldName As String, ByVal ex As Exception)
         Dim message As String = String.Format("Please enter a valid value for '{0}'{1}Error: {2}", fieldName, Environment.NewLine, ex.Message)
         MessageBox.Show(Me, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         tb.Focus()
         DialogResult = Windows.Forms.DialogResult.None
      End Sub

      Private Sub CheckPresentationContextType()
         Select Case PresentationContextType
            Case 0
               _rbPresentationOne.Checked = True
            Case 1
               _rbPresentationMultiple.Checked = True
         End Select
      End Sub

      Private Function CheckFormat(ByVal tb As TextBox, ByVal fieldName As String, ByVal ipAddress As Boolean) As Boolean
         Try
            If ipAddress Then
               System.Net.IPAddress.Parse(tb.Text)
            Else
               Convert.ToInt32(tb.Text)
            End If

            Return True
         Catch ex As FormatException
            ParseError(tb, fieldName, ex)
            Return False
         Catch ex As OverflowException
            ParseError(tb, fieldName, ex)
            Return False
         End Try
      End Function

      Private Sub buttonOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonOK.Click
         If (Not CheckFormat(ServerPort, "Server Port No.", False)) Then
            Return
         End If
         If (Not CheckFormat(Timeout, "Timeout", False)) Then
            Return
         End If
         If (Not CheckFormat(ServerIp, "Server IP Address", True)) Then
            Return
         End If

         _listViewCipherSuites.ListViewToCipherSuites(CipherSuites, _initializing)

         _Compression = DicomImageCompressionType.None
         If CompressionNone.Checked Then
            _Compression = DicomImageCompressionType.None
         ElseIf CompressionJ2kLossy.Checked Then
            _Compression = DicomImageCompressionType.J2kLossy
         ElseIf CompressionJ2KLossless.Checked Then
            _Compression = DicomImageCompressionType.J2kLossless
         ElseIf CompressionJPEGLossy.Checked Then
            _Compression = DicomImageCompressionType.JpegLossy
         ElseIf CompressionJPEGLossless.Checked Then
            _Compression = DicomImageCompressionType.JpegLossless
         End If


         If Me._rbPresentationOne.Checked Then
            _presentationContextType = 0
         Else
            _presentationContextType = 1
         End If
      End Sub

      Private Sub UpdateIpType()
         If radioButtonIpv4.Checked Then
            IpType = DicomNetIpTypeFlags.Ipv4
         ElseIf radioButtonIpv6.Checked Then
            IpType = DicomNetIpTypeFlags.Ipv6
         Else
            IpType = DicomNetIpTypeFlags.Ipv4OrIpv6
         End If
      End Sub

      Private Sub radioButtonIp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioButtonIpv4.CheckedChanged, radioButtonIpv4Ipv6.CheckedChanged, radioButtonIpv6.CheckedChanged
         Dim rb As RadioButton = TryCast(sender, RadioButton)
         If rb IsNot Nothing Then
            If rb.Checked Then
               UpdateIpType()
            End If
         End If
      End Sub

      Public Sub EnableDialogItems()
         Dim enable As Boolean = UseSecureTLSCommunication.Checked

         ' Cipher Suites
         _buttonMoveUp.Enabled = enable
         _buttonMoveDown.Enabled = enable
         _listViewCipherSuites.Enabled = enable
         _checkBoxTlsOld.Enabled = enable
      End Sub

      Private _initializing As Boolean = True

      Private Sub OptionsDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
         _initializing = True

         radioButtonIpv4.Checked = (IpType = DicomNetIpTypeFlags.Ipv4)
         radioButtonIpv6.Checked = (IpType = DicomNetIpTypeFlags.Ipv6)
         radioButtonIpv4Ipv6.Checked = (IpType = DicomNetIpTypeFlags.Ipv4OrIpv6)

         _listViewCipherSuites.InitializeCipherListView(CipherSuites, ImageListCiphers)
         _checkBoxTlsOld.Checked = CipherSuites.ContainsOldCipherSuites()

         _initializing = False
         EnableDialogItems()
      End Sub

      Private Sub _buttonMoveUp_Click(sender As Object, e As EventArgs) Handles _buttonMoveUp.Click
         _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Up)
      End Sub

      Private Sub _buttonMoveDown_Click(sender As Object, e As EventArgs) Handles _buttonMoveDown.Click
         _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Down)
      End Sub

      Private Sub _checkBoxTlsOld_CheckedChanged(sender As Object, e As EventArgs) Handles _checkBoxTlsOld.CheckedChanged
         _listViewCipherSuites.ListViewToCipherSuites(CipherSuites, _initializing)
         If _checkBoxTlsOld.Checked Then
            CipherSuites.AddOldCipherSuites()
         Else
            CipherSuites.RemoveOldCipherSuites()
         End If
         _listViewCipherSuites.UpdateCipherSuitesListView(CipherSuites)
         _listViewCipherSuites.Focus()
      End Sub

        Private Sub UseSecureTLSCommunication_CheckedChanged(sender As Object, e As EventArgs) Handles UseSecureTLSCommunication.CheckedChanged
            If UseSecureTLSCommunication.Checked Then
                If Utils.VerifyOpensslVersion(Me) = False Then
                    UseSecureTLSCommunication.Checked = False
                    Return
                End If
            End If
            EnableDialogItems()
        End Sub

        Public CipherSuites As New CipherSuiteItems()

    End Class
End Namespace
