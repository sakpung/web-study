' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.MedicalViewer

Namespace MedicalViewerDemo
   Partial Public Class CounterDialog : Inherits Form

      Private myOwner As MainForm
      Private imageIndex As Integer

      Public Sub New(ByVal owner As MainForm, ByVal codecs As RasterCodecs)
         myOwner = owner
         imageIndex = 0
         If Not codecs Is Nothing Then
            AddHandler codecs.LoadPage, AddressOf codecs_LoadPage
         End If
         InitializeComponent()
         _lblCounter.Text = "Loading Image"
      End Sub

      Public Sub UpdateCounterPercent(ByVal currentPage As Integer, ByVal total As Integer, ByVal invalidate As Boolean)
         _lblCounter.Text = "Loading Image ( " & (imageIndex + 1) & " )   Page " & currentPage.ToString() & " / " & total.ToString()
         _lblCounter.Invalidate()
         _lblCounter.Update()

         Dim percentage As Integer = CInt(currentPage * 100 / total)
         If percentage = 100 Then
            imageIndex = imageIndex + 1
            percentage = 0
         End If

         _progress.Value = CInt((imageIndex * 100 + percentage) / myOwner.Images)
         If imageIndex = myOwner.Images Then
            Me.Close()
         End If

         If invalidate Then
            myOwner.Invalidate()
            myOwner.Update()
         End If
      End Sub

      Private Sub codecs_LoadPage(ByVal sender As Object, ByVal e As CodecsPageEventArgs)
         If e.State = CodecsPageEventState.After Then
            UpdateCounterPercent(e.Image.Page, e.Image.PageCount, False)
         End If
         myOwner.Invalidate()
         myOwner.Update()
      End Sub
   End Class
End Namespace
