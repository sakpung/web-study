' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Drawing

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
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(292, 271)
      Me.Cursor = System.Windows.Forms.Cursors.Default
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.Name = "ViewerForm"
      Me.ShowInTaskbar = False
      Me.Text = "ViewerForm"
      '		 Me.Closing += New System.ComponentModel.CancelEventHandler(Me.ViewerForm_Closing);
      '		 Me.MdiChildActivate += New System.EventHandler(Me.ViewerForm_MdiChildActivate);
      '		 Me.Activated += New System.EventHandler(Me.ViewerForm_MdiChildActivate);
      '		 Me.Paint += New System.Windows.Forms.PaintEventHandler(Me.ViewerForm_Paint);

   End Sub
#End Region

   Friend Property StandardOptions() As PdfStandardOptions
      Get
         Return _standardOptions
      End Get
      Set(value As PdfStandardOptions)
         _standardOptions = value
      End Set
   End Property

   Friend Property AdvancedOptions() As PdfAdvancedOptions
      Get
         Return _advancedOptions
      End Get
      Set(value As PdfAdvancedOptions)
         _advancedOptions = value
      End Set
   End Property

   Public ReadOnly Property Image() As RasterImage
      Get
         Return _tempImage
      End Get
   End Property

   Public ReadOnly Property Viewer() As ImageViewer
      Get
         Return _viewer
      End Get
   End Property

   Private _viewer As ImageViewer
   Private _tempImage As RasterImage
   Private _name As String
   Private _standardOptions As PdfStandardOptions
   Private _advancedOptions As PdfAdvancedOptions
   Private _drawRect As RectangleF



   Private Sub InitClass()
      _viewer = New ImageViewer()

      _viewer.Dock = DockStyle.Fill
      _viewer.BorderStyle = BorderStyle.None
      AddHandler _viewer.DragEnter, AddressOf _viewer_DragEnter
      AddHandler _viewer.DragDrop, AddressOf _viewer_DragDrop
      AddHandler _viewer.DoubleClick, AddressOf _viewer_DoubleClick

      Controls.Add(_viewer)
      _viewer.BringToFront()
      _viewer.AllowDrop = True

   End Sub

   Public Sub Initialize(ByVal info As ImageInformation, ByVal paintProperties As RasterPaintProperties, ByVal snap_Renamed As Boolean)
      _viewer.BeginUpdate()
      UpdatePaintProperties(paintProperties)
      _viewer.Image = info.Image
      _tempImage = _viewer.Image.CloneAll()
      If Not _viewer.Image Is Nothing Then
         AddHandler _viewer.Image.Changed, AddressOf Image_Changed
      End If
      _name = info.Name
      If snap_Renamed Then
         Snap()
      End If
      UpdateCaption()
      _viewer.EndUpdate()
   End Sub

   Public Sub UpdatePaintProperties(ByVal paintProperties As RasterPaintProperties)
      _viewer.PaintProperties = paintProperties
   End Sub

   Private Sub UpdateCaption()
      'Do nothing now
      Text = String.Format("{0} ", _name, _viewer.Image.Page, _viewer.Image.PageCount)
   End Sub

   Private Sub Image_Changed(ByVal sender As Object, ByVal e As RasterImageChangedEventArgs)
      UpdateCaption()
      If Not MdiParent Is Nothing Then
         CType(MdiParent, MainForm).UpdateControls()
      End If
   End Sub

   Public Sub Snap()
      _viewer.ClientSize = _viewer.DisplayRectangle.Size
      ClientSize = _viewer.ClientSize
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

   Private Sub ViewerForm_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MdiChildActivate, MyBase.Activated
      If Not MdiParent Is Nothing Then
         CType(MdiParent, MainForm).UpdateControls()
      End If
   End Sub


   Private Sub ViewerForm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
      Dim drawColor As Color

      If Not _viewer.Image Is Nothing Then
         If _viewer.Image.Width >= 150 AndAlso _viewer.Image.Height >= 150 Then
            _viewer.Image = _tempImage.CloneAll()

            Using container As RasterImageGdiPlusGraphicsContainer = New RasterImageGdiPlusGraphicsContainer(_viewer.Image)

               ' Create string to draw.
               Dim drawString As String = ""


               If StandardOptions.Added Then
                  drawString &= " Status : ADDED" & Constants.vbLf
                  drawString &= " Index: "
                  drawString &= StandardOptions.PageNumber
                  If (Not StandardOptions.NOMRC) Then
                     drawString &= Constants.vbLf
                     drawString &= " Input Quality: "

                     Select Case StandardOptions.InputImageComboSel
                        Case 0
                           drawString &= "Auto"
                        Case 1
                           drawString &= "Noisy"
                        Case 2
                           drawString &= "Scanned"
                        Case 3
                           drawString &= "Printed"
                        Case 4
                           drawString &= "Computer Generated"
                        Case 5
                           drawString &= "Photo"
                        Case 6
                           drawString &= "User Defined"
                     End Select

                     drawString &= Constants.vbLf & " Output Quality : "
                     Select Case StandardOptions.OutputImageComboSel
                        Case 0
                           drawString &= "Auto"
                        Case 1
                           drawString &= "Poor"
                        Case 2
                           drawString &= "Average"
                        Case 3
                           drawString &= "Good"
                        Case 4
                           drawString &= "Excellent"
                        Case 5
                           drawString &= "User Defined"
                     End Select
                  End If
                  drawColor = Color.Green
               Else
                  drawString &= " Status : NOT ADDED"
                  drawColor = Color.Red
               End If

               ' Create font and brush.
               Dim fontSize As Integer = 12
               Dim gradientBrush As LinearGradientBrush
               Dim drawFont As Font = New Font("Arial", fontSize, FontStyle.Bold, GraphicsUnit.Pixel)
               Dim drawBrush As SolidBrush = New SolidBrush(Color.Black)

               ' Set format of string.
               Dim size As SizeF = container.Graphics.MeasureString(drawString, drawFont)
               Dim pen As Pen = New Pen(drawColor, 0)
               container.Graphics.DrawRectangle(pen, 0, 0, _viewer.Image.Width, size.Height)

               _drawRect = New RectangleF(0, 0, _viewer.Image.Width, size.Height)

               Dim drawFormat As StringFormat = New StringFormat()
               drawFormat.Alignment = StringAlignment.Center
               gradientBrush = New LinearGradientBrush(_drawRect, drawColor, Color.White, LinearGradientMode.ForwardDiagonal)

               container.Graphics.FillRectangle(gradientBrush, _drawRect)

               container.Graphics.DrawString(drawString, drawFont, drawBrush, _drawRect) ',drawFormat);
            End Using
         End If
      End If
   End Sub

   Private Sub _viewer_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
      AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
   End Sub


   Private Sub _viewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
      If e.X >= _drawRect.X AndAlso e.X <= _drawRect.X + _drawRect.Width AndAlso e.Y >= _drawRect.Y AndAlso e.Y <= _drawRect.Y + _drawRect.Height Then
         CType(MdiParent, MainForm).PdfOptionsAddDialog()
         ViewerForm.ActiveForm.Refresh()
      End If
      RemoveHandler _viewer.MouseMove, AddressOf _viewer_MouseMove

   End Sub

   Private Sub ViewerForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      If Not MdiParent Is Nothing Then
         CType(MdiParent, MainForm).DeletePage()
      End If
   End Sub
End Class

