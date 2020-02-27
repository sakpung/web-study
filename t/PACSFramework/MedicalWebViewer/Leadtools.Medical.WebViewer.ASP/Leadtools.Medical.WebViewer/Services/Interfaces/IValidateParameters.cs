// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{
   public interface IValidateParameters<T>
   {
      void Validate(T objectToValidate, string key, object[] results);
   }
}
