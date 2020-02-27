// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Converter
{
   [DataContract]
   public enum DocumentConverterJobStatus
   {
      Success = 0,
      SuccessWithErrors = 1,
      Aborted = 2
   }
}
