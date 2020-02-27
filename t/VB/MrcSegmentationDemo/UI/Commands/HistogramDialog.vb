' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.ImageProcessing.Color

Namespace MrcSegmentationDemo
   ''' <summary>
   ''' Summary description for HistogramDialog.
   ''' </summary>
   Public Class HistogramDialog : Inherits System.Windows.Forms.Form
      Friend _lblChannel As System.Windows.Forms.Label
      Private WithEvents _cbChannel As System.Windows.Forms.ComboBox
      Private WithEvents _cbView As System.Windows.Forms.ComboBox
      Private WithEvents _lblHistogram As System.Windows.Forms.Label
      Private _groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents _numUDClipping As System.Windows.Forms.NumericUpDown
      Private _lblClipping As System.Windows.Forms.Label
      Private _groupBox2 As System.Windows.Forms.GroupBox
      Private _lblPercentileValue As System.Windows.Forms.Label
      Private _lblPercentile As System.Windows.Forms.Label
      Private _lblCountValue As System.Windows.Forms.Label
      Private _lblCount As System.Windows.Forms.Label
      Private _lblMedianValue As System.Windows.Forms.Label
      Private _lblMedian As System.Windows.Forms.Label
      Private _lblTotalPixelsValue As System.Windows.Forms.Label
      Private _lblTotalPixels As System.Windows.Forms.Label
      Private _lblLevelValue As System.Windows.Forms.Label
      Private _lblLevel As System.Windows.Forms.Label
      Private _lblMeanValue As System.Windows.Forms.Label
      Private _lblMean As System.Windows.Forms.Label
      Private WithEvents _btnClose As System.Windows.Forms.Button
      Friend _lblView As System.Windows.Forms.Label
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public Sub New(ByVal image As RasterImage)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
         '
         ' TODO: Add any constructor code after InitializeComponent call
         '

         InitClass(image)
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
         Me._lblChannel = New System.Windows.Forms.Label()
         Me._cbChannel = New System.Windows.Forms.ComboBox()
         Me._cbView = New System.Windows.Forms.ComboBox()
         Me._lblHistogram = New System.Windows.Forms.Label()
         Me._groupBox1 = New System.Windows.Forms.GroupBox()
         Me._numUDClipping = New System.Windows.Forms.NumericUpDown()
         Me._lblClipping = New System.Windows.Forms.Label()
         Me._groupBox2 = New System.Windows.Forms.GroupBox()
         Me._lblPercentileValue = New System.Windows.Forms.Label()
         Me._lblPercentile = New System.Windows.Forms.Label()
         Me._lblCountValue = New System.Windows.Forms.Label()
         Me._lblCount = New System.Windows.Forms.Label()
         Me._lblMedianValue = New System.Windows.Forms.Label()
         Me._lblMedian = New System.Windows.Forms.Label()
         Me._lblTotalPixelsValue = New System.Windows.Forms.Label()
         Me._lblTotalPixels = New System.Windows.Forms.Label()
         Me._lblLevelValue = New System.Windows.Forms.Label()
         Me._lblLevel = New System.Windows.Forms.Label()
         Me._lblMeanValue = New System.Windows.Forms.Label()
         Me._lblMean = New System.Windows.Forms.Label()
         Me._btnClose = New System.Windows.Forms.Button()
         Me._lblView = New System.Windows.Forms.Label()
         Me._groupBox1.SuspendLayout()
         CType(Me._numUDClipping, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._groupBox2.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _lblChannel
         ' 
         Me._lblChannel.Location = New System.Drawing.Point(8, 8)
         Me._lblChannel.Name = "_lblChannel"
         Me._lblChannel.Size = New System.Drawing.Size(56, 16)
         Me._lblChannel.TabIndex = 0
         Me._lblChannel.Text = "C&hannel:"
         ' 
         ' _cbChannel
         ' 
         Me._cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbChannel.Location = New System.Drawing.Point(61, 5)
         Me._cbChannel.Name = "_cbChannel"
         Me._cbChannel.Size = New System.Drawing.Size(83, 21)
         Me._cbChannel.TabIndex = 1
         ' 
         ' _cbView
         ' 
         Me._cbView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbView.Location = New System.Drawing.Point(432, 5)
         Me._cbView.Name = "_cbView"
         Me._cbView.Size = New System.Drawing.Size(83, 21)
         Me._cbView.TabIndex = 3
         ' 
         ' _lblHistogram
         ' 
         Me._lblHistogram.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblHistogram.Location = New System.Drawing.Point(6, 34)
         Me._lblHistogram.Name = "_lblHistogram"
         Me._lblHistogram.Size = New System.Drawing.Size(512, 152)
         Me._lblHistogram.TabIndex = 4
         ' 
         ' _groupBox1
         ' 
         Me._groupBox1.Controls.Add(Me._numUDClipping)
         Me._groupBox1.Controls.Add(Me._lblClipping)
         Me._groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._groupBox1.Location = New System.Drawing.Point(5, 198)
         Me._groupBox1.Name = "_groupBox1"
         Me._groupBox1.Size = New System.Drawing.Size(512, 43)
         Me._groupBox1.TabIndex = 5
         Me._groupBox1.TabStop = False
         ' 
         ' _numUDClipping
         ' 
         Me._numUDClipping.Location = New System.Drawing.Point(56, 15)
         Me._numUDClipping.Name = "_numUDClipping"
         Me._numUDClipping.Size = New System.Drawing.Size(48, 20)
         Me._numUDClipping.TabIndex = 1
         ' 
         ' _lblClipping
         ' 
         Me._lblClipping.Location = New System.Drawing.Point(12, 17)
         Me._lblClipping.Name = "_lblClipping"
         Me._lblClipping.Size = New System.Drawing.Size(45, 16)
         Me._lblClipping.TabIndex = 0
         Me._lblClipping.Text = "Cli&pping:"
         ' 
         ' _groupBox2
         ' 
         Me._groupBox2.Controls.Add(Me._lblPercentileValue)
         Me._groupBox2.Controls.Add(Me._lblPercentile)
         Me._groupBox2.Controls.Add(Me._lblCountValue)
         Me._groupBox2.Controls.Add(Me._lblCount)
         Me._groupBox2.Controls.Add(Me._lblMedianValue)
         Me._groupBox2.Controls.Add(Me._lblMedian)
         Me._groupBox2.Controls.Add(Me._lblTotalPixelsValue)
         Me._groupBox2.Controls.Add(Me._lblTotalPixels)
         Me._groupBox2.Controls.Add(Me._lblLevelValue)
         Me._groupBox2.Controls.Add(Me._lblLevel)
         Me._groupBox2.Controls.Add(Me._lblMeanValue)
         Me._groupBox2.Controls.Add(Me._lblMean)
         Me._groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._groupBox2.Location = New System.Drawing.Point(5, 248)
         Me._groupBox2.Name = "_groupBox2"
         Me._groupBox2.Size = New System.Drawing.Size(512, 72)
         Me._groupBox2.TabIndex = 6
         Me._groupBox2.TabStop = False
         ' 
         ' _lblPercentileValue
         ' 
         Me._lblPercentileValue.Location = New System.Drawing.Point(432, 48)
         Me._lblPercentileValue.Name = "_lblPercentileValue"
         Me._lblPercentileValue.Size = New System.Drawing.Size(64, 14)
         Me._lblPercentileValue.TabIndex = 11
         ' 
         ' _lblPercentile
         ' 
         Me._lblPercentile.Location = New System.Drawing.Point(371, 48)
         Me._lblPercentile.Name = "_lblPercentile"
         Me._lblPercentile.Size = New System.Drawing.Size(72, 15)
         Me._lblPercentile.TabIndex = 10
         Me._lblPercentile.Text = "Percentile:"
         ' 
         ' _lblCountValue
         ' 
         Me._lblCountValue.Location = New System.Drawing.Point(240, 48)
         Me._lblCountValue.Name = "_lblCountValue"
         Me._lblCountValue.Size = New System.Drawing.Size(57, 15)
         Me._lblCountValue.TabIndex = 9
         ' 
         ' _lblCount
         ' 
         Me._lblCount.Location = New System.Drawing.Point(192, 48)
         Me._lblCount.Name = "_lblCount"
         Me._lblCount.Size = New System.Drawing.Size(35, 15)
         Me._lblCount.TabIndex = 8
         Me._lblCount.Text = "Count:"
         ' 
         ' _lblMedianValue
         ' 
         Me._lblMedianValue.Location = New System.Drawing.Point(63, 48)
         Me._lblMedianValue.Name = "_lblMedianValue"
         Me._lblMedianValue.Size = New System.Drawing.Size(48, 14)
         Me._lblMedianValue.TabIndex = 7
         ' 
         ' _lblMedian
         ' 
         Me._lblMedian.Location = New System.Drawing.Point(9, 48)
         Me._lblMedian.Name = "_lblMedian"
         Me._lblMedian.Size = New System.Drawing.Size(47, 15)
         Me._lblMedian.TabIndex = 6
         Me._lblMedian.Text = "Median:"
         ' 
         ' _lblTotalPixelsValue
         ' 
         Me._lblTotalPixelsValue.Location = New System.Drawing.Point(432, 16)
         Me._lblTotalPixelsValue.Name = "_lblTotalPixelsValue"
         Me._lblTotalPixelsValue.Size = New System.Drawing.Size(64, 14)
         Me._lblTotalPixelsValue.TabIndex = 5
         ' 
         ' _lblTotalPixels
         ' 
         Me._lblTotalPixels.Location = New System.Drawing.Point(368, 16)
         Me._lblTotalPixels.Name = "_lblTotalPixels"
         Me._lblTotalPixels.Size = New System.Drawing.Size(72, 15)
         Me._lblTotalPixels.TabIndex = 4
         Me._lblTotalPixels.Text = "Total Pixels:"
         ' 
         ' _lblLevelValue
         ' 
         Me._lblLevelValue.Location = New System.Drawing.Point(240, 17)
         Me._lblLevelValue.Name = "_lblLevelValue"
         Me._lblLevelValue.Size = New System.Drawing.Size(57, 15)
         Me._lblLevelValue.TabIndex = 3
         ' 
         ' _lblLevel
         ' 
         Me._lblLevel.Location = New System.Drawing.Point(192, 16)
         Me._lblLevel.Name = "_lblLevel"
         Me._lblLevel.Size = New System.Drawing.Size(35, 15)
         Me._lblLevel.TabIndex = 2
         Me._lblLevel.Text = "Level:"
         ' 
         ' _lblMeanValue
         ' 
         Me._lblMeanValue.Location = New System.Drawing.Point(64, 18)
         Me._lblMeanValue.Name = "_lblMeanValue"
         Me._lblMeanValue.Size = New System.Drawing.Size(48, 14)
         Me._lblMeanValue.TabIndex = 1
         ' 
         ' _lblMean
         ' 
         Me._lblMean.Location = New System.Drawing.Point(10, 17)
         Me._lblMean.Name = "_lblMean"
         Me._lblMean.Size = New System.Drawing.Size(38, 15)
         Me._lblMean.TabIndex = 0
         Me._lblMean.Text = "Mean:"
         ' 
         ' _btnClose
         ' 
         Me._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnClose.Location = New System.Drawing.Point(216, 328)
         Me._btnClose.Name = "_btnClose"
         Me._btnClose.TabIndex = 7
         Me._btnClose.Text = "&Close"
         ' 
         ' _lblView
         ' 
         Me._lblView.Location = New System.Drawing.Point(392, 8)
         Me._lblView.Name = "_lblView"
         Me._lblView.Size = New System.Drawing.Size(32, 16)
         Me._lblView.TabIndex = 2
         Me._lblView.Text = "&View:"
         ' 
         ' HistogramDialog
         ' 
         Me.AcceptButton = Me._btnClose
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnClose
         Me.ClientSize = New System.Drawing.Size(522, 359)
         Me.Controls.Add(Me._lblView)
         Me.Controls.Add(Me._btnClose)
         Me.Controls.Add(Me._groupBox2)
         Me.Controls.Add(Me._groupBox1)
         Me.Controls.Add(Me._lblHistogram)
         Me.Controls.Add(Me._cbView)
         Me.Controls.Add(Me._cbChannel)
         Me.Controls.Add(Me._lblChannel)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "HistogramDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Histogram Dialog"
         Me._groupBox1.ResumeLayout(False)
         CType(Me._numUDClipping, System.ComponentModel.ISupportInitialize).EndInit()
         Me._groupBox2.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private _histogramCommand As HistogramCommand
      Private _image As RasterImage
      Private _maximumHistogramValue As Single

      Private Sub InitClass(ByVal image As RasterImage)
         _image = image
         _histogramCommand = New HistogramCommand()
         _histogramCommand.Channel = CType(0, HistogramCommandFlags)
         _histogramCommand.Run(_image)
         SetLabelsValues()

         _cbChannel.Items.Add("Master")
         _cbChannel.Items.Add("Red")
         _cbChannel.Items.Add("Green")
         _cbChannel.Items.Add("Blue")
         _cbChannel.SelectedIndex = 0

         _cbView.Items.Add("Area")
         _cbView.Items.Add("Line")
         _cbView.SelectedIndex = 0
      End Sub

      Private Sub _btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnClose.Click
         Close()
      End Sub

      Private Sub GetMaximumHistogramValue(ByRef maximum As Single, ByRef sumMean As Int64, ByRef totalPixels As Int64)

         Dim histogramValues As Int64() = _histogramCommand.Histogram

         totalPixels = histogramValues(0)
         sumMean = histogramValues(0)

         Dim index As Integer
         For index = 1 To 255
            totalPixels += histogramValues(index)
            sumMean += histogramValues(index) * index
            If histogramValues(index) > CInt(maximum) Then
               maximum = CSng(histogramValues(index))
            End If
         Next index
      End Sub

      Private Function GetMedianValue(ByVal totalSum As Int64) As Integer

         Dim histogramValues As Int64() = _histogramCommand.Histogram
         Dim sumMedian As Int64 = 0

         Dim index As Integer

         For index = 1 To 255
            sumMedian += histogramValues(index)

            If sumMedian >= CInt(totalSum / 2) Then
               Return index
            End If
         Next index
         Return 0
      End Function

      Private Sub SetLabelsValues()
         _maximumHistogramValue = _histogramCommand.Histogram(0)

         Dim sumMean As Int64 = 0
         Dim totalPixels As Int64 = 0

         GetMaximumHistogramValue(_maximumHistogramValue, sumMean, totalPixels)

         _lblMedianValue.Text = (GetMedianValue(totalPixels)).ToString()
         _lblTotalPixelsValue.Text = totalPixels.ToString()
         _lblMeanValue.Text = (CSng(sumMean) / totalPixels).ToString()
      End Sub

      Private Sub _cbChannel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbChannel.SelectedIndexChanged
         _histogramCommand.Channel = CType(_cbChannel.SelectedIndex, HistogramCommandFlags)
         _histogramCommand.Run(_image)
         SetLabelsValues()

         _lblHistogram.Invalidate()
      End Sub

      Private Sub _lblHistogram_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _lblHistogram.MouseMove
         Dim histogramValues As Int64() = _histogramCommand.Histogram

         Dim index As Integer = CInt(e.X / 2)

         If index >= histogramValues.Length OrElse index < 0 Then
            Return
         End If

         _lblLevelValue.Text = index.ToString()
         _lblCountValue.Text = (histogramValues(index)).ToString()
         Dim tempI As Integer = CInt(e.X / 510.0 * 10000)
         _lblPercentileValue.Text = ((CSng(tempI) / 100).ToString() & "%")
      End Sub

      Private Sub _cbView_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbView.SelectedIndexChanged
         _lblHistogram.Invalidate()
      End Sub

      Private Sub _lblHistogram_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _lblHistogram.Paint
         Dim pen As Pen

         Select Case _cbChannel.SelectedIndex
            Case 1
               pen = New Pen(Color.Red, 2)
            Case 2
               pen = New Pen(Color.Green, 2)
            Case 3
               pen = New Pen(Color.Blue, 2)
            Case Else
               pen = New Pen(Color.Black, 2)
         End Select

         e.Graphics.Clear(SystemColors.Control)

         Dim yViewValue As Single
         Dim xViewValue As Single
         Dim histogramValues As Int64() = _histogramCommand.Histogram

         Dim previousPoint As Point = New Point(0, _lblHistogram.Height)
         Dim index As Integer
         For index = 0 To 255
            If _numUDClipping.Value <> 100 Then
               yViewValue = CSng(Math.Min(_lblHistogram.Height, (histogramValues(index) / ((1.0 - CSng(_numUDClipping.Value) / 100.0) * _maximumHistogramValue)) * _lblHistogram.Height + 0.5))
            Else
               yViewValue = _lblHistogram.Height
            End If

            xViewValue = index * 2

            If _cbView.SelectedIndex = 0 Then
               e.Graphics.DrawLine(pen, xViewValue, _lblHistogram.Height, xViewValue, _lblHistogram.Height - yViewValue)
            Else
               Dim currectPoint As Point = New Point(0)

               currectPoint.X = CInt(xViewValue)
               currectPoint.Y = CInt(_lblHistogram.Height - yViewValue)
               e.Graphics.DrawLine(pen, previousPoint, currectPoint)
               previousPoint = currectPoint
            End If
         Next index
      End Sub

      Private Sub _numUDClipping_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numUDClipping.ValueChanged
         _lblHistogram.Invalidate()
      End Sub
   End Class
End Namespace
