// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.ImageProcessing;
using System.Drawing;
using Leadtools.DataAccessLayers.Core;
using Leadtools.Dicom;
using System.IO;

namespace Leadtools.Medical.WebViewer.Addins
{
    public static class Extensions
    {
        public static Point Transform(this RectangleF from, PointF source, RectangleF to)
        {
            Point dest = new Point();


            dest.X = (int)((((source.X - from.Left) / from.Width) * to.Width) + to.Left);
            dest.Y = (int)((((source.Y - from.Top) / from.Height) * to.Height) + to.Top);

            return dest;
        }

        public static RasterImage GetResizedImageToAspectRatio(this RasterImage originalImage, int destinationWidth, int destinationHeight)
        {
            float factor;

            // check which is bigger, width or height of page rectangle, fit accordingly
            if (destinationWidth > destinationHeight)
            {
                factor = (float)destinationWidth / originalImage.Width;

                // check if this factor does not exceed the height, if so, use the height instead
                if ((factor * originalImage.Height) > destinationHeight)
                    factor = (float)destinationHeight / originalImage.Height;
            }
            else
            {
                factor = (float)destinationHeight / originalImage.Height;
                if ((factor * originalImage.Width) > destinationWidth)
                    factor = (float)destinationWidth / originalImage.Width;
            }

            return new RasterImage(RasterMemoryFlags.Conventional,
                                     (int)(originalImage.Width * factor),
                                     (int)(originalImage.Height * factor),
                                     originalImage.BitsPerPixel,
                                     originalImage.Order,
                                     originalImage.ViewPerspective,
                                     originalImage.GetPalette(),
                                     null,
                                     0);
        }

        public static bool TryParse<T>(this string strType,
          out T result)
        {
            string strTypeFixed = strType.Replace(' ', '_');
            if (Enum.IsDefined(typeof(T), strTypeFixed))
            {
                result = (T)Enum.Parse(typeof(T), strTypeFixed, true);
                return true;
            }
            else
            {
                foreach (string value in Enum.GetNames(typeof(T)))
                {
                    if (value.Equals(strTypeFixed,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        result = (T)Enum.Parse(typeof(T), value);
                        return true;
                    }
                }
                result = default(T);
                return false;
            }
        }

        public static IBCoordinate ToCoordinate(this FramePosition position)
        {
            IBCoordinate coordinate = new IBCoordinate();

            coordinate.Left = position.leftTop.X;
            coordinate.Top = position.leftTop.Y;
            coordinate.Right = position.rightBottom.X;
            coordinate.Bottom = position.rightBottom.Y;

            return coordinate;
        }

        public static void CopyAllTo<T>(this object source, T target)
        {
            var type = source.GetType();
            var targetType = typeof(T);

            foreach (var sourceProperty in type.GetProperties())
            {
                var targetProperty = targetType.GetProperty(sourceProperty.Name);

                if (targetProperty != null && (targetProperty.PropertyType == sourceProperty.PropertyType))
                {
                    targetProperty.SetValue(target, sourceProperty.GetValue(source, null), null);
                }
            }

            foreach (var sourceField in type.GetFields())
            {
                var targetField = targetType.GetField(sourceField.Name);

                if (targetField != null)
                {
                    targetField.SetValue(target, sourceField.GetValue(source));
                }
            }
        }
      
    }
}
