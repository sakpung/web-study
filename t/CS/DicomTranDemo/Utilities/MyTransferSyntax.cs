// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace DicomTranDemo
{
   class MyTransferSyntax
   {
      public string szUID;
      public string szDescription;

      public override string ToString()
      {
         return szDescription;
      }
   }
}
