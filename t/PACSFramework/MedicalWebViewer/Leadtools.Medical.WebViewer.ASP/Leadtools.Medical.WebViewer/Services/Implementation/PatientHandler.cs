// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Net;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using Leadtools.Medical.WebViewer.DataContracts;
using System.IO;
using Leadtools.Medical.WebViewer.Addins;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.ServiceContracts;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{

   public class PatientHandler : IPatientHandler
   {
      IStoreAddin _storeAddin;
      IQueryAddin _queryAddin;

      public PatientHandler(AddinsFactory factory)
      {
         _storeAddin = factory.CreateStoreAddin();
         _queryAddin = factory.CreateQueryAddin();
      }

      public bool UpdatePatient(string authenticationCookie, PatientInfo_Json info)
      {
         string userName;


         try
         {
            userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);
         }
         catch (Exception ex)
         {
            throw ex;
         }

         QueryOptions queryOptions = new QueryOptions();
         queryOptions.PatientsOptions = new PatientsQueryOptions();
         queryOptions.PatientsOptions.PatientID = info.PatientId;

         PatientData[] patientData = _queryAddin.FindPatients(userName, queryOptions);
         if (patientData == null || patientData.Length == 0)
         {
            throw new Exception("PatientID does not exist: " + info.PatientId);
            // return false;
         }

         using (DicomDataSet ds = new DicomDataSet())
         {
            ChangePatient c = new ChangePatient();
            const string notUsed = "NotUsed";

            c.OriginalPatientId = info.PatientId;
            c.PatientId = info.PatientId;
            c.Name = new PersonName(info.Name);
            c.Sex = info.Sex;
            c.PatientComments = info.Comments;
            c.EthnicGroup = info.EthnicGroup;

            if (info.BirthDate != null)
            {
               c.Birthdate = DateTime.Parse(info.BirthDate);
            }

            c.Description = notUsed;
            c.Reason = notUsed;
            c.Operator = notUsed;
            c.Station = notUsed;
            c.Date = DateTime.Now;
            c.Time = c.Date;
            c.TransactionID = notUsed;

            ds.Set(c);

            _storeAddin.UpdatePatient(ds);

         }

         return true;
      }

      public bool AddPatient(string authenticationCookie, PatientInfo_Json patientInfo, string userData)
      {
         try
         {
            string userName;

            userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanStore);

            StoreItemInfo storeItemInfo = new StoreItemInfo();
            storeItemInfo.MimeType = SupportedMimeTypes.DICOM;
            DicomDataSet ds = new DicomDataSet();
            ds.Initialize(DicomClassType.Patient, DicomDataSetInitializeFlags.AddMandatoryElementsOnly);

            // The 2014 specification has added ReferencedStudySequence to the Patient Module (Retired) as a mandatory element
            // Remove this element for adding the patient
            DicomElement element = ds.FindFirstElement(null, DicomTag.ReferencedStudySequence, true);
            if (element != null)
            {
               ds.DeleteElement(element);
            }

            SetPatientInfo(patientInfo, ds, DicomCharacterSetType.UnicodeInUtf8);

            MemoryStream ms = new MemoryStream();
            ds.Save(ms, DicomDataSetSaveFlags.None);

            //TODO: Store Patient information (Need to determine how this will be handled in the DB. Same for the unapproved captured images)

            QueryOptions queryOptions = new QueryOptions();
            queryOptions.PatientsOptions = new PatientsQueryOptions();
            queryOptions.PatientsOptions.PatientID = patientInfo.PatientId;

            // If patientID already exists, return 'false'
            PatientData[] patientData = _queryAddin.FindPatients(userName, queryOptions);
            if (patientData.Length > 0)
            {
               return false;
            }

            // Otherwise, add the patient
            _storeAddin.StoreItem(ms, storeItemInfo);

            return true;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            return false;
         }
      }

      private void SetPatientInfo(PatientInfo_Json patientInfo, DicomDataSet ds, DicomCharacterSetType characterSetType)
      {
         DicomDateValue dateValue = GetDateTimeValue(patientInfo.BirthDate);

         ds.InsertElementAndSetValue(DicomTag.PatientID, patientInfo.PatientId);
         ds.InsertElementAndSetValue(DicomTag.PatientName, patientInfo.Name);
         ds.InsertElementAndSetValue(DicomTag.PatientBirthDate, dateValue);
         ds.InsertElementAndSetValue(DicomTag.PatientSex, patientInfo.Sex);
         ds.InsertElementAndSetValue(DicomTag.PatientComments, patientInfo.Comments);
         ds.InsertElementAndSetValue(DicomTag.EthnicGroup, patientInfo.EthnicGroup);

         ds.InsertElementAndSetValue(DicomTag.StudyInstanceUID, DicomUtilities.GenerateDicomUniqueIdentifier());
         ds.InsertElementAndSetValue(DicomTag.SeriesInstanceUID, DicomUtilities.GenerateDicomUniqueIdentifier());
         ds.InsertElementAndSetValue(DicomTag.SOPInstanceUID, DicomUtilities.GenerateDicomUniqueIdentifier());
      }

      public DicomDateValue GetDateTimeValue(string date)
      {
         DateTime dt;
         if (DateTime.TryParse(date, out dt))
         {
            return new DicomDateValue(dt.Year, dt.Month, dt.Day);
         }
         return new DicomDateValue();
      }

      public bool DeletePatient(string patientId)
      {
         if (string.IsNullOrEmpty(patientId))
         {
            throw new Exception("patientId is null or empty");

         }
         return _storeAddin.DeletePatient(patientId);

      }


   }
}
