// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public class SvgDocumentOptions : DocumentOptions
   {
      public override DocumentFormat Format { get { return DocumentFormat.Svg; } }
   }
}
