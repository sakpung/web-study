// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Leadtools.Medical.WebViewer.DataContracts
{
   /// <summary>
   /// Status for the download
   /// </summary>
   
   public enum DownloadStatus
   {
      
      Idle,

      
      Started,

      
      Completed,

      
      Error,

      
      Aborted,

      
      All,
   }

   /// <summary>
   /// Download info
   /// </summary>
   [DataContract]
   public class DownloadInfo
   {
      /// <summary>
      /// The download ID, a unique GUID of interest only inside IDownloadService
      /// </summary>
      [DataMember]
      public string Id { get; set; }

      /// <summary>
      /// Original server connection
      /// </summary>
      [DataMember]
      public PACSConnection Server { get; set; }

      /// <summary>
      /// Original client connection
      /// </summary>
      [DataMember]
      public ClientConnection Client { get; set; }

      /// <summary>
      /// The original query used
      /// </summary>
      [DataMember]
      public string PatientID { get ;set;}
      [DataMember]
      public string StudyInstanceUID { get ;set;}
      [DataMember]
      public string SeriesInstanceUID { get ;set;}
      [DataMember]
      public string SOPInstanceUID { get ;set;}
      
      /// <summary>
      /// The download status
      /// </summary>
      [DataMember]
      public DownloadStatus Status { get; set; }

      /// <summary>
      /// If Status is Error, this should contain the error message
      /// </summary>
      [DataMember]
      public string ErrorMessage { get; set; }

      /// <summary>
      /// user defined data (string)
      /// </summary>
      [DataMember]
      public string UserData { get; set; }
   }

   /// <summary>
   /// Download status
   /// </summary>
   [DataContract]
   public class JobStatus
   {
      /// <summary>
      /// The download ID, a unique GUID of interest only inside IDownloadService
      /// </summary>
      [DataMember]
      public string Id { get; set; }
      
      /// <summary>
      /// The download status
      /// </summary>
      [DataMember]
      public DownloadStatus Status { get; set; }

      /// <summary>
      /// If Status is Error, this should contain the error message
      /// </summary>
      [DataMember]
      public string ErrorMessage { get; set; }
   }
}
