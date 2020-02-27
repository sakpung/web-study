// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Dicom.AddIn.Attributes;
using Leadtools.Dicom.Scp ;
using Leadtools.Dicom.Scp.Command ;
using Leadtools.Dicom.Scp.Command.Configuration ;


namespace Leadtools.Medical.Storage.AddIns
{
   public class FindAddIn : IProcessCFind
   {
      public FindAddIn ( ) 
      {}

      #region IProcessCFind Members

      public event MatchFoundDelegate MatchFound;

      [PresentationContext(DicomUidType.PatientRootQueryFind, new byte[] {1,0,1},DicomUidType.ImplicitVRLittleEndian)]
      [PresentationContext(DicomUidType.PatientStudyQueryFind, DicomUidType.ImplicitVRLittleEndian)]
      [PresentationContext(DicomUidType.StudyRootQueryFind, DicomUidType.ImplicitVRLittleEndian)]
      public DicomCommandStatusType OnFind
      (
         DicomClient client, 
         byte presentationId, 
         int messageId, 
         string affectedClass, 
         DicomCommandPriorityType priority, 
         DicomDataSet request
      )
      {
         try
         {
            CFindClientSessionProxy sessionProxy ;
            DicomCommand            command  ;
            

            _messageId      = messageId ;
            _presentationId = presentationId ;
            _clientSession = new ClientSession ( client ) ;
            
            if ( null == DicomCommandFactory.GetInitializationService ( typeof ( QueryCFindCommand ) ) )
            {
               DicomCommandFactory.RegisterCommandInitializationService ( typeof ( QueryCFindCommand ), 
                                                                          new FindCommandInitializationService ( ) ) ;
            }
            
            sessionProxy  = new CFindClientSessionProxy ( _clientSession, presentationId, messageId, affectedClass ) ;
            command       = DicomCommandFactory.GetInstance ( ).CreateCFindCommand ( sessionProxy, request ) ;
            
            _clientSession.CFindResponse += new EventHandler<CFindResponseEventArgs> ( clientSession_CFindResponse ) ;
            
            _clientSession.ProcessCFindRequest ( presentationId, messageId, affectedClass, priority, command  ).WaitOne ( ) ; ;
            
            return _status ;
         }
         finally
         {
            if ( null != request ) 
            {
               request.Dispose ( ) ;
            }
         }
      }

      #endregion

      #region IProcessBreak Members

      public void Break ( BreakType type )
      {
         try
         {
            if ( null != _clientSession ) 
            {
               _clientSession.ProcessCCancelRequest ( _messageId ) ;
            }
         }
         catch
         {}
      }

      #endregion
      
      void clientSession_CFindResponse(object sender, CFindResponseEventArgs e)
      {
         _status = e.Status ;
         
         if ( null != MatchFound &&
             ( _status ==  DicomCommandStatusType.Pending || _status == DicomCommandStatusType.Warning ) )
         {
            try
            {
               e.ResponseDataset.InsertElementAndSetValue ( DicomTag.InstanceAvailability, "ONLINE" ) ;
               
               MatchFound ( this, new MatchFoundEventArgs ( e.ResponseDataset ) ) ;
            }
            finally
            {
               if ( e.ResponseDataset != null ) 
               {
                  e.ResponseDataset.Dispose ( ) ;
               }
            }
         }
         
         e.Handled = true ;
      }
      
      DicomCommandStatusType _status ;
      ClientSession _clientSession ;
      byte _presentationId = 0 ;
      int _messageId = -1 ;
   }
}
