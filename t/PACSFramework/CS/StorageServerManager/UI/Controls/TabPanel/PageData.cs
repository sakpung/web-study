// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Leadtools.Demos.StorageServer.UI
{
   public class PageData
   {
      public PageData ( Control page ) 
      : this ( page, string.Empty )
      {}

      public PageData ( Control page, string text ) 
      : this ( page, text, null ) 
      {}

      public PageData ( Control page, string text, Image image ) 
      {
         Page  = page ;
         Text  = text ;
         Image = image ;
      }

      public string Text { get ; set ;}
      public Image Image { get ; set ;}
      public Control Page { get ; set ;}
   }
}
