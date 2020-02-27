// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;

namespace Leadtools.Medical.Winforms.EventBrokerArgs
{
   public class DicomFileImportedEventArgs : FileInformationEventArgs
   {
      public DicomFileImportedEventArgs ( string filePath ) : base ( filePath ) 
      {
         Description = string.Empty;
         Status = DicomCommandStatusType.Success;
      }
      
      public DicomFileImportedEventArgs ( string filePath, DicomCommandStatusType status, string description) : base ( filePath ) 
      {
         Status = status;
         Description = description;
      }
      
      public string Description { get ; private set ; }
      
      public DicomCommandStatusType Status { get ; private set ; }
   }

   public class DicomFileExportedEventArgs : FileInformationEventArgs
   {
      public DicomFileExportedEventArgs ( string filePath ) : base ( filePath ) 
      {
         Description = string.Empty;
         Status = DicomCommandStatusType.Success;
      }
      
      public DicomFileExportedEventArgs ( string filePath, DicomCommandStatusType status, string description) : base ( filePath ) 
      {
         Status = status;
         Description = description;
      }
      
      public string Description { get ; private set ; }
      
      public DicomCommandStatusType Status { get ; private set ; }
   }

   public enum MultiDicomImportState
   {
      Starting = 0,
      Ending = 1,
   }

   public class MultiDicomImportEventArgs : EventArgs
   {
      public int TotalFileCount { get; set; }
      public int TotalStored { get; set; }
      public int TotalFailed { get; set; }
      public bool Cancelled { get; set;}
      public MultiDicomImportState State { get; set; }

      public MultiDicomImportEventArgs(int totalFileCount)
      {
         TotalFileCount = totalFileCount;
         TotalStored = 0;
         TotalFailed = 0;
         Cancelled = false;
         State = MultiDicomImportState.Starting;
      }

      public MultiDicomImportEventArgs(bool cancelled, int totalFileCount, int totalStored, int totalFailed)
      {
         TotalFileCount = totalFileCount;
         TotalStored = totalStored;
         TotalFailed = totalFailed;
         Cancelled = cancelled;
         State = MultiDicomImportState.Ending;
      }
   }
}
