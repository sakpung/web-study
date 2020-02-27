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
using Leadtools.Dicom.AddIn.Interfaces;

namespace Leadtools.AddIn.Store
{
    public static class DB    
    {               
        public static DicomCommandStatusType FindPatient(FindAddIn addin,string connection, DicomDataSet ds, DicomDataSet response)
        {
            string filter = string.Empty;
            string patientID = ds.GetValue<string>(DicomTag.PatientID, string.Empty);
            string patientName = ds.GetValue<string>(DicomTag.PatientName, string.Empty);
            SqlCeDataReader reader = null;

            if (patientID.Length > 0)
                filter = CheckForWildcards("PatientID LIKE '" + patientID + "'");

            if (patientName.Length > 0)
            {
                if (filter.Length > 0)
                    filter += " AND ";
                filter += CheckForWildcards("Name LIKE '" + patientName + "'");
            }

            if (string.IsNullOrEmpty(filter))
                filter = "SELECT * FROM Patients";
            else
                filter = "SELECT * FROM Patients WHERE " + filter;

            reader = SqlCeHelper.ExecuteReader(connection, filter);
            while (reader.Read())
            {
                response.InsertElementAndSetValue(DicomTag.PatientID, reader["PatientID"]);
                if (reader["Name"] != null)
                    response.InsertElementAndSetValue(DicomTag.PatientName, reader["Name"]);
                if (reader["BirthDate"] != null)
                    response.InsertElementAndSetValue(DicomTag.PatientBirthDate, reader["BirthDate"]);
                if (reader["Sex"] != null)
                    response.InsertElementAndSetValue(DicomTag.PatientSex, reader["Sex"]);
                if (reader["EthnicGroup"] != null)
                    response.InsertElementAndSetValue(DicomTag.EthnicGroup, reader["EthnicGroup"]);
                if (reader["Comments"] != null)
                    response.InsertElementAndSetValue(DicomTag.PatientComments, reader["Comments"]);
                if (addin.OnMatchFound(response))
                {
                    reader.Close();
                    return DicomCommandStatusType.Cancel;
                }
                else if(addin.Cancel)
                {
                    if (addin.BreakType == BreakType.Cancel)
                        return DicomCommandStatusType.Cancel;
                    else
                        return DicomCommandStatusType.Failure;
                }

                //response.Clear();
            }
            return DicomCommandStatusType.Success;
        }

        public static string FindElementModalitiesInStudy(DicomDataSet ds)
        {
           if (ds == null)
              return string.Empty;

           string sRet = string.Empty;

           string sQueryModality =
             "  (Studies.StudyInstanceUID in " +
                "(SELECT StudyInstanceUID " +
                " FROM Series " +
                " WHERE {0}))";

           DicomElement element = ds.FindFirstElement(null, DicomTag.ModalitiesInStudy, false);
           if (element != null)
           {
              // Get a list of strings value of an element by specifying a tag
              string sEndQuery = string.Empty;
              List<string> modalitiesInStudy = ds.GetValue<List<string>>(DicomTag.ModalitiesInStudy, null);
              int count = 0;
              if (modalitiesInStudy != null)
              {
                 foreach (string s in modalitiesInStudy)
                 {
                    if (count > 0)
                       sEndQuery = sEndQuery + " OR ";
                    sEndQuery = sEndQuery + string.Format("(Series.Modality = '{0}')", s);
                    count++;
                 }

                 sRet = string.Format(sQueryModality, sEndQuery);
              }

           }
           return sRet;
        }


        public static string CheckForWildcards(string pcsVal)
        {
           string ret = pcsVal;
           ret = ret.Replace("*", "%");
           ret = ret.Replace("?", "_");

           if (string.Compare(pcsVal, ret) != 0)
           {
              ret = ret.Replace("=", "LIKE");
           }
           return ret;
        }


        /// <summary>
        /// Finds the study.
        /// </summary>
        /// <param name="addin">The addin.</param>
        /// <param name="connection">The connection.</param>
        /// <param name="ds">The ds.</param>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static DicomCommandStatusType FindStudy(FindAddIn addin, string connection, DicomDataSet ds, DicomDataSet response)
        {
            string filter = string.Empty;
            string temp;
            SqlCeDataReader reader;

            temp = ds.GetValue<string>(DicomTag.PatientID, string.Empty);
            if (temp.Length > 0)
                filter = CheckForWildcards("Studies.PatientId = '" + temp + "'");

            temp = ds.GetValue<string>(DicomTag.PatientName, string.Empty);
            if (temp.Length > 0)
            {
                if (filter.Length > 0)
                    filter += " AND ";
                filter += CheckForWildcards("Name LIKE '" + temp + "'");
            }

            List<string> instances = ds.GetValue<List<string>>(DicomTag.StudyInstanceUID, new List<string>());

            foreach (string instance in instances)
            {
                if (filter.Length > 0)
                    filter += " AND ";

                filter += CheckForWildcards("StudyInstanceUid = '" + instance + "'");
            }

            DicomDateRangeValue[] d = ExtensionMethods.GetDateRange(ds, DicomTag.StudyDate);
            DicomTimeRangeValue[] t = ExtensionMethods.GetTimeRange(ds, DicomTag.StudyTime);
            int dCount = (d == null ? 0 : d.Length);
            int tCount = (t == null ? 0 : t.Length);
            int maxEntries = Math.Max(dCount, tCount);

            for (int i = 0; i < maxEntries; i++)
            {
               DateTime startDate = new DateTime(1900, 1, 1,0,0,0);
               DateTime endDate = new DateTime(3000, 12, 31, 23, 59, 59);
               DateTime startTime = DateTime.MinValue;
               DateTime endTime = DateTime.MaxValue;
               string sStartDateTime = string.Empty;
               string sEndDateTime = string.Empty;

               // Get the start date and end date
               if (i < dCount)
               {
                  // start date
                  if ((d[i].Type == DicomRangeType.Lower) || (d[i].Type == DicomRangeType.Both))
                     startDate = new DateTime(d[i].Date1.Year, d[i].Date1.Month, d[i].Date1.Day,0,0,0);

                  // end date
                  if (d[i].Type == DicomRangeType.Upper)
                     endDate = new DateTime(d[i].Date1.Year, d[i].Date1.Month, d[i].Date1.Day, 23, 59, 59);
                  else if (d[i].Type == DicomRangeType.Both)
                     endDate = new DateTime(d[i].Date2.Year, d[i].Date2.Month, d[i].Date2.Day, 23,59,59);
               }

               // Get the start time and end time
               if (i < tCount)
               {
                  // start date
                  if ((t[i].Type == DicomRangeType.Lower) || (t[i].Type == DicomRangeType.Both))
                     startTime = new DateTime(1,1,1,t[i].Time1.Hours, t[i].Time1.Minutes, t[i].Time1.Seconds);

                  // end date
                  if (t[i].Type == DicomRangeType.Upper)
                     endTime = new DateTime(1,1,1,t[i].Time1.Hours, t[i].Time1.Minutes, t[i].Time1.Seconds);
                  else if (t[i].Type == DicomRangeType.Both)
                     endTime = new DateTime(1,1,1,t[i].Time2.Hours, t[i].Time2.Minutes, t[i].Time2.Seconds);
               }

               string sAdd = string.Format("( (StudyDate >= '{0}') and (StudyDate <= '{1}'))", startDate, endDate);               
               string sTimeFormatString = "AND ((CONVERT(nvarchar,StudyDate,108) BETWEEN '{0}' AND '{1}'))";

               filter += sAdd;
               sAdd = string.Format(sTimeFormatString, startTime.ToString("HH:mm:ss"), endTime.ToString("HH:mm:ss"));
               filter += sAdd;
            }

            temp = ds.GetValue<string>(DicomTag.AccessionNumber, string.Empty);
            if (temp.Length > 0)
            {
                if (filter.Length > 0)
                    filter += " AND ";
                filter += CheckForWildcards("AccessionNumber = '" + temp + "'");
            }

            temp = ds.GetValue<string>(DicomTag.StudyID, string.Empty);
            if (temp.Length > 0)
            {
                if (filter.Length > 0)
                    filter += " AND ";
                filter += CheckForWildcards("StudyId LIKE '" + temp + "'");
            }

            temp = ds.GetValue<string>(DicomTag.ReferringPhysicianName, string.Empty);
            if (temp.Length > 0)
            {
                temp = temp.Replace("*", "%");
                if (filter.Length > 0)
                    filter += " AND ";
                filter += CheckForWildcards("ReferDrName LIKE '" + temp + "'");
            }

            temp = FindElementModalitiesInStudy(ds);
            if (temp.Length > 0)
            {
               if (filter.Length > 0)
                  filter += " AND ";
               filter += temp;
            }

            if (string.IsNullOrEmpty(filter))
                filter = "SELECT p.PatientId,Name,Studies.* FROM Studies JOIN Patients p ON p.PatientId = Studies.PatientId";
            else
                filter = "SELECT p.PatientId,Name,Studies.* FROM Studies JOIN Patients p ON p.PatientId = Studies.PatientId WHERE " + filter;


            reader = SqlCeHelper.ExecuteReader(connection, filter);
            while (reader.Read())
            {
                response.InsertElementAndSetValue(DicomTag.StudyInstanceUID, reader["StudyInstanceUID"]);

                if (reader["StudyDate"] != System.DBNull.Value)
                {
                    DateTime date = DateTime.Parse(reader["StudyDate"].ToString());

                    response.InsertElementAndSetValue(DicomTag.StudyDate, date.ToShortDateString());
                    response.InsertElementAndSetValue(DicomTag.StudyTime, date.ToShortTimeString());
                }

                if (reader["AccessionNumber"] != null)
                    response.InsertElementAndSetValue(DicomTag.AccessionNumber, reader["AccessionNumber"]);
                if (reader["StudyId"] != null)
                    response.InsertElementAndSetValue(DicomTag.StudyID, reader["StudyId"]);
                if (reader["PatientID"] != null)
                    response.InsertElementAndSetValue(DicomTag.PatientID, reader["PatientId"]);
                if (reader["Name"] != null)
                    response.InsertElementAndSetValue(DicomTag.PatientName, reader["Name"]);
                if (reader["ReferDrName"] != null)
                    response.InsertElementAndSetValue(DicomTag.ReferringPhysicianName, reader["ReferDrName"]);
                if (reader["StudyDescription"] != null)
                    response.InsertElementAndSetValue(DicomTag.StudyDescription, reader["StudyDescription"]);

                try
                {
                    string sql = string.Format("SELECT Count(*) FROM Series WHERE StudyInstanceUid = '{0}'", reader["StudyInstanceUID"]);

                    response.InsertElementAndSetValue(DicomTag.NumberOfStudyRelatedSeries, (int)SqlCeHelper.ExecuteScalar(connection, sql));
                    sql = string.Format("SELECT Count(*) FROM Images WHERE StudyInstanceUid = '{0}'", reader["StudyInstanceUID"]);
                    response.InsertElementAndSetValue(DicomTag.NumberOfStudyRelatedInstances, (int)SqlCeHelper.ExecuteScalar(connection, sql));
                }
                catch { }

                if (addin.OnMatchFound(response))
                {
                    reader.Close();
                    return DicomCommandStatusType.Cancel;
                }
                else if (addin.Cancel)
                {
                    if (addin.BreakType == BreakType.Cancel)
                        return DicomCommandStatusType.Cancel;
                    else
                        return DicomCommandStatusType.Failure;
                }

                //response.Clear();
            }
            return DicomCommandStatusType.Success;
        }

        /// <summary>
        /// Finds the series.
        /// </summary>
        /// <param name="addin">The addin.</param>
        /// <param name="affectedClass">The affected class.</param>
        /// <param name="connection">The connection.</param>
        /// <param name="ds">The ds.</param>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static DicomCommandStatusType FindSeries(FindAddIn addin, string affectedClass,string connection, DicomDataSet ds, DicomDataSet response)
        {
            string filter = string.Empty;
            string temp;            
            SqlCeDataReader reader;

            filter = "s.StudyInstanceUID = '" + ds.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty) + "'";

            temp = ds.GetValue<string>(DicomTag.PatientID, string.Empty);
            if (affectedClass == DicomUidType.PatientRootQueryFind && temp.Length>0)
            {
                filter += " AND p.PatientID = '" + temp + "'";            
            }

            temp = ds.GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);
            if (temp.Length > 0)
            {
                filter += " AND SeriesInstanceUID='" + temp + "'";
            }

            temp = ds.GetValue<string>(DicomTag.Modality, string.Empty);
            if (temp.Length > 0)
            {
                filter += " AND Modality LIKE '" + temp + "'";
            }

            temp = ds.GetValue<string>(DicomTag.SeriesNumber, string.Empty);
            if (temp.Length > 0)
            {
                filter += " AND SeriesNumber = " + temp;
            }

            filter = "SELECT p.PatientId,Name,Series.* FROM Series JOIN Studies s ON s.StudyInstanceUid = Series.StudyInstanceUid JOIN Patients p ON p.PatientId = s.PatientId WHERE " + filter;
            reader = SqlCeHelper.ExecuteReader(connection, filter);
            while (reader.Read())
            {
                response.InsertElementAndSetValue(DicomTag.SeriesInstanceUID, reader["SeriesInstanceUID"]);

                if (reader["Modality"] != null)
                    response.InsertElementAndSetValue(DicomTag.Modality, reader["Modality"]);
                if (reader["SeriesNumber"] != null && IsInteger(reader["SeriesNumber"].ToString()))
                    response.InsertElementAndSetValue(DicomTag.SeriesNumber, reader["SeriesNumber"]);
                if (reader["SeriesDate"] != null && reader["SeriesDate"].ToString().Length>0)
                {
                    DateTime date = DateTime.Parse(reader["SeriesDate"].ToString());

                    response.InsertElementAndSetValue(DicomTag.SeriesDate, date.ToShortDateString());
                    response.InsertElementAndSetValue(DicomTag.SeriesTime, date.ToShortTimeString());
                }
                if(reader["SeriesDesscription"]!=null)
                    response.InsertElementAndSetValue(DicomTag.SeriesDescription, reader["SeriesDesscription"].ToString());
                if (reader["StudyInstanceUID"] != null)
                    response.InsertElementAndSetValue(DicomTag.StudyInstanceUID, reader["StudyInstanceUID"].ToString());
                try
                {
                    string sql = string.Format("SELECT Count(*) FROM Images WHERE SeriesInstanceUID = '{0}'", reader["SeriesInstanceUID"]);

                    response.InsertElementAndSetValue(DicomTag.NumberOfSeriesRelatedInstances, (int)SqlCeHelper.ExecuteScalar(connection, sql));                    
                }
                catch { }

                if (addin.OnMatchFound(response))
                {
                    reader.Close();
                    return DicomCommandStatusType.Cancel;
                }
                else if (addin.Cancel)
                {
                    if (addin.BreakType == BreakType.Cancel)
                        return DicomCommandStatusType.Cancel;
                    else
                        return DicomCommandStatusType.Failure;
                }


                //response.Clear();
            }

            return DicomCommandStatusType.Success;
        }

        private static bool IsInteger(string intString)
        {
           int num;

           return int.TryParse(intString, out num);
        }

        /// <summary>
        /// Finds the image.
        /// </summary>
        /// <param name="addin">The addin.</param>
        /// <param name="affectedClass">The affected class.</param>
        /// <param name="connection">The connection.</param>
        /// <param name="ds">The ds.</param>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static DicomCommandStatusType FindImage(FindAddIn addin, string affectedClass, string connection, DicomDataSet ds, DicomDataSet response)
        {
            string filter = string.Empty;
            string temp;
            SqlCeDataReader reader;

            filter = "s.StudyInstanceUID = '" + ds.GetValue<string>(DicomTag.StudyInstanceUID,string.Empty) + "'";
            filter += " AND SeriesInstanceUID = '" + ds.GetValue<string>(DicomTag.SeriesInstanceUID,string.Empty) + "'";

            temp = ds.GetValue<string>(DicomTag.PatientID, string.Empty);
            if (affectedClass == DicomUidType.PatientRootQueryFind && temp.Length > 0)
            {
                filter += " AND p.PatientID = '" + temp + "'";
            }

            List<string> instances = ds.GetValue<List<string>>(DicomTag.SOPInstanceUID, new List<string>());

            foreach (string instance in instances)
            {
                filter += " AND SOPInstanceUID ='" + instance + "'";
            }

            temp = ds.GetValue<string>(DicomTag.InstanceNumber, string.Empty);
            if (temp.Length > 0)
            {
                filter += " AND InstanceNumber = " + temp.ToString();
            }

            filter = "SELECT p.PatientId,Name,Images.* FROM Images JOIN Studies s ON s.StudyInstanceUid = images.StudyInstanceUid JOIN Patients p ON p.PatientId = s.PatientId WHERE " + filter;
            reader = SqlCeHelper.ExecuteReader(connection, filter);
            while (reader.Read())
            {
                response.InsertElementAndSetValue(DicomTag.SOPInstanceUID, reader["SOPInstanceUID"]);
                if(affectedClass == DicomUidType.PatientRootQueryFind)
                    response.InsertElementAndSetValue(DicomTag.PatientID, ds.GetValue<string>(DicomTag.PatientID, string.Empty));

                if (reader["ImageNumber"] != null && reader["ImageNumber"].ToString().Length>0)
                    response.InsertElementAndSetValue(DicomTag.InstanceNumber, reader["ImageNumber"]);                

                if (addin.OnMatchFound(response))
                {
                    reader.Close();
                    return DicomCommandStatusType.Cancel;
                }
                else if (addin.Cancel)
                {
                    if (addin.BreakType == BreakType.Cancel)
                        return DicomCommandStatusType.Cancel;
                    else
                        return DicomCommandStatusType.Failure;
                }

                //response.Clear();
            }

            return DicomCommandStatusType.Success;
        }

        public static string GetReferencedFile(string connection, string sopInstanceUID)
        {
           object referencedFile = string.Empty;
           string sql = string.Format("SELECT ReferencedFile FROM Images WHERE SopInstanceUID = '{0}'", sopInstanceUID);

           referencedFile = SqlCeHelper.ExecuteScalar(connection, sql);
           if (referencedFile != null)
              return referencedFile.ToString();

           return string.Empty;
        }

        /// <summary>
        /// Converts date to SQL Compact SQL format.
        /// </summary>
        /// <param name="reqDate">The req date.</param>
        /// <returns></returns>
        private static string ConvertToQueryDate(string reqDate)
        {
            string date = reqDate.Substring(4, 2) + "/" + reqDate.Substring(6, 2) + "/" + reqDate.Substring(0, 4);

            return DateTime.Parse(date).ToString("yyyy-M-d");
        }
    }
}
