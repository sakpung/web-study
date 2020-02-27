// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using Leadtools.Annotations.Engine;
using Leadtools.Medical.WebViewer.ServiceContracts;
using System.IO;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Dicom;
using Ionic.Zip;
using System.Configuration;
using Leadtools.Medical.WebViewer.Core.DataTypes.Common;
using Leadtools.ImageProcessing;
using System.Xml;
using Leadtools.Medical.WebViewer.Addins.Common;
using Leadtools.Medical.WebViewer.Annotations;
using System.Diagnostics;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Dicom.Common.Anonymization;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.Medical.Logging.DataAccessLayer;
using Leadtools.Document.Writer;
using Leadtools.Drawing;
using System.Drawing;
using System.Web.Hosting;
using Leadtools.Annotations.Rendering;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;

namespace Leadtools.Medical.WebViewer.Addins
{
    public class ExportAddin : IExportAddin
    {
        private IStorageDataAccessAgent3 _DataAccessAgent;
        private Exporter _Exporter;
        private IObjectRetrieveAddin _ObjectRetrieveAddIn;
        private IStoreAddin _StoreAddin;        
        private IQueryAddin _QueryAddIn;

        public ExportAddin(IStorageDataAccessAgent3 dataAccessAgent, IAuthorizedStorageDataAccessAgent2 authAgent, Lazy<IExternalStoreDataAccessAgent> externalStoreAgent, ILoggingDataAccessAgent loggingAgent, string storageServerServicePath, IStoreAddin storeAddin, IOptionsDataAccessAgent optionsAgent, IPermissionManagementDataAccessAgent2 permissionsAgent, Leadtools.Dicom.Imaging.IDataCacheProvider dataCache)
        {
            _DataAccessAgent = dataAccessAgent;
            _Exporter = new Exporter(dataAccessAgent);
            _ObjectRetrieveAddIn = new ObjectRetrieveAddin(dataAccessAgent, externalStoreAgent, loggingAgent, storageServerServicePath, optionsAgent, permissionsAgent, authAgent, dataCache);
            _StoreAddin = storeAddin;
            _QueryAddIn = new DatabaseQueryAddin(authAgent, optionsAgent, permissionsAgent, externalStoreAgent, loggingAgent, storageServerServicePath, null, dataCache);
        }

        #region IExportAddin Members

        public Stream ExportAllSeries(string userName, string patientID, ExportOptions options)
        {
            MemoryStream zipStream = new MemoryStream();
            ZipFile zip = null;

            try
            {
                if (options.FileFormat.ToLower() == "dicomzip" && string.IsNullOrEmpty(options.DczPassword))
                    throw new ArgumentException("Must pass a password when creating a DICOM Zip");

                if (options.FileFormat.ToLower() == "dicomgray" || options.FileFormat.ToLower() == "dicomzip")
                {
                    List<DicomDataSet> datasets = _Exporter.GetAllPatientDataSets(patientID);

                    if (options.CreateDICOMDIR)
                    {
                        zipStream = ExportToDICOMDIR(ref zip, datasets, options);
                    }
                    else
                    {
                        Dictionary<string, int> studies = new Dictionary<string, int>();
                        Dictionary<string, int> series = new Dictionary<string, int>();
                        int nextStudy = 0;
                        int nextSeries = 0;

                        ExportExtensions.ResetAnonymization();
                        foreach (DicomDataSet dataset in datasets)
                        {
                            string studyInstance = dataset.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty);
                            string seriesInstance = dataset.GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);
                            string sopInstance = dataset.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
                            string fileName = sopInstance + ".dcm";
                            string path = GetFolderName(studies, series, ref nextStudy, ref nextSeries, studyInstance, seriesInstance);
                            
                            if (zip == null)
                                zip = new ZipFile();

                            if (options.FileFormat.ToLower() == "dicomzip" && !string.IsNullOrEmpty(options.DczPassword))
                            {
                               zip.Password = options.DczPassword;
                            }

                            if (options.Anonymize)
                                dataset.Anonymize();
                            zip.AddEntry(path + fileName, dataset.ToStream());
                        }

                        if (zip != null)
                        {
                            if (options.IncludeViewer)
                            {
                                IncludeViewer(ref zip);
                            }

                            zip.Save(zipStream);
                            zip.Dispose();
                        }
                        zipStream.Position = 0;
                    }
                }
                else
                {
                    List<SeriesImage> seriesImages = _Exporter.GetAllPatientImages(patientID);

                    zip = LoadInstances(seriesImages, userName, options);
                    if (zip != null)
                    {
                       zip.Save(zipStream);
                       zip.Dispose();
                    }
                    zipStream.Position = 0;
                }

                return zipStream;
            }
            finally
            {

            }
        }

        private int GetCompression(CompressionType type)
        {
            switch(type)
            {
                case CompressionType.Low:
                    return 2;
                case CompressionType.Medium:
                    return 128;
                case CompressionType.High:
                    return 255;
            }
            return 2;
        }

        public Stream ExportInstances(string userName, string[] instanceUIDs, ExportOptions options)
        {
            MemoryStream zipStream = new MemoryStream();
            ZipFile zip = null;

            try
            {
                if (options.FileFormat.ToLower() == "dicomzip" && string.IsNullOrEmpty(options.DczPassword))
                    throw new ArgumentException("Must pass a password when creating a DICOM Zip");

                if (options.FileFormat.ToLower() == "dicomgray" || options.FileFormat.ToLower() == "dicomzip")
                {
                    List<DicomDataSet> datasets = _Exporter.GetInstanceDatasets(instanceUIDs);

                    if (options.CreateDICOMDIR)
                    {
                        zipStream = ExportToDICOMDIR(ref zip, datasets, options);
                    }
                    else
                    {
                        Dictionary<string, int> studies = new Dictionary<string, int>();
                        Dictionary<string, int> series = new Dictionary<string, int>();
                        int nextStudy = 0;
                        int nextSeries = 0;

                        ExportExtensions.ResetAnonymization();
                        foreach (DicomDataSet dataset in datasets)
                        {
                            string studyInstance = dataset.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty);
                            string seriesInstance = dataset.GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);
                            string sopInstance = dataset.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
                            string fileName = sopInstance + ".dcm";
                            string path = GetFolderName(studies, series, ref nextStudy, ref nextSeries, studyInstance, seriesInstance);
                            if (zip == null)
                                zip = new ZipFile();
                            
                            if(options.Anonymize)
                                dataset.Anonymize();
                            zip.AddEntry(path + fileName, dataset.ToStream());
                        }

                        if (zip != null)
                        {                           
                            zip.Save(zipStream);
                            zip.Dispose();
                        }
                        zipStream.Position = 0;
                    }
                }
                else
                {
                    List<SeriesImage> seriesImages = _Exporter.GetInstanceImages(instanceUIDs);

                    zip = LoadInstances(seriesImages, userName, options);
                    if (zip != null)
                    {
                       zip.Save(zipStream);
                       zip.Dispose();
                    }
                    zipStream.Position = 0;

                }
            }
            finally
            {

            }
            return zipStream;
        }

        public Stream ExportLayout(string userName, string seriesInstanceUID, Layout layout, bool burnAnnotations, CompressionType compression, int width)
        {
            Dictionary<string, DicomDataSet> datasets = _Exporter.GetSeriesDatasets(new string[] { seriesInstanceUID });            
            RasterImage image;            
            
            //
            // Check to see if a width was provide.  If not we default to 1024;
            //
            if (width == 0)
                width = 1024;
            image = AddInsUtils.LayoutToImage(datasets, layout, burnAnnotations, width, _QueryAddIn, _ObjectRetrieveAddIn, userName);

            if (image != null)
            {
               if (null != WebOperationContext.Current)
               {
                  WebOperationContext.Current.OutgoingResponse.ContentType = SupportedMimeTypes.JPG;
                  WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Disposition", string.Format("attachment; filename={0}.jpg", seriesInstanceUID));
               }

                return image.ToStream(RasterImageFormat.Jpeg, GetCompression(compression));
            }
            return null;
        }

        public Stream ExportSeries(string userName, string[] seriesInstanceUIDs, ExportOptions options)
        {
            MemoryStream zipStream = new MemoryStream();
            ZipFile zip = null;
            
            try
            {
                if(options.FileFormat.ToLower() == "dicomzip" && string.IsNullOrEmpty(options.DczPassword))
                    throw new ArgumentException("Must pass a password when creating a DICOM Zip");

                if (options.FileFormat.ToLower() == "dicomgray" || options.FileFormat.ToLower() == "dicomzip")
                {
                    List<DicomDataSet> datasets = _Exporter.GetSeriesDatasets(seriesInstanceUIDs).Values.ToList();

                    if (options.CreateDICOMDIR)
                    {
                        zipStream = ExportToDICOMDIR(ref zip, datasets, options);
                    }
                    else
                    {
                        Dictionary<string, int> studies = new Dictionary<string, int>();
                        Dictionary<string, int> series = new Dictionary<string, int>();
                        int nextStudy = 0;
                        int nextSeries = 0;

                        ExportExtensions.ResetAnonymization();
                        foreach (DicomDataSet dataset in datasets)
                        {
                            string studyInstance = dataset.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty);
                            string seriesInstance = dataset.GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);
                            string sopInstance = dataset.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
                            string fileName = sopInstance + ".dcm";
                            string path = GetFolderName(studies, series, ref nextStudy, ref nextSeries, studyInstance, seriesInstance);                            

                            if (zip == null)
                                zip = new ZipFile();

                            if (options.Anonymize)
                                dataset.Anonymize();
                            zip.AddEntry(path + fileName, dataset.ToStream());
                        }

                        if (zip != null)
                        {                           
                            zip.Save(zipStream);
                            zip.Dispose();
                        }
                        zipStream.Position = 0;
                    }
                }
                else
                {
                    List<SeriesImage> seriesImages = _Exporter.GetSeriesImages(seriesInstanceUIDs);

                    zip = LoadInstances(seriesImages, userName, options);

                    if (zip != null)
                    {
                       zip.Save(zipStream);
                       zip.Dispose();
                    }
                    zipStream.Position = 0;
                }
            }
            finally
            {

            }
            return zipStream;
        }
              
        public Stream PrintAllSeries(string userName, string patientID, PrintOptions options, string annotationData)
        {
           DocumentWriter documentWriterInstance = null;

           try
           {
               List<SeriesImage> seriesImages = _Exporter.GetAllPatientImages(patientID);
               Dictionary<string, List<AnnContainer>> annotations = AddInsUtils.GetAnnotations(annotationData);

               documentWriterInstance = OpenDocumentWriterInstance(options.PageWidth, options.PageHeight, 300);
               string fileName = Path.GetTempFileName();
               documentWriterInstance.BeginDocument(fileName, DocumentFormat.Pdf);

               foreach (SeriesImage si in seriesImages)
               {
                  ProcessInstance(si, userName, options, annotations);

                  {
                     var page = new Leadtools.Document.Writer.DocumentWriterRasterPage();
                     page.Image = si.Image;
                     documentWriterInstance.AddPage(page);
                  }
               }

               documentWriterInstance.EndDocument();
               MemoryStream ms = new MemoryStream(File.ReadAllBytes(fileName));
               File.Delete(fileName);
               ms.Position = 0;
               return ms;
           }
           finally
           {
              if (null != documentWriterInstance)
                 documentWriterInstance.EndDocument();
           }
        }

        public Stream PrintInstances(string userName, string[] instanceUIDs, PrintOptions options, string annotationData)
       {
          DocumentWriter documentWriterInstance = null;

          try
          {              
             List<SeriesImage> seriesImages = _Exporter.GetInstanceImages(instanceUIDs);
             Dictionary<string, List<AnnContainer>> annotations = AddInsUtils.GetAnnotations(annotationData);

             documentWriterInstance = OpenDocumentWriterInstance(options.PageWidth, options.PageHeight, 300);
             string fileName = Path.GetTempFileName();
             documentWriterInstance.BeginDocument(fileName, DocumentFormat.Pdf);

             foreach (SeriesImage si in seriesImages)
             {
                ProcessInstance(si, userName, options, annotations);

                {
                   var page = new Leadtools.Document.Writer.DocumentWriterRasterPage();
                   page.Image = si.Image;
                   documentWriterInstance.AddPage(page);
                }
             }

             documentWriterInstance.EndDocument();
             MemoryStream ms = new MemoryStream(File.ReadAllBytes(fileName));
             File.Delete(fileName);
             ms.Position = 0;
             return ms;
          }
          finally
          {
             if (null != documentWriterInstance)
                documentWriterInstance.EndDocument();
          }
       }

        public Stream PrintLayout(string userName, string seriesInstanceUID, Layout layout, PrintOptions options, string annotationData)
        {
            DocumentWriter documentWriterInstance = null;

            //
            // Check to see if a width was provide.  If not we default to 1024;
            //
            if (options.LayoutImageWidth == 0)
                options.LayoutImageWidth = 1024;

            SeriesImage layoutImageWithInfo = null;

            using (RasterImage layoutImage = AddInsUtils.CreateLayoutImage(options.LayoutImageWidth, options.WhiteBackground))
            {
                try
                {
                    options.LayoutPatientInfo = true;
                    Dictionary<string, List<AnnContainer>> annotations = AddInsUtils.GetAnnotations(annotationData);

                    foreach (var box in layout.Boxes)
                    {
                        if (null == box.referencedSOPInstanceUID)
                            continue;
                        if (0 == box.referencedSOPInstanceUID.Count)
                            continue;

                        //only the first instance
                        List<SeriesImage> seriesImages = _Exporter.GetInstanceImages(new string[] { box.referencedSOPInstanceUID[0] });

                        if (null == seriesImages)
                            continue;
                        if (0 == seriesImages.Count)
                            continue;

                        // layout patient info check whether to print the patient information on each image or on the whole layout image.
                        if (!options.LayoutPatientInfo)
                        {
                            //only the first image
                            ProcessInstance(seriesImages[0], userName, options, annotations);

                        }
                        else
                        {
                            // take one of those series image to print them at the bottom of the final resultant image.
                            if (layoutImageWithInfo == null)
                            {
                                layoutImageWithInfo = seriesImages[0];
                            }
                        }

                        AddInsUtils.LayoutImage(layoutImage, seriesImages[0].Image, box);
                    }

                    documentWriterInstance = OpenDocumentWriterInstance(options.PageWidth, options.PageHeight, 300);
                    string fileName = Path.GetTempFileName();
                    documentWriterInstance.BeginDocument(fileName, DocumentFormat.Pdf);

                    {
                        var page = new Leadtools.Document.Writer.DocumentWriterRasterPage();
                        var finalImage = layoutImage;
                        if (options.LayoutPatientInfo)
                        {
                            // add text to the bottom of the resultant image.
                            layoutImageWithInfo.Image = layoutImage;
                            ProcessInstance(layoutImageWithInfo, userName, options, null);
                            finalImage = layoutImageWithInfo.Image;
                        }

                        page.Image = finalImage;
                        documentWriterInstance.AddPage(page);
                    }

                    documentWriterInstance.EndDocument();
                    MemoryStream ms = new MemoryStream(File.ReadAllBytes(fileName));
                    File.Delete(fileName);
                    ms.Position = 0;
                    return ms;
                }
                finally
                {
                    if (null != documentWriterInstance)
                        documentWriterInstance.EndDocument();
                }
            }

            return null;
        }

        public Stream PrintSeries(string userName, string[] seriesInstanceUIDs, PrintOptions options, string annotationData)
       {
          DocumentWriter documentWriterInstance = null;
          
          try
          {
            List<SeriesImage> seriesImages = _Exporter.GetSeriesImages(seriesInstanceUIDs);
            Dictionary<string, List<AnnContainer>> annotations = AddInsUtils.GetAnnotations(annotationData);

            documentWriterInstance = OpenDocumentWriterInstance(options.PageWidth, options.PageHeight, 300);
            string fileName = Path.GetTempFileName();
            documentWriterInstance.BeginDocument(fileName, DocumentFormat.Pdf);

            foreach (SeriesImage si in seriesImages)
            {
               ProcessInstance(si, userName, options, annotations);

               {
                  var page = new Leadtools.Document.Writer.DocumentWriterRasterPage();
                  page.Image = si.Image;
                  documentWriterInstance.AddPage(page);
               }
            }

            documentWriterInstance.EndDocument();
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(fileName));
            File.Delete(fileName);
            ms.Position = 0;
            return ms;
          }
          finally
          {
             if (null != documentWriterInstance)
                documentWriterInstance.EndDocument();
          }
       }

        public string GetInstanceLocalPathName(string userName, string instanceUID)
        {
           try
           {
              string referencedFile = _Exporter.GetInstanceLocalPathName(instanceUID);
              if (string.IsNullOrEmpty(referencedFile))
              {
                 referencedFile = _Exporter.GetSeriesLocalPathName(instanceUID);
              }
              return referencedFile;
           }
           catch
           {
              return string.Empty;
           }
        }

        #endregion

        private void ProcessInstance(SeriesImage seriesImage, string userName, PrintOptions options, Dictionary<string, List<AnnContainer>> annotations)
        {
           ResetGrayscale(seriesImage.Image, options.ReduceGrayscaleTo8BitsSelected);

           List<DicomDataSet> ds = _Exporter.GetInstanceDatasets(new string[] { seriesImage.SOPInstanceUID });
           
           double xDpi = 0;
           double yDpi = 0;

           if (ds.Count > 0)
           {
              AddInsUtils.GetDpi(ds[0], out xDpi, out yDpi);

              if (options.PatientInfo)
              {
                 string name = ds[0].GetValue<string>(DicomTag.PatientName, string.Empty);
                 string id = ds[0].GetValue<string>(DicomTag.PatientID, string.Empty);
                 string sex = ds[0].GetValue<string>(DicomTag.PatientSex, string.Empty);
                 string date = ds[0].GetValue<string>(DicomTag.SeriesDate, string.Empty);
                 string icomments = ds[0].GetValue<string>(DicomTag.ImageComments, string.Empty);
                 string fcomments = ds[0].GetValue<string>(DicomTag.FrameComments, string.Empty);
                 string patientDOB = ds[0].GetValue<string>(DicomTag.PatientBirthDate, string.Empty);
                 string seriesDecription = ds[0].GetValue<string>(DicomTag.SeriesDescription, string.Empty);

                    string tag = string.Empty;

                 if (!string.IsNullOrEmpty(name))
                    tag += string.Format("Patient: {1}{0}", Environment.NewLine, name.Replace('^', ' '));
                 if (!string.IsNullOrEmpty(id))
                    tag += string.Format("Patient ID: {1}{0}", Environment.NewLine, id);
                 if (!string.IsNullOrEmpty(sex))
                    tag += string.Format("Sex: {1}{0}", Environment.NewLine, sex);
                 if (!string.IsNullOrEmpty(date))
                    tag += string.Format("Date: {1}{0}", Environment.NewLine, date);
                 if (!string.IsNullOrEmpty(icomments))
                    tag += string.Format("Comments: {1}{0}", Environment.NewLine, icomments);
                 if (!string.IsNullOrEmpty(fcomments))
                    tag += string.Format("Comments: {1}{0}", Environment.NewLine, fcomments);


                    if (options.LayoutPatientInfo)
                    {
                        tag = string.Empty;

                        if (!string.IsNullOrEmpty(id))
                            tag += string.Format("Patient ID: {1}{0}", Environment.NewLine, id);

                        if (!string.IsNullOrEmpty(name))
                            tag += string.Format("Patient: {1}{0}", Environment.NewLine, name.Replace('^', ' '));

                        if (!string.IsNullOrEmpty(patientDOB))
                            tag += string.Format("Brith Date: {1}{0}", Environment.NewLine, patientDOB);

                        if (!string.IsNullOrEmpty(sex))
                            tag += string.Format("Sex: {1}{0}", Environment.NewLine, sex);

                        if (!string.IsNullOrEmpty(date))
                            tag += string.Format("Date: {1}{0}", Environment.NewLine, date);

                        if (!string.IsNullOrEmpty(seriesDecription))
                            tag += string.Format("Description: {1}{0}", Environment.NewLine, date);
                    }


                 if (!string.IsNullOrEmpty(tag))
                 {
                    // adjust the text size based on the size of the output image.
                    var imageTagged = AddTextFooter(seriesImage.Image, tag, options.LayoutPatientInfo ? Math.Max(100, seriesImage.Image.Height / 5) : 100);
                    seriesImage.Image.Dispose();
                    seriesImage.Image = null;
                    seriesImage.Image = imageTagged;
                 }
              }
           }

           try
           {
              if (options.BurnAnnotations)
              {
                  if (annotations.ContainsKey(seriesImage.SOPInstanceUID))
                 {
                        foreach (AnnContainer container in annotations[seriesImage.SOPInstanceUID])
                        {
                            container.IsVisible = true;
                            seriesImage.Image.Burn(container, xDpi, yDpi);
                        }
                 }
              }
           }
           catch { }//ignored
        }

        private static RasterImage CreateTextFooter(LeadSize size, string tag)
        {
           var bpp = 24;
           var byteOrder = RasterByteOrder.Bgr;
           var viewPerspective = RasterViewPerspective.TopLeft;

           var image = new RasterImage(RasterMemoryFlags.Conventional, size.Width, size.Height, bpp, byteOrder, viewPerspective, null, null, 0);

           var fill = new FillCommand(RasterColor.FromKnownColor(RasterKnownColor.White));
           fill.Run(image);

           using (var graphics = RasterImagePainter.CreateGraphics(image))
           {
              using (var brush = new SolidBrush(Color.Black))
              {
                 using (var font = new Font(FontFamily.GenericSansSerif, size.Width / 128))
                 {
                    var pos = new PointF(0, 0);

                    {
                       SizeF stringSize = new SizeF();
                       stringSize = graphics.Graphics.MeasureString(tag, font);

                       float scaleX = (float)size.Width / stringSize.Width;
                       float scaleY = (float)size.Height / stringSize.Height;

                       scaleX = Math.Min(1f, scaleX);
                       scaleY = Math.Min(1f, scaleY);

                       graphics.Graphics.ScaleTransform(scaleX, scaleY);

                       if (size.Height > (int)stringSize.Height)
                       {
                          size.Height = (int)stringSize.Height;
                       }
                    }

                    graphics.Graphics.DrawString(tag, font, Brushes.Black, new PointF(0, 0));
                 }
              }
           }

           if (size.Height < image.Height)
           {
              var crop = new CropCommand(LeadRect.FromLTRB(0, 0, size.Width, size.Height));
              crop.Run(image);
           }

           return image;
        }

        private RasterImage AddTextFooter(RasterImage image, string tag, int footerMaxHeight)
        {
           LeadRect bounds = LeadRect.Create(0, 0, image.Width, image.Height);
           using (var imageTag = CreateTextFooter(LeadSize.Create(bounds.Width, footerMaxHeight), tag))
           {
              bounds.Height += imageTag.Height;

              var bpp = 24;
              var byteOrder = RasterByteOrder.Bgr;
              var viewPerspective = RasterViewPerspective.TopLeft;

              if (image.ViewPerspective != viewPerspective)
              {
                 image.ChangeViewPerspective(viewPerspective);
              }

              if (image.BitsPerPixel != bpp || image.Order != byteOrder)
              {
                 var colorResCommand = new ColorResolutionCommand(
                    ColorResolutionCommandMode.InPlace,
                    bpp,
                    byteOrder,
                    RasterDitheringMethod.None,
                    ColorResolutionCommandPaletteFlags.Optimized,
                    null);
                 colorResCommand.Run(image);
              }

              RasterImage imageResult = new RasterImage(RasterMemoryFlags.Conventional, bounds.Width, bounds.Height, bpp, byteOrder, viewPerspective, null, null, 0);

              {
                 var combine = new CombineFastCommand(imageResult, bounds, LeadPoint.Create(0, 0), CombineFastCommandFlags.SourceCopy);
                 combine.Run(image);
              }

              {
                 var combine = new CombineFastCommand(imageResult, LeadRect.Create(bounds.X, image.Height, bounds.Width, bounds.Height - image.Height), LeadPoint.Create(0, 0), CombineFastCommandFlags.SourceCopy);
                 combine.Run(imageTag);
              }
              return imageResult;
           }           
        }

        private DocumentWriter OpenDocumentWriterInstance(double pageWidth, double pageHeight, int resolution)
        {
           DocumentWriter documentWriterInstance = null;

           try
           {
              documentWriterInstance = new DocumentWriter();
              {
                 PdfDocumentOptions pdfOptions = documentWriterInstance.GetOptions(DocumentFormat.Pdf) as PdfDocumentOptions;

                 int emptyPageResolution = resolution;
                 if ((int)pageWidth == 0)
                    pageWidth = 11;
                 if ((int)pageHeight == 0)
                    pageHeight = 8.5;
                 pdfOptions.EmptyPageResolution = emptyPageResolution;
                 pdfOptions.DocumentResolution = emptyPageResolution;
                 pdfOptions.EmptyPageWidth = pageWidth;
                 pdfOptions.EmptyPageHeight = pageHeight;
                 pdfOptions.PageRestriction = DocumentPageRestriction.Relaxed;
                 pdfOptions.PrintEnabled = true;
                 pdfOptions.ImageOverText = true;

                 documentWriterInstance.SetOptions(DocumentFormat.Pdf, pdfOptions);
              }

              return documentWriterInstance;
           }
           catch (Exception)
           {
              throw;
           }
        }

        private ZipFile LoadInstances(List<SeriesImage> seriesImages, string userName, ExportOptions options)
        {
            ZipFile zip = null;            
            string extension = string.Empty;
         bool isLossless = false;
            RasterImageFormat format = GetFormat(options.FileFormat, out extension, out isLossless );
            Dictionary<string, Dictionary<string, List<AnnContainer>>> seriesAnnotations = new Dictionary<string, Dictionary<string, List<AnnContainer>>>();

            foreach (SeriesImage seriesImage in seriesImages)
            {
                string fileName = Path.ChangeExtension(Path.GetRandomFileName(), extension);

                if (options.BurnAnnotations)
                {
                    if (!seriesAnnotations.ContainsKey(seriesImage.SeriesInstanceUID))
                        seriesAnnotations[seriesImage.SeriesInstanceUID] = AddInsUtils.GetSeriesAnnotations(userName, seriesImage.SeriesInstanceUID, _QueryAddIn, _ObjectRetrieveAddIn);

                    if (seriesAnnotations[seriesImage.SeriesInstanceUID].ContainsKey(seriesImage.SOPInstanceUID))
                    {
                        foreach (AnnContainer container in seriesAnnotations[seriesImage.SeriesInstanceUID][seriesImage.SOPInstanceUID])
                            seriesImage.Image.Burn(container, seriesImage.XDpi, seriesImage.YDpi);
                    }
                }

                ResetGrayscale(seriesImage.Image, options.ReduceGrayscaleTo8BitsSelected);
                if (zip == null)
                    zip = new ZipFile();
                zip.AddEntry(fileName, seriesImage.Image.ToStream(format, (!isLossless &&(format == RasterImageFormat.Jpeg || format == RasterImageFormat.Cmp)) ? GetCompression(options.ImageCompression) : 0));
                zip.Dispose();
            }
            return zip;
        }

        private RasterImageFormat GetFormat(string format, out string extension, out bool isLossless)
        {
            isLossless = false;
            RasterImageFormat fileFormat = RasterImageFormat.Unknown;

            switch (format.ToLower())
            {
                case "bmp":
                    fileFormat = RasterImageFormat.Bmp;
                    extension = "bmp";
                    break;
                case "jpg lossless":
                    fileFormat = RasterImageFormat.Jpeg;
                    extension = "jpg";
                    isLossless = true;
                    break;
                case "png":
                    fileFormat = RasterImageFormat.Png;
                    extension = "png";
                    break;
                case "tif":
                    fileFormat = RasterImageFormat.Tif;
                    extension = "tif";
                    break;
                case "cmp":
                    fileFormat = RasterImageFormat.Cmp;
                    extension = "cmp";
                    break;
                case "dicom":
                    fileFormat = RasterImageFormat.DicomGray;
                    extension = "dcm";
                    break;
                default:
                    fileFormat = RasterImageFormat.Jpeg;
                    extension = "jpg";
                    break;
            }
            return fileFormat;
        }

        private string GetFolderName(Dictionary<string, int> studies, Dictionary<string, int> series, ref int nextStudy, ref int nextSeries, string studyInstanceUID, string seriesIntanceUID)
        {
            string path = string.Empty;

            if (!studies.ContainsKey(studyInstanceUID))
            {
                studies[studyInstanceUID] = nextStudy;
                nextStudy++;
            }
            path += @"\Study" + studies[studyInstanceUID].ToString();

            if (!series.ContainsKey(seriesIntanceUID))
            {
                series[seriesIntanceUID] = nextSeries;
                nextSeries++;
            }
            path += @"\Series" + series[seriesIntanceUID].ToString() + @"\";

            return path;
        }

        private string GetDestinationFolder()
        {
            string tempDir = ConfigurationManager.AppSettings["TemporaryDirectory"];

            if (string.IsNullOrEmpty(tempDir))
                tempDir = Path.GetTempPath();

            return Path.Combine(tempDir, CoreUtils.RandomString(5) + Path.DirectorySeparatorChar);
        }


        private void IncludeViewer(ref ZipFile zip)
        {
            string viewerDir = ConfigurationManager.AppSettings["ExportViewerFolder"];

            // check the validity of the provided folder.
            if (viewerDir.Length > 0 && Directory.Exists(viewerDir))
            {
                string[] files = Directory.GetFiles(viewerDir);

                // no files exists in this directory, or something went wrong
                if (files == null)
                    return;

                int index = 0;
                int length = files.Length;

                // go through all the files in the direcotry, and only include, the dlls, the CSMedicalWorkstationDicomDirDemo exe and config file.
                for (index = 0; index < length; index++)
                {
                    if ((Path.GetExtension(files[index]) == ".dll") ||
                        (Path.GetFileName(files[index]).Contains("MedicalWorkstationDicomDir")))
                    {
                        zip.AddFile(files[index], string.Empty);
                    }
                }
            }
        }

    private MemoryStream ExportToDICOMDIR(ref ZipFile zip, List<DicomDataSet> datasets, ExportOptions options)
    {
        DicomDir dir;
        string dirDestination = string.Empty;
        string folderPath;
        MemoryStream zipStream = new MemoryStream();

        dirDestination = GetDestinationFolder();
        if (!Directory.Exists(dirDestination))
            Directory.CreateDirectory(dirDestination);
        dir = new DicomDir(dirDestination);
        folderPath = Path.Combine(dirDestination, @"DICOM\");
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        try
        {
            Dictionary<string, int> studies = new Dictionary<string, int>();
            Dictionary<string, int> series = new Dictionary<string, int>();
            int nextStudy = 0;
            int nextSeries = 0;

            ExportExtensions.ResetAnonymization();
            foreach (DicomDataSet dataset in datasets)
            {
                string studyInstance = dataset.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty);
                string seriesInstance = dataset.GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);
                string sopInstance = dataset.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
                string fileName = sopInstance + ".dcm";
                string path = GetFolderName(studies, series, ref nextStudy, ref nextSeries, studyInstance, seriesInstance);
                if (zip == null)
                {
                    zip = new ZipFile();
                }

                if (options.FileFormat.ToLower() == "dicomzip" && !string.IsNullOrEmpty(options.DczPassword))
                {
                    zip.Password = options.DczPassword;
                }

                if (options.Anonymize)
                    dataset.Anonymize();
                dataset.Save(folderPath + fileName, DicomDataSetSaveFlags.MetaHeaderPresent);
                zip.AddEntry(@"DICOM\" + fileName, dataset.ToStream());
                dir.InsertDataSet(dataset, folderPath + fileName);
            }

            dir.Save();
            if (zip != null)
            {
                zip.AddFile(dirDestination + "DICOMDIR", string.Empty);
                if (options.IncludeViewer)
                {
                    IncludeViewer(ref zip);
                }
                zip.Save(zipStream);
                zip.Dispose();
            }
            zipStream.Position = 0;
        }
        finally
        {
            if (!string.IsNullOrEmpty(dirDestination))
            {
                if (Directory.Exists(dirDestination))
                    Directory.Delete(dirDestination, true);
            }
        }
        return zipStream;
    }

    private void ResetGrayscale(RasterImage image, bool reduce)
        {
            if (image.BitsPerPixel < 24 &&
                 (image.Signed || reduce))
            {
                GrayscaleCommand cmgGray;

                cmgGray = new GrayscaleCommand(8);

                cmgGray.Run(image);
            }
        }
    }
}
