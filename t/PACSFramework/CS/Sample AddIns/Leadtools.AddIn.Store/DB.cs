// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom;
using System.Data.SqlServerCe;
using System.IO;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Interfaces;

namespace Leadtools.AddIn.Store
{
    public static class DB    
    {
       public static bool _newPatient = false;
       public static bool _newStudy = false;
       public static bool _newSeries = false;
       public static bool _newImage = false;

        private static GetValueDelegate GetDate = delegate(string data)
                                                    {
                                                        try
                                                        {
                                                            return DateTime.Parse(data);
                                                        }
                                                        catch
                                                        {
                                                            return null;
                                                        }
                                                    };

        private const string PatientInsert = "INSERT INTO Patients(PatientId,Name,BirthDate,Sex,EthnicGroup,Comments,AETitle) " +
                                             "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";

        private const string sQueryGetAllImages =
           "SELECT p.PatientId, p.Name, s.StudyId, r.SeriesNumber, r.Modality, i.ImageNumber, i.ReferencedFile, i.TransferSyntax, i.SOPClassUid, i.SOPInstanceUid " +
           "FROM Patients p, Studies s, Series r, Images i " +
           "WHERE (p.PatientId = s.PatientId) AND (s.StudyInstanceUid = r.StudyInstanceUid) AND (r.SeriesInstanceUid = i.SeriesInstanceUid)";

        private const string sQueryGetOneImage =
            "SELECT p.PatientId, s.StudyInstanceUid, r.SeriesInstanceUid, i.SOPInstanceUid, i.ReferencedFile " +
            "FROM Patients p, Studies s, Series r, Images i " +
            "WHERE (p.PatientId = s.PatientId) AND (s.StudyInstanceUid = r.StudyInstanceUid) AND (r.SeriesInstanceUid = i.SeriesInstanceUid) {0}";


        static ListViewItem AddItem(SqlCeDataReader reader, string colName, ListView listView, ListViewItem item)
        {
           string s = reader[colName].ToString();
           if (item != null)
              item.SubItems.Add(s);
           else
              item = listView.Items.Add(s);

           return item;
           //if (reader["ImageNumber"] != null && reader["ImageNumber"].ToString().Length>0)
           //    response.InsertElementAndSetValue(DicomTag.InstanceNumber, reader["ImageNumber"]);                
        }
    
        public static int ListAllImages(string ConnectionString, ListView listView )
        {
           int count = 0;
           ListViewItem item = null;
           listView.Items.Clear();
           SqlCeDataReader reader = SqlCeHelper.ExecuteReader(ConnectionString, sQueryGetAllImages);
           while (reader.Read())
           {
              item = AddItem(reader, "PatientId", listView, null);
              if (item != null)
              {
                 item.Tag = reader["SOPInstanceUid"];             // set the item data to be SOPInstanceUid
                 AddItem(reader, "Name", listView, item);
                 AddItem(reader, "StudyId", listView, item);
                 AddItem(reader, "SeriesNumber", listView, item);
                 AddItem(reader, "Modality",       listView, item);
                 AddItem(reader, "ImageNumber",    listView, item);
                 AddItem(reader, "TransferSyntax", listView, item);
                 AddItem(reader, "SOPClassUid",    listView, item);
                 AddItem(reader, "ReferencedFile", listView, item);
                 count++;
              }
           }
           reader.Close();
           return count;
        }

        private const string sQueryCount =
           "SELECT COUNT(*) AS count " +
           "FROM {0} " +
           "WHERE {1} = '{2}'";

        public static int GetCount(string ConnectionString, string sTable, string sUniqueId, string sValue)
        {
           string sCount = "0";
           string sQuery = string.Format(sQueryCount, sTable, sUniqueId, sValue);
           SqlCeDataReader reader = SqlCeHelper.ExecuteReader(ConnectionString, sQuery);
           if (reader.Read())
           {
              sCount           = reader["count"].ToString();
           }
           reader.Close();
           int nCount = Convert.ToInt32(sCount);
           return nCount;
        }

        private const string sQueryDeleteTableItem =
            "DELETE " +
            "FROM {0} " +
            "WHERE {1} = '{2}'";

        private const string sQueryDeleteAllTableItems =
           "DELETE " +
           "FROM {0} ";

        private const string sQueryReferencedFiles =
           "SELECT ReferencedFile " +
           "FROM Images ";

       public static void DeleteTableItem(string ConnectionString, string sTable, string sUniqueId, string sValue)
        {
           string sQuery = string.Format(sQueryDeleteTableItem, sTable, sUniqueId, sValue);
           SqlCeHelper.ExecuteNonQuery(ConnectionString, sQuery);
        }

       public static void DeleteAllReferencedFiles(string ConnectionString)
       {
          SqlCeDataReader reader = SqlCeHelper.ExecuteReader(ConnectionString, sQueryReferencedFiles);
          while (reader.Read())
          {
             string sReferencedFile = reader["ReferencedFile"].ToString();
             if ((sReferencedFile.Length > 0) && (File.Exists(sReferencedFile)))
             {
                try
                {
                   File.Delete(sReferencedFile);
                }
                catch (Exception )
                {
                }
             }
          }
          reader.Close();
       }
       public static void DeleteAllTableItems(string ConnectionString, string sTable)
       {
          string sQuery = string.Format(sQueryDeleteAllTableItems, sTable);
          SqlCeHelper.ExecuteNonQuery(ConnectionString, sQuery);
       }

       // If the child table no items with (sUniqueId == sValue), than we can delete the (sUniqueId == sValue) item from parent table
       // Returns true if a delete took place
       public static bool DeleteTableItemIfNecessary(string ConnectionString, string sTableParent ,string sTableChild, string sUniqueId, string sValue)
       {
          bool bDelete = false;
          int count = GetCount(ConnectionString, sTableChild, sUniqueId, sValue);
          if (count == 0)
          {
             DeleteTableItem(ConnectionString, sTableParent, sUniqueId, sValue);
             bDelete = true;
          }
          return bDelete;
       }

       public static void DeleteDicomRecord(string ConnectionString, string sSOPInstanceUid)
       {
          string sReferencedFile = string.Empty;
          string sPatientId = string.Empty;
          string sStudyInstanceUid = string.Empty;
          string sSeriesInstanceUid = string.Empty;
          string sQuery = string.Format(sQueryGetOneImage, "AND (SOPInstanceUid = '" + sSOPInstanceUid + "')");
          SqlCeDataReader reader = SqlCeHelper.ExecuteReader(ConnectionString, sQuery);

           if (reader.Read())
           {
              sReferencedFile      = reader["ReferencedFile"].ToString() ;
              sPatientId           = reader["PatientId"].ToString();
              sStudyInstanceUid    = reader["StudyInstanceUid"].ToString();
              sSeriesInstanceUid   = reader["SeriesInstanceUid"].ToString();
           }
           reader.Close();

           // Delete file from folder
           if ((sReferencedFile.Length > 0) && (File.Exists(sReferencedFile)))
           {
              try
              {
                 File.Delete(sReferencedFile);
              }
              catch (Exception)
              {
              }
           }

           // Delete from the Image table
           bool bDelete = true;
           DeleteTableItem(ConnectionString, "Images", "SOPInstanceUid", sSOPInstanceUid);

           bDelete = DeleteTableItemIfNecessary(ConnectionString,"Series",  "Images", "SeriesInstanceUid", sSeriesInstanceUid);
           if (bDelete)
              bDelete = DeleteTableItemIfNecessary(ConnectionString, "Studies", "Series", "StudyInstanceUid", sStudyInstanceUid);

           if (bDelete)
              DeleteTableItemIfNecessary(ConnectionString, "Patients", "Studies", "PatientId", sPatientId);
       }

       public static void DeleteAllDicomRecords(string ConnectionString)
       {
          DeleteAllReferencedFiles(ConnectionString);
          DeleteAllTableItems(ConnectionString, "Patients");
          DeleteAllTableItems(ConnectionString, "Studies");
          DeleteAllTableItems(ConnectionString, "Series");
          DeleteAllTableItems(ConnectionString, "Images");
       }
        
        
        public static DicomCommandStatusType Insert(DateTime receive,ServerInfo info, string AETitle,DicomDataSet dataset)
        {
            string sop = dataset.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
            DicomCommandStatusType status = DicomCommandStatusType.Success;

            if (!string.IsNullOrEmpty(sop))
            {
               //string filename = info.ImageDirectory + sop + ".dcm";
               string pid = string.Empty;
               string studyInstance = string.Empty;
               string seriesInstance = string.Empty;
               string sopInstance = string.Empty;

               pid = AddPatient(info.ConnectionString, AETitle, dataset);
               studyInstance = AddStudy(receive, pid, info.ConnectionString, AETitle, dataset);
               seriesInstance = AddSeries(receive, studyInstance, info.ConnectionString, AETitle, dataset);
               status = AddImage(receive, sop, studyInstance, seriesInstance, info.ConnectionString, AETitle, dataset, info.ImageDirectory + pid + @"\");
               if (status == DicomCommandStatusType.Failure)
               {
                  // remove patient, study, series, image information added to database
                  if (_newImage)
                     DeleteImage(sop, info.ConnectionString);

                  if (_newSeries)
                     DeleteSeries(seriesInstance, info.ConnectionString);

                  if (_newStudy)
                     DeleteStudy(studyInstance, info.ConnectionString);

                  if (_newPatient)
                     DeletePatient(pid, info.ConnectionString);
               }
            }
            else
               throw new ArgumentException("Missing dicom tag", "SOP Instance UID");

            return status;
        }

        /// <summary>
        /// Adds the patient.
        /// </summary>
        /// <param name="ConnectionString">The connection string.</param>
        /// <param name="AETitle">The AE title.</param>
        /// <param name="dataset">The dataset.</param>
        /// <returns></returns>
        private static string AddPatient(string ConnectionString, string AETitle, DicomDataSet dataset)
        {
            string pid = dataset.GetValue<string>(DicomTag.PatientID, string.Empty);

            if (string.IsNullOrEmpty(pid))
                throw new ArgumentException("Missing dicom tag", "Patient ID");

             _newPatient = false;
             if (!RecordExists(ConnectionString, "Patients", "PatientID = '" + pid + "'"))
             {
                DateTime? bd = dataset.GetValue<DateTime?>(DicomTag.PatientBirthDate, null, GetDate);
                DateTime? bt = dataset.GetValue<DateTime?>(DicomTag.PatientBirthTime, null, GetDate);
                string sql = string.Format(PatientInsert, pid,
                                           dataset.GetValue<string>(DicomTag.PatientName, string.Empty),
                                           GetDateString(bd, bt),
                                           dataset.GetValue<string>(DicomTag.PatientSex, string.Empty),
                                           dataset.GetValue<string>(DicomTag.EthnicGroup, string.Empty),
                                           dataset.GetValue<string>(DicomTag.PatientComments, string.Empty),
                                           AETitle);

                SqlCeHelper.ExecuteNonQuery(ConnectionString, sql);
                _newPatient = true;
             }

            return pid;
        }

        /// <summary>
        /// Adds the study.
        /// </summary>
        /// <param name="receive">The receive.</param>
        /// <param name="PatientId">The patient id.</param>
        /// <param name="ConnectionString">The connection string.</param>
        /// <param name="AETitle">The AE title.</param>
        /// <param name="dataset">The dataset.</param>
        /// <returns></returns>
        private static string AddStudy(DateTime receive, string PatientId, string ConnectionString, string AETitle, DicomDataSet dataset)
        {
            string studyInstance = dataset.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty);

            if (string.IsNullOrEmpty(studyInstance))
                throw new ArgumentException("Missing dicom tag", "Study Instance UID");

            _newStudy = false;          
            if (!RecordExists(ConnectionString, "Studies", "StudyInstanceUID = '" + studyInstance + "'"))
            {
                DateTime? sd = dataset.GetValue<DateTime?>(DicomTag.StudyDate, null, GetDate);
                DateTime? st = dataset.GetValue<DateTime?>(DicomTag.StudyTime, null, GetDate);                
                SqlCeResultSet rs = SqlCeHelper.ExecuteResultSet(ConnectionString, "Studies");
                SqlCeUpdatableRecord study = rs.CreateRecord();

                study.SetValue(0, studyInstance);
                string sDate = GetDateString(sd, st).Trim();
                if (sDate.Length > 0)
                   study.SetValue(1, sDate);
                study.SetValue(2, dataset.GetValue<string>(DicomTag.AccessionNumber,string.Empty));
                study.SetValue(3, dataset.GetValue<string>(DicomTag.StudyID, string.Empty));
                study.SetValue(4, dataset.GetValue<string>(DicomTag.ReferringPhysicianName, string.Empty));
                study.SetValue(5, dataset.GetValue<string>(DicomTag.StudyDescription, string.Empty));
                study.SetValue(6, dataset.GetValue<string>(DicomTag.AdmittingDiagnosesDescription, string.Empty));

                string age = dataset.GetValue<string>(DicomTag.PatientAge, string.Empty);

                if (age != string.Empty && age.Length > 0)
                    age = age.Substring(0, 4);

                study.SetValue(7, age);
                study.SetValue(8, dataset.GetValue<double>(DicomTag.PatientSize, 0));
                study.SetValue(9, dataset.GetValue<double>(DicomTag.PatientWeight, 0));
                study.SetValue(10, dataset.GetValue<string>(DicomTag.Occupation, string.Empty));
                study.SetValue(11, dataset.GetValue<string>(DicomTag.AdditionalPatientHistory, string.Empty));
                study.SetValue(12, dataset.GetValue<string>(DicomTag.InterpretationAuthor, string.Empty));
                study.SetValue(13, PatientId);

                sDate = GetDateString(receive, receive).Trim();
                if (sDate.Length > 0)
                   study.SetValue(14, sDate);
                study.SetValue(15, AETitle);

                rs.Insert(study);
                rs.Close();
                _newStudy = true;
            }

            return studyInstance;
        }

        /// <summary>
        /// Adds the series.
        /// </summary>
        /// <param name="receive">The receive.</param>
        /// <param name="StudyInstanceUid">The study instance uid.</param>
        /// <param name="ConnectionString">The connection string.</param>
        /// <param name="AETitle">The AE title.</param>
        /// <param name="dataset">The dataset.</param>
        /// <returns></returns>
        private static string AddSeries(DateTime receive, string StudyInstanceUid, string ConnectionString, string AETitle, DicomDataSet dataset)
        {
            string seriesInstance = dataset.GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);

            if (string.IsNullOrEmpty(seriesInstance))
                throw new ArgumentException("Missing dicom tag", "Series Instance UID");

            _newSeries = false;          
            if (!RecordExists(ConnectionString, "Series", "SeriesInstanceUID = '" + seriesInstance + "'"))
            {
                DateTime? sd = dataset.GetValue<DateTime?>(DicomTag.SeriesDate, null, GetDate);
                DateTime? st = dataset.GetValue<DateTime?>(DicomTag.SeriesTime, null, GetDate);
                SqlCeResultSet rs = SqlCeHelper.ExecuteResultSet(ConnectionString, "Series");
                SqlCeUpdatableRecord series = rs.CreateRecord();

                series.SetValue(0, seriesInstance);
                series.SetValue(1, dataset.GetValue<string>(DicomTag.Modality, string.Empty));
                series.SetValue(2, dataset.GetValue<string>(DicomTag.SeriesNumber, string.Empty));

                string seriesDate = GetDateString(sd, st);

                if (seriesDate.Length > 0)
                    series.SetValue(3, seriesDate);

                series.SetValue(4, dataset.GetValue<string>(DicomTag.SeriesDescription, string.Empty));
                series.SetValue(5, dataset.GetValue<string>(DicomTag.InstitutionName, string.Empty));

                seriesDate = GetDateString(receive, receive);
                if (seriesDate.Length > 0)
                   series.SetValue(6, seriesDate);
                series.SetValue(7, AETitle);
                series.SetValue(8, StudyInstanceUid);

                rs.Insert(series);
                rs.Close();
                _newSeries = true;          
            }

            return seriesInstance;
         }

         private static void DeletePatient(string patientId, string ConnectionString)
         {
            if (patientId.Length > 0)
            {
               string query = "DELETE FROM Patients WHERE PatientID = '" + patientId + "';";
               try
               {
                  SqlCeHelper.ExecuteNonQuery(ConnectionString, query);
               }
               catch (Exception)
               {
               }
            }
         }

         private static void DeleteStudy(string studyInstanceUid, string ConnectionString)
         {
            if (studyInstanceUid.Length > 0)
            {
               string query = "DELETE FROM Studies WHERE StudyInstanceUID = '" + studyInstanceUid + "';";
               try
               {
                  SqlCeHelper.ExecuteNonQuery(ConnectionString, query);
               }
               catch (Exception)
               {
               }
            }
         }

         private static void DeleteSeries(string seriesInstanceUid, string ConnectionString)
         {
            if (seriesInstanceUid.Length > 0)
            {
               string query = "DELETE FROM Series WHERE SeriesInstanceUID = '" + seriesInstanceUid + "';";
               try
               {
                  SqlCeHelper.ExecuteNonQuery(ConnectionString, query);
               }
               catch (Exception)
               {
               }
            }
         }


         private static void DeleteImage(string sopInstanceUid, string ConnectionString)
         {
            if (sopInstanceUid.Length > 0)
            {
               string query = "DELETE FROM Images WHERE SOPInstanceUID = '" + sopInstanceUid + "';";
               try
               {
                  SqlCeHelper.ExecuteNonQuery(ConnectionString, query);
               }
               catch (Exception)
               {
               }
            }
         }

       private static DicomCommandStatusType AddImage(DateTime receive, string sopInstance, string StudyInstanceUid, string SeriesInstanceUid,
                                      string ConnectionString, string AETitle, DicomDataSet dataset, string ImageDirectory)
       {
          if (string.IsNullOrEmpty(sopInstance))
             throw new ArgumentException("Missing dicom tag", "SOP Instance UID");

          _newImage = false;
          if (!RecordExists(ConnectionString, "Images", "SOPInstanceUID = '" + sopInstance + "'"))
          {
             string fileName = ImageDirectory + sopInstance + ".dcm";
             SqlCeResultSet rs = SqlCeHelper.ExecuteResultSet(ConnectionString, "Images");
             SqlCeUpdatableRecord image = rs.CreateRecord();

             image.SetValue(0, sopInstance);
             image.SetValue(1, SeriesInstanceUid);
             image.SetValue(2, StudyInstanceUid);
             if (HasValue(dataset, DicomTag.InstanceNumber))
                image.SetValue(3, dataset.GetValue<int>(DicomTag.InstanceNumber, 0));
             image.SetValue(4, fileName);
             image.SetValue(5, dataset.GetValue<string>(DicomTag.TransferSyntaxUID, DicomUidType.ImplicitVRLittleEndian));
             image.SetValue(6, dataset.GetValue<string>(DicomTag.SOPClassUID, string.Empty));
             image.SetValue(7, dataset.GetValue<string>(DicomTag.StationName, string.Empty));
             image.SetValue(8, GetDateString(DateTime.Now, DateTime.Now));
             image.SetValue(9, AETitle);

             rs.Insert(image);
             rs.Close();
             _newImage = true;

             //
             // store the file
             //
             if (!Directory.Exists(ImageDirectory))
             {
                Directory.CreateDirectory(ImageDirectory);
             }

             bool saved = true;
             try
             {
                dataset.Save(fileName, DicomDataSetSaveFlags.MetaHeaderPresent);
             }
             catch (Exception)
             {
                saved = false;
             }

             if (!saved)
             {
                return DicomCommandStatusType.Failure;
             }
          }
          else
             return DicomCommandStatusType.DuplicateInstance;

          return DicomCommandStatusType.Success;
       }



        /// <summary>
        /// Check to see if the record already exists.
        /// </summary>
        /// <param name="ConnectionString">The connection string.</param>
        /// <param name="table">The table.</param>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        public static bool RecordExists(string ConnectionString,string table,string where)
        {
            string sql = "SELECT Count(*) FROM " + table + " WHERE " + where;
            object o = SqlCeHelper.ExecuteScalar(ConnectionString, sql);

            return o != null && Convert.ToInt32(o) != 0;
        }

        private static bool HasValue(DicomDataSet ds, long tag)
        {
            DicomElement e = ds.FindFirstElement(null, tag, false);

            return e != null && e.Length > 0;
        }

        /// <summary>
        /// Gets the SQL CE formatted date string.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        public static string GetDateString(DateTime? date,DateTime? time)
        {
            string combined = string.Empty;

            if(date!=null)
                combined = date.Value.ToString("yyyy-M-d") + " ";

            if (time != null)
                combined += time.Value.ToString("HH:mm:ss");

            combined = combined.Trim();

            return combined;
        }       
    }
}
