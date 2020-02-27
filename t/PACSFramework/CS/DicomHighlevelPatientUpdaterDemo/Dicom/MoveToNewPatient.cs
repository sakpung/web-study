// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.Attributes;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;
using System.ComponentModel;
using Leadtools.Dicom.Common.Editing.Converters;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;

namespace DicomDemo.Dicom
{
   [Instance(DicomClassType.Undefined, NActionScu.PatientUpdateClass)]
   public class MoveToNewPatient : PatientUpdate
   {
      private string _PatientId = string.Empty;

      [Element(DicomTag.PatientID)]
      public string PatientId
      {
         get { return _PatientId; }
         set { _PatientId = value; }
      }

#if (LEADTOOLS_V19_OR_LATER)
      [Element(DicomTag.OtherPatientIDs)]
      public List<string> OtherPatientIds { get; set; }
#endif


      private PersonName _Name = new PersonName();

      [Element(DicomTag.PatientName)]
      [TypeConverter(typeof(PersonNameConverter))]
      public PersonName Name
      {
         get { return _Name; }
         set { _Name = value; }
      }

      private string _Sex;

      [Element(DicomTag.PatientSex)]
      public string Sex
      {
         get { return _Sex; }
         set { _Sex = value; }
      }

      private DateTime? _Birthdate;

      [Element(DicomTag.PatientBirthDate)]
      public DateTime? Birthdate
      {
         get { return _Birthdate; }
         set { _Birthdate = value; }
      }

      private string _StudyInstanceUID;

      [Element(DicomTag.StudyInstanceUID)]
      public string StudyInstanceUID
      {
         get { return _StudyInstanceUID; }
         set { _StudyInstanceUID = value; }
      }

      private List<MergePatientSequence> _PatientToMerge = new List<MergePatientSequence>();

      [Element(DicomTag.ReferencedPatientSequence)]
      public List<MergePatientSequence> PatientToMerge
      {
         get { return _PatientToMerge; }
         set { _PatientToMerge = value; }
      }
   }
}
