// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Pdf;
using PDFDocumentDemo.Annotations;

namespace PDFDocumentDemo.Workers
{
   // Generate the thumbnails for the pages in a document
   class GenerateThumbnailsWorker : ThreadedPageWorker
   {
      public GenerateThumbnailsWorker() :
         base()
      {
      }

      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            Stop();
         }

         base.Dispose(disposing);
      }

      private PDFDocument _document;
      private int _thumbnailWidth;
      private int _thumbnailHeight;

      public void Start(PDFDocument document, int thumbnailWidth, int thumbnailHeight)
      {
         _document = document;
         _thumbnailWidth = thumbnailWidth;
         _thumbnailHeight = thumbnailHeight;

         StartWork(_document.Pages.Count);
      }

      public void Stop()
      {
         StopWork();

         _document = null;
      }

      protected override ThreadedPageWorkerPageProcessedEventArgs ProcessPage(int pageNumber)
      {
         // Get the thumbnail for this page
         try
         {
            using (RasterCodecs codecs = new RasterCodecs())
            {
               DocumentAnnotations.SetRasterCodecsOptions(_document, codecs, pageNumber);
               RasterImage thumbnailImage = _document.GetThumbnail(codecs, pageNumber, _thumbnailWidth, _thumbnailHeight);
               return new ThreadedPageWorkerPageProcessedEventArgs(pageNumber, thumbnailImage, null);
            }
         }
         catch(Exception e)
         {
            return new ThreadedPageWorkerPageProcessedEventArgs(pageNumber, null, e);
         }
      }
   }
}
