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


namespace Leadtools.Medical.Media.AddIns
{
   public class MediaCreateAddIn : IProcessNCreate
   {
      [PresentationContext(DicomUidType.MediaCreationManagement, DicomUidType.ExplicitVRBigEndian)]
      [PresentationContext(DicomUidType.MediaCreationManagement, DicomUidType.ExplicitVRLittleEndian)]
      [PresentationContext(DicomUidType.MediaCreationManagement, DicomUidType.ImplicitVRLittleEndian)]
      public DicomCommandStatusType OnNCreate
      (
         DicomClient client, 
         byte presentationID, 
         int messageID, 
         string affectedClass, 
         string instance, 
         DicomDataSet Request, 
         DicomDataSet Response
      )
      {
         ClientSession             clientSession ;
         NCreateClientSessionProxy sessionProxy ;
         DicomCommand              mediaCreateCommand ;
         
         
         
         clientSession = new ClientSession           ( client ) ;
         sessionProxy  = new NCreateClientSessionProxy ( clientSession, presentationID, messageID, affectedClass, instance ) ;
         
         mediaCreateCommand = DicomCommandFactory.GetInstance ( ).CreateNCreateCommand ( sessionProxy, Request )  ;

         _clientSession = clientSession ;
         _sessionProxy  = sessionProxy ;

         clientSession.NCreateResponse += new EventHandler<NCreateResponseEventArgs>(clientSession_NCreateResponse);
         
         clientSession.ProcessNCreateRequest ( presentationID, messageID, affectedClass, instance, mediaCreateCommand ).WaitOne ( ) ;
         
         
         //TODO: use the new interface to update the instance parameter
         if ( null != _status )
         {
            return _status.Status ;
         }
         else
         {
            return DicomCommandStatusType.Failure ;
         }
      }

      void clientSession_NCreateResponse ( object sender, NCreateResponseEventArgs e )
      {
         e.Handled = true ; 
         
         _status = e ;
      }

      Leadtools.Dicom.Scp.ClientSession _clientSession = null ;
      Leadtools.Dicom.Scp.NCreateClientSessionProxy _sessionProxy ;
      NCreateResponseEventArgs _status = null ;

      #region IProcessBreak Members

      public void Break(BreakType type)
      {
         if ( null != _clientSession ) 
         {
            if ( type == BreakType.Cancel ) 
            {
               _clientSession.ProcessCCancelRequest ( _sessionProxy.MessageID ) ;
            }
         }
      }

      #endregion
   }
}
