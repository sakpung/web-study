// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DicomAnonymizer.UI.Controls
{
   public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
   {
      public DataGridViewDisableButtonColumn()
      {
         this.CellTemplate = new DataGridViewDisableButtonCell();
      }
   }
}
