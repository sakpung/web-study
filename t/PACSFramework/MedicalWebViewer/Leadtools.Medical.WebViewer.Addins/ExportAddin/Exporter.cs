// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Dicom;
using Leadtools.Codecs;
using System.IO;
using Leadtools.ImageProcessing;
using Leadtools.Annotations;
using System.Drawing;
using Leadtools.Drawing;
using System.Xml.Serialization;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom.Common.DataTypes;
using System.Data;
using Leadtools.Medical.WebViewer.Addins.Common;

namespace Leadtools.Medical.WebViewer.DataContracts
{
    public class Exporter
    {
        private IStorageDataAccessAgent _DataAccessAgent;

        #region Public

        #region Methods

        public Exporter(IStorageDataAccessAgent accessAgent)
        {
            _DataAccessAgent = accessAgent;
        }

        public List<SeriesImage> GetAllPatientImages(string patientID)
        {
            List<SeriesImage> seriesImages;
            DataSet instances;


            seriesImages = new List<SeriesImage>();
            instances = QueryCurrentPatient(patientID);

            foreach (DataRow row in instances.Tables[DataTableHelper.InstanceTableName].Rows)
            {
                
                RasterImage image;
                string referencedFile = row.Field<string>("ReferencedFile");

                using (var dicomDs = new DicomDataSet())
                {
                   dicomDs.Load(referencedFile, DicomDataSetLoadFlags.None);
                   double xDpi=0;
                   double yDpi=0;
                   AddInsUtils.GetDpi(dicomDs, out xDpi, out yDpi);
                   image = GetImage(dicomDs);
                   if (image != null)
                   {
                      string seriesIntanceUID = dicomDs.GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);
                      string sopInstanceUID = dicomDs.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
                      SeriesImage si = new SeriesImage(seriesIntanceUID, sopInstanceUID, image, xDpi, yDpi);

                      seriesImages.Add(si);
                   }
                }
            }
            return seriesImages;
        }

        public List<DicomDataSet> GetAllPatientDataSets(string patientID)
        {
            List<DicomDataSet> dataSets;
            DataSet instances;

            dataSets = new List<DicomDataSet>();
            instances = QueryCurrentPatient(patientID);

            foreach (DataRow row in instances.Tables[DataTableHelper.InstanceTableName].Rows)
            {
                DicomDataSet ds = new DicomDataSet();
                string referencedFile = row.Field<string>("ReferencedFile");

                ds.Load(referencedFile, DicomDataSetLoadFlags.None);

                dataSets.Add(ds);
            }

            return dataSets;
        }

        public List<SeriesImage> GetInstanceImages(string[] instanceUIDs)
        {
            DataSet instances;
            List<SeriesImage> seriesImages = new List<SeriesImage>();

            instances = QueryInstances(instanceUIDs);
            foreach (DataRow row in instances.Tables[DataTableHelper.InstanceTableName].Rows)
            {
                string referencedFile = row.Field<string>("ReferencedFile");

                using (DicomDataSet dicomDs = new DicomDataSet())
                {
                    RasterImage image;

                    dicomDs.Load(referencedFile, DicomDataSetLoadFlags.None);
                    image = GetImage(dicomDs);
                    if (image != null)
                    {
                        string seriesIntanceUID = dicomDs.GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);
                        string sopInstanceUID = dicomDs.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
                        SeriesImage si = new SeriesImage(seriesIntanceUID, sopInstanceUID, image);

                        seriesImages.Add(si);
                    }
                }
            }

            return seriesImages;
        }

        public List<DicomDataSet> GetInstanceDatasets(string[] instanceUIDs)
        {
            DataSet instances;
            List<DicomDataSet> dataSets = new List<DicomDataSet>();

            instances = QueryInstances(instanceUIDs);
            foreach (DataRow row in instances.Tables[DataTableHelper.InstanceTableName].Rows)
            {
                DicomDataSet ds = new DicomDataSet();
                string referencedFile = row.Field<string>("ReferencedFile");

                ds.Load(referencedFile, DicomDataSetLoadFlags.None);
                dataSets.Add(ds);
            }

            return dataSets;
        }

        public List<SeriesImage> GetSeriesImages(string[] instanceUIDs)
        {
            DataSet instances;
            List<SeriesImage> seriesImages = new List<SeriesImage>();

            instances = QuerySeries(instanceUIDs);
            foreach (DataRow row in instances.Tables[DataTableHelper.InstanceTableName].Rows)
            {
                string referencedFile = row.Field<string>("ReferencedFile");

                using (DicomDataSet dicomDs = new DicomDataSet())
                {
                    RasterImage image = null;

                    dicomDs.Load(referencedFile, DicomDataSetLoadFlags.None);
                    image = GetImage(dicomDs);
                    if (image != null)
                    {
                        string seriesIntanceUID = dicomDs.GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);
                        string sopInstanceUID = dicomDs.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
                        SeriesImage si = new SeriesImage(seriesIntanceUID, sopInstanceUID, image);

                        seriesImages.Add(si);
                    }
                }
            }

            return seriesImages;
        }

        public Dictionary<string,DicomDataSet> GetSeriesDatasets(string[] instanceUIDs)
        {
            DataSet instances;
            Dictionary<string,DicomDataSet> dataSets = new Dictionary<string, DicomDataSet>();

            instances = QuerySeries(instanceUIDs);
            foreach (DataRow row in instances.Tables[DataTableHelper.InstanceTableName].Rows)
            {
                DicomDataSet ds = new DicomDataSet();
                string referencedFile = row.Field<string>("ReferencedFile");
                string key;

                ds.Load(referencedFile, DicomDataSetLoadFlags.None);
                key = ds.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
                if (string.IsNullOrEmpty(key))
                    key = Guid.NewGuid().ToString("N");
                dataSets.Add(key, ds);
            }

            return dataSets;
        }

        public string GetInstanceLocalPathName(string instanceUID)
        {
           DataSet instances;
            string[] instanceUIDs = { instanceUID };
            instances = QueryInstances(instanceUIDs);
            foreach (DataRow row in instances.Tables[DataTableHelper.InstanceTableName].Rows)
            {
               string referencedFile = row.Field<string>("ReferencedFile");
               return referencedFile;
            }
            return string.Empty;
        }

        public string GetSeriesLocalPathName(string instanceUID)
        {
           DataSet instances;
            string[] instanceUIDs = { instanceUID };
            instances = QuerySeries(instanceUIDs);
            foreach (DataRow row in instances.Tables[DataTableHelper.InstanceTableName].Rows)
            {
               string referencedFile = row.Field<string>("ReferencedFile");
               return referencedFile;
            }
            return string.Empty;
        }
       
        #endregion


        #endregion

        #region Private

        #region Methods

        private RasterImage GetImage(DicomDataSet dicomDs)
        {
            DicomElement element = dicomDs.FindFirstElement(null, DicomTag.PixelData, true);

            if (null != element)
            {
                return dicomDs.GetImage(element,
                                          0,
                                          0,
                                          RasterByteOrder.Gray,
                                          DicomGetImageFlags.AutoApplyModalityLut | DicomGetImageFlags.AutoApplyVoiLut);
            }
            return null;
        }

        private DataSet QueryCurrentPatient(string patientID)
        {
            MatchingParameterCollection matchingCollection;
            MatchingParameterList matchingList;
            Patient patient;

            matchingCollection = new MatchingParameterCollection();
            matchingList = new MatchingParameterList();
            patient = new Patient(patientID);

            matchingList.Add(patient);
            matchingCollection.Add(matchingList);

            return _DataAccessAgent.QueryCompositeInstances(matchingCollection);
        }

        private DataSet QueryInstances(string[] instanceUIDs)
        {
            MatchingParameterCollection matchingCollection;
            MatchingParameterList matchingList;

            matchingCollection = new MatchingParameterCollection();

            foreach (string instanceUID in instanceUIDs)
            {
                Instance intance = new Instance(instanceUID);

                matchingList = new MatchingParameterList();
                matchingList.Add(intance);
                matchingCollection.Add(matchingList);
            }

            return _DataAccessAgent.QueryCompositeInstances(matchingCollection);
        }

        private DataSet QuerySeries(string[] instanceUIDs)
        {
            MatchingParameterCollection matchingCollection;
            MatchingParameterList matchingList;

            matchingCollection = new MatchingParameterCollection();

            foreach (string instanceUID in instanceUIDs)
            {
                Series intance = new Series(instanceUID);

                matchingList = new MatchingParameterList();
                matchingList.Add(intance);
                matchingCollection.Add(matchingList);
            }

            return _DataAccessAgent.QueryCompositeInstances(matchingCollection);
        }        

        private static T FromXml<T>(string value, params Type[] extraTypes)
        {
            XmlSerializer s = new XmlSerializer(typeof(T), extraTypes);

            using (StringReader reader = new StringReader(value))
            {
                object obj = s.Deserialize(reader);
                return (T)obj;
            }
        }

        #endregion

        #region Properties

        #endregion

        #region Events

        #endregion

        #region Data Members

        #endregion

        #region Data Types Definition

        #endregion

        #endregion

        #region internal

        #region Methods

        #endregion

        #region Properties

        #endregion

        #region Events

        #endregion

        #region Data Types Definition

        #endregion

        #region Callbacks

        #endregion

        #endregion
    }
}
