// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Forms.Recognition;
using Leadtools.Forms.Processing;

namespace FormsDemo
{
   public class MasterForm
   {
      private RasterImage _image;
      private FormRecognitionAttributes _attributes;
      private FormRecognitionProperties _properties;
      private FormPages _processingPages;
      private bool _isDirty;

      public MasterForm()
      {
         _image = null;
         _attributes = new FormRecognitionAttributes();
         _properties = FormRecognitionProperties.Empty;
         _processingPages = null;
         _isDirty = false;
      }

      public MasterForm(string name)
      {
         _image = null;
         _attributes = new FormRecognitionAttributes();
         _properties = new FormRecognitionProperties();
         _properties.Name = name;
         _processingPages = null;
         _isDirty = false;
      }

      public bool IsDirty
      {
         get { return _isDirty; }
         set { _isDirty = value; }
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

      public FormRecognitionProperties Properties
      {
         get { return _properties; }
         set { _properties = value; }
      }

      public FormPages ProcessingPages
      {
         get { return _processingPages; }
         set { _processingPages = value; }
      }

#if LEADTOOLS_V19_OR_LATER
      public Boolean IsExtendable
      {
         get
         {
            if (this.ProcessingPages == null)
               return false;

            foreach (FormPage page in this.ProcessingPages)
            {
               foreach (FormField field in page)
               {
                  if (field is TableFormField)
                  {
                     return true;
                  }
               }
            }
            return false;
         }
      }
#endif//#if LEADTOOLS_V19_OR_LATER
   }
}
