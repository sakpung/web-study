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
Imports Leadtools.Document
Imports System

Partial Public Class DocumentPropertiesDialog
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Property Document() As LEADDocument
      Get
         Return m_Document
      End Get
      Set(value As LEADDocument)
         m_Document = value
      End Set
   End Property
   Private m_Document As LEADDocument

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         Init()
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub Init()
      Dim document__1 As LEADDocument = Me.Document

      _documentListView.Items.Add(New ListViewItem(New String() {"Document ID", document__1.DocumentId}))

      Dim uriType As String = "URL"
      Dim uriValue As String = "none"

      Dim uri As Uri = document__1.Uri
      If uri IsNot Nothing Then
         If uri.IsFile Then
            uriType = "File"
            uriValue = uri.LocalPath
         Else
            uriType = "URL"
            uriValue = uri.ToString()
         End If
      End If

      _documentListView.Items.Add(New ListViewItem(New String() {uriType, uriValue}))
      _documentListView.Items.Add(New ListViewItem(New String() {"MIME Type", document__1.MimeType}))
      _documentListView.Items.Add(New ListViewItem(New String() {"Encrypted", If(document__1.IsDecrypted, "Yes", "No")}))

      uri = document__1.Annotations.AnnotationsUri
      If uri IsNot Nothing Then
         If uri.IsFile Then
            _documentListView.Items.Add(New ListViewItem(New String() {"Annotations file", uri.LocalPath}))
         Else
            _documentListView.Items.Add(New ListViewItem(New String() {"Annotations URL", uri.ToString()}))
         End If
      End If

      Dim pageCount As Integer = document__1.Pages.Count
      _documentListView.Items.Add(New ListViewItem(New String() {"Pages", pageCount.ToString()}))

      If pageCount > 0 Then
         Dim page As DocumentPage = document__1.Pages(0)
         Dim pageSize As LeadSizeD = page.Size
         Dim sizeInchdes As LeadSizeD = LeadSizeD.Create(pageSize.Width / LEADDocument.UnitsPerInch, pageSize.Height / LEADDocument.UnitsPerInch)
         Dim sizePixels As LeadSize = document__1.SizeToPixels(pageSize)
         _documentListView.Items.Add(New ListViewItem(New String() {"Page size", String.Format("{0} x {1} in ({2} x {3} px)", sizeInchdes.Width, sizeInchdes.Height, sizePixels.Width, sizePixels.Height)}))
      End If

      For Each iter As KeyValuePair(Of String, String) In document__1.Metadata
         _metadataListView.Items.Add(New ListViewItem(New String() {iter.Key, iter.Value}))
      Next
   End Sub

   Protected Overrides Sub OnSizeChanged(e As EventArgs)
      _documentListView.Columns(_documentListView.Columns.Count - 1).Width = -2
      _metadataListView.Columns(_metadataListView.Columns.Count - 1).Width = -2

      MyBase.OnSizeChanged(e)
   End Sub
End Class
