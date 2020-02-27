// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Collections.Generic;
using System.ComponentModel;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom;
using System.IO;
using Leadtools.Dicom.AddIn;
using System.Threading;

namespace Leadtools.Medical.Rules.AddIn.Workers
{
   public class StoreWorker : BackgroundWorker
   {
      private List<DicomScp> _Scps = new List<DicomScp>();
      private DicomDataSet _DataSet;      

      public int Timeout { get; set; }
      public int NumberOfRetries { get; set; }
      public bool EnableRetry { get; set; }

      /// <summary>
      /// Initializes a new instance of the <see cref="StoreWorker"/> class.
      /// </summary>
      /// <param name="scps">The SCPS.</param>
      /// <param name="ds">The ds.</param>
      /// <param name="copy">if set to <c>true</c> [copy].</param>
      public StoreWorker(List<DicomScp> scps, DicomDataSet ds)
      {                  
         if (ds != null)
         {
            DoWork += new DoWorkEventHandler(StoreWorker_DoWork);
            RunWorkerCompleted += new RunWorkerCompletedEventHandler(StoreWorker_RunWorkerCompleted);

            _Scps.AddRange(scps);

            DicomServer server = ServiceLocator.Retrieve<DicomServer>();
            
            _DataSet = ds;
         }
      }
     
      void StoreWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         _DataSet = null;
      }

      void StoreWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         StoreClient client = new StoreClient(_Scps,_DataSet);

         Thread.CurrentThread.Name = "Dicom Store";
         client.EnableRetry = EnableRetry;
         client.Timeout = Timeout;
         client.NumberOfRetries = NumberOfRetries;
         client.Store();
      }      
   }
}
