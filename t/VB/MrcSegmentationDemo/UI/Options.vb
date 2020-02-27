' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools

Namespace MrcSegmentationDemo
   ''' <summary>
   ''' Summary description for Options.
   ''' </summary>
   Public Class Options : Inherits System.Windows.Forms.Form
      Private WithEvents tanctrlOptions As System.Windows.Forms.TabControl
      Private tabMrcCompressions As System.Windows.Forms.TabPage
      Private tabPDFCompressions As System.Windows.Forms.TabPage
      Private tabCombine As System.Windows.Forms.TabPage
      Private tabColors As System.Windows.Forms.TabPage
      Private WithEvents _cb1BitTxtMaskCom As System.Windows.Forms.ComboBox
      Private _lbl1BitTxtMaskCom As System.Windows.Forms.Label
      Private WithEvents _cb2BitGrayscaleCom As System.Windows.Forms.ComboBox
      Private _lblMrcCom6 As System.Windows.Forms.Label
      Private WithEvents _cb2BitTxtClrCom As System.Windows.Forms.ComboBox
      Private _lblMrcCom5 As System.Windows.Forms.Label
      Private WithEvents _txtGrayscaleFactor As System.Windows.Forms.TextBox
      Private _lblMrcCom4 As System.Windows.Forms.Label
      Private WithEvents _cb8BitGrayCom As System.Windows.Forms.ComboBox
      Private _lblMrcCom3 As System.Windows.Forms.Label
      Private WithEvents _txtMrcClrQualityFactor As System.Windows.Forms.TextBox
      Private _lblMrcCom2 As System.Windows.Forms.Label
      Private WithEvents _cb24BitClrPicCom As System.Windows.Forms.ComboBox
      Private _lblMrcCom1 As System.Windows.Forms.Label
      Private WithEvents _cb1BitCom As System.Windows.Forms.ComboBox
      Private _lbl1BitCom As System.Windows.Forms.Label
      Private WithEvents _cb2BitCom As System.Windows.Forms.ComboBox
      Private _lblPDFCom3 As System.Windows.Forms.Label
      Private WithEvents _txtPDFClrQualityFactor As System.Windows.Forms.TextBox
      Private _lblPDFCom2 As System.Windows.Forms.Label
      Private WithEvents _cbPicCom As System.Windows.Forms.ComboBox
      Private _lblPDFCom1 As System.Windows.Forms.Label
      Private _groupBox2 As System.Windows.Forms.GroupBox
      Private WithEvents _chckSearchForBackBG As System.Windows.Forms.CheckBox
      Private WithEvents _cbTypes As System.Windows.Forms.ComboBox
      Private WithEvents _txtClrThreshold As System.Windows.Forms.TextBox
      Private WithEvents _txtQuality As System.Windows.Forms.TextBox
      Private WithEvents _tbClrThreshold As System.Windows.Forms.TrackBar
      Private WithEvents _tbQuality As System.Windows.Forms.TrackBar
      Private _lblSeg6 As System.Windows.Forms.Label
      Private _lblSeg5 As System.Windows.Forms.Label
      Private _lblSeg4 As System.Windows.Forms.Label
      Private WithEvents _cbOutputImage As System.Windows.Forms.ComboBox
      Private _groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents _txtCombineThreshold As System.Windows.Forms.TextBox
      Private WithEvents _txtCleanSize As System.Windows.Forms.TextBox
      Private WithEvents _txtBgThreshold As System.Windows.Forms.TextBox
      Private WithEvents _tbCombineThreshold As System.Windows.Forms.TrackBar
      Private WithEvents _tbCleanSize As System.Windows.Forms.TrackBar
      Private _lblSeg3 As System.Windows.Forms.Label
      Private _lblSeg2 As System.Windows.Forms.Label
      Private _lblSeg1 As System.Windows.Forms.Label
      Private WithEvents _cbInputImage As System.Windows.Forms.ComboBox
      Private WithEvents _cbCombiningType As System.Windows.Forms.ComboBox
      Private WithEvents _txtCombiningFactor As System.Windows.Forms.TextBox
      Private WithEvents _tbCombiningFactor As System.Windows.Forms.TrackBar
      Private _lblCombine2 As System.Windows.Forms.Label
      Private _lblCombine1 As System.Windows.Forms.Label
      Private WithEvents _btnFGClr As System.Windows.Forms.Button
      Private _lblForegroundClr As System.Windows.Forms.Label
      Private WithEvents _btnBGClr As System.Windows.Forms.Button
      Private _lblBackgroundClr As System.Windows.Forms.Label
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private _tabSegmentation As System.Windows.Forms.TabPage
      Private WithEvents _tbBgThreshold As System.Windows.Forms.TrackBar
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         FillControls()
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
         Me.tanctrlOptions = New System.Windows.Forms.TabControl()
         Me.tabMrcCompressions = New System.Windows.Forms.TabPage()
         Me._cb1BitTxtMaskCom = New System.Windows.Forms.ComboBox()
         Me._lbl1BitTxtMaskCom = New System.Windows.Forms.Label()
         Me._cb2BitGrayscaleCom = New System.Windows.Forms.ComboBox()
         Me._lblMrcCom6 = New System.Windows.Forms.Label()
         Me._cb2BitTxtClrCom = New System.Windows.Forms.ComboBox()
         Me._lblMrcCom5 = New System.Windows.Forms.Label()
         Me._txtGrayscaleFactor = New System.Windows.Forms.TextBox()
         Me._lblMrcCom4 = New System.Windows.Forms.Label()
         Me._cb8BitGrayCom = New System.Windows.Forms.ComboBox()
         Me._lblMrcCom3 = New System.Windows.Forms.Label()
         Me._txtMrcClrQualityFactor = New System.Windows.Forms.TextBox()
         Me._lblMrcCom2 = New System.Windows.Forms.Label()
         Me._cb24BitClrPicCom = New System.Windows.Forms.ComboBox()
         Me._lblMrcCom1 = New System.Windows.Forms.Label()
         Me.tabPDFCompressions = New System.Windows.Forms.TabPage()
         Me._cb1BitCom = New System.Windows.Forms.ComboBox()
         Me._lbl1BitCom = New System.Windows.Forms.Label()
         Me._cb2BitCom = New System.Windows.Forms.ComboBox()
         Me._lblPDFCom3 = New System.Windows.Forms.Label()
         Me._txtPDFClrQualityFactor = New System.Windows.Forms.TextBox()
         Me._lblPDFCom2 = New System.Windows.Forms.Label()
         Me._cbPicCom = New System.Windows.Forms.ComboBox()
         Me._lblPDFCom1 = New System.Windows.Forms.Label()
         Me._tabSegmentation = New System.Windows.Forms.TabPage()
         Me._groupBox2 = New System.Windows.Forms.GroupBox()
         Me._chckSearchForBackBG = New System.Windows.Forms.CheckBox()
         Me._cbTypes = New System.Windows.Forms.ComboBox()
         Me._txtClrThreshold = New System.Windows.Forms.TextBox()
         Me._txtQuality = New System.Windows.Forms.TextBox()
         Me._tbClrThreshold = New System.Windows.Forms.TrackBar()
         Me._tbQuality = New System.Windows.Forms.TrackBar()
         Me._lblSeg6 = New System.Windows.Forms.Label()
         Me._lblSeg5 = New System.Windows.Forms.Label()
         Me._lblSeg4 = New System.Windows.Forms.Label()
         Me._cbOutputImage = New System.Windows.Forms.ComboBox()
         Me._groupBox1 = New System.Windows.Forms.GroupBox()
         Me._txtCombineThreshold = New System.Windows.Forms.TextBox()
         Me._txtCleanSize = New System.Windows.Forms.TextBox()
         Me._txtBgThreshold = New System.Windows.Forms.TextBox()
         Me._tbCombineThreshold = New System.Windows.Forms.TrackBar()
         Me._tbCleanSize = New System.Windows.Forms.TrackBar()
         Me._tbBgThreshold = New System.Windows.Forms.TrackBar()
         Me._lblSeg3 = New System.Windows.Forms.Label()
         Me._lblSeg2 = New System.Windows.Forms.Label()
         Me._lblSeg1 = New System.Windows.Forms.Label()
         Me._cbInputImage = New System.Windows.Forms.ComboBox()
         Me.tabCombine = New System.Windows.Forms.TabPage()
         Me._cbCombiningType = New System.Windows.Forms.ComboBox()
         Me._txtCombiningFactor = New System.Windows.Forms.TextBox()
         Me._tbCombiningFactor = New System.Windows.Forms.TrackBar()
         Me._lblCombine2 = New System.Windows.Forms.Label()
         Me._lblCombine1 = New System.Windows.Forms.Label()
         Me.tabColors = New System.Windows.Forms.TabPage()
         Me._btnFGClr = New System.Windows.Forms.Button()
         Me._lblForegroundClr = New System.Windows.Forms.Label()
         Me._btnBGClr = New System.Windows.Forms.Button()
         Me._lblBackgroundClr = New System.Windows.Forms.Label()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me.tanctrlOptions.SuspendLayout()
         Me.tabMrcCompressions.SuspendLayout()
         Me.tabPDFCompressions.SuspendLayout()
         Me._tabSegmentation.SuspendLayout()
         Me._groupBox2.SuspendLayout()
         CType(Me._tbClrThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._tbQuality, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._groupBox1.SuspendLayout()
         CType(Me._tbCombineThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._tbCleanSize, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._tbBgThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.tabCombine.SuspendLayout()
         CType(Me._tbCombiningFactor, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.tabColors.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' tanctrlOptions
         ' 
         Me.tanctrlOptions.Controls.Add(Me.tabMrcCompressions)
         Me.tanctrlOptions.Controls.Add(Me.tabPDFCompressions)
         Me.tanctrlOptions.Controls.Add(Me._tabSegmentation)
         Me.tanctrlOptions.Controls.Add(Me.tabCombine)
         Me.tanctrlOptions.Controls.Add(Me.tabColors)
         Me.tanctrlOptions.Location = New System.Drawing.Point(8, 8)
         Me.tanctrlOptions.Name = "tanctrlOptions"
         Me.tanctrlOptions.SelectedIndex = 0
         Me.tanctrlOptions.Size = New System.Drawing.Size(408, 360)
         Me.tanctrlOptions.TabIndex = 0
         ' 
         ' tabMrcCompressions
         ' 
         Me.tabMrcCompressions.Controls.Add(Me._cb1BitTxtMaskCom)
         Me.tabMrcCompressions.Controls.Add(Me._lbl1BitTxtMaskCom)
         Me.tabMrcCompressions.Controls.Add(Me._cb2BitGrayscaleCom)
         Me.tabMrcCompressions.Controls.Add(Me._lblMrcCom6)
         Me.tabMrcCompressions.Controls.Add(Me._cb2BitTxtClrCom)
         Me.tabMrcCompressions.Controls.Add(Me._lblMrcCom5)
         Me.tabMrcCompressions.Controls.Add(Me._txtGrayscaleFactor)
         Me.tabMrcCompressions.Controls.Add(Me._lblMrcCom4)
         Me.tabMrcCompressions.Controls.Add(Me._cb8BitGrayCom)
         Me.tabMrcCompressions.Controls.Add(Me._lblMrcCom3)
         Me.tabMrcCompressions.Controls.Add(Me._txtMrcClrQualityFactor)
         Me.tabMrcCompressions.Controls.Add(Me._lblMrcCom2)
         Me.tabMrcCompressions.Controls.Add(Me._cb24BitClrPicCom)
         Me.tabMrcCompressions.Controls.Add(Me._lblMrcCom1)
         Me.tabMrcCompressions.Location = New System.Drawing.Point(4, 22)
         Me.tabMrcCompressions.Name = "tabMrcCompressions"
         Me.tabMrcCompressions.Size = New System.Drawing.Size(400, 334)
         Me.tabMrcCompressions.TabIndex = 0
         Me.tabMrcCompressions.Text = "Mrc Compressions"
         ' 
         ' _cb1BitTxtMaskCom
         ' 
         Me._cb1BitTxtMaskCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cb1BitTxtMaskCom.Location = New System.Drawing.Point(21, 278)
         Me._cb1BitTxtMaskCom.Name = "_cb1BitTxtMaskCom"
         Me._cb1BitTxtMaskCom.Size = New System.Drawing.Size(205, 21)
         Me._cb1BitTxtMaskCom.TabIndex = 13
         ' 
         ' _lbl1BitTxtMaskCom
         ' 
         Me._lbl1BitTxtMaskCom.Location = New System.Drawing.Point(21, 262)
         Me._lbl1BitTxtMaskCom.Name = "_lbl1BitTxtMaskCom"
         Me._lbl1BitTxtMaskCom.Size = New System.Drawing.Size(176, 16)
         Me._lbl1BitTxtMaskCom.TabIndex = 12
         Me._lbl1BitTxtMaskCom.Text = "1-Bit Text/&Mask Compression"
         ' 
         ' _cb2BitGrayscaleCom
         ' 
         Me._cb2BitGrayscaleCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cb2BitGrayscaleCom.Location = New System.Drawing.Point(21, 234)
         Me._cb2BitGrayscaleCom.Name = "_cb2BitGrayscaleCom"
         Me._cb2BitGrayscaleCom.Size = New System.Drawing.Size(205, 21)
         Me._cb2BitGrayscaleCom.TabIndex = 11
         ' 
         ' _lblMrcCom6
         ' 
         Me._lblMrcCom6.Location = New System.Drawing.Point(21, 218)
         Me._lblMrcCom6.Name = "_lblMrcCom6"
         Me._lblMrcCom6.Size = New System.Drawing.Size(176, 16)
         Me._lblMrcCom6.TabIndex = 10
         Me._lblMrcCom6.Text = "2-Bit G&rayscale Compression"
         ' 
         ' _cb2BitTxtClrCom
         ' 
         Me._cb2BitTxtClrCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cb2BitTxtClrCom.Location = New System.Drawing.Point(21, 192)
         Me._cb2BitTxtClrCom.Name = "_cb2BitTxtClrCom"
         Me._cb2BitTxtClrCom.Size = New System.Drawing.Size(205, 21)
         Me._cb2BitTxtClrCom.TabIndex = 9
         ' 
         ' _lblMrcCom5
         ' 
         Me._lblMrcCom5.Location = New System.Drawing.Point(21, 174)
         Me._lblMrcCom5.Name = "_lblMrcCom5"
         Me._lblMrcCom5.Size = New System.Drawing.Size(176, 16)
         Me._lblMrcCom5.TabIndex = 8
         Me._lblMrcCom5.Text = "2-Bit Te&xt Colored Compression"
         ' 
         ' _txtGrayscaleFactor
         ' 
         Me._txtGrayscaleFactor.Enabled = False
         Me._txtGrayscaleFactor.Location = New System.Drawing.Point(168, 144)
         Me._txtGrayscaleFactor.MaxLength = 3
         Me._txtGrayscaleFactor.Name = "_txtGrayscaleFactor"
         Me._txtGrayscaleFactor.Size = New System.Drawing.Size(56, 20)
         Me._txtGrayscaleFactor.TabIndex = 7
         ' 
         ' _lblMrcCom4
         ' 
         Me._lblMrcCom4.Location = New System.Drawing.Point(20, 146)
         Me._lblMrcCom4.Name = "_lblMrcCom4"
         Me._lblMrcCom4.Size = New System.Drawing.Size(136, 16)
         Me._lblMrcCom4.TabIndex = 6
         Me._lblMrcCom4.Text = "&Grayscale Quality Factor"
         ' 
         ' _cb8BitGrayCom
         ' 
         Me._cb8BitGrayCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cb8BitGrayCom.Location = New System.Drawing.Point(18, 115)
         Me._cb8BitGrayCom.Name = "_cb8BitGrayCom"
         Me._cb8BitGrayCom.Size = New System.Drawing.Size(205, 21)
         Me._cb8BitGrayCom.TabIndex = 5
         ' 
         ' _lblMrcCom3
         ' 
         Me._lblMrcCom3.Location = New System.Drawing.Point(20, 96)
         Me._lblMrcCom3.Name = "_lblMrcCom3"
         Me._lblMrcCom3.Size = New System.Drawing.Size(176, 16)
         Me._lblMrcCom3.TabIndex = 4
         Me._lblMrcCom3.Text = "&8-Bit Grayscale Compression"
         ' 
         ' _txtMrcClrQualityFactor
         ' 
         Me._txtMrcClrQualityFactor.Location = New System.Drawing.Point(168, 63)
         Me._txtMrcClrQualityFactor.MaxLength = 3
         Me._txtMrcClrQualityFactor.Name = "_txtMrcClrQualityFactor"
         Me._txtMrcClrQualityFactor.Size = New System.Drawing.Size(56, 20)
         Me._txtMrcClrQualityFactor.TabIndex = 3
         ' 
         ' _lblMrcCom2
         ' 
         Me._lblMrcCom2.Location = New System.Drawing.Point(22, 64)
         Me._lblMrcCom2.Name = "_lblMrcCom2"
         Me._lblMrcCom2.Size = New System.Drawing.Size(108, 16)
         Me._lblMrcCom2.TabIndex = 2
         Me._lblMrcCom2.Text = "Color &Quality Factor"
         ' 
         ' _cb24BitClrPicCom
         ' 
         Me._cb24BitClrPicCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cb24BitClrPicCom.Location = New System.Drawing.Point(19, 35)
         Me._cb24BitClrPicCom.Name = "_cb24BitClrPicCom"
         Me._cb24BitClrPicCom.Size = New System.Drawing.Size(205, 21)
         Me._cb24BitClrPicCom.TabIndex = 1
         ' 
         ' _lblMrcCom1
         ' 
         Me._lblMrcCom1.Location = New System.Drawing.Point(20, 16)
         Me._lblMrcCom1.Name = "_lblMrcCom1"
         Me._lblMrcCom1.Size = New System.Drawing.Size(176, 16)
         Me._lblMrcCom1.TabIndex = 0
         Me._lblMrcCom1.Text = "2&4-Bit Color Picture Compression"
         ' 
         ' tabPDFCompressions
         ' 
         Me.tabPDFCompressions.Controls.Add(Me._cb1BitCom)
         Me.tabPDFCompressions.Controls.Add(Me._lbl1BitCom)
         Me.tabPDFCompressions.Controls.Add(Me._cb2BitCom)
         Me.tabPDFCompressions.Controls.Add(Me._lblPDFCom3)
         Me.tabPDFCompressions.Controls.Add(Me._txtPDFClrQualityFactor)
         Me.tabPDFCompressions.Controls.Add(Me._lblPDFCom2)
         Me.tabPDFCompressions.Controls.Add(Me._cbPicCom)
         Me.tabPDFCompressions.Controls.Add(Me._lblPDFCom1)
         Me.tabPDFCompressions.Location = New System.Drawing.Point(4, 22)
         Me.tabPDFCompressions.Name = "tabPDFCompressions"
         Me.tabPDFCompressions.Size = New System.Drawing.Size(400, 334)
         Me.tabPDFCompressions.TabIndex = 1
         Me.tabPDFCompressions.Text = "PDF Compressions"
         ' 
         ' _cb1BitCom
         ' 
         Me._cb1BitCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cb1BitCom.Location = New System.Drawing.Point(19, 158)
         Me._cb1BitCom.Name = "_cb1BitCom"
         Me._cb1BitCom.Size = New System.Drawing.Size(205, 21)
         Me._cb1BitCom.TabIndex = 7
         ' 
         ' _lbl1BitCom
         ' 
         Me._lbl1BitCom.Location = New System.Drawing.Point(19, 142)
         Me._lbl1BitCom.Name = "_lbl1BitCom"
         Me._lbl1BitCom.Size = New System.Drawing.Size(176, 16)
         Me._lbl1BitCom.TabIndex = 6
         Me._lbl1BitCom.Text = "&1-Bit Compression"
         ' 
         ' _cb2BitCom
         ' 
         Me._cb2BitCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cb2BitCom.Location = New System.Drawing.Point(19, 110)
         Me._cb2BitCom.Name = "_cb2BitCom"
         Me._cb2BitCom.Size = New System.Drawing.Size(205, 21)
         Me._cb2BitCom.TabIndex = 5
         ' 
         ' _lblPDFCom3
         ' 
         Me._lblPDFCom3.Location = New System.Drawing.Point(19, 94)
         Me._lblPDFCom3.Name = "_lblPDFCom3"
         Me._lblPDFCom3.Size = New System.Drawing.Size(176, 16)
         Me._lblPDFCom3.TabIndex = 4
         Me._lblPDFCom3.Text = "&2-Bit Compression"
         ' 
         ' _txtPDFClrQualityFactor
         ' 
         Me._txtPDFClrQualityFactor.Location = New System.Drawing.Point(168, 63)
         Me._txtPDFClrQualityFactor.MaxLength = 3
         Me._txtPDFClrQualityFactor.Name = "_txtPDFClrQualityFactor"
         Me._txtPDFClrQualityFactor.Size = New System.Drawing.Size(56, 20)
         Me._txtPDFClrQualityFactor.TabIndex = 3
         ' 
         ' _lblPDFCom2
         ' 
         Me._lblPDFCom2.Location = New System.Drawing.Point(22, 64)
         Me._lblPDFCom2.Name = "_lblPDFCom2"
         Me._lblPDFCom2.Size = New System.Drawing.Size(108, 16)
         Me._lblPDFCom2.TabIndex = 2
         Me._lblPDFCom2.Text = "Color &Quality Factor"
         ' 
         ' _cbPicCom
         ' 
         Me._cbPicCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbPicCom.Location = New System.Drawing.Point(19, 35)
         Me._cbPicCom.Name = "_cbPicCom"
         Me._cbPicCom.Size = New System.Drawing.Size(205, 21)
         Me._cbPicCom.TabIndex = 1
         ' 
         ' _lblPDFCom1
         ' 
         Me._lblPDFCom1.Location = New System.Drawing.Point(20, 16)
         Me._lblPDFCom1.Name = "_lblPDFCom1"
         Me._lblPDFCom1.Size = New System.Drawing.Size(176, 16)
         Me._lblPDFCom1.TabIndex = 0
         Me._lblPDFCom1.Text = "&Picture Compression"
         ' 
         ' _tabSegmentation
         ' 
         Me._tabSegmentation.Controls.Add(Me._groupBox2)
         Me._tabSegmentation.Controls.Add(Me._groupBox1)
         Me._tabSegmentation.Location = New System.Drawing.Point(4, 22)
         Me._tabSegmentation.Name = "_tabSegmentation"
         Me._tabSegmentation.Size = New System.Drawing.Size(400, 334)
         Me._tabSegmentation.TabIndex = 2
         Me._tabSegmentation.Text = "Segmentation"
         ' 
         ' _groupBox2
         ' 
         Me._groupBox2.Controls.Add(Me._chckSearchForBackBG)
         Me._groupBox2.Controls.Add(Me._cbTypes)
         Me._groupBox2.Controls.Add(Me._txtClrThreshold)
         Me._groupBox2.Controls.Add(Me._txtQuality)
         Me._groupBox2.Controls.Add(Me._tbClrThreshold)
         Me._groupBox2.Controls.Add(Me._tbQuality)
         Me._groupBox2.Controls.Add(Me._lblSeg6)
         Me._groupBox2.Controls.Add(Me._lblSeg5)
         Me._groupBox2.Controls.Add(Me._lblSeg4)
         Me._groupBox2.Controls.Add(Me._cbOutputImage)
         Me._groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._groupBox2.Location = New System.Drawing.Point(24, 168)
         Me._groupBox2.Name = "_groupBox2"
         Me._groupBox2.Size = New System.Drawing.Size(360, 152)
         Me._groupBox2.TabIndex = 1
         Me._groupBox2.TabStop = False
         Me._groupBox2.Text = "&Output Image Quality"
         ' 
         ' _chckSearchForBackBG
         ' 
         Me._chckSearchForBackBG.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._chckSearchForBackBG.Location = New System.Drawing.Point(200, 120)
         Me._chckSearchForBackBG.Name = "_chckSearchForBackBG"
         Me._chckSearchForBackBG.Size = New System.Drawing.Size(152, 24)
         Me._chckSearchForBackBG.TabIndex = 9
         Me._chckSearchForBackBG.Text = "Searc&h For Background"
         ' 
         ' _cbTypes
         ' 
         Me._cbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbTypes.Location = New System.Drawing.Point(48, 120)
         Me._cbTypes.Name = "_cbTypes"
         Me._cbTypes.Size = New System.Drawing.Size(121, 21)
         Me._cbTypes.TabIndex = 8
         ' 
         ' _txtClrThreshold
         ' 
         Me._txtClrThreshold.Location = New System.Drawing.Point(304, 85)
         Me._txtClrThreshold.Name = "_txtClrThreshold"
         Me._txtClrThreshold.Size = New System.Drawing.Size(48, 20)
         Me._txtClrThreshold.TabIndex = 5
         ' 
         ' _txtQuality
         ' 
         Me._txtQuality.Location = New System.Drawing.Point(304, 55)
         Me._txtQuality.Name = "_txtQuality"
         Me._txtQuality.Size = New System.Drawing.Size(48, 20)
         Me._txtQuality.TabIndex = 2
         ' 
         ' _tbClrThreshold
         ' 
         Me._tbClrThreshold.AutoSize = False
         Me._tbClrThreshold.Location = New System.Drawing.Point(134, 83)
         Me._tbClrThreshold.Maximum = 100
         Me._tbClrThreshold.Name = "_tbClrThreshold"
         Me._tbClrThreshold.Size = New System.Drawing.Size(168, 24)
         Me._tbClrThreshold.TabIndex = 6
         Me._tbClrThreshold.TickStyle = System.Windows.Forms.TickStyle.None
         ' 
         ' _tbQuality
         ' 
         Me._tbQuality.AutoSize = False
         Me._tbQuality.Location = New System.Drawing.Point(134, 54)
         Me._tbQuality.Maximum = 100
         Me._tbQuality.Name = "_tbQuality"
         Me._tbQuality.Size = New System.Drawing.Size(168, 24)
         Me._tbQuality.TabIndex = 3
         Me._tbQuality.TickStyle = System.Windows.Forms.TickStyle.None
         ' 
         ' _lblSeg6
         ' 
         Me._lblSeg6.Location = New System.Drawing.Point(8, 121)
         Me._lblSeg6.Name = "_lblSeg6"
         Me._lblSeg6.Size = New System.Drawing.Size(40, 15)
         Me._lblSeg6.TabIndex = 7
         Me._lblSeg6.Text = "&Type:"
         ' 
         ' _lblSeg5
         ' 
         Me._lblSeg5.Location = New System.Drawing.Point(8, 89)
         Me._lblSeg5.Name = "_lblSeg5"
         Me._lblSeg5.Size = New System.Drawing.Size(100, 15)
         Me._lblSeg5.TabIndex = 4
         Me._lblSeg5.Text = "Co&lor Threshold:"
         ' 
         ' _lblSeg4
         ' 
         Me._lblSeg4.Location = New System.Drawing.Point(8, 57)
         Me._lblSeg4.Name = "_lblSeg4"
         Me._lblSeg4.Size = New System.Drawing.Size(128, 15)
         Me._lblSeg4.TabIndex = 1
         Me._lblSeg4.Text = "&Quality %:"
         ' 
         ' _cbOutputImage
         ' 
         Me._cbOutputImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbOutputImage.Location = New System.Drawing.Point(10, 24)
         Me._cbOutputImage.Name = "_cbOutputImage"
         Me._cbOutputImage.Size = New System.Drawing.Size(156, 21)
         Me._cbOutputImage.TabIndex = 0
         ' 
         ' _groupBox1
         ' 
         Me._groupBox1.Controls.Add(Me._txtCombineThreshold)
         Me._groupBox1.Controls.Add(Me._txtCleanSize)
         Me._groupBox1.Controls.Add(Me._txtBgThreshold)
         Me._groupBox1.Controls.Add(Me._tbCombineThreshold)
         Me._groupBox1.Controls.Add(Me._tbCleanSize)
         Me._groupBox1.Controls.Add(Me._tbBgThreshold)
         Me._groupBox1.Controls.Add(Me._lblSeg3)
         Me._groupBox1.Controls.Add(Me._lblSeg2)
         Me._groupBox1.Controls.Add(Me._lblSeg1)
         Me._groupBox1.Controls.Add(Me._cbInputImage)
         Me._groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._groupBox1.Location = New System.Drawing.Point(24, 16)
         Me._groupBox1.Name = "_groupBox1"
         Me._groupBox1.Size = New System.Drawing.Size(360, 152)
         Me._groupBox1.TabIndex = 0
         Me._groupBox1.TabStop = False
         Me._groupBox1.Text = "&Input Image Quality"
         ' 
         ' _txtCombineThreshold
         ' 
         Me._txtCombineThreshold.Location = New System.Drawing.Point(304, 117)
         Me._txtCombineThreshold.Name = "_txtCombineThreshold"
         Me._txtCombineThreshold.Size = New System.Drawing.Size(48, 20)
         Me._txtCombineThreshold.TabIndex = 8
         ' 
         ' _txtCleanSize
         ' 
         Me._txtCleanSize.Location = New System.Drawing.Point(304, 85)
         Me._txtCleanSize.Name = "_txtCleanSize"
         Me._txtCleanSize.Size = New System.Drawing.Size(48, 20)
         Me._txtCleanSize.TabIndex = 5
         ' 
         ' _txtBgThreshold
         ' 
         Me._txtBgThreshold.Location = New System.Drawing.Point(304, 55)
         Me._txtBgThreshold.Name = "_txtBgThreshold"
         Me._txtBgThreshold.Size = New System.Drawing.Size(48, 20)
         Me._txtBgThreshold.TabIndex = 2
         ' 
         ' _tbCombineThreshold
         ' 
         Me._tbCombineThreshold.AutoSize = False
         Me._tbCombineThreshold.Location = New System.Drawing.Point(133, 116)
         Me._tbCombineThreshold.Maximum = 300
         Me._tbCombineThreshold.Name = "_tbCombineThreshold"
         Me._tbCombineThreshold.Size = New System.Drawing.Size(168, 24)
         Me._tbCombineThreshold.TabIndex = 9
         Me._tbCombineThreshold.TickStyle = System.Windows.Forms.TickStyle.None
         ' 
         ' _tbCleanSize
         ' 
         Me._tbCleanSize.AutoSize = False
         Me._tbCleanSize.Location = New System.Drawing.Point(134, 83)
         Me._tbCleanSize.Name = "_tbCleanSize"
         Me._tbCleanSize.Size = New System.Drawing.Size(168, 24)
         Me._tbCleanSize.TabIndex = 6
         Me._tbCleanSize.TickStyle = System.Windows.Forms.TickStyle.None
         ' 
         ' _tbBgThreshold
         ' 
         Me._tbBgThreshold.AutoSize = False
         Me._tbBgThreshold.Location = New System.Drawing.Point(134, 54)
         Me._tbBgThreshold.Maximum = 100
         Me._tbBgThreshold.Name = "_tbBgThreshold"
         Me._tbBgThreshold.Size = New System.Drawing.Size(168, 24)
         Me._tbBgThreshold.TabIndex = 3
         Me._tbBgThreshold.TickStyle = System.Windows.Forms.TickStyle.None
         ' 
         ' _lblSeg3
         ' 
         Me._lblSeg3.Location = New System.Drawing.Point(8, 121)
         Me._lblSeg3.Name = "_lblSeg3"
         Me._lblSeg3.Size = New System.Drawing.Size(112, 15)
         Me._lblSeg3.TabIndex = 7
         Me._lblSeg3.Text = "Co&mbine Threshold:"
         ' 
         ' _lblSeg2
         ' 
         Me._lblSeg2.Location = New System.Drawing.Point(8, 89)
         Me._lblSeg2.Name = "_lblSeg2"
         Me._lblSeg2.Size = New System.Drawing.Size(100, 15)
         Me._lblSeg2.TabIndex = 4
         Me._lblSeg2.Text = "Clean Si&ze:"
         ' 
         ' _lblSeg1
         ' 
         Me._lblSeg1.Location = New System.Drawing.Point(8, 57)
         Me._lblSeg1.Name = "_lblSeg1"
         Me._lblSeg1.Size = New System.Drawing.Size(128, 15)
         Me._lblSeg1.TabIndex = 1
         Me._lblSeg1.Text = "&Background Threshold:"
         ' 
         ' _cbInputImage
         ' 
         Me._cbInputImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbInputImage.Location = New System.Drawing.Point(12, 22)
         Me._cbInputImage.Name = "_cbInputImage"
         Me._cbInputImage.Size = New System.Drawing.Size(156, 21)
         Me._cbInputImage.TabIndex = 0
         ' 
         ' tabCombine
         ' 
         Me.tabCombine.Controls.Add(Me._cbCombiningType)
         Me.tabCombine.Controls.Add(Me._txtCombiningFactor)
         Me.tabCombine.Controls.Add(Me._tbCombiningFactor)
         Me.tabCombine.Controls.Add(Me._lblCombine2)
         Me.tabCombine.Controls.Add(Me._lblCombine1)
         Me.tabCombine.Location = New System.Drawing.Point(4, 22)
         Me.tabCombine.Name = "tabCombine"
         Me.tabCombine.Size = New System.Drawing.Size(400, 334)
         Me.tabCombine.TabIndex = 3
         Me.tabCombine.Text = "Combine"
         ' 
         ' _cbCombiningType
         ' 
         Me._cbCombiningType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbCombiningType.Location = New System.Drawing.Point(153, 56)
         Me._cbCombiningType.Name = "_cbCombiningType"
         Me._cbCombiningType.Size = New System.Drawing.Size(121, 21)
         Me._cbCombiningType.TabIndex = 4
         ' 
         ' _txtCombiningFactor
         ' 
         Me._txtCombiningFactor.Location = New System.Drawing.Point(320, 24)
         Me._txtCombiningFactor.Name = "_txtCombiningFactor"
         Me._txtCombiningFactor.Size = New System.Drawing.Size(48, 20)
         Me._txtCombiningFactor.TabIndex = 1
         ' 
         ' _tbCombiningFactor
         ' 
         Me._tbCombiningFactor.AutoSize = False
         Me._tbCombiningFactor.Location = New System.Drawing.Point(144, 24)
         Me._tbCombiningFactor.Maximum = 100
         Me._tbCombiningFactor.Name = "_tbCombiningFactor"
         Me._tbCombiningFactor.Size = New System.Drawing.Size(168, 24)
         Me._tbCombiningFactor.TabIndex = 2
         Me._tbCombiningFactor.TickStyle = System.Windows.Forms.TickStyle.None
         ' 
         ' _lblCombine2
         ' 
         Me._lblCombine2.Location = New System.Drawing.Point(24, 56)
         Me._lblCombine2.Name = "_lblCombine2"
         Me._lblCombine2.Size = New System.Drawing.Size(88, 15)
         Me._lblCombine2.TabIndex = 3
         Me._lblCombine2.Text = "Combining &Type"
         ' 
         ' _lblCombine1
         ' 
         Me._lblCombine1.Location = New System.Drawing.Point(24, 24)
         Me._lblCombine1.Name = "_lblCombine1"
         Me._lblCombine1.Size = New System.Drawing.Size(100, 15)
         Me._lblCombine1.TabIndex = 0
         Me._lblCombine1.Text = "Combining &Factor"
         ' 
         ' tabColors
         ' 
         Me.tabColors.Controls.Add(Me._btnFGClr)
         Me.tabColors.Controls.Add(Me._lblForegroundClr)
         Me.tabColors.Controls.Add(Me._btnBGClr)
         Me.tabColors.Controls.Add(Me._lblBackgroundClr)
         Me.tabColors.Location = New System.Drawing.Point(4, 22)
         Me.tabColors.Name = "tabColors"
         Me.tabColors.Size = New System.Drawing.Size(400, 334)
         Me.tabColors.TabIndex = 4
         Me.tabColors.Text = "Colors"
         ' 
         ' _btnFGClr
         ' 
         Me._btnFGClr.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnFGClr.Location = New System.Drawing.Point(192, 24)
         Me._btnFGClr.Name = "_btnFGClr"
         Me._btnFGClr.Size = New System.Drawing.Size(80, 32)
         Me._btnFGClr.TabIndex = 2
         Me._btnFGClr.Text = "&Foreground"
         ' 
         ' _lblForegroundClr
         ' 
         Me._lblForegroundClr.BackColor = System.Drawing.Color.Black
         Me._lblForegroundClr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._lblForegroundClr.Location = New System.Drawing.Point(192, 64)
         Me._lblForegroundClr.Name = "_lblForegroundClr"
         Me._lblForegroundClr.Size = New System.Drawing.Size(80, 32)
         Me._lblForegroundClr.TabIndex = 3
         ' 
         ' _btnBGClr
         ' 
         Me._btnBGClr.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnBGClr.Location = New System.Drawing.Point(104, 24)
         Me._btnBGClr.Name = "_btnBGClr"
         Me._btnBGClr.Size = New System.Drawing.Size(80, 32)
         Me._btnBGClr.TabIndex = 0
         Me._btnBGClr.Text = "&Background"
         ' 
         ' _lblBackgroundClr
         ' 
         Me._lblBackgroundClr.BackColor = System.Drawing.Color.White
         Me._lblBackgroundClr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._lblBackgroundClr.Location = New System.Drawing.Point(104, 64)
         Me._lblBackgroundClr.Name = "_lblBackgroundClr"
         Me._lblBackgroundClr.Size = New System.Drawing.Size(80, 32)
         Me._lblBackgroundClr.TabIndex = 1
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(128, 376)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(75, 23)
         Me._btnOk.TabIndex = 1
         Me._btnOk.Text = "&Ok"
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(224, 376)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "&Cancel"
         ' 
         ' Options
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(426, 407)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me.tanctrlOptions)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "Options"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Options"
         Me.tanctrlOptions.ResumeLayout(False)
         Me.tabMrcCompressions.ResumeLayout(False)
         Me.tabMrcCompressions.PerformLayout()
         Me.tabPDFCompressions.ResumeLayout(False)
         Me.tabPDFCompressions.PerformLayout()
         Me._tabSegmentation.ResumeLayout(False)
         Me._groupBox2.ResumeLayout(False)
         Me._groupBox2.PerformLayout()
         CType(Me._tbClrThreshold, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._tbQuality, System.ComponentModel.ISupportInitialize).EndInit()
         Me._groupBox1.ResumeLayout(False)
         Me._groupBox1.PerformLayout()
         CType(Me._tbCombineThreshold, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._tbCleanSize, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._tbBgThreshold, System.ComponentModel.ISupportInitialize).EndInit()
         Me.tabCombine.ResumeLayout(False)
         Me.tabCombine.PerformLayout()
         CType(Me._tbCombiningFactor, System.ComponentModel.ISupportInitialize).EndInit()
         Me.tabColors.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
#End Region

      Public backgroundColor As Color
      Public foregroundColor As Color

      '    Mrc:
      Public tempPictureCoder As Integer
      Public tempGrayscaleCoder8Bit As Integer
      Public tempTextCoder2Bit As Integer
      Public tempGrayscaleCoder2Bit As Integer
      Public tempMaskCode As Integer
      Public tempQFactor As Integer
      Public tempGSQFactor As Integer

      '    PDF:
      Public tempPDFPictureCoder As Integer
      Public tempPDFTextCoder2Bit As Integer
      Public tempPDFMaskCoder As Integer
      Public tempPDFQFactor As Integer

      '    Segmentation
      Public tempInputImageType As Integer
      Public tempOutputImageType As Integer

      Public tempBGThreshold As Integer
      Public tempCleanSize As Integer
      Public tempCombineThreshold As Integer
      Public tempQuality As Integer
      Public tempClrThreshold As Integer
      Public tempTypeIndex As Integer
      Public tempCheck As Boolean

      Public tempUserDefineBGThreshold As Integer
      Public tempUserDefineCleanSize As Integer
      Public tempUserDefineCombineThreshold As Integer
      Public tempUserDefineQuality As Integer
      Public tempUserDefineClrThreshold As Integer
      Public tempUserDefineTypeIndex As Integer
      Public tempUserDefineCheck As Boolean

      '    Combine
      Public tempCombineType As Integer
      Public tempCombineFactor As Integer

      Private Sub FillControls()
         '    Mrc: 24-Bit Color Picture Compression
         _cb24BitClrPicCom.Items.Add("Wavelet CMW")
         _cb24BitClrPicCom.Items.Add("Lossless Wavelet CMW")
         _cb24BitClrPicCom.Items.Add("LEAD CMP")
         _cb24BitClrPicCom.Items.Add("JPEG")
         _cb24BitClrPicCom.Items.Add("Lossless JPEG")
         _cb24BitClrPicCom.Items.Add("JPEG YUV 4:2:2")
         _cb24BitClrPicCom.Items.Add("JPEG YUV 4:1:1")
         _cb24BitClrPicCom.Items.Add("JPEG Progressive")
         _cb24BitClrPicCom.Items.Add("JPEG Progressive YUV 4:2:2")
         _cb24BitClrPicCom.Items.Add("JPEG Progressive YUV 4:1:1")

         '    Mrc: 8-Bit Grayscale Compression
         _cb8BitGrayCom.Items.Add("Lossless CMW 8-bit")
         _cb8BitGrayCom.Items.Add("Grayscale CMW 8-bit")
         _cb8BitGrayCom.Items.Add("Grayscale CMP 8-bit")
         _cb8BitGrayCom.Items.Add("Lossless JPEG 8-bit")
         _cb8BitGrayCom.Items.Add("Grayscale JPEG 8-bit")
         _cb8BitGrayCom.Items.Add("Grayscale JPEG Progressive 8-bit")

         '    Mrc: 2-Bit Text Colored Compression
         _cb2BitTxtClrCom.Items.Add("Text JBIG 2-bit")
         _cb2BitTxtClrCom.Items.Add("Text GIF 2-bit")

         '    Mrc: 2-Bit Grayscale Compression
         _cb2BitGrayscaleCom.Items.Add("Grayscale JBIG 2-bit")

         '    Mrc: 1-Bit Text/Mask Compression
         _cb1BitTxtMaskCom.Items.Add("JBIG")
         _cb1BitTxtMaskCom.Items.Add("Fax G4")
         _cb1BitTxtMaskCom.Items.Add("Fax G3(1D)")
         _cb1BitTxtMaskCom.Items.Add("Fax G3(2D)")

         '    PDF: Picture Compression
         _cbPicCom.Items.Add("JPEG")
         _cbPicCom.Items.Add("JPEG YUV 4:2:2")
         _cbPicCom.Items.Add("JPEG YUV 4:1:1")
         _cbPicCom.Items.Add("JPEG Progressive")
         _cbPicCom.Items.Add("JPEG Progressive YUV 4:2:2")
         _cbPicCom.Items.Add("ZIP")
         _cbPicCom.Items.Add("LZW")

         '    PDF: 2-Bit Compression
         _cb2BitCom.Items.Add("ZIP 2-bit")
         _cb2BitCom.Items.Add("LZW 2-bit")

         '    PDF: 1-Bit Compression
         _cb1BitCom.Items.Add("ZIP 1-bit")
         _cb1BitCom.Items.Add("LZW 1-bit")
         _cb1BitCom.Items.Add("Fax G3(1D)")
         _cb1BitCom.Items.Add("Fax G3(2D)")
         _cb1BitCom.Items.Add("Fax G4")
         _cb1BitCom.Items.Add("JBIG2")

         '    Segmentation: Input Image Quality
         _cbInputImage.Items.Add("Auto Select")
         _cbInputImage.Items.Add("Noisy Image")
         _cbInputImage.Items.Add("Scanned Image")
         _cbInputImage.Items.Add("Printed Image")
         _cbInputImage.Items.Add("Computer Generated Image")
         _cbInputImage.Items.Add("Photo")
         _cbInputImage.Items.Add("User Defined")

         '    Segmentation: Output Image Quality
         _cbOutputImage.Items.Add("Auto Select")
         _cbOutputImage.Items.Add("Poor Quality")
         _cbOutputImage.Items.Add("Average Quality")
         _cbOutputImage.Items.Add("Good Quality")
         _cbOutputImage.Items.Add("Excellent Quality")
         _cbOutputImage.Items.Add("User Defined")

         '    Segmentation: Type
         _cbTypes.Items.Add("Favor 1 bit segments")
         _cbTypes.Items.Add("Favor 2 bit segments")
         _cbTypes.Items.Add("Force 1 bit segments")
         _cbTypes.Items.Add("Force 2 bit segments")

         '    Combine: Combining Type
         _cbCombiningType.Items.Add("Force")
         _cbCombiningType.Items.Add("Force Similar")
         _cbCombiningType.Items.Add("Try")
      End Sub

      Private Sub InputImageEnables(ByVal enable As Boolean)
         '    Enable Text boxes...
         _txtBgThreshold.Enabled = enable
         _txtCleanSize.Enabled = enable
         _txtCombineThreshold.Enabled = enable

         '    Enable Scrolls...
         _tbBgThreshold.Enabled = enable
         _tbCleanSize.Enabled = enable
         _tbCombineThreshold.Enabled = enable
      End Sub

      Private Sub OutputImageEnables(ByVal enable As Boolean)
         '    Enable Text boxes...
         _txtQuality.Enabled = enable
         _txtClrThreshold.Enabled = enable

         '    Enable Scrolls...
         _tbQuality.Enabled = enable
         _tbClrThreshold.Enabled = enable

         '    Enable Combo boxes...
         _cbTypes.Enabled = enable

         '    Enable Check Boxes...
         _chckSearchForBackBG.Enabled = enable
      End Sub

      Public Sub SetSelections()
         '    Mrc:
         _cb24BitClrPicCom.SelectedIndex = tempPictureCoder
         _cb8BitGrayCom.SelectedIndex = tempGrayscaleCoder8Bit
         _cb2BitTxtClrCom.SelectedIndex = tempTextCoder2Bit
         _cb2BitGrayscaleCom.SelectedIndex = tempGrayscaleCoder2Bit
         _cb1BitTxtMaskCom.SelectedIndex = tempMaskCode
         _txtMrcClrQualityFactor.Text = tempQFactor.ToString()
         _txtGrayscaleFactor.Text = tempGSQFactor.ToString()

         '    PDF:
         _cbPicCom.SelectedIndex = tempPDFPictureCoder
         _cb2BitCom.SelectedIndex = tempPDFTextCoder2Bit
         _cb1BitCom.SelectedIndex = tempPDFMaskCoder
         _txtPDFClrQualityFactor.Text = tempPDFQFactor.ToString()

         '    Segmentation
         _cbInputImage.SelectedIndex = tempInputImageType
         _cbOutputImage.SelectedIndex = tempOutputImageType

         If tempInputImageType <> 6 Then
            _txtBgThreshold.Text = tempBGThreshold.ToString()
            _txtCleanSize.Text = tempCleanSize.ToString()
            _txtCombineThreshold.Text = tempCombineThreshold.ToString()
            _txtQuality.Text = tempQuality.ToString()
            _txtClrThreshold.Text = tempClrThreshold.ToString()
            _cbTypes.SelectedIndex = tempTypeIndex
            _chckSearchForBackBG.Checked = tempCheck
         Else
            _txtBgThreshold.Text = tempUserDefineBGThreshold.ToString()
            _txtCleanSize.Text = tempUserDefineCleanSize.ToString()
            _txtCombineThreshold.Text = tempUserDefineCombineThreshold.ToString()
            _txtQuality.Text = tempUserDefineQuality.ToString()
            _txtClrThreshold.Text = tempUserDefineClrThreshold.ToString()
            _cbTypes.SelectedIndex = tempUserDefineTypeIndex
            _chckSearchForBackBG.Checked = tempUserDefineCheck
         End If

         '    Combine
         _cbCombiningType.SelectedIndex = tempCombineType
         _txtCombiningFactor.Text = tempCombineFactor.ToString()
      End Sub

      Private Sub Options_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         _lblBackgroundClr.BackColor = Color.FromArgb(backgroundColor.R, backgroundColor.G, backgroundColor.B)
         _lblForegroundClr.BackColor = Color.FromArgb(foregroundColor.R, foregroundColor.G, foregroundColor.B)
      End Sub


      '    Click Functions...
      Private Sub _btnBGClr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnBGClr.Click
         Dim colorDlg As ColorDialog = New ColorDialog()

         colorDlg.Color = backgroundColor
         If colorDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _lblBackgroundClr.BackColor = colorDlg.Color
            backgroundColor = colorDlg.Color
         End If
      End Sub

      Private Sub _btnFGClr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnFGClr.Click
         Dim colorDlg As ColorDialog = New ColorDialog()

         colorDlg.Color = foregroundColor
         If colorDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _lblForegroundClr.BackColor = colorDlg.Color
            foregroundColor = colorDlg.Color
         End If
      End Sub


      '    SelectedIndexChanged Functions...
      Private Sub _cb24BitClrPicCom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cb24BitClrPicCom.SelectedIndexChanged
         Select Case _cb24BitClrPicCom.SelectedIndex
            Case 1, 4
               _txtMrcClrQualityFactor.Enabled = False
            Case Else
               _txtMrcClrQualityFactor.Enabled = True
         End Select

         tempPictureCoder = _cb24BitClrPicCom.SelectedIndex
      End Sub

      Private Sub _cb8BitGrayCom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cb8BitGrayCom.SelectedIndexChanged
         Select Case _cb8BitGrayCom.SelectedIndex
            Case 0, 3
               _txtGrayscaleFactor.Enabled = False
            Case Else
               _txtGrayscaleFactor.Enabled = True
         End Select

         tempGrayscaleCoder8Bit = _cb8BitGrayCom.SelectedIndex
      End Sub

      Private Sub _cb2BitTxtClrCom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cb2BitTxtClrCom.SelectedIndexChanged
         tempTextCoder2Bit = _cb2BitTxtClrCom.SelectedIndex
      End Sub

      Private Sub _cb2BitGrayscaleCom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cb2BitGrayscaleCom.SelectedIndexChanged
         tempGrayscaleCoder2Bit = _cb2BitGrayscaleCom.SelectedIndex
      End Sub

      Private Sub _cb1BitTxtMaskCom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cb1BitTxtMaskCom.SelectedIndexChanged
         tempMaskCode = _cb1BitTxtMaskCom.SelectedIndex
      End Sub

      Private Sub _cbPicCom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbPicCom.SelectedIndexChanged
         Select Case _cbPicCom.SelectedIndex
            Case 6, 7
               _txtPDFClrQualityFactor.Enabled = False
            Case Else
               _txtPDFClrQualityFactor.Enabled = True
         End Select

         tempPDFPictureCoder = _cbPicCom.SelectedIndex
      End Sub

      Private Sub _cb2BitCom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cb2BitCom.SelectedIndexChanged
         tempPDFTextCoder2Bit = _cb2BitCom.SelectedIndex
      End Sub

      Private Sub _cb1BitCom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cb1BitCom.SelectedIndexChanged
         tempPDFMaskCoder = _cb1BitCom.SelectedIndex
      End Sub

      Private Sub _cbInputImage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbInputImage.SelectedIndexChanged
         Dim enableControls As Boolean = False
         tempInputImageType = _cbInputImage.SelectedIndex

         Select Case _cbInputImage.SelectedIndex
            Case 0
               tempBGThreshold = 15
               tempCleanSize = 7
               tempCombineThreshold = 100
            Case 1
               tempBGThreshold = 25
               tempCleanSize = 10
               tempCombineThreshold = 125
            Case 2
               tempBGThreshold = 15
               tempCleanSize = 8
               tempCombineThreshold = 100
            Case 3
               tempBGThreshold = 10
               tempCleanSize = 7
               tempCombineThreshold = 100
            Case 4
               tempBGThreshold = 10
               tempCleanSize = 3
               tempCombineThreshold = 75
            Case 5
               tempBGThreshold = 0
               tempCleanSize = 3
               tempCombineThreshold = 75
            Case Else
               tempBGThreshold = tempUserDefineBGThreshold
               tempCleanSize = tempUserDefineCleanSize
               tempCombineThreshold = tempUserDefineCombineThreshold

               enableControls = True

         End Select
         _txtBgThreshold.Text = tempBGThreshold.ToString()
         _txtCleanSize.Text = tempCleanSize.ToString()
         _txtCombineThreshold.Text = tempCombineThreshold.ToString()

         InputImageEnables(enableControls)
      End Sub

      Private Sub _cbOutputImage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbOutputImage.SelectedIndexChanged
         Dim enableControls As Boolean = False
         tempOutputImageType = _cbOutputImage.SelectedIndex

         Select Case _cbOutputImage.SelectedIndex
            Case 0
               tempQuality = 50
               tempClrThreshold = 25
               _cbTypes.SelectedIndex = 1
               _chckSearchForBackBG.Checked = False
            Case 1
               tempQuality = 0
               tempClrThreshold = 30
               _cbTypes.SelectedIndex = 2
               _chckSearchForBackBG.Checked = True
            Case 2
               tempQuality = 50
               tempClrThreshold = 25
               _cbTypes.SelectedIndex = 0
               _chckSearchForBackBG.Checked = True
            Case 3
               tempQuality = 75
               tempClrThreshold = 25
               _cbTypes.SelectedIndex = 1
               _chckSearchForBackBG.Checked = False
            Case 4
               tempQuality = 100
               tempClrThreshold = 25
               _cbTypes.SelectedIndex = 3
               _chckSearchForBackBG.Checked = False
            Case Else
               tempQuality = tempUserDefineQuality
               tempClrThreshold = tempUserDefineClrThreshold
               _cbTypes.SelectedIndex = tempUserDefineTypeIndex
               _chckSearchForBackBG.Checked = tempUserDefineCheck

               enableControls = True
         End Select
         _txtQuality.Text = tempQuality.ToString()
         _txtClrThreshold.Text = tempClrThreshold.ToString()
         tempTypeIndex = _cbTypes.SelectedIndex
         tempCheck = _chckSearchForBackBG.Checked

         OutputImageEnables(enableControls)
      End Sub

      Private Sub _cbTypes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbTypes.SelectedIndexChanged
         tempUserDefineTypeIndex = _cbTypes.SelectedIndex
      End Sub

      Private Sub _cbCombiningType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbCombiningType.SelectedIndexChanged
         tempCombineType = _cbCombiningType.SelectedIndex
      End Sub


      '    TextChanged Functions...
      Private Sub _txtBgThreshold_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtBgThreshold.TextChanged
         If tempInputImageType = 6 Then
            If _txtBgThreshold.Text.Length = 0 Then
               _txtBgThreshold.Text = "0"
            End If

            tempUserDefineBGThreshold = Math.Max(0, Math.Min(Int32.Parse(_txtBgThreshold.Text), 100))
            _txtBgThreshold.Text = tempUserDefineBGThreshold.ToString()
            _txtBgThreshold.SelectionStart = _txtBgThreshold.Text.Length

            _tbBgThreshold.Value = tempUserDefineBGThreshold
         Else
            If _txtBgThreshold.Text.Length = 0 Then
               _txtBgThreshold.Text = "0"
            End If

            tempBGThreshold = Math.Max(0, Math.Min(Int32.Parse(_txtBgThreshold.Text), 100))
            _txtBgThreshold.Text = tempBGThreshold.ToString()
            _txtBgThreshold.SelectionStart = _txtBgThreshold.Text.Length

            _tbBgThreshold.Value = tempBGThreshold
         End If
      End Sub

      Private Sub _txtCleanSize_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCleanSize.TextChanged
         If tempInputImageType = 6 Then
            If _txtCleanSize.Text.Length = 0 Then
               _txtCleanSize.Text = "0"
            End If

            tempUserDefineCleanSize = Math.Max(0, Math.Min(Int32.Parse(_txtCleanSize.Text), 10))
            _txtCleanSize.Text = tempUserDefineCleanSize.ToString()
            _txtCleanSize.SelectionStart = _txtCleanSize.Text.Length

            _tbCleanSize.Value = tempUserDefineCleanSize
         Else
            If _txtCleanSize.Text.Length = 0 Then
               _txtCleanSize.Text = "0"
            End If

            tempCleanSize = Math.Max(0, Math.Min(Int32.Parse(_txtCleanSize.Text), 10))
            _txtCleanSize.Text = tempCleanSize.ToString()
            _txtCleanSize.SelectionStart = _txtCleanSize.Text.Length

            _tbCleanSize.Value = tempCleanSize
         End If
      End Sub

      Private Sub _txtCombineThreshold_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCombineThreshold.TextChanged
         If tempInputImageType = 6 Then
            If _txtCombineThreshold.Text.Length = 0 Then
               _txtCombineThreshold.Text = "0"
            End If

            tempUserDefineCombineThreshold = Math.Max(0, Math.Min(Int32.Parse(_txtCombineThreshold.Text), 300))
            _txtCombineThreshold.Text = tempUserDefineCombineThreshold.ToString()
            _txtCombineThreshold.SelectionStart = _txtCombineThreshold.Text.Length

            _tbCombineThreshold.Value = tempUserDefineCombineThreshold
         Else
            If _txtCombineThreshold.Text.Length = 0 Then
               _txtCombineThreshold.Text = "0"
            End If

            tempCombineThreshold = Math.Max(0, Math.Min(Int32.Parse(_txtCombineThreshold.Text), 300))
            _txtCombineThreshold.Text = tempCombineThreshold.ToString()
            _txtCombineThreshold.SelectionStart = _txtCombineThreshold.Text.Length

            _tbCombineThreshold.Value = tempCombineThreshold
         End If
      End Sub

      Private Sub _txtQuality_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtQuality.TextChanged
         If tempOutputImageType = 5 Then
            If _txtQuality.Text.Length = 0 Then
               _txtQuality.Text = "0"
            End If

            tempUserDefineQuality = Math.Max(0, Math.Min(Int32.Parse(_txtQuality.Text), 100))
            _txtQuality.Text = tempUserDefineQuality.ToString()
            _txtQuality.SelectionStart = _txtQuality.Text.Length

            _tbQuality.Value = tempUserDefineQuality
         Else
            If _txtQuality.Text.Length = 0 Then
               _txtQuality.Text = "0"
            End If

            tempQuality = Math.Max(0, Math.Min(Int32.Parse(_txtQuality.Text), 100))
            _txtQuality.Text = tempQuality.ToString()
            _txtQuality.SelectionStart = _txtQuality.Text.Length

            _tbQuality.Value = tempQuality
         End If
      End Sub

      Private Sub _txtClrThreshold_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtClrThreshold.TextChanged
         If tempOutputImageType = 5 Then
            If _txtClrThreshold.Text.Length = 0 Then
               _txtClrThreshold.Text = "0"
            End If

            tempUserDefineClrThreshold = Math.Max(0, Math.Min(Int32.Parse(_txtClrThreshold.Text), 100))
            _txtClrThreshold.Text = tempUserDefineClrThreshold.ToString()
            _txtClrThreshold.SelectionStart = _txtClrThreshold.Text.Length

            _tbClrThreshold.Value = tempUserDefineClrThreshold
         Else
            If _txtClrThreshold.Text.Length = 0 Then
               _txtClrThreshold.Text = "0"
            End If

            tempClrThreshold = Math.Max(0, Math.Min(Int32.Parse(_txtClrThreshold.Text), 100))
            _txtClrThreshold.Text = tempClrThreshold.ToString()
            _txtClrThreshold.SelectionStart = _txtClrThreshold.Text.Length

            _tbClrThreshold.Value = tempClrThreshold
         End If
      End Sub

      Private Sub _txtCombiningFactor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCombiningFactor.TextChanged
         If _txtCombiningFactor.Text.Length = 0 Then
            _txtCombiningFactor.Text = "0"
         End If

         tempCombineFactor = Math.Max(0, Math.Min(Int32.Parse(_txtCombiningFactor.Text), 100))
         _txtCombiningFactor.Text = tempCombineFactor.ToString()
         _txtCombiningFactor.SelectionStart = _txtCombiningFactor.Text.Length

         _tbCombiningFactor.Value = tempCombineFactor
      End Sub


      '    Scroll Functions...
      Private Sub _tbbgThreshold_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles _tbBgThreshold.Scroll
         _txtBgThreshold.Text = _tbBgThreshold.Value.ToString()
      End Sub

      Private Sub _tbCleanSize_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles _tbCleanSize.Scroll
         _txtCleanSize.Text = _tbCleanSize.Value.ToString()
      End Sub

      Private Sub _tbCombineThreshold_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles _tbCombineThreshold.Scroll
         _txtCombineThreshold.Text = _tbCombineThreshold.Value.ToString()
      End Sub

      Private Sub _tbQuality_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles _tbQuality.Scroll
         _txtQuality.Text = _tbQuality.Value.ToString()
      End Sub

      Private Sub _tbClrThreshold_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles _tbClrThreshold.Scroll
         _txtClrThreshold.Text = _tbClrThreshold.Value.ToString()
      End Sub

      Private Sub _tbCombiningFactor_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles _tbCombiningFactor.Scroll
         _txtCombiningFactor.Text = _tbCombiningFactor.Value.ToString()
      End Sub


      '    CheckedChanged Functions...
      Private Sub _chckSearchForBackBG_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _chckSearchForBackBG.CheckedChanged
         tempUserDefineCheck = _chckSearchForBackBG.Checked
      End Sub

      '    Key Press Function...
      Private Sub _txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _txtGrayscaleFactor.KeyPress, _txtMrcClrQualityFactor.KeyPress, _txtPDFClrQualityFactor.KeyPress, _txtClrThreshold.KeyPress, _txtQuality.KeyPress, _txtCombineThreshold.KeyPress, _txtCleanSize.KeyPress, _txtBgThreshold.KeyPress, _txtCombiningFactor.KeyPress
         If (Not Char.IsNumber(e.KeyChar)) AndAlso (Not Char.IsControl(e.KeyChar)) Then
            e.Handled = True
         End If
      End Sub

      Private Sub tanctrlOptions_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tanctrlOptions.KeyDown
         If (Not e.Handled) Then
            If e.KeyCode = Keys.Escape Then
               e.Handled = True

               _btnCancel_Click(_btnCancel, Nothing)
            End If
         End If
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
         Close()
      End Sub

      Private Sub _txtMrcClrQualityFactor_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _txtMrcClrQualityFactor.Leave
         If _txtMrcClrQualityFactor.Text.Length = 0 Then
            _txtMrcClrQualityFactor.Text = "2"
         End If

         tempQFactor = Math.Max(2, Math.Min(Int32.Parse(_txtMrcClrQualityFactor.Text), 255))
         _txtMrcClrQualityFactor.Text = tempQFactor.ToString()
         _txtMrcClrQualityFactor.SelectionStart = _txtMrcClrQualityFactor.Text.Length
      End Sub

      Private Sub _txtGrayscaleFactor_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _txtGrayscaleFactor.Leave
         If _txtGrayscaleFactor.Text.Length = 0 Then
            _txtGrayscaleFactor.Text = "2"
         End If

         tempGSQFactor = Math.Max(2, Math.Min(Int32.Parse(_txtGrayscaleFactor.Text), 255))
         _txtGrayscaleFactor.Text = tempGSQFactor.ToString()
         _txtGrayscaleFactor.SelectionStart = _txtGrayscaleFactor.Text.Length
      End Sub

      Private Sub _txtPDFClrQualityFactor_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _txtPDFClrQualityFactor.Leave
         If _txtPDFClrQualityFactor.Text.Length = 0 Then
            _txtPDFClrQualityFactor.Text = "2"
         End If

         tempPDFQFactor = Math.Max(2, Math.Min(Int32.Parse(_txtPDFClrQualityFactor.Text), 255))
         _txtPDFClrQualityFactor.Text = tempPDFQFactor.ToString()
         _txtPDFClrQualityFactor.SelectionStart = _txtPDFClrQualityFactor.Text.Length
      End Sub
   End Class
End Namespace
