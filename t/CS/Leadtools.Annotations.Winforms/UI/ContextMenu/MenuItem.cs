// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using Leadtools.Annotations.Engine;

namespace Leadtools.Annotations.WinForms
{
   internal class ObjectMenuItem : MenuItem
   {
      private ObjectMenuItem() { }

      internal ObjectMenuItem(int id, string text) :
         base(text)
      {
         _id = id;
         this.RadioCheck = true;
      }

      private int _id;
      public int Id
      {
         get { return _id; }
      }
   }

   internal class RubberStampMenuItem : MenuItem
   {
      private RubberStampMenuItem() { }

      internal RubberStampMenuItem(string text, AnnRubberStampType type) :
         base(text)
      {
         _type = type;
      }

      private AnnRubberStampType _type;
      public AnnRubberStampType Type
      {
         get { return _type; }
      }
   }
}
