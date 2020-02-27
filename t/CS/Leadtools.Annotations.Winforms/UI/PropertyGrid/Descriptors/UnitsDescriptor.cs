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

namespace Leadtools.Annotations.WinForms
{
   public class AngularUnitsAbbreviationProxy
   {
      Dictionary<AnnAngularUnit, string> _units;

      public string Radian
      {
         get { return _units[AnnAngularUnit.Radian]; }
         set { _units[AnnAngularUnit.Radian] = value; }
      }

      public string Degree
      {
         get { return _units[AnnAngularUnit.Degree]; }
         set { _units[AnnAngularUnit.Degree] = value; }
      }


      public AngularUnitsAbbreviationProxy(Dictionary<AnnAngularUnit, string> units)
      {
         _units = units;
      }
   }

   public class UnitsAbbreviationProxy
   {
      Dictionary<AnnUnit, string> _units;

      public string Unit
      {
         get { return _units[AnnUnit.Unit]; }
         set { _units[AnnUnit.Unit] = value; }
      }

      public string Display
      {
         get { return _units[AnnUnit.Display]; }
         set { _units[AnnUnit.Display] = value; }
      }

      public string Document
      {
         get { return _units[AnnUnit.Document]; }
         set { _units[AnnUnit.Document] = value; }
      }

      public string Inch
      {
         get { return _units[AnnUnit.Inch]; }
         set { _units[AnnUnit.Inch] = value; }
      }

      public string Millimeter
      {
         get { return _units[AnnUnit.Millimeter]; }
         set { _units[AnnUnit.Millimeter] = value; }
      }

      public string Point
      {
         get { return _units[AnnUnit.Point]; }
         set { _units[AnnUnit.Point] = value; }
      }

      public string Feet
      {
         get { return _units[AnnUnit.Feet]; }
         set { _units[AnnUnit.Feet] = value; }
      }
      public string Yard
      {
         get { return _units[AnnUnit.Yard]; }
         set { _units[AnnUnit.Yard] = value; }
      }

      public string Micrometer
      {
         get { return _units[AnnUnit.Micrometer]; }
         set { _units[AnnUnit.Micrometer] = value; }
      }

      public string Centimeter
      {
         get { return _units[AnnUnit.Centimeter]; }
         set { _units[AnnUnit.Centimeter] = value; }
      }

      public string Meter
      {
         get { return _units[AnnUnit.Meter]; }
         set { _units[AnnUnit.Meter] = value; }
      }

      public string Twip
      {
         get { return _units[AnnUnit.Twip]; }
         set { _units[AnnUnit.Twip] = value; }
      }

      public string Pixel
      {
         get { return _units[AnnUnit.Pixel]; }
         set { _units[AnnUnit.Pixel] = value; }
      }

      public UnitsAbbreviationProxy(Dictionary<AnnUnit, string> units)
      {
         _units = units;
      }
   }

   public class UnitsAbbreviationDescriptor : CustomTypeDescriptor
   {
      Dictionary<AnnUnit, string> _units;
      Dictionary<AnnAngularUnit, string> _angularUnits;
      string _category;
      bool _isAngularUnit = false;
      public UnitsAbbreviationDescriptor(Dictionary<AnnUnit, string> units, string category)
      {
         _units = units;
         _category = category;
      }

      public UnitsAbbreviationDescriptor(Dictionary<AnnAngularUnit, string> units, string category)
      {
         _angularUnits = units;
         _category = category;
         _isAngularUnit = true;
      }

      public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
      {
         List<CustomPropertyDescriptor> properties = new List<CustomPropertyDescriptor>();

         if (!_isAngularUnit)
         {
            Type t = typeof(UnitsAbbreviationProxy);

            UnitsAbbreviationProxy proxy = new UnitsAbbreviationProxy(_units);
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Unit"), proxy, "Unit", _category));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Display"), proxy, "Display", _category));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Document"), proxy, "Document", _category));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Inch"), proxy, "Inch", _category));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Millimeter"), proxy, "Millimeter", _category));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Point"), proxy, "Point", _category));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Feet"), proxy, "Feet", _category));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Yard"), proxy, "Yard", _category));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Micrometer"), proxy, "Micrometer", _category));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Centimeter"), proxy, "Centimeter", _category));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Meter"), proxy, "Meter", _category));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Twip"), proxy, "Twip", _category));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Pixel"), proxy, "Pixel", _category));
         }
         else
         {
            Type t = typeof(AngularUnitsAbbreviationProxy);

            AngularUnitsAbbreviationProxy proxy = new AngularUnitsAbbreviationProxy(_angularUnits);
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Radian"), proxy, "Radian", _category));
            properties.Add(new CustomPropertyDescriptor(t.GetProperty("Degree"), proxy, "Degree", _category));
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
