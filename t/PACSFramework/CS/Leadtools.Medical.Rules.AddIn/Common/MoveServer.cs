// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scu;
using Leadtools.Medical.Rules.AddIn.Workers;
using System.IO;
using System.Xml.Serialization;

namespace Leadtools.Medical.Rules.AddIn.Common
{
   public class MoveServer : ResendServer
   {
      public MoveInfo Info { get; set; }

      public string DestinationAE { get; set; }

      [XmlIgnore]
      public string FileName { get; set; }

      public MoveServer()
      {
      }

      public MoveServer(DicomScp scp)
         : base(scp)
      {
      }

      public override void Save()
      {
         string name = string.Format("Move-{0}-{1}-{2}.fail", Info.MoveType,Scp.AETitle, Info.Id);
         string fileName = Path.Combine(Module.FailureDirectory, name);        

         SerializeToXml(fileName);
      }

      public void Delete()
      {
         if (!string.IsNullOrEmpty(FileName))
         {
            File.Delete(FileName);
         }
      }
   }
}
