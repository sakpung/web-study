// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer;

namespace My.Medical.Storage.DataAccessLayer.DataAccessLogic.DataAccessAgent.Database.SqlServer
{
   // SQL query statements and statement fragments used by MyStorageSqlDbDataAccessAgent class
   public class MyConstants
   {
      public const string PrimaryKeyTableName = "#PrimaryKeys";

      public abstract class DeleteCommandText
      {
         public static readonly string OrphanPatient = "DELETE FROM MyPatientTable " +
                                                      "WHERE MyPatientTable.PatientId " +
                                                      "NOT IN ( SELECT MyStudyTable.StudyPatientId FROM MyStudyTable ) ";

         public static readonly string OrphanStudies = "DELETE FROM MyStudyTable " +
                                                      "WHERE MyStudyTable.StudyId " +
                                                      "NOT IN ( SELECT MySeriesTable.SeriesStudyId FROM MySeriesTable ) ";

         public static readonly string OrphanSeries = "DELETE FROM MySeriesTable " +
                                                      "WHERE MySeriesTable.SeriesId " +
                                                      "NOT IN ( SELECT MyInstanceTable.ImageSeriesId FROM MyInstanceTable ) ";

         public static readonly string FromPatient = "DELETE FROM MyPatientTable " +
                                                      "WHERE ( MyPatientTable.PatientId IN ( SELECT MyPatientTable.PatientId ";

         public static readonly string FromStudy = "DELETE FROM MyStudyTable " +
                                                      "WHERE ( MyStudyTable.StudyId IN ( SELECT MyStudyTable.StudyId ";

         public static readonly string FromSeries = "DELETE FROM MySeriesTable " +
                                                      "WHERE ( MySeriesTable.SeriesId IN ( SELECT MySeriesTable.SeriesId ";

         public static readonly string FromInstance = "DELETE FROM MyInstanceTable " +
                                                      "WHERE ( MyInstanceTable.SOPInstanceUID  IN ( SELECT MyInstanceTable.SOPInstanceUID ";
         public const string DeleteLastPart = " ) ) ";
      }

      public abstract class SelectCommandText
      {
         public const string MIDDLE_PART = "SET NOCOUNT OFF ";

         public static readonly string LAST_PART = string.Format("DROP TABLE {0} ", MyConstants.PrimaryKeyTableName) + "END ";

         private static readonly string FirstPartInternal = "BEGIN " +
                                                    "SET NOCOUNT ON " +
                                                    "CREATE TABLE {0} " +
                                                     " PatientId [int], " +
                                                     " StudyId [int], " +
                                                     " SeriesId [int], " +
                                                     " ImageId [int] " +
                                                     " ) " +
                                                    "INSERT INTO {0} {1}";


         public static readonly string FirstPart = "BEGIN SET NOCOUNT ON CREATE TABLE #PrimaryKeys ( " +
                                                     " PatientId [int], " +
                                                     " StudyId [int], " +
                                                     " SeriesId [int], " +
                                                     " ImageId [int] " +
                                                     " ) " +
                                       "INSERT INTO #PrimaryKeys " +
                                       " SELECT  " +
                                       " MyPatientTable.PatientId, " +
                                       " MyStudyTable.StudyId, " +
                                       " MySeriesTable.SeriesId, " +
                                       " MyInstanceTable.ImageId ";

         public static string GetFirstPartPagination(QueryPageInfo queryPageInfo)
         {
            if (queryPageInfo == null)
            {
               return FirstPart;
            }
            string sTop = string.Format("TOP {0} ", queryPageInfo.PageSize);
            string sOut = string.Format(
               FirstPartInternal,
               MyConstants.PrimaryKeyTableName,
               string.Format(MySqlStatments.SelectIntoPrimaryTable, sTop));
            return sOut;
         }

         public abstract class FromClause
         {
            public static readonly string Patient = "FROM MyPatientTable " +
                                                    "LEFT OUTER JOIN MyStudyTable      ON MyStudyTable.StudyPatientId      = MyPatientTable.PatientId " +
                                                    "LEFT OUTER JOIN MySeriesTable     ON MySeriesTable.SeriesStudyId      = MyStudyTable.StudyId " +
                                                    "LEFT OUTER JOIN MyInstanceTable   ON MyInstanceTable.ImageSeriesId    = MySeriesTable.SeriesId " +
                                                    " ";

            public static readonly string Study = "FROM MyStudyTable " +
                                                  "LEFT OUTER JOIN MyPatientTable    ON MyPatientTable.PatientId         = MyStudyTable.StudyPatientId " +
                                                  "LEFT OUTER JOIN MySeriesTable     ON MySeriesTable.SeriesStudyId      = MyStudyTable.StudyId " +
                                                  "LEFT OUTER JOIN MyInstanceTable   ON MyInstanceTable.ImageSeriesId    = MySeriesTable.SeriesId " +
                                                  " ";

            public static readonly string Series = "FROM MySeriesTable " +
                                                   "LEFT OUTER JOIN MyStudyTable      ON MyStudyTable.StudyId             = MySeriesTable.SeriesStudyId " +
                                                   "LEFT OUTER JOIN MyPatientTable    ON MyPatientTable.PatientId         = MyStudyTable.StudyPatientId " +
                                                   "LEFT OUTER JOIN MyInstanceTable   ON MyInstanceTable.ImageSeriesId    = MySeriesTable.SeriesId " +
                                                   " ";

            public static readonly string Image = "FROM MyInstanceTable " +
                                                  "LEFT OUTER JOIN MySeriesTable     ON MySeriesTable.SeriesId            = MyInstanceTable.ImageSeriesId " +
                                                  "LEFT OUTER JOIN MyStudyTable      ON MyStudyTable.StudyId                    = MySeriesTable.SeriesStudyId " +
                                                  "LEFT OUTER JOIN MyPatientTable    ON MyPatientTable.PatientId                = MyStudyTable.StudyPatientId " +
                                                  " ";
         }

         public abstract class SelectStatements
         {
            public static readonly string PatientEntity = @"SELECT * FROM MyPatientTable WHERE PatientId IN ( SELECT PatientId FROM #PrimaryKeys ) ";

            public static readonly string StudyEntity = @"SELECT * FROM MyStudyTable WHERE StudyId IN ( SELECT StudyId FROM #PrimaryKeys ) ";

            public static readonly string SeriesEntity = @"SELECT * FROM MySeriesTable WHERE SeriesId IN ( SELECT SeriesId FROM #PrimaryKeys ) ";

            public static readonly string InstanceEntity = @"SELECT * FROM MyInstanceTable WHERE ImageId IN ( SELECT ImageId FROM #PrimaryKeys ) ";

         }
      }
   }
   
   public class MySqlStatments
            {
               public static readonly string SelectIntoPrimaryTable = "SELECT {0} " +
                                                " MyPatientTable.PatientId, "+
                                                " MyStudyTable.StudyId, "+
                                                " MySeriesTable.SeriesId, "+
                                                " MyInstanceTable.ImageId " ;
            
               public abstract class SeriesEntitySelect
               {
                  public static readonly string SeriesCount = "SELECT COUNT ( MySeriesTable.SeriesId  ) FROM MySeriesTable WHERE SeriesId IN ( SELECT SeriesId FROM {0} ) ";
               }
               
               public abstract class InstanceEntitySelect
               {
                  public static readonly string Instance = "SELECT * FROM MyInstanceTable WHERE SOPInstanceUID IN ( SELECT SOPInstanceUID FROM {0} ) ";
                     
                  public static readonly string InstanceCount = "SELECT COUNT ( MyInstanceTable.ImageId ) FROM MyInstanceTable WHERE ImageId IN ( SELECT ImageId FROM {0} ) ";
               }
               
               public static readonly string SqlGenericSelectCount = @"SELECT COUNT (*) FROM '{0}'" ;
               
               public static readonly string SqlSpecificSelectCount = @"SELECT ROWS 
FROM sysindexes
WHERE OBJECT_NAME(id) = '{0}' and indid = 1" ;
            }
}
