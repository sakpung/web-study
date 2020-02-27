// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Caching;
using System.Web.Script.Serialization;
using System.Xml;

using Leadtools.Annotations.Engine;
using Leadtools.Dicom.Annotations;
using Leadtools.Annotations.Rendering;
using Leadtools.Codecs;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom.Common.Medical;
using Leadtools.Dicom.Imaging;
using Leadtools.Dicom.Scp.Command;
using Leadtools.Drawing;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Core;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer.Catalog;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.Medical.Logging.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Interface;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.WebViewer.Addins.Common;
using Leadtools.Medical.WebViewer.Core.Addins;
using Leadtools.Medical.WebViewer.Core.DataTypes;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.Winforms.Common;

using CodeSequence = Leadtools.Dicom.Common.DataTypes.CodeSequence;
using SortingOperation = Leadtools.Dicom.Common.Medical.SortingOperation;
using Leadtools.Medical3D.Client;


namespace Leadtools.Medical.WebViewer.Addins
{
    public class UserFunction
    {
        public string Name { get; set; }
        public string Metadata { get; set; }
    }

   internal class DicomUids
   {
      public string StudyInstanceUid;
      public string SeriesInstanceUid;
   }

    /// <summary>
    /// The Add-in which is used to return DICOM instances/images in different format (Binary, image, audio, presentation state...)
    /// </summary>
    public class ObjectRetrieveAddin : IObjectRetrieveAddin
    {
        private Dictionary<string, Action<RasterImage, string[]>> _ProcessingActions = new Dictionary<string, Action<RasterImage, string[]>>(StringComparer.OrdinalIgnoreCase);

        IStorageDataAccessAgent3 DataAccess { get; set; }

        private static System.Web.Caching.Cache _cache = HttpRuntime.Cache;

        public static Cache Cache
        {
            get
            {
                return _cache;
            }
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

        public IAuthorizedStorageDataAccessAgent AuthorizedDataAccess
        {
            get;
            private set;
        }

        Leadtools.Dicom.Imaging.IDataCacheProvider DataCache
        {
            get;
            set;
        }

        private IQueryAddin _QueryAddIn = null;
        string StorageServerServicePath { get; set; }
        Lazy<IExternalStoreDataAccessAgent> ExternalStoreAgent { get; set; }
        ILoggingDataAccessAgent LoggingAgent { get; set; }

        public ObjectRetrieveAddin(IStorageDataAccessAgent3 dataAccess, Lazy<IExternalStoreDataAccessAgent> externalStoreAgent, ILoggingDataAccessAgent loggingAgent, string storageServerServicePath, IOptionsDataAccessAgent optionsAgent, IPermissionManagementDataAccessAgent2 permissionsAgent, IAuthorizedStorageDataAccessAgent2 authAgent, Leadtools.Dicom.Imaging.IDataCacheProvider dataCache)
        {
            DataAccess = dataAccess;
            ExternalStoreAgent = externalStoreAgent;
            LoggingAgent = loggingAgent;
            StorageServerServicePath = storageServerServicePath;
            OptionsDataAccess = optionsAgent;
            PermissionsDataAccess = permissionsAgent;
            AuthorizedDataAccess = authAgent;
            DataCache = dataCache;
            InitializeFunctions();

            _QueryAddIn = new DatabaseQueryAddin(authAgent, optionsAgent, permissionsAgent, externalStoreAgent, loggingAgent, storageServerServicePath, null, dataCache);

        }

        private void InitializeFunctions()
        {
            _ProcessingActions.Add("MultiscaleEnhancement", ProcessingActions.MultiscaleEnhancement);
            _ProcessingActions.Add("GammaCorrect", ProcessingActions.GammaCorrect);
            _ProcessingActions.Add("UnsharpMask", ProcessingActions.UnsharpMask);
            _ProcessingActions.Add("BrightnessContrast", ProcessingActions.BrightnessContrast);
            _ProcessingActions.Add("HSL", ProcessingActions.HSL);
            _ProcessingActions.Add("StretchHistogram", ProcessingActions.StretchHistogram);
            _ProcessingActions.Add("WindowLevel", ProcessingActions.WindowLevel);
            _ProcessingActions.Add("Invert", ProcessingActions.Invert);
            _ProcessingActions.Add("Flip", ProcessingActions.Flip);
            _ProcessingActions.Add("Rotate", ProcessingActions.Rotate);
        }

        /// <summary>
        /// returns a DICOM Dataset as binary
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="options"></param>
        /// <param name="extraOptions"></param>
        /// <returns></returns>
        public Stream GetDicom(ObjectUID uid, GetDicomOptions options)
        {
            //query for the DICOM instance row, then create a DICOM retrieve command to get the DICOM DataSet
            DataRow instanceRow = GetDicomInstanceRow(uid.SOPInstanceUID);

            MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(DataAccess, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, true);

         DicomDataSet ds;
         

         //apply some options into the DICOM DataSet
         using (ds = dsLoadCmd.GetDicomDataSet(instanceRow))
         {
            if (options.StripImage)
            {
               StripDicomImage(ds);
            }

                if (!string.IsNullOrEmpty(options.TransferSyntax))
                {
                    string dsTransfer;


                    dsTransfer = ds.GetValue<string>(DicomTag.TransferSyntaxUID, string.Empty);

                    if (string.Compare(options.TransferSyntax, dsTransfer) != 0)
                    {
                        ds.ChangeTransferSyntax(options.TransferSyntax,
                                                  options.QualityFactor,
                                                  ChangeTransferSyntaxFlags.None);                        
                    }
                }

                //save and return as binary
                return new MemoryStream(SaveDICOMDataSet(ds));
            }
        }
      
        /// <summary>
        /// Returns the image data in a DICOM DataSet as binary
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="extraOptions"></param>
        /// <param name="frame"></param>
        /// <returns></returns>
        public byte[] GetBinaryDicomImageData(ObjectUID uid, int frame, ImageSize imageSize)
        {
            //query the DICOM dataset, then create a DICOM retrieve command to load the DataSet
            DataRow instanceRow = GetDicomInstanceRow(uid.SOPInstanceUID);
            MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(DataAccess, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, true);

            DicomDataSet ds;

            using (ds = dsLoadCmd.GetDicomDataSet(instanceRow))
            {
                RasterImage image = null;
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                if (null == ds)
                {
                    return null;
                }

                int width = 0;
                int height = 0;
                //check if the user sent custom image size. This is used now to control the images size on devices and for very large images
                    if (null != imageSize)
                    {
                        width = imageSize.width;
                        height = imageSize.height;
                }

                image = ExtractImage(ds, frame, width, height);
                if (imageSize.functions != null && imageSize.functions.Count > 0)
                {
                    try
                    {
                        foreach (ImageProcessingFunction function in imageSize.functions)
                        {
                            if (_ProcessingActions.ContainsKey(function.Name))
                            {
                                string[] parameters = function.Parameters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                _ProcessingActions[function.Name](image, parameters);
                            }
                        }
                    }
                    catch { }
                }

                //Get the image from the DICOM DataSet with the given width/height (0 means keep original)
                return GetImageBuffer(image);
            }
        }


        /// <summary>
        /// Returns the image data in a DICOM DataSet as binary
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <param name="extraOptions">The extra options.</param>
        /// <param name="frame">The frame.</param>
        /// <param name="userData">Custom data.</param>
        /// <returns></returns>
        public byte[] GetBinaryDicomImageDataAsPNG(ObjectUID uid,  int frame, ImageSize imageSize = null)
        {
            //query the DICOM dataset, then create a DICOM retrieve command to load the DataSet
            DataRow instanceRow = GetDicomInstanceRow(uid.SOPInstanceUID);

            MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(DataAccess, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, true);

            DicomDataSet ds;

            using (ds = dsLoadCmd.GetDicomDataSet(instanceRow))
            {
                if (null == ds)
                {
                    return null;
                }

                int width = 0;
                int height = 0;
                RasterImage image;
                

                    if (null != imageSize)
                    {
                        width = imageSize.width;
                        height = imageSize.height;
                }

                image = ExtractImage(ds, frame, width, height);

                if (imageSize != null && imageSize.functions != null && imageSize.functions.Count > 0)
                {
                    foreach (ImageProcessingFunction function in imageSize.functions)
                    {
                        if (_ProcessingActions.ContainsKey(function.Name))
                        {
                            string[] parameters = function.Parameters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                            _ProcessingActions[function.Name](image, parameters);
                        }
                    }
                }

                //Get the image from the DICOM DataSet with the given width/height (0 means keep original)
                var ms = new MemoryStream();
                GetImageBufferAsPNG(image, new byte[0], ms);
                return ms.ToArray();
            }
        }


        /// <summary>
        /// extract the image data from the DICOM dataset without recompression using the Raw Filter
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="frame"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private RasterImage ExtractImage(DicomDataSet ds, int frame, int width, int height)
        {
            DicomElement pixelElement = ds.FindFirstElement(null, DicomTag.PixelData, true);

            if (null != pixelElement && pixelElement.Length > 0)
            {
#if !LEADTOOLS_V20_OR_LATER
                RasterImage image = ds.GetImage(pixelElement, frame - 1, 0, RasterByteOrder.Bgr, DicomGetImageFlags.AutoDectectInvalidRleCompression);
#else
              RasterImage image = ds.GetImage(pixelElement, frame - 1, 0, RasterByteOrder.Bgr, DicomGetImageFlags.AutoDetectInvalidRleCompression);
#endif // #if !LEADTOOLS_V20_OR_LATER

                if (width != image.Width || height != image.Height)
                {
                    this.ResizeImage(image, width, height, false);
                }

                return image;
            }
            else
            {
                return null;
            }
        }

        private static MemoryStream GetImageStream(RasterImage image)
        {
            if (null == image)
            {
                throw new ArgumentException();
            }

            using (RasterCodecs codec = new RasterCodecs())
            {
                MemoryStream ms = new MemoryStream();
                {
                    codec.Save(image, ms, RasterImageFormat.Raw, image.BitsPerPixel);

                    return ms;
                }
            }
        }

        private byte[] GetImageBuffer(RasterImage image)
        {
            using (MemoryStream ms = GetImageStream(image))
            {
                return ms.ToArray();
            }
        }

        /// <summary>
        /// image resulted depth = 32bits, effective bpp is 16 bits
        /// meaning each pixel(4bytes) has 2 bytes of info
        ///
        /// following are the test results:
        /// 
        /// - 24bits PNG effective 24bits   9   MBytes     poor compression
        /// - 24bits PNG effective 16bits   7.5 MBytes     overhead processing in client
        /// - 32bits PNG effective 16bits   8   MBytes     used currently
        /// - 32bits PNG effective 32bits   7.5 MBytes     doesn't work for HTML5 client, alpha channel is applied on image before drawing, data is lost
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private static void GetImageBufferAsPNG32(RasterImage image, byte[] autoScaleString, MemoryStream msResult)
        {
            const int _bbp = 32;
            int _effectivebbp = 16;
            const RasterViewPerspective _vp = RasterViewPerspective.TopLeft;

            int stringLength = autoScaleString.Length;
            int autoScaleCounter = 0;
            byte[] buf = null;
            int fullValue;
            int mask = ((1 << (image.HighBit - image.LowBit + 1)) - 1) << image.LowBit;

            if (image.HighBit <= image.LowBit)
                mask = 0xFFFF;

            using (MemoryStream ms = GetImageStream(image))
            {

                if (image.BitsPerPixel == 32)
                {
                    _effectivebbp = 8;

                    buf = new byte[(ms.Length * _bbp) / _effectivebbp];

                    for (int index = 0; index < buf.Length; index += (_bbp / 8))
                    {
                        fullValue = (byte)ms.ReadByte();
                        fullValue = (fullValue | ((byte)ms.ReadByte() << 8)) & mask;

                        buf[index] = (byte)(fullValue & 0xFF);
                        buf[index + 1] = (byte)(fullValue >> 8);
                        // store custom values in the PNG.
                        if (autoScaleCounter >= stringLength)
                            buf[index + 2] = 0;
                        else
                        {
                            buf[index + 2] = autoScaleString[autoScaleCounter];
                            autoScaleCounter++;
                        }
                        buf[index + 3] = 0xff;
                    }
                }
                else
                {

                    buf = new byte[(ms.Length * _bbp) / _effectivebbp];


                    for (int index = 0; index < buf.Length; index += (_bbp / 8))
                    {
                        fullValue = (byte)ms.ReadByte();
                        fullValue = (fullValue | ((byte)ms.ReadByte() << 8)) & mask;

                        buf[index] = (byte)(fullValue & 0xFF);
                        buf[index + 1] = (byte)(fullValue >> 8);
                        // store custom values in the PNG.
                        if (autoScaleCounter >= stringLength)
                            buf[index + 2] = 0;
                        else
                        {
                            buf[index + 2] = autoScaleString[autoScaleCounter];
                            autoScaleCounter++;
                        }
                        buf[index + 3] = 0xff;
                    }
                }
            }

            double Width = image.Width;
            double Height = image.Height;

            using (RasterImage ri = new RasterImage(RasterMemoryFlags.Conventional, (int)Width * (16 / _effectivebbp), (int)Height, _bbp, RasterByteOrder.Bgr, _vp, null, buf, buf.Length))
            {
                buf = null;

                using (RasterCodecs codec = new RasterCodecs())
                {
                    codec.Save(ri, msResult, RasterImageFormat.Png, _bbp);
                    msResult.Position = 0;
                }
            }
        }

        /// <summary>
        /// image resulted depth = 8bits, effective bpp is 8 bits
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private static void GetImageBufferAsPNG8(RasterImage image, MemoryStream msResult)
        {
            using (RasterCodecs codec = new RasterCodecs())
            {
                codec.Save(image, msResult, RasterImageFormat.Png, 8);
                msResult.Position = 0;
            }
        }

        /// <summary>
        /// 8-bits images, returned in an 8-bits PNG
        /// other depths (16, 12) returned in 32-bits PNG (16-bits effective -only 2 bytes of the pixel have data-)
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static void GetImageBufferAsPNG(RasterImage image, byte[] autoScaleString, MemoryStream msResult)
        {
            if (image.BitsPerPixel == 32)
            {
                GetImageBufferAsPNG32(image, autoScaleString, msResult);
            }
            else
            {
                if (image.BitsPerPixel != 8)
                {
                    GetImageBufferAsPNG32(image, autoScaleString, msResult);
                }
                else
                {
                    GetImageBufferAsPNG8(image, msResult);
                }
            }
        }

        /// <summary>
        /// Get the DICOM DataSet as XML (without the actual image). Used for displaying the tags and information about the dataset in REST service
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="extraOptions"></param>
        /// <returns></returns>
        public XmlElement GetDicomXml(ObjectUID uid)
        {
            //Get the DICOM Instance table 
            DataTable instanceTable = GetDicomInstanceTable(uid, false);

            XmlDocument xmlDocument = new XmlDocument();

            //write the DICOM DS as XML
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings();

                settings.CloseOutput = false;
                settings.Indent = false;
                settings.NewLineHandling = NewLineHandling.None;
                settings.NewLineOnAttributes = false;
                settings.OmitXmlDeclaration = false;
                //settings.Encoding = Encoding.Unicode ;

                XmlWriter xmlWriter = XmlWriter.Create(ms, settings);

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("root");

                MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(DataAccess, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, true);

                foreach (DataRow instanceRow in instanceTable.Rows)
                {
                    using (DicomDataSet ds = dsLoadCmd.GetDicomDataSet(instanceRow))
                    {
                        //using ( MemoryStream tempMs = new MemoryStream ( ) ) 
                        {
                            ds.ToXml(xmlWriter);
                        }
                    }

                }



                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Flush();

                ms.Position = 0;

                xmlDocument.Load(ms);
            }

            return xmlDocument.DocumentElement;
        }

      
      private RasterImage GetImage(string sopInstanceUID, int frame, int width, int height)
      {
         RasterImage image = null;

            try
            {
                DataRow instanceRow = GetDicomInstanceRow(sopInstanceUID);

                if (instanceRow != null)
                {
                    //for a strong id:
                    //var sopInstanceUID = RegisteredDataRows.InstanceInfo.GetElementValue(instanceRow, DicomTag.SOPInstanceUID);

                    var referencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(instanceRow);

                    if (string.IsNullOrEmpty(referencedFile))//external storage?
                    {
                        MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(DataAccess, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, true);
                        using (var ds = dsLoadCmd.GetDicomDataSet(instanceRow, out referencedFile))
                        {
                        }
                    }

               if (!string.IsNullOrEmpty(referencedFile))
               {
                  using (var dicomSourceProxy = new DicomSourceProxy(DataCache))
                  {
                     //we may load small res images from a nearest available matching resolution
                     var matchNearestResolution = (width < 100 && height < 100) ? true : false;
                     var query = new ViewImageQuery()
                     {
                        FileName = referencedFile,
                        FrameNumber = frame,
                        Resolution = LeadSize.Create(width, height),
                        MatchAspectRatio = true,
                        MatchNearestResolution = matchNearestResolution,
                        Rasterize = true
                     };

                     try
                     {
                        var result = dicomSourceProxy.Load(query);
                        image = result.Image;

                        if (matchNearestResolution)
                        {
                           ResizeImage(image, width, height, true, RasterSizeFlags.Resample);
                        }
                     }
                     catch
                     {
                        image = null;
                     }
                  }
               }
            }
         }
         catch
         {
            image = null;
         }

            return image;
        }
               
        public Stream GetImage(string sopInstanceUID, int frame, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height, string userData)
        {
            using (RasterCodecs codec = new RasterCodecs())
            {
                RasterImageFormat format = GetRasterImageFormat(mimeType);
                RasterImage image = GetImage(sopInstanceUID, frame, width, height);
                MemoryStream imageStream = new MemoryStream();

                if (image == null)
                    return null;

                if (format == RasterImageFormat.Jpeg)
                {
                    codec.Options.Jpeg.Save.QualityFactor = qualityFactor;
                    codec.Options.Jpeg.Save.Passes = -1;
                }

                if (bitsPerPixel == 0)
                {
                    if (format == RasterImageFormat.Jpeg)
                    {
                        if (image.BitsPerPixel >= 24)
                        {
                            bitsPerPixel = 24;
                        }
                        else
                        {
                            bitsPerPixel = 8;
                        }
                    }
                    else
                    {
                        if (image.BitsPerPixel < 8)
                            bitsPerPixel = 8;
                        else
                            bitsPerPixel = 32;
                    }
                }

                codec.Save(image, imageStream, format, bitsPerPixel);

                return imageStream;
            }
        }

        public Stream DownloadImage(string sopInstanceUID, int frame, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height, string annotationData, double xDpi, double yDpi, string userData)
        {
            RasterImage image = LoadDicomImage(sopInstanceUID, frame);

            if (image == null)
            {
                return null;
            }

            ApplyProcessingAction(userData, image, _ProcessingActions);

            if (!String.IsNullOrEmpty(annotationData))
            {
                if (image.BitsPerPixel != 24)
                {
                    Leadtools.ImageProcessing.ColorResolutionCommand cmd = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, 24, RasterByteOrder.Bgr, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.None, null);

                    cmd.Run(image);
                }

                AnnCodecs codecs = new AnnCodecs();
                AnnContainer container = codecs.LoadFromString(annotationData, 1);

                // The Medical Viewer defaults dpi to 150
                // In this case, there is enough information to compute the dpi, which should be 150
                // container.CalculateDpi(image, width, height, ref xDpi, ref yDpi);
                double calibrationScale = container.Mapper.CalibrationScale;
                container.Mapper = new AnnContainerMapper(150, 150, xDpi, yDpi);

                LeadMatrix transform = container.Mapper.Transform;

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                ImageProcessingFunction[] functions = serializer.Deserialize<ImageProcessingFunction[]>(userData);

                if (functions != null && functions.Length > 0)
                {
                    foreach (ImageProcessingFunction function in functions)
                    {
                        string[] parameters = function.Parameters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        switch (function.Name)
                        {
                            case "Flip":
                                bool fliped;

                                if (bool.TryParse(parameters[0], out fliped))
                                {
                                    if (fliped)
                                        transform.ScaleAt(1, -1, image.Width / 2.0, image.Height / 2.0);
                                }
                                break;

                            case "Rotate":

                                int angle;
                                if (int.TryParse(parameters[0], out angle))
                                {
                                    PointF[] pts =
                                      {
                              new PointF(0, 0),
                              new PointF(image.Width, 0),
                              new PointF(image.Width, image.Height),
                              new PointF(0, image.Height)
                           };

                                    PointF origin = new PointF(image.Width / 2.0f, image.Height / 2.0f);

                                    using (Matrix m = new Matrix())
                                    {
                                        m.RotateAt(angle, origin);
                                        m.TransformPoints(pts);
                                    }

                                    double xMin = pts[0].X;
                                    double yMin = pts[0].Y;

                                    for (int i = 1; i < pts.Length; i++)
                                    {
                                        if (pts[i].X < xMin)
                                            xMin = pts[i].X;

                                        if (pts[i].Y < yMin)
                                            yMin = pts[i].Y;
                                    }

                                    double xTranslate = -xMin;
                                    double yTranslate = -yMin;

                                    LeadPointD annOrigin = LeadPointD.Create(origin.X, origin.Y);
                                    AnnContainerMapper mapper = container.Mapper.Clone();
                                    mapper.UpdateTransform(LeadMatrix.Identity);
                                    annOrigin = mapper.PointToContainerCoordinates(annOrigin);

                                    LeadPointD offset = LeadPointD.Create(xTranslate, yTranslate);
                                    offset = mapper.PointToContainerCoordinates(offset);

                                    foreach (AnnObject obj in container.Children)
                                    {
                                        obj.Rotate(angle, annOrigin);

                                        if (xTranslate != 0 || yTranslate != 0)
                                            obj.Translate(offset.X, offset.Y);
                                    }
                                }
                                break;

                            case "Reverse":
                                bool reversed;

                                if (bool.TryParse(parameters[0], out reversed))
                                {
                                    if (reversed)
                                        transform.ScaleAt(-1, 1, image.Width / 2.0, image.Height / 2.0);
                                }
                                break;

                        }
                    }
                }

                container.Mapper.UpdateTransform(transform);
                container.Mapper.Calibrate(LeadLengthD.Create(1), AnnUnit.Unit, new LeadLengthD(calibrationScale), AnnUnit.Unit);

                RasterColor[] colors = image.GetPalette();
                IntPtr hDC = RasterImagePainter.CreateLeadDC(image);
                if (hDC != null && hDC != IntPtr.Zero)
                {
                    using (Graphics g = Graphics.FromHdc(hDC))
                    {   //g.ScaleTransform((float)(g.DpiX/ xDpi), (float)(g.DpiY/yDpi));                   
                        // Create a new rendering engine for this container and context
                        AnnWinFormsRenderingEngine renderingEngine = new AnnWinFormsRenderingEngine(container, g);


                        container.Mapper.BurnScaleFactor = xDpi / 150;

                        // Burn it
                        renderingEngine.Burn();
                    }

                    RasterImagePainter.DeleteLeadDC(hDC);
                }
            }

            if ((width != 0 && height != 0) && (width < image.Width || height < image.Height))
            {
                ResizeImage(image, width, height, true);
            }

            if (null != image && image.Signed)
            {
                Leadtools.ImageProcessing.GrayscaleCommand cmd = new Leadtools.ImageProcessing.GrayscaleCommand(8);

                cmd.Run(image);
                //Set this flag to false because there is no signed 8 bit Gray scale image 
                image.Signed = false;
            }

            MemoryStream imageStream = new MemoryStream();

            using (RasterCodecs codec = new RasterCodecs())
            {
                codec.Options.Jpeg.Save.QualityFactor = qualityFactor;
                codec.Options.Jpeg.Save.Passes = 0;//not progressive, since it consumes tons of memory space

                if (bitsPerPixel == 0)
                {
                    if (image.BitsPerPixel >= 24)
                    {
                        bitsPerPixel = 24;
                    }
                    else
                    {
                        bitsPerPixel = 8;
                    }

                }

                codec.Save(image, imageStream, GetRasterImageFormat(mimeType), bitsPerPixel);

                image.Dispose();

                return imageStream;
            }
        }

        public void BurnAnnotations(RasterImage image, string annotationData, double xDpi, double yDpi)
        {
            if (!String.IsNullOrEmpty(annotationData))
            {
                if (image.BitsPerPixel != 24)
                {
                    Leadtools.ImageProcessing.ColorResolutionCommand cmd = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, 24, RasterByteOrder.Bgr, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.None, null);

                    cmd.Run(image);
                }

                AnnCodecs codecs = new AnnCodecs();
                AnnContainer container = codecs.LoadFromString(annotationData, 1);

                container.Mapper = new AnnContainerMapper(xDpi, yDpi, xDpi, yDpi);

                LeadMatrix transform = container.Mapper.Transform;

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                ImageProcessingFunction[] functions = null;// serializer.Deserialize<ImageProcessingFunction[]>(userData);

                if (functions != null && functions.Length > 0)
                {
                    foreach (ImageProcessingFunction function in functions)
                    {
                        string[] parameters = function.Parameters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        switch (function.Name)
                        {
                            case "Flip":
                                bool fliped;

                                if (bool.TryParse(parameters[0], out fliped))
                                {
                                    if (fliped)
                                        transform.ScaleAt(1, -1, image.Width / 2.0, image.Height / 2.0);
                                }
                                break;

                            case "Rotate":

                                int angle;
                                if (int.TryParse(parameters[0], out angle))
                                {
                                    PointF[] pts =
                                             {
                              new PointF(0, 0),
                              new PointF(image.Width, 0),
                              new PointF(image.Width, image.Height),
                              new PointF(0, image.Height)
                           };

                                    PointF origin = new PointF(image.Width / 2.0f, image.Height / 2.0f);

                                    using (Matrix m = new Matrix())
                                    {
                                        m.RotateAt(angle, origin);
                                        m.TransformPoints(pts);
                                    }

                                    double xMin = pts[0].X;
                                    double yMin = pts[0].Y;

                                    for (int i = 1; i < pts.Length; i++)
                                    {
                                        if (pts[i].X < xMin)
                                            xMin = pts[i].X;

                                        if (pts[i].Y < yMin)
                                            yMin = pts[i].Y;
                                    }

                                    double xTranslate = -xMin;
                                    double yTranslate = -yMin;

                                    LeadPointD annOrigin = LeadPointD.Create(origin.X, origin.Y);
                                    AnnContainerMapper mapper = container.Mapper.Clone();
                                    mapper.UpdateTransform(LeadMatrix.Identity);
                                    annOrigin = mapper.PointToContainerCoordinates(annOrigin);

                                    LeadPointD offset = LeadPointD.Create(xTranslate, yTranslate);
                                    offset = mapper.PointToContainerCoordinates(offset);

                                    foreach (AnnObject obj in container.Children)
                                    {
                                        obj.Rotate(angle, annOrigin);

                                        if (xTranslate != 0 || yTranslate != 0)
                                            obj.Translate(offset.X, offset.Y);
                                    }
                                }
                                break;

                            case "Reverse":
                                bool reversed;

                                if (bool.TryParse(parameters[0], out reversed))
                                {
                                    if (reversed)
                                        transform.ScaleAt(-1, 1, image.Width / 2.0, image.Height / 2.0);
                                }
                                break;

                        }
                    }
                }

                container.Mapper.UpdateTransform(transform);


                RasterColor[] colors = image.GetPalette();
                IntPtr hDC = RasterImagePainter.CreateLeadDC(image);
                if (hDC != null && hDC != IntPtr.Zero)
                {
                    using (Graphics g = Graphics.FromHdc(hDC))
                    {  // g.ScaleTransform((float)(g.DpiX/ xDpi), (float)(g.DpiY/yDpi));                   
                       // Create a new rendering engine for this container and context
                        AnnWinFormsRenderingEngine renderingEngine = new AnnWinFormsRenderingEngine(container, g);

                        container.Mapper.BurnScaleFactor = xDpi / 150;

                        // Burn it
                        renderingEngine.Burn();
                    }

                    RasterImagePainter.DeleteLeadDC(hDC);
                }
            }
        }

      private RasterImage LoadDicomImage(string sopInstanceUID, int frame)
      {
         //GetReferencedFile already handles external storage
         var referencedFile = GetReferencedFile(new ObjectUID() { SOPInstanceUID = sopInstanceUID });

         if (!string.IsNullOrEmpty(referencedFile))
         {
            using (var dicomSourceProxy = new DicomSourceProxy(DataCache))
            {
               if (frame <= 0)
               {
                  frame = 1;
               }
               var query = new ViewImageQuery() { FileName = referencedFile, FrameNumber = frame - 1, Rasterize = true };

               try
               {
                  return dicomSourceProxy.Load(query).Image;
               }
               catch
               {
                  //ignored
               }
            }
         }

         return null;
      }     

        private void ApplyProcessingAction(string userData, RasterImage image, Dictionary<string, Action<RasterImage, string[]>> actionsList)
        {
            if (userData != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                ImageProcessingFunction[] functions = serializer.Deserialize<ImageProcessingFunction[]>(userData);

                if (functions != null && functions.Length > 0)
                {
                    foreach (ImageProcessingFunction function in functions)
                    {
                        if (actionsList.ContainsKey(function.Name))
                        {
                            string[] parameters = function.Parameters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                            actionsList[function.Name](image, parameters);
                        }
                    }
                }
            }
        }

        public int[] GetMinMaxValues(string sopInstanceUID, int frame)
        {
            RasterImage image = GetImage(sopInstanceUID, frame, 0, 0);
            MinMaxValuesCommand cmd = new MinMaxValuesCommand();
            cmd.Run(image);
            return new int[] { cmd.MinimumValue, cmd.MaximumValue };
        }

        public List<StackItem> GetSeriesStacks(string seriesInstanceUID)
        {
            ObjectUID uid = new ObjectUID() { SeriesInstanceUID = seriesInstanceUID };
            DataTable instanceTable = GetDicomInstanceTable(uid, true);
            List<DicomSortImageData> data = new List<DicomSortImageData>();
            List<StackItem> stacks = new List<StackItem>();

            MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(DataAccess, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, true);

            List<DicomSortImageData> seperateData = new List<DicomSortImageData>();

            foreach (DataRow instanceRow in instanceTable.Rows)
            {
                DicomSortImageDataEx imageData = (DicomSortImageDataEx)AddInsUtils.GetImageData(instanceRow);

                if (imageData != null)
                {
                   // if the number of frames is greater than one, that means this should be a separate stack and should have it's own cell.
                   if (imageData.NumberOfFrames > 1)
                      seperateData.Add(imageData);
                   else
                      data.Add(imageData);
                }
            }

            if (data.Count > 0)
            {
               var seriesManager = new DicomSortSeriesManager();

               seriesManager.Sort(data);

                // if the number of frames is greater than one, that means this should be a separate stack and should have it's own cell.
                foreach (DicomSortSeriesStack stack in seriesManager.Stacks)
                {
                    StackItem si = new StackItem();

                    si.SequenceName = stack.SequenceName;
                    si.SopInstanceUIDs = new List<string>();
                    foreach (var item in stack.Items)
                    {
                        si.SopInstanceUIDs.Add(item.Data.ToString());
                    }
                    stacks.Add(si);
                }


                bool stackSingleFrames = OptionsDataAccess.Get<bool>("StackSingleFrames", true);
                if (!stackSingleFrames)
                {
                    foreach (DicomSortSeriesStack stack in seriesManager.Localizers)
                    {
                        StackItem si = new StackItem();

                        si.SequenceName = stack.SequenceName;
                        si.SopInstanceUIDs = new List<string>();
                        foreach (var item in stack.Items)
                        {
                            si.SopInstanceUIDs.Add(item.Data.ToString());
                        }
                        stacks.Add(si);
                    }
                }
                // this is in case the series contains both stacks and localizers.
                if (seriesManager.Stacks.Count > 0)
                {
                    foreach (DicomSortSeriesStack stack in seriesManager.Localizers)
                    {
                        StackItem si = new StackItem();

                        si.SequenceName = stack.SequenceName;
                        si.SopInstanceUIDs = new List<string>();
                        foreach (var item in stack.Items)
                        {
                            si.SopInstanceUIDs.Add(item.Data.ToString());
                        }
                        stacks.Add(si);
                    }
                }
            }

            foreach (DicomSortImageData multiFrameData in seperateData)
            {
                StackItem si = new StackItem();

                si.SequenceName = multiFrameData.SequenceName;
                si.SopInstanceUIDs = new List<string>();
                si.SopInstanceUIDs.Add(multiFrameData.Data.ToString());

                stacks.Add(si);
            }


            return stacks;
        }

        private string ParseFunctionName(string functionMetaData)
        {
            string output;
            int cutIndex = functionMetaData.IndexOf(',');
            if (cutIndex == -1)
                return "";
            output = functionMetaData.Substring(0, cutIndex);
            return output;
        }


        private string ParseParameter(string functionMetaData, string parameterName)
        {
            string output;
            int parameterIndex = functionMetaData.IndexOf(parameterName);
            if (parameterIndex == -1)
                return "0";
            int startIndex = functionMetaData.IndexOf(':', parameterIndex) + 1;
            int endIndex = functionMetaData.IndexOf(',', parameterIndex);
            if (endIndex == -1)
                endIndex = functionMetaData.Length;

            output = functionMetaData.Substring(startIndex, endIndex - startIndex);
            return output;
        }


        private void ApplyContrastBrightnessIntensity(RasterImage image, string functionMetaData)
        {
            int brightness = Int32.Parse(ParseParameter(functionMetaData, "brightness"));
            int contrast = Int32.Parse(ParseParameter(functionMetaData, "contrast"));
            int intensity = Int32.Parse(ParseParameter(functionMetaData, "intensity"));


            ContrastBrightnessIntensityCommand cmd = new ContrastBrightnessIntensityCommand();
            cmd.Brightness = brightness;
            cmd.Contrast = contrast;
            cmd.Run(image);
        }


        private void ApplyChangeHueSaturationIntensity(RasterImage image, string functionMetaData)
        {
            int hue = Int32.Parse(ParseParameter(functionMetaData, "hue"));
            int saturation = Int32.Parse(ParseParameter(functionMetaData, "saturation"));
            int intensity = Int32.Parse(ParseParameter(functionMetaData, "intensity"));

            ChangeHueSaturationIntensityCommand cmd = new ChangeHueSaturationIntensityCommand();

            cmd.Hue = hue;
            cmd.Saturation = saturation;
            cmd.Intensity = intensity;
            cmd.Run(image);
        }


        private void ApplyStretchHistogram(RasterImage image, string functionMetaData)
        {
            int low = Int32.Parse(ParseParameter(functionMetaData, "low"));
            int high = Int32.Parse(ParseParameter(functionMetaData, "high"));

            ColorLevelCommand cmd = new ColorLevelCommand(ColorLevelCommandFlags.Master);
            cmd.Master.MinimumInput = low;
            cmd.Master.MaximumInput = high;
            cmd.Run(image);
        }


        private void ParseFunction(RasterImage image, string functionMetaData)
        {
            string fn = ParseFunctionName(functionMetaData);

            switch (fn)
            {
                case "ContrastBrightnessIntensity":
                    ApplyContrastBrightnessIntensity(image, functionMetaData);
                    break;

                case "ChangeHueSaturationIntensity":
                    ApplyChangeHueSaturationIntensity(image, functionMetaData);
                    break;

                case "StretchHistogram":
                    ApplyStretchHistogram(image, functionMetaData);
                    break;


            }
        }

        List<UserFunction> GetUserFunctions(string userData)
        {
            List<UserFunction> functionList = new List<UserFunction>();
            string[] functions;
            int index = 0;
            int length = 0;

            if (userData == null || userData.Trim() == string.Empty)
                return functionList;

            functions = userData.Split(';');
            length = functions.Length;

            for (index = 0; index < length; index++)
            {
                UserFunction function = new UserFunction();

                function.Name = ParseFunctionName(functions[index]);
                function.Metadata = functions[index].Replace(function.Name + ",", string.Empty);
                functionList.Add(function);
            }

            return functionList;
        }

        private void ApplyImageProcessing(RasterImage image, string userData)
        {
            if (userData == null)
                return;

            if (userData.Trim() == "")
                return;

            string[] functions = userData.Split(';');
            int index = 0;
            int length = functions.Length;
            for (index = 0; index < length; index++)
            {
                ParseFunction(image, functions[index]);
            }
        }

        private void ProcessSpecialFunction(RasterImage image, UserFunction function)
        {
            string[] functions = function.Metadata.Split('=');
            Dictionary<string, string[]> functionParams = new Dictionary<string, string[]>();

            for (int i = 0; i < functions.Length; i++)
            {
                string[] data = functions[i].Split(':');

                if (data.Length > 1)
                {
                    string key = data[0].Replace(",", string.Empty);

                    functionParams[key] = data[1].Split(',');
                }
            }

                foreach (string key in functionParams.Keys)
                {
                    if (_ProcessingActions.ContainsKey(key))
                        _ProcessingActions[key](image, functionParams[key]);
            }
        }

        static byte[] SerializeAutoScale(double autoScaleIntercept, double autoScaleSlope, RasterImage image)
        {
            double minValue = 0;
            double maxValue = 0;

            //get min/max
            {
                MinMaxValuesCommand minmax = new MinMaxValuesCommand();

                if (image.IsGray)
                {
                    if (image.BitsPerPixel == 32)
                    {
                        minValue = 0;
                        maxValue = 0xffffffff;
                    }
                    else
                    {
                        minmax.Run(image);
                        minValue = minmax.MinimumValue;
                        maxValue = minmax.MaximumValue;
                    }
                }
            }

            string doubleString = '!' + Math.Round(autoScaleIntercept, 6).ToString() + ',' + Math.Round(autoScaleSlope, 6).ToString() + ',' + (image.Signed ? "1" : "0") + ',' + minValue.ToString() + ',' + maxValue.ToString() + '!';

            int length = doubleString.Length;
            byte[] output = new byte[length];
            char myChar;

            int index;
            for (index = 0; index < length; index++)
            {
                myChar = doubleString[index];
                if (myChar == '.')
                    output[index] = 11;
                else if (myChar == '!')
                    output[index] = 12;
                else if (myChar == ',')
                    output[index] = 13;
                else if (myChar == '-')
                    output[index] = 14;
                else
                    output[index] = (byte)Int32.Parse(myChar.ToString());
            }

            return output;
        }

        public Stream GetMPRImage(string id, int mprType, int index)
        {

           MemoryStream imageStream = new MemoryStream();

           RasterImage image = Medical3DClient.GetMPRImage(id, (CellMPRType)mprType, index);
           if (image == null)
              return null;


           RasterCodecs codecs = new RasterCodecs();

           byte[] output = new byte[0];
           GetImageBufferAsPNG(image, output, imageStream);

           image.Dispose();

           return imageStream;
        }




        public Stream GetImageTile(string sopInstanceUID, int frameNumber, LeadRect tile, int xResolution, int yResolution, Boolean wldata, string userData, out string mime)
        {
           mime = SupportedMimeTypes.PNG;

           //GetReferencedFile already handles external storage
           var referencedFile = GetReferencedFile(new ObjectUID() { SOPInstanceUID = sopInstanceUID});

           if (!string.IsNullOrEmpty(referencedFile))
           {
              using (var dicomSourceProxy = new DicomSourceProxy(DataCache))
              {
                 var query = new ViewImageQuery() { FileName = referencedFile, FrameNumber = frameNumber + 1, Tile = tile, Resolution = LeadSize.Create(xResolution, yResolution) };

                 //processing?
                 {
                    var specialFunctions = GetUserFunctions(userData);
                    var specialFunction = (from u in specialFunctions
                                           where u.Name == "Perio" || u.Name == "Dentin" || u.Name == "Endo" || u.Name == "UnsharpMask"
                                           select u).FirstOrDefault();

                    if (specialFunction != null)
                    {
                       query.PostLoadAction = (image) => { ProcessSpecialFunction(image, specialFunction); };
                       query.PostLoadActionName = specialFunction.Name;//may add parameters here so to cache different ones
                        query.PostLoadActionName += specialFunction.Metadata;
                    }
                 }

                 try
                 {
                    query.ApplyLUTs = false;
                    var result = dicomSourceProxy.Load(query);
                    {
                       if (result.Raw != null)
                       {                          
                          mime = result.RawMimeType;
                          return result.Raw;//return same stream, no dispose off of the result
                       }

                       var output = new byte[0];
                       if (null != result.AutoScaleData && !result.AutoScaleData.IsEmpty)
                       {
                          output = SerializeAutoScale(result.AutoScaleData.AutoScaleIntercept, result.AutoScaleData.AutoScaleSlope, result.Image);
                       }

                       var imageStream = new MemoryStream();

                       if (!wldata)
                       {
                          ApplyImageProcessing(result.Image, userData);

                          using (RasterCodecs codecs = new RasterCodecs())
                          {
                             codecs.Options.Jpeg.Save.QualityFactor = 2;
                             codecs.Save(result.Image, imageStream, RasterImageFormat.Jpeg, 0);

                             imageStream.Position = 0;
                          }
                       }
                       else
                       {
                            GetImageBufferAsPNG(result.Image, output, imageStream);
                       }
                       
                       result.Dispose();//done with
                       return imageStream;
                    }
                 }
                 catch
                 {
                    //ignored
                 }
              }
           }

           return new MemoryStream();
        }

      static private DateTime CachedPathsTimeout = DateTime.Now;
      static private TimeSpan CachedPathsTimeoutSpan = TimeSpan.FromMinutes(1);
      static private ConcurrentDictionary<string, Tuple<string, DateTime>> CachedPaths = new ConcurrentDictionary<string, Tuple<string, DateTime>>();
      
      private string GetReferencedFile(ObjectUID uid)
      {
         var now = DateTime.Now;

         if (now - CachedPathsTimeout > CachedPathsTimeoutSpan)
         {
            CachedPaths.Clear();
            CachedPathsTimeout = now; 
         }

         var key = uid.StudyInstanceUID + uid.SeriesInstanceUID + uid.SOPInstanceUID;

         if (!string.IsNullOrEmpty(uid.SOPInstanceUID))
         {
            Tuple<string, DateTime> pathinfo = null;
            if (CachedPaths.TryGetValue(key, out pathinfo))
            {
               //only queries done within 5 seconds from last query
               if (now - pathinfo.Item2 < TimeSpan.FromSeconds(5))
               {
                  CachedPaths.TryAdd(key, new Tuple<string, DateTime>(pathinfo.Item1, now));
                  return pathinfo.Item1;
               }
            }
         }

         DataTable instanceTable = GetDicomInstanceTable(uid, false);

            foreach (DataRow instanceRow in instanceTable.Rows)
            {
                var referencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(instanceRow);

                if (string.IsNullOrEmpty(referencedFile))//external storage?
                {
                    MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(DataAccess, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, true);
                    using (var ds = dsLoadCmd.GetDicomDataSet(instanceRow, out referencedFile))
                    {
                    }
                }

                if (!string.IsNullOrEmpty(uid.SOPInstanceUID))
                {
                   CachedPaths.TryAdd(key, new Tuple<string, DateTime>(referencedFile, now));
                }
                return referencedFile;
            }

            return null;
        }
       
        public string GetDicomJSON(ObjectUID uid)
        {
           var referencedFile = GetReferencedFile(new ObjectUID() { SOPInstanceUID = uid.SOPInstanceUID });

            if (!string.IsNullOrEmpty(referencedFile))
            {
               using (var dicomSourceProxy = new DicomSourceProxy(DataCache))
               {
                  var query = new ViewImageQuery() { FileName = referencedFile, Meta = "json" };

                  try
                  {
                     using (var result = dicomSourceProxy.LoadMeta(query))
                     {
                        return (string)result.Meta;
                     }
                  }
                  catch
                  {
                  }
               }
         }
         return string.Empty;
      }


        public string GetDicomJSON(string referencedFile)
        {
           if (!string.IsNullOrEmpty(referencedFile))
           {
              using (var dicomSourceProxy = new DicomSourceProxy(DataCache))
              {
                 var query = new ViewImageQuery() { FileName = referencedFile, Meta = "json" };

                 try
                 {
                    using (var result = dicomSourceProxy.LoadMeta(query))
                    {
                       return (string)result.Meta;
                    }
                 }
                 catch
                 {
                 }
              }
            }
            return string.Empty;
        }

        private static List<Leadtools.Dicom.Common.Medical.SortingOperation> GetSortingOperationSequence(DisplaySetEx displaySet)
        {
           List<Leadtools.Dicom.Common.Medical.SortingOperation> sortingOperationSequence = new List<SortingOperation>();

           if (displaySet.SortingOperationsSequence != null)
           {
              foreach (Dicom.Common.DataTypes.SortingOperation sortingOperation in displaySet.SortingOperationsSequence)
              {
                 Leadtools.Dicom.Common.Medical.SortingOperation medicalViewerSortingOperation =
                    new Leadtools.Dicom.Common.Medical.SortingOperation();

                 medicalViewerSortingOperation.SortByCategory = SortType.None;
                 if (sortingOperation.SortByCategory.HasValue)
                 {
                    switch (sortingOperation.SortByCategory.Value)
                    {
                       case SortByCategory.AlongAxis:
                          medicalViewerSortingOperation.SortByCategory = SortType.ByAxis;
                          break;

                       case SortByCategory.ByAcquireTime:
                          medicalViewerSortingOperation.SortByCategory = SortType.ByAcquisitionTime;
                          break;
                    }
                 }

                 medicalViewerSortingOperation.Order = SortOrder.Ascending;
                 if (sortingOperation.SortingDirection.HasValue)
                 {
                    switch (sortingOperation.SortingDirection.Value)
                    {
                       case SortingDirection.Increasing:
                          medicalViewerSortingOperation.Order = SortOrder.Ascending;
                          break;

                       case SortingDirection.Decreasing:
                          medicalViewerSortingOperation.Order = SortOrder.Descending;
                          break;
                    }
                 }

                 medicalViewerSortingOperation.SelectorAttribute = 0;
                 if (sortingOperation.SelectorAttribute.HasValue)
                 {
                    medicalViewerSortingOperation.SelectorAttribute = sortingOperation.SelectorAttribute.Value;
                 }

                 sortingOperationSequence.Add(medicalViewerSortingOperation);
              }
           }

           return sortingOperationSequence;
        }

        public WCFHangingProtocol GetHangingProtocol(string userName, string sopInstanceUID, string userData)
        {
            HangingProtocolDataset.HangingProtocolRow instanceRow = GetHangingProtocolInstanceRow(sopInstanceUID) as HangingProtocolDataset.HangingProtocolRow;
            HangingProtocolEx protocol = LoadHangingProtocol(instanceRow);
            WCFHangingProtocol wcfProtocol = new WCFHangingProtocol();

            if (protocol != null)
            {
                foreach (ImageSet set in protocol.ImageSetsSequence)
                {
                    foreach (ImageSetSelector selector in set.ImageSetSelectorSequence)
                    {
                        selector.SelectorValue = GetSelectorValue(selector);
                    }
                }

                wcfProtocol.DisplaySets = new List<WCFDisplaySet>();
                foreach(DisplaySetEx displaySet in protocol.DisplaySetsSequence)
                {
                    WCFDisplaySet wcfDisplaySet = new WCFDisplaySet();

                    wcfDisplaySet.Boxes = new List<DataContracts.ImageBox>();
                    displaySet.CopyAllTo<WCFDisplaySet>(wcfDisplaySet);
                    foreach(HPWCFImageBox box in displaySet.ImageBoxesSequence)
                    {
                        DataContracts.ImageBox imageBox = new DataContracts.ImageBox();

                        if (box.DisplayEnvironmentSpatialPosition != null && box.DisplayEnvironmentSpatialPosition.Count == 4)
                        {
                            imageBox.Position.leftTop = new LeadPointD(box.DisplayEnvironmentSpatialPosition[0], 1 - box.DisplayEnvironmentSpatialPosition[1]);
                            imageBox.Position.rightBottom = new LeadPointD(box.DisplayEnvironmentSpatialPosition[2], 1 - box.DisplayEnvironmentSpatialPosition[3]);
                            imageBox.ImageBoxTileHorizontalDimension = box.ImageBoxTileHorizontalDimension;
                            imageBox.ImageBoxTileVerticalDimension = box.ImageBoxTileVerticalDimension;


                            if (box.ImageBoxLayoutType.HasValue)
                                imageBox.ImageBoxLayoutType = box.ImageBoxLayoutType.Value;

                            if (box.ImageBoxNumber.HasValue)
                                imageBox.ImageBoxNumber = box.ImageBoxNumber.Value;

                            if (box.PreferredPlaybackSequencing.HasValue)
                               imageBox.PreferredPlaybackSequencing = box.PreferredPlaybackSequencing.Value;

                            if (box.RecommendedDisplayFrameRate.HasValue)
                               imageBox.RecommendedDisplayFrameRate = box.RecommendedDisplayFrameRate.Value;

                            if (!string.IsNullOrEmpty(box.ImageDisplayFormat))
                            {
                                string data = box.ImageDisplayFormat.Replace(@"STANDARD\", "");
                                string[] info = data.Split(',');

                                if (info.Count() >= 2)
                                {
                                    imageBox.ColumnPosition = Convert.ToInt32(info[0]);
                                    imageBox.RowPosition = Convert.ToInt32(info[1]);                                    
                                }

                                if(box.Position!=null && box.Position.Count >= 2)
                                {
                                    imageBox.NumberOfRows = Convert.ToInt32(box.Position[0]);
                                    imageBox.NumberOfColumns = Convert.ToInt32(box.Position[1]);
                                }
                            }

                            imageBox.ImageBoxScrollDirection = box.ImageBoxScrollDirection;
                            imageBox.ImageBoxSmallScrollType = box.ImageBoxSmallScrollType;
                            imageBox.ImageBoxSmallScrollAmount = box.ImageBoxSmallScrollAmount;
                            imageBox.ImageBoxLargeScrollType = box.ImageBoxLargeScrollType;
                            imageBox.ImageBoxLargeScrollAmount = box.ImageBoxLargeScrollAmount;

                            wcfDisplaySet.Boxes.Add(imageBox);
                        }
                    }

                    wcfProtocol.DisplaySets.Add(wcfDisplaySet);
                }

                protocol.CopyAllTo<WCFHangingProtocol>(wcfProtocol);
                if (!string.IsNullOrEmpty(protocol.ImageDisplayFormat))
                {
                    string data = protocol.ImageDisplayFormat.Replace(@"STANDARD\", "");
                    string[] info = data.Split(',');

                    if (info.Count() >= 2)
                    {
                        wcfProtocol.Columns = Convert.ToInt32(info[0]);
                        wcfProtocol.Rows = Convert.ToInt32(info[1]);
                    }
                }
            }

            return wcfProtocol;
        }

        public int ? FindParentDisplaySetNumber(HangingProtocolEx hp, DisplaySetEx child)
        {
           if (!child.DisplaySetNumber.HasValue)
              return null;

           int childDisplaySetNumber = child.DisplaySetNumber.Value;

           foreach (SynchronizedScrolling s in hp.SynchronizedScrollingSequence)
           {
              if (s.DisplaySetScrollingGroup.IndexOf(childDisplaySetNumber) != -1)
              {
                 // The 0th item in the group is the parent of the MPR (the original, non-generated stack)
                 return s.DisplaySetScrollingGroup[0];
              }
           }

           return null;
        }

        private static List<DicomDataSetItem>  SortDefault(List<DicomDataSetItem> dicomDataSetList, DataSet result)
        {
           List<DicomSortImageData> imageDataList = new List<DicomSortImageData>();
           // List<StackItem> stacks = new List<StackItem>();
           var seriesManager = new DicomSortSeriesManager();
           CompositeInstanceDataSet dataset = result as CompositeInstanceDataSet;
           if (dataset != null)
           {
              foreach (DicomDataSetItem item in dicomDataSetList)
              {

                 string sopInstanceUid = item.UserData as string;
                 CompositeInstanceDataSet.InstanceRow instanceRow =
                    dataset.Instance.FindBySOPInstanceUID(sopInstanceUid);

                 DicomSortImageData imageData = AddInsUtils.GetImageData(instanceRow);
                 if (imageData != null)
                 {
                    imageDataList.Add(imageData);
                 }
              }

              seriesManager.Sort(imageDataList);

              List<DicomSortImageData> DicomSortImageDataList = null;

              if (seriesManager.Stacks != null && seriesManager.Stacks.Count > 0)
              {
                 DicomSortImageDataList = seriesManager.Stacks[0].Items;
              }
              else if (seriesManager.Localizers != null && seriesManager.Localizers.Count > 0)
              {
                 int length = seriesManager.Localizers.Count;

                 DicomSortImageDataList = new List<DicomSortImageData>();
                 for (int index=  0; index < length; index++)
                 {
                    DicomSortImageDataList.Add(seriesManager.Localizers[index].Items[0]);
                 }
              }
              if (DicomSortImageDataList != null)
              {
                 List<DicomDataSetItem> copiedList = new List<DicomDataSetItem>();

                 foreach (DicomSortImageData DicomSortImageData in DicomSortImageDataList)
                 {
                    string sopInstanceUid = DicomSortImageData.Data as string;
                    DicomDataSetItem dicomDataSetItem =
                       dicomDataSetList.Find(item => (string)item.UserData == sopInstanceUid);
                    if (dicomDataSetItem != null)
                    {
                       copiedList.Add(dicomDataSetItem);
                    }
                 }

                 // Sanity Check
                 if (copiedList.Count == dicomDataSetList.Count)
                 {
                    dicomDataSetList = copiedList;
                 }
              }
           }
           return dicomDataSetList;
        }

#if FOR_DOTNET4
        public List<DisplaySetView> GetHangingProtocolInstances(string userName, string hangingProtocolSOP, string patientID, string studyInstanceUID, string studyDateMostRecent, string userData)
        {

           // MyStopWatch.Log("Begin GetHangingProtocolInstances");
            HangingProtocolDataset.HangingProtocolRow row = GetHangingProtocolInstanceRow(hangingProtocolSOP) as HangingProtocolDataset.HangingProtocolRow;
            List<DisplaySetView> views = new List<DisplaySetView>();

            if (row != null)
            {
                HangingProtocolEx protocol = LoadHangingProtocol(row);                
                DataSet result = FindHangingProtocolStudies(protocol, patientID, studyDateMostRecent, userName);
                
                if(result.Tables[DataTableHelper.SeriesTableName].Rows.Count > 0)
                {
                    var seriesInstances = from s in result.Tables[DataTableHelper.SeriesTableName].AsEnumerable()
                                          join i in result.Tables[DataTableHelper.InstanceTableName].AsEnumerable() on s.Field<string>("SeriesInstanceUID") equals i.Field<string>("SeriesInstanceUID") into si
                                          from r in si.DefaultIfEmpty()
                                          orderby s["SeriesDate"]!=DBNull.Value?s.Field<DateTime>("SeriesDate"):DateTime.MinValue
                                          group r by r.Field<string>("SeriesInstanceUID") into g                                             
                                          select new
                                          {
                                              seriesInstanceUID = g.Key,                                              
                                              instances = from i in g
                                                          select new {
                                                              sopInstanceUID = i.Field<string>("SOPInstanceUID"),
                                                              referencedFile =i.Field<string>("ReferencedFile")
                                                          }
                                          };

                   //{
                   //     // Dump contents of query
                   //     foreach (var series in seriesInstances)
                   //     {
                   //        Console.WriteLine("seriesInstanceUID: " + series.seriesInstanceUID);
                   //        foreach (var instance in series.instances)
                   //        {
                   //           Console.WriteLine("\t" + instance.sopInstanceUID);
                   //           Console.WriteLine("\t" + instance.referencedFile);
                   //        }
                   //     }
                   //   Console.WriteLine("****************");
                   //}

                   var studyDatesSorted = from st in result.Tables[DataTableHelper.StudyTableName].AsEnumerable()
                                           join sr in result.Tables[DataTableHelper.SeriesTableName].AsEnumerable() on st.Field<string>("StudyInstanceUID") equals sr.Field<string>("StudyInstanceUID") into si
                                           // join i in Instances on sr.SeriesInstanceUID equals i.SeriesInstanceUID into si

                                           from r in si.DefaultIfEmpty()

                                           // orderby st.Field<string>("StudyDate") ascending
                                           // orderby sr.SeriesDate

                                           group r by st.Field<DateTime>("StudyDate") into MyStudyDateGroups
                                           orderby MyStudyDateGroups.Key descending

                                           select new
                                           {
                                              StudyDate = MyStudyDateGroups.Key,
                                              SeriesInstanceUIDs = from i in MyStudyDateGroups
                                                                   select new
                                                                   {
                                                                      seriesInstanceUID = i.Field<string>("SeriesInstanceUID")
                                                                   }
                                           };

                   StudyDateGroup studyDateGroup = new StudyDateGroup();
                   foreach(var a in studyDatesSorted)
                   {
                      StudyDateItem studyDateItem = new StudyDateItem { StudyDate = a.StudyDate };

                      foreach (var s in a.SeriesInstanceUIDs)
                      {
                         SeriesItem seriesItem = new SeriesItem(s.seriesInstanceUID);
                         studyDateItem.SeriesItemDictionary.Add(s.seriesInstanceUID, seriesItem);
                      }
                      studyDateGroup.StudyDateItems.Add(studyDateItem);
                   }


                   int notUsedSeriesCount = 0;
                   int notUsedInstanceCount = 0;
                   foreach (var series in seriesInstances)
                   {
                      notUsedSeriesCount++;
                      SeriesItem seriesItem = studyDateGroup.FindSeriesItem(series.seriesInstanceUID);
                      if (seriesItem != null)
                      {
                         foreach (var instance in series.instances)
                         {
                            notUsedInstanceCount++;
                            if (instance != null)
                            {
                               string jsonData0 = GetDicomJSON(instance.referencedFile);
                               JavaScriptSerializer serializer = new JavaScriptSerializer();
                               dynamic instanceItemMetadata = serializer.Deserialize<object>(jsonData0);

                               InstanceItem instanceItem = new InstanceItem(instance.sopInstanceUID,
                                                                            instanceItemMetadata);
                               seriesItem.InstanceItemList.Add(instanceItem);
                            }
                         }
                      }
                   }


                   // Dictionary<DateTime, List<string>> studyDatesSortedDictionary = studyDatesSortedList.ToDictionary();
                   //var studyDateLookup = studyDatesSorted.ToLookup();


                    foreach (DisplaySetEx displaySet in protocol.DisplaySetsSequence)
                    {

                       int? parentDisplaySetNumber = null;
                       InitialViewDirection ? reformattingOperationView = null; //InitialViewDirection.Sagittal;
                       
                       // If ReformattingOperationType == "MPR", then no series is assigned to this displayset.  These will generated in the client
                       //if (displaySet.ReformattingOperationType != null)
                       //{
                       //   break;
                       //}

                       List<Leadtools.Dicom.Common.Medical.SortingOperation> sortingOperationSequence = GetSortingOperationSequence(displaySet);
                        Tuple<List<ImageSetSelector>, TimeBasedImageSet> selection = GetImageSet(protocol, displaySet.ImageSetNumber.Value);

                        if (selection != null)
                        {
                           List<SeriesData> matchedSeries = new List<SeriesData>();
                           // Dictionary<SeriesData, dynamic> jsonData = new Dictionary<SeriesData, dynamic>();

                           foreach (var series in seriesInstances)
                           {
                              bool seriesAdded = false;
                              int instanceCount = 0;
                              SeriesData data = null;
                              List<DicomDataSetItem> dicomDataSetList = new List<DicomDataSetItem>();

                              // MyStopWatch.Log("Building SOPInstanceUID list");

                              // Get series date for the series
                              dynamic seriesItem = null;
                              {
                                 var instance = series.instances.FirstOrDefault();
                                 if (instance != null)
                                 {
                                    string jsonData0 = GetDicomJSON(instance.referencedFile);
                                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                                    seriesItem = serializer.Deserialize<object>(jsonData0);
                                 }
                              }

                              // Here we need to create a new copy of the studyDatesSortedList that removes the studyDates that don't agree with the Image Set Selector items
                              studyDateGroup.Prune(selection.Item1);

                              if (IsValidTimeBasedSeries(seriesItem, selection.Item2, studyDateGroup))
                              {
                                 foreach (var instance in series.instances)
                                 {
                                    instanceCount++;
                                    string json = GetDicomJSON(instance.referencedFile);
                                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                                    dynamic item = serializer.Deserialize<object>(json);

                                    if (item != null)
                                    {
                                       if (IsValidSeries(item, selection.Item1))
                                       {
                                          if (data == null)
                                          {
                                             data = GetSeries(series.seriesInstanceUID);
                                          }

                                          if ((displaySet.FilterOperationsSequence == null) &&
                                              (sortingOperationSequence.Count == 0))
                                          {
                                             // jsonData[data] = item;
                                             matchedSeries.Add(data);
                                             break;
                                          }

                                          // If ReformattingOperationType == "MPR", then no series is assigned to this displayset.  These will generated in the client
                                          if (displaySet.ReformattingOperationType != null)
                                          {
                                             parentDisplaySetNumber =
                                                FindParentDisplaySetNumber(protocol, displaySet);
                                             if (parentDisplaySetNumber.HasValue)
                                             {
                                                reformattingOperationView =
                                                   displaySet.ReformattingOperationInitialViewDirection;
                                                //InitialViewDirection.Sagittal; 
                                             }
                                             matchedSeries.Add(data);
                                             break;
                                          }

                                             // Two cases get to here:
                                          // 1. there is a filter operation
                                          // 2. there is a sortingOperationSequence
                                          else
                                          {

                                             // To include a series, at least one instance in series must pass the FilterOperation
                                             // IsValidSeries() --true  then break out of loop
                                             // IsValidSeries() --false must continue checking until find true, or all instances are false
                                             bool isValidSeries = IsValidSeries(item,
                                                                                displaySet.FilterOperationsSequence);
                                             if (isValidSeries)
                                             {
                                                //DicomDataSet ds = new DicomDataSet();

                                                //using (MemoryStream ms = json.GenerateStreamFromString())
                                                //{
                                                //   ds.LoadJson(ms, DicomDataSetLoadJsonFlags.None);
                                                //}

                                                DicomDataSetJson dicomDataSetJson = new DicomDataSetJson(item);
                                                string sopInstanceUid = GetDicomTagValue(item, DicomTag.SOPInstanceUID);

                                                // MyStopWatch.Log("InstanceCount: ", instanceCount);

                                                DicomDataSetItem dicomDataSetItem =
                                                   new DicomDataSetItem(dicomDataSetJson,
                                                                        sopInstanceUid);
                                                dicomDataSetList.Add(dicomDataSetItem);

                                                // data.AddSopInstanceUID(instance.sopInstanceUID);

                                                if (seriesAdded == false)
                                                {
                                                   // jsonData[data] = item;
                                                   matchedSeries.Add(data);
                                                   seriesAdded = true;
                                                }
                                                ;
                                                // break;
                                             }
                                          }
                                       }
                                    }
                                 }
                              } // IsValidTimeBasedSeries()

                              if (dicomDataSetList.Count > 0)
                              {
                                 // Add the sorted SOPInstanceUID list
                                 if (sortingOperationSequence.Count > 0)
                                 {
                                    // MyStopWatch.Log("Begin Sort...");
                                    dicomDataSetList = SortDicom.Sort(dicomDataSetList, sortingOperationSequence);
                                    // MyStopWatch.Log("End Sort");
                                 }
                                 else
                                 {
                                    // Need to do a default sort here
                                    dicomDataSetList = SortDefault(dicomDataSetList, result);
                                 }
                              }

                              foreach(DicomDataSetItem dicomDataSetItem in dicomDataSetList)
                              {
                                 string sopInstanceUid = dicomDataSetItem.UserData as string;

                                 if (data != null)
                                 {
                                    data.AddSopInstanceUID(sopInstanceUid);
                                 }

                                 DicomDataSet ds = dicomDataSetItem.UserData as DicomDataSet;
                                 if (ds != null)
                                 {
                                    ds.Dispose();
                                 }
                              }
                           }

                           if (matchedSeries.Count > 0)
                           {
                              SeriesData series = null;

                              {
                                 series = matchedSeries[0];
                              }

                              if (series != null)
                              {
                                 DisplaySetView view = new DisplaySetView();

                                 view.DisplaySetNumber = displaySet.DisplaySetNumber.Value;
                                 view.ReformattingOperationView = reformattingOperationView;
                                 view.ParentDisplaySetNumber = parentDisplaySetNumber;
                                 view.Series = series; // GetSeries(series.InstanceUID);
                                 views.Add(view);
                              }
                           }
                        }               
                    }
                }                
            }

           // MyStopWatch.Stop();
           return views;
        }
#else
       public List<DisplaySetView> GetHangingProtocolInstances(string userName, string hangingProtocolSOP, string patientID, string studyInstanceUID, string studyDateMostRecent, string userData)
        {
            HangingProtocolDataset.HangingProtocolRow row = GetHangingProtocolInstanceRow(hangingProtocolSOP) as HangingProtocolDataset.HangingProtocolRow;
            List<DisplaySetView> views = new List<DisplaySetView>();

            if (row != null)
            {
                HangingProtocolEx protocol = LoadHangingProtocol(row);                
                DataSet result = FindHangingProtocolStudies(protocol, patientID, studyDateMostRecent, userName);
                
                if(result.Tables[DataTableHelper.SeriesTableName].Rows.Count > 0)
                {
                    var seriesInstances = from s in result.Tables[DataTableHelper.SeriesTableName].AsEnumerable()
                                          join i in result.Tables[DataTableHelper.InstanceTableName].AsEnumerable() on s.Field<string>("SeriesInstanceUID") equals i.Field<string>("SeriesInstanceUID") into si
                                          from r in si.DefaultIfEmpty()
                                          orderby s["SeriesDate"]!=DBNull.Value?s.Field<DateTime>("SeriesDate"):DateTime.MinValue
                                          group r by r.Field<string>("SeriesInstanceUID") into g
                                          select new
                                          {
                                              seriesInstanceUID = g.Key,                                              
                                              instances = from i in g
                                                          select new {
                                                              sopInstanceUID = i.Field<string>("SOPInstanceUID"),
                                                              referencedFile =i.Field<string>("ReferencedFile")
                                                          }
                                          };


                    foreach (DisplaySetEx displaySet in protocol.DisplaySetsSequence)
                    {
                        Tuple<List<ImageSetSelector>, TimeBasedImageSet> selection = GetImageSet(protocol, displaySet.ImageSetNumber.Value);

                        if (selection != null)
                        {
                            List<SeriesData> matchedSeries = new List<SeriesData>();
                            Dictionary<SeriesData, object> jsonData = new Dictionary<SeriesData, object>();

                            foreach (var series in seriesInstances)
                            {
                                var instance = series.instances.FirstOrDefault();

                                if (instance != null)
                                {
                                    string json = GetDicomJSON(instance.referencedFile);
                                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                                    object item = serializer.Deserialize<object>(json);

                                    if(item!=null)
                                    {                                        
                                        if(IsValidSeries(item, selection.Item1))
                                        {
                                            SeriesData data = GetSeries(series.seriesInstanceUID);

                                            jsonData[data] = item;
                                            matchedSeries.Add(data);                                          
                                        }
                                    }
                                }
                            } 
                            
                            if(matchedSeries.Count > 0)
                            {
                                if (displaySet.FilterOperationsSequence.Count > 0)
                                {
                                    List<SeriesData> currentMatches = new List<SeriesData>();

                                    currentMatches.AddRange(matchedSeries);
                                    foreach (SeriesData series in currentMatches)
                                    {
                                        if (!IsValidSeries(jsonData[series], displaySet.FilterOperationsSequence))
                                            matchedSeries.Remove(series);
                                    }
                                }
                            }

                            if(matchedSeries.Count > 0)
                            {
                                DisplaySetView view = new DisplaySetView();

                                view.DisplaySetNumber = displaySet.DisplaySetNumber.Value;
                                view.Series = GetSeries(matchedSeries[0].InstanceUID);
                                views.Add(view);
                            }
                        }               
                    }
                }                
            }
            return views;
        }
#endif

        private DataSet FindHangingProtocolStudies(HangingProtocolEx protocol, string patientID, string studyDateMostRecent, string userName)
        {
            DataSet result = null;
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList mpPatientList = new MatchingParameterList();
            string[] roles = PermissionsDataAccess.GetUserRoles(userName);
            // bool enablePatientRestriction = OptionsDataAccess.Get<bool>("EnablePatientRestriction", false);
            Patient patient = new Patient(patientID);

            // Do not add the patient
            //mpPatientList.Add(patient);
            //matchingCollection.Add(mpPatientList);
            foreach(HangingProtocolDefinition definition in protocol.HangingProtocolDefinitionSequence)
            {
                MatchingParameterList mpList = new MatchingParameterList();
                Study study = null;
                Series series = null;

                if (!string.IsNullOrEmpty(definition.Modality))
                {
                    series = new Series();
                    series.Modality = definition.Modality;
                }

                if (!string.IsNullOrEmpty(definition.StudyDescription))
                {
                    study = new Study();
                    study.StudyDescription = definition.StudyDescription;                
                }

                if (!string.IsNullOrEmpty(studyDateMostRecent))
                {
                   if (study == null)
                   {
                      study = new Study();
                   }
                   study.StudyDate = new DateRange();
                   study.StudyDate.EndDate = DateTime.Parse(studyDateMostRecent);
                }

                if (series != null)
                    mpList.Add(series);

                if (study != null)
                    mpList.Add(study);

                if (mpList.Count > 0)
                {
                    Patient p = new Patient(patientID);

                    mpList.Add(p);
                    matchingCollection.Add(mpList);
                }
            }

            result = AuthorizedDataAccess.QueryCompositeInstances(matchingCollection, userName, roles);
            return result;
        }  
        
       private static bool IsMatchCodeSequenceItem(Dictionary<string, object> dictionaryValue, long tag, string valueToMatch)
       {
          object outValue = null;
          string tagString = tag.DicomTagToHexString();

          if (dictionaryValue.TryGetValue(tagString, out outValue))
          {
             Dictionary<string, object> newDictionary = outValue as Dictionary<string, object>;

             object[] objectArray = GetValueArray(newDictionary);
             if (objectArray != null && objectArray.Length > 0)
             {
                string s = objectArray[0] as string;
                bool match = (string.Compare(s, valueToMatch, true) == 0);

                //if (match == false)
                //{
                //   if (s == "T-D1213" || s== "T-11170")
                //   {
                //      if (valueToMatch == "T-D1213" || valueToMatch== "T-11170")
                //      {
                //         return true;
                //      }
                //   }
                //}

                return match;
             }
          }
          return false;
       }   
               
       private static bool IsSequenceMatch( Dictionary<string, object> dictionaryValue, List<Dicom.Common.DataTypes.CodeSequence> hpSequence)
       {
          // If a single match is found, then return true
          foreach (CodeSequence cs in hpSequence)
          {
             bool matchCodeValue = IsMatchCodeSequenceItem(dictionaryValue, DicomTag.CodeValue, cs.CodeValue);
             bool matchCodingSchemeDesignator = IsMatchCodeSequenceItem(dictionaryValue, DicomTag.CodingSchemeDesignator, cs.CodeSchemeDesignator);

             // According to DICOM spec, must match both (CodeValue and CodingSchemeDesignator) to be considered a match
             if (matchCodeValue && matchCodingSchemeDesignator)
             {
                return true;
             }
          }
          return false;
       }

#if FOR_DOTNET4

       private static DateTime TruncateDate(DateTime d, RelativeTimeUnits ? units)
       {
          DateTime retDate = d;

          if (units.HasValue)
          {
             switch (units.Value)
             {
                case RelativeTimeUnits.Years:
                   retDate = new DateTime(d.Year, 1, 1, 0, 0, 0);
                   break;
                case RelativeTimeUnits.Months:
                   retDate = new DateTime(d.Year, d.Month, 1, 0, 0, 0);
                   break;
                case RelativeTimeUnits.Weeks:
                   retDate = new DateTime(d.Year, d.Month, 1, 0, 0, 0);
                   break;
                case RelativeTimeUnits.Days:
                   retDate = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
                   break;
                case RelativeTimeUnits.Hours:
                   retDate = new DateTime(d.Year, d.Month, d.Day, d.Hour, 0, 0);
                   break;
                case RelativeTimeUnits.Minutes:
                   retDate = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, 0);
                   break;
                case RelativeTimeUnits.Seconds:
                   retDate = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
                   break;
             }
          }

          return retDate;
       }

       private static bool IsRelativeTimeBasedImageSetValid(DateTime studyDateToTest, TimeBasedImageSet timeBasedImageSet, StudyDateGroup studyDateGroup)
       {
          // Multiply by (-1) because must subtract the number (i.e months) from the most recent date to get the acceptable date range
          int start = (-1) * timeBasedImageSet.RelativeTime[0];
          int end = (-1) * timeBasedImageSet.RelativeTime[1];

          if (studyDateGroup.StudyDateItems.Count == 0)
          {
             return false;
          }

          studyDateToTest = TruncateDate(studyDateToTest, timeBasedImageSet.RelativeTimeUnits);

          DateTime mostRecentDate = studyDateGroup.StudyDateItems[0].StudyDate;
          mostRecentDate = TruncateDate(mostRecentDate, timeBasedImageSet.RelativeTimeUnits);

          DateTime date0 = mostRecentDate;
          DateTime date1 = mostRecentDate;

          if (timeBasedImageSet.RelativeTimeUnits.HasValue)
          {
             switch (timeBasedImageSet.RelativeTimeUnits.Value)
             {
                case RelativeTimeUnits.Years:
                   date0 = date0.AddYears(start);
                   date1 = date1.AddYears(end);
                   break;
                case RelativeTimeUnits.Months:
                   date0 =date0.AddMonths(start);
                   date1 = date1.AddMonths(end);
                   break;
                case RelativeTimeUnits.Weeks:
                   date0 = date0.AddDays(start * 7);
                   date1 = date1.AddDays(end * 7);
                   break;
                case RelativeTimeUnits.Days:
                   date0 = date0.AddDays(start);
                   date1 = date1.AddDays(end);
                   break;
                case RelativeTimeUnits.Hours:
                   date0 = date0.AddHours(start);
                   date1 = date1.AddHours(end);
                   break;
                case RelativeTimeUnits.Minutes:
                   date0 = date0.AddMinutes(start);
                   date1 = date1.AddMinutes(end);
                   break;
                case RelativeTimeUnits.Seconds:
                   date0 = date0.AddSeconds(start);
                   date1 = date1.AddSeconds(end);
                   break;
             }
          }
          return (date1 <= studyDateToTest) && (studyDateToTest <= date0);
       }

       // if 'maximum' is true, then this a max time based value ( min/max)
       //                 false, then this is a min time based value ( min/max)
       private static int AdjustAbstractPriorValue(int hpValue, int studyDatesCount, bool maximum)
       {
          // Note (studyDatesCount - 1) is the number of priors because the 0th entry the current
          int nPriorsCount = studyDatesCount - 1;

          if (hpValue <= -1)
             return nPriorsCount;

          // If a maximum value 
          if (maximum)
             return Math.Min(hpValue, nPriorsCount);

          return hpValue;
       }

       private static bool IsAbstractTimeBasedImageSetValid(DateTime studyDateToTest, TimeBasedImageSet timeBasedImageSet, StudyDateGroup studyDateGroup)
       {
          int studyDatesCount = studyDateGroup.StudyDateItems.Count;
          if (studyDatesCount == 0)
          {
             return false;
          }

          int start = AdjustAbstractPriorValue(timeBasedImageSet.AbstractPriorValue[0], studyDatesCount, false);
          int end = AdjustAbstractPriorValue(timeBasedImageSet.AbstractPriorValue[1], studyDatesCount, true);

          // These are actually illegal values for an abstractTimeBasedValue so return 'false'
          if (start == 0 || end == 0)
             return false;

          // (studyDatesCount - 1) because the 0th value is not a prior -- it is the current value
          // So there are (studyDatesCount -1) available priors
          if (start > studyDatesCount - 1)
             return false;

          // Skip the 0th entry because this is the most recent study date
          for (int i = start; i<= end; i++)
          {
             if (studyDateToTest == studyDateGroup.StudyDateItems[i].StudyDate)
             {
                return true;
             }
          }
          return false;
       }

       private bool IsValidTimeBasedSeries(dynamic studyMetadata, TimeBasedImageSet timeBasedImageSet, StudyDateGroup studyDateGroup)
       {
          bool isValid = false;

          if (timeBasedImageSet == null)
          {
             return true;
          }

          if (!timeBasedImageSet.ImageSetSelectorCategory.HasValue)
          {
             return true;
          }

          string studyDateString = GetDicomTagValue(studyMetadata, DicomTag.StudyDate);
          DateTime studyDate;
          DateTime.TryParseExact(studyDateString, @"yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out studyDate);

          string studyTimeString = GetDicomTagValue(studyMetadata, DicomTag.StudyTime);
          studyTimeString = studyTimeString + "000000";
          studyTimeString = studyTimeString.Substring(0, 6);

          DateTime studyTime; // DICOM TimeString uses 24 hour clock, so must use format string with HH which means 24 hour clock
          if (DateTime.TryParseExact(studyTimeString, @"HHmmss", CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out studyTime))
          {
             studyDate = new DateTime(studyDate.Year, studyDate.Month, studyDate.Day, studyTime.Hour, studyTime.Minute, studyTime.Second);
          }

          switch (timeBasedImageSet.ImageSetSelectorCategory.Value)
          {
             case ImageSetSelectorCategory.RelativeTime:
                isValid = IsRelativeTimeBasedImageSetValid(studyDate, timeBasedImageSet, studyDateGroup);
                break;

             case ImageSetSelectorCategory.AbstractPrior:
             default:
                isValid = IsAbstractTimeBasedImageSetValid(studyDate, timeBasedImageSet, studyDateGroup);
                break;
          }

          return isValid;
       }

       // Checks Selector values with multiplicity greater or equal to 1
       private static bool IsValidSelectorValue(ImageSetSelector selector, string stringValue)
       {
          bool valid = false;
          string[] selectorValues = selector.SelectorValue.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

          foreach (string s in selectorValues)
          {
             if (s.CompareTo(stringValue) == 0)
             {
                valid = true;
                break;
             }
          }
          return valid;
       }

       public static bool IsValidSeries(dynamic metadata, List<ImageSetSelector> selectors)
        {
            bool valid = true;

            foreach(ImageSetSelector selector in selectors)
            {
                string tag = selector.WCFSelectorAttribute.Replace(":", string.Empty);
                DicomTag dicomTag = DicomTagTable.Instance.Find(selector.SelectorAttribute);

                if (Haskey(metadata, tag))
                {
                    var item = metadata[tag];

                    if (item != null)
                    {
                        object[] values = GetValueArray(item);
                        int count = values.Count();

                        if (count > 0)
                        {
                            if (selector.SelectorValueNumber > 0 && selector.SelectorValueNumber <= count)
                            {
                               object objectValue = values[selector.SelectorValueNumber.Value - 1];
                               if (objectValue is string)
                               {
                                  string stringValue = objectValue as string;

                                  if (IsValidSelectorValue(selector, stringValue) == false)
                                  {
                                     valid = false;
                                     break;
                                  }                          
                                 
                               }
                               else if (objectValue is Dictionary<string, object>)
                               {
                                  Dictionary<string, object> dictionaryValue = objectValue as Dictionary<string, object>;
                                  if (IsSequenceMatch(dictionaryValue, selector.SelectorCodeSequenceValue) == false)
                                  {
                                     valid = false;
                                     break;
                                  }
                               }

                            }
                            else if(selector.SelectorValueNumber == 0)     // The value zero identifies any value
                            {
                               valid = false;   // now if any are true, return true
                                for (int i = 0; i < count;i++)
                                {
                                   object objectValue = values[i];
                                   if (objectValue is string)
                                   {
                                      string stringValue = objectValue as string;
                                      if (IsValidSelectorValue(selector, stringValue))
                                      {
                                         valid = true;
                                         break;
                                      }
                                   }
                                   if (objectValue is Dictionary<string, object>)
                                   {
                                         Dictionary<string, object> dictionaryValue = objectValue as Dictionary<string, object>;
                                         if (IsSequenceMatch(dictionaryValue, selector.SelectorCodeSequenceValue))
                                         {
                                            valid = true;
                                            break;
                                         }
                                   }
                                }
                            }
                            else
                            {
                                valid = false;
                                break;
                            }
                        }                       
                    }
                    else
                    {
                        if(selector.ImageSetSelectorUsageFlag == ImageSetSelectorUsage.NoMatch)
                        {
                            valid = false;
                            break;
                        }
                    }
                }
                else
                {
                    if (selector.ImageSetSelectorUsageFlag == ImageSetSelectorUsage.NoMatch)
                    {
                        valid = false;
                        break;
                    }
                }
            }            
            return valid;
        }
        private bool IsValidSeries(dynamic metadata, List<FilterOperation> operations)
       {
          if (operations == null)
             return true;

          bool valid = false;

          foreach (FilterOperation operation in operations)
          {
             ImageSetSelectorUsage imageSetSelectorUsage = ImageSetSelectorUsage.Match;
             if (operation.ImageSetSelectorUsageFlag.HasValue)
                imageSetSelectorUsage = operation.ImageSetSelectorUsageFlag.Value;

             IDictionary<string, Object> dict = GetDictionary(metadata, operation.SelectorSequencePointer, operation.SelectorSequencePointerItems);
             if (dict != null)
             {

                var item = dict;
                if (operation.SelectorAttribute.HasValue == false)
                   return false;

                string tag = operation.SelectorAttribute.Value.DicomTagToHexString();

                item = null;
                if (dict.ContainsKey(tag))
                {
                   item = dict[tag] as IDictionary<string, Object>;
                }

             if (item != null)
                {
                   object[] values = GetValueArray(item);

                   valid = CompareFilter(operation, values);
                   if (!valid)
                      break;
                }
             }
             else if (imageSetSelectorUsage == ImageSetSelectorUsage.Match)
             {
               // if (ImageSetSelectorUsage.Match) then if Tag does not exist, then it is a match 
                valid = true;
             }
          }
          return valid;
       }

        private static bool CompareOneObject(FilterByOperator filterByOperator, List<object> filterObjectList, object dsObject)
        {
           bool valid = false;

           if (filterObjectList == null || filterObjectList.Count == 0)
              return false;

           switch (filterByOperator)
           {
              case FilterByOperator.RangeInclusive:   // numeric only
              case FilterByOperator.RangeExclusive:   // numeric only
                 {
                    if (filterObjectList.Count < 2)
                       return false;

                    int value0 = AddInsUtils.CompareObjects(dsObject, filterObjectList[0]);
                    int value1 = AddInsUtils.CompareObjects(dsObject, filterObjectList[1]);

                    if (filterByOperator == FilterByOperator.RangeInclusive)
                    {
                       valid = (0 <= value0) && (value1 <= 0);
                    }
                    else
                    {
                       // FilterByOperator.RangeExclusive
                       valid = (0 < value0) && (value1 < 0);
                    }
                 }
                 break;

              case FilterByOperator.GreaterOrEqual:   // numeric only
                 {
                    int value0 = AddInsUtils.CompareObjects(dsObject, filterObjectList[0]);
                    valid = value0 >= 0;
                 }
                 break;

              case FilterByOperator.GreaterThan:      // numeric only
                 {
                    int value0 = AddInsUtils.CompareObjects(dsObject, filterObjectList[0]);
                    valid = value0 > 0;
                 }
                 break;

              case FilterByOperator.LessOrEqual:      // numeric only
                 {
                    int value0 = AddInsUtils.CompareObjects(dsObject, filterObjectList[0]);
                    valid = value0 <= 0;
                 }
                 break;

              case FilterByOperator.LessThan:         // numeric only
                 {
                    int value0 = AddInsUtils.CompareObjects(dsObject, filterObjectList[0]);
                    valid = value0 < 0;
                 }
                 break;

              case FilterByOperator.MemberOf:         // alphanumeric
                 {
                    foreach (object filterObject in filterObjectList)
                    {
                       int value0 = AddInsUtils.CompareObjects(filterObject, dsObject);
                       if (value0 == 0)
                       {
                          return true;
                       }
                    }
                    return false;
                 }
                 break;

              case FilterByOperator.NotMemberOf:      // alphanumeric
                 {
                    foreach (object filterObject in filterObjectList)
                    {
                       int value0 = AddInsUtils.CompareObjects(filterObject, dsObject);
                       if (value0 == 0)
                       {
                          return false;
                       }
                    }
                    return true;
                 }
                 break;
           }
           return valid;
        }

        private static bool CompareFilterSequence(FilterOperation operation, object[] dsValues)
        {
           // Get the last SelectorSequencePointerItem
           long lastSelectorSequencePointerItem = operation.SelectorSequencePointerItems.Last();

           long startIndex = 0;
           long endIndex = 0;

           if (lastSelectorSequencePointerItem == 0)
           {
              // Check all items
              startIndex = 0;
              endIndex = dsValues.Length;
           }
           else
           {
              if (lastSelectorSequencePointerItem <= dsValues.Length)
              {
                 //Check only one item
                 startIndex = lastSelectorSequencePointerItem - 1;
                 endIndex = lastSelectorSequencePointerItem;
              }
           }

           for (long i = startIndex; i < endIndex; i++)
           {
              object dsValue = dsValues[i];
              if (dsValue is Dictionary<string, object>)
              {
                 Dictionary<string, object> dictionaryValue = dsValue as Dictionary<string, object>;
                 if (IsSequenceMatch(dictionaryValue, operation.SelectorCodeSequenceValue))
                 {
                    return true;
                 }
              }
           }
           return false;
        }

        private static bool CompareFilter(FilterOperation operation, object[] dsValues)
        {
           // Check if sequence
           if (operation.SelectorAttributeVR == "SQ")
           {
              return CompareFilterSequence(operation, dsValues);
           }

           // If HP does not contain the FilterByOperator, add a default value
           if (operation.FilterByOperator == null)
           {
              operation.FilterByOperator = FilterByOperator.MemberOf;
           }

           // If HP does not contain the SelectorValueNumber, add a default value
           if (operation.SelectorValueNumber == null)
           {
              operation.SelectorValueNumber = 0;
           }

           object objectFilterOperationValue = GetFilterOperationValue(operation);
           List<object> objectList = new List<object>();

           bool isList = typeof(IList).IsAssignableFrom(objectFilterOperationValue.GetType());
           bool isString = objectFilterOperationValue.GetType() == typeof(string);

           if (isList)
           {
              IList objectFilterOperationList = objectFilterOperationValue as IList;
              if (objectFilterOperationList != null)
              {
                 foreach (object o in objectFilterOperationList)
                 {
                    objectList.Add(o);
                 }
              }
           }
           else if (isString)
           {
              string stringValue = objectFilterOperationValue as string;
              if (stringValue != null)
              {
                 string[] stringValues = stringValue.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                 foreach (string s in stringValues)
                 {
                    objectList.Add(s);
                 }
              }
           }
           else
           {
              objectList.Add(objectFilterOperationValue);
           }

           bool valid = false;
           int dsValuesCount = dsValues.Count();

           // Specific selector value
           if (operation.SelectorValueNumber > 0 && operation.SelectorValueNumber <= dsValuesCount)
           {
              valid = CompareOneObject(operation.FilterByOperator.Value, objectList, dsValues[operation.SelectorValueNumber.Value - 1]);
           }
           else if (operation.SelectorValueNumber == 0)
           {
              // Any selector value (SelectorValueNumber == 0)
              for (int i = 0; i < dsValuesCount; i++)
              {
                 valid = CompareOneObject(operation.FilterByOperator.Value, objectList, dsValues[i]);
                 if (valid)
                    break;
              }
           }
           else if (operation.SelectorValueNumber > 0 && operation.SelectorValueNumber > dsValuesCount)
           {
              // Example
              //  Image Type (0008:0008) is "PRIMARY\SECONDARY"
              //  Selector value: AXIAL
              //  Selctor Index: 3
              //
              //  There is no third value -- only two values (PRIMARY\SECONDARY)
              //  So result depends on SelectorUsage flag (Match/NoMatch)
              valid = (operation.ImageSetSelectorUsageFlag.HasValue &&
                       operation.ImageSetSelectorUsageFlag.Value == ImageSetSelectorUsage.Match);
               
           }
           return valid;
        }

        private static IDictionary<string, Object> GetDictionary(dynamic expando, List<long> selectorSequencePointer, List<long> selectorSequencePointerItems)
        {
           IDictionary<string, Object> dict = expando as IDictionary<string, Object>;
           if (dict == null)
           {
              return null;
           }

           int count = selectorSequencePointer.Count;

           for (int i = 0; i<count; i++)
           {
              string dicomTagString = selectorSequencePointer[i].DicomTagToHexString();
              if (dict.ContainsKey(dicomTagString))
              {
                 var item2 = dict[dicomTagString];
                 object[] values = GetValueArray(item2);
                 long indexItem = selectorSequencePointerItems[i] - 1;
                 dict = values[indexItem] as IDictionary<string, Object>;
                 if (dict == null)
                 {
                    return null;
                 }
              }
              else
              {
                 return null;
              }
           }

           return dict;
        }

        private static bool Haskey(dynamic expando, string key)
        {
            return ((IDictionary<string, Object>)expando).ContainsKey(key);
        }

        public static object[] GetValueArray(dynamic metadata)
        {
            dynamic value;

            if (Haskey(metadata, "Value"))
            {
                value = metadata["Value"];
                return value.GetType().IsArray ? value as object[] : new object[] { value };
            }
            return new object[0];
        }

        public static string GetDicomTagValue(object dicomJson, long dicomTag)
        {
           string sValue = string.Empty;
           string dicomTagString = dicomTag.DicomTagToHexString();

           // object[] values = GetValueArray(dicomJson);

           if (Haskey(dicomJson, dicomTagString))
           {
              var item2 = ((IDictionary<string, Object>)dicomJson)[dicomTagString];
              object[] values = GetValueArray(item2);
              int count = values.Count();
              if (count > 0)
              {
                 sValue = values[0] as string;
              }
           }
           return sValue;
        }


#else
        public static bool IsValidSeries(object metadata, List<ImageSetSelector> selectors)
        {
           bool valid = false;

           foreach (ImageSetSelector selector in selectors)
           {
              string tag = selector.WCFSelectorAttribute.Replace(":", string.Empty);
              DicomTag dicomTag = DicomTagTable.Instance.Find(selector.SelectorAttribute);

              if (Haskey(metadata, tag))
              {
                 var item = ((IDictionary<string, Object>)metadata)[tag];

                 if (item != null)
                 {
                    object[] values = GetValueArray(item);
                    int count = values.Count();

                    if (dicomTag != null && dicomTag.MaxVM > 1)
                    {
                       if (selector.SelectorValueNumber > 0 && selector.SelectorValueNumber <= count)
                       {
                          if (selector.SelectorValue.CompareTo(values[selector.SelectorValueNumber.Value - 1]) == 0)
                          {
                             valid = true;
                          }
                       }
                       else
                       {
                          valid = false;
                          break;
                       }
                    }
                    else if (count > 0)
                    {
                       if (selector.SelectorValue.CompareTo(values[selector.SelectorValueNumber.Value - 1]) == 0)
                       {
                          valid = true;
                       }
                       else
                       {
                          valid = false;
                          break;
                       }
                    }
                 }
                 else
                 {
                    if (selector.ImageSetSelectorUsageFlag == ImageSetSelectorUsage.NoMatch)
                    {
                       valid = false;
                       break;
                    }
                 }
              }
              else
              {
                 if (selector.ImageSetSelectorUsageFlag == ImageSetSelectorUsage.NoMatch)
                 {
                    valid = false;
                    break;
                 }
              }
           }
           return valid;
        }
        private bool IsValidSeries(object metadata, List<FilterOperation> operations)
        {
           bool valid = false;

           foreach (FilterOperation operation in operations)
           {
              string tag = operation.WCFSelectorAttribute.Replace(":", string.Empty);
              DicomTag dicomTag = DicomTagTable.Instance.Find(operation.SelectorAttribute.Value);

              if (Haskey(metadata, tag))
              {
                 var item = ((IDictionary<string, Object>)metadata)[tag];
                 object filterOperation = GetFilterOperationValue(operation);

                 if (item != null)
                 {
                    object[] values = GetValueArray(item);
                    int count = values.Count();

                    if (dicomTag != null && dicomTag.MaxVM > 1)
                    {
                       if (operation.SelectorValueNumber > 0 && operation.SelectorValueNumber <= count)
                       {
                          if (AddInsUtils.CompareObjects(filterOperation, values[operation.SelectorValueNumber.Value - 1]) == 0)
                          {
                             valid = true;
                          }
                       }
                       else
                       {
                          valid = false;
                          break;
                       }
                    }
                    else if (count > 0)
                    {
                       if (AddInsUtils.CompareObjects(filterOperation, values[operation.SelectorValueNumber.Value - 1]) == 0)
                       {
                          valid = true;
                       }
                       else
                       {
                          valid = false;
                          break;
                       }
                    }
                 }
              }
           }
           return valid;
        }

        private static bool Haskey(object expando, string key)
        {
           return ((IDictionary<string, Object>)expando).ContainsKey(key);
        }

        public static object[] GetValueArray(object metadata)
        {
           object value;

           if (Haskey(metadata, "Value"))
           {
              value = ((IDictionary<string, Object>)metadata)["Value"];
              return value.GetType().IsArray ? value as object[] : new object[] { value };
           }
           return new object[0];
        }
#endif
        private SeriesData GetSeries(string seriesInstanceUID)
        {
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();
            ICatalogEntity seriesEntity = RegisteredEntities.GetSeriesEntity(seriesInstanceUID);
            DataSet result;            

            matchingList.Add(seriesEntity);
            matchingCollection.Add(matchingList);
            result = DataAccess.QuerySeries(matchingCollection);

            if(result.Tables[DataTableHelper.SeriesTableName].Rows.Count > 0)
            {
                DataRow seriesRow = result.Tables[DataTableHelper.SeriesTableName].Rows[0];

                return GetSeriesInfo(seriesRow);
            }
            return null;
        }

        private SeriesData GetNewestSeries(string studyInstanceUID)
        {
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();
            ICatalogEntity studyEntity = RegisteredEntities.GetStudyEntity(studyInstanceUID);
            DataSet result;
            DataRow newest = null;

            matchingList.Add(studyEntity);
            matchingCollection.Add(matchingList);
            result = DataAccess.QuerySeries(matchingCollection);

            newest = (from DataRow row in result.Tables[DataTableHelper.SeriesTableName].Rows
                      orderby row["SeriesDate"] == DBNull.Value ? DateTime.MinValue : row["SeriesDate"] descending
                      select row).FirstOrDefault();

            if (newest != null)
            {                
                return GetSeriesInfo(newest);
            }

            return null;
        }

        private SeriesData GetSeriesInfo(DataRow seriesRow)
        {
            ISeriesInfo si = RegisteredDataRows.SeriesInfo;
            SeriesData seriesObject = new SeriesData();
            DataRow studyRow = si.GetStudyRow(seriesRow);
            DataRow patientRow = studyRow.GetParentRow(studyRow.Table.ParentRelations["FK_Patient_Study"]);

            seriesObject.Modality = si.GetElementValue(seriesRow, DicomTag.Modality);
            seriesObject.Number = si.GetElementValue(seriesRow, DicomTag.SeriesNumber);
            seriesObject.InstanceUID = si.GetElementValue(seriesRow, DicomTag.SeriesInstanceUID);
            seriesObject.Description = si.GetElementValue(seriesRow, DicomTag.SeriesDescription);
            seriesObject.Date = si.GetElementValue(seriesRow, DicomTag.SeriesDate);
            seriesObject.StudyInstanceUID = si.GetElementValue(seriesRow, DicomTag.StudyInstanceUID);

            seriesObject.Patient = new PatientData();
            seriesObject.Patient.ID = RegisteredDataRows.StudyInfo.GetElementValue(studyRow, DicomTag.PatientID);
            seriesObject.Patient.Name = AddInsUtils.GetPatientName(patientRow);
            seriesObject.Patient.Sex = RegisteredDataRows.PatientInfo.GetElementValue(patientRow, DicomTag.PatientSex);
            seriesObject.Patient.Comments = RegisteredDataRows.PatientInfo.GetElementValue(patientRow, DicomTag.PatientComments);
            seriesObject.Patient.BirthDate = RegisteredDataRows.PatientInfo.GetElementValue(patientRow, DicomTag.PatientBirthDate);
            seriesObject.Patient.EthnicGroup = RegisteredDataRows.PatientInfo.GetElementValue(patientRow, DicomTag.EthnicGroup);

            return seriesObject;
        }
        
        private Tuple<List<ImageSetSelector>, TimeBasedImageSet> GetImageSet(HangingProtocolEx protocol, int imageSetNumber)
        {
            Tuple<List<ImageSetSelector>, TimeBasedImageSet> selection = null;

            foreach (ImageSet set in protocol.ImageSetsSequence)
            {
                foreach (TimeBasedImageSet timeSet in set.TimeBasedImageSetsSequence)
                {
                    if (timeSet.ImageSetNumber == imageSetNumber)
                    {
                        selection = new Tuple<List<ImageSetSelector>, TimeBasedImageSet>(set.ImageSetSelectorSequence, timeSet);

                        return selection;
                    }
                }
            }

            return selection;
        }
       
        private HangingProtocolEx LoadHangingProtocol(HangingProtocolDataset.HangingProtocolRow row)
        {
            DicomDataSet ds;
            HangingProtocolEx protocol = null;
            MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(DataAccess, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, true);

            //apply some options into the DICOM DataSet
            using (ds = dsLoadCmd.GetDicomDataSet(row))
            {
                protocol = ds.Get<HangingProtocolEx>();
                if (protocol != null)
                {
                    foreach (ImageSet set in protocol.ImageSetsSequence)
                    {
                        foreach (ImageSetSelector selector in set.ImageSetSelectorSequence)
                        {
                            selector.SelectorValue = GetSelectorValue(selector);
                        }
                    }

                    foreach(DisplaySetEx displaySet in protocol.DisplaySetsSequence)
                    {
                        if (displaySet.FilterOperationsSequence == null)
                            continue;

                        foreach (FilterOperation operation in displaySet.FilterOperationsSequence)
                        {
                            operation.SelectorValue = GetConvertFilterOperationValue(operation);
                        }
                    }
                }
            }

            return protocol;
        }

        private static string GetSelectorValue(ImageSetSelector selector)
        {
            PropertyInfo property = selector.GetType().GetProperty("Selector" + selector.SelectorAttributeVR + "Value");

            if (property != null)
            {                
                object value = property.GetValue(selector, null);

                if (value != null)
                    return value.ToString();
            }
            
            return string.Empty;
        }

        private static string GetConvertFilterOperationValue(FilterOperation operation)
        {
            PropertyInfo property = operation.GetType().GetProperty("Selector" + operation.SelectorAttributeVR + "Value");

            if (property != null)
            {
                object value = property.GetValue(operation, null);

                if (value != null)
                    return value.ToString();
            }

            return string.Empty;
        }

        private static object GetFilterOperationValue(FilterOperation operation)
        {
            PropertyInfo property = operation.GetType().GetProperty("Selector" + operation.SelectorAttributeVR + "Value");

            if (property != null)
            {
                object value = property.GetValue(operation, null);

                if (value != null)
                    return value;
            }

            return null;
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="AudioWaveformGroup"></param>
        /// <returns></returns>
        private static byte[] SaveAudio(DicomWaveformGroup AudioWaveformGroup)
        {
            string strTempFile;


            strTempFile = Path.GetTempFileName();

            try
            {
                AudioWaveformGroup.SaveAudio(strTempFile);

                return File.ReadAllBytes(strTempFile);
            }
            finally
            {
                if (File.Exists(strTempFile))
                {
                    File.Delete(strTempFile);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sopInstanceUID"></param>
        /// <param name="groupIndex"></param>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        public Stream GetAudio(string sopInstanceUID, int groupIndex, string mimeType)
        {
            DataRow instanceRow = GetDicomInstanceRow(sopInstanceUID);

            MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(DataAccess, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, true);

            using (DicomDataSet ds = dsLoadCmd.GetDicomDataSet(instanceRow))
            {
                if (ds.WaveformGroupCount < 1)
                {
                    return null;
                }

                DicomWaveformGroup AudioWaveformGroup = ds.GetWaveformGroup(0);
                byte[] buf = SaveAudio(AudioWaveformGroup);
                return new MemoryStream(buf);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sopInstanceUID"></param>
        /// <returns></returns>
        public int GetAudioGroupsCount(string sopInstanceUID)
        {
            DataRow instanceRow = GetDicomInstanceRow(sopInstanceUID);

            MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(DataAccess, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, true);

            using (DicomDataSet ds = dsLoadCmd.GetDicomDataSet(instanceRow))
            {
                DicomIod iod = DicomIodTable.Instance.FindClass(ds.InformationClass);
                if (iod != null)
                {
                    return ds.WaveformGroupCount;
                }

                return 0;
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        class MyPresentationStateRelationshipModule
        {
            [Element(DicomTag.ReferencedSeriesSequence)]
            public List<MyReferencedSeriesSequence> ReferencedSeriesSequence { get; set; }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        class MyReferencedSeriesSequence
        {
            [Element(DicomTag.ReferencedImageSequence)]
            public List<ImageSopInstanceReference> ReferencedImageSequence { get; set; }

            [Element(DicomTag.SeriesInstanceUID)]
            public string SeriesInstanceUID { get; set; }
        }

        public Stream GetPresentationAnnotations(string sopInstanceUID, string userData)
        {
            DataRow instanceRow = GetDicomInstanceRow(sopInstanceUID);

            MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(DataAccess, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, true);


            using (DicomDataSet ds = dsLoadCmd.GetDicomDataSet(instanceRow))
            {
                AnnCodecs codec = new AnnCodecs();
                MemoryStream ms = new MemoryStream();


                // The Medical Viewer defaults dpi to 150
                DicomAnnotationsUtilities annUtilities = new DicomAnnotationsUtilities();
                annUtilities.ImageDpiX = 150.0;
                annUtilities.ImageDpiY = 150.0;

                DicomElement graphicSeq = ds.FindFirstElement(null, DicomTag.GraphicAnnotationSequence, true);

                if (null != graphicSeq && graphicSeq.Length > 0)
                {
                    MyPresentationStateRelationshipModule relationshipModule = ds.Get<MyPresentationStateRelationshipModule>();
                    GraphicAnnotationsModule globalReferencedImages = new GraphicAnnotationsModule();
                    globalReferencedImages.ReferencedImageSequence = new List<ImageSopInstanceReference>();


                    foreach (MyReferencedSeriesSequence refSeries in relationshipModule.ReferencedSeriesSequence)
                    {
                        globalReferencedImages.ReferencedImageSequence.AddRange(refSeries.ReferencedImageSequence);
                    }

                    DicomElement childItem = ds.GetChildElement(graphicSeq, false);
                    JavaScriptSerializer jSerializer = new JavaScriptSerializer();

                    int pageNumber = 1;

                    while (childItem != null && childItem.Length > 0)
                    {
                        AnnContainer mainContainer = annUtilities.FromDataSetToAnnContainer(ds, childItem);
                        AnnUserData annData = new AnnUserData();
                        GraphicAnnotationsModule annModule = ds.Get<GraphicAnnotationsModule>(childItem);

                        if (null == annModule || null == annModule.ReferencedImageSequence || 0 == annModule.ReferencedImageSequence.Count)
                        {
                            annModule = globalReferencedImages;
                        }

                        foreach (ImageSopInstanceReference instanceRef in annModule.ReferencedImageSequence)
                        {
                            AnnContainer container = mainContainer.Clone();


                            container.Mapper = mainContainer.Mapper.Clone();
                            annData.ReferencedImageSequence = instanceRef;
                            container.UserData = jSerializer.Serialize(annData);

                            codec.Save(ms, container, AnnFormat.Annotations, pageNumber);

                            pageNumber++;
                        }

                        childItem = ds.GetNextElement(childItem, true, false);
                    }
                }

                ms.Position = 0;

                return ms;
            }
        }

        public Layout GetSeriesLayout(string userName, string seriesInstanceUID, Lazy<IStoreAddin> storeAddin, string userData)
        {
            ObjectUID uid = new ObjectUID() { SeriesInstanceUID = seriesInstanceUID };
            DataTable instanceTable = GetDicomInstanceTable(uid, false);
            List<string> referencedFiles = new List<string>();

            foreach (DataRow row in instanceTable.Rows)
            {
               IInstanceInfo instanceInfo = RegisteredDataRows.InstanceInfo;
               string referencedFile = instanceInfo.ReferencedFile(row);
                if (!string.IsNullOrEmpty(referencedFile))
                {
                    if (File.Exists(referencedFile))
                    {
                        referencedFiles.Add(referencedFile);
                    }
                }
            }

            if (referencedFiles.Count > 0)
            {
                DataRow row = null;
                IInstanceInfo instanceInfo = RegisteredDataRows.InstanceInfo;

                // Series series = new Series() { Modality = "PR", SeriesDescription = "" };
                Dictionary<long, object> seriesValues = new Dictionary<long, object>();
                seriesValues.Add(DicomTag.Modality, "PR");
                seriesValues.Add(DicomTag.SeriesDescription, string.Empty);
                ICatalogEntity seriesEntity = RegisteredEntities.GetSeriesEntity(seriesValues);

                // Instance instance = new Instance() { SOPClassUID = DicomUidType.BasicStructuredDisplayStorage };
                Dictionary<long, object> instanceValues = new Dictionary<long, object>();
                instanceValues.Add(DicomTag.SOPClassUID, DicomUidType.BasicStructuredDisplayStorage);
                ICatalogEntity instanceEntity = RegisteredEntities.GetInstanceEntity(instanceValues);

                MatchingParameterCollection mpc = new MatchingParameterCollection();
                MatchingParameterList mpl = new MatchingParameterList();

#if !TUTORIAL_CUSTOM_DATABASE
                ReferencedSeriesSequence refSeries = new ReferencedSeriesSequence() { SeriesInstanceUID = seriesInstanceUID };
                mpl.Add(refSeries);
#endif

                mpl.Add(seriesEntity);
                mpl.Add(instanceEntity);
                mpc.Add(mpl);
                DataSet results = DataAccess.MinimumQueryCompositeInstances(mpc);

                bool foundStudyLayout = false;
                for (int i = 0; i < results.Tables[DataTableHelper.InstanceTableName].Rows.Count; i++)
                {
                   DataRow seriesRow = instanceInfo.GetSeriesRow(results.Tables[DataTableHelper.InstanceTableName].Rows[i]);
                   ISeriesInfo seriesInfo = RegisteredDataRows.SeriesInfo;
                   string seriesDescription = seriesInfo.GetElementValue(seriesRow, DicomTag.SeriesDescription);
                   if (seriesDescription == "FOR STUDY LAYOUT")
                   {
                      foundStudyLayout = true;
                      break;
                   }
                }

                for (int i = 0; i < results.Tables[DataTableHelper.InstanceTableName].Rows.Count; i++)
                {
                   DataRow seriesRow = instanceInfo.GetSeriesRow(results.Tables[DataTableHelper.InstanceTableName].Rows[i]);
                   ISeriesInfo seriesInfo = RegisteredDataRows.SeriesInfo;
                   string seriesDescription = seriesInfo.GetElementValue(seriesRow, DicomTag.SeriesDescription);

                   if (seriesDescription != "FOR STUDY LAYOUT")
                   {
                      row = results.Tables[DataTableHelper.InstanceTableName].Rows[i];
                      break;
                   }
                }

                //
                // Check to see if we have any results.  If we don't we need to create a structured display
                //           
                if (row == null || foundStudyLayout)
                {
                    DicomDataSet sdDataSet = CreateLayout(seriesInstanceUID, referencedFiles);

                    if (sdDataSet != null)
                    {
                        try
                        {
                            //
                            // Store the newly created structured display file.  The next request for for this series will load the layout
                            // from the database.
                            //
                            storeAddin.Value.DoStore(sdDataSet);
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                        }
                        return sdDataSet.ToLayout();
                    }
                }
                else
                {
                    DicomInstanceRetrieveCommand dsLoadCmd = new DicomInstanceRetrieveCommand(DataAccess);

                    using (DicomDataSet ds = dsLoadCmd.GetDicomDataSet(row))
                    {
                        return ds.ToLayout();
                    }
                }
            }

            return null;
        }


        private static bool IsImageBoxAssigned(StudyLayout studyLayout, int imageBoxNumber)
        {
           foreach(SeriesInfo si in studyLayout.Series)
           {
              if (si.ImageBoxNumber == imageBoxNumber)
              {
                 return true;
              }
           }
           return false;
        }

        private bool GetUidsFromDatabase(string sopInstanceUid, out string studyInstanceUid, out string seriesInstanceUid)
        {
           studyInstanceUid = string.Empty;
           seriesInstanceUid = string.Empty;

           IStorageDataAccessAgent3 myDataAccess = DataAccess;
           MatchingParameterCollection mpc = new MatchingParameterCollection();
           MatchingParameterList mpl = new MatchingParameterList();

           Instance instance = new Instance(sopInstanceUid);

           mpl.Add(instance);
           mpc.Add(mpl);

           DataSet ds = myDataAccess.MinimumQuerySeries(mpc);

           if((ds != null) && ds.SeriesRowCount() > 0)
           {
              DataRow seriesRow = ds.SeriesRows()[0];
              ISeriesInfo seriesInfo = RegisteredDataRows.SeriesInfo;
              studyInstanceUid = seriesInfo.GetElementValue(seriesRow, DicomTag.StudyInstanceUID);
              seriesInstanceUid = seriesInfo.GetElementValue(seriesRow, DicomTag.SeriesInstanceUID);
              return true;
           }
           return false;
        }

        private void FinalizeStudyLayout(StudyLayout studyLayout)
        {
           Dictionary<string, DicomUids> instanceDictionary = new Dictionary<string, DicomUids>();

           foreach (DataContracts.ImageBox imageBox in studyLayout.Boxes)
           {
              int imageBoxNumber = imageBox.ImageBoxNumber;

              if (IsImageBoxAssigned(studyLayout, imageBoxNumber) == false)
              {
                 foreach (string sopInstanceUid in imageBox.referencedSOPInstanceUID)
                 {
                    SeriesInfo seriesInfo = new SeriesInfo();
                    seriesInfo.ImageBoxNumber = imageBoxNumber;

                    DicomUids dicomUids = null;
                    if (instanceDictionary.TryGetValue(sopInstanceUid, out dicomUids))
                    {
                       seriesInfo.StudyInstanceUID = dicomUids.StudyInstanceUid;
                       seriesInfo.SeriesInstanceUID = dicomUids.SeriesInstanceUid;
                       studyLayout.Series.Add(seriesInfo);
                    }
                    else
                    {
                       string studyInstanceUid;
                       string seriesInstanceUid;
                       bool isSuccess = GetUidsFromDatabase(sopInstanceUid, out studyInstanceUid, out seriesInstanceUid);

                       if (isSuccess)
                       {
                          seriesInfo.StudyInstanceUID = studyInstanceUid;
                          seriesInfo.SeriesInstanceUID = seriesInstanceUid;
                          studyLayout.Series.Add(seriesInfo);

                          // Add to dictionary
                          dicomUids = new DicomUids
                                         {
                                            StudyInstanceUid = studyInstanceUid,
                                            SeriesInstanceUid = seriesInstanceUid
                                         };
                          instanceDictionary.Add(sopInstanceUid, dicomUids);
                       }
                    }
                 }
              }
           }
        }

        public List<StudyLayout> GetPatientStructuredDisplay(string userName, string patientID, string userData)
        {
            ICatalogEntity patientEntity = RegisteredEntities.GetPatientEntity(patientID);

            Dictionary<long, object> instanceValues = new Dictionary<long, object>();
            instanceValues.Add(DicomTag.SOPClassUID, DicomUidType.BasicStructuredDisplayStorage);
            ICatalogEntity instanceEntity = RegisteredEntities.GetInstanceEntity(instanceValues);

            MatchingParameterCollection mpc = new MatchingParameterCollection();
            MatchingParameterList mpl = new MatchingParameterList { patientEntity, instanceEntity };

            mpc.Add(mpl);
            DataSet results = DataAccess.MinimumQueryCompositeInstances(mpc);

            List<StudyLayout> output = new List<StudyLayout>();

            if (results.Tables[DataTableHelper.InstanceTableName].Rows.Count != 0)
            {
                int index = 0;
                int length = results.Tables[DataTableHelper.InstanceTableName].Rows.Count;

                for (index = 0; index < length; index++)
                {
                    DataRow row = results.Tables[DataTableHelper.InstanceTableName].Rows[index];
                    DicomInstanceRetrieveCommand dsLoadCmd = new DicomInstanceRetrieveCommand(DataAccess);

                    using (DicomDataSet ds = dsLoadCmd.GetDicomDataSet(row))
                    {
                        StudyLayout patientLayout = ds.ToStudyLayout();
                        FinalizeStudyLayout(patientLayout);

                        output.Add(patientLayout);
                    }
                }
            }


            return output;
        }


        public StudyLayout  GetStudyLayout(string userName, string studyInstanceUID, string userData)
        {
           // Study study = new Study() { StudyInstanceUID = studyInstanceUID };
           ICatalogEntity studyEntity = RegisteredEntities.GetStudyEntity(studyInstanceUID);

           // Series series = new Series() { Modality = "PR", SeriesDescription = "FOR STUDY LAYOUT" };
           Dictionary<long, object> seriesValues = new Dictionary<long, object>();
           seriesValues.Add(DicomTag.Modality, "PR");
           seriesValues.Add(DicomTag.SeriesDescription, "FOR STUDY LAYOUT");
           ICatalogEntity seriesEntity = RegisteredEntities.GetSeriesEntity(seriesValues);

           // Instance instance = new Instance() { SOPClassUID = DicomUidType.BasicStructuredDisplayStorage };
           Dictionary<long, object> instanceValues = new Dictionary<long, object>();
           instanceValues.Add(DicomTag.SOPClassUID, DicomUidType.BasicStructuredDisplayStorage);
           ICatalogEntity instanceEntity = RegisteredEntities.GetInstanceEntity(instanceValues);

           MatchingParameterCollection mpc = new MatchingParameterCollection();
           MatchingParameterList mpl = new MatchingParameterList { studyEntity, seriesEntity, instanceEntity};

           mpc.Add(mpl);
           DataSet results = DataAccess.MinimumQueryCompositeInstances(mpc);

           if (results.Tables[DataTableHelper.InstanceTableName].Rows.Count != 0)
           {
              DataRow row = results.Tables[DataTableHelper.InstanceTableName].Rows[0];
              DicomInstanceRetrieveCommand dsLoadCmd = new DicomInstanceRetrieveCommand(DataAccess);

              using (DicomDataSet ds = dsLoadCmd.GetDicomDataSet(row))
              {
                 StudyLayout studyLayout = ds.ToStudyLayout();
                 FinalizeStudyLayout(studyLayout);

                 return studyLayout;
              }
           }

           return null;
        }


        //
        // Provide code in this function to convert the series files to a Structured display dataset
        //
        /// <summary>
        /// Create a Layout for the specified series.
        /// </summary>
        /// <param name="seriesInstanceUID">The series instance UID.</param>
        /// <param name="referencedFiles">The list of referenced files in the series.</param>
        /// <returns>A Structured display dataset that contains information on how to layout the series.</returns>
        private DicomDataSet CreateLayout(string seriesInstanceUID, List<string> referencedFiles)
        {
            bool hasCreator = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["SDCreator"]);

            if (!hasCreator)
            {
                if (Cache.Get("SDCreator") != null)
                    Cache.Remove("SDCreator");
                return null;
            }
            else
            {
                try
                {
                    ISDCreator creator = Cache.Get("SDCreator") as ISDCreator;

                    if (creator == null)
                    {
                        creator = PluginLoader<ISDCreator>.Load(ConfigurationManager.AppSettings["SDCreator"]);
                        if (creator != null)
                        {
                            creator.Manufacturer = ConfigurationManager.AppSettings["SDManufacturer"];
                            creator.InstitutionName = ConfigurationManager.AppSettings["InstitutionName"];
                            creator.ContentDescription = ConfigurationManager.AppSettings["SDContentDescription"];
                            creator.ContentCreator = ConfigurationManager.AppSettings["SDContentCreator"];
                            Cache.Add("SDCreator", creator, null, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration,
                                      CacheItemPriority.Normal, null); // valid for one hour
                        }
                        else
                            return null;
                    }

                    return creator.Create(seriesInstanceUID, referencedFiles);
                }
                catch (Exception e)
                {

                }
                return null;
            }
        }

        private void PrepareThumbnailImage(RasterImage image, int width, int height)
        {
            if (image.Signed)
            {
                Leadtools.ImageProcessing.GrayscaleCommand cmd = new Leadtools.ImageProcessing.GrayscaleCommand(8);

                cmd.Run(image);
                //Set this flag to false because there is no signed 8 bit Gray scale image 
                image.Signed = false;
            }

            if (width < image.Width || height < image.Height)
            {
                ResizeImage(image, width, height, true);
            }
        }

        private Stream StreamThumbnailImage(RasterImage image, RasterCodecs codec, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height)
        {
            MemoryStream imageStream = new MemoryStream();

            codec.Options.Jpeg.Save.QualityFactor = qualityFactor;
            codec.Options.Jpeg.Save.Passes = -1;

            if (bitsPerPixel == 0)
            {
                if (image.BitsPerPixel >= 24)
                {
                    bitsPerPixel = 24;
                }
                else
                {
                    bitsPerPixel = 8;
                }

            }

            codec.Save(image, imageStream, GetRasterImageFormat(mimeType), bitsPerPixel);

            return imageStream;
        }

        public Stream GetSeriesThumbnail(string userName, string seriesInstanceUID, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height)
        {
            RasterImage image = null;

            try
            {
                DataRow instanceRow = GetFirstSeriesInstanceRow(seriesInstanceUID);

                if (instanceRow != null)
                {
                    //for a strong id:
                    //var sopInstanceUID = RegisteredDataRows.InstanceInfo.GetElementValue(instanceRow, DicomTag.SOPInstanceUID);

                    var referencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(instanceRow);

                    if (string.IsNullOrEmpty(referencedFile))//external storage?
                    {
                        MyDicomInstanceRetrieveExternalStoreCommand dsLoadCmd = new MyDicomInstanceRetrieveExternalStoreCommand(DataAccess, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, true);
                        using (var ds = dsLoadCmd.GetDicomDataSet(instanceRow, out referencedFile))
                        {
                        }
                    }

                    if (!string.IsNullOrEmpty(referencedFile))
                    {
                       using (var dicomSourceProxy = new DicomSourceProxy(DataCache))
                       {
                          var query = new ViewImageQuery() { Rasterize = true, FileName = referencedFile, FrameNumber = 1, Resolution = LeadSize.Create(width, height), MatchAspectRatio = true, MatchNearestResolution = false };

                          try
                          {
                             var result = dicomSourceProxy.Load(query);
                             image = result.Image;
                          }
                          catch
                          {
                             image = null;
                          }
                       }
                    }
                }

                if (null == image)
                {
                    image = GetDefaultImage(width, height);
                }

                if (null != image)
                {
                    PrepareThumbnailImage(image, width, height);
                    using (RasterCodecs codec = new RasterCodecs())
                    {
                        return StreamThumbnailImage(image, codec, mimeType, bitsPerPixel, qualityFactor, width, height);
                    }
                }

                throw new Exception("Failed to load thumbnail/default thumbnail image");
            }
            finally
            {
                if (image != null)
                {
                    image.Dispose();
                }
            }
        }

        private RasterImage GetDefaultImage(int width, int height)
        {
            //Create the empty image.
            using (Bitmap image = new Bitmap(width, height))
            {
                //draw a useless line for some data
                using (Graphics imageData = Graphics.FromImage(image))
                {
                    using (var pen = new Pen(Color.Red))
                    {
                        imageData.DrawLine(pen, 0, 0, width, height);
                    }

                    //Convert to byte array
                    MemoryStream memoryStream = new MemoryStream();
                    byte[] bitmapData;

                    using (memoryStream)
                    {
                        image.Save(memoryStream, ImageFormat.Bmp);
                        bitmapData = memoryStream.ToArray();
                    }
                }
                return RasterImageConverter.ConvertFromImage(image, ConvertFromImageOptions.None);
            }
        }

        private DataTable GetDicomInstanceTable(ObjectUID uid, bool IncludeImageInstance)
      {
         MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
         MatchingParameterList matchingList = new MatchingParameterList();

         matchingCollection.Add(matchingList);

         if (uid != null)
         {
            if (!string.IsNullOrEmpty(uid.StudyInstanceUID))
            {
               ICatalogEntity studyEntity = RegisteredEntities.GetStudyEntity(uid.StudyInstanceUID);

               matchingList.Add(studyEntity);
            }

            if (!string.IsNullOrEmpty(uid.SeriesInstanceUID))
            {
               ICatalogEntity seriesEntity = RegisteredEntities.GetSeriesEntity(uid.SeriesInstanceUID);

               matchingList.Add(seriesEntity);
            }

            if (!string.IsNullOrEmpty(uid.SOPInstanceUID))
            {
               ICatalogEntity instanceEntity = RegisteredEntities.GetInstanceEntity(uid.SOPInstanceUID);

               matchingList.Add(instanceEntity);
            }
         }

         DataSet dataSet = null;
         if (IncludeImageInstance)
         {
            dataSet = DataAccess.CustomQueryCompositeInstances(matchingCollection, ExtraQueryOptions.OptimizedImageInstance);
         }
         else
         {
            dataSet = DataAccess.MinimumQueryCompositeInstances(matchingCollection);
         }
         return dataSet.Tables[DataTableHelper.InstanceTableName];
      }

        private DataRow GetDicomInstanceRow(string sopInstanceUID)
        {
            ICatalogEntity instanceEntity = RegisteredEntities.GetInstanceEntity(sopInstanceUID);

            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();

            matchingList.Add(instanceEntity);
            matchingCollection.Add(matchingList);

            DataSet result = DataAccess.MinimumQueryCompositeInstances(matchingCollection);

            if (result.Tables[DataTableHelper.InstanceTableName].Rows.Count > 0)
            {
                return result.Tables[DataTableHelper.InstanceTableName].Rows[0];
            }
            else
            {
                return null;
            }
        }

        private DataRow GetFirstSeriesInstanceRow(string seriesInstanceUID)
        {
           ICatalogEntity seriesEntity = RegisteredEntities.GetSeriesEntity(seriesInstanceUID);
           MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
           MatchingParameterList matchingList = new MatchingParameterList();

           matchingList.Add(seriesEntity);
           matchingCollection.Add(matchingList);

           DataSet result = DataAccess.MinimumQueryCompositeInstances(matchingCollection);

           if (result.Tables[DataTableHelper.InstanceTableName].Rows.Count > 0)
           {
              return result.Tables[DataTableHelper.InstanceTableName].Rows[0];
           }
           else
           {
              return null;
           }
        }

        private DataRow GetHangingProtocolInstanceRow(string sopInstanceUID)
        {
            MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
            MatchingParameterList matchingList = new MatchingParameterList();
            HangingProtocolEntity protocol = new HangingProtocolEntity(sopInstanceUID);
            DataSet result = null;
            IStorageDataAccessAgent3 access = DataAccess as IStorageDataAccessAgent3;

            matchingList.Add(protocol);
            matchingCollection.Add(matchingList);

            result = access.QueryHangingProtocol(matchingCollection);
            if (result.Tables[DataTableHelper.HangingProtocolTableName].Rows.Count > 0)
            {
                return result.Tables[DataTableHelper.HangingProtocolTableName].Rows[0];
            }
            else
            {
                return null;
            }
        }


        private void StripDicomImage(DicomDataSet ds)
        {
            DicomElement pixelDataElement;


            pixelDataElement = ds.FindFirstElement(null, DicomTag.PixelData, true);

            if (null != pixelDataElement)
            {
                ds.DeleteElement(pixelDataElement);
            }
        }

        private byte[] SaveDICOMDataSet(DicomDataSet ds)
        {
            string strTempFile;


            strTempFile = Path.GetTempFileName();

            try
            {
                ds.Save(strTempFile, DicomDataSetSaveFlags.None);

                return File.ReadAllBytes(strTempFile);
            }
            finally
            {
                if (File.Exists(strTempFile))
                {
                    File.Delete(strTempFile);
                }
            }
        }

      private void ResizeImage
      (
         RasterImage bitmap,
         int width,
         int height,
         bool fitImage,
         RasterSizeFlags flags = RasterSizeFlags.Bicubic
      )
      {
         try
         {
            // do we need to resize the image?
            if ((width > 0) && (height > 0))
            {
               // Yes, resize but keep the image scale factor the same.
               // In other words, fit the image as much as you can into width/height.

                    if (bitmap.Width > width || bitmap.Height > height)
                    {
                        SizeCommand SizeCmd;
                        int resizeWidth = width, resizeHeight = height;

                        if (fitImage)
                            CalculateFitSize(bitmap.Width, bitmap.Height, width, height, out resizeWidth, out resizeHeight);

                  SizeCmd = new SizeCommand(resizeWidth,
                                              resizeHeight,
                                              flags);

                        for (int pageNumber = 1; pageNumber <= bitmap.PageCount; pageNumber++)
                        {
                            bitmap.Page = pageNumber;

                            SizeCmd.Run(bitmap);
                        }

                        bitmap.Page = 1;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static void CalculateFitSize
        (
           int imageWidth,
           int imageHeight,
           int fitWidth,
           int fitHeight,
           out int width,
           out int height
        )
        {
            try
            {
                if (imageWidth > fitWidth || imageHeight > fitHeight)
                {
                    double factor;
                    if (fitWidth < fitHeight)
                    {
                        factor = (double)fitWidth / (double)imageWidth;

                        if ((factor * (double)imageHeight) > (double)fitHeight)
                            factor = (double)fitHeight / (double)imageHeight;
                    }
                    else
                    {
                        factor = (double)fitHeight / (double)imageHeight;

                        if ((factor * (double)imageWidth) > (double)fitWidth)
                            factor = (double)fitWidth / (double)imageWidth;
                    }

                    width = Math.Max((int)((double)imageWidth * factor + 0.5F), 1);
                    height = Math.Max((int)((double)imageHeight * factor + 0.5F), 1);
                }
                else
                {
                    width = imageWidth;
                    height = imageHeight;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private RasterImageFormat GetRasterImageFormat(string mimeType)
        {
            try
            {
                RasterImageFormat fileFormat;


                if (string.IsNullOrEmpty(mimeType))
                {
                    return RasterImageFormat.Jpeg;
                }

                switch (mimeType)
                {
                    case SupportedMimeTypes.JPG:
                        {
                            //fileFormat = RasterImageFormat.Jpeg422 ;
                            fileFormat = RasterImageFormat.Jpeg;
                        }
                        break;

                    //case SupportedMimeTypes.Jpeg2000:
                    //{
                    //   fileFormat = RasterImageFormat.J2k ;
                    //}
                    //break ;

                    //case SupportedMimeTypes.Bmp:
                    //{
                    //   fileFormat = RasterImageFormat.Bmp ;
                    //}
                    //break ;

                    case SupportedMimeTypes.PNG:
                        {
                            fileFormat = RasterImageFormat.Png;
                        }
                        break;

                    //case SupportedMimeTypes.Tiff:
                    //{
                    //   fileFormat = RasterImageFormat.Tif ;
                    //}
                    //break ;

                    //case SupportedMimeTypes.TiffJpeg:
                    //{
                    //   fileFormat = RasterImageFormat.TifJpeg ;
                    //}
                    //break ;

                    //case SupportedMimeTypes.TiffJ2k:
                    //{
                    //   fileFormat = RasterImageFormat.TifJ2k ;
                    //}
                    //break ;

                    default:
                        throw new ArgumentException("Invalid image format",
                                                      mimeType);
                }

                return fileFormat;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw exception;
            }

        }


    }
    public static class SupportedMimeTypes
    {
        public const string DICOM = "application/dicom";
        public const string JPG = "image/jpeg";
        public const string WAVE = "audio/wav";
        public const string PNG = "image/png";
        public const string SVG = "image/svg+xml";
        public const string PDF = "application/pdf";
    }

    public class DataProp
    {
        public int maxLength;
        public int startOffset;
    }


    public class DicomInstanceRetrieveExternalStoreCommand
    {
        public IStorageDataAccessAgent StoreAgent { get; private set; }
        public Lazy<IExternalStoreDataAccessAgent> ExternalStoreAgent { get; private set; }
        public DicomDataSetLoadFlags Flags { get; set; }
        public bool CacheLocal { get; set; }

        private ICrud _defaultCrud = null;
        private ICrud DefaultCrud
        {
            get
            {
                if (_defaultCrud == null)
                {
                    _defaultCrud = new DefaultCrud();
                }
                return _defaultCrud;
            }
        }

        private string ServiceDirectory { get; set; }

        public DicomInstanceRetrieveExternalStoreCommand(IStorageDataAccessAgent storeAgent, Lazy<IExternalStoreDataAccessAgent> externalStoreAgent, string serviceDirectory, bool cacheLocal)
        {
            StoreAgent = storeAgent;
            ExternalStoreAgent = externalStoreAgent;
            Flags = DicomDataSetLoadFlags.None;
            ServiceDirectory = serviceDirectory;
            CacheLocal = cacheLocal;
        }

        public static void FillStoreCommandDefaultSettings(CStoreCommandConfiguration c, StorageAddInsConfiguration settings)
        {


            // Set the default store location

            c.DataSetStorageLocation = settings.StoreAddIn.StorageLocation;
            c.DicomFileExtension = settings.StoreAddIn.StoreFileExtension;

            // Set the default Overwrite location
            c.OverwriteBackupLocation = settings.StoreAddIn.OverwriteBackupLocation;

            // Set the default Backup location

            // Set the default CStoreFailures location
            //string storeFailuresLocation = Path.Combine(storeLocation, "StoreFailures");
            //settings.StoreAddIn.CStoreFailuresPath = Path.Combine(storeFailuresLocation, serviceName);

            c.DirectoryStructure.CreatePatientFolder = settings.StoreAddIn.DirectoryStructure.CreatePatientFolder;
            c.DirectoryStructure.CreateSeriesFolder = settings.StoreAddIn.DirectoryStructure.CreateSeriesFolder;
            c.DirectoryStructure.CreateStudyFolder = settings.StoreAddIn.DirectoryStructure.CreateStudyFolder;
            c.DirectoryStructure.UsePatientName = settings.StoreAddIn.DirectoryStructure.UsePatientName;
            c.DirectoryStructure.SplitPatientId = settings.StoreAddIn.DirectoryStructure.SplitPatientId;
            c.SaveThumbnail = settings.StoreAddIn.CreateThumbnailImage;
        }

        private object _lockObject = new object();

        public virtual DicomDataSet GetDicomDataSet(DataRow instanceData, out string referencedFileLocation)
        {
            lock (_lockObject)
            {
                referencedFileLocation = string.Empty;
                DicomDataSet ds = RegisteredDataRows.InstanceInfo.LoadDicomDataSet(instanceData, Flags);
                if (CacheLocal)
                {
                    bool exists = false;
                    Exception ex = DefaultCrud.ExistsDicom(instanceData, out exists);
                    if (!exists)
                    {
                        using (StorageModuleConfigurationManager StorageConfigManager = new StorageModuleConfigurationManager(true))
                        {
                            StorageConfigManager.Load(ServiceDirectory);
                            StorageAddInsConfiguration storageSettings = StorageConfigManager.GetStorageAddInsSettings();

                            CStoreCommandConfiguration storeConfig = new CStoreCommandConfiguration();
                            storeConfig.DicomFileExtension = storageSettings.StoreAddIn.StoreFileExtension;
                            FillStoreCommandDefaultSettings(storeConfig, storageSettings);

                            string storageLocation = CStoreCommand.GetStorageLocation(storeConfig, ds);
                            string sopInstanceUid = RegisteredDataRows.InstanceInfo.GetElementValue(instanceData, DicomTag.SOPInstanceUID);
                            string dicomInstancePath = Path.Combine(storageLocation, sopInstanceUid + "." + storeConfig.DicomFileExtension);

                            ICrud crud = DefaultInstanceInfo.GetRetrieveCrud(instanceData);
                            if (crud != null)
                            {
                                ex = crud.RetrieveFile(instanceData, dicomInstancePath);
                                if (ex == null)
                                {
                                    ExternalStoreAgent.Value.SetReferencedFile(sopInstanceUid, dicomInstancePath);
                                    referencedFileLocation = dicomInstancePath;
                                }
                            }
                        }
                    }
                }
                return ds;
            }
        }
    }


    public class MyDicomInstanceRetrieveExternalStoreCommand : DicomInstanceRetrieveExternalStoreCommand
    {

        ILoggingDataAccessAgent LoggingAgent { get; set; }

        public MyDicomInstanceRetrieveExternalStoreCommand(IStorageDataAccessAgent storeAgent, Lazy<IExternalStoreDataAccessAgent> externalStoreAgent, ILoggingDataAccessAgent loggingAgent, string serviceDirectory, bool cacheLocal)
           : base(storeAgent, externalStoreAgent, serviceDirectory, cacheLocal)
        {
            // Console.WriteLine("");
            LoggingAgent = loggingAgent;
        }

        public DicomDataSet GetDicomDataSet(DataRow instanceData)
        {
            string referencedFile = string.Empty;
            return GetDicomDataSet(instanceData, out referencedFile);
        }

        public DicomDataSet GetDicomDataSet(DataRow instanceData, out string referencedFile)
        {
            referencedFile = string.Empty;
            DicomDataSet ds = base.GetDicomDataSet(instanceData, out referencedFile);

            string debugMessage = string.Format("GetDicomDataSet: returned referenecedFile '{0}'", referencedFile); ;
            Debug.WriteLine(debugMessage);
            if (ds != null && !string.IsNullOrEmpty(referencedFile))
            {
                if (LoggingAgent != null)
                {
                    string fileName = Path.GetFileName(referencedFile);
                    string message = string.Format("[ExternalStore] '{0}' pulled from external store and cached to local store: '{1}'", fileName, referencedFile); ;
                    //Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                    //                 LogType.Information, MessageDirection.None, message, null, null);

                    DicomLogEntry logEntry = new DicomLogEntry();
                    logEntry.ServerAETitle = string.Empty;
                    logEntry.ServerIPAddress = string.Empty;
                    logEntry.ServerPort = -1;
                    logEntry.ClientAETitle = string.Empty;
                    logEntry.ClientIPAddress = string.Empty;
                    logEntry.ClientPort = -1;
                    logEntry.Command = DicomCommandType.Undefined;
                    logEntry.TimeStamp = DateTime.Now;
                    logEntry.LogType = LogType.Information;
                    logEntry.MessageDirection = MessageDirection.None;
                    logEntry.Description = message;
                    logEntry.DicomDataset = null;


                    debugMessage = string.Format("AddDicomEventLog: '{0}'", message);
                    LoggingAgent.AddDicomEventLog(logEntry);
                    Debug.WriteLine(debugMessage);

                }
            }
            return ds;
        }
    }

#if FOR_DOTNET4
    static class MyStopWatch
    {
       private static Stopwatch _stopWatch;

       public static void Start()
       {
          if (_stopWatch == null)
          {
             _stopWatch = new Stopwatch();
          }
          _stopWatch.Restart();
       }

       public static void Start(string s)
       {
          Start();
          Log(s);
       }

       public static void Log(string s)
       {
         if (_stopWatch == null)
         {
            Start();
         }
          string message = string.Format("[{0:F}] {1}", _stopWatch.ElapsedMilliseconds / 1000.0, s);
          Trace.WriteLine(message);
       }

       public static void Log(string s, int n)
       {
         if (_stopWatch == null)
         {
            Start();
         }
          string message = string.Format("[{0:F}] {1}: {2}", _stopWatch.ElapsedMilliseconds / 1000.0, s, n);
          Trace.WriteLine(message);
       }

       public static void Stop()
       {
          if (_stopWatch != null)
          {
             _stopWatch.Stop();
          }
       }
    }
#endif

#if !FOR_DOTNET4
    public class Tuple<T1, T2>
    {
       public T1 Item1 { get; private set; }
       public T2 Item2 { get; private set; }
       internal Tuple(T1 item1, T2 item2)
       {
          Item1 = item1;
          Item2 = item2;
       }
    }

#endif // #if FOR_DOTNET4

#if FOR_DOTNET4
public class InstanceItem
{
   public string SopInstanceUid;
   public dynamic Metadata;

   public InstanceItem(string sopInstanceUid, dynamic metadata)
   {
      SopInstanceUid = sopInstanceUid;
      Metadata = metadata;
   }
}

#else
public class InstanceItem
{
   public string SopInstanceUid;
   public object Metadata;

   public InstanceItem(string sopInstanceUid, object metadata)
   {
      SopInstanceUid = sopInstanceUid;
      Metadata = metadata;
   }
}
#endif //#if FOR_DOTNET4

   public class SeriesItem
   {
      public string SeriesInstanceUid;
      public List<InstanceItem> InstanceItemList;

      public SeriesItem(string seriesInstanceUid)
      {
         SeriesInstanceUid = seriesInstanceUid;
         InstanceItemList = new List<InstanceItem>();
      }
   }

    public class StudyDateItem
    {
      public StudyDateItem()
      {
         StudyDate = DateTime.Now;
         SeriesItemDictionary = new Dictionary<string, SeriesItem>();
      }

       public bool IsValid = true;
       public DateTime StudyDate { get; set;}
       public Dictionary<string, SeriesItem> SeriesItemDictionary; 
    }

    public class StudyDateGroup
    {
       public List<StudyDateItem> StudyDateItems = new List<StudyDateItem>();
       public List<StudyDateItem> InvalidItems = new List<StudyDateItem>();

       public SeriesItem FindSeriesItem(string seriesInstanceUid)
       {
          foreach (StudyDateItem studyDateItem in StudyDateItems)
          {
             if (studyDateItem.SeriesItemDictionary.ContainsKey(seriesInstanceUid))
             {
                SeriesItem seriesItem;
                if (studyDateItem.SeriesItemDictionary.TryGetValue(seriesInstanceUid, out seriesItem))
                {
                   return seriesItem;
                }
             }
          }
          return null;
       }

       public void Prune(List<ImageSetSelector> imageSetSelectors)
       {
         // Consolidate the lists
         foreach(StudyDateItem studyDateItem in InvalidItems)
         {
            StudyDateItems.Add(studyDateItem);
         }

         // Clear the invalid list
          InvalidItems.Clear();

          // Move Studies that fail imageSetSelectors criteria into a privateList
          foreach(StudyDateItem studyDateItem in StudyDateItems)
          {
             bool isValidStudy = false;
             foreach(string seriesInstanceUid in studyDateItem.SeriesItemDictionary.Keys)
             {
                SeriesItem seriesItem = studyDateItem.SeriesItemDictionary[seriesInstanceUid];

                foreach(InstanceItem instanceItem in seriesItem.InstanceItemList)
                {

                   //string notUsedStudyDate = ObjectRetrieveAddin.GetDicomTagValue(instanceItem.Metadata, DicomTag.StudyDate);
                   //string notUsedStudyTime = ObjectRetrieveAddin.GetDicomTagValue(instanceItem.Metadata, DicomTag.StudyTime);

                   //string notUsedStudyInstanceUID = ObjectRetrieveAddin.GetDicomTagValue(instanceItem.Metadata, DicomTag.StudyInstanceUID);
                   //string notUsedSopInstanceUid = ObjectRetrieveAddin.GetDicomTagValue(instanceItem.Metadata, DicomTag.SOPInstanceUID);
                   //string notUsedModality = ObjectRetrieveAddin.GetDicomTagValue(instanceItem.Metadata, DicomTag.Modality);
                   isValidStudy = ObjectRetrieveAddin.IsValidSeries(instanceItem.Metadata, imageSetSelectors);
                   if (isValidStudy)
                      break;
                }

                if (isValidStudy)
                   break;
             }
             studyDateItem.IsValid = isValidStudy;
          }

          // Move all the invalid studies out of the list
          for (int i = StudyDateItems.Count -1; i>=0; i--)
          {
             if (StudyDateItems[i].IsValid == false)
             {
                InvalidItems.Add(StudyDateItems[i]);
                StudyDateItems.RemoveAt(i);
             }
          }

          // Sort the list
          StudyDateItems.Sort((x, y) => y.StudyDate.CompareTo(x.StudyDate));

       }
    }
}
