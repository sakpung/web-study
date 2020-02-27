' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Demos
Imports Leadtools.Drawing

Namespace MainDemo
   Partial Public Class ViewerForm : Inherits Form
      Public Sub New()
         InitializeComponent()
         Me.WindowState = FormWindowState.Maximized
         InitClass()
      End Sub

      Private _viewer As ImageViewer
      Private _name As String

      'Interactive Modes
      Dim _noneInteractiveMode As ImageViewerNoneInteractiveMode = Nothing
      Dim _floaterInteractiveMode As ImageViewerFloaterInteractiveMode = Nothing
      Dim _panInteractiveMode As ImageViewerPanZoomInteractiveMode = Nothing
      Dim _centerAtInteractiveMode As ImageViewerCenterAtInteractiveMode = Nothing
      Dim _zoomToInteractiveMode As ImageViewerZoomToInteractiveMode = Nothing
      Dim _scaleInteractiveMode As ImageViewerPanZoomInteractiveMode = Nothing
      Dim _pagerInteractiveMode As ImageViewerPagerInteractiveMode = Nothing
      Dim _magnifyGlassInteractiveMode As ImageViewerMagnifyGlassInteractiveMode = Nothing
      Dim _regionInteractiveMode As ImageViewerAddRegionInteractiveMode = Nothing
      Dim _rectangleInteractiveMode As ImageViewerRubberBandInteractiveMode = Nothing
      Dim _addMagicWandInteractivMode As ImageViewerAddMagicWandInteractivMode = Nothing

      'Interactive mode public methods
      Public Property NoneInteractiveMode As ImageViewerNoneInteractiveMode
         Get
            Return _noneInteractiveMode
         End Get
         Set(value As ImageViewerNoneInteractiveMode)
            _noneInteractiveMode = value
         End Set
      End Property

      Public Property FloaterInteractiveMode As ImageViewerFloaterInteractiveMode
         Get
            Return _floaterInteractiveMode
         End Get
         Set(value As ImageViewerFloaterInteractiveMode)
            _floaterInteractiveMode = value
         End Set
      End Property

      Public Property PanInteractiveMode As ImageViewerPanZoomInteractiveMode
         Get
            Return _panInteractiveMode
         End Get
         Set(value As ImageViewerPanZoomInteractiveMode)
            _panInteractiveMode = value
         End Set
      End Property
      
      Public Property CenterAtInteractiveMode As ImageViewerCenterAtInteractiveMode
         Get
            Return _centerAtInteractiveMode
         End Get
         Set(value As ImageViewerCenterAtInteractiveMode)
            _centerAtInteractiveMode = value
         End Set
      End Property

      Public Property AddMagicWandInteractivMode As ImageViewerAddMagicWandInteractivMode
         Get
            Return _addMagicWandInteractivMode
         End Get
         Set(value As ImageViewerAddMagicWandInteractivMode)
            _addMagicWandInteractivMode = value
         End Set
      End Property


      Public Property ZoomToInteractiveMode As ImageViewerZoomToInteractiveMode
         Get
            Return _zoomToInteractiveMode
         End Get
         Set(value As ImageViewerZoomToInteractiveMode)
            _zoomToInteractiveMode = value
         End Set
      End Property

      Public Property ScaleInteractiveMode As ImageViewerPanZoomInteractiveMode
         Get
            Return _scaleInteractiveMode
         End Get
         Set(value As ImageViewerPanZoomInteractiveMode)
            _scaleInteractiveMode = value
         End Set
      End Property
      
      Public Property PagerInteractiveMode As ImageViewerPagerInteractiveMode
         Get
            Return _pagerInteractiveMode
         End Get
         Set(value As ImageViewerPagerInteractiveMode)
            _pagerInteractiveMode = value
         End Set
      End Property

      Public Property MagnifyGlassInteractiveMode As ImageViewerMagnifyGlassInteractiveMode
         Get
            Return _magnifyGlassInteractiveMode
         End Get
         Set(value As ImageViewerMagnifyGlassInteractiveMode)
            _magnifyGlassInteractiveMode = value
         End Set
      End Property

      Public Property RegionInteractiveMode As ImageViewerAddRegionInteractiveMode
         Get
            Return _regionInteractiveMode
         End Get
         Set(value As ImageViewerAddRegionInteractiveMode)
            _regionInteractiveMode = value
         End Set
      End Property
      
      Public Property RectangleInteractiveMode As ImageViewerRubberBandInteractiveMode
         Get
            Return _rectangleInteractiveMode
         End Get
         Set(value As ImageViewerRubberBandInteractiveMode)
            _rectangleInteractiveMode = value
         End Set
      End Property

      Private Sub InitClass()
         _viewer = New ImageViewer()
         _viewer.Dock = DockStyle.Fill
         _viewer.BorderStyle = BorderStyle.None
         AddHandler _viewer.TransformChanged, AddressOf _viewer_TransformChanged
         AddHandler _viewer.DragEnter, AddressOf _viewer_DragEnter
         AddHandler _viewer.DragDrop, AddressOf _viewer_DragDrop
         AddHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
         AddHandler _viewer.KeyDown, AddressOf _viewer_KeyDown
         AddHandler _viewer.PropertyChanged, AddressOf _viewer_PropertyChanged
         _viewer.ViewHorizontalAlignment = ControlAlignment.Near
         _viewer.ViewVerticalAlignment = ControlAlignment.Near
         Controls.Add(_viewer)
         _viewer.BringToFront()
         _viewer.AllowDrop = True
         _viewer.ScrollMode = ControlScrollMode.Auto
         'Initialize Interactive modes
         InitializeInteractivemodes()
      End Sub

      Private Sub InitializeInteractivemodes()
         _viewer.InteractiveModes.BeginUpdate()
         'None
         NoneInteractiveMode = New ImageViewerNoneInteractiveMode()
         NoneInteractiveMode.IsEnabled = True
         _viewer.InteractiveModes.Add(NoneInteractiveMode)
         'Floater
         FloaterInteractiveMode = New ImageViewerFloaterInteractiveMode()
         FloaterInteractiveMode.EnablePan = True
         FloaterInteractiveMode.EnableZoom = False
         FloaterInteractiveMode.EnablePinchZoom = False
         FloaterInteractiveMode.WorkOnBounds = True
         FloaterInteractiveMode.FloaterRegionRenderMode = ControlRegionRenderMode.Animated
         _viewer.InteractiveModes.Add(FloaterInteractiveMode)
         'Pan
         PanInteractiveMode = New ImageViewerPanZoomInteractiveMode()
         PanInteractiveMode.EnablePan = True
         PanInteractiveMode.EnableZoom = False
         PanInteractiveMode.EnablePinchZoom = False
         PanInteractiveMode.WorkOnBounds = True
         _viewer.InteractiveModes.Add(PanInteractiveMode)
         'CenterAt         
         CenterAtInteractiveMode = New ImageViewerCenterAtInteractiveMode()
         CenterAtInteractiveMode.WorkOnBounds = True
         _viewer.InteractiveModes.Add(CenterAtInteractiveMode)
         'Add Magic Wand
         AddMagicWandInteractivMode = New ImageViewerAddMagicWandInteractivMode()
         AddMagicWandInteractivMode.Threshold = 100
         AddMagicWandInteractivMode.WorkOnBounds = True
         AddMagicWandInteractivMode.IsEnabled = False
         AddHandler AddMagicWandInteractivMode.WorkCompleted, AddressOf AddMagicWandInteractivMode_WorkCompleted
         _viewer.InteractiveModes.Add(AddMagicWandInteractivMode)
         'ZoomTo
         ZoomToInteractiveMode = New ImageViewerZoomToInteractiveMode()
         ZoomToInteractiveMode.WorkOnBounds = True
         ZoomToInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
         _viewer.InteractiveModes.Add(ZoomToInteractiveMode)
         'Scale
         ScaleInteractiveMode = New ImageViewerPanZoomInteractiveMode()
         ScaleInteractiveMode.ZoomKeyModifier = Keys.None
         ScaleInteractiveMode.EnablePan = False
         ScaleInteractiveMode.EnableZoom = True
         ScaleInteractiveMode.EnablePinchZoom = False
         ScaleInteractiveMode.WorkOnBounds = True
         _viewer.InteractiveModes.Add(ScaleInteractiveMode)
         'Pager
         PagerInteractiveMode = New ImageViewerPagerInteractiveMode()
         PagerInteractiveMode.WorkOnBounds = True
         _viewer.InteractiveModes.Add(PagerInteractiveMode)
         'MagnifyGlass
         MagnifyGlassInteractiveMode = New ImageViewerMagnifyGlassInteractiveMode()
         MagnifyGlassInteractiveMode.BorderPen = New Pen(Brushes.Red)
         MagnifyGlassInteractiveMode.Crosshair = ImageViewerSpyGlassCrosshair.Fine
         MagnifyGlassInteractiveMode.CrosshairPen = New Pen(Brushes.Red)
         MagnifyGlassInteractiveMode.WorkOnBounds = True
         _viewer.InteractiveModes.Add(MagnifyGlassInteractiveMode)
         'Region
         RegionInteractiveMode = New ImageViewerAddRegionInteractiveMode()
         RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
         RegionInteractiveMode.AutoRegionToFloater = True
         RegionInteractiveMode.WorkOnBounds = True
         RegionInteractiveMode.IsEnabled = False
         AddHandler RegionInteractiveMode.WorkCompleted, AddressOf RegionInteractiveMode_WorkCompleted
         _viewer.InteractiveModes.Add(RegionInteractiveMode)
         'Rectangle
         RectangleInteractiveMode = New ImageViewerRubberBandInteractiveMode()
         RectangleInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
         RectangleInteractiveMode.WorkOnBounds = True
         _viewer.InteractiveModes.Add(RectangleInteractiveMode)

         _viewer.InteractiveModes.EndUpdate()
      End Sub
      Private Sub AddMagicWandInteractivMode_WorkCompleted(sender As Object, e As EventArgs)
         If (_viewer.Image.GetRegionBounds(Nothing).Width > 0) Then
            _viewer.Image.MakeRegionEmpty()
            _viewer.InteractiveModes.BeginUpdate()
            FloaterInteractiveMode.DoubleTapSizeMode = _viewer.SizeMode
            FloaterInteractiveMode.IsEnabled = True
            _viewer.InteractiveModes.EndUpdate()
         End If
      End Sub
      Private Sub _viewer_TransformChanged(sender As Object, e As EventArgs)
         CType(MdiParent, MainForm).UpdateControls()
      End Sub

      Private Sub RegionInteractiveMode_WorkCompleted(sender As Object, e As EventArgs)
         If (_viewer.Image.GetRegionBounds(Nothing).Width > 0) Then
            _viewer.ActiveItem.ImageRegionToFloater()
            _viewer.WorkingInteractiveMode.IsEnabled = False
            _viewer.Image.MakeRegionEmpty()

            FloaterInteractiveMode.AutoItemMode = ImageViewerAutoItemMode.AutoSetActive
            FloaterInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left
            FloaterInteractiveMode.FloaterOpacity = 0.5
            FloaterInteractiveMode.FloaterRegionRenderMode = ControlRegionRenderMode.Animated
            FloaterInteractiveMode.Item = _viewer.ActiveItem
            _viewer.InteractiveModes.BeginUpdate()
            FloaterInteractiveMode.IsEnabled = True
            _viewer.InteractiveModes.EndUpdate()
         End If

         CType(MdiParent, MainForm).UpdateControls()
      End Sub

      Private Sub _viewer_PropertyChanged(sender As Object, e As PropertyChangedEventArgs)
         Select Case e.PropertyName
            Case "FloaterOpacity"
               CType(MdiParent, MainForm).SetFloaterPaintValues()
            Case "Floater"
         End Select
      End Sub

      Private Sub _viewer_MouseUp(sender As Object, e As MouseEventArgs)
         Me.OnMouseClick(e)
      End Sub

      Public Sub Initialize(ByVal info As ImageInformation, ByVal paintProperties As RasterPaintProperties, ByVal animateRegions As Boolean, ByVal snap_ As Boolean, ByVal useDpi As Boolean)
         _viewer.BeginUpdate()
         UpdateAnimateRegions(animateRegions)
         UpdatePaintProperties(paintProperties)
         _viewer.Image = info.Image
         _viewer.UseDpi = useDpi
         If Not _viewer.Image Is Nothing Then
            AddHandler _viewer.Image.Changed, AddressOf Image_Changed
         End If
         _name = info.Name

         If snap_ Then
            Snap()
         End If
         UpdateCaption()
         _viewer.EndUpdate()
      End Sub

      Public Sub UpdateAnimateRegions(ByVal animateRegions As Boolean)
         Dim rc As LeadRectD = _viewer.GetItemBounds(_viewer.ActiveItem, ImageViewerItemPart.Floater)

         If (animateRegions) Then
            _viewer.ImageRegionRenderMode = ControlRegionRenderMode.Animated
         Else
            _viewer.ImageRegionRenderMode = ControlRegionRenderMode.Fixed
         End If

         _viewer.FloaterRegionRenderMode = _viewer.ImageRegionRenderMode
      End Sub

      Public Sub UpdatePaintProperties(ByVal paintProperties As RasterPaintProperties)
         _viewer.PaintProperties = paintProperties
      End Sub

      Private Sub UpdateCaption()
         If (_viewer.Image.PageCount > 1) Then
            Text = String.Format("{0} - Page {1}:{2}", System.IO.Path.GetFileName(_name), _viewer.Image.Page, _viewer.Image.PageCount)
         Else
            Text = String.Format("{0}", System.IO.Path.GetFileName(_name))
         End If
      End Sub

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
         If (_viewer.ViewBounds.Width <= 0) Then
            _viewer.ClientSize = New Size(_viewer.Bounds.Width, _viewer.Bounds.Height)
            ClientSize = New Size(_viewer.Bounds.Width, _viewer.Bounds.Height)
         Else
            _viewer.ClientSize = New Size(_viewer.ViewBounds.Size.Width, _viewer.ViewBounds.Size.Height)
            ClientSize = New Size(_viewer.ViewBounds.Size.Width, _viewer.ViewBounds.Size.Height)
         End If
      End Sub

      Private Sub _viewer_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
         If CanFocus Then
            If Tools.CanDrop(e.Data) Then
               e.Effect = DragDropEffects.Copy
            End If
         End If
      End Sub

      Private Sub _viewer_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
         If CanFocus Then
            If Tools.CanDrop(e.Data) Then
               Dim files As String() = Tools.GetDropFiles(e.Data)
               If Not files Is Nothing Then
                  CType(MdiParent, MainForm).LoadDropFiles(Me, files)
               End If
            End If
         End If
      End Sub

      Private Sub _viewer_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
         If (Not e.Handled) Then
            If e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.Oemplus OrElse e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.OemMinus Then
               e.Handled = True

               CType(MdiParent, MainForm).Zoom(e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.Oemplus)
            End If
         End If
      End Sub

      Private Sub _viewer_FloaterImageChanged(ByVal sender As Object, ByVal e As EventArgs)
         CType(MdiParent, MainForm).SetFloaterPaintValues()
      End Sub

      Private Sub _viewer_FloaterVisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
         CType(MdiParent, MainForm).SetFloaterPaintValues()
      End Sub
   End Class
End Namespace
