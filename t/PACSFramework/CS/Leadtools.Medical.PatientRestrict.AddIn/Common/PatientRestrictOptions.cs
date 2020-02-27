// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************


namespace Leadtools.Medical.PatientRestrict.AddIn.Common
{
   public class PatientRestrictOptions
   {
      public bool PatientRestrictEnabled { get;set;}
      public int PageSize { get;set; }

      public PatientRestrictOptions()
      {
         PatientRestrictEnabled = false;
         PageSize = 10;
      }
   }
}
