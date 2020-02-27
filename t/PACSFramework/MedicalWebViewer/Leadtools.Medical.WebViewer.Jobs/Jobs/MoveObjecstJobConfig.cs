// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;

using System.Text;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Dicom;

namespace Leadtools.Medical.WebViewer.Jobs
{
   public class MoveObjectsJobConfig
   {
      public string PatientID;
      public string StudyInstanceUID;
      public string SeriesInstanceUID;
      public string SOPInstanceUID;

      public MoveObjectsJobConfig()
      {
      }

      public void Config(MoveObjectsJob MoveJob)
      {
         try
         {
            if (String.IsNullOrEmpty(PatientID) && String.IsNullOrEmpty(StudyInstanceUID) && String.IsNullOrEmpty(SeriesInstanceUID) && String.IsNullOrEmpty(SOPInstanceUID))
            {
               throw new ArgumentException("Should provide one key to perform c-move");
            }

            MoveJob.DataSet = new DicomDataSetAdapter()
            {
               PatientID = PatientID,
               StudyInstanceUID = StudyInstanceUID,
               SeriesInstanceUID = SeriesInstanceUID,
               SOPInstanceUID = SOPInstanceUID
            };

         }
         catch (System.Exception e)
         {
            #region LOG
            {
               string message = @"MoveObjectsJobConfig Failure: " + e.Message;
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, message, null, null);
            }
            #endregion	

            throw;
         }
      }
   }
}
