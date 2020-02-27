// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scp;
using Leadtools.Dicom;

namespace CSCustomizingWorklistDAL.MyClientSession
{
   class DemoClientSession : ICFindClientSessionProxy
   {
   
      public DemoClientSession ( ) 
      {
         ResponseDS  = new List<DicomDataSet> ( ) ;
      }
      
      public DicomCommandStatusType Status
      {
         get ;
         private set ;
      }
      
      public string StatusMessage
      {
         get ;
         private set ;
      }
      
      public List <DicomDataSet> ResponseDS 
      {
         get ;
         private set ;
      }
      
      #region IDicomCommandClientSessionProxy Members

      public string AbstractClass
      {
         get 
         { 
            return string.Empty ; 
         }
      }

      public int MessageID
      {
         get 
         { 
            return 1; 
         }
      }

      public byte PresentationID
      {
         get 
         { 
            return 1; 
         }
      }

      #endregion

      #region IClientSessionProxy Members

      public string ClientName
      {
         get 
         { 
            return "DEMO" ; 
         }
      }

      public bool IsAssociated
      {
         get 
         { 
            return true ; 
         }
      }

      public bool IsConnected
      {
         get 
         { 
            return true ; 
         }
      }

      public void LogEvent(Leadtools.Logging.LogType eventType, Leadtools.Logging.Medical.MessageDirection messageDirection, string description, Leadtools.Dicom.DicomCommandType command, Leadtools.Dicom.DicomDataSet dataset, Leadtools.Logging.SerializableDictionary<string, object> customInformation)
      {
         
      }

      public string ServerName
      {
         get 
         { 
            return "DEMOSERVER"; 
         }
      }

      #endregion

      #region ICFindClientSessionProxy Members

      public void SendCFindResponse(DicomCommandStatusType status, DicomDataSet responseDataset, string descriptionMessage)
      {
         Status = status ;
         StatusMessage = descriptionMessage ;
         
         if ( null != responseDataset ) 
         {
            ResponseDS .Add ( responseDataset ) ;
         }
      }

      #endregion
   }
   
   
}
