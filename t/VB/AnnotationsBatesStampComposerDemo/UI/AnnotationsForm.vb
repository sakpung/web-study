' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.IO

Imports Leadtools
Imports Leadtools.WinForms

Imports Leadtools.Drawing
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.Engine
Imports System.Collections.Generic
Imports System.Reflection
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Annotations.Rendering
Imports Leadtools.Annotations.Designers
Imports Leadtools.Controls
Imports System

''' <summary>
''' Summary description for AnnotationsForm.
''' </summary>
Public Class AnnotationsForm
   Inherits System.Windows.Forms.Form
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.Container = Nothing

   Public Sub New()
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()
   End Sub

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing Then
         If components IsNot Nothing Then
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
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(AnnotationsForm))
      Me.SuspendLayout()
      ' 
      ' AnnotationsForm
      ' 
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(292, 271)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "AnnotationsForm"
      Me.Text = "w4"
      Me.TransparencyKey = System.Drawing.Color.White
      Me.ResumeLayout(False)

   End Sub
#End Region

   Private _automationControl As ImageViewerAutomationControl
   Private _viewer As ImageViewer
   Private Sub InitClass()
      _viewer = New ImageViewer()
      _automationControl = New ImageViewerAutomationControl()
      _automationControl.ImageViewer = _viewer

      _viewer.Dock = DockStyle.Fill
      _viewer.BorderStyle = BorderStyle.None
      Controls.Add(_viewer)
      _viewer.BringToFront()
      AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
      AddHandler _viewer.KeyDown, AddressOf _viewer_KeyDown
      _viewer.UseDpi = False
      _viewer.Focus()
   End Sub

   Public ReadOnly Property MainForm() As MainForm
      Get
         Return TryCast(MdiParent, MainForm)
      End Get
   End Property

   Public ReadOnly Property Viewer() As ImageViewer
      Get
         Return _viewer
      End Get
   End Property

   Public ReadOnly Property Automation() As AnnAutomation
      Get
         If _automationControl IsNot Nothing Then
            Return TryCast(_automationControl.AutomationObject, AnnAutomation)
         Else
            Return Nothing
         End If
      End Get
   End Property

   Public Sub Initialize(paintProperties As RasterPaintProperties, image As RasterImage, fileName As String)
      InitClass()
      Text = fileName
      _viewer.Image = image
      UpdatePaintProperties(paintProperties)

      Dim automation As New AnnAutomation(MainForm.AutomationManager, _automationControl)

      ' Update the container size
      automation.Container.Size = automation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(_viewer.Image.ImageWidth, _viewer.Image.ImageHeight))

      AddHandler automation.Container.Children.CollectionChanged, AddressOf Children_CollectionChanged
      automation.Container.Mapper.FontRelativeToDevice = False
      AddHandler automation.DeserializeObjectError, AddressOf automation_DeserializeObjectError

      MainForm.UpdateControls()
   End Sub

   Private Sub automation_DeserializeObjectError(sender As Object, e As AnnSerializeObjectEventArgs)
      ' In case you need to skip objects or create them yourself
      System.Diagnostics.Debug.WriteLine("Object could not be de-serialized: {0}", e.TypeName)
      e.SkipObject = True
   End Sub

   Private Sub AnnotationsForm_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs)Handles Me.Closing
      Dim automation__1 As AnnAutomation = Automation
      If automation__1 IsNot Nothing Then
         RemoveHandler automation__1.Container.Children.CollectionChanged, AddressOf Children_CollectionChanged
         automation__1.Container.Mapper.FontRelativeToDevice = False
         RemoveHandler automation__1.DeserializeObjectError, AddressOf automation_DeserializeObjectError

         If Not e.Cancel Then
            MainForm.AutomationManager.Automations.Remove(automation__1)
         End If
      End If
   End Sub


   Public Sub UpdatePaintProperties(paintProperties As RasterPaintProperties)
      '_viewer.PaintProperties = paintProperties;
   End Sub

   Private Sub Children_CollectionChanged(sender As Object, e As AnnNotifyCollectionChangedEventArgs)
      MainForm.UpdateControls()
   End Sub

   Private Sub _viewer_MouseMove(sender As Object, e As MouseEventArgs)
      If Automation IsNot Nothing AndAlso Automation.Container IsNot Nothing Then
         Dim physical As New LeadPointD(e.X, e.Y)
         Dim logical As LeadPointD = Automation.Container.Mapper.PointToContainerCoordinates(physical)
         MainForm.SetStatusBarText(String.Format("{0}, {1} ({2}, {3})", physical.X, physical.Y, logical.X, logical.Y))
      Else
         MainForm.SetStatusBarText(String.Format("{0}, {1}", e.X, e.Y))
      End If
   End Sub

   Private Sub automation_ImageDirtyChanged(sender As Object, e As EventArgs)
      MainForm.UpdateControls()
   End Sub

   Private Sub _viewer_KeyDown(sender As Object, e As KeyEventArgs)
      If Not e.Handled Then
         If e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.Oemplus OrElse e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.OemMinus Then
            e.Handled = True

            MainForm.Zoom(e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.Oemplus)
         End If
      End If
   End Sub
End Class
