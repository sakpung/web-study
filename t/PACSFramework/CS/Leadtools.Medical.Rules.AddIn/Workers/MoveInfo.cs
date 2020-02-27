// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Rules.AddIn.Workers
{
   public enum MoveType
   {
      Patient,
      Study,
      Series,
      Instance
   }

   [Serializable]
   public class MoveInfo
   {
      public string Id { get; set; }
      public MoveType MoveType { get; set; }

      public MoveInfo()
      {
      }

      public MoveInfo(string id, MoveType type)
      {
         Id = id;
         MoveType = type;
      }
   }
}
