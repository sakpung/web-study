' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Drawing

Namespace AbcDemo
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
         Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ViewerForm))
         ' 
         ' ViewerForm
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.Name = "ViewerForm"
         Me.ShowInTaskbar = False
         Me.Text = "ViewerForm"

      End Sub
#End Region

      Private _viewer As ImageViewer
      Private _name As String
      Private _originalViewer As Boolean

      Private Sub InitClass()
         _viewer = New ImageViewer()
         _viewer.Dock = DockStyle.Fill
         AddHandler _viewer.DragEnter, AddressOf _viewer_DragEnter
         AddHandler _viewer.DragDrop, AddressOf _viewer_DragDrop
         AddHandler _viewer.KeyDown, AddressOf _viewer_KeyDown
         Controls.Add(_viewer)
         _viewer.BringToFront()
         _viewer.AllowDrop = True

         _viewer.Zoom(ControlSizeMode.ActualSize, 1.0, _viewer.DefaultZoomOrigin)
      End Sub

      Public Sub Initialize(ByVal info As ImageInformation, ByVal paintProperties As RasterPaintProperties, ByVal snap_Renamed As Boolean)
         _viewer.BeginUpdate()
         UpdatePaintProperties(paintProperties)
         _viewer.Image = info.Image
         If Not _viewer.Image Is Nothing Then
            AddHandler _viewer.Image.Changed, AddressOf Image_Changed
         End If
         _name = info.Name
         UpdateCaption()
         _viewer.EndUpdate()

         If snap_Renamed Then
            Snap()
         End If
      End Sub

      Public Sub UpdatePaintProperties(ByVal paintProperties As RasterPaintProperties)
         _viewer.PaintProperties = paintProperties
      End Sub

      Private Sub UpdateCaption()
         Text = _name
      End Sub

      Public Property OriginalViewer() As Boolean
         Get
            Return _originalViewer
         End Get
         Set(value As Boolean)
            _originalViewer = Value
         End Set
      End Property

      Public Property Image() As RasterImage
         Get
            Return _viewer.Image
         End Get
         Set(value As RasterImage)
            _viewer.Image = Value
         End Set
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
         Dim workingScreen As Screen = Screen.FromRectangle(New Rectangle(Me.Location, Me.Size))
         If (_viewer.Image.Height < workingScreen.WorkingArea.Height) AndAlso (_viewer.Width < workingScreen.WorkingArea.Width) Then
            ClientSize = New Size(_viewer.ViewSize.Width, _viewer.ViewSize.Height)
         End If
      End Sub

      Private Sub _viewer_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
         If Tools.CanDrop(e.Data) Then
            e.Effect = DragDropEffects.Copy
         End If
      End Sub

      Private Sub _viewer_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
         If Tools.CanDrop(e.Data) Then
            Dim files As String() = Tools.GetDropFiles(e.Data)
            If Not files Is Nothing Then
               CType(MdiParent, MainForm).LoadDropFiles(Me, files)
            End If
         End If
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

               CType(MdiParent, MainForm).StopSaving = True
            End If
         End If
      End Sub

      Private Sub ViewerForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
         If _originalViewer Then
            CType(MdiParent, MainForm).ViewerOpened = False

            If (CType(MdiParent, MainForm)).MdiChildren.Length > 1 Then
               CType(MdiParent, MainForm).MdiChildren(1).Close()
               CType(MdiParent, MainForm).UpdateControls()
               CType(MdiParent, MainForm).ShowSave = False
               CType(MdiParent, MainForm).PreviousCheckQuality.Checked = False
            End If
         End If
      End Sub
   End Class
End Namespace
