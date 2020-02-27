// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Document.Writer;
using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Converter
{
   [DataContract]
   public class StatusJobData
   {
      [DataMember(Name = "jobToken")]
      public string JobToken;

      [DataMember(Name = "userToken")]
      public string UserToken;

      [DataMember(Name = "statusCacheConfiguration")]
      public string StatusCacheConfiguration;

      [DataMember(Name = "statusCachePolicy")]
      public string StatusCachePolicy;

      [DataMember(Name = "userData")]
      public string UserData;

      [DataMember(Name = "jobStatus")]
      public DocumentConverterJobStatus JobStatus;

      [DataMember(Name = "jobStatusPageNumber")]
      public int JobStatusPageNumber;

      [DataMember(Name = "jobStatusMessage")]
      public string JobStatusMessage;

      [DataMember(Name = "isCompleted")]
      public bool IsCompleted;

      [DataMember(Name = "abort")]
      public bool Abort;

      [DataMember(Name = "jobStartedTimestamp")]
      public string JobStartedTimestamp;

      [DataMember(Name = "jobCompletedTimestamp")]
      public string JobCompletedTimestamp;

      [DataMember(Name = "jobStatusTimestamp")]
      public string JobStatusTimestamp;

      [DataMember(Name = "queryJobStatusTimestamp")]
      public string QueryJobStatusTimestamp;

      [DataMember(Name = "errorMessages")]
      public string[] ErrorMessages;

      [DataMember(Name = "inputDocumentId")]
      public string InputDocumentId;

      [DataMember(Name = "inputDocumentFirstPageNumber")]
      public int InputDocumentFirstPageNumber;

      [DataMember(Name = "inputDocumentLastPageNumber")]
      public int InputDocumentLastPageNumber;

      [DataMember(Name = "outputDocumentId")]
      public string OutputDocumentId;

      [DataMember(Name = "outputDocumentUri")]
      public Uri OutputDocumentUri;

      [DataMember(Name = "outputDocumentName")]
      public string OutputDocumentName;

      [DataMember(Name = "documentFormat")]
      public DocumentFormat DocumentFormat;

      [DataMember(Name = "rasterImageFormat")]
      public RasterImageFormat RasterImageFormat;

      [DataMember(Name = "rasterImageBitsPerPixel")]
      public int RasterImageBitsPerPixel;

      [DataMember(Name = "jobName")]
      public string JobName;

      [DataMember(Name = "annotationsMode")]
      public DocumentConverterAnnotationsMode AnnotationsMode;
   }
}
