// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Forms.Recognition;
using Leadtools.Forms.Processing;

//This project is provided as an example of how to implement the following three interfaces: IMasterFormsRepository, IMasterFormsCategory, and IMasterForm.
//This demo is not intended to be a running one. These three interfaces are used with Leadtools.Forms.Auto.AutoFormsEngine class to store master forms and categorize them.
//The code provided in this project is the default implementation for the three mentioned interfaces that is shipped with LEADTOOLS SDK for Forms
//This project may help a user to build his own implementation of these interfaces that fits his application, for example, database repository.

namespace Leadtools.Forms.Auto
{
   public class DiskMasterFormExample : IMasterForm
   {
      private string _name;
      private string _path;
      private IMasterFormsCategory _parent;
      private FormRecognitionAttributes _attributes;
      private FormProcessingEngine _processingEngine;
      private IMasterFormsRepository _repository;
      private int _candidatePageNumber;

      // Name of this master form
      public string Name { get { return _name; } }

      //The Repository that this Master belongs to
      public IMasterFormsRepository Repository { get { return _repository; } }

      //Parent category that contains this Master Form
      public IMasterFormsCategory Parent { get { return _parent; } }

      // Get all the path
      public string Path { get { return _path; } }

      // Get/set all the CandidatePageNumber
      public int CandidatePageNumber { get { return _candidatePageNumber; } set { _candidatePageNumber = value; }}

      // Get the attributes of this master form (from attributes you can get last access date/time/etc)
      public FormRecognitionAttributes ReadAttributes()
      {
         if(_attributes == null)
         {
            if(!File.Exists(_path + ".bin"))
               return null;
            byte[] data = File.ReadAllBytes(_path +".bin");
            _attributes = new FormRecognitionAttributes();
            _attributes.SetData(data);
         }
         return _attributes;
      }

      // Update the attributes of this master form
      public void WriteAttributes(FormRecognitionAttributes attributes)
      {
         if(attributes == null)
            throw new ArgumentNullException("attributes");
         _attributes = null;
         byte[] data = attributes.GetData();
         File.WriteAllBytes(_path + ".bin", data);
      }

      // Read the fields of this master form
      public FormPages ReadFields()
      {
         if(!File.Exists(_path + ".xml"))
            return null;
         _processingEngine.LoadFields(_path + ".xml");
         //to create new forms pages
         FormProcessingEngine tempProcessingEngine = new FormProcessingEngine();
         FormPages formFields = tempProcessingEngine.Pages;
         formFields.AddRange(_processingEngine.Pages);
         return formFields;
      }
      
      // Update the fields of this master form
      public void WriteFields(FormPages fields)
      {
         if(fields == null)
            throw new ArgumentNullException("fields");
         _processingEngine.Pages.Clear();
         _processingEngine.Pages.AddRange(fields);
         _processingEngine.SaveFields(_path + ".xml");
      }

      // Read the form (RasterImage) attached to this master form (optional, might return null)
      public RasterImage ReadForm()
      {
         if(!File.Exists(_path + ".tif"))
            return null;
         return _repository.RasterCodecsInstance.Load(_path + ".tif", 1, CodecsLoadByteOrder.Bgr, 1, -1);
      }

      // Update the form (RasterImage) attached to this master form
      public void WriteForm(RasterImage form)
      {
         if(form == null)
            throw new ArgumentNullException("form");
         form.DitheringMethod = RasterDitheringMethod.None;
         _repository.RasterCodecsInstance.Save(form, _path + ".tif", RasterImageFormat.Tif, 1, 1, -1, 1, CodecsSavePageMode.Overwrite);
      }

      internal DiskMasterFormExample(IMasterFormsRepository repository, string name, string path, IMasterFormsCategory parent)
      {
         _repository = repository;
         _processingEngine = new FormProcessingEngine();
         _attributes = null;
         _name = name;
         _parent = parent;
         _path = path;
      }
#if LEADTOOLS_V19_OR_LATER
      bool _isExtendable;

      public bool IsExtendable
      {
         get
         {
            if (_isExtendable == true)
               return _isExtendable;

            FormPages pages = this.ReadFields();
            if (pages == null)
               return false;
            foreach (FormPage page in pages)
               foreach (FormField field in page)
                  if (field is TableFormField)
                  {
                     _isExtendable = true;
                     return true;
                  }
            return false;
         }
      }
#endif//#if LEADTOOLS_V19_OR_LATER
   }
}
