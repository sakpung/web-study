// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;

namespace Leadtools.Medical.WebViewer.Jobs
{
   class DicomDataSetAdapter
   {
      public Dicom.DicomDataSet query = new Dicom.DicomDataSet();
      bool _bPatientIDAvailable = false;
      bool _bStudyInstanceUIDAvailable = false;
      bool _bSeriesInstanceUIDAvailable = false;
      bool _bSOPInstanceUIDAvailable = false;
      
      public DicomDataSetAdapter()
      {
         query.Initialize(DicomClassType.Undefined, DicomDataSetInitializeType.ImplicitVRLittleEndian);
      }

      public string PatientID
      {
         set
         {
            if (String.IsNullOrEmpty(value))
            {
               _bPatientIDAvailable = false;
               return;
            }
            _bPatientIDAvailable = true;
            query.InsertElementAndSetValue(DicomTag.PatientID, value);            
         }
      }
      public string StudyInstanceUID
      {
         set
         {
            if (String.IsNullOrEmpty(value))
            {
               _bStudyInstanceUIDAvailable = false;
               return;
            }
            _bStudyInstanceUIDAvailable = true;
            query.InsertElementAndSetValue(DicomTag.StudyInstanceUID, value);            
         }
      }
      public string SeriesInstanceUID
      {
         set
         {
            if (String.IsNullOrEmpty(value))
            {
               _bSeriesInstanceUIDAvailable = false;
               return;
            }
            _bSeriesInstanceUIDAvailable = true;
            query.InsertElementAndSetValue(DicomTag.SeriesInstanceUID, value);            
         }
      }
      public string SOPInstanceUID
      {
         set
         {
            if (String.IsNullOrEmpty(value))
            {
               _bSOPInstanceUIDAvailable = false;
               return;
            }
            _bSOPInstanceUIDAvailable = true;
            query.InsertElementAndSetValue(DicomTag.SOPInstanceUID, value);            
         }
      }

      public void UpdateQueryLevel()
      {
         if (_bSOPInstanceUIDAvailable)
         {
            query.InsertElementAndSetValue(DicomTag.QueryRetrieveLevel, "IMAGE");
         }
         else if(_bSeriesInstanceUIDAvailable)
         {
            query.InsertElementAndSetValue(DicomTag.QueryRetrieveLevel, "SERIES");
         }
         else if(_bStudyInstanceUIDAvailable)
         {
            query.InsertElementAndSetValue(DicomTag.QueryRetrieveLevel, "STUDY");
         }
         else if(_bPatientIDAvailable)
         {
            query.InsertElementAndSetValue(DicomTag.QueryRetrieveLevel, "PATIENT");
         }
         else
         {
            System.Diagnostics.Debug.Assert(false);
            query.InsertElementAndSetValue(DicomTag.QueryRetrieveLevel, "PATIENT");
         }
      }

      public static implicit operator Dicom.DicomDataSet(DicomDataSetAdapter _adapter)
      {
         _adapter.UpdateQueryLevel();
         return _adapter.query;
      }
   }
}
