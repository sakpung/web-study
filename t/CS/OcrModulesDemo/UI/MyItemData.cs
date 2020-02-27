// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace OcrModulesDemo
{
   struct MyItemData
   {
      int _zoneType;
      int _characterFilters;
      int _selectedDocFormatIndex;
      int _selectedOcrModuleIndex;
      string _name;
      string _originalName;
      string _imageFileName;

      public MyItemData(string name, string originalName, int zoneType, int characterFilters, string imageFileName, int selectedDocFormatIndex, int selectedOcrModuleIndex)

      {
         _name = name;
         _originalName = originalName;
         _zoneType = zoneType;
         _characterFilters = characterFilters;

         _imageFileName = imageFileName;
         _selectedDocFormatIndex = selectedDocFormatIndex;
         _selectedOcrModuleIndex = selectedOcrModuleIndex;
      }

      public int ZoneType
      {
         get
         {
            return _zoneType;
         }
         set
         {
            _zoneType = value;
         }
      }

      public int CharacterFilters
      {
         get
         {
            return _characterFilters;
         }
         set
         {
            _characterFilters = value;
         }
      }

      public string Name
      {
         get
         {
            return _name;
         }
         set
         {
            _name = value;
         }
      }

      public string OriginalName
      {
         get
         {
            return _originalName;
         }
         set
         {
            _originalName = value;
         }
      }

      public int SelectedDocumentFormatIndex
      {
         get
         {
            return _selectedDocFormatIndex;
         }
         set
         {
            _selectedDocFormatIndex = value;
         }
      }

      public int SelectedOcrModuleIndex
      {
         get
         {
            return _selectedOcrModuleIndex;
         }
         set
         {
            _selectedOcrModuleIndex = value;
         }
      }

      public string ImageFileName
      {
         get
         {
            return _imageFileName;
         }
         set
         {
            _imageFileName = value;
         }
      }

      public override string ToString()
      {
         return _name;
      }
   }
}
