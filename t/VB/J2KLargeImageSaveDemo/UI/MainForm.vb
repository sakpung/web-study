' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Imports Leadtools
Imports Leadtools.Codecs
Imports System.IO
Imports Leadtools.WinForms.CommonDialogs.File
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Leadtools.Demos.Dialogs

Namespace J2KLargeImageSaveDemo
   ''' <summary>
   ''' Summary description for MainForm.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private _mmMain As System.Windows.Forms.MainMenu
      Private _miFile As System.Windows.Forms.MenuItem
      Private WithEvents _miFileOpenSave As System.Windows.Forms.MenuItem
      Private WithEvents _miFileExit As System.Windows.Forms.MenuItem
      Private _miFileSep1 As System.Windows.Forms.MenuItem
      Private _miHelp As System.Windows.Forms.MenuItem
      Private WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
      Private _lblImageFileName As Label
      Private _lblImageDimensions As Label
      Private _lblImageBitsPerPixel As Label
      Private _lblCurrentRow As Label
      Private _lblStatus As Label
      Private WithEvents _btnCancel As Button
      Private _lblStatusValue As Label
      Private _lblCurrentRowValue As Label
      Private _lblImageBitsPerPixelValue As Label
      Private _lblDimensionValue As Label
      Private _lblFilenameValue As Label
      Private components As IContainer

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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._mmMain = New System.Windows.Forms.MainMenu(Me.components)
         Me._miFile = New System.Windows.Forms.MenuItem()
         Me._miFileOpenSave = New System.Windows.Forms.MenuItem()
         Me._miFileSep1 = New System.Windows.Forms.MenuItem()
         Me._miFileExit = New System.Windows.Forms.MenuItem()
         Me._miHelp = New System.Windows.Forms.MenuItem()
         Me._miHelpAbout = New System.Windows.Forms.MenuItem()
         Me._lblImageFileName = New System.Windows.Forms.Label()
         Me._lblImageDimensions = New System.Windows.Forms.Label()
         Me._lblImageBitsPerPixel = New System.Windows.Forms.Label()
         Me._lblCurrentRow = New System.Windows.Forms.Label()
         Me._lblStatus = New System.Windows.Forms.Label()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._lblStatusValue = New System.Windows.Forms.Label()
         Me._lblCurrentRowValue = New System.Windows.Forms.Label()
         Me._lblImageBitsPerPixelValue = New System.Windows.Forms.Label()
         Me._lblDimensionValue = New System.Windows.Forms.Label()
         Me._lblFilenameValue = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' _mmMain
         ' 
         Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miHelp})
         ' 
         ' _miFile
         ' 
         Me._miFile.Index = 0
         Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpenSave, Me._miFileSep1, Me._miFileExit})
         Me._miFile.Text = "&File"
         ' 
         ' _miFileOpenSave
         ' 
         Me._miFileOpenSave.Index = 0
         Me._miFileOpenSave.Shortcut = System.Windows.Forms.Shortcut.CtrlO
         Me._miFileOpenSave.Text = "&Open and Save..."
         ' 
         ' _miFileSep1
         ' 
         Me._miFileSep1.Index = 1
         Me._miFileSep1.Text = "-"
         ' 
         ' _miFileExit
         ' 
         Me._miFileExit.Index = 2
         Me._miFileExit.Text = "E&xit"
         ' 
         ' _miHelp
         ' 
         Me._miHelp.Index = 1
         Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
         Me._miHelp.Text = "&Help"
         ' 
         ' _miHelpAbout
         ' 
         Me._miHelpAbout.Index = 0
         Me._miHelpAbout.Text = "&About..."
         ' 
         ' _lblImageFileName
         ' 
         Me._lblImageFileName.AutoSize = True
         Me._lblImageFileName.Location = New System.Drawing.Point(26, 29)
         Me._lblImageFileName.Name = "_lblImageFileName"
         Me._lblImageFileName.Size = New System.Drawing.Size(92, 13)
         Me._lblImageFileName.TabIndex = 0
         Me._lblImageFileName.Text = "Image File Name: "
         ' 
         ' _lblImageDimensions
         ' 
         Me._lblImageDimensions.AutoSize = True
         Me._lblImageDimensions.Location = New System.Drawing.Point(26, 67)
         Me._lblImageDimensions.Name = "_lblImageDimensions"
         Me._lblImageDimensions.Size = New System.Drawing.Size(99, 13)
         Me._lblImageDimensions.TabIndex = 1
         Me._lblImageDimensions.Text = "Image Dimensions: "
         ' 
         ' _lblImageBitsPerPixel
         ' 
         Me._lblImageBitsPerPixel.AutoSize = True
         Me._lblImageBitsPerPixel.Location = New System.Drawing.Point(26, 107)
         Me._lblImageBitsPerPixel.Name = "_lblImageBitsPerPixel"
         Me._lblImageBitsPerPixel.Size = New System.Drawing.Size(106, 13)
         Me._lblImageBitsPerPixel.TabIndex = 2
         Me._lblImageBitsPerPixel.Text = "Image Bits Per Pixel: "
         ' 
         ' _lblCurrentRow
         ' 
         Me._lblCurrentRow.AutoSize = True
         Me._lblCurrentRow.Location = New System.Drawing.Point(26, 148)
         Me._lblCurrentRow.Name = "_lblCurrentRow"
         Me._lblCurrentRow.Size = New System.Drawing.Size(72, 13)
         Me._lblCurrentRow.TabIndex = 3
         Me._lblCurrentRow.Text = "Current Row: "
         ' 
         ' _lblStatus
         ' 
         Me._lblStatus.AutoSize = True
         Me._lblStatus.Location = New System.Drawing.Point(26, 188)
         Me._lblStatus.Name = "_lblStatus"
         Me._lblStatus.Size = New System.Drawing.Size(43, 13)
         Me._lblStatus.TabIndex = 4
         Me._lblStatus.Text = "Status: "
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.Location = New System.Drawing.Point(159, 223)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(179, 39)
         Me._btnCancel.TabIndex = 5
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _lblStatusValue
         ' 
         Me._lblStatusValue.AutoSize = True
         Me._lblStatusValue.Location = New System.Drawing.Point(138, 188)
         Me._lblStatusValue.Name = "_lblStatusValue"
         Me._lblStatusValue.Size = New System.Drawing.Size(22, 13)
         Me._lblStatusValue.TabIndex = 10
         Me._lblStatusValue.Text = "NA"
         ' 
         ' _lblCurrentRowValue
         ' 
         Me._lblCurrentRowValue.AutoSize = True
         Me._lblCurrentRowValue.Location = New System.Drawing.Point(138, 148)
         Me._lblCurrentRowValue.Name = "_lblCurrentRowValue"
         Me._lblCurrentRowValue.Size = New System.Drawing.Size(22, 13)
         Me._lblCurrentRowValue.TabIndex = 9
         Me._lblCurrentRowValue.Text = "NA"
         ' 
         ' _lblImageBitsPerPixelValue
         ' 
         Me._lblImageBitsPerPixelValue.AutoSize = True
         Me._lblImageBitsPerPixelValue.Location = New System.Drawing.Point(138, 107)
         Me._lblImageBitsPerPixelValue.Name = "_lblImageBitsPerPixelValue"
         Me._lblImageBitsPerPixelValue.Size = New System.Drawing.Size(22, 13)
         Me._lblImageBitsPerPixelValue.TabIndex = 8
         Me._lblImageBitsPerPixelValue.Text = "NA"
         ' 
         ' _lblDimensionValue
         ' 
         Me._lblDimensionValue.AutoSize = True
         Me._lblDimensionValue.Location = New System.Drawing.Point(138, 67)
         Me._lblDimensionValue.Name = "_lblDimensionValue"
         Me._lblDimensionValue.Size = New System.Drawing.Size(22, 13)
         Me._lblDimensionValue.TabIndex = 7
         Me._lblDimensionValue.Text = "NA"
         ' 
         ' _lblFilenameValue
         ' 
         Me._lblFilenameValue.AutoSize = True
         Me._lblFilenameValue.Location = New System.Drawing.Point(138, 29)
         Me._lblFilenameValue.Name = "_lblFilenameValue"
         Me._lblFilenameValue.Size = New System.Drawing.Size(22, 13)
         Me._lblFilenameValue.TabIndex = 6
         Me._lblFilenameValue.Text = "NA"
         ' 
         ' MainForm
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(528, 269)
         Me.Controls.Add(Me._lblStatusValue)
         Me.Controls.Add(Me._lblCurrentRowValue)
         Me.Controls.Add(Me._lblImageBitsPerPixelValue)
         Me.Controls.Add(Me._lblDimensionValue)
         Me.Controls.Add(Me._lblFilenameValue)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._lblStatus)
         Me.Controls.Add(Me._lblCurrentRow)
         Me.Controls.Add(Me._lblImageBitsPerPixel)
         Me.Controls.Add(Me._lblImageDimensions)
         Me.Controls.Add(Me._lblImageFileName)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MaximizeBox = False
         Me.Menu = Me._mmMain
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "J2KLargeImageSave Demo"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
#End Region

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main()
         
         If Not Support.SetLicense() Then
            Return
         End If

         Application.Run(New MainForm())
      End Sub

      Private bCompressing As Boolean = False
      Private bCancel As Boolean = False
      Private outputFile As FileStream = Nothing
      Private bytesPerLine As Int32 = 0
      Private _openInitialPath As String = ""

      ''' <summary>
      ''' Initialize the Application.
      ''' </summary>
      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Messager.Caption = "VB.NET J2KLargeImageSave Demo"
         Text = Messager.Caption

         UpdateMyControls()
      End Sub

      ''' <summary>
      ''' Update the UI depending on the program state
      ''' </summary>
      Private Sub UpdateMyControls()
         _btnCancel.Enabled = bCompressing
         _miFileOpenSave.Enabled = Not bCompressing
      End Sub

      ''' <summary>
      ''' Load a new image
      ''' </summary>
      Private Sub _miFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileOpenSave.Click

         Dim _codecs As RasterCodecs = Nothing
         Dim imageInfo As CodecsImageInfo = Nothing
         Try

            ' initialize the codecs object.
            _codecs = New RasterCodecs()
            ' Since we are dealing with large images, we do not want to allocate the entire image. We are only going to load it row by row
            _codecs.Options.Load.AllocateImage = False
            _codecs.Options.Load.StoreDataInImage = False
            AddHandler _codecs.LoadImage, AddressOf codecs_LoadImage

            ' load the image
            Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
            openFileDialog.Title = "Open File"
            openFileDialog.Multiselect = False
            openFileDialog.InitialDirectory = _openInitialPath
            If openFileDialog.ShowDialog() = DialogResult.OK Then
               _openInitialPath = Path.GetDirectoryName(openFileDialog.FileName)
               'Check if image is valid for this demo
               imageInfo = _codecs.GetInformation(openFileDialog.FileName, False)
               If (Not IsImageValid(imageInfo)) Then
                  Messager.ShowError(Me, "The input image has to be 8-bit Gray scale, 12-bit Gray scale, 16-bit Gray scale, RGB (color), and TopLeft view perspective." & " This DEMO is not meant to be used with small or palletized images (like GIF, PNG, or 1-bit images)." & " Use this DEMO to save large dimension images efficiently using JPEG2000 compression.")
                  Return
               End If

               Using saveDialog As RasterSaveDialog = New RasterSaveDialog(_codecs)
                  saveDialog.AutoProcess = False
                  saveDialog.Title = "Save As"
                  saveDialog.ShowFileOptionsBasicJ2kOptions = True
                  saveDialog.ShowFileOptionsJ2kOptions = True
                  saveDialog.ShowOptions = True
                  saveDialog.ShowQualityFactor = True
                  saveDialog.ShowFileOptionsProgressive = True
                  saveDialog.ShowFileOptionsStamp = True
                  saveDialog.QualityFactor = 20
                  SetupFormats(saveDialog)

                  If saveDialog.ShowDialog(Me) <> DialogResult.OK Then
                     Return
                  End If

                  _lblFilenameValue.Text = Path.GetFileName(openFileDialog.FileName)
                  _lblDimensionValue.Text = String.Format("{0} x {1}", imageInfo.Width, imageInfo.Height)
                  _lblImageBitsPerPixelValue.Text = imageInfo.BitsPerPixel.ToString()

                  'Get the selected compression type
                  Dim selectedCompression As CodecsCompression
                  If saveDialog.Format = RasterImageFormat.J2k Then
                     selectedCompression = CodecsCompression.J2k
                  Else
                     selectedCompression = CodecsCompression.Jp2
                  End If

                  Dim rasterByteOrder As RasterByteOrder
                  If ((saveDialog.BitsPerPixel = 12) OrElse (saveDialog.BitsPerPixel = 16)) Then
                     rasterByteOrder = rasterByteOrder.Gray
                  Else
                     rasterByteOrder = rasterByteOrder.Bgr
                  End If
                  Dim codecsLoadByteOrder As CodecsLoadByteOrder
                  If ((saveDialog.BitsPerPixel = 12) OrElse (saveDialog.BitsPerPixel = 16)) Then
                     codecsLoadByteOrder = codecsLoadByteOrder.Gray
                  Else
                     codecsLoadByteOrder = codecsLoadByteOrder.Bgr
                  End If

                  bytesPerLine = CalculateBytesPerLine(saveDialog.BitsPerPixel, imageInfo.Width)

                  _codecs.Options.Jpeg.Save.QualityFactor = saveDialog.QualityFactor
                  _codecs.Options.Jpeg.Save.Passes = saveDialog.Passes

                  _codecs.Options.Jpeg.Save.SaveWithStamp = saveDialog.WithStamp
                  _codecs.Options.Jpeg.Save.StampWidth = saveDialog.StampWidth
                  _codecs.Options.Jpeg.Save.StampHeight = saveDialog.StampHeight
                  _codecs.Options.Jpeg.Save.StampBitsPerPixel = saveDialog.StampBitsPerPixel

                  _codecs.Options.Jpeg2000.Save.CompressionControl = saveDialog.FileJ2kOptions.CompressionControl
                  _codecs.Options.Jpeg2000.Save.CompressionRatio = saveDialog.FileJ2kOptions.CompressionRatio
                  _codecs.Options.Jpeg2000.Save.DecompositionLevels = saveDialog.FileJ2kOptions.DecompositionLevels
                  _codecs.Options.Jpeg2000.Save.DerivedQuantization = saveDialog.FileJ2kOptions.DerivedQuantization
                  _codecs.Options.Jpeg2000.Save.ImageAreaHorizontalOffset = saveDialog.FileJ2kOptions.ImageAreaHorizontalOffset
                  _codecs.Options.Jpeg2000.Save.ImageAreaVerticalOffset = saveDialog.FileJ2kOptions.ImageAreaVerticalOffset
                  _codecs.Options.Jpeg2000.Save.ProgressingOrder = saveDialog.FileJ2kOptions.ProgressingOrder
                  _codecs.Options.Jpeg2000.Save.ReferenceTileHeight = saveDialog.FileJ2kOptions.ReferenceTileHeight
                  _codecs.Options.Jpeg2000.Save.ReferenceTileWidth = saveDialog.FileJ2kOptions.ReferenceTileWidth
                  _codecs.Options.Jpeg2000.Save.RegionOfInterest = saveDialog.FileJ2kOptions.RegionOfInterest
                  _codecs.Options.Jpeg2000.Save.RegionOfInterestRectangle = saveDialog.FileJ2kOptions.RegionOfInterestRectangle
                  _codecs.Options.Jpeg2000.Save.RegionOfInterestWeight = saveDialog.FileJ2kOptions.RegionOfInterestWeight
                  _codecs.Options.Jpeg2000.Save.TargetFileSize = saveDialog.FileJ2kOptions.TargetFileSize
                  _codecs.Options.Jpeg2000.Save.TileHorizontalOffset = saveDialog.FileJ2kOptions.TileHorizontalOffset
                  _codecs.Options.Jpeg2000.Save.TileVerticalOffset = saveDialog.FileJ2kOptions.TileVerticalOffset
                  _codecs.Options.Jpeg2000.Save.UseColorTransform = saveDialog.FileJ2kOptions.UseColorTransform
                  _codecs.Options.Jpeg2000.Save.UseEphMarker = saveDialog.FileJ2kOptions.UseEphMarker
                  _codecs.Options.Jpeg2000.Save.UseRegionOfInterest = saveDialog.FileJ2kOptions.UseRegionOfInterest
                  _codecs.Options.Jpeg2000.Save.UseSopMarker = saveDialog.FileJ2kOptions.UseSopMarker

                  bCancel = False
                  bCompressing = True
                  UpdateMyControls()

                  Try
                     'Start Compressing
                     outputFile = File.Create(saveDialog.FileName)
                     _codecs.StartCompress(imageInfo.Width, imageInfo.Height, saveDialog.BitsPerPixel, rasterByteOrder, RasterViewPerspective.TopLeft, bytesPerLine, IntPtr.Zero, 0, selectedCompression, AddressOf MyCodecsCompressDataCallback)
                     _codecs.Load(openFileDialog.FileName, saveDialog.BitsPerPixel, codecsLoadByteOrder, 1, 1)
                     _codecs.StopCompress()

                     If bCancel Then
                        _lblStatusValue.Text = "Aborted"
                     Else
                        _lblStatusValue.Text = "Complete"
                     End If
                  Finally
                     If Not outputFile Is Nothing Then
                        outputFile.Close()
                     End If
                  End Try
               End Using
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            _lblStatusValue.Text = "Error"
         Finally
            If Not _codecs Is Nothing Then
               _codecs.Dispose()
            End If

            If Not imageInfo Is Nothing Then
               imageInfo.Dispose()
            End If
            bCompressing = False
            UpdateMyControls()
         End Try
      End Sub

      Private Function CalculateBytesPerLine(ByVal bitsPerPixel As Integer, ByVal imageWidth As Integer) As Integer
         Dim bitsPerLine As Integer = bitsPerPixel * imageWidth
         Dim bytesPerLine As Double = bitsPerLine / 8

         'Round up to nearest multiple of 4
         Return CInt(Math.Ceiling(bytesPerLine / 4.0)) * 4
      End Function

      ''' <summary>
      ''' Load Image callback. This is called as the image is decompressed
      ''' </summary>
      Private Sub codecs_LoadImage(ByVal sender As Object, ByVal e As CodecsLoadImageEventArgs)
         Dim lineBuffer As IntPtr = e.Buffer.Data
         Dim i As Integer = 0
         Do While i < e.Lines
            If bCancel Then
               e.Cancel = True
               Return
            End If

            Try
               Dim _codecs As RasterCodecs = CType(sender, RasterCodecs)
               _codecs.Compress(lineBuffer)
               lineBuffer = New IntPtr(lineBuffer.ToInt64() + bytesPerLine)
               UpdateStatus(e.Row, e.TotalPercent)
            Catch ex As Exception
               Messager.ShowError(Me, ex.Message)
               e.Cancel = True
               Return
            End Try

            Application.DoEvents()
            i += 1
         Loop
      End Sub

      ''' <summary>
      ''' Called when compressed data is available
      ''' </summary>
      Private Function MyCodecsCompressDataCallback(ByVal width As Integer, ByVal height As Integer, ByVal bitsPerPixel As Integer, ByVal order As RasterByteOrder, ByVal viewPerspective As RasterViewPerspective, ByVal buffer As RasterNativeBuffer) As Boolean
         ' Write compressed data to the file 
         Dim dataBuffer As Byte() = New Byte(CInt(buffer.Length) - 1) {}
         Marshal.Copy(buffer.Data, dataBuffer, 0, CInt(buffer.Length))
         outputFile.Write(dataBuffer, 0, CInt(buffer.Length))

         Return True
      End Function

      ''' <summary>
      ''' Cancel Save Process
      ''' </summary>
      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         bCancel = True
      End Sub

      Private Sub UpdateStatus(ByVal currentRow As Integer, ByVal currentProgress As Integer)
         _lblCurrentRowValue.Text = (currentRow + 1).ToString()
         _lblStatusValue.Text = String.Format("{0} %", currentProgress)
      End Sub

      ''' <summary>
      ''' Shutdown
      ''' </summary>
      Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
         Close()
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
         If bCompressing Then
            If Messager.Show(Me, "Would you like to cancel the current operation?", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) = DialogResult.No Then
               e.Cancel = True
               Return
            Else
               _btnCancel_Click(Me, Nothing)
            End If
         End If
      End Sub

      ''' <summary>
      ''' show the about dialog
      ''' </summary>
      Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
         Using aboutDialog As New AboutDialog("J2K Large Image Save", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Function IsImageValid(ByVal imageInfo As CodecsImageInfo) As Boolean
         Dim imageValid As Boolean = False

         Select Case imageInfo.BitsPerPixel
            Case 32, 24, 16, 12, 8
               imageValid = True
            Case Else
               imageValid = False
         End Select

         Return (imageValid AndAlso imageInfo.ViewPerspective = RasterViewPerspective.TopLeft)
      End Function

      Private Sub SetupFormats(ByVal saveDialog As RasterSaveDialog)
         saveDialog.FileFormatsList = New RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.User)
         saveDialog.FileFormatsList.Add(RasterDialogFileTypesIndex.Jpeg2000, RasterDialogBitsPerPixelDataContent.User)

         Dim saveBBP As Integer() = New Integer() {8, 12, 16, 24, 32}
         Dim i As Integer = 0
         Do While i < saveBBP.Length
            saveDialog.FileFormatsList(0).BitsPerPixelList.Add(RasterDialogFileTypesIndex.Jpeg2000, saveBBP(i), RasterDialogFileSubTypeDataContent.User)
            saveDialog.FileFormatsList(0).BitsPerPixelList(i).SubFormatsList.Add(RasterDialogFileTypesIndex.Jpeg2000, saveBBP(i), CInt(RasterDialogJ2kSubTypesIndex.Jpeg2000File))
            saveDialog.FileFormatsList(0).BitsPerPixelList(i).SubFormatsList.Add(RasterDialogFileTypesIndex.Jpeg2000, saveBBP(i), CInt(RasterDialogJ2kSubTypesIndex.Jpeg2000Stream))
            i += 1
         Loop
      End Sub
   End Class
End Namespace
