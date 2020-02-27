// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public class PdfCustomBookmark
   {
      [DataMember(Name = "levelNumber")]
      public int LevelNumber;
      [DataMember(Name = "pageNumber")]
      public int PageNumber;
      [DataMember(Name = "xCoordinate")]
      public double XCoordinate;
      [DataMember(Name = "yCoordinate")]
      public double YCoordinate;
      [DataMember(Name = "name")]
      public string Name;
   }
}
