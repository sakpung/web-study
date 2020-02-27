// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom.Common.Attributes;
using Leadtools.Dicom.Common.Extensions;
using DicomDemo.Utils;

namespace DicomDemo.Dicom
{
    public class NActionScu : DicomConnection
    {                     
        public static int MessageId = 0;
        private new DicomCommandStatusType _Status = DicomCommandStatusType.Success;

        public const string PatientUpdateClass = "1.2.840.114257.15.1.3";
        public const string PatientUpdateInstance = "1.2.840.114257.15.1.3.100.1";

        public const int ChangePatient = 100;
        public const int DeletePatient = 101;
        public const int MergePatient = 102;
        public const int ChangeSeries = 103;
        public const int DeleteSeries = 104;
        public const int MergeStudy = 105;
        public const int MoveStudyToNewPatient = 106;
        public const int CopyPatient = 107;
        public const int CopyStudy = 108;
        public const int MoveSeries = 109;
        public const int ChangeStudy = 110;
        public const int DeleteStudy = 111;

        private string _ErrorMessage;

        public string ErrorMessage
        {
           get
           {
              return _ErrorMessage;
           }
        }

        public NActionScu()
            : base()
        {
        }

#if !LEADTOOLS_V20_OR_LATER
        public NActionScu(string TemporaryDirectory, DicomNetSecurityeMode SecurityMode, DicomOpenSslContextCreationSettings openSslContextCreationSettings)
           : base(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
        {
        }
#else
        public NActionScu(string TemporaryDirectory, DicomNetSecurityMode SecurityMode, DicomOpenSslContextCreationSettings openSslContextCreationSettings)
            : base(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
        {
        }
#endif // #if !LEADTOOLS_V20_OR_LATER

        private DicomDataSet GetDataset(object findObject, BeforeAddTagDelegate OnBeforeAdd)
        {
            DicomDataSet ds = null;

            ds = new DicomDataSet(TemporaryDirectory);
            ds.Initialize(_CurrentInstance.ClassType, DicomDataSetInitializeType.ExplicitVRLittleEndian);
            ds.Set(OnBeforeAdd, findObject);
            return ds;
        }

        private InstanceAttribute GetFindAttribute(object findObject)
        {
            InstanceAttribute[] cfa = (InstanceAttribute[])findObject.GetType().GetCustomAttributes(typeof(InstanceAttribute), false);

            if (cfa == null || cfa.Length == 0)
                return null;
            return cfa[0];
        }

        protected override List<PresentationContext> GetPresentationContexts()
        {
            List<PresentationContext> contexts = base.GetPresentationContexts();
            PresentationContext pc = new PresentationContext(NActionScu.PatientUpdateClass);

            pc.TransferSyntaxes.Add(DicomUidType.ImplicitVRLittleEndian);
            contexts.Add(pc);
            return contexts;
        }

        public DicomCommandStatusType SendNActionRequest<TQuery>(DicomScp Scp, TQuery Query,int action,string instance)
        {
            DicomDataSet ds = null;

            if (Scp == null)
                throw new ArgumentNullException("Scp");

            if (Query == null)
                throw new ArgumentNullException("Query");

            _ErrorMessage = string.Empty;
            try
            {
               _CurrentInstance = GetFindAttribute(Query);
               if (_CurrentInstance == null)
                  throw new InvalidOperationException();

               ds = GetDataset(Query, null);
               Connect(Scp);
               if (parameters.Result == null)
               {
                  SendNAction(ds, action, instance);
               }
               else
               {
                  throw new ClientAssociationException(parameters.Reason);
               }
            }            
            catch (Exception e)
            {
               _ErrorMessage = e.Message;               
               _Status = DicomCommandStatusType.Failure;
            }
            finally
            {
                if (IsConnected())
                    Close();
                if (ds != null)
                {
                    ds.Dispose();
                    ds = null;
                }
            }

            return _Status;
        }

        private void SendNAction(DicomDataSet ds,int action, string instance)
        {
            byte pid = 0;            
            string abstractSyntax = string.Empty;

            pid = Association.FindAbstract(_CurrentInstance.AbstractSyntax);
            if (pid == 0 || Association.GetResult(pid) != DicomAssociateAcceptResultType.Success)
            {
               throw new DicomException("Invalid Abstract Syntax");
            }
            abstractSyntax = _CurrentInstance.AbstractSyntax;
            SendNActionRequest(pid, MessageId++, _CurrentInstance.AbstractSyntax, instance, action, ds);
            Wait();
            Release();
        }

        protected override void OnReceiveNActionResponse(byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, int action, DicomDataSet dataSet)
        {
            _Status = status;
            dicomEventResponse.Set();            
        }

        public string GetErrorMessage()
        {
           if (_ErrorMessage == "Invalid Abstract Syntax")
           {
              return "Server doesn't support update action.  Either update client doesn't have permission or the Patient " +
                     "Updater addin is not available.  Please contact your server administrator.";
           }
           return _ErrorMessage;
        }
    }
}
