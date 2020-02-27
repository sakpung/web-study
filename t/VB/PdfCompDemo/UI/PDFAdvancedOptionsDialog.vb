' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

''' <summary>
''' Summary description for PdfAdvancedOptionsDialog.
''' </summary>
Public Class PdfAdvancedOptionsDialog : Inherits System.Windows.Forms.Form
   Private _gbCompressionTypes As System.Windows.Forms.GroupBox
   Private _lblBestQuality As System.Windows.Forms.Label
   Private _lblBestCompression As System.Windows.Forms.Label
   Private _cmboSegmentationOptions As System.Windows.Forms.ComboBox
   Private _cbSearchForBackground As System.Windows.Forms.CheckBox
   Private _lblSegmentationOptions As System.Windows.Forms.Label
   Private _gbSegmentationOptions As System.Windows.Forms.GroupBox
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOK As System.Windows.Forms.Button
   Private _lblPictures As Label
   Private _lbl1BPPImages As Label
   Private _lbl2BPPImages As Label
   Private _cmbo1BPPImages As ComboBox
   Private _cmbo2BPPImages As ComboBox
   Private _trkbQFactor As TrackBar
   Private WithEvents _cmboPictures As ComboBox
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
      Me._cmboSegmentationOptions = New System.Windows.Forms.ComboBox()
      Me._cbSearchForBackground = New System.Windows.Forms.CheckBox()
      Me._lblSegmentationOptions = New System.Windows.Forms.Label()
      Me._gbSegmentationOptions = New System.Windows.Forms.GroupBox()
      Me._gbCompressionTypes = New System.Windows.Forms.GroupBox()
      Me._lblBestCompression = New System.Windows.Forms.Label()
      Me._lblBestQuality = New System.Windows.Forms.Label()
      Me._lblPictures = New System.Windows.Forms.Label()
      Me._lbl1BPPImages = New System.Windows.Forms.Label()
      Me._lbl2BPPImages = New System.Windows.Forms.Label()
      Me._cmbo1BPPImages = New System.Windows.Forms.ComboBox()
      Me._cmbo2BPPImages = New System.Windows.Forms.ComboBox()
      Me._trkbQFactor = New System.Windows.Forms.TrackBar()
      Me._cmboPictures = New System.Windows.Forms.ComboBox()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOK = New System.Windows.Forms.Button()
      Me._gbSegmentationOptions.SuspendLayout()
      Me._gbCompressionTypes.SuspendLayout()
      CType(Me._trkbQFactor, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _cmboSegmentationOptions
      ' 
      Me._cmboSegmentationOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmboSegmentationOptions.Items.AddRange(New Object() {"Favor 1 Bit segments", "Favor 2 Bit segments", "Force 1 Bit segments", "Force 2 Bit segments"})
      Me._cmboSegmentationOptions.Location = New System.Drawing.Point(152, 19)
      Me._cmboSegmentationOptions.Name = "_cmboSegmentationOptions"
      Me._cmboSegmentationOptions.Size = New System.Drawing.Size(160, 21)
      Me._cmboSegmentationOptions.TabIndex = 1
      ' 
      ' _cbSearchForBackground
      ' 
      Me._cbSearchForBackground.Location = New System.Drawing.Point(16, 64)
      Me._cbSearchForBackground.Name = "_cbSearchForBackground"
      Me._cbSearchForBackground.Size = New System.Drawing.Size(160, 24)
      Me._cbSearchForBackground.TabIndex = 2
      Me._cbSearchForBackground.Text = "Sea&rch for background"
      ' 
      ' _lblSegmentationOptions
      ' 
      Me._lblSegmentationOptions.Location = New System.Drawing.Point(8, 24)
      Me._lblSegmentationOptions.Name = "_lblSegmentationOptions"
      Me._lblSegmentationOptions.Size = New System.Drawing.Size(120, 24)
      Me._lblSegmentationOptions.TabIndex = 0
      Me._lblSegmentationOptions.Text = "S&egmentation Options"
      ' 
      ' _gbSegmentationOptions
      ' 
      Me._gbSegmentationOptions.Controls.Add(Me._lblSegmentationOptions)
      Me._gbSegmentationOptions.Controls.Add(Me._cbSearchForBackground)
      Me._gbSegmentationOptions.Controls.Add(Me._cmboSegmentationOptions)
      Me._gbSegmentationOptions.Location = New System.Drawing.Point(16, 258)
      Me._gbSegmentationOptions.Name = "_gbSegmentationOptions"
      Me._gbSegmentationOptions.Size = New System.Drawing.Size(336, 104)
      Me._gbSegmentationOptions.TabIndex = 1
      Me._gbSegmentationOptions.TabStop = False
      Me._gbSegmentationOptions.Text = "Segmentation Options"
      ' 
      ' _gbCompressionTypes
      ' 
      Me._gbCompressionTypes.Controls.Add(Me._lblBestCompression)
      Me._gbCompressionTypes.Controls.Add(Me._lblBestQuality)
      Me._gbCompressionTypes.Controls.Add(Me._lblPictures)
      Me._gbCompressionTypes.Controls.Add(Me._lbl1BPPImages)
      Me._gbCompressionTypes.Controls.Add(Me._lbl2BPPImages)
      Me._gbCompressionTypes.Controls.Add(Me._cmbo1BPPImages)
      Me._gbCompressionTypes.Controls.Add(Me._cmbo2BPPImages)
      Me._gbCompressionTypes.Controls.Add(Me._trkbQFactor)
      Me._gbCompressionTypes.Controls.Add(Me._cmboPictures)
      Me._gbCompressionTypes.Location = New System.Drawing.Point(16, 12)
      Me._gbCompressionTypes.Name = "_gbCompressionTypes"
      Me._gbCompressionTypes.Size = New System.Drawing.Size(336, 240)
      Me._gbCompressionTypes.TabIndex = 0
      Me._gbCompressionTypes.TabStop = False
      Me._gbCompressionTypes.Text = "&CompressionTypes"
      ' 
      ' _lblBestCompression
      ' 
      Me._lblBestCompression.Location = New System.Drawing.Point(208, 156)
      Me._lblBestCompression.Name = "_lblBestCompression"
      Me._lblBestCompression.Size = New System.Drawing.Size(104, 16)
      Me._lblBestCompression.TabIndex = 7
      Me._lblBestCompression.Text = "Best Compression"
      ' 
      ' _lblBestQuality
      ' 
      Me._lblBestQuality.Location = New System.Drawing.Point(15, 156)
      Me._lblBestQuality.Name = "_lblBestQuality"
      Me._lblBestQuality.Size = New System.Drawing.Size(98, 16)
      Me._lblBestQuality.TabIndex = 6
      Me._lblBestQuality.Text = "Best Quality"
      ' 
      ' _lblPictures
      ' 
      Me._lblPictures.Location = New System.Drawing.Point(15, 119)
      Me._lblPictures.Name = "_lblPictures"
      Me._lblPictures.Size = New System.Drawing.Size(48, 16)
      Me._lblPictures.TabIndex = 4
      Me._lblPictures.Text = "&Pictures"
      ' 
      ' _lbl1BPPImages
      ' 
      Me._lbl1BPPImages.Location = New System.Drawing.Point(15, 31)
      Me._lbl1BPPImages.Name = "_lbl1BPPImages"
      Me._lbl1BPPImages.Size = New System.Drawing.Size(88, 16)
      Me._lbl1BPPImages.TabIndex = 0
      Me._lbl1BPPImages.Text = "&1BPP Images"
      ' 
      ' _lbl2BPPImages
      ' 
      Me._lbl2BPPImages.Location = New System.Drawing.Point(15, 71)
      Me._lbl2BPPImages.Name = "_lbl2BPPImages"
      Me._lbl2BPPImages.Size = New System.Drawing.Size(88, 24)
      Me._lbl2BPPImages.TabIndex = 2
      Me._lbl2BPPImages.Text = "&2BPP Images"
      ' 
      ' _cmbo1BPPImages
      ' 
      Me._cmbo1BPPImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbo1BPPImages.Items.AddRange(New Object() {"ZIP", "Lempel Ziv Welch (LZW)", "Fax CCITT G3 1D", "Fax CCITT G3 2D", "Fax CCITT G4", "JBIG2"})
      Me._cmbo1BPPImages.Location = New System.Drawing.Point(111, 31)
      Me._cmbo1BPPImages.Name = "_cmbo1BPPImages"
      Me._cmbo1BPPImages.Size = New System.Drawing.Size(184, 21)
      Me._cmbo1BPPImages.TabIndex = 1
      ' 
      ' _cmbo2BPPImages
      ' 
      Me._cmbo2BPPImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbo2BPPImages.Items.AddRange(New Object() {"ZIP", "Lempel Ziv Welch (LZW)"})
      Me._cmbo2BPPImages.Location = New System.Drawing.Point(111, 71)
      Me._cmbo2BPPImages.Name = "_cmbo2BPPImages"
      Me._cmbo2BPPImages.Size = New System.Drawing.Size(184, 21)
      Me._cmbo2BPPImages.TabIndex = 3
      ' 
      ' _trkbQFactor
      ' 
      Me._trkbQFactor.Location = New System.Drawing.Point(15, 175)
      Me._trkbQFactor.Maximum = 255
      Me._trkbQFactor.Minimum = 2
      Me._trkbQFactor.Name = "_trkbQFactor"
      Me._trkbQFactor.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._trkbQFactor.Size = New System.Drawing.Size(304, 45)
      Me._trkbQFactor.TabIndex = 8
      Me._trkbQFactor.TickFrequency = 10
      Me._trkbQFactor.Value = 2
      ' 
      ' _cmboPictures
      ' 
      Me._cmboPictures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmboPictures.Items.AddRange(New Object() {"JPEG", "JPEG_YUV422", "JPEG_YUV411", "JPEG_PROGRESSIVE", "JPEG_PROGRESSIVE_ YUV422", "JPEG_PROGRESSIVE_ YUV411", "ZIP", "Lempel Ziv Welch (LZW)", "Jpeg2000(J2k)"})
      Me._cmboPictures.Location = New System.Drawing.Point(111, 116)
      Me._cmboPictures.Name = "_cmboPictures"
      Me._cmboPictures.Size = New System.Drawing.Size(184, 21)
      Me._cmboPictures.TabIndex = 5
      '		 Me._cmboPictures.SelectedIndexChanged += New System.EventHandler(Me._cmboPictures_SelectedIndexChanged);
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(216, 400)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(112, 24)
      Me._btnCancel.TabIndex = 3
      Me._btnCancel.Text = "Cancel"
      ' 
      ' _btnOK
      ' 
      Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOK.Location = New System.Drawing.Point(32, 400)
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.Size = New System.Drawing.Size(112, 24)
      Me._btnOK.TabIndex = 2
      Me._btnOK.Text = "OK"
      '		 Me._btnOK.Click += New System.EventHandler(Me._btnOK_Click);
      ' 
      ' PdfAdvancedOptionsDialog
      ' 
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(376, 438)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOK)
      Me.Controls.Add(Me._gbSegmentationOptions)
      Me.Controls.Add(Me._gbCompressionTypes)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PdfAdvancedOptionsDialog"
      Me.ShowInTaskbar = False
      Me.Text = "Pdf Advanced Options"
      '		 Me.Load += New System.EventHandler(Me.PdfAdvancedOptionsDialog_Load);
      Me._gbSegmentationOptions.ResumeLayout(False)
      Me._gbCompressionTypes.ResumeLayout(False)
      Me._gbCompressionTypes.PerformLayout()
      CType(Me._trkbQFactor, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
#End Region

   Friend Property AdvancedOptions() As PdfAdvancedOptions
      Get
         Return _advancedOptions
      End Get
      Set(value As PdfAdvancedOptions)
         _advancedOptions = value
      End Set
   End Property


   Private _advancedOptions As PdfAdvancedOptions

   Private Sub PdfAdvancedOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

      SetDialog()

   End Sub

   Private Sub SetDialog()
      _cmboSegmentationOptions.SelectedIndex = AdvancedOptions.SegmentationComboSel
      _cmbo1BPPImages.SelectedIndex = AdvancedOptions.OneBitComboSel
      _cmbo2BPPImages.SelectedIndex = AdvancedOptions.TwoBitComboSel
      _cmboPictures.SelectedIndex = AdvancedOptions.PictComboSel
      _trkbQFactor.Value = AdvancedOptions.QFactor
      _cbSearchForBackground.Checked = AdvancedOptions.CheckBackground

   End Sub

   Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOK.Click
      AdvancedOptions.SegmentationComboSel = _cmboSegmentationOptions.SelectedIndex
      AdvancedOptions.OneBitComboSel = _cmbo1BPPImages.SelectedIndex
      AdvancedOptions.TwoBitComboSel = _cmbo2BPPImages.SelectedIndex
      AdvancedOptions.PictComboSel = _cmboPictures.SelectedIndex
      AdvancedOptions.QFactor = _trkbQFactor.Value
      AdvancedOptions.CheckBackground = _cbSearchForBackground.Checked


   End Sub

   Private Sub _cmboPictures_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmboPictures.SelectedIndexChanged
      Dim bStatus As Boolean = (_cmboPictures.SelectedIndex < 6) OrElse (_cmboPictures.SelectedIndex = 8)
      _trkbQFactor.Enabled = bStatus
      _lblBestQuality.Enabled = bStatus
      _lblBestCompression.Enabled = bStatus

   End Sub

End Class
