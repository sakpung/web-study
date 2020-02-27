// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public enum DocumentTextImagesRecognitionMode
   {
      Auto, // default
      Disabled,
      Always
   }
}
