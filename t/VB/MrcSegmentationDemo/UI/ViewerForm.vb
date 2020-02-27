' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Reflection

Imports Leadtools
Imports Leadtools.Mrc
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Color

Imports Leadtools.Drawing
Imports System.Drawing.Drawing2D

Namespace MrcSegmentationDemo
   ''' <summary>
   ''' Summary description for ViewerForm.
   ''' </summary>
   Public Class ViewerForm : Inherits System.Windows.Forms.Form
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
         InitClass()
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewerForm))
         Me._cmenuCombine = New System.Windows.Forms.ContextMenu()
         Me._cmenuCombineSegments = New System.Windows.Forms.MenuItem()
         Me._cmenuEnlargeSegment = New System.Windows.Forms.MenuItem()
         Me._cmenuShowInNewWindow = New System.Windows.Forms.MenuItem()
         Me._cmenuSeperator1 = New System.Windows.Forms.MenuItem()
         Me._cmenuShowType = New System.Windows.Forms.MenuItem()
         Me._cmenuShowProperties = New System.Windows.Forms.MenuItem()
         Me._cmenuShowHistogram = New System.Windows.Forms.MenuItem()
         Me._cmenuUniqueColors = New System.Windows.Forms.MenuItem()
         Me.SuspendLayout()
         ' 
         ' _cmenuCombine
         ' 
         Me._cmenuCombine.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._cmenuCombineSegments, Me._cmenuEnlargeSegment, Me._cmenuShowInNewWindow, Me._cmenuSeperator1, Me._cmenuShowType, Me._cmenuShowProperties, Me._cmenuShowHistogram, Me._cmenuUniqueColors})
         ' 
         ' _cmenuCombineSegments
         ' 
         Me._cmenuCombineSegments.Index = 0
         Me._cmenuCombineSegments.Text = "Combine Segments"
         ' 
         ' _cmenuEnlargeSegment
         ' 
         Me._cmenuEnlargeSegment.Index = 1
         Me._cmenuEnlargeSegment.Text = "Enlarge Segment"
         ' 
         ' _cmenuShowInNewWindow
         ' 
         Me._cmenuShowInNewWindow.Index = 2
         Me._cmenuShowInNewWindow.Text = "Show In New Window"
         ' 
         ' _cmenuSeperator1
         ' 
         Me._cmenuSeperator1.Index = 3
         Me._cmenuSeperator1.Text = "-"
         ' 
         ' _cmenuShowType
         ' 
         Me._cmenuShowType.Index = 4
         Me._cmenuShowType.Text = "Show Type..."
         ' 
         ' _cmenuShowProperties
         ' 
         Me._cmenuShowProperties.Index = 5
         Me._cmenuShowProperties.Text = "Show Properties..."
         ' 
         ' _cmenuShowHistogram
         ' 
         Me._cmenuShowHistogram.Index = 6
         Me._cmenuShowHistogram.Text = "Show Histogram..."
         ' 
         ' _cmenuUniqueColors
         ' 
         Me._cmenuUniqueColors.Index = 7
         Me._cmenuUniqueColors.Text = "Unique Colors..."
         ' 
         ' ViewerForm
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(724, 448)
         Me.ContextMenu = Me._cmenuCombine
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.Name = "ViewerForm"
         Me.ShowInTaskbar = False
         Me.Text = "ViewerForm"
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private _viewer As ImageViewer
      Private _name As String
      Private _mrcSegmenter As MrcSegmenter
      Private _segmentsData() As MrcSegmentData
      Private _index As Integer
      Private _selectedSegment As Integer
      Private _selectedCombineSegment As Integer
      Private _selectionRectangle As Rectangle()
      Private _selectionCombineRectangle As Rectangle()
      Private _resizeSegment As Boolean
      Private WithEvents _cmenuCombine As ContextMenu
      Private WithEvents _cmenuCombineSegments As MenuItem
      Private _callback As MrcEnumerateSegmentsInfo
      Private _mrcStart As Boolean
      Private _addSegment As Boolean
      Private _drawNewSegment As Boolean
      Private _resizeIndex As Integer
      Private _enableUndo As Boolean
      Private _moveSegment As Boolean
      Private _movePoint As Point
      Private _drawRectangle As Rectangle
      Private _preResize As Rectangle
      Private _optionsChanged As Boolean
      Private _previousSegmenter As MrcSegmenter
      Private _multiSelection As Boolean
      Private _selectionArray As Boolean()
      '      private MrcSegmenter _testSegmenter;

      Private WithEvents _cmenuEnlargeSegment As System.Windows.Forms.MenuItem
      Private WithEvents _cmenuShowInNewWindow As System.Windows.Forms.MenuItem
      Private WithEvents _cmenuShowType As System.Windows.Forms.MenuItem
      Private WithEvents _cmenuShowProperties As System.Windows.Forms.MenuItem
      Private WithEvents _cmenuShowHistogram As System.Windows.Forms.MenuItem
      Private WithEvents _cmenuUniqueColors As System.Windows.Forms.MenuItem
      Private _cmenuSeperator1 As System.Windows.Forms.MenuItem

      Public Property OptionsChanged() As Boolean
         Get
            Return _optionsChanged
         End Get
         Set(value As Boolean)
            _optionsChanged = Value
         End Set
      End Property

      Public ReadOnly Property ViewerSegmenter() As MrcSegmenter
         Get
            Return _mrcSegmenter
         End Get
      End Property

      Public ReadOnly Property EnableUndo() As Boolean
         Get
            Return _enableUndo
         End Get
      End Property

      Public Property SelectedSegment() As Integer
         Get
            Return _selectedSegment
         End Get
         Set(value As Integer)
            _selectedSegment = Value
         End Set
      End Property

      Public ReadOnly Property SelectedCombineSegment() As Integer
         Get
            Return _selectedCombineSegment
         End Get
      End Property

      Public ReadOnly Property MrcStarted() As Boolean
         Get
            Return _mrcStart
         End Get
      End Property

      Public ReadOnly Property Image() As RasterImage
         Get
            Return _viewer.Image
         End Get
      End Property

      Public ReadOnly Property Viewer() As ImageViewer
         Get
            Return _viewer
         End Get
      End Property

      Public Property AddSegment() As Boolean
         Get
            Return _addSegment
         End Get
         Set(value As Boolean)
            _addSegment = Value
         End Set
      End Property

      Public Property DrawNewSegment() As Boolean
         Get
            Return _drawNewSegment
         End Get
         Set(value As Boolean)
            _drawNewSegment = Value
         End Set
      End Property

      Private Sub InitClass()
         _viewer = New ImageViewer()
         _viewer.Dock = DockStyle.Fill
         _viewer.BorderStyle = BorderStyle.None
         AddHandler _viewer.ImeModeChanged, AddressOf _viewer_SizeModeChanged
         AddHandler _viewer.DragEnter, AddressOf _viewer_DragEnter
         AddHandler _viewer.DragDrop, AddressOf _viewer_DragDrop
         AddHandler _viewer.PostRender, AddressOf _viewer_PostRender
         AddHandler _viewer.MouseDown, AddressOf _viewer_mouseDown
         AddHandler _viewer.MouseUp, AddressOf _viewer_mouseUp
         AddHandler _viewer.MouseMove, AddressOf _viewer_mouseMove
         AddHandler _viewer.KeyDown, AddressOf _viewer_KeyDown
         Controls.Add(_viewer)
         _viewer.BringToFront()
         _viewer.AllowDrop = True

         _callback = New MrcEnumerateSegmentsInfo(AddressOf MrcEnumerateSegmentInfoCallback)

         _selectedSegment = -1
         _selectedCombineSegment = -1
         _index = 1

         _mrcStart = False
         _addSegment = False
         _moveSegment = False
         _drawNewSegment = False
         _optionsChanged = False
         _cmenuCombineSegments.Enabled = False

         _segmentsData = New MrcSegmentData(_index - 1) {}
         _selectionArray = New Boolean(_index - 1) {}

         _selectionRectangle = New Rectangle(7) {}
         _selectionCombineRectangle = New Rectangle(7) {}
      End Sub

      Private Sub _viewer_PostRender(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs)
         Dim drawFont As Font = New Font("Arial", 9, FontStyle.Bold)

         Try
            Dim g As Graphics = e.PaintEventArgs.Graphics
            Dim t As Transformer = New Transformer(Tools.ToMatrix(_viewer.ImageTransform))

            If _mrcStart Then
               Dim index As Integer = 0
               Do While index < _segmentsData.Length
                  Dim segmentRect As Rectangle = Leadtools.Demos.Converters.ConvertRect(_segmentsData(index).ImageSegment)
                  segmentRect = Rectangle.Round(t.RectangleToPhysical(segmentRect))

                  g.DrawRectangle(Pens.Red, segmentRect)

                  Dim text As String = String.Empty
                  If _segmentsData(index).SegmentType = MrcSegmentType.Background Then
                     text = "BG"
                  ElseIf _segmentsData(index).SegmentType = MrcSegmentType.OneColor Then
                     text = "1C"
                  ElseIf _segmentsData(index).SegmentType = MrcSegmentType.Text2BitBw Then
                     text = "T2BW"
                  ElseIf _segmentsData(index).SegmentType = MrcSegmentType.Text1BitBw Then
                     text = "T1BW"
                  ElseIf _segmentsData(index).SegmentType = MrcSegmentType.Text1BitColor Then
                     text = "T1C"
                  ElseIf _segmentsData(index).SegmentType = MrcSegmentType.Text2BitColor Then
                     text = "T2C"
                  ElseIf _segmentsData(index).SegmentType = MrcSegmentType.Grayscale2Bit Then
                     text = "G2"
                  ElseIf _segmentsData(index).SegmentType = MrcSegmentType.Grayscale8Bit Then
                     text = "G8"
                  ElseIf _segmentsData(index).SegmentType = MrcSegmentType.Picture Then
                     text = "P"
                  End If

                  If (CType(MdiParent, MainForm)).ShowSegmentType Then
                     Dim textStart As Point = New Point(segmentRect.Left + 5, segmentRect.Top + 5)
                     Dim textSize As Size = Size.Round(g.MeasureString(text, drawFont))
                     Dim textRect As Rectangle = New Rectangle(textStart.X, textStart.Y, textSize.Width + 1, textSize.Height + 1)
                     g.FillRectangle(Brushes.White, textRect)
                     g.DrawString(text, drawFont, Brushes.Black, textRect)
                  End If
                  index += 1
               Loop

               If _mrcStart AndAlso _selectedSegment <> -2 Then
                  If _selectedSegment <> -1 Then
                     _selectionArray(_selectedSegment) = True
                     If _multiSelection Then
                        index = 0
                        Do While index < _index - 1
                           If _selectionArray(index) Then
                              GetSelectionRectangles(index)
                              For index1 As Integer = 0 To 7
                                 Dim rc As Rectangle = _selectionRectangle(index1)
                                 rc = Rectangle.Round(t.RectangleToPhysical(rc))
                                 g.FillRectangle(Brushes.White, rc)
                                 g.DrawRectangle(Pens.Black, rc)
                              Next index1
                           End If
                           index += 1
                        Loop
                     Else
                        For index = 0 To 7
                           Dim rc As Rectangle = _selectionRectangle(index)
                           rc = Rectangle.Round(t.RectangleToPhysical(rc))
                           g.FillRectangle(Brushes.White, rc)
                           g.DrawRectangle(Pens.Black, rc)

                           If _selectedCombineSegment <> -1 Then
                              rc = _selectionCombineRectangle(index)
                              rc = Rectangle.Round(t.RectangleToPhysical(rc))
                              g.FillRectangle(Brushes.White, rc)
                              g.DrawRectangle(Pens.Black, rc)
                           End If
                        Next index
                     End If
                  Else
                     Dim index1 As Integer = 0
                     Do While index1 < _index - 1
                        If _selectionArray(index1) Then
                           GetSelectionRectangles(index1)
                           For index = 0 To 7
                              Dim rc As Rectangle = _selectionRectangle(index)
                              rc = Rectangle.Round(t.RectangleToPhysical(rc))
                              g.FillRectangle(Brushes.White, rc)
                              g.DrawRectangle(Pens.Black, rc)
                           Next index
                        End If
                        index1 += 1
                     Loop
                  End If
               End If
            End If

            If _addSegment AndAlso _drawNewSegment Then
               Dim rc As Rectangle = DemosGlobal.FixRectangle(_drawRectangle)
               g.DrawRectangle(Pens.Red, rc)
            End If
         Finally
            drawFont.Dispose()
         End Try

      End Sub

      Public Sub Initialize(ByVal info As ImageInformation, ByVal paintProperties As RasterPaintProperties, ByVal snap_Renamed As Boolean)
         _viewer.BeginUpdate()
         UpdatePaintProperties(paintProperties)
         _viewer.Image = info.Image
         If Not _viewer.Image Is Nothing Then
            AddHandler _viewer.Image.Changed, AddressOf Image_Changed
         End If
         _name = info.Name
         If snap_Renamed Then
            Snap()
         End If
         UpdateCaption()
         _viewer.EndUpdate()
      End Sub

      Public Sub UpdatePaintProperties(ByVal paintProperties As RasterPaintProperties)
         _viewer.PaintProperties = paintProperties
      End Sub

      Private Sub UpdateCaption()
         Text = String.Format(_name)
      End Sub

      Private Sub Image_Changed(ByVal sender As Object, ByVal e As RasterImageChangedEventArgs)
         UpdateCaption()
         If Not MdiParent Is Nothing Then
            CType(MdiParent, MainForm).UpdateControls()
         End If
      End Sub

      Private Sub _viewer_SizeModeChanged(ByVal sender As Object, ByVal e As EventArgs)
         CType(MdiParent, MainForm).UpdateControls()
      End Sub

      Public Sub Snap()
         _viewer.ClientSize = _viewer.ClientRectangle.Size
         ClientSize = _viewer.ClientSize
      End Sub

      Private Sub _viewer_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
         If Tools.CanDrop(e.Data) Then
            e.Effect = DragDropEffects.Copy
         End If
      End Sub

      Private Sub _viewer_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
         If Tools.CanDrop(e.Data) Then
            ClearSegments()
            Dim files As String() = Tools.GetDropFiles(e.Data)
            If Not files Is Nothing Then
               CType(MdiParent, MainForm).LoadDropFiles(Me, files)
            End If
         End If
      End Sub

      Public Function GetNewSegmenter() As MrcSegmenter
         Dim mainForm As MainForm = (CType(MdiParent, MainForm))
         Return (New MrcSegmenter(_viewer.Image, Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._backColor), Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._foreColor)))

      End Function

      Public Sub SetValuesToDialog(ByRef optionsDialog As Options)
         Dim mainForm As MainForm = (CType(MdiParent, MainForm))
         '    Color:
         optionsDialog.foregroundColor = mainForm._foreColor
         optionsDialog.backgroundColor = mainForm._backColor

         '    Mrc:
         optionsDialog.tempPictureCoder = mainForm._pictureCoder
         optionsDialog.tempGrayscaleCoder8Bit = mainForm._grayscaleCoder8Bit
         optionsDialog.tempTextCoder2Bit = mainForm._textCoder2Bit
         optionsDialog.tempGrayscaleCoder2Bit = mainForm._grayscaleCoder2Bit
         optionsDialog.tempMaskCode = mainForm._maskCoder
         optionsDialog.tempQFactor = mainForm._qFactor
         optionsDialog.tempGSQFactor = mainForm._gSQFactor

         '    PDF:
         optionsDialog.tempPDFPictureCoder = mainForm._pDFPictureCoder
         optionsDialog.tempPDFTextCoder2Bit = mainForm._pDFTextCoder2Bit
         optionsDialog.tempPDFMaskCoder = mainForm._pDFMaskCoder
         optionsDialog.tempPDFQFactor = mainForm._pDFQFactor

         '    Segmentation:
         optionsDialog.tempInputImageType = mainForm._inputImageType
         optionsDialog.tempOutputImageType = mainForm._outputImageType

         optionsDialog.tempBGThreshold = mainForm._bGThreshold
         optionsDialog.tempCleanSize = mainForm._cleanSize
         optionsDialog.tempCombineThreshold = mainForm._combineThreshold
         optionsDialog.tempQuality = mainForm._quality
         optionsDialog.tempClrThreshold = mainForm._clrThreshold
         optionsDialog.tempTypeIndex = mainForm._typeIndex
         optionsDialog.tempCheck = mainForm._check

         optionsDialog.tempUserDefineBGThreshold = mainForm._userDefineBGThreshold
         optionsDialog.tempUserDefineCleanSize = mainForm._userDefineCleanSize
         optionsDialog.tempUserDefineCombineThreshold = mainForm._userDefineCombineThreshold
         optionsDialog.tempUserDefineQuality = mainForm._userDefineQuality
         optionsDialog.tempUserDefineClrThreshold = mainForm._userDefineclrThreshold
         optionsDialog.tempUserDefineTypeIndex = mainForm._userDefineTypeIndex
         optionsDialog.tempUserDefineCheck = mainForm._userDefineCheck

         '    Combine:
         optionsDialog.tempCombineFactor = mainForm._combineFactor
         optionsDialog.tempCombineType = mainForm._combineType
      End Sub

      Public Sub SetValuesToVariables(ByVal optionsDialog As Options)
         Dim mainForm As MainForm = (CType(MdiParent, MainForm))
         '    Color:
         mainForm._foreColor = optionsDialog.foregroundColor
         mainForm._backColor = optionsDialog.backgroundColor

         '    Mrc:
         mainForm._pictureCoder = optionsDialog.tempPictureCoder
         mainForm._grayscaleCoder8Bit = optionsDialog.tempGrayscaleCoder8Bit
         mainForm._textCoder2Bit = optionsDialog.tempTextCoder2Bit
         mainForm._grayscaleCoder2Bit = optionsDialog.tempGrayscaleCoder2Bit
         mainForm._maskCoder = optionsDialog.tempMaskCode
         mainForm._qFactor = optionsDialog.tempQFactor
         mainForm._gSQFactor = optionsDialog.tempGSQFactor

         '    PDF:
         mainForm._pDFPictureCoder = optionsDialog.tempPDFPictureCoder
         mainForm._pDFTextCoder2Bit = optionsDialog.tempPDFTextCoder2Bit
         mainForm._pDFMaskCoder = optionsDialog.tempPDFMaskCoder
         mainForm._pDFQFactor = optionsDialog.tempPDFQFactor

         '    Segmentation
         mainForm._inputImageType = optionsDialog.tempInputImageType
         mainForm._outputImageType = optionsDialog.tempOutputImageType

         mainForm._bGThreshold = optionsDialog.tempBGThreshold
         mainForm._cleanSize = optionsDialog.tempCleanSize
         mainForm._combineThreshold = optionsDialog.tempCombineThreshold
         mainForm._quality = optionsDialog.tempQuality
         mainForm._clrThreshold = optionsDialog.tempClrThreshold
         mainForm._typeIndex = optionsDialog.tempTypeIndex
         mainForm._check = optionsDialog.tempCheck

         mainForm._userDefineBGThreshold = optionsDialog.tempUserDefineBGThreshold
         mainForm._userDefineCleanSize = optionsDialog.tempUserDefineCleanSize
         mainForm._userDefineCombineThreshold = optionsDialog.tempUserDefineCombineThreshold
         mainForm._userDefineQuality = optionsDialog.tempUserDefineQuality
         mainForm._userDefineclrThreshold = optionsDialog.tempUserDefineClrThreshold
         mainForm._userDefineTypeIndex = optionsDialog.tempUserDefineTypeIndex
         mainForm._userDefineCheck = optionsDialog.tempUserDefineCheck

         '    Combine:
         mainForm._combineFactor = optionsDialog.tempCombineFactor
         mainForm._combineType = optionsDialog.tempCombineType

      End Sub

      Private Function MrcEnumerateSegmentInfoCallback(ByVal segmentHandle As MrcSegmenter, ByVal data As MrcSegmentData, ByVal id As Integer) As Boolean
         AddToSegment(data)
         Return True
      End Function

      Private Sub RefreshSegments()
         _index = 1
         _segmentsData = New MrcSegmentData(_index - 1) {}
         _selectionArray = New Boolean(_index - 1) {}

         _mrcSegmenter.EnumerateSegments(_callback)

         If _index > 1 Then
            _selectedSegment = 0
         Else
            _selectedSegment = -2
         End If
         _selectedCombineSegment = -1
         _multiSelection = False

         If _mrcSegmenter.EnumerateSegments(Nothing) = 0 Then
            _mrcStart = False
         End If

         SetSelectionRectangles(_selectedSegment)
         CType(MdiParent, MainForm).UpdateControls()
         _viewer.Invalidate(True)
      End Sub

      Private Function GetSegmentImageFlags(ByVal index As Integer, ByVal searchBackground As Boolean) As MrcSegmentImageFlags
         Select Case index
            Case 0
               If (searchBackground) Then
                  Return (MrcSegmentImageFlags.FavorOneBit Or (MrcSegmentImageFlags.SegmentWithBackground))
               Else
                  Return (MrcSegmentImageFlags.FavorOneBit Or (MrcSegmentImageFlags.SegmentWithOutBackground))
               End If
            Case 1
               If (searchBackground) Then
                  Return (MrcSegmentImageFlags.FavorTwoBit Or (MrcSegmentImageFlags.SegmentWithBackground))
               Else
                  Return (MrcSegmentImageFlags.FavorTwoBit Or (MrcSegmentImageFlags.SegmentWithOutBackground))
               End If
            Case 2
               If (searchBackground) Then
                  Return (MrcSegmentImageFlags.ForceOneBit Or (MrcSegmentImageFlags.SegmentWithBackground))
               Else
                  Return (MrcSegmentImageFlags.ForceOneBit Or (MrcSegmentImageFlags.SegmentWithOutBackground))
               End If
            Case Else
               If (searchBackground) Then
                  Return (MrcSegmentImageFlags.ForceTwoBit Or (MrcSegmentImageFlags.SegmentWithBackground))
               Else
                  Return (MrcSegmentImageFlags.ForceTwoBit Or (MrcSegmentImageFlags.SegmentWithOutBackground))
               End If
         End Select
      End Function
      Public Sub StartAutoMrcSegmentation(ByVal preserveManual As Boolean)
         Dim mainForm As MainForm = (CType(MdiParent, MainForm))

         Dim segmentImageOptions As MrcSegmentImageOptions = New MrcSegmentImageOptions()

         If mainForm._inputImageType = 6 Then
            segmentImageOptions.BackgroundThreshold = mainForm._userDefineBGThreshold
            segmentImageOptions.CleanSize = mainForm._userDefineCleanSize
            segmentImageOptions.ColorThreshold = mainForm._userDefineclrThreshold
         Else
            segmentImageOptions.BackgroundThreshold = mainForm._bGThreshold
            segmentImageOptions.CleanSize = mainForm._cleanSize
            segmentImageOptions.ColorThreshold = mainForm._clrThreshold
         End If

         If mainForm._outputImageType = 5 Then
            segmentImageOptions.CombineThreshold = mainForm._userDefineCombineThreshold
            segmentImageOptions.Flags = GetSegmentImageFlags(mainForm._userDefineTypeIndex, mainForm._userDefineCheck) Or MrcSegmentImageFlags.NormalSegmentation
            segmentImageOptions.SegmentQuality = mainForm._userDefineQuality
         Else
            segmentImageOptions.CombineThreshold = mainForm._combineThreshold
            segmentImageOptions.Flags = GetSegmentImageFlags(mainForm._typeIndex, mainForm._check) Or MrcSegmentImageFlags.NormalSegmentation
            segmentImageOptions.SegmentQuality = mainForm._quality
         End If

         If (Not preserveManual) Then
            ClearSegments()
         End If

         Try
            _mrcSegmenter.SegmentImage(_viewer.Image, segmentImageOptions)
         Catch ex As Exception
            MrcError("An error occurred while trying to segment the image.", ex)
         End Try

         _mrcStart = True

         RefreshSegments()

         SetSelectionRectangles(_selectedSegment)

         _resizeSegment = False
         _optionsChanged = False
         CType(MdiParent, MainForm).UpdateControls()
      End Sub

      Private Sub GetSelectionRectangles(ByVal index As Integer)
         Dim x1, y1 As Integer

         x1 = _segmentsData(index).ImageSegment.Left - 2
         y1 = _segmentsData(index).ImageSegment.Top - 2
         _selectionRectangle(0) = New Rectangle(x1, y1, 5, 5)

         x1 = CInt(_segmentsData(index).ImageSegment.Left + _segmentsData(index).ImageSegment.Width / 2)
         y1 = _segmentsData(index).ImageSegment.Top - 2
         _selectionRectangle(1) = New Rectangle(x1, y1, 5, 5)

         x1 = _segmentsData(index).ImageSegment.Right - 2
         y1 = _segmentsData(index).ImageSegment.Top - 2
         _selectionRectangle(2) = New Rectangle(x1, y1, 5, 5)

         x1 = _segmentsData(index).ImageSegment.Left - 2
         y1 = CInt(_segmentsData(index).ImageSegment.Top + _segmentsData(index).ImageSegment.Height / 2)
         _selectionRectangle(3) = New Rectangle(x1, y1, 5, 5)

         x1 = _segmentsData(index).ImageSegment.Right - 2
         y1 = CInt(_segmentsData(index).ImageSegment.Top + _segmentsData(index).ImageSegment.Height / 2)
         _selectionRectangle(4) = New Rectangle(x1, y1, 5, 5)

         x1 = _segmentsData(index).ImageSegment.Left - 2
         y1 = _segmentsData(index).ImageSegment.Bottom - 2
         _selectionRectangle(5) = New Rectangle(x1, y1, 5, 5)

         x1 = CInt(_segmentsData(index).ImageSegment.Left + _segmentsData(index).ImageSegment.Width / 2)
         y1 = _segmentsData(index).ImageSegment.Bottom - 2
         _selectionRectangle(6) = New Rectangle(x1, y1, 5, 5)

         x1 = _segmentsData(index).ImageSegment.Right - 2
         y1 = _segmentsData(index).ImageSegment.Bottom - 2
         _selectionRectangle(7) = New Rectangle(x1, y1, 5, 5)
      End Sub

      Private Sub SetSelectionRectangles(ByVal index As Integer)
         Dim x1 As Integer
         Dim y1 As Integer

         If _mrcStart Then
            If _selectedCombineSegment <> -1 Then
               x1 = _segmentsData(_selectedCombineSegment).ImageSegment.Left - 2
               y1 = _segmentsData(_selectedCombineSegment).ImageSegment.Top - 2
               _selectionCombineRectangle(0) = New Rectangle(x1, y1, 5, 5)

               x1 = CInt(_segmentsData(_selectedCombineSegment).ImageSegment.Left + _segmentsData(_selectedCombineSegment).ImageSegment.Width / 2)
               y1 = _segmentsData(_selectedCombineSegment).ImageSegment.Top - 2
               _selectionCombineRectangle(1) = New Rectangle(x1, y1, 5, 5)

               x1 = _segmentsData(_selectedCombineSegment).ImageSegment.Right - 2
               y1 = _segmentsData(_selectedCombineSegment).ImageSegment.Top - 2
               _selectionRectangle(2) = New Rectangle(x1, y1, 5, 5)

               x1 = _segmentsData(_selectedCombineSegment).ImageSegment.Left - 2
               y1 = CInt(_segmentsData(_selectedCombineSegment).ImageSegment.Top + _segmentsData(_selectedCombineSegment).ImageSegment.Height / 2)
               _selectionCombineRectangle(3) = New Rectangle(x1, y1, 5, 5)

               x1 = _segmentsData(_selectedCombineSegment).ImageSegment.Right - 2
               y1 = CInt(_segmentsData(_selectedCombineSegment).ImageSegment.Top + _segmentsData(_selectedCombineSegment).ImageSegment.Height / 2)
               _selectionCombineRectangle(4) = New Rectangle(x1, y1, 5, 5)

               x1 = _segmentsData(_selectedCombineSegment).ImageSegment.Left - 2
               y1 = _segmentsData(_selectedCombineSegment).ImageSegment.Bottom - 2
               _selectionCombineRectangle(5) = New Rectangle(x1, y1, 5, 5)

               x1 = CInt(_segmentsData(_selectedCombineSegment).ImageSegment.Left + _segmentsData(_selectedCombineSegment).ImageSegment.Width / 2)
               y1 = _segmentsData(_selectedCombineSegment).ImageSegment.Bottom - 2
               _selectionCombineRectangle(6) = New Rectangle(x1, y1, 5, 5)

               x1 = _segmentsData(_selectedCombineSegment).ImageSegment.Right - 2
               y1 = _segmentsData(_selectedCombineSegment).ImageSegment.Bottom - 2
               _selectionCombineRectangle(7) = New Rectangle(x1, y1, 5, 5)
            End If

            If _selectedSegment <> -1 AndAlso _selectedSegment <> -2 Then
               x1 = _segmentsData(_selectedSegment).ImageSegment.Left - 2
               y1 = _segmentsData(_selectedSegment).ImageSegment.Top - 2
               _selectionRectangle(0) = New Rectangle(x1, y1, 5, 5)

               x1 = CInt(_segmentsData(_selectedSegment).ImageSegment.Left + _segmentsData(_selectedSegment).ImageSegment.Width / 2)
               y1 = _segmentsData(_selectedSegment).ImageSegment.Top - 2
               _selectionRectangle(1) = New Rectangle(x1, y1, 5, 5)

               x1 = _segmentsData(_selectedSegment).ImageSegment.Right - 2
               y1 = _segmentsData(_selectedSegment).ImageSegment.Top - 2
               _selectionRectangle(2) = New Rectangle(x1, y1, 5, 5)

               x1 = _segmentsData(_selectedSegment).ImageSegment.Left - 2
               y1 = CInt(_segmentsData(_selectedSegment).ImageSegment.Top + _segmentsData(_selectedSegment).ImageSegment.Height / 2)
               _selectionRectangle(3) = New Rectangle(x1, y1, 5, 5)

               x1 = _segmentsData(_selectedSegment).ImageSegment.Right - 2
               y1 = CInt(_segmentsData(_selectedSegment).ImageSegment.Top + _segmentsData(_selectedSegment).ImageSegment.Height / 2)
               _selectionRectangle(4) = New Rectangle(x1, y1, 5, 5)

               x1 = _segmentsData(_selectedSegment).ImageSegment.Left - 2
               y1 = _segmentsData(_selectedSegment).ImageSegment.Bottom - 2
               _selectionRectangle(5) = New Rectangle(x1, y1, 5, 5)

               x1 = CInt(_segmentsData(_selectedSegment).ImageSegment.Left + _segmentsData(_selectedSegment).ImageSegment.Width / 2)
               y1 = _segmentsData(_selectedSegment).ImageSegment.Bottom - 2
               _selectionRectangle(6) = New Rectangle(x1, y1, 5, 5)

               x1 = _segmentsData(_selectedSegment).ImageSegment.Right - 2
               y1 = _segmentsData(_selectedSegment).ImageSegment.Bottom - 2
               _selectionRectangle(7) = New Rectangle(x1, y1, 5, 5)
            End If
         End If
      End Sub

      Private Sub AddToSegment(ByVal mrcData As MrcSegmentData)
         Dim tempMrcData As MrcSegmentData() = New MrcSegmentData(_index - 2) {}
         Dim tempSelection As Boolean() = New Boolean(_index - 2) {}

         tempMrcData = _segmentsData
         tempSelection = _selectionArray

         _segmentsData = New MrcSegmentData(_index - 1) {}
         _selectionArray = New Boolean(_index - 1) {}

         Array.Copy(tempMrcData, _segmentsData, (_index - 1))
         Array.Copy(tempSelection, _selectionArray, (_index - 1))

         _segmentsData(_index - 1) = mrcData
         _selectionArray(_index - 1) = False
         _index += 1
      End Sub

      Public Sub SetSelectionArray(ByVal value As Boolean)
         Dim index As Integer = 0
         Do While index < _index - 1
            _selectionArray(index) = value
            index += 1
         Loop
      End Sub

      Private Sub _viewer_mouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
         If e.Button = MouseButtons.Left Then
            If e.X < _viewer.ClientRectangle.Width AndAlso e.Y < _viewer.ClientRectangle.Height Then
               If _addSegment Then
                  _drawNewSegment = True
                  _drawRectangle = New Rectangle(e.X, e.Y, 0, 0)
               ElseIf Me.Cursor Is Cursors.SizeNWSE OrElse Me.Cursor Is Cursors.SizeNS OrElse Me.Cursor Is Cursors.SizeNESW OrElse Me.Cursor Is Cursors.SizeWE Then
                  _resizeSegment = True
                  _preResize = Leadtools.Demos.Converters.ConvertRect(_segmentsData(_selectedSegment).ImageSegment)
                  CType(MdiParent, MainForm).CancelDrawing()
               ElseIf Me.Cursor Is Cursors.SizeAll Then
                  _moveSegment = True
                  _movePoint = New Point(e.X, e.Y)
                  CType(MdiParent, MainForm).CancelDrawing()
               End If
            End If
         End If
      End Sub

      Private Sub _viewer_mouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
         If _drawNewSegment AndAlso e.Button = MouseButtons.Left Then
            Dim segmentTypeDlg As SegmentTypeDialog = New SegmentTypeDialog()

            _drawRectangle = DemosGlobal.FixRectangle(_drawRectangle)

            _drawNewSegment = False
            If (Not _drawRectangle.IsEmpty) AndAlso segmentTypeDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
               AddToUndoList()
               Dim mrcSegmentData As MrcSegmentData = New MrcSegmentData()

               _drawRectangle.Width = Math.Max(15, _drawRectangle.Width)
               _drawRectangle.Height = Math.Max(15, _drawRectangle.Height)

               Dim t As Transformer = New Transformer(Tools.ToMatrix(_viewer.ImageTransform))

               mrcSegmentData.ImageSegment = Leadtools.Demos.Converters.ConvertRect(Rectangle.Round(t.RectangleToLogical(_drawRectangle)))
               mrcSegmentData.SegmentType = segmentTypeDlg.SegmentType

               If (Not _mrcStart) Then
                  Dim mainForm As MainForm = (CType(MdiParent, MainForm))
                  _mrcSegmenter = New MrcSegmenter(_viewer.Image, Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._backColor), Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._foreColor))

                  _mrcStart = True
               End If

               mrcSegmentData.ImageSegment = New LeadRect(mrcSegmentData.ImageSegment.X, mrcSegmentData.ImageSegment.Y, (Math.Min(_viewer.Image.Width, mrcSegmentData.ImageSegment.Right) - mrcSegmentData.ImageSegment.Left), (Math.Min(_viewer.Image.Height, mrcSegmentData.ImageSegment.Bottom) - mrcSegmentData.ImageSegment.Top))

               If mrcSegmentData.ImageSegment.Width < 10 OrElse mrcSegmentData.ImageSegment.Height < 10 Then
                  Return
               End If

               Dim index As Integer = _mrcSegmenter.AddSegment(_viewer.Image, mrcSegmentData)
               AddToSegment(mrcSegmentData)
               SetSelectionRectangles(index)
               If (Not _mrcStart) Then
                  _mrcStart = True
               End If

               CType(MdiParent, MainForm).PreserveManualMenuItem.Enabled = True

               _selectedSegment = index
            End If
            _viewer.Invalidate(True)
         ElseIf _resizeSegment Then
            AddToUndoList()
            _segmentsData(_selectedSegment).ImageSegment = New LeadRect(_segmentsData(_selectedSegment).ImageSegment.X, _segmentsData(_selectedSegment).ImageSegment.Y, (Math.Min(_viewer.Image.Width, _segmentsData(_selectedSegment).ImageSegment.Right) - _segmentsData(_selectedSegment).ImageSegment.Left), (Math.Min(_viewer.Image.Height, _segmentsData(_selectedSegment).ImageSegment.Bottom) - _segmentsData(_selectedSegment).ImageSegment.Top))
            _mrcSegmenter.SetSegmentData(_viewer.Image, _selectedSegment, _segmentsData(_selectedSegment))
            RefreshSegments()
            _resizeSegment = False
         ElseIf _moveSegment AndAlso _selectedSegment <> -2 Then
            Try
               AddToUndoList()
               _mrcSegmenter.SetSegmentData(_viewer.Image, _selectedSegment, _segmentsData(_selectedSegment))
               RefreshSegments()
            Catch ex As Exception
               MrcError("Could not update segment.", ex)
            End Try
         End If

         If _index > 1 AndAlso e.Button = MouseButtons.Left Then
            Dim done As Boolean = False
            Dim index As Integer = 0
            Do
               Dim t As Transformer = New Transformer(Tools.ToMatrix(_viewer.ImageTransform))
               Dim rc As Rectangle = Rectangle.Round(t.RectangleToPhysical(Leadtools.Demos.Converters.ConvertRect(_segmentsData(index).ImageSegment)))
               If rc.Contains(e.X, e.Y) Then
                  If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                     If _selectedCombineSegment = -1 Then
                        _selectedCombineSegment = index
                        _selectionArray(_selectedCombineSegment) = True
                        _cmenuCombineSegments.Enabled = True
                        SetSelectionRectangles(_selectedCombineSegment)
                     Else
                        _selectionArray(index) = Not _selectionArray(index)
                        _multiSelection = True
                     End If
                  Else
                     _selectedSegment = index
                     _selectedCombineSegment = -1
                     _multiSelection = False
                     SetSelectionArray(False)
                  End If
                  SetSelectionRectangles(_selectedSegment)
                  done = True
               End If

               index += 1
            Loop While index < _segmentsData.Length AndAlso Not done

            _viewer.Invalidate(True)
         End If
         _moveSegment = False
         _resizeSegment = False
         CType(MdiParent, MainForm).UpdateControls()
      End Sub

      Private Sub _viewer_mouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
         If _multiSelection Then
            Return
         End If

         If _addSegment AndAlso _drawNewSegment Then
            Dim maxMinX As Integer = Math.Max(0, Math.Min(e.X, _viewer.ClientRectangle.Width))
            Dim maxMinY As Integer = Math.Max(0, Math.Min(e.Y, _viewer.ClientRectangle.Height))
            _drawRectangle = Rectangle.FromLTRB(_drawRectangle.Left, _drawRectangle.Top, maxMinX, maxMinY)
            _viewer.Invalidate(True)
         ElseIf (Not _resizeSegment) AndAlso _selectedSegment <> -1 AndAlso _selectedSegment <> -2 Then
            If _addSegment Then
               Me.Cursor = Cursors.Cross
            Else
               Dim t As Transformer = New Transformer(Tools.ToMatrix(_viewer.ImageTransform))
               Dim pt As Point = Point.Round(t.PointToLogical(New Point(e.X, e.Y)))

               Dim index As Integer = 0
               Dim done As Boolean = False
               Do
                  If _selectionRectangle(index).Contains(pt) Then
                     done = True
                  Else
                     index += 1
                  End If
               Loop While index < 8 AndAlso Not done

               If index <> 8 Then
                  _resizeIndex = index
               End If

               If index = 8 AndAlso _mrcStart AndAlso _segmentsData(_selectedSegment).ImageSegment.Contains(Leadtools.Demos.Converters.ConvertPoint(pt)) Then
                  index = -1
               End If

               Select Case index
                  Case 0, 7
                     Me.Cursor = Cursors.SizeNWSE
                  Case 1, 6
                     Me.Cursor = Cursors.SizeNS
                  Case 2, 5
                     Me.Cursor = Cursors.SizeNESW
                  Case 3, 4
                     Me.Cursor = Cursors.SizeWE
                  Case -1
                     Me.Cursor = Cursors.SizeAll
                  Case Else
                     Me.Cursor = Cursors.Default
               End Select
            End If
         End If

         If _moveSegment AndAlso _selectedSegment <> -2 Then
            Dim t As Transformer = New Transformer(Tools.ToMatrix(_viewer.ImageTransform))
            Dim pt1 As Point = Point.Round(t.PointToLogical(_movePoint))
            _movePoint = New Point(e.X, e.Y)
            Dim pt2 As Point = Point.Round(t.PointToLogical(_movePoint))

            Dim xDifference As Integer = pt2.X - pt1.X
            Dim yDifference As Integer = pt2.Y - pt1.Y
            Dim x As Integer = _segmentsData(_selectedSegment).ImageSegment.X
            Dim y As Integer = _segmentsData(_selectedSegment).ImageSegment.Y
            Dim width As Integer = _segmentsData(_selectedSegment).ImageSegment.Width
            Dim height As Integer = _segmentsData(_selectedSegment).ImageSegment.Height

            Dim rc As LeadRect = _segmentsData(_selectedSegment).ImageSegment
            'rc.Offset(xDifference, yDifference);
            rc = New LeadRect(rc.Left + xDifference, rc.Top + yDifference, rc.Width, rc.Height)
            Dim imageRect As LeadRect = New LeadRect(0, 0, _viewer.Image.ImageWidth, _viewer.Image.ImageHeight)

            If imageRect.Contains(rc) Then
               _segmentsData(_selectedSegment).ImageSegment = rc
            End If

            _viewer.Invalidate(True)
         End If

         If _resizeSegment Then
            Dim t As Transformer = New Transformer(Tools.ToMatrix(_viewer.ImageTransform))
            Dim maxMinX As Integer = Math.Max(0, Math.Min(e.X, _viewer.ClientRectangle.Width))
            Dim maxMinY As Integer = Math.Max(0, Math.Min(e.Y, _viewer.ClientRectangle.Height))
            Dim pt As Point = Point.Round(t.PointToLogical(New Point(maxMinX, maxMinY)))

            Dim x As Integer = _segmentsData(_selectedSegment).ImageSegment.X
            Dim y As Integer = _segmentsData(_selectedSegment).ImageSegment.Y
            Dim width As Integer = _segmentsData(_selectedSegment).ImageSegment.Width
            Dim height As Integer = _segmentsData(_selectedSegment).ImageSegment.Height
            Dim right As Integer = _segmentsData(_selectedSegment).ImageSegment.Right
            Dim bottom As Integer = _segmentsData(_selectedSegment).ImageSegment.Bottom

            Select Case _resizeIndex
               Case 0
                  If pt.X < x Then
                     width += Math.Abs(x - pt.X)
                     x = pt.X
                  Else
                     width -= Math.Abs(x - pt.X)
                     x = pt.X
                  End If
                  If pt.Y < y Then
                     height += Math.Abs(y - pt.Y)
                     y = pt.Y
                  Else
                     height -= Math.Abs(y - pt.Y)
                     y = pt.Y
                  End If

               Case 1
                  If pt.Y < y Then
                     height += Math.Abs(y - pt.Y)
                     y = pt.Y
                  Else
                     height -= Math.Abs(y - pt.Y)
                     y = pt.Y
                  End If

               Case 2
                  If pt.X < right Then
                     width -= Math.Abs(right - pt.X)
                  Else
                     width += Math.Abs(right - pt.X)
                  End If
                  If pt.Y < y Then
                     height += Math.Abs(y - pt.Y)
                     y = pt.Y
                  Else
                     height -= Math.Abs(y - pt.Y)
                     y = pt.Y
                  End If

               Case 3
                  If pt.X < x Then
                     width += Math.Abs(x - pt.X)
                     x = pt.X
                  Else
                     width -= Math.Abs(x - pt.X)
                     x = pt.X
                  End If

               Case 4
                  If pt.X < right Then
                     width -= Math.Abs(right - pt.X)
                  Else
                     width += Math.Abs(right - pt.X)
                  End If

               Case 5
                  If pt.X < x Then
                     width += Math.Abs(x - pt.X)
                     x = pt.X
                  Else
                     width -= Math.Abs(x - pt.X)
                     x = pt.X
                  End If
                  If pt.Y < bottom Then
                     height -= Math.Abs(bottom - pt.Y)
                  Else
                     height += Math.Abs(bottom - pt.Y)
                  End If

               Case 6
                  If pt.Y < bottom Then
                     height -= Math.Abs(bottom - pt.Y)
                  Else
                     height += Math.Abs(bottom - pt.Y)
                  End If

               Case 7
                  If pt.X < right Then
                     width -= Math.Abs(right - pt.X)
                  Else
                     width += Math.Abs(right - pt.X)
                  End If
                  If pt.Y < bottom Then
                     height -= Math.Abs(bottom - pt.Y)
                  Else
                     height += Math.Abs(bottom - pt.Y)
                  End If
            End Select

            If width >= 10 AndAlso height >= 10 Then
               _segmentsData(_selectedSegment).ImageSegment = New LeadRect(x, y, width, height)
            End If

            _viewer.Invalidate(True)
         End If

         SetSelectionRectangles(_selectedSegment)
      End Sub

      Private Function GetCombineFlags(ByVal index As Integer) As MrcCombineSegmentFlags
         Select Case index
            Case 0
               Return MrcCombineSegmentFlags.CombineForce
            Case 1
               Return MrcCombineSegmentFlags.ForeSimilar
            Case Else
               Return MrcCombineSegmentFlags.TryFactor
         End Select
      End Function

      Public Sub CombineSegments()
         Try
            Dim mainForm As MainForm = (CType(MdiParent, MainForm))

            _mrcSegmenter.CombineSegments(_selectedSegment, _selectedCombineSegment, GetCombineFlags(mainForm._combineType), mainForm._combineFactor)

            _selectedCombineSegment = -1
            RefreshSegments()
         Catch ex As Exception
            MrcError(String.Format("Error combining segments; the segments are of different types or not adjacent.{0}If you want to force combining segments of different types go to Preferences -> 'Segmentation and Compression Options. and change the combining type to (Force)", Environment.NewLine), ex)
         End Try
         _selectedCombineSegment = -1
      End Sub

      Private Sub _cmenuCombineSegments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmenuCombineSegments.Click
         AddToUndoList()
         CombineSegments()
      End Sub

      Public Sub DeleteSelectedSegment()
         If _index > 1 AndAlso _selectedSegment <> -2 Then
            Try
               Dim index As Integer = 0
               Do While index < _index - 1
                  If _selectionArray(index) Then
                     _mrcSegmenter.DeleteSegment(index)
                  End If
                  index += 1
               Loop
               RefreshSegments()
            Catch ex As Exception
               MrcError("Error deleting segment.", ex)
            End Try
         End If
      End Sub

      Public Sub SelectAllSegments()
         _selectedSegment = -1
         _selectedCombineSegment = -1
      End Sub

      Public Sub ClearSegments()
         Dim mainForm As MainForm = (CType(MdiParent, MainForm))

         _selectedCombineSegment = -1
         _selectedSegment = -2
         _index = 1

         _mrcStart = False
         _cmenuCombineSegments.Enabled = False

         _segmentsData = New MrcSegmentData(_index - 1) {}
         _selectionArray = New Boolean(_index - 1) {}

         If Not _mrcSegmenter Is Nothing Then
            _mrcSegmenter.Dispose()
         End If

         Try
            _mrcSegmenter = New MrcSegmenter(_viewer.Image, Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._backColor), Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._foreColor))

         Catch ex As Exception
            MrcError("An error occurred while trying to initialize the segmentation process.", ex)
         Finally
            _viewer.Invalidate(True)
            CType(MdiParent, MainForm).UpdateControls()
         End Try
      End Sub

      Private Function CanEnlargeFromLeft(ByVal leftRectangle As Rectangle, ByVal selectedRectangle As Rectangle) As Boolean
         If (leftRectangle.Top <= selectedRectangle.Top) AndAlso (leftRectangle.Bottom > selectedRectangle.Top) AndAlso (leftRectangle.Bottom < selectedRectangle.Bottom) AndAlso (leftRectangle.Right <= selectedRectangle.Left) Then
            Return True

         ElseIf (leftRectangle.Top >= selectedRectangle.Top) AndAlso (leftRectangle.Top < selectedRectangle.Bottom) AndAlso (leftRectangle.Bottom > selectedRectangle.Top) AndAlso (leftRectangle.Bottom <= selectedRectangle.Bottom) AndAlso (leftRectangle.Right <= selectedRectangle.Left) Then
            Return True

         ElseIf (leftRectangle.Top > selectedRectangle.Top) AndAlso (leftRectangle.Top < selectedRectangle.Bottom) AndAlso (leftRectangle.Bottom >= selectedRectangle.Bottom) AndAlso (leftRectangle.Right <= selectedRectangle.Left) Then

            Return True
         ElseIf (leftRectangle.Top <= selectedRectangle.Top) AndAlso (leftRectangle.Bottom >= selectedRectangle.Bottom) AndAlso (leftRectangle.Right <= selectedRectangle.Left) Then
            Return True
         Else
            Return False
         End If
      End Function

      Private Function CanEnlargeFromTop(ByVal topRectangle As Rectangle, ByVal selectedRectangle As Rectangle) As Boolean
         If (topRectangle.Left <= selectedRectangle.Left) AndAlso (topRectangle.Right > selectedRectangle.Left) AndAlso (topRectangle.Right < selectedRectangle.Right) AndAlso (topRectangle.Bottom <= selectedRectangle.Top) Then

            Return True
         ElseIf (topRectangle.Left >= selectedRectangle.Left) AndAlso (topRectangle.Left < selectedRectangle.Right) AndAlso (topRectangle.Right > selectedRectangle.Left) AndAlso (topRectangle.Right <= selectedRectangle.Right) AndAlso (topRectangle.Bottom <= selectedRectangle.Top) Then

            Return True

         ElseIf (topRectangle.Left > selectedRectangle.Left) AndAlso (topRectangle.Left < selectedRectangle.Right) AndAlso (topRectangle.Right >= selectedRectangle.Right) AndAlso (topRectangle.Bottom < selectedRectangle.Top) Then
            Return True
         ElseIf (topRectangle.Left <= selectedRectangle.Left) AndAlso (topRectangle.Right >= selectedRectangle.Right) AndAlso (topRectangle.Bottom <= selectedRectangle.Top) Then

            Return True
         Else
            Return False
         End If
      End Function

      Private Function CanEnlargeFromRight(ByVal rightRectangle As Rectangle, ByVal selectedRectangle As Rectangle) As Boolean
         If (rightRectangle.Top <= selectedRectangle.Top) AndAlso (rightRectangle.Bottom > selectedRectangle.Top) AndAlso (rightRectangle.Bottom < selectedRectangle.Bottom) AndAlso (rightRectangle.Left >= selectedRectangle.Right) Then
            Return True
         ElseIf (rightRectangle.Top >= selectedRectangle.Top) AndAlso (rightRectangle.Top < selectedRectangle.Bottom) AndAlso (rightRectangle.Bottom > selectedRectangle.Top) AndAlso (rightRectangle.Bottom <= selectedRectangle.Bottom) AndAlso (rightRectangle.Left >= selectedRectangle.Right) Then

            Return True
         ElseIf (rightRectangle.Top > selectedRectangle.Top) AndAlso (rightRectangle.Top < selectedRectangle.Bottom) AndAlso (rightRectangle.Bottom >= selectedRectangle.Bottom) AndAlso (rightRectangle.Left >= selectedRectangle.Right) Then

            Return True
         ElseIf (rightRectangle.Top <= selectedRectangle.Top) AndAlso (rightRectangle.Bottom >= selectedRectangle.Bottom) AndAlso (rightRectangle.Left >= selectedRectangle.Right) Then
            Return True
         Else
            Return False
         End If
      End Function

      Private Function CanEnlargeFromBottom(ByVal bottomRectangle As Rectangle, ByVal selectedRectangle As Rectangle) As Boolean
         If (bottomRectangle.Left <= selectedRectangle.Left) AndAlso (bottomRectangle.Right > selectedRectangle.Left) AndAlso (bottomRectangle.Right < selectedRectangle.Right) AndAlso (bottomRectangle.Top >= selectedRectangle.Bottom) Then
            Return True
         ElseIf (bottomRectangle.Left >= selectedRectangle.Left) AndAlso (bottomRectangle.Left < selectedRectangle.Right) AndAlso (bottomRectangle.Right > selectedRectangle.Left) AndAlso (bottomRectangle.Right <= selectedRectangle.Right) AndAlso (bottomRectangle.Top >= selectedRectangle.Bottom) Then
            Return True
         ElseIf (bottomRectangle.Left > selectedRectangle.Left) AndAlso (bottomRectangle.Left < selectedRectangle.Right) AndAlso (bottomRectangle.Right >= selectedRectangle.Right) AndAlso (bottomRectangle.Top >= selectedRectangle.Bottom) Then
            Return True
         ElseIf (bottomRectangle.Left <= selectedRectangle.Left) AndAlso (bottomRectangle.Right >= selectedRectangle.Right) AndAlso (bottomRectangle.Top >= selectedRectangle.Bottom) Then
            Return True
         Else
            Return False
         End If
      End Function

      Public Sub EnlargeSegment()
         Dim index, left, right, top, bottom As Integer
         Dim selectedRectangle, tempRectangle As Rectangle

         left = 0
         right = _viewer.Image.Width
         top = 0
         bottom = _viewer.Image.Height

         selectedRectangle = Leadtools.Demos.Converters.ConvertRect(_segmentsData(_selectedSegment).ImageSegment)

         index = 0
         Do While index < _segmentsData.Length
            If index = _selectedSegment Then
               Continue Do
            End If

            tempRectangle = Leadtools.Demos.Converters.ConvertRect(_segmentsData(index).ImageSegment)

            ' Find the left value
            If CanEnlargeFromLeft(tempRectangle, selectedRectangle) Then
               left = Math.Max(left, tempRectangle.Right)
            End If
            index += 1
         Loop

         index = 0
         Do While index < _segmentsData.Length
            If index = _selectedSegment Then
               Continue Do
            End If

            tempRectangle = Leadtools.Demos.Converters.ConvertRect(_segmentsData(index).ImageSegment)

            ' Find the left value
            If CanEnlargeFromTop(tempRectangle, selectedRectangle) Then
               top = Math.Max(top, tempRectangle.Bottom)
            End If
            index += 1
         Loop

         index = 0
         Do While index < _segmentsData.Length
            If index = _selectedSegment Then
               Continue Do
            End If

            tempRectangle = Leadtools.Demos.Converters.ConvertRect(_segmentsData(index).ImageSegment)

            ' Find the left value
            If CanEnlargeFromRight(tempRectangle, selectedRectangle) Then
               right = Math.Min(right, tempRectangle.Left)
            End If
            index += 1
         Loop

         index = 0
         Do While index < _segmentsData.Length
            If index = _selectedSegment Then
               Continue Do
            End If

            tempRectangle = Leadtools.Demos.Converters.ConvertRect(_segmentsData(index).ImageSegment)

            ' Find the left value
            If CanEnlargeFromBottom(tempRectangle, selectedRectangle) Then
               bottom = Math.Min(bottom, tempRectangle.Top)
            End If
            index += 1
         Loop
         _segmentsData(_selectedSegment).ImageSegment = New LeadRect(left, top, (right - left), (bottom - top))

         _mrcSegmenter.SetSegmentData(_viewer.Image, _selectedSegment, _segmentsData(_selectedSegment))
         RefreshSegments()
      End Sub

      Public Sub SaveLeadMrc(ByVal fileName As String, ByVal codecs As RasterCodecs, ByVal saveFormat As RasterImageFormat)
         Dim mainForm As MainForm = (CType(MdiParent, MainForm))
         Dim compressionOptions As MrcCompressionOptions = New MrcCompressionOptions()

         compressionOptions.PictureCoder = mainForm.GetPictureCompression(mainForm._pictureCoder)
         compressionOptions.Grayscale8BitCoder = mainForm.GetGrayscaleCompression8BitCoder(mainForm._grayscaleCoder8Bit)
         compressionOptions.Text2BitCoder = mainForm.GetTextCompressionCoder(mainForm._textCoder2Bit)
         compressionOptions.Grayscale2BitCoder = mainForm.GetGrayscaleCompression2BitCoder(mainForm._grayscaleCoder2Bit)
         compressionOptions.MaskCoder = mainForm.GetMaskCompression(mainForm._maskCoder)
         compressionOptions.PictureQualityFactor = mainForm._qFactor
         compressionOptions.Grayscale8BitFactor = mainForm._gSQFactor

         Select Case compressionOptions.PictureCoder
            Case MrcPictureCompression.LosslessJpeg, MrcPictureCompression.LosslessCmw
               compressionOptions.PictureQualityFactor = 0
         End Select
         Select Case compressionOptions.Grayscale8BitCoder
            Case MrcGrayscaleCompression8BitCoder.LosslessCmw, MrcGrayscaleCompression8BitCoder.LosslessJpeg
               compressionOptions.Grayscale8BitFactor = 0
         End Select

         If _optionsChanged OrElse _mrcSegmenter Is Nothing Then
            Try
               _mrcSegmenter = New MrcSegmenter(Image, Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._backColor), Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._foreColor))

               _optionsChanged = False
            Catch ex As Exception
               MrcError("An error occurred while trying to initialize the segmentation process.", ex)
            End Try

            Dim index As Integer = 0
            Do While index < _index - 1
               _mrcSegmenter.AddSegment(Image, _segmentsData(index))
               index += 1
            Loop
         End If

         Try
            If saveFormat = RasterImageFormat.LeadMrc Then
               _mrcSegmenter.SaveImage(_viewer.Image, fileName, MrcImageFormat.Mrc, compressionOptions, codecs)
            ElseIf saveFormat = RasterImageFormat.TifLeadMrc Then
               _mrcSegmenter.SaveImage(_viewer.Image, fileName, MrcImageFormat.MrcTif, compressionOptions, codecs)
            End If
         Catch ex As Exception
            MrcError("An error occurred while trying to save the image as LEAD Mrc.", ex)
         End Try
      End Sub

      Public Sub SaveMrc(ByVal fileName As String, ByVal codecs As RasterCodecs, ByVal saveFormat As RasterImageFormat)
         Dim mainForm As MainForm = (CType(MdiParent, MainForm))
         Dim compressionOptions As MrcCompressionOptions = New MrcCompressionOptions()

         compressionOptions.PictureCoder = mainForm.GetPictureCompression(mainForm._pictureCoder)
         compressionOptions.Text2BitCoder = mainForm.GetTextCompressionCoder(mainForm._textCoder2Bit)
         compressionOptions.MaskCoder = mainForm.GetMaskCompression(mainForm._maskCoder)
         compressionOptions.PictureQualityFactor = mainForm._qFactor

         If compressionOptions.PictureCoder <> MrcPictureCompression.Jpeg Then
            Messager.ShowWarning(Me, "Invalid picture compression, it will be replaced with ""JPEG compression"".")
            compressionOptions.PictureCoder = MrcPictureCompression.Jpeg
         End If

         If _optionsChanged OrElse _mrcSegmenter Is Nothing Then
            Try
               _mrcSegmenter = New MrcSegmenter(Image, Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._backColor), Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._foreColor))

               _optionsChanged = False
            Catch ex As Exception
               MrcError("An error occurred while trying to initialize the segmentation process.", ex)
            End Try

            Dim index As Integer = 0
            Do While index < _index - 1
               _mrcSegmenter.AddSegment(Image, _segmentsData(index))
               index += 1
            Loop
         End If

         Try
            If saveFormat = RasterImageFormat.Mrc Then
               _mrcSegmenter.SaveImageT44(_viewer.Image, fileName, MrcT44ImageFormat.MrcT44, compressionOptions, codecs)
            ElseIf saveFormat = RasterImageFormat.TifMrc Then
               _mrcSegmenter.SaveImageT44(_viewer.Image, fileName, MrcT44ImageFormat.MrcT44Tif, compressionOptions, codecs)
            End If
         Catch ex As Exception
            MrcError("An error occurred while trying to save the image as T44 Mrc.", ex)
         End Try

      End Sub

      Public Sub SavePDF(ByVal fileName As String, ByVal codecs As RasterCodecs)
         Dim mainForm As MainForm = (CType(MdiParent, MainForm))
         Dim compressionOptions As MrcCompressionOptions = New MrcCompressionOptions()

         compressionOptions.MaskCoder = mainForm.GetPDF1Compression(mainForm._pDFMaskCoder)
         compressionOptions.PictureQualityFactor = mainForm._pDFQFactor
         compressionOptions.PictureCoder = mainForm.GetPDFPictureCompression(mainForm._pDFPictureCoder)
         compressionOptions.Text2BitCoder = mainForm.GetPDF2Compression(mainForm._pDFTextCoder2Bit)

         If _optionsChanged OrElse _mrcSegmenter Is Nothing Then
            Try
               _mrcSegmenter = New MrcSegmenter(_viewer.Image, Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._backColor), Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._foreColor))

               _optionsChanged = False
            Catch ex As Exception
               MrcError("An error occurred while trying to initialize the segmentation process.", ex)
            End Try

            Dim index As Integer = 0
            Do While index < _index - 1
               _mrcSegmenter.AddSegment(_viewer.Image, _segmentsData(index))
               index += 1
            Loop
         End If

         Try
            _mrcSegmenter.SaveImage(_viewer.Image, fileName, MrcImageFormat.MrcPdf, compressionOptions, codecs)
         Catch ex As Exception
            MrcError("An error occurred while trying to save the image as PDF.", ex)
         End Try
      End Sub

      Public Sub SaveSegments(ByVal fileName As String)
         Try
            _mrcSegmenter.Save(fileName)
         Catch ex As Exception
            MrcError("Error exporting segments.", ex)
         End Try
      End Sub

      Public Sub LoadSegments(ByVal fileName As String)
         ClearSegments()
         _mrcSegmenter = New MrcSegmenter(_viewer.Image, fileName)
         RefreshSegments()
         _mrcStart = True
      End Sub

      Public Function GetRectangleAsImage() As RasterImage
         Try
            ' Make sure the coordinates are in the ViewPerspective of the _viewer.Image.
            _viewer.Image.RectangleFromImage(RasterViewPerspective.TopLeft, _segmentsData(_selectedSegment).ImageSegment)

            ' Copy the rectangle.
            Dim command As CopyRectangleCommand = New CopyRectangleCommand()
            command.Rectangle = _segmentsData(_selectedSegment).ImageSegment
            command.CreateFlags = RasterMemoryFlags.None
            command.Run(_viewer.Image)

            Return command.DestinationImage
         Catch ex As Exception
            Messager.ShowError(Me, ex.Message)
            Return Nothing
         End Try
      End Function

      Public Sub ShowSegmentType()
         Dim segmentTypeDlg As SegmentTypeDialog = New SegmentTypeDialog()

         segmentTypeDlg.SegmentType = _segmentsData(_selectedSegment).SegmentType

         If segmentTypeDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            AddToUndoList()
            _segmentsData(_selectedSegment).SegmentType = segmentTypeDlg.SegmentType
            _mrcSegmenter.SetSegmentData(_viewer.Image, _selectedSegment, _segmentsData(_selectedSegment))
            RefreshSegments()
         End If
      End Sub

      Public Sub ShowSegmentHistogram()
         Dim histogramDialog As HistogramDialog = New HistogramDialog(GetRectangleAsImage())

         histogramDialog.ShowDialog()
      End Sub

      Public Sub ShowHistogram()
         Dim histogramDialog As HistogramDialog = New HistogramDialog(_viewer.Image)

         histogramDialog.ShowDialog()
      End Sub

      Public Sub GetUniqueColorsCount()
         Dim command As ColorCountCommand = New ColorCountCommand()

         command.Run(_viewer.Image)

         Messager.ShowInformation(Me, "The image has " & command.ColorCount.ToString() & " colors.")
      End Sub

      Public Sub GetSegmentUniqueColorsCount()
         Dim command As ColorCountCommand = New ColorCountCommand()

         command.Run(GetRectangleAsImage())

         Messager.ShowInformation(Me, "The Segment has " & command.ColorCount.ToString() & " colors.")
      End Sub

      Public Sub AddToUndoList()
         If Not _mrcSegmenter Is Nothing AndAlso _index > 1 Then
            _previousSegmenter = CType(_mrcSegmenter.Clone(), MrcSegmenter)
            _enableUndo = True
         End If
      End Sub

      Public Sub Undo()
         If Not _previousSegmenter Is Nothing Then
            _mrcSegmenter = CType(_previousSegmenter.Clone(), MrcSegmenter)
            _selectedSegment = 0
            SetSelectionRectangles(_selectedSegment)
            RefreshSegments()
            _mrcStart = True
            _enableUndo = False
            _multiSelection = False
            CType(MdiParent, MainForm).UpdateControls()
         End If
      End Sub

      Public Sub ShowSegmentInformation()
         Dim dlg As SegmentInformationDialog = New SegmentInformationDialog(_segmentsData(_selectedSegment).SegmentType.ToString(), _viewer.Image.Width, _viewer.Image.Height)

         ' The NewRight value should be filled before the NewLeft value because the
         ' NewLeft value checks on the NewRight value for validation purposes...
         dlg.NewRight = _segmentsData(_selectedSegment).ImageSegment.Right
         dlg.NewLeft = _segmentsData(_selectedSegment).ImageSegment.Left

         ' The NewBottom value should be filled before the NewTop value because the
         ' NewTop value checks on the NewBottom value for validation purposes...
         dlg.NewBottom = _segmentsData(_selectedSegment).ImageSegment.Bottom
         dlg.NewTop = _segmentsData(_selectedSegment).ImageSegment.Top

         If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            AddToUndoList()
            _segmentsData(_selectedSegment).ImageSegment = New LeadRect(dlg.NewLeft, dlg.NewTop, (dlg.NewRight - dlg.NewLeft), (dlg.NewBottom - dlg.NewTop))

            _mrcSegmenter.SetSegmentData(_viewer.Image, _selectedSegment, _segmentsData(_selectedSegment))
            RefreshSegments()
         End If
      End Sub

      Private Sub _cmenuCombine_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmenuCombine.Popup
         If _selectedSegment <> -2 AndAlso (Not _multiSelection) Then
            If _index > 1 AndAlso _selectedSegment <> -1 Then
               CType(MdiParent, MainForm).CancelDrawing()

               Dim checkCombine As Boolean
               If (_selectedCombineSegment = -1) Then
                  checkCombine = False
               Else
                  checkCombine = True
               End If

               _cmenuCombineSegments.Visible = checkCombine
               _cmenuEnlargeSegment.Visible = Not checkCombine
               _cmenuShowInNewWindow.Visible = Not checkCombine
               _cmenuSeperator1.Visible = Not checkCombine
               _cmenuShowType.Visible = Not checkCombine
               _cmenuShowProperties.Visible = Not checkCombine
               _cmenuShowHistogram.Visible = Not checkCombine
               _cmenuUniqueColors.Visible = Not checkCombine
            Else
               If _index = 3 Then
                  _cmenuCombineSegments.Visible = True
                  _cmenuCombineSegments.Enabled = True
                  _selectedSegment = 0
                  _selectedCombineSegment = 1
               Else
                  _cmenuCombineSegments.Visible = False
               End If

               _cmenuEnlargeSegment.Visible = False
               _cmenuShowInNewWindow.Visible = False
               _cmenuSeperator1.Visible = False
               _cmenuShowType.Visible = False
               _cmenuShowProperties.Visible = False
               _cmenuShowHistogram.Visible = False
               _cmenuUniqueColors.Visible = False
            End If
         Else
            _cmenuCombineSegments.Visible = False
            _cmenuEnlargeSegment.Visible = False
            _cmenuShowInNewWindow.Visible = False
            _cmenuSeperator1.Visible = False
            _cmenuShowType.Visible = False
            _cmenuShowProperties.Visible = False
            _cmenuShowHistogram.Visible = False
            _cmenuUniqueColors.Visible = False
         End If
      End Sub

      Private Sub _cmenuEnlargeSegment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmenuEnlargeSegment.Click
         AddToUndoList()
         EnlargeSegment()
      End Sub

      Private Sub _cmenuShowInNewWindow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmenuShowInNewWindow.Click
         CType(MdiParent, MainForm)._miViewShowInNewWindow_Click(sender, e)
      End Sub

      Private Sub _cmenuShowType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmenuShowType.Click
         ShowSegmentType()
      End Sub

      Private Sub _cmenuShowProperties_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmenuShowProperties.Click
         ShowSegmentInformation()
      End Sub

      Private Sub _cmenuShowHistogram_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmenuShowHistogram.Click
         ShowSegmentHistogram()
      End Sub

      Private Sub _cmenuUniqueColors_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmenuUniqueColors.Click
         GetSegmentUniqueColorsCount()
      End Sub

      Private Sub MrcError(ByVal message As String, ByVal ex As Exception)
         Messager.ShowError(Me, String.Format("{0}{1}{1}Error: {2}", message, Environment.NewLine, ex.Message))
      End Sub

      Private Sub _viewer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
         If (Not e.Handled) Then
            If e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.Oemplus Then
               e.Handled = True

               CType(MdiParent, MainForm)._miView_Click((CType(MdiParent, MainForm)).ZoomIn, Nothing)
            ElseIf e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.OemMinus Then
               e.Handled = True

               CType(MdiParent, MainForm)._miView_Click((CType(MdiParent, MainForm)).ZoomOut, Nothing)
            ElseIf e.KeyCode = Keys.Escape Then
               e.Handled = True

               CType(MdiParent, MainForm).CancelDrawing()
            End If
         End If
      End Sub

      Private Sub ViewerForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
         If AddSegment Then
            CType(MdiParent, MainForm).CancelDrawing()
         End If
      End Sub

      Private Sub ViewerForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
         If AddSegment AndAlso _drawNewSegment Then
            CType(MdiParent, MainForm).CancelDrawing()
         End If
      End Sub
   End Class
End Namespace
