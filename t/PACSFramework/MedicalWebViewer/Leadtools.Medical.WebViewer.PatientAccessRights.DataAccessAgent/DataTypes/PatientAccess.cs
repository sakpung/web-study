// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.WebViewer.PatientAccessRights
{
   /// <summary>
   /// structure that holds the patient ID and either user name or role name in the AccessKey field
   /// </summary>
   public class PatientAccessKey
   {
      public string PatientID  { get ; set ; }
      public string AccessKey { get ; set ; }
   }

   public class AeAccessKey
   {
      private string _aeTitle;
      private string _accessKey;

      public AeAccessKey()
      {

         _aeTitle = string.Empty;
         _accessKey = string.Empty;
      }

      public string AeTitle
      {
         get
         {
            return _aeTitle;
         }
         set
         {
            _aeTitle = value.Trim();
         }
      }
      public string AccessKey
      {
         get
         {
            return _accessKey;
         }
         set
         {
            _accessKey = value.Trim();
         }
      }
      public string GetUniqueId()
      {
         string uniqueId = string.Format("{0}\n{1}", AeTitle,AccessKey);
         return uniqueId;
      }
   }
}
