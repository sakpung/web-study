// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Medical;
using System.Xml;
using System.Security;
using System.Diagnostics;
using System.Drawing;
using System.Configuration;
using System.IO;
using Leadtools.Drawing;
using System.Xml.Linq;
using Leadtools.Medical.WebViewer.Addins;
using Leadtools.ImageProcessing;
using System.Reflection;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Annotations.Engine;
using System.Web.Script.Serialization;
using Leadtools.Annotations.Rendering;
using Leadtools.ImageProcessing.Core;
using ImageBox = Leadtools.Dicom.Common.DataTypes.ImageBox;
using Patient = Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters.Patient;
using ScheduledProcedureStep = Leadtools.Dicom.Common.DataTypes.ScheduledProcedureStep;
using Leadtools.Annotations.WinForms;
using Leadtools.Medical.DataAccessLayer.Catalog;
using System.Data;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;
using Leadtools.Medical.Storage.DataAccessLayer.Interface;
using System.Collections;

#if TUTORIAL_CUSTOM_DATABASE
using My.Medical.Storage.DataAccessLayer.Entities;
#endif

namespace Leadtools.Medical.WebViewer.Addins.Common
{
    class DicomSortImageDataEx : DicomSortImageData
    {
        public int NumberOfFrames;
        public DicomSortImageDataEx() : base()
        {

        }
    }
    public class MyOtherPatientIDs : CatalogEntity
    {
        public MyOtherPatientIDs()
        {
        }

        [EntityElement]
        public DateRange BirthDate { get; set; }
        public override string CatalogKey
        {
            get
            {
                return "OtherPatientIDs";
            }
        }
        [EntityElement]
        public string OtherPatientID { get; set; }
    }


    static class AddInsUtils
    {
        
#if TUTORIAL_CUSTOM_DATABASE
      // This version of FillMatchingParameters is part of the "Changing the LEAD HTML5 Medical Viewer to use a different database schema" tutorial
      // It fills the properties of custom classes (i.e MyPatient, MyStudy, MySeries, and MyInstance)
      // that correspond 'matchingList'.
      // For more details, see the "Changing the LEAD HTML5 Medical Viewer to use a different database schema" tutorial.
      public static void FillMatchingParameters(QueryOptions query, MatchingParameterList matchingList)
      {
         // if we have patient options then create a DB Patient object for matching and copy the values
         if ((query.PatientsOptions != null) && (
              !string.IsNullOrEmpty(query.PatientsOptions.PatientID) ||
              !string.IsNullOrEmpty(query.PatientsOptions.PatientName)))
         {
            MyPatient patient = new MyPatient();

            patient.PatientIdentification = (!string.IsNullOrEmpty(query.PatientsOptions.PatientID)) ? query.PatientsOptions.PatientID : null;

            if (!string.IsNullOrEmpty(query.PatientsOptions.PatientName))
            {
               patient.PatientName = query.PatientsOptions.PatientName;
            }

            matchingList.Add(patient);
         }

         // if we have study options then create a DB study object for matching and copy the values
         if ((query.StudiesOptions != null) && (
              !string.IsNullOrEmpty(query.StudiesOptions.AccessionNumber) ||
              !string.IsNullOrEmpty(query.StudiesOptions.ReferDoctorName) ||
              !string.IsNullOrEmpty(query.StudiesOptions.StudyDateStart) ||
              !string.IsNullOrEmpty(query.StudiesOptions.StudyDateEnd) ||
              !string.IsNullOrEmpty(query.StudiesOptions.StudyID) ||
              !string.IsNullOrEmpty(query.StudiesOptions.StudyInstanceUID) ||
              ( query.StudiesOptions.ModalitiesInStudy != null && query.StudiesOptions.ModalitiesInStudy.Length >0 ) ))
         {
            MyStudy study = new MyStudy();

            study.StudyAccessionNumber  = (!string.IsNullOrEmpty(query.StudiesOptions.AccessionNumber)) ? query.StudiesOptions.AccessionNumber : null;
            study.StudyStudyId= (!string.IsNullOrEmpty(query.StudiesOptions.StudyID)) ? query.StudiesOptions.StudyID : null;
            study.StudyStudyInstanceUID = (!string.IsNullOrEmpty(query.StudiesOptions.StudyInstanceUID)) ? query.StudiesOptions.StudyInstanceUID : null;

            if (!string.IsNullOrEmpty(query.StudiesOptions.ReferDoctorName))
            {
               study.StudyReferringPhysiciansName = query.StudiesOptions.ReferDoctorName;
            }

            if (!string.IsNullOrEmpty(query.StudiesOptions.StudyDateStart) || !string.IsNullOrEmpty(query.StudiesOptions.StudyDateEnd))
            {
               study.StudyStudyDate = new DateRange();

               AddInsUtils.FillDateRangeInfo(query.StudiesOptions.StudyDateStart, query.StudiesOptions.StudyDateEnd, study.StudyStudyDate);
            }

            matchingList.Add(study);

            if ( query.StudiesOptions.ModalitiesInStudy != null && query.StudiesOptions.ModalitiesInStudy.Length >0 ) 
            {
               MySeries series = new MySeries ( ) ;
               series.SeriesModality= string.Join ( "\\", query.StudiesOptions.ModalitiesInStudy ) ;
               matchingList.Add ( series ) ;
            }
         }

         if ((query.SeriesOptions != null) && (
              !string.IsNullOrEmpty(query.SeriesOptions.SeriesInstanceUID) ||
              !string.IsNullOrEmpty(query.SeriesOptions.SeriesNumber) ||
              (null != query.SeriesOptions.Modality)))
         {
            MySeries series = new MySeries();
            series.SeriesSeriesInstanceUID = (!string.IsNullOrEmpty(query.SeriesOptions.SeriesInstanceUID)) ? query.SeriesOptions.SeriesInstanceUID : null;
            series.SeriesSeriesNumber = (!string.IsNullOrEmpty(query.SeriesOptions.SeriesNumber)) ? query.SeriesOptions.SeriesNumber : null;

            if (!string.IsNullOrEmpty(query.SeriesOptions.Modality))
            {
               series.SeriesModality = query.SeriesOptions.Modality;
            }

            matchingList.Add(series);
         }

         if ( ( null != query.InstancesOptions  ) && (
              !string.IsNullOrEmpty ( query.InstancesOptions.InstanceNumber ) ||
              !string.IsNullOrEmpty ( query.InstancesOptions.SOPInstanceUID ) ) )
         {
            MyInstance instance = new MyInstance();

            instance.SOPInstanceUID = (!string.IsNullOrEmpty(query.InstancesOptions.SOPInstanceUID)) ? query.InstancesOptions.SOPInstanceUID : null;
            string sImageNumber = (!string.IsNullOrEmpty(query.InstancesOptions.InstanceNumber)) ? query.InstancesOptions.InstanceNumber : null;
            
            int nImageNumber = 0;
            if (int.TryParse(sImageNumber, out nImageNumber))
            {
               instance.ImageImageNumber = nImageNumber;
            }

            matchingList.Add(instance);
         }
      }
#else
        public static void FillMatchingParameters(QueryOptions query, MatchingParameterList matchingList)
        {
            if (query == null)
            {
                query = new QueryOptions();
            }

            //if we have patient options then create a DB Patient object for matching and copy the values
            if ((query.PatientsOptions != null) && (
                 !string.IsNullOrEmpty(query.PatientsOptions.PatientID) ||
                 !string.IsNullOrEmpty(query.PatientsOptions.PatientName)))
            {
                Patient patient = new Patient();

                patient.PatientID = (!string.IsNullOrEmpty(query.PatientsOptions.PatientID)) ? query.PatientsOptions.PatientID : null;

                if (!string.IsNullOrEmpty(query.PatientsOptions.PatientName))
                {
                    PersonNameComponents patientNameComponent = AddInsUtils.ParseName(query.PatientsOptions.PatientName);

                    patient.FamilyName = patientNameComponent.FamilyName;
                    patient.GivenName = patientNameComponent.GivenName;
                    patient.MiddleName = patientNameComponent.MiddleName;
                    patient.NamePrefix = patientNameComponent.NamePrefix;
                    patient.NameSuffix = patientNameComponent.NameSuffix;
                }

                matchingList.Add(patient);
            }

            //if we have study options then create a DB study object for matching and copy the values
            if ((query.StudiesOptions != null) && (
                 !string.IsNullOrEmpty(query.StudiesOptions.AccessionNumber) ||
                 !string.IsNullOrEmpty(query.StudiesOptions.ReferDoctorName) ||
                 !string.IsNullOrEmpty(query.StudiesOptions.StudyDateStart) ||
                 !string.IsNullOrEmpty(query.StudiesOptions.StudyDateEnd) ||
                 !string.IsNullOrEmpty(query.StudiesOptions.StudyID) ||
                 !string.IsNullOrEmpty(query.StudiesOptions.StudyInstanceUID) ||
                 (query.StudiesOptions.ModalitiesInStudy != null && query.StudiesOptions.ModalitiesInStudy.Length > 0)))
            {
                Study study = new Study();

                study.AccessionNumber = (!string.IsNullOrEmpty(query.StudiesOptions.AccessionNumber)) ? query.StudiesOptions.AccessionNumber : null;
                study.StudyID = (!string.IsNullOrEmpty(query.StudiesOptions.StudyID)) ? query.StudiesOptions.StudyID : null;
                study.StudyInstanceUID = (!string.IsNullOrEmpty(query.StudiesOptions.StudyInstanceUID)) ? query.StudiesOptions.StudyInstanceUID : null;

                if (!string.IsNullOrEmpty(query.StudiesOptions.ReferDoctorName))
                {
                    PersonNameComponents referDrNameComponent = AddInsUtils.ParseName(query.StudiesOptions.ReferDoctorName);

                    study.ReferDrFamilyName = referDrNameComponent.FamilyName;
                    study.ReferDrGivenName = referDrNameComponent.GivenName;
                    study.ReferDrMiddleName = referDrNameComponent.MiddleName;
                    study.ReferDrNamePrefix = referDrNameComponent.NamePrefix;
                    study.ReferDrNameSuffix = referDrNameComponent.NameSuffix;
                }

                if (!string.IsNullOrEmpty(query.StudiesOptions.StudyDateStart) || !string.IsNullOrEmpty(query.StudiesOptions.StudyDateEnd))
                {
                    study.StudyDate = new DateRange();

                    AddInsUtils.FillDateRangeInfo(query.StudiesOptions.StudyDateStart, query.StudiesOptions.StudyDateEnd, study.StudyDate);
                }

                matchingList.Add(study);

                if (query.StudiesOptions.ModalitiesInStudy != null && query.StudiesOptions.ModalitiesInStudy.Length > 0)
                {
                    Series series = new Series();

                    //use the following line of code to not allow PR and other none-pixel data modalities
                    //var modalities = query.StudiesOptions.ModalitiesInStudy.Where(m => ModalityHasPixelData(m));
                    var modalities = query.StudiesOptions.ModalitiesInStudy;
                    series.Modality = string.Join("\\", modalities);

                    matchingList.Add(series);
                }
            }

            //if we have series options then create a DB series object for matching and copy the values
            if ((query.SeriesOptions != null) && (
                 !string.IsNullOrEmpty(query.SeriesOptions.SeriesInstanceUID) ||
                 !string.IsNullOrEmpty(query.SeriesOptions.SeriesNumber) ||
                 !string.IsNullOrEmpty(query.SeriesOptions.SeriesDateStart) ||
                 !string.IsNullOrEmpty(query.SeriesOptions.SeriesDateEnd) ||
                 !string.IsNullOrEmpty(query.SeriesOptions.SeriesDescription) ||
                 (null != query.SeriesOptions.Modality)))
            {
                Series series = new Series();

                series.SeriesInstanceUID = (!string.IsNullOrEmpty(query.SeriesOptions.SeriesInstanceUID)) ? query.SeriesOptions.SeriesInstanceUID : null;
                series.SeriesNumber = (!string.IsNullOrEmpty(query.SeriesOptions.SeriesNumber)) ? query.SeriesOptions.SeriesNumber : null;
                series.SeriesDescription = (!string.IsNullOrEmpty(query.SeriesOptions.SeriesDescription)) ? query.SeriesOptions.SeriesDescription : null;

                if (!string.IsNullOrEmpty(query.SeriesOptions.Modality))
                {
                   //use the following line of code to not allow PR and other none-pixel data modalities
                   //if (ModalityHasPixelData(query.SeriesOptions.Modality))
                   {
                      series.Modality = query.SeriesOptions.Modality;
                   }
                }

                if (!string.IsNullOrEmpty(query.SeriesOptions.SeriesDateStart) || !string.IsNullOrEmpty(query.SeriesOptions.SeriesDateEnd))
                {
                    series.SeriesDate = new DateRange();
                    AddInsUtils.FillDateRangeInfo(query.SeriesOptions.SeriesDateStart, query.SeriesOptions.SeriesDateEnd, series.SeriesDate);
                }

                matchingList.Add(series);
            }

            //if we have instance options then create a DB instance object for matching and copy the values
            if ((null != query.InstancesOptions) && (
                 !string.IsNullOrEmpty(query.InstancesOptions.InstanceNumber) ||
                 !string.IsNullOrEmpty(query.InstancesOptions.SOPInstanceUID)))
            {
                Instance instance = new Instance();

                instance.SOPInstanceUID = (!string.IsNullOrEmpty(query.InstancesOptions.SOPInstanceUID)) ? query.InstancesOptions.SOPInstanceUID : null;
                instance.ImageNumber = (!string.IsNullOrEmpty(query.InstancesOptions.InstanceNumber)) ? query.InstancesOptions.InstanceNumber : null;

                matchingList.Add(instance);
            }
        }
#endif // TUTORIAL_CUSTOM_DATABASE   


        public static MatchingParameterCollection FillMatchingParametersCombined(QueryOptions query, bool searchOtherPatientIds)
        {
           var matchingCollection = new MatchingParameterCollection();

           {
              var matchingList = new MatchingParameterList();            
              AddInsUtils.FillMatchingParameters(query, matchingList);
              matchingCollection.Add(matchingList);
           }

           if (searchOtherPatientIds)
           {
              if ((query.PatientsOptions != null) && (!string.IsNullOrEmpty(query.PatientsOptions.PatientID)))
              {
                 var matchingListOtherPatientIDs = new MatchingParameterList();

                 AddInsUtils.FillMatchingParametersOtherPatientIDs(query, matchingListOtherPatientIDs);
                 matchingCollection.Add(matchingListOtherPatientIDs);
              }
           }

           return matchingCollection;
        }

        public static MatchingParameterCollection FillMatchingParametersCombinedForStudies(QueryOptions query, bool searchOtherPatientIds)
        {
           var matchingCollection = new MatchingParameterCollection();

           {
              var matchingList = new MatchingParameterList();
              AddInsUtils.FillMatchingParameters(query, matchingList);
              matchingCollection.Add(matchingList);
           }

           if (searchOtherPatientIds)
           {
              if ((query.PatientsOptions != null) && (!string.IsNullOrEmpty(query.PatientsOptions.PatientID)))
              {
                 var matchingListOtherPatientIDs = new MatchingParameterList();

                 AddInsUtils.FillMatchingParametersOtherPatientIDs(query, matchingListOtherPatientIDs);
                 matchingCollection.Add(matchingListOtherPatientIDs);
              }
           }

           //because query fields are (or)ed 
           //we will add modality filtering only when no query field is requested
           if (!QueryIsSpecific(matchingCollection))
           {
              
              AddInsUtils.FillMatchingParametersModalitiesWithImages(matchingCollection);
           }

           return matchingCollection;
        }

        private static bool QueryIsSpecific(MatchingParameterCollection matchingCollection)
        {
           return matchingCollection.Count > 0;
        }

        public static bool QueryModalitiesHavePixelData(QueryOptions query)
        {
           if (query == null)
           {
              query = new QueryOptions();
           }

           if ((query.StudiesOptions != null) && (
               (query.StudiesOptions.ModalitiesInStudy != null && query.StudiesOptions.ModalitiesInStudy.Length > 0)))
           {
              var haspixeldata = query.StudiesOptions.ModalitiesInStudy.Any(m => ModalityHasPixelData(m));

              return haspixeldata;
           }
           else if ((query.SeriesOptions != null) && (null != query.SeriesOptions.Modality))
           {
              return ModalityHasPixelData(query.SeriesOptions.Modality);
           }

           return true;//broad search, assume true
        }

        public static void FillMatchingParametersOtherPatientIDs(QueryOptions query, MatchingParameterList matchingList)
        {
            if (!string.IsNullOrEmpty(query.PatientsOptions.PatientID))
            {
                MyOtherPatientIDs otherPatientIDs = new MyOtherPatientIDs();
                otherPatientIDs.OtherPatientID = query.PatientsOptions.PatientID;
                matchingList.Add(otherPatientIDs);

                // Add all other parameters except PatientID
                string oldPatientId = query.PatientsOptions.PatientID;
                query.PatientsOptions.PatientID = string.Empty;
                FillMatchingParameters(query, matchingList);
                query.PatientsOptions.PatientID = oldPatientId;
            }
        }

       static MatchingParameterList[] _matchingListModalities = null;

       static MatchingParameterList ModalityMatching(string modality)
       {
          var mpl = new MatchingParameterList();
          mpl.Add(new Series() { Modality = modality });
          return mpl;
       }

       static void Startup()
       {
          if (_matchingListModalities == null)
           {
              var matchingListModalities = new List<MatchingParameterList>();

              matchingListModalities.Add(ModalityMatching("CR"));
              matchingListModalities.Add(ModalityMatching("CT"));
              matchingListModalities.Add(ModalityMatching("MR"));
              matchingListModalities.Add(ModalityMatching("NM"));
              matchingListModalities.Add(ModalityMatching("US"));
              matchingListModalities.Add(ModalityMatching("OT"));
              matchingListModalities.Add(ModalityMatching("BI"));
              matchingListModalities.Add(ModalityMatching("CD"));
              matchingListModalities.Add(ModalityMatching("DD"));
              matchingListModalities.Add(ModalityMatching("DG"));
              matchingListModalities.Add(ModalityMatching("ES"));
              matchingListModalities.Add(ModalityMatching("LS"));
              matchingListModalities.Add(ModalityMatching("PT"));
              matchingListModalities.Add(ModalityMatching("RG"));
              matchingListModalities.Add(ModalityMatching("ST"));
              matchingListModalities.Add(ModalityMatching("TG"));
              matchingListModalities.Add(ModalityMatching("XA"));
              matchingListModalities.Add(ModalityMatching("RF"));
              matchingListModalities.Add(ModalityMatching("RTIMAGE"));
              matchingListModalities.Add(ModalityMatching("RTDOSE"));
              matchingListModalities.Add(ModalityMatching("RTSTRUCT"));
              matchingListModalities.Add(ModalityMatching("RTPLAN"));
              matchingListModalities.Add(ModalityMatching("RTRECORD"));
              matchingListModalities.Add(ModalityMatching("HC"));
              matchingListModalities.Add(ModalityMatching("DX"));
              matchingListModalities.Add(ModalityMatching("MG"));
              matchingListModalities.Add(ModalityMatching("IO"));
              matchingListModalities.Add(ModalityMatching("PX"));
              matchingListModalities.Add(ModalityMatching("GM"));
              matchingListModalities.Add(ModalityMatching("SM"));
              matchingListModalities.Add(ModalityMatching("XC"));
              matchingListModalities.Add(ModalityMatching("AU"));
              matchingListModalities.Add(ModalityMatching("ECG"));
              matchingListModalities.Add(ModalityMatching("EPS"));
              matchingListModalities.Add(ModalityMatching("HD"));
              matchingListModalities.Add(ModalityMatching("SR"));
              matchingListModalities.Add(ModalityMatching("IVUS"));
              matchingListModalities.Add(ModalityMatching("DS"));
              matchingListModalities.Add(ModalityMatching("CF"));
              matchingListModalities.Add(ModalityMatching("DF"));
              matchingListModalities.Add(ModalityMatching("VF"));
              matchingListModalities.Add(ModalityMatching("AS"));
              matchingListModalities.Add(ModalityMatching("CS"));
              matchingListModalities.Add(ModalityMatching("EC"));
              matchingListModalities.Add(ModalityMatching("LP"));
              matchingListModalities.Add(ModalityMatching("FA"));
              matchingListModalities.Add(ModalityMatching("CP"));
              matchingListModalities.Add(ModalityMatching("DM"));
              matchingListModalities.Add(ModalityMatching("FS"));
              matchingListModalities.Add(ModalityMatching("MA"));
              matchingListModalities.Add(ModalityMatching("MS"));

              _matchingListModalities = matchingListModalities.ToArray(); 
           }
       }

       public static bool ModalityHasPixelData(string name)
       {
          return !String.Equals(name, "PR", StringComparison.OrdinalIgnoreCase) && 
             !String.Equals(name, "SD", StringComparison.OrdinalIgnoreCase) && 
             !String.Equals(name, "KO", StringComparison.OrdinalIgnoreCase) &&
             !String.Equals(name, "SR", StringComparison.OrdinalIgnoreCase);
       }

       static AddInsUtils()
       {
          Startup();          
       }

        public static void FillMatchingParametersModalitiesWithImages(MatchingParameterCollection matchingCollection)
        {  
           foreach (var mlm in _matchingListModalities)
           {
              matchingCollection.Add(mlm);
           }
        }

        /// <summary>
        /// Create a DateRange structure from a matching start and end date
        /// </summary>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="dateRange"></param>
        public static void FillDateRangeInfo(string dateStart, string dateEnd, DateRange dateRange)
        {
            if (!string.IsNullOrEmpty(dateStart) || !string.IsNullOrEmpty(dateEnd))
            {
                dateRange.StartDate = (string.IsNullOrEmpty(dateStart) ? DateTime.MinValue : DateTime.Parse(dateStart));
                dateRange.EndDate = (string.IsNullOrEmpty(dateEnd) ? DateTime.MaxValue : DateTime.Parse(dateEnd));
            }
        }

        /// <summary>
        /// Convert a DICOM formatted name into its five components (Family, Given, Middle, Prefix and suffix)
        /// </summary>
        /// <param name="personName"></param>
        /// <returns></returns>
        public static PersonNameComponents ParseName(string personName)
        {
            PersonNameComponents nameComponent = new PersonNameComponents();

            if (string.IsNullOrEmpty(personName))
            {
                return nameComponent;
            }

            string[] components = personName.Split('^');

            if (components.Length > 0)
            {
                nameComponent.FamilyName = components[0];
            }

            if (components.Length > 1)
            {
                nameComponent.GivenName = components[1];
            }

            if (components.Length > 2)
            {
                nameComponent.MiddleName = components[2];
            }

            if (components.Length > 3)
            {
                nameComponent.NamePrefix = components[3];
            }

            if (components.Length > 4)
            {
                nameComponent.NameSuffix = components[4];
            }

            return nameComponent;
        }

        /// <summary>
        /// Writes a DICOM DataSet as XML. We are not using the built in XML conversion because this is more optimized for our case.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="xmlWriter"></param>
        public static void ToXml(this DicomDataSet ds, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("dataset");
            DicomElement element = ds.GetFirstElement(null, true, true);

            while (element != null)
            {
                SaveXmlElement(ds, xmlWriter, element);
                element = ds.GetNextElement(element, true, true);
            }

            xmlWriter.WriteEndElement();
        }

        private static UInt16 GetGroup(this long tag)
        {
            return ((UInt16)(tag >> 16));
        }

        private static int GetElement(this long tag)
        {
            return ((UInt16)(tag & 0xFFFF));
        }

        public static RasterImage CreateLayoutImage(int width, bool whiteBackground)
        {
            int destinationHeight;
            RectangleF destinationRect;
            RectangleF layoutDestinationRect;
            int screenWidth = ConfigurationManager.AppSettings["ScreenWidth"].Length > 0 ? Convert.ToInt32(ConfigurationManager.AppSettings["ScreenWidth"]) : 1920;
            int screenHeight = ConfigurationManager.AppSettings["ScreenHeight"].Length > 0 ? Convert.ToInt32(ConfigurationManager.AppSettings["ScreenHeight"]) : 1200;

            destinationHeight = (width * screenHeight) / screenWidth;
            destinationRect = new Rectangle(0, 0, width, destinationHeight);
            layoutDestinationRect = destinationRect;

            RasterImage image = new RasterImage(RasterMemoryFlags.Conventional, Convert.ToInt32(destinationRect.Width), Convert.ToInt32(destinationRect.Height), 24,
                                              RasterByteOrder.Bgr, RasterViewPerspective.TopLeft, null, null, 0);
            FillCommand fill = new FillCommand();
            if (whiteBackground)
                fill.Color = RasterColor.White;
            else
                fill.Color = RasterColor.Black;
            fill.Run(image);

            return image;
        }

        public static void LayoutImage(RasterImage image, RasterImage dcmImage, Leadtools.Medical.WebViewer.DataContracts.ImageBox box)
        {
            if (dcmImage == null)
                return;

            RectangleF layoutDestinationRect = new RectangleF(0, 0, image.Width, image.Height);

            using (RasterGraphics rasterG = RasterImagePainter.CreateGraphics(image))
            {
                using (Graphics g = rasterG.Graphics)
                {
                    RectangleF sourceRect = new RectangleF(0, 0, 1, 1);
                    Point lt = sourceRect.Transform(new PointF((float)box.Position.leftTop.X, (float)box.Position.leftTop.Y), layoutDestinationRect);
                    Point rb = sourceRect.Transform(new PointF((float)box.Position.rightBottom.X, (float)box.Position.rightBottom.Y), layoutDestinationRect);
                    int boxWidth = (int)Math.Abs(rb.X - lt.X);
                    int boxHeight = (int)Math.Abs(rb.Y - lt.Y);
                    Rectangle boxRect = new Rectangle(lt.X, Math.Abs(lt.Y), boxWidth, boxHeight);

                    ColorResImage(dcmImage);
                    PaintImage(dcmImage, boxRect, g);
                }
            }
        }

        public static RasterImage LayoutToImage(Dictionary<string, DicomDataSet> datasets, Layout layout, bool burnAnnotations, int width, IQueryAddin queryAddin, IObjectRetrieveAddin retrieveAddin, string userName)
        {
            int destinationHeight;
            RectangleF destinationRect;
            RectangleF sourceRect = new RectangleF(0, 0, 1, 1);
            RectangleF layoutDestinationRect;
            int screenWidth = ConfigurationManager.AppSettings["ScreenWidth"].Length > 0 ? Convert.ToInt32(ConfigurationManager.AppSettings["ScreenWidth"]) : 1920;
            int screenHeight = ConfigurationManager.AppSettings["ScreenHeight"].Length > 0 ? Convert.ToInt32(ConfigurationManager.AppSettings["ScreenHeight"]) : 1200;
            Dictionary<string, List<AnnContainer>> annotations = null;

            destinationHeight = (width * screenHeight) / screenWidth;
            destinationRect = new Rectangle(0, 0, width, destinationHeight);
            layoutDestinationRect = destinationRect;


            {
                RasterImage image = new RasterImage(RasterMemoryFlags.Conventional, Convert.ToInt32(destinationRect.Width), Convert.ToInt32(destinationRect.Height), 24,
                                                    RasterByteOrder.Bgr, RasterViewPerspective.TopLeft, null, null, 0);

                using (RasterGraphics rasterG = RasterImagePainter.CreateGraphics(image))
                {
                    using (Graphics g = rasterG.Graphics)
                    {
                        g.FillRectangle(Brushes.Black, destinationRect);
                        foreach (Leadtools.Medical.WebViewer.DataContracts.ImageBox box in layout.Boxes)
                        {
                            string sop;

                            if (box.referencedSOPInstanceUID.Count == 0)
                                continue;

                            Point lt = sourceRect.Transform(new PointF((float)box.Position.leftTop.X, (float)box.Position.leftTop.Y),
                                                            layoutDestinationRect);
                            Point rb = sourceRect.Transform(new PointF((float)box.Position.rightBottom.X, (float)box.Position.rightBottom.Y),
                                                            layoutDestinationRect);
                            int boxWidth = (int)Math.Abs(rb.X - lt.X);
                            int boxHeight = (int)Math.Abs(rb.Y - lt.Y);
                            Rectangle boxRect = new Rectangle(lt.X, Math.Abs(lt.Y), boxWidth, boxHeight);

                            sop = box.referencedSOPInstanceUID[0];
                            if (datasets.ContainsKey(sop))
                            {
                                RasterImage dcmImage = GetImage(datasets[sop]);

                                if (burnAnnotations && annotations == null)
                                {
                                    string seriesInstanceUID = datasets[sop].GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);

                                    annotations = GetSeriesAnnotations(userName, seriesInstanceUID, queryAddin, retrieveAddin);
                                }

                                if (dcmImage != null)
                                {
                                    if (burnAnnotations && annotations.ContainsKey(sop))
                                    {
                                        foreach (AnnContainer container in annotations[sop])
                                            dcmImage.Burn(container, 0, 0);
                                    }
                                    ColorResImage(dcmImage);
                                    PaintImage(dcmImage, boxRect, g);
                                }
                            }
                        }
                    }
                }
                return image;
            }
        }
         static public void GetDpi(DicomDataSet ds, out double xDpi, out double yDpi)
         {
            xDpi = 254;
            yDpi = 254;

            var pixelSpacing = ds.GetValue<string>(DicomTag.ImagerPixelSpacing, string.Empty);
            if (string.IsNullOrEmpty(pixelSpacing))
            {
               pixelSpacing = ds.GetValue<string>(DicomTag.PixelSpacing, string.Empty);
            }
            if (!string.IsNullOrEmpty(pixelSpacing))
            {
               var pixelSpacingValues = AddInsUtils.ExtractValues(pixelSpacing);
               if (pixelSpacingValues.Length == 2)
               {
                  xDpi = 25.4 / pixelSpacingValues[0];
                  yDpi = 25.4 / pixelSpacingValues[1];
               }
            }
        }

        public static void Burn(this RasterImage image, AnnContainer container, double xDpi, double yDpi)
        {           
            if (image.BitsPerPixel != 24)
            {
               Leadtools.ImageProcessing.ColorResolutionCommand cmd = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, 24, RasterByteOrder.Bgr, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.None, null);

               cmd.Run(image);
            }

            // The Medical Viewer defaults dpi to 150
            // In this case, there is enough information to compute the dpi, which should be 150
            // container.CalculateDpi(image, width, height, ref xDpi, ref yDpi);
           if((int)xDpi==0||(int)yDpi==0)
           {
              xDpi = image.XResolution;
              yDpi = image.YResolution; 
           }
                        
            double calibrationScale = container.Mapper.CalibrationScale;
            container.Mapper = new AnnContainerMapper(150, 150, xDpi, yDpi);

            LeadMatrix transform = container.Mapper.Transform;
            container.Mapper.UpdateTransform(transform);
            container.Mapper.Calibrate(LeadLengthD.Create(1), AnnUnit.Unit, new LeadLengthD(calibrationScale), AnnUnit.Unit);
            RasterColor[] colors = image.GetPalette();
            IntPtr hDC = RasterImagePainter.CreateLeadDC(image);
            if (hDC != null && hDC != IntPtr.Zero)
            {
               using (Graphics g = Graphics.FromHdc(hDC))
               {   
                  // Create a new rendering engine for this container and context
                  AnnWinFormsRenderingEngine renderingEngine = new AnnWinFormsRenderingEngine(container, g);
                  
                  container.Mapper.BurnScaleFactor = xDpi / 150;

                  // Burn it
                  renderingEngine.Burn();
               }

               RasterImagePainter.DeleteLeadDC(hDC);
            }
        }

        public static Dictionary<string, List<AnnContainer>> GetSeriesAnnotations(string userName, string seriesInstanceUID, IQueryAddin queryAddin, IObjectRetrieveAddin retrieveAddin)
        {
            PresentationStateData[] data = queryAddin.FindPresentationState(userName, seriesInstanceUID, null);
            Dictionary<string, List<AnnContainer>> annotations = new Dictionary<string, List<AnnContainer>>();
            AnnCodecs codecs = new AnnCodecs();
            JavaScriptSerializer jSerializer = new JavaScriptSerializer();

            foreach (PresentationStateData item in data)
            {
                Stream stream = retrieveAddin.GetPresentationAnnotations(item.SOPInstanceUID, null);

                if (stream != null && stream.Length > 0)
                {
                    AnnCodecsInfo info = null;

                    info = codecs.GetInfo(stream);
                    stream.Position = 0;
                    for (int i = 1; i <= info.Pages.Length; i++)
                    {
                        AnnContainer container = codecs.Load(stream, i);

                        if (container.UserData != null)
                        {
                            AnnUserData userData = jSerializer.Deserialize<AnnUserData>(container.UserData.ToString());

                            if (!annotations.ContainsKey(userData.ReferencedImageSequence.ReferencedSopInstanceUid))
                                annotations[userData.ReferencedImageSequence.ReferencedSopInstanceUid] = new List<AnnContainer>();

                            annotations[userData.ReferencedImageSequence.ReferencedSopInstanceUid].Add(container);
                        }
                    }
                }
            }
            return annotations;
        }

        public static Dictionary<string, List<AnnContainer>> GetAnnotations(string annotationData)
        {
            Dictionary<string, List<AnnContainer>> annotations = new Dictionary<string, List<AnnContainer>>();
                        

            if (!string.IsNullOrEmpty(annotationData))
            {
                AnnCodecs codecs = new AnnCodecs();
                AnnCodecsInfo info = codecs.GetInfoFromString(annotationData);

                for (int i = 0; i < info.Pages.Length; i++)
                {
                    AnnContainer container = codecs.LoadFromString(annotationData, info.Pages[i]);
                    if (null!=container)
                    if (container.UserData != null)
                    {
                        AnnUserData userData = (new JavaScriptSerializer()).Deserialize<AnnUserData>(container.UserData.ToString());

                        if (!annotations.ContainsKey(userData.ReferencedImageSequence.ReferencedSopInstanceUid))
                            annotations[userData.ReferencedImageSequence.ReferencedSopInstanceUid] = new List<AnnContainer>();

                        annotations[userData.ReferencedImageSequence.ReferencedSopInstanceUid].Add(container);
                    }
                }
            }

            return annotations;
        }

        public static Dictionary<string, List<AnnContainer>> GetAndRemoveSeriesAnnotations(string userName, string seriesInstanceUID, IQueryAddin queryAddin, IObjectRetrieveAddin retrieveAddin, string description, IStoreAddin storeAddin)
        {
            PresentationStateData[] data = queryAddin.FindPresentationState(userName, seriesInstanceUID, null);
            Dictionary<string, List<AnnContainer>> annotations = new Dictionary<string, List<AnnContainer>>();
            AnnCodecs codecs = new AnnCodecs();
            JavaScriptSerializer jSerializer = new JavaScriptSerializer();

            foreach (PresentationStateData item in data)
            {
                if (!string.IsNullOrEmpty(description))
                    if (item.ContentDescription != description)
                        continue;

                Stream stream = retrieveAddin.GetPresentationAnnotations(item.SOPInstanceUID, null);

                //delete item.SOPInstanceUID
                storeAddin.DeletePresentationState(item.SOPInstanceUID, null);

                if (stream != null && stream.Length > 0)
                {
                    AnnCodecsInfo info = null;

                    info = codecs.GetInfo(stream);
                    stream.Position = 0;
                    for (int i = 1; i <= info.Pages.Length; i++)
                    {
                        AnnContainer container = codecs.Load(stream, i);

                        if (container.UserData != null)
                        {
                            AnnUserData userData = jSerializer.Deserialize<AnnUserData>(container.UserData.ToString());

                            if (!annotations.ContainsKey(userData.ReferencedImageSequence.ReferencedSopInstanceUid))
                                annotations[userData.ReferencedImageSequence.ReferencedSopInstanceUid] = new List<AnnContainer>();

                            annotations[userData.ReferencedImageSequence.ReferencedSopInstanceUid].Add(container);
                        }
                    }
                }
            }
            return annotations;
        }

        private static void SaveXmlElement(DicomDataSet ds, XmlWriter xmlWriter, DicomElement element)
        {
            if (null != element)
            {
                xmlWriter.WriteStartElement("element", "");

                xmlWriter.WriteStartAttribute("tag");
                xmlWriter.WriteString(ElementTagToString(element));
                xmlWriter.WriteEndAttribute();

                xmlWriter.WriteStartAttribute("name");
                DicomTag tag = DicomTagTable.Instance.Find(element.Tag);
                string name = string.Empty;

                if (null != tag)
                {
                    name = tag.Name;
                }

                xmlWriter.WriteString(name);
                xmlWriter.WriteEndAttribute();

                xmlWriter.WriteStartAttribute("vr");
                xmlWriter.WriteString(element.VR.ToString());
                xmlWriter.WriteEndAttribute();

                xmlWriter.WriteString(GetStringValue(ds, element));

                DicomElement child = ds.GetChildElement(element, true);
                if (child != null)
                {
                    SaveXmlElement(ds, xmlWriter, child);

                    child = ds.GetNextElement(child, true, true);

                    while (child != null)
                    {
                        SaveXmlElement(ds, xmlWriter, child);
                        child = ds.GetNextElement(child, true, true);
                    }

                }

                xmlWriter.WriteEndElement();
            }
        }

        private static string ElementTagToString(DicomElement element)
        {
            string tag = string.Empty;

            tag = string.Format("{0:X8}", element.Tag);

            return tag;
        }

        private static string GetStringValue(DicomDataSet ds, DicomElement element)
        {
            if (element.Length <= 0)
            {
                return string.Empty;
            }

            switch (element.VR)
            {
                case DicomVRType.DA:
                case DicomVRType.DT:
                case DicomVRType.TM:
                    {
                        byte[] b = ds.GetBinaryValue(element, (int)element.Length);
                        return Encoding.ASCII.GetString(b);
                    }

                case DicomVRType.OB:
                case DicomVRType.OW:
                case DicomVRType.UN:
                    {
                        if (element.Tag == DicomTag.FileMetaInformationVersion)
                        {
                            return SecurityElement.Escape(ds.GetConvertValue(element));
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }

                default:
                    {
                        string value = ds.GetConvertValue(element);
                        return GetValidXmlString(value);

                    }
            }
        }

        private static string GetValidXmlString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            foreach (char c in value)
            {
                if (!char.IsControl(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
            //return SecurityElement.Escape(sb.ToString());
        }

        private static RasterImage GetImage(DicomDataSet dicomDs)
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

        private static void PaintImage(RasterImage image, RectangleF displayRectangle, Graphics g)
        {
            RasterImage resizedImage = image.ResizeImage(displayRectangle);
            Point position = new Point((int)Math.Ceiling(displayRectangle.X + ((displayRectangle.Width - resizedImage.Width) / 2)),
                                                        (int)Math.Ceiling(displayRectangle.Y + ((displayRectangle.Height - resizedImage.Height) / 2)));

            g.DrawImage(RasterImageConverter.ConvertToImage(resizedImage, ConvertToImageOptions.None),
                        new Rectangle(position.X, position.Y, resizedImage.Width, resizedImage.Height));
        }

        private static void ColorResImage(RasterImage currentImage)
        {
            if (currentImage.BitsPerPixel < 24)
            {
                ColorResolutionCommand cmd = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, 24, RasterByteOrder.Bgr,
                                                                        RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.None, null);

                cmd.Run(currentImage);
            }
        }

        public static DicomSortImageData GetImageData(DataRow row)
        {
            DicomSortImageDataEx data = null;

            if (row.Table.ChildRelations["FK_ImageInstance_Instance"] != null)
            {
                CompositeInstanceDataSet.ImageInstanceRow[] imageRows = ((CompositeInstanceDataSet.ImageInstanceRow[])(row.GetChildRows(row.Table.ChildRelations["FK_ImageInstance_Instance"])));
                data = new DicomSortImageDataEx();

                if (imageRows != null && imageRows.Length > 0)
                {
                    CompositeInstanceDataSet.ImageInstanceRow imageInstanceRow = imageRows[0];
                    double[] temp;

                    data.NumberOfFrames = imageInstanceRow.IsNumberOfFramesNull() ? 1 : imageInstanceRow.NumberOfFrames;


                    data.FrameOfReferenceUID = imageInstanceRow.IsFrameOfReferenceUIDNull() ? string.Empty : imageInstanceRow.FrameOfReferenceUID;
                    data.EchoNumber = imageInstanceRow.IsEchoNumberNull() ? -1 : imageInstanceRow.EchoNumber;
                    data.InstanceNumber = imageInstanceRow.InstanceRow.IsInstanceNumberNull() ? 0 : imageInstanceRow.InstanceRow.InstanceNumber;
                    data.SequenceName = imageInstanceRow.IsSequenceNameNull() ? string.Empty : imageInstanceRow.SequenceName;
                    if (!imageInstanceRow.IsImageOrientationPatientNull() && imageInstanceRow.ImageOrientationPatient.Length > 0)
                    {
                       try
                       {
                          data.ImageOrientation = imageInstanceRow.ImageOrientationPatient;
                       }
                       catch { }
                    }
                    data.Data = imageInstanceRow.SOPInstanceUID;

                    temp = ExtractValues(imageInstanceRow.IsImagePositionPatientNull() ? string.Empty : imageInstanceRow.ImagePositionPatient);
                    if (temp == null)
                        temp = new double[3];
                    data.ImagePosition = temp;

                    temp = ExtractValues(imageInstanceRow.IsPixelSpacingNull() ? string.Empty : imageInstanceRow.PixelSpacing);
                    if (temp == null)
                        data.PixelSpacing = LeadPointD.Create(1, 1);
                    else
                       data.PixelSpacing = LeadPointD.Create(temp[0], temp[1]);
                }
            }

            return data;
        }

        public static double[] ExtractValues(string value)
        {
           try
           {
              if (!string.IsNullOrEmpty(value))
              {
                 string[] values = value.Split('\\');

                 if (values.Length == 0)
                    return null;
                 else
                 {
                    return values.Select(double.Parse).ToArray();
                 }
              }
           }
           catch
           {           	
           }            

            return null;
        }

        public static DataRow GetDicomInstanceRow(IStorageDataAccessAgent3 storageAgent, string sopInstanceUID)
        {
            ICatalogEntity instanceEntity = RegisteredEntities.GetInstanceEntity(sopInstanceUID);

            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();

            matchingList.Add(instanceEntity);
            matchingCollection.Add(matchingList);

            DataSet result = storageAgent.MinimumQueryCompositeInstances(matchingCollection);

            if (result.Tables[DataTableHelper.InstanceTableName].Rows.Count > 0)
            {
                return result.Tables[DataTableHelper.InstanceTableName].Rows[0];
            }
            else
            {
                return null;
            }
        }

        public static string GetPatientName(DataRow patientRow)
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

#if(LEADTOOLS_V19_OR_LATER)

        private static IList CreateList(Type myType)
        {
           Type genericListType = typeof(List<>).MakeGenericType(myType);
           return (IList)Activator.CreateInstance(genericListType);
        }

        public static object ConvertToPropertyType(PropertyInfo property, object value)
        {
           object cstVal = null;
           if (property != null)
           {
              Type propType = Nullable.GetUnderlyingType(property.PropertyType);
              bool isNullable = (propType != null);

              if (!isNullable)
              {
                 propType = property.PropertyType;
              }
              bool canAttrib = (value != null || isNullable);
              if (!canAttrib)
              {
                 throw new Exception("Cant attrib null on non nullable. ");
              }

              // cstVal = (value == null || Convert.IsDBNull(value)) ? null : Convert.ChangeType(value, propType);

              if (value == null || Convert.IsDBNull(value))
                 return null;

              object[] objectArray = value as object[];

              bool isList = typeof(IList).IsAssignableFrom(propType);
              if (isList == false)
                 try
                 {
                    if (objectArray != null)
                    {
                       cstVal = Convert.ChangeType(objectArray[0], propType);
                    }
                    else
                    {
                       cstVal = Convert.ChangeType(value, propType);
                    }
                    return cstVal;
                 }
                 catch (Exception ex)
                 {

                 }
              else
              {
                 Type elementType = propType.GetGenericArguments()[0];
                 if (objectArray != null)
                 {
                    // var arrayResult = Array.CreateInstance(propType, objectArray.Length);
                    var listResult = CreateList(elementType);
                    for (int i = 0; i < objectArray.Length; i++)
                    {
                       object itemValue = Convert.ChangeType(objectArray[i], elementType);
                       listResult.Add(itemValue);
                    }
                    cstVal = listResult;
                 }
              }
           }

           return cstVal;
        }

        private static bool IsNumber(this object value)
        {
           return value is sbyte
                   || value is byte
                   || value is short
                   || value is ushort
                   || value is int
                   || value is uint
                   || value is long
                   || value is ulong
                   || value is float
                   || value is double
                   || value is decimal;
        }

        public static bool IsNumericType(this Type type)
        {
           switch (Type.GetTypeCode(type))
           {
              case TypeCode.Byte:
              case TypeCode.SByte:
              case TypeCode.UInt16:
              case TypeCode.UInt32:
              case TypeCode.UInt64:
              case TypeCode.Int16:
              case TypeCode.Int32:
              case TypeCode.Int64:
              case TypeCode.Decimal:
              case TypeCode.Double:
              case TypeCode.Single:
                 return true;
              default:
                 return false;
           }
        }



#if FOR_DOTNET4
        public static int CompareObjects(object valueX, object valueY)
        {
            IComparable myValueX = valueX as IComparable;
            IComparable myValueY = valueY as IComparable;
            Type typeX;
            Type typeY;

            if (myValueX == null)
            {
                if (myValueY == null)
                    return 0;
                return -1;
            }

            if (myValueY == null)
                return 1;

            typeX = valueX.GetType();
            typeY = valueY.GetType();

            if (!typeX.Equals(typeY))
            {
                // if(typeY == typeof(decimal) && typeX!=typeof(decimal))
                if (typeX.IsNumericType() && typeY.IsNumericType())
                {
                    myValueY = Cast(myValueY, typeX);
                }
                int ret = ((dynamic)myValueX).CompareTo(((dynamic)myValueY));
               
                return ret;
            }

            // If comparing strings, trim blanks from the string
           string stringX = valueX as string;
           string stringY = valueY as string;
           if (stringX != null && stringY != null)
           {
              stringX = stringX.Trim();
              stringY = stringY.Trim();
              return stringX.CompareTo(stringY);
           } 

            return myValueX.CompareTo(myValueY);
        }

        public static dynamic Cast(dynamic obj, Type castTo)
        {
            return Convert.ChangeType(obj, castTo);
        }
#else
        public static int CompareObjects(object valueX, object valueY)
        {
           IComparable myValueX = valueX as IComparable;
           IComparable myValueY = valueY as IComparable;
           Type typeX;
           Type typeY;

           if (myValueX == null)
           {
              if (myValueY == null)
                 return 0;
              return -1;
           }

           if (myValueY == null)
              return 1;

           typeX = valueX.GetType();
           typeY = valueY.GetType();

           if (!typeX.Equals(typeY))
           {
              if ((typeX.IsPrimitive || typeof(string).Equals(typeX)) &&
                  (typeY.IsPrimitive || typeof(string).Equals(typeY)))
              {
                 myValueY = Convert.ChangeType(myValueY, typeX) as IComparable;
                 return myValueX.CompareTo(myValueY);
              }

              return -1;
           }

           return myValueX.CompareTo(myValueY);
        }      
#endif       
#endif
    }



    class PersonNameComponents
    {
        public string FamilyName { get; set; }

        public string GivenName { get; set; }

        public string MiddleName { get; set; }

        public string NamePrefix { get; set; }

        public string NameSuffix { get; set; }
    }

    public static class PluginLoader<T>
    {
        //
        // Load the first occurrence of the specified interface
        //
        public static T Load(string file)
        {
            Assembly a = Assembly.LoadFrom(file);
            Type[] types = a.GetTypes();

            foreach (Type t in types)
            {
                if (t.GetInterfaces().Contains<Type>(typeof(T)))
                {
                    return (T)Activator.CreateInstance(t);
                }
            }
            return default(T);
        }
    }

    public static class HangingProtocolUtils
    {
       public static bool IsCurrent(TimeBasedImageSet imageSet)
       {
          if (imageSet.RelativeTime != null && imageSet.RelativeTime.Count == 2)
          {
             if (imageSet.RelativeTime[0] == 0 && imageSet.RelativeTime[1] == 0)
                return true;
          }
          return false;
       }

       private static MatchingParameterCollection StartCreateMatchingParameterCollection(string userName, IEnumerable<string> userRoles)
       {
          // 0:     Manufacturer
          // 1:     Site
          // 2:     SINGLE_USER
          // 3..N:  USER_ROLES

          int userRolesCount = userRoles.Count() == 0 ? 0 : 1;
          //foreach (string role in userRoles)
          //{
          //   userRolesCount++;
          //}
          int countListsToCreate = 3 + userRolesCount;

          MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
          for (int i = 0; i < countListsToCreate; i++)
          {
             MatchingParameterList mpList = new MatchingParameterList();
             matchingCollection.Add(mpList);
          }
          return matchingCollection;
       }

       private static void FinishCreateMatchingParameterCollection(MatchingParameterCollection matchingCollection, string userName, IEnumerable<string> userRoles)
       {
          if (matchingCollection.Count < 3)
          {
             return;
          }

          string roleString = string.Empty;
          foreach (string role in userRoles)
          {
             roleString = roleString + role + "\\";
          }
          if (roleString.EndsWith("\\"))
          {
             roleString = roleString.Substring(0, roleString.Length - 1);
          }

          HangingProtocolEntity hpEntityManufacturer = new HangingProtocolEntity() { Level = "MANUFACTURER" };
          HangingProtocolEntity hpEntitySite = new HangingProtocolEntity() { Level = "SITE" };
          HangingProtocolEntity hpEntitySingleUser = new HangingProtocolEntity() { Level = "SINGLE_USER", Creator = userName };

          // Copy mpList0 to the other lists
          matchingCollection[1].AddRange(matchingCollection[0]);
          matchingCollection[2].AddRange(matchingCollection[0]);

          if (!string.IsNullOrEmpty(roleString))
          {
             HangingProtocolEntity hpEntityUserGroup = new HangingProtocolEntity() { Level = "USER_GROUP", UserGroupName = roleString };
             matchingCollection[3].AddRange(matchingCollection[0]);
             matchingCollection[3].Add(hpEntityUserGroup);
          }

          // Customize each list
          matchingCollection[0].Add(hpEntityManufacturer);
          matchingCollection[1].Add(hpEntitySite);
          matchingCollection[2].Add(hpEntitySingleUser);
       }


       public static List<HangingProtocolQueryResult> GetVerySpecificProtocols(string userName, IEnumerable<string> userRoles, CompositeInstanceDataSet.StudyRow studyRow, IStorageDataAccessAgent3 dataAccess)
       {
          Dictionary<string, HangingProtocolQueryResult> protocols = new Dictionary<string, HangingProtocolQueryResult>();
          List<HangingProtocolQueryResult> results;

          if (studyRow.GetProcedureCodeSequenceRows().Length > 0)
          {
             CompositeInstanceDataSet.ProcedureCodeSequenceRow[] pcsRows = studyRow.GetProcedureCodeSequenceRows();
             HangingProtocolProcedureCodeSequenceEntity pcsEntity = new HangingProtocolProcedureCodeSequenceEntity();

             bool anythingToQuery = false;

             MatchingParameterCollection matchingCollection = StartCreateMatchingParameterCollection(userName, userRoles);

             for (int i = 0; i < pcsRows.Length; i++)
             {
                CompositeInstanceDataSet.ProcedureCodeSequenceRow row = pcsRows[i] as CompositeInstanceDataSet.ProcedureCodeSequenceRow;

                pcsEntity.CodeMeaning = row.CodeMeaning;
                pcsEntity.CodeValue = row.CodeValue;
                pcsEntity.CodingSchemeDesignator = row.CodingSchemaDesignator;

                bool isEmpty = string.IsNullOrEmpty(row.CodeMeaning) && string.IsNullOrEmpty(row.CodeMeaning) &&
                               string.IsNullOrEmpty(row.CodeMeaning);

                if (!isEmpty)
                {
                   matchingCollection[0].Add(pcsEntity);
                   anythingToQuery = true;
                }
             }

             if (anythingToQuery)
             {
                FinishCreateMatchingParameterCollection(matchingCollection, userName, userRoles);
                results = QueryHangingProtocols(matchingCollection, dataAccess);
                results.ForEach((result) =>
                                   {
                                      if (!protocols.ContainsKey(result.SOPInstanceUID))
                                         protocols.Add(result.SOPInstanceUID, result);
                                   });
             }
          }
          return protocols.Values.ToList();
       }

       public static List<HangingProtocolQueryResult> GetSomeWhatSpecificProtocols(string userName, IEnumerable<string> userRoles, CompositeInstanceDataSet.InstanceRow instanceRow, IStorageDataAccessAgent3 dataAccess)
       {
          Dictionary<string, HangingProtocolQueryResult> protocols = new Dictionary<string, HangingProtocolQueryResult>();
          HangingProtocolEntity hpEntity = new HangingProtocolEntity() { Creator = userName };
          HangingProtocolDefinitonSequenceEntity hpDefinitionSequenceEntity = new HangingProtocolDefinitonSequenceEntity();

          List<HangingProtocolQueryResult> results;

          if (instanceRow.GetAnatomicRegionSequenceRows().Length > 0)
          {
             CompositeInstanceDataSet.AnatomicRegionSequenceRow[] arsRows = instanceRow.GetAnatomicRegionSequenceRows();
             HangingProtocolAnatomicRegionSequenceEntity arsEntity = new HangingProtocolAnatomicRegionSequenceEntity();

             MatchingParameterCollection matchingCollection = StartCreateMatchingParameterCollection(userName, userRoles);

             hpDefinitionSequenceEntity.Modality = instanceRow.SeriesRow.Modality;
             for (int i = 0; i < arsRows.Length; i++)
             {
                CompositeInstanceDataSet.AnatomicRegionSequenceRow row = arsRows[i] as CompositeInstanceDataSet.AnatomicRegionSequenceRow;

                arsEntity.CodeMeaning = row.CodeMeaning;
                arsEntity.CodeValue = row.CodeValue;
                arsEntity.CodingSchemeDesignator = row.CodingSchemeDesignator;
                matchingCollection[0].Add(arsEntity);
             }
             matchingCollection[0].Add(hpDefinitionSequenceEntity);

             FinishCreateMatchingParameterCollection(matchingCollection, userName, userRoles);

             results = QueryHangingProtocols(matchingCollection, dataAccess);
             results.ForEach((result) =>
             {
                if (!protocols.ContainsKey(result.SOPInstanceUID))
                   protocols.Add(result.SOPInstanceUID, result);
             });
          }
          else
          {
             hpDefinitionSequenceEntity.Modality = instanceRow.SeriesRow.Modality;
             if (!instanceRow.SeriesRow.IsBodyPartExaminedNull() && instanceRow.SeriesRow.BodyPartExamined.Length > 0)
             {
                hpDefinitionSequenceEntity.BodyPartExamined = instanceRow.SeriesRow.BodyPartExamined;
             }
             else
             {
                return protocols.Values.ToList();
             }

             MatchingParameterCollection matchingCollection = StartCreateMatchingParameterCollection(userName, userRoles);
             matchingCollection[0].Add(hpDefinitionSequenceEntity);

             FinishCreateMatchingParameterCollection(matchingCollection, userName, userRoles);

             results = QueryHangingProtocols(matchingCollection, dataAccess);
             results.ForEach((result) =>
             {
                if (!protocols.ContainsKey(result.SOPInstanceUID))
                   protocols.Add(result.SOPInstanceUID, result);
             });
          }

          return protocols.Values.ToList();
       }

       public static List<HangingProtocolQueryResult> GetGenericProtocols(string userName, IEnumerable<string> userRoles, DataRow[] seriesRows, IStorageDataAccessAgent3 dataAccess)
       {
          Dictionary<string, HangingProtocolQueryResult> protocols = new Dictionary<string, HangingProtocolQueryResult>();
          List<HangingProtocolQueryResult> results;

          // Get the list of modalities
          string modality = string.Empty;
          List<string> modalityList = new List<string>();
          foreach (DataRow row in seriesRows)
          {
             CompositeInstanceDataSet.SeriesRow seriesRow = row as CompositeInstanceDataSet.SeriesRow;
             if (seriesRow != null)
             {
                modalityList.Add(seriesRow.Modality);
             }
          }

          modalityList = modalityList.Distinct().ToList();
          foreach (string s in modalityList)
          {
             modality += s + "\\";
          }
          if (modality.EndsWith("\\"))
          {
             modality = modality.Remove(modality.Length - 1, 1);
          }

          HangingProtocolDefinitonSequenceEntity hpDefinitonSequenceEntity = new HangingProtocolDefinitonSequenceEntity() { Modality = modality };

          MatchingParameterCollection matchingCollection = StartCreateMatchingParameterCollection(userName, userRoles);
          matchingCollection[0].Add(hpDefinitonSequenceEntity);
          FinishCreateMatchingParameterCollection(matchingCollection, userName, userRoles);

          results = QueryHangingProtocols(matchingCollection, dataAccess);
          results.ForEach((result) =>
          {
             if (!protocols.ContainsKey(result.SOPInstanceUID))
                protocols.Add(result.SOPInstanceUID, result);
          });

          return protocols.Values.ToList();
       }

       public static List<HangingProtocolQueryResult> QueryHangingProtocols(MatchingParameterCollection matchingCollection, IStorageDataAccessAgent3 dataAccess)
       {
          HangingProtocolDataset result = null;
          List<HangingProtocolQueryResult> protocols = new List<HangingProtocolQueryResult>();

          result = dataAccess.QueryHangingProtocol(matchingCollection) as HangingProtocolDataset;
          if (result.HangingProtocol.Rows.Count > 0)
          {
             foreach (HangingProtocolDataset.HangingProtocolRow row in result.HangingProtocol.Rows)
             {
                HangingProtocolQueryResult protocol = new HangingProtocolQueryResult();

                protocol.Name = row.Name;
                protocol.SOPInstanceUID = row.SOPInstanceUID;

                if (row.Level == "MANUFACTURER")
                {
                   protocol.Level = HangingProtocolLevel.Manufacturer;
                }
                else if (row.Level == "SITE")
                {
                   protocol.Level = HangingProtocolLevel.Site;
                }
                else if (row.Level == "USER_GROUP")
                {
                   protocol.Level = HangingProtocolLevel.UserGroup;
                }
                else if (row.Level == "SINGLE_USER")
                {
                   protocol.Level = HangingProtocolLevel.SingleUser;
                }
                else
                {
                   protocol.Level = null;
                }

                protocols.Add(protocol);
             }
          }
          return protocols;
       }

       public static CompositeInstanceDataSet.AnatomicRegionSequenceRow[] GetAnatomicRegionSequenceRows(this CompositeInstanceDataSet.InstanceRow instanceRow)
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
    }
}
