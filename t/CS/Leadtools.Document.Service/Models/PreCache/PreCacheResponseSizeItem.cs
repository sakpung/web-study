// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.PreCache
{
   [DataContract]
   public class PreCacheResponseSizeItem
   {
      /// <summary>
      /// The mapped documentId of the cached document.
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;

      /// <summary>
      /// The value of MaximumImagePixelSize
      /// </summary>
      [DataMember(Name = "maximumImagePixelSize")]
      public int MaximumImagePixelSize;

      /// <summary>
      /// The time it took to pre-cache the document, if relevant to the operation.
      /// Else it will be zero.
      /// </summary>
      [DataMember(Name = "seconds")]
      public double Seconds;

      /// <summary>
      /// The times this item has been accessed, if relevant to the operation.
      /// Else it will be zero.
      /// </summary>
      [DataMember(Name = "reads")]
      public int Reads;
   }
}
