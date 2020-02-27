// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Dicom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadtools.Medical.HL7MWL.AddIn
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

      public static void ArgumentNotNullOrEmpty(DicomDateRangeValue? dateRange, string argumentName)
      {
         if (dateRange == null)
            throw new ArgumentNullException(argumentName);
      }
   }
}
