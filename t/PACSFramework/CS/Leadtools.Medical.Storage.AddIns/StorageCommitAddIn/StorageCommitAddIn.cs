// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn.Attributes;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Medical.Storage.AddIns.Messages;
using System.IO;
using Microsoft.Practices.Unity;


namespace Leadtools.Medical.Storage.AddIns.StorageCommitAddIn
{
   public class StorageCommitAddIn : IProcessNAction
   {
      private AsyncResult result = null;

      private IDicomRequest _dicomRequest;

      [Dependency]
      public IDicomRequest DicomRequest
      {
         set
         {
            _dicomRequest = value;
         }
      }

      [PresentationContext(DicomUidType.StorageCommitmentPushModelClass, DicomUidType.ImplicitVRLittleEndian)]
      public DicomCommandStatusType OnNAction(DicomClient client, byte presentationId, int messageID, string affectedClass, string instance, int action, DicomDataSet requestDS, DicomDataSet responseDS)
      {
         StorageCommitArgs args = new StorageCommitArgs
                                     {
                                        Client = client,
                                        PresentationId = presentationId,
                                        MessageId = messageID,
                                        AffectedClass = affectedClass,
                                        Instance = instance,
                                        Action = action
                                     };
         args.RequestDS = new DicomDataSet();
         args.RequestDS.Copy(requestDS, null, null);

         result = AsyncHelper.Execute<StorageCommitArgs>(new Action<StorageCommitArgs>(HandleNReport), args); 
         // responseDS = null;

         return DicomCommandStatusType.Success;
      }

      public void Break(BreakType type)
      {
         if (result != null && !result.IsCompleted)
            result.Cancel();
      }

      private static void request_ReceiveNReportResponse(DicomRequest request, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, int dicomEvent, DicomDataSet dataSet)
      {
      }

      public void HandleNReport(StorageCommitArgs p)
       {
         StorageCommitment commitRequest = p.RequestDS.Get<StorageCommitment>();
         StorageCommitmentResult commitResult = new StorageCommitmentResult();

         commitResult.TransactionUID = commitRequest.TransactionUID;
         commitResult.RetrieveAETitle = p.Client.AETitle; //p.Client.Server.AETitle;

         int failedCount = 0;

         foreach(SopInstanceReference referencedSop in commitRequest.ReferencedSOPSequence)
         {
            string referencedFile = GetInstanceFileName.FindReferencedFile(referencedSop.ReferencedSopInstanceUid);
            bool success = !string.IsNullOrEmpty(referencedFile) && File.Exists(referencedFile);

            if (success)
            {
               // Success
               if (commitResult.ReferencedSOPSequence == null)
               {
                  commitResult.ReferencedSOPSequence = new List<SCSOPInstanceReference>();
               }

               SCSOPInstanceReference scSopInstanceReference = new SCSOPInstanceReference();
               scSopInstanceReference.RetrieveAETitle = commitResult.RetrieveAETitle;
               scSopInstanceReference.ReferencedSopClassUid = referencedSop.ReferencedSopClassUid;
               scSopInstanceReference.ReferencedSopInstanceUid = referencedSop.ReferencedSopInstanceUid;
               commitResult.ReferencedSOPSequence.Add(scSopInstanceReference);
            }
            else
            {
               // Fail

               if (commitResult.FailedSOPSequence == null)
               {
                  commitResult.FailedSOPSequence = new List<SCFailedSOPInstanceReference>();
               }

               SCFailedSOPInstanceReference scFailedSopInstanceReference = new SCFailedSOPInstanceReference();
               scFailedSopInstanceReference.ReferencedSopClassUid = referencedSop.ReferencedSopClassUid;
               scFailedSopInstanceReference.ReferencedSopInstanceUid = referencedSop.ReferencedSopInstanceUid;

               // The following values and semantics shall be used for the Failure Reason Attribute:
               // 0110H - DicomCommandStatusType.ProcessingFailure       - Processing failure A general failure in processing the operation was encountered.
               // 0112H - DicomCommandStatusType.NoSuchObjectInstance    - No such object instance One or more of the elements in the Referenced SOP Instance Sequence was not available.
               // 0213H - DicomCommandStatusType.ResourceLimitation      - Resource limitation The SCP does not currently have enough resources to store the requested SOP Instance(s).
               // 0122H - DicomCommandStatusType.ClassNotSupported       - Referenced SOP Class not supported Storage Commitment has been requested for a SOP Instance with a SOP Class thatis not supported by the SCP.
               // 0119H - DicomCommandStatusType.ClaseInstanceConflict   - Class / Instance conflict The SOP Class of an element in the Referenced SOP Instance Sequence did not correspond to theSOP class registered for this SOP Instance at the SCP.
               // 0131H - DicomCommandStatusType.DuplicateTransactionUid - Duplicate transaction UID The Transaction UID of the Storage Commitment Request is already in use.
               scFailedSopInstanceReference.FailureReason = (int) DicomCommandStatusType.NoSuchObjectInstance;

               commitResult.FailedSOPSequence.Add(scFailedSopInstanceReference);
               failedCount++;
            }
         }

         DicomDataSet resultDS = new DicomDataSet();
         resultDS.Set(commitResult);

         PresentationContext pc = new PresentationContext();

         pc.AbstractSyntax = DicomUidType.StorageCommitmentPushModelClass;
         pc.TransferSyntaxes.Add(DicomUidType.ImplicitVRLittleEndian);

         DicomRequest request = new DicomRequest(p.Client);
         request.PresentationContexts.Add(pc);
         request.RequireMessagePump = true;

         request.ReceiveNReportResponse += new ReceiveNReportResponseDelegate(request_ReceiveNReportResponse);

         request.ConnectType = ConnectType.Conditional;
         // request.ConnectType = ConnectType.New;

         // eventTypeId   - 1 -- All success
         //               - 2 -- One or more failures
         int eventTypeId = failedCount > 0 ? 2 : 1;
         _dicomRequest.SendNReportRequest(request,
                                            p.PresentationId,
                                            p.MessageId,
                                            DicomUidType.StorageCommitmentPushModelClass,
                                            DicomUidType.StorageCommitmentPushModelInstance,
                                            eventTypeId,
                                            resultDS);
       }

   }

    public class StorageCommitArgs
    {
       public DicomClient Client { get; set; }
       public byte PresentationId { get; set; }
       public int MessageId { get; set; }
       public string AffectedClass { get; set; }
       public string Instance { get; set; }
       public int Action { get; set; }
       public DicomDataSet RequestDS { get; set; }
       // public DicomDataSet ResponseDS { get; set; }

       public string ServerAE{ get; set; }
    }
}
