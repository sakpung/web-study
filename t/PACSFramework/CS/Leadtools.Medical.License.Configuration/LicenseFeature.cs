// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;

namespace Leadtools.Medical.License.Configuration
{
   public class LicenseFeature : IFeature
   {      
      public LicenseFeature(string id,string description)
      {
         Id = id;
         Description = description;
      }

      #region IFeature Members

      public string AdditionalInfo { get; internal set; }      
      public int? Counter { get; internal set; }      
      public string Description { get; internal set; }      
      public DateTime? Expiration { get; internal set; }      
      public string Id { get; internal set; }      
      public bool IsExpired { get; internal set; }     
      public LicenseFeatureType Type { get; internal set; }

      #endregion
   }
}
