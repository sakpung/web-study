// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Leadtools.Dicom;
using System.ServiceModel;

namespace Leadtools.Medical.WebViewer.Addins
{
    class Check
    {
        public static void ArgumentNotNull(object argumentValue,
                                           string argumentName)
        {
            if (argumentValue == null) 
                ThrowNull(argumentName);
        }

        public static void ArgumentNotNullOrEmpty(string argumentValue,
                                                 string argumentName)
        {
            if (argumentValue == null)
                ThrowNull(argumentName);
            if (argumentValue.Length == 0) throw new ArgumentException(argumentName + " must not be empty.");
        }

        public static void ArgumentNotNullOrEmpty(IList argumentValue,
                                                string argumentName)
        {
            if (argumentValue == null)
                ThrowNull(argumentName);
            if (argumentValue.Count == 0) throw new FaultException(argumentName + " list must not be empty.");
        }

        public static void ArgumentNotNullOrEmpty(DicomDateRangeValue? dateRange, string argumentName)
        {
            if (dateRange == null)
                ThrowNull(argumentName);
        }

        private static void ThrowNull(string argumentName)
        {
            throw new FaultException(argumentName + " cannot be null");
        }
    }
}
