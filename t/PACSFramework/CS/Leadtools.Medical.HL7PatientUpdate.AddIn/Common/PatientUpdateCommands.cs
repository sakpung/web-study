using Leadtools.Dicom;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadtools.Medical.HL7PatientUpdate.AddIn
{
   public static class PatientUpdateCommandsFactory
   {
      public static IPatientUpdateCommand MapHL7ToPatientUpdateCommand(IHL7MessageAdapter hl7)
      {
         var updateType = hl7.UpdateType;

         if (updateType == UpdateType.PatientUpdate ||
            updateType == UpdateType.PatientUpdatePatientSpecific ||
            updateType == UpdateType.PatientUpdateVisitSpecific ||
            updateType == UpdateType.ScheduleAppointment ||
            updateType == UpdateType.CheckInPatient ||
            updateType == UpdateType.CheckOutPatient)
         {
            var update = new UpdatePatient(hl7.getChangePatient());
            return update;
         }
         else if (updateType == UpdateType.PatientMerge)
         {
            var merge = new MergePatient(hl7.getMergePatient());
            var updateAttempt1 = new UpdatePatient(hl7.getChangePatient());
            var updateAttempt2 = new UpdatePatient(hl7.getChangePatientFromMrg());

            var cmd = (new CompositeContinueOnErrorCommand()).Add(merge).Add(updateAttempt1).Add(updateAttempt2);

            return cmd;
         }
         else if (updateType == UpdateType.NewPatient)
         {
            var update = new NewPatient(hl7.getChangePatient());
            return update;
         }
         else
         {
            throw new Exception("The requested update type is not supported.");
         }
      }
   }

   public interface IPatientUpdateCommand
   {
      void Execute();
      string Desc();      
   }

   internal class CompositeContinueOnErrorCommand : IPatientUpdateCommand
   {
      List<IPatientUpdateCommand> _lst = new List<IPatientUpdateCommand>();
      
      public CompositeContinueOnErrorCommand Add(IPatientUpdateCommand cmd)
      {
         _lst.Add(cmd);
         return this;
      }
      
      public void Execute()
      {
         var sb = new StringBuilder();
         var success = false;
         var failure = false;

         foreach (var cmd in _lst)
         {
            try
            {
               cmd.Execute();
               success = true;
            }
            catch(Exception ex)
            {
               failure = true;
               sb.Append(ex.Message);
               sb.Append(", ");
            }
         }

         if(failure && !success)
         {
            throw new Exception(sb.ToString());
         }
         else if(failure)
         {
            Logger.Global.Log("HL7PatientUpdate", null, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now, LogType.Debug, MessageDirection.None,
               "Partial failure: " + sb.ToString(), null, null);
         }
      }

      public string Desc()
      {
         var sb = new StringBuilder();
         foreach (var cmd in _lst)
         {
            sb.Append(cmd.Desc());
            sb.Append(",");
         }
         sb.Remove(sb.Length - 1, 1);
         return sb.ToString();
      }
   }

   internal class UpdatePatient : IPatientUpdateCommand
   {
      private Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangePatient _change = null;
      public UpdatePatient(Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangePatient change)
      {
         _change = change;
      }

      public void Execute()
      {
         Guard.ArgumentNotNull(_change, "_change");

         Guard.ArgumentNotNull(_change.OriginalPatientId, "_change.OriginalPatientId");
         Guard.ArgumentNotNull(_change.PatientId, "_change.PatientId");
         Guard.ArgumentNotNull(_change.Name, "_change.Name");
         Guard.ArgumentNotNull(_change.Name.FullDicomEncoded, "_change.Name.FullDicomEncoded");
         Guard.ArgumentNotNull(_change.Sex, "_change.Sex");

         NActionClient.ChangePatient(_change, _change.Operator);
      }

      public string Desc()
      {
         return GetType().Name;
      }
   }

   internal class MergePatient : IPatientUpdateCommand
   {
      private Leadtools.Dicom.Common.DataTypes.PatientUpdater.MergePatient _merge = null;
      public MergePatient(Leadtools.Dicom.Common.DataTypes.PatientUpdater.MergePatient merge)
      {
         _merge = merge;
      }
      public void Execute()
      {
         Guard.ArgumentNotNull(_merge, "_merge");

         Guard.ArgumentNotNull(_merge.PatientId, "_merge.PatientId");
         Guard.ArgumentNotNull(_merge.PatientToMerge, "_merge.PatientToMerge");
         Guard.ArgumentNotNull(_merge.PatientToMerge[0].PatientId, "_merge.PatientToMerge[0].PatientId");

         NActionClient.MergePatient(_merge, _merge.Operator);
      }

      public string Desc()
      {
         return GetType().Name;
      }
   }

   /// <summary>
   /// The concept of having new patient added without any study or series is not supported in the PACS server
   /// New here means create a new patient record from an existing patient's record
   /// </summary>
   internal class NewPatient : IPatientUpdateCommand
   {
      private Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangePatient _change = null;
      public NewPatient(Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangePatient change)
      {
         _change = change;
      }

      public void Execute()
      {
         try
         {
            Guard.ArgumentNotNull(_change, "_change");

            Guard.ArgumentNotNull(_change.OriginalPatientId, "_change.OriginalPatientId");
            Guard.ArgumentNotNull(_change.PatientId, "_change.PatientId");
            Guard.ArgumentNotNull(_change.Name, "_change.Name");
            Guard.ArgumentNotNull(_change.Name.FullDicomEncoded, "_change.Name.FullDicomEncoded");
            Guard.ArgumentNotNull(_change.Sex, "_change.Sex");

            NActionClient.ChangePatient(_change, _change.Operator);
         }
         catch(Exception ex)
         {
            //if status == DicomCommandStatusType.AttributeOutOfRange;
            //error message = "Original Patient ID does not exist in database";
            if (ex.Message.ToLower().Contains("attributeoutofrange"))
            {
               throw new Exception("Original Patient ID does not exist in database");
            }
            throw;
         }
      }

      public string Desc()
      {
         return GetType().Name;
      }
   }
}
