// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Forms.Common;
using Leadtools.Forms.Recognition;
using Leadtools.Forms.Processing;

namespace FormsDemo
{
   public class FilledForm
   {
      private string _fileName;
      private string _name;
      private RasterImage _image;
      private FormRecognitionAttributes _attributes;
      private MasterForm _master;
      private FormRecognitionResult _result;
      private IList<PageAlignment> _alignment;
      private FormPages _processingPages;

      public FilledForm()
      {
         _fileName = null;
         _name = null;
         _image = null;
         _attributes = null;
         _master = null;
         _result = null;
         _alignment = null;
      }

      public string FileName
      {
         get { return _fileName; }
         set { _fileName = value; }
      }

      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

      public IList<PageAlignment> Alignment
      {
         get { return _alignment; }
         set { _alignment = value; }
      }

      public FormRecognitionResult Result
      {
         get { return _result; }
         set { _result = value; }
      }

      public RasterImage Image
      {
         get { return _image; }
         set { _image = value; }
      }

      public FormRecognitionAttributes Attributes
      {
         get { return _attributes; }
         set { _attributes = value; }
      }

      public MasterForm Master
      {
         get { return _master; }
         set { _master = value; }
      }

      public FormPages ProcessingPages
      {
         get { return _processingPages; }
         set { _processingPages = value; }
      }
   }
}
