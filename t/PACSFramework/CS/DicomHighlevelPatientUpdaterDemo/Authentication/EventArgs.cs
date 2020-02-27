// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DicomDemo.Authentication
{
   public class ValidatePasswordEventArgs : EventArgs
   {
      public bool Valid { get; set; }
      public string Password { get; set; }
      public string ConfirmPassword { get; set; }
   }
}
