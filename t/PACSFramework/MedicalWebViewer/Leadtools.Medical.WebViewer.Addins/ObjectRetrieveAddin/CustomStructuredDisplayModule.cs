// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.Common.DataTypes.StructuredDisplay;
using Leadtools.Dicom;

namespace Leadtools.Medical.WebViewer.Addins
{
    public class CustomStructuredDisplayModule : StructuredDisplayModule
    {
        [Element(DicomTag.ReferencedSeriesSequence)]
        public List<ExtendedReferenceSeries> ReferencedSeriesSequence { get; set; }

        [Element(DicomTag.StudiesContainingOtherReferencedInstancesSequence)]
        public List<OtherStudyReference> StudyContainingOtherReferences { get; set; }

        public void AddReferencedInstance(string sopClassUID, string SOPIntanceUID)
        {
            SopInstanceReference sopRef = new SopInstanceReference();

            sopRef.ReferencedSopClassUid = sopClassUID;
            sopRef.ReferencedSopInstanceUid = SOPIntanceUID;
            if (ReferencedSeriesSequence[0].ReferencedInstanceSequence == null)
                ReferencedSeriesSequence[0].ReferencedInstanceSequence = new List<SopInstanceReference>();

            ReferencedSeriesSequence[0].ReferencedInstanceSequence.Add(sopRef);
        }

        public void AddReferencedImage(string sopClassUID, string SOPIntanceUID)
        {
            SopInstanceReference sopRef = new SopInstanceReference();

            sopRef.ReferencedSopClassUid = sopClassUID;
            sopRef.ReferencedSopInstanceUid = SOPIntanceUID;
            if (ReferencedSeriesSequence[0].ReferencedImageSequence == null)
                ReferencedSeriesSequence[0].ReferencedImageSequence = new List<SopInstanceReference>();

            ReferencedSeriesSequence[0].ReferencedImageSequence.Add(sopRef);
        }

        public CustomStructuredDisplayModule(string referencedSeriesUID) : this()
        {
            ExtendedReferenceSeries rs = new ExtendedReferenceSeries();

            rs.SeriesInstanceUID = referencedSeriesUID;
            ReferencedSeriesSequence.Add(rs);
        }

        public CustomStructuredDisplayModule()
        {
            ReferencedSeriesSequence = new List<ExtendedReferenceSeries>();
            StudyContainingOtherReferences = new List<OtherStudyReference>();
        }
    }

    public class ExtendedSDImageBox : SDImageBox
    {
        [Element(DicomTag.ImageDisplayFormat)]
        public string ImageDisplayFormat { get; set; }
        [Element(DicomTag.Rows)]
        public int? Rows { get; set; }
        [Element(DicomTag.Columns)]
        public int? Columns { get; set; }
    }

    public class ExtendedReferenceSeries : ReferencedSeries
    {
        [Element(DicomTag.ImageBoxNumber)]
        public int? ImageBoxNumber { get; set; }
    }

    public class OtherStudyReference
    {
        [Element(DicomTag.StudyInstanceUID)]
        public string StudyInstanceUID { get; set; }
        [Element(DicomTag.ReferencedSeriesSequence)]
        public List<ExtendedReferenceSeries> ReferencedSeriesSequence { get; set; }
    }

    public class StructuredDisplayImageBoxModuleEx
    {
        private const int tag_ImageBoxSynchronizationSequence = 7472176;

        private List<ExtendedSDImageBox> _StructuredDisplayImageBoxSequence = new List<ExtendedSDImageBox>();
        [Element(DicomTag.StructuredDisplayImageBoxSequence)]
        public List<ExtendedSDImageBox> StructuredDisplayImageBoxSequence
        {
            get { return _StructuredDisplayImageBoxSequence; }
            set { _StructuredDisplayImageBoxSequence = value; }
        }

        private List<ImageBoxSynchronization> _ImageBoxSynchronizationSequence;
        [Element(DicomTag.ImageBoxSynchronizationSequence)]
        public List<ImageBoxSynchronization> ImageBoxSynchronizationSequence
        {
            get { return _ImageBoxSynchronizationSequence; }
            set { _ImageBoxSynchronizationSequence = value; }
        }

        private List<ExtendedReferenceSeries> _ReferencedSeriesSequence = new List<ExtendedReferenceSeries>();
        [Element(DicomTag.ReferencedSeriesSequence)]
        public List<ExtendedReferenceSeries> ReferencedSeriesSequence
        {
            get { return _ReferencedSeriesSequence; }
            set { _ReferencedSeriesSequence = value; }
        }

        private List<OtherStudyReference> _StudiesContainingOtherReferencedInstancesSequence = new List<OtherStudyReference>();
        [Element(DicomTag.StudiesContainingOtherReferencedInstancesSequence)]
        public List<OtherStudyReference> StudyContainingOtherReferences
        {
            get { return _StudiesContainingOtherReferencedInstancesSequence; }
            set { _StudiesContainingOtherReferencedInstancesSequence = value; }
        }

        [Element(DicomTag.ImageDisplayFormat)]
        public string ImageDisplayFormat { get; set; }
    }
}
