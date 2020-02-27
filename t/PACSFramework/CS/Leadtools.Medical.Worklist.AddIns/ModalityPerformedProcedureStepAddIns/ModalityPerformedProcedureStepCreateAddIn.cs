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
using Leadtools.Logging;
using Leadtools.Logging.Medical;


namespace Leadtools.Medical.Worklist.AddIns
{
   public class ModalityPerformedProcedureStepCreateAddIn : IProcessNCreate
   {
      #region IProcessNCreate Members

      [PresentationContext(DicomUidType.ModalityPerformedClass, DicomUidType.ImplicitVRLittleEndian)]
      public DicomCommandStatusType OnNCreate
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
         try
         {
            ClientSession      clientSession ;
            MppsNCreateCommand mppsCommand ;

            if (!AddInsSession.IsLicenseValid())
            {
               Logger.Global.SystemMessage(LogType.Information, "Worklist license not valid.  Worklist creation cannot be performed", Client.AETitle);
               return DicomCommandStatusType.ProcessingFailure;
            }
            

            clientSession  = new ClientSession           ( Client ) ;
            _sessionProxy  = new NCreateClientSessionProxy ( clientSession, presentationID, messageID, affectedClass, instance ) ;
            
            if ( null == DicomCommandFactory.GetInitializationService ( typeof ( MppsNCreateCommand ) ) )
            {
               DicomCommandFactory.RegisterCommandInitializationService ( typeof ( MppsNCreateCommand ), 
                                                                          new MppsCreateCommandInitializationService ( ) ) ;
            }
            
            mppsCommand =  DicomCommandFactory.GetInstance ( ).CreateTypedCommand <MppsNCreateCommand> ( _sessionProxy, Request ) ;

            clientSession.NCreateResponse += new EventHandler<NCreateResponseEventArgs>(clientSession_NCreateResponse);
            mppsCommand.PPSConfiguration.ValidateRelationalAttributesAccordingToIHE = true ;
            
            _response = Response ;
            
            clientSession.ProcessNCreateRequest ( presentationID, messageID, affectedClass, instance, mppsCommand ).WaitOne ( ) ;
            
            return _status ;
         }
         catch ( Exception exception ) 
         {
            Logger.Global.Log ( Client.Server.AETitle, 
                                Client.Server.HostAddress, 
                                Client.Server.Port, 
                                Client.AETitle, 
                                Client.PeerAddress, 
                                Client.PeerPort, 
                                DicomCommandType.NCreate,
                                DateTime.Now, 
                                LogType.Error, 
                                MessageDirection.Input, 
                                "NCreate Failed: " + exception.Message, 
                                Request,
                                null ) ;
            throw ;
         }
      }

      void clientSession_NCreateResponse(object sender, NCreateResponseEventArgs e)
      {
         e.Handled = true ;
         _status = e.Status ;
         
         if (  null != e.ResponseDataset && null != _response ) 
         {
            _response.Copy ( e.ResponseDataset, null, null ) ;
         }
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
      Leadtools.Dicom.Scp.INCreateClientSessionProxy _sessionProxy ;
      DicomCommandStatusType _status = DicomCommandStatusType.Failure ;
      DicomDataSet _response ;
   }
}
