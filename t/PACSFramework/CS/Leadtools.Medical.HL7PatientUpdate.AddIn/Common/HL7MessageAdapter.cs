using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using Leadtools.Medical.HL7.V2x.Models;
using System;
using System.Collections.Generic;

namespace Leadtools.Medical.HL7PatientUpdate.AddIn
{
   public enum UpdateType
   {
      Unknown,
      NewPatient, //A28
      PatientUpdate, //A31
      PatientUpdatePatientSpecific, //A31
      PatientUpdateVisitSpecific, //A08
      ScheduleAppointment, //A05
      CheckInPatient, //A04
      CheckOutPatient, //A03
      PatientMerge //A40
   };
   public static class HL7MessageAdapterFactory
   {
      private static readonly Dictionary<string, UpdateType> _nameUpdateType = new Dictionary<string, UpdateType>
      {
         {"ORM_O01", UpdateType.PatientUpdate },
         {"ADT_A01", UpdateType.PatientUpdate },

         //{"ADT_A28", UpdateType.NewPatient },
         // This is not enabled by default, it can be misleading
         // The concept of having new patient added without any study or series is not supported in the PACS server
         // "New" here means: create a new patient record from an existing patient's record
   
         {"ADT_A31", UpdateType.PatientUpdatePatientSpecific },
         {"ADT_A08", UpdateType.PatientUpdateVisitSpecific },
         {"ADT_A05", UpdateType.ScheduleAppointment },
         {"ADT_A04", UpdateType.CheckInPatient },
         {"ADT_A03", UpdateType.CheckOutPatient },
         {"ADT_A40", UpdateType.PatientMerge },
      };

      public static IHL7MessageAdapter Create(string name, List<Segment> segments)
      {
         if(_nameUpdateType.ContainsKey(name))
         {
            return new GenericHL7MessageAdapter(segments, _nameUpdateType[name]);
         }
         else
         {
            throw new Exception("HL7 message is not supported.");
         }
      }
   }
   public interface IHL7MessageAdapter
   {
      Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangePatient getChangePatient();
      Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangePatient getChangePatientFromMrg();
      Leadtools.Dicom.Common.DataTypes.PatientUpdater.MergePatient getMergePatient();
      UpdateType UpdateType { get; set; }
   }


   /// <summary>
   /// 
   /// </summary>
   internal class GenericHL7MessageAdapter : IHL7MessageAdapter
   {
      private HL7SegmentsAdapter _adapter = null;

      private Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangePatient _change = null;
      private Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangePatient _changeMrg = null;
      private Leadtools.Dicom.Common.DataTypes.PatientUpdater.MergePatient _merge = null;

      public UpdateType UpdateType { get; set; } = UpdateType.Unknown;
            
      public GenericHL7MessageAdapter(List<Segment> segments, UpdateType updateType)
      {
         _adapter = new HL7SegmentsAdapter(segments);
         UpdateType = updateType;
      }

      public void Validate()
      {
      }

      public Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangePatient getChangePatientFromMrg()
      {
         if (_changeMrg == null)
         {
            _changeMrg = new Dicom.Common.DataTypes.PatientUpdater.ChangePatient();

            //transaction info
            _changeMrg.Description = _adapter.DG1?.Diagnosis_Description.Read();
            _changeMrg.Reason = _adapter.EVN?.Event_Reason_Code.Read();
            _changeMrg.Operator = _adapter.MSH?.Sending_Application.Read();
            _changeMrg.Station = _adapter.MSH?.Sending_Facility.Read();
            _changeMrg.Date = DateTime.Now;//LTConvert.ToDateTime(_adapter.MSH?.Date_Time_of_Message?.Month, _adapter.MSH?.Date_Time_of_Message?.Day, _adapter.MSH?.Date_Time_of_Message?.Year);
            _changeMrg.Time = DateTime.Now;//LTConvert.ToDateTime(_adapter.MSH?.Date_Time_of_Message?.Month, _adapter.MSH?.Date_Time_of_Message?.Day, _adapter.MSH?.Date_Time_of_Message?.Year);
            _changeMrg.TransactionID = _adapter.MSH?.Message_Control_ID.Read();

            //patient - original             
            _changeMrg.OriginalPatientId = DicomValidation.FixText(_adapter.MRG?.Prior_Patient_Identifier_List?[0]?.IDNumber.Read());
            if (string.IsNullOrEmpty(_changeMrg.OriginalPatientId))
            {
               _changeMrg.OriginalPatientId = DicomValidation.FixText(_adapter.MRG?.Prior_Patient_ID?.IDNumber.Read());
            }

            //patient - updated
            _changeMrg.PatientId = DicomValidation.FixText(_adapter.PID?.Patient_Identifier_List?[0]?.IDNumber.Read());
            if (string.IsNullOrEmpty(_changeMrg.PatientId))
            {
               _changeMrg.PatientId = DicomValidation.FixText(_adapter.PID?.Patient_ID?.IDNumber.Read());
            }
            _changeMrg.Name = new Dicom.Common.DataTypes.PersonName()
            {
               Family = DicomValidation.FixText(_adapter.PID?.Patient_Name?[0]?.FamilyName.Surname.Read()),
               Given = DicomValidation.FixText(_adapter.PID?.Patient_Name?[0]?.GivenName.Read()),
               Middle = DicomValidation.FixText(_adapter.PID?.Patient_Name?[0]?.SecondAndFurtherGivenNamesOrInitialsThereof.Read()),
               Prefix = DicomValidation.FixText(_adapter.PID?.Patient_Name?[0]?.PrefixEgDR.Read()),
               Suffix = DicomValidation.FixText(_adapter.PID?.Patient_Name?[0]?.SuffixEgJRorIII.Read()),
            };
            _changeMrg.Sex = _adapter.PID?.Administrative_Sex.Read();
            if (!DicomValidation.IsValidPatientSex(_changeMrg.Sex)) _changeMrg.Sex = null;
            _changeMrg.Birthdate = LTConvert.ToDateTime(_adapter.PID?.Date_Time_of_Birth?.Month, _adapter.PID?.Date_Time_of_Birth?.Day, _adapter.PID?.Date_Time_of_Birth?.Year);
            _changeMrg.PatientComments = _adapter.Zxx?.Field_2.Read();
            _changeMrg.EthnicGroup = _adapter.PID?.Race.Read();
            //_changeMrg.OtherPatientIdsSequence          
            //_changeMrg.ReferencedStudySequence 

            DefaultValuesProvider.Visit(_changeMrg);
         }
         return _changeMrg;
      }
      
      public Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangePatient getChangePatient()
      {
         if(_change==null)
         {
            _change = new Dicom.Common.DataTypes.PatientUpdater.ChangePatient();

            //transaction info
            _change.Description = _adapter.DG1?.Diagnosis_Description.Read();
            _change.Reason = _adapter.EVN?.Event_Reason_Code.Read();
            _change.Operator = _adapter.MSH?.Sending_Application.Read();
            _change.Station = _adapter.MSH?.Sending_Facility.Read();
            _change.Date = DateTime.Now;//LTConvert.ToDateTime(_adapter.MSH?.Date_Time_of_Message?.Month, _adapter.MSH?.Date_Time_of_Message?.Day, _adapter.MSH?.Date_Time_of_Message?.Year);
            _change.Time = DateTime.Now;//LTConvert.ToDateTime(_adapter.MSH?.Date_Time_of_Message?.Month, _adapter.MSH?.Date_Time_of_Message?.Day, _adapter.MSH?.Date_Time_of_Message?.Year);
            _change.TransactionID = _adapter.MSH?.Message_Control_ID.Read();

            //patient - original 
            _change.OriginalPatientId = DicomValidation.FixText(_adapter.PID?.Patient_Identifier_List?[0]?.IDNumber.Read());
            if (string.IsNullOrEmpty(_change.OriginalPatientId))
            {
               _change.OriginalPatientId = DicomValidation.FixText(_adapter.PID?.Patient_ID?.IDNumber.Read());
            }

            //patient - updated
            _change.PatientId = DicomValidation.FixText( _adapter.PID?.Patient_Identifier_List?[0]?.IDNumber.Read() );
            if (string.IsNullOrEmpty(_change.PatientId))
            {
               _change.PatientId = DicomValidation.FixText(_adapter.PID?.Patient_ID?.IDNumber.Read() );
            }
            _change.Name = new Dicom.Common.DataTypes.PersonName()
            {
               Family = DicomValidation.FixText(_adapter.PID?.Patient_Name?[0]?.FamilyName.Surname.Read()),
               Given = DicomValidation.FixText(_adapter.PID?.Patient_Name?[0]?.GivenName.Read()),
               Middle = DicomValidation.FixText(_adapter.PID?.Patient_Name?[0]?.SecondAndFurtherGivenNamesOrInitialsThereof.Read()),
               Prefix = DicomValidation.FixText(_adapter.PID?.Patient_Name?[0]?.PrefixEgDR.Read()),
               Suffix = DicomValidation.FixText(_adapter.PID?.Patient_Name?[0]?.SuffixEgJRorIII.Read()),
            };
            _change.Sex = _adapter.PID?.Administrative_Sex.Read();
            if (!DicomValidation.IsValidPatientSex(_change.Sex)) _change.Sex = null;
            _change.Birthdate = LTConvert.ToDateTime(_adapter.PID?.Date_Time_of_Birth?.Month, _adapter.PID?.Date_Time_of_Birth?.Day, _adapter.PID?.Date_Time_of_Birth?.Year);
            _change.PatientComments = _adapter.Zxx?.Field_2.Read();
            _change.EthnicGroup = _adapter.PID?.Race.Read();
            //_change.OtherPatientIdsSequence          
            //_change.ReferencedStudySequence 
            
            DefaultValuesProvider.Visit(_change);
         }
         return _change;
      }
      public Leadtools.Dicom.Common.DataTypes.PatientUpdater.MergePatient getMergePatient()
      {
         if (_merge == null)
         {
            _merge = new Dicom.Common.DataTypes.PatientUpdater.MergePatient();

            _merge.Description = _adapter.DG1?.Diagnosis_Description.Read();
            _merge.Reason = _adapter.EVN?.Event_Reason_Code.Read();
            _merge.Operator = _adapter.MSH?.Sending_Application.Read();
            _merge.Station = _adapter.MSH?.Sending_Facility.Read();
            _merge.Date = DateTime.Now; //LTConvert.ToDateTime(_adapter.MSH?.Date_Time_of_Message?.Month, _adapter.MSH?.Date_Time_of_Message?.Day, _adapter.MSH?.Date_Time_of_Message?.Year);
            _merge.Time = DateTime.Now; //LTConvert.ToDateTime(_adapter.MSH?.Date_Time_of_Message?.Month, _adapter.MSH?.Date_Time_of_Message?.Day, _adapter.MSH?.Date_Time_of_Message?.Year);
            _merge.TransactionID = _adapter.MSH?.Message_Control_ID.Read();

            //patient - updated
            _merge.PatientId = DicomValidation.FixText(_adapter.PID?.Patient_Identifier_List?[0]?.IDNumber.Read());
            if (string.IsNullOrEmpty(_merge.PatientId))
            {
               _merge.PatientId = DicomValidation.FixText(_adapter.PID?.Patient_ID?.IDNumber.Read());
            }

            //patient to merge
            var mergePatientId = DicomValidation.FixText(_adapter.MRG?.Prior_Patient_Identifier_List?[0]?.IDNumber.Read());
            if (string.IsNullOrEmpty(mergePatientId))
            {
               mergePatientId = DicomValidation.FixText(_adapter.MRG?.Prior_Patient_ID?.IDNumber.Read());
            }
            if (!string.IsNullOrEmpty(mergePatientId))
            {
               _merge.PatientToMerge = new List<MergePatientSequence>() { new MergePatientSequence(mergePatientId) };
            }
            //_merge.ReferencedStudySequence 

            DefaultValuesProvider.Visit(_merge);
         }
         return _merge;
      }
   }

   
}
