// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public class TextDocumentOptions : DocumentOptions
   {
      [DataMember(Name = "documentType")]
      public TextDocumentType DocumentType = TextDocumentType.Ansi;
      [DataMember(Name = "addPageNumber")]
      public bool AddPageNumber = false;
      [DataMember(Name = "addPageBreak")]
      public bool AddPageBreak = false;
      [DataMember(Name = "formatted")]
      public bool Formatted = false;

      public override DocumentFormat Format { get { return DocumentFormat.Text; } }
   }
}
