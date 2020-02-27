// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;

using Leadtools;
using Leadtools.Ocr;
using Leadtools.Drawing;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Designers;

namespace OcrDemo
{
   public class ZoneAnnotationObject : AnnRectangleObject
   {
      private int _zoneIndex;
      private IOcrPage _ocrPage;
      private AnnStroke _cellPen;
      private AnnLabel mylabel;

      public ZoneAnnotationObject() :
         base()
      {
         _ocrPage = null;
         _zoneIndex = 0;
         _cellPen = null;
         SetId(AnnObject.UserObjectId);

         mylabel = this.Labels["AnnObjectName"];
         mylabel.Background = AnnSolidColorBrush.Create("Black");
         mylabel.Foreground = AnnSolidColorBrush.Create("White");
         mylabel.RestrictionMode = AnnLabelRestriction.None;
         mylabel.IsVisible = true;
      }

      public void SetZone(IOcrPage ocrPage, int zoneIndex, bool isVisible, bool isNameVisible)
      {
         _ocrPage = ocrPage;
         _zoneIndex = zoneIndex;

         IsVisible = isVisible;
         mylabel.IsVisible = isNameVisible;

         if (_ocrPage != null && _zoneIndex >= 0 && _zoneIndex < _ocrPage.Zones.Count)
         {
            OcrZone zone = _ocrPage.Zones[_zoneIndex];
            if (string.IsNullOrEmpty(zone.Name))
               mylabel.Text = "Zone " + (_zoneIndex + 1).ToString();
            else
               mylabel.Text = zone.Name;

            if (zone.ZoneType == OcrZoneType.None || zone.ZoneType == OcrZoneType.Graphic || zone.ZoneType == OcrZoneType.Barcode)
            {
               RasterColor color = RasterColorConverter.FromColor(Color.FromArgb(32, Color.Yellow));
               this.Fill = AnnSolidColorBrush.Create(color.ToString());//Color.FromArgb(32, Color.Yellow)
               this.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Blue"), new LeadLengthD(1));
            }
            else
               this.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), new LeadLengthD(1));

         }
      }

      public void ClearTableCells()
      {
         if (_ocrPage != null && _zoneIndex >= 0 && _ocrPage.Zones != null && _zoneIndex < _ocrPage.Zones.Count)
         {
            OcrZone zone = _ocrPage.Zones[_zoneIndex];
            OcrZoneCell[] cells = null;

            cells = _ocrPage.Zones.GetZoneCells(zone);

            if (cells != null)
            {
               _ocrPage.Zones.SetZoneCells(zone, null);
            }
         }
      }

      public int ZoneIndex
      {
         get { return _zoneIndex; }
      }

      public AnnStroke CellPen
      {
         get { return _cellPen; }
         set { _cellPen = value; }
      }

      public AnnLabel Label
      {
         get { return mylabel; }
         set { mylabel = value; }
      }

      protected override AnnObject Create()
      {
         return new ZoneAnnotationObject();
      }

      public override AnnObject Clone()
      {
         ZoneAnnotationObject obj = base.Clone() as ZoneAnnotationObject;
         obj._ocrPage = _ocrPage;
         obj._zoneIndex = _zoneIndex;
         obj.CellPen = CellPen != null ? CellPen.Clone() as AnnStroke : null;

         return obj;
      }
   }
}
