// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class UploadDocumentRequest : Request
   {
      /// <summary>
      /// The uri, retrieved from BeginUpload, that is used for uploading.
      /// </summary>
      [DataMember(Name = "uri")]
      public Uri Uri;

      /// <summary>
      /// The data to upload as Base64 string. If this value is null, then Buffer is used.
      /// </summary>
      [DataMember(Name = "data")]
      public string Data;

      /// <summary>
      /// The data to upload. The length of this buffer must be set in BufferLength. If this value is null, then Data is used.
      /// </summary>
      [DataMember(Name = "buffer")]
      public byte[] Buffer;

      /// <summary>
      /// The length of Buffer in bytes.
      /// </summary>
      [DataMember(Name = "bufferLength")]
      public int BufferLength;
   }
}
