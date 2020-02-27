// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Leadtools.Medical.AutoCopy.AddIn
{
    public static class Extensions
    {
       public static void Check(this ListView listview, bool check)
       {
          if(listview == null)
             return;

          foreach(ListViewItem item in listview.Items)
          {
             item.Checked = check;
          }
       }
    }
}
