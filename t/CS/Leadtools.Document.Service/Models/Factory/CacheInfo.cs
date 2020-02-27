// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class CacheInfo
   {
      /// <summary>
      /// Whether or not the document is virtual.
      /// </summary>
      [DataMember(Name = "isVirtual")]
      public bool IsVirtual;

      /// <summary>
      /// Whether or not the document is loaded already.
      /// </summary>
      [DataMember(Name = "isLoaded")]
      public bool IsLoaded;

      /// <summary>
      /// Whether or not the document has annotations.
      /// </summary>
      [DataMember(Name = "hasAnnotations")]
      public bool HasAnnotations;

      /// <summary>
      /// The document name, if one is set.
      /// </summary>
      [DataMember(Name = "name")]
      public string Name;

      /// <summary>
      /// The reported mimeType of the document.
      /// </summary>
      [DataMember(Name = "mimeType")]
      public string MimeType;

      /// <summary>
      /// Whether or not the mimeType is acceptable.
      /// </summary>
      [DataMember(Name = "isMimeTypeAccepted")]
      public bool IsMimeTypeAccepted;

      /// <summary>
      /// The page count of the document.
      /// </summary>
      [DataMember(Name = "pageCount")]
      public int PageCount;

      /// <summary>
      /// Document user token.
      /// </summary>
      [DataMember(Name = "userToken")]
      public string UserToken;

      /// <summary>
      /// Indicate that the document has a user token
      /// </summary>
      [DataMember(Name = "hasUserToken")]
      public bool HasUserToken;
   }
}
