// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Svg;

namespace SvgDemo
{
   public class SvgDocumentInformation
   {
      private SvgDocument _document;
      private DocumentText _documentText;
      private bool _showText;

      public SvgDocumentInformation(SvgDocument document)
      {
         _document = document;
         _documentText = null;
         _showText = false;
      }

      public SvgDocument Document
      {
         get { return _document; }
         set
         {
            if (_document != value)
            {
               if (_document != null)
                  _document.Dispose();

               _document = value;
            }
         }
      }

      public bool ShowText
      {
         get { return _showText; }
         set { _showText = value; }
      }

      public DocumentText DocumentText
      {
         get { return _documentText; }
         set { _documentText = value; }
      }
   }
}
