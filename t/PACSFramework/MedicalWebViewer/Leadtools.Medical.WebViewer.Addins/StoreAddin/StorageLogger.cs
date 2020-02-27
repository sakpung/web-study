// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Logging.DataAccessLayer;

namespace Leadtools.Medical.WebViewer.Addins
{
    public static class StorageLogger
    {
        public static void CreateDerived(this ILoggingDataAccessAgent logger, string authUser, string originalUID, string newUID)
        {
            if (AuthenticationLogger.CanLog("LogUserActivity"))
            {
                string detail = "Derived Series Create:\n\n";

                detail += "Original SOP UID: " + originalUID + "\n";
                detail += "Derived SOP UID: " + newUID;

                AuthenticationLogger.Log(logger, authUser, detail);
            }
        }

        public static void UploadFile(this ILoggingDataAccessAgent logger, string authUser, string patientName, string sopInstanceUID)
        {
           if (AuthenticationLogger.CanLog("LogUserActivity"))
           {
              string detail = "Upload File: \n\n";

              detail += "Patient Name: " + patientName;
              detail += " SopInstanceUID: " + sopInstanceUID;

              AuthenticationLogger.Log(logger, authUser, detail);
           }
        }

    }
}
