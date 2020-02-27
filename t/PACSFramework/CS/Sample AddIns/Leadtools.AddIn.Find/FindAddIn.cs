// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom.AddIn.Attributes;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;
using System.Data.SqlServerCe;
using Leadtools.Dicom.AddIn.Common;

namespace Leadtools.AddIn.Store
{
    [DicomAddIn("CFIND AddIn", "1.0.0.0", Description = "Implements C-FIND-REQ", Author = "")]
    public class FindAddIn : IProcessCFind
    {
        internal BreakType BreakType;
        internal bool Cancel = false;

        #region IProcessCFind Members

        public event MatchFoundDelegate MatchFound;

        [PresentationContext(DicomUidType.PatientRootQueryFind, new byte[] {1,0,1},DicomUidType.ImplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.StudyRootQueryFind, DicomUidType.ImplicitVRLittleEndian)]
        public DicomCommandStatusType OnFind(DicomClient Client, byte PresentationId, int MessageId, string AffectedClass, 
                                             DicomCommandPriorityType Priority, DicomDataSet Request)
        {
            if (Request == null)
                return DicomCommandStatusType.InvalidArgumentValue;

            try
            {
                string level = Request.GetValue<string>(DicomTag.QueryRetrieveLevel, string.Empty);
                DicomCommandStatusType status = Module.GetAttributeStatus(level, AffectedClass, Request);
                DicomDataSet response = new DicomDataSet(Client.Server.TemporaryDirectory);

                if (status != DicomCommandStatusType.Success)
                {
                    return status;
                }

                response.Initialize(DicomClassType.Undefined, DicomDataSetInitializeFlags.ExplicitVR | DicomDataSetInitializeFlags.LittleEndian);
                switch (level.ToUpper())
                {
                    case "PATIENT":
                        response.InsertElementAndSetValue(DicomTag.QueryRetrieveLevel, "PATIENT");

                        //
                        // Required Keys
                        //
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.PatientBirthDate);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.PatientBirthTime);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.PatientSex);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.EthnicGroup);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.PatientComments);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.NumberOfPatientRelatedStudies);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.NumberOfPatientRelatedSeries);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.NumberOfPatientRelatedInstances);
                        status = DB.FindPatient(this, Module.ServerInfo.ConnectionString, Request, response);
                        break;
                    case "STUDY":
                        response.InsertElementAndSetValue(DicomTag.QueryRetrieveLevel, "STUDY");

                        // Required Keys
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.StudyDate);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.StudyTime);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.AccessionNumber);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.StudyID);

                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.PatientName);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.PatientID);               

                        // Optional Keys
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.StudyDescription);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.ReferringPhysicianName);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.NumberOfStudyRelatedSeries);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.NumberOfStudyRelatedInstances);
                        status = DB.FindStudy(this, Module.ServerInfo.ConnectionString, Request, response);
                        break;
                    case "SERIES":
                        response.InsertElementAndSetValue(DicomTag.QueryRetrieveLevel, "SERIES");

                        // Required Keys
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.StudyInstanceUID);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.Modality);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.SeriesNumber);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.SeriesDate);

                        // Optional Keys
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.SeriesDescription);
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.NumberOfSeriesRelatedInstances);
                        status = DB.FindSeries(this, AffectedClass, Module.ServerInfo.ConnectionString, Request, response);
                        break;
                    case "IMAGE":
                        response.InsertElementAndSetValue(DicomTag.QueryRetrieveLevel, "IMAGE");

                        // Required Keys
                        ExtensionMethods.InsertKeyElement(response, Request, DicomTag.InstanceNumber);
                        status = DB.FindImage(this, AffectedClass, Module.ServerInfo.ConnectionString, Request, response);
                        break;
                    default:
                        return DicomCommandStatusType.InvalidAttributeValue;
                }
                return status;
                
            }
            catch (Exception)
            {
                return DicomCommandStatusType.ProcessingFailure;
            }            
        }

        #endregion  
        
        internal bool OnMatchFound(DicomDataSet ds)
        {
            if (MatchFound != null)
            {
                MatchFoundEventArgs e = new MatchFoundEventArgs(ds);

                MatchFound(this, e);                
            }
            return false;
        }

        #region IProcessBreak Members

        public void Break(BreakType type)
        {
            Cancel = true;
            BreakType = type;
        }

        #endregion
    }

    public class GetInstanceFileName : IProcessServiceMessage
    {
       private const string GetReferencedFile = "99F19F47-C51B-4961-82EC-FBD7C1091390";

       #region IProcessServiceMessage Members

       public bool CanProcess(string MessageId)
       {
          return MessageId == GetReferencedFile;
       }

       public ServiceMessage Process(ServiceMessage Message)
       {
          ServiceMessage message = new ServiceMessage();

          if (Message.Message == GetReferencedFile)
          {
             string sopInstanceUID = Message.Data[0] as string;
             string referenceFile = DB.GetReferencedFile(Module.ServerInfo.ConnectionString, sopInstanceUID);

             message.Message = Message.Message;
             message.Data.Add(sopInstanceUID);
             message.Data.Add(referenceFile);
          }
          return message;
       }

       #endregion       
    }
}
