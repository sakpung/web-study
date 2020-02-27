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
   public class MediaActionAddIn : IProcessNAction
   {
      
      [PresentationContext(DicomUidType.MediaCreationManagement, DicomUidType.ExplicitVRBigEndian)]
      [PresentationContext(DicomUidType.MediaCreationManagement, DicomUidType.ExplicitVRLittleEndian)]
      [PresentationContext(DicomUidType.MediaCreationManagement, DicomUidType.ImplicitVRLittleEndian)]
      public DicomCommandStatusType OnNAction
      (
         DicomClient client, 
         byte presentationId, 
         int messageID, 
         string affectedClass, 
         string instance, 
         int action, 
         DicomDataSet request, 
         DicomDataSet response
      )
      {
         ClientSession             clientSession ;
         INActionClientSessionProxy sessionProxy ;
         DicomCommand              mediaActionCommand ;
         
         
         clientSession = new ClientSession           ( client ) ;
         sessionProxy  = new NActionClientSessionProxy ( clientSession, presentationId, messageID, affectedClass, instance, action, response ) ;
         
         //by default this will return a strategy which switch between the actual Action command based on the Action Type
         mediaActionCommand = DicomCommandFactory.GetInstance ( ).CreateNActionCommand ( sessionProxy, request )  ;

#if DEBUG
         if ( mediaActionCommand is MediaCreationNActionCommandStrategy ) 
         {
            System.Diagnostics.Trace.WriteLine ( ( ( MediaCreationNActionCommandStrategy ) mediaActionCommand ).StrategyCommand.ToString ( ) ) ;
         }
#endif
         
         _clientSession = clientSession ;
         _sessionProxy  = sessionProxy ;

         clientSession.NActionResponse += new EventHandler<NActionResponseEventArgs> ( clientSession_NActionResponse ) ;
         
         clientSession.ProcessNActionRequest ( presentationId, messageID, affectedClass, instance, action, mediaActionCommand ).WaitOne ( ) ;
         
         return _status ;
      }

      void clientSession_NActionResponse(object sender, NActionResponseEventArgs e)
      {
         e.Handled = true ; 
         
         _status = e.Status ;
      }

      Leadtools.Dicom.Scp.ClientSession _clientSession = null ;
      Leadtools.Dicom.Scp.INActionClientSessionProxy _sessionProxy ;
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
