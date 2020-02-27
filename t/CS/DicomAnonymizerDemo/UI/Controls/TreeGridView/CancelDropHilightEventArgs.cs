// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DicomAnonymizer.UI.Controls
{
   public class CancelDropHilightEventArgs : CancelEventArgs
   {
      private int _RowIndex = -1;

      public int RowIndex
      {
         get 
         { 
            return _RowIndex; 
         }       
      }

      public CancelDropHilightEventArgs(int rowIndex)
      {
         _RowIndex = rowIndex;
      }
   }
}
