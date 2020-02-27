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
Imports System.Text

Imports Leadtools.DicomDemos

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.Codecs

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for ImageOptionsDlg.
   ''' </summary>
   Public Class ImageOptionsDlg : Inherits System.Windows.Forms.Form
      Private groupBox1 As System.Windows.Forms.GroupBox
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing
      Private WithEvents radioButtonNone As System.Windows.Forms.RadioButton
      Private WithEvents radioButtonRunLength As System.Windows.Forms.RadioButton
      Private WithEvents radioButtonJpegLossless As System.Windows.Forms.RadioButton
      Private WithEvents radioButtonJPEGLossy As System.Windows.Forms.RadioButton
      Private WithEvents radioButtonJ2kLossless As System.Windows.Forms.RadioButton
      Private WithEvents radioButtonJ2kLossy As System.Windows.Forms.RadioButton
      Private label1 As System.Windows.Forms.Label
      Private buttonJ2kOptions As System.Windows.Forms.Button
      Private numericUpDownQFactor As System.Windows.Forms.NumericUpDown
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private WithEvents radioButtonMonochrome As System.Windows.Forms.RadioButton
      Private WithEvents radioButtonPalette As System.Windows.Forms.RadioButton
      Private WithEvents radioButtonRGB As System.Windows.Forms.RadioButton
      Private WithEvents radioButton8 As System.Windows.Forms.RadioButton
      Private WithEvents radioButton12 As System.Windows.Forms.RadioButton
      Private WithEvents radioButton16 As System.Windows.Forms.RadioButton
      Private WithEvents radioButton24 As System.Windows.Forms.RadioButton

      Private ds As DicomDataSet
      Private element As DicomElement

      Private _Compression As DicomImageCompressionType
      Private _BitsPerPixel As Integer
      Private _TransferSyntax As String
      Private _UseNewImageFile As Boolean
      Private _ForceNewImageFileName As Boolean
      Private _raster As RasterImage
      Private WithEvents buttonOriginal As System.Windows.Forms.Button
      Private buttonCancel As System.Windows.Forms.Button
      Private buttonOK As System.Windows.Forms.Button
      Private groupBox4 As System.Windows.Forms.GroupBox
      Private WithEvents checkBoxUseExistingImage As System.Windows.Forms.CheckBox
      Private label2 As System.Windows.Forms.Label
      Private textBoxNewImageFileName As System.Windows.Forms.TextBox
      Private WithEvents buttonSelectNewImage As System.Windows.Forms.Button
      Private WithEvents radioButtonJpegLsLossy As System.Windows.Forms.RadioButton
      Private WithEvents radioButtonJpegLsLossless As System.Windows.Forms.RadioButton
      Private _PhotoMetric As DicomImagePhotometricInterpretationType


      Public ReadOnly Property UseNewImageFile() As Boolean
         Get
            Return _UseNewImageFile
         End Get
      End Property
      Public Property ForceNewImageFileName() As Boolean
         Get
            Return _ForceNewImageFileName
         End Get
         Set(ByVal value As Boolean)
            _ForceNewImageFileName = Value
         End Set
      End Property

      Public ReadOnly Property NewImage() As RasterImage
         Get
            Return _raster
         End Get
      End Property
      Public ReadOnly Property Compression() As DicomImageCompressionType
         Get
            Return _Compression
         End Get
      End Property

      Public ReadOnly Property BitsPerPixel() As Integer
         Get
            Return _BitsPerPixel
         End Get
      End Property

      Public ReadOnly Property QFactor() As Integer
         Get
            Return Convert.ToInt32(numericUpDownQFactor.Value)
         End Get
      End Property

      Public ReadOnly Property TransferSyntax() As String
         Get
            Return _TransferSyntax
         End Get
      End Property

      Public ReadOnly Property PhotoMetric() As DicomImagePhotometricInterpretationType
         Get
            Return _PhotoMetric
         End Get
      End Property

      Public Sub New(ByVal ds As DicomDataSet, ByVal element As DicomElement)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
         _ForceNewImageFileName = False
         buttonJ2kOptions.Visible = False
         Me.ds = ds
         Me.element = element
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
            Me.groupBox1 = New System.Windows.Forms.GroupBox
            Me.buttonJ2kOptions = New System.Windows.Forms.Button
            Me.numericUpDownQFactor = New System.Windows.Forms.NumericUpDown
            Me.label1 = New System.Windows.Forms.Label
            Me.radioButtonJ2kLossy = New System.Windows.Forms.RadioButton
            Me.radioButtonJ2kLossless = New System.Windows.Forms.RadioButton
            Me.radioButtonJPEGLossy = New System.Windows.Forms.RadioButton
            Me.radioButtonJpegLossless = New System.Windows.Forms.RadioButton
            Me.radioButtonRunLength = New System.Windows.Forms.RadioButton
            Me.radioButtonNone = New System.Windows.Forms.RadioButton
            Me.buttonCancel = New System.Windows.Forms.Button
            Me.buttonOK = New System.Windows.Forms.Button
            Me.groupBox2 = New System.Windows.Forms.GroupBox
            Me.radioButtonRGB = New System.Windows.Forms.RadioButton
            Me.radioButtonPalette = New System.Windows.Forms.RadioButton
            Me.radioButtonMonochrome = New System.Windows.Forms.RadioButton
            Me.groupBox3 = New System.Windows.Forms.GroupBox
            Me.radioButton24 = New System.Windows.Forms.RadioButton
            Me.radioButton16 = New System.Windows.Forms.RadioButton
            Me.radioButton12 = New System.Windows.Forms.RadioButton
            Me.radioButton8 = New System.Windows.Forms.RadioButton
            Me.buttonOriginal = New System.Windows.Forms.Button
            Me.groupBox4 = New System.Windows.Forms.GroupBox
            Me.buttonSelectNewImage = New System.Windows.Forms.Button
            Me.textBoxNewImageFileName = New System.Windows.Forms.TextBox
            Me.label2 = New System.Windows.Forms.Label
            Me.checkBoxUseExistingImage = New System.Windows.Forms.CheckBox
            Me.radioButtonJpegLsLossy = New System.Windows.Forms.RadioButton
            Me.radioButtonJpegLsLossless = New System.Windows.Forms.RadioButton
            Me.groupBox1.SuspendLayout()
            CType(Me.numericUpDownQFactor, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.groupBox2.SuspendLayout()
            Me.groupBox3.SuspendLayout()
            Me.groupBox4.SuspendLayout()
            Me.SuspendLayout()
            '
            'groupBox1
            '
            Me.groupBox1.Controls.Add(Me.radioButtonJpegLsLossy)
            Me.groupBox1.Controls.Add(Me.buttonJ2kOptions)
            Me.groupBox1.Controls.Add(Me.radioButtonJpegLsLossless)
            Me.groupBox1.Controls.Add(Me.numericUpDownQFactor)
            Me.groupBox1.Controls.Add(Me.label1)
            Me.groupBox1.Controls.Add(Me.radioButtonJ2kLossy)
            Me.groupBox1.Controls.Add(Me.radioButtonJ2kLossless)
            Me.groupBox1.Controls.Add(Me.radioButtonJPEGLossy)
            Me.groupBox1.Controls.Add(Me.radioButtonJpegLossless)
            Me.groupBox1.Controls.Add(Me.radioButtonRunLength)
            Me.groupBox1.Controls.Add(Me.radioButtonNone)
            Me.groupBox1.Location = New System.Drawing.Point(8, 8)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(160, 288)
            Me.groupBox1.TabIndex = 0
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Compression"
            '
            'buttonJ2kOptions
            '
            Me.buttonJ2kOptions.Location = New System.Drawing.Point(16, 256)
            Me.buttonJ2kOptions.Name = "buttonJ2kOptions"
            Me.buttonJ2kOptions.Size = New System.Drawing.Size(112, 23)
            Me.buttonJ2kOptions.TabIndex = 9
            Me.buttonJ2kOptions.Text = "Options..."
            '
            'numericUpDownQFactor
            '
            Me.numericUpDownQFactor.Enabled = False
            Me.numericUpDownQFactor.Location = New System.Drawing.Point(72, 224)
            Me.numericUpDownQFactor.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
            Me.numericUpDownQFactor.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
            Me.numericUpDownQFactor.Name = "numericUpDownQFactor"
            Me.numericUpDownQFactor.Size = New System.Drawing.Size(56, 20)
            Me.numericUpDownQFactor.TabIndex = 8
            Me.numericUpDownQFactor.Value = New Decimal(New Integer() {2, 0, 0, 0})
            '
            'label1
            '
            Me.label1.Location = New System.Drawing.Point(16, 228)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(48, 16)
            Me.label1.TabIndex = 6
            Me.label1.Text = "QFactor:"
            '
            'radioButtonJ2kLossy
            '
            Me.radioButtonJ2kLossy.Location = New System.Drawing.Point(16, 192)
            Me.radioButtonJ2kLossy.Name = "radioButtonJ2kLossy"
            Me.radioButtonJ2kLossy.Size = New System.Drawing.Size(120, 24)
            Me.radioButtonJ2kLossy.TabIndex = 5
            Me.radioButtonJ2kLossy.Text = "JPEG 2000 Lossy"
            '
            'radioButtonJ2kLossless
            '
            Me.radioButtonJ2kLossless.Location = New System.Drawing.Point(16, 168)
            Me.radioButtonJ2kLossless.Name = "radioButtonJ2kLossless"
            Me.radioButtonJ2kLossless.Size = New System.Drawing.Size(128, 24)
            Me.radioButtonJ2kLossless.TabIndex = 4
            Me.radioButtonJ2kLossless.Text = "JPEG 2000 Lossless"
            '
            'radioButtonJPEGLossy
            '
            Me.radioButtonJPEGLossy.Location = New System.Drawing.Point(16, 96)
            Me.radioButtonJPEGLossy.Name = "radioButtonJPEGLossy"
            Me.radioButtonJPEGLossy.Size = New System.Drawing.Size(104, 24)
            Me.radioButtonJPEGLossy.TabIndex = 3
            Me.radioButtonJPEGLossy.Text = "JPEG Lossy"
            '
            'radioButtonJpegLossless
            '
            Me.radioButtonJpegLossless.Location = New System.Drawing.Point(16, 72)
            Me.radioButtonJpegLossless.Name = "radioButtonJpegLossless"
            Me.radioButtonJpegLossless.Size = New System.Drawing.Size(104, 24)
            Me.radioButtonJpegLossless.TabIndex = 2
            Me.radioButtonJpegLossless.Text = "JPEG Lossless"
            '
            'radioButtonRunLength
            '
            Me.radioButtonRunLength.Location = New System.Drawing.Point(16, 48)
            Me.radioButtonRunLength.Name = "radioButtonRunLength"
            Me.radioButtonRunLength.Size = New System.Drawing.Size(104, 24)
            Me.radioButtonRunLength.TabIndex = 1
            Me.radioButtonRunLength.Text = "Run Length"
            '
            'radioButtonNone
            '
            Me.radioButtonNone.Location = New System.Drawing.Point(16, 24)
            Me.radioButtonNone.Name = "radioButtonNone"
            Me.radioButtonNone.Size = New System.Drawing.Size(104, 24)
            Me.radioButtonNone.TabIndex = 0
            Me.radioButtonNone.Text = "None"
            '
            'buttonCancel
            '
            Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.buttonCancel.Location = New System.Drawing.Point(493, 312)
            Me.buttonCancel.Name = "buttonCancel"
            Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
            Me.buttonCancel.TabIndex = 1
            Me.buttonCancel.Text = "&Cancel"
            '
            'buttonOK
            '
            Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.buttonOK.Location = New System.Drawing.Point(408, 312)
            Me.buttonOK.Name = "buttonOK"
            Me.buttonOK.Size = New System.Drawing.Size(75, 23)
            Me.buttonOK.TabIndex = 2
            Me.buttonOK.Text = "&OK"
            '
            'groupBox2
            '
            Me.groupBox2.Controls.Add(Me.radioButtonRGB)
            Me.groupBox2.Controls.Add(Me.radioButtonPalette)
            Me.groupBox2.Controls.Add(Me.radioButtonMonochrome)
            Me.groupBox2.Location = New System.Drawing.Point(176, 8)
            Me.groupBox2.Name = "groupBox2"
            Me.groupBox2.Size = New System.Drawing.Size(176, 120)
            Me.groupBox2.TabIndex = 3
            Me.groupBox2.TabStop = False
            Me.groupBox2.Text = "Photometric Interpretation"
            '
            'radioButtonRGB
            '
            Me.radioButtonRGB.Location = New System.Drawing.Point(16, 72)
            Me.radioButtonRGB.Name = "radioButtonRGB"
            Me.radioButtonRGB.Size = New System.Drawing.Size(104, 24)
            Me.radioButtonRGB.TabIndex = 2
            Me.radioButtonRGB.Text = "RGB"
            '
            'radioButtonPalette
            '
            Me.radioButtonPalette.Location = New System.Drawing.Point(16, 48)
            Me.radioButtonPalette.Name = "radioButtonPalette"
            Me.radioButtonPalette.Size = New System.Drawing.Size(104, 24)
            Me.radioButtonPalette.TabIndex = 1
            Me.radioButtonPalette.Text = "Palette"
            '
            'radioButtonMonochrome
            '
            Me.radioButtonMonochrome.Location = New System.Drawing.Point(16, 24)
            Me.radioButtonMonochrome.Name = "radioButtonMonochrome"
            Me.radioButtonMonochrome.Size = New System.Drawing.Size(104, 24)
            Me.radioButtonMonochrome.TabIndex = 0
            Me.radioButtonMonochrome.Text = "Monochrome 2"
            '
            'groupBox3
            '
            Me.groupBox3.Controls.Add(Me.radioButton24)
            Me.groupBox3.Controls.Add(Me.radioButton16)
            Me.groupBox3.Controls.Add(Me.radioButton12)
            Me.groupBox3.Controls.Add(Me.radioButton8)
            Me.groupBox3.Location = New System.Drawing.Point(368, 8)
            Me.groupBox3.Name = "groupBox3"
            Me.groupBox3.Size = New System.Drawing.Size(200, 120)
            Me.groupBox3.TabIndex = 4
            Me.groupBox3.TabStop = False
            Me.groupBox3.Text = "Bits Per Pixel"
            '
            'radioButton24
            '
            Me.radioButton24.Enabled = False
            Me.radioButton24.Location = New System.Drawing.Point(16, 88)
            Me.radioButton24.Name = "radioButton24"
            Me.radioButton24.Size = New System.Drawing.Size(104, 16)
            Me.radioButton24.TabIndex = 3
            Me.radioButton24.Text = "24"
            '
            'radioButton16
            '
            Me.radioButton16.Enabled = False
            Me.radioButton16.Location = New System.Drawing.Point(16, 64)
            Me.radioButton16.Name = "radioButton16"
            Me.radioButton16.Size = New System.Drawing.Size(104, 24)
            Me.radioButton16.TabIndex = 2
            Me.radioButton16.Text = "16"
            '
            'radioButton12
            '
            Me.radioButton12.Enabled = False
            Me.radioButton12.Location = New System.Drawing.Point(16, 48)
            Me.radioButton12.Name = "radioButton12"
            Me.radioButton12.Size = New System.Drawing.Size(104, 16)
            Me.radioButton12.TabIndex = 1
            Me.radioButton12.Text = "12"
            '
            'radioButton8
            '
            Me.radioButton8.Enabled = False
            Me.radioButton8.Location = New System.Drawing.Point(16, 24)
            Me.radioButton8.Name = "radioButton8"
            Me.radioButton8.Size = New System.Drawing.Size(104, 24)
            Me.radioButton8.TabIndex = 0
            Me.radioButton8.Text = "8"
            '
            'buttonOriginal
            '
            Me.buttonOriginal.Location = New System.Drawing.Point(8, 312)
            Me.buttonOriginal.Name = "buttonOriginal"
            Me.buttonOriginal.Size = New System.Drawing.Size(75, 23)
            Me.buttonOriginal.TabIndex = 5
            Me.buttonOriginal.Text = "Default"
            '
            'groupBox4
            '
            Me.groupBox4.Controls.Add(Me.buttonSelectNewImage)
            Me.groupBox4.Controls.Add(Me.textBoxNewImageFileName)
            Me.groupBox4.Controls.Add(Me.label2)
            Me.groupBox4.Controls.Add(Me.checkBoxUseExistingImage)
            Me.groupBox4.Location = New System.Drawing.Point(176, 136)
            Me.groupBox4.Name = "groupBox4"
            Me.groupBox4.Size = New System.Drawing.Size(392, 120)
            Me.groupBox4.TabIndex = 6
            Me.groupBox4.TabStop = False
            Me.groupBox4.Text = "Image File"
            '
            'buttonSelectNewImage
            '
            Me.buttonSelectNewImage.Location = New System.Drawing.Point(304, 88)
            Me.buttonSelectNewImage.Name = "buttonSelectNewImage"
            Me.buttonSelectNewImage.Size = New System.Drawing.Size(80, 24)
            Me.buttonSelectNewImage.TabIndex = 3
            Me.buttonSelectNewImage.Text = "Select File..."
            '
            'textBoxNewImageFileName
            '
            Me.textBoxNewImageFileName.Location = New System.Drawing.Point(16, 88)
            Me.textBoxNewImageFileName.Name = "textBoxNewImageFileName"
            Me.textBoxNewImageFileName.ReadOnly = True
            Me.textBoxNewImageFileName.Size = New System.Drawing.Size(280, 24)
            Me.textBoxNewImageFileName.TabIndex = 2
            '
            'label2
            '
            Me.label2.Location = New System.Drawing.Point(16, 64)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(160, 16)
            Me.label2.TabIndex = 1
            Me.label2.Text = "New Image File Name"
            '
            'checkBoxUseExistingImage
            '
            Me.checkBoxUseExistingImage.Location = New System.Drawing.Point(16, 24)
            Me.checkBoxUseExistingImage.Name = "checkBoxUseExistingImage"
            Me.checkBoxUseExistingImage.Size = New System.Drawing.Size(144, 16)
            Me.checkBoxUseExistingImage.TabIndex = 0
            Me.checkBoxUseExistingImage.Text = "Use Existing Image"
            '
            'radioButtonJpegLsLossy
            '
            Me.radioButtonJpegLsLossy.Location = New System.Drawing.Point(16, 144)
            Me.radioButtonJpegLsLossy.Name = "radioButtonJpegLsLossy"
            Me.radioButtonJpegLsLossy.Size = New System.Drawing.Size(120, 24)
            Me.radioButtonJpegLsLossy.TabIndex = 13
            Me.radioButtonJpegLsLossy.Text = "JPEG-LS Lossy"
            '
            'radioButtonJpegLsLossless
            '
            Me.radioButtonJpegLsLossless.Location = New System.Drawing.Point(16, 120)
            Me.radioButtonJpegLsLossless.Name = "radioButtonJpegLsLossless"
            Me.radioButtonJpegLsLossless.Size = New System.Drawing.Size(128, 24)
            Me.radioButtonJpegLsLossless.TabIndex = 12
            Me.radioButtonJpegLsLossless.Text = "JPEG-LS Lossless"
            '
            'ImageOptionsDlg
            '
            Me.AcceptButton = Me.buttonOK
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.CancelButton = Me.buttonCancel
            Me.ClientSize = New System.Drawing.Size(578, 346)
            Me.Controls.Add(Me.groupBox4)
            Me.Controls.Add(Me.buttonOriginal)
            Me.Controls.Add(Me.groupBox3)
            Me.Controls.Add(Me.groupBox2)
            Me.Controls.Add(Me.buttonOK)
            Me.Controls.Add(Me.buttonCancel)
            Me.Controls.Add(Me.groupBox1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ImageOptionsDlg"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Image Options"
            Me.groupBox1.ResumeLayout(False)
            CType(Me.numericUpDownQFactor, System.ComponentModel.ISupportInitialize).EndInit()
            Me.groupBox2.ResumeLayout(False)
            Me.groupBox3.ResumeLayout(False)
            Me.groupBox4.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
#End Region

      Private Sub radioButtonJPEGLossy_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButtonJPEGLossy.CheckedChanged
         numericUpDownQFactor.Enabled = radioButtonJPEGLossy.Checked
         If radioButtonJPEGLossy.Checked Then
            _Compression = DicomImageCompressionType.JpegLossy
            _TransferSyntax = DicomUidType.JPEGBaseline1
         End If
      End Sub

        Private Sub radioButtonJpegLsLossless_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioButtonJpegLsLossless.CheckedChanged
            If radioButtonJpegLsLossless.Checked Then
                _Compression = DicomImageCompressionType.JpegLsLossless
                _TransferSyntax = DicomUidType.JPEGLSLossless
            End If
        End Sub

        Private Sub radioButtonJpegLsLossy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioButtonJpegLsLossy.CheckedChanged
            numericUpDownQFactor.Enabled = radioButtonJpegLsLossy.Checked
            If radioButtonJpegLsLossy.Checked Then
                _Compression = DicomImageCompressionType.JpegLsLossy
                _TransferSyntax = DicomUidType.JPEGLSLossy
            End If
        End Sub

      Private Sub radioButtonJ2kLossy_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButtonJ2kLossy.CheckedChanged
         numericUpDownQFactor.Enabled = radioButtonJ2kLossy.Checked
         If radioButtonJ2kLossy.Checked Then
            _Compression = DicomImageCompressionType.J2kLossy
            _TransferSyntax = DicomUidType.JPEG2000
         End If
      End Sub

      Private Sub radioButtonPalette_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButtonPalette.CheckedChanged
		 radioButton8.Enabled = radioButtonPalette.Checked
		 radioButton8.Checked = True
		 'radioButton12.Enabled = radioButtonPalette.Checked;

		 If radioButtonPalette.Checked Then
			_PhotoMetric = DicomImagePhotometricInterpretationType.PaletteColor
		 End If
	  End Sub

      Private Sub radioButtonMonochrome_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButtonMonochrome.CheckedChanged
		 radioButton8.Enabled = radioButtonMonochrome.Checked
		 radioButton12.Enabled = radioButtonMonochrome.Checked
		 radioButton16.Enabled = radioButtonMonochrome.Checked

		 If radioButtonMonochrome.Checked Then
			If radioButton24.Checked Then
			   radioButton16.Checked = True
			End If
			_PhotoMetric = DicomImagePhotometricInterpretationType.Monochrome2
		 End If
	  End Sub

      Private Sub radioButtonRGB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButtonRGB.CheckedChanged
		 radioButton24.Enabled = radioButtonRGB.Checked
		 radioButton24.Checked = True

		 If radioButtonRGB.Checked Then
			_PhotoMetric = DicomImagePhotometricInterpretationType.Rgb
		 End If
	  End Sub

      Private Sub ImageOptionsDlg_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
         If DialogResult = System.Windows.Forms.DialogResult.OK Then

         End If
      End Sub

      Private Sub radioButtonNone_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButtonNone.CheckedChanged
         If radioButtonNone.Checked Then
            _Compression = DicomImageCompressionType.None
            _TransferSyntax = DicomUidType.ImplicitVRLittleEndian
         End If
      End Sub

      Private Sub radioButtonRunLength_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButtonRunLength.CheckedChanged
         If radioButtonRunLength.Checked Then
            _Compression = DicomImageCompressionType.Rle
            _TransferSyntax = DicomUidType.RLELossless
         End If
      End Sub

      Private Sub radioButtonJpegLossless_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButtonJpegLossless.CheckedChanged
         If radioButtonJpegLossless.Checked Then
            _Compression = DicomImageCompressionType.JpegLossless
            _TransferSyntax = DicomUidType.JPEGLosslessNonhier14B
         End If
      End Sub

      Private Sub radioButtonJ2kLossless_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButtonJ2kLossless.CheckedChanged
         If radioButtonJ2kLossless.Checked Then
            _Compression = DicomImageCompressionType.J2kLossless
            _TransferSyntax = DicomUidType.JPEG2000LosslessOnly
         End If
      End Sub

      Private Sub radioButton8_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButton8.CheckedChanged
         If radioButton8.Checked Then
            _BitsPerPixel = 8
         End If
      End Sub

      Private Sub radioButton12_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButton12.CheckedChanged
         If radioButton12.Checked Then
            _BitsPerPixel = 12
         End If
      End Sub

      Private Sub radioButton16_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButton16.CheckedChanged
         If radioButton16.Checked Then
            _BitsPerPixel = 16
         End If
      End Sub

      Private Sub radioButton24_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButton24.CheckedChanged
         If radioButton24.Checked Then
            _BitsPerPixel = 24
         End If
      End Sub

      Private Sub ImageOptionsDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         SetDefaults()
	  End Sub

Private Sub SetDefaults()
		 Dim imageInfo As DicomImageInformation

		 Try
			imageInfo = ds.GetImageInformation(element, 0)

			'
			' Initialize Bits Per Pixel
			'
			If imageInfo.BitsPerPixel = 8 Then
			   radioButton8.Checked = True
			ElseIf imageInfo.BitsPerPixel = 12 Then
			   radioButton12.Checked = True
			ElseIf imageInfo.BitsPerPixel = 16 Then
			   radioButton16.Checked = True
			ElseIf imageInfo.BitsPerPixel = 24 Then
			   radioButton24.Checked = True
			End If

			'
			' Initialize Photometric Interpretation
			'
			If imageInfo.PhotometricInterpretation = DicomImagePhotometricInterpretationType.Monochrome2 Then
			   radioButtonMonochrome.Checked = True
			ElseIf imageInfo.PhotometricInterpretation = DicomImagePhotometricInterpretationType.PaletteColor Then
			   radioButtonPalette.Checked = True
			ElseIf imageInfo.PhotometricInterpretation = DicomImagePhotometricInterpretationType.Rgb Then
			   radioButtonRGB.Checked = True
			End If

			'
			' Initialize Compression
			'
			If imageInfo.Compression = DicomImageCompressionType.None Then
			   radioButtonNone.Checked = True
			ElseIf imageInfo.Compression = DicomImageCompressionType.JpegLossy Then
			   radioButtonJPEGLossy.Checked = True
			ElseIf imageInfo.Compression = DicomImageCompressionType.JpegLossless Then
			   radioButtonJpegLossless.Checked = True
			ElseIf imageInfo.Compression = DicomImageCompressionType.JpegLsLossy Then
			   radioButtonJpegLsLossy.Checked = True
			ElseIf imageInfo.Compression = DicomImageCompressionType.JpegLsLossless Then
			   radioButtonJpegLsLossless.Checked = True
			ElseIf imageInfo.Compression = DicomImageCompressionType.J2kLossy Then
			   radioButtonJ2kLossy.Checked = True
			ElseIf imageInfo.Compression = DicomImageCompressionType.J2kLossless Then
			   radioButtonJ2kLossless.Checked = True
			ElseIf imageInfo.Compression = DicomImageCompressionType.Rle Then
			   radioButtonRunLength.Checked = True
			End If
			checkBoxUseExistingImage.Checked = True
			buttonSelectNewImage.Enabled = False
		 Catch
			radioButton24.Checked = True
			radioButtonRGB.Checked = True
			radioButtonNone.Checked = True
			checkBoxUseExistingImage.Checked = False
			buttonSelectNewImage.Enabled = True
		 End Try

		 textBoxNewImageFileName.Text = ""
		 _TransferSyntax = Utils.GetStringValue(ds, DemoDicomTags.TransferSyntaxUID)

		 _UseNewImageFile = Not checkBoxUseExistingImage.Checked
End Sub

      Private Sub buttonOriginal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonOriginal.Click
         SetDefaults()
      End Sub

      Private Sub buttonSelectNewImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonSelectNewImage.Click
         Dim loader As DICOMImageFileLoader = New DICOMImageFileLoader()
         Using codecs As New RasterCodecs()

            If loader.Load(Me, codecs, True) And Not loader.Image Is Nothing Then
               _raster = loader.Image
               textBoxNewImageFileName.Text = loader.FileName
            End If
         End Using
      End Sub

      Private Sub checkBoxUseExistingImage_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkBoxUseExistingImage.CheckedChanged
         buttonSelectNewImage.Enabled = Not buttonSelectNewImage.Enabled
         _UseNewImageFile = Not _UseNewImageFile
      End Sub


   End Class

   Public Class DICOMImageFileLoader
      Public Enum Filter
         AllFiles
      End Enum

      Private Structure LoadFormat
         Private _name As String
         Private _extensions As String
         Private _filter As Filter

         Private Sub New(ByVal name_Renamed As String, ByVal extensions_Renamed As String, ByVal filter_Renamed As Filter)
            _name = name_Renamed
            _extensions = extensions_Renamed
            _filter = filter_Renamed
         End Sub

         Public ReadOnly Property Name() As String
            Get
               Return _name
            End Get
         End Property

         Public ReadOnly Property Extensions() As String
            Get
               Return _extensions
            End Get
         End Property

         Public ReadOnly Property Filter() As Filter
            Get
               Return _filter
            End Get
         End Property

         Public Overrides Function ToString() As String
            Return String.Format("{0} ({1})|{2}", Name, Extensions, Extensions)
         End Function

         Public Shared ReadOnly Entries As LoadFormat()
         Shared Sub New()
            Entries = New LoadFormat() {New LoadFormat("All Files", "*.*", Filter.AllFiles)}
         End Sub
      End Structure

      Public Shared Function GetFilterIndex(ByVal filter As Filter) As Integer
         Dim i As Integer = 0
         Do While i < LoadFormat.Entries.Length
            If filter = LoadFormat.Entries(i).Filter Then
               Return i + 1
            End If
            i += 1
         Loop

         Return 1
      End Function

      Private Shared _filterIndex As Integer = 1
      Private _fileName As String
      Private _image As RasterImage
      Private _loadOnlyOnePage As Boolean = False

      Public Sub New()
      End Sub

      Public ReadOnly Property FileName() As String
         Get
            Return _fileName
         End Get
      End Property

      Public ReadOnly Property Image() As RasterImage
         Get
            Return _image
         End Get
      End Property

      Public Property LoadOnlyOnePage() As Boolean
         Get
            Return _loadOnlyOnePage
         End Get
         Set(ByVal value As Boolean)
            _loadOnlyOnePage = Value
         End Set
      End Property

      Public Shared Property FilterIndex() As Integer
         Get
            Return _filterIndex
         End Get
         Set(ByVal value As Integer)
            _filterIndex = Value
         End Set
      End Property

      Public Function Load(ByVal owner As IWin32Window, ByVal codecs As RasterCodecs, ByVal autoLoad As Boolean) As Boolean
         _fileName = String.Empty
         _image = Nothing

         Dim sb As StringBuilder = New StringBuilder()
         Dim i As Integer = 0
         Do While i < LoadFormat.Entries.Length
            sb.Append(LoadFormat.Entries(i).ToString())
            If i <> (LoadFormat.Entries.Length - 1) Then
               sb.Append("|")
            End If
            i += 1
         Loop

         Dim ofd As OpenFileDialog = New OpenFileDialog()
         ofd.Filter = sb.ToString()
         ofd.FilterIndex = _filterIndex

         Dim ok As Boolean = False

         Try
            If ofd.ShowDialog(owner) = System.Windows.Forms.DialogResult.OK Then
               _fileName = ofd.FileName
               ok = True

               _filterIndex = ofd.FilterIndex

               Dim info As CodecsImageInfo

               Using wait As WaitCursor = New WaitCursor()
                  info = codecs.GetInformation(ofd.FileName, True)
               End Using
               If autoLoad AndAlso ok Then
                  Using wait As WaitCursor = New WaitCursor()
                     _image = codecs.Load(ofd.FileName, 0, CodecsLoadByteOrder.BgrOrGray, 1, 1)
                  End Using
               End If
            Else
               ok = True
            End If
         Catch
            MessageBox.Show("Failed to load image.\nPlease note that, you can't use this dialog to load a DICOM file as an image.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ok = False
         End Try
         Return ok
      End Function
   End Class
End Namespace
