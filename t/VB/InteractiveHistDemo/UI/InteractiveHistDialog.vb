' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Core

Public Class InteractiveHistDialog

   Public Sub New(ByVal mainForm As MainForm)
      _mainForm = mainForm

      applyImage = New RasterImage(ChildImage)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.

      InitClass()
   End Sub

   Private _interactiveHistogramData As HistogramData.InteractiveHistogramDialogData
   Private applyImage As RasterImage
   Private _mainForm As MainForm
   Private _cancelRun As Boolean
   Private _doApply As Boolean
   Private _hsRange As System.Windows.Forms.HScrollBar

   Private Sub InitClass()
      ' Create and initialize an HScrollBar and add it to the end of the Histogram Label.
      _hsRange = New HScrollBar()
      _hsRange.Dock = DockStyle.Bottom
      AddHandler _hsRange.Scroll, AddressOf _hsRange_Scroll
      _lblHistogram.Controls.Add(_hsRange)

      ' Set the globales selection index for the dilaog combo boxes...
      _cbChannel.SelectedIndex = 0

      ' Initialize the values of the Interactive Histogram Data Structure...
      _interactiveHistogramData = New HistogramData.InteractiveHistogramDialogData()

      ReDim _interactiveHistogramData.cD(3)
      _interactiveHistogramData.fullView = False
      _interactiveHistogramData.channel = RasterColorChannel.Master

      _interactiveHistogramData.histogramLabel = New HistogramData.HistogramLabel()
      _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNone
      _interactiveHistogramData.histogramLabel.drawLength = 256
      ReDim _interactiveHistogramData.histogramLabel.drawHistogram(255)
      _interactiveHistogramData.histogramLabel.drawStartRange = 0
      _interactiveHistogramData.histogramLabel.drawEndRange = 255

      Dim checkGray As Boolean = (ChildImage.GrayscaleMode = RasterGrayscaleMode.None) AndAlso (IsNothing(ChildImage.GetLookupTable()))

      _interactiveHistogramData.histogramLabel.histogramLength = GetHistogramlength(ChildImage.BitsPerPixel, ChildImage.LowBit, ChildImage.HighBit, checkGray, ChildImage.Signed)

      SetMinMaxValues(_interactiveHistogramData.histogramLabel.histogramLength)

      _interactiveHistogramData.pushed = True
      _interactiveHistogramData.distance = _tabOptions.Height + _grpStatisticalInformation.Height + _lblHelp.Height
      _interactiveHistogramData.signed = ChildImage.Signed
      _interactiveHistogramData.histogramLabel.startRange = 0
      _interactiveHistogramData.histogramLabel.endRange = _interactiveHistogramData.histogramLabel.histogramLength - 1
      _interactiveHistogramData.letApplyOnPallete = True
      _interactiveHistogramData.scale = CInt(_interactiveHistogramData.histogramLabel.histogramLength / 256)

      If (_interactiveHistogramData.signed) Then
         _interactiveHistogramData.histogramLabel.startRange = CInt(_interactiveHistogramData.histogramLabel.startRange - (_interactiveHistogramData.histogramLabel.histogramLength / 2))
         _interactiveHistogramData.histogramLabel.endRange = CInt(_interactiveHistogramData.histogramLabel.endRange - (_interactiveHistogramData.histogramLabel.histogramLength / 2))
      End If

      _interactiveHistogramData.image = ChildImage.CloneAll()
      _interactiveHistogramData.originalImage = ChildImage.CloneAll()
      _interactiveHistogramData.savedImage = ChildImage.CloneAll()

      ' Disable the Apply to LUT button if the image doesn't use LUT...
      If (_interactiveHistogramData.originalImage.UseLookupTable) Then
         _interactiveHistogramData.originalLUT = ChildImage.GetLookupTable()
         EnableApplyLUT(True)
      Else
         EnableApplyLUT(False)
      End If

      ' Disable the channels combo if the image is grayscale...
      _cbChannel.Enabled = (ChildImage.GrayscaleMode = RasterGrayscaleMode.None)

      ' Disable the Undo button...
      _btnUndo.Enabled = False

      _interactiveHistogramData.gradient = True
      _interactiveHistogramData.shift = True
      _interactiveHistogramData.shiftRight = True
      _interactiveHistogramData.rescaleShiftAmount = 0

      If (_interactiveHistogramData.histogramLabel.histogramLength <> 256) Then
         _hsRange.Minimum = _interactiveHistogramData.histogramLabel.startRange
         _hsRange.Maximum = _interactiveHistogramData.histogramLabel.endRange - 256 + 9
         _hsRange.Value = _interactiveHistogramData.histogramLabel.startRange
      Else
         _hsRange.Visible = False
      End If

      InitLUTArrays(_interactiveHistogramData.histogramLabel.histogramLength - 1)

      If (ChildImage.UseLookupTable) Then
         Dim lut() As RasterColor = ChildImage.GetLookupTable()
         Array.Copy(lut, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBPrevLUT, lut.Length)
      End If

      ' Initialize the values of the options structures...
      InitialChannelData(0, GetColorFromRasterColor(New RasterColor(96, 96, 96)), GetColorFromRasterColor(New RasterColor(160, 160, 160)), _interactiveHistogramData.histogramLabel.histogramLength)
      InitialChannelData(1, GetColorFromRasterColor(New RasterColor(128, 0, 0)), GetColorFromRasterColor(New RasterColor(255, 0, 0)), _interactiveHistogramData.histogramLabel.histogramLength)
      InitialChannelData(2, GetColorFromRasterColor(New RasterColor(0, 128, 0)), GetColorFromRasterColor(New RasterColor(0, 255, 0)), _interactiveHistogramData.histogramLabel.histogramLength)
      InitialChannelData(3, GetColorFromRasterColor(New RasterColor(0, 0, 128)), GetColorFromRasterColor(New RasterColor(0, 0, 255)), _interactiveHistogramData.histogramLabel.histogramLength)

      ReDim _interactiveHistogramData.applyInProgress(3)
      _interactiveHistogramData.applyInProgress(0) = True
      _interactiveHistogramData.applyInProgress(1) = True
      _interactiveHistogramData.applyInProgress(2) = True
      _interactiveHistogramData.applyInProgress(3) = True

      _doApply = False
      ' Segmentation options...
      ' Set the range for the controls...
      Dim value As Integer
      value = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).segmentation.startLine.position
      _nudSegStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
      _nudSegStartPt.Maximum = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).segmentation.endLine.position - 1
      _nudSegStartPt.Value = value

      value = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).segmentation.endLine.position
      _nudSegEndPt.Minimum = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).segmentation.startLine.position + 1
      _nudSegEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange
      _nudSegEndPt.Value = value

      ' Initial the global variables...
      _interactiveHistogramData.segmentStartColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black)
      _interactiveHistogramData.segmentEndColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White)
      _rbSegGradient.Checked = True

      ' Gray Distribution.
      ' Set the range for the controls...
      value = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).grayDistribution.startLine.position
      _nudGrayStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
      _nudGrayStartPt.Maximum = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).grayDistribution.endLine.position - 1
      _nudGrayStartPt.Value = value

      value = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).grayDistribution.endLine.position
      _nudGrayEndPt.Minimum = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).grayDistribution.startLine.position + 1
      _nudGrayEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange
      _nudGrayEndPt.Value = value

      ' Initial the global variables...
      _interactiveHistogramData.grayFactor = 0
      _interactiveHistogramData.grayCenter = CInt(_interactiveHistogramData.histogramLabel.histogramLength / 2)
      _interactiveHistogramData.grayWidth = _interactiveHistogramData.histogramLabel.histogramLength - 1
      _interactiveHistogramData.graySelectionOnly = False
      _interactiveHistogramData.grayStartColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black)
      _interactiveHistogramData.grayEndColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White)

      value = _interactiveHistogramData.grayFactor
      _nudGrayFactor.Minimum = -1000
      _nudGrayFactor.Maximum = 1000
      _nudGrayFactor.Value = value

      _txtGrayCenter.Text = _interactiveHistogramData.grayCenter.ToString()
      _txtGrayWidth.Text = _interactiveHistogramData.grayWidth.ToString()
      _cbGrayFunctionType.SelectedIndex = 2

      ' Filter (Noise).
      ' Set the range for the controls...
      value = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).filterNoise.startLine.position
      _nudNoiseStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
      _nudNoiseStartPt.Maximum = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).filterNoise.endLine.position - 1
      _nudNoiseStartPt.Value = value

      value = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).filterNoise.endLine.position
      _nudNoiseEndPt.Minimum = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).filterNoise.startLine.position + 1
      _nudNoiseEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange
      _nudNoiseEndPt.Value = value

      ' Initial the global variables...
      _interactiveHistogramData.noiseReplaceType = 0
      _cbNoiseReplaceWith.SelectedIndex = CInt(_interactiveHistogramData.noiseReplaceType)
      _interactiveHistogramData.noiseReplaceColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black)

      ' Rescaling.
      ' Set the range for the controls...
      value = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).rescale.startLine.position
      _nudResStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
      _nudResStartPt.Maximum = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).rescale.endLine.position - 1
      _nudResStartPt.Value = value

      value = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).rescale.endLine.position
      _nudResEndPt.Minimum = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).rescale.startLine.position + 1
      _nudResEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange
      _nudResEndPt.Value = value

      value = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).rescale.newStartLine.position
      _nudResNewStart.Minimum = _interactiveHistogramData.histogramLabel.startRange
      _nudResNewStart.Maximum = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).rescale.newEndLine.position - 1
      _nudResNewStart.Value = value

      value = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).rescale.newEndLine.position
      _nudResNewEnd.Minimum = _interactiveHistogramData.cD(_cbChannel.SelectedIndex).rescale.newStartLine.position + 1
      _nudResNewEnd.Maximum = _interactiveHistogramData.histogramLabel.endRange
      _nudResNewEnd.Value = value

      _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.prevEndHist.position = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newEndLine.position

      _nudResShiftAmount.Minimum = -2000000
      _nudResShiftAmount.Maximum = 2000000
      _nudResShiftAmount.Value = _interactiveHistogramData.rescaleShiftAmount

      If (_interactiveHistogramData.signed) Then
         _lblSegStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.startLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
         _lblSegEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.endLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()

         _lblGryStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.startLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
         _lblGryEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.endLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()

         _lblNoiseStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.startLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
         _lblNoiseEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.endLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()

         _lblResStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.startLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
         _lblResEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.endLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
      Else
         _lblSegStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.startLine.position)).ToString()
         _lblSegEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.endLine.position)).ToString()

         _lblGryStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.startLine.position)).ToString()
         _lblGryEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.endLine.position)).ToString()

         _lblNoiseStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.startLine.position)).ToString()
         _lblNoiseEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.endLine.position)).ToString()

         _lblResStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.startLine.position)).ToString()
         _lblResEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.endLine.position)).ToString()
      End If

      ' Initial the global variables...
      _interactiveHistogramData.shift = True
      _interactiveHistogramData.shiftRight = True
      _interactiveHistogramData.rescaleShiftAmount = 0
      _rbResShift.Checked = _interactiveHistogramData.shift
      _rbResShiftRight.Checked = _interactiveHistogramData.shiftRight

      ' Apply to all channels...
      _interactiveHistogramData.histogramAvaliable = True
      Dim index As Integer
      Dim result As Integer
      For index = 1 To 3
         _interactiveHistogramData.getHistogram = True
         _interactiveHistogramData.channel = CType(index, RasterColorChannel)

         result = ApplyFilter()
         DrawChanges()
      Next index

      ApplyInProgress(True)

      ReDim _interactiveHistogramData.predefinedPalette(255)

      _interactiveHistogramData.channel = RasterColorChannel.Master
      _interactiveHistogramData.getHistogram = True
      result = ApplyFilter()
      ' if (result = 1)
      DrawChanges()
      _cbSelectionType.SelectedIndex = 0

      If (Not _interactiveHistogramData.histogramAvaliable) Then
         Messager.ShowError(Me, "Error occur while initializing the hisogram. The histogram graph will not be available.")
      End If

      ' Initial data needed for drawing on the label...
      _interactiveHistogramData.histogramLabel.paint = _
         New Rectangle(25, _
                       0, _
                       _lblHistogram.Width + 25 + 25, _
                       _lblHistogram.Height - 25 - 10)

      _hsRange.Value = _interactiveHistogramData.histogramLabel.startRange
      _hsRange.Enabled = False
      _hsRange.Visible = (_interactiveHistogramData.histogramLabel.histogramLength <> 256)

      _interactiveHistogramData.histogramLabel.zoomed = False

      ' Initial the controls to the enable status...
      _nudGrayFactor.Enabled = False
      _btnNoiseReplaceColor.Enabled = False

      ' Set the colors of the color labels...
      _lblInner.BackColor = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).innerColor
      _lblOuter.BackColor = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).outerColor

      Dim clr As Integer = GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.startLine.position)
      _lblSegStartPtClr.BackColor = Color.FromArgb(clr, clr, clr)
      clr = GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.endLine.position)
      _lblSegEndPtClr.BackColor = Color.FromArgb(clr, clr, clr)

      clr = GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.startLine.position)
      _lblGrayStartPtClr.BackColor = Color.FromArgb(clr, clr, clr)
      clr = GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.endLine.position)
      _lblGrayEndPtClr.BackColor = Color.FromArgb(clr, clr, clr)

      clr = GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.startLine.position)
      _lblNoiseStartPtClr.BackColor = Color.FromArgb(clr, clr, clr)
      clr = GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.endLine.position)
      _lblNoiseEndPtClr.BackColor = Color.FromArgb(clr, clr, clr)

      clr = GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.startLine.position)
      _lblResStartPtClr.BackColor = Color.FromArgb(clr, clr, clr)
      clr = GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.endLine.position)
      _lblResEndPtClr.BackColor = Color.FromArgb(clr, clr, clr)

      _lblSegStartColor.BackColor = GetColorFromRasterColor(_interactiveHistogramData.segmentStartColor)
      _lblSegEndColor.BackColor = GetColorFromRasterColor(_interactiveHistogramData.segmentEndColor)

      _lblGrayStartColor.BackColor = GetColorFromRasterColor(_interactiveHistogramData.grayStartColor)
      _lblGrayEndColor.BackColor = GetColorFromRasterColor(_interactiveHistogramData.grayEndColor)

      _lblNoiseReplaceColor.BackColor = GetColorFromRasterColor(_interactiveHistogramData.noiseReplaceColor)

      _lblHelp.Visible = False
      _MainProgressBar.Value = 0

      If (_interactiveHistogramData.signed) Then
         _lblSegStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetStart() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
         _lblSegEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetEnd() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
      Else
         _lblSegStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetStart())).ToString()
         _lblSegEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetEnd())).ToString()
      End If

      _mainForm.Cursor = Cursors.Arrow
      _doApply = True
   End Sub

   Private Sub ApplyInProgress(ByVal apply As Boolean)
      _doApply = False
      _chkSegApplyInProgress.Checked = apply
      _chkGrayApplyInProgress.Checked = apply
      _chkNoiseApplyInProgress.Checked = apply
      _chkResApplyInProgress.Checked = apply
      _doApply = True
   End Sub

   Private Property ChildImage() As RasterImage
      Get
         Return (_mainForm.ActiveViewerForm.Viewer.Image)
      End Get

      Set(ByVal value As RasterImage)
         _mainForm.ActiveViewerForm.Viewer.Image = value
      End Set
   End Property

   Public ReadOnly Property OriginalImage() As RasterImage
      Get
         Return (_interactiveHistogramData.originalImage)
      End Get
   End Property

   Private Sub ConVertToLutValue(ByVal refImage As RasterImage, ByRef pStart As Integer, ByRef pEnd As Integer)
      Dim nFactor As Integer

      nFactor = refImage.HighBit - 7
      If (refImage.Signed) Then
         Dim nMiddle As Integer = CInt((refImage.GetLookupTable()).Length / 2)
         If (pStart < 0) Then
            pStart += nMiddle
         End If
         If (pEnd < 0) Then
            pEnd += nMiddle
         End If
      End If
      pStart >>= nFactor
      pEnd >>= nFactor
   End Sub


   Private Sub _hsRange_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs)
      Dim position As Integer = e.NewValue

      _interactiveHistogramData.histogramLabel.drawStartRange = position
      _interactiveHistogramData.histogramLabel.drawEndRange = position + 256

      _lblHistogram.Invalidate(True)
   End Sub

   Private Sub SetStatisticalValue()
      Dim startPoint As Integer = 0
      Dim endPoint As Integer = 0

      Select Case (_cbSelectionType.SelectedIndex)
         Case 0
            If (_interactiveHistogramData.signed) Then
               startPoint = _interactiveHistogramData.histogramLabel.startRange + Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
            Else
               startPoint = _interactiveHistogramData.histogramLabel.startRange
            End If

            If (_interactiveHistogramData.signed) Then
               endPoint = _interactiveHistogramData.histogramLabel.endRange + Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
            Else
               endPoint = _interactiveHistogramData.histogramLabel.endRange
            End If

         Case 1
            If (_interactiveHistogramData.signed) Then
               startPoint = GetStart() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
            Else
               startPoint = GetStart()
            End If
            If (_interactiveHistogramData.signed) Then
               endPoint = GetEnd() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
            Else
               endPoint = GetEnd()
            End If

         Case 2
            If (_interactiveHistogramData.signed) Then
               startPoint = _interactiveHistogramData.histogramLabel.startRange + Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
            Else
               startPoint = _interactiveHistogramData.histogramLabel.startRange
            End If

            If (_interactiveHistogramData.signed) Then
               endPoint = GetStart() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
            Else
               endPoint = GetStart()
            End If

         Case 3
            If (_interactiveHistogramData.signed) Then
               startPoint = GetEnd() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
            Else
               startPoint = GetEnd()
            End If

            If (_interactiveHistogramData.signed) Then
               endPoint = _interactiveHistogramData.histogramLabel.endRange + Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
            Else
               endPoint = _interactiveHistogramData.histogramLabel.endRange
            End If
      End Select

      If (_interactiveHistogramData.originalImage.UseLookupTable) Then
         ConVertToLutValue(_interactiveHistogramData.originalImage, startPoint, endPoint)
      End If

      Dim cmd As New StatisticsInformationCommand()

      cmd.Channel = _interactiveHistogramData.channel
      cmd.Start = startPoint
      cmd.End = endPoint
      AddHandler cmd.Progress, AddressOf cmd_Progress
      cmd.Run(_interactiveHistogramData.originalImage)

      ' Set the selection statistical information...
      _lblSelCount.Text = cmd.PixelCount.ToString()
      _lblSelPercent.Text = DoubleToString(cmd.Percent, 2)
      _lblSelMean.Text = DoubleToString(cmd.Mean, 2)
      _lblSelStdDev.Text = DoubleToString(cmd.StandardDeviation, 2)
      _lblSelMedian.Text = cmd.Median.ToString()

      Select Case (_cbSelectionType.SelectedIndex)
         Case 0
            _lblSelLevel.Text = String.Format("{0} to {1}", _interactiveHistogramData.histogramLabel.startRange, _interactiveHistogramData.histogramLabel.endRange)
         Case 1
            _lblSelLevel.Text = String.Format("{0} to {1}", GetStart(), GetEnd())
         Case 2
            _lblSelLevel.Text = String.Format("{0} to {1}", 0, GetStart())
         Case 3
            _lblSelLevel.Text = String.Format("{0} to {1}", GetEnd(), _interactiveHistogramData.histogramLabel.endRange)
      End Select

      _interactiveHistogramData.cD(_cbChannel.SelectedIndex).minHistogramValue = cmd.Minimum
      _interactiveHistogramData.cD(_cbChannel.SelectedIndex).maxHistogramValue = cmd.Maximum

      _MainProgressBar.Value = 0
   End Sub

   Private Function DoubleToString(ByVal value As Double, ByVal digits As UInt32) As String
      Dim factor As Double = 10.0 * digits

      Return ((CInt(value * factor)) / factor).ToString()
   End Function

   Private Function GetRealVal(ByVal value As Integer) As Integer
      Dim temp As Integer

      If (_interactiveHistogramData.signed) Then
         temp = value + Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
      Else
         temp = value
      End If
      Return CInt(temp / _interactiveHistogramData.scale)
   End Function

   Private Function SetRealVal(ByVal value As Integer) As Integer
      Dim temp As Integer

      temp = value * _interactiveHistogramData.scale
      If (_interactiveHistogramData.signed) Then
         Return temp - Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
      Else
         Return temp
      End If
   End Function

   Private Function SetRealVal_MouseMove(ByVal value As Integer) As Integer
      Dim temp As Integer

      temp = value * _interactiveHistogramData.scale
      If (_interactiveHistogramData.signed) Then
         temp = temp - Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
      End If

      temp = Math.Max(_interactiveHistogramData.histogramLabel.startRange, Math.Min(temp, _interactiveHistogramData.histogramLabel.endRange))
      Return temp
   End Function

   Private Function GetStart() As Integer
      Select Case (_tabOptions.SelectedIndex)
         Case 0
            Return (_interactiveHistogramData.cD(_cbChannel.SelectedIndex).segmentation.startLine.position)
         Case 1
            Return (_interactiveHistogramData.cD(_cbChannel.SelectedIndex).grayDistribution.startLine.position)
         Case 2
            Return (_interactiveHistogramData.cD(_cbChannel.SelectedIndex).filterNoise.startLine.position)
         Case 3
            Return (_interactiveHistogramData.cD(_cbChannel.SelectedIndex).rescale.startLine.position)
      End Select
      Return 0
   End Function

   Private Sub SetStart(ByVal startLine As Integer)
      Select Case (_tabOptions.SelectedIndex)
         Case 0
            _interactiveHistogramData.cD(_cbChannel.SelectedIndex).segmentation.startLine.position = startLine
         Case 1
            _interactiveHistogramData.cD(_cbChannel.SelectedIndex).grayDistribution.startLine.position = startLine
         Case 2
            _interactiveHistogramData.cD(_cbChannel.SelectedIndex).filterNoise.startLine.position = startLine
         Case 3
            _interactiveHistogramData.cD(_cbChannel.SelectedIndex).rescale.startLine.position = startLine
      End Select
   End Sub

   Private Function GetEnd() As Integer
      Select Case (_tabOptions.SelectedIndex)
         Case 0
            Return (_interactiveHistogramData.cD(_cbChannel.SelectedIndex).segmentation.endLine.position)
         Case 1
            Return (_interactiveHistogramData.cD(_cbChannel.SelectedIndex).grayDistribution.endLine.position)
         Case 2
            Return (_interactiveHistogramData.cD(_cbChannel.SelectedIndex).filterNoise.endLine.position)
         Case 3
            Return (_interactiveHistogramData.cD(_cbChannel.SelectedIndex).rescale.endLine.position)
      End Select
      Return 0
   End Function

   Private Sub SetEnd(ByVal endLine As Integer)
      Select Case (_tabOptions.SelectedIndex)
         Case 0
            _interactiveHistogramData.cD(_cbChannel.SelectedIndex).segmentation.endLine.position = endLine
         Case 1
            _interactiveHistogramData.cD(_cbChannel.SelectedIndex).grayDistribution.endLine.position = endLine
         Case 2
            _interactiveHistogramData.cD(_cbChannel.SelectedIndex).filterNoise.endLine.position = endLine
         Case 3
            _interactiveHistogramData.cD(_cbChannel.SelectedIndex).rescale.endLine.position = endLine
      End Select
   End Sub

   Private Sub InitLUTArrays(ByVal length As Integer)
      Dim index As Integer

      For index = 0 To 3
         ReDim _interactiveHistogramData.cD(index).RGBLUTSegment(length)
         ReDim _interactiveHistogramData.cD(index).RGBLUTGray(length)
         ReDim _interactiveHistogramData.cD(index).RGBPrevLUT(length)
         ReDim _interactiveHistogramData.cD(index).LUTSegment(length)
         ReDim _interactiveHistogramData.cD(index).LUTGray(length)
         ReDim _interactiveHistogramData.cD(index).LUTFilter(length)
         ReDim _interactiveHistogramData.cD(index).LUTRescale(length)
      Next index
   End Sub

   Private Sub Command_Progress(ByVal sender As Object, ByVal e As RasterCommandProgressEventArgs)
      If (e.Percent = 50) Then
         e.Cancel = True
      End If
   End Sub

   Private Sub SetMinMaxValues(ByVal length As Integer)
      Select Case (ChildImage.BitsPerPixel)
         Case 12, 16, 48, 64
            Dim minMaxCommand As New MinMaxValuesCommand()

            Try
               minMaxCommand.Run(ChildImage)
               _interactiveHistogramData.minimumValue = minMaxCommand.MinimumValue
               _interactiveHistogramData.maximumValue = minMaxCommand.MaximumValue

            Catch ex As Exception
               ex.Message.ToString()
               _interactiveHistogramData.minimumValue = 0
               _interactiveHistogramData.maximumValue = length - 1
            End Try

         Case Else
            _interactiveHistogramData.minimumValue = 0
            _interactiveHistogramData.maximumValue = length - 1
      End Select

      If (ChildImage.Signed) Then
         _interactiveHistogramData.minimumValue = _
               CInt(-(1 << (ChildImage.HighBit - ChildImage.LowBit + 1)) / 2)
         _interactiveHistogramData.maximumValue = _
               CInt(((1 << (ChildImage.HighBit - ChildImage.LowBit + 1)) / 2) - 1)
      End If
   End Sub

   Private Sub InitAfterApply()
      _interactiveHistogramData.histogramLabel.histogramLength = GetHistogramlength(ChildImage.BitsPerPixel, ChildImage.LowBit, ChildImage.HighBit, ChildImage.GrayscaleMode = RasterGrayscaleMode.None, ChildImage.Signed)

      _interactiveHistogramData.signed = ChildImage.Signed
      _interactiveHistogramData.histogramLabel.startRange = 0
      _interactiveHistogramData.histogramLabel.endRange = _interactiveHistogramData.histogramLabel.histogramLength - 1

      If (_interactiveHistogramData.signed) Then
         _interactiveHistogramData.histogramLabel.startRange = CInt(_interactiveHistogramData.histogramLabel.startRange - _interactiveHistogramData.histogramLabel.histogramLength / 2)
         _interactiveHistogramData.histogramLabel.endRange = CInt(_interactiveHistogramData.histogramLabel.endRange - _interactiveHistogramData.histogramLabel.histogramLength / 2)
      End If

      ' Prepare channels data...
      InitialChannelData(0, _interactiveHistogramData.cD(0).innerColor, _interactiveHistogramData.cD(0).outerColor, _interactiveHistogramData.histogramLabel.histogramLength)
      InitialChannelData(1, _interactiveHistogramData.cD(1).innerColor, _interactiveHistogramData.cD(1).outerColor, _interactiveHistogramData.histogramLabel.histogramLength)
      InitialChannelData(2, _interactiveHistogramData.cD(2).innerColor, _interactiveHistogramData.cD(2).outerColor, _interactiveHistogramData.histogramLabel.histogramLength)
      InitialChannelData(3, _interactiveHistogramData.cD(3).innerColor, _interactiveHistogramData.cD(3).outerColor, _interactiveHistogramData.histogramLabel.histogramLength)

      _cbChannel.Enabled = (ChildImage.GrayscaleMode = RasterGrayscaleMode.None)

      _doApply = False
      ' Segmentation options...
      ' Set the range for the controls...
      _nudSegStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
      _nudSegStartPt.Maximum = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).segmentation.endLine.position - 1
      _nudSegStartPt.Value = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).segmentation.startLine.position



      _nudSegEndPt.Minimum = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).segmentation.startLine.position + 1
      _nudSegEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange
      _nudSegEndPt.Value = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).segmentation.endLine.position
      ' Gray Distribution.
      ' Set the range for the controls...
      _nudGrayStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
      _nudGrayStartPt.Maximum = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).grayDistribution.endLine.position - 1
      _nudGrayStartPt.Value = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).grayDistribution.startLine.position

      _nudGrayEndPt.Minimum = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).grayDistribution.startLine.position + 1
      _nudGrayEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange
      _nudGrayEndPt.Value = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).grayDistribution.endLine.position
      ' Filter (Noise).
      ' Set the range for the controls...
      _nudNoiseStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
      _nudNoiseStartPt.Maximum = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).filterNoise.endLine.position - 1
      _nudNoiseStartPt.Value = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).filterNoise.startLine.position

      _nudNoiseEndPt.Minimum = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).filterNoise.startLine.position + 1
      _nudNoiseEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange
      _nudNoiseEndPt.Value = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).filterNoise.endLine.position
      ' Rescaling.
      ' Set the range for the controls...
      _nudResStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
      _nudResStartPt.Maximum = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).rescale.endLine.position - 1
      _nudResStartPt.Value = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).rescale.startLine.position
      _nudResEndPt.Minimum = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).rescale.startLine.position + 1
      _nudResEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange
      _nudResEndPt.Value = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).rescale.endLine.position

      _nudResNewStart.Minimum = _interactiveHistogramData.histogramLabel.startRange
      _nudResNewStart.Maximum = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).rescale.newEndLine.position - 1
      _nudResNewStart.Value = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).rescale.newStartLine.position

      _nudResNewEnd.Minimum = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).rescale.newStartLine.position + 1
      _nudResNewEnd.Maximum = _interactiveHistogramData.histogramLabel.endRange
      _nudResNewEnd.Value = _interactiveHistogramData.cD(CInt(_cbChannel.SelectedIndex)).rescale.newEndLine.position

      _nudResShiftAmount.Minimum = _interactiveHistogramData.histogramLabel.startRange
      _nudResShiftAmount.Maximum = _interactiveHistogramData.histogramLabel.endRange
      _nudResShiftAmount.Value = 0
      _doApply = True

   End Sub

   Private Function GetHistogramlength(ByVal nBBP As Integer, ByVal nLowBit As Integer, ByVal nHighBit As Integer, ByVal bNoGray As Boolean, ByVal bSigned As Boolean) As Integer
      If (nHighBit = -1) Then
         Select Case (nBBP)
            Case 12
               nHighBit = 11
            Case Else
               nHighBit = 15
         End Select
      End If

      Select Case (nBBP)
         Case 16
            If (bNoGray AndAlso Not bSigned) Then
               Return 256
            Else
               Return CInt((Math.Pow(2.0, (nHighBit - nLowBit + 1))))
            End If

         Case 12
            Return CInt((Math.Pow(2.0, (nHighBit - nLowBit + 1))))

         Case 48, 64
            Return 65536

         Case Else
            Return 256
      End Select
   End Function

   Private Function GetActiveChannel(ByVal index As Integer) As RasterColorChannel
      Select Case (index)
         Case 0
            Return RasterColorChannel.Master
         Case 1
            Return RasterColorChannel.Red
         Case 2
            Return RasterColorChannel.Green
         Case 3
            Return RasterColorChannel.Blue
      End Select

      Return RasterColorChannel.Master
   End Function

   Private Function GetFunctionType(ByVal index As Integer) As FunctionalLookupTableFlags
      Select Case (index)
         Case 0
            Return FunctionalLookupTableFlags.Exponential
         Case 1
            Return FunctionalLookupTableFlags.Logarithm
         Case 2
            Return FunctionalLookupTableFlags.Linear
         Case 3
            Return FunctionalLookupTableFlags.Sigmoid
      End Select
      Return FunctionalLookupTableFlags.Linear
   End Function

   Private Sub InitialChannelData(ByVal nChannel As Integer, ByVal InColor As Color, ByVal outColor As Color, ByVal length As Integer)
      ReDim _interactiveHistogramData.cD(nChannel).orginalHistogram(length - 1)
      _interactiveHistogramData.cD(nChannel).innerColor = InColor
      _interactiveHistogramData.cD(nChannel).outerColor = outColor

      ' Initial the stretch structure...
      _interactiveHistogramData.cD(nChannel).segmentation = New HistogramData.Segmentation()
      _interactiveHistogramData.cD(nChannel).segmentation.startLine = New HistogramData.MovingLine(Color.Yellow)
      _interactiveHistogramData.cD(nChannel).segmentation.endLine = New HistogramData.MovingLine(Color.Red)
      _interactiveHistogramData.cD(nChannel).segmentation.startLine.position = CInt((length) / 2 - (length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
      _interactiveHistogramData.cD(nChannel).segmentation.endLine.position = CInt((length) / 2 + (length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange))

      ' Initial the gray distribution structure...
      _interactiveHistogramData.cD(nChannel).grayDistribution = New HistogramData.GrayDistribution()
      _interactiveHistogramData.cD(nChannel).grayDistribution.startLine = New HistogramData.MovingLine(Color.Yellow)
      _interactiveHistogramData.cD(nChannel).grayDistribution.endLine = New HistogramData.MovingLine(Color.Red)
      _interactiveHistogramData.cD(nChannel).grayDistribution.startLine.position = CInt((length) / 2 - (length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
      _interactiveHistogramData.cD(nChannel).grayDistribution.endLine.position = CInt((length) / 2 + (length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange))

      ' Initial the filter noise structure...
      _interactiveHistogramData.cD(nChannel).filterNoise = New HistogramData.FilterNoise()
      _interactiveHistogramData.cD(nChannel).filterNoise.startLine = New HistogramData.MovingLine(Color.Yellow)
      _interactiveHistogramData.cD(nChannel).filterNoise.endLine = New HistogramData.MovingLine(Color.Red)
      _interactiveHistogramData.cD(nChannel).filterNoise.startLine.position = CInt((length) / 2 - (length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
      _interactiveHistogramData.cD(nChannel).filterNoise.endLine.position = CInt((length) / 2 + (length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange))

      ' Initial the rescaling structure...
      _interactiveHistogramData.cD(nChannel).rescale = New HistogramData.Rescaling()
      _interactiveHistogramData.cD(nChannel).rescale.startLine = New HistogramData.MovingLine(Color.Yellow)
      _interactiveHistogramData.cD(nChannel).rescale.endLine = New HistogramData.MovingLine(Color.Red)
      _interactiveHistogramData.cD(nChannel).rescale.newStartLine = New HistogramData.MovingLine(Color.Green)
      _interactiveHistogramData.cD(nChannel).rescale.newEndLine = New HistogramData.MovingLine(Color.Green)

      _interactiveHistogramData.cD(nChannel).rescale.startLine.position = CInt((1 * length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
      _interactiveHistogramData.cD(nChannel).rescale.endLine.position = CInt((3 * length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
      _interactiveHistogramData.cD(nChannel).rescale.newStartLine.position = CInt((5 * length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
      _interactiveHistogramData.cD(nChannel).rescale.newEndLine.position = CInt((7 * length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
   End Sub

   Private Sub PrepareCompressedHisto()
      Dim sum As Integer
      Dim index, of_8, counter As Integer

      _interactiveHistogramData.scale = CInt(_interactiveHistogramData.histogramLabel.histogramLength / 256)

      ReDim _interactiveHistogramData.histogramLabel.drawHistogram(255)

      counter = 0
      For index = 0 To _interactiveHistogramData.histogramLabel.histogramLength - 1 Step _interactiveHistogramData.scale
         sum = 0
         For of_8 = index To (index + _interactiveHistogramData.scale - 1)
            sum = sum + CInt(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(of_8))
         Next of_8

         _interactiveHistogramData.histogramLabel.drawHistogram(counter) = sum
         counter = counter + 1
      Next index
   End Sub

   Private Sub GetMaximumHistogramValue()
      Dim index As Integer
      Dim startLoop, endLoop As Integer

      If (_interactiveHistogramData.histogramLabel.zoomed) Then

         startLoop = _interactiveHistogramData.histogramLabel.drawStartRange
         endLoop = _interactiveHistogramData.histogramLabel.drawEndRange
      ElseIf (_interactiveHistogramData.histogramLabel.drawLength = 256) Then
         startLoop = 1
         endLoop = 256
      Else
         startLoop = 1
         endLoop = _interactiveHistogramData.histogramLabel.histogramLength
      End If

      'Bug#8890 Fix
      If (startLoop < 0) Then
         startLoop = _interactiveHistogramData.histogramLabel.histogramLength + startLoop
         If (endLoop < 0) Then
            endLoop = _interactiveHistogramData.histogramLabel.histogramLength + endLoop
         End If
      End If

      If (endLoop < 0) Then
         endLoop = _interactiveHistogramData.histogramLabel.histogramLength + endLoop
         If (startLoop < 0) Then
            startLoop = _interactiveHistogramData.histogramLabel.histogramLength + startLoop
         End If
      End If
      'End of Bug#8890 Fix

      For index = startLoop To endLoop - 1
         If (_interactiveHistogramData.histogramLabel.drawHistogram(index) > _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).maxHistogramValue) Then
            _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).maxHistogramValue = _interactiveHistogramData.histogramLabel.drawHistogram(index)
         End If

         If (_interactiveHistogramData.histogramLabel.drawHistogram(index) < _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).minHistogramValue) Then
            _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).minHistogramValue = _interactiveHistogramData.histogramLabel.drawHistogram(index)
         End If
      Next index

      For index = 1 To _interactiveHistogramData.histogramLabel.histogramLength - 1
         If (_interactiveHistogramData.cD(_cbChannel.SelectedIndex).orginalHistogram(index) <> 0) Then
            _interactiveHistogramData.noiseMinIntensity = index
            Exit For
         End If
      Next index

      _interactiveHistogramData.noiseMaxIntensity = _interactiveHistogramData.histogramLabel.drawLength - 1
      For index = _interactiveHistogramData.histogramLabel.histogramLength - 2 To 0 Step -1
         If (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(index) <> 0) Then
            _interactiveHistogramData.noiseMaxIntensity = index
            Exit For
         End If
      Next index
   End Sub

   Private Sub SetLabelsValues()
      _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).maxHistogramValue = _interactiveHistogramData.histogramLabel.drawHistogram(0)
      _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).minHistogramValue = _interactiveHistogramData.histogramLabel.drawHistogram(0)

      _interactiveHistogramData.noiseMinIntensity = 0
      _interactiveHistogramData.noiseMaxIntensity = 0

      GetMaximumHistogramValue()
   End Sub

   Private Sub DrawHistogram(ByVal gDraw As Graphics, ByVal pen As Pen, ByVal penWidth As Integer, ByVal divideBy As Integer, ByVal pArray() As Integer, ByVal start As Integer, ByVal nFrom As Integer, ByVal nTo As Integer, ByVal bLine As Boolean)
      Dim nXViewValue As Integer
      Dim nYViewValue As Integer
      Dim index As Integer
      Dim middle As Integer

      If (nFrom >= nTo) Then
         Return
      End If

      middle = CInt(_interactiveHistogramData.histogramLabel.histogramLength / 2)

      nXViewValue = GetXPaintValueHist(start, penWidth) + penWidth

      If (_interactiveHistogramData.signed AndAlso _interactiveHistogramData.fullView) Then
         While (nFrom < nTo)
            index = nFrom + middle
            nYViewValue = CInt((CDbl(pArray(index)) / divideBy) * _interactiveHistogramData.histogramLabel.paint.Height + CDbl(0.5))
            nXViewValue += penWidth

            gDraw.DrawLine(pen, nXViewValue - (2 * penWidth), _interactiveHistogramData.histogramLabel.paint.Height, _
                                nXViewValue - (2 * penWidth), _interactiveHistogramData.histogramLabel.paint.Height - nYViewValue)

            nFrom += 1
         End While
      Else
         If (bLine) Then
            For index = nFrom To nTo - 1

               nYViewValue = CInt((CSng(pArray(index)) / divideBy) * _interactiveHistogramData.histogramLabel.paint.Height + 0.5)
               nXViewValue = nXViewValue + penWidth

               gDraw.DrawLine(pen, nXViewValue - (2 * penWidth), _interactiveHistogramData.histogramLabel.paint.Height, _
                                   nXViewValue - (2 * penWidth), _interactiveHistogramData.histogramLabel.paint.Height - nYViewValue)
            Next index
         End If
      End If
   End Sub

   Private Function GetXPaintValueHist(ByVal nXValue As Integer, ByVal penWidth As Integer) As Integer
      Return ((nXValue * penWidth) + 25 - 2)
   End Function

   Private Function GetXPaintValue(ByVal nXValue As Integer, ByVal penWidth As Integer) As Integer
      If (_interactiveHistogramData.fullView) Then
         Return (nXValue * penWidth) + 25 - 2
      Else
         Return ((GetRealVal(nXValue) * penWidth) + 25 - 2)
      End If
   End Function

   Private Function IsMouseOverPt(ByVal nPointX As Integer, ByVal nPointY As Integer, ByVal nX As Integer, ByVal nY As Integer) As Boolean
      If (nX >= nPointX - 10 AndAlso _
         nX <= nPointX + 10 AndAlso _
         nY >= nPointY AndAlso _
         nY <= nPointY + 10) Then
         Return True
      Else
         Return False
      End If
   End Function

   Private Sub DrawMovingLine(ByVal gDraw As Graphics, ByVal linePen As Pen, ByVal polyPen As Pen, ByVal nValue As Integer, ByVal nRectHeight As Integer, ByVal penWidth As Integer)
      Dim ptTria(3) As Point

      gDraw.DrawLine(linePen, GetXPaintValue(nValue, penWidth), nRectHeight + 2, _
                              GetXPaintValue(nValue, penWidth), 0)

      ptTria(0).X = GetXPaintValue(nValue, penWidth)
      ptTria(0).Y = nRectHeight + 2
      ptTria(1).X = ptTria(0).X + 5
      ptTria(1).Y = ptTria(0).Y + 5
      ptTria(2).X = ptTria(0).X - 5
      ptTria(2).Y = ptTria(0).Y + 5

      gDraw.DrawPolygon(polyPen, ptTria)
   End Sub

   Private Function GetColorFromRasterColor(ByVal rasterColor As RasterColor) As Color
      Dim clr As Color = Color.FromArgb(rasterColor.R, rasterColor.G, rasterColor.B)

      Return clr
   End Function

   Private Sub DrawMovingLine(ByVal gDraw As Graphics, ByVal value As Integer, ByVal height As Integer, ByVal penWidth As Integer, ByVal linePen As Pen, ByVal traPen As Pen)
      Dim ptTria(2) As Point

      gDraw.DrawLine(linePen, GetXPaintValue(value, penWidth), height + 2, _
                              GetXPaintValue(value, penWidth), 0)

      ptTria(0).X = GetXPaintValue(value, penWidth)
      ptTria(0).Y = height + 2
      ptTria(1).X = ptTria(0).X + 5
      ptTria(1).Y = ptTria(0).Y + 5
      ptTria(2).X = ptTria(0).X - 5
      ptTria(2).Y = ptTria(0).Y + 5

      gDraw.DrawPolygon(traPen, ptTria)
   End Sub

   Private Sub DrawAxisAndRanges(ByVal gDraw As Graphics, ByVal penWidth As Integer)
      Dim axisPen, textPen, yellowPen, greenPen, redPen As Pen

      ' Create the pens to draw the selection lines...
      axisPen = New Pen(Color.FromArgb(128, 128, 128), 2)
      axisPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash

      textPen = New Pen(Color.FromArgb(0, 0, 0), 1)
      textPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid

      yellowPen = New Pen(Color.FromArgb(255, 255, 0), penWidth)
      yellowPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash

      greenPen = New Pen(Color.FromArgb(0, 255, 0), penWidth)
      greenPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot

      redPen = New Pen(Color.FromArgb(255, 0, 0), penWidth)
      redPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash

      ' Draw the x-axis for the histogram graph...
      gDraw.DrawLine(axisPen, 25 - penWidth - 2, _interactiveHistogramData.histogramLabel.paint.Height + 2, _
                              25 + 256 - 4, _interactiveHistogramData.histogramLabel.paint.Height + 2)

      ' Draw the intial range marks and its value...
      ' Start point mark
      gDraw.DrawLine(axisPen, 25 - 2, _interactiveHistogramData.histogramLabel.paint.Height + 4, _
                              25 - 2, _interactiveHistogramData.histogramLabel.paint.Height + 7)

      ' End point mark...
      gDraw.DrawLine(axisPen, 25 + 256 - 4, _interactiveHistogramData.histogramLabel.paint.Height + 4, _
                              25 + 256 - 4, _interactiveHistogramData.histogramLabel.paint.Height + 7)

      ' Start point text...
      Dim str As String
      Dim Left, Top As Integer
      Dim textFont As New Font("Arial", 7)

      Left = 25
      Top = _interactiveHistogramData.histogramLabel.paint.Height + 5

      If (_interactiveHistogramData.histogramLabel.histogramLength <> 256 AndAlso _interactiveHistogramData.fullView) Then
         str = _hsRange.Value.ToString()
      ElseIf (_interactiveHistogramData.histogramLabel.zoomed) Then
         str = (GetStart()).ToString()
      Else
         str = _interactiveHistogramData.histogramLabel.startRange.ToString()
      End If

      gDraw.DrawString(str, textFont, Brushes.Black, New PointF(Left, Top))

      ' End point text...
      ' Subtract 5 from the left of the text rectangle to view text when its large...
      Left = 25 + 256 - 5
      Top = _interactiveHistogramData.histogramLabel.paint.Height + 5

      If (_interactiveHistogramData.histogramLabel.histogramLength <> 256 AndAlso _interactiveHistogramData.fullView) Then
         str = (_hsRange.Value + 256).ToString()
      ElseIf (_interactiveHistogramData.histogramLabel.zoomed) Then
         str = (GetEnd()).ToString()
      Else
         str = _interactiveHistogramData.histogramLabel.endRange.ToString()
      End If

      gDraw.DrawString(str, textFont, Brushes.Black, New PointF(Left, Top))
      textFont.Dispose()

      If (Not _interactiveHistogramData.histogramLabel.zoomed) Then
         If (_tabOptions.SelectedIndex = 3 AndAlso Not _interactiveHistogramData.shift) Then
            ' Draw the second start point line...
            DrawMovingLine(gDraw, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newStartLine.position - _interactiveHistogramData.histogramLabel.drawStartRange, _
                                  _interactiveHistogramData.histogramLabel.paint.Height, penWidth, greenPen, textPen)

            ' Draw the second end point line...
            DrawMovingLine(gDraw, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newEndLine.position - _interactiveHistogramData.histogramLabel.drawStartRange, _
               _interactiveHistogramData.histogramLabel.paint.Height, penWidth, greenPen, textPen)
         End If

         ' Draw the start point line...
         DrawMovingLine(gDraw, GetStart() - _interactiveHistogramData.histogramLabel.drawStartRange, _
               _interactiveHistogramData.histogramLabel.paint.Height, penWidth, yellowPen, textPen)

         ' Draw the end point line...
         DrawMovingLine(gDraw, GetEnd() - _interactiveHistogramData.histogramLabel.drawStartRange, _
               _interactiveHistogramData.histogramLabel.paint.Height, penWidth, redPen, textPen)
      End If

      axisPen.Dispose()
      textPen.Dispose()
      yellowPen.Dispose()
      greenPen.Dispose()
      redPen.Dispose()
   End Sub

   Private Function GetGrayValue(ByVal clr As RasterColor) As Integer
      Return CInt(((clr.R * 2) + (clr.G * 5) + (clr.B * 1)) / 8)
   End Function

   Private Sub SetColorValuesToLUT(ByVal puLUT() As Integer, ByVal startColor As RasterColor, ByVal endColor As RasterColor, ByVal startPoint As Integer, ByVal endPoint As Integer, ByVal channel As RasterColorChannel)
      Select Case (channel)
         Case RasterColorChannel.Master
            puLUT(startPoint) = SetRealVal(GetGrayValue(startColor))
            puLUT(endPoint) = SetRealVal(GetGrayValue(endColor))

         Case RasterColorChannel.Red
            puLUT(startPoint) = SetRealVal(startColor.R)
            puLUT(endPoint) = SetRealVal(endColor.R)

         Case RasterColorChannel.Green
            puLUT(startPoint) = SetRealVal(startColor.G)
            puLUT(endPoint) = SetRealVal(endColor.G)

         Case RasterColorChannel.Blue
            puLUT(startPoint) = SetRealVal(startColor.B)
            puLUT(endPoint) = SetRealVal(endColor.B)
      End Select
   End Sub

   Private Function ApplyGradMaster(ByVal startLine As Integer, ByVal endLine As Integer, ByVal channel As RasterColorChannel) As Integer
      Dim startPoint As Integer
      Dim endPoint As Integer
      Dim nCopySize As Integer

      startPoint = _interactiveHistogramData.histogramLabel.startRange
      endPoint = _interactiveHistogramData.histogramLabel.endRange

      _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment(startPoint) = startPoint
      _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment(endPoint) = endPoint

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _
                                        startPoint, _
                                        endPoint, _
                                        0, _
                                        FunctionalLookupTableFlags.Linear)

      startPoint = startLine
      endPoint = endLine

      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _
                          _interactiveHistogramData.segmentStartColor, _interactiveHistogramData.segmentEndColor, _
                          startPoint, endPoint, channel)

      nCopySize = endPoint - startPoint
      If (nCopySize <> 0) Then
         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _
                                           startPoint, _
                                           endPoint, _
                                           0, _
                                           FunctionalLookupTableFlags.Linear)
      End If
      Return 1
   End Function

   Private Function ApplyThreMaster(ByVal startLine As Integer, ByVal endLine As Integer, ByVal channel As RasterColorChannel) As Integer
      Dim startPoint As Integer
      Dim endPoint As Integer
      Dim nCopySize As Integer

      startPoint = _interactiveHistogramData.histogramLabel.startRange
      endPoint = _interactiveHistogramData.histogramLabel.endRange

      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _
                          _interactiveHistogramData.segmentEndColor, _interactiveHistogramData.segmentEndColor, _
                          startPoint, endPoint, channel)
      nCopySize = endPoint - startPoint
      If (nCopySize <> 0) Then
         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _
                                           startPoint, _
                                           endPoint, _
                                           0, _
                                           FunctionalLookupTableFlags.Linear)
      End If

      startPoint = startLine
      endPoint = endLine

      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _
                          _interactiveHistogramData.segmentStartColor, _interactiveHistogramData.segmentStartColor, _
                          startPoint, endPoint, channel)

      nCopySize = endPoint - startPoint
      If (nCopySize > 0) Then
         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _
                                           startPoint, _
                                           endPoint, _
                                           0, _
                                           FunctionalLookupTableFlags.Linear)
      End If
      Return 1
   End Function

   Private Function IsColorGray(ByVal clr As RasterColor) As Boolean
      Return (clr.R = clr.G) AndAlso (clr.G = clr.B)
   End Function

   Private Function IsValidLength(ByVal length As Integer) As Boolean
      If (length = 256 OrElse length = 4096 OrElse length = 65536) Then
         Return True
      Else
         Return False
      End If
   End Function

   Private Function ApplySegmentationMaster(ByVal startLine As Integer, ByVal endLine As Integer) As Integer
      Dim nRet As Integer

      ' Apply to Red channel...
      If (_interactiveHistogramData.gradient) Then
         nRet = ApplyGradMaster(startLine, endLine, RasterColorChannel.Red)
      Else
         nRet = ApplyThreMaster(startLine, endLine, RasterColorChannel.Red)
      End If

      Dim useLUT As Boolean = applyImage.UseLookupTable
      applyImage.UseLookupTable = False

      If (Not applyImage.UseLookupTable AndAlso (applyImage.BitsPerPixel = 12 OrElse applyImage.BitsPerPixel = 16)) Then
         PrepareRemapIntensity(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Red)
      Else
         Dim cmd As New RemapIntensityCommand()
         ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
         Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment.Length)
         cmd.Flags = RemapIntensityCommandFlags.Red
         AddHandler cmd.Progress, AddressOf cmd_Progress
         cmd.Run(applyImage)
      End If
      applyImage.UseLookupTable = useLUT

      ' Apply to Green channel...
      If (_interactiveHistogramData.gradient) Then
         nRet = ApplyGradMaster(startLine, endLine, RasterColorChannel.Green)
      Else
         nRet = ApplyThreMaster(startLine, endLine, RasterColorChannel.Green)
      End If

      useLUT = applyImage.UseLookupTable
      applyImage.UseLookupTable = False
      If (Not applyImage.UseLookupTable AndAlso (applyImage.BitsPerPixel = 12 OrElse applyImage.BitsPerPixel = 16)) Then
         PrepareRemapIntensity(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Green)
      Else
         Dim cmd As New RemapIntensityCommand()
         ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
         Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment.Length)
         cmd.Flags = RemapIntensityCommandFlags.Green
         AddHandler cmd.Progress, AddressOf cmd_Progress
         cmd.Run(applyImage)
      End If
      applyImage.UseLookupTable = useLUT

      ' Apply to Blue channel...
      If (_interactiveHistogramData.gradient) Then
         nRet = ApplyGradMaster(startLine, endLine, RasterColorChannel.Blue)
      Else
         nRet = ApplyThreMaster(startLine, endLine, RasterColorChannel.Blue)
      End If

      useLUT = applyImage.UseLookupTable
      applyImage.UseLookupTable = False

      If (Not applyImage.UseLookupTable AndAlso (applyImage.BitsPerPixel = 12 OrElse applyImage.BitsPerPixel = 16)) Then
         PrepareRemapIntensity(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Blue)
      Else
         Dim cmd As New RemapIntensityCommand()
         ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
         Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment.Length)
         cmd.Flags = RemapIntensityCommandFlags.Blue
         AddHandler cmd.Progress, AddressOf cmd_Progress
         cmd.Run(applyImage)
      End If
      applyImage.UseLookupTable = useLUT

      Return nRet
   End Function

   Private Function ShiftFromSigned(ByVal value As Integer) As Integer
      Dim number As Integer

      number = Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
      number += value

      Return number
   End Function

   Private Sub SetDataValues(ByRef puLUT() As Integer)
      Dim index As Integer
      Dim middle, histogramLength As Integer

      middle = CInt(_interactiveHistogramData.histogramLabel.histogramLength / 2)
      histogramLength = _interactiveHistogramData.histogramLabel.histogramLength
      If (_interactiveHistogramData.signed) Then
         For index = 0 To histogramLength - 1

            If (index < middle) Then
               puLUT(index) = index
            Else
               puLUT(index) = index - _interactiveHistogramData.histogramLabel.histogramLength
            End If
         Next index
      Else
         For index = 0 To histogramLength - 1
            puLUT(index) = index
         Next index
      End If
   End Sub

   Private Function GetLUTSegGradient() As Integer
      Dim startPoint, endPoint As Integer
      Dim nCopySize As Integer
      Dim flags As RasterPaletteWindowLevelFlags

      If (ChildImage.UseLookupTable) Then
         If (_interactiveHistogramData.signed) Then
            flags = RasterPaletteWindowLevelFlags.Signed
         Else
            flags = 0
         End If

         flags = RasterPaletteWindowLevelFlags.Inside Or RasterPaletteWindowLevelFlags.Linear Or RasterPaletteWindowLevelFlags.DicomStyle
         If (_interactiveHistogramData.signed) Then
            flags = flags Or RasterPaletteWindowLevelFlags.Signed
         End If

         Array.Copy(_interactiveHistogramData.originalLUT, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTSegment, _interactiveHistogramData.originalLUT.Length)

         startPoint = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.startLine.position
         endPoint = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.endLine.position

         RasterPalette.WindowLevelFillLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTSegment, _
                                                  _interactiveHistogramData.segmentStartColor, _
                                                  _interactiveHistogramData.segmentEndColor, _
                                                  startPoint, _
                                                  endPoint, _
                                                  ChildImage.LowBit, _
                                                  ChildImage.HighBit, _
                                                  0, _
                                                  _interactiveHistogramData.histogramLabel.histogramLength - 1, _
                                                  0, _
                                                  flags)
      End If

      SetDataValues(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment)

      startPoint = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.startLine.position
      endPoint = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.endLine.position

      If (startPoint < 0) Then
         startPoint = startPoint + _interactiveHistogramData.histogramLabel.histogramLength
      End If
      If (endPoint < 0) Then
         endPoint = endPoint + _interactiveHistogramData.histogramLabel.histogramLength
      End If
      If (ChildImage.Signed) Then
         Dim value As Integer
         value = GetGrayValue(_interactiveHistogramData.segmentStartColor)
         value = SetRealVal(value)
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment(startPoint) = value
         value = GetGrayValue(_interactiveHistogramData.segmentEndColor)
         value = SetRealVal(value)
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment(endPoint) = value
      Else
         SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _
                                _interactiveHistogramData.segmentStartColor, _
                                _interactiveHistogramData.segmentEndColor, _
                             startPoint, endPoint, _interactiveHistogramData.channel)
      End If

      nCopySize = endPoint - startPoint
      If (nCopySize <> 0) Then
         Dim LUTflags As FunctionalLookupTableFlags = FunctionalLookupTableFlags.Linear
         If (_interactiveHistogramData.signed) Then
            LUTflags = LUTflags Or FunctionalLookupTableFlags.Signed
         End If

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _
                                                   _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.startLine.position, _
                                                   _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.endLine.position, _
                                                   0, _
                                                   LUTflags)
      End If
      Return 1
   End Function

   Private Function GetLUTSegThreshold() As Integer

      Dim startPoint, endPoint As Integer
      Dim nCopySize As Integer
      Dim flags As RasterPaletteWindowLevelFlags

      If (ChildImage.UseLookupTable) Then
         If (_interactiveHistogramData.signed) Then
            flags = RasterPaletteWindowLevelFlags.Signed
         Else
            flags = 0
         End If

         flags = flags Or RasterPaletteWindowLevelFlags.Inside Or RasterPaletteWindowLevelFlags.Linear Or RasterPaletteWindowLevelFlags.DicomStyle

         startPoint = _interactiveHistogramData.histogramLabel.startRange
         endPoint = _interactiveHistogramData.histogramLabel.endRange

         nCopySize = endPoint - startPoint
         If (nCopySize <> 0) Then
            RasterPalette.WindowLevelFillLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTSegment, _
                                         _interactiveHistogramData.segmentEndColor, _
                                         _interactiveHistogramData.segmentEndColor, _
                                         startPoint, _
                                         endPoint, _
                                         ChildImage.LowBit, _
                                         ChildImage.HighBit, _
                                         _interactiveHistogramData.histogramLabel.startRange, _
                                         _interactiveHistogramData.histogramLabel.endRange, _
                                         0, _
                                         flags)
         End If

         startPoint = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.startLine.position
         endPoint = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.endLine.position

         Dim lookuptable(_interactiveHistogramData.histogramLabel.histogramLength - 1) As RasterColor
         nCopySize = endPoint - startPoint

         If (nCopySize > 0) Then
            RasterPalette.WindowLevelFillLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTSegment, _
                                      _interactiveHistogramData.segmentStartColor, _
                                      _interactiveHistogramData.segmentStartColor, _
                                      startPoint, _
                                      endPoint, _
                                      ChildImage.LowBit, _
                                      ChildImage.HighBit, _
                                      _interactiveHistogramData.histogramLabel.startRange, _
                                      _interactiveHistogramData.histogramLabel.endRange, _
                                      0, _
                                      flags)
         End If
      End If

      startPoint = _interactiveHistogramData.histogramLabel.startRange
      endPoint = _interactiveHistogramData.histogramLabel.endRange

      If (startPoint < 0) Then
         startPoint = startPoint + _interactiveHistogramData.histogramLabel.histogramLength
      End If

      If (endPoint < 0) Then
         endPoint = endPoint + _interactiveHistogramData.histogramLabel.histogramLength
      End If

      If (ChildImage.Signed) Then
         Dim value As Integer
         value = GetGrayValue(_interactiveHistogramData.segmentEndColor)
         value = SetRealVal(value)
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment(startPoint) = value
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment(endPoint) = value
      Else
         SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _
                             _interactiveHistogramData.segmentEndColor, _interactiveHistogramData.segmentEndColor, _
                             startPoint, endPoint, _interactiveHistogramData.channel)
      End If

      nCopySize = _interactiveHistogramData.histogramLabel.endRange - _interactiveHistogramData.histogramLabel.startRange

      Dim LUTflags As FunctionalLookupTableFlags = FunctionalLookupTableFlags.Linear
      If (_interactiveHistogramData.signed) Then
         LUTflags = LUTflags Or FunctionalLookupTableFlags.Signed
      End If

      If (nCopySize <> 0) Then
         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _
                                                   _interactiveHistogramData.histogramLabel.startRange, _
                                                   _interactiveHistogramData.histogramLabel.endRange, _
                                                   0, _
                                                   LUTflags)
      End If

      startPoint = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.startLine.position
      endPoint = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.endLine.position
      If (startPoint < 0) Then
         startPoint = startPoint + _interactiveHistogramData.histogramLabel.histogramLength
      End If

      If (endPoint < 0) Then
         endPoint = endPoint + _interactiveHistogramData.histogramLabel.histogramLength
      End If

      If (ChildImage.Signed) Then
         Dim value As Integer
         value = GetGrayValue(_interactiveHistogramData.segmentStartColor)
         value = SetRealVal(value)
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment(startPoint) = value
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment(endPoint) = value
      Else
         SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _
                             _interactiveHistogramData.segmentStartColor, _interactiveHistogramData.segmentStartColor, _
                             startPoint, endPoint, _interactiveHistogramData.channel)
      End If

      nCopySize = endPoint - startPoint

      If (nCopySize > 0) Then
         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, _
                                                _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.startLine.position, _
                                                _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.endLine.position, _
                                                0, _
                                                LUTflags)
      End If
      Return 1
   End Function

   Private Function GetLUTSegmentation() As Integer
      Dim nRet As Integer = 0

      FreeImage(applyImage)
      applyImage = _interactiveHistogramData.originalImage.CloneAll()
      _interactiveHistogramData.grayLUT = IsColorGray(_interactiveHistogramData.segmentStartColor) AndAlso IsColorGray(_interactiveHistogramData.segmentEndColor)

      If (_interactiveHistogramData.originalImage.UseLookupTable) Then
         applyImage.SetLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBPrevLUT)
      End If

      If ((applyImage.GrayscaleMode = RasterGrayscaleMode.None) AndAlso (Not IsNothing(applyImage.GetLookupTable())) AndAlso _interactiveHistogramData.channel = RasterColorChannel.Master AndAlso Not _interactiveHistogramData.signed) Then
         If (_interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex)) Then
            nRet = ApplySegmentationMaster(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.startLine.position, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.endLine.position)
         End If
      Else
         If (_interactiveHistogramData.gradient) Then
            nRet = GetLUTSegGradient()
         Else
            nRet = GetLUTSegThreshold()
         End If
         If (_interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex)) Then
            If (_interactiveHistogramData.originalImage.UseLookupTable) Then
               applyImage.WindowLevel(ChildImage.LowBit, _
                                      ChildImage.HighBit, _
                                      _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTSegment, _
                                      RasterWindowLevelMode.PaintAndProcessing)
            Else
               Dim useLUT As Boolean = applyImage.UseLookupTable
               applyImage.UseLookupTable = False

               Dim cmd As New RemapIntensityCommand()
               ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
               Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment.Length)
               cmd.Flags = CType(_interactiveHistogramData.channel Or RemapIntensityCommandFlags.Normal, RemapIntensityCommandFlags)
               AddHandler cmd.Progress, AddressOf cmd_Progress
               cmd.Run(applyImage)

               applyImage.UseLookupTable = useLUT
            End If
         End If
      End If

      FreeImage(ChildImage)
      ChildImage = applyImage.CloneAll()

      Return nRet
   End Function

   Private Sub ConvertToSignedRGBLut(ByVal pLUT() As RasterColor, ByVal LUTLength As Integer)
      Dim i, nLUTLength2 As Integer
      Dim nNewIndexShift As Integer
      Dim nNewRedValueShift, nNewGreenValueShift, nNewBlueValueShift As Integer

      nLUTLength2 = CInt(LUTLength / 2)

      ReDim pLUT(LUTLength - 1)

      For i = 0 To LUTLength - 1
         nNewIndexShift = i - nLUTLength2
         If (nNewIndexShift < 0) Then
            nNewIndexShift = LUTLength + nNewIndexShift
         End If

         nNewBlueValueShift = pLUT(i).B - nLUTLength2
         If (nNewBlueValueShift < 0) Then
            nNewBlueValueShift = LUTLength + nNewBlueValueShift
         End If
         nNewGreenValueShift = pLUT(i).G - nLUTLength2
         If (nNewGreenValueShift < 0) Then
            nNewGreenValueShift = LUTLength + nNewGreenValueShift
         End If
         nNewRedValueShift = pLUT(i).R - nLUTLength2
         If (nNewRedValueShift < 0) Then
            nNewRedValueShift = LUTLength + nNewRedValueShift
         End If

         pLUT(nNewIndexShift).R = CByte(nNewRedValueShift)
         pLUT(nNewIndexShift).B = CByte(nNewBlueValueShift)
         pLUT(nNewIndexShift).G = CByte(nNewGreenValueShift)
         pLUT(nNewIndexShift).Reserved = 0
      Next i
   End Sub

   Private Function GetWinLevelLUT() As Integer
      Dim startColor As RasterColor
      Dim endColor As RasterColor
      Dim lookuptable(_interactiveHistogramData.histogramLabel.histogramLength) As RasterColor
      Dim signed As RasterPaletteWindowLevelFlags

      If (_interactiveHistogramData.signed) Then
         signed = RasterPaletteWindowLevelFlags.Signed
      Else
         signed = 0
      End If

      startColor = New RasterColor(0, 0, 0)

      If (_interactiveHistogramData.graySelectionOnly) Then
         endColor = New RasterColor(0, 0, 0)
      Else
         endColor = New RasterColor(255, 255, 255)
      End If

      RasterPalette.WindowLevelFillLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray, _
                                               startColor, _
                                               endColor, _
                                               _interactiveHistogramData.histogramLabel.startRange, _
                                               _interactiveHistogramData.histogramLabel.endRange, _
                                               ChildImage.LowBit, _
                                               ChildImage.HighBit, _
                                               0, _
                                               _interactiveHistogramData.histogramLabel.histogramLength - 1, _
                                               0, _
                                               RasterPaletteWindowLevelFlags.Linear Or RasterPaletteWindowLevelFlags.Inside Or RasterPaletteWindowLevelFlags.DicomStyle Or signed)

      RasterPalette.WindowLevelFillLookupTable(lookuptable, _
                                               _interactiveHistogramData.grayStartColor, _
                                               _interactiveHistogramData.grayEndColor, _
                                               _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.startLine.position, _
                                               _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.endLine.position, _
                                               ChildImage.LowBit, _
                                               ChildImage.HighBit, _
                                               0, _
                                               _interactiveHistogramData.histogramLabel.histogramLength - 1, _
                                               _interactiveHistogramData.grayFactor, _
                                               GetFillFunction())

      Array.Copy(lookuptable, ShiftFromSigned(GetStart()), _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray, ShiftFromSigned(GetStart()), ShiftFromSigned(GetEnd()) - ShiftFromSigned(GetStart()))

      Return 1
   End Function

   Private Function GetUintArray(ByVal rgbArray() As RasterColor, ByVal length As Integer, ByVal channel As RasterColorChannel) As Integer()
      Dim index As Integer
      Dim array(length - 1) As Integer

      For index = 0 To length - 1
         Select Case (channel)
            Case RasterColorChannel.Red
               array(index) = rgbArray(index).R
            Case RasterColorChannel.Green
               array(index) = rgbArray(index).G
            Case RasterColorChannel.Blue
               array(index) = rgbArray(index).B
         End Select
      Next index
      Return array
   End Function

   Private Function ApplyGrayMaster(ByVal startHist As Integer, ByVal endHist As Integer) As Integer
      Dim startColor As RasterColor
      Dim endColor As RasterColor

      ' Apply the Red Channel...
      If ((endHist - startHist + 1) <> _interactiveHistogramData.histogramLabel.histogramLength) Then

         startColor = New RasterColor(0, 0, 0)
         If (_interactiveHistogramData.graySelectionOnly) Then
            endColor = New RasterColor(0, 0, 0)
         Else
            endColor = New RasterColor(255, 255, 255)
         End If

         SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                             startColor, _
                             endColor, _
                             _interactiveHistogramData.histogramLabel.startRange, _
                             _interactiveHistogramData.histogramLabel.endRange, _
                             RasterColorChannel.Red)

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                                                   _interactiveHistogramData.histogramLabel.startRange, _
                                                   _interactiveHistogramData.histogramLabel.endRange, _
                                                   0, _
                                                   FunctionalLookupTableFlags.Linear)
      End If

      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                         _interactiveHistogramData.grayStartColor, _
                         _interactiveHistogramData.grayEndColor, _
                         startHist, _
                         endHist, _
                         RasterColorChannel.Red)

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                                                startHist, _
                                                endHist, _
                                                _interactiveHistogramData.grayFactor, _
                                                _interactiveHistogramData.grayFunctionType)

      Dim useLUT As Boolean = applyImage.UseLookupTable
      applyImage.UseLookupTable = False

      Dim buffer() As Integer = GetUintArray(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Red)
      Dim cmd As New RemapIntensityCommand()
      ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
      Array.Copy(buffer, cmd.LookupTable, buffer.Length)
      cmd.Flags = RemapIntensityCommandFlags.Red
      AddHandler cmd.Progress, AddressOf cmd_Progress
      cmd.Run(applyImage)

      applyImage.UseLookupTable = useLUT

      ' Apply the Green Channel...
      If ((endHist - startHist + 1) <> _interactiveHistogramData.histogramLabel.histogramLength) Then
         startColor = New RasterColor(0, 0, 0)
         If (_interactiveHistogramData.graySelectionOnly) Then
            endColor = New RasterColor(0, 0, 0)
         Else
            endColor = New RasterColor(255, 255, 255)
         End If

         SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                             startColor, _
                             endColor, _
                             _interactiveHistogramData.histogramLabel.startRange, _
                             _interactiveHistogramData.histogramLabel.endRange, _
                             RasterColorChannel.Green)

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                                           _interactiveHistogramData.histogramLabel.startRange, _
                                           _interactiveHistogramData.histogramLabel.endRange, _
                                           0, _
                                           FunctionalLookupTableFlags.Linear)
      End If

      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                          _interactiveHistogramData.grayStartColor, _
                          _interactiveHistogramData.grayEndColor, _
                          startHist, _
                          endHist, _
                          RasterColorChannel.Green)

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                                                startHist, _
                                                endHist, _
                                                _interactiveHistogramData.grayFactor, _
                                                _interactiveHistogramData.grayFunctionType)

      useLUT = applyImage.UseLookupTable
      applyImage.UseLookupTable = False

      cmd = New RemapIntensityCommand()
      ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
      Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray.Length)
      cmd.Flags = RemapIntensityCommandFlags.Green
      AddHandler cmd.Progress, AddressOf cmd_Progress
      cmd.Run(applyImage)

      applyImage.UseLookupTable = useLUT

      ' Apply the Blue Channel...
      If ((endHist - startHist + 1) <> _interactiveHistogramData.histogramLabel.histogramLength) Then
         startColor = New RasterColor(0, 0, 0)
         If (_interactiveHistogramData.graySelectionOnly) Then
            endColor = New RasterColor(0, 0, 0)
         Else
            endColor = New RasterColor(255, 255, 255)
         End If

         SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                             startColor, _
                             endColor, _
                             _interactiveHistogramData.histogramLabel.startRange, _
                             _interactiveHistogramData.histogramLabel.endRange, _
                             RasterColorChannel.Blue)

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                                                   _interactiveHistogramData.histogramLabel.startRange, _
                                                   _interactiveHistogramData.histogramLabel.endRange, _
                                                   0, _
                                                   FunctionalLookupTableFlags.Linear)
      End If

      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                         _interactiveHistogramData.grayStartColor, _
                         _interactiveHistogramData.grayEndColor, _
                         startHist, _
                         endHist, _
                         RasterColorChannel.Blue)

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                                                startHist, _
                                                endHist, _
                                                _interactiveHistogramData.grayFactor, _
                                                _interactiveHistogramData.grayFunctionType)

      useLUT = applyImage.UseLookupTable
      applyImage.UseLookupTable = False

      cmd = New RemapIntensityCommand()
      ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
      Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment.Length)
      cmd.Flags = RemapIntensityCommandFlags.Blue
      AddHandler cmd.Progress, AddressOf cmd_Progress
      cmd.Run(applyImage)

      applyImage.UseLookupTable = useLUT
      Return 1
   End Function

   Private Function GetFillFunction() As RasterPaletteWindowLevelFlags
      Dim flags As RasterPaletteWindowLevelFlags

      If (_interactiveHistogramData.signed) Then
         flags = RasterPaletteWindowLevelFlags.Inside Or RasterPaletteWindowLevelFlags.DicomStyle Or RasterPaletteWindowLevelFlags.Signed
      Else
         flags = RasterPaletteWindowLevelFlags.Inside Or RasterPaletteWindowLevelFlags.DicomStyle
      End If

      Select Case (_cbGrayFunctionType.SelectedIndex)
         Case 0
            flags = flags Or RasterPaletteWindowLevelFlags.Exponential
         Case 1
            flags = flags Or RasterPaletteWindowLevelFlags.Logarithmic
         Case 2
            flags = flags Or RasterPaletteWindowLevelFlags.Linear
         Case 3
            flags = flags Or RasterPaletteWindowLevelFlags.Sigmoid
      End Select
      Return flags
   End Function


   Private Function GenerateLUTFromPalette(ByVal RGBLUTGray() As RasterColor, ByVal RGBPallete() As RasterColor) As Integer
      Dim index As Integer
      Dim counter As Integer
      Dim startColor As RasterColor
      Dim endColor As RasterColor
      Dim flags As RasterPaletteWindowLevelFlags = RasterPaletteWindowLevelFlags.Inside Or RasterPaletteWindowLevelFlags.Linear Or RasterPaletteWindowLevelFlags.DicomStyle
      Dim nEndRange As Integer
      Dim fStep As Double
      Dim nStartStep As Integer = 0
      Dim nEndStep As Integer = 0

      nEndRange = 1 << (ChildImage.HighBit + 1)
      fStep = CDbl((CDbl(_interactiveHistogramData.histogramLabel.histogramLength) / (_interactiveHistogramData.numberofPallet - 1)))

      If (_interactiveHistogramData.numberofPallet < 2) Then
         startColor = RGBPallete(0)
         endColor = startColor
         nStartStep = 0
         nEndStep = _interactiveHistogramData.histogramLabel.histogramLength - 1
         RasterPalette.WindowLevelFillLookupTable(RGBLUTGray, _
                                                  startColor, _
                                                  endColor, _
                                                  nStartStep, _
                                                  nEndStep, _
                                                  ChildImage.LowBit, _
                                                  ChildImage.HighBit, _
                                                  0, _
                                                  nEndRange, _
                                                  0, _
                                                  flags)
      End If

      _interactiveHistogramData.numberofPallet -= 1
      counter = 0
      For index = 0 To _interactiveHistogramData.numberofPallet - 1
         startColor = RGBPallete(counter)
         endColor = RGBPallete(counter + 1)

         nStartStep = Convert.ToInt32(counter * fStep)
         nEndStep = Convert.ToInt32((counter + 1) * fStep - 1)

         RasterPalette.WindowLevelFillLookupTable(RGBLUTGray, _
                                                  startColor, _
                                                  endColor, _
                                                  nStartStep, _
                                                  nEndStep, _
                                                  ChildImage.LowBit, _
                                                  ChildImage.HighBit, _
                                                  0, _
                                                  nEndRange, _
                                                  0, _
                                                  flags)
         counter += 1
      Next index

      If (_interactiveHistogramData.signed) Then
         ConvertToSignedRGBLut(RGBLUTGray, _interactiveHistogramData.histogramLabel.histogramLength)
      End If
      _interactiveHistogramData.numberofPallet = 256
      Return 1
   End Function

   Private Function GetLUTGrayDistribution() As Integer
      Dim nRet As Integer
      Dim nSHist, nEHist As Integer
      Dim nStart, nEnd As Integer

      If (Not _interactiveHistogramData.letApplyOnPallete AndAlso _interactiveHistogramData.grayPredefinedPalette) Then
         Return 1
      End If

      applyImage = _interactiveHistogramData.originalImage.CloneAll()

      If (ChildImage.UseLookupTable) Then
         applyImage.SetLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBPrevLUT)
      End If

      _interactiveHistogramData.grayLUT = IsColorGray(_interactiveHistogramData.grayStartColor) AndAlso IsColorGray(_interactiveHistogramData.grayEndColor)

      If ((applyImage.GrayscaleMode = RasterGrayscaleMode.None AndAlso (Not applyImage.UseLookupTable)) AndAlso _interactiveHistogramData.channel = RasterColorChannel.Master AndAlso Not _interactiveHistogramData.signed) Then
         If (_interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex)) Then
            nRet = ApplyGrayMaster(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.startLine.position, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.endLine.position)
         End If
      Else
         nStart = GetStart()
         nSHist = GetStart()
         nEnd = GetEnd()
         nEHist = GetEnd()

         If (_interactiveHistogramData.grayPredefinedPalette) Then
            GenerateLUTFromPalette(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray, _interactiveHistogramData.predefinedPalette)
            If (_interactiveHistogramData.letApplyOnPallete) Then
               _interactiveHistogramData.letApplyOnPallete = False
            End If
         Else
            If (ChildImage.UseLookupTable) Then
               If ((nEHist - nSHist + 1) <> _interactiveHistogramData.histogramLabel.histogramLength) Then
                  If (_interactiveHistogramData.graySelectionOnly) Then
                     ReDim _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray(_interactiveHistogramData.histogramLabel.histogramLength - 1)
                     ' copy the original Bitmap LUT
                  Else
                     Array.Copy(_interactiveHistogramData.originalLUT, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray, _interactiveHistogramData.histogramLabel.histogramLength)
                  End If
               End If

               RasterPalette.WindowLevelFillLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray, _
                                                         _interactiveHistogramData.grayStartColor, _
                                                         _interactiveHistogramData.grayEndColor, _
                                                         nSHist, _
                                                         nEHist, _
                                                         ChildImage.LowBit, _
                                                         ChildImage.HighBit, _
                                                         _interactiveHistogramData.histogramLabel.startRange, _
                                                         _interactiveHistogramData.histogramLabel.endRange, _
                                                         _interactiveHistogramData.grayFactor, _
                                                         GetFillFunction())
            End If

            If ((nEHist - nSHist + 1) <> _interactiveHistogramData.histogramLabel.histogramLength) Then
               SetDataValues(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray)
            End If

            If (_interactiveHistogramData.graySelectionOnly) Then
               ReDim _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray(_interactiveHistogramData.histogramLabel.histogramLength - 1)
            End If
            If (nStart < 0) Then
               nStart += _interactiveHistogramData.histogramLabel.histogramLength
            End If
            If (nEnd < 0) Then
               nEnd += _interactiveHistogramData.histogramLabel.histogramLength
            End If

            If (_interactiveHistogramData.signed) Then
               Dim nValue As Integer
               nValue = GetGrayValue(_interactiveHistogramData.segmentStartColor)
               nValue = SetRealVal(nValue)
               _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray(nStart) = nValue
               nValue = GetGrayValue(_interactiveHistogramData.segmentEndColor)
               nValue = SetRealVal(nValue)
               _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray(nEnd) = nValue
            Else
               SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                                    _interactiveHistogramData.grayStartColor, _
                                    _interactiveHistogramData.grayEndColor, _
                                    nSHist, _
                                    nEHist, _
                                    _interactiveHistogramData.channel)
            End If

            Dim lutFlags As FunctionalLookupTableFlags = _interactiveHistogramData.grayFunctionType
            If (_interactiveHistogramData.signed) Then
               lutFlags = lutFlags Or FunctionalLookupTableFlags.Signed
            End If

            EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, _
                                                      nSHist, _
                                                      nEHist, _
                                                      _interactiveHistogramData.grayFactor, _
                                                      lutFlags)
         End If

         If (_interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex)) Then
            If (ChildImage.UseLookupTable) Then
               applyImage.WindowLevel(ChildImage.LowBit, _
               ChildImage.HighBit, _
               _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray, _
               RasterWindowLevelMode.PaintAndProcessing)
            Else
               Dim bUseLUT As Boolean = applyImage.UseLookupTable
               applyImage.UseLookupTable = False

               Dim cmd As New RemapIntensityCommand()
               ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
               Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray.Length)
               cmd.Flags = CType(_interactiveHistogramData.channel, RemapIntensityCommandFlags)
               AddHandler cmd.Progress, AddressOf cmd_Progress
               cmd.Run(applyImage)

               applyImage.UseLookupTable = bUseLUT
            End If
         End If
      End If

      FreeImage(ChildImage)
      ChildImage = applyImage.CloneAll()
      Return 1
   End Function

   Private Function ApplyFilterMaster(ByVal startHist As Integer, ByVal endHist As Integer) As Integer

      Dim clr As RasterColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black)
      Dim uFlags As FunctionalLookupTableFlags = FunctionalLookupTableFlags.Linear
      If (_interactiveHistogramData.signed) Then
         uFlags = uFlags Or FunctionalLookupTableFlags.Signed
      End If

      ' Apply to the Red Channel...
      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                         New RasterColor(0, 0, 0), _
                         New RasterColor(255, 255, 255), _
                         _interactiveHistogramData.histogramLabel.startRange, _
                         _interactiveHistogramData.histogramLabel.endRange, _
                         RasterColorChannel.Red)

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                                        _interactiveHistogramData.histogramLabel.startRange, _
                                        _interactiveHistogramData.histogramLabel.endRange, _
                                        0, _
                                        uFlags)

      Select Case (_interactiveHistogramData.noiseReplaceType)
         Case HistogramData.FilterNoiseReplaceType.StartEndPoints
            clr = GetColorFromNumber(GetRealVal(GetStart()))

         Case HistogramData.FilterNoiseReplaceType.MinimumMaximumInternsity
            clr = GetColorFromNumber(GetRealVal(_interactiveHistogramData.minimumValue))

         Case HistogramData.FilterNoiseReplaceType.ReplaceColor
            clr = _interactiveHistogramData.noiseReplaceColor

         Case HistogramData.FilterNoiseReplaceType.Zero
            clr = New RasterColor(0, 0, 0)
      End Select

      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                         clr, _
                         clr, _
                         _interactiveHistogramData.histogramLabel.startRange, _
                         startHist, _
                         RasterColorChannel.Red)

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                                           _interactiveHistogramData.histogramLabel.startRange, _
                                           startHist, _
                                           0, _
                                           uFlags)

      Select Case (_interactiveHistogramData.noiseReplaceType)
         Case HistogramData.FilterNoiseReplaceType.StartEndPoints
            clr = GetColorFromNumber(GetRealVal(GetEnd()))

         Case HistogramData.FilterNoiseReplaceType.MinimumMaximumInternsity
            clr = GetColorFromNumber(GetRealVal(_interactiveHistogramData.maximumValue))

         Case HistogramData.FilterNoiseReplaceType.ReplaceColor
            clr = _interactiveHistogramData.noiseReplaceColor

         Case HistogramData.FilterNoiseReplaceType.Zero
            clr = New RasterColor(0, 0, 0)
      End Select

      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                         clr, _
                         clr, _
                         endHist, _
                         _interactiveHistogramData.histogramLabel.endRange, _
                         RasterColorChannel.Red)

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                                        endHist, _
                                        _interactiveHistogramData.histogramLabel.endRange, _
                                        0, _
                                        uFlags)

      Dim useLUT As Boolean = applyImage.UseLookupTable
      applyImage.UseLookupTable = False

      If (Not applyImage.UseLookupTable AndAlso (applyImage.BitsPerPixel = 12 OrElse applyImage.BitsPerPixel = 16)) Then
         PrepareRemapIntensity(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Red)
      Else
         Dim cmd As New RemapIntensityCommand()
         ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
         Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment.Length)
         cmd.Flags = RemapIntensityCommandFlags.Red
         AddHandler cmd.Progress, AddressOf cmd_Progress
         cmd.Run(applyImage)
      End If
      applyImage.UseLookupTable = useLUT

      ' Apply to the Green Channel...
      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                          New RasterColor(0, 0, 0), _
                          New RasterColor(255, 255, 255), _
                          _interactiveHistogramData.histogramLabel.startRange, _
                          _interactiveHistogramData.histogramLabel.endRange, _
                          RasterColorChannel.Green)

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                                                _interactiveHistogramData.histogramLabel.startRange, _
                                                _interactiveHistogramData.histogramLabel.endRange, _
                                                0, _
                                                uFlags)

      Select Case (_interactiveHistogramData.noiseReplaceType)
         Case HistogramData.FilterNoiseReplaceType.StartEndPoints
            clr = GetColorFromNumber(GetRealVal(GetStart()))

         Case HistogramData.FilterNoiseReplaceType.MinimumMaximumInternsity
            clr = GetColorFromNumber(GetRealVal(_interactiveHistogramData.minimumValue))

         Case HistogramData.FilterNoiseReplaceType.ReplaceColor
            clr = _interactiveHistogramData.noiseReplaceColor

         Case HistogramData.FilterNoiseReplaceType.Zero
            clr = New RasterColor(0, 0, 0)

      End Select

      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                         clr, _
                         clr, _
                         _interactiveHistogramData.histogramLabel.startRange, _
                         startHist, _
                         RasterColorChannel.Green)

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                                                _interactiveHistogramData.histogramLabel.startRange, _
                                                startHist, _
                                                0, _
                                                uFlags)

      Select Case (_interactiveHistogramData.noiseReplaceType)
         Case HistogramData.FilterNoiseReplaceType.StartEndPoints
            clr = GetColorFromNumber(GetRealVal(GetEnd()))

         Case HistogramData.FilterNoiseReplaceType.MinimumMaximumInternsity
            clr = GetColorFromNumber(GetRealVal(_interactiveHistogramData.maximumValue))

         Case HistogramData.FilterNoiseReplaceType.ReplaceColor
            clr = _interactiveHistogramData.noiseReplaceColor

         Case HistogramData.FilterNoiseReplaceType.Zero
            clr = New RasterColor(0, 0, 0)
      End Select

      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                         clr, _
                         clr, _
                         endHist, _
                         _interactiveHistogramData.histogramLabel.endRange, _
                         RasterColorChannel.Green)

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                                        endHist, _
                                        _interactiveHistogramData.histogramLabel.endRange, _
                                        0, _
                                        uFlags)

      useLUT = applyImage.UseLookupTable
      applyImage.UseLookupTable = False

      If (Not applyImage.UseLookupTable AndAlso (applyImage.BitsPerPixel = 12 OrElse applyImage.BitsPerPixel = 16)) Then
         PrepareRemapIntensity(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Green)
      Else
         Dim cmd As New RemapIntensityCommand()
         ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
         Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment.Length)
         cmd.Flags = RemapIntensityCommandFlags.Green
         AddHandler cmd.Progress, AddressOf cmd_Progress
         cmd.Run(applyImage)
      End If
      applyImage.UseLookupTable = useLUT

      ' Apply to the Blue Channel...
      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                         New RasterColor(0, 0, 0), _
                         New RasterColor(255, 255, 255), _
                         _interactiveHistogramData.histogramLabel.startRange, _
                         _interactiveHistogramData.histogramLabel.endRange, _
                         RasterColorChannel.Blue)

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                                        _interactiveHistogramData.histogramLabel.startRange, _
                                        _interactiveHistogramData.histogramLabel.endRange, _
                                        0, _
                                        uFlags)

      Select Case (_interactiveHistogramData.noiseReplaceType)
         Case HistogramData.FilterNoiseReplaceType.StartEndPoints
            clr = GetColorFromNumber(GetRealVal(GetStart()))

         Case HistogramData.FilterNoiseReplaceType.MinimumMaximumInternsity
            clr = GetColorFromNumber(GetRealVal(_interactiveHistogramData.minimumValue))

         Case HistogramData.FilterNoiseReplaceType.ReplaceColor
            clr = _interactiveHistogramData.noiseReplaceColor

         Case HistogramData.FilterNoiseReplaceType.Zero
            clr = New RasterColor(0, 0, 0)
      End Select

      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                         clr, _
                         clr, _
                         _interactiveHistogramData.histogramLabel.startRange, _
                         startHist, _
                         RasterColorChannel.Blue)

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                                        _interactiveHistogramData.histogramLabel.startRange, _
                                        startHist, _
                                        0, _
                                        uFlags)

      Select Case (_interactiveHistogramData.noiseReplaceType)
         Case HistogramData.FilterNoiseReplaceType.StartEndPoints
            clr = GetColorFromNumber(GetRealVal(GetEnd()))

         Case HistogramData.FilterNoiseReplaceType.MinimumMaximumInternsity
            clr = GetColorFromNumber(GetRealVal(_interactiveHistogramData.maximumValue))

         Case HistogramData.FilterNoiseReplaceType.ReplaceColor
            clr = _interactiveHistogramData.noiseReplaceColor

         Case HistogramData.FilterNoiseReplaceType.Zero
            clr = New RasterColor(0, 0, 0)
      End Select

      SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                         clr, _
                         clr, _
                         endHist, _
                         _interactiveHistogramData.histogramLabel.endRange, _
                         RasterColorChannel.Blue)

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                                        endHist, _
                                        _interactiveHistogramData.histogramLabel.endRange, _
                                        0, _
                                        uFlags)

      useLUT = applyImage.UseLookupTable
      applyImage.UseLookupTable = False

      If (Not applyImage.UseLookupTable AndAlso (applyImage.BitsPerPixel = 12 OrElse applyImage.BitsPerPixel = 16)) Then
         PrepareRemapIntensity(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Blue)
      Else
         Dim cmd As New RemapIntensityCommand()
         ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
         Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment.Length)
         cmd.Flags = RemapIntensityCommandFlags.Blue
         AddHandler cmd.Progress, AddressOf cmd_Progress
         cmd.Run(applyImage)
      End If
      applyImage.UseLookupTable = useLUT

      Return 1
   End Function

   Private Function GetColorFromNumber(ByVal value As Integer) As RasterColor
      Dim byteColor As Byte = CByte(Math.Max(0, Math.Min(255, value)))
      Return (New RasterColor(byteColor, byteColor, byteColor))
   End Function

   Private Function GetLUTFilterNoise() As Integer
      Dim nStartLoop, nEndLoop, endRange As Integer
      Dim nRet As Integer
      Dim clr As RasterColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black)
      Dim nValue As Integer = 0
      Dim nStart, nEnd As Integer
      Dim uFlags As FunctionalLookupTableFlags

      If (_interactiveHistogramData.signed) Then
         nStartLoop = GetStart() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
         nEndLoop = GetEnd() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
         endRange = _interactiveHistogramData.histogramLabel.endRange + Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
      Else
         nStartLoop = GetStart()
         nEndLoop = GetEnd()
         endRange = _interactiveHistogramData.histogramLabel.endRange
      End If

      _interactiveHistogramData.grayLUT = True
      applyImage = _interactiveHistogramData.originalImage.CloneAll()
      If (ChildImage.UseLookupTable) Then
         applyImage.SetLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBPrevLUT)
      End If

      uFlags = FunctionalLookupTableFlags.Linear
      If (_interactiveHistogramData.signed) Then
         uFlags = uFlags Or FunctionalLookupTableFlags.Signed
      End If

      If ((ChildImage.GrayscaleMode = RasterGrayscaleMode.None) AndAlso _interactiveHistogramData.channel = RasterColorChannel.Master AndAlso Not _interactiveHistogramData.signed) Then
         If (_interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex)) Then
            nRet = ApplyFilterMaster(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.startLine.position, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.endLine.position)
         End If
      Else
         SetDataValues(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter)

         Select Case (_interactiveHistogramData.noiseReplaceType)
            Case HistogramData.FilterNoiseReplaceType.StartEndPoints
               nValue = GetStart()
               If (Not applyImage.Signed) Then
                  clr = GetColorFromNumber(GetRealVal(nValue))
               Else
                  If (nValue < 0) Then
                     nValue += _interactiveHistogramData.histogramLabel.histogramLength
                  End If
                  nValue = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter(nValue)
               End If

            Case HistogramData.FilterNoiseReplaceType.MinimumMaximumInternsity
               nValue = _interactiveHistogramData.noiseMinIntensity
               If (Not applyImage.Signed) Then
                  clr = GetColorFromNumber(GetRealVal(nValue))
               Else
                  If (nValue < 0) Then
                     nValue += _interactiveHistogramData.histogramLabel.histogramLength
                  End If
                  nValue = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter(nValue)
               End If

            Case HistogramData.FilterNoiseReplaceType.ReplaceColor
               clr = _interactiveHistogramData.noiseReplaceColor
               If (applyImage.Signed) Then
                  nValue = GetGrayValue(clr)
                  nValue = SetRealVal(nValue)
               End If

            Case HistogramData.FilterNoiseReplaceType.Zero
               clr = GetColorFromNumber(0)
               If (applyImage.Signed) Then
                  nValue = GetGrayValue(clr)
                  nValue = SetRealVal(nValue)
               End If
         End Select

         nStart = _interactiveHistogramData.histogramLabel.startRange
         nEnd = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.startLine.position
         If (nStart <> nEnd) Then
            If (nStart < 0) Then
               nStart += _interactiveHistogramData.histogramLabel.histogramLength
            End If
            If (nEnd < 0) Then
               nEnd += _interactiveHistogramData.histogramLabel.histogramLength
            End If

            If (applyImage.Signed) Then
               _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter(nStart) = nValue
               _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter(nEnd) = nValue
            Else
               SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                  clr, _
                  clr, _
                  nStart, _
                  nEnd, _
                  _interactiveHistogramData.channel)

               If (_interactiveHistogramData.histogramLabel.startRange <> _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.startLine.position) Then
                  EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                                                            _interactiveHistogramData.histogramLabel.startRange, _
                                                            _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.startLine.position, _
                                                            0, _
                                                            uFlags)
               End If
            End If
         End If

         Select Case (_interactiveHistogramData.noiseReplaceType)
            Case HistogramData.FilterNoiseReplaceType.StartEndPoints
               nValue = GetEnd()
               If (Not applyImage.Signed) Then
                  clr = GetColorFromNumber(GetRealVal(nValue))
               Else
                  If (nValue < 0) Then
                     nValue += _interactiveHistogramData.histogramLabel.histogramLength
                  End If
                  nValue = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter(nValue)
               End If

            Case HistogramData.FilterNoiseReplaceType.MinimumMaximumInternsity
               nValue = _interactiveHistogramData.noiseMaxIntensity
               If ((Not applyImage.Signed)) Then
                  clr = GetColorFromNumber(GetRealVal(nValue))
               Else
                  If (nValue < 0) Then
                     nValue += _interactiveHistogramData.histogramLabel.histogramLength
                  End If
                  nValue = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter(nValue)
               End If

            Case HistogramData.FilterNoiseReplaceType.ReplaceColor
               clr = _interactiveHistogramData.noiseReplaceColor
               If (applyImage.Signed) Then
                  nValue = GetGrayValue(clr)
                  nValue = SetRealVal(nValue)
               End If

            Case HistogramData.FilterNoiseReplaceType.Zero
               clr = New RasterColor(0, 0, 0)
               If (applyImage.Signed) Then
                  nValue = GetGrayValue(clr)
                  nValue = SetRealVal(nValue)
               End If
         End Select

         nStart = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.endLine.position
         nEnd = _interactiveHistogramData.histogramLabel.endRange
         If (nStart <> nEnd) Then
            If (nStart < 0) Then
               nStart += _interactiveHistogramData.histogramLabel.histogramLength
            End If
            If (nEnd < 0) Then
               nEnd += _interactiveHistogramData.histogramLabel.histogramLength
            End If
            If (applyImage.Signed) Then
               _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter(nStart) = nValue
               _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter(nEnd) = nValue
            Else
               SetColorValuesToLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                                  clr, _
                                  clr, _
                                  nStart, _
                                  nEnd, _
                                  _interactiveHistogramData.channel)
            End If

            If (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.endLine.position <> _interactiveHistogramData.histogramLabel.endRange) Then
               EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, _
                                                 _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.endLine.position, _
                                                 _interactiveHistogramData.histogramLabel.endRange, _
                                                 0, _
                                                 uFlags)
            End If
         End If
         If (_interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex)) Then
            Dim useLUT As Boolean = applyImage.UseLookupTable
            applyImage.UseLookupTable = False

            Dim cmd As New RemapIntensityCommand()
            ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
            Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment.Length)
            cmd.Flags = CType(_interactiveHistogramData.channel, RemapIntensityCommandFlags) Or RemapIntensityCommandFlags.Normal
            AddHandler cmd.Progress, AddressOf cmd_Progress
            cmd.Run(applyImage)

            applyImage.UseLookupTable = useLUT
         End If
      End If

      FreeImage(ChildImage)
      ChildImage = applyImage.CloneAll()
      Return 1
   End Function

   Private Function GetLUTResShift() As Integer
      Dim nFrom, nTo, nTemp As Integer

      Dim uFlags As FunctionalLookupTableFlags

      uFlags = FunctionalLookupTableFlags.Linear
      If (_interactiveHistogramData.signed) Then
         uFlags = uFlags Or FunctionalLookupTableFlags.Signed
      End If

      SetDataValues(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale)

      If (_interactiveHistogramData.shiftRight) Then
         nTemp = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.startLine.position
         nTemp += CInt(_nudResShiftAmount.Value)
         If (nTemp > _interactiveHistogramData.histogramLabel.endRange) Then
            nTemp = _interactiveHistogramData.histogramLabel.endRange
         End If

         nFrom = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.startLine.position
         If (nFrom < 0) Then
            nFrom += _interactiveHistogramData.histogramLabel.histogramLength
         End If
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale(nFrom) = nTemp

         nTemp = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.endLine.position
         nTemp += CInt(_nudResShiftAmount.Value)
         If (nTemp > _interactiveHistogramData.histogramLabel.endRange) Then
            nTemp = _interactiveHistogramData.histogramLabel.endRange
         End If

         nTo = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.endLine.position
         If (nTo < 0) Then
            nTo += _interactiveHistogramData.histogramLabel.histogramLength
         End If
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale(nTo) = nTemp
      Else
         nTemp = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.startLine.position
         nTemp -= CInt(_nudResShiftAmount.Value)
         If (nTemp < _interactiveHistogramData.histogramLabel.startRange) Then
            nTemp = _interactiveHistogramData.histogramLabel.startRange
         End If

         nFrom = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.startLine.position
         If (nFrom < 0) Then
            nFrom += _interactiveHistogramData.histogramLabel.histogramLength
         End If
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale(nFrom) = nTemp

         nTemp = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.endLine.position
         nTemp -= CInt(_nudResShiftAmount.Value)
         If (nTemp < _interactiveHistogramData.histogramLabel.startRange) Then
            nTemp = _interactiveHistogramData.histogramLabel.startRange
         End If

         nTo = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.endLine.position
         If (nTo < 0) Then
            nTo += _interactiveHistogramData.histogramLabel.histogramLength
         End If
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale(nTo) = nTemp
      End If

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale, _
                                                GetStart(), _
                                                GetEnd(), _
                                                0, _
                                                uFlags)
      Return 1
   End Function

   Private Function GetLUTResNewSE() As Integer
      Dim nStart, nEnd As Integer
      Dim nNewStart, nNewEnd As Integer
      Dim uFlags As FunctionalLookupTableFlags

      uFlags = FunctionalLookupTableFlags.Linear
      If (_interactiveHistogramData.signed) Then
         uFlags = uFlags Or FunctionalLookupTableFlags.Signed
      End If

      SetDataValues(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale)

      nStart = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.startLine.position
      If (nStart < 0) Then
         nStart += _interactiveHistogramData.histogramLabel.histogramLength
      End If

      nEnd = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.endLine.position
      If (nEnd < 0) Then
         nEnd += _interactiveHistogramData.histogramLabel.histogramLength
      End If

      nNewStart = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newStartLine.position
      If (nNewStart < 0) Then
         nNewStart += _interactiveHistogramData.histogramLabel.histogramLength
      End If

      nNewEnd = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newEndLine.position
      If (nNewEnd < 0) Then
         nNewEnd += _interactiveHistogramData.histogramLabel.histogramLength
      End If

      _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale(nStart) = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale(nNewStart)
      _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale(nEnd) = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale(nNewEnd)

      EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale, _
                                                GetStart(), _
                                                GetEnd(), _
                                                0, _
                                                uFlags)
      Return 1
   End Function

   Private Function ApplyResaleMaster() As Integer
      Dim nRet As Integer

      If (_interactiveHistogramData.shift) Then
         nRet = GetLUTResShift()
      Else
         nRet = GetLUTResNewSE()
      End If

      ' Apply the Red Channel...
      Dim useLUT As Boolean = applyImage.UseLookupTable
      applyImage.UseLookupTable = False

      If (Not applyImage.UseLookupTable AndAlso (applyImage.BitsPerPixel = 12 OrElse applyImage.BitsPerPixel = 16)) Then
         PrepareRemapIntensity(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Red)
      Else
         Dim cmd As New RemapIntensityCommand()
         ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
         Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment.Length)
         cmd.Flags = RemapIntensityCommandFlags.Red
         AddHandler cmd.Progress, AddressOf cmd_Progress
         cmd.Run(applyImage)
      End If
      applyImage.UseLookupTable = useLUT

      ' Apply the Green Channel...
      useLUT = applyImage.UseLookupTable
      applyImage.UseLookupTable = False

      If (Not applyImage.UseLookupTable AndAlso (applyImage.BitsPerPixel = 12 OrElse applyImage.BitsPerPixel = 16)) Then
         PrepareRemapIntensity(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Green)
      Else
         Dim cmd As New RemapIntensityCommand()
         ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
         Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment.Length)
         cmd.Flags = RemapIntensityCommandFlags.Green
         AddHandler cmd.Progress, AddressOf cmd_Progress
         cmd.Run(applyImage)
      End If
      applyImage.UseLookupTable = useLUT

      ' Apply the Blue Channel...
      useLUT = applyImage.UseLookupTable
      applyImage.UseLookupTable = False
      If (Not applyImage.UseLookupTable AndAlso (applyImage.BitsPerPixel = 12 OrElse applyImage.BitsPerPixel = 16)) Then
         PrepareRemapIntensity(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Blue)
      Else
         Dim cmd As New RemapIntensityCommand()
         ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
         Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment.Length)
         cmd.Flags = RemapIntensityCommandFlags.Blue
         AddHandler cmd.Progress, AddressOf cmd_Progress
         cmd.Run(applyImage)
      End If
      applyImage.UseLookupTable = useLUT

      Return 1
   End Function

   Private Function GetLUTRescaling() As Integer
      Dim nRet As Integer
      _interactiveHistogramData.grayLUT = True
      applyImage = _interactiveHistogramData.originalImage.CloneAll()
      If (ChildImage.UseLookupTable) Then
         applyImage.SetLookupTable(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBPrevLUT)
      End If

      If ((ChildImage.GrayscaleMode = RasterGrayscaleMode.None) AndAlso _interactiveHistogramData.channel = RasterColorChannel.Master AndAlso Not _interactiveHistogramData.signed) Then
         If (_interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex)) Then
            nRet = ApplyResaleMaster()
         End If
      Else
         If (_interactiveHistogramData.shift) Then
            nRet = GetLUTResShift()
         Else
            nRet = GetLUTResNewSE()
         End If

         Dim useLUT As Boolean = applyImage.UseLookupTable
         applyImage.UseLookupTable = False

         If (_interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex)) Then
            Dim cmd As New RemapIntensityCommand()
            ReDim cmd.LookupTable(_interactiveHistogramData.histogramLabel.histogramLength - 1)
            Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale, cmd.LookupTable, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment.Length)
            cmd.Flags = CType(_interactiveHistogramData.channel, RemapIntensityCommandFlags) Or RemapIntensityCommandFlags.Normal
            AddHandler cmd.Progress, AddressOf cmd_Progress
            cmd.Run(applyImage)
         End If
         applyImage.UseLookupTable = useLUT
      End If

      FreeImage(ChildImage)
      ChildImage = applyImage.CloneAll()
      Return 1
   End Function

   Private Sub _lblHistogram_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _lblHistogram.Paint
      Dim inRangePen, outRangePen As Pen
      Dim divideBy As Integer
      Dim startLoop, endLoop As Integer
      Dim penWidth As Integer = CInt(Math.Max(1, (_lblHistogram.Width - 49) / _interactiveHistogramData.histogramLabel.drawLength))

      inRangePen = New Pen(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).innerColor, penWidth)
      outRangePen = New Pen(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).outerColor, penWidth)

      ' Fill the background of the label with white brush...
      e.Graphics.FillRectangle(Brushes.White, 0, 0, _lblHistogram.Width, _lblHistogram.Height)

      ' Set the values to label that holds the statistical information...
      SetLabelsValues()

      ' Draw the histogram graph...
      If (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).maxHistogramValue = 0) Then
         divideBy = 1
      Else
         divideBy = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).maxHistogramValue
      End If

      startLoop = _interactiveHistogramData.histogramLabel.drawStartRange
      endLoop = _interactiveHistogramData.histogramLabel.drawEndRange
      DrawHistogram(e.Graphics, outRangePen, penWidth, divideBy, _interactiveHistogramData.histogramLabel.drawHistogram, 0, startLoop, endLoop + 1, True)

      If (_tabOptions.SelectedIndex <> 3) Then
         If (_interactiveHistogramData.fullView) Then
            startLoop = Math.Max(_interactiveHistogramData.histogramLabel.drawStartRange, GetStart())
            endLoop = Math.Min(_interactiveHistogramData.histogramLabel.drawEndRange, GetEnd())
         Else
            startLoop = Math.Max(_interactiveHistogramData.histogramLabel.drawStartRange, GetRealVal(GetStart()))
            endLoop = Math.Min(_interactiveHistogramData.histogramLabel.drawEndRange, GetRealVal(GetEnd()))
         End If
         DrawHistogram(e.Graphics, inRangePen, penWidth, divideBy, _interactiveHistogramData.histogramLabel.drawHistogram, startLoop - _interactiveHistogramData.histogramLabel.drawStartRange, startLoop, endLoop + 1, True)
      Else
         ' Draw the selected area between the start and end points...
         If (_interactiveHistogramData.fullView) Then
            startLoop = Math.Max(_interactiveHistogramData.histogramLabel.drawStartRange, GetStart())
            endLoop = Math.Min(_interactiveHistogramData.histogramLabel.drawEndRange, GetEnd())
         Else
            startLoop = Math.Max(_interactiveHistogramData.histogramLabel.drawStartRange, GetRealVal(GetStart()))
            endLoop = Math.Min(_interactiveHistogramData.histogramLabel.drawEndRange, GetRealVal(GetEnd()))
         End If
         DrawHistogram(e.Graphics, inRangePen, penWidth, divideBy, _interactiveHistogramData.histogramLabel.drawHistogram, startLoop - _interactiveHistogramData.histogramLabel.drawStartRange, startLoop, endLoop + 1, True)

         If (Not _interactiveHistogramData.shift) Then
            ' Draw the selected area between the new start and end points...
            If (_interactiveHistogramData.fullView) Then
               startLoop = Math.Max(_interactiveHistogramData.histogramLabel.drawStartRange, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newStartLine.position)
               endLoop = Math.Min(_interactiveHistogramData.histogramLabel.drawEndRange, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newEndLine.position)
            Else
               startLoop = Math.Max(_interactiveHistogramData.histogramLabel.drawStartRange, GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newStartLine.position))
               endLoop = Math.Min(_interactiveHistogramData.histogramLabel.drawEndRange, GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newEndLine.position))
            End If
            DrawHistogram(e.Graphics, inRangePen, penWidth, divideBy, _interactiveHistogramData.histogramLabel.drawHistogram, startLoop - _interactiveHistogramData.histogramLabel.drawStartRange, startLoop, endLoop + 1, True)
         End If
      End If

      ' Draw the X amd Y axis and draw the start and end ranges marks and texts.
      DrawAxisAndRanges(e.Graphics, penWidth)
   End Sub

   Private Sub DrawChanges()
      _mainForm.ActiveViewerForm.Viewer.Invalidate()
      _lblHistogram.Invalidate()
   End Sub

   Private Sub SetEditStart(ByVal value As Integer)
      Select Case (_tabOptions.SelectedIndex)
         Case 0
            _nudSegStartPt.Value = value
         Case 1
            _nudGrayStartPt.Value = value
         Case 2
            _nudNoiseStartPt.Value = value
         Case 3
            _nudResStartPt.Value = value
      End Select
   End Sub

   Private Sub SetEditEnd(ByVal value As Integer)
      Select Case (_tabOptions.SelectedIndex)
         Case 0
            _nudSegEndPt.Value = value
         Case 1
            _nudGrayEndPt.Value = value
         Case 2
            _nudNoiseEndPt.Value = value
         Case 3
            _nudResEndPt.Value = value
      End Select
   End Sub

   Private Function GetEditStart() As Integer
      Select Case (_tabOptions.SelectedIndex)
         Case 0
            Return CInt(_nudSegStartPt.Value)
         Case 1
            Return CInt(_nudGrayStartPt.Value)
         Case 2
            Return CInt(_nudNoiseStartPt.Value)
         Case 3
            Return CInt(_nudResStartPt.Value)
      End Select
      Return 0
   End Function

   Private Function GetEditEnd() As Integer
      Select Case (_tabOptions.SelectedIndex)
         Case 0
            Return CInt(_nudSegEndPt.Value)
         Case 1
            Return CInt(_nudGrayEndPt.Value)
         Case 2
            Return CInt(_nudNoiseEndPt.Value)
         Case 3
            Return CInt(_nudResEndPt.Value)
      End Select
      Return 0
   End Function

   Private Function GetNormalDrawFromSigned(ByVal value As Integer) As Integer
      If (_interactiveHistogramData.signed) Then
         Return (value + GetRealVal(Math.Abs(_interactiveHistogramData.histogramLabel.startRange)))
      Else
         Return value
      End If
   End Function

   Private Function GetNormalFromSigned(ByVal value As Integer) As Integer
      If (_interactiveHistogramData.signed) Then
         Return (value + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
      Else
         Return value
      End If
   End Function

   Private Function GetSignedFromNormal(ByVal value As Integer) As Integer
      If (_interactiveHistogramData.signed) Then
         Return (value - Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
      Else
         Return value
      End If
   End Function

   Private Sub ShowHideOptions()
      If (_interactiveHistogramData.pushed) Then
         Me.Height = Me.Height + _interactiveHistogramData.distance
         _btnOk.Top = _btnOk.Top + _interactiveHistogramData.distance
         _btnUndo.Top = _btnUndo.Top + _interactiveHistogramData.distance
         _btnCancel.Top = _btnCancel.Top + _interactiveHistogramData.distance
         _MainProgressBar.Top = _MainProgressBar.Top + _interactiveHistogramData.distance
         _grpView.Height = _grpView.Height + _interactiveHistogramData.distance
         _btnShowHideOptions.Text = "Hide Options <<"
      Else
         Me.Height = Me.Height - _interactiveHistogramData.distance
         _btnOk.Top = _btnOk.Top - _interactiveHistogramData.distance
         _btnUndo.Top = _btnUndo.Top - _interactiveHistogramData.distance
         _btnCancel.Top = _btnCancel.Top - _interactiveHistogramData.distance
         _MainProgressBar.Top = _MainProgressBar.Top - _interactiveHistogramData.distance
         _grpView.Height = _grpView.Height - _interactiveHistogramData.distance
         _btnShowHideOptions.Text = "Show Options >>"
      End If

      _tabOptions.Visible = _interactiveHistogramData.pushed
      _grpStatisticalInformation.Visible = _interactiveHistogramData.pushed
   End Sub

   Private Function GetColorFromEdit(ByVal value As Integer) As Color
      value = CInt((value * 255.0) / _interactiveHistogramData.histogramLabel.histogramLength)

      Select Case (CInt(_interactiveHistogramData.channel))
         Case 0
            Return Color.FromArgb(value, value, value)
         Case 1
            Return Color.FromArgb(value, 0, 0)
         Case 2
            Return Color.FromArgb(0, value, 0)
         Case 3
            Return Color.FromArgb(0, 0, value)
      End Select

      Return Color.Empty
   End Function

   Private Sub SetLabelsColor()
      Select Case (_tabOptions.SelectedIndex)
         Case 0
            If (_interactiveHistogramData.signed) Then
               _lblSegStartPtClr.BackColor = GetColorFromEdit(GetStart() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
               _lblSegEndPtClr.BackColor = GetColorFromEdit(GetEnd() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
            Else
               _lblSegStartPtClr.BackColor = GetColorFromEdit(GetStart())
               _lblSegEndPtClr.BackColor = GetColorFromEdit(GetEnd())
            End If

         Case 1
            If (_interactiveHistogramData.signed) Then
               _lblGrayStartPtClr.BackColor = GetColorFromEdit(GetStart() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
               _lblGrayEndPtClr.BackColor = GetColorFromEdit(GetEnd() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
            Else
               _lblGrayStartPtClr.BackColor = GetColorFromEdit(GetStart())
               _lblGrayEndPtClr.BackColor = GetColorFromEdit(GetEnd())
            End If

         Case 2
            If (_interactiveHistogramData.signed) Then
               _lblNoiseStartPtClr.BackColor = GetColorFromEdit(GetStart() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
               _lblNoiseEndPtClr.BackColor = GetColorFromEdit(GetEnd() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
            Else
               _lblNoiseStartPtClr.BackColor = GetColorFromEdit(GetStart())
               _lblNoiseEndPtClr.BackColor = GetColorFromEdit(GetEnd())
            End If

         Case 3
            If (_interactiveHistogramData.signed) Then
               _lblResStartPtClr.BackColor = GetColorFromEdit(GetStart() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
               _lblResEndPtClr.BackColor = GetColorFromEdit(GetEnd() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))
            Else
               _lblResStartPtClr.BackColor = GetColorFromEdit(GetStart())
               _lblResEndPtClr.BackColor = GetColorFromEdit(GetEnd())
            End If
      End Select
   End Sub


   Private Sub _lblHistogram_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _lblHistogram.MouseMove
      Dim nTempInt As Integer
      Dim nTempX, nTempY As Integer
      Dim nTemp, nOrgTempX As Integer

      If (_interactiveHistogramData.histogramLabel.zoomed) Then
         Return
      End If

      nTemp = _lblHistogram.Width - 25 - 25
      nTemp = CInt(nTemp / (_interactiveHistogramData.histogramLabel.drawEndRange - _interactiveHistogramData.histogramLabel.drawStartRange))
      nTemp = Math.Max(nTemp, 1)
      nTempX = (e.X - 23)
      nTempX = CInt(nTempX / nTemp)

      nTempX = nTempX + _interactiveHistogramData.histogramLabel.drawStartRange
      nTempY = e.Y

      nOrgTempX = nTempX
      If (Not (_interactiveHistogramData.fullView AndAlso Not _interactiveHistogramData.histogramLabel.zoomed)) Then
         nTempX = SetRealVal_MouseMove(nTempX)
      End If

      ' Set the proper mouse cursor...
      Me.Cursor = Cursors.Arrow
      If (_interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNone) Then
         If ((IsMouseOverPt(GetRealVal(GetStart()), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY) OrElse _
               (IsMouseOverPt(GetRealVal(GetEnd()), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY)))) Then
            Me.Cursor = Cursors.SizeWE
         ElseIf (_tabOptions.SelectedIndex = 3 AndAlso Not _interactiveHistogramData.shift) Then
            If (IsMouseOverPt(GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newStartLine.position), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY) OrElse _
                IsMouseOverPt(GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newEndLine.position), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY)) Then
               Me.Cursor = Cursors.SizeWE
            End If
         End If
      ElseIf (_interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveStart OrElse _
              _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveEnd OrElse _
              _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNewStart OrElse _
              _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNewEnd) Then
         Me.Cursor = Cursors.SizeWE
      End If

      If (nTempX < _interactiveHistogramData.histogramLabel.startRange OrElse nTempX > _interactiveHistogramData.histogramLabel.endRange) Then
         _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNone
      End If

      Select Case (_interactiveHistogramData.histogramLabel.moveType)
         Case HistogramData.MovePoint.MoveNone
            If (nTempX >= _interactiveHistogramData.histogramLabel.startRange AndAlso _
                nTempX <= _interactiveHistogramData.histogramLabel.endRange) Then
               _interactiveHistogramData.histogramLabel.mousePosition = nTempX
               If (_interactiveHistogramData.signed) Then
                  _interactiveHistogramData.histogramLabel.mousePosition += Math.Abs(_interactiveHistogramData.histogramLabel.startRange)
               End If

               ' Set the mouse position statistical information...
               Dim convert As Integer = CInt(nTempX * 10000.0 / _interactiveHistogramData.histogramLabel.histogramLength)
               _lblMousePercent.Text = (convert / 100.0).ToString()
               _lblMouseLevel.Text = nTempX.ToString()
               _lblMouseCount.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.histogramLabel.mousePosition)).ToString()
            End If

         Case HistogramData.MovePoint.MoveStart
            nTempInt = GetEnd()

            If (nTempX >= nTempInt) Then
               SetEditStart(nTempInt - 1)
            ElseIf (nTempX >= _interactiveHistogramData.histogramLabel.startRange AndAlso nTempX < _interactiveHistogramData.histogramLabel.endRange) Then
               SetEditStart(nTempX)
            Else
               SetEditStart(_interactiveHistogramData.histogramLabel.startRange)
            End If

         Case HistogramData.MovePoint.MoveEnd
            nTempInt = GetStart()

            If (nTempX <= nTempInt) Then
               SetEditEnd(nTempInt + 1)
            ElseIf (nTempX >= _interactiveHistogramData.histogramLabel.startRange AndAlso nTempX < _interactiveHistogramData.histogramLabel.endRange) Then
               SetEditEnd(nTempX)
            Else
               SetEditEnd(_interactiveHistogramData.histogramLabel.endRange)
            End If

         Case HistogramData.MovePoint.MoveNewStart
            If (nTempX < _interactiveHistogramData.histogramLabel.startRange) Then
               _nudResNewStart.Value = _interactiveHistogramData.histogramLabel.startRange
            ElseIf (nTempX >= _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newEndLine.position) Then
               _nudResNewStart.Value = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newEndLine.position - 1
            Else
               _nudResNewStart.Value = nTempX
            End If

         Case HistogramData.MovePoint.MoveNewEnd
            If (nTempX <= _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newStartLine.position) Then
               _nudResNewEnd.Value = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newStartLine.position + 1
            ElseIf (nTempX >= _interactiveHistogramData.histogramLabel.endRange - 1) Then
               _nudResNewEnd.Value = _interactiveHistogramData.histogramLabel.endRange - 1
            Else
               _nudResNewEnd.Value = nTempX
            End If
      End Select
   End Sub

   Private Sub _lblHistogram_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _lblHistogram.MouseDown
      If (e.Button = Windows.Forms.MouseButtons.Left) Then
         Dim nTempX, nTempY As Integer
         Dim nTemp, nOrgTempX As Integer

         _lblHistogram.Capture = True
         If (Not (Not _interactiveHistogramData.fullView AndAlso Not _interactiveHistogramData.histogramLabel.zoomed)) Then
            Return
         End If

         nTemp = _lblHistogram.Width - 25 - 25
         nTemp = CInt(nTemp / (_interactiveHistogramData.histogramLabel.drawEndRange - _interactiveHistogramData.histogramLabel.drawStartRange))
         nTemp = Math.Max(nTemp, 1)
         nTempX = (e.X - 23)
         nTempX = CInt(nTempX / nTemp)

         nTempX = nTempX + _interactiveHistogramData.histogramLabel.drawStartRange
         nTempX = Math.Max(GetNormalFromSigned(_interactiveHistogramData.histogramLabel.startRange), _
                  Math.Min(nTempX, GetNormalFromSigned(_interactiveHistogramData.histogramLabel.endRange)))
         nTempY = e.Y

         nOrgTempX = nTempX
         nTempX = SetRealVal(nTempX)

         _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNone

         ' Set the proper mouse cursor...
         If (_interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNone) Then
            If ((IsMouseOverPt(GetRealVal(GetStart()), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY) OrElse _
                  (IsMouseOverPt(GetRealVal(GetEnd()), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY)))) Then
               Me.Cursor = Cursors.SizeWE
            ElseIf (_tabOptions.SelectedIndex = 3 AndAlso Not _interactiveHistogramData.shift) Then
               If (IsMouseOverPt(GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newStartLine.position), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY) OrElse _
                     IsMouseOverPt(GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newEndLine.position), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY)) Then
                  Me.Cursor = Cursors.SizeWE
               End If
            Else
               Me.Cursor = Cursors.Arrow
            End If
         ElseIf (_interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveStart OrElse _
                  _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveEnd OrElse _
                  _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNewStart OrElse _
                  _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNewEnd) Then
            Me.Cursor = Cursors.SizeWE
         End If

         If (_tabOptions.SelectedIndex = 3 AndAlso Not _interactiveHistogramData.shift) Then
            If (IsMouseOverPt(GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newStartLine.position), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY)) Then
               _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNewStart
            ElseIf (IsMouseOverPt(GetRealVal(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newEndLine.position), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY)) Then
               _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNewEnd
            End If
         End If

         If (IsMouseOverPt(GetRealVal(GetStart()), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY)) Then
            If (GetRealVal(GetEnd()) - GetRealVal(GetStart()) > 10) Then
               _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveStart
            Else
               _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveEnd
            End If
         ElseIf (IsMouseOverPt(GetRealVal(GetEnd()), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY)) Then
            _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveEnd
         End If
         If (nTempX > _interactiveHistogramData.histogramLabel.endRange) Then
            SetEnd(_interactiveHistogramData.histogramLabel.endRange)
         End If
      End If
   End Sub

   Private Sub _lblHistogram_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _lblHistogram.MouseUp
      If (e.Button = Windows.Forms.MouseButtons.Left) Then
         Dim nTempX, nTempY As Integer
         Dim nTemp, nOrgTempX As Integer

         _lblHistogram.Capture = False

         nTemp = _lblHistogram.Width - 25 - 25
         nTemp = CInt(nTemp / (_interactiveHistogramData.histogramLabel.drawEndRange - _interactiveHistogramData.histogramLabel.drawStartRange))
         nTemp = Math.Max(nTemp, 1)
         nTempX = (e.X - 23)
         nTempX = CInt(nTempX / nTemp)

         nTempX = nTempX + _interactiveHistogramData.histogramLabel.drawStartRange
         nTempX = Math.Max(_interactiveHistogramData.histogramLabel.drawStartRange, Math.Min(nTempX, _interactiveHistogramData.histogramLabel.drawEndRange))
         nTempY = e.Y

         nOrgTempX = nTempX
         nTempX = SetRealVal(nTempX)

         If (_interactiveHistogramData.fullView AndAlso nOrgTempX >= _interactiveHistogramData.histogramLabel.drawStartRange AndAlso nOrgTempX <= _interactiveHistogramData.histogramLabel.drawEndRange) Then
            If ((Control.ModifierKeys And Keys.Shift) = Keys.Shift) Then
               nTemp = GetStart()
               If (nOrgTempX > nTemp + 1) Then
                  SetEditEnd(nOrgTempX)
               Else
                  SetEditEnd(nTemp + 1)
               End If
            Else
               nTemp = GetEnd()
               If (nOrgTempX < nTemp - 1) Then
                  SetEditStart(nOrgTempX)
               Else
                  SetEditStart(nTemp - 1)
               End If
            End If
         End If

         _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNone
      End If
   End Sub


   Private Sub EnableGrayControls()
      _lblGrayFunctionType.Enabled = Not _interactiveHistogramData.grayPredefinedPalette
      _cbGrayFunctionType.Enabled = Not _interactiveHistogramData.grayPredefinedPalette
      _lblGrayCenter.Enabled = Not _interactiveHistogramData.grayPredefinedPalette
      _txtGrayCenter.Enabled = Not _interactiveHistogramData.grayPredefinedPalette
      _lblGrayWidth.Enabled = Not _interactiveHistogramData.grayPredefinedPalette
      _txtGrayWidth.Enabled = Not _interactiveHistogramData.grayPredefinedPalette
      _cbGraySelectionOnly.Enabled = Not _interactiveHistogramData.grayPredefinedPalette
      _btnGrayStartColor.Enabled = Not _interactiveHistogramData.grayPredefinedPalette
      _lblGrayStartColor.Enabled = Not _interactiveHistogramData.grayPredefinedPalette
      _btnGrayEndColor.Enabled = Not _interactiveHistogramData.grayPredefinedPalette
      _lblGrayEndColor.Enabled = Not _interactiveHistogramData.grayPredefinedPalette

      If (_cbGrayFunctionType.SelectedIndex <> 2) Then
         _lblGrayFactor.Enabled = Not _interactiveHistogramData.grayPredefinedPalette
         _nudGrayFactor.Enabled = Not _interactiveHistogramData.grayPredefinedPalette
      End If
   End Sub

   Private Sub FitHistogram()
      PrepareCompressedHisto()

      _interactiveHistogramData.histogramLabel.drawLength = 256
      _interactiveHistogramData.histogramLabel.drawStartRange = 0
      _interactiveHistogramData.histogramLabel.drawEndRange = 255
      _interactiveHistogramData.fullView = False

      _interactiveHistogramData.histogramLabel.startRange = 0
      _interactiveHistogramData.histogramLabel.endRange = _interactiveHistogramData.histogramLabel.histogramLength - 1

      If (_interactiveHistogramData.signed) Then
         _interactiveHistogramData.histogramLabel.startRange = CInt(_interactiveHistogramData.histogramLabel.startRange - _interactiveHistogramData.histogramLabel.histogramLength / 2)
         _interactiveHistogramData.histogramLabel.endRange = CInt(_interactiveHistogramData.histogramLabel.endRange - _interactiveHistogramData.histogramLabel.histogramLength / 2)
      End If

      _hsRange.Value = _interactiveHistogramData.histogramLabel.startRange
      _hsRange.Enabled = False
      _hsRange.Visible = (_interactiveHistogramData.histogramLabel.histogramLength <> 256)

      _lblHelp.Visible = False

      _interactiveHistogramData.histogramLabel.zoomed = False

      _lblHistogram.Invalidate()
   End Sub

   Private Sub EnableRescaleOptions(ByVal enableShift As Boolean)
      ' Enable New Start and End Options...
      _lblResNewStart.Enabled = Not enableShift
      _nudResNewStart.Enabled = Not enableShift

      _lblResNewEnd.Enabled = Not enableShift
      _nudResNewEnd.Enabled = Not enableShift

      ' Enable Shift Options...
      _lblResShiftAmount.Enabled = enableShift
      _nudResShiftAmount.Enabled = enableShift
      _rbResShiftLeft.Enabled = enableShift
      _rbResShiftRight.Enabled = enableShift
      _interactiveHistogramData.shift = enableShift
   End Sub

   Private Sub _cbChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cbChannel.SelectedIndexChanged
      If (_interactiveHistogramData.channel <> _cbChannel.SelectedIndex) Then
         _interactiveHistogramData.channel = CType(_cbChannel.SelectedIndex, RasterColorChannel)
         Dim length As Integer = _interactiveHistogramData.histogramLabel.histogramLength
         Select Case (_tabOptions.SelectedIndex)
            Case 0
               _nudSegStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
               _nudSegStartPt.Maximum = _interactiveHistogramData.histogramLabel.endRange
               _nudSegEndPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
               _nudSegEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange

            Case 1
               _nudGrayStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
               _nudGrayStartPt.Maximum = _interactiveHistogramData.histogramLabel.endRange
               _nudGrayEndPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
               _nudGrayEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange

            Case 2
               _nudNoiseStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
               _nudNoiseStartPt.Maximum = _interactiveHistogramData.histogramLabel.endRange
               _nudNoiseEndPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
               _nudNoiseEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange

            Case 3
               _nudResStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
               _nudResStartPt.Maximum = _interactiveHistogramData.histogramLabel.endRange
               _nudResEndPt.Minimum = _interactiveHistogramData.histogramLabel.startRange
               _nudResEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange
               _nudResNewStart.Minimum = _interactiveHistogramData.histogramLabel.startRange
               _nudResNewStart.Maximum = _interactiveHistogramData.histogramLabel.endRange
               _nudResNewEnd.Minimum = _interactiveHistogramData.histogramLabel.startRange
               _nudResNewEnd.Maximum = _interactiveHistogramData.histogramLabel.endRange
         End Select

         SetEditStart(GetStart())
         SetEditEnd(GetEnd())
         If (_interactiveHistogramData.fullView OrElse _interactiveHistogramData.histogramLabel.zoomed) Then

            FitHistogram()
         End If

         SetLabelsColor()

         _interactiveHistogramData.getHistogram = True
         ApplyFilter()
         DrawChanges()
         _lblHistogram.Invalidate()
         _lblInner.BackColor = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).innerColor
         _lblOuter.BackColor = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).outerColor
      End If
   End Sub

   Private Sub _btnInner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnInner.Click
      Dim colorDlg As New ColorDialog()

      colorDlg.Color = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).innerColor
      If (colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then
         _lblInner.BackColor = colorDlg.Color
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).innerColor = colorDlg.Color
         _lblHistogram.Invalidate()
      End If
   End Sub

   Private Sub _btnOuter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOuter.Click
      Dim colorDlg As New ColorDialog()

      colorDlg.Color = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).outerColor
      If (colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then
         _lblOuter.BackColor = colorDlg.Color
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).outerColor = colorDlg.Color
         _lblHistogram.Invalidate()
      End If
   End Sub

   Private Sub _cbSelectionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cbSelectionType.SelectedIndexChanged
      SetStatisticalValue()
   End Sub

   Private Sub _btnShowHideOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnShowHideOptions.Click
      _interactiveHistogramData.pushed = Not _interactiveHistogramData.pushed
      ShowHideOptions()
   End Sub

   Private Sub _nudStartPt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
 Handles _nudSegStartPt.ValueChanged, _
         _nudGrayStartPt.ValueChanged, _
         _nudNoiseStartPt.ValueChanged, _
         _nudResStartPt.ValueChanged

      If (Not _doApply) Then
         Return
      End If
      Dim nTemp As Integer

      nTemp = GetEditStart()
      If (nTemp <> GetStart()) Then
         SetStart(nTemp)

         If (sender Is _nudSegStartPt) Then
            If (_interactiveHistogramData.signed) Then
               _lblSegStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetStart() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
            Else
               _lblSegStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetStart())).ToString()
            End If
            _nudSegEndPt.Minimum = GetStart() + 1
         ElseIf (sender Is _nudGrayStartPt) Then
            If (_interactiveHistogramData.signed) Then
               _lblGryStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetStart() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
            Else
               _lblGryStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetStart())).ToString()
            End If
            _nudGrayEndPt.Minimum = GetStart() + 1
         ElseIf (sender Is _nudNoiseStartPt) Then
            If (_interactiveHistogramData.signed) Then
               _lblNoiseStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetStart() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
            Else
               _lblNoiseStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetStart())).ToString()
            End If
            _nudNoiseEndPt.Minimum = GetStart() + 1
         ElseIf (sender Is _nudResStartPt) Then
            If (_interactiveHistogramData.signed) Then
               _lblResStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetStart() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
            Else
               _lblResStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetStart())).ToString()
            End If
            _nudResEndPt.Minimum = GetStart() + 1
         End If


         If (_cbSelectionType.SelectedIndex = 1 Or _cbSelectionType.SelectedIndex = 2) Then
            SetStatisticalValue()
         End If

         If (sender Is _nudGrayStartPt) Then
            _txtGrayWidth.Text = (GetEnd() - GetStart()).ToString()
            _txtGrayCenter.Text = (((Math.Abs(GetEnd()) - Math.Abs(GetStart())) / 2) + GetStart()).ToString()
         End If

         ApplyFilter()
         DrawChanges()

         SetLabelsColor()
      End If
   End Sub

   Private Sub _nudEndPt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
 Handles _nudSegEndPt.ValueChanged, _
         _nudGrayEndPt.ValueChanged, _
         _nudNoiseEndPt.ValueChanged, _
         _nudResEndPt.ValueChanged

      If (Not _doApply) Then
         Return
      End If

      Dim nTemp As Integer = GetEditEnd()
      If (nTemp <> GetEnd()) Then
         SetEnd(nTemp)

         If (sender Is _nudSegEndPt) Then
            If (_interactiveHistogramData.signed) Then
               _lblSegEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetEnd() + (Math.Abs(_interactiveHistogramData.histogramLabel.startRange)))).ToString()
            Else
               _lblSegEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetEnd())).ToString()
            End If
            _nudSegStartPt.Maximum = GetEnd() - 1
         ElseIf (sender Is _nudGrayEndPt) Then
            If (_interactiveHistogramData.signed) Then
               _lblGryEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetEnd() + (Math.Abs(_interactiveHistogramData.histogramLabel.startRange)))).ToString()
            Else
               _lblGryEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetEnd())).ToString()
            End If
            _nudGrayStartPt.Maximum = GetEnd() - 1
         ElseIf (sender Is _nudNoiseEndPt) Then
            If (_interactiveHistogramData.signed) Then
               _lblNoiseEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetEnd() + (Math.Abs(_interactiveHistogramData.histogramLabel.startRange)))).ToString()
            Else
               _lblNoiseEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetEnd())).ToString()
            End If
            _nudNoiseStartPt.Maximum = GetEnd() - 1
         ElseIf (sender Is _nudResEndPt) Then
            If (_interactiveHistogramData.signed) Then
               _lblResEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetEnd() + (Math.Abs(_interactiveHistogramData.histogramLabel.startRange)))).ToString()
            Else
               _lblResEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetEnd())).ToString()
            End If
            _nudResStartPt.Maximum = GetEnd() - 1
         End If

         If (_cbSelectionType.SelectedIndex = 1 OrElse _cbSelectionType.SelectedIndex = 3) Then
            SetStatisticalValue()
         End If

         If (sender Is _nudGrayStartPt) Then
            _txtGrayWidth.Text = (GetEnd() - GetStart()).ToString()
            _txtGrayCenter.Text = (((Math.Abs(GetEnd()) - Math.Abs(GetStart())) / 2) + GetStart()).ToString()
         End If

         ApplyFilter()
         DrawChanges()

         SetLabelsColor()
      End If
   End Sub

   Private Sub _btnSegStartColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnSegStartColor.Click
      Dim colorDlg As New ColorDialog()

      colorDlg.Color = GetColorFromRasterColor(_interactiveHistogramData.segmentStartColor)
      If (colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then
         _lblSegStartColor.BackColor = colorDlg.Color
         _interactiveHistogramData.segmentStartColor = Leadtools.Demos.Converters.FromGdiPlusColor(colorDlg.Color)
         ApplyFilter()
         DrawChanges()
      End If

   End Sub

   Private Sub _btnSegEndColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnSegEndColor.Click
      Dim colorDlg As New ColorDialog()

      colorDlg.Color = GetColorFromRasterColor(_interactiveHistogramData.segmentEndColor)
      If (colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then
         _lblSegEndColor.BackColor = colorDlg.Color
         _interactiveHistogramData.segmentEndColor = Leadtools.Demos.Converters.FromGdiPlusColor(colorDlg.Color)
         ApplyFilter()
         DrawChanges()
      End If
   End Sub

   Private Sub _rbSegGradient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _rbSegGradient.CheckedChanged
      _btnSegStartColor.Text = "Start Color"
      _btnSegEndColor.Text = "End Color"
      _interactiveHistogramData.gradient = True

      ApplyFilter()
      DrawChanges()
   End Sub

   Private Sub _rbSegThreshold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _rbSegThreshold.CheckedChanged
      _btnSegStartColor.Text = "Inner Color"
      _btnSegEndColor.Text = "Outer Color"
      _interactiveHistogramData.gradient = False

      ApplyFilter()
      DrawChanges()
   End Sub

   Private Sub _cbGrayFunctionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cbGrayFunctionType.SelectedIndexChanged
      If (_interactiveHistogramData.grayFunctionType <> CType(_cbGrayFunctionType.SelectedIndex, FunctionalLookupTableFlags)) Then
         _interactiveHistogramData.grayFunctionType = CType(_cbGrayFunctionType.SelectedIndex, FunctionalLookupTableFlags)

         If (_cbGrayFunctionType.SelectedIndex = 1) Then
            _nudGrayFactor.Minimum = 0
         Else
            _nudGrayFactor.Minimum = -1000
         End If

         If (_cbGrayFunctionType.SelectedIndex = 2) Then
            _nudGrayFactor.Enabled = False
            _lblGrayFactor.Enabled = False
         Else
            _nudGrayFactor.Enabled = True
            _lblGrayFactor.Enabled = True
         End If


         ApplyFilter()
         DrawChanges()
      End If
   End Sub

   Private Sub _nudGrayFactor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _nudGrayFactor.ValueChanged
      If (_interactiveHistogramData.grayFactor <> _nudGrayFactor.Value) Then
         _interactiveHistogramData.grayFactor = CInt(_nudGrayFactor.Value)
         ApplyFilter()
         DrawChanges()
      End If
   End Sub

   Private Sub _cbGraySelectionOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cbGraySelectionOnly.CheckedChanged
      _interactiveHistogramData.graySelectionOnly = _cbGraySelectionOnly.Checked
      ApplyFilter()
      DrawChanges()
   End Sub

   Private Sub _btnGrayStartColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGrayStartColor.Click
      Dim colorDlg As New ColorDialog()

      colorDlg.Color = GetColorFromRasterColor(_interactiveHistogramData.grayStartColor)
      If (colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then
         _lblGrayStartColor.BackColor = colorDlg.Color
         _interactiveHistogramData.grayStartColor = Leadtools.Demos.Converters.FromGdiPlusColor(colorDlg.Color)
         ApplyFilter()
         DrawChanges()
      End If
   End Sub

   Private Sub _btnGrayEndColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGrayEndColor.Click
      Dim colorDlg As New ColorDialog()

      colorDlg.Color = GetColorFromRasterColor(_interactiveHistogramData.grayEndColor)
      If (colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then
         _lblGrayEndColor.BackColor = colorDlg.Color
         _interactiveHistogramData.grayEndColor = Leadtools.Demos.Converters.FromGdiPlusColor(colorDlg.Color)
         ApplyFilter()
         DrawChanges()
      End If
   End Sub

   Private Sub _cbNoiseReplaceWith_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cbNoiseReplaceWith.SelectedIndexChanged
      If (_interactiveHistogramData.noiseReplaceType <> _cbNoiseReplaceWith.SelectedIndex) Then
         _interactiveHistogramData.noiseReplaceType = CType(_cbNoiseReplaceWith.SelectedIndex, HistogramData.FilterNoiseReplaceType)

         ApplyFilter()
         DrawChanges()

         If (_cbNoiseReplaceWith.SelectedIndex = 2) Then
            _btnNoiseReplaceColor.Enabled = True
         Else
            _btnNoiseReplaceColor.Enabled = False
         End If
      End If
   End Sub

   Private Sub _btnNoiseReplaceColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnNoiseReplaceColor.Click
      Dim colorDlg As New ColorDialog()

      colorDlg.Color = GetColorFromRasterColor(_interactiveHistogramData.noiseReplaceColor)
      If (colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then
         _lblNoiseReplaceColor.BackColor = colorDlg.Color
         _interactiveHistogramData.noiseReplaceColor = Leadtools.Demos.Converters.FromGdiPlusColor(colorDlg.Color)
         ApplyFilter()
         DrawChanges()
      End If
   End Sub

   Private Sub _rbResShift_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _rbResShift.CheckedChanged
      EnableRescaleOptions(True)
      ApplyFilter()
      DrawChanges()

   End Sub

   Private Sub _nudResShiftAmount_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _nudResShiftAmount.ValueChanged
      If (_interactiveHistogramData.rescaleShiftAmount <> _nudResShiftAmount.Value) Then
         _interactiveHistogramData.rescaleShiftAmount = CInt(_nudResShiftAmount.Value)
         If (_interactiveHistogramData.rescaleShiftAmount > _interactiveHistogramData.histogramLabel.endRange) Then
            _nudResShiftAmount.Value = _interactiveHistogramData.histogramLabel.endRange
            Return
         End If
         If (_interactiveHistogramData.rescaleShiftAmount < _interactiveHistogramData.histogramLabel.startRange) Then
            _nudResShiftAmount.Value = _interactiveHistogramData.histogramLabel.startRange
            Return
         End If
         ApplyFilter()
         DrawChanges()
      End If
   End Sub

   Private Sub _rbResShiftRight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _rbResShiftRight.CheckedChanged
      _interactiveHistogramData.shiftRight = True
      ApplyFilter()
      DrawChanges()
   End Sub

   Private Sub _rbResShiftLeft_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _rbResShiftLeft.CheckedChanged
      _interactiveHistogramData.shiftRight = False
      ApplyFilter()
      DrawChanges()
   End Sub

   Private Sub _rbResNewSE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _rbResNewSE.CheckedChanged
      EnableRescaleOptions(False)
      ApplyFilter()
      DrawChanges()
   End Sub

   Private Sub _nudResNewStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _nudResNewStart.ValueChanged
      If (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newStartLine.position <> _nudResNewStart.Value) Then
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newStartLine.position = CInt(_nudResNewStart.Value)

         _nudResNewEnd.Minimum = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newStartLine.position + 1

         ApplyFilter()
         DrawChanges()
      End If
   End Sub

   Private Sub _nudResNewEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _nudResNewEnd.ValueChanged
      If (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newEndLine.position <> _nudResNewEnd.Value) Then
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newEndLine.position = CInt(_nudResNewEnd.Value)

         _nudResNewStart.Maximum = _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.newEndLine.position - 1

         ApplyFilter()
         DrawChanges()
      End If
   End Sub

   Private Sub EnableApplyLUT(ByVal enable As Boolean)
      _btnSegApplyLUT.Enabled = enable
      _btnGrayApplyLUT.Enabled = enable
      _btnNoiseApplyLUT.Enabled = enable
      _btnResApplyLUT.Enabled = enable
   End Sub

   Private Sub _tabOptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _tabOptions.SelectedIndexChanged
      Dim str As String
      If (_interactiveHistogramData.signed) Then
         str = String.Format("%d", _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetStart() + Math.Abs(_interactiveHistogramData.histogramLabel.startRange)))
      Else
         str = String.Format("%d", _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetStart()))
      End If

      _lblSegStartPtOccVal.Text = str
      _lblGryStartPtOccVal.Text = str
      _lblNoiseStartPtOccVal.Text = str
      _lblResStartPtOccVal.Text = str

      If (_interactiveHistogramData.signed) Then
         str = String.Format("%d", _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetEnd() + (Math.Abs(_interactiveHistogramData.histogramLabel.startRange))))
      Else
         str = String.Format("%d", _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(GetEnd()))
      End If

      _lblSegEndPtOccVal.Text = str
      _lblGryEndPtOccVal.Text = str
      _lblNoiseEndPtOccVal.Text = str
      _lblResEndPtOccVal.Text = str

      SetEditStart(GetStart())
      SetEditEnd(GetEnd())

      If (_interactiveHistogramData.fullView OrElse _interactiveHistogramData.histogramLabel.zoomed) Then
         FitHistogram()
      End If

      ChildImage = _interactiveHistogramData.originalImage.CloneAll()

      EnableApplyLUT(_interactiveHistogramData.originalImage.UseLookupTable AndAlso _tabOptions.SelectedIndex < 2)

      If (_interactiveHistogramData.signed) Then
         _lblSegStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.startLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
         _lblSegEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.endLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()

         _lblGryStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.startLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
         _lblGryEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.endLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()

         _lblNoiseStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.startLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
         _lblNoiseEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.endLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()

         _lblResStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.startLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
         _lblResEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.endLine.position + Math.Abs(_interactiveHistogramData.histogramLabel.startRange))).ToString()
      Else
         _lblSegStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.startLine.position)).ToString()
         _lblSegEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.endLine.position)).ToString()

         _lblGryStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.startLine.position)).ToString()
         _lblGryEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.endLine.position)).ToString()

         _lblNoiseStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.startLine.position)).ToString()
         _lblNoiseEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.endLine.position)).ToString()

         _lblResStartPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.startLine.position)).ToString()
         _lblResEndPtOccVal.Text = (_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).rescale.endLine.position)).ToString()
      End If

      _chkSegApplyInProgress.Checked = _interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex)

      SetLabelsColor()
      ApplyFilter()
      DrawChanges()
   End Sub

   Private Function ApplyChanges() As Integer
      If (_interactiveHistogramData.getHistogram) Then
         Dim cmd As New HistogramCommand()
         cmd.Channel = CType(_interactiveHistogramData.channel, HistogramCommandFlags)
         AddHandler cmd.Progress, AddressOf cmd_Progress

         Try
            cmd.Run(ChildImage)
         Catch ex As Exception
            ex.Message.ToString()
            _interactiveHistogramData.histogramAvaliable = False
         End Try

         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram = cmd.Histogram

         If (_interactiveHistogramData.signed) Then
            Dim length As Integer = CInt(_interactiveHistogramData.histogramLabel.histogramLength / 2)

                Dim pTemp(length) As Int64

            Array.ConstrainedCopy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram, 0, _
                                  pTemp, 0, length)
            Array.ConstrainedCopy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram, length, _
                                  _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram, 0, length)
            Array.ConstrainedCopy(pTemp, 0, _
                                  _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram, length, length)
         End If

         If (Not _interactiveHistogramData.fullView) Then
            PrepareCompressedHisto()
         End If

         _interactiveHistogramData.getHistogram = False
      End If
      Return 1
   End Function

   Private Function ApplyChangesFromLUT(ByVal RGBLUT() As RasterColor, ByVal LUT() As Integer) As Integer
      Dim nRet As Integer = 0
      Dim useLUT As Boolean

      _interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex) = False
      ApplyInProgress(False)

      If ((ChildImage.GrayscaleMode = RasterGrayscaleMode.None AndAlso (Not ChildImage.UseLookupTable)) AndAlso _interactiveHistogramData.channel = RasterColorChannel.Master AndAlso Not _interactiveHistogramData.signed) Then
         FreeImage(applyImage)
         applyImage = _interactiveHistogramData.originalImage.CloneAll()

         Select Case (_tabOptions.SelectedIndex)
            Case 0
               nRet = ApplySegmentationMaster(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.startLine.position, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).segmentation.endLine.position)

            Case 1
               nRet = ApplyGrayMaster(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.startLine.position, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).grayDistribution.endLine.position)

            Case 2
               nRet = ApplyFilterMaster(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.startLine.position, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).filterNoise.endLine.position)

            Case 3
               nRet = ApplyResaleMaster()
         End Select

         FreeImage(ChildImage)
         ChildImage = applyImage.CloneAll()
      Else
         FreeImage(ChildImage)
         ChildImage = _interactiveHistogramData.originalImage.CloneAll()

         useLUT = ChildImage.UseLookupTable

         ChildImage.UseLookupTable = False

         Dim cmd As New RemapIntensityCommand()
         cmd.LookupTable = LUT
         cmd.Flags = CType(_interactiveHistogramData.channel, RemapIntensityCommandFlags) Or RemapIntensityCommandFlags.Normal
         AddHandler cmd.Progress, AddressOf cmd_Progress
         cmd.Run(ChildImage)
         ChildImage.UseLookupTable = useLUT
      End If

      Return 1
   End Function

   Private Sub FreeImage(ByVal image As RasterImage)
      If (Not IsNothing(image)) Then
         image.Dispose()
      End If
   End Sub

   Private Sub ConvertToGrayLUT()
      Dim value As Integer

      For index As Integer = 0 To _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray.Length - 1
         value = GetGrayValue(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray(index))
         _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray(index) = New RasterColor(value, value, value)
      Next index
   End Sub

   Private Sub _btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
 Handles _
         _btnGrayApplyToBitmap.Click, _
         _btnNoiseApplyBitmap.Click, _
         _btnResApplyBitmap.Click, _btnSegApply.Click

      Me.Cursor = Cursors.WaitCursor

      If ((Not _interactiveHistogramData.grayLUT OrElse _interactiveHistogramData.grayPredefinedPalette) AndAlso _interactiveHistogramData.originalImage.UseLookupTable) Then
         If (Messager.ShowQuestion(Me, "Color LUT may cause data lost" + vbCrLf + "Do you want to continue?", MessageBoxIcon.Warning, MessageBoxButtons.YesNo) = DialogResult.No) Then
            Return
         End If

         If ((_tabOptions.SelectedIndex = 1) AndAlso _interactiveHistogramData.originalImage.IsGray) Then
            ConvertToGrayLUT()
         End If
      End If


      Dim nRet As Integer = 0
      Dim nBPP As Integer = _interactiveHistogramData.originalImage.BitsPerPixel

      Select Case (_tabOptions.SelectedIndex)
         Case 0
            nRet = ApplyChangesFromLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTSegment, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTSegment)
         Case 1
            nRet = ApplyChangesFromLUT(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTGray)
         Case 2
            nRet = ApplyChangesFromLUT(Nothing, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTFilter)
         Case 3
            nRet = ApplyChangesFromLUT(Nothing, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).LUTRescale)
      End Select

      If (nRet = 1) Then
         FreeImage(_interactiveHistogramData.undoImage)

         _interactiveHistogramData.undoImage = _interactiveHistogramData.originalImage.CloneAll()

         _btnUndo.Enabled = True

         FreeImage(_interactiveHistogramData.originalImage)
         _interactiveHistogramData.originalImage = ChildImage.CloneAll()

         InitAfterApply()
         _interactiveHistogramData.getHistogram = True
         nRet = ApplyChanges()
         If (nRet = 1) Then
            DrawChanges()
         End If

         SetStatisticalValue()
         FitHistogram()
         _MainProgressBar.Value = 0
      End If
      Me.Cursor = Cursors.Arrow
   End Sub

   Private Sub _btnApplyLUT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
Handles _btnSegApplyLUT.Click, _
      _btnGrayApplyLUT.Click, _
      _btnNoiseApplyLUT.Click, _
      _btnResApplyLUT.Click

      Dim nRet As Integer = 1

      Dim lookUpTable() As RasterColor = ChildImage.GetLookupTable()
      Array.Copy(lookUpTable, _interactiveHistogramData.originalLUT, lookUpTable.Length)

      Select Case (_tabOptions.SelectedIndex)
         Case 0
            Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTSegment, _
                       _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBPrevLUT, _
                       _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTSegment.Length)

         Case 1
            Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray, _
                       _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBPrevLUT, _
                       _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBLUTGray.Length)
      End Select

      If (Not _interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex)) Then
         _interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex) = True
         nRet = ApplyFilter()
         DrawChanges()

         _interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex) = False
      End If

      If (nRet = 1) Then
         If (Not IsNothing(_interactiveHistogramData.undoImage)) Then
            FreeImage(_interactiveHistogramData.undoImage)
         End If

         _interactiveHistogramData.undoImage = _interactiveHistogramData.originalImage.CloneAll()
         _btnUndo.Enabled = True
      End If

      Array.Copy(lookUpTable, _interactiveHistogramData.originalLUT, lookUpTable.Length)

   End Sub

   Private Sub _btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
      Me.Close()
   End Sub

   Private Sub _btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOk.Click
      FreeImage(ChildImage)
      ChildImage = _interactiveHistogramData.originalImage.CloneAll()

      If (_interactiveHistogramData.originalImage.UseLookupTable AndAlso (_interactiveHistogramData.originalImage.GrayscaleMode <> RasterGrayscaleMode.None OrElse _interactiveHistogramData.signed)) Then
         ChildImage.SetLookupTable(_interactiveHistogramData.originalLUT)
      End If
   End Sub

   Private Sub _btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnUndo.Click
      Dim nRet As Integer

      FreeImage(_interactiveHistogramData.originalImage)
      _interactiveHistogramData.originalImage = _interactiveHistogramData.undoImage.CloneAll()

      _btnUndo.Enabled = False

      If (_interactiveHistogramData.originalImage.UseLookupTable) Then
         Dim tempArray() As RasterColor = _interactiveHistogramData.originalImage.GetLookupTable()

         Array.Copy(tempArray, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).RGBPrevLUT, _interactiveHistogramData.histogramLabel.histogramLength)
         Array.Copy(tempArray, _interactiveHistogramData.originalLUT, _interactiveHistogramData.histogramLabel.histogramLength)
      Else
         EnableApplyLUT(False)
      End If

      ChildImage = _interactiveHistogramData.originalImage.CloneAll()

      _mainForm.ActiveViewerForm.Invalidate(True)

      _interactiveHistogramData.getHistogram = True
      nRet = ApplyFilter()
      DrawChanges()

      ' Set the selection statistical Information...
      SetStatisticalValue()
      _MainProgressBar.Value = 0
   End Sub


   Private Sub _lblHistogram_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _lblHistogram.Leave
      _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNone
      Me.Cursor = Cursors.Arrow
   End Sub

   Private Sub _cmiZoomToSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmiZoomToSelection.Click
      If (_interactiveHistogramData.histogramLabel.drawEndRange - _interactiveHistogramData.histogramLabel.drawStartRange <= 256) Then
         _interactiveHistogramData.histogramLabel.drawStartRange = GetRealVal(GetStart())
         _interactiveHistogramData.histogramLabel.drawEndRange = GetRealVal(GetEnd())
         Dim signed As Boolean = False
         If (_interactiveHistogramData.signed) Then
            signed = _interactiveHistogramData.signed
            _interactiveHistogramData.signed = False
         End If
         _interactiveHistogramData.histogramLabel.drawLength = GetRealVal(GetEnd() - GetStart())
         If (signed) Then
            _interactiveHistogramData.signed = True
         End If

         _lblMousePercent.Text = "0"
         _lblMouseLevel.Text = "0"
         _lblMouseCount.Text = "0"

         _interactiveHistogramData.histogramLabel.zoomed = True
         Me.Invalidate(True)
      Else
         Messager.ShowError(Me, "Difference between the Start Point and the End Point must be less than 512.")
      End If
   End Sub

   Private Sub _cmiFitGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmiFitGraph.Click
      FitHistogram()
      _interactiveHistogramData.fullView = False
   End Sub

   Private Sub _cmiFullRangeView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmiFullRangeView.Click
      _interactiveHistogramData.histogramLabel.drawLength = _interactiveHistogramData.histogramLabel.histogramLength
      ReDim _interactiveHistogramData.histogramLabel.drawHistogram(_interactiveHistogramData.histogramLabel.drawLength - 1)

      Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram, _interactiveHistogramData.histogramLabel.drawHistogram, _interactiveHistogramData.histogramLabel.drawLength)

      _interactiveHistogramData.histogramLabel.drawLength = _interactiveHistogramData.histogramLabel.histogramLength
      If (Not _interactiveHistogramData.signed) Then
         _interactiveHistogramData.histogramLabel.drawEndRange = 255
         _interactiveHistogramData.histogramLabel.drawStartRange = 0
      Else
         _interactiveHistogramData.histogramLabel.drawStartRange = _interactiveHistogramData.histogramLabel.startRange
         _interactiveHistogramData.histogramLabel.drawEndRange = _interactiveHistogramData.histogramLabel.drawStartRange + 256
      End If
      _interactiveHistogramData.fullView = True

      SetLabelsValues()
      _hsRange.Visible = True
      _hsRange.Enabled = True

      _lblHelp.Visible = True
      Me.Invalidate(True)
   End Sub

   Private Sub _cmRightClickOptions_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _cmRightClickOptions.Opening
      _cmiZoomToSelection.Enabled = (GetEnd() - GetStart() >= _interactiveHistogramData.scale)
      _cmiFitGraph.Enabled = (_interactiveHistogramData.histogramLabel.zoomed OrElse _interactiveHistogramData.histogramLabel.drawLength <> 256)
      _cmiFullRangeView.Enabled = (_interactiveHistogramData.histogramLabel.drawLength = 256)

      If (_interactiveHistogramData.histogramLabel.histogramLength = 256) Then
         _cmiFullRangeView.Enabled = False
      End If

      _interactiveHistogramData.histogramLabel.moveType = HistogramData.MovePoint.MoveNone
   End Sub

   Private Sub CheckProgress()
      _cancelRun = False
      _MainProgressBar.Value = 0
   End Sub

   Private Sub cmd_Progress(ByVal sender As Object, ByVal e As RasterCommandProgressEventArgs)
      _MainProgressBar.Value = e.Percent

      If (_cancelRun) Then
         e.Cancel = True
      End If
   End Sub

   Private Sub _rbResShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
 Handles _rbResShift.Click, _
         _rbResNewSE.Click, _
         _rbResShiftLeft.Click, _
         _rbResShiftRight.Click

      If (sender Is _rbResShift AndAlso Not _rbResShift.Checked) Then
         _rbResNewSE.Checked = False
         _rbResShift.Checked = True
      ElseIf (sender Is _rbResNewSE AndAlso Not _rbResNewSE.Checked) Then
         _rbResShift.Checked = False
         _rbResNewSE.Checked = True
      ElseIf (sender Is _rbResShiftRight AndAlso Not _rbResShiftRight.Checked) Then
         _rbResShiftLeft.Checked = False
         _rbResShiftRight.Checked = True
      ElseIf (sender Is _rbResShiftLeft AndAlso Not _rbResShiftLeft.Checked) Then
         _rbResShiftRight.Checked = False
         _rbResShiftLeft.Checked = True
      End If
   End Sub

   Private Sub InteractiveHistDialog_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
      If (Me.DialogResult <> Windows.Forms.DialogResult.OK) Then
         FreeImage(_interactiveHistogramData.originalImage)
         ChildImage = _interactiveHistogramData.savedImage.CloneAll()
      End If
   End Sub

   Private Function Generate256Histogram(ByVal lut As RasterColor(), ByVal originalHistogram As Integer(), ByVal channel As HistogramCommandFlags) As Integer()

      Dim index As Integer
      Dim returnHistogram(256) As Integer

      For index = 0 To originalHistogram.Length - 1
         Select Case (channel)
            Case HistogramCommandFlags.Master
               returnHistogram(GetGrayValue(lut(index))) += originalHistogram(index)

            Case HistogramCommandFlags.Red
               returnHistogram(lut(index).R) += originalHistogram(index)

            Case HistogramCommandFlags.Green
               returnHistogram(lut(index).G) += originalHistogram(index)

            Case HistogramCommandFlags.Blue
               returnHistogram(lut(index).B) += originalHistogram(index)
         End Select
      Next index

      Return returnHistogram
   End Function

   Private Sub PrepareRemapIntensity(ByVal LUT() As Integer, ByVal length As Integer, ByVal channel As RasterColorChannel)
      Dim buffer() As Integer
      Dim i, j As UInteger
      Dim size As UInteger = CUInt(length)
      Dim useLUT As Boolean = False

      If (applyImage.UseLookupTable) Then
         applyImage.UseLookupTable = False
         useLUT = True
      End If

      Select Case (applyImage.BitsPerPixel)
         Case 12
            ReDim buffer(4095)
            size = 4096

         Case 16
            If ((applyImage.GrayscaleMode = RasterGrayscaleMode.None AndAlso IsNothing(applyImage.GetLookupTable())) AndAlso Not applyImage.Signed) Then
               ReDim buffer(length - 1)
               size = CUInt(length)
            Else
               ReDim buffer(65535)
               size = 65536
            End If

         Case Else
            ReDim buffer(length - 1)
            size = CUInt(length)
      End Select

      Select Case (applyImage.BitsPerPixel)
         Case 12
            For i = 0 To CUInt(length - 1)
               For j = 0 To CUInt((4096) / length - 1)
                  buffer(CInt((i * 4096) / length + j)) = CInt((LUT(CInt(i)) * 4096) / length)
               Next j
               If (i = 1536) Then
                  i = 1536
               End If
            Next i

         Case 16
            If ((applyImage.GrayscaleMode = RasterGrayscaleMode.None AndAlso IsNothing(applyImage.GetLookupTable())) AndAlso Not applyImage.Signed) Then
               Array.Copy(LUT, buffer, length)
            Else
               For i = 0 To CUInt(length - 1)
                  For j = 0 To CUInt((65536) / length - 1)
                     buffer(CInt((i * 65536) / length + j)) = CInt((CUInt(LUT(CInt(i))) * 65536) / length)
                  Next j
               Next i
            End If

         Case Else
            Array.Copy(LUT, buffer, length)
      End Select

      Dim cmd As New RemapIntensityCommand()
      cmd.Flags = CType(channel, RemapIntensityCommandFlags)
      cmd.LookupTable = buffer
      AddHandler cmd.Progress, AddressOf cmd_Progress
      cmd.Run(applyImage)

      applyImage.UseLookupTable = useLUT
   End Sub

   Private Function ApplyFilter() As Integer
      Dim result As Integer = 1
      Try
         Select Case (_tabOptions.SelectedIndex)
            Case 0
               result = GetLUTSegmentation()
            Case 1
               result = GetLUTGrayDistribution()
            Case 2
               result = GetLUTFilterNoise()
            Case 3
               result = GetLUTRescaling()
         End Select

         If (_interactiveHistogramData.histogramLabel.zoomed) Then
            _interactiveHistogramData.histogramLabel.drawStartRange = GetRealVal(GetStart())
            _interactiveHistogramData.histogramLabel.drawEndRange = GetRealVal(GetEnd())
         End If

         If (_interactiveHistogramData.getHistogram) Then
            Dim cmd As New HistogramCommand()
            cmd.Channel = CType(_interactiveHistogramData.channel, HistogramCommandFlags)
            If (_interactiveHistogramData.histogramLabel.histogramLength = 256) Then
               cmd.Channel = cmd.Channel Or HistogramCommandFlags.Force256
            End If

            AddHandler cmd.Progress, AddressOf cmd_Progress
            Try
               cmd.Run(_interactiveHistogramData.originalImage)
            Catch ex As Exception
               ex.Message.ToString()
               _interactiveHistogramData.histogramAvaliable = False
            End Try

            Array.Copy(cmd.Histogram, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram, cmd.Histogram.Length)

            If (_interactiveHistogramData.signed) Then
               Dim nLength As Integer = Convert.ToInt32(_interactiveHistogramData.histogramLabel.histogramLength / 2.0)

                    Dim pTemp(nLength) As Int64


               Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram, 0, pTemp, 0, nLength)
               Array.Copy(_interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram, CInt(_interactiveHistogramData.histogramLabel.histogramLength / 2), _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram, 0, nLength)
               Array.Copy(pTemp, 0, _interactiveHistogramData.cD(CInt(_interactiveHistogramData.channel)).orginalHistogram, CInt(_interactiveHistogramData.histogramLabel.histogramLength / 2), nLength)
            End If

            If (Not _interactiveHistogramData.fullView) Then
               PrepareCompressedHisto()
            End If

            _interactiveHistogramData.getHistogram = False
         End If

      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try

      _MainProgressBar.Value = 0

      Return result
   End Function

   Private Sub _chkApplyInProgress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _chkSegApplyInProgress.CheckedChanged, _chkResApplyInProgress.CheckedChanged, _chkNoiseApplyInProgress.CheckedChanged, _chkGrayApplyInProgress.CheckedChanged
      If (Not _doApply) Then
         Return
      End If

      _interactiveHistogramData.applyInProgress(_tabOptions.SelectedIndex) = CType(sender, CheckBox).Checked
      ApplyFilter()
      DrawChanges()
   End Sub
End Class
