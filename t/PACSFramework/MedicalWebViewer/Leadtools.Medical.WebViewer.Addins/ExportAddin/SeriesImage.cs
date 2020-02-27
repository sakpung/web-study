// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.WebViewer.DataContracts
{
    public class SeriesImage
    {
        public string SeriesInstanceUID { get; set; }
        public string SOPInstanceUID { get; set; }
        public RasterImage Image { get; set; }
        public double XDpi{ get; set; }
        public double YDpi{ get; set; }

        public SeriesImage()
        {

        }

        public SeriesImage(string seriesInstanceUID, string sopInstanceUID, RasterImage image)
        {
            SeriesInstanceUID = seriesInstanceUID;
            SOPInstanceUID = sopInstanceUID;
            Image = image;
        }
        public SeriesImage(string seriesInstanceUID, string sopInstanceUID, RasterImage image, double xDpi, double yDpi)
        {
            SeriesInstanceUID = seriesInstanceUID;
            SOPInstanceUID = sopInstanceUID;
            Image = image;
            XDpi = xDpi;
            YDpi = yDpi;
        }
    }
}
