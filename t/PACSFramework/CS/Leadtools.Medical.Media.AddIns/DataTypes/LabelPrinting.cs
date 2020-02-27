// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Media.AddIns
{
   public class LabelPrinting
   {
      public LabelPrinting ( )
      {
         PrintLabelType = LabelType.ClientText ;
         PrintLabelData = string.Empty ;
      }
      
      public LabelType PrintLabelType
      {
         get ;
         set ;
      }
      
      public string PrintLabelData
      {
         get ;
         set ;
      }

      public override string ToString ( )
      {
         if ( PrintLabelType == LabelType.ClientText )
         {
            return "$ClientText$" ;
         }
         else
         {
            return PrintLabelData ;
         }
      }
   }
}
