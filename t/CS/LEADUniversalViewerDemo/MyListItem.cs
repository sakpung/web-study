// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LEADUniversalViewer
{
   //MyListItem: This is a use-defined class to control the items in the list-box
   public class MyListItem
   {
      private string _fileFullName;
      private string _fileShortName;
      private int _fileType;

      public MyListItem(string strFileName, string strfileShortName, int strFileType)
      {
         this._fileFullName = strFileName;
         this._fileShortName = strfileShortName;
         this._fileType = strFileType;
      }

      public string FileFullName
      {
         get
         {
            return _fileFullName;
         }
      }

      public int FileType
      {
         get
         {
            return _fileType;
         }
      }

      public string FileShortName
      {
         get
         {
            return _fileShortName;
         }
      }
   }
}
