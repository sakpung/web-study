// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Threading;
using System.Text;
using System.ComponentModel;

using Leadtools;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using Leadtools.DicomDemos.Scu;
using Leadtools.DicomDemos.Scp;

namespace Leadtools.DicomDemos.Scu.CFind
{
   public class FindCompleteEventArgs : EventArgs
   {
      internal DicomDataSetCollection _Datasets;
      internal FindType _Type;

      /// <summary>
      /// 
      /// </summary>
      public FindCompleteEventArgs( )
      {
      }

      public DicomDataSetCollection Datasets
      {
         get
         {
            return _Datasets;
         }
      }

      public FindType Type
      {
         get
         {
            return _Type;
         }
      }
   }

   public class MoveCompleteEventArgs : EventArgs
   {
      internal DicomDataSetCollection _Datasets;
      //internal FindType _Type;

      /// <summary>
      /// 
      /// </summary>
      public MoveCompleteEventArgs( )
      {
      }

      public DicomDataSetCollection Datasets
      {
         get
         {
            return _Datasets;
         }
      }

      //		public FindType Type
      //		{
      //			get
      //			{
      //				return _Type;
      //			}
      //		}
   }

   public delegate void FindCompleteEventHandler(object sender, FindCompleteEventArgs e);
   public delegate void MoveCompleteEventHandler(object sender, MoveCompleteEventArgs e);

   /// <summary>
   /// 
   /// </summary>
   public class CFindQuery
   {
      private string _PatientName;
      private string _PatientID;
      private string _StudyID;
      private string _StudyInstanceUid;
      private string _AccessionNo;
      private string _ReferingDrName;
      private DateTime _StudyStart;
      private DateTime _StudyEnd;
       private DateTime _ScheduledDate;
       private string _Modality;
       private string _RequestedProcedureID;

       public CFindQuery()
       {
            _PatientName = "";
            _PatientID = "";
            _StudyID = "";
            _StudyInstanceUid = "";
            _AccessionNo = "";
            _ReferingDrName = "";
            _StudyStart = DateTime.MinValue;
            _StudyEnd = DateTime.MinValue;
            _ScheduledDate = DateTime.MinValue;
            _Modality = "";
            _RequestedProcedureID = "";
       }

       [Category("Patient")]
       [Description("Patient name")]
       public string PatientName
       {
           get
           {
               return _PatientName;
           }
           set
           {
               _PatientName = value;
           }
       }

      [Category("Patient")]
      [Description("Patient id")]
      public string PatientID
      {
         get
         {
            return _PatientID;
         }
         set
         {
            _PatientID = value;
         }
      }

      [Category("Study")]
      [Description("Study id")]
      public string StudyID
      {
         get
         {
            return _StudyID;
         }
         set
         {
            _StudyID = value;
         }
      }

      [Category("Study")]
      [Description("Study instance uid")]
      public string StudyInstanceUid
      {
         get
         {
            return _StudyInstanceUid;
         }
         set
         {
            _StudyInstanceUid = value;
         }
      }

      [Category("Study")]
      [Description("Accession number")]
      public string AccessionNo
      {
         get
         {
            return _AccessionNo;
         }
         set
         {
            _AccessionNo = value;
         }
      }

      [Category("Study")]
      [Description("Referring doctor's name")]
      public string ReferingDrName
      {
         get
         {
            return _ReferingDrName;
         }
         set
         {
            _ReferingDrName = value;
         }
      }

      [Category("Study")]
      [Description("Study start date")]
      public DateTime StudyStartDate
      {
         get
         {
            return _StudyStart;
         }
         set
         {
            _StudyStart = value;
         }
      }

      [Category("Study")]
      [Description("Study end date")]
      public DateTime StudyEndDate
      {
         get
         {
            return _StudyEnd;
         }
         set
         {
            _StudyEnd = value;
         }
     }

     [Category("Broad")]
     [Description("Scheduled Procedure Step Start Date")]
     public DateTime ScheduledDate
     {
         get
         {
             return _ScheduledDate;
         }
         set
         {
             _ScheduledDate = value;
         }
     }

     [Category("Broad")]
     [Description("Modality")]
     public string Modality
     {
         get
         {
             return _Modality;
         }
         set
         {
             _Modality = value;
         }
     }

     [Category("Patient")]
     [Description("Requested Procedure ID")]
     public string RequestedProcedureID
     {
         get
         {
             return _RequestedProcedureID;
         }
         set
         {
             _RequestedProcedureID = value;
         }
     }
   }

   /// <summary>
   /// Type of query retrieve level.
   /// </summary>
   public enum FindType
   {
      Patient,		/// Patient
      PatientSeries,  /// Patient Series
      Study,			/// Study
      StudySeries,	/// Study Series
      MWLBroad,          // MWL Broad query
      MWLPatient,        // MWL Patient based query
   };

   /// <summary>
   /// This class communicate with the SCP.  The SCP will communicate with
   /// use when we send a C-MOVE-REQUEST.  This class is used to respond
   /// to the C-FIND-REQUEST.
   /// </summary>
   public class CFindClient : DicomNet
   {
      private CFindSCP server;

#if !LEADTOOLS_V20_OR_LATER
      public CFindClient(CFindSCP server)
         : base(null, DicomNetSecurityeMode.None)
      {
         this.server = server;
      }
#else
      public CFindClient(CFindSCP server)
         : base(null, DicomNetSecurityMode.None)
      {
         this.server = server;
      }
#endif // #if !LEADTOOLS_V20_OR_LATER

      protected override void OnReceiveAssociateRequest(DicomAssociate association)
      {
         server.cfind.InvokeStatusEvent(StatusType.ReceiveAssociateRequest, DicomExceptionCode.Success,
                                        association.Calling, association.Called);
         server.DoAssociateRequest(this, association);
      }

      protected override void OnReceiveCStoreRequest(byte presentationID, int messageID, string affectedClass, string instance, DicomCommandPriorityType priority, string moveAE, int moveMessageID, DicomDataSet dataSet)
      {
         DicomDataSet ds = new DicomDataSet();

         server.cfind.InvokeStatusEvent(StatusType.ReceiveCStoreRequest, DicomExceptionCode.Success);
         if(dataSet == null)
         {
            SendCStoreResponse(presentationID, messageID, affectedClass, instance, DicomCommandStatusType.ProcessingFailure);
            return;
         }

         ds.Copy(dataSet, null, null);
         server.dsCollection.Add(ds);

         server.cfind.InvokeStatusEvent(StatusType.SendCStoreResponse, DicomExceptionCode.Success);
         SendCStoreResponse(presentationID, messageID, affectedClass, instance, DicomCommandStatusType.Success);
      }

      protected override void OnReceiveReleaseRequest()
      {
         SendReleaseResponse();
      }

   }

   public class CFindSCP : Leadtools.DicomDemos.Scp.Scp
   {
      internal DicomDataSetCollection dsCollection;
      internal CFind cfind;

      public override void Init( )
      {
         base.Init();

         BuildExclusionList();
      }

      protected override void OnAccept(DicomExceptionCode error)
      {
         if(error == DicomExceptionCode.Success)
         {
            CFindClient client = new CFindClient(this);

            Accept(client);
         }
      }

      public void DoAssociateRequest(CFindClient client, DicomAssociate association)
      {
         using(DicomAssociate retAssociate = new DicomAssociate(false))
         {
            if(retAssociate == null)
            {
               client.SendAssociateReject(DicomAssociateRejectResultType.Permanent,
                                         DicomAssociateRejectSourceType.Provider1,
                                         DicomAssociateRejectReasonType.Application);
               return;
            }

            retAssociate.MaxLength = 46726;
            retAssociate.Version = 1;
            retAssociate.Called = (CalledAE == null) ? association.Called : CalledAE;
            retAssociate.Calling = (CallingAE == null) ? association.Calling : CallingAE;
            retAssociate.ApplicationContextName = (string)DicomUidType.ApplicationContextName;

            for(int i = 0; i < association.PresentationContextCount; i++)
            {
               byte id = association.GetPresentationContextID(i);
               string abstractSyntax = association.GetAbstract(id);

               retAssociate.AddPresentationContext(id, DicomAssociateAcceptResultType.Success, abstractSyntax);
               if(IsSupported(abstractSyntax))
               {
                  for(int j = 0; j < association.GetTransferCount(id); j++)
                  {
                     string transferSyntax = association.GetTransfer(id, j);

                     if(IsSupported(transferSyntax))
                     {
                        retAssociate.AddTransfer(id, transferSyntax);
                        break;
                     }
                  }

                  if(retAssociate.GetTransferCount(id) == 0)
                  {
                     //
                     // Presentation id doesn't have any abstract
                     //  syntaxes therefore we will reject it.
                     //
                     retAssociate.SetResult(id, DicomAssociateAcceptResultType.AbstractSyntax);
                  }
               }
               else
               {
                  retAssociate.SetResult(id, DicomAssociateAcceptResultType.AbstractSyntax);
               }
            }

            if(association.MaxLength != 0)
            {
               retAssociate.MaxLength = association.MaxLength;
            }

            retAssociate.ImplementClass = ImplementationClass;
            retAssociate.ImplementationVersionName = ImplementationVersionName;

            client.SendAssociateAccept(retAssociate);
         }
      }

      protected override void OnClose(DicomExceptionCode error, DicomNet net)
      {
         base.OnClose(error, net);
      }

      private void BuildExclusionList( )
      {
         UidExclusionList.Add(DicomUidType.BasicStudyNotificationClass);
         UidExclusionList.Add(DicomUidType.ApplicationContextName);
         UidExclusionList.Add(DicomUidType.ModalityPerformedClass);
         UidExclusionList.Add(DicomUidType.ModalityPerformedRetrieveClass);
         UidExclusionList.Add(DicomUidType.ModalityPerformedNotificationClass);
         UidExclusionList.Add(DicomUidType.BasicFilmSessionClass);
         UidExclusionList.Add(DicomUidType.BasicFilmBoxClass);
         UidExclusionList.Add(DicomUidType.BasicGrayscaleImageBoxClass);
         UidExclusionList.Add(DicomUidType.BasicColorImageBoxClass);
         UidExclusionList.Add(DicomUidType.BasicGrayscalePrintMetaClass);
         UidExclusionList.Add(DicomUidType.PrintJobClass);
         UidExclusionList.Add(DicomUidType.BasicAnnotationBoxClass);
         UidExclusionList.Add(DicomUidType.PrinterClass);
         UidExclusionList.Add(DicomUidType.PrinterConfigurationRetrievalClass);
         UidExclusionList.Add(DicomUidType.PrinterInstance);
         UidExclusionList.Add(DicomUidType.PrinterConfigurationRetrievalInstance);
         UidExclusionList.Add(DicomUidType.BasicColorPrintMetaClass);
         UidExclusionList.Add(DicomUidType.PresentationLutClass);
         UidExclusionList.Add(DicomUidType.BasicPrintImageOverlayBoxClass);
         UidExclusionList.Add(DicomUidType.PrintQueueInstance);
         UidExclusionList.Add(DicomUidType.PrintQueueClass);
         UidExclusionList.Add(DicomUidType.PullPrintRequestClass);
         UidExclusionList.Add(DicomUidType.PullStoredPrintMetaClass);
         UidExclusionList.Add(DicomUidType.PatientRootQueryFind);
         UidExclusionList.Add(DicomUidType.PatientRootQueryMove);
         UidExclusionList.Add(DicomUidType.PatientRootQueryGet);
         UidExclusionList.Add(DicomUidType.StudyRootQueryFind);
         UidExclusionList.Add(DicomUidType.StudyRootQueryMove);
         UidExclusionList.Add(DicomUidType.StudyRootQueryGet);
         UidExclusionList.Add(DicomUidType.PatientStudyQueryFind);
         UidExclusionList.Add(DicomUidType.PatientStudyQueryMove);
         UidExclusionList.Add(DicomUidType.PatientStudyQueryGet);
         UidExclusionList.Add(DicomUidType.ModalityWorklistFind);
         UidExclusionList.Add(DicomUidType.Papyrus3ImplicitVRLittleEndian);
         UidExclusionList.Add(DicomUidType.JPEGExtended3_5);
         UidExclusionList.Add(DicomUidType.JPEGSpectralNonhier6_8);
         UidExclusionList.Add(DicomUidType.JPEGSpectralNonhier7_9);
         UidExclusionList.Add(DicomUidType.JPEGFullNonhier10_12);
         UidExclusionList.Add(DicomUidType.JPEGFullNonhier11_13);
         UidExclusionList.Add(DicomUidType.JPEGLosslessNonhier15);
         UidExclusionList.Add(DicomUidType.JPEGExtendedHier16_18);
         UidExclusionList.Add(DicomUidType.JPEGExtendedHier17_19);
         UidExclusionList.Add(DicomUidType.JPEGSpectralHier20_22);
         UidExclusionList.Add(DicomUidType.JPEGSpectralHier21_23);
         UidExclusionList.Add(DicomUidType.JPEGFullHier24_26);
         UidExclusionList.Add(DicomUidType.JPEGFullHier25_27);
         UidExclusionList.Add(DicomUidType.JPEGLosslessHierProcess28);
         UidExclusionList.Add(DicomUidType.JPEGLosslessHierProcess29);
         UidExclusionList.Add(DicomUidType.JPEGLSLossless);
         UidExclusionList.Add(DicomUidType.JPEGLSLossy);
      }
   }

   /// <summary>
   /// Implements a Dicom C-FIND operation. 
   /// </summary>
   public class CFind : Scu
   {
      private DicomDataSetCollection dsCollection = new DicomDataSetCollection();
      private FindType type;
      private CFindQuery query;

       private Boolean m_bReturnDatasetsOnComplete;

      // Move series values
      private string patientID;
      private string studyInstance;
      private string seriesInstance;
      private int clientPort;

      /// <summary>
      /// C-FIND operation has completed.
      /// </summary>
      public event FindCompleteEventHandler FindComplete;

      /// <summary>
      /// C-MOVE operation has completed.
      /// </summary>
      public event MoveCompleteEventHandler MoveComplete;

      protected virtual void OnFindComplete(FindCompleteEventArgs e)
      {
         //LastError = e.Error;
         if(FindComplete != null)
         {
            // Invokes the delegates. 
            FindComplete(this, e);
         }
      }

      protected virtual void OnMoveComplete(MoveCompleteEventArgs e)
      {
         if(MoveComplete != null)
         {
            MoveComplete(this, e);
         }
     }

     public CFind()
     {
         // Return datasets when finished by default
         m_bReturnDatasetsOnComplete = true;
     }

     public CFind(bool ReturnDatasetsOnComplete)
     {
         // Return datasets when finished based on user's choice
         m_bReturnDatasetsOnComplete = ReturnDatasetsOnComplete;
     }

      public override void Init( )
      {
         base.Init();
      }

      protected override void OnReceiveCEchoResponse(byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status)
      {
         base.OnReceiveCEchoResponse(presentationID, messageID, affectedClass, status);
      }

       public delegate void ReceiveCFindResponseEventHandler(object sender, byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status, DicomDataSet dataSet);
       public event ReceiveCFindResponseEventHandler ReceiveCFindResponse;

      protected override void OnReceiveCFindResponse(byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status, DicomDataSet dataSet)
      {
         InvokeStatusEvent(StatusType.ReceiveCFindResponse, status);

         switch(status)
         {
            case DicomCommandStatusType.Success:
            case DicomCommandStatusType.Warning:
               Event.Set();
               break;
           case DicomCommandStatusType.Pending:
           case DicomCommandStatusType.PendingWarning:
               if (m_bReturnDatasetsOnComplete)
               {
                   AddDS(dataSet);
               }
               else
               {
                   ReceiveCFindResponse(this, presentationID, messageID, affectedClass, status, dataSet);
               }
               break;
            default:
               Event.Set();
               break;
         }
      }

      protected override void OnReceiveCMoveResponse(byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status, int remaining, int completed, int failed, int warning, DicomDataSet dataSet)
      {
         InvokeStatusEvent(StatusType.ReceiveCMoveResponse, DicomExceptionCode.Success, completed, remaining, status);
         Event.Set();
      }

      protected override void OnReceiveReleaseResponse( )
      {
         InvokeStatusEvent(StatusType.ReceiveReleaseResponse, DicomExceptionCode.Success);
         Close();
         Event.Set();
      }

      /// <summary>
      /// Sends a find request to the specified server.
      /// </summary>
      /// <param name="server">Server to send the find request to.</param>
      /// <param name="type">Type of query.</param>
      /// <param name="query">Query information.</param>
      /// <param name="AETitle">Calling aetitle.</param>
      public void Find(DicomServer server, FindType type, CFindQuery query, string AETitle)
      {
         DicomExceptionCode ret;

         this.type = type;
         this.query = query;

         dsCollection.Clear();
         ret = Associate(server, AETitle, new SCUProcessFunc(FindProcess));
         if(ret != DicomExceptionCode.Success)
         {
            //MessageBox.Show("Error during association: ",ret.ToString());
            return;
         }
      }

      /// <summary>
      /// Performs a C-MOVE to move a series.
      /// </summary>
      /// <param name="patientID">Patient ID.</param>
      /// <param name="studyInstance">Study Instance UID.</param>
      /// <param name="seriesInstance">Series Instance UID.</param>
      /// <param name="clientPort">Client port for SCP to connect to.</param>
      public void MoveSeries(DicomServer server, string AETitle, string patientID, string studyInstance, string seriesInstance, int clientPort)
      {
         DicomExceptionCode ret;

         this.patientID = patientID;
         this.studyInstance = studyInstance;
         this.seriesInstance = seriesInstance;
         this.clientPort = clientPort;

         ret = Associate(server, AETitle, new SCUProcessFunc(MoveSeriesProcess));
         if(ret != DicomExceptionCode.Success)
         {
            //MessageBox.Show("Error during association: ",ret.ToString());
            return;
         }
      }

      public override PresentationContextCollection GetPresentationContext( )
      {
         PresentationContextCollection pc = new PresentationContextCollection();
         PresentationContext p;

         p = new PresentationContext();
         p.AbstractSyntax = DicomUidType.PatientRootQueryFind;
         p.TransferSyntaxList.Add(DicomUidType.ImplicitVRLittleEndian);
         pc.Add(p);

         p = new PresentationContext();
         p.AbstractSyntax = DicomUidType.StudyRootQueryFind;
         p.TransferSyntaxList.Add(DicomUidType.ImplicitVRLittleEndian);
         pc.Add(p);

         p = new PresentationContext();
         p.AbstractSyntax = DicomUidType.StudyRootQueryFind;
         p.TransferSyntaxList.Add(DicomUidType.ImplicitVRLittleEndian);
         pc.Add(p);

         p = new PresentationContext();
         p.AbstractSyntax = DicomUidType.VerificationClass;
         p.TransferSyntaxList.Add(DicomUidType.ImplicitVRLittleEndian);
         pc.Add(p);

         p = new PresentationContext();
         p.AbstractSyntax = DicomUidType.PatientRootQueryMove;
         p.TransferSyntaxList.Add(DicomUidType.ImplicitVRLittleEndian);
         pc.Add(p);

         p = new PresentationContext();
         p.AbstractSyntax = DicomUidType.ModalityWorklistFind;
         p.TransferSyntaxList.Add(DicomUidType.ImplicitVRLittleEndian);
         pc.Add(p);


         return pc;
      }

      public void FindProcess( )
      {
         using ( DicomDataSet ds = GetDS() ) 
         {
            byte pid = GetPresentationID(type);

            if(pid == 0 || (Association.GetResult(pid) != DicomAssociateAcceptResultType.Success))
            {
               InvokeStatusEvent(StatusType.Error, DicomExceptionCode.Success);
               return;
            }

            if(ds == null)
               return;

            string uid = "";

            if(type == FindType.Patient || type == FindType.PatientSeries)
            {
               uid = DicomUidType.PatientRootQueryFind;
            }
            else if(type == FindType.Study || type == FindType.StudySeries)
            {
               uid = DicomUidType.StudyRootQueryFind;
            }
            else if (type == FindType.MWLBroad || type == FindType.MWLPatient)
            {
                uid = DicomUidType.ModalityWorklistFind;
            }

            InvokeStatusEvent(StatusType.SendCFindRequest, DicomExceptionCode.Success);
            SendCFindRequest(pid, MessageId++, uid, DicomCommandPriorityType.Medium, ds);

            if(!Wait())
            {
               //
               // Connection timed out
               //
               InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success);
               Terminate();
            }

            InvokeStatusEvent(StatusType.SendReleaseRequest, DicomExceptionCode.Success);
            SendReleaseRequest();

            if(!Wait())
            {
               InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success);
               Terminate();
            }

            FindCompleteEventArgs e = new FindCompleteEventArgs();

            e._Datasets = dsCollection;
            e._Type = type;
            OnFindComplete(e);
         }
      }

      public void MoveSeriesProcess( )
      {
         DicomExceptionCode ret = DicomExceptionCode.Success;
         CFindSCP scp = new CFindSCP();
         DicomDataSet ds = new DicomDataSet();

         dsCollection.Clear();
         scp.cfind = this;
         scp.dsCollection = dsCollection;
         scp.ImplementationClass = ImplementationClass;
         scp.ImplementationVersionName = ImplementationVersionName;
         ret = scp.Listen(clientPort, 1);
         if(ret != DicomExceptionCode.Success)
         {
            InvokeStatusEvent(StatusType.Error, ret);
            Terminate();
            return;
         }

         ds.Initialize(DicomClassType.Undefined, DicomDataSetInitializeType.ExplicitVRLittleEndian);

         Utils.SetTag(ds, DemoDicomTags.QueryRetrieveLevel, "SERIES");
         Utils.SetTag(ds, DemoDicomTags.StudyInstanceUID, studyInstance);
         Utils.SetTag(ds, DemoDicomTags.SeriesInstanceUID, seriesInstance);
         Utils.SetTag(ds, DemoDicomTags.PatientID, patientID);

         byte pid = Association.FindAbstract(DicomUidType.PatientRootQueryMove);

         InvokeStatusEvent(StatusType.SendCMoveRequest, DicomExceptionCode.Success);

         try
         {
            SendCMoveRequest(pid, MessageId++, DicomUidType.PatientRootQueryMove,
                             DicomCommandPriorityType.Medium, Association.Calling, ds);
         }
         catch(DicomException de)
         {
            InvokeStatusEvent(StatusType.Error, de.Code);
            scp.Close();
            return;
         }

         if(!Wait())
         {
            //
            // Connection timed out
            //
            scp.Close();
            InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success);
            Terminate();
         }

         InvokeStatusEvent(StatusType.SendReleaseRequest, DicomExceptionCode.Success);
         SendReleaseRequest();

         if (!Wait())
         {
            scp.Close();
            InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success);
            Terminate();
         }

         scp.Close();
         MoveCompleteEventArgs e = new MoveCompleteEventArgs();

         e._Datasets = dsCollection;
         OnMoveComplete(e);
      }

      public void AddDS(DicomDataSet addDS)
      {
         DicomDataSet ds = new DicomDataSet();

         ds.Copy(addDS, null, null);
         dsCollection.Add(ds);
      }

      public byte GetPresentationID(FindType type)
      {
         byte id = 0;

         if (Association != null)
         {
            switch (type)
            {
               case FindType.Patient:
               case FindType.PatientSeries:
                  id = Association.FindAbstract(DicomUidType.PatientRootQueryFind);
                  break;
               case FindType.Study:
               case FindType.StudySeries:
                  id = Association.FindAbstract(DicomUidType.StudyRootQueryFind);
                  break;
                case FindType.MWLBroad:
                case FindType.MWLPatient:
                    id = Association.FindAbstract(DicomUidType.ModalityWorklistFind);
                    break;                    
            }

         }
         return id;
      }

      public void UpdateSpecificCharacterSet(DicomDataSet ds, string s)
      {
         if (false == Utils.IsAscii(s))
         {
            ds.InsertElementAndSetValue(DicomTag.SpecificCharacterSet, "ISO_IR 192");
         }
      }

      public DicomDataSet GetDS( )
      {
         DicomDataSet ds = new DicomDataSet();

         if(ds == null)
            return null;

         switch(type)
         {
            case FindType.Patient:
               {
                  ds.Initialize(DicomClassType.PatientRootQueryPatient, DicomDataSetInitializeType.ExplicitVRLittleEndian);

                  UpdateSpecificCharacterSet(ds, query.PatientName);
                  Utils.SetTag(ds, DemoDicomTags.QueryRetrieveLevel, "PATIENT");
                  Utils.SetTag(ds, DemoDicomTags.PatientName, query.PatientName);
                  Utils.SetTag(ds, DemoDicomTags.PatientID, query.PatientID);
               }
               break;

            case FindType.PatientSeries:
               {
                  ds.Initialize(DicomClassType.PatientRootQuerySeries, DicomDataSetInitializeType.ExplicitVRLittleEndian);

                  Utils.SetTag(ds, DemoDicomTags.QueryRetrieveLevel, "SERIES");
                  Utils.SetTag(ds, DemoDicomTags.PatientID, query.PatientID);
                  Utils.SetTag(ds, DemoDicomTags.StudyInstanceUID, query.StudyInstanceUid);
               }
               break;

            case FindType.Study:
               {
                  ds.Initialize(DicomClassType.StudyRootQueryStudy, DicomDataSetInitializeType.ExplicitVRLittleEndian);
                  UpdateSpecificCharacterSet(ds, query.PatientName);

                  Utils.SetTag(ds, DemoDicomTags.QueryRetrieveLevel, "STUDY");
                  Utils.SetTag(ds, DemoDicomTags.StudyInstanceUID, query.StudyInstanceUid);
                  Utils.SetTag(ds, DemoDicomTags.StudyID, query.StudyID);
                  Utils.SetTag(ds, DemoDicomTags.AccessionNumber, query.AccessionNo);
                  Utils.SetTag(ds, DemoDicomTags.PatientName, query.PatientName);
                  Utils.SetTag(ds, DemoDicomTags.PatientID, query.PatientID);

                  if(DateTime.Compare(query.StudyStartDate, DateTime.MinValue) != 0 &&
                     DateTime.Compare(query.StudyEndDate, DateTime.MinValue) != 0)
                  {
                     StringBuilder range = new StringBuilder();

                     range.Append(query.StudyStartDate.ToString("yyyyMMdd"));
                     range.Append("-");
                     range.Append(query.StudyEndDate.ToString("yyyyMMdd"));

                     Utils.SetTag(ds, DemoDicomTags.StudyDate, Encoding.UTF8.GetBytes(range.ToString()));
                  }
                  else if(DateTime.Compare(query.StudyStartDate, DateTime.MinValue) == 0 &&
                         DateTime.Compare(query.StudyEndDate, DateTime.MinValue) != 0)
                  {
                     StringBuilder range = new StringBuilder();

                     range.Append("-");
                     range.Append(query.StudyEndDate.ToString("yyyyMMdd"));
                     Utils.SetTag(ds, DemoDicomTags.StudyDate, Encoding.UTF8.GetBytes(range.ToString()));
                  }
                  else if(DateTime.Compare(query.StudyStartDate, DateTime.MinValue) != 0 &&
                         DateTime.Compare(query.StudyEndDate, DateTime.MinValue) == 0)
                  {
                     StringBuilder range = new StringBuilder();

                     range.Append(query.StudyStartDate.ToString("yyyyMMdd"));
                     range.Append("-");
                     Utils.SetTag(ds, DemoDicomTags.StudyDate, Encoding.UTF8.GetBytes(range.ToString()));
                  }
               }
               break;

            case FindType.StudySeries:
               {
                  ds.Initialize(DicomClassType.StudyRootQuerySeries, DicomDataSetInitializeType.ExplicitVRLittleEndian);

                  Utils.SetTag(ds, DemoDicomTags.QueryRetrieveLevel, "SERIES");
                  Utils.SetTag(ds, DemoDicomTags.StudyInstanceUID, query.StudyInstanceUid);
               }
               break;
           case FindType.MWLBroad:
               {
                   ds.Initialize(DicomClassType.ModalityWorklist, DicomDataSetInitializeType.ImplicitVRLittleEndian);

                   Utils.SetTag(ds, DemoDicomTags.ScheduledProcedureStepSequence,DemoDicomTags.Modality, query.Modality);


                   if (DateTime.Compare(query.ScheduledDate, DateTime.MinValue) != 0)
                   {
                       Utils.SetTag(ds, DemoDicomTags.ScheduledProcedureStepSequence,DemoDicomTags.ScheduledProcedureStepStartDate, query.ScheduledDate.ToString("MM/dd/yyyy"));
                   }
               }
               break;
           case FindType.MWLPatient:
               {
                   ds.Initialize(DicomClassType.ModalityWorklist, DicomDataSetInitializeType.ImplicitVRLittleEndian);
                   UpdateSpecificCharacterSet(ds, query.PatientName);

                   Utils.SetTag(ds, DemoDicomTags.PatientName, query.PatientName);
                   Utils.SetTag(ds, DemoDicomTags.PatientID, query.PatientID);
                   Utils.SetTag(ds, DemoDicomTags.AccessionNumber, query.AccessionNo);
                   Utils.SetTag(ds, DemoDicomTags.RequestedProcedureID, query.RequestedProcedureID);
               }
               break;
         }

         return ds;
      }

      protected override void OnReceiveData(byte presentationID, DicomDataSet cs, DicomDataSet ds)
      {
         base.OnReceiveData(presentationID, cs, ds);
         
         if ( null != cs ) 
         {
            cs.Dispose ( ) ;
         }
      }
   } 
}
