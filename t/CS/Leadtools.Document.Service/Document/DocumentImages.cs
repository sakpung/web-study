// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentImages
   {
      [DataMember(Name = "isSvgSupported")]
      public bool IsSvgSupported;

      [DataMember(Name = "isSvgViewingPreferred")]
      public bool IsSvgViewingPreferred;

      [DataMember(Name = "isResolutionsSupported")]
      public bool IsResolutionsSupported;

      [DataMember(Name = "defaultBitsPerPixel")]
      public int DefaultBitsPerPixel;

      [DataMember(Name = "maximumImagePixelSize")]
      public int MaximumImagePixelSize;

      [DataMember(Name = "thumbnailPixelSize")]
      public LeadSize ThumbnailPixelSize;

      [DataMember(Name = "unembedSvgImages")]
      public bool UnembedSvgImages;

      public static RasterViewPerspective RotateViewPerspective(RasterViewPerspective value, int angle)
      {
         while (angle < 0)
            angle += 360;
         while (angle >= 360)
            angle -= 360;

         switch (angle)
         {
            case 0:
               break;

            case 270:
               value = RotateViewPerspective90(value);
               // and fall through
               goto case 180;
            case 180:
               value = RotateViewPerspective90(value);
               // and fall through
               goto case 90;
            case 90:
               value = RotateViewPerspective90(value);
               break;

            default:
               throw new ArgumentException("Must be in increment of 90 degrees", "angle");
         }

         return value;
      }

      private static RasterViewPerspective RotateViewPerspective90(RasterViewPerspective value)
      {
         switch (value)
         {
            case RasterViewPerspective.TopLeft:
               return RasterViewPerspective.TopLeft90;
            case RasterViewPerspective.TopLeft90:
               return RasterViewPerspective.TopLeft180;
            case RasterViewPerspective.TopLeft180:
               return RasterViewPerspective.TopLeft270;
            case RasterViewPerspective.TopLeft270:
               return RasterViewPerspective.TopLeft;
            case RasterViewPerspective.BottomLeft:
               return RasterViewPerspective.BottomLeft90;
            case RasterViewPerspective.BottomLeft90:
               return RasterViewPerspective.BottomLeft180;
            case RasterViewPerspective.BottomLeft180:
               return RasterViewPerspective.BottomLeft270;
            case RasterViewPerspective.BottomLeft270:
               return RasterViewPerspective.BottomLeft;
            default:
               return value;
         }
      }

      internal static RasterViewPerspective ReverseViewPerspective(RasterViewPerspective value)
      {
         switch (value)
         {
            case RasterViewPerspective.TopLeft:
               value = RasterViewPerspective.TopRight;
               break;
            case RasterViewPerspective.TopRight:
               value = RasterViewPerspective.TopLeft;
               break;
            case RasterViewPerspective.BottomLeft:
               value = RasterViewPerspective.BottomRight;
               break;
            case RasterViewPerspective.BottomRight:
               value = RasterViewPerspective.BottomLeft;
               break;
            case RasterViewPerspective.LeftTop:
               value = RasterViewPerspective.RightTop;
               break;
            case RasterViewPerspective.RightTop:
               value = RasterViewPerspective.LeftTop;
               break;
            case RasterViewPerspective.LeftBottom:
               value = RasterViewPerspective.RightBottom;
               break;
            case RasterViewPerspective.RightBottom:
               value = RasterViewPerspective.LeftBottom;
               break;
         }

         return value;
      }

      public static RasterViewPerspective FlipViewPerspective(RasterViewPerspective value)
      {
         switch (value)
         {
            case RasterViewPerspective.TopLeft:
               value = RasterViewPerspective.BottomLeft;
               break;
            case RasterViewPerspective.BottomLeft:
               value = RasterViewPerspective.TopLeft;
               break;
            case RasterViewPerspective.TopRight:
               value = RasterViewPerspective.BottomRight;
               break;
            case RasterViewPerspective.BottomRight:
               value = RasterViewPerspective.TopRight;
               break;
            case RasterViewPerspective.LeftTop:
               value = RasterViewPerspective.LeftBottom;
               break;
            case RasterViewPerspective.LeftBottom:
               value = RasterViewPerspective.LeftTop;
               break;
            case RasterViewPerspective.RightTop:
               value = RasterViewPerspective.RightBottom;
               break;
            case RasterViewPerspective.RightBottom:
               value = RasterViewPerspective.RightTop;
               break;
         }

         return value;
      }

      internal static DocumentRotateFlip GetRotateFlip(RasterViewPerspective srcViewPerspective, RasterViewPerspective destViewPerspective)
      {
         bool srcFlip = false;
         bool srcReversed = false;
         bool destFlip = false;
         int angle = 0;

         switch (srcViewPerspective)
         {
            case RasterViewPerspective.TopLeft:
               break;
            case RasterViewPerspective.TopLeft90:
               angle = 90;
               break;
            case RasterViewPerspective.TopLeft180:
               angle = 180;
               break;
            case RasterViewPerspective.TopLeft270:
               angle = 270;
               break;
            case RasterViewPerspective.BottomLeft:
               srcFlip = true;
               break;
            case RasterViewPerspective.BottomLeft90:
               //sb: I prefer Flip to Reverse, since it is faster with any BPP (especially 2-7)
               srcFlip = true;
               angle = 90;
               break;
            case RasterViewPerspective.BottomLeft180:
               srcReversed = true;
               break;
            case RasterViewPerspective.BottomLeft270:
               srcFlip = true;
               angle = 270;
               break;
            default:
               break;
         }

         // now from RasterViewPerspective.TopLeft to ViewPerspective
         switch (destViewPerspective)
         {
            case RasterViewPerspective.TopLeft:
               break;
            case RasterViewPerspective.TopLeft90:
               angle -= 90;
               break;
            case RasterViewPerspective.TopLeft180:
               angle -= 180;
               break;
            case RasterViewPerspective.TopLeft270:
               angle -= 270;
               break;
            case RasterViewPerspective.BottomLeft:
               destFlip = true;
               break;
            case RasterViewPerspective.BottomLeft90:
               angle -= 90;
               destFlip = true;
               break;
            case RasterViewPerspective.BottomLeft180:
               destFlip = true;
               angle -= 180;
               break;
            case RasterViewPerspective.BottomLeft270:
               destFlip = true;
               angle -= 270;
               break;
            default:
               break;
         }

         // Now I want to have bDstFlip and bDstRev to be false, so I want to reduce the 
         //    situation to have a Flip or a reverse and then a rotate
         // A destination flip is equivalent to a source flip and a rotation in the opposite direction
         if (destFlip)
         {
            destFlip = false;
            srcFlip = !srcFlip;
            angle = -angle;
         }

         // at this moment, we have no destination flip nor reverse. 
         if (srcFlip && srcReversed)
         {
            srcFlip = srcReversed = false;
            angle += 180;
         }

         if (srcReversed)
         {// in this case, srcFlip must be false
            srcFlip = true;
            angle -= 180;
            srcReversed = false;
         }

         if (angle < 0)
            angle += 360;
         else if (angle >= 360)
            angle -= 360;

         return new DocumentRotateFlip
         {
            IsFlipped = srcFlip,
            RotationAngle = angle
         };
      }
   }
}
