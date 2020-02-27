// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public class DocxDocumentOptions : DocumentOptions
   {
      [DataMember(Name = "textMode ")]
      public DocumentTextMode TextMode = DocumentTextMode.Auto;

      [DataMember(Name = "dropObjects ")]
      public DocumentDropObjects DropObjects = DocumentDropObjects.None;

      public override DocumentFormat Format { get { return DocumentFormat.Docx; } }
   }
}
