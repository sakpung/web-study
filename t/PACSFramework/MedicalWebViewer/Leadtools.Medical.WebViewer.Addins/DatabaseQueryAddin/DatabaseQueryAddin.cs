// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;


using Leadtools.Dicom;
using Leadtools.Dicom.Common.Medical;
using Leadtools.Codecs;
using Leadtools.Dicom.Imaging;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer.Catalog;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.Medical.Logging.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Interface;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.WebViewer.Addins.Common;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Medical3D.Client;
using System.Drawing;
using System.Timers;
using System.Web.Script.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime;
using System.Runtime.CompilerServices;

namespace Leadtools.Medical.WebViewer.Addins
{
    static class Image3DGenerator
    {
        static Task TimelyChecks = null;

        public static int DebuggingFlag { get; set; }
        public static string DebuggingUser { get; set; }
        static Image3DGenerator()
        {
            using (var c = new RasterCodecs())
            { }

            int val = 0;

            if (int.TryParse(ConfigurationManager.AppSettings["Medical3D.VolumeCountLimit"], out val))
            {
                Medical3DClient.VolumesLimit = val;
            }
            if (int.TryParse(ConfigurationManager.AppSettings["Medical3D.HardwareVolumeCountLimit"], out val))
            {
                Medical3DClient.VolumesHardwareLimit = val;
            }

            if (int.TryParse(ConfigurationManager.AppSettings["Medical3D.DebuggingFlag"], out val))
            {
                DebuggingFlag = val;
            }
            else
            {
                DebuggingFlag = 0;
            }

            DebuggingUser = ConfigurationManager.AppSettings["Medical3D.DebuggingUser"];

            if (int.TryParse(ConfigurationManager.AppSettings["Medical3D.IdleTimeout"], out val))
            {
                Medical3DClient.IdleTimeout = val;
            }
            if (int.TryParse(ConfigurationManager.AppSettings["Medical3D.RecycleTimeout"], out val))
            {
                Medical3DClient.RecycleTimeout = val;
            }

            TimelyChecks = new Task(async () =>
            {
                while (true)
                {
                    await Task.Delay(30000);
                    Medical3DClient.DoTimelyChecks();
                }
            });

            TimelyChecks.Start();
        }

        static string GetDefaultCacheStorage()
        {
            try
            {
                string storageLocation = string.Empty;

                using (StorageModuleConfigurationManager configManager = new StorageModuleConfigurationManager(false))
                {
                    var serviceDirectory = ConfigurationManager.AppSettings.Get("storageServerServicePath");

                    if (!string.IsNullOrEmpty(serviceDirectory))
                    {
                        configManager.Load(serviceDirectory);
                        StorageAddInsConfiguration storageSettings = configManager.GetStorageAddInsSettings();
                        storageLocation = storageSettings.StoreAddIn.StorageLocation;

                        return Path.Combine(storageLocation, @"LTCache3D");
                    }
                }
            }
            catch
            {

            }

            return string.Empty;
        }


        public static void Reset()
        {
            lock (Medical3DClient.EnginePath)
            {
                Medical3DClient.EnginePath = ConfigurationManager.AppSettings["Medical3D.RendererPath"];
            }
        }

        private const DicomGetImageFlags _dicomGetImageFlags =
                    DicomGetImageFlags.AutoApplyModalityLut |
                    DicomGetImageFlags.AutoApplyVoiLut |
                    DicomGetImageFlags.AutoScaleModalityLut |
                    DicomGetImageFlags.AutoScaleVoiLut |
                    DicomGetImageFlags.AutoDetectInvalidRleCompression;

        public static void CreateObject(string id)
        {
            Medical3DClient.CreateObject(id);
        }
        public static string Create3DObject(string userName, List<DicomSortImageData> items, string stackInstanceUID, string id, string object3DFileName, bool cacheEnabled, RenderingType rendering)
        {
            int count = items.Count;
            float[] imageOrientation = new float[6];


            if (items[0].ImageOrientation != null)
            {
                string spearator = "\\";
                string[] test = items[0].ImageOrientation.Split(spearator.ToCharArray());
                for (int i = 0; i < 6; i++)
                {
                    imageOrientation[i] = float.Parse(test[i]);
                }
            }
            else
                imageOrientation = new float[] { 1, 0, 0, 0, 1, 0 };

            bool multiFrame = false;
            CodecsImageInfo info = null;
            using (RasterCodecs a = new RasterCodecs())
            {
                info = a.GetInformation((string)items[0].Data, true);

                if ((items.Count == 1) && (info.TotalPages > 1))
                {
                    multiFrame = true;
                    count = info.TotalPages;
                }
            }

            string files3D = "";
            lock (Medical3DClient.EnginePath)
            {
                files3D = Medical3DClient.EnginePath;
            }
            if (!String.IsNullOrEmpty(files3D) && Directory.Exists(files3D))
            {
                int debug = (DebuggingUser == userName) ? 1 : DebuggingFlag;
                Medical3DClient.Create3DObject_Create(id, info.Width, info.Height, count, info.BitsPerPixel, rendering, debug);

                LeadPointD pixelSpacing = items[0].PixelSpacing;

                if (imageOrientation == null)
                    return "No orientation value is present";

                int index = 0;

                int windowWidth = 0;
                int windowCenter = 0;
                float rescaleSlope = 1;
                float rescaleIntercept = 0;


                if (multiFrame)
                {
                    string fileName = (string)items[0].Data;
                    DicomDataSet ds = new DicomDataSet();
                    ds.Load(fileName, DicomDataSetLoadFlags.None);

                    object output = GetDicomValue(ds, DicomTag.WindowWidth, true);
                    if (output != null)
                    {
                        windowWidth = (int)output;
                    }

                    output = GetDicomValue(ds, DicomTag.WindowCenter, true);
                    if (output != null)
                    {
                        windowCenter = (int)output;
                    }


                    output = GetDicomValue(ds, DicomTag.RescaleIntercept, false);
                    if (output != null)
                    {
                        rescaleIntercept = (float)output;
                    }


                    output = GetDicomValue(ds, DicomTag.RescaleSlope, false);
                    if (output != null)
                    {
                        rescaleSlope = (float)output;
                    }


                    DicomElement patientElement = ds.FindFirstElement(null, DicomTag.PerFrameFunctionalGroupsSequence, true);

                    patientElement = ds.GetChildElement(patientElement, true);

                    DicomElement firstItem = ds.FindFirstElement(patientElement, DicomTag.Item, true);

                    DicomElement itemElement = ds.GetChildElement(firstItem, true);

                    itemElement = ds.FindFirstElement(itemElement, DicomTag.PlaneOrientationSequence, true);

                    itemElement = ds.GetChildElement(itemElement, true);

                    itemElement = ds.FindFirstElement(itemElement, DicomTag.Item, true);

                    itemElement = ds.GetChildElement(itemElement, true);

                    itemElement = ds.FindFirstElement(itemElement, DicomTag.ImageOrientationPatient, true);

                    double[] imageOrientationD = ds.GetDoubleValue(itemElement, 0, 6);
                    imageOrientation = new float[] { (float)imageOrientationD[0], (float)imageOrientationD[1], (float)imageOrientationD[2], (float)imageOrientationD[3], (float)imageOrientationD[4], (float)imageOrientationD[5] };

                    double[] a = GetPixelSpacing(ds);
                    pixelSpacing = LeadPointD.Create(a[0], a[1]);

                    for (index = 0; index < count; index++)
                    {
                        itemElement = ds.GetChildElement(firstItem, true);

                        itemElement = ds.FindFirstElement(itemElement, DicomTag.PlanePositionSequence, true);

                        itemElement = ds.GetChildElement(itemElement, true);

                        itemElement = ds.FindFirstElement(itemElement, DicomTag.Item, true);

                        itemElement = ds.GetChildElement(itemElement, true);

                        itemElement = ds.FindFirstElement(itemElement, DicomTag.ImagePositionPatient, true);

                        double[] imagePosition = ds.GetDoubleValue(itemElement, 0, 3);

                        RasterImage image = ds.GetImage(null, index, 0, RasterByteOrder.Gray,
                           DicomGetImageFlags.AutoDetectInvalidRleCompression);
                        /*DicomGetImageFlags.AutoApplyVoiLut |
                        DicomGetImageFlags.AutoScaleModalityLut |
                        DicomGetImageFlags.AutoScaleVoiLut |
                        DicomGetImageFlags.AutoDetectInvalidRleCompression);*/

                        Medical3DClient.Create3DObject_AddFrame(id, image, fileName, index, new float[] { (float)imagePosition[0], (float)imagePosition[1], (float)imagePosition[2] }, rescaleSlope, rescaleIntercept, windowWidth, windowCenter);

                        image.Dispose();

                        firstItem = ds.GetNextElement(firstItem, true, true);

                    }
                }
                else
                {
                    for (index = 0; index < count; index++)
                    {
                        using (DicomDataSet ds = new DicomDataSet())
                        {
                            ds.Load((string)items[index].Data, DicomDataSetLoadFlags.None);

                            DicomElement pixelDataElement = ds.FindFirstElement(null, DicomTag.PixelData, true);

                            using (RasterImage image = ds.GetImage(pixelDataElement, 0, 0, RasterByteOrder.Gray, DicomGetImageFlags.AutoDetectInvalidRleCompression))
                            {
                                DicomElement patientElement = ds.FindFirstElement(null, DicomTag.ImagePositionPatient, true);

                                double[] imagePosition = new double[] { 0, 0, 0 }; ;
                                if (patientElement != null)
                                {
                                    imagePosition = ds.GetDoubleValue(patientElement, 0, 3);
                                }

                                object output = GetDicomValue(ds, DicomTag.WindowWidth, true);
                                if (output != null)
                                {
                                    windowWidth = (int)output;
                                }

                                output = GetDicomValue(ds, DicomTag.WindowCenter, true);
                                if (output != null)
                                {
                                    windowCenter = (int)output;
                                }


                                output = GetDicomValue(ds, DicomTag.RescaleIntercept, false);
                                if (output != null)
                                {
                                    rescaleIntercept = (float)output;
                                }


                                output = GetDicomValue(ds, DicomTag.RescaleSlope, false);
                                if (output != null)
                                {
                                    rescaleSlope = (float)output;
                                }

                                Medical3DClient.Create3DObject_AddFrame(id, image, (string)items[index].Data, index, new float[] { (float)imagePosition[0], (float)imagePosition[1], (float)imagePosition[2] }, rescaleSlope, rescaleIntercept, windowWidth, windowCenter);
                            }
                        }
                    }
                }

                Medical3DClient.Create3DObject_Close(id, imageOrientation, new float[] { (float)pixelSpacing.X, (float)pixelSpacing.Y }, 1);

                if (cacheEnabled)
                    Medical3DClient.Save3DObject(id, object3DFileName);

            }
            else
                return "Path to 3D Engine is not assigned";

            return "Success";
        }

        private static double[] GetPixelSpacing(DicomDataSet ds)
        {
            DicomElement patientElement = ds.FindFirstElement(null, DicomTag.SharedFunctionalGroupsSequence, true);

            patientElement = ds.GetChildElement(patientElement, true);

            DicomElement firstItem = ds.FindFirstElement(patientElement, DicomTag.Item, true);

            DicomElement itemElement = ds.GetChildElement(firstItem, true);

            itemElement = ds.FindFirstElement(itemElement, DicomTag.PixelMeasuresSequence, true);

            itemElement = ds.GetChildElement(itemElement, true);

            itemElement = ds.FindFirstElement(itemElement, DicomTag.Item, true);

            itemElement = ds.GetChildElement(itemElement, true);

            itemElement = ds.FindFirstElement(itemElement, DicomTag.PixelSpacing, true);

            return ds.GetDoubleValue(itemElement, 0, 2);
        }

        private static object GetDicomValue(DicomDataSet ds, long tag, bool integer)
        {
            DicomElement element = ds.FindFirstElement(null, tag, true);
            if (element != null)
            {
                string value = ds.GetConvertValue(element);
                if (!String.IsNullOrEmpty(value))
                {

                    if (value.Contains('\\'))
                    {
                        value = (value.Split('\\'))[0];

                    }

                    float numericValue = float.Parse(value);

                    if (integer)
                    {
                        int integerValue = (int)numericValue;
                        return integerValue;
                    }
                    else
                        return numericValue;
                }

            }

            return null;
        }


        public static void KeepAlive(string id)
        {
            Medical3DClient.KeepAlive(id);
        }

        public static string CheckProgress(string id)
        {
            return Medical3DClient.CheckProgress(id);
        }



        public static void End3DObject(string id)
        {
            Medical3DClient.DestroyObject(id);

            Reset();
        }


        public static Image CreateBitmapImage(int index, int width, int height, int downSizeRatio)
        {
            Bitmap b = new Bitmap(width / downSizeRatio, height / downSizeRatio);

            int min = Math.Min(b.Width, b.Height);

            Graphics g = Graphics.FromImage(b);

            g.FillRectangle(Brushes.DarkBlue, new Rectangle(0, 0, b.Width, b.Height));

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            g.DrawString(index.ToString(), new Font(new FontFamily("Arial"), min / 2, FontStyle.Bold), Brushes.Yellow, b.Width / 2, b.Height / 2, format);


            return b;
        }

        public static Stream GetPanoramicImage(string id = "", int resizeFactor = 0, string polygonInfo = "", string polygonData = "")
        {
            MemoryStream imageStream = new MemoryStream();


            // TODO: extensive check.
            string[] pointData = polygonData.Split(',');
            if ((pointData == null) || (pointData.Length < 4))
                return null;

            LeadPoint[] points = new LeadPoint[pointData.Length / 2];
            int index = 0;
            float x = 0, y = 0;
            for (index = 0; index < points.Length; index++)
            {
                if (!float.TryParse(pointData[index * 2], out x))
                    return null;
                if (!float.TryParse(pointData[index * 2 + 1], out y))
                    return null;

                points[index] = LeadPoint.Create((int)Math.Round(x), (int)Math.Round(y));
            }   

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, string> info = serializer.Deserialize<Dictionary<string, string>>(polygonInfo);
            if (info == null)
                return null;

            RasterImage image = Medical3DClient.GetPanoramicImage(id, resizeFactor, float.Parse(info["thickness"]), float.Parse(info["angle"]), (PanoramicType)Int32.Parse(info["type"]), points);

            if (image == null)
            {
                return null;
            }


            int width  = (int)(image.Width  / resizeFactor);
            int height = (int)(image.Height / resizeFactor);

            Leadtools.ImageProcessing.SizeCommand size = new Leadtools.ImageProcessing.SizeCommand(width, height, RasterSizeFlags.Bicubic);
            size.Run(image);


            byte[] output = new byte[0];
            ObjectRetrieveAddin.GetImageBufferAsPNG(image, output, imageStream);
            image.Dispose();

            return imageStream;

            return imageStream;
        }


        public static void Update3DSettings(string id = "", string options = "")
        {
            Medical3DClient.UpdateSettings(id, options);
        }

        public static string Get3DSettings(string id = "", string options = "")
        {
            return Medical3DClient.GetSettings(id, options);
        }

        public static void LockTimeOut(string id)
        {
            Medical3DClient.LockTimeOut(id);
        }

        public static void UnlockTimeOut(string id)
        {
            Medical3DClient.UnLockTimeOut(id);
        }



        public static Stream Get3DImage(string id, int x, int y, int width, int height, int size, string effect, int action, float sensitivity, float ratio)
        {
            try
            {
                MemoryStream imageStream = new MemoryStream();

                int fullSize = 1024;

                RasterImage image = Medical3DClient.GetRenderedImage(id, x, y, width, height, size, effect, action, sensitivity, ratio);

                if (image == null)
                {
                    return null;
                }

                //System.Diagnostics.Debug.WriteLine($"ltrender: Dim {image.Width} X {image.Height}");

                if (size != 0)
                {
                    fullSize = fullSize / size;
                }

                width = (int)(width * ratio);
                height = (int)(height * ratio);

                Leadtools.ImageProcessing.CropCommand crop = new ImageProcessing.CropCommand();
                LeadRect rect = new LeadRect((fullSize - width) / 2, (fullSize - height) / 2, width, height);
                crop.Rectangle = rect;
                crop.Run(image);

                using (var codecs = new RasterCodecs())
                {
                    codecs.Options.Jpeg.Save.QualityFactor = 20;
                    codecs.Options.Jpeg.Save.CmpQualityFactorPredefined = CodecsCmpQualityFactorPredefined.Custom;
                    codecs.Save(image, imageStream, RasterImageFormat.Jpeg411, 24);
                }

                imageStream.Position = 0;

                image.Dispose();

                return imageStream;
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine("lt: Get3DImage stream > " + ex.Message);
                throw;
            }
            finally
            {
            }
        }
    }


    /// <summary>
    /// Use this addin to query the Storage Server database and apply user authorization to filter out the results.
    /// </summary>
    public class DatabaseQueryAddin : IQueryAddin
    {

        private bool _searchOtherPatientIds = false;
        private IStorageDataAccessAgent3 _dataAccess3;

        /// <summary>
        /// The data access layer object used to evaluate the user allowed patients
        /// </summary>
        public IAuthorizedStorageDataAccessAgent2 DataAccess
        {
            get;
            private set;
        }

        public IOptionsDataAccessAgent OptionsDataAccess
        {
            get;
            private set;
        }

        public IPermissionManagementDataAccessAgent2 PermissionsDataAccess
        {
            get;
            private set;
        }

        private Lazy<IExternalStoreDataAccessAgent> _externalStoreAgent;
        private ILoggingDataAccessAgent _loggingAgent;
        private string _storageServerServicePath;

        Leadtools.Dicom.Imaging.IDataCacheProvider DataCache
        {
            get;
            set;
        }

        public DatabaseQueryAddin(IAuthorizedStorageDataAccessAgent2 dataAccess)
        {
            DataAccess = dataAccess;

            string sSearchOtherPatientIds = ConfigurationManager.AppSettings["searchOtherPatientIds"];
            _searchOtherPatientIds = string.Compare(sSearchOtherPatientIds, "true", true) == 0;
        }

        public DatabaseQueryAddin(IAuthorizedStorageDataAccessAgent2 dataAccess, IOptionsDataAccessAgent optionsDataAccess, IPermissionManagementDataAccessAgent2 permissionsDataAccess,
                                  Lazy<IExternalStoreDataAccessAgent> externalStoreAgent, ILoggingDataAccessAgent loggingAgent, string storageServerServicePath, IStorageDataAccessAgent dataAccess2, Leadtools.Dicom.Imaging.IDataCacheProvider dataCache)
        {
            DataAccess = dataAccess;
            OptionsDataAccess = optionsDataAccess;
            PermissionsDataAccess = permissionsDataAccess;
            _externalStoreAgent = externalStoreAgent;
            _loggingAgent = loggingAgent;
            _storageServerServicePath = storageServerServicePath;
            DataCache = dataCache;
            _searchOtherPatientIds = optionsDataAccess.Get("SearchOtherPatientIds", false, null);
            _dataAccess3 = dataAccess2 as IStorageDataAccessAgent3;

            GCLatencyMode oldMode = GCSettings.LatencyMode;
            RuntimeHelpers.PrepareConstrainedRegions();
            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
        }

        /// <summary>
        /// Find the presentation state DICOM instances (e.g. DICOM Annotations) stored in the storage server database
        /// </summary>
        /// <param name="userName">user making the query</param>
        /// <param name="referencedSeries">
        /// The series instance UID for the which the presentation state object is created
        /// </param>
        /// <param name="userData">custom data</param>
        /// <returns>
        /// returns the matching presentation state objects information
        /// </returns>
        public PresentationStateData[] FindPresentationState(string userName, string referencedSeries, string userData)
        {
#if TUTORIAL_CUSTOM_DATABASE
         // This version of FindPresentationState is part of the "Changing the LEAD HTML5 Medical Viewer to use a different database schema" tutorial
         // The tutorial database schema does not store presentation state information, so for the tutorial this method always returns an empty list.
         // For more details, see the "Changing the LEAD HTML5 Medical Viewer to use a different database schema" tutorial.
         return new PresentationStateData[0];
#else
            //preparing the matching parameters
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();
            ReferencedSeriesSequence referencedSeriesSeq = new ReferencedSeriesSequence();
            Series prSeries = new Series() { Modality = "PR" };
            string[] roles = PermissionsDataAccess.GetUserRoles(userName);
            bool enablePatientRestriction = OptionsDataAccess.Get<bool>("EnablePatientRestriction", false);

            DataAccess.EnablePatientRestriction = enablePatientRestriction;
            referencedSeriesSeq.SeriesInstanceUID = referencedSeries;

            matchingList.Add(referencedSeriesSeq);
            matchingList.Add(prSeries);

            matchingCollection.Add(matchingList);

            //query all objects that has a matching referenced sereis
            DataSet dataSetResults = DataAccess.QueryCompositeInstances(matchingCollection, userName, roles);
            CompositeInstanceDataSet results = dataSetResults.ToCompositeInstanceDataSet();
            List<PresentationStateData> matchingInstances = new List<PresentationStateData>();

            //creating the presentation state objects from the returned data.
            for (int instanceIndex = 0; instanceIndex < results.Instance.Count; instanceIndex++)
            {
                bool isDbNull = results.Instance[instanceIndex]["SOPClassUID"] == System.DBNull.Value;
                if (isDbNull == false)
                {
                    if (results.Instance[instanceIndex].SOPClassUID != DicomUidType.BasicStructuredDisplayStorage)
                    {
                        PresentationStateData instanceObject = new PresentationStateData();
                        CompositeInstanceDataSet.InstanceRow row = results.Instance[instanceIndex];

                        FillInstanceData(instanceObject, row);

                        CompositeInstanceDataSet.PresentationInstanceRow[] presentationsRows =
                           row.GetPresentationInstanceRows();

                        if (presentationsRows.Length == 1)
                        {
                            CompositeInstanceDataSet.PresentationInstanceRow presentationsRow = presentationsRows[0];

                            var refImages = from r in results.ReferencedImageSequence
                                            where r.SOPInstanceUID == presentationsRow.SOPInstanceUID
                                            select r;

                            instanceObject.ContentLabel = presentationsRow.IsContentLabelNull()
                                                             ? ""
                                                             : presentationsRow.ContentLabel;
                            instanceObject.ContentDescription = presentationsRow.IsContentDescriptionNull()
                                                                   ? ""
                                                                   : presentationsRow.ContentDescription;
                            instanceObject.ContentCreatorName = presentationsRow.IsContentCreatorFamilyNameNull()
                                                                   ? ""
                                                                   : presentationsRow.ContentCreatorFamilyName;
                            instanceObject.CreationDate = presentationsRow.IsCreationDateNull()
                                                             ? ""
                                                             : presentationsRow.CreationDate.ToString();

                            instanceObject.ReferencedSOPInstanceUIDs = new List<string>();
                            foreach (var refSop in refImages)
                            {
                                instanceObject.ReferencedSOPInstanceUIDs.Add(refSop.ReferencedSOPInstanceUID);
                            }
                        }

                        matchingInstances.Add(instanceObject);
                    }
                }
            }

            return matchingInstances.ToArray();
#endif
        }

        public bool HasPresentationState(string userName, string referencedSeriesInstanceUID, string sopInstanceUID, string userData)
        {
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();
            ReferencedSeriesSequence referencedSeriesSeq = new ReferencedSeriesSequence();
            ReferencedImageSequence referencedImageSeq = new ReferencedImageSequence();
            DataSet results = null;
            string[] roles = PermissionsDataAccess.GetUserRoles(userName);
            bool enablePatientRestriction = OptionsDataAccess.Get<bool>("EnablePatientRestriction", false);

            DataAccess.EnablePatientRestriction = enablePatientRestriction;

            referencedSeriesSeq.SeriesInstanceUID = referencedSeriesInstanceUID;
            matchingList.Add(referencedSeriesSeq);

            referencedImageSeq.ReferencedSOPInstanceUID = sopInstanceUID;
            matchingList.Add(referencedImageSeq);

            matchingCollection.Add(matchingList);
            results = DataAccess.MinimumQueryCompositeInstances(matchingCollection, userName, roles);

            return results.Tables[DataTableHelper.InstanceTableName].Rows.Count > 0;
        }

        /// <summary>
        /// takes a row from the database that represents a DICOM instance and populate the custom instance object
        /// </summary>
        /// <param name="instanceObject"></param>
        /// <param name="row"></param>
        private static void FillInstanceData(InstanceData instanceObject, DataRow instanceRow)
        {
            IInstanceInfo instanceInfo = RegisteredDataRows.InstanceInfo;
            ISeriesInfo seriesInfo = RegisteredDataRows.SeriesInfo;
            IStudyInfo studyInfo = RegisteredDataRows.StudyInfo;

            DataRow seriesRow = instanceInfo.GetSeriesRow(instanceRow);
            DataRow studyRow = seriesInfo.GetStudyRow(seriesRow);

            // instanceRow
            instanceObject.InstanceNumber = instanceInfo.GetElementValue(instanceRow, DicomTag.InstanceNumber);            // InstanceNumber(row);           // row.IsInstanceNumberNull() ? string.Empty : row.InstanceNumber.ToString();
            instanceObject.SOPClassUID = instanceInfo.GetElementValue(instanceRow, DicomTag.SOPClassUID);               // row.IsSOPClassUIDNull() ? string.Empty : row.SOPClassUID;
            instanceObject.SOPInstanceUID = instanceInfo.GetElementValue(instanceRow, DicomTag.SOPInstanceUID);            // row.SOPInstanceUID;
            instanceObject.StationName = instanceInfo.GetElementValue(instanceRow, DicomTag.StationName);               // row.IsStationNameNull() ? string.Empty : row.StationName;
            instanceObject.TransferSyntax = instanceInfo.GetElementValue(instanceRow, DicomTag.TransferSyntaxUID);         // row.IsTransferSyntaxNull() ? string.Empty : row.TransferSyntax;
            instanceObject.SeriesInstanceUID = instanceInfo.GetElementValue(instanceRow, DicomTag.SeriesInstanceUID);         // row.SeriesInstanceUID;

            // seriesRow
            instanceObject.StudyInstanceUID = seriesInfo.GetElementValue(seriesRow, DicomTag.StudyInstanceUID);

            // studyRow
            instanceObject.PatientID = studyInfo.GetElementValue(studyRow, DicomTag.PatientID);

            //
            instanceObject.NumberOfFrames = 1;
            if (instanceRow.Table.ChildRelations["FK_ImageInstance_Instance"] != null)
            {
                // CompositeInstanceDataSet.ImageInstanceRow[] imageRows = (CompositeInstanceDataSet.ImageInstanceRow[])instanceRow.GetImageInstanceRows();
                CompositeInstanceDataSet.ImageInstanceRow[] imageRows = ((CompositeInstanceDataSet.ImageInstanceRow[])(instanceRow.GetChildRows(instanceRow.Table.ChildRelations["FK_ImageInstance_Instance"])));
                if (imageRows != null && imageRows.Length > 0)
                {
                    instanceObject.NumberOfFrames = imageRows[0].IsNumberOfFramesNull() ? 1 : imageRows[0].NumberOfFrames;
                }
            }
        }

        private static void FillSeriesData(SeriesData seriesObject, DataRow instanceRow)
        {
            IInstanceInfo instanceInfo = RegisteredDataRows.InstanceInfo;
            ISeriesInfo seriesInfo = RegisteredDataRows.SeriesInfo;
            IStudyInfo studyInfo = RegisteredDataRows.StudyInfo;

            DataRow seriesRow = instanceInfo.GetSeriesRow(instanceRow);
            DataRow studyRow = seriesInfo.GetStudyRow(seriesRow);

            if (null != seriesObject)
            {
                seriesObject.Modality = seriesInfo.GetElementValue(seriesRow, DicomTag.Modality);
                if (AddInsUtils.ModalityHasPixelData(seriesObject.Modality))
                {
                    seriesObject.Number = seriesInfo.GetElementValue(seriesRow, DicomTag.SeriesNumber);
                    seriesObject.InstanceUID = seriesInfo.GetElementValue(seriesRow, DicomTag.SeriesInstanceUID);
                    seriesObject.Description = seriesInfo.GetElementValue(seriesRow, DicomTag.SeriesDescription);
                    seriesObject.Date = seriesInfo.GetElementValue(seriesRow, DicomTag.SeriesDate);
                    seriesObject.StudyInstanceUID = seriesInfo.GetElementValue(seriesRow, DicomTag.StudyInstanceUID);
                }
                else
                {
                    //skip altogether
                    return;
                }
            }
        }


        private void SetMaxQueryResults(int max)
        {
            if (max > 0)
            {
                DataAccess.MaxQueryResults = max;
            }
        }

        private void ResetMaxQueryResults()
        {
            DataAccess.MaxQueryResults = 0;
        }

        private DicomFileInfo GetDicomFileInfo(MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd, string userName, DataSet results, DataRow instanceRow)
        {
            var referencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(instanceRow);

            if (string.IsNullOrEmpty(referencedFile))//external storage?
            {
                using (var ds = dsLoadCmd.GetDicomDataSet(instanceRow, out referencedFile))
                {
                }
            }

            if (!string.IsNullOrEmpty(referencedFile))
            {
                using (var dicomSourceProxy = new DicomSourceProxy(DataCache))
                {
                    var query = new ViewImageQuery() { FileName = referencedFile, Meta = "info" };

                    try
                    {
                        using (var result = dicomSourceProxy.LoadMeta(query))
                        {
                            if (null != result.Meta)
                            {
                                var fileInfo = result.Meta as DicomFileInfo;
                                return fileInfo;
                            }
                        }
                    }
                    catch
                    {
                        //ignored
                    }
                }
            }
            return null;
        }
        private PageInfo[] GetPagesInfo(DicomFileInfo fileInfo)
        {
            if (null == fileInfo)
                return null;

            var pi = new List<PageInfo>();

            if (null != fileInfo.Pages)
            {
                for (int index = 0; index < fileInfo.Pages.Length; index++)
                {
                    pi.Add(ShallowCopyInfo(fileInfo.Pages[index], fileInfo));
                }
            }

            return pi.ToArray();
        }

        public void CreateObject(string id = "")
        {
            Medical3DClient.CreateObject(id);
        }

        public string Get3DSettings(string id = "", string options = "")
        {
            return Image3DGenerator.Get3DSettings(id, options);
        }


        public void Update3DSettings(string id = "", string options = "")
        {
            Image3DGenerator.Update3DSettings(id, options);
        }


        public Stream GetPanoramicImage(string id = "", int resizeFactor = 0, string polygonInfo = "", string polygonData = "")
        {
            var stm = Image3DGenerator.GetPanoramicImage(id, resizeFactor, polygonInfo, polygonData);
            if (null == stm)
            {
                throw new Exception("Failed to get panoramic image (null stream)");
            }
            return stm;
        }

        public Stream Get3DImage(string id = "", int x = 0, int y = 0, int width = 1, int height = 1, int resizeFactor = 0, string effect = "", int action = 0, float sensitivity = 1.0f, float ratio = 1.0f)
        {
            var stm = Image3DGenerator.Get3DImage(id, x, y, width, height, resizeFactor, effect, action, sensitivity, ratio);
            if (null == stm)
            {
                throw new Exception("Failed to get image (null stream)");
            }
            return stm;
        }

        public void End3DObject(string id = "")
        {
            Image3DGenerator.End3DObject(id);
        }


        public string CheckProgress(string id = "")
        {
            return Image3DGenerator.CheckProgress(id);
        }

        public void KeepAlive(string id = "")
        {
            Image3DGenerator.KeepAlive(id);
        }
        public bool ItemExists(string id)
        {
            return Medical3DClient.ItemExists(id);
        }
        public void LockTimeOut(string id)
        {
            Image3DGenerator.LockTimeOut(id);
        }
        public void UnlockTimeOut(string id)
        {
            Image3DGenerator.UnlockTimeOut(id);
        }

        public void Initialize3DObject(string id)
        {
            Image3DGenerator.CreateObject(id);
        }
        public string Start3DObject(string userName, DataContracts.QueryOptions options, bool cacheEnabled = true, string cachePath = "", string id = "", string stackInstanceUID = "", int renderingType = 1)
        {
            try
            {
                Leadtools.Medical3D.Client.RenderingType rendering = (Leadtools.Medical3D.Client.RenderingType)renderingType;
                Medical3DClient.CachePath = cachePath;
                Image3DGenerator.Reset();

                String saved3DObjectFileName = stackInstanceUID + ".raw";

                string object3DFileName = Path.Combine(Medical3DClient.CachePath, saved3DObjectFileName);

                if (File.Exists(object3DFileName))
                {
                    int debug = (Image3DGenerator.DebuggingUser == userName) ? 1 : Image3DGenerator.DebuggingFlag;
                    Medical3DClient.Load3DObject(id, object3DFileName, rendering, debug);
                    return "Success";
                }

                MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
                MatchingParameterList matchingList = new MatchingParameterList();
                string[] roles = PermissionsDataAccess.GetUserRoles(userName);
                bool enablePatientRestriction = OptionsDataAccess.Get<bool>("EnablePatientRestriction", false);

                List<DicomSortImageData> data = new List<DicomSortImageData>();

                MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(null, _externalStoreAgent, _loggingAgent, _storageServerServicePath, true);
                DataAccess.EnablePatientRestriction = enablePatientRestriction;
                matchingCollection.Add(matchingList);
                AddInsUtils.FillMatchingParameters(options, matchingList);

                DataSet results = null;
                results = DataAccess.BasicQueryCompositeInstances(matchingCollection, userName, roles);

                int nInstanceCount = results.Tables[DataTableHelper.InstanceTableName].Rows.Count;
                InstanceData[] matchingInstances = new InstanceData[/*lightQuery ? 1 : */nInstanceCount];
                Dictionary<string, InstanceData> rows = new Dictionary<string, InstanceData>();

                for (int instanceIndex = 0; instanceIndex < nInstanceCount; instanceIndex++)
                {
                    DataRow row = results.Tables[DataTableHelper.InstanceTableName].Rows[instanceIndex];

                    DicomFileInfo dicomFileInfo = GetDicomFileInfo(dsLoadCmd, userName, results, row);

                    try
                    {
                        DicomSortImageDataEx imageData = (DicomSortImageDataEx)AddInsUtils.GetImageData(row);
                        InstanceData instanceObject = new InstanceData();
                        imageData.Data = RegisteredDataRows.InstanceInfo.ReferencedFile(row);
                        data.Add(imageData);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                    }
                }

                DicomSortSeriesManager sort = new DicomSortSeriesManager();
                sort.Sort(data);

                List<DicomSortImageData> items = null;
                if (sort.Stacks.Count != 0)
                    items = sort.Stacks[0].Items;
                else
                    items = sort.Localizers[0].Items;


                string output = Image3DGenerator.Create3DObject(userName, items, stackInstanceUID, id, object3DFileName, cacheEnabled, rendering);

                if ("Success" != output)
                {
                    throw new Exception(output);
                }

                return output;
            }
            catch (Exception e)
            {
                Medical3DClient.SetErrorStatus(id, e.Message);
                return e.Message;
            }
        }




        /// <summary>
        /// Query the storage server database for DICOM instances (Image level query)
        /// </summary>
        /// <param name="userName">The name of the user making the query (validation purposes)</param>
        /// <param name="options">The query parameters</param>
        /// <param name="extraOptions">custom data (not used)</param>
        /// <returns></returns>
        public InstanceData[] FindInstances(string userName, DataContracts.QueryOptions options, int maxQueryResults = 0, bool lightQuery = false, bool noSort = false, string stackInstanceUID = "")
        {
            //preparing the matching parameters
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();
            string[] roles = PermissionsDataAccess.GetUserRoles(userName);
            bool enablePatientRestriction = OptionsDataAccess.Get<bool>("EnablePatientRestriction", false);

            List<DicomSortImageData> data = new List<DicomSortImageData>();
            MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(null, _externalStoreAgent, _loggingAgent, _storageServerServicePath, true);

            DataAccess.EnablePatientRestriction = enablePatientRestriction;


            matchingCollection.Add(matchingList);

            AddInsUtils.FillMatchingParameters(options, matchingList);

            SetMaxQueryResults(maxQueryResults);
            DataSet results = null;
            results = DataAccess.BasicQueryCompositeInstances(matchingCollection, userName, roles);
            ResetMaxQueryResults();

            int nInstanceCount = results.Tables[DataTableHelper.InstanceTableName].Rows.Count;


            if (nInstanceCount == 1)
            {
                results = DataAccess.BasicQueryCompositeInstances(matchingCollection, userName, roles);
            }

            nInstanceCount = results.Tables[DataTableHelper.InstanceTableName].Rows.Count;

            InstanceData[] matchingInstances = new InstanceData[lightQuery ? 1 : nInstanceCount];
            Dictionary<string, InstanceData> rows = new Dictionary<string, InstanceData>();
            for (int instanceIndex = 0; instanceIndex < nInstanceCount; instanceIndex++)
            {
                DataRow row = results.Tables[DataTableHelper.InstanceTableName].Rows[instanceIndex];

                DicomFileInfo dicomFileInfo = lightQuery ? null : GetDicomFileInfo(dsLoadCmd, userName, results, row);

                try
                {
                    DicomSortImageData imageData = AddInsUtils.GetImageData(row);
                    InstanceData instanceObject = new InstanceData();
                    if (imageData == null)
                        noSort = true;
                    data.Add(imageData);

                    FillInstanceData(instanceObject, row);

                    if (null != dicomFileInfo)
                    {
                        instanceObject.Pages = GetPagesInfo(dicomFileInfo);

                        if (instanceObject.NumberOfFrames == 0 && dicomFileInfo.EncapsulatedPDF)
                        {
                            instanceObject.NumberOfFrames = dicomFileInfo.TotalPages;
                        }
                    }

                    if (imageData != null && imageData.Data != null)
                    {
                        rows[imageData.Data.ToString()] = instanceObject;
                    }
                    else
                    {
                        rows[instanceObject.SOPInstanceUID] = instanceObject;
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }

            if (data.Count > 0)
            {
                var seriesManager = new DicomSortSeriesManager();
                if (noSort == false)
                {
                    seriesManager.Sort(data);
                }

                if ((noSort == false) && (seriesManager.Stacks.Count > 0))
                {
                    // search through both the stacks and localizers.
                    List<DicomSortSeriesStack> totalList = new List<DicomSortSeriesStack>(seriesManager.Stacks);
                    totalList.AddRange(seriesManager.Localizers);

                    foreach (DicomSortSeriesStack stack in totalList)
                    {
                        bool useStack = stack.Items.Find(item =>
                        {
                            if (item.Data != null && item.Data.ToString() == stackInstanceUID)
                                return true;
                            return false;
                        }) != null;

                        if (string.IsNullOrEmpty(stackInstanceUID) || useStack)
                        {
                            for (int instanceIndex = 0; instanceIndex < stack.Items.Count; instanceIndex++)
                            {
                                DicomSortImageData d = stack.Items[instanceIndex];

                                if (rows.ContainsKey(d.Data.ToString()))
                                {
                                    matchingInstances[lightQuery ? 0 : instanceIndex] = rows[d.Data.ToString()];

                                    if (lightQuery)
                                        break;
                                }
                            }
                            break;
                        }
                    }
                }
                else
                {
                    for (int instanceIndex = 0; instanceIndex < nInstanceCount; instanceIndex++)
                    {
                        matchingInstances[lightQuery ? 0 : instanceIndex] = rows.Values.ElementAt(instanceIndex);

                        if (lightQuery)
                            break;
                    }
                }
            }



            return matchingInstances;
        }

        /// <summary>
        /// Query the storage server database for DICOM instances (Image level query)
        /// </summary>
        /// <param name="userName">The name of the user making the query (validation purposes)</param>
        /// <param name="options">The query parameters</param>
        /// <param name="extraOptions">custom data (not used)</param>
        /// <returns></returns>
        public DICOMQueryResult ElectStudyTimeLineInstances(string userName, DataContracts.QueryOptions options, string authCookie, string ServiceUri)
        {
            //preparing the matching parameters
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();
            string[] roles = PermissionsDataAccess.GetUserRoles(userName);
            bool enablePatientRestriction = OptionsDataAccess.Get<bool>("EnablePatientRestriction", false);
            string stackInstanceUID = string.Empty;
            List<DicomSortImageData> data = new List<DicomSortImageData>();

            MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(null, _externalStoreAgent, _loggingAgent, _storageServerServicePath, true);

            DataAccess.EnablePatientRestriction = enablePatientRestriction;

            matchingCollection.Add(matchingList);

            AddInsUtils.FillMatchingParameters(options, matchingList);

            DataSet results = null;
            results = DataAccess.MinimumQueryCompositeInstances(matchingCollection, userName, roles);
            int nInstanceCount = results.Tables[DataTableHelper.InstanceTableName].Rows.Count;
            var matchingInstances = new List<InstanceData>();
            var matchingSeries = new List<SeriesData>();
            var SeriesLookup = new Dictionary<string, bool>();
            for (int instanceIndex = 0; instanceIndex < nInstanceCount; instanceIndex++)
            {
                DataRow row = results.Tables[DataTableHelper.InstanceTableName].Rows[instanceIndex];

                try
                {
                    InstanceData instanceObject = new InstanceData();
                    SeriesData seriesObject = new SeriesData();

                    FillSeriesData(seriesObject, row);
                    if (AddInsUtils.ModalityHasPixelData(seriesObject.Modality))
                    {
                        if (!SeriesLookup.ContainsKey(seriesObject.InstanceUID))
                        {
                            FillInstanceData(instanceObject, row);

                            matchingInstances.Add(instanceObject);
                            matchingSeries.Add(seriesObject);

                            SeriesLookup.Add(seriesObject.InstanceUID, true);
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }

            return new DICOMQueryResult()
            {
                Series = matchingSeries.ToArray(),
                Instances = matchingInstances.ToArray()
            };
        }



        static PageInfo ShallowCopyInfo(DicomFileInfo fileInfo, DicomFileInfo parentInfo)
        {
            if (fileInfo == null)
                return null;
            var pi = new PageInfo();
            pi.TotalEncapsulatedPages = fileInfo.EncapsulatedPDF ? fileInfo.TotalPages : 0;
            pi.SupportWindowLevel = fileInfo.SupportWindowLevel;

            if (null != fileInfo.PatientOrientation)
                pi.PatientOrientation = (string[])fileInfo.PatientOrientation.Clone();
            else if (null != parentInfo && null != parentInfo.PatientOrientation)
                pi.PatientOrientation = (string[])parentInfo.PatientOrientation.Clone();

            if (null != fileInfo.ImagePositionPatientArray)
                pi.ImagePositionPatientArray = (double[])fileInfo.ImagePositionPatientArray.Clone();
            else if (null != parentInfo && null != parentInfo.ImagePositionPatientArray)
                pi.ImagePositionPatientArray = (double[])parentInfo.ImagePositionPatientArray.Clone();

            if (null != fileInfo.ImageOrientationPatientArray)
                pi.ImageOrientationPatientArray = (double[])fileInfo.ImageOrientationPatientArray.Clone();
            else if (null != parentInfo && null != parentInfo.ImageOrientationPatientArray)
                pi.ImageOrientationPatientArray = (double[])parentInfo.ImageOrientationPatientArray.Clone();

            if (null != fileInfo.PixelSpacingPatientArray)
                pi.PixelSpacingPatientArray = (double[])fileInfo.PixelSpacingPatientArray.Clone();
            else if (null != parentInfo && null != parentInfo.PixelSpacingPatientArray)
                pi.PixelSpacingPatientArray = (double[])parentInfo.PixelSpacingPatientArray.Clone();

            //special attributes
            pi.TileSize = fileInfo.GetRecommendedTileSize();
            pi.Resolutions = fileInfo.GetRecommendedResolutions();
            return pi;
        }

        public void Normalize(PageInfo presentation)
        {
            if (null != presentation.ImagePositionPatientArray)
            {
                if (presentation.ImagePositionPatientArray.Length == 0)
                {
                    presentation.ImagePositionPatientArray = null;
                }
            }
            if (null != presentation.ImageOrientationPatientArray)
            {
                if (presentation.ImageOrientationPatientArray.Length == 0)
                {
                    presentation.ImageOrientationPatientArray = null;
                }
            }
            if (null != presentation.PixelSpacingPatientArray)
            {
                if (presentation.PixelSpacingPatientArray.Length == 0)
                {
                    presentation.PixelSpacingPatientArray = null;
                }
            }
        }

        private readonly string otherPatientIdsTableName = "OtherPatientIDs";
        private string GetOtherPatientIds(string userName, string patientId)
        {
            if (string.IsNullOrEmpty(patientId))
            {
                return string.Empty;
            }

            string otherPatientIds = string.Empty;
            IPatientInfo pi = RegisteredDataRows.PatientInfo;

            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();
            string[] roles = PermissionsDataAccess.GetUserRoles(userName);

            matchingCollection.Add(matchingList);

            QueryOptions query = new QueryOptions();
            query.PatientsOptions = new PatientsQueryOptions();
            query.PatientsOptions.PatientID = patientId;
            AddInsUtils.FillMatchingParameters(query, matchingList);
            bool enablePatientRestriction = OptionsDataAccess.Get<bool>("EnablePatientRestriction", false);

            DataAccess.EnablePatientRestriction = enablePatientRestriction;

            DataSet results = DataAccess.QueryPatients(matchingCollection, userName, roles);
            int otherPatientIdsRowCount = results.Tables[otherPatientIdsTableName].Rows.Count;

            for (int tableIndex = 0; tableIndex < otherPatientIdsRowCount; tableIndex++)
            {
                PatientData patientObject = new PatientData();
                DataRow row = results.Tables[otherPatientIdsTableName].Rows[tableIndex];
                string otherPatientId = row["OtherPatientID"] as string;
                if (!string.IsNullOrEmpty(otherPatientId))
                {
                    otherPatientIds = string.Format(@"{0}{1}\", otherPatientIds, otherPatientId);
                }
            }

            if (otherPatientIds.EndsWith(@"\"))
            {
                otherPatientIds = otherPatientIds.Substring(0, otherPatientIds.Length - 1);
            }
            return otherPatientIds;
        }

        /// <summary>
        /// query the storage server database for patients (Patient Level Query)
        /// </summary>
        /// <param name="userName">user name making the query (authorization purposes)</param>
        /// <param name="options">query params</param>
        /// <param name="extraOptions">custom data (not used)</param>
        /// <returns></returns>
        public PatientData[] FindPatients(string userName, DataContracts.QueryOptions options, int maxQueryResults = 0)
        {
            //prepare matching parameters
            MatchingParameterCollection matchingCollection = AddInsUtils.FillMatchingParametersCombined(options, _searchOtherPatientIds);
            string[] roles = PermissionsDataAccess.GetUserRoles(userName);
            bool enablePatientRestriction = OptionsDataAccess.Get<bool>("EnablePatientRestriction", false);

            DataAccess.EnablePatientRestriction = enablePatientRestriction;

            SetMaxQueryResults(maxQueryResults);
            DataSet results = DataAccess.QueryPatients(matchingCollection, userName, roles);
            ResetMaxQueryResults();

            int nPatientCount = results.Tables[DataTableHelper.PatientTableName].Rows.Count;
            PatientData[] matchingPatients = new PatientData[nPatientCount];

            //create the custom patient objects from the returned results.
            IPatientInfo pi = RegisteredDataRows.PatientInfo;
            for (int patientIndex = 0; patientIndex < nPatientCount; patientIndex++)
            {
                PatientData patientObject = new PatientData();
                DataRow row = results.Tables[DataTableHelper.PatientTableName].Rows[patientIndex];

                patientObject.BirthDate = pi.GetElementValue(row, DicomTag.PatientBirthDate);
                patientObject.ID = pi.GetElementValue(row, DicomTag.PatientID);
                patientObject.Name = GetPatientName(row);
                patientObject.Sex = pi.GetElementValue(row, DicomTag.PatientSex);
                patientObject.Comments = pi.GetElementValue(row, DicomTag.PatientComments);
                patientObject.EthnicGroup = pi.GetElementValue(row, DicomTag.EthnicGroup);

                patientObject.NumberOfRelatedStudies = DataTableHelper.StudyRowCount(results).ToString();
                patientObject.NumberOfRelatedSeries = DataTableHelper.SeriesRowCount(results).ToString();
                patientObject.NumberOfRelatedInstances = DataTableHelper.InstanceRowCount(results).ToString();

                matchingPatients[patientIndex] = patientObject;
            }

            return matchingPatients;
        }

        /// <summary>
        /// query the storage server database for series data (series query level)
        /// </summary>
        /// <param name="userName">the name of the user making the query (authorization)</param>
        /// <param name="options">query params</param>
        /// <returns></returns>
        public SeriesData[] FindSeries(string userName, DataContracts.QueryOptions options, int maxQueryResults = 0, bool lightQuery = false)
        {
            //preparing the matching parameters.
            MatchingParameterCollection matchingCollection = AddInsUtils.FillMatchingParametersCombined(options, _searchOtherPatientIds);
            string[] roles = PermissionsDataAccess.GetUserRoles(userName);
            bool enablePatientRestriction = OptionsDataAccess.Get<bool>("EnablePatientRestriction", false);

            DataAccess.EnablePatientRestriction = enablePatientRestriction;

            SetMaxQueryResults(maxQueryResults);
            DataSet results = DataAccess.MinimumQuerySeries(matchingCollection, userName, roles);
            ResetMaxQueryResults();

            int seriesCount = results.Tables[DataTableHelper.SeriesTableName].Rows.Count;
            var matchingSeries = new List<SeriesData>();
            DataRow[] seriesRows = results.Tables[DataTableHelper.SeriesTableName].Select().OrderBy(u =>
            {
                ISeriesInfo si = RegisteredDataRows.SeriesInfo;
                String seriesDate = si.GetElementValue(u, DicomTag.SeriesDate);
                //some series don't have dates!
                if (!string.IsNullOrEmpty(seriesDate))
                {
                    return DateTime.Parse(seriesDate);
                }

                return DateTime.Now;
            }).ToArray();


            //create the series object from the returned results
            for (int SeriesIndex = 0; SeriesIndex < seriesCount; SeriesIndex++)
            {
                SeriesData seriesObject = new SeriesData();
                DataRow row = seriesRows[SeriesIndex];
                ISeriesInfo si = RegisteredDataRows.SeriesInfo;

                seriesObject.Modality = si.GetElementValue(row, DicomTag.Modality);
                if (AddInsUtils.ModalityHasPixelData(seriesObject.Modality))
                {
                    seriesObject.Number = si.GetElementValue(row, DicomTag.SeriesNumber);
                    seriesObject.InstanceUID = si.GetElementValue(row, DicomTag.SeriesInstanceUID);
                    seriesObject.Description = si.GetElementValue(row, DicomTag.SeriesDescription);
                    seriesObject.Date = si.GetElementValue(row, DicomTag.SeriesDate);
                    seriesObject.StudyInstanceUID = si.GetElementValue(row, DicomTag.StudyInstanceUID);


                    if (!lightQuery)
                    {
                        seriesObject.CompleteMRTI = HasCompleteMRTI(results.Tables[DataTableHelper.InstanceTableName], seriesObject.InstanceUID);
                    }


                    if (!lightQuery)
                    {
                        DataRow studyRow = si.GetStudyRow(row);
                        // DataRow patientRow = studyRow.GetParentRow(studyRow.Table.ParentRelations["FK_Patient_Study"]);

                        DataRow patientRow = RegisteredDataRows.StudyInfo.GetPatientRow(studyRow);

                        seriesObject.Patient = new PatientData();
                        seriesObject.Patient.ID = RegisteredDataRows.StudyInfo.GetElementValue(studyRow, DicomTag.PatientID);
                        seriesObject.Patient.Name = GetPatientName(patientRow);
                        seriesObject.Patient.Sex = RegisteredDataRows.PatientInfo.GetElementValue(patientRow, DicomTag.PatientSex);
                        seriesObject.Patient.Comments = RegisteredDataRows.PatientInfo.GetElementValue(patientRow, DicomTag.PatientComments);
                        seriesObject.Patient.BirthDate = RegisteredDataRows.PatientInfo.GetElementValue(patientRow, DicomTag.PatientBirthDate);
                        seriesObject.Patient.EthnicGroup = RegisteredDataRows.PatientInfo.GetElementValue(patientRow, DicomTag.EthnicGroup);

                    }

                    seriesObject.NumberOfRelatedInstances = lightQuery ? "0" : "-1";

                    if (seriesObject.NumberOfRelatedInstances == "-1")
                    {
                        // Reset
                        matchingCollection.Clear();
                        MatchingParameterList matchingList = new MatchingParameterList();
                        matchingCollection.Add(matchingList);
                        matchingList.Clear();

                        ICatalogEntity seriesEntity = RegisteredEntities.GetSeriesEntity(seriesObject.InstanceUID);
                        matchingList.Add(seriesEntity);
                        seriesObject.NumberOfRelatedInstances = DataAccess.FindCompositeInstancesCount(matchingCollection, userName, null).ToString();
                    }

                    matchingSeries.Add(seriesObject);
                }
            }

            return matchingSeries.ToArray();
        }

        StudyData ReadStudyResult(DataRow row)
        {
            IStudyInfo s = null;

            try
            {
                s = RegisteredDataRows.StudyInfo;
            }
            catch (Exception)
            {
            }

            StudyData studyObject = new StudyData();
            studyObject.Patient = new PatientData();

            if (s != null)
            {
                studyObject.Date = s.GetElementValue(row, DicomTag.StudyDate);
                studyObject.InstanceUID = s.GetElementValue(row, DicomTag.StudyInstanceUID);
                studyObject.Id = s.GetElementValue(row, DicomTag.StudyID);
                studyObject.AccessionNumber = s.GetElementValue(row, DicomTag.AccessionNumber);
                studyObject.ReferringPhysiciansName = GetReferDrName(row);
                // modalities in study              
                studyObject.Description = s.GetElementValue(row, DicomTag.StudyDescription);
                // studyObject.NameOfDoctorsReading = s.GetElementValue(row, DicomTag.NameOfPhysicianReadingStudy);
                studyObject.AdmittingDiagnosesDescription = s.GetElementValue(row, DicomTag.AdmittingDiagnosesDescription);
                studyObject.Age = s.GetElementValue(row, DicomTag.PatientAge);
                studyObject.Size = s.GetElementValue(row, DicomTag.PatientSize);
                studyObject.Weight = s.GetElementValue(row, DicomTag.PatientWeight);
                studyObject.AdditionalPatientHistory = s.GetElementValue(row, DicomTag.AdditionalPatientHistory);
            }

            DataRow patientRow = s.GetPatientRow(row);
            IPatientInfo p = RegisteredDataRows.PatientInfo;

            studyObject.Patient.ID = p.GetElementValue(patientRow, DicomTag.PatientID);
            studyObject.Patient.Name = GetPatientName(patientRow);
            studyObject.Patient.Sex = p.GetElementValue(patientRow, DicomTag.PatientSex);
            studyObject.Patient.Comments = p.GetElementValue(patientRow, DicomTag.PatientComments);
            studyObject.Patient.BirthDate = p.GetElementValue(patientRow, DicomTag.PatientBirthDate);
            studyObject.Patient.EthnicGroup = p.GetElementValue(patientRow, DicomTag.EthnicGroup);
            // studyObject.Patient.OtherPatientIds = GetOtherPatientIds(userName, studyObject.Patient.ID);

            return studyObject;
        }

        Dictionary<string, HashSet<string>> GetStudiesModalities(DataRowCollection seriesRows)
        {
            var result = new Dictionary<string, HashSet<string>>();

            try
            {
                var s = RegisteredDataRows.StudyInfo;
                var se = RegisteredDataRows.SeriesInfo;

                if (se != null && s != null)
                {
                    foreach (var row in seriesRows)
                    {
                        var studyRow = se.GetStudyRow((DataRow)row);
                        var studyInstanceUID = s.GetElementValue(studyRow, DicomTag.StudyInstanceUID);
                        var modality = se.GetElementValue((DataRow)row, DicomTag.Modality);

                        if (!string.IsNullOrEmpty(modality) && !string.IsNullOrEmpty(studyInstanceUID))
                        {
                            if (!result.ContainsKey(studyInstanceUID))
                                result.Add(studyInstanceUID, new HashSet<string>());

                            result[studyInstanceUID].Add(modality);
                        }
                    }
                }
            }
            catch
            {
            }

            return result;
        }

        /// <summary>
        /// //Query the storage server database for studies (Study level query)
        /// </summary>
        /// <param name="userName">the name of the user making the query</param>
        /// <param name="options">query parameters</param>
        /// <returns>Returns the study information </returns>
        public StudyData[] FindStudies(string userName, DataContracts.QueryOptions options, int maxQueryResults = 0, bool readModalitiesInStudy = false)
        {
            if (!AddInsUtils.QueryModalitiesHavePixelData(options))
            {
                return new StudyData[0];
            }

            //preparing the matching parameters
            var matchingCollection = AddInsUtils.FillMatchingParametersCombinedForStudies(options, _searchOtherPatientIds);
            var roles = PermissionsDataAccess.GetUserRoles(userName);
            var enablePatientRestriction = OptionsDataAccess.Get<bool>("EnablePatientRestriction", false);

            //setup dataaccess
            SetMaxQueryResults(maxQueryResults);
            DataAccess.EnablePatientRestriction = enablePatientRestriction;

            //query
            DataSet results = null;
            if (!readModalitiesInStudy)
            {
                //faster - not reading modalities
                results = DataAccess.MinimumQueryStudies(matchingCollection, userName, roles);
            }
            else
            {
                // optionally query for modalities in study, this will impact the speed of the API
                // reason for slowness of this option: we will query for series level instead and extract studies form that query result in addition to modalities
                // study level query doesn't have any information about modalities and cant access series from a study level query result

                //slower - but reads modalities
                results = DataAccess.MinimumQuerySeries(matchingCollection, userName, roles);
            }
            ResetMaxQueryResults();

            //read results
            var studyRows = results.StudyRows();
            var matchingStudies = new Dictionary<string, StudyData>();

            var NumberOfRelatedSeries = results.SeriesRowCount();
            var NumberOfRelatedInstances = results.InstanceRowCount();

            foreach (var row in studyRows)
            {
                var studyObject = ReadStudyResult((DataRow)row);
                studyObject.NumberOfRelatedSeries = NumberOfRelatedSeries;
                studyObject.NumberOfRelatedInstances = NumberOfRelatedInstances;

#if DEBUG
                if (matchingStudies.ContainsKey(studyObject.InstanceUID))
                {
                    System.Diagnostics.Debug.Assert(false); //duplicate study instance id
                }
#endif
                matchingStudies.Add(studyObject.InstanceUID, studyObject);
            }

            //fill in modalities in study
            if (readModalitiesInStudy)
            {
                var seriesRows = results.SeriesRows();
                var studiesModalities = GetStudiesModalities(seriesRows);

                foreach (var studyModalities in studiesModalities)
                {
                    if (matchingStudies.ContainsKey(studyModalities.Key))
                    {
                        matchingStudies[studyModalities.Key].ModalitiesInStudy = studyModalities.Value.ToArray();
                    }
                }
            }

            return matchingStudies.Values.OrderBy((x) => x.Date).ToArray();
        }

        private string[] GetUserRolesAddAdmin(string userName)
        {
            const string _administratorPermissionName = "Admin";
            const string _administratorRoleName = "Administrators";
            string[] userRoles = PermissionsDataAccess.GetUserRoles(userName);
            List<string> userRoleList = userRoles.ToList();
            string[] permissions = PermissionsDataAccess.GetUserPermissions(userName);

            if (permissions.Contains(_administratorPermissionName))
            {
                if (false == userRoleList.Contains(_administratorRoleName))
                {
                    userRoleList.Add(_administratorRoleName);
                }
            }

            return userRoleList.ToArray();
        }


        public HangingProtocolQueryResult[] FindHangingProtocols(string userName, string studyInstanceUID, string userData)
        {
            string[] roles = GetUserRolesAddAdmin(userName);

            bool enablePatientRestriction = OptionsDataAccess.Get<bool>("EnablePatientRestriction", false);
            DataSet study = GetStudyDataSet(studyInstanceUID, userName, roles);
            DataRow[] series = study.Tables[DataTableHelper.SeriesTableName].Select("Modality <> 'PR'", "SeriesDate ASC");
            Dictionary<string, HangingProtocolQueryResult> protocols = new Dictionary<string, HangingProtocolQueryResult>();

            DataAccess.EnablePatientRestriction = enablePatientRestriction;

            if (series.Length > 0)
            {
                CompositeInstanceDataSet.StudyRow defaultStudyRow = study.Tables[DataTableHelper.StudyTableName].Rows[0] as CompositeInstanceDataSet.StudyRow;
                CompositeInstanceDataSet.SeriesRow defaultSeriesRow = series[0] as CompositeInstanceDataSet.SeriesRow;
                CompositeInstanceDataSet.InstanceRow[] instanceRows = FindSeriesInstances(userName, roles, defaultSeriesRow.SeriesInstanceUID);

                if (instanceRows.Length > 0)
                {
                    CompositeInstanceDataSet.InstanceRow instanceRow = instanceRows[0];
                    List<HangingProtocolQueryResult> results;

                    results = HangingProtocolUtils.GetVerySpecificProtocols(userName, roles, defaultStudyRow, _dataAccess3);
                    results.ForEach((result) =>
                    {
                        if (!protocols.ContainsKey(result.SOPInstanceUID))
                            protocols.Add(result.SOPInstanceUID, result);
                    });

                    results = HangingProtocolUtils.GetSomeWhatSpecificProtocols(userName, roles, instanceRow, _dataAccess3);
                    results.ForEach((result) =>
                    {
                        if (!protocols.ContainsKey(result.SOPInstanceUID))
                            protocols.Add(result.SOPInstanceUID, result);
                    });

                    results = HangingProtocolUtils.GetGenericProtocols(userName, roles, series, _dataAccess3);
                    results.ForEach((result) =>
                    {
                        if (!protocols.ContainsKey(result.SOPInstanceUID))
                            protocols.Add(result.SOPInstanceUID, result);
                    });
                }
            }

            if (protocols.Count > 0)
                protocols.Values.First().BestMatch = true;

            return protocols.Values.ToArray();
        }

        public CompositeInstanceDataSet.ReasonForRequestedProcedureCodeSequenceRow[] GetReasonForRequestedProcedureRows(CompositeInstanceDataSet.SeriesRow seriesRow)
        {
            if ((seriesRow.Table.ChildRelations["FK_ReasonForRequestedProcedureCodeSequence_Series"] == null))
            {
                return new CompositeInstanceDataSet.ReasonForRequestedProcedureCodeSequenceRow[0];
            }
            else
            {
                return ((CompositeInstanceDataSet.ReasonForRequestedProcedureCodeSequenceRow[])(seriesRow.GetChildRows(seriesRow.Table.ChildRelations["FK_ReasonForRequestedProcedureCodeSequence_Series"])));
            }
        }

        public CompositeInstanceDataSet.AnatomicRegionSequenceRow[] GetAnatomicRegionSequenceRows(CompositeInstanceDataSet.InstanceRow instanceRow)
        {
            if ((instanceRow.Table.ChildRelations["FK_AnatomicRegionSequence_Instance"] == null))
            {
                return new CompositeInstanceDataSet.AnatomicRegionSequenceRow[0];
            }
            else
            {
                return ((CompositeInstanceDataSet.AnatomicRegionSequenceRow[])(instanceRow.GetChildRows(instanceRow.Table.ChildRelations["FK_AnatomicRegionSequence_Instance"])));
            }
        }

        public CompositeInstanceDataSet.InstanceRow[] FindSeriesInstances(string userName, string[] roles, string seriesInstanceUID)
        {
            //preparing the matching parameters
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();
            Series series = new Series(seriesInstanceUID);
            CompositeInstanceDataSet results;

            matchingList.Add(series);
            matchingCollection.Add(matchingList);
            results = DataAccess.MinimumQueryCompositeInstances(matchingCollection, userName, roles) as CompositeInstanceDataSet;

            return (CompositeInstanceDataSet.InstanceRow[])results.Instance.Rows.Cast<CompositeInstanceDataSet.InstanceRow>().ToArray();
        }

        private DataSet GetStudyDataSet(string studyInstanceUID, string userName, string[] roles)
        {
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList mpList = new MatchingParameterList();
            Study study = new Study(studyInstanceUID);

            mpList.Add(study);
            matchingCollection.Add(mpList);

            return DataAccess.QuerySeries(matchingCollection, userName, roles);
        }

        public WordResult[] AutoComplete(string user, string key, string term, string userData)
        {
            switch (key.ToLower())
            {
                case "patientid":
                    return GetPatientIDs(user, "*" + term + "*");
                case "patientname":
                    return GetPatientNames(user, term);
                case "study":
                    break;
                case "series":
                    break;
            }
            return new List<WordResult>().ToArray();
        }

        private WordResult[] GetPatientIDs(string user, string patientId)
        {
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();
            Patient p = new Patient(patientId);
            DataSet results = null;
            int patientCount = 0;
            List<WordResult> words = new List<WordResult>();
            string[] roles = PermissionsDataAccess.GetUserRoles(user);
            bool enablePatientRestriction = OptionsDataAccess.Get<bool>("EnablePatientRestriction", false);

            DataAccess.EnablePatientRestriction = enablePatientRestriction;

            matchingList.Add(p);
            matchingCollection.Add(matchingList);

            results = DataAccess.QueryPatients(matchingCollection, user, roles);
            patientCount = results.Tables[DataTableHelper.PatientTableName].Rows.Count;
            if (patientCount > 0)
            {
                //create the custom patient objects from the returned results.
                IPatientInfo pi = RegisteredDataRows.PatientInfo;
                for (int patientIndex = 0; patientIndex < patientCount; patientIndex++)
                {
                    WordResult word = new WordResult();
                    DataRow row = results.Tables[DataTableHelper.PatientTableName].Rows[patientIndex];

                    word.Word = pi.GetElementValue(row, DicomTag.PatientID);
                    word.Length = word.Word.Length;
                    words.Add(word);
                }
            }
            return words.ToArray();
        }

        private WordResult[] GetPatientNames(string user, string patientName)
        {
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();
            Patient p = new Patient();
            DataSet results = null;
            int patientCount = 0;
            List<WordResult> words = new List<WordResult>();
            PersonNameComponents patientNameComponent = AddInsUtils.ParseName(patientName);
            string[] roles = PermissionsDataAccess.GetUserRoles(user);
            bool enablePatientRestriction = OptionsDataAccess.Get<bool>("EnablePatientRestriction", false);

            DataAccess.EnablePatientRestriction = enablePatientRestriction;

            p.FamilyName = !string.IsNullOrEmpty(patientNameComponent.FamilyName) ? "*" + patientNameComponent.FamilyName + "*" : "*";
            p.GivenName = !string.IsNullOrEmpty(patientNameComponent.GivenName) ? "*" + patientNameComponent.GivenName + "*" : "*";
            p.MiddleName = !string.IsNullOrEmpty(patientNameComponent.MiddleName) ? "*" + patientNameComponent.MiddleName + "*" : "*";
            p.NamePrefix = !string.IsNullOrEmpty(patientNameComponent.NamePrefix) ? "*" + patientNameComponent.NamePrefix + "*" : "*";
            p.NameSuffix = !string.IsNullOrEmpty(patientNameComponent.NameSuffix) ? "*" + patientNameComponent.NameSuffix + "*" : "*";

            matchingList.Add(p);
            matchingCollection.Add(matchingList);

            results = DataAccess.QueryPatients(matchingCollection, user, roles);
            patientCount = results.Tables[DataTableHelper.PatientTableName].Rows.Count;
            if (patientCount > 0)
            {
                //create the custom patient objects from the returned results.
                IPatientInfo pi = RegisteredDataRows.PatientInfo;
                for (int patientIndex = 0; patientIndex < patientCount; patientIndex++)
                {
                    WordResult word = new WordResult();
                    DataRow row = results.Tables[DataTableHelper.PatientTableName].Rows[patientIndex];
                    PersonNameComponent name = pi.Name(row);

                    word.Word = string.Join(" ", new string[] { name.FamilyName, name.GivenName, name.NameSuffix }).Trim();
                    if (string.IsNullOrEmpty(name.GivenName) && string.IsNullOrEmpty(name.NameSuffix))
                    {
                        if (word.Word.Trim().Contains(" "))
                        {
                            word.Word = "\"" + word.Word + "\"";
                        }
                    }
                    word.Length = word.Word.Length;
                    words.Add(word);
                }
            }
            return words.ToArray();
        }

        /// <summary>
        /// returns a DICOM formatted patient name from DB fields 
        /// </summary>
        /// <param name="patientRow">Patient row returned from database</param>
        /// <returns>DICOM formatted Person Name</returns>
        private string GetPatientName(DataRow patientRow)
        {
            string name = string.Empty;

            IPatientInfo pi = RegisteredDataRows.PatientInfo;
            PersonNameComponent pn = pi.Name(patientRow);

            string familyName = pn.FamilyName;
            string givenName = pn.GivenName;
            string middleName = pn.MiddleName;
            string namePrefix = pn.NamePrefix;
            string nameSuffix = pn.NameSuffix;

            if (!string.IsNullOrEmpty(familyName))
            {
                name += familyName;
            }
            name += "^";

            if (!string.IsNullOrEmpty(givenName))
            {
                name += givenName;
            }
            name += "^";

            if (!string.IsNullOrEmpty(middleName))
            {
                name += middleName;
            }
            name += "^";

            if (!string.IsNullOrEmpty(namePrefix))
            {
                name += namePrefix;
            }
            name += "^";

            if (!string.IsNullOrEmpty(nameSuffix))
            {
                name += nameSuffix;
            }

            return name.TrimEnd('^');
        }

        /// <summary>
        /// Returns DICOM formatted ref. Dr. Name from database fields
        /// </summary>
        /// <param name="studyRow">Ref. Dr. row returned from database</param>
        /// <returns>DICOM formatted Person Name</returns>
        private string GetReferDrName(DataRow studyRow)
        {
            string name = string.Empty;

            PersonNameComponent pn = RegisteredDataRows.StudyInfo.ReferringPhysiciansName(studyRow);

            if (!string.IsNullOrEmpty(pn.FamilyName))
            {
                name += pn.FamilyName + "^";
            }

            if (!string.IsNullOrEmpty(pn.GivenName))
            {
                name += pn.GivenName + "^";
            }

            if (!string.IsNullOrEmpty(pn.MiddleName))
            {
                name += pn.MiddleName + "^";
            }

            if (!string.IsNullOrEmpty(pn.NamePrefix))
            {
                name += pn.NamePrefix + "^";
            }

            if (!string.IsNullOrEmpty(pn.NameSuffix))
            {
                name += pn.NameSuffix;
            }

            return name.TrimEnd('^');
        }

        private DataRow GetFirstSeriesInstanceRow(string seriesInstanceUID, string userName, string[] roles)
        {
            Series series = new Series(seriesInstanceUID);
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();

            matchingList.Add(series);
            matchingCollection.Add(matchingList);

            DataSet result = DataAccess.MinimumQueryCompositeInstances(matchingCollection, userName, roles);

            if (result.Tables[DataTableHelper.InstanceTableName].Rows.Count > 0)
            {
                return result.Tables[DataTableHelper.InstanceTableName].Rows[0];
            }
            else
            {
                return null;
            }
        }

        internal bool HasCompleteMRTI(DataTable instances, string seriesInstanceUID)
        {
            if (instances != null)
            {
                if (instances.Rows.Count > 0)
                {
                    //using linq:
                    //var match = instances.AsEnumerable().Any(p => p.Field<string>("SeriesInstanceUID") == seriesInstanceUID);
                    var matches = instances.Select("SeriesInstanceUID = '" + seriesInstanceUID + "'");

                    if (matches.Length > 0)
                    {
                        var referencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(matches[0]);

                        if (!string.IsNullOrEmpty(referencedFile))
                        {
                            using (var dicomSourceProxy = new DicomSourceProxy(DataCache))
                            {
                                var query = new ViewImageQuery() { FileName = referencedFile };
                                return !dicomSourceProxy.EstimatedLongLoad(query);
                            }
                        }
                    }
                }
            }
            return true;
        }

        //deprecated
        internal bool HasCompleteMRTI(string seriesInstanceUID, string userName)
        {
            string[] roles = PermissionsDataAccess.GetUserRoles(userName);
            DataRow instanceRow = GetFirstSeriesInstanceRow(seriesInstanceUID, userName, roles);

            if (instanceRow != null)
            {
                var referencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(instanceRow);

                if (!string.IsNullOrEmpty(referencedFile))
                {
                    using (var dicomSourceProxy = new DicomSourceProxy(DataCache))
                    {
                        var query = new ViewImageQuery() { FileName = referencedFile };
                        return !dicomSourceProxy.EstimatedLongLoad(query);
                    }
                }
            }
            return true;
        }
    }

    public class SeriesImageCountEntity : CatalogEntity
    {
        public override string CatalogKey
        {
            get
            {
                return "SeriesImageCount";
            }
        }

        [EntityElement]
        public string SeriesInstanceUID { get; set; }

        [EntityElement]
        public int imagecount { get; set; }
    }
}
