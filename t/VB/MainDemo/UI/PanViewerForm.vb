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

Imports Leadtools.Controls

Namespace MainDemo
   Partial Public Class PanViewerForm : Inherits Form
      Private _panViewer As ImageViewerPanControl

      Public Sub New()
         InitializeComponent()

         InitClass()
      End Sub

      Private Sub InitClass()
         Dim PanViewerPicture As New PictureBox()
         PanViewerPicture.Width = 400
         PanViewerPicture.Dock = DockStyle.Fill
         PanViewerPicture.BorderStyle = BorderStyle.None
         Controls.Add(PanViewerPicture)
         PanViewerPicture.BringToFront()

         _panViewer = New ImageViewerPanControl()
         _panViewer.BorderPen = New Pen(Brushes.Red)
         _panViewer.EnablePan = True
         _panViewer.OutsideBrush = New SolidBrush(Color.FromArgb(128, 0, 0, 0))
         _panViewer.MouseButton = System.Windows.Forms.MouseButtons.Left
         _panViewer.WorkingCursor = Cursors.Hand
         _panViewer.Control = PanViewerPicture
      End Sub

      Private Sub PanViewerForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
         e.Cancel = True
         Visible = False
         CType(Owner, MainForm).UpdateControls()
      End Sub

      Public Sub SetViewer(ByVal viewer As ImageViewer)
         _panViewer.ImageViewer = viewer
      End Sub

   End Class
End Namespace
