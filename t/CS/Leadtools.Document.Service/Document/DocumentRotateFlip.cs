// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentRotateFlip
   {
      [DataMember(Name = "isFlipped")]
      public bool IsFlipped;

      [DataMember(Name = "rotationAngle")]
      public int RotationAngle;
   }
}
