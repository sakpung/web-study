// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom;
using System.Xml.Serialization;
using System.IO;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.Rules.AddIn.Common
{
   [Serializable]
   public class ResendServer
   {
      private DicomScp _Scp;

      public DicomScp Scp
      {
         get
         {
            return _Scp;
         }
         set
         {
            _Scp = value;
         }
      }

      private string _LastStatus = string.Empty;

      /// <summary>
      /// Gets or sets the last status that occured when trying to communicate with this server.
      /// </summary>
      /// <value>
      /// The last status.
      /// </value>
      public string LastStatus
      {
         get { return _LastStatus; }
         set { _LastStatus = value; }
      }

      private int _RetryCount = 0;

      /// <summary>
      /// Gets or sets the retry count.
      /// </summary>
      /// <value>
      /// The retry count.
      /// </value>
      public int RetryCount
      {
         get { return _RetryCount; }
         set { _RetryCount = value; }
      }

      public string IPAddress { get; set; }

      public string AETitle { get; set; }
      
      public ResendServer()
      {
      }

      public ResendServer(DicomScp scp)
      {
         Scp = scp;
         IPAddress = scp.PeerAddress.ToString();
      }      

      public virtual void Save()
      {         
      }

      protected virtual void SerializeToXml(string filename)
      {
         using (Stream file = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
         {
            XmlSerializer s = new XmlSerializer(GetType());

            s.Serialize(file, this);
            file.Close();
         }
      }

      public bool Verify(string AETitle)
      {
         StoreScu scu = new StoreScu();

         Scp.PeerAddress = System.Net.IPAddress.Parse(IPAddress);
         scu.AETitle = AETitle;
         return scu.Verify(Scp);
      }
   }
}
