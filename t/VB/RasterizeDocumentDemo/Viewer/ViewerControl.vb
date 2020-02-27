' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.ComponentModel
Imports System.IO
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Codecs
Imports Leadtools.Drawing

''' <summary>
''' This control contains an instance of RasterImageViewer plus
''' a tool strip control for common operations
''' </summary>
Public Class ViewerControl
   ' Minimum and maximum scale percentages allowed
   Private Const _minimumViewerScalePercentage As Double = 1
   Private Const _maximumViewerScalePercentage As Double = 6400

   ' Current document
   Private _documentFileName As String

   ' Current interactive mode (with the mouse)
   Private _interactiveMode As ViewerControlInteractiveMode

   ' Ruler size and edges
   Private Const _rulerEdge As Integer = 10
   Private Const _rulerSize As Integer = 20

   ' Default ruler resolution
   Private _defaultRulerXResolution As Single
   Private _defaultRulerYResolution As Single

   ' The ruler properties
   Private _rulerPainter As New RulerPainter()
   Private _horizontalRulerBounds As Rectangle
   Private _verticalRulerBounds As Rectangle
   Private _horizontalRulerLength As Double
   Private _verticalRulerLength As Double
   Private _horizontalRulerResolution As Single
   Private _verticalRulerResolution As Single
   Private _horizontalRulerOrigin As Integer
   Private _verticalRulerOrigin As Integer
   Private _panInteractiveMode As ImageViewerPanZoomInteractiveMode
   Private _zoomToInteractiveMode As ImageViewerZoomToInteractiveMode
   Private _rasterCodecsInstance As RasterCodecs
   ' The viewer transform matrix
   Private _viewerTransform As LeadMatrix

   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      _panInteractiveMode = New ImageViewerPanZoomInteractiveMode()
      _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left
      _zoomToInteractiveMode = New ImageViewerZoomToInteractiveMode()

      _imageViewer.InteractiveModes.BeginUpdate()
      _imageViewer.InteractiveModes.Add(_panInteractiveMode)
      _imageViewer.InteractiveModes.Add(_zoomToInteractiveMode)
      _imageViewer.InteractiveModes.EndUpdate()

      DisableInteractiveModes()
      _imageViewer.InteractiveModes.EnableById(_panInteractiveMode.Id)

      ' Add any initialization after the InitializeComponent() call.
      If Not DesignMode Then
         ' We will be using the same image in the RasterImageViewer and RasterImageList
         ' So, we will let the RasterImageViewer be the control responsible for disposing
         ' the image
         _imageList.AutoDisposeImages = False

         ' For smooth rulers
         SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
      End If
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If Not DesignMode Then
         InteractiveMode = ViewerControlInteractiveMode.PanMode

         ' High-quality paint
         HighQualityPaintScaling = True

         ' These events are needed and not visible from the designer, so
         ' hook into them here
         AddHandler _zoomToolStripComboBox.LostFocus, AddressOf _zoomToolStripComboBox_LostFocus
         AddHandler _pageToolStripTextBox.LostFocus, AddressOf _pageToolStripTextBox_LostFocus

         ' Call the transform changed event
         _imageViewer_TransformChanged(_imageViewer, EventArgs.Empty)

         _mousePositionLabel.Text = String.Empty

         _imageViewer.Padding = New Padding(8)

         ' Move the viewer to the left and down to make room for the rulers
         _imageViewer.Dock = DockStyle.Fill
         _imageViewer.BringToFront()
         Dim rc As Rectangle = _imageViewer.Bounds

         ' Get its bounds
         Dim rulerOverallSize As Integer = _rulerEdge * 2 + _rulerSize
         rc.X = rc.X + rulerOverallSize
         rc.Y = rc.Y + rulerOverallSize
         rc.Width = rc.Width - rulerOverallSize
         rc.Height = rc.Height - rulerOverallSize

         _imageViewer.Dock = DockStyle.None
         _imageViewer.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Bottom
         _imageViewer.Bounds = rc

         Using g As Graphics = CreateGraphics()
            _defaultRulerXResolution = g.DpiX
            _defaultRulerYResolution = g.DpiY
         End Using

         _rulerPainter.FontFamilyName = Font.FontFamily.Name
      End If

      MyBase.OnLoad(e)
   End Sub

   ''' <summary>
   ''' Called by the main form to change the page viewing mode (from the main menu)
   ''' </summary>
   Public Sub FitPage(ByVal fitWidth As Boolean)
      ' Since we are doing more than one operation on the viewer, it is
      ' recommended to disable then re-enable updates on the viewer to
      ' minimize flickering

      _imageViewer.BeginUpdate()

      If fitWidth Then
         _imageViewer.Zoom(ControlSizeMode.FitWidth, 1, _imageViewer.DefaultZoomOrigin)
      Else
         _imageViewer.Zoom(ControlSizeMode.Fit, 1, _imageViewer.DefaultZoomOrigin)
      End If

      _imageViewer.EndUpdate()

      UpdateUIState()
   End Sub

   ''' <summary>
   ''' Zoom the viewer in our out
   ''' </summary>
   ''' <param name="zoomOut"></param>
   Public Sub ZoomViewer(ByVal zoomOut As Boolean)
      ' Get the current scale factor
      Dim percentage As Double = _imageViewer.XScaleFactor * 100.0

      ' The valid scale factors are here
      Dim validPercentages() As Double = _
      { _
         _minimumViewerScalePercentage, 6.25, 12.5, 25, 33.3, 50, 66.7, 73.6, 92.5, 100, _
         125, 150, 200, 300, 400, 600, 800, 1200, 1600, 2400, _
         3200, _maximumViewerScalePercentage _
      }

      ' Find out where we are, move to the next one up or down depending on 'zoomOut'
      If zoomOut Then
         For i As Integer = validPercentages.Length - 1 To 0 Step -1
            If percentage > validPercentages(i) Then
               percentage = validPercentages(i)
               Exit For
            End If
         Next
      Else
         For i As Integer = 0 To validPercentages.Length - 1
            If percentage < validPercentages(i) Then
               percentage = validPercentages(i)
               Exit For
            End If
         Next
      End If

      SetViewerZoomPercentage(percentage)
   End Sub

   ''' <summary>
   ''' Called by the main form to get/set the current ruler unit
   ''' </summary>
   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public Property RulerInInches() As Boolean
      Get
         Return (_rulerPainter.Unit = RulerPainterUnit.Inch)
      End Get
      Set(ByVal value As Boolean)
         Dim newUnit As RulerPainterUnit = If(value, RulerPainterUnit.Inch, RulerPainterUnit.Millimeter)

         If newUnit <> _rulerPainter.Unit Then
            _rulerPainter.Unit = newUnit
            UpdateRulers()
            UpdatePageInfo()
            Invalidate()
         End If
      End Set
   End Property

   ''' <summary>
   ''' Current interactive mode (what happens when the user uses the mouse on the viewer)
   ''' </summary>
   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public Property InteractiveMode() As ViewerControlInteractiveMode
      Get
         Return _interactiveMode
      End Get
      Set(ByVal value As ViewerControlInteractiveMode)
         _interactiveMode = value

         ' Set the RasterImageViewer interactive mode accordingly
         Select Case _interactiveMode
            Case ViewerControlInteractiveMode.PanMode
               DisableInteractiveModes()
               _imageViewer.InteractiveModes.EnableById(_panInteractiveMode.Id)

            Case ViewerControlInteractiveMode.ZoomToSelectionMode
               DisableInteractiveModes()
               _imageViewer.InteractiveModes.EnableById(_zoomToInteractiveMode.Id)
         End Select

         UpdateUIState()
      End Set
   End Property

   ''' <summary>
   ''' Called by the main form to set a new document into the viewer
   ''' </summary>
   Public Sub SetDocument(ByVal documentFileName As String, ByVal totalPages As Integer, ByVal rasterCodecsInstance As RasterCodecs)
      _documentFileName = documentFileName
      _rasterCodecsInstance = rasterCodecsInstance

      If Not IsNothing(_imageViewer.Image) Then
         RemoveHandler _imageViewer.Image.Changed, AddressOf Image_Changed
      End If

      ' Set the new image in the viewer
      '_imageViewer.Image = image

      If Not IsNothing(_imageViewer.Image) Then
         AddHandler _imageViewer.Image.Changed, AddressOf Image_Changed
      End If

      ' Create the pages thumbnails
      _imageList.Items.Clear()


      ' Create the thumbnails
      For pageNumber As Integer = 1 To totalPages
         Dim thumbnailImage As RasterImage = _rasterCodecsInstance.Load(_documentFileName, 160, 160, 0, RasterSizeFlags.Resample, CodecsLoadByteOrder.BgrOrGray, pageNumber, pageNumber)
         If Not IsNothing(thumbnailImage) Then
            Dim item As New ImageViewerItem()
            item.Image = thumbnailImage
            item.Tag = pageNumber
            item.Text = "Page " + (pageNumber).ToString()
            item.PageNumber = pageNumber
            _imageList.Items.Add(item)
         End If
         _imageList.Items(0).IsSelected = True
      Next

      UpdateImageInfo()
      UpdatePageInfo()

      UpdateUIState()
   End Sub

   ''' <summary>
   ''' Called by the main form to get the viewer
   ''' </summary>
   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public ReadOnly Property RasterImageViewer() As ImageViewer
      Get
         Return _imageViewer
      End Get
   End Property

   ''' <summary>
   ''' Called by the main form to get/set the paint scaling
   ''' </summary>
   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public Property HighQualityPaintScaling() As Boolean
      Get
         Dim props As RasterPaintProperties = _imageViewer.PaintProperties

         Dim highQuality As Boolean = _
            (props.PaintDisplayMode And RasterPaintDisplayModeFlags.ScaleToGray) = RasterPaintDisplayModeFlags.ScaleToGray AndAlso _
            (props.PaintDisplayMode And RasterPaintDisplayModeFlags.Bicubic) = RasterPaintDisplayModeFlags.Bicubic

         Return highQuality
      End Get
      Set(ByVal value As Boolean)
         Dim props As RasterPaintProperties = _imageViewer.PaintProperties

         If value Then
            ' Set the paint scaling to ScaleToGray (for 1-bit images) and Bicubic (for color images)
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray Or RasterPaintDisplayModeFlags.Bicubic
         Else
            ' Set to highest speed
            props.PaintDisplayMode = props.PaintDisplayMode And (Not (RasterPaintDisplayModeFlags.ScaleToGray Or RasterPaintDisplayModeFlags.Bicubic))
         End If

         _imageViewer.PaintProperties = props
         _imageList.PaintProperties = props
      End Set
   End Property

   ''' <summary>
   ''' Called by the main form when the page number changes
   ''' </summary>
   Public Sub SetCurrentPageNumber(ByVal pageNumber As Integer)
      _imageViewer.Image.Page = pageNumber
      UpdateUIState()
   End Sub

   Private Sub Image_Changed(ByVal sender As Object, ByVal e As RasterImageChangedEventArgs)
      If (e.Flags And RasterImageChangedFlags.Page) = RasterImageChangedFlags.Page Then
         TryGotoPage(_imageViewer.Image.Page)
      End If

      UpdateUIState()
   End Sub

   Private Sub UpdateImageInfo()
      If Not String.IsNullOrEmpty(_documentFileName) Then
         If Not _imageInfoTableLayoutPanel.Visible Then
            _imageInfoTableLayoutPanel.Visible = True
         End If

         ' Update the info panel with current image information
         Dim image As RasterImage = _imageViewer.Image

         Dim fileLength As Long

         Try
            Dim fi As New FileInfo(_documentFileName)
            fileLength = fi.Length
         Catch
            fileLength = 0
         End Try

         _imageInfoFileSizeValueLabel.Text = String.Format("{0} KB ({1} Bytes)", (CType(fileLength, Double) / 1024.0).ToString("0.00"), fileLength.ToString("#,#"))

         ' The rest (size, bits/pixel) etc gets updated when the page is updated
      Else
         _imageInfoTableLayoutPanel.Visible = False
      End If
   End Sub

   Private Sub UpdatePageInfo()
      Dim image As RasterImage = _imageViewer.Image
      If Not IsNothing(image) Then
         Dim dataSize As Long = image.DataSize
         _imageInfoMemorySizeValueLabel.Text = String.Format("{0} KB ({1} Bytes)", (CType(dataSize, Double) / 1024.0).ToString("0.00"), dataSize.ToString("#,#"))
         _imageInfoBitsPerPixelValueLabel.Text = image.BitsPerPixel.ToString()

         _imageInfoPageSizePixelsLabel.Text = String.Format("{0} x {1}   pixels", image.ImageWidth, image.ImageHeight)

         Dim xResolution As Integer = image.XResolution
         Dim yResolution As Integer = image.YResolution
         _imageInfoPageSizeResolutionLabel.Text = String.Format("{0} x {1}   pixels/inch", xResolution, yResolution)

         Dim cxInches As Single = CType(image.ImageWidth, Single) / CType(xResolution, Single)
         Dim cyInches As Single = CType(image.ImageHeight, Single) / CType(yResolution, Single)

         If RulerInInches Then
            _imageInfoPageSizeLogicalLabel.Text = String.Format("{0} x {1}   inches", cxInches.ToString("0.00"), cyInches.ToString("0.00"))
         Else
            ' The ruler is in metric

            Dim cxMM As Double = InchesToMM(cxInches)
            Dim cyMM As Double = InchesToMM(cyInches)
            _imageInfoPageSizeLogicalLabel.Text = String.Format("{0} x {1}   cm", (cxMM / 10.0).ToString("0.00"), (cyMM / 10.0).ToString("0.00"))
         End If
      End If
   End Sub

   Private Sub UpdateZoomValueFromControl()
      ' We are invoking this instead of changing the properties
      ' directly because the Text value of a combo box is not
      ' updated till after the lost focus or enter event is exited
      BeginInvoke(New MethodInvoker(AddressOf InvokeUpdateZoomValueFromControl))
   End Sub

   Private Sub InvokeUpdateZoomValueFromControl()
      If Not IsNothing(_imageViewer.Image) Then
         Dim factor As Double = _imageViewer.XScaleFactor * 100.0
         _zoomToolStripComboBox.Text = factor.ToString("F1") + "%"
      Else
         _zoomToolStripComboBox.Text = String.Empty
      End If
   End Sub

   Private Sub UpdateUIState()
      ' Update the UI controls states

      _fitPageWidthToolStripButton.Checked = (_imageViewer.SizeMode = RasterPaintSizeMode.FitWidth)
      _fitPageToolStripButton.Checked = (_imageViewer.SizeMode = RasterPaintSizeMode.Fit)
      _useDpiToolStripButton.Checked = _imageViewer.UseDpi

      _panModeToolStripButton.Checked = (_interactiveMode = ViewerControlInteractiveMode.PanMode)
      _zoomToSelectionModeToolStripButton.Checked = (_interactiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode)

      If Not IsNothing(_imageViewer.Image) Then
         If Not _toolStrip.Enabled Then
            _toolStrip.Enabled = True
         End If

         Dim currentPage As Integer = _imageList.ActiveItem.Tag
         Dim pageCount As Integer = _imageList.Items.Count

         _pageToolStripTextBox.Text = currentPage.ToString()
         _pageToolStripLabel.Text = "/ " + pageCount.ToString()

         _pageToolStripTextBox.Enabled = (pageCount > 1)

         _previousPageToolStripButton.Enabled = (currentPage > 1)
         _nextPageToolStripButton.Enabled = (currentPage < pageCount)

         UpdatePageInfo()
      Else
         If _toolStrip.Enabled Then
            _toolStrip.Enabled = False
         End If

         _pageToolStripTextBox.Text = "0"
         _pageToolStripLabel.Text = "/ 0"

         _zoomToolStripComboBox.Text = String.Empty
      End If
   End Sub

   Private Sub _imageViewer_TransformChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _imageViewer.TransformChanged, _imageViewer.TransformChanged
      If (Not DesignMode) AndAlso (IsHandleCreated) Then
         _viewerTransform = _imageViewer.ViewTransform

         UpdateZoomValueFromControl()
         UpdateUIState()
         UpdateRulers()
      End If
   End Sub

   Private Sub _previousPageToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _previousPageToolStripButton.Click
      TryGotoPage(_imageList.ActiveItem.Tag - 1)
   End Sub

   Private Sub _nextPageToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _nextPageToolStripButton.Click
      TryGotoPage(_imageList.ActiveItem.Tag + 1)
   End Sub

   Private Sub _pageToolStripTextBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      _pageToolStripTextBox.Text = _imageViewer.Image.Page.ToString()
   End Sub

   Private Sub _pageToolStripTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _pageToolStripTextBox.KeyPress
      If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
         ' User has pressed enter, go to the new page number

         Dim str As String = _pageToolStripTextBox.Text.Trim()

         ' Try to parse the integer value
         Dim pageNumber As Integer
         If Integer.TryParse(str, pageNumber) Then
            TryGotoPage(pageNumber)
         End If

         _pageToolStripTextBox.Text = _imageViewer.Image.Page.ToString()
      End If
   End Sub

   Private Sub TryGotoPage(ByVal pageNumber As Integer)
      ' Check if the index is valid
      If pageNumber >= 1 AndAlso pageNumber <= _imageList.Items.Count Then
         _imageList.BeginUpdate()

         For i As Integer = 0 To _imageList.Items.Count - 1
            Dim item As ImageViewerItem = _imageList.Items(i)

            If item.Tag = pageNumber Then
               item.IsSelected = True
            Else
               item.IsSelected = False
            End If
         Next

         _imageList.EnsureItemVisible(_imageList.Items(pageNumber - 1))
         _imageList.EndUpdate()
      End If
   End Sub

   Private Sub _zoomOutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zoomOutToolStripButton.Click
      ZoomViewer(True)
   End Sub

   Private Sub _zoomInToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zoomInToolStripButton.Click
      ZoomViewer(False)
   End Sub

   Private Sub _zoomToolStripComboBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      UpdateZoomValueFromControl()
   End Sub

   Private Sub _zoomToolStripComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zoomToolStripComboBox.SelectedIndexChanged
      ' Parse the new zoom value
      Dim str As String = _zoomToolStripComboBox.Text.Trim()

      Select Case str
         Case "Actual Size"
            SetViewerZoomPercentage(100)

         Case "Fit Page"
            _fitPageToolStripButton.PerformClick()

         Case "Fit Width"
            _fitPageWidthToolStripButton.PerformClick()

         Case Else
            If Not String.IsNullOrEmpty(str) Then
               Dim val As Double = Double.Parse(str.Substring(0, str.Length - 1))
               SetViewerZoomPercentage(val)
            End If
      End Select
   End Sub

   Private Sub _zoomToolStripComboBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _zoomToolStripComboBox.KeyPress
      If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
         ' User has pressed enter, parse the new zoom value

         Dim str As String = _zoomToolStripComboBox.Text.Trim()

         If Not String.IsNullOrEmpty(str) Then
            ' Remove the % sign if present
            If str.EndsWith("%") Then
               str = str.Remove(str.Length - 1, 1).Trim()
            End If

            ' Try to parse the new zoom value
            Dim percentage As Double
            If Double.TryParse(str, percentage) Then
               SetViewerZoomPercentage(percentage)
            End If

            UpdateZoomValueFromControl()
         End If
      End If
   End Sub

   Private Sub SetViewerZoomPercentage(ByVal percentage As Double)
      ' Normalize the percentage based on min/max value allowed
      percentage = Math.Max(_minimumViewerScalePercentage, Math.Min(_maximumViewerScalePercentage, percentage))

      If Math.Abs(_imageViewer.XScaleFactor * 100.0 - percentage) > 0.01 Then
         _imageViewer.BeginUpdate()

         ' Zoom
         _imageViewer.Zoom(ControlSizeMode.None, percentage / 100.0, _imageViewer.DefaultZoomOrigin)

         _imageViewer.EndUpdate()

         _imageViewer_TransformChanged(_imageViewer, EventArgs.Empty)

         UpdateUIState()
      End If
   End Sub

   Private Sub _fitPageWidthToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fitPageWidthToolStripButton.Click
      FitPage(True)
   End Sub

   Private Sub _fitPageToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fitPageToolStripButton.Click
      FitPage(False)
   End Sub

   Private Sub _useDpiToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _useDpiToolStripButton.Click
      _imageViewer.UseDpi = Not _imageViewer.UseDpi
   End Sub

   Private Sub _panModeToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _panModeToolStripButton.Click
      InteractiveMode = ViewerControlInteractiveMode.PanMode
   End Sub

   Private Sub _zoomToSelectionModeToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zoomToSelectionModeToolStripButton.Click
      InteractiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode
   End Sub

   Private Sub DisableInteractiveModes()
      For Each mode As ImageViewerInteractiveMode In _imageViewer.InteractiveModes
         mode.IsEnabled = False
      Next mode
   End Sub

   'Private Sub _imageViewer_InteractiveZoomTo(ByVal sender As System.Object, ByVal e As RasterViewerRectangleEventArgs) Handles _imageViewer.InteractiveZoomTo
   '   ' Switch back to 'select' mode when the user finishes zoom/selection
   '   If e.Status = RasterViewerInteractiveStatus.End Then
   '      ' Go back to pan mode
   '      ' We must invoke this because the select button will change the
   '      ' interactive mode of the viewer and hence, cancel the current
   '      ' operation
   '      BeginInvoke(New MethodInvoker(AddressOf _panModeToolStripButton.PerformClick))
   '   End If
   'End Sub

   Private Sub _imageViewer_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _imageViewer.MouseMove, _imageViewer.MouseMove
      Dim str As String = String.Empty

      If Not IsNothing(_imageViewer.Image) Then
         ' Show the mouse position in physical and logical (inches) coordinates

         If _imageViewer.DisplayRectangle.Contains(e.X, e.Y) Then
            Dim physical As New PointF(e.X, e.Y)
            Dim pixels As PointF

            Dim trans As New Transformer(New Matrix(Convert.ToSingle(_viewerTransform.M11), Convert.ToSingle(_viewerTransform.M12), Convert.ToSingle(_viewerTransform.M21), Convert.ToSingle(_viewerTransform.M22), Convert.ToSingle(_viewerTransform.OffsetX), Convert.ToSingle(_viewerTransform.OffsetY)))
            pixels = trans.PointToLogical(physical)

            ' Convert the logical point to inches
            Dim inches As PointF = PointF.Empty
            inches.X = CType(pixels.X, Single) / CType(_imageViewer.Image.XResolution, Single)
            inches.Y = CType(pixels.Y, Single) / CType(_imageViewer.Image.YResolution, Single)

            str = String.Format("{0},{1} px {2},{3} in", CType(pixels.X, Integer), CType(pixels.Y, Integer), inches.X.ToString("F02"), inches.Y.ToString("F02"))
         End If
      End If

      _mousePositionLabel.Text = str
   End Sub

   Private Sub _imageList_SelectedItemsChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _imageList.SelectedItemsChanged, _imageList.SelectedItemsChanged

      ' Find the first selected item in the image list, it is
      ' a single selection control
      For i As Integer = 0 To _imageList.Items.Count - 1
         If _imageList.Items(i).IsSelected Then
            _imageList.ActiveItem = _imageList.Items(i)
            _imageViewer.Image = _rasterCodecsInstance.Load(_documentFileName, _imageList.Items(i).Tag)
         End If
      Next
      UpdateUIState()
   End Sub

   Private Sub UpdateRulers()
      Dim image As RasterImage = _imageViewer.Image
      If IsNothing(image) Then
         Return
      End If

      _horizontalRulerResolution = _defaultRulerXResolution
      _verticalRulerResolution = _defaultRulerXResolution

      ' Update the ruler lengths
      If _imageViewer.UseDpi Then
         _horizontalRulerLength = CType(image.ImageWidth, Double) / image.XResolution
         _verticalRulerLength = CType(image.ImageHeight, Double) / image.YResolution
      Else
         _horizontalRulerLength = CType(image.ImageWidth, Double) / _defaultRulerXResolution
         _verticalRulerLength = CType(image.ImageHeight, Double) / _defaultRulerYResolution
      End If

      ' The length is in inches, see if we need it in mm
      If _rulerPainter.Unit = RulerPainterUnit.Millimeter Then
         _horizontalRulerLength = InchesToMM(_horizontalRulerLength)
         _verticalRulerLength = InchesToMM(_verticalRulerLength)
      End If

      ' Update the ruler bounds
      _horizontalRulerBounds = New Rectangle(_imageViewer.Left - (_rulerEdge), _imageViewer.Top - (_rulerEdge + _rulerSize), ClientSize.Width, _rulerSize)
      _verticalRulerBounds = New Rectangle(_imageViewer.Left - (_rulerEdge + _rulerSize), _imageViewer.Top - (_rulerEdge), _rulerSize, ClientSize.Height)

      ' Find out where 0,0 is
      Dim pt As PointF = New Transformer(New Matrix(Convert.ToSingle(_viewerTransform.M11), Convert.ToSingle(_viewerTransform.M12), Convert.ToSingle(_viewerTransform.M21), Convert.ToSingle(_viewerTransform.M22), Convert.ToSingle(_viewerTransform.OffsetX), Convert.ToSingle(_viewerTransform.OffsetY))).PointToPhysical(PointF.Empty)

      _horizontalRulerOrigin = CType(pt.X, Integer) + _rulerEdge
      _verticalRulerOrigin = CType(pt.Y, Integer) + _rulerEdge

      Invalidate()
   End Sub

   Private Shared Function InchesToMM(ByVal inchesValue As Double) As Double
      ' The length is in inches, see if we need it in mm
      Const mmRatio As Double = 25.400000025908
      Dim mmValue As Double = inchesValue * mmRatio
      Return mmValue
   End Function

   Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
      If Not IsNothing(_imageViewer.Image) Then
         Dim g As Graphics = e.Graphics

         ' Paint the horizontal ruler
         Dim bounds As Rectangle = _horizontalRulerBounds
         _rulerPainter.Orientation = RulerPainterOrientation.Horizontal
         _rulerPainter.Resolution = _horizontalRulerResolution
         _rulerPainter.ScaleFactor = _imageViewer.XScaleFactor
         _rulerPainter.OriginPixelOffset = _horizontalRulerOrigin
         _rulerPainter.Length = _horizontalRulerLength
         _rulerPainter.Paint(g, bounds)

         ' Paint the vertical ruler
         bounds = _verticalRulerBounds
         _rulerPainter.Orientation = RulerPainterOrientation.Vertical
         _rulerPainter.Resolution = _verticalRulerResolution
         _rulerPainter.ScaleFactor = _imageViewer.XScaleFactor
         _rulerPainter.OriginPixelOffset = _verticalRulerOrigin
         _rulerPainter.Length = _verticalRulerLength
         _rulerPainter.Paint(g, bounds)
      End If
   End Sub
End Class
