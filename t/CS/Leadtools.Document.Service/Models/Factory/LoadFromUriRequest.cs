// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Document;
using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class LoadFromUriRequest : Request
   {
      /// <summary>
      /// The options to use when loading this document (serialized Leadtools.Document.LoadDocumentOptions instance).
      /// </summary>
      [DataMember(Name = "options")]
      public LoadDocumentOptions Options;

      /// <summary>
      /// The URI to the document to be loaded.
      /// </summary>
      [DataMember(Name = "uri")]
      public Uri Uri;

      /// <summary>
      /// The resolution to load the document at. To use the default, pass 0.
      /// </summary>
      [DataMember(Name = "resolution")]
      public int Resolution;

      /// <summary>
      /// If this document is pre-cached, load it directly and do not automatically clone it
      /// </summary>
      [DataMember(Name = "loadPreCached")]
      public bool LoadPreCached;
   }
}
