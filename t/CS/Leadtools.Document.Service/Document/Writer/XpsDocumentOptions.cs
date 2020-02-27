// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public class XpsDocumentOptions : DocumentOptions
   {
      [DataMember(Name = "dropObjects")]
      public DocumentDropObjects DropObjects = DocumentDropObjects.None;

      public override DocumentFormat Format { get { return DocumentFormat.Xps; } }
   }
}
