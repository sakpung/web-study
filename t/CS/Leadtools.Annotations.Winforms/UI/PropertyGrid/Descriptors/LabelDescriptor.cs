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
using Leadtools.Annotations.Automation;

namespace Leadtools.Annotations.WinForms
{

   public class LabelProxy
   {
      private AnnLabel _annLabel;
      private AnnAutomation _automation;
      public LabelProxy(AnnLabel annLabel, AnnAutomation automation)
      {
         _annLabel = annLabel;
         _automation = automation;
      }

      public AnnFont Font
      {
         get
         {
            return _annLabel.Font;
         }
         set
         {
            _annLabel.Font = value;
         }
      }

      public AnnBrush Background
      {
         get
         {
            return _annLabel.Background;
         }
         set
         {
            _annLabel.Background = value;
         }
      }

      public AnnBrush Foreground
      {
         get
         {
            return _annLabel.Foreground;
         }
         set
         {
            _annLabel.Foreground = value;
         }
      }

      public bool IsVisible
      {
         get
         {
            return _annLabel.IsVisible;
         }
         set
         {
            _annLabel.IsVisible = value;
         }
      }

      public string Text
      {
         get
         {
            return _annLabel.Text;
         }
         set
         {
            _annLabel.Text = value;
         }
      }
      public LeadPointD Offset
      {
         get
         {
            if (_automation != null)
            {
               double offsetX = _automation.Container.Mapper.LengthFromContainerCoordinates(LeadLengthD.Create(_annLabel.Offset.X), AnnFixedStateOperations.None);
               double offsetY = _automation.Container.Mapper.LengthFromContainerCoordinates(LeadLengthD.Create(_annLabel.Offset.Y), AnnFixedStateOperations.None);
               return new LeadPointD(offsetX, offsetY);
            }
            else return new LeadPointD(0, 0);
         }
         set
         {
            if (_automation != null)
            {
               LeadLengthD offsetX = _automation.Container.Mapper.LengthToContainerCoordinates(value.X);
               LeadLengthD offsetY = _automation.Container.Mapper.LengthToContainerCoordinates(value.Y);
               _annLabel.Offset = new LeadPointD(offsetX.Value, offsetY.Value);
            }
         }
      }
   }

   public class LabelDescriptor : CustomTypeDescriptor
   {
      private AnnLabel _label;
      private string _category;
      private AnnAutomation _automation;

      public LabelDescriptor(AnnLabel label, string category, AnnAutomation automation)
      {
         _label = label;
         _category = category;
         _automation = automation;
      }

      public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
      {
         List<PropertyDescriptor> properties = new List<PropertyDescriptor>(7);

         LabelProxy proxy = new LabelProxy(_label, _automation);
         Type t = typeof(LabelProxy);

         List<Attribute> attribs = new List<Attribute>();

         attribs.Add(new EditorAttribute(typeof(FontEditor), typeof(UITypeEditor)));
         properties.Add(new CustomPropertyDescriptor(t.GetProperty("Font"), proxy, "Font", _category, attribs.ToArray(), typeof(FontConverter)));

         attribs.Clear();
         attribs.Add(new EditorAttribute(typeof(ColorEditor), typeof(UITypeEditor)));
         properties.Add(new CustomPropertyDescriptor(t.GetProperty("Background"), proxy, "Background", _category, attribs.ToArray(), typeof(BrushConverter)));
         properties.Add(new CustomPropertyDescriptor(t.GetProperty("Foreground"), proxy, "Foreground", _category, attribs.ToArray(), typeof(BrushConverter)));
         properties.Add(new CustomPropertyDescriptor(t.GetProperty("IsVisible"), proxy, "Visible", _category));
         properties.Add(new CustomPropertyDescriptor(t.GetProperty("Text"), proxy, "Text", _category));
         properties.Add(new CustomPropertyDescriptor(t.GetProperty("Offset"), proxy, "Offset", _category));

         LabelRestrictionDescriptor labelRestriction = new LabelRestrictionDescriptor(_label, _category);
         foreach (PropertyDescriptor property in labelRestriction.GetProperties())
         {
            properties.Add(property);
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
