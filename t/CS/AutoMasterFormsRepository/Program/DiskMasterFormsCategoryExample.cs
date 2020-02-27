// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections;
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
   public class DiskMasterFormsCategoryExample : IMasterFormsCategory
   {
      private string _name;
      private string _path;
      private IMasterFormsCategory _parent;
      private MasterFormsCategoryCollection _childCategories;
      private MasterFormCollection _masterForms;
      private FormRecognitionEngine _recognitionEngine;
      private IMasterFormsRepository _repository;

      // This category name
      public string Name { get {return _name;} }

      //The Repository that this Master belongs to
      public IMasterFormsRepository Repository { get { return _repository; } }

      // Get all the path
      public string Path { get { return _path; } }

      //Parent category that contains this Category
      public IMasterFormsCategory Parent { get { return _parent; } }

      // Children categories of this category
      public MasterFormsCategoryCollection ChildCategories
      {
         get { return _childCategories; }
      }

      public int ChildCategoriesCount
      {
         get { return _childCategories.Count; }
      }

      public IMasterFormsCategory AddChildCategory(string name)
      {
         string dir = System.IO.Path.Combine(_path, name);

         // Check if already exists
         if(Directory.Exists(dir))
            throw new ArgumentException(string.Format("A category with the name '{0}' already exists", name), "name");

         // Create the directory
         Directory.CreateDirectory(dir);

         // Add it to the child categories
         DiskMasterFormsCategoryExample cat = new DiskMasterFormsCategoryExample(_repository, name, dir, this);
         _childCategories.AddCategory(cat);
         return cat;
      }

      public void DeleteChildCategory(IMasterFormsCategory category)
      {
         // Check
         if(category == null) throw new ArgumentNullException("category");

         if(!_childCategories.Contains(category)) throw new ArgumentException("Category not child of this category", "category");

         DiskMasterFormsCategoryExample diskCategory = category as DiskMasterFormsCategoryExample;
         if(diskCategory == null) throw new Exception("Invalid category type"); // cast above failed

         // Call clear to delete all children of this category
         category.Clear();

         // Remove it from the list
         _childCategories.Remove(category);
      }


      public int MasterFormsCount
      {
         get { return _masterForms.Count; }
      }

      public MasterFormCollection MasterForms
      {
         get { return _masterForms; }
      }

      // Adds a new master form in the given category, parentCategory must not be null
      public IMasterForm AddMasterForm(FormRecognitionAttributes attributes, FormPages fields, RasterImage form)
      {
         if(attributes == null)
            throw new ArgumentException(string.Format("Master Form attributes should be available"), "attributes");
         // Create the file(s)
         FormRecognitionProperties properties = _recognitionEngine.GetFormProperties(attributes);
         DiskMasterFormExample masterForm = new DiskMasterFormExample(_repository, properties.Name, System.IO.Path.Combine(_path, properties.Name), this);
         // Create the file
         masterForm.WriteAttributes(attributes);
         if(fields != null)
            masterForm.WriteFields(fields);
         if(form != null)
            masterForm.WriteForm(form);
         
         _masterForms.AddMasterForm(masterForm);
         return masterForm;
      }

      public IMasterForm AddMasterForm(FormRecognitionAttributes attributes, FormPages fields, string fileName)
      {
         if(attributes == null)
            throw new ArgumentException(string.Format("Master Form attributes should be available"), "attributes");
         // Create the file(s)
         FormRecognitionProperties properties = _recognitionEngine.GetFormProperties(attributes);
         DiskMasterFormExample masterForm = new DiskMasterFormExample(_repository, properties.Name, System.IO.Path.Combine(_path, properties.Name), this);
         // Create the file
         masterForm.WriteAttributes(attributes);
         if(fields != null)
            masterForm.WriteFields(fields);
         if(fileName != null)
            masterForm.WriteForm(_repository.RasterCodecsInstance.Load(fileName, 1, CodecsLoadByteOrder.Bgr, 1, -1));
         
         _masterForms.AddMasterForm(masterForm);
         return masterForm;
      }

      public IMasterForm AddMasterForm(FormRecognitionAttributes attributes, FormPages fields, Stream stream)
      {
         if(attributes == null)
            throw new ArgumentException(string.Format("Master Form attributes should be available"), "attributes");
         // Create the file(s)
         FormRecognitionProperties properties = _recognitionEngine.GetFormProperties(attributes);
         DiskMasterFormExample masterForm = new DiskMasterFormExample(_repository, properties.Name, System.IO.Path.Combine(_path, properties.Name), this);
         // Create the file
         masterForm.WriteAttributes(attributes);
         if(fields != null)
            masterForm.WriteFields(fields);
         if(stream != null)
            masterForm.WriteForm(_repository.RasterCodecsInstance.Load(stream, 1, CodecsLoadByteOrder.Bgr, 1, -1));

         _masterForms.AddMasterForm(masterForm);
         return masterForm;
      }

      public IMasterForm AddMasterForm(FormRecognitionAttributes attributes, FormPages fields, Uri url)
      {
         if(attributes == null)
            throw new ArgumentException(string.Format("Master Form attributes should be available"), "attributes");
         // Create the file(s)
         FormRecognitionProperties properties = _recognitionEngine.GetFormProperties(attributes);
         DiskMasterFormExample masterForm = new DiskMasterFormExample(_repository, properties.Name, System.IO.Path.Combine(_path, properties.Name), this);
         // Create the file
         masterForm.WriteAttributes(attributes);
         if(fields != null)
            masterForm.WriteFields(fields);
         if(url != null)
            masterForm.WriteForm(_repository.RasterCodecsInstance.Load(url, 1, CodecsLoadByteOrder.Bgr, 1, -1));

         _masterForms.AddMasterForm(masterForm);
         return masterForm;
      }

      public void DeleteMasterForm(IMasterForm masterForm)
      {
         // Check
         if(masterForm == null) throw new ArgumentNullException("masterForm");

         DiskMasterFormExample diskMasterForm = masterForm as DiskMasterFormExample;
         if(diskMasterForm == null) throw new Exception("Invalid master form type"); // cast above failed

         // Remove it from its parent list
         _masterForms.Remove(masterForm);

         // Delete attributes file
         string file = diskMasterForm.Path + ".bin";
         if(File.Exists(file))
            File.Delete(file);
         // Delete fields file
         file = diskMasterForm.Path + ".xml";
         if(File.Exists(file))
            File.Delete(file);
         // Delete image file
         file = diskMasterForm.Path + ".tif";
         if(File.Exists(file))
            File.Delete(file);
      }

      public void Clear()
      {
         // Delete the child categories first
         while(_childCategories.Count > 0)
         {
            IMasterFormsCategory childCategory = _childCategories[0];

            // Delete it, this will remove itself from the list
            DeleteChildCategory(childCategory);
         }

         // Delete all the master forms in this category
         while(_masterForms.Count > 0)
         {
            IMasterForm masterForm = _masterForms[0];

            // Delete it, this will remove itself from the list
            DeleteMasterForm(masterForm);
         }

         // At this point, we can safely remove the directory
         Directory.Delete(Path);
      }

      internal void Refresh()
      {
         // Clear the collections
         _childCategories.Clear();
         _masterForms.Clear();

         // Read all the master forms in here
         string[] files = Directory.GetFiles(_path, "*.bin");
         foreach(string file in files)
         {
            string name = System.IO.Path.GetFileNameWithoutExtension(file);
            DiskMasterFormExample masterForm = new DiskMasterFormExample(_repository, name, System.IO.Path.Combine(_path,name), this);
            _masterForms.AddMasterForm(masterForm);
         }

         // Read all the directories
         string[] dirs = Directory.GetDirectories(_path);
         foreach(string dir in dirs)
         {
            DiskMasterFormsCategoryExample category = new DiskMasterFormsCategoryExample(_repository, System.IO.Path.GetFileNameWithoutExtension(dir), dir, this);
            _childCategories.AddCategory(category);
            category.Refresh();
         }
      }

      internal DiskMasterFormsCategoryExample(IMasterFormsRepository repository, string name, string path, IMasterFormsCategory parent)
      {
         _repository = repository;
         _name   = name;
         _parent = parent;
         _path = path;
         _recognitionEngine = new FormRecognitionEngine();
         _childCategories = new MasterFormsCategoryCollection();
         _masterForms = new MasterFormCollection();
      }
   }
}
