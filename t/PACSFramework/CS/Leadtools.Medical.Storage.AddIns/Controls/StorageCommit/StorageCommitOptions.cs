// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Xml.Serialization;

namespace Leadtools.Medical.Storage.AddIns.Controls.StorageCommit
{
   [Serializable]   
   [XmlRoot(Namespace="")]
   public class StorageCommitOptions // : ConfigurationElement
   {

      public StorageCommitOptions()
      {
         _reportType = ReportType.SameAssociation;
      }

      private ReportType _reportType;
      public ReportType reportType
      {
         get { return _reportType; }
         set { _reportType = value; }
      }

      public static bool IsEqual(StorageCommitOptions options1, StorageCommitOptions options2)
      {
         if (options1 == null)
         {
            return (options2 == null);
         }

         if (options2 == null)
         {
            // Options1 is not null, so return false
            return false;
         }

         return (options1.reportType == options2.reportType);
      }

   }

   public enum ReportType
   {
      SameAssociation = 0,
      NewAssociation = 1,
      ConditionalAssociation = 2,
   }

}
