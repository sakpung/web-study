' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Twain
Imports Leadtools.Codecs
Imports Leadtools.WinForms.CommonDialogs.File

Namespace VBFastTwainDemo
   ''' <summary>
   ''' Summary description for FastOptions.
   ''' </summary>
   Public Class FastOptions : Inherits System.Windows.Forms.Form
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents _rdTransferFile As System.Windows.Forms.RadioButton
      Private WithEvents _rdTransferMemory As System.Windows.Forms.RadioButton
      Private WithEvents _rdTransferNative As System.Windows.Forms.RadioButton
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private _lblBaseFileName As System.Windows.Forms.Label
      Private WithEvents _txtFileName As System.Windows.Forms.TextBox
      Private WithEvents _btnBrowse As System.Windows.Forms.Button
      Private _lblOutputFileFormat As System.Windows.Forms.Label
      Private _cmbFileFormats As System.Windows.Forms.ComboBox
      Private WithEvents _btnLEADFormats As System.Windows.Forms.Button
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private WithEvents _cbUseBufferSize As System.Windows.Forms.CheckBox
      Private _lblBufferSize As System.Windows.Forms.Label
      Private WithEvents _txtBufferSize As System.Windows.Forms.TextBox
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
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
         Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FastOptions))
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._rdTransferNative = New System.Windows.Forms.RadioButton()
         Me._rdTransferMemory = New System.Windows.Forms.RadioButton()
         Me._rdTransferFile = New System.Windows.Forms.RadioButton()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me._btnLEADFormats = New System.Windows.Forms.Button()
         Me._cmbFileFormats = New System.Windows.Forms.ComboBox()
         Me._lblOutputFileFormat = New System.Windows.Forms.Label()
         Me._btnBrowse = New System.Windows.Forms.Button()
         Me._txtFileName = New System.Windows.Forms.TextBox()
         Me._lblBaseFileName = New System.Windows.Forms.Label()
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         Me._txtBufferSize = New System.Windows.Forms.TextBox()
         Me._lblBufferSize = New System.Windows.Forms.Label()
         Me._cbUseBufferSize = New System.Windows.Forms.CheckBox()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me.groupBox1.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me.groupBox3.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._rdTransferNative)
         Me.groupBox1.Controls.Add(Me._rdTransferMemory)
         Me.groupBox1.Controls.Add(Me._rdTransferFile)
         Me.groupBox1.Location = New System.Drawing.Point(8, 8)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(152, 192)
         Me.groupBox1.TabIndex = 0
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "&Transfer Mode "
         ' 
         ' _rdTransferNative
         ' 
         Me._rdTransferNative.Location = New System.Drawing.Point(16, 136)
         Me._rdTransferNative.Name = "_rdTransferNative"
         Me._rdTransferNative.TabIndex = 3
         Me._rdTransferNative.Text = "&Native Mode"
         ' 
         ' _rdTransferMemory
         ' 
         Me._rdTransferMemory.Location = New System.Drawing.Point(16, 84)
         Me._rdTransferMemory.Name = "_rdTransferMemory"
         Me._rdTransferMemory.TabIndex = 2
         Me._rdTransferMemory.Text = "Memor&y Mode"
         ' 
         ' _rdTransferFile
         ' 
         Me._rdTransferFile.Location = New System.Drawing.Point(16, 32)
         Me._rdTransferFile.Name = "_rdTransferFile"
         Me._rdTransferFile.TabIndex = 1
         Me._rdTransferFile.Text = "&File Mode"
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.Controls.Add(Me._btnLEADFormats)
         Me.groupBox2.Controls.Add(Me._cmbFileFormats)
         Me.groupBox2.Controls.Add(Me._lblOutputFileFormat)
         Me.groupBox2.Controls.Add(Me._btnBrowse)
         Me.groupBox2.Controls.Add(Me._txtFileName)
         Me.groupBox2.Controls.Add(Me._lblBaseFileName)
         Me.groupBox2.Location = New System.Drawing.Point(168, 8)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(328, 112)
         Me.groupBox2.TabIndex = 4
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "&General Options "
         ' 
         ' _btnLEADFormats
         ' 
         Me._btnLEADFormats.Location = New System.Drawing.Point(120, 80)
         Me._btnLEADFormats.Name = "_btnLEADFormats"
         Me._btnLEADFormats.Size = New System.Drawing.Size(200, 23)
         Me._btnLEADFormats.TabIndex = 10
         Me._btnLEADFormats.Text = "LEADTOOLS Formats"
         ' 
         ' _cmbFileFormats
         ' 
         Me._cmbFileFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbFileFormats.Location = New System.Drawing.Point(120, 48)
         Me._cmbFileFormats.Name = "_cmbFileFormats"
         Me._cmbFileFormats.Size = New System.Drawing.Size(200, 21)
         Me._cmbFileFormats.TabIndex = 9
         ' 
         ' _lblOutputFileFormat
         ' 
         Me._lblOutputFileFormat.Location = New System.Drawing.Point(16, 48)
         Me._lblOutputFileFormat.Name = "_lblOutputFileFormat"
         Me._lblOutputFileFormat.Size = New System.Drawing.Size(104, 24)
         Me._lblOutputFileFormat.TabIndex = 8
         Me._lblOutputFileFormat.Text = "Output File F&ormat:"
         Me._lblOutputFileFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         ' 
         ' _btnBrowse
         ' 
         Me._btnBrowse.Location = New System.Drawing.Point(288, 16)
         Me._btnBrowse.Name = "_btnBrowse"
         Me._btnBrowse.Size = New System.Drawing.Size(32, 23)
         Me._btnBrowse.TabIndex = 7
         Me._btnBrowse.Text = "..."
         ' 
         ' _txtFileName
         ' 
         Me._txtFileName.Location = New System.Drawing.Point(120, 16)
         Me._txtFileName.Name = "_txtFileName"
         Me._txtFileName.ReadOnly = True
         Me._txtFileName.Size = New System.Drawing.Size(160, 20)
         Me._txtFileName.TabIndex = 6
         Me._txtFileName.Text = ""
         ' 
         ' _lblBaseFileName
         ' 
         Me._lblBaseFileName.Location = New System.Drawing.Point(32, 16)
         Me._lblBaseFileName.Name = "_lblBaseFileName"
         Me._lblBaseFileName.Size = New System.Drawing.Size(88, 24)
         Me._lblBaseFileName.TabIndex = 5
         Me._lblBaseFileName.Text = "Base File N&ame:"
         Me._lblBaseFileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         ' 
         ' groupBox3
         ' 
         Me.groupBox3.Controls.Add(Me._txtBufferSize)
         Me.groupBox3.Controls.Add(Me._lblBufferSize)
         Me.groupBox3.Controls.Add(Me._cbUseBufferSize)
         Me.groupBox3.Location = New System.Drawing.Point(168, 120)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(328, 80)
         Me.groupBox3.TabIndex = 11
         Me.groupBox3.TabStop = False
         Me.groupBox3.Text = "Transfer &Options"
         ' 
         ' _txtBufferSize
         ' 
         Me._txtBufferSize.Location = New System.Drawing.Point(128, 48)
         Me._txtBufferSize.Name = "_txtBufferSize"
         Me._txtBufferSize.Size = New System.Drawing.Size(192, 20)
         Me._txtBufferSize.TabIndex = 14
         Me._txtBufferSize.Text = ""
         ' 
         ' _lblBufferSize
         ' 
         Me._lblBufferSize.Location = New System.Drawing.Point(8, 48)
         Me._lblBufferSize.Name = "_lblBufferSize"
         Me._lblBufferSize.Size = New System.Drawing.Size(112, 24)
         Me._lblBufferSize.TabIndex = 13
         Me._lblBufferSize.Text = "Custom &Buffer Size:"
         Me._lblBufferSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         ' 
         ' _cbUseBufferSize
         ' 
         Me._cbUseBufferSize.Location = New System.Drawing.Point(16, 24)
         Me._cbUseBufferSize.Name = "_cbUseBufferSize"
         Me._cbUseBufferSize.Size = New System.Drawing.Size(152, 16)
         Me._cbUseBufferSize.TabIndex = 12
         Me._cbUseBufferSize.Text = "Use &Custom Buffer Size"
         ' 
         ' _btnOK
         ' 
         Me._btnOK.Location = New System.Drawing.Point(504, 77)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.TabIndex = 15
         Me._btnOK.Text = "OK"
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(504, 109)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.TabIndex = 16
         Me._btnCancel.Text = "Cancel"
         ' 
         ' FastOptions
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(586, 208)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me.groupBox3)
         Me.Controls.Add(Me.groupBox2)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "FastOptions"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Fast Twain Options..."
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox3.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
#End Region
      Private _transferMode As TwainTransferMode
      Private _allBPPCount As Integer
      Private _bitsPerPixel As Integer()
      Private _formInitialized As Boolean
      Private _imageLEADFormat As RasterImageFormat
      Private _nativeBPP As Integer
      Private _memoryFormatBPP As Integer()
      Private _memoryFormatMulti As Boolean()
      Private _format As RasterImageFormat()
      Private _bufferSize As Integer
      Private _oldBufferSize As Integer
      Private _codecs As RasterCodecs
      Public _session As TwainSession

      Private Sub FastOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs)Handles Me.Load
         _memoryFormatBPP = New Integer(29) {}
         _memoryFormatMulti = New Boolean(29) {}
         _transferMode = TwainTransferMode.Native

         _rdTransferFile.Enabled = False
         _rdTransferMemory.Enabled = False
         _rdTransferNative.Enabled = False
         _txtFileName.Enabled = False
         _btnBrowse.Enabled = False
         _cmbFileFormats.Enabled = False
         _btnLEADFormats.Enabled = False
         _cbUseBufferSize.Enabled = False
         _txtBufferSize.Enabled = False

         If MainForm.TwainAvailable Then
            CheckTransferMode(sender, e)
         End If

         _btnOK.Enabled = False

         _codecs = New RasterCodecs()
      End Sub

      Private Sub _cbUseBufferSize_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)Handles _cbUseBufferSize.CheckedChanged
         If (Not _formInitialized) Then
            If _cbUseBufferSize.Checked Then
               _cbUseBufferSize.Checked = True
            Else
               _cbUseBufferSize.Checked = False
            End If
         End If

         _txtBufferSize.Enabled = _cbUseBufferSize.Checked
      End Sub

      Private Sub _txtBufferSize_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)Handles _txtBufferSize.TextChanged
         Try
            _bufferSize = Convert.ToInt32(_txtBufferSize.Text)
            _oldBufferSize = _bufferSize

            _btnOK.Enabled = (_txtFileName.Text <> "" AndAlso _txtBufferSize.Text <> "")
         Catch ex As Exception
            _bufferSize = _oldBufferSize
            _txtBufferSize.Text = Convert.ToString(_bufferSize)
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Function GetFormatFilter() As String
         Dim selectedFormatIndex As Integer = _cmbFileFormats.SelectedIndex
         Dim myFormat As RasterImageFormat = _format(selectedFormatIndex)

         Dim formatFilter As String = "All files (*.*)|*.*"


         Select Case myFormat
            Case RasterImageFormat.Tif, RasterImageFormat.FaxG4, RasterImageFormat.FaxG32Dim, RasterImageFormat.FaxG31Dim, RasterImageFormat.FaxG31DimNoEol
               formatFilter = "Tif files (*.tif)|*.tif"
            Case RasterImageFormat.Bmp
               formatFilter = "Bmp files (*.bmp)|*.bmp"
            Case RasterImageFormat.Xbm
               formatFilter = "Xbm files (*.xbm)|*.xbm"
            Case RasterImageFormat.Jpeg, RasterImageFormat.Jpeg411, RasterImageFormat.Jpeg422
               formatFilter = "Jpeg files (*.jpg)|*.jpg"
            Case RasterImageFormat.Png
               formatFilter = "Png files (*.png)|*.png"
            Case RasterImageFormat.Exif
               formatFilter = "Exit files (*.exif)|*.exif"
            Case RasterImageFormat.Jbig
               formatFilter = "Jbig files (*.jbg)|*.jbg"
         End Select

         Return formatFilter
      End Function

      Private Sub _btnBrowse_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _btnBrowse.Click
         Using saveDialog As SaveFileDialog = New SaveFileDialog()
            saveDialog.Filter = GetFormatFilter()
            saveDialog.FilterIndex = 0

            If saveDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               _txtFileName.Text = saveDialog.FileName
            End If
         End Using
      End Sub

      Private Sub _rdTransferFile_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)Handles _rdTransferFile.CheckedChanged
         Dim format As Integer
         Dim fileName As String

         _transferMode = TwainTransferMode.File
         _cmbFileFormats.Enabled = True
         _btnBrowse.Enabled = True

         fileName = Me._txtFileName.Text
         _btnOK.Enabled = (fileName <> "")

         ' disable other options
         _cbUseBufferSize.Enabled = False
         _txtBufferSize.Enabled = False
         _btnLEADFormats.Enabled = False

         Try
            Dim twnCap As TwainCapability = _session.GetCapability(TwainCapabilityType.ImageImageFileFormat, TwainGetCapabilityMode.GetValues)

            Select Case twnCap.Information.ContainerType
               Case TwainContainerType.Enumeration
                  _cmbFileFormats.Items.Clear()
                  Dim count As Integer = twnCap.EnumerationCapability.Count
                  _format = New RasterImageFormat(count - 1) {}
                  Dim i As Integer = 0
                  Do While i < count
                     If twnCap.EnumerationCapability.ItemType = TwainItemType.Uint16 Then
                        format = Convert.ToUInt16(twnCap.EnumerationCapability.GetValue(i))
                        AddScannerFormats(format, i)
                     End If
                     i += 1
                  Loop
                  Exit Select
               Case TwainContainerType.OneValue
                  _cmbFileFormats.Items.Clear()
                  If twnCap.OneValueCapability.ItemType = TwainItemType.Uint16 Then
                     _format = New RasterImageFormat(0) {}
                     format = Convert.ToUInt16(twnCap.OneValueCapability.Value)
                     AddScannerFormats(format, 0)
                  End If
                  Exit Select
            End Select

            _cmbFileFormats.SelectedIndex = 0
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _rdTransferMemory_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)Handles _rdTransferMemory.CheckedChanged
         Dim customBuffer As String
         _transferMode = TwainTransferMode.Buffer

         _cbUseBufferSize.Enabled = True
         _txtBufferSize.Enabled = True
         _cmbFileFormats.Enabled = True
         _btnBrowse.Enabled = True

         _formInitialized = True
         _cbUseBufferSize_CheckedChanged(Me, e)
         _formInitialized = False

         customBuffer = " "
         If _cbUseBufferSize.Checked Then
            customBuffer = _txtBufferSize.Text
         End If

         If customBuffer = "" OrElse _txtFileName.Text = "" Then
            _btnOK.Enabled = False
         Else
            _btnOK.Enabled = True
         End If

         FillMemoryFormats()

         ' disable other options
         Me._btnLEADFormats.Enabled = False
      End Sub

      Private Sub _rdTransferNative_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)Handles _rdTransferNative.CheckedChanged
         Dim fileName As String
         _transferMode = TwainTransferMode.Native

         _btnLEADFormats.Enabled = True

         fileName = _txtFileName.Text
         _btnOK.Enabled = (fileName <> "")

         ' disable other options
         _cmbFileFormats.Enabled = False
         _cbUseBufferSize.Enabled = False

         If _txtBufferSize.Text = "" Then
            _txtBufferSize.Text = "0"
         End If

         _txtBufferSize.Enabled = False
         _btnBrowse.Enabled = False
      End Sub

      Private Sub AddScannerFormats(ByVal format As Integer, ByVal index As Integer)
         Dim formatValue As TwainCapabilityValue = CType(format, TwainCapabilityValue)
         Select Case formatValue
            Case TwainCapabilityValue.FileFormatTiff
               _cmbFileFormats.Items.Insert(index, "TIFF")
               _format(index) = RasterImageFormat.Tif
            Case TwainCapabilityValue.FileFormatBmp
               _cmbFileFormats.Items.Insert(index, "BMP")
               _format(index) = RasterImageFormat.Bmp
            Case TwainCapabilityValue.FileFormatXbm
               _cmbFileFormats.Items.Insert(index, "XBM")
               _format(index) = RasterImageFormat.Xbm
            Case TwainCapabilityValue.FileFormatJfif
               _cmbFileFormats.Items.Insert(index, "JFIF")
               _format(index) = RasterImageFormat.Jpeg
            Case TwainCapabilityValue.FileFormatTiffMulti
               _cmbFileFormats.Items.Insert(index, "TIFF MULTI")
               _format(index) = RasterImageFormat.Tif
            Case TwainCapabilityValue.FileFormatPng
               _cmbFileFormats.Items.Insert(index, "PNG")
               _format(index) = RasterImageFormat.Png
            Case TwainCapabilityValue.FileFormatExif
               _cmbFileFormats.Items.Insert(index, "EXIF")
               _format(index) = RasterImageFormat.Exif
         End Select
      End Sub

      Private Function GetScannerBPP() As Boolean
         Dim twnCap As TwainCapability
         _allBPPCount = 0

         Try
            twnCap = _session.GetCapability(TwainCapabilityType.ImageBitDepth, TwainGetCapabilityMode.GetCurrent)

            Select Case twnCap.Information.ContainerType
               Case TwainContainerType.OneValue
                  _allBPPCount = 1
                  _bitsPerPixel = New Integer(_allBPPCount - 1) {}
                  If twnCap.OneValueCapability.ItemType = TwainItemType.Uint16 Then
                     _bitsPerPixel(0) = Convert.ToUInt16(twnCap.OneValueCapability.Value)
                  End If
                  Exit Select
               Case TwainContainerType.Enumeration
                  Dim count As Integer = twnCap.EnumerationCapability.Count
                  _allBPPCount = count
                  _bitsPerPixel = New Integer(_allBPPCount - 1) {}
                  Dim i As Integer = 0
                  Do While i < _allBPPCount
                     If twnCap.EnumerationCapability.ItemType = TwainItemType.Uint16 Then
                        _bitsPerPixel(i) = Convert.ToUInt16(twnCap.EnumerationCapability.GetValue(i))
                     End If
                     i += 1
                  Loop
                  Exit Select
            End Select
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            Return False
         End Try

         Return (_allBPPCount > 0)
      End Function

      Private Sub FillMemoryFormats()
         Dim k As Integer = 0
         If GetScannerBPP() = False Then
            _bitsPerPixel = New Integer(0) {}

            _allBPPCount = 1
            _bitsPerPixel(0) = 1
         End If

         _format = New RasterImageFormat(29) {}
         _cmbFileFormats.Items.Clear()
         Dim i As Integer = 0
         Do While i < _allBPPCount
            Select Case _bitsPerPixel(i)
               Case 1
                  ' G4
                  _cmbFileFormats.Items.Add("Multipage CCITT G4 TIFF")
                  _format(k) = RasterImageFormat.FaxG4
                  _memoryFormatBPP(k) = 1
                  _memoryFormatMulti(k) = True
                  k += 1

                  _cmbFileFormats.Items.Add("Singlepage CCITT G4 TIFF")
                  _format(k) = RasterImageFormat.FaxG4
                  _memoryFormatBPP(k) = 1
                  _memoryFormatMulti(k) = False
                  k += 1

                  ' G32D
                  _cmbFileFormats.Items.Add("Multipage CCITT G32D TIFF")
                  _format(k) = RasterImageFormat.FaxG32Dim
                  _memoryFormatBPP(k) = 1
                  _memoryFormatMulti(k) = True
                  k += 1

                  _cmbFileFormats.Items.Add("Singlepage CCITT G32D TIFF")
                  _format(k) = RasterImageFormat.FaxG32Dim
                  _memoryFormatBPP(k) = 1
                  _memoryFormatMulti(k) = False
                  k += 1

                  ' G31D
                  _cmbFileFormats.Items.Add("Multipage CCITT G31D TIFF")
                  _format(k) = RasterImageFormat.FaxG31Dim
                  _memoryFormatBPP(k) = 1
                  _memoryFormatMulti(k) = True
                  k += 1

                  _cmbFileFormats.Items.Add("Singlepage CCITT G31D TIFF")
                  _format(k) = RasterImageFormat.FaxG31Dim
                  _memoryFormatBPP(k) = 1
                  _memoryFormatMulti(k) = False
                  k += 1

                  ' G31D NOEOL
                  If CheckG31DNOEOLCompression() Then
                     _cmbFileFormats.Items.Add("Singlepage CCITT G31D NOEOL (FAX)")
                     _format(k) = RasterImageFormat.FaxG31DimNoEol
                     _memoryFormatBPP(k) = 1
                     _memoryFormatMulti(k) = False
                     k += 1
                  End If

                  ' JBIG
                  _cmbFileFormats.Items.Add("Singlepage JBIG")
                  _format(k) = RasterImageFormat.Jbig
                  _memoryFormatBPP(k) = 1
                  _memoryFormatMulti(k) = False
                  k += 1

                  ' TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 1-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 1
                  _memoryFormatMulti(k) = True
                  k += 1

                  _cmbFileFormats.Items.Add("Singlepage Uncompressed 1-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 1
                  _memoryFormatMulti(k) = False
                  k += 1
                  _cmbFileFormats.SelectedIndex = 0
               Case 24
                  ' LEAD1JFIF
                  _cmbFileFormats.Items.Add("Singlepage JPEG Color 4:1:1")
                  _format(k) = RasterImageFormat.Jpeg411
                  _memoryFormatBPP(k) = 24
                  _memoryFormatMulti(k) = False
                  k += 1

                  ' LEAD2JFIF
                  _cmbFileFormats.Items.Add("Singlepage JPEG Color 4:2:2")
                  _format(k) = RasterImageFormat.Jpeg422
                  _memoryFormatBPP(k) = 24
                  _memoryFormatMulti(k) = False
                  k += 1

                  ' JPEG
                  _cmbFileFormats.Items.Add("Singlepage JPEG Color 4:4:4")
                  _format(k) = RasterImageFormat.Jpeg
                  _memoryFormatBPP(k) = 24
                  _memoryFormatMulti(k) = False
                  k += 1

                  ' TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 24-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 24
                  _memoryFormatMulti(k) = True
                  k += 1

                  _cmbFileFormats.Items.Add("Single Uncompressed 24-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 24
                  _memoryFormatMulti(k) = False
                  k += 1
                  _cmbFileFormats.SelectedIndex = 0
               Case 8
                  ' JPEG
                  _cmbFileFormats.Items.Add("Singlepage JPEG Grayscale 8-bit")
                  _format(k) = RasterImageFormat.Jpeg
                  _memoryFormatBPP(k) = 8
                  _memoryFormatMulti(k) = False
                  k += 1

                  ' TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 8-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 8
                  _memoryFormatMulti(k) = True
                  k += 1

                  _cmbFileFormats.Items.Add("Single Uncompressed 8-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 8
                  _memoryFormatMulti(k) = False
                  k += 1
                  _cmbFileFormats.SelectedIndex = 0
               Case 2, 4
                  ' TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 4-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 4
                  _memoryFormatMulti(k) = True
                  k += 1

                  _cmbFileFormats.Items.Add("Single Uncompressed 4-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 4
                  _memoryFormatMulti(k) = False
                  k += 1
                  _cmbFileFormats.SelectedIndex = 0
               Case 16
                  ' JPEG
                  _cmbFileFormats.Items.Add("Singlepage JPEG Grayscale 16-bit")
                  _format(k) = RasterImageFormat.Jpeg
                  _memoryFormatBPP(k) = 16
                  _memoryFormatMulti(k) = False
                  k += 1

                  ' TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 16-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 16
                  _memoryFormatMulti(k) = True
                  k += 1

                  _cmbFileFormats.Items.Add("Single Uncompressed 16-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 16
                  _memoryFormatMulti(k) = False
                  k += 1
                  _cmbFileFormats.SelectedIndex = 0
               Case 32
                  ' TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 32-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 32
                  _memoryFormatMulti(k) = True
                  k += 1

                  _cmbFileFormats.Items.Add("Single Uncompressed 32-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 32
                  _memoryFormatMulti(k) = False
                  k += 1
                  _cmbFileFormats.SelectedIndex = 0
               Case 48
                  ' TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 48-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 48
                  _memoryFormatMulti(k) = True
                  k += 1

                  _cmbFileFormats.Items.Add("Single Uncompressed 48-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 48
                  _memoryFormatMulti(k) = False
                  k += 1
                  _cmbFileFormats.SelectedIndex = 0
               Case 64
                  ' TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 64-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 64
                  _memoryFormatMulti(k) = True
                  k += 1

                  _cmbFileFormats.Items.Add("Single Uncompressed 64-bit TIFF")
                  _format(k) = RasterImageFormat.Tif
                  _memoryFormatBPP(k) = 64
                  _memoryFormatMulti(k) = False
                  k += 1
                  _cmbFileFormats.SelectedIndex = 0
            End Select
            i += 1
         Loop
      End Sub

      Private Function CheckG31DNOEOLCompression() As Boolean
         Dim compression As Integer
         Dim compressionExit As Boolean = False
         Dim twnCap As TwainCapability

         Try
            twnCap = _session.GetCapability(TwainCapabilityType.ImageCompression, TwainGetCapabilityMode.GetValues)

            Select Case twnCap.Information.ContainerType
               Case TwainContainerType.OneValue
                  If twnCap.OneValueCapability.ItemType = TwainItemType.Uint16 Then
                     compression = Convert.ToUInt16(twnCap.OneValueCapability.Value)

                     If compression = CInt(TwainCapabilityValue.CompressionGroup31D) Then
                        compressionExit = True
                     End If
                  End If
                  Exit Select
               Case TwainContainerType.Enumeration
                  Dim count As Integer = twnCap.EnumerationCapability.Count
                  Dim i As Integer = 0
                  Do While i < count
                     If twnCap.EnumerationCapability.ItemType = TwainItemType.Uint16 Then
                        compression = Convert.ToUInt16(twnCap.EnumerationCapability.GetValue(i))

                        If compression = CInt(TwainCapabilityValue.CompressionGroup31D) Then
                           compressionExit = True
                           Exit Do
                        End If
                     End If
                     i += 1
                  Loop
                  Exit Select
            End Select
         Catch
            Return False
         End Try

         Return compressionExit
      End Function

      Private Sub CheckTransferMode(ByVal sender As Object, ByVal e As System.EventArgs)
         Dim fileMode As Boolean = False, memoryMode As Boolean = False, nativeMode As Boolean = False
         Dim xfer As Integer = 0
         Dim twnCap As TwainCapability = Nothing

         Try
            twnCap = _session.GetCapability(TwainCapabilityType.ImageTransferMechanism, TwainGetCapabilityMode.GetValues)

            Select Case twnCap.Information.ContainerType
               Case TwainContainerType.OneValue
                  If twnCap.OneValueCapability.ItemType = TwainItemType.Uint16 Then
                     xfer = Convert.ToUInt16(twnCap.OneValueCapability.Value)

                     If xfer = CInt(TwainCapabilityValue.TransferMechanismFile) Then
                        fileMode = True
                     End If
                     If xfer = CInt(TwainCapabilityValue.TransferMechanismMemory) Then
                        memoryMode = True
                     End If
                     If xfer = CInt(TwainCapabilityValue.TransferMechanismNative) Then
                        nativeMode = True
                     End If
                  End If
                  Exit Select
               Case TwainContainerType.Enumeration
                  Dim count As Integer = twnCap.EnumerationCapability.Count
                  Dim i As Integer = 0
                  Do While i < count
                     If twnCap.EnumerationCapability.ItemType = TwainItemType.Uint16 Then
                        xfer = Convert.ToUInt16(twnCap.EnumerationCapability.GetValue(i))

                        If xfer = CInt(TwainCapabilityValue.TransferMechanismFile) Then
                           fileMode = True
                        End If
                        If xfer = CInt(TwainCapabilityValue.TransferMechanismMemory) Then
                           memoryMode = True
                        End If
                        If xfer = CInt(TwainCapabilityValue.TransferMechanismNative) Then
                           nativeMode = True
                        End If
                     End If
                     i += 1
                  Loop

                  Exit Select
            End Select
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            Return
         End Try

         _rdTransferFile.Enabled = fileMode
         _rdTransferMemory.Enabled = memoryMode
         _rdTransferNative.Enabled = nativeMode

         If memoryMode Then
            _rdTransferMemory.Checked = True
            _rdTransferMemory_CheckedChanged(sender, e)
         End If

         If fileMode Then
            _rdTransferFile.Checked = True
            _rdTransferFile_CheckedChanged(sender, e)
         End If

         If nativeMode Then
            _rdTransferNative.Checked = True
            _rdTransferNative_CheckedChanged(sender, e)
         End If

         _txtFileName_TextChanged(sender, e)
      End Sub

      Private Sub _btnLEADFormats_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _btnLEADFormats.Click
         Dim saveDlg As RasterSaveDialog = New RasterSaveDialog(_codecs)

         saveDlg.EnableSizing = True
         saveDlg.FileFormatsList = New RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.Default)

         If saveDlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _txtFileName.Text = saveDlg.FileName
            _nativeBPP = saveDlg.BitsPerPixel
            _imageLEADFormat = saveDlg.Format
         End If

         DialogResult = DialogResult.None
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _btnOK.Click
         Dim format As RasterImageFormat = RasterImageFormat.Tif
         Dim baseFileName As String = ""
         Dim multiPage As Boolean = True
         Dim bpp As Integer = 1

         Select Case _transferMode
            Case TwainTransferMode.File
               format = _format(_cmbFileFormats.SelectedIndex)
               If (Not _cmbFileFormats.Text.Equals("TIFF MULTI")) Then
                  multiPage = False
               End If
            Case TwainTransferMode.Buffer
               If _cbUseBufferSize.Checked AndAlso _txtBufferSize.Text = "0" Then
                  Messager.ShowError(Me, "Please, enter valid custom buffer size")
                  Return
               End If

               format = _format(_cmbFileFormats.SelectedIndex)
               bpp = _memoryFormatBPP(_cmbFileFormats.SelectedIndex)
               multiPage = _memoryFormatMulti(_cmbFileFormats.SelectedIndex)
            Case TwainTransferMode.Native
               format = _imageLEADFormat
               bpp = _nativeBPP
         End Select

         Hide()
         Try
            _session.EnableAcquireMultiPageEvent = False
            baseFileName = _txtFileName.Text

            _session.AcquireFast(baseFileName, TwainFastUserInterfaceFlags.Show Or TwainFastUserInterfaceFlags.Modal, _transferMode, format, bpp, multiPage, _bufferSize, (Not _cbUseBufferSize.Checked))
            Messager.ShowInformation(Me, "Process Completed")
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try

         DialogResult = System.Windows.Forms.DialogResult.OK
      End Sub

      Private Sub _txtFileName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)Handles _txtFileName.TextChanged
         Dim useBufferSize As Boolean = True
         If Me._cbUseBufferSize.Checked Then
            useBufferSize = (_txtBufferSize.Text <> "")
         End If

         _btnOK.Enabled = (_txtFileName.Text <> "" AndAlso useBufferSize)
      End Sub
   End Class
End Namespace
