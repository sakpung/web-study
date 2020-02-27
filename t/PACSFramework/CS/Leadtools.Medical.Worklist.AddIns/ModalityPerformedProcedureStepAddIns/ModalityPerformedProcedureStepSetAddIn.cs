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
using System.Threading;
using Leadtools.Logging;


namespace Leadtools.Medical.Worklist.AddIns
{
   public class ModalityPerformedProcedureStepSetAddIn : IProcessNSet
   {
      #region IProcessNCreate Members

      [PresentationContext(DicomUidType.ModalityPerformedClass, DicomUidType.ImplicitVRLittleEndian)]
      public DicomCommandStatusType OnNSet
      (
         DicomClient Client, 
         byte presentationID, 
         int messageID, 
         string affectedClass, 
         string instance, 
         DicomDataSet Request, 
         DicomDataSet Response
      )
      {
         ClientSession          clientSession ;
         NSetClientSessionProxy sessionProxy ;
         DicomCommand           mppsCommand ;

         if (!AddInsSession.IsLicenseValid())
         {
            Logger.Global.SystemMessage(LogType.Information, "Worklist license not valid.  Worklist set cannot be performed", Client.AETitle);
            return DicomCommandStatusType.ProcessingFailure;
         }
                  
         clientSession = new ClientSession           ( Client ) ;
         sessionProxy  = new NSetClientSessionProxy ( clientSession, presentationID, messageID, affectedClass, instance ) ;
         
         if ( null == DicomCommandFactory.GetInitializationService ( typeof ( MppsNSetCommand ) ) )
         {
            DicomCommandFactory.RegisterCommandInitializationService ( typeof ( MppsNSetCommand ), 
                                                                       new MppsSetCommandInitializationService ( ) ) ;
         }
         
         mppsCommand = DicomCommandFactory.GetInstance ( ).CreateNSetCommand ( sessionProxy, Request )  ;

         _clientSession = clientSession ;
         _sessionProxy  = sessionProxy ;

         clientSession.NSetResponse += new EventHandler<NSetResponseEventArgs>(clientSession_NSetResponse);
         
         clientSession.ProcessNSetRequest ( presentationID, messageID, affectedClass, instance, mppsCommand ).WaitOne ( ) ;
         
         Response = _response ;
         
         return _status ;
      }

      void clientSession_NSetResponse(object sender, NSetResponseEventArgs e)
      {
         e.Handled = true ;
         
         _status = e.Status ;
         
         _response = e.ResponseDataset ;
      }

      #endregion

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
      
      Leadtools.Dicom.Scp.ClientSession _clientSession = null ;
      Leadtools.Dicom.Scp.NSetClientSessionProxy _sessionProxy ;
      DicomCommandStatusType _status = DicomCommandStatusType.Failure ;
      DicomDataSet _response ;
   }
}
