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

Imports Leadtools
Imports Leadtools.WinForms

''' <summary>
''' Summary description for ChildForm.
''' </summary>
Public Class ChildForm : Inherits System.Windows.Forms.Form
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChildForm))
      Me.SuspendLayout()
      ' 
      ' ChildForm
      ' 
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(505, 354)
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.Name = "ChildForm"
      Me.Text = "ChildForm"
      '         Me.Closing += New System.ComponentModel.CancelEventHandler(Me.ChildForm_Closing);
      '         Me.Load += New System.EventHandler(Me.ChildForm_Load);
      Me.ResumeLayout(False)

   End Sub
#End Region
   Public _viewer As RasterImageViewer

   Private Sub ChildForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
   End Sub

   Public Sub InsertImage(ByVal img As RasterImage, ByVal imageName As String)
      ' initialize the _viewer object
      _viewer = New RasterImageViewer()
      _viewer.Dock = DockStyle.Fill
      _viewer.BackColor = Color.DarkGray
      Controls.Add(_viewer)
      _viewer.BringToFront()

      _viewer.Image = img
      Text = imageName
   End Sub

   Private Sub ChildForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      Dim parentForm As MainForm = CType(MdiParent, MainForm)
      If parentForm.MdiChildren.Length = 1 Then
         parentForm.EnableMenuItems(False)
      End If
   End Sub
End Class
