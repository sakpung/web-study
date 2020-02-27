' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Collections
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Controls

Imports Leadtools.Drawing

Friend Enum ViewerRubberBandingHelperMode
   Draw
   Move
   Resize
End Enum

Friend Enum ViewerRubberBandingControlPoint
   TopLeft
   TopRight
   BottomRight
   BottomLeft
   Inside
End Enum

Friend Class ViewerRubberBandingHelperEventArgs : Inherits EventArgs
   Private _bounds As Rectangle
   Private _mode As ViewerRubberBandingHelperMode

   Friend Sub New(ByVal bounds_Renamed As Rectangle, ByVal mode_Renamed As ViewerRubberBandingHelperMode)
      _bounds = bounds_Renamed
      _mode = mode_Renamed
   End Sub

   Public ReadOnly Property Mode() As ViewerRubberBandingHelperMode
      Get
         Return _mode
      End Get
   End Property

   ' The rubberband rectangle in image coordinates (pixels)
   Public ReadOnly Property Bounds() As Rectangle
      Get
         Return _bounds
      End Get
   End Property
End Class

' Helper class to uncapsulate drawing a rubberband on a RasterImageViewer
Friend Class ViewerRubberBandingHelper : Implements IDisposable
   ' The viewer we are drawing on
   Private _viewer As ImageViewer
   ' Are we currently rubber banding
   Private _isRubberBanding As Boolean
   ' The current rubber band rectangle
   Private _rubberBandingRectangle As Rectangle
   ' Flag to indicates if the rubber band rectangle is drawn
   Private _isRubberBandingRectangleDrawn As Boolean
   ' Did we clip the cursor?
   Private _saveClipRectangle As Rectangle
   Private _started As Boolean
   Private _enableAutomation As Boolean
   Private _resizeCorner As ViewerRubberBandingControlPoint
   Private _mode As ViewerRubberBandingHelperMode
   Private _originalMovePoint As Point
   Private _containerRectangle As Rectangle
   Private _rectangles As List(Of Rectangle)
   Private _selRectangleIndex As Integer

   Public Event RubberBand As EventHandler(Of ViewerRubberBandingHelperEventArgs)

   Public Sub New()
      _rectangles = New List(Of Rectangle)()
      _enableAutomation = True
   End Sub

   Public Sub Dispose() Implements IDisposable.Dispose
      Dispose(True)
      System.GC.SuppressFinalize(Me)
   End Sub

   Protected Overrides Sub Finalize()
      Dispose(True)
   End Sub

   Private Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not _rectangles Is Nothing Then
            _rectangles.Clear()

            ' Un-subclass to the events
            If Not _viewer Is Nothing Then
               RemoveHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
               RemoveHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
               RemoveHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
               RemoveHandler _viewer.LostFocus, AddressOf _viewer_LostFocus
            End If
         End If
      End If
   End Sub

   Public Sub Start()
      _mode = ViewerRubberBandingHelperMode.Draw
      _viewer.Focus()

      _started = True
   End Sub

   Private Sub StartResize(ByVal rect As Rectangle, ByVal corner As ViewerRubberBandingControlPoint)
      _mode = ViewerRubberBandingHelperMode.Resize

      _resizeCorner = corner
      _started = True
      _viewer.Focus()

      ' Start the rubber banding
      BeginRubberBanding(rect)
   End Sub

   Private Sub StartMove(ByVal rect As Rectangle)
      _mode = ViewerRubberBandingHelperMode.Move

      _started = True
      _viewer.Focus()

      ' Start the rubber banding
      BeginRubberBanding(rect)
   End Sub

   Public Sub [Stop]()
      _isRubberBanding = False
      _rubberBandingRectangle = Rectangle.Empty
      _isRubberBandingRectangleDrawn = False
      _saveClipRectangle = Rectangle.Empty
      _started = False

      ClipCursor(False)
   End Sub

   ' Begins the rubber banding operation
   Private Sub BeginRubberBanding(ByVal rect As Rectangle)
      _rubberBandingRectangle = rect
      _containerRectangle = Rectangle.Empty

      _isRubberBanding = True
      _viewer.Capture = True

      ' Clip the cursor
      ClipCursor(True)

      DrawRubberBandRectangle()
   End Sub

   ' Ends the rubber banding
   Private Sub EndRubberBanding()
      _viewer.Capture = False
      _isRubberBanding = False

      If _isRubberBandingRectangleDrawn Then
         DrawRubberBandRectangle()
      End If
   End Sub

   Private Sub ClipCursor(ByVal clip As Boolean)
      If clip Then
         Dim rect As Rectangle = Rectangle.Intersect(FixRectangle(_viewer.DisplayRectangle), _viewer.ClientRectangle)
         rect = _viewer.RectangleToScreen(rect)
         Dim parent As Control = _viewer.Parent
         Do While Not parent Is Nothing
            rect = Rectangle.Intersect(rect, _viewer.Parent.RectangleToScreen(_viewer.Parent.ClientRectangle))
            If TypeOf parent Is Form Then
               Dim form As Form = CType(IIf(TypeOf parent Is Form, parent, Nothing), Form)
               If form.IsMdiChild Then
                  If Not form.Owner Is Nothing Then
                     rect = Rectangle.Intersect(rect, form.Owner.RectangleToScreen(form.Owner.ClientRectangle))
                  ElseIf Not form.Parent Is Nothing Then
                     rect = Rectangle.Intersect(rect, form.Parent.RectangleToScreen(form.Parent.ClientRectangle))
                  End If
               End If
            End If

            parent = parent.Parent
         Loop

         rect.Height += 1
         rect.Width += 1

         _saveClipRectangle = Cursor.Clip
         Cursor.Clip = rect
      Else
         Cursor.Clip = _saveClipRectangle
         _saveClipRectangle = Rectangle.Empty
      End If
   End Sub

   Private Shared Function FixRectangle(ByVal rect As Rectangle) As Rectangle
      If rect.Left > rect.Right Then
         rect = Rectangle.FromLTRB(rect.Right, rect.Top, rect.Left, rect.Bottom)
      End If
      If rect.Top > rect.Bottom Then
         rect = Rectangle.FromLTRB(rect.Left, rect.Bottom, rect.Right, rect.Top)
      End If

      Return rect
   End Function

   ' Draws the rubberband rectangle on the viewer
   Private Sub DrawRubberBandRectangle()
      Dim rect As Rectangle = FixRectangle(_rubberBandingRectangle)
      rect.Width += 1
      rect.Height += 1
      rect = _viewer.RectangleToScreen(rect)
      ControlPaint.DrawReversibleFrame(rect, Color.Transparent, FrameStyle.Thick)

      _isRubberBandingRectangleDrawn = Not _isRubberBandingRectangleDrawn
   End Sub

   Private Sub _viewer_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
      If _viewer Is Nothing OrElse (Not _started) Then
         Return
      End If

      _viewer.Focus()

      ' Cancel rubber banding if it is on
      If _isRubberBanding AndAlso e.Button <> MouseButtons.Left Then
         EndRubberBanding()
      Else
         If _viewer.HasImage AndAlso e.Button = MouseButtons.Left Then
            ' See if we click is on the image
            Dim rect As Rectangle = _viewer.DisplayRectangle
            If rect.Contains(e.X, e.Y) Then
               Dim testPoint As Point = New Point(e.X, e.Y)
               _selRectangleIndex = GetSelectedRectangleIndex()
               If _selRectangleIndex >= 0 Then ' There is a selected rectangle
                  Dim controlPoint As ViewerRubberBandingControlPoint = GetCursorPos(testPoint)
                  If controlPoint <> ViewerRubberBandingControlPoint.TopLeft AndAlso controlPoint <> ViewerRubberBandingControlPoint.TopRight AndAlso controlPoint <> ViewerRubberBandingControlPoint.BottomRight AndAlso controlPoint <> ViewerRubberBandingControlPoint.BottomLeft AndAlso controlPoint <> ViewerRubberBandingControlPoint.Inside Then
                     ' the user pressed outside the selected rectangle boundaries, so deselect the selected rectangle.
                     _selRectangleIndex = -1
                     _containerRectangle = Rectangle.Empty
                  End If
               End If

               ' Check if there is any rectangle where the user pressed then select it (unless it's already selected).
               Dim index As Integer = HitTestRubberBandRectangle(testPoint)
               If index >= 0 AndAlso index <> _selRectangleIndex Then
                  _selRectangleIndex = index
                  _containerRectangle = _rectangles(_selRectangleIndex)
               End If

               If _selRectangleIndex >= 0 AndAlso _enableAutomation Then
                  Dim controlPoint As ViewerRubberBandingControlPoint = GetCursorPos(testPoint)
                  If controlPoint = ViewerRubberBandingControlPoint.TopLeft OrElse controlPoint = ViewerRubberBandingControlPoint.TopRight OrElse controlPoint = ViewerRubberBandingControlPoint.BottomRight OrElse controlPoint = ViewerRubberBandingControlPoint.BottomLeft Then
                     StartResize(_containerRectangle, controlPoint)
                  ElseIf controlPoint = ViewerRubberBandingControlPoint.Inside Then ' Move
                     ' Save the first point position to use it to offset the rubber band rectangle
                     ' when the mode is "Move".
                     _originalMovePoint = testPoint

                     StartMove(_containerRectangle)
                  Else
                     ' Start the rubber banding
                     BeginRubberBanding(Rectangle.FromLTRB(e.X, e.Y, e.X, e.Y))
                  End If
               Else
                  _selRectangleIndex = -1
                  ' Start the rubber banding
                  BeginRubberBanding(Rectangle.FromLTRB(e.X, e.Y, e.X, e.Y))
               End If
            End If
         End If
      End If
   End Sub

   Private Function HitTestRubberBandRectangle(ByVal pt As Point) As Integer
      Dim i As Integer = 0
      Do While i < _rectangles.Count
         If _rectangles(i).Contains(pt) Then
            Return i
         End If
         i += 1
      Loop

      Return -1
   End Function

   Private Sub _viewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
      ' Change the mouse cursor when hovering over the selected rectangle
      ChangeMouseCursor(New Point(e.X, e.Y))

      If _isRubberBanding Then
         DrawRubberBandRectangle()

         Select Case _mode
            Case ViewerRubberBandingHelperMode.Draw
               _rubberBandingRectangle = Rectangle.FromLTRB(_rubberBandingRectangle.Left, _rubberBandingRectangle.Top, e.X, e.Y)

            Case ViewerRubberBandingHelperMode.Resize
               Select Case _resizeCorner
                  Case ViewerRubberBandingControlPoint.TopLeft
                     _rubberBandingRectangle = Rectangle.FromLTRB(e.X, e.Y, _rubberBandingRectangle.Right, _rubberBandingRectangle.Bottom)

                  Case ViewerRubberBandingControlPoint.TopRight
                     _rubberBandingRectangle = Rectangle.FromLTRB(_rubberBandingRectangle.Left, e.Y, e.X, _rubberBandingRectangle.Bottom)

                  Case ViewerRubberBandingControlPoint.BottomRight
                     _rubberBandingRectangle = Rectangle.FromLTRB(_rubberBandingRectangle.Left, _rubberBandingRectangle.Top, e.X, e.Y)

                  Case ViewerRubberBandingControlPoint.BottomLeft
                     _rubberBandingRectangle = Rectangle.FromLTRB(e.X, _rubberBandingRectangle.Top, _rubberBandingRectangle.Right, e.Y)
               End Select

            Case ViewerRubberBandingHelperMode.Move
               _rubberBandingRectangle.Offset(e.X - _originalMovePoint.X, e.Y - _originalMovePoint.Y)
               _originalMovePoint.X = e.X
               _originalMovePoint.Y = e.Y
         End Select

         DrawRubberBandRectangle()
      End If
   End Sub

   Private Sub _viewer_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
      ClipCursor(False)

      If _isRubberBanding Then
         ' Save the rubberband rectangle
         Dim rect As Rectangle = _rubberBandingRectangle

         EndRubberBanding()

         ' Fire the event
         If Not RubberBandEvent Is Nothing Then
            ' First, convert the rectangle to image coordinates
            rect = FixRectangle(rect)

            ' Must be at least 1 pixel in size
            If rect.Width > 1 AndAlso rect.Height > 1 Then
               _selRectangleIndex = GetSelectedRectangleIndex()
               If _rectangles.Count > 0 AndAlso _selRectangleIndex >= 0 AndAlso _rectangles.Count > _selRectangleIndex Then
                  _rectangles(_selRectangleIndex) = rect
               End If

               rect = Rectangle.Round(RectangleToLogical(rect))
               RaiseEvent RubberBand(Me, New ViewerRubberBandingHelperEventArgs(rect, _mode))
               _mode = ViewerRubberBandingHelperMode.Draw
            End If
         End If
      End If
   End Sub

   Private Function GetSelectedRectangleIndex() As Integer
      If _rectangles Is Nothing OrElse _containerRectangle = Nothing OrElse _containerRectangle.IsEmpty Then
         Return -1
      End If

      Dim i As Integer = 0
      Do While i < _rectangles.Count
         If _rectangles(i).Equals(_containerRectangle) Then
            Return i
         End If
         i += 1
      Loop

      Return -1
   End Function

   Private Sub _viewer_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      If _isRubberBanding Then
         EndRubberBanding()
      End If
   End Sub

   Public ReadOnly Property IsStarted() As Boolean
      Get
         Return _started
      End Get
   End Property

   Public ReadOnly Property Mode() As ViewerRubberBandingHelperMode
      Get
         Return _mode
      End Get
   End Property

   Public Property Viewer() As ImageViewer
      Get
         Return _viewer
      End Get
      Set(ByVal value As ImageViewer)
         If Not value Is Nothing Then
            _viewer = value
            AddHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
            AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
            AddHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
            AddHandler _viewer.LostFocus, AddressOf _viewer_LostFocus
         Else
            RemoveHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
            RemoveHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
            RemoveHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
            RemoveHandler _viewer.LostFocus, AddressOf _viewer_LostFocus

            _viewer = Nothing
         End If
      End Set
   End Property

   Public Function PointToLogical(ByVal pt As PointF) As PointF
      Dim transform As LeadMatrix = _viewer.GetImageTransformWithDpi(True)
      Try
         Dim t As Transformer = New Transformer(New Matrix(Convert.ToSingle(transform.M11), Convert.ToSingle(transform.M12), Convert.ToSingle(transform.M21), Convert.ToSingle(transform.M22), Convert.ToSingle(transform.OffsetX), Convert.ToSingle(transform.OffsetY)))
         Return t.PointToLogical(pt)
      Finally
         'CType(transform, IDisposable).Dispose()
      End Try
   End Function

   Public Function PointToPhysical(ByVal pt As PointF) As PointF
      Dim transform As LeadMatrix = _viewer.GetImageTransformWithDpi(True)
      Try
         Dim t As Transformer = New Transformer(New Matrix(Convert.ToSingle(transform.M11), Convert.ToSingle(transform.M12), Convert.ToSingle(transform.M21), Convert.ToSingle(transform.M22), Convert.ToSingle(transform.OffsetX), Convert.ToSingle(transform.OffsetY)))
         Return t.PointToPhysical(pt)
      Finally
         'CType(transform, IDisposable).Dispose()
      End Try
   End Function

   Public Function RectangleToLogical(ByVal rect As RectangleF) As RectangleF
      Dim transform As LeadMatrix = _viewer.GetImageTransformWithDpi(True)
      Try
         Dim t As Transformer = New Transformer(New Matrix(Convert.ToSingle(transform.M11), Convert.ToSingle(transform.M12), Convert.ToSingle(transform.M21), Convert.ToSingle(transform.M22), Convert.ToSingle(transform.OffsetX), Convert.ToSingle(transform.OffsetY)))
         Return t.RectangleToLogical(rect)
      Finally
         'CType(transform, IDisposable).Dispose()
      End Try
   End Function

   Public Function RectangleToPhysical(ByVal rect As RectangleF) As RectangleF
      Dim transform As LeadMatrix = _viewer.GetImageTransformWithDpi(True)
      Try
         Dim t As Transformer = New Transformer(New Matrix(Convert.ToSingle(transform.M11), Convert.ToSingle(transform.M12), Convert.ToSingle(transform.M21), Convert.ToSingle(transform.M22), Convert.ToSingle(transform.OffsetX), Convert.ToSingle(transform.OffsetY)))
         Return t.RectangleToPhysical(rect)
      Finally
         'CType(transform, IDisposable).Dispose()
      End Try
   End Function

   Public Property EnableAutomation() As Boolean
      Get
         Return _enableAutomation
      End Get
      Set(ByVal value As Boolean)
         _enableAutomation = value
      End Set
   End Property

   Public Sub DrawRectangle(ByVal g As Graphics, ByVal rect As Rectangle, ByVal rubberBandPen As Pen, ByVal containerPen As Pen, ByVal showControlPoints As Boolean)
      If (Not showControlPoints) Then
         g.DrawRectangle(rubberBandPen, rect)
      Else
         _containerRectangle = rect
         ' Draw the selected zone rectangle control points

         Dim controlPointRect1 As Rectangle = Rectangle.Empty
         Dim controlPointRect2 As Rectangle = Rectangle.Empty
         Dim controlPointRect3 As Rectangle = Rectangle.Empty
         Dim controlPointRect4 As Rectangle = Rectangle.Empty

         ' Set the control points coordinates
         controlPointRect1 = New Rectangle(rect.Left - 5, rect.Top - 5, 10, 10)
         controlPointRect2 = New Rectangle(rect.Right - 5, rect.Top - 5, 10, 10)
         controlPointRect3 = New Rectangle(rect.Left - 5, rect.Bottom - 5, 10, 10)
         controlPointRect4 = New Rectangle(rect.Right - 5, rect.Bottom - 5, 10, 10)

         Dim br As SolidBrush = New SolidBrush(containerPen.Color)
         Try
            g.DrawRectangle(containerPen, rect)
            g.FillRectangle(br, controlPointRect1)
            g.FillRectangle(br, controlPointRect2)
            g.FillRectangle(br, controlPointRect3)
            g.FillRectangle(br, controlPointRect4)
         Finally
            CType(br, IDisposable).Dispose()
         End Try
      End If
   End Sub

   Public Function GetCursorPos(ByVal pt As Point) As ViewerRubberBandingControlPoint
      Dim rc As Rectangle = GetLTSelCorner()
      If rc.Contains(pt) Then
         Return ViewerRubberBandingControlPoint.TopLeft
      End If

      rc = GetRTSelCorner()
      If rc.Contains(pt) Then
         Return ViewerRubberBandingControlPoint.TopRight
      End If

      rc = GetRBSelCorner()
      If rc.Contains(pt) Then
         Return ViewerRubberBandingControlPoint.BottomRight
      End If

      rc = GetLBSelCorner()
      If rc.Contains(pt) Then
         Return ViewerRubberBandingControlPoint.BottomLeft
      End If

      ' check if the point inside the selected zone 
      If _containerRectangle.Contains(pt) Then
         Return ViewerRubberBandingControlPoint.Inside
      End If

      Return CType(-1, ViewerRubberBandingControlPoint)
   End Function

   Private Function GetLTSelCorner() As Rectangle
      Return New Rectangle(_containerRectangle.Left - 5, _containerRectangle.Top - 5, 10, 10)
   End Function

   Private Function GetRTSelCorner() As Rectangle
      Return New Rectangle(_containerRectangle.Right - 5, _containerRectangle.Top - 5, 10, 10)
   End Function

   Private Function GetLBSelCorner() As Rectangle
      Return New Rectangle(_containerRectangle.Left - 5, _containerRectangle.Bottom - 5, 10, 10)
   End Function

   Private Function GetRBSelCorner() As Rectangle
      Return New Rectangle(_containerRectangle.Right - 5, _containerRectangle.Bottom - 5, 10, 10)
   End Function

   Private Sub ChangeMouseCursor(ByVal pt As Point)
      If (Not IsStarted) OrElse (Not _viewer.HasImage) Then
         _viewer.Cursor = Cursors.Default
         Return
      End If

      ' check if the point is outside the image boundaries then show the default cursor
      If _viewer.DisplayRectangle.Contains(pt) Then
         _viewer.Cursor = Cursors.Cross
      Else
         _viewer.Cursor = Cursors.Default
      End If

      If (Not _enableAutomation) Then
         Return
      End If

      Dim controlPoint As ViewerRubberBandingControlPoint = GetCursorPos(pt)

      Select Case controlPoint
         Case ViewerRubberBandingControlPoint.TopLeft, ViewerRubberBandingControlPoint.BottomRight
            _viewer.Cursor = Cursors.SizeNWSE

         Case ViewerRubberBandingControlPoint.TopRight, ViewerRubberBandingControlPoint.BottomLeft
            _viewer.Cursor = Cursors.SizeNESW

         Case ViewerRubberBandingControlPoint.Inside
            _viewer.Cursor = Cursors.NoMove2D

         Case Else
            Dim index As Integer = HitTestRubberBandRectangle(pt)
            If index >= 0 Then
               _viewer.Cursor = Cursors.Default
            Else
               ' check if the point is outside the image boundaries then show the default cursor
               If _viewer.DisplayRectangle.Contains(pt) Then
                  _viewer.Cursor = Cursors.Cross
               Else
                  _viewer.Cursor = Cursors.Default
               End If
            End If
      End Select
   End Sub

   Public ReadOnly Property Rectangles() As List(Of Rectangle)
      Get
         Return _rectangles
      End Get
   End Property

   Public Property ContainerRectangle() As Rectangle
      Get
         Return _containerRectangle
      End Get
      Set(ByVal value As Rectangle)
         _containerRectangle = value
      End Set
   End Property
End Class
