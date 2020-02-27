// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Wia;

namespace PrintToPACSDemo
{
   struct MyFormat
   {
      WiaTransferMode   _transferMode;
      string            _transferModeString;
      string            _formatName;
      string            _formatCLSID;
      System.Guid       _guidFormat;

      public static MyFormat Empty
      {
         get
         {
            return new MyFormat(0);
         }
      }

      public MyFormat(int dummy)
      {
         _transferMode = WiaTransferMode.None;
         _transferModeString = string.Empty;
         _formatName = string.Empty;
         _formatCLSID = string.Empty;
         _guidFormat = Guid.Empty;
      }

      public WiaTransferMode TransferMode
      {
         get
         {
            return _transferMode;
         }
         set
         {
            _transferMode = value;
         }
      }

      public string TransferModeString
      {
         get
         {
            return _transferModeString;
         }
         set
         {
            _transferModeString = value;
         }
      }

      public string FormatName
      {
         get
         {
            return _formatName;
         }
         set
         {
            _formatName = value;
         }
      }

      public string FormatCLSID
      {
         get
         {
            return _formatCLSID;
         }
         set
         {
            _formatCLSID = value;
         }
      }

      public System.Guid Format
      {
         get
         {
            return _guidFormat;
         }
         set
         {
            _guidFormat = value;
         }
      }
   }
}
