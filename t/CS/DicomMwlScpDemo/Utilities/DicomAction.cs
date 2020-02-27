// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SQLite;
using System.Net;
using System.Threading;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using Leadtools.DicomDemos.Scu;

namespace DicomDemo
{
   public enum ProcessType
   {
      EchoRequest,
      StoreRequest,
      FindRequest,
      MoveRequest
   }

   public enum QueryLevel
   {
      Patient,
      Study,
      Series,
      Image,
   }

   /// <summary>
   /// Summary description for DicomThread.
   /// </summary>
   public class DicomAction
   {
      private Server server;
      private Client client;
      ProcessType process;
      private string _AETitle;
      private string _ipAddress;
      private byte _PresentationID;
      private int _MessageID;
      private string _Class;
      private string _Instance;
      private DicomCommandPriorityType _Priority;
      private string _MoveAETitle;
      private int _MoveMessageID;

      public string dsFileName;

      private DicomDataSet ds = new DicomDataSet();

      public delegate void ActionCompleteHandler(object sender, EventArgs e);

      public event ActionCompleteHandler ActionComplete;

      public Client Client
      {
         get
         {
            return client;
         }
      }

      public DicomDataSet DS
      {
         get
         {
            return ds;
         }
      }

      public string AETitle
      {
         get
         {
            return _AETitle;
         }
         set
         {
            _AETitle = value;
         }
      }

      public string ipAddress
      {
         get
         {
            return _ipAddress;
         }
         set
         {
            _ipAddress = value;
         }
      }

      public byte PresentationID
      {
         get
         {
            return _PresentationID;
         }
         set
         {
            _PresentationID = value;
         }
      }

      public int MessageID
      {
         get
         {
            return _MessageID;
         }
         set
         {
            _MessageID = value;
         }
      }

      public string Class
      {
         get
         {
            return _Class;
         }
         set
         {
            _Class = value;
         }
      }

      public string Instance
      {
         get
         {
            return _Instance;
         }
         set
         {
            _Instance = value;
         }
      }

      public DicomCommandPriorityType Priority
      {
         get
         {
            return _Priority;
         }
         set
         {
            _Priority = value;
         }
      }

      public string MoveAETitle
      {
         get
         {
            return _MoveAETitle;
         }
         set
         {
            _MoveAETitle = value;
         }
      }

      public int MoveMessageID
      {
         get
         {
            return _MoveMessageID;
         }
         set
         {
            _MoveMessageID = value;
         }
      }

      public DicomAction(ProcessType process, Server server, Client client)
      {
         this.server = server;
         this.client = client;
         this.process = process;
      }

      public DicomAction(ProcessType process, Server server, Client client, DicomDataSet ds)
      {
         this.server = server;
         this.client = client;
         this.process = process;

         if (ds != null)
         {
            this.ds.Copy(ds, null, null);
         }
      }

      protected virtual void OnActionComplete()
      {
         if (ActionComplete != null)
         {
            // Invokes the delegates. 
            ActionComplete(this, new EventArgs());
         }

         if (ds != null)
         {
            ds.Dispose();

            ds = null;
         }
      }

      public void DoAction()
      {
         if (client.Association != null)
         {
            switch (process)
            {
               case ProcessType.EchoRequest:
                  DoEchoRequest();
                  break;
               case ProcessType.FindRequest:
                  DoFindRequest();
                  break;
            }
         }
         OnActionComplete();
      }

      private bool IsActionSupported()
      {
         byte id;

         if (DicomUidTable.Instance.Find(Class) == null)
         {
            return false;
         }

         id = client.Association.FindAbstract(Class);
         if (id == 0 || client.Association.GetResult(id) !=
            DicomAssociateAcceptResultType.Success)
         {
            return false;
         }

         return true;
      }

      private string GetUIDName()
      {
         DicomUid uid = DicomUidTable.Instance.Find(Class);

         if (uid == null)
            return Class;

         return uid.Name;
      }

      /*
       * Handles a C-ECHO request
       */
      private void DoEchoRequest()
      {
         try
         {
            server.mf.Log("Client Name: " + client.Association.Calling + " -- Receiving C-Echo Response...\r\n");

            if (!IsActionSupported())
            {
               string name = GetUIDName();

               server.mf.Log("Client Name: " + client.Association.Calling + " -- Sending C-Echo Response - Status: Abstract Syntax not supported!\r\n");
               client.SendCEchoResponse(_PresentationID, _MessageID, Class,
                                       DicomCommandStatusType.ClassNotSupported);
               return;
            }

            server.mf.Log("Client Name: " + client.Association.Calling + " -- Sending C-Echo Response...\r\n");
            client.SendCEchoResponse(_PresentationID, MessageID, Class,
                                        DicomCommandStatusType.Success);
         }
         catch (Exception ex)
         {
            server.mf.Log("Error handling CEcho request:\r\n\r\n" + ex.ToString());
         }
      }

      /*
       * Handles a C-FIND request
       */
      private void DoFindRequest()
      {
         try
         {
            // We have received a C-Find Request
            server.mf.Log("Client Name:" + AETitle + " -- Receiving C-Find Request...\r\n");

            if (!IsActionSupported())
            {
               string name = GetUIDName();

               server.mf.Log("Client Name:" + AETitle + " -- Sending C-Find Response - Status: Abstract Syntax not supported!\r\n");
               client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                                        DicomCommandStatusType.ClassNotSupported, null);
               return;
            }

            if (ds == null)
            {
               server.mf.Log("Client Name:" + AETitle + " -- Sending C-Find Response - Status: Invalid argument value!\r\n");
               client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                                                 DicomCommandStatusType.InvalidArgumentValue, null);
               return;
            }

            // Build
            string strSQLQuery;
            strSQLQuery = GenerateMatchingQuery();
            FindMatchingAttributes(strSQLQuery);
         }
         catch (Exception ex)
         {
            server.mf.Log("Error handling CFind request:\r\n\r\n" + ex.ToString());
         }
      }

      /*
       * Generates an SQL query based on the client's search parameters
       */
      private string GenerateMatchingQuery()
      {
         string strSqlQuery = "";
         string strAttributeValue = "";
         DicomElement element;

         try
         {
            strSqlQuery = "SELECT * FROM MwlSCPTbl WHERE 1=1";

            // TAG_ACCESSION_NUMBER
            element = ds.FindFirstElement(null, DemoDicomTags.AccessionNumber, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Wild Card Matching or Single Value Matching
                  if ((strAttributeValue.IndexOf('*') >= 0) || (strAttributeValue.IndexOf('?') >= 0))
                  {
                     // Wild card matching -- case insensitive
                     strSqlQuery += " And TAG_ACCESSION_NUMBER LIKE '" + PrepareForWCM(strAttributeValue) + "'";
                  }
                  else
                  {
                     // Single value matching -- case sensitive
                     strSqlQuery += " And TAG_ACCESSION_NUMBER = '" + strAttributeValue + "'";
                  }
               }
            }

            // TAG_MODALITY
            element = ds.FindFirstElement(null, DemoDicomTags.Modality, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Single value matching -- case sensitive
                  strSqlQuery += " And TAG_MODALITY = '" + FilterForSingleValueMatch(strAttributeValue) + "'";
               }
            }

            // TAG_INSTITUTION_NAME
            element = ds.FindFirstElement(null, DemoDicomTags.InstitutionName, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Wild Card Matching or Single Value Matching
                  if ((strAttributeValue.IndexOf('*') >= 0) || (strAttributeValue.IndexOf('?') >= 0))
                  {
                     // Wild card matching -- case insensitive
                     strSqlQuery += " And TAG_INSTITUTION_NAME LIKE '" + PrepareForWCM(strAttributeValue) + "'";
                  }
                  else
                  {
                     // Single value matching -- case sensitive
                     strSqlQuery += " And TAG_INSTITUTION_NAME = '" + strAttributeValue + "'";
                  }
               }
            }

            // TAG_REFERRING_PHYSICIAN_NAME
            element = ds.FindFirstElement(null, DemoDicomTags.ReferringPhysicianName, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_REFERRING_PHYSICIAN_NAME LIKE '" + PrepareForWCM(strAttributeValue) + "'";
               }
            }

            // TAG_PATIENT_NAME
            element = ds.FindFirstElement(null, DemoDicomTags.PatientName, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_PATIENT_NAME LIKE '" + PrepareForWCM(strAttributeValue) + "'";
               }
            }

            // TAG_PATIENT_ID
            element = ds.FindFirstElement(null, DemoDicomTags.PatientID, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Single value matching -- case sensitive
                  strSqlQuery += " And TAG_PATIENT_ID = '" + FilterForSingleValueMatch(strAttributeValue) + "'";
               }
            }

            // TAG_PATIENT_BIRTH_DATE
            element = ds.FindFirstElement(null, DemoDicomTags.PatientBirthDate, false);
            if (element != null)
            {
               DicomDateValue[] dateValue = ds.GetDateValue(element, 0, 1);

               if (dateValue.Length > 0)
               {
                  strSqlQuery += " And (julianday(substr(TAG_PATIENT_BIRTH_DATE,1,10)) = julianday('" + ConvertDicomDateToQueryDate(dateValue[0]) + "'))";
               }
            }

            // TAG_PATIENT_SEX
            element = ds.FindFirstElement(null, DemoDicomTags.PatientSex, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Single value matching -- case sensitive
                  strSqlQuery += " And TAG_PATIENT_SEX = '" + FilterForSingleValueMatch(strAttributeValue) + "'";
               }
            }

            // TAG_PATIENT_WEIGHT
            element = ds.FindFirstElement(null, DemoDicomTags.PatientWeight, false);
            if (element != null)
            {
               double[] dAttributeValue = ds.GetDoubleValue(element, 0, 1);

               //strAttributeValue = 
               if (dAttributeValue.Length > 0)
               {
                  strAttributeValue = dAttributeValue[0].ToString();
                  // Single value matching -- case sensitive
                  strSqlQuery += " And TAG_PATIENT_WEIGHT = '" + FilterForSingleValueMatch(strAttributeValue) + "'";
               }
            }

            // TAG_STUDY_INSTANCE_UID
            strSqlQuery += GetUIDCondition((long)DemoDicomTags.StudyInstanceUID, "TAG_STUDY_INSTANCE_UID"); // List of Matching UIDs

            // TAG_REQUESTING_PHYSICIAN
            element = ds.FindFirstElement(null, DemoDicomTags.RequestingPhysician, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_REQUESTING_PHYSICIAN LIKE '" + PrepareForWCM(strAttributeValue) + "'";
               }
            }

            // TAG_REQUESTED_PROCEDURE_DESCRIPTION
            element = ds.FindFirstElement(null, DemoDicomTags.RequestedProcedureDescription, false);
            if ((strAttributeValue != null) && (strAttributeValue != ""))
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_REQUESTED_PROCEDURE_DESCRIPTION LIKE '" + PrepareForWCM(strAttributeValue) + "'";
               }
            }

            // TAG_ADMISSION_ID
            element = ds.FindFirstElement(null, DemoDicomTags.AdmissionID, false);
            if ((strAttributeValue != null) && (strAttributeValue != ""))
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Single value matching -- case sensitive
                  strSqlQuery += " And TAG_ADMISSION_ID = '" + FilterForSingleValueMatch(strAttributeValue) + "'";
               }
            }

            // TAG_SCHEDULED_STATION_AE_TITLE
            element = ds.FindFirstElement(null, DemoDicomTags.ScheduledStationAETitle, false);
            if ((strAttributeValue != null) && (strAttributeValue != ""))
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Single value matching -- case sensitive
                  strSqlQuery += " And TAG_SCHEDULED_STATION_AE_TITLE = '" + FilterForSingleValueMatch(strAttributeValue) + "'";
               }
            }

            // TAG_SCHEDULED_PROCEDURE_STEP_START_DATE
            element = ds.FindFirstElement(null, DemoDicomTags.ScheduledProcedureStepStartDate, false);
            if (element != null)
            {
               DicomDateValue[] dateValue = ds.GetDateValue(element, 0, 1);

               if (dateValue.Length > 0)
               {
                  strSqlQuery += " And (julianday(substr(TAG_SCHEDULED_PROCEDURE_STEP_START_DATE,1,10)) = julianday('" + ConvertDicomDateToQueryDate(dateValue[0]) + "'))";
               }
            }

            // TAG_SCHEDULED_PROCEDURE_STEP_START_TIME
            element = ds.FindFirstElement(null, DemoDicomTags.ScheduledProcedureStepStartTime, false);
            if (element != null)
            {
               DicomTimeValue[] timeValue = ds.GetTimeValue(element, 0, 1);

               if (timeValue.Length > 0)
               {
                  strSqlQuery += " And (julianday(substr(TAG_SCHEDULED_PROCEDURE_STEP_START_TIME,-8,8)) = julianday('" + ConvertDicomTimeToQueryTime(timeValue[0]) + "'))";
               }
            }

            // TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME
            element = ds.FindFirstElement(null, DemoDicomTags.ScheduledPerformingPhysicianName, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME LIKE '" + PrepareForWCM(strAttributeValue) + "'";
               }
            }

            // TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION
            element = ds.FindFirstElement(null, DemoDicomTags.ScheduledProcedureStepDescription, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION LIKE '" + PrepareForWCM(strAttributeValue) + "'";
               }
            }

            // TAG_SCHEDULED_PROCEDURE_STEP_ID
            element = ds.FindFirstElement(null, DemoDicomTags.ScheduledProcedureStepID, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Single value matching -- case sensitive
                  strSqlQuery += " And TAG_SCHEDULED_PROCEDURE_STEP_ID = '" + FilterForSingleValueMatch(strAttributeValue) + "'";
               }
            }

            // TAG_SCHEDULED_PROCEDURE_STEP_LOCATION
            element = ds.FindFirstElement(null, DemoDicomTags.ScheduledProcedureStepLocation, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_SCHEDULED_PROCEDURE_STEP_LOCATION LIKE '" + PrepareForWCM(strAttributeValue) + "'";
               }
            }

            // TAG_REQUESTED_PROCEDURE_ID
            element = ds.FindFirstElement(null, DemoDicomTags.RequestedProcedureID, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Single value matching -- case sensitive
                  strSqlQuery += " And TAG_REQUESTED_PROCEDURE_ID = '" + FilterForSingleValueMatch(strAttributeValue) + "'";
               }
            }

            // TAG_REASON_FOR_THE_REQUESTED_PROCEDURE
            element = ds.FindFirstElement(null, DemoDicomTags.ReasonForTheRequestedProcedure, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Single value matching -- case sensitive
                  strSqlQuery += " And TAG_REASON_FOR_THE_REQUESTED_PROCEDURE = '" + FilterForSingleValueMatch(strAttributeValue) + "'";
               }
            }

            // TAG_REQUESTED_PROCEDURE_PRIORITY
            element = ds.FindFirstElement(null, DemoDicomTags.RequestedProcedurePriority, false);
            if (element != null)
            {
               strAttributeValue = ds.GetStringValue(element, 0);
               if ((strAttributeValue != null) && (strAttributeValue != ""))
               {
                  // Single value matching -- case sensitive
                  strSqlQuery += " And TAG_REQUESTED_PROCEDURE_PRIORITY = '" + FilterForSingleValueMatch(strAttributeValue) + "'";
               }
            }
         }
         catch (Exception ex)
         {
            server.mf.Log("Error generating SQL query:\r\n\r\n" + ex.ToString());
            return "";
         }

         return strSqlQuery;
      }

      /*
       * Finds, builds, and returns to SCU datasets that match the query.
       */
      private void FindMatchingAttributes(string strSQLQuery)
      {
         // Get matching data from the database
         SQLiteConnection SqlConn = new SQLiteConnection();
         SqlConn.ConnectionString = String.Format("Data Source={0};New=False;Version=3", server.mf.m_strDBFileName);

         try
         {
            SqlConn.Open();

            SQLiteCommand cmd = SqlConn.CreateCommand();
            cmd.CommandText = strSQLQuery;
            SQLiteDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            // Loop over the retrieved data
            while (reader.Read())
            {
               using (DicomDataSet ResponseDicomDS = PrepareResponseDS())
               {
                  string value;
                  DateTime time;

                  if (reader["TAG_ACCESSION_NUMBER"] != DBNull.Value)
                     value = (string)reader["TAG_ACCESSION_NUMBER"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.AccessionNumber, value, false);

                  if (reader["TAG_MODALITY"] != DBNull.Value)
                     value = (string)reader["TAG_MODALITY"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.Modality, value, false);

                  if (reader["TAG_INSTITUTION_NAME"] != DBNull.Value)
                     value = (string)reader["TAG_INSTITUTION_NAME"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.InstitutionName, value, false);


                  if (reader["TAG_REFERRING_PHYSICIAN_NAME"] != DBNull.Value)
                     value = (string)reader["TAG_REFERRING_PHYSICIAN_NAME"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ReferringPhysicianName, value, false);


                  if (reader["TAG_PATIENT_NAME"] != DBNull.Value)
                     value = (string)reader["TAG_PATIENT_NAME"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientName, value, false);

                  if (reader["TAG_PATIENT_ID"] != DBNull.Value)
                     value = (string)reader["TAG_PATIENT_ID"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientID, value, false);

                  // dates must be handled specially
                  if (reader.GetString(reader.GetOrdinal("TAG_PATIENT_BIRTH_DATE")) != "")
                  {
                     time = DateTime.Parse(reader.GetString(reader.GetOrdinal("TAG_PATIENT_BIRTH_DATE")));
                     SetTimeDateKeyElement(ResponseDicomDS, time, DemoDicomTags.PatientBirthDate, false);
                  }
                  else
                  {
                     Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientBirthDate, value);
                  }

                  if (reader["TAG_PATIENT_SEX"] != DBNull.Value)
                     value = (string)reader["TAG_PATIENT_SEX"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientSex, value, false);

                  if (reader["TAG_PATIENT_WEIGHT"] != DBNull.Value)
                     value = ((decimal)reader["TAG_PATIENT_WEIGHT"]).ToString();
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientWeight, value, false);

                  if (reader["TAG_STUDY_INSTANCE_UID"] != DBNull.Value)
                     value = (string)reader["TAG_STUDY_INSTANCE_UID"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.StudyInstanceUID, value, false);

                  if (reader["TAG_REQUESTING_PHYSICIAN"] != DBNull.Value)
                     value = (string)reader["TAG_REQUESTING_PHYSICIAN"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.RequestingPhysician, value, false);

                  if (reader["TAG_REQUESTED_PROCEDURE_DESCRIPTION"] != DBNull.Value)
                     value = (string)reader["TAG_REQUESTED_PROCEDURE_DESCRIPTION"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.RequestedProcedureDescription, value, false);

                  if (reader["TAG_ADMISSION_ID"] != DBNull.Value)
                     value = (string)reader["TAG_ADMISSION_ID"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.AdmissionID, value, false);

                  if (reader["TAG_SCHEDULED_STATION_AE_TITLE"] != DBNull.Value)
                     value = (string)reader["TAG_SCHEDULED_STATION_AE_TITLE"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ScheduledStationAETitle, value, false);

                  // dates must be handled specially
                  if (reader.GetString(reader.GetOrdinal("TAG_SCHEDULED_PROCEDURE_STEP_START_DATE")) != "")
                  {
                     time = DateTime.Parse(reader.GetString(reader.GetOrdinal("TAG_SCHEDULED_PROCEDURE_STEP_START_DATE")));
                     SetTimeDateKeyElement(ResponseDicomDS, time, DemoDicomTags.ScheduledProcedureStepStartDate, false);
                  }
                  else
                  {
                     Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientBirthDate, value, false);
                  }

                  // dates must be handled specially
                  if (reader.GetString(reader.GetOrdinal("TAG_SCHEDULED_PROCEDURE_STEP_START_TIME")) != "")
                  {
                     time = DateTime.Parse(reader.GetString(reader.GetOrdinal("TAG_SCHEDULED_PROCEDURE_STEP_START_TIME")));
                     SetTimeDateKeyElement(ResponseDicomDS, time, DemoDicomTags.ScheduledProcedureStepStartTime, true);
                  }
                  else
                  {
                     Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientBirthDate, value, false);
                  }

                  if (reader["TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME"] != DBNull.Value)
                     value = (string)reader["TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ScheduledPerformingPhysicianName, value, false);

                  if (reader["TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION"] != DBNull.Value)
                     value = (string)reader["TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ScheduledProcedureStepDescription, value, false);

                  if (reader["TAG_SCHEDULED_PROCEDURE_STEP_ID"] != DBNull.Value)
                     value = (string)reader["TAG_SCHEDULED_PROCEDURE_STEP_ID"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ScheduledProcedureStepID, value, false);

                  if (reader["TAG_SCHEDULED_PROCEDURE_STEP_LOCATION"] != DBNull.Value)
                     value = (string)reader["TAG_SCHEDULED_PROCEDURE_STEP_LOCATION"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ScheduledProcedureStepLocation, value, false);

                  if (reader["TAG_REQUESTED_PROCEDURE_ID"] != DBNull.Value)
                     value = (string)reader["TAG_REQUESTED_PROCEDURE_ID"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.RequestedProcedureID, value, false);

                  if (reader["TAG_REASON_FOR_THE_REQUESTED_PROCEDURE"] != DBNull.Value)
                     value = (string)reader["TAG_REASON_FOR_THE_REQUESTED_PROCEDURE"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ReasonForTheRequestedProcedure, value, false);

                  if (reader["TAG_REQUESTED_PROCEDURE_PRIORITY"] != DBNull.Value)
                     value = (string)reader["TAG_REQUESTED_PROCEDURE_PRIORITY"];
                  else
                     value = "";
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.RequestedProcedurePriority, value, false);

                  // Send the response Dataset
                  if (client.IsConnected())
                  {
                     server.mf.Log("Client Name:" + AETitle + " -- Sending C-Find Response - Status: Pending\r\n");
                     client.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.Pending, ResponseDicomDS);
                  }
                  else
                  {
                     server.mf.Log("Client Name:" + AETitle + " -- Cannot send C-Find Response because client is no longer connected.\r\n");
                     break;
                  }
               }
            }
         }
         catch (Exception ex)
         {
            server.mf.Log(ex.ToString());
            server.mf.Log("Client Name:" + AETitle + " -- Sending C-Find Response - Status: Processing failure!\r\n");
            try
            {
               client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                                        DicomCommandStatusType.ProcessingFailure, null);
            }
            catch (Exception ex2)
            {
               // do nothing since we can't send a response to the client.  The client can handle a timeout if necessary.
               server.mf.Log(ex2.ToString());
            }
            return;
         }

         SqlConn.Close();

         // The final C-FIND-RSP

         if (client.IsConnected())
         {
            server.mf.Log("Client Name:" + AETitle + " -- Sending C-Find Response - Status: Success\r\n");
            client.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.Success, null);
         }
      }

      /*
       * Replaces every '*' with '%' and every '?' with '_' for the SQL Wildcard matching
       */
      private string PrepareForWCM(string strValue)
      {
         try
         {
            strValue = strValue.Replace('*', '%');
            strValue = strValue.Replace('?', '_');
         }
         catch (Exception ex)
         {
            server.mf.Log("Error preparing string for Wild Card matching:\r\n\r\n" + ex.ToString());
         }
         return strValue;
      }

      /*
       * Ensures that the string will return only a perfect match.
       */
      private string FilterForSingleValueMatch(string strValue)
      {
         try
         {
            strValue = strValue.Replace("*", "");
            strValue = strValue.Replace("?", "");
         }
         catch (Exception ex)
         {
            server.mf.Log("Error filtering string for single value matching:\r\n\r\n" + ex.ToString());
         }
         return strValue;
      }

      /*
       * Converts a DicomDateValue object into a string formatted as yyyy-mm-dd
       */
      private string ConvertDicomDateToQueryDate(DicomDateValue ddv)
      {
         try
         {
            // Add 0s to beginning if necessary, e.g. yyyy-m-dd needs to be yyyy-mm-dd
            return ddv.Year.ToString().PadLeft(4, '0') + "-" +
                   ddv.Month.ToString().PadLeft(2, '0') + "-" +
                   ddv.Day.ToString().PadLeft(2, '0');
         }
         catch (Exception ex)
         {
            server.mf.Log("Error Converting date:\r\n\r\n" + ex.ToString());
            return "";
         }
      }

      /*
       * Converts a DicomTimeValue object into a string formatted as HH:MM:SS
       */
      private string ConvertDicomTimeToQueryTime(DicomTimeValue dtv)
      {
         try
         {
            // Add 0s to beginning if necessary, e.g. HH-M-SS needs to be HH-MM-SS
            return dtv.Hours.ToString().PadLeft(2, '0') + ":" +
                   dtv.Minutes.ToString().PadLeft(2, '0') + ":" +
                   dtv.Seconds.ToString().PadLeft(2, '0');
         }
         catch (Exception ex)
         {
            server.mf.Log("Error converting time:\r\n\r\n" + ex.ToString());
            return "";
         }
      }

      private void AddSecheduledProcedureStepSequenceAttributes(DicomDataSet ResponseDicomDS, DicomElement item)
      {
         ResponseDicomDS.InsertElement(item, true, DemoDicomTags.ScheduledStationAETitle, DicomVRType.UN, false, 0);
         ResponseDicomDS.InsertElement(item, true, DemoDicomTags.ScheduledProcedureStepStartDate, DicomVRType.UN, false, 0);
         ResponseDicomDS.InsertElement(item, true, DemoDicomTags.ScheduledProcedureStepStartTime, DicomVRType.UN, false, 0);
         ResponseDicomDS.InsertElement(item, true, DemoDicomTags.Modality, DicomVRType.UN, false, 0);
         ResponseDicomDS.InsertElement(item, true, DemoDicomTags.ScheduledPerformingPhysicianName, DicomVRType.UN, false, 0);
         ResponseDicomDS.InsertElement(item, true, DemoDicomTags.ScheduledProcedureStepDescription, DicomVRType.UN, false, 0);
         ResponseDicomDS.InsertElement(item, true, DicomTag.ScheduledStationName, DicomVRType.UN, false, 0);
         ResponseDicomDS.InsertElement(item, true, DemoDicomTags.ScheduledProcedureStepLocation, DicomVRType.UN, false, 0);
         DicomElement sequence = ResponseDicomDS.InsertElement(item, true, DemoDicomTags.ScheduledProtocolCodeSequence, DicomVRType.SQ, true, 0);
         sequence = ResponseDicomDS.InsertElement(sequence, true, DemoDicomTags.Item, DicomVRType.SQ, true, 0);
         ResponseDicomDS.InsertElement(sequence, true, DicomTag.CodeValue, DicomVRType.UN, false, 0);
         ResponseDicomDS.InsertElement(sequence, true, DicomTag.CodingSchemeDesignator, DicomVRType.UN, false, 0);
         ResponseDicomDS.InsertElement(sequence, true, DicomTag.CodeMeaning, DicomVRType.UN, false, 0);
         ResponseDicomDS.InsertElement(item, true, DicomTag.PreMedication, DicomVRType.UN, false, 0);
         ResponseDicomDS.InsertElement(item, true, DemoDicomTags.ScheduledProcedureStepID, DicomVRType.UN, false, 0);
         ResponseDicomDS.InsertElement(item, true, DicomTag.RequestedContrastAgent, DicomVRType.UN, false, 0);

      }

      /*
       * Initializes a blank dataset to send back to the SCU
       */
      private DicomDataSet PrepareResponseDS()
      {
         try
         {
            DicomDataSet ResponseDicomDS = new DicomDataSet();

            ResponseDicomDS.Initialize(DicomClassType.Undefined, DicomDataSetInitializeType.ImplicitVRLittleEndian);

            DicomElement element;

            // Scheduled Procedure Step
            element = ds.FindFirstElement(null, DemoDicomTags.ScheduledProcedureStepSequence, false);
            if (element != null)
            {
               DicomElement sequence = null;
               DicomElement item = null;
               sequence = ResponseDicomDS.InsertElement(null, false, DemoDicomTags.ScheduledProcedureStepSequence, DicomVRType.SQ, true, 0);
               if (sequence != null)
               {
                  item = ResponseDicomDS.InsertElement(sequence, true, DemoDicomTags.Item, DicomVRType.SQ, false, 0);
               }

               if (item != null)
               {
                  element = ds.GetChildElement(element, true);
                  if (element != null)
                  {
                     element = ds.GetChildElement(element, true);

                     if (element == null)
                     {
                        AddSecheduledProcedureStepSequenceAttributes(ResponseDicomDS, item);
                     }
                     else
                     {
                        while (element != null)
                        {
                           switch (element.Tag)
                           {
                              case DemoDicomTags.ScheduledStationAETitle:
                              case DemoDicomTags.ScheduledProcedureStepStartDate:
                              case DemoDicomTags.ScheduledProcedureStepStartTime:
                              case DemoDicomTags.Modality:
                              case DemoDicomTags.ScheduledPerformingPhysicianName:
                              case DemoDicomTags.ScheduledProcedureStepDescription:
                              case DemoDicomTags.ScheduledProcedureStepLocation:
                              case DemoDicomTags.ScheduledProcedureStepID:
                                 ResponseDicomDS.InsertElement(item, true, element.Tag, DicomVRType.UN, false, 0);
                                 break;
                           }

                           element = ds.GetNextElement(element, true, true);
                        }
                     }
                  }
                  else
                  {
                     AddSecheduledProcedureStepSequenceAttributes(ResponseDicomDS, item);
                  }
               }
            }

            // Requested Procedure
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.RequestedProcedureID);
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.RequestedProcedureDescription);
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.StudyInstanceUID);
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.RequestedProcedurePriority);
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.ReasonForTheRequestedProcedure);

            // Imaging Service Request
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.AccessionNumber);
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.RequestingPhysician);
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.ReferringPhysicianName);

            // Visit Identification
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.AdmissionID);
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.InstitutionName);

            // Patient Identification
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.PatientName);
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.PatientID);

            // Patient Demographic
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.PatientBirthDate);
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.PatientSex);
            Utils.InsertKeyElement(ResponseDicomDS, ds, DemoDicomTags.PatientWeight);

            return ResponseDicomDS;
         }
         catch (Exception ex)
         {
            // Throw the exception and let the calling function handle it.
            throw ex;
         }
      }

      /*
       * Sets a DicomElement that is either a DicomDateValue or DicomTimeValue
       */

      private void SetTimeDateKeyElement(DicomDataSet ResponseDS, DateTime dt, long tag, bool bTimeValue)
      {
         try
         {
            DicomElement element = ResponseDS.FindFirstElement(null, tag, false);
            if (element != null)
            {
               if (bTimeValue)
               {
                  DicomTimeValue[] dtv = new DicomTimeValue[1];
                  dtv[0] = new DicomTimeValue(dt);
                  ResponseDS.SetTimeValue(element, dtv);
               }
               else
               {
                  DicomDateValue[] ddv = new DicomDateValue[1];
                  ddv[0] = new DicomDateValue(dt);
                  ResponseDS.SetDateValue(element, ddv);
               }
            }
         }
         catch (Exception ex)
         {
            server.mf.Log("Error setting time or date element:\r\n\r\n" + ex.ToString());
            return;
         }
      }

      /*
       * Builds a SQL condition for a list of UIDs.
       */

      private string GetUIDCondition(long Tag, string strFieldName)
      {
         string strRetCondition = "";

         try
         {
            DicomElement element = ds.FindFirstElement(null, Tag, false);
            if (element != null)
            {
               string strUID;
               int nUIDsCount = ds.GetElementValueCount(element);

               if (nUIDsCount > 0)
               {
                  strRetCondition += " AND (";

                  for (int i = 0; i < nUIDsCount; i++)
                  {
                     strUID = ds.GetStringValue(element, i);
                     strRetCondition += strFieldName + "='" + strUID + "'";

                     if (i != nUIDsCount - 1)
                        strRetCondition += " OR ";
                  }

                  strRetCondition += ")";
               }
            }
         }
         catch (Exception ex)
         {
            server.mf.Log("Error creating UID condition:\r\n\r\n" + ex.ToString());
            strRetCondition = "";
         }

         return strRetCondition;
      }
   }
}
