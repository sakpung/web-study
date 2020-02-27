// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;

using System.Text;
using Leadtools;
using Leadtools.Codecs;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;

namespace Leadtools.Medical.WebViewer.Jobs
{
   [Serializable]   
   public class StorageDeleteJob : StorageJob
   {
      public StorageDeleteJob():base()
      {
      }

      public override void Dispose(bool bUnmanaged)
      {
         base.Dispose();
      }
      override protected void TryAbort()
      {
         
      }
      public string Owner { get; set; }
      public string PatientID{ get; set; }
      public string StudyInstanceUID { get; set; }
      public string SeriesInstanceUID{ get; set; }
      public string SOPInstanceUID { get; set; }

      int Delete()
      {
         if (null == AuthorizedDataAccessAgent)
         {
            throw new ArgumentException();
         }

         int totalDeletedImagesCount = 0;

         MatchingParameterCollection matchingParamCollection;
         MatchingParameterList matchingParamList;

         matchingParamCollection = new MatchingParameterCollection();
         matchingParamList = new MatchingParameterList();

         matchingParamCollection.Add(matchingParamList);

         if (!string.IsNullOrEmpty(SOPInstanceUID))
         {
            Instance imageInstance = new Instance(SOPInstanceUID);

            matchingParamList.Add(imageInstance);

         }
         if (!string.IsNullOrEmpty(SeriesInstanceUID))
         {
            Series seriesEntity = new Series(SeriesInstanceUID);

            matchingParamList.Add(seriesEntity);
         }
         if (!string.IsNullOrEmpty(StudyInstanceUID))
         {
            Study studyEntity = new Study(StudyInstanceUID);

            matchingParamList.Add(studyEntity);
         }
         if (!string.IsNullOrEmpty(PatientID))
         {         
            Patient patientEntity = new Patient(PatientID);

            matchingParamList.Add(patientEntity);
         }

         totalDeletedImagesCount = AuthorizedDataAccessAgent.DeleteInstance(matchingParamCollection, Owner, null);

         return totalDeletedImagesCount;
      }

      override public void StartJob()
      {
         try
         {
            if (IsAbortTriggered())
            {
               JobAborted();
               return;
            }

            JobPending();
            
            {
               JobRunning();
               Delete();               
               JobSucceeded();               
            }
         }
         catch (System.Exception ex)
         {            
            JobFailed(ex.Message);
         }
         finally
         {
            
         }
      }
   }
}
