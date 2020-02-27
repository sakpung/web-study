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
using System.Diagnostics;


namespace Leadtools.Medical.Worklist.AddIns
{
   public class ModalityWorklistAddIn : IProcessCFind
   {
      
      #region IProcessCFind Members

      public event MatchFoundDelegate MatchFound;
      
      [PresentationContext(DicomUidType.ModalityWorklistFind, DicomUidType.ImplicitVRLittleEndian)]
      public DicomCommandStatusType OnFind
      (
         DicomClient Client, 
         byte PresentationId, 
         int MessageId, 
         string AffectedClass, 
         DicomCommandPriorityType Priority, 
         DicomDataSet Request
      )
      {
         ClientSession           clientSession ;
         CFindClientSessionProxy sessionProxy ;
         DicomCommand            mwlCommand ;
         
         if (!AddInsSession.IsLicenseValid())
         {
            Logger.Global.SystemMessage(LogType.Information, "Worklist license not valid.  Worklist search cannot be performed", Client.AETitle);
            return DicomCommandStatusType.ProcessingFailure;
         }
         
         clientSession = new ClientSession           ( Client ) ;
         sessionProxy  = new CFindClientSessionProxy ( clientSession, PresentationId, MessageId, AffectedClass ) ;
         
         if ( null == DicomCommandFactory.GetInitializationService ( typeof ( MWLCFindCommand ) ) )
         {
            DicomCommandFactory.RegisterCommandInitializationService ( typeof ( MWLCFindCommand ), 
                                                                       new MWLCommandInitializationService ( ) ) ;
         }
         
         mwlCommand = DicomCommandFactory.GetInstance ( ).CreateCFindCommand ( sessionProxy, Request )  ;

         _clientSession = clientSession ;
         _sessionProxy  = sessionProxy ;
         
         clientSession.CFindResponse += new EventHandler<Leadtools.Dicom.Scp.CFindResponseEventArgs> ( clientSession_CFindResponse ) ;
         
         clientSession.ProcessCFindRequest ( PresentationId, MessageId, AffectedClass, Priority, mwlCommand ).WaitOne ( ) ;
         
         return _status ;
      }

      void clientSession_CFindResponse ( object sender, Leadtools.Dicom.Scp.CFindResponseEventArgs e )
      {
         if ( null != MatchFound ) 
         {
            if ( e.Status == DicomCommandStatusType.Pending || e.Status == DicomCommandStatusType.Warning ) 
            {
               MatchFound ( this, new MatchFoundEventArgs ( e.ResponseDataset ) ) ;
            }
            else //if ( e.Status == DicomCommandStatusTypeSuccess )
            {
               _status = e.Status ;
            }
            
            e.Handled = true ;
         }
         else
         {
            e.Handled = false ; 
         }
      }

      Leadtools.Dicom.Scp.ClientSession _clientSession = null ;
      Leadtools.Dicom.Scp.CFindClientSessionProxy _sessionProxy ;
      DicomCommandStatusType _status = DicomCommandStatusType.Failure ;

      #endregion

      #region IProcessBreak Members

      public void Break(BreakType type)
      {
         if ( null != _clientSession ) 
         {
            _clientSession.ProcessCCancelRequest ( _sessionProxy.MessageID ) ;
         }
      }

      #endregion
   }
   
   //public class MwlCommandInitializationService : IInitializationService
   //{
   //   public MwlCommandInitializationService ( ) {}
      
   //   public void ConfigureCommand ( DicomCommand command ) 
   //   {
   //      if ( command is MWLCFindCommand )
   //      {
   //         ( command as MWLCFindCommand ).Configuration.AllowExtraElements = false ;
   //      }
   //   }
      
   //   CFindCommandConfiguration cFindConfiguration = new CFindCommandConfiguration ( ) ;
   //   MWLCFindCommandConfiguration cFindMwlConfiguration = new MWLCFindCommandConfiguration ( ) ;
   //}
}
