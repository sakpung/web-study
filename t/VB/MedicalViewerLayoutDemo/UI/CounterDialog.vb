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
Imports Leadtools.Codecs
Imports Leadtools.MedicalViewer

Namespace MedicalViewerLayoutDemo
   Public Partial Class CounterDialog : Inherits Form

	  Private myOwner As MainForm
	  Private imageIndex As Integer

	  Public Sub New(ByVal owner As MainForm, ByVal codecs As RasterCodecs)
		 myOwner = owner
		 imageIndex = 0
            AddHandler codecs.LoadPage, AddressOf codecs_LoadPage
		 InitializeComponent()
		 _lblCounter.Text = "Loading Image"
	  End Sub

	  Private Sub codecs_LoadPage(ByVal sender As Object, ByVal e As CodecsPageEventArgs)
		 If e.State = CodecsPageEventState.After Then
			_lblCounter.Text = "Loading Image ( " & (imageIndex + 1) & " )   Page " & e.Page.ToString() & " / " & e.PageCount.ToString()
			_lblCounter.Invalidate()
			_lblCounter.Update()

                Dim percentage As Integer = Convert.ToInt32((e.Page * 100 / e.PageCount))
			If percentage = 100 Then
			   imageIndex = imageIndex + 1
			   percentage = 0
			End If

                _progress.Value = Convert.ToInt32((imageIndex * 100 + percentage) / myOwner.Images)
                If imageIndex = myOwner.Images Then
                    Me.Close()
                End If
		 End If
		 myOwner.Invalidate()
		 myOwner.Update()
	  End Sub
   End Class
End Namespace
