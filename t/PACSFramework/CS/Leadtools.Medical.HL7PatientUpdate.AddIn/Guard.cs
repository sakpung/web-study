// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Leadtools.Medical.HL7PatientUpdate.AddIn
{
   internal static class Guard
   {
      public static void ArgumentNotNull(object argumentValue,
                                         string argumentName)
      {
         if (argumentValue == null) throw new ArgumentNullException(argumentName);
      }

      public static void ArgumentNotNullOrEmpty(string argumentValue,
                                               string argumentName)
      {
         if (argumentValue == null) throw new ArgumentNullException(argumentName);
         if (argumentValue.Length == 0) throw new ArgumentException("The provided string argument must not be empty.", argumentName);
      }

      public static void ArgumentNotNullOrEmpty(IList argumentValue,
                                              string argumentName)
      {
         if (argumentValue == null) throw new ArgumentNullException(argumentName);
         if (argumentValue.Count == 0) throw new ArgumentException("The provided string argument must not be empty.", argumentName);
      }
   }
}
