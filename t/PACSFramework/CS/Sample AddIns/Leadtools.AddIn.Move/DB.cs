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

namespace Leadtools.AddIn.Move
{
    public static class DB    
    {                     
        /// <summary>
        /// Moves the images.
        /// </summary>
        /// <param name="addin">The addin.</param>
        /// <param name="level">The level.</param>
        /// <param name="affectedClass">The affected class.</param>
        /// <param name="connection">The connection.</param>
        /// <param name="ds">The ds.</param>
        /// <returns></returns>
        internal static DicomCommandStatusType MoveImages(MoveAddIn addin, string level, string affectedClass, string connection, DicomDataSet ds)
        {
            string filter = string.Empty;
            string countFilter = string.Empty;
            string queryFilter = string.Empty;
            string sTemp = string.Empty;
            object count = null;
            SqlCeDataReader reader;
            MoveDataSetEventArgs move = new MoveDataSetEventArgs();

            if (affectedClass == DicomUidType.PatientRootQueryMove ||
                affectedClass == DicomUidType.PatientRootQueryGet)
            {
               filter += " AND ";
               filter += AddParen("p.PatientID = '" + ds.GetValue<string>(DicomTag.PatientID, string.Empty) + "'");
            }

            if (level == "STUDY" || level == "SERIES" || level == "IMAGE")
            {
                    filter += " AND ";

                if (level == "STUDY")
                    filter += AddParen("s.StudyInstanceUID = '" + ds.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty) + "'");
                else
                {
                    List<string> instances = ds.GetValue<List<string>>(DicomTag.StudyInstanceUID,new List<string>());

                    sTemp = string.Empty;
                    foreach(string instance in instances)
                    {
                        sTemp += "s.StudyInstanceUID ='" + instance + "'";
                        if (instances.IndexOf(instance)<instances.Count -1)
                            sTemp += " AND ";
                    }
                    filter += AddParen(sTemp);
                }
            }

            if (level == "SERIES" || level == "IMAGE")
            {
                filter += " AND ";

                if (level != "SERIES")
                    filter += AddParen("r.SeriesInstanceUID = '" + ds.GetValue<string>(DicomTag.SeriesInstanceUID,string.Empty) + "'");
                else
                {
                    List<string> instances = ds.GetValue<List<string>>(DicomTag.SeriesInstanceUID, new List<string>());

                    sTemp = string.Empty;
                    foreach (string instance in instances)
                    {
                        sTemp += "r.SeriesInstanceUID ='" + instance + "'";
                        if (instances.IndexOf(instance) < instances.Count - 1)
                            sTemp += " AND ";
                    }
                    filter += AddParen(sTemp);
                }
            }

            if (level == "IMAGE")
            {
                List<string> instances = ds.GetValue<List<string>>(DicomTag.SOPInstanceUID, new List<string>());

                if (instances.Count>0)
                    filter += " AND ";

                sTemp = string.Empty;
                foreach (string instance in instances)
                {
                    sTemp += "i.SOPInstanceUID ='" + instance + "'";
                    if (instances.IndexOf(instance) < instances.Count - 1)
                        sTemp += " AND ";
                }
                filter += AddParen(sTemp);   
            }

            //countFilter = "SELECT COUNT(*) FROM IMAGES WHERE " + filter;
            //filter = "SELECT * FROM IMAGES WHERE " + filter;    

            countFilter =
               "SELECT COUNT(*) " +
               "FROM Patients p, Studies s, Series r, Images i " +
               "WHERE (p.PatientID = s.PatientID) AND (s.StudyInstanceUID = r.StudyInstanceUID) AND (r.SeriesInstanceUID = i.SeriesInstanceUID) " + 
               filter;

            queryFilter =
               "SELECT i.* " +
               "FROM Patients p, Studies s, Series r, Images i " +
               "WHERE (p.PatientID = s.PatientID) AND (s.StudyInstanceUID = r.StudyInstanceUID) AND (r.SeriesInstanceUID = i.SeriesInstanceUID) " +
               filter;

            count = SqlCeHelper.ExecuteScalar(connection, countFilter);
            if (count == null || Convert.ToInt32(count) == 0)
                return DicomCommandStatusType.Success;

            move.Remaining = Convert.ToInt32(count);
            reader = SqlCeHelper.ExecuteReader(connection, queryFilter);
            while (reader.Read())
            {
                try
                {
                    DicomCommandStatusType status;

                    using (DicomDataSet dicom = new DicomDataSet())
                    {
                       dicom.Load(reader["ReferencedFile"].ToString(), DicomDataSetLoadFlags.LoadAndClose);
                       //move.StoreFileName = reader["ReferencedFile"].ToString();
                       move.StoreDataSet = dicom;
                       move.Remaining--;
                       status = addin.OnMoveDataSet(move);
                       if (status != DicomCommandStatusType.Success || addin.Cancel)
                       {
                          reader.Close();
                          if (addin.Cancel)
                          {
                             if (addin.BreakType == BreakType.Cancel)
                                status = DicomCommandStatusType.Cancel;
                             else
                                status = DicomCommandStatusType.Failure;
                          }
                          return status;
                       }
                    }
                }
                catch
                {
                }                
            }

            return DicomCommandStatusType.Success;
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

        private static string AddParen(string s)
        {
           return "(" + s + ")";
        }
    }
}
