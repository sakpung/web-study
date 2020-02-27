' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Demos
Imports Leadtools.Controls

Imports Leadtools.Drawing

Namespace AnimationDemo
   Partial Public Class ViewerForm
      Inherits Form
      Public Sub New()
         InitializeComponent()

         InitClass()
      End Sub

      Private _viewer As RasterPictureBox
      Private _name As String

      Private Sub InitClass()
         _viewer = New RasterPictureBox()
         _viewer.Dock = DockStyle.Fill
         _viewer.BorderStyle = BorderStyle.None
         AddHandler _viewer.FrameChanged, AddressOf _viewer_FrameChanged
         Controls.Add(_viewer)
         _viewer.BringToFront()
      End Sub

      Private Sub _viewer_FrameChanged(sender As Object, e As RasterPictureBoxFrameChangedEventArgs)
         UpdateCaption()
         If MdiParent IsNot Nothing Then
            CType(MdiParent, MainForm).UpdateControls()
         End If
      End Sub

      Public Sub Initialize(info As ImageInformation, paintProperties As RasterPaintProperties, animateRegions As Boolean, snap As Boolean, useDpi As Boolean, animationMode As RasterPictureBoxAnimationMode)
         _viewer.BeginUpdate()
         UpdatePaintProperties(paintProperties)
         _viewer.Image = info.Image
         _viewer.UseDpi = useDpi
         _viewer.AnimationMode = animationMode
         If _viewer.Image IsNot Nothing Then
            AddHandler _viewer.Image.Changed, AddressOf Image_Changed
         End If

         If Image.Width > Me.Viewer.Size.Width OrElse Image.Height > Me.Viewer.Size.Height Then
            Me.Viewer.SizeMode = RasterPictureBoxSizeMode.Fit
         End If

         _name = info.Name
         UpdateCaption()
         _viewer.EndUpdate()
      End Sub

      Public Sub UpdatePaintProperties(paintProperties As RasterPaintProperties)
         _viewer.PaintProperties = paintProperties
         _viewer.Refresh()
      End Sub

      Private Sub UpdateCaption()
         Text = String.Format("{0} - Page {1}:{2}", _name, _viewer.Image.Page, _viewer.Image.PageCount)
      End Sub

      Public ReadOnly Property Image() As RasterImage
         Get
            Return _viewer.Image
         End Get
      End Property

      Public ReadOnly Property Viewer() As RasterPictureBox
         Get
            Return _viewer
         End Get
      End Property

      Public ReadOnly Property Title() As String
         Get
            Return _name
         End Get
      End Property

      Private Sub Image_Changed(sender As Object, e As RasterImageChangedEventArgs)
         UpdateCaption()
         If MdiParent IsNot Nothing Then
            CType(MdiParent, MainForm).UpdateControls()
         End If
      End Sub
   End Class
End Namespace
