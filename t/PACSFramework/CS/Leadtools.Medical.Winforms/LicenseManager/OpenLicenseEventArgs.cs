// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms.LicenseManager
{
   public class OpenLicenseEventArgs : EventArgs
   {    
      private string _FileName;

      public string FileName
      {
         get { return _FileName; }        
      }

      public OpenLicenseEventArgs(string filename)
      {
         _FileName = filename;
      }
   }
}
