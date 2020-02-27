// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Leadtools.Codecs;

//This project is provided as an example of how to implement the following three interfaces: IMasterFormsRepository, IMasterFormsCategory, and IMasterForm.
//This demo is not intended to be a running one. These three interfaces are used with Leadtools.Forms.Auto.AutoFormsEngine class to store master forms and categorize them.
//The code provided in this project is the default implementation for the three mentioned interfaces that is shipped with LEADTOOLS SDK for Forms
//This project may help a user to build his own implementation of these interfaces that fits his application, for example, database repository.

namespace Leadtools.Forms.Auto
{
   public class DiskMasterFormsRepositoryExample : IMasterFormsRepository
   {
      private RasterCodecs _rasterCodecsInstance;
      private DiskMasterFormsCategoryExample _rootCategory;
      private string _path;

      // Get or set the RasterCodecs objcte to use when loading forms
      public RasterCodecs RasterCodecsInstance { get { return _rasterCodecsInstance; } }

      // Get all the root categories in this repository
      public IMasterFormsCategory RootCategory { get { return _rootCategory; } }

      // Get all the path
      public string Path { get { return _path; } }

      public void Refresh()
      {
         (_rootCategory as DiskMasterFormsCategoryExample).Refresh();
      }

      public DiskMasterFormsRepositoryExample(RasterCodecs rasterCodecsInstance, string path)
      {
         DiskMasterFormRepositoryInternal(rasterCodecsInstance, path);//, true);
      }
      
      private void DiskMasterFormRepositoryInternal(RasterCodecs rasterCodecsInstance, string rootPath)
      {
         string path = System.IO.Path.GetFullPath(rootPath);
         // Check if we need to create the root directory
         if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
         _rasterCodecsInstance = rasterCodecsInstance;
         _path = path;
         // Create the root category
         _rootCategory = new DiskMasterFormsCategoryExample(this, "root", _path, null);
         Refresh();
      }
   }
}
