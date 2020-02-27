// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;

namespace Leadtools.Medical.Storage.AddIns
{
public class ServiceStatusItem
   {
      public string Name{get;set;}
      public DicomCommandStatusType Value {get;set;}
      
      public ServiceStatusItem(string name, DicomCommandStatusType value)
      {
         Name = name;
         Value = value;
      }

      public override string ToString()
      {
         return Name;
      }
      
      public string ToHexValue()
      {
         return ToHexValue(Convert.ToInt32(Value));
      }
      
      public static string ToHexValue(int n)
      {
         return string.Format("{0:X4}", n);
      }
   }
}
