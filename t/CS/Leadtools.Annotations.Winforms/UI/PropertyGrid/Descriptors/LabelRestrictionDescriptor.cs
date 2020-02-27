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
   // This class maps AnnLabelRestriction enumeration to boolean properties.
   // so we can display them as check boxes in the property grid.
   public class LabelRestrictionProxy
   {
      AnnLabel _annLabel;
      public LabelRestrictionProxy(AnnLabel annLabel)
      {
         _annLabel = annLabel;
      }

      public bool RestrictToContainer
      {
         get
         {
            return (_annLabel.RestrictionMode & AnnLabelRestriction.RestrictToContainer) == AnnLabelRestriction.RestrictToContainer;
         }
         set
         {
            if (value)
            {
               _annLabel.RestrictionMode |= AnnLabelRestriction.RestrictToContainer;
            }
            else
            {
               _annLabel.RestrictionMode &= ~AnnLabelRestriction.RestrictToContainer;
            }
         }
      }

      public bool RestrictToObjectBounds
      {
         get
         {
            return (_annLabel.RestrictionMode & AnnLabelRestriction.RestrictToObjectBounds) == AnnLabelRestriction.RestrictToObjectBounds;
         }
         set
         {
            if (value)
            {
               _annLabel.RestrictionMode |= AnnLabelRestriction.RestrictToObjectBounds;
            }
            else
            {
               _annLabel.RestrictionMode &= ~AnnLabelRestriction.RestrictToObjectBounds;
            }
         }
      }

   }

   // This class describes the AnnLabelRestriction flags, after mapping them to boolean 
   // properties using LabelRestrictionProxy instanse.
   public class LabelRestrictionDescriptor : CustomTypeDescriptor
   {
      AnnLabel _annLabel;
      string _category;

      public LabelRestrictionDescriptor(AnnLabel annLabel, string category)
      {
         _annLabel = annLabel;
         _category = category;
      }

      public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
      {
         List<CustomPropertyDescriptor> properties = new List<CustomPropertyDescriptor>();

         LabelRestrictionProxy proxy = new LabelRestrictionProxy(_annLabel);
         Type type = typeof(LabelRestrictionProxy);

         properties.Add(new CustomPropertyDescriptor(type.GetProperty("RestrictToContainer"), proxy, "Restrict To Container", _category));
         properties.Add(new CustomPropertyDescriptor(type.GetProperty("RestrictToObjectBounds"), proxy, "Restrict To Object Bounds", _category));

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
