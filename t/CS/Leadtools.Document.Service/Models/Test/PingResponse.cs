// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Test
{
   [DataContract]
   public class PingResponse : Response
   {
      /// <summary>
      /// A simple message, for testing.
      /// </summary>
      [DataMember(Name = "message")]
      public string Message;

      /// <summary>
      /// The current time, so the user may tell if it was cached.
      /// </summary>
      [DataMember(Name = "time")]
      public DateTime Time;

      /// <summary>
      /// Whether or not the license was able to be checked.
      /// </summary>
      [DataMember(Name = "isLicenseChecked")]
      public bool IsLicenseChecked;

      /// <summary>
      /// Whether or not the license is expired.
      /// </summary>
      [DataMember(Name = "isLicenseExpired")]
      public bool IsLicenseExpired;

      /// <summary>
      /// The type of kernel - evaluation, for example.
      /// </summary>
      [DataMember(Name = "kernelType")]
      public string KernelType;

      /// <summary>
      /// Whether the cache was accessed successfully.
      /// </summary>
      [DataMember(Name = "isCacheAccessible")]
      public bool IsCacheAccessible;

      /// <summary>
      /// The value of the OCREngineStatus enum indicating the OCR Engine Status.
      /// </summary>
      [DataMember(Name = "ocrEngineStatus")]
      public OcrEngineStatus OcrEngineStatus;

      /// <summary>
      /// The service version.
      /// </summary>
      [DataMember(Name = "serviceVersion")]
      public string ServiceVersion;

      /// <summary>
      /// The kernel version.
      /// </summary>
      [DataMember(Name = "kernelVersion")]
      public string KernelVersion;

      /// <summary>
      /// The multi-platform support.
      /// </summary>
      [DataMember(Name = "multiplatformSupportStatus")]
      public string MultiplatformSupportStatus;
   }
}
