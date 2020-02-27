' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System

Imports Leadtools
Imports Leadtools.Drawing
Imports Leadtools.Controls
Imports Leadtools.Pdf
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Codecs
Imports PDFDocumentDemo.Leadtools.Demos

Namespace PDFDocumentDemo.ViewerControl
   Partial Public Class ViewerControl
      Inherits UserControl
#Region "Private"
      ' Minimum and maximum scale percentages allowed
      Private Const _minimumViewerScalePercentage As Double = 1
      Private Const _maximumViewerScalePercentage As Double = 6400

      ' Current interactive mode (with the mouse)
      Private _interactiveMode As ViewerControlInteractiveMode

      'Interactive Modes
      Private _noneInteractiveMode As ImageViewerNoneInteractiveMode
      Private _automationInteractiveMode As AutomationInteractiveMode
      Private _panInteractiveMode As ImageViewerPanZoomInteractiveMode
      Private _zoomToInteractiveMode As ImageViewerZoomToInteractiveMode
      Private _regionInteractiveMode As ImageViewerAddRegionInteractiveMode
      Private _rectangleInteractiveMode As ImageViewerRubberBandInteractiveMode

      'Interactive mode public methods
      Public Property NoneInteractiveMode() As ImageViewerNoneInteractiveMode
         Get
            Return _noneInteractiveMode
         End Get
         Set(value As ImageViewerNoneInteractiveMode)
            _noneInteractiveMode = value
         End Set
      End Property

      Public Property automationInteractiveMode() As AutomationInteractiveMode
         Get
            Return _automationInteractiveMode
         End Get
         Set(value As AutomationInteractiveMode)
            _automationInteractiveMode = value
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

      Public Property RegionInteractiveMode() As ImageViewerAddRegionInteractiveMode
         Get
            Return _regionInteractiveMode
         End Get
         Set(value As ImageViewerAddRegionInteractiveMode)
            _regionInteractiveMode = value
         End Set
      End Property

      Public Property RectangleInteractiveMode() As ImageViewerRubberBandInteractiveMode
         Get
            Return _rectangleInteractiveMode
         End Get
         Set(value As ImageViewerRubberBandInteractiveMode)
            _rectangleInteractiveMode = value
         End Set
      End Property

      ' Current PDF document
      Private _document As PDFDocument
      Private _isNewDocument As Boolean

      ' The selected text for each page
      Private _selectedText As Dictionary(Of Integer, MyWord())

      ' Current page number
      Private _currentPageNumber As Integer

      ' These are the hyperlinks and internal links of the current page
      ' We group them here because we will check them often in the mouse move
      Private Structure PageLink
         Public ImageBounds As LeadRect
         ' The bounds of the link in image coordinates
         Public InternalLinkIndex As Integer
         ' If not -1, the index into PDFDocument.InternalLinks
         Public HyperLinkIndex As Integer
         ' If not -1, the index into PDFPage.Hyperlinks
      End Structure

      Private _pageLinks As List(Of PageLink)

      Private Sub UpdatePageInfo()
         Dim sb As New StringBuilder()

         If _document IsNot Nothing Then
            Dim page As PDFDocumentPage = _document.Pages(_currentPageNumber - 1)
            sb.AppendFormat(DemosGlobalization.GetResxString([GetType](), "resx_SizeBy"), page.WidthPixels, page.HeightPixels, page.WidthInches.ToString("F02"), page.HeightInches.ToString("F02"))
         End If

         _pageInfoLabel.Text = sb.ToString()
      End Sub

      Private Delegate Sub DoActionDelegate(action As String, data As Object)

      Private Sub DoAction(action As String, data As Object)
         ' Raise the action event so the main form can handle it

         RaiseEvent Action(Me, New ActionEventArgs(action, data))
      End Sub
#End Region

#Region "Control"
      Public Sub New()
         InitializeComponent()

         Dim dropShadow As ControlDropShadowOptions = Me._rasterImageViewer.ImageDropShadow
         dropShadow.IsVisible = True
         Me._rasterImageViewer.ImageDropShadow = dropShadow

         'Initialize Interactive modes
         InitializeInteractivemodes()
      End Sub

      Private Sub InitializeInteractivemodes()
         'None
         NoneInteractiveMode = New ImageViewerNoneInteractiveMode()
         _rasterImageViewer.InteractiveModes.Add(NoneInteractiveMode)
         'Annotations
         automationInteractiveMode = New AutomationInteractiveMode()
         automationInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left Or System.Windows.Forms.MouseButtons.Right
         automationInteractiveMode.IdleCursor = Cursors.[Default]
         automationInteractiveMode.WorkingCursor = Cursors.[Default]
         _rasterImageViewer.InteractiveModes.Add(automationInteractiveMode)
         'Pan
         PanInteractiveMode = New ImageViewerPanZoomInteractiveMode()
         PanInteractiveMode.EnablePan = True
         PanInteractiveMode.EnableZoom = False
         PanInteractiveMode.EnablePinchZoom = False
         PanInteractiveMode.WorkOnBounds = True
         _rasterImageViewer.InteractiveModes.Add(PanInteractiveMode)
         'ZoomTo
         ZoomToInteractiveMode = New ImageViewerZoomToInteractiveMode()
         ZoomToInteractiveMode.WorkOnBounds = True
         ZoomToInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
         AddHandler ZoomToInteractiveMode.WorkCompleted, AddressOf ZoomToInteractiveMode_WorkCompleted
         _rasterImageViewer.InteractiveModes.Add(ZoomToInteractiveMode)
         'Region
         RegionInteractiveMode = New ImageViewerAddRegionInteractiveMode()
         RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
         RegionInteractiveMode.AutoRegionToFloater = True
         RegionInteractiveMode.WorkOnBounds = True
         _rasterImageViewer.InteractiveModes.Add(RegionInteractiveMode)
         'Rectangle
         RectangleInteractiveMode = New ImageViewerRubberBandInteractiveMode()
         RectangleInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
         RectangleInteractiveMode.WorkOnBounds = True
         AddHandler RectangleInteractiveMode.RubberBandCompleted, AddressOf RectangleInteractiveMode_RubberBandCompleted
         _rasterImageViewer.InteractiveModes.Add(RectangleInteractiveMode)

         automationInteractiveMode.IsEnabled = True
         _rasterImageViewer.InteractiveModes.EnableById(automationInteractiveMode.Id)
      End Sub

      Protected Overrides Sub OnLoad(e As EventArgs)
         If Not DesignMode Then
            ' We cannot run without document support
            If Not RasterSupport.IsLocked(RasterSupportType.Document) Then
               InitViewer()

               ' These events are needed and not visible from the designer, so hook into them here
               AddHandler _zoomToolStripComboBox.LostFocus, AddressOf _zoomToolStripComboBox_LostFocus
               AddHandler _pageToolStripTextBox.LostFocus, AddressOf _pageToolStripTextBox_LostFocus

               ' Call the transform changed event
               _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty)

               InteractiveMode = ViewerControlInteractiveMode.SelectMode

               _mousePositionLabel.Text = String.Empty
            End If
         End If

         MyBase.OnLoad(e)
      End Sub
#End Region

#Region "Public"
      ''' <summary>
      ''' The instance of RasterImageViewer used in this viewer
      ''' </summary>
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property RasterImageViewer() As AutomationImageViewer
         Get
            Return _rasterImageViewer
         End Get
      End Property

      ''' <summary>
      ''' Called by the main form to set the new document
      ''' </summary>
      Public Sub SetDocument(document As PDFDocument, selectedText As Dictionary(Of Integer, MyWord()))
         _document = document
         _selectedText = selectedText
         _currentPageNumber = 1
         _isNewDocument = True

         UpdatePageInfo()
         UpdateUIState()
      End Sub

      Public Sub RunLink(document As PDFDocument, pageFitType As PDFPageFitType, zoomPercent As Integer)
         _rasterImageViewer.BeginUpdate()

         Dim sizeMode As ControlSizeMode

         Select Case pageFitType
            Case PDFPageFitType.FitWidth, PDFPageFitType.FitWidthBounds
               sizeMode = ControlSizeMode.FitWidth
               Exit Select

            Case PDFPageFitType.FitHeight, PDFPageFitType.FitHeightBounds, PDFPageFitType.FitBounds
               sizeMode = ControlSizeMode.Fit
               Exit Select

            Case Else
               sizeMode = ControlSizeMode.ActualSize
               Exit Select
         End Select

         If sizeMode <> ControlSizeMode.ActualSize Then
            FitPage(sizeMode = ControlSizeMode.FitWidth)
         Else
            If zoomPercent <> 0 Then
               SetViewerZoomPercentage(zoomPercent)
            End If
         End If

         _rasterImageViewer.ScrollOffset = LeadPoint.Empty
         _rasterImageViewer.EndUpdate()
      End Sub

      ''' <summary>
      ''' Called by the main form when the page number of the image is changed
      ''' </summary>
      Public Sub SetCurrentPageNumber(pageNumber As Integer, pageImage As RasterImage)
         _currentPageNumber = pageNumber

         Dim savedOptions As ImageViewerAutoResetOptions = _rasterImageViewer.AutoResetOptions
         _rasterImageViewer.AutoResetOptions = ImageViewerAutoResetOptions.None
         _rasterImageViewer.Image = pageImage
         _rasterImageViewer.AutoResetOptions = savedOptions

         If _isNewDocument Then
            ' Fit page when new document is set
            _isNewDocument = False
            FitPage(False)
         End If

         ' Build the page internal links
         _pageLinks = New List(Of PageLink)()

         ' Loop through the document internal links
         If _document IsNot Nothing Then
            ' Get the page
            Dim page As PDFDocumentPage = _document.Pages(_currentPageNumber - 1)

            If _document.InternalLinks IsNot Nothing Then
               For i As Integer = 0 To _document.InternalLinks.Count - 1
                  If _document.InternalLinks(i).SourcePageNumber = pageNumber Then
                     ' Our page
                     Dim link As New PageLink()
                     link.InternalLinkIndex = i
                     link.HyperLinkIndex = -1
                     ' The internal links bounds are in PDF page coordinates, not objects
                     link.ImageBounds = ToLeadRect(page.ConvertRect(PDFCoordinateType.Pdf, PDFCoordinateType.Pixel, _document.InternalLinks(i).SourceBounds))
                     _pageLinks.Add(link)
                  End If
               Next
            End If

            ' Now add all hyperlinks
            If page.Hyperlinks IsNot Nothing Then
               For i As Integer = 0 To page.Hyperlinks.Count - 1
                  Dim link As New PageLink()
                  link.HyperLinkIndex = i
                  link.InternalLinkIndex = -1
                  link.ImageBounds = ToLeadRect(page.ConvertRect(PDFCoordinateType.Pdf, PDFCoordinateType.Pixel, page.Hyperlinks(i).Bounds))
                  _pageLinks.Add(link)
               Next
            End If
         End If

         UpdatePageInfo()
         UpdateUIState()
      End Sub

      ''' <summary>
      ''' Called by the main form to change the page viewing mode (from the main menu)
      ''' </summary>
      Public Sub FitPage(fitWidth As Boolean)
         ' Since we are doing more than one operation on the viewer, it is
         ' recommended to disable then re-enable updates on the viewer to
         ' minimize flickering

         _rasterImageViewer.BeginUpdate()

         _rasterImageViewer.Zoom(ControlSizeMode.None, 1, _rasterImageViewer.DefaultZoomOrigin)

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
      Public Sub ZoomViewer(zoomOut As Boolean)
         ' Get the current scale factor
         Dim percentage As Double = _rasterImageViewer.XScaleFactor * 100.0

         ' The valid scale factors are here
         Dim validPercentages As Double() = {_minimumViewerScalePercentage, 6.25, 12.5, 25, 33.3, 50, _
          66.7, 73.6, 92.5, 100, 125, 150, _
          200, 300, 400, 600, 800, 1200, _
          1600, 2400, 3200, _maximumViewerScalePercentage}

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

      Public Sub DisableAllInteractiveModes(CurrentViewer As AutomationImageViewer)
         For Each mode As ImageViewerInteractiveMode In CurrentViewer.InteractiveModes
            mode.IsEnabled = False
         Next
      End Sub

      ''' <summary>
      ''' Current interactive mode (what happens when the user uses the mouse on the viewer)
      ''' </summary>
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public Property InteractiveMode() As ViewerControlInteractiveMode
         Get
            Return _interactiveMode
         End Get
         Set(value As ViewerControlInteractiveMode)
            _interactiveMode = value

            DisableAllInteractiveModes(RasterImageViewer)
            ' Set the RasterImageViewer interactive mode accordingly
            Select Case _interactiveMode
               Case ViewerControlInteractiveMode.SelectMode
                  automationInteractiveMode.IsEnabled = True
                  RasterImageViewer.InteractiveModes.EnableById(automationInteractiveMode.Id)
                  Exit Select

               Case ViewerControlInteractiveMode.HighlightTextMode
                  RectangleInteractiveMode.IsEnabled = True
                  RasterImageViewer.InteractiveModes.EnableById(RectangleInteractiveMode.Id)
                  Exit Select

               Case ViewerControlInteractiveMode.PanMode
                  PanInteractiveMode.IsEnabled = True
                  RasterImageViewer.InteractiveModes.EnableById(PanInteractiveMode.Id)
                  Exit Select

               Case ViewerControlInteractiveMode.ZoomToSelectionMode
                  ZoomToInteractiveMode.IsEnabled = True
                  RasterImageViewer.InteractiveModes.EnableById(ZoomToInteractiveMode.Id)
                  Exit Select
            End Select

            RaiseEvent InteractiveModeChanged(Me, EventArgs.Empty)

            UpdateUIState()
         End Set
      End Property

      Public Event InteractiveModeChanged As EventHandler

      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public Property HighlightObjects() As Boolean
         Get
            Return _highlightObjectsToolStripButton.Checked
         End Get
         Set(value As Boolean)
            _highlightObjectsToolStripButton.Checked = value
            _rasterImageViewer.Invalidate()
         End Set
      End Property

      ''' <summary>
      ''' This event is fired by the control when an action occurs that must be handled by
      ''' the owner (the main form)
      ''' </summary>
      Public Event Action As EventHandler(Of ActionEventArgs)
#End Region

#Region "Viewer"
      Private Sub InitViewer()
         ' Use ScaleToGray and Bicubic for optimum viewing of black/white and color images
         Dim props As RasterPaintProperties = _rasterImageViewer.PaintProperties
         props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray Or RasterPaintDisplayModeFlags.Bicubic
         _rasterImageViewer.PaintProperties = props

         ' Pad the viewer
         Dim tempPadding As Padding = _rasterImageViewer.Padding
         tempPadding.All = 16
         _rasterImageViewer.Padding = tempPadding

         _rasterImageViewer.ViewMargin = Padding.Empty
         _rasterImageViewer.ImageBorderThickness = 0
         Dim dropShadow As ControlDropShadowOptions = _rasterImageViewer.ImageDropShadow
         dropShadow.IsVisible = False
         _rasterImageViewer.ImageDropShadow = dropShadow
         ' Set the cursors
         NoneInteractiveMode.WorkingCursor = InlineAssignHelper(NoneInteractiveMode.IdleCursor, Cursors.Arrow)
         PanInteractiveMode.WorkingCursor = InlineAssignHelper(PanInteractiveMode.IdleCursor, Cursors.Hand)
         ZoomToInteractiveMode.WorkingCursor = InlineAssignHelper(ZoomToInteractiveMode.IdleCursor, Cursors.Cross)
         RegionInteractiveMode.WorkingCursor = InlineAssignHelper(RegionInteractiveMode.IdleCursor, Cursors.Cross)
         RectangleInteractiveMode.WorkingCursor = InlineAssignHelper(RectangleInteractiveMode.IdleCursor, Cursors.Cross)
      End Sub

      Private Sub _rasterImageViewer_PostRender(sender As Object, e As ImageViewerRenderEventArgs) Handles _rasterImageViewer.PostRender
         Dim page As PDFDocumentPage = _document.Pages(_currentPageNumber - 1)
         If _selectedText IsNot Nothing AndAlso _selectedText(_currentPageNumber) IsNot Nothing Then
            HighlightSelectedWords(e.PaintEventArgs.Graphics)
         End If

         If HighlightObjects AndAlso _document IsNot Nothing Then
            Dim data As New HighlightObjectsData()
            data.TextBrush = New SolidBrush(Color.FromArgb(128, Color.Yellow))
            data.RetangleBrush = New SolidBrush(Color.FromArgb(128, Color.Black))
            data.ImageBrush = New SolidBrush(Color.FromArgb(128, Color.Red))
            data.HyperlinkBrush = New SolidBrush(Color.FromArgb(128, Color.Blue))
            data.InternalLinkBrush = New SolidBrush(Color.FromArgb(128, Color.Green))

            DrawHighlightObjects(e.PaintEventArgs.Graphics, data, page)
            DrawLegends(e.PaintEventArgs.Graphics, data)

            data.TextBrush.Dispose()
            data.RetangleBrush.Dispose()
            data.ImageBrush.Dispose()
            data.HyperlinkBrush.Dispose()
            data.InternalLinkBrush.Dispose()
         End If

         If _highlightSelectedImageObject AndAlso Not HighlightObjects Then
            Using imageBrush As Brush = New SolidBrush(Color.FromArgb(128, Color.Red))
               DrawHighlightImageObject(e.PaintEventArgs.Graphics, imageBrush, page)
            End Using
         End If
      End Sub

      Private Sub _rasterImageViewer_TransformChanged(sender As Object, e As EventArgs) Handles _rasterImageViewer.TransformChanged
         If IsHandleCreated AndAlso Not DesignMode Then
            UpdateZoomValueFromControl()
            UpdateUIState()
         End If
      End Sub

      Private Sub RectangleInteractiveMode_RubberBandCompleted(sender As Object, e As ImageViewerRubberBandEventArgs)
         Dim pixels As New Rectangle(e.InteractiveEventArgs.Origin.X, e.InteractiveEventArgs.Origin.Y, e.InteractiveEventArgs.Position.X - e.InteractiveEventArgs.Origin.X, e.InteractiveEventArgs.Position.Y - e.InteractiveEventArgs.Origin.Y)

         If pixels.Left > pixels.Right Then
            pixels = Rectangle.FromLTRB(pixels.Right, pixels.Top, pixels.Left, pixels.Bottom)
         End If
         If pixels.Top > pixels.Bottom Then
            pixels = Rectangle.FromLTRB(pixels.Left, pixels.Bottom, pixels.Right, pixels.Top)
         End If

         If pixels.Width > 2 AndAlso pixels.Height > 2 Then
            Dim pixelsF As RectangleF = pixels


            Dim mm As LeadMatrix = _rasterImageViewer.GetImageTransformWithDpi(True)
            Dim m As New Matrix(CSng(mm.M11), CSng(mm.M12), CSng(mm.M21), CSng(mm.M22), CSng(mm.OffsetX), CSng(mm.OffsetY))
            Dim trans As New Transformer(m)
            pixelsF = trans.RectangleToLogical(pixelsF)


            pixelsF = RectangleF.Intersect(New RectangleF(0, 0, _rasterImageViewer.Image.ImageWidth, _rasterImageViewer.Image.ImageHeight), pixelsF)
            pixels = Rectangle.Round(pixelsF)

            Dim bounds As New LeadRect(pixels.X, pixels.Y, pixels.Width, pixels.Height)
            BeginInvoke(New DoActionDelegate(AddressOf DoAction), New Object() {"HighlightText", bounds})
         End If

         ' Go back to selection mode
         ' We must invoke this because the select button will change the
         ' interactive mode of the viewer and hence, cancel the current
         ' operation
         BeginInvoke(New MethodInvoker(AddressOf DoSelectMode))
      End Sub

      Private Sub ZoomToInteractiveMode_WorkCompleted(sender As Object, e As EventArgs)
         ' Go back to selection mode
         ' We must invoke this because the select button will change the
         ' interactive mode of the viewer and hence, cancel the current
         ' operation
         BeginInvoke(New MethodInvoker(AddressOf DoSelectMode))
      End Sub

      Private Sub _rasterImageViewer_MouseMove(sender As Object, e As MouseEventArgs) Handles _rasterImageViewer.MouseMove
         Dim str As String = [String].Empty

         Dim image As RasterImage = _rasterImageViewer.Image
         If image IsNot Nothing Then
            Dim pixels As LeadPoint = PhysicalToLogical(New LeadPoint(e.X, e.Y))

            If pixels.X >= 0 AndAlso pixels.X <= image.ImageWidth AndAlso pixels.Y >= 0 AndAlso pixels.Y <= image.ImageHeight Then
               str = String.Format("{0},{1} px", CInt(pixels.X), CInt(pixels.Y))
            End If

            _mousePositionLabel.Text = str

            If InteractiveMode = ViewerControlInteractiveMode.HighlightTextMode OrElse InteractiveMode = ViewerControlInteractiveMode.SelectMode Then
               ' See if we are over a hyper or internal link
               If _document IsNot Nothing AndAlso _pageLinks IsNot Nothing Then
                  Dim overLink As Boolean = False

                  For Each link As PageLink In _pageLinks
                     ' We pre-calculated the link bounds in image coordinates
                     If link.ImageBounds.Contains(pixels) Then
                        ' Yes, change cursor to Hand
                        _rasterImageViewer.Cursor = Cursors.Hand
                        overLink = True
                        Exit For
                     End If
                  Next

                  If Not overLink Then
                     _rasterImageViewer.Cursor = Cursors.[Default]
                  End If
               End If
            End If
         End If
      End Sub

      Private _highlightSelectedImageObject As Boolean = False
      Public Property HighlightSelectedImageObject() As Boolean
         Get
            Return _highlightSelectedImageObject
         End Get
         Set(value As Boolean)
            _highlightSelectedImageObject = value
         End Set
      End Property

      Private _selectedPdfImageObject As New PDFObject()
      Private Sub _rasterImageViewer_MouseDown(sender As Object, e As MouseEventArgs) Handles _rasterImageViewer.MouseDown
         _highlightSelectedImageObject = False
         Dim pixels As LeadPoint = PhysicalToLogical(New LeadPoint(e.X, e.Y))

         Try
            If e.Button = MouseButtons.Right Then
               Dim pdfImageObject As PDFObject = HitTestPDFImageObject(pixels)
               Dim pdfImageObjectBounds As LeadRect = ToLeadRect(pdfImageObject.Bounds)
               If Not pdfImageObjectBounds.IsEmpty Then
                  _selectedPdfImageObject = pdfImageObject

                  ' Highlight image object
                  _highlightSelectedImageObject = True

                  ' User right clicked on valid PDF image object, so show context menu to allow him/her to save image
                  Dim cm As New ContextMenu()
                  cm.MenuItems.Add(New MenuItem("&Save As...", AddressOf _pdfObject_SavePDFImageObjectAs))
                  Me.ContextMenu = cm
               Else
                  Me.ContextMenu = Nothing
                  _highlightSelectedImageObject = False
               End If
            Else
               If InteractiveMode = ViewerControlInteractiveMode.HighlightTextMode OrElse InteractiveMode = ViewerControlInteractiveMode.SelectMode Then
                  ' See if we are over a hyper or internal link
                  If _document IsNot Nothing AndAlso _pageLinks IsNot Nothing Then
                     For Each link As PageLink In _pageLinks

                        ' We pre-calculated the link bounds in image coordinates
                        If link.ImageBounds.Contains(pixels) Then
                           If link.HyperLinkIndex <> -1 Then
                              Dim hyperlink As PDFHyperlink = _document.Pages(_currentPageNumber - 1).Hyperlinks(link.HyperLinkIndex)
                              DoAction("GotoHyperlink", hyperlink)
                           ElseIf link.InternalLinkIndex <> -1 Then
                              Dim internalLink As PDFInternalLink = _document.InternalLinks(link.InternalLinkIndex)
                              DoAction("GotoInternalLink", internalLink)
                           End If
                        End If
                     Next
                  End If
               End If
            End If
         Finally
            _rasterImageViewer.Invalidate()
         End Try
      End Sub

      Private Sub _pdfObject_SavePDFImageObjectAs(sender As Object, e As EventArgs)
         Dim saver As New ImageFileSaver()
         Try
            Dim image As RasterImage = _document.DecodeImage(_selectedPdfImageObject.ImageObjectNumber)
            Using codecs As New RasterCodecs()
               DemosGlobal.SetDefaultComments(image, codecs)
               saver.Save(Me, codecs, image)
            End Using
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, saver.FileName, ex)
         End Try
      End Sub

      Private Function HitTestPDFImageObject(pt As LeadPoint) As PDFObject
         Dim retObject As New PDFObject()

         Dim page As PDFDocumentPage = _document.Pages(_currentPageNumber - 1)
         If page.Objects IsNot Nothing AndAlso page.Objects.Count > 0 Then
            For Each obj As PDFObject In page.Objects
               If obj.ObjectType = PDFObjectType.Image Then
                  Dim tempPDFRect As PDFRect = page.ConvertRect(PDFCoordinateType.Pdf, PDFCoordinateType.Pixel, obj.Bounds)
                  Dim objectRect As LeadRect = ToLeadRect(tempPDFRect)
                  If objectRect.Contains(pt) Then
                     ' Point in rect then user pressed over image object, so return it.
                     retObject = obj
                     Exit For
                  End If
               End If
            Next
         End If

         Return retObject
      End Function

      Private Function PhysicalToLogical(physical As LeadPoint) As LeadPoint
         Dim pixelsF As New PointF(physical.X, physical.Y)
         Dim mm As LeadMatrix = _rasterImageViewer.GetImageTransformWithDpi(True)
         Dim m As New Matrix(CSng(mm.M11), CSng(mm.M12), CSng(mm.M21), CSng(mm.M22), CSng(mm.OffsetX), CSng(mm.OffsetY))
         Dim trans As New Transformer(m)
         pixelsF = trans.PointToLogical(pixelsF)

         Dim pixels As Point = Point.Round(pixelsF)
         Return New LeadPoint(pixels.X, pixels.Y)
      End Function

      Private Structure HighlightObjectsData
         Public TextBrush As Brush
         Public RetangleBrush As Brush
         Public ImageBrush As Brush
         Public HyperlinkBrush As Brush
         Public InternalLinkBrush As Brush
      End Structure

      Private Sub _rasterImageViewer_PostImagePaint(sender As Object, e As PaintEventArgs)
         If _selectedText IsNot Nothing AndAlso _selectedText(_currentPageNumber) IsNot Nothing Then
            HighlightSelectedWords(e.Graphics)
         End If

         If HighlightObjects AndAlso _document IsNot Nothing Then
            Dim page As PDFDocumentPage = _document.Pages(_currentPageNumber - 1)

            Dim data As New HighlightObjectsData()
            data.TextBrush = New SolidBrush(Color.FromArgb(128, Color.Yellow))
            data.RetangleBrush = New SolidBrush(Color.FromArgb(128, Color.Black))
            data.ImageBrush = New SolidBrush(Color.FromArgb(128, Color.Red))
            data.HyperlinkBrush = New SolidBrush(Color.FromArgb(128, Color.Blue))
            data.InternalLinkBrush = New SolidBrush(Color.FromArgb(128, Color.Green))

            DrawHighlightObjects(e.Graphics, data, page)
            DrawLegends(e.Graphics, data)

            data.TextBrush.Dispose()
            data.RetangleBrush.Dispose()
            data.ImageBrush.Dispose()
            data.HyperlinkBrush.Dispose()
            data.InternalLinkBrush.Dispose()
         End If
      End Sub

      Private Sub HighlightSelectedWords(g As Graphics)
         Dim words As MyWord() = _selectedText(_currentPageNumber)

         ' Highlight the selected words
         Using brush As Brush = New SolidBrush(Color.FromArgb(128, SystemColors.Highlight))
            Dim mm As LeadMatrix = _rasterImageViewer.GetImageTransformWithDpi(True)
            Dim m As New Matrix(CSng(mm.M11), CSng(mm.M12), CSng(mm.M21), CSng(mm.M22), CSng(mm.OffsetX), CSng(mm.OffsetY))
            Dim trans As New Transformer(m)

            ' Clip to the current image bounds
            Dim clipRect As New RectangleF(0, 0, _rasterImageViewer.Image.ImageWidth, _rasterImageViewer.Image.ImageHeight)
            clipRect = trans.RectangleToPhysical(clipRect)
            g.SetClip(clipRect)

            Dim lineBounds As LeadRect = LeadRect.Empty

            For Each word As MyWord In words
               ' Get the word boundaries
               If lineBounds.IsEmpty Then
                  lineBounds = word.Bounds
               Else
                  lineBounds = LeadRect.Union(lineBounds, word.Bounds)
               End If

               If word.IsEndOfLine Then
                  ' Highlight this line
                  HighlightLine(g, trans, brush, lineBounds)
                  lineBounds = LeadRect.Empty
               End If
            Next

            If Not lineBounds.IsEmpty Then
               HighlightLine(g, trans, brush, lineBounds)
            End If
         End Using
      End Sub

      Private Shared Sub HighlightLine(g As Graphics, trans As Transformer, brush As Brush, bounds As LeadRect)
         ' Convert to physical coordinates
         Dim rc As New RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height + 4)
         rc = trans.RectangleToPhysical(rc)

         g.FillRectangle(brush, rc)
      End Sub

      Private Shared Function ToLeadRect(rect As PDFRect) As LeadRect
         Return LeadRect.FromLTRB(CInt(rect.Left), CInt(rect.Top), CInt(rect.Right), CInt(rect.Bottom))
      End Function

      Private Shared Function ToRectangleF(rect As PDFRect) As RectangleF
         Dim rc As RectangleF = RectangleF.FromLTRB(CSng(rect.Left), CSng(rect.Top), CSng(rect.Right), CSng(rect.Bottom))
         rc.Inflate(2, 2)
         Return rc
      End Function

      Private Shared Sub DrawRectangle(g As Graphics, brush As Brush, rc As RectangleF)
         g.FillRectangle(brush, rc)
         g.DrawRectangle(Pens.Black, rc.X, rc.Y, rc.Width, rc.Height)
      End Sub

      Private Sub DrawHighlightObjects(g As Graphics, data As HighlightObjectsData, page As PDFDocumentPage)

         Dim mm As LeadMatrix = _rasterImageViewer.GetImageTransformWithDpi(True)
         Dim m As New Matrix(CSng(mm.M11), CSng(mm.M12), CSng(mm.M21), CSng(mm.M22), CSng(mm.OffsetX), CSng(mm.OffsetY))
         Dim trans As New Transformer(m)

         ' Clip to the current image bounds
         Dim clipRect As New RectangleF(0, 0, _rasterImageViewer.Image.ImageWidth, _rasterImageViewer.Image.ImageHeight)
         clipRect = trans.RectangleToPhysical(clipRect)
         g.SetClip(clipRect)

         ' Draw objects
         If page.Objects IsNot Nothing Then
            For Each obj As PDFObject In page.Objects
               Dim rc As RectangleF = ToRectangleF(page.ConvertRect(PDFCoordinateType.Pdf, PDFCoordinateType.Pixel, obj.Bounds))
               rc = trans.RectangleToPhysical(rc)

               ' Highlight it
               Dim brush As Brush

               If obj.ObjectType = PDFObjectType.Image Then
                  brush = data.ImageBrush
               ElseIf obj.ObjectType = PDFObjectType.Rectangle Then
                  brush = data.RetangleBrush
               Else
                  brush = data.TextBrush
               End If

               DrawRectangle(g, brush, rc)
            Next
         End If

         ' Draw internal and hyper links
         For Each link As PageLink In _pageLinks
            Dim rc As RectangleF = trans.RectangleToPhysical(New RectangleF(link.ImageBounds.X, link.ImageBounds.Y, link.ImageBounds.Width, link.ImageBounds.Height))

            Dim brush As Brush
            If link.InternalLinkIndex <> -1 Then
               brush = data.InternalLinkBrush
            Else
               brush = data.HyperlinkBrush
            End If

            DrawRectangle(g, brush, rc)
         Next

      End Sub

      Private Sub DrawLegends(g As Graphics, data As HighlightObjectsData)
         Dim textSize As SizeF = g.MeasureString("WWW", Font)
         Dim rc As New RectangleF(0, 0, _rasterImageViewer.ClientRectangle.Width, textSize.Height)
         g.FillRectangle(Brushes.White, rc)
         g.DrawString("Legends: ", Font, Brushes.Black, 0, 0)

         Dim x As Single = g.MeasureString("Legends: ", Font).Width + 1

         Dim texts As String() = {"Text", "Retangle", "Image", "Hyperlink", "InternalLink"}

         Dim brushes__1 As Brush() = {data.TextBrush, data.RetangleBrush, data.ImageBrush, data.HyperlinkBrush, data.InternalLinkBrush}

         rc.Inflate(-1, -2)
         rc.Width = rc.Height

         For i As Integer = 0 To texts.Length - 1
            rc.X = x

            DrawRectangle(g, brushes__1(i), rc)
            x += rc.Width + 1

            g.DrawString(texts(i), Font, Brushes.Black, x, 1)
            x += g.MeasureString(texts(i), Font).Width + 8
         Next
      End Sub

      Private Sub DrawHighlightImageObject(g As Graphics, imageBrush As Brush, page As PDFDocumentPage)
         Dim mm As LeadMatrix = _rasterImageViewer.GetImageTransformWithDpi(True)
         Dim m As New Matrix(CSng(mm.M11), CSng(mm.M12), CSng(mm.M21), CSng(mm.M22), CSng(mm.OffsetX), CSng(mm.OffsetY))
         Dim trans As New Transformer(m)

         ' Clip to the current image bounds
         Dim clipRect As New RectangleF(0, 0, _rasterImageViewer.Image.ImageWidth, _rasterImageViewer.Image.ImageHeight)
         clipRect = trans.RectangleToPhysical(clipRect)
         g.SetClip(clipRect)

         ' Draw image object
         Dim rc As RectangleF = ToRectangleF(page.ConvertRect(PDFCoordinateType.Pdf, PDFCoordinateType.Pixel, _selectedPdfImageObject.Bounds))
         If Not rc.IsEmpty Then
            rc = trans.RectangleToPhysical(rc)

            ' Highlight it
            DrawRectangle(g, imageBrush, rc)
         End If
      End Sub
#End Region

#Region "UI"
      Private Sub UpdateUIState()
         ' Update the UI controls states

         _fitPageWidthToolStripButton.Checked = _rasterImageViewer.SizeMode = ControlSizeMode.FitWidth
         _fitPageToolStripButton.Checked = _rasterImageViewer.SizeMode = ControlSizeMode.FitAlways

         _selectModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.SelectMode
         _highlightTextModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.HighlightTextMode
         _panModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.PanMode
         _zoomToSelectionModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode

         If _document IsNot Nothing Then
            If Not _toolStrip.Enabled Then
               _toolStrip.Enabled = True
            End If

            Dim pageNumber As Integer = _currentPageNumber
            Dim pageCount As Integer = _document.Pages.Count

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
                                          If _document IsNot Nothing Then
                                             Dim factor As Double = _rasterImageViewer.ScaleFactor * 100.0
                                             _zoomToolStripComboBox.Text = factor.ToString("F1") & "%"
                                          Else
                                             _zoomToolStripComboBox.Text = String.Empty
                                          End If
                                       End Sub
      ))

      End Sub

      Private Sub _previousPageToolStripButton_Click(sender As Object, e As EventArgs) Handles _previousPageToolStripButton.Click
         TryGotoPage(_currentPageNumber - 1)
      End Sub

      Private Sub _nextPageToolStripButton_Click(sender As Object, e As EventArgs) Handles _nextPageToolStripButton.Click
         TryGotoPage(_currentPageNumber + 1)
      End Sub

      Private Sub _pageToolStripTextBox_LostFocus(sender As Object, e As EventArgs)
         _pageToolStripTextBox.Text = _currentPageNumber.ToString()
      End Sub

      Private Sub _pageToolStripTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _pageToolStripTextBox.KeyPress
         If e.KeyChar = CChar(Microsoft.VisualBasic.ChrW(Keys.Return)) Then
            ' User has pressed enter, go to the new page number

            Dim str As String = _pageToolStripTextBox.Text.Trim()

            ' Try to parse the integer value
            Dim pageNumber As Integer
            If Integer.TryParse(str, pageNumber) Then
               TryGotoPage(pageNumber)
            End If

            _pageToolStripTextBox.Text = _currentPageNumber.ToString()
         End If
      End Sub

      Private Sub TryGotoPage(pageNumber As Integer)
         ' Check if the page number is valid
         If _document IsNot Nothing AndAlso pageNumber >= 1 AndAlso pageNumber <= _document.Pages.Count Then
            ' Yes, fire the event to the main form
            DoAction("PageNumberChanged", pageNumber)
         End If
      End Sub

      Private Sub _zoomOutToolStripButton_Click(sender As Object, e As EventArgs) Handles _zoomOutToolStripButton.Click
         ZoomViewer(True)
      End Sub

      Private Sub _zoomInToolStripButton_Click(sender As Object, e As EventArgs) Handles _zoomInToolStripButton.Click
         ZoomViewer(False)
      End Sub

      Private Sub _zoomToolStripComboBox_LostFocus(sender As Object, e As EventArgs)
         UpdateZoomValueFromControl()
      End Sub

      Private Sub _zoomToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _zoomToolStripComboBox.SelectedIndexChanged
         ' Parse the new zoom value
         Dim str As String = _zoomToolStripComboBox.Text.Trim()

         Select Case str
            Case "Actual Size"
               SetViewerZoomPercentage(100)
               Exit Select

            Case "Fit Page"
               FitPage(False)
               Exit Select

            Case "Fit Width"
               FitPage(True)
               Exit Select
            Case Else

               If Not String.IsNullOrEmpty(str) Then
                  Dim val As Double = Double.Parse(str.Substring(0, str.Length - 1))
                  SetViewerZoomPercentage(val)
               End If
               Exit Select
         End Select
      End Sub

      Private Sub _zoomToolStripComboBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _zoomToolStripComboBox.KeyPress
         If e.KeyChar = CChar(Microsoft.VisualBasic.ChrW(Keys.Return)) Then
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

      Private Sub SetViewerZoomPercentage(percentage As Double)
         ' Normalize the percentage based on min/max value allowed
         percentage = Math.Max(_minimumViewerScalePercentage, Math.Min(_maximumViewerScalePercentage, percentage))

         If Math.Abs(_rasterImageViewer.ScaleFactor * 100.0 - percentage) > 0.01 Then
            ' Save the current center location in the viewer, we will use it later to
            ' re-center the viewer

            Dim LeadPhysicalViewRectangle As LeadRectD = _rasterImageViewer.GetItemViewBounds(_rasterImageViewer.ActiveItem, ImageViewerItemPart.Image, True)
            Dim LeadLogicalViewRectangle As LeadRectD = _rasterImageViewer.GetItemBounds(_rasterImageViewer.ActiveItem, ImageViewerItemPart.Image)

            Dim PhysicalViewRectangle As New Rectangle(CInt(LeadPhysicalViewRectangle.Left), CInt(LeadPhysicalViewRectangle.Top), CInt(LeadPhysicalViewRectangle.Width), CInt(LeadPhysicalViewRectangle.Height))
            Dim LogicalViewRectangle As New Rectangle(CInt(LeadLogicalViewRectangle.Left), CInt(LeadLogicalViewRectangle.Top), CInt(LeadLogicalViewRectangle.Width), CInt(LeadLogicalViewRectangle.Height))

            Dim rc As Rectangle = Rectangle.Intersect(PhysicalViewRectangle, LogicalViewRectangle)
            Dim center As New PointF(rc.Left + rc.Width \ 2, rc.Top + rc.Right \ 2)

            Dim LeadM As LeadMatrix = _rasterImageViewer.ImageTransform
            Dim M As New Matrix(CSng(LeadM.M11), CSng(LeadM.M12), CSng(LeadM.M21), CSng(LeadM.M22), CSng(LeadM.OffsetX), CSng(LeadM.OffsetY))
            Dim trans As New Transformer(M)
            center = trans.PointToLogical(center)

            _rasterImageViewer.BeginUpdate()

            ' Switch to normal size mode if we are not in it
            If _rasterImageViewer.SizeMode <> ControlSizeMode.ActualSize Then
               _rasterImageViewer.Zoom(ControlSizeMode.ActualSize, 1, _rasterImageViewer.DefaultZoomOrigin)
            End If

            ' Zoom
            _rasterImageViewer.Zoom(ControlSizeMode.None, percentage / 100.0, _rasterImageViewer.DefaultZoomOrigin)

            ' Go back to original center point
            LeadM = _rasterImageViewer.ImageTransform
            M = New Matrix(CSng(LeadM.M11), CSng(LeadM.M12), CSng(LeadM.M21), CSng(LeadM.M22), CSng(LeadM.OffsetX), CSng(LeadM.OffsetY))
            trans.Transform = M
            center = trans.PointToPhysical(center)

            _rasterImageViewer.CenterAtPoint(LeadPoint.Create(CInt(Math.Truncate(center.X)), CInt(Math.Truncate(center.Y))))

            _rasterImageViewer.EndUpdate()

            _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty)

            UpdateUIState()
         End If
      End Sub

      Private Sub _fitPageWidthToolStripButton_Click(sender As Object, e As EventArgs) Handles _fitPageWidthToolStripButton.Click
         FitPage(True)
      End Sub

      Private Sub _fitPageToolStripButton_Click(sender As Object, e As EventArgs) Handles _fitPageToolStripButton.Click
         FitPage(False)
      End Sub

      Private Sub _selectModeToolStripButton_Click(sender As Object, e As EventArgs) Handles _selectModeToolStripButton.Click
         DoSelectMode()
      End Sub

      Private Sub DoSelectMode()
         InteractiveMode = ViewerControlInteractiveMode.SelectMode
      End Sub

      Private Sub _highlightTextModeToolStripButton_Click(sender As Object, e As EventArgs) Handles _highlightTextModeToolStripButton.Click
         InteractiveMode = ViewerControlInteractiveMode.HighlightTextMode
      End Sub

      Private Sub _panModeToolStripButton_Click(sender As Object, e As EventArgs) Handles _panModeToolStripButton.Click
         InteractiveMode = ViewerControlInteractiveMode.PanMode
      End Sub

      Private Sub _zoomToSelectionModeToolStripButton_Click(sender As Object, e As EventArgs) Handles _zoomToSelectionModeToolStripButton.Click
         InteractiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode
      End Sub

      Private Sub _highlightObjectsToolStripButton_Click(sender As Object, e As EventArgs) Handles _highlightObjectsToolStripButton.Click
         HighlightObjects = Not HighlightObjects
      End Sub
      Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
         target = value
         Return value
      End Function
#End Region
   End Class
End Namespace
