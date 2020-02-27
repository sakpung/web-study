// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Annotations.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Text;

namespace Leadtools.Annotations.WinForms
{
   class FillDescriptor : CustomTypeDescriptor
   {
      private AnnBrush _brush;
      private string _category;



      public FillDescriptor(AnnBrush brush, string category)
      {
         _brush = brush;
         _category = category;
      }

      public AnnBrush Brush
      {
         get { return _brush; }
      }

      public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
      {
         List<CustomPropertyDescriptor> properties = new List<CustomPropertyDescriptor>();

         Type t = typeof(AnnBrush);

         List<Attribute> attribs = new List<Attribute>();
         attribs.Add(new EditorAttribute(typeof(ColorEditor), typeof(UITypeEditor)));

         if(_brush is AnnSolidColorBrush)
         {
            t = typeof(AnnSolidColorBrush);
            var info = t.GetProperty("Color");
            properties.Add(new CustomPropertyDescriptor(info, _brush, "Color", _category, attribs.ToArray(), typeof(ColorConverter)));
         }
         else if(_brush is AnnHatchBrush)
         {
            t = typeof(AnnHatchBrush);
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("BackgroundColor"), _brush, "Background Color", _category, attribs.ToArray(), typeof(ColorConverter)));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("ForegroundColor"), _brush, "Foreground Color", _category, attribs.ToArray(), typeof(ColorConverter)));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("HatchStyle"), _brush, "Hatch Style", _category));
         }

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
