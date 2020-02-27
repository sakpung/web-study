' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Leadtools.Demos.StorageServer.DataTypes

Namespace Leadtools.Demos.StorageServer.UI
   Partial Public Class StorageServerContainerView : Inherits UserControl
#Region "Public"

#Region "Methods"

      Public Sub New()
         InitializeComponent()
         ResizeRedraw = False
         PageLocation = New Point(169, 98)
         _pages = New TabPageCollection()
         _labels = New List(Of TabLabel)()

         AddHandler _pages.PageAdded, AddressOf _pages_PageAdded
         AddHandler _pages.PageRemoved, AddressOf _pages_PageRemoved

         PagesLocation = New Point(204, 131)
         LeftPanel.BackColor = Color.Transparent
         TopPanel.BackColor = Color.Transparent
         ContentsPanel.BackColor = Color.Transparent

         'TopPanel.Paint += new PaintEventHandler  ( TopPanel_Paint ) ;
         'LeftPanel.Paint += new PaintEventHandler ( TopPanel_Paint ) ;

         'this.BackColor = Color.White ;

         DoubleBuffered = True
      End Sub

      Public Sub SetHeader(ByVal headerControl As Control)
         HeaderPanel.Controls.Clear()

         headerControl.Dock = DockStyle.Fill

         HeaderPanel.Controls.Add(headerControl)
      End Sub

#End Region

#Region "Properties"

      Public Property PagesLocation() As Point
         Get
            Return _pagesLocation
         End Get
         Set(ByVal value As Point)
            _pagesLocation = value
            TopPanel.Height = _pagesLocation.Y
            LeftPanel.Width = _pagesLocation.X
         End Set
      End Property

      Private _selectedPage As PageData
      Public Property SelectedPage() As PageData
         Get
            Return _selectedPage
         End Get
         Private Set(ByVal value As PageData)
            _selectedPage = value
         End Set
      End Property

      Public ReadOnly Property Pages() As TabPageCollection
         Get
            Return _pages
         End Get
      End Property

      Private _gradientMode As LinearGradientMode
      Public Property GradientMode() As LinearGradientMode
         Get
            Return _gradientMode
         End Get
         Set(ByVal value As LinearGradientMode)
            _gradientMode = value
         End Set
      End Property

      Private _pageLocation As Point
      Public Property PageLocation() As Point
         Get
            Return _pageLocation
         End Get
         Set(ByVal value As Point)
            _pageLocation = value
         End Set
      End Property

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region

#Region "Protected"

#Region "Methods"

      'protected override void OnResize(EventArgs e)
      '{
      '   base.OnResize(e);
      '   //Invalidate ( ) ;
      '}

      'protected override void OnSizeChanged(EventArgs e)
      '{
      '   base.OnSizeChanged(e);
      '   Invalidate ( ) ;
      '}

      'protected override void OnPaintBackground(PaintEventArgs e)
      '{
      '   Rectangle rect = new Rectangle ( new Point ( 0, 0 ), new Size ( Math.Max ( this.Width, 1 ), Math.Max ( this.Height, 1 ) ) ) ;

      '   using ( Brush myBrush = new LinearGradientBrush ( rect , Color.LightBlue, Color.DarkBlue, GradientMode ) )
      '   {
      '      e.Graphics.FillRectangle ( myBrush, rect ) ;
      '   }
      '}

      Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
         MyBase.OnHandleCreated(e)

         For Each page As PageData In Pages
            AddPage(page)
         Next page
      End Sub

      'void TopPanel_Paint(object sender, PaintEventArgs e)
      '{
      '   Rectangle rect = new Rectangle ( new Point ( 0, 0 ), new Size ( Math.Max ( this.Width, 1 ), Math.Max ( this.Height, 1 ) ) ) ;

      '   using ( Brush myBrush = new LinearGradientBrush ( rect , Color.LightBlue, Color.DarkBlue, GradientMode ) )
      '   {
      '      e.Graphics.FillRectangle ( myBrush, rect ) ;
      '   }
      '}

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

      Private Sub AddPage(ByVal pageData As PageData)
         AddHandler pageData.Page.Paint, AddressOf TabPage_Paint

         pageData.Page.Location = PagesLocation
         pageData.Page.Dock = DockStyle.Fill
         pageData.Page.Visible = False

         If (Not ContentsPanel.Contains(pageData.Page)) Then
            ContentsPanel.Controls.Add(pageData.Page)
         End If

         AddTabButton(pageData)
      End Sub

      Private Sub AddTabButton(ByVal pageData As PageData)
         Dim label As TabLabel = New TabLabel()

         label.Size = New Size(PagesLocation.X - 9, 50)
         label.Location = New Point(10, 20 + (60 * Pages.IndexOf(pageData)))
         label.Text = pageData.Text
         label.Tag = pageData
         label.BackColor = Color.Red
         label.TextAlign = ContentAlignment.MiddleCenter
         label.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
         label.Cursor = Cursors.Hand

         Dim r As Rectangle = label.ClientRectangle
         Dim path As System.Drawing.Drawing2D.GraphicsPath = RoundRectangle(r, 8, Corners.BottomLeft Or Corners.TopLeft)
         label.Region = New Region(path)

         AddHandler label.IsPressedChanged, AddressOf label_IsPressedChanged

         If _labels.Count = 0 Then
            label.IsPressed = True
         End If

         LeftPanel.Controls.Add(label)

         _labels.Add(label)
      End Sub

      Private Function RoundRectangle(ByVal r As Rectangle, ByVal radius As Integer, ByVal corners As Corners) As System.Drawing.Drawing2D.GraphicsPath
         'Make sure the Path fits inside the rectangle
         r.Width -= 1
         r.Height -= 1

         'Scale the radius if it's too large to fit.
         If radius > (r.Width) Then
            radius = r.Width
         End If
         If radius > (r.Height) Then
            radius = r.Height
         End If

         Dim path As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()

         If radius <= 0 Then
            path.AddRectangle(r)
         Else
            If (corners And corners.TopLeft) = corners.TopLeft Then
               path.AddArc(r.Left, r.Top, radius, radius, 180, 90)
            Else
               path.AddLine(r.Left, r.Top, r.Left, r.Top)
            End If
         End If

         If (corners And corners.TopRight) = corners.TopRight Then
            path.AddArc(r.Right - radius, r.Top, radius, radius, 270, 90)
         Else
            path.AddLine(r.Right, r.Top, r.Right, r.Top)
         End If

         If (corners And corners.BottomRight) = corners.BottomRight Then
            path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90)
         Else
            path.AddLine(r.Right, r.Bottom, r.Right, r.Bottom)
         End If

         If (corners And corners.BottomLeft) = corners.BottomLeft Then
            path.AddArc(r.Left, r.Bottom - radius, radius, radius, 90, 90)
         Else
            path.AddLine(r.Left, r.Bottom, r.Left, r.Bottom)
         End If

         path.CloseFigure()

         Return path
      End Function

#End Region

#Region "Properties"

      Private _mySelectedLabel As TabLabel
      Private Property __SelectedLabel() As TabLabel
         Get
            Return _mySelectedLabel
         End Get
         Set(ByVal value As TabLabel)
            _mySelectedLabel = value
         End Set
      End Property

#End Region

#Region "Events"

      Private Sub _pages_PageRemoved(ByVal sender As Object, ByVal e As DataEventArgs(Of PageData))
         If (Not IsHandleCreated) Then
            Return
         End If

         RemoveHandler e.Data.Page.Paint, AddressOf TabPage_Paint
      End Sub

      Private Sub _pages_PageAdded(ByVal sender As Object, ByVal e As DataEventArgs(Of PageData))
         If (Not IsHandleCreated) Then
            Return
         Else
            AddPage(e.Data)
         End If
      End Sub

      Private Sub label_IsPressedChanged(ByVal sender As Object, ByVal e As EventArgs)
         Dim label As TabLabel = CType(sender, TabLabel)

         If label.IsPressed = True Then
            Dim pageData As PageData = CType(label.Tag, PageData)

            pageData.Page.Visible = True


            If Not Nothing Is __SelectedLabel Then
               __SelectedLabel.IsPressed = False
            End If

            If Not Nothing Is SelectedPage Then
               SelectedPage.Page.Visible = False
            End If

            __SelectedLabel = label
            SelectedPage = pageData
         End If
      End Sub

      Private Sub TabPage_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
         Dim r As Rectangle = Me.ClientRectangle
         Dim path As System.Drawing.Drawing2D.GraphicsPath = RoundRectangle(r, 8, Corners.All)

         CType(sender, Control).Region = New Region(path)
      End Sub

#End Region

#Region "Data Members"

      Private _pagesLocation As Point
      Private _pages As TabPageCollection
      Private _labels As List(Of TabLabel)

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "internal"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region
   End Class

   Public Class DoubleBufferedPanel : Inherits Panel
      Public Sub New()
         SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
      End Sub
   End Class
End Namespace
