// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.Annotations.Engine;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Leadtools.Annotations.Automation;

namespace Leadtools.Annotations.WinForms
{
   // This class is responsible to list all properties for each annotation object, 
   // taking in consideration the object type.
   public class AutomationObjectDescriptor : ICustomTypeDescriptor
   {
      static int NorbergObjectId = -1008;// Leadtools.Annotations.UserMedicalPack.AnnNorbergObjcet

      AnnObject _object;
      Type _type;

      string _friendlyName;

      //select which property we want to view (common,ruler,note...)
      private int _propertyType = AnnObject.RectangleObjectId;
      public int PropertyType
      {
         get
         {
            return _propertyType;
         }
         set
         {
            _propertyType = value;
         }
      }

      public string FriendlyName
      {
         get { return _friendlyName; }
      }

      string GetFriendlyName()
      {
         string friendlyName = _object.FriendlyName;

         // detect if the object is line or polyline, depending on the number of points it has.
         if (_object.Id == AnnObject.LineObjectId || (_object.Id == AnnObject.PolylineObjectId && _object.Points.Count == 2))
         {
            friendlyName = "Line";
         }
         // detect if the object is ruler or polyruler, depending on the number of points it has.
         else if (_object.Id == AnnObject.RulerObjectId || (_object.Id == AnnObject.PolyRulerObjectId && _object.Points.Count == 2))
         {
            friendlyName = "Ruler";
         }
         else if (_object.Id == AnnObject.FreehandObjectId)
         {
            friendlyName = "Freehand";
         }

         return string.Format("{0} {1}", friendlyName, "Properties");
      }

      private bool _showFixedState = true;

      public bool ShowFixedState
      {
         get { return _showFixedState; }
         set { _showFixedState = value; }
      }

      public AnnObject Object
      {
         get { return _object; }
      }

      private AnnAutomation _automation;
      public AnnAutomation Automation
      {
         get { return _automation; }
      }

      private AnnSelectionObject _selectionObject = null;

      AnnResources _resources;

      public AutomationObjectDescriptor(AnnObject editObject, AnnResources resources ,AnnAutomation automation)
      {
         if (editObject == null) throw new ArgumentNullException("editObject");
         if (resources == null) throw new ArgumentNullException("resources");

         _object = editObject;
         _type = _object.GetType();
         _friendlyName = GetFriendlyName();
         _resources = resources;
         _automation = automation;
         _selectionObject = automation.CurrentEditObject as AnnSelectionObject;
      }

      public String GetClassName()
      {
         return TypeDescriptor.GetClassName(this, true);
      }

      public AttributeCollection GetAttributes()
      {
         return TypeDescriptor.GetAttributes(this, true);
      }

      public String GetComponentName()
      {
         return TypeDescriptor.GetComponentName(this, true);
      }

      public TypeConverter GetConverter()
      {
         return TypeDescriptor.GetConverter(this, true);
      }

      public EventDescriptor GetDefaultEvent()
      {
         return TypeDescriptor.GetDefaultEvent(this, true);
      }

      public PropertyDescriptor GetDefaultProperty()
      {
         return TypeDescriptor.GetDefaultProperty(this, true);
      }

      public object GetEditor(Type editorBaseType)
      {
         return TypeDescriptor.GetEditor(this, editorBaseType, true);
      }

      public EventDescriptorCollection GetEvents(Attribute[] attributes)
      {
         return TypeDescriptor.GetEvents(this, attributes, true);
      }

      public EventDescriptorCollection GetEvents()
      {
         return TypeDescriptor.GetEvents(this, true);
      }

      public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
      {
         List<PropertyDescriptor> properties = new List<PropertyDescriptor>();

         if (_propertyType == AnnObject.RectangleObjectId)
         {
            // Adding common properties for all objects.
            AddObjectProperties(properties, string.Empty);
         }
         else if (_propertyType == AnnObject.TextObjectId)
         {
            AddTextProperties(properties, "Text");
         }
         else if (_propertyType == AnnObject.NoteObjectId)
         {
            AddNoteProperties(properties, "Note");
         }
         else if (_propertyType == AnnObject.TextRollupObjectId)
         {
            AddTextRollupProperties(properties, "Text Rollup");
         }
         else if (_propertyType == AnnObject.PolyRulerObjectId || _propertyType == AnnObject.RulerObjectId)
         {
            AddRulerProperties(properties, "Ruler");
         }
         else if (_propertyType == AnnObject.ProtractorObjectId)
         {
            AddProtractorProperties(properties, "Protractor");
         }
         else if (_propertyType == AnnObject.PolylineObjectId)
         {
            AddPolylineProperties(properties, "Polyline");
         }
         else if (_propertyType == AnnObject.CurveObjectId)
         {
            AddCurveProperties(properties, "Curve");
         }
         else if (_propertyType == AnnObject.RubberStampObjectId)
         {
            AddRubberStampProperties(properties, "Rubber Stamp");
         }
         else if (_propertyType == AnnObject.TextPointerObjectId)
         {
            AddTextPointerProperties(properties, "Text Pointer");
         }
         else if (_propertyType == AnnObject.StampObjectId)
         {
            AddPictureProperties(properties, "Stamp", null);
            properties.Add(new CustomPropertyDescriptor(_type.GetProperty("DrawShadow"), _object, "DrawShadow", "Stamp"));
         }
         else if (_propertyType == AnnObject.HotspotObjectId)
         {
            AddPictureProperties(properties, "Picture", _resources.Images[(_object as AnnHotspotObject).DefaultPicture]);
         }
         else if (_propertyType == AnnObject.FreehandHotspotObjectId)
         {
            AddPictureProperties(properties, "Picture", _resources.Images[(_object as AnnFreehandHotspotObject).DefaultPicture]);
         }
         else if (_propertyType == AnnObject.PointerObjectId)
         {
            AddPointerProperties(properties, "Pointer");
         }
         else if (_propertyType == AnnObject.MediaObjectId)
         {
            if (_object.Id == AnnObject.AudioObjectId)
            {
               AddAudioProperties(properties, "Media");
            }
            else
            {
               AddMediaProperties(properties, "Media");
            }
         }
         else if (_propertyType == AnnObject.EncryptObjectId)
         {
            AddEncryptProperties(properties, "Encrypt");
         }
         else if (_propertyType == AnnObject.PointObjectId)
         {
            AddPointProperties(properties, "Point");
         }
         else if (_propertyType == AnnObject.StickyNoteObjectId)
         {
            AddStickyNoteProperties(properties, "Sticky Note");
         }
         else if (_propertyType == AnnObject.CrossProductObjectId)
         {
            AddCrossProductProperties(properties, "Cross Product");
         }

         return new PropertyDescriptorCollection(properties.ToArray());
      }

      void AddObjectProperties(List<PropertyDescriptor> properties, string category)
      {
         // Adding Stroke properties.
         // Check if there is any object in selection list supports stroke
         bool addStroke = false;
         if (_selectionObject != null)
         {
            foreach (AnnObject annObject in _selectionObject.SelectedObjects)
               if (annObject.SupportsStroke)
                  addStroke = true;
         }
         else
         {
            addStroke = _object.SupportsStroke;
         }

         if (addStroke)
         {
            StrokeDescriptor stroke = new StrokeDescriptor(_object.Stroke, "Stroke");
            foreach (PropertyDescriptor property in stroke.GetProperties())
            {
               properties.Add(property);
            }
         }

         // Adding Fill property.
         if (_object.SupportsFill)
         {
            List<Attribute> attribs = new List<Attribute>();
            attribs.Add(new EditorAttribute(typeof(FillEditor), typeof(UITypeEditor)));

            if (_object.Id != AnnObject.HiliteObjectId)
            {
               properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Fill"), _object, "Style", "Fill", attribs.ToArray(), typeof(BrushConverter)));
            }
            else
            {
               properties.Add(new CustomPropertyDescriptor(_type.GetProperty("HiliteColor"), _object, "Color", "Fill", attribs.ToArray(), typeof(ColorConverter)));
            }
         }

         // Adding Hyperlink property.
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Hyperlink"), _object, "Hyperlink", "Misc"));

         if (_object.SupportsOpacity)
         {
            // Adding Opacity property.
            properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Opacity"), _object, "Opacity", "Misc"));
         }

         // Adding FixedState properties.
         if (_showFixedState)
         {
            FixedStateDescriptor fixedState = new FixedStateDescriptor(_object, "Fixed State");
            foreach (PropertyDescriptor property in fixedState.GetProperties())
            {
               properties.Add(property);
            }
         }

         // Adding metadata for
         if (_object.Metadata != null && _object.Metadata.Count > 0)
         {
            foreach (string key in _object.Metadata.Keys)
            {
               string value = _object.Metadata[key];
               if (!string.IsNullOrEmpty(value))
                  properties.Add(new CustomPropertyDescriptor(key, value, "Metadata"));
            }
         }

         // Adding labels.
         LabelDescriptor label = new LabelDescriptor(_object.Labels["AnnObjectName"], "Name", _automation);
         foreach (PropertyDescriptor property in label.GetProperties())
         {
            properties.Add(property);
         }
      }

      void AddPointProperties(List<PropertyDescriptor> properties, string category)
      {
         AnnPointObject annPointObject = _object as AnnPointObject;
         Attribute[] attribs = new Attribute[1] { new EditorAttribute(typeof(BitmapEditor), typeof(UITypeEditor)) };
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Picture"), _object, "Picture", category, attribs, typeof(PictureConverter), _resources.Images[annPointObject.DefaultPicture]));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("ShowPicture"), _object, "Show Picture", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Radius"), _object, "Radius", category));
      }

      void AddStickyNoteProperties(List<PropertyDescriptor> properties, string category)
      {
         AnnStickyNoteObject annStickyNoteObject = _object as AnnStickyNoteObject;
         Attribute[] attribs = new Attribute[1] { new EditorAttribute(typeof(BitmapEditor), typeof(UITypeEditor)) };

         object defaultValue = _resources.Images[annStickyNoteObject.DefaultPicture];
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Picture"), _object, "Picture", category, attribs, typeof(PictureConverter), _resources.Images[annStickyNoteObject.DefaultPicture]));
      }

      void AddEncryptProperties(List<PropertyDescriptor> properties, string category)
      {
         AnnEncryptObject encrypt = _object as AnnEncryptObject;
         Attribute[] attribs = new Attribute[1] { new EditorAttribute(typeof(BitmapEditor), typeof(UITypeEditor)) };
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("PrimaryPicture"), _object, "Primary Picture", category, attribs, typeof(PictureConverter), _resources.Images[encrypt.DefaultPrimaryPicture]));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("SecondaryPicture"), _object, "Secondary Picture", category, attribs, typeof(PictureConverter), _resources.Images[encrypt.DefaultSecondaryPicture]));
         if (!encrypt.IsEncrypted)
         {
            properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Encryptor"), _object, "Encryptor", category));
         }
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Key"), _object, "Key", category));
      }

      void AddProtractorProperties(List<PropertyDescriptor> properties, string category)
      {
         UnitsAbbreviationDescriptor annUnitsDescriptor = new UnitsAbbreviationDescriptor((_object as AnnProtractorObject).AngularUnitsAbbreviation, "Angular Units Abbreviation");
         foreach (PropertyDescriptor property in annUnitsDescriptor.GetProperties())
         {
            properties.Add(property);
         }

         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("AngularUnit"), _object, "Unit", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Acute"), _object, "Acute", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("AnglePrecision"), _object, "Precision", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("ArcRadius"), _object, "Arc Radius", category));

         if (_object.Id != NorbergObjectId)
         {
            AddLabelProperties(new LabelDescriptor(_object.Labels["FirstRulerLength"], "First Ruler Length Properties", _automation), properties, category);
            AddLabelProperties(new LabelDescriptor(_object.Labels["SecondRulerLength"], "Second Ruler Length Properties", _automation), properties, category);
         }

         AddLabelProperties(new LabelDescriptor(_object.Labels["AngleText"], "Angle Properties", _automation), properties, category);
      }

      static void AddLabelProperties(LabelDescriptor descriptor, List<PropertyDescriptor> properties, string category)
      {
         foreach (PropertyDescriptor property in descriptor.GetProperties())
         {
            if (property.Name == "Text")
               continue;
            properties.Add(property);
         }
      }

      void AddCrossProductProperties(List<PropertyDescriptor> properties, string category)
      {
         AddLabelProperties(new LabelDescriptor(_object.Labels["RulerLength"], "First Ruler Length Properties", _automation), properties, category);
         AddLabelProperties(new LabelDescriptor(_object.Labels["SecondaryRulerLength"], "Second Ruler Length Properties", _automation), properties, category);
      }

      void AddRulerProperties(List<PropertyDescriptor> properties, string category)
      {
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("MeasurementUnit"), _object, "Unit", category));

         UnitsAbbreviationDescriptor annUnitsDescriptor = new UnitsAbbreviationDescriptor((_object as AnnPolyRulerObject).UnitsAbbreviation, "Ruler Units Abbreviation");
         foreach (PropertyDescriptor property in annUnitsDescriptor.GetProperties())
         {
            properties.Add(property);
         }

         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("GaugeLength"), _object, "GaugeLength", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("TickMarksLength"), _object, "TickMarksLength", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Precision"), _object, "Precision", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("ShowGauge"), _object, "ShowGauge", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("ShowTickMarks"), _object, "ShowTickMarks", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("ShowTickValue"), _object, "ShowTickValue", category));

         if (!(_object is AnnCrossProductObject) && !(_object is AnnProtractorObject))
         {
            AddLabelProperties(new LabelDescriptor(_object.Labels["RulerLength"], "Ruler Length Properties", _automation), properties, category);
         }
      }

      void AddPointerProperties(List<PropertyDescriptor> properties, string category)
      {
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("ArrowLength"), _object, "Arrow Length", category));
      }

      void AddPictureProperties(List<PropertyDescriptor> properties, string category, AnnPicture defaultValue)
      {
         Attribute[] attribs = new Attribute[1] { new EditorAttribute(typeof(BitmapEditor), typeof(UITypeEditor)) };
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Picture"), _object, "Picture", category, attribs, typeof(PictureConverter), defaultValue));
      }

      void AddAudioProperties(List<PropertyDescriptor> properties, string category)
      {
         Attribute[] attribs = new Attribute[1] { new EditorAttribute(typeof(WavFileNameEditor), typeof(UITypeEditor)) };
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Media"), _object, "Media", category, attribs, typeof(MediaConverter)));
      }

      void AddMediaProperties(List<PropertyDescriptor> properties, string category)
      {
         Attribute[] attribs = new Attribute[1] { new EditorAttribute(typeof(MediaFileNameEditor), typeof(UITypeEditor)) };
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Media"), _object, "Uri", category, attribs, typeof(MediaConverter)));
      }

      void AddRubberStampProperties(List<PropertyDescriptor> properties, string category)
      {
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("RubberStampType"), _object, "Type", category));
      }

      void AddCurveProperties(List<PropertyDescriptor> properties, string category)
      {
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Tension"), _object, "Tension", category));
      }

      void AddPolylineProperties(List<PropertyDescriptor> properties, string category)
      {
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("IsClosed"), _object, "Closed", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("FillRule"), _object, "Fill Rule", category));
      }

      void AddTextProperties(List<PropertyDescriptor> properties, string category)
      {
         Attribute[] attribs;
         if (_object.SupportsFont)
         {
            attribs = new Attribute[1] { new EditorAttribute(typeof(FontEditor), typeof(UITypeEditor)) };
            properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Font"), _object, "Font", category, attribs, typeof(FontConverter)));
         }

         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Text"), _object, "Text", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("HorizontalAlignment"), _object, "Horizontal Alignment", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("VerticalAlignment"), _object, "Vertical Alignment", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("TextRotate"), _object, "Rotate", category));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("WordWrap"), _object, "WordWrap", category));

         attribs = new Attribute[1] { new EditorAttribute(typeof(ColorEditor), typeof(UITypeEditor)) };

         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("TextForeground"), _object, "Foreground", category, attribs, typeof(BrushConverter)));
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("TextBackground"), _object, "Background", category, attribs, typeof(BrushConverter)));
      }

      void AddTextRollupProperties(List<PropertyDescriptor> properties, string category)
      {
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("Expanded"), _object, "Expanded", category));
      }

      void AddNoteProperties(List<PropertyDescriptor> properties, string category)
      {
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("ShadowBorderWidth"), _object, "Shadow Width", category));
      }

      void AddTextPointerProperties(List<PropertyDescriptor> properties, string category)
      {
         properties.Add(new CustomPropertyDescriptor(_type.GetProperty("FixedPointer"), _object, "Fixed Pointer", category));
      }

      public PropertyDescriptorCollection GetProperties()
      {
         return GetProperties(null);
      }

      public object GetPropertyOwner(PropertyDescriptor pd)
      {
         return this;
      }
   }
}
