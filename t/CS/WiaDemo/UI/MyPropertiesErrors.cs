// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace WiaDemo
{
   struct MyPropertiesErrors
   {
      string _deviceName;
      string _itemName;
      string _propertyName;
      string _propertyValue;
      string _errorCodeString;

      public static MyPropertiesErrors Empty
      {
         get
         {
            return new MyPropertiesErrors(0);
         }
      }

      public MyPropertiesErrors(int dummy)
      {
         _deviceName = string.Empty;
         _itemName = string.Empty;
         _propertyName = string.Empty;
         _propertyValue = string.Empty;
         _errorCodeString = string.Empty;
      }

      public string DeviceName
      {
         get
         {
            return _deviceName;
         }
         set
         {
            _deviceName = value;
         }
      }

      public string ItemName
      {
         get
         {
            return _itemName;
         }
         set
         {
            _itemName = value;
         }
      }

      public string PropertyName
      {
         get
         {
            return _propertyName;
         }
         set
         {
            _propertyName = value;
         }
      }

      public string PropertyValue
      {
         get
         {
            return _propertyValue;
         }
         set
         {
            _propertyValue = value;
         }
      }

      public string ErrorCodeString
      {
         get
         {
            return _errorCodeString;
         }
         set
         {
            _errorCodeString = value;
         }
      }
   }
}
