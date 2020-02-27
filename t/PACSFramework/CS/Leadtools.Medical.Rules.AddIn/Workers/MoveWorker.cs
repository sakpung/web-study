// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Leadtools.Dicom.Scu;

namespace Leadtools.Medical.Rules.AddIn.Workers
{
   public class MoveWorker : BackgroundWorker
   {
      private DicomScp _Server;
      private List<string> _AeTitles = new List<string>();
      private MoveInfo _MoveInfo;

      public int Timeout { get; set; }
      public int NumberOfRetries { get; set; }
      public bool EnableRetry { get; set; }

      public MoveWorker(DicomScp server, List<string> aetitles, MoveInfo moveInfo)
      {
         _Server = server;
         _MoveInfo = moveInfo;
         if (aetitles != null && aetitles.Count > 0)
            _AeTitles.AddRange(aetitles);

         DoWork += new DoWorkEventHandler(MoveWorker_DoWork);
      }

      void MoveWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         MoveClient client = new MoveClient(_Server, _AeTitles);

         client.EnableRetry = EnableRetry;
         client.Timeout = Timeout;
         client.NumberOfRetries = NumberOfRetries;
         client.Move(_MoveInfo);
      }
   }
}
