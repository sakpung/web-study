// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Rules.AddIn.Controls
{
   class DoubleBufferedListView : System.Windows.Forms.ListView
   {
      public DoubleBufferedListView()
         : base()
      {
         this.DoubleBuffered = true;
      }
   }

}
