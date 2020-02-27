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
   public class MediaGetAddIn : IProcessNGet
   {
      [PresentationContext(DicomUidType.MediaCreationManagement, DicomUidType.ExplicitVRBigEndian)]
      [PresentationContext(DicomUidType.MediaCreationManagement, DicomUidType.ExplicitVRLittleEndian)]
      [PresentationContext(DicomUidType.MediaCreationManagement, DicomUidType.ImplicitVRLittleEndian)]
      public DicomCommandStatusType OnNGet
      (
         DicomClient client, 
         byte presentationId, 
         int messageID, 
         string affectedClass, 
         string instance, 
         long[] attributes, 
         DicomDataSet response
      )
      {
         ClientSession           clientSession ;
         INGetClientSessionProxy sessionProxy ;
         DicomCommand            mediaCreateCommand ;
         
         
         
         clientSession = new ClientSession          ( client ) ;
         sessionProxy  = new NGetClientSessionProxy ( clientSession, presentationId, messageID, affectedClass, instance, response ) ;
         
         mediaCreateCommand = DicomCommandFactory.GetInstance ( ).CreateNGetCommand ( sessionProxy, attributes )  ;

         _clientSession = clientSession ;
         _sessionProxy  = sessionProxy ;

         clientSession.NGetResponse += new EventHandler<NGetResponseEventArgs> ( clientSession_NGetResponse ) ;
         
         clientSession.ProcessNGetMessage ( presentationId, messageID, affectedClass, instance, mediaCreateCommand ).WaitOne ( ) ;
         
         return _status ;
      }

      void clientSession_NGetResponse ( object sender, NGetResponseEventArgs e )
      {
         e.Handled = true ; 
         
         _status = e.Status ;
      }

      Leadtools.Dicom.Scp.ClientSession _clientSession = null ;
      Leadtools.Dicom.Scp.INGetClientSessionProxy _sessionProxy ;
      DicomCommandStatusType _status = DicomCommandStatusType.Failure ;

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
