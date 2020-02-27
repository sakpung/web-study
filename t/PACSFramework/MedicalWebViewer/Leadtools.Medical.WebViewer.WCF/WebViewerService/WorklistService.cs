// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Services;
using System.ServiceModel.Activation;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Wcf.Helper;

namespace Leadtools.Medical.WebViewer.Wcf
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [WebService(Namespace = "http://leadtools.com/")]
    public class WorklistService : IWorklistService
    {
        private IAuthenticationAddin _AuthenticationService = null;
        private IWorklistAddin _worklistAddin;
        private AddinsFactory _Factory { get; set; }

        public WorklistService()
        {
            _Factory = new AddinsFactory();
            _AuthenticationService = _Factory.CreateAuthenticationAddin();
            _worklistAddin = _Factory.CreateWorklistAddin();
        }

        public string AddPatient(string authenticationCookie, WorklistPatient patient)
        {
            string userName;

            ServiceUtils.Authenticate(_AuthenticationService, authenticationCookie, out userName, null);
            return _worklistAddin.AddPatient(userName, patient);
        }

        public WorklistResult[] QueryWorklist(string authenticationCookie, WorklistQueryOptions options)
        {
            string userName;

            ServiceUtils.Authenticate(_AuthenticationService, authenticationCookie, out userName, null);
            return _worklistAddin.QueryWorklist(userName, options);
        }

        public string AddCaptureRequest(string authenticationCookie, string patientID, string issuerOfPatientID, CaptureRequest request)
        {
            string userName;

            ServiceUtils.Authenticate(_AuthenticationService, authenticationCookie, out userName, null);

            if (string.IsNullOrEmpty(patientID))
            {
                throw new Exception("Must provide a value for patientID");
            }

            if (string.IsNullOrEmpty(issuerOfPatientID))
            {
                throw new Exception("Must provide a value for issuerOfPatientID");
            }

            return _worklistAddin.AddCaptureRequest(userName, patientID, issuerOfPatientID, request);
        }
    }
}
