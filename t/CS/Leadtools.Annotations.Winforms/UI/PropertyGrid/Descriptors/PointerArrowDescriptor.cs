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
   public class PointerArrowProxy
   {
      private AnnPointerObject _annPointerObjet;
      private AnnAutomation _automation;
      public PointerArrowProxy(AnnPointerObject pointerObject, AnnAutomation automation)
      {
         _annPointerObjet = pointerObject;
         _automation = automation;
      }
      public LeadLengthD ArrowLength
      {
         get
         {
            if (_automation != null)
            {
               AnnContainerMapper mapper = _automation.Container.Mapper.Clone();
               mapper.UpdateTransform(LeadMatrix.Identity);
               return LeadLengthD.Create(mapper.LengthFromContainerCoordinates(_annPointerObjet.ArrowLength, AnnFixedStateOperations.None));
            }
            else return LeadLengthD.Create(30);
         }
         set
         {
            if (_automation != null)
            {
               AnnContainerMapper mapper = _automation.Container.Mapper.Clone();
               mapper.UpdateTransform(LeadMatrix.Identity);
               _annPointerObjet.ArrowLength = mapper.LengthToContainerCoordinates(value.Value);
            }
         }
      }
   }

   public class PointerArrowDescriptor : CustomTypeDescriptor
   {
      private AnnPointerObject _annPointerObject;
      private string _category;
      private AnnAutomation _automation;

      public PointerArrowDescriptor(AnnPointerObject annPointerObject, string category, AnnAutomation automation)
      {
         _annPointerObject = annPointerObject;
         _category = category;
         _automation = automation;
      }

      public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
      {
         List<PropertyDescriptor> properties = new List<PropertyDescriptor>(1);

         PointerArrowProxy proxy = new PointerArrowProxy(_annPointerObject, _automation);
         Type t = typeof(PointerArrowProxy);

         properties.Add(new CustomPropertyDescriptor(t.GetProperty("ArrowLength"), proxy, "ArrowLength", _category));

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
