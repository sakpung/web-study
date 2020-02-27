' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Pdf
Imports PDFDocumentDemo.PDFDocumentDemo.Annotations

Namespace PDFDocumentDemo.Workers
   ' Generate the thumbnails for the pages in a document
   Friend Class GenerateThumbnailsWorker : Inherits ThreadedPageWorker
      Public Sub New()
         MyBase.New()
      End Sub

      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            [Stop]()
         End If

         MyBase.Dispose(disposing)
      End Sub

      Private _document As PDFDocument
      Private _thumbnailWidth As Integer
      Private _thumbnailHeight As Integer

      Public Sub Start(ByVal document As PDFDocument, ByVal thumbnailWidth As Integer, ByVal thumbnailHeight As Integer)
         _document = document
         _thumbnailWidth = thumbnailWidth
         _thumbnailHeight = thumbnailHeight

         StartWork(_document.Pages.Count)
      End Sub

      Public Sub [Stop]()
         StopWork()

         _document = Nothing
      End Sub

      Protected Overrides Function ProcessPage(ByVal pageNumber As Integer) As ThreadedPageWorkerPageProcessedEventArgs
         ' Get the thumbnail for this page
         Try
            Dim codecs As RasterCodecs = New RasterCodecs()
            Try
               DocumentAnnotations.SetRasterCodecsOptions(_document, codecs, pageNumber)
               Dim thumbnailImage As RasterImage = _document.GetThumbnail(codecs, pageNumber, _thumbnailWidth, _thumbnailHeight)
               Return New ThreadedPageWorkerPageProcessedEventArgs(pageNumber, thumbnailImage, Nothing)
            Finally
               CType(codecs, IDisposable).Dispose()
            End Try
         Catch e As Exception
            Return New ThreadedPageWorkerPageProcessedEventArgs(pageNumber, Nothing, e)
         End Try
      End Function
   End Class
End Namespace
