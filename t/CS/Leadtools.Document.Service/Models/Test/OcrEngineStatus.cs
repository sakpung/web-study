// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Test
{
   [DataContract]
   public enum OcrEngineStatus
   {
      /// <summary>
      ///   The OCR Engine was not set, and thus is not being used.
      /// </summary>
      Unset = 0,

      /// <summary>
      ///   An error occurred with the setup.
      /// </summary>
      Error = 1,

      /// <summary>
      ///   The OCR Engine should be working normally.
      /// </summary>
      Ready = 2
   }
}
