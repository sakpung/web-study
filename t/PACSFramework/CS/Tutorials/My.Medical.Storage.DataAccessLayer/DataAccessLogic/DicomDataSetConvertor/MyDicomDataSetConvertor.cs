// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Medical.Storage.DataAccessLayer.DataAccessLogic.BusinessEntity;
using Leadtools.Dicom;
using System.Data;
using System.Globalization;

namespace My.Medical.Storage.DataAccessLayer.DataAccessLogic.DicomDataSetConvertor
{
   public class MyDicomDataSetConvertor
   {
      //Extracts the patient, study, series, and instance information from a DicomDataSet object, and add/updates the DataSet tables (patient, study, series, instance) accordingly.
      public void FillADONetDataSet( MyDataSet instanceDataSet, DicomDataSet dicomDataSet, string referencedFileName, string retrieveAe, bool updateExistentPatient, bool updateExistentStudy, bool updateExistentSeries, bool updateExistentInstances )
      {
         bool enforceConst = instanceDataSet.EnforceConstraints;

         instanceDataSet.EnforceConstraints = false;

         try
         {
            FillPatientData   (dicomDataSet, instanceDataSet, updateExistentPatient,   retrieveAe);
            FillStudiesData   (dicomDataSet, instanceDataSet, updateExistentStudy,     retrieveAe);
            FillSeriesData    (dicomDataSet, instanceDataSet, updateExistentSeries,    retrieveAe);
            FillInstancetData (dicomDataSet, instanceDataSet, updateExistentInstances, referencedFileName, retrieveAe);
         }
         finally
         {
            try
            {
               instanceDataSet.EnforceConstraints = enforceConst;
            }
            catch (Exception ex1)
            {
               DataTable dt = instanceDataSet.Tables.OfType<DataTable>().Where((t) => t.HasErrors).FirstOrDefault();

               if (dt != null)
               {
                  DataRow[] rows = dt.GetErrors();

                  throw new DataException(rows[0].RowError, ex1);
               }
               throw ex1;
            }
         }
      }

      // Helper function that returns true if 
      private bool CanSetValue(object value, bool update, DataRow row, DataColumn column)
      {
         if (null == value)
         {
            return false;
         }
         if (update)
         {
            return true;
         }

         return (row.IsNull(column));
      }

      private bool CanSetValue(object value, bool update, DataTable table)
      {
         if (null == value)
         {
            return false;
         }
         if (update)
         {
            return true;
         }

         return (table.Rows.Count == 0);
      }

      /// <summary>
      /// If true, data from the DicomDataSet is truncated if necessary, so that if fits in the DataTable column maximum length.
      /// </summary>
      public bool AutoTruncate
      {
         get;
         set;
      }

      /// <summary>
      /// Adds a new row to the DataSet Patient table (MyPatientTable) if the DicomDataSet PatientID does not already exist
      /// </summary>
      /// <param name="ds">The Leadtools.Dicom.DicomDataSet that is being stored</param>
      /// <param name="instanceDataSet">The DataSet that contains the patient, study, series, and instance tables</param>
      /// <param name="updateExistentPatient">If 'true', update the existing patient with information from dicomDataSet</param>
      /// <param name="retrieveAe">retrieveAe">AE Title of the client doing the retrieval</param>
      private void FillPatientData(DicomDataSet ds, MyDataSet instanceDataSet, bool updateExistentPatient, string retrieveAe)
      {
         string patientId = ds.MyGetStringValue(DicomTag.PatientID, AutoTruncate, instanceDataSet.MyPatientTable.PatientIdColumn.MaxLength);

         if (null == patientId)
         {
            return;
         }

         MyDataSet.MyPatientTableRow patientRow = null;
         DataRow[] rows = instanceDataSet.MyPatientTable.Select(string.Format("PatientIdentification = '{0}'", patientId));

         MyDataSet.MyPatientTableRow[] patientRows = (MyDataSet.MyPatientTableRow[])rows;
         if (patientRows != null && patientRows.Length > 0)
         {
            patientRow = patientRows[0];
         }

         bool patientFound = (null != patientRow);

         if (!patientFound)
         {
            patientRow = instanceDataSet.MyPatientTable.NewMyPatientTableRow();

            patientRow.PatientIdentification = patientId;

            instanceDataSet.MyPatientTable.AddMyPatientTableRow(patientRow);
         }
         else if (!updateExistentPatient)
         {
            return;
         }

         FillPatientInformation(patientRow,
                                  ds,
                                  instanceDataSet,
                                  patientId,
                                  retrieveAe,
                                  updateExistentPatient);
      }

      /// <summary>
      /// If the ‘update’ parameter is true, replaces all the DataSet Patient table information with the corresponding information from the DicomDataSet.
      /// </summary>
      /// <param name="patient">Row of the patient table that is being udpated</param>
      /// <param name="ds">The Leadtools.Dicom.DicomDataSet that is being stored</param>
      /// <param name="instanceDataSet">The DataSet that contains the patient, study, series, and instance tables</param>
      /// <param name="patientId">The PatientID of the patient being updated</param>
      /// <param name="retrieveAE">retrieveAe">AE Title of the client doing the retrieval</param>
      /// <param name="update">If 'true', updates the DataSet Patient table information with the corresponding information from the DicomDataSet</param>
      /// <remarks>
      /// This method needs to change based on your schema.  For the MyDicomDb schema, we update all fields in the patient table
      /// <list>
      /// <item>PatientName</item>
      /// <item>PatientBirthday</item>
      /// <item>PatientSex</item>
      /// <item>PatientComments</item>
      /// </list>
      /// </remarks>
      private void FillPatientInformation(MyDataSet.MyPatientTableRow patient, DicomDataSet ds, MyDataSet instanceDataSet, string patientId, string retrieveAE, bool update)
      {
         try
         {
            // PatientName
            string patientName = ds.MyGetStringValue(DicomTag.PatientName, AutoTruncate, instanceDataSet.MyPatientTable.PatientNameColumn.MaxLength);
            if (CanSetValue(patientName, update, patient, instanceDataSet.MyPatientTable.PatientNameColumn))
            {
               patient.PatientName = patientName;
            }

            // PatientBirthday
            DateTime? patientBirthDate = ds.MyGetDateTime(DicomTag.PatientBirthDate, DicomTag.PatientBirthTime);
            if (CanSetValue(patientBirthDate, update, patient, instanceDataSet.MyPatientTable.PatientBirthdayColumn))
            {
               patient.PatientBirthday = patientBirthDate.Value;
            }

            // PatientSex
            char patientSex = ds.GetValue<char>(DicomTag.PatientSex, 'X');
            string patientSexString = string.Empty;
            switch (patientSex)
            {
               case 'O':
                  patientSexString = "O";
                  break;

               case 'M':
                  patientSexString = "M";
                  break;

               case 'F':
                  patientSexString = "F";
                  break;
            }

            if (CanSetValue(patientSex, update, patient, instanceDataSet.MyPatientTable.PatientSexColumn))
            {
               patient.PatientSex = patientSexString;
            }

            // PatientComments
            string patientComments = ds.MyGetStringValue( DicomTag.PatientComments, AutoTruncate, instanceDataSet.MyPatientTable.PatientCommentsColumn.MaxLength);
            if (CanSetValue(patientComments, update, patient, instanceDataSet.MyPatientTable.PatientCommentsColumn))
            {
               patient.PatientComments = patientComments;
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
      
      /// <summary>
      /// Adds a new row to the DataSet Study Table (MyStudyTable) if the DicomDataSet StudyInstanceUID does not already exist
      /// </summary>
      /// <param name="ds">The Leadtools.Dicom.DicomDataSet that is being stored</param>
      /// <param name="instanceDataSet">The DataSet that contains the patient, study, series, and instance tables</param>
      /// <param name="updateExistentPatient">If 'true', update the existing patient with information from dicomDataSet</param>
      /// <param name="retrieveAe">retrieveAe">AE Title of the client doing the retrieval</param>
      private void FillStudiesData(DicomDataSet ds, MyDataSet instanceDataSet, bool updateExistentStudy, string retrieveAe)
      {
         string patientIdentification = ds.MyGetStringValue( DicomTag.PatientID, AutoTruncate, instanceDataSet.MyPatientTable.PatientIdentificationColumn.MaxLength);
         string studyInstanceUID = ds.MyGetStringValue( DicomTag.StudyInstanceUID, AutoTruncate, instanceDataSet.MyStudyTable.StudyStudyInstanceUIDColumn.MaxLength);

         if (null == studyInstanceUID)
         {
            return;
         }

         MyDataSet.MyStudyTableRow studyRow = null;
         DataRow[] rows = instanceDataSet.MyStudyTable.Select(string.Format("StudyStudyInstanceUID = '{0}'", studyInstanceUID));
         MyDataSet.MyStudyTableRow[] studyRows = (MyDataSet.MyStudyTableRow[])rows;
         if (studyRows != null && studyRows.Length > 0)
         {
            studyRow = studyRows[0];
         }

         bool studyFound = (null != studyRow);

         if (!studyFound)
         {
            studyRow = instanceDataSet.MyStudyTable.NewMyStudyTableRow();

            studyRow.StudyPatientId = -1;                     // Fill this in later
            studyRow.StudyStudyInstanceUID = studyInstanceUID;

            instanceDataSet.MyStudyTable.AddMyStudyTableRow(studyRow);
         }
         else if (!updateExistentStudy)
         {
            return;
         }

         FillStudyInformation(studyRow,
                                ds,
                                instanceDataSet,
                                patientIdentification,
                                studyInstanceUID,
                                retrieveAe,
                                updateExistentStudy);
      }

      /// <summary>
      /// If the ‘update’ parameter is true, replaces all the DataSet Study table information with the corresponding information from the DicomDataSet.
      /// </summary>
      /// <param name="study">Row of the 'study' table that is being udpated</param>
      /// <param name="ds">The Leadtools.Dicom.DicomDataSet that is being stored</param>
      /// <param name="instanceDataSet">The DataSet that contains the patient, study, series, and instance tables</param>
      /// <param name="patientIdentification">The PatientID that corresponds to the study of the study row being updated</param>
      /// <param name="studyInstanceUID">The StudyInstanceUID of the study row being udpated.</param>
      /// <param name="retrieveAE">retrieveAe">AE Title of the client doing the retrieval</param>
      /// <param name="update">If 'true', updates the DataSet Study table information with the corresponding information from the DicomDataSet</param>
      /// <remarks>
      /// This method needs to change based on your schema.  For the MyDicomDb schema, we update all fields in the 'study' table
      /// <list>
      /// <item>StudyDate</item>
      /// <item>AccessionNumber</item>
      /// <item>StudyDescription</item>
      /// <item>StudyReferringPhysiciansName</item>
      /// </list>
      /// </remarks>
      private void FillStudyInformation(MyDataSet.MyStudyTableRow study, DicomDataSet ds, MyDataSet instanceDataSet, string patientIdentification, string studyInstanceUID, string retrieveAE, bool update)
      {
         // StudyDate
         DateTime? studyDate = ds.MyGetDateTime(DicomTag.StudyDate, DicomTag.StudyTime);
         if (CanSetValue(studyDate, update, study, instanceDataSet.MyStudyTable.StudyStudyDateColumn))
         {
            study.StudyStudyDate = studyDate.Value;
         }
         
         // AccessionNumber
         string accessionNumber = ds.MyGetStringValue( DicomTag.AccessionNumber, AutoTruncate, instanceDataSet.MyStudyTable.StudyAccessionNumberColumn.MaxLength);
         if (CanSetValue(accessionNumber, update, study, instanceDataSet.MyStudyTable.StudyAccessionNumberColumn))
         {
            study.StudyAccessionNumber = accessionNumber;
         }

         // StudyDescription
         string studyStudyDescription = ds.MyGetStringValue( DicomTag.StudyDescription, AutoTruncate, instanceDataSet.MyStudyTable.StudyStudyDescriptionColumn.MaxLength);
         if (CanSetValue(studyStudyDescription, update, study, instanceDataSet.MyStudyTable.StudyStudyDescriptionColumn))
         {
            study.StudyStudyDescription = studyStudyDescription;
         }

         // StudyReferringPhysiciansName
         string referringPhysiciansName = ds.MyGetStringValue( DicomTag.ReferringPhysicianName, AutoTruncate, instanceDataSet.MyStudyTable.StudyReferringPhysiciansNameColumn.MaxLength);
         if (CanSetValue(referringPhysiciansName, update, study, instanceDataSet.MyStudyTable.StudyReferringPhysiciansNameColumn))
         {
            study.StudyReferringPhysiciansName = referringPhysiciansName;
         }

         string studyStudyId = ds.MyGetStringValue( DicomTag.StudyID, AutoTruncate, instanceDataSet.MyStudyTable.StudyStudyIdColumn.MaxLength);
         if (CanSetValue(studyStudyId, update, study, instanceDataSet.MyStudyTable.StudyStudyIdColumn))
         {
            study.StudyStudyId = studyStudyId;
         }
      }

      /// <summary>
      /// Adds a new row to the DataSet Study Table (MySeriesTable) if the DicomDataSet SeriesInstanceUID does not already exist
      /// </summary>
      /// <param name="ds">The Leadtools.Dicom.DicomDataSet that is being stored</param>
      /// <param name="instanceDataSet">The DataSet that contains the patient, study, series, and instance tables</param>
      /// <param name="updateExistentPatient">If 'true', update the existing patient with information from dicomDataSet</param>
      /// <param name="retrieveAe">retrieveAe">AE Title of the client doing the retrieval</param>
      private void FillSeriesData(DicomDataSet ds, MyDataSet instanceDataSet, bool updateExistentSeries, string retrieveAe)
      {
         // studyInstanceUID = GetStringValue(dicomDataSet, DicomTag.StudyInstanceUID, AutoTruncate, instanceDataSet.Series.MaxLength);
         string seriesInstanceUID = ds.MyGetStringValue( DicomTag.SeriesInstanceUID, AutoTruncate, instanceDataSet.MySeriesTable.SeriesSeriesInstanceUIDColumn.MaxLength);

         if (/* null == studyInstanceUID  || */ null == seriesInstanceUID)
         {
            return;
         }

         // MyDataSet.SeriesRow seriesRow = instanceDataSet.Series.FindBySeriesInstanceUID(seriesInstanceUID);
         MyDataSet.MySeriesTableRow seriesRow = null;
         DataRow[] rows = instanceDataSet.MySeriesTable.Select(string.Format("SeriesSeriesInstanceUID = '{0}'", seriesInstanceUID));
         MyDataSet.MySeriesTableRow[] seriesRows = (MyDataSet.MySeriesTableRow[])rows;
         if (seriesRows != null && seriesRows.Length > 0)
         {
            seriesRow = seriesRows[0];
         }

         bool seriesFound = (null != seriesRow);

         if (!seriesFound)
         {
            seriesRow = instanceDataSet.MySeriesTable.NewMySeriesTableRow();

            // seriesRow.StudyInstanceUID = studyInstanceUID;
            seriesRow.SeriesSeriesInstanceUID = seriesInstanceUID;

            instanceDataSet.MySeriesTable.AddMySeriesTableRow(seriesRow);
         }
         else if (!updateExistentSeries)
         {
            return;
         }

         FillSeriesInformation(seriesRow,
                                 ds,
                                 instanceDataSet,
                                 seriesInstanceUID,
                                 retrieveAe,
                                 updateExistentSeries);
      }

      /// <summary>
      /// If the ‘update’ parameter is true, replaces all the DataSet 'Series' table information with the corresponding information from the DicomDataSet.
      /// </summary>
      /// <param name="series">Row of the 'series' table that is being udpated</param>
      /// <param name="ds"></param>
      /// <param name="ds">The Leadtools.Dicom.DicomDataSet that is being stored</param>
      /// <param name="instanceDataSet">The DataSet that contains the patient, study, series, and instance tables</param>
      /// <param name="seriesInstanceUID">The SeriesInstanceUID of the study row being udpated</param>
      /// <param name="retrieveAE">retrieveAe">AE Title of the client doing the retrieval</param>
      /// <param name="update">If 'true', updates the DataSet 'Series' table information with the corresponding information from the DicomDataSet</param>
      /// <remarks>
      /// This method needs to change based on your schema.  For the MyDicomDb schema, we update all fields in the 'study' table
      /// <list>
      /// <item>SeriesNumber</item>
      /// <item>SeriesDate</item>
      /// <item>SeriesDescription</item>
      /// <item>Modality</item>
      /// <item>BodyPartExamined</item>
      /// </list>
      /// </remarks>
      private void FillSeriesInformation(MyDataSet.MySeriesTableRow series, DicomDataSet ds, MyDataSet instanceDataSet, string seriesInstanceUID, string retrieveAE, bool update)
      {
         // SeriesNumber
         int? seriesNumber = ds.MyGetIntValue(DicomTag.SeriesNumber);
         if (CanSetValue(seriesNumber, update, series, instanceDataSet.MySeriesTable.SeriesSeriesNumberColumn))
         {
            series.SeriesSeriesNumber = seriesNumber.Value;
         }
 
         // SeriesDate
         DateTime? seriesDate = ds.MyGetDateTime(DicomTag.SeriesDate, DicomTag.SeriesTime);
         if (CanSetValue(seriesDate, update, series, instanceDataSet.MySeriesTable.SeriesSeriesDateColumn))
         {
            series.SeriesSeriesDate = seriesDate.Value;
         }

         // SeriesDescription
         string seriesDescription = ds.MyGetStringValue( DicomTag.SeriesDescription, AutoTruncate, instanceDataSet.MySeriesTable.SeriesSeriesDescriptionColumn.MaxLength);
         if (CanSetValue(seriesDescription, update, series, instanceDataSet.MySeriesTable.SeriesSeriesDescriptionColumn))
         {
            series.SeriesSeriesDescription = seriesDescription;
         }

         // Modality
         string seriesModality = ds.MyGetStringValue( DicomTag.Modality, AutoTruncate, instanceDataSet.MySeriesTable.SeriesModalityColumn.MaxLength);
         if (CanSetValue(seriesModality, update, series, instanceDataSet.MySeriesTable.SeriesModalityColumn))
         {
            series.SeriesModality = seriesModality;
         }

         // BodyPartExamined
         string bodyPartExamined = ds.MyGetStringValue( DicomTag.BodyPartExamined, AutoTruncate, instanceDataSet.MySeriesTable.SeriesBodyPartExaminedColumn.MaxLength);
         if (CanSetValue(bodyPartExamined, update, series, instanceDataSet.MySeriesTable.SeriesBodyPartExaminedColumn))
         {
            series.SeriesBodyPartExamined = bodyPartExamined;
         }

         series.SeriesStudyId = -1;
      }

      /// <summary>
      /// Adds a new row to the DataSet Study Table (MyInstanceTable) if the DicomDataSet SOPInstanceUID does not already exist
      /// </summary>
      /// <param name="ds">The Leadtools.Dicom.DicomDataSet that is being stored</param>
      /// <param name="instanceDataSet">The DataSet that contains the patient, study, series, and instance tables</param>
      /// <param name="updateExistentPatient">If 'true', update the existing patient with information from dicomDataSet</param>
      /// <param name="referencedFileName">Full path of the DICOM file</param>
      /// <param name="retrieveAe">retrieveAe">AE Title of the client doing the retrieval</param>
      private void FillInstancetData(DicomDataSet ds, MyDataSet instanceDataSet, bool updateExistentInstance, string referencedFileName, string retrieveAe)
      {
         string sopInstanceUID = ds.MyGetStringValue( DicomTag.SOPInstanceUID, AutoTruncate, instanceDataSet.MyInstanceTable.SOPInstanceUIDColumn.MaxLength);

         if (null == sopInstanceUID /*|| null == seriesInstanceUID*/)
         {
            return;
         }

         MyDataSet.MyInstanceTableRow instanceRow = null;
         DataRow[] rows = instanceDataSet.MyInstanceTable.Select(string.Format("SOPInstanceUID = '{0}'", sopInstanceUID));
         MyDataSet.MyInstanceTableRow[] seriesRows = (MyDataSet.MyInstanceTableRow[])rows;

         bool instanceFound = (null != instanceRow);

         if (!instanceFound)
         {
            instanceRow = instanceDataSet.MyInstanceTable.NewMyInstanceTableRow();

            instanceRow.SOPInstanceUID = sopInstanceUID;

            instanceDataSet.MyInstanceTable.AddMyInstanceTableRow(instanceRow);
         }
         else if (!updateExistentInstance)
         {
            return;
         }

         FillInstanceInformation(instanceRow,
                                 ds,
                                 instanceDataSet,
                                 sopInstanceUID,
                                 retrieveAe,
                                 referencedFileName,
                                 updateExistentInstance);
      }

      /// <summary>
      /// If the ‘update’ parameter is true, replaces all the DataSet 'Instance' table information with the corresponding information from the DicomDataSet.
      /// </summary>
      /// <param name="instance">Row of the 'instance' table that is being udpated</param>
      /// <param name="ds">The Leadtools.Dicom.DicomDataSet that is being stored</param>
      /// <param name="instanceDataSet">The DataSet that contains the patient, study, series, and instance tables</param>
      /// <param name="sopInstanceUID">The SOPInstanceUID of the study row being udpated</param>
      /// <param name="retrieveAE">retrieveAe">AE Title of the client doing the retrieval</param>
      /// <param name="update">If 'true', updates the DataSet 'Instance' table information with the corresponding information from the DicomDataSet</param>
      /// <remarks>
      /// This method needs to change based on your schema.  For the MyDicomDb schema, we update all fields in the 'Instance' table
      /// <list>
      /// <item>InstanceNumber</item>
      /// <item>SOPClassUID</item>
      /// <item>Rows</item>
      /// <item>Columns</item>
      /// <item>BitsAllocated</item>
      /// <item>ImageLastStoreDate – Updated to current date</item>
      /// <item>ImageFilename – Full path to location where DicomDataSet is stored</item>
      /// </list>
      /// </remarks>
      private void FillInstanceInformation(MyDataSet.MyInstanceTableRow instance, DicomDataSet ds, MyDataSet instanceDataSet, string sopInstanceUID, string retrieveAE, string referencedFileName, bool update)
      {
         try
         {
            // InstanceNumber
            int? instanceNumber = ds.MyGetIntValue(DicomTag.InstanceNumber);
            if (CanSetValue(instanceNumber, update, instance, instanceDataSet.MyInstanceTable.ImageImageNumberColumn))
            {
               instance.ImageImageNumber = instanceNumber.Value;
            }

            // ImageLastStoreDate
            MyDataSet.MyInstanceTableRow myInstanceRow = (MyDataSet.MyInstanceTableRow)instanceDataSet.MyInstanceTable.Rows[0];
            if (myInstanceRow.IsImageLastStoreDateNull())
            {
               instance.ImageLastStoreDate = DateTime.Now;
            }

            // ImageFilename
            if (CanSetValue(referencedFileName, update, instance, instanceDataSet.MyInstanceTable.ImageFilenameColumn))
            {
               instance.ImageFilename = referencedFileName;
            }

            // SOPClassUID
            string sopClassUid;
            sopClassUid = ds.MyGetStringValue( DicomTag.SOPClassUID, AutoTruncate, instanceDataSet.MyInstanceTable.ImageUniqueSOPClassUIDColumn.MaxLength);

            if (CanSetValue(sopClassUid, update, instance, instanceDataSet.MyInstanceTable.ImageUniqueSOPClassUIDColumn))
            {
               instance.ImageUniqueSOPClassUID = sopClassUid;
            }

            // Rows
            int? imageRows = ds.MyGetIntValue(DicomTag.Rows);
            if (CanSetValue(imageRows, update, instance, instanceDataSet.MyInstanceTable.ImageRowsColumn))
            {
               instance.ImageRows = imageRows.Value;
            }

            // Columns
            int? imageColumns = ds.MyGetIntValue(DicomTag.Columns);
            if (CanSetValue(imageColumns, update, instance, instanceDataSet.MyInstanceTable.ImageColumnsColumn))
            {
               instance.ImageColumns = imageColumns.Value;
            }

            // BitsAllocated
            int? imageBitsAllocated = ds.MyGetIntValue(DicomTag.BitsAllocated);
            if (CanSetValue(imageBitsAllocated, update, instance, instanceDataSet.MyInstanceTable.ImageBitsAllocatedColumn))
            {
               instance.ImageBitsAllocated = imageBitsAllocated.Value;
            }


         }
         catch (Exception ex)
         {
            throw ex;
         }
         
         instance.ImageSeriesId = -1;
      }
   }
}
