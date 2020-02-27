// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Attributes;
using Leadtools.Dicom.AddIn.Interfaces;
using System.Diagnostics;
using Microsoft.Practices.Unity;
using Leadtools.AddIn.StorageCommit;
using System.IO;
using System.Data.SqlServerCe;
using Leadtools.Logging;

namespace Leadtools.AddIn.Store
{
    [DicomAddInAttribute("Storage Commit AddIn","1.0.0.0",Description="Implements Storage Commitment",Author="")]
    public class StorageCommitAddin : IProcessNAction
    {
        private AsyncResult result = null;  
      

        private IDicomRequest _DicomRequest;

        [Dependency]
        public IDicomRequest DicomRequest
        {
            set
            {
                _DicomRequest = value;
            }
        }

        private IAETitle _AeTitle;
        [Dependency]
        public IAETitle AeTitle
        {
            set
            {
                _AeTitle = value;
            }
        }

        private void AddCommitItem(DicomDataSet ds, long tag, StorageCommit.StorageCommit commit)
        {
            DicomElement rppss = null;
            DicomElement element;

            rppss = ds.FindFirstElement(null, tag, true);

            // If SameStudy goes to false, it is false for the entire commit
            if (commit.SameStudy)
            {
                commit.SameStudy = rppss != null;
            }
            commit.TransactionUID = ds.GetValue<string>(DicomTag.TransactionUID, string.Empty);
            element = ds.GetChildElement(rppss, false);
            while (element != null)
            {
                DicomElement child = ds.GetChildElement(element, true);

                if (child != null)
                {
                    StorageCommitItem item = new StorageCommitItem();

                    item.SOPClassUID = ds.GetValue<string>(child, true, DicomTag.ReferencedSOPClassUID, string.Empty);
                    item.SOPInstanceUID = ds.GetValue<string>(child, true, DicomTag.ReferencedSOPInstanceUID, string.Empty);
                    commit.Items.Add(item);
                }
                element = ds.GetNextElement(element, true, true);
            }  
        }

        private DicomDataSet BuildDataset(DicomClient client,StorageCommit.StorageCommit commit, string serverAE)
        {
            DicomDataSet ds = new DicomDataSet(null);
            DicomElement success = null;
            DicomElement failed = null;

            ds.Initialize(DicomClassType.Undefined, DicomDataSetInitializeType.ExplicitVRLittleEndian);
            ds.InsertElementAndSetValue(DicomTag.TransactionUID, commit.TransactionUID);
            ds.InsertElementAndSetValue(DicomTag.RetrieveAETitle, serverAE);

            if (commit.SameStudy && !commit.IsSameStudy())
            {

                Logger.Global.Error("Storage Commit AddIn", "N-EVENT-REPORT: Referenced SOP Sequence does not have same StudyInstanceUID");
                foreach (StorageCommitItem item in commit.Items)
                    item.Status = DicomCommandStatusType.ProcessingFailure;
            }
            
            if(commit.SuccessCount > 0)
                success = ds.InsertElement(null, true, DicomTag.ReferencedSOPSequence, DicomVRType.SQ, true, 0);

            if(commit.FailedCount > 0)
                failed = ds.InsertElement(null, true, DicomTag.FailedSOPSequence, DicomVRType.SQ, true, 0);

            foreach (StorageCommitItem item in commit.Items)
            {
                DicomElement sequence = null;
                DicomElement sequenceItem = null;

                if (item.Status == DicomCommandStatusType.Success)
                    sequence = success;
                else
                    sequence = failed;

                sequenceItem = ds.InsertElement(sequence, true, DicomTag.Item, DicomVRType.SQ, false, -1);
                ds.InsertElementAndSetValue(sequenceItem, true, DicomTag.ReferencedSOPClassUID, item.SOPClassUID);
                ds.InsertElementAndSetValue(sequenceItem, true, DicomTag.ReferencedSOPInstanceUID, item.SOPInstanceUID);

                if (sequence == failed)
                {
                    ds.InsertElementAndSetValue(sequenceItem, true, DicomTag.FailureReason, Convert.ToInt16(item.Status));
                }                
            }

            return ds;
        }

        #region IProcessNAction Members

       public void MyDelegate(MyParameters p)
       {
          Leadtools.AddIn.StorageCommit.StorageCommit commit = new Leadtools.AddIn.StorageCommit.StorageCommit();
          DicomRequest request = new DicomRequest(p._client);

          this.AddCommitItem(p._ds, DicomTag.ReferencedPerformedProcedureStepSequence, commit);
          this.AddCommitItem(p._ds, DicomTag.ReferencedSOPSequence, commit);
          foreach (StorageCommitItem item in commit.Items)
          {
             string sql = string.Format("SELECT * FROM Images WHERE SOPInstanceUID = '{0}'", item.SOPInstanceUID);
             SqlCeDataReader r = SqlCeHelper.ExecuteReader(p._connectionString, sql);
             if (r.Read())
             {
                if (r["SOPClassUID"].ToString() == item.SOPClassUID)
                {
                   string referencedFile = r["referencedFile"].ToString();
                   if (File.Exists(referencedFile))
                   {
                      item.Status = DicomCommandStatusType.Success;
                   }
                   else
                   {
                      item.Status = DicomCommandStatusType.NoSuchObjectInstance;
                   }
                }
                else
                {
                   item.Status = DicomCommandStatusType.ClaseInstanceConflict;
                }
                item.StudyInstanceUID = r["StudyInstanceUID"].ToString();
             }
             else
                item.Status = DicomCommandStatusType.NoSuchObjectInstance;
             r.Close();
          }
          DicomDataSet commitDS = BuildDataset(p._client, commit,p.ServerAE);
          PresentationContext pc = new PresentationContext();

          pc.AbstractSyntax = DicomUidType.StorageCommitmentPushModelClass;
          pc.TransferSyntaxes.Add(DicomUidType.ImplicitVRLittleEndian);
          request.PresentationContexts.Add(pc);
          request.RequireMessagePump = true;

          request.ReceiveNReportResponse += new ReceiveNReportResponseDelegate(request_ReceiveNReportResponse);
          request.ConnectType = ConnectType.Conditional;

          _DicomRequest.SendNReportRequest(request, p._presentationId, p._messageId, DicomUidType.StorageCommitmentPushModelClass,
                                               DicomUidType.StorageCommitmentPushModelInstance,
                                               commit.FailedCount > 0 ? 2 : 1, commitDS);
       }


        [PresentationContext(DicomUidType.StorageCommitmentPushModelClass,DicomUidType.ImplicitVRLittleEndian)]
        public DicomCommandStatusType OnNAction(DicomClient Client, byte PresentationId, int MessageId,string AffectedClass, string Instance, int Action, DicomDataSet Request, DicomDataSet Response)
        {
           DicomDataSet ds = new DicomDataSet(Client.Server.TemporaryDirectory);
           string ConnectionString = "Data Source='" + Client.Server.ServerDirectory + @"\Dicom.sdf'";
           string DBFile = Client.Server.ServerDirectory + @"\Dicom.sdf";

           if (!File.Exists(DBFile))
              return DicomCommandStatusType.ResourceLimitation;

           ds.Copy(Request, null, null);

           MyParameters parameters = new MyParameters();
           parameters._client = Client;
           parameters._ds = ds;
           parameters._connectionString = ConnectionString;
           parameters._presentationId = PresentationId;
           parameters._messageId = MessageId;
           parameters.ServerAE = Client.Server.AETitle;
           result = AsyncHelper.Execute<MyParameters>(new Action<MyParameters>(this.MyDelegate), parameters);

           Response = null;
           return DicomCommandStatusType.Success;
        }

        void request_ReceiveNReportResponse(DicomRequest request,byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, int dicomEvent, DicomDataSet dataSet)
        {            
        }

        #endregion

        #region IProcessBreak Members

        public void Break(BreakType type)
        {
            if (result != null && !result.IsCompleted)
                result.Cancel();
        }

        #endregion
    }

   public class MyParameters
   {
      // Fields
      public DicomClient _client;
      public string _connectionString;
      public DicomDataSet _ds;
      public byte _presentationId;
      public int _messageId;
      public string ServerAE;
   }
}
