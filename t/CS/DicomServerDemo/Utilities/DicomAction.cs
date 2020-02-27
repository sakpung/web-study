// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Net;
using System.Data;
using System.Threading;
using System.Collections.Specialized;

using Leadtools;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using Leadtools.DicomDemos.Scu;
using Leadtools.Demos.Database;
using Leadtools.DicomDemos.Scu.CStore;

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
      CStore _store = null ;
      
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

         if(ds != null)
         {
            this.ds.Copy(ds, null, null);
         }
      }

      protected virtual void OnActionComplete( )
      {
         //LastError = e.Error;
         if(ActionComplete != null)
         {
            // Invokes the delegates. 
            ActionComplete(this, new EventArgs());
         }
         
         if ( ds != null ) 
         {
            ds.Dispose ( ) ;
            ds = null ;
         }
      }

      public void DoAction( )
      {
         if(client.Association != null)
         {
            switch(process)
            {
               case ProcessType.EchoRequest:
                  DoEchoRequest();
                  break;
               case ProcessType.StoreRequest:
                  DoStoreRequest();
                  break;
               case ProcessType.FindRequest:
                  DoFindRequest();
                  break;
               case ProcessType.MoveRequest:
                  DoMoveRequest();
                  break;
            }
         }
         OnActionComplete();
      }

      private bool IsActionSupported( )
      {
         byte id;

         if(DicomUidTable.Instance.Find(Class) == null)
         {
            return false;
         }

         id = client.Association.FindAbstract(Class);
         if(id == 0 || client.Association.GetResult(id) !=
            DicomAssociateAcceptResultType.Success)
         {
            return false;
         }

         return true;
      }

      private DicomExceptionCode SaveDataSet(string filename)
      {
         string temp;

         Utils.SetTag(ds, DemoDicomTags.FillerOrderNumberProcedure, "01");

         temp = Utils.GetStringValue(ds, DemoDicomTags.SOPClassUID);
         Utils.SetTag(ds, DemoDicomTags.MediaStorageSOPClassUID, temp);

         temp = Utils.GetStringValue(ds, DemoDicomTags.SOPInstanceUID);
         Utils.SetTag(ds, DemoDicomTags.MediaStorageSOPInstanceUID, temp);

         Utils.SetTag(ds, DemoDicomTags.ImplementationClassUID, client.Association.ImplementClass);

         Utils.SetTag(ds, DemoDicomTags.ImplementationVersionName, client.Association.ImplementationVersionName);

         try
         {
            ds.Save(filename, DicomDataSetSaveFlags.MetaHeaderPresent |
                    DicomDataSetSaveFlags.GroupLengths);
         }
         catch(DicomException de)
         {
            return de.Code;
         }

         return DicomExceptionCode.Success;
      }

      private string GetUIDName( )
      {
         DicomUid uid = DicomUidTable.Instance.Find(Class);

         if(uid == null)
            return Class;

         return uid.Name;
      }

      private void DoEchoRequest( )
      {
         if(!IsActionSupported())
         {
            string name = GetUIDName();

            server.mf.Log("C-ECHO-REQUEST", "Abstract syntax (" + name + ") not supported by association");
            client.SendCEchoResponse(_PresentationID, _MessageID, Class,
                                    DicomCommandStatusType.ClassNotSupported);
            return;
         }

         client.SendCEchoResponse(_PresentationID, MessageID, Class,
                                     DicomCommandStatusType.Success);
         server.mf.Log("C-ECHO-RESPONSE", "Response sent to " + AETitle);
      }

      private void DoStoreRequest( )
      {
         DicomCommandStatusType status = DicomCommandStatusType.ProcessingFailure;
         string msg = "Error saving dataset received from: " + AETitle;
         DicomElement element;

         if(!IsActionSupported())
         {
            string name = GetUIDName();

            server.mf.Log("C-STORE-REQUEST", "Abstract syntax (" + name + ") not supported by association");
            client.SendCStoreResponse(_PresentationID, _MessageID, _Class, _Instance,
                                      DicomCommandStatusType.ClassNotSupported);
            return;
         }

         element = ds.FindFirstElement(null, DemoDicomTags.SOPInstanceUID, true);
         if(element != null)
         {
            string value = ds.GetConvertValue(element);
            string file;
            InsertReturn ret;

            file = server.ImageDir + value + ".dcm";
            ret = server.mf.DicomData.Insert(ds, file);
            switch(ret)
            {
               case InsertReturn.Success:
                  DicomExceptionCode dret = SaveDataSet(file);
                  if(dret == DicomExceptionCode.Success)
                  {
                     status = DicomCommandStatusType.Success;
                  }
                  else
                  {
                     msg = "Error saving dicom file: " + dret.ToString();
                  }
                  server.mf.Log("C-STORE-REQUEST", "New file imported: " + file);
                  break;
               case InsertReturn.Exists:
                  msg = "File (" + file + ") not imported. Record already exists in database";
                  break;
               case InsertReturn.Error:
                  msg = "Error importing file: " + file;
                  break;
            }

         }

         if(status != DicomCommandStatusType.Success)
         {
            server.mf.Log("C-STORE-REQUEST", msg);
         }

         client.SendCStoreResponse(_PresentationID, _MessageID, _Class, _Instance, status);
         server.mf.Log("C-STORE-RESPONSE", "Response sent to " + AETitle);
      }

      private void DoFindRequest( )
      {
         string level;
         string msgTag = "";
         DicomCommandStatusType status;

         if(!IsActionSupported())
         {
            string name = GetUIDName();

            server.mf.Log("C-FIND-REQUEST", "Abstract syntax (" + name + ") not supported by association");
            client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                                     DicomCommandStatusType.ClassNotSupported, null);
            return;
         }

         if(ds == null)
         {
            server.mf.Log("C-FIND-REQUEST", "No dataset provided");
            client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                                              DicomCommandStatusType.InvalidArgumentValue, null);
            return;
         }

         level = Utils.GetStringValue(ds, DemoDicomTags.QueryRetrieveLevel);
         status = AttributeStatus(level, ref msgTag);
         if(status != DicomCommandStatusType.Success)
         {
            server.mf.Log("C-FIND-REQUEST", msgTag);
            client.SendCFindResponse(_PresentationID, _MessageID, _Class, status, null);
            return;
         }

         try
         {
            switch(level)
            {
               case "PATIENT":
                  DoPatientFind();
                  break;
               case "STUDY":
                  DoStudyFind();
                  break;
               case "SERIES":
                  DoSeriesFind();
                  break;
               case "IMAGE":
                  DoFindImage();
                  break;
               default:
                  server.mf.Log("C-FIND-REQUEST", "Invalid query retrieve level: " + level);
                  client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                      DicomCommandStatusType.InvalidAttributeValue, null);
                  break;
            }
         }
         catch(Exception e)
         {
            server.mf.Log("C-FIND-REQUEST", "Processing failure: " + e.Message);
            if ( null != client && client.IsConnected ( ) )
            {
               client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                   DicomCommandStatusType.ProcessingFailure, null);
            }
         }
      }

      private void DoMoveRequest( )
      {
         DicomCommandStatusType status;
         UserInfo ui;
         string level, msgTag = "";

         if(!IsActionSupported())
         {
            string name = GetUIDName();

            server.mf.Log("C-MOVE-REQUEST", "Abstract syntax (" + name + ") not supported by association");
            client.SendCMoveResponse(_PresentationID, _MessageID, _Class,
                                     DicomCommandStatusType.ClassNotSupported, 0, 0, 0, 0, null);
            return;
         }

         ui = server.mf.UsersData.LoadMoveAE(_MoveAETitle);
         if(ui == null)
         {
            server.mf.Log("C-MOVE-REQUEST", string.Format("Move destination [{0}] not found.",_MoveAETitle));
            client.SendCMoveResponse(_PresentationID, _MessageID, _Class,
                                     DicomCommandStatusType.RefusedMoveDestinationUnknown, 0, 0, 0, 0, null);
            return;
         }

         level = Utils.GetStringValue(ds, DemoDicomTags.QueryRetrieveLevel);
         status = AttributeStatus(level, ref msgTag);
         if(status != DicomCommandStatusType.Success)
         {
            server.mf.Log("C-MOVE-REQUEST", msgTag);
            client.SendCMoveResponse(_PresentationID, _MessageID, _Class,
                                     status, 0, 0, 0, 0, null);
            return;
         }

         switch(level)
         {
            case "PATIENT":
               MoveImages(ui, QueryLevel.Patient);
               break;
            case "STUDY":
               MoveImages(ui, QueryLevel.Study);
               break;
            case "SERIES":
               MoveImages(ui, QueryLevel.Series);
               break;
            case "IMAGE":
               MoveImages(ui, QueryLevel.Image);
               break;
            default:
               server.mf.Log("C-MOVE-REQUEST", "Invalid query retrieve level: " + level);
               client.SendCMoveResponse(_PresentationID, _MessageID, _Class,
                                        DicomCommandStatusType.InvalidAttributeValue, 0, 0, 0, 0, null);
               break;
         }
      }

      private DicomCommandStatusType AttributeStatus(string level, ref string msgTag)
      {
         if(level.Length == 0)
         {
            msgTag = "Query Retrieve Level";
            return DicomCommandStatusType.InvalidArgumentValue;
         }

         if(_Class == DicomUidType.PatientRootQueryFind && level != "PATIENT")
         {
            if (!Utils.IsTagPresent(ds, DemoDicomTags.PatientID))
            {
               msgTag = "Patient ID";
               return DicomCommandStatusType.MissingAttribute;
            }

            if (Utils.GetStringValue(ds, DemoDicomTags.PatientID).Length == 0)
            {
               msgTag = "Patient ID missing value";
               return DicomCommandStatusType.MissingAttribute;
            }
         }

         if(level == "STUDY" || level == "SERIES" || level == "IMAGE")
         {
            if (!Utils.IsTagPresent(ds, DemoDicomTags.StudyInstanceUID))
            {
               msgTag = "Study Instance UID";
               return DicomCommandStatusType.MissingAttribute;
            }

            if(level == "SERIES" || level == "IMAGE")
            {
               if (Utils.GetStringValue(ds, DemoDicomTags.StudyInstanceUID).Length == 0)
               {
                  msgTag = "Study Instance UID missing value";
                  return DicomCommandStatusType.MissingAttribute;
               }
            }
         }

         if(level == "SERIES" || level == "IMAGE")
         {
            if (!Utils.IsTagPresent(ds, DemoDicomTags.SeriesInstanceUID))
            {
               msgTag = "Series Instance ID";
               return DicomCommandStatusType.MissingAttribute;
            }
         }

         if(level == "IMAGE")
         {
            if (!Utils.IsTagPresent(ds, DemoDicomTags.SOPInstanceUID))
            {
               msgTag = "SOP Instance ID";
               return DicomCommandStatusType.MissingAttribute;
            }
         }

         return DicomCommandStatusType.Success;
      }

      private void DoPatientFind( )
      {
         DataView dv = null;
         string filter = "PATIENTID LIKE '*'";
         string patientID = Utils.GetStringValue(ds, DemoDicomTags.PatientID);
         string patientName = Utils.GetStringValue(ds, DemoDicomTags.PatientName);
         DicomDataSet rspDs;

         if(patientID.Length > 0)
            filter = "PATIENTID LIKE '" + patientID + "'";
         if(patientName.Length > 0)
         {
            if(filter.Length > 0)
               filter += " AND ";
            filter += "PATIENTNAME LIKE '" + patientName + "'";
         }

         server.mf.Log("DB QUERY", filter);
         dv = server.mf.DicomData.FindRecords("Patients", filter);
         foreach(DataRowView drv in dv)
         {
            DataRow row = drv.Row;

            rspDs = InitResponseDS(QueryLevel.Patient);
            
            Utils.SetKeyElement(rspDs, DemoDicomTags.PatientID, row["PatientID"]);
            if(row["PatientName"] != null)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientName, row["PatientName"]);
            }
            if(row["PatientBirthDate"] != null)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientBirthDate, row["PatientBirthDate"]);
            }
            if(row["PatientBirthTime"] != null)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientBirthTime, row["PatientBirthTime"]);
            }
            if(row["PatientSex"] != null)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientSex, row["PatientSex"]);
            }
            if(row["EthnicGroup"] != null)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.EthnicGroup, row["EthnicGroup"]);
            }
            if(row["PatientComments"] != null)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientComments, row["PatientComments"]);
            }

            int seriesCount = 0;
            int imageCount = 0;

            DataView dvStudies = server.mf.DicomData.FindRecords("Studies", "PatientID = '" + row["PatientID"].ToString() + "'");
            Utils.SetKeyElement(rspDs, DemoDicomTags.NumberOfPatientRelatedStudies, dvStudies.Count);
            foreach(DataRowView drvStudies in dvStudies)
            {
               DataRow rowStudy = drvStudies.Row;
               DataView dvSeries;

               dvSeries = server.mf.DicomData.FindRecords("Series", "StudyInstanceUID = '" + rowStudy["StudyInstanceUID"].ToString() + "'");
               seriesCount += dvSeries.Count;
               foreach(DataRowView drvSeries in dvSeries)
               {
                  DataRow rowSeries = drvSeries.Row;
                  DataView drvImages;

                  drvImages = server.mf.DicomData.FindRecords("Images", "SeriesInstanceUID = '" + rowSeries["SeriesInstanceUID"].ToString() + "'");
                  imageCount += drvImages.Count;
               }
            }
            Utils.SetKeyElement(rspDs, DemoDicomTags.NumberOfPatientRelatedSeries, seriesCount);
            Utils.SetKeyElement(rspDs, DemoDicomTags.NumberOfPatientRelatedInstances, imageCount);

            try
            {
               string file = "";

               client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                                        DicomCommandStatusType.Pending, rspDs);

               if(server.SaveDSSent && !Logger.DisableLogging)
                  file = server.LogDS("C-FIND-RESPONSE", client, rspDs);

               server.mf.Log("C-FIND-RESPONSE", "Response sent to " + _AETitle + " (pending)", file);
            }
            catch
            {
            }
            
            rspDs.Dispose ( ) ;
         }
         client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                                  DicomCommandStatusType.Success, null);
         server.mf.Log("C-FIND-RESPONSE", "Response sent to " + _AETitle + " (final)");
      }

      private void DoStudyFind( )
      {
         DataView dv = null;
         string filter = "";
         string patientID = "", accessionNum, studyID, patientName, referringPhysicianName;
         StringCollection studyInstance;
         DicomDataSet rspDs;
         byte[] studyDate;

         if (Utils.IsTagPresent(ds, DemoDicomTags.PatientID))
         {
            patientID = Utils.GetStringValue(ds, DemoDicomTags.PatientID);            
         }

         //studyTime = Utils.GetTimeValue(ds,"TAG_STUDY_TIME");
         accessionNum = Utils.GetStringValue(ds, DemoDicomTags.AccessionNumber);
         studyID = Utils.GetStringValue(ds, DemoDicomTags.StudyID);
         patientName = Utils.GetStringValue(ds, DemoDicomTags.PatientName);
         referringPhysicianName = Utils.GetStringValue(ds, DemoDicomTags.ReferringPhysicianName);

         if(patientID.Length > 0)
         {
            if(filter.Length > 0)
               filter += " AND ";
            filter += "PatientID = '" + patientID + "'";
         }

         if(patientName.Length > 0)
         {
            if(filter.Length > 0)
               filter += " AND ";
            filter += "PatientName = '" + patientName + "'";
         }

         studyInstance = Utils.GetStringValues(ds, DemoDicomTags.StudyInstanceUID);
         foreach(string instance in studyInstance)
         {
            if(filter.Length > 0)
               filter += " AND ";
            filter += "StudyInstanceUID = '" + instance + "'";
         }

         studyDate = Utils.GetBinaryValues(ds, DemoDicomTags.StudyDate);
         if(studyDate != null && studyDate.Length > 0)
         {
            string date;
            string del = @"\";
            string[] dateArray;

            date = System.Text.ASCIIEncoding.ASCII.GetString(studyDate);

            while(date.IndexOf("\0") != -1)
            {
               date = date.Remove(date.IndexOf("\0"), 1);
            }
            dateArray = date.Split(del.ToCharArray()); 
            for(int i = 0; i<dateArray.Length;i++)
            {
               dateArray[i] = dateArray[i].Replace(" ","");
            }

            if(filter.Length > 0)
               filter += " AND ";
            if(dateArray[0].IndexOf("-") != -1)
            {
               string reqDate;

               // We are working with a date range
               //
               // These are the rules

               //  1. The date inside DICOM is formatted as yyyymmdd so
               //     "19930822" would represent August 22, 1993.
               //  2. A string of the form "<date1> - <date2>" shall match
               //     all occurrences of dates which fall between <date1>
               //     and <date2> inclusive.
               //  3. A string of the form "- <date1>" shall match all occurrences of
               //     dates prior to and including <date1>.
               //  4. A string of the form "<date1> -" shall match all occurrences of
               //     <date1> and subsequent dates.

               if(dateArray[0].Substring(0, 1) == "-")
               {	// If it starts with a '-' then it's an upper range
                  reqDate = dateArray[0].Substring(1);

                  filter += "( StudyDate <= #" + ConvertToQueryDate(reqDate) + "#)";
               }
               else if(dateArray[0].Substring(dateArray[0].Length - 1, 1) == "-")
               {	// If it ends with a '-' then it's the lower range
                  reqDate = dateArray[0].Substring(0, dateArray[0].Length - 1);

                  filter += "( StudyDate >= #" + ConvertToQueryDate(reqDate) + "#)";
               }
               else
               {	// Both dates provided
                  string[] cmpDates = dateArray[0].Split('-');

                  filter += "( StudyDate >= #" + ConvertToQueryDate(cmpDates[0]) + "# AND ";
                  filter += "StudyDate <= #" + ConvertToQueryDate(cmpDates[1]) + "#)";
               }
            }
            else
            {
               filter += "( StudyDate = #" + ConvertToQueryDate(dateArray[0]) + "#)";
            }
         }

         //studyTime = Utils.GetTimeValue(ds,"TAG_STUDY_TIME");

         if(accessionNum.Length > 0)
         {
            if(filter.Length > 0)
               filter += " AND ";
            filter += "AccessionNumber LIKE '" + accessionNum + "'";
         }

         if(studyID.Length > 0)
         {
            if(filter.Length > 0)
               filter += " AND ";
            filter += "StudyID LIKE '" + studyID + "'";
         }

         if (referringPhysicianName.Length > 0)
         {
            if (filter.Length > 0)
               filter += " AND ";
            filter += "ReferringDrName LIKE '" + referringPhysicianName + "'";
         }

         if(filter.Length == 0)
         {
            filter = "STUDYID LIKE '*'";
         }

         server.mf.Log("DB QUERY", filter);
         dv = server.mf.DicomData.FindRecords("Studies", filter);
         foreach(DataRowView drv in dv)
         {
            DataRow row = drv.Row;
            
            rspDs = InitResponseDS(QueryLevel.Study);
            
            if(_Class == DicomUidType.PatientRootQueryFind)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientID, patientID);
            }

            Utils.SetKeyElement(rspDs, DemoDicomTags.StudyInstanceUID, row["StudyInstanceUID"]);

            if(row["StudyDate"] != null)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.StudyDate, row["StudyDate"]);
            }
            if(row["StudyTime"] != null)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.StudyTime, row["StudyTime"]);
            }
            if(row["AccessionNumber"] != null)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.AccessionNumber, row["AccessionNumber"]);
            }
            if(row["StudyID"] != null)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.StudyID, row["StudyID"]);
            }

            if(row["PatientID"] != null)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientID, row["PatientID"]);
            }
            if(row["PatientName"] != null)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientName, row["PatientName"]);
            }

            if (row["ReferringDrName"] != null)
            {
               Utils.SetKeyElement(rspDs, DemoDicomTags.ReferringPhysicianName, row["ReferringDrName"]);
            }

            DataView dvSeries;
            int seriesCount = 0;
            int imageCount = 0;

            dvSeries = server.mf.DicomData.FindRecords("Series", "StudyInstanceUID = '" + row["StudyInstanceUID"].ToString() + "'");
            seriesCount += dvSeries.Count;
            foreach(DataRowView drvSeries in dvSeries)
            {
               DataRow rowSeries = drvSeries.Row;
               DataView drvImages;

               drvImages = server.mf.DicomData.FindRecords("Images", "SeriesInstanceUID = '" + rowSeries["SeriesInstanceUID"].ToString() + "'");
               imageCount += drvImages.Count;
            }

            Utils.SetKeyElement(rspDs, DemoDicomTags.NumberOfStudyRelatedSeries, seriesCount);
            Utils.SetKeyElement(rspDs, DemoDicomTags.NumberOfStudyRelatedInstances, imageCount);

            try
            {
               string file = "";

               client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                                        DicomCommandStatusType.Pending, rspDs);

               if(server.SaveDSSent && !Logger.DisableLogging)
                  file = server.LogDS("C-FIND-RESPONSE", client, rspDs);

               server.mf.Log("C-FIND-RESPONSE", "Response sent to " + _AETitle + " (pending)", file);
            }
            catch
            {
            }
            
            rspDs.Dispose ( ) ;
         }
         client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                                  DicomCommandStatusType.Success, null);
         server.mf.Log("C-FIND-RESPONSE", "Response sent to " + _AETitle + " (final)");
      }

      private void DoSeriesFind( )
      {
         DataView dv = null;
         string filter = "";
         string modality, seriesNumber, patientID, studyInstance;
         StringCollection seriesInstance;
         DicomDataSet rspDS;

         patientID = Utils.GetStringValue(ds, DemoDicomTags.PatientID);
         modality = Utils.GetStringValue(ds, DemoDicomTags.Modality);
         seriesNumber = Utils.GetStringValue(ds, DemoDicomTags.SeriesNumber);
         studyInstance = Utils.GetStringValue(ds, DemoDicomTags.StudyInstanceUID);

         filter = "StudyInstanceUID = '" + studyInstance + "'";

         if(_Class == DicomUidType.PatientRootQueryFind && patientID.Length > 0)
         {
            filter += " AND PatientID = '" + patientID + "'";
         }

         seriesInstance = Utils.GetStringValues(ds, DemoDicomTags.SeriesInstanceUID);
         foreach(string instance in seriesInstance)
         {
            filter += " AND SeriesInstanceUID='" + instance + "'";
         }

         if(modality.Length > 0)
         {
            filter += " AND Modality LIKE '" + modality + "'";
         }

         if(seriesNumber.Length > 0)
         {
            filter += " AND SeriesNumber = " + seriesNumber;
         }

         server.mf.Log("DB QUERY", filter);
         dv = server.mf.DicomData.FindRecords("Series", filter);
         foreach(DataRowView drv in dv)
         {
            DataRow row = drv.Row;

            rspDS = InitResponseDS(QueryLevel.Series);
            
            if(_Class == DicomUidType.PatientRootQueryFind)
            {
               Utils.SetKeyElement(rspDS, DemoDicomTags.PatientID, patientID);
            }
            
            Utils.SetKeyElement(rspDS, DemoDicomTags.StudyInstanceUID, studyInstance);
            
            Utils.SetKeyElement(rspDS, DemoDicomTags.SeriesInstanceUID, row["SeriesInstanceUID"]);

            if(row["Modality"] != null)
            {
               Utils.SetKeyElement(rspDS, DemoDicomTags.Modality, row["Modality"]);
            }

            if(row["SeriesNumber"] != null)
            {
               Utils.SetKeyElement(rspDS, DemoDicomTags.SeriesNumber, row["SeriesNumber"]);
            }

            if (row["SeriesDate"] != null)
            {
               Utils.SetKeyElement(rspDS, DemoDicomTags.SeriesDate, row["SeriesDate"]);
            }

            DataView dvImages;

            dvImages = server.mf.DicomData.FindRecords("Images", "SeriesInstanceUID = '" + row["SeriesInstanceUID"].ToString() + "'");
            if(dvImages!=null)
            {
               Utils.SetKeyElement(rspDS, DemoDicomTags.NumberOfSeriesRelatedInstances, dvImages.Count);
            }            

            try
            {
               string file = "";

               client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                                        DicomCommandStatusType.Pending, rspDS);

               if(server.SaveDSSent && !Logger.DisableLogging)
                  file = server.LogDS("C-FIND-RESPONSE", client, rspDS);

               server.mf.Log("C-FIND-RESPONSE", "Response sent to " + _AETitle + " (pending)", file);
            }
            catch
            {
            }
            
            rspDS.Dispose ( ) ;
         }
         client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                                  DicomCommandStatusType.Success, null);
         server.mf.Log("C-FIND-RESPONSE", "Response sent to " + _AETitle + " (final)");
      }

      private void DoFindImage( )
      {
         DataView dv = null;
         string filter = "";
         DicomDataSet rspDS;
         string studyInstance, patientID, instanceNumber;
         string seriesInstance;
         StringCollection sopInstanceUID;

         studyInstance = Utils.GetStringValue(ds, DemoDicomTags.StudyInstanceUID);
         seriesInstance = Utils.GetStringValue(ds, DemoDicomTags.SeriesInstanceUID);
         patientID = Utils.GetStringValue(ds, DemoDicomTags.PatientID);
         instanceNumber = Utils.GetStringValue(ds, DemoDicomTags.InstanceNumber);

         filter = "StudyInstanceUID = '" + studyInstance + "'";
         filter += " AND SeriesInstanceUID = '" + seriesInstance + "'";

         if(_Class == DicomUidType.PatientRootQueryFind && patientID.Length > 0)
         {
            filter += " AND PatientID = '" + patientID + "'";
         }

         sopInstanceUID = Utils.GetStringValues(ds, DemoDicomTags.SOPInstanceUID);
         foreach(string instance in sopInstanceUID)
         {
            filter += " AND SOPInstanceUID ='" + instance + "'";
         }

         if(instanceNumber.Length > 0)
         {
            filter += " AND InstanceNumber = " + instanceNumber.ToString();
         }

         server.mf.Log("DB QUERY", filter);
         dv = server.mf.DicomData.FindRecords("Images", filter);
         foreach(DataRowView drv in dv)
         {
            DataRow row = drv.Row;

            rspDS = InitResponseDS(QueryLevel.Image);
            
            if(_Class == DicomUidType.PatientRootQueryFind)
            {
               Utils.SetKeyElement(rspDS, DemoDicomTags.PatientID, patientID);
            }
            
            Utils.SetKeyElement(rspDS, DemoDicomTags.SOPInstanceUID, row["SOPInstanceUID"]);

            if(row["InstanceNumber"] != null)
            {
               Utils.SetKeyElement(rspDS, DemoDicomTags.InstanceNumber, row["InstanceNumber"]);
            }

            try
            {
               string file = "";

               client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                                        DicomCommandStatusType.Pending, rspDS);

               if(server.SaveDSSent && !Logger.DisableLogging)
                  file = server.LogDS("C-FIND-RESPONSE", client, rspDS);

               server.mf.Log("C-FIND-RESPONSE", "Response sent to " + _AETitle + " (pending)", file);
            }
            catch
            {
            }
            
            rspDS.Dispose ( ) ;
         }
         client.SendCFindResponse(_PresentationID, _MessageID, _Class,
                                  DicomCommandStatusType.Success, null);
         server.mf.Log("C-FIND-RESPONSE", "Response sent to " + _AETitle + " (final)");
      }

      private string ConvertToQueryDate(string reqDate)
      {
         return reqDate.Substring(4, 2) + "/" + reqDate.Substring(6, 2) + "/" + reqDate.Substring(0, 4);
      }

      private DicomDataSet InitResponseDS(QueryLevel level)
      {
         DicomDataSet rspDs = new DicomDataSet();

         rspDs.Initialize(DicomClassType.Undefined, DicomDataSetInitializeType.ExplicitVRLittleEndian);
         switch(level)
         {
            case QueryLevel.Patient:
               Utils.SetTag(rspDs, DemoDicomTags.QueryRetrieveLevel, "PATIENT");

               // Required Keys
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.PatientName);

               // Optional Keys
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.PatientBirthDate);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.PatientBirthTime);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.PatientSex);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.EthnicGroup);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.PatientComments);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.NumberOfPatientRelatedStudies);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.NumberOfPatientRelatedSeries);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.NumberOfPatientRelatedInstances);
               break;
            case QueryLevel.Study:
               Utils.SetTag(rspDs, DemoDicomTags.QueryRetrieveLevel, "STUDY");

               // Require Keys
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.StudyDate);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.StudyTime);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.AccessionNumber);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.StudyID);

               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.PatientName);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.PatientID);               

               // Optional Keys
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.StudyDescription);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.ReferringPhysicianName);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.NumberOfStudyRelatedSeries);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.NumberOfStudyRelatedInstances);
               break;
            case QueryLevel.Series:
               Utils.SetTag(rspDs, DemoDicomTags.QueryRetrieveLevel, "SERIES");

               // Required Keys
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.Modality);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.SeriesNumber);
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.SeriesDate);               

               // Optional Keys
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.NumberOfSeriesRelatedInstances);
               break;
            case QueryLevel.Image:
               Utils.SetTag(rspDs, DemoDicomTags.QueryRetrieveLevel, "IMAGE");

               // Required Keys
               Utils.InsertKeyElement(rspDs, ds, DemoDicomTags.InstanceNumber);
               break;
         }

         if(_Class == DicomUidType.PatientRootQueryFind && level!=QueryLevel.Study)
         {
            rspDs.InsertElement(null, false, DemoDicomTags.PatientID, DicomVRType.UN, false, 0);
         }

         if(level == QueryLevel.Study || level == QueryLevel.Series ||
            level == QueryLevel.Image)
         {
            rspDs.InsertElement(null, false, DemoDicomTags.StudyInstanceUID, DicomVRType.UN, false, 0);
         }

         if(level == QueryLevel.Series || level == QueryLevel.Image)
         {
            rspDs.InsertElement(null, false, DemoDicomTags.SeriesInstanceUID, DicomVRType.UN, false, 0);
         }

         if(level == QueryLevel.Image)
         {
            rspDs.InsertElement(null, false, DemoDicomTags.SOPInstanceUID, DicomVRType.UN, false, 0);
         }

         return rspDs;
      }

      public void MoveImages(UserInfo ui, QueryLevel level)
      {
         string filter = "";
         StringCollection instanceIds;
         DataView dv;

         if(_Class == DicomUidType.PatientRootQueryFind)
         {
            filter = "PatientID = '" + Utils.GetStringValue(ds, DemoDicomTags.PatientID) + "'";
         }

         if(level == QueryLevel.Study || level == QueryLevel.Series || level == QueryLevel.Image)
         {
            if(filter.Length > 0)
               filter += " AND ";

            if(level != QueryLevel.Study)
               filter += "StudyInstanceUID = '" + Utils.GetStringValue(ds, DemoDicomTags.StudyInstanceUID) + "'";
            else
            {
               instanceIds = Utils.GetStringValues(ds, DemoDicomTags.StudyInstanceUID);
               for(int i = 0; i < instanceIds.Count; i++)
               {
                  filter += "StudyInstanceUID ='" + instanceIds[i] + "'";
                  if(i < instanceIds.Count - 1)
                     filter += " AND ";
               }
            }
         }

         if(level == QueryLevel.Series || level == QueryLevel.Image)
         {
            if(filter.Length > 0)
               filter += " AND ";

            if(level != QueryLevel.Series)
               filter += "SeriesInstanceUID = '" + Utils.GetStringValue(ds, DemoDicomTags.SeriesInstanceUID) + "'";
            else
            {
               instanceIds = Utils.GetStringValues(ds, DemoDicomTags.SeriesInstanceUID);
               for(int i = 0; i < instanceIds.Count; i++)
               {
                  filter += "SeriesInstanceUID ='" + instanceIds[i] + "'";
                  if(i < instanceIds.Count - 1)
                     filter += " AND ";
               }
            }
         }

         if(level == QueryLevel.Image)
         {
            if(filter.Length > 0)
               filter += " AND ";

            instanceIds = Utils.GetStringValues(ds, DemoDicomTags.SOPInstanceUID);
            for(int i = 0; i < instanceIds.Count; i++)
            {
               filter += "SOPInstanceUID ='" + instanceIds[i] + "'";
               if(i < instanceIds.Count - 1)
                  filter += " AND ";
            }
         }

         server.mf.Log("DB QUERY", filter);
         dv = server.mf.DicomData.FindRecords("Images", filter);
         if(dv.Count == 0)
         {
            server.mf.Log("C-MOVE-REQUEST", "No matching images found" + level);
            client.SendCMoveResponse(_PresentationID, _MessageID, _Class,
                DicomCommandStatusType.Success, 0, 0, 0, 0, null);
            return;
         }
         
         DicomServer dcmServer = new DicomServer();
         CStore store = new CStore();

         foreach(DataRowView drv in dv)
         {
            DataRow row = drv.Row;

            store.Files.Add(row["ReferencedFile"].ToString());
         }
         dcmServer.AETitle = ui.AETitle;
         dcmServer.Port = ui.Port;
         dcmServer.Timeout = server.Timeout * 60;
         dcmServer.Address = IPAddress.Parse(ui.IPAddress);
#if (LEADTOOLS_V17_OR_LATER)
         dcmServer.IpType = server.IpType;
#endif

         store.ImplementationClass = "1.2.840.114257.1123456";
         store.ImplementationVersionName = "1";
         store.ProtocolVersion = "1";
         store.Status += new StatusEventHandler(store_Status);
         store.ProgressFiles += new ProgressFilesEventHandler(store_ProgressFiles);
         store.Store(dcmServer, server.CalledAE);
         _store = store ;
      }

      private void store_Status(object sender, StatusEventArgs e)
      {
         string message = "";
         bool done = false;
         DicomCommandStatusType status = DicomCommandStatusType.Success;
         
         if(e.Type == StatusType.Error)
         {
            message = "DICOM error. The process will be terminated! -- Error code is: " + e.Error.ToString();
            done = true;
         }
         else
         {
            switch(e.Type)
            {
               case StatusType.ConnectFailed:
                  message = "Connect operation failed.";
                  done = true;
                  status = DicomCommandStatusType.ProcessingFailure;
                  break;
               case StatusType.ConnectSucceeded:
                  message = "Connected successfully.";
                  message += "  Peer Address:  " + e.PeerIP.ToString();
                  message += "  Peer Port:  " + e.PeerPort.ToString();
                  break;
               case StatusType.SendAssociateRequest:
                  message = "Sending association request...";
                  break;
               case StatusType.ReceiveAssociateAccept:
                  message = "Received Associate Accept.";
                  message += "  Calling AE:  " + e.CallingAE;
                  message += "  Called AE:  " + e.CalledAE;
                  break;
               case StatusType.ReceiveAssociateReject:
                  message = "Received Associate Reject!";
                  done = true;
                  break;
               case StatusType.AbstractSyntaxNotSupported:
                  message = "Abstract Syntax NOT supported!";
                  done = true;
                  break;
               case StatusType.SendCStoreRequest:
                  message = "Sending C-STORE Request...";
                  break;
               case StatusType.ReceiveCStoreResponse:
                  if(e.Error == DicomExceptionCode.Success)
                  {
                     message = "**** Storage completed successfully ****";
                  }
                  else
                  {
                     message = "**** Status code is: " + e.Status.ToString();
                  }
                  break;
               case StatusType.ConnectionClosed:
                  message = "Network Connection closed!";
                  done = true;
                  break;
               case StatusType.ProcessTerminated:
                  message = "Process has been terminated!";
                  done = true;
                  break;
               case StatusType.SendReleaseRequest:
                  message = "Sending release request...";
                  break;
               case StatusType.ReceiveReleaseResponse:
                  message = "Receiving release response";
                  done = true;
                  break;
               case StatusType.Timeout:
                  message = "Communication timeout. Process will be terminated.";
                  done = true;
                  break;
            }
         }

         server.mf.Log("C-STORE-REQUEST", message);

         if(done)
         {
            if (client.IsConnected() && client.Association!=null)
            {
               client.SendCMoveResponse(_PresentationID, _MessageID, _Class, status, 0, 0, 0, 0, null);
            }
             
            if ( null != _store )
            {
               _store.Dispose ( ) ;
               _store = null ;
            }
         }
      }

      public void Close()
      {
          if (_store != null && _store.IsConnected())
              _store.Terminate();
      }

      private void store_ProgressFiles(Object sender, ProgressFilesEventArgs e)
      {
         server.mf.Log("C-STORE-REQUEST", "Processing file: " + e.File.FullName, e.File.FullName);
      }
   }
}
