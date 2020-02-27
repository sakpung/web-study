' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Drawing
Imports Leadtools.Barcode
Imports Leadtools.Controls
Imports BarcodeMainDemo.Leadtools.Demos

''' <summary>
''' This control contains an instance of RasterImageViewer plus
''' a tool strip control for common operations
''' </summary>
Partial Public Class ViewerControl : Inherits UserControl
#Region "Private"
    ' Minimum and maximum scale percentages allowed
    Private Const _minimumViewerScalePercentage As Double = 1
    Private Const _maximumViewerScalePercentage As Double = 6400
    'Interactive modes
    Private _noneInteractiveMode As ImageViewerNoneInteractiveMode = Nothing
    Private _panInteractiveMode As ImageViewerPanZoomInteractiveMode = Nothing
    Private _zoomToInteractiveMode As ImageViewerZoomToInteractiveMode = Nothing
    Private _rectInteractiveMode As ImageViewerRubberBandInteractiveMode = Nothing
    Private _regionInteractiveMode As ImageViewerAddRegionInteractiveMode = Nothing


    ' Current interactive mode (with the mouse)
    Private _interactiveMode As ViewerControlInteractiveMode = ViewerControlInteractiveMode.SelectMode

    ' Current document barcodes
    Private _documentBarcodes As DocumentBarcodes

    Private _disableExtraDrawing As Boolean
    Public _viewerRegion As Boolean = False
    Public _viewerRegionCopy As Boolean = False
    Public _viewerRegionPage As Integer
    Public RegionG As RasterRegion
    Public FourPoints As Boolean

    Private Sub UpdatePageInfo()
        Dim sb As StringBuilder = New StringBuilder()

        If Not _rasterImageViewer.Image Is Nothing Then
            Dim image As RasterImage = _rasterImageViewer.Image

            sb.AppendFormat(DemosGlobalization.GetResxString(Me.GetType(), "Resx_Size"), image.ImageWidth, image.ImageHeight, image.XResolution, image.YResolution, image.BitsPerPixel)
        End If

        _pageInfoLabel.Text = sb.ToString()
    End Sub

    Public Property NoneInteractiveMode() As ImageViewerNoneInteractiveMode
        Get
            Return _noneInteractiveMode
        End Get
        Set(value As ImageViewerNoneInteractiveMode)
            _noneInteractiveMode = value
        End Set
    End Property

    Public Property PanInteractiveMode() As ImageViewerPanZoomInteractiveMode
        Get
            Return _panInteractiveMode
        End Get
        Set(value As ImageViewerPanZoomInteractiveMode)
            _panInteractiveMode = value
        End Set
    End Property

    Public Property ZoomToInteractiveMode() As ImageViewerZoomToInteractiveMode
        Get
            Return _zoomToInteractiveMode
        End Get
        Set(value As ImageViewerZoomToInteractiveMode)
            _zoomToInteractiveMode = value
        End Set
    End Property

    Public Property RectInteractiveMode() As ImageViewerRubberBandInteractiveMode
        Get
            Return _rectInteractiveMode
        End Get
        Set(value As ImageViewerRubberBandInteractiveMode)
            _rectInteractiveMode = value
        End Set
    End Property

    Public Property RegionInteractiveMode() As ImageViewerAddRegionInteractiveMode
        Get
            Return _regionInteractiveMode
        End Get
        Set(value As ImageViewerAddRegionInteractiveMode)
            _regionInteractiveMode = value
        End Set
    End Property

    Private Delegate Sub DoActionDelegate(ByVal action As String, ByVal data As Object)

    Private Sub DoAction(ByVal action As String, ByVal data As Object)
        ' Raise the action event so the main form can handle it

        If Not ActionEvent Is Nothing Then
            RaiseEvent action(Me, New ActionEventArgs(action, data))
        End If
    End Sub

#End Region ' Private

#Region "Control"
    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        If (Not DesignMode) Then
            ' We cannot run without document support
            InitViewer()

            ' These events are needed and not visible from the designer, so hook into them here
            AddHandler _zoomToolStripComboBox.LostFocus, AddressOf _zoomToolStripComboBox_LostFocus
            AddHandler _pageToolStripTextBox.LostFocus, AddressOf _pageToolStripTextBox_LostFocus

            ' Call the transform changed event
            _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty)

            _mousePositionLabel.Text = String.Empty

        End If

        MyBase.OnLoad(e)
    End Sub
#End Region ' Control

#Region "Public"
    ''' <summary>
    ''' The instance of RasterImageViewer used in this viewer
    ''' </summary>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property RasterImageViewer() As ImageViewer
        Get
            Return _rasterImageViewer
        End Get
    End Property

    ''' <summary>
    ''' Called by the main form to set the new raster image and barcodes
    ''' </summary>
    Public Sub SetDocument(ByVal image As RasterImage, ByVal documentBarcodes As DocumentBarcodes)
        _documentBarcodes = documentBarcodes

        _rasterImageViewer.Image = image

        UpdatePageInfo()
        UpdateUIState()
    End Sub

    ''' <summary>
    ''' Called by the main form when the page number of the image is changed
    ''' </summary>
    Public Sub SetCurrentPageNumber(ByVal pageNumber As Integer)
        _rasterImageViewer.Image.Page = pageNumber
        _rasterImageViewer.Items(0).PageNumber = pageNumber
        UpdatePageInfo()
        UpdateUIState()
    End Sub

    ''' <summary>
    ''' Called by the main form to change the page viewing mode (from the main menu)
    ''' </summary>
    Public Sub FitPage(ByVal fitWidth As Boolean)
        ' Since we are doing more than one operation on the viewer, it is
        ' recommended to disable then re-enable updates on the viewer to
        ' minimize flickering

        _rasterImageViewer.BeginUpdate()

        If fitWidth Then
            _rasterImageViewer.Zoom(ControlSizeMode.FitWidth, 1, _rasterImageViewer.DefaultZoomOrigin)
        Else
            _rasterImageViewer.Zoom(ControlSizeMode.FitAlways, 1, _rasterImageViewer.DefaultZoomOrigin)
        End If

        _rasterImageViewer.EndUpdate()

        UpdateUIState()
    End Sub

    ''' <summary>
    ''' Zoom the viewer in our out
    ''' </summary>
    Public Sub ZoomViewer(ByVal zoomOut As Boolean)
        ' Get the current scale factor
        Dim percentage As Double = _rasterImageViewer.XScaleFactor * 100.0

        ' The valid scale factors are here
        Dim validPercentages As Double() = {_minimumViewerScalePercentage, 6.25, 12.5, 25, 33.3, 50, 66.7, 73.6, 92.5, 100, 125, 150, 200, 300, 400, 600, 800, 1200, 1600, 2400, 3200, _maximumViewerScalePercentage}

        ' Find out where we are, move to the next one up or down depending on 'zoomOut'
        If zoomOut Then
            For i As Integer = validPercentages.Length - 1 To 0 Step -1
                If percentage > validPercentages(i) Then
                    percentage = validPercentages(i)
                    Exit For
                End If
            Next i
        Else
            Dim i As Integer = 0
            Do While i < validPercentages.Length
                If percentage < validPercentages(i) Then
                    percentage = validPercentages(i)
                    Exit Do
                End If
                i += 1
            Loop
        End If

        SetViewerZoomPercentage(percentage)
    End Sub

    ''' <summary>
    ''' Current interactive mode (what happens when the user uses the mouse on the viewer)
    ''' </summary>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property InteractiveMode() As ViewerControlInteractiveMode
        Get
            Return _interactiveMode
        End Get
        Set(value As ViewerControlInteractiveMode)
            _interactiveMode = value

            For Each mode As ImageViewerInteractiveMode In _rasterImageViewer.InteractiveModes
                mode.IsEnabled = False
            Next mode

            ' Set the RasterImageViewer interactive mode accordingly
            Select Case _interactiveMode
                Case ViewerControlInteractiveMode.SelectMode
                    _rasterImageViewer.InteractiveModes.EnableById(_noneInteractiveMode.Id)

                Case ViewerControlInteractiveMode.PanMode
                    _rasterImageViewer.InteractiveModes.EnableById(_panInteractiveMode.Id)

                Case ViewerControlInteractiveMode.ZoomToSelectionMode
                    _rasterImageViewer.InteractiveModes.EnableById(_zoomToInteractiveMode.Id)

                Case ViewerControlInteractiveMode.RegionMode
                    RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
                    _rasterImageViewer.InteractiveModes.EnableById(_regionInteractiveMode.Id)

                Case ViewerControlInteractiveMode.ReadBarcodeMode
                    RectInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
                    _rasterImageViewer.InteractiveModes.EnableById(_rectInteractiveMode.Id)

                Case ViewerControlInteractiveMode.WriteBarcodeMode
                    RectInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
                    _rasterImageViewer.InteractiveModes.EnableById(_rectInteractiveMode.Id)
            End Select

            UpdateUIState()
        End Set
    End Property

    ''' <summary>
    ''' Called by the main form to show/hide the barcodes
    ''' </summary>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ShowBarcodes() As Boolean
        Get
            Return _showBarcodesToolStripButton.Checked
        End Get
        Set(value As Boolean)
            _showBarcodesToolStripButton.Checked = value

            If (Not _showBarcodesToolStripButton.Checked) Then
                _interactiveMode = ViewerControlInteractiveMode.SelectMode
            End If

            _rasterImageViewer.Invalidate()
            UpdateUIState()
        End Set
    End Property

    ''' <summary>
    ''' Called when the RasterImage region is changed from outside
    ''' </summary>
    Public Sub ImageRegionChanged()
        UpdateUIState()
    End Sub

    ''' <summary>
    ''' This event is fired by the control when an action occurs that must be handled by
    ''' the owner (the main form)
    ''' </summary>
    Public Event Action As EventHandler(Of ActionEventArgs)
#End Region ' Public

#Region "Viewer"
    Private Sub InitViewer()
        ' Use ScaleToGray and Bicubic for optimum viewing of black/white and color images
        Dim props As RasterPaintProperties = _rasterImageViewer.PaintProperties
        props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.Bicubic

        If (Not RasterSupport.IsLocked(RasterSupportType.Document)) Then
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray
        End If

        _rasterImageViewer.PaintProperties = props

        ' Pad the viewer
        _rasterImageViewer.Padding = New Padding(10)

        ' Set the cursors
        _noneInteractiveMode = New ImageViewerNoneInteractiveMode()
        _panInteractiveMode = New ImageViewerPanZoomInteractiveMode()
        _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left
        _zoomToInteractiveMode = New ImageViewerZoomToInteractiveMode()
        AddHandler _zoomToInteractiveMode.RubberBandCompleted, AddressOf _rasterImageViewer_InteractiveZoomTo
        _rectInteractiveMode = New ImageViewerRubberBandInteractiveMode()
        _regionInteractiveMode = New ImageViewerAddRegionInteractiveMode()
        AddHandler _regionInteractiveMode.RubberBandCompleted, AddressOf _rasterImageViewer_InteractiveRegionRectangle
        AddHandler _regionInteractiveMode.RubberBandStarted, AddressOf RegionInteractiveMode_RubberBandStarted
        AddHandler _rectInteractiveMode.RubberBandCompleted, AddressOf RectInteractiveMode_RubberBandCompleted
        _noneInteractiveMode.IdleCursor = Cursors.Arrow
        _noneInteractiveMode.WorkingCursor = Cursors.Arrow

        _panInteractiveMode.IdleCursor = Cursors.Hand
        _panInteractiveMode.WorkingCursor = Cursors.Hand

        _zoomToInteractiveMode.IdleCursor = Cursors.Cross
        _zoomToInteractiveMode.WorkingCursor = Cursors.Cross

        _rectInteractiveMode.IdleCursor = Cursors.Cross
        _rectInteractiveMode.WorkingCursor = Cursors.Cross

        _regionInteractiveMode.IdleCursor = Cursors.Cross
        _regionInteractiveMode.WorkingCursor = Cursors.Cross

        _rasterImageViewer.InteractiveModes.BeginUpdate()
        _rasterImageViewer.InteractiveModes.Add(_noneInteractiveMode)
        _rasterImageViewer.InteractiveModes.Add(_panInteractiveMode)
        _rasterImageViewer.InteractiveModes.Add(_zoomToInteractiveMode)
        _rasterImageViewer.InteractiveModes.Add(_rectInteractiveMode)
        _rasterImageViewer.InteractiveModes.Add(_regionInteractiveMode)
        _rasterImageViewer.InteractiveModes.EndUpdate()
    End Sub

   Private Sub RectInteractiveMode_RubberBandCompleted(ByVal sender As Object, ByVal e As ImageViewerRubberBandEventArgs)
      Dim actionName As String = Nothing

      If InteractiveMode = ViewerControlInteractiveMode.ReadBarcodeMode Then
         actionName = "ReadBarcode"
      ElseIf InteractiveMode = ViewerControlInteractiveMode.WriteBarcodeMode Then
         actionName = "WriteBarcode"
      End If

      If Not actionName Is Nothing Then
         Dim MyRect As LeadRect = LeadRect.Create(e.InteractiveEventArgs.Origin.X, e.InteractiveEventArgs.Origin.Y, e.InteractiveEventArgs.Position.X - e.InteractiveEventArgs.Origin.X, e.InteractiveEventArgs.Position.Y - e.InteractiveEventArgs.Origin.Y)
         Dim pixels As Rectangle = New Rectangle(CInt(MyRect.X), CInt(MyRect.Y), CInt(MyRect.Width), CInt(MyRect.Height))

         If pixels.Left > pixels.Right Then
            pixels = Rectangle.FromLTRB(pixels.Right, pixels.Top, pixels.Left, pixels.Bottom)
         End If
         If pixels.Top > pixels.Bottom Then
            pixels = Rectangle.FromLTRB(pixels.Left, pixels.Bottom, pixels.Right, pixels.Top)
         End If

         If pixels.Width > 2 AndAlso pixels.Height > 2 Then
            Dim pixelsF As RectangleF = pixels

            Dim m As Matrix = GetMatrixFromLeadMatrix(_rasterImageViewer.GetImageTransformWithDpi(True))
            Try
               Dim trans As Transformer = New Transformer(m)
               pixelsF = trans.RectangleToLogical(pixelsF)
            Finally
               CType(m, IDisposable).Dispose()
            End Try

            pixelsF = RectangleF.Intersect(New RectangleF(0, 0, _rasterImageViewer.Image.ImageWidth, _rasterImageViewer.Image.ImageHeight), pixelsF)
            pixels = Rectangle.Round(pixelsF)

            Dim bounds As LeadRect = New LeadRect(pixels.X, pixels.Y, pixels.Width, pixels.Height)
            BeginInvoke(New DoActionDelegate(AddressOf DoAction), New Object() {actionName, bounds})
         End If
      End If
   End Sub

    Private Sub RegionInteractiveMode_RubberBandStarted(ByVal sender As Object, ByVal e As ImageViewerRubberBandEventArgs)
        _disableExtraDrawing = True
        _rasterImageViewer.Invalidate()
        _rasterImageViewer.Update()
    End Sub

    Private Sub _rasterImageViewer_TransformChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _rasterImageViewer.TransformChanged
        If IsHandleCreated Then
            If _viewerRegionCopy Then
                RegionG = _rasterImageViewer.Image.GetRegion(Nothing)
                _rasterImageViewer.CombineFloater(True)
                _viewerRegionPage = _rasterImageViewer.Image.Page
                _viewerRegionCopy = False
                _viewerRegion = True
            End If
            UpdateZoomValueFromControl()
            UpdateUIState()
        End If
    End Sub

    Private Sub _rasterImageViewer_InteractiveZoomTo(ByVal sender As Object, ByVal e As ImageViewerRubberBandEventArgs)
        ' Go back to selection mode
        ' We must invoke this because the select button will change the
        ' interactive mode of the viewer and hence, cancel the current
        ' operation
        BeginInvoke(New MethodInvoker(AddressOf DoSelectMode))
    End Sub

    Private Sub _rasterImageViewer_InteractiveRegionRectangle(ByVal sender As Object, ByVal e As ImageViewerRubberBandEventArgs)
        ' Go back to selection mode
        ' We must invoke this because the select button will change the
        ' interactive mode of the viewer and hence, cancel the current
        ' operation
        BeginInvoke(New MethodInvoker(AddressOf DoSelectMode))
        BeginInvoke(New MethodInvoker(AddressOf UpdateUIState))

        _disableExtraDrawing = False
        _viewerRegionCopy = True
    End Sub

    Private Function GetMatrixFromLeadMatrix(ByVal matrix As LeadMatrix) As Matrix
        Return New Matrix(CSng(matrix.M11), CSng(matrix.M12), CSng(matrix.M21), CSng(matrix.M22), CSng(matrix.OffsetX), CSng(matrix.OffsetY))
    End Function

    Private Sub _rasterImageViewer_PostImagePaint(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs) Handles _rasterImageViewer.PostRender
        Dim image As RasterImage = _rasterImageViewer.Image

        If Not image Is Nothing AndAlso (Not _disableExtraDrawing) Then
            If ShowBarcodes Then
                Dim sf As StringFormat = New StringFormat()
                Try
                    Dim normalBrush As Brush = New SolidBrush(Color.FromArgb(200, Color.DarkGreen))
                    Try
                        Dim normalPen As Pen = New Pen(Color.FromArgb(180, Color.DarkGreen), 4)
                        Try
                            Dim selectedBrush As Brush = New SolidBrush(Color.FromArgb(200, Color.Blue))
                            Try
                                Dim selectedPen As Pen = New Pen(Color.FromArgb(180, Color.Blue), 4)
                                Try
                                    sf.FormatFlags = StringFormatFlags.NoWrap

                                    ' Draw the barcodes for this page
                                    Dim index As Integer = 0
                                    Dim pageBarcodes As PageBarcodes = _documentBarcodes.Pages(image.Page - 1)
                                    For Each data As BarcodeData In pageBarcodes.Barcodes
                                        If index = pageBarcodes.SelectedIndex Then
                                            DrawBarcodeData(e.PaintEventArgs.Graphics, image, data, sf, selectedBrush, selectedPen)
                                        Else
                                            DrawBarcodeData(e.PaintEventArgs.Graphics, image, data, sf, normalBrush, normalPen)
                                        End If

                                        index += 1
                                    Next data
                                Finally
                                    CType(selectedPen, IDisposable).Dispose()
                                End Try
                            Finally
                                CType(selectedBrush, IDisposable).Dispose()
                            End Try
                        Finally
                            CType(normalPen, IDisposable).Dispose()
                        End Try
                    Finally
                        CType(normalBrush, IDisposable).Dispose()
                    End Try
                Finally
                    CType(sf, IDisposable).Dispose()
                End Try


            End If

            If _viewerRegion AndAlso _rasterImageViewer.Image.Page = _viewerRegionPage Then
                ' Draw an alpha brush around the image region
                If (Not _rasterImageViewer.Image.HasRegion) Then
                    _rasterImageViewer.Image.SetRegion(Nothing, RegionG, RasterRegionCombineMode.Set)
                End If
                Dim regionBounds As LeadRect = RegionG.GetBounds()

                Dim regionRect As LeadRectD = New LeadRectD(regionBounds.X, regionBounds.Y, regionBounds.Width, regionBounds.Height)
                regionRect = _rasterImageViewer.ImageTransform.TransformRect(regionRect)
                regionRect.Inflate(1, 1)
                Dim imageRect As LeadRectD = New LeadRectD(0, 0, image.ImageWidth, image.ImageHeight)
                imageRect = _rasterImageViewer.ImageTransform.TransformRect(imageRect)
                imageRect.Inflate(1, 1)

                Dim region As Region = New Region(New Rectangle(CInt(imageRect.X), CInt(imageRect.Y), CInt(imageRect.Width), CInt(imageRect.Height)))
                Try
                    region.Exclude(New Rectangle(CInt(regionRect.X), CInt(regionRect.Y), CInt(regionRect.Width), CInt(regionRect.Height)))
                    Dim brush As Brush = New HatchBrush(HatchStyle.SmallConfetti, Color.Black, Color.FromArgb(64, Color.Black))
                    Try
                        e.PaintEventArgs.Graphics.FillRegion(brush, region)
                    Finally
                        CType(brush, IDisposable).Dispose()
                    End Try
                Finally
                    CType(region, IDisposable).Dispose()
                End Try

                e.PaintEventArgs.Graphics.DrawRectangle(Pens.Black, CInt(regionRect.X), CInt(regionRect.Y), CInt(regionRect.Width), CInt(regionRect.Height))
                e.PaintEventArgs.Graphics.DrawRectangle(Pens.Black, CInt(imageRect.X), CInt(imageRect.Y), CInt(imageRect.Width), CInt(imageRect.Height))
            End If
        End If
    End Sub

    Private Sub DrawBarcodeData(ByVal g As Graphics, ByVal image As RasterImage, ByVal data As BarcodeData, ByVal sf As StringFormat, ByVal brush As Brush, ByVal pen As Pen)
      Dim rect As LeadRect = data.Bounds
      Dim rc As LeadRectD = New LeadRectD(rect.X, rect.Y, rect.Width, rect.Height)
      Dim line As String = BarcodeEngine.GetSymbologyFriendlyName(data.Symbology)
      If FourPoints AndAlso data.Symbology <> BarcodeSymbology.Aztec AndAlso data.Symbology <> BarcodeSymbology.Maxi AndAlso data.Symbology <> BarcodeSymbology.MicroQR Then
         Dim pointsL As LeadPointD() = New LeadPointD(3) {}
         Dim points As Point() = New Point(3) {}
         pointsL(0).X = (CInt(rc.Left) And &HFFFF)
         pointsL(0).Y = (CInt(rc.Left) >> 16)
         pointsL(1).X = (CInt(rc.Top) And &HFFFF)
         pointsL(1).Y = (CInt(rc.Top) >> 16)
         pointsL(2).X = (CInt(rc.Width) And &HFFFF)
         pointsL(2).Y = (CInt(rc.Width) >> 16)
         pointsL(3).X = (CInt(rc.Height) And &HFFFF)
         pointsL(3).Y = (CInt(rc.Height) >> 16)

         _rasterImageViewer.ImageTransform.TransformPoints(pointsL)

         For i As Integer = 0 To 3
            points(i).X = CInt(pointsL(i).X)
            points(i).Y = CInt(pointsL(i).Y)
         Next

         g.DrawPolygon(pen, points)

         Dim size As SizeF = g.MeasureString(line, Font, points(2).X - points(0).X, sf)
         rc.Width = CInt(size.Width) + 1
         rc.Height = CInt(size.Height) + 1

         g.FillRectangle(brush, points(0).X, points(0).Y, CInt(rc.Width), CInt(rc.Height))
         g.DrawString(line, Font, Brushes.White, New RectangleF(points(0).X, points(0).Y, CInt(rc.Width), CInt(rc.Height)), sf)
      Else
         rc = _rasterImageViewer.ImageTransform.TransformRect(rc)
         rc.Inflate(3, 3)

         If rc.Width < 10 OrElse rc.Height < 10 Then
            Return
         End If

         g.DrawRectangle(pen, CInt(rc.X), CInt(rc.Y), CInt(rc.Width), CInt(rc.Height))

         Dim size As SizeF = g.MeasureString(line, Font, CInt(rc.Width), sf)
         rc.Width = CInt(size.Width) + 1
         rc.Height = CInt(size.Height) + 1

         g.FillRectangle(brush, CInt(rc.X), CInt(rc.Y), CInt(rc.Width), CInt(rc.Height))
         g.DrawString(line, Font, Brushes.White, New RectangleF(CInt(rc.X), CInt(rc.Y), CInt(rc.Width), CInt(rc.Height)), sf)
      End If
   End Sub

    Private Sub _rasterImageViewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _rasterImageViewer.MouseMove
        Dim str As String = String.Empty

        Dim image As RasterImage = _rasterImageViewer.Image
        If Not image Is Nothing Then
            Dim pixels As LeadPoint = PhysicalToLogical(New LeadPoint(e.X, e.Y))

            If pixels.X >= 0 AndAlso pixels.X <= image.ImageWidth AndAlso pixels.Y >= 0 AndAlso pixels.Y <= image.ImageHeight Then
                str = String.Format("{0},{1} px", CInt(pixels.X), CInt(pixels.Y))
            End If

            If InteractiveMode = ViewerControlInteractiveMode.SelectMode Then
                Dim index As Integer = HitTestBarcode(pixels)
                If index <> -1 Then
                    _rasterImageViewer.Cursor = Cursors.Cross
                ElseIf MainForm.InversePerspectiveActive = False Then
                    _rasterImageViewer.Cursor = Cursors.Default
                End If
            End If
        End If

        _mousePositionLabel.Text = str
    End Sub

    Private Sub _rasterImageViewer_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _rasterImageViewer.MouseClick
        Dim image As RasterImage = _rasterImageViewer.Image
        If Not image Is Nothing AndAlso InteractiveMode = ViewerControlInteractiveMode.SelectMode Then
            Dim pixels As LeadPoint = PhysicalToLogical(New LeadPoint(e.X, e.Y))

            If pixels.X >= 0 AndAlso pixels.X <= image.ImageWidth AndAlso pixels.Y >= 0 AndAlso pixels.Y <= image.ImageHeight Then
                Dim index As Integer = HitTestBarcode(pixels)
                If index <> _documentBarcodes.Pages(_rasterImageViewer.Image.Page - 1).SelectedIndex Then
                    DoAction("SelectedBarcodeChanged", index)
                End If
            End If
        End If
    End Sub

    Function PhysicalToLogical(ByVal physical As LeadPoint) As LeadPoint
        Dim pixelsF As PointF = New PointF(physical.X, physical.Y)

        Dim m As Matrix = GetMatrixFromLeadMatrix(_rasterImageViewer.GetImageTransformWithDpi(True))
        Try
            Dim trans As Transformer = New Transformer(m)
            pixelsF = trans.PointToLogical(pixelsF)
        Finally
            CType(m, IDisposable).Dispose()
        End Try

        Dim pixels As Point = Point.Round(pixelsF)
        Return New LeadPoint(pixels.X, pixels.Y)
    End Function

    Private Function HitTestBarcode(ByVal point As LeadPoint) As Integer
        Dim index As Integer = 0
        Dim pageBarcodes As PageBarcodes = _documentBarcodes.Pages(_rasterImageViewer.Image.Page - 1)
        For Each data As BarcodeData In pageBarcodes.Barcodes
            If data.Bounds.Contains(point) Then
                Return index
            End If

            index += 1
        Next data

        Return -1
    End Function
#End Region ' Viewer

#Region "UI"
    Private Sub UpdateUIState()
        ' Update the UI controls states

        _fitPageWidthToolStripButton.Checked = _rasterImageViewer.SizeMode = ControlSizeMode.FitWidth
        _fitPageToolStripButton.Checked = _rasterImageViewer.SizeMode = ControlSizeMode.FitAlways

        _selectModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.SelectMode
        _panModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.PanMode
        _zoomToSelectionModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode
        _regionModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.RegionMode
        _deleteRegionToolStripButton.Enabled = Not _rasterImageViewer.Image Is Nothing AndAlso _viewerRegion
        _readBarcodeModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.ReadBarcodeMode
        _writeBarcodeModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.WriteBarcodeMode
        _writeBarcodeModeToolStripButton.Enabled = _showBarcodesToolStripButton.Checked

        If Not _rasterImageViewer.Image Is Nothing Then
            If (Not _toolStrip.Enabled) AndAlso MainForm.InversePerspectiveActive = False Then
                _toolStrip.Enabled = True
            End If

            Dim pageNumber As Integer = _rasterImageViewer.Image.Page
            Dim pageCount As Integer = _rasterImageViewer.Image.PageCount

            _pageToolStripTextBox.Text = pageNumber.ToString()
            _pageToolStripLabel.Text = "/ " & pageCount.ToString()
            _pageToolStripTextBox.Enabled = pageCount > 1

            _previousPageToolStripButton.Enabled = pageNumber > 1
            _nextPageToolStripButton.Enabled = pageNumber < pageCount
        Else
            _pageToolStripTextBox.Text = "0"
            _pageToolStripLabel.Text = "/ 0"

            _zoomToolStripComboBox.Text = String.Empty

            _toolStrip.Enabled = False
        End If
    End Sub

    Private Sub UpdateZoomValueFromControl()
        ' We are invoking this instead of changing the properties
        ' directly because the Text value of a combo box is not
        ' updated till after the lost focus or enter event is exited
        BeginInvoke(New MethodInvoker(Sub()
                                          If Not _rasterImageViewer.Image Is Nothing Then
                                              Dim factor As Double = _rasterImageViewer.XScaleFactor * 100.0
                                              _zoomToolStripComboBox.Text = factor.ToString("F1") & "%"
                                          Else
                                              _zoomToolStripComboBox.Text = String.Empty
                                          End If
                                      End Sub
       ))
    End Sub

    Private Sub _previousPageToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _previousPageToolStripButton.Click
        TryGotoPage(_rasterImageViewer.Image.Page - 1)
    End Sub

    Private Sub _nextPageToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _nextPageToolStripButton.Click
        TryGotoPage(_rasterImageViewer.Image.Page + 1)
    End Sub

    Private Sub _pageToolStripTextBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        _pageToolStripTextBox.Text = _rasterImageViewer.Image.Page.ToString()
    End Sub

    Private Sub _pageToolStripTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _pageToolStripTextBox.KeyPress
        If e.KeyChar = CChar(Microsoft.VisualBasic.ChrW(Keys.Return)) Then
            ' User has pressed enter, go to the new page number

            Dim str As String = _pageToolStripTextBox.Text.Trim()

            ' Try to parse the integer value
            Dim pageNumber As Integer
            If Integer.TryParse(str, pageNumber) Then
                TryGotoPage(pageNumber)
            End If

            _pageToolStripTextBox.Text = _rasterImageViewer.Image.Page.ToString()
        End If
    End Sub

    Private Sub TryGotoPage(ByVal pageNumber As Integer)
        ' Check if the index is valid
        If pageNumber >= 1 AndAlso pageNumber <= _rasterImageViewer.Image.PageCount Then
            ' Yes, fire the event to the main form
            DoAction("PageNumberChanged", pageNumber)
        End If
    End Sub

    Private Sub _zoomOutToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _zoomOutToolStripButton.Click
        ZoomViewer(True)
    End Sub

    Private Sub _zoomInToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _zoomInToolStripButton.Click
        ZoomViewer(False)
    End Sub

    Private Sub _zoomToolStripComboBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        UpdateZoomValueFromControl()
    End Sub

    Private Sub _zoomToolStripComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _zoomToolStripComboBox.SelectedIndexChanged
        ' Parse the new zoom value
        Dim str As String = _zoomToolStripComboBox.Text.Trim()

        Select Case str
            Case "Actual Size"
                SetViewerZoomPercentage(100)

            Case "Fit Page"
                FitPage(False)

            Case "Fit Width"
                FitPage(True)

            Case Else
                If (Not String.IsNullOrEmpty(str)) Then
                    Dim val As Double = Double.Parse(str.Substring(0, str.Length - 1))
                    SetViewerZoomPercentage(val)
                End If
        End Select
    End Sub

    Private Sub _zoomToolStripComboBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _zoomToolStripComboBox.KeyPress
        If e.KeyChar = CChar(Microsoft.VisualBasic.ChrW(Keys.Return)) Then
            ' User has pressed enter, parse the new zoom value

            Dim str As String = _zoomToolStripComboBox.Text.Trim()

            If (Not String.IsNullOrEmpty(str)) Then
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

        If Math.Abs(_rasterImageViewer.XScaleFactor * 100.0 - percentage) > 0.01 Then
            ' Save the current center location in the viewer, we will use it later to
            ' re-center the viewer
            Dim rc As Rectangle = Rectangle.Intersect(_rasterImageViewer.DisplayRectangle, _rasterImageViewer.ClientRectangle)
            Dim center As PointF = New PointF(Convert.ToSingle(rc.Left + rc.Width / 2), Convert.ToSingle(rc.Top + rc.Right / 2))

            Using m As Matrix = New Matrix(Convert.ToSingle(_rasterImageViewer.GetImageTransformWithDpi(True).M11), Convert.ToSingle(_rasterImageViewer.GetImageTransformWithDpi(True).M12), Convert.ToSingle(_rasterImageViewer.GetImageTransformWithDpi(True).M21), Convert.ToSingle(_rasterImageViewer.GetImageTransformWithDpi(True).M22), Convert.ToSingle(_rasterImageViewer.GetImageTransformWithDpi(True).OffsetX), Convert.ToSingle(_rasterImageViewer.GetImageTransformWithDpi(True).OffsetY))
                Dim trans As Transformer = New Transformer(m)
                center = trans.PointToLogical(center)
            End Using

            _rasterImageViewer.BeginUpdate()

            ' Zoom
            _rasterImageViewer.Zoom(ControlSizeMode.None, percentage / 100.0, _rasterImageViewer.DefaultZoomOrigin)

            ' Go back to original center point
            Using m As Matrix = New Matrix(Convert.ToSingle(_rasterImageViewer.GetImageTransformWithDpi(True).M11), Convert.ToSingle(_rasterImageViewer.GetImageTransformWithDpi(True).M12), Convert.ToSingle(_rasterImageViewer.GetImageTransformWithDpi(True).M21), Convert.ToSingle(_rasterImageViewer.GetImageTransformWithDpi(True).M22), Convert.ToSingle(_rasterImageViewer.GetImageTransformWithDpi(True).OffsetX), Convert.ToSingle(_rasterImageViewer.GetImageTransformWithDpi(True).OffsetY))
                Dim trans As Transformer = New Transformer(m)
                center = trans.PointToPhysical(center)
            End Using

            _rasterImageViewer.CenterAtPoint(New LeadPoint(Point.Round(center).X, Point.Round(center).Y))

            _rasterImageViewer.EndUpdate()

            _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty)

            UpdateUIState()
        End If
    End Sub

    Private Sub _fitPageWidthToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _fitPageWidthToolStripButton.Click
        FitPage(True)
    End Sub

    Private Sub _fitPageToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _fitPageToolStripButton.Click
        FitPage(False)
    End Sub

    Private Sub _selectModeToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _selectModeToolStripButton.Click
        DoSelectMode()
    End Sub

    Private Sub DoSelectMode()
        InteractiveMode = ViewerControlInteractiveMode.SelectMode
    End Sub

    Private Sub _panModeToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _panModeToolStripButton.Click
        InteractiveMode = ViewerControlInteractiveMode.PanMode
    End Sub

    Private Sub _zoomToSelectionModeToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _zoomToSelectionModeToolStripButton.Click
        InteractiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode
    End Sub

    Private Sub _regionModeToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _regionModeToolStripButton.Click
        InteractiveMode = ViewerControlInteractiveMode.RegionMode
    End Sub

    Private Sub _deleteRegionToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _deleteRegionToolStripButton.Click
        _viewerRegion = False
        _rasterImageViewer.Image.MakeRegionEmpty()

        ImageRegionChanged()
        _rasterImageViewer.Invalidate()
    End Sub

    Private Sub _writeBarcodeModeToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _writeBarcodeModeToolStripButton.Click
        InteractiveMode = ViewerControlInteractiveMode.WriteBarcodeMode
    End Sub

    Private Sub _readBarcodeModeToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _readBarcodeModeToolStripButton.Click
        InteractiveMode = ViewerControlInteractiveMode.ReadBarcodeMode
    End Sub

    Private Sub _showBarcodesToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _showBarcodesToolStripButton.Click
        _showBarcodesToolStripButton.Checked = Not _showBarcodesToolStripButton.Checked
        _rasterImageViewer.Invalidate()
    End Sub
#End Region ' UI
End Class
