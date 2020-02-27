// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
namespace Leadtools.Medical.WebViewer.Wado
{
   public class WadoDataSetModel
   {
      public string PatientName { get; set; }
      public string PatientID { get; set; }
      public string PatientSex { get; set; }
      public string PatientBirthDate { get; set; }
      public string StudyDate { get; set; }
      public string AccessionNumber { get; set; }
      public string StudyInstanceUID { get; set; }
      public string StudyDescription { get; set; }
      public string NumberOfSeriesRelatedInstances { get; set; }
      public string NumberOfStudyRelatedSeries { get; set; }
      public string NumberOfStudyRelatedInstances { get; set; }
      public string SeriesDate { get; set; }
      public string Modality { get; set; }
      public string SeriesNumber { get; set; }
      public string SeriesDescription { get; set; }
      public string TransferSyntaxUID { get; set; }
      public string SOPClassUID { get; set; }
      public string SOPInstanceUID { get; set; }
      public string StationName { get; set; }
      public string SeriesInstanceUID { get; set; }
      public string InstanceNumber { get; set; }
      public string NumberOfFrames { get; set; }
      public string NumberOfInstances { get; set; }
   }
}
