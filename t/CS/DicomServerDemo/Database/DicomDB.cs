// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Data;

using Leadtools.Dicom;
using Leadtools.DicomDemos;

namespace Leadtools.Demos.Database
{
   public enum InsertReturn
   {
      Exists,
      Error,
      Success
   }

   /// <summary>
   /// Summary description for DicomDB.
   /// </summary>
   public class DicomDB : DBBase
   {
      // If we have to create database this will signal us to load
      //  default images.
      public bool NeedImport = false;
      public string ImageDir;
      private Object adoDatasetLock = new Object();

      public DicomDB(string dbFileName)
      {
         this.dbFileName = dbFileName;

         if (!LoadDatabase())
         {
            CreateDatabase();
            NeedImport = true;
         }

         lock (adoDatasetLock)
         {
            if (ds.Tables["Images"] != null)
            {
               ds.Tables["Images"].RowDeleting += new DataRowChangeEventHandler(DicomDB_RowDeleting);
            }
         }
      }

      void DicomDB_RowDeleting(object sender, DataRowChangeEventArgs e)
      {
         string file = e.Row["ReferencedFile"].ToString();

         try
         {
            File.Delete(file);
         }
         catch
         {
         }
      }

      private bool CreateDatabase()
      {
         bool created = true;
         lock (adoDatasetLock)
         {
            try
            {
               DataTable table;
               DataColumn Patients_PatientID, Studies_PatientID;
               DataColumn Studies_InstUID, Series_InstUID;
               DataColumn Series_ID, Images_ID;
               DataColumn[] key = new DataColumn[1];

               table = ds.Tables.Add("Patients");
               Patients_PatientID = table.Columns.Add("PatientID", typeof(string));
               table.Columns.Add("PatientName", typeof(string));
               table.Columns.Add("PatientBirthDate", typeof(DateTime));
               table.Columns.Add("PatientBirthTime", typeof(DateTime));
               table.Columns.Add("PatientSex", typeof(string));
               table.Columns.Add("EthnicGroup", typeof(string));
               table.Columns.Add("PatientComments", typeof(string));

               key[0] = Patients_PatientID;
               table.PrimaryKey = key;

               table = ds.Tables.Add("Studies");
               Studies_InstUID = table.Columns.Add("StudyInstanceUID", typeof(string));
               table.Columns.Add("StudyDate", typeof(DateTime));
               table.Columns.Add("StudyTime", typeof(DateTime));
               table.Columns.Add("AccessionNumber", typeof(string));
               table.Columns.Add("StudyID", typeof(string));
               table.Columns.Add("PatientName", typeof(string));
               Studies_PatientID = table.Columns.Add("PatientID", typeof(string));
               table.Columns.Add("StudyDescription", typeof(string));
               table.Columns.Add("ReferringDrName", typeof(string));

               key[0] = Studies_InstUID;
               table.PrimaryKey = key;
               ds.Relations.Add("Studies", Patients_PatientID, Studies_PatientID);

               table = ds.Tables.Add("Series");
               Series_ID = table.Columns.Add("SeriesInstanceUID", typeof(string));
               Series_InstUID = table.Columns.Add("StudyInstanceUID", typeof(string));
               table.Columns.Add("Modality", typeof(string));
               table.Columns.Add("SeriesNumber", typeof(int));
               table.Columns.Add("PatientID", typeof(string));
               table.Columns.Add("SeriesDate", typeof(DateTime));

               key[0] = Series_ID;
               table.PrimaryKey = key;
               ds.Relations.Add("Series", Studies_InstUID, Series_InstUID);

               table = ds.Tables.Add("Images");
               table.Columns.Add("SOPInstanceUID", typeof(string));
               Images_ID = table.Columns.Add("SeriesInstanceUID", typeof(string));
               table.Columns.Add("StudyInstanceUID", typeof(string));
               table.Columns.Add("InstanceNumber", typeof(int));
               table.Columns.Add("ReferencedFile", typeof(string));
               table.Columns.Add("PatientID", typeof(string));
               table.Columns.Add("SOPClassUID", typeof(string));
               table.Columns.Add("TransferSyntaxUID", typeof(string));

               ds.Relations.Add("Images", Series_ID, Images_ID);

               Save();
            }
            catch
            {
               created = false;
            }
         }

         return created;
      }

      /// <summary>
      /// Insert a dicom file into the database.
      /// </summary>
      /// <param name="filename"></param>
      /// <returns></returns>
      public InsertReturn Insert(string filename)
      {
         DicomDataSet dcm;
         string patientID, studyInstanceUID;
         string seriesInstanceUID, sopInstanceUID;
         InsertReturn iret = InsertReturn.Success;

         dcm = new DicomDataSet();
         if (dcm == null)
         {
            return InsertReturn.Error;
         }

         try
         {
            FileInfo src = new FileInfo(filename);
            DirectoryInfo dstDir = new DirectoryInfo(ImageDir);

            if (src.Directory.FullName != dstDir.FullName)
            {
               filename = dstDir.FullName + src.Name;
               src.CopyTo(filename);
            }
            dcm.Load(filename, DicomDataSetLoadFlags.LoadAndClose);
         }
         catch
         {
            return InsertReturn.Error;
         }

         patientID = AddPatient(dcm, ref iret);
         if (iret != InsertReturn.Success && iret != InsertReturn.Exists)
         {
            return iret;
         }

         studyInstanceUID = AddStudy(dcm, patientID, ref iret);
         if (iret != InsertReturn.Success && iret != InsertReturn.Exists)
         {
            return iret;
         }
         seriesInstanceUID = AddSeries(dcm, studyInstanceUID, patientID, ref iret);
         if (iret != InsertReturn.Success && iret != InsertReturn.Exists)
         {
            return iret;
         }

         sopInstanceUID = AddImage(dcm, seriesInstanceUID, studyInstanceUID, patientID, filename, ref iret);

         if (iret == InsertReturn.Success)
         {
            Save();
         }
         return iret;
      }

      public InsertReturn Insert(DicomDataSet dcm, string filename)
      {
         string patientID;
         string studyInstanceUID;
         string seriesInstanceUID;
         string sopInstanceUID;
         InsertReturn ret = InsertReturn.Success;

         patientID = AddPatient(dcm, ref ret);
         if (ret != InsertReturn.Success && ret != InsertReturn.Exists)
         {
            return ret;
         }

         studyInstanceUID = AddStudy(dcm, patientID, ref ret);
         seriesInstanceUID = AddSeries(dcm, studyInstanceUID, patientID, ref ret);
         sopInstanceUID = AddImage(dcm, seriesInstanceUID, studyInstanceUID, patientID, filename, ref ret);

         if (ret == InsertReturn.Success)
         {
            Save();
         }
         return ret;
      }

      private string AddPatient(DicomDataSet dcm, ref InsertReturn ret)
      {
         string patientID;

         ret = InsertReturn.Success;
         patientID = Utils.GetStringValue(dcm, DemoDicomTags.PatientID);
         if (patientID.Length == 0)
         {
            ret = InsertReturn.Error;
            return "";
         }

         lock (adoDatasetLock)
         {
            if (!RecordExists(ds.Tables["Patients"], "PatientID = '" + patientID + "'"))
            {
               DataRow dr;

               dr = ds.Tables["Patients"].NewRow();
               if (dr != null)
               {
                  dr["PatientID"] = patientID;
                  dr["PatientName"] = Utils.GetStringValue(dcm, DemoDicomTags.PatientName);
                  dr["PatientSex"] = Utils.GetStringValue(dcm, DemoDicomTags.PatientSex);
                  dr["EthnicGroup"] = Utils.GetStringValue(dcm, DemoDicomTags.EthnicGroup);
                  dr["PatientComments"] = Utils.GetStringValue(dcm, DemoDicomTags.PatientComments);

                  try
                  {
                     dr["PatientBirthDate"] = DateTime.Parse(Utils.GetStringValue(dcm, DemoDicomTags.PatientBirthDate));
                     dr["PatientBirthTime"] = DateTime.Parse(Utils.GetStringValue(dcm, DemoDicomTags.PatientBirthTime));
                  }
                  catch
                  {
                  }

                  ds.Tables["Patients"].Rows.Add(dr);
               }
            }
            else
            {
               ret = InsertReturn.Exists;
            }
         }

         return patientID;
      }

      private string AddStudy(DicomDataSet dcm, string patientID, ref InsertReturn ret)
      {
         string studyInstanceUID;
         string filter;

         ret = InsertReturn.Success;
         studyInstanceUID = Utils.GetStringValue(dcm, DemoDicomTags.StudyInstanceUID);
         if (studyInstanceUID.Length == 0)
         {
            ret = InsertReturn.Error;
            return "";
         }

         lock (adoDatasetLock)
         {
            filter = "StudyInstanceUID = '" + studyInstanceUID + "' AND PatientID = '" + patientID + "'";
            if (!RecordExists(ds.Tables["Studies"], filter))
            {
               DataRow dr;

               dr = ds.Tables["Studies"].NewRow();
               if (dr != null)
               {
                  dr["StudyInstanceUID"] = studyInstanceUID;
                  dr["StudyID"] = Utils.GetStringValue(dcm, DemoDicomTags.StudyID);
                  dr["StudyDescription"] = Utils.GetStringValue(dcm, DemoDicomTags.StudyDescription);
                  dr["AccessionNumber"] = Utils.GetStringValue(dcm, DemoDicomTags.AccessionNumber);
                  dr["PatientID"] = patientID;
                  dr["PatientName"] = Utils.GetStringValue(dcm, DemoDicomTags.PatientName);
                  dr["ReferringDrName"] = Utils.GetStringValue(dcm, DemoDicomTags.ReferringPhysicianName);

                  try
                  {
                     dr["StudyDate"] = DateTime.Parse(Utils.GetStringValue(dcm, DemoDicomTags.StudyDate));
                     dr["StudyTime"] = DateTime.Parse(Utils.GetStringValue(dcm, DemoDicomTags.StudyTime));
                  }
                  catch
                  {
                  }

                  ds.Tables["Studies"].Rows.Add(dr);
               }
            }
            else
            {
               ret = InsertReturn.Exists;
            }
         }

         return studyInstanceUID;
      }

      private string AddSeries(DicomDataSet dcm, string studyInstanceUID, string patientID, ref InsertReturn ret)
      {
         string seriesInstanceUID;
         string filter;

         ret = InsertReturn.Success;
         seriesInstanceUID = Utils.GetStringValue(dcm, DemoDicomTags.SeriesInstanceUID);
         if (seriesInstanceUID.Length == 0)
         {
            ret = InsertReturn.Error;
            return "";
         }

         filter = "StudyInstanceUID = '" + studyInstanceUID + "' AND SeriesInstanceUID = '" + seriesInstanceUID + "'";
         lock (adoDatasetLock)
         {
            if (!RecordExists(ds.Tables["Series"], filter))
            {
               DataRow dr;

               dr = ds.Tables["Series"].NewRow();
               if (dr != null)
               {
                  string temp;

                  temp = Utils.GetStringValue(dcm, DemoDicomTags.SeriesNumber);

                  dr["SeriesInstanceUID"] = seriesInstanceUID;
                  dr["StudyInstanceUID"] = studyInstanceUID;
                  dr["Modality"] = Utils.GetStringValue(dcm, DemoDicomTags.Modality);
                  dr["PatientID"] = patientID;

                  try
                  {
                     dr["SeriesDate"] = DateTime.Parse(Utils.GetStringValue(dcm, DemoDicomTags.SeriesDate));
                  }
                  catch
                  {
                  }

                  try
                  {
                     if (temp.Length > 0)
                     {
                        dr["SeriesNumber"] = Convert.ToInt32(temp);
                     }
                  }
                  catch
                  {
                  }

                  ds.Tables["Series"].Rows.Add(dr);
               }
            }
            else
            {
               ret = InsertReturn.Exists;
            }
         }

         return seriesInstanceUID;
      }

      private string AddImage(DicomDataSet dcm, string seriesInstanceUID, string studyInstanceUID,
                             string patientID, string filename, ref InsertReturn ret)
      {
         string sopInstanceUID;
         string filter;

         ret = InsertReturn.Success;
         sopInstanceUID = Utils.GetStringValue(dcm, DemoDicomTags.SOPInstanceUID);
         if (sopInstanceUID.Length == 0)
         {
            ret = InsertReturn.Error;
            return "";
         }

         filter = "StudyInstanceUID = '" + studyInstanceUID + "' AND SeriesInstanceUID = '" + seriesInstanceUID + "'";
         filter += " AND SOPInstanceUID = '" + sopInstanceUID + "'";
         lock (adoDatasetLock)
         {
            if (!RecordExists(ds.Tables["Images"], filter))
            {
               DataRow dr;

               dr = ds.Tables["Images"].NewRow();
               if (dr != null)
               {
                  string temp;

                  dr["SOPInstanceUID"] = sopInstanceUID;
                  dr["SeriesInstanceUID"] = seriesInstanceUID;
                  dr["StudyInstanceUID"] = studyInstanceUID;
                  dr["PatientID"] = patientID;
                  dr["ReferencedFile"] = filename;

                  temp = Utils.GetStringValue(dcm, DemoDicomTags.SOPClassUID);
                  if (temp.Length == 0)
                  {
                     temp = Utils.GetStringValue(dcm, DemoDicomTags.MediaStorageSOPClassUID);
                     if (temp.Length == 0)
                     {
                        temp = "1.1.1.1";
                     }
                  }
                  dr["SOPClassUID"] = temp;

                  temp = Utils.GetStringValue(dcm, DemoDicomTags.TransferSyntaxUID);
                  if (temp.Length == 0)
                  {
                     temp = DicomUidType.ImplicitVRLittleEndian;
                  }
                  dr["TransferSyntaxUID"] = temp;

                  temp = Utils.GetStringValue(dcm, DemoDicomTags.InstanceNumber);
                  if (temp.Length > 0)
                  {
                     dr["InstanceNumber"] = Convert.ToInt32(temp);
                  }

                  ds.Tables["Images"].Rows.Add(dr);
               }
            }
            else
            {
               ret = InsertReturn.Exists;
            }
         }

         return sopInstanceUID;
      }

      private bool RecordExists(DataTable table, string filter)
      {
         DataView dv = new DataView(table);

         if (dv != null)
         {
            dv.RowFilter = filter;
            return dv.Count > 0;
         }
         return false;
      }

      public DataView FindRecords(string type, string filter)
      {

         DataView dv;
         lock (adoDatasetLock)
         {
            dv = new DataView(ds.Tables[type]);

            if (dv != null)
            {
               dv.RowFilter = filter;
            }
         }
         return dv;
      }

      public void Delete(string table, string field, string key)
      {
         lock (adoDatasetLock)
         {
            DataView dv = new DataView(ds.Tables[table]);

            if (dv != null)
            {
               DataRow dr;

               dv.RowFilter = field + " = '" + key + "'";
               dr = dv[0].Row;
               if (dr != null)
               {
                  ds.Tables[table].Rows.Remove(dr);
               }
            }
         }
      }
   }
}
