// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Leadtools.Annotations.Engine;
using System.Drawing.Design;
using System.Reflection;
using System.Globalization;

namespace Leadtools.Annotations.WinForms
{
   public class StrokeStyleProxy
   {
      AnnStroke _stroke;
      public StrokeStyleProxy(AnnStroke stroke)
      {
         if (stroke == null) throw new ArgumentNullException("stroke");

         _stroke = stroke;

         if (_stroke.StrokeDashArray != null && _stroke.StrokeDashArray.Length > 0)
         {
            StringBuilder builder = new StringBuilder();
            foreach(double item in _stroke.StrokeDashArray)
            {
               builder.Append(item);
               builder.Append(",");
            }

            string strokeDashArray = builder.ToString();
            strokeDashArray = strokeDashArray.TrimEnd(',');

            if (strokeDashArray == "3,1")
               _style = StrokeStyle.Dash;
            else if (strokeDashArray == "1,1")
               _style = StrokeStyle.Dot;
            else if (strokeDashArray == "3,1,1,1")
               _style = StrokeStyle.DashDot;
            else if (strokeDashArray == "3,1,1,1,1,1")
               _style = StrokeStyle.DashDotDot;
            else
               _style = StrokeStyle.Dot;
         }
      }

      StrokeStyle _style;

      public StrokeStyle Style
      {
         get { return _style; }
         set 
         {
            _style = value;
            switch (value)
            {
               case StrokeStyle.Dash :
                  _stroke.StrokeDashArray = new double[] { 3, 1 };
               break;

            case StrokeStyle.Dot:          // Dotted line
               _stroke.StrokeDashArray = new double[] { 1, 1 };
               break;

            case StrokeStyle.DashDot:      // Dash dot line
               _stroke.StrokeDashArray = new double[] { 3, 1, 1, 1 };
               break;

            case StrokeStyle.DashDotDot:   // Dash dot dot line
               _stroke.StrokeDashArray = new double[] { 3, 1, 1, 1, 1, 1 };
               break;

               default : // Solid
               _stroke.StrokeDashArray = null;
               break;
            }
         }
      }
   }

   public class StrokeDescriptor : CustomTypeDescriptor
   {
      AnnStroke _stroke;
      string _category;
      StrokeStyle _style = StrokeStyle.Solid;

      public StrokeStyle Style
      {
         get { return _style; }
         set { _style = value; }
      }

      public StrokeDescriptor(AnnStroke stroke, string category)
      {
         _stroke = stroke;
         _category = category;
      }

      public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
      {
         List<CustomPropertyDescriptor> properties = new List<CustomPropertyDescriptor>();

         Type t = typeof(AnnStroke);

         List<Attribute> attribs = new List<Attribute>();
         attribs.Add(new EditorAttribute(typeof(ColorEditor), typeof(UITypeEditor)));
         properties.Add(new CustomPropertyDescriptor(t.GetProperty("Stroke"), _stroke, "Color", _category, attribs.ToArray(), typeof(BrushConverter)));
         properties.Add(new CustomPropertyDescriptor(t.GetProperty("StrokeThickness"), _stroke, "Width", _category));

         StrokeStyleProxy proxy = new StrokeStyleProxy(_stroke);
         properties.Add(new CustomPropertyDescriptor(typeof(StrokeStyleProxy).GetProperty("Style"), proxy, "Style", _category));

         return new PropertyDescriptorCollection(properties.ToArray());
      }

      public override PropertyDescriptorCollection GetProperties()
      {
         return GetProperties(null);
      }

      public override object GetPropertyOwner(PropertyDescriptor pd)
      {
         return this;
      }
   }
}
