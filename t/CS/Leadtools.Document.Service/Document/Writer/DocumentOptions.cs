// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public abstract class DocumentOptions
   {
      [DataMember(Name = "pageRestriction")]
      public DocumentPageRestriction PageRestriction = DocumentPageRestriction.Default;
      [DataMember(Name = "emptyPageWidth")]
      public double EmptyPageWidth = 8.5;
      [DataMember(Name = "emptyPageHeight")]
      public double EmptyPageHeight = 11;
      [DataMember(Name = "emptyPageResolution")]
      public int EmptyPageResolution = 0;
      [DataMember(Name = "documentResolution")]
      public int DocumentResolution = 0;
      [DataMember(Name = "maintainAspectRatio")]
      public bool MaintainAspectRatio = false;

      public abstract DocumentFormat Format { get; }
   }
}
