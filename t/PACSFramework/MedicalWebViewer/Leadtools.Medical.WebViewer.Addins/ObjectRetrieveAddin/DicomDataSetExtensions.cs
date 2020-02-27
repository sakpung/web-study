// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.DataTypes.StructuredDisplay;
using Leadtools.Dicom.Common.Extensions;
using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.Medical.WebViewer.Addins
{
    public static class DicomDataSetExtensions
    {
        /// <summary>
        /// Creates an xml layout file based on DICOM Structured display.
        /// </summary>
        /// <param name="ds">The ds.</param>
        /// <returns></returns>
        public static Layout ToLayout(this DicomDataSet ds)
        {
            StructuredDisplayImageBoxModule ibModule = new StructuredDisplayImageBoxModule();
            Layout layout = null;

            ds.Get(ibModule);
            if (ibModule != null)
            {
                if (ibModule.StructuredDisplayImageBoxSequence.Count > 0 && ibModule.StructuredDisplayImageBoxSequence != null && ibModule.StructuredDisplayImageBoxSequence.Count > 0)
                {
                    if (!(ibModule.StructuredDisplayImageBoxSequence.Count == 1 && ibModule.StructuredDisplayImageBoxSequence[0].DisplayEnvironmentSpatialPosition == null))
                    {                        
                        layout = new Layout();

                        using (MemoryStream ms = new MemoryStream())
                        {                            
                            layout.Icon = "";
                            layout.Name = "";
                            layout.TemplateId = ds.GetValue<string>(DicomTag.TemplateIdentifier, string.Empty);
                            foreach (SDImageBox box in ibModule.StructuredDisplayImageBoxSequence)
                            {
                                if (box.DisplayEnvironmentSpatialPosition != null && box.DisplayEnvironmentSpatialPosition.Count == 4)
                                {
                                    string referencedSOPInstanceUID = (box.ReferencedImageSequence!=null && box.ReferencedImageSequence.Count > 0) ?
                                        box.ReferencedImageSequence[0].ImageSopInstanceReference.ReferencedSopInstanceUid : string.Empty;
                                    DataContracts.ImageBox imageBox = new DataContracts.ImageBox(referencedSOPInstanceUID);

                                    //
                                    // Top and bottom coordinates need to be switched.  In DICOM the lower left is 0,0 in our viewer the lower left is 1,1
                                    //
                                    
                                    imageBox.Position.leftTop = new LeadPointD(box.DisplayEnvironmentSpatialPosition[0],1 - box.DisplayEnvironmentSpatialPosition[1]);
                                    imageBox.Position.rightBottom = new LeadPointD(box.DisplayEnvironmentSpatialPosition[2], 1 - box.DisplayEnvironmentSpatialPosition[3]);
                                    layout.Boxes.Add(imageBox);
                                }
                            }
                        }
                    }
                }
            }            
            return layout;
        }

        public static StudyLayout ToStudyLayout(this DicomDataSet ds)
        {
            StructuredDisplayImageBoxModuleEx ibModule = new StructuredDisplayImageBoxModuleEx();
            StudyLayout layout = null;
            Dictionary<string, string> mappedSeries = new Dictionary<string, string>();

            ds.Get(ibModule); 
            if (ibModule != null)
            {
                var studyIntanceUID = ds.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty);

                layout = new StudyLayout();

                DateTime dateTime = DateTime.Parse(ds.GetValue<string>(DicomTag.SeriesDate, string.Empty) + " " + ds.GetValue<string>(DicomTag.SeriesTime, string.Empty));

                layout.Name = dateTime.ToString("G");

                if (!string.IsNullOrEmpty(ibModule.ImageDisplayFormat))
                {
                    string data = ibModule.ImageDisplayFormat.Replace(@"STANDARD\", "");
                    string[] info = data.Split(',');

                    if(info.Count() >= 2)
                    {
                        layout.Columns = Convert.ToInt32(info[0]);
                        layout.Rows = Convert.ToInt32(info[1]);
                    }
                } 
                
                foreach(ExtendedReferenceSeries series in ibModule.ReferencedSeriesSequence)
                {
                    SeriesInfo info = new SeriesInfo();

                    if (series.ImageBoxNumber.HasValue)
                        info.ImageBoxNumber = series.ImageBoxNumber.Value;                 
                    info.SeriesInstanceUID = series.SeriesInstanceUID;
                    info.StudyInstanceUID = ds.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty);
                    layout.Series.Add(info);
                } 
                
                foreach(OtherStudyReference studyReference in ibModule.StudyContainingOtherReferences)
                {
                    OtherStudies study = new OtherStudies();

                    study.StudyInstanceUID = studyReference.StudyInstanceUID;
                    foreach (ExtendedReferenceSeries series in studyReference.ReferencedSeriesSequence)
                    {
                        SeriesInfo info = new SeriesInfo();

                        if (series.ImageBoxNumber.HasValue)
                            info.ImageBoxNumber = series.ImageBoxNumber.Value;
                        info.SeriesInstanceUID = series.SeriesInstanceUID;
                        info.StudyInstanceUID = studyReference.StudyInstanceUID;
                        study.Series.Add(info);
                    }
                    layout.OtherStudies.Add(study);
                }          

                if (ibModule.StructuredDisplayImageBoxSequence.Count > 0 && ibModule.StructuredDisplayImageBoxSequence != null && ibModule.StructuredDisplayImageBoxSequence.Count > 0)
                {
                    if (!(ibModule.StructuredDisplayImageBoxSequence.Count == 1 && ibModule.StructuredDisplayImageBoxSequence[0].DisplayEnvironmentSpatialPosition == null))
                    {    
                        ibModule.StructuredDisplayImageBoxSequence.Reverse();                   
                        foreach (ExtendedSDImageBox box in ibModule.StructuredDisplayImageBoxSequence)
                        {                                
                            if (box.DisplayEnvironmentSpatialPosition != null && box.DisplayEnvironmentSpatialPosition.Count == 4)
                            {
                                string referencedSOPInstanceUID = (box.ReferencedImageSequence != null && box.ReferencedImageSequence.Count > 0) ?
                                    box.ReferencedImageSequence[0].ImageSopInstanceReference.ReferencedSopInstanceUid : string.Empty;
                                DataContracts.ImageBox imageBox = new DataContracts.ImageBox(referencedSOPInstanceUID);                                
                                //
                                // Top and bottom coordinates need to be switched.  In DICOM the lower left is 0,0 in our viewer the lower left is 1,1
                                //

                                imageBox.Position.leftTop = new LeadPointD(box.DisplayEnvironmentSpatialPosition[0], 1 - box.DisplayEnvironmentSpatialPosition[1]);
                                imageBox.Position.rightBottom = new LeadPointD(box.DisplayEnvironmentSpatialPosition[2], 1 - box.DisplayEnvironmentSpatialPosition[3]);

                               if(box.ImageBoxLayoutType.HasValue)
                                   imageBox.ImageBoxLayoutType = box.ImageBoxLayoutType.Value;

                                if (box.ImageBoxNumber.HasValue)
                                    imageBox.ImageBoxNumber = box.ImageBoxNumber.Value;                                

                                if (box.ReferencedFirstFrameSequence!= null && box.ReferencedFirstFrameSequence.Count > 0)
                                {
                                    ImageSopInstanceReference imgSopRef = box.ReferencedFirstFrameSequence[0];

                                    imageBox.FirstFrame = new FirstFrame();
                                    imageBox.FirstFrame.SOPClassUID = imgSopRef.ReferencedSopClassUid;
                                    imageBox.FirstFrame.SOPInstanceUID = imgSopRef.ReferencedSopInstanceUid;
                                    if (imgSopRef.ReferencedFrameNumber != null && imgSopRef.ReferencedFrameNumber.Count > 0)
                                        imageBox.FirstFrame.FrameNumber = imgSopRef.ReferencedFrameNumber[0];
                                }

                                if (!string.IsNullOrEmpty(box.ImageDisplayFormat))
                                {
                                    string data = box.ImageDisplayFormat.Replace(@"STANDARD\", "");
                                    string[] info = data.Split(',');

                                    if (info.Count() >= 2)
                                    {
                                        imageBox.ColumnPosition = Convert.ToInt32(info[0]);
                                        imageBox.RowPosition = Convert.ToInt32(info[1]);
                                        imageBox.NumberOfRows = box.Rows.Value;
                                        imageBox.NumberOfColumns = box.Columns.Value;
                                    }
                                }

                                if(box.ReferencedPresentationStateSequence!=null && box.ReferencedPresentationStateSequence.Count > 0)
                                {
                                    SopInstanceReference refPS = box.ReferencedPresentationStateSequence[0];

                                    imageBox.ReferencedPresentationStateSOP = refPS.ReferencedSopInstanceUid;
                                }

                                if (box.DisplaySetHorizontalJustification.HasValue)
                                    imageBox.HorizontalJustification = box.DisplaySetHorizontalJustification.Value;

                                if (box.DisplaySetVerticalJustification.HasValue)
                                    imageBox.VerticalJustification = box.DisplaySetVerticalJustification.Value;

                                if (box.ImageBoxTileHorizontalDimension.HasValue)
                                   imageBox.ImageBoxTileHorizontalDimension = box.ImageBoxTileHorizontalDimension.Value;

                                if (box.ImageBoxTileVerticalDimension.HasValue)
                                   imageBox.ImageBoxTileVerticalDimension = box.ImageBoxTileVerticalDimension.Value;

                                layout.Boxes.Add(imageBox);                                
                            }
                        }                        
                    }
                }
            }            
            return layout;
        }

        public static MemoryStream ToStream(this DicomDataSet dataset)
        {
            string strTempFile;
            MemoryStream stream = new MemoryStream();

            strTempFile = Path.GetTempFileName();
            try
            {
                byte[] data = null;

                dataset.Save(strTempFile, DicomDataSetSaveFlags.None);

                data = File.ReadAllBytes(strTempFile);
                stream.Write(data, 0, data.Length);
            }
            finally
            {
                if (File.Exists(strTempFile))
                {
                    File.Delete(strTempFile);
                }
            }
            stream.Position = 0;
            return stream;
        }

        public static void RemoveTag(this DicomDataSet ds, long tag)
        {
            DicomElement element = ds.FindFirstElement(null, tag, false);

            if (element != null)
                ds.DeleteElement(element);
        }
    }
}
