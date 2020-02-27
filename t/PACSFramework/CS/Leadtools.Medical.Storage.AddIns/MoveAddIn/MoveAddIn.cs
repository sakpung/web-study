// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Attributes;
using Leadtools.Dicom.Scp ;
using Leadtools.Dicom.Scp.Command ;
using Leadtools.Medical.Winforms.Common;
using Leadtools.Medical.Storage.DataAccessLayer;


namespace Leadtools.Medical.Storage.AddIns
{
   public class MoveAddIn : IProcessCMove, IProcessCGet
   {
      public MoveAddIn ( ) 
      {}

      #region IProcessCGet Members

      [PresentationContext ( DicomUidType.PatientRootQueryGet, DicomUidType.ImplicitVRLittleEndian )]
      [PresentationContext ( DicomUidType.StudyRootQueryGet, DicomUidType.ImplicitVRLittleEndian )]
      public DicomCommandStatusType OnGet(DicomClient client, byte presentationId, int messageId, string affectedClass, DicomCommandPriorityType priority, DicomDataSet request)
      {
          try
         {
            _messageId      = messageId ;
            _presentationId = presentationId ;
            _clientSession = new ClientSession ( client ) ;
            
            CMoveClientSessionProxy sessionProxy = new CMoveClientSessionProxy ( _clientSession, presentationId, messageId, affectedClass );
            DicomCommand command = new CustomCMoveCommand ( sessionProxy, request );
            
            _clientSession.CMoveStoreSubOperation += new EventHandler<CMoveStoreSubOperationEventArgs>(_clientSession_CMoveStoreSubOperation);
            _clientSession.CMoveResponse += new EventHandler<CMoveResponseEventArgs>(_clientSession_CMoveResponse);
            
            _clientSession.ProcessCMoveRequest ( presentationId, messageId, affectedClass, priority, command  ).WaitOne ( ) ;
            
            return _status ;
         }
         finally
         {
            if ( request != null ) 
            {
               request.Dispose ( ) ;
            }
         }
      }

      #endregion

      #region IProcessCMove Members

      public event MoveDataSetDelegate MoveDataSet ;

      [PresentationContext(DicomUidType.PatientRootQueryMove, new byte[] {1,0,1},DicomUidType.ImplicitVRLittleEndian)]
      [PresentationContext(DicomUidType.PatientStudyQueryMove, DicomUidType.ImplicitVRLittleEndian)]
      [PresentationContext(DicomUidType.StudyRootQueryMove, DicomUidType.ImplicitVRLittleEndian)]
      public DicomCommandStatusType OnMove
      (
         DicomClient client, 
         byte presentationId, 
         int messageId, 
         string affectedClass, 
         DicomCommandPriorityType priority, 
         string moveAE, 
         DicomDataSet request
      )
      {
         try
         {
            _messageId      = messageId ;
            _presentationId = presentationId ;
            _clientSession = new ClientSession ( client ) ;
            
            CMoveClientSessionProxy sessionProxy = new CMoveClientSessionProxy ( _clientSession, presentationId, messageId, affectedClass );
            DicomCommand command = new CustomCMoveCommand ( sessionProxy, request );
            

            _clientSession.CMoveStoreSubOperation += new EventHandler<CMoveStoreSubOperationEventArgs>(_clientSession_CMoveStoreSubOperation);
            _clientSession.CMoveResponse += new EventHandler<CMoveResponseEventArgs>(_clientSession_CMoveResponse);
            
            _clientSession.ProcessCMoveRequest ( presentationId, messageId, affectedClass, priority, command  ).WaitOne ( ) ;
            
            return _status ;
         }
         finally
         {
            if ( request != null ) 
            {
               request.Dispose ( ) ;
            }
         }
      }

      void _clientSession_CMoveResponse(object sender, CMoveResponseEventArgs e)
      {
         e.Handled = true ;
         _status = e.Status ;
      }

      void _clientSession_CMoveStoreSubOperation
      (
         object sender, 
         CMoveStoreSubOperationEventArgs e
      )
      {
         if ( null != MoveDataSet  )
         {
            try
            {
               MoveDataSetEventArgs args = new MoveDataSetEventArgs ( e.MovedDataset );
               
               args.Remaining = e.Remaining ;
               
               MoveDataSet ( this, args ) ;
               
               e.Handled = true ;
            }
            finally
            {
               if ( e.MovedDataset != null ) 
               {
                  e.MovedDataset.Dispose ( ) ;
               }
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
         catch{}
      }

      #endregion
      
      DicomCommandStatusType _status ;
      ClientSession _clientSession ;
      byte _presentationId = 0 ;
      int _messageId = -1 ;
   }
   
   class CustomCMoveCommand : CMoveCommand
   {
      public CustomCMoveCommand(ICMoveClientSessionProxy sessionProxy, DicomDataSet requestDataSet)
      :base ( sessionProxy, requestDataSet )
      {}
      
      public CustomCMoveCommand(ICMoveClientSessionProxy sessionProxy, DicomDataSet requestDataSet, IStorageDataAccessAgent dataAccess)
      : base ( sessionProxy, requestDataSet, dataAccess)
      {}
      
      protected override DicomDataSet LoadDicomDataSet(Leadtools.Medical.Storage.DataAccessLayer.CompositeInstanceDataSet.InstanceRow image)
      {
         DicomInstanceRetrieveCommand loadDsCommand = new DicomInstanceRetrieveCommand ( StorageDataAccess ) ;
         
         return loadDsCommand.GetDicomDataSet ( image ) ;
      }
   }
}
