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
   // This class maps AnnFixedState enumeration to boolean properties.
   // so we can display them as check boxes in the property grid.
   public class FixedStateProxy
   {
      AnnObject _annObject;
      public FixedStateProxy(AnnObject annObject)
      {
          _annObject = annObject;
      }

      public bool StrokeWidth
      {
          get
          {
              return (_annObject.FixedStateOperations & AnnFixedStateOperations.StrokeWidth) == AnnFixedStateOperations.StrokeWidth;
          }
          set
          {
             if (value)
             {
                _annObject.FixedStateOperations |= AnnFixedStateOperations.StrokeWidth;
             }
             else
             {
                _annObject.FixedStateOperations &= ~AnnFixedStateOperations.StrokeWidth;
             }
          }
      }

      public bool FontSize
      {
          get
          {
              return (_annObject.FixedStateOperations & AnnFixedStateOperations.FontSize) == AnnFixedStateOperations.FontSize;
          }
          set
          {
             if (value)
             {
                _annObject.FixedStateOperations |= AnnFixedStateOperations.FontSize;
             }
             else
             {
                _annObject.FixedStateOperations &= ~AnnFixedStateOperations.FontSize;
             }
          }
      }

      public bool Zooming
      {
          get
          {
              return (_annObject.FixedStateOperations & AnnFixedStateOperations.Zooming) == AnnFixedStateOperations.Zooming;
          }
          set
          {
             if (value)
             {
                _annObject.FixedStateOperations |= AnnFixedStateOperations.Zooming;
             }
             else
             {
                _annObject.FixedStateOperations &= ~AnnFixedStateOperations.Zooming;
             }
          }
      }

      public bool Scrolling
      {
          get
          {
              return (_annObject.FixedStateOperations & AnnFixedStateOperations.Scrolling) == AnnFixedStateOperations.Scrolling;
          }
          set
          {
             if (value)
             {
                _annObject.FixedStateOperations |= AnnFixedStateOperations.Scrolling;
             }
             else
             {
                _annObject.FixedStateOperations &= ~AnnFixedStateOperations.Scrolling;
             }
          }
      }
   }

   // This class describes the AnnFixedState flags, after mapping them to boolean 
   // properties using FixedStateProxy instanse.
   public class FixedStateDescriptor : CustomTypeDescriptor
   {
      AnnObject _annObject;
      string _category;

      public FixedStateDescriptor(AnnObject annObject, string category)
      {
         _annObject = annObject;
         _category = category;
      }

      public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
      {
         List<CustomPropertyDescriptor> properties = new List<CustomPropertyDescriptor>();

         FixedStateProxy proxy = new FixedStateProxy(_annObject);
         Type type = typeof(FixedStateProxy);

         properties.Add(new CustomPropertyDescriptor(type.GetProperty("StrokeWidth"), proxy, "Stroke Width", _category));
         properties.Add(new CustomPropertyDescriptor(type.GetProperty("FontSize"), proxy, "Font Size", _category));
         properties.Add(new CustomPropertyDescriptor(type.GetProperty("Zooming"), proxy, "Zooming", _category));
         properties.Add(new CustomPropertyDescriptor(type.GetProperty("Scrolling"), proxy, "Scrolling", _category));

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
