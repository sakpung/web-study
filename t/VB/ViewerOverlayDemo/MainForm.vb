' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Text
Imports System.IO
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Drawing
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.Demos.Dialogs

Public Class MainForm
   ' This is overlay rectangle in image coordinates
   Private _overlayRect As LeadRect

   ' If we are currently moving _overRect with the mouse
   Private _isMovingOverlayRect As Boolean

   ' This is the Interactive Mode to create the Overlay Rectangle
   Private rubberBandMode As ImageViewerRubberBandInteractiveMode

   ' This the original moving point, first point that was clicked
   Private _lastMovePoint As LeadPoint

   Private _drawOverlays As Boolean

   Private _openInitialPath As String = ""

   ''' <summary>
   ''' The main entry point for the application.
   ''' </summary>
   <STAThread()> _
   Shared Sub Main()
      
      If Not Support.SetLicense() Then
         Return
      End If

      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New MainForm())
   End Sub
   Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      ' Setup the caption for this demo
      Messager.Caption = "VB.NET Viewer Overlay Demo"
   End Sub

   Private Sub InitInteractiveModes()
      _imageViewer.InteractiveModes.BeginUpdate()
      _imageViewer.InteractiveModes.Clear()
      rubberBandMode = New ImageViewerRubberBandInteractiveMode()
      rubberBandMode.IdleCursor = Cursors.Cross
      rubberBandMode.WorkingCursor = Cursors.Cross
      rubberBandMode.Shape = ImageViewerRubberBandShape.Rectangle
      AddHandler rubberBandMode.RubberBandCompleted, AddressOf rubberBandMode_RubberBandCompleted
      rubberBandMode.IsEnabled = False
      _imageViewer.InteractiveModes.Add(rubberBandMode)
      _imageViewer.InteractiveModes.EndUpdate()
   End Sub

   Private Sub rubberBandMode_RubberBandCompleted(sender As Object, e As ImageViewerRubberBandEventArgs)
      ' User selected a new rectangle
      _overlayRect = _imageViewer.ConvertRect(
         Nothing,
         ImageViewerCoordinateType.Control,
         ImageViewerCoordinateType.Image,
         LeadRect.FromLTRB(e.Points(0).X, e.Points(0).Y, e.Points(1).X, e.Points(1).Y))

      ' We need to change the interactive mode back to "None"
      ResetInteractiveMode()
   End Sub




   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      If Not DesignMode Then
         For Each i As ControlAlignment In System.Enum.GetValues(GetType(ControlAlignment))
            _horizontalAlignmentComboBox.Items.Add(i)
            _verticalAlignmentComboBox.Items.Add(i)
         Next

         For Each i As ControlSizeMode In System.Enum.GetValues(GetType(ControlSizeMode))
            _sizeModeComboBox.Items.Add(i)
         Next

         _imageViewer.BorderStyle = BorderStyle.FixedSingle
         _imageViewer.UseDpi = True

         InitInteractiveModes()

         ' So we can track the mouse and show its position related to the viewer and the image
         AddHandler _imageViewer.MouseDown, AddressOf _ImageViewer_MouseDown
         AddHandler _imageViewer.MouseMove, AddressOf _ImageViewer_MouseMove
         AddHandler _imageViewer.MouseUp, AddressOf _ImageViewer_MouseUp
         AddHandler _imageViewer.LostFocus, AddressOf _ImageViewer_LostFocus

         ' So we can draw our overlays
         AddHandler _imageViewer.PostRender, AddressOf _imageViewer_PostRender

         Dim defaultImageFileName As String = Path.Combine(DemosGlobal.ImagesFolder, "Ocr1.tif")
         LoadImage(defaultImageFileName)

         ReadMe(True)
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _imageViewer_PostRender(sender As Object, e As ImageViewerRenderEventArgs)
      Dim image As RasterImage = _imageViewer.Image

      If (image Is Nothing Or _overlayRect.IsEmpty) Then
         ' No image or the overlay rectangle hasn't been set yet
         Return
      End If
      ' Convert the overlay rectangle (it is in image coordinates) to viewer coordinates
      Dim imageRect As LeadRect = LeadRect.Create(_overlayRect.X, _overlayRect.Y, _overlayRect.Width, _overlayRect.Height)
      ' We must pass false for 'accountForViewPerspective' in this case because _overlayRect is always
      ' in top-left coordinates in this demo
      Dim viewerRect As LeadRect = _imageViewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, imageRect)

      If Not (viewerRect.IsEmpty) Then
         ' Otherwise, we zoomed out too much and it is too small to paint
         Dim g As Graphics = e.PaintEventArgs.Graphics
         Dim Brush = New SolidBrush(Color.FromArgb(128, Color.Black))
         Dim rect As Rectangle = Rectangle.FromLTRB(viewerRect.Left, viewerRect.Top, viewerRect.Right, viewerRect.Bottom)
         g.FillRectangle(Brush, rect)
         g.DrawRectangle(Pens.Yellow, viewerRect.X, viewerRect.Y, viewerRect.Width - 1, viewerRect.Height - 1)

      End If

   End Sub




   Protected Overrides Sub OnFormClosed(ByVal e As System.Windows.Forms.FormClosedEventArgs)
      RemoveHandler _imageViewer.LostFocus, AddressOf _ImageViewer_LostFocus
      RemoveHandler _imageViewer.MouseDown, AddressOf _ImageViewer_MouseDown
      RemoveHandler _imageViewer.MouseMove, AddressOf _ImageViewer_MouseMove
      RemoveHandler _imageViewer.MouseUp, AddressOf _ImageViewer_MouseUp
      RemoveHandler _imageViewer.PostRender, AddressOf _imageViewer_PostRender

      MyBase.OnFormClosed(e)
   End Sub


   Private Sub _openToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _openToolStripMenuItem.Click
      Using dlg As New OpenFileDialog()
         dlg.Filter = "All Files|*.*"
         dlg.InitialDirectory = _openInitialPath

         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _openInitialPath = Path.GetDirectoryName(dlg.FileName)
            LoadImage(dlg.FileName)
         End If
      End Using

   End Sub

   Private Sub _closeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _closeToolStripMenuItem.Click
      LoadImage(Nothing)
   End Sub

   Private Sub _exitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _exitToolStripMenuItem.Click
      Close()
   End Sub

   Private Sub _aboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _aboutToolStripMenuItem.Click
      Using aboutDialog As New AboutDialog("Viewer Overlay", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _readMeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _readMeToolStripMenuItem.Click
      ReadMe(False)
   End Sub

   Private Sub ReadMe(ByVal showHint As Boolean)
      Dim sb As New StringBuilder()

      sb.AppendLine("This demo lets you draw a rectangle on top of the RasterImageViewer control in image coordinates and use the mouse cursor to drag it.")
      sb.AppendLine()
      sb.AppendLine("The purpose of this demo is to show how to map points and rectangles from viewer to client coordinates and back. Also, how to transform these coordinates to actual pixel coordinates in the image regardless of the view perspective.")
      sb.AppendLine()
      sb.AppendLine("The demo uses the following methods to achieve that:")
      sb.AppendLine("RasterImageViewer.ViewerToImageRectangle")
      sb.AppendLine("RasterImageViewer.ImageToViewerRectangle")
      sb.AppendLine("RasterImageViewer.ViewerToImagePoint")
      sb.AppendLine("RasterImageViewer.ImageToViewerPoint")
      sb.AppendLine("RasterImage.RectangleToImage")
      sb.AppendLine("RasterImage.RectangleFromImage")
      sb.AppendLine()
      sb.AppendLine("Make sure an image is loaded, then click the 'Draw overlay rectangle' button to an overlay rectangle. You can then use the mouse to click on it and move it around the image.")
      sb.AppendLine()
      sb.AppendLine("Click the 'Fast rotate' buttons to rotate the image using its own view perspective, notice how everything is calculated correctly and the overlay rectangle should rotate with the image.")
      sb.AppendLine()
      sb.AppendLine("Click the 'Invert image under overlay rectangle' button to invert the image under the current overlay rectangle.")
      sb.AppendLine()
      sb.AppendLine("You can use the controls in 'Viewer Properties' group box to change the scroll, zoom, size mode and alignment of the image viewer.")

      If showHint Then
         sb.AppendLine()
         sb.AppendLine("Select 'Help/Read me' from the menu to show this dialog box again.")
      End If

      Messager.ShowInformation(Me, sb.ToString())
   End Sub

   Private Sub LoadImage(ByVal fileName As String)
      Dim newImage As RasterImage = Nothing

      ' Try to load the new image
      If Not IsNothing(fileName) Then
         Try
            Using codecs As New RasterCodecs()
               Using wait As New WaitCursor()
                  newImage = codecs.Load(fileName, 0, CodecsLoadByteOrder.BgrOrGray, 1, 1)
               End Using
            End Using

         Catch ex As Exception
            Messager.ShowFileOpenError(Me, fileName, ex)
            Return
         End Try
      End If

      _overlayRect = LeadRect.Empty
      _imageViewer.Image = newImage

      If Not IsNothing(fileName) Then
         Text = String.Format("{0} - {1}", Messager.Caption, fileName)
      Else
         Text = Messager.Caption
      End If

      UpdateImageInfo()
      UpdateUIState()
   End Sub

   Private Shared Function GetRasterViewPerspectiveName(ByVal value As RasterViewPerspective) As String
      Select Case value
         Case RasterViewPerspective.TopLeft
            Return "TopLeft"
         Case RasterViewPerspective.TopRight
            Return "TopRight"
         Case RasterViewPerspective.BottomRight
            Return "BottomRight"
         Case RasterViewPerspective.BottomLeft
            Return "BottomLeft"
         Case RasterViewPerspective.LeftTop
            Return "LeftTop"
         Case RasterViewPerspective.RightTop
            Return "RightTop"
         Case RasterViewPerspective.RightBottom
            Return "RightBottom"
         Case RasterViewPerspective.LeftBottom
            Return "LeftBottom"
         Case Else
            Throw New ArgumentException("Invalid view perspective")
      End Select
   End Function

   Private Sub UpdateImageInfo()
      Dim image As RasterImage = _imageViewer.Image

      If Not IsNothing(image) Then
         Dim xResolution As Double
         If (image.XResolution > 0) Then
            xResolution = image.XResolution
         Else
            xResolution = 96
         End If
         Dim yResolution As Double
         If (image.YResolution > 0) Then
            yResolution = image.YResolution
         Else
            yResolution = 96
         End If

         Dim widthInches As Double = CType(image.ImageWidth / xResolution, Double)
         Dim heightInches As Double = CType(image.ImageHeight / yResolution, Double)

         _imageInfoLabel.Text = String.Format( _
            "Size: {0} by {1} px ({2} by {3} in), Resolution: {4} by {5} dpi, View perspective: {6}", _
            image.ImageWidth, image.ImageHeight, _
            widthInches.ToString("F02"), heightInches.ToString("F02"), _
            image.XResolution, image.YResolution, _
            GetRasterViewPerspectiveName(image.ViewPerspective))
      Else
         _imageInfoLabel.Text = String.Empty
      End If
   End Sub

   Private Sub UpdateUIState()
      _leftPanel.Enabled = Not IsNothing(_imageViewer.Image)
      _bottomPanel.Enabled = Not IsNothing(_imageViewer.Image)

      _useDpiCheckBox.Checked = _imageViewer.UseDpi
      _paddingCheckBox.Checked = (_imageViewer.ViewPadding.All <> 0)
      _horizontalAlignmentComboBox.SelectedItem = _imageViewer.ViewHorizontalAlignment
      _verticalAlignmentComboBox.SelectedItem = _imageViewer.ViewVerticalAlignment
      _sizeModeComboBox.Text = (CType(_imageViewer.SizeMode, ControlSizeMode).ToString)
      _zoomValueLabel.Text = String.Format("Current zoom value: {0}%", ((_imageViewer.ScaleFactor * 100.0)))
      _drawOverlayRectangleButton.Enabled = Not rubberBandMode.IsEnabled
      _invertImageUnderOverlayRectButton.Enabled = Not _overlayRect.IsEmpty
   End Sub

   Private Sub _useDpiCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _useDpiCheckBox.CheckedChanged
      _imageViewer.UseDpi = _useDpiCheckBox.Checked
      UpdateUIState()
   End Sub

   Private Sub _paddingCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _paddingCheckBox.CheckedChanged
      If (_imageViewer.ViewPadding.All = 0) Then
         _imageViewer.ViewPadding = New Padding(8)
      Else
         _imageViewer.ViewPadding = New Padding(0)
      End If

      UpdateUIState()
   End Sub

   Private Sub _zoomNoneButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zoomNoneButton.Click
      ZoomViewer(1.0)
   End Sub

   Private Sub _zoomInButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zoomInButton.Click
      ZoomViewer(_imageViewer.ScaleFactor * 1.2)
   End Sub

   Private Sub _zoomOutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zoomOutButton.Click
      ZoomViewer(_imageViewer.ScaleFactor / 1.2)
   End Sub

   Private Sub ZoomViewer(ByVal value As Double)
      ' zoom         
      ' We will do zoom/center, so save the current center in logical units
      ' get what you see in physical coordinates
      Dim LeadPhysicalViewRectangle As LeadRect = _imageViewer.ViewBounds

      Dim PhysicalViewRectangle As Rectangle = New Rectangle(LeadPhysicalViewRectangle.X, LeadPhysicalViewRectangle.Y, LeadPhysicalViewRectangle.Width, LeadPhysicalViewRectangle.Height)
      Dim LogicalViewRectangle As Rectangle = _imageViewer.ClientRectangle

      Dim rc As Rectangle = Rectangle.Intersect(PhysicalViewRectangle, LogicalViewRectangle)

      ' get the center of what you see in physical coordinates
      Dim center As PointF = New PointF(CSng(rc.Left + rc.Width / 2), CSng(rc.Top + rc.Height / 2))

      Dim m As LeadMatrix = _imageViewer.GetImageTransformWithDpi(_imageViewer.UseDpi)
      Dim mm As Matrix = New Matrix(CSng(m.M11), CSng(m.M12), CSng(m.M21), CSng(m.M22), CSng(m.OffsetX), CSng(m.OffsetY))
      Dim t As Transformer = New Transformer(mm)
      ' get the center of what you see in logical coordinates
      center = t.PointToLogical(center)
      ' zoom
      Dim minimumScaleFactor As Double = 0.05
      Dim maximumScaleFactor As Double = 11

      Dim scaleFactor As Double = Math.Max(minimumScaleFactor, Math.Min(maximumScaleFactor, value))
      If Not (_imageViewer.ScaleFactor = scaleFactor) Then
         _imageViewer.Zoom(ControlSizeMode.None, scaleFactor, _imageViewer.DefaultZoomOrigin)
         ' bring the original center into the view center
         m = _imageViewer.GetImageTransformWithDpi(_imageViewer.UseDpi)
         mm = New Matrix(CSng(m.M11), CSng(m.M12), CSng(m.M21), CSng(m.M22), CSng(m.OffsetX), CSng(m.OffsetY))
         t = New Transformer(mm)
         ' get the center of what you saw before the zoom in physical coordinates
         center = t.PointToPhysical(center)
         ' bring the old center into the center of the view
         _imageViewer.CenterAtPoint(LeadPoint.Create(CInt(center.X), CInt(center.Y)))
         UpdateUIState()
      End If
   End Sub

   Private Sub _horizontalAlignmentComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _horizontalAlignmentComboBox.SelectedIndexChanged
      _imageViewer.ViewHorizontalAlignment = CType(_horizontalAlignmentComboBox.SelectedItem, ControlAlignment)
      UpdateUIState()
   End Sub

   Private Sub _verticalAlignmentComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _verticalAlignmentComboBox.SelectedIndexChanged
      _imageViewer.ViewVerticalAlignment = CType(_verticalAlignmentComboBox.SelectedItem, ControlAlignment)
      UpdateUIState()
   End Sub

   Private Sub _sizeModeComboBox_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles _sizeModeComboBox.SelectionChangeCommitted
      Dim sizeMode As ControlSizeMode = CType(_sizeModeComboBox.SelectedItem, ControlSizeMode)
      _imageViewer.Zoom(sizeMode, 1, _imageViewer.DefaultZoomOrigin)
      UpdateUIState()
   End Sub

   Private Sub _ImageViewer_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
      Dim image As RasterImage = _imageViewer.Image

      If (image Is Nothing Or rubberBandMode.IsEnabled) Then
         ' Nothing for us to do
         Return
      End If

      If _isMovingOverlayRect Then
         ' Previously moving the rectangle, end the move operation
         EndMovingOverlayRect()
      End If

      If Not _overlayRect.IsEmpty AndAlso e.Button = MouseButtons.Left Then
         ' Check if we are on the overlay rect. Get current mouse position
         ' in image coordinates. Using TopLeft since the overlay rect is in
         ' TopLeft always
         Dim viewerPoint As LeadPoint = LeadPoint.Create(e.X, e.Y)
         Dim imagePoint As LeadPoint = _imageViewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, viewerPoint)

         If _overlayRect.Contains(imagePoint.X, imagePoint.Y) Then
            ' Yes, start moving 
            _lastMovePoint = viewerPoint
            _isMovingOverlayRect = True

            ' Optional: clip the cursor to not move outside the image bounds
            Dim imageRect As New LeadRect(0, 0, image.ImageWidth, image.ImageHeight)
            Dim viewerRect As LeadRect = _imageViewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, imageRect)
            ' Note, the above returns the same value as _ImageViewer.PhysicalViewRectangle
            Dim clipRect As Rectangle = Rectangle.Intersect(Rectangle.FromLTRB(viewerRect.Left, viewerRect.Top, viewerRect.Right, viewerRect.Bottom), _imageViewer.ClientRectangle)
            Cursor.Clip = _imageViewer.RectangleToScreen(clipRect)
            _imageViewer.Capture = True
         End If
      End If
   End Sub

   Private Sub _ImageViewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
      Dim image As RasterImage = _imageViewer.Image

      If IsNothing(image) Then
         Return
      End If

      ' Here is the point in viewer (physical or client) coordinates
      ' This point is the mouse position
      Dim viewerPoint As New LeadPoint(e.X, e.Y)

      ' Convert to image coordinates (top-left view perspective, since we are
      ' only interested in the zoom/scroll values and not trying to get to a
      ' certain pixel in the image data)
      Dim imagePoint As LeadPoint = _imageViewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, viewerPoint)

      ShowMousePositionAndImageColor(image, viewerPoint, imagePoint)

      If _isMovingOverlayRect Then
         ' We are moving the overlay rect

         ' After we are done with moving the overlay rect to a new position,
         ' we need to re-paint to show the effect. To optimize the code, we will
         ' only repaint the combination of the old and new rects

         ' Get the current (soon to be old) overlay rect in viewer coordinates
         Dim oldImageRect As New LeadRect(_overlayRect.X, _overlayRect.Y, _overlayRect.Width, _overlayRect.Height)
         Dim oldViewerRect As LeadRect = _imageViewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, oldImageRect)

         ' Get the difference
         Dim dx As Integer = e.X - _lastMovePoint.X
         Dim dy As Integer = e.Y - _lastMovePoint.Y

         If dx <> 0 OrElse dy <> 0 Then
            ' Has moved

            Dim newViewerRect As LeadRect = oldViewerRect
            newViewerRect.Offset(dx, dy)

            ' Now re-calculate new overlay rectangle in image coordinates
            Dim newImageRect As LeadRect = _imageViewer.ConvertRect(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, newViewerRect)

            ' Make sure the image rectangle does not go outside the image boundaries
            If newImageRect.X < 0 Then
               newImageRect.Offset(-newImageRect.X, 0)
            End If
            If newImageRect.Y < 0 Then
               newImageRect.Offset(0, -newImageRect.Y)
            End If
            If (newImageRect.X + newImageRect.Width) > image.ImageWidth Then
               newImageRect.Offset(-(newImageRect.X + newImageRect.Width - image.ImageWidth), 0)
            End If
            If (newImageRect.Y + newImageRect.Height) > image.ImageHeight Then
               newImageRect.Offset(0, -(newImageRect.Y + newImageRect.Height - image.ImageHeight))
            End If

            ' Check if it has really changed
            If newImageRect.X <> oldImageRect.X OrElse _
               newImageRect.Y <> oldImageRect.Y OrElse _
               newImageRect.Width <> oldImageRect.Width OrElse _
               newImageRect.Height <> oldImageRect.Height Then
               ' Yes
               _overlayRect = New LeadRect(newImageRect.X, newImageRect.Y, newImageRect.Width, newImageRect.Height)

               ' Re-paint the old and new rectangles
               _imageViewer.Invalidate()
            End If

            ' Save the new moving position
            _lastMovePoint = LeadPoint.Create(e.X, e.Y)
         End If
      End If
   End Sub

   Private Sub _ImageViewer_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
      If _isMovingOverlayRect Then
         EndMovingOverlayRect()
      End If
   End Sub

   Private Sub _ImageViewer_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      If _isMovingOverlayRect Then
         EndMovingOverlayRect()
      End If
   End Sub

   Private Sub EndMovingOverlayRect()
      _imageViewer.Capture = False
      _isMovingOverlayRect = False
      Cursor.Clip = Rectangle.Empty
   End Sub

   Private Sub ShowMousePositionAndImageColor(ByVal image As RasterImage, ByVal viewerPoint As LeadPoint, ByVal imagePoint As LeadPoint)
      ' This point is now in image coordinates, i.e., 0,0 is the top-left area of the image
      ' Since we passed 'false' to 'accountForViewPerspective' above, the point is what we see
      ' if the data in the image is top-left (point 0, 0, is the most left-top point in the image data)
      ' This is called the ViewPerspective of the image. Not all images supported by LEADTOOLS have top-left coordinates,
      ' for example, when you load a BMP file, by the default, the image data is "flipped" and has a view perspective of
      ' bottom-left. We could pass 'true' for images like that if we need to convert the point to the
      ' actual pixel x, y in the image. We will do that later in the code below

      Dim imagePointText As String
      Dim outside As Boolean = False

      ' Check if the viewer point is outside the image coordinates
      If imagePoint.X < 0 OrElse imagePoint.Y < 0 OrElse imagePoint.X > image.ImageWidth OrElse imagePoint.Y > image.ImageHeight Then
         outside = True
      End If

      If outside Then
         ' Outside
         imagePointText = "OUTSIDE"
      Else
         imagePointText = String.Format("{0}, {1}", imagePoint.X, imagePoint.Y)
      End If

      ' Show both points
      _mousePositionLabel.Text = String.Format( _
         "Viewer: {0}, {1} - Image: {2}", _
         viewerPoint.X, viewerPoint.Y, _
         imagePointText)

      ' Get the color under the cursor

      Dim pointCursorColor As RasterColor

      ' Use the imagePoint, we will use Raster.GetPixel. This method except the points
      ' to be in image coordinates and in the image view perspective.
      ' Since we had the point in top-left (by not passing true to accountForViewPerspective),
      ' we must convert it to image coordinate first using RasterImage.PointToImage
      If Not outside Then
         Dim colorPoint As New LeadPoint(imagePoint.X, imagePoint.Y)
         colorPoint = image.PointToImage(RasterViewPerspective.TopLeft, colorPoint)

         ' GetPixel takes row/column, or Y and X
         pointCursorColor = image.GetPixel(colorPoint.Y, colorPoint.X)
      Else
         ' Either outside the image or we do not have an image
         pointCursorColor = RasterColor.FromKnownColor(RasterKnownColor.Transparent)
      End If

      _cursorColorValueLabel.Text = pointCursorColor.ToString()
      _colorCursorPanel.BackColor = RasterColorConverter.ToColor(pointCursorColor)

      ' Finally, if we are not drawing an interactive user rectangle and the cursor is over the
      ' overlay rect, change its shape to a Hand

      If Not (rubberBandMode.IsEnabled) Then
         If (Not _overlayRect.IsEmpty) And (_overlayRect.Contains(imagePoint.X, imagePoint.Y)) Then
            _imageViewer.Cursor = Cursors.Hand
         Else
            _imageViewer.Cursor = Cursors.Default
         End If
      End If
   End Sub

   Private Sub ResetInteractiveMode()
      ' Set the interactive mode back to None
      _imageViewer.InteractiveModes.BeginUpdate()
      rubberBandMode.IsEnabled = False
      _imageViewer.InteractiveModes.EndUpdate()
      ' To enable/disable controls
      UpdateUIState()
      ' Re-paint
      _imageViewer.Invalidate()
   End Sub

   Private Sub _invertImageUnderOverlayRectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _invertImageUnderOverlayRectButton.Click
      Dim image As RasterImage = _imageViewer.Image

      ' Add the overlay rect as a region to the image

      ' The overlay rect is in image coordinates already but it is at top-left
      ' view perspective, the image might not be. If you load a BMP file or click
      ' the fast rotate buttons, you will notice this.

      ' We can do one of two things:

      ' 1. Use RasterRegionXForm to tell the AddRectangleToRegion method the
      ' rect passed is in TopLeft:
      '
      ' RasterRegionXForm xForm = RasterRegionXForm.Default
      ' xForm.ViewPerspective = RasterViewPerspective.TopLeft
      ' image.AddRectangleToRegion(xForm, _overlayRect, RasterRegionCombineMode.Set)
      '

      ' RasterRegionXForm is a matrix that allows you to perform many more actions,
      ' such as transform the rectangle from any coordinates to another.

      ' 2. Use RasterImage.RectangleToImage to convert the rect from TopLeft
      ' to the view perspective of the image:
      Dim dataRect As LeadRect = image.RectangleToImage(RasterViewPerspective.TopLeft, _overlayRect)
      image.AddRectangleToRegion(Nothing, dataRect, RasterRegionCombineMode.Set)

      Dim cmd As New InvertCommand()
      cmd.Run(image)

      ' Remove the region
      image.MakeRegionEmpty()
   End Sub

   Private Sub _fastRotate90ClockwiseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fastRotate90ClockwiseButton.Click
      Rotate(90)
   End Sub

   Private Sub _fastRotate90CounterClockwiseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fastRotate90CounterClockwiseButton.Click
      Rotate(-90)
   End Sub

   Private Sub Rotate(ByVal angle As Integer)
      Dim image As RasterImage = _imageViewer.Image

      ' We must rotate our overlay rect too. We could rotate it ourselves or we could do this:
      ' Get the rect in image coordinates (regardless of the view persective)
      ' Rotate the image
      ' Get the rect again in top-left from the image coordinates we saved

      Dim imageRect As LeadRect = LeadRect.Empty

      If Not _overlayRect.IsEmpty Then
         ' Save the overlay rect in image coordinates
         imageRect = image.RectangleToImage(RasterViewPerspective.TopLeft, _overlayRect)
      End If

      If RasterSupport.IsLocked(RasterSupportType.Document) Then
         MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
      End If

      ' Fast rotation involves changing the image view-perspective
      image.RotateViewPerspective(angle)

      If Not _overlayRect.IsEmpty Then
         ' Now re-get the overlay rectangle as top left from the image data coordinates
         ' we saved
         _overlayRect = image.RectangleFromImage(RasterViewPerspective.TopLeft, imageRect)
      End If

      UpdateImageInfo()
   End Sub

   Private Sub _drawOverlayRectangleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _drawOverlayRectangleButton.Click
      ' Start the interactive mode
      _imageViewer.InteractiveModes.BeginUpdate()
      rubberBandMode.IsEnabled = True
      _imageViewer.InteractiveModes.EndUpdate()
      UpdateUIState()
   End Sub
End Class
